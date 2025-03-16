using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroText5_3 : MonoBehaviour
{
    public TextMeshProUGUI mainText;
    public TextMeshProUGUI websiteLinkText;
    public Image part1Image;
    public Image part2Image;
    public Image part3Image;
    public Image part4Image;

    private string introText = "Ключ розгадано:";
    private string finalText = "Хочеш отримати престижну професію і стати своїм у світі кіберпанку? Вступай на навчання до ВСП 'ППФК НТУ 'ХПІ' на спеціальність 'Розробка програмного забезпечення!'";
    public string nextSceneName = "The ending";

    private float fadeDuration = 2f;
    private float scrollingTextDelay = 0.06f;
    private float waitBeforeSceneChange = 3f;

    void Start()
    {
        HideAllElements();
        StartCoroutine(DisplayIntroText());
    }

    IEnumerator DisplayIntroText()
    {
        yield return FadeTextIn(introText);

        yield return FadeInImageWithText(part1Image, "Карта пам'яті 1");
        yield return FadeInImageWithText(part2Image, "Карта пам'яті 2");
        yield return FadeInImageWithText(part3Image, "Карта пам'яті 3");

        yield return new WaitForSeconds(1f);

        yield return FadeOutImagesAndText();

        websiteLinkText.text = "<link=polytechnic.poltava.ua>polytechnic.poltava.ua</link>";
        websiteLinkText.gameObject.SetActive(true);
        part4Image.gameObject.SetActive(true);
        StartCoroutine(FadeInImage(part4Image));

        yield return ShowScrollingText(finalText);

        yield return new WaitForSeconds(waitBeforeSceneChange);
        SceneManager.LoadScene(nextSceneName);
    }

    IEnumerator FadeInImageWithText(Image image, string message)
    {
        image.gameObject.SetActive(true);
        yield return FadeInImage(image);
        yield return FadeTextIn(message);
    }

    IEnumerator FadeOutImagesAndText()
    {
        yield return FadeOutElements(part1Image, part2Image, part3Image, mainText);
    }

    IEnumerator ShowScrollingText(string message)
    {
        mainText.gameObject.SetActive(true);
        mainText.text = "";
        mainText.color = new Color(mainText.color.r, mainText.color.g, mainText.color.b, 1);

        foreach (char c in message)
        {
            mainText.text += c;
            yield return new WaitForSeconds(scrollingTextDelay);
        }
    }

    IEnumerator FadeTextIn(string message)
    {
        mainText.gameObject.SetActive(true);
        mainText.text = message;
        return FadeElement(mainText, 0, 1);
    }

    IEnumerator FadeInImage(Image image)
    {
        return FadeElement(image, 0, 1);
    }

    IEnumerator FadeOutElements(params Graphic[] elements)
    {
        foreach (var element in elements)
        {
            StartCoroutine(FadeElement(element, 1, 0));
        }
        yield return new WaitForSeconds(fadeDuration);
        foreach (var element in elements)
        {
            element.gameObject.SetActive(false);
        }
    }

    IEnumerator FadeElement(Graphic element, float startAlpha, float endAlpha)
    {
        float time = 0f;
        Color color = element.color;
        color.a = startAlpha;
        element.color = color;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, endAlpha, time / fadeDuration);
            element.color = color;
            yield return null;
        }
    }

    void HideAllElements()
    {
        part1Image.gameObject.SetActive(false);
        part2Image.gameObject.SetActive(false);
        part3Image.gameObject.SetActive(false);
        part4Image.gameObject.SetActive(false);
        websiteLinkText.gameObject.SetActive(false);
        mainText.gameObject.SetActive(false);
    }
}
