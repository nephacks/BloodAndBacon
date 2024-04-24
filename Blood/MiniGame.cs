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
  internal class MiniGame : MenuScreen
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
    private string messagedisplay = "";
    private GamePadState previousgamepadstate;
    private int fader = (int) byte.MaxValue;
    private int fadeflag = 1;
    private string[] messages = new string[50]
    {
      "A Little Bird Told Me",
      "Alien Life",
      "Ancient Artifacts",
      "Buy Better Batteries",
      "Caution",
      "Certain Skills Increase Your Rank",
      "Crystals Can Be Refined",
      "Do Anything To Stay Alert",
      "Don't Drop Your Crystals",
      "Don't Monkey Around In Space",
      "Don't Run With Scissors",
      "Don't Talk To Strangers",
      "Eat Later",
      "Gems Can Be Sold At A Profit",
      "Gems Can Be Used As Tools",
      "Go Get Promoted",
      "Gold Is Worthless In Space",
      "Great Treasures Wait For You",
      "In Space Repairs Are Done Yourself",
      "It's Not Rocket Science",
      "Know Your Friends",
      "L257 Is Ready For Launch",
      "Launch Another Rocket For Cash",
      "Listen To Your Radio",
      "No Time For Romance",
      "Ore Becomes Fuel",
      "Ore Means Life",
      "Rank Means Increased Salary",
      "Rare Gems Are Hard To Find",
      "Recycling Saves Money",
      "Refine Lunar Ore",
      "Remember To Recharge",
      "Remember Your Home",
      "Repair It Yourself",
      "Repair Your Ship",
      "Save Your Progress",
      "Some Actions Increase Your Rank",
      "Some Repairs Take Longer",
      "Some Rocks Contain Crystals",
      "Some Things Cost More Than Money",
      "Take Good Notes",
      "The Eyes See Everything",
      "This Is A Treasure Chest",
      "This Is Not Food",
      "Use Ore To Build Explosives",
      "Use Your Radio From Afar",
      "Watch For Other Life Forms",
      "Watch For The Signs",
      "Watch Your Fuel Levels",
      "You Are Only Human"
    };
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
    private int loadspot;
    private List<Color> colortab = new List<Color>();
    private List<int> posxtab = new List<int>();
    private List<int> posytab = new List<int>();
    private int pulse = 10;
    private int loadIndex;
    private SoundEffect button;
    private int num;

    public MiniGame()
      : base("")
    {
      this.TransitionOnTime = TimeSpan.FromSeconds(2.5);
      this.TransitionOffTime = TimeSpan.FromSeconds(2.2000000476837158);
    }

    public override void LoadContent()
    {
      if (this.content == null)
        this.content = new ContentManager((IServiceProvider) this.ScreenManager.Game.Services, "Content");
      this.random = new Random(77);
      this.graphicsDevice = this.ScreenManager.GraphicsDevice;
      this.button = this.content.Load<SoundEffect>("Audio\\gong");
      this.gear2 = this.content.Load<Texture2D>("sprites\\icons\\gear1");
      this.random = new Random(57);
      this.num = this.random.Next(1, 14);
      this.horPos = this.random.Next(0, 900);
      this.sizer = (float) this.random.Next(2800, 4800) / 1000f;
      this.buttonOn = this.content.Load<Texture2D>("sprites\\icons\\buttonon" + (object) this.num);
      this.loadfont1 = this.content.Load<SpriteFont>("fonts\\tag");
      this.loadfont2 = this.content.Load<SpriteFont>("fonts\\load");
      this.L257load = this.content.Load<Texture2D>("menus\\Loading");
      this.allcolors(1);
      this.rays = this.content.Load<Texture2D>("loading\\rays");
      this.messagedisplay = "\"" + this.messages[this.loadIndex - 1] + "\"";
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
      if (this.loadIndex > this.messages.Length)
        this.loadIndex = 1;
      if (this.loadIndex < 1)
        this.loadIndex = this.messages.Length;
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
      int index1 = (int) this.ControllingPlayer.Value;
      GamePadState currentGamePadState = input.CurrentGamePadStates[index1];
      if (currentGamePadState.Buttons.Back == ButtonState.Pressed)
        this.fadeflag = 3;
      if (currentGamePadState.Buttons.A == ButtonState.Pressed && this.previousgamepadstate.Buttons.A == ButtonState.Released)
      {
        this.allcolors(1);
        this.colortab.Clear();
        this.posxtab.Clear();
        this.posytab.Clear();
        this.messagedisplay = "\"" + this.messages[this.loadIndex - 1] + "\"";
        int num1 = 0;
        int num2 = 1;
        for (int index2 = 0; index2 < this.colorArray1.Length; ++index2)
        {
          ++num1;
          if (num1 > 32)
          {
            num1 = 1;
            ++num2;
          }
          int int16_1 = (int) Convert.ToInt16(this.colorArray1[index2].R);
          int int16_2 = (int) Convert.ToInt16(this.colorArray1[index2].G);
          if ((int) Convert.ToInt16(this.colorArray1[index2].B) + int16_2 + int16_1 > 20)
          {
            this.colortab.Add(this.colorArray1[index2]);
            this.posxtab.Add(num1);
            this.posytab.Add(num2);
          }
        }
        this.realrot = 0.0f;
        this.horPos = this.random.Next(0, 900);
        this.sizer = (float) this.random.Next(1800, 5800) / 1000f;
        this.realrot = 0.0f;
        this.locX.Clear();
        this.locY.Clear();
        this.col.Clear();
      }
      if (currentGamePadState.Buttons.B == ButtonState.Pressed && this.previousgamepadstate.Buttons.B == ButtonState.Released)
      {
        this.allcolors(-1);
        this.colortab.Clear();
        this.posxtab.Clear();
        this.posytab.Clear();
        this.messagedisplay = "\"" + this.messages[this.loadIndex - 1] + "\"";
        int num3 = 0;
        int num4 = 1;
        for (int index3 = 0; index3 < this.colorArray1.Length; ++index3)
        {
          ++num3;
          if (num3 > 32)
          {
            num3 = 1;
            ++num4;
          }
          int int16_3 = (int) Convert.ToInt16(this.colorArray1[index3].R);
          int int16_4 = (int) Convert.ToInt16(this.colorArray1[index3].G);
          if ((int) Convert.ToInt16(this.colorArray1[index3].B) + int16_4 + int16_3 > 20)
          {
            this.colortab.Add(this.colorArray1[index3]);
            this.posxtab.Add(num3);
            this.posytab.Add(num4);
          }
        }
        this.realrot = 0.0f;
        this.horPos = this.random.Next(0, 900);
        this.sizer = (float) this.random.Next(1800, 5800) / 1000f;
        this.realrot = 0.0f;
        this.locX.Clear();
        this.locY.Clear();
        this.col.Clear();
      }
      if (currentGamePadState.Buttons.X == ButtonState.Pressed && this.previousgamepadstate.Buttons.X == ButtonState.Released)
      {
        --this.num;
        if (this.num < 1)
          this.num = 14;
        this.buttonOn = this.content.Load<Texture2D>("sprites\\icons\\buttonon" + (object) this.num);
        this.horPos = this.random.Next(0, 900);
        this.sizer = (float) this.random.Next(1800, 5800) / 1000f;
        this.realrot = 0.0f;
      }
      if (currentGamePadState.Buttons.Y == ButtonState.Pressed && this.previousgamepadstate.Buttons.Y == ButtonState.Released)
      {
        ++this.num;
        if (this.num > 13)
          this.num = 1;
        this.buttonOn = this.content.Load<Texture2D>("sprites\\icons\\buttonon" + (object) this.num);
        this.horPos = this.random.Next(0, 900);
        this.sizer = (float) this.random.Next(1800, 5800) / 1000f;
        this.realrot = 0.0f;
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
      if ((double) this.rot > 0.15)
      {
        this.rot = 0.0f;
        this.realrot += 0.05f;
        --this.pulse;
        if (this.pulse <= 0)
          this.pulse = 12;
        if (this.colortab.Count > 0)
        {
          int index1 = this.random.Next(0, this.colortab.Count);
          int num1 = this.posxtab[index1] - 16;
          int num2 = this.posytab[index1] - 16;
          this.locX.Add((float) (num1 * 12 + 640) + (float) this.random.Next(-1000, 1000) / 1000f);
          this.locY.Add((float) (num2 * 12 + 330) + (float) this.random.Next(-1000, 1000) / 1000f);
          this.col.Add(this.colortab[index1]);
          this.colortab.RemoveAt(index1);
          this.posxtab.RemoveAt(index1);
          this.posytab.RemoveAt(index1);
          if (this.colortab.Count > 0)
          {
            int index2 = this.random.Next(0, this.colortab.Count);
            int num3 = this.posxtab[index2] - 16;
            int num4 = this.posytab[index2] - 16;
            this.locX.Add((float) (num3 * 12 + 640) + (float) this.random.Next(-1000, 1000) / 1000f);
            this.locY.Add((float) (num4 * 12 + 330) + (float) this.random.Next(-1000, 1000) / 1000f);
            this.col.Add(this.colortab[index2]);
            this.colortab.RemoveAt(index2);
            this.posxtab.RemoveAt(index2);
            this.posytab.RemoveAt(index2);
          }
          if (this.colortab.Count > 0)
          {
            int index3 = this.random.Next(0, this.colortab.Count);
            int num5 = this.posxtab[index3] - 16;
            int num6 = this.posytab[index3] - 16;
            this.locX.Add((float) (num5 * 12 + 640) + (float) this.random.Next(-1000, 1000) / 1000f);
            this.locY.Add((float) (num6 * 12 + 330) + (float) this.random.Next(-1000, 1000) / 1000f);
            this.col.Add(this.colortab[index3]);
            this.colortab.RemoveAt(index3);
            this.posxtab.RemoveAt(index3);
            this.posytab.RemoveAt(index3);
          }
          if (this.colortab.Count > 0)
          {
            int index4 = this.random.Next(0, this.colortab.Count);
            int num7 = this.posxtab[index4] - 16;
            int num8 = this.posytab[index4] - 16;
            this.locX.Add((float) (num7 * 12 + 640) + (float) this.random.Next(-1000, 1000) / 1000f);
            this.locY.Add((float) (num8 * 12 + 330) + (float) this.random.Next(-1000, 1000) / 1000f);
            this.col.Add(this.colortab[index4]);
            this.colortab.RemoveAt(index4);
            this.posxtab.RemoveAt(index4);
            this.posytab.RemoveAt(index4);
          }
          if (this.pulse == 3)
            this.button.Play(0.3f * this.ScreenManager.ev, (float) this.random.Next(-1000, 1000) / 1000f, 0.0f);
        }
      }
      this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
      this.spriteBatch.Draw(this.dossy, new Vector2((float) this.horPos, (float) ((double) this.realrot * 20.0 - 150.0)), new Rectangle?(), new Color(120, 120, 200, 80), 0.0f, new Vector2(0.0f, 0.0f), this.sizer, SpriteEffects.None, 0.0f);
      this.spriteBatch.Draw(this.L257load, new Vector2(0.0f, 0.0f), new Rectangle?(), Color.White, 0.0f, new Vector2(0.0f, 0.0f), 2f, SpriteEffects.None, 0.0f);
      for (int index = 0; index < this.locX.Count; ++index)
        this.spriteBatch.Draw(this.buttonOn, new Vector2(this.locX[index], this.locY[index]), this.col[index]);
      this.spriteBatch.Draw(this.gear2, new Vector2(160f, 60f), new Rectangle?(), Color.White, this.realrot, new Vector2((float) (this.gear2.Width / 2), (float) (this.gear2.Height / 2)), 1f, SpriteEffects.None, 0.0f);
      this.spriteBatch.Draw(this.gear2, new Vector2(192f, 92f), new Rectangle?(), Color.White, (float) (-(double) this.realrot + 0.0099999997764825821), new Vector2((float) (this.gear2.Width / 2), (float) (this.gear2.Height / 2)), 0.66f, SpriteEffects.None, 0.0f);
      this.spriteBatch.DrawString(this.loadfont1, "Simulated Loading.....   " + this.loadIndex.ToString(), new Vector2(230f, 35f), Color.White);
      this.spriteBatch.DrawString(this.loadfont1, this.messagedisplay, new Vector2((float) (this.graphicsDevice.Viewport.Width / 2) - this.loadfont1.MeasureString(this.messagedisplay).X / 2f, (float) (this.graphicsDevice.Viewport.Height - 130)), new Color(200, 200, 230));
      if (this.colortab.Count <= 0)
      {
        this.loadspot += 2;
        if (this.loadspot > 80)
          this.loadspot = 0;
        this.spriteBatch.Draw(this.rays, new Vector2((float) (this.graphicsDevice.Viewport.Width / 2), (float) (this.graphicsDevice.Viewport.Height / 2)), new Rectangle?(), new Color((int) (byte) ((int) byte.MaxValue - this.loadspot * 3), (int) (byte) ((int) byte.MaxValue - this.loadspot * 3), (int) (byte) ((int) byte.MaxValue - this.loadspot * 3), 190), 0.0f, new Vector2((float) (this.rays.Width / 2), (float) (this.rays.Height / 2)), (float) (((double) this.loadspot / 70.0 + 1.5) * 4.0), SpriteEffects.None, 0.0f);
      }
      this.spriteBatch.End();
    }
  }
}
