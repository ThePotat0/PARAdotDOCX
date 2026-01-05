using UnityEngine;
using UnityEngine.SceneManagement;

public class btnCreditsController : MonoBehaviour
{
    public void OnCreditsClicked() => SceneManager.LoadScene("CreditsScene");
}
