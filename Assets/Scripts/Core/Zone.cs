using UnityEngine;

public class Zone : MonoBehaviour
{
    [SerializeField] private ZoneType zoneType;

    public ZoneType ZoneType => zoneType;
}