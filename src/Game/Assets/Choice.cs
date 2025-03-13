using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Choice : MonoBehaviour
{
    public void PauseButton1()
    {
        Invoke("Button1", 0.3f);
    }

    private void Button1()
    {
        SceneManager.LoadScene("Final1");
    }

    public void PauseButton2()
    {
        Invoke("Button2", 0.3f);
    }

    private void Button2()
    {
        SceneManager.LoadScene("Final2");
    }
}