using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

#pragma warning disable CS0067
#pragma warning disable CS0414
#pragma warning disable CS0649
#pragma warning disable CS0169
#nullable disable
namespace Blood
{
  internal class MessageBoxScreen2 : GameScreen
  {
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

    public MessageBoxScreen2(string messagex, int flag, string password)
    {
      this.password = password;
      this.flag = flag;
      this.message = messagex;
      this.longmessage = "";
      this.IsPopup = true;
      this.TransitionOnTime = TimeSpan.FromSeconds(0.0);
      this.TransitionOffTime = TimeSpan.FromSeconds(0.0);
    }

    public MessageBoxScreen2(string messagex, int flag)
    {
      this.flag = flag;
      this.message = messagex;
      if (flag == 1)
      {
        this.includeYesNo = true;
      }
      if (flag == 9)
      {
        this.includeYesNo = false;
        this.includeOkay = true;
      }
      if (flag == 2)
      {
        this.includeYesNo = true;
        this.ipaddress = "";
        this.messone = this.message;
        this.message = this.messone + "\n" + this.ipaddress + "\n";
      }
      if (flag == 3)
      {
        this.includeYesNo = false;
        this.includeMeter = true;
        this.message += "\n";
      }
      this.longmessage = "";
      this.IsPopup = true;
      this.TransitionOnTime = TimeSpan.FromSeconds(0.0);
      this.TransitionOffTime = TimeSpan.FromSeconds(0.0);
    }

