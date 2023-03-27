public interface IOVerloadedState<TPayload> : IExitableState
{ 
    void Enter(TPayload payload);
}