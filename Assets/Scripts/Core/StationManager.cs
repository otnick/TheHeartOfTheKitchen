using UnityEngine;

public class StationManager : MonoBehaviour
{
    public static StationManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
}