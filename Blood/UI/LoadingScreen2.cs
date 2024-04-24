using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

#pragma warning disable CS0169
#nullable disable
namespace Blood
{
  internal class LoadingScreen2 : GameScreen
  {
    public static bool done;
    private int mytime;
    private int countdown = 10;
    private bool loadingIsSlow;
    private bool otherScreensAreGone;
    private GameScreen[] screensToLoad;
    private Thread backgroundThread;
    private EventWaitHandle backgroundThreadExit;
    private GraphicsDevice graphicsDevice;
    private GameTime loadStartTime;
    private ContentManager content;
    private Random random;
    private Texture2D gear2;
    private Texture2D buttonOn;
    private Texture2D loadBG;
    private Texture2D rays;
    private bool loaded;
    private float rot;
    private float realrot;
    private SpriteBatch spriteBatch;
    private SpriteFont loadfont1;
    private SpriteFont loadfont2;
    private List<Color> col = new List<Color>();
    private List<float> locX = new List<float>();
    private List<float> locY = new List<float>();
    private int horPos;
    private float sizer = 1f;
    private int blue = 200;
    private string[] image0 = new string[0];
    private Texture2D myimage;
    private Texture2D codeBG;
    private Color[] colorArray1 = new Color[0];
    private string messagedisplay = "";
    private string[] messages = new string[34]
    {
      "call the dropship",
      "activate the monolith",
      "upgraded solar cell",
      "missions increase rep",
      "mine crystals",
      "stay alert",
      "mine crystals",
      "don't monkey around",
      "refine ore for gems",
      "refine ore for gems",
      "Go Get Promoted",
      "gold Is worthless",
      "repair from the lander",
      "this is rocket science",
      "Know Your Friends",
      "the L257 lander",
      "launch another rocket",
      "listen to your radio",
      "refine shale into fuel",
      "red stones for fuel",
      "return home",
      "upgrades cost money",
      "remember to recharge",
      "the blue dot",
      "save your progress",
      "increase your ranking",
      "rocks contain crystals",
      "bag oh money",
      "save yourgame",
      "watching you",
      "recordings of the dead",
      "signs of life",
      "remember to refuel",
      "are you human"
    };
    private string[] loadx = new string[9]
    {
      "moon of mercury",
      "moon of venus",
      "earth's moon",
      "moon of mars",
      "moon of saturn",
      "moon of jupiter",
      "moon of neptune",
      "moon of uranus",
      "moon of pluto"
    };
    private string[] header = new string[5]
    {
      "destination : ",
      "orbiting : ",
      "approaching : ",
      "nearing : ",
      "navigating : "
    };
    private string mess = "";
    private int loadspot;
    private List<Color> colortab = new List<Color>();
    private List<int> posxtab = new List<int>();
    private List<int> posytab = new List<int>();
    private int pulse = 10;
    private int loadIndex = 1;
    private int loadonce;
    private SoundEffect button;
    private ScreenManager sc;
    private Matrix scalematrix = Matrix.Identity;

    private LoadingScreen2(
      ScreenManager screenManager,
      bool loadingIsSlow,
      GameScreen[] screensToLoad)
    {
      this.loadingIsSlow = loadingIsSlow;
      this.screensToLoad = screensToLoad;
      this.TransitionOnTime = TimeSpan.FromSeconds(0.5);
      this.sc = screenManager;
      this.spriteBatch = new SpriteBatch(this.sc.GraphicsDevice);
      this.scalematrix = this.sc.ScaleMatrix1;
      if (!loadingIsSlow)
        return;
      this.backgroundThread = new Thread(new ThreadStart(this.BackgroundWorkerThread));
      this.backgroundThreadExit = (EventWaitHandle) new ManualResetEvent(false);
      this.graphicsDevice = screenManager.GraphicsDevice;
    }

    public static void Load(
      ScreenManager screenManager,
      bool loadingIsSlow,
      PlayerIndex? controllingPlayer,
      params GameScreen[] screensToLoad)
    {
      foreach (GameScreen screen in screenManager.GetScreens())
        screen.ExitScreen();
      LoadingScreen2 screen1 = new LoadingScreen2(screenManager, loadingIsSlow, screensToLoad);
      LoadingScreen2.done = false;
      screenManager.AddScreen((GameScreen) screen1, controllingPlayer);
    }

