using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Infrastructure.Services.AssetProvider
{
    public class AssetProviderService : IAssetProvider, IInitializable
    {
        private readonly Dictionary<string, AsyncOperationHandle> _completedHandles = new Dictionary<string, AsyncOperationHandle>();
        private readonly Dictionary<string, List<AsyncOperationHandle>> _temporaryHandles = new Dictionary<string, List<AsyncOperationHandle>>();

        public void Initialize()
        {
            Addressables.InitializeAsync();
        }

        public T Load<T>(string assetReference) where T : UnityEngine.Object
        {
            var resource = UnityEngine.Resources.Load(assetReference);
            return (T)resource;
        }

        public async Task<T> LoadAsync<T>(AssetReferenceGameObject assetReference) where T : class
        {
            if (_completedHandles.TryGetValue(assetReference.AssetGUID, out AsyncOperationHandle completedHandle))
                return completedHandle.Result as T;

            AsyncOperationHandle<T> asyncOperationHandle = Addressables.LoadAssetAsync<T>(assetReference);
            AsyncOperationHandle<T> handle = asyncOperationHandle;

            string completedKey = assetReference.AssetGUID;
            return await LoadHandleWithCompletedCache(handle, completedKey);
        }
        
        public async Task<T> LoadAsync<T>(string assetReference) where T : class
        {
            if (_completedHandles.TryGetValue(assetReference, out AsyncOperationHandle completedHandle))
                return completedHandle.Result as T;

            AsyncOperationHandle<T> asyncOperationHandle = Addressables.LoadAssetAsync<T>(assetReference);
            AsyncOperationHandle<T> handle = asyncOperationHandle;

            string completedKey = assetReference;
            return await LoadHandleWithCompletedCache(handle, completedKey);
        }

        public void CleanUp()
        {
            foreach (List<AsyncOperationHandle> handles in _temporaryHandles.Values)
            {
                foreach (AsyncOperationHandle operationHandle in handles)
                {
                    Addressables.Release(operationHandle);
                }
            }
            
            _completedHandles.Clear();
            _temporaryHandles.Clear();
        }

        private void AddTemporaryHandles<T>(string key, AsyncOperationHandle<T> handle) where T : class
        {
            if (!_temporaryHandles.TryGetValue(key, out List<AsyncOperationHandle> tempHandles))
            {
                tempHandles = new List<AsyncOperationHandle>();
                _temporaryHandles[key] = tempHandles;
            }
 
            tempHandles.Add(handle);
        }

        private async Task<T> LoadHandleWithCompletedCache<T>(AsyncOperationHandle<T> handle, string completedKey) where T : class
        {
            handle.Completed += newCompletedHandle =>
            {
                _completedHandles[completedKey] = newCompletedHandle;
            };

            AddTemporaryHandles(completedKey, handle);

            return await handle.Task;
        }
    }
}