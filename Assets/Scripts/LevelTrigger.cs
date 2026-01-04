using UnityEngine;

// Как использовать
// _triggerComponent - компоненет у которого есть Tile_SimpleToggle
//   он используется, что бы именно на нем вызвать Tile_SimpleToggle.ForceMoveTo
// _levelID - должен быть проствлен здесь, что бы вызвать нужное действие
//   возможно стоит зарефакторить и использовать "направление"? down/right?
// _window - компонент на странице, сейчас рекомендуется использовать "интерфейс комухтера", который
//   используется что бы убедиться что _triggerComponnent виден пользователю
// вызвать LevelTrigger.ForceMoveTo или через кнопку вызывать LevelTrigger.ForceMoveToForButtons
// скрипт выполняет движение один раз, после выполнения он удаляет _trigger дабавленный внутри Start

// Для реакции на "кнопку звука" - этот скрипт нужно добавить как компонент к кнопке ToggleSound
// проставить все необходимые поля и затем
// в On Click () кнопки добавить вызов LevelTrigger.ForceMoveToForButtons

// Для реакции на "время" - этот скрипт нужно добавить как компонент объекту который
// вызовет .ForceMoveTo
// при этом нужно этот скрипт верно настроить (смотри инструкцию выше)
public class LevelTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _triggerComponent;
    [SerializeField] private GameObject _window;
    [SerializeField] private int _levelID;

    private Tile_SimpleToggle _trigger;

    private void Start()
    {
        if (_triggerComponent == null)
        {
            Debug.Log($"SET Trigger Component and Level ID for {gameObject.name} object!!!");
        } else
        {
            _trigger = _triggerComponent.GetComponent<Tile_SimpleToggle>();
        }
    }

    public void ForceMoveToForButtons() // buttons do not accept functions that returns values
    {
        ForceMoveTo();
    }

    public bool ForceMoveTo()
    {
        if (_trigger != null && IsTriggerInWindow())
        {
            _trigger.ForceMoveTo(_levelID);
            _trigger = null;
            return true; // this helps check is it moved successfully
        }
        return false;
    }

    private bool IsTriggerInWindow()
    {
        // Bounds a = objectA.GetComponent<Renderer>().bounds;
        // Bounds b = objectB.GetComponent<Renderer>().bounds;
        // if (a.Intersects(b)) { /* пересекаются */ }
        Bounds a = _triggerComponent.GetComponent<Renderer>().bounds;
        Bounds b = _window.GetComponent<Renderer>().bounds;
        if (a.Intersects(b)) 
        { 
            return true;
        } else
        {
            return false;
        }
    }
}
