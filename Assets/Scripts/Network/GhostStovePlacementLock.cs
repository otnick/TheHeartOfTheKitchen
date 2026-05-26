using UnityEngine;

public class GhostStovePlacementLock : MonoBehaviour
{
    private Rigidbody rb;
    private Quaternion lockedRotation;
    private float lockedX;
    private float lockedZ;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        lockedRotation = transform.rotation;
        lockedX = transform.position.x;
        lockedZ = transform.position.z;
    }

    private void LateUpdate()
    {
        Vector3 pos = transform.position;
        transform.position = new Vector3(lockedX, pos.y, lockedZ);
        transform.rotation = lockedRotation;

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}