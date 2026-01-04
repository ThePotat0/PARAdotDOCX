using UnityEngine;

public class Tile_SimpleToggle : MonoBehaviour
{
    [SerializeField] private int _levelID;
    private LevelMovement _leveloMvement;
    private bool _playerOnTrigger = false;

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

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && _playerOnTrigger) 
        {
            Destroy(gameObject);
            switch (_levelID) 
            {
                case 1: 
                    {
                        _leveloMvement.RightRotation();
                        break;
                    }
                case 4: 
                    {
                        var player = FindAnyObjectByType<PlayerMovement>();
                        player.gameObject.GetComponent<Rigidbody2D>().gravityScale *= -1;
                        _leveloMvement.LowerRotation();
                        break;
                    }
            }
        }
    }
}
