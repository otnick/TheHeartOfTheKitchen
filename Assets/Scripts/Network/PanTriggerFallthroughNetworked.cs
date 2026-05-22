using UnityEngine;

public class PanTriggerFallthroughNetworked : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            collision.gameObject.GetComponent<FoodItemNetworked>().CookingFood();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            other.gameObject.GetComponent<FoodItemNetworked>().fallingThroughThePan = true;
            Debug.Log("food trigger interaction");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            other.gameObject.GetComponent<FoodItemNetworked>().fallingThroughThePan = true;
            Debug.Log("food trigger interaction");
        }
    }
}
