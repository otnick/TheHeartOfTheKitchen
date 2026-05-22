using UnityEngine;

public class FoodAcceleration : MonoBehaviour
{
    Vector3 prevPos = Vector3.zero;
    Vector3 currentPos = Vector3.zero;
    Vector3 acceleration = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        prevPos = transform.localPosition;
        currentPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAcceleration();
    }
    public void ApplyAcceleration()
    {
        this.gameObject.GetComponent<Rigidbody>().linearVelocity = acceleration;
    }
    public void UpdateAcceleration()
    {
        currentPos = transform.localPosition;
        acceleration = prevPos - currentPos;
        prevPos = currentPos;
    }
}
