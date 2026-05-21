using System.Collections.Generic;
using UnityEngine;

public class StationManager : MonoBehaviour
{
    private readonly List<Station> stations = new();

    public IReadOnlyList<Station> Stations => stations;

    public void Register(Station station)
    {
        if (station == null || stations.Contains(station)) return;

        stations.Add(station);
        Debug.Log($"Registered station: {station.name}");
    }

    public void Unregister(Station station)
    {
        if (station == null) return;

        stations.Remove(station);
        Debug.Log($"Unregistered station: {station.name}");
    }
}