using UnityEngine;
using Fusion;

public class KnifeCut : MonoBehaviour
{
    [Header("Ingredient")]
    public int ingredientId;
    [Header("Original")]
    public GameObject currentObject;
    [Header("Cut Prefab")]
    public NetworkPrefabRef cutPrefab;
    public Transform spawnPoint;
    [Header("Spawn Settings")]
    public int spawnCount = 3;
    public float spawnSpacing = 0.05f;
    [Header("Food Colors")]
    public Color freshColor = Color.white;
    public Color brownColor = new Color(0.35f, 0.16f, 0.04f);
    public Color blackColor = Color.black;
    private bool cutDone = false;

    [Header("Cut Effect")]
    public GameObject cutParticlePrefab;

    [Header("Cut Sound")]
    public AudioClip cutSound;
    [Range(0f, 1f)]
    public float cutSoundVolume = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (cutDone) return;
        if (other.CompareTag("Knife"))
        {
            var playerNetwork = FindFirstObjectByType<PlayerNetwork>();
            if (playerNetwork != null)
            {
                Vector3 pos = spawnPoint != null ? spawnPoint.position : transform.position;
                Quaternion rot = spawnPoint != null ? spawnPoint.rotation : transform.rotation;
                playerNetwork.RPC_CutIngredient(
                    ingredientId,
                    pos,
                    rot,
                    spawnCount,
                    spawnSpacing,
                    freshColor,
                    brownColor,
                    blackColor
                );
            }
        }
    }

    public void ApplyCutLocal()
    {
        if (cutDone) return;
        cutDone = true;

        Vector3 pos = spawnPoint != null ? spawnPoint.position : transform.position;
        Quaternion rot = spawnPoint != null ? spawnPoint.rotation : transform.rotation;

        if (cutParticlePrefab != null)
        {
            GameObject particles = Instantiate(cutParticlePrefab, pos, rot);
            Destroy(particles, 3f);
        }

        if (cutSound != null)
            AudioSource.PlayClipAtPoint(cutSound, pos, cutSoundVolume);

        if (currentObject != null)
            currentObject.SetActive(false);

        Debug.Log("Ingredient hidden after cut: " + ingredientId);
    }
}