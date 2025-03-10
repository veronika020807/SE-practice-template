using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class IntroText2_2 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public float delayBeforeChange = 2f;
    public float fadeDuration = 1.5f;
    public float sceneTransitionDelay = 2f; // ��� ����� ���������
    public string nextSceneName = "Loading3"; // ����� �������� �����

    void Start()
    {
        StartCoroutine(DisplayTextSequence());
    }

    IEnumerator DisplayTextSequence()
    {
        yield return ShowText("����� �����������");
        yield return ShowText("����� ��������� � ��������� � ������� ���������.");
        yield return ShowText("�� ��� � ������ � �������� ���� \"³����� ���\".");
        yield return ShowText("����� ������� ������ �� ��������.");

        // �������� ����� ��������� �� �������� �����
        yield return new WaitForSeconds(sceneTransitionDelay);
        SceneManager.LoadScene(nextSceneName);
    }

    IEnumerator ShowText(string message)
    {
        textDisplay.text = message;
        yield return FadeText(1f);
        yield return new WaitForSeconds(delayBeforeChange);
        yield return FadeText(0f);
    }

    IEnumerator FadeText(float targetAlpha)
    {
        float startAlpha = textDisplay.color.a;
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            textDisplay.color = new Color(textDisplay.color.r, textDisplay.color.g, textDisplay.color.b, alpha);
            yield return null;
        }
    }

}
