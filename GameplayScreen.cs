// Decompiled with JetBrains decompiler
// Type: Blood.GameplayScreen
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
using System.Text;
using System.Threading;

#nullable disable
namespace Blood
{
  internal class GameplayScreen : GameScreen
  {
    private const float rotationSpeed = 0.3f;
    private const float moveSpeed = 30f;
    private float flowervol;
    private int flowervolumeTimer;
    private int tragetCount;
    private Vector3 barnloc1;
    private Vector2 xSpace;
    private Vector2 zSpace;
    private int firstsapphire;
    private int firstshale;
    private int firstruby;
    private bool softlockMess1 = true;
    private bool softlockMess2 = true;
    private bool cameditMess1 = true;
    private bool cameditMess2 = true;
    private bool editcam;
    private bool camadjust;
    private Vector2 adj = Vector2.Zero;
    private Rectangle rovercamedit = new Rectangle(0, 0, 404, 346);
    private Rectangle landercamedit = new Rectangle(0, 0, 404, 346);
    private Vector2 menuposition = new Vector2(50f, 150f);
    private Rectangle buttonhalf = new Rectangle(0, 346, 33, 34);
    private Rectangle buttonfill = new Rectangle(35, 346, 33, 34);
    private Rectangle buttonhand = new Rectangle(70, 350, 30, 30);
    private Rectangle buttonchoice = new Rectangle(70, 350, 30, 30);
    private Rectangle buttonzoom = new Rectangle(100, 350, 30, 30);
    private Vector2[] pointbox1 = new Vector2[4]
    {
      new Vector2(330f, 65f),
      new Vector2(330f, 111f),
      new Vector2(330f, 159f),
      new Vector2(330f, 206f)
    };
    public int humanonramp;
    private Vector3 dumpos = Vector3.Zero;
    private Vector3 groundy = Vector3.Zero;
    private Vector3 normalxxx = Vector3.Zero;
    private int waiting;
    private int recruitCount;
    private int rescueCount;
    public GameplayScreen.act emo;
    private int refineRuby;
    private int refineBlue;
    private int refineShale;
    private Effect reflectEffect;
    private Effect muzzleEffect;
    private Effect buildingEffect;
    private Texture2D mountTexture;
    private Texture2D grassTexture;
    private Texture2D texture2D_0;
    private Texture2D buildingShadow;
    private Model heightmodel;
    private int[,] heights = new int[0, 0];
    private Vector3 farmLocation = new Vector3(0.0f, 5f, 0.0f);
    private bool nearfarm;
    private Thread backgroundThread;
    private EventWaitHandle backgroundThreadExit;
    private bool isBusy;
    private bool isDrawing;
    private List<int> loads = new List<int>();
    private int print;
    private string mytext = "none";
    private int roverY = 30;
    private int landerY = 150;
    private int frameRate;
    private int frameCounter;
    private TimeSpan elapsedTime = TimeSpan.Zero;
    private float X;
    private float Y;
    private float W;
    private float X2;
    private float Y2;
    private float W2;
    private Vector3 mercury = new Vector3(1f, 0.95f, 0.87f);
    private Vector3 venus = new Vector3(0.9f, 1f, 0.9f);
    private Vector3 earth = new Vector3(1f, 1f, 0.95f);
    private Vector3 mars = new Vector3(1.1f, 0.8f, 0.7f);
    private Vector3 jupiter = new Vector3(0.9f, 0.8f, 0.7f);
    private Vector3 saturn = new Vector3(0.9f, 0.9f, 0.7f);
    private Vector3 uranus = new Vector3(0.6f, 0.6f, 1.1f);
    private Vector3 neptune = new Vector3(0.5f, 0.8f, 0.9f);
    private Vector3 pluto = new Vector3(0.95f, 1f, 0.9f);
    private Vector3 c10 = new Vector3(0.4f, 0.4f, 0.4f);
    private Vector3[] tinting;
    private Vector3[] chosenBouy = new Vector3[3];
    private Vector3[] colorBouy = new Vector3[3]
    {
      new Vector3(0.8f, 1.2f, 0.9f),
      new Vector3(1.2f, 0.8f, 0.9f),
      new Vector3(0.8f, 0.92f, 1.2f)
    };
    private int[] pulseBouy = new int[3]{ 120, 70, 172 };
    private Effect blurEffect;
    private bool onDropship = true;
    private bool displaymap;
    private float displaymapx;
    private float displaymapz;
    private int myframe;
    private int horntimer;
    private int horncount;
    private int radiotimer;
    private int radiocount;
    private int landNum1 = 1;
    private int landNum2 = 12;
    private int landNum3 = 43;
    private int landNum4 = 67;
    private float surf;
    private Effect mybasic;
    private Texture2D dropshipTexture;
    private Texture2D dropshipLights;
    private Texture2D shieldTexture;
    private Texture2D distortion;
    private float shortclip = 15f;
    private float farclip = 75000f;
    private float shortclip2 = 5f;
    private float farclip2 = 150000f;
    public float val1 = 4580f;
    public float val2 = 4580f;
    private bool atRover;
    private bool atLander;
    private Rectangle rect_Blue = new Rectangle(793, 34, 30, 30);
    private Rectangle rect_Xbutton = new Rectangle(776, 75, 30, 30);
    private Rectangle rect_Abutton = new Rectangle(719, 34, 30, 30);
    private Rectangle rect_Bbutton = new Rectangle(755, 34, 30, 30);
    private Rectangle rect_Wbutton = new Rectangle(991, 34, 30, 30);
    private Rectangle rect_Ybutton = new Rectangle(831, 34, 30, 30);
    private Rectangle rect_Bulb = new Rectangle(871, 34, 30, 30);
    private Rectangle rect_Heart = new Rectangle(828, 110, 37, 34);
    private Rectangle rect_Lock = new Rectangle(910, 34, 30, 30);
    private Rectangle rect_Lock2 = new Rectangle(952, 75, 30, 30);
    private Rectangle rect_Exclaim = new Rectangle(951, 34, 30, 30);
    private Rectangle rect_Exclaim2 = new Rectangle(1031, 81, 44, 39);
    private Rectangle[] rect_choice = new Rectangle[8]
    {
      new Rectangle(1028, 30, 53, 51),
      new Rectangle(1028, 30, 53, 51),
      new Rectangle(909, 74, 32, 32),
      new Rectangle(830, 74, 32, 32),
      new Rectangle(951, 34, 30, 30),
      new Rectangle(994, 75, 30, 30),
      new Rectangle(699, 76, 58, 30),
      new Rectangle(828, 110, 10, 10)
    };
    private bool atFarmer;
    private bool lookatFarmer;
    private bool atPig;
    private bool atBarnDoor;
    private bool atKissing;
    private bool nearAstro;
    private bool viewGrinder;
    private bool nearFlower;
    private bool atPump1;
    private bool atPump2;
    private bool viewPump2;
    private bool viewPump1;
    private int localPump;
    private int int_0 = 12;
    private int int_1 = 12;
    private float waterRamp1;
    private float waterRamp2;
    private bool atLever;
    private int leverLevel;
    private float leverRamp;
    private int leverTimer;
    private int shockDelay;
    private int shatterDelay;
    private int shatterBigCount;
    private static StringBuilder gamertagBuild = new StringBuilder(32, 32);
    private static StringBuilder nearastroBuild = new StringBuilder(64, 64);
    private static StringBuilder closehelpBuild = new StringBuilder(64, 64);
    private static StringBuilder helpingUpBuild = new StringBuilder(64, 64);
    private static StringBuilder atDoorBuild = new StringBuilder(32, 32);
    private static StringBuilder atPump1Build = new StringBuilder(32, 32);
    private static StringBuilder atPump2Build = new StringBuilder(32, 32);
    private static StringBuilder atPumpBusyBuild = new StringBuilder(32, 32);
    private static StringBuilder atgrinderBuild = new StringBuilder(52, 52);
    private static StringBuilder atKissingBuild = new StringBuilder(52, 52);
    private static StringBuilder needbloodBuild = new StringBuilder(32, 32);
    private static StringBuilder reloadBuild = new StringBuilder(32, 32);
    private static StringBuilder atLever1Build = new StringBuilder(44, 44);
    private static StringBuilder atLever2Build = new StringBuilder(44, 44);
    private static StringBuilder atLever3Build = new StringBuilder(44, 44);
    private static StringBuilder atDoorLockedBuild = new StringBuilder(40, 40);
    private static StringBuilder atFarmerBuild = new StringBuilder(40, 40);
    private static StringBuilder pickupMilkBuild = new StringBuilder(40, 40);
    private static StringBuilder pickupAmmoBuild = new StringBuilder(40, 40);
    private static StringBuilder pickupHulkBuild = new StringBuilder(40, 40);
    private static StringBuilder pickupRocketBuild = new StringBuilder(40, 40);
    private static StringBuilder pickupFullBuild = new StringBuilder(40, 40);
    private static StringBuilder pickupGrenBuild = new StringBuilder(40, 40);
    private static StringBuilder pickupPillBuild = new StringBuilder(40, 40);
    private static StringBuilder pickWeaponBuild = new StringBuilder(40, 40);
    private static StringBuilder liftingFriendBuild = new StringBuilder(40, 40);
    private static StringBuilder coltammoBuild = new StringBuilder(40, 40);
    private static StringBuilder akammoBuild = new StringBuilder(40, 40);
    private static StringBuilder akmagBuild = new StringBuilder(40, 40);
    private static StringBuilder memo = new StringBuilder(75, 75);
    private int memoTimer;
    private int memoIcon;
    private static StringBuilder dpad = new StringBuilder(44, 44);
    private int dpadTimer;
    private int dpadCount;
    private static StringBuilder my_stringbuilder = new StringBuilder(64, 64);
    private static StringBuilder myScore = new StringBuilder(32, 32);
    private static StringBuilder remScore = new StringBuilder(32, 32);
    private static StringBuilder pigsalive = new StringBuilder(32, 32);
    private static StringBuilder whatday = new StringBuilder(32, 32);
    private static StringBuilder surviveT = new StringBuilder(12, 12);
    private static StringBuilder survive4 = new StringBuilder(12, 12);
    private static StringBuilder survive3 = new StringBuilder(12, 12);
    private static StringBuilder survive2 = new StringBuilder(12, 12);
    private static StringBuilder survive1 = new StringBuilder(12, 12);
    private static StringBuilder packets = new StringBuilder(64, 64);
    public static StringBuilder stringBuilder_0 = new StringBuilder(32, 32);
    public string stat1 = "";
    public static StringBuilder stringBuilder_1 = new StringBuilder(32, 32);
    public string stat2 = "";
    public static StringBuilder stringBuilder_2 = new StringBuilder(32, 32);
    public string stat3 = "";
    public static StringBuilder stringBuilder_3 = new StringBuilder(32, 32);
    public string stat4 = "";
    public static StringBuilder stringBuilder_4 = new StringBuilder(32, 32);
    public string stat5 = "";
    public static StringBuilder stringBuilder_5 = new StringBuilder(32, 32);
    public string stat6 = "";
    public static StringBuilder messBuild = new StringBuilder(32, 32);
    public string mess = "";
    public static StringBuilder stringBuilder_6 = new StringBuilder(32, 32);
    public string rover1 = "";
    private Model sphere;
    private int cutoff;
    private Matrix starRot = Matrix.CreateRotationX(1.1f) * Matrix.CreateRotationZ(0.5f);
    private Vector3 trnLoctn = Vector3.Zero;
    private Vector3 oldtrnLoctn;
    private Vector3 trnLoctnLast;
    private Vector3 oldtrnLoctn2;
    private Vector3 delta;
    private ContentManager content;
    private Vector3 moonPos = new Vector3(500f, -3000f, 500f);
    private Random random;
    private Vector3 shake = Vector3.Zero;
    private int vibrateRover;
    private float vibrateLander;
    private int vibrateControl;
    private float xx;
    private float zz;
    private float yy = 200f;
    private float rot;
    private float myrotter;
    private int clickradius1 = 2;
    private float clickradius2 = 500f;
    private int landerbuttonindex = 1;
    private int roverbuttonindex = 1;
    private Vector3 sunDir;
    private bool delayinput = true;
    private GamePadState prevstate;
    private PlayerIndex myplayer;
    private GamePadState gamePadState;
    private KeyboardState keyState;
    private KeyboardState prevkeyState;
    private MouseState mouseState;
    private MouseState prevMouse;
    private float mouseX;
    private float mouseY;
    private readonly Vector3 CameraTargetOffset = new Vector3(0.0f, 0.0f, 0.0f);
    private Model stardome;
    private Model darkFog;
    private Model LanderShadow;
    private Model tankShadow;
    private Model bigquad;
    private Model galaxy;
    private Rover rover;
    private Lander lander;
    public Facility facility;
    private Model dropship;
    private Model dropshipShade;
    private Vector3 vector3_0 = Vector3.Zero;
    private BoundingBox dropshipBox;
    private Vector3 DSmax = new Vector3(410.99f, 347f, 819.26f);
    private Vector3 DSmin = new Vector3(-410.99f, -245f, -699.58f);
    private float dropshipAcc = 20f;
    private tmake tmake;
    private MoonSurface surface;
    private Vector3 leg1 = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 leg2 = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 leg3 = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 leg4 = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 lastleg1 = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 lastleg2 = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 lastleg3 = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 lastleg4 = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 lastpos = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 lastlanderpos = new Vector3(0.0f, 0.0f, 0.0f);
    private Matrix projectionMatrix;
    private Matrix longProjection;
    private Matrix longerProjection;
    private Matrix viewMatrix;
    private float lens = 70f;
    private Vector3 aCamtarget;
    private Vector3 aUppy = Vector3.Up;
    private Vector3 bCampos;
    private Vector3 bCamtarget;
    private Vector3 bUppy = Vector3.Up;
    private Vector3 lastCampos = Vector3.Zero;
    private int vehicleindex = 3;
    private Overlay overlay;
    private int musictick;
    private SoundEffectInstance landerEngineI;
    private SoundEffectInstance roverEngineI;
    private SoundEffectInstance dropEngineI;
    private SoundEffectInstance gravelI;
    private SoundEffectInstance overtureInstance;
    private SoundEffectInstance flowerradioInstance;
    private SoundEffectInstance breathing;
    private float breathvol = 0.5f;
    private Effect terrainEffect;
    private Effect shadowEffect;
    private Effect simpEffect;
    private Effect starEffect;
    private SpriteBatch spriteBatch;
    private SpriteBatch starBatch;
    private int numVertices;
    private int numTriangles;
    private Vector3[,] normalData;
    private int[,] heightData;
    private int[,] objectData;
    private int myposx = 1000;
    private int myposz = 1000;
    private Texture2D tt;
    private Texture2D layer1;
    private Texture2D layer2;
    private Texture2D layer3;
    private Texture2D layer4;
    private ParticleSystem skids;
    private ParticleSystem streaks;
    private ParticleSystem dust;
    private SpriteFont font;
    private SpriteFont ammoMedium2;
    private SpriteFont afont1;
    private SpriteFont afont2;
    private SpriteFont afont3;
    private SpriteFont afont4;
    private SpriteFont afont5;
    private SpriteFont afont6;
    private SpriteFont afont7;
    private SpriteFont afont8;
    private SpriteFont[] ammoMedium;
    private int fontindex;
    private int bitmap;
    private int gridscale;
    private int unit;
    private int zgrid;
    private int xgrid;
    private int lastzgrid;
    private int lastxgrid;
    private int whatz;
    private int whatx;
    private int index;
    private Vector3 normal = Vector3.Zero;
    private RenderTarget2D shadowTarget;
    private RenderTarget2D resolveTarget2;
    private RenderTarget2D resolveTarget1;
    private float LensX = 0.14f;
    private float LensZ = -0.03f;
    private float fader = 1f;
    private int myvarIndex;
    private int myvarIndex2;
    private int[] myVar = new int[8]
    {
      3000,
      2,
      10,
      25,
      2,
      6,
      3,
      1
    };
    private int[] myVar2 = new int[4]{ 1, 33, 98, 97 };
    private string[] myString = new string[8]
    {
      "Base",
      "1st Bumps",
      "Valleys",
      "Mountains",
      "1st Dips",
      "2nd Bumps",
      "2nd Dips",
      "TextureDivide"
    };
    private string[] myString2 = new string[4]
    {
      "Texture1",
      "Texture2",
      "Texture3",
      "Texture4"
    };
    private Vector3 ambient;
    private Vector3 diffuse;
    private Vector3 difDay = new Vector3(1f, 1f, 1f);
    private Vector3 ambDay = new Vector3(0.5f, 0.5f, 0.5f);
    private Vector3 difSol = new Vector3(2f, 2f, 2f);
    private Vector3 ambSol = new Vector3(0.18f, 0.18f, 0.18f);
    private Vector3 difSet = new Vector3(0.88f, 0.37f, -0.35f);
    private Vector3 ambSet = new Vector3(0.25f, 0.18f, 0.25f);
    private Vector3 ambNite = new Vector3(0.21f, 0.37f, 0.33f);
    private Vector3 difNite = new Vector3(0.12f, 0.19f, 0.31f);
    private int diffiz = 99;
    private int diffix = 99;
    private Vector2 errorCatch = new Vector2(0.0f, 0.0f);
    private Vector4 bigX = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
    private Vector4 bigZ = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
    private float terrainDivider = 1f;
    private Texture2D starSheet;
    private Plane wallPlane;
    private Vector3[] origRegion1 = new Vector3[5]
    {
      new Vector3(-0.636f, 0.05f, -2.2f),
      new Vector3(0.643f, 0.05f, -2.2f),
      new Vector3(0.498f, 0.0f, -0.007f),
      new Vector3(-0.525f, 0.0f, -0.007f),
      new Vector3(0.0f, 0.05f, -1.5f)
    };
    private Vector3[] bucketRegion1 = new Vector3[5];
    private Matrix inDumper = Matrix.Identity;
    private int totalGems;
    private int gemOffset;
    private gemstruct shale1 = new gemstruct();
    private gemstruct shale2 = new gemstruct();
    private gemstruct shale3 = new gemstruct();
    private rockstruct rock = new rockstruct();
    private InstancedModel chain;
    private Matrix[] ropeTrans;
    private ropeDupe rope;
    private Vector2 gemPOS = new Vector2(0.0f, 0.0f);
    private Vector2 vector2_0 = new Vector2(0.0f, 0.0f);
    private Vector2 vector2_1 = new Vector2(0.0f, 0.0f);
    private float var1;
    private float var2;
    private float var3;
    private float vehicleDistance;
    private float dropshipDistance;
    private float faciltyDistance;
    private Model beacon;
    private buildStars starmap = new buildStars();
    private PresentationParameters pp;
    private int lastAlias;
    private float aspectratio;
    private ScreenManager sc;
    private int[] myradius = new int[5]
    {
      160,
      200,
      440,
      770,
      1500
    };
    private Vector3 campos = new Vector3(975f, 250f, 1650f);
    private Vector3 aCampos = new Vector3(975f, 250f, 1650f);
    private float camhite = 350f;
    private Vector3 oldcampos = new Vector3(975f, 250f, 1650f);
    private bool jumping = true;
    private bool jumpCalled;
    private Vector3 camlookpos;
    private float camradian = 5.15f;
    private float camheight = 3.55f;
    private float oldcamheight = 4f;
    private int stepCount;
    private int stepFlag;
    private float bobber;
    private float mytimer;
    private bool iscamShake;
    private int camShakeTimer;
    private Vector3 camShake;
    public float groundHeight;
    private Vector3 vec;
    public Vector3 fallVec = Vector3.Zero;
    public Vector3 hitVec = Vector3.Zero;
    public float fallLim = 5f;
    private float slopereducer = 1f;
    public float fallPosition;
    public float fallGrav;
    public float gravLim = 4f;
    public float gravLimdown = -8f;
    public float fallAcc = -0.15f;
    private int jumpCount;
    private bool rejump;
    private float doubleJump;
    private float dist;
    private float olddist;
    private float walkspeed;
    private Texture2D blurdot;
    private GameplayScreen.hitStream hitstreamTemp = new GameplayScreen.hitStream();
    private static VertexDeclaration vd2 = new VertexDeclaration(new VertexElement[5]
    {
      new VertexElement(0, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 0),
      new VertexElement(16, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 1),
      new VertexElement(32, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 2),
      new VertexElement(48, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 3),
      new VertexElement(64, VertexElementFormat.Single, VertexElementUsage.Fog, 0)
    });
    private GameplayScreen.hole prints;
    private Model footprint;
    private Texture2D normalmap;
    private readonly VertexBufferBinding[] _vertexBufferBindings = new VertexBufferBinding[2];
    private MoonSurface.tex[] texdata;
    private int textflag;
    private float typewriterblank;
    private float typewriterwait = 500f;
    private float typeposition;
    private float typevertical = 110f;
    private int typewriterdelay = 3;
    private SoundEffect pop1;
    private float typewritercount;
    private string text = "";
    private SpriteFont typer;
    private float timer;
    private int objIndex;
    private int displayObjective = 650;
    private bool firstMess = true;
    private List<string> objectiveData = new List<string>();

    public GameplayScreen(float divider)
    {
      this.TransitionOnTime = TimeSpan.FromSeconds(0.5);
      this.TransitionOffTime = TimeSpan.FromSeconds(0.5);
      this.backgroundThread = new Thread(new ThreadStart(this.BackgroundWorkerThread));
      this.backgroundThread.Name = "space";
      this.backgroundThreadExit = (EventWaitHandle) new ManualResetEvent(false);
    }

    public override void LoadContent()
    {
      this.sc = this.ScreenManager;
      this.sc.loadflag = 0;
      this.sc.lockVideosetup = true;
      this.sc.LoadSpaceKeys();
      this.random = new Random();
      this.sc.Game.ResetElapsedTime();
      if (this.content == null)
        this.content = new ContentManager((IServiceProvider) this.sc.Game.Services, "Content");
      this.spriteBatch = new SpriteBatch(this.sc.GraphicsDevice);
      this.sc.loadSpaceFarm();
      this.sc.myTimer = 0.0f;
      if (this.sc.usingMouse)
        this.sc.getXkey();
      else
        this.sc.myXkey = "X";
      this.emo = GameplayScreen.act.chill;
      this.typer = this.content.Load<SpriteFont>("astro\\fonts\\typer");
      this.pop1 = this.content.Load<SoundEffect>("astro\\Audio\\pop");
      this.objectiveData.Add("OBJECTIVE 1.01 : \nLook For A Safe Place\nYou Are Running Out of Oxygen\nYou Will Soon Die");
      this.objectiveData.Add("OBJECTIVE 2.F5 : \nFind A New Vehicle\nLearn How To Fly\nPark The Rover Inside");
      this.objectiveData.Add("OBJECTIVE 3.06 : \nRescue A Stranded Astronaut\nWalk Up To The Astronaut\nBring Him Back To The Farm\nHonk To Make Him Leave");
      this.objectiveData.Add("OBJECTIVE 4.BB : \nMine Some Ore Now\nUsing Your Rover\nSmash Rocks With The Bumper");
      this.objectiveData.Add("OBJECTIVE 5.E9 : \nRefining Ore Make Fuel\nFill The Fuel Tank\nBring Ore Into The Lander");
      this.objectiveData.Add("OBJECTIVE 6.01 : \nKill An Astronaut\nTry Everything\nDo It Now , Do It");
      this.objectiveData.Add("OBJECTIVE 7.XY : \nExploration And Discovery\nThere Is A Secret Location\nUse Your Resources");
      this.objectiveData.Add("OBJECTIVE 8.EA : \nCreate A Worker\nBuild And Build\nPress The 2nd Switch");
      this.objectiveData.Add("OBJECTIVE 9.7I :  \nSearching For Mission\nPlease Wait A Minute\nSearching . . . .");
      this.objectiveData.Add("OBJECTIVE 10.0E : \nSomeone Needs To Be Rescued\nUse Your Compass\nBring Him Home Safely");
      this.objectiveData.Add("OBJECTIVE 11.3G : \nTake A Ride On A Dropship\nLook At The Terrain\nFollow The Groove");
      this.objectiveData.Add("OBJECTIVE 12.TT : \nSomeone Is Lost\nPlease Find Them\nBring That Back Home");
      this.objectiveData.Add("OBJECTIVE 13.RD : \nThis Really Is Enough\nThanks For Playing\nStart Transmission");
      this.objectiveData.Add("OBJECTIVE 13.XC : \nThis Really Is Enough\nThanks For Playing\nEnd Transmission");
      this.objectiveData.Add("OBJECTIVE 13.XC : \nThis Really Is Enough\nThanks For Playing\nEnd Transmission");
      this.text = this.objectiveData[this.objIndex];
      this.grassTexture = this.sc.grassTexture;
      this.texture2D_0 = this.sc.texture2D_0;
      this.buildingShadow = this.sc.buildingshadspace;
      this.buildingEffect = this.content.Load<Effect>("effects\\buildingsPMspace");
      this.buildingEffect.Parameters["rgbTexture"].SetValue((Texture) this.texture2D_0);
      this.buildingEffect.Parameters["shadTexture"].SetValue((Texture) this.buildingShadow);
      this.buildingEffect.Parameters["moon"].SetValue(this.sc.moontype);
      this.heightmodel = this.sc.farmspacecollide;
      float[] numArray = (float[]) ((Dictionary<string, object>) this.heightmodel.Tag)["Heights"];
      int index1 = 0;
      this.heights = new int[200, 200];
      for (int index2 = 0; index2 < 200; ++index2)
      {
        for (int index3 = 0; index3 < 200; ++index3)
        {
          this.heights[index2, index3] = (int) numArray[index1];
          ++index1;
        }
      }
      this.farmLocation = new Vector3(0.0f, 5f, 0.0f);
      Lander.farmLocation = this.farmLocation;
      Rover.farmLocation = this.farmLocation;
      Rover.nearfarm = this.nearfarm;
      Lander.nearfarm = this.nearfarm;
      this.afont4 = this.content.Load<SpriteFont>("font\\afont4");
      this.ammoMedium = new SpriteFont[1]{ this.afont4 };
      this.ammoMedium2 = this.content.Load<SpriteFont>("font\\ammomedium2");
      int index4 = 0;
      Vector3[] origRegion1 = this.origRegion1;
      for (int index5 = 0; index5 < origRegion1.Length; ++index5)
      {
        this.origRegion1[index4] = Vector3.Transform(this.origRegion1[index4], Matrix.CreateScale(1.8f));
        ++index4;
      }
      this.tinting = new Vector3[11]
      {
        this.mercury,
        this.mercury,
        this.venus,
        this.earth,
        this.mars,
        this.jupiter,
        this.saturn,
        this.uranus,
        this.neptune,
        this.pluto,
        this.c10
      };
      for (int index6 = 0; index6 < this.tinting.Length; ++index6)
        this.tinting[index6] = (this.tinting[index6] + Vector3.One * 2f) / 3f;
      this.sc.planet = this.sc.bgindex;
      this.lander = new Lander();
      this.rover = new Rover();
      this.overlay = new Overlay();
      this.tmake = new tmake();
      this.surface = new MoonSurface();
      this.landerEngineI = this.sc.landerEngine.CreateInstance();
      this.roverEngineI = this.sc.roverEngine.CreateInstance();
      this.dropEngineI = this.sc.dropEngine.CreateInstance();
      this.gravelI = this.sc.gravel.CreateInstance();
      this.overtureInstance = this.sc.overture.CreateInstance();
      this.flowerradioInstance = this.content.Load<SoundEffect>("astro\\audio\\radioshit").CreateInstance();
      this.breathing = this.sc.breath.CreateInstance();
      this.blurEffect = this.content.Load<Effect>("astro\\shaders\\postShader");
      float num1 = 15f;
      Vector2[] vector2Array = new Vector2[24];
      for (int index7 = 0; index7 < 24; ++index7)
      {
        float num2 = (float) -index7;
        vector2Array[index7] = new Vector2((float) Math.Sin((double) MathHelper.ToRadians(num2 * num1)), -1.4f * (float) Math.Cos((double) MathHelper.ToRadians((float) (180.0 + (double) num2 * (double) num1))));
      }
      this.blurEffect.Parameters["offsets"].SetValue(vector2Array);
      this.blurdot = this.content.Load<Texture2D>("astro\\textures\\blurdot");
      this.blurEffect.Parameters["flatTexture"].SetValue((Texture) this.blurdot);
      this.mybasic = this.content.Load<Effect>("astro\\shaders\\basic");
      this.dropshipTexture = this.content.Load<Texture2D>("astro\\textures\\dropShipPNGnewlow");
      this.dropshipLights = this.content.Load<Texture2D>("astro\\textures\\dropshipLights");
      this.mybasic.Parameters["modelTexture"].SetValue((Texture) this.dropshipTexture);
      this.mybasic.Parameters["modelTexture2"].SetValue((Texture) this.dropshipLights);
      this.distortion = this.content.Load<Texture2D>("astro\\textures\\dist");
      this.shieldTexture = this.content.Load<Texture2D>("astro\\textures\\shield");
      this.terrainEffect = this.content.Load<Effect>("astro\\shaders\\terrainShader");
      this.starEffect = this.content.Load<Effect>("astro\\shaders\\starShader");
      this.shadowEffect = this.content.Load<Effect>("astro\\shaders\\shadowShader");
      this.simpEffect = this.content.Load<Effect>("astro\\shaders\\simple");
      this.wallPlane = new Plane(new Vector3(-15000f, 0.0f, -15000f), new Vector3(15000f, 0.0f, -15000f), new Vector3(-15000f, 0.0f, 15000f));
      this.texdata = new MoonSurface.tex[4000000];
      this.heightData = new int[2000, 2000];
      this.normalData = new Vector3[2000, 2000];
      this.objectData = new int[500, 500];
      this.sphere = this.content.Load<Model>("astro\\models//sphere");
      this.prints = new GameplayScreen.hole();
      this.prints.stainMax = 0;
      this.prints.stainIndex = 0;
      this.prints.drift = new float[150];
      this.prints.stainCapacity = 150;
      this.prints.stainTrans = new GameplayScreen.hitStream[this.prints.stainCapacity];
      this.prints.stainBuffer = new DynamicVertexBuffer(this.sc.GraphicsDevice, GameplayScreen.vd2, this.prints.stainCapacity, BufferUsage.WriteOnly);
      this.footprint = this.content.Load<Model>("astro\\models//footprint1");
      this.normalmap = this.content.Load<Texture2D>("astro\\textures//normalmap");
      this.tmake.Load(this.content, this.sc);
      this.bitmap = this.tmake.Tw;
      this.rover.bitmap = this.bitmap;
      this.lander.bitmap = this.bitmap;
      this.gridscale = this.tmake.gridScale;
      this.rover.gridscale = this.gridscale;
      this.lander.gridScale = (float) this.gridscale;
      this.unit = this.bitmap - 1;
      this.rover.LoadContent(this.content, this.sc);
      this.lander.LoadContent(this.content, this.sc);
      this.overlay.Load(this.content, this.sc);
      this.overlay.farm = this.farmLocation;
      this.shale1.LoadContent(this.content, this.sc);
      this.shale2.LoadContent(this.content, this.sc);
      this.shale3.LoadContent(this.content, this.sc);
      this.dropship = this.content.Load<Model>("astro\\models\\dropship");
      this.dropshipShade = this.content.Load<Model>("astro\\models\\dropship");
      this.beacon = this.content.Load<Model>("astro\\models\\beacon");
      this.stardome = this.content.Load<Model>("astro\\models\\dome3");
      this.galaxy = this.content.Load<Model>("astro\\models\\galaxy");
      this.darkFog = this.content.Load<Model>("astro\\models\\darkFog");
      this.LanderShadow = this.content.Load<Model>("astro\\models\\LanderShade");
      this.tankShadow = this.content.Load<Model>("astro\\models\\tankShade");
      this.bigquad = this.content.Load<Model>("astro\\models\\bigquad");
      this.rock.flower = this.content.Load<Model>("astro\\models\\flower");
      this.rock.rock = this.content.Load<Model>("astro\\models\\rockhigh");
      this.rock.rock1 = this.content.Load<Model>("astro\\models\\rockpart1");
      this.rock.rock2 = this.content.Load<Model>("astro\\models\\rockpart2");
      this.rock.slab = this.content.Load<Model>("astro\\models\\slab3");
      this.rock.slablet = this.content.Load<Model>("astro\\models\\slab4");
      this.rock.reflection = this.content.Load<Texture2D>("astro\\textures\\reflectBW");
      this.shale1.model = this.content.Load<Model>("astro\\models\\shale1");
      this.shale1.gtype = gemstruct.gemtype.shale;
      this.shale2.model = this.content.Load<Model>("astro\\models\\shale2");
      this.shale2.gtype = gemstruct.gemtype.ruby;
      this.shale3.model = this.content.Load<Model>("astro\\models\\sapphire");
      this.shale3.gtype = gemstruct.gemtype.sapphire;
      this.starSheet = this.content.Load<Texture2D>("astro\\sprites\\stars\\starSheet");
      this.skids = (ParticleSystem) new skidsSystem(this.sc.Game, this.content);
      this.skids.Initialize();
      this.skids.LoadContent(this.sc.GraphicsDevice);
      this.streaks = (ParticleSystem) new streaksSystem(this.sc.Game, this.content);
      this.streaks.Initialize();
      this.streaks.LoadContent(this.sc.GraphicsDevice);
      this.dust = (ParticleSystem) new dustSystem(this.sc.Game, this.content);
      this.dust.Initialize();
      this.dust.LoadContent(this.sc.GraphicsDevice);
      this.lastAlias = this.sc.aliasSetting;
      this.aspectratio = this.sc.aspectratio2;
      this.longProjection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(this.lens), this.aspectratio, 14f, 195000f);
      this.sc.loadflag = 0;
      this.surface.LoadContent(this.content, this.sc, ref this.heightData, ref this.normalData, ref this.objectData, ref this.texdata);
      this.sc.loadflag = 0;
      this.tmake.LoadVertices();
      this.rock.LoadContent(this.content, this.sc, this.gridscale, this.bitmap, 550);
      this.pp = this.sc.GraphicsDevice.PresentationParameters;
      this.resolveTarget1 = new RenderTarget2D(this.sc.GraphicsDevice, 1280, 720, false, this.pp.BackBufferFormat, this.pp.DepthStencilFormat, 2, RenderTargetUsage.DiscardContents);
      this.resolveTarget2 = new RenderTarget2D(this.sc.GraphicsDevice, 1280, 720, false, this.pp.BackBufferFormat, this.pp.DepthStencilFormat, 0, RenderTargetUsage.DiscardContents);
      this.shadowTarget = new RenderTarget2D(this.sc.GraphicsDevice, 800, 800, false, SurfaceFormat.Color, DepthFormat.None, 0, RenderTargetUsage.DiscardContents);
      this.buildTextures(0);
      this.terrainGoto(1000, 1000);
      this.facility = new Facility();
      Facility.inFacility = false;
      Facility.outsideCastle = true;
      this.facility.scaler = 4f;
      this.facility.facilityLocate.X = (float) ((int) (((double) this.surface.facility1.X + 75.0) / 150.0) * 150 - 75);
      this.facility.facilityLocate.Y = (float) ((int) (((double) this.surface.facility1.Y + 75.0) / 150.0) * 150 - 75);
      this.overlay.facility.X = this.facility.facilityLocate.X;
      this.overlay.facility.Z = this.facility.facilityLocate.Y;
      this.GetHeightOnly(ref this.tmake.heightData, new Vector3(this.facility.facilityLocate.X, 0.0f, this.facility.facilityLocate.Y), out this.groundHeight);
      Facility.offset = new Vector3(this.facility.facilityLocate.X - 2250f, this.groundHeight - 1441f / this.facility.scaler, this.facility.facilityLocate.Y - 4337.5f);
      this.facility.LoadContent(this.content, this.sc);
      this.sc.loadflag = 2;
      this.makeFaciltyDirt();
      this.starmap.LoadContent(this.sc, this.content, this.sc.GraphicsDevice, 1200, 20000, true, this.sc.planet - 1);
      this.starEffect.Parameters["modelTexture"].SetValue((Texture) this.starmap.manmadestars);
      this.sc.loadflag = 0;
      this.sc.astronaut.man.dupe.Clear();
      for (int index8 = 0; index8 < this.surface.astroLoc.Count; ++index8)
      {
        this.sc.astronaut.dropAstronaut(this.myframe, this.surface.astroLoc[index8].Loc, 1, this.surface.astroLoc[index8].emo);
        ++this.myframe;
      }
      this.lens = 70f;
      this.setLens(70f);
      this.buildstrings();
      while (!LoadingScreen2.done)
        Thread.Sleep(5);
      this.backgroundThread.Start();
      this.sc.LoadSpacePrefs();
    }

