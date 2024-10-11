using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Rat : Enemy
{
    public Rat()
    {
        color = ConsoleColor.Red;
        elementChar = 'r';
        Health = 10;
        AttackDice = new Dice(1, 6, 3);
        DefenceDice = new Dice(1, 6, 1);
    }

    public override void Update()
    {
        MoveRat(this);
    }

    private void MoveRat(Enemy rat)
    {
        Random randomDirection = new Random();
                
        switch(randomDirection.Next(1, 5))
        {
            case 1:
                Movement.MoveRight(rat);
                break;

            case 2:
                Movement.MoveLeft(rat);
                break;

            case 3:
                Movement.MoveDown(rat);
                break;

            case 4:
                Movement.MoveUp(rat);
                break;
        }

    }

    public override string ToString()
    {
        return ("The Rat");
    }

}

