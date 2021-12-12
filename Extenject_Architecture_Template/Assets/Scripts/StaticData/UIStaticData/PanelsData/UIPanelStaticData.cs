using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace StaticData.UIStaticData.PanelsData
{
    [Serializable]    
    public class UIPanelStaticData
    {
        [SerializeField] private UIPanelType _panelType = UIPanelType.None;
        [SerializeField] private string _resourcePath = string.Empty;
        [SerializeField] private AssetReferenceGameObject _assetReferenceGameObject = null;

        public UIPanelType PanelType => _panelType;
        public string ResourcePath => _resourcePath;
        public AssetReferenceGameObject AssetReferenceGameObject => _assetReferenceGameObject;
    }

    public enum UIPanelType
    {
        None,
        MainPanel,
    }
}