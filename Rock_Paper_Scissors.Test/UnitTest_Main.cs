using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rock_Paper_Scissors.Game;

namespace Rock_Paper_Scissors.Test
{
    [TestClass]
    public class UnitTestMain
    {
        [TestMethod]
        [ExpectedException(typeof(WrongNumberOfPlayersError))]
        public void Test_should_be_not_valid_game()
        {
           var moves = new List<Move>
            {
                new Move {MoveType = "P", Player = "Armando"},
                new Move {MoveType = "S", Player = "Dave"},
                new Move {MoveType = "S", Player = "Michael"}
            };

            var rps = new RockPaperScissors();
            rps.Rps_game_winner(moves);
        }

        [TestMethod]
        [ExpectedException(typeof(NoSuchStrategyError))]
        public void Test_should_be_wrong_strategy()
        {
            var moves = new List<Move>
            {
                new Move {MoveType = "W", Player = "Armando"},
                new Move {MoveType = "X", Player = "Dave"},
            };

            var rps = new RockPaperScissors();
            rps.Rps_game_winner(moves);
        }

        [TestMethod]
        public void Test_should_be_valid_game()
        {
            // arrange
            var moves = new List<Move>
            {
                new Move {MoveType = "P", Player = "Armando"},
                new Move {MoveType = "S", Player = "Dave"},
            };

            // act
            var rps = new RockPaperScissors();
            var winner = rps.Rps_game_winner(moves);

            // assert
            Assert.IsNotNull(winner);
            Assert.AreEqual(winner.Player, "Dave");
        }

        [TestMethod]
        public void Test_Richard_winner()
        {
            // arrange
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

            // act
            var rps = new RockPaperScissors();
            var winner = rps.Rps_tournament_winner(tournament);

            // assert
            Assert.IsNotNull(winner);
            Assert.AreEqual(winner.Player, "Richard");
            Assert.AreEqual(winner.MoveType, "R");
        }
    }
}
