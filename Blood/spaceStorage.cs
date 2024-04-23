// Decompiled with JetBrains decompiler
// Type: Blood.spaceStorage
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using System.IO;

#nullable disable
namespace Blood
{
  public class spaceStorage
  {
    public string status = "";

    public SpaceData LoadPreferences()
    {
      this.status = "";
      SpaceData spaceData = new SpaceData();
      spaceData.fileExists = false;
      string path = "SAVES//spaceprefs";
      if (!File.Exists(path))
      {
        this.status = "fail";
        return spaceData;
      }
      try
      {
        using (BinaryReader binaryReader = new BinaryReader((Stream) File.Open(path, FileMode.Open)))
        {
          spaceData.fileExists = binaryReader.ReadBoolean();
          spaceData.fileVersion = binaryReader.ReadSingle();
          spaceData.mv = binaryReader.ReadSingle();
          spaceData.ev = binaryReader.ReadSingle();
          spaceData.vv = binaryReader.ReadSingle();
          spaceData.df = binaryReader.ReadInt32();
          spaceData.brightness = binaryReader.ReadInt32();
          spaceData.contrast = binaryReader.ReadInt32();
          spaceData.pad_invertX = binaryReader.ReadInt32();
          spaceData.pad_invertY = binaryReader.ReadInt32();
          spaceData.pad_sensitivityX = binaryReader.ReadSingle();
          spaceData.pad_sensitivityY = binaryReader.ReadSingle();
          spaceData.pad_winvertX = binaryReader.ReadInt32();
          spaceData.pad_winvertY = binaryReader.ReadInt32();
          spaceData.pad_wsensitivityX = binaryReader.ReadSingle();
          spaceData.pad_wsensitivityY = binaryReader.ReadSingle();
          spaceData.pad_vibro = binaryReader.ReadInt32();
          int[] numArray1 = new int[4]
          {
            binaryReader.ReadInt32(),
            binaryReader.ReadInt32(),
            binaryReader.ReadInt32(),
            binaryReader.ReadInt32()
          };
          spaceData.allcamsradius = numArray1;
          int[] numArray2 = new int[4]
          {
            binaryReader.ReadInt32(),
            binaryReader.ReadInt32(),
            binaryReader.ReadInt32(),
            binaryReader.ReadInt32()
          };
          spaceData.allcamsorbit = numArray2;
          int[] numArray3 = new int[4]
          {
            binaryReader.ReadInt32(),
            binaryReader.ReadInt32(),
            binaryReader.ReadInt32(),
            binaryReader.ReadInt32()
          };
          spaceData.allcamsaltitude = numArray3;
          int[] numArray4 = new int[4]
          {
            binaryReader.ReadInt32(),
            binaryReader.ReadInt32(),
            binaryReader.ReadInt32(),
            binaryReader.ReadInt32()
          };
          spaceData.allcamslens = numArray4;
          spaceData.pad_rinvertX = binaryReader.ReadInt32();
          spaceData.pad_rinvertY = binaryReader.ReadInt32();
          spaceData.pad_rsensitivityX = binaryReader.ReadSingle();
          spaceData.pad_rsensitivityY = binaryReader.ReadSingle();
          spaceData.roverindex = binaryReader.ReadInt32();
          spaceData.roverrotlock = binaryReader.ReadInt32();
          spaceData.roverhitelock = binaryReader.ReadInt32();
          float[] numArray5 = new float[3]
          {
            binaryReader.ReadSingle(),
            binaryReader.ReadSingle(),
            binaryReader.ReadSingle()
          };
          spaceData.roverdist = numArray5;
          float[] numArray6 = new float[3]
          {
            binaryReader.ReadSingle(),
            binaryReader.ReadSingle(),
            binaryReader.ReadSingle()
          };
          spaceData.roverheight = numArray6;
          float[] numArray7 = new float[3]
          {
            binaryReader.ReadSingle(),
            binaryReader.ReadSingle(),
            binaryReader.ReadSingle()
          };
          spaceData.roverradian = numArray7;
          spaceData.landerindex = binaryReader.ReadInt32();
          spaceData.landerrotlock = binaryReader.ReadInt32();
          spaceData.landerhitelock = binaryReader.ReadInt32();
          float[] numArray8 = new float[3]
          {
            binaryReader.ReadSingle(),
            binaryReader.ReadSingle(),
            binaryReader.ReadSingle()
          };
          spaceData.landerdist = numArray8;
          float[] numArray9 = new float[3]
          {
            binaryReader.ReadSingle(),
            binaryReader.ReadSingle(),
            binaryReader.ReadSingle()
          };
          spaceData.landerheight = numArray9;
          float[] numArray10 = new float[3]
          {
            binaryReader.ReadSingle(),
            binaryReader.ReadSingle(),
            binaryReader.ReadSingle()
          };
          spaceData.landerradian = numArray10;
          binaryReader.Close();
          this.status = "success";
        }
      }
      catch
      {
        this.status = "fail";
      }
      return spaceData;
    }

