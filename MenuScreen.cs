// Decompiled with JetBrains decompiler
// Type: Blood.MenuScreen
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

#nullable disable
namespace Blood
{
  internal abstract class MenuScreen : GameScreen
  {
    public static PlayerIndex playerIndex = PlayerIndex.One;
    private float percX = 90f;
    private float percY = 90f;
    private SpriteBatch spriteBatch;
    private MenuEntry myheight;
    private List<MenuEntry> menuEntries = new List<MenuEntry>();
    private int selectedEntry;
    public string menuTitle;
    public static string title;
    private ContentManager content;
    private Matrix projectionMatrix;
    private Matrix viewMatrix;
    private float aspectRatio;
    private Vector3 camlookpos = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 campos = new Vector3(0.0f, 0.0f, 2000f);
    private float mytimer;
    private int onceflag;
    public Random rr;
    private Vector2 textPosition = new Vector2(256f);
    private float radians = Convert.ToSingle(Math.PI / 5.0);
    private ScreenManager sc;
    private float timeadjust;
    private string[] lists;
    private string text;
    private Texture2D blue;
    private Texture2D red;
    private List<Rectangle> point = new List<Rectangle>();
    private List<Rectangle> valbox = new List<Rectangle>();
    private int whichbutton;
    private bool IncDec;
    private bool delayinput = true;
    private bool mousemoving;
    private GamePadState prevstate;
    private PlayerIndex myplayer;
    private GamePadState gamePadState;
    private KeyboardState keyState;
    private KeyboardState prevkeyState;
    private static MouseState mouseState;
    private static MouseState prevMouse;
    private float mouseX;
    private float mouseY;

    public string Text
    {
      get => this.text;
      set => this.text = value;
    }

    protected IList<MenuEntry> MenuEntries => (IList<MenuEntry>) this.menuEntries;

    public MenuScreen(string mm)
    {
      this.menuTitle = mm;
      this.TransitionOnTime = TimeSpan.FromSeconds(1.0);
      this.TransitionOffTime = TimeSpan.FromSeconds(1.0);
    }

