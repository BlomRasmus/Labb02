using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class Enemy : LevelElements
{
    public int Health { get; set; }

    public Dice AttackDice { get; set; }
    public Dice DefenceDice { get; set; }

    public abstract void Update();
}
