using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CreditsRoll : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public float scrollSpeed = 50f; // Скорость подъема текста
    public float endDelay = 3f; // Задержка перед сменой сцены
    public string nextSceneName = "MainMenu"; // Назва наступної сцени

    void Start()
    {
        // Устанавливаем начальное положение текста внизу экрана
        RectTransform textTransform = textDisplay.GetComponent<RectTransform>();
        textTransform.anchoredPosition = new Vector2(0, -Screen.height / 2);

        StartCoroutine(RollCredits(textTransform));
    }

    IEnumerator RollCredits(RectTransform textTransform)
    {
        textDisplay.text = "ДЯКУЄМО ЗА ГРУ!\n\n"
                         + "Менеджер програми:\n"
                         + "Вероніка Михайлик\n\n"
                         + "Менеджер продукту:\n"
                         + "Олекмандр Наріков\n\n"
                         + "Розробники:\n"
                         + "Олексій Шульженко\n"
                         + "Ярослав Пічугін\n\n"
                         + "Тестувальники:\n"
                         + "Ростислав Без'язичний\n"
                         + "Євгеній Соколіков\n\n"
                         + "UX-спеціалісти:\n"
                         + "Назар Чугунов\n"
                         + "Ілля Яковлев\n\n"
                         + "Спеціалісти з розгортання:\n"
                         + "Артем Пишнов\n"
                         + "Юрій Темний\n\n"
                         + "Спеціальна подяка:\n"
                         + "Unity Community\n\n"
                         + "© 2025 Всі права захищені.";

        // Поднимаем текст вверх, пока он не выйдет за экран
        while (textTransform.anchoredPosition.y < Screen.height + 500)
        {
            textTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;
            yield return null;
        }

        // Ждем перед сменой сцены
        yield return new WaitForSeconds(endDelay);
        SceneManager.LoadScene(nextSceneName);
    }
}
