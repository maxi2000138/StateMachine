using HUD.Curtain;
using Infrastructure.States;
using Services;

namespace Infrastructure
{
    public class Game
    {
        public readonly StateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain)
        {
            StateMachine = new StateMachine(ServiceLocator.Container, new SceneLoader(coroutineRunner), loadingCurtain);
        }
    }
}