using Logic;
using StaticData;
using UnityEngine;

public class BuyZoneSpawnMarker : MonoBehaviour
{
    [SerializeField] private BuyZoneTypeState _typeState;
    [SerializeField] private ZoneTypeState _connectedZoneTypeState;

    public BuyZoneTypeState TypeState => _typeState;
    public ZoneTypeState ConnectedZoneTypeState => _connectedZoneTypeState;
}