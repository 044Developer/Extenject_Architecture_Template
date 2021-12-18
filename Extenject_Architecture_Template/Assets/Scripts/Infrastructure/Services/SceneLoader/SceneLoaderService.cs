using System;
using StaticData.SceneStaticData.MainApplicationScenes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Services.SceneLoader
{
    public class SceneLoaderService : ISceneLoaderService<string>
    {
        private readonly SceneStaticDataContainer _sceneStaticDataContainer;
        private string _currentSceneName = String.Empty;
        
        public SceneLoaderService(SceneStaticDataContainer sceneStaticDataContainer)
        {
            _sceneStaticDataContainer = sceneStaticDataContainer;
        }

        public AsyncOperation LoadSceneAsync(string scene, LoadSceneMode loadSceneMode)
        {
            string assetPath = GetPath(scene);
            AsyncOperation loadTask = SceneManager.LoadSceneAsync(assetPath, loadSceneMode);
            UnLoadCurrentScene();
            _currentSceneName = assetPath;

            return loadTask;
        }

        private string GetPath(string sceneType)
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