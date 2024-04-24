using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

#pragma warning disable CS0067
#pragma warning disable CS0414
#pragma warning disable CS0169
#nullable disable
namespace Blood
{
  internal class Construction : MenuScreen
  {
    private bool delayinput = true;
    private bool mousemoving;
    private PlayerIndex myplayer;
    private GamePadState gamePadState;
    private KeyboardState keyState;
    private KeyboardState prevkeyState;
    private MouseState mouseState;
    private MouseState prevMouse;
    private float oldangle;
    private bool snapped;
    private Vector2 screenoffset;
    private SpriteBatch spriteBatch;
    private Rectangle fullscreen;
    private Rectangle topbar;
    private Rectangle bottombar;
    private Rectangle topRGB;
    private Rectangle rectangle_0;
    private Rectangle cursor;
    private Rectangle buttonB;
    private Rectangle hammer1;
    private Rectangle hammer2;
    private Rectangle dozer;
    private Rectangle infoicon;
    private Rectangle chestR;
    private Rectangle switchR;
    private Rectangle breakerR;
    private Rectangle gateR;
    private Rectangle trihallR;
    private Rectangle longR;
    private Rectangle hallR;
    private Rectangle crossR;
    private Rectangle deadR;
    private Rectangle cornerR;
    private Rectangle oxygenR;
    private Rectangle powerR;
    private Rectangle salvageR;
    private Rectangle dirtR;
    private Rectangle[] icons;
    private Vector2[] boxGrid = new Vector2[6]
    {
      new Vector2(317f, 260f),
      new Vector2(317f, 345f),
      new Vector2(317f, 430f),
      new Vector2(907f, 260f),
      new Vector2(907f, 345f),
      new Vector2(907f, 430f)
    };
    private List<Rectangle> collide1 = new List<Rectangle>();
    private Rectangle collideBut1;
    private Rectangle collideBut2;
    private Rectangle cursorBox;
    private int butpress;
    private float curX;
    private float curY;
    private float curRot;
    private float curScale = 1f;
    private float curOpacity = 0.6f;
    private float boxScaleUp = 1f;
    private int boxInc;
    private int boxIndexUp = -1;
    private float[] boxSize = new float[9]
    {
      0.95f,
      0.98f,
      1f,
      1.03f,
      1.05f,
      1.1f,
      1.13f,
      1.1f,
      1.05f
    };
    private string[] boxName = new string[6]
    {
      "Xtra Attachment",
      "Solar Panels",
      "Mining System",
      "Engine Type",
      "Wheel Type",
      "Flatbed Type"
    };
    private float boxScaleDown = 1f;
    private int boxDec = 1;
    private int boxIndexDown = -1;
    private float mytimer;
    private int flashTimer;
    private float flashAnim;
    private Rectangle glow = new Rectangle(235, 80, 66, 66);
    private int flash2 = -1;
    private float upgradeScale = 0.2f;
    private float boxOpacity = 0.9f;
    private int myframe;
    private int max;
    private int currentNum = -1;
    private bool touching;
    private int touchingBox;
    private GamePadState gamestate;
    private GamePadState prevstate;
    private ScreenManager sc;
    private ContentManager content;
    private bool facilityNeedsLoading;
    private Texture2D conTexture;
    private Texture2D conTextureBG;
    private Texture2D dirtmap;
    private float startwidth2;
    private float starthite2;
    private float startaspect2;
    private float stretch2;
    private Rectangle src;
    private Rectangle destn;
    private float amt;
    private Vector2 ctr;
    private Matrix projection;
    private Matrix view;
    private Matrix orientation = Matrix.CreateRotationY(1f);
    private float myRot = 1.5f;
    private Vector3 sunDir = new Vector3(0.5f, 1f, 0.1f);
    private Facility facility;
    private List<Construction.parts> mypart = new List<Construction.parts>();

    public event EventHandler<PlayerIndexEventArgs> Accepted;

    public event EventHandler<PlayerIndexEventArgs> Cancelled;

    public Construction(ref Facility fac)
      : base("")
    {
      this.facility = fac;
      this.facilityNeedsLoading = false;
      this.TransitionOnTime = TimeSpan.FromSeconds(0.0);
      this.TransitionOffTime = TimeSpan.FromSeconds(0.0);
    }

