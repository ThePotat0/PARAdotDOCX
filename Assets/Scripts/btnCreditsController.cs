using UnityEngine;
using UnityEngine.SceneManagement;

public class btnCreditsController : MonoBehaviour
{
    public void OnCreditsClicked() => FindObjectOfType<SceneFader>().FadeToScene("CreditsScene");
}
