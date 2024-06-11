using Assets.Code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class End : MonoBehaviour
{
    [SerializeField] GameObject infomationCanvas;
    [SerializeField] GameObject winCanvas;

    private StoregaHelper StoregaHelper;
    private GameDataPlay played;

    [SerializeField] GameObject Row;

    private void Start()
    {
        StoregaHelper = new StoregaHelper();
        StoregaHelper.LoadData();
        played = StoregaHelper.played;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            infomationCanvas.SetActive(false);
            var score = FindObjectOfType<GameController>().GetScore();

            var gamedata = new GameData()
            {
                score = score,
                timePlay = DateTime.Now.ToString(format: "yyyy-MM-dd HH:mm:ss")
            };
            played.plays.Add(gamedata);
            StoregaHelper.SaveData();


            //played.plays.Sort(comparison:(x:gamedata, y:gamedata) => y.score.CompareTo(x.score));
            var plays = played.plays.GetRange(index:0, count:Math.Min(5, played.plays.Count));

            for (int i = 0; i < played.plays.Count; i++)
            {
                var rowInstance = Instantiate(Row, Row.transform.parent);
                rowInstance.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = (i + 1).ToString();
                rowInstance.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = played.plays[i].score.ToString();
                rowInstance.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = played.plays[i].timePlay;
                rowInstance.SetActive(true);
            }

            winCanvas.SetActive(true);
        }
    }
}
