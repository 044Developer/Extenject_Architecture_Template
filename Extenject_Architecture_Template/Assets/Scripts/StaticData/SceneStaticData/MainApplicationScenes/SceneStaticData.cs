using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace StaticData.SceneStaticData.MainApplicationScenes
{
    [Serializable]
    public class SceneStaticData
    {
        [SerializeField] private SceneType _sceneType = SceneType.None;
        [SerializeField] private string _scenePath = string.Empty;
        [SerializeField] private AssetReference _sceneReference = null;

        public SceneType SceneType => _sceneType;
        public string ScenePath => _scenePath;
        public AssetReference SceneReference => _sceneReference;
    }
    public enum SceneType { None, Initial, Main, Level_1, Level_2, Level_3, Level_4 }
}