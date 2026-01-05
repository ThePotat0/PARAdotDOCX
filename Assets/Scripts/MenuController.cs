using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button _creditsButton;
    
    public void OnPlayClicked() => SceneManager.LoadScene("SampleScene");
    public void OnCreditsClicked() => SceneManager.LoadScene("CreditsScene");

    private void Start()
    {
        _creditsButton?.gameObject.SetActive(PlayerPrefs.GetInt("CreditsVisible", 0) == 1 );
    }
}
