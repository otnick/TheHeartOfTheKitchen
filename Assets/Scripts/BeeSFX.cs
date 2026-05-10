using UnityEngine;

public class BeeSound : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Slight random pitch change
        audioSource.pitch = 1f + Mathf.Sin(Time.time * 10f) * 0.05f;
    }
}