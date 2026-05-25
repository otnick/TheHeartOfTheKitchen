using Fusion;
using Meta.XR.MRUtilityKit.SceneDecorator;
using System.Collections;
using UnityEngine;
using static Unity.Collections.Unicode;

public class MeatGrinder : MonoBehaviour
{
    [Header("Food Item Prefab")]
    [SerializeField]
    GameObject foodPrefab;
    [Header("Spawn Smoke Prefab")]
    [SerializeField]
    GameObject spawnSmokeEffect;
    bool spawnedFood = false;
    [SerializeField]
    AudioSource foodAudioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is 

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnMeatGround()
    {
        if (spawnedFood) return;
        var runner = FindFirstObjectByType<NetworkRunner>();
        if (runner == null)
        {
            Debug.Log("NoRunner");
            return;
        }
        spawnedFood=true;
        foodAudioSource.Play();
        Debug.Log("Playing spawning sound");
        IEnumerator coroutine = SpawnFood(runner);
        StartCoroutine(coroutine);

    }
    IEnumerator SpawnFood(NetworkRunner runner)
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("we did that spawning thing, remember?");
        NetworkObject meat = runner.Spawn(foodPrefab, transform.position, transform.rotation);
        meat.GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);
        foodAudioSource.Stop();
        Instantiate(spawnSmokeEffect, transform.position, transform.rotation);
    }
}
