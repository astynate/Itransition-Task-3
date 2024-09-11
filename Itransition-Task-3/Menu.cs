using ConsoleTables;

namespace Itransition_Task_3
{
    public static class Menu
    {
        public static int PrintAsk(string[] actions)
        {
            PrintMenu();

            for (int i = 0; i < actions.Length; i++)
            {
                Console.WriteLine($"{i} — {actions[i]}");
            }

            var result = -1;
            var isWrong = (int value) => value < 0 || value > actions.Length - 1;

            while (isWrong(result)) 
            {
                PrintDevide();
                bool outputValue = int.TryParse(Console.ReadLine(), out int value);

                if (!outputValue || isWrong(value))
                {
                    PrintDevide();
                    Console.WriteLine("This option doesn't exist :(");
                    continue;
                }

                result = value;
            }

             return result;
        }

        public static void PrintTable(Move[] moves)
        {
            var table = new ConsoleTable("Player", "Computer", "Result", "ValidationCode");

            for (int i = 0; i < moves.Length; i++)
            {
                table.AddRow(
                    moves[i].PlayerMoveIndex,
                    moves[i].ComputerMoveIndex,
                    moves[i].Result,
                    moves[i].Code!.Value
                );
            }

            table.Write();
        }

        public static void PrintMoveData(Move move, string[] moveOptions)
        {
            Console.WriteLine($"HMAC key: {move.Code.Key}");
            Console.WriteLine($"Your move: {moveOptions[move.PlayerMoveIndex]}");
            Console.WriteLine($"Computer move: {moveOptions[move.ComputerMoveIndex]}");
            Console.WriteLine($"Result: {move.Result}");
        }

        public static void PrintDevide() => Console.WriteLine("==========================================");
        public static void PrintMenu() => Console.WriteLine("====================MENU==================");
    }
}