using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class IntroText4_4 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public float delayBeforeChange = 2f;
    public float fadeDuration = 1.5f;
    public float sceneTransitionDelay = 2f; // Час перед переходом
    public string nextSceneName = "Scene4.3"; // Назва наступної сцени

    void Start()
    {
        StartCoroutine(DisplayTextSequence());
    }

    IEnumerator DisplayTextSequence()
    {
        yield return ShowText("Сцена 3: Центральне ядро");
        yield return ShowText("Підземний комплекс з кібернетичним \"мозком\" NeuraTech — велетенською сферою, опутаною проводами. ");
        yield return ShowText("Алекс підключається до системи, але ШІ пропонує угоду.");

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
