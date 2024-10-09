using System.Xml.Linq;

public class Vision
{

    public static void PrintVision()
    {

        for (int i = 0; i < LevelData.Elements.Count; i++)
        {
            int deltaX = LevelData.player.Position.X - LevelData.Elements[i].Position.X;
            int deltaY = LevelData.player.Position.Y - LevelData.Elements[i].Position.Y;
            double distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));

            if(distance <= 4)
            {
                LevelData.Elements[i].Draw();
            }

        }
    }


}
