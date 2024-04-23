﻿// Decompiled with JetBrains decompiler
// Type: Blood.gamesettingScreen2
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;
using System;

#nullable disable
namespace Blood
{
  internal class gamesettingScreen2 : MenuScreen
  {
    private MenuEntry invertxMenuEntry;
    private MenuEntry invertyMenuEntry;
    private MenuEntry xsenseMenuEntry;
    private MenuEntry ysenseMenuEntry;
    private MenuEntry vibro;

    public gamesettingScreen2()
      : base("Game Settings2")
    {
      this.vibro = new MenuEntry(string.Empty);
      this.invertxMenuEntry = new MenuEntry(string.Empty);
      this.invertyMenuEntry = new MenuEntry(string.Empty);
      this.xsenseMenuEntry = new MenuEntry(string.Empty);
      this.ysenseMenuEntry = new MenuEntry(string.Empty);
      this.SetMenuEntryText();
      this.invertxMenuEntry.Selected += new EventHandler<PlayerIndexEventArgs>(this.invertxSelected);
      this.invertyMenuEntry.Selected += new EventHandler<PlayerIndexEventArgs>(this.invertySelected);
      this.xsenseMenuEntry.Selected += new EventHandler<PlayerIndexEventArgs>(this.xsenseSelected);
      this.ysenseMenuEntry.Selected += new EventHandler<PlayerIndexEventArgs>(this.ysenseSelected);
      this.vibro.Selected += new EventHandler<PlayerIndexEventArgs>(this.vibroSelected);
      this.MenuEntries.Add(this.vibro);
      this.MenuEntries.Add(this.invertxMenuEntry);
      this.MenuEntries.Add(this.invertyMenuEntry);
      this.MenuEntries.Add(this.xsenseMenuEntry);
      this.MenuEntries.Add(this.ysenseMenuEntry);
    }

    private void SetMenuEntryText()
    {
      this.invertxMenuEntry.Text = "INVERT X";
      this.invertyMenuEntry.Text = "INVERT Y";
      this.xsenseMenuEntry.Text = "TURN SPEED";
      this.ysenseMenuEntry.Text = "TILT SPEED";
      this.invertxMenuEntry.Type = 1;
      this.invertyMenuEntry.Type = 1;
      this.xsenseMenuEntry.Type = 1;
      this.ysenseMenuEntry.Type = 1;
      this.invertxMenuEntry.Lists = new string[2]
      {
        "NO",
        "YES"
      };
      this.invertyMenuEntry.Lists = new string[2]
      {
        "NO",
        "YES"
      };
      this.xsenseMenuEntry.Lists = new string[11]
      {
        "0",
        "1",
        "2",
        "3",
        "4",
        "5",
        "6",
        "7",
        "8",
        "9",
        "10"
      };
      this.ysenseMenuEntry.Lists = new string[11]
      {
        "0",
        "1",
        "2",
        "3",
        "4",
        "5",
        "6",
        "7",
        "8",
        "9",
        "10"
      };
      this.vibro.Text = "LANDER";
      this.vibro.Type = 1;
      this.vibro.Lists = new string[3]{ "", "", "" };
    }

    private void vibroSelected(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.vibroSetting = (int) this.vibro.Amount;
    }

    private void invertxSelected(object sender, PlayerIndexEventArgs e)
    {
      int num = 1;
      if ((int) this.invertxMenuEntry.Amount == 0)
        num = 1;
      if ((int) this.invertxMenuEntry.Amount == 1)
        num = -1;
      this.ScreenManager.space_invertX = num;
    }

    private void invertySelected(object sender, PlayerIndexEventArgs e)
    {
      int num = 1;
      if ((int) this.invertyMenuEntry.Amount == 0)
        num = 1;
      if ((int) this.invertyMenuEntry.Amount == 1)
        num = -1;
      this.ScreenManager.space_invertY = num;
    }

    private void xsenseSelected(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.space_sentivityX = MathHelper.Lerp(0.2f, 2f, this.xsenseMenuEntry.Amount / 10f);
    }

    private void ysenseSelected(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.space_sentivityY = MathHelper.Lerp(0.2f, 2f, this.ysenseMenuEntry.Amount / 10f);
    }
  }
}
