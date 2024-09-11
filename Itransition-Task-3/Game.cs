namespace Itransition_Task_3
{
    public class Game
    {
        private readonly string[] _moveOptions;

        private readonly string[] _actions;

        private readonly List<Move> _moves = new List<Move>();
        
        private readonly Action[] _additionalActions;

        private int _index = 0;

        private Game(string[] moveOptions)
        {
            _moveOptions = moveOptions;
            _actions = _moveOptions.Concat(["Help", "Games", "Exit"]).ToArray();
            _additionalActions = [HandleHelpTable, HandleGamesTable, HandleExit];
        }

        public void Start()
        {
            Console.WriteLine("Welcome to Itransition Task 3!");

            while (_index < _moveOptions.Length)
            {
                Menu.PrintDevide();

                var move = GetRandomMove();
                var code = new ValidationCode(move.name);

                Console.WriteLine($"HMAC: {code.Value}");

                var result = Menu.PrintAsk(_actions);
                var additionalIndex = result - _moveOptions.Length;

                if (additionalIndex >= 0)
                {
                    _additionalActions[additionalIndex % _moveOptions.Length]();
                    continue;
                }

                HandlePlayerMove(result, move.index, code);
            }
        }

        public (string name, int index) GetRandomMove()
        {
            var random = new Random();
            var result = random.Next(0, _moveOptions.Length);

            return (_moveOptions[result], result);
        }

        static bool AreElementsUnique(string[] array)
        {
            HashSet<string> seenElements = new HashSet<string>();
            
            foreach (var element in array)
            {
                if (!seenElements.Add(element))
                {
                    return false;
                }
            }

            return true;
        }

        public static (string? error, Game? instance) Create(string[] moveOptions)
        {
            var lengthError = moveOptions.Length == 0 || moveOptions.Length == 1 || moveOptions.Length % 2 == 0;
            var errorMessage = "You entered incorrect data :( You must enter an odd number of moves like this: 0 1 2";

            if (lengthError || AreElementsUnique(moveOptions) == false)
            {
                return (errorMessage, null);
            }

            return (null, new Game(moveOptions));
        }

        public void HandlePlayerMove(int player, int computer, ValidationCode code)
        {
            var move = new Move(player, computer, code, _moveOptions.Length);
            Menu.PrintMoveData(move, _moveOptions); 
            
            _index++; 
            _moves.Add(move);
        }

        public void HandleHelpTable()
        {
            Menu.PrintHelpTable(_moveOptions);
        }

        public void HandleGamesTable()
        {
            Menu.PrintTable(_moves.ToArray());
        }

        public void HandleExit()
        {
            _index = _moveOptions.Length; Console.WriteLine("Game over!"); Menu.PrintDevide();
        }
    }
}