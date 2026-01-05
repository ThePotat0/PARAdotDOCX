using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioController _instance;
    private void Awake()
    {
        // Получаем все объекты данного типа в сцене
        AudioController[] existingObjects = FindObjectsOfType<AudioController>();

        // Если уже существует объект этого типа, уничтожаем текущий
        if (existingObjects.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
