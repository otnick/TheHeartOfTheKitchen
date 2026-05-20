using UnityEngine;

public class FlyingIngredient : MonoBehaviour
{
    public float speed = 0.7f;
    public float amplitude = 0.2f;

    public GameObject wingObject;

    private Vector3 startPos;

    private float offsetX;
    private float offsetY;
    private float offsetZ;

    private Rigidbody rb;

    private bool inBowl = false;

    void Start()
    {
        offsetX = Random.Range(0f, 100f);
        offsetY = Random.Range(0f, 100f);
        offsetZ = Random.Range(0f, 100f);

        startPos = transform.position;

        rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.useGravity = false;
            rb.isKinematic = true; // IMPORTANT FIX
        }

        if (wingObject != null)
            wingObject.SetActive(true);
    }

    void Update()
    {
        if (inBowl) return;

        float t = Time.time * speed;

        Vector3 offset = new Vector3(
            Mathf.Sin(t + offsetX),
            Mathf.Cos(t + offsetY),
            Mathf.Sin(t + offsetZ)
        ) * amplitude;

        transform.position = startPos + offset;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bowl"))
        {
            EnterBowl();
        }
    }

    void EnterBowl()
    {
        inBowl = true;

        // stop floating system completely
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.WakeUp();

        if (wingObject != null)
            wingObject.SetActive(false);

        transform.SetParent(null);
    }
}