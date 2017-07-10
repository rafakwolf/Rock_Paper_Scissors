using System;

namespace Rock_Paper_Scissors.Game
{
    public class NoSuchStrategyError : Exception
    {
        public NoSuchStrategyError() : base("Estratégia inexistente!")
        {
        }
    }
}