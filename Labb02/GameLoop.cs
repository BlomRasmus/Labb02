using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Xml.Linq;

class GameLoop
{
    public static Player player = LevelData.player;
    public static void Run()
    {
        Console.CursorVisible = false;
        Console.Write("Please write your username: ");
        string userName = Console.ReadLine();
        int turnCounter = 1;

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Player: {userName} - {player.Health} HP - Turn: {turnCounter}".PadRight(Console.WindowWidth, ' '));
            Console.ResetColor();

            player.PrintVision();

            player.MovePlayer();

            Enemy.MoveEnemies(LevelData.Elements);

            if (player.Health <= 0)
            {
                player.PrintGameOver();
                break;
            }

            turnCounter++;
        }
    }
}