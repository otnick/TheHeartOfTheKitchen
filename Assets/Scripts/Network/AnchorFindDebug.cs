using UnityEngine;

public class AnchorFinderDebug : MonoBehaviour
{
    void Start()
    {
        var anchors = FindObjectsByType<OVRSpatialAnchor>(FindObjectsSortMode.None);

        foreach (var anchor in anchors)
        {
            Debug.Log("Found OVRSpatialAnchor: " + anchor.gameObject.name);
        }
    }
}