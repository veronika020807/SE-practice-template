using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager1 : MonoBehaviour
{
    public Image Alex;
    public Image Glitch;
    public Image Frame;
    public TextMeshProUGUI NamePers;
    public TextMeshProUGUI Text;
    public AudioSource backgroundMusic; // ������ ����� ��� ������ ������

    private int dialogueIndex = 0;

    private class DialogueLine
    {
        public string Speaker;
        public string Content;
    }

    private DialogueLine[] dialogue = new DialogueLine[]
    {
        new DialogueLine { Speaker = "Alex", Content = "(���� �� ����)\n�� ���� ���, �� ���� ����� ����������...\n"},

        new DialogueLine { Speaker = "Narrator", Content = "(������ �'��������� �������� � ����.)"},

        new DialogueLine { Speaker = "Glitch", Content = "(���������� �������)\n�����, �����. �� ����� ������ ��� ����� ������?" },

        new DialogueLine { Speaker = "Alex", Content = "(г��� ����������)\n��� ��? �� �� ���� ��� �����?" },

        new DialogueLine { Speaker = "Glitch", Content = "³� ������� ��� ��������. ���, ��������� �� ������ �������.\n" +
            "����� - � ����� ������������, �� �� ������ ��������."},

        new DialogueLine { Speaker = "Alex", Content = "(������ ������)\n���� � ������� ��� �����?" },

        new DialogueLine { Speaker = "Glitch", Content = "�� �� ������ ����� �������� ������. �� � �� �����,\n" +
            "��� ���� ������ �������� �����������?\n"},

        new DialogueLine { Speaker = "Narrator", Content = "(�� ������ ������� ���� �� ��������, ���� ����� ����� � �� ��������� ���� ���� ������.)"},

        new DialogueLine { Speaker = "Alex", Content = "(г����)\n������. � ���.\n"},

        new DialogueLine { Speaker = "Narrator", Content = "(����� ���� ����������� ������ ������, ���� ������ ����� �� �����, � �������� �� ��������.)"},
    };

    void Start()
    {
        Glitch.gameObject.SetActive(false); // ������ �'��������� ����� �����
        Frame.gameObject.SetActive(true);
        Text.alignment = TextAlignmentOptions.Justified; // ����������� ������ �� ������

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
                Glitch.gameObject.SetActive(false);
            }

            else if (dialogue[dialogueIndex].Speaker == "Narrator")
            {
                Alex.gameObject.SetActive(false);
                Glitch.gameObject.SetActive(false);
            }

            else
            {
                Alex.gameObject.SetActive(false);
                Glitch.gameObject.SetActive(true);
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
        yield return new WaitForSeconds(1f); // �������� �������� ����� ���������

        if (backgroundMusic != null)
        {
            backgroundMusic.Stop(); // �������� ������ ����� ����� �����
        }

        SceneManager.LoadScene("Loading2.1"); // ������������ �������� �����
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // ������� �� ������
        {
            ShowDialogue();
        }
    }
}
