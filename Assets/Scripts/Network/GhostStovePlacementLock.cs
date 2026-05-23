using UnityEngine;

public class GhostStovePlacementLock : MonoBehaviour
{
    public bool allowYRotation = false;

    private Rigidbody rb;
    private float lockedY;
    private Quaternion lockedRotation;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        lockedY = transform.position.y;
        lockedRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, lockedY, pos.z);

        if (allowYRotation)
        {
            Vector3 rot = transform.eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rot.y, 0f);
        }
        else
        {
            transform.rotation = lockedRotation;
        }

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}