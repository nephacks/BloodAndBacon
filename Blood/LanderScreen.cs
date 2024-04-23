// Decompiled with JetBrains decompiler
// Type: Blood.LanderScreen
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
  internal class LanderScreen : MenuScreen
  {
    private BasicEffect basiceffect;
    private Effect writeEffect;
    private bool leftclick;
    private bool rightclick;
    private bool lbumperClick;
    private bool rbumperClick;
    private Texture2D blankTexture;
    private Texture2D back;
    private Texture2D thumb;
    private float mytimer;
    private float btimer;
    private int automove;
    private Vector3 controllerpos = new Vector3(0.0f, 0.0f, 0.0f);
    private int fader = (int) byte.MaxValue;
    private int fadeflag = 1;
    private ContentManager content;
    private Model controller;
    private Matrix projectionMatrix;
    private Matrix viewMatrix;
    private float aspectRatio;
    private Matrix axisMatrix = Matrix.Identity;
    private Matrix spinMatrix = Matrix.Identity;
    private Random random;
    private Vector3 lastpos = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 tracepos = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 followpos = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 lastfollowpos = new Vector3(0.0f, 0.0f, 0.0f);
    private GamePadState previousgamepadstate;
    private Vector3 camlookpos = new Vector3(0.0f, 0.0f, -100f);
    private Vector3 campos = Vector3.Zero;
    private float camradius = 2900f;
    private float camradian = 2.8f;
    private float camheight = 2.8f;
    private Matrix xrot = Matrix.CreateRotationX(0.0f);
    private Matrix zrot = Matrix.CreateRotationX(0.0f);
    private float dpadincx;
    private float dpadincz;
    private ModelBone dpadBone;
    private Matrix dpadTransform;
    private Matrix dpadMatrix = Matrix.Identity;
    private ModelBone rstickBone;
    private Matrix rstickTransform;
    private Matrix rstickMatrix = Matrix.Identity;
    private ModelBone lstickBone;
    private Matrix lstickTransform;
    private Matrix lstickMatrix = Matrix.Identity;
    private ModelBone ltBone;
    private Matrix ltTransform;
    private Matrix ltMatrix = Matrix.Identity;
    private ModelBone rtBone;
    private Matrix rtTransform;
    private Matrix rtMatrix = Matrix.Identity;
    private ModelBone lbBone;
    private Matrix lbTransform;
    private Matrix lbMatrix = Matrix.Identity;
    private ModelBone rbBone;
    private Matrix rbTransform;
    private Matrix rbMatrix = Matrix.Identity;
    private ModelBone bBone;
    private Matrix bTransform;
    private Matrix bMatrix = Matrix.Identity;
    private ModelBone aBone;
    private Matrix aTransform;
    private Matrix aMatrix = Matrix.Identity;
    private ModelBone xBone;
    private Matrix xTransform;
    private Matrix xMatrix = Matrix.Identity;
    private ModelBone yBone;
    private Matrix yTransform;
    private Matrix yMatrix = Matrix.Identity;
    private int buttonflagA;
    private int buttonflagB;
    private int buttonflagX;
    private int buttonflagY;
    private SpriteBatch spriteBatch;
    private SpriteFont tag;
    private SpriteFont menufont;
    private Quad quad;
    private VertexDeclaration quadVertexDec;
    private Matrix world;
    private BasicEffect effect;
    private Vector2 textPosition = new Vector2(256f);
    private float radians = Convert.ToSingle(Math.PI / 5.0);
    private ParticleSystem tracerx;
    private ParticleSystem dotx;
    private ParticleSystem buttonburstA;
    private ParticleSystem buttonburstB;
    private ParticleSystem buttonburstX;
    private ParticleSystem buttonburstY;
    private Texture2D leftstick;
    private Texture2D rightstick;
    private Texture2D xbutton;
    private Texture2D bbutton;
    private Texture2D abutton;
    private Texture2D ybutton;
    private Texture2D rtrigger;
    private Texture2D rbumper;
    private Texture2D ltrigger;
    private Texture2D lbumper;
    private Texture2D dpadLR;
    private Texture2D dpadUD;
    private Vector3 leftstick0 = new Vector3(-350f, 275f, -180f);
    private Vector3 leftstick1 = new Vector3(-480f, 450f, -190f);
    private Vector3 rightstick0 = new Vector3(180f, 230f, 30f);
    private Vector3 rightstick1 = new Vector3(300f, 450f, 30f);
    private Vector3 xbutton0 = new Vector3(190f, 190f, -190f);
    private Vector3 xbutton1 = new Vector3(80f, 250f, -190f);
    private Vector3 bbutton0 = new Vector3(420f, 190f, -190f);
    private Vector3 bbutton1 = new Vector3(570f, 250f, -190f);
    private Vector3 ybutton0 = new Vector3(305f, 220f, -300f);
    private Vector3 ybutton1 = new Vector3(330f, 280f, -420f);
    private Vector3 abutton0 = new Vector3(305f, 150f, -90f);
    private Vector3 abutton1 = new Vector3(390f, 160f, 60f);
    private Vector3 rtrigger0 = new Vector3(330f, 90f, -360f);
    private Vector3 rtrigger1 = new Vector3(400f, -80f, -530f);
    private Vector3 rbumper0 = new Vector3(250f, 180f, -370f);
    private Vector3 rbumper1 = new Vector3(150f, 100f, -460f);
    private Vector3 ltrigger0 = new Vector3(-320f, 90f, -360f);
    private Vector3 ltrigger1 = new Vector3(-400f, -80f, -530f);
    private Vector3 lbumper0 = new Vector3(-250f, 180f, -370f);
    private Vector3 lbumper1 = new Vector3(-150f, 100f, -460f);
    private Vector3 dpadLR0 = new Vector3(-270f, 150f, 10f);
    private Vector3 dpadLR1 = new Vector3(-450f, 200f, 0.0f);
    private Vector3 dpadUD0 = new Vector3(-180f, 135f, 100f);
    private Vector3 dpadUD1 = new Vector3(-280f, 100f, 300f);
    private int drawonce;
    private string[] defined = new string[0];
    private string[] lander = new string[12]
    {
      "Steering",
      "camera",
      "NA",
      "objectives",
      "  Activate",
      "beacon",
      "Thrust",
      "Unknown",
      "reverse",
      "Unknown",
      "On/Off",
      "Select"
    };
    private string[] lander2 = new string[12]
    {
      "Steering",
      "zoomout",
      "NA",
      "displays",
      "  Activate",
      "drop",
      "Thrust",
      "Unknown",
      "reverse",
      "Unknown",
      "On/Off",
      "Select"
    };
    private string[] rover = new string[12]
    {
      "Steering",
      "Camera",
      "interact",
      "objective",
      "  Activate",
      "honk",
      "Forward",
      "scooper",
      "Reverse",
      "scooper",
      "On/Off",
      "Select"
    };
    private string[] rover2 = new string[12]
    {
      "Steering",
      "zoomout",
      "interact",
      "display",
      "  Activate",
      "getout",
      "Forward",
      "open",
      "Reverse",
      "close",
      "On/Off",
      "Select"
    };
    private string[] walk = new string[12]
    {
      nameof (walk),
      "look",
      "interact",
      "objective",
      "  jump",
      "callout",
      "NA",
      "Unknown",
      "NA",
      "Unknown",
      "On/Off",
      "Select"
    };
    private string[] walk2 = new string[12]
    {
      "run",
      "look",
      "interact",
      "display",
      " doublejump",
      "disembark",
      "NA",
      "Unknown",
      "NA",
      "Unknown",
      "On/Off",
      "Select"
    };
    private string[] xxx = new string[12]
    {
      "Lstick",
      "Rstickk",
      nameof (xbutton),
      nameof (bbutton),
      nameof (abutton),
      nameof (ybutton),
      nameof (rtrigger),
      nameof (rbumper),
      nameof (ltrigger),
      nameof (lbumper),
      nameof (dpadUD),
      nameof (dpadLR)
    };
    private string header;
    private string[] header1 = new string[5]
    {
      "",
      "Lander Controls",
      "Rover Controls",
      "V127 Controls",
      "Menu Controls"
    };
    private Vector3 diffuse;
    private Vector3 diffuse1 = new Vector3(0.7f, 0.7f, 0.7f);
    private Vector3 diffuse2 = new Vector3(0.7f, 0.7f, 0.7f);
    private Vector3 diffuse3 = new Vector3(0.3f, 0.3f, 0.3f);
    private Vector3 diffuse4 = new Vector3(0.35f, 0.35f, 0.35f);
    private string[] titlehead = new string[5]
    {
      "Shit Happens",
      " lander",
      " rover",
      " walking",
      "Shit Happens"
    };
    private int pick;
    private ScreenManager sc;

    public event EventHandler<PlayerIndexEventArgs> Accepted;

    public LanderScreen(int pick, ScreenManager sc)
      : base("")
    {
      this.TransitionOnTime = TimeSpan.FromSeconds(0.0);
      this.TransitionOffTime = TimeSpan.FromSeconds(0.0);
      this.ScreenManager = sc;
      this.defined = new string[this.lander.Length];
      if (pick == 1)
      {
        Array.Copy((Array) this.lander, (Array) this.defined, this.lander.Length);
        this.header = this.header1[pick];
        this.diffuse = this.diffuse1;
      }
      if (pick == 2)
      {
        Array.Copy((Array) this.rover, (Array) this.defined, this.lander.Length);
        this.header = this.header1[pick];
        this.diffuse = this.diffuse2;
      }
      if (pick == 3)
      {
        Array.Copy((Array) this.walk, (Array) this.defined, this.lander.Length);
        this.header = this.header1[pick];
        this.diffuse = this.diffuse3;
      }
      this.pick = pick;
    }

    public override void LoadContent()
    {
      if (this.content == null)
        this.content = new ContentManager((IServiceProvider) this.ScreenManager.Game.Services, "Content");
      this.random = new Random();
      this.sc = this.ScreenManager;
      this.projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(30f), this.sc.aspectratio2, 1f, 490000f);
      this.viewMatrix = Matrix.CreateLookAt(this.campos, this.camlookpos, Vector3.Up);
      this.basiceffect = new BasicEffect(this.sc.GraphicsDevice)
      {
        TextureEnabled = true,
        VertexColorEnabled = true
      };
      this.controller = this.sc.controllerX;
      this.dpadBone = this.controller.Bones["DPAD"];
      this.dpadTransform = this.dpadBone.Transform;
      this.rstickBone = this.controller.Bones["RSTICK"];
      this.rstickTransform = this.rstickBone.Transform;
      this.lstickBone = this.controller.Bones["LSTICK"];
      this.lstickTransform = this.lstickBone.Transform;
      this.ltBone = this.controller.Bones["LT"];
      this.ltTransform = this.ltBone.Transform;
      this.rtBone = this.controller.Bones["RT"];
      this.rtTransform = this.rtBone.Transform;
      this.lbBone = this.controller.Bones["LB"];
      this.lbTransform = this.lbBone.Transform;
      this.rbBone = this.controller.Bones["RB"];
      this.rbTransform = this.rbBone.Transform;
      this.aBone = this.controller.Bones["A"];
      this.bBone = this.controller.Bones["B"];
      this.xBone = this.controller.Bones["X"];
      this.yBone = this.controller.Bones["Y"];
      this.aTransform = this.aBone.Transform;
      this.bTransform = this.bBone.Transform;
      this.xTransform = this.xBone.Transform;
      this.yTransform = this.yBone.Transform;
      this.effect = new BasicEffect(this.ScreenManager.GraphicsDevice);
      this.spriteBatch = new SpriteBatch(this.ScreenManager.GraphicsDevice);
      this.world = Matrix.Identity;
      this.tracerx = (ParticleSystem) new lineSystem(this.sc.Game, this.content);
      this.tracerx.Initialize();
      this.tracerx.LoadContent(this.sc.GraphicsDevice);
    }

    public override void UnloadContent() => this.content.Unload();

    public override void HandleInput(InputState input)
    {
      if (input == null)
        throw new ArgumentNullException(nameof (input));
      int index = (int) this.ControllingPlayer.Value;
      GamePadState currentGamePadState = input.CurrentGamePadStates[index];
      if (currentGamePadState.Buttons.Back == ButtonState.Pressed || input.IsMenuCancel(this.ControllingPlayer, out this.sc.playerindex))
        this.fadeflag = 3;
      if (this.fadeflag == 3)
      {
        if (this.Accepted != null)
          this.Accepted((object) this, new PlayerIndexEventArgs(this.sc.playerindex));
        this.ScreenManager.menuflag = 0;
        this.ExitScreen();
      }
      this.btimer += 0.02f;
      if ((double) this.btimer > 6.0)
        this.automove = 1;
      if (this.automove == 1)
        this.camradian -= 0.01f;
      if (this.previousgamepadstate != currentGamePadState)
      {
        this.automove = 0;
        this.btimer = 0.0f;
      }
      this.camradius -= currentGamePadState.ThumbSticks.Left.Y * 50f;
      if ((double) this.camradius < 1000.0)
        this.camradius = 1000f;
      if ((double) this.camradius > 5000.0)
        this.camradius = 5000f;
      this.camradian -= currentGamePadState.ThumbSticks.Right.X / 16f;
      this.camheight -= currentGamePadState.ThumbSticks.Right.Y / 25f;
      if ((double) this.camheight > 4.0)
        this.camheight = 4f;
      if ((double) this.camheight < 2.0)
        this.camheight = 2f;
      if ((double) this.camradian > 6.28)
        this.camradian = 0.0f;
      if ((double) this.camradian < 0.0)
        this.camradian = 6.28f;
      this.campos.X = (float) -Math.Cos((double) this.camheight) * (float) Math.Sin((double) this.camradian) * this.camradius;
      this.campos.Z = (float) -Math.Cos((double) this.camheight) * (float) -Math.Cos((double) this.camradian) * this.camradius;
      this.campos.Y = (float) Math.Sin((double) this.camheight) * this.camradius;
      if (currentGamePadState.DPad.Right == ButtonState.Released && currentGamePadState.DPad.Left == ButtonState.Released)
      {
        this.zrot = Matrix.CreateRotationZ(0.0f);
        this.dpadincz = 0.0f;
      }
      if (currentGamePadState.DPad.Up == ButtonState.Released && currentGamePadState.DPad.Down == ButtonState.Released)
      {
        this.dpadincx = 0.0f;
        this.xrot = Matrix.CreateRotationX(0.0f);
      }
      if (currentGamePadState.DPad.Right == ButtonState.Pressed)
      {
        this.dpadincz -= 0.06f;
        this.zrot = Matrix.CreateRotationZ(this.dpadincz);
      }
      if (currentGamePadState.DPad.Left == ButtonState.Pressed)
      {
        this.dpadincz += 0.06f;
        this.zrot = Matrix.CreateRotationZ(this.dpadincz);
      }
      if (currentGamePadState.DPad.Up == ButtonState.Pressed)
      {
        this.dpadincx -= 0.06f;
        this.xrot = Matrix.CreateRotationX(this.dpadincx);
      }
      if (currentGamePadState.DPad.Down == ButtonState.Pressed)
      {
        this.dpadincx += 0.06f;
        this.xrot = Matrix.CreateRotationX(this.dpadincx);
      }
      if ((double) this.dpadincz < -0.11)
        this.dpadincz = -0.11f;
      if ((double) this.dpadincz > 0.11)
        this.dpadincz = 0.11f;
      if ((double) this.dpadincx < -0.11)
        this.dpadincx = -0.11f;
      if ((double) this.dpadincx > 0.11)
        this.dpadincx = 0.11f;
      this.dpadMatrix = this.xrot * this.zrot;
      this.rstickMatrix = Matrix.CreateRotationX((float) (-(double) currentGamePadState.ThumbSticks.Right.Y / 3.0)) * Matrix.CreateRotationZ((float) (-(double) currentGamePadState.ThumbSticks.Right.X / 3.0));
      this.rightclick = false;
      this.leftclick = false;
      if (currentGamePadState.Buttons.RightStick == ButtonState.Pressed)
      {
        this.rightclick = true;
        this.rstickMatrix *= Matrix.CreateTranslation(0.0f, -5f, 0.0f);
      }
      else
        this.rstickMatrix *= Matrix.CreateTranslation(0.0f, 0.0f, 0.0f);
      this.lstickMatrix = Matrix.CreateRotationX((float) (-(double) currentGamePadState.ThumbSticks.Left.Y / 3.0)) * Matrix.CreateRotationZ((float) (-(double) currentGamePadState.ThumbSticks.Left.X / 3.0));
      if (currentGamePadState.Buttons.LeftStick == ButtonState.Pressed)
      {
        this.leftclick = true;
        this.lstickMatrix *= Matrix.CreateTranslation(0.0f, -5f, 0.0f);
      }
      else
        this.lstickMatrix *= Matrix.CreateTranslation(0.0f, 0.0f, 0.0f);
      this.previousgamepadstate = currentGamePadState;
      this.rbumperClick = false;
      this.lbumperClick = false;
      this.rtMatrix = Matrix.CreateRotationX((float) (-(double) currentGamePadState.Triggers.Right / 3.2000000476837158));
      this.ltMatrix = Matrix.CreateRotationX((float) (-(double) currentGamePadState.Triggers.Left / 3.2000000476837158));
      if (currentGamePadState.Buttons.RightShoulder == ButtonState.Pressed)
      {
        this.rbMatrix = Matrix.CreateTranslation(0.0f, 0.0f, 8f);
        this.rbumperClick = true;
      }
      else
        this.rbMatrix = Matrix.CreateTranslation(0.0f, 0.0f, 0.0f);
      if (currentGamePadState.Buttons.LeftShoulder == ButtonState.Pressed)
      {
        this.lbMatrix = Matrix.CreateTranslation(0.0f, 0.0f, 8f);
        this.lbumperClick = true;
      }
      else
        this.lbMatrix = Matrix.CreateTranslation(0.0f, 0.0f, 0.0f);
      this.aMatrix = Matrix.CreateTranslation(0.0f, 0.0f, 0.0f);
      this.buttonflagA = 0;
      this.buttonflagB = 0;
      this.buttonflagX = 0;
      this.buttonflagY = 0;
      if (currentGamePadState.Buttons.A == ButtonState.Pressed)
      {
        this.aMatrix = Matrix.CreateTranslation(0.0f, -6f, 0.0f);
        this.buttonflagA = 1;
      }
      this.bMatrix = Matrix.CreateTranslation(0.0f, 0.0f, 0.0f);
      if (currentGamePadState.Buttons.B == ButtonState.Pressed)
      {
        this.bMatrix = Matrix.CreateTranslation(0.0f, -6f, 0.0f);
        this.buttonflagB = 1;
      }
      this.xMatrix = Matrix.CreateTranslation(0.0f, 0.0f, 0.0f);
      if (currentGamePadState.Buttons.X == ButtonState.Pressed)
      {
        this.xMatrix = Matrix.CreateTranslation(0.0f, -6f, 0.0f);
        this.buttonflagX = 1;
      }
      this.yMatrix = Matrix.CreateTranslation(0.0f, 0.0f, 0.0f);
      if (currentGamePadState.Buttons.Y == ButtonState.Pressed)
      {
        this.yMatrix = Matrix.CreateTranslation(0.0f, -6f, 0.0f);
        this.buttonflagY = 1;
      }
      this.previousgamepadstate = currentGamePadState;
    }

    public override void Update(
      GameTime gameTime,
      bool otherScreenHasFocus,
      bool coveredByOtherScreen)
    {
      this.mytimer += 0.06f;
      if (this.drawonce == 0)
      {
        this.drawonce = 1;
        int index1 = 0;
        if (this.defined[0] != "Unknown" && this.defined[index1] != "NA")
          this.tracerZone(this.leftstick0, this.leftstick1);
        int index2 = index1 + 1;
        if (this.defined[index2] != "Unknown" && this.defined[index2] != "NA")
          this.tracerZone(this.rightstick0, this.rightstick1);
        int index3 = index2 + 1;
        if (this.defined[index3] != "Unknown" && this.defined[index3] != "NA")
          this.tracerZone(this.xbutton0, this.xbutton1);
        int index4 = index3 + 1;
        if (this.defined[index4] != "Unknown" && this.defined[index4] != "NA")
          this.tracerZone(this.bbutton0, this.bbutton1);
        int index5 = index4 + 1;
        if (this.defined[index5] != "Unknown" && this.defined[index5] != "NA")
          this.tracerZone(this.abutton0, this.abutton1);
        int index6 = index5 + 1;
        if (this.defined[index6] != "Unknown" && this.defined[index6] != "NA")
          this.tracerZone(this.ybutton0, this.ybutton1);
        int index7 = index6 + 1;
        if (this.defined[index7] != "Unknown" && this.defined[index7] != "NA")
          this.tracerZone(this.rtrigger0, new Vector3(this.rtrigger1.X, this.rtrigger1.Y + 50f, this.rtrigger1.Z));
        int index8 = index7 + 1;
        if (this.defined[index8] != "Unknown" && this.defined[index8] != "NA")
          this.tracerZone(this.rbumper0, new Vector3(this.rbumper1.X, this.rbumper1.Y + 50f, this.rbumper1.Z));
        int index9 = index8 + 1;
        if (this.defined[index9] != "Unknown" && this.defined[index9] != "NA")
          this.tracerZone(this.ltrigger0, new Vector3(this.ltrigger1.X, this.ltrigger1.Y + 50f, this.ltrigger1.Z));
        int index10 = index9 + 1;
        if (this.defined[index10] != "Unknown" && this.defined[index10] != "NA")
          this.tracerZone(this.lbumper0, new Vector3(this.lbumper1.X, this.lbumper1.Y + 50f, this.lbumper1.Z));
        int index11 = index10 + 1;
        if (this.defined[index11] != "Unknown" && this.defined[index11] != "NA")
          this.tracerZone(this.dpadLR0, this.dpadLR1);
        int index12 = index11 + 1;
        if (this.defined[index12] != "Unknown" && this.defined[index12] != "NA")
          this.tracerZone(this.dpadUD0, this.dpadUD1);
        int num = index12 + 1;
        this.tracerx.Update(gameTime);
      }
      this.viewMatrix = Matrix.CreateLookAt(this.campos, this.camlookpos, Vector3.Up);
      base.Update(gameTime, otherScreenHasFocus, false);
    }

    public override void Draw(GameTime gameTime)
    {
      this.RenderStates();
      this.DrawModel(this.controller);
      this.sc.GraphicsDevice.DepthStencilState = DepthStencilState.DepthRead;
      this.tracerx.SetCamera(this.viewMatrix, this.projectionMatrix);
      this.tracerx.Draw(0);
      this.RenderStates();
      if (this.pick == 1)
      {
        this.defined[0] = this.lander[0];
        if (this.leftclick)
          this.defined[0] = this.lander2[0];
        this.defined[1] = this.lander[1];
        if (this.rightclick)
          this.defined[1] = this.lander2[1];
        this.defined[2] = this.lander[2];
        if (this.buttonflagX == 1)
          this.defined[2] = this.lander2[2];
        this.defined[3] = this.lander[3];
        if (this.buttonflagB == 1)
          this.defined[3] = this.lander2[3];
        this.defined[4] = this.lander[4];
        if (this.buttonflagA == 1)
          this.defined[4] = this.lander2[4];
        this.defined[5] = this.lander[5];
        if (this.buttonflagY == 1)
          this.defined[5] = this.lander2[5];
      }
      if (this.pick == 2)
      {
        this.defined[0] = this.rover[0];
        if (this.leftclick)
          this.defined[0] = this.rover2[0];
        this.defined[1] = this.rover[1];
        if (this.rightclick)
          this.defined[1] = this.rover2[1];
        this.defined[9] = this.rover[9];
        if (this.lbumperClick)
          this.defined[9] = this.rover2[9];
        this.defined[7] = this.rover[7];
        if (this.rbumperClick)
          this.defined[7] = this.rover2[7];
        this.defined[2] = this.rover[2];
        if (this.buttonflagX == 1)
          this.defined[2] = this.rover2[2];
        this.defined[3] = this.rover[3];
        if (this.buttonflagB == 1)
          this.defined[3] = this.rover2[3];
        this.defined[4] = this.rover[4];
        if (this.buttonflagA == 1)
          this.defined[4] = this.rover2[4];
        this.defined[5] = this.rover[5];
        if (this.buttonflagY == 1)
          this.defined[5] = this.rover2[5];
      }
      if (this.pick == 3)
      {
        this.defined[0] = this.walk[0];
        if (this.leftclick)
          this.defined[0] = this.walk2[0];
        this.defined[1] = this.walk[1];
        if (this.rightclick)
          this.defined[1] = this.walk2[1];
        this.defined[2] = this.walk[2];
        if (this.buttonflagX == 1)
          this.defined[2] = this.walk2[2];
        this.defined[3] = this.walk[3];
        if (this.buttonflagB == 1)
          this.defined[3] = this.walk2[3];
        this.defined[4] = this.walk[4];
        if (this.buttonflagA == 1)
          this.defined[4] = this.walk2[4];
        this.defined[5] = this.walk[5];
        if (this.buttonflagY == 1)
          this.defined[5] = this.walk2[5];
      }
      this.DrawQuad(this.defined[0], this.leftstick1);
      this.DrawQuad(this.defined[1], this.rightstick1);
      this.DrawQuad(this.defined[2], this.xbutton1);
      this.DrawQuad(this.defined[3], this.bbutton1);
      this.DrawQuad(this.defined[4], this.abutton1);
      this.DrawQuad(this.defined[5], this.ybutton1);
      this.DrawQuad(this.defined[6], this.rtrigger1);
      this.DrawQuad(this.defined[7], this.rbumper1);
      this.DrawQuad(this.defined[8], this.ltrigger1);
      this.DrawQuad(this.defined[9], this.lbumper1);
      this.DrawQuad(this.defined[10], this.dpadUD1);
      this.DrawQuad(this.defined[11], this.dpadLR1);
      this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) null, this.sc.ScaleMatrix1);
      this.spriteBatch.DrawString(this.sc.landerfont, this.titlehead[this.pick], Vector2.Zero, Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
      this.spriteBatch.End();
    }

    private void DrawModel(Model model)
    {
      this.dpadBone.Transform = this.dpadMatrix * this.dpadTransform;
      this.rstickBone.Transform = this.rstickMatrix * this.rstickTransform;
      this.lstickBone.Transform = this.lstickMatrix * this.lstickTransform;
      this.rtBone.Transform = this.rtMatrix * this.rtTransform;
      this.ltBone.Transform = this.ltMatrix * this.ltTransform;
      this.rbBone.Transform = this.rbMatrix * this.rbTransform;
      this.lbBone.Transform = this.lbMatrix * this.lbTransform;
      this.bBone.Transform = this.bMatrix * this.bTransform;
      this.aBone.Transform = this.aMatrix * this.aTransform;
      this.xBone.Transform = this.xMatrix * this.xTransform;
      this.yBone.Transform = this.yMatrix * this.yTransform;
      Matrix[] destinationBoneTransforms = new Matrix[model.Bones.Count];
      model.CopyAbsoluteBoneTransformsTo(destinationBoneTransforms);
      Matrix matrix = Matrix.CreateRotationX(0.2f) * Matrix.CreateTranslation(this.controllerpos);
      foreach (ModelMesh mesh in model.Meshes)
      {
        int num = 1;
        if (mesh.Name == "A" && this.buttonflagA == 1)
          num = 0;
        if (mesh.Name == "B" && this.buttonflagB == 1)
          num = 0;
        if (mesh.Name == "X" && this.buttonflagX == 1)
          num = 0;
        if (mesh.Name == "Y" && this.buttonflagY == 1)
          num = 0;
        foreach (BasicEffect effect in mesh.Effects)
        {
          effect.World = destinationBoneTransforms[mesh.ParentBone.Index] * matrix;
          effect.View = this.viewMatrix;
          effect.Projection = this.projectionMatrix;
          effect.LightingEnabled = true;
          effect.DirectionalLight0.Enabled = true;
          effect.DirectionalLight1.Enabled = true;
          effect.DirectionalLight2.Enabled = true;
          effect.DirectionalLight0.Direction = new Vector3(0.3f, -0.7f, (float) Math.Sin((double) this.mytimer / 8.0) / 1.2f);
          effect.AmbientLightColor = new Vector3(0.24f, 0.24f, 0.24f);
          effect.DirectionalLight0.DiffuseColor = this.diffuse * 0.8f;
          effect.DirectionalLight0.SpecularColor = new Vector3(0.51f, 0.51f, 0.51f);
          effect.DirectionalLight1.Direction = new Vector3((float) Math.Sin((double) this.mytimer / 4.0) / 1.2f, -0.7f, 0.2f);
          effect.DirectionalLight1.DiffuseColor = this.diffuse * 0.4f;
          effect.DirectionalLight1.SpecularColor = new Vector3(0.45f, 0.45f, 0.45f);
          effect.DirectionalLight2.Direction = new Vector3(0.0f, 0.7f, 0.2f);
          effect.DirectionalLight2.DiffuseColor = new Vector3(0.1f, 0.1f, 0.1f);
          effect.DirectionalLight2.SpecularColor = new Vector3(0.15f, 0.15f, 0.15f);
          effect.SpecularPower = 35f;
          if (num == 0)
            effect.SpecularPower = 1f;
          effect.PreferPerPixelLighting = true;
        }
        mesh.Draw();
      }
    }

    private void DrawQuad(string ss, Vector3 pos)
    {
      switch (ss)
      {
        case "Unknown":
          break;
        case "NA":
          break;
        default:
          ss = ss.ToLower();
          this.basiceffect.View = this.viewMatrix;
          this.basiceffect.Projection = this.projectionMatrix;
          Vector2 origin = this.sc.landerfont.MeasureString(ss) / 2f;
          this.basiceffect.World = Matrix.CreateScale(1f, -1f, 1f) * Matrix.CreateRotationY((float) (-(double) this.camradian + 3.1400001049041748)) * Matrix.CreateTranslation(pos.X, pos.Y + 10f, pos.Z);
          this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, (SamplerState) null, DepthStencilState.Default, RasterizerState.CullNone, (Effect) this.basiceffect);
          this.spriteBatch.DrawString(this.sc.landerfont, ss, Vector2.Zero, Color.White, 0.0f, origin, 1f, SpriteEffects.None, 0.0f);
          this.spriteBatch.End();
          break;
      }
    }

    private void DrawText(string text, RenderTarget2D target)
    {
    }

    private void DrawText2(string text, ref Texture2D tex)
    {
      RenderTarget2D renderTarget = new RenderTarget2D(this.sc.GraphicsDevice, 600, 200, true, SurfaceFormat.Color, DepthFormat.None);
      this.sc.GraphicsDevice.SetRenderTarget(renderTarget);
      this.sc.GraphicsDevice.Clear(Color.Black);
      this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
      this.spriteBatch.DrawString(this.tag, text, new Vector2((float) (300 - text.Length * 5) + 1.5f, 71.5f), Color.Black);
      this.spriteBatch.DrawString(this.tag, text, new Vector2((float) (300 - text.Length * 5) - 1.5f, 71.5f), Color.Black);
      this.spriteBatch.DrawString(this.tag, text, new Vector2((float) (300 - text.Length * 5), 71.5f), Color.Black);
      this.spriteBatch.DrawString(this.tag, text, new Vector2((float) (300 - text.Length * 5), 70f), Color.LightGray);
      this.spriteBatch.End();
      tex = (Texture2D) renderTarget;
    }

    private void Header()
    {
    }

    private void tracerZone(Vector3 pos1, Vector3 pos2)
    {
      float num = Vector3.Distance(pos1, pos2);
      Vector3 vector3 = Vector3.Normalize(pos2 - pos1);
      for (int index = 0; (double) index < (double) num; index += 4)
        this.tracerx.AddParticle(pos1 + (float) index * vector3, new Vector3(0.0f, 0.0f, 0.0f));
    }

    private void RestoreRenderStates()
    {
    }

    private void RenderStates()
    {
      this.ScreenManager.GraphicsDevice.BlendState = BlendState.NonPremultiplied;
      this.sc.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
      this.sc.GraphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;
    }
  }
}
