using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button _creditsButton;
    
    public void OnPlayClicked() => FindObjectOfType<SceneFader>().FadeToScene("SampleScene");
    public void OnCreditsClicked() => FindObjectOfType<SceneFader>().FadeToScene("CreditsScene");

    private void Start()
    {
        _creditsButton?.gameObject.SetActive(PlayerPrefs.GetInt("CreditsVisible", 0) == 1 );
    }
}
