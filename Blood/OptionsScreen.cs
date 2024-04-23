// Decompiled with JetBrains decompiler
// Type: Blood.OptionsScreen
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;
using System;

#nullable disable
namespace Blood
{
  internal class OptionsScreen : MenuScreen
  {
    public OptionsScreen()
      : base("Game Options")
    {
      MenuEntry menuEntry1 = new MenuEntry("AUDIO");
      MenuEntry menuEntry2 = new MenuEntry("VIDEO");
      MenuEntry menuEntry3 = new MenuEntry("CAMERA");
      menuEntry1.Selected += new EventHandler<PlayerIndexEventArgs>(this.audioMenuEntrySelected);
      menuEntry2.Selected += new EventHandler<PlayerIndexEventArgs>(this.videoMenuEntrySelected);
      menuEntry3.Selected += new EventHandler<PlayerIndexEventArgs>(this.camSelected);
      this.MenuEntries.Add(menuEntry1);
      this.MenuEntries.Add(menuEntry2);
      this.MenuEntries.Add(menuEntry3);
    }

    private void notesSelected(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.menuflag = 1;
      this.ScreenManager.AddScreen((GameScreen) new Notes(), new PlayerIndex?(e.PlayerIndex));
    }

    private void audioMenuEntrySelected(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.drawflag = 0;
      this.ScreenManager.AddScreen((GameScreen) new audiosettingScreen(), new PlayerIndex?(e.PlayerIndex));
    }

    private void videoMenuEntrySelected(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.drawflag = 0;
      if (this.ScreenManager.menutype == 0)
        this.ScreenManager.AddScreen((GameScreen) new videosettingsScreen(), new PlayerIndex?(e.PlayerIndex));
      else
        this.ScreenManager.AddScreen((GameScreen) new videosettingsScreen(), new PlayerIndex?(e.PlayerIndex));
    }

    private void gameX(object sender, PlayerIndexEventArgs e) => this.ScreenManager.drawflag = 0;

    private void savePrefsEntrySelected(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.SavePrefs();
    }

    private void loadPrefsEntrySelected(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.LoadPrefs();
    }

    private void camSelected(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.drawflag = 0;
      if (this.ScreenManager.vehicleindex == 1)
        this.ScreenManager.AddScreen((GameScreen) new CamerasScreen(), new PlayerIndex?(e.PlayerIndex));
      if (this.ScreenManager.vehicleindex != 2)
        return;
      this.ScreenManager.AddScreen((GameScreen) new CamerasScreen2(), new PlayerIndex?(e.PlayerIndex));
    }
  }
}
