using UnityEngine;
using Fusion;

public class FoodPlateJointHandler : NetworkBehaviour
{
    private SpringJoint _joint;
    private Rigidbody _plateRb;
    [SerializeField] 
    float breakForce = 15f;
    [SerializeField]
    float breakTorque = 3f;
    [SerializeField]
    float springForce = 10f;
    [SerializeField]
    float _maxTiltAngle = 30f;

    void OnCollisionEnter(Collision col)
    {
        if (!Object.HasStateAuthority) return;

        if (col.gameObject.CompareTag("Plate") || col.gameObject.CompareTag("Pan"))
        {
            // Don't add a second joint if one already exists
            if (_joint != null) return;
            Debug.Log("foodPlateJoinCreation");

            _plateRb = col.rigidbody;
            _joint = gameObject.AddComponent<SpringJoint>();

            _joint.connectedBody = _plateRb;
            _joint.spring = springForce;
            _joint.damper = 5f;
            _joint.breakForce = breakForce;   // tweak these values
            _joint.breakTorque = breakTorque;   // to get the feel right
        }
    }

    public override void FixedUpdateNetwork()
    {
        if (_joint == null || _plateRb == null) return;

        // Get how far the plate is tilted from flat
        float tilt = Vector3.Angle(Vector3.up, _plateRb.transform.up);

        if (tilt > _maxTiltAngle)
        {
            RemoveJoint();
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (!Object.HasStateAuthority) return;

        // Food fully left the plate surface
        if (col.gameObject.CompareTag("Plate"))
        {
            RemoveJoint();
        }
    }

    void OnJointBreak(float breakForce)
    {
        // Unity calls this automatically when the joint snaps
        // Note: the joint is already destroyed at this point by Unity
        // just null out your reference
        _joint = null;
        _plateRb = null;
        Debug.Log("plate tilt too hard dont stand too close");
    }

    private void RemoveJoint()
    {
        if (_joint != null)
        {
            Destroy(_joint);
            _joint = null;
            _plateRb = null;
            Debug.Log("food slide off dont jerk too mouch");
        }
    }
}
