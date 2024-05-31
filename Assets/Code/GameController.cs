using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] int live = 3;

    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI LiveText;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
