using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Code
{
    [Serializable] 
    public class GameData
    {
       public int score = 0;
        public string timePlay; 
    }

    [Serializable]
    public class GameDataPlay
    {
        public List<GameData> plays;
    }
}