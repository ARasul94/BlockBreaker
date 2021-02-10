using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class Player: IComparable<Player>
    {
        public string Name;
        public int Result;
        public GUID Id => _id;

        private GUID _id;

        public Player(string name, int result)
        {
            Name = name;
            Result = result;
            _id = GUID.Generate();
        }

        public void UpdatePlayerResult(int result)
        {
            Result = result;
        }

        public int CompareTo(Player player)
        {
            var i = Result.CompareTo(player.Result);
            if (i == 0)
                i = Name.CompareTo(player.Name);

            return i;
        }
    }
}