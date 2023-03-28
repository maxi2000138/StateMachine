using HUD.Curtain;
using Infrastructure.States.Interfaces;
using Services;
using Services.GameFactory;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly SceneLoader _sceneLoader;
        private readonly ServiceLocator _serviceLocator;
        private readonly LoadingCurtain _curtain;
        private readonly StateMachine _stateMachine;

        public BootstrapState(StateMachine stateMachine, SceneLoader sceneLoader, ServiceLocator serviceLocator, LoadingCurtain curtain)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _serviceLocator = serviceLocator;
            _curtain = curtain;
        }

        public void Enter()
        {
            _curtain.Show();
            _sceneLoader.Load("BootstrapScene", OnLoadLevel);
        }

        public void Exit()
        {
        }

        public void OnLoadLevel()
        {
            RegisterServices();
            _stateMachine.Enter<LoadLevelState, string>("GameScene");
        }

        private void RegisterServices()
        {
            _serviceLocator.RegisterService<IGameFactory>(new GameFactory());
        }
    }
}