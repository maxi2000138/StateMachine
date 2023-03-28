using Infrastructure.States.Interfaces;
using Services;

namespace Infrastructure.States
{
    public class LoadLevelState : IOVerloadedState<string>
    {
        private readonly SceneLoader _sceneLoader;
        private readonly StateMachine _stateMachine;

        public LoadLevelState(SceneLoader sceneLoader, StateMachine stateMachine)
        {
            _sceneLoader = sceneLoader;
            _stateMachine = stateMachine;
        }

        public void Enter(string payload)
        {
            _sceneLoader.Load(payload, ChangeState);
        }

        public void Exit()
        {
        }

        public void ChangeState()
        {
            _stateMachine.Enter<GameLoopState>();
        }
    }
}