using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class IntroText4_2 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay; // Виведення тексту
    public TMP_InputField answerInput; // Поле для введення
    public Button buttonReload; // Кнопка повторення
    public float textSpeed = 0.1f; // Швидкість друкування тексту
    public string nextSceneName = "Loading 4.3"; // Назва наступної сцени

    public AudioSource startSound; // Звук на початку головоломки
    public AudioSource correctAnswerSound; // Звук при правильній відповіді

    private int correctAnswer = 1; // Правильна відповідь
    private bool hasPlayedCorrectSound = false; // Флаг, щоб звук грав тільки один раз
    private bool hasAnsweredCorrectly = false; // Флаг, щоб запобігти повторному введенню

    void Start()
    {
        buttonReload.gameObject.SetActive(false);
        answerInput.gameObject.SetActive(false);

        answerInput.onSubmit.RemoveAllListeners();
        answerInput.onSubmit.AddListener(delegate { CheckAnswer(); });

        if (startSound != null)
        {
            startSound.Play(); // Воспроизводим звук в начале головоломки
        }

        StartCoroutine(DisplayTextSequence());
    }

    IEnumerator DisplayTextSequence()
    {
        yield return ShowText("**Головоломка 3**");
        yield return ShowText("**Завдання:**");
        yield return ShowText("Користувач = \"Гість\"");
        yield return ShowText("Якщо (Користувач == \"Адмін\"):");
        yield return ShowText("Доступ = \"повний\"");
        yield return ShowText("Інакше:");
        yield return ShowText("Доступ = \"обмежений\"");
        yield return ShowText("Гість = 0");
        yield return ShowText("Адмін = 1");
        yield return ShowText("**Питання: Що потрібно ввести, щоби отримати повний доступ?**");

        answerInput.gameObject.SetActive(true);
    }

    IEnumerator ShowText(string message)
    {
        textDisplay.text = "";
        foreach (char letter in message)
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
        yield return new WaitForSeconds(1.5f);
    }

    public void CheckAnswer()
    {
        if (hasAnsweredCorrectly) return; // Запрещаем повторное срабатывание

        int playerAnswer;
        bool isNumber = int.TryParse(answerInput.text, out playerAnswer);

        if (isNumber && playerAnswer == correctAnswer)
        {
            hasAnsweredCorrectly = true;
            textDisplay.text = "**3 карта пам'яті знайдено!**";
            buttonReload.gameObject.SetActive(false);

            answerInput.interactable = false;
            answerInput.gameObject.SetActive(false);
            answerInput.onSubmit.RemoveAllListeners();

            if (correctAnswerSound != null && !hasPlayedCorrectSound)
            {
                hasPlayedCorrectSound = true;
                correctAnswerSound.Play();
                StartCoroutine(LoadNextScene(correctAnswerSound.clip.length)); // Ждём окончания звука перед сценой
            }
            else
            {
                StartCoroutine(LoadNextScene(0f));
            }
        }
        else
        {
            textDisplay.text = "**Неправильна відповідь. Спробуйте ще раз!**";
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

        answerInput.interactable = true;
        answerInput.onSubmit.RemoveAllListeners();
        answerInput.onSubmit.AddListener(delegate { CheckAnswer(); });

        StartCoroutine(DisplayTextSequence());
    }

    IEnumerator LoadNextScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextSceneName);
    }
}
