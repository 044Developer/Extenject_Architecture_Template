using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace StaticData.UIStaticData.PanelsData
{
    [CreateAssetMenu(fileName = "PanelsStaticDataContainer", menuName = "StaticData/UI/PanelStaticData")]
    public class PanelsStaticDataContainer : StaticData
    {            
        [SerializeField] private List<UIPanelStaticData> _panelsStaticData = null;
        
        public string GetPath(UIPanelType panelType)
        {
            return _panelsStaticData.Find(it => it.PanelType == panelType).ResourcePath;
        }

        public AssetReferenceGameObject GetAddressableAsset(UIPanelType panelType)
        {
            return _panelsStaticData.Find(it => it.PanelType == panelType).AssetReferenceGameObject;
        }
    }
}