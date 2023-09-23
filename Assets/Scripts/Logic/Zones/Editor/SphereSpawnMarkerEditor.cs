using System;
using UnityEditor;
using UnityEngine;

namespace Logic.Zones.Editor
{
    [CustomEditor(typeof(SphereSpawnMarker))]
    public class SphereSpawnMarkerEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.NotInSelectionHierarchy | GizmoType.Selected)]
        private static void GizmoTest(SphereSpawnMarker marker, GizmoType aGizmoType)
        {
            if (marker == null) 
                return;
            
            Gizmos.color = marker.Type switch
            {
                ZoneTypeState.PlayerSpawn => Color.gray,
                ZoneTypeState.EnemySpawn => Color.gray,
                ZoneTypeState.Neutral => Color.gray,
                _ => throw new ArgumentOutOfRangeException()
            };
            
            Gizmos.DrawCube(marker.transform.position, Vector3.one);
        }
    }
}