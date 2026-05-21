using UnityEngine;

public class InteractionPermissionManager : MonoBehaviour
{
    public static InteractionPermissionManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public bool CanInteract(PlayerRole role, GamePhase phase)
    {
        return true;
    }
}