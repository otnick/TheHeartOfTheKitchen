using Fusion;
using Meta.XR.MRUtilityKit.SceneDecorator;
using UnityEngine;

public class MeatGrinder : MonoBehaviour
{
    [Header("Food Item Prefab")]
    [SerializeField]
    GameObject foodPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is 

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnMeatGround()
    {
        var runner = FindFirstObjectByType<NetworkRunner>();
        if (runner == null) return;
        runner.Spawn(foodPrefab, transform.position, transform.rotation);
    }
}
