using System;
using StaticData.SceneStaticData.MainApplicationScenes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Services.SceneLoader
{
    public class SceneLoaderService : ISceneLoaderService<string, SceneType>
    {
        private readonly SceneStaticDataContainer _sceneStaticDataContainer;
        private string _currentSceneName = String.Empty;
        
        public SceneLoaderService(SceneStaticDataContainer sceneStaticDataContainer)
        {
            _sceneStaticDataContainer = sceneStaticDataContainer;
        }
        
        public void LoadSceneAsync(string scene, LoadSceneMode loadSceneMode)
        {
            SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        }

        public AsyncOperation LoadSceneAsync(SceneType scene, LoadSceneMode loadSceneMode)
        {
            string assetPath = GetPath(scene);
            AsyncOperation loadTask = SceneManager.LoadSceneAsync(assetPath, loadSceneMode);
            UnLoadCurrentScene();
            _currentSceneName = assetPath;

            return loadTask;
        }

        private string GetPath(SceneType sceneType)
        {
            return _sceneStaticDataContainer.GetAssetPath(sceneType);
        }

        private void UnLoadCurrentScene()
        {
            if (_currentSceneName != string.Empty)
            {
                SceneManager.UnloadSceneAsync(_currentSceneName);
            }
        }
    }
}