using Infrastructure.States;
using Services;

namespace Infrastructure
{
    public class Game
    {
        public readonly StateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner)
        {
            StateMachine = new StateMachine(ServiceLocator.Container, new SceneLoader(coroutineRunner));
        }
    }
}