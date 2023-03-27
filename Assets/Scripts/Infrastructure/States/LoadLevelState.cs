using CodeBase.Infrastructure;

public class LoadLevelState : IOVerloadedState<string>
{
    private readonly SceneLoader _sceneLoader;
    private readonly StateMachine _stateMachine;

    public LoadLevelState(SceneLoader sceneLoader, StateMachine stateMachine)
    {
        _sceneLoader = sceneLoader;
        _stateMachine = stateMachine;
    }
    public void Enter(string payload) => 
        _sceneLoader.Load(payload, ChangeState);

    public void ChangeState() => 
        _stateMachine.Enter<GameLoopState>();

    public void Exit()
    {
        
    }
}