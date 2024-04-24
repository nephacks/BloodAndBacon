using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Text;

#pragma warning disable CS0414
#pragma warning disable CS0169
#nullable disable
namespace Blood
{
  internal class astrobindings : GameScreen
  {
    public static RasterizerState clipit = new RasterizerState()
    {
      ScissorTestEnable = true
    };
    private bool isHost;
    private bool exclude;
    private int myIndex = -1;
    private int thisKEY;
    private int whichKEY;
    private float origMouseX;
    private Vector2 origMouseXY;
    private Vector2 origPlaque;
    private float nowMouseX;
    private float sliderbox1;
    private float float_0;
    private float sliderbox2;
    private float float_1;
    private float sliderbox3;
    private float float_2;
    private float sliderbox4;
    private float float_3;
    private float scc = 1.2f;
    private Vector2 paperPos;
    private float drift = 10f;
    private float scaler = 1f;
    private float scalerZoom;
    private SoundEffect drip;
    private SoundEffect jot;
    private SoundEffect scribble;
    private SoundEffect cashout;
    private SpriteBatch spriteBatch;
    private SpriteFont scribbleFont;
    private SpriteFont scribbleFont2;
    private Rectangle rectangle_0 = new Rectangle(0, 0, 286, (int) byte.MaxValue);
    private Rectangle rectangle_1 = new Rectangle(286, 0, 286, (int) byte.MaxValue);
    private Rectangle rectangle_2 = new Rectangle(0, 269, 286, (int) byte.MaxValue);
    private Rectangle rectangle_3 = new Rectangle(286, 269, 286, (int) byte.MaxValue);
    private Rectangle rectangle_4 = new Rectangle(23, 658, 321, 337);
    private Rectangle rectangle_5 = new Rectangle(365, 658, 321, 337);
    private Rectangle narrowRect = new Rectangle(49, 0, 181, 254);
    private Rectangle leftArrowRect = new Rectangle(68, 546, 48, 46);
    private Rectangle leftArrowGlowRect = new Rectangle(68, 595, 48, 46);
    private Rectangle rightArrowRect = new Rectangle(171, 546, 48, 46);
    private Rectangle rightArrowGlowRect = new Rectangle(171, 595, 48, 46);
    private Rectangle buttonBoxRect = new Rectangle(627, 221, 45, 45);
    private Rectangle buttonGlowRect = new Rectangle(740, 221, 45, 45);
    private Rectangle rectangle_6 = new Rectangle(626, 139, 48, 48);
    private Rectangle rectangle_7 = new Rectangle(737, 137, 48, 48);
    private Rectangle rectangle_8 = new Rectangle(737, 64, 48, 48);
    private Rectangle rectangle_9 = new Rectangle(626, 66, 48, 48);
    private Rectangle littleboxRect = new Rectangle(626, 302, 60, 57);
    private Rectangle littleglowRect = new Rectangle(567, 302, 60, 57);
    private Rectangle bigboxRect = new Rectangle(576, 384, 211, 68);
    private Rectangle biggerboxRect = new Rectangle(580, 456, 240, 62);
    private Rectangle longboxRect = new Rectangle((int) byte.MaxValue, 549, 377, 41);
    private Rectangle checkmarkRect = new Rectangle(707, 300, 65, 58);
    private Rectangle sliderBoxRect = new Rectangle(702, 548, 33, 42);
    private Rectangle sliderGlowRect = new Rectangle(751, 548, 33, 42);
    private Rectangle sliderRect = new Rectangle(631, 613, 176, 8);
    private float[] musicVal = new float[11]
    {
      0.0f,
      10f,
      19f,
      31f,
      52f,
      87f,
      145f,
      240f,
      360f,
      600f,
      1000f
    };
    private Vector2[] vec;
    private string choice = "";
    private float rampIN;
    private bool hideMenu;
    private Random rr;
    private GamePadState gamestate;
    private GamePadState prevstate;
    private KeyboardState keyState;
    private KeyboardState prevKey;
    private MouseState prevMouse;
    private MouseState mouseState;
    private Vector2 mm = Vector2.Zero;
    private bool delayinput;
    private ScreenManager sc;
    private Vector2 offset;
    private int vecIndex;
    private float rot;
    private Color bluePen;
    private Color blackPen;
    private Color grnPen;
    private int updownIndex;
    private int slider1;
    private int slider2;
    private int slider3;
    private int slider4;
    private int slider5;
    private int slider6;
    private int slider7;
    private int slider8;
    private int slider9;
    private int slider10;
    private int slider11;
    private int slider12;
    private int slider13;
    private int slider14;
    private int slider15;
    private int slider16;
    private int slider17;
    private int slider18;
    private int slider19;
    private int slider20;
    private int slider21;
    private int slider22;
    private int slider23;
    private int slider24;
    private int slider25;
    private Rectangle myRect;
    private static StringBuilder b1 = new StringBuilder(32, 32);
    private string[] diff = new string[3]
    {
      "easy",
      "norm",
      "hard"
    };
    private string[] dayDescribe = new string[152]
    {
      "wildebeasts",
      "wildeboars",
      "grinder",
      "shockem",
      "night attack",
      "revenge day",
      "wildeboars",
      "mammoths",
      "pigrats",
      "needy greedy",
      "chargiboars",
      "brutiboars",
      "wilde  boars",
      "skelaboars",
      "pigrats",
      "mammoths",
      "revenge day",
      "night death",
      "chargiboars",
      "princess fight",
      "blue boars",
      "brutiboars",
      "pigadillos",
      "pigrats",
      "night attack",
      "revenge day",
      "mammoths",
      "skelaboars",
      "pigadillos",
      "the brethren",
      "hell hounds",
      "the stampede",
      "armadillo herds",
      "frutiboars",
      "revenge day",
      "mammoths",
      "hell hounds",
      "skelaboars",
      "armadillos",
      "boss fight",
      "the beast",
      "the innocents",
      "mammoths",
      "skelaboars",
      "revenge day",
      "brutiboars",
      "pigadillos",
      "chargiboars",
      "death combo",
      "mini boss",
      "mammoths",
      "stampede",
      "dusk til death",
      "pigadillos",
      "brute boars",
      "revenge day",
      "oh fatsnap",
      "mammoths",
      "death march",
      "big boss fight",
      "stampedes",
      "the herds",
      "pigrats",
      "mammoths",
      "pigadillos",
      "revenge day",
      "brute boars",
      "night mammoths",
      "brute boars",
      "TroikaBoss",
      "skelaboars",
      "pigadillos",
      "mammoths",
      "dusk stomp ",
      "revenge day",
      "boar hounds",
      "pigrats",
      "bulkaboars",
      "wilde boars",
      "boss fight",
      "boar hounds",
      "pigrats",
      "skelaboars",
      "mammoth hounds",
      "revenge day",
      "pigrats",
      "ambushed",
      "bulkaboars",
      "until dusk",
      "mini boss",
      "stampede",
      "pray for day",
      "mammoths",
      "wilde boars",
      "revenge day",
      "bulkaboars",
      "chargiboars",
      "death herds",
      "bulkaboars",
      "you're fucked",
      "happiness",
      "mammoths",
      "chargiboars",
      "night",
      "pigadillos",
      "brutiboars",
      "revenge day",
      "oh shit",
      "mammoths",
      "pigrats",
      "big boss fight",
      "stampedes",
      "the herds",
      "pigrats",
      "mammoths",
      "pigadillos",
      "revenge day",
      "brutiboars",
      "night mammoths",
      "brutiboars",
      "3 Mini Boss",
      "skelaboars",
      "pigadillos",
      "mammoths",
      "dusk stomp ",
      "revenge day",
      "boar hounds",
      "pigrats",
      "bulkaboars",
      "wilde boars",
      "boss fight",
      "boar hounds",
      "pigrats",
      "skelaboars",
      "mammoth hounds",
      "revenge day",
      "pigrats",
      "pigadillos",
      "chargiboars",
      "oh shit",
      "mini boss",
      "oh shit",
      "night fuck",
      "mammoths",
      "wilde boars",
      "revenge day",
      "bulkaboars",
      "chargiboars",
      "death herds",
      "bulkaboars",
      "you're fucked",
      "happiness"
    };
    private PlayerIndex playerIndex;

    public event EventHandler<PlayerIndexEventArgs> Accepted;

    public event EventHandler<PlayerIndexEventArgs> Cancelled;

    public event EventHandler<PlayerIndexEventArgs> CheatSent;

    public event EventHandler<PlayerIndexEventArgs> LevelSent;

    public astrobindings(string ch)
    {
      this.choice = ch;
      this.IsPopup = true;
      this.TransitionOnTime = TimeSpan.FromSeconds(0.0);
      this.TransitionOffTime = TimeSpan.FromSeconds(0.0);
    }

    public override void LoadContent()
    {
      ContentManager content = this.ScreenManager.Game.Content;
      this.sc = this.ScreenManager;
      this.spriteBatch = new SpriteBatch(this.ScreenManager.GraphicsDevice);
      this.rr = new Random();
      this.rot = 0.0f;
      this.drift = (float) this.rr.Next(250, 1900) / 100f;
      if (this.rr.Next(1, 100) < 50)
        this.drift = -this.drift;
      this.delayinput = true;
      this.scribbleFont = this.sc.scribblefont2;
      this.grnPen = new Color(30, 50, (int) byte.MaxValue, (int) byte.MaxValue);
      this.bluePen = new Color(30, 30, 140, (int) byte.MaxValue);
      this.blackPen = new Color(0, 0, 0, (int) byte.MaxValue);
      int num1 = this.rr.Next(0, 4);
      if (num1 == 0)
        this.myRect = this.rectangle_0;
      if (num1 == 1)
        this.myRect = this.rectangle_1;
      if (num1 == 2)
        this.myRect = this.rectangle_2;
      if (num1 == 3)
        this.myRect = this.rectangle_3;
      this.jot = !(this.choice == "instructions") ? this.sc.jot2 : this.sc.jot1;
      this.drip = this.sc.drip;
      this.cashout = this.sc.cashout;
      this.scribble = this.sc.scribble;
      this.offset = new Vector2(-70f, 0.0f);
      if (this.choice == "video")
      {
        this.offset = new Vector2(-90f, 0.0f);
        this.myRect = this.rectangle_4;
        if (this.sc.usingMouse)
          this.myRect = this.rectangle_5;
      }
      if (this.choice == "options")
        this.offset = new Vector2(-50f, 0.0f);
      if (this.choice == "audio")
        this.offset = new Vector2(-50f, 0.0f);
      if (this.choice == "kicks")
        this.offset = new Vector2(-50f, 0.0f);
      this.scribble.Play(this.sc.ev * 0.8f, (float) this.rr.Next(-30, 30) / 100f, 0.0f);
      this.vecIndex = 9;
      this.vec = new Vector2[80];
      for (int index = 0; index < 80; ++index)
        this.vec[index] = new Vector2(0.0f, 0.0f);
      if (this.choice == "restart")
      {
        this.updownIndex = this.sc.currentDay;
        this.vec[0] = new Vector2(4.6f, -58.4f);
        this.vec[1] = new Vector2(4.8f, -8.2f);
        this.vec[2] = new Vector2(-22.2f, 56.4f);
        this.vec[3] = new Vector2(52.2f, 163f);
        this.vec[4] = new Vector2(82.2f, 55.2f);
        this.vec[5] = new Vector2(157f, 163f);
        this.vec[6] = new Vector2(0.0f, 0.0f);
        this.vec[7] = new Vector2(0.0f, 0.0f);
        this.vec[8] = new Vector2(0.0f, 0.0f);
        this.vec[9] = new Vector2(0.0f, 0.0f);
      }
      if (this.choice == "kicks")
      {
        this.updownIndex = 0;
        this.vec[0] = new Vector2(10f, -85f);
        this.vec[1] = new Vector2(10f, -40f);
        this.vec[2] = new Vector2(10f, 5f);
        this.vec[3] = new Vector2(10f, 50f);
        this.vec[4] = new Vector2(10f, 95f);
        this.vec[5] = new Vector2(30f, 10f);
        this.vec[6] = new Vector2(30f, 55f);
        this.vec[7] = new Vector2(30f, 100f);
        this.vec[8] = new Vector2(30f, 145f);
        this.vec[9] = new Vector2(30f, 190f);
        this.vec[10] = new Vector2(0.0f, 0.0f);
        this.vec[11] = new Vector2(0.0f, 0.0f);
        this.vec[12] = new Vector2(0.0f, 0.0f);
        this.vec[13] = new Vector2(0.0f, 0.0f);
      }
      if (this.choice == "options")
      {
        this.updownIndex = 0;
        this.vec[0] = new Vector2(-25f, -52f);
        this.vec[1] = new Vector2(34f, 6.6f);
        this.vec[2] = new Vector2(-19.19f, 66.2f);
        this.vec[3] = new Vector2(35.19f, 41.99f);
        this.vec[4] = new Vector2(58f, 100.4f);
        this.vec[5] = new Vector2(38.99f, 162.19f);
        this.vec[6] = new Vector2(0.0f, 0.0f);
        this.vec[7] = new Vector2(0.0f, 0.0f);
        this.vec[8] = new Vector2(0.0f, 0.0f);
        this.vec[9] = new Vector2(0.0f, 0.0f);
      }
      if (this.choice == "audio")
      {
        this.updownIndex = 0;
        this.vec[0] = new Vector2(-36.8f, -89.2f);
        this.vec[1] = new Vector2(-1.8f, -21.8f);
        this.vec[2] = new Vector2(-44.6f, 35.4f);
        this.vec[3] = new Vector2(34f, 5.2f);
        this.vec[4] = new Vector2(60.2f, 71.4f);
        this.vec[5] = new Vector2(27.2f, 129.6f);
        this.vec[6] = new Vector2(63.2f, -87.8f);
        this.vec[7] = new Vector2(91.6f, -23f);
        this.vec[8] = new Vector2(55f, 35.8f);
        this.vec[9] = new Vector2(35.2f, 110.4f);
        this.vec[10] = new Vector2(94.6f, 216.2f);
        this.slider1 = (int) Math.Round(Math.Sqrt((double) this.sc.mv * 100.0));
        this.slider2 = (int) Math.Round(Math.Sqrt((double) this.sc.ev * 100.0));
        this.slider3 = (int) Math.Round(Math.Sqrt((double) this.sc.vv * 100.0));
        this.slider1 = (int) MathHelper.Clamp((float) this.slider1, 0.0f, 10f);
        this.slider2 = (int) MathHelper.Clamp((float) this.slider2, 0.0f, 10f);
        this.slider3 = (int) MathHelper.Clamp((float) this.slider3, 0.0f, 10f);
        this.sliderbox1 = (float) ((double) this.slider1 * 16.799999237060547 - 84.0);
        this.sliderbox2 = (float) ((double) this.slider2 * 16.799999237060547 - 84.0);
        this.sliderbox3 = (float) ((double) this.slider3 * 16.799999237060547 - 84.0);
      }
      if (this.choice == "video")
      {
        this.vec[0] = new Vector2(42.8f, -46.8f);
        this.vec[1] = new Vector2(137.4f, 98f);
        this.vec[2] = new Vector2(23f, -1f);
        this.vec[3] = new Vector2(90.2f, 144.8f);
        this.vec[4] = new Vector2(44.4f, 41.6f);
        this.vec[5] = new Vector2(136f, 189f);
        this.sliderbox1 = (float) ((double) this.sc.brightness * 0.65880000591278076 - 84.0);
        this.sliderbox2 = (float) ((double) this.sc.contrast * 0.65880000591278076 - 84.0);
        this.rampIN = 1f;
      }
      if (this.choice == "game")
      {
        this.vec[0] = new Vector2(-21.3f, -97.8f);
        this.vec[1] = new Vector2(208f, -2.5f);
        this.vec[2] = new Vector2(216f, -10.4f);
        this.vec[3] = new Vector2(-29.4f, -42.4f);
        this.vec[4] = new Vector2(83.4f, -43.99f);
        this.vec[5] = new Vector2(-5.4f, 14.8f);
        this.vec[6] = new Vector2(215.4f, 111.5f);
        this.vec[7] = new Vector2(226.2f, 103.2f);
        this.vec[8] = new Vector2(-47.8f, 73.9f);
        this.vec[9] = new Vector2(74.8f, 74.4f);
        this.vec[10] = new Vector2(32f, 122.6f);
        this.vec[11] = new Vector2(99.4f, 230.2f);
        this.vec[12] = new Vector2(36f, -4f);
        this.vec[13] = new Vector2(14f, 54f);
        this.vec[14] = new Vector2(46f, 112f);
        this.vec[15] = new Vector2(20f, 172f);
        if ((double) this.sc.pad_invertY == 1.0)
          this.slider1 = 0;
        if ((double) this.sc.pad_invertY == -1.0)
          this.slider1 = 1;
        this.slider2 = 4;
        if ((double) this.sc.pad_sensitivity == 3.5)
          this.slider2 = 1;
        if ((double) this.sc.pad_sensitivity == 2.5)
          this.slider2 = 2;
        if ((double) this.sc.pad_sensitivity == 2.0)
          this.slider2 = 3;
        if ((double) this.sc.pad_sensitivity == 1.5)
          this.slider2 = 4;
        if ((double) this.sc.pad_sensitivity == 1.0)
          this.slider2 = 5;
        if ((double) this.sc.pad_sensitivity == 0.75999999046325684)
          this.slider2 = 6;
        if ((double) this.sc.pad_sensitivity == 0.5)
          this.slider2 = 7;
        if ((double) this.sc.pad_sensitivity == 0.25)
          this.slider2 = 8;
        if (!this.sc.pad_vibro)
          this.slider3 = 0;
        if (this.sc.pad_vibro)
          this.slider3 = 1;
        if (!this.sc.pad_togglesprint)
          this.slider5 = 0;
        if (this.sc.pad_togglesprint)
          this.slider5 = 1;
        this.slider4 = this.sc.df;
      }
      if (this.choice == "help")
      {
        this.vec[0] = new Vector2(37f, 52f);
        this.vec[1] = new Vector2(38f, 100f);
        this.vec[3] = new Vector2(40f, 135f);
        this.vec[4] = new Vector2(8.2f, -40f);
        this.vec[5] = new Vector2(8f, 10f);
        this.vec[6] = new Vector2(3.6f, 40f);
        this.scaler = 0.0f;
      }
      if (this.choice == "controller" || this.choice == "controller2")
      {
        this.drift = 100f;
        this.scaler = 0.0f;
      }
      if (this.choice == "instructions")
      {
        this.drift = 100f;
        this.scaler = 0.0f;
      }
      if (this.choice == "cheats")
      {
        this.updownIndex = 0;
        this.vec[0] = new Vector2(-26.8f, -81.2f);
        this.vec[1] = new Vector2(-21.8f, -28.8f);
        this.vec[2] = new Vector2(-29.5999985f, 29f);
        this.vec[30] = new Vector2(-25f, 78f);
        this.vec[3] = new Vector2(60f, 18f);
        this.vec[4] = new Vector2(100f, 69.5f);
        this.vec[5] = new Vector2(57f, 127.5f);
        this.vec[31] = new Vector2(60f, 177f);
        this.vec[6] = new Vector2(33.2f, -80f);
        this.vec[7] = new Vector2(71.6f, -30f);
        this.vec[8] = new Vector2(40f, 29f);
        this.vec[32] = new Vector2(48f, 79f);
        this.vec[9] = new Vector2(25.2f, 85.4f);
        this.vec[10] = new Vector2(94.6f, 191.2f);
        this.slider1 = 0;
        this.slider2 = 0;
        this.slider3 = 0;
        this.slider4 = 0;
        bool flag = true;
        int num2 = 0;
        while (num2 < 19)
          num2 += 2;
        if (this.sc.cheat_InfiniteAmmo)
          this.slider1 = 1;
        if (this.sc.cheat_Invincible)
          this.slider2 = 1;
        if (this.sc.cheat_skipday)
          this.slider4 = 1;
        if (flag)
          this.slider3 = 1;
      }
      if (this.choice == "hidden")
      {
        this.vec[0] = new Vector2(35f, 6.2f);
        this.vec[1] = new Vector2(54.6f, 65.6f);
        this.vec[2] = new Vector2(32.4f, 125.6f);
        this.vec[3] = new Vector2(47f, 185.4f);
        this.vec[4] = new Vector2(-0.8f, -87.6f);
        this.vec[5] = new Vector2(36f, -27.2f);
        this.vec[6] = new Vector2(10f, 31.6f);
        this.vec[7] = new Vector2(14.2f, 93f);
      }
      if (this.choice == "networking")
      {
        if (this.sc.debug_showNetwork)
          this.slider1 = 1;
        this.slider2 = (int) this.sc.networkQuality;
        this.vec[0] = new Vector2(25f, 14f);
        this.vec[1] = new Vector2(27f, 89f);
        this.vec[2] = new Vector2(41f, 153f);
        this.vec[3] = new Vector2(-27f, -81f);
        this.vec[4] = new Vector2(199f, 15f);
        this.vec[5] = new Vector2(212f, 4f);
        this.vec[6] = new Vector2(-26f, -6f);
        this.vec[7] = new Vector2(83f, -8f);
        this.vec[8] = new Vector2(-23f, 58f);
        this.vec[9] = new Vector2(89f, 57f);
        this.vec[10] = new Vector2(34f, 121f);
        this.vec[11] = new Vector2(96f, 228f);
      }
      if (this.choice == "debugging")
      {
        if (this.sc.debug_showGarbage)
          this.slider1 = 1;
        if (this.sc.debug_showHoming)
          this.slider2 = 1;
        if (this.sc.debug_showAccuracy)
          this.slider3 = 1;
        if (this.sc.debug_showSeed)
          this.slider4 = 2;
        this.vec[0] = new Vector2(29f, -4f);
        this.vec[1] = new Vector2(21f, 54f);
        this.vec[2] = new Vector2(35f, 108f);
        this.vec[3] = new Vector2(22f, 163f);
        this.vec[4] = new Vector2(0.0f, -96f);
        this.vec[5] = new Vector2(206f, -2f);
        this.vec[6] = new Vector2(216f, -10f);
        this.vec[7] = new Vector2(-28f, -38f);
        this.vec[8] = new Vector2(198f, 56f);
        this.vec[9] = new Vector2(211f, 47f);
        this.vec[10] = new Vector2(-7f, 12f);
        this.vec[11] = new Vector2(210f, 110f);
        this.vec[12] = new Vector2(221f, 101f);
        this.vec[13] = new Vector2(-18f, 67f);
        this.vec[14] = new Vector2(197f, 165f);
        this.vec[15] = new Vector2(208f, 156f);
        this.vec[16] = new Vector2(41f, 118f);
        this.vec[17] = new Vector2(104f, 226f);
      }
      if (this.choice == "cheat mode")
      {
        if (this.sc.cheat_Invincible)
          this.slider1 = 1;
        if (this.sc.cheat_FastFiring)
          this.slider2 = 1;
        if (this.sc.cheat_InfiniteAmmo)
          this.slider3 = 1;
        if (this.sc.cheat_AllExplode)
          this.slider4 = 1;
        if (this.sc.cheat_PickupPack)
          this.slider5 = 1;
        this.vec[0] = new Vector2(30f, -22f);
        this.vec[1] = new Vector2(55f, 40f);
        this.vec[2] = new Vector2(32f, 101f);
        this.vec[3] = new Vector2(58f, 154f);
        this.vec[4] = new Vector2(23f, 215f);
        this.vec[5] = new Vector2(-18f, -116f);
        this.vec[6] = new Vector2(209f, -21f);
        this.vec[7] = new Vector2(220f, -30f);
        this.vec[8] = new Vector2(10f, -55f);
        this.vec[9] = new Vector2(234f, 42f);
        this.vec[10] = new Vector2(244f, 33f);
        this.vec[11] = new Vector2(-6f, 3f);
        this.vec[12] = new Vector2(214f, 102f);
        this.vec[13] = new Vector2(225f, 91f);
        this.vec[14] = new Vector2(7f, 58f);
        this.vec[15] = new Vector2(235f, 156f);
        this.vec[16] = new Vector2(244f, 145f);
        this.vec[17] = new Vector2(-20f, 120f);
        this.vec[18] = new Vector2(200f, 215f);
        this.vec[19] = new Vector2(210f, 203f);
        this.vec[20] = new Vector2(48f, 172f);
        this.vec[21] = new Vector2(114f, 281f);
      }
      if (this.choice == "level edit")
      {
        this.updownIndex = 0;
        this.slider1 = !(this.sc.dayTime == "am") ? 1 : 0;
        this.slider2 = this.sc.int_4;
        this.slider3 = this.sc.boarCount;
        this.slider4 = this.sc.int_9;
        this.slider5 = this.sc.int_10;
        this.slider6 = this.sc.boar1MinSize;
        this.slider7 = this.sc.boar1MaxSize;
        this.slider8 = this.sc.boar1GiantOdds;
        this.slider9 = this.sc.boar1TinyOdds;
        this.slider10 = this.sc.int_11;
        this.slider11 = this.sc.boar1TurnRate;
        this.slider12 = this.sc.boarDistance[0];
        this.slider14 = this.sc.boarDistance[1];
        this.slider16 = this.sc.boarDistance[2];
        this.slider13 = this.sc.boarHomingLimit[0];
        this.slider15 = this.sc.boarHomingLimit[1];
        this.slider17 = this.sc.boarHomingLimit[2];
        this.vec[0] = new Vector2(-92f, -90f);
        this.vec[1] = new Vector2(-92f, -56f);
        this.vec[2] = new Vector2(-96f, -18f);
        this.vec[3] = new Vector2(-90f, 20f);
        this.vec[4] = new Vector2(-92f, 56f);
        this.vec[5] = new Vector2(-94f, 94f);
        this.vec[6] = new Vector2(-92f, 134f);
        this.vec[7] = new Vector2(-92f, 178f);
        this.vec[8] = new Vector2(-92f, 218f);
        this.vec[9] = new Vector2(-92f, 266f);
        this.vec[10] = new Vector2(-94f, 310f);
        this.vec[11] = new Vector2(-42f, -196f);
        this.vec[12] = new Vector2(114f, -196f);
        this.vec[13] = new Vector2(-50f, -160f);
        this.vec[14] = new Vector2(120f, -160f);
        this.vec[15] = new Vector2(-48f, -124f);
        this.vec[16] = new Vector2(114f, -126f);
        this.vec[17] = new Vector2(-44f, -86f);
        this.vec[18] = new Vector2(112f, -86f);
        this.vec[19] = new Vector2(-40f, -48f);
        this.vec[20] = new Vector2(118f, -50f);
        this.vec[21] = new Vector2(-32f, -10f);
        this.vec[22] = new Vector2(118f, -10f);
        this.vec[23] = new Vector2(-46f, 30f);
        this.vec[24] = new Vector2(118f, 28f);
        this.vec[25] = new Vector2(-46f, 72f);
        this.vec[26] = new Vector2(116f, 68f);
        this.vec[27] = new Vector2(-58f, 114f);
        this.vec[28] = new Vector2(118f, 110f);
        this.vec[29] = new Vector2(-44f, 160f);
        this.vec[30] = new Vector2(120f, 156f);
        this.vec[31] = new Vector2(-48f, 206f);
        this.vec[32] = new Vector2(126f, 202f);
        this.vec[33] = new Vector2(30f, 270f);
        this.vec[34] = new Vector2(2f, 378f);
        this.vec[35] = new Vector2(-84f, -80f);
        this.vec[36] = new Vector2(-88f, -44f);
        this.vec[37] = new Vector2(-86f, -8f);
        this.vec[38] = new Vector2(-86f, 26f);
        this.vec[39] = new Vector2(-82f, 62f);
        this.vec[40] = new Vector2(-84f, 98f);
        this.vec[41] = new Vector2(-88f, 132f);
        this.vec[42] = new Vector2(-86f, 168f);
        this.vec[43] = new Vector2(-84f, 206f);
        this.vec[44] = new Vector2(-84f, 242f);
        this.vec[45] = new Vector2(-86f, 278f);
        this.vec[46] = new Vector2(-84f, 314f);
        this.vec[47] = new Vector2(-42f, -182f);
        this.vec[48] = new Vector2(116f, -184f);
        this.vec[49] = new Vector2(-36f, -148f);
        this.vec[50] = new Vector2(120f, -150f);
        this.vec[51] = new Vector2(-36f, -114f);
        this.vec[52] = new Vector2(128f, -114f);
        this.vec[53] = new Vector2(-34f, -78f);
        this.vec[54] = new Vector2(122f, -80f);
        this.vec[55] = new Vector2(-48f, -40f);
        this.vec[56] = new Vector2(126f, -44f);
        this.vec[57] = new Vector2(-44f, -6f);
        this.vec[58] = new Vector2(122f, -10f);
        this.vec[59] = new Vector2(-42f, 28f);
        this.vec[60] = new Vector2(124f, 26f);
        this.vec[61] = new Vector2(-34f, 64f);
        this.vec[62] = new Vector2(126f, 62f);
        this.vec[63] = new Vector2(-34f, 100f);
        this.vec[64] = new Vector2(126f, 98f);
        this.vec[65] = new Vector2(-36f, 138f);
        this.vec[66] = new Vector2(128f, 136f);
        this.vec[67] = new Vector2(-34f, 172f);
        this.vec[68] = new Vector2(126f, 170f);
        this.vec[69] = new Vector2(-36f, 208f);
        this.vec[70] = new Vector2(130f, 210f);
        this.vec[71] = new Vector2(-56f, 274f);
        this.vec[72] = new Vector2(-58f, 378f);
        this.vec[73] = new Vector2(126f, 270f);
        this.vec[74] = new Vector2(136f, 376f);
      }
      if (!(this.choice == "moon"))
        return;
      this.slider1 = (int) ((double) this.sc.realDarkness * 10.0);
      this.slider2 = this.sc.realMoon;
      this.vec[0] = new Vector2(29f, 44f);
      this.vec[1] = new Vector2(33f, 132f);
      this.vec[2] = new Vector2(-20f, -52f);
      this.vec[3] = new Vector2(88f, -53f);
      this.vec[4] = new Vector2(8f, 37f);
      this.vec[5] = new Vector2(7f, 36f);
      this.vec[6] = new Vector2(42f, 106f);
      this.vec[7] = new Vector2(100f, 214f);
    }

