using Fusion;
using System.Collections;
using UnityEngine;

public class PanTriggerFallthroughNetworked : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField]
    GameObject particles;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            FoodItemNetworked food = collision.gameObject.GetComponent<FoodItemNetworked>();
            if (!food.ParticlesEnabled())
            {
                food.EnableParticles(true);
            }
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            if (!food.isCooking) food.isCooking = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            FoodItemNetworked food = collision.gameObject.GetComponent<FoodItemNetworked>();
            food.isCooking = false;
            IEnumerator coroutine = WaitAndCeckIfFoodStillThere(food);
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator WaitAndCeckIfFoodStillThere(FoodItemNetworked food)
    {
        yield return new WaitForSeconds(1f);
        if (!food.isCooking)
        {
            audioSource.Stop();
            food.EnableParticles(false);
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