    public override void LoadContent()
    {
      this.rr = new Random();
      if (this.content == null)
        this.content = new ContentManager((IServiceProvider) this.ScreenManager.Game.Services, "Content");
      this.sc = this.ScreenManager;
      this.spriteBatch = this.ScreenManager.SpriteBatch;
      this.myheight = this.menuEntries[0];
      this.aspectRatio = (float) this.ScreenManager.GraphicsDevice.Viewport.Width / (float) this.ScreenManager.GraphicsDevice.Viewport.Height;
      this.projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(30f), 1.77f, 1f, 490000f);
      this.viewMatrix = Matrix.CreateLookAt(this.campos, this.camlookpos, Vector3.Up);
      this.blue = new Texture2D(this.sc.GraphicsDevice, 1, 1);
      this.red = new Texture2D(this.sc.GraphicsDevice, 1, 1);
      this.blue.SetData<Color>(new Color[1]
      {
        new Color(10, 10, 200, 50)
      });
      this.red.SetData<Color>(new Color[1]
      {
        new Color(220, 10, 10, 50)
      });
      for (int index = 0; index < this.menuEntries.Count; ++index)
      {
        MenuEntry menuEntry = this.menuEntries[index];
        menuEntry.LoadContent(this);
        if (this.menuTitle == "Game Video Settings")
        {
          if (menuEntry.Text == "BRITE")
            menuEntry.Amount = this.sc.gamefadeSetting;
          if (menuEntry.Text == "FILTER")
            menuEntry.Amount = this.sc.gamefilterSetting;
          if (menuEntry.Text == "LEVEL")
            menuEntry.Amount = this.sc.gameintenseSetting;
          if (menuEntry.Text == "ALIAS")
            menuEntry.Amount = (float) this.sc.aliasSetting;
        }
        if (this.menuTitle == "Video Settings")
        {
          this.percX = (float) (1.0 - ((double) this.sc.siders - 5.0) / 640.0);
          this.percY = (float) (1.0 - ((double) this.sc.topper - 5.0) / 360.0);
          if (menuEntry.Text == "BRIGHTEN")
            menuEntry.Amount = (float) ((this.sc.brightness - 28) / 10);
          if (menuEntry.Text == "CONTRAST")
            menuEntry.Amount = (float) ((this.sc.contrast - 28) / 10);
          if (menuEntry.Text == "BORDERS")
            menuEntry.Amount = 0.0f;
        }
        if (menuEntry.Text == "PLANET")
        {
          menuEntry.Amount = (float) this.ScreenManager.bgindex;
          menuEntry.Text = menuEntry.Lists[this.ScreenManager.bgindex];
        }
        if (menuEntry.Text == "VIBRO")
          menuEntry.Amount = (float) this.sc.vibroSetting;
        if (this.menuTitle == "Audio Settings")
        {
          if (menuEntry.Text == "SOUND")
            menuEntry.Amount = (float) (int) Math.Round(Math.Sqrt((double) this.sc.ev * 100.0));
          if (menuEntry.Text == "MUSIC")
            menuEntry.Amount = (float) (int) Math.Round(Math.Sqrt((double) this.sc.mv * 100.0));
          if (menuEntry.Text == "RADIO")
            menuEntry.Amount = (float) (int) Math.Round(Math.Sqrt((double) this.sc.voiceVolume * 100.0));
        }
        if (this.menuTitle == "SetCamera")
        {
          if (menuEntry.Text == "Distance")
            menuEntry.Amount = (float) this.sc.allcamsradius[menuEntry.Myindex];
          if (menuEntry.Text == "Orbiting")
          {
            menuEntry.Amount = (float) this.sc.allcamsorbit[menuEntry.Myindex];
            menuEntry.Amount = MathHelper.Clamp((float) this.sc.roverrotlock, 0.0f, 1f);
          }
          if (menuEntry.Text == "Altitude")
          {
            menuEntry.Amount = MathHelper.Clamp((float) this.sc.allcamsaltitude[menuEntry.Myindex], 0.0f, 1f);
            menuEntry.Amount = 1f - MathHelper.Clamp((float) this.sc.roverhitelock, 0.0f, 1f);
          }
          if (menuEntry.Text == "Lensing")
            menuEntry.Amount = (float) this.sc.allcamslens[menuEntry.Myindex];
        }
        if (this.menuTitle == "SetCamera2")
        {
          if (menuEntry.Text == "Distance")
            menuEntry.Amount = (float) this.sc.allcamsradius[menuEntry.Myindex];
          if (menuEntry.Text == "Orbiting")
          {
            menuEntry.Amount = (float) this.sc.allcamsorbit[menuEntry.Myindex];
            menuEntry.Amount = MathHelper.Clamp((float) this.sc.landerrotlock, 0.0f, 1f);
          }
          if (menuEntry.Text == "Altitude")
          {
            menuEntry.Amount = MathHelper.Clamp((float) this.sc.allcamsaltitude[menuEntry.Myindex], 0.0f, 1f);
            menuEntry.Amount = 1f - MathHelper.Clamp((float) this.sc.landerhitelock, 0.0f, 1f);
          }
          if (menuEntry.Text == "Lensing")
            menuEntry.Amount = (float) this.sc.allcamslens[menuEntry.Myindex];
        }
        if (this.menuTitle == "Game Settings1")
        {
          if (menuEntry.Text == "INVERT X")
          {
            int num = 0;
            if (this.sc.space_rinvertX == -1)
              num = 1;
            menuEntry.Amount = (float) num;
          }
          if (menuEntry.Text == "INVERT Y")
          {
            int num = 0;
            if (this.sc.space_rinvertY == -1)
              num = 1;
            menuEntry.Amount = (float) num;
          }
          if (menuEntry.Text == "TURN SPEED")
          {
            int num = (int) MathHelper.Clamp((float) (int) MathHelper.Lerp(0.0f, 10f, (float) (((double) this.sc.space_rsentivityX - 0.20000000298023224) / 1.7999999523162842)), 0.0f, 10f);
            menuEntry.Amount = (float) num;
          }
          if (menuEntry.Text == "TILT SPEED")
          {
            int num = (int) MathHelper.Clamp((float) (int) MathHelper.Lerp(0.0f, 10f, (float) (((double) this.sc.space_rsentivityY - 0.20000000298023224) / 1.7999999523162842)), 0.0f, 10f);
            menuEntry.Amount = (float) num;
          }
          if (menuEntry.Text == "VIBRATION")
            menuEntry.Amount = (float) this.sc.vibroSetting;
        }
        if (this.menuTitle == "Game Settings2")
        {
          if (menuEntry.Text == "INVERT X")
          {
            int num = 0;
            if (this.sc.space_invertX == -1)
              num = 1;
            menuEntry.Amount = (float) num;
          }
          if (menuEntry.Text == "INVERT Y")
          {
            int num = 0;
            if (this.sc.space_invertY == -1)
              num = 1;
            menuEntry.Amount = (float) num;
          }
          if (menuEntry.Text == "TURN SPEED")
          {
            int num = (int) MathHelper.Clamp((float) (int) MathHelper.Lerp(0.0f, 10f, (float) (((double) this.sc.space_sentivityX - 0.20000000298023224) / 1.7999999523162842)), 0.0f, 10f);
            menuEntry.Amount = (float) num;
          }
          if (menuEntry.Text == "TILT SPEED")
          {
            int num = (int) MathHelper.Clamp((float) (int) MathHelper.Lerp(0.0f, 10f, (float) (((double) this.sc.space_sentivityY - 0.20000000298023224) / 1.7999999523162842)), 0.0f, 10f);
            menuEntry.Amount = (float) num;
          }
          if (menuEntry.Text == "VIBRATION")
            menuEntry.Amount = (float) this.sc.vibroSetting;
        }
        if (this.menuTitle == "Game Settings3")
        {
          if (menuEntry.Text == "INVERT X")
          {
            int num = 0;
            if (this.sc.space_winvertX == -1)
              num = 1;
            menuEntry.Amount = (float) num;
          }
          if (menuEntry.Text == "INVERT Y")
          {
            int num = 0;
            if (this.sc.space_winvertY == -1)
              num = 1;
            menuEntry.Amount = (float) num;
          }
          if (menuEntry.Text == "TURN SPEED")
          {
            int num = (int) MathHelper.Clamp((float) (int) MathHelper.Lerp(0.0f, 10f, (float) (((double) this.sc.space_wsentivityX - 0.20000000298023224) / 1.7999999523162842)), 0.0f, 10f);
            menuEntry.Amount = (float) num;
          }
          if (menuEntry.Text == "TILT SPEED")
          {
            int num = (int) MathHelper.Clamp((float) (int) MathHelper.Lerp(0.0f, 10f, (float) (((double) this.sc.space_wsentivityY - 0.20000000298023224) / 1.7999999523162842)), 0.0f, 10f);
            menuEntry.Amount = (float) num;
          }
        }
      }
    }

