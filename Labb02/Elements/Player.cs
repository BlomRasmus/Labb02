using System;
using System.Collections.Generic;
using System.Linq;
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
}

