using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class IntroText4_2 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public float delayBeforeChange = 2f;
    public float fadeDuration = 1.5f;
    public float sceneTransitionDelay = 2f; // Час перед переходом
    public string nextSceneName = "Scene4.2"; // Назва наступної сцени

    void Start()
    {
        StartCoroutine(DisplayTextSequence());
    }

    IEnumerator DisplayTextSequence()
    {
        yield return ShowText("Головоломка: Маскарад");
        yield return ShowText("Крок 1: Вибрати правильний шаблон сигнатури зі списку.\n(Потрібно знати дату народження інженера).");
        yield return ShowText("Крок 2: Обійти біометричну перевірку, підставивши 3D-модель обличчя.");
        yield return ShowText("Алекс використовує дані зі щоденника батька, де вказано: \"Ключі до систем — у дрібничках\".");
        yield return ShowText("Вгадує, що дата — день заснування NeuraTech.");
        yield return ShowText("Система: [Доступ надано].\nЛаскаво просимо, інженер Грей.");
        yield return ShowText("Сцена 2: Сховище 9-B");
        yield return ShowText("Кімната з кубічними модулями даних.");
        yield return ShowText("Алекс знаходить третій фрагмент коду, але раптом з’являється Кібер-Ворон — помічник батька, який тепер підключений до систем NeuraTech.");

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
