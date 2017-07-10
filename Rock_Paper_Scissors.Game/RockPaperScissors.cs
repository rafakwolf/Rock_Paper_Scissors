using System;
using System.Collections.Generic;
using System.Linq;

namespace Rock_Paper_Scissors.Game
{
    public class RockPaperScissors
    {
        private readonly List<Move> _winnerList = new List<Move>();

        private bool IsValidMove(string move)
        {
            // P = Papel
            // R = Pedra
            // S = Tesoura

            return move.Equals("P") || move.Equals("R") || move.Equals("S");
        }

        private bool IsValidGame(IEnumerable<Move> game)
        {
            return game.All(move => IsValidMove(move.MoveType));
        }

        private bool WinnerIs(List<Move> game)
        {
            // Verdadeiro se:
            // --------------
            // - Os dois jogadores tiverem a mesma jogada
            // - R > S
            // - S > P
            // - P > R

            return (game.First().MoveType == game.Last().MoveType) ||
                  (game.First().MoveType == "R" && game.Last().MoveType == "S") ||
                  (game.First().MoveType == "S" && game.Last().MoveType == "P") ||
                  (game.First().MoveType == "P" && game.Last().MoveType == "R");
        }

        public Move Rps_game_winner(List<Move> game)
        {
            if (game.Count != 2)
                throw new WrongNumberOfPlayersError();

            if (!IsValidGame(game))
                throw new NoSuchStrategyError();

            return WinnerIs(game) ? game.First() : game.Last();
        }

        private static IEnumerable<List<T>> SplitList<T>(List<T> locations, int nSize = 2)
        {
            for (var i = 0; i < locations.Count; i += nSize)
            {
                yield return locations.GetRange(i, Math.Min(nSize, locations.Count - i));
            }
        }

        private static Tournament NewTournament(List<Move> winners)
        {
            var newTournament = new Tournament();

            var newDoubles = SplitList(winners);
            newTournament.AddRange(newDoubles);

            return newTournament;
        }

        public Move Rps_tournament_winner(Tournament tournament)
        {
            while (true)
            {
                foreach (var moves in tournament)
                {
                    var winner = Rps_game_winner(moves);
                    _winnerList.Add(winner);
                }

                if (!_winnerList.Any())
                    throw new Exception("Something is wrong!");

                if (_winnerList.Count == 1)
                    return _winnerList.First();

                var newTournament = NewTournament(_winnerList);
                _winnerList.Clear();

                tournament = newTournament;
            }
        }
    }
}