    public override void Update(
      GameTime gameTime,
      bool otherScreenHasFocus,
      bool coveredByOtherScreen)
    {
      base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
      ++this.mytime;
      if (!this.otherScreensAreGone)
        return;
      if (this.backgroundThread != null)
      {
        this.loadStartTime = gameTime;
        this.backgroundThread.Start();
      }
      this.ScreenManager.RemoveScreen((GameScreen) this);
      foreach (GameScreen screen in this.screensToLoad)
      {
        if (screen != null)
          this.ScreenManager.AddScreen(screen, this.ControllingPlayer);
      }
      if (this.backgroundThread != null)
      {
        this.backgroundThreadExit.Set();
        this.backgroundThread.Join();
      }
      this.ScreenManager.Game.ResetElapsedTime();
    }

    private void allcolors()
    {
      if (this.ScreenManager.loadScreen.Count == 0)
      {
        for (int index = 1; index < this.messages.Length + 1; ++index)
          this.ScreenManager.loadScreen.Add(index);
      }
      int index1 = this.random.Next(0, this.ScreenManager.loadScreen.Count - 1);
      this.loadIndex = this.ScreenManager.loadScreen[index1];
      this.ScreenManager.loadScreen.RemoveAt(index1);
      this.mess = this.header[this.random.Next(0, 5)] + this.loadx[this.ScreenManager.bgindex - 1];
      this.myimage = this.content.Load<Texture2D>("astro\\loading\\image0");
      this.codeBG = this.ScreenManager.codeBG;
      this.colorArray1 = new Color[1024];
      this.myimage.GetData<Color>(this.colorArray1);
    }

