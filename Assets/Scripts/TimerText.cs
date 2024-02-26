using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Collections;
using System.Collections.Generic;

public class TimerScript : MonoBehaviour
{
    public float timerDuration; // Duration of the timer in seconds
    private float timer;
    private bool timer_going = true;

    private TextMeshProUGUI timerTextMesh; // Reference to the TextMesh component for displaying the timer

    void Start()
    {
        // Ensure that you have a TextMesh component attached to the same GameObject
        timerTextMesh = GetComponent<TextMeshProUGUI>();

        timer = timerDuration;

        timerTextMesh.color = Color.black;

    }

    void Update() {

        if (timer_going) {

            // Update the timer countdown
            timer -= Time.deltaTime;

            // Update the displayed timer text on the TextMesh
            timerTextMesh.text = Mathf.Ceil(timer).ToString();

            timerTextMesh.color = new Color(1-timer/timerDuration, 0, 0, 1);

            // Check if the timer has reached zero
            if (timer <= 0)
            {
                // Timer has reached zero, do something (e.g., trigger an event, reset, etc.)
                timer_going = false;

                SceneManager.LoadScene("Lose Screen");

            }
        }
    }
}
