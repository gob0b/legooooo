using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneName;  // The name of the scene to load
    public float timeToWait = 5f;  // Time in seconds to wait before loading the scene

    private void Start()
    {
        // Start the timer when the script starts
        Invoke("LoadScene", timeToWait);
    }

    void LoadScene()
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }
}
