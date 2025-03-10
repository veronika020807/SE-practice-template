using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager2 : MonoBehaviour
{
    public Image Alex;
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
        new DialogueLine { Speaker = "Alex", Content = "Нейрон-Сіті, 2147 рік. Алекс пробирається до старого корпусу університету, обходячи камери.\n" +
            "Він залазить у вентиляційний шахту, як його навчив батько." },

        new DialogueLine { Speaker = "Alex", Content = "(Шепоче)\nАрхів має бути на третьому рівні...\n" +
            "(Алекс потрапляє у приміщення зі старими серверами. На стіні – графіті з символом руху \"Вільний Код\". Алекс підключає гаджет до терміналу.)" },

    };

    void Start()
    {
        Frame.gameObject.SetActive(true);
        Text.alignment = TextAlignmentOptions.Justified; // Вирівнювання тексту по ширині
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
            }
            else
            {
                Alex.gameObject.SetActive(false);
            }

            dialogueIndex++;
        }
        else
        {
            StartCoroutine(LoadNextScene()); // Переходить до наступної сцени
        }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1f); // Невелика затримка перед переходом
        SceneManager.LoadScene("Loading3"); // Завантаження наступної сцени
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Перехід по діалогу
        {
            ShowDialogue();
        }
    }
}