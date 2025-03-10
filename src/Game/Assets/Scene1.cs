using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Image Alex;
    public Image Glitch;
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
        new DialogueLine { Speaker = "Alex", Content = "З’являється головний герой – Алекс, 22 роки, програміст-початківець. Він сидить у своїй скромній кіберквартирі, " +
            "заваленій технікою. На столі – фотографія його батька, відомого хакера, який зник роком раніше.)" },

        new DialogueLine { Speaker = "Alex", Content = "(Тихо до себе)\nЩе одна ніч, ще одне дрібне замовлення...\n" +
            "(Раптом з'являється персонаж – Глітч.)" },

        new DialogueLine { Speaker = "Glitch", Content = "(Спотворним голосом)\nПривіт, Алекс. Ти шукав відповіді про свого батька?" },

        new DialogueLine { Speaker = "Alex", Content = "(Різко підводиться)\nХто ти? Що ти знаєш про нього?" },

        new DialogueLine { Speaker = "Glitch", Content = "Він залишив тобі послання. Код, розділений на чотири частини.\n" + 
            "Перша - у архіві університету, де він колись працював."},

        new DialogueLine { Speaker = "Alex", Content = "(Стискає кулаки)\nЧому я повинен тобі вірити?" },

        new DialogueLine { Speaker = "Glitch", Content = "Бо це єдиний спосіб дізнатися правду. Ти ж не хочеш,\n" + 
            "щоб його робота дісталася корпораціям?"},

        new DialogueLine { Speaker = "Alex", Content = "(Рішуче)\nГаразд. Я йду.\n" +
            "(Алекс бере кишеньковий гаджет батька, який завжди носив із собою, і виходить із квартири.)" }
    };

    void Start()
    {
        Glitch.gameObject.SetActive(false); // Спершу з'являється тільки Алекс
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
                Glitch.gameObject.SetActive(false);
            }
            else
            {
                Alex.gameObject.SetActive(false);
                Glitch.gameObject.SetActive(true);
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
        SceneManager.LoadScene("Scene2"); // Завантаження наступної сцени
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Перехід по діалогу
        {
            ShowDialogue();
        }
    }
}