    public Construction()
      : base("")
    {
      this.facility = new Facility();
      Facility.inFacility = false;
      this.facilityNeedsLoading = true;
      this.TransitionOnTime = TimeSpan.FromSeconds(0.0);
      this.TransitionOffTime = TimeSpan.FromSeconds(0.0);
    }

    public override void LoadContent()
    {
      if (this.content == null)
        this.content = new ContentManager((IServiceProvider) this.ScreenManager.Game.Services, "Content//astro//");
      this.spriteBatch = new SpriteBatch(this.ScreenManager.GraphicsDevice);
      this.sc = this.ScreenManager;
      if (this.facilityNeedsLoading)
        this.facility.LoadContent(this.content, this.sc);
      this.conTexture = this.content.Load<Texture2D>("textures//conTexture");
      this.conTextureBG = this.content.Load<Texture2D>("textures//conTexture2");
      this.dirtmap = this.content.Load<Texture2D>("textures//dirt");
      this.fullscreen = new Rectangle(480, 0, 800, 450);
      this.topbar = new Rectangle(0, 0, 1280, 80);
      this.bottombar = new Rectangle(0, 654, 1280, 66);
      this.topRGB = new Rectangle(155, 0, 39, 113);
      this.rectangle_0 = new Rectangle(0, 70, 40, 40);
      this.hammer1 = new Rectangle(0, 533, 80, 67);
      this.hammer2 = new Rectangle(88, 533, 80, 67);
      this.dozer = new Rectangle(176, 533, 80, 67);
      this.infoicon = new Rectangle(0, 602, 257, 262);
      this.cursor = new Rectangle(72, 116, 64, 64);
      this.curX = 640f;
      this.curY = 360f;
      this.buttonB = new Rectangle(198, 0, 26, 26);
      this.salvageR = new Rectangle(0, 212, 90, 90);
      this.powerR = new Rectangle(90, 212, 90, 90);
      this.oxygenR = new Rectangle(180, 212, 90, 90);
      this.longR = new Rectangle(0, 302, 90, 90);
      this.deadR = new Rectangle(90, 302, 90, 90);
      this.trihallR = new Rectangle(180, 302, 90, 90);
      this.hallR = new Rectangle(0, 392, 90, 90);
      this.cornerR = new Rectangle(90, 392, 90, 90);
      this.crossR = new Rectangle(180, 392, 90, 90);
      this.chestR = new Rectangle(0, 482, 30, 30);
      this.gateR = new Rectangle(30, 482, 30, 30);
      this.breakerR = new Rectangle(60, 482, 30, 30);
      this.switchR = new Rectangle(90, 482, 30, 30);
      this.dirtR = new Rectangle(565, 1, 235, 235);
      this.loadParts(ref this.facility.powerPos, "power", this.powerR);
      this.loadParts(ref this.facility.oxygenPos, "oxygen", this.oxygenR);
      this.loadParts(ref this.facility.salvagePos, "salvage", this.salvageR);
      this.loadParts(ref this.facility.trihallPos, "tri", this.trihallR);
      this.loadParts(ref this.facility.crossPos, "cross", this.crossR);
      this.loadParts(ref this.facility.cornerPos, "corner", this.cornerR);
      this.loadParts(ref this.facility.deadPos, "dead", this.deadR);
      this.loadParts(ref this.facility.longPos, "long", this.longR);
      this.loadParts(ref this.facility.hallwayPos, "hall", this.hallR);
      this.loadParts(ref this.facility.gatePos, "gate", this.gateR);
      this.loadParts(ref this.facility.switchPos, "switch", this.switchR);
      this.loadParts(ref this.facility.chestPos, "chest", this.chestR);
      this.screenoffset = new Vector2(0.0f, -400f);
      this.startwidth2 = (float) this.conTextureBG.Width;
      this.starthite2 = (float) this.conTextureBG.Height;
      this.startaspect2 = this.startwidth2 / this.starthite2;
      this.stretch2 = this.startaspect2 / this.sc.aspectratio2;
      Vector2 vector2 = new Vector2(1280f, 720f) * 1f;
      if ((double) vector2.X / (double) vector2.Y >= (double) this.sc.aspectratio2)
      {
        this.src = new Rectangle(0, 0, this.conTextureBG.Width, this.conTextureBG.Height);
        this.amt = (float) this.conTextureBG.Width / vector2.X;
        this.destn = new Rectangle((int) ((double) this.sc.width * 0.5), (int) ((double) this.sc.hite * 0.5), (int) ((double) this.sc.width * (double) this.amt), (int) ((double) this.sc.hite / (double) this.stretch2 * (double) this.amt));
        this.ctr = new Vector2((float) this.conTextureBG.Width, (float) this.conTextureBG.Height) / 2f;
      }
      else
      {
        this.src = new Rectangle(0, 0, this.conTextureBG.Width, this.conTextureBG.Height);
        this.amt = (float) this.conTextureBG.Height / vector2.Y;
        this.destn = new Rectangle((int) ((double) this.sc.width * 0.5), (int) ((double) this.sc.hite * 0.5), (int) ((double) this.sc.width * (double) this.stretch2 * (double) this.amt), (int) ((double) this.sc.hite * (double) this.amt));
        this.ctr = new Vector2((float) this.conTextureBG.Width, (float) this.conTextureBG.Height) / 2f;
      }
    }

