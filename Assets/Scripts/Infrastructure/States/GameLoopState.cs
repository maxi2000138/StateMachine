using HUD.Curtain;
using Infrastructure.States.Interfaces;

namespace Infrastructure.States
{
    public class GameLoopState : IState
    {
        private readonly LoadingCurtain _curtain;

        public GameLoopState(LoadingCurtain curtain)
        {
            _curtain = curtain;
        }
        
        public void Enter()
        {
                _curtain.Hide();
        }

        public void Exit()
        {
        }
    }
}