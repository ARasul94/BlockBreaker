using System;
using System.Collections.Generic;
using Enums;
using Helpers;
using Models;
using UnityEngine;

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
            
            UpdatePlayerList();
            
            return player;
        }
        
        public bool RemovePlayer(Player player)
        {
            try
            {
                if (_players.ContainsKey(player.Name))
                {
                    _players.Remove(player.Name);
                    UpdatePlayerList();
                    return true;
                }

                Debug.LogError(new PlayerTableException(PlayerTableErrors.PLAYER_NOT_EXIST));
                return false;

            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
                throw new PlayerTableException(PlayerTableErrors.ERROR_ON_DELETE_PLAYER);
            }
        }

        public List<Player> GetPlayers()
        {
            return players;
        }

        private void UpdatePlayerList()
        {
            players.Clear();
            players.AddRange(_players.Values);
            players.Sort();
        }
    }
}
