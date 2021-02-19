using System;

namespace Models
{
    [Serializable]
    public class PlayerLevelResult: IComparable<PlayerLevelResult>
    {
        public readonly Level Level;
        public readonly Player Player;
        public int Result;

        public PlayerLevelResult(Level level, Player player, int result = 0)
        {
            Level = level;
            Player = player;
            Result = result;
        }

        public void UpdatePlayerResult(int result)
        {
            Result = result;
        }
        
        public int CompareTo(PlayerLevelResult other)
        {
            var i = Result.CompareTo(other.Result);
            if (i == 0)
                i = Level.Name.CompareTo(other.Level.Name);

            if (i == 0)
                i = Player.Name.CompareTo(other.Player.Name);

            return i;
        }
    }
}