    public override void Draw(GameTime gameTime)
    {
      if (this.ScreenState == ScreenState.Active && this.ScreenManager.GetScreens().Length == 1)
        this.otherScreensAreGone = true;
      if (this.loadonce == 0)
      {
        if (this.content == null)
          this.content = new ContentManager((IServiceProvider) this.ScreenManager.Game.Services, "Content");
        this.random = new Random();
        int num = this.random.Next(1, 13);
        this.horPos = this.random.Next(0, 300);
        this.blue = this.random.Next(120, 200);
        this.sizer = (float) this.random.Next(1200, 1600) / 1000f;
        this.button = this.sc.buttonGong;
        this.gear2 = this.sc.gear2;
        this.loadfont1 = this.sc.loadfont1;
        this.loadBG = this.sc.loadBG;
        this.buttonOn = this.content.Load<Texture2D>("astro//sprites\\icons\\buttonon" + (object) num);
        this.loadonce = 1;
      }
      if (!this.loadingIsSlow)
        return;
      if (!this.loaded)
      {
        this.loaded = true;
        this.allcolors();
        this.messagedisplay = this.messages[this.loadIndex - 1].ToLower();
        int num1 = 0;
        int num2 = 1;
        for (int index = 0; index < this.colorArray1.Length; ++index)
        {
          ++num1;
          if (num1 > 32)
          {
            num1 = 1;
            ++num2;
          }
          int int16_1 = (int) Convert.ToInt16(this.colorArray1[index].R);
          int int16_2 = (int) Convert.ToInt16(this.colorArray1[index].G);
          if ((int) Convert.ToInt16(this.colorArray1[index].B) + int16_2 + int16_1 > 20)
          {
            this.colortab.Add(this.colorArray1[index]);
            this.posxtab.Add(num1);
            this.posytab.Add(num2);
          }
        }
      }
      if (this.ScreenManager.loadflag == 2)
        return;
      this.rot += 0.04f;
      if ((double) this.rot > 0.15)
      {
        this.rot = 0.0f;
        this.realrot += 0.1f;
        --this.pulse;
        if (this.pulse <= 0)
          this.pulse = 10;
        if (this.colortab.Count > 0)
        {
          int index1 = this.random.Next(0, this.colortab.Count);
          int num3 = this.posxtab[index1] - 16;
          int num4 = this.posytab[index1] - 16;
          this.locX.Add((float) (num3 * 12 + 640) + (float) this.random.Next(-1000, 1000) / 1000f);
          this.locY.Add((float) (num4 * 12 + 330) + (float) this.random.Next(-1000, 1000) / 1000f);
          this.col.Add(this.colortab[index1]);
          this.colortab.RemoveAt(index1);
          this.posxtab.RemoveAt(index1);
          this.posytab.RemoveAt(index1);
          if (this.colortab.Count > 0)
          {
            int index2 = this.random.Next(0, this.colortab.Count);
            int num5 = this.posxtab[index2] - 16;
            int num6 = this.posytab[index2] - 16;
            this.locX.Add((float) (num5 * 12 + 640) + (float) this.random.Next(-1000, 1000) / 1000f);
            this.locY.Add((float) (num6 * 12 + 330) + (float) this.random.Next(-1000, 1000) / 1000f);
            this.col.Add(this.colortab[index2]);
            this.colortab.RemoveAt(index2);
            this.posxtab.RemoveAt(index2);
            this.posytab.RemoveAt(index2);
          }
          if (this.colortab.Count > 0)
          {
            int index3 = this.random.Next(0, this.colortab.Count);
            int num7 = this.posxtab[index3] - 16;
            int num8 = this.posytab[index3] - 16;
            this.locX.Add((float) (num7 * 12 + 640) + (float) this.random.Next(-1000, 1000) / 1000f);
            this.locY.Add((float) (num8 * 12 + 330) + (float) this.random.Next(-1000, 1000) / 1000f);
            this.col.Add(this.colortab[index3]);
            this.colortab.RemoveAt(index3);
            this.posxtab.RemoveAt(index3);
            this.posytab.RemoveAt(index3);
          }
          if (this.colortab.Count > 0)
          {
            int index4 = this.random.Next(0, this.colortab.Count);
            int num9 = this.posxtab[index4] - 16;
            int num10 = this.posytab[index4] - 16;
            this.locX.Add((float) (num9 * 12 + 640) + (float) this.random.Next(-1000, 1000) / 1000f);
            this.locY.Add((float) (num10 * 12 + 330) + (float) this.random.Next(-1000, 1000) / 1000f);
            this.col.Add(this.colortab[index4]);
            this.colortab.RemoveAt(index4);
            this.posxtab.RemoveAt(index4);
            this.posytab.RemoveAt(index4);
          }
          if (this.colortab.Count > 0)
          {
            int index5 = this.random.Next(0, this.colortab.Count);
            int num11 = this.posxtab[index5] - 16;
            int num12 = this.posytab[index5] - 16;
            this.locX.Add((float) (num11 * 12 + 640) + (float) this.random.Next(-1000, 1000) / 1000f);
            this.locY.Add((float) (num12 * 12 + 330) + (float) this.random.Next(-1000, 1000) / 1000f);
            this.col.Add(this.colortab[index5]);
            this.colortab.RemoveAt(index5);
            this.posxtab.RemoveAt(index5);
            this.posytab.RemoveAt(index5);
          }
          this.button.Play(0.3f * this.ScreenManager.ev, (float) this.random.Next(-10000, 10000) / 10000f, 0.0f);
        }
      }
      ++this.mytime;
      if (this.colortab.Count <= 0 && this.mytime > 70)
      {
        --this.countdown;
        if (this.countdown <= 0)
          LoadingScreen2.done = true;
      }
      this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) null, this.scalematrix);
      this.spriteBatch.Draw(this.codeBG, new Rectangle(this.horPos + 50, (int) ((double) this.realrot * 20.0 - 50.0), (int) ((double) this.sizer * 720.0), (int) ((double) this.sizer * 720.0)), new Color(120, 120, this.blue, 80));
      this.spriteBatch.Draw(this.loadBG, new Rectangle(0, 0, 1280, 720), Color.White);
      for (int index = 0; index < this.locX.Count; ++index)
        this.spriteBatch.Draw(this.buttonOn, new Vector2(this.locX[index], this.locY[index]), this.col[index]);
      this.spriteBatch.Draw(this.gear2, new Vector2(160f, 60f), new Rectangle?(), Color.White, this.realrot, new Vector2((float) (this.gear2.Width / 2), (float) (this.gear2.Height / 2)), 1f, SpriteEffects.None, 0.0f);
      this.spriteBatch.Draw(this.gear2, new Vector2(192f, 92f), new Rectangle?(), Color.White, (float) (-(double) this.realrot + 0.0099999997764825821), new Vector2((float) (this.gear2.Width / 2), (float) (this.gear2.Height / 2)), 0.66f, SpriteEffects.None, 0.0f);
      this.spriteBatch.DrawString(this.loadfont1, this.mess, new Vector2(235f, 45f), Color.White);
      this.spriteBatch.DrawString(this.loadfont1, this.messagedisplay, new Vector2((float) (640.0 - (double) this.loadfont1.MeasureString(this.messagedisplay).X / 2.0), 600f), new Color(200, 200, 230));
      this.spriteBatch.End();
    }

    private void BackgroundWorkerThread()
    {
      long timestamp = Stopwatch.GetTimestamp();
      while (!this.backgroundThreadExit.WaitOne(160))
      {
        GameTime gameTime = this.GetGameTime(ref timestamp);
        if (this.ScreenManager.loadflag < 2)
        {
          this.rot += 0.15f;
          this.DrawLoadAnimation(gameTime);
        }
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
        this.graphicsDevice.Clear(Color.Black);
        this.Draw(gameTime);
        this.graphicsDevice.Present();
      }
      catch
      {
        this.graphicsDevice = (GraphicsDevice) null;
      }
    }
  }
}
