using Fusion;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    [Rpc(RpcSources.All, RpcTargets.All, HostMode = RpcHostMode.SourceIsHostPlayer)]
    public void RPC_ToggleLights(bool turnLightsOff)
    {
        FindAnyObjectByType<LightPuzzleController>()?.ApplyState(turnLightsOff);
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void RPC_StartBookSequence()
    {
        var bookActivator = FindFirstObjectByType<BookToPaperActivator>(
            FindObjectsInactive.Include
        );

        if (bookActivator == null)
        {
            Debug.LogWarning("BookToPaperActivator not found!");
            return;
        }

        bookActivator.ApplyBookSequence();
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void RPC_ConfirmTablePlacement(Vector3 position, Quaternion rotation)
    {
        var setup = FindFirstObjectByType<TableSetupManager>();

        if (setup != null)
        {
            setup.ApplyTablePlacement(position, rotation);
        }
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void RPC_IngredientEnterBowl(int ingredientId)
    {
        FlyingIngredient[] ingredients =
            FindObjectsByType<FlyingIngredient>(FindObjectsSortMode.None);

        foreach (var ingredient in ingredients)
        {
            if (ingredient.ingredientId == ingredientId)
            {
                ingredient.ApplyEnterBowl();
                return;
            }
        }

        Debug.LogWarning("FlyingIngredient not found: " + ingredientId);
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void RPC_CutIngredient(
        int ingredientId,
        Vector3 position,
        Quaternion rotation,
        int spawnCount,
        float spawnSpacing,
        Color freshColor,
        Color brownColor,
        Color blackColor)
    {
        KnifeCut[] cutters = FindObjectsByType<KnifeCut>(FindObjectsSortMode.None);

        foreach (var cutter in cutters)
        {
            if (cutter.ingredientId == ingredientId)
            {
                cutter.ApplyCutLocal();

                var runner = FindFirstObjectByType<NetworkRunner>();

                if (runner != null &&
                    (runner.IsServer || runner.IsSharedModeMasterClient))
                {
                    for (int i = 0; i < spawnCount; i++)
                    {
                        float offset = (i - (spawnCount - 1) / 2f) * spawnSpacing;

                        Vector3 spawnPos =
                            position + rotation * new Vector3(offset, 0f, 0f);

                        NetworkObject spawned = runner.Spawn(
                            cutter.cutPrefab,
                            spawnPos,
                            rotation
                        );

                        FoodItemNetworked food =
                            spawned.GetComponent<FoodItemNetworked>();

                        if (food != null)
                            food.SetColors(freshColor, brownColor, blackColor);
                    }
                }

                return;
            }
        }

        Debug.LogWarning("KnifeCut not found for ingredientId: " + ingredientId);
    }
}