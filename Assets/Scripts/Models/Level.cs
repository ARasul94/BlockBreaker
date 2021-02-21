using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class Level: IComparable<Level>
    {
        public string Name;
        [SerializeField] private List<PlayerLevelResult> PlayersResults;
        
        public GUID Id => _id;

        private GUID _id;

        public Level(string levelName)
        {
            Name = levelName;
            _id = GUID.Generate();
            PlayersResults = new List<PlayerLevelResult>();
        }

        public PlayerLevelResult AddPlayer(Player player, int result)
        {
            var playerLevelResult = new PlayerLevelResult(this, player, result);
            PlayersResults.Add(playerLevelResult);
            SortPlayerResults();

            return playerLevelResult;
        }
        
        public void RemovePlayer(Player player)
        {
            var playerResult = PlayersResults.FirstOrDefault(x=> x.Player.Id == player.Id);
            if (playerResult != null)
            {
                PlayersResults.Remove(playerResult);
                SortPlayerResults();
            }
        }

        public void UpdatePlayerLevelInfo(Player player, int newResult)
        {
            var playerResult = PlayersResults.FirstOrDefault(x=> x.Player.Id == player.Id);
            if (playerResult == null)
            {
                AddPlayer(player, newResult);
                return;
            }

            playerResult.UpdatePlayerResult(newResult);
            SortPlayerResults();
        }
        
        public int CompareTo(Level other)
        {
            return Name.CompareTo(other.Name);
        }

        private void SortPlayerResults()
        {
            PlayersResults.Sort();
        }
    }
}