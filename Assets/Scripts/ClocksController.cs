using UnityEngine;
using TMPro;

// Как использовать
// Повесить на TMP_InputField
// На тот же input field повесить LevelTrigger
// LevelTrigger настроить согласно его инструкции
// вызовет скролл один раз. Если успешно - отключится, 
// если нет, будет ждать пока на странице не отобразится в видимой области объект _trigger
public class ClocksController : MonoBehaviour
{
    private TMP_InputField _timeField;
    private LevelTrigger _trigger;
    private bool _active = true;

    private void Start()
    {
        _timeField = gameObject.GetComponent<TMP_InputField>();
        _trigger = gameObject.GetComponent<LevelTrigger>();
        UpdateTime();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (_active && _timeField.text.Replace(" ", "") == "22:22")
        {
            if (_trigger.ForceMoveTo())
            {
                _active = false;                
            }
        }
    }

    private void UpdateTime()
    {
        _timeField.text = System.DateTime.Now.ToString("HH:mm");
    }
}
