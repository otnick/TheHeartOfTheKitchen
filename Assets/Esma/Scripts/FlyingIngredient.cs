using UnityEngine;

public class FlyingIngredient : MonoBehaviour
{
    [Header("Float Settings")]
    public float speed = 0.5f;
    public float amplitude = 0.1f;

    private bool isGrabbed = false;

    private Vector3 startPos;

    private float offsetX;
    private float offsetY;
    private float offsetZ;

    void Start()
    {
        // Randomize movement so each object behaves differently
        offsetX = Random.Range(0f, 100f);
        offsetY = Random.Range(0f, 100f);
        offsetZ = Random.Range(0f, 100f);

        startPos = transform.position;
    }

    void Update()
    {
        // Stop animation while grabbed
        if (isGrabbed) return;

        float t = Time.time * speed;

        // Smooth floating motion
        Vector3 offset = new Vector3(
            Mathf.Sin(t + offsetX),
            Mathf.Cos(t + offsetY),
            Mathf.Sin(t + offsetZ)
        ) * amplitude;

        transform.position = startPos + offset;
    }

    // Called by OVRGrabbable
    public void OnGrabBegin()
    {
        isGrabbed = true;
    }

    // Called by OVRGrabbable
    public void OnGrabEnd()
    {
        isGrabbed = false;
    }
}