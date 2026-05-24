using UnityEngine;
using Fusion;

public class NetworkedPan : NetworkBehaviour
{
    [Networked] private Vector3 SyncedPos { get; set; }
    [Networked] private Quaternion SyncedRot { get; set; }

    public override void FixedUpdateNetwork()
    {
        // Only write authoritative state here — this is the simulation
        if (HasStateAuthority)
        {
            SyncedPos = transform.position;
            SyncedRot = transform.rotation;
        }
    }

    public override void Render()
    {
        // Lerp lives here — purely visual, runs every frame
        if (!HasStateAuthority)
        {
            transform.position = Vector3.Lerp(transform.position, SyncedPos, Time.deltaTime * 20f);
            transform.rotation = Quaternion.Slerp(transform.rotation, SyncedRot, Time.deltaTime * 20f);
        }
    }
}