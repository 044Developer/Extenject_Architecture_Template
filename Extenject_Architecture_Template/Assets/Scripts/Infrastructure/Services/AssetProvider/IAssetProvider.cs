using UnityEngine;

namespace Infrastructure.Services.AssetProvider
{
    public interface IAssetProvider
    {
        GameObject GetAsset(string path);
    }
}