using UnityEngine;
using Fusion;

public class KnifeCut : MonoBehaviour
{
    public int ingredientId;

    public GameObject currentObject;
    public GameObject cutObject;

    private bool cutDone = false;

    private void OnTriggerEnter(Collider other)
    {
        if (cutDone) return;

        if (other.CompareTag("Knife"))
        {
            var playerNetwork = FindFirstObjectByType<PlayerNetwork>();

            if (playerNetwork != null)
                playerNetwork.RPC_CutIngredient(ingredientId);
        }
    }

    public void ApplyCut()
    {
        if (cutDone) return;

        cutDone = true;

        if (currentObject != null)
            currentObject.SetActive(false);

        if (cutObject != null)
            cutObject.SetActive(true);

        Debug.Log("Ingredient cut: " + ingredientId);
    }
}