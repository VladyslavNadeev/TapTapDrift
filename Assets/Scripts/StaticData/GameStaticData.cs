using UnityEngine;

namespace Infrastructure.Services
{
    [CreateAssetMenu(menuName = "StaticData/Game", fileName = "GameConfig", order = 0)]
    public class GameStaticData : ScriptableObject
    {
        public string InitialScene = "Initial";
        public string FirstScene = "First";
        public bool CanLoadCurrentOpenedScene = false;
    }
}