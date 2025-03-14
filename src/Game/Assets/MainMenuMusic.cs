using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    public string sceneToStopMusic = "Chapter 1/Loading1"; // �����, ��� ������ ������ ������������
    private static BackgroundMusic instance;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(transform.root.gameObject); // ������ ����������� � ��������� �������
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        audioSource.Play();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == sceneToStopMusic)
        {
            Destroy(gameObject); // ���������� ������ � ������� ��� ����� � ��������� �����
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // ������������ �� ������� ��� �������� �������
    }
}