    public override void UnloadContent()
    {
      this.content.Unload();
      this.content.Dispose();
      this.content = (ContentManager) null;
    }

    public void loadParts(ref float[] part, string name, Rectangle rect)
    {
      for (int index = 0; index < part.Length; index += 4)
        this.mypart.Add(new Construction.parts()
        {
          angle = part[index + 3],
          pos = new Vector3(part[index], part[index + 1], part[index + 2]),
          type = name,
          rr = rect
        });
    }

    public void copyParts()
    {
      int count1 = 0;
      int count2 = 0;
      int count3 = 0;
      int count4 = 0;
      int count5 = 0;
      int count6 = 0;
      int count7 = 0;
      int count8 = 0;
      int count9 = 0;
      int count10 = 0;
      int count11 = 0;
      int count12 = 0;
      for (int index = 0; index < this.mypart.Count; ++index)
      {
        if (this.mypart[index].type == "gate")
          this.replacePart(ref this.facility.gatePos, index, ref count11);
        if (this.mypart[index].type == "switch")
          this.replacePart(ref this.facility.switchPos, index, ref count12);
        if (this.mypart[index].type == "chest")
          this.replacePart(ref this.facility.chestPos, index, ref count10);
        if (this.mypart[index].type == "power")
          this.replacePart(ref this.facility.powerPos, index, ref count1);
        if (this.mypart[index].type == "oxygen")
          this.replacePart(ref this.facility.oxygenPos, index, ref count2);
        if (this.mypart[index].type == "salvage")
          this.replacePart(ref this.facility.salvagePos, index, ref count3);
        if (this.mypart[index].type == "tri")
          this.replacePart(ref this.facility.trihallPos, index, ref count4);
        if (this.mypart[index].type == "cross")
          this.replacePart(ref this.facility.crossPos, index, ref count5);
        if (this.mypart[index].type == "corner")
          this.replacePart(ref this.facility.cornerPos, index, ref count6);
        if (this.mypart[index].type == "hall")
          this.replacePart(ref this.facility.hallwayPos, index, ref count7);
        if (this.mypart[index].type == "long")
          this.replacePart(ref this.facility.longPos, index, ref count8);
        if (this.mypart[index].type == "dead")
          this.replacePart(ref this.facility.deadPos, index, ref count9);
      }
    }

    public void replacePart(ref float[] part, int i, ref int count)
    {
      int index = count;
      if (part.Length < index + 4)
        Array.Resize<float>(ref part, index + 4);
      part[index] = this.mypart[i].pos.X;
      part[index + 1] = this.mypart[i].pos.Y;
      part[index + 2] = this.mypart[i].pos.Z;
      part[index + 3] = this.mypart[i].angle;
      count += 4;
    }

    public new bool KMdown(Keys k)
    {
      bool flag;
      switch (k)
      {
        case Keys.Print:
          flag = this.mouseState.XButton1 == ButtonState.Pressed;
          break;
        case Keys.PrintScreen:
          flag = this.mouseState.XButton2 == ButtonState.Pressed;
          break;
        case Keys.VolumeMute:
          flag = this.mouseState.MiddleButton == ButtonState.Pressed;
          break;
        case Keys.VolumeDown:
          flag = this.mouseState.LeftButton == ButtonState.Pressed;
          break;
        case Keys.VolumeUp:
          flag = this.mouseState.RightButton == ButtonState.Pressed;
          break;
        default:
          flag = this.keyState.IsKeyDown(k);
          break;
      }
      return flag;
    }

