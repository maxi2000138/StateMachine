namespace Infrastructure.States.Interfaces
{
    public interface IOVerloadedState<TPayload> : IExitableState
    {
        void Enter(TPayload payload);
    }
}