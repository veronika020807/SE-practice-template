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
    private bool hasPlayedCorrectSound = false; // Флаг для відстеження відтворення звуку
    private bool hasAnsweredCorrectly = false; // Флаг, щоб не дозволяти повторну відповідь

    void Start()
    {
        buttonReload.gameObject.SetActive(false); // Ховаємо кнопку повтору
        answerInput.gameObject.SetActive(false); // Ховаємо поле для введення
        answerInput.onSubmit.AddListener(delegate { CheckAnswer(); }); // Додаємо обробник для введення

        if (startSound != null)
        {
            startSound.Play(); // Відтворюємо звук на початку головоломки
        }

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
        if (hasAnsweredCorrectly) return; // Запрещаем повторный вызов

        int playerAnswer;
        bool isNumber = int.TryParse(answerInput.text, out playerAnswer);

        if (isNumber && playerAnswer == correctAnswer)
        {
            hasAnsweredCorrectly = true; // Устанавливаем флаг, что ответ верный
            textDisplay.text = "**1 карта пам'яті знайдено!**";
            buttonReload.gameObject.SetActive(false);

            // Отключаем поле ввода и удаляем обработчик ввода
            answerInput.interactable = false;
            answerInput.onSubmit.RemoveAllListeners(); // Удаляем обработчик, чтобы больше не срабатывал

            if (correctAnswerSound != null && !hasPlayedCorrectSound)
            {
                hasPlayedCorrectSound = true; // Фиксируем, что звук уже проигран
                correctAnswerSound.Play();
                StartCoroutine(LoadNextScene(correctAnswerSound.clip.length)); // Ждём окончания звука перед сценой
            }
            else
            {
                StartCoroutine(LoadNextScene(0f)); // Если звука нет, сразу переходим
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
        answerInput.text = ""; // Очистити поле
        answerInput.gameObject.SetActive(false); // Сховати поле для введення
        buttonReload.gameObject.SetActive(false); // Сховати кнопку
        hasPlayedCorrectSound = false; // Скидаємо флаг для повторного відтворення звуку
        hasAnsweredCorrectly = false; // Скидаємо флаг для дозволу нової відповіді
        StartCoroutine(DisplayTextSequence()); // Повторно запустити текстову послідовність
    }

    IEnumerator LoadNextScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextSceneName);
    }
}