    public bool method_1(Keys k)
    {
      bool flag;
      switch (k)
      {
        case Keys.Print:
          flag = this.prevMouse.XButton1 == ButtonState.Released;
          break;
        case Keys.PrintScreen:
          flag = this.prevMouse.XButton2 == ButtonState.Released;
          break;
        case Keys.VolumeMute:
          flag = this.prevMouse.MiddleButton == ButtonState.Released;
          break;
        case Keys.VolumeDown:
          flag = this.prevMouse.LeftButton == ButtonState.Released;
          break;
        case Keys.VolumeUp:
          flag = this.prevMouse.RightButton == ButtonState.Released;
          break;
        default:
          flag = this.prevkeyState.IsKeyUp(k);
          break;
      }
      return flag;
    }

    public new bool KMtoggle(Keys k)
    {
      bool flag;
      switch (k)
      {
        case Keys.Print:
          flag = this.mouseState.XButton1 == ButtonState.Pressed && this.prevMouse.XButton1 == ButtonState.Released;
          break;
        case Keys.PrintScreen:
          flag = this.mouseState.XButton2 == ButtonState.Pressed && this.prevMouse.XButton2 == ButtonState.Released;
          break;
        case Keys.VolumeMute:
          flag = this.mouseState.MiddleButton == ButtonState.Pressed && this.prevMouse.MiddleButton == ButtonState.Released;
          break;
        case Keys.VolumeDown:
          flag = this.mouseState.LeftButton == ButtonState.Pressed && this.prevMouse.LeftButton == ButtonState.Released;
          break;
        case Keys.VolumeUp:
          flag = this.mouseState.RightButton == ButtonState.Pressed && this.prevMouse.RightButton == ButtonState.Released;
          break;
        default:
          flag = this.keyState.IsKeyDown(k) && this.prevkeyState.IsKeyUp(k);
          break;
      }
      return flag;
    }

    public bool Ktoggle(Keys k) => this.keyState.IsKeyDown(k) && this.prevkeyState.IsKeyUp(k);

