using UnityEngine;

namespace Logic
{
    public class ZoneSpawnMarker: MonoBehaviour
    {
        [SerializeField] private ZoneTypeState _type;
        
        public ZoneTypeState Type => _type;
    }
}