    public void buildstrings()
    {
      GameplayScreen.nearastroBuild.Length = 0;
      GameplayScreen.nearastroBuild.Append("  press to rescue astronaut");
      GameplayScreen.stringBuilder_6.Length = 0;
      GameplayScreen.stringBuilder_6.Append("  press to drive rover");
      GameplayScreen.liftingFriendBuild.Length = 0;
      GameplayScreen.liftingFriendBuild.Append("  lifting your friend !!");
      GameplayScreen.atDoorBuild.Length = 0;
      GameplayScreen.atDoorBuild.Append("  press to move Barn Door");
      GameplayScreen.atPump1Build.Length = 0;
      GameplayScreen.atPump1Build.Append("  press to drink water");
      GameplayScreen.atPump2Build.Length = 0;
      GameplayScreen.atPump2Build.Append("  this Well is empty");
      GameplayScreen.atLever1Build.Length = 0;
      GameplayScreen.atLever1Build.Append("  press to activate Electric Fence");
      GameplayScreen.atLever2Build.Length = 0;
      GameplayScreen.atLever2Build.Append("  Out of Order, try again tomorrow");
      GameplayScreen.atLever3Build.Length = 0;
      GameplayScreen.atLever3Build.Append("  electric fence is in operation");
      GameplayScreen.atPumpBusyBuild.Length = 0;
      GameplayScreen.atPumpBusyBuild.Append("  Pump is being used");
      GameplayScreen.atKissingBuild.Length = 0;
      GameplayScreen.atKissingBuild.Append("  to Wear Secret Item");
      GameplayScreen.atgrinderBuild.Length = 0;
      GameplayScreen.atgrinderBuild.Append("  Shoot the Glowing Blue Buttons !!");
      GameplayScreen.needbloodBuild.Length = 0;
      GameplayScreen.needbloodBuild.Append("  Kick parts into Front-Blade");
      GameplayScreen.reloadBuild.Length = 0;
      GameplayScreen.reloadBuild.Append("  press to Reload Weapon");
      GameplayScreen.atDoorLockedBuild.Length = 0;
      GameplayScreen.atDoorLockedBuild.Append("  Barn Door is locked");
      GameplayScreen.atFarmerBuild.Length = 0;
      GameplayScreen.atFarmerBuild.Append("  press to talk to Farmer");
      GameplayScreen.pickupMilkBuild.Length = 0;
      GameplayScreen.pickupMilkBuild.Append("  press to pickup Boars Milk");
      GameplayScreen.pickupAmmoBuild.Length = 0;
      GameplayScreen.pickupAmmoBuild.Append("  press to pickup Bullet Box");
      GameplayScreen.pickupHulkBuild.Length = 0;
      GameplayScreen.pickupHulkBuild.Append("  press to pickup Bulkify");
      GameplayScreen.pickupGrenBuild.Length = 0;
      GameplayScreen.pickupGrenBuild.Append("  press to pickup Grenade");
      GameplayScreen.pickupPillBuild.Length = 0;
      GameplayScreen.pickupPillBuild.Append("  press to pickup BounceBack");
      GameplayScreen.pickupRocketBuild.Length = 0;
      GameplayScreen.pickupRocketBuild.Append("  press to pickup Rocket");
      GameplayScreen.pickupFullBuild.Length = 0;
      GameplayScreen.pickupFullBuild.Append("  cant carry more of that");
      GameplayScreen.pickWeaponBuild.Length = 0;
      GameplayScreen.pickWeaponBuild.Append("  press to take Weapon");
    }

    private void BackgroundWorkerThread()
    {
      while (!this.backgroundThreadExit.WaitOne(10))
      {
        if (!this.isBusy && this.loads.Count > 0 && !this.isDrawing)
        {
          this.isBusy = true;
          switch (this.loads[0])
          {
            case 1:
              this.terrainhester();
              break;
          }
          this.loads.RemoveAt(0);
          this.isBusy = false;
        }
      }
    }

    public override void UnloadContent()
    {
      try
      {
        GamePad.SetVibration(this.myplayer, 0.0f, 0.0f);
        this.dropEngineI.Dispose();
        this.landerEngineI.Dispose();
        this.roverEngineI.Dispose();
        this.gravelI.Dispose();
        this.overtureInstance.Dispose();
        this.flowerradioInstance.Dispose();
        this.breathing.Dispose();
      }
      catch
      {
      }
      try
      {
        this.resolveTarget1.Dispose();
        this.resolveTarget1 = (RenderTarget2D) null;
        this.resolveTarget2.Dispose();
        this.resolveTarget2 = (RenderTarget2D) null;
        this.shadowTarget.Dispose();
        this.shadowTarget = (RenderTarget2D) null;
        this.starmap.manmadestars.Dispose();
        this.starmap.tt.Dispose();
        this.starmap.starSheet.Dispose();
        this.starmap.colorArray1 = new Color[0];
        this.sc.astronaut.man.dupe.Clear();
        this.texdata = new MoonSurface.tex[0];
      }
      catch
      {
      }
      try
      {
        if (this.backgroundThread != null)
        {
          this.backgroundThreadExit.Set();
          this.backgroundThread.Join();
        }
      }
      catch
      {
      }
      this.content.Unload();
      this.content.Dispose();
      this.content = (ContentManager) null;
    }

    private string botPath(
      ref float[] floorplot,
      ref List<Vector2> botPath,
      Vector2 startpos,
      Vector2 destiny)
    {
      List<Vector2> vector2List = new List<Vector2>();
      float num1 = 700f;
      int index1 = -1;
      for (int index2 = 0; index2 < floorplot.Length; index2 += 2)
      {
        vector2List.Add(new Vector2(floorplot[index2] + 0.0f, floorplot[index2 + 1] + 0.0f));
        float num2 = Vector2.Distance(new Vector2(floorplot[index2] + 0.0f, floorplot[index2 + 1] + 0.0f), startpos);
        if ((double) num2 <= (double) num1)
        {
          num1 = num2;
          index1 = index2;
        }
      }
      if (index1 == -1)
        return "lost";
      Vector2 start = new Vector2(floorplot[index1] + 0.0f, floorplot[index1 + 1] + 0.0f);
      List<Vector2> search = new List<Vector2>();
      List<Vector2> result = new List<Vector2>();
      vector2List.ForEach((Action<Vector2>) (item => search.Add(item)));
      bool flag = this.buildbotPath(ref search, ref result, start, destiny);
      botPath.Clear();
      for (int index3 = 0; index3 < result.Count; ++index3)
        botPath.Add(result[index3]);
      botPath.Insert(0, startpos);
      botPath.Add(destiny);
      return !flag ? "lost" : "good";
    }

    private bool buildbotPath(
      ref List<Vector2> source,
      ref List<Vector2> result,
      Vector2 start,
      Vector2 end)
    {
      bool flag = true;
      Random random = new Random();
      List<Vector2> vector2List1 = new List<Vector2>();
      for (int index = 0; index < source.Count; ++index)
      {
        float num = Vector2.Distance(start, source[index]);
        if ((double) num > 50.0 && (double) num <= 400.0)
          vector2List1.Add(source[index]);
      }
      if (vector2List1.Count == 0)
        return false;
      List<Vector2> vector2List2 = new List<Vector2>();
      while (vector2List1.Count > 0)
      {
        int index = random.Next(0, vector2List1.Count);
        vector2List2.Add(vector2List1[index]);
        vector2List1.RemoveAt(index);
      }
      for (int index = 0; index < vector2List2.Count; ++index)
      {
        if ((double) Vector2.Distance(end, vector2List2[index]) > 500.0)
        {
          start = vector2List2[index];
          source.Remove(start);
          result.Add(start);
          if (flag = this.buildbotPath(ref source, ref result, start, end))
            return true;
          if (!flag)
            result.Remove(start);
        }
        else
        {
          result.Add(vector2List2[index]);
          return true;
        }
      }
      return flag;
    }

    private void buildTextures(int x)
    {
      if (x == 1)
        ++this.myVar2[0];
      if (this.myVar2[0] > 100)
        this.myVar2[0] = 1;
      if (x == 2)
        ++this.myVar2[1];
      if (this.myVar2[1] > 100)
        this.myVar2[1] = 1;
      if (x == 3)
        ++this.myVar2[2];
      if (this.myVar2[2] > 100)
        this.myVar2[2] = 1;
      if (x == 4)
        ++this.myVar2[3];
      if (this.myVar2[3] > 100)
        this.myVar2[3] = 1;
      if (this.sc.planetName[this.sc.planet] == "Mercury")
      {
        this.landNum1 = 12;
        this.landNum2 = 95;
        this.landNum4 = 69;
      }
      else if (this.sc.planetName[this.sc.planet] == "Venus")
      {
        this.landNum1 = 1;
        this.landNum2 = 93;
        this.landNum4 = 87;
      }
      else if (this.sc.planetName[this.sc.planet] == "Earth")
      {
        this.landNum1 = 97;
        this.landNum2 = 101;
        this.landNum4 = 51;
      }
      else if (this.sc.planetName[this.sc.planet] == "Mars")
      {
        this.landNum1 = 16;
        this.landNum2 = 22;
        this.landNum4 = 31;
      }
      else if (this.sc.planetName[this.sc.planet] == "Neptune")
      {
        this.landNum1 = 10;
        this.landNum2 = 9;
        this.landNum4 = 11;
      }
      else
      {
        this.landNum1 = this.myVar2[0];
        this.landNum2 = this.myVar2[1];
        this.landNum4 = this.myVar2[3];
      }
      this.layer1 = this.content.Load<Texture2D>("astro\\sprites\\land\\text" + (object) this.landNum1);
      this.layer2 = this.content.Load<Texture2D>("astro\\sprites\\land\\text" + (object) this.landNum2);
      this.layer4 = this.content.Load<Texture2D>("astro\\sprites\\land\\text" + (object) this.landNum4);
      this.terrainEffect.CurrentTechnique = this.terrainEffect.Techniques["terrainShadows3"];
      this.terrainEffect.Parameters["xTexture1"].SetValue((Texture) this.layer1);
      this.terrainEffect.Parameters["xTexture2"].SetValue((Texture) this.layer2);
      this.terrainEffect.Parameters["xTexture4"].SetValue((Texture) this.layer4);
    }

    private void bucketCollide()
    {
      Matrix matrix = Matrix.CreateRotationX(-0.44f) * Matrix.CreateTranslation(0.0f, 25.98f, -26.1f) * this.sc.scooperTrans;
      gemstruct.setitRight = this.rover.orientation * Matrix.CreateTranslation(this.rover.position);
      gemstruct.setVacuum = Matrix.CreateRotationX(0.0f) * Matrix.CreateTranslation(0.0f, 0.0f, -26.1f) * this.sc.scooperTrans * this.rover.orientation * Matrix.CreateTranslation(this.rover.position);
      gemstruct.inDumper = this.rover.orientation * Matrix.CreateFromAxisAngle(this.rover.orientation.Forward, this.rover.leanAmt) * Matrix.CreateTranslation(this.rover.pp);
      this.bucketRegion1[0] = Vector3.Transform(this.origRegion1[0] * 30f, gemstruct.setitRight);
      this.bucketRegion1[1] = Vector3.Transform(this.origRegion1[1] * 30f, gemstruct.setitRight);
      this.bucketRegion1[2] = Vector3.Transform(this.origRegion1[2] * 30f, gemstruct.setitRight);
      this.bucketRegion1[3] = Vector3.Transform(this.origRegion1[3] * 30f, gemstruct.setitRight);
      this.bucketRegion1[4] = Vector3.Transform(this.origRegion1[4] * 30f, this.rover.orientation * Matrix.CreateTranslation(this.rover.position));
    }

    private void terrainGoto(int x, int z)
    {
      this.trnLoctn.X += (float) (300 * this.gridscale);
      this.trnLoctn.Z += (float) (300 * this.gridscale);
      this.myposx = x + 298;
      this.myposz = z + 298;
      if (this.myposx > 1999)
        this.myposx -= 2000;
      if (this.myposz > 1999)
        this.myposz -= 2000;
      for (int index = 299; index >= 0; --index)
      {
        this.trnLoctn -= new Vector3((float) this.gridscale, 0.0f, (float) this.gridscale);
        this.whatz = (int) Math.Round((double) this.trnLoctn.Z / (double) this.gridscale) * this.gridscale;
        this.zgrid = (int) (((double) this.trnLoctn.Z + (double) (this.gridscale / 2)) / (double) this.gridscale % (double) this.unit + (double) this.unit) % this.unit;
        this.whatx = (int) Math.Round((double) this.trnLoctn.X / (double) this.gridscale) * this.gridscale;
        this.xgrid = (int) (((double) this.trnLoctn.X + (double) (this.gridscale / 2)) / (double) this.gridscale % (double) this.unit + (double) this.unit) % this.unit;
        if (this.lastxgrid != this.xgrid && this.whatx != this.diffix || this.lastzgrid != this.zgrid && this.whatz != this.diffiz)
        {
          this.UpdateTerrain(150000, true);
          if ((double) Vector2.Distance(new Vector2(this.trnLoctn.X, this.trnLoctn.Z), new Vector2(this.trnLoctnLast.X, this.trnLoctnLast.Z)) > (double) this.cutoff)
            this.trnLoctnLast = this.trnLoctn;
        }
      }
      this.rover.velocity = Vector3.Zero;
      this.GetHeightOnly(ref this.tmake.heightData, this.trnLoctn, out this.rover.position.Y);
      this.rover.HandleInput(ref this.mouseState, ref this.prevMouse, ref this.keyState, ref this.prevkeyState, ref this.gamePadState, ref this.heights, ref this.tmake.normals);
      this.rover.position = new Vector3(this.rover.position.X, this.rover.position.Y, this.rover.position.Z);
      this.oldtrnLoctn = this.trnLoctn;
      this.oldtrnLoctn2 = this.trnLoctn;
      this.rock.myPOS = new Vector2((float) ((int) Math.Round((double) this.trnLoctn.X / 1000.0) * 1000), (float) ((int) Math.Round((double) this.trnLoctn.Z / 1000.0) * 1000));
      this.rock.oldmyPOS = this.rock.myPOS;
      this.rock.slabPOS = this.rock.myPOS;
      this.rock.vector2_0 = this.rock.myPOS;
      this.trnLoctnLast = this.trnLoctn;
      this.tmake.moveall();
      this.rock.placeOBJECTS(this.vehicleindex, ref this.rover, ref this.lander, ref this.tmake.heightData, ref this.tmake.normals, ref this.objectData, (float) this.sc.planet);
      this.rock.method_0(this.vehicleindex, ref this.rover, ref this.lander, ref this.tmake.heightData, ref this.tmake.normals, ref this.objectData);
      this.lander.velocity = Vector3.Zero;
      Lander.nearfarm = false;
      this.lander.position = new Vector3(-4500f, 0.0f, 3900f);
      this.GetHeightOnly(ref this.tmake.heightData, this.lander.position, out this.lander.position.Y);
      this.lander.position = new Vector3(this.lander.position.X, this.lander.position.Y, this.lander.position.Z);
      this.lander.impact = 1;
      this.lander.diff = 2f;
      this.lander.door1 = 1;
      this.rover.onramp = 0;
      this.lander.HandleInput(ref this.mouseState, ref this.prevMouse, ref this.keyState, ref this.prevkeyState, ref this.gamePadState, ref this.tmake.heightData, ref this.tmake.normals);
      this.lander.orientation = Matrix.CreateRotationY(this.lander.directme);
      this.lander.orientation.Up = this.lander.normal;
      this.lander.orientation.Right = Vector3.Cross(this.lander.orientation.Forward, this.lander.orientation.Up);
      this.lander.orientation.Right = Vector3.Normalize(this.lander.orientation.Right);
      this.lander.orientation.Forward = Vector3.Cross(this.lander.orientation.Up, this.lander.orientation.Right);
      this.lander.orientation.Forward = Vector3.Normalize(this.lander.orientation.Forward);
      this.vector3_0 = new Vector3(-110250f, this.lander.position.Y + 4500f, 0.0f);
    }

    private void updateMusic()
    {
      this.flowervol = 1f - MathHelper.Clamp(this.rock.flowerDistance / 35000f, 0.0f, 1f);
      this.overlay.flowerScale = this.flowervol;
      --this.flowervolumeTimer;
      if (this.flowervolumeTimer <= 0)
        this.flowervol = 0.0f;
      if (this.flowervolumeTimer == 0)
        this.sc.radio1.Play(this.sc.ev, 0.3f, 0.0f);
      if (this.flowerradioInstance.State == SoundState.Stopped)
      {
        this.flowerradioInstance.IsLooped = true;
        this.flowerradioInstance.Volume = this.flowervol * this.sc.voiceVolume;
        this.flowerradioInstance.Play();
      }
      else
      {
        this.flowerradioInstance.Resume();
        this.flowerradioInstance.Volume = this.flowervol * this.sc.voiceVolume;
      }
      if (this.overtureInstance.State == SoundState.Stopped)
      {
        this.overtureInstance.IsLooped = true;
        this.overtureInstance.Volume = 0.3f * this.sc.mv;
        this.overtureInstance.Play();
      }
      else
      {
        this.overtureInstance.Resume();
        this.overtureInstance.Volume = 0.3f * this.sc.mv;
      }
      if (this.musictick == 0)
        this.musictick = this.random.Next(100, 360) + 180;
      --this.musictick;
      if (this.musictick >= 1)
        return;
      if (this.random.Next(1, 11) < 6)
      {
        this.sc.steeldrum1.Play(0.3f * this.sc.mv, 0.0f, 0.0f);
        this.musictick = 1620 + this.random.Next(100, 540) + 230;
      }
      else
      {
        this.sc.steeldrum2.Play(0.3f * this.sc.mv, 0.0f, 0.0f);
        this.musictick = 1620 + this.random.Next(100, 540) + 260;
      }
    }

    private int range(int val, int max)
    {
      val = (val % max + max) % max;
      return val;
    }

    private void textures(int x, int y, int xx, int yy)
    {
      this.tmake.Tv[x + y * this.bitmap].TextureCoordinate.X = (float) ((double) x / 36.125 + 0.11072664707899094);
      this.tmake.Tv[x + y * this.bitmap].TextureCoordinate.Y = (float) ((double) y / 36.125 + 0.11072664707899094);
      this.tmake.Tv[x + y * this.bitmap].TexWeights.X = this.texdata[xx + yy * 2000].TexWeights.X;
      this.tmake.Tv[x + y * this.bitmap].TexWeights.Y = this.texdata[xx + yy * 2000].TexWeights.Y;
      this.tmake.Tv[x + y * this.bitmap].TexWeights.W = this.texdata[xx + yy * 2000].TexWeights.Z;
    }

