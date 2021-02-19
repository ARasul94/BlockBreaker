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
        public GUID Id => _id;
        private GUID _id;

        public Player(string name)
        {
            Name = name;
            _id = GUID.Generate();
        }

        public int CompareTo(Player player)
        {
            return Name.CompareTo(player.Name);
        }
    }
}