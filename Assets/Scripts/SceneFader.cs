using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    private IEnumerator FadeIn()
    {
        Color tempColor = fadeImage.color;
        tempColor.a = 1;
        fadeImage.color = tempColor;

        while (tempColor.a > 0)
        {
            tempColor.a -= Time.deltaTime / fadeDuration;
            fadeImage.color = tempColor;
            yield return null;
        }
    }

    private IEnumerator FadeOut(string sceneName)
    {
        Color tempColor = fadeImage.color;
        tempColor.a = 0;
        fadeImage.color = tempColor;

        while (tempColor.a < 1)
        {
            tempColor.a += Time.deltaTime / fadeDuration;
            fadeImage.color = tempColor;
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
    }

    public IEnumerator TheLastFadeOut() 
    {
        Color tempColor = fadeImage.color;
        tempColor.a = 0;
        fadeImage.color = tempColor;

        while (tempColor.a < 1)
        {
            tempColor.a += Time.deltaTime / fadeDuration;
            fadeImage.color = tempColor;
            yield return null;
        }
    }
}
