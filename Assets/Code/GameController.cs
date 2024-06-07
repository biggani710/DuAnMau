using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] int live = 3;

    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI LiveText;

    private void Awake()
    {
        int numberGameSessions = FindObjectsOfType<GameController>().Length;
        if(numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        LiveText.text = live.ToString();
        ScoreText.text = score.ToString();
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        ScoreText.text += score.ToString();
    }

    private void Decreaselive()
    {
        live--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        LiveText.text = live.ToString();
    }

    private void ResetGame()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    public void ProcessPlayerDeath()
    {
        if(live > 1)
        {
            Decreaselive();
        }
        else
        {
            ResetGame();
        }
    }
}
