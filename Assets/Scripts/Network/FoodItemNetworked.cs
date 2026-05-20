using UnityEngine;
using Fusion;
public class FoodItemNetworked : NetworkBehaviour
{
    public bool fallingThroughThePan { get; set; } = false;
    private GameObject pan;
    private NetworkTransform nt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pan = GameObject.Find("Pan");
        nt = gameObject.GetComponent<NetworkTransform>();
    }

    public override void FixedUpdateNetwork()
    {
        if (!Object.HasStateAuthority) return;

        if (fallingThroughThePan)
        {
            TeleportItem();
            fallingThroughThePan = false;
        }
    }
    private void TeleportItem()
    {
        // Snap it back to the floor if it fell through
        nt.Teleport(new Vector3(transform.localPosition.x, pan.transform.localPosition.y + transform.localScale.y / 2, transform.localPosition.z),
            pan.transform.localRotation); //TODO: later on check the pivot points of the tangible pan and real pan.
        return;
    }
}
