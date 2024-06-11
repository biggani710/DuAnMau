using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;


namespace Assets.Code
{
    public class StoregaHelper
    {
        private readonly string filename = "game_data.txt";
        public GameDataPlay played;

        public void LoadData() 
        {
            played = new GameDataPlay()
            {
                plays = new List<GameData>()
            };

            string dataAsJson = StorageManager.LoadFromFile(filename);
            if (dataAsJson != null)
            {
                played = JsonUtility.FromJson<GameDataPlay>(dataAsJson);
            }
        }

        public void SaveData()
        {
            string dataASJson = JsonUtility.ToJson(played);
            StorageManager.SaveToFile(filename, dataASJson);
        }
    }
}