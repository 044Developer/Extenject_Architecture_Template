using Infrastructure.ApplicationStateMachine.States;

namespace Infrastructure.ApplicationStateMachine
{
    public interface IApplicationStateMachine
    {
        void Enter<TState>() where TState : class, IApplicationState;
    }
}