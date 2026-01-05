using UnityEngine;
using UnityEngine.SceneManagement;


public class ContinuePopUpController : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private LevelTrigger _levelTrigger;

    public void OnYesClicked() => SceneManager.LoadScene("SampleScene");

    public void OnNoClicked()
    {
        _player.Enable();
        _levelTrigger.ForceMoveTo();
        Destroy(gameObject);
    }
}
