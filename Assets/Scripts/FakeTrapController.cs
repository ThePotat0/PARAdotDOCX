using UnityEngine;

public class FakeTrapController : MonoBehaviour
{
    [SerializeField] private GameObject PopUp;
    private PlayerMovement playerMovement;
    private bool _active = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_active && other.CompareTag("Player"))
        {
            playerMovement = other.GetComponent<PlayerMovement>();
            playerMovement.Disable();
            PopUp.active = true;
            _active = false;
        }
    }
}
