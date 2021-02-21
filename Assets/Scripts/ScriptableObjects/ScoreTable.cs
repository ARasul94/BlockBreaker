using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu][Serializable]
    public class ScoreTable : ScriptableObject
    {
        [SerializeField] private List<Level> levels;
        
        private Level AddLevel(string levelName)
        {
            if (levels == null)
                levels = new List<Level>();
            
            if (levels.Count(x => x.Name == levelName) > 0)
                return levels.First(x => x.Name == levelName);
            
            var level = new Level(levelName);
            
            levels.Add(level);
            
            return level;
        }

        public Level GetLevelInfo(string levelName)
        {
            return AddLevel(levelName);
        }
        
        public void RemoveLevel(Level level)
        {
            var tmpLevel = levels.FirstOrDefault(x=> x.Id == level.Id);
            if (tmpLevel != null)
                levels.Remove(tmpLevel);
        }

        public void RemovePlayerInfo(Player player)
        {
            foreach (var level in levels)
            {
                level.RemovePlayer(player);
            }
        }

        public void UpdatePlayerLevelInfo(Level level, Player player, int newResult)
        {
            if (levels == null)
                levels = new List<Level>();
            
            var tmpLevel = levels.FirstOrDefault(x=> x.Id == level.Id);
            if (tmpLevel == null)
                return;

            levels.First(x => x.Id == level.Id).UpdatePlayerLevelInfo(player, newResult);
        }
    }
}
