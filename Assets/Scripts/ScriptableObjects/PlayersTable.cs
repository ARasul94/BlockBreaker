using System;
using System.Collections.Generic;
using Models;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu][Serializable]
    public class PlayersTable : ScriptableObject
    {
        [SerializeField] private List<Player> Players = new List<Player>();
        private Dictionary<GUID, Player> _players = new Dictionary<GUID, Player>();
        
        public void AddPlayer(string playerName)
        {
            var player = new Player(playerName);
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

        public void UpdatePlayerInfo(GUID playerId, Player player)
        {
            if (!_players.ContainsKey(playerId))
                return;

            _players[playerId] = player;
        }
    }
}
