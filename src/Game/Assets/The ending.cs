using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CreditsRoll : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public float scrollSpeed = 50f; // �������� ������� ������
    public float endDelay = 3f; // �������� ����� ������ �����
    public string nextSceneName = "MainMenu"; // ����� �������� �����

    void Start()
    {
        // ������������� ��������� ��������� ������ ����� ������
        RectTransform textTransform = textDisplay.GetComponent<RectTransform>();
        textTransform.anchoredPosition = new Vector2(0, -Screen.height / 2);

        StartCoroutine(RollCredits(textTransform));
    }

    IEnumerator RollCredits(RectTransform textTransform)
    {
        textDisplay.text = "���Ӫ�� �� ���!\n\n"
                         + "�������� ��������:\n"
                         + "������� ��������\n\n"
                         + "�������� ��������:\n"
                         + "��������� ������\n\n"
                         + "����������:\n"
                         + "������ ���������\n"
                         + "������� ϳ����\n\n"
                         + "�������������:\n"
                         + "��������� ���'�������\n"
                         + "������ ��������\n\n"
                         + "UX-����������:\n"
                         + "����� �������\n"
                         + "���� �������\n\n"
                         + "���������� � �����������:\n"
                         + "����� ������\n"
                         + "��� ������\n\n"
                         + "���������� ������:\n"
                         + "Unity Community\n\n"
                         + "� 2025 �� ����� �������.";

        // ��������� ����� �����, ���� �� �� ������ �� �����
        while (textTransform.anchoredPosition.y < Screen.height + 500)
        {
            textTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;
            yield return null;
        }

        // ���� ����� ������ �����
        yield return new WaitForSeconds(endDelay);
        SceneManager.LoadScene(nextSceneName);
    }
}
