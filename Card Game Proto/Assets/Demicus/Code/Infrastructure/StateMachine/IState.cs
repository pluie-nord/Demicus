namespace Demicus.Code.Infrastructure.StateMachine
{
    public interface IState : IExitableState
    {
        void Enter();
    }

    public interface IPayloadedState<TPayload> : IExitableState
    {
        void Enter(TPayload levelID);
    }

    public interface IExitableState
    {
        void Exit();
    }

    public interface IInitializableState : IState
    {
        void SetupStateMachine(IGameStateMachine gameStateMachine);
    }
}
