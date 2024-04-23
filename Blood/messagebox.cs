// Decompiled with JetBrains decompiler
// Type: Blood.messagebox
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

#nullable disable
namespace Blood
{
  internal class messagebox : GameScreen
  {
    private Keys[] pressedKeys = new Keys[0];
    private int kt;
    private int alternator;
    private bool delayinput = true;
    private PlayerIndex playerIndex;
    private int myindex = -1;
    private string whichButton = "none";
    private Rectangle yesRect = new Rectangle(0, 0, 0, 0);
    private Rectangle noRect = new Rectangle(0, 0, 0, 0);
    private Rectangle okRect = new Rectangle(0, 0, 0, 0);
    private Rectangle arrRect = new Rectangle(0, 0, 0, 0);
    private Rectangle meter = new Rectangle(164, 289, 362, 48);
    private Rectangle meterColor = new Rectangle(164, 346, 362, 48);
    private Rectangle pointer1 = new Rectangle(1095, 32, 20, 30);
    private Rectangle pointer2 = new Rectangle(1071, 32, 20, 30);
    private Rectangle arrows = new Rectangle(541, 289, 39, 84);
    private Rectangle[] dot1 = new Rectangle[3]
    {
      new Rectangle(23, 22, 28, 28),
      new Rectangle(23, 62, 28, 28),
      new Rectangle(23, 97, 28, 28)
    };
    private Vector2 mm = Vector2.Zero;
    private string message;
    private bool includeYesNo;
    private bool includeBG = true;
    private int flag;
    private SpriteFont squarefont;
    private SpriteBatch spriteBatch;
    private SpriteFont font;
    private ScreenManager sc;
    private Vector2 viewportSize;
    private Vector2 textSize;
    private Vector2 textPosition;
    private int hPad;
    private int vPad;
    private int textgap = 10;
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
    private int myframe;
    private int val1;
    private int selects;
    private bool showmiles;
    private GamePadState gamestate;
    private GamePadState prevstate;
    private KeyboardState prevKeys;
    private KeyboardState keyState;
    private MouseState prevMouse;
    private MouseState mouseState;

    public event EventHandler<PlayerIndexEventArgs> Accepted;

    public event EventHandler<PlayerIndexEventArgs> Cancelled;

    public event EventHandler<PlayerIndexEventArgs> Response1;

    public event EventHandler<PlayerIndexEventArgs> Response2;

    public event EventHandler<PlayerIndexEventArgs> Response3;

    public event EventHandler<PlayerIndexEventArgs> Response4;

    public event EventHandler<PlayerIndexEventArgs> Response5;

    public event EventHandler<PlayerIndexEventArgs> Response6;

    public event EventHandler<PlayerIndexEventArgs> Response7;

    public messagebox(string messagex, int flag, int num)
    {
      this.flag = flag;
      this.message = messagex;
      if (flag == 0)
      {
        this.includeYesNo = false;
        this.includeBG = true;
        this.textgap = 10;
      }
      if (flag == 1)
      {
        this.includeYesNo = true;
        this.includeBG = true;
        this.textgap = 10;
        if (!this.showmiles)
          this.message += "\n";
      }
      if (flag == 2)
      {
        this.includeYesNo = false;
        this.includeBG = true;
        this.textgap = 10;
        this.selects = num;
      }
      this.IsPopup = false;
      this.TransitionOnTime = TimeSpan.FromSeconds(0.0);
      this.TransitionOffTime = TimeSpan.FromSeconds(0.0);
    }

