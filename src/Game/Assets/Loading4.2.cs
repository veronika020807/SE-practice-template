using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class IntroText4_2 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay; // ��������� ������
    public TMP_InputField answerInput; // ���� ��� ��������
    public Button buttonReload; // ������ ����������
    public float textSpeed = 0.1f; // �������� ���������� ������
    public string nextSceneName = "Loading 4.3"; // ����� �������� �����

    public AudioSource startSound; // ���� �� ������� �����������
    public AudioSource correctAnswerSound; // ���� ��� ��������� ������

    private int correctAnswer = 1; // ��������� �������
    private bool hasPlayedCorrectSound = false; // ����, ��� ���� ���� ����� ���� ���
    private bool hasAnsweredCorrectly = false; // ����, ��� �������� ���������� ��������

    void Start()
    {
        buttonReload.gameObject.SetActive(false);
        answerInput.gameObject.SetActive(false);

        answerInput.onSubmit.RemoveAllListeners();
        answerInput.onSubmit.AddListener(delegate { CheckAnswer(); });

        if (startSound != null)
        {
            startSound.Play(); // ������������� ���� � ������ �����������
        }

        StartCoroutine(DisplayTextSequence());
    }

    IEnumerator DisplayTextSequence()
    {
        yield return ShowText("**����������� 3**");
        yield return ShowText("**��������:**");
        yield return ShowText("���������� = \"ó���\"");
        yield return ShowText("���� (���������� == \"����\"):");
        yield return ShowText("������ = \"������\"");
        yield return ShowText("������:");
        yield return ShowText("������ = \"���������\"");
        yield return ShowText("ó��� = 0");
        yield return ShowText("���� = 1");
        yield return ShowText("**�������: �� ������� ������, ���� �������� ������ ������?**");

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
        if (hasAnsweredCorrectly) return; // ��������� ��������� ������������

        int playerAnswer;
        bool isNumber = int.TryParse(answerInput.text, out playerAnswer);

        if (isNumber && playerAnswer == correctAnswer)
        {
            hasAnsweredCorrectly = true;
            textDisplay.text = "**3 ����� ���'�� ��������!**";
            buttonReload.gameObject.SetActive(false);

            answerInput.interactable = false;
            answerInput.gameObject.SetActive(false);
            answerInput.onSubmit.RemoveAllListeners();

            if (correctAnswerSound != null && !hasPlayedCorrectSound)
            {
                hasPlayedCorrectSound = true;
                correctAnswerSound.Play();
                StartCoroutine(LoadNextScene(correctAnswerSound.clip.length)); // ��� ��������� ����� ����� ������
            }
            else
            {
                StartCoroutine(LoadNextScene(0f));
            }
        }
        else
        {
            textDisplay.text = "**����������� �������. ��������� �� ���!**";
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