    public MessageBoxScreen2(string messagex, int flag, ulong id)
    {
      this.id = id;
      this.flag = flag;
      this.message = messagex;
      if (flag == 1)
      {
        this.includeYesNo = true;
      }
      if (flag == 2)
      {
        this.includeYesNo = true;
        this.ipaddress = "";
        this.messone = this.message;
        this.message = this.messone + "\n" + this.ipaddress + "\n";
      }
      if (flag == 3)
      {
        this.includeYesNo = false;
        this.includeMeter = true;
        this.message += "\n";
      }
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
      this.hudMatrix = Matrix.CreateScale((float) this.sc.screenSize.Width / (float) this.sc.origSize.Width, (float) this.sc.screenSize.Height / (float) this.sc.origSize.Height, 1f);
      if ((double) this.sc.introCamera > 0.0 && this.flag != 0)
        this.hudMatrix *= Matrix.CreateTranslation((float) this.sc.myviewport.X, (float) this.sc.myviewport.Y, 0.0f);
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
      if (this.flag == 4)
      {
        this.includeYesNo = true;
        this.myname = this.sc.lobby.nickname;
        this.myname = this.sc.playername;
        this.messone = this.message;
        this.message = this.messone + "\n" + this.myname + "\n";
      }
      if (this.flag == 55)
      {
        this.includeYesNo = true;
        this.myname = "Log Update 001";
        this.messone = this.message;
        this.message = this.messone + "\n" + this.myname + "\n";
      }
      if (this.flag == 17)
      {
        this.includeYesNo = false;
        this.myname = this.sc.workshop.formMark;
        this.messone = this.message;
        this.message = this.myname;
      }
      if (this.flag == 14)
      {
        this.includeYesNo = false;
        this.myname = this.sc.workshop.formTitle;
        this.messone = this.message;
        this.message = this.myname;
      }
      if (this.flag == 15)
      {
        this.includeYesNo = false;
        this.myname = this.sc.workshop.formDescr;
        this.messone = this.message;
        this.message = this.myname;
      }
      if (this.flag == 16 || this.flag == 18)
      {
        this.includeYesNo = false;
        this.techYesNo = false;
        if (this.flag == 18)
        {
          this.flag = 16;
          this.techYesNo = true;
        }
      }
      if (this.flag == 6)
      {
        this.includeYesNo = true;
        this.myname = "";
        this.messone = this.message;
        this.message = this.messone + "\n" + this.myname + "\n";
      }
      if (this.flag == 5)
      {
        this.includeYesNo = false;
        this.chatentry = "";
        this.message = "";
      }
      if (this.flag == 7)
      {
        this.includeYesNo = true;
        this.myname = this.sc.lobby.password;
        this.messone = this.message;
        this.message = this.messone + "\n" + this.myname + "\n";
      }
      this.textSize = this.font.MeasureString(this.message);
      this.hPad = 40;
      this.vPad = 40;
      if (this.flag == 15)
      {
        this.textSize.Y = 120f;
        this.textSize.X = 300f;
      }
      if (this.flag == 14 || this.flag == 17)
      {
        this.textSize.X += 100f;
        this.textSize.Y = 50f;
      }
      if (this.flag == 16)
      {
        this.textSize = this.sc.fontsmall.MeasureString(this.message);
        if (this.message.Split('\r', '\n').Length <= 2)
          this.textSize.Y += 15f;
        this.hPad = 15;
        this.vPad = 0;
      }
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
      if ((double) this.sc.introCamera > 0.0 && (double) this.sc.introCamera < 5.0)
      {
        if (this.Cancelled != null)
          this.Cancelled((object) this, new PlayerIndexEventArgs(this.playerIndex));
        this.sc.Game.IsMouseVisible = false;
        this.ExitScreen();
      }
      if (this.flag == 0)
      {
        if (!flag2 && !flag1 && !input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex))
        {
          if (flag1 || input.IsMenuCancel(this.ControllingPlayer, out this.playerIndex))
          {
            if (this.Cancelled != null)
              this.Cancelled((object) this, new PlayerIndexEventArgs(this.playerIndex));
            this.ExitScreen();
          }
        }
        else
        {
          if (this.Accepted != null)
            this.Accepted((object) this, new PlayerIndexEventArgs(this.playerIndex));
          this.ExitScreen();
        }
      }
      if (this.flag == 1)
      {
        bool flag3 = this.keyState.IsKeyDown(Keys.Y) && this.prevKeys.IsKeyUp(Keys.Y);
        bool flag4 = this.keyState.IsKeyDown(Keys.N) && this.prevKeys.IsKeyUp(Keys.N);
        if (!flag3 && !input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex) && (this.mouseState.LeftButton != ButtonState.Pressed || this.prevMouse.LeftButton != ButtonState.Released || !(this.whichButton == "YES")))
        {
          if (flag4 || flag1 || input.IsMenuCancel(this.ControllingPlayer, out this.playerIndex) || this.mouseState.LeftButton == ButtonState.Pressed && this.prevMouse.LeftButton == ButtonState.Released && this.whichButton == "NO")
          {
            if (this.Cancelled != null)
              this.Cancelled((object) this, new PlayerIndexEventArgs(this.playerIndex));
            this.sc.Game.IsMouseVisible = false;
            this.ExitScreen();
          }
        }
        else
        {
          if (this.Accepted != null)
            this.Accepted((object) this, new PlayerIndexEventArgs(this.playerIndex));
          this.sc.Game.IsMouseVisible = false;
          this.ExitScreen();
        }
      }
      if (this.flag == 9)
      {
        bool flag5 = this.keyState.IsKeyDown(Keys.Y) && this.prevKeys.IsKeyUp(Keys.Y);
        bool flag6 = this.keyState.IsKeyDown(Keys.N) && this.prevKeys.IsKeyUp(Keys.N);
        if (!flag5 && !input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex) && (this.mouseState.LeftButton != ButtonState.Pressed || this.prevMouse.LeftButton != ButtonState.Released || !(this.whichButton == "OKAY")))
        {
          if (flag6 || input.IsMenuCancel(this.ControllingPlayer, out this.playerIndex) || this.mouseState.RightButton == ButtonState.Pressed && this.prevMouse.RightButton == ButtonState.Released && this.whichButton == "OKAY")
          {
            if (this.Cancelled != null)
              this.Cancelled((object) this, new PlayerIndexEventArgs(this.playerIndex));
            this.sc.Game.IsMouseVisible = false;
            this.ExitScreen();
          }
        }
        else
        {
          if (this.Accepted != null)
            this.Accepted((object) this, new PlayerIndexEventArgs(this.playerIndex));
          this.sc.Game.IsMouseVisible = false;
          this.ExitScreen();
        }
      }
      if (this.flag == 2)
      {
        if (!input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex) && (this.mouseState.LeftButton != ButtonState.Pressed || this.prevMouse.LeftButton != ButtonState.Released || !(this.whichButton == "YES")))
        {
          if (flag1 || input.IsMenuCancel(this.ControllingPlayer, out this.playerIndex) || this.mouseState.LeftButton == ButtonState.Pressed && this.prevMouse.LeftButton == ButtonState.Released && this.whichButton == "NO")
          {
            if (this.Cancelled != null)
            {
              this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
              this.Cancelled((object) this, new PlayerIndexEventArgs(this.playerIndex));
            }
            this.sc.Game.IsMouseVisible = false;
            this.ExitScreen();
          }
        }
        else if (this.myindex == -1)
        {
          if (this.totaldots == 3 && !this.lastwasdot)
          {
            if (this.Accepted != null)
            {
              this.sc.switch2.Play(this.sc.ev, 1f, 0.0f);
              string[] strArray = this.ipaddress.Split('.');
              string str = "";
              for (int index = 0; index < strArray.Length; ++index)
              {
                if (index > 0)
                  str += ".";
                int int32 = Convert.ToInt32(strArray[index]);
                str += int32.ToString();
              }
              this.Accepted((object) this, new PlayerIndexEventArgs(this.playerIndex));
            }
            this.sc.Game.IsMouseVisible = false;
            this.ExitScreen();
          }
          else
            this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
        }
        else
        {
          if (this.Accepted != null)
          {
            this.sc.switch2.Play(this.sc.ev, 1f, 0.0f);
            this.Accepted((object) this, new PlayerIndexEventArgs(this.playerIndex));
          }
          this.sc.Game.IsMouseVisible = false;
          this.ExitScreen();
        }
        this.lastwasdot = true;
        bool flag7 = false;
        this.totaldots = 0;
        int length = this.ipaddress.Length;
        if (length > 0)
        {
          this.lastwasdot = this.ipaddress[length - 1].ToString() == ".";
          for (int index = 0; index < length; ++index)
          {
            if (this.ipaddress[index].ToString() == ".")
              ++this.totaldots;
          }
        }
        if (length > 2)
        {
          int index = length - 1;
          flag7 = this.ipaddress[index].ToString() != "." && this.ipaddress[index - 1].ToString() != "." && this.ipaddress[index - 2].ToString() != ".";
        }
        if (length < 15)
        {
          if (!flag7)
          {
            if (this.keyState.IsKeyDown(Keys.D0) && this.prevKeys.IsKeyUp(Keys.D0) || this.keyState.IsKeyDown(Keys.NumPad0) && this.prevKeys.IsKeyUp(Keys.NumPad0))
            {
              this.ipaddress += "0";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D1) && this.prevKeys.IsKeyUp(Keys.D1) || this.keyState.IsKeyDown(Keys.NumPad1) && this.prevKeys.IsKeyUp(Keys.NumPad1))
            {
              this.ipaddress += "1";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D2) && this.prevKeys.IsKeyUp(Keys.D2) || this.keyState.IsKeyDown(Keys.NumPad2) && this.prevKeys.IsKeyUp(Keys.NumPad2))
            {
              this.ipaddress += "2";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D3) && this.prevKeys.IsKeyUp(Keys.D3) || this.keyState.IsKeyDown(Keys.NumPad3) && this.prevKeys.IsKeyUp(Keys.NumPad3))
            {
              this.ipaddress += "3";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D4) && this.prevKeys.IsKeyUp(Keys.D4) || this.keyState.IsKeyDown(Keys.NumPad4) && this.prevKeys.IsKeyUp(Keys.NumPad4))
            {
              this.ipaddress += "4";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D5) && this.prevKeys.IsKeyUp(Keys.D5) || this.keyState.IsKeyDown(Keys.NumPad5) && this.prevKeys.IsKeyUp(Keys.NumPad5))
            {
              this.ipaddress += "5";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D6) && this.prevKeys.IsKeyUp(Keys.D6) || this.keyState.IsKeyDown(Keys.NumPad6) && this.prevKeys.IsKeyUp(Keys.NumPad6))
            {
              this.ipaddress += "6";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D7) && this.prevKeys.IsKeyUp(Keys.D7) || this.keyState.IsKeyDown(Keys.NumPad7) && this.prevKeys.IsKeyUp(Keys.NumPad7))
            {
              this.ipaddress += "7";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D8) && this.prevKeys.IsKeyUp(Keys.D8) || this.keyState.IsKeyDown(Keys.NumPad8) && this.prevKeys.IsKeyUp(Keys.NumPad8))
            {
              this.ipaddress += "8";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D9) && this.prevKeys.IsKeyUp(Keys.D9) || this.keyState.IsKeyDown(Keys.NumPad9) && this.prevKeys.IsKeyUp(Keys.NumPad9))
            {
              this.ipaddress += "9";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.totaldots < 3 && !this.lastwasdot && this.keyState.IsKeyDown(Keys.OemPeriod) && this.prevKeys.IsKeyUp(Keys.OemPeriod))
            {
              this.ipaddress += ".";
              this.sc.tick.Play(this.sc.ev, -0.3f, 0.0f);
            }
            if (this.totaldots < 3 && !this.lastwasdot && this.keyState.IsKeyDown(Keys.Decimal) && this.prevKeys.IsKeyUp(Keys.Decimal))
            {
              this.ipaddress += ".";
              this.sc.tick.Play(this.sc.ev, -0.3f, 0.0f);
            }
          }
          else if (flag7 && this.totaldots < 3)
          {
            if (this.keyState.IsKeyDown(Keys.D0) && this.prevKeys.IsKeyUp(Keys.D0) || this.keyState.IsKeyDown(Keys.NumPad0) && this.prevKeys.IsKeyUp(Keys.NumPad0))
            {
              this.ipaddress += ".0";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D1) && this.prevKeys.IsKeyUp(Keys.D1) || this.keyState.IsKeyDown(Keys.NumPad1) && this.prevKeys.IsKeyUp(Keys.NumPad1))
            {
              this.ipaddress += ".1";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D2) && this.prevKeys.IsKeyUp(Keys.D2) || this.keyState.IsKeyDown(Keys.NumPad2) && this.prevKeys.IsKeyUp(Keys.NumPad2))
            {
              this.ipaddress += ".2";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D3) && this.prevKeys.IsKeyUp(Keys.D3) || this.keyState.IsKeyDown(Keys.NumPad3) && this.prevKeys.IsKeyUp(Keys.NumPad3))
            {
              this.ipaddress += ".3";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D4) && this.prevKeys.IsKeyUp(Keys.D4) || this.keyState.IsKeyDown(Keys.NumPad4) && this.prevKeys.IsKeyUp(Keys.NumPad4))
            {
              this.ipaddress += ".4";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D5) && this.prevKeys.IsKeyUp(Keys.D5) || this.keyState.IsKeyDown(Keys.NumPad5) && this.prevKeys.IsKeyUp(Keys.NumPad5))
            {
              this.ipaddress += ".5";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D6) && this.prevKeys.IsKeyUp(Keys.D6) || this.keyState.IsKeyDown(Keys.NumPad6) && this.prevKeys.IsKeyUp(Keys.NumPad6))
            {
              this.ipaddress += ".6";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D7) && this.prevKeys.IsKeyUp(Keys.D7) || this.keyState.IsKeyDown(Keys.NumPad7) && this.prevKeys.IsKeyUp(Keys.NumPad7))
            {
              this.ipaddress += ".7";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D8) && this.prevKeys.IsKeyUp(Keys.D8) || this.keyState.IsKeyDown(Keys.NumPad8) && this.prevKeys.IsKeyUp(Keys.NumPad8))
            {
              this.ipaddress += ".8";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D9) && this.prevKeys.IsKeyUp(Keys.D9) || this.keyState.IsKeyDown(Keys.NumPad9) && this.prevKeys.IsKeyUp(Keys.NumPad9))
            {
              this.ipaddress += ".9";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.totaldots < 3 && !this.lastwasdot && this.keyState.IsKeyDown(Keys.OemPeriod) && this.prevKeys.IsKeyUp(Keys.OemPeriod))
            {
              this.ipaddress += ".";
              this.sc.tick.Play(this.sc.ev, -0.3f, 0.0f);
            }
            if (this.totaldots < 3 && !this.lastwasdot && this.keyState.IsKeyDown(Keys.Decimal) && this.prevKeys.IsKeyUp(Keys.Decimal))
            {
              this.ipaddress += ".";
              this.sc.tick.Play(this.sc.ev, -0.3f, 0.0f);
            }
          }
        }
        if (length > 0 && (this.keyState.IsKeyDown(Keys.Back) && this.prevKeys.IsKeyUp(Keys.Back) || this.keyState.IsKeyDown(Keys.Delete) && this.prevKeys.IsKeyUp(Keys.Delete)))
        {
          string str = "";
          for (int index = 0; index < this.ipaddress.Length - 1; ++index)
            str += this.ipaddress[index].ToString();
          this.ipaddress = str;
          this.sc.tick.Play(this.sc.ev, -0.6f, 0.0f);
        }
        string str1 = "_";
        if (this.myframe % 30 < 15)
          str1 = "  ";
        this.message = this.messone + "\n" + this.ipaddress + str1 + "\n";
        if (this.keyState.IsKeyDown(Keys.Up) && this.prevKeys.IsKeyUp(Keys.Up) || this.mouseState.LeftButton == ButtonState.Pressed && this.prevMouse.LeftButton == ButtonState.Released && this.whichButton == "ARROW")
        {
          --this.myindex;
          if (this.myindex < -1)
            this.myindex = -1;
          this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
        }
        if (this.keyState.IsKeyDown(Keys.Down) && this.prevKeys.IsKeyUp(Keys.Down))
        {
          ++this.myindex;
          this.sc.tick.Play(this.sc.ev, -0.3f, 0.0f);
        }
      }
      if (this.flag == 3 && input.IsMenuCancel(this.ControllingPlayer, out this.playerIndex) && this.downloadCancel != null)
      {
        this.downloadCancel((object) this, new PlayerIndexEventArgs(this.playerIndex));
        this.sc.Game.IsMouseVisible = false;
        this.ExitScreen();
      }
      if (this.flag == 4)
      {
        if (!input.IsNewButtonPress(Buttons.A, this.ControllingPlayer, out this.playerIndex) && (this.mouseState.LeftButton != ButtonState.Pressed || this.prevMouse.LeftButton != ButtonState.Released || !(this.whichButton == "YES")))
        {
          if (input.IsNewButtonPress(Buttons.B, this.ControllingPlayer, out this.playerIndex) || flag1 || this.mouseState.LeftButton == ButtonState.Pressed && this.prevMouse.LeftButton == ButtonState.Released && this.whichButton == "NO")
          {
            if (this.Cancelled != null)
            {
              this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
              this.Cancelled((object) this, (PlayerIndexEventArgs) null);
            }
            this.sc.Game.IsMouseVisible = false;
            this.ExitScreen();
          }
        }
        else
        {
          this.myname = this.myname.Trim();
          if (this.Approved != null && this.myname != "")
          {
            if (this.myname.ToUpper() == "PLAYER")
              this.myname = this.dummy[this.rr.Next(0, this.dummy.Length)];
            this.sc.lobby.nickname = this.myname;
            this.sc.playername = this.myname;
            this.Approved((object) this, (PlayerIndexEventArgs) null);
          }
          else if (this.Failed != null)
            this.Failed((object) this, (PlayerIndexEventArgs) null);
          this.sc.Game.IsMouseVisible = false;
          this.ExitScreen();
        }
        this.inputKeys3(ref this.myname, this.myname.Length, 16);
        string str = "_";
        if (this.myframe % 30 < 15)
          str = "  ";
        this.message = this.messone + "\n" + this.myname + str + "\n";
      }
      if (this.flag == 55)
      {
        if (!input.IsNewButtonPress(Buttons.A, this.ControllingPlayer, out this.playerIndex) && (this.mouseState.LeftButton != ButtonState.Pressed || this.prevMouse.LeftButton != ButtonState.Released || !(this.whichButton == "YES")))
        {
          if (input.IsNewButtonPress(Buttons.B, this.ControllingPlayer, out this.playerIndex) || flag1 || this.mouseState.LeftButton == ButtonState.Pressed && this.prevMouse.LeftButton == ButtonState.Released && this.whichButton == "NO")
          {
            if (this.Cancelled != null)
            {
              this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
              this.Cancelled((object) this, (PlayerIndexEventArgs) null);
            }
            this.sc.Game.IsMouseVisible = false;
            this.ExitScreen();
          }
        }
        else
        {
          this.myname = this.myname.Trim();
          if (this.Approved != null && this.myname != "")
          {
            this.sc.workshop.changenotes = this.myname;
            this.Approved((object) this, (PlayerIndexEventArgs) null);
          }
          else if (this.Failed != null)
            this.Failed((object) this, (PlayerIndexEventArgs) null);
          this.sc.Game.IsMouseVisible = false;
          this.ExitScreen();
        }
        this.inputKeys3(ref this.myname, this.myname.Length, 16);
        string str = "_";
        if (this.myframe % 30 < 15)
          str = "  ";
        this.message = this.messone + "\n" + this.myname + str + "\n";
      }
      if (this.flag == 14)
      {
        if (!input.IsNewButtonPress(Buttons.A, this.ControllingPlayer, out this.playerIndex) && (this.mouseState.LeftButton != ButtonState.Pressed || this.prevMouse.LeftButton != ButtonState.Released || !(this.whichButton == "YES")))
        {
          if (input.IsNewButtonPress(Buttons.B, this.ControllingPlayer, out this.playerIndex) || flag1 || this.mouseState.LeftButton == ButtonState.Pressed && this.prevMouse.LeftButton == ButtonState.Released && this.whichButton == "NO")
          {
            if (this.Cancelled != null)
            {
              this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
              this.Cancelled((object) this, (PlayerIndexEventArgs) null);
            }
            this.sc.Game.IsMouseVisible = false;
            this.ExitScreen();
          }
        }
        else
        {
          this.myname = this.myname.Trim();
          if (this.Approved != null && this.myname != "")
          {
            this.sc.workshop.formTitle = this.myname;
            this.Approved((object) this, (PlayerIndexEventArgs) null);
          }
          else if (this.Failed != null)
            this.Failed((object) this, (PlayerIndexEventArgs) null);
          this.sc.Game.IsMouseVisible = false;
          this.ExitScreen();
        }
        this.inputKeys4(ref this.myname, this.myname.Length, 21);
        string str = "_";
        if (this.myframe % 60 < 30)
          str = " ";
        this.message = this.myname + str + "\n";
      }
      if (this.flag == 17)
      {
        if (!input.IsNewButtonPress(Buttons.A, this.ControllingPlayer, out this.playerIndex) && (this.mouseState.LeftButton != ButtonState.Pressed || this.prevMouse.LeftButton != ButtonState.Released || !(this.whichButton == "YES")))
        {
          if (input.IsNewButtonPress(Buttons.B, this.ControllingPlayer, out this.playerIndex) || flag1 || this.mouseState.LeftButton == ButtonState.Pressed && this.prevMouse.LeftButton == ButtonState.Released && this.whichButton == "NO")
          {
            if (this.Cancelled != null)
            {
              this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
              this.Cancelled((object) this, (PlayerIndexEventArgs) null);
            }
            this.sc.Game.IsMouseVisible = false;
            this.ExitScreen();
          }
        }
        else
        {
          this.myname = this.myname.Trim();
          if (this.Approved != null)
          {
            this.sc.workshop.formMark = this.myname.ToUpper();
            this.Approved((object) this, (PlayerIndexEventArgs) null);
          }
          else if (this.Failed != null)
            this.Failed((object) this, (PlayerIndexEventArgs) null);
          this.sc.Game.IsMouseVisible = false;
          this.ExitScreen();
        }
        this.inputKeys4(ref this.myname, this.myname.Length, 10);
        string str = "_";
        if (this.myframe % 60 < 30)
          str = " ";
        this.message = this.myname + str + "\n";
      }
      if (this.flag == 15)
      {
        if (!input.IsNewButtonPress(Buttons.A, this.ControllingPlayer, out this.playerIndex) && (this.mouseState.LeftButton != ButtonState.Pressed || this.prevMouse.LeftButton != ButtonState.Released || !(this.whichButton == "YES")))
        {
          if (input.IsNewButtonPress(Buttons.B, this.ControllingPlayer, out this.playerIndex) || flag1 || this.mouseState.LeftButton == ButtonState.Pressed && this.prevMouse.LeftButton == ButtonState.Released && this.whichButton == "NO")
          {
            if (this.Cancelled != null)
            {
              this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
              this.Cancelled((object) this, (PlayerIndexEventArgs) null);
            }
            this.sc.Game.IsMouseVisible = false;
            this.ExitScreen();
          }
        }
        else
        {
          this.myname = this.myname.Trim();
          if (this.Approved != null && this.myname != "")
          {
            this.sc.workshop.formDescr = this.myname;
            this.Approved((object) this, (PlayerIndexEventArgs) null);
          }
          else if (this.Failed != null)
            this.Failed((object) this, (PlayerIndexEventArgs) null);
          this.sc.Game.IsMouseVisible = false;
          this.ExitScreen();
        }
        this.inputKeys4(ref this.myname, this.myname.Length, 90);
        string str = "_";
        if (this.myframe % 60 < 30)
          str = " ";
        this.message = this.myname + str;
      }
      if (this.flag == 16)
      {
        if (this.whichButton == "YES" && flag2)
        {
          if (this.Accepted != null)
            this.Accepted((object) this, new PlayerIndexEventArgs(this.playerIndex));
          this.ExitScreen();
        }
        else if (this.whichButton == "NO" && flag2 || input.IsMenuCancel(this.ControllingPlayer, out this.playerIndex))
        {
          if (this.Cancelled != null)
            this.Cancelled((object) this, new PlayerIndexEventArgs(this.playerIndex));
          this.ExitScreen();
        }
      }
      if (this.flag == 5)
      {
        if (this.sc.forcedout)
        {
          this.sc.forcedout = false;
          if (this.Failed != null)
          {
            this.longmessage = "";
            this.Failed((object) this, (PlayerIndexEventArgs) null);
          }
          this.sc.Game.IsMouseVisible = false;
          this.ExitScreen();
        }
        if (this.keyState.IsKeyDown(Keys.Enter) && this.prevKeys.IsKeyUp(Keys.Enter))
        {
          if (this.chatentry.Length > 0)
          {
            Color white = Color.White;
            this.sc.chat.message2send = true;
            this.sc.chat.message = this.chatentry;
            this.sc.addChatMsg(this.sc.lobby.nickname + " : ", !this.sc.host ? this.sc.colors[this.sc.myplayerindex] : this.sc.hostblue, this.chatentry, Color.LightSteelBlue, 0, this.id);
            this.chatentry = "";
          }
          else
          {
            if (this.Failed != null)
            {
              this.longmessage = "";
              this.Failed((object) this, (PlayerIndexEventArgs) null);
            }
            this.sc.Game.IsMouseVisible = false;
            this.ExitScreen();
          }
        }
        else if (this.keyState.IsKeyDown(Keys.Escape) || input.IsNewButtonPress(Buttons.B, this.ControllingPlayer, out this.playerIndex) || flag1)
        {
          if (this.Cancelled != null)
          {
            this.longmessage = "";
            this.Cancelled((object) this, (PlayerIndexEventArgs) null);
          }
          this.sc.Game.IsMouseVisible = false;
          this.ExitScreen();
        }
        int length = this.chatentry.Length;
        if (this.keyState.IsKeyDown(Keys.Down) && this.prevKeys.IsKeyUp(Keys.Down))
        {
          --this.sc.chatIndex;
          if (this.sc.chatIndex <= 0)
            this.sc.chatIndex = 0;
        }
        if (this.keyState.IsKeyDown(Keys.Up) && this.prevKeys.IsKeyUp(Keys.Up))
        {
          ++this.sc.chatIndex;
          if (this.sc.chatIndex > this.sc.chatHistory.Count)
            this.sc.chatIndex = this.sc.chatHistory.Count;
        }
        if (this.keyState.IsKeyDown(Keys.Left) && this.prevKeys.IsKeyUp(Keys.Left))
          this.sc.chatIndex = 0;
        this.inputKeys3(ref this.chatentry, length, 45);
        string str = "|";
        if (this.myframe % 30 < 15)
          str = "  ";
        this.message = this.chatentry + str;
      }
      if (this.flag == 6)
      {
        if (!input.IsNewButtonPress(Buttons.A, this.ControllingPlayer, out this.playerIndex) && (this.mouseState.LeftButton != ButtonState.Pressed || this.prevMouse.LeftButton != ButtonState.Released || !(this.whichButton == "YES")))
        {
          if (input.IsNewButtonPress(Buttons.B, this.ControllingPlayer, out this.playerIndex) || flag1 || this.mouseState.LeftButton == ButtonState.Pressed && this.prevMouse.LeftButton == ButtonState.Released && this.whichButton == "NO")
          {
            if (this.Cancelled != null)
            {
              this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
              this.Cancelled((object) this, (PlayerIndexEventArgs) null);
            }
            this.sc.Game.IsMouseVisible = false;
            this.ExitScreen();
          }
        }
        else
        {
          if (this.Approved != null && this.myname == this.password)
            this.Approved((object) this, (PlayerIndexEventArgs) null);
          else if (this.Failed != null)
            this.Failed((object) this, (PlayerIndexEventArgs) null);
          this.sc.Game.IsMouseVisible = false;
          this.ExitScreen();
        }
        this.inputKeys3(ref this.myname, this.myname.Length, 16);
        string str = "_";
        if (this.myframe % 30 < 15)
          str = "  ";
        this.message = this.messone + "\n" + this.myname + str + "\n";
      }
      if (this.flag == 7)
      {
        if (!input.IsNewButtonPress(Buttons.A, this.ControllingPlayer, out this.playerIndex) && (this.mouseState.LeftButton != ButtonState.Pressed || this.prevMouse.LeftButton != ButtonState.Released || !(this.whichButton == "YES")))
        {
          if (input.IsNewButtonPress(Buttons.B, this.ControllingPlayer, out this.playerIndex) || flag1 || this.mouseState.LeftButton == ButtonState.Pressed && this.prevMouse.LeftButton == ButtonState.Released && this.whichButton == "NO")
          {
            if (this.Cancelled != null)
            {
              this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
              this.Cancelled((object) this, (PlayerIndexEventArgs) null);
            }
            this.sc.Game.IsMouseVisible = false;
            this.ExitScreen();
          }
        }
        else
        {
          this.myname = this.myname.Trim();
          if (this.Approved != null)
          {
            this.sc.lobby.password = this.myname;
            this.Approved((object) this, (PlayerIndexEventArgs) null);
          }
          this.sc.Game.IsMouseVisible = false;
          this.ExitScreen();
        }
        this.inputKeys3(ref this.myname, this.myname.Length, 16);
        string str = "_";
        if (this.myframe % 30 < 15)
          str = "  ";
        this.message = this.messone + "\n" + this.myname + str + "\n";
      }
      this.delayinput = false;
    }

    private void inputKeys3(ref string ans, int count, int lim)
    {
      string str1 = "";
      int num = 40;
      Keys[] pressedKeys = this.keyState.GetPressedKeys();
      if (pressedKeys.Length > 0)
        ++this.kt;
      bool flag1 = this.keyState.IsKeyDown(Keys.LeftShift) || this.keyState.IsKeyDown(Keys.RightShift);
      if (count < lim)
      {
        bool flag2 = false;
        if (count == 0 && this.keyState.IsKeyDown(Keys.OemPeriod) && this.prevKeys.IsKeyUp(Keys.OemPeriod))
        {
          str1 = ":";
          this.sc.tick.Play(this.sc.ev, -0.3f, 0.0f);
          this.sc.tick.Play(this.sc.ev, -0.8f, 0.0f);
          flag2 = true;
        }
        if (!flag2)
        {
          if (!flag1)
          {
            if (this.keyState.IsKeyDown(Keys.OemComma) && this.prevKeys.IsKeyUp(Keys.OemComma))
            {
              str1 = ",";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemPeriod) && this.prevKeys.IsKeyUp(Keys.OemPeriod))
            {
              str1 = ".";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemQuestion) && this.prevKeys.IsKeyUp(Keys.OemQuestion))
            {
              str1 = "/";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemSemicolon) && this.prevKeys.IsKeyUp(Keys.OemSemicolon))
            {
              str1 = ";";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemOpenBrackets) && this.prevKeys.IsKeyUp(Keys.OemOpenBrackets))
            {
              str1 = "[";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemCloseBrackets) && this.prevKeys.IsKeyUp(Keys.OemCloseBrackets))
            {
              str1 = "]";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemMinus) && this.prevKeys.IsKeyUp(Keys.OemMinus))
            {
              str1 = "-";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemPlus) && this.prevKeys.IsKeyUp(Keys.OemPlus))
            {
              str1 = "=";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemQuotes) && this.prevKeys.IsKeyUp(Keys.OemQuotes))
            {
              str1 = "'";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemPipe) && this.prevKeys.IsKeyUp(Keys.OemPipe))
            {
              str1 = "\\";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D0) && this.prevKeys.IsKeyUp(Keys.D0))
            {
              str1 = "0";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D1) && this.prevKeys.IsKeyUp(Keys.D1))
            {
              str1 = "1";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D2) && this.prevKeys.IsKeyUp(Keys.D2))
            {
              str1 = "2";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D3) && this.prevKeys.IsKeyUp(Keys.D3))
            {
              str1 = "3";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D4) && this.prevKeys.IsKeyUp(Keys.D4))
            {
              str1 = "4";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D5) && this.prevKeys.IsKeyUp(Keys.D5))
            {
              str1 = "5";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D6) && this.prevKeys.IsKeyUp(Keys.D6))
            {
              str1 = "6";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D7) && this.prevKeys.IsKeyUp(Keys.D7))
            {
              str1 = "7";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D8) && this.prevKeys.IsKeyUp(Keys.D8))
            {
              str1 = "8";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D9) && this.prevKeys.IsKeyUp(Keys.D9))
            {
              str1 = "9";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.A) && this.prevKeys.IsKeyUp(Keys.A))
            {
              str1 = "a";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.B) && this.prevKeys.IsKeyUp(Keys.B))
            {
              str1 = "b";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.C) && this.prevKeys.IsKeyUp(Keys.C))
            {
              str1 = "c";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D) && this.prevKeys.IsKeyUp(Keys.D))
            {
              str1 = "d";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.E) && this.prevKeys.IsKeyUp(Keys.E))
            {
              str1 = "e";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.F) && this.prevKeys.IsKeyUp(Keys.F))
            {
              str1 = "f";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.G) && this.prevKeys.IsKeyUp(Keys.G))
            {
              str1 = "g";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.H) && this.prevKeys.IsKeyUp(Keys.H))
            {
              str1 = "h";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.I) && this.prevKeys.IsKeyUp(Keys.I))
            {
              str1 = "i";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.J) && this.prevKeys.IsKeyUp(Keys.J))
            {
              str1 = "j";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.K) && this.prevKeys.IsKeyUp(Keys.K))
            {
              str1 = "k";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.L) && this.prevKeys.IsKeyUp(Keys.L))
            {
              str1 = "l";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.M) && this.prevKeys.IsKeyUp(Keys.M))
            {
              str1 = "m";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.N) && this.prevKeys.IsKeyUp(Keys.N))
            {
              str1 = "n";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.O) && this.prevKeys.IsKeyUp(Keys.O))
            {
              str1 = "o";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.P) && this.prevKeys.IsKeyUp(Keys.P))
            {
              str1 = "p";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.Q) && this.prevKeys.IsKeyUp(Keys.Q))
            {
              str1 = "q";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.R) && this.prevKeys.IsKeyUp(Keys.R))
            {
              str1 = "r";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.S) && this.prevKeys.IsKeyUp(Keys.S))
            {
              str1 = "s";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.T) && this.prevKeys.IsKeyUp(Keys.T))
            {
              str1 = "t";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.U) && this.prevKeys.IsKeyUp(Keys.U))
            {
              str1 = "u";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.V) && this.prevKeys.IsKeyUp(Keys.V))
            {
              str1 = "v";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.W) && this.prevKeys.IsKeyUp(Keys.W))
            {
              str1 = "w";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.X) && this.prevKeys.IsKeyUp(Keys.X))
            {
              str1 = "x";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.Y) && this.prevKeys.IsKeyUp(Keys.Y))
            {
              str1 = "y";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.Z) && this.prevKeys.IsKeyUp(Keys.Z))
            {
              str1 = "z";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
          }
          else
          {
            if (this.keyState.IsKeyDown(Keys.OemComma) && this.prevKeys.IsKeyUp(Keys.OemComma))
            {
              str1 = "<";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemPeriod) && this.prevKeys.IsKeyUp(Keys.OemPeriod))
            {
              str1 = ">";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemQuestion) && this.prevKeys.IsKeyUp(Keys.OemQuestion))
            {
              str1 = "?";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemSemicolon) && this.prevKeys.IsKeyUp(Keys.OemSemicolon))
            {
              str1 = ":";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemOpenBrackets) && this.prevKeys.IsKeyUp(Keys.OemOpenBrackets))
            {
              str1 = "{";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemCloseBrackets) && this.prevKeys.IsKeyUp(Keys.OemCloseBrackets))
            {
              str1 = "}";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemMinus) && this.prevKeys.IsKeyUp(Keys.OemMinus))
            {
              str1 = "_";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemPlus) && this.prevKeys.IsKeyUp(Keys.OemPlus))
            {
              str1 = "+";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemQuotes) && this.prevKeys.IsKeyUp(Keys.OemQuotes))
            {
              str1 = "\"";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemPipe) && this.prevKeys.IsKeyUp(Keys.OemPipe))
            {
              str1 = "|";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D0) && this.prevKeys.IsKeyUp(Keys.D0))
            {
              str1 = ")";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D1) && this.prevKeys.IsKeyUp(Keys.D1))
            {
              str1 = "!";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D2) && this.prevKeys.IsKeyUp(Keys.D2))
            {
              str1 = "@";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D3) && this.prevKeys.IsKeyUp(Keys.D3))
            {
              str1 = "#";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D4) && this.prevKeys.IsKeyUp(Keys.D4))
            {
              str1 = "$";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D5) && this.prevKeys.IsKeyUp(Keys.D5))
            {
              str1 = "%";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D6) && this.prevKeys.IsKeyUp(Keys.D6))
            {
              str1 = "^";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D7) && this.prevKeys.IsKeyUp(Keys.D7))
            {
              str1 = "&";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D8) && this.prevKeys.IsKeyUp(Keys.D8))
            {
              str1 = "*";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D9) && this.prevKeys.IsKeyUp(Keys.D9))
            {
              str1 = "(";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.A) && this.prevKeys.IsKeyUp(Keys.A))
            {
              str1 = "A";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.B) && this.prevKeys.IsKeyUp(Keys.B))
            {
              str1 = "B";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.C) && this.prevKeys.IsKeyUp(Keys.C))
            {
              str1 = "C";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D) && this.prevKeys.IsKeyUp(Keys.D))
            {
              str1 = "D";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.E) && this.prevKeys.IsKeyUp(Keys.E))
            {
              str1 = "E";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.F) && this.prevKeys.IsKeyUp(Keys.F))
            {
              str1 = "F";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.G) && this.prevKeys.IsKeyUp(Keys.G))
            {
              str1 = "G";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.H) && this.prevKeys.IsKeyUp(Keys.H))
            {
              str1 = "H";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.I) && this.prevKeys.IsKeyUp(Keys.I))
            {
              str1 = "I";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.J) && this.prevKeys.IsKeyUp(Keys.J))
            {
              str1 = "J";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.K) && this.prevKeys.IsKeyUp(Keys.K))
            {
              str1 = "K";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.L) && this.prevKeys.IsKeyUp(Keys.L))
            {
              str1 = "L";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.M) && this.prevKeys.IsKeyUp(Keys.M))
            {
              str1 = "M";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.N) && this.prevKeys.IsKeyUp(Keys.N))
            {
              str1 = "N";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.O) && this.prevKeys.IsKeyUp(Keys.O))
            {
              str1 = "O";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.P) && this.prevKeys.IsKeyUp(Keys.P))
            {
              str1 = "P";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.Q) && this.prevKeys.IsKeyUp(Keys.Q))
            {
              str1 = "Q";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.R) && this.prevKeys.IsKeyUp(Keys.R))
            {
              str1 = "R";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.S) && this.prevKeys.IsKeyUp(Keys.S))
            {
              str1 = "S";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.T) && this.prevKeys.IsKeyUp(Keys.T))
            {
              str1 = "T";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.U) && this.prevKeys.IsKeyUp(Keys.U))
            {
              str1 = "U";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.V) && this.prevKeys.IsKeyUp(Keys.V))
            {
              str1 = "V";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.W) && this.prevKeys.IsKeyUp(Keys.W))
            {
              str1 = "W";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.X) && this.prevKeys.IsKeyUp(Keys.X))
            {
              str1 = "X";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.Y) && this.prevKeys.IsKeyUp(Keys.Y))
            {
              str1 = "Y";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.Z) && this.prevKeys.IsKeyUp(Keys.Z))
            {
              str1 = "Z";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
          }
        }
        ans += str1;
      }
      if (count > 0 && count < lim && this.keyState.IsKeyDown(Keys.Space) && this.prevKeys.IsKeyUp(Keys.Space))
      {
        ans += " ";
        this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
      }
      if (count > 0 && (this.keyState.IsKeyDown(Keys.Back) && (this.kt > num || this.prevKeys.IsKeyUp(Keys.Back)) || this.keyState.IsKeyDown(Keys.Delete) && (this.kt > num || this.prevKeys.IsKeyUp(Keys.Delete))))
      {
        string str2 = "";
        for (int index = 0; index < ans.Length - 1; ++index)
          str2 += ans[index].ToString();
        ans = str2;
        this.sc.tick.Play(this.sc.ev, -0.6f, 0.0f);
      }
      this.pressedKeys = this.prevKeys.GetPressedKeys();
      if (pressedKeys.Length > 0)
      {
        if (this.pressedKeys.Length <= 0)
          return;
        if (pressedKeys[0] == this.pressedKeys[0])
        {
          if (this.kt <= num)
            return;
          this.kt = num - 4;
        }
        else
          this.kt = 0;
      }
      else
        this.kt = 0;
    }

    private void inputKeys4(ref string ans, int count, int lim)
    {
      string str1 = "";
      int num = 40;
      Keys[] pressedKeys = this.keyState.GetPressedKeys();
      if (pressedKeys.Length > 0)
        ++this.kt;
      bool flag1 = this.keyState.IsKeyDown(Keys.LeftShift) || this.keyState.IsKeyDown(Keys.RightShift);
      if (count < lim)
      {
        bool flag2 = false;
        if (count == 0 && this.keyState.IsKeyDown(Keys.OemPeriod) && this.prevKeys.IsKeyUp(Keys.OemPeriod))
        {
          str1 = ":";
          this.sc.tick.Play(this.sc.ev, -0.3f, 0.0f);
          this.sc.tick.Play(this.sc.ev, -0.8f, 0.0f);
          flag2 = true;
        }
        if (!flag2)
        {
          if (!flag1)
          {
            if (this.keyState.IsKeyDown(Keys.OemComma) && this.prevKeys.IsKeyUp(Keys.OemComma))
            {
              str1 = ",";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemPeriod) && this.prevKeys.IsKeyUp(Keys.OemPeriod))
            {
              str1 = ".";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemQuestion) && this.prevKeys.IsKeyUp(Keys.OemQuestion))
            {
              str1 = "/";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemSemicolon) && this.prevKeys.IsKeyUp(Keys.OemSemicolon))
            {
              str1 = ";";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemOpenBrackets) && this.prevKeys.IsKeyUp(Keys.OemOpenBrackets))
            {
              str1 = "[";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemCloseBrackets) && this.prevKeys.IsKeyUp(Keys.OemCloseBrackets))
            {
              str1 = "]";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemMinus) && this.prevKeys.IsKeyUp(Keys.OemMinus))
            {
              str1 = "-";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemPlus) && this.prevKeys.IsKeyUp(Keys.OemPlus))
            {
              str1 = "=";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemQuotes) && this.prevKeys.IsKeyUp(Keys.OemQuotes))
            {
              str1 = "'";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemPipe) && this.prevKeys.IsKeyUp(Keys.OemPipe))
            {
              str1 = "\\";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D0) && this.prevKeys.IsKeyUp(Keys.D0))
            {
              str1 = "0";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D1) && this.prevKeys.IsKeyUp(Keys.D1))
            {
              str1 = "1";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D2) && this.prevKeys.IsKeyUp(Keys.D2))
            {
              str1 = "2";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D3) && this.prevKeys.IsKeyUp(Keys.D3))
            {
              str1 = "3";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D4) && this.prevKeys.IsKeyUp(Keys.D4))
            {
              str1 = "4";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D5) && this.prevKeys.IsKeyUp(Keys.D5))
            {
              str1 = "5";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D6) && this.prevKeys.IsKeyUp(Keys.D6))
            {
              str1 = "6";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D7) && this.prevKeys.IsKeyUp(Keys.D7))
            {
              str1 = "7";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D8) && this.prevKeys.IsKeyUp(Keys.D8))
            {
              str1 = "8";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D9) && this.prevKeys.IsKeyUp(Keys.D9))
            {
              str1 = "9";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.A) && this.prevKeys.IsKeyUp(Keys.A))
            {
              str1 = "a";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.B) && this.prevKeys.IsKeyUp(Keys.B))
            {
              str1 = "b";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.C) && this.prevKeys.IsKeyUp(Keys.C))
            {
              str1 = "c";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D) && this.prevKeys.IsKeyUp(Keys.D))
            {
              str1 = "d";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.E) && this.prevKeys.IsKeyUp(Keys.E))
            {
              str1 = "e";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.F) && this.prevKeys.IsKeyUp(Keys.F))
            {
              str1 = "f";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.G) && this.prevKeys.IsKeyUp(Keys.G))
            {
              str1 = "g";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.H) && this.prevKeys.IsKeyUp(Keys.H))
            {
              str1 = "h";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.I) && this.prevKeys.IsKeyUp(Keys.I))
            {
              str1 = "i";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.J) && this.prevKeys.IsKeyUp(Keys.J))
            {
              str1 = "j";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.K) && this.prevKeys.IsKeyUp(Keys.K))
            {
              str1 = "k";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.L) && this.prevKeys.IsKeyUp(Keys.L))
            {
              str1 = "l";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.M) && this.prevKeys.IsKeyUp(Keys.M))
            {
              str1 = "m";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.N) && this.prevKeys.IsKeyUp(Keys.N))
            {
              str1 = "n";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.O) && this.prevKeys.IsKeyUp(Keys.O))
            {
              str1 = "o";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.P) && this.prevKeys.IsKeyUp(Keys.P))
            {
              str1 = "p";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.Q) && this.prevKeys.IsKeyUp(Keys.Q))
            {
              str1 = "q";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.R) && this.prevKeys.IsKeyUp(Keys.R))
            {
              str1 = "r";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.S) && this.prevKeys.IsKeyUp(Keys.S))
            {
              str1 = "s";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.T) && this.prevKeys.IsKeyUp(Keys.T))
            {
              str1 = "t";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.U) && this.prevKeys.IsKeyUp(Keys.U))
            {
              str1 = "u";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.V) && this.prevKeys.IsKeyUp(Keys.V))
            {
              str1 = "v";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.W) && this.prevKeys.IsKeyUp(Keys.W))
            {
              str1 = "w";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.X) && this.prevKeys.IsKeyUp(Keys.X))
            {
              str1 = "x";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.Y) && this.prevKeys.IsKeyUp(Keys.Y))
            {
              str1 = "y";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.Z) && this.prevKeys.IsKeyUp(Keys.Z))
            {
              str1 = "z";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
          }
          else
          {
            if (this.keyState.IsKeyDown(Keys.OemComma) && this.prevKeys.IsKeyUp(Keys.OemComma))
            {
              str1 = "<";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemPeriod) && this.prevKeys.IsKeyUp(Keys.OemPeriod))
            {
              str1 = ">";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemQuestion) && this.prevKeys.IsKeyUp(Keys.OemQuestion))
            {
              str1 = "?";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemSemicolon) && this.prevKeys.IsKeyUp(Keys.OemSemicolon))
            {
              str1 = ":";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemOpenBrackets) && this.prevKeys.IsKeyUp(Keys.OemOpenBrackets))
            {
              str1 = "{";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemCloseBrackets) && this.prevKeys.IsKeyUp(Keys.OemCloseBrackets))
            {
              str1 = "}";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemMinus) && this.prevKeys.IsKeyUp(Keys.OemMinus))
            {
              str1 = "_";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemPlus) && this.prevKeys.IsKeyUp(Keys.OemPlus))
            {
              str1 = "+";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemQuotes) && this.prevKeys.IsKeyUp(Keys.OemQuotes))
            {
              str1 = "\"";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.OemPipe) && this.prevKeys.IsKeyUp(Keys.OemPipe))
            {
              str1 = "|";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D0) && this.prevKeys.IsKeyUp(Keys.D0))
            {
              str1 = ")";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D1) && this.prevKeys.IsKeyUp(Keys.D1))
            {
              str1 = "!";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D2) && this.prevKeys.IsKeyUp(Keys.D2))
            {
              str1 = "@";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D3) && this.prevKeys.IsKeyUp(Keys.D3))
            {
              str1 = "#";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D4) && this.prevKeys.IsKeyUp(Keys.D4))
            {
              str1 = "$";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D5) && this.prevKeys.IsKeyUp(Keys.D5))
            {
              str1 = "%";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D6) && this.prevKeys.IsKeyUp(Keys.D6))
            {
              str1 = "^";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D7) && this.prevKeys.IsKeyUp(Keys.D7))
            {
              str1 = "&";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D8) && this.prevKeys.IsKeyUp(Keys.D8))
            {
              str1 = "*";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D9) && this.prevKeys.IsKeyUp(Keys.D9))
            {
              str1 = "(";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.A) && this.prevKeys.IsKeyUp(Keys.A))
            {
              str1 = "A";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.B) && this.prevKeys.IsKeyUp(Keys.B))
            {
              str1 = "B";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.C) && this.prevKeys.IsKeyUp(Keys.C))
            {
              str1 = "C";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.D) && this.prevKeys.IsKeyUp(Keys.D))
            {
              str1 = "D";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.E) && this.prevKeys.IsKeyUp(Keys.E))
            {
              str1 = "E";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.F) && this.prevKeys.IsKeyUp(Keys.F))
            {
              str1 = "F";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.G) && this.prevKeys.IsKeyUp(Keys.G))
            {
              str1 = "G";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.H) && this.prevKeys.IsKeyUp(Keys.H))
            {
              str1 = "H";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.I) && this.prevKeys.IsKeyUp(Keys.I))
            {
              str1 = "I";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.J) && this.prevKeys.IsKeyUp(Keys.J))
            {
              str1 = "J";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.K) && this.prevKeys.IsKeyUp(Keys.K))
            {
              str1 = "K";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.L) && this.prevKeys.IsKeyUp(Keys.L))
            {
              str1 = "L";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.M) && this.prevKeys.IsKeyUp(Keys.M))
            {
              str1 = "M";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.N) && this.prevKeys.IsKeyUp(Keys.N))
            {
              str1 = "N";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.O) && this.prevKeys.IsKeyUp(Keys.O))
            {
              str1 = "O";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.P) && this.prevKeys.IsKeyUp(Keys.P))
            {
              str1 = "P";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.Q) && this.prevKeys.IsKeyUp(Keys.Q))
            {
              str1 = "Q";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.R) && this.prevKeys.IsKeyUp(Keys.R))
            {
              str1 = "R";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.S) && this.prevKeys.IsKeyUp(Keys.S))
            {
              str1 = "S";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.T) && this.prevKeys.IsKeyUp(Keys.T))
            {
              str1 = "T";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.U) && this.prevKeys.IsKeyUp(Keys.U))
            {
              str1 = "U";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.V) && this.prevKeys.IsKeyUp(Keys.V))
            {
              str1 = "V";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.W) && this.prevKeys.IsKeyUp(Keys.W))
            {
              str1 = "W";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.X) && this.prevKeys.IsKeyUp(Keys.X))
            {
              str1 = "X";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.Y) && this.prevKeys.IsKeyUp(Keys.Y))
            {
              str1 = "Y";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.keyState.IsKeyDown(Keys.Z) && this.prevKeys.IsKeyUp(Keys.Z))
            {
              str1 = "Z";
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
          }
        }
        ans += str1;
      }
      if (count > 0 && count < lim && this.keyState.IsKeyDown(Keys.Space) && this.prevKeys.IsKeyUp(Keys.Space))
      {
        ans += " ";
        this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
      }
      if (count > 0 && (this.keyState.IsKeyDown(Keys.Back) && (this.kt > num || this.prevKeys.IsKeyUp(Keys.Back)) || this.keyState.IsKeyDown(Keys.Delete) && (this.kt > num || this.prevKeys.IsKeyUp(Keys.Delete))))
      {
        string str2 = "";
        for (int index = 0; index < ans.Length - 1; ++index)
          str2 += ans[index].ToString();
        ans = str2;
        this.sc.tick.Play(this.sc.ev, -0.6f, 0.0f);
      }
      this.pressedKeys = this.prevKeys.GetPressedKeys();
      if (pressedKeys.Length > 0)
      {
        if (this.pressedKeys.Length <= 0)
          return;
        if (pressedKeys[0] == this.pressedKeys[0])
        {
          if (this.kt <= num)
            return;
          this.kt = num - 8;
        }
        else
          this.kt = 0;
      }
      else
        this.kt = 0;
    }

    public override void Update(
      GameTime gameTime,
      bool otherScreenHasFocus,
      bool coveredByOtherScreen)
    {
      ++this.myframe;
      this.whichButton = "none";
      this.queryButton(this.yesRect, "YES");
      this.queryButton(this.okRect, "OKAY");
      this.queryButton(this.noRect, "NO");
      this.queryButton(this.arrRect, "ARROW");
      base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
    }

    public override void Draw(GameTime gameTime)
    {
      if (this.flag != 5)
        this.ScreenManager.FadeBackBufferToBlack((int) this.TransitionAlpha * 2 / 3);
      Color color1 = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) this.TransitionAlpha);
      Color color2 = new Color(30, 30, 30, (int) this.TransitionAlpha);
      this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) null, this.hudMatrix);
      if (this.flag != 5 && this.flag != 15 && this.flag != 14 && this.flag != 16)
      {
        this.spriteBatch.Draw(this.ScreenManager.menuBlob2, this.backgroundRectangle, new Rectangle?(this.menuSlate), color1);
        string[] strArray = this.message.Split('\r', '\n');
        for (int index = 0; index < strArray.Length; ++index)
        {
          float x = this.textPosition.X - this.font.MeasureString(strArray[index]).X / 2f;
          float y = this.textPosition.Y + this.textSize.Y / (float) strArray.Length * (float) index;
          this.spriteBatch.DrawString(this.font, strArray[index], new Vector2(x + 3f, y + 1f), color2, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
          this.spriteBatch.DrawString(this.font, strArray[index], new Vector2(x + 1f, y + 2f), color2, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
          this.spriteBatch.DrawString(this.font, strArray[index], new Vector2(x, y), color1, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
        }
      }
      if (this.flag == 16)
      {
        this.spriteBatch.Draw(this.ScreenManager.menuBlob2, this.backgroundRectangle, new Rectangle?(this.bgBlue), color1);
        char[] chArray = new char[2]{ '\r', '\n' };
        float num1 = 0.65f;
        string[] strArray = this.message.Split(chArray);
        int num2 = 17;
        if (strArray.Length > 2)
          num2 = 30;
        for (int index = 0; index < strArray.Length; ++index)
        {
          float x = this.textPosition.X - this.sc.fontsmall.MeasureString(strArray[index]).X / 2f;
          float y = (float) ((double) num2 + (double) this.textPosition.Y + (double) this.textSize.Y * (double) num1 / (double) strArray.Length * (double) index);
          this.spriteBatch.DrawString(this.sc.fontsmall, strArray[index], new Vector2(x + 3f, y + 1f), color2, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
          this.spriteBatch.DrawString(this.sc.fontsmall, strArray[index], new Vector2(x + 1f, y + 2f), color2, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
          this.spriteBatch.DrawString(this.sc.fontsmall, strArray[index], new Vector2(x, y), color1, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
        }
        if (!this.techYesNo)
        {
          string text1 = "X";
          string text2 = "  OKAY";
          string text3 = "OKAY  ";
          Vector2 position = new Vector2(0.0f, this.bottom - 25f);
          position.Y -= this.squarefont.MeasureString(text1).X / 3f;
          position.X = this.textPosition.X - this.sc.fontsmall.MeasureString(text3).X / 2f;
          this.yesRect = new Rectangle((int) ((double) position.X - 1.0), (int) position.Y, 60, 30);
          if (this.whichButton == "YES")
          {
            this.spriteBatch.Draw(this.sc.overlay, new Rectangle(this.yesRect.X, this.yesRect.Y + 1, 30, 30), new Rectangle?(this.whitebox), Color.White);
            this.spriteBatch.DrawString(this.squarefont, text1, position, Color.Black, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
          }
          else
            this.spriteBatch.DrawString(this.squarefont, text1, position, color1, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
          position.X = this.textPosition.X + 22f;
          position.Y += 20f;
          this.spriteBatch.DrawString(this.sc.fontsmall, text2, position, color1, 0.0f, new Vector2(this.sc.fontsmall.MeasureString(text2).X / 2f, this.sc.fontsmall.MeasureString(text2).Y / 2f), 0.8f, SpriteEffects.None, 0.0f);
        }
        else
        {
          string text4 = "Y";
          string text5 = "N";
          string text6 = "  YES              NO";
          string text7 = "YES              NO";
          Vector2 position = new Vector2(0.0f, this.bottom - 25f);
          position.Y -= this.squarefont.MeasureString(text5).X / 3f;
          position.X = this.textPosition.X - this.sc.fontsmall.MeasureString(text7).X / 2f;
          this.yesRect = new Rectangle((int) ((double) position.X - 1.0), (int) position.Y, 60, 30);
          if (this.whichButton == "YES")
          {
            this.spriteBatch.Draw(this.sc.overlay, new Rectangle(this.yesRect.X, this.yesRect.Y + 1, 30, 30), new Rectangle?(this.whitebox), Color.White);
            this.spriteBatch.DrawString(this.squarefont, text4, position, Color.Black, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
          }
          else
            this.spriteBatch.DrawString(this.squarefont, text4, position, color1, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
          position.X = (float) (5.0 + ((double) this.textPosition.X - (double) this.sc.fontsmall.MeasureString(text7).X / 2.0) + (double) this.sc.fontsmall.MeasureString(" ").X * 17.0);
          this.noRect = new Rectangle((int) ((double) position.X - 1.0), (int) position.Y, 60, 30);
          if (this.whichButton == "NO")
          {
            this.spriteBatch.Draw(this.sc.overlay, new Rectangle(this.noRect.X, this.noRect.Y + 1, 30, 30), new Rectangle?(this.whitebox), Color.White);
            this.spriteBatch.DrawString(this.squarefont, text5, position, Color.Black, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
          }
          else
            this.spriteBatch.DrawString(this.squarefont, text5, position, color1, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
          position.X = this.textPosition.X + 17f;
          position.Y += 20f;
          this.spriteBatch.DrawString(this.sc.fontsmall, text6, position, color1, 0.0f, new Vector2(this.sc.fontsmall.MeasureString(text6).X / 2f, this.sc.fontsmall.MeasureString(text6).Y / 2f), 0.8f, SpriteEffects.None, 0.0f);
        }
      }
      if (this.flag == 15 || this.flag == 14 || this.flag == 17)
      {
        this.spriteBatch.Draw(this.ScreenManager.menuBlob2, this.backgroundRectangle, new Rectangle?(this.bgBlue), color1);
        string text8 = "DESCRIPTION";
        if (this.flag == 14)
          text8 = "TITLE";
        if (this.flag == 17)
          text8 = "WaterMark";
        Vector2 position1 = new Vector2((float) (640.0 - (double) this.sc.fontsmall.MeasureString(text8).X / 2.0), this.top);
        this.spriteBatch.DrawString(this.sc.fontsmall, text8, new Vector2(position1.X + 3f, position1.Y + 1f), color2, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
        this.spriteBatch.DrawString(this.sc.fontsmall, text8, new Vector2(position1.X + 1f, position1.Y + 2f), color2, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
        this.spriteBatch.DrawString(this.sc.fontsmall, text8, position1, Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
        this.me.Clear();
        string[] strArray = this.message.Split(' ');
        string str = "";
        bool flag = false;
        for (int index = 0; index < strArray.Length; ++index)
        {
          str = str + strArray[index] + " ";
          flag = false;
          if (str.Length > 22)
          {
            this.me.Add(str + "\n");
            str = "";
            flag = true;
          }
        }
        if (!flag)
          this.me.Add(str);
        for (int index = 0; index < this.me.Count; ++index)
        {
          float x = this.textPosition.X - this.sc.fontsmall.MeasureString(this.me[index]).X / 2f;
          float y = 5f + this.textPosition.Y + (float) (26 * index);
          this.spriteBatch.DrawString(this.sc.fontsmall, this.me[index], new Vector2(x + 3f, y + 1f), color2, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
          this.spriteBatch.DrawString(this.sc.fontsmall, this.me[index], new Vector2(x + 1f, y + 2f), color2, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
          this.spriteBatch.DrawString(this.sc.fontsmall, this.me[index], new Vector2(x, y), color1, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
        }
        string text9 = "Y";
        string text10 = "N";
        string text11 = "  YES              NO";
        string text12 = "YES              NO";
        Vector2 position2 = new Vector2(0.0f, this.bottom - 25f);
        position2.Y -= this.squarefont.MeasureString(text10).X / 3f;
        position2.X = this.textPosition.X - this.sc.fontsmall.MeasureString(text12).X / 2f;
        this.yesRect = new Rectangle((int) ((double) position2.X - 1.0), (int) position2.Y, 60, 30);
        if (this.whichButton == "YES")
        {
          this.spriteBatch.Draw(this.sc.overlay, new Rectangle(this.yesRect.X, this.yesRect.Y + 1, 30, 30), new Rectangle?(this.whitebox), Color.White);
          this.spriteBatch.DrawString(this.squarefont, text9, position2, Color.Black, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
        }
        else
          this.spriteBatch.DrawString(this.squarefont, text9, position2, color1, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
        position2.X = (float) (5.0 + ((double) this.textPosition.X - (double) this.sc.fontsmall.MeasureString(text12).X / 2.0) + (double) this.sc.fontsmall.MeasureString(" ").X * 17.0);
        this.noRect = new Rectangle((int) ((double) position2.X - 1.0), (int) position2.Y, 60, 30);
        if (this.whichButton == "NO")
        {
          this.spriteBatch.Draw(this.sc.overlay, new Rectangle(this.noRect.X, this.noRect.Y + 1, 30, 30), new Rectangle?(this.whitebox), Color.White);
          this.spriteBatch.DrawString(this.squarefont, text10, position2, Color.Black, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
        }
        else
          this.spriteBatch.DrawString(this.squarefont, text10, position2, color1, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
        position2.X = this.textPosition.X + 17f;
        position2.Y += 20f;
        this.spriteBatch.DrawString(this.sc.fontsmall, text11, position2, color1, 0.0f, new Vector2(this.sc.fontsmall.MeasureString(text11).X / 2f, this.sc.fontsmall.MeasureString(text11).Y / 2f), 0.8f, SpriteEffects.None, 0.0f);
      }
      if (this.flag == 5)
      {
        int num3 = this.viewport.X + 20;
        int num4 = this.viewport.Height - 40;
        int width = Math.Max((int) this.font2.MeasureString("X").X * 32, (int) this.font2.MeasureString(this.message).X);
        this.spriteBatch.Draw(this.sc.blackTexture, new Rectangle(num3 + 5, num4 - 20, width, (int) (0.60000002384185791 * (double) this.font2.MeasureString("X").Y)), new Color(1, 1, 1, (int) byte.MaxValue));
        char[] chArray = new char[2]{ '\r', '\n' };
        foreach (string text in this.message.Split(chArray))
          this.spriteBatch.DrawString(this.font2, text, new Vector2((float) (num3 + 15), (float) (num4 - 29)), color1, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
        if (this.sc.chatHistory.Count > 0)
        {
          int num5 = 0;
          int num6 = Math.Max(0, this.sc.chatHistory.Count - 1 - this.sc.chatIndex);
          int num7 = Math.Max(num6 - 13, 0);
          float num8 = 1f;
          for (int index = num6; index >= num7; --index)
          {
            num5 += 20;
            if (num5 >= 60)
              num8 -= 0.055f;
            this.spriteBatch.DrawString(this.font2, this.sc.chatHistory[index].name, new Vector2((float) (this.viewport.X + 25), (float) (num4 - 50 - num5)), this.sc.chatHistory[index].nameColor * num8, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
            if (this.sc.chatHistory[index].gap == 0)
              this.spriteBatch.DrawString(this.font2, this.sc.chatHistory[index].message, new Vector2((float) ((double) this.font2.MeasureString(this.sc.chatHistory[index].name).X * 0.800000011920929 + (double) this.viewport.X + 25.0), (float) (num4 - 50 - num5)), this.sc.chatHistory[index].messColor * num8, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
            else
              this.spriteBatch.DrawString(this.font2, this.sc.chatHistory[index].message, new Vector2((float) (this.sc.chatHistory[index].gap + this.viewport.X + 25), (float) (num4 - 50 - num5)), this.sc.chatHistory[index].messColor * num8, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
          }
        }
      }
      if (this.includeOkay)
      {
        string text = "X O";
        Vector2 position = new Vector2(0.0f, (float) ((double) this.bottom - (double) this.vPad - (double) this.squarefont.MeasureString(text).Y / 2.0));
        position.X = this.textPosition.X - this.squarefont.MeasureString(text).X / 2f;
        this.okRect = new Rectangle((int) position.X - 1, (int) position.Y, 60, 30);
        if (this.whichButton == "OKAY")
        {
          this.spriteBatch.Draw(this.sc.overlay, new Rectangle(this.okRect.X, this.okRect.Y, 30, 30), new Rectangle?(this.whitebox), Color.White);
          this.spriteBatch.DrawString(this.squarefont, "X", position, Color.Black, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
        }
        else
          this.spriteBatch.DrawString(this.squarefont, "X", position, color1, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
        position.X = this.textPosition.X;
        position.Y += (float) ((double) this.squarefont.MeasureString("okay").Y / 3.0 + 2.0);
        this.spriteBatch.DrawString(this.font, "okay", position, color1, 0.0f, new Vector2(this.font.MeasureString("x").X / 2f, this.font.MeasureString("x okay").Y / 2f), 0.8f, SpriteEffects.None, 0.0f);
      }
      if (this.includeYesNo)
      {
        string text13 = "Y    N";
        string text14 = "Y";
        string text15 = "N";
        string text16 = "  YES         NO";
        string text17 = "YES         NO";
        Vector2 position3 = new Vector2(0.0f, (float) ((double) this.bottom - (double) this.vPad - (double) this.squarefont.MeasureString(text13).Y / 2.0));
        position3.Y -= this.squarefont.MeasureString(text15).X / 3f;
        position3.X = this.textPosition.X - this.font.MeasureString(text17).X / 2f;
        this.yesRect = new Rectangle((int) ((double) position3.X - 1.0), (int) ((double) position3.Y + 1.0), 60, 30);
        if (this.whichButton == "YES")
        {
          this.spriteBatch.Draw(this.sc.overlay, new Rectangle(this.yesRect.X, this.yesRect.Y, 30, 30), new Rectangle?(this.whitebox), Color.White);
          this.spriteBatch.DrawString(this.squarefont, text14, position3, Color.Black, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
        }
        else
          this.spriteBatch.DrawString(this.squarefont, text14, position3, color1, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
        position3.X = (float) ((double) this.textPosition.X - (double) this.font.MeasureString(text17).X / 2.0 + (double) this.font.MeasureString(" ").X * 13.0);
        this.noRect = new Rectangle((int) ((double) position3.X - 1.0), (int) position3.Y, 60, 30);
        if (this.whichButton == "NO")
        {
          this.spriteBatch.Draw(this.sc.overlay, new Rectangle(this.noRect.X, this.noRect.Y + 1, 30, 30), new Rectangle?(this.whitebox), Color.White);
          this.spriteBatch.DrawString(this.squarefont, text15, position3, Color.Black, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
        }
        else
          this.spriteBatch.DrawString(this.squarefont, text15, position3, color1, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
        position3.X = this.textPosition.X;
        position3.Y += (float) ((double) this.squarefont.MeasureString(text15).X / 2.0 - 0.0);
        this.spriteBatch.DrawString(this.font, text16, position3, color1, 0.0f, new Vector2(this.font.MeasureString(text16).X / 2f, this.font.MeasureString(text16).Y / 2f), 0.8f, SpriteEffects.None, 0.0f);
        if (this.flag == 2)
        {
          Vector2 position4 = new Vector2(this.right - (float) this.arrows.Width - (float) this.hPad, (float) ((double) this.viewportSize.Y / 2.0 - 25.0));
          this.spriteBatch.Draw(this.sc.menuBlob2, position4, new Rectangle?(this.arrows), Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
          this.arrRect = new Rectangle((int) position4.X, (int) position4.Y, this.arrows.Width, this.arrows.Height);
        }
      }
      if (this.flag == 3)
      {
        Vector2 position = new Vector2(this.textPosition.X - (float) (this.meter.Width / 2), this.bottom - (float) this.vPad - (float) this.meter.Height);
        this.spriteBatch.Draw(this.sc.menuBlob2, position, new Rectangle?(new Rectangle(this.meterColor.X, this.meterColor.Y, 14, this.meterColor.Height)), Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
        this.spriteBatch.Draw(this.sc.menuBlob2, position, new Rectangle?(this.meter), Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
      }
      this.spriteBatch.End();
    }

    public void queryButton(Rectangle rr, string word)
    {
      this.sc.adjustVector(this.mm);
      Vector2 mm = this.mm;
      Vector2 one = Vector2.One;
      if ((double) this.sc.aspectratio <= 1.0)
        mm.Y -= (float) (((double) this.sc.screenSize.Height - (double) this.sc.screenSize.Height * (double) this.sc.aspectratio) * (0.5 / (double) this.sc.aspectratio));
      else
        mm.X -= (float) (((double) this.sc.screenSize.Width - (double) this.sc.screenSize.Width / (double) this.sc.aspectratio) * (0.5 * (double) this.sc.aspectratio));
      Vector2 vector2_1 = new Vector2((float) this.sc.screenSize.Width / (float) this.sc.origSize.Width, (float) this.sc.screenSize.Height / (float) this.sc.origSize.Height);
      Vector2 vector2_2 = mm / vector2_1;
      if (((double) vector2_2.Y <= (double) rr.Y || (double) vector2_2.Y > (double) (rr.Y + rr.Height) || (double) vector2_2.X <= (double) rr.X ? 0 : ((double) vector2_2.X <= (double) (rr.X + rr.Width) ? 1 : 0)) == 0)
        return;
      this.whichButton = word;
    }
  }
}
