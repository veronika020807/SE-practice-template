using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager4_3 : MonoBehaviour
{
    public Image Alex;
    public Image Father;
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
        new DialogueLine { Speaker = "AI NeuraTech", Content = "Віддай код, і я поверну твого батька. Відмовишся — він загине."},

        new DialogueLine { Speaker = "Alex", Content = "(Шоковано)\nЩо?.."},

        new DialogueLine { Speaker = "Father", Content = "Я вклав у тебе ключ. Твоя ДНК — останній фрагмент. NeuraTech ніколи не здогадається..."},

        new DialogueLine { Speaker = "Narrator", Content = "(Сигнал обривається. Лекса тягне Алекса до виходу, але їх оточують дрони.)"},

        new DialogueLine { Speaker = "Lexa", Content = "Треба тікати! Зараз!"}
    };

    void Start()
    {
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
                Father.gameObject.SetActive(false);
                Frame.gameObject.SetActive(true);
            }

            else if (dialogue[dialogueIndex].Speaker == "Narrator")
            {
                Lexa.gameObject.SetActive(false);
                Father.gameObject.SetActive(false);
                Alex.gameObject.SetActive(false);
                Frame.gameObject.SetActive(true);
            }

            else if (dialogue[dialogueIndex].Speaker == "AI NeuraTech")
            {
                Lexa.gameObject.SetActive(false);
                Father.gameObject.SetActive(false);
                Alex.gameObject.SetActive(false);
                Frame.gameObject.SetActive(true);
            }

            else if (dialogue[dialogueIndex].Speaker == "Father")
            {
                Lexa.gameObject.SetActive(false);
                Father.gameObject.SetActive(true);
                Alex.gameObject.SetActive(false);
                Frame.gameObject.SetActive(true);
            }

            else if (dialogue[dialogueIndex].Speaker == "Lexa")
            {
                Lexa.gameObject.SetActive(true);
                Father.gameObject.SetActive(false);
                Alex.gameObject.SetActive(false);
                Frame.gameObject.SetActive(true);
            }

            else
            {
                Alex.gameObject.SetActive(false);
                Father.gameObject.SetActive(false);
            }

            dialogueIndex++;
        }
        else
        {
            StartCoroutine(LoadNextScene()); // Перехід на наступну сцену
        }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Loading5.1"); // Завантаження наступної сцени
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowDialogue();
        }
    }
}
