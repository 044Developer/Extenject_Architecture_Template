using System.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Infrastructure.Services.AssetProvider
{
    public interface IAssetProvider
    {
        void Initialize();
        T Load<T>(string assetReference) where T : UnityEngine.Object;
        Task<T> LoadAsync<T>(string assetReference) where T : class;
        Task<T> LoadAsync<T>(AssetReferenceGameObject assetReference) where T : class;
        void CleanUp();
    }
}