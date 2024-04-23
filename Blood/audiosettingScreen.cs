// Decompiled with JetBrains decompiler
// Type: Blood.audiosettingScreen
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using System;

#nullable disable
namespace Blood
{
  internal class audiosettingScreen : MenuScreen
  {
    private MenuEntry sfxMenuEntry;
    private MenuEntry musicMenuEntry;
    private MenuEntry voiceMenuEntry;

    public audiosettingScreen()
      : base("Audio Settings")
    {
      this.sfxMenuEntry = new MenuEntry(string.Empty);
      this.musicMenuEntry = new MenuEntry(string.Empty);
      this.voiceMenuEntry = new MenuEntry(string.Empty);
      this.SetMenuEntryText();
      this.sfxMenuEntry.Selected += new EventHandler<PlayerIndexEventArgs>(this.sfxMenuEntrySelected);
      this.musicMenuEntry.Selected += new EventHandler<PlayerIndexEventArgs>(this.musicMenuEntrySelected);
      this.voiceMenuEntry.Selected += new EventHandler<PlayerIndexEventArgs>(this.voiceMenuEntrySelected);
      this.MenuEntries.Add(this.sfxMenuEntry);
      this.MenuEntries.Add(this.musicMenuEntry);
      this.MenuEntries.Add(this.voiceMenuEntry);
    }

    private void SetMenuEntryText()
    {
      this.sfxMenuEntry.Text = "SOUND";
      this.musicMenuEntry.Text = "MUSIC";
      this.voiceMenuEntry.Text = "RADIO";
      this.sfxMenuEntry.Type = 1;
      this.musicMenuEntry.Type = 1;
      this.voiceMenuEntry.Type = 1;
      this.sfxMenuEntry.Lists = new string[11]
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
      this.musicMenuEntry.Lists = new string[11]
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
      this.voiceMenuEntry.Lists = new string[11]
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
    }

    private void sfxMenuEntrySelected(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.ev = this.sfxMenuEntry.Amount * this.sfxMenuEntry.Amount / 100f;
    }

    private void musicMenuEntrySelected(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.mv = this.musicMenuEntry.Amount * this.musicMenuEntry.Amount / 100f;
    }

    private void voiceMenuEntrySelected(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.voiceVolume = this.voiceMenuEntry.Amount * this.voiceMenuEntry.Amount / 100f;
    }
  }
}
