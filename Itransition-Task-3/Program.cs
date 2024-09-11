using Itransition_Task_3;

var game = Game.Create(args);

if (game.error != null || game.instance == null)
{
    Console.WriteLine(game.error);
    Console.ReadKey(); return;
}

game.instance.Start();