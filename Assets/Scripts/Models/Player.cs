using System;
using System.Collections.Generic;
using UnityEditor;

namespace Models
{
    [Serializable]
    public class Player
    {
        public string Name;
        public GUID Id;
        public Dictionary<string, PlayerLevelResult> LevelResults;

        public Player(string name)
        {
            Name = name;
            LevelResults = new Dictionary<string, PlayerLevelResult>();
            Id = GUID.Generate();
        }

        public void UpdateLevelInfo(PlayerLevelResult levelResult)
        {
            if (LevelResults.ContainsKey(levelResult.LevelName))
            {
                LevelResults[levelResult.LevelName] = levelResult;
            }
            else
            {
                LevelResults.Add(levelResult.LevelName, levelResult);
            }
        }
    }
}