using UnityEngine;
using Fusion;
using Meta.XR.MultiplayerBlocks.Shared;

public class ColocationManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private OVRCameraRig cameraRig;
    [SerializeField] private Transform sceneRoot; // Parent of all scene geometry

    private bool _isAligned = false;

    // Wire this to the ColocationController's "Colocation Ready" UnityEvent
    public void OnColocationReady()
    {
        if (_isAligned) return;
        _isAligned = true;
        Debug.Log("[Colocation] OnColocationReady called — searching for anchor...");
        AlignToAnchor();
    }

    private void AlignToAnchor()
    {
        // Find the shared spatial anchor (created/localized by the Building Block)
        OVRSpatialAnchor anchor = FindFirstObjectByType<OVRSpatialAnchor>();

        if (anchor == null)
        {
            Debug.LogError("[Colocation] No OVRSpatialAnchor found! Make sure SharedSpatialAnchorCore has created one.");
            return;
        }

        if (!anchor.Localized)
        {
            Debug.LogWarning("[Colocation] Anchor not yet localized — retrying in 0.5s...");
            Invoke(nameof(AlignToAnchor), 0.5f);
            return;
        }

        Transform anchorT = anchor.transform;
        Debug.Log($"[Colocation] Aligning to anchor at {anchorT.position}, rot {anchorT.rotation.eulerAngles}");

        if (sceneRoot != null)
        {
            // Move the scene so the anchor is at world origin
            // This way all players see the scene at the same position relative to the anchor
            sceneRoot.position = -anchorT.position;
            sceneRoot.rotation = Quaternion.Inverse(anchorT.rotation);
            Debug.Log("[Colocation] Scene root aligned to anchor ✅");
        }
        else
        {
            // Fallback: align camera rig instead
            if (cameraRig == null)
            {
                Debug.LogError("[Colocation] Neither sceneRoot nor cameraRig assigned!");
                return;
            }

            Transform root = cameraRig.transform.root;
            // Build offset transform: move root so that anchor ends up at origin
            Quaternion deltaRot = Quaternion.Inverse(anchorT.rotation);
            root.rotation = deltaRot * root.rotation;
            root.position = deltaRot * (root.position - anchorT.position);
            Debug.Log("[Colocation] Camera rig aligned to anchor ✅");
        }
    }

    public void ResetAlignment()
    {
        _isAligned = false;
        CancelInvoke(nameof(AlignToAnchor));
        if (sceneRoot != null)
        {
            sceneRoot.position = Vector3.zero;
            sceneRoot.rotation = Quaternion.identity;
        }
        Debug.Log("[Colocation] Alignment reset.");
    }
}