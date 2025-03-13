using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Final1 : MonoBehaviour
{
    public Image Frame;
    public Image Father;
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
        new DialogueLine { Speaker = "Narrator", Content = "(Алекс знищує ядро. NeuraTech втрачає владу, місто освітлюється справжнім сонцем. Батько, слабкий, але живий, обіймає сина. Лекса і Макс організовують новий рух — \"Кодекс Людей\"."},

        new DialogueLine { Speaker = "Father's last words", Content = "Ти звільнив не лише мене... але й мільйони душ."}
    };

    void Start()
    {
        Father.gameObject.SetActive(false);
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

            if (dialogue[dialogueIndex].Speaker == "Narrator")
            {
                Father.gameObject.SetActive(false);
                Frame.gameObject.SetActive(true);
            }

            else if (dialogue[dialogueIndex].Speaker == "Father's last words")
            {
                Father.gameObject.SetActive(true);
                Frame.gameObject.SetActive(true);
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
        SceneManager.LoadScene("The ending"); // Завантаження наступної сцени
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Перехід по діалогу
        {
            ShowDialogue();
        }
    }
}
