using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public void PlayTheGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
