using Microsoft.Xna.Framework;
using System;

#nullable disable
namespace Blood
{
  internal class ExtrasScreen : MenuScreen
  {
    public ExtrasScreen()
      : base("Extras")
    {
      MenuEntry menuEntry1 = new MenuEntry("Play Intro");
      MenuEntry menuEntry2 = new MenuEntry("Play MiniGame");
      MenuEntry menuEntry3 = new MenuEntry("MorseCode");
      MenuEntry menuEntry4 = new MenuEntry("STORAGE");
      menuEntry1.Selected += new EventHandler<PlayerIndexEventArgs>(this.PlayEntrySelected);
      menuEntry2.Selected += new EventHandler<PlayerIndexEventArgs>(this.miniEntrySelected);
      menuEntry3.Selected += new EventHandler<PlayerIndexEventArgs>(this.morseEntrySelected);
      menuEntry4.Selected += new EventHandler<PlayerIndexEventArgs>(this.storageEntrySelected);
      this.MenuEntries.Add(menuEntry1);
      this.MenuEntries.Add(menuEntry2);
      this.MenuEntries.Add(menuEntry3);
      this.MenuEntries.Add(menuEntry4);
    }

    private void PlayEntrySelected(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.SavePrefs();
      LoadingScreen2.Load(this.ScreenManager, false, new PlayerIndex?(), (GameScreen) new titles());
    }

    private void miniEntrySelected(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.menuflag = 1;
      this.ScreenManager.AddScreen((GameScreen) new MiniGame(), new PlayerIndex?(e.PlayerIndex));
    }

    private void morseEntrySelected(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.menuflag = 1;
    }

    private void storageEntrySelected(object sender, PlayerIndexEventArgs e)
    {
    }
  }
}
