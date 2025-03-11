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
        new DialogueLine { Speaker = "AI voice", Content = "[Ідентифікація] Введіть пароль: \"Що залишається, коли зникають усі коди?\"" },

        new DialogueLine { Speaker = "Alex", Content = "(Задумливо)\nЦе ж цитата з щоденника батька... Він писав: \"Надія\"!" },

        new DialogueLine { Speaker = "Narrator", Content = "(Після введення пароля сервер видає другий фрагмент коду. На екрані з’являється нове повідомлення від батька.)" },

        new DialogueLine { Speaker = "Father's voice", Content = "\"Я пишаюся тобою, сину. Але обережно – NeuraTech ближче, ніж здається...\"" },

        new DialogueLine { Speaker = "Narrator", Content = "(Раптом лунає вибух. До лабораторії вриваються солдати NeuraTech на кібернетичних екзоскелетах.)" },

        new DialogueLine { Speaker = "Lexa", Content = "Треба тікати! Через аварійний хід!" }
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
            StartCoroutine(LoadNextScene()); // Перехід на наступну сцену
        }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Loading4"); // Завантаження наступної сцени
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowDialogue();
        }
    }
}
