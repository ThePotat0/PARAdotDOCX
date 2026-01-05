using UnityEngine;

public class Tile_Gravity : MonoBehaviour
{
    private LevelMovement _leveloMvement;
    private bool _playerOnTrigger = false;
    private Collider2D _player;
    private void Start()
    {
        _leveloMvement = FindObjectOfType<LevelMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            _playerOnTrigger = true;
            _player = collision;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            _playerOnTrigger = false;
            _player = null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _playerOnTrigger) 
        {
            _player.gameObject.GetComponent<Rigidbody2D>().gravityScale *= -1;
            _player.gameObject.transform.rotation = new Quaternion(0, 0, 90, 0);
            _player.gameObject.GetComponent<PlayerMovement>().IsFlipped = true;
            _leveloMvement.UpperRotation();
            Destroy(gameObject);
        }
    }
}
