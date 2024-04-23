// Decompiled with JetBrains decompiler
// Type: Blood.RotoTyper
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

#nullable disable
namespace Blood
{
  internal class RotoTyper : MenuScreen
  {
    private int myletter;
    private string letters = "";
    private string enteredtext = "";
    private int onoff;
    private int blink = 45;
    private int cursor;
    private float rx = 640f;
    private float ry = 410f;
    private float offx = 68f;
    private float offy = 50f;
    private Texture2D blankTexture;
    private Texture2D back;
    private Texture2D thumb;
    private Texture2D rotobox;
    private Texture2D solidbox;
    private Texture2D pointer;
    private Texture2D databox;
    private Texture2D rotoMain;
    private Texture2D r1;
    private Texture2D r2;
    private Texture2D r3;
    private Texture2D r4;
    private Texture2D r5;
    private Texture2D r6;
    private Texture2D scanline;
    private float scanx = 240f;
    private float scany = 120f;
    private int highlightflag;
    private int highlight = 10;
    private int style = 1;
    private int oldstyle = 1;
    private int lastletter;
    private float degrees;
    private float pointerscale;
    private SoundEffect pop1;
    private SoundEffect beep;
    private SoundEffect click;
    private int fader = (int) byte.MaxValue;
    private int fadeflag = 1;
    private ContentManager content;
    private Random random;
    private GamePadState previousgamepadstate;
    private SpriteBatch spriteBatch;
    private SpriteFont tag;
    private SpriteFont bigtag;

    public RotoTyper()
      : base("")
    {
      this.TransitionOnTime = TimeSpan.FromSeconds(2.5);
      this.TransitionOffTime = TimeSpan.FromSeconds(2.2000000476837158);
    }

    public override void LoadContent()
    {
      if (this.content == null)
        this.content = new ContentManager((IServiceProvider) this.ScreenManager.Game.Services, "Content");
      this.random = new Random();
      this.blankTexture = this.content.Load<Texture2D>("menus\\blank");
      this.back = this.content.Load<Texture2D>("menus\\back");
      this.thumb = this.content.Load<Texture2D>("menus\\thumb");
      this.rotobox = this.content.Load<Texture2D>("menus\\rotobox");
      this.solidbox = this.content.Load<Texture2D>("menus\\solidbox");
      this.pointer = this.content.Load<Texture2D>("menus\\pointer");
      this.databox = this.content.Load<Texture2D>("menus\\databox");
      this.rotoMain = this.content.Load<Texture2D>("menus\\rotoMain");
      this.scanline = this.content.Load<Texture2D>("menus\\scanline");
      this.r1 = this.content.Load<Texture2D>("menus\\r1");
      this.r2 = this.content.Load<Texture2D>("menus\\r2");
      this.r3 = this.content.Load<Texture2D>("menus\\r3");
      this.r4 = this.content.Load<Texture2D>("menus\\r4");
      this.r5 = this.content.Load<Texture2D>("menus\\r5");
      this.r6 = this.content.Load<Texture2D>("menus\\r6");
      this.pop1 = this.content.Load<SoundEffect>("Audio\\pop");
      this.click = this.content.Load<SoundEffect>("Audio\\clickmenu");
      this.beep = this.content.Load<SoundEffect>("Audio\\0527");
      this.tag = this.content.Load<SpriteFont>("menus\\consola");
      this.bigtag = this.content.Load<SpriteFont>("fonts\\bigtag");
      this.spriteBatch = new SpriteBatch(this.ScreenManager.GraphicsDevice);
    }

    public override void UnloadContent() => this.content.Unload();