    public bool KMdown(Keys k)
    {
      bool flag;
      switch (k)
      {
        case Keys.Print:
          flag = MenuScreen.mouseState.XButton1 == ButtonState.Pressed;
          break;
        case Keys.PrintScreen:
          flag = MenuScreen.mouseState.XButton2 == ButtonState.Pressed;
          break;
        case Keys.VolumeMute:
          flag = MenuScreen.mouseState.MiddleButton == ButtonState.Pressed;
          break;
        case Keys.VolumeDown:
          flag = MenuScreen.mouseState.LeftButton == ButtonState.Pressed;
          break;
        case Keys.VolumeUp:
          flag = MenuScreen.mouseState.RightButton == ButtonState.Pressed;
          break;
        default:
          flag = this.keyState.IsKeyDown(k);
          break;
      }
      return flag;
    }

    public bool method_0(Keys k)
    {
      bool flag;
      switch (k)
      {
        case Keys.Print:
          flag = MenuScreen.prevMouse.XButton1 == ButtonState.Released;
          break;
        case Keys.PrintScreen:
          flag = MenuScreen.prevMouse.XButton2 == ButtonState.Released;
          break;
        case Keys.VolumeMute:
          flag = MenuScreen.prevMouse.MiddleButton == ButtonState.Released;
          break;
        case Keys.VolumeDown:
          flag = MenuScreen.prevMouse.LeftButton == ButtonState.Released;
          break;
        case Keys.VolumeUp:
          flag = MenuScreen.prevMouse.RightButton == ButtonState.Released;
          break;
        default:
          flag = this.prevkeyState.IsKeyUp(k);
          break;
      }
      return flag;
    }

