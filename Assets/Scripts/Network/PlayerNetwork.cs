using Fusion;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    [Rpc(RpcSources.All, RpcTargets.All, HostMode = RpcHostMode.SourceIsHostPlayer)]
    public void RPC_ToggleLights(bool turnLightsOff)
    {
        FindAnyObjectByType<LightPuzzleController>()?.ApplyState(turnLightsOff);
    }

    [SerializeField] private BookToPaperActivator bookActivator;
    [Rpc(RpcSources.All, RpcTargets.All)]
    public void RPC_StartBookSequence()
    {
        Debug.Log("RPC_StartBookSequence received");

        if (bookActivator == null)
        {
            Debug.LogWarning("bookActivator missing on PlayerNetwork");
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
}