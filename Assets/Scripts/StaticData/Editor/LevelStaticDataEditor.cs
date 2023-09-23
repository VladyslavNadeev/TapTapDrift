using System;
using System.Linq;
using Logic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StaticData.Editor
{
    [CustomEditor(typeof(LevelStaticData))]
    public class LevelStaticDataEditor : UnityEditor.Editor
    {
        private LevelStaticData _levelData;

        private void OnEnable()
        {
            _levelData = (LevelStaticData)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            if (GUILayout.Button("Refresh"))
            {
                RefreshData(_levelData);
                EditorUtility.SetDirty(_levelData);
            }
        }

        private void RefreshData(LevelStaticData levelStaticData)
        {
            levelStaticData.SceneName = SceneManager.GetActiveScene().name;

            levelStaticData.ZoneSpawnConfigs = GameObject.FindObjectsOfType<ZoneSpawnMarker>()
                .Select(x => new ZoneSpawnConfig
                {
                    Position = x.transform.position,
                    ZoneType = x.Type
                })
                .ToList();

            levelStaticData.BuyZoneSpawnConfigs = GameObject.FindObjectsOfType<BuyZoneSpawnMarker>()
                .Select(x => new BuyZoneSpawnConfig
                {
                    Position = x.transform.position,
                    BuyZoneTypeState = x.TypeState,
                    ConnectedZoneTypeState = x.ConnectedZoneTypeState
                })
                .ToList();

            levelStaticData.SphereSpawnConfigs = GameObject.FindObjectsOfType<SphereSpawnMarker>()
                .Select(x => new SphereSpawnConfig
                {
                    Position = x.transform.position,
                    MarkerType = x.Type
                })
                .ToList();
        }
    }
}