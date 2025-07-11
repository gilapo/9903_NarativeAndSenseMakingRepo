using UnityEngine;
using System.Collections;

public class DelayedPlay : MonoBehaviour
{
    public AudioSource audioSource;
    public float delayInSeconds = 2f;

    private void Start()
    {
        StartCoroutine(PlayAfterDelay());
    }

    private IEnumerator PlayAfterDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        audioSource.Play();
    }
}
