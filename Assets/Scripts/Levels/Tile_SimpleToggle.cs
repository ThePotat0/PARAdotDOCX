using UnityEngine;

public class Tile_SimpleToggle : MonoBehaviour
{
    [SerializeField] private int _levelID;
    private LevelMovement _leveloMvement;
    private bool _playerOnTrigger = false;

    private bool forceMovement = false;

    private void Start()
    {
        _leveloMvement = FindObjectOfType<LevelMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            _playerOnTrigger = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            _playerOnTrigger = false;
    }

    public void ForceMoveTo(int levelID)
    {
        _levelID = levelID;
        forceMovement = true;
    }

    private void FixedUpdate()
    {
        if (forceMovement || Input.GetKeyDown(KeyCode.E) && _playerOnTrigger) 
        {
            Destroy(gameObject);
            switch (_levelID) 
            {
                case 1: 
                    {
                        _leveloMvement.RightRotation();
                        break;
                    }
                case 2: 
                    {
                        _leveloMvement.LeftRotation();
                        break;
                    }
                case 3: 
                    {
                        _leveloMvement.UpperRotation();
                        break;
                    }
                case 4: 
                    {
                        _leveloMvement.LowerRotation();
                        break;
                    }
            }
            forceMovement = false;
        }
    }
}