    public override void HandleInput(InputState input)
    {
      if (this.sc.deactivated)
        return;
      if (this.ControllingPlayer.HasValue)
      {
        int index = (int) this.ControllingPlayer.Value;
        this.gamestate = input.CurrentGamePadStates[index];
        this.prevstate = input.LastGamePadStates[index];
      }
      this.prevKey = input.lastKeyState;
      this.keyState = input.currentKeyState;
      this.prevMouse = this.mouseState;
      this.mouseState = Mouse.GetState();
      this.mm.X = (float) this.mouseState.X;
      this.mm.Y = (float) this.mouseState.Y;
      if (this.mouseState.X == (int) this.sc.mymouse.X)
      {
        int y1 = this.mouseState.Y;
      }
      this.sc.mymouse.X = (float) this.mouseState.X;
      this.sc.mymouse.Y = (float) this.mouseState.Y;
      bool flag1 = this.mouseState.RightButton == ButtonState.Pressed && this.prevMouse.RightButton == ButtonState.Released;
      bool flag2 = this.mouseState.LeftButton == ButtonState.Pressed && this.prevMouse.LeftButton == ButtonState.Released;
      bool flag3 = this.mouseState.LeftButton == ButtonState.Pressed;
      bool flag4 = this.mouseState.MiddleButton == ButtonState.Pressed && this.prevMouse.MiddleButton == ButtonState.Released;
      bool flag5 = this.mouseState.XButton1 == ButtonState.Pressed && this.prevMouse.XButton1 == ButtonState.Released;
      bool flag6 = this.mouseState.XButton2 == ButtonState.Pressed && this.prevMouse.XButton2 == ButtonState.Released;
      if (this.delayinput)
      {
        this.prevMouse = this.mouseState;
        this.prevKey = this.keyState;
        this.prevstate = this.gamestate;
        flag1 = false;
        flag2 = false;
        flag4 = false;
        flag5 = false;
        flag6 = false;
      }
      if (this.choice == "restart")
      {
        if (!flag1 && !input.IsMenuCancel(this.ControllingPlayer, out this.playerIndex) && (!flag2 || this.myIndex != 3))
        {
          if (!input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex) && (!flag2 || this.myIndex != 2))
          {
            if (!input.IsMenuLeft(this.ControllingPlayer) && (!flag2 || this.myIndex != 0))
            {
              if (input.IsMenuRight(this.ControllingPlayer) || flag2 && this.myIndex == 1)
              {
                ++this.updownIndex;
                if (!this.sc.cheat_skipday && this.updownIndex > (int) this.sc.maxDay() + 1)
                  this.updownIndex = 1;
                if (this.updownIndex > 101)
                  this.updownIndex = 1;
                if (this.updownIndex < 1)
                  this.updownIndex = 101;
                this.jot.Play(this.sc.ev * 0.5f, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
              }
            }
            else
            {
              --this.updownIndex;
              if (!this.sc.cheat_skipday && this.updownIndex < 1)
                this.updownIndex = Math.Max((int) this.sc.maxDay() + 1, 1);
              if (this.updownIndex > 101)
                this.updownIndex = 1;
              if (this.updownIndex < 1)
                this.updownIndex = 101;
              this.jot.Play(this.sc.ev * 0.5f, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
            }
          }
          else
          {
            this.sc.currentDay = this.updownIndex;
            if (this.Accepted != null)
              this.Accepted((object) this, new PlayerIndexEventArgs(this.playerIndex));
            this.ExitScreen();
          }
        }
        else
        {
          if (this.Cancelled != null)
            this.Cancelled((object) this, new PlayerIndexEventArgs(this.playerIndex));
          this.ExitScreen();
        }
      }
      if (this.choice == "kicks")
      {
        if (!flag1 && !input.IsMenuCancel(this.ControllingPlayer, out this.playerIndex))
        {
          if (flag2 && this.myIndex == 0 || input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex) && this.updownIndex == 0)
          {
            if (this.sc.kickplayerID.Count >= 5)
            {
              this.sc.kickID = this.sc.kickplayerID[4];
              string str = this.sc.kickplayerName[4];
              this.sc.kickplayerID.Clear();
              this.sc.kickplayerName.Clear();
              this.sc.kickplayerName.Add(str);
              this.sc.kickplayerID.Add(this.sc.kickID);
              if (this.Accepted != null)
                this.Accepted((object) this, new PlayerIndexEventArgs(this.playerIndex));
              this.ExitScreen();
            }
            else
              this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
          }
          else if (flag2 && this.myIndex == 1 || input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex) && this.updownIndex == 1)
          {
            if (this.sc.kickplayerID.Count >= 4)
            {
              this.sc.kickID = this.sc.kickplayerID[3];
              string str = this.sc.kickplayerName[3];
              this.sc.kickplayerID.Clear();
              this.sc.kickplayerName.Clear();
              this.sc.kickplayerName.Add(str);
              this.sc.kickplayerID.Add(this.sc.kickID);
              if (this.Accepted != null)
                this.Accepted((object) this, new PlayerIndexEventArgs(this.playerIndex));
              this.ExitScreen();
            }
            else
              this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
          }
          else if (flag2 && this.myIndex == 2 || input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex) && this.updownIndex == 2)
          {
            if (this.sc.kickplayerID.Count >= 3)
            {
              this.sc.kickID = this.sc.kickplayerID[2];
              string str = this.sc.kickplayerName[2];
              this.sc.kickplayerID.Clear();
              this.sc.kickplayerName.Clear();
              this.sc.kickplayerName.Add(str);
              this.sc.kickplayerID.Add(this.sc.kickID);
              this.sc.abort.Play(1f, -1f, -1f);
              if (this.Accepted != null)
                this.Accepted((object) this, new PlayerIndexEventArgs(this.playerIndex));
              this.ExitScreen();
            }
            else
              this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
          }
          else if (flag2 && this.myIndex == 3 || input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex) && this.updownIndex == 3)
          {
            if (this.sc.kickplayerID.Count >= 2)
            {
              this.sc.kickID = this.sc.kickplayerID[1];
              string str = this.sc.kickplayerName[1];
              this.sc.kickplayerID.Clear();
              this.sc.kickplayerName.Clear();
              this.sc.kickplayerName.Add(str);
              this.sc.kickplayerID.Add(this.sc.kickID);
              this.sc.abort.Play(1f, 1f, 1f);
              if (this.Accepted != null)
                this.Accepted((object) this, new PlayerIndexEventArgs(this.playerIndex));
              this.ExitScreen();
            }
            else
              this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
          }
          else if (flag2 && this.myIndex == 4 || input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex) && this.updownIndex == 4)
          {
            if (this.sc.kickplayerID.Count >= 1)
            {
              this.sc.kickID = this.sc.kickplayerID[0];
              string str = this.sc.kickplayerName[0];
              this.sc.kickplayerID.Clear();
              this.sc.kickplayerName.Clear();
              this.sc.kickplayerName.Add(str);
              this.sc.kickplayerID.Add(this.sc.kickID);
              if (this.Accepted != null)
                this.Accepted((object) this, new PlayerIndexEventArgs(this.playerIndex));
              this.ExitScreen();
            }
            else
              this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
          }
          else if (input.IsMenuUp(this.ControllingPlayer))
          {
            --this.updownIndex;
            if (this.updownIndex < 0)
              this.updownIndex = 4;
            this.jot.Play(this.sc.ev * 0.5f, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
          }
          else if (input.IsMenuDown(this.ControllingPlayer))
          {
            ++this.updownIndex;
            if (this.updownIndex > 4)
              this.updownIndex = 0;
            this.jot.Play(this.sc.ev * 0.5f, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
          }
        }
        else
        {
          if (this.Cancelled != null)
            this.Cancelled((object) this, new PlayerIndexEventArgs(this.playerIndex));
          this.ExitScreen();
        }
      }
      if (this.choice == "options")
      {
        if (!flag1 && !input.IsMenuCancel(this.ControllingPlayer, out this.playerIndex))
        {
          if (flag2 && this.myIndex == 0 || input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex) && this.updownIndex == 0)
          {
            walletBoxBB screen = new walletBoxBB("audio");
            screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
            {
              this.hideMenu = false;
              this.rampIN = 1f;
              this.cashout.Play(this.sc.ev * 0.9f, 0.0f, 0.0f);
            });
            screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
            {
              this.hideMenu = false;
              this.rampIN = 1f;
              this.delayinput = true;
            });
            this.ScreenManager.AddScreen((GameScreen) screen, new PlayerIndex?(this.playerIndex));
          }
          else if (flag2 && this.myIndex == 1 || input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex) && this.updownIndex == 1)
          {
            walletBoxBB screen = new walletBoxBB("video");
            screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
            {
              this.hideMenu = false;
              this.sc.showVideoSetup = false;
              this.sc.resetColors();
              this.rampIN = 1f;
              this.cashout.Play(this.sc.ev * 0.9f, 0.0f, 0.0f);
            });
            screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
            {
              this.hideMenu = false;
              this.sc.showVideoSetup = false;
              this.sc.resetColors();
              this.rampIN = 1f;
              this.delayinput = true;
            });
            this.ScreenManager.AddScreen((GameScreen) screen, new PlayerIndex?(this.playerIndex));
            this.hideMenu = true;
            this.sc.showVideoSetup = true;
          }
          else if (flag2 && this.myIndex == 2 || input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex) && this.updownIndex == 2)
          {
            walletBoxBB screen = new walletBoxBB("game");
            screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
            {
              this.hideMenu = false;
              this.rampIN = 1f;
              this.cashout.Play(this.sc.ev * 0.9f, 0.0f, 0.0f);
            });
            screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
            {
              this.hideMenu = false;
              this.rampIN = 1f;
              this.cashout.Play(this.sc.ev * 0.7f, 0.0f, 0.0f);
              this.delayinput = true;
            });
            this.ScreenManager.AddScreen((GameScreen) screen, new PlayerIndex?(this.playerIndex));
          }
          else if (input.IsMenuUp(this.ControllingPlayer))
          {
            --this.updownIndex;
            if (this.updownIndex < 0)
              this.updownIndex = 2;
            this.jot.Play(this.sc.ev * 0.5f, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
          }
          else if (input.IsMenuDown(this.ControllingPlayer))
          {
            ++this.updownIndex;
            if (this.updownIndex > 2)
              this.updownIndex = 0;
            this.jot.Play(this.sc.ev * 0.5f, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
          }
        }
        else
        {
          if (this.Cancelled != null)
            this.Cancelled((object) this, new PlayerIndexEventArgs(this.playerIndex));
          this.ExitScreen();
        }
      }
      if (this.choice == "audio")
      {
        if (!flag1 && !input.IsMenuCancel(this.ControllingPlayer, out this.playerIndex))
        {
          if (flag2 && this.myIndex == 3 || input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex))
          {
            this.sc.mv = (float) (this.slider1 * this.slider1) / 100f;
            this.sc.ev = (float) (this.slider2 * this.slider2) / 100f;
            this.sc.vv = (float) (this.slider3 * this.slider3) / 100f;
            this.sc.SavePrefs();
            if (this.Accepted != null)
              this.Accepted((object) this, new PlayerIndexEventArgs(this.playerIndex));
            this.ExitScreen();
          }
        }
        else
        {
          if (this.Cancelled != null)
            this.Cancelled((object) this, new PlayerIndexEventArgs(this.playerIndex));
          this.ExitScreen();
        }
        if (this.sc.usingMouse)
        {
          if (this.myIndex == 0)
          {
            if (flag2)
            {
              this.origMouseX = this.adjustMouse().X;
              this.float_0 = this.sliderbox1;
            }
            if (flag3)
            {
              this.sliderbox1 = this.float_0 + (this.adjustMouse().X - this.origMouseX);
              this.sliderbox1 = MathHelper.Clamp(this.sliderbox1, -84f, 84f);
              if (this.slider1 != (int) (((double) this.sliderbox1 + 84.0) / 16.799999237060547))
                this.sc.tick.Play(0.8f, MathHelper.Clamp((float) ((double) this.slider1 / 10.0 - 0.5), -1f, 1f), 0.0f);
              this.slider1 = (int) (((double) this.sliderbox1 + 84.0) / 16.799999237060547);
              this.sc.mv = (float) (this.slider1 * this.slider1) / 100f;
            }
          }
          if (this.myIndex == 1)
          {
            if (flag2)
            {
              this.origMouseX = this.adjustMouse().X;
              this.float_1 = this.sliderbox2;
            }
            if (flag3)
            {
              this.sliderbox2 = this.float_1 + (this.adjustMouse().X - this.origMouseX);
              this.sliderbox2 = MathHelper.Clamp(this.sliderbox2, -84f, 84f);
              if (this.slider2 != (int) (((double) this.sliderbox2 + 84.0) / 16.799999237060547))
                this.sc.tick.Play(0.8f, MathHelper.Clamp((float) ((double) this.slider2 / 10.0 - 0.5), -1f, 1f), 0.0f);
              this.slider2 = (int) (((double) this.sliderbox2 + 84.0) / 16.799999237060547);
              this.sc.ev = (float) (this.slider2 * this.slider2) / 100f;
            }
          }
          if (this.myIndex == 2)
          {
            if (flag2)
            {
              this.origMouseX = this.adjustMouse().X;
              this.float_2 = this.sliderbox3;
            }
            if (flag3)
            {
              this.sliderbox3 = this.float_2 + (this.adjustMouse().X - this.origMouseX);
              this.sliderbox3 = MathHelper.Clamp(this.sliderbox3, -84f, 84f);
              if (this.slider3 != (int) (((double) this.sliderbox3 + 84.0) / 16.799999237060547))
                this.sc.tick.Play(0.8f, MathHelper.Clamp((float) ((double) this.slider3 / 10.0 - 0.5), -1f, 1f), 0.0f);
              this.slider3 = (int) (((double) this.sliderbox3 + 84.0) / 16.799999237060547);
              this.sc.vv = (float) (this.slider3 * this.slider3) / 100f;
            }
          }
        }
        if (!this.sc.usingMouse)
        {
          if (input.IsMenuUp(this.ControllingPlayer))
          {
            --this.updownIndex;
            if (this.updownIndex < 0)
              this.updownIndex = 2;
            this.jot.Play(this.sc.ev * 0.5f, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
          }
          else if (input.IsMenuDown(this.ControllingPlayer))
          {
            ++this.updownIndex;
            if (this.updownIndex > 2)
              this.updownIndex = 0;
            this.jot.Play(this.sc.ev * 0.5f, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
          }
          else if (input.IsMenuRight(this.ControllingPlayer))
          {
            if (this.updownIndex == 0)
            {
              ++this.slider1;
              if (this.slider1 > 10)
                this.slider1 = 10;
              else
                this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
              this.sc.mv = (float) (this.slider1 * this.slider1) / 100f;
            }
            if (this.updownIndex == 1)
            {
              ++this.slider2;
              if (this.slider2 > 10)
                this.slider2 = 10;
              else
                this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
              this.sc.ev = (float) (this.slider2 * this.slider2) / 100f;
            }
            if (this.updownIndex == 2)
            {
              ++this.slider3;
              if (this.slider3 > 10)
                this.slider3 = 10;
              else
                this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
              this.sc.vv = (float) (this.slider3 * this.slider3) / 100f;
            }
          }
          else if (input.IsMenuLeft(this.ControllingPlayer))
          {
            if (this.updownIndex == 0)
            {
              --this.slider1;
              if (this.slider1 < 0)
                this.slider1 = 0;
              else
                this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
              this.sc.mv = (float) (this.slider1 * this.slider1) / 100f;
            }
            if (this.updownIndex == 1)
            {
              --this.slider2;
              if (this.slider2 < 0)
                this.slider2 = 0;
              else
                this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
              this.sc.ev = (float) (this.slider2 * this.slider2) / 100f;
            }
            if (this.updownIndex == 2)
            {
              --this.slider3;
              if (this.slider3 < 0)
                this.slider3 = 0;
              else
                this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
              this.sc.vv = (float) (this.slider3 * this.slider3) / 100f;
            }
          }
        }
      }
      if (this.choice == "video")
      {
        if (this.gamestate.Buttons.RightShoulder == ButtonState.Pressed || this.keyState.IsKeyDown(Keys.OemCloseBrackets))
        {
          ++this.sc.brightness;
          if (this.sc.brightness > 230)
            this.sc.brightness = 230;
          this.sliderbox1 = (float) ((double) this.sc.brightness * 0.65880000591278076 - 84.0);
          this.sliderbox2 = (float) ((double) this.sc.contrast * 0.65880000591278076 - 84.0);
        }
        if (this.gamestate.Buttons.LeftShoulder == ButtonState.Pressed || this.keyState.IsKeyDown(Keys.OemOpenBrackets))
        {
          --this.sc.brightness;
          if (this.sc.brightness < 25)
            this.sc.brightness = 25;
          this.sliderbox1 = (float) ((double) this.sc.brightness * 0.65880000591278076 - 84.0);
          this.sliderbox2 = (float) ((double) this.sc.contrast * 0.65880000591278076 - 84.0);
        }
        if ((double) this.gamestate.Triggers.Right > 0.0 || this.keyState.IsKeyDown(Keys.OemQuotes))
        {
          ++this.sc.contrast;
          if (this.sc.contrast > 230)
            this.sc.contrast = 230;
          this.sliderbox1 = (float) ((double) this.sc.brightness * 0.65880000591278076 - 84.0);
          this.sliderbox2 = (float) ((double) this.sc.contrast * 0.65880000591278076 - 84.0);
        }
        if ((double) this.gamestate.Triggers.Left > 0.0 || this.keyState.IsKeyDown(Keys.OemSemicolon))
        {
          --this.sc.contrast;
          if (this.sc.contrast < 25)
            this.sc.contrast = 25;
          this.sliderbox1 = (float) ((double) this.sc.brightness * 0.65880000591278076 - 84.0);
          this.sliderbox2 = (float) ((double) this.sc.contrast * 0.65880000591278076 - 84.0);
        }
        if (this.sc.usingMouse)
        {
          if (this.myIndex == 0)
          {
            if (flag2)
            {
              this.origMouseX = this.adjustMouse().X;
              this.float_0 = this.sliderbox1;
            }
            if (flag3)
            {
              this.sliderbox1 = this.float_0 + (this.adjustMouse().X - this.origMouseX);
              this.sliderbox1 = MathHelper.Clamp(this.sliderbox1, -84f, 84f);
              if (this.slider1 != (int) (((double) this.sliderbox1 + 84.0) / 0.65880000591278076))
                this.sc.tick.Play(0.8f, MathHelper.Clamp(this.sliderbox1 / 80f, -1f, 1f), 0.0f);
              this.slider1 = (int) (((double) this.sliderbox1 + 84.0) / 0.65880000591278076);
              this.sc.brightness = (int) MathHelper.Clamp((float) this.slider1, 25f, 230f);
            }
          }
          if (this.myIndex == 1)
          {
            if (flag2)
            {
              this.origMouseX = this.adjustMouse().X;
              this.float_1 = this.sliderbox2;
            }
            if (flag3)
            {
              this.sliderbox2 = this.float_1 + (this.adjustMouse().X - this.origMouseX);
              this.sliderbox2 = MathHelper.Clamp(this.sliderbox2, -84f, 84f);
              if (this.slider2 != (int) (((double) this.sliderbox2 + 84.0) / 0.65880000591278076))
                this.sc.tick.Play(0.8f, MathHelper.Clamp(this.sliderbox2 / 80f, -1f, 1f), 0.0f);
              this.slider2 = (int) (((double) this.sliderbox2 + 84.0) / 0.65880000591278076);
              this.sc.contrast = (int) MathHelper.Clamp((float) this.slider2, 25f, 230f);
            }
          }
          if (this.myIndex == 5)
          {
            this.updownIndex = 0;
            if (flag2)
            {
              this.origMouseXY = this.adjustMouse2();
              this.origPlaque = this.sc.hud_enemy;
            }
            if (flag3)
              this.sc.hud_enemy = this.origPlaque + (this.adjustMouse2() - this.origMouseXY);
          }
          if (this.myIndex == 6)
          {
            this.updownIndex = 1;
            if (flag2)
            {
              this.origMouseXY = this.adjustMouse2();
              this.origPlaque = this.sc.hud_clock;
            }
            if (flag3)
              this.sc.hud_clock = this.origPlaque + (this.adjustMouse2() - this.origMouseXY);
          }
          if (this.myIndex == 7)
          {
            this.updownIndex = 2;
            if (flag2)
            {
              this.origMouseXY = this.adjustMouse2();
              this.origPlaque = this.sc.hud_day;
            }
            if (flag3)
              this.sc.hud_day = this.origPlaque + (this.adjustMouse2() - this.origMouseXY);
          }
          if (this.myIndex == 8)
          {
            this.updownIndex = 3;
            if (flag2)
            {
              this.origMouseXY = this.adjustMouse2();
              this.origPlaque = this.sc.hud_weapons;
            }
            if (flag3)
              this.sc.hud_weapons = this.origPlaque + (this.adjustMouse2() - this.origMouseXY);
          }
          if (this.myIndex == 9)
          {
            this.updownIndex = 4;
            if (flag2)
            {
              this.origMouseXY = this.adjustMouse2();
              this.origPlaque = this.sc.hud_dpad;
            }
            if (flag3)
              this.sc.hud_dpad = this.origPlaque + (this.adjustMouse2() - this.origMouseXY);
          }
          if (this.myIndex == 10)
          {
            this.updownIndex = 5;
            if (flag2)
            {
              this.origMouseXY = this.adjustMouse2();
              this.origPlaque = this.sc.hud_player1;
            }
            if (flag3)
              this.sc.hud_player1 = this.origPlaque + (this.adjustMouse2() - this.origMouseXY);
          }
          if (this.myIndex == 11)
          {
            this.updownIndex = 6;
            if (flag2)
            {
              this.origMouseXY = this.adjustMouse2();
              this.origPlaque = this.sc.hud_player2;
            }
            if (flag3)
              this.sc.hud_player2 = this.origPlaque + (this.adjustMouse2() - this.origMouseXY);
          }
        }
        if (flag1 || input.IsMenuCancel(this.ControllingPlayer, out this.playerIndex))
        {
          if (this.Cancelled != null)
            this.Cancelled((object) this, new PlayerIndexEventArgs(this.playerIndex));
          this.ExitScreen();
        }
        if ((!flag2 || this.myIndex != 4) && !input.IsNewButtonPress(Buttons.A, this.ControllingPlayer, out this.playerIndex) && !input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex))
        {
          if ((!flag2 || this.myIndex != 3) && !input.IsNewButtonPress(Buttons.X, this.ControllingPlayer, out this.playerIndex) && (!this.keyState.IsKeyDown(Keys.X) || !this.prevKey.IsKeyUp(Keys.X)))
          {
            if (flag2 && this.myIndex == 2 || input.IsNewButtonPress(Buttons.Y, this.ControllingPlayer, out this.playerIndex) || this.keyState.IsKeyDown(Keys.Y) && this.prevKey.IsKeyUp(Keys.Y))
            {
              ++this.updownIndex;
              if (this.updownIndex > 6)
                this.updownIndex = 0;
            }
          }
          else
          {
            this.sc.resetVideo();
            this.sliderbox1 = (float) ((double) this.sc.brightness * 0.65880000591278076 - 84.0);
            this.sliderbox2 = (float) ((double) this.sc.contrast * 0.65880000591278076 - 84.0);
          }
        }
        else
        {
          this.sc.SavePrefs();
          if (this.Accepted != null)
            this.Accepted((object) this, new PlayerIndexEventArgs(this.playerIndex));
          this.ExitScreen();
        }
        Vector2 vector2;
        if ((this.keyState.IsKeyDown(Keys.Left) || this.keyState.IsKeyDown(Keys.Right) || this.keyState.IsKeyDown(Keys.Up) ? 1 : (this.keyState.IsKeyDown(Keys.Down) ? 1 : 0)) == 0)
        {
          vector2 = this.gamestate.ThumbSticks.Right;
          if ((double) vector2.Length() <= 0.05000000074505806 && (double) this.gamestate.ThumbSticks.Left.Length() <= 0.05000000074505806)
            goto label_272;
        }
        float num1 = (float) ((double) this.gamestate.ThumbSticks.Right.X * (double) this.gamestate.ThumbSticks.Right.X * (double) Math.Sign(this.gamestate.ThumbSticks.Right.X) * 5.0);
        double y2 = (double) this.gamestate.ThumbSticks.Right.Y;
        GamePadThumbSticks thumbSticks = this.gamestate.ThumbSticks;
        double y3 = (double) thumbSticks.Right.Y;
        double num2 = y2 * y3;
        thumbSticks = this.gamestate.ThumbSticks;
        double num3 = (double) Math.Sign(thumbSticks.Right.Y);
        float num4 = (float) (num2 * num3 * 5.0);
        if (this.keyState.IsKeyDown(Keys.Left))
          num1 -= 2f;
        if (this.keyState.IsKeyDown(Keys.Right))
          num1 += 2f;
        if (this.keyState.IsKeyDown(Keys.Up))
          num4 += 2f;
        if (this.keyState.IsKeyDown(Keys.Down))
          num4 -= 2f;
        thumbSticks = this.gamestate.ThumbSticks;
        vector2 = thumbSticks.Left;
        if ((double) vector2.Length() > 0.05000000074505806)
        {
          thumbSticks = this.gamestate.ThumbSticks;
          double x1 = (double) thumbSticks.Left.X;
          thumbSticks = this.gamestate.ThumbSticks;
          double x2 = (double) thumbSticks.Left.X;
          double num5 = x1 * x2;
          thumbSticks = this.gamestate.ThumbSticks;
          double num6 = (double) Math.Sign(thumbSticks.Left.X);
          num1 = (float) (num5 * num6 * 5.0);
          thumbSticks = this.gamestate.ThumbSticks;
          double y4 = (double) thumbSticks.Left.Y;
          thumbSticks = this.gamestate.ThumbSticks;
          double y5 = (double) thumbSticks.Left.Y;
          double num7 = y4 * y5;
          thumbSticks = this.gamestate.ThumbSticks;
          double num8 = (double) Math.Sign(thumbSticks.Left.Y);
          num4 = (float) (num7 * num8 * 5.0);
        }
        if (this.updownIndex == 0)
        {
          this.sc.hud_enemy.X += num1;
          this.sc.hud_enemy.Y -= num4;
        }
        if (this.updownIndex == 1)
        {
          this.sc.hud_clock.X += num1;
          this.sc.hud_clock.Y -= num4;
        }
        if (this.updownIndex == 2)
        {
          this.sc.hud_day.X += num1;
          this.sc.hud_day.Y -= num4;
        }
        if (this.updownIndex == 3)
        {
          this.sc.hud_weapons.X += num1;
          this.sc.hud_weapons.Y -= num4;
        }
        if (this.updownIndex == 4)
        {
          this.sc.hud_dpad.X += num1;
          this.sc.hud_dpad.Y -= num4;
        }
        if (this.updownIndex == 5)
        {
          this.sc.hud_player1.X += num1;
          this.sc.hud_player1.Y -= num4;
        }
        if (this.updownIndex == 6)
        {
          this.sc.hud_player2.X += num1;
          this.sc.hud_player2.Y -= num4;
        }
      }