    public bool KMtoggle(Keys k)
    {
      bool flag;
      switch (k)
      {
        case Keys.Print:
          flag = MenuScreen.mouseState.XButton1 == ButtonState.Pressed && MenuScreen.prevMouse.XButton1 == ButtonState.Released;
          break;
        case Keys.PrintScreen:
          flag = MenuScreen.mouseState.XButton2 == ButtonState.Pressed && MenuScreen.prevMouse.XButton2 == ButtonState.Released;
          break;
        case Keys.VolumeMute:
          flag = MenuScreen.mouseState.MiddleButton == ButtonState.Pressed && MenuScreen.prevMouse.MiddleButton == ButtonState.Released;
          break;
        case Keys.VolumeDown:
          flag = MenuScreen.mouseState.LeftButton == ButtonState.Pressed && MenuScreen.prevMouse.LeftButton == ButtonState.Released;
          break;
        case Keys.VolumeUp:
          flag = MenuScreen.mouseState.RightButton == ButtonState.Pressed && MenuScreen.prevMouse.RightButton == ButtonState.Released;
          break;
        default:
          flag = this.keyState.IsKeyDown(k) && this.prevkeyState.IsKeyUp(k);
          break;
      }
      return flag;
    }

    public override void HandleInput(InputState input)
    {
      this.prevkeyState = input.lastKeyState;
      this.keyState = input.currentKeyState;
      MenuScreen.prevMouse = MenuScreen.mouseState;
      MenuScreen.mouseState = Mouse.GetState();
      if ((double) this.mytimer % 120.0 == 0.0)
        this.sc.centerWindow();
      if (this.delayinput)
      {
        MenuScreen.prevMouse = MenuScreen.mouseState;
        this.prevkeyState = this.keyState;
      }
      if (MenuScreen.mouseState.X == (int) this.sc.mymouse.X && MenuScreen.mouseState.Y == (int) this.sc.mymouse.Y)
      {
        this.mousemoving = false;
        --this.sc.mousefade;
        if (this.sc.mousefade == 0)
          this.sc.Game.IsMouseVisible = false;
      }
      else
      {
        this.mousemoving = true;
        this.sc.mousefade = 210;
        this.sc.Game.IsMouseVisible = true;
      }
      this.sc.mymouse.X = (float) MenuScreen.mouseState.X;
      this.sc.mymouse.Y = (float) MenuScreen.mouseState.Y;
      MenuScreen.title = this.menuTitle;
      float xxx;
      this.sc.righttrigger = input.IsTrigger("right", this.ControllingPlayer, out xxx);
      this.sc.lefttrigger = input.IsTrigger("left", this.ControllingPlayer, out xxx);
      this.sc.rightstickY = input.IsStick("updown", this.ControllingPlayer, out xxx);
      this.sc.rightstickX = input.IsStick("leftright", this.ControllingPlayer, out xxx);
      bool yyy;
      this.sc.rightbumper = input.IsBumper("right", this.ControllingPlayer, out yyy);
      this.sc.leftbumper = input.IsBumper("left", this.ControllingPlayer, out yyy);
      if (this.menuTitle == "Video Settings")
      {
        this.percX += this.sc.rightstickX / 100f;
        this.percY += this.sc.rightstickY / 100f;
        this.percX = MathHelper.Clamp(this.percX, 0.6f, 1f);
        this.percY = MathHelper.Clamp(this.percY, 0.6f, 1f);
      }
      if (input.IsMenuUpX(this.ControllingPlayer) && (double) this.mytimer > 0.05000000074505806)
      {
        this.sc.gamerindex = MenuScreen.playerIndex;
        --this.selectedEntry;
        this.sc.clickmenu.Play(this.sc.ev, 0.0f, 0.0f);
        if (this.selectedEntry < 0)
          this.selectedEntry = this.menuEntries.Count - 1;
        this.mytimer = 0.0f;
      }
      if (input.IsMenuDownX(this.ControllingPlayer) && (double) this.mytimer > 0.05000000074505806)
      {
        this.sc.gamerindex = MenuScreen.playerIndex;
        ++this.selectedEntry;
        this.sc.clickmenu.Play(this.sc.ev, 0.0f, 0.0f);
        if (this.selectedEntry >= this.menuEntries.Count)
          this.selectedEntry = 0;
        this.mytimer = 0.0f;
      }
      if (this.sc.usingMouse && this.mousemoving && this.point.Count == this.menuEntries.Count)
      {
        this.whichbutton = -1;
        for (int index = 0; index < this.menuEntries.Count; ++index)
        {
          this.queryButton(this.point[index], index);
          if (this.whichbutton == -1 || this.whichbutton == this.selectedEntry)
          {
            this.queryButton(this.valbox[index], index);
            if (this.whichbutton != -1 && this.whichbutton != this.selectedEntry)
            {
              this.selectedEntry = this.whichbutton;
              this.sc.clickmenu.Play(this.sc.ev, 0.0f, 0.0f);
              break;
            }
          }
          else
          {
            this.selectedEntry = this.whichbutton;
            this.sc.clickmenu.Play(this.sc.ev, 0.0f, 0.0f);
            break;
          }
        }
      }
      this.IncDec = false;
      if (this.sc.usingMouse && this.point.Count == this.menuEntries.Count && this.menuEntries[this.selectedEntry].Type > 0)
      {
        this.whichbutton = -1;
        this.queryButton(this.valbox[this.selectedEntry], this.selectedEntry);
        if (this.whichbutton != -1)
        {
          if (this.KMtoggle(this.sc.rmb_key))
          {
            if ((double) this.menuEntries[this.selectedEntry].Amount < (double) (this.menuEntries[this.selectedEntry].Lists.Length - 1))
            {
              ++this.menuEntries[this.selectedEntry].Amount;
              this.sc.clickmenu.Play(this.sc.ev, 0.2f, 0.0f);
              this.menuEntries[this.selectedEntry].OnSelectEntry(MenuScreen.playerIndex);
            }
            this.IncDec = true;
          }
          if (this.KMtoggle(this.sc.lmb_key))
          {
            if ((double) this.menuEntries[this.selectedEntry].Amount > 0.0)
            {
              --this.menuEntries[this.selectedEntry].Amount;
              this.sc.clickmenu.Play(this.sc.ev, -0.2f, 0.0f);
              this.menuEntries[this.selectedEntry].OnSelectEntry(MenuScreen.playerIndex);
            }
            this.IncDec = true;
          }
        }
      }
      if (this.menuEntries[this.selectedEntry].Type > 0 && input.IsMenuRightX(this.ControllingPlayer) && (double) this.mytimer > 0.05000000074505806)
      {
        this.sc.gamerindex = MenuScreen.playerIndex;
        if ((double) this.menuEntries[this.selectedEntry].Amount < (double) (this.menuEntries[this.selectedEntry].Lists.Length - 1))
        {
          ++this.menuEntries[this.selectedEntry].Amount;
          this.sc.clickmenu.Play(this.sc.ev, 0.0f, 0.0f);
          this.menuEntries[this.selectedEntry].OnSelectEntry(MenuScreen.playerIndex);
          this.mytimer = 0.0f;
        }
      }
      if (this.menuEntries[this.selectedEntry].Type > 0 && input.IsMenuLeftX(this.ControllingPlayer) && (double) this.mytimer > 0.05000000074505806)
      {
        this.sc.gamerindex = MenuScreen.playerIndex;
        if ((double) this.menuEntries[this.selectedEntry].Amount > 0.0)
        {
          --this.menuEntries[this.selectedEntry].Amount;
          this.sc.clickmenu.Play(this.sc.ev, 0.0f, 0.0f);
          this.menuEntries[this.selectedEntry].OnSelectEntry(MenuScreen.playerIndex);
          this.mytimer = 0.0f;
        }
      }
      if (this.menuEntries[this.selectedEntry].Type == 2 && input.IsMenuSelect(this.ControllingPlayer, out MenuScreen.playerIndex))
      {
        this.sc.gamerindex = MenuScreen.playerIndex;
        this.ScreenManager.typewriterblank = 0.0f;
        this.ScreenManager.textflag = 0;
        this.ScreenManager.typewriterwait = (float) this.rr.Next(700, 1100);
        this.ScreenManager.typeposition = 0.0f;
        this.ScreenManager.typevertical = (float) this.rr.Next(420, 510);
        this.ScreenManager.typewriterdelay = this.rr.Next(2, 6);
      }
      if (this.IncDec)
      {
        this.delayinput = false;
      }
      else
      {
        if (!input.IsMenuSelect(this.ControllingPlayer, out MenuScreen.playerIndex) && (!this.sc.usingMouse || !this.KMtoggle(this.sc.lmb_key)))
        {
          if (input.IsMenuCancel(this.ControllingPlayer, out MenuScreen.playerIndex) || this.sc.usingMouse && this.KMtoggle(this.sc.rmb_key))
          {
            this.sc.gamerindex = MenuScreen.playerIndex;
            this.OnCancel(MenuScreen.playerIndex);
          }
        }
        else
        {
          this.sc.gamerindex = MenuScreen.playerIndex;
          if (this.menuEntries[this.selectedEntry].Type == 0)
            this.OnSelectEntry(this.selectedEntry, MenuScreen.playerIndex);
        }
        this.delayinput = false;
      }
    }

