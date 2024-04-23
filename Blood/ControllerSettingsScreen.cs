// Decompiled with JetBrains decompiler
// Type: Blood.ControllerSettingsScreen
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;
using System;

#nullable disable
namespace Blood
{
  internal class ControllerSettingsScreen : MenuScreen
  {
    private MenuEntry vibro;

    public ControllerSettingsScreen()
      : base("Controller Settings")
    {
      MenuEntry menuEntry1 = new MenuEntry("Walking");
      MenuEntry menuEntry2 = new MenuEntry("Rover");
      MenuEntry menuEntry3 = new MenuEntry("Lander");
      menuEntry3.Selected += new EventHandler<PlayerIndexEventArgs>(this.landerEntrySelected);
      menuEntry2.Selected += new EventHandler<PlayerIndexEventArgs>(this.roverMenuEntrySelected);
      menuEntry1.Selected += new EventHandler<PlayerIndexEventArgs>(this.v127EntrySelected);
      this.MenuEntries.Add(menuEntry1);
      this.MenuEntries.Add(menuEntry2);
      this.MenuEntries.Add(menuEntry3);
    }

    private void SetMenuEntryText()
    {
      this.vibro.Text = "VIBRATION";
      this.vibro.Type = 1;
      this.vibro.Lists = new string[2]{ "OFF", "ON" };
    }

    private void vibroSelected(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.vibroSetting = (int) this.vibro.Amount;
    }

    private void landerEntrySelected(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.menuflag = 0;
      if (this.ScreenManager.usingMouse)
      {
        this.ScreenManager.abort.Play(this.ScreenManager.ev, 0.0f, 0.0f);
        this.ScreenManager.AddScreen((GameScreen) new astrobindings("rebind"), new PlayerIndex?(e.PlayerIndex));
      }
      else
        this.ScreenManager.AddScreen((GameScreen) new LanderScreen(1, this.ScreenManager), new PlayerIndex?(e.PlayerIndex));
    }

    private void roverMenuEntrySelected(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.menuflag = 0;
      if (this.ScreenManager.usingMouse)
        this.ScreenManager.abort.Play(this.ScreenManager.ev, 0.0f, 0.0f);
      else
        this.ScreenManager.AddScreen((GameScreen) new LanderScreen(2, this.ScreenManager), new PlayerIndex?(e.PlayerIndex));
    }

    private void v127EntrySelected(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.menuflag = 0;
      if (this.ScreenManager.usingMouse)
        this.ScreenManager.abort.Play(this.ScreenManager.ev, 0.0f, 0.0f);
      else
        this.ScreenManager.AddScreen((GameScreen) new LanderScreen(3, this.ScreenManager), new PlayerIndex?(e.PlayerIndex));
    }

    private void menuEntrySelected(object sender, PlayerIndexEventArgs e)
    {
    }
  }
}
