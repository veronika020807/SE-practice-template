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


    private int dialogueIndex = 0;

    private class DialogueLine
    {
        public string Speaker;
        public string Content;
    }

    private DialogueLine[] dialogue = new DialogueLine[]
    {
        new DialogueLine { Speaker = "Gadget", Content = "[Сканування...]\n[Знайдено зашифрований файл: \"Проєкт Прометей\"]"},
        new DialogueLine { Speaker = "Alex", Content = "(З хвилюванням)\n\"Проєкт Прометей\"... Батько згадував його!\n"},
        new DialogueLine { Speaker = "Narrator", Content = "(Головоломка, яку розв'язав гравець, це код батька у розкиданих файлах)"},
        new DialogueLine { Speaker = "Alex", Content = "Він завжди говорив: \"Код – це свобода\".\n"},
        new DialogueLine { Speaker = "Narrator", Content = "(На екрані – голосове повідомлення батька.)"},
        new DialogueLine { Speaker = "Father's voice", Content = "\"Алексе... якщо ти це чуєш, значить, я не встиг.\n\"Прометей\" – це ключ до системи NeuraTech.\nЗбери всі частини, перш ніж вони їх знайдуть...\""},
        new DialogueLine { Speaker = "Narrator", Content = "(Раптом лунає сирена. Алекс виймає флешку з даними.)"},
        new DialogueLine { Speaker = "Alex", Content = "(Панікує)\nЯ ж нічого не чіпав! Хіба що...\n"},
        new DialogueLine { Speaker = "Narrator", Content = "(Він дивиться на гаджет: екран блимає червоним – хтось стежив за підключенням.)"},
        new DialogueLine { Speaker = "Alex", Content = "Трясця! Мене ввели в пастку..."},
        new DialogueLine { Speaker = "Narrator", Content = "(Він тікає, стискаючи флешку. У тіні маячить силует дрона з логотипом NeuraTech.)"}
    };

    void Start()
    {
        // Скрываем всех персонажей в начале сцены
        Alex.gameObject.SetActive(false);
        Frame.gameObject.SetActive(true);
        Father.gameObject.SetActive(false); // Hide Father's photo initially
        Text.alignment = TextAlignmentOptions.Justified; // Выровнять текст по ширине
        ShowDialogue();
    }

    public void ShowDialogue()
    {
        if (dialogueIndex < dialogue.Length)
        {
            NamePers.text = dialogue[dialogueIndex].Speaker;
            Text.text = dialogue[dialogueIndex].Content;

            if (dialogue[dialogueIndex].Speaker == "Gadget")
            {
                // Во время диалога гаджета ничего не показываем
                Alex.gameObject.SetActive(false);
                Frame.gameObject.SetActive(true);
                Father.gameObject.SetActive(false); // Hide Father's photo during Gadget's dialogue
            }
            else if (dialogue[dialogueIndex].Speaker == "Narrator")
            {
                Alex.gameObject.SetActive(false);
                Frame.gameObject.SetActive(true);
                Father.gameObject.SetActive(false); // Hide Father's photo during Narrator's dialogue
            }
            else if (dialogue[dialogueIndex].Speaker == "Father's voice")
            {
                // Show Father's photo when he speaks
                Alex.gameObject.SetActive(false);
                Frame.gameObject.SetActive(true);
                Father.gameObject.SetActive(true); // Show Father's photo
            }
            else
            {
                // Появляется диалоговое окно и персонажи
                Frame.gameObject.SetActive(true);

                if (dialogue[dialogueIndex].Speaker == "Alex")
                {
                    Alex.gameObject.SetActive(true);
                    Father.gameObject.SetActive(false); // Hide Father's photo during Alex's dialogue
                }
            }

            dialogueIndex++;
        }
        else
        {
            StartCoroutine(LoadNextScene()); // Переход к следующей сцене
        }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1f); // Задержка перед сменой сцены
        SceneManager.LoadScene("Chapter 2/Loading3");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Переход по диалогу
        {
            ShowDialogue();
        }
    }
}
