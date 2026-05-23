using UnityEngine;
using Fusion;

public class TableSetupManager : MonoBehaviour
{
    [Header("Setup")]
    public GameObject setupRoot;
    public Transform ghostStove;

    [Header("Game")]
    public GameObject gameRoot;
    public Vector3 gameRootOffset = new Vector3(0.275f, -0.38f, 0f);

    public void ConfirmTablePlacement()
    {
        Vector3 gameRootPosition =
            ghostStove.position + gameRootOffset;

        var playerNetwork = FindFirstObjectByType<PlayerNetwork>();

        if (playerNetwork != null)
        {
            playerNetwork.RPC_ConfirmTablePlacement(
                gameRootPosition,
                ghostStove.rotation
            );
        }
        else
        {
            Debug.LogWarning("PlayerNetwork not found");
        }
    }

    public void ApplyTablePlacement(Vector3 position, Quaternion rotation)
    {
        Debug.Log("ApplyTablePlacement");

        gameRoot.transform.position = position;
        gameRoot.transform.rotation = rotation;

        gameRoot.SetActive(true);

        if (setupRoot != null)
            setupRoot.SetActive(false);
    }
}