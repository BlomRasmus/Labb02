using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LevelData
{
    private static List<LevelElements> elements = new List<LevelElements>();

    public static List<LevelElements> Elements { get { return elements;  } }

    public static Player player;

    public static int Rows { get; set; }

    public void Load(string fileName)
    {
        StreamReader file = new StreamReader(fileName);
        string fileLine;
        int row = 1;

        while ((fileLine = file.ReadLine()) != null)
        {

            for (int i = 0; i < fileLine.Length; i++)
            {

                if (fileLine[i] == '#')
                {
                    Wall wall = new Wall() { Position = new Positions { X = i, Y = row + 2 } };
                    elements.Add(wall);
                }
                else if (fileLine[i] == 'r')
                {
                    Rat rat = new Rat() { Position = new Positions { X = i, Y = row + 2} };
                    elements.Add(rat);
                }
                else if (fileLine[i] == 's')
                {
                    Snake snake = new Snake() { Position = new Positions { X = i, Y = row +2 } };
                    elements.Add(snake);
                }
                else if (fileLine[i] == '@')
                {
                    player = new Player() { Position = new Positions { X = i, Y = row + 2} };
                    elements.Add(player);
                }
                else
                {
                    continue;
                }
            }

            row++;

        }

        Rows = row;
    }
}

