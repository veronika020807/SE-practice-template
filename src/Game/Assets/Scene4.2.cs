using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager4_2 : MonoBehaviour
{
    public Image Alex;
    public Image Lexa;
    public Image Cyber_​​Raven;
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
        new DialogueLine { Speaker = "Cyber ​​Raven", Content = "(Спотворений голос)\nАлекс... Вони мене перепрограмували. Твій батько живий. Але він у пастці."},

        new DialogueLine { Speaker = "Alex", Content = "(Збентежено)\nДе він? Як його звільнити?"},

        new DialogueLine { Speaker = "Cyber ​​Raven", Content = "Останній фрагмент у Центральному ядрі. Але це самогубство..."},

        new DialogueLine { Speaker = "Narrator", Content = "(Лекса перериває зв’язок, вимкнучи гаджет.)"},

        new DialogueLine { Speaker = "Lexa", Content = "Це може бути пастка. NeuraTech маніпулює тобою."},

        new DialogueLine { Speaker = "Alex", Content = "(Рішуче)\nЯ йду. Зі мною чи без?"},
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
                Cyber_​​Raven.gameObject.SetActive(false);
            }

            else if (dialogue[dialogueIndex].Speaker == "Narrator")
            {
                Cyber_​​Raven.gameObject.SetActive(false);
                Lexa.gameObject.SetActive(false);
                Alex.gameObject.SetActive(false);
                Frame.gameObject.SetActive(true);
            }

            else if (dialogue[dialogueIndex].Speaker == "Cyber ​​Raven")
            {
                Cyber_​​Raven.gameObject.SetActive(true);
                Lexa.gameObject.SetActive(false);
                Alex.gameObject.SetActive(false);
                Frame.gameObject.SetActive(true);
            }

            else if (dialogue[dialogueIndex].Speaker == "Lexa")
            {
                Alex.gameObject.SetActive(false);
                Cyber_​​Raven.gameObject.SetActive(false);
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
        SceneManager.LoadScene("Loading4.4"); // Завантаження наступної сцени
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowDialogue();
        }
    }
}
