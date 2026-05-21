using UnityEngine;

public class Station : MonoBehaviour
{
    [SerializeField] private StationType stationType;
    [SerializeField] private ZoneType zoneType;

    public StationType StationType => stationType;
    public ZoneType ZoneType => zoneType;

    private void OnEnable()
    {
        FindFirstObjectByType<StationManager>()?.Register(this);
    }

    private void OnDisable()
    {
        FindFirstObjectByType<StationManager>()?.Unregister(this);
    }
}