using System.IO;

#nullable disable
namespace Blood
{
  public class GameStorage
  {
    public string status = "";

    public GameData LoadGame()
    {
      this.status = "";
      GameData gameData = new GameData();
      gameData.fileExists = false;
      gameData.days = new byte[201];
      gameData.hats = (byte) 0;
      gameData.mats = (byte) 0;
      gameData.flashlight1 = (byte) 0;
      gameData.flashlight2 = (byte) 0;
      gameData.flashlight3 = (byte) 0;
      gameData.goggles = (byte) 0;
      gameData.map = new byte[20];
      gameData.ammobox1 = new byte[20];
      gameData.ammobox2 = new byte[20];
      gameData.ammobox3 = new byte[20];
      gameData.cog1 = new byte[20];
      gameData.cog2 = new byte[20];
      gameData.cog3 = new byte[20];
      gameData.exitkey = new byte[20];
      gameData.code1 = new byte[20, 3];
      gameData.code2 = new byte[20, 3];
      gameData.code3 = new byte[20, 3];
      gameData.redskull1 = (byte) 0;
      gameData.redskull2 = (byte) 0;
      gameData.redskull3 = (byte) 0;
      gameData.tusk1 = (byte) 0;
      gameData.tusk2 = (byte) 0;
      gameData.tusk3 = (byte) 0;
      gameData.heirloom = new byte[7];
      gameData.scarh = false;
      if (!File.Exists("SAVES//savegame"))
        return gameData;
      this.status = "";
      string path = "SAVES//savegame";
      try
      {
        using (BinaryReader binaryReader = new BinaryReader((Stream) File.Open(path, FileMode.Open)))
        {
          gameData.fileExists = binaryReader.ReadBoolean();
          gameData.fileVersion = binaryReader.ReadSingle();
          for (int index = 0; index < gameData.days.Length; ++index)
            gameData.days[index] = binaryReader.ReadByte();
          gameData.weaponsunlocked = binaryReader.ReadInt32();
          gameData.grinderunlocked = binaryReader.ReadInt32();
          gameData.charunlocked = binaryReader.ReadInt32();
          gameData.grenades = binaryReader.ReadByte();
          gameData.milks = binaryReader.ReadByte();
          gameData.bulkify = binaryReader.ReadByte();
          gameData.pills = binaryReader.ReadByte();
          gameData.mirv = binaryReader.ReadByte();
          gameData.hats = binaryReader.ReadByte();
          gameData.mats = binaryReader.ReadByte();
          gameData.man1 = binaryReader.ReadBoolean();
          gameData.man2 = binaryReader.ReadBoolean();
          gameData.man3 = binaryReader.ReadBoolean();
          gameData.man4 = binaryReader.ReadBoolean();
          gameData.flashlight1 = binaryReader.ReadByte();
          gameData.flashlight2 = binaryReader.ReadByte();
          gameData.flashlight3 = binaryReader.ReadByte();
          gameData.goggles = binaryReader.ReadByte();
          for (int index = 0; index < gameData.map.Length; ++index)
            gameData.map[index] = binaryReader.ReadByte();
          for (int index = 0; index < gameData.ammobox1.Length; ++index)
            gameData.ammobox1[index] = binaryReader.ReadByte();
          for (int index = 0; index < gameData.ammobox2.Length; ++index)
            gameData.ammobox2[index] = binaryReader.ReadByte();
          for (int index = 0; index < gameData.ammobox3.Length; ++index)
            gameData.ammobox3[index] = binaryReader.ReadByte();
          for (int index = 0; index < gameData.cog1.Length; ++index)
            gameData.cog1[index] = binaryReader.ReadByte();
          for (int index = 0; index < gameData.cog2.Length; ++index)
            gameData.cog2[index] = binaryReader.ReadByte();
          for (int index = 0; index < gameData.cog3.Length; ++index)
            gameData.cog3[index] = binaryReader.ReadByte();
          for (int index = 0; index < gameData.exitkey.Length; ++index)
            gameData.exitkey[index] = binaryReader.ReadByte();
          for (int index = 0; index < 20; ++index)
          {
            gameData.code1[index, 0] = binaryReader.ReadByte();
            gameData.code1[index, 1] = binaryReader.ReadByte();
            gameData.code1[index, 2] = binaryReader.ReadByte();
            gameData.code2[index, 0] = binaryReader.ReadByte();
            gameData.code2[index, 1] = binaryReader.ReadByte();
            gameData.code2[index, 2] = binaryReader.ReadByte();
            gameData.code3[index, 0] = binaryReader.ReadByte();
            gameData.code3[index, 1] = binaryReader.ReadByte();
            gameData.code3[index, 2] = binaryReader.ReadByte();
          }
          gameData.redskull1 = binaryReader.ReadByte();
          gameData.redskull2 = binaryReader.ReadByte();
          gameData.redskull3 = binaryReader.ReadByte();
          gameData.tusk1 = binaryReader.ReadByte();
          gameData.tusk2 = binaryReader.ReadByte();
          gameData.tusk3 = binaryReader.ReadByte();
          gameData.heirloom[0] = binaryReader.ReadByte();
          gameData.heirloom[1] = binaryReader.ReadByte();
          gameData.heirloom[2] = binaryReader.ReadByte();
          gameData.heirloom[3] = binaryReader.ReadByte();
          gameData.heirloom[4] = binaryReader.ReadByte();
          gameData.heirloom[5] = binaryReader.ReadByte();
          gameData.heirloom[6] = binaryReader.ReadByte();
          gameData.scarh = binaryReader.ReadBoolean();
          binaryReader.Close();
        }
      }
      catch
      {
        this.status = "fail";
      }
      return gameData;
    }

    public void SaveGame(GameData sg)
    {
      this.status = "";
      this.status = "";
      string path = "SAVES//savegame";
      if (!Directory.Exists("SAVES"))
        Directory.CreateDirectory("SAVES");
      try
      {
        using (BinaryWriter binaryWriter = new BinaryWriter((Stream) File.Open(path, FileMode.Create)))
        {
          binaryWriter.Write(true);
          binaryWriter.Write(sg.fileVersion);
          for (int index = 0; index < sg.days.Length; ++index)
            binaryWriter.Write(sg.days[index]);
          binaryWriter.Write(sg.weaponsunlocked);
          binaryWriter.Write(sg.grinderunlocked);
          binaryWriter.Write(sg.charunlocked);
          binaryWriter.Write(sg.grenades);
          binaryWriter.Write(sg.milks);
          binaryWriter.Write(sg.bulkify);
          binaryWriter.Write(sg.pills);
          binaryWriter.Write(sg.mirv);
          binaryWriter.Write(sg.hats);
          binaryWriter.Write(sg.mats);
          binaryWriter.Write(sg.man1);
          binaryWriter.Write(sg.man2);
          binaryWriter.Write(sg.man3);
          binaryWriter.Write(sg.man4);
          binaryWriter.Write(sg.flashlight1);
          binaryWriter.Write(sg.flashlight2);
          binaryWriter.Write(sg.flashlight3);
          binaryWriter.Write(sg.goggles);
          for (int index = 0; index < sg.map.Length; ++index)
            binaryWriter.Write(sg.map[index]);
          for (int index = 0; index < sg.ammobox1.Length; ++index)
            binaryWriter.Write(sg.ammobox1[index]);
          for (int index = 0; index < sg.ammobox2.Length; ++index)
            binaryWriter.Write(sg.ammobox2[index]);
          for (int index = 0; index < sg.ammobox3.Length; ++index)
            binaryWriter.Write(sg.ammobox3[index]);
          for (int index = 0; index < sg.cog1.Length; ++index)
            binaryWriter.Write(sg.cog1[index]);
          for (int index = 0; index < sg.cog2.Length; ++index)
            binaryWriter.Write(sg.cog2[index]);
          for (int index = 0; index < sg.cog3.Length; ++index)
            binaryWriter.Write(sg.cog3[index]);
          for (int index = 0; index < sg.exitkey.Length; ++index)
            binaryWriter.Write(sg.exitkey[index]);
          for (int index = 0; index < 20; ++index)
          {
            binaryWriter.Write(sg.code1[index, 0]);
            binaryWriter.Write(sg.code1[index, 1]);
            binaryWriter.Write(sg.code1[index, 2]);
            binaryWriter.Write(sg.code2[index, 0]);
            binaryWriter.Write(sg.code2[index, 1]);
            binaryWriter.Write(sg.code2[index, 2]);
            binaryWriter.Write(sg.code3[index, 0]);
            binaryWriter.Write(sg.code3[index, 1]);
            binaryWriter.Write(sg.code3[index, 2]);
          }
          binaryWriter.Write(sg.redskull1);
          binaryWriter.Write(sg.redskull2);
          binaryWriter.Write(sg.redskull3);
          binaryWriter.Write(sg.tusk1);
          binaryWriter.Write(sg.tusk2);
          binaryWriter.Write(sg.tusk3);
          binaryWriter.Write(sg.heirloom[0]);
          binaryWriter.Write(sg.heirloom[1]);
          binaryWriter.Write(sg.heirloom[2]);
          binaryWriter.Write(sg.heirloom[3]);
          binaryWriter.Write(sg.heirloom[4]);
          binaryWriter.Write(sg.heirloom[5]);
          binaryWriter.Write(sg.heirloom[6]);
          binaryWriter.Write(sg.scarh);
          binaryWriter.Close();
        }
      }
      catch
      {
      }
    }
  }
}
