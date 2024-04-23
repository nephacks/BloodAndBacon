// Decompiled with JetBrains decompiler
// Type: Blood.walletScreen
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using System;
using System.Text;

#nullable disable
namespace Blood
{
  internal class walletScreen : GameScreen
  {
    private KeyboardState keyState;
    private KeyboardState prevkeyState;
    private MouseState prevMouse;
    private MouseState mouseState;
    private Vector2 mm = Vector2.Zero;
    private bool delayinput;
    private SoundEffect cashout;
    private SoundEffect click;
    private SpriteBatch spriteBatch;
    private int myIndex;
    private float rampIN;
    private Rectangle restartRect = new Rectangle(535, 347, 364, 49);
    private Rectangle settingsRect = new Rectangle(535, 408, 364, 49);
    private Rectangle helpRect = new Rectangle(535, 465, 364, 49);
    private Rectangle multiRect = new Rectangle(535, 522, 364, 49);
    private Rectangle kickRect = new Rectangle(535, 576, 364, 49);
    private Rectangle exitRect = new Rectangle(535, 635, 364, 49);
    private Random rr;
    private GamePadState gamestate;
    private GamePadState prevstate;
    private ScreenManager sc;
    private NetworkSession networkSession;
    private static StringBuilder my_stringbuilder = new StringBuilder(32, 32);
    private PlayerIndex playerIndex;
    private bool exitme;

    public event EventHandler<PlayerIndexEventArgs> Restart;

    public event EventHandler<PlayerIndexEventArgs> KickPlayer;

    public event EventHandler<PlayerIndexEventArgs> ExitGame;

    public event EventHandler<PlayerIndexEventArgs> Cancelled;

    public walletScreen()
    {
      this.IsPopup = true;
      this.TransitionOnTime = TimeSpan.FromSeconds(0.0);
      this.TransitionOffTime = TimeSpan.FromSeconds(0.0);
    }

    public override void LoadContent()
    {
      ContentManager content = this.ScreenManager.Game.Content;
      this.sc = this.ScreenManager;
      this.spriteBatch = new SpriteBatch(this.ScreenManager.GraphicsDevice);
      this.cashout = this.sc.cashout;
      this.click = this.sc.menuclick;
      this.rr = new Random();
      this.cashout.Play(this.sc.ev * 0.8f, (float) this.rr.Next(-10, 10) / 100f, 0.0f);
      this.sc.showVideoSetup = false;
      if (!this.sc.usingMouse)
        return;
      this.sc.Game.IsMouseVisible = true;
    }