    public override void LoadContent()
    {
      ContentManager content = this.ScreenManager.Game.Content;
      this.sc = this.ScreenManager;
      this.sc.myindex = (int) MathHelper.Clamp((float) this.sc.myindex, 1f, (float) this.selects);
      this.font = this.sc.terminal;
      this.squarefont = this.sc.squarefont;
      this.menuSlate = new Rectangle(114, 12, 480, 244);
      this.cornerR = new Rectangle(139, 433, 88, 88);
      this.borderR = new Rectangle(9, 457, 100, 64);
      this.spriteBatch = this.ScreenManager.SpriteBatch;
      int length = this.message.Split('\r', '\n').Length;
      this.viewportSize = new Vector2(1280f, 720f);
      this.textSize = this.font.MeasureString(this.message);
      this.textPosition = this.viewportSize / 2f - this.textSize / 2f;
      this.textPosition.Y -= (float) (length * this.textgap / 2);
      this.hPad = 80;
      this.vPad = 30;
      this.mywidth = (float) ((int) this.textSize.X + this.hPad * 2);
      this.myhite = (float) ((int) this.textSize.Y + this.vPad * 2 + length * this.textgap);
      this.left = (float) ((int) this.textPosition.X - this.hPad);
      this.top = (float) ((int) this.textPosition.Y - this.vPad);
      this.top = (float) ((double) this.viewportSize.Y / 2.0 - (double) this.myhite / 2.0);
      this.right = this.left + this.mywidth;
      this.bottom = this.top + this.myhite;
      this.middle = this.viewportSize.X / 2f;
      this.midhite = this.viewportSize.Y / 2f;
      this.backgroundRectangle = new Rectangle((int) this.left, (int) this.top, (int) this.mywidth, (int) this.myhite);
      this.topRect = new Rectangle((int) this.middle, (int) this.top, (int) this.mywidth, 30);
      this.botRect = new Rectangle((int) this.middle, (int) this.bottom, (int) this.mywidth, 30);
      this.leftRect = new Rectangle((int) this.left, (int) this.midhite, (int) this.myhite, 30);
      this.rightRect = new Rectangle((int) this.right, (int) this.midhite, (int) this.myhite, 30);
      this.cornA = new Rectangle((int) this.left, (int) this.top, 60, 60);
      this.cornB = new Rectangle((int) this.right, (int) this.top, 60, 60);
      this.cornC = new Rectangle((int) this.left, (int) this.bottom, 60, 60);
      this.cornD = new Rectangle((int) this.right, (int) this.bottom, 60, 60);
    }

    public override void HandleInput(InputState input)
    {
      this.gamestate = input.CurrentGamePadStates[(int) this.sc.playerindex];
      this.prevstate = input.LastGamePadStates[(int) this.sc.playerindex];
      this.prevKeys = input.lastKeyState;
      this.keyState = input.currentKeyState;
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
      if (this.mouseState.RightButton == ButtonState.Pressed)
      {
        int rightButton = (int) this.prevMouse.RightButton;
      }
      if (this.delayinput)
      {
        this.prevMouse = this.mouseState;
        this.prevKeys = this.keyState;
        this.prevstate = this.gamestate;
      }
      if (this.flag == 0)
      {
        if (this.keyState.IsKeyDown(Keys.Y))
          this.prevKeys.IsKeyUp(Keys.Y);
        if (this.keyState.IsKeyDown(Keys.N))
          this.prevKeys.IsKeyUp(Keys.N);
        bool flag1 = this.mouseState.LeftButton == ButtonState.Pressed && this.prevMouse.LeftButton == ButtonState.Released;
        bool flag2 = this.mouseState.RightButton == ButtonState.Pressed && this.prevMouse.RightButton == ButtonState.Released;
        if (input.IsMenuCancel(this.ControllingPlayer, out this.playerIndex) || input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex) || flag1 || flag2)
        {
          if (this.Accepted != null)
            this.Accepted((object) this, new PlayerIndexEventArgs(this.playerIndex));
          this.sc.Game.IsMouseVisible = false;
          this.ExitScreen();
        }
      }
      if (this.flag == 1)
      {
        bool flag3 = this.keyState.IsKeyDown(Keys.Y) && this.prevKeys.IsKeyUp(Keys.Y);
        bool flag4 = this.keyState.IsKeyDown(Keys.N) && this.prevKeys.IsKeyUp(Keys.N);
        if (this.mouseState.LeftButton == ButtonState.Pressed)
        {
          int leftButton = (int) this.prevMouse.LeftButton;
        }
        bool flag5 = this.mouseState.RightButton == ButtonState.Pressed && this.prevMouse.RightButton == ButtonState.Released;
        if (!flag3 && !input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex) && (this.mouseState.LeftButton != ButtonState.Pressed || this.prevMouse.LeftButton != ButtonState.Released || !(this.whichButton == "YES")))
        {
          if (flag5 || flag4 || input.IsMenuCancel(this.ControllingPlayer, out this.playerIndex) || this.mouseState.LeftButton == ButtonState.Pressed && this.prevMouse.LeftButton == ButtonState.Released && this.whichButton == "NO")
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
        if (input.IsMenuUp(this.ControllingPlayer))
        {
          --this.sc.myindex;
          if (this.sc.myindex < 1)
            this.sc.myindex = this.selects;
          this.sc.click.Play(this.sc.ev, -0.1f, 0.0f);
        }
        if (input.IsMenuDown(this.ControllingPlayer))
        {
          ++this.sc.myindex;
          if (this.sc.myindex > this.selects)
            this.sc.myindex = 1;
          this.sc.click.Play(this.sc.ev, 0.1f, 0.0f);
        }
        if (input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex))
        {
          if (this.sc.myindex == 1 && this.Response1 != null)
            this.Response1((object) this, new PlayerIndexEventArgs(this.playerIndex));
          if (this.sc.myindex == 2 && this.Response2 != null)
            this.Response2((object) this, new PlayerIndexEventArgs(this.playerIndex));
          if (this.sc.myindex == 3 && this.Response3 != null)
            this.Response3((object) this, new PlayerIndexEventArgs(this.playerIndex));
          if (this.sc.myindex == 4 && this.Response4 != null)
            this.Response4((object) this, new PlayerIndexEventArgs(this.playerIndex));
          if (this.sc.myindex == 5 && this.Response5 != null)
            this.Response5((object) this, new PlayerIndexEventArgs(this.playerIndex));
          if (this.sc.myindex == 6 && this.Response6 != null)
            this.Response6((object) this, new PlayerIndexEventArgs(this.playerIndex));
          if (this.sc.myindex == 7 && this.Response7 != null)
            this.Response6((object) this, new PlayerIndexEventArgs(this.playerIndex));
          this.sc.select.Play(this.sc.ev, 0.0f, 0.0f);
          this.sc.Game.IsMouseVisible = false;
          this.ExitScreen();
        }
        if (input.IsMenuCancel(this.ControllingPlayer, out this.playerIndex))
        {
          if (this.Cancelled != null)
            this.Cancelled((object) this, new PlayerIndexEventArgs(this.playerIndex));
          if (!this.showmiles)
            this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
          this.sc.Game.IsMouseVisible = false;
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
      this.queryButton2(this.yesRect, "YES");
      this.queryButton2(this.okRect, "OKAY");
      this.queryButton2(this.noRect, "NO");
      this.queryButton2(this.arrRect, "ARROW");
      base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
    }

