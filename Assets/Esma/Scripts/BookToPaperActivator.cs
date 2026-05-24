using UnityEngine;
using TMPro;
using System.Collections;
using Fusion;

public class BookToPaperActivator : MonoBehaviour
{
    public GameObject paper;
    public GameObject bookModel1;
    public GameObject bookModel2;
    public GameObject timerUI;

    public TextMeshProUGUI timerText;
    public float countdownTime = 147f;

    public AudioSource musicSource;

    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("BOOK TRIGGER by: " + other.name);

        if (activated)
        {
            Debug.Log("Book already activated locally");
            return;
        }

        var playerNetwork = FindFirstObjectByType<PlayerNetwork>();

        Debug.Log("PlayerNetwork found: " + (playerNetwork != null));

        if (playerNetwork == null)
        {
            Debug.LogWarning("PlayerNetwork not found!");
            return;
        }

        Debug.Log("Calling RPC_StartBookSequence");
        playerNetwork.RPC_StartBookSequence();
    }

    public void ApplyBookSequence()
    {
        Debug.Log("=== ApplyBookSequence called ===");

        Debug.Log("activated before: " + activated);

        Debug.Log("bookModel1 assigned: " + (bookModel1 != null));
        Debug.Log("bookModel2 assigned: " + (bookModel2 != null));
        Debug.Log("paper assigned: " + (paper != null));
        Debug.Log("timerUI assigned: " + (timerUI != null));
        Debug.Log("timerText assigned: " + (timerText != null));
        Debug.Log("musicSource assigned: " + (musicSource != null));

        if (timerUI != null)
        {
            Debug.Log("timerUI activeSelf before: " + timerUI.activeSelf);
            Debug.Log("timerUI activeInHierarchy before: " + timerUI.activeInHierarchy);
            Debug.Log("timerUI parent: " + (timerUI.transform.parent != null ? timerUI.transform.parent.name : "no parent"));
        }

        if (activated)
        {
            Debug.Log("Already activated in ApplyBookSequence");
            return;
        }

        activated = true;

        if (bookModel1 != null)
        {
            bookModel1.SetActive(false);
            Debug.Log("bookModel1 disabled");
        }

        if (bookModel2 != null)
        {
            bookModel2.SetActive(false);
            Debug.Log("bookModel2 disabled");
        }

        if (paper != null)
        {
            paper.SetActive(true);
            Debug.Log("paper enabled | activeSelf: " + paper.activeSelf + " | activeInHierarchy: " + paper.activeInHierarchy);
        }

        if (timerUI != null)
        {
            timerUI.SetActive(true);
            Debug.Log("timerUI enabled | activeSelf: " + timerUI.activeSelf + " | activeInHierarchy: " + timerUI.activeInHierarchy);
        }
        else
        {
            Debug.LogWarning("timerUI is NULL");
        }

        if (musicSource != null)
        {
            Debug.Log("Playing music on: " + musicSource.gameObject.name);

            musicSource.volume = 0.05f;
            musicSource.Play();

            Debug.Log("musicSource isPlaying after Play: " + musicSource.isPlaying);
            Debug.Log("musicSource clip: " + (musicSource.clip != null ? musicSource.clip.name : "NO CLIP"));

            StartCoroutine(IncreaseMusicVolume());
        }
        else
        {
            Debug.LogWarning("musicSource is NULL");
        }

        Debug.Log("Starting timer coroutine");
        StartCoroutine(StartTimer());
    }

    IEnumerator IncreaseMusicVolume()
    {
        Debug.Log("IncreaseMusicVolume started");

        float time = 0f;

        while (time < countdownTime)
        {
            time += Time.deltaTime;

            if (musicSource != null)
                musicSource.volume = Mathf.Lerp(0.05f, 1f, time / countdownTime);

            yield return null;
        }

        if (musicSource != null)
            musicSource.volume = 1f;

        Debug.Log("IncreaseMusicVolume finished");
    }

    IEnumerator StartTimer()
    {
        Debug.Log("StartTimer started");

        float currentTime = countdownTime;

        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);

            if (timerText != null)
            {
                timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
            }
            else
            {
                Debug.LogWarning("timerText is NULL while timer is running");
                yield break;
            }

            yield return null;
        }

        if (timerText != null)
            timerText.text = "00:00";

        if (musicSource != null)
            musicSource.Stop();

        Debug.Log("Timer finished - Game Over");
    }
}