using System.Collections.Generic;
using RunManGun.Window;
using StaticData;

namespace Infrastructure.Services.StaticData
{
    public interface IStaticDataService
    {
        void LoadData();
        GameStaticData GameConfig();
        WindowConfig ForWindow(WindowTypeId windowTypeId);
        LevelStaticData GetLevelDataFor(string scene);
    }
}