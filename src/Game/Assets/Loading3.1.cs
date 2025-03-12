using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class IntroText3_1 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay; // Виведення тексту
    public TMP_InputField answerInput; // Поле для введення
    public Button buttonReload; // Кнопка повторення
    public float textSpeed = 0.1f; // Швидкість друкування тексту
    public string nextSceneName = "Scene3.1"; // Назва наступної сцени

    private int correctAnswer = 21; // Правильна відповідь

    void Start()
    {
        buttonReload.gameObject.SetActive(false); // Ховаємо кнопку повтору
        answerInput.gameObject.SetActive(false); // Ховаємо поле для введення
        answerInput.onSubmit.AddListener(delegate { CheckAnswer(); }); // Додаємо обробник для введення
        StartCoroutine(DisplayTextSequence());
    }

    IEnumerator DisplayTextSequence()
    {
        yield return ShowText("**Головоломка 2**");
        yield return ShowText("**Завдання:**");
        yield return ShowText("Число (А) = 3");
        yield return ShowText("Число (B) = Число (А) + 4");
        yield return ShowText("Ключ: Число (А) * Число(B)");
        yield return ShowText("**Питання: Яке значення має змінна \"Ключ\"?**");

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
            textDisplay.text = "**2 карта пам'яті знайдено!**";
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
