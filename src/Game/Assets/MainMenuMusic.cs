using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    public string sceneToStopMusic = "Chapter 1/Loading1"; // Сцена, где музыка должна остановиться
    private static BackgroundMusic instance;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(transform.root.gameObject); // Теперь применяется к корневому объекту
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
            Destroy(gameObject); // Уничтожаем объект с музыкой при входе в указанную сцену
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Отписываемся от события при удалении объекта
    }
}
