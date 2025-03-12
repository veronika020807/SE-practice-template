using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class IntroText3_1 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay; // ��������� ������
    public TMP_InputField answerInput; // ���� ��� ��������
    public Button buttonReload; // ������ ����������
    public float textSpeed = 0.1f; // �������� ���������� ������
    public string nextSceneName = "Scene3.1"; // ����� �������� �����

    private int correctAnswer = 21; // ��������� �������

    void Start()
    {
        buttonReload.gameObject.SetActive(false); // ������ ������ �������
        answerInput.gameObject.SetActive(false); // ������ ���� ��� ��������
        answerInput.onSubmit.AddListener(delegate { CheckAnswer(); }); // ������ �������� ��� ��������
        StartCoroutine(DisplayTextSequence());
    }

    IEnumerator DisplayTextSequence()
    {
        yield return ShowText("**����������� 2**");
        yield return ShowText("**��������:**");
        yield return ShowText("����� (�) = 3");
        yield return ShowText("����� (B) = ����� (�) + 4");
        yield return ShowText("����: ����� (�) * �����(B)");
        yield return ShowText("**�������: ��� �������� �� ����� \"����\"?**");

        // �������� ���� ��� �������� ���� ���������� �������� �����������
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
            textDisplay.text = "**2 ����� ���'�� ��������!**";
            buttonReload.gameObject.SetActive(false);
            StartCoroutine(LoadNextScene());
        }
        else
        {
            textDisplay.text = "**����������� �������. ��������� �� ���!**";
            buttonReload.gameObject.SetActive(true);
        }
    }

    public void RetryPuzzle()
    {
        answerInput.text = ""; // �������� ����
        answerInput.gameObject.SetActive(false); // ������� ���� ��� ��������
        buttonReload.gameObject.SetActive(false); // ������� ������
        StartCoroutine(DisplayTextSequence()); // �������� ��������� �������� �����������
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(nextSceneName);
    }
}
