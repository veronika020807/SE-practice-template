using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class IntroText5_1 : MonoBehaviour
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
        yield return ShowText("ГЛАВА 4: ОСТАННЯ КОДОВА ІСКРА");
        yield return ShowText("Сцена 1: СЕРЦЕ СИСТЕМИ");
        yield return ShowText("Алекс і Лекса пробиваються до Центрального ядра NeuraTech — велетенської кріогенної камери, де підключений батько.");
        yield return ShowText("Навколо мерехтять голограми з даними, а ШІ постійно моніторить їхні дії.");

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