    protected virtual void OnSelectEntry(int entryIndex, PlayerIndex playerIndex)
    {
      this.sc.gamerindex = playerIndex;
      this.sc.forward.Play(this.sc.ev, 0.0f, 0.0f);
      this.menuEntries[this.selectedEntry].OnSelectEntry(playerIndex);
    }

    protected virtual void OnCancel(PlayerIndex playerIndex)
    {
      this.sc.poppy = 0;
      if (this.menuTitle == "Paused")
      {
        this.sc.horn.Play(this.sc.ev * 0.1f, -0.8f, 0.0f);
        this.sc.SaveSpacePrefs();
        this.sc.Game.IsMouseVisible = false;
      }
      else
        this.sc.back.Play(this.sc.ev, 0.0f, 0.0f);
      this.ExitScreen();
    }

    protected void exitPauseScreen(object sender, PlayerIndexEventArgs e)
    {
      this.sc.poppy = 0;
      this.ExitScreen();
    }

    public override void Update(
      GameTime gameTime,
      bool otherScreenHasFocus,
      bool coveredByOtherScreen)
    {
      base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
      ++this.mytimer;
    }

    public override void Draw(GameTime gameTime)
    {
      Vector2 zero = Vector2.Zero;
      if (this.sc.menutype == 0)
      {
        zero.Y = (float) (600 - (this.sc.halo.LineSpacing + 3) * this.menuEntries.Count / 1);
      }
      else
      {
        this.sc.halo = this.sc.halo2;
        zero.Y = (float) (360 - this.menuEntries.Count * (this.sc.halo.LineSpacing + 3) / 2);
      }
      zero.X = this.sc.halo.MeasureString(this.menuEntries[0].Text).X;
      for (int index = 0; index < this.menuEntries.Count; ++index)
      {
        if (this.menuEntries[0].Type != 1)
          zero.X = this.sc.halo.MeasureString(this.menuEntries[index].Text).X;
        MenuEntry menuEntry = this.menuEntries[index];
        bool isSelected = index == this.selectedEntry;
        menuEntry.Draw(this, zero, isSelected, gameTime, (float) index, (float) this.menuEntries.Count, 1f);
        if (this.point.Count < this.menuEntries.Count)
        {
          Vector2 vector2 = this.sc.halo2.MeasureString(this.menuEntries[index].Text);
          float x1 = (float) ((1280.0 - (double) vector2.X) / 2.0);
          if (this.menuEntries[index].Type == 1)
            x1 = (float) (640.0 - ((double) zero.X + 240.0) / 2.0);
          Rectangle rectangle = new Rectangle(0, 0, 0, 0);
          rectangle = new Rectangle((int) x1, (int) ((double) zero.Y + (double) vector2.Y * 0.25), (int) vector2.X, (int) ((double) vector2.Y * 0.5));
          this.point.Add(rectangle);
          rectangle = new Rectangle(0, 0, 0, 0);
          if (this.menuEntries[index].Type > 0)
          {
            float x2 = this.sc.halo2.MeasureString(this.menuEntries[index].Lists[(int) this.menuEntries[index].Amount]).X;
            rectangle = new Rectangle((int) (640.0 + ((double) zero.X + 90.0) / 2.0 - (double) x2 / 2.0), (int) ((double) zero.Y + (double) vector2.Y * 0.25), (int) x2, (int) ((double) vector2.Y * 0.5));
          }
          this.valbox.Add(rectangle);
        }
        zero.Y += menuEntry.GetHeight(this);
      }
      if (this.onceflag != 0)
        return;
      this.ScreenManager.drawflag = 1;
      this.onceflag = 1;
    }

