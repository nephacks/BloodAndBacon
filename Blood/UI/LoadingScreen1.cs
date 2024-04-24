using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using System;
using System.Diagnostics;
using System.Threading;

#pragma warning disable CS0169
#nullable disable
namespace Blood
{
  internal class LoadingScreen1 : GameScreen
  {
    private Random rr;
    private float counter;
    private int tick;
    private float shrink = 1f;
    private bool loadingIsSlow;
    private bool otherScreensAreGone;
    private long startTime;
    private long lastTime;
    private long waitTime;
    private long waitTime2;
    private string day = "1";
    private float shake = 150f;
    private GameScreen[] screensToLoad;
    private Thread backgroundThread;
    private EventWaitHandle backgroundThreadExit;
    private GraphicsDevice graphicsDevice;
    private NetworkSession networkSession;
    private ScreenManager sc;
    private GameTime loadStartTime;
    private Vector2 textPosition;
    private SpriteFont font;
    private SpriteFont font2;
    private GameTime gg = new GameTime();
    private bool scaryday;

    private LoadingScreen1(
      ScreenManager screenManager,
      bool loadingIsSlow,
      NetworkSession networker,
      GameScreen[] screensToLoad)
    {
      this.sc = screenManager;
      this.loadingIsSlow = loadingIsSlow;
      this.screensToLoad = screensToLoad;
      this.TransitionOnTime = TimeSpan.FromSeconds(0.5);
      this.TransitionOffTime = TimeSpan.FromSeconds(0.0);
      this.networkSession = networker;
      GamePad.SetVibration(PlayerIndex.One, 0.0f, 0.0f);
      GamePad.SetVibration(PlayerIndex.Two, 0.0f, 0.0f);
      GamePad.SetVibration(PlayerIndex.Three, 0.0f, 0.0f);
      GamePad.SetVibration(PlayerIndex.Four, 0.0f, 0.0f);
      if (!loadingIsSlow)
        return;
      this.waitTime2 = Stopwatch.Frequency * 7L;
      this.startTime = Stopwatch.GetTimestamp();
      this.backgroundThread = new Thread(new ThreadStart(this.BackgroundWorkerThread));
      this.backgroundThreadExit = (EventWaitHandle) new ManualResetEvent(false);
      this.rr = new Random();
      if (this.sc.hordemode)
      {
        this.sc.scree.Play(this.sc.ev, (float) this.rr.Next(0, 10) / 100f, 0.0f);
        this.shake = 120f;
        this.scaryday = true;
        this.day = "666";
        this.shrink = 0.7f;
      }
      else if (this.sc.paintland)
      {
        this.sc.xmas.Play(this.sc.ev, 0.0f, 0.0f);
        this.shake = 10000f;
        this.scaryday = false;
        this.day = "PAINTLAND";
        this.shrink = 0.6f;
      }
      else if (this.sc.inSpace)
      {
        this.shake = 100f;
        this.sc.pileDriverSure.Play(this.sc.ev, (float) this.rr.Next(-20, 0) / 100f, 0.0f);
        this.scaryday = false;
        this.day = "DAY 00";
        this.shrink = 0.7f;
      }
      else
      {
        this.shake = 150f;
        this.sc.pileDriverSure.Play(this.sc.ev, (float) this.rr.Next(-20, 0) / 100f, 0.0f);
        this.day = this.sc.currentDay.ToString();
        this.shrink = 1f;
      }
    }

    public static void Load(
      ScreenManager screenManager,
      bool loadingIsSlow,
      PlayerIndex? controllingPlayer,
      NetworkSession networker,
      params GameScreen[] screensToLoad)
    {
      foreach (GameScreen screen in screenManager.GetScreens())
        screen.ExitScreen();
      LoadingScreen1 screen1 = new LoadingScreen1(screenManager, loadingIsSlow, networker, screensToLoad);
      screenManager.AddScreen((GameScreen) screen1, controllingPlayer);
    }

