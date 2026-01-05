using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void OnMainMenuClicked() 
    {
        if (this.enabled == false)
        {
            enabled = true;
        }
        else 
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
