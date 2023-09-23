using UnityEngine;

namespace Infrastructure.StateMachine.Game.States
{
    public class GameLoopState : IState, IGameState, IUpdatable
    {
        private GameObject _gameHud;
        private GameObject _winWindow;
        private GameObject _looseWindow;
        private GameObject _respawnWindow;

        public GameLoopState()
        {
        }

        public void Enter()
        {
            
        }

        public void Update()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}