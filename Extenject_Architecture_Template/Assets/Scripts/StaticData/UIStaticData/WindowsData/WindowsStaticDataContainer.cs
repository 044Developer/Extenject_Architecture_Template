using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace StaticData.UIStaticData.WindowsData
{
    [CreateAssetMenu(fileName = "WindowsStaticDataContainer", menuName = "StaticData/UI/WindowStaticData")]
    public class WindowsStaticDataContainer : UIStaticData
    {
        [SerializeField] private List<UIWindowStaticData> _windowStaticData = null;
        
        public string GetPath(UIWindowType windowType)
        {
            return _windowStaticData.Find(it => it.WindowType == windowType).ResourcePath;
        }

        public AssetReferenceGameObject GetAddressableAssetGetAsset(UIWindowType windowType)
        {
            return _windowStaticData.Find(it => it.WindowType == windowType).AssetReferenceGameObject;
        }
    }
}