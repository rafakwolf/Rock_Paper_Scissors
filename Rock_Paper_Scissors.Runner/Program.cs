using System;
using System.Collections.Generic;
using Rock_Paper_Scissors.Game;

namespace Rock_Paper_Scissors.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var tournament = new Tournament {

                new List<Move>
                {
                    new Move {MoveType = "P", Player = "Armando"},
                    new Move {MoveType = "S", Player = "Dave"}
                },

                new List<Move>
                {
                    new Move {MoveType = "R", Player = "Richard"},
                    new Move {MoveType = "S", Player = "Michael"}
                },

                new List<Move>
                {
                    new Move {MoveType = "S", Player = "Allen"},
                    new Move {MoveType = "P", Player = "Omer"}
                },

                new List<Move>
                {
                    new Move {MoveType = "R", Player = "David E"},
                    new Move {MoveType = "P", Player = "Richard X"}
                }

            };


            // === Jogo === //


            Console.WriteLine("Escreva \"start\" para iniciar as jogadas.");

            if (Console.ReadLine() == "start")
            {
                var rps = new RockPaperScissors();
                var winner = rps.Rps_tournament_winner(tournament);

                Console.WriteLine(winner.ToString());
            }


            Console.ReadKey();
        }
    }
}
