using UnityEngine;

public class BeeController : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    public float areaSize = 2f;
    public float minHeight = 1f;
    public float maxHeight = 2f;
    public Transform centerPoint;

    private Vector3 targetPosition;
    private bool isDead = false;

    void Start()
    {
        PickNewTarget();
    }

    void Update()
    {
        if (isDead) return;

        // Move toward target
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );
	float hover = Mathf.Sin(Time.time * 8f) * 0.05f;
	transform.position += Vector3.up * hover * Time.deltaTime;

        // Rotate toward movement direction
        Vector3 direction = targetPosition - transform.position;

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(direction),
                5f * Time.deltaTime
            );
        }

        // Pick new target when close
        if (Vector3.Distance(transform.position, targetPosition) < 0.2f)
        {
            PickNewTarget();
        }
    }

    void PickNewTarget()
    {
        Vector3 randomOffset = new Vector3(
            Random.Range(-areaSize, areaSize),
            Random.Range(minHeight, maxHeight),
            Random.Range(-areaSize, areaSize)
        );

        targetPosition = centerPoint.position + randomOffset;
    }

    public void Die()
    {
        isDead = true;

        Rigidbody rb = GetComponent<Rigidbody>();

        rb.isKinematic = false;
        rb.useGravity = true;
    }
}