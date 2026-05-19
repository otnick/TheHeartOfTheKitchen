using UnityEngine;
using System.Collections;
using Meta.XR.BuildingBlocks;

public class InitializeAnchor : MonoBehaviour
{
    public GameObject spatialAnchorPrefab;

    void Start()
    {
        
        
    }
    public void InitAnchors()
    {
        this.GetComponent<SharedSpatialAnchorCore>().InstantiateSpatialAnchor(spatialAnchorPrefab, transform.position, transform.rotation);
    }
}