using UnityEngine;
using Fusion;

public class MeatGrinder : MonoBehaviour
{
    private NetworkRunner Runner;
    [SerializeField]
    GameObject foodToSpawn;
    [SerializeField]
    GameObject grinder;
    
    bool spawned = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var runner = FindFirstObjectByType<NetworkRunner>();
        if (Runner != null) Debug.Log("no runner?");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnFood()
    {
        if (spawned) return;
        NetworkObject item = Runner.Spawn(foodToSpawn, grinder.transform.position, grinder.transform.rotation);
        item.GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);
        //GameObject tem = Instantiate(foodToSpawn, grinder.transform.position, grinder.transform.rotation);
        //tem.GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);
        spawned = true;
    }
}