label_272:
      if (this.choice == "game")
      {
        if (!flag1 && !input.IsMenuCancel(this.ControllingPlayer, out this.playerIndex))
        {
          if (flag2 && this.myIndex == 5 || input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex))
          {
            if (this.slider1 == 0)
              this.sc.pad_invertY = 1f;
            if (this.slider1 == 1)
              this.sc.pad_invertY = -1f;
            if (this.slider2 == 1)
              this.sc.pad_sensitivity = 3.5f;
            if (this.slider2 == 2)
              this.sc.pad_sensitivity = 2.5f;
            if (this.slider2 == 3)
              this.sc.pad_sensitivity = 2f;
            if (this.slider2 == 4)
              this.sc.pad_sensitivity = 1.5f;
            if (this.slider2 == 5)
              this.sc.pad_sensitivity = 1f;
            if (this.slider2 == 6)
              this.sc.pad_sensitivity = 0.76f;
            if (this.slider2 == 7)
              this.sc.pad_sensitivity = 0.5f;
            if (this.slider2 == 8)
              this.sc.pad_sensitivity = 0.25f;
            if (this.slider3 == 0)
              this.sc.pad_vibro = false;
            if (this.slider3 == 1)
              this.sc.pad_vibro = true;
            if (this.slider5 == 0)
              this.sc.pad_togglesprint = false;
            if (this.slider5 == 1)
              this.sc.pad_togglesprint = true;
            this.sc.df = this.slider4;
            this.sc.SavePrefs();
            if (this.Accepted != null)
              this.Accepted((object) this, new PlayerIndexEventArgs(this.playerIndex));
            this.ExitScreen();
          }
        }
        else
        {
          if (this.Cancelled != null)
            this.Cancelled((object) this, new PlayerIndexEventArgs(this.playerIndex));
          if (this.slider1 == 0)
            this.sc.pad_invertY = 1f;
          if (this.slider1 == 1)
            this.sc.pad_invertY = -1f;
          if (this.slider2 == 1)
            this.sc.pad_sensitivity = 3.5f;
          if (this.slider2 == 2)
            this.sc.pad_sensitivity = 2.5f;
          if (this.slider2 == 3)
            this.sc.pad_sensitivity = 2f;
          if (this.slider2 == 4)
            this.sc.pad_sensitivity = 1.5f;
          if (this.slider2 == 5)
            this.sc.pad_sensitivity = 1f;
          if (this.slider2 == 6)
            this.sc.pad_sensitivity = 0.76f;
          if (this.slider2 == 7)
            this.sc.pad_sensitivity = 0.5f;
          if (this.slider2 == 8)
            this.sc.pad_sensitivity = 0.25f;
          if (this.slider3 == 0)
            this.sc.pad_vibro = false;
          if (this.slider3 == 1)
            this.sc.pad_vibro = true;
          if (this.slider5 == 0)
            this.sc.pad_togglesprint = false;
          if (this.slider5 == 1)
            this.sc.pad_togglesprint = true;
          this.sc.df = this.slider4;
          this.sc.SavePrefs();
          this.ExitScreen();
        }
        if (this.sc.usingMouse && this.myIndex != 5)
        {
          if (flag2)
          {
            if (this.myIndex == 0)
            {
              ++this.slider1;
              if (this.slider1 > 1)
                this.slider1 = 0;
              this.drip.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.myIndex == 1)
            {
              ++this.slider2;
              if (this.slider2 > 8)
                this.slider2 = 1;
              this.drip.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.myIndex == 2)
            {
              ++this.slider3;
              if (this.slider3 > 1)
                this.slider3 = 0;
              this.drip.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.myIndex == 3)
            {
              ++this.slider5;
              if (this.slider5 > 1)
                this.slider5 = 0;
              this.drip.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.myIndex == 4)
            {
              ++this.slider4;
              if (this.slider4 > 2)
                this.slider4 = 0;
              this.drip.Play(this.sc.ev, 0.0f, 0.0f);
            }
          }
        }
        else if (input.IsMenuUp(this.ControllingPlayer))
        {
          --this.updownIndex;
          if (this.updownIndex < 0)
            this.updownIndex = 4;
          this.jot.Play(this.sc.ev * 0.5f, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
        }
        else if (input.IsMenuDown(this.ControllingPlayer))
        {
          ++this.updownIndex;
          if (this.updownIndex > 4)
            this.updownIndex = 0;
          this.jot.Play(this.sc.ev * 0.5f, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
        }
        else if (input.IsMenuRight(this.ControllingPlayer))
        {
          if (this.updownIndex == 0)
          {
            ++this.slider1;
            if (this.slider1 > 1)
              this.slider1 = 1;
            else
              this.drip.Play(this.sc.ev, 0.0f, 0.0f);
          }
          if (this.updownIndex == 1)
          {
            ++this.slider2;
            if (this.slider2 > 8)
              this.slider2 = 8;
            else
              this.drip.Play(this.sc.ev, 0.0f, 0.0f);
          }
          if (this.updownIndex == 2)
          {
            ++this.slider3;
            if (this.slider3 > 1)
              this.slider3 = 1;
            else
              this.drip.Play(this.sc.ev, 0.0f, 0.0f);
          }
          if (this.updownIndex == 3)
          {
            ++this.slider5;
            if (this.slider5 > 1)
              this.slider5 = 1;
            else
              this.drip.Play(this.sc.ev, 0.0f, 0.0f);
          }
          if (this.updownIndex == 4)
          {
            ++this.slider4;
            if (this.slider4 > 2)
              this.slider4 = 2;
            else
              this.drip.Play(this.sc.ev, 0.0f, 0.0f);
          }
        }
        else if (input.IsMenuLeft(this.ControllingPlayer))
        {
          if (this.updownIndex == 0)
          {
            --this.slider1;
            if (this.slider1 < 0)
              this.slider1 = 0;
            else
              this.drip.Play(this.sc.ev, -0.2f, 0.0f);
          }
          if (this.updownIndex == 1)
          {
            --this.slider2;
            if (this.slider2 < 1)
              this.slider2 = 1;
            else
              this.drip.Play(this.sc.ev, -0.2f, 0.0f);
          }
          if (this.updownIndex == 2)
          {
            --this.slider3;
            if (this.slider3 < 0)
              this.slider3 = 0;
            else
              this.drip.Play(this.sc.ev, -0.2f, 0.0f);
          }
          if (this.updownIndex == 3)
          {
            --this.slider5;
            if (this.slider5 < 0)
              this.slider5 = 0;
            else
              this.drip.Play(this.sc.ev, -0.2f, 0.0f);
          }
          if (this.updownIndex == 4)
          {
            --this.slider4;
            if (this.slider4 < 0)
              this.slider4 = 0;
            else
              this.drip.Play(this.sc.ev, -0.2f, 0.0f);
          }
        }
      }
      if (this.choice == "help")
      {
        if (this.sc.usingMouse)
        {
          if (flag2 && this.myIndex == 0)
          {
            this.sc.LoadSpaceKeys();
            walletBoxBB screen = new walletBoxBB("rebind");
            screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
            screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
            this.ScreenManager.AddScreen((GameScreen) screen, new PlayerIndex?(this.playerIndex));
            this.delayinput = true;
          }
          if (flag2 && this.myIndex == 1)
          {
            walletBoxBB screen = new walletBoxBB("hotkeys");
            screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
            screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
            this.ScreenManager.AddScreen((GameScreen) screen, new PlayerIndex?(this.playerIndex));
            this.delayinput = true;
          }
        }
        if (!this.sc.usingMouse)
        {
          if (input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex) && this.updownIndex == 0)
          {
            walletBoxBB screen = new walletBoxBB("instructions");
            screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => { });
            screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => { });
            this.ScreenManager.AddScreen((GameScreen) screen, new PlayerIndex?(this.playerIndex));
          }
          if (input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex) && this.updownIndex == 1)
          {
            walletBoxBB screen = new walletBoxBB("controller");
            screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => { });
            screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => { });
            this.ScreenManager.AddScreen((GameScreen) screen, new PlayerIndex?(this.playerIndex));
          }
        }
        if (input.IsMenuUp(this.ControllingPlayer))
        {
          --this.updownIndex;
          if (this.updownIndex < 0)
            this.updownIndex = 1;
          this.jot.Play(this.sc.ev * 0.5f, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
        }
        if (input.IsMenuDown(this.ControllingPlayer))
        {
          ++this.updownIndex;
          if (this.updownIndex > 1)
            this.updownIndex = 0;
          this.jot.Play(this.sc.ev * 0.5f, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
        }
      }
      if (this.choice == "rebind")
      {
        if (this.keyState.IsKeyDown(Keys.Left) && this.prevKey.IsKeyUp(Keys.Left))
          this.sc.ar1 -= 0.01f;
        if (this.keyState.IsKeyDown(Keys.Right) && this.prevKey.IsKeyUp(Keys.Right))
          this.sc.ar1 += 0.01f;
        if (this.keyState.IsKeyDown(Keys.Up) && this.prevKey.IsKeyUp(Keys.Up))
          this.sc.ar2 += 0.01f;
        if (this.keyState.IsKeyDown(Keys.Down) && this.prevKey.IsKeyUp(Keys.Down))
          this.sc.ar2 -= 0.01f;
        Keys[] pressedKeys = this.keyState.GetPressedKeys();
        if (this.thisKEY != 0 && (flag2 || flag1 || flag4 || flag5 || flag6) && this.thisKEY == this.whichKEY)
        {
          Keys keys = Keys.VolumeUp;
          if (flag2)
            keys = Keys.VolumeDown;
          if (flag1)
            keys = Keys.VolumeUp;
          if (flag4)
            keys = Keys.VolumeMute;
          if (flag5)
            keys = Keys.Print;
          if (flag6)
            keys = Keys.PrintScreen;
          if (this.thisKEY == 9)
          {
            this.sc.space_key = keys;
            this.thisKEY = 0;
          }
          if (this.thisKEY == 7)
          {
            this.sc.a_key = keys;
            this.thisKEY = 0;
          }
          if (this.thisKEY == 8)
          {
            this.sc.d_key = keys;
            this.thisKEY = 0;
          }
          if (this.thisKEY == 5)
          {
            this.sc.w_key = keys;
            this.thisKEY = 0;
          }
          if (this.thisKEY == 6)
          {
            this.sc.s_key = keys;
            this.thisKEY = 0;
          }
          if (this.thisKEY == 10)
          {
            this.sc.leftshift_key = keys;
            this.thisKEY = 0;
          }
          if (this.thisKEY == 11)
          {
            this.sc.r_key = keys;
            this.thisKEY = 0;
          }
          if (this.thisKEY == 12)
          {
            this.sc.x_key = keys;
            this.thisKEY = 0;
          }
          if (this.thisKEY == 13)
          {
            this.sc.t_key = keys;
            this.thisKEY = 0;
          }
          if (this.thisKEY == 28)
          {
            this.sc.e_key = keys;
            this.thisKEY = 0;
          }
          if (this.thisKEY == 14)
          {
            this.sc.enter_key = keys;
            this.thisKEY = 0;
          }
          if (this.thisKEY == 23)
          {
            this.sc.tab_key = keys;
            this.thisKEY = 0;
          }
          if (this.thisKEY == 24)
          {
            this.sc.u_key = keys;
            this.thisKEY = 0;
          }
        }
        if (this.thisKEY != 0 && pressedKeys.Length > 0)
        {
          if (this.thisKEY == 1)
          {
            this.sc.escape_key = pressedKeys[0];
            this.thisKEY = 0;
          }
          if (this.thisKEY == 2)
          {
            this.sc.lmb_key = pressedKeys[0];
            this.thisKEY = 0;
          }
          if (this.thisKEY == 3)
          {
            this.sc.rmb_key = pressedKeys[0];
            this.thisKEY = 0;
          }
          if (this.thisKEY == 5)
          {
            this.sc.w_key = pressedKeys[0];
            this.thisKEY = 0;
          }
          if (this.thisKEY == 6)
          {
            this.sc.s_key = pressedKeys[0];
            this.thisKEY = 0;
          }
          if (this.thisKEY == 7)
          {
            this.sc.a_key = pressedKeys[0];
            this.thisKEY = 0;
          }
          if (this.thisKEY == 8)
          {
            this.sc.d_key = pressedKeys[0];
            this.thisKEY = 0;
          }
          if (this.thisKEY == 9)
          {
            this.sc.space_key = pressedKeys[0];
            this.thisKEY = 0;
          }
          if (this.thisKEY == 10)
          {
            this.sc.leftshift_key = pressedKeys[0];
            this.thisKEY = 0;
          }
          if (this.thisKEY == 11)
          {
            this.sc.r_key = pressedKeys[0];
            this.thisKEY = 0;
          }
          if (this.thisKEY == 12)
          {
            this.sc.x_key = pressedKeys[0];
            this.thisKEY = 0;
          }
          if (this.thisKEY == 13)
          {
            this.sc.t_key = pressedKeys[0];
            this.thisKEY = 0;
          }
          if (this.thisKEY == 14)
          {
            this.sc.enter_key = pressedKeys[0];
            this.thisKEY = 0;
          }
          if (this.thisKEY == 15)
          {
            this.sc.f1_key = pressedKeys[0];
            this.thisKEY = 0;
          }
          if (this.thisKEY == 16)
          {
            this.sc.one_key = pressedKeys[0];
            this.thisKEY = 0;
          }
          if (this.thisKEY == 17)
          {
            this.sc.two_key = pressedKeys[0];
            this.thisKEY = 0;
          }
          if (this.thisKEY == 18)
          {
            this.sc.three_key = pressedKeys[0];
            this.thisKEY = 0;
          }
          if (this.thisKEY == 19)
          {
            this.sc.four_key = pressedKeys[0];
            this.thisKEY = 0;
          }
          if (this.thisKEY == 20)
          {
            this.sc.f1_key = pressedKeys[0];
            this.thisKEY = 0;
          }
          if (this.thisKEY == 23)
          {
            this.sc.tab_key = pressedKeys[0];
            this.thisKEY = 0;
          }
          if (this.thisKEY == 24)
          {
            this.sc.u_key = pressedKeys[0];
            this.thisKEY = 0;
          }
          if (this.thisKEY == 25)
          {
            this.sc.left_key = pressedKeys[0];
            this.thisKEY = 0;
          }
          if (this.thisKEY == 26)
          {
            this.sc.right_key = pressedKeys[0];
            this.thisKEY = 0;
          }
          if (this.thisKEY == 27)
          {
            this.sc.up_key = pressedKeys[0];
            this.thisKEY = 0;
          }
          if (this.thisKEY == 28)
          {
            this.sc.e_key = pressedKeys[0];
            this.thisKEY = 0;
          }
        }
        if (flag2 && this.whichKEY == 36)
        {
          this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
          this.delayinput = true;
          if (this.Cancelled != null)
            this.Cancelled((object) this, new PlayerIndexEventArgs(this.playerIndex));
          this.ExitScreen();
        }
        if (flag2)
        {
          if (this.whichKEY == 4)
          {
            this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
            this.thisKEY = 0;
          }
          if (this.whichKEY == 30)
          {
            this.sc.SaveSpaceKeys();
            this.sc.getXkey();
            this.sc.harp2.Play(this.sc.ev * 0.4f, 0.0f, 0.0f);
            this.thisKEY = 0;
            this.delayinput = true;
            if (this.Cancelled != null)
              this.Cancelled((object) this, new PlayerIndexEventArgs(this.playerIndex));
            this.ExitScreen();
          }
          if (this.whichKEY == 33)
          {
            this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            this.thisKEY = 0;
            this.sc.rmb_key = Keys.VolumeUp;
            this.sc.lmb_key = Keys.VolumeDown;
            this.sc.mmb_key = Keys.VolumeMute;
            this.sc.but1_key = Keys.Print;
            this.sc.but2_key = Keys.PrintScreen;
            this.sc.escape_key = Keys.Escape;
            this.sc.w_key = Keys.W;
            this.sc.a_key = Keys.A;
            this.sc.s_key = Keys.S;
            this.sc.d_key = Keys.D;
            this.sc.f_key = Keys.F;
            this.sc.q_key = Keys.Q;
            this.sc.e_key = Keys.E;
            this.sc.x_key = Keys.X;
            this.sc.r_key = Keys.R;
            this.sc.up_key = Keys.Up;
            this.sc.down_key = Keys.Down;
            this.sc.left_key = Keys.Left;
            this.sc.space_key = Keys.Space;
            this.sc.one_key = Keys.D1;
            this.sc.two_key = Keys.D2;
            this.sc.three_key = Keys.D3;
            this.sc.four_key = Keys.D4;
            this.sc.tab_key = Keys.Tab;
            this.sc.f1_key = Keys.F1;
            this.sc.f2_key = Keys.F2;
            this.sc.f3_key = Keys.F3;
            this.sc.leftshift_key = Keys.LeftShift;
            this.sc.t_key = Keys.T;
            this.sc.enter_key = Keys.Enter;
          }
          this.thisKEY = this.whichKEY != 2 || this.whichKEY != 3 || this.whichKEY != 4 || this.whichKEY != 30 || this.whichKEY != 33 || this.whichKEY != 36 ? (this.thisKEY != this.whichKEY ? this.whichKEY : 0) : 0;
        }
        if (flag1 && this.whichKEY == 0)
        {
          this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
          this.delayinput = true;
          if (this.Cancelled != null)
            this.Cancelled((object) this, new PlayerIndexEventArgs(this.playerIndex));
          this.ExitScreen();
        }
        if (flag1 && this.thisKEY == 0)
          this.whichKEY = 0;
      }
      if (this.choice == "hotkeys" && (flag1 || input.IsMenuCancel(this.ControllingPlayer, out this.playerIndex)))
      {
        if (this.Cancelled != null)
          this.Cancelled((object) this, new PlayerIndexEventArgs(this.playerIndex));
        this.ExitScreen();
      }
      GamePadTriggers triggers;
      if (this.choice == "instructions")
      {
        if (!flag1 && !input.IsMenuCancel(this.ControllingPlayer, out this.playerIndex))
        {
          if (input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex))
          {
            ++this.updownIndex;
            if (this.updownIndex > 6)
            {
              this.updownIndex = 6;
            }
            else
            {
              this.jot.Play(this.sc.ev * 0.5f, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
              this.rot = (float) this.rr.Next(-30, 30) / 1000f;
            }
          }
          else if (input.IsMenuLeft(this.ControllingPlayer))
          {
            --this.updownIndex;
            if (this.updownIndex < 0)
            {
              this.updownIndex = 0;
            }
            else
            {
              this.jot.Play(this.sc.ev * 0.5f, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
              this.rot = (float) this.rr.Next(-30, 30) / 1000f;
            }
          }
          else if (input.IsMenuRight(this.ControllingPlayer))
          {
            ++this.updownIndex;
            if (this.updownIndex > 6)
            {
              this.updownIndex = 6;
            }
            else
            {
              this.jot.Play(this.sc.ev * 0.5f, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
              this.rot = (float) this.rr.Next(-30, 30) / 1000f;
            }
          }
        }
        else
        {
          this.jot.Play(this.sc.ev * 0.5f, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
          this.rot = (float) this.rr.Next(-30, 30) / 1000f;
          --this.updownIndex;
          if (this.updownIndex < 0)
          {
            this.updownIndex = 0;
            if (this.Cancelled != null)
              this.Cancelled((object) this, new PlayerIndexEventArgs(this.playerIndex));
            this.ExitScreen();
            this.rot = 0.0f;
          }
        }
        double scalerZoom = (double) this.scalerZoom;
        triggers = this.gamestate.Triggers;
        double num9 = (double) triggers.Right / 3.0;
        double num10 = scalerZoom + num9;
        triggers = this.gamestate.Triggers;
        double num11 = (double) triggers.Left / 3.0;
        this.scaler = (float) (num10 + num11);
      }
      if (this.choice == "controller")
      {
        if (flag1 || input.IsMenuCancel(this.ControllingPlayer, out this.playerIndex))
        {
          if (this.Cancelled != null)
            this.Cancelled((object) this, new PlayerIndexEventArgs(this.playerIndex));
          this.ExitScreen();
        }
        if (input.IsNewButtonPress(Buttons.A, this.ControllingPlayer, out this.playerIndex))
        {
          if (this.Accepted != null)
            this.Accepted((object) this, new PlayerIndexEventArgs(this.playerIndex));
          this.ExitScreen();
        }
        double scalerZoom = (double) this.scalerZoom;
        triggers = this.gamestate.Triggers;
        double num12 = (double) triggers.Right / 3.0;
        double num13 = scalerZoom + num12;
        triggers = this.gamestate.Triggers;
        double num14 = (double) triggers.Left / 3.0;
        this.scaler = (float) (num13 + num14);
      }
      if (this.choice == "controller2")
      {
        if (flag1 || input.IsMenuCancel(this.ControllingPlayer, out this.playerIndex))
        {
          if (this.Cancelled != null)
            this.Cancelled((object) this, new PlayerIndexEventArgs(this.playerIndex));
          this.ExitScreen();
        }
        if (input.IsNewButtonPress(Buttons.A, this.ControllingPlayer, out this.playerIndex))
        {
          if (this.Accepted != null)
            this.Accepted((object) this, new PlayerIndexEventArgs(this.playerIndex));
          this.ExitScreen();
        }
        double scalerZoom = (double) this.scalerZoom;
        triggers = this.gamestate.Triggers;
        double num15 = (double) triggers.Right / 3.0;
        double num16 = scalerZoom + num15;
        triggers = this.gamestate.Triggers;
        double num17 = (double) triggers.Left / 3.0;
        this.scaler = (float) (num16 + num17);
      }
      if (this.choice == "cheats")
      {
        this.sc.myplayerCheats = this.sc.cheat_InfiniteAmmo && this.sc.revengeDay <= 0 || this.sc.cheat_Invincible || this.sc.cheat_allweapons;
        if (!flag1 && !input.IsMenuCancel(this.ControllingPlayer, out this.playerIndex))
        {
          if (input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex))
          {
            this.cashout.Play(this.sc.ev * 0.9f, 0.0f, 0.0f);
            if (this.Accepted != null)
              this.Accepted((object) this, new PlayerIndexEventArgs(this.playerIndex));
            this.ExitScreen();
          }
        }
        else
        {
          if (this.Cancelled != null)
            this.Cancelled((object) this, new PlayerIndexEventArgs(this.playerIndex));
          this.ExitScreen();
        }
        if (this.sc.usingMouse && this.myIndex != 4 && flag2)
        {
          if (this.myIndex == 0)
          {
            ++this.slider1;
            if (this.slider1 > 1)
              this.slider1 = 0;
            this.drip.Play(this.sc.ev, 0.0f, 0.0f);
          }
          if (this.myIndex == 1)
          {
            ++this.slider2;
            if (this.slider2 > 1)
              this.slider2 = 0;
            this.drip.Play(this.sc.ev, 0.0f, 0.0f);
          }
          if (this.myIndex == 2)
          {
            ++this.slider3;
            if (this.slider3 > 1)
              this.slider3 = 0;
            this.drip.Play(this.sc.ev, 0.0f, 0.0f);
          }
          if (this.myIndex == 3)
          {
            ++this.slider4;
            if (this.slider4 > 1)
              this.slider4 = 0;
            this.drip.Play(this.sc.ev, 0.0f, 0.0f);
          }
          if (this.slider1 == 0)
            this.sc.cheat_InfiniteAmmo = false;
          if (this.slider1 == 1)
            this.sc.cheat_InfiniteAmmo = true;
          if (this.slider2 == 0)
            this.sc.cheat_Invincible = false;
          if (this.slider2 == 1)
            this.sc.cheat_Invincible = true;
          if (this.slider4 == 0)
            this.sc.cheat_skipday = false;
          if (this.slider4 == 1)
            this.sc.cheat_skipday = true;
          if (this.slider3 == 0)
            this.sc.cheat_allweapons = false;
          if (this.slider3 == 1)
            this.sc.cheat_allweapons = true;
        }
        if (!this.sc.usingMouse)
        {
          if (input.IsMenuUp(this.ControllingPlayer))
          {
            --this.updownIndex;
            if (this.updownIndex < 0)
              this.updownIndex = 3;
            this.jot.Play(this.sc.ev * 0.7f, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
          }
          else if (input.IsMenuDown(this.ControllingPlayer))
          {
            ++this.updownIndex;
            if (this.updownIndex > 3)
              this.updownIndex = 0;
            this.jot.Play(this.sc.ev * 0.7f, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
          }
          else if (input.IsMenuRight(this.ControllingPlayer))
          {
            if (this.updownIndex == 0)
            {
              ++this.slider1;
              if (this.slider1 > 1)
                this.slider1 = 1;
              else
                this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
            }
            if (this.updownIndex == 1)
            {
              ++this.slider2;
              if (this.slider2 > 1)
                this.slider2 = 1;
              else
                this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
            }
            if (this.updownIndex == 2)
            {
              ++this.slider3;
              if (this.slider3 > 1)
                this.slider3 = 1;
              else
                this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
            }
            if (this.updownIndex == 3)
            {
              ++this.slider4;
              if (this.slider4 > 1)
                this.slider4 = 1;
              else
                this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
            }
            if (this.updownIndex == 0)
              this.sc.cheat_InfiniteAmmo = true;
            if (this.updownIndex == 1)
              this.sc.cheat_Invincible = true;
            if (this.updownIndex == 3)
              this.sc.cheat_skipday = true;
            if (this.updownIndex == 2)
              this.sc.cheat_allweapons = true;
          }
          else if (input.IsMenuLeft(this.ControllingPlayer))
          {
            if (this.updownIndex == 0)
            {
              --this.slider1;
              if (this.slider1 < 0)
                this.slider1 = 0;
              else
                this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
            }
            if (this.updownIndex == 1)
            {
              --this.slider2;
              if (this.slider2 < 0)
                this.slider2 = 0;
              else
                this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
            }
            if (this.updownIndex == 2)
            {
              --this.slider3;
              if (this.slider3 < 0)
                this.slider3 = 0;
              else
                this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
            }
            if (this.updownIndex == 3)
            {
              --this.slider4;
              if (this.slider4 < 0)
                this.slider4 = 0;
              else
                this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
            }
            if (this.updownIndex == 0)
              this.sc.cheat_InfiniteAmmo = false;
            if (this.updownIndex == 1)
              this.sc.cheat_Invincible = false;
            if (this.updownIndex == 3)
              this.sc.cheat_skipday = false;
            if (this.updownIndex == 2)
              this.sc.cheat_allweapons = false;
          }
        }
      }
      if (this.choice == "hidden")
      {
        if (input.IsMenuCancel(this.ControllingPlayer, out this.playerIndex))
        {
          if (this.Cancelled != null)
            this.Cancelled((object) this, new PlayerIndexEventArgs(this.playerIndex));
          this.ExitScreen();
        }
        else if (input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex) && this.updownIndex == 0)
        {
          walletBoxBB screen = new walletBoxBB("networking");
          screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.cashout.Play(this.sc.ev * 0.9f, 0.0f, 0.0f));
          this.ScreenManager.AddScreen((GameScreen) screen, new PlayerIndex?(this.playerIndex));
        }
        else if (input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex) && this.updownIndex == 1)
        {
          walletBoxBB screen = new walletBoxBB("debugging");
          screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.cashout.Play(this.sc.ev * 0.9f, 0.2f, 0.0f));
          this.ScreenManager.AddScreen((GameScreen) screen, new PlayerIndex?(this.playerIndex));
        }
        else if (input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex) && this.updownIndex == 2)
        {
          walletBoxBB screen = new walletBoxBB("cheat mode");
          screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
          {
            if (this.CheatSent != null)
              this.CheatSent((object) this, new PlayerIndexEventArgs(this.playerIndex));
            this.ExitScreen();
          });
          this.ScreenManager.AddScreen((GameScreen) screen, new PlayerIndex?(this.playerIndex));
        }
        else if (input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex) && this.updownIndex == 3)
        {
          walletBoxBB screen = new walletBoxBB("level edit");
          screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
          {
            if (this.LevelSent != null)
              this.LevelSent((object) this, new PlayerIndexEventArgs(this.playerIndex));
            this.ExitScreen();
          });
          this.ScreenManager.AddScreen((GameScreen) screen, new PlayerIndex?(this.playerIndex));
        }
        else if (input.IsMenuUp(this.ControllingPlayer))
        {
          --this.updownIndex;
          if (this.updownIndex < 0)
            this.updownIndex = 3;
          this.jot.Play(this.sc.ev * 0.5f, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
        }
        else if (input.IsMenuDown(this.ControllingPlayer))
        {
          ++this.updownIndex;
          if (this.updownIndex > 3)
            this.updownIndex = 0;
          this.jot.Play(this.sc.ev * 0.5f, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
        }
      }
      if (this.choice == "networking")
      {
        if (input.IsMenuCancel(this.ControllingPlayer, out this.playerIndex))
        {
          if (this.Cancelled != null)
          {
            this.sc.debug_showNetwork = false;
            this.sc.networkQuality = (byte) 0;
            this.Cancelled((object) this, new PlayerIndexEventArgs(this.playerIndex));
          }
          this.ExitScreen();
        }
        else if (input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex))
        {
          if (this.Accepted != null)
          {
            if (this.slider1 == 1)
            {
              this.sc.debug_showNetwork = true;
              this.sc.networkQuality = (byte) this.slider2;
            }
            else
            {
              this.sc.networkQuality = (byte) 0;
              this.sc.debug_showNetwork = false;
            }
            this.Accepted((object) this, new PlayerIndexEventArgs(this.playerIndex));
          }
          this.ExitScreen();
        }
        else if (input.IsMenuUp(this.ControllingPlayer))
        {
          --this.updownIndex;
          if (this.updownIndex < 0)
            this.updownIndex = 2;
          this.jot.Play(this.sc.ev * 0.5f, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
        }
        else if (input.IsMenuDown(this.ControllingPlayer))
        {
          ++this.updownIndex;
          if (this.updownIndex > 2)
            this.updownIndex = 0;
          this.jot.Play(this.sc.ev * 0.5f, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
        }
        else if (input.IsMenuRight(this.ControllingPlayer))
        {
          if (this.updownIndex == 0)
          {
            ++this.slider1;
            if (this.slider1 > 1)
              this.slider1 = 1;
            else
              this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
          }
          if (this.updownIndex == 1)
          {
            ++this.slider2;
            if (this.slider2 > this.sc.lag.Length - 1)
              this.slider2 = this.sc.lag.Length - 1;
            else
              this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
          }
          if (this.updownIndex == 2)
          {
            ++this.slider2;
            if (this.slider2 > this.sc.lag.Length - 1)
              this.slider2 = this.sc.lag.Length - 1;
            else
              this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
          }
        }
        else if (input.IsMenuLeft(this.ControllingPlayer))
        {
          if (this.updownIndex == 0)
          {
            --this.slider1;
            if (this.slider1 < 0)
              this.slider1 = 0;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          if (this.updownIndex == 1)
          {
            --this.slider2;
            if (this.slider2 < 0)
              this.slider2 = 0;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          if (this.updownIndex == 2)
          {
            --this.slider2;
            if (this.slider2 < 0)
              this.slider2 = 0;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
        }
      }
      if (this.choice == "debugging")
      {
        if (input.IsMenuCancel(this.ControllingPlayer, out this.playerIndex))
        {
          if (this.Cancelled != null)
          {
            this.sc.debug_showSeed = false;
            this.sc.debug_showAccuracy = false;
            this.sc.debug_showGarbage = false;
            this.sc.debug_showHoming = false;
            this.Cancelled((object) this, new PlayerIndexEventArgs(this.playerIndex));
          }
          this.ExitScreen();
        }
        else if (input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex))
        {
          if (this.Accepted != null)
          {
            this.sc.debug_showGarbage = this.slider1 == 1;
            this.sc.debug_showSeed = this.slider2 == 1;
            this.sc.debug_showAccuracy = this.slider3 == 1;
            this.sc.debug_showHoming = this.slider4 == 1;
            this.Accepted((object) this, new PlayerIndexEventArgs(this.playerIndex));
          }
          this.ExitScreen();
        }
        else if (input.IsMenuUp(this.ControllingPlayer))
        {
          --this.updownIndex;
          if (this.updownIndex < 0)
            this.updownIndex = 3;
          this.jot.Play(this.sc.ev * 0.5f, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
        }
        else if (input.IsMenuDown(this.ControllingPlayer))
        {
          ++this.updownIndex;
          if (this.updownIndex > 3)
            this.updownIndex = 0;
          this.jot.Play(this.sc.ev * 0.5f, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
        }
        else if (input.IsMenuRight(this.ControllingPlayer))
        {
          if (this.updownIndex == 0)
          {
            ++this.slider1;
            if (this.slider1 > 1)
              this.slider1 = 1;
            else
              this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
          }
          if (this.updownIndex == 1)
          {
            ++this.slider2;
            if (this.slider2 > 1)
              this.slider2 = 1;
            else
              this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
          }
          if (this.updownIndex == 2)
          {
            ++this.slider3;
            if (this.slider2 > 1)
              this.slider2 = 1;
            else
              this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
          }
          if (this.updownIndex == 3)
          {
            ++this.slider4;
            if (this.slider4 > 1)
              this.slider4 = 1;
            else
              this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
          }
        }
        else if (input.IsMenuLeft(this.ControllingPlayer))
        {
          if (this.updownIndex == 0)
          {
            --this.slider1;
            if (this.slider1 < 0)
              this.slider1 = 0;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          if (this.updownIndex == 1)
          {
            --this.slider2;
            if (this.slider2 < 0)
              this.slider2 = 0;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          if (this.updownIndex == 2)
          {
            --this.slider3;
            if (this.slider2 < 0)
              this.slider2 = 0;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          if (this.updownIndex == 3)
          {
            --this.slider4;
            if (this.slider4 < 0)
              this.slider4 = 0;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
        }
      }
      if (this.choice == "cheat mode")
      {
        if (input.IsMenuCancel(this.ControllingPlayer, out this.playerIndex))
        {
          this.sc.cheat_SendPackage = false;
          if (this.Cancelled != null)
            this.Cancelled((object) this, new PlayerIndexEventArgs(this.playerIndex));
          this.ExitScreen();
        }
        else if (input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex))
        {
          this.sc.cheat_SendPackage = true;
          this.sc.cheat_Invincible = this.slider1 == 1;
          this.sc.cheat_FastFiring = this.slider2 == 1;
          this.sc.cheat_InfiniteAmmo = this.slider3 == 1;
          this.sc.cheat_AllExplode = this.slider4 == 1;
          if (this.slider5 == 1)
          {
            this.sc.days[100] = 1;
            this.sc.cheat_PickupPack = true;
            this.sc.bloodLevel = 600f;
          }
          else
          {
            this.sc.days[100] = 0;
            this.sc.cheat_PickupPack = false;
          }
          if (this.Accepted != null)
            this.Accepted((object) this, new PlayerIndexEventArgs(this.playerIndex));
          this.ExitScreen();
        }
        else if (input.IsMenuUp(this.ControllingPlayer))
        {
          --this.updownIndex;
          if (this.updownIndex < 0)
            this.updownIndex = 4;
          this.jot.Play(this.sc.ev * 0.5f, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
        }
        else if (input.IsMenuDown(this.ControllingPlayer))
        {
          ++this.updownIndex;
          if (this.updownIndex > 4)
            this.updownIndex = 0;
          this.jot.Play(this.sc.ev * 0.5f, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
        }
        else if (input.IsMenuRight(this.ControllingPlayer))
        {
          if (this.updownIndex == 0)
          {
            ++this.slider1;
            if (this.slider1 > 1)
              this.slider1 = 1;
            else
              this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
          }
          if (this.updownIndex == 1)
          {
            ++this.slider2;
            if (this.slider2 > 1)
              this.slider2 = 1;
            else
              this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
          }
          if (this.updownIndex == 2)
          {
            ++this.slider3;
            if (this.slider2 > 1)
              this.slider2 = 1;
            else
              this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
          }
          if (this.updownIndex == 3)
          {
            ++this.slider4;
            if (this.slider4 > 1)
              this.slider4 = 1;
            else
              this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
          }
          if (this.updownIndex == 4)
          {
            ++this.slider5;
            if (this.slider5 > 1)
              this.slider5 = 1;
            else
              this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
          }
        }
        else if (input.IsMenuLeft(this.ControllingPlayer))
        {
          if (this.updownIndex == 0)
          {
            --this.slider1;
            if (this.slider1 < 0)
              this.slider1 = 0;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          if (this.updownIndex == 1)
          {
            --this.slider2;
            if (this.slider2 < 0)
              this.slider2 = 0;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          if (this.updownIndex == 2)
          {
            --this.slider3;
            if (this.slider2 < 0)
              this.slider2 = 0;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          if (this.updownIndex == 3)
          {
            --this.slider4;
            if (this.slider4 < 0)
              this.slider4 = 0;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          if (this.updownIndex == 4)
          {
            --this.slider5;
            if (this.slider5 < 0)
              this.slider5 = 0;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
        }
      }
      if (this.choice == "level edit")
      {
        if (input.IsMenuCancel(this.ControllingPlayer, out this.playerIndex) && this.updownIndex <= 10)
        {
          this.sc.levelChange = false;
          if (this.Cancelled != null)
            this.Cancelled((object) this, new PlayerIndexEventArgs(this.playerIndex));
          this.ExitScreen();
        }
        else if (input.IsMenuCancel(this.ControllingPlayer, out this.playerIndex) && this.updownIndex >= 11)
          this.updownIndex = 0;
        else if (input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex) && this.updownIndex >= 11)
        {
          if (this.slider1 == 0)
            this.sc.newDayTime = "am";
          if (this.slider1 == 1)
            this.sc.newDayTime = "pm";
          this.sc.int_4 = this.slider2;
          this.sc.int_5 = this.slider2;
          this.sc.boarCount = this.slider3;
          this.sc.int_9 = this.slider4;
          this.sc.int_12 = this.slider4;
          this.sc.int_10 = this.slider5;
          this.sc.int_13 = this.slider5;
          this.sc.boar1MinSize = this.slider6;
          this.sc.boar2MinSize = this.slider6;
          this.sc.boar1MaxSize = this.slider7;
          this.sc.boar2MaxSize = this.slider7;
          this.sc.boar1GiantOdds = this.slider8;
          this.sc.boar2GiantOdds = this.slider8;
          this.sc.boar1TinyOdds = this.slider9;
          this.sc.boar2TinyOdds = this.slider9;
          this.sc.int_11 = this.slider10;
          this.sc.int_14 = this.slider10;
          this.sc.boar1TurnRate = this.slider11;
          this.sc.boar2TurnRate = this.slider11;
          this.sc.boarDistance[0] = this.slider12;
          this.sc.boarDistance[1] = this.slider14;
          this.sc.boarDistance[2] = this.slider16;
          this.sc.boarHomingLimit[0] = this.slider13;
          this.sc.boarHomingLimit[1] = this.slider15;
          this.sc.boarHomingLimit[2] = this.slider17;
          this.sc.levelChange = true;
          this.sc.sendlevelChange = true;
          if (this.Accepted != null)
            this.Accepted((object) this, new PlayerIndexEventArgs(this.playerIndex));
          this.ExitScreen();
        }
        else if (input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex) && this.updownIndex <= 10)
          this.updownIndex = 11;
        else if (input.IsMenuUp(this.ControllingPlayer))
        {
          --this.updownIndex;
          if (this.updownIndex < 0)
            this.updownIndex = 0;
          this.jot.Play(this.sc.ev * 0.5f, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
        }
        else if (input.IsMenuDown(this.ControllingPlayer))
        {
          ++this.updownIndex;
          if (this.updownIndex > 22)
            this.updownIndex = 22;
          this.jot.Play(this.sc.ev * 0.5f, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
        }
        else if (!input.IsNewButtonPress(Buttons.DPadRight, this.ControllingPlayer, out this.playerIndex) && !input.IsNewButtonPress(Buttons.LeftThumbstickRight, this.ControllingPlayer, out this.playerIndex))
        {
          if (!input.IsNewButtonPress(Buttons.DPadLeft, this.ControllingPlayer, out this.playerIndex) && !input.IsNewButtonPress(Buttons.LeftThumbstickLeft, this.ControllingPlayer, out this.playerIndex))
          {
            if (input.IsNewButtonPress(Buttons.RightThumbstickRight, this.ControllingPlayer, out this.playerIndex))
            {
              if (this.updownIndex >= 11)
              {
                this.slider12 += 100;
                if (this.slider12 > 4500)
                  this.slider12 = 0;
                this.slider14 += 100;
                if (this.slider14 > 4500)
                  this.slider14 = 0;
                this.slider16 += 100;
                if (this.slider16 > 4500)
                  this.slider16 = 0;
                this.slider18 += 100;
                if (this.slider18 > 4500)
                  this.slider18 = 0;
                this.slider20 += 100;
                if (this.slider20 > 4500)
                  this.slider20 = 0;
                this.slider22 += 100;
                if (this.slider22 > 4500)
                  this.slider22 = 0;
                this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
              }
            }
            else if (input.IsNewButtonPress(Buttons.RightThumbstickLeft, this.ControllingPlayer, out this.playerIndex) && this.updownIndex >= 11)
            {
              this.slider12 -= 100;
              if (this.slider12 < 0)
                this.slider12 = 4500;
              this.slider14 -= 100;
              if (this.slider14 < 0)
                this.slider14 = 4500;
              this.slider16 -= 100;
              if (this.slider16 < 0)
                this.slider16 = 4500;
              this.slider18 -= 100;
              if (this.slider18 < 0)
                this.slider18 = 4500;
              this.slider20 -= 100;
              if (this.slider20 < 0)
                this.slider20 = 4500;
              this.slider22 -= 100;
              if (this.slider22 < 0)
                this.slider22 = 4500;
              this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
            }
          }
          else if (this.updownIndex == 0)
          {
            --this.slider1;
            if (this.slider1 < 0)
              this.slider1 = 1;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
            if (this.slider1 == 1)
            {
              walletBoxBB screen = new walletBoxBB("moon");
              screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.hideMenu = false);
              screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.hideMenu = false);
              this.ScreenManager.AddScreen((GameScreen) screen, new PlayerIndex?(this.playerIndex));
              this.hideMenu = true;
            }
          }
          else if (this.updownIndex == 1)
          {
            --this.slider2;
            if (this.slider2 < 0)
              this.slider2 = 22;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          else if (this.updownIndex == 2)
          {
            this.slider3 -= 7;
            if (this.slider3 < 0)
              this.slider3 = 1200;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          else if (this.updownIndex == 3)
          {
            this.slider4 -= 10;
            if (this.slider4 < 0)
              this.slider4 = 800;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          else if (this.updownIndex == 4)
          {
            this.slider5 -= 10;
            if (this.slider5 < 0)
              this.slider5 = 800;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          else if (this.updownIndex == 5)
          {
            --this.slider6;
            if (this.slider6 < 0)
              this.slider6 = 35;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          else if (this.updownIndex == 6)
          {
            --this.slider7;
            if (this.slider7 < 0)
              this.slider7 = 35;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          else if (this.updownIndex == 7)
          {
            --this.slider8;
            if (this.slider8 < 0)
              this.slider8 = 100;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          else if (this.updownIndex == 8)
          {
            --this.slider9;
            if (this.slider9 < 0)
              this.slider9 = 100;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          else if (this.updownIndex == 9)
          {
            this.slider10 -= 10;
            if (this.slider10 < 0)
              this.slider10 = 800;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          else if (this.updownIndex == 10)
          {
            this.slider11 -= 10;
            if (this.slider11 < 0)
              this.slider11 = 800;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          else if (this.updownIndex == 11)
          {
            this.slider12 -= 100;
            if (this.slider12 < 0)
              this.slider12 = 4500;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          else if (this.updownIndex == 12)
          {
            --this.slider13;
            if (this.slider13 < 0)
              this.slider13 = 50;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          else if (this.updownIndex == 13)
          {
            this.slider14 -= 100;
            if (this.slider14 < 0)
              this.slider14 = 4500;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          else if (this.updownIndex == 14)
          {
            --this.slider15;
            if (this.slider15 < 0)
              this.slider15 = 50;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          else if (this.updownIndex == 15)
          {
            this.slider16 -= 100;
            if (this.slider16 < 0)
              this.slider16 = 4500;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          else if (this.updownIndex == 16)
          {
            --this.slider17;
            if (this.slider17 < 0)
              this.slider17 = 50;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          else if (this.updownIndex == 17)
          {
            this.slider18 -= 100;
            if (this.slider18 < 0)
              this.slider18 = 4500;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          else if (this.updownIndex == 18)
          {
            --this.slider19;
            if (this.slider19 < 0)
              this.slider19 = 50;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          else if (this.updownIndex == 19)
          {
            this.slider20 -= 100;
            if (this.slider20 < 0)
              this.slider20 = 4500;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          else if (this.updownIndex == 20)
          {
            --this.slider21;
            if (this.slider21 < 0)
              this.slider21 = 50;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          else if (this.updownIndex == 21)
          {
            this.slider22 -= 100;
            if (this.slider22 < 0)
              this.slider22 = 4500;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          else if (this.updownIndex == 22)
          {
            --this.slider23;
            if (this.slider23 < 0)
              this.slider23 = 50;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
        }
        else if (this.updownIndex == 0)
        {
          ++this.slider1;
          if (this.slider1 > 1)
            this.slider1 = 0;
          else
            this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
          if (this.slider1 == 1)
          {
            walletBoxBB screen = new walletBoxBB("moon");
            screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.hideMenu = false);
            screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.hideMenu = false);
            this.ScreenManager.AddScreen((GameScreen) screen, new PlayerIndex?(this.playerIndex));
            this.hideMenu = true;
          }
        }
        else if (this.updownIndex == 1)
        {
          ++this.slider2;
          if (this.slider2 > 22)
            this.slider2 = 0;
          else
            this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
        }
        else if (this.updownIndex == 2)
        {
          this.slider3 += 6;
          if (this.slider3 > 1200)
            this.slider3 = 0;
          else
            this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
        }
        else if (this.updownIndex == 3)
        {
          this.slider4 += 10;
          if (this.slider4 > 800)
            this.slider4 = 0;
          else
            this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
        }
        else if (this.updownIndex == 4)
        {
          this.slider5 += 10;
          if (this.slider5 > 800)
            this.slider5 = 0;
          else
            this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
        }
        else if (this.updownIndex == 5)
        {
          ++this.slider6;
          if (this.slider6 > 35)
            this.slider6 = 0;
          else
            this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
        }
        else if (this.updownIndex == 6)
        {
          ++this.slider7;
          if (this.slider7 > 35)
            this.slider7 = 0;
          else
            this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
        }
        else if (this.updownIndex == 7)
        {
          ++this.slider8;
          if (this.slider8 > 100)
            this.slider8 = 0;
          else
            this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
        }
        else if (this.updownIndex == 8)
        {
          ++this.slider9;
          if (this.slider9 > 100)
            this.slider9 = 0;
          else
            this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
        }
        else if (this.updownIndex == 9)
        {
          this.slider10 += 10;
          if (this.slider10 > 800)
            this.slider10 = 0;
          else
            this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
        }
        else if (this.updownIndex == 10)
        {
          this.slider11 += 10;
          if (this.slider11 > 800)
            this.slider11 = 0;
          else
            this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
        }
        else if (this.updownIndex == 11)
        {
          this.slider12 += 100;
          if (this.slider12 > 4500)
            this.slider12 = 0;
          else
            this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
        }
        else if (this.updownIndex == 12)
        {
          ++this.slider13;
          if (this.slider13 > 50)
            this.slider13 = 0;
          else
            this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
        }
        else if (this.updownIndex == 13)
        {
          this.slider14 += 100;
          if (this.slider14 > 4500)
            this.slider14 = 0;
          else
            this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
        }
        else if (this.updownIndex == 14)
        {
          ++this.slider15;
          if (this.slider15 > 50)
            this.slider15 = 0;
          else
            this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
        }
        else if (this.updownIndex == 15)
        {
          this.slider16 += 100;
          if (this.slider16 > 4500)
            this.slider16 = 0;
          else
            this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
        }
        else if (this.updownIndex == 16)
        {
          ++this.slider17;
          if (this.slider17 > 50)
            this.slider17 = 0;
          else
            this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
        }
        else if (this.updownIndex == 17)
        {
          this.slider18 += 100;
          if (this.slider18 > 4500)
            this.slider18 = 0;
          else
            this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
        }
        else if (this.updownIndex == 18)
        {
          ++this.slider19;
          if (this.slider19 > 50)
            this.slider19 = 0;
          else
            this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
        }
        else if (this.updownIndex == 19)
        {
          this.slider20 += 100;
          if (this.slider20 > 4500)
            this.slider20 = 0;
          else
            this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
        }
        else if (this.updownIndex == 20)
        {
          ++this.slider21;
          if (this.slider21 > 50)
            this.slider21 = 0;
          else
            this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
        }
        else if (this.updownIndex == 21)
        {
          this.slider22 += 100;
          if (this.slider22 > 4500)
            this.slider22 = 0;
          else
            this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
        }
        else if (this.updownIndex == 22)
        {
          ++this.slider23;
          if (this.slider23 > 50)
            this.slider23 = 0;
          else
            this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
        }
      }
      if (this.choice == "moon")
      {
        if (input.IsMenuCancel(this.ControllingPlayer, out this.playerIndex))
        {
          this.sc.realMoon = this.slider2;
          this.sc.realDarkness = (float) this.slider1 / 10f;
          if (this.Accepted != null)
            this.Accepted((object) this, new PlayerIndexEventArgs(this.playerIndex));
          this.ExitScreen();
        }
        else if (input.IsMenuSelect(this.ControllingPlayer, out this.playerIndex))
        {
          this.sc.realMoon = this.slider2;
          this.sc.realDarkness = (float) this.slider1 / 10f;
          if (this.Accepted != null)
            this.Accepted((object) this, new PlayerIndexEventArgs(this.playerIndex));
          this.ExitScreen();
        }
        else if (input.IsMenuUp(this.ControllingPlayer))
        {
          --this.updownIndex;
          if (this.updownIndex < 0)
            this.updownIndex = 1;
          this.jot.Play(this.sc.ev * 0.5f, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
        }
        else if (input.IsMenuDown(this.ControllingPlayer))
        {
          ++this.updownIndex;
          if (this.updownIndex > 1)
            this.updownIndex = 0;
          this.jot.Play(this.sc.ev * 0.5f, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
        }
        else if (input.IsMenuRight(this.ControllingPlayer))
        {
          if (this.updownIndex == 0)
          {
            ++this.slider1;
            if (this.slider1 > 10)
              this.slider1 = 0;
            else
              this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
          }
          if (this.updownIndex == 1)
          {
            ++this.slider2;
            if (this.slider2 > 8)
              this.slider2 = 0;
            else
              this.drip.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
          }
        }
        else if (input.IsMenuLeft(this.ControllingPlayer))
        {
          if (this.updownIndex == 0)
          {
            --this.slider1;
            if (this.slider1 < 0)
              this.slider1 = 10;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
          if (this.updownIndex == 1)
          {
            --this.slider2;
            if (this.slider2 < 0)
              this.slider2 = 8;
            else
              this.drip.Play(this.sc.ev * 0.5f, -0.2f, 0.0f);
          }
        }
      }
      this.delayinput = false;
    }

    public override void Draw(GameTime gameTime)
    {
      if (this.sc.deactivated)
        return;
      this.rampIN += 0.07f;
      if ((double) this.rampIN > 1.0)
        this.rampIN = 1f;
      if (this.hideMenu)
        return;
      if (this.choice == "controller" || this.choice == "controller2" || this.choice == "rebind" || this.choice == "hotkeys")
        this.scc = 1f;
      float num1 = MathHelper.Lerp(-1090f, 0.0f, this.rampIN);
      this.paperPos = new Vector2(1280f + num1, (float) (620.0 + (double) num1 / (double) this.drift)) / 2f + this.offset;
      int num2 = (int) (443.0 * ((double) this.sc.screenSize.Width / (double) this.sc.origSize.Width));
      int num3;
      if ((double) this.sc.aspectratio > 1.0)
        num3 = num2 + (int) (((double) this.sc.screenSize.Width - (double) this.sc.screenSize.Width / (double) this.sc.aspectratio) * (0.5 * (double) this.sc.aspectratio));
      if (this.choice == "hotkeys" || this.choice == "rebind" || this.choice == "instructions" || this.choice == "controller" || this.choice == "video" || this.choice == "controller2")
        num3 = 0;
      Matrix scale = Matrix.CreateScale((float) this.sc.width / 1280f, (float) this.sc.hite / 720f, 1f);
      this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) null, scale);
      if (this.choice == "restart")
      {
        int index = this.myIndex;
        this.myIndex = -1;
        Vector2 origin = new Vector2((float) this.myRect.Width, (float) this.myRect.Height) / 2f;
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos, new Rectangle?(this.myRect), Color.White, this.rot, origin, 1.2f, SpriteEffects.None, 0.0f);
        this.queryButton(this.leftArrowRect, new Vector2(-73f, -65f) + this.paperPos, 0);
        this.queryButton(this.rightArrowRect, new Vector2(35f, -65f) + this.paperPos, 1);
        if (this.sc.usingMouse)
        {
          if (this.myIndex == 0)
            this.spriteBatch.Draw(this.sc.paper1, new Vector2(-73f, -65f) + this.paperPos, new Rectangle?(this.leftArrowGlowRect), Color.White);
          else
            this.spriteBatch.Draw(this.sc.paper1, new Vector2(-73f, -65f) + this.paperPos, new Rectangle?(this.leftArrowRect), Color.White);
          if (this.myIndex == 1)
            this.spriteBatch.Draw(this.sc.paper1, new Vector2(35f, -65f) + this.paperPos, new Rectangle?(this.rightArrowGlowRect), Color.White);
          else
            this.spriteBatch.Draw(this.sc.paper1, new Vector2(35f, -65f) + this.paperPos, new Rectangle?(this.rightArrowRect), Color.White);
        }
        else
        {
          this.spriteBatch.Draw(this.sc.paper1, new Vector2(-73f, -65f) + this.paperPos, new Rectangle?(this.leftArrowRect), Color.White);
          this.spriteBatch.Draw(this.sc.paper1, new Vector2(35f, -65f) + this.paperPos, new Rectangle?(this.rightArrowRect), Color.White);
        }
        this.paperPos.Y -= 30f;
        astrobindings.b1.Length = 0;
        astrobindings.b1.Append("Choose Day");
        this.spriteBatch.DrawString(this.scribbleFont, astrobindings.b1, this.paperPos - this.scribbleFont.MeasureString(astrobindings.b1) / 2f + this.vec[0], this.bluePen);
        astrobindings.b1.Length = 0;
        astrobindings.b1.Concat(this.updownIndex);
        this.spriteBatch.DrawString(this.scribbleFont, astrobindings.b1, this.paperPos - this.scribbleFont.MeasureString(astrobindings.b1) / 2f + this.vec[1], this.bluePen);
        astrobindings.b1.Length = 0;
        if (!this.sc.cheat_skipday && this.updownIndex >= (int) this.sc.maxDay() + 1)
          astrobindings.b1.Append("not completed");
        else
          astrobindings.b1.Append(this.dayDescribe[this.updownIndex - 1]);
        this.spriteBatch.DrawString(this.scribbleFont, astrobindings.b1, new Vector2(0.0f, 40f) + this.paperPos - this.scribbleFont.MeasureString(astrobindings.b1) / 2f + this.vec[1], new Color(120, 50, 0));
        astrobindings.b1.Length = 0;
        Color color = this.bluePen;
        if (this.sc.days[this.updownIndex] == 0)
          astrobindings.b1.Append("");
        if (this.sc.days[this.updownIndex] == 1)
        {
          astrobindings.b1.Append("beat on easy");
          color = new Color(120, 50, 0);
        }
        if (this.sc.days[this.updownIndex] == 2)
        {
          astrobindings.b1.Append("beat on normal");
          color = this.bluePen;
        }
        if (this.sc.days[this.updownIndex] == 3)
        {
          astrobindings.b1.Append("beat on hard");
          color = new Color(20, 120, 10);
        }
        this.spriteBatch.DrawString(this.scribbleFont, astrobindings.b1, new Vector2(0.0f, 70f) + this.paperPos - this.scribbleFont.MeasureString(astrobindings.b1) / 2f + this.vec[1], color);
        if (!this.sc.usingMouse)
        {
          astrobindings.b1.Length = 0;
          astrobindings.b1.Append("yes");
          this.spriteBatch.DrawString(this.scribbleFont, astrobindings.b1, new Vector2(0.0f, 50f) + this.paperPos - this.scribbleFont.MeasureString(astrobindings.b1) / 2f + this.vec[2], this.bluePen);
          this.spriteBatch.Draw(this.sc.paper1, new Vector2(0.0f, 50f) + this.paperPos - origin + this.vec[3], new Rectangle?(this.rectangle_6), Color.White);
          astrobindings.b1.Length = 0;
          astrobindings.b1.Append("no");
          this.spriteBatch.DrawString(this.scribbleFont, astrobindings.b1, new Vector2(0.0f, 50f) + this.paperPos - this.scribbleFont.MeasureString(astrobindings.b1) / 2f + this.vec[4], this.bluePen);
          this.spriteBatch.Draw(this.sc.paper1, new Vector2(0.0f, 50f) + this.paperPos - origin + this.vec[5], new Rectangle?(this.rectangle_7), Color.White);
        }
        else
        {
          this.queryButton(this.buttonBoxRect, new Vector2(0.0f, 50f) + this.paperPos - origin + this.vec[3], 2);
          this.queryButton(this.buttonBoxRect, new Vector2(20f, 50f) + this.paperPos - origin + this.vec[5], 3);
          astrobindings.b1.Length = 0;
          astrobindings.b1.Append("yes");
          this.spriteBatch.DrawString(this.scribbleFont, astrobindings.b1, new Vector2(-5f, 50f) + this.paperPos - this.scribbleFont.MeasureString(astrobindings.b1) / 2f + this.vec[2], this.bluePen);
          astrobindings.b1.Length = 0;
          astrobindings.b1.Append("no");
          this.spriteBatch.DrawString(this.scribbleFont, astrobindings.b1, new Vector2(5f, 50f) + this.paperPos - this.scribbleFont.MeasureString(astrobindings.b1) / 2f + this.vec[4], this.bluePen);
          if (this.myIndex == 2)
            this.spriteBatch.Draw(this.sc.paper1, new Vector2(0.0f, 50f) + this.paperPos - origin + this.vec[3], new Rectangle?(this.buttonGlowRect), Color.White);
          else
            this.spriteBatch.Draw(this.sc.paper1, new Vector2(0.0f, 50f) + this.paperPos - origin + this.vec[3], new Rectangle?(this.buttonBoxRect), Color.White);
          if (this.myIndex == 3)
            this.spriteBatch.Draw(this.sc.paper1, new Vector2(20f, 50f) + this.paperPos - origin + this.vec[5], new Rectangle?(this.buttonGlowRect), Color.White);
          else
            this.spriteBatch.Draw(this.sc.paper1, new Vector2(20f, 50f) + this.paperPos - origin + this.vec[5], new Rectangle?(this.buttonBoxRect), Color.White);
        }
        if (index != this.myIndex && this.myIndex != -1)
          this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
      }
      if (this.choice == "kicks")
      {
        int index = this.myIndex;
        this.myIndex = -1;
        Vector2 origin = new Vector2((float) this.myRect.Width, (float) this.myRect.Height) / 2f;
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos, new Rectangle?(this.myRect), Color.White, 0.0f, origin, 1.25f, SpriteEffects.None, 0.0f);
        if (this.sc.usingMouse)
        {
          this.queryButton(this.bigboxRect, this.paperPos - origin + this.vec[5], 0);
          this.queryButton(this.bigboxRect, this.paperPos - origin + this.vec[6], 1);
          this.queryButton(this.bigboxRect, this.paperPos - origin + this.vec[7], 2);
          this.queryButton(this.bigboxRect, this.paperPos - origin + this.vec[8], 3);
          this.queryButton(this.bigboxRect, this.paperPos - origin + this.vec[9], 4);
          this.updownIndex = -1;
        }
        if (this.updownIndex == 0 || this.myIndex == 0)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[5], new Rectangle?(this.biggerboxRect), this.bluePen);
        if (this.updownIndex == 1 || this.myIndex == 1)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[6], new Rectangle?(this.biggerboxRect), this.bluePen);
        if (this.updownIndex == 2 || this.myIndex == 2)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[7], new Rectangle?(this.biggerboxRect), this.bluePen);
        if (this.updownIndex == 3 || this.myIndex == 3)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[8], new Rectangle?(this.biggerboxRect), this.bluePen);
        if (this.updownIndex == 4 || this.myIndex == 4)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[9], new Rectangle?(this.biggerboxRect), this.bluePen);
        string text1 = "EMPTY SLOT";
        if (this.sc.kickplayerName.Count >= 5)
          text1 = this.sc.kickplayerName[4];
        this.spriteBatch.DrawString(this.scribbleFont, text1, this.paperPos - this.scribbleFont.MeasureString(text1) / 2f + this.vec[0], this.bluePen);
        string text2 = "EMPTY SLOT";
        if (this.sc.kickplayerName.Count >= 4)
          text2 = this.sc.kickplayerName[3];
        this.spriteBatch.DrawString(this.scribbleFont, text2, this.paperPos - this.scribbleFont.MeasureString(text2) / 2f + this.vec[1], this.bluePen);
        string text3 = "EMPTY SLOT";
        if (this.sc.kickplayerName.Count >= 3)
          text3 = this.sc.kickplayerName[2];
        this.spriteBatch.DrawString(this.scribbleFont, text3, this.paperPos - this.scribbleFont.MeasureString(text3) / 2f + this.vec[2], this.bluePen);
        string text4 = "EMPTY SLOT";
        if (this.sc.kickplayerName.Count >= 2)
          text4 = this.sc.kickplayerName[1];
        this.spriteBatch.DrawString(this.scribbleFont, text4, this.paperPos - this.scribbleFont.MeasureString(text4) / 2f + this.vec[3], this.bluePen);
        string text5 = "EMPTY SLOT";
        if (this.sc.kickplayerName.Count >= 1)
          text5 = this.sc.kickplayerName[0];
        this.spriteBatch.DrawString(this.scribbleFont, text5, this.paperPos - this.scribbleFont.MeasureString(text5) / 2f + this.vec[4], this.bluePen);
        if (index != this.myIndex && this.myIndex != -1)
          this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
      }
      if (this.choice == "options")
      {
        int index = this.myIndex;
        this.myIndex = -1;
        Vector2 origin = new Vector2((float) this.myRect.Width, (float) this.myRect.Height) / 2f;
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos, new Rectangle?(this.myRect), Color.White, this.rot, origin, 1.1f, SpriteEffects.None, 0.0f);
        if (this.sc.usingMouse)
        {
          this.queryButton(this.bigboxRect, this.paperPos - origin + this.vec[3], 0);
          this.queryButton(this.bigboxRect, this.paperPos - origin + this.vec[4], 1);
          this.queryButton(this.bigboxRect, this.paperPos - origin + this.vec[5], 2);
          this.updownIndex = -1;
        }
        if (this.updownIndex == 0 || this.myIndex == 0)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[3], new Rectangle?(this.bigboxRect), this.bluePen);
        if (this.updownIndex == 1 || this.myIndex == 1)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[4], new Rectangle?(this.bigboxRect), this.bluePen);
        if (this.updownIndex == 2 || this.myIndex == 2)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[5], new Rectangle?(this.bigboxRect), this.bluePen);
        string text6 = "Audio";
        this.spriteBatch.DrawString(this.scribbleFont, text6, this.paperPos - this.scribbleFont.MeasureString(text6) / 2f + this.vec[0], this.bluePen);
        string text7 = "Video";
        this.spriteBatch.DrawString(this.scribbleFont, text7, this.paperPos - this.scribbleFont.MeasureString(text7) / 2f + this.vec[1], this.bluePen);
        string text8 = "Game";
        this.spriteBatch.DrawString(this.scribbleFont, text8, this.paperPos - this.scribbleFont.MeasureString(text8) / 2f + this.vec[2], this.bluePen);
        if (index != this.myIndex && this.myIndex != -1)
          this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
      }
      if (this.choice == "audio")
      {
        int index = this.myIndex;
        this.myIndex = -1;
        Vector2 origin = new Vector2((float) this.myRect.Width, (float) this.myRect.Height) / 2f;
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos, new Rectangle?(this.myRect), Color.White, 0.0f, origin, 1.25f, SpriteEffects.None, 0.0f);
        if (!this.sc.usingMouse)
        {
          if (this.updownIndex == 0)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[3], new Rectangle?(this.bigboxRect), this.bluePen);
          if (this.updownIndex == 1)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[4], new Rectangle?(this.bigboxRect), this.bluePen);
          if (this.updownIndex == 2)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[5], new Rectangle?(this.bigboxRect), this.bluePen);
        }
        string text9 = "music";
        this.spriteBatch.DrawString(this.scribbleFont, text9, this.paperPos - this.scribbleFont.MeasureString(text9) / 2f + this.vec[0], this.bluePen);
        string text10 = "effects";
        this.spriteBatch.DrawString(this.scribbleFont, text10, this.paperPos - this.scribbleFont.MeasureString(text10) / 2f + this.vec[1], this.bluePen);
        string text11 = "voice";
        this.spriteBatch.DrawString(this.scribbleFont, text11, this.paperPos - this.scribbleFont.MeasureString(text11) / 2f + this.vec[2], this.bluePen);
        astrobindings.b1.Length = 0;
        astrobindings.b1.Concat(this.slider1);
        this.spriteBatch.DrawString(this.scribbleFont, astrobindings.b1, this.paperPos - this.scribbleFont.MeasureString(astrobindings.b1) / 2f + this.vec[6], this.bluePen);
        if (this.sc.usingMouse)
        {
          this.queryButton(this.sliderBoxRect, this.paperPos + this.vec[0] + new Vector2(32f + this.sliderbox1, 4f), 0);
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos + this.vec[0] + new Vector2(-40f, 20f), new Rectangle?(this.sliderRect), Color.White);
          if (this.myIndex == 0)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos + this.vec[0] + new Vector2(32f + this.sliderbox1, 4f), new Rectangle?(this.sliderGlowRect), Color.White);
          else
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos + this.vec[0] + new Vector2(32f + this.sliderbox1, 4f), new Rectangle?(this.sliderBoxRect), Color.White);
        }
        astrobindings.b1.Length = 0;
        astrobindings.b1.Concat(this.slider2);
        this.spriteBatch.DrawString(this.scribbleFont, astrobindings.b1, this.paperPos - this.scribbleFont.MeasureString(astrobindings.b1) / 2f + this.vec[7], this.bluePen);
        if (this.sc.usingMouse)
        {
          this.queryButton(this.sliderBoxRect, this.paperPos + this.vec[1] + new Vector2(17f + this.sliderbox2, 4f), 1);
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos + this.vec[1] + new Vector2(-55f, 20f), new Rectangle?(this.sliderRect), Color.White);
          if (this.myIndex == 1)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos + this.vec[1] + new Vector2(17f + this.sliderbox2, 4f), new Rectangle?(this.sliderGlowRect), Color.White);
          else
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos + this.vec[1] + new Vector2(17f + this.sliderbox2, 4f), new Rectangle?(this.sliderBoxRect), Color.White);
        }
        astrobindings.b1.Length = 0;
        astrobindings.b1.Concat(this.slider3);
        this.spriteBatch.DrawString(this.scribbleFont, astrobindings.b1, this.paperPos - this.scribbleFont.MeasureString(astrobindings.b1) / 2f + this.vec[8], this.bluePen);
        if (this.sc.usingMouse)
        {
          this.queryButton(this.sliderBoxRect, this.paperPos + this.vec[2] + new Vector2(32f + this.sliderbox3, 4f), 2);
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos + this.vec[2] + new Vector2(-40f, 20f), new Rectangle?(this.sliderRect), Color.White);
          if (this.myIndex == 2)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos + this.vec[2] + new Vector2(32f + this.sliderbox3, 4f), new Rectangle?(this.sliderGlowRect), Color.White);
          else
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos + this.vec[2] + new Vector2(32f + this.sliderbox3, 4f), new Rectangle?(this.sliderBoxRect), Color.White);
        }
        string text12 = "save";
        this.queryButton(this.buttonBoxRect, this.paperPos - origin + this.vec[10], 3);
        Color color = this.bluePen;
        if (this.myIndex == 3)
          color = this.grnPen;
        this.spriteBatch.DrawString(this.scribbleFont, text12, this.paperPos - this.scribbleFont.MeasureString(text12) / 2f + this.vec[9], color);
        if (!this.sc.usingMouse)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[10], new Rectangle?(this.rectangle_6), Color.White);
        else if (this.myIndex == 3)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[10], new Rectangle?(this.buttonGlowRect), Color.White);
        else
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[10], new Rectangle?(this.buttonBoxRect), Color.White);
        if (index != this.myIndex && this.myIndex != -1)
          this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
      }
      if (this.choice == "video")
      {
        int index = this.myIndex;
        this.myIndex = -1;
        Vector2 origin = new Vector2((float) this.myRect.Width, (float) this.myRect.Height) / 2f;
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos, new Rectangle?(this.myRect), Color.White, 0.0f, origin, 1f, SpriteEffects.None, 0.0f);
        Vector2 vector2 = new Vector2(-40f, -115f);
        this.queryButton(this.sliderBoxRect, this.paperPos + vector2 + new Vector2(32f + this.sliderbox1, 4f), 0);
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos + vector2 + new Vector2(-40f, 20f), new Rectangle?(this.sliderRect), Color.White);
        if (this.myIndex == 0)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos + vector2 + new Vector2(32f + this.sliderbox1, 4f), new Rectangle?(this.sliderGlowRect), Color.White);
        else
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos + vector2 + new Vector2(32f + this.sliderbox1, 4f), new Rectangle?(this.sliderBoxRect), Color.White);
        vector2 = new Vector2(-40f, 80f);
        this.queryButton(this.sliderBoxRect, this.paperPos + vector2 + new Vector2(32f + this.sliderbox2, 4f), 1);
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos + vector2 + new Vector2(-40f, 20f), new Rectangle?(this.sliderRect), Color.White);
        if (this.myIndex == 1)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos + vector2 + new Vector2(32f + this.sliderbox2, 4f), new Rectangle?(this.sliderGlowRect), Color.White);
        else
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos + vector2 + new Vector2(32f + this.sliderbox2, 4f), new Rectangle?(this.sliderBoxRect), Color.White);
        if (this.sc.usingMouse)
        {
          this.queryButton2(new Rectangle(0, 0, 160, 50), this.sc.hud_enemy, 5);
          this.queryButton2(new Rectangle(0, 0, 160, 50), new Vector2(this.sc.hud_clock.X + 100f, this.sc.hud_clock.Y), 6);
          this.queryButton2(new Rectangle(0, 0, 140, 50), new Vector2(this.sc.hud_day.X - 160f, this.sc.hud_day.Y), 7);
          this.queryButton2(new Rectangle(0, 0, 110, 60), this.sc.hud_weapons, 8);
          this.queryButton2(new Rectangle(0, 0, 110, 60), this.sc.hud_dpad, 9);
          this.queryButton2(new Rectangle(0, 0, 180, 60), this.sc.hud_player1, 10);
          this.queryButton2(new Rectangle(0, 0, 140, 60), this.sc.hud_player2, 11);
        }
        string text13 = "cycle";
        if (!this.sc.usingMouse)
        {
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[1], new Rectangle?(this.rectangle_9), Color.White);
        }
        else
        {
          this.queryButton(this.buttonBoxRect, this.paperPos - origin + this.vec[1], 2);
          if (this.myIndex == 2)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[1], new Rectangle?(this.buttonGlowRect), Color.White);
          else
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[1], new Rectangle?(this.buttonBoxRect), Color.White);
        }
        Color color1 = this.bluePen;
        if (this.myIndex == 2)
          color1 = this.grnPen;
        this.spriteBatch.DrawString(this.scribbleFont, text13, this.paperPos - this.scribbleFont.MeasureString(text13) / 2f + this.vec[0], color1);
        string text14 = "defaults";
        if (!this.sc.usingMouse)
        {
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[3], new Rectangle?(this.rectangle_8), Color.White);
        }
        else
        {
          this.queryButton(this.buttonBoxRect, this.paperPos - origin + this.vec[3], 3);
          if (this.myIndex == 3)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[3], new Rectangle?(this.buttonGlowRect), Color.White);
          else
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[3], new Rectangle?(this.buttonBoxRect), Color.White);
        }
        Color color2 = this.bluePen;
        if (this.myIndex == 3)
          color2 = this.grnPen;
        this.spriteBatch.DrawString(this.scribbleFont, text14, this.paperPos - this.scribbleFont.MeasureString(text14) / 2f + this.vec[2], color2);
        string text15 = "save";
        if (!this.sc.usingMouse)
        {
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[5], new Rectangle?(this.rectangle_6), Color.White);
        }
        else
        {
          this.queryButton(this.buttonBoxRect, this.paperPos - origin + this.vec[5], 4);
          if (this.myIndex == 4)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[5], new Rectangle?(this.buttonGlowRect), Color.White);
          else
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[5], new Rectangle?(this.buttonBoxRect), Color.White);
        }
        Color color3 = this.bluePen;
        if (this.myIndex == 4)
          color3 = this.grnPen;
        this.spriteBatch.DrawString(this.scribbleFont, text15, this.paperPos - this.scribbleFont.MeasureString(text15) / 2f + this.vec[4], color3);
        float num4 = (float) (Math.Sin(gameTime.TotalGameTime.TotalMilliseconds / 40.0) / 2.0 + 0.60000002384185791);
        this.sc.color_enemy = this.updownIndex != 0 ? new Color(210, 0, 0, (int) byte.MaxValue) : new Color(210, 0, 0, (int) byte.MaxValue) * num4;
        this.sc.color_day = this.updownIndex != 2 ? new Color(210, 0, 0, (int) byte.MaxValue) : new Color(210, 0, 0, (int) byte.MaxValue) * num4;
        this.sc.color_clock = this.updownIndex != 1 ? new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue) : new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue) * num4;
        this.sc.color_player1 = this.updownIndex != 5 ? new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue) : new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue) * num4;
        this.sc.color_player2 = this.updownIndex != 6 ? new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue) : new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue) * num4;
        this.sc.color_weapons = this.updownIndex != 3 ? new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue) : new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue) * num4;
        this.sc.color_dpad = this.updownIndex != 4 ? new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue) : new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue) * num4;
        if (index != this.myIndex && this.myIndex != -1)
          this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
      }
      if (this.choice == "game")
      {
        int index = this.myIndex;
        this.myIndex = -1;
        this.paperPos.X += 30f;
        Vector2 origin = new Vector2((float) this.myRect.Width, (float) this.myRect.Height) / 2f;
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos, new Rectangle?(this.myRect), Color.White, this.rot, origin, 1.5f, SpriteEffects.None, 0.0f);
        if (!this.sc.usingMouse)
        {
          if (this.updownIndex == 0)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[12] - new Vector2(0.0f, 30f), new Rectangle?(this.biggerboxRect), this.bluePen);
          if (this.updownIndex == 1)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[13] - new Vector2(0.0f, 35f), new Rectangle?(this.biggerboxRect), this.bluePen);
          if (this.updownIndex == 2)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[14] - new Vector2(10f, 45f), new Rectangle?(this.biggerboxRect), this.bluePen);
          if (this.updownIndex == 3)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + new Vector2(46f, 126f), new Rectangle?(this.biggerboxRect), this.bluePen);
          if (this.updownIndex == 4)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[15] + new Vector2(0.0f, 10f), new Rectangle?(this.biggerboxRect), this.bluePen);
        }
        Vector2 vector2 = new Vector2(0.0f, -30f);
        string text16 = "invert-Y";
        this.spriteBatch.DrawString(this.scribbleFont, text16, this.paperPos - this.scribbleFont.MeasureString(text16) / 2f + this.vec[0] + vector2, this.bluePen);
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[1] + vector2, new Rectangle?(this.littleboxRect), Color.White);
        this.queryButton(this.littleboxRect, this.paperPos - origin + this.vec[1] + vector2, 0);
        if (this.myIndex == 0)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[1] + vector2, new Rectangle?(this.littleglowRect), Color.White);
        if (this.slider1 == 1)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[2] + vector2, new Rectangle?(this.checkmarkRect), Color.White);
        vector2 = new Vector2(0.0f, -35f);
        string text17 = "sensitivity";
        this.spriteBatch.DrawString(this.scribbleFont, text17, this.paperPos - this.scribbleFont.MeasureString(text17) / 2f + this.vec[3] + vector2, this.bluePen);
        astrobindings.b1.Length = 0;
        astrobindings.b1.Concat(this.slider2);
        this.queryButtonX(new Rectangle(0, 0, (int) this.scribbleFont.MeasureString(astrobindings.b1).X, (int) this.scribbleFont.MeasureString(astrobindings.b1).Y), this.paperPos - this.scribbleFont.MeasureString(astrobindings.b1) / 2f + this.vec[4] + vector2, 1);
        Color color4 = this.bluePen;
        if (this.myIndex == 1)
          color4 = this.grnPen;
        this.spriteBatch.DrawString(this.scribbleFont, astrobindings.b1, this.paperPos - this.scribbleFont.MeasureString(astrobindings.b1) / 2f + this.vec[4] + vector2, color4);
        vector2 = new Vector2(-10f, -45f);
        string text18 = "vibration";
        this.spriteBatch.DrawString(this.scribbleFont, text18, this.paperPos - this.scribbleFont.MeasureString(text18) / 2f + this.vec[5] + vector2, this.bluePen);
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[6] + vector2, new Rectangle?(this.littleboxRect), Color.White);
        this.queryButton(this.littleboxRect, this.paperPos - origin + this.vec[6] + vector2, 2);
        if (this.myIndex == 2)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[6] + vector2, new Rectangle?(this.littleglowRect), Color.White);
        if (this.slider3 == 1)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[7] + vector2, new Rectangle?(this.checkmarkRect), Color.White);
        string text19 = "sprint-toggle";
        this.spriteBatch.DrawString(this.scribbleFont, text19, this.paperPos - this.scribbleFont.MeasureString(text19) / 2f + new Vector2(-6.4f, 28.8f), this.bluePen);
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + new Vector2(218f, 125.5f), new Rectangle?(this.littleboxRect), Color.White);
        this.queryButton(this.littleboxRect, this.paperPos - origin + new Vector2(218f, 125.5f), 3);
        if (this.myIndex == 3)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + new Vector2(218f, 125.5f), new Rectangle?(this.littleglowRect), Color.White);
        if (this.slider5 == 1)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + new Vector2(229f, 117.2f), new Rectangle?(this.checkmarkRect), Color.White);
        vector2 = new Vector2(0.0f, 10f);
        string text20 = "difficulty";
        this.spriteBatch.DrawString(this.scribbleFont, text20, this.paperPos - this.scribbleFont.MeasureString(text20) / 2f + this.vec[8] + vector2, this.bluePen);
        astrobindings.b1.Length = 0;
        astrobindings.b1.Append(this.diff[this.slider4]);
        this.queryButtonX(new Rectangle(0, 0, (int) this.scribbleFont.MeasureString(astrobindings.b1).X, (int) this.scribbleFont.MeasureString(astrobindings.b1).Y), this.paperPos - this.scribbleFont.MeasureString(astrobindings.b1) / 2f + this.vec[9] + vector2, 4);
        Color color5 = this.bluePen;
        if (this.myIndex == 4)
          color5 = this.grnPen;
        this.spriteBatch.DrawString(this.scribbleFont, astrobindings.b1, this.paperPos - this.scribbleFont.MeasureString(astrobindings.b1) / 2f + this.vec[9] + vector2, color5);
        vector2 = new Vector2(0.0f, 20f);
        string text21 = "save";
        this.queryButton(this.buttonBoxRect, this.paperPos - origin + this.vec[11] + vector2, 5);
        Color color6 = this.bluePen;
        if (this.myIndex == 5)
          color6 = this.grnPen;
        this.spriteBatch.DrawString(this.scribbleFont, text21, this.paperPos - this.scribbleFont.MeasureString(text21) / 2f + this.vec[10] + vector2, color6);
        if (!this.sc.usingMouse)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[11] + vector2, new Rectangle?(this.rectangle_6), Color.White);
        else if (this.myIndex == 5)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[11] + vector2, new Rectangle?(this.buttonGlowRect), Color.White);
        else
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[11] + vector2, new Rectangle?(this.buttonBoxRect), Color.White);
        if (index != this.myIndex && this.myIndex != -1)
          this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
      }
      if (this.choice == "help")
      {
        int index = this.myIndex;
        this.myIndex = -1;
        Vector2 origin = new Vector2((float) this.myRect.Width, (float) this.myRect.Height) / 2f;
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos, new Rectangle?(this.myRect), Color.White, this.rot, origin, 1f, SpriteEffects.None, 0.0f);
        if (!this.sc.usingMouse)
        {
          if (this.updownIndex == 0)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[0], new Rectangle?(this.bigboxRect), this.bluePen);
          if (this.updownIndex == 1)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[3], new Rectangle?(this.bigboxRect), this.bluePen);
          string text22 = "Instructions";
          this.spriteBatch.DrawString(this.scribbleFont, text22, this.paperPos - this.scribbleFont.MeasureString(text22) / 2f + this.vec[4], this.bluePen);
          string text23 = "Controller";
          this.spriteBatch.DrawString(this.scribbleFont, text23, this.paperPos - this.scribbleFont.MeasureString(text23) / 2f + this.vec[6], this.bluePen);
        }
        else
        {
          string text24 = "Key Bindings";
          this.spriteBatch.DrawString(this.scribbleFont, text24, this.paperPos - this.scribbleFont.MeasureString(text24) / 2f + this.vec[4], this.bluePen);
          string text25 = "Game Hotkeys";
          this.spriteBatch.DrawString(this.scribbleFont, text25, this.paperPos - this.scribbleFont.MeasureString(text25) / 2f + this.vec[6], this.bluePen);
          this.queryButton(this.bigboxRect, this.paperPos - origin + this.vec[0], 0);
          this.queryButton(this.bigboxRect, this.paperPos - origin + this.vec[3], 1);
          if (this.myIndex == 0)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[0], new Rectangle?(this.bigboxRect), this.bluePen);
          if (this.myIndex == 1)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[3], new Rectangle?(this.bigboxRect), this.bluePen);
        }
        if (index != this.myIndex && this.myIndex != -1)
          this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
      }
      if (this.choice == "rebind")
        this.sc.drawKeyBindings3(this.spriteBatch, ref this.whichKEY, ref this.thisKEY, this.sc.font);
      if (this.choice == "hotkeys")
        this.spriteBatch.Draw(this.sc.instructions, new Vector2((float) (640 - this.sc.instructions.Width / 2), (float) (370 - this.sc.instructions.Height / 2)), Color.White);
      if (this.choice == "controller")
      {
        this.scalerZoom += 0.1f;
        if ((double) this.scalerZoom > 1.0499999523162842)
          this.scalerZoom = 1.05f;
        this.paperPos = new Vector2(680f, 360f);
        this.spriteBatch.Draw(this.sc.controller, this.paperPos, new Rectangle?(), Color.White, this.rot, new Vector2((float) this.sc.controller.Width, (float) this.sc.controller.Height) / 2f, this.scaler, SpriteEffects.None, 0.0f);
      }
      if (this.choice == "instructions")
      {
        this.scalerZoom += 0.1f;
        if ((double) this.scalerZoom > 1.0)
          this.scalerZoom = 1f;
        this.paperPos = new Vector2(570f, 305f);
        Vector2 origin = new Vector2((float) this.sc.page1.Width, (float) this.sc.page1.Height) / 2f;
        if (this.updownIndex == 0)
          this.spriteBatch.Draw(this.sc.page1, this.paperPos, new Rectangle?(), Color.White, this.rot, origin, this.scaler, SpriteEffects.None, 0.0f);
        if (this.updownIndex == 1)
          this.spriteBatch.Draw(this.sc.page2, this.paperPos, new Rectangle?(), Color.White, this.rot, origin, this.scaler, SpriteEffects.None, 0.0f);
        if (this.updownIndex == 2)
          this.spriteBatch.Draw(this.sc.page3, this.paperPos, new Rectangle?(), Color.White, this.rot, origin, this.scaler, SpriteEffects.None, 0.0f);
        if (this.updownIndex == 3)
          this.spriteBatch.Draw(this.sc.page4, this.paperPos, new Rectangle?(), Color.White, this.rot, origin, this.scaler, SpriteEffects.None, 0.0f);
        if (this.updownIndex == 4)
          this.spriteBatch.Draw(this.sc.page5, this.paperPos, new Rectangle?(), Color.White, this.rot, origin, this.scaler, SpriteEffects.None, 0.0f);
        if (this.updownIndex == 5)
          this.spriteBatch.Draw(this.sc.page6, this.paperPos, new Rectangle?(), Color.White, this.rot, origin, this.scaler, SpriteEffects.None, 0.0f);
        if (this.updownIndex == 6)
          this.spriteBatch.Draw(this.sc.page7, this.paperPos, new Rectangle?(), Color.White, this.rot, origin, this.scaler, SpriteEffects.None, 0.0f);
      }
      if (this.choice == "cheats")
      {
        int index = this.myIndex;
        this.myIndex = -1;
        Vector2 origin = new Vector2((float) this.myRect.Width, (float) this.myRect.Height) / 2f;
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos, new Rectangle?(this.myRect), Color.White, 0.0f, origin, 1.1f, SpriteEffects.None, 0.0f);
        if (!this.sc.usingMouse)
        {
          if (this.updownIndex == 0)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[3] + new Vector2(-35f, 0.0f), new Rectangle?(this.biggerboxRect), this.bluePen);
          if (this.updownIndex == 1)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[4] + new Vector2(-75f, 0.0f), new Rectangle?(this.biggerboxRect), this.bluePen);
          if (this.updownIndex == 2)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[5] + new Vector2(-35f, 0.0f), new Rectangle?(this.biggerboxRect), this.bluePen);
          if (this.updownIndex == 3)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[31] + new Vector2(-35f, 0.0f), new Rectangle?(this.biggerboxRect), this.bluePen);
        }
        string text26 = "super ammo";
        this.spriteBatch.DrawString(this.scribbleFont, text26, this.paperPos - this.scribbleFont.MeasureString(text26) / 2f + this.vec[0], this.bluePen);
        string text27 = "invincible";
        this.spriteBatch.DrawString(this.scribbleFont, text27, this.paperPos - this.scribbleFont.MeasureString(text27) / 2f + this.vec[1], this.bluePen);
        string text28 = "all weapons";
        this.spriteBatch.DrawString(this.scribbleFont, text28, this.paperPos - this.scribbleFont.MeasureString(text28) / 2f + this.vec[2], this.bluePen);
        string text29 = "unlock days";
        this.spriteBatch.DrawString(this.scribbleFont, text29, this.paperPos - this.scribbleFont.MeasureString(text29) / 2f + this.vec[30], this.bluePen);
        astrobindings.b1.Length = 0;
        astrobindings.b1.Concat(this.slider1);
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos + this.vec[6] + new Vector2(0.0f, -28f), new Rectangle?(this.littleboxRect), Color.White);
        this.queryButton(this.littleboxRect, this.paperPos + this.vec[6] + new Vector2(0.0f, -28f), 0);
        if (this.myIndex == 0)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos + this.vec[6] + new Vector2(0.0f, -28f), new Rectangle?(this.littleglowRect), Color.White);
        if (this.slider1 == 1)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos + this.vec[6] + new Vector2(7f, -35f), new Rectangle?(this.checkmarkRect), Color.White);
        astrobindings.b1.Length = 0;
        astrobindings.b1.Concat(this.slider2);
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos + this.vec[7] + new Vector2(-40f, -28f), new Rectangle?(this.littleboxRect), Color.White);
        this.queryButton(this.littleboxRect, this.paperPos + this.vec[7] + new Vector2(-40f, -28f), 1);
        if (this.myIndex == 1)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos + this.vec[7] + new Vector2(-40f, -28f), new Rectangle?(this.littleglowRect), Color.White);
        if (this.slider2 == 1)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos + this.vec[7] + new Vector2(-33f, -35f), new Rectangle?(this.checkmarkRect), Color.White);
        astrobindings.b1.Length = 0;
        astrobindings.b1.Concat(this.slider3);
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos + this.vec[8] + new Vector2(0.0f, -28f), new Rectangle?(this.littleboxRect), Color.White);
        this.queryButton(this.littleboxRect, this.paperPos + this.vec[8] + new Vector2(0.0f, -28f), 2);
        if (this.myIndex == 2)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos + this.vec[8] + new Vector2(0.0f, -28f), new Rectangle?(this.littleglowRect), Color.White);
        if (this.slider3 == 1)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos + this.vec[8] + new Vector2(7f, -35f), new Rectangle?(this.checkmarkRect), Color.White);
        astrobindings.b1.Length = 0;
        astrobindings.b1.Concat(this.slider4);
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos + this.vec[32] + new Vector2(0.0f, -28f), new Rectangle?(this.littleboxRect), Color.White);
        this.queryButton(this.littleboxRect, this.paperPos + this.vec[32] + new Vector2(0.0f, -28f), 3);
        if (this.myIndex == 3)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos + this.vec[32] + new Vector2(0.0f, -28f), new Rectangle?(this.littleglowRect), Color.White);
        if (this.slider4 == 1)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos + this.vec[32] + new Vector2(7f, -35f), new Rectangle?(this.checkmarkRect), Color.White);
        if (index != this.myIndex && this.myIndex != -1)
          this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
      }
      if (this.choice == "hidden")
      {
        Vector2 origin = new Vector2((float) this.myRect.Width, (float) this.myRect.Height) / 2f;
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos, new Rectangle?(this.myRect), new Color((int) byte.MaxValue, 200, 200), this.rot, origin, 1.1f, SpriteEffects.None, 0.0f);
        if (this.updownIndex == 0)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[0], new Rectangle?(this.bigboxRect), this.bluePen);
        if (this.updownIndex == 1)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[1], new Rectangle?(this.bigboxRect), this.bluePen);
        if (this.updownIndex == 2)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[2], new Rectangle?(this.bigboxRect), this.bluePen);
        if (this.updownIndex == 3)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[3], new Rectangle?(this.bigboxRect), this.bluePen);
        string text30 = "networking";
        this.spriteBatch.DrawString(this.scribbleFont, text30, this.paperPos - this.scribbleFont.MeasureString(text30) / 2f + this.vec[4], this.bluePen);
        string text31 = "debugging";
        this.spriteBatch.DrawString(this.scribbleFont, text31, this.paperPos - this.scribbleFont.MeasureString(text31) / 2f + this.vec[5], this.bluePen);
        string text32 = "level edit";
        this.spriteBatch.DrawString(this.scribbleFont, text32, this.paperPos - this.scribbleFont.MeasureString(text32) / 2f + this.vec[7], this.bluePen);
        string text33 = "cheat mode";
        this.spriteBatch.DrawString(this.scribbleFont, text33, this.paperPos - this.scribbleFont.MeasureString(text33) / 2f + this.vec[6], this.bluePen);
      }
      if (this.choice == "networking")
      {
        Vector2 origin = new Vector2((float) this.myRect.Width, (float) this.myRect.Height) / 2f;
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos, new Rectangle?(this.myRect), new Color((int) byte.MaxValue, 200, 200), this.rot, origin, 1.25f, SpriteEffects.None, 0.0f);
        if (this.updownIndex == 0)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[0], new Rectangle?(this.biggerboxRect), this.bluePen);
        if (this.updownIndex == 1)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[1], new Rectangle?(this.biggerboxRect), this.bluePen);
        if (this.updownIndex == 2)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[2], new Rectangle?(this.biggerboxRect), this.bluePen);
        string text34 = "show data";
        this.spriteBatch.DrawString(this.scribbleFont, text34, this.paperPos - this.scribbleFont.MeasureString(text34) / 2f + this.vec[3], this.bluePen);
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[4], new Rectangle?(this.littleboxRect), Color.White);
        if (this.slider1 == 1)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[5], new Rectangle?(this.checkmarkRect), Color.White);
        string text35 = "pack delay";
        this.spriteBatch.DrawString(this.scribbleFont, text35, this.paperPos - this.scribbleFont.MeasureString(text35) / 2f + this.vec[6], this.bluePen);
        string text36 = this.sc.lag[this.slider2].ToString();
        this.spriteBatch.DrawString(this.scribbleFont, text36, this.paperPos - this.scribbleFont.MeasureString(text36) / 2f + this.vec[7], this.bluePen);
        string text37 = "pack loss";
        this.spriteBatch.DrawString(this.scribbleFont, text37, this.paperPos - this.scribbleFont.MeasureString(text37) / 2f + this.vec[8], this.bluePen);
        string text38 = ((int) ((double) this.sc.loss[this.slider2] * 100.0)).ToString() + "%";
        this.spriteBatch.DrawString(this.scribbleFont, text38, this.paperPos - this.scribbleFont.MeasureString(text38) / 2f + this.vec[9], this.bluePen);
        string text39 = "okay";
        this.spriteBatch.DrawString(this.scribbleFont, text39, this.paperPos - this.scribbleFont.MeasureString(text39) / 2f + this.vec[10], this.bluePen);
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[11], new Rectangle?(this.rectangle_6), Color.White);
      }
      if (this.choice == "debugging")
      {
        Vector2 origin = new Vector2((float) this.myRect.Width, (float) this.myRect.Height) / 2f;
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos, new Rectangle?(this.myRect), new Color((int) byte.MaxValue, 200, 200), this.rot, origin, 1.25f, SpriteEffects.None, 0.0f);
        if (this.updownIndex == 0)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[0], new Rectangle?(this.biggerboxRect), this.bluePen);
        if (this.updownIndex == 1)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[1], new Rectangle?(this.biggerboxRect), this.bluePen);
        if (this.updownIndex == 2)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[2], new Rectangle?(this.biggerboxRect), this.bluePen);
        if (this.updownIndex == 3)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[3], new Rectangle?(this.biggerboxRect), this.bluePen);
        string text40 = "Garbage";
        this.spriteBatch.DrawString(this.scribbleFont, text40, this.paperPos - this.scribbleFont.MeasureString(text40) / 2f + this.vec[4], this.bluePen);
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[5], new Rectangle?(this.littleboxRect), Color.White);
        if (this.slider1 == 1)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[6], new Rectangle?(this.checkmarkRect), Color.White);
        string text41 = "Seed #";
        this.spriteBatch.DrawString(this.scribbleFont, text41, this.paperPos - this.scribbleFont.MeasureString(text41) / 2f + this.vec[7], this.bluePen);
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[8], new Rectangle?(this.littleboxRect), Color.White);
        if (this.slider2 == 1)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[9], new Rectangle?(this.checkmarkRect), Color.White);
        string text42 = "Accuracy";
        this.spriteBatch.DrawString(this.scribbleFont, text42, this.paperPos - this.scribbleFont.MeasureString(text42) / 2f + this.vec[10], this.bluePen);
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[11], new Rectangle?(this.littleboxRect), Color.White);
        if (this.slider3 == 1)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[12], new Rectangle?(this.checkmarkRect), Color.White);
        string text43 = "Homing";
        this.spriteBatch.DrawString(this.scribbleFont, text43, this.paperPos - this.scribbleFont.MeasureString(text43) / 2f + this.vec[13], this.bluePen);
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[14], new Rectangle?(this.littleboxRect), Color.White);
        if (this.slider4 == 1)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[15], new Rectangle?(this.checkmarkRect), Color.White);
        string text44 = "okay";
        this.spriteBatch.DrawString(this.scribbleFont, text44, this.paperPos - this.scribbleFont.MeasureString(text44) / 2f + this.vec[16], this.bluePen);
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[17], new Rectangle?(this.rectangle_6), Color.White);
      }
      if (this.choice == "cheat mode")
      {
        this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, (SamplerState) null, (DepthStencilState) null, astrobindings.clipit);
        Vector2 vector2 = new Vector2((float) this.myRect.Width, (float) this.myRect.Height) / 2f;
        if (this.updownIndex == 0)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - vector2 + this.vec[0], new Rectangle?(this.biggerboxRect), this.bluePen);
        if (this.updownIndex == 1)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - vector2 + this.vec[1], new Rectangle?(this.biggerboxRect), this.bluePen);
        if (this.updownIndex == 2)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - vector2 + this.vec[2], new Rectangle?(this.biggerboxRect), this.bluePen);
        if (this.updownIndex == 3)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - vector2 + this.vec[3], new Rectangle?(this.biggerboxRect), this.bluePen);
        if (this.updownIndex == 4)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - vector2 + this.vec[4], new Rectangle?(this.biggerboxRect), this.bluePen);
        string text45 = "Invincible";
        this.spriteBatch.DrawString(this.scribbleFont, text45, this.paperPos - this.scribbleFont.MeasureString(text45) / 2f + this.vec[5], this.bluePen);
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos - vector2 + this.vec[6], new Rectangle?(this.littleboxRect), Color.White);
        if (this.slider1 == 1)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - vector2 + this.vec[7], new Rectangle?(this.checkmarkRect), Color.White);
        string text46 = "fastfiring";
        this.spriteBatch.DrawString(this.scribbleFont, text46, this.paperPos - this.scribbleFont.MeasureString(text46) / 2f + this.vec[8], this.bluePen);
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos - vector2 + this.vec[9], new Rectangle?(this.littleboxRect), Color.White);
        if (this.slider2 == 1)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - vector2 + this.vec[10], new Rectangle?(this.checkmarkRect), Color.White);
        string text47 = "superAmmo";
        this.spriteBatch.DrawString(this.scribbleFont, text47, this.paperPos - this.scribbleFont.MeasureString(text47) / 2f + this.vec[11], this.bluePen);
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos - vector2 + this.vec[12], new Rectangle?(this.littleboxRect), Color.White);
        if (this.slider3 == 1)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - vector2 + this.vec[13], new Rectangle?(this.checkmarkRect), Color.White);
        string text48 = "allExplode";
        this.spriteBatch.DrawString(this.scribbleFont, text48, this.paperPos - this.scribbleFont.MeasureString(text48) / 2f + this.vec[14], this.bluePen);
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos - vector2 + this.vec[15], new Rectangle?(this.littleboxRect), Color.White);
        if (this.slider4 == 1)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - vector2 + this.vec[16], new Rectangle?(this.checkmarkRect), Color.White);
        string text49 = "pickupPack";
        this.spriteBatch.DrawString(this.scribbleFont, text49, this.paperPos - this.scribbleFont.MeasureString(text49) / 2f + this.vec[17], this.bluePen);
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos - vector2 + this.vec[18], new Rectangle?(this.littleboxRect), Color.White);
        if (this.slider5 == 1)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - vector2 + this.vec[19], new Rectangle?(this.checkmarkRect), Color.White);
        string text50 = "Send";
        this.spriteBatch.DrawString(this.scribbleFont, text50, this.paperPos - this.scribbleFont.MeasureString(text50) / 2f + this.vec[20], this.bluePen);
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos - vector2 + this.vec[21], new Rectangle?(this.rectangle_6), Color.White);
      }
      if (this.choice == "level edit")
      {
        Vector2 origin = new Vector2((float) this.narrowRect.Width, (float) this.narrowRect.Height) / 2f;
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos + new Vector2(0.0f, 20f), new Rectangle?(this.narrowRect), new Color((int) byte.MaxValue, 200, 200), this.rot, origin, 2.4f, SpriteEffects.None, 0.0f);
        Color bluePen = this.bluePen;
        Color color7 = new Color((int) byte.MaxValue, 40, 40, (int) byte.MaxValue);
        if (this.updownIndex <= 10)
        {
          if (this.updownIndex == 0)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[0], new Rectangle?(this.longboxRect), this.bluePen);
          else if (this.updownIndex == 1)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[1], new Rectangle?(this.longboxRect), this.bluePen);
          else if (this.updownIndex == 2)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[2], new Rectangle?(this.longboxRect), this.bluePen);
          else if (this.updownIndex == 3)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[3], new Rectangle?(this.longboxRect), this.bluePen);
          else if (this.updownIndex == 4)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[4], new Rectangle?(this.longboxRect), this.bluePen);
          else if (this.updownIndex == 5)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[5], new Rectangle?(this.longboxRect), this.bluePen);
          else if (this.updownIndex == 6)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[6], new Rectangle?(this.longboxRect), this.bluePen);
          else if (this.updownIndex == 7)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[7], new Rectangle?(this.longboxRect), this.bluePen);
          else if (this.updownIndex == 8)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[8], new Rectangle?(this.longboxRect), this.bluePen);
          else if (this.updownIndex == 9)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[9], new Rectangle?(this.longboxRect), this.bluePen);
          else if (this.updownIndex == 10)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[10], new Rectangle?(this.longboxRect), this.bluePen);
          Color color8 = this.bluePen;
          if (this.updownIndex == 0)
            color8 = color7;
          string text51 = "Day or Night";
          this.spriteBatch.DrawString(this.scribbleFont, text51, this.paperPos - this.scribbleFont.MeasureString(text51) / 2f + this.vec[11], color8);
          string text52 = new string[2]{ "am", "pm" }[this.slider1];
          this.spriteBatch.DrawString(this.scribbleFont, text52, this.paperPos - this.scribbleFont.MeasureString(text52) / 2f + this.vec[12], color8);
          Color color9 = this.bluePen;
          if (this.updownIndex == 1)
            color9 = color7;
          string text53 = "SpawnArea";
          this.spriteBatch.DrawString(this.scribbleFont, text53, this.paperPos - this.scribbleFont.MeasureString(text53) / 2f + this.vec[13], color9);
          string[] strArray = new string[23]
          {
            "center",
            "borders",
            "grinder",
            "barn",
            "silos",
            "corner",
            "powerbox",
            "northLine",
            "southLine",
            "WestLine",
            "EastLine",
            "P1.1",
            "P2.1",
            "P4.1",
            "P4.2",
            "P1.3",
            "P4.3",
            "P2.4",
            "none",
            "none",
            "centBigX",
            "centTinyX",
            "borderX"
          };
          string text54 = this.slider2 <= strArray.Length - 1 ? strArray[this.slider2] : "xxx";
          this.spriteBatch.DrawString(this.scribbleFont, text54, this.paperPos - this.scribbleFont.MeasureString(text54) / 2f + this.vec[14], color9);
          Color color10 = this.bluePen;
          if (this.updownIndex == 2)
            color10 = color7;
          string text55 = "Boar Count";
          this.spriteBatch.DrawString(this.scribbleFont, text55, this.paperPos - this.scribbleFont.MeasureString(text55) / 2f + this.vec[15], color10);
          string text56 = this.slider3.ToString() + " x";
          this.spriteBatch.DrawString(this.scribbleFont, text56, this.paperPos - this.scribbleFont.MeasureString(text56) / 2f + this.vec[16], color10);
          Color color11 = this.bluePen;
          if (this.updownIndex == 3)
            color11 = color7;
          string text57 = "Boar Health";
          this.spriteBatch.DrawString(this.scribbleFont, text57, this.paperPos - this.scribbleFont.MeasureString(text57) / 2f + this.vec[17], color11);
          string text58 = this.slider4.ToString() + "%";
          this.spriteBatch.DrawString(this.scribbleFont, text58, this.paperPos - this.scribbleFont.MeasureString(text58) / 2f + this.vec[18], color11);
          Color color12 = this.bluePen;
          if (this.updownIndex == 4)
            color12 = color7;
          string text59 = "Boar Attack";
          this.spriteBatch.DrawString(this.scribbleFont, text59, this.paperPos - this.scribbleFont.MeasureString(text59) / 2f + this.vec[19], color12);
          string text60 = this.slider5.ToString() + "%";
          this.spriteBatch.DrawString(this.scribbleFont, text60, this.paperPos - this.scribbleFont.MeasureString(text60) / 2f + this.vec[20], color12);
          Color color13 = this.bluePen;
          if (this.updownIndex == 5)
            color13 = color7;
          string text61 = "Boar MinSize";
          this.spriteBatch.DrawString(this.scribbleFont, text61, this.paperPos - this.scribbleFont.MeasureString(text61) / 2f + this.vec[21], color13);
          string text62 = this.slider6.ToString();
          this.spriteBatch.DrawString(this.scribbleFont, text62, this.paperPos - this.scribbleFont.MeasureString(text62) / 2f + this.vec[22], color13);
          Color color14 = this.bluePen;
          if (this.updownIndex == 6)
            color14 = color7;
          string text63 = "Boar MaxSize";
          this.spriteBatch.DrawString(this.scribbleFont, text63, this.paperPos - this.scribbleFont.MeasureString(text63) / 2f + this.vec[23], color14);
          string text64 = this.slider7.ToString();
          this.spriteBatch.DrawString(this.scribbleFont, text64, this.paperPos - this.scribbleFont.MeasureString(text64) / 2f + this.vec[24], color14);
          Color color15 = this.bluePen;
          if (this.updownIndex == 7)
            color15 = color7;
          string text65 = "Giant Odds";
          this.spriteBatch.DrawString(this.scribbleFont, text65, this.paperPos - this.scribbleFont.MeasureString(text65) / 2f + this.vec[25], color15);
          string text66 = this.slider8.ToString() + "%";
          this.spriteBatch.DrawString(this.scribbleFont, text66, this.paperPos - this.scribbleFont.MeasureString(text66) / 2f + this.vec[26], color15);
          Color color16 = this.bluePen;
          if (this.updownIndex == 8)
            color16 = color7;
          string text67 = "Tiny Odds";
          this.spriteBatch.DrawString(this.scribbleFont, text67, this.paperPos - this.scribbleFont.MeasureString(text67) / 2f + this.vec[27], color16);
          string text68 = this.slider9.ToString() + "%";
          this.spriteBatch.DrawString(this.scribbleFont, text68, this.paperPos - this.scribbleFont.MeasureString(text68) / 2f + this.vec[28], color16);
          Color color17 = this.bluePen;
          if (this.updownIndex == 9)
            color17 = color7;
          string text69 = "AttackSpeed";
          this.spriteBatch.DrawString(this.scribbleFont, text69, this.paperPos - this.scribbleFont.MeasureString(text69) / 2f + this.vec[29], color17);
          string text70 = this.slider10.ToString() + "%";
          this.spriteBatch.DrawString(this.scribbleFont, text70, this.paperPos - this.scribbleFont.MeasureString(text70) / 2f + this.vec[30], color17);
          Color color18 = this.bluePen;
          if (this.updownIndex == 10)
            color18 = color7;
          string text71 = "TurningRate";
          this.spriteBatch.DrawString(this.scribbleFont, text71, this.paperPos - this.scribbleFont.MeasureString(text71) / 2f + this.vec[31], color18);
          string text72 = this.slider11.ToString() + "%";
          this.spriteBatch.DrawString(this.scribbleFont, text72, this.paperPos - this.scribbleFont.MeasureString(text72) / 2f + this.vec[32], color18);
          string text73 = "Next Page";
          this.spriteBatch.DrawString(this.scribbleFont, text73, this.paperPos - this.scribbleFont.MeasureString(text73) / 2f + this.vec[33], this.bluePen);
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[34], new Rectangle?(this.rectangle_6), Color.White);
        }
        else
        {
          if (this.updownIndex == 11)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[35], new Rectangle?(this.longboxRect), this.bluePen);
          else if (this.updownIndex == 12)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[36], new Rectangle?(this.longboxRect), this.bluePen);
          else if (this.updownIndex == 13)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[37], new Rectangle?(this.longboxRect), this.bluePen);
          else if (this.updownIndex == 14)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[38], new Rectangle?(this.longboxRect), this.bluePen);
          else if (this.updownIndex == 15)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[39], new Rectangle?(this.longboxRect), this.bluePen);
          else if (this.updownIndex == 16)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[40], new Rectangle?(this.longboxRect), this.bluePen);
          else if (this.updownIndex == 17)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[41], new Rectangle?(this.longboxRect), this.bluePen);
          else if (this.updownIndex == 18)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[42], new Rectangle?(this.longboxRect), this.bluePen);
          else if (this.updownIndex == 19)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[43], new Rectangle?(this.longboxRect), this.bluePen);
          else if (this.updownIndex == 20)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[44], new Rectangle?(this.longboxRect), this.bluePen);
          else if (this.updownIndex == 21)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[45], new Rectangle?(this.longboxRect), this.bluePen);
          else if (this.updownIndex == 22)
            this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[46], new Rectangle?(this.longboxRect), this.bluePen);
          Color color19 = this.bluePen;
          if (this.updownIndex == 11)
            color19 = color7;
          string text74 = "90% Radius";
          this.spriteBatch.DrawString(this.scribbleFont, text74, this.paperPos - this.scribbleFont.MeasureString(text74) / 2f + this.vec[47], color19);
          string text75 = this.slider12.ToString();
          this.spriteBatch.DrawString(this.scribbleFont, text75, this.paperPos - this.scribbleFont.MeasureString(text75) / 2f + this.vec[48], color19);
          Color color20 = this.bluePen;
          if (this.updownIndex == 12)
            color20 = color7;
          string text76 = "90% Homing";
          this.spriteBatch.DrawString(this.scribbleFont, text76, this.paperPos - this.scribbleFont.MeasureString(text76) / 2f + this.vec[49], color20);
          string text77 = this.slider13.ToString();
          this.spriteBatch.DrawString(this.scribbleFont, text77, this.paperPos - this.scribbleFont.MeasureString(text77) / 2f + this.vec[50], color20);
          Color color21 = this.bluePen;
          if (this.updownIndex == 13)
            color21 = color7;
          string text78 = "75% Radius";
          this.spriteBatch.DrawString(this.scribbleFont, text78, this.paperPos - this.scribbleFont.MeasureString(text78) / 2f + this.vec[51], color21);
          string text79 = this.slider14.ToString();
          this.spriteBatch.DrawString(this.scribbleFont, text79, this.paperPos - this.scribbleFont.MeasureString(text79) / 2f + this.vec[52], color21);
          Color color22 = this.bluePen;
          if (this.updownIndex == 14)
            color22 = color7;
          string text80 = "75% Homing";
          this.spriteBatch.DrawString(this.scribbleFont, text80, this.paperPos - this.scribbleFont.MeasureString(text80) / 2f + this.vec[53], color22);
          string text81 = this.slider15.ToString();
          this.spriteBatch.DrawString(this.scribbleFont, text81, this.paperPos - this.scribbleFont.MeasureString(text81) / 2f + this.vec[54], color22);
          Color color23 = this.bluePen;
          if (this.updownIndex == 15)
            color23 = color7;
          string text82 = "50% Radius";
          this.spriteBatch.DrawString(this.scribbleFont, text82, this.paperPos - this.scribbleFont.MeasureString(text82) / 2f + this.vec[55], color23);
          string text83 = this.slider16.ToString();
          this.spriteBatch.DrawString(this.scribbleFont, text83, this.paperPos - this.scribbleFont.MeasureString(text83) / 2f + this.vec[56], color23);
          Color color24 = this.bluePen;
          if (this.updownIndex == 16)
            color24 = color7;
          string text84 = "50% Homing";
          this.spriteBatch.DrawString(this.scribbleFont, text84, this.paperPos - this.scribbleFont.MeasureString(text84) / 2f + this.vec[57], color24);
          string text85 = this.slider17.ToString();
          this.spriteBatch.DrawString(this.scribbleFont, text85, this.paperPos - this.scribbleFont.MeasureString(text85) / 2f + this.vec[58], color24);
          Color color25 = this.bluePen;
          if (this.updownIndex == 17)
            color25 = color7;
          string text86 = "30% Radius";
          this.spriteBatch.DrawString(this.scribbleFont, text86, this.paperPos - this.scribbleFont.MeasureString(text86) / 2f + this.vec[59], color25);
          string text87 = this.slider18.ToString();
          this.spriteBatch.DrawString(this.scribbleFont, text87, this.paperPos - this.scribbleFont.MeasureString(text87) / 2f + this.vec[60], color25);
          Color color26 = this.bluePen;
          if (this.updownIndex == 18)
            color26 = color7;
          string text88 = "30% Homing";
          this.spriteBatch.DrawString(this.scribbleFont, text88, this.paperPos - this.scribbleFont.MeasureString(text88) / 2f + this.vec[61], color26);
          string text89 = this.slider19.ToString();
          this.spriteBatch.DrawString(this.scribbleFont, text89, this.paperPos - this.scribbleFont.MeasureString(text89) / 2f + this.vec[62], color26);
          Color color27 = this.bluePen;
          if (this.updownIndex == 19)
            color27 = color7;
          string text90 = "20% Radius";
          this.spriteBatch.DrawString(this.scribbleFont, text90, this.paperPos - this.scribbleFont.MeasureString(text90) / 2f + this.vec[63], color27);
          string text91 = this.slider20.ToString();
          this.spriteBatch.DrawString(this.scribbleFont, text91, this.paperPos - this.scribbleFont.MeasureString(text91) / 2f + this.vec[64], color27);
          Color color28 = this.bluePen;
          if (this.updownIndex == 20)
            color28 = color7;
          string text92 = "20% Homing";
          this.spriteBatch.DrawString(this.scribbleFont, text92, this.paperPos - this.scribbleFont.MeasureString(text92) / 2f + this.vec[65], color28);
          string text93 = this.slider21.ToString();
          this.spriteBatch.DrawString(this.scribbleFont, text93, this.paperPos - this.scribbleFont.MeasureString(text93) / 2f + this.vec[66], color28);
          Color color29 = this.bluePen;
          if (this.updownIndex == 21)
            color29 = color7;
          string text94 = "00% Radius";
          this.spriteBatch.DrawString(this.scribbleFont, text94, this.paperPos - this.scribbleFont.MeasureString(text94) / 2f + this.vec[67], color29);
          string text95 = this.slider22.ToString();
          this.spriteBatch.DrawString(this.scribbleFont, text95, this.paperPos - this.scribbleFont.MeasureString(text95) / 2f + this.vec[68], color29);
          Color color30 = this.bluePen;
          if (this.updownIndex == 22)
            color30 = color7;
          string text96 = "00% Homing";
          this.spriteBatch.DrawString(this.scribbleFont, text96, this.paperPos - this.scribbleFont.MeasureString(text96) / 2f + this.vec[69], color30);
          string text97 = this.slider23.ToString();
          this.spriteBatch.DrawString(this.scribbleFont, text97, this.paperPos - this.scribbleFont.MeasureString(text97) / 2f + this.vec[70], color30);
          string text98 = "Prev";
          this.spriteBatch.DrawString(this.scribbleFont, text98, this.paperPos - this.scribbleFont.MeasureString(text98) / 2f + this.vec[71], this.bluePen);
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[72], new Rectangle?(this.rectangle_7), Color.White);
          string text99 = "Save";
          this.spriteBatch.DrawString(this.scribbleFont, text99, this.paperPos - this.scribbleFont.MeasureString(text99) / 2f + this.vec[73], this.bluePen);
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[74], new Rectangle?(this.rectangle_6), Color.White);
        }
      }
      if (this.choice == "moon")
      {
        Vector2 origin = new Vector2((float) this.myRect.Width, (float) this.myRect.Height) / 2f;
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos, new Rectangle?(this.myRect), new Color((int) byte.MaxValue, 200, 200), this.rot, origin, 1.25f, SpriteEffects.None, 0.0f);
        if (this.updownIndex == 0)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[0], new Rectangle?(this.biggerboxRect), this.bluePen);
        if (this.updownIndex == 1)
          this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[1], new Rectangle?(this.biggerboxRect), this.bluePen);
        string text100 = "Darkness ";
        this.spriteBatch.DrawString(this.scribbleFont, text100, this.paperPos - this.scribbleFont.MeasureString(text100) / 2f + this.vec[2], this.bluePen);
        string text101 = this.slider1.ToString();
        this.spriteBatch.DrawString(this.scribbleFont, text101, this.paperPos - this.scribbleFont.MeasureString(text101) / 2f + this.vec[3], this.bluePen);
        string text102 = new string[9]
        {
          "northDark",
          "northGlow",
          "northBrite",
          "southDark",
          "southGlow",
          "southBrite",
          "westDark",
          "westGlow",
          "westBrite"
        }[this.slider2].ToString();
        this.spriteBatch.DrawString(this.scribbleFont, text102, this.paperPos - this.scribbleFont.MeasureString(text102) / 2f + this.vec[5], this.bluePen);
        string text103 = "okay";
        this.spriteBatch.DrawString(this.scribbleFont, text103, this.paperPos - this.scribbleFont.MeasureString(text103) / 2f + this.vec[6], this.bluePen);
        this.spriteBatch.Draw(this.sc.paper1, this.paperPos - origin + this.vec[7], new Rectangle?(this.rectangle_6), Color.White);
      }
      this.spriteBatch.End();
    }

    public void queryButton(Rectangle rr, Vector2 vv, int ch)
    {
      rr = new Rectangle((int) vv.X, (int) vv.Y, rr.Width, rr.Height);
      rr = new Rectangle(rr.X + 5, rr.Y + 5, rr.Width - 10, rr.Height - 10);
      Vector2 mm = this.mm;
      if ((double) this.sc.aspectratio <= 1.0)
        mm.Y -= (float) (((double) this.sc.screenSize.Height - (double) this.sc.screenSize.Height * (double) this.sc.aspectratio) * (0.5 / (double) this.sc.aspectratio));
      else
        mm.X -= (float) (((double) this.sc.screenSize.Width - (double) this.sc.screenSize.Width / (double) this.sc.aspectratio) * (0.5 * (double) this.sc.aspectratio));
      Vector2 vector2_1 = this.scc * new Vector2((float) this.sc.screenSize.Width / (float) this.sc.origSize.Width, (float) this.sc.screenSize.Height / (float) this.sc.origSize.Height);
      Vector2 vector2_2 = mm / vector2_1;
      if (((double) vector2_2.Y <= (double) rr.Y || (double) vector2_2.Y > (double) (rr.Y + rr.Height) || (double) vector2_2.X <= (double) rr.X ? 0 : ((double) vector2_2.X <= (double) (rr.X + rr.Width) ? 1 : 0)) == 0)
        return;
      this.myIndex = ch;
    }

    public void queryButtonX(Rectangle rr, Vector2 vv, int ch)
    {
      rr = new Rectangle((int) vv.X, (int) vv.Y, rr.Width, rr.Height);
      Vector2 mm = this.mm;
      if ((double) this.sc.aspectratio <= 1.0)
        mm.Y -= (float) (((double) this.sc.screenSize.Height - (double) this.sc.screenSize.Height * (double) this.sc.aspectratio) * (0.5 / (double) this.sc.aspectratio));
      else
        mm.X -= (float) (((double) this.sc.screenSize.Width - (double) this.sc.screenSize.Width / (double) this.sc.aspectratio) * (0.5 * (double) this.sc.aspectratio));
      Vector2 vector2_1 = this.scc * new Vector2((float) this.sc.screenSize.Width / (float) this.sc.origSize.Width, (float) this.sc.screenSize.Height / (float) this.sc.origSize.Height);
      Vector2 vector2_2 = mm / vector2_1;
      if (((double) vector2_2.Y <= (double) rr.Y || (double) vector2_2.Y > (double) (rr.Y + rr.Height) || (double) vector2_2.X <= (double) rr.X ? 0 : ((double) vector2_2.X <= (double) (rr.X + rr.Width) ? 1 : 0)) == 0)
        return;
      this.myIndex = ch;
    }

    public void queryButton2(Rectangle rr, Vector2 vv, int ch)
    {
      rr = new Rectangle((int) vv.X, (int) vv.Y, rr.Width, rr.Height);
      Vector2 mm = this.mm;
      if ((double) this.sc.aspectratio <= 1.0)
        mm.Y -= (float) (((double) this.sc.screenSize.Height - (double) this.sc.screenSize.Height * (double) this.sc.aspectratio) * (0.5 / (double) this.sc.aspectratio));
      else
        mm.X -= (float) (((double) this.sc.screenSize.Width - (double) this.sc.screenSize.Width / (double) this.sc.aspectratio) * (0.5 * (double) this.sc.aspectratio));
      Vector2 vector2_1 = 1f * new Vector2((float) this.sc.screenSize.Width / (float) this.sc.origSize.Width, (float) this.sc.screenSize.Height / (float) this.sc.origSize.Height);
      Vector2 vector2_2 = mm / vector2_1;
      if (((double) vector2_2.Y <= (double) rr.Y || (double) vector2_2.Y > (double) (rr.Y + rr.Height) || (double) vector2_2.X <= (double) rr.X ? 0 : ((double) vector2_2.X <= (double) (rr.X + rr.Width) ? 1 : 0)) == 0)
        return;
      this.myIndex = ch;
    }

    public Vector2 adjustMouse()
    {
      Vector2 mm = this.mm;
      if ((double) this.sc.aspectratio <= 1.0)
        mm.Y -= (float) (((double) this.sc.screenSize.Height - (double) this.sc.screenSize.Height * (double) this.sc.aspectratio) * (0.5 / (double) this.sc.aspectratio));
      else
        mm.X -= (float) (((double) this.sc.screenSize.Width - (double) this.sc.screenSize.Width / (double) this.sc.aspectratio) * (0.5 * (double) this.sc.aspectratio));
      Vector2 vector2 = this.scc * new Vector2((float) this.sc.screenSize.Width / (float) this.sc.origSize.Width, (float) this.sc.screenSize.Height / (float) this.sc.origSize.Height);
      return mm / vector2;
    }

    public Vector2 adjustMouse2()
    {
      Vector2 mm = this.mm;
      if ((double) this.sc.aspectratio <= 1.0)
        mm.Y -= (float) (((double) this.sc.screenSize.Height - (double) this.sc.screenSize.Height * (double) this.sc.aspectratio) * (0.5 / (double) this.sc.aspectratio));
      else
        mm.X -= (float) (((double) this.sc.screenSize.Width - (double) this.sc.screenSize.Width / (double) this.sc.aspectratio) * (0.5 * (double) this.sc.aspectratio));
      Vector2 vector2 = 1f * new Vector2((float) this.sc.screenSize.Width / (float) this.sc.origSize.Width, (float) this.sc.screenSize.Height / (float) this.sc.origSize.Height);
      return mm / vector2;
    }
  }
}
