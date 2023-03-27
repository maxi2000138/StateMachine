using System;
using CodeBase.Infrastructure;

public class BootstrapState : IState
{
    private readonly StateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly ServiceLocator _serviceLocator;

    public BootstrapState(StateMachine stateMachine, SceneLoader sceneLoader, ServiceLocator serviceLocator)
    {
        _stateMachine = stateMachine;
        _sceneLoader = sceneLoader;
        _serviceLocator = serviceLocator;
    }

    public void Enter()
    {
        _sceneLoader.Load("BootstrapScene", OnLoadLevel);
    }

    public void OnLoadLevel()
    {
        RegisterServices();
        _stateMachine.Enter<LoadLevelState, String>("GameScene");
    }

    private void RegisterServices()
    {
        _serviceLocator.RegisterService<IGameFactory>(new GameFactory());
    }

    public void Exit()
    {
            
    }
}