    public override void HandleInput(InputState input)
    {
      if (input == null)
        throw new ArgumentNullException(nameof (input));
      int index = (int) this.ControllingPlayer.Value;
      GamePadState currentGamePadState = input.CurrentGamePadStates[index];
      if (currentGamePadState.Buttons.Back == ButtonState.Pressed || currentGamePadState.Buttons.B == ButtonState.Pressed)
        this.fadeflag = 3;
      float x = currentGamePadState.ThumbSticks.Left.X;
      float y = currentGamePadState.ThumbSticks.Left.Y;
      float degrees = MathHelper.ToDegrees((float) Math.Atan((double) x / (double) y));
      if ((double) y < 0.0)
        degrees += 180f;
      if ((double) degrees < 0.0)
        degrees = 360f + degrees;
      this.degrees = MathHelper.ToRadians(degrees);
      this.pointerscale = Math.Abs(x) + Math.Abs(y);
      if ((double) this.pointerscale > 0.699999988079071)
      {
        this.myletter = (int) Math.Round((double) degrees / 13.859999656677246 + 1.0);
        if (this.myletter > 26)
          this.myletter = 1;
      }
      if ((double) this.pointerscale > 1.0)
        this.pointerscale = 1f;
      if (currentGamePadState.Buttons.RightShoulder == ButtonState.Pressed && this.previousgamepadstate.Buttons.RightShoulder == ButtonState.Released)
      {
        this.highlightflag = 4;
        ++this.cursor;
        if (this.cursor > this.enteredtext.Length)
          this.cursor = this.enteredtext.Length;
        if (this.cursor > 15)
        {
          this.cursor = 15;
          this.beep.Play(0.2f * this.ScreenManager.ev, 0.0f, 0.0f);
          this.highlightflag = 7;
        }
        if (this.cursor < 0)
          this.cursor = 0;
      }
      if (currentGamePadState.Buttons.LeftShoulder == ButtonState.Pressed && this.previousgamepadstate.Buttons.LeftShoulder == ButtonState.Released)
      {
        --this.cursor;
        if (this.cursor < 0)
          this.cursor = 0;
        this.highlightflag = 3;
      }
      if (currentGamePadState.Buttons.RightStick == ButtonState.Pressed && this.previousgamepadstate.Buttons.RightStick == ButtonState.Released)
      {
        this.highlightflag = 5;
        this.style = this.style != 3 ? 3 : this.oldstyle;
      }
      if (currentGamePadState.Buttons.LeftStick == ButtonState.Pressed && this.previousgamepadstate.Buttons.LeftStick == ButtonState.Released)
      {
        this.highlightflag = 5;
        this.style = this.style != 1 ? 1 : 2;
        this.oldstyle = this.style;
      }
      if ((double) currentGamePadState.Triggers.Right > 0.800000011920929 && (double) this.previousgamepadstate.Triggers.Right <= 0.800000011920929)
      {
        this.highlightflag = 5;
        this.style = this.style != 3 ? 3 : this.oldstyle;
      }
      if ((double) currentGamePadState.Triggers.Left > 0.800000011920929 && (double) this.previousgamepadstate.Triggers.Left <= 0.800000011920929)
      {
        this.highlightflag = 5;
        this.style = this.style != 1 ? 1 : 2;
        this.oldstyle = this.style;
      }
      if (currentGamePadState.Buttons.A == ButtonState.Pressed && this.previousgamepadstate.Buttons.A == ButtonState.Released)
      {
        this.click.Play(this.ScreenManager.ev, 0.0f, 0.0f);
        if (this.style == 1)
          this.letters = "abcdefghijklmnopqrstuvwxyz*";
        if (this.style == 2)
          this.letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ*";
        if (this.style == 3)
          this.letters = "0123456789!?@#$%^&*().[]:-*";
        if (this.myletter > 0)
        {
          if (this.enteredtext.Length < 16)
          {
            string str = this.letters.Substring(this.myletter - 1, 1);
            this.enteredtext = this.cursor > 0 || this.enteredtext.Length > 0 ? this.enteredtext.Insert(this.cursor, str) : str;
            ++this.cursor;
            if (this.cursor > this.enteredtext.Length)
              this.cursor = this.enteredtext.Length;
            if (this.cursor > 15)
              this.cursor = 15;
          }
          else
          {
            string str = this.letters.Substring(this.myletter - 1, 1);
            this.enteredtext = this.enteredtext.Remove(this.cursor, 1);
            this.enteredtext = this.enteredtext.Insert(this.cursor, str);
            this.beep.Play(0.2f * this.ScreenManager.ev, 0.0f, 0.0f);
            this.highlightflag = 7;
          }
        }
      }
      if (currentGamePadState.Buttons.X == ButtonState.Pressed && this.previousgamepadstate.Buttons.X == ButtonState.Released)
      {
        this.highlightflag = 2;
        if (this.enteredtext.Length > 0)
        {
          if (this.cursor > 0 && (this.enteredtext.Length != 16 || this.cursor != 15))
          {
            this.enteredtext = this.enteredtext.Remove(this.cursor - 1, 1);
            --this.cursor;
            if (this.cursor < 0)
              this.cursor = 0;
          }
          else
            this.enteredtext = this.enteredtext.Remove(this.cursor, 1);
        }
        else
          this.enteredtext = "";
        this.click.Play(this.ScreenManager.ev, -1f, 0.0f);
      }
      if (currentGamePadState.Buttons.Y == ButtonState.Pressed && this.previousgamepadstate.Buttons.Y == ButtonState.Released)
      {
        this.highlightflag = 1;
        if (this.enteredtext.Length < 16)
        {
          this.enteredtext = this.enteredtext.Insert(this.cursor, " ");
          ++this.cursor;
        }
        else
        {
          this.beep.Play(0.2f * this.ScreenManager.ev, 0.0f, 0.0f);
          this.highlightflag = 7;
        }
        if (this.cursor > this.enteredtext.Length)
          this.cursor = this.enteredtext.Length;
        if (this.cursor > 15)
          this.cursor = 15;
      }
      this.previousgamepadstate = currentGamePadState;
    }

