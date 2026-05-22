using UnityEngine;

public class ColocationManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private OVRCameraRig cameraRig; // drag [BuildingBlock] Camera Rig here

    private bool _isAligned = false;

    // ── Wire this to "Colocation Ready Callbacks" in the Colocation BB ───────
    public void OnColocationReady()
    {
        if (_isAligned) return;
        _isAligned = true;

        Debug.Log("[Colocation] Colocation ready — aligning camera...");
        AlignCameraRig();
    }

    private void AlignCameraRig()
    {
        OVRSpatialAnchor anchor = FindFirstObjectByType<OVRSpatialAnchor>();

        if (anchor == null)
        {
            Debug.LogError("[Colocation] No OVRSpatialAnchor found in scene!");
            return;
        }

        if (cameraRig == null)
        {
            Debug.LogError("[Colocation] CameraRig is not assigned!");
            return;
        }

        Transform anchorT = anchor.transform;
        // Instead of moving cameraRig.transform directly
        // move its root parent
        Transform rootToMove = cameraRig.transform.root; // or cameraRig.transform.parent
        rootToMove.rotation = Quaternion.Inverse(anchorT.rotation) * rootToMove.rotation;
        rootToMove.position -= anchorT.position;

        Debug.Log($"[Colocation] Camera rig aligned to anchor at {anchorT.position} ✅");
    }

    // ── Optional reset for debugging ─────────────────────────────────────────
    public void ResetAlignment()
    {
        _isAligned = false;
        if (cameraRig != null)
        {
            cameraRig.transform.position = Vector3.zero;
            cameraRig.transform.rotation = Quaternion.identity;
        }
        Debug.Log("[Colocation] Alignment reset.");
    }
}