using UnityEngine;
using System.Collections;

public class AutoDeactivateAfterSeconds : MonoBehaviour
{
    public float activeDuration = 5f;

    private Coroutine deactivateCoroutine;

    private void OnEnable()
    {
        // When object becomes active, start countdown to deactivate
        if (deactivateCoroutine != null)
            StopCoroutine(deactivateCoroutine);

        deactivateCoroutine = StartCoroutine(DeactivateAfterDelay());
    }

    private IEnumerator DeactivateAfterDelay()
    {
        yield return new WaitForSeconds(activeDuration);
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        // Stop coroutine if object is disabled early to avoid errors
        if (deactivateCoroutine != null)
            StopCoroutine(deactivateCoroutine);
    }
}
