using System.Xml.Linq;

static class Movement
{
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

    public static void Attack(LevelElements attackingElement, LevelElements defendingElement)
    {

        if (attackingElement is Enemy && defendingElement is Player)
        {

            Console.SetCursorPosition(0, 1);
            Enemy.AttackingEnemy(attackingElement as Enemy, GameLoop.player);
            if((defendingElement as Player).Health > 0)
            {
                defendingElement = attackingElement;
                Player.AttackingPlayer(GameLoop.player, defendingElement as Enemy);
            }
        }
        else if(attackingElement is Player && defendingElement is Enemy)
        {
            Console.SetCursorPosition(0, 1);
            Player.AttackingPlayer(GameLoop.player, defendingElement as Enemy);
            attackingElement = defendingElement;
            Enemy.AttackingEnemy(attackingElement as Enemy, GameLoop.player);
           
        }
    }

}