using UnityEngine;

public class GhostStovePlacementLock : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 lockedPosition;
    private Quaternion lockedRotation;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        lockedPosition = transform.position;
        lockedRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        transform.position = lockedPosition;
        transform.rotation = lockedRotation;

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}