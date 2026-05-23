using UnityEngine;

public class ConfirmButton : MonoBehaviour
{
    public TableSetupManager setupManager;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Button pressed by: " + other.name);

        if (setupManager != null)
        {
            setupManager.ConfirmTablePlacement();
        }
        else
        {
            Debug.LogWarning("SetupManager missing!");
        }
    }
}