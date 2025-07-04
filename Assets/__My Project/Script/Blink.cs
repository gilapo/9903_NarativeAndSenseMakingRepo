using UnityEngine;
using System.Collections;

public class EyelidBlink : MonoBehaviour
{
    public RectTransform topLid;
    public RectTransform bottomLid;

    public float duration = 1.2f;      // Total time to open/close
    public float holdDuration = 5.4f;  // Time eyelids stay closed

    private Vector2 topStartPos;
    private Vector2 bottomStartPos;
    private Vector2 topClosedPos;
    private Vector2 bottomClosedPos;

    void Start()
    {
        // Cache original positions
        topStartPos = topLid.anchoredPosition;
        bottomStartPos = bottomLid.anchoredPosition;

        // Closed position = center of screen (y = 0)
        topClosedPos = new Vector2(topStartPos.x, 0);
        bottomClosedPos = new Vector2(bottomStartPos.x, 0);

        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        float time = 0f;
        float halfDuration = duration / 2f;

        // Close (Top down, Bottom up)
        while (time < halfDuration)
        {
            float t = time / halfDuration;
            float eased = Mathf.SmoothStep(0f, 1f, t);

            topLid.anchoredPosition = Vector2.Lerp(topStartPos, topClosedPos, eased);
            bottomLid.anchoredPosition = Vector2.Lerp(bottomStartPos, bottomClosedPos, eased);

            time += Time.deltaTime;
            yield return null;
        }

        // Clamp closed
        topLid.anchoredPosition = topClosedPos;
        bottomLid.anchoredPosition = bottomClosedPos;

        yield return new WaitForSeconds(holdDuration);

        time = 0f;

        // Open (reverse)
        while (time < halfDuration)
        {
            float t = time / halfDuration;
            float eased = Mathf.SmoothStep(0f, 1f, t);

            topLid.anchoredPosition = Vector2.Lerp(topClosedPos, topStartPos, eased);
            bottomLid.anchoredPosition = Vector2.Lerp(bottomClosedPos, bottomStartPos, eased);

            time += Time.deltaTime;
            yield return null;
        }

        // Clamp open
        topLid.anchoredPosition = topStartPos;
        bottomLid.anchoredPosition = bottomStartPos;
    }
}
