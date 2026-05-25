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

    [Header("Food Colors")]
    public Color freshColor = Color.white;
    public Color brownColor = new Color(0.35f, 0.16f, 0.04f);
    public Color blackColor = Color.black;

    private bool cutDone = false;

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
                    freshColor,
                    brownColor,
                    blackColor
                );
            }
            else
            {
                Debug.LogWarning("PlayerNetwork not found!");
            }
        }
    }

    public void ApplyCutLocal()
    {
        if (cutDone) return;

        cutDone = true;

        if (currentObject != null)
            currentObject.SetActive(false);

        Debug.Log("Ingredient hidden after cut: " + ingredientId);
    }
}