using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class TimesUpStopwatch : MonoBehaviour
{
    public TextMeshPro timerText;
    public GameObject timesUpText; // Drag TIME'S UP object here

    private float elapsedTime = 0f;
    private bool isRunning = true;

    public Color normalColor = Color.white;
    public Color warningColor = Color.red;

    private bool timeUp = false;

    void Start()
    {
        timesUpText.SetActive(false);
        UpdateDisplay();
    }

    void Update()
    {
        if (isRunning && !timeUp)
        {
            elapsedTime += Time.deltaTime;

            // At 2 minutes
            if (elapsedTime >= 120f)
            {
                ShowTimesUp();
            }
            else
            {
                UpdateDisplay();
            }
        }
    }

    void UpdateDisplay()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Red near ending
        if (elapsedTime >= 110f)
        {
            timerText.color = warningColor;
        }
        else
        {
            timerText.color = normalColor;
        }
    }

    void ShowTimesUp()
    {
        timeUp = true;
        isRunning = false;

        // Hide timer
        timerText.gameObject.SetActive(false);

        // Show TIME'S UP text
        timesUpText.SetActive(true);
    }
	public void RestartExperience()
{
    Scene currentScene = SceneManager.GetActiveScene();
    SceneManager.LoadScene(currentScene.buildIndex);
}
}