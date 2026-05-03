using UnityEngine;
// Manages the local player's role and provides methods to change it
public class RoleManager : MonoBehaviour
{
    public static RoleManager Instance { get; private set; }

    [SerializeField] private PlayerRole localPlayerRole = PlayerRole.Kitchen;

    public PlayerRole LocalPlayerRole => localPlayerRole;

    private void Awake()
    {
        Instance = this;
    }

    public void SetLocalRoleKitchen()
    {
        localPlayerRole = PlayerRole.Kitchen;
    }

    public void SetLocalRoleFront()
    {
        localPlayerRole = PlayerRole.Front;
    }
}