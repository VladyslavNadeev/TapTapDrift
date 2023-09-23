using System.Collections.Generic;
using System.Linq;
using RunManGun.Window;
using StaticData;
using UnityEngine;

namespace Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string GameConfigPath = "StaticData/GameConfig";
        private const string WindowsStaticDataPath = "StaticData/WindowsStaticData";
        private const string LevelStaticDataPath = "StaticData/Levels";

        private GameStaticData _gameStaticData;
        private Dictionary<WindowTypeId, WindowConfig> _windowConfigs;
        private Dictionary<string, LevelStaticData> _levelDatas;
        
        public void LoadData()
        {
            _gameStaticData = Resources
                .Load<GameStaticData>(GameConfigPath);

            _windowConfigs = Resources
                .Load<WindowStaticData>(WindowsStaticDataPath)
                .Configs.ToDictionary(x => x.WindowTypeId, x => x);

            _levelDatas = Resources
                .LoadAll<LevelStaticData>(LevelStaticDataPath)
                .ToDictionary(x => x.SceneName, x => x);
        }
        
        public GameStaticData GameConfig() =>
            _gameStaticData;

        public WindowConfig ForWindow(WindowTypeId windowTypeId) => 
            _windowConfigs[windowTypeId];

        public LevelStaticData GetLevelDataFor(string scene) =>
            _levelDatas[scene];
    }
}