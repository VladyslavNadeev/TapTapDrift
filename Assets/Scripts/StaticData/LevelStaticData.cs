using System;
using System.Collections.Generic;
using Logic;
using UnityEngine;
using UnityEngine.Serialization;

namespace StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Level", fileName = "LevelStaticData", order = 0)]
    public class LevelStaticData : ScriptableObject
    {
        public string SceneName;
        public List<ZoneSpawnConfig> ZoneSpawnConfigs = new();
        public List<BuyZoneSpawnConfig> BuyZoneSpawnConfigs = new();
        public List<SphereSpawnConfig> SphereSpawnConfigs = new();
    }

    [Serializable]
    public class ZoneSpawnConfig
    {
        public ZoneTypeState ZoneType;
        public Vector3 Position;
    }

    [Serializable]
    public class BuyZoneSpawnConfig
    {
        public BuyZoneTypeState BuyZoneTypeState;
        public ZoneTypeState ConnectedZoneTypeState;
        public Vector3 Position;
    }

    [Serializable]
    public class SphereSpawnConfig
    {
        public ZoneTypeState MarkerType;
        public Vector3 Position;
        public Vector3 Range;

    }
}