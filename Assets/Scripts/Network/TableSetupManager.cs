using Fusion;
using Meta.WitAi.Attributes;
using UnityEditor;
using UnityEngine;

public class TableSetupManager : MonoBehaviour
{
    [Header("Setup")]
    public GameObject setupRoot;
    public Transform ghostStove;

    [Header("Network Spawn")]
    public NetworkPrefabRef gameRootNetworkPrefab;

    [Header("Placement Offset")]
    public Vector3 gameRootOffset = new Vector3(0.275f, -0.38f, 0f);

    private NetworkObject spawnedGameRoot;

    public void ConfirmTablePlacement()
    {
        Vector3 spawnPosition = ghostStove.position + gameRootOffset;
        Quaternion spawnRotation = ghostStove.rotation;

        var playerNetwork = FindFirstObjectByType<PlayerNetwork>();

        if (playerNetwork != null)
        {
            playerNetwork.RPC_ConfirmTablePlacement(
                spawnPosition,
                spawnRotation
            );
        }
        else
        {
            Debug.LogWarning("PlayerNetwork not found!");
        }
    }

    private bool placementConfirmed = false;
    public void ApplyTablePlacement(Vector3 position, Quaternion rotation)
    {
        if (setupRoot != null)
            setupRoot.SetActive(false);

        if (placementConfirmed)
            return;
        placementConfirmed = true;

        var runner = FindFirstObjectByType<NetworkRunner>();
        if (runner == null)
        {
            Debug.LogWarning("NetworkRunner not found!");
            return;
        }

        if (runner.IsServer || runner.IsSharedModeMasterClient)
        {
            spawnedGameRoot = runner.Spawn(
                gameRootNetworkPrefab,
                position,
                rotation
            );
            Debug.Log("Spawned GameRoot network prefab");
        }
    }
}