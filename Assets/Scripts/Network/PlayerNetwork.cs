using Fusion;

public class PlayerNetwork : NetworkBehaviour
{
    [Rpc(RpcSources.All, RpcTargets.All, HostMode = RpcHostMode.SourceIsHostPlayer)]
    public void RPC_ToggleLights(bool turnLightsOff)
    {
        FindAnyObjectByType<LightPuzzleController>()?.ApplyState(turnLightsOff);
    }
}