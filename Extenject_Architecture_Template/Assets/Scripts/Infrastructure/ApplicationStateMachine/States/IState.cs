namespace Infrastructure.ApplicationStateMachine.States
{
    public interface IState : IApplicationState
    {
        void Enter();
    }

    public interface IPayLoadedState<TPayLoad, VPayLoad> : IApplicationState
    {
        void Enter(TPayLoad payLoad, LoadingToStateType vPayLoad);
    }

    public interface IApplicationState
    {
        void Initialize();
        void Exit();
        void Dispose();
    }
}