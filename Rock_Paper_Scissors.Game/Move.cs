namespace Rock_Paper_Scissors.Game
{
    public class Move
    {
        public string Player { get; set; }
        public string MoveType { get; set; }

        public override string ToString()
        {
            return "Jogador " + Player + ", jogada " + MoveType;
        }
    }
}