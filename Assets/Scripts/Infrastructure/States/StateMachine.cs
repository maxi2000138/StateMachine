using System;
using System.Collections.Generic;
using Infrastructure.States.Interfaces;
using Services;

namespace Infrastructure.States
{
    public class StateMachine
    {
        private readonly ServiceLocator _serviceLocator;
        private IExitableState _currentState;
        private readonly Dictionary<Type, IExitableState> _states;

        public StateMachine(ServiceLocator serviceLocator, SceneLoader sceneLoader)
        {
            _serviceLocator = serviceLocator;
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, serviceLocator),
                [typeof(LoadLevelState)] = new LoadLevelState(sceneLoader, this),
                [typeof(GameLoopState)] = new GameLoopState()
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            _currentState?.Exit();
            var state = GetState<TState>();
            state.Enter();
            _currentState = state;
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IOVerloadedState<TPayload>
        {
            _currentState?.Exit();
            var state = GetState<TState>();
            state.Enter(payload);
            _currentState = state;
        }

        private TState GetState<TState>() where TState : class, IExitableState
        {
            return _states[typeof(TState)] as TState;
        }
    }
}