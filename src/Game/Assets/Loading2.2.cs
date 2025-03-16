using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class IntroText2_2 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay; // Виведення тексту
    public TMP_InputField answerInput; // Поле для введення
    public Button buttonReload; // Кнопка повторення
    public float textSpeed = 0.1f; // Швидкість друкування тексту
    public string nextSceneName = "Loading3"; // Назва наступної сцени

    public AudioSource startSound; // Звук на початку головоломки
    public AudioSource correctAnswerSound; // Звук при правильній відповіді

    private int correctAnswer = 3; // Правильна відповідь
    private bool hasPlayedCorrectSound = false; // Флаг для звуку
    private bool hasAnsweredCorrectly = false; // Флаг для правильної відповіді

    void Start()
    {
        buttonReload.gameObject.SetActive(false);
        answerInput.gameObject.SetActive(false);
        answerInput.onSubmit.AddListener(delegate { CheckAnswer(); });

        // Встановлюємо зелений колір тексту
        textDisplay.color = new Color(0f, 1f, 0f);

        if (startSound != null) startSound.Play();

        StartCoroutine(DisplayTextSequence());
    }

    IEnumerator DisplayTextSequence()
    {
        yield return ShowText("**Головоломка 1**");
        yield return ShowText("**Завдання:**");
        yield return ShowText("Glitch");
        yield return ShowText("Glitch");
        yield return ShowText("Alex");
        yield return ShowText("Glitch");
        yield return ShowText("Glitch");
        yield return ShowText("Alex");
        yield return ShowText("Glitch");
        yield return ShowText("Alex");
        yield return ShowText("**Питання: Скільки разів вивелося ім'я Alex?**");

        answerInput.gameObject.SetActive(true);
    }

    IEnumerator ShowText(string message)
    {
        textDisplay.text = "C:\\> "; // Додаємо запрошення командного рядка
        foreach (char letter in message)
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
        textDisplay.text += " _"; // Імітація мигаючого курсора
        yield return new WaitForSeconds(1.5f);
    }

    public void CheckAnswer()
    {
        if (hasAnsweredCorrectly) return;

        int playerAnswer;
        bool isNumber = int.TryParse(answerInput.text, out playerAnswer);

        if (isNumber && playerAnswer == correctAnswer)
        {
            hasAnsweredCorrectly = true;
            textDisplay.text = "C:\\> **1 карта пам'яті знайдено!** _";
            buttonReload.gameObject.SetActive(false);
            answerInput.interactable = false;
            answerInput.onSubmit.RemoveAllListeners();

            if (correctAnswerSound != null && !hasPlayedCorrectSound)
            {
                hasPlayedCorrectSound = true;
                correctAnswerSound.Play();
                StartCoroutine(LoadNextScene(correctAnswerSound.clip.length));
            }
            else
            {
                StartCoroutine(LoadNextScene(0f));
            }
        }
        else
        {
            textDisplay.text = "C:\\> **Неправильна відповідь. Спробуйте ще раз!** _";
            buttonReload.gameObject.SetActive(true);
        }
    }

    public void RetryPuzzle()
    {
        answerInput.text = "";
        answerInput.gameObject.SetActive(false);
        buttonReload.gameObject.SetActive(false);
        hasPlayedCorrectSound = false;
        hasAnsweredCorrectly = false;
        StartCoroutine(DisplayTextSequence());
    }

    IEnumerator LoadNextScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextSceneName);
    }
}
