using System.Collections.Generic;
using UnityEngine;

public class LevelMovement : MonoBehaviour
{
    [SerializeField] private List<GameObject> _levelFragments;
    private List<GameObject> _leftRow;
    private List<GameObject> _rightRow;
    private List<GameObject> _upperRow;
    private List<GameObject> _lowerRow;

    private void Start()
    {
        _leftRow = new List<GameObject>();
        _rightRow = new List<GameObject>();
        _lowerRow = new List<GameObject>();
        _upperRow = new List<GameObject>();

        _leftRow.Add(_levelFragments[1]);
        _leftRow.Add(_levelFragments[5]);
        _leftRow.Add(_levelFragments[8]);
        _leftRow.Add(_levelFragments[11]);

        _rightRow.Add(_levelFragments[7]);
        _rightRow.Add(_levelFragments[3]);
        _rightRow.Add(_levelFragments[2]);
        _rightRow.Add(_levelFragments[0]);

        _upperRow.Add(_levelFragments[10]);
        _upperRow.Add(_levelFragments[6]);
        _upperRow.Add(_levelFragments[5]);
        _upperRow.Add(_levelFragments[2]);

        _lowerRow.Add(_levelFragments[9]);
        _lowerRow.Add(_levelFragments[4]);
        _lowerRow.Add(_levelFragments[1]);
        _lowerRow.Add(_levelFragments[0]);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            LeftMovement();
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            RightMovement();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            UpperMovement();
        }
        else if (Input.GetKeyDown(KeyCode.S)) 
        {
             LowerMovement();
        }

    }

    private void UpperMovement()
    {
        foreach (var row in _upperRow)
        {
            while (row.transform.position != new Vector3(row.transform.position.x + 1, row.transform.position.y, row.transform.position.z))
                row.transform.position = Vector3.Lerp(row.transform.position, new Vector3(row.transform.position.x + 1, row.transform.position.y, row.transform.position.z), 3 * Time.deltaTime);
        }
    }

    private void LowerMovement()
    {
        foreach (var row in _lowerRow)
        {
            while (row.transform.position != new Vector3(row.transform.position.x + 1, row.transform.position.y, row.transform.position.z))
                row.transform.position = Vector3.Lerp(row.transform.position, new Vector3(row.transform.position.x + 1, row.transform.position.y, row.transform.position.z), 3 * Time.deltaTime);
        }
    }

    private void LeftMovement()
    {
        foreach (var row in _leftRow)
        {
            while (row.transform.position != new Vector3(row.transform.position.x, row.transform.position.y - 1, row.transform.position.z))
                row.transform.position = Vector3.Lerp(row.transform.position, new Vector3(row.transform.position.x, row.transform.position.y - 1, row.transform.position.z), 3 * Time.deltaTime);
        }
    }

    private void RightMovement()
    {
        foreach (var row in _rightRow)
        {
            while (row.transform.position != new Vector3(row.transform.position.x, row.transform.position.y - 1, row.transform.position.z))
                row.transform.position = Vector3.Lerp(row.transform.position, new Vector3(row.transform.position.x, row.transform.position.y - 1, row.transform.position.z), 3 * Time.deltaTime);
        }
    }
}
