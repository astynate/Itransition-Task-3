using ConsoleTables;

namespace Itransition_Task_3
{
    public static class Menu
    {
        public static (string? error, Action? action) PrintAsk(Dictionary<string, Action> actions)
        {
            PrintMenu();

            for (int i = 0; i < actions.Count; i++)
            {
                Console.WriteLine($"{i} — {actions.ElementAt(i).Key}");
            }

            PrintDevide();

            return int.TryParse(Console.ReadLine(), out int value) ? 
                (null, actions.ElementAt(value).Value) : ("Invalid line", null);
        }

        public static void PrintTable(Move[] moves)
        {
            var table = new ConsoleTable("Player", "Computer", "Result", "ValidateCode");

            for (int i = 0; i < moves.Length; i++)
            {
                table.AddRow(
                    moves[i].PlayerMove!.Value,
                    moves[i].ComputerMove!.Value,
                    moves[i].Result!.Value,
                    moves[i].Code!.Value
                );
            }

            table.Write();
        }

        public static void PrintDevide() => Console.WriteLine("==========================================");
        public static void PrintMenu() => Console.WriteLine("====================MENU==================");
    }
}