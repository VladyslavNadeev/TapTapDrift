using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Infrastructure.Services.Factories.Game
{
    public class GameFactory : Factory, IGameFactory
    {
        private const string StartupHudPath = "Hud/StartupHud";
        private const string GameHudPath = "Hud/GameHud";
        private const string WinWindowPath = "Hud/WinWindow";
        private const string LooseWindowPath = "Hud/LooseWindow";
        
        private const string MainPlayerCarPath = "MainCar/MainCar";
        
        private GameObject _gameHud;

        public GameFactory(IInstantiator instantiator) : base(instantiator) { }

        public GameObject MainPlayerCar { get; private set; }

        public GameObject CreateGameHud()
        {
            _gameHud = InstantiateOnActiveScene(GameHudPath);
            return _gameHud;
        }

        public GameObject CreateStartupHud()
        {
            GameObject startupHud = InstantiateOnActiveScene(StartupHudPath);
            startupHud.GetComponentInChildren<UITapToStartButton>().Init();
            return startupHud;
        }

        public GameObject CreateWinWindow()
        {
            GameObject winWindow = InstantiateOnActiveScene(WinWindowPath);
            return winWindow;
        }

        public GameObject CreateLooseWindow()
        {
            GameObject looseWindow = InstantiateOnActiveScene(LooseWindowPath);
            return looseWindow;
        }

        public GameObject CreateMainPlayerCar(Vector3 position, Quaternion rotation)
        {
            GameObject mainPlayerCar = InstantiateOnActiveScene(MainPlayerCarPath, position, rotation, null);
            
            MainPlayerCar = mainPlayerCar;
            return mainPlayerCar;
        }
    }
}