using System;
using System.Collections.Generic;
using Models;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu][Serializable]
    public class ScoreTable : ScriptableObject
    {
        [SerializeField] private List<Player> Players = new List<Player>();
        
        private Dictionary<GUID, Player> _players = new Dictionary<GUID, Player>();

        public void AddPlayer(string newPlayerName)
        {
            var player = new Player(newPlayerName);
            _players.Add(player.Id, player);
            
            Players.Clear();
            Players.AddRange(_players.Values);
        }
        
        public void RemovePlayer(GUID playerId)
        {
            _players.Remove(playerId);
        }

        public void UpdatePlayerLevelInfo(GUID playerId, PlayerLevelResult levelResult)
        {
            var player = _players[playerId];
            player.UpdateLevelInfo(levelResult);
        }
    }
}
