namespace RpsTournament.Core
{
    public static class GameLogic
    {
        private static readonly Random random = new Random();

        public static Move GetComputerMove()
        {
            Move[] moves =
            {
                Move.Rock,
                Move.Paper,
                Move.Scissors
            };

            return moves[random.Next(moves.Length)];
        }

        public static RoundResult GetResult(Move player, Move computer)
        {
            if (player == computer)
                return RoundResult.Draw;

            if ((player == Move.Rock && computer == Move.Scissors) ||
                (player == Move.Paper && computer == Move.Rock) ||
                (player == Move.Scissors && computer == Move.Paper))
            {
                return RoundResult.PlayerWin;
            }

            return RoundResult.ComputerWin;
        }
    }
}