using System.Collections.Generic;
using System;
using CodeBase.Infrastructure;

public class StateMachine
{
    private readonly ServiceLocator _serviceLocator;
    private Dictionary<Type, IExitableState> _states;
    private IExitableState _currentState;
    
    public StateMachine(ServiceLocator serviceLocator, SceneLoader sceneLoader)
    {
        _serviceLocator = serviceLocator;
        _states = new Dictionary<Type, IExitableState>()
        {
            [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, serviceLocator),   
            [typeof(LoadLevelState)] = new LoadLevelState(sceneLoader, this),
            [typeof(GameLoopState)] = new GameLoopState(),
        };
    }   

    public void Enter<TState>() where TState : class,IState
    {
        _currentState?.Exit();
        TState state = GetState<TState>();
        state.Enter();
        _currentState = state;
    }

    public void Enter<TState, TPayload>(TPayload payload) where TState : class,IOVerloadedState<TPayload>
    {
        _currentState?.Exit();
        TState state = GetState<TState>();
        state.Enter(payload);
        _currentState = state;
    }

    private TState GetState<TState>() where TState : class,IExitableState => 
        _states[typeof(TState)] as TState;
}