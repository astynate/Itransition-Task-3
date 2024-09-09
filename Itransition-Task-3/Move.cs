namespace Itransition_Task_3
{
    public class Move
    {
        public Moves? PlayerMove { get; private set; }
        public Moves? ComputerMove { get; private set; }
        public Results? Result { get; private set; }
        public ValidateCode? Code { get; private set; }

        public Move(Moves player, Moves computer, ValidateCode code) 
        {
            PlayerMove = player;
            ComputerMove = computer;
            Result = GetMoveResult(player, computer);
            Code = code;
        }

        public static Results GetMoveResult(Moves? playerMoveValue, Moves? computerMoveValue)
        {
            List<(Moves one, Moves two, int result)> results = [
                (Moves.Paper, Moves.Scissors, -1),
                (Moves.Paper, Moves.Rock, 1),
                (Moves.Scissors, Moves.Rock, -1),
            ];

            Results result = Results.Lose;

            if (playerMoveValue == computerMoveValue)
            {
                return Results.Draw;
            }

            foreach (var value in results)
            {
                if (value.one == playerMoveValue && value.two == computerMoveValue)
                {
                    result = (Results)value.result; break;
                }
                
                if (value.one == computerMoveValue && value.two == playerMoveValue)
                {
                    result = (Results)(-1 * value.result); break;
                }
            }

            return result;
        }
    }
}