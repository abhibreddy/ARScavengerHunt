using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public Button restartButton;

    void Start()
    {
        // Debugging to make sure button is assigned
        if (restartButton != null)
        {
            // Add a listener to the button's onClick event
            restartButton.onClick.AddListener(RestartScene);
        }
    }

    public void RestartScene()
    {
        // Restart the current scene
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
