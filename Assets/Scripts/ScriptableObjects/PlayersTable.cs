using System;
using System.Collections.Generic;
using System.Linq;
using Enums;
using Helpers;
using Models;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu][Serializable]
    public class PlayersTable : ScriptableObject
    {
        [SerializeField] private List<Player> players;

        public Player AddPlayer(string playerName)
        {
            if (players == null)
                players = new List<Player>();
            
            if (players.Count(x => x.Name == playerName) > 0)
                throw new PlayerTableException(PlayerTableErrors.PLAYER_WITH_SUCH_NAME_ALREADY_EXIST);
            var player = new Player(playerName);

            players.Add(player);

            return player;
        }
        
        public bool RemovePlayer(Player player)
        {
            try
            {
                var tmpPlayer = players?.FirstOrDefault(x=> x.Id == player.Id);
                if (tmpPlayer != null)
                    players.Remove(tmpPlayer );

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
    }
}
