using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

#pragma warning disable CS0067
#pragma warning disable CS0414
#pragma warning disable CS0649
#pragma warning disable CS0169
#nullable disable
namespace Blood
{
  internal class MediaScreen : GameScreen
  {
    private Video trailerVid;
    private VideoPlayer myPlayer;
    private ContentManager content2;
    private int playTimer = 60;
    private int watchtimer;
    private List<string> me = new List<string>();
    private int alternator;
    private bool delayinput = true;
    private string whichButton = "none";
    private Rectangle bgBlue = new Rectangle(644, 0, 510, 270);
    private Rectangle yesRect = new Rectangle(0, 0, 0, 0);
    private Rectangle noRect = new Rectangle(0, 0, 0, 0);
    private Rectangle okRect = new Rectangle(0, 0, 0, 0);
    private Rectangle arrRect = new Rectangle(0, 0, 0, 0);
    private Rectangle meter = new Rectangle(164, 289, 362, 48);
    private Rectangle meterColor = new Rectangle(164, 346, 362, 48);
    private Rectangle whitebox = new Rectangle(867, 74, 35, 35);
    private Rectangle arrows = new Rectangle(541, 289, 39, 84);
    private Vector2 mm = Vector2.Zero;
    private Matrix hudMatrix;
    private Keys[] pressedKeys = new Keys[0];
    private int kt;
    private int totaldots;
    private bool lastwasdot = true;
    private Rectangle goldRod;
    private Rectangle goldButton;
    private string message;
    private string messone;
    private string ipaddress;
    private string myname;
    private string chatentry;
    private bool includeYesNo;
    private bool techYesNo;
    private bool includeOkay;
    private int flag;
    private SpriteFont squarefont;
    private SpriteBatch spriteBatch;
    private SpriteFont font;
    private SpriteFont font2;
    private ScreenManager sc;
    private Viewport viewport;
    private Vector2 viewportSize;
    private Vector2 textSize;
    private Vector2 textPosition;
    private int hPad;
    private int vPad;
    private float widthset = 300f;
    private float mywidth;
    private float myhite;
    private float left;
    private float top;
    private float right;
    private float bottom;
    private float middle;
    private float midhite;
    private Rectangle menuSlate;
    private Rectangle cornerR;
    private Rectangle borderR;
    private Rectangle backgroundRectangle;
    private Rectangle topRect;
    private Rectangle botRect;
    private Rectangle leftRect;
    private Rectangle rightRect;
    private Rectangle cornA;
    private Rectangle cornB;
    private Rectangle cornC;
    private Rectangle cornD;
    private int max;
    private float currentNum;
    private int myframe;
    private bool useArial;
    private PlayerIndex playerIndex;
    private int myindex = -1;
    private GamePadState gamestate;
    private GamePadState prevstate;
    private KeyboardState prevKeys;
    private KeyboardState keyState;
    private MouseState prevMouse;
    private MouseState mouseState;
    public string longmessage = "";
    private bool includeMeter;
    private Random rr;
    private string[] dummy = new string[11]
    {
      "Dumb Ass",
      "Dumb-Ass",
      "El Dumbo",
      "Fart Smeller",
      "Lazy Goat",
      "The Noob",
      "Greenhorn",
      "Bed Wetter",
      "John Smith",
      "Pee Wee",
      "Thundar"
    };
    public string password = "";
    private ulong id = 5;

    public event EventHandler<PlayerIndexEventArgs> Accepted;

    public event EventHandler<PlayerIndexEventArgs> Approved;

    public event EventHandler<PlayerIndexEventArgs> Launch;

    public event EventHandler<PlayerIndexEventArgs> Failed;

    public event EventHandler<PlayerIndexEventArgs> Cancelled;

    public event EventHandler<PlayerIndexEventArgs> downloadCancel;

    public MediaScreen(int flag)
    {
      this.password = "nada";
      this.flag = flag;
      this.message = "nuoll";
      this.longmessage = "";
      this.IsPopup = true;
      this.TransitionOnTime = TimeSpan.FromSeconds(0.0);
      this.TransitionOffTime = TimeSpan.FromSeconds(0.0);
    }

