

using System.IO;


var fileName = "Level\\Level1.txt";

LevelData levelData = new LevelData();
levelData.Load(fileName);

GameLoop.Run();

