using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager4_1 : MonoBehaviour
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
        new DialogueLine { Speaker = "Lexa", Content = "(������ ����� ����������)\n��� ����� ���� ���������. �������� ������ �� ����."},

        new DialogueLine { Speaker = "Narrator", Content = "(���� ��������� ����� �������, �������������� �������� ��������������. ������ ����� ����������� ��� �������������� ����������.)"},

        new DialogueLine { Speaker = "Lexa", Content = "����� �������� � ������� 9-B. ��� ������ �� ���� �������� �������."},

        new DialogueLine { Speaker = "Alex", Content = "(������ ������)\n� ���� �������� ���� ���������. ������ ������ ���� ����� �����."}
    };

    void Start()
    {
        Lexa.gameObject.SetActive(true);
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

            else if (dialogue[dialogueIndex].Speaker == "Narrator")
            {
                Lexa.gameObject.SetActive(false);
                Alex.gameObject.SetActive(false);
                Frame.gameObject.SetActive(true);
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
        SceneManager.LoadScene("Loading4.2"); // ������������ �������� �����
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowDialogue();
        }
    }
}
