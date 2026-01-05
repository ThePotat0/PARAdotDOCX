using UnityEngine;

public class LevelLocker : MonoBehaviour
{
    [SerializeField] private GameObject _wallFragment;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            _wallFragment.transform.localScale = new Vector3(_wallFragment.transform.localScale.x + 3, _wallFragment.transform.localScale.y, _wallFragment.transform.localScale.z);
        }
        Destroy(gameObject);
    }
}
