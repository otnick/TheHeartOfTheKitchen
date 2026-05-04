using UnityEngine;
using TMPro; // Use UnityEngine.UI if you're using normal Text

public class MRStopwatch : MonoBehaviour
{
    public TextMeshProUGUI timeText; // Assign your UI text here

    private float elapsedTime = 0f;
    private bool isRunning = false;

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

        // Format: 02:37
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // ?? Call this from your button (Start)
    public void StartStopwatch()
    {
        isRunning = true;
    }

    // ?? Optional Pause
    public void StopStopwatch()
    {
        isRunning = false;
    }

    // Reset
    public void ResetStopwatch()
    {
        isRunning = false;
        elapsedTime = 0f;
        UpdateDisplay();
    }
}