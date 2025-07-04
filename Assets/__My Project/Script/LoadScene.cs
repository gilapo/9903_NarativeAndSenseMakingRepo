using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchTrigger : MonoBehaviour
{
    public string targetSceneName;
    public string playerTag = "Player";
    public float delay = 4f; // Delay in seconds

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            StartCoroutine(DelayedSceneSwitch());
        }
    }

    private IEnumerator DelayedSceneSwitch()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(targetSceneName);
    }
}