    public override void Draw(GameTime gameTime)
    {
      if (!this.showmiles)
        this.sc.FadeBackBufferToBlack((int) this.TransitionAlpha * 2 / 3);
      Color color1 = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) this.TransitionAlpha);
      Color color2 = new Color(30, 30, 30, (int) this.TransitionAlpha);
      this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) null, this.sc.ScaleMatrix1);
      if (this.includeBG)
      {
        this.spriteBatch.Draw(this.ScreenManager.messageBlob, this.backgroundRectangle, new Rectangle?(this.menuSlate), color1);
        float num = 0.4f;
        if (this.myframe % 70 < 33)
          num = 0.2f;
        this.spriteBatch.Draw(this.ScreenManager.messageBlob, this.cornA, new Rectangle?(this.cornerR), color1, 0.0f, new Vector2((float) this.cornerR.Width * num, (float) this.cornerR.Height * num), SpriteEffects.None, 0.0f);
        this.spriteBatch.Draw(this.ScreenManager.messageBlob, this.cornB, new Rectangle?(this.cornerR), color1, 1.57f, new Vector2((float) this.cornerR.Width * num, (float) this.cornerR.Height * num), SpriteEffects.None, 0.0f);
        this.spriteBatch.Draw(this.ScreenManager.messageBlob, this.cornC, new Rectangle?(this.cornerR), color1, -1.57f, new Vector2((float) this.cornerR.Width * num, (float) this.cornerR.Height * num), SpriteEffects.None, 0.0f);
        this.spriteBatch.Draw(this.ScreenManager.messageBlob, this.cornD, new Rectangle?(this.cornerR), color1, 3.14f, new Vector2((float) this.cornerR.Width * num, (float) this.cornerR.Height * num), SpriteEffects.None, 0.0f);
      }
      float[] numArray = new float[8];
      string[] strArray = this.message.Split('\r', '\n');
      for (int index = 0; index < strArray.Length; ++index)
      {
        float x = (float) ((double) this.viewportSize.X / 2.0 - (double) this.font.MeasureString(strArray[index]).X / 2.0);
        float y = (float) (0.0 + (double) this.textPosition.Y + ((double) this.textSize.Y / (double) strArray.Length + (double) this.textgap) * (double) index);
        this.spriteBatch.DrawString(this.font, strArray[index], new Vector2(x + 3f, y + 1f), color2, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
        this.spriteBatch.DrawString(this.font, strArray[index], new Vector2(x + 1f, y + 2f), color2, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
        this.spriteBatch.DrawString(this.font, strArray[index], new Vector2(x, y), color1, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
        numArray[index + 1] = y;
      }
      if (this.includeYesNo && !this.showmiles)
      {
        string text1 = "A";
        string text2 = "B";
        string text3 = "  YES         NO";
        Vector2 vector2 = new Vector2((float) ((double) this.textPosition.X + (double) this.textSize.X / 2.0 - 15.0), this.bottom - (float) this.vPad);
        vector2.Y -= (float) (30.0 + (double) this.squarefont.MeasureString(text2).X / 2.0);
        vector2.X = (float) ((double) this.viewportSize.X / 2.0 - (double) this.font.MeasureString(text3).X / 2.0);
        this.yesRect = new Rectangle((int) ((double) vector2.X - 1.0), (int) vector2.Y, 100, 30);
        if (this.whichButton == "YES")
        {
          this.spriteBatch.Draw(this.sc.whiteTexture, new Rectangle(this.yesRect.X, this.yesRect.Y + 1, 30, 30), Color.White);
          this.spriteBatch.DrawString(this.squarefont, text1, 1f * vector2, Color.Black, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
        }
        else
          this.spriteBatch.DrawString(this.squarefont, text1, 1f * vector2, color1, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
        vector2.X = (float) ((double) this.viewportSize.X / 2.0 - (double) this.font.MeasureString(text3).X / 2.0 + (double) this.font.MeasureString(" ").X * 12.0);
        this.noRect = new Rectangle((int) (1.0 * ((double) vector2.X - 1.0)), (int) (1.0 * (double) vector2.Y), 100, 30);
        if (this.whichButton == "NO")
        {
          this.spriteBatch.Draw(this.sc.whiteTexture, new Rectangle(this.noRect.X, this.noRect.Y + 1, 30, 30), Color.White);
          this.spriteBatch.DrawString(this.squarefont, text2, 1f * vector2, Color.Black, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
        }
        else
          this.spriteBatch.DrawString(this.squarefont, text2, 1f * vector2, color1, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
        vector2.X = this.viewportSize.X / 2f;
        vector2.Y += (float) ((double) this.squarefont.MeasureString(text2).X / 2.0 - 2.0);
        this.spriteBatch.DrawString(this.font, text3, 1f * vector2, color1, 0.0f, new Vector2(this.font.MeasureString(text3).X / 2f, this.font.MeasureString(text3).Y / 2f), 0.8f, SpriteEffects.None, 0.0f);
      }
      if (this.flag == 2 || this.flag == 4 || this.flag == 5)
      {
        int index = this.myframe / 10 % 3;
        this.spriteBatch.Draw(this.sc.messageBlob, new Vector2(this.left + 20f, numArray[this.sc.myindex]), new Rectangle?(this.dot1[index]), Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
        this.spriteBatch.Draw(this.sc.messageBlob, new Vector2(this.right - 25f - (float) this.dot1[index].Width, numArray[this.sc.myindex]), new Rectangle?(this.dot1[index]), Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally, 0.0f);
      }
      if (this.flag == 3)
      {
        int index = this.myframe / 10 % 3;
        this.spriteBatch.Draw(this.sc.messageBlob, new Vector2(this.left + 20f, numArray[this.sc.myindex]), new Rectangle?(this.dot1[index]), Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
        this.spriteBatch.Draw(this.sc.messageBlob, new Vector2(this.right - 25f - (float) this.dot1[index].Width, numArray[this.sc.myindex]), new Rectangle?(this.dot1[index]), Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally, 0.0f);
      }
      this.spriteBatch.End();
    }

    public void queryButton(Rectangle rr, string word)
    {
      if (((double) this.mm.Y <= (double) rr.Y || (double) this.mm.Y >= (double) (rr.Y + rr.Height) || (double) this.mm.X <= (double) rr.X ? 0 : ((double) this.mm.X < (double) (rr.X + rr.Width) ? 1 : 0)) == 0)
        return;
      this.whichButton = word;
    }

    public void queryButton2(Rectangle rr, string word)
    {
      Vector2 mm = this.mm;
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
