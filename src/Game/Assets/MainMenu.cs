using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GamePause()
    {
        Invoke("PlayGame", 1.2f);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Chapter 1/Loading1");
    }
    public void QuitPause()
    {
        Invoke("QuitGame", 1.0f);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void LoadInstructions()
    {
        Invoke("LoadSceneInstructions", 0.3f); 
    }

    private void LoadSceneInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }
}
