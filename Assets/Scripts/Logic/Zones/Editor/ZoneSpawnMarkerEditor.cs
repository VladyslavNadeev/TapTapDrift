using System;
using UnityEditor;
using UnityEngine;

namespace Logic.Zones.Editor
{
    [CustomEditor(typeof(ZoneSpawnMarker))]
    public class ZoneSpawnMarkerEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.NotInSelectionHierarchy | GizmoType.Selected)]
        private static void GizmoTest(ZoneSpawnMarker marker, GizmoType aGizmoType)
        {
            if (marker == null) 
                return;
            
            Gizmos.color = marker.Type switch
            {
                    ZoneTypeState.PlayerSpawn => Color.blue,
                    ZoneTypeState.EnemySpawn => Color.magenta,
                    ZoneTypeState.Neutral => Color.black,
                    _ => throw new ArgumentOutOfRangeException()
            };
            
            Gizmos.DrawCube(marker.transform.position, Vector3.one);
        }
    }
}

namespace Logic.Zones.Editor
{
}