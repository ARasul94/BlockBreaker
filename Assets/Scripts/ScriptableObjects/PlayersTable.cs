using System;
using System.Collections.Generic;
using Enums;
using Helpers;
using Models;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
    [CreateAssetMenu][Serializable]
    public class PlayersTable : ScriptableObject
    {
        [SerializeField] private List<Player> players = new List<Player>();
        private Dictionary<string, Player> _players = new Dictionary<string, Player>();
        
        public Player AddPlayer(string playerName)
        {
            if (_players.ContainsKey(playerName))
                throw new PlayerTableException(PlayerTableErrors.PLAYER_WITH_SUCH_NAME_ALREADY_EXIST);
            var player = new Player(playerName);
            _players.Add(playerName, player);
            
            players.Clear();
            players.AddRange(_players.Values);
            players.Sort();
            
            return player;
        }
        
        public void RemovePlayer(Player player)
        {
            if (_players.ContainsKey(player.Name))
                _players.Remove(player.Name);
        }

        public List<Player> GetPlayers()
        {
            return players;
        }
    }
}
