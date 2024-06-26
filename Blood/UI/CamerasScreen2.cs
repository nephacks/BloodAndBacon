﻿using Microsoft.Xna.Framework;
using System;

#nullable disable
namespace Blood
{
  internal class CamerasScreen2 : MenuScreen
  {
    public CamerasScreen2()
      : base("Camera Settings2")
    {
      MenuEntry menuEntry1 = new MenuEntry("CAM 01");
      MenuEntry menuEntry2 = new MenuEntry("CAM 02");
      MenuEntry menuEntry3 = new MenuEntry("CAM 03");
      menuEntry1.Selected += new EventHandler<PlayerIndexEventArgs>(this.cam1Selected);
      menuEntry2.Selected += new EventHandler<PlayerIndexEventArgs>(this.cam2Selected);
      menuEntry3.Selected += new EventHandler<PlayerIndexEventArgs>(this.cam3Selected);
      this.MenuEntries.Add(menuEntry1);
      this.MenuEntries.Add(menuEntry2);
      this.MenuEntries.Add(menuEntry3);
    }

    private void cam1Selected(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.drawflag = 0;
      this.ScreenManager.AddScreen((GameScreen) new setCamera2(1), new PlayerIndex?(e.PlayerIndex));
    }

    private void cam2Selected(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.drawflag = 0;
      this.ScreenManager.AddScreen((GameScreen) new setCamera2(2), new PlayerIndex?(e.PlayerIndex));
    }

    private void cam3Selected(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.drawflag = 0;
      this.ScreenManager.AddScreen((GameScreen) new setCamera2(3), new PlayerIndex?(e.PlayerIndex));
    }
  }
}
