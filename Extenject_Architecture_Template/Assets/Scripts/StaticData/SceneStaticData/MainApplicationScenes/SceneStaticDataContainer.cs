using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace StaticData.SceneStaticData.MainApplicationScenes
{
    [CreateAssetMenu(fileName = "ScenesStaticDataContainer", menuName = "StaticData/Scenes/Common_Scenes")]
    public class SceneStaticDataContainer : StaticData
    {
        [SerializeField] private List<SceneStaticData> _sceneStaticData = null;

        public string GetAssetPath(SceneType sceneType)
        {
            return _sceneStaticData.Find(it => it.SceneType == sceneType).ScenePath;
        }
        
        public string GetAssetPath(string sceneName)
        {
            return _sceneStaticData.Find(it => it.ScenePath == sceneName).ScenePath;
        }
        
        public AssetReference GetAddressableAsset(SceneType sceneType)
        {
            return _sceneStaticData.Find(it => it.SceneType == sceneType).SceneReference;
        }
    }
}