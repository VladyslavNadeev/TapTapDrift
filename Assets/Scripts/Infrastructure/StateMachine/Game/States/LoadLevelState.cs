using System.Linq;
using Cinemachine;
using Infrastructure.Services.Factories.UIFactory;
using UnityEngine;
using Infrastructure.Services.Factories.Game;
using StaticData;
using Object = UnityEngine.Object;

namespace Infrastructure.StateMachine.Game.States
{
    public class LoadLevelState : IPayloadedState<string>, IGameState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly IUIFactory _uiFactory;
        private readonly IGameFactory _gameFactory;
        private GameObject _startupHud;
        private LevelStaticData _levelData;
        private CarMovement _carMovement;
        private GameObject _gameHud;
        private GameObject _looseWindow;
        private GameObject _winWindow;

        public LoadLevelState(ISceneLoader sceneLoader, 
            ILoadingCurtain loadingCurtain, 
            IUIFactory uiFactory,
            IGameFactory gameFactory)
        {
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _uiFactory = uiFactory;
            _gameFactory = gameFactory;
        }
        
        public void Enter(string payload)
        {
            _loadingCurtain.Show();
            _sceneLoader.Load(payload, OnLevelLoad);
        }

        public void Exit()
        {
            Object.Destroy(_startupHud);
            _gameHud.SetActive(true);
            _carMovement.StartMoving();
        }

        protected virtual void OnLevelLoad()
        {
            InitGameWorld();
        }

        private void InitGameWorld()
        {
           _uiFactory.CreateUiRoot();
           
           _gameHud = InitGameHud();
           InitializeGameHud(_gameHud);
            
           UIStartDriftButton uiStartDriftButton = InitStartDriftButton(_gameHud);

           GameObject mainCar = InitMainCar();
           InitCameraForMainCar(mainCar);
           _carMovement = mainCar.GetComponent<CarMovement>();
           
           Object.FindObjectsOfType<CarDriftCircle>().ToList().ForEach(x => x.Init(
               mainCar.GetComponent<CarMovement>(),
               uiStartDriftButton));

           Init();
           _gameHud.SetActive(false);
           _startupHud = _gameFactory.CreateStartupHud();
           _looseWindow = _gameFactory.CreateLooseWindow();
           _looseWindow.SetActive(false);
           _winWindow = _gameFactory.CreateWinWindow();
           _winWindow.SetActive(false);
           _loadingCurtain.Hide();
        }
        
        private UIStartDriftButton InitStartDriftButton(GameObject gameHud)
        {
            UIStartDriftButton uiStartDriftButton = gameHud.GetComponentInChildren<UIStartDriftButton>();
            return uiStartDriftButton;
        }

        private void InitializeGameHud(GameObject gameHud)
        {
            
        }

        private GameObject InitGameHud()
        {
            GameObject gameHud = _gameFactory.CreateGameHud();
            return gameHud;
        }

        private void InitCameraForMainCar(GameObject mainCar)
        {
            var virtualCamera = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
            virtualCamera.m_Follow = mainCar.transform;
            virtualCamera.m_LookAt = mainCar.transform;
        }

        private GameObject InitMainCar()
        {
            Vector3 spawnPosition = GameObject.FindWithTag("CarSpawnPoint").transform.position;

            GameObject mainCar = _gameFactory.CreateMainPlayerCar(spawnPosition, Quaternion.identity);

            mainCar.GetComponent<CarMovement>().Init();

            return mainCar;
        }

        private void Init()
        {
            Object.FindObjectsOfType<LoseObstacle>().ToList().ForEach(x => x.Init(_gameHud, _looseWindow));
            Object.FindObjectsOfType<WinPoint>().ToList().ForEach(x => x.Init(_gameHud, _winWindow));
        }
    }
}