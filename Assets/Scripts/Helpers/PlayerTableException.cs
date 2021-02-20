using System;
using Enums;

namespace Helpers
{
    public class PlayerTableException: Exception
    {
        public PlayerTableException(PlayerTableErrors error):base(error.ToString())
        {
        }
    }
}