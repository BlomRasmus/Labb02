using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

public class Player : LevelElements
{
    public int Health { get; set; }
    public Dice AttackDice { get; set; }
    public Dice DefenceDice { get; set; }


    public Player()
    {
        color = ConsoleColor.Blue;
        elementChar = '@';
        Health = 100;
        AttackDice = new Dice(2, 6, 2);
        DefenceDice = new Dice(2, 6, 0);
    }

    public static void AttackingPlayer(Player player, Enemy enemy)
    {
        int attack = GameLoop.player.AttackDice.Throw();
        int defence = enemy.DefenceDice.Throw();
        int damage = attack - defence;


        if (damage <= 0)
        {
            damage = 0;
        }

        enemy.Health -= damage;

        if (enemy.Health <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Player: (ATK {GameLoop.player.AttackDice}): the player attacks for {attack} damage, killing {enemy} immediately".PadRight(Console.BufferWidth, ' '));
            Console.ResetColor();

            Console.SetCursorPosition(enemy.Position.X, enemy.Position.Y);
            Console.Write(' ');
            LevelData.Elements.Remove(enemy);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Player: (ATK {GameLoop.player.AttackDice}): the player attacks for {attack} damage. {enemy} (DEF {enemy.DefenceDice}) defends {defence} damage, taking {damage}".PadRight(Console.BufferWidth, ' '));
            Console.ResetColor();
        }
    }

    public void MovePlayer()
    {
        var input = Console.ReadKey();
        switch (input.Key)
        {
            case ConsoleKey.RightArrow:
                Movement.MoveRight(this);
                break;

            case ConsoleKey.LeftArrow:
                Movement.MoveLeft(this);
                break;

            case ConsoleKey.DownArrow:
                Movement.MoveDown(this);
                break;

            case ConsoleKey.UpArrow:
                Movement.MoveUp(this);
                break;
            default:
                Movement.InvalidInput();
                break;
        }
    }

    public void PrintGameOver()
    {
        Console.SetCursorPosition(0, 0);
        Console.Clear();
        Console.WriteLine("YOU DIED!");
        Console.WriteLine();
        Console.WriteLine("GAME OVER!");
        Console.ReadKey(true);
    }

    public void PrintVision()
    {

        for (int i = 0; i < LevelData.Elements.Count; i++)
        {
            int deltaX = LevelData.player.Position.X - LevelData.Elements[i].Position.X;
            int deltaY = LevelData.player.Position.Y - LevelData.Elements[i].Position.Y;
            double distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));

            if (distance <= 4)
            {
                LevelData.Elements[i].Draw();
            }

        }
    }
}

