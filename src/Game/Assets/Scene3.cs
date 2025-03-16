using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager3 : MonoBehaviour
{
    public Image Alex;
    public Image Lexa;
    public Image Frame;
    public TextMeshProUGUI NamePers;
    public TextMeshProUGUI Text;
    public AudioSource backgroundMusic; // Фонова музика

    private int dialogueIndex = 0;

    private class DialogueLine
    {
        public string Speaker;
        public string Content;
    }

    private DialogueLine[] dialogue = new DialogueLine[]
    {
        new DialogueLine { Speaker = "Lexa", Content = "(Серйозно)\nNeuraTech вже знає, що ти наблизився до правди. Їхні дрони сканують кожен кут. " +
            "Але в нас є перевага – код твого батька." },

        new DialogueLine { Speaker = "Alex", Content = "(Розглядає флешку)\nТут лише перший фрагмент. Як знайти інші?" },

        new DialogueLine { Speaker = "Lexa", Content = "(Показує на голограмі)\nКожен фрагмент містить координати наступного. Але їх треба активувати в правильній послідовності. " +
            "Спробуй підключитись через мій інтерфейс." },

        new DialogueLine { Speaker = "Narrator", Content = "(Алекс підключає гаджет до голографічного проектора. З’являється головоломка.)" }
    };

    void Start()
    {
        Lexa.gameObject.SetActive(false);
        Frame.gameObject.SetActive(true);
        Text.alignment = TextAlignmentOptions.Justified;

        if (backgroundMusic != null)
        {
            backgroundMusic.loop = true; // Зациклюємо музику
            backgroundMusic.Play();
        }

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
            StartCoroutine(LoadNextScene()); // Переходити на наступну сцену
        }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1f);

        if (backgroundMusic != null)
        {
            backgroundMusic.Stop(); // Вимикаємо музику перед переходом на іншу сцену
        }

        SceneManager.LoadScene("Loading3.1"); // Завантаження наступної сцени
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowDialogue();
        }
    }
}