    public override void LoadContent()
    {
      ContentManager content = this.ScreenManager.Game.Content;
      this.sc = this.ScreenManager;
      this.sc.forcedout = false;
      this.rr = new Random();
      this.content2 = new ContentManager((IServiceProvider) this.ScreenManager.Game.Services, "ABCDE1");
      if (this.flag == 0)
        this.trailerVid = this.content2.Load<Video>("trailer");
      if (this.flag == 1)
        this.trailerVid = this.content2.Load<Video>("creditNEW");
      this.myPlayer = new VideoPlayer();
      this.myPlayer.IsLooped = true;
      this.myPlayer.Volume = this.sc.ev;
      this.myPlayer.Stop();
      this.myPlayer.Play(this.trailerVid);
      this.font2 = this.sc.lilyFont;
      this.font = this.sc.terminal;
      this.squarefont = this.sc.squarefont;
      if (this.useArial)
        this.font = this.sc.squarefont;
      this.menuSlate = new Rectangle(114, 12, 480, 244);
      this.menuSlate = new Rectangle(76, 0, 520, 267);
      this.cornerR = new Rectangle(16, 13, 88, 88);
      this.borderR = new Rectangle(9, 457, 100, 64);
      this.spriteBatch = this.ScreenManager.SpriteBatch;
      this.viewport = new Viewport(0, 0, 1280, 720);
      this.viewportSize = new Vector2((float) this.viewport.Width, (float) this.viewport.Height);
      this.textSize = this.font.MeasureString(this.message);
      this.hPad = 40;
      this.vPad = 40;
      this.textPosition = this.viewportSize / 2f - this.textSize / 2f;
      this.mywidth = (float) ((int) this.textSize.X + this.hPad * 2);
      this.myhite = (float) ((int) this.textSize.Y + this.vPad * 2);
      if ((double) this.sc.introCamera <= 0.0)
      {
        this.textPosition.X = this.viewportSize.X / 2f;
        this.left = (float) ((int) this.textPosition.X - this.hPad) - this.textSize.X / 2f;
        this.top = (float) ((int) this.textPosition.Y - this.vPad);
      }
      else
      {
        this.textPosition.Y += (float) this.viewport.Y;
        this.textPosition.X = this.viewportSize.X / 2f + (float) this.viewport.X;
        this.left = (float) ((int) this.textPosition.X - this.hPad) - this.textSize.X / 2f;
        this.top = (float) ((int) this.textPosition.Y - this.vPad);
      }
      this.right = this.left + this.mywidth;
      this.bottom = this.top + this.myhite;
      this.backgroundRectangle = new Rectangle((int) this.left - 10, (int) this.top - 10, (int) this.mywidth + 20, (int) this.myhite + 20);
      this.cornA = new Rectangle((int) this.left, (int) this.top, 60, 60);
      this.cornB = new Rectangle((int) this.right, (int) this.top, 60, 60);
      this.cornC = new Rectangle((int) this.left, (int) this.bottom, 60, 60);
      this.cornD = new Rectangle((int) this.right, (int) this.bottom, 60, 60);
      this.mouseState = Mouse.GetState();
      this.sc.mymouse.X = (float) this.mouseState.X;
      this.sc.mymouse.Y = (float) this.mouseState.Y;
    }

