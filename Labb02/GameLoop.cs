using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Xml.Linq;

class GameLoop
{
    public static Player player = LevelData.player;
    public static void Run()
    {
        Console.CursorVisible = false;

        while (true)
        {
            Console.ResetColor();
            Console.SetCursorPosition(0, 0);
            Console.Write(new string (' ', Console.WindowWidth));

            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Player: {player.Health} HP");

            Vision.PrintVision();

            var input = Console.ReadKey();
            switch (input.Key)
            {
                case ConsoleKey.RightArrow:
                    Movement.MoveRight(player);             
                    break;

                case ConsoleKey.LeftArrow:
                    Movement.MoveLeft(player);
                    break;

                case ConsoleKey.DownArrow:
                    Movement.MoveDown(player);
                    break;

                case ConsoleKey.UpArrow:
                    Movement.MoveUp(player);
                    break;
                default:
                    Movement.InvalidInput();
                    break;
            }

            if (player.Health <= 0)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                break;
            }

            Movement.MoveEnemies(LevelData.Elements);
        }
    }
}