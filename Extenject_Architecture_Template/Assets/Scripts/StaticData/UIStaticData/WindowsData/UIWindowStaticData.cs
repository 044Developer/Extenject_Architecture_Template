using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace StaticData.UIStaticData.WindowsData
{
    [Serializable]
    public class UIWindowStaticData : IWindowStaticData
    {
        [SerializeField] private UIWindowType _windowType = UIWindowType.None;
        [SerializeField] private string _resourcePath = string.Empty;
        [SerializeField] private AssetReferenceGameObject _assetReferenceGameObject = null;

        public UIWindowType WindowType => _windowType;
        public string ResourcePath => _resourcePath;
        public AssetReferenceGameObject AssetReferenceGameObject => _assetReferenceGameObject;
    }

    public enum UIWindowType
    {
        None,
        UIHolder,
        LoadingWindow,
        EnterWindow,
        ExitWindow,
    }
}