    public override void HandleInput(InputState input)
    {
      this.sc.Game.IsMouseVisible = false;
      if (this.ControllingPlayer.HasValue)
      {
        int index = (int) this.ControllingPlayer.Value;
        this.gamestate = input.CurrentGamePadStates[index];
        this.prevstate = input.LastGamePadStates[index];
      }
      ++this.myframe;
      this.prevkeyState = input.lastKeyState;
      this.keyState = input.currentKeyState;
      this.prevMouse = this.mouseState;
      this.mouseState = Mouse.GetState();
      if (this.myframe % 120 == 0)
        this.sc.centerWindow();
      float num1 = (float) this.mouseState.X - this.sc.mymouse.X;
      float num2 = this.sc.mymouse.Y - (float) this.mouseState.Y;
      if (this.delayinput)
      {
        this.prevMouse = this.mouseState;
        this.prevkeyState = this.keyState;
        this.delayinput = false;
      }
      this.mousemoving = this.mouseState.X != (int) this.sc.mymouse.X || this.mouseState.Y != (int) this.sc.mymouse.Y;
      this.sc.mymouse.X = (float) this.mouseState.X;
      this.sc.mymouse.Y = (float) this.mouseState.Y;
      if (this.Ktoggle(Keys.Back) || this.Ktoggle(this.sc.escape_key) || input.IsMenuCancel(this.ControllingPlayer, out PlayerIndex _))
      {
        messagebox screen = new messagebox("Are You finished Building?", 1, 0);
        screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
        {
          this.copyParts();
          this.facility.resetClickables();
          this.facility.loadClickables();
          this.facility.buildFloor(3);
          this.facility.updateGateCollision();
          this.ScreenManager.menuflag = 0;
          this.ExitScreen();
        });
        screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => { });
        this.ScreenManager.AddScreen((GameScreen) screen, new PlayerIndex?());
      }
      if (!this.sc.usingMouse)
      {
        this.screenoffset.X -= this.gamestate.ThumbSticks.Right.X * 5f;
        this.screenoffset.Y += this.gamestate.ThumbSticks.Right.Y * 5f;
      }
      else if (this.KMdown(this.sc.rmb_key))
      {
        float num3 = 0.1f;
        if ((double) num1 < -0.10000000149011612)
          this.screenoffset.X -= Math.Abs(num1);
        if ((double) num1 > (double) num3)
          this.screenoffset.X += Math.Abs(num1);
        if ((double) num2 < -(double) num3)
          this.screenoffset.Y += Math.Abs(num2);
        if ((double) num2 > (double) num3)
          this.screenoffset.Y -= Math.Abs(num2);
      }
      float num4 = 8f;
      if (this.touching)
        num4 = 6f;
      if (!this.snapped)
      {
        if (!this.sc.usingMouse)
        {
          Vector2 result = this.gamestate.ThumbSticks.Left * (this.gamestate.ThumbSticks.Left.Length() * this.gamestate.ThumbSticks.Left.Length());
          Vector2 min = -Vector2.One;
          Vector2 one = Vector2.One;
          Vector2.Clamp(ref result, ref min, ref one, out result);
          this.curX += result.X * num4;
          this.curY -= result.Y * num4;
          this.curX = MathHelper.Clamp(this.curX, 40f, 1240f);
          this.curY = MathHelper.Clamp(this.curY, 90f, 650f);
        }
        else
        {
          this.curX = this.sc.adjustVector2(this.sc.mymouse).X;
          this.curY = this.sc.adjustVector2(this.sc.mymouse).Y;
        }
      }
      else
      {
        int num5 = 10;
        int num6 = 400;
        if ((double) this.gamestate.Triggers.Right > 0.5)
          num5 = 4;
        if (this.mypart[this.currentNum].type == "chest" || this.mypart[this.currentNum].type == "switch" || this.mypart[this.currentNum].type == "gate")
        {
          num5 = 5;
          num6 = 50;
          if ((double) this.gamestate.Triggers.Right > 0.5)
            num6 = 200;
        }
        Vector2 left = this.gamestate.ThumbSticks.Left;
        if (this.sc.usingMouse)
        {
          if (this.myframe % num5 == 0)
          {
            float num7 = 0.0f;
            if ((double) num1 < -0.0)
            {
              this.mypart[this.currentNum].pos.X -= (float) num6;
              this.sc.back.Play(this.sc.ev, 0.3f, 0.0f);
            }
            if ((double) num1 > (double) num7)
            {
              this.mypart[this.currentNum].pos.X += (float) num6;
              this.sc.back.Play(this.sc.ev, 0.25f, 0.0f);
            }
            if ((double) num2 < -(double) num7)
            {
              this.mypart[this.currentNum].pos.Z += (float) num6;
              this.sc.back.Play(this.sc.ev, 0.25f, 0.0f);
            }
            if ((double) num2 > (double) num7)
            {
              this.mypart[this.currentNum].pos.Z -= (float) num6;
              this.sc.back.Play(this.sc.ev, 0.3f, 0.0f);
            }
          }
          Vector2 vector2 = this.sc.adjustVector2(this.sc.mymouse);
          this.mypart[this.currentNum].pos.X = (float) (((double) vector2.X - (double) this.screenoffset.X) * 13.333333015441895);
          this.mypart[this.currentNum].pos.Z = (float) (((double) vector2.Y - (double) this.screenoffset.Y) * 13.333333015441895);
          this.mypart[this.currentNum].pos.X = (float) Math.Round((double) this.mypart[this.currentNum].pos.X / 200.0, 0) * 200f;
          this.mypart[this.currentNum].pos.Z = (float) Math.Round((double) this.mypart[this.currentNum].pos.Z / 200.0, 0) * 200f;
        }
        else if (this.myframe % num5 == 0)
        {
          float num8 = 0.0f;
          if ((double) left.X < -0.0)
          {
            this.mypart[this.currentNum].pos.X -= (float) num6;
            this.sc.back.Play(this.sc.ev, 0.3f, 0.0f);
          }
          if ((double) left.X > (double) num8)
          {
            this.mypart[this.currentNum].pos.X += (float) num6;
            this.sc.back.Play(this.sc.ev, 0.25f, 0.0f);
          }
          if ((double) left.Y < -(double) num8)
          {
            this.mypart[this.currentNum].pos.Z += (float) num6;
            this.sc.back.Play(this.sc.ev, 0.25f, 0.0f);
          }
          if ((double) left.Y > (double) num8)
          {
            this.mypart[this.currentNum].pos.Z -= (float) num6;
            this.sc.back.Play(this.sc.ev, 0.3f, 0.0f);
          }
        }
        this.curX = this.screenoffset.X + this.mypart[this.currentNum].pos.X / 13.333333f;
        this.curY = this.screenoffset.Y + this.mypart[this.currentNum].pos.Z / 13.333333f;
        this.curScale = 0.7f;
      }
      if (this.KMtoggle(this.sc.lmb_key) || this.gamestate.Buttons.A == ButtonState.Pressed && this.prevstate.Buttons.A == ButtonState.Released)
      {
        if (!this.snapped)
        {
          if (this.mypart.Count > 0 && this.currentNum < this.mypart.Count && this.currentNum >= 0)
          {
            this.sc.select.Play(this.sc.ev, -0.2f, 0.0f);
            this.curX = this.mypart[this.currentNum].pos.X / 13.333333f;
            this.curY = this.mypart[this.currentNum].pos.Z / 13.333333f;
            this.snapped = true;
            this.oldangle = this.mypart[this.currentNum].angle;
          }
        }
        else
        {
          this.mypart[this.currentNum].pos.X = (float) Math.Round((double) this.mypart[this.currentNum].pos.X / 100.0, 0) * 100f;
          this.mypart[this.currentNum].pos.Z = (float) Math.Round((double) this.mypart[this.currentNum].pos.Z / 100.0, 0) * 100f;
          this.snapped = false;
          this.sc.drop.Play(this.sc.ev, 0.0f, 0.0f);
        }
      }
      if (this.snapped && (this.Ktoggle(this.sc.a_key) || this.gamestate.Buttons.LeftShoulder == ButtonState.Pressed && this.prevstate.Buttons.LeftShoulder == ButtonState.Released) && this.mypart.Count > 0 && this.currentNum < this.mypart.Count && this.currentNum >= 0)
      {
        this.oldangle = this.mypart[this.currentNum].angle;
        this.mypart[this.currentNum].angle += 1.57079637f;
        this.sc.forklift.Play(this.sc.ev * 0.7f, -0.2f, 0.0f);
      }
      if (this.snapped && (this.Ktoggle(this.sc.d_key) || this.gamestate.Buttons.RightShoulder == ButtonState.Pressed && this.prevstate.Buttons.RightShoulder == ButtonState.Released) && this.mypart.Count > 0 && this.currentNum < this.mypart.Count && this.currentNum >= 0)
      {
        this.oldangle = this.mypart[this.currentNum].angle;
        this.mypart[this.currentNum].angle -= 1.57079637f;
        this.sc.forklift.Play(this.sc.ev * 0.7f, -0.1f, 0.0f);
      }
      this.delayinput = false;
    }

    public override void Update(
      GameTime gameTime,
      bool otherScreenHasFocus,
      bool coveredByOtherScreen)
    {
      if (this.flashTimer > 0)
      {
        --this.flashTimer;
        this.flashAnim += 8.4f;
        if ((double) this.flashAnim > 126.0)
          this.flashAnim = 0.0f;
      }
      ++this.mytimer;
      this.cursorBox = new Rectangle((int) ((double) this.curX - 10.0), (int) ((double) this.curY - 10.0), 20, 20);
      if (this.touching)
      {
        float num = 0.06f;
        this.curScale -= num;
        if ((double) this.curScale < 0.89999997615814209)
          this.curScale = 0.9f;
        this.curOpacity += num;
        if ((double) this.curOpacity > 1.1000000238418579)
          this.curOpacity = 1.1f;
        this.curRot += num;
      }
      else
      {
        float num = 0.06f;
        this.curScale += num;
        if ((double) this.curScale > 1.0)
          this.curScale = 1f;
        this.curOpacity -= num;
        if ((double) this.curOpacity < 0.89999997615814209)
          this.curOpacity = 0.9f;
        this.curRot = 0.0f;
      }
      base.Update(gameTime, otherScreenHasFocus, false);
    }

    public override void Draw(GameTime gameTime)
    {
      this.touching = false;
      if (!this.snapped)
        this.currentNum = -1;
      this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.LinearWrap, (DepthStencilState) null, (RasterizerState) null, (Effect) null, this.sc.ScaleMatrix1);
      this.spriteBatch.Draw(this.sc.blankTexture, new Vector2(640f, 360f), new Rectangle?(), new Color(43, 29, 25, (int) byte.MaxValue), 0.0f, new Vector2(2f, 2f), 3000f, SpriteEffects.None, 0.0f);
      this.spriteBatch.Draw(this.dirtmap, new Vector2(640f, 760f) + this.screenoffset, new Rectangle?(), Color.White, 0.0f, new Vector2(640f, 360f), 1.3f, SpriteEffects.None, 0.0f);
      this.collide1.Clear();
      this.drawParts(this.screenoffset);
      this.spriteBatch.Draw(this.conTexture, new Vector2(this.curX, this.curY), new Rectangle?(this.cursor), Color.White * this.curOpacity, this.curRot, new Vector2(32f, 32f), this.curScale, SpriteEffects.None, 0.0f);
      this.spriteBatch.End();
      this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);
      this.spriteBatch.Draw(this.conTextureBG, this.destn, new Rectangle?(this.src), Color.White, 0.0f, this.ctr, SpriteEffects.None, 0.0f);
      this.spriteBatch.End();
    }

    public void drawParts(Vector2 offset)
    {
      for (int index = 0; index < this.mypart.Count; ++index)
      {
        float x = this.mypart[index].pos.X / 13.333333f;
        float y = this.mypart[index].pos.Z / 13.333333f;
        float num1 = this.mypart[index].angle % 6.28318548f;
        if ((double) num1 < 0.0)
          num1 += 6.28318548f;
        int num2 = (int) ((double) x + (double) offset.X);
        int num3 = (int) ((double) y + (double) offset.Y);
        Rectangle rectangle = new Rectangle(num2 - 20, num3 - 20, 40, 40);
        float num4 = 45f;
        Color color1 = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        Color color2 = new Color(130, (int) byte.MaxValue, 130, (int) byte.MaxValue);
        if (this.mypart[index].type == "chest" || this.mypart[index].type == "switch" || this.mypart[index].type == "gate")
        {
          num4 = 15f;
          color1 = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
          rectangle = new Rectangle(num2 - 10, num3 - 10, 20, 20);
          color2 = new Color(130, (int) byte.MaxValue, 130, (int) byte.MaxValue);
        }
        if (!this.collide1.Contains(rectangle))
          this.collide1.Add(rectangle);
        if (!this.snapped && rectangle.Intersects(this.cursorBox))
        {
          this.touching = true;
          this.currentNum = index;
          this.spriteBatch.Draw(this.conTexture, new Vector2(x, y) + offset, new Rectangle?(this.mypart[index].rr), color2, -num1, new Vector2(num4, num4), 1f, SpriteEffects.None, 0.0f);
        }
        else if (!this.snapped || this.currentNum != index)
          this.spriteBatch.Draw(this.conTexture, new Vector2(x, y) + offset, new Rectangle?(this.mypart[index].rr), color1, -num1, new Vector2(num4, num4), 1f, SpriteEffects.None, 0.0f);
      }
      if (!this.snapped)
        return;
      float x1 = this.mypart[this.currentNum].pos.X / 13.333333f;
      float y1 = this.mypart[this.currentNum].pos.Z / 13.333333f;
      float num5;
      if ((double) this.oldangle != (double) this.mypart[this.currentNum].angle)
      {
        this.oldangle = MathHelper.Lerp(this.oldangle, this.mypart[this.currentNum].angle, 0.1f);
        num5 = this.oldangle % 6.28318548f;
        if ((double) num5 < 0.0)
          num5 += 6.28318548f;
      }
      else
      {
        num5 = this.mypart[this.currentNum].angle % 6.28318548f;
        if ((double) num5 < 0.0)
          num5 += 6.28318548f;
      }
      float scale = 1.1f;
      float num6 = 45f;
      Color color = new Color(130, 130, (int) byte.MaxValue, (int) byte.MaxValue);
      float num7 = (float) Math.Sin((double) this.mytimer / 10.0) * 0.04f;
      if (this.mypart[this.currentNum].type == "chest" || this.mypart[this.currentNum].type == "switch" || this.mypart[this.currentNum].type == "gate")
      {
        num7 = 0.0f;
        scale = 1f;
        num6 = 15f;
        color = new Color(130, 130, (int) byte.MaxValue, (int) byte.MaxValue);
      }
      this.spriteBatch.Draw(this.conTexture, new Vector2(x1, y1) + offset, new Rectangle?(this.mypart[this.currentNum].rr), color, -num5 + num7, new Vector2(num6, num6), scale, SpriteEffects.None, 0.0f);
    }

    public class parts
    {
      public Vector3 pos;
      public float angle;
      public string type;
      public Rectangle rr;
    }
  }
}
