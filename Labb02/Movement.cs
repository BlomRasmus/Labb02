using System.Xml.Linq;

class Movement
{
    public static void MoveEnemies(List<LevelElements> elements)
    {
        var enemies = LevelData.Elements.OfType<Enemy>().ToList();
        for (int i = 0; i < enemies.Count(); i++)
        {
            enemies[i].Update();
        }
    }

    public static void MoveRight(LevelElements element)
    {
        Positions testPosition = new Positions { X = element.Position.X + 1, Y = element.Position.Y };

        bool move = IsColliding(element, testPosition);

        if (move == true)
        {
            Console.SetCursorPosition(element.Position.X, element.Position.Y);
            Console.Write(' ');
            element.Position.X++;

            if (element is Player)
            {
                element.Draw();
            }
        }
    }

    public static void MoveLeft(LevelElements element)
    {
        Positions testPosition = new Positions { X = element.Position.X - 1, Y = element.Position.Y };

        bool move = IsColliding(element, testPosition);

        if (move == true)
        {
            Console.SetCursorPosition(element.Position.X, element.Position.Y);
            Console.Write(' ');
            element.Position.X--;

            if (element is Player)
            {
                element.Draw();
            }
        }
    }

    public static void MoveDown(LevelElements element)
    {
        Positions testPosition = new Positions { X = element.Position.X, Y = element.Position.Y + 1 };

        bool move = IsColliding(element, testPosition);

        if (move == true)
        {
            Console.SetCursorPosition(element.Position.X, element.Position.Y);
            Console.Write(' ');
            element.Position.Y++;

            if (element is Player)
            {
                element.Draw();
            }
        }
    }

    public static void MoveUp(LevelElements element)
    {
        Positions testPosition = new Positions { X = element.Position.X, Y = element.Position.Y - 1 };

        bool move = IsColliding(element, testPosition);

        if (move == true)
        {
            Console.SetCursorPosition(element.Position.X, element.Position.Y);
            Console.Write(' ');
            element.Position.Y--;

            if (element is Player)
            {
                element.Draw();
            }
        }
    }

    public static void InvalidInput()
    {
        return;
    }

    public static bool IsColliding(LevelElements movingElement, Positions positions)
    {
        bool move = false;

        for (int i = 0; i < LevelData.Elements.Count; i++)
        {
            if (positions.X == LevelData.Elements[i].Position.X && positions.Y == LevelData.Elements[i].Position.Y)
            {
                Attack(movingElement, LevelData.Elements[i]);
                move = false;
                break;
            }
            else
            {
                move = true;
                continue;
            }
        }

        return move;
    }

    protected static void Attack(LevelElements attackingElement, LevelElements defendingElement)
    {
        if (attackingElement is Enemy && defendingElement is Player)
        {
            Console.SetCursorPosition(0, 1);
            AttackingEnemy(attackingElement as Enemy, defendingElement as Player);
            if((defendingElement as Player).Health > 0)
            {
                AttackingPlayer(defendingElement as Player, attackingElement as Enemy);
            }
        }
        else if(attackingElement is Player && defendingElement is Enemy)
        {
            Console.SetCursorPosition(0, 1);
            AttackingPlayer(attackingElement as Player, defendingElement as Enemy);

            if((defendingElement as Enemy).Health > 0)
            {
                AttackingEnemy(defendingElement as Enemy, GameLoop.player);
            }
        }
    }

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
        Console.WriteLine($"{enemy}: {enemy.Health} HP, {enemy.AttackDice}: {enemy} attacks for {attack} damage. You defend {defence} damage, taking {damage}".PadRight(Console.BufferWidth, ' '));
        Console.ResetColor();

        GameLoop.player.Health -= damage;
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
            Console.SetCursorPosition(0, 1);

            Console.Write(new string(' ', Console.WindowWidth));
            Console.Write(new string(' ', Console.WindowWidth));

            Console.SetCursorPosition(0, 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Player: {GameLoop.player.Health} HP, {GameLoop.player.AttackDice}: the player attacks for {attack} damage, killing {enemy} immediately");
            Console.ResetColor();

            Console.SetCursorPosition(enemy.Position.X, enemy.Position.Y);
            Console.Write(' ');
            LevelData.Elements.Remove(enemy);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Player: {GameLoop.player.AttackDice}: the player attacks for {attack} damage. {enemy} defends {defence} damage, taking {damage}".PadRight(Console.BufferWidth, ' '));
            Console.ResetColor();
        }
    }

}