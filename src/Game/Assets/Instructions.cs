using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void LoadMainMenu()
    {
        Invoke("LoadMainMenuDelayed", 0.3f);
    }

    private void LoadMainMenuDelayed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
