using System.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Infrastructure.Services.AssetProvider
{
    public interface IAssetProvider
    {
        void Initialize();
        Task<T> Load<T>(string assetReference) where T : class;
        Task<T> Load<T>(AssetReferenceGameObject assetReference) where T : class;
        void CleanUp();
    }
}