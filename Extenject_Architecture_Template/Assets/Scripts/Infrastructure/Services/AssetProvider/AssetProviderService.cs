using UnityEngine;

namespace Infrastructure.Services.AssetProvider
{
    public class AssetProviderService : IAssetProvider
    {
        public AssetProviderService()
        {
        
        }

        public GameObject GetAsset(string path)
        {
            return Resources.Load(path) as GameObject;
        }
    }
}