using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager2_1 : MonoBehaviour
{
    public Image Alex;
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
        new DialogueLine { Speaker = "Narrator", Content = "Нейрон-Сіті, 2147 рік. Алекс пробирається до старого корпусу університету, обходячи камери.\n" +
            "Він залазить у вентиляційний шахту, як його навчив батько." },

        new DialogueLine { Speaker = "Alex", Content = "(Шепоче)\nАрхів має бути на третьому рівні..."},
    };

    void Start()
    {
        Frame.gameObject.SetActive(true);
        Text.alignment = TextAlignmentOptions.Justified; // Вирівнювання тексту по ширині

        if (backgroundMusic != null)
        {
            backgroundMusic.loop = true; // Зациклення музики
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

        if (backgroundMusic != null)
        {
            backgroundMusic.Stop(); // Вимикаємо музику перед зміною сцени
        }

        SceneManager.LoadScene("Loading2.2"); // Завантаження наступної сцени
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Перехід по діалогу
        {
            ShowDialogue();
        }
    }
}
