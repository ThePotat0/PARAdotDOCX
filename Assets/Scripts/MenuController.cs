using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button _creditsButton;
    [SerializeField] private bool _creditsButtonDebugMode = false;
    
    public void OnPlayClicked() => FindObjectOfType<SceneFader>().FadeToScene("SampleScene");
    public void OnCreditsClicked() => FindObjectOfType<SceneFader>().FadeToScene("CreditsScene");

    private void Start()
    {
        _creditsButton?.gameObject.SetActive(PlayerPrefs.GetInt("CreditsVisible", 0) == 1 );
    }

    // На текущий момент содержит только логику для дебага ссылки на кредитс, 
    // может быть удалено со временем без обратной совместимости
    private void Update()
    {
        _creditsButton?.gameObject.SetActive(_creditsButtonDebugMode);
    }
}
