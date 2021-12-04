using System.Collections.Generic;
using UnityEngine;

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
    }
}