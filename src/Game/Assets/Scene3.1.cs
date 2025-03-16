using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager3_1 : MonoBehaviour
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
        new DialogueLine { Speaker = "Alex", Content = "(Концентрується)\nТак... Батько завжди використовував геометричні шаблони. Тут має бути шестикутник!" },

        new DialogueLine { Speaker = "Narrator", Content = "(Після успіху на карті висвічується локація: Підземна лабораторія \"Квант\".)" },

        new DialogueLine { Speaker = "Lexa", Content = "(Посміхається)\nНепогано для новачка. Але туди не потрапити без моєї допомоги." }
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
            StartCoroutine(LoadNextScene()); // Перехід на наступну сцену
        }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1f);

        if (backgroundMusic != null)
        {
            backgroundMusic.Stop(); // Вимикаємо музику перед переходом на іншу сцену
        }

        SceneManager.LoadScene("Loading3.2"); // Завантаження наступної сцени
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowDialogue();
        }
    }
}
