using UnityEngine;
using TMPro;

public class MRStopwatch : MonoBehaviour
{
    public TextMeshPro timeText;     // 3D text showing time (00:00)
    public TextMeshPro buttonText;   // Text on the button (Start/Stop)

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

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // 🔘 Connect this to your MR button press event
    public void ToggleStopwatch()
    {
        isRunning = !isRunning;

        if (isRunning)
        {
            buttonText.text = "Stop";
        }
        else
        {
            buttonText.text = "Start";
        }
    }

    // (Optional) Reset function
    public void ResetStopwatch()
    {
        isRunning = false;
        elapsedTime = 0f;
        timeText.text = "00:00";
        buttonText.text = "Start";
    }
}