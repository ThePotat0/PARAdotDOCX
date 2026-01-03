using UnityEngine;

public class TileController : MonoBehaviour
{
    [SerializeField] private LevelMovement _levelMovement;
    [SerializeField] private int _levelID;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            switch (_levelID) 
            {
                case 1: 
                    {
                        collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = -1;
                        collision.gameObject.transform.rotation = new Quaternion(0, 0, 180, 0);
                        collision.gameObject.GetComponent<PlayerMovement>().IsFlipped = true;
                        break;
                    }
            }
        }
    }
}
