using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class Level: IComparable<Level>
    {
        public string Name;
        [SerializeField] private List<PlayerLevelResult> PlayersResults = new List<PlayerLevelResult>();
        
        private Dictionary<GUID, PlayerLevelResult> _players = new Dictionary<GUID, PlayerLevelResult>();
        
        public GUID Id => _id;

        private GUID _id;

        public Level(string levelName)
        {
            Name = levelName;
            _id = GUID.Generate();
        }

        public void AddPlayer(Player player, int result)
        {
            var playerLevelResult = new PlayerLevelResult(this, player, result);
            _players.Add(playerLevelResult.Player.Id, playerLevelResult);
            
            UpdatePlayerResultsList();
        }
        
        public void RemovePlayer(GUID playerId)
        {
            if (_players.ContainsKey(playerId))
            {
                _players.Remove(playerId);
                UpdatePlayerResultsList();
            }
        }

        public void UpdatePlayerLevelInfo(GUID playerId, int newResult)
        {
            if (!_players.ContainsKey(playerId))
                return;
            
            var player = _players[playerId];
            player.UpdatePlayerResult(newResult);
        }

        private void UpdatePlayerResultsList()
        {
            PlayersResults.Clear();
            PlayersResults.AddRange(_players.Values);
            PlayersResults.Sort();
        }
        public int CompareTo(Level other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}