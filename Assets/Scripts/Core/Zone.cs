using UnityEngine;

public enum ZoneType
{
    Kitchen,
    Front,
    ServicePass
}

public class Zone : MonoBehaviour
{
    [SerializeField] private ZoneType zoneType;

    public ZoneType ZoneType => zoneType;
}