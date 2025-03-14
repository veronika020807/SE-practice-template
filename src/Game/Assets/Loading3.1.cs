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

    public AudioSource startSound; // Звук на початку головоломки
    public AudioSource correctAnswerSound; // Звук при правильній відповіді

    private int correctAnswer = 21; // Правильна відповідь
    private bool hasPlayedCorrectSound = false; // Флаг для контроля звука правильного ответа
    private bool hasAnsweredCorrectly = false; // Флаг, чтобы не допускать повторной проверки

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
        yield return ShowText("**Головоломка 2**");
        yield return ShowText("**Завдання:**");
        yield return ShowText("Число (А) = 3");
        yield return ShowText("Число (B) = Число (А) + 4");
        yield return ShowText("Ключ: Число (А) * Число(B)");
        yield return ShowText("**Питання: Яке значення має змінна \"Ключ\"?**");

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
            textDisplay.text = "**2 карта пам'яті знайдено!**";
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
