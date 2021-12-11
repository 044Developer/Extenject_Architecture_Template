namespace Infrastructure.ApplicationStateMachine.States
{
    public interface IApplicationState
    {
        void Initialize();
        void Enter();
        void Exit();
        void Dispose();
    }
}