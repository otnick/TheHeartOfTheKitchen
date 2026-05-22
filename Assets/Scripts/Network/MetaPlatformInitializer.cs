using UnityEngine;
using UnityEngine.Events;
using Oculus.Platform;

public class MetaPlatformInitializer : MonoBehaviour
{
    [Header("Initialization Events")]
    [Tooltip("Triggered when the app is authenticated and Spatial Anchors are unlocked.")]
    public UnityEvent OnAuthenticationSuccess;

    [Tooltip("Triggered if the user fails store authentication.")]
    public UnityEvent OnAuthenticationFailed;

    private void Awake()
    {
        // Prevent this object from being destroyed if you switch scenes to your main level
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        InitializeMetaPlatform();
    }

    private void InitializeMetaPlatform()
    {
        Debug.Log("[Meta Auth] Starting core Platform SDK initialization...");

        // Step 1: Initialize the core underlying Meta SDK framework
        Core.AsyncInitialize().OnComplete(initMessage =>
        {
            if (initMessage.IsError)
            {
                Debug.LogError($"[Meta Auth] SDK Initialization crashed: {initMessage.GetError().Message}");
                OnAuthenticationFailed?.Invoke();
                return;
            }

            Debug.Log("[Meta Auth] Platform SDK online. Now checking store entitlement...");

            // Step 2: Query the Meta Horizon backend to see if this user is allowed to run the app
            Entitlements.IsUserEntitledToApplication().OnComplete(entitlementMessage =>
            {
                if (entitlementMessage.IsError)
                {
                    Debug.LogError($"[Meta Auth] Entitlement FAILED: {entitlementMessage.GetError().Message}");
                    Debug.LogError("[Meta Auth] Spatial features locked. Verify you are logged into a registered developer account on this headset.");
                    OnAuthenticationFailed?.Invoke();
                }
                else
                {
                    Debug.Log("[Meta Auth] Entitlement Success! Meta ecosystem and Spatial Anchors are completely unlocked.");

                    // Step 3: Run your game logic (e.g., enable matchmaking or activate anchor spawning)
                    OnAuthenticationSuccess?.Invoke();
                }
            });
        });
    }
}
