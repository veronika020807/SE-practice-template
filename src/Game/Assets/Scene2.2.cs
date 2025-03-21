using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager2_2 : MonoBehaviour
{
    public Image Alex;
    public Image Frame;
    public Image Father;
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
        new DialogueLine { Speaker = "Gadget", Content = "[����������...]\n[�������� ������������ ����: \"����� ��������\"]"},
        new DialogueLine { Speaker = "Alex", Content = "(� �����������)\n\"����� ��������\"... ������ �������� ����!\n"},
        new DialogueLine { Speaker = "Narrator", Content = "(�����������, ��� ����'���� �������, �� ��� ������ � ���������� ������)"},
        new DialogueLine { Speaker = "Alex", Content = "³� ������ �������: \"��� � �� �������\".\n"},
        new DialogueLine { Speaker = "Narrator", Content = "(�� ������ � �������� ����������� ������.)"},
        new DialogueLine { Speaker = "Father's voice", Content = "\"������... ���� �� �� ���, �������, � �� �����.\n\"��������\" � �� ���� �� ������� NeuraTech.\n����� �� �������, ���� ��� ���� �� ��������...\""},
        new DialogueLine { Speaker = "Narrator", Content = "(������ ���� ������. ����� ����� ������ � ������.)"},
        new DialogueLine { Speaker = "Alex", Content = "(������)\n� � ������ �� �����! ճ�� ��...\n"},
        new DialogueLine { Speaker = "Narrator", Content = "(³� �������� �� ������: ����� ����� �������� � ����� ������ �� �����������.)"},
        new DialogueLine { Speaker = "Alex", Content = "������! ���� ����� � ������..."},
        new DialogueLine { Speaker = "Narrator", Content = "(³� ���, ��������� ������. � ��� ������� ������ ����� � ��������� NeuraTech.)"}
    };

    void Start()
    {
        Alex.gameObject.SetActive(false);
        Frame.gameObject.SetActive(true);
        Father.gameObject.SetActive(false); // ������ ���� ������

        if (backgroundMusic != null)
        {
            backgroundMusic.loop = true; // ���������� ������
            backgroundMusic.Play();
        }

        Text.alignment = TextAlignmentOptions.Justified;
        ShowDialogue();
    }

    public void ShowDialogue()
    {
        if (dialogueIndex < dialogue.Length)
        {
            NamePers.text = dialogue[dialogueIndex].Speaker;
            Text.text = dialogue[dialogueIndex].Content;

            if (dialogue[dialogueIndex].Speaker == "Gadget" || dialogue[dialogueIndex].Speaker == "Narrator")
            {
                Alex.gameObject.SetActive(false);
                Father.gameObject.SetActive(false);
                Frame.gameObject.SetActive(true);
            }
            else if (dialogue[dialogueIndex].Speaker == "Father's voice")
            {
                Alex.gameObject.SetActive(false);
                Frame.gameObject.SetActive(true);
                Father.gameObject.SetActive(true);
            }
            else if (dialogue[dialogueIndex].Speaker == "Alex")
            {
                Alex.gameObject.SetActive(true);
                Father.gameObject.SetActive(false);
                Frame.gameObject.SetActive(true);
            }

            dialogueIndex++;
        }
        else
        {
            StartCoroutine(LoadNextScene());
        }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1f);

        if (backgroundMusic != null)
        {
            backgroundMusic.Stop(); // �������� ������ ����� ��������� �� ���� �����
        }

        SceneManager.LoadScene("Chapter 2/Loading3");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowDialogue();
        }
    }
}
