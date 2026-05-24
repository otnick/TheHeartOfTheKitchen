// NetworkedPan.cs
using Fusion;
using UnityEngine;

public class PanTracker : NetworkBehaviour
{
    [Header("Adjust these to align colliders with physical pan")]
    public Vector3 positionOffset = new Vector3(0, -0.05f, 0.1f);
    public Vector3 rotationOffset = new Vector3(0, 0, 0);

    [Networked] private Vector3 NetworkedPosition { get; set; }
    [Networked] private Quaternion NetworkedRotation { get; set; }

    private Transform _trackingSpace;

    private bool IsRightControllerTracked =>
        OVRInput.IsControllerConnected(OVRInput.Controller.RTouch) &&
        OVRInput.GetControllerPositionTracked(OVRInput.Controller.RTouch);

    public override void Spawned()
    {
        if (HasStateAuthority)
        {
            _trackingSpace = FindFirstObjectByType<OVRCameraRig>().trackingSpace;
        }
    }

    public override void FixedUpdateNetwork()
    {
        if (!HasStateAuthority || !IsRightControllerTracked) return;

        Vector3 controllerPos = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
        Quaternion controllerRot = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);

        Vector3 worldPos = _trackingSpace.TransformPoint(controllerPos);
        Quaternion worldRot = _trackingSpace.rotation * controllerRot;

        NetworkedPosition = worldRot * positionOffset + worldPos;
        NetworkedRotation = worldRot * Quaternion.Euler(rotationOffset);
    }

    public override void Render()
    {
        transform.position = NetworkedPosition;
        transform.rotation = NetworkedRotation;
    }
}