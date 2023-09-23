using System;
using StaticData;
using UnityEditor;
using UnityEngine;

namespace Logic.Zones.Editor
{
    [CustomEditor(typeof(BuyZoneSpawnMarker))]
    public class BuyZoneSpawnMarkerEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.NotInSelectionHierarchy | GizmoType.Selected)]
        private static void GizmoTest(BuyZoneSpawnMarker marker, GizmoType aGizmoType)
        {
            if (marker == null) 
                return;
            
            Gizmos.color = marker.TypeState switch
            {
                BuyZoneTypeState.BuyZone => Color.green,
                BuyZoneTypeState.PortalBuyZone => Color.yellow,
                BuyZoneTypeState.BossBuyZone => Color.red,
                BuyZoneTypeState.ImitationBuyZone => Color.cyan,
                _ => throw new ArgumentOutOfRangeException()
            };
            
            Gizmos.DrawSphere(marker.transform.position, 0.1f);
        }
    }
}