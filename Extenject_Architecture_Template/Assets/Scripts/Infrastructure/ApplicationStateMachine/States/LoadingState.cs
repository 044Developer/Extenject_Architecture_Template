

using System;
using System.ComponentModel;
using Infrastructure.Services.SceneLoader;
using StaticData.SceneStaticData.MainApplicationScenes;
using UI.Controller;
using UI.Windows.LoadingScreenWindow;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.ApplicationStateMachine.States
{
    public enum LoadingToStateType { None, MainMenu, Level, }
    public class LoadingState : IPayLoadedState<string, LoadingToStateType>
    {
        private readonly ApplicationStateMachine _applicationStateMachine =  null;
        private readonly UIController _uiController = null;
        private readonly SceneStaticDataContainer _sceneStaticDataContainer = null;
        private readonly ISceneLoaderService<string> _sceneLoaderService = null;
        private Action _onFinishAction = null;

        public LoadingState(ApplicationStateMachine applicationStateMachine, UIController uiController, SceneStaticDataContainer sceneStaticDataContainer, ISceneLoaderService<string> sceneLoaderService)
        {
            _applicationStateMachine = applicationStateMachine;
            _uiController = uiController;
            _sceneStaticDataContainer = sceneStaticDataContainer;
            _sceneLoaderService = sceneLoaderService;
        }

        public void Initialize()
        {
        }
        
        public void Enter(string sceneName, LoadingToStateType nextStateType)
        {
            Debug.Log("Entered");
            _uiController.OnStartLoadingWindow();
            LoadScene(sceneName);
            SwitchNextState(nextStateType);
        }

        public void Exit()
        {
        }

        public void Dispose()
        {
        }

        private void LoadScene(string scenePath)
        {
            UnityEngine.AsyncOperation loadTask = _sceneLoaderService.LoadSceneAsync(scenePath, LoadSceneMode.Additive);

            loadTask.completed += OnSceneLoaded;
        }

        private void OnSceneLoaded(UnityEngine.AsyncOperation operation)
        {
            Debug.Log("Loaded");
            _uiController.OnFinalizeLoadingWindow();
            _uiController.OnShowMainPanel();
            _onFinishAction?.Invoke();
        }

        private void SwitchNextState(LoadingToStateType loadingToStateType)
        {
            switch (loadingToStateType)
            {
                case LoadingToStateType.None:
                    break;
                case LoadingToStateType.MainMenu:
                    _onFinishAction += () =>  _applicationStateMachine.Enter<MainMenuState>();
                    break;
                case LoadingToStateType.Level:
                    _onFinishAction += () => _applicationStateMachine.Enter<LevelState>();
                    break;
            }
        }
    }
}