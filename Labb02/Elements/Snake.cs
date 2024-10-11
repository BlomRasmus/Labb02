using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


internal class Snake : Enemy
{
    public Snake()
    {
        elementChar = 's';
        color = ConsoleColor.Green;
        Health = 25;
        AttackDice = new Dice(3, 4, 2);
        DefenceDice = new Dice(1, 8, 5);
    }

    public override void Update()
    {
        MoveSnake(this);
    }

    private void MoveSnake(Enemy snake)
    {
        int deltaX = snake.Position.X - LevelData.player.Position.X;
        int deltaY = snake.Position.Y - LevelData.player.Position.Y;

        double distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));

        if (distance <= 2)
        {
            MoveAwayFromPlayer(snake, LevelData.player.Position, snake.Position);
        }
        else if (distance > 4)
        {
            Console.SetCursorPosition(snake.Position.X, snake.Position.Y);
            Console.Write(' ');
        }
    }

    private void MoveAwayFromPlayer(Enemy snake, Positions playerPos, Positions snakePos)
    {
        if(playerPos.X < snakePos.X)
        {
            Movement.MoveRight(snake);
        }
        else if (playerPos.X > snakePos.X)
        {
            Movement.MoveLeft(snake);
        }
        else if(playerPos.Y < snakePos.Y)
        {
            Movement.MoveDown(snake);
        }
        else if (playerPos.Y > snakePos.Y)
        {
            Movement.MoveUp(snake);
        }
    }

    public override string ToString()
    {
        return "The Snake";
    }
}

