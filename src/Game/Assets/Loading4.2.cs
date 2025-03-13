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

    private int correctAnswer = 1; // Правильна відповідь

    void Start()
    {
        buttonReload.gameObject.SetActive(false); // Ховаємо кнопку повтору
        answerInput.gameObject.SetActive(false); // Ховаємо поле для введення
        answerInput.onSubmit.AddListener(delegate { CheckAnswer(); }); // Додаємо обробник для введення
        StartCoroutine(DisplayTextSequence());
    }

    IEnumerator DisplayTextSequence()
    {
        yield return ShowText("**Головоломка 3**");
        yield return ShowText("**Завдання:**");
        yield return ShowText("Користувач = \"Гість\"");
        yield return ShowText("Якщо (Користувач == \"Адмін\"):");
        yield return ShowText("Доступ = \"повний\"");
        yield return ShowText("інакше:");
        yield return ShowText("Доступ = \"обмежений\"");
        yield return ShowText("Гість = 0");
        yield return ShowText("Адмін = 1");
        yield return ShowText("**Питання: Що потрібно ввести, щоби отримати повний доступ?**");

        // Показуємо поле для введення після завершення текстової послідовності
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
        int playerAnswer;
        bool isNumber = int.TryParse(answerInput.text, out playerAnswer);

        if (isNumber && playerAnswer == correctAnswer)
        {
            textDisplay.text = "**3 карта пам'яті знайдено!";
            buttonReload.gameObject.SetActive(false);
            StartCoroutine(LoadNextScene());
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
        StartCoroutine(DisplayTextSequence()); // Повторно запустити текстову послідовність
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(nextSceneName);
    }
}