    public override void Update(
      GameTime gameTime,
      bool otherScreenHasFocus,
      bool coveredByOtherScreen)
    {
      LoadingScreen2.done = true;
      this.lastTime = Stopwatch.GetTimestamp();
      base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
      if (!this.otherScreensAreGone)
        return;
      if (this.backgroundThread != null)
      {
        this.loadStartTime = gameTime;
        this.backgroundThread.Start();
      }
      this.sc.RemoveScreen((GameScreen) this);
      foreach (GameScreen screen in this.screensToLoad)
      {
        if (screen != null)
          this.sc.AddScreen(screen, this.ControllingPlayer);
      }
      if (this.backgroundThread != null)
      {
        this.backgroundThreadExit.Set();
        this.backgroundThread.Join();
      }
      this.sc.Game.ResetElapsedTime();
    }

    public override void Draw(GameTime gameTime)
    {
      if (this.ScreenState == ScreenState.Active && this.sc.GetScreens().Length == 1)
        this.otherScreensAreGone = true;
      this.graphicsDevice = this.sc.GraphicsDevice;
      if (!this.loadingIsSlow)
        return;
      this.sc.isLoading = true;
      this.font = this.sc.grungeFont;
      this.font2 = this.sc.font;
      this.graphicsDevice = this.sc.GraphicsDevice;
      this.sc.contrastBU = 128;
      this.sc.redContrast = 128;
      SpriteBatch spriteBatch = this.sc.SpriteBatch;
      this.graphicsDevice.Clear(Color.Black);
      Vector2 vector2 = new Vector2((float) this.rr.Next(-100, 100) / this.shake, (float) this.rr.Next(-100, 100) / this.shake);
      if (this.scaryday || this.sc.inSpace)
        this.shake -= 1.4f;
      if ((double) this.shake < 30.0)
        this.shake = 25f;
      string text1 = "DAY " + this.day;
      if (this.sc.paintland)
        text1 = this.day;
      if (this.sc.inSpace)
        text1 = "YEAR 3019";
      this.textPosition = new Vector2((float) this.graphicsDevice.Viewport.Width, (float) this.graphicsDevice.Viewport.Height) / 2f;
      float num1 = (float) this.sc.screenSize.Width / (float) this.sc.origSize.Width;
      Vector2 origin1 = this.font.MeasureString(text1) / 2f;
      spriteBatch.Begin();
      if (this.sc.inSpace)
      {
        string text2 = "32.1  EARLY RELEASE BETA  : EXPECT CRASHES";
        spriteBatch.DrawString(this.font2, text2, new Vector2(50f, 50f), new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        float x1 = (float) (int) ((double) this.textPosition.X + (double) vector2.X * 4.0);
        float y1 = (float) (int) ((double) this.textPosition.Y + (double) vector2.Y * 4.0);
        spriteBatch.DrawString(this.font, text1, new Vector2(x1, y1), new Color(90, 90, 90, 210), 0.0f, origin1, num1 * this.shrink, SpriteEffects.None, 0.0f);
        float x2 = (float) (int) ((double) this.textPosition.X + (double) vector2.X * 7.0);
        float y2 = (float) (int) ((double) this.textPosition.Y + (double) vector2.Y * 7.0);
        spriteBatch.DrawString(this.font, text1, new Vector2(x2, y2), new Color(60, 60, 60, (int) byte.MaxValue), 0.0f, origin1, num1 * this.shrink, SpriteEffects.None, 0.0f);
      }
      this.textPosition.X = (float) (int) ((double) this.textPosition.X + (double) vector2.X);
      this.textPosition.Y = (float) (int) ((double) this.textPosition.Y + (double) vector2.Y);
      spriteBatch.DrawString(this.font, text1, this.textPosition, new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 210), 0.0f, origin1, num1 * this.shrink, SpriteEffects.None, 0.0f);
      if (this.sc.tunnelDay.Contains(this.sc.currentDay) && this.sc.showTunnels)
      {
        spriteBatch.DrawString(this.font, "explore the tunnels", new Vector2(0.0f, origin1.Y + 35f) + this.textPosition, new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 210), 0.0f, origin1, 0.2f * num1 * this.shrink, SpriteEffects.None, 0.0f);
        Vector2 origin2 = origin1 + new Vector2(-490f, -166f);
        Rectangle rectangle = new Rectangle(2, 1326, 94, 48);
        int num2 = this.sc.tunnelDay.IndexOf(this.sc.currentDay);
        if (num2 == 1 && this.sc.tusk1 == 0)
          rectangle = new Rectangle(108, 1326, 94, 48);
        if (num2 == 2 && this.sc.tusk2 == 0)
          rectangle = new Rectangle(108, 1326, 94, 48);
        if (num2 == 4 && this.sc.tusk3 == 0)
          rectangle = new Rectangle(108, 1326, 94, 48);
        spriteBatch.Draw(this.sc.overlay, new Vector2(this.textPosition.X, this.textPosition.Y), new Rectangle?(rectangle), new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 210), 0.0f, origin2, num1 * this.shrink, SpriteEffects.None, 0.0f);
      }
      if (this.sc.viewGarbage)
      {
        spriteBatch.DrawString(this.font2, this.sc.loadMoment, new Vector2(150f, 130f), Color.White);
        int num3 = (int) GC.GetTotalMemory(false) / 1024;
        spriteBatch.DrawString(this.font2, num3.ToString(), new Vector2(150f, 100f), Color.White);
      }
      if (this.lastTime - this.startTime > this.waitTime2)
      {
        ++this.counter;
        string text3 = "loading";
        for (int index = 0; (double) index < (double) this.counter; index += 10)
          text3 += " .";
        if ((double) this.counter > 80.0)
          this.counter = 0.0f;
        spriteBatch.DrawString(this.font2, text3, vector2 + new Vector2((float) (720.0 - (double) this.font2.MeasureString("loading").X / 2.0), (float) this.graphicsDevice.Viewport.Height * 0.85f), new Color(200, 200, 200, 200));
      }
      spriteBatch.End();
      this.sc.blackdayFader = 150f;
      this.sc.introCamera = 600f;
      this.sc.fenceDemo = false;
      this.sc.musicDemo = false;
    }

    private void BackgroundWorkerThread()
    {
      this.lastTime = Stopwatch.GetTimestamp();
      while (!this.backgroundThreadExit.WaitOne(30))
      {
        GameTime gameTime = this.GetGameTime(ref this.lastTime);
        this.lastTime = Stopwatch.GetTimestamp();
        this.DrawLoadAnimation(gameTime);
      }
    }

    private GameTime GetGameTime(ref long lastTime)
    {
      long timestamp = Stopwatch.GetTimestamp();
      long num = timestamp - lastTime;
      lastTime = timestamp;
      TimeSpan elapsedGameTime = TimeSpan.FromTicks(num * 10000000L / Stopwatch.Frequency);
      return new GameTime(this.loadStartTime.TotalGameTime + elapsedGameTime, elapsedGameTime);
    }

    private void DrawLoadAnimation(GameTime gameTime)
    {
      if (this.graphicsDevice == null)
        return;
      if (this.graphicsDevice.IsDisposed)
        return;
      try
      {
        if ((!this.sc.isLoading || this.sc.inSpace) && (!this.sc.inSpace || this.sc.loadflag != 0))
          return;
        this.Draw(gameTime);
        this.graphicsDevice.Present();
      }
      catch
      {
        this.graphicsDevice = (GraphicsDevice) null;
      }
    }

    private void UpdateNetworkSession()
    {
      if (this.networkSession == null)
        return;
      if (this.networkSession.SessionState == NetworkSessionState.Ended)
        return;
      try
      {
        this.networkSession.Update();
      }
      catch
      {
        this.networkSession = (NetworkSession) null;
      }
    }
  }
}