    public override void HandleInput(InputState input)
    {
      if (this.ControllingPlayer.HasValue)
      {
        int index = (int) this.ControllingPlayer.Value;
        this.gamestate = input.CurrentGamePadStates[index];
        this.prevstate = input.LastGamePadStates[index];
      }
      this.prevKeys = input.lastKeyState;
      this.keyState = input.currentKeyState;
      if ((int) this.sc.myTimer % 120 == 0)
        this.sc.centerWindow();
      this.prevMouse = this.mouseState;
      this.mouseState = Mouse.GetState();
      this.mm.X = (float) this.mouseState.X;
      this.mm.Y = (float) this.mouseState.Y;
      if (this.mouseState.X == (int) this.sc.mymouse.X && this.mouseState.Y == (int) this.sc.mymouse.Y)
      {
        --this.sc.mousefade;
        if (this.sc.mousefade == 0)
          this.sc.Game.IsMouseVisible = false;
      }
      else
      {
        this.sc.mousefade = 210;
        this.sc.Game.IsMouseVisible = true;
      }
      this.sc.mymouse.X = (float) this.mouseState.X;
      this.sc.mymouse.Y = (float) this.mouseState.Y;
      bool flag1 = this.mouseState.RightButton == ButtonState.Pressed && this.prevMouse.RightButton == ButtonState.Released;
      bool flag2 = this.mouseState.LeftButton == ButtonState.Pressed && this.prevMouse.LeftButton == ButtonState.Released;
      if (this.delayinput)
      {
        this.prevMouse = this.mouseState;
        this.prevKeys = this.keyState;
        this.prevstate = this.gamestate;
      }
      if (this.flag == 0 || this.flag == 1)
      {
        if (!flag2 && !flag1 && !input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex))
        {
          if (flag1 || input.IsMenuCancel(this.ControllingPlayer, out this.playerIndex))
          {
            if (this.Cancelled != null)
              this.Cancelled((object) this, new PlayerIndexEventArgs(this.playerIndex));
            try
            {
              this.myPlayer.Dispose();
            }
            catch (Exception ex)
            {
              throw new Exception("MoviePlayer Stop() Failed! : " + ex.Message, ex);
            }
            this.ExitScreen();
          }
        }
        else
        {
          if (this.Accepted != null)
            this.Accepted((object) this, new PlayerIndexEventArgs(this.playerIndex));
          try
          {
            this.myPlayer.Dispose();
          }
          catch (Exception ex)
          {
            throw new Exception("MoviePlayer Stop() Failed! : " + ex.Message, ex);
          }
          this.ExitScreen();
        }
      }
      this.delayinput = false;
    }

    public override void Update(
      GameTime gameTime,
      bool otherScreenHasFocus,
      bool coveredByOtherScreen)
    {
      ++this.myframe;
      this.whichButton = "none";
      base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
    }

    public override void Draw(GameTime gameTime)
    {
      --this.playTimer;
      ++this.watchtimer;
      Matrix scale = Matrix.CreateScale((float) this.sc.screenSize.Width / (float) this.sc.origSize.Width, (float) this.sc.screenSize.Height / (float) this.sc.origSize.Height, 1f);
      this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) null, scale);
      if (this.flag == 0)
      {
        this.spriteBatch.Draw(this.sc.titleTrailer, this.sc.origSize, Color.White);
        if (!this.myPlayer.IsDisposed)
        {
          if (this.myPlayer.State != MediaState.Playing)
          {
            this.myPlayer.Stop();
            this.myPlayer.Play(this.trailerVid);
            this.playTimer = 2;
          }
          if (this.playTimer <= 0)
            this.spriteBatch.Draw(this.myPlayer.GetTexture(), new Vector2(848f, 338f), new Rectangle?(new Rectangle(0, 35, 720, 410)), Color.White, -0.07f, new Vector2(360f, 240f), 0.9f, SpriteEffects.None, 0.0f);
        }
        this.spriteBatch.Draw(this.sc.titleFrame, this.sc.origSize, Color.White);
      }
      if (this.flag == 1 && !this.myPlayer.IsDisposed)
      {
        if (this.myPlayer.State != MediaState.Playing)
        {
          this.myPlayer.Stop();
          this.myPlayer.Play(this.trailerVid);
          this.playTimer = 2;
        }
        if (this.playTimer <= 0)
        {
          this.spriteBatch.Draw(this.myPlayer.GetTexture(), new Vector2(640f, 360f), new Rectangle?(), Color.White, 0.0f, new Vector2(360f, 240f), 1f, SpriteEffects.None, 0.0f);
          if (this.watchtimer > 2580)
          {
            this.sc.trophy.win(this.sc.trophy.credits);
            this.watchtimer = 0;
          }
        }
      }
      this.spriteBatch.End();
    }
  }
}
