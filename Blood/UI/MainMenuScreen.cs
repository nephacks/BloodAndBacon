using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Net;
using System;

#nullable disable
namespace Blood
{
  internal class MainMenuScreen : MenuScreen
  {
    private MenuEntry BackGroundPlanet;

    public MainMenuScreen()
      : base("Main Menu")
    {
      MenuEntry menuEntry1 = new MenuEntry("PLAY GAME");
      MenuEntry menuEntry2 = new MenuEntry("INTERFACE");
      this.BackGroundPlanet = new MenuEntry(string.Empty);
      MenuEntry menuEntry3 = new MenuEntry("SETTINGS");
      MenuEntry menuEntry4 = new MenuEntry("EXTRAS");
      this.BackGroundPlanet = new MenuEntry(string.Empty);
      this.SetMenuEntryText();
      menuEntry1.Selected += new EventHandler<PlayerIndexEventArgs>(this.PlayGameMenuEntrySelected);
      this.BackGroundPlanet.Selected += new EventHandler<PlayerIndexEventArgs>(this.planetSelected);
      menuEntry2.Selected += new EventHandler<PlayerIndexEventArgs>(this.interface1);
      menuEntry4.Selected += new EventHandler<PlayerIndexEventArgs>(this.PlayTitleEntrySelected);
      menuEntry3.Selected += new EventHandler<PlayerIndexEventArgs>(this.OptionsMenuEntrySelected);
      this.MenuEntries.Add(menuEntry1);
      this.MenuEntries.Add(this.BackGroundPlanet);
      this.MenuEntries.Add(menuEntry2);
      this.MenuEntries.Add(menuEntry3);
      this.MenuEntries.Add(menuEntry4);
    }

    private void SetMenuEntryText()
    {
      this.BackGroundPlanet.Text = "PLANET";
      this.BackGroundPlanet.Type = 2;
      this.BackGroundPlanet.Lists = new string[10]
      {
        "Oor",
        "Mercury",
        "Venus",
        "Earth",
        "Mars",
        "Jupiter",
        "Saturn",
        "Uranus",
        "Neptune",
        "Pluto"
      };
    }

    private void PlayGameMenuEntrySelected(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.aliasSet = 2;
      LoadingScreen2.Load(this.ScreenManager, true, new PlayerIndex?(e.PlayerIndex), (GameScreen) new GameplayScreen(1f));
    }

    private void interface1(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.menuflag = 1;
      this.ScreenManager.AddScreen((GameScreen) new Interface(), new PlayerIndex?(e.PlayerIndex));
      this.ScreenManager.AddScreen((GameScreen) new Construction(), new PlayerIndex?(e.PlayerIndex));
    }

    private void loadMenuEntrySelected(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.menuflag = 1;
      this.ScreenManager.AddScreen((GameScreen) new RotoTyper(), new PlayerIndex?(e.PlayerIndex));
    }

    private void PlayTitleEntrySelected(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.drawflag = 0;
      this.ScreenManager.AddScreen((GameScreen) new ExtrasScreen(), new PlayerIndex?());
    }

    private void builderEntrySelected(object sender, PlayerIndexEventArgs e)
    {
    }

    private void OptionsMenuEntrySelected(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.drawflag = 0;
      this.ScreenManager.AddScreen((GameScreen) new OptionsScreen(), new PlayerIndex?());
    }

    protected override void OnCancel(PlayerIndex playerIndex)
    {
      messagebox screen = new messagebox("You Are About To Exit", 1, 0);
      screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
      {
        this.ScreenManager.inSpace = false;
        LoadingScreen1.Load(this.ScreenManager, false, new PlayerIndex?(), (NetworkSession) null, (GameScreen) new MainMenu(false));
      });
      this.ScreenManager.AddScreen((GameScreen) screen, new PlayerIndex?(playerIndex));
    }

    private void ConfirmExitMessageBoxAccepted(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.SavePrefs();
      this.ScreenManager.Game.Exit();
    }

    private void planetSelected(object sender, PlayerIndexEventArgs e)
    {
      if ((double) this.BackGroundPlanet.Amount < 1.0)
        this.BackGroundPlanet.Amount = 1f;
      this.ScreenManager.bgindex = (int) this.BackGroundPlanet.Amount;
      this.BackGroundPlanet.Text = this.BackGroundPlanet.Lists[this.ScreenManager.bgindex];
    }
  }
}
