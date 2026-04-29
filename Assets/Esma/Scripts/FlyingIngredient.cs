using UnityEngine;

public class FlyingIngredient : MonoBehaviour
{
    public int movementType = 0;
    public float speed = 1f;
    public float radius = 1f;

    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float t = Time.time * speed;

        if (movementType == 0) // circle
        {
            transform.position = startPos + new Vector3(Mathf.Cos(t), 0, Mathf.Sin(t)) * radius;
        }
        else if (movementType == 1) // up down
        {
            transform.position = startPos + new Vector3(0, Mathf.Sin(t), 0);
        }
        else if (movementType == 2) // random wave
        {
            transform.position = startPos + new Vector3(Mathf.Sin(t), Mathf.Cos(t), Mathf.Sin(t * 2)) * 0.7f;
        }
    }
}
