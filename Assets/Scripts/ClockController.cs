using UnityEngine;
using System;

public class ClockController : MonoBehaviour
{
    public Transform hourHand;
    public Transform minuteHand;
    public Transform secondHand;

    void Update()
    {
        DateTime time = DateTime.Now;

        float seconds = time.Second;
        float minutes = time.Minute + seconds / 60f;
        float hours = time.Hour % 12 + minutes / 60f;

        // Rotate hands (negative for clockwise rotation in Unity)
secondHand.localRotation = Quaternion.Euler(0, 0, seconds * 6f);
minuteHand.localRotation = Quaternion.Euler(0, 0, minutes * 6f);
hourHand.localRotation   = Quaternion.Euler(0, 0, hours * 30f);    }
}