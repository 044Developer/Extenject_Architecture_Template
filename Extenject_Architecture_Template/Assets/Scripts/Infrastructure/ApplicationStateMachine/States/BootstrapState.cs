using UI.Controller;

namespace Infrastructure.ApplicationStateMachine.States
{
    public class BootstrapState : IApplicationState
    {
        private readonly ApplicationStateMachine _applicationStateMachine = null;
        private readonly UIController _uiController = null;

        public BootstrapState(ApplicationStateMachine applicationStateMachine, UIController uiController)
        {
            _applicationStateMachine = applicationStateMachine;
            _uiController = uiController;
        }
        
        public void Initialize()
        {
        }

        public void Enter()
        {
            BootstrapUI();
        }

        public void Exit()
        {
            
        }

        public void Dispose()
        {
        }

        private void BootstrapUI()
        {
            _uiController
                .BootstrapUI((() =>
            {
                _applicationStateMachine.Enter<MainMenuState>();
            }));
        }
    }
}