    public void queryButton(Rectangle rr, int index)
    {
      Vector2 mymouse = this.sc.mymouse;
      if (this.sc.fullmode)
        ;
      Vector2 vector2_1;
      if ((double) this.sc.aspectratio <= 1.0)
      {
        mymouse.Y -= (float) (((double) this.sc.screenSize.Height - (double) this.sc.screenSize.Height * (double) this.sc.aspectratio) * (0.5 / (double) this.sc.aspectratio));
        vector2_1 = new Vector2((float) this.sc.screenSize.Width / 1280f, (float) this.sc.screenSize.Height / 720f);
      }
      else
      {
        mymouse.X -= (float) (((double) this.sc.screenSize.Width - (double) this.sc.screenSize.Width / (double) this.sc.aspectratio) * (0.5 * (double) this.sc.aspectratio));
        vector2_1 = new Vector2((float) this.sc.screenSize.Width / 1280f, (float) this.sc.screenSize.Height / 720f);
      }
      Vector2 vector2_2 = mymouse / vector2_1;
      if (((double) vector2_2.Y <= (double) rr.Y || (double) vector2_2.Y > (double) (rr.Y + rr.Height) || (double) vector2_2.X <= (double) rr.X ? 0 : ((double) vector2_2.X <= (double) (rr.X + rr.Width) ? 1 : 0)) == 0)
        return;
      this.whichbutton = index;
    }

