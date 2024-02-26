using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Image timerImage;
    public float totalTime = 60.0f; // Total time in seconds
    
    private float currentTime;

    void Start()
    {
        currentTime = totalTime;
    }

    void Update()
    {
        if (currentTime > 0)
        {
            // Update the timer
            currentTime -= Time.deltaTime;
            UpdateTimerUI();
        }
        else
        {
            // Timer reached zero, perform any actions needed
            Debug.Log("Timer expired!");
        }
    }

    void UpdateTimerUI()
    {
        // Calculate the fill amount based on the current time and total time
        float fillAmount = currentTime / totalTime;

        // Set the fill amount for the circular timer
        timerImage.fillAmount = fillAmount;
    }
}
