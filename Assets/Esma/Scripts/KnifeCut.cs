using UnityEngine;

public class KnifeCut : MonoBehaviour
{
    [Header("Object Settings")]
    public GameObject currentObject;
    public GameObject cutObject;

    private bool cutDone = false;

    private void OnTriggerEnter(Collider other)
    {
        if (cutDone) return;

        // Detect knife
        if (other.CompareTag("Knife"))
        {
            CutObject();
        }
    }

    void CutObject()
    {
        cutDone = true;

        // Hide original object
        if (currentObject != null)
            currentObject.SetActive(false);

        // Show cut version
        if (cutObject != null)
            cutObject.SetActive(true);
    }
}
