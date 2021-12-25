using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Infrastructure.Factories
{
    public interface ICustomFactory
    {
        T Create<T>(string assetReference);
        T Create<T>(string assetReference, Transform parent);
        T Create<T>(string assetReference, Vector3 position, Quaternion quaternion, Transform parent);
        Task<T> CreateAsync<T>(AssetReferenceGameObject assetReference);
        Task<T> CreateAsync<T>(AssetReferenceGameObject assetReference, Transform parent);
        Task<T> CreateAsync<T>(AssetReferenceGameObject assetReference, Vector3 position, Quaternion quaternion, Transform parent);
    }
}