    public void drawBorders()
    {
      float xPosition = (float) (640.0 - (double) this.percX * 640.0);
      this.ScreenManager.siders = xPosition + 5f;
      Matrix matrix = Matrix.CreateScale(1f, this.percY * 144f, 1f) * Matrix.CreateTranslation(xPosition, (float) (360.0 - (double) this.percY * 360.0), 0.0f);
      this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, (DepthStencilState) null, (RasterizerState) null, (Effect) null, this.sc.ScaleMatrix1);
      this.spriteBatch.Draw(this.sc.messageBlob, new Vector2(0.0f, 0.0f), new Rectangle?(new Rectangle(0, 0, 12, 5)), Color.White);
      this.spriteBatch.End();
      Matrix transformMatrix1 = Matrix.CreateScale(1f, this.percY * 144f, 1f) * Matrix.CreateTranslation(1275f - xPosition, (float) (360.0 - (double) this.percY * 360.0), 0.0f);
      this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, (DepthStencilState) null, (RasterizerState) null, (Effect) null, transformMatrix1);
      this.spriteBatch.Draw(this.sc.messageBlob, new Vector2(-6f, 0.0f), new Rectangle?(new Rectangle(0, 0, 12, 5)), Color.White);
      this.spriteBatch.End();
      float yPosition = (float) (360.0 - (double) this.percY * 360.0);
      Matrix transformMatrix2 = Matrix.CreateScale(this.percX * 256f, 1f, 1f) * Matrix.CreateTranslation((float) (640.0 - (double) this.percX * 640.0), yPosition, 0.0f);
      this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, (DepthStencilState) null, (RasterizerState) null, (Effect) null, transformMatrix2);
      this.spriteBatch.Draw(this.sc.messageBlob, new Vector2(0.0f, 0.0f), new Rectangle?(new Rectangle(0, 0, 5, 12)), Color.White);
      this.spriteBatch.End();
      this.ScreenManager.bottomer = 715f - yPosition;
      this.ScreenManager.topper = yPosition + 5f;
      Matrix transformMatrix3 = Matrix.CreateScale(this.percX * 256f, 1f, 1f) * Matrix.CreateTranslation((float) (640.0 - (double) this.percX * 640.0), 715f - yPosition, 0.0f);
      this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, (DepthStencilState) null, (RasterizerState) null, (Effect) null, transformMatrix3);
      this.spriteBatch.Draw(this.sc.messageBlob, new Vector2(0.0f, -6f), new Rectangle?(new Rectangle(0, 0, 5, 12)), Color.White);
      this.spriteBatch.End();
    }
  }
}
