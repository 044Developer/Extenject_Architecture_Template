using Infrastructure.Services.SceneLoader;
using UI.Controller;

namespace Infrastructure.ApplicationStateMachine.States
{
    public class BootstrapState : IApplicationState
    {
        private readonly UIController _uiController;

        public BootstrapState(UIController uiController)
        {
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