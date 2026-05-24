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
        FlyingIngredient[] ingredients = FindObjectsByType<FlyingIngredient>(FindObjectsSortMode.None);

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
    public void RPC_CutIngredient(int ingredientId)
    {
        KnifeCut[] cutters = FindObjectsByType<KnifeCut>(FindObjectsSortMode.None);

        foreach (var cutter in cutters)
        {
            if (cutter.ingredientId == ingredientId)
            {
                cutter.ApplyCut();
                return;
            }
        }

        Debug.LogWarning("KnifeCut not found: " + ingredientId);
    }
}