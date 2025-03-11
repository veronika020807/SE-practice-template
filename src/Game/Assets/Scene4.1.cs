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
        new DialogueLine { Speaker = "Lexa", Content = "(Шепоче через комунікатор)\nТут кожен крок фіксується. Тримайся ближче до мене."},

        new DialogueLine { Speaker = "Narrator", Content = "(Вони проходять через сканери, використовуючи підроблені ідентифікатори. Раптом Лекса зупиняється біля голографічного інтерфейсу.)"},

        new DialogueLine { Speaker = "Lexa", Content = "Третій фрагмент у сховищі 9-B. Але доступ має лише головний інженер."},

        new DialogueLine { Speaker = "Alex", Content = "(Показує гаджет)\nЯ можу імітувати його сигнатуру. Батько навчив мене цьому трюку."}
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
            StartCoroutine(LoadNextScene()); // Перехід на наступну сцену
        }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Loading4.2"); // Завантаження наступної сцени
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowDialogue();
        }
    }
}
