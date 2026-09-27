namespace RpsTournament.Core
{
    public struct GameRound
    {
        public int RoundNumber { get; set; }
        public Move PlayerMove { get; set; }
        public Move ComputerMove { get; set; }
        public RoundResult Result { get; set; }

        public GameRound(int roundNumber, Move playerMove,
            Move computerMove, RoundResult result)
        {
            RoundNumber = roundNumber;
            PlayerMove = playerMove;
            ComputerMove = computerMove;
            Result = result;
        }
    }
}