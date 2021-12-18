using Infrastructure.Services.SceneLoader;
using StaticData.SceneStaticData.MainApplicationScenes;
using StaticData.UIStaticData.WindowsData;
using UI.Controller;
using UI.Windows.LoadingScreenWindow;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.ApplicationStateMachine.States
{
    public class MainMenuState : IState
    {
        private readonly ApplicationStateMachine _applicationStateMachine = null;
        private readonly UIController _uiController = null;
        public MainMenuState(ApplicationStateMachine applicationStateMachine, UIController uiController)
        {
            _applicationStateMachine = applicationStateMachine;
            _uiController = uiController;
        }
        
        public void Initialize()
        {
        }

        public void Enter()
        {
        }

        public void Exit()
        {
        }

        public void Dispose()
        {
        }
    }
}