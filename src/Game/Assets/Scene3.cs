using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager3 : MonoBehaviour
{
    public Image Alex;
    public Image Lexa;
    public Image Frame;
    public TextMeshProUGUI NamePers;
    public TextMeshProUGUI Text;
    public AudioSource backgroundMusic; // ������ ������

    private int dialogueIndex = 0;

    private class DialogueLine
    {
        public string Speaker;
        public string Content;
    }

    private DialogueLine[] dialogue = new DialogueLine[]
    {
        new DialogueLine { Speaker = "Lexa", Content = "(��������)\nNeuraTech ��� ���, �� �� ���������� �� ������. ��� ����� �������� ����� ���. " +
            "��� � ��� � �������� � ��� ����� ������." },

        new DialogueLine { Speaker = "Alex", Content = "(�������� ������)\n��� ���� ������ ��������. �� ������ ����?" },

        new DialogueLine { Speaker = "Lexa", Content = "(������ �� ��������)\n����� �������� ������ ���������� ����������. ��� �� ����� ���������� � ��������� �����������. " +
            "������� ����������� ����� �� ���������." },

        new DialogueLine { Speaker = "Narrator", Content = "(����� ������� ������ �� �������������� ���������. ǒ��������� �����������.)" }
    };

    void Start()
    {
        Lexa.gameObject.SetActive(false);
        Frame.gameObject.SetActive(true);
        Text.alignment = TextAlignmentOptions.Justified;

        if (backgroundMusic != null)
        {
            backgroundMusic.loop = true; // ���������� ������
            backgroundMusic.Play();
        }

        ShowDialogue();
    }

    public void ShowDialogue()
    {
        if (dialogueIndex < dialogue.Length)
        {
            NamePers.text = dialogue[dialogueIndex].Speaker;
            Text.text = dialogue[dialogueIndex].Content;

            if (dialogue[dialogueIndex].Speaker == "Alex")
            {
                Alex.gameObject.SetActive(true);
                Lexa.gameObject.SetActive(false);
            }
            else if (dialogue[dialogueIndex].Speaker == "Lexa")
            {
                Alex.gameObject.SetActive(false);
                Lexa.gameObject.SetActive(true);
            }
            else
            {
                Alex.gameObject.SetActive(false);
                Lexa.gameObject.SetActive(false);
            }

            dialogueIndex++;
        }
        else
        {
            StartCoroutine(LoadNextScene()); // ���������� �� �������� �����
        }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1f);

        if (backgroundMusic != null)
        {
            backgroundMusic.Stop(); // �������� ������ ����� ��������� �� ���� �����
        }

        SceneManager.LoadScene("Loading3.1"); // ������������ �������� �����
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowDialogue();
        }
    }
}
