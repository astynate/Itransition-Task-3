namespace Itransition_Task_3
{
    public class Game
    {
        private readonly Moves[]? _computerMoves;

        private readonly ValidateCode[]? _validateCodes;

        private readonly List<Move> _moves = new List<Move>();

        private int _index = 0;

        public Game(string[] computerMoves)
        {
            if (computerMoves.Length == 0 || computerMoves.Length % 2 == 0)
            {
                Console.WriteLine("Invalid arguments!"); return;
            }

            _computerMoves = new Moves[computerMoves.Length];
            _validateCodes = new ValidateCode[computerMoves.Length];

            for (int i = 0; i < computerMoves.Length; i++)
            {
                if (int.TryParse(computerMoves[i], out int value) && Enum.IsDefined(typeof(Moves), value))
                {
                    _computerMoves[i] = (Moves)value;
                }
                else if (Enum.TryParse(typeof(Moves), computerMoves[i], true, out object? move))
                {
                    _computerMoves[i] = (Moves)move;
                }
                else
                {
                    Console.WriteLine("Invalid arguments!"); return;
                }

                _validateCodes[i] = new ValidateCode(_computerMoves[i]); 
            }

            GamePlay();
        }

        public void GamePlay()
        {
            if (_computerMoves == null)
            {
                Console.WriteLine("Invalid arguments!"); return;
            }

            _index = 0;

            for (int i = 0; i < _computerMoves.Length; i ++)
            {
                Menu.PrintDevide();

                if (_validateCodes != null)
                {
                    Console.WriteLine($"HMAC: {_validateCodes[_index].Value}");
                }

                Dictionary<string, Action> actions = new Dictionary<string, Action>() 
                {
                    { "Scissors", UseScissors },
                    { "Rock", UseRock },
                    { "Paper", UsePaper }
                };

                var result = Menu.PrintAsk(actions);

                if (result.error != null || result.action == null)
                {
                    Console.WriteLine(result.error); return;
                }

                result.action(); _index = i;
            }

            Menu.PrintDevide();
            Menu.PrintTable(_moves.ToArray());
        }

        public void SetInstance(Moves type)
        {
            if (_computerMoves == null || _validateCodes == null)
            {
                Console.WriteLine("Something went wrong"); return;
            }

            _moves.Add(new Move(
                type, 
                _computerMoves[_index], 
                _validateCodes[_index])
            );

            Console.WriteLine($"HMAC key: {_validateCodes[_index].Key}");
            Console.WriteLine($"Your move: {_moves[_index].PlayerMove!.Value}");
            Console.WriteLine($"Computer move: {_moves[_index].ComputerMove!.Value}");
            Console.WriteLine($"Result: {_moves[_index].Result!.Value}");
        }

        public void UseScissors() => SetInstance(Moves.Scissors);
        public void UseRock() => SetInstance(Moves.Rock);
        public void UsePaper() => SetInstance(Moves.Paper);
    }
}