    public void SaveSpacePreferences(SpaceData sg)
    {
      this.status = "";
      string path = "SAVES//spaceprefs";
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
          binaryWriter.Write(sg.pad_invertX);
          binaryWriter.Write(sg.pad_invertY);
          binaryWriter.Write(sg.pad_sensitivityX);
          binaryWriter.Write(sg.pad_sensitivityY);
          binaryWriter.Write(sg.pad_winvertX);
          binaryWriter.Write(sg.pad_winvertY);
          binaryWriter.Write(sg.pad_wsensitivityX);
          binaryWriter.Write(sg.pad_wsensitivityY);
          binaryWriter.Write(sg.pad_vibro);
          binaryWriter.Write(sg.allcamsradius[0]);
          binaryWriter.Write(sg.allcamsradius[1]);
          binaryWriter.Write(sg.allcamsradius[2]);
          binaryWriter.Write(sg.allcamsradius[3]);
          binaryWriter.Write(sg.allcamsorbit[0]);
          binaryWriter.Write(sg.allcamsorbit[1]);
          binaryWriter.Write(sg.allcamsorbit[2]);
          binaryWriter.Write(sg.allcamsorbit[3]);
          binaryWriter.Write(sg.allcamsaltitude[0]);
          binaryWriter.Write(sg.allcamsaltitude[1]);
          binaryWriter.Write(sg.allcamsaltitude[2]);
          binaryWriter.Write(sg.allcamsaltitude[3]);
          binaryWriter.Write(sg.allcamslens[0]);
          binaryWriter.Write(sg.allcamslens[1]);
          binaryWriter.Write(sg.allcamslens[2]);
          binaryWriter.Write(sg.allcamslens[3]);
          binaryWriter.Write(sg.pad_rinvertX);
          binaryWriter.Write(sg.pad_rinvertY);
          binaryWriter.Write(sg.pad_rsensitivityX);
          binaryWriter.Write(sg.pad_rsensitivityY);
          binaryWriter.Write(sg.roverindex);
          binaryWriter.Write(sg.roverrotlock);
          binaryWriter.Write(sg.roverhitelock);
          binaryWriter.Write(sg.roverdist[0]);
          binaryWriter.Write(sg.roverdist[1]);
          binaryWriter.Write(sg.roverdist[2]);
          binaryWriter.Write(sg.roverheight[0]);
          binaryWriter.Write(sg.roverheight[1]);
          binaryWriter.Write(sg.roverheight[2]);
          binaryWriter.Write(sg.roverradian[0]);
          binaryWriter.Write(sg.roverradian[1]);
          binaryWriter.Write(sg.roverradian[2]);
          binaryWriter.Write(sg.landerindex);
          binaryWriter.Write(sg.landerrotlock);
          binaryWriter.Write(sg.landerhitelock);
          binaryWriter.Write(sg.landerdist[0]);
          binaryWriter.Write(sg.landerdist[1]);
          binaryWriter.Write(sg.landerdist[2]);
          binaryWriter.Write(sg.landerheight[0]);
          binaryWriter.Write(sg.landerheight[1]);
          binaryWriter.Write(sg.landerheight[2]);
          binaryWriter.Write(sg.landerradian[0]);
          binaryWriter.Write(sg.landerradian[1]);
          binaryWriter.Write(sg.landerradian[2]);
          binaryWriter.Close();
        }
      }
      catch
      {
      }
    }
  }
}
