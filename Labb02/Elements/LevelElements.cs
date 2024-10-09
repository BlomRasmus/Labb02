using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

abstract public class LevelElements
{
    public Positions Position { get; set; }

    public char elementChar;

    public ConsoleColor color;

    public void Draw()
    {
        Console.ForegroundColor = this.color;
        Console.SetCursorPosition(this.Position.X, this.Position.Y);
        Console.Write(this.elementChar);
    }
}

