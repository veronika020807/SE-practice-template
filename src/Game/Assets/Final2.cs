using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Final2 : MonoBehaviour
{
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
        new DialogueLine { Speaker = "Narrator", Content = "Алекс об’єднується з ШІ, ставши \"Прометеєм\". Місто перезавантажується: технології тепер служать людям. Але Алекс втрачає тіло, залишаючись у кіберпросторі. Лекса відвідує його голограму, показуючи фото їхньої команди.) Голос Алекса: — Це була ціна... але вони вільні."}
    };

    void Start()
    {
        Frame.gameObject.SetActive(true);
        Text.alignment = TextAlignmentOptions.Justified; // Вирівнювання тексту по ширині

        // Запуск фонової музики
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

            if (dialogue[dialogueIndex].Speaker == "Narrator")
            {
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

        // Зупинка фонової музики перед переходом
        if (backgroundMusic != null)
        {
            backgroundMusic.Stop();
        }

        SceneManager.LoadScene("Loading5.3"); // Завантаження наступної сцени
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Перехід по діалогу
        {
            ShowDialogue();
        }
    }
}
