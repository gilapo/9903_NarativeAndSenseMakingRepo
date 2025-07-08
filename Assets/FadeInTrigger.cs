using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInTrigger : MonoBehaviour
{
    public CanvasGroup fadeCanvasGroup;   // The black fade panel
    public float fadeDuration = 2f;
    public float messageDelay = 1f;
    public CanvasGroup messageCanvasGroup; // The "The End" message group
    public float messageFadeDuration = 1f;

    public string playerTag = "Player";
    private bool hasFaded = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasFaded && other.CompareTag(playerTag))
        {
            hasFaded = true;
            StartCoroutine(FadeToBlackAndShowMessage());
        }
    }

    IEnumerator FadeToBlackAndShowMessage()
    {
        // Fade to black
        float t = 0f;
        fadeCanvasGroup.blocksRaycasts = true;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadeCanvasGroup.alpha = Mathf.Clamp01(t / fadeDuration);
            yield return null;
        }

        fadeCanvasGroup.alpha = 1;

        // Wait before showing message
        yield return new WaitForSeconds(messageDelay);

        // Fade in the message
        if (messageCanvasGroup != null)
        {
            float m = 0f;
            while (m < messageFadeDuration)
            {
                m += Time.deltaTime;
                messageCanvasGroup.alpha = Mathf.Clamp01(m / messageFadeDuration);
                yield return null;
            }
            messageCanvasGroup.alpha = 1;
        }
    }
}
