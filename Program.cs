// Decompiled with JetBrains decompiler
// Type: Blood.Program
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Steamworks;
using System;
using System.Diagnostics;
using System.IO;

#nullable disable
namespace Blood
{
  internal static class Program
  {
    private static void Main()
    {
      SteamAPI.Init();
      try
      {
        using (myGame myGame = new myGame())
          myGame.Run();
      }
      catch (Exception ex)
      {
        SteamAPI.Shutdown();
        using (StreamWriter streamWriter = new StreamWriter("unfriendly.txt"))
        {
          streamWriter.WriteLine("**********************  SORRY THE GAME CRASHED **************************");
          streamWriter.WriteLine("");
          streamWriter.WriteLine("Sexy Date :" + DateTime.Now.ToString());
          streamWriter.WriteLine("");
          streamWriter.WriteLine("ERROR MESSAGE :  " + ex.Message);
          streamWriter.WriteLine("");
          streamWriter.WriteLine("StackTrace : " + ex.StackTrace);
          streamWriter.WriteLine("");
          streamWriter.WriteLine("**********************  SORRY THE GAME CRASHED **************************");
          streamWriter.WriteLine("");
          streamWriter.Close();
        }
      }
      SteamAPI.Shutdown();
      Process.GetProcessesByName("BloodandBacon")[0].Kill();
    }
  }
}
