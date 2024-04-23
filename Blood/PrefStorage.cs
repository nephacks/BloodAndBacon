// Decompiled with JetBrains decompiler
// Type: Blood.PrefStorage
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using System.IO;

#nullable disable
namespace Blood
{
  public class PrefStorage
  {
    public string status = "";

    public PrefData LoadPreferences()
    {
      this.status = "";
      PrefData prefData = new PrefData();
      prefData.fileExists = false;
      prefData.lens = 58f;
      prefData.gore = 0;
      prefData.playername = "";
      prefData.aspectratio = 1f;
      prefData.star1 = false;
      prefData.star2 = false;
      prefData.star3 = false;
      string path = "SAVES//saveprefs";
      try
      {
        using (BinaryReader binaryReader = new BinaryReader((Stream) File.Open(path, FileMode.Open)))
        {
          prefData.fileExists = binaryReader.ReadBoolean();
          prefData.fileVersion = binaryReader.ReadSingle();
          prefData.mv = binaryReader.ReadSingle();
          prefData.ev = binaryReader.ReadSingle();
          prefData.vv = binaryReader.ReadSingle();
          prefData.df = binaryReader.ReadInt32();
          prefData.brightness = binaryReader.ReadInt32();
          prefData.contrast = binaryReader.ReadInt32();
          prefData.pad_invertY = binaryReader.ReadSingle();
          prefData.pad_sensitivity = binaryReader.ReadSingle();
          prefData.pad_vibro = binaryReader.ReadBoolean();
          prefData.hud_enemy.X = binaryReader.ReadSingle();
          prefData.hud_enemy.Y = binaryReader.ReadSingle();
          prefData.hud_clock.X = binaryReader.ReadSingle();
          prefData.hud_clock.Y = binaryReader.ReadSingle();
          prefData.hud_day.X = binaryReader.ReadSingle();
          prefData.hud_day.Y = binaryReader.ReadSingle();
          prefData.hud_player1.X = binaryReader.ReadSingle();
          prefData.hud_player1.Y = binaryReader.ReadSingle();
          prefData.hud_player2.X = binaryReader.ReadSingle();
          prefData.hud_player2.Y = binaryReader.ReadSingle();
          prefData.hud_weapons.X = binaryReader.ReadSingle();
          prefData.hud_weapons.Y = binaryReader.ReadSingle();
          prefData.hud_dpad.X = binaryReader.ReadSingle();
          prefData.hud_dpad.Y = binaryReader.ReadSingle();
          prefData.camradianA = binaryReader.ReadSingle();
          prefData.camheightA = binaryReader.ReadSingle();
          prefData.vector3_0.X = binaryReader.ReadSingle();
          prefData.vector3_0.Y = binaryReader.ReadSingle();
          prefData.vector3_0.Z = binaryReader.ReadSingle();
          prefData.camlookpos3rdA.X = binaryReader.ReadSingle();
          prefData.camlookpos3rdA.Y = binaryReader.ReadSingle();
          prefData.camlookpos3rdA.Z = binaryReader.ReadSingle();
          prefData.camradianB = binaryReader.ReadSingle();
          prefData.camheightB = binaryReader.ReadSingle();
          prefData.vector3_1.X = binaryReader.ReadSingle();
          prefData.vector3_1.Y = binaryReader.ReadSingle();
          prefData.vector3_1.Z = binaryReader.ReadSingle();
          prefData.camlookpos3rdB.X = binaryReader.ReadSingle();
          prefData.camlookpos3rdB.Y = binaryReader.ReadSingle();
          prefData.camlookpos3rdB.Z = binaryReader.ReadSingle();
          prefData.curDay = binaryReader.ReadUInt16();
          prefData.FarmerUnlocked = binaryReader.ReadBoolean();
          prefData.pad_reload = true;
          prefData.pad_togglesprint = binaryReader.ReadBoolean();
          prefData.aliasing = binaryReader.ReadInt32();
          prefData.resolution = binaryReader.ReadInt32();
          prefData.fullscreen = binaryReader.ReadInt32();
          prefData.aspectratio = binaryReader.ReadSingle();
          prefData.playername = binaryReader.ReadString();
          prefData.lens = binaryReader.ReadSingle();
          prefData.gore = binaryReader.ReadInt32();
          prefData.fastnades = binaryReader.ReadBoolean();
          prefData.star1 = binaryReader.ReadBoolean();
          prefData.star2 = binaryReader.ReadBoolean();
          prefData.star3 = binaryReader.ReadBoolean();
          prefData.doubleAmmo = binaryReader.ReadBoolean();
          prefData.workshopNum = binaryReader.ReadByte();
          binaryReader.Close();
        }
      }
      catch
      {
        this.status = "fail";
      }
      return prefData;
    }

