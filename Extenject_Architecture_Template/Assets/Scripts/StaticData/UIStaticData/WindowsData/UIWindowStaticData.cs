using System;
using UnityEngine;

namespace StaticData.UIStaticData.WindowsData
{
    [Serializable]
    public class UIWindowStaticData : IWindowStaticData
    {
        [SerializeField] private UIWindowType _windowType = UIWindowType.None;
        [SerializeField] private string _resourcePath = string.Empty;

        public UIWindowType WindowType => _windowType;
        public string ResourcePath => _resourcePath;
    }

    public enum UIWindowType
    {
        None,
        EnterWindow,
        ExitWindow,
    }
}