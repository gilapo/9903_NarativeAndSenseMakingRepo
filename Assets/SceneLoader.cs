using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using static System.TimeZoneInfo;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    private bool triggered = false; // prevent multiple triggers

    // Remove Update method since no mouse click now

    private void OnTriggerEnter(Collider other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;
            LoadNextLevel();
        }
    }
    public void LoadNextLevel()
    {
       StartCoroutine(Loadlevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator Loadlevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

}


