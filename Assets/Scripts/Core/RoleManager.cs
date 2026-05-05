using System;
using UnityEngine;

// Manages the local player's role and provides methods to change it
public class RoleManager : MonoBehaviour
{
    public static RoleManager Instance { get; private set; }

    [SerializeField] private PlayerRole localPlayerRole = PlayerRole.Kitchen;

    public PlayerRole LocalPlayerRole => localPlayerRole;

    public event Action<PlayerRole> RoleChanged;

    private void Awake()
    {
        Instance = this;
    }

    public void SetRole(PlayerRole role)
    {
        if (localPlayerRole == role) return;

        localPlayerRole = role;
        RoleChanged?.Invoke(localPlayerRole);

        Debug.Log($"Role changed to: {localPlayerRole}");
    }

    public void SetLocalRoleKitchen()
    {
        SetRole(PlayerRole.Kitchen);
    }

    public void SetLocalRoleFront()
    {
        SetRole(PlayerRole.Front);
    }
}