using System.Threading.Tasks;
using Infrastructure.Services.AssetProvider;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Infrastructure.Factories
{
    public class CustomFactory : ICustomFactory
    {
        private readonly DiContainer _container = null;
        private readonly IAssetProvider _assetProvider = null;

        public CustomFactory(DiContainer container, IAssetProvider assetProvider)
        {
            _container = container;
            _assetProvider = assetProvider;
        }

        public T Create<T>(string assetReference)
        {
            var prefab = _assetProvider.Load<GameObject>(assetReference);
            return BindAndInstantiate<T>(prefab);
        }

        public T Create<T>(string assetReference, Transform parent)
        {
            var prefab = _assetProvider.Load<GameObject>(assetReference);
            return BindAndInstantiate<T>(prefab, parent);
        }

        public T Create<T>(string assetReference, Vector3 position, Quaternion quaternion, Transform parent)
        {
            var prefab = _assetProvider.Load<GameObject>(assetReference);
            return BindAndInstantiate<T>(prefab, position, quaternion, parent);
        }

        public async Task<T> CreateAsync<T>(AssetReferenceGameObject assetReference)
        {
            var prefab = await _assetProvider.LoadAsync<GameObject>(assetReference); 
            return BindAndInstantiate<T>(prefab);
        }

        public async Task<T> CreateAsync<T>(AssetReferenceGameObject assetReference, Transform parent)
        {
            var prefab = await _assetProvider.LoadAsync<GameObject>(assetReference); 
            return BindAndInstantiate<T>(prefab, parent);
        }

        public async Task<T> CreateAsync<T>(AssetReferenceGameObject assetReference, Vector3 position, Quaternion quaternion, Transform parent)
        {
            var prefab = await _assetProvider.LoadAsync<GameObject>(assetReference); 
            return BindAndInstantiate<T>(prefab, position, quaternion, parent);
        }

        private  T BindAndInstantiate<T>(GameObject prefab)
        {
            _container.Unbind<T>();
            return _container.InstantiatePrefabForComponent<T>(prefab);
        }

        private  T BindAndInstantiate<T>(GameObject prefab, Transform parent)
        {
            _container.Unbind<T>();
            return _container.InstantiatePrefabForComponent<T>(prefab, parent);
        }

        private  T BindAndInstantiate<T>(GameObject prefab, Vector3 position, Quaternion quaternion, Transform parent)
        {
            _container.Unbind<T>();
            return _container.InstantiatePrefabForComponent<T>(prefab, position, quaternion, parent);
        }
    }
}