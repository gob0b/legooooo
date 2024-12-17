using UnityEngine;

public class AutoCameraZoom : MonoBehaviour
{
    public Camera mainCamera;  // Reference to the camera
    public float zoomSpeed = 10f; // Speed of zooming (adjustable in the inspector)
    public float minZoom = 5f; // Minimum zoom distance (field of view)
    public float maxZoom = 50f; // Maximum zoom distance (field of view)
    public float zoomOutDuration = 5f; // Time in seconds to zoom out fully

    private float targetZoom;

    private void Start()
    {
        // Set initial zoom target to the maximum zoom level
        targetZoom = maxZoom;

        // Start zooming out when the game starts (or when you press Play)
        StartCoroutine(ZoomOutOverTime());
    }

    private System.Collections.IEnumerator ZoomOutOverTime()
    {
        float startZoom = mainCamera.fieldOfView;
        float elapsedTime = 0f;

        // Gradually zoom out to the target zoom level over time
        while (elapsedTime < zoomOutDuration)
        {
            mainCamera.fieldOfView = Mathf.Lerp(startZoom, targetZoom, elapsedTime / zoomOutDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure we reach the target zoom exactly
        mainCamera.fieldOfView = targetZoom;
    }
}

