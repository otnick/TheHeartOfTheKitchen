using UnityEngine;
using TMPro;
using System.Collections;
using Unity.Netcode;

public class BookToPaperActivator : NetworkBehaviour
{
    [Header("Objects")]
    public GameObject paper;
    public GameObject bookModel1;
    public GameObject bookModel2;
    public GameObject timerUI;

    [Header("Timer")]
    public TextMeshProUGUI timerText;
    public float countdownTime = 147f;

    [Header("Audio")]
    public AudioSource musicSource;

    private NetworkVariable<bool> activated = new(false);
    private NetworkVariable<double> startTime = new(0);

    private void OnTriggerEnter(Collider other)
    {
        if (activated.Value) return;

        if (NetworkManager.Singleton == null || !NetworkManager.Singleton.IsListening)
        {
            Debug.LogWarning("NetworkManager is not started yet.");
            return;
        }

        if (IsServer)
        {
            StartSequenceServer();
        }
        else
        {
            RequestStartServerRpc();
        }
    }

    [ServerRpc(RequireOwnership = false)]
    void RequestStartServerRpc()
    {
        if (activated.Value) return;
        StartSequenceServer();
    }

    void StartSequenceServer()
    {
        activated.Value = true;
        startTime.Value = NetworkManager.Singleton.ServerTime.Time;

        StartSequenceClientRpc(startTime.Value);
    }

    [ClientRpc]
    void StartSequenceClientRpc(double networkStartTime)
    {
        ActivateVisuals();

        if (musicSource != null)
        {
            musicSource.volume = 0.05f;
            musicSource.Play();
            StartCoroutine(IncreaseMusicVolume());
        }

        StartCoroutine(StartTimer(networkStartTime));
    }

    void ActivateVisuals()
    {
        if (bookModel1 != null)
            bookModel1.SetActive(false);

        if (bookModel2 != null)
            bookModel2.SetActive(false);

        if (paper != null)
            paper.SetActive(true);

        if (timerUI != null)
            timerUI.SetActive(true);
    }

    IEnumerator IncreaseMusicVolume()
    {
        float duration = countdownTime;
        float startVolume = 0.05f;
        float targetVolume = 1f;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            musicSource.volume = Mathf.Lerp(startVolume, targetVolume, time / duration);
            yield return null;
        }

        musicSource.volume = targetVolume;
    }

    IEnumerator StartTimer(double networkStartTime)
    {
        while (true)
        {
            double elapsed = NetworkManager.Singleton.ServerTime.Time - networkStartTime;
            float currentTime = countdownTime - (float)elapsed;

            if (currentTime <= 0)
                break;

            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);

            if (timerText != null)
                timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

            yield return null;
        }

        if (timerText != null)
            timerText.text = "00:00";

        if (musicSource != null)
            musicSource.Stop();

        Debug.Log("Game Over");
    }
}