using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager2_2 : MonoBehaviour
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
        new DialogueLine { Speaker = "Gadget", Content = "[Сканування...]\n[Знайдено зашифрований файл: \"Проєкт Прометей\"]"},
        new DialogueLine { Speaker = "Alex", Content = "(З хвилюванням)\n\"Проєкт Прометей\"... Батько згадував його!\n" +
            "(З’являється головоломка: гравець має знайти ключ у фрагментах коду батька, розкиданих у файлах.)" },
        new DialogueLine { Speaker = "Alex", Content = "(Під час розв’язання)\nВін завжди говорив: \"Код – це свобода\".\n" +
            "(Після успіху файл розшифровується. На екрані – голосове повідомлення батька.)"},
         new DialogueLine { Speaker = "Father's voice", Content = "\"Алексе... якщо ти це чуєш, значить, я не встиг.\n\"Прометей\" – це ключ до системи NeuraTech.\nЗбери всі частини, перш ніж вони їх знайдуть...\""},
         new DialogueLine { Speaker = "Father's voice", Content = "(Раптом лунає сирена. Алекс виймає флешку з даними.)"},
         new DialogueLine { Speaker = "Alex", Content = "(Панікує)\nЯ ж нічого не чіпав! Хіба що...\n"},
         new DialogueLine { Speaker = "Alex", Content = "Трясця! Мене ввели в пастку...\n(Він тікає, стискаючи флешку. У тіні маячить силует дрона з логотипом NeuraTech.)"}
    };

    void Start()
    {
        // Скрываем всех персонажей в начале сцены
        Alex.gameObject.SetActive(false);
        Frame.gameObject.SetActive(true);
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
            }

            else if(dialogue[dialogueIndex].Speaker == "Father's voice")
            {
                Alex.gameObject.SetActive(false);
                Frame.gameObject.SetActive(true);
            }

            else
            {
                // Появляется диалоговое окно и персонажи
                Frame.gameObject.SetActive(true);

                if (dialogue[dialogueIndex].Speaker == "Alex")
                {
                    Alex.gameObject.SetActive(true);
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
