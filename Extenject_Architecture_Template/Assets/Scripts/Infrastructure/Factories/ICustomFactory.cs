using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Infrastructure.Factories
{
    public interface ICustomFactory
    {
        Task<T> Create<T>(AssetReferenceGameObject assetReference);
        Task<T> Create<T>(AssetReferenceGameObject assetReference, Transform parent);
        Task<T> Create<T>(AssetReferenceGameObject assetReference, Vector3 position, Quaternion quaternion, Transform parent);
    }
}