using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Класс <c>LevelMovement</c> изменяет игровое поле в зависимоти от стадии прохождения игры.
/// Горизонтальные колонки перемещаются по горизонтали, вертикальные - по вертикали.
/// </summary>
public class LevelMovement : MonoBehaviour
{
    [SerializeField] private List<GameObject> _levelFragments;
    [SerializeField] private float moveDuration = 0.5f;
    private bool _isMoving = false;
    private List<GameObject> _leftRow;
    private List<GameObject> _rightRow;
    private List<GameObject> _upperRow;
    private List<GameObject> _lowerRow;

    /// <summary>
    /// Метод <c>LeftRotation</c> перемещает левую половину вертикальной колонки тайлов.
    /// </summary>
    public void LeftRotation()
    {
        if (!_isMoving)
        {
            _leftRow = new List<GameObject>();
            for (int i = 0; i < _levelFragments.Count; i++)
            {
                if (_levelFragments[i].transform.localPosition.x == 8.59f)
                {
                    _leftRow.Add(_levelFragments[i]);
                }
            }
            SortY(ref _leftRow);
            StartCoroutine(LevelMoving(_leftRow, false));
        }
    }
    /// <summary>
    /// Метод <c>RightRotation</c> перемещает правую половину вертикальной колонки тайлов.
    /// </summary>
    public void RightRotation()
    {
        if (!_isMoving)
        {
            _rightRow = new List<GameObject>();
            for (int i = 0; i < _levelFragments.Count; i++)
            {
                if (_levelFragments[i].transform.localPosition.x == 15.18f)
                {
                    _rightRow.Add(_levelFragments[i]);
                }
            }
            SortY(ref _rightRow);
            StartCoroutine(LevelMoving(_rightRow, false));
        }
    }
    /// <summary>
    /// Метод <c>UpperRotation</c> перемещает верхнюю половину горизонтальной колонки тайлов.
    /// </summary>
    public void UpperRotation()
    {
        if (!_isMoving)
        {
            _upperRow = new List<GameObject>();
            for (int i = 0; i < _levelFragments.Count; i++)
            {
                if (_levelFragments[i].transform.localPosition.y == 4.61f)
                {
                    _upperRow.Add(_levelFragments[i]);
                }
            }
            SortX(ref _upperRow);
            StartCoroutine(LevelMoving(_upperRow, true));
        }
    }
    /// <summary>
    /// Метод <c>LowerRotation</c> перемещает нижнюю половину горизонтальной колонки тайлов.
    /// </summary>
    public void LowerRotation()
    {
        if (!_isMoving)
        {
            _lowerRow = new List<GameObject>();
            for (int i = 0; i < _levelFragments.Count; i++)
            {
                if (_levelFragments[i].transform.localPosition.y == -2.33f)
                {
                    _lowerRow.Add(_levelFragments[i]);
                }
            }
            SortX(ref _lowerRow);
            StartCoroutine(LevelMoving(_lowerRow, true));
        }
    }
    /// <summary>
    /// Функция <c>LevelMoving</c> осуществляет движение тайлов на экране.
    /// </summary>
    /// <param name="inputRow">Входной массив тайлов для перемещения</param>
    /// <param name="horizontalMovement">Индикатор горизонтального перемещения</param>
    /// <example>Например для
    /// <code>
    /// LevelMoving(_lowerRow, true)
    /// </code>
    /// второй параметр true потому что движение тайлов происходит по горизонтали.
    /// </example>
    /// <returns>Нулевое значение</returns>
    private IEnumerator LevelMoving(List<GameObject> inputRow, bool horizontalMovement)
    {
        _isMoving = true;

        Vector3[] startPositions = new Vector3[inputRow.Count];
        for (int i = 0; i < inputRow.Count; i++)
        {
            startPositions[i] = inputRow[i].transform.position;
        }
        Vector3 delta = startPositions[0] - startPositions[1];
        Vector3[] targetPositions = new Vector3[inputRow.Count];
        for (int i = 0; i < inputRow.Count; i++)
        {
            if (horizontalMovement)
                targetPositions[i] = startPositions[i] - delta;
            else
                targetPositions[i] = startPositions[i] + delta;
        }

        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            for (int i = 0; i < inputRow.Count; i++)
            {
                inputRow[i].transform.position = Vector3.Lerp(startPositions[i], targetPositions[i], (elapsedTime / moveDuration));
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        for (int i = 0; i < inputRow.Count; i++)
        {
            inputRow[i].transform.position = targetPositions[i];
        }

        _isMoving = false;
    }
    /// <summary>
    /// Метод <c>SortX</c> Осуществляет реализует сортировку списка тайлов для сортировки.
    /// Это нужно для правильного расчета направление движения тайлов.
    /// </summary>
    /// <param name="inputList">Входной список тайлов для сортировки</param>
    /// <returns>Отсортированный по значению смещения по X список тайлов</returns>
    private List<GameObject> SortX(ref List<GameObject> inputList)
    {
        inputList.Sort((a, b) =>
            a.transform.localPosition.x.CompareTo(b.transform.localPosition.x));
        return inputList;
    }
    /// <summary>
    /// Метод <c>SortY</c> Осуществляет реализует сортировку списка тайлов для сортировки.
    /// Это нужно для правильного расчета направление движения тайлов.
    /// </summary>
    /// <param name="inputList">Входной список тайлов для сортировки</param>
    /// <returns>Отсортированный по значению смещения по Y список тайлов</returns>
    private List<GameObject> SortY(ref List<GameObject> inputList)
    {
        inputList.Sort((a, b) =>
            a.transform.localPosition.y.CompareTo(b.transform.localPosition.y));
        return inputList;
    }
}
