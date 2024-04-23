// Decompiled with JetBrains decompiler
// Type: Blood.Notes
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

#nullable disable
namespace Blood
{
  internal class Notes : MenuScreen
  {
    private GraphicsDevice graphicsDevice;
    private ContentManager content;
    private Random random;
    private Texture2D gear2;
    private Texture2D buttonOn;
    private Texture2D L257load;
    private Texture2D rays;
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
    private string[] image0 = new string[0];
    private Texture2D myimage;
    private Texture2D dossy;
    private Color[] colorArray1 = new Color[0];
    private GamePadState previousgamepadstate;
    private int fader = (int) byte.MaxValue;
    private int fadeflag = 1;
    private string[] loadx = new string[7]
    {
      "LOADING",
      "LOADING",
      "LOADING",
      "LOADING",
      "LOADING",
      "LOADING",
      " LOADING"
    };
    private List<Color> colortab = new List<Color>();
    private List<int> posxtab = new List<int>();
    private List<int> posytab = new List<int>();
    private int loadIndex;
    private SoundEffect button;
    private int num;
    private float offsetX;
    private float offsetY;
    private float zoomFactor = 1.3f;
    private float myRot;

    public Notes()
      : base("")
    {
      this.TransitionOnTime = TimeSpan.FromSeconds(2.5);
      this.TransitionOffTime = TimeSpan.FromSeconds(2.2000000476837158);
    }

    public override void LoadContent()
    {
      if (this.content == null)
        this.content = new ContentManager((IServiceProvider) this.ScreenManager.Game.Services, "Content");
      this.random = new Random(44);
      this.graphicsDevice = this.ScreenManager.GraphicsDevice;
      this.button = this.content.Load<SoundEffect>("Audio\\gong");
      this.gear2 = this.content.Load<Texture2D>("sprites\\icons\\gear1");
      this.random = new Random(3);
      this.num = this.random.Next(1, 14);
      this.horPos = this.random.Next(0, 900);
      this.sizer = (float) this.random.Next(2800, 4800) / 1000f;
      this.buttonOn = this.content.Load<Texture2D>("sprites\\icons\\buttonon" + (object) this.num);
      this.loadfont1 = this.content.Load<SpriteFont>("fonts\\tag");
      this.loadfont2 = this.content.Load<SpriteFont>("fonts\\load2");
      this.L257load = this.content.Load<Texture2D>("menus\\Loading");
      this.allcolors(1);
      this.rays = this.content.Load<Texture2D>("loading\\rays");
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
      this.spriteBatch = new SpriteBatch(this.ScreenManager.GraphicsDevice);
    }

    private void allcolors(int val)
    {
      this.loadIndex += val;
      this.myimage = this.content.Load<Texture2D>("loading\\image" + (object) this.loadIndex);
      this.dossy = this.content.Load<Texture2D>("loading\\dossy");
      this.colorArray1 = new Color[1024];
      this.myimage.GetData<Color>(this.colorArray1);
    }

    public override void UnloadContent() => this.content.Unload();

    public override void HandleInput(InputState input)
    {
      if (input == null)
        throw new ArgumentNullException(nameof (input));
      int index = (int) this.ControllingPlayer.Value;
      GamePadState currentGamePadState = input.CurrentGamePadStates[index];
      if (currentGamePadState.Buttons.Back == ButtonState.Pressed)
        this.fadeflag = 3;
      if (currentGamePadState.Buttons.X == ButtonState.Pressed)
        this.ScreenManager.mess = "";
      this.myRot += currentGamePadState.ThumbSticks.Left.X / 80f;
      this.zoomFactor += currentGamePadState.ThumbSticks.Left.Y / 10f;
      this.offsetX += currentGamePadState.ThumbSticks.Right.X * 10f;
      this.offsetY -= currentGamePadState.ThumbSticks.Right.Y * 10f;
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
      this.drawSaver();
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

    private void drawSaver()
    {
      this.rot += 0.8f;
      this.realrot += 0.05f;
      this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
      this.spriteBatch.Draw(this.dossy, new Vector2((float) this.horPos, (float) ((double) this.realrot * 20.0 - 150.0)), new Rectangle?(), new Color(120, 120, 200, 80), 0.0f, new Vector2(0.0f, 0.0f), this.sizer, SpriteEffects.None, 0.0f);
      this.spriteBatch.Draw(this.L257load, new Vector2(0.0f, 0.0f), new Rectangle?(), Color.White, 0.0f, new Vector2(0.0f, 0.0f), 2f, SpriteEffects.None, 0.0f);
      this.spriteBatch.Draw(this.gear2, new Vector2(160f, 60f), new Rectangle?(), Color.White, this.realrot, new Vector2((float) (this.gear2.Width / 2), (float) (this.gear2.Height / 2)), 1f, SpriteEffects.None, 0.0f);
      this.spriteBatch.Draw(this.gear2, new Vector2(192f, 92f), new Rectangle?(), Color.White, (float) (-(double) this.realrot + 0.0099999997764825821), new Vector2((float) (this.gear2.Width / 2), (float) (this.gear2.Height / 2)), 0.66f, SpriteEffects.None, 0.0f);
      this.spriteBatch.DrawString(this.loadfont1, "Current Notes.....   ", new Vector2(230f, 35f), Color.White);
      this.spriteBatch.DrawString(this.loadfont2, this.ScreenManager.mess, new Vector2(520f + this.offsetX, 330f + this.offsetY), Color.White, this.myRot, new Vector2(300f, 150f), this.zoomFactor, SpriteEffects.None, 0.0f);
      this.spriteBatch.End();
    }
  }
}