    private void makeFaciltyDirt()
    {
      float facility1hite = this.surface.facility1hite;
      this.X = MathHelper.Clamp((float) (1.0 - (double) Math.Abs(facility1hite - 0.0f) / 2000.0), 0.0f, 1f);
      this.Y = MathHelper.Clamp((float) (1.0 - (double) Math.Abs(facility1hite - 4000f) / 3980.0), 0.0f, 1f);
      this.W = MathHelper.Clamp((float) (1.0 - (double) Math.Abs(facility1hite - 8000f) / 6000.0), 0.0f, 1f);
      if ((double) facility1hite >= 7000.0)
        this.W = 1f;
      if ((double) facility1hite <= 20.0)
      {
        this.Y = 0.01f;
        this.X = 1f;
      }
      float num1 = this.X + this.Y + this.W;
      double num2 = (double) MathHelper.Clamp(num1, 1f, 10f);
      this.X /= num1;
      this.Y /= num1;
      this.W /= num1;
      this.pp = this.sc.GraphicsDevice.PresentationParameters;
      RenderTarget2D renderTarget = new RenderTarget2D(this.sc.GraphicsDevice, 500, 500, true, this.pp.BackBufferFormat, this.pp.DepthStencilFormat, 0, RenderTargetUsage.DiscardContents);
      this.sc.GraphicsDevice.SetRenderTarget(renderTarget);
      this.sc.GraphicsDevice.Clear(Color.Black);
      Color color1 = new Color(this.X, this.X, this.X, 1f);
      Color color2 = new Color(this.Y, this.Y, this.Y, 1f);
      Color color3 = new Color(this.W, this.W, this.W, 1f);
      int num3 = 250;
      int num4 = 2;
      this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive);
      for (int index1 = 0; index1 < num4; ++index1)
      {
        for (int index2 = 0; index2 < num4; ++index2)
          this.spriteBatch.Draw(this.layer1, new Rectangle(index1 * num3, index2 * num3, num3, num3), color1);
      }
      for (int index3 = 0; index3 < num4; ++index3)
      {
        for (int index4 = 0; index4 < num4; ++index4)
          this.spriteBatch.Draw(this.layer2, new Rectangle(index3 * num3, index4 * num3, num3, num3), color2);
      }
      for (int index5 = 0; index5 < num4; ++index5)
      {
        for (int index6 = 0; index6 < num4; ++index6)
          this.spriteBatch.Draw(this.layer4, new Rectangle(index5 * num3, index6 * num3, num3, num3), color3);
      }
      this.spriteBatch.End();
      this.sc.GraphicsDevice.SetRenderTarget((RenderTarget2D) null);
      this.facility.dirtrgb = (Texture2D) renderTarget;
    }

    private void UpdateTerrain(int cutoff, bool ignore)
    {
      int num1 = 0;
      int num2 = this.bitmap - 2;
      int xx = 0;
      int yy1 = 0;
      if (this.zgrid != this.lastzgrid && this.whatz != this.diffiz)
      {
        int y1 = this.range(this.zgrid + 1, this.bitmap - 1);
        int num3 = this.range(this.zgrid + 2, this.bitmap - 1);
        int y2 = this.range(this.zgrid - 1, this.bitmap - 1);
        int num4 = this.range(this.zgrid - 2, this.bitmap - 1);
        if (this.zgrid <= this.lastzgrid && (this.zgrid != 0 || this.lastzgrid != num2) || this.zgrid == num2 && this.lastzgrid == 0)
        {
          if ((this.zgrid < this.lastzgrid || this.zgrid == num2 && this.lastzgrid == 0) && (this.zgrid != 0 || this.lastzgrid != num2))
          {
            --this.myposz;
            if (this.myposz < 0)
              this.myposz = 1999;
          }
        }
        else
        {
          ++this.myposz;
          if (this.myposz > 1999)
            this.myposz = 0;
        }
        bool flag1 = (this.zgrid > this.lastzgrid || this.zgrid == 0 && this.lastzgrid == num2) && (this.zgrid != num2 || this.lastzgrid != 0);
        bool flag2 = (this.zgrid < this.lastzgrid || this.zgrid == num2 && this.lastzgrid == 0) && (this.zgrid != 0 || this.lastzgrid != num2);
        if (flag1 || flag2)
        {
          if (flag1)
          {
            yy1 = this.myposz + (this.bitmap - 2) / 2 + 1;
            if (yy1 > 1999)
              yy1 -= 2000;
            if (yy1 < 0)
              yy1 += 2000;
          }
          if (flag2)
          {
            yy1 = this.myposz - (this.bitmap - 2) / 2 + 2;
            if (yy1 < 0)
              yy1 += 2000;
            if (yy1 < 0)
              yy1 += 2000;
          }
          for (int x = 0; x < this.bitmap; ++x)
          {
            if (flag1)
            {
              this.tmake.Tv[x + this.zgrid * this.bitmap].Position = new Vector3(this.tmake.Tv[x + this.zgrid * this.bitmap].Position.X, -100000f, this.trnLoctn.Z);
              this.index = x + y2 * this.bitmap;
              xx = this.myposx - (this.bitmap - 2) / 2 + this.range(x - this.lastxgrid, this.bitmap - 1) + 1;
              if (xx > 1999)
                xx -= 2000;
              if (xx < 0)
                xx += 2000;
              this.tmake.heightData[x, y2] = this.heightData[xx, yy1];
              if (y2 == 0)
              {
                num1 = 1;
                this.tmake.heightData[x, this.bitmap - 1] = this.heightData[xx, yy1];
              }
              float y3 = (float) this.heightData[xx, yy1];
              if (x == this.lastxgrid)
                y3 = -100000f;
              this.tmake.Tv[this.index].Position = new Vector3(this.tmake.Tv[this.index].Position.X, y3, (float) (this.whatz + ((this.bitmap - 1) * this.gridscale / 2 - this.gridscale)));
              if (num4 == 1)
                this.tmake.Tv[x + (this.bitmap - 1) * this.bitmap].Normal = this.tmake.Tv[x].Normal;
              this.tmake.normals[x, y2] = this.normalData[xx, yy1];
              this.tmake.Tv[x + y2 * this.bitmap].Normal = this.normalData[xx, yy1];
              this.textures(x, y2, xx, yy1);
              if (!ignore && x % 2 == 0)
                this.rock.simpleObjectAdd(this.tmake.Tv[this.index].Position.X, this.tmake.Tv[this.index].Position.Z - 160f, ref this.tmake.heightData, ref this.tmake.normals, ref this.objectData);
            }
            else if (flag2)
            {
              this.tmake.Tv[x + this.zgrid * this.bitmap].Position = new Vector3(this.tmake.Tv[x + this.zgrid * this.bitmap].Position.X, -100000f, this.trnLoctn.Z);
              this.index = x + y1 * this.bitmap;
              xx = this.myposx - (this.bitmap - 2) / 2 + this.range(x - this.lastxgrid, this.bitmap - 1) + 1;
              if (xx > 1999)
                xx -= 2000;
              if (xx < 0)
                xx += 2000;
              this.tmake.heightData[x, y1] = this.heightData[xx, yy1];
              if (y1 == 0)
              {
                num1 = 2;
                this.tmake.heightData[x, this.bitmap - 1] = this.heightData[xx, yy1];
              }
              float y4 = (float) this.heightData[xx, yy1];
              if (x == this.lastxgrid)
                y4 = -100000f;
              this.tmake.Tv[this.index].Position = new Vector3(this.tmake.Tv[this.index].Position.X, y4, (float) (this.whatz - ((this.bitmap - 1) * this.gridscale / 2 - this.gridscale)));
              if (num3 == num2)
                this.tmake.Tv[x + (this.bitmap - 1) * this.bitmap].Normal = this.tmake.Tv[x].Normal;
              this.tmake.normals[x, y1] = this.normalData[xx, yy1];
              this.tmake.Tv[this.index].Normal = this.normalData[xx, yy1];
              this.textures(x, y1, xx, yy1);
              if (!ignore && x % 2 == 0)
                this.rock.simpleObjectAdd(this.tmake.Tv[this.index].Position.X, 160f + this.tmake.Tv[this.index].Position.Z, ref this.tmake.heightData, ref this.tmake.normals, ref this.objectData);
            }
            if (num1 > 0)
              this.tmake.Tv[x + (this.bitmap - 1) * this.bitmap].Position = this.tmake.Tv[x].Position;
            if (this.zgrid == 0)
              this.tmake.Tv[x + (this.bitmap - 1) * this.bitmap].Position = this.tmake.Tv[x].Position;
          }
        }
        this.diffiz = this.whatz;
        this.lastzgrid = this.zgrid;
      }
      int num5 = 0;
      if (this.xgrid == this.lastxgrid || this.whatx == this.diffix)
        return;
      int x1 = this.range(this.xgrid + 1, this.bitmap - 1);
      int num6 = this.range(this.xgrid + 2, this.bitmap - 1);
      int x2 = this.range(this.xgrid - 1, this.bitmap - 1);
      int num7 = this.range(this.xgrid - 2, this.bitmap - 1);
      if (this.xgrid <= this.lastxgrid && (this.xgrid != 0 || this.lastxgrid != num2) || this.xgrid == num2 && this.lastxgrid == 0)
      {
        if ((this.xgrid < this.lastxgrid || this.xgrid == num2 && this.lastxgrid == 0) && (this.xgrid != 0 || this.lastxgrid != num2))
        {
          --this.myposx;
          if (this.myposx < 0)
            this.myposx = 1999;
        }
      }
      else
      {
        ++this.myposx;
        if (this.myposx > 1999)
          this.myposx = 0;
      }
      bool flag3 = (this.xgrid > this.lastxgrid || this.xgrid == 0 && this.lastxgrid == num2) && (this.xgrid != num2 || this.lastxgrid != 0);
      bool flag4 = (this.xgrid < this.lastxgrid || this.xgrid == num2 && this.lastxgrid == 0) && (this.xgrid != 0 || this.lastxgrid != num2);
      if (flag3 || flag4)
      {
        if (flag3)
        {
          xx = this.myposx + (this.bitmap - 2) / 2 + 1;
          if (xx > 1999)
            xx -= 2000;
          if (xx < 0)
            xx += 2000;
        }
        if (flag4)
        {
          xx = this.myposx - (this.bitmap - 2) / 2 + 2;
          if (xx > 1999)
            xx -= 2000;
          if (xx < 0)
            xx += 2000;
        }
        for (int y5 = 0; y5 < this.bitmap; ++y5)
        {
          if (flag3)
          {
            this.tmake.Tv[this.xgrid + y5 * this.bitmap].Position = new Vector3(this.trnLoctn.X, -100000f, this.tmake.Tv[this.xgrid + y5 * this.bitmap].Position.Z);
            this.index = x2 + y5 * this.bitmap;
            int yy2 = this.myposz - (this.bitmap - 2) / 2 + this.range(y5 - this.lastzgrid, this.bitmap - 1) + 1;
            if (yy2 > 1999)
              yy2 -= 2000;
            if (yy2 < 0)
              yy2 += 2000;
            this.tmake.heightData[x2, y5] = this.heightData[xx, yy2];
            if (x2 == 0)
            {
              num5 = 1;
              this.tmake.heightData[this.bitmap - 1, y5] = this.heightData[xx, yy2];
            }
            float y6 = (float) this.heightData[xx, yy2];
            if (y5 == this.lastzgrid)
              y6 = -100000f;
            this.tmake.Tv[this.index].Position = new Vector3((float) (this.whatx + ((this.bitmap - 1) * this.gridscale / 2 - this.gridscale)), y6, this.tmake.Tv[this.index].Position.Z);
            if (num7 == 1)
              this.tmake.Tv[this.bitmap - 1 + y5 * this.bitmap].Normal = this.tmake.Tv[y5 * this.bitmap].Normal;
            this.tmake.normals[x2, y5] = this.normalData[xx, yy2];
            this.tmake.Tv[this.index].Normal = this.normalData[xx, yy2];
            this.textures(x2, y5, xx, yy2);
            if (!ignore && y5 % 2 == 0)
              this.rock.simpleObjectAdd(this.tmake.Tv[this.index].Position.X - 160f, this.tmake.Tv[this.index].Position.Z, ref this.tmake.heightData, ref this.tmake.normals, ref this.objectData);
          }
          else if (flag4)
          {
            this.tmake.Tv[this.xgrid + y5 * this.bitmap].Position = new Vector3(this.trnLoctn.X, -100000f, this.tmake.Tv[this.xgrid + y5 * this.bitmap].Position.Z);
            this.index = x1 + y5 * this.bitmap;
            int yy3 = this.myposz - (this.bitmap - 2) / 2 + this.range(y5 - this.lastzgrid, this.bitmap - 1) + 1;
            if (yy3 > 1999)
              yy3 -= 2000;
            if (yy3 < 0)
              yy3 += 2000;
            this.tmake.heightData[x1, y5] = this.heightData[xx, yy3];
            if (x1 == 0)
            {
              num5 = 2;
              this.tmake.heightData[this.bitmap - 1, y5] = this.heightData[xx, yy3];
            }
            float y7 = (float) this.heightData[xx, yy3];
            if (y5 == this.lastzgrid)
              y7 = -100000f;
            this.tmake.Tv[this.index].Position = new Vector3((float) (this.whatx - ((this.bitmap - 1) * this.gridscale / 2 - this.gridscale)), y7, this.tmake.Tv[this.index].Position.Z);
            if (num6 == num2)
              this.tmake.Tv[this.bitmap - 1 + y5 * this.bitmap].Normal = this.tmake.Tv[y5 * this.bitmap].Normal;
            this.tmake.normals[x1, y5] = this.normalData[xx, yy3];
            this.tmake.Tv[this.index].Normal = this.normalData[xx, yy3];
            this.textures(x1, y5, xx, yy3);
            if (!ignore && y5 % 2 == 0)
              this.rock.simpleObjectAdd(160f + this.tmake.Tv[this.index].Position.X, this.tmake.Tv[this.index].Position.Z, ref this.tmake.heightData, ref this.tmake.normals, ref this.objectData);
          }
          if (num5 > 0)
            this.tmake.Tv[this.bitmap - 1 + y5 * this.bitmap].Position = this.tmake.Tv[y5 * this.bitmap].Position;
          if (this.xgrid == 0)
            this.tmake.Tv[this.bitmap - 1 + y5 * this.bitmap].Position = this.tmake.Tv[y5 * this.bitmap].Position;
        }
      }
      this.diffix = this.whatx;
      this.lastxgrid = this.xgrid;
    }

    private void dropGems(ref gemstruct gem, int amt)
    {
      if (this.objIndex == 3)
        this.emo = GameplayScreen.act.rocked;
      float num1 = this.sc.gemDropScale / 2f * (float) amt;
      if ((double) this.sc.gemDropScale > 10.0)
        num1 = 120f;
      amt = (int) MathHelper.Clamp((float) (int) num1, 5f, 120f);
      float gemDropScale = this.sc.gemDropScale;
      Vector3 gemDropPosition = this.sc.gemDropPosition;
      Vector3 veloc = this.sc.gemDropVelocity;
      if (gem.Inst.Count >= gem.max - amt)
        gem.Inst.RemoveRange(0, amt);
      for (int index1 = 0; index1 < amt; ++index1)
      {
        float x = gemDropPosition.X + (float) this.random.Next(-900, 900) / 100f * gemDropScale;
        float z = gemDropPosition.Z + (float) this.random.Next(-900, 900) / 100f * gemDropScale;
        veloc = Vector3.Normalize(veloc);
        veloc.X += (float) this.random.Next(-300, 300) / 100f;
        veloc.Y += (float) this.random.Next(-300, 1200) / 100f;
        veloc.Z += (float) this.random.Next(-300, 300) / 100f;
        float num2 = (float) this.random.Next(-900, 900) / 100f * gemDropScale;
        float height;
        this.GetHeightOnly(ref this.tmake.heightData, new Vector3(x, 0.0f, z), out height);
        gem.Inst.Add(new gemDupe(this.sc, new Vector3(x, height + gemDropScale * 20f + num2, z), veloc, true, this.random.Next(2, 200)));
        int index2 = gem.Inst.Count - 1;
        gem.Inst[index2].onramp = 5;
        gem.Trans[index2].Trans = gem.Inst[index2].transform;
      }
    }

    private void updateGems(ref gemstruct gem)
    {
      Vector2 vector2 = new Vector2(this.trnLoctn.X, this.trnLoctn.Z);
      for (int index1 = 0; index1 < gem.Inst.Count; ++index1)
      {
        int index2 = index1;
        gem.uptheRamp(this.sc.equip[3], ref this.rover, gem.Inst[index2], ref gem.xInst, ref gem.xCount, ref gem.xTrans, ref gem.xTrack);
        if (gem.Inst[index2].move)
        {
          gem.Inst[index2].Update(ref this.tmake.heightData);
          gem.Trans[index2].Trans = gem.Inst[index2].transform;
          Vector3 vector3 = Vector3.Transform(Vector3.Zero, gem.Inst[index2].transform);
          if ((double) Vector2.DistanceSquared(vector2, new Vector2(vector3.X, vector3.Z)) > 1224999936.0)
            gem.Inst[index2].move = false;
        }
        else
        {
          gem.Inst.RemoveAt(index2);
          --index1;
        }
      }
    }

    private void nearScooper(ref gemstruct gem, SoundEffect soundy)
    {
      if (gem.Inst.Count > gem.max - 1)
        return;
      for (int index1 = 0; index1 < gem.Inst.Count; ++index1)
      {
        Vector3 mypos1 = gem.Inst[index1].mypos;
        if (this.sc.equip[3] == 1 && (double) Vector3.Distance(mypos1, this.bucketRegion1[1]) < 60.0)
        {
          int num1 = 0;
          float num2 = 0.0f;
          float num3 = 0.0f;
          Vector2 vector2_1 = new Vector2(this.bucketRegion1[3].X, this.bucketRegion1[3].Z);
          Vector2 zero = Vector2.Zero;
          Vector2 vector2_2 = new Vector2(mypos1.X, mypos1.Z);
          for (int index2 = 0; index2 < 4; ++index2)
          {
            Vector2 vector2_3 = vector2_1;
            vector2_1 = new Vector2(this.bucketRegion1[index2].X, this.bucketRegion1[index2].Z);
            Vector2 vector2_4 = vector2_2 - vector2_3;
            Vector2 vector2_5 = vector2_2 - vector2_1;
            float num4 = (float) ((double) vector2_4.X * (double) vector2_5.Y - (double) vector2_5.X * (double) vector2_4.Y);
            float num5 = (float) Math.Acos((double) Vector2.Dot(vector2_4, vector2_5) / ((double) vector2_4.Length() * (double) vector2_5.Length()));
            float num6 = (double) num4 > 0.0 ? num5 : -num5;
            if ((double) Math.Abs(num6) > (double) num3)
            {
              num3 = Math.Abs(num6);
              num1 = index2;
            }
            if (index2 > 0)
              num2 += num6;
          }
          if ((double) Math.Abs(num2) >= 3.1415927410125732 && num1 != 3 && gem.Inst.Count < gem.max)
          {
            float scaler = gem.Inst[index1].scaler;
            Matrix rot = gem.Inst[index1].myRot;
            gem.Inst.Add(new gemDupe(this.sc, mypos1, Vector3.Zero, false, this.random.Next(5, 300)));
            int index3 = gem.Inst.Count - 1;
            gem.Inst[index3].onramp = 1;
            gem.Inst[index3].move = true;
            gem.Inst[index3].myRot = rot;
            gem.Inst[index3].scaler = scaler;
            Vector3 vector3_1 = this.bucketRegion1[0];
            Vector3 vector3_2 = this.bucketRegion1[1];
            Vector3 vector3_3 = this.bucketRegion1[2];
            Vector3 vector3_4 = this.bucketRegion1[3];
            Vector3 vector3_5 = this.origRegion1[0] * 30f;
            Vector3 vector3_6 = this.origRegion1[1] * 30f;
            Vector3 vector3_7 = this.origRegion1[2] * 30f;
            Vector3 vector3_8 = this.origRegion1[3] * 30f;
            Vector3 mypos2 = gem.Inst[index3].mypos;
            float num7 = Vector3.Distance(vector3_1, vector3_2);
            float num8 = Vector3.Distance(vector3_2, mypos2);
            float num9 = Vector3.Distance(vector3_1, mypos2);
            float num10 = Vector3.Distance(vector3_2, vector3_3);
            float num11 = Vector3.Distance(vector3_1, vector3_4);
            float num12 = Vector3.Distance(vector3_3, mypos2);
            double num13 = (double) Vector3.Distance(vector3_4, mypos2);
            double num14 = (double) Vector3.Distance(vector3_3, vector3_4);
            float num15 = (float) Math.Sin(Math.Acos(((double) num7 * (double) num7 + (double) num8 * (double) num8 - (double) num9 * (double) num9) / (2.0 * (double) num7 * (double) num8))) * num8;
            float amount1 = num15 / num10;
            float amount2 = num15 / num11;
            Vector3 vector3_9 = Vector3.Lerp(vector3_2, vector3_3, amount1);
            Vector3 vector3_10 = Vector3.Lerp(vector3_6, vector3_7, amount1);
            Vector3 vector3_11 = Vector3.Lerp(vector3_1, vector3_4, amount2);
            Vector3 vector3_12 = Vector3.Lerp(vector3_5, vector3_8, amount2);
            float amount3 = (float) Math.Sin(Math.Acos(((double) num10 * (double) num10 + (double) num12 * (double) num12 - (double) num8 * (double) num8) / (2.0 * (double) num10 * (double) num12))) * num12 / Vector3.Distance(vector3_9, vector3_11);
            gem.Inst[index3].mypos = Vector3.Lerp(vector3_10, vector3_12, amount3);
            gem.Inst[index3].oldpos = gem.Inst[index3].mypos;
            gem.Inst[index3].myRot *= Matrix.CreateRotationY(-this.rover.facingDirection) * Matrix.CreateRotationX(0.44f);
            gem.Inst[index3].velocity += new Vector3((float) this.random.Next(-100, 100) / 300f, (float) this.random.Next(80, 200) / 300f, (float) this.random.Next(-100, 100) / 300f);
            soundy.Play(this.sc.ev, (float) this.random.Next(-30, 70) / 100f, 0.0f);
            gem.Inst.RemoveAt(index1);
            break;
          }
        }
      }
    }

    public void clearDumper()
    {
      if (gemstruct.totalGems > 0)
      {
        gemstruct.totalGems = 0;
        this.refineShale = this.shale1.xCount;
        this.refineRuby = this.shale2.xCount;
        this.refineBlue = this.shale3.xCount;
        this.shale2.xTrack = 0;
        this.shale2.xCount = 0;
        Array.Clear((Array) this.shale2.xInst, 0, this.shale2.xInst.Length);
        Array.Clear((Array) this.shale2.xTrans, 0, this.shale2.xInst.Length);
        this.shale1.xTrack = 0;
        this.shale1.xCount = 0;
        Array.Clear((Array) this.shale1.xInst, 0, this.shale1.xInst.Length);
        Array.Clear((Array) this.shale1.xTrans, 0, this.shale1.xInst.Length);
        this.shale3.xTrack = 0;
        this.shale3.xCount = 0;
        Array.Clear((Array) this.shale3.xInst, 0, this.shale3.xInst.Length);
        Array.Clear((Array) this.shale3.xTrans, 0, this.shale3.xInst.Length);
      }
      else
        this.sc.confirm.Play(this.sc.ev, 0.0f, 0.0f);
    }

    public void openHatch(bool force)
    {
      if (!force && (this.lander.onDropship || this.lander.impact != 1 || (double) this.lander.diff > 40.0 || this.lander.door1 != 1 || (double) this.lander.normal.Y <= 0.89999997615814209))
      {
        this.sc.warning.Play(this.sc.ev, -0.3f, 0.0f);
      }
      else
      {
        this.lander.commandFlag = 1;
        this.sc.ramp.Play(this.sc.ev, 0.0f, 0.0f);
        this.rover.directme = this.lander.directme;
        if ((double) this.rover.directme < 0.0)
          this.rover.directme += 6.28f;
        this.rover.directme = this.lander.directme - MathHelper.ToRadians(-135f);
        if ((double) this.rover.directme < 0.0)
          this.rover.directme += 6.28f;
        if (force)
          return;
        this.rover.position.X = this.lander.position.X;
        this.rover.position.Y = this.lander.position.Y;
        this.rover.position.Z = this.lander.position.Z;
        this.rover.facingDirection = this.rover.directme;
        this.rover.orientation = Matrix.CreateRotationY(this.rover.directme);
        this.rover.orientation.Up = this.lander.orientation.Up;
        this.rover.orientation.Right = Vector3.Cross(this.rover.orientation.Forward, this.rover.orientation.Up);
        this.rover.orientation.Right = Vector3.Normalize(this.rover.orientation.Right);
        this.rover.orientation.Forward = Vector3.Cross(this.rover.orientation.Up, this.rover.orientation.Right);
        this.rover.orientation.Forward = Vector3.Normalize(this.rover.orientation.Forward);
        this.rover.onramp = 3;
        this.lastpos = this.rover.position;
        this.rover.grav = Vector3.Zero;
        this.rover.movement = Vector3.Zero;
        this.rover.thumb = 0.0f;
        this.rover.righttrig = 0.0f;
      }
    }

    private void addPrint(Matrix mm)
    {
      this.prints.drift[this.prints.stainIndex] = 400f;
      this.hitstreamTemp.Trans = mm;
      this.hitstreamTemp.Fade = 1f;
      this.prints.stainTrans[this.prints.stainIndex] = this.hitstreamTemp;
      ++this.prints.stainIndex;
      if (this.prints.stainIndex > this.prints.stainCapacity - 1)
        this.prints.stainIndex = 0;
      ++this.prints.stainMax;
      if (this.prints.stainMax <= this.prints.stainCapacity - 1)
        return;
      this.prints.stainMax = this.prints.stainCapacity;
    }

    private void updatePrints()
    {
      for (int index = 0; index < this.prints.stainMax; ++index)
      {
        --this.prints.drift[index];
        if ((double) this.prints.drift[index] < 1.0)
          this.prints.stainTrans[index].Fade -= 3f / 500f;
        this.prints.stainTrans[index].Trans = this.prints.stainTrans[index].Trans;
        if ((double) this.prints.stainTrans[index].Fade <= 0.0)
        {
          this.prints.drift[index] = this.prints.drift[this.prints.stainMax - 1];
          this.prints.stainTrans[index].Fade = this.prints.stainTrans[this.prints.stainMax - 1].Fade;
          this.prints.stainTrans[index].Trans = this.prints.stainTrans[this.prints.stainMax - 1].Trans;
          --this.prints.stainMax;
          if (this.prints.stainMax < 0)
            this.prints.stainMax = 0;
          if (this.prints.stainIndex > this.prints.stainMax - 1)
            --this.prints.stainIndex;
          if (this.prints.stainIndex < 0)
            this.prints.stainIndex = 0;
        }
      }
    }

    private void removePoly(int x, int z)
    {
      int num1 = (int) ((double) ((z + this.gridscale / 2) / this.gridscale % this.unit) + 1.5 * (double) this.unit) % this.unit;
      int num2 = (int) ((double) ((x + this.gridscale / 2) / this.gridscale % this.unit) + 1.5 * (double) this.unit) % this.unit;
      this.tmake.Tv[num2 + num1 * this.bitmap].TexWeights.X = -5000f;
      this.tmake.Tv[num2 + num1 * this.bitmap].TexWeights.Y = -5000f;
      this.tmake.Tv[num2 + num1 * this.bitmap].TexWeights.Z = -5000f;
      this.tmake.Tv[num2 + num1 * this.bitmap].TexWeights.W = -5000f;
      this.tmake.Tv[num2 + num1 * this.bitmap].Position.Y = -5000f;
      int num3 = num1 - 1;
      this.tmake.Tv[num2 + num3 * this.bitmap].TexWeights.X = -5000f;
      this.tmake.Tv[num2 + num3 * this.bitmap].TexWeights.Y = -5000f;
      this.tmake.Tv[num2 + num3 * this.bitmap].TexWeights.Z = -5000f;
      this.tmake.Tv[num2 + num3 * this.bitmap].TexWeights.W = -5000f;
      this.tmake.Tv[num2 + num3 * this.bitmap].Position.Y = -5000f;
      int num4 = num3 - 1;
      this.tmake.Tv[num2 + num4 * this.bitmap].TexWeights.X = -5000f;
      this.tmake.Tv[num2 + num4 * this.bitmap].TexWeights.Y = -5000f;
      this.tmake.Tv[num2 + num4 * this.bitmap].TexWeights.Z = -5000f;
      this.tmake.Tv[num2 + num4 * this.bitmap].TexWeights.W = -5000f;
      this.tmake.Tv[num2 + num4 * this.bitmap].Position.Y = -5000f;
    }

    private void rebuildFacility()
    {
      this.GetHeightOnly(ref this.tmake.heightData, new Vector3(this.facility.facilityLocate.X, 0.0f, this.facility.facilityLocate.Y), out this.groundHeight);
      Facility.offset = new Vector3(this.facility.facilityLocate.X - 2250f, this.groundHeight - 1441f / this.facility.scaler, this.facility.facilityLocate.Y - 4337.5f);
      this.facility.buildFloor(3);
      this.facility.updateGateCollision();
      this.removePoly((int) this.facility.facilityLocate.X, (int) this.facility.facilityLocate.Y);
      this.facility.rebuild = false;
    }

    public bool KMdown(Keys k)
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

    public bool method_0(Keys k)
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

    public bool KMtoggle(Keys k)
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

    public bool Kdown(Keys k) => this.keyState.IsKeyDown(k);

    public override void HandleInput(InputState input)
    {
      if (input == null)
        throw new ArgumentNullException(nameof (input));
      this.ControllingPlayer = new PlayerIndex?(this.sc.playerindex);
      this.myplayer = this.sc.playerindex;
      this.gamePadState = input.CurrentGamePadStates[(int) this.sc.playerindex];
      bool flag1 = !this.gamePadState.IsConnected && input.GamePadWasConnected[(int) this.sc.playerindex];
      this.prevkeyState = input.lastKeyState;
      this.keyState = input.currentKeyState;
      this.prevMouse = this.mouseState;
      this.mouseState = Mouse.GetState();
      if (this.myframe % 120 == 0)
        this.sc.centerWindow();
      if (!this.editcam)
        Mouse.SetPosition((int) this.sc.winCorner.X, (int) this.sc.winCorner.Y);
      this.sc.mymouse.X = (float) this.mouseState.X;
      this.sc.mymouse.Y = (float) this.mouseState.Y;
      this.mouseX = (float) (this.mouseState.X - (int) this.sc.winCorner.X);
      this.mouseY = (float) (this.mouseState.Y - (int) this.sc.winCorner.Y);
      if (this.delayinput)
      {
        this.prevMouse = this.mouseState;
        this.prevkeyState = this.keyState;
        this.delayinput = false;
        this.sc.centerWindow();
      }
      if (Facility.openConstruction)
      {
        this.editcam = false;
        GamePad.SetVibration(this.myplayer, 0.0f, 0.0f);
        Facility.openConstruction = false;
        this.sc.AddScreen((GameScreen) new Construction(ref this.facility), this.ControllingPlayer);
      }
      if (!this.Ktoggle(this.sc.escape_key) && !input.IsPauseGame(this.ControllingPlayer) && !flag1 && !input.IsMenuGame(this.ControllingPlayer))
      {
        if (this.vehicleindex != 3 && this.Ktoggle(this.sc.f1_key))
        {
          this.editcam = !this.editcam;
          this.camadjust = false;
          this.sc.tick.Play(this.sc.ev, 0.2f, 0.0f);
          if (!this.editcam)
            this.sc.SaveSpacePrefs();
        }
        if (this.editcam)
        {
          if (this.vehicleindex == 3)
            this.editcam = false;
          this.camadjust = false;
          this.sc.Game.IsMouseVisible = true;
          if (this.Ktoggle(Keys.Tab) || this.KMtoggle(this.sc.tab_key))
          {
            int num = 0;
            if (this.vehicleindex == 1)
            {
              ++this.sc.roverindex;
              if (this.sc.roverindex > 2)
                this.sc.roverindex = 0;
              this.yy = this.sc.roverheight[this.sc.roverindex];
              this.rot = this.sc.roverradian[this.sc.roverindex];
              num = this.sc.roverindex + 1;
            }
            if (this.vehicleindex == 2)
            {
              ++this.sc.landerindex;
              if (this.sc.landerindex > 2)
                this.sc.landerindex = 0;
              this.yy = this.sc.landerheight[this.sc.landerindex];
              this.rot = this.sc.landerheight[this.sc.landerindex];
              num = this.sc.landerindex + 1;
            }
            if (this.memoTimer <= 0 || this.memoIcon == 7)
            {
              this.memoTimer = 150;
              this.memoIcon = 7;
              GameplayScreen.memo.Length = 0;
              GameplayScreen.memo.Append("Camera " + num.ToString());
            }
          }
          if (this.vehicleindex == 1)
          {
            Rectangle rr = new Rectangle((int) this.menuposition.X, (int) this.menuposition.Y, this.rovercamedit.Width, this.rovercamedit.Height);
            if (!this.queryButton2(rr))
            {
              this.camadjust = true;
              this.sc.Game.IsMouseVisible = false;
              this.buttonchoice = this.buttonhand;
            }
            rr = new Rectangle((int) ((double) this.pointbox1[0].X + (double) this.menuposition.X), (int) ((double) this.pointbox1[0].Y + (double) this.menuposition.Y), 23, 24);
            if (this.queryButton2(rr) && this.KMtoggle(this.sc.lmb_key))
            {
              if (this.sc.roverrotlock == 0)
              {
                this.sc.roverradian[0] = this.sc.roverradian[0] + this.rover.facingDirection;
                this.sc.roverradian[1] = this.sc.roverradian[1] + this.rover.facingDirection;
                this.sc.roverradian[2] = this.sc.roverradian[2] + this.rover.facingDirection;
              }
              if (this.sc.roverrotlock == 2)
              {
                this.sc.roverradian[0] = this.sc.roverradian[0] - this.rover.facingDirection;
                this.sc.roverradian[1] = this.sc.roverradian[1] - this.rover.facingDirection;
                this.sc.roverradian[2] = this.sc.roverradian[2] - this.rover.facingDirection;
              }
              if ((double) this.sc.roverradian[0] > 6.2831850051879883)
                this.sc.roverradian[0] -= 6.283185f;
              if ((double) this.sc.roverradian[0] < 0.0)
                this.sc.roverradian[0] += 6.283185f;
              if ((double) this.sc.roverradian[1] > 6.2831850051879883)
                this.sc.roverradian[1] -= 6.283185f;
              if ((double) this.sc.roverradian[1] < 0.0)
                this.sc.roverradian[1] += 6.283185f;
              if ((double) this.sc.roverradian[2] > 6.2831850051879883)
                this.sc.roverradian[2] -= 6.283185f;
              if ((double) this.sc.roverradian[2] < 0.0)
                this.sc.roverradian[2] += 6.283185f;
              this.rot = this.sc.roverradian[this.sc.roverindex];
              ++this.sc.roverrotlock;
              if (this.sc.roverrotlock == 1 && this.softlockMess1)
              {
                this.sc.AddScreen((GameScreen) new messagebox("Camera Softlock Selected\nHold Spacebar While Driving", 0, 0), new PlayerIndex?());
                this.softlockMess1 = false;
              }
              if (this.sc.roverrotlock > 2)
                this.sc.roverrotlock = 0;
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            rr = new Rectangle((int) ((double) this.pointbox1[1].X + (double) this.menuposition.X), (int) ((double) this.pointbox1[1].Y + (double) this.menuposition.Y), 23, 24);
            if (this.queryButton2(rr) && this.KMtoggle(this.sc.lmb_key))
            {
              ++this.sc.roverhitelock;
              if (this.sc.roverhitelock == 1 && this.softlockMess1)
              {
                this.sc.AddScreen((GameScreen) new messagebox("Camera Softlock Selected\nHold Spacebar While Driving", 0, 0), new PlayerIndex?());
                this.softlockMess1 = false;
              }
              if (this.sc.roverhitelock > 2)
                this.sc.roverhitelock = 0;
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            rr = new Rectangle((int) ((double) this.pointbox1[2].X + (double) this.menuposition.X), (int) ((double) this.pointbox1[2].Y + (double) this.menuposition.Y), 23, 24);
            if (this.queryButton2(rr) && this.KMtoggle(this.sc.lmb_key))
            {
              this.sc.space_rinvertX = this.sc.space_rinvertX != -1 ? -1 : 1;
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            rr = new Rectangle((int) ((double) this.pointbox1[3].X + (double) this.menuposition.X), (int) ((double) this.pointbox1[3].Y + (double) this.menuposition.Y), 23, 24);
            if (this.queryButton2(rr) && this.KMtoggle(this.sc.lmb_key))
            {
              this.sc.space_rinvertY = this.sc.space_rinvertY != -1 ? -1 : 1;
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            float num1 = (float) ((this.mouseState.X - this.prevMouse.X) * 4);
            float num2 = (float) ((this.mouseState.Y - this.prevMouse.Y) * 4);
            float num3 = 0.0f;
            if (this.camadjust && this.KMdown(this.sc.lmb_key))
            {
              this.buttonchoice = this.buttonhand;
              num3 = (float) (-(double) num1 * (0.00089999998454004526 * (double) this.sc.space_rsentivityX)) * (float) this.sc.space_rinvertX;
            }
            this.sc.roverradian[this.sc.roverindex] = this.rot;
            this.rot += num3;
            if ((double) this.rot > 6.2831850051879883)
              this.rot = 0.0f;
            if ((double) this.rot < 0.0)
              this.rot = 6.283185f;
            this.aUppy = Vector3.Up;
            if (this.sc.roverrotlock > 0)
            {
              this.myrotter = this.rot - this.rover.facingDirection;
              if ((double) this.myrotter > 6.2831850051879883)
                this.myrotter -= 6.283185f;
              if ((double) this.myrotter < 0.0)
                this.myrotter += 6.283185f;
            }
            else
              this.myrotter = this.rot;
            if (this.camadjust && this.KMdown(this.sc.rmb_key))
            {
              this.buttonchoice = this.buttonzoom;
              this.sc.roverdist[this.sc.roverindex] += num2 * 2f;
              this.sc.roverdist[this.sc.roverindex] = MathHelper.Clamp(this.sc.roverdist[this.sc.roverindex], 50f, 2200f);
            }
            this.xx = (float) Math.Sin((double) this.myrotter) * this.sc.roverdist[this.sc.roverindex];
            this.zz = (float) -Math.Cos((double) this.myrotter) * this.sc.roverdist[this.sc.roverindex];
            this.aCampos.X = this.rover.position.X + this.xx;
            this.aCampos.Y = this.rover.position.Y + this.yy;
            this.aCampos.Z = this.rover.position.Z + this.zz;
            float height;
            this.GetHeightOnly(ref this.tmake.heightData, this.aCampos, out height);
            if ((double) this.aCampos.Y < (double) height + (double) this.roverY)
            {
              this.aCampos.Y = height + (float) this.roverY;
              this.yy = this.aCampos.Y - this.rover.position.Y;
            }
            if (this.camadjust && this.KMdown(this.sc.lmb_key))
              this.yy += (float) (-(double) num2 * 0.40000000596046448) * this.sc.space_rsentivityY * (float) this.sc.space_rinvertY;
            this.yy = MathHelper.Clamp(this.yy, -300f, 2f * this.sc.roverdist[this.sc.roverindex]);
            this.sc.roverheight[this.sc.roverindex] = this.yy;
            if ((double) this.yy != (double) this.sc.roverheight[this.sc.roverindex])
            {
              if ((double) this.yy > (double) this.sc.roverheight[this.sc.roverindex])
                this.yy -= 5f;
              if ((double) this.yy < (double) this.sc.roverheight[this.sc.roverindex])
                this.yy += 5f;
              if ((double) Math.Abs(this.sc.roverheight[this.sc.roverindex] - this.yy) <= 6.0)
                this.yy = this.sc.roverheight[this.sc.roverindex];
            }
            this.aCamtarget.X = this.rover.position.X;
            this.aCamtarget.Y = this.rover.position.Y + 30f;
            this.aCamtarget.Z = this.rover.position.Z;
            if ((double) this.sc.roverdist[this.sc.roverindex] < 110.0)
            {
              this.rover.dashcam = 1;
              this.myrotter = 3.1415925f - this.rover.facingDirection;
              if ((double) this.myrotter < 0.0)
                this.myrotter += 6.283185f;
              if ((double) this.sc.vehiclelerp >= 1.0)
                this.rover.dashcam = 1;
              this.aCampos = this.rover.position + Vector3.Transform(new Vector3(0.0f, (float) (3.0 * (double) this.rover.scoopx + 64.0), -35f), this.rover.orientation);
              this.aCamtarget = this.rover.position + Vector3.Transform(new Vector3(0.0f, 0.0f, (float) (-((double) this.rover.scoopx * 600.0) - 350.0)), this.rover.orientation);
              this.aUppy = Vector3.Normalize(Vector3.Transform(new Vector3(0.0f, 10000f, 0.0f), this.rover.orientation));
            }
            else
              this.rover.dashcam = 0;
          }
          if (this.vehicleindex == 2)
          {
            Rectangle rr = new Rectangle((int) this.menuposition.X, (int) this.menuposition.Y, this.landercamedit.Width, this.landercamedit.Height);
            if (!this.queryButton2(rr))
            {
              this.camadjust = true;
              this.sc.Game.IsMouseVisible = false;
              this.buttonchoice = this.buttonhand;
            }
            rr = new Rectangle((int) ((double) this.pointbox1[0].X + (double) this.menuposition.X), (int) ((double) this.pointbox1[0].Y + (double) this.menuposition.Y), 23, 24);
            if (this.queryButton2(rr) && this.KMtoggle(this.sc.lmb_key))
            {
              ++this.sc.landerrotlock;
              if (this.sc.landerrotlock == 1 && this.softlockMess2)
              {
                this.sc.AddScreen((GameScreen) new messagebox("Camera Softlock Selected\nHold Spacebar While Flying", 0, 0), new PlayerIndex?());
                this.softlockMess2 = false;
              }
              if (this.sc.landerrotlock > 2)
                this.sc.landerrotlock = 0;
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            rr = new Rectangle((int) ((double) this.pointbox1[1].X + (double) this.menuposition.X), (int) ((double) this.pointbox1[1].Y + (double) this.menuposition.Y), 23, 24);
            if (this.queryButton2(rr) && this.KMtoggle(this.sc.lmb_key))
            {
              ++this.sc.landerhitelock;
              if (this.sc.landerhitelock == 1 && this.softlockMess2)
              {
                this.sc.AddScreen((GameScreen) new messagebox("Camera Softlock Selected\nHold Spacebar While Flying", 0, 0), new PlayerIndex?());
                this.softlockMess2 = false;
              }
              if (this.sc.landerhitelock > 2)
                this.sc.landerhitelock = 0;
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            rr = new Rectangle((int) ((double) this.pointbox1[2].X + (double) this.menuposition.X), (int) ((double) this.pointbox1[2].Y + (double) this.menuposition.Y), 23, 24);
            if (this.queryButton2(rr) && this.KMtoggle(this.sc.lmb_key))
            {
              this.sc.space_invertX = this.sc.space_invertX != -1 ? -1 : 1;
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            rr = new Rectangle((int) ((double) this.pointbox1[3].X + (double) this.menuposition.X), (int) ((double) this.pointbox1[3].Y + (double) this.menuposition.Y), 23, 24);
            if (this.queryButton2(rr) && this.KMtoggle(this.sc.lmb_key))
            {
              this.sc.space_invertY = this.sc.space_invertY != -1 ? -1 : 1;
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            }
            float num4 = (float) ((this.mouseState.X - this.prevMouse.X) * 4);
            float num5 = (float) ((this.mouseState.Y - this.prevMouse.Y) * 4);
            float num6 = 0.0f;
            if (this.camadjust && this.KMdown(this.sc.lmb_key))
            {
              this.buttonchoice = this.buttonhand;
              num6 = (float) (-(double) num4 * (0.00044999999227002263 * (double) this.sc.space_sentivityX)) * (float) this.sc.space_invertX;
              this.sc.landerradian[0] = this.rot;
              this.sc.landerradian[1] = this.rot;
              this.sc.landerradian[2] = this.rot;
            }
            this.rot += num6;
            if (this.camadjust && this.KMdown(this.sc.rmb_key))
            {
              this.buttonchoice = this.buttonzoom;
              this.sc.landerdist[this.sc.landerindex] += num5 * 2f;
              this.sc.landerdist[this.sc.landerindex] = MathHelper.Clamp(this.sc.landerdist[this.sc.landerindex], 250f, 3500f);
            }
            this.xx = (float) Math.Sin((double) this.rot) * this.sc.landerdist[this.sc.landerindex];
            this.zz = (float) -Math.Cos((double) this.rot) * this.sc.landerdist[this.sc.landerindex];
            this.yy = MathHelper.Clamp(this.yy, -800f, this.sc.landerdist[this.sc.landerindex] * 2f);
            this.aCampos = this.lander.position + new Vector3(this.xx, this.yy, this.zz);
            float height;
            this.GetHeightOnly(ref this.tmake.heightData, this.aCampos, out height);
            if ((double) this.aCampos.Y < (double) height + (double) this.landerY)
            {
              this.aCampos.Y = height + (float) this.landerY;
              this.yy = this.aCampos.Y - this.lander.position.Y;
            }
            if (this.camadjust && this.KMdown(this.sc.lmb_key))
              this.yy += (float) (-(double) num5 * 0.34999999403953552) * this.sc.space_sentivityY * (float) this.sc.space_invertY;
            this.yy = MathHelper.Clamp(this.yy, -800f, this.sc.landerdist[this.sc.landerindex] * 2f);
            this.sc.landerheight[this.sc.landerindex] = this.yy;
            if ((double) this.yy != (double) this.sc.landerheight[this.sc.landerindex])
            {
              if ((double) this.yy > (double) this.sc.landerheight[this.sc.landerindex])
                this.yy -= 5f;
              if ((double) this.yy < (double) this.sc.landerheight[this.sc.landerindex])
                this.yy += 5f;
              if ((double) Math.Abs(this.sc.landerheight[this.sc.landerindex] - this.yy) <= 6.0)
                this.yy = this.sc.landerheight[this.sc.landerindex];
            }
            this.aCamtarget.X = this.lander.position.X;
            this.aCamtarget.Y = this.lander.position.Y;
            this.aCamtarget.Z = this.lander.position.Z;
          }
          this.viewMatrix = Matrix.CreateLookAt(this.aCampos, this.aCamtarget, this.aUppy);
        }
        else
        {
          this.sc.Game.IsMouseVisible = false;
          if (this.sc.developer && this.KMtoggle(Keys.F7))
            this.sc.cheat_astro = !this.sc.cheat_astro;
          if (this.sc.cheat_astro && this.Ktoggle(Keys.F5))
            Facility.openConstruction = true;
          if (this.sc.cheat_astro && !this.nearAstro && (this.Ktoggle(this.sc.space_key) || this.gamePadState.Buttons.X == ButtonState.Pressed && this.prevstate.Buttons.X == ButtonState.Released))
          {
            if (!Facility.inFacility)
              this.sc.astronaut.dropAstronaut(this.myframe, new Vector2(this.trnLoctn.X + 150f, this.trnLoctn.Z), 1, astroDupe.emotion.safe);
            else
              this.sc.astronaut.dropFacilityAstronaut(this.myframe, new Vector2(this.trnLoctn.X, this.trnLoctn.Z), astroDupe.emotion.underground, (float) this.random.Next(-300, 300) / 50f);
          }
          bool flag2 = false;
          int num7;
          if (this.vehicleindex == 2)
          {
            this.rover.dashcam = 0;
            float num8 = 0.96f;
            if (this.sc.usingMouse)
            {
              num8 = 1f;
              this.overlay.fuelDec -= this.lander.rightTrigger / 100f;
            }
            else if ((double) this.lander.rightTrigger >= (double) num8)
              this.overlay.fuelDec -= this.lander.speed / 60f;
            else
              this.overlay.fuelDec -= this.lander.rightTrigger / 140f;
            if ((double) this.overlay.fuelDec < 0.0)
            {
              this.overlay.fuelDec = 1f;
              --this.overlay.fuelAMT;
            }
            this.lander.thrust = (float) Math.Pow((double) this.overlay.fuelAMT / 100.0, 0.20000000298023224) * 1.4f;
            if ((double) this.lander.rightTrigger >= (double) num8)
            {
              this.landerDrips();
              if (!this.sc.usingMouse)
                this.lander.thrust = this.lander.maxthrust;
            }
            else
            {
              this.lastleg1 = Vector3.Zero;
              this.lastleg2 = Vector3.Zero;
              this.lastleg3 = Vector3.Zero;
              this.lastleg4 = Vector3.Zero;
            }
            if (this.overlay.fuelAMT <= 4)
              this.lander.thrust = 0.3f;
            if (this.myframe % 2 == 0 && this.refineShale > 0)
            {
              if (this.objIndex == 4)
                this.emo = GameplayScreen.act.refined;
              --this.refineShale;
              this.overlay.fuelTick += 0.4f;
            }
            if (this.myframe % 5 == 0 && this.refineShale <= 0 && this.refineRuby > 0)
            {
              if (this.objIndex == 4)
                this.emo = GameplayScreen.act.refined;
              --this.refineRuby;
              this.overlay.fuelTick += 1.5f;
            }
            if (this.myframe % 6 == 0 && this.refineShale <= 0 && this.refineRuby <= 0 && this.refineBlue > 0)
            {
              if (this.objIndex == 4)
                this.emo = GameplayScreen.act.refined;
              --this.refineBlue;
              this.overlay.fuelTick += 2.5f;
            }
            if ((double) this.overlay.fuelTick > 1.0)
            {
              ++this.overlay.fuelAMT;
              float pitch = (float) this.overlay.fuelAMT / 80f - 0.3f;
              this.overlay.fuelTick = 0.0f;
              if (this.refineShale > 0)
                this.sc.tick.Play(this.sc.ev * 0.6f, pitch, 0.0f);
              else if (this.refineRuby > 0)
                this.sc.boulderhit2.Play(this.sc.ev, pitch, 0.0f);
              else
                this.sc.boulderhit4.Play(this.sc.ev, pitch, 0.0f);
            }
            if (this.nearfarm)
              this.lander.HandleInput(ref this.mouseState, ref this.prevMouse, ref this.keyState, ref this.prevkeyState, ref this.gamePadState, ref this.heights, ref this.tmake.normals);
            else
              this.lander.HandleInput(ref this.mouseState, ref this.prevMouse, ref this.keyState, ref this.prevkeyState, ref this.gamePadState, ref this.tmake.heightData, ref this.tmake.normals);
            if ((double) this.lander.normalizedSpeed > 0.0)
            {
              float normalizedSpeed = this.lander.normalizedSpeed;
              if ((double) this.lander.lander2ground < 2000.0 || this.lander.onDropship)
                this.ejecta((int) ((double) normalizedSpeed * 250.0));
              if (this.landerEngineI.State == SoundState.Stopped)
              {
                this.landerEngineI.IsLooped = true;
                this.landerEngineI.Pitch = (float) ((double) normalizedSpeed * 2.0 - 1.0);
                this.landerEngineI.Volume = normalizedSpeed * this.sc.ev;
                this.landerEngineI.Play();
              }
              else
              {
                this.landerEngineI.Resume();
                this.landerEngineI.Pitch = (float) ((double) normalizedSpeed * 2.0 - 1.0);
                this.landerEngineI.Volume = normalizedSpeed * this.sc.ev;
              }
              float num9 = 1f - MathHelper.Clamp(this.lander.lander2ground / 1500f, 0.0f, 1f);
              if ((double) num9 > 0.0 && this.sc.vibroSetting == 1)
                GamePad.SetVibration(this.myplayer, (float) ((double) normalizedSpeed / 2.5 + 0.10000000149011612) * num9, (float) ((double) normalizedSpeed / 2.5 + 0.11999999731779099) * num9);
            }
            else
            {
              if ((double) this.vibrateLander == 0.0 && this.vibrateControl < 3)
                GamePad.SetVibration(this.myplayer, 0.0f, 0.0f);
              if (this.landerEngineI.State == SoundState.Playing)
                this.landerEngineI.Pause();
            }
            if (this.lander.rampSwitch == 1)
            {
              this.lander.rampSwitch = 0;
              this.rover.region1 = this.lander.region1;
              this.rover.region3 = this.lander.region2;
              this.rover.region2[0] = this.rover.region1[9];
              this.rover.region2[1] = this.rover.region1[10];
              this.rover.region2[2] = this.rover.region1[11];
              this.rover.region2[3] = this.rover.region1[6];
              this.rover.region2[4] = this.rover.region1[7];
              this.rover.region2[5] = this.rover.region1[8];
              this.rover.region2[6] = this.rover.region3[3];
              this.rover.region2[7] = this.rover.region3[4];
              this.rover.region2[8] = this.rover.region3[5];
              this.rover.region2[9] = this.rover.region3[0];
              this.rover.region2[10] = this.rover.region3[1];
              this.rover.region2[11] = this.rover.region3[2];
              Vector3 vector3 = Vector3.Normalize(Vector3.Lerp(new Vector3(this.rover.region1[12], this.rover.region1[13], this.rover.region1[14]), new Vector3(this.rover.region3[12], this.rover.region3[13], this.rover.region3[14]), 0.5f));
              this.rover.region2[12] = vector3.X;
              this.rover.region2[13] = vector3.Y;
              this.rover.region2[14] = vector3.Z;
              this.vehicleindex = 1;
              this.overlay.buttonindex = this.roverbuttonindex;
              this.sc.vehiclelerp = 0.0f;
              GamePad.SetVibration(this.myplayer, 0.0f, 0.0f);
              if (this.landerEngineI.State == SoundState.Playing)
                this.landerEngineI.Pause();
              this.bCampos = this.aCampos;
              this.bCamtarget = this.aCamtarget;
              this.bUppy = this.aUppy;
            }
            if (this.Ktoggle(this.sc.right_key) || this.gamePadState.DPad.Right == ButtonState.Pressed && this.prevstate.DPad.Right == ButtonState.Released)
            {
              ++this.landerbuttonindex;
              if (this.landerbuttonindex > 4)
                this.landerbuttonindex = 1;
              this.overlay.buttonindex = this.landerbuttonindex;
              this.sc.click.Play(this.sc.ev, 0.0f, 0.0f);
            }
            if (this.Ktoggle(this.sc.left_key) || this.gamePadState.DPad.Left == ButtonState.Pressed && this.prevstate.DPad.Left == ButtonState.Released)
            {
              --this.landerbuttonindex;
              if (this.landerbuttonindex < 1)
                this.landerbuttonindex = 4;
              this.sc.click.Play(this.sc.ev, 0.0f, 0.0f);
              this.overlay.buttonindex = this.landerbuttonindex;
            }
            bool flag3 = this.Ktoggle(this.sc.one_key) || this.Ktoggle(this.sc.two_key) || this.Ktoggle(this.sc.three_key) || this.Ktoggle(this.sc.four_key);
            if (this.Ktoggle(this.sc.up_key) || flag3 || this.gamePadState.Buttons.A == ButtonState.Pressed && this.prevstate.Buttons.A == ButtonState.Released)
            {
              int num10 = this.landerbuttonindex;
              if (this.sc.usingMouse)
              {
                if (this.Ktoggle(this.sc.one_key))
                  num10 = 1;
                if (this.Ktoggle(this.sc.two_key))
                  num10 = 2;
                if (this.Ktoggle(this.sc.three_key))
                  num10 = 3;
                if (this.Ktoggle(this.sc.four_key))
                {
                  num7 = 4;
                  goto label_224;
                }
              }
              switch (num10)
              {
                case 1:
                  this.overlay.landerbutton1 = 50;
                  if (this.lander.door1 == 1)
                  {
                    this.openHatch(false);
                    goto label_233;
                  }
                  else if (this.lander.door1 == 10)
                  {
                    this.sc.ramp.Play(this.sc.ev, 0.0f, 0.0f);
                    this.lander.commandFlag = 2;
                    goto label_233;
                  }
                  else
                    goto label_233;
                case 2:
                  this.clearDumper();
                  this.overlay.landerbutton2 = 50;
                  goto label_233;
                case 3:
                  this.overlay.landerbutton3 = 50;
                  if (this.lander.radioFixed)
                  {
                    if ((double) this.flowervol < 0.30000001192092896)
                    {
                      ++this.radiocount;
                      this.radiotimer = 20;
                    }
                    if (this.rock.chosenfar == -1 && this.flowervolumeTimer <= 0)
                    {
                      if (this.radiocount != 13)
                        this.sc.radio1.Play(this.sc.ev, (float) this.random.Next(-40, 40) / 100f, (float) this.random.Next(-60, 80) / 100f);
                      if (this.radiocount == 13 && (double) this.flowervol < 0.10000000149011612)
                        this.sc.abort.Play(this.sc.ev, 1f, 0.0f);
                    }
                    this.landerbuttonindex = 3;
                    this.flowervolumeTimer = 900;
                    this.overlay.landerbutton3 = 1800;
                    goto label_233;
                  }
                  else
                  {
                    this.sc.abort.Play(this.sc.ev, -0.4f, 0.3f);
                    goto label_233;
                  }
                case 4:
                  break;
                default:
                  goto label_233;
              }
label_224:
              this.overlay.landerbutton4 = 50;
              Vector3 vector3 = this.lander.position + Vector3.Transform(new Vector3(-200f, 0.0f, -200f), this.lander.orientation);
              float height;
              this.GetHeightOnly(ref this.tmake.heightData, new Vector3(vector3.X, vector3.Y, vector3.Z), out height);
              if (this.overlay.nextBouy == 1)
              {
                this.overlay.bouy1.X = vector3.X;
                this.overlay.bouy1.Y = height;
                this.overlay.bouy1.Z = vector3.Z;
                this.sc.dropBeacon.Play(this.sc.ev, 0.0f, 0.0f);
              }
              else if (this.overlay.nextBouy == 2)
              {
                this.overlay.bouy2.X = vector3.X;
                this.overlay.bouy2.Y = height;
                this.overlay.bouy2.Z = vector3.Z;
                this.sc.dropBeacon.Play(this.sc.ev, 0.0f, 0.0f);
              }
              else
                this.sc.rejected.Play(this.sc.ev, 0.0f, 0.0f);
              this.overlay.nextBouy = 0;
              if (this.overlay.bouy1 == Vector3.Zero)
                this.overlay.nextBouy = 1;
              else if (this.overlay.bouy2 == Vector3.Zero)
                this.overlay.nextBouy = 2;
            }
label_233:
            if ((double) this.lander.leftTrigger > 0.0)
              this.openHatch(false);
            if (this.gamePadState.Buttons.Y == ButtonState.Pressed && this.prevstate.Buttons.Y == ButtonState.Released)
            {
              Vector3 vector3 = this.vehicleindex != 1 ? this.lander.position + Vector3.Transform(new Vector3(-200f, 0.0f, -200f), this.lander.orientation) : this.rover.position + Vector3.Transform(new Vector3((float) this.random.Next(-10, 10), 0.0f, 200f), this.rover.orientation);
              float height;
              this.GetHeightOnly(ref this.tmake.heightData, new Vector3(vector3.X, vector3.Y, vector3.Z), out height);
              if (this.overlay.nextBouy == 1)
              {
                this.overlay.bouy1.X = vector3.X;
                this.overlay.bouy1.Y = height;
                this.overlay.bouy1.Z = vector3.Z;
                this.sc.dropBeacon.Play(this.sc.ev, 0.0f, 0.0f);
              }
              if (this.overlay.nextBouy == 2)
              {
                this.overlay.bouy2.X = vector3.X;
                this.overlay.bouy2.Y = height;
                this.overlay.bouy2.Z = vector3.Z;
                this.sc.dropBeacon.Play(this.sc.ev, 0.0f, 0.0f);
              }
              this.overlay.nextBouy = 0;
              if (this.overlay.bouy1 == Vector3.Zero)
                this.overlay.nextBouy = 1;
              else if (this.overlay.bouy2 == Vector3.Zero)
                this.overlay.nextBouy = 2;
            }
          }
          if (this.vehicleindex == 1)
          {
            if (this.rover.solar1 == 100 && this.myframe % 5 == 0)
            {
              if ((double) this.sunDir.Y < 0.0)
              {
                float num11 = -Vector3.Dot(Vector3.Transform(new Vector3(1f, -0.6f, 0.0f), this.rover.orientation), this.sunDir);
                if ((double) num11 > 0.0)
                {
                  this.overlay.cellTick += (double) this.rover.movement.Z != 0.0 ? num11 * 1.8f : num11 * 3.5f;
                }
                else
                {
                  this.overlay.cellTick += 0.25f;
                  if ((double) this.rover.movement.Z == 0.0)
                    this.overlay.cellTick += 0.1f;
                }
              }
              else
              {
                this.overlay.cellTick += 0.25f;
                if ((double) this.rover.movement.Z == 0.0)
                  this.overlay.cellTick += 0.1f;
              }
              if ((double) this.overlay.cellTick > 1.0)
              {
                ++this.overlay.cellAMT;
                this.overlay.cellTick = 0.0f;
                float pitch = (float) this.overlay.cellAMT / 101.1f;
                if (this.overlay.cellAMT < 100 && (this.overlay.cellAMT % 5 == 0 || this.overlay.cellAMT > 95))
                {
                  if (this.overlay.cellAMT > 95)
                    this.sc.fuelfull.Play(this.sc.ev * 0.7f, pitch, 0.0f);
                  else
                    this.sc.fuellow.Play(this.sc.ev * 0.6f, pitch, 0.0f);
                }
              }
            }
            this.overlay.cellDec += this.rover.movement.Z / 1700f;
            if ((double) this.overlay.cellDec < 0.0)
            {
              this.overlay.cellDec = 1f;
              --this.overlay.cellAMT;
            }
            Rover.max = -5f;
            if (this.overlay.cellAMT > 10)
              Rover.max = -10f;
            if (this.overlay.cellAMT > 25)
              Rover.max = -20f;
            if (this.overlay.cellAMT > 35)
              Rover.max = -30f;
            if (this.overlay.cellAMT > 45)
              Rover.max = -45f;
            if (this.overlay.cellAMT > 85)
              Rover.max = -65f;
            if (this.rover.solar1 == 100)
              Rover.max /= 2.5f;
            if (this.rover.scoop1 == 100)
              Rover.max = Math.Max(Rover.max, -6f);
            if (this.nearfarm)
              this.rover.HandleInput(ref this.mouseState, ref this.prevMouse, ref this.keyState, ref this.prevkeyState, ref this.gamePadState, ref this.heights, ref this.tmake.normals);
            else
              this.rover.HandleInput(ref this.mouseState, ref this.prevMouse, ref this.keyState, ref this.prevkeyState, ref this.gamePadState, ref this.tmake.heightData, ref this.tmake.normals);
            float num12 = MathHelper.Clamp(Math.Abs(this.rover.speedx), 0.0f, 43f);
            float num13 = MathHelper.Clamp(Math.Abs(this.rover.speedx), 0.0f, 43f);
            if (this.roverEngineI.State == SoundState.Stopped)
            {
              this.roverEngineI.IsLooped = true;
              this.roverEngineI.Volume = num12 / 48f * this.sc.ev;
              this.roverEngineI.Play();
            }
            else
            {
              this.roverEngineI.Resume();
              this.roverEngineI.Pitch = (float) ((double) num13 / 43.0 - 1.0);
              this.roverEngineI.Volume = num12 / 48f * this.sc.ev;
            }
            if ((double) Math.Abs(this.rover.grav.X) + (double) Math.Abs(this.rover.grav.Z) > 0.0 && (double) this.rover.speedx > -1.0 && this.rover.groundflag == 1)
            {
              if (this.gravelI.State == SoundState.Stopped)
              {
                this.gravelI.IsLooped = true;
                this.gravelI.Volume = MathHelper.Clamp((float) (((double) Math.Abs(this.rover.grav.X) + (double) Math.Abs(this.rover.grav.Z)) / 5.0), 0.0f, 1f) * this.sc.ev;
                this.gravelI.Play();
              }
              else
              {
                this.gravelI.Resume();
                this.gravelI.Volume = MathHelper.Clamp((float) (((double) Math.Abs(this.rover.grav.X) + (double) Math.Abs(this.rover.grav.Z)) / 5.0), 0.0f, 1f) * this.sc.ev;
              }
            }
            else if (this.gravelI.State == SoundState.Playing)
              this.gravelI.Pause();
            if (this.rover.camSwitch == 1)
            {
              this.rover.camSwitch = 0;
              this.overlay.landerbutton4 = 0;
              this.lander.commandFlag = 2;
              this.sc.ramp.Play(this.sc.ev, 0.0f, 0.0f);
              this.vehicleindex = 2;
              this.setLens(70f);
              this.overlay.buttonindex = this.landerbuttonindex;
              if (this.roverEngineI.State == SoundState.Playing)
                this.roverEngineI.Pause();
              if (this.gravelI.State == SoundState.Playing)
                this.gravelI.Pause();
              if (this.vibrateControl > 0)
                GamePad.SetVibration(this.myplayer, 0.0f, 0.0f);
              this.sc.vehiclelerp = 0.0f;
              this.bCampos = this.aCampos;
              this.bCamtarget = this.aCamtarget;
              this.bUppy = this.aUppy;
              this.rot -= this.rover.facingDirection;
              if ((double) this.rot > 6.2831850051879883)
                this.rot -= 6.283185f;
              if ((double) this.rot < 0.0)
                this.rot += 6.283185f;
            }
            if (this.Ktoggle(this.sc.right_key) || this.gamePadState.DPad.Right == ButtonState.Pressed && this.prevstate.DPad.Right == ButtonState.Released)
            {
              ++this.roverbuttonindex;
              if (this.roverbuttonindex > 4)
                this.roverbuttonindex = 1;
              this.sc.click.Play(this.sc.ev, 0.0f, 0.0f);
              this.overlay.buttonindex = this.roverbuttonindex;
            }
            if (this.Ktoggle(this.sc.left_key) || this.gamePadState.DPad.Left == ButtonState.Pressed && this.prevstate.DPad.Left == ButtonState.Released)
            {
              --this.roverbuttonindex;
              if (this.roverbuttonindex < 1)
                this.roverbuttonindex = 4;
              this.sc.click.Play(this.sc.ev, 0.0f, 0.0f);
              this.overlay.buttonindex = this.roverbuttonindex;
            }
            bool flag4 = this.Ktoggle(this.sc.x_key) || this.Ktoggle(this.sc.one_key) || this.Ktoggle(this.sc.two_key) || this.Ktoggle(this.sc.three_key) || this.Ktoggle(this.sc.four_key);
            if (!flag2 && (this.Ktoggle(this.sc.up_key) || flag4 || this.gamePadState.Buttons.A == ButtonState.Pressed && this.prevstate.Buttons.A == ButtonState.Released))
            {
              int num14 = this.roverbuttonindex;
              if (this.sc.usingMouse)
              {
                if (this.Ktoggle(this.sc.one_key) || this.Ktoggle(this.sc.x_key))
                  num14 = 1;
                if (this.Ktoggle(this.sc.two_key))
                  num14 = 2;
                if (this.Ktoggle(this.sc.three_key))
                  num14 = 3;
                if (this.Ktoggle(this.sc.four_key))
                {
                  flag2 = true;
                  num7 = 4;
                  goto label_335;
                }
              }
              flag2 = true;
              switch (num14)
              {
                case 1:
                  if (this.rover.onramp == 0 && (double) this.rover.grav.Length() < 4.0 && (double) this.rover.velocity.Length() < 4.0)
                  {
                    this.overlay.roverbutton1 = 50;
                    this.vehicleindex = 3;
                    this.setLens(80f);
                    this.sc.vehiclelerp = 0.0f;
                    if ((double) this.sc.roverdist[this.sc.roverindex] == 0.0)
                      this.sc.vehiclelerp = 1f;
                    this.bCampos = this.aCampos;
                    this.bCamtarget = this.aCamtarget;
                    this.bUppy = this.aUppy;
                    this.rover.dashcam = 0;
                    this.rover.speedx = 0.0f;
                    this.humanonramp = 0;
                    this.camheight = 3.4f;
                    this.camhite = 80f;
                    Vector3 vector3 = Vector3.Normalize(this.aCampos - this.rover.position);
                    if ((double) this.sc.vehiclelerp == 1.0)
                      vector3 = Vector3.Transform(Vector3.Right, Matrix.CreateRotationY(this.rover.facingDirection));
                    this.aCampos = new Vector3(this.rover.position.X + vector3.X * 140f, this.rover.position.Y, this.rover.position.Z + vector3.Z * 140f);
                    this.campos = this.aCampos;
                    this.camradian = 0.0f - (float) Math.Atan2((double) this.aCampos.X - (double) this.rover.position.X, (double) this.aCampos.Z - (double) this.rover.position.Z);
                    this.camlookpos.X = (float) (-Math.Cos((double) this.camheight) * Math.Sin((double) this.camradian) * 200.0) + this.campos.X;
                    this.camlookpos.Z = (float) (-Math.Cos((double) this.camheight) * -Math.Cos((double) this.camradian) * 200.0) + this.campos.Z;
                    this.camlookpos.Y = (float) Math.Sin((double) this.camheight) * 200f + this.campos.Y;
                    this.aCamtarget = new Vector3(this.camlookpos.X, this.camlookpos.Y + this.camhite, this.camlookpos.Z);
                    goto label_336;
                  }
                  else
                  {
                    this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
                    this.vibrateControl = 20;
                    goto label_336;
                  }
                case 2:
                  this.overlay.roverbutton2 = 50;
                  if (this.rover.solar1 == 1)
                  {
                    this.rover.solarflag = 1;
                    this.sc.opensolar.Play(this.sc.ev * 0.3f, 0.1f, 0.2f);
                    goto label_336;
                  }
                  else if (this.rover.solar1 == 100)
                  {
                    this.rover.solarflag = 2;
                    this.sc.opensolar.Play(this.sc.ev * 0.3f, -0.1f, -0.2f);
                    goto label_336;
                  }
                  else
                    goto label_336;
                case 3:
                  if ((double) this.rover.movement.Z >= -10.0)
                  {
                    this.rover.scoopflag = 1;
                    Rover.max = -6f;
                    this.rover.min = 5f;
                    if (this.rover.scoop1 == 1)
                      this.sc.scoopx.Play(this.sc.ev, 0.0f, 0.0f);
                  }
                  if (this.rover.scoop1 != 1)
                  {
                    this.rover.scoopflag = 2;
                    this.rover.min = 7f;
                    if (this.rover.scoop1 == 100)
                      this.sc.scoopx.Play(this.sc.ev, -0.12f, 0.0f);
                  }
                  this.overlay.roverbutton3 = 50;
                  goto label_336;
                case 4:
                  break;
                default:
                  goto label_336;
              }
label_335:
              this.sc.horn.Play(this.sc.ev, 0.0f, 0.0f);
              this.horntimer = 20;
              ++this.horncount;
              this.overlay.roverbutton4 = 50;
            }
label_336:
            if (this.sc.equip[3] == 1)
            {
              if (this.gamePadState.Buttons.RightShoulder == ButtonState.Pressed && this.prevstate.Buttons.RightShoulder == ButtonState.Released && (double) this.rover.movement.Z >= -10.0)
              {
                if (this.rover.scoop1 == 1)
                  this.sc.scoopx.Play(this.sc.ev, 0.0f, 0.0f);
                this.rover.scoopflag = 1;
                Rover.max = -6f;
                this.rover.min = 3f;
              }
              if (this.gamePadState.Buttons.LeftShoulder == ButtonState.Pressed && this.prevstate.Buttons.LeftShoulder == ButtonState.Released)
              {
                if (this.rover.scoop1 == 100)
                  this.sc.scoopx.Play(this.sc.ev, -0.2f, 0.0f);
                this.rover.scoopflag = 2;
                this.rover.min = 7f;
              }
            }
            if (!flag2 && (this.Ktoggle(this.sc.t_key) || this.gamePadState.Buttons.Y == ButtonState.Pressed && this.prevstate.Buttons.Y == ButtonState.Released))
            {
              this.sc.horn.Play(this.sc.ev, 0.0f, 0.0f);
              this.horntimer = 20;
              ++this.horncount;
            }
          }
          GamePadThumbSticks thumbSticks;
          if (this.vehicleindex == 3)
          {
            if (this.rover.solar1 == 100 && this.myframe % 5 == 0)
            {
              if ((double) this.sunDir.Y < 0.0)
              {
                float num15 = -Vector3.Dot(Vector3.Transform(Vector3.Right, this.rover.orientation), this.sunDir);
                if ((double) num15 > 0.0)
                  this.overlay.cellTick += num15 * 0.2f;
                else
                  this.overlay.cellTick += 0.08f;
              }
              else
                this.overlay.cellTick += 0.03f;
              if ((double) this.overlay.cellTick > 1.0)
              {
                ++this.overlay.cellAMT;
                this.overlay.cellTick = 0.0f;
                if ((double) Vector3.Distance(this.campos, this.rover.position) < 1000.0)
                {
                  float pitch = (float) this.overlay.cellAMT / 101.1f;
                  if (this.overlay.cellAMT < 100 && (this.overlay.cellAMT % 5 == 0 || this.overlay.cellAMT > 95))
                  {
                    if (this.overlay.cellAMT > 95)
                      this.sc.fuelfull.Play(this.sc.ev * 0.7f, pitch, 0.0f);
                    else
                      this.sc.fuellow.Play(this.sc.ev * 0.7f, pitch, 0.0f);
                  }
                }
              }
            }
            if (Facility.inFacility && this.objIndex == 6)
              this.emo = GameplayScreen.act.facilityfound;
            if (Facility.createWorkerLoc != Vector4.Zero && (this.sc.astronaut.man.dupe.Count < 10 || this.objIndex == 7))
            {
              this.sc.enginex.Play(this.sc.ev, 0.6f, 0.0f);
              this.sc.astronaut.dropFacilityAstronaut(this.myframe, new Vector2(Facility.createWorkerLoc.X, Facility.createWorkerLoc.Z), astroDupe.emotion.underground, 4.71f + Facility.createWorkerLoc.W);
              if (this.objIndex == 7)
                this.emo = GameplayScreen.act.cloned;
              Facility.createWorkerLoc = Vector4.Zero;
            }
            if ((this.gamePadState.Buttons.A == ButtonState.Pressed || this.sc.usingMouse && this.KMdown(this.sc.space_key)) && Facility.outsideCastle && !Facility.inFacility)
            {
              if (this.rejump && this.jumping && (double) this.doubleJump < 2.0)
              {
                ++this.doubleJump;
                this.jumpCount = 30;
                this.sc.jump.Play(this.sc.ev, (float) (0.10000000149011612 + (double) this.doubleJump / 5.0), 0.0f);
                this.rejump = false;
                if ((double) this.fallGrav < 0.0)
                {
                  if ((double) this.fallGrav > (double) this.gravLimdown)
                    this.fallGrav = 0.0f;
                  else
                    this.fallGrav /= 2f;
                }
              }
              if (this.jumpCount > 0 && this.jumping)
              {
                this.fallGrav += 0.15f;
                if ((double) this.fallGrav > (double) this.gravLim)
                  this.fallGrav = this.gravLim;
              }
            }
            if ((!this.sc.usingMouse && this.prevstate.Buttons.A == ButtonState.Released || this.sc.usingMouse && this.method_0(this.sc.space_key)) && Facility.outsideCastle && !Facility.inFacility && this.jumping && !this.rejump)
              this.rejump = true;
            bool flag5;
            if (this.sc.usingMouse && this.Ktoggle(this.sc.space_key) || !this.atRover && !flag2 && this.gamePadState.Buttons.A == ButtonState.Pressed && this.prevstate.Buttons.A == ButtonState.Released)
            {
              flag5 = true;
              if (!this.jumpCalled && !this.jumping && !Facility.inFacility)
              {
                this.jumpCalled = true;
                this.jumpCount = 30;
                this.sc.jump.Play(this.sc.ev, 0.0f, 0.0f);
                this.doubleJump = 0.0f;
                this.rejump = false;
                thumbSticks = this.gamePadState.ThumbSticks;
                Vector2 left = thumbSticks.Left;
                if (this.sc.usingMouse)
                {
                  if (this.KMdown(this.sc.a_key))
                    --left.X;
                  if (this.KMdown(this.sc.d_key))
                    ++left.X;
                  if (this.KMdown(this.sc.w_key))
                    ++left.Y;
                  if (this.KMdown(this.sc.s_key))
                    --left.Y;
                }
                float num16 = 1.5f;
                float num17 = 0.3f;
                this.fallLim = 5f;
                if (this.Ktoggle(this.sc.leftshift_key) || this.gamePadState.Buttons.LeftStick == ButtonState.Pressed)
                {
                  num17 = 0.9f;
                  this.fallLim = 8f;
                }
                if (Facility.outsideCastle)
                {
                  this.walkspeed = num16 + num17 * 5f;
                  this.vec = Vector3.Transform(new Vector3((float) (-(double) left.X / 1.2999999523162842), 0.0f, left.Y), Matrix.CreateRotationY(-3.14f - this.camradian)) * this.walkspeed;
                  this.vec /= this.slopereducer;
                  this.fallLim /= this.slopereducer;
                  this.fallVec = this.vec;
                  this.gravLim = 5f;
                  this.fallAcc = -0.06f;
                  this.fallGrav = 1f;
                }
                else
                {
                  this.fallLim = 2f;
                  this.walkspeed = num16 + 0.33f;
                  this.vec = Vector3.Transform(new Vector3((float) (-(double) left.X / 1.2999999523162842), 0.0f, left.Y), Matrix.CreateRotationY(-3.14f - this.camradian)) * this.walkspeed;
                  this.fallVec = this.vec;
                  this.fallAcc = -0.05f;
                  this.fallGrav = 1f;
                }
              }
            }
            if (this.humanonramp == 3 && !this.lander.radioFixed && (this.Ktoggle(this.sc.x_key) || this.gamePadState.Buttons.X == ButtonState.Pressed && this.prevstate.Buttons.X == ButtonState.Released))
            {
              this.sc.radio1.Play(this.sc.ev, 0.0f, 0.0f);
              this.lander.radioFixed = true;
            }
            if (this.atRover && (this.Ktoggle(this.sc.x_key) || this.gamePadState.Buttons.A == ButtonState.Pressed && this.prevstate.Buttons.A == ButtonState.Released))
            {
              flag5 = true;
              this.vehicleindex = 1;
              this.setLens(70f);
              this.sc.vehiclelerp = 1f;
              if ((double) this.sc.roverdist[this.sc.roverindex] == 0.0)
                this.sc.vehiclelerp = 1f;
              this.bCampos = this.aCampos;
              this.bCamtarget = this.aCamtarget;
              this.bUppy = this.aUppy;
              if (this.cameditMess1 && this.sc.usingMouse)
              {
                this.ScreenManager.AddScreen((GameScreen) new messagebox("Press F1 to Edit Cameras", 0, 0), new PlayerIndex?());
                this.cameditMess1 = false;
              }
              this.rot = this.camradian + 3.14f;
              if ((double) this.rot > 6.2831850051879883)
                this.rot -= 6.283185f;
              if ((double) this.rot < 0.0)
                this.rot += 6.283185f;
            }
            if ((this.Ktoggle(this.sc.t_key) || this.gamePadState.Buttons.Y == ButtonState.Pressed && this.prevstate.Buttons.Y == ButtonState.Released) && !this.nearAstro && (double) this.rover.velocity.Length() < 3.0 && this.rover.onramp == 0)
              this.sc.astronaut.everyoneOut = true;
            if (this.nearAstro && (this.Ktoggle(this.sc.x_key) || this.gamePadState.Buttons.X == ButtonState.Pressed && this.prevstate.Buttons.X == ButtonState.Released))
            {
              this.sc.astronaut.saluteRequest = true;
              this.sc.astronaut.facingRover = this.rover.facingDirection;
            }
            if (this.nearFlower && (this.Ktoggle(this.sc.x_key) || this.gamePadState.Buttons.X == ButtonState.Pressed && this.prevstate.Buttons.X == ButtonState.Released) && this.rock.chosen != -1 && this.rock.flowerInst[this.rock.chosen].stateFlag == 15)
            {
              this.sc.grow.Play(this.sc.ev, 0.0f, (float) this.random.Next(-40, 40) / 100f);
              this.rock.flowerInst[this.rock.chosen].stateFlag = 5;
            }
            if (Facility.inFacility)
              this.facility.HandleInput(input, this.gamePadState, this.prevstate, this.aCampos, this.aCamtarget);
          }
          if (this.Ktoggle(this.sc.enter_key) || this.gamePadState.Buttons.B == ButtonState.Pressed && this.prevstate.Buttons.B == ButtonState.Released)
          {
            this.typewriterblank = 500f;
            this.textflag = 0;
            this.typewriterwait = 480f;
            this.typeposition = 0.0f;
            this.typevertical = (float) this.random.Next(100, 150);
            this.typewriterdelay = this.random.Next(2, 7);
          }
          if (this.lander.door1 == 1 && (double) this.vehicleDistance < 2000.0 && this.rover.onramp == 0 && this.vehicleindex == 1)
            this.openHatch(true);
          if (this.lander.rampSwitch == 1)
          {
            this.lander.rampSwitch = 0;
            Array.Copy((Array) this.lander.region1, (Array) this.rover.region1, this.rover.region1.Length);
            Array.Copy((Array) this.lander.region2, (Array) this.rover.region3, this.rover.region3.Length);
            this.rover.region2[0] = this.rover.region1[9];
            this.rover.region2[1] = this.rover.region1[10];
            this.rover.region2[2] = this.rover.region1[11];
            this.rover.region2[3] = this.rover.region1[6];
            this.rover.region2[4] = this.rover.region1[7];
            this.rover.region2[5] = this.rover.region1[8];
            this.rover.region2[6] = this.rover.region3[3];
            this.rover.region2[7] = this.rover.region3[4];
            this.rover.region2[8] = this.rover.region3[5];
            this.rover.region2[9] = this.rover.region3[0];
            this.rover.region2[10] = this.rover.region3[1];
            this.rover.region2[11] = this.rover.region3[2];
            Vector3 vector3 = Vector3.Normalize(Vector3.Lerp(new Vector3(this.rover.region1[12], this.rover.region1[13], this.rover.region1[14]), new Vector3(this.rover.region3[12], this.rover.region3[13], this.rover.region3[14]), 0.5f));
            this.rover.region2[12] = vector3.X;
            this.rover.region2[13] = vector3.Y;
            this.rover.region2[14] = vector3.Z;
          }
          if (this.lander.shockhit > 0)
          {
            if (this.lander.shockhit > 20)
            {
              this.sc.groundhit.Play(this.sc.ev, (float) (0.30000001192092896 - (double) this.random.Next(1, 1000) / 1000.0), 0.0f);
              this.vibrateControl = this.lander.shockhit;
            }
            this.lander.shockhit = 0;
          }
          if (this.rover.shockhit > 0)
          {
            this.vibrateControl = this.rover.shockhit / 3;
            if (this.rover.shockhit > 15)
              this.sc.shocks.Play(0.7f * this.sc.ev, (float) this.random.Next(-90, 90) / 100f, 0.0f);
            this.rover.shockhit = 0;
          }
          if (this.vibrateControl > 0)
          {
            --this.vibrateControl;
            if (this.sc.vibroSetting == 1 && this.vibrateControl > 2)
              GamePad.SetVibration(this.myplayer, 0.5f, 1f);
            if (this.vibrateControl < 2)
              GamePad.SetVibration(this.myplayer, 0.0f, 0.0f);
          }
          if (this.myframe % 25 == 0 || this.jumping)
          {
            if (this.dropEngineI.State == SoundState.Stopped)
            {
              this.dropEngineI.IsLooped = true;
              this.dropEngineI.Volume = this.sc.ev * (1f - MathHelper.Clamp((float) (((double) this.dropshipDistance - 3000.0) / 12000.0), 0.0f, 1f));
              this.dropEngineI.Play();
            }
            else
            {
              float num18 = 1f - MathHelper.Clamp((float) (((double) this.dropshipDistance - 3000.0) / 12000.0), 0.0f, 1f);
              this.dropEngineI.Resume();
              this.dropEngineI.Volume = num18 * this.sc.ev;
            }
            if (this.breathing.State == SoundState.Stopped)
            {
              this.breathing.IsLooped = true;
              if (this.vehicleindex == 3)
              {
                if (!this.jumping)
                {
                  this.breathvol += 0.1f;
                  if ((double) this.breathvol > 0.40000000596046448)
                    this.breathvol = 0.4f;
                }
                else
                {
                  this.breathvol -= 0.01f;
                  if ((double) this.breathvol < 0.05000000074505806)
                    this.breathvol = 0.05f;
                }
                this.breathing.Volume = this.breathvol * this.sc.ev;
              }
              else
                this.breathing.Volume = 0.0f;
              this.breathing.Play();
            }
            else
            {
              this.breathing.Resume();
              if (this.vehicleindex == 3)
              {
                if (!this.jumping)
                {
                  this.breathvol += 0.1f;
                  if ((double) this.breathvol > 0.5)
                    this.breathvol = 0.5f;
                }
                else
                {
                  this.breathvol -= 0.01f;
                  if ((double) this.breathvol < 0.05000000074505806)
                    this.breathvol = 0.05f;
                }
                this.breathing.Volume = this.breathvol * this.sc.ev;
              }
              else
                this.breathing.Volume = 0.0f;
            }
          }
          if (this.vehicleindex != 3 && (this.KMtoggle(this.sc.mmb_key) || this.Ktoggle(this.sc.tab_key) || this.gamePadState.Buttons.RightStick == ButtonState.Pressed && this.prevstate.Buttons.RightStick == ButtonState.Released))
          {
            if (this.vehicleindex == 1)
            {
              ++this.sc.roverindex;
              if (this.sc.roverindex > 2)
                this.sc.roverindex = 0;
              this.yy = this.sc.roverheight[this.sc.roverindex];
              this.rot = this.sc.roverradian[this.sc.roverindex];
              this.setLens(70f);
              if (this.memoTimer <= 0 || this.memoIcon == 7)
              {
                int num19 = this.sc.roverindex + 1;
                this.memoTimer = 150;
                this.memoIcon = 7;
                GameplayScreen.memo.Length = 0;
                GameplayScreen.memo.Append("Camera " + num19.ToString());
              }
            }
            else if (this.vehicleindex == 2)
            {
              ++this.sc.landerindex;
              if (this.sc.landerindex > 2)
                this.sc.landerindex = 0;
              this.yy = this.sc.landerheight[this.sc.landerindex];
              this.rot = this.sc.landerradian[this.sc.landerindex];
              if (this.lander.impact == 1)
              {
                this.sc.vehiclelerp = 0.0f;
                this.bCampos = this.aCampos;
                this.bCamtarget = this.aCamtarget;
                this.bUppy = this.aUppy;
              }
              this.setLens(70f);
              if (this.memoTimer <= 0 || this.memoIcon == 7)
              {
                int num20 = this.sc.landerindex + 1;
                this.memoTimer = 150;
                this.memoIcon = 7;
                GameplayScreen.memo.Length = 0;
                GameplayScreen.memo.Append("Camera " + num20.ToString());
              }
            }
          }
          float num21 = 0.0f;
          if (this.sc.usingMouse)
          {
            if (this.vehicleindex == 1)
            {
              if (this.sc.roverrotlock == 1 && this.Kdown(this.sc.u_key))
              {
                num21 = (float) (-(double) this.mouseX * (0.00044999999227002263 * (double) this.sc.space_rsentivityX)) * (float) this.sc.space_rinvertX;
                this.sc.roverradian[this.sc.roverindex] = this.rot;
              }
              if (this.sc.roverrotlock == 0)
              {
                num21 = (float) (-(double) this.mouseX * (0.00044999999227002263 * (double) this.sc.space_rsentivityX)) * (float) this.sc.space_rinvertX;
                this.sc.roverradian[this.sc.roverindex] = this.rot;
              }
            }
            if (this.vehicleindex == 2)
            {
              if (this.sc.landerrotlock == 1 && this.Kdown(this.sc.u_key))
              {
                num21 = (float) (-(double) this.mouseX * (0.00044999999227002263 * (double) this.sc.space_sentivityX)) * (float) this.sc.space_invertX;
                this.sc.landerradian[0] = this.rot;
                this.sc.landerradian[1] = this.rot;
                this.sc.landerradian[2] = this.rot;
              }
              if (this.sc.landerrotlock == 0)
              {
                num21 = (float) (-(double) this.mouseX * (0.00044999999227002263 * (double) this.sc.space_sentivityX)) * (float) this.sc.space_invertX;
                this.sc.landerradian[0] = this.rot;
                this.sc.landerradian[1] = this.rot;
                this.sc.landerradian[2] = this.rot;
              }
            }
          }
          else
          {
            if (this.vehicleindex == 1)
            {
              if (this.sc.roverrotlock == 0)
              {
                thumbSticks = this.gamePadState.ThumbSticks;
                num21 = (float) (-(double) thumbSticks.Right.X * (0.10000000149011612 * (double) this.sc.space_rsentivityX)) * (float) this.sc.space_rinvertX;
              }
              this.sc.roverradian[this.sc.roverindex] = this.rot;
            }
            if (this.vehicleindex == 2)
            {
              thumbSticks = this.gamePadState.ThumbSticks;
              num21 = (float) (-(double) thumbSticks.Right.X * (0.10000000149011612 * (double) this.sc.space_sentivityX)) * (float) this.sc.space_invertX;
              this.sc.landerradian[0] = this.rot;
              this.sc.landerradian[1] = this.rot;
              this.sc.landerradian[2] = this.rot;
            }
          }
          this.rot += num21;
          if ((double) this.rot > 6.2831850051879883)
            this.rot = 0.0f;
          if ((double) this.rot < 0.0)
            this.rot = 6.283185f;
          this.aUppy = Vector3.Up;
          this.lander.camrot = this.rot;
          if (this.vehicleindex == 1)
          {
            if (this.objIndex == 0)
              this.emo = GameplayScreen.act.rovered;
            this.sc.vehicleindex = this.vehicleindex;
            this.overlay.damaged1 = false;
            if ((double) this.sc.roverdist[this.sc.roverindex] > 110.0)
            {
              if (this.sc.roverrotlock > 0)
              {
                this.myrotter = this.rot - this.rover.facingDirection;
                if ((double) this.myrotter > 6.2831850051879883)
                  this.myrotter -= 6.283185f;
                if ((double) this.myrotter < 0.0)
                  this.myrotter += 6.283185f;
              }
              else
                this.myrotter = this.rot;
              this.xx = (float) Math.Sin((double) this.myrotter) * this.sc.roverdist[this.sc.roverindex];
              this.zz = (float) -Math.Cos((double) this.myrotter) * this.sc.roverdist[this.sc.roverindex];
              this.yy = !this.sc.usingMouse ? MathHelper.Clamp(this.yy, -300f, this.sc.roverdist[this.sc.roverindex] * 2f) : MathHelper.Clamp(this.yy, -300f, this.sc.roverdist[this.sc.roverindex] * 2f);
              this.aCampos.X = this.rover.position.X + this.xx;
              this.aCampos.Y = this.rover.position.Y + this.yy;
              this.aCampos.Z = this.rover.position.Z + this.zz;
              float height;
              this.GetHeightOnly(ref this.tmake.heightData, this.aCampos, out height);
              if ((double) this.aCampos.Y < (double) height + (double) this.roverY)
              {
                this.aCampos.Y = height + (float) this.roverY;
                this.yy = this.aCampos.Y - this.rover.position.Y;
              }
              if (this.sc.usingMouse)
              {
                if (this.sc.roverhitelock == 1 && this.Kdown(this.sc.u_key))
                {
                  this.yy += (float) (-(double) this.mouseY * 0.20000000298023224) * this.sc.space_rsentivityY * (float) this.sc.space_rinvertY;
                  this.sc.roverheight[this.sc.roverindex] = this.yy;
                }
                if (this.sc.roverhitelock == 0)
                {
                  this.yy += (float) (-(double) this.mouseY * 0.20000000298023224) * this.sc.space_rsentivityY * (float) this.sc.space_rinvertY;
                  this.sc.roverheight[this.sc.roverindex] = this.yy;
                }
              }
              else
              {
                if (this.sc.roverhitelock == 0)
                {
                  GameplayScreen gameplayScreen = this;
                  double yy = (double) gameplayScreen.yy;
                  thumbSticks = this.gamePadState.ThumbSticks;
                  double num22 = (double) thumbSticks.Right.Y * (20.0 * (double) this.sc.space_rsentivityY) * (double) this.sc.space_rinvertY;
                  gameplayScreen.yy = (float) (yy + num22);
                }
                this.sc.roverheight[this.sc.roverindex] = this.yy;
              }
              if ((double) this.yy != (double) this.sc.roverheight[this.sc.roverindex])
              {
                if ((double) this.yy > (double) this.sc.roverheight[this.sc.roverindex])
                  this.yy -= 3f;
                if ((double) this.yy < (double) this.sc.roverheight[this.sc.roverindex])
                  this.yy += 3f;
                if ((double) Math.Abs(this.sc.roverheight[this.sc.roverindex] - this.yy) <= 4.0)
                  this.yy = this.sc.roverheight[this.sc.roverindex];
              }
              this.aCamtarget.X = this.rover.position.X;
              this.aCamtarget.Y = this.rover.position.Y + 30f;
              this.aCamtarget.Z = this.rover.position.Z;
              this.rover.dashcam = 0;
              this.setLens(70f);
            }
            else
            {
              this.myrotter = 3.1415925f - this.rover.facingDirection;
              if ((double) this.myrotter < 0.0)
                this.myrotter += 6.283185f;
              if ((double) this.sc.vehiclelerp >= 1.0)
                this.rover.dashcam = 1;
              this.setLens(this.lens);
              this.aCampos = this.rover.position + Vector3.Transform(new Vector3(0.0f, (float) (3.0 * (double) this.rover.scoopx + 64.0), -35f), this.rover.orientation);
              this.aCamtarget = this.rover.position + Vector3.Transform(new Vector3(0.0f, 0.0f, (float) (-((double) this.rover.scoopx * 600.0) - 350.0)), this.rover.orientation);
              this.aUppy = Vector3.Normalize(Vector3.Transform(new Vector3(0.0f, 10000f, 0.0f), this.rover.orientation));
            }
          }
          if (this.vehicleindex == 2)
          {
            if (this.objIndex == 1)
              this.emo = GameplayScreen.act.landered;
            this.sc.vehicleindex = this.vehicleindex;
            this.xx = (float) Math.Sin((double) this.rot) * this.sc.landerdist[this.sc.landerindex];
            this.zz = (float) -Math.Cos((double) this.rot) * this.sc.landerdist[this.sc.landerindex];
            this.yy = !this.sc.usingMouse ? MathHelper.Clamp(this.yy, -300f, this.sc.landerdist[this.sc.landerindex]) : MathHelper.Clamp(this.yy, -800f, this.sc.landerheight[this.sc.landerindex]);
            this.aCampos = this.lander.position + new Vector3(this.xx, this.yy, this.zz);
            float height;
            this.GetHeightOnly(ref this.tmake.heightData, this.aCampos, out height);
            if ((double) this.aCampos.Y < (double) height + (double) this.landerY)
            {
              this.aCampos.Y = height + (float) this.landerY;
              this.yy = this.aCampos.Y - this.lander.position.Y;
            }
            float num23 = 0.0f;
            if (this.sc.usingMouse)
            {
              if (this.sc.landerhitelock == 0)
              {
                this.yy += (float) (-(double) this.mouseY * 0.34999999403953552) * this.sc.space_sentivityY * (float) this.sc.space_invertY;
                this.sc.landerheight[this.sc.landerindex] = this.yy;
              }
              if (this.sc.landerhitelock == 1 && this.Kdown(this.sc.u_key))
              {
                this.yy += (float) (-(double) this.mouseY * 0.34999999403953552) * this.sc.space_sentivityY * (float) this.sc.space_invertY;
                this.sc.landerheight[this.sc.landerindex] = this.yy;
              }
              if (this.Ktoggle(this.sc.w_key))
                num23 = 1f;
            }
            else
            {
              if (this.sc.landerhitelock == 0)
              {
                GameplayScreen gameplayScreen = this;
                double yy = (double) gameplayScreen.yy;
                thumbSticks = this.gamePadState.ThumbSticks;
                double num24 = (double) thumbSticks.Right.Y * (45.0 * (double) this.sc.space_sentivityY) * (double) this.sc.space_invertY;
                gameplayScreen.yy = (float) (yy + num24);
              }
              num23 = this.lander.rightTrigger;
            }
            if ((double) this.yy != (double) this.sc.landerheight[this.sc.landerindex])
            {
              if ((double) this.yy > (double) this.sc.landerheight[this.sc.landerindex])
                this.yy -= 5f;
              if ((double) this.yy < (double) this.sc.landerheight[this.sc.landerindex])
                this.yy += 5f;
              if ((double) Math.Abs(this.sc.landerheight[this.sc.landerindex] - this.yy) <= 6.0)
                this.yy = this.sc.landerheight[this.sc.landerindex];
            }
            this.aCamtarget.X = this.lander.position.X;
            this.aCamtarget.Y = this.lander.position.Y;
            this.aCamtarget.Z = this.lander.position.Z;
            if ((double) this.lander.lander2ground >= 100.0 && (this.Ktoggle(this.sc.w_key) || (double) this.lander.rightTrigger > 0.0))
            {
              float num25 = (1f - MathHelper.Clamp((float) (((double) this.lander.lander2ground - 100.0) / 1800.0), 0.0f, 1f)) * num23;
              this.aCamtarget.X += (float) ((double) num25 * (double) this.random.Next(-850, 850) / 90.0);
              this.aCamtarget.Y += (float) ((double) num25 * (double) this.random.Next(-850, 850) / 90.0);
              this.aCamtarget.Z += (float) ((double) num25 * (double) this.random.Next(-850, 850) / 90.0);
            }
          }
          if (this.vehicleindex == 3)
          {
            this.sc.vehicleindex = this.vehicleindex;
            Vector2 zero = Vector2.Zero;
            this.vec = Vector3.Zero;
            this.facility.jumping = this.jumping;
            if ((double) this.sc.vehiclelerp >= 1.0)
            {
              float num26;
              float num27;
              if ((double) this.mouseX == 0.0 && (double) this.mouseY == 0.0)
              {
                thumbSticks = this.gamePadState.ThumbSticks;
                num26 = thumbSticks.Right.X * (0.0286f * this.sc.space_wsentivityX) * (float) this.sc.space_winvertX;
                thumbSticks = this.gamePadState.ThumbSticks;
                num27 = thumbSticks.Right.Y * (0.017f * this.sc.space_wsentivityY) * (float) this.sc.space_winvertY;
              }
              else
              {
                num26 = this.mouseX * (0.0012f * this.sc.space_wsentivityX) * (float) this.sc.space_winvertX;
                num27 = (float) (-(double) this.mouseY * (0.0012000000569969416 * (double) this.sc.space_wsentivityY)) * (float) this.sc.space_winvertY;
              }
              this.camradian += num26;
              this.camheight -= num27;
              this.camheight = MathHelper.Clamp(this.camheight, 1.7f, 4.5f);
              thumbSticks = this.gamePadState.ThumbSticks;
              Vector2 left = thumbSticks.Left;
              if (this.sc.usingMouse)
              {
                if (this.KMdown(this.sc.a_key))
                  --left.X;
                if (this.KMdown(this.sc.d_key))
                  ++left.X;
                if (this.KMdown(this.sc.w_key))
                  ++left.Y;
                if (this.KMdown(this.sc.s_key))
                  --left.Y;
              }
              float num28 = 1.5f;
              float num29 = 0.3f;
              if (this.KMdown(this.sc.leftshift_key) || this.gamePadState.Buttons.LeftStick == ButtonState.Pressed)
                num29 = 0.9f;
              this.walkspeed = num28 + num29 * 5f;
              this.vec = Vector3.Transform(new Vector3((float) (-(double) left.X / 1.2999999523162842), 0.0f, left.Y), Matrix.CreateRotationY(-3.14f - this.camradian)) * this.walkspeed;
              Vector3 vector3_1 = Vector3.Normalize(this.vec);
              if ((double) this.vec.Length() > (double) this.walkspeed)
                this.vec = vector3_1 * this.walkspeed;
              if (this.jumping)
              {
                Vector3 vector3_2 = Vector3.Transform(new Vector3((float) (-(double) left.X / 1.2000000476837158), 0.0f, left.Y), Matrix.CreateRotationY(-3.14f - this.camradian)) * 1f * num29;
                if ((double) (this.fallVec + vector3_2).Length() < (double) this.fallLim)
                  this.fallVec += vector3_2;
                if ((double) (this.fallVec + vector3_2).Length() >= (double) this.fallLim && (double) (this.fallVec + vector3_2).Length() < (double) this.fallVec.Length())
                  this.fallVec += vector3_2;
                this.vec = this.fallVec;
              }
              this.vec += this.hitVec;
              this.hitVec *= 0.9f;
            }
            float num30 = 13f;
            float y = this.campos.Y;
            float num31 = 1.5f;
            if (this.nearfarm)
              this.GetHeightFarm2(this.campos + this.vec, out this.groundHeight);
            else
              this.GetHeightOnly(ref this.tmake.heightData, this.campos + this.vec, out this.groundHeight);
            float groundHeight = this.groundHeight;
            this.slopereducer = 1f;
            bool flag6;
            if ((flag6 = (double) this.campos.X < (double) this.facility.facilityLocate.X + 865.0 && (double) this.campos.X > (double) this.facility.facilityLocate.X - 865.0 && (double) this.campos.Z < (double) this.facility.facilityLocate.Y + 200.0 && (double) this.campos.Z > (double) this.facility.facilityLocate.Y - 945.0) && Facility.outsideCastle)
            {
              float num32 = 2f;
              bool flag7 = false;
              float height;
              this.facility.GetHeightEntry(this.campos, out height, groundHeight);
              if (!this.facility.steep)
                flag7 = true;
              this.facility.GetHeightEntry(this.campos + this.vec, out this.groundHeight, groundHeight);
              if (!this.facility.steep)
                flag7 = true;
              if ((double) this.vec.Length() > 0.0)
              {
                if ((double) Math.Abs((height - this.groundHeight) / this.vec.Length()) >= (double) num32 && !flag7 && !this.jumping)
                {
                  Vector3 vector3 = new Vector3(0.0f, 0.0f, this.vec.Z);
                  this.facility.GetHeightEntry(this.campos + vector3, out this.groundHeight, groundHeight);
                  if ((double) Math.Abs((height - this.groundHeight) / this.vec.Length()) < (double) num32)
                  {
                    this.campos.X += vector3.X;
                    this.campos.Y += this.vec.Y;
                    this.campos.Z += vector3.Z;
                  }
                  else
                  {
                    vector3 = new Vector3(this.vec.X, 0.0f, 0.0f);
                    this.facility.GetHeightEntry(this.campos + vector3, out this.groundHeight, groundHeight);
                    if ((double) Math.Abs((height - this.groundHeight) / this.vec.Length()) < (double) num32)
                    {
                      this.campos.X += vector3.X;
                      this.campos.Y += this.vec.Y;
                      this.campos.Z += vector3.Z;
                    }
                    else
                      this.groundHeight = height;
                  }
                }
                else
                  this.campos += this.vec;
              }
            }
            else if (!Facility.outsideCastle)
            {
              float num33 = 5.5f;
              float height;
              this.facility.GetHeight(this.campos, out height, groundHeight);
              this.facility.GetHeight(this.campos + this.vec, out this.groundHeight, groundHeight);
              if ((double) this.vec.Length() > 0.0)
              {
                if ((double) Math.Abs((height - this.groundHeight) / this.vec.Length()) < (double) num33)
                {
                  this.campos += this.vec;
                }
                else
                {
                  Vector3 vector3 = new Vector3(0.0f, 0.0f, this.vec.Z);
                  this.facility.GetHeight(this.campos + vector3, out this.groundHeight, groundHeight);
                  if ((double) Math.Abs((height - this.groundHeight) / this.vec.Length()) < (double) num33)
                  {
                    this.campos.X += vector3.X;
                    this.campos.Y += this.vec.Y;
                    this.campos.Z += vector3.Z;
                  }
                  else
                  {
                    vector3 = new Vector3(this.vec.X, 0.0f, 0.0f);
                    this.facility.GetHeight(this.campos + vector3, out this.groundHeight, groundHeight);
                    if ((double) Math.Abs((height - this.groundHeight) / this.vec.Length()) < (double) num33)
                    {
                      this.campos.X += vector3.X;
                      this.campos.Y += this.vec.Y;
                      this.campos.Z += vector3.Z;
                    }
                    else
                      this.groundHeight = height;
                  }
                }
              }
            }
            if (Facility.outsideCastle && !flag6)
            {
              num31 = -0.1f;
              float height;
              if (this.nearfarm)
              {
                this.GetHeightFarm2(this.campos, out height);
                this.GetHeightFarm2(this.campos + this.vec, out this.groundHeight);
                num31 = -0.1f;
              }
              else
              {
                this.GetHeightOnly(ref this.tmake.heightData, this.campos, out height);
                this.GetHeightOnly(ref this.tmake.heightData, this.campos + this.vec, out this.groundHeight);
              }
              this.dumpos = this.campos;
              if ((double) this.vec.Length() > 0.0)
              {
                float num34 = (height - this.groundHeight) / this.vec.Length();
                if ((double) num34 > 0.0)
                  this.campos += this.vec;
                else if (this.nearfarm)
                {
                  if ((double) num34 >= 0.0)
                  {
                    this.campos += this.vec;
                  }
                  else
                  {
                    this.vec.Y = 0.0f;
                    this.vec.X = 0.0f;
                    this.vec.Z = 0.0f;
                  }
                  this.GetHeightFarm2(this.campos, out this.groundHeight);
                }
                else
                {
                  this.slopereducer = MathHelper.Clamp(Math.Abs((float) (((double) num34 + 0.5) * ((double) num34 + 0.5))), 1f, 500f);
                  this.vec.X /= this.slopereducer;
                  this.vec.Z /= this.slopereducer;
                  this.campos += this.vec;
                  this.GetHeightOnly(ref this.tmake.heightData, this.campos, out this.groundHeight);
                }
              }
              BoundingBox boundingBox = new BoundingBox();
              Vector3 point = Vector3.Transform(this.campos - this.rover.position, Matrix.Invert(this.rover.orientation));
              boundingBox.Min = new Vector3(-80f, -100f, -100f);
              boundingBox.Max = new Vector3(80f, 200f, 140f);
              if (boundingBox.Contains(point) == ContainmentType.Contains)
                this.campos += Vector3.Normalize(this.aCampos - this.rover.position) * 4f;
              if (this.lander.door1 == 10)
              {
                if (this.nearfarm)
                  this.rover.hitramp2(this.heights, this.tmake.normals, ref this.humanonramp, ref this.dumpos, ref this.campos, ref this.groundy, ref this.normalxxx, ref this.vec);
                else
                  this.rover.hitramp2(this.tmake.heightData, this.tmake.normals, ref this.humanonramp, ref this.dumpos, ref this.campos, ref this.groundy, ref this.normalxxx, ref this.vec);
                this.groundHeight = this.groundy.Y;
              }
            }
            float num35 = Vector3.Distance(this.oldcampos, this.campos);
            if (!this.jumping)
              this.dist += num35;
            if ((double) this.dist > 500000.0)
            {
              this.dist = 0.0f;
              this.olddist = 0.0f;
            }
            this.bobber = (float) ((Math.Sin((double) this.dist / (double) num30) + 1.0) * 2.0);
            float num36 = Math.Abs(this.dist - this.olddist);
            if ((double) num36 > 30.0)
              this.olddist = this.dist;
            this.camhite = 70f;
            this.campos.Y = this.groundHeight;
            this.updatePrints();
            if ((double) num36 > 30.0 && !this.jumping && !Facility.inFacility)
            {
              ++this.print;
              if (this.print > 1)
                this.print = 0;
              Vector3 position = this.campos + Vector3.Transform(new Vector3(-7f, 0.0f, 0.0f), Matrix.CreateRotationY(-this.camradian));
              if (this.print == 1)
                position = this.campos + Vector3.Transform(new Vector3(7f, 0.0f, 0.0f), Matrix.CreateRotationY(-this.camradian));
              if (this.print == 1)
                this.sc.step.Play(this.sc.ev * 0.7f, (float) this.random.Next(-10, 10) / 100f, 0.0f);
              float height;
              Vector3 normal;
              this.GetHeightAndNormal(ref this.tmake.heightData, ref this.tmake.normals, new Vector3(position.X, 0.0f, position.Z), out height, out normal);
              position.Y = height + 2f;
              Matrix rotationY = Matrix.CreateRotationY(-this.camradian) with
              {
                Up = normal
              };
              rotationY.Right = Vector3.Cross(rotationY.Forward, rotationY.Up);
              rotationY.Right = Vector3.Normalize(rotationY.Right);
              rotationY.Forward = Vector3.Cross(rotationY.Up, rotationY.Right);
              rotationY.Forward = Vector3.Normalize(rotationY.Forward);
              this.addPrint(Matrix.CreateScale(0.8f) * rotationY * Matrix.CreateTranslation(position));
            }
            if (this.jumping)
              this.campos.Y = MathHelper.Max(this.groundHeight, y + this.fallGrav);
            if ((double) this.campos.Y <= (double) this.groundHeight && !this.jumpCalled && this.jumpCount <= 0)
            {
              if (this.jumping)
                this.sc.land.Play(this.sc.ev, 0.0f, 0.0f);
              if ((double) this.fallGrav < -12.0)
              {
                this.sc.bone.Play(this.sc.ev, 0.0f, 0.0f);
                this.overlay.damaged1 = true;
                this.vibrateControl = 60;
                this.iscamShake = true;
                this.camShakeTimer = 130;
              }
              this.jumpCalled = false;
              this.jumping = false;
              this.jumpCount = 0;
              this.fallVec = Vector3.Zero;
              this.fallGrav = 0.0f;
              this.fallAcc = 0.0f;
            }
            else
            {
              --this.jumpCount;
              this.jumping = true;
              this.jumpCalled = false;
              if ((double) this.hitVec.Length() > 0.0)
              {
                this.fallGrav = MathHelper.Min(this.hitVec.Y / 10f, 6f);
                this.hitVec.Y = 0.0f;
                this.fallVec = this.hitVec / 5f;
                this.hitVec = Vector3.Zero;
              }
              if ((double) this.fallGrav >= (double) this.gravLimdown)
                this.fallGrav += this.fallAcc;
              if ((double) this.fallGrav < (double) this.gravLimdown)
              {
                if ((double) this.fallAcc != -0.15000000596046448)
                  this.sc.alarm1.Play(this.sc.ev, 0.0f, 0.0f);
                this.fallAcc = -0.15f;
                this.fallGrav += this.fallAcc;
              }
            }
            this.camlookpos.X = (float) (-Math.Cos((double) this.camheight) * Math.Sin((double) this.camradian) * 200.0) + this.campos.X;
            this.camlookpos.Z = (float) (-Math.Cos((double) this.camheight) * -Math.Cos((double) this.camradian) * 200.0) + this.campos.Z;
            this.camlookpos.Y = (float) Math.Sin((double) this.camheight) * 200f + this.campos.Y;
            this.oldcampos = this.campos;
            if (this.iscamShake)
            {
              --this.camShakeTimer;
              this.camShake = (float) this.camShakeTimer / 100f * new Vector3((float) this.random.Next(-500, 500) / 100f, (float) this.random.Next(-500, 500) / 100f, (float) this.random.Next(-500, 500) / 100f);
              if (this.camShakeTimer <= 0)
              {
                this.iscamShake = false;
                this.camShakeTimer = 0;
                this.camShake = Vector3.Zero;
              }
            }
            this.aCampos = new Vector3(this.campos.X, this.campos.Y + this.bobber + this.camhite, this.campos.Z);
            this.aCamtarget = this.camShake + new Vector3(this.camlookpos.X, this.camlookpos.Y + this.bobber + this.camhite, this.camlookpos.Z);
            this.aUppy = Vector3.Up;
            this.lens = 70f;
          }
          if ((double) this.sc.vehiclelerp < 1.0)
          {
            this.sc.vehiclelerp += 0.025f;
            if ((double) this.sc.vehiclelerp > 1.0)
              this.sc.vehiclelerp = 1f;
            if (this.vehicleindex == 3)
              this.lens = MathHelper.Lerp(70f, 80f, this.sc.vehiclelerp);
            if (this.vehicleindex == 1)
              this.lens = MathHelper.Lerp(80f, 70f, this.sc.vehiclelerp);
            this.setLens(this.lens);
            this.aCampos = Vector3.Hermite(this.bCampos, Vector3.Zero, this.aCampos, Vector3.Zero, this.sc.vehiclelerp);
            this.aCamtarget = Vector3.Hermite(this.bCamtarget, Vector3.Zero, this.aCamtarget, Vector3.Zero, this.sc.vehiclelerp);
            this.aUppy = Vector3.Hermite(this.bUppy, Vector3.Zero, this.aUppy, Vector3.Zero, this.sc.vehiclelerp);
          }
          this.viewMatrix = Matrix.CreateLookAt(this.aCampos, this.aCamtarget, this.aUppy);
        }
        this.prevstate = this.gamePadState;
        if (this.myframe % 40 == 0)
        {
          this.atRover = false;
          if (this.vehicleindex == 3 && !Facility.inFacility && (double) Vector3.DistanceSquared(this.aCampos, this.rover.position) < 22500.0 && (double) Vector3.Dot(Vector3.Normalize(this.aCamtarget - this.aCampos), Vector3.Normalize(this.rover.position - this.aCampos)) > 0.64999997615814209)
            this.atRover = true;
        }
        this.gemPOS = new Vector2((float) ((int) Math.Round((double) this.trnLoctn.X / 1000.0) * 1000), (float) ((int) Math.Round((double) this.trnLoctn.Z / 1000.0) * 1000));
        this.vector2_0 = this.gemPOS;
        if (this.vehicleindex != 1 && this.lander.door1 == 1)
        {
          this.updateGems(ref this.shale1);
          this.updateGems(ref this.shale2);
          this.updateGems(ref this.shale3);
        }
        else
        {
          this.bucketCollide();
          if (this.rover.scooperON || this.sc.equip[3] > 1)
          {
            this.nearScooper(ref this.shale1, this.sc.shalehit1);
            this.nearScooper(ref this.shale2, this.sc.boulderhit2);
            this.nearScooper(ref this.shale3, this.sc.boulderhit3);
          }
          this.updateGems(ref this.shale1);
          this.updateGems(ref this.shale2);
          this.updateGems(ref this.shale3);
          for (int index = 0; index < this.shale1.xCount; ++index)
          {
            this.shale1.hitDumper(this.shale1.xInst[index]);
            this.shale1.xInst[index].Update(ref this.tmake.heightData);
            this.shale1.xTrans[index].Trans = this.shale1.xInst[index].transform;
          }
          for (int index = 0; index < this.shale2.xCount; ++index)
          {
            this.shale2.hitDumper(this.shale2.xInst[index]);
            this.shale2.xInst[index].Update(ref this.tmake.heightData);
            this.shale2.xTrans[index].Trans = this.shale2.xInst[index].transform;
          }
          for (int index = 0; index < this.shale3.xCount; ++index)
          {
            this.shale3.hitDumper(this.shale3.xInst[index]);
            this.shale3.xInst[index].Update(ref this.tmake.heightData);
            this.shale3.xTrans[index].Trans = this.shale3.xInst[index].transform;
          }
        }
        astro.inDumper = this.rover.orientation * Matrix.CreateFromAxisAngle(this.rover.orientation.Forward, this.rover.leanAmt) * Matrix.CreateTranslation(this.rover.pp);
        astro.rovpos = this.rover.position;
        astroDupe.constantRoverPosition = this.rover.position;
        astro.rovveloc = Vector3.Zero;
        if (this.vehicleindex == 1)
        {
          astro.rovveloc = this.rover.velocity;
          this.sc.astronaut.Update(ref this.tmake.heightData, ref this.tmake.normals, 1, this.aCampos, this.aCamtarget, false);
          if (astro.someonedied)
          {
            if (this.objIndex == 5)
              this.emo = GameplayScreen.act.killed;
            this.sc.trophy.win(this.sc.trophy.spacedeath);
          }
          this.sc.astronaut.facingRover = this.rover.facingDirection;
          if (!this.sc.astronaut.manhit)
            return;
          this.sc.astronaut.manhit = false;
          this.vibrateControl = 30;
        }
        else
        {
          this.sc.astronaut.Update(ref this.tmake.heightData, ref this.tmake.normals, 0, this.aCampos, this.aCamtarget, this.vehicleindex == 2 && this.lander.door1 == 1);
          if (this.vehicleindex != 3)
            return;
          this.nearAstro = this.sc.astronaut.chosen != -1;
          if (this.rock.chosen != -1)
            this.nearFlower = true;
          else
            this.nearFlower = false;
        }
      }
      else if (this.editcam)
      {
        this.editcam = false;
        this.sc.SaveSpacePrefs();
      }
      else
      {
        this.sc.back.Play(this.sc.ev, 0.0f, 0.0f);
        GamePad.SetVibration(this.myplayer, 0.0f, 0.0f);
        if (this.gravelI.State == SoundState.Playing)
          this.gravelI.Pause();
        if (this.roverEngineI.State == SoundState.Playing)
          this.roverEngineI.Pause();
        if (this.dropEngineI.State == SoundState.Playing)
          this.dropEngineI.Pause();
        if (this.breathing.State == SoundState.Playing)
          this.breathing.Pause();
        if (this.landerEngineI.State == SoundState.Playing)
          this.landerEngineI.Pause();
        if (this.overtureInstance.State == SoundState.Playing)
          this.overtureInstance.Pause();
        if (this.flowerradioInstance.State == SoundState.Playing)
          this.flowerradioInstance.Pause();
        this.sc.menutype = 1;
        string text = "Controls";
        if (this.sc.usingMouse)
        {
          text = "Keyboard";
          this.sc.Game.IsMouseVisible = true;
        }
        PauseMenuScreen screen = new PauseMenuScreen(text);
        screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
        {
          try
          {
            GamePad.SetVibration(this.myplayer, 0.0f, 0.0f);
            this.dropEngineI.Dispose();
            this.landerEngineI.Dispose();
            this.roverEngineI.Dispose();
            this.gravelI.Dispose();
            this.overtureInstance.Dispose();
            this.flowerradioInstance.Dispose();
            this.breathing.Dispose();
          }
          catch
          {
          }
          this.resolveTarget1.Dispose();
          this.resolveTarget1 = (RenderTarget2D) null;
          this.resolveTarget2.Dispose();
          this.resolveTarget2 = (RenderTarget2D) null;
          this.shadowTarget.Dispose();
          this.shadowTarget = (RenderTarget2D) null;
          this.starmap.manmadestars.Dispose();
          this.starmap.tt.Dispose();
          this.starmap.starSheet.Dispose();
          this.starmap.colorArray1 = new Color[0];
          this.sc.astronaut.man.dupe.Clear();
          this.texdata = new MoonSurface.tex[0];
          try
          {
            if (this.backgroundThread != null)
            {
              this.backgroundThreadExit.Set();
              this.backgroundThread.Join();
            }
          }
          catch
          {
          }
          this.sc.SaveSpacePrefs();
          this.sc.LoadPrefs();
          this.sc.LoadSavedKeys();
          LoadingScreen2.Load(this.ScreenManager, false, new PlayerIndex?(), null, (GameScreen) new MainMenu(false));
          GC.Collect();
        });
        screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => { });
        this.sc.AddScreen((GameScreen) screen, this.ControllingPlayer);
      }
    }

    private void setLens(float lens)
    {
      if (this.vehicleindex == 1)
      {
        this.shortclip = 25f;
        this.farclip = 55000f;
        this.shortclip2 = 10f;
        this.farclip2 = 90000f;
        if (this.rover.dashcam == 1)
        {
          this.shortclip = 1f;
          this.shortclip2 = 0.5f;
        }
        this.projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(lens), this.aspectratio, this.shortclip, this.farclip);
        this.longProjection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(lens), this.aspectratio, this.shortclip2, this.farclip2);
      }
      else if (this.vehicleindex == 2)
      {
        this.shortclip = 100f;
        this.farclip = 65000f;
        this.shortclip2 = 10f;
        this.farclip2 = 90000f;
        this.projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(lens), this.aspectratio, this.shortclip, this.farclip);
        this.longProjection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(lens), this.aspectratio, this.shortclip2, this.farclip2);
      }
      else
      {
        if (this.vehicleindex != 3)
          return;
        this.shortclip = 10f;
        this.farclip = 55000f;
        this.shortclip2 = 10f;
        this.farclip2 = 90000f;
        this.projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(lens), this.aspectratio, this.shortclip, this.farclip);
        this.longProjection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(lens), this.aspectratio, this.shortclip2, this.farclip2);
      }
    }

    private void setLens2(float lens)
    {
      this.projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(lens), this.aspectratio, 70f, 250000f);
      this.longProjection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(lens), this.aspectratio, this.shortclip2, 260000f);
    }

    public override void Update(
      GameTime gameTime,
      bool otherScreenHasFocus,
      bool coveredByOtherScreen)
    {
      base.Update(gameTime, otherScreenHasFocus, false);
      ++this.frameCounter;
      if (!this.IsActive)
        return;
      ++this.myframe;
      --this.displayObjective;
      if (this.displayObjective > 450 && this.displayObjective < 455)
      {
        this.memoTimer = 300;
        GameplayScreen.memo.Length = 0;
        if (this.firstMess)
        {
          if (this.sc.usingMouse)
            GameplayScreen.memo.Append("Welcome Back : Press Esc For Menu");
          else
            GameplayScreen.memo.Append("Welcome Back : Press Back For Menu");
          this.memoIcon = 2;
          this.sc.tada2.Play(this.sc.ev * 0.6f, 0.0f, 0.0f);
          this.firstMess = false;
          this.displayObjective = 240;
        }
        else
        {
          if (this.objIndex == 0)
          {
            GameplayScreen.memo.Append("Good Job You Can Breathe");
            this.sc.tada2.Play(this.sc.ev * 0.6f, 0.0f, 0.0f);
          }
          else if (this.objIndex == 1)
          {
            GameplayScreen.memo.Append("Impressive Flying");
            this.sc.tada3.Play(this.sc.ev * 0.6f, 0.0f, 0.0f);
          }
          else if (this.objIndex == 2)
          {
            if (!this.sc.man4)
            {
              this.sc.fanfare.Play(this.sc.ev, 0.0f, 0.0f);
              this.sc.man4 = true;
              this.sc.SaveEquipables();
              GameplayScreen.memo.Append("New Character Unlocked");
            }
            else
            {
              this.sc.tada4.Play(this.sc.ev * 0.6f, 0.0f, 0.0f);
              GameplayScreen.memo.Append("Epic Rescue Strategy");
            }
          }
          else if (this.objIndex == 3)
          {
            this.sc.tada5.Play(this.sc.ev * 0.6f, 0.0f, 0.0f);
            GameplayScreen.memo.Append("Congrats You Rock");
          }
          else if (this.objIndex == 4)
          {
            this.sc.tada6.Play(this.sc.ev * 0.6f, 0.0f, 0.0f);
            GameplayScreen.memo.Append("Elon Musk Is Jealous");
          }
          else if (this.objIndex == 5)
          {
            this.sc.tada7.Play(this.sc.ev * 0.6f, 0.0f, 0.0f);
            GameplayScreen.memo.Append("You Murderer You");
            this.overlay.bigfacilitymarker = true;
          }
          else if (this.objIndex == 6)
          {
            this.sc.tada3.Play(this.sc.ev * 0.6f, 0.0f, 0.0f);
            GameplayScreen.memo.Append("You Are A Clever One");
          }
          else if (this.objIndex == 7)
          {
            this.sc.tada4.Play(this.sc.ev * 0.6f, 0.0f, 0.0f);
            GameplayScreen.memo.Append("Now You Learned The Secret");
          }
          else if (this.objIndex == 8)
          {
            this.sc.tada5.Play(this.sc.ev * 0.6f, 0.0f, 0.0f);
            GameplayScreen.memo.Append("Found New Mission");
          }
          else if (this.objIndex == 9)
          {
            this.sc.tada6.Play(this.sc.ev * 0.6f, 0.0f, 0.0f);
            GameplayScreen.memo.Append("That Was A Great Rescue");
          }
          else if (this.objIndex == 10)
          {
            this.sc.tada2.Play(this.sc.ev * 0.6f, 0.0f, 0.0f);
            GameplayScreen.memo.Append("You Could Leave The Planet");
          }
          else if (this.objIndex == 11)
          {
            this.sc.tada7.Play(this.sc.ev * 0.6f, 0.0f, 0.0f);
            GameplayScreen.memo.Append("Another Hero in the Making");
          }
          else if (this.objIndex == 12)
          {
            this.sc.tada3.Play(this.sc.ev * 0.6f, 0.0f, 0.0f);
            GameplayScreen.memo.Append("You Are The Best Player");
          }
          this.memoIcon = 2;
          this.displayObjective = 450;
          ++this.objIndex;
          if (this.objIndex > this.objectiveData.Count - 1)
          {
            this.displayObjective = 0;
            this.objIndex = this.objectiveData.Count - 1;
          }
        }
      }
      if (this.displayObjective > 1 && this.displayObjective < 10)
      {
        this.typewriterblank = 500f;
        this.textflag = 0;
        this.typewriterwait = 480f;
        this.typeposition = 0.0f;
        this.typevertical = (float) this.random.Next(100, 150);
        this.typewriterdelay = this.random.Next(2, 7);
        this.displayObjective = 0;
      }
      if (this.objIndex == 8 || this.objIndex == 12)
      {
        ++this.waiting;
        if (this.waiting > 600)
          this.emo = GameplayScreen.act.waited;
      }
      if (this.myframe % 180 == 0 && this.displayObjective <= 0)
      {
        switch (this.objIndex)
        {
          case 0:
            if (this.emo == GameplayScreen.act.rovered)
            {
              this.displayObjective = 850;
              break;
            }
            break;
          case 1:
            if (this.emo == GameplayScreen.act.landered)
            {
              this.displayObjective = 850;
              Vector3 vector3 = Vector3.Zero;
              for (int index = 0; index < this.sc.astronaut.man.dupe.Count; ++index)
              {
                if (this.sc.astronaut.man.dupe[index].headType == 2 && this.sc.astronaut.man.dupe[index].emo == astroDupe.emotion.stranded)
                  vector3 = this.sc.astronaut.man.dupe[index].mypos;
              }
              if (vector3 != Vector3.Zero)
              {
                Overlay.manbouy = vector3;
                break;
              }
              break;
            }
            break;
          case 2:
            for (int index = 0; index < this.sc.astronaut.man.dupe.Count; ++index)
            {
              if (astro.teamCount > astro.oldteamCount)
              {
                astro.oldteamCount = astro.teamCount;
                this.displayObjective = 850;
              }
            }
            break;
          case 3:
            if (this.emo == GameplayScreen.act.rocked)
            {
              this.displayObjective = 850;
              break;
            }
            break;
          case 4:
            if (this.emo == GameplayScreen.act.refined)
            {
              this.displayObjective = 850;
              break;
            }
            break;
          case 5:
            if (this.emo == GameplayScreen.act.killed)
            {
              this.displayObjective = 850;
              break;
            }
            break;
          case 6:
            if (this.emo == GameplayScreen.act.facilityfound)
            {
              this.displayObjective = 850;
              this.overlay.bigfacilitymarker = true;
              break;
            }
            break;
          case 7:
            if (this.emo == GameplayScreen.act.cloned)
            {
              this.displayObjective = 850;
              break;
            }
            break;
          case 8:
            if (this.emo == GameplayScreen.act.waited)
            {
              this.displayObjective = 850;
              this.waiting = 0;
              this.emo = GameplayScreen.act.nothing;
              Vector3 vector3 = Vector3.Zero;
              for (int index = 0; index < this.sc.astronaut.man.dupe.Count; ++index)
              {
                if (this.sc.astronaut.man.dupe[index].emo == astroDupe.emotion.stranded)
                  vector3 = this.sc.astronaut.man.dupe[index].mypos;
              }
              if (vector3 != Vector3.Zero)
              {
                Overlay.manbouy = vector3;
                break;
              }
              break;
            }
            break;
          case 9:
            for (int index = 0; index < this.sc.astronaut.man.dupe.Count; ++index)
            {
              if (astro.teamCount > astro.oldteamCount)
              {
                astro.oldteamCount = astro.teamCount;
                this.displayObjective = 850;
              }
            }
            break;
          case 10:
            if (this.emo == GameplayScreen.act.dropship)
            {
              this.displayObjective = 850;
              Vector3 vector3 = Vector3.Zero;
              for (int index = 0; index < this.sc.astronaut.man.dupe.Count; ++index)
              {
                if (this.sc.astronaut.man.dupe[index].emo == astroDupe.emotion.stranded)
                  vector3 = this.sc.astronaut.man.dupe[index].mypos;
              }
              if (vector3 != Vector3.Zero)
              {
                Overlay.manbouy = vector3;
                break;
              }
              break;
            }
            break;
          case 11:
            for (int index = 0; index < this.sc.astronaut.man.dupe.Count; ++index)
            {
              if (astro.teamCount > astro.oldteamCount)
              {
                astro.oldteamCount = astro.teamCount;
                this.displayObjective = 850;
              }
            }
            break;
          case 12:
            if (this.emo == GameplayScreen.act.waited)
            {
              this.displayObjective = 850;
              this.waiting = 0;
              break;
            }
            break;
        }
      }
      --this.radiotimer;
      if (this.radiotimer <= 0)
      {
        if (this.radiocount == 13)
        {
          float num1 = 1f - MathHelper.Clamp(Vector2.Distance(new Vector2(this.lander.position.X, this.lander.position.Z), this.facility.facilityLocate) / 12000f, 0.0f, 0.93f);
          int num2 = this.random.Next(1, 100);
          if (num2 < 40)
            this.sc.radio3.Play(this.sc.voiceVolume * num1, 0.1f, 0.0f);
          if (num2 >= 40)
            this.sc.radio2.Play(this.sc.voiceVolume * num1, 0.0f, 0.0f);
        }
        this.radiocount = 0;
      }
      --this.horntimer;
      if (this.horntimer <= 0)
      {
        if (this.horncount >= 1)
        {
          this.sc.astronaut.everyoneOut = true;
          if (this.horncount >= 5)
          {
            messagebox screen = new messagebox("Really?  10 Honks?", 0, 0);
            this.sc.trophy.win(this.sc.trophy.walkinghere);
            this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
          }
          if (this.horncount == 20)
            this.sc.AddScreen((GameScreen) new messagebox("You Are Crazy!", 0, 0), new PlayerIndex?());
          if (this.horncount >= 80 && this.horncount <= 100)
            this.sc.AddScreen((GameScreen) new messagebox("Use The Radio", 0, 0), new PlayerIndex?());
        }
        this.horncount = 0;
      }
      ++this.sc.myTimer;
      if (this.vehicleindex != 1 && this.vehicleindex != 3)
      {
        this.dust.Update(gameTime);
        this.streaks.Update(gameTime);
      }
      else
      {
        this.TireTreads();
        this.skids.Update(gameTime);
      }
      this.terrainhester();
      if (this.frameCounter % 120 == 0)
      {
        this.overlay.flower = this.rock.chosenfar == -1 ? Vector3.Zero : this.rock.flowerInst[this.rock.chosenfar].mypos;
        if (this.overlay.bouy1 != Vector3.Zero)
        {
          if ((double) Math.Abs(this.trnLoctn.X - this.overlay.bouy1.X) > 150000.0)
            this.overlay.bouy1.X += (float) (Math.Sign(this.trnLoctn.X - this.overlay.bouy1.X) * 300000);
          if ((double) Math.Abs(this.trnLoctn.Z - this.overlay.bouy1.Z) > 150000.0)
            this.overlay.bouy1.Z += (float) (Math.Sign(this.trnLoctn.Z - this.overlay.bouy1.Z) * 300000);
        }
        if (this.overlay.bouy2 != Vector3.Zero)
        {
          if ((double) Math.Abs(this.trnLoctn.X - this.overlay.bouy2.X) > 150000.0)
            this.overlay.bouy2.X += (float) (Math.Sign(this.trnLoctn.X - this.overlay.bouy2.X) * 300000);
          if ((double) Math.Abs(this.trnLoctn.Z - this.overlay.bouy2.Z) > 150000.0)
            this.overlay.bouy2.Z += (float) (Math.Sign(this.trnLoctn.Z - this.overlay.bouy2.Z) * 300000);
        }
        if (Overlay.manbouy != Vector3.Zero)
        {
          if ((double) Math.Abs(this.trnLoctn.X - Overlay.manbouy.X) > 150000.0)
          {
            int num = Math.Sign(this.trnLoctn.X - Overlay.manbouy.X);
            Overlay.manbouy.X += (float) (num * 300000);
          }
          if ((double) Math.Abs(this.trnLoctn.Z - Overlay.manbouy.Z) > 150000.0)
          {
            int num = Math.Sign(this.trnLoctn.Z - Overlay.manbouy.Z);
            Overlay.manbouy.Z += (float) (num * 300000);
          }
        }
        for (int index = 0; index < this.sc.astronaut.man.dupe.Count; ++index)
        {
          if ((double) Math.Abs(this.trnLoctn.X - this.sc.astronaut.man.dupe[index].mypos.X) > 150000.0)
          {
            int num = Math.Sign(this.trnLoctn.X - this.sc.astronaut.man.dupe[index].mypos.X);
            this.sc.astronaut.man.dupe[index].mypos.X += (float) (num * 300000);
          }
          if ((double) Math.Abs(this.trnLoctn.Z - this.sc.astronaut.man.dupe[index].mypos.Z) > 150000.0)
          {
            int num = Math.Sign(this.trnLoctn.Z - this.sc.astronaut.man.dupe[index].mypos.Z);
            this.sc.astronaut.man.dupe[index].mypos.Z += (float) (num * 300000);
          }
        }
        if ((double) Math.Abs(this.trnLoctn.X - this.vector3_0.X) > 150000.0)
          this.vector3_0.X += (float) (Math.Sign(this.trnLoctn.X - this.vector3_0.X) * 300000);
        if ((double) Math.Abs(this.trnLoctn.Z - this.vector3_0.Z) > 150000.0)
          this.vector3_0.Z += (float) (Math.Sign(this.trnLoctn.Z - this.vector3_0.Z) * 300000);
        if ((double) Math.Abs(this.trnLoctn.X - this.farmLocation.X) > 150000.0)
        {
          this.farmLocation.X += (float) (Math.Sign(this.trnLoctn.X - this.farmLocation.X) * 300000);
          Lander.farmLocation = this.farmLocation;
          Rover.farmLocation = this.farmLocation;
          astroDupe.farmLocation = this.farmLocation;
          this.overlay.farm.X = this.farmLocation.X;
          this.overlay.farm.Z = this.farmLocation.Z;
        }
        if ((double) Math.Abs(this.trnLoctn.Z - this.farmLocation.Z) > 150000.0)
        {
          this.farmLocation.Z += (float) (Math.Sign(this.trnLoctn.Z - this.farmLocation.Z) * 300000);
          Lander.farmLocation = this.farmLocation;
          Rover.farmLocation = this.farmLocation;
          astroDupe.farmLocation = this.farmLocation;
          this.overlay.farm.X = this.farmLocation.X;
          this.overlay.farm.Z = this.farmLocation.Z;
        }
        if ((double) Math.Abs(this.trnLoctn.X - this.facility.facilityLocate.X) > 150000.0)
        {
          this.facility.facilityLocate.X += (float) (Math.Sign(this.trnLoctn.X - this.facility.facilityLocate.X) * 300000);
          this.overlay.facility.X = this.facility.facilityLocate.X;
          this.overlay.facility.Z = this.facility.facilityLocate.Y;
        }
        if ((double) Math.Abs(this.trnLoctn.Z - this.facility.facilityLocate.Y) > 150000.0)
        {
          this.facility.facilityLocate.Y += (float) (Math.Sign(this.trnLoctn.Z - this.facility.facilityLocate.Y) * 300000);
          this.overlay.facility.X = this.facility.facilityLocate.X;
          this.overlay.facility.Z = this.facility.facilityLocate.Y;
        }
        if (this.vehicleindex == 1)
        {
          if ((double) Math.Abs(this.rover.position.X - this.lander.position.X) > 150000.0)
          {
            int num = Math.Sign(this.rover.position.X - this.lander.position.X);
            this.lander.position.X += (float) (num * 300000);
            for (int index = 0; index < 12; index += 3)
            {
              this.rover.region1[index] += (float) (num * 300000);
              this.rover.region2[index] += (float) (num * 300000);
              this.rover.region3[index] += (float) (num * 300000);
            }
          }
          if ((double) Math.Abs(this.rover.position.Z - this.lander.position.Z) > 150000.0)
          {
            int num = Math.Sign(this.rover.position.Z - this.lander.position.Z);
            this.lander.position.Z += (float) (num * 300000);
            for (int index = 0; index < 12; index += 3)
            {
              this.rover.region1[index + 2] += (float) (num * 300000);
              this.rover.region2[index + 2] += (float) (num * 300000);
              this.rover.region3[index + 2] += (float) (num * 300000);
            }
          }
        }
      }
      if (this.frameCounter % 2 == 0)
      {
        float num = Vector2.Distance(new Vector2(this.trnLoctn.X, this.trnLoctn.Z), new Vector2(this.oldtrnLoctn.X, this.oldtrnLoctn.Z));
        this.delta.X = this.trnLoctn.X - this.oldtrnLoctn.X;
        this.delta.Z = this.trnLoctn.Z - this.oldtrnLoctn.Z;
        this.delta.Y = 0.0f;
        if ((double) num >= 5.0 && (double) this.delta.LengthSquared() > 0.0)
          this.starRot *= Matrix.CreateFromAxisAngle(Vector3.Cross(Vector3.Normalize(this.delta), Vector3.Up), num / 110000f);
        this.oldtrnLoctn.X = this.trnLoctn.X;
        this.oldtrnLoctn.Y = this.trnLoctn.Y;
        this.oldtrnLoctn.Z = this.trnLoctn.Z;
        if (this.vehicleindex == 3)
          this.starRot *= Matrix.CreateFromAxisAngle(Vector3.Cross(new Vector3(-1f, 0.0f, 0.4f), Vector3.Up), 6E-05f);
        else
          this.starRot *= Matrix.CreateFromAxisAngle(Vector3.Cross(new Vector3(-1f, 0.0f, 0.1f), Vector3.Up), 2E-05f);
        this.sunDir = -Vector3.Normalize(Vector3.Transform(new Vector3(1f, 0.0f, 0.0f), this.starRot));
        this.updateMusic();
      }
      if (this.frameCounter % 3 == 0)
      {
        if (this.vehicleindex == 1)
        {
          Vector2 vector2_1 = new Vector2(this.aCampos.X, this.aCampos.Z) - new Vector2(this.lander.position.X, this.lander.position.Z);
          Vector2 vector2_2 = new Vector2(this.aCampos.X, this.aCampos.Z) - new Vector2(this.aCamtarget.X, this.aCamtarget.Z);
          this.overlay.landerNeedle = (float) Math.Acos((double) Vector2.Dot(vector2_1, vector2_2) / ((double) vector2_1.Length() * (double) vector2_2.Length()));
          this.overlay.landerNeedle = (double) vector2_1.X * (double) vector2_2.Y - (double) vector2_2.X * (double) vector2_1.Y > 0.0 ? this.overlay.landerNeedle : -this.overlay.landerNeedle;
        }
        if (this.overlay.flower != Vector3.Zero)
        {
          Vector2 vector2_3 = new Vector2(this.aCampos.X, this.aCampos.Z) - new Vector2(this.overlay.flower.X, this.overlay.flower.Z);
          Vector2 vector2_4 = new Vector2(this.aCampos.X, this.aCampos.Z) - new Vector2(this.aCamtarget.X, this.aCamtarget.Z);
          this.overlay.flowerNeedle = (float) Math.Acos((double) Vector2.Dot(vector2_3, vector2_4) / ((double) vector2_3.Length() * (double) vector2_4.Length()));
          this.overlay.flowerNeedle = (double) vector2_3.X * (double) vector2_4.Y - (double) vector2_4.X * (double) vector2_3.Y > 0.0 ? this.overlay.flowerNeedle : -this.overlay.flowerNeedle;
        }
        if (this.overlay.bouy1 != Vector3.Zero)
        {
          Vector2 vector2_5 = new Vector2(this.aCampos.X, this.aCampos.Z) - new Vector2(this.overlay.bouy1.X, this.overlay.bouy1.Z);
          Vector2 vector2_6 = new Vector2(this.aCampos.X, this.aCampos.Z) - new Vector2(this.aCamtarget.X, this.aCamtarget.Z);
          this.overlay.float_0 = (float) Math.Acos((double) Vector2.Dot(vector2_5, vector2_6) / ((double) vector2_5.Length() * (double) vector2_6.Length()));
          this.overlay.float_0 = (double) vector2_5.X * (double) vector2_6.Y - (double) vector2_6.X * (double) vector2_5.Y > 0.0 ? this.overlay.float_0 : -this.overlay.float_0;
        }
        if (this.overlay.bouy2 != Vector3.Zero)
        {
          Vector2 vector2_7 = new Vector2(this.aCampos.X, this.aCampos.Z) - new Vector2(this.overlay.bouy2.X, this.overlay.bouy2.Z);
          Vector2 vector2_8 = new Vector2(this.aCampos.X, this.aCampos.Z) - new Vector2(this.aCamtarget.X, this.aCamtarget.Z);
          this.overlay.float_1 = (float) Math.Acos((double) Vector2.Dot(vector2_7, vector2_8) / ((double) vector2_7.Length() * (double) vector2_8.Length()));
          this.overlay.float_1 = (double) vector2_7.X * (double) vector2_8.Y - (double) vector2_8.X * (double) vector2_7.Y > 0.0 ? this.overlay.float_1 : -this.overlay.float_1;
        }
        if (Overlay.manbouy != Vector3.Zero)
        {
          Vector2 vector2_9 = new Vector2(this.aCampos.X, this.aCampos.Z) - new Vector2(Overlay.manbouy.X, Overlay.manbouy.Z);
          Vector2 vector2_10 = new Vector2(this.aCampos.X, this.aCampos.Z) - new Vector2(this.aCamtarget.X, this.aCamtarget.Z);
          this.overlay.bouymanNeedle = (float) Math.Acos((double) Vector2.Dot(vector2_9, vector2_10) / ((double) vector2_9.Length() * (double) vector2_10.Length()));
          this.overlay.bouymanNeedle = (double) vector2_9.X * (double) vector2_10.Y - (double) vector2_10.X * (double) vector2_9.Y > 0.0 ? this.overlay.bouymanNeedle : -this.overlay.bouymanNeedle;
        }
        if (this.overlay.facility != Vector3.Zero)
        {
          Vector2 vector2_11 = new Vector2(this.aCampos.X, this.aCampos.Z) - new Vector2(this.overlay.facility.X, this.overlay.facility.Z);
          Vector2 vector2_12 = new Vector2(this.aCampos.X, this.aCampos.Z) - new Vector2(this.aCamtarget.X, this.aCamtarget.Z);
          this.overlay.facilityNeedle = (float) Math.Acos((double) Vector2.Dot(vector2_11, vector2_12) / ((double) vector2_11.Length() * (double) vector2_12.Length()));
          this.overlay.facilityNeedle = (double) vector2_11.X * (double) vector2_12.Y - (double) vector2_12.X * (double) vector2_11.Y > 0.0 ? this.overlay.facilityNeedle : -this.overlay.facilityNeedle;
        }
        if (this.overlay.farm != Vector3.Zero)
        {
          Vector2 vector2_13 = new Vector2(this.aCampos.X, this.aCampos.Z) - new Vector2(this.overlay.farm.X, this.overlay.farm.Z);
          Vector2 vector2_14 = new Vector2(this.aCampos.X, this.aCampos.Z) - new Vector2(this.aCamtarget.X, this.aCamtarget.Z);
          this.overlay.farmNeedle = (float) Math.Acos((double) Vector2.Dot(vector2_13, vector2_14) / ((double) vector2_13.Length() * (double) vector2_14.Length()));
          this.overlay.farmNeedle = (double) vector2_13.X * (double) vector2_14.Y - (double) vector2_14.X * (double) vector2_13.Y > 0.0 ? this.overlay.farmNeedle : -this.overlay.farmNeedle;
        }
      }
      Vector3 grnd = Vector3.Zero;
      if (this.vehicleindex == 1)
        grnd = this.rover.position;
      if (this.vehicleindex == 2)
        grnd = this.lander.position;
      if (this.vehicleindex == 3)
        grnd = this.aCampos;
      this.rock.method_1(this.myframe, this.vehicleindex, grnd, ref this.tmake.heightData, ref this.tmake.normals, ref this.objectData);
      if (this.myframe % 3 == 0)
        this.rock.removeOBJECTS(this.aCampos, this.aCamtarget, this.vehicleindex, grnd, ref this.tmake.heightData, ref this.tmake.normals, ref this.objectData);
      this.rock.collideROCKS(this.vehicleindex, ref this.lander, ref this.rover, this.aCampos, ref this.sc.boulderhit, ref this.sc.crack, ref this.tmake.heightData, ref this.tmake.normals, ref this.objectData, ref this.vec, ref this.hitVec);
      if (this.vehicleindex == 1 && this.nearfarm && this.myframe % 2 == 0)
      {
        ++this.tragetCount;
        if (this.tragetCount > 4)
          this.tragetCount = 0;
        if (this.tragetCount == 0)
        {
          this.barnloc1 = new Vector3(391f, 0.0f, 1636f) + this.farmLocation;
          this.xSpace = new Vector2(41f, 742f) + new Vector2(this.farmLocation.X, this.farmLocation.X);
          this.zSpace = new Vector2(1388f, 1859f) + new Vector2(this.farmLocation.Z, this.farmLocation.Z);
        }
        if (this.tragetCount == 1)
        {
          this.barnloc1 = new Vector3(1599f, 0.0f, -59f) + this.farmLocation;
          this.xSpace = new Vector2(1431f, 1768f) + new Vector2(this.farmLocation.X, this.farmLocation.X);
          this.zSpace = new Vector2(-209f, 91f) + new Vector2(this.farmLocation.Z, this.farmLocation.Z);
        }
        if (this.tragetCount == 2)
        {
          this.barnloc1 = new Vector3(-1646f, 0.0f, -188f) + this.farmLocation;
          this.xSpace = new Vector2(-2075f, -1217f) + new Vector2(this.farmLocation.X, this.farmLocation.X);
          this.zSpace = new Vector2(-689f, 314f) + new Vector2(this.farmLocation.Z, this.farmLocation.Z);
        }
        if (this.tragetCount == 3)
        {
          this.barnloc1 = new Vector3(1879f, 0.0f, -1732f) + this.farmLocation;
          this.xSpace = new Vector2(1670f, 2088f) + new Vector2(this.farmLocation.X, this.farmLocation.X);
          this.zSpace = new Vector2(-1928f, -1536f) + new Vector2(this.farmLocation.Z, this.farmLocation.Z);
        }
        if (this.tragetCount == 4)
        {
          this.barnloc1 = new Vector3(-1109f, 0.0f, -1645f) + this.farmLocation;
          this.xSpace = new Vector2(-1550f, -668f) + new Vector2(this.farmLocation.X, this.farmLocation.X);
          this.zSpace = new Vector2(-1819f, -1472f) + new Vector2(this.farmLocation.Z, this.farmLocation.Z);
        }
        if ((double) this.rover.position.X >= (double) this.xSpace.X && (double) this.rover.position.X <= (double) this.xSpace.Y && (double) this.rover.position.Z >= (double) this.zSpace.X && (double) this.rover.position.Z <= (double) this.zSpace.Y)
        {
          this.sc.boulderhit.Play(this.sc.ev, 0.0f, 0.0f);
          Vector2 vector2_15 = Vector2.Zero;
          Vector2 vector2_16 = new Vector2(this.rover.position.X - this.barnloc1.X, this.rover.position.Z - this.barnloc1.Z);
          if ((double) vector2_16.LengthSquared() > 0.0)
            vector2_15 = Vector2.Normalize(vector2_16);
          this.rover.grav.X = vector2_15.X * 20f;
          this.rover.grav.Z = vector2_15.Y * 20f;
          Rover.fric = 0.99f;
          Rover.rockhitCount = 140;
          this.rover.velocity = Vector3.Zero;
          this.rover.movement *= 0.0f;
        }
      }
      if (this.sc.gemDropType == 1)
      {
        if (this.firstshale < 4)
        {
          this.memoTimer = 190;
          GameplayScreen.memo.Length = 0;
          GameplayScreen.memo.Append("common shale rock");
          this.memoIcon = 2;
          this.sc.gemfound.Play(this.sc.ev, -0.2f, 0.0f);
          ++this.firstshale;
        }
        this.dropGems(ref this.shale1, this.random.Next(30, 60));
      }
      if (this.sc.gemDropType == 2)
      {
        if (this.firstruby < 6)
        {
          this.memoTimer = 190;
          GameplayScreen.memo.Length = 0;
          GameplayScreen.memo.Append("rare rubies found");
          this.memoIcon = 2;
          this.sc.gemfound.Play(this.sc.ev, 0.0f, 0.0f);
          ++this.firstruby;
        }
        this.dropGems(ref this.shale2, this.random.Next(20, 50));
      }
      if (this.sc.gemDropType == 3)
      {
        if (this.firstsapphire < 15)
        {
          this.memoTimer = 190;
          GameplayScreen.memo.Length = 0;
          GameplayScreen.memo.Append("explosive ornite found");
          this.memoIcon = 2;
          this.sc.gemfound.Play(this.sc.ev, 0.2f, 0.0f);
          ++this.firstsapphire;
        }
        this.dropGems(ref this.shale3, this.random.Next(20, 40));
      }
      this.sc.gemDropType = 0;
      if (this.frameCounter % 100 == 0 && this.vehicleindex == 1)
      {
        Vector2 vector2 = new Vector2(this.rover.position.X, this.rover.position.Z);
        if (this.overlay.bouy1 != Vector3.Zero && (double) Vector2.Distance(new Vector2(this.overlay.bouy1.X, this.overlay.bouy1.Z), vector2) < 90.0)
        {
          this.overlay.bouy1 = Vector3.Zero;
          this.sc.eraseBeacon.Play(this.sc.ev, 0.0f, 0.0f);
          this.overlay.nextBouy = 1;
        }
        if (this.overlay.bouy2 != Vector3.Zero && (double) Vector2.Distance(new Vector2(this.overlay.bouy2.X, this.overlay.bouy2.Z), vector2) < 90.0)
        {
          this.overlay.bouy2 = Vector3.Zero;
          this.sc.eraseBeacon.Play(this.sc.ev, 0.0f, 0.0f);
          this.overlay.nextBouy = 2;
        }
      }
      float amount1 = MathHelper.Clamp((float) (((double) this.dropshipDistance - 17000.0) / 70000.0), 0.0f, 1f);
      float num3 = MathHelper.Hermite(4500f, 0.0f, -7500f, 0.0f, amount1);
      if ((double) amount1 <= 0.0)
      {
        float height = 9999f;
        this.GetHeightOnly(ref this.tmake.heightData, new Vector3(this.vector3_0.X, this.vector3_0.Y, this.vector3_0.Z + 3000f), out height);
        this.GetHeightOnly(ref this.tmake.heightData, new Vector3(this.vector3_0.X, this.vector3_0.Y, this.vector3_0.Z + 9000f), out this.surf);
        if ((double) this.surf <= (double) height)
          this.surf = height;
      }
      float amount2 = MathHelper.Hermite(1f / 500f, 0.0f, 1f, 0.0f, amount1);
      if (!this.lander.onDropship)
      {
        this.dropshipAcc -= 0.5f;
        if ((double) this.dropshipAcc < 20.0)
          this.dropshipAcc = 20f;
      }
      else
      {
        if (this.objIndex == 10)
          this.emo = GameplayScreen.act.dropship;
        ++this.dropshipAcc;
        if ((double) this.dropshipAcc > 250.0)
          this.dropshipAcc = 250f;
      }
      this.vector3_0.Z += this.dropshipAcc;
      this.lander.dropshipVeloc.Z = this.dropshipAcc;
      this.vector3_0.Y = MathHelper.Lerp(this.vector3_0.Y, this.surf + num3, amount2);
      this.lander.dropship = this.vector3_0;
      this.dropshipBox = new BoundingBox(this.DSmin * 5f + this.vector3_0, this.DSmax * 5f + this.vector3_0);
      this.lander.insideDropship = this.dropshipBox.Intersects(new BoundingSphere(new Vector3(this.lander.position.X, this.lander.position.Y, this.lander.position.Z + this.dropshipAcc), 230f));
      if (this.vehicleindex == 3 && Facility.inFacility)
        this.facility.Update();
      this.vehicleDistance = this.vehicleindex != 3 ? Vector3.Distance(this.rover.position, this.lander.position) : Vector3.Distance(this.aCampos, this.lander.position);
      this.dropshipDistance = Vector2.Distance(new Vector2(this.vector3_0.X, this.vector3_0.Z), new Vector2(this.aCampos.X, this.aCampos.Z));
      this.faciltyDistance = Vector2.Distance(new Vector2(this.facility.facilityLocate.X, this.facility.facilityLocate.Y), new Vector2(this.trnLoctn.X, this.trnLoctn.Z));
      this.overlay.Update(this.vehicleindex);
    }

    private void terrainhester()
    {
      if (this.vehicleindex == 1)
      {
        this.trnLoctn.X = this.rover.position.X;
        this.trnLoctn.Y = this.rover.position.Y;
        this.trnLoctn.Z = this.rover.position.Z;
        this.cutoff = 300;
      }
      else if (this.vehicleindex == 2)
      {
        this.trnLoctn.X = this.lander.position.X;
        this.trnLoctn.Y = this.lander.position.Y;
        this.trnLoctn.Z = this.lander.position.Z;
        this.cutoff = 300;
      }
      else if (this.vehicleindex == 3)
      {
        this.trnLoctn.X = this.aCampos.X;
        this.trnLoctn.Y = this.aCampos.Y;
        this.trnLoctn.Z = this.aCampos.Z;
        this.cutoff = 300;
      }
      this.nearfarm = (double) this.trnLoctn.X < (double) this.farmLocation.X + 2000.0 && (double) this.trnLoctn.X > (double) this.farmLocation.X - 2000.0 && (double) this.trnLoctn.Z < (double) this.farmLocation.Z + 2000.0 && (double) this.trnLoctn.Z > (double) this.farmLocation.Z - 2000.0;
      Lander.nearfarm = this.nearfarm;
      Rover.nearfarm = this.nearfarm;
      Vector3 trnLoctn = this.trnLoctn;
      bool flag = (double) Vector2.Distance(new Vector2(this.trnLoctn.X, this.trnLoctn.Z), new Vector2(this.oldtrnLoctn2.X, this.oldtrnLoctn2.Z)) > (double) this.cutoff;
      if ((double) Vector2.Distance(new Vector2(trnLoctn.X, trnLoctn.Z), new Vector2(this.trnLoctnLast.X, this.trnLoctnLast.Z)) <= 149.0)
        return;
      while ((double) this.trnLoctnLast.X != (double) trnLoctn.X || (double) this.trnLoctnLast.Z != (double) trnLoctn.Z)
      {
        int num = 140;
        if ((double) this.trnLoctnLast.X < (double) trnLoctn.X)
        {
          this.trnLoctnLast.X += (float) num;
          if ((double) this.trnLoctnLast.X > (double) trnLoctn.X)
            this.trnLoctnLast.X = trnLoctn.X;
        }
        if ((double) this.trnLoctnLast.X > (double) trnLoctn.X)
        {
          this.trnLoctnLast.X -= (float) num;
          if ((double) this.trnLoctnLast.X < (double) trnLoctn.X)
            this.trnLoctnLast.X = trnLoctn.X;
        }
        if ((double) this.trnLoctnLast.Z < (double) trnLoctn.Z)
        {
          this.trnLoctnLast.Z += (float) num;
          if ((double) this.trnLoctnLast.Z > (double) trnLoctn.Z)
            this.trnLoctnLast.Z = trnLoctn.Z;
        }
        if ((double) this.trnLoctnLast.Z > (double) trnLoctn.Z)
        {
          this.trnLoctnLast.Z -= (float) num;
          if ((double) this.trnLoctnLast.Z < (double) trnLoctn.Z)
            this.trnLoctnLast.Z = trnLoctn.Z;
        }
        this.trnLoctn = this.trnLoctnLast;
        this.whatz = (int) Math.Round((double) this.trnLoctn.Z / (double) this.gridscale) * this.gridscale;
        this.zgrid = (int) (((double) this.trnLoctn.Z + (double) (this.gridscale / 2)) / (double) this.gridscale % (double) this.unit + (double) this.unit) % this.unit;
        this.whatx = (int) Math.Round((double) this.trnLoctn.X / (double) this.gridscale) * this.gridscale;
        this.xgrid = (int) (((double) this.trnLoctn.X + (double) (this.gridscale / 2)) / (double) this.gridscale % (double) this.unit + (double) this.unit) % this.unit;
        if (this.lastxgrid != this.xgrid && this.whatx != this.diffix || this.lastzgrid != this.zgrid && this.whatz != this.diffiz)
          this.UpdateTerrain(this.cutoff, false);
      }
      if (!flag)
        return;
      if (!this.isDrawing)
        this.tmake.moveall();
      this.trnLoctnLast = this.trnLoctn;
      this.oldtrnLoctn2 = this.trnLoctn;
    }

    public override void Draw(GameTime gameTime)
    {
      this.isDrawing = true;
      if (this.IsActive || MenuScreen.title == "Video Settings")
      {
        if (this.vehicleindex == 3 && Facility.inFacility)
        {
          this.sc.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
          this.sc.GraphicsDevice.BlendState = BlendState.Opaque;
          this.sc.GraphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;
          this.sc.GraphicsDevice.SetRenderTarget(this.resolveTarget2);
          this.sc.GraphicsDevice.Clear(Color.Transparent);
          this.bigquad.Meshes[0].MeshParts[0].Effect = this.simpEffect;
          Matrix translation = Matrix.CreateTranslation(Facility.offset);
          this.simpEffect.CurrentTechnique = this.simpEffect.Techniques["straight"];
          this.simpEffect.Parameters["val"].SetValue(this.facility.specRot);
          this.simpEffect.Parameters["campos"].SetValue(this.aCampos);
          this.simpEffect.Parameters["modelTexture"].SetValue((Texture) this.distortion);
          this.simpEffect.Parameters["world"].SetValue(translation);
          this.simpEffect.Parameters["view"].SetValue(this.viewMatrix);
          this.simpEffect.Parameters["projection"].SetValue(this.projectionMatrix);
          this.simpEffect.CurrentTechnique.Passes[0].Apply();
          this.bigquad.Meshes[0].Draw();
          this.facility.DrawBlack(this.viewMatrix, this.projectionMatrix, this.aCampos);
          this.sc.GraphicsDevice.SetRenderTarget((RenderTarget2D) null);
        }
        this.RestoreRenderStates();
        this.sc.GraphicsDevice.Clear(Color.Black);
        if (!Facility.inFacility && this.IsActive && (double) MathHelper.Clamp((float) (-((double) this.sunDir.Y - 0.20000000298023224) / 0.10000000149011612), 0.0f, 1f) > 0.0)
        {
          this.sc.GraphicsDevice.RasterizerState = RasterizerState.CullNone;
          this.sc.GraphicsDevice.SetRenderTarget(this.shadowTarget);
          this.sc.GraphicsDevice.BlendState = BlendState.Additive;
          this.sc.GraphicsDevice.Clear(Color.Black);
          Matrix identity1 = Matrix.Identity;
          Vector3 one = Vector3.One;
          Matrix identity2 = Matrix.Identity;
          if (this.vehicleindex == 2 || (double) this.vehicleDistance <= 5000.0)
          {
            float num = 0.8f;
            if (this.vehicleindex != 2)
              num = 1f - MathHelper.Clamp((float) (((double) this.vehicleDistance - 4000.0) / 1000.0), 0.2f, 1f);
            this.terrainEffect.Parameters["landerfade"].SetValue(num);
            this.LanderShadow.Meshes[0].MeshParts[0].Effect = this.shadowEffect;
            Matrix matrix1 = this.lander.orientation * Matrix.CreateTranslation(new Vector3(0.0f, 152f, 0.0f));
            Matrix matrix2 = Matrix.CreateShadow(Vector3.Normalize(new Vector3(this.sunDir.X / 3f, (float) (-(double) Math.Abs(this.sunDir.Y) - 0.15000000596046448), this.sunDir.Z / 3f)), this.wallPlane) * Matrix.CreateTranslation(new Vector3(0.0f, 1f, 0.0f) / 100f);
            this.shadowEffect.Parameters["colorme"].SetValue(new Vector3(1f, 0.0f, 0.0f));
            this.shadowEffect.Parameters["world"].SetValue(matrix1 * matrix2);
            this.shadowEffect.Parameters["view"].SetValue(Matrix.CreateLookAt(new Vector3(0.0f, 3300f, 0.0f), Vector3.Zero, Vector3.Forward));
            this.shadowEffect.Parameters["projection"].SetValue(Matrix.CreatePerspectiveFieldOfView(0.785f, 1f, 5f, 5000f));
            this.LanderShadow.Meshes[0].Draw();
          }
          if (this.vehicleindex == 1 || this.vehicleindex == 3 && (double) Vector3.Distance(this.aCampos, this.rover.position) <= 2000.0)
          {
            float num = 0.8f;
            if (this.vehicleindex == 3)
              num = 1f - MathHelper.Clamp((float) (((double) Vector3.Distance(this.aCampos, this.rover.position) - 1000.0) / 1000.0), 0.2f, 1f);
            this.terrainEffect.Parameters["roverfade"].SetValue(num);
            this.tankShadow.Meshes[0].MeshParts[0].Effect = this.shadowEffect;
            Matrix matrix3 = Matrix.CreateScale(1.5f) * this.rover.orientation * Matrix.CreateTranslation(new Vector3(0.0f, 0.0f, 0.0f));
            Matrix matrix4 = Matrix.CreateShadow(Vector3.Normalize(new Vector3(this.sunDir.X / 3f, (float) (-(double) Math.Abs(this.sunDir.Y) - 0.15000000596046448), this.sunDir.Z / 3f)), this.wallPlane) * Matrix.CreateTranslation(new Vector3(0.0f, 1f, 0.0f) / 100f);
            this.shadowEffect.Parameters["colorme"].SetValue(new Vector3(0.0f, 0.0f, 1f));
            this.shadowEffect.Parameters["view"].SetValue(Matrix.CreateLookAt(new Vector3(0.0f, 3500f, 0.0f), Vector3.Zero, Vector3.Forward));
            this.shadowEffect.Parameters["projection"].SetValue(Matrix.CreatePerspectiveFieldOfView(0.33f, 1f, 5f, 5000f));
            this.shadowEffect.Parameters["world"].SetValue(matrix3 * matrix4);
            this.tankShadow.Meshes[0].Draw();
          }
          if ((double) this.dropshipDistance <= 28000.0)
          {
            this.terrainEffect.Parameters["shipfade"].SetValue(1f - MathHelper.Clamp((float) (((double) this.dropshipDistance - 24000.0) / 4000.0), 0.2f, 1f));
            this.dropshipShade.Meshes[0].MeshParts[0].Effect = this.shadowEffect;
            Matrix translation = Matrix.CreateTranslation(new Vector3(0.0f, 20f, 0.0f));
            Matrix matrix = Matrix.CreateShadow(Vector3.Normalize(new Vector3(this.sunDir.X / 4f, (float) (-(double) Math.Abs(this.sunDir.Y) - 0.15000000596046448), this.sunDir.Z / 4f)), this.wallPlane) * Matrix.CreateTranslation(new Vector3(0.0f, 1f, 0.0f) / 100f);
            this.shadowEffect.Parameters["colorme"].SetValue(new Vector3(0.0f, 1f, 0.0f));
            this.shadowEffect.Parameters["world"].SetValue(translation * matrix);
            this.shadowEffect.Parameters["view"].SetValue(Matrix.CreateLookAt(new Vector3(0.0f, 2100f, 0.0f), Vector3.Zero, Vector3.Forward));
            this.shadowEffect.Parameters["projection"].SetValue(Matrix.CreatePerspectiveFieldOfView(0.785f, 1f, 5f, 5000f));
            this.dropshipShade.Meshes[0].Draw();
          }
          this.sc.GraphicsDevice.SetRenderTarget((RenderTarget2D) null);
          this.sc.GraphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;
          this.sc.GraphicsDevice.BlendState = BlendState.NonPremultiplied;
        }
        this.RestoreRenderStates();
        if (this.vehicleindex != 1 && this.vehicleindex != 3)
        {
          this.sc.GraphicsDevice.Clear(Color.Black);
          if ((double) this.faciltyDistance < 20000.0)
          {
            if (this.facility.rebuild)
              this.rebuildFacility();
            this.facility.Draw(this.viewMatrix, this.projectionMatrix, this.aCampos, this.sunDir, this.ambient * 0.8f, this.diffuse, new Vector3(0.8f, 0.8f, 0.8f), (RenderTarget2D) null, (Texture2D) this.resolveTarget2, this.spriteBatch, this.faciltyDistance, false);
          }
          else if ((double) this.faciltyDistance > 21000.0)
            this.facility.rebuild = true;
          this.DrawTerrain(2);
          if (this.lander.door1 != 1)
          {
            this.sc.solar1aMatrix = Matrix.CreateTranslation(0.0f, 0.0f, 0.0f);
            this.sc.modelBone_0.Transform = this.sc.solar1aMatrix * this.sc.solar1aTrans;
            this.rover.solar1 = 1;
            this.rover.directme = this.lander.directme;
            if ((double) this.rover.directme < 0.0)
              this.rover.directme += 6.28f;
            this.rover.directme = this.lander.directme - MathHelper.ToRadians(-135f);
            if ((double) this.rover.directme < 0.0)
              this.rover.directme += 6.28f;
            this.rover.position.X = this.lander.position.X;
            this.rover.position.Y = this.lander.position.Y;
            this.rover.position.Z = this.lander.position.Z;
            this.rover.facingDirection = this.rover.directme;
            this.rover.orientation = Matrix.CreateRotationY(this.rover.directme);
            this.rover.orientation.Up = this.lander.orientation.Up;
            this.rover.orientation.Right = Vector3.Cross(this.rover.orientation.Forward, this.rover.orientation.Up);
            this.rover.orientation.Right = Vector3.Normalize(this.rover.orientation.Right);
            this.rover.orientation.Forward = Vector3.Cross(this.rover.orientation.Up, this.rover.orientation.Right);
            this.rover.orientation.Forward = Vector3.Normalize(this.rover.orientation.Forward);
            this.rover.scooperON = false;
            this.rover.scoopx = 1f;
            this.rover.scoop1 = 1;
            this.rover.scooperON = false;
            this.sc.RoverEquip();
            this.rover.Draw(this.viewMatrix, this.projectionMatrix, this.sunDir);
            this.shale1.drawShaleInDumper(this.sunDir, this.ambient, this.diffuse, this.viewMatrix, this.projectionMatrix);
            this.shale2.drawShaleInDumper(this.sunDir, this.ambient, this.diffuse, this.viewMatrix, this.projectionMatrix);
            this.shale3.drawShaleInDumper(this.sunDir, this.ambient, this.diffuse, this.viewMatrix, this.projectionMatrix);
          }
          this.lander.Draw(this.viewMatrix, this.projectionMatrix, this.sunDir);
          if ((double) this.dropshipDistance < 28000.0)
            this.DrawDropship(this.dropship, this.viewMatrix, this.projectionMatrix, this.sunDir);
          this.sc.astronaut.Draw(this.viewMatrix, this.projectionMatrix, this.sunDir, this.diffuse, this.ambient * 0.9f, 1f, this.camradian);
          this.sc.GraphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;
          this.shale1.drawShale(this.sunDir, this.ambient, this.diffuse, this.viewMatrix, this.projectionMatrix);
          this.shale2.drawShale(this.sunDir, this.ambient, this.diffuse, this.viewMatrix, this.projectionMatrix);
          this.rock.drawObjects(this.sunDir, this.ambient, this.diffuse, this.viewMatrix, this.projectionMatrix);
          this.rock.drawSlabs(this.sunDir, this.ambient, this.diffuse * 1.1f, this.viewMatrix, this.projectionMatrix, this.aCampos);
          this.DrawEnv(this.darkFog, this.longProjection);
          this.DrawStars(this.stardome, this.longProjection, "straightStars");
          this.DrawBuilding(this.sc.farmBuildingspace, this.farmLocation);
          this.DrawBeacon(gameTime);
          this.streaks.SetCamera(this.viewMatrix, this.projectionMatrix);
          this.streaks.Draw(0);
          this.dust.SetCamera(this.viewMatrix, this.projectionMatrix);
          this.dust.Draw(0);
          if ((double) this.lander.shieldhit > 0.0)
            this.drawSphere();
          this.sc.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
          this.sc.GraphicsDevice.BlendState = BlendState.NonPremultiplied;
          this.sc.GraphicsDevice.RasterizerState = RasterizerState.CullNone;
          this.rock.drawFlowers(this.sunDir, new Vector3(0.5f, 0.5f, 0.5f), this.diffuse, this.viewMatrix, this.projectionMatrix);
          this.overlay.needle = this.rot;
          this.overlay.Draw(2);
        }
        else
        {
          bool set = false;
          if (this.vehicleindex == 3 && (double) this.faciltyDistance < 20000.0)
          {
            this.sc.GraphicsDevice.SetRenderTarget(this.resolveTarget1);
            set = true;
          }
          this.sc.GraphicsDevice.Clear(Color.Black);
          if ((double) this.faciltyDistance < 20000.0)
          {
            if (this.facility.rebuild)
              this.rebuildFacility();
            this.facility.Draw(this.viewMatrix, this.projectionMatrix, this.aCampos, this.sunDir, this.ambient * 0.8f, this.diffuse, new Vector3(0.8f, 0.8f, 0.8f), this.resolveTarget1, (Texture2D) this.resolveTarget2, this.spriteBatch, this.faciltyDistance, set);
          }
          else if ((double) this.faciltyDistance > 21000.0)
            this.facility.rebuild = true;
          if (Facility.inFacility)
            this.sc.astronaut.Draw(this.viewMatrix, this.projectionMatrix, new Vector3(0.0f, 1f, 0.0f), Vector3.Zero, new Vector3(1f, 1f, 1f), 1f, this.camradian);
          if (!Facility.inFacility)
          {
            if ((double) this.dropshipDistance < 28000.0)
              this.DrawDropship(this.dropship, this.viewMatrix, this.projectionMatrix, this.sunDir);
            this.DrawTerrain(1);
            this.sc.GraphicsDevice.DepthStencilState = DepthStencilState.DepthRead;
            this.DrawPrints(ref this.prints);
            this.sc.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            this.rover.Draw(this.viewMatrix, this.projectionMatrix, this.sunDir);
            this.sc.astronaut.Draw(this.viewMatrix, this.projectionMatrix, this.sunDir, this.diffuse, this.ambient * 0.9f, 1f, this.camradian);
            this.sc.GraphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;
            if ((double) this.vehicleDistance < 25000.0)
              this.lander.Draw(this.viewMatrix, this.projectionMatrix, this.sunDir);
            this.shale1.drawShale(this.sunDir, this.ambient, this.diffuse, this.viewMatrix, this.projectionMatrix);
            this.shale2.drawShale(this.sunDir, this.ambient, this.diffuse, this.viewMatrix, this.projectionMatrix);
            this.shale3.drawShale(this.sunDir, this.ambient, this.diffuse, this.viewMatrix, this.projectionMatrix);
            this.shale1.drawShaleInDumper(this.sunDir, this.ambient, this.diffuse, this.viewMatrix, this.projectionMatrix);
            this.shale2.drawShaleInDumper(this.sunDir, this.ambient, this.diffuse, this.viewMatrix, this.projectionMatrix);
            this.shale3.drawShaleInDumper(this.sunDir, this.ambient, this.diffuse, this.viewMatrix, this.projectionMatrix);
            this.rock.drawObjects(this.sunDir, this.ambient, this.diffuse, this.viewMatrix, this.projectionMatrix);
            this.rock.drawSlabs(this.sunDir, this.ambient, this.diffuse * 1.1f, this.viewMatrix, this.projectionMatrix, this.aCampos);
            this.rock.drawBrokenSides(this.sunDir, this.ambient * 0.7f, this.diffuse, this.viewMatrix, this.projectionMatrix);
            this.rock.drawRockRubble(this.sunDir, this.ambient * 0.7f, this.diffuse, this.viewMatrix, this.projectionMatrix);
            this.DrawEnv(this.darkFog, this.longProjection);
            this.DrawStars(this.stardome, this.longProjection, "straightStars");
            this.DrawBuilding(this.sc.farmBuildingspace, this.farmLocation);
            this.DrawBeacon(gameTime);
            this.skids.SetCamera(this.viewMatrix, this.projectionMatrix);
            this.skids.Draw(0);
            this.overlay.needle = this.myrotter;
            this.sc.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            this.sc.GraphicsDevice.BlendState = BlendState.NonPremultiplied;
            this.sc.GraphicsDevice.RasterizerState = RasterizerState.CullNone;
            this.rock.drawFlowers(this.sunDir, new Vector3(0.5f, 0.5f, 0.5f), this.diffuse, this.viewMatrix, this.projectionMatrix);
          }
          if (Facility.inFacility)
            this.DrawStars(this.stardome, this.longProjection, "straightStars");
          if (this.vehicleindex == 1)
          {
            this.overlay.Draw(1);
          }
          else
          {
            if ((double) this.faciltyDistance < 20000.0)
            {
              this.sc.GraphicsDevice.SetRenderTarget((RenderTarget2D) null);
              this.blurEffect.CurrentTechnique = this.blurEffect.Techniques["spacewalk"];
              this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Opaque, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, this.blurEffect);
              this.spriteBatch.Draw((Texture2D) this.resolveTarget1, new Rectangle(0, 0, this.sc.GraphicsDevice.Viewport.Width, this.sc.GraphicsDevice.Viewport.Height), Color.White);
              this.spriteBatch.End();
            }
            if ((double) this.sc.vehiclelerp == 1.0)
              this.overlay.Draw(3);
          }
        }
        this.overlay.View = this.viewMatrix;
        this.overlay.Projection = this.projectionMatrix;
        this.overlay.LightDirection = this.sunDir;
      }
      this.DrawOptions();
      if (!this.IsActive)
        this.sc.FadeBackBufferToBlack(160);
      this.isDrawing = false;
    }

    private void DrawOptions()
    {
      this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) null, this.sc.ScaleMatrix1);
      bool flag = true;
      if (this.editcam)
      {
        flag = false;
        if (this.vehicleindex == 1)
        {
          this.spriteBatch.Draw(this.sc.camedit, this.menuposition, new Rectangle?(this.rovercamedit), Color.White);
          if (this.sc.roverrotlock == 1)
            this.spriteBatch.Draw(this.sc.camedit, this.menuposition + this.pointbox1[0], new Rectangle?(this.buttonhalf), Color.White);
          if (this.sc.roverrotlock == 2)
            this.spriteBatch.Draw(this.sc.camedit, this.menuposition + this.pointbox1[0], new Rectangle?(this.buttonfill), Color.White);
          if (this.sc.roverhitelock == 1)
            this.spriteBatch.Draw(this.sc.camedit, this.menuposition + this.pointbox1[1], new Rectangle?(this.buttonhalf), Color.White);
          if (this.sc.roverhitelock == 2)
            this.spriteBatch.Draw(this.sc.camedit, this.menuposition + this.pointbox1[1], new Rectangle?(this.buttonfill), Color.White);
          if (this.sc.space_rinvertX == -1)
            this.spriteBatch.Draw(this.sc.camedit, this.menuposition + this.pointbox1[2], new Rectangle?(this.buttonfill), Color.White);
          if (this.sc.space_rinvertY == -1)
            this.spriteBatch.Draw(this.sc.camedit, this.menuposition + this.pointbox1[3], new Rectangle?(this.buttonfill), Color.White);
          if (this.camadjust)
            this.spriteBatch.Draw(this.sc.camedit, this.adj + new Vector2(-9f, -9f), new Rectangle?(this.buttonchoice), Color.White);
        }
        if (this.vehicleindex == 2)
        {
          this.spriteBatch.Draw(this.sc.camedit, this.menuposition, new Rectangle?(this.landercamedit), Color.White);
          if (this.sc.landerrotlock == 1)
            this.spriteBatch.Draw(this.sc.camedit, this.menuposition + this.pointbox1[0], new Rectangle?(this.buttonhalf), Color.White);
          if (this.sc.landerrotlock == 2)
            this.spriteBatch.Draw(this.sc.camedit, this.menuposition + this.pointbox1[0], new Rectangle?(this.buttonfill), Color.White);
          if (this.sc.landerhitelock == 1)
            this.spriteBatch.Draw(this.sc.camedit, this.menuposition + this.pointbox1[1], new Rectangle?(this.buttonhalf), Color.White);
          if (this.sc.landerhitelock == 2)
            this.spriteBatch.Draw(this.sc.camedit, this.menuposition + this.pointbox1[1], new Rectangle?(this.buttonfill), Color.White);
          if (this.sc.space_invertX == -1)
            this.spriteBatch.Draw(this.sc.camedit, this.menuposition + this.pointbox1[2], new Rectangle?(this.buttonfill), Color.White);
          if (this.sc.space_invertY == -1)
            this.spriteBatch.Draw(this.sc.camedit, this.menuposition + this.pointbox1[3], new Rectangle?(this.buttonfill), Color.White);
          if (this.camadjust)
            this.spriteBatch.Draw(this.sc.camedit, this.adj + new Vector2(-9f, -9f), new Rectangle?(this.buttonchoice), Color.White);
        }
      }
      if (this.refineShale > 0 || this.refineRuby > 0 || this.refineBlue > 0)
      {
        flag = false;
        float y = this.typer.MeasureString("REFINE").Y;
        this.spriteBatch.DrawString(this.typer, "* REFINING *", new Vector2(90f, 180f), new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        this.spriteBatch.DrawString(this.typer, "____________", new Vector2(90f, 185f), new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        this.spriteBatch.DrawString(this.typer, "SHALE----> " + this.refineShale.ToString(), new Vector2(90f, 190f + y), new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        if (this.refineShale <= 0)
          this.spriteBatch.DrawString(this.typer, "RUBIES---> " + this.refineRuby.ToString(), new Vector2(90f, 190f + y + y), new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        if (this.refineShale <= 0 && this.refineRuby <= 0)
          this.spriteBatch.DrawString(this.typer, "ORNITE---> " + this.refineBlue.ToString(), new Vector2(90f, 190f + y + y + y), new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
      }
      if (flag)
      {
        this.timer += 0.0166f;
        --this.typewritercount;
        if ((double) this.typewriterblank == 500.0)
        {
          if (this.textflag == 0)
          {
            this.text = this.objectiveData[this.objIndex];
            this.textflag = 1;
          }
          if ((double) this.typewritercount <= 0.0)
            ++this.typeposition;
          if ((double) this.typeposition < (double) this.text.Length && (double) this.typewritercount <= 0.0)
          {
            this.pop1.Play(0.8f * this.sc.mv, (float) this.random.Next(-70, 90) / 100f, 0.0f);
            this.typewritercount = (float) this.typewriterdelay;
          }
          if ((double) this.typeposition > (double) this.text.Length)
          {
            this.typeposition = (float) this.text.Length;
            --this.typewriterwait;
          }
          float num1 = (float) (Math.Sin((double) this.timer * 30.0) * 15.0) + 240f;
          if ((double) this.typewriterwait < 240.0)
            num1 = this.typewriterwait + (float) (Math.Sin((double) this.timer * 30.0) * 15.0);
          float num2 = num1 / 245f;
          string str = "";
          if ((double) this.typeposition < (double) this.text.Length)
            str = "|";
          this.spriteBatch.DrawString(this.typer, this.text.Substring(0, (int) this.typeposition) + str, new Vector2(90f, this.typevertical), new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue) * num2);
          if ((int) this.typeposition == this.text.Length)
            this.typevertical -= (float) (0.0099999997764825821 + (double) this.random.Next(1, 200) / 1000.0);
          if ((double) this.typewriterwait <= 0.0)
          {
            this.textflag = 0;
            this.typewriterblank = 0.0f;
            this.typewriterwait = 480f;
            this.typeposition = 0.0f;
            this.typevertical = (float) this.random.Next(100, 150);
            this.typewriterdelay = this.random.Next(2, 7);
          }
        }
      }
      if (this.memoTimer > 0)
      {
        float num = MathHelper.Clamp((float) this.memoTimer / 30f, 0.0f, 1f);
        Vector2 position = new Vector2((float) Math.Sin((double) this.sc.myTimer / 15.0) * 26f, (float) Math.Cos((double) this.sc.myTimer / 15.0) * 23f) + new Vector2(135f, 390f);
        if (this.memoIcon > 0)
        {
          if (this.memoIcon == 1)
          {
            position.X += 10f;
            this.spriteBatch.Draw(this.sc.overlay, position + new Vector2(-50f, -22f), new Rectangle?(this.rect_choice[this.memoIcon]), Color.White);
          }
          else if (this.memoIcon == 6)
          {
            position.X += 10f;
            this.spriteBatch.Draw(this.sc.overlay, position + new Vector2(-50f, 10f), new Rectangle?(this.rect_choice[this.memoIcon]), Color.White);
          }
          else if (this.memoIcon == 7)
          {
            position.X += 420f;
            position.Y += 170f;
          }
          else
            this.spriteBatch.Draw(this.sc.overlay, position + new Vector2(-45f, 5f), new Rectangle?(this.rect_choice[this.memoIcon]), Color.White);
        }
        this.spriteBatch.DrawString(this.ammoMedium2, GameplayScreen.memo, new Vector2(-4f, 4f) + position, Color.Black * num);
        this.spriteBatch.DrawString(this.ammoMedium2, GameplayScreen.memo, position, Color.White * num);
        --this.memoTimer;
      }
      float y1 = 570f;
      Vector2 position1 = new Vector2((float) Math.Sin((double) this.sc.myTimer / 20.0) * 10f, (float) Math.Cos((double) this.sc.myTimer / 20.0) * 10f) + new Vector2(660f, y1) - this.ammoMedium[this.fontindex].MeasureString(GameplayScreen.atDoorBuild) / 2f;
      if (this.nearAstro && flag && this.sc.astronaut.chosen != -1 && this.sc.astronaut.man.dupe[this.sc.astronaut.chosen].emo != astroDupe.emotion.trucking && this.sc.astronaut.man.dupe[this.sc.astronaut.chosen].emo != astroDupe.emotion.scaredintruck)
      {
        if (this.sc.astronaut.seats.Count > 0)
        {
          if (this.sc.usingMouse)
          {
            Vector2 position2 = new Vector2(position1.X - this.ammoMedium[this.fontindex].MeasureString(this.sc.myXkey + "  ").X, position1.Y);
            this.spriteBatch.Draw(this.sc.overlay, new Rectangle((int) position2.X - 8, (int) position2.Y + 2, (int) this.ammoMedium[this.fontindex].MeasureString(this.sc.myXkey + "  ").X, (int) this.ammoMedium[this.fontindex].MeasureString(this.sc.x_key.ToString()).Y), new Rectangle?(this.rect_Blue), Color.White);
            this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], this.sc.myXkey, position2, Color.White);
          }
          else
            this.spriteBatch.Draw(this.sc.overlay, position1 + new Vector2(-30f, 7f), new Rectangle?(this.rect_Xbutton), Color.White);
        }
        else
          this.spriteBatch.Draw(this.sc.overlay, position1 + new Vector2(-30f, 8f), new Rectangle?(this.rect_Lock), Color.White);
        if (this.sc.astronaut.man.dupe[this.sc.astronaut.chosen].emo == astroDupe.emotion.stranded)
        {
          if (this.sc.astronaut.seats.Count > 0)
          {
            this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], " press to rescue astronaut", position1 + new Vector2(-2f, 2f), Color.Black);
            this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], " press to rescue astronaut", position1, Color.White);
          }
          else
          {
            this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], " rover full can't rescue", position1 + new Vector2(-2f, 2f), Color.Black);
            this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], " rover full can't rescue", position1, Color.White);
          }
        }
        else if (this.sc.astronaut.man.dupe[this.sc.astronaut.chosen].emo == astroDupe.emotion.safe)
        {
          if (this.sc.astronaut.seats.Count > 0)
          {
            this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], " press to recruit !", position1 + new Vector2(-2f, 2f), Color.Black);
            this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], " press to recruit !", position1, Color.White);
          }
          else
          {
            this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], " rover full can't recruit", position1 + new Vector2(-2f, 2f), Color.Black);
            this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], " rover full can't recruit", position1, Color.White);
          }
        }
        else if (this.sc.astronaut.man.dupe[this.sc.astronaut.chosen].emo == astroDupe.emotion.underground)
        {
          this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], " this astronaut is upset", position1 + new Vector2(-2f, 2f), Color.Black);
          this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], " this astronaut is upset", position1, Color.White);
        }
        flag = false;
      }
      if (this.nearFlower && flag && this.rock.chosen != -1)
      {
        if (this.rock.flowerInst[this.rock.chosen].stateFlag == 15)
        {
          if (this.sc.usingMouse)
          {
            Vector2 position3 = new Vector2(position1.X - this.ammoMedium[this.fontindex].MeasureString(this.sc.myXkey + "  ").X, position1.Y);
            this.spriteBatch.Draw(this.sc.overlay, new Rectangle((int) position3.X - 8, (int) position3.Y + 2, (int) this.ammoMedium[this.fontindex].MeasureString(this.sc.myXkey + "  ").X, (int) this.ammoMedium[this.fontindex].MeasureString(this.sc.x_key.ToString()).Y), new Rectangle?(this.rect_Blue), Color.White);
            this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], this.sc.myXkey, position3, Color.White);
          }
          else
            this.spriteBatch.Draw(this.sc.overlay, position1 + new Vector2(-30f, 7f), new Rectangle?(this.rect_Xbutton), Color.White);
          if (objDupe.flowersaved == 0)
          {
            this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], " what is this thing?", position1 + new Vector2(-2f, 2f), Color.Black);
            this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], " what is this thing?", position1, Color.White);
          }
          if (objDupe.flowersaved == 1)
          {
            this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], " press to love this flower", position1 + new Vector2(-2f, 2f), Color.Black);
            this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], " press to love this flower", position1, Color.White);
          }
          if (objDupe.flowersaved >= 2)
          {
            this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], " wait, do you want this?", position1 + new Vector2(-2f, 2f), Color.Black);
            this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], " wait, do you want this?", position1, Color.White);
          }
        }
        if (this.rock.flowerInst[this.rock.chosen].stateFlag == 10)
        {
          this.spriteBatch.Draw(this.sc.overlay, position1 + new Vector2(-30f, 7f), new Rectangle?(this.rect_Heart), Color.White);
          if (objDupe.flowersaved <= 1)
          {
            this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], "   Love is Love " + objDupe.flowersaved.ToString() + " of 3", position1 + new Vector2(-2f, 2f), Color.Black);
            this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], "   Love is Love " + objDupe.flowersaved.ToString() + " of 3", position1, Color.White);
          }
          if (objDupe.flowersaved == 2)
          {
            this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], "   You Have Two Loves " + objDupe.flowersaved.ToString() + " of 3", position1 + new Vector2(-2f, 2f), Color.Black);
            this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], "   You Have Two Loves " + objDupe.flowersaved.ToString() + " of 3", position1, Color.White);
          }
          if (objDupe.flowersaved > 2)
          {
            this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], "   The Event Has Begun", position1 + new Vector2(-2f, 2f), Color.DarkRed);
            this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], "   The Event Has Begun", position1, Color.White);
          }
        }
        flag = false;
      }
      if (this.humanonramp > 0 && flag)
      {
        if (this.humanonramp >= 3 && !this.lander.radioFixed)
        {
          if (this.sc.usingMouse)
          {
            Vector2 position4 = new Vector2(position1.X - this.ammoMedium[this.fontindex].MeasureString(this.sc.myXkey + "  ").X, position1.Y);
            this.spriteBatch.Draw(this.sc.overlay, new Rectangle((int) position4.X - 8, (int) position4.Y + 2, (int) this.ammoMedium[this.fontindex].MeasureString(this.sc.myXkey + "  ").X, (int) this.ammoMedium[this.fontindex].MeasureString(this.sc.x_key.ToString()).Y), new Rectangle?(this.rect_Blue), Color.White);
            this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], this.sc.myXkey, position4, Color.White);
          }
          else
            this.spriteBatch.Draw(this.sc.overlay, position1 + new Vector2(-30f, 7f), new Rectangle?(this.rect_Xbutton), Color.White);
          this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], " press to repair radio", position1 + new Vector2(-2f, 2f), Color.Black);
          this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], " press to repair radio", position1, Color.White);
        }
        else
        {
          this.spriteBatch.Draw(this.sc.overlay, position1 + new Vector2(-30f, 5f), new Rectangle?(this.rect_Exclaim2), Color.White);
          this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], "  drive rover up ramp", position1 + new Vector2(-2f, 2f), Color.Black);
          this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], "  drive rover up ramp", position1, Color.White);
        }
        flag = false;
      }
      if (this.atRover && flag)
      {
        if (this.sc.usingMouse)
        {
          Vector2 position5 = new Vector2(position1.X - this.ammoMedium[this.fontindex].MeasureString(this.sc.myXkey + "  ").X, position1.Y);
          this.spriteBatch.Draw(this.sc.overlay, new Rectangle((int) position5.X - 8, (int) position5.Y + 2, (int) this.ammoMedium[this.fontindex].MeasureString(this.sc.myXkey + "  ").X, (int) this.ammoMedium[this.fontindex].MeasureString(this.sc.x_key.ToString()).Y), new Rectangle?(this.rect_Blue), Color.White);
          this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], this.sc.myXkey, position5, Color.White);
        }
        else
          this.spriteBatch.Draw(this.sc.overlay, position1 + new Vector2(-30f, 7f), new Rectangle?(this.rect_Abutton), Color.White);
        this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], " press to enter rover", position1 + new Vector2(-2f, 2f), Color.Black);
        this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], " press to enter rover", position1, Color.White);
        flag = false;
      }
      if (Facility.atSwitch && flag)
      {
        if (this.sc.usingMouse)
        {
          Vector2 position6 = new Vector2(position1.X - this.ammoMedium[this.fontindex].MeasureString(this.sc.myXkey + "  ").X, position1.Y);
          this.spriteBatch.Draw(this.sc.overlay, new Rectangle((int) position6.X - 8, (int) position6.Y + 2, (int) this.ammoMedium[this.fontindex].MeasureString(this.sc.myXkey + "  ").X, (int) this.ammoMedium[this.fontindex].MeasureString(this.sc.x_key.ToString()).Y), new Rectangle?(this.rect_Blue), Color.White);
          this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], this.sc.myXkey, position6, Color.White);
        }
        else
          this.spriteBatch.Draw(this.sc.overlay, position1 + new Vector2(-30f, 7f), new Rectangle?(this.rect_Abutton), Color.White);
        this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], " press for c.r.a.n.e", position1 + new Vector2(-2f, 2f), Color.Black);
        this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], " press for c.r.a.n.e", position1, Color.White);
        flag = false;
      }
      if (Facility.atSwitch2 && flag)
      {
        if (this.sc.usingMouse)
        {
          Vector2 position7 = new Vector2(position1.X - this.ammoMedium[this.fontindex].MeasureString(this.sc.myXkey + "  ").X, position1.Y);
          this.spriteBatch.Draw(this.sc.overlay, new Rectangle((int) position7.X - 8, (int) position7.Y + 2, (int) this.ammoMedium[this.fontindex].MeasureString(this.sc.myXkey + "  ").X, (int) this.ammoMedium[this.fontindex].MeasureString(this.sc.x_key.ToString()).Y), new Rectangle?(this.rect_Blue), Color.White);
          this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], this.sc.myXkey, position7, Color.White);
        }
        else
          this.spriteBatch.Draw(this.sc.overlay, position1 + new Vector2(-30f, 7f), new Rectangle?(this.rect_Abutton), Color.White);
        this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], " press to create worker", position1 + new Vector2(-2f, 2f), Color.Black);
        this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], " press to create worker", position1, Color.White);
        flag = false;
      }
      if (Facility.atMain && flag)
      {
        if (this.sc.usingMouse)
        {
          Vector2 position8 = new Vector2(position1.X - this.ammoMedium[this.fontindex].MeasureString(this.sc.myXkey + "  ").X, position1.Y);
          this.spriteBatch.Draw(this.sc.overlay, new Rectangle((int) position8.X - 8, (int) position8.Y + 2, (int) this.ammoMedium[this.fontindex].MeasureString(this.sc.myXkey + "  ").X, (int) this.ammoMedium[this.fontindex].MeasureString(this.sc.x_key.ToString()).Y), new Rectangle?(this.rect_Blue), Color.White);
          this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], this.sc.myXkey, position8, Color.White);
        }
        else
          this.spriteBatch.Draw(this.sc.overlay, position1 + new Vector2(-30f, 7f), new Rectangle?(this.rect_Abutton), Color.White);
        this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], " press to open", position1 + new Vector2(-2f, 2f), Color.Black);
        this.spriteBatch.DrawString(this.ammoMedium[this.fontindex], " press to open", position1, Color.White);
      }
      this.spriteBatch.End();
    }

    private void DrawBuilding(Model model, Vector3 pos)
    {
      if ((double) Vector3.Distance(this.aCampos, this.farmLocation) > 29000.0)
        return;
      Matrix translation1 = Matrix.CreateTranslation(pos);
      Vector3 zero = Vector3.Zero;
      Matrix identity = Matrix.Identity;
      model.Meshes[0].MeshParts[0].Effect = this.buildingEffect;
      this.sc.dayTime = "pm";
      if (this.sc.dayTime == "pm")
      {
        this.buildingEffect.Parameters["darkness"].SetValue(this.ambient);
        this.buildingEffect.Parameters["mydiffuse"].SetValue(this.diffuse);
        this.buildingEffect.Parameters["proj"].SetValue(this.projectionMatrix);
      }
      this.buildingEffect.Parameters["moon"].SetValue(this.sunDir);
      this.buildingEffect.Parameters["depth"].SetValue(5000);
      this.buildingEffect.Parameters["pulse"].SetValue(1);
      this.buildingEffect.Parameters["gDiffuse"].SetValue((Texture) this.sc.crosshair);
      this.buildingEffect.Parameters["lightPos1"].SetValue(this.aCampos);
      this.buildingEffect.Parameters["world"].SetValue(translation1);
      this.buildingEffect.Parameters["projectorView"].SetValue(translation1 * identity);
      this.buildingEffect.Parameters["WorldViewProj"].SetValue(translation1 * this.viewMatrix * this.projectionMatrix);
      this.buildingEffect.CurrentTechnique = this.buildingEffect.Techniques[1];
      model.Meshes[0].Draw();
      model.Meshes[1].MeshParts[0].Effect = this.buildingEffect;
      Matrix translation2 = Matrix.CreateTranslation(688.413f, 86.649f, 1619.653f + zero.Z);
      this.buildingEffect.Parameters["world"].SetValue(translation1 * translation2);
      this.buildingEffect.Parameters["projectorView"].SetValue(translation1 * translation2 * identity);
      this.buildingEffect.Parameters["WorldViewProj"].SetValue(translation1 * translation2 * this.viewMatrix * this.projectionMatrix);
      if (this.sc.dayTime == "pm")
        this.buildingEffect.CurrentTechnique = this.buildingEffect.Techniques[0];
      model.Meshes[1].Draw();
    }

    public void DrawStars(Model model, Matrix proj, string tech)
    {
      if (this.overlay.scopeMode)
        return;
      float num = MathHelper.Clamp((float) (((double) this.sunDir.Y + 0.0) / 0.40000000596046448), 0.0f, 1f);
      Vector3 vector3 = new Vector3(1f, 1f, 1f) * (1f - num) + new Vector3(0.9f, 1.1f, 1.5f) * num;
      model.Meshes[0].MeshParts[0].Effect = this.starEffect;
      Matrix matrix = Matrix.CreateRotationX(1.335f) * Matrix.CreateRotationZ(-1.735f) * this.starRot * Matrix.CreateScale(2f) * Matrix.CreateTranslation(this.aCampos);
      this.starEffect.Parameters["bright"].SetValue(vector3);
      this.starEffect.Parameters["world"].SetValue(matrix);
      this.starEffect.Parameters["view"].SetValue(this.viewMatrix);
      this.starEffect.Parameters["projection"].SetValue(proj);
      this.starEffect.CurrentTechnique = this.starEffect.Techniques[tech];
      model.Meshes[0].Draw();
    }

    private void DrawEnv(Model model, Matrix proj)
    {
      if (this.overlay.scopeMode)
        return;
      foreach (BasicEffect effect in model.Meshes[0].Effects)
      {
        effect.Alpha = 1f;
        effect.LightingEnabled = false;
        effect.View = this.viewMatrix;
        effect.Projection = proj;
        effect.PreferPerPixelLighting = false;
        effect.World = Matrix.CreateScale(1.5f) * Matrix.CreateTranslation(this.aCampos.X, this.aCampos.Y + 1000f, this.aCampos.Z);
      }
      model.Meshes[0].Draw();
    }

    private void DrawBeacon(GameTime gm)
    {
      Vector3 vector3_1 = new Vector3(0.5f, 0.5f, 0.5f);
      Vector3 vector3_2 = new Vector3(1f, 1f, 1f);
      this.chosenBouy[0] = this.overlay.bouy1;
      this.chosenBouy[1] = this.overlay.bouy2;
      this.chosenBouy[2] = this.overlay.bouy3;
      for (int index = 0; index < 3; ++index)
      {
        int num1 = this.pulseBouy[index];
        double num2 = (double) Vector3.Distance(this.aCampos, this.chosenBouy[index]) / 3300.0;
        Vector3 vector3_3 = this.colorBouy[index];
        Matrix matrix = Matrix.CreateScale(1.2f) * Matrix.CreateTranslation(this.chosenBouy[index]);
        if (this.chosenBouy[index] != Vector3.Zero)
        {
          foreach (BasicEffect effect in this.beacon.Meshes[1].Effects)
          {
            effect.LightingEnabled = true;
            effect.AmbientLightColor = vector3_1;
            effect.DiffuseColor = vector3_2;
            effect.View = this.viewMatrix;
            effect.Projection = this.projectionMatrix;
            effect.World = matrix;
          }
          this.beacon.Meshes[1].Draw();
          foreach (BasicEffect effect in this.beacon.Meshes[2].Effects)
          {
            Vector3 vector3_4 = vector3_3 / (float) (1.2000000476837158 + Math.Sin(gm.TotalGameTime.TotalMilliseconds / (double) num1) * 0.5);
            effect.LightingEnabled = true;
            effect.AmbientLightColor = vector3_4;
            effect.DiffuseColor = vector3_4;
            effect.View = this.viewMatrix;
            effect.Projection = this.projectionMatrix;
            effect.World = matrix;
          }
          this.beacon.Meshes[2].Draw();
        }
      }
      this.sc.GraphicsDevice.DepthStencilState = DepthStencilState.DepthRead;
      this.sc.GraphicsDevice.BlendState = BlendState.Additive;
      this.sc.GraphicsDevice.RasterizerState = RasterizerState.CullNone;
      for (int index = 0; index < 3; ++index)
      {
        int num3 = this.pulseBouy[index];
        Vector3 objectPosition = new Vector3(this.chosenBouy[index].X, this.chosenBouy[index].Y + 57f, this.chosenBouy[index].Z);
        float num4 = Vector3.Distance(this.aCampos, this.chosenBouy[index]) / 3300f;
        Vector3 vector3_5 = this.colorBouy[index];
        if (this.chosenBouy[index] != Vector3.Zero)
        {
          foreach (BasicEffect effect in this.beacon.Meshes[0].Effects)
          {
            Vector3 vector3_6 = vector3_5 / (float) (5.6999998092651367 + Math.Sin(gm.TotalGameTime.TotalMilliseconds / (double) num3) * 5.0);
            Vector3 vector3_7 = vector3_6;
            Vector3 vector3_8 = vector3_6;
            Matrix billboard = Matrix.CreateBillboard(objectPosition, this.aCampos, this.projectionMatrix.Up, new Vector3?(this.projectionMatrix.Forward));
            Matrix matrix = Matrix.CreateScale(0.6f + MathHelper.Clamp(num4, 0.0f, 4f)) * billboard;
            effect.LightingEnabled = true;
            effect.AmbientLightColor = vector3_7;
            effect.DiffuseColor = vector3_8;
            effect.View = this.viewMatrix;
            effect.Projection = this.projectionMatrix;
            effect.World = matrix;
          }
          this.beacon.Meshes[0].Draw();
        }
      }
    }

    private void DrawGalaxy(Matrix proj)
    {
      foreach (BasicEffect effect in this.galaxy.Meshes[0].Effects)
      {
        Matrix matrix = Matrix.CreateFromYawPitchRoll(-1.77f, -0.2f, 0.0f) * this.starRot * Matrix.CreateScale(4.8f) * Matrix.CreateTranslation(this.aCampos);
        effect.LightingEnabled = true;
        effect.AmbientLightColor = new Vector3(0.7f, 0.7f, 0.7f);
        effect.DiffuseColor = new Vector3(0.7f, 0.7f, 0.7f);
        effect.View = this.viewMatrix;
        effect.Projection = proj;
        effect.World = matrix;
      }
      this.galaxy.Meshes[0].Draw();
    }

    private void DrawTerrain(int ch)
    {
      float num1 = MathHelper.Clamp((float) (-((double) this.sunDir.Y - 0.10000000149011612) / 0.10000000149011612), 0.0f, 0.99f);
      float num2 = MathHelper.Clamp((float) (-((double) this.sunDir.Y - 0.20000000298023224) / 0.10000000149011612), 0.0f, 0.99f);
      float num3 = MathHelper.Clamp((float) (((double) this.sunDir.Y - 0.25) / 0.10000000149011612), 0.0f, 0.99f);
      this.ambient = this.ambDay * num1 + this.ambSol * (1f - num1) * num2 + this.ambSet * (1f - num2) * (1f - num3) + this.ambNite * num3;
      this.diffuse = this.difDay * num1 + this.difSol * (1f - num1) * num2 + this.difSet * (1f - num2) * (1f - num3) + this.difNite * num3;
      this.lander.amb = this.ambient;
      this.lander.diffu = this.diffuse;
      this.rover.amb = this.ambient;
      this.rover.diffu = this.diffuse;
      Effect terrainEffect = this.terrainEffect;
      if (this.vehicleindex == 3)
      {
        terrainEffect.Parameters["far"].SetValue(1f);
        terrainEffect.Parameters["near"].SetValue(5f);
      }
      else
      {
        terrainEffect.Parameters["far"].SetValue(1f);
        terrainEffect.Parameters["near"].SetValue(5f);
      }
      if (ch == 2)
      {
        if ((double) this.lander.lscale > 0.0)
        {
          terrainEffect.CurrentTechnique = this.terrainEffect.Techniques["terrainShadowsLanderDropship"];
          if ((double) this.dropshipDistance > 28000.0)
            terrainEffect.CurrentTechnique = this.terrainEffect.Techniques["terrainShadowsLander"];
        }
        else
        {
          terrainEffect.CurrentTechnique = this.terrainEffect.Techniques["terrainShadowsLanderDropshipnoflame"];
          if ((double) this.dropshipDistance > 28000.0)
            terrainEffect.CurrentTechnique = this.terrainEffect.Techniques["terrainShadowsLandernoflame"];
        }
        terrainEffect.Parameters["center"].SetValue(this.lander.position);
        if ((double) this.lander.lander2ground > 2500.0)
          terrainEffect.Parameters["xLanderFlame"].SetValue(0);
        else if (this.overlay.fuelAMT <= 4)
          terrainEffect.Parameters["xLanderFlame"].SetValue(0.2f);
        else
          terrainEffect.Parameters["xLanderFlame"].SetValue(this.lander.lscale);
        terrainEffect.Parameters["xLander2ground"].SetValue(this.lander.lander2ground);
        terrainEffect.Parameters["hitefade"].SetValue(1f - MathHelper.Clamp((float) (((double) this.lander.lander2ground - 700.0) / 2000.0), 0.0f, 1f));
        terrainEffect.Parameters["xGround"].SetValue(this.lander.ground);
      }
      else
      {
        terrainEffect.CurrentTechnique = this.terrainEffect.Techniques["terrainShadows3"];
        if ((double) this.dropshipDistance > 28000.0)
          terrainEffect.CurrentTechnique = (double) this.vehicleDistance <= 5000.0 ? this.terrainEffect.Techniques["terrainShadowsRoverLander"] : this.terrainEffect.Techniques["terrainShadowsRover"];
        terrainEffect.Parameters["center"].SetValue(this.rover.position);
        terrainEffect.Parameters["xLanderFlame"].SetValue(0);
      }
      int num4 = this.unit * this.gridscale;
      float num5 = 36.125f * (float) this.gridscale;
      float num6 = (float) (this.lander.altitude - 155);
      Vector2 vector2 = new Vector2((float) ((double) this.lander.position.X - 765.0 + (double) num6 * (double) this.sunDir.X / 2.0), (float) ((double) this.lander.position.Z - 754.0 + (double) num6 * (double) this.sunDir.Z / 2.0));
      terrainEffect.Parameters["shadoffset1"].SetValue(new Vector2(vector2.X + 765f, vector2.Y + 754f));
      vector2.X = (float) ((double) vector2.X % 43350.0 + 1.5 * (double) num4) % (float) num4;
      vector2.Y = (float) ((double) vector2.Y % 43350.0 + 1.5 * (double) num4) % (float) num4;
      terrainEffect.Parameters["landerCoord"].SetValue(new Vector2(vector2.X / num5, vector2.Y / num5));
      vector2 = new Vector2((float) ((double) this.rover.position.X + 62.0 + ((double) this.rover.position.Y - (double) this.rover.gndPosition.Y) * (double) this.sunDir.X / 2.0), (float) ((double) this.rover.position.Z + 55.0 + ((double) this.rover.position.Y - (double) this.rover.gndPosition.Y) * (double) this.sunDir.Z / 2.0));
      terrainEffect.Parameters["shadoffset2"].SetValue(new Vector2(vector2.X + 62f, vector2.Y + 62f));
      vector2.X = (float) ((double) vector2.X % 43350.0 + 1.5 * (double) num4) % (float) num4;
      vector2.Y = (float) ((double) vector2.Y % 43350.0 + 1.5 * (double) num4) % (float) num4;
      terrainEffect.Parameters["roverCoord"].SetValue(new Vector2(vector2.X / num5, vector2.Y / num5));
      vector2 = new Vector2(this.vector3_0.X - 5670f, this.vector3_0.Z - 5140f);
      vector2.X = (float) ((double) vector2.X % 43350.0 + 1.5 * (double) num4) % (float) num4;
      vector2.Y = (float) ((double) vector2.Y % 43350.0 + 1.5 * (double) num4) % (float) num4;
      terrainEffect.Parameters["dropCoord"].SetValue(new Vector2(vector2.X / num5, vector2.Y / num5));
      terrainEffect.Parameters["dropship"].SetValue(new Vector2(this.vector3_0.X, this.vector3_0.Z));
      terrainEffect.Parameters["fade"].SetValue(num2);
      terrainEffect.Parameters["planet"].SetValue(this.tinting[this.sc.planet]);
      terrainEffect.Parameters["xAmbient"].SetValue(this.ambient * 0.4f);
      terrainEffect.Parameters["xDiffuse"].SetValue(this.diffuse * 1f);
      terrainEffect.Parameters["xView"].SetValue(this.viewMatrix);
      terrainEffect.Parameters["xProjection"].SetValue(this.projectionMatrix);
      terrainEffect.Parameters["xCamPos"].SetValue(this.aCampos);
      terrainEffect.Parameters["xLightDirection"].SetValue(this.sunDir);
      terrainEffect.Parameters["xTextureX"].SetValue((Texture) this.shadowTarget);
      terrainEffect.CurrentTechnique.Passes[0].Apply();
      this.sc.GraphicsDevice.SetVertexBuffer(this.tmake.terrainVertexBuffer);
      this.sc.GraphicsDevice.Indices = this.tmake.terrainIndexBuffer;
      this.sc.GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, this.tmake.terrainVertexBuffer.VertexCount, 0, this.tmake.terrainIndexBuffer.IndexCount / 3);
    }

    private void drawSphere()
    {
      this.sphere.Meshes[0].MeshParts[0].Effect = this.simpEffect;
      Matrix translation = Matrix.CreateTranslation(new Vector3(Facility.offset.X + 2200f, Facility.offset.Y + 360f, Facility.offset.Z + 4050f));
      this.simpEffect.CurrentTechnique = this.simpEffect.Techniques["shield"];
      this.simpEffect.Parameters["val"].SetValue(this.lander.shieldhit / 60f);
      this.simpEffect.Parameters["campos"].SetValue(this.aCampos);
      this.simpEffect.Parameters["modelTexture"].SetValue((Texture) this.shieldTexture);
      this.simpEffect.Parameters["world"].SetValue(translation);
      this.simpEffect.Parameters["view"].SetValue(this.viewMatrix);
      this.simpEffect.Parameters["projection"].SetValue(this.projectionMatrix);
      this.simpEffect.CurrentTechnique.Passes[0].Apply();
      this.sphere.Meshes[0].Draw();
    }

    public void DrawDropship(
      Model model,
      Matrix viewMatrix,
      Matrix projectionMatrix,
      Vector3 sundir)
    {
      float num = 1f - MathHelper.Clamp((float) (((double) this.dropshipDistance - 24000.0) / 4000.0), 0.0f, 1f);
      if ((double) num <= 0.0)
        return;
      Matrix matrix = Matrix.CreateScale(5f) * Matrix.CreateTranslation(this.vector3_0);
      model.Meshes[0].MeshParts[0].Effect = this.mybasic;
      this.mybasic.Parameters["inc"].SetValue((float) (this.myframe / 20 % 4) * 0.25f);
      this.mybasic.Parameters["diffuse"].SetValue(1.2f * this.diffuse * num);
      this.mybasic.Parameters["amb"].SetValue(0.5f * this.ambient * num);
      this.mybasic.Parameters["LightDirection"].SetValue(sundir);
      this.mybasic.Parameters["world"].SetValue(matrix);
      this.mybasic.Parameters["view"].SetValue(viewMatrix);
      this.mybasic.Parameters["projection"].SetValue(projectionMatrix);
      model.Meshes[0].Draw();
    }

    private void TireTreads()
    {
      if (this.lastpos == new Vector3(0.0f, 0.0f, 0.0f))
        this.lastpos = this.rover.position;
      int num = (int) Vector3.Distance(this.rover.position, this.lastpos);
      if (num <= 2)
        return;
      Vector3 vector3_1 = Vector3.Normalize(this.rover.position - this.lastpos);
      float height;
      this.GetHeightOnly(ref this.tmake.heightData, this.rover.position, out height);
      Vector3 vector3_2 = this.rover.position + Vector3.Transform(new Vector3(37f, 0.0f, 61f), this.rover.orientation);
      Vector3 vector3_3 = this.rover.position + Vector3.Transform(new Vector3(-37f, 0.0f, 61f), this.rover.orientation);
      if ((double) height >= (double) this.rover.position.Y - 20.0)
      {
        for (int index = 0; index < num; index += 4)
        {
          Vector3 position = new Vector3(vector3_2.X + (float) index * vector3_1.X, 0.0f, vector3_2.Z + (float) index * vector3_1.Z);
          this.GetHeightOnly(ref this.tmake.heightData, position, out height);
          position.Y = height + 4f;
          if ((double) this.rover.leanAmt >= -0.20000000298023224)
            this.skids.AddParticle(position, new Vector3(0.0f, 0.0f, 0.0f));
          position = new Vector3(vector3_3.X + (float) index * vector3_1.X, 0.0f, vector3_3.Z + (float) index * vector3_1.Z);
          this.GetHeightOnly(ref this.tmake.heightData, position, out height);
          position.Y = height + 4f;
          if ((double) this.rover.leanAmt <= 0.20000000298023224)
            this.skids.AddParticle(position, new Vector3(0.0f, 0.0f, 0.0f));
        }
      }
      this.lastpos = this.rover.position;
    }

    private void landerDrips()
    {
      this.leg1 = this.lander.position + Vector3.Transform(new Vector3(-13f, -152f, 151f), this.lander.orientation);
      this.leg2 = this.lander.position + Vector3.Transform(new Vector3(-151f, -152f, 11f), this.lander.orientation);
      this.leg3 = this.lander.position + Vector3.Transform(new Vector3(13f, -152f, -151f), this.lander.orientation);
      this.leg4 = this.lander.position + Vector3.Transform(new Vector3(151f, -152f, 11f), this.lander.orientation);
      if (this.lastleg1 == new Vector3(0.0f, 0.0f, 0.0f))
        this.lastleg1 = this.leg1;
      if (this.lastleg2 == new Vector3(0.0f, 0.0f, 0.0f))
        this.lastleg2 = this.leg2;
      if (this.lastleg3 == new Vector3(0.0f, 0.0f, 0.0f))
        this.lastleg3 = this.leg3;
      if (this.lastleg4 == new Vector3(0.0f, 0.0f, 0.0f))
        this.lastleg4 = this.leg4;
      int num1 = (int) Vector3.Distance(this.leg1, this.lastleg1);
      if (num1 > 2)
      {
        Vector3 vector3 = Vector3.Normalize(this.leg1 - this.lastleg1);
        for (int index = 0; index < num1; index += 4)
          this.streaks.AddParticle(new Vector3(this.leg1.X + (float) index * vector3.X, this.leg1.Y + (float) index * vector3.Y, this.leg1.Z + (float) index * vector3.Z), new Vector3(0.0f, 0.0f, 0.0f));
      }
      int num2 = (int) Vector3.Distance(this.leg2, this.lastleg2);
      if (num2 > 2)
      {
        Vector3 vector3 = Vector3.Normalize(this.leg2 - this.lastleg2);
        for (int index = 0; index < num2; index += 4)
          this.streaks.AddParticle(new Vector3(this.leg2.X + (float) index * vector3.X, this.leg2.Y + (float) index * vector3.Y, this.leg2.Z + (float) index * vector3.Z), new Vector3(0.0f, 0.0f, 0.0f));
      }
      int num3 = (int) Vector3.Distance(this.leg3, this.lastleg3);
      if (num3 > 2)
      {
        Vector3 vector3 = Vector3.Normalize(this.leg3 - this.lastleg3);
        for (int index = 0; index < num3; index += 4)
          this.streaks.AddParticle(new Vector3(this.leg3.X + (float) index * vector3.X, this.leg3.Y + (float) index * vector3.Y, this.leg3.Z + (float) index * vector3.Z), new Vector3(0.0f, 0.0f, 0.0f));
      }
      int num4 = (int) Vector3.Distance(this.leg4, this.lastleg4);
      if (num4 > 2)
      {
        Vector3 vector3 = Vector3.Normalize(this.leg4 - this.lastleg4);
        for (int index = 0; index < num4; index += 4)
          this.streaks.AddParticle(new Vector3(this.leg4.X + (float) index * vector3.X, this.leg4.Y + (float) index * vector3.Y, this.leg4.Z + (float) index * vector3.Z), new Vector3(0.0f, 0.0f, 0.0f));
      }
      this.lastleg1 = this.leg1;
      this.lastleg2 = this.leg2;
      this.lastleg3 = this.leg3;
      this.lastleg4 = this.leg4;
    }

    private void ejecta(int many)
    {
      for (float num1 = 1f; (double) num1 < (double) many; ++num1)
      {
        float num2 = (float) this.random.Next(40, 110) + this.lander.lander2ground / 6f;
        float num3 = (float) this.random.Next(1, 65000) / 10000f;
        float x = (float) Math.Sin((double) num3) * num2 + this.lander.ground.X;
        float z = (float) Math.Cos((double) num3) * num2 + this.lander.ground.Z;
        float height;
        Vector3 normal;
        if (!this.lander.onDropship)
        {
          this.GetHeightAndNormal(ref this.tmake.heightData, ref this.tmake.normals, new Vector3(x, 0.0f, z), out height, out normal);
          Vector3 position = new Vector3(x, height, z);
          Vector3 velocity = Vector3.Reflect(new Vector3(x, (float) -(Math.Sin((double) num1 / 80.0) * 10.0 + 26.0), z) - new Vector3(this.lander.ground.X, 0.0f, this.lander.ground.Z), normal) * (float) (this.random.Next(600, 3000) / 300);
          if ((double) velocity.Y < 0.0)
            velocity.Y = Math.Abs(velocity.Y) + (float) ((double) velocity.Y * (double) this.random.Next(1, 100) / 100.0);
          this.dust.AddParticle(position, velocity);
        }
        else
        {
          this.ShipHeightandNormal(new Vector3(x, 0.0f, z), out height, out normal);
          if ((double) height != -5000.0)
          {
            Vector3 position = new Vector3(x, height, z);
            Vector3 velocity = Vector3.Reflect(new Vector3(x, (float) -(Math.Sin((double) num1 / 80.0) * 10.0 + 26.0), z) - new Vector3(this.lander.ground.X, 0.0f, this.lander.ground.Z), normal) * (float) (this.random.Next(600, 3000) / 300);
            if ((double) velocity.Y < 0.0)
              velocity.Y = Math.Abs(velocity.Y) + (float) ((double) velocity.Y * (double) this.random.Next(1, 100) / 100.0);
            this.dust.AddParticle(position, velocity);
          }
        }
      }
    }

    public void GetHeightAndNormal(
      ref int[,] heightData,
      ref Vector3[,] normals,
      Vector3 position,
      out float height,
      out Vector3 normal)
    {
      if (this.nearfarm)
      {
        this.GetHeightNormFarm(position, out height, out normal);
      }
      else
      {
        int num1 = (this.bitmap - 1) * this.gridscale;
        position.X = (float) ((double) position.X % (double) num1 + 1.5 * (double) num1) % (float) num1;
        position.Z = (float) ((double) position.Z % (double) num1 + 1.5 * (double) num1) % (float) num1;
        Vector3 vector3_1 = position;
        int x1 = (int) vector3_1.X / this.gridscale;
        int z1 = (int) vector3_1.Z / this.gridscale;
        float num2 = vector3_1.X % (float) this.gridscale / (float) this.gridscale;
        float num3 = vector3_1.Z % (float) this.gridscale / (float) this.gridscale;
        int x2 = x1 + 1;
        int z2 = z1 + 1;
        if (x2 > this.bitmap - 2)
          x2 = 0;
        if (z2 > this.bitmap - 2)
          z2 = 0;
        Vector3 vector3_2 = new Vector3((float) x1, (float) heightData[x1, z1], (float) z1);
        if ((double) num2 + (double) num3 >= 1.0)
          vector3_2 = new Vector3((float) x2, (float) heightData[x2, z2], (float) z2);
        Vector3 vector3_3 = new Vector3((float) x1, (float) heightData[x1, z2], (float) z2);
        Vector3 vector3_4 = new Vector3((float) x2, (float) heightData[x2, z1], (float) z1);
        Vector2 vector2 = new Vector2(vector3_1.X / (float) this.gridscale, vector3_1.Z / (float) this.gridscale);
        float num4 = (float) (((double) vector3_3.Z - (double) vector3_4.Z) * ((double) vector3_2.X - (double) vector3_4.X) + ((double) vector3_4.X - (double) vector3_3.X) * ((double) vector3_2.Z - (double) vector3_4.Z));
        float num5 = (float) (((double) vector3_3.Z - (double) vector3_4.Z) * ((double) vector2.X - (double) vector3_4.X) + ((double) vector3_4.X - (double) vector3_3.X) * ((double) vector2.Y - (double) vector3_4.Z)) / num4;
        float num6 = (float) (((double) vector3_4.Z - (double) vector3_2.Z) * ((double) vector2.X - (double) vector3_4.X) + ((double) vector3_2.X - (double) vector3_4.X) * ((double) vector2.Y - (double) vector3_4.Z)) / num4;
        float num7 = 1f - num5 - num6;
        height = (float) ((double) num5 * (double) vector3_2.Y + (double) num6 * (double) vector3_3.Y + (double) num7 * (double) vector3_4.Y);
        if ((double) num2 + (double) num3 > 1.0)
          vector3_2 = new Vector3((float) x2, (float) heightData[x2, z2], (float) z2);
        vector3_2.Y /= (float) this.gridscale;
        vector3_3.Y /= (float) this.gridscale;
        vector3_4.Y /= (float) this.gridscale;
        Vector3 vector3_5 = vector3_2;
        Vector3 vector3_6 = vector3_3;
        Vector3 vector3_7 = Vector3.Normalize(Vector3.Cross(vector3_4 - vector3_6, vector3_5 - vector3_6));
        if ((double) vector3_7.Y < 0.0)
          vector3_7 = -vector3_7;
        normal = vector3_7;
      }
    }

    public void GetHeightOnly(ref int[,] heightData, Vector3 position, out float height)
    {
      int num1 = (this.bitmap - 1) * this.gridscale;
      position.X = (float) ((double) position.X % (double) num1 + 1.5 * (double) num1) % (float) num1;
      position.Z = (float) ((double) position.Z % (double) num1 + 1.5 * (double) num1) % (float) num1;
      Vector3 vector3_1 = position;
      int x1 = (int) vector3_1.X / this.gridscale;
      int z1 = (int) vector3_1.Z / this.gridscale;
      float num2 = vector3_1.X % (float) this.gridscale / (float) this.gridscale;
      float num3 = vector3_1.Z % (float) this.gridscale / (float) this.gridscale;
      int x2 = x1 + 1;
      int z2 = z1 + 1;
      if (x2 > this.bitmap - 2)
        x2 = 0;
      if (z2 > this.bitmap - 2)
        z2 = 0;
      Vector3 vector3_2 = new Vector3((float) x1, (float) heightData[x1, z1], (float) z1);
      if ((double) num2 + (double) num3 >= 1.0)
        vector3_2 = new Vector3((float) x2, (float) heightData[x2, z2], (float) z2);
      Vector3 vector3_3 = new Vector3((float) x1, (float) heightData[x1, z2], (float) z2);
      Vector3 vector3_4 = new Vector3((float) x2, (float) heightData[x2, z1], (float) z1);
      Vector2 vector2 = new Vector2(vector3_1.X / (float) this.gridscale, vector3_1.Z / (float) this.gridscale);
      float num4 = (float) (((double) vector3_3.Z - (double) vector3_4.Z) * ((double) vector3_2.X - (double) vector3_4.X) + ((double) vector3_4.X - (double) vector3_3.X) * ((double) vector3_2.Z - (double) vector3_4.Z));
      float num5 = (float) (((double) vector3_3.Z - (double) vector3_4.Z) * ((double) vector2.X - (double) vector3_4.X) + ((double) vector3_4.X - (double) vector3_3.X) * ((double) vector2.Y - (double) vector3_4.Z)) / num4;
      float num6 = (float) (((double) vector3_4.Z - (double) vector3_2.Z) * ((double) vector2.X - (double) vector3_4.X) + ((double) vector3_2.X - (double) vector3_4.X) * ((double) vector2.Y - (double) vector3_4.Z)) / num4;
      float num7 = 1f - num5 - num6;
      height = (float) ((double) num5 * (double) vector3_2.Y + (double) num6 * (double) vector3_3.Y + (double) num7 * (double) vector3_4.Y);
    }

    public void ShipHeight(Vector3 position, out float height)
    {
      int num1 = 81;
      float num2 = 102.5f;
      float num3 = 8200f;
      position.X = (float) (((double) position.X - (double) this.vector3_0.X) % (double) num3 + 12300.0) % num3;
      position.Z = (float) (((double) position.Z - (double) this.vector3_0.Z) % (double) num3 + 12300.0) % num3;
      Vector3 vector3 = position;
      int index1 = (int) vector3.X / 102;
      int index2 = (int) vector3.Z / 102;
      float amount1 = vector3.X % num2 / num2;
      float amount2 = vector3.Z % num2 / num2;
      int index3 = index1 + 1;
      int index4 = index2 + 1;
      if (index3 > 79)
        index3 = 0;
      if (index4 > num1 - 2)
        index4 = 0;
      float num4 = MathHelper.Lerp(this.lander.drophite[index1, index2], this.lander.drophite[index3, index2], amount1);
      float num5 = MathHelper.Lerp(this.lander.drophite[index1, index4], this.lander.drophite[index3, index4], amount1);
      height = MathHelper.Lerp(num4, num5, amount2);
      if ((double) height <= 0.0)
        height = -5000f;
      else
        height += this.vector3_0.Y;
    }

    public void ShipHeightandNormal(Vector3 position, out float height, out Vector3 normal)
    {
      int num1 = 81;
      float num2 = 102.5f;
      float num3 = 8200f;
      position.X = (float) (((double) position.X - (double) this.vector3_0.X) % (double) num3 + 12300.0) % num3;
      position.Z = (float) (((double) position.Z - (double) this.vector3_0.Z) % (double) num3 + 12300.0) % num3;
      Vector3 vector3 = position;
      int index1 = (int) vector3.X / 102;
      int index2 = (int) vector3.Z / 102;
      float amount1 = vector3.X % num2 / num2;
      float amount2 = vector3.Z % num2 / num2;
      int index3 = index1 + 1;
      int index4 = index2 + 1;
      if (index3 > 79)
        index3 = 0;
      if (index4 > num1 - 2)
        index4 = 0;
      float num4 = MathHelper.Lerp(this.lander.drophite[index1, index2], this.lander.drophite[index3, index2], amount1);
      float num5 = MathHelper.Lerp(this.lander.drophite[index1, index4], this.lander.drophite[index3, index4], amount1);
      height = MathHelper.Lerp(num4, num5, amount2);
      if ((double) height <= 0.0)
        height = -5000f;
      else
        height += this.vector3_0.Y;
      normal = Vector3.Normalize(new Vector3(-this.lander.drophite[index3, index2] + this.lander.drophite[index1, index2], 102.5f, -this.lander.drophite[index1, index4] + this.lander.drophite[index1, index2]));
    }

    public void GetHeightFarm(Vector3 position, out float height)
    {
      Vector3 vector3 = new Vector3(3000f - this.farmLocation.X, 0.0f, 3000f - this.farmLocation.Z);
      position += vector3;
      int index1 = (int) MathHelper.Clamp(position.X / 30f, 0.0f, 198f);
      int index2 = (int) MathHelper.Clamp(position.Z / 30f, 0.0f, 198f);
      float num1 = (float) ((double) position.X % 30.0 / 30.0);
      float num2 = (float) ((double) position.Z % 30.0 / 30.0);
      float num3 = (float) ((1.0 - (double) num1) * (double) this.heights[index1, index2] + (double) num1 * (double) this.heights[index1 + 1, index2]);
      float num4 = (float) ((1.0 - (double) num1) * (double) this.heights[index1, index2 + 1] + (double) num1 * (double) this.heights[index1 + 1, index2 + 1]);
      height = (float) ((1.0 - (double) num2) * (double) num3 + (double) num2 * (double) num4);
    }

    public void GetHeightFarm2(Vector3 position, out float height)
    {
      Vector3 vector3_1 = new Vector3(3000f - this.farmLocation.X, 0.0f, 3000f - this.farmLocation.Z);
      position += vector3_1;
      int x1 = (int) MathHelper.Clamp(position.X / 30f, 0.0f, 198f);
      int z1 = (int) MathHelper.Clamp(position.Z / 30f, 0.0f, 198f);
      float num1 = (float) ((double) position.X % 30.0 / 30.0);
      float num2 = (float) ((double) position.Z % 30.0 / 30.0);
      int x2 = x1 + 1;
      int z2 = z1 + 1;
      if (x2 > 198)
        x2 = 0;
      if (z2 > 198)
        z2 = 0;
      Vector3 vector3_2 = new Vector3((float) x1, (float) this.heights[x1, z1], (float) z1);
      if ((double) num1 + (double) num2 >= 1.0)
        vector3_2 = new Vector3((float) x2, (float) this.heights[x2, z2], (float) z2);
      Vector3 vector3_3 = new Vector3((float) x1, (float) this.heights[x1, z2], (float) z2);
      Vector3 vector3_4 = new Vector3((float) x2, (float) this.heights[x2, z1], (float) z1);
      Vector2 vector2 = new Vector2(position.X / 30f, position.Z / 30f);
      float num3 = (float) (((double) vector3_3.Z - (double) vector3_4.Z) * ((double) vector3_2.X - (double) vector3_4.X) + ((double) vector3_4.X - (double) vector3_3.X) * ((double) vector3_2.Z - (double) vector3_4.Z));
      float num4 = (float) (((double) vector3_3.Z - (double) vector3_4.Z) * ((double) vector2.X - (double) vector3_4.X) + ((double) vector3_4.X - (double) vector3_3.X) * ((double) vector2.Y - (double) vector3_4.Z)) / num3;
      float num5 = (float) (((double) vector3_4.Z - (double) vector3_2.Z) * ((double) vector2.X - (double) vector3_4.X) + ((double) vector3_2.X - (double) vector3_4.X) * ((double) vector2.Y - (double) vector3_4.Z)) / num3;
      float num6 = 1f - num4 - num5;
      height = (float) ((double) num4 * (double) vector3_2.Y + (double) num5 * (double) vector3_3.Y + (double) num6 * (double) vector3_4.Y);
    }

    public void GetHeightNormFarm(Vector3 position, out float height, out Vector3 normal)
    {
      Vector3 vector3_1 = new Vector3(3000f - this.farmLocation.X, 0.0f, 3000f - this.farmLocation.Z);
      position += vector3_1;
      int x1 = (int) MathHelper.Clamp(position.X / 30f, 0.0f, 198f);
      int z1 = (int) MathHelper.Clamp(position.Z / 30f, 0.0f, 198f);
      float num1 = (float) ((double) position.X % 30.0 / 30.0);
      float num2 = (float) ((double) position.Z % 30.0 / 30.0);
      int x2 = x1 + 1;
      int z2 = z1 + 1;
      if (x2 > 198)
        x2 = 0;
      if (z2 > 198)
        z2 = 0;
      Vector3 vector3_2 = new Vector3((float) x1, (float) this.heights[x1, z1], (float) z1);
      if ((double) num1 + (double) num2 >= 1.0)
        vector3_2 = new Vector3((float) x2, (float) this.heights[x2, z2], (float) z2);
      Vector3 vector3_3 = new Vector3((float) x1, (float) this.heights[x1, z2], (float) z2);
      Vector3 vector3_4 = new Vector3((float) x2, (float) this.heights[x2, z1], (float) z1);
      Vector2 vector2 = new Vector2(position.X / 30f, position.Z / 30f);
      float num3 = (float) (((double) vector3_3.Z - (double) vector3_4.Z) * ((double) vector3_2.X - (double) vector3_4.X) + ((double) vector3_4.X - (double) vector3_3.X) * ((double) vector3_2.Z - (double) vector3_4.Z));
      float num4 = (float) (((double) vector3_3.Z - (double) vector3_4.Z) * ((double) vector2.X - (double) vector3_4.X) + ((double) vector3_4.X - (double) vector3_3.X) * ((double) vector2.Y - (double) vector3_4.Z)) / num3;
      float num5 = (float) (((double) vector3_4.Z - (double) vector3_2.Z) * ((double) vector2.X - (double) vector3_4.X) + ((double) vector3_2.X - (double) vector3_4.X) * ((double) vector2.Y - (double) vector3_4.Z)) / num3;
      float num6 = 1f - num4 - num5;
      height = (float) ((double) num4 * (double) vector3_2.Y + (double) num5 * (double) vector3_3.Y + (double) num6 * (double) vector3_4.Y);
      if ((double) num1 + (double) num2 > 1.0)
        vector3_2 = new Vector3((float) x2, (float) this.heights[x2, z2], (float) z2);
      vector3_2.Y /= 30f;
      vector3_3.Y /= 30f;
      vector3_4.Y /= 30f;
      Vector3 vector3_5 = vector3_2;
      Vector3 vector3_6 = vector3_3;
      Vector3 vector3_7 = Vector3.Normalize(Vector3.Cross(vector3_4 - vector3_6, vector3_5 - vector3_6));
      if ((double) vector3_7.Y < 0.0)
        vector3_7 = -vector3_7;
      normal = vector3_7;
    }

    private void DrawPrints(ref GameplayScreen.hole hole)
    {
      int stainMax = hole.stainMax;
      if (stainMax < 1)
        return;
      ModelMeshPart meshPart = this.footprint.Meshes[0].MeshParts[0];
      hole.stainBuffer.SetData<GameplayScreen.hitStream>(hole.stainTrans, 0, stainMax, SetDataOptions.Discard);
      Effect effect = meshPart.Effect;
      effect.Parameters["World"].SetValue(Matrix.Identity);
      effect.Parameters["NormalMap"].SetValue((Texture) this.normalmap);
      effect.Parameters["AmbientColor"].SetValue(new Vector4(0.1f, 0.1f, 0.1f, 1f));
      effect.Parameters["DiffuseColor"].SetValue(new Vector4(1f, 1f, 1f, 1f));
      effect.Parameters["LightDirection"].SetValue(new Vector3(this.sunDir.X, this.sunDir.Y, this.sunDir.Z));
      effect.CurrentTechnique = effect.Techniques["feet"];
      effect.Parameters["View"].SetValue(this.viewMatrix);
      effect.Parameters["Projection"].SetValue(this.projectionMatrix);
      effect.CurrentTechnique.Passes[0].Apply();
      this._vertexBufferBindings[0] = new VertexBufferBinding(meshPart.VertexBuffer, meshPart.VertexOffset, 0);
      this._vertexBufferBindings[1] = new VertexBufferBinding((VertexBuffer) hole.stainBuffer, 0, 1);
      this.sc.GraphicsDevice.SetVertexBuffers(this._vertexBufferBindings);
      this.sc.GraphicsDevice.Indices = meshPart.IndexBuffer;
      this.sc.GraphicsDevice.DrawInstancedPrimitives(PrimitiveType.TriangleList, 0, 0, meshPart.NumVertices, meshPart.StartIndex, meshPart.PrimitiveCount, stainMax);
    }

    private void RestoreRenderStates()
    {
      this.sc.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
      this.sc.GraphicsDevice.BlendState = BlendState.NonPremultiplied;
      this.sc.GraphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;
      this.sc.GraphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;
    }

    public bool queryButton2(Rectangle rr)
    {
      this.adj = new Vector2((float) this.mouseState.X, (float) this.mouseState.Y);
      if ((double) this.sc.aspectratio <= 1.0)
        this.adj.Y -= (float) (((double) this.sc.screenSize.Height - (double) this.sc.screenSize.Height * (double) this.sc.aspectratio) * (0.5 / (double) this.sc.aspectratio));
      else
        this.adj.X -= (float) (((double) this.sc.screenSize.Width - (double) this.sc.screenSize.Width / (double) this.sc.aspectratio) * (0.5 * (double) this.sc.aspectratio));
      this.adj /= new Vector2((float) this.sc.screenSize.Width / (float) this.sc.origSize.Width, (float) this.sc.screenSize.Height / (float) this.sc.origSize.Height);
      return ((double) this.adj.Y <= (double) rr.Y || (double) this.adj.Y > (double) (rr.Y + rr.Height) || (double) this.adj.X <= (double) rr.X ? 0 : ((double) this.adj.X <= (double) (rr.X + rr.Width) ? 1 : 0)) != 0;
    }

    public enum act
    {
      rovered,
      landered,
      killed,
      rescued,
      recruited,
      facility,
      chill,
      rocked,
      refined,
      facilityfound,
      cloned,
      waited,
      dropship,
      nothing,
    }

    public struct hitStream : IVertexType
    {
      public Matrix Trans;
      public float Fade;
      private static readonly VertexDeclaration VertexDeclaration = new VertexDeclaration(new VertexElement[5]
      {
        new VertexElement(0, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 0),
        new VertexElement(16, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 1),
        new VertexElement(32, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 2),
        new VertexElement(48, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 3),
        new VertexElement(64, VertexElementFormat.Single, VertexElementUsage.Fog, 0)
      });

      VertexDeclaration IVertexType.VertexDeclaration => GameplayScreen.hitStream.VertexDeclaration;
    }

    public struct hole
    {
      public float[] drift;
      public GameplayScreen.hitStream[] stainTrans;
      public int stainIndex;
      public int stainMax;
      public int stainCapacity;
      public DynamicVertexBuffer stainBuffer;
    }
  }
}
