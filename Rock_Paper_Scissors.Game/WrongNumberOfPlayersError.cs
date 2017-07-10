using System;

namespace Rock_Paper_Scissors.Game
{
    public class WrongNumberOfPlayersError : Exception
    {
        public WrongNumberOfPlayersError() : base("Número incorreto de jogadores!")
        {
        }
    }
}