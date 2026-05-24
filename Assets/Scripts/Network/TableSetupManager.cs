using UnityEngine;
using Fusion;

public class TableSetupManager : MonoBehaviour
{
    [Header("Setup")]
    public GameObject setupRoot;
    public Transform ghostStove;

    [Header("Shared Anchor")]
    public Transform sharedAnchorTransform;

    [Header("Network Spawn")]
    public NetworkPrefabRef gameRootNetworkPrefab;

    [Header("Placement Offset")]
    public Vector3 gameRootOffset = new Vector3(0.275f, -0.38f, 0f);

    private NetworkObject spawnedGameRoot;

    private void FindSharedAnchor()
    {
        if (sharedAnchorTransform != null)
            return;

        OVRSpatialAnchor anchor = FindFirstObjectByType<OVRSpatialAnchor>();

        if (anchor != null)
        {
            sharedAnchorTransform = anchor.transform;
            Debug.Log("Shared anchor found: " + anchor.gameObject.name);
        }
        else
        {
            Debug.LogWarning("No OVRSpatialAnchor found yet!");
        }
    }

    public void ConfirmTablePlacement()
    {
        FindSharedAnchor();

        if (ghostStove == null)
        {
            Debug.LogWarning("GhostStove missing!");
            return;
        }

        if (sharedAnchorTransform == null)
        {
            Debug.LogWarning("SharedAnchorTransform missing!");
            return;
        }

        Vector3 spawnWorldPosition = ghostStove.position + gameRootOffset;
        Quaternion spawnWorldRotation = ghostStove.rotation;

        Vector3 localPosition =
            sharedAnchorTransform.InverseTransformPoint(spawnWorldPosition);

        Quaternion localRotation =
            Quaternion.Inverse(sharedAnchorTransform.rotation) * spawnWorldRotation;

        var playerNetwork = FindFirstObjectByType<PlayerNetwork>();

        if (playerNetwork != null)
        {
            playerNetwork.RPC_ConfirmTablePlacement(localPosition, localRotation);
        }
        else
        {
            Debug.LogWarning("PlayerNetwork not found!");
        }
    }

    public void ApplyTablePlacement(Vector3 localPosition, Quaternion localRotation)
    {
        FindSharedAnchor();

        if (setupRoot != null)
            setupRoot.SetActive(false);

        if (sharedAnchorTransform == null)
        {
            Debug.LogWarning("SharedAnchorTransform missing!");
            return;
        }

        Vector3 worldPosition =
            sharedAnchorTransform.TransformPoint(localPosition);

        Quaternion worldRotation =
            sharedAnchorTransform.rotation * localRotation;

        var runner = FindFirstObjectByType<NetworkRunner>();

        if (runner == null)
        {
            Debug.LogWarning("NetworkRunner not found!");
            return;
        }

        if (runner.IsServer || runner.IsSharedModeMasterClient)
        {
            if (spawnedGameRoot != null)
                return;

            spawnedGameRoot = runner.Spawn(
                gameRootNetworkPrefab,
                worldPosition,
                worldRotation
            );

            Debug.Log("Spawned GameRoot network prefab at anchor-relative pose");
        }
    }
}