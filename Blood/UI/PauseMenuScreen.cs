using Microsoft.Xna.Framework;
using System;

#pragma warning disable CS0067
#nullable disable
namespace Blood
{
  internal class PauseMenuScreen : MenuScreen
  {
    public event EventHandler<PlayerIndexEventArgs> Accepted;

    public event EventHandler<PlayerIndexEventArgs> Cancelled;

    public PauseMenuScreen(string text)
      : base("Paused")
    {
      this.TransitionOnTime = TimeSpan.FromSeconds(0.60000002384185791);
      this.TransitionOffTime = TimeSpan.FromSeconds(0.60000002384185791);
      MenuEntry menuEntry1 = new MenuEntry(text);
      MenuEntry menuEntry2 = new MenuEntry("Settings");
      MenuEntry menuEntry3 = new MenuEntry("Quit Game");
      MenuEntry menuEntry4 = new MenuEntry("Sensitivity");
      this.MenuEntries.Add(menuEntry1);
      this.MenuEntries.Add(menuEntry2);
      this.MenuEntries.Add(menuEntry4);
      this.MenuEntries.Add(menuEntry3);
      menuEntry2.Selected += new EventHandler<PlayerIndexEventArgs>(this.settingsX);
      menuEntry1.Selected += new EventHandler<PlayerIndexEventArgs>(this.controlsX);
      menuEntry4.Selected += new EventHandler<PlayerIndexEventArgs>(this.sansaX);
      menuEntry3.Selected += new EventHandler<PlayerIndexEventArgs>(this.quitgame);
    }

    private void settingsX(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.drawflag = 0;
      if (this.ScreenManager.vehicleindex == 3)
        this.ScreenManager.AddScreen((GameScreen) new OptionsScreen2(), new PlayerIndex?());
      else
        this.ScreenManager.AddScreen((GameScreen) new OptionsScreen(), new PlayerIndex?());
    }

    private void controlsX(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.menuflag = 0;
      if (this.ScreenManager.usingMouse)
        this.ScreenManager.AddScreen((GameScreen) new astrobindings("rebind"), new PlayerIndex?(e.PlayerIndex));
      else
        this.ScreenManager.AddScreen((GameScreen) new ControllerSettingsScreen(), new PlayerIndex?());
    }

    private void sansaX(object sender, PlayerIndexEventArgs e)
    {
      if (this.ScreenManager.vehicleindex == 1)
        this.ScreenManager.AddScreen((GameScreen) new gamesettingScreen1(), new PlayerIndex?(e.PlayerIndex));
      if (this.ScreenManager.vehicleindex == 2)
        this.ScreenManager.AddScreen((GameScreen) new gamesettingScreen2(), new PlayerIndex?(e.PlayerIndex));
      if (this.ScreenManager.vehicleindex != 3)
        return;
      this.ScreenManager.AddScreen((GameScreen) new gamesettingScreen3(), new PlayerIndex?(e.PlayerIndex));
    }

    private void quitgame(object sender1, PlayerIndexEventArgs e1)
    {
      messagebox screen = new messagebox("Exit Game?", 1, 0);
      screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender2, e2) =>
      {
        this.ScreenManager.poppy = 0;
        if (this.Accepted != null)
          this.Accepted((object) this, new PlayerIndexEventArgs(e1.PlayerIndex));
        this.ExitScreen();
      });
      screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender3, e3) =>
      {
        this.ScreenManager.Game.IsMouseVisible = true;
        this.ScreenManager.AddScreen((GameScreen) new messagebox("Stop Screwing Around", 0, 0), new PlayerIndex?(e1.PlayerIndex));
      });
      this.ScreenManager.AddScreen((GameScreen) screen, new PlayerIndex?(e1.PlayerIndex));
    }
  }
}
