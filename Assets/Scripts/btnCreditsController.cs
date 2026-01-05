using UnityEngine;
using UnityEngine.SceneManagement;

public class btnCreditsController : MonoBehaviour
{
    public void OnCreditsClicked() 
    {
        PlayerPrefs.SetInt("CreditsVisible", 1);
        SceneManager.LoadScene("CreditsScene");
    }
}
