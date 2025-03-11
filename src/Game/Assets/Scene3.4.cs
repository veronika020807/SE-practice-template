using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager3_4 : MonoBehaviour
{
    public Image Alex;
    public Image Lexa;
    public Image Frame;
    public TextMeshProUGUI NamePers;
    public TextMeshProUGUI Text;

    private int dialogueIndex = 0;

    private class DialogueLine
    {
        public string Speaker;
        public string Content;
    }

    private DialogueLine[] dialogue = new DialogueLine[]
    {
        new DialogueLine { Speaker = "AI voice", Content = "[�������������] ������ ������: \"�� ����������, ���� �������� �� ����?\"" },

        new DialogueLine { Speaker = "Alex", Content = "(���������)\n�� � ������ � ��������� ������... ³� �����: \"����\"!" },

        new DialogueLine { Speaker = "Narrator", Content = "(ϳ��� �������� ������ ������ ���� ������ �������� ����. �� ����� ���������� ���� ����������� �� ������.)" },

        new DialogueLine { Speaker = "Father's voice", Content = "\"� ������� �����, ����. ��� �������� � NeuraTech ������, �� �������...\"" },

        new DialogueLine { Speaker = "Narrator", Content = "(������ ���� �����. �� ��������� ���������� ������� NeuraTech �� ������������ ������������.)" },

        new DialogueLine { Speaker = "Lexa", Content = "����� �����! ����� �������� ���!" }
    };

    void Start()
    {
        Lexa.gameObject.SetActive(false);
        Frame.gameObject.SetActive(true);
        Text.alignment = TextAlignmentOptions.Justified;
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
            StartCoroutine(LoadNextScene()); // ������� �� �������� �����
        }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Loading4"); // ������������ �������� �����
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowDialogue();
        }
    }
}
