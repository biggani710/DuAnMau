using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using 
UnityEngine.SceneManagement;
public class ExitPoint : MonoBehaviour
{
    private float levelLoadDelay = 2f;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(routine: LoadNextLevel());
        }  
    }

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
