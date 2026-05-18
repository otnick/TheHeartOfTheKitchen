using UnityEngine;
using Fusion;

public class NetworkedFoodAccel : NetworkBehaviour
{
    public Vector3 prevPos = Vector3.zero;
    public Vector3 currentPos = Vector3.zero;
    [Networked]
    public Vector3 acceleration { get; set; } = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Spawned()
    {
        prevPos = transform.localPosition;
        currentPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAcceleration();
    }
    public override void FixedUpdateNetwork()
    {
        if (!HasStateAuthority) return;
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
