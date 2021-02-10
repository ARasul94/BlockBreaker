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
        [SerializeField] private List<Player> Players = new List<Player>();
        
        private Dictionary<GUID, Player> _players = new Dictionary<GUID, Player>();
        
        public GUID Id => _id;

        private GUID _id;

        public Level(string levelName)
        {
            Name = levelName;
            _id = GUID.Generate();
        }

        public void AddPlayer(string newPlayerName, int result)
        {
            var player = new Player(newPlayerName, result);
            _players.Add(player.Id, player);
            
            Players.Clear();
            Players.AddRange(_players.Values);
            Players.Sort();
        }
        
        public void RemovePlayer(GUID playerId)
        {
            if (_players.ContainsKey(playerId))
                _players.Remove(playerId);
        }

        public void UpdatePlayerLevelInfo(GUID playerId, int newResult)
        {
            if (!_players.ContainsKey(playerId))
                return;
            
            var player = _players[playerId];
            player.UpdatePlayerResult(newResult);
        }

        public int CompareTo(Level other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}