using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Services.Factories.Game
{
    public interface IGameFactory
    {
        GameObject MainPlayerCar { get; }
        GameObject CreateMainPlayerCar(Vector3 position, Quaternion rotation);

        GameObject CreateGameHud();
        GameObject CreateStartupHud();
        GameObject CreateWinWindow();
        GameObject CreateLooseWindow();
    }
}