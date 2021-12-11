using Infrastructure.Services.SceneLoader;
using StaticData.SceneStaticData.MainApplicationScenes;
using StaticData.UIStaticData.WindowsData;
using UI.Controller;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.ApplicationStateMachine.States
{
    public class MainMenuState : IApplicationState
    {
        private readonly ApplicationStateMachine _applicationStateMachine = null;
        private readonly UIController _uiController = null;
        private readonly ISceneLoaderService<string, SceneType> _sceneLoaderService = null;
        public MainMenuState(ApplicationStateMachine applicationStateMachine, UIController uiController, ISceneLoaderService<string, SceneType> sceneLoaderService)
        {
            _applicationStateMachine = applicationStateMachine;
            _uiController = uiController;
            _sceneLoaderService = sceneLoaderService;
        }
        
        public void Initialize()
        {
        }

        public void Enter()
        {
            _uiController.OnShowLoadingWindow(LoadMainScene);
        }

        public void Exit()
        {
        }

        public void Dispose()
        {
        }
        
        private void LoadMainScene()
        {
            AsyncOperation loadTask = _sceneLoaderService.LoadSceneAsync(SceneType.Main, LoadSceneMode.Additive);

            loadTask.completed += OnSceneLoaded;
        }

        private void OnSceneLoaded(AsyncOperation operation)
        {
            _uiController.OnCloseWindow(UIWindowType.LoadingWindow);
        }
    }
}