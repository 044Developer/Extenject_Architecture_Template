using System;
using System.Collections.Generic;
using Infrastructure.ApplicationStateMachine.States;
using Zenject;

namespace Infrastructure.ApplicationStateMachine
{
    public class ApplicationStateMachine : IApplicationStateMachine, IInitializable, IDisposable
    {
        private Dictionary<Type, IApplicationState> _applicationStates = null;
        private IApplicationState _currentState = null;

        public ApplicationStateMachine(BootstrapState bootstrapState, MainMenuState mainMenuState)
        {
            _applicationStates = new Dictionary<Type, IApplicationState>()
            {
                [typeof(BootstrapState)] = bootstrapState,
                [typeof(MainMenuState)] = mainMenuState,
            };
        }

        public void Initialize()
        {
            foreach (IApplicationState state in _applicationStates.Values) 
                state.Initialize();
        }

        public void Enter<TState>() where TState : class, IApplicationState
        {
            IApplicationState newState = ChangeState<TState>();
            newState.Enter();
        }

        private TState ChangeState<TState>() where TState : class, IApplicationState
        {
            _currentState?.Exit();
            TState newState = GetState<TState>();
            _currentState = newState;
            return newState;
        }

        private TState GetState<TState>() where TState : class
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