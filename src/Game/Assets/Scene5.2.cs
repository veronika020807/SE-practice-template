using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager5_2 : MonoBehaviour
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
        new DialogueLine { Speaker = "Lexa", Content = "(Тримає гаджет)\nЯ відключу зовнішні сенсори, але в мене лише 5 хвилин. Ти мусиш знайти спосіб витягти його!"},

        new DialogueLine { Speaker = "Alex", Content = "(Підходить до кріокамери)\nТату... Я знайшов усі фрагменти. Ти обіцяв пояснити..."},

        new DialogueLine { Speaker = "The voice of AI", Content = "[Попередження] Система \"Прометей\" активована. Введіть фінальний код для завершення протоколу."},

        new DialogueLine { Speaker = "Father", Content = "(Ледь чутно через інтерфейс)\nКод... це ти, сину. Твоя ДНК — ключ."},

        new DialogueLine { Speaker = "Alex", Content = "(Зрозумівши)\nТак! Він закодував відповідь у моїй крові…"},

        new DialogueLine { Speaker = "Narrator", Content = "(Алекс сканує свою долоню, щоб отримати генетичний шаблон.)"},

        new DialogueLine { Speaker = "Alex", Content = "Так! Він закодував відповідь у моїй крові…"},

        new DialogueLine { Speaker = "Lexa", Content = "(Кричить через комунікатор)\nАлекс, дрони прорвалися! Швидше!"},

        new DialogueLine { Speaker = "Father", Content = "(Насилу відкриває очі)\nНе бійся... Обери те, у що віриш."}
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

            else if (dialogue[dialogueIndex].Speaker == "The voice of AI")
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
        SceneManager.LoadScene("Loading5.2"); // Завантаження наступної сцени
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowDialogue();
        }
    }
}
