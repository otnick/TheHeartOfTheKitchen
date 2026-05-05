using UnityEngine;
using TMPro;

public class MRStopwatch : MonoBehaviour
{
    public TextMeshPro timeText;

    private float elapsedTime = 0f;
    private bool isRunning = false;
    public Color normalColor = Color.white;
    public Color warningColor = Color.red;

    void Start()
    {
        UpdateDisplay(); // show 00:00 at start
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateDisplay();
        }
    }

    void UpdateDisplay()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
	if (elapsedTime >= 120f)
        {
            timeText.color = warningColor;
        }
        else
        {
            timeText.color = normalColor;
        }
    }

    // Start Button
    public void StartTimer()
    {
        isRunning = true;
    }

    // Stop Button
    public void StopTimer()
    {
        isRunning = false;
    }

    // Reset Button
    public void ResetTimer()
    {
        isRunning = false;
        elapsedTime = 0f;
        UpdateDisplay();
	timeText.color = normalColor;
    }
}