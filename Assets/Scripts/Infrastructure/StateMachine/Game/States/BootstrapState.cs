using Infrastructure.Services;
using Infrastructure.Services.Factories.Game;
using Infrastructure.Services.StaticData;
using UnityEngine.SceneManagement;

namespace Infrastructure.StateMachine.Game.States
{
    public class BootstrapState : IState, IGameState
    {
        private readonly IStateMachine<IGameState> _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly GameStaticData _gameStaticData;
        private string _firstSceneName;

        public BootstrapState(IStateMachine<IGameState> stateMachine, ISceneLoader sceneLoader, IStaticDataService staticDataService)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameStaticData = staticDataService.GameConfig();
        }

        public void Enter()
        {
            _firstSceneName = FirstSceneName();
            _sceneLoader.Load(_gameStaticData.InitialScene, OnLevelLoad);
        }

        public void Exit()
        {

        }

        private void OnLevelLoad() => 
            _stateMachine.Enter<LoadProgressState, string>(_firstSceneName);

        private string FirstSceneName()
        {
            string name = _gameStaticData.FirstScene;
            
#if UNITY_EDITOR
            if (_gameStaticData.CanLoadCurrentOpenedScene)
                name = SceneManager.GetActiveScene().name;        
#endif
                return name;
        }
    }
}