    public override void Update(
      GameTime gameTime,
      bool otherScreenHasFocus,
      bool coveredByOtherScreen)
    {
      base.Update(gameTime, otherScreenHasFocus, false);
    }

    public override void Draw(GameTime gameTime)
    {
      if (this.TransitionAlpha < byte.MaxValue && this.fadeflag <= 1)
        return;
      this.DrawText(this.enteredtext);
      if (this.fadeflag == 1)
      {
        this.fader -= 3;
        if (this.fader <= 0)
        {
          this.fader = 0;
          this.fadeflag = 2;
        }
      }
      if (this.fadeflag == 3)
        this.fader += 11;
      if (this.fader > (int) byte.MaxValue)
      {
        this.fader = (int) byte.MaxValue;
        this.fadeflag = 0;
        this.ScreenManager.menuflag = 0;
        this.ExitScreen();
      }
      this.ScreenManager.FadeBackBufferToBlack(this.fader);
    }

    private void DrawText(string text)
    {
      this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
      this.spriteBatch.Draw(this.scanline, new Vector2(this.scanx, 572f), new Rectangle?(), new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 150), MathHelper.ToRadians(90f), new Vector2((float) (this.scanline.Width / 2), (float) (this.scanline.Height / 2)), 1f, SpriteEffects.None, 0.0f);
      this.spriteBatch.Draw(this.scanline, new Vector2(0.0f, this.scany), new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 150));
      this.spriteBatch.Draw(this.scanline, new Vector2(0.0f, this.scany + 6f), new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 150));
      this.spriteBatch.Draw(this.rotoMain, new Vector2(this.offx, this.offy), Color.White);
      string str = "";
      if (this.style == 1)
        str = "abcdefghijklmnopqrstuvwxyz";
      if (this.style == 2)
        str = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
      if (this.style == 3)
        str = "0123456789!?@#$%^&*().[]:-";
      for (int startIndex = 0; startIndex < str.Length; ++startIndex)
      {
        float num1 = this.tag.MeasureString(str.Substring(startIndex, 1)).X / 2f;
        float num2 = this.tag.MeasureString(str.Substring(startIndex, 1)).Y / 2f;
        float radians = MathHelper.ToRadians((float) startIndex * 13.86f);
        float x = (float) (Math.Sin((double) radians) * 180.0) + this.rx - num1;
        float y = (float) (-Math.Cos((double) radians) * 180.0) + this.ry - num2;
        Color color = new Color(56, 76, 120, (int) byte.MaxValue);
        if (this.highlightflag == 7)
          color = new Color(199, 199, 76, (int) byte.MaxValue);
        if (startIndex == this.myletter - 1)
        {
          if (this.lastletter != this.myletter - 1)
            this.pop1.Play(0.3f * this.ScreenManager.ev, (float) (1.0 - (double) this.random.Next(1, 30) / 100.0), 0.0f);
          this.lastletter = this.myletter - 1;
          this.spriteBatch.DrawString(this.tag, str.Substring(startIndex, 1), new Vector2(x, y), Color.White);
        }
        else
        {
          this.spriteBatch.Draw(this.solidbox, new Vector2((float) Math.Sin((double) radians) * 180f + this.rx, (float) -Math.Cos((double) radians) * 180f + this.ry), new Rectangle?(), color, radians, new Vector2((float) (this.rotobox.Width / 2), (float) (this.rotobox.Height / 2)), 1f, SpriteEffects.None, 0.0f);
          this.spriteBatch.DrawString(this.tag, str.Substring(startIndex, 1), new Vector2(x, y), Color.Black);
        }
      }
      this.spriteBatch.Draw(this.rotobox, new Vector2((float) Math.Sin((double) MathHelper.ToRadians((float) this.lastletter * 13.86f)) * 180f + this.rx, (float) -Math.Cos((double) MathHelper.ToRadians((float) this.lastletter * 13.86f)) * 180f + this.ry), new Rectangle?(), Color.White, MathHelper.ToRadians((float) this.lastletter * 13.86f), new Vector2((float) (this.rotobox.Width / 2), (float) (this.rotobox.Height / 2)), 1f, SpriteEffects.None, 0.0f);
      this.spriteBatch.Draw(this.pointer, new Vector2(this.rx, this.ry), new Rectangle?(), Color.White, this.degrees, new Vector2((float) (this.pointer.Width / 2), (float) this.pointer.Height), this.pointerscale, SpriteEffects.None, 0.0f);
      this.spriteBatch.DrawString(this.bigtag, str.Substring(this.lastletter, 1), new Vector2(this.rx - this.bigtag.MeasureString(str.Substring(this.lastletter, 1)).X / 2f, this.ry - this.bigtag.MeasureString(str.Substring(this.lastletter, 1)).Y / 2f), Color.White);
      float x1 = (float) (this.ScreenManager.GraphicsDevice.Viewport.Width / 2) - this.tag.MeasureString("OOOOOOOOOOOOOOOO").X / 2f;
      for (float num = 0.0f; (double) num < 16.0; ++num)
        this.spriteBatch.Draw(this.databox, new Vector2((float) ((double) num * (double) (this.databox.Width + 1) + (double) x1 + 2.0), 57f + this.offy), new Color(56, 76, 120, (int) byte.MaxValue));
      this.spriteBatch.DrawString(this.tag, text, new Vector2(x1, 58f + this.offy), Color.White);
      --this.blink;
      if (this.blink <= 0)
      {
        this.blink = 6;
        this.onoff = this.onoff != 0 ? 0 : 1;
      }
      float num3 = 0.0f;
      if (text.Length > 0)
        num3 = this.tag.MeasureString(text.Substring(0, this.cursor)).X;
      if (this.cursor > 15)
        this.cursor = 15;
      if (this.onoff == 1)
        this.spriteBatch.DrawString(this.tag, "_", new Vector2(x1 + num3, 61f + this.offy), Color.White);
      if (this.highlightflag > 0)
      {
        --this.highlight;
        if (this.highlight <= 0)
        {
          this.highlightflag = 0;
          this.highlight = 5;
        }
        if (this.highlightflag == 1)
          this.spriteBatch.Draw(this.r1, new Vector2(144f + this.offx, 187f + this.offy), Color.White);
        if (this.highlightflag == 2)
          this.spriteBatch.Draw(this.r2, new Vector2(800f + this.offx, 187f + this.offy), Color.White);
        if (this.highlightflag == 3)
          this.spriteBatch.Draw(this.r3, new Vector2(144f + this.offx, 307f + this.offy), Color.White);
        if (this.highlightflag == 4)
          this.spriteBatch.Draw(this.r4, new Vector2(800f + this.offx, 307f + this.offy), Color.White);
        if (this.highlightflag == 5)
          this.spriteBatch.Draw(this.r5, new Vector2(144f + this.offx, 432f + this.offy), Color.White);
        if (this.highlightflag == 6)
          this.spriteBatch.Draw(this.r6, new Vector2(800f + this.offx, 432f + this.offy), Color.White);
      }
      this.spriteBatch.DrawString(this.tag, "Space", new Vector2(174f + this.offx, 192f + this.offy), Color.White);
      this.spriteBatch.DrawString(this.tag, "Delete", new Vector2(840f + this.offx, 192f + this.offy), Color.White);
      this.spriteBatch.DrawString(this.tag, "Cursor", new Vector2(154f + this.offx, 312f + this.offy), Color.White);
      this.spriteBatch.DrawString(this.tag, "Cursor", new Vector2(850f + this.offx, 312f + this.offy), Color.White);
      this.spriteBatch.DrawString(this.tag, "Caps", new Vector2(184f + this.offx, 437f + this.offy), Color.White);
      this.spriteBatch.DrawString(this.tag, "Done", new Vector2(855f + this.offx, 437f + this.offy), Color.White);
      this.spriteBatch.Draw(this.ScreenManager.interfaceBlob, new Vector2(0.0f, 0.0f), Color.White);
      this.spriteBatch.End();
    }
  }
}
