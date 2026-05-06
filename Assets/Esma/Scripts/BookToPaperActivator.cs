using UnityEngine;

public class BookToPaperActivator : MonoBehaviour
{
    [Header("Assign Paper Object")]
    public GameObject paper;

    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (activated) return;

        // Any object that touches the book triggers it
        if (other != null)
        {
            ActivatePaper();
        }
    }

    void ActivatePaper()
    {
        activated = true;

        if (paper != null)
        {
            paper.SetActive(true);
        }
    }
}
