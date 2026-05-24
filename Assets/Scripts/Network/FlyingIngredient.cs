using UnityEngine;
using Fusion;

public class FlyingIngredient : MonoBehaviour
{
    public int ingredientId;

    public Transform visualRoot;
    public GameObject wingObject;

    public float speed = 0.7f;
    public float amplitude = 0.2f;

    private Rigidbody rb;
    private bool inBowl = false;

    private float offsetX;
    private float offsetY;
    private float offsetZ;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        offsetX = Random.Range(0f, 100f);
        offsetY = Random.Range(0f, 100f);
        offsetZ = Random.Range(0f, 100f);

        if (rb != null)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            rb.linearDamping = 10f;
            rb.angularDamping = 10f;
        }

        if (wingObject != null)
            wingObject.SetActive(true);

        if (visualRoot != null)
            visualRoot.localPosition = Vector3.zero;
    }

    void Update()
    {
        if (visualRoot == null) return;

        if (inBowl)
        {
            visualRoot.localPosition = Vector3.zero;
            return;
        }

        float t = Time.time * speed;

        visualRoot.localPosition = new Vector3(
            Mathf.Sin(t + offsetX),
            Mathf.Cos(t + offsetY),
            Mathf.Sin(t + offsetZ)
        ) * amplitude;
    }

    void LateUpdate()
    {
        if (inBowl) return;

        StopMotion();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ingredient trigger with: " + other.name + " tag: " + other.tag);

        if (inBowl) return;

        if (other.CompareTag("Bowl"))
        {
            Debug.Log("BOWL DETECTED for ingredient " + ingredientId);

            var playerNetwork = FindFirstObjectByType<PlayerNetwork>();

            if (playerNetwork != null)
            {
                playerNetwork.RPC_IngredientEnterBowl(ingredientId);
            }
            else
            {
                Debug.LogWarning("PlayerNetwork not found, applying locally");
                ApplyEnterBowl();
            }
        }
    }

    public void OnGrabbed()
    {
        StopMotion();
    }

    public void OnReleased()
    {
        StopMotion();
    }

    private void StopMotion()
    {
        if (rb == null) return;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public void ApplyEnterBowl()
    {
        if (inBowl) return;

        inBowl = true;

        if (visualRoot != null)
            visualRoot.localPosition = Vector3.zero;

        StopMotion();

        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
            rb.WakeUp();
        }

        if (wingObject != null)
            wingObject.SetActive(false);

        transform.SetParent(null);

        Debug.Log("Ingredient entered bowl: " + ingredientId);
    }
}