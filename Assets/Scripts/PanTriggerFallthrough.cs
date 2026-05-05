using UnityEngine;

public class PanTriggerFallthrough : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            // Snap it back to the floor if it fell through
            other.transform.localPosition = new Vector3(other.transform.localPosition.x, this.transform.position.y + other.transform.localScale.y/2, other.transform.localPosition.z) ;
            //other.attachedRigidbody.linearVelocity = Vector3.zero;
            other.attachedRigidbody.linearVelocity = new Vector3(other.attachedRigidbody.linearVelocity.x,GetComponent<Rigidbody>().linearVelocity.y, other.attachedRigidbody.linearVelocity.z);
            //other.transform.localRotation = Quaternion.Euler(new Vector3(transform.localRotation.x, other.transform.localRotation.y, transform.localRotation.z));
            other.transform.localRotation = transform.localRotation;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            // Snap it back to the floor if it fell through
            other.transform.localPosition = new Vector3(other.transform.localPosition.x, this.transform.position.y + other.transform.localScale.y / 2, other.transform.localPosition.z);
            //other.attachedRigidbody.linearVelocity = Vector3.zero;
            other.attachedRigidbody.linearVelocity = new Vector3(other.attachedRigidbody.linearVelocity.x,GetComponent<Rigidbody>().linearVelocity.y, other.attachedRigidbody.linearVelocity.z);
            //other.transform.localRotation = Quaternion.Euler(new Vector3(transform.localRotation.x,other.transform.localRotation.y, transform.localRotation.z));
            other.transform.localRotation = transform.localRotation;
        }
    }
}
