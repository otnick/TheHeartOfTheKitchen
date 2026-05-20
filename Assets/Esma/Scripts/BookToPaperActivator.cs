using UnityEngine;
using TMPro;
using System.Collections;

public class BookToPaperActivator : MonoBehaviour
{
    [Header("Objects")]
    public GameObject paper;
    public GameObject bookModel1;
    public GameObject bookModel2;
    public GameObject timerUI;

    [Header("Timer")]
    public TextMeshProUGUI timerText;
    public float countdownTime = 147f; // 2 min 27 sec

    [Header("Audio")]
    public AudioSource musicSource;

    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (activated) return;

        ActivateSequence();
    }

    void ActivateSequence()
    {
        activated = true;

        // Hide book animation
        if (bookModel1 != null)
            bookModel1.SetActive(false);

        // Hide book model
        if (bookModel2 != null)
            bookModel2.SetActive(false);

        // Show paper
        if (paper != null)
            paper.SetActive(true);

        // Show timer UI
        if (timerUI != null)
            timerUI.SetActive(true);

        // Start music
        if (musicSource != null)
        {
            musicSource.volume = 0.1f;
            musicSource.Play();

            StartCoroutine(IncreaseMusicVolume());
        }

        // Start countdown
        StartCoroutine(StartTimer());
    }

    IEnumerator IncreaseMusicVolume()
    {
        float duration = countdownTime; // whole timer duration

        float startVolume = 0.05f;
        float targetVolume = 1f;

        float time = 0f;

        musicSource.volume = startVolume;

        while (time < duration)
        {
            time += Time.deltaTime;

            musicSource.volume = Mathf.Lerp(
                startVolume,
                targetVolume,
                time / duration
            );

            yield return null;
        }

        musicSource.volume = targetVolume;
    }

    IEnumerator StartTimer()
    {
        float currentTime = countdownTime;

        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);

            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

            yield return null;
        }

        timerText.text = "00:00";

        // GAME OVER
        musicSource.Stop();

        Debug.Log("Game Over");
    }
}
