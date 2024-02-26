using UnityEngine;

public class LockAspectRatio : MonoBehaviour
{
    public float targetAspect = 16.0f / 9.0f; // Example aspect ratio

    void Start()
    {
        Camera mainCamera = Camera.main;

        // Calculate window's current aspect ratio
        float windowAspect = (float)Screen.width / (float)Screen.height;

        // Current vertical size compared to desired aspect ratio
        float scaleHeight = windowAspect / targetAspect;

        // Create a new rect with the adjusted size
        Rect rect = new Rect(0, 0, 1, 1);

        if (scaleHeight > targetAspect)
        {
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
            rect.width = 1.0f;
            rect.height = scaleHeight;
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
            rect.width = scaleWidth;
            rect.height = 1.0f;
        }

        mainCamera.rect = rect;
    }
}