    public void SavePreferences(PrefData sg)
    {
      this.status = "";
      this.status = "";
      string path = "SAVES//saveprefs";
      if (!Directory.Exists("SAVES"))
        Directory.CreateDirectory("SAVES");
      try
      {
        using (BinaryWriter binaryWriter = new BinaryWriter((Stream) File.Open(path, FileMode.Create)))
        {
          binaryWriter.Write(true);
          binaryWriter.Write(sg.fileVersion);
          binaryWriter.Write(sg.mv);
          binaryWriter.Write(sg.ev);
          binaryWriter.Write(sg.vv);
          binaryWriter.Write(sg.df);
          binaryWriter.Write(sg.brightness);
          binaryWriter.Write(sg.contrast);
          binaryWriter.Write(sg.pad_invertY);
          binaryWriter.Write(sg.pad_sensitivity);
          binaryWriter.Write(sg.pad_vibro);
          binaryWriter.Write(sg.hud_enemy.X);
          binaryWriter.Write(sg.hud_enemy.Y);
          binaryWriter.Write(sg.hud_clock.X);
          binaryWriter.Write(sg.hud_clock.Y);
          binaryWriter.Write(sg.hud_day.X);
          binaryWriter.Write(sg.hud_day.Y);
          binaryWriter.Write(sg.hud_player1.X);
          binaryWriter.Write(sg.hud_player1.Y);
          binaryWriter.Write(sg.hud_player2.X);
          binaryWriter.Write(sg.hud_player2.Y);
          binaryWriter.Write(sg.hud_weapons.X);
          binaryWriter.Write(sg.hud_weapons.Y);
          binaryWriter.Write(sg.hud_dpad.X);
          binaryWriter.Write(sg.hud_dpad.Y);
          binaryWriter.Write(sg.camradianA);
          binaryWriter.Write(sg.camheightA);
          binaryWriter.Write(sg.vector3_0.X);
          binaryWriter.Write(sg.vector3_0.Y);
          binaryWriter.Write(sg.vector3_0.Z);
          binaryWriter.Write(sg.camlookpos3rdA.X);
          binaryWriter.Write(sg.camlookpos3rdA.Y);
          binaryWriter.Write(sg.camlookpos3rdA.Z);
          binaryWriter.Write(sg.camradianB);
          binaryWriter.Write(sg.camheightB);
          binaryWriter.Write(sg.vector3_1.X);
          binaryWriter.Write(sg.vector3_1.Y);
          binaryWriter.Write(sg.vector3_1.Z);
          binaryWriter.Write(sg.camlookpos3rdB.X);
          binaryWriter.Write(sg.camlookpos3rdB.Y);
          binaryWriter.Write(sg.camlookpos3rdB.Z);
          binaryWriter.Write(sg.curDay);
          binaryWriter.Write(sg.FarmerUnlocked);
          binaryWriter.Write(sg.pad_togglesprint);
          binaryWriter.Write(sg.aliasing);
          binaryWriter.Write(sg.resolution);
          binaryWriter.Write(sg.fullscreen);
          binaryWriter.Write(sg.aspectratio);
          binaryWriter.Write(sg.playername);
          binaryWriter.Write(sg.lens);
          binaryWriter.Write(sg.gore);
          binaryWriter.Write(sg.fastnades);
          binaryWriter.Write(sg.star1);
          binaryWriter.Write(sg.star2);
          binaryWriter.Write(sg.star3);
          binaryWriter.Write(sg.doubleAmmo);
          binaryWriter.Write(sg.workshopNum);
          binaryWriter.Close();
        }
      }
      catch
      {
      }
    }
  }
}
