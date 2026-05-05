using UnityEngine;
using UnityEngine.InputSystem;

public class DebugPhaseControls : MonoBehaviour
{
    [SerializeField] private GamePhaseManager phaseManager;
    [SerializeField] private RoleManager roleManager;

    private void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
            phaseManager.SetPhase(GamePhase.Ingredients);

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
            phaseManager.SetPhase(GamePhase.Prep);

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
            phaseManager.SetPhase(GamePhase.Cooking);

        if (Keyboard.current.digit4Key.wasPressedThisFrame)
            phaseManager.SetPhase(GamePhase.Delivery);

        if (Keyboard.current.kKey.wasPressedThisFrame)
            roleManager.SetLocalRoleKitchen();

        if (Keyboard.current.fKey.wasPressedThisFrame)
            roleManager.SetLocalRoleFront();
    }
}