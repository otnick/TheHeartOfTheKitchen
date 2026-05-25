using Fusion;
using Meta.XR.MRUtilityKit.SceneDecorator;
using UnityEngine;

public class MeatGrinder : MonoBehaviour
{
    [Header("Food Item Prefab")]
    [SerializeField]
    GameObject foodPrefab;
    bool spawnedFood = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is 

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnMeatGround()
    {
        if (spawnedFood) return;
        var runner = FindFirstObjectByType<NetworkRunner>();
        if (runner == null) return;
        NetworkObject meat = runner.Spawn(foodPrefab, transform.position, transform.rotation);
        meat.GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);
        spawnedFood=true;
    }
}
