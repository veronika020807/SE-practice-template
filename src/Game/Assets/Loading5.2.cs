using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class IntroText5_2 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public float delayBeforeChange = 2f;
    public float fadeDuration = 1.5f;
    public float sceneTransitionDelay = 2f; // Час перед переходом
    public string nextSceneName = "Scene5.1"; // Назва наступної сцени

    void Start()
    {
        StartCoroutine(DisplayTextSequence());
    }

    IEnumerator DisplayTextSequence()
    {
        yield return ShowText("Сцена 2: ВИБІР");
        yield return ShowText("Система пропонує два варіанти:");
        yield return ShowText("1. Знищити ядро — звільнити батька, але стерти всі дані NeuraTech.");
        yield return ShowText("2. Переписати код — об’єднатися з ШІ, щоб створити нову систему.");

        // Затримка перед переходом на наступну сцену
        yield return new WaitForSeconds(sceneTransitionDelay);
        SceneManager.LoadScene(nextSceneName);
    }

    IEnumerator ShowText(string message)
    {
        textDisplay.text = message;
        yield return FadeText(1f);
        yield return new WaitForSeconds(delayBeforeChange);
        yield return FadeText(0f);
    }

    IEnumerator FadeText(float targetAlpha)
    {
        float startAlpha = textDisplay.color.a;
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            textDisplay.color = new Color(textDisplay.color.r, textDisplay.color.g, textDisplay.color.b, alpha);
            yield return null;
        }
    }
}
