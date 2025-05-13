using UnityEngine;

public class StartupFadeCanvas : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration = 2f;

    void Start()
    {
        canvasGroup.alpha = 1;
        StartCoroutine(FadeOut());
    }

    System.Collections.IEnumerator FadeOut()
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            canvasGroup.alpha = 1 - t / fadeDuration;
            t += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 0;
        gameObject.SetActive(false);
    }
}
