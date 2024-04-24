using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

#nullable disable
namespace Blood
{
  public class myGame : Game
  {
    public GraphicsDeviceManager graphics;
    private ScreenManager screenManager;
    private GameWindow gamewindow;

    public myGame()
    {
      this.Content.RootDirectory = "Content";
      this.graphics = new GraphicsDeviceManager((Game) this);
      graphics.GraphicsProfile = GraphicsProfile.HiDef;
      Mouse.WindowHandle = this.Window.Handle;
      this.gamewindow = this.Window;
      this.gamewindow.AllowUserResizing = false;
      this.IsMouseVisible = false;
      this.gamewindow.Title = "Blood and Bacon";
      this.graphics.SynchronizeWithVerticalRetrace = true;
      this.IsFixedTimeStep = true;
      this.TargetElapsedTime = TimeSpan.FromSeconds(1.0 / 60.0);
      this.screenManager = new ScreenManager(true, 800, 600, (Game) this, this.graphics);
      this.Components.Add((IGameComponent) this.screenManager);
      this.screenManager.AddScreen((GameScreen) new MainMenu(true), new PlayerIndex?());
    }

    protected override void Update(GameTime gameTime) => base.Update(gameTime);

    protected override void Draw(GameTime gameTime)
    {
      this.graphics.GraphicsDevice.Clear(Color.Black);
      base.Draw(gameTime);
    }
  }
}
