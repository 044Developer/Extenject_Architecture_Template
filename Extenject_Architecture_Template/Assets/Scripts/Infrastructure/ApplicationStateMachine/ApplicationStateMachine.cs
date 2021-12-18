using System;
using System.Collections.Generic;
using Infrastructure.ApplicationStateMachine.States;
using Infrastructure.Services.SceneLoader;
using StaticData.SceneStaticData.MainApplicationScenes;
using UI.Controller;
using Zenject;

namespace Infrastructure.ApplicationStateMachine
{
    public class ApplicationStateMachine : IApplicationStateMachine, IInitializable, IDisposable
    {
        private Dictionary<Type, IApplicationState> _applicationStates = null;
        private IApplicationState _currentState = null;

        public ApplicationStateMachine(UIController uiController, ISceneLoaderService<string> sceneLoaderService,
            SceneStaticDataContainer sceneStaticDataContainer)
        {
            _applicationStates = new Dictionary<Type, IApplicationState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, uiController),
                [typeof(LoadingState)] = new LoadingState(this, uiController, sceneStaticDataContainer, sceneLoaderService),
                [typeof(MainMenuState)] = new MainMenuState(this, uiController),
            };
        }

        public void Initialize()
        {
            foreach (IApplicationState state in _applicationStates.Values) 
                state.Initialize();
            
            Enter<BootstrapState>();
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState newState = ChangeState<TState>();
            newState.Enter();
        }

        public void Enter<TState>(string tpayload, LoadingToStateType vPayLoad)
            where TState : class, IPayLoadedState<string, LoadingToStateType>
        {
            TState state = ChangeState<TState>();
            state.Enter(tpayload, vPayLoad);
        }

        private TState ChangeState<TState>() where TState : class, IApplicationState
        {
            _currentState?.Exit();
            TState newState = GetState<TState>();
            _currentState = newState;
            return newState;
        }

        private TState GetState<TState>() where TState : class, IApplicationState
        {
            return _applicationStates[typeof(TState)] as TState;
        }

        public void Dispose()
        {
            foreach (IApplicationState state in _applicationStates.Values) 
                state.Dispose();
        }
    }
}