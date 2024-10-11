using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Enemy : LevelElements
{
    public int Health { get; set; }

    public Dice AttackDice { get; set; }
    public Dice DefenceDice { get; set; }

    public abstract void Update();

    public static void AttackingEnemy(Enemy enemy, Player player)
    {
        int attack = enemy.AttackDice.Throw();
        int defence = GameLoop.player.DefenceDice.Throw();
        int damage = attack - defence;


        if (damage <= 0)
        {
            damage = 0;
        }

        Console.ForegroundColor = enemy.color;
        if (enemy.Health <= 0)
        {
            Console.SetCursorPosition(0, 2);
            Console.WriteLine($"{enemy} is dead.".PadRight(Console.WindowWidth,' '));
        }
        else
        {
            Console.WriteLine($"{enemy}: {enemy.Health} HP, (ATK {enemy.AttackDice}) attacks for {attack} damage. You defend (DEF {GameLoop.player.DefenceDice}) {defence} damage, taking {damage}".PadRight(Console.BufferWidth, ' '));
            GameLoop.player.Health -= damage;
        }
        Console.ResetColor();

    }

    public static void MoveEnemies(List<LevelElements> elements)
    {
        var enemies = LevelData.Elements.OfType<Enemy>().ToList();
        for (int i = 0; i < enemies.Count(); i++)
        {
            enemies[i].Update();
        }
    }
}