    public override void HandleInput(InputState input)
    {
      if (this.sc.deactivated)
        return;
      if (input == null)
        throw new ArgumentNullException(nameof (input));
      if (this.ControllingPlayer.HasValue)
      {
        int index = (int) this.ControllingPlayer.Value;
        this.gamestate = input.CurrentGamePadStates[index];
        this.prevstate = input.LastGamePadStates[index];
        GamePad.SetVibration(this.ControllingPlayer.Value, 0.0f, 0.0f);
      }
      this.prevkeyState = input.lastKeyState;
      this.keyState = input.currentKeyState;
      this.prevMouse = this.mouseState;
      this.mouseState = Mouse.GetState();
      this.mm.X = (float) this.mouseState.X;
      this.mm.Y = (float) this.mouseState.Y;
      bool flag1 = this.mouseState.X != (int) this.sc.mymouse.X || this.mouseState.Y != (int) this.sc.mymouse.Y;
      this.sc.mymouse.X = (float) this.mouseState.X;
      this.sc.mymouse.Y = (float) this.mouseState.Y;
      bool flag2 = this.mouseState.RightButton == ButtonState.Pressed && this.prevMouse.RightButton == ButtonState.Released;
      bool flag3 = this.mouseState.LeftButton == ButtonState.Pressed && this.prevMouse.LeftButton == ButtonState.Released;
      if (this.delayinput)
      {
        this.prevMouse = this.mouseState;
        this.prevkeyState = this.keyState;
        this.prevstate = this.gamestate;
        flag2 = false;
        flag3 = false;
      }
      if (this.exitme)
      {
        if (this.Cancelled != null)
          this.Cancelled((object) this, new PlayerIndexEventArgs(PlayerIndex.One));
        this.sc.Game.IsMouseVisible = false;
        this.ExitScreen();
      }
      else if (this.keyState.IsKeyDown(this.sc.escape_key) && this.prevkeyState.IsKeyUp(this.sc.escape_key))
      {
        if (this.Cancelled != null)
          this.Cancelled((object) this, new PlayerIndexEventArgs(this.playerIndex));
        this.sc.Game.IsMouseVisible = false;
        this.ExitScreen();
      }
      else if (!flag2 && !input.IsMenuCancel(this.ControllingPlayer, out this.playerIndex))
      {
        if (input.IsMenuUp(this.ControllingPlayer))
        {
          --this.myIndex;
          if (this.myIndex < 0)
            this.myIndex = 5;
          this.click.Play(1f, 0.0f, 0.0f);
        }
        else if (input.IsMenuDown(this.ControllingPlayer))
        {
          ++this.myIndex;
          if (this.myIndex > 5)
            this.myIndex = 0;
          this.click.Play(1f, 0.0f, 0.0f);
        }
        else
        {
          if (flag1 && this.sc.usingMouse)
          {
            int index = this.myIndex;
            this.queryButton(this.restartRect, 0);
            this.queryButton(this.settingsRect, 1);
            this.queryButton(this.helpRect, 2);
            this.queryButton(this.multiRect, 3);
            this.queryButton(this.exitRect, 5);
            this.queryButton(this.kickRect, 4);
            if (index != this.myIndex)
              this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
          }
          if (flag3 || input.IsNewButtonPress(Buttons.A, this.ControllingPlayer, out this.playerIndex) || input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex))
          {
            if (this.myIndex == 0)
            {
              if (this.sc.host)
              {
                if (!this.sc.hordemode && !this.sc.paintland)
                {
                  walletBoxBB screen = new walletBoxBB("restart");
                  screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
                  {
                    if (this.Restart != null)
                      this.Restart((object) this, new PlayerIndexEventArgs(this.playerIndex));
                    this.sc.Game.IsMouseVisible = false;
                    this.ExitScreen();
                  });
                  this.ScreenManager.AddScreen((GameScreen) screen, new PlayerIndex?(this.playerIndex));
                  this.delayinput = true;
                  return;
                }
                MessageBoxScreen2 screen1 = new MessageBoxScreen2("Lose All Horde Progress\nAnd Restart From Wave 1?\n", 1);
                if (this.sc.paintland)
                  screen1 = new MessageBoxScreen2("Lose All Your Work\nAnd Restart The Day?\n", 1);
                screen1.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
                {
                  if (this.Restart != null)
                    this.Restart((object) this, new PlayerIndexEventArgs(this.playerIndex));
                  this.sc.Game.IsMouseVisible = false;
                  this.ExitScreen();
                });
                screen1.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
                {
                  this.sc.Game.IsMouseVisible = false;
                  this.ExitScreen();
                });
                this.ScreenManager.AddScreen((GameScreen) screen1, new PlayerIndex?(this.playerIndex));
                this.delayinput = true;
                return;
              }
              this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.myIndex == 1)
            {
              this.ScreenManager.AddScreen((GameScreen) new walletBoxBB("options"), new PlayerIndex?(this.playerIndex));
              this.delayinput = true;
              return;
            }
            if (this.myIndex == 2)
            {
              this.ScreenManager.AddScreen((GameScreen) new walletBoxBB("help"), new PlayerIndex?(this.playerIndex));
              this.delayinput = true;
              return;
            }
            if (this.myIndex == 3)
            {
              if ((int) this.sc.maxDay() + 1 < 31 && !this.sc.cheatsOn)
              {
                string messagex = "Cheats will Unlock\n After Day 30";
                if (this.sc.hordemode)
                  messagex = "Cheats Not Allowed";
                MessageBoxScreen2 screen = new MessageBoxScreen2(messagex, 0);
                screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
                {
                  if (!this.sc.usingMouse)
                    return;
                  this.sc.Game.IsMouseVisible = true;
                });
                this.ScreenManager.AddScreen((GameScreen) screen, new PlayerIndex?(this.playerIndex));
                this.delayinput = true;
                return;
              }
              if ((!this.sc.hordemode && this.sc.hostAllowCheats || this.sc.developer) && !this.sc.tunnelMode)
              {
                this.ScreenManager.AddScreen((GameScreen) new walletBoxBB("cheats"), new PlayerIndex?(this.playerIndex));
                this.delayinput = true;
                return;
              }
              this.sc.buttonDeny.Play(this.sc.ev, 0.0f, 0.0f);
              return;
            }
            if (this.myIndex == 4)
            {
              if (this.sc.host && this.sc.kickplayerID.Count > 0)
              {
                if (this.sc.kickplayerID.Count == 1)
                {
                  this.sc.Game.IsMouseVisible = false;
                  if (this.KickPlayer != null)
                    this.KickPlayer((object) this, new PlayerIndexEventArgs(this.playerIndex));
                  this.ExitScreen();
                }
                else
                {
                  walletBoxBB screen = new walletBoxBB("kicks");
                  screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
                  {
                    this.sc.Game.IsMouseVisible = false;
                    if (this.KickPlayer != null)
                      this.KickPlayer((object) this, new PlayerIndexEventArgs(this.playerIndex));
                    this.ExitScreen();
                  });
                  screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => { });
                  this.ScreenManager.AddScreen((GameScreen) screen, new PlayerIndex?(this.playerIndex));
                  this.delayinput = true;
                  return;
                }
              }
              else
              {
                this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
                return;
              }
            }
            if (this.myIndex == 5)
            {
              if (this.ExitGame != null)
                this.ExitGame((object) this, new PlayerIndexEventArgs(this.playerIndex));
              this.sc.Game.IsMouseVisible = false;
              this.ExitScreen();
              return;
            }
          }
          this.delayinput = false;
        }
      }
      else
      {
        if (this.Cancelled != null)
          this.Cancelled((object) this, new PlayerIndexEventArgs(this.playerIndex));
        this.sc.Game.IsMouseVisible = false;
        this.ExitScreen();
      }
    }

    public override void Draw(GameTime gameTime)
    {
      if (this.sc.deactivated)
        return;
      this.rampIN += 0.1f;
      if ((double) this.rampIN > 1.0)
        this.rampIN = 1f;
      float x = MathHelper.Hermite(-520f, 0.0f, 0.0f, 0.0f, this.rampIN);
      float y = 0.0f;
      Matrix scale;
      if ((double) this.sc.introCamera > 0.0)
      {
        scale = Matrix.CreateScale((float) this.sc.screenSize.Width / (float) this.sc.origSize.Width, (float) this.sc.screenSize.Height / (float) this.sc.origSize.Height, 1f);
        if ((double) this.sc.introCamera > 0.0 && (double) this.sc.introCamera < 5.0)
          this.exitme = true;
      }
      else
        scale = Matrix.CreateScale((float) this.sc.screenSize.Width / (float) this.sc.origSize.Width, (float) this.sc.screenSize.Height / (float) this.sc.origSize.Height, 1f);
      if (this.sc.showVideoSetup)
        return;
      this.ScreenManager.FadeBackBufferToBlack((int) this.TransitionAlpha / 2);
      this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) null, scale);
      Rectangle destinationRectangle = new Rectangle((int) x, (int) y, 519, 720);
      Color color = new Color(250, 250, 250, (int) byte.MaxValue);
      this.spriteBatch.Draw(this.ScreenManager.johnnyWallet, destinationRectangle, new Rectangle?(new Rectangle(0, 0, 519, 720)), Color.White);
      int num = 467;
      if (this.myIndex == 0)
      {
        destinationRectangle = new Rectangle((int) x + this.restartRect.X - num, this.restartRect.Y, this.restartRect.Width, this.restartRect.Height);
        this.spriteBatch.Draw(this.ScreenManager.johnnyWallet, destinationRectangle, new Rectangle?(this.restartRect), color);
      }
      if (this.myIndex == 1)
      {
        destinationRectangle = new Rectangle((int) x + this.settingsRect.X - num, this.settingsRect.Y, this.settingsRect.Width, this.settingsRect.Height);
        this.spriteBatch.Draw(this.ScreenManager.johnnyWallet, destinationRectangle, new Rectangle?(this.settingsRect), color);
      }
      if (this.myIndex == 2)
      {
        destinationRectangle = new Rectangle((int) x + this.helpRect.X - num, this.helpRect.Y, this.helpRect.Width, this.helpRect.Height);
        this.spriteBatch.Draw(this.ScreenManager.johnnyWallet, destinationRectangle, new Rectangle?(this.helpRect), color);
      }
      if (this.myIndex == 3)
      {
        destinationRectangle = new Rectangle((int) x + this.multiRect.X - num, this.multiRect.Y, this.multiRect.Width, this.multiRect.Height);
        this.spriteBatch.Draw(this.ScreenManager.johnnyWallet, destinationRectangle, new Rectangle?(this.multiRect), color);
      }
      if (this.myIndex == 4)
      {
        destinationRectangle = new Rectangle((int) x + this.kickRect.X - num, this.kickRect.Y, this.kickRect.Width, this.kickRect.Height);
        this.spriteBatch.Draw(this.ScreenManager.johnnyWallet, destinationRectangle, new Rectangle?(this.kickRect), color);
      }
      if (this.myIndex == 5)
      {
        destinationRectangle = new Rectangle((int) x + this.exitRect.X - num, this.exitRect.Y, this.exitRect.Width, this.exitRect.Height);
        this.spriteBatch.Draw(this.ScreenManager.johnnyWallet, destinationRectangle, new Rectangle?(this.exitRect), color);
      }
      this.spriteBatch.End();
      walletScreen.my_stringbuilder.Length = 0;
      walletScreen.my_stringbuilder.Append("L");
      int int_val = (int) this.sc.maxDay() + 1;
      if (int_val > 101)
        int_val = 101;
      if (int_val < 10)
      {
        walletScreen.my_stringbuilder.Concat(0);
        walletScreen.my_stringbuilder.Concat(0);
      }
      else if (int_val < 100)
        walletScreen.my_stringbuilder.Concat(0);
      walletScreen.my_stringbuilder.Concat(int_val);
      this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) null, scale);
      this.spriteBatch.DrawString(this.sc.font, walletScreen.my_stringbuilder, new Vector2(x + 213f, y + 194f), new Color(180, 180, 160, 120), 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
      this.spriteBatch.End();
    }

    public void queryButton(Rectangle rr, int ch)
    {
      rr = new Rectangle(rr.X - 467, rr.Y, rr.Width, rr.Height);
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
      this.myIndex = ch;
    }
  }
}
