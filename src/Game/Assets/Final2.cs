using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Final2 : MonoBehaviour
{
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
        new DialogueLine { Speaker = "Narrator", Content = "����� �ᒺ������� � ز, ������ \"��������\". ̳��� �����������������: �������㳿 ����� ������� �����. ��� ����� ������ ���, ����������� � �����������. ����� ����� ���� ���������, ��������� ���� ����� �������.) ����� ������: � �� ���� ����... ��� ���� ����."}
    };

    void Start()
    {
        Frame.gameObject.SetActive(true);
        Text.alignment = TextAlignmentOptions.Justified; // ����������� ������ �� �����

        // ������ ������ ������
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

            if (dialogue[dialogueIndex].Speaker == "Narrator")
            {
                Frame.gameObject.SetActive(true);
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

        // ������� ������ ������ ����� ���������
        if (backgroundMusic != null)
        {
            backgroundMusic.Stop();
        }

        SceneManager.LoadScene("Loading5.3"); // ������������ �������� �����
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // ������� �� ������
        {
            ShowDialogue();
        }
    }
}
