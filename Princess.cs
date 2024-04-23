// Decompiled with JetBrains decompiler
// Type: Blood.Princess
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Net;
using SkinnedModel;
using System;
using System.Collections.Generic;
using System.Text;

#nullable disable
namespace Blood
{
  internal class Princess
  {
    public ParticleSystem rocks;
    public ParticleSystem dots;
    public ushort heartHit;
    public static int speeches = 0;
    public static int xcoord;
    public static int ycoord;
    public static int cuttyCount = 0;
    public static bool allplayersReady = false;
    public static bool cuttyDoneSpeech = false;
    public static byte bit = 0;
    public static byte uvIndex;
    public static int whichPigTalks;
    public static bool someoneTalking = false;
    public static float shortestDistance = 20000f;
    public static int bitmap;
    public static float unit;
    public static float Grid;
    public static int seed = 5;
    public int explodeSpeed;
    public int randomSeed = 10;
    public int explodeReal = 1;
    public Vector3 campos;
    public bool pigModelLoaded;
    private Vector3 assScale = Vector3.Zero;
    private Vector3 assScale2 = Vector3.Zero;
    private float assRamp;
    private float myTimer1;
    private float myTimer2;
    private float burstscale = 0.2f;
    private float burstfade;
    private float burstY = 30f;
    public bool volumeFade;
    private AnimationPlayer a;
    private AnimationPlayer b;
    private int myClip;
    private Matrix heartMatrix;
    private float heartTimer;
    private float heartattack;
    public bool heartExposed;
    public int heartIndex = -1;
    private Matrix m1;
    private Matrix m2;
    private Matrix m3;
    private Matrix m4;
    private Matrix m5;
    private Vector3 v1 = Vector3.Zero;
    private Vector3 myZero = Vector3.Zero;
    private NetworkSession networkSession;
    public int break1 = 510;
    public int break2 = 790;
    private int timeframe;
    public bool spectator;
    public int df;
    private float playerHealth;
    private float remoteHealth;
    public SoundEffect bossTheme;
    private SoundEffects burps;
    private SoundEffects explode;
    private SoundEffects splats;
    private SoundEffects dogroll;
    private SoundEffects windy;
    private SoundEffects heartbeat;
    private SoundEffects bucking;
    private SoundEffects fart;
    public float shockRadius;
    public float shockTimer;
    public bool shockHit;
    public bool groundhit;
    public bool shockHasHit;
    public static StringBuilder nameBuild = new StringBuilder(32, 32);
    private Model canvas;
    private Model tunnel;
    private Effect simple;
    private Effect simple2;
    private Effect tunnelfx;
    public int myIndex;
    public int pigIndex;
    private int bodyState;
    public bool boneStrike;
    private int showSkelTimer;
    public int seizureTimer;
    private int faceseizureTimer;
    public float glowTimer;
    public Vector3 playerpos;
    public Vector3 remotepos;
    public bool cuttyCollide;
    public bool cuttyAssPush;
    public bool cuttyRoll;
    public bool cuttyBuck;
    public bool cuttyShit;
    private float cuttyRollFade = 1f;
    private int cuttyRollCount;
    public int cuttyWait;
    private readonly VertexBufferBinding[] _vertexBufferBindings = new VertexBufferBinding[2];
    private static VertexDeclaration instanceDec = new VertexDeclaration(new VertexElement[5]
    {
      new VertexElement(0, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 0),
      new VertexElement(16, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 1),
      new VertexElement(32, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 2),
      new VertexElement(48, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 3),
      new VertexElement(64, VertexElementFormat.Vector3, VertexElementUsage.Normal, 1)
    });
    private Princess.shell chunk;
    private Princess.shell faceChunk;
    private Princess.shell assChunk;
    public Princess.vomit puke1;
    public Princess.finale bloody;
    public static RasterizerState wiredOn = new RasterizerState()
    {
      FillMode = FillMode.WireFrame
    };
    public static RasterizerState wiredOff = new RasterizerState()
    {
      FillMode = FillMode.Solid
    };
    public float targetRot;
    public int turningWait = 900;
    public bool newAction;
    public bool jumpVol;
    public bool rollVol;
    public bool vomitVol;
    public bool shitVol;
    public bool heartVol;
    public float cuttyDistance = 20000f;
    public float fps;
    public ushort assDamage;
    public ushort faceDamage;
    public ushort spineDamage;
    private float[] assBreach = new float[7]
    {
      40f,
      90f,
      110f,
      80f,
      120f,
      140f,
      250f
    };
    private ushort[] assDam = new ushort[7]
    {
      (ushort) 12,
      (ushort) 6,
      (ushort) 3,
      (ushort) 9,
      (ushort) 5,
      (ushort) 3,
      (ushort) 2
    };
    private float[] faceBreach = new float[7]
    {
      40f,
      90f,
      110f,
      80f,
      120f,
      140f,
      250f
    };
    private ushort[] faceDam = new ushort[7]
    {
      (ushort) 14,
      (ushort) 6,
      (ushort) 3,
      (ushort) 8,
      (ushort) 5,
      (ushort) 3,
      (ushort) 2
    };
    private float[] spineBreach = new float[7]
    {
      40f,
      90f,
      110f,
      70f,
      120f,
      140f,
      250f
    };
    private ushort[] spineDam = new ushort[7]
    {
      (ushort) 14,
      (ushort) 6,
      (ushort) 3,
      (ushort) 10,
      (ushort) 6,
      (ushort) 4,
      (ushort) 2
    };
    private bool assDestroyed;
    private bool spineDestroyed;
    private bool faceDestroyed;
    public float[] minDistance = new float[7]
    {
      1440000f,
      990000f,
      850000f,
      1440000f,
      990000f,
      810000f,
      1400000f
    };
    private int[] jumpOdds = new int[7]
    {
      200,
      300,
      400,
      400,
      500,
      700,
      200
    };
    private float[] angleView = new float[7]
    {
      0.3f,
      0.9f,
      1.4f,
      1f,
      1.4f,
      1.6f,
      1.7f
    };
    public int[] shitDam = new int[7]
    {
      3,
      5,
      8,
      8,
      10,
      15,
      20
    };
    public float[] futureDam = new float[7]
    {
      30f,
      40f,
      60f,
      60f,
      90f,
      90f,
      90f
    };
    public int[] rollDam = new int[7]
    {
      2,
      3,
      5,
      5,
      7,
      8,
      12
    };
    private float[] hitScale = new float[7]
    {
      1f,
      1f,
      1.1f,
      1f,
      1.1f,
      1.2f,
      1.6f
    };
    public float[] rollPower = new float[7]
    {
      0.5f,
      0.6f,
      0.65f,
      0.65f,
      0.7f,
      0.73f,
      0.77f
    };
    private int[] damTrigger = new int[7]
    {
      6,
      5,
      2,
      6,
      3,
      1,
      2
    };
    private int damcheck = 5;
    public bool shootHeartMessage;
    public int heartMessCount;
    public bool shootWoundMessage;
    public bool notcloseEnough;
    public int notcloseCount;
    public float delay;
    private int timeDelay;
    private int lasttimeDelay;
    public bool actionScheduled;
    public Princess.conductor tempConduct = new Princess.conductor();
    private Princess.conductor cuttyStruct = new Princess.conductor();
    private Princess.conductor cuttyStruct_send = new Princess.conductor();
    private List<Princess.conductor> scheduleList = new List<Princess.conductor>();
    private int currentKeyframe;
    private TimeSpan currentTimeValue;
    private ScreenManager sc;
    private ContentManager content;
    private RenderTarget2D screenTarget1;
    private RenderTarget2D screenTarget2;
    private RenderTarget2D canvasTarget2;
    private RenderTarget2D canvasTarget1;
    private int targetChoice;
    private int canvasChoice;
    private SpriteBatch spriteBatch;
    private int boneHit = -1;
    private int[] col_Bone = new int[8]
    {
      5,
      7,
      8,
      2,
      13,
      17,
      21,
      26
    };
    private float[] col_Scale = new float[8];
    private Vector3[] col_Pos = new Vector3[8];
    public bool cuttyisHit;
    public bool cuttyChunkRelease;
    public Vector3 hitCenter;
    public Vector3 hitCenter2;
    public Vector3 hitEdge;
    public Vector3 hitEdge2;
    public string[] pigdialogueName = new string[11]
    {
      "yell1",
      "vomit1",
      "vomit2",
      "yell2",
      "yell3",
      "yell4",
      "hurtbaby",
      "baby4",
      "baby3",
      "baby2",
      "empty"
    };
    public int pigLine = -1;
    public int pigJawIndex = -1;
    public int talkIndex = -1;
    public SoundEffects pigDialog1;
    public float distanceCutty = 10000f;
    public float distanceCutty2 = 100000f;
    public float eyeGlow = 1f;
    public bool isSpeaking;
    public bool isWatching;
    public bool pigDialog1Loaded;
    public bool lookingatPig = true;
    public float[] pigJaw;
    public float talkSmooth;
    public float piglook;
    private float tiltOffset;
    private Vector3 bonePos;
    public float pigPush;
    public float pigFrame1;
    private float bFrame1;
    private AnimationPlayer[] pig1;
    private Matrix[] princessBone;
    private int clipIndexA;
    private int clipIndexB;
    private float tween = 1f;
    public Vector3 cuttyPos;
    public Vector3 oldcuttyPos;
    public Vector3 cuttyVeloc;
    private Vector3 oldvomitpos = Vector3.Zero;
    private Vector3 vomitpos;
    private Vector3 vomitveloc;
    private float cuttyScale;
    public float cuttyRot;
    private Matrix cuttyTrans;
    private Random rr;
    public Model pigModel;
    public Model sphere;
    public Model grid;
    public Model gutsModel;
    private Effect pigSkin;
    private Effect solidSkin;
    public Effect glowEffect;
    private Texture2D pigTexture;
    private Texture2D heartTexture;
    private Texture2D tunneldust;
    private Texture2D glow;
    private Texture2D guts;
    private Effect burst;
    private Effect gutsEffect;
    private Matrix burstMatrix;
    private Matrix view;
    private Matrix proj;
    private Matrix[] explodePart;
    public bool attack1;
    private int nextAttack = 900;
    public int hurtBoss;
    public bool death1;
    public bool deathsent;
    public bool cuttyisDead;
    public int explodeTimer = 50;
    public bool cuttyVomitHit;
    public bool cuttyVomitHit2;
    public bool cuttyShitHit;
    public bool cuttyShitHit2;
    public float cuttyVomitTimer;
    public float cuttyShitTimer;
    private float upForce;
    private float upForceAcc;
    private float upForceMax;
    private float grav;
    private float attackduration;
    private float attacktimer;
    private float attackWait1;
    private float attackWait2;
    private float gonnaRollDelay = 500f;
    private float buckDelay = 900f;
    private float shitDelay = 900f;
    private bool gonnaShit;
    private bool gonnaVomit;
    private float shitTimer = 200f;
    public ushort startHealth = 2500;
    public ushort health = 2500;
    private float healthPerc;
    public byte damagebit = 1;
    public int homing;
    public int homingDirection;
    private int homingTimer;
    private int homingStart = 500;
    public bool cuttyDoneLocalSpeech;
    private List<int> speechList = new List<int>();
    private List<int> speechInclude = new List<int>();
    public bool playingBossMusic;
    public bool isTrialMode;
    public Princess.paintBody canvasPaint;
    public Princess.paintBody bodyPaint;

    public Princess(int index, string name, bool thisTrial)
    {
      this.isTrialMode = thisTrial;
      Princess.bit = (byte) 0;
      Princess.uvIndex = (byte) 0;
      Princess.xcoord = 0;
      Princess.ycoord = 0;
      Princess.speeches = 0;
      Princess.cuttyCount = 0;
      Princess.allplayersReady = false;
      Princess.cuttyDoneSpeech = false;
      Princess.someoneTalking = false;
      Princess.shortestDistance = 20000f;
      Princess.whichPigTalks = 0;
      Princess.seed = 5;
      Princess.nameBuild.Length = 0;
      Princess.nameBuild.Append(name);
      Random random = new Random();
      if (index == 3)
      {
        this.pigIndex = index;
        this.myIndex = 0;
        this.health = (ushort) 1600;
        this.startHealth = (ushort) 1600;
        this.speechList = new List<int>()
        {
          random.Next(3, 6)
        };
        Princess.speeches = 0;
        this.cuttyPos = new Vector3(2988f, -54f, 2975f);
        this.cuttyScale = 2.6f;
        this.speechInclude = new List<int>() { 0 };
        this.cuttyRot = 1.7f;
        this.targetRot = 1.7f;
      }
      if (index == 4)
      {
        this.pigIndex = index;
        this.myIndex = 0;
        this.health = (ushort) 1600;
        this.startHealth = (ushort) 1600;
        this.speechList = new List<int>()
        {
          random.Next(3, 6)
        };
        Princess.speeches = 0;
        this.cuttyPos = new Vector3(2988f, -54f, 2975f);
        this.cuttyScale = 3.2f;
        this.speechInclude = new List<int>() { 0 };
        this.cuttyRot = 4.84f;
        this.targetRot = 4.84f;
      }
      if (index == 5)
      {
        this.pigIndex = index;
        this.myIndex = 0;
        this.health = (ushort) 1600;
        this.startHealth = (ushort) 1600;
        this.speechList = new List<int>()
        {
          random.Next(3, 6)
        };
        Princess.speeches = 0;
        this.cuttyPos = new Vector3(2988f, -54f, 2975f);
        this.cuttyScale = 2.6f;
        this.speechInclude = new List<int>() { 0 };
        this.cuttyRot = 1.7f;
        this.targetRot = 1.7f;
      }
      if (index == 6)
      {
        this.pigIndex = index;
        this.myIndex = 0;
        this.health = (ushort) 1600;
        this.startHealth = (ushort) 1600;
        this.speechList = new List<int>()
        {
          random.Next(3, 6)
        };
        Princess.speeches = 0;
        this.cuttyPos = new Vector3(2988f, -54f, 2975f);
        this.cuttyScale = 3.6f;
        this.speechInclude = new List<int>() { 0 };
        this.cuttyRot = 5.04f;
        this.targetRot = 5.04f;
      }
      if (index == 7)
      {
        this.pigIndex = index;
        this.myIndex = 0;
        this.health = (ushort) 1600;
        this.startHealth = (ushort) 1600;
        this.speechList = new List<int>() { 8 };
        Princess.speeches = 0;
        this.cuttyPos = new Vector3(2988f, -54f, 2975f);
        this.cuttyScale = 3.8f;
        this.speechInclude = new List<int>() { 0 };
        this.cuttyRot = 4.14000034f;
        this.targetRot = 4.14000034f;
      }
      if (this.isTrialMode)
      {
        this.health = (ushort) 1600;
        this.startHealth = (ushort) 1600;
      }
      this.healthPerc = (float) this.health / (float) this.startHealth;
      this.oldcuttyPos = this.cuttyPos;
    }

    public void LoadContent(ScreenManager sc, ContentManager cc)
    {
      this.sc = sc;
      this.content = cc;
      this.canvasPaint.index = new List<int>();
      this.canvasPaint.x = new List<float>();
      this.canvasPaint.z = new List<float>();
      this.bodyPaint.index = new List<int>();
      this.bodyPaint.x = new List<float>();
      this.bodyPaint.z = new List<float>();
      this.spriteBatch = new SpriteBatch(sc.GraphicsDevice);
      this.rr = new Random();
      this.bossTheme = this.content.Load<SoundEffect>("audio\\newBoss");
      this.burps = new SoundEffects(1);
      this.burps.sound[0] = this.content.Load<SoundEffect>("audio\\gallop2").CreateInstance();
      this.burps.sound[0].IsLooped = true;
      this.burps.sound[0].Play();
      this.burps.sound[0].Volume = 0.0f;
      this.heartbeat = new SoundEffects(1);
      this.heartbeat.sound[0] = this.content.Load<SoundEffect>("audio//heartbeat").CreateInstance();
      this.bucking = new SoundEffects(1);
      this.bucking.sound[0] = this.content.Load<SoundEffect>("audio//buckClomp2").CreateInstance();
      this.fart = new SoundEffects(1);
      this.fart.sound[0] = this.content.Load<SoundEffect>("audio//fart4").CreateInstance();
      this.explode = new SoundEffects(1);
      this.explode.sound[0] = this.content.Load<SoundEffect>("audio\\explode2").CreateInstance();
      this.windy = new SoundEffects(1);
      this.windy.sound[0] = this.content.Load<SoundEffect>("audio\\windy").CreateInstance();
      this.dogroll = new SoundEffects(2);
      this.dogroll.sound[0] = this.content.Load<SoundEffect>("audio\\dogroll").CreateInstance();
      this.dogroll.sound[1] = this.content.Load<SoundEffect>("audio\\dogroll").CreateInstance();
      this.splats = new SoundEffects(3);
      this.splats.sound[0] = this.content.Load<SoundEffect>("audio\\splats").CreateInstance();
      this.splats.sound[1] = this.content.Load<SoundEffect>("audio\\splats").CreateInstance();
      this.splats.sound[2] = this.content.Load<SoundEffect>("audio\\splats").CreateInstance();
      this.solidSkin = this.content.Load<Effect>("effects\\SolidSkinEffect");
      this.solidSkin.Parameters["World"].SetValue(Matrix.CreateTranslation(0.0f, 0.0f, 0.0f));
      this.glowEffect = this.content.Load<Effect>("effects\\glowEffect2");
      this.glowEffect.CurrentTechnique = this.glowEffect.Techniques["EdgeDetect"];
      this.simple = this.content.Load<Effect>("effects//simpleEffect");
      this.simple2 = this.content.Load<Effect>("effects//simpleEffect2");
      this.tunnelfx = this.content.Load<Effect>("effects//tunnelEffect");
      this.canvas = this.content.Load<Model>("Models//farmCanvas");
      this.tunnel = this.content.Load<Model>("Models//windtunnel");
      Model model;
      if (this.pigIndex == 3)
      {
        model = this.content.Load<Model>("Models\\chunk4");
        this.pigTexture = this.content.Load<Texture2D>("npc\\pigBoss");
      }
      else if (this.pigIndex == 4)
      {
        model = this.content.Load<Model>("Models\\chunkBlk");
        this.pigTexture = this.content.Load<Texture2D>("npc\\pigBossBlack");
      }
      else if (this.pigIndex == 5)
      {
        model = this.content.Load<Model>("Models\\chunkGreen");
        this.pigTexture = this.content.Load<Texture2D>("npc\\pigBossGreen");
      }
      else if (this.pigIndex == 6)
      {
        model = this.content.Load<Model>("Models\\chunkUgly");
        this.pigTexture = this.content.Load<Texture2D>("npc\\pigBossUgly");
      }
      else if (this.pigIndex == 7)
      {
        model = this.content.Load<Model>("Models\\chunkUgly3");
        this.pigTexture = this.content.Load<Texture2D>("npc\\pigBossUgly3");
      }
      else
      {
        model = this.content.Load<Model>("Models\\chunk4");
        this.pigTexture = this.content.Load<Texture2D>("npc\\pigBoss");
      }
      this.heartTexture = this.content.Load<Texture2D>("npc\\heart");
      this.tunneldust = this.content.Load<Texture2D>("texture\\dusty");
      this.tunnelfx.Parameters["Texture"].SetValue((Texture) this.tunneldust);
      this.burst = this.content.Load<Effect>("effects\\burstEffect");
      this.burstMatrix = Matrix.CreateScale(1500f);
      this.glow = this.content.Load<Texture2D>("texture\\glow");
      this.grid = this.content.Load<Model>("models\\outlineGrid");
      this.burst.Parameters["Texture"].SetValue((Texture) this.glow);
      this.gutsEffect = this.content.Load<Effect>("effects\\gutsEffect");
      this.guts = this.content.Load<Texture2D>("texture\\guts");
      this.gutsModel = this.content.Load<Model>("models\\guts");
      this.gutsEffect.Parameters["Texture"].SetValue((Texture) this.guts);
      sc.bossIndex = 0;
      this.loadModels();
      this.pigJaw = new float[2200];
      this.pigSkin = this.content.Load<Effect>("effects\\bossSkin2");
      this.pigSkin.Parameters["World"].SetValue(Matrix.CreateTranslation(0.0f, 0.0f, 0.0f));
      this.pigSkin.Parameters["Texture"].SetValue((Texture) this.pigTexture);
      this.pigSkin.Parameters["Texture2"].SetValue((Texture) this.heartTexture);
      this.col_Bone = new int[6]{ 7, 7, 5, 3, 2, 17 };
      this.col_Scale[0] = 11f;
      this.col_Pos[0] = new Vector3(0.0f, 66f, (float) sbyte.MaxValue);
      this.col_Scale[1] = 27f;
      this.col_Pos[1] = new Vector3(0.0f, 72.46032f, 98.99477f);
      this.col_Scale[2] = 52f;
      this.col_Pos[2] = new Vector3(0.0f, 66.70475f, 46.14088f);
      this.col_Scale[3] = 58f;
      this.col_Pos[3] = new Vector3(0.0f, 64.01877f, -9.665999f);
      this.col_Scale[4] = 47f;
      this.col_Pos[4] = new Vector3(0.0f, 64.01877f, -62.562748f);
      this.col_Scale[5] = 25f;
      this.col_Pos[5] = new Vector3(0.0f, 54.4f, 22.6f);
      this.puke1 = new Princess.vomit();
      this.puke1.max = 0;
      this.puke1.maxCapacity = 1200;
      this.puke1.index = 0;
      this.puke1.model = this.content.Load<Model>("Models//pukelet");
      this.puke1.buffer = new DynamicVertexBuffer(sc.GraphicsDevice, Princess.instanceDec, this.puke1.maxCapacity, BufferUsage.WriteOnly);
      this.puke1.displayList = new Princess.instancedObject[this.puke1.maxCapacity];
      this.puke1.dupe = new vomitDupe[this.puke1.maxCapacity];
      for (int i = 0; i < this.puke1.maxCapacity; ++i)
        this.puke1.dupe[i] = new vomitDupe(i);
      this.puke1.stream = new Princess.instancedObject[this.puke1.maxCapacity];
      this.bloody = new Princess.finale();
      this.bloody.max = 0;
      this.bloody.maxCapacity = 399;
      this.bloody.index = 0;
      this.bloody.model = this.content.Load<Model>("Models//bloodything");
      this.bloody.buffer = new DynamicVertexBuffer(sc.GraphicsDevice, Princess.instanceDec, this.bloody.maxCapacity, BufferUsage.WriteOnly);
      this.bloody.displayList = new Princess.instancedObject[this.bloody.maxCapacity];
      this.bloody.dupe = new explodeDupe[this.bloody.maxCapacity];
      for (int i = 0; i < this.bloody.maxCapacity; ++i)
        this.bloody.dupe[i] = new explodeDupe(i);
      this.bloody.stream = new Princess.instancedObject[this.bloody.maxCapacity];
      this.chunk = new Princess.shell();
      this.chunk.max = 0;
      this.chunk.maxCapacity = 150;
      this.chunk.index = 0;
      this.chunk.offset = new Matrix[this.chunk.maxCapacity];
      this.chunk.bone = new int[this.chunk.maxCapacity];
      this.chunk.model = model;
      this.chunk.buffer = new DynamicVertexBuffer(sc.GraphicsDevice, Princess.instanceDec, this.chunk.maxCapacity, BufferUsage.WriteOnly);
      this.chunk.displayList = new Princess.instancedObject[this.chunk.maxCapacity];
      this.chunk.dupe = new chunkDupe[this.chunk.maxCapacity];
      for (int i = 0; i < this.chunk.maxCapacity; ++i)
        this.chunk.dupe[i] = new chunkDupe(i);
      this.chunk.stream = new Princess.instancedObject[this.chunk.maxCapacity];
      this.faceChunk = new Princess.shell();
      this.faceChunk.max = 0;
      this.faceChunk.maxCapacity = 60;
      this.faceChunk.index = 0;
      this.faceChunk.offset = new Matrix[this.faceChunk.maxCapacity];
      this.faceChunk.bone = new int[this.faceChunk.maxCapacity];
      this.faceChunk.model = model;
      this.faceChunk.buffer = new DynamicVertexBuffer(sc.GraphicsDevice, Princess.instanceDec, this.faceChunk.maxCapacity, BufferUsage.WriteOnly);
      this.faceChunk.displayList = new Princess.instancedObject[this.faceChunk.maxCapacity];
      this.faceChunk.dupe = new chunkDupe[this.faceChunk.maxCapacity];
      for (int i = 0; i < this.faceChunk.maxCapacity; ++i)
        this.faceChunk.dupe[i] = new chunkDupe(i);
      this.faceChunk.stream = new Princess.instancedObject[this.faceChunk.maxCapacity];
      this.assChunk = new Princess.shell();
      this.assChunk.max = 0;
      this.assChunk.maxCapacity = 79;
      this.assChunk.index = 0;
      this.assChunk.offset = new Matrix[this.assChunk.maxCapacity];
      this.assChunk.bone = new int[this.assChunk.maxCapacity];
      this.assChunk.model = model;
      this.assChunk.buffer = new DynamicVertexBuffer(sc.GraphicsDevice, Princess.instanceDec, this.assChunk.maxCapacity, BufferUsage.WriteOnly);
      this.assChunk.displayList = new Princess.instancedObject[this.assChunk.maxCapacity];
      this.assChunk.dupe = new chunkDupe[this.assChunk.maxCapacity];
      for (int i = 0; i < this.assChunk.maxCapacity; ++i)
        this.assChunk.dupe[i] = new chunkDupe(i);
      this.assChunk.stream = new Princess.instancedObject[this.assChunk.maxCapacity];
      this.resetExplody(false);
      Matrix[] matrixArray1 = new Matrix[148]
      {
        Matrix.CreateScale(0.8014864f, 0.889643967f, 0.8014864f) * Matrix.CreateRotationX(-1.48936939f) * Matrix.CreateRotationY(1.43918264f) * Matrix.CreateRotationZ(3.98103f) * Matrix.CreateTranslation(26.6014538f, 105.047989f, -29.7614765f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.10213661f) * Matrix.CreateRotationY(-1.41947961f) * Matrix.CreateRotationZ(0.317777127f) * Matrix.CreateTranslation(28.9735546f, 99.132576f, -68.3020859f),
        Matrix.CreateScale(0.756934643f, 0.6127788f, 0.6127788f) * Matrix.CreateRotationX(2.90467119f) * Matrix.CreateRotationY(0.5454444f) * Matrix.CreateRotationZ(8.517765f) * Matrix.CreateTranslation(25.0750217f, 106.966934f, 33.082f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(2.87051439f) * Matrix.CreateRotationY(0.773279846f) * Matrix.CreateRotationZ(8.430361f) * Matrix.CreateTranslation(22.8226147f, 102.60141f, 51.00435f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(2.73917961f) * Matrix.CreateRotationY(-0.7497437f) * Matrix.CreateRotationZ(8.731192f) * Matrix.CreateTranslation(35.9407272f, 89.76424f, 46.57292f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(2.856856f) * Matrix.CreateRotationY(0.7751548f) * Matrix.CreateRotationZ(8.440346f) * Matrix.CreateTranslation(29.3483963f, 96.68955f, 42.9412346f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(0.481634468f) * Matrix.CreateRotationY(-1.22178769f) * Matrix.CreateRotationZ(10.8561287f) * Matrix.CreateTranslation(47.8588257f, 74.6941757f, 20.0224686f),
        Matrix.CreateScale(0.631728947f, 0.5492081f, 0.6019117f) * Matrix.CreateRotationX(-0.0743461251f) * Matrix.CreateRotationY(-1.02668035f) * Matrix.CreateRotationZ(-1.16012371f) * Matrix.CreateTranslation(48.3657074f, 71.7803345f, -16.2644958f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(2.76684952f) * Matrix.CreateRotationY(-1.46768463f) * Matrix.CreateRotationZ(8.693154f) * Matrix.CreateTranslation(41.9052162f, 83.9779f, -48.790844f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(3.28568864f) * Matrix.CreateRotationY(0.7930756f) * Matrix.CreateRotationZ(8.599927f) * Matrix.CreateTranslation(38.3946266f, 89.42756f, -53.7233963f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(3.177453f) * Matrix.CreateRotationY(-0.6140531f) * Matrix.CreateRotationZ(8.58768f) * Matrix.CreateTranslation(29.9801636f, 105.9818f, 0.7926182f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(3.12785268f) * Matrix.CreateRotationY(0.444085628f) * Matrix.CreateRotationZ(8.514753f) * Matrix.CreateTranslation(36.7148552f, 97.02453f, 18.0649929f),
        Matrix.CreateScale(0.64229f, 0.4090254f, 0.64229f) * Matrix.CreateRotationX(3.12205672f) * Matrix.CreateRotationY(2.60455275f) * Matrix.CreateRotationZ(8.436325f) * Matrix.CreateTranslation(36.321476f, 98.7005844f, 8.202137f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(3.198539f) * Matrix.CreateRotationY(0.7041228f) * Matrix.CreateRotationZ(8.763815f) * Matrix.CreateTranslation(29.616478f, 106.564369f, 12.3993187f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(3.23758054f) * Matrix.CreateRotationY(-0.5807444f) * Matrix.CreateRotationZ(8.146708f) * Matrix.CreateTranslation(48.8764153f, 73.2013855f, 7.00098562f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(3.23758054f) * Matrix.CreateRotationY(-0.5807444f) * Matrix.CreateRotationZ(8.146708f) * Matrix.CreateTranslation(46.5118942f, 70.45753f, -30.5961857f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(2.95162153f) * Matrix.CreateRotationY(0.5767148f) * Matrix.CreateRotationZ(7.89462948f) * Matrix.CreateTranslation(44.62853f, 73.07472f, 40.8505745f),
        Matrix.CreateScale(0.918520868f, 1.0195514f, 0.918520868f) * Matrix.CreateRotationX(-1.42431521f) * Matrix.CreateRotationY(1.40116692f) * Matrix.CreateRotationZ(-1.48997486f) * Matrix.CreateTranslation(5.167546f, 117.757164f, -28.1143818f),
        Matrix.CreateScale(0.8014864f, 0.889643967f, 0.8014864f) * Matrix.CreateRotationX(-2.857909f) * Matrix.CreateRotationY(0.3168916f) * Matrix.CreateRotationZ(-3.13814878f) * Matrix.CreateTranslation(4.13568068f, 113.545135f, -52.18575f),
        Matrix.CreateScale(0.8014864f, 0.889643967f, 0.8014864f) * Matrix.CreateRotationX(-1.41908371f) * Matrix.CreateRotationY(1.27516329f) * Matrix.CreateRotationZ(-1.52323949f) * Matrix.CreateTranslation(5.67285442f, 109.98587f, -67.45575f),
        Matrix.CreateScale(0.8014864f, 0.889643967f, 0.8014864f) * Matrix.CreateRotationX(-1.183979f) * Matrix.CreateRotationY(1.5054332f) * Matrix.CreateRotationZ(-1.24831176f) * Matrix.CreateTranslation(4.72274351f, 119.357742f, -5.977935f),
        Matrix.CreateScale(0.8014864f, 0.889643967f, 0.8014864f) * Matrix.CreateRotationX(-0.332959741f) * Matrix.CreateRotationY(1.49797952f) * Matrix.CreateRotationZ(-0.349921733f) * Matrix.CreateTranslation(3.97533631f, 120.053413f, 14.6981878f),
        Matrix.CreateScale(0.8014864f, 0.889643967f, 0.8014864f) * Matrix.CreateRotationX(-1.76037729f) * Matrix.CreateRotationY(1.70192468f) * Matrix.CreateRotationZ(-1.82237446f) * Matrix.CreateTranslation(3.61256027f, 118.075409f, 35.3071175f),
        Matrix.CreateScale(0.8014864f, 0.889643967f, 0.8014864f) * Matrix.CreateRotationX(1.48485291f) * Matrix.CreateRotationY(1.27964461f) * Matrix.CreateRotationZ(1.42486668f) * Matrix.CreateTranslation(2.78207159f, 112.836037f, 55.7861748f),
        Matrix.CreateScale(0.58616364f, 0.5492081f, 0.519378841f) * Matrix.CreateRotationX(0.5534142f) * Matrix.CreateRotationY(1.11798716f) * Matrix.CreateRotationZ(5.935321f) * Matrix.CreateTranslation(30.431097f, 98.32836f, 44.1847649f),
        Matrix.CreateScale(0.6396528f, 0.6396528f, 0.6396528f) * Matrix.CreateRotationX(3.22826242f) * Matrix.CreateRotationY(1.04587257f) * Matrix.CreateRotationZ(8.801974f) * Matrix.CreateTranslation(23.5659237f, 110.713707f, 22.65279f),
        Matrix.CreateScale(0.5492081f, 0.352546334f, 0.5492081f) * Matrix.CreateRotationX(3.14461446f) * Matrix.CreateRotationY(0.443176657f) * Matrix.CreateRotationZ(8.622264f) * Matrix.CreateTranslation(31.7244244f, 103.454033f, 23.3423767f),
        Matrix.CreateScale(0.387121469f, 0.311443061f, 0.3594557f) * Matrix.CreateRotationX(2.67102575f) * Matrix.CreateRotationY(-0.7143527f) * Matrix.CreateRotationZ(8.833094f) * Matrix.CreateTranslation(30.0305214f, 96.0336151f, 51.1898727f),
        Matrix.CreateScale(0.6941537f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(2.8499496f) * Matrix.CreateRotationY(0.99365586f) * Matrix.CreateRotationZ(8.437673f) * Matrix.CreateTranslation(20.925108f, 108.702469f, 41.0659561f),
        Matrix.CreateScale(0.412663f, 0.352546334f, 0.3732656f) * Matrix.CreateRotationX(2.97896743f) * Matrix.CreateRotationY(0.499973327f) * Matrix.CreateRotationZ(8.476306f) * Matrix.CreateTranslation(34.5225754f, 99.08463f, 30.8145084f),
        Matrix.CreateScale(0.5492081f, 0.352546334f, 0.5492081f) * Matrix.CreateRotationX(3.02552414f) * Matrix.CreateRotationY(0.419903219f) * Matrix.CreateRotationZ(8.493059f) * Matrix.CreateTranslation(39.0413933f, 93.84401f, 24.51765f),
        Matrix.CreateScale(0.5492081f, 0.352546334f, 0.5492081f) * Matrix.CreateRotationX(3.533742f) * Matrix.CreateRotationY(-2.43152642f) * Matrix.CreateRotationZ(8.212889f) * Matrix.CreateTranslation(36.74667f, 93.65792f, 38.62052f),
        Matrix.CreateScale(0.6784089f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(0.0245869718f) * Matrix.CreateRotationY(2.39951968f) * Matrix.CreateRotationZ(1.17209339f) * Matrix.CreateTranslation(-42.3019562f, 83.67706f, -35.1966248f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(0.269153476f) * Matrix.CreateRotationY(2.16439342f) * Matrix.CreateRotationZ(1.50727689f) * Matrix.CreateTranslation(-44.94263f, 80.8478851f, -17.52322f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(3.272598f) * Matrix.CreateRotationY(-0.5911699f) * Matrix.CreateRotationZ(-2.22213936f) * Matrix.CreateTranslation(-36.4423332f, 97.77751f, -19.14101f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(0.3452033f) * Matrix.CreateRotationY(2.270528f) * Matrix.CreateRotationZ(1.33828139f) * Matrix.CreateTranslation(-40.2876472f, 89.78955f, -23.8843555f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(0.260376f) * Matrix.CreateRotationY(3.546283f) * Matrix.CreateRotationZ(0.973279f) * Matrix.CreateTranslation(-38.04717f, 91.24086f, -66.84701f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(0.09478507f) * Matrix.CreateRotationY(2.45678043f) * Matrix.CreateRotationZ(1.00920033f) * Matrix.CreateTranslation(-34.3561859f, 97.12025f, -47.25208f),
        Matrix.CreateScale(0.578982f, 0.461103082f, 0.857182264f) * Matrix.CreateRotationX(-0.0231657028f) * Matrix.CreateRotationY(-0.213910982f) * Matrix.CreateRotationZ(0.767155051f) * Matrix.CreateTranslation(-34.45692f, 97.82798f, -57.826355f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(0.105960749f) * Matrix.CreateRotationY(2.29681516f) * Matrix.CreateRotationZ(1.22746837f) * Matrix.CreateTranslation(-40.2988968f, 89.0999451f, -54.90931f),
        Matrix.CreateScale(0.883709967f, 0.8279952f, 0.7830241f) * Matrix.CreateRotationX(0.0129408846f) * Matrix.CreateRotationY(1.017281f) * Matrix.CreateRotationZ(0.9692761f) * Matrix.CreateTranslation(-38.7781944f, 96.4439545f, -5.145422f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(0.212690711f) * Matrix.CreateRotationY(2.0659883f) * Matrix.CreateRotationZ(1.35375762f) * Matrix.CreateTranslation(-43.77305f, 80.5562439f, -46.5087242f),
        Matrix.CreateScale(0.5492081f, 0.352546334f, 0.5492081f) * Matrix.CreateRotationX(0.0757202f) * Matrix.CreateRotationY(2.60298252f) * Matrix.CreateRotationZ(1.098416f) * Matrix.CreateTranslation(-39.798645f, 90.27742f, -43.6806335f),
        Matrix.CreateScale(0.387121469f, 0.311443061f, 0.3594557f) * Matrix.CreateRotationX(3.254875f) * Matrix.CreateRotationY(-0.559053838f) * Matrix.CreateRotationZ(-2.04531646f) * Matrix.CreateTranslation(-42.75852f, 89.67516f, -15.2941046f),
        Matrix.CreateScale(0.6941537f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(0.183773354f) * Matrix.CreateRotationY(1.959056f) * Matrix.CreateRotationZ(1.358342f) * Matrix.CreateTranslation(-45.1450272f, 76.98852f, -28.5967617f),
        Matrix.CreateScale(0.412663f, 0.352546334f, 0.3732656f) * Matrix.CreateRotationX(0.07876453f) * Matrix.CreateRotationY(2.43462873f) * Matrix.CreateRotationZ(1.1105181f) * Matrix.CreateTranslation(-37.7492142f, 93.0274353f, -36.0304642f),
        Matrix.CreateScale(0.5492081f, 0.352546334f, 0.5492081f) * Matrix.CreateRotationX(0.114633724f) * Matrix.CreateRotationY(2.51598859f) * Matrix.CreateRotationZ(1.10527289f) * Matrix.CreateTranslation(-32.8451f, 99.3442154f, -40.4208527f),
        Matrix.CreateScale(0.5492081f, 0.352546334f, 0.5492081f) * Matrix.CreateRotationX(0.0124984039f) * Matrix.CreateRotationY(-0.9433144f) * Matrix.CreateRotationZ(0.9398156f) * Matrix.CreateTranslation(-35.6935f, 96.38744f, -28.3416367f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(3.060085f) * Matrix.CreateRotationY(1.04354f) * Matrix.CreateRotationZ(-2.05997443f) * Matrix.CreateTranslation(-45.6720428f, 75.31387f, -57.09627f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(0.105960749f) * Matrix.CreateRotationY(2.29681516f) * Matrix.CreateRotationZ(1.22746837f) * Matrix.CreateTranslation(-43.4348335f, 82.93181f, -62.781208f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(0.339723766f) * Matrix.CreateRotationY(2.1147f) * Matrix.CreateRotationZ(1.50541687f) * Matrix.CreateTranslation(-47.18694f, 71.3023453f, -14.4043274f),
        Matrix.CreateScale(0.412663f, 0.352546334f, 0.3732656f) * Matrix.CreateRotationX(0.03809634f) * Matrix.CreateRotationY(1.81182611f) * Matrix.CreateRotationZ(1.30559993f) * Matrix.CreateTranslation(-47.0175362f, 71.64015f, -38.118782f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(0.276080757f) * Matrix.CreateRotationY(2.0219f) * Matrix.CreateRotationZ(1.51192939f) * Matrix.CreateTranslation(-46.2914619f, 71.87676f, -25.7265148f),
        Matrix.CreateScale(0.412663f, 0.352546334f, 0.3732656f) * Matrix.CreateRotationX(0.03809634f) * Matrix.CreateRotationY(1.81182611f) * Matrix.CreateRotationZ(1.30559993f) * Matrix.CreateTranslation(-46.56113f, 72.85199f, -46.375103f),
        Matrix.CreateScale(0.5793862f, 0.470134377f, 0.5793862f) * Matrix.CreateRotationX(3.0626905f) * Matrix.CreateRotationY(0.59309727f) * Matrix.CreateRotationZ(2.73437667f) * Matrix.CreateTranslation(12.1258793f, 117.642372f, 25.3902626f),
        Matrix.CreateScale(0.484010428f, 0.3927431f, 0.484010428f) * Matrix.CreateRotationX(3.17353463f) * Matrix.CreateRotationY(0.563424468f) * Matrix.CreateRotationZ(2.79592f) * Matrix.CreateTranslation(13.84377f, 118.506981f, 5.44623375f),
        Matrix.CreateScale(0.5877558f, 0.4769258f, 0.5877558f) * Matrix.CreateRotationX(-3.04326749f) * Matrix.CreateRotationY(0.6191079f) * Matrix.CreateRotationZ(2.83094573f) * Matrix.CreateTranslation(13.76582f, 118.116684f, -15.7094707f),
        Matrix.CreateScale(0.5521139f, 0.448004663f, 0.5521139f) * Matrix.CreateRotationX(-2.895909f) * Matrix.CreateRotationY(0.6625589f) * Matrix.CreateRotationZ(2.92341852f) * Matrix.CreateTranslation(13.3342571f, 115.250786f, -39.6645927f),
        Matrix.CreateScale(0.548612654f, 0.445163637f, 0.548612654f) * Matrix.CreateRotationX(3.47416186f) * Matrix.CreateRotationY(0.5807329f) * Matrix.CreateRotationZ(3.06496143f) * Matrix.CreateTranslation(14.6940374f, 111.059853f, -57.7840538f),
        Matrix.CreateScale(0.484010428f, 0.3927431f, 0.484010428f) * Matrix.CreateRotationX(2.94277716f) * Matrix.CreateRotationY(0.602257133f) * Matrix.CreateRotationZ(2.74331117f) * Matrix.CreateTranslation(11.0757723f, 114.226006f, 45.7980957f),
        Matrix.CreateScale(0.576153338f, 0.467511117f, 0.576153338f) * Matrix.CreateRotationX(2.836445f) * Matrix.CreateRotationY(0.571453035f) * Matrix.CreateRotationZ(2.492016f) * Matrix.CreateTranslation(13.3570862f, 110.510452f, 53.780468f),
        Matrix.CreateScale(0.56409657f, 0.457727849f, 0.56409657f) * Matrix.CreateRotationX(2.89621949f) * Matrix.CreateRotationY(0.5944767f) * Matrix.CreateRotationZ(2.56794119f) * Matrix.CreateTranslation(14.3409643f, 116.055374f, 36.0304222f),
        Matrix.CreateScale(0.484010428f, 0.3927431f, 0.484010428f) * Matrix.CreateRotationX(3.17353463f) * Matrix.CreateRotationY(0.563424468f) * Matrix.CreateRotationZ(2.79592f) * Matrix.CreateTranslation(13.6000366f, 117.649658f, 17.0699463f),
        Matrix.CreateScale(0.484010428f, 0.3927431f, 0.484010428f) * Matrix.CreateRotationX(3.088904f) * Matrix.CreateRotationY(0.596482754f) * Matrix.CreateRotationZ(2.583408f) * Matrix.CreateTranslation(20.2427273f, 114.121719f, 11.9975348f),
        Matrix.CreateScale(0.484010428f, 0.3927431f, 0.484010428f) * Matrix.CreateRotationX(0.022594044f) * Matrix.CreateRotationY(-0.5566799f) * Matrix.CreateRotationZ(5.822581f) * Matrix.CreateTranslation(14.2455711f, 118.028893f, -2.70445f),
        Matrix.CreateScale(0.484010428f, 0.3927431f, 0.484010428f) * Matrix.CreateRotationX(3.465098f) * Matrix.CreateRotationY(0.5890991f) * Matrix.CreateRotationZ(2.97249627f) * Matrix.CreateTranslation(16.63063f, 108.239891f, -65.59853f),
        Matrix.CreateScale(0.5401568f, 0.438302249f, 0.5401568f) * Matrix.CreateRotationX(-2.895909f) * Matrix.CreateRotationY(0.6625589f) * Matrix.CreateRotationZ(2.92341852f) * Matrix.CreateTranslation(17.2245483f, 112.039383f, -47.7588234f),
        Matrix.CreateScale(0.484010428f, 0.3927431f, 0.484010428f) * Matrix.CreateRotationX(-2.88901544f) * Matrix.CreateRotationY(0.6743725f) * Matrix.CreateRotationZ(2.87906241f) * Matrix.CreateTranslation(16.056366f, 114.953568f, -30.533741f),
        Matrix.CreateScale(0.294127584f, 0.238665491f, 0.294127584f) * Matrix.CreateRotationX(-2.895909f) * Matrix.CreateRotationY(0.6625589f) * Matrix.CreateRotationZ(2.92341852f) * Matrix.CreateTranslation(14.0795069f, 117.761925f, -23.1030331f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(0.481634468f) * Matrix.CreateRotationY(-1.22178769f) * Matrix.CreateRotationZ(10.8561287f) * Matrix.CreateTranslation(46.0641937f, 74.32302f, 31.3722019f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(3.23758054f) * Matrix.CreateRotationY(-0.5807444f) * Matrix.CreateRotationZ(8.146708f) * Matrix.CreateTranslation(48.9501648f, 72.65733f, -5.47698927f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(2.99375f) * Matrix.CreateRotationY(0.6162873f) * Matrix.CreateRotationZ(1.761059f) * Matrix.CreateTranslation(42.96185f, 83.41237f, 33.57761f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(0.3648104f) * Matrix.CreateRotationY(-1.21297491f) * Matrix.CreateRotationZ(-1.552406f) * Matrix.CreateTranslation(44.2900429f, 84.41099f, 23.5517769f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(0.315245926f) * Matrix.CreateRotationY(-1.23193824f) * Matrix.CreateRotationZ(-1.46991885f) * Matrix.CreateTranslation(44.68848f, 84.60289f, 12.0386944f),
        Matrix.CreateScale(0.631728947f, 0.5492081f, 0.6019117f) * Matrix.CreateRotationX(-0.0241778977f) * Matrix.CreateRotationY(-1.04054713f) * Matrix.CreateRotationZ(-1.12483537f) * Matrix.CreateTranslation(45.8196564f, 84.02553f, 1.8935523f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-3.00391364f) * Matrix.CreateRotationY(-0.6034175f) * Matrix.CreateRotationZ(1.88846719f) * Matrix.CreateTranslation(45.05016f, 82.9193649f, -12.6199379f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-2.92893672f) * Matrix.CreateRotationY(-0.625863f) * Matrix.CreateRotationZ(1.81393719f) * Matrix.CreateTranslation(43.7851028f, 81.59443f, -25.3314171f),
        Matrix.CreateScale(0.6845234f, 0.6845234f, 0.6845234f) * Matrix.CreateRotationX(-3.07337785f) * Matrix.CreateRotationY(-0.6034175f) * Matrix.CreateRotationZ(1.88846719f) * Matrix.CreateTranslation(42.03446f, 82.19244f, -36.8204651f),
        Matrix.CreateScale(0.460648417f, 0.276732147f, 0.287635863f) * Matrix.CreateRotationX(2.72315764f) * Matrix.CreateRotationY(0.9055733f) * Matrix.CreateRotationZ(1.56459939f) * Matrix.CreateTranslation(41.055378f, 81.84674f, 45.17037f),
        Matrix.CreateScale(0.8014864f, 0.889643967f, 0.8014864f) * Matrix.CreateRotationX(-1.33621025f) * Matrix.CreateRotationY(1.4607451f) * Matrix.CreateRotationZ(4.2820363f) * Matrix.CreateTranslation(24.133646f, 109.806808f, -17.7168388f),
        Matrix.CreateScale(0.8014864f, 0.889643967f, 0.8014864f) * Matrix.CreateRotationX(-2.09716582f) * Matrix.CreateRotationY(1.49106908f) * Matrix.CreateRotationZ(3.30579519f) * Matrix.CreateTranslation(33.4358673f, 101.233795f, -9.457364f),
        Matrix.CreateScale(0.3885317f, 0.315268338f, 0.3885317f) * Matrix.CreateRotationX(3.096028f) * Matrix.CreateRotationY(-0.295833915f) * Matrix.CreateRotationZ(2.62631583f) * Matrix.CreateTranslation(21.1782646f, 114.628716f, -8.859396f),
        Matrix.CreateScale(0.582323432f, 0.5218734f, 0.582323432f) * Matrix.CreateRotationX(3.11402154f) * Matrix.CreateRotationY(-0.329172075f) * Matrix.CreateRotationZ(2.57956076f) * Matrix.CreateTranslation(21.881813f, 112.934059f, 0.6908919f),
        Matrix.CreateScale(0.6784089f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(2.81837463f) * Matrix.CreateRotationY(-0.5714998f) * Matrix.CreateRotationZ(-2.112944f) * Matrix.CreateTranslation(-31.7153835f, 100.815147f, 35.92108f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(2.949118f) * Matrix.CreateRotationY(-0.246607f) * Matrix.CreateRotationZ(-2.283821f) * Matrix.CreateTranslation(-18.4591465f, 111.294945f, 42.88511f),
        Matrix.CreateScale(0.7685885f, 0.7685885f, 0.7685885f) * Matrix.CreateRotationX(0.994030356f) * Matrix.CreateRotationY(-1.39923918f) * Matrix.CreateRotationZ(-0.409165084f) * Matrix.CreateTranslation(-17.6752071f, 114.617744f, 21.6664314f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(3.01441836f) * Matrix.CreateRotationY(-0.3796233f) * Matrix.CreateRotationZ(-2.43026662f) * Matrix.CreateTranslation(-23.3144455f, 109.165276f, 32.488f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(0.571567f) * Matrix.CreateRotationY(-1.38899338f) * Matrix.CreateRotationZ(0.5293887f) * Matrix.CreateTranslation(-47.05853f, 77.58652f, 19.9087276f),
        Matrix.CreateScale(0.631282f, 0.631282f, 0.631282f) * Matrix.CreateRotationX(3.03882623f) * Matrix.CreateRotationY(-0.6493934f) * Matrix.CreateRotationZ(-2.1356833f) * Matrix.CreateTranslation(-38.62055f, 95.844635f, 18.07455f),
        Matrix.CreateScale(0.5492081f, 0.349748641f, 0.5492081f) * Matrix.CreateRotationX(-0.3269507f) * Matrix.CreateRotationY(1.81697774f) * Matrix.CreateRotationZ(0.750733733f) * Matrix.CreateTranslation(-44.21431f, 88.83822f, 12.0261793f),
        Matrix.CreateScale(0.5752881f, 0.5752881f, 0.5752881f) * Matrix.CreateRotationX(3.12106276f) * Matrix.CreateRotationY(-0.5292624f) * Matrix.CreateRotationZ(-1.92983663f) * Matrix.CreateTranslation(-42.8579025f, 87.22709f, 23.1924133f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(2.95267367f) * Matrix.CreateRotationY(-0.189679146f) * Matrix.CreateRotationZ(-2.06250763f) * Matrix.CreateTranslation(-38.31622f, 91.21098f, 36.39579f),
        Matrix.CreateScale(0.5492081f, 0.352546334f, 0.5492081f) * Matrix.CreateRotationX(2.92301941f) * Matrix.CreateRotationY(-0.7858745f) * Matrix.CreateRotationZ(-2.07197976f) * Matrix.CreateTranslation(-36.93455f, 96.6414948f, 27.1882744f),
        Matrix.CreateScale(0.387121469f, 0.311443061f, 0.3594557f) * Matrix.CreateRotationX(0.5746365f) * Matrix.CreateRotationY(-0.983498335f) * Matrix.CreateRotationZ(0.112267375f) * Matrix.CreateTranslation(-15.6647692f, 115.161758f, 34.9907951f),
        Matrix.CreateScale(0.6941537f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(2.89830947f) * Matrix.CreateRotationY(-0.136871144f) * Matrix.CreateRotationZ(-2.226478f) * Matrix.CreateTranslation(-26.5489712f, 102.563683f, 44.1139069f),
        Matrix.CreateScale(0.412663f, 0.352546334f, 0.3732656f) * Matrix.CreateRotationX(2.99500871f) * Matrix.CreateRotationY(-0.6311514f) * Matrix.CreateRotationZ(-2.21288323f) * Matrix.CreateTranslation(-32.4683342f, 103.553543f, 25.78184f),
        Matrix.CreateScale(0.631282f, 0.405231029f, 0.631282f) * Matrix.CreateRotationX(3.02260661f) * Matrix.CreateRotationY(-0.71131897f) * Matrix.CreateRotationZ(-2.19438267f) * Matrix.CreateTranslation(-32.0091972f, 104.646706f, 13.76978f),
        Matrix.CreateScale(0.5492081f, 0.352546334f, 0.5492081f) * Matrix.CreateRotationX(0.0285668969f) * Matrix.CreateRotationY(0.410650373f) * Matrix.CreateRotationZ(0.763514f) * Matrix.CreateTranslation(-26.55525f, 109.609993f, 23.534729f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(2.92672729f) * Matrix.CreateRotationY(-0.017405048f) * Matrix.CreateRotationZ(-2.03903937f) * Matrix.CreateTranslation(-43.7397041f, 79.6306839f, 40.7117157f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(3.13417363f) * Matrix.CreateRotationY(-0.2534797f) * Matrix.CreateRotationZ(-2.09261322f) * Matrix.CreateTranslation(-45.4441f, 78.40346f, 30.2888279f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(2.83875f) * Matrix.CreateRotationY(-0.162640974f) * Matrix.CreateRotationZ(-2.28299856f) * Matrix.CreateTranslation(-15.6019316f, 110.015648f, 54.8467026f),
        Matrix.CreateScale(0.412663f, 0.352546334f, 0.3732656f) * Matrix.CreateRotationX(2.8501997f) * Matrix.CreateRotationY(0.0492279865f) * Matrix.CreateRotationZ(-2.24041557f) * Matrix.CreateTranslation(-32.3878632f, 93.54818f, 49.37319f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(2.83745217f) * Matrix.CreateRotationY(-0.161590621f) * Matrix.CreateRotationZ(-2.14050364f) * Matrix.CreateTranslation(-23.5579586f, 102.49102f, 51.5799561f),
        Matrix.CreateScale(0.412663f, 0.352546334f, 0.3732656f) * Matrix.CreateRotationX(2.91775346f) * Matrix.CreateRotationY(0.123767324f) * Matrix.CreateRotationZ(-2.18019366f) * Matrix.CreateTranslation(-38.58807f, 87.418335f, 46.3565178f),
        Matrix.CreateScale(0.603401363f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-0.07980949f) * Matrix.CreateRotationY(-1.13517785f) * Matrix.CreateRotationZ(-0.6748722f) * Matrix.CreateTranslation(36.8435326f, 91.67015f, -64.6669846f),
        Matrix.CreateScale(0.3719859f, 0.3719859f, 0.3719859f) * Matrix.CreateRotationX(3.06345367f) * Matrix.CreateRotationY(-0.4657729f) * Matrix.CreateRotationZ(-1.80828631f) * Matrix.CreateTranslation(-50.0302734f, 71.13418f, 22.2965469f),
        Matrix.CreateScale(0.3719859f, 0.3719859f, 0.3719859f) * Matrix.CreateRotationX(3.00172138f) * Matrix.CreateRotationY(-0.5292588f) * Matrix.CreateRotationZ(-1.82272124f) * Matrix.CreateTranslation(-48.65056f, 71.23681f, 30.5375977f),
        Matrix.CreateScale(0.3719859f, 0.3719859f, 0.3719859f) * Matrix.CreateRotationX(2.97454667f) * Matrix.CreateRotationY(-0.5230291f) * Matrix.CreateRotationZ(-1.7606051f) * Matrix.CreateTranslation(-46.34685f, 71.58137f, 38.7975426f),
        Matrix.CreateScale(0.603401363f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-0.196208552f) * Matrix.CreateRotationY(-1.618147f) * Matrix.CreateRotationZ(-0.9977801f) * Matrix.CreateTranslation(42.6679649f, 82.9725342f, -60.70823f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(3.07579613f) * Matrix.CreateRotationY(1.259747f) * Matrix.CreateRotationZ(8.194264f) * Matrix.CreateTranslation(46.3608627f, 73.90459f, -56.553f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(0.0624242723f) * Matrix.CreateRotationY(1.125631f) * Matrix.CreateRotationZ(5.199453f) * Matrix.CreateTranslation(46.53683f, 70.44083f, -42.2462425f),
        Matrix.CreateScale(0.9503381f, 0.6749803f, 0.8673502f) * Matrix.CreateRotationX(-2.89610362f) * Matrix.CreateRotationY(-1.41053152f) * Matrix.CreateRotationZ(-3.0920403f) * Matrix.CreateTranslation(-13.3475008f, 117.807671f, -17.47968f),
        Matrix.CreateScale(0.82678324f, 0.5872251f, 0.7545847f) * Matrix.CreateRotationX(-3.36217856f) * Matrix.CreateRotationY(-1.41148412f) * Matrix.CreateRotationZ(-2.62017083f) * Matrix.CreateTranslation(-13.8074694f, 117.8573f, 3.927928f),
        Matrix.CreateScale(0.651777148f, 0.36413002f, 0.467907369f) * Matrix.CreateRotationX(-3.58621264f) * Matrix.CreateRotationY(-1.40528679f) * Matrix.CreateRotationZ(-2.410742f) * Matrix.CreateTranslation(-9.44646f, 118.132675f, 25.1415367f),
        Matrix.CreateScale(0.651777148f, 0.36413002f, 0.467907369f) * Matrix.CreateRotationX(-4.834741f) * Matrix.CreateRotationY(-1.32808423f) * Matrix.CreateRotationZ(-1.21329832f) * Matrix.CreateTranslation(-10.3276377f, 115.157944f, 44.81575f),
        Matrix.CreateScale(0.9503381f, 0.6749803f, 0.8673502f) * Matrix.CreateRotationX(-2.59026122f) * Matrix.CreateRotationY(-1.33134162f) * Matrix.CreateRotationZ(-3.40290022f) * Matrix.CreateTranslation(-13.066761f, 114.462967f, -38.3103027f),
        Matrix.CreateScale(0.693231761f, 0.4923698f, 0.6326956f) * Matrix.CreateRotationX(-1.9461199f) * Matrix.CreateRotationY(-1.34030008f) * Matrix.CreateRotationZ(-4.053498f) * Matrix.CreateTranslation(-12.1037569f, 111.960114f, -57.2832f),
        Matrix.CreateScale(0.639163554f, 0.352546334f, 0.5492081f) * Matrix.CreateRotationX(3.10718417f) * Matrix.CreateRotationY(-0.249224633f) * Matrix.CreateRotationZ(-2.39527059f) * Matrix.CreateTranslation(-24.018898f, 113.888084f, 0.627713859f),
        Matrix.CreateScale(0.5492081f, 0.352546334f, 0.5492081f) * Matrix.CreateRotationX(3.16276979f) * Matrix.CreateRotationY(-0.832935452f) * Matrix.CreateRotationZ(-2.53738928f) * Matrix.CreateTranslation(-23.7381f, 113.193375f, -10.0974417f),
        Matrix.CreateScale(0.631282f, 0.405231029f, 0.631282f) * Matrix.CreateRotationX(3.02260661f) * Matrix.CreateRotationY(-0.71131897f) * Matrix.CreateRotationZ(-2.19438267f) * Matrix.CreateTranslation(-31.5920887f, 105.759079f, -7.283146f),
        Matrix.CreateScale(0.5492081f, 0.352546334f, 0.5492081f) * Matrix.CreateRotationX(3.02260661f) * Matrix.CreateRotationY(-0.71131897f) * Matrix.CreateRotationZ(-2.19438267f) * Matrix.CreateTranslation(-33.0450325f, 103.719727f, 3.152794f),
        Matrix.CreateScale(0.5492081f, 0.352546334f, 0.5492081f) * Matrix.CreateRotationX(3.046901f) * Matrix.CreateRotationY(-0.8331882f) * Matrix.CreateRotationZ(-2.433287f) * Matrix.CreateTranslation(-24.5111446f, 112.25528f, 12.3322439f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(0.269153476f) * Matrix.CreateRotationY(2.16439342f) * Matrix.CreateRotationZ(1.50727689f) * Matrix.CreateTranslation(-45.938446f, 82.5847855f, -5.234365f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(0.339723766f) * Matrix.CreateRotationY(2.1147f) * Matrix.CreateRotationZ(1.50541687f) * Matrix.CreateTranslation(-48.9604645f, 72.7186661f, -4.006808f),
        Matrix.CreateScale(0.684721351f, 0.684721351f, 0.684721351f) * Matrix.CreateRotationX(-2.96506429f) * Matrix.CreateRotationY(-0.6245846f) * Matrix.CreateRotationZ(1.99538589f) * Matrix.CreateTranslation(39.9966545f, 91.09647f, -22.2549229f),
        Matrix.CreateScale(0.5965378f, 0.5965378f, 0.5965378f) * Matrix.CreateRotationX(-3.02865386f) * Matrix.CreateRotationY(-0.6447598f) * Matrix.CreateRotationZ(2.07481384f) * Matrix.CreateTranslation(42.1131f, 94.73886f, -7.857341f),
        Matrix.CreateScale(0.5492081f, 0.349748641f, 0.5492081f) * Matrix.CreateRotationX(3.12205672f) * Matrix.CreateRotationY(2.60455275f) * Matrix.CreateRotationZ(8.436325f) * Matrix.CreateTranslation(41.4682121f, 91.99784f, 6.761472f),
        Matrix.CreateScale(0.5492081f, 0.349748641f, 0.5492081f) * Matrix.CreateRotationX(3.12205672f) * Matrix.CreateRotationY(2.60455275f) * Matrix.CreateRotationZ(8.436325f) * Matrix.CreateTranslation(42.27822f, 90.6081161f, 17.14855f),
        Matrix.CreateScale(0.8014864f, 0.889643967f, 0.8014864f) * Matrix.CreateRotationX(-1.48936939f) * Matrix.CreateRotationY(1.43918264f) * Matrix.CreateRotationZ(3.98103f) * Matrix.CreateTranslation(28.3759727f, 101.370735f, -45.4003143f),
        Matrix.CreateScale(0.484010428f, 0.3927431f, 0.484010428f) * Matrix.CreateRotationX(3.465098f) * Matrix.CreateRotationY(0.5890991f) * Matrix.CreateRotationZ(2.97249627f) * Matrix.CreateTranslation(17.5437012f, 106.627632f, -72.68181f),
        Matrix.CreateScale(0.597806752f, 0.597806752f, 0.597806752f) * Matrix.CreateRotationX(-1.10213661f) * Matrix.CreateRotationY(-1.41947961f) * Matrix.CreateRotationZ(0.317777127f) * Matrix.CreateTranslation(23.5798531f, 105.947083f, -60.53807f),
        Matrix.CreateScale(0.603401363f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-0.07980949f) * Matrix.CreateRotationY(-1.13517785f) * Matrix.CreateRotationZ(-0.6748722f) * Matrix.CreateTranslation(30.8784924f, 97.6306839f, -55.2084579f),
        Matrix.CreateScale(0.670048058f, 0.4267024f, 0.670048058f) * Matrix.CreateRotationX(-0.09178543f) * Matrix.CreateRotationY(0.329120636f) * Matrix.CreateRotationZ(0.5163088f) * Matrix.CreateTranslation(-20.0322742f, 109.846985f, -54.9661f),
        Matrix.CreateScale(0.695536733f, 0.695536733f, 0.695536733f) * Matrix.CreateRotationX(0.156375825f) * Matrix.CreateRotationY(2.466111f) * Matrix.CreateRotationZ(0.7724612f) * Matrix.CreateTranslation(-28.6648426f, 103.80397f, -53.4953651f),
        Matrix.CreateScale(0.7340461f, 0.471197128f, 0.7340461f) * Matrix.CreateRotationX(0.172091886f) * Matrix.CreateRotationY(2.52974367f) * Matrix.CreateRotationZ(0.8631235f) * Matrix.CreateTranslation(-22.2286129f, 110.261139f, -41.57115f),
        Matrix.CreateScale(0.7464699f, 0.4791722f, 0.7464699f) * Matrix.CreateRotationX(-0.06945549f) * Matrix.CreateRotationY(-0.9366604f) * Matrix.CreateRotationZ(0.7305289f) * Matrix.CreateTranslation(-28.2606926f, 106.73951f, -27.3626747f),
        Matrix.CreateScale(0.93094337f, 0.93094337f, 0.93094337f) * Matrix.CreateRotationX(0.189695492f) * Matrix.CreateRotationY(3.73602271f) * Matrix.CreateRotationZ(0.611175537f) * Matrix.CreateTranslation(-25.1375141f, 108.870872f, -19.9506054f),
        Matrix.CreateScale(0.615097344f, 0.3917085f, 0.615097344f) * Matrix.CreateRotationX(-0.283041924f) * Matrix.CreateRotationY(0.7407013f) * Matrix.CreateRotationZ(0.308232456f) * Matrix.CreateTranslation(-25.4068871f, 104.124062f, -67.50924f),
        Matrix.CreateScale(0.5492081f, 0.349748641f, 0.5492081f) * Matrix.CreateRotationX(-0.334705532f) * Matrix.CreateRotationY(0.710084f) * Matrix.CreateRotationZ(0.124512278f) * Matrix.CreateTranslation(-13.5946741f, 109.206841f, -68.9638443f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(0.571567f) * Matrix.CreateRotationY(-1.38899338f) * Matrix.CreateRotationZ(0.5293887f) * Matrix.CreateTranslation(-47.6251068f, 77.88855f, 8.258694f),
        Matrix.CreateScale(0.3719859f, 0.3719859f, 0.3719859f) * Matrix.CreateRotationX(3.06345367f) * Matrix.CreateRotationY(-0.4657729f) * Matrix.CreateRotationZ(-1.80828631f) * Matrix.CreateTranslation(-50.5928345f, 71.034f, 13.52861f),
        Matrix.CreateScale(0.3719859f, 0.3719859f, 0.3719859f) * Matrix.CreateRotationX(3.06345367f) * Matrix.CreateRotationY(-0.4657729f) * Matrix.CreateRotationZ(-1.80828631f) * Matrix.CreateTranslation(-51.0846329f, 70.933815f, 5.951716f),
        Matrix.CreateScale(0.631282f, 0.402015239f, 0.631282f) * Matrix.CreateRotationX(-0.3269507f) * Matrix.CreateRotationY(1.81697774f) * Matrix.CreateRotationZ(0.750733733f) * Matrix.CreateTranslation(-39.0427132f, 96.93261f, 5.94301462f),
        Matrix.CreateScale(0.5492081f, 0.349748641f, 0.5492081f) * Matrix.CreateRotationX(-0.3269507f) * Matrix.CreateRotationY(1.81697774f) * Matrix.CreateRotationZ(0.750733733f) * Matrix.CreateTranslation(-43.7638435f, 89.63663f, 2.80486655f),
        Matrix.CreateScale(0.6668183f, 0.6668183f, 0.6668183f) * Matrix.CreateRotationX(-2.998355f) * Matrix.CreateRotationY(0.6572863f) * Matrix.CreateRotationZ(2.05482054f) * Matrix.CreateTranslation(36.8839264f, 96.0884247f, -34.18301f),
        Matrix.CreateScale(0.412663f, 0.352546334f, 0.3732656f) * Matrix.CreateRotationX(2.91775346f) * Matrix.CreateRotationY(0.123767324f) * Matrix.CreateRotationZ(-2.18019366f) * Matrix.CreateTranslation(-42.52037f, 86.58178f, 33.8376274f),
        Matrix.CreateScale(0.5942891f, 0.5492081f, 0.7608631f) * Matrix.CreateRotationX(3.455039f) * Matrix.CreateRotationY(1.23790956f) * Matrix.CreateRotationZ(8.794167f) * Matrix.CreateTranslation(38.6970062f, 91.67688f, -43.3827744f),
        Matrix.CreateScale(0.8014864f, 0.889643967f, 0.8014864f) * Matrix.CreateRotationX(-2.09716582f) * Matrix.CreateRotationY(1.49106908f) * Matrix.CreateRotationZ(3.30579519f) * Matrix.CreateTranslation(34.5718956f, 97.83498f, -22.11409f)
      };
      for (int index = 0; index < 148; ++index)
        this.dropChunk(ref this.chunk, matrixArray1[index], 3);
      Matrix[] matrixArray2 = new Matrix[55]
      {
        Matrix.CreateScale(0.387121469f, 0.311443061f, 0.3594557f) * Matrix.CreateRotationX(2.17468643f) * Matrix.CreateRotationY(0.8770141f) * Matrix.CreateRotationZ(8.594833f) * Matrix.CreateTranslation(-5.556709f, 95.53957f, 113.717514f),
        Matrix.CreateScale(0.387121469f, 0.311443061f, 0.3594557f) * Matrix.CreateRotationX(1.08032453f) * Matrix.CreateRotationY(0.881698132f) * Matrix.CreateRotationZ(7.14294863f) * Matrix.CreateTranslation(0.753327131f, 94.15164f, 115.563393f),
        Matrix.CreateScale(0.387121469f, 0.311443061f, 0.3594557f) * Matrix.CreateRotationX(2.19257855f) * Matrix.CreateRotationY(0.809269965f) * Matrix.CreateRotationZ(8.528606f) * Matrix.CreateTranslation(8.087221f, 94.3279343f, 115.592018f),
        Matrix.CreateScale(0.387121469f, 0.311443061f, 0.3594557f) * Matrix.CreateRotationX(1.85146809f) * Matrix.CreateRotationY(0.244931787f) * Matrix.CreateRotationZ(8.385155f) * Matrix.CreateTranslation(6.296268f, 88.39294f, 119.941216f),
        Matrix.CreateScale(0.303020269f, 0.2437828f, 0.2813648f) * Matrix.CreateRotationX(1.32291651f) * Matrix.CreateRotationY(0.2780876f) * Matrix.CreateRotationZ(6.76889849f) * Matrix.CreateTranslation(4.963311f, 81.00862f, 122.748f),
        Matrix.CreateScale(0.387121469f, 0.311443061f, 0.3594557f) * Matrix.CreateRotationX(3.12781835f) * Matrix.CreateRotationY(1.14049757f) * Matrix.CreateRotationZ(3.30424476f) * Matrix.CreateTranslation(-8.444035f, 98.070816f, 106.502151f),
        Matrix.CreateScale(0.387121469f, 0.311443061f, 0.3594557f) * Matrix.CreateRotationX(0.4566107f) * Matrix.CreateRotationY(1.15040934f) * Matrix.CreateRotationZ(0.384272665f) * Matrix.CreateTranslation(-1.83997548f, 98.51286f, 108.111588f),
        Matrix.CreateScale(0.387121469f, 0.311443061f, 0.3594557f) * Matrix.CreateRotationX(2.80863929f) * Matrix.CreateRotationY(1.05380261f) * Matrix.CreateRotationZ(2.61915731f) * Matrix.CreateTranslation(5.449545f, 97.3282242f, 108.069359f),
        Matrix.CreateScale(0.3891732f, 0.3130937f, 0.3613608f) * Matrix.CreateRotationX(3.10042048f) * Matrix.CreateRotationY(-0.162769973f) * Matrix.CreateRotationZ(2.52533484f) * Matrix.CreateTranslation(10.8312788f, 94.28727f, 108.138664f),
        Matrix.CreateScale(0.2431268f, 0.195597917f, 0.225751653f) * Matrix.CreateRotationX(3.28132367f) * Matrix.CreateRotationY(1.03199363f) * Matrix.CreateRotationZ(3.24044466f) * Matrix.CreateTranslation(-5.17261028f, 98.36752f, 101.402527f),
        Matrix.CreateScale(0.2431268f, 0.195597917f, 0.225751653f) * Matrix.CreateRotationX(3.28132367f) * Matrix.CreateRotationY(1.03199363f) * Matrix.CreateRotationZ(3.24044466f) * Matrix.CreateTranslation(0.287984073f, 99.15402f, 101.459557f),
        Matrix.CreateScale(0.2431268f, 0.195597917f, 0.225751653f) * Matrix.CreateRotationX(3.28132367f) * Matrix.CreateRotationY(1.03199363f) * Matrix.CreateRotationZ(3.24044466f) * Matrix.CreateTranslation(5.59440756f, 98.32128f, 102.308f),
        Matrix.CreateScale(0.2431268f, 0.195597917f, 0.225751653f) * Matrix.CreateRotationX(3.08357882f) * Matrix.CreateRotationY(0.9019291f) * Matrix.CreateRotationZ(2.51923966f) * Matrix.CreateTranslation(9.48187f, 95.96213f, 103.356361f),
        Matrix.CreateScale(0.387121469f, 0.311443061f, 0.3594557f) * Matrix.CreateRotationX(3.253598f) * Matrix.CreateRotationY(1.20918322f) * Matrix.CreateRotationZ(4.215438f) * Matrix.CreateTranslation(-14.6232471f, 94.2606049f, 105.853333f),
        Matrix.CreateScale(0.2431268f, 0.195597917f, 0.225751653f) * Matrix.CreateRotationX(3.049706f) * Matrix.CreateRotationY(4.28206968f) * Matrix.CreateRotationZ(3.81762719f) * Matrix.CreateTranslation(-11.0320444f, 97.20025f, 101.990822f),
        Matrix.CreateScale(0.2431268f, 0.195597917f, 0.225751653f) * Matrix.CreateRotationX(3.049706f) * Matrix.CreateRotationY(4.28206968f) * Matrix.CreateRotationZ(3.81762719f) * Matrix.CreateTranslation(-14.948451f, 94.52942f, 101.474228f),
        Matrix.CreateScale(0.2431268f, 0.195597917f, 0.225751653f) * Matrix.CreateRotationX(1.66727865f) * Matrix.CreateRotationY(3.58450246f) * Matrix.CreateRotationZ(4.80943f) * Matrix.CreateTranslation(-31.6333923f, 103.890709f, 110.791351f),
        Matrix.CreateScale(0.2431268f, 0.195597917f, 0.225751653f) * Matrix.CreateRotationX(1.019545f) * Matrix.CreateRotationY(4.10219f) * Matrix.CreateRotationZ(5.13915157f) * Matrix.CreateTranslation(-26.2689972f, 104.279488f, 111.54248f),
        Matrix.CreateScale(0.2431268f, 0.195597917f, 0.225751653f) * Matrix.CreateRotationX(0.808886051f) * Matrix.CreateRotationY(4.245341f) * Matrix.CreateRotationZ(5.307986f) * Matrix.CreateTranslation(-21.1838951f, 103.282593f, 111.698807f),
        Matrix.CreateScale(0.3296346f, 0.2651943f, 0.306077152f) * Matrix.CreateRotationX(1.66727865f) * Matrix.CreateRotationY(3.58450246f) * Matrix.CreateRotationZ(4.80943f) * Matrix.CreateTranslation(-29.352356f, 98.80729f, 108.143066f),
        Matrix.CreateScale(0.2431268f, 0.195597917f, 0.225751653f) * Matrix.CreateRotationX(1.43443477f) * Matrix.CreateRotationY(3.62872028f) * Matrix.CreateRotationZ(5.218542f) * Matrix.CreateTranslation(-23.5328846f, 98.0299f, 106.608421f),
        Matrix.CreateScale(0.2431268f, 0.195597917f, 0.225751653f) * Matrix.CreateRotationX(1.01073015f) * Matrix.CreateRotationY(3.84785533f) * Matrix.CreateRotationZ(5.178656f) * Matrix.CreateTranslation(-19.98247f, 100.421646f, 108.01033f),
        Matrix.CreateScale(0.2431268f, 0.195597917f, 0.225751653f) * Matrix.CreateRotationX(0.808886051f) * Matrix.CreateRotationY(4.245341f) * Matrix.CreateRotationZ(5.307986f) * Matrix.CreateTranslation(-18.4087219f, 99.4872055f, 110.583885f),
        Matrix.CreateScale(0.2431268f, 0.195597917f, 0.225751653f) * Matrix.CreateRotationX(1.48373258f) * Matrix.CreateRotationY(3.45802236f) * Matrix.CreateRotationZ(5.03093863f) * Matrix.CreateTranslation(-26.0373116f, 93.49069f, 106.196831f),
        Matrix.CreateScale(0.2431268f, 0.195597917f, 0.225751653f) * Matrix.CreateRotationX(1.44479072f) * Matrix.CreateRotationY(3.47827673f) * Matrix.CreateRotationZ(5.00470972f) * Matrix.CreateTranslation(-19.7067337f, 94.475296f, 105.288383f),
        Matrix.CreateScale(0.2431268f, 0.195597917f, 0.225751653f) * Matrix.CreateRotationX(1.10727143f) * Matrix.CreateRotationY(3.79751682f) * Matrix.CreateRotationZ(5.03334475f) * Matrix.CreateTranslation(-16.1815166f, 97.4408f, 106.888939f),
        Matrix.CreateScale(0.2431268f, 0.195597917f, 0.225751653f) * Matrix.CreateRotationX(2.64172649f) * Matrix.CreateRotationY(2.97032881f) * Matrix.CreateRotationZ(2.56544852f) * Matrix.CreateTranslation(-11.834446f, 99.04786f, 111.80526f),
        Matrix.CreateScale(0.2431268f, 0.195597917f, 0.225751653f) * Matrix.CreateRotationX(0.6066495f) * Matrix.CreateRotationY(3.908579f) * Matrix.CreateRotationZ(5.411663f) * Matrix.CreateTranslation(-16.6642952f, 101.5979f, 111.148254f),
        Matrix.CreateScale(0.241904914f, 0.1331595f, 0.2121244f) * Matrix.CreateRotationX(2.25455618f) * Matrix.CreateRotationY(3.53493762f) * Matrix.CreateRotationZ(3.59166169f) * Matrix.CreateTranslation(-24.363554f, 102.140724f, 109.10907f),
        Matrix.CreateScale(0.387121469f, 0.311443061f, 0.3594557f) * Matrix.CreateRotationX(1.00568461f) * Matrix.CreateRotationY(0.998671949f) * Matrix.CreateRotationZ(8.306467f) * Matrix.CreateTranslation(-13.4531136f, 92.5265045f, 111.616875f),
        Matrix.CreateScale(0.2431268f, 0.195597917f, 0.225751653f) * Matrix.CreateRotationX(-1.80768156f) * Matrix.CreateRotationY(-0.0272603966f) * Matrix.CreateRotationZ(-2.77292371f) * Matrix.CreateTranslation(-21.4512882f, 89.81291f, 104.789963f),
        Matrix.CreateScale(0.387121469f, 0.311443061f, 0.3594557f) * Matrix.CreateRotationX(0.20949696f) * Matrix.CreateRotationY(1.85876358f) * Matrix.CreateRotationZ(1.45878673f) * Matrix.CreateTranslation(-16.8791885f, 88.8569f, 106.763557f),
        Matrix.CreateScale(0.387121469f, 0.311443061f, 0.3594557f) * Matrix.CreateRotationX(2.57124782f) * Matrix.CreateRotationY(-0.00254059676f) * Matrix.CreateRotationZ(1.758418f) * Matrix.CreateTranslation(14.7891684f, 81.7561f, 115.701111f),
        Matrix.CreateScale(0.1684977f, 0.135558069f, 0.156455949f) * Matrix.CreateRotationX(-0.5022078f) * Matrix.CreateRotationY(0.39912f) * Matrix.CreateRotationZ(0.282630771f) * Matrix.CreateTranslation(23.64873f, 104.045044f, 116.229919f),
        Matrix.CreateScale(0.2431268f, 0.195597917f, 0.225751653f) * Matrix.CreateRotationX(-0.98196733f) * Matrix.CreateRotationY(-0.07829085f) * Matrix.CreateRotationZ(-0.0390241332f) * Matrix.CreateTranslation(23.6088638f, 100.777985f, 112.628258f),
        Matrix.CreateScale(0.2431268f, 0.195597917f, 0.225751653f) * Matrix.CreateRotationX(-1.03213024f) * Matrix.CreateRotationY(-0.208739474f) * Matrix.CreateRotationZ(-0.144311443f) * Matrix.CreateTranslation(22.27088f, 97.46503f, 109.99588f),
        Matrix.CreateScale(0.232860938f, 0.187338933f, 0.21621944f) * Matrix.CreateRotationX(-0.135355711f) * Matrix.CreateRotationY(0.6865736f) * Matrix.CreateRotationZ(0.38400498f) * Matrix.CreateTranslation(19.7285061f, 102.170372f, 115.844643f),
        Matrix.CreateScale(0.2431268f, 0.195597917f, 0.225751653f) * Matrix.CreateRotationX(-0.518204f) * Matrix.CreateRotationY(0.0559077337f) * Matrix.CreateRotationZ(0.419037342f) * Matrix.CreateTranslation(16.2919846f, 100.123116f, 112.413719f),
        Matrix.CreateScale(0.2431268f, 0.195597917f, 0.225751653f) * Matrix.CreateRotationX(-0.970668256f) * Matrix.CreateRotationY(0.00163728569f) * Matrix.CreateRotationZ(0.20408918f) * Matrix.CreateTranslation(18.4051685f, 97.38823f, 109.038185f),
        Matrix.CreateScale(0.2431268f, 0.195597917f, 0.225751653f) * Matrix.CreateRotationX(0.3299982f) * Matrix.CreateRotationY(0.4894939f) * Matrix.CreateRotationZ(0.8413306f) * Matrix.CreateTranslation(16.0955563f, 99.37985f, 115.852562f),
        Matrix.CreateScale(0.2431268f, 0.195597917f, 0.225751653f) * Matrix.CreateRotationX(-0.5838058f) * Matrix.CreateRotationY(0.296088159f) * Matrix.CreateRotationZ(0.47668618f) * Matrix.CreateTranslation(12.4209652f, 96.83835f, 111.219254f),
        Matrix.CreateScale(0.2431268f, 0.195597917f, 0.225751653f) * Matrix.CreateRotationX(-0.9660442f) * Matrix.CreateRotationY(0.125085592f) * Matrix.CreateRotationZ(0.199412867f) * Matrix.CreateTranslation(15.346796f, 94.09566f, 108.082153f),
        Matrix.CreateScale(0.2431268f, 0.195597917f, 0.225751653f) * Matrix.CreateRotationX(-1.217677f) * Matrix.CreateRotationY(-0.181074992f) * Matrix.CreateRotationZ(0.2032162f) * Matrix.CreateTranslation(21.1506634f, 93.88156f, 107.578094f),
        Matrix.CreateScale(0.241904914f, 0.1331595f, 0.2121244f) * Matrix.CreateRotationX(-1.29919648f) * Matrix.CreateRotationY(0.813748658f) * Matrix.CreateRotationZ(-1.01565146f) * Matrix.CreateTranslation(21.4291668f, 100.9801f, 111.347572f),
        Matrix.CreateScale(0.2431268f, 0.195597917f, 0.225751653f) * Matrix.CreateRotationX(-1.79839122f) * Matrix.CreateRotationY(0.289564252f) * Matrix.CreateRotationZ(-2.27988362f) * Matrix.CreateTranslation(19.139101f, 89.45162f, 105.607811f),
        Matrix.CreateScale(0.2431268f, 0.195597917f, 0.225751653f) * Matrix.CreateRotationX(1.43448317f) * Matrix.CreateRotationY(-1.43093538f) * Matrix.CreateRotationZ(-0.576587856f) * Matrix.CreateTranslation(12.2347221f, 96.13136f, 115.399712f),
        Matrix.CreateScale(0.303020269f, 0.2437828f, 0.2813648f) * Matrix.CreateRotationX(1.49877524f) * Matrix.CreateRotationY(0.7135183f) * Matrix.CreateRotationZ(6.644081f) * Matrix.CreateTranslation(10.0275526f, 81.39528f, 120.186462f),
        Matrix.CreateScale(0.320253849f, 0.2576474f, 0.2973668f) * Matrix.CreateRotationX(2.75923848f) * Matrix.CreateRotationY(-0.392961264f) * Matrix.CreateRotationZ(1.84871161f) * Matrix.CreateTranslation(17.9652367f, 79.7362061f, 110.205238f),
        Matrix.CreateScale(0.31720233f, 0.165347353f, 0.294533342f) * Matrix.CreateRotationX(0.8415748f) * Matrix.CreateRotationY(0.204222217f) * Matrix.CreateRotationZ(5.193258f) * Matrix.CreateTranslation(11.5285931f, 87.96191f, 117.918663f),
        Matrix.CreateScale(0.320253849f, 0.182834715f, 0.2973668f) * Matrix.CreateRotationX(2.75923848f) * Matrix.CreateRotationY(-0.392961264f) * Matrix.CreateRotationZ(1.84871161f) * Matrix.CreateTranslation(16.0703144f, 89.9645844f, 111.849258f),
        Matrix.CreateScale(0.17614454f, 0.1005619f, 0.163556308f) * Matrix.CreateRotationX(2.75923848f) * Matrix.CreateRotationY(-0.392961264f) * Matrix.CreateRotationZ(1.84871161f) * Matrix.CreateTranslation(16.125658f, 85.37537f, 112.923492f),
        Matrix.CreateScale(0.17614454f, 0.1005619f, 0.163556308f) * Matrix.CreateRotationX(2.75923848f) * Matrix.CreateRotationY(-0.392961264f) * Matrix.CreateRotationZ(1.84871161f) * Matrix.CreateTranslation(17.5258865f, 84.8205f, 109.628716f),
        Matrix.CreateScale(0.17614454f, 0.1005619f, 0.163556308f) * Matrix.CreateRotationX(2.75923848f) * Matrix.CreateRotationY(-0.392961264f) * Matrix.CreateRotationZ(1.84871161f) * Matrix.CreateTranslation(18.3766613f, 87.0399551f, 107.308624f),
        Matrix.CreateScale(0.17614454f, 0.1005619f, 0.163556308f) * Matrix.CreateRotationX(3.18155169f) * Matrix.CreateRotationY(-0.4181991f) * Matrix.CreateRotationZ(1.65671885f) * Matrix.CreateTranslation(18.0903721f, 84.09554f, 105.95903f),
        Matrix.CreateScale(0.17614454f, 0.1005619f, 0.163556308f) * Matrix.CreateRotationX(3.37782884f) * Matrix.CreateRotationY(-0.36525625f) * Matrix.CreateRotationZ(1.59365642f) * Matrix.CreateTranslation(18.447073f, 80.50692f, 105.51458f)
      };
      for (int index = 0; index < 55; ++index)
        this.dropChunk(ref this.faceChunk, matrixArray2[index], 7);
      Matrix[] matrixArray3 = new Matrix[78]
      {
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.58463919f) * Matrix.CreateRotationY(-0.0148354806f) * Matrix.CreateRotationZ(0.7115125f) * Matrix.CreateTranslation(3.10787582f, 67.61283f, -106.552589f),
        Matrix.CreateScale(0.5492081f, 0.7507169f, 0.8029641f) * Matrix.CreateRotationX(-1.37017179f) * Matrix.CreateRotationY(-0.0121693686f) * Matrix.CreateRotationZ(-0.040402282f) * Matrix.CreateTranslation(2.93050551f, 80.62694f, -104.24733f),
        Matrix.CreateScale(0.705929935f, 0.5492081f, 0.475593656f) * Matrix.CreateRotationX(-1.51583564f) * Matrix.CreateRotationY(-0.117167786f) * Matrix.CreateRotationZ(-0.03497848f) * Matrix.CreateTranslation(10.195426f, 74.731514f, -105.112785f),
        Matrix.CreateScale(0.571772456f, 0.4458087f, 0.315614939f) * Matrix.CreateRotationX(-1.60425615f) * Matrix.CreateRotationY(0.0471737832f) * Matrix.CreateRotationZ(-1.87968934f) * Matrix.CreateTranslation(-3.45668173f, 72.73312f, -105.938484f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.7092129f) * Matrix.CreateRotationY(0.261115223f) * Matrix.CreateRotationZ(-0.0647093356f) * Matrix.CreateTranslation(-18.3803864f, 62.86674f, -103.597916f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.70450473f) * Matrix.CreateRotationY(0.0135935433f) * Matrix.CreateRotationZ(-0.0305898525f) * Matrix.CreateTranslation(-4.15608168f, 62.1187172f, -106.11586f),
        Matrix.CreateScale(0.324921131f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.64530742f) * Matrix.CreateRotationY(0.0161616281f) * Matrix.CreateRotationZ(0.497547f) * Matrix.CreateTranslation(2.00586081f, 56.66722f, -105.306267f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.70549345f) * Matrix.CreateRotationY(-0.121635325f) * Matrix.CreateRotationZ(-0.0123197492f) * Matrix.CreateTranslation(10.195426f, 61.8065834f, -105.365631f),
        Matrix.CreateScale(0.94858f, 0.5492081f, 0.456823051f) * Matrix.CreateRotationX(-1.59548414f) * Matrix.CreateRotationY(-0.325216085f) * Matrix.CreateRotationZ(0.1891407f) * Matrix.CreateTranslation(17.3780327f, 67.9491959f, -103.997215f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.69737029f) * Matrix.CreateRotationY(-0.27637738f) * Matrix.CreateRotationZ(1.30976987f) * Matrix.CreateTranslation(17.2725677f, 80.21303f, -101.932121f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.46386564f) * Matrix.CreateRotationY(-0.494836926f) * Matrix.CreateRotationZ(-0.1271584f) * Matrix.CreateTranslation(23.9883671f, 73.67303f, -100.823654f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.59006441f) * Matrix.CreateRotationY(0.221637979f) * Matrix.CreateRotationZ(-0.152618408f) * Matrix.CreateTranslation(-11.2199354f, 68.3645859f, -105.260033f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.38655639f) * Matrix.CreateRotationY(0.13629584f) * Matrix.CreateRotationZ(1.19921052f) * Matrix.CreateTranslation(-11.0581083f, 56.2938881f, -104.537331f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.38539171f) * Matrix.CreateRotationY(0.2518054f) * Matrix.CreateRotationZ(-0.124424063f) * Matrix.CreateTranslation(-11.2863226f, 80.2987747f, -103.034172f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.27597f) * Matrix.CreateRotationY(0.0250762627f) * Matrix.CreateRotationZ(-0.0221754368f) * Matrix.CreateTranslation(-4.15608168f, 86.63884f, -102.134468f),
        Matrix.CreateScale(0.636520147f, 0.636520147f, 0.636520147f) * Matrix.CreateRotationX(-0.9661885f) * Matrix.CreateRotationY(-0.283534735f) * Matrix.CreateRotationZ(0.11555218f) * Matrix.CreateTranslation(3.88938951f, 89.29078f, -98.13169f),
        Matrix.CreateScale(0.636520147f, 0.636520147f, 0.636520147f) * Matrix.CreateRotationX(-0.9661885f) * Matrix.CreateRotationY(-0.283534735f) * Matrix.CreateRotationZ(0.11555218f) * Matrix.CreateTranslation(8.940514f, 89.7711f, -94.69171f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.60535085f) * Matrix.CreateRotationY(-0.193121433f) * Matrix.CreateRotationZ(0.0112966793f) * Matrix.CreateTranslation(17.4524021f, 56.29916f, -102.877769f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.57431364f) * Matrix.CreateRotationY(0.3214582f) * Matrix.CreateRotationZ(1.94435048f) * Matrix.CreateTranslation(10.195426f, 50.26846f, -102.59111f),
        Matrix.CreateScale(0.4914728f, 0.5492081f, 0.5178722f) * Matrix.CreateRotationX(-1.94659877f) * Matrix.CreateRotationY(-0.04572508f) * Matrix.CreateRotationZ(-0.0184648987f) * Matrix.CreateTranslation(3.07325125f, 45.97189f, -101.279106f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.86668837f) * Matrix.CreateRotationY(0.008474327f) * Matrix.CreateRotationZ(-0.032383278f) * Matrix.CreateTranslation(-4.15608168f, 50.4553f, -103.381905f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.67821f) * Matrix.CreateRotationY(-0.5090938f) * Matrix.CreateRotationZ(-53f / (822f * (float)Math.E)) * Matrix.CreateTranslation(23.9883671f, 61.56994f, -100.95417f),
        Matrix.CreateScale(0.2705493f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.28991568f) * Matrix.CreateRotationY(-0.72987324f) * Matrix.CreateRotationZ(-0.225993529f) * Matrix.CreateTranslation(30.1606674f, 65.47449f, -97.69554f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.33659685f) * Matrix.CreateRotationY(-0.5502652f) * Matrix.CreateRotationZ(-0.09253939f) * Matrix.CreateTranslation(28.5620461f, 78.60998f, -96.64705f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.19868946f) * Matrix.CreateRotationY(-0.4496977f) * Matrix.CreateRotationZ(-0.2483829f) * Matrix.CreateTranslation(23.9883671f, 83.99449f, -97.66775f),
        Matrix.CreateScale(0.636520147f, 0.636520147f, 0.636520147f) * Matrix.CreateRotationX(-0.9661885f) * Matrix.CreateRotationY(-0.283534735f) * Matrix.CreateRotationZ(0.11555218f) * Matrix.CreateTranslation(2.37760687f, 94.06802f, -94.8682861f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-0.8822971f) * Matrix.CreateRotationY(0.140157312f) * Matrix.CreateRotationZ(-0.009255556f) * Matrix.CreateTranslation(-3.83786321f, 92.7997055f, -96.80923f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.26516747f) * Matrix.CreateRotationY(0.263820171f) * Matrix.CreateRotationZ(0.05230235f) * Matrix.CreateTranslation(-18.3803864f, 86.2727356f, -99.5334f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.3169764f) * Matrix.CreateRotationX(-1.29664648f) * Matrix.CreateRotationY(0.008123664f) * Matrix.CreateRotationZ(1.31793678f) * Matrix.CreateTranslation(-19.9640217f, 74.182724f, -102.822083f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.44526982f) * Matrix.CreateRotationY(0.5223918f) * Matrix.CreateRotationZ(-0.00291495584f) * Matrix.CreateTranslation(-24.8899746f, 68.94341f, -100.746307f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.87624729f) * Matrix.CreateRotationY(0.247184917f) * Matrix.CreateRotationZ(-0.106798336f) * Matrix.CreateTranslation(-18.3803864f, 51.6002541f, -101.017868f),
        Matrix.CreateScale(0.427946955f, 0.5492081f, 0.350014418f) * Matrix.CreateRotationX(-1.9608252f) * Matrix.CreateRotationY(0.130645365f) * Matrix.CreateRotationZ(-0.232227191f) * Matrix.CreateTranslation(-11.0274792f, 46.0621719f, -100.226341f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.91484475f) * Matrix.CreateRotationY(-0.202985376f) * Matrix.CreateRotationZ(0.05230667f) * Matrix.CreateTranslation(17.334446f, 45.8704f, -98.46881f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-2.20942116f) * Matrix.CreateRotationY(-0.116487764f) * Matrix.CreateRotationZ(0.03718929f) * Matrix.CreateTranslation(9.938953f, 39.926693f, -96.38662f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.86386812f) * Matrix.CreateRotationY(-0.5055974f) * Matrix.CreateRotationZ(0.06668243f) * Matrix.CreateTranslation(23.9883671f, 50.7475662f, -98.1993561f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.58005631f) * Matrix.CreateRotationY(-0.6725001f) * Matrix.CreateRotationZ(-0.0442111529f) * Matrix.CreateTranslation(29.9868889f, 56.2071533f, -95.98568f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.18152809f) * Matrix.CreateRotationY(-1.0725075f) * Matrix.CreateRotationZ(-0.373307168f) * Matrix.CreateTranslation(34.4538727f, 71.6692657f, -91.52195f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.48890471f) * Matrix.CreateRotationY(-1.01869023f) * Matrix.CreateRotationZ(0.0567129143f) * Matrix.CreateTranslation(33.0642929f, 77.9525146f, -91.80834f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-0.8755695f) * Matrix.CreateRotationY(-0.177812472f) * Matrix.CreateRotationZ(-0.31678164f) * Matrix.CreateTranslation(20.4007988f, 92.71499f, -91.93767f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-0.8822971f) * Matrix.CreateRotationY(0.140157312f) * Matrix.CreateRotationZ(-0.009255556f) * Matrix.CreateTranslation(-9.879172f, 89.55384f, -98.70473f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-0.8278552f) * Matrix.CreateRotationY(0.298371375f) * Matrix.CreateRotationZ(0.00132769009f) * Matrix.CreateTranslation(-17.662302f, 92.46165f, -93.8452148f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.25792527f) * Matrix.CreateRotationY(0.689832866f) * Matrix.CreateRotationZ(0.00694007333f) * Matrix.CreateTranslation(-24.450983f, 81.02595f, -97.46898f),
        Matrix.CreateScale(0.7280517f, 0.5492081f, 0.5133965f) * Matrix.CreateRotationX(-1.62848866f) * Matrix.CreateRotationY(0.519744754f) * Matrix.CreateRotationZ(-0.109336153f) * Matrix.CreateTranslation(-24.8348064f, 57.22952f, -100.374886f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.88232946f) * Matrix.CreateRotationY(0.4796757f) * Matrix.CreateRotationZ(-0.215500265f) * Matrix.CreateTranslation(-24.8899746f, 52.8262367f, -98.31365f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-2.205311f) * Matrix.CreateRotationY(0.000340057974f) * Matrix.CreateRotationZ(-0.0334716327f) * Matrix.CreateTranslation(-4.3281846f, 39.9156075f, -97.19421f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-2.3231473f) * Matrix.CreateRotationY(-0.116487764f) * Matrix.CreateRotationZ(0.03718929f) * Matrix.CreateTranslation(15.3151894f, 36.1409569f, -92.88421f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-2.2330668f) * Matrix.CreateRotationY(-0.473024726f) * Matrix.CreateRotationZ(0.1972035f) * Matrix.CreateTranslation(23.2029152f, 41.3088722f, -92.53364f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.94054615f) * Matrix.CreateRotationY(-0.563806f) * Matrix.CreateRotationZ(0.13085556f) * Matrix.CreateTranslation(30.0942268f, 48.04029f, -92.291626f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.714557f) * Matrix.CreateRotationY(-1.10703266f) * Matrix.CreateRotationZ(0.101684943f) * Matrix.CreateTranslation(34.4538727f, 56.59346f, -90.71127f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.18152809f) * Matrix.CreateRotationY(-1.0725075f) * Matrix.CreateRotationZ(-0.373307168f) * Matrix.CreateTranslation(36.4428368f, 8739f / 128f, -87.93319f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(1.07734728f) * Matrix.CreateRotationY(3.867327f) * Matrix.CreateRotationZ(0.171690673f) * Matrix.CreateTranslation(-28.98379f, 80.55913f, -93.53776f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.44253254f) * Matrix.CreateRotationY(0.5203474f) * Matrix.CreateRotationZ(0.0343818478f) * Matrix.CreateTranslation(-34.07364f, 74.91253f, -94.70304f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.65945554f) * Matrix.CreateRotationY(0.516653f) * Matrix.CreateRotationZ(-0.0734395757f) * Matrix.CreateTranslation(-31.0441074f, 63.7106819f, -96.89971f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.44253254f) * Matrix.CreateRotationY(0.5203474f) * Matrix.CreateRotationZ(0.0343818478f) * Matrix.CreateTranslation(-31.0441074f, 75.01673f, -96.44006f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.168756f) * Matrix.CreateRotationY(0.495879263f) * Matrix.CreateRotationZ(0.168230385f) * Matrix.CreateTranslation(-31.0441074f, 84.256546f, -93.0903244f),
        Matrix.CreateScale(0.5492081f, 0.8177453f, 0.5492081f) * Matrix.CreateRotationX(0.593399048f) * Matrix.CreateRotationY(3.26709962f) * Matrix.CreateRotationZ(0.825727463f) * Matrix.CreateTranslation(-27.4723072f, 88.52301f, -91.77288f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(0.7353731f) * Matrix.CreateRotationY(3.5824244f) * Matrix.CreateRotationZ(0.427059233f) * Matrix.CreateTranslation(-22.710556f, 92.36538f, -91.93782f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.403014f) * Matrix.CreateRotationY(0.51883024f) * Matrix.CreateRotationZ(0.05400566f) * Matrix.CreateTranslation(-34.1458244f, 67.9987f, -95.2201f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-2.069983f) * Matrix.CreateRotationY(0.5540223f) * Matrix.CreateRotationZ(-0.429155648f) * Matrix.CreateTranslation(-24.52844f, 48.1403427f, -96.82264f),
        Matrix.CreateScale(0.4601228f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-2.324843f) * Matrix.CreateRotationY(-0.0545465723f) * Matrix.CreateRotationZ(-0.00283810147f) * Matrix.CreateTranslation(0.308356643f, 35.4640579f, -94.76395f),
        Matrix.CreateScale(0.19484207f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.116205f) * Matrix.CreateRotationY(-1.05907f) * Matrix.CreateRotationZ(-0.4304821f) * Matrix.CreateTranslation(33.62607f, 65.03218f, -93.81542f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.03352141f) * Matrix.CreateRotationY(-0.6668906f) * Matrix.CreateRotationZ(-0.3914625f) * Matrix.CreateTranslation(30.1606674f, 81.76501f, -94.32763f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-0.841964245f) * Matrix.CreateRotationY(-0.07450044f) * Matrix.CreateRotationZ(-0.484667957f) * Matrix.CreateTranslation(25.68081f, 91.01244f, -92.24491f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-0.9074931f) * Matrix.CreateRotationY(-0.1044257f) * Matrix.CreateRotationZ(-0.236730039f) * Matrix.CreateTranslation(13.7333059f, 89.46902f, -96.9784851f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-0.955380261f) * Matrix.CreateRotationY(-0.1550788f) * Matrix.CreateRotationZ(-0.234646931f) * Matrix.CreateTranslation(14.2725821f, 94.20745f, -92.8221741f),
        Matrix.CreateScale(0.3244631f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.41945446f) * Matrix.CreateRotationY(-0.2763122f) * Matrix.CreateRotationZ(0.667177f) * Matrix.CreateTranslation(8.037078f, 84.34308f, -102.360924f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-0.8822971f) * Matrix.CreateRotationY(0.140157312f) * Matrix.CreateRotationZ(-0.009255556f) * Matrix.CreateTranslation(-3.23852563f, 89.880455f, -99.31867f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-0.8822971f) * Matrix.CreateRotationY(0.140157312f) * Matrix.CreateRotationZ(-0.009255556f) * Matrix.CreateTranslation(-10.6411018f, 92.86268f, -95.8493652f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.72608447f) * Matrix.CreateRotationY(0.5114255f) * Matrix.CreateRotationZ(-0.106210239f) * Matrix.CreateTranslation(-31.0441074f, 58.63907f, -96.29777f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-2.11276841f) * Matrix.CreateRotationY(0.442377836f) * Matrix.CreateRotationZ(-0.2855793f) * Matrix.CreateTranslation(-31.0441074f, 50.2132034f, -93.20737f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.65945554f) * Matrix.CreateRotationY(0.516653f) * Matrix.CreateRotationZ(-0.0734395757f) * Matrix.CreateTranslation(-33.85883f, 63.895256f, -95.58768f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(1.07734728f) * Matrix.CreateRotationY(3.867327f) * Matrix.CreateRotationZ(0.171690673f) * Matrix.CreateTranslation(-32.1845169f, 80.00413f, -90.65548f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-0.6849225f) * Matrix.CreateRotationY(-0.242393523f) * Matrix.CreateRotationZ(-0.7679393f) * Matrix.CreateTranslation(31.2120247f, 86.87792f, -90.33482f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-0.7924579f) * Matrix.CreateRotationY(-0.947056949f) * Matrix.CreateRotationZ(-0.7045537f) * Matrix.CreateTranslation(34.4538727f, 79.83499f, -89.10998f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-2.36155534f) * Matrix.CreateRotationY(-0.9695611f) * Matrix.CreateRotationZ(0.6653488f) * Matrix.CreateTranslation(34.4538727f, 50.2062569f, -87.25814f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.84382415f) * Matrix.CreateRotationY(0.49744162f) * Matrix.CreateRotationZ(-0.163167045f) * Matrix.CreateTranslation(-32.4727364f, 53.75036f, -93.7578049f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-1.84382415f) * Matrix.CreateRotationY(0.49744162f) * Matrix.CreateRotationZ(-0.163167045f) * Matrix.CreateTranslation(-31.0441074f, 53.5151634f, -94.54397f),
        Matrix.CreateScale(0.5492081f, 0.5492081f, 0.5492081f) * Matrix.CreateRotationX(-0.9135846f) * Matrix.CreateRotationY(-0.682975352f) * Matrix.CreateRotationZ(-0.276005477f) * Matrix.CreateTranslation(29.88582f, 84.34374f, -93.59616f)
      };
      for (int index = 0; index < 78; ++index)
        this.dropChunk(ref this.assChunk, matrixArray3[index], 2);
      this.rocks = (ParticleSystem) new rockSystem(sc.Game, this.content);
      this.rocks.Initialize();
      this.rocks.LoadContent(sc.GraphicsDevice);
      this.dots = (ParticleSystem) new dot2System(sc.Game, this.content);
      this.dots.Initialize();
      this.dots.LoadContent(sc.GraphicsDevice);
    }

    public void setPrincessTargets()
    {
      this.screenTarget1 = new RenderTarget2D(this.sc.GraphicsDevice, 1024, 1024, true, SurfaceFormat.Color, DepthFormat.None, 0, RenderTargetUsage.DiscardContents);
      this.screenTarget2 = new RenderTarget2D(this.sc.GraphicsDevice, 1024, 1024, true, SurfaceFormat.Color, DepthFormat.None, 0, RenderTargetUsage.DiscardContents);
      this.canvasTarget1 = new RenderTarget2D(this.sc.GraphicsDevice, 2000, 2000, false, SurfaceFormat.Color, DepthFormat.None, 0, RenderTargetUsage.DiscardContents);
      this.canvasTarget2 = new RenderTarget2D(this.sc.GraphicsDevice, 2000, 2000, false, SurfaceFormat.Color, DepthFormat.None, 0, RenderTargetUsage.DiscardContents);
      this.sc.isLoading = false;
      this.initTarget();
      this.initCanvas();
      this.sc.isLoading = true;
    }

    public void disposePrincessTargets()
    {
      if (!this.screenTarget1.IsDisposed)
        this.screenTarget1.Dispose();
      if (!this.screenTarget2.IsDisposed)
        this.screenTarget2.Dispose();
      if (!this.canvasTarget1.IsDisposed)
        this.canvasTarget1.Dispose();
      if (this.canvasTarget2.IsDisposed)
        return;
      this.canvasTarget2.Dispose();
    }

    public void loadModels()
    {
      this.pigModel = !this.sc.localLoad ? this.sc.pigModelPrincess : this.content.Load<Model>("boss\\bossBase");
      SkinningData tag = this.pigModel.Tag as SkinningData;
      this.pig1 = new AnimationPlayer[7];
      this.pig1[0] = new AnimationPlayer(tag);
      this.pig1[0].StartClip(tag.AnimationClips["bosswait"]);
      this.pig1[1] = new AnimationPlayer(tag);
      this.pig1[1].StartClip(tag.AnimationClips["bossbuck"]);
      this.pig1[2] = new AnimationPlayer(tag);
      this.pig1[2].StartClip(tag.AnimationClips["bossjump"]);
      this.pig1[3] = new AnimationPlayer(tag);
      this.pig1[3].StartClip(tag.AnimationClips["bossroll"]);
      this.pig1[4] = new AnimationPlayer(tag);
      this.pig1[4].StartClip(tag.AnimationClips["bossdie"]);
      this.pig1[5] = new AnimationPlayer(tag);
      this.pig1[5].StartClip(tag.AnimationClips["bossturnleft"]);
      this.pig1[6] = new AnimationPlayer(tag);
      this.pig1[6].StartClip(tag.AnimationClips["bossturnright"]);
      this.clipIndexA = 0;
      this.a = this.pig1[this.clipIndexA];
      this.b = this.pig1[this.clipIndexA];
      this.princessBone = new Matrix[this.a.skinTransforms.Length];
      this.pigModelLoaded = true;
    }

    public void UnloadContent()
    {
      this.rocks.unloadContent();
      this.dots.unloadContent();
      this.content.Unload();
    }

    public void SetTangents(ref Curve x, ref Curve y)
    {
      for (int index1 = 0; index1 < x.Keys.Count; ++index1)
      {
        int index2 = index1 - 1;
        if (index2 < 0)
          index2 = index1;
        int index3 = index1 + 1;
        if (index3 == x.Keys.Count)
          index3 = index1;
        CurveKey key1 = x.Keys[index2];
        CurveKey key2 = x.Keys[index3];
        CurveKey key3 = x.Keys[index1];
        Princess.SetCurveKeyTangent(ref key1, ref key3, ref key2);
        x.Keys[index1] = key3;
        CurveKey key4 = y.Keys[index2];
        CurveKey key5 = y.Keys[index3];
        CurveKey key6 = y.Keys[index1];
        Princess.SetCurveKeyTangent(ref key4, ref key6, ref key5);
        y.Keys[index1] = key6;
      }
    }

    private static void SetCurveKeyTangent(ref CurveKey prev, ref CurveKey cur, ref CurveKey next)
    {
      float num1 = next.Position - prev.Position;
      float num2 = next.Value - prev.Value;
      if ((double) Math.Abs(num2) < 1.4012984643248171E-45)
      {
        cur.TangentIn = 0.0f;
        cur.TangentOut = 0.0f;
      }
      else
      {
        cur.TangentIn = num2 * (cur.Position - prev.Position) / num1;
        cur.TangentOut = num2 * (next.Position - cur.Position) / num1;
      }
    }

    public void damHealth(ushort amt)
    {
      if (!Princess.cuttyDoneSpeech)
        return;
      if (amt > (ushort) 0)
        ++this.hurtBoss;
      this.health -= amt;
      if (this.health < (ushort) 0 || this.health >= (ushort) 15000)
        this.health = (ushort) 0;
      if (this.bodyState > 0 && this.health < (ushort) 25)
        this.heartExposed = true;
      if (!this.heartExposed)
        return;
      this.health = (ushort) 0;
    }

    public void startHeartAttack()
    {
      this.volumeFade = true;
      this.heartVol = true;
      this.heartattack = 370f;
      this.heartbeat.Play(this.sc.ev, 0.0f, 0.0f);
    }

    public void checkTargets(Vector3 gunpos, Vector3 gunlook, ref Cursor genCursor, float wall)
    {
      if (!Princess.cuttyDoneSpeech)
      {
        this.health = this.startHealth;
      }
      else
      {
        this.cuttyDistance = 20000f;
        float num = 20000f;
        this.boneHit = -1;
        Matrix identity = Matrix.Identity;
        this.cuttyisHit = false;
        if (this.explodeTimer <= 0)
          return;
        for (int index = 0; index < this.col_Bone.Length; ++index)
        {
          Matrix matrix = Matrix.CreateTranslation(this.col_Pos[index]) * this.princessBone[this.col_Bone[index]];
          Vector3 cent = Vector3.Transform(Vector3.Zero, matrix);
          float? nullable = genCursor.hitSphere2(gunpos, gunlook, cent, this.col_Scale[index] * this.cuttyScale);
          bool flag = this.heartExposed && (double) this.heartattack <= 0.0 && (double) this.cuttyPos.Y > 100.0 && (this.boneHit == 2 || this.boneHit == 3) && this.col_Bone[index] == 17;
          if (nullable.HasValue && (flag || (double) nullable.Value < (double) num && (double) nullable.Value < (double) wall))
          {
            this.cuttyisHit = true;
            this.hitCenter = Vector3.Transform(Vector3.Zero, matrix);
            this.hitEdge = nullable.Value * genCursor.rayDir + genCursor.rayPos;
            num = nullable.Value;
            this.cuttyDistance = num;
            this.boneHit = index;
          }
        }
        if (!this.cuttyisHit || this.boneHit == -1)
          return;
        Matrix matrix1 = Matrix.Invert(Matrix.CreateTranslation(this.col_Pos[this.boneHit]) * this.princessBone[this.col_Bone[this.boneHit]]);
        Vector3 vector3 = Vector3.Transform(this.hitEdge, matrix1) - Vector3.Transform(this.hitCenter, matrix1);
        if (this.boneHit == 5 && this.heartExposed && (double) Vector2.DistanceSquared(new Vector2(this.cuttyPos.X, this.cuttyPos.Z), new Vector2(this.playerpos.X, this.playerpos.Z)) < (double) this.minDistance[this.df])
        {
          ++this.heartHit;
          this.heartIndex = 0;
          this.damHealth((ushort) 10);
          this.startHeartAttack();
        }
        else if (this.boneHit == 0)
        {
          if ((double) vector3.X < 0.0)
            this.addBulletHole(new Vector2(460f, 14f), new Vector2(512f, 15f), new Vector2(415f, 98f), new Vector2(512f, 114f), vector3.Z, vector3.Y, this.boneHit);
          else
            this.addBulletHole(new Vector2(564f, 14f), new Vector2(512f, 15f), new Vector2(589f, 98f), new Vector2(512f, 114f), vector3.Z, vector3.Y, -this.boneHit);
        }
        else if (this.boneHit == 1)
        {
          if ((double) vector3.X < 0.0)
            this.addBulletHole(new Vector2(409f, 62f), new Vector2(512f, 82f), new Vector2(295f, 244f), new Vector2(512f, 311f), vector3.Z, vector3.Y, this.boneHit);
          else
            this.addBulletHole(new Vector2(615f, 62f), new Vector2(512f, 82f), new Vector2(729f, 244f), new Vector2(512f, 311f), vector3.Z, vector3.Y, -this.boneHit);
        }
        else if (this.boneHit == 2)
        {
          if ((double) vector3.X < 0.0)
            this.addBulletHole(new Vector2(262f, 165f), new Vector2(512f, 225f), new Vector2(224f, 428f), new Vector2(512f, 473f), vector3.Z, vector3.Y, this.boneHit);
          else
            this.addBulletHole(new Vector2(762f, 165f), new Vector2(512f, 225f), new Vector2(810f, 428f), new Vector2(512f, 473f), vector3.Z, vector3.Y, -this.boneHit);
        }
        else if (this.boneHit == 3)
        {
          if ((double) vector3.X < 0.0)
            this.addBulletHole(new Vector2(266f, 351f), new Vector2(512f, 367f), new Vector2(252f, 474f), new Vector2(512f, 499f), vector3.Z, vector3.Y, this.boneHit);
          else
            this.addBulletHole(new Vector2(758f, 351f), new Vector2(512f, 367f), new Vector2(772f, 474f), new Vector2(512f, 499f), vector3.Z, vector3.Y, -this.boneHit);
        }
        else if (this.boneHit == 4)
        {
          if ((double) vector3.X < 0.0)
            this.addBulletHole(new Vector2(256f, 416f), new Vector2(512f, 448f), new Vector2(284f, 670f), new Vector2(512f, 568f), vector3.Z, vector3.Y, this.boneHit);
          else
            this.addBulletHole(new Vector2(768f, 416f), new Vector2(512f, 448f), new Vector2(740f, 670f), new Vector2(512f, 568f), vector3.Z, vector3.Y, -this.boneHit);
        }
        ushort amt = 0;
        if ((double) this.distanceCutty < (double) this.minDistance[this.df])
        {
          if (this.df == 2)
            amt = (ushort) 1;
          else if (this.df == 1)
            amt = (ushort) 2;
          else if (this.df == 0)
            amt = (ushort) 3;
          else if (this.df == 3)
            amt = (ushort) 1;
          else if (this.df == 4 && this.rr.Next(1, 1000) < 800)
            amt = (ushort) 1;
          else if (this.df >= 5 && this.rr.Next(1, 1000) < 300)
            amt = (ushort) 1;
        }
        this.damHealth(amt);
      }
    }

    private void addBulletHole(
      Vector2 p1,
      Vector2 p2,
      Vector2 p3,
      Vector2 p4,
      float sendY,
      float sendX,
      int bonehit)
    {
      float num1 = this.col_Scale[this.boneHit];
      float amount1 = (float) (((double) sendY + (double) num1) / ((double) num1 * 2.0));
      float amount2 = (float) (((double) sendX + (double) num1) / ((double) num1 * 2.0));
      float num2 = MathHelper.Lerp(MathHelper.Lerp(p3.X, p1.X, amount1), MathHelper.Lerp(p4.X, p2.X, amount1), amount2);
      float num3 = MathHelper.Lerp(MathHelper.Lerp(p3.Y, p4.Y, amount2), MathHelper.Lerp(p1.Y, p2.Y, amount2), amount1);
      Princess.uvIndex = (byte) this.myIndex;
      Princess.xcoord = (int) num2;
      Princess.ycoord = (int) num3;
      int index = 6;
      if ((double) this.distanceCutty < (double) this.minDistance[this.df])
        index = this.sc.paintColor;
      this.addTargetBlood(index, (int) num2 - 15, (int) num2 + 15, (int) num3 - 15, (int) num3 + 15);
      this.addTargetBlood(index, (int) num2 - 15, (int) num2 + 15, (int) num3 - 15, (int) num3 + 15);
      if (this.boneHit == 1 && (double) amount2 > 0.40000000596046448)
      {
        if (bonehit > 0)
        {
          this.addTargetBlood(index, 14, 209, 725, 845);
          this.addTargetBlood(index, 14, 209, 725, 845);
        }
        else
        {
          this.addTargetBlood(index, 248, 443, 737, 857);
          this.addTargetBlood(index, 248, 443, 737, 857);
        }
      }
      if ((this.boneHit == 3 || this.boneHit == 2) && (double) amount2 > 0.51999998092651367 && (this.boneHit != 2 || (double) amount1 < 0.47999998927116394) && (double) this.distanceCutty < (double) this.minDistance[this.df])
      {
        ++this.spineDamage;
        if (this.spineDamage > (ushort) 300)
          this.spineDamage = (ushort) 300;
        if ((double) this.spineDamage > (double) this.spineBreach[this.df])
        {
          if (!this.spineDestroyed)
            this.spineSwitch();
          if ((double) this.spineDamage < (double) this.spineBreach[this.df] + (double) (620 / (int) this.spineDam[this.df]))
          {
            this.damHealth(this.spineDam[this.df]);
            this.buzzSkeleton(18);
            this.boneStrike = true;
          }
        }
      }
      if (this.boneHit == 1 && (double) this.distanceCutty < (double) this.minDistance[this.df])
      {
        ++this.faceDamage;
        if (this.faceDamage > (ushort) 300)
          this.faceDamage = (ushort) 300;
        if ((double) this.faceDamage > (double) this.faceBreach[this.df])
        {
          if (!this.faceDestroyed)
            this.faceSwitch();
          if ((double) this.faceDamage < (double) this.faceBreach[this.df] + (double) (600 / (int) this.faceDam[this.df]))
          {
            this.damHealth(this.faceDam[this.df]);
            this.buzzSkeleton(8);
            this.boneStrike = true;
          }
        }
      }
      if (this.boneHit != 4 || (double) amount1 >= 0.20000000298023224 || (double) this.distanceCutty >= (double) this.minDistance[this.df])
        return;
      ++this.assDamage;
      if (this.assDamage > (ushort) 300)
        this.assDamage = (ushort) 300;
      if ((double) this.assDamage <= (double) this.assBreach[this.df])
        return;
      if (!this.assDestroyed)
        this.assSwitch();
      if ((double) this.assDamage >= (double) this.assBreach[this.df] + (double) (610 / (int) this.assDam[this.df]))
        return;
      this.damHealth(this.assDam[this.df]);
      this.buzzSkeleton(8);
      this.boneStrike = true;
      this.seizureTimer = 40;
    }

    public void fixModel() => this.pigModel = this.content.Load<Model>("boss\\bossBase");

    public void initTarget()
    {
      this.sc.GraphicsDevice.SetRenderTarget(this.screenTarget1);
      this.sc.GraphicsDevice.Clear(Color.Transparent);
      this.sc.GraphicsDevice.SetRenderTarget((RenderTarget2D) null);
      this.sc.GraphicsDevice.SetRenderTarget(this.screenTarget2);
      this.sc.GraphicsDevice.Clear(Color.Transparent);
      this.sc.GraphicsDevice.SetRenderTarget((RenderTarget2D) null);
      this.pigSkin.Parameters["BloodTexture"].SetValue((Texture) this.screenTarget1);
      this.targetChoice = 1;
    }

    public void addTargetBlood(int index, int xMin, int xMax, int yMin, int yMax)
    {
      this.bodyPaint.index.Add(index);
      this.bodyPaint.x.Add((float) this.rr.Next(xMin * 100, xMax * 100) / 100f);
      this.bodyPaint.z.Add((float) this.rr.Next(yMin * 100, yMax * 100) / 100f);
    }

    public void executeTargetBlood()
    {
      if (this.targetChoice == 2)
        this.sc.GraphicsDevice.SetRenderTarget(this.screenTarget1);
      else
        this.sc.GraphicsDevice.SetRenderTarget(this.screenTarget2);
      this.sc.GraphicsDevice.Clear(Color.Transparent);
      this.spriteBatch.Begin();
      if (this.targetChoice == 2)
        this.spriteBatch.Draw((Texture2D) this.screenTarget2, Vector2.Zero, Color.White);
      else
        this.spriteBatch.Draw((Texture2D) this.screenTarget1, Vector2.Zero, Color.White);
      for (int index = 0; index < this.bodyPaint.index.Count; ++index)
      {
        Color color = (Color.White * ((float) this.rr.Next(40, 100) / 100f)) with
        {
          A = (byte) this.rr.Next(120, (int) byte.MaxValue)
        };
        this.spriteBatch.Draw(this.sc.wound, new Vector2(this.bodyPaint.x[index], this.bodyPaint.z[index]), new Rectangle?(this.sc.woundRect[this.bodyPaint.index[index]]), color, (float) this.rr.Next(-1800, 1800) / 100f, new Vector2(32f, 32f), (float) this.rr.Next(10, 50) / 100f, SpriteEffects.None, 0.0f);
      }
      this.spriteBatch.End();
      this.sc.GraphicsDevice.SetRenderTarget((RenderTarget2D) null);
      if (this.targetChoice == 2)
      {
        this.pigSkin.Parameters["BloodTexture"].SetValue((Texture) this.screenTarget1);
        this.simple2.Parameters["BloodTexture"].SetValue((Texture) this.screenTarget1);
        this.targetChoice = 1;
      }
      else
      {
        this.pigSkin.Parameters["BloodTexture"].SetValue((Texture) this.screenTarget2);
        this.simple2.Parameters["BloodTexture"].SetValue((Texture) this.screenTarget2);
        this.targetChoice = 2;
      }
      this.bodyPaint.index.Clear();
      this.bodyPaint.x.Clear();
      this.bodyPaint.z.Clear();
    }

    public void addCanvasCrap(int index, float X, float Z)
    {
      float num1 = (float) ((double) X - 3000.0 + 1085.0);
      float num2 = (float) ((double) Z - 3000.0 + 1085.0);
      if ((double) num1 <= 0.0 || (double) num1 >= 2170.0 || (double) num2 <= 0.0 || (double) num2 >= 2170.0)
        return;
      this.addCanvasBlood(index, num1 * 0.92166f, num2 * 0.92166f);
    }

    private void initCanvas()
    {
      this.sc.GraphicsDevice.SetRenderTarget(this.canvasTarget1);
      this.sc.GraphicsDevice.Clear(Color.Transparent);
      this.sc.GraphicsDevice.SetRenderTarget((RenderTarget2D) null);
      this.sc.GraphicsDevice.SetRenderTarget(this.canvasTarget2);
      this.sc.GraphicsDevice.Clear(Color.Transparent);
      this.sc.GraphicsDevice.SetRenderTarget((RenderTarget2D) null);
      this.simple.Parameters["Texture"].SetValue((Texture) this.canvasTarget1);
      this.canvasChoice = 1;
    }

    public void addCanvasBlood(int index, float x, float z)
    {
      this.canvasPaint.index.Add(index);
      this.canvasPaint.x.Add(x);
      this.canvasPaint.z.Add(z);
    }

    public void executeCanvasBlood()
    {
      if (this.canvasChoice == 2)
        this.sc.GraphicsDevice.SetRenderTarget(this.canvasTarget1);
      else
        this.sc.GraphicsDevice.SetRenderTarget(this.canvasTarget2);
      this.sc.GraphicsDevice.Clear(Color.Transparent);
      this.spriteBatch.Begin();
      if (this.canvasChoice == 2)
        this.spriteBatch.Draw((Texture2D) this.canvasTarget2, Vector2.Zero, Color.White);
      else
        this.spriteBatch.Draw((Texture2D) this.canvasTarget1, Vector2.Zero, Color.White);
      for (int index = 0; index < this.canvasPaint.index.Count; ++index)
      {
        float num = (float) this.rr.Next(10, 70) / 100f;
        Color color = (Color.White * num) with
        {
          A = (byte) ((double) byte.MaxValue * ((double) this.rr.Next((int) ((double) num * 100.0) + 10, 85) / 100.0))
        };
        this.spriteBatch.Draw(this.sc.wound, new Vector2(this.canvasPaint.x[index], this.canvasPaint.z[index]), new Rectangle?(this.sc.woundRect[this.canvasPaint.index[index]]), color, (float) this.rr.Next(-1800, 1800) / 100f, new Vector2(32f, 32f), (float) this.rr.Next(60, 210) / 100f, SpriteEffects.None, 0.0f);
      }
      this.spriteBatch.End();
      this.sc.GraphicsDevice.SetRenderTarget((RenderTarget2D) null);
      if (this.canvasChoice == 2)
      {
        this.simple.Parameters["Texture"].SetValue((Texture) this.canvasTarget1);
        this.canvasChoice = 1;
      }
      else
      {
        this.simple.Parameters["Texture"].SetValue((Texture) this.canvasTarget2);
        this.canvasChoice = 2;
      }
      this.canvasPaint.index.Clear();
      this.canvasPaint.x.Clear();
      this.canvasPaint.z.Clear();
    }

    public void runDestructionChecks(int type)
    {
      if (type < 1)
        return;
      if ((double) this.spineDamage > (double) this.spineBreach[this.df] && !this.spineDestroyed)
        this.spineSwitch();
      if ((double) this.assDamage > (double) this.assBreach[this.df] && !this.assDestroyed)
        this.assSwitch();
      if ((double) this.faceDamage <= (double) this.faceBreach[this.df] || this.faceDestroyed)
        return;
      this.faceSwitch();
    }

    public void buzzSkeleton(int amt)
    {
      this.showSkelTimer = 30;
      this.sc.buzz.Play(this.sc.ev, (float) this.rr.Next(-50, 20) / 100f, 0.0f);
    }

    private void spineSwitch()
    {
      if (!this.sc.bossLoaded || !this.pigModelLoaded)
        return;
      if (this.pigJawIndex == -1)
      {
        this.talkIndex = 0;
        Princess.whichPigTalks = this.myIndex;
      }
      if (this.df != 2 && this.df != 5 && !this.death1)
        this.shootWoundMessage = true;
      this.sc.cuttygouge.Play(this.sc.ev, (float) this.rr.Next(-20, 0) / 100f, (float) this.rr.Next(-20, 30) / 100f);
      this.chunk.startDrop = true;
      this.spineDestroyed = true;
      if ((double) this.spineDamage < (double) this.spineBreach[this.df])
        this.spineDamage = (ushort) ((double) this.spineBreach[this.df] + 5.0);
      if (this.bodyState == 0)
      {
        this.bodyState = 1;
        this.pigModel = this.sc.bossAll;
        this.sc.bossIndex = 1;
      }
      else if (this.bodyState == 2)
      {
        this.bodyState = 4;
        this.pigModel = this.sc.bossAll;
        this.sc.bossIndex = 6;
      }
      else if (this.bodyState == 3)
      {
        this.bodyState = 5;
        this.pigModel = this.sc.bossAll;
        this.sc.bossIndex = 5;
      }
      else
      {
        if (this.bodyState != 6)
          return;
        this.bodyState = 7;
        this.pigModel = this.sc.bossAll;
        this.sc.bossIndex = 7;
      }
    }

    private void assSwitch()
    {
      if (!this.sc.bossLoaded || !this.pigModelLoaded)
        return;
      if (this.pigJawIndex == -1)
      {
        this.talkIndex = 0;
        Princess.whichPigTalks = this.myIndex;
      }
      if (this.df != 2 && this.df != 5 && !this.death1)
        this.shootWoundMessage = true;
      this.assChunk.startDrop = true;
      this.sc.cuttygouge.Play(this.sc.ev, (float) this.rr.Next(-20, 0) / 100f, (float) this.rr.Next(-20, 30) / 100f);
      this.assDestroyed = true;
      if ((double) this.assDamage < (double) this.assBreach[this.df])
        this.assDamage = (ushort) ((double) this.assBreach[this.df] + 5.0);
      if (this.bodyState == 0)
      {
        this.bodyState = 2;
        this.pigModel = this.sc.bossAll;
        this.sc.bossIndex = 2;
      }
      else if (this.bodyState == 1)
      {
        this.bodyState = 4;
        this.pigModel = this.sc.bossAll;
        this.sc.bossIndex = 6;
      }
      else if (this.bodyState == 3)
      {
        this.bodyState = 6;
        this.pigModel = this.sc.bossAll;
        this.sc.bossIndex = 4;
      }
      else
      {
        if (this.bodyState != 5)
          return;
        this.bodyState = 7;
        this.pigModel = this.sc.bossAll;
        this.sc.bossIndex = 7;
      }
    }

    private void faceSwitch()
    {
      if (!this.sc.bossLoaded || !this.pigModelLoaded)
        return;
      if (this.pigJawIndex == -1)
      {
        this.talkIndex = 0;
        Princess.whichPigTalks = this.myIndex;
      }
      if (this.df != 2 && this.df != 5 && !this.death1)
        this.shootWoundMessage = true;
      this.faceChunk.startDrop = true;
      this.sc.cuttygouge.Play(this.sc.ev, (float) this.rr.Next(-20, 0) / 100f, (float) this.rr.Next(-20, 30) / 100f);
      this.faceDestroyed = true;
      if ((double) this.faceDamage < (double) this.faceBreach[this.df])
        this.faceDamage = (ushort) ((double) this.faceBreach[this.df] + 5.0);
      if (this.bodyState == 0)
      {
        this.bodyState = 3;
        this.pigModel = this.sc.bossAll;
        this.sc.bossIndex = 3;
      }
      else if (this.bodyState == 2)
      {
        this.bodyState = 6;
        this.pigModel = this.sc.bossAll;
        this.sc.bossIndex = 4;
      }
      else if (this.bodyState == 1)
      {
        this.bodyState = 5;
        this.pigModel = this.sc.bossAll;
        this.sc.bossIndex = 5;
      }
      else
      {
        if (this.bodyState != 4)
          return;
        this.bodyState = 7;
        this.pigModel = this.sc.bossAll;
        this.sc.bossIndex = 7;
      }
    }

    public void Update(
      GameTime gm,
      NetworkSession net,
      Vector3 campos,
      int timeframe,
      Vector3 lookVec,
      Vector3 playerPos,
      Vector3 remotePos,
      float playerHealth,
      float remoteHealth,
      bool isSpectating,
      ref float[,] heights)
    {
      if (!this.pigModelLoaded)
        return;
      this.networkSession = net;
      this.playerpos = playerPos;
      this.remotepos = remotePos;
      this.timeframe = timeframe;
      this.spectator = isSpectating;
      this.df = this.sc.df;
      if (!this.spectator)
        this.df += 3;
      if (this.isTrialMode)
        this.df = 6;
      this.playerHealth = playerHealth;
      this.remoteHealth = remoteHealth;
      this.healthPerc = (float) this.health / (float) this.startHealth;
      if (this.sc.host && !this.deathsent)
        this.pigLogic();
      this.pigBones(lookVec, ref heights);
      if (this.chunk.startDrop)
        this.updateChunk(ref this.chunk, ref heights);
      if (this.faceChunk.startDrop)
        this.updateChunk(ref this.faceChunk, ref heights);
      if (this.assChunk.startDrop)
        this.updateChunk(ref this.assChunk, ref heights);
      if (this.puke1.max > 1)
      {
        if (this.cuttyShit)
          this.updateShit(ref this.puke1, ref heights);
        else if (this.death1)
          this.updatePuke2(ref this.puke1, ref heights);
        else
          this.updatePuke(ref this.puke1, ref heights);
      }
      this.runScheduler(ref heights);
      if ((double) this.shockTimer > 0.0)
        this.shockWave(ref heights);
      this.rocks.Update(gm);
      this.dots.Update(gm);
    }

    private void dropChunk(ref Princess.shell sh, Matrix mm, int bone)
    {
      sh.offset[sh.index] = mm;
      sh.bone[sh.index] = bone;
      sh.dupe[sh.index].init((float) this.rr.Next(20, 60) / 100f, 2f, 1f, mm, new Vector3(2f, 1f, 0.0f), (float) (-(double) this.rr.Next(80, 160) / 1000.0), 80, 80f, 220f);
      sh.stream[sh.index].Trans = sh.dupe[sh.index].transform;
      sh.stream[sh.index].color = Vector3.One;
      ++sh.index;
      if (sh.index > sh.maxCapacity - 1)
        sh.index = 0;
      ++sh.max;
      if (sh.max <= sh.maxCapacity - 1)
        return;
      sh.max = sh.maxCapacity;
    }

    private void updateChunk(ref Princess.shell sh, ref float[,] heights)
    {
      sh.tempindex = 0;
      bool flag = true;
      for (int index = 0; index < sh.max; ++index)
      {
        if (sh.dupe[index].move == 1 || sh.dupe[index].move == 2)
          sh.dupe[index].Update(ref heights);
        if (sh.dupe[index].move == 0)
          sh.dupe[index].transform = sh.offset[index] * this.princessBone[sh.bone[index]];
        if (sh.startDrop)
        {
          sh.dropTimer += 0.015f;
          if ((double) index < (double) sh.dropTimer && sh.dupe[index].move == 0)
          {
            sh.dupe[index].move = 1;
            sh.dupe[index].createState(sh.dupe[index].transform);
            Vector3 vector3 = (this.cuttyPos - this.oldcuttyPos) * (float) this.rr.Next(75, 100) / 100f;
            float num = MathHelper.Lerp(3f, 0.5f, (float) index / (float) sh.maxCapacity);
            sh.dupe[index].velocity = vector3 + (sh.dupe[index].transform.Up + new Vector3(0.0f, 0.6f, 0.0f)) * num;
            sh.dupe[index].Update(ref heights);
            this.cuttyChunkRelease = true;
            this.hitCenter2 = sh.dupe[index].mypos;
            this.hitEdge2 = this.hitCenter2 + sh.dupe[index].transform.Up;
          }
          if (sh.dupe[index].move != 3)
            flag = false;
        }
        sh.stream[index].Trans = sh.dupe[index].transform;
        sh.displayList[sh.tempindex] = sh.stream[index];
        ++sh.tempindex;
      }
      if (!sh.startDrop || !flag)
        return;
      sh.startDrop = false;
    }

    private void dropPuke(
      ref Princess.vomit sh,
      int thick,
      int width,
      float speed,
      Matrix bonelock)
    {
      Vector3 vector3_1 = new Vector3((float) this.rr.Next(-width, width) / 100f, (float) this.rr.Next(thick, -20) / 100f, 0.0f);
      vector3_1.Z += (float) this.rr.Next(0, 120) / 10f;
      Matrix.CreateTranslation(vector3_1.X, vector3_1.Y, vector3_1.Z, out this.m1);
      Matrix.Multiply(ref this.m1, ref bonelock, out this.m5);
      sh.dupe[sh.index].init((float) this.rr.Next(20, 48) / 100f, this.m5, Vector3.Zero, -0.42f, this.rr.Next(20, 120), 80f, 220f);
      Vector3 vector3_2 = new Vector3((float) this.rr.Next(-100, 100) / 1200f, (float) this.rr.Next(-100, 100) / 1200f, (float) this.rr.Next(-100, 100) / 1200f);
      sh.dupe[sh.index].velocity = (sh.dupe[sh.index].transform.Forward + vector3_2) * speed;
      sh.stream[sh.index].Trans = sh.dupe[sh.index].transform;
      sh.dupe[sh.index].mycolor = new Vector3(122f, 116f, 24f) / 275f;
      if ((double) vector3_1.X >= 0.20000000298023224)
        sh.dupe[sh.index].mycolor = new Vector3(142f, 146f, 47f) / 425f;
      sh.stream[sh.index].color = sh.dupe[sh.index].mycolor;
      ++sh.index;
      if (sh.index > sh.maxCapacity - 1)
        sh.index = 0;
      ++sh.max;
      if (sh.max <= sh.maxCapacity)
        return;
      sh.max = sh.maxCapacity;
    }

    private void updatePuke(ref Princess.vomit sh, ref float[,] heights)
    {
      sh.tempindex = 0;
      for (int index = 0; index < sh.max; ++index)
      {
        if (sh.dupe[index].move == 1 || sh.dupe[index].move == 2)
        {
          sh.dupe[index].Update(ref heights, this.vomitveloc);
          sh.stream[index].Trans = sh.dupe[index].transform;
          if ((double) sh.dupe[index].age >= 18.0 && (double) sh.dupe[index].age <= 26.0)
          {
            sh.dupe[index].mycolor *= 0.95f;
            sh.stream[index].color = sh.dupe[index].mycolor;
          }
          else
            sh.stream[index].color = (double) sh.dupe[index].age < 0.0 || (double) sh.dupe[index].age > 4.0 ? ((double) sh.dupe[index].age != 8.0 ? sh.dupe[index].mycolor : sh.dupe[index].mycolor * 1.7f) : new Vector3(122f, 116f, 34f) / (float) byte.MaxValue * (float) (0.10000000149011612 + (double) sh.dupe[index].age * 0.2199999988079071);
          sh.displayList[sh.tempindex] = sh.stream[index];
          ++sh.tempindex;
        }
      }
      if (sh.tempindex < 4)
      {
        sh.index = 0;
        sh.max = 0;
        sh.tempindex = 0;
      }
      if (sh.max <= 50)
        return;
      for (int index = 10; index < sh.max; index += 60)
      {
        if (!this.cuttyVomitHit && sh.dupe[index].move == 1 && (double) Vector3.DistanceSquared(sh.dupe[index].mypos, new Vector3(this.playerpos.X, this.playerpos.Y + 50f, this.playerpos.Z)) < 8100.0)
        {
          this.cuttyVomitHit = true;
          this.splats.Play(this.sc.ev, (float) this.rr.Next(-50, 20) / 100f, (float) this.rr.Next(-90, 90) / 100f);
        }
        if (!this.cuttyVomitHit2 && sh.dupe[index].move == 1 && !this.spectator && (double) Vector3.DistanceSquared(sh.dupe[index].mypos, new Vector3(this.remotepos.X, this.remotepos.Y + 50f, this.remotepos.Z)) < 8100.0)
          this.cuttyVomitHit2 = true;
        if (sh.dupe[index].splat)
        {
          sh.dupe[index].splat = false;
          this.addCanvasCrap(this.rr.Next(1, 4), sh.dupe[index].mypos.X, sh.dupe[index].mypos.Z);
        }
      }
    }

    private void dropPuke2(
      ref Princess.vomit sh,
      int thick,
      int width,
      float speed,
      Matrix bonelock)
    {
      Vector3 vector3_1 = new Vector3((float) this.rr.Next(-width, width) / 100f, (float) this.rr.Next(thick, -20) / 100f, 0.0f);
      vector3_1.Z += (float) this.rr.Next(0, 120) / 10f;
      Matrix.CreateTranslation(vector3_1.X, vector3_1.Y, vector3_1.Z, out this.m1);
      Matrix.Multiply(ref this.m1, ref bonelock, out this.m5);
      sh.dupe[sh.index].init((float) this.rr.Next(20, 48) / 100f, this.m5, Vector3.Zero, -0.42f, this.rr.Next(20, 120), 80f, 220f);
      Vector3 vector3_2 = new Vector3((float) this.rr.Next(-100, 100) / 1200f, (float) this.rr.Next(-100, 100) / 1200f, (float) this.rr.Next(-100, 100) / 1200f);
      sh.dupe[sh.index].velocity = (sh.dupe[sh.index].transform.Forward + vector3_2) * speed;
      sh.stream[sh.index].Trans = sh.dupe[sh.index].transform;
      sh.dupe[sh.index].mycolor = new Vector3(190f, 30f, 30f) / 275f;
      sh.stream[sh.index].color = sh.dupe[sh.index].mycolor;
      ++sh.index;
      if (sh.index > sh.maxCapacity - 1)
        sh.index = 0;
      ++sh.max;
      if (sh.max <= sh.maxCapacity)
        return;
      sh.max = sh.maxCapacity;
    }

    private void updatePuke2(ref Princess.vomit sh, ref float[,] heights)
    {
      sh.tempindex = 0;
      for (int index = 0; index < sh.max; ++index)
      {
        if (sh.dupe[index].move == 1 || sh.dupe[index].move == 2)
        {
          sh.dupe[index].Update(ref heights, this.vomitveloc);
          sh.stream[index].Trans = sh.dupe[index].transform;
          if ((double) sh.dupe[index].age >= 16.0)
          {
            sh.dupe[index].mycolor *= 0.95f;
            sh.stream[index].color = sh.dupe[index].mycolor;
          }
          else
            sh.stream[index].color = (double) sh.dupe[index].age < 0.0 || (double) sh.dupe[index].age > 4.0 ? sh.dupe[index].mycolor : new Vector3(140f, 10f, 10f) / (float) byte.MaxValue * (float) (0.10000000149011612 + (double) sh.dupe[index].age * 0.2199999988079071);
          sh.displayList[sh.tempindex] = sh.stream[index];
          ++sh.tempindex;
        }
      }
      if (sh.tempindex < 4)
      {
        sh.index = 0;
        sh.max = 0;
        sh.tempindex = 0;
      }
      if (sh.max <= 50)
        return;
      for (int index = 10; index < sh.max; index += 60)
      {
        if (sh.dupe[index].splat)
        {
          sh.dupe[index].splat = false;
          this.addCanvasCrap(8, sh.dupe[index].mypos.X, sh.dupe[index].mypos.Z);
        }
      }
    }

    private void dropShit(ref Princess.vomit sh, float speed, Matrix bonelock, float myTimer)
    {
      Vector3 vector3_1 = new Vector3((float) this.rr.Next(-500, 500) / 100f, (float) this.rr.Next(-400, 400) / 100f, 0.0f);
      vector3_1.Z += (float) this.rr.Next(-50, 10) / 10f;
      Vector3 vector3_2 = vector3_1 * myTimer;
      Matrix.CreateTranslation(vector3_2.X, vector3_2.Y, vector3_2.Z, out this.m1);
      Matrix.Multiply(ref this.m1, ref bonelock, out this.m5);
      sh.dupe[sh.index].init((float) this.rr.Next(20, 48) / 100f, this.m5, Vector3.Zero, -0.42f, this.rr.Next(20, 120), 80f, 220f);
      Vector3 vector3_3 = new Vector3((float) this.rr.Next(-100, 100) / 900f, (float) this.rr.Next(-50, 150) / 900f, (float) this.rr.Next(-100, 100) / 900f);
      vector3_3.Y += Math.Abs((float) Math.Sin((double) this.sc.myTimer / 12.0)) * 0.3f;
      sh.dupe[sh.index].velocity = (sh.dupe[sh.index].transform.Forward + vector3_3) * speed;
      sh.stream[sh.index].Trans = sh.dupe[sh.index].transform;
      sh.dupe[sh.index].mycolor = Vector3.Lerp(new Vector3(37f, 18f, 0.0f) / (float) byte.MaxValue, new Vector3(66f, 37f, 0.0f) / (float) byte.MaxValue, Math.Abs((float) Math.Sin((double) this.sc.myTimer / 14.0)));
      sh.stream[sh.index].color = sh.dupe[sh.index].mycolor;
      ++sh.index;
      if (sh.index > sh.maxCapacity - 1)
        sh.index = 0;
      ++sh.max;
      if (sh.max <= sh.maxCapacity)
        return;
      sh.max = sh.maxCapacity;
    }

    private void updateShit(ref Princess.vomit sh, ref float[,] heights)
    {
      sh.tempindex = 0;
      for (int index = 0; index < sh.max; ++index)
      {
        if (sh.dupe[index].move == 1 || sh.dupe[index].move == 2)
        {
          sh.dupe[index].Update(ref heights, this.vomitveloc);
          sh.stream[index].Trans = sh.dupe[index].transform;
          if ((double) sh.dupe[index].age >= 18.0)
          {
            sh.dupe[index].mycolor *= 0.95f;
            sh.stream[index].color = sh.dupe[index].mycolor;
          }
          else
            sh.stream[index].color = (double) sh.dupe[index].age < 0.0 || (double) sh.dupe[index].age > 4.0 ? ((double) sh.dupe[index].age != 7.0 ? sh.dupe[index].mycolor : sh.dupe[index].mycolor * 1.4f) : sh.dupe[index].mycolor * (float) (0.10000000149011612 + (double) sh.dupe[index].age * 0.2199999988079071);
          sh.displayList[sh.tempindex] = sh.stream[index];
          ++sh.tempindex;
        }
      }
      if (sh.tempindex < 4)
      {
        sh.index = 0;
        sh.max = 0;
        sh.tempindex = 0;
      }
      if (sh.max <= 50)
        return;
      for (int index = 10; index < sh.max; index += 60)
      {
        if (!this.cuttyShitHit && sh.dupe[index].move == 1 && (double) Vector3.DistanceSquared(sh.dupe[index].mypos, new Vector3(this.playerpos.X, this.playerpos.Y + 60f, this.playerpos.Z)) < 14400.0)
        {
          this.cuttyShitHit = true;
          this.splats.Play(this.sc.ev, (float) this.rr.Next(-99, -30) / 100f, (float) this.rr.Next(-90, 90) / 100f);
        }
        if (!this.cuttyShitHit2 && sh.dupe[index].move == 1 && !this.spectator && (double) Vector3.DistanceSquared(sh.dupe[index].mypos, new Vector3(this.remotepos.X, this.remotepos.Y + 60f, this.remotepos.Z)) < 14400.0)
          this.cuttyShitHit2 = true;
        if (sh.dupe[index].splat)
        {
          sh.dupe[index].splat = false;
          this.addCanvasCrap(this.rr.Next(9, 13), sh.dupe[index].mypos.X, sh.dupe[index].mypos.Z);
        }
      }
    }

    public void makePigTalk(int line)
    {
      if (this.death1)
        return;
      this.cuttyStruct.homing = 0;
      this.cuttyStruct.rot = (float) ((double) this.rr.Next(90, 130) / 100.0 * 8.0);
      this.cuttyStruct.animType = 0;
      this.cuttyStruct.talkindex = line;
      this.scheduleAction(146);
    }

    private void volumeBurps()
    {
      if (this.burps.sound[0].IsDisposed)
        return;
      this.burps.sound[0].Volume = this.sc.ev - MathHelper.Clamp(this.distanceCutty / 2250000f, 0.0f, this.sc.ev);
      if (this.explodeTimer >= 5)
        return;
      this.burps.sound[0].Volume = 0.0f;
    }

    private void pigVolume()
    {
      if (this.pigDialog1.sound[0].IsDisposed)
        return;
      this.pigDialog1.sound[0].Volume = this.sc.vv;
    }

    private void pigLogic()
    {
      if (!this.cuttyDoneLocalSpeech)
      {
        if (!Princess.allplayersReady || Princess.someoneTalking)
          return;
        if (Princess.speeches < this.speechList.Count && this.speechInclude.Contains(Princess.speeches))
        {
          Princess.someoneTalking = true;
          this.cuttyStruct.talkindex = this.speechList[Princess.speeches];
          this.scheduleAction(146);
          ++Princess.speeches;
        }
        else
        {
          if (Princess.speeches < this.speechList.Count)
            return;
          this.cuttyStruct.talkindex = -1;
          this.scheduleAction(146);
          this.cuttyDoneLocalSpeech = true;
          Princess.cuttyDoneSpeech = true;
        }
      }
      else if (!this.newAction && this.health <= (ushort) 0 && this.heartHit >= (ushort) 5 && !this.isTrialMode)
      {
        this.deathsent = true;
        this.cuttyStruct.dur = (ushort) 40;
        this.cuttyStruct.rot = this.cuttyRot;
        this.scheduleAction(142);
        this.newAction = true;
      }
      else
      {
        --this.nextAttack;
        if (!this.isTrialMode && !this.cuttyShit && !this.newAction && ((double) this.healthPerc < 0.30000001192092896 || (double) this.healthPerc > 0.40000000596046448 && (double) this.healthPerc < 0.699999988079071 && this.rr.Next(1, 1000) < 30) && this.nextAttack < 0)
        {
          this.cuttyStruct.dur = (ushort) this.rr.Next(500, 1400);
          if (this.heartExposed && this.rr.Next(1, 1000) < this.jumpOdds[this.df])
            this.cuttyStruct.dur = (ushort) 2500;
          if (this.rr.Next(1, 1000) < 100)
            this.cuttyStruct.dur = (ushort) 2500;
          this.scheduleAction(141);
          this.newAction = true;
        }
        else
        {
          --this.buckDelay;
          bool flag1 = (double) this.healthPerc >= 0.800000011920929 && this.rr.Next(1, 1000) < 60 || (double) this.healthPerc > 0.30000001192092896 && (double) this.healthPerc < 0.800000011920929 && this.rr.Next(1, 1000) < 20;
          if (!this.newAction && (double) this.buckDelay <= 0.0 && (double) this.healthPerc > 0.30000001192092896 && flag1)
          {
            this.cuttyStruct.dur = (ushort) 0;
            this.cuttyStruct.rot = this.cuttyRot;
            this.scheduleAction(144);
            this.newAction = true;
          }
          else
          {
            --this.shitDelay;
            if (!this.gonnaShit && (this.gonnaVomit || this.homingTimer > 0 || (double) this.shitDelay > 0.0 || this.cuttyShit || this.attack1))
            {
              --this.gonnaRollDelay;
              if (!this.newAction && (double) this.gonnaRollDelay <= 0.0 && (double) this.healthPerc < 0.800000011920929)
              {
                this.cuttyStruct.dur = (ushort) this.rr.Next(3, 9);
                this.cuttyStruct.rot = this.cuttyRot;
                this.scheduleAction(143);
                this.newAction = true;
              }
              else
              {
                --this.turningWait;
                this.damcheck = this.damTrigger[this.df];
                if (this.heartExposed)
                  this.damcheck = 2;
                if (this.turningWait > 0 && this.hurtBoss <= this.damcheck || this.newAction || this.cuttyShit)
                  return;
                int num1 = 0;
                float num2 = 1440000f;
                bool flag2 = false;
                bool flag3 = false;
                int num3 = 300;
                if (this.heartExposed)
                  num3 = 500;
                if (this.hurtBoss > this.damcheck)
                {
                  flag2 = true;
                  if (this.rr.Next(1, 1000) < num3 && !this.isTrialMode)
                  {
                    flag2 = false;
                    flag3 = true;
                  }
                }
                else
                {
                  int num4 = 450;
                  int num5 = 600;
                  if (this.heartExposed)
                  {
                    num4 = 500;
                    num5 = 850;
                  }
                  if (!this.isTrialMode)
                  {
                    num4 = 700;
                    num5 = 850;
                  }
                  int num6 = this.rr.Next(1, 1000);
                  if (num6 < num4)
                    flag2 = true;
                  if (num6 >= num4 && num6 < num5)
                    flag3 = true;
                }
                this.hurtBoss = 0;
                if (this.spectator)
                {
                  if ((double) this.distanceCutty < (double) num2)
                    num1 = 1;
                  else if (this.rr.Next(1, 1000) < 300)
                    num1 = 1;
                }
                if (!this.spectator)
                {
                  if ((double) this.playerHealth > 0.0 && (double) this.remoteHealth > 0.0)
                  {
                    if ((double) this.distanceCutty < (double) num2 && (double) this.distanceCutty2 < (double) num2)
                      num1 = this.rr.Next(1, 3);
                    else if ((double) this.distanceCutty < (double) num2)
                    {
                      num1 = 1;
                      if (this.rr.Next(1, 1000) < 200)
                        num1 = 2;
                    }
                    else if ((double) this.distanceCutty2 < (double) num2)
                    {
                      num1 = 2;
                      if (this.rr.Next(1, 1000) < 200)
                        num1 = 1;
                    }
                    else if ((double) this.distanceCutty >= (double) num2 && (double) this.distanceCutty2 >= (double) num2)
                      num1 = this.rr.Next(1, 3);
                  }
                  else if ((double) this.playerHealth > 0.0 && (double) this.remoteHealth <= 0.0)
                  {
                    num1 = 1;
                    if ((double) this.distanceCutty >= (double) num2)
                      num1 = this.rr.Next(1, 3);
                  }
                  else if ((double) this.playerHealth <= 0.0 && (double) this.remoteHealth > 0.0)
                  {
                    num1 = 2;
                    if ((double) this.distanceCutty2 >= (double) num2)
                      num1 = this.rr.Next(1, 3);
                  }
                  else if ((double) this.playerHealth <= 0.0 && (double) this.remoteHealth <= 0.0)
                    num1 = this.rr.Next(1, 3);
                }
                if (num1 > 0)
                {
                  if (flag2)
                  {
                    this.homing = 0;
                    this.gonnaVomit = true;
                    float radians = 0.0f;
                    if (num1 == 1)
                      radians = (float) (-Math.Atan2((double) this.cuttyPos.Z - (double) this.playerpos.Z, (double) this.cuttyPos.X - (double) this.playerpos.X) - 1.5700000524520874);
                    if (num1 == 2)
                      radians = (float) (-Math.Atan2((double) this.cuttyPos.Z - (double) this.remotepos.Z, (double) this.cuttyPos.X - (double) this.remotepos.X) - 1.5700000524520874);
                    float num7 = Math.Abs(Princess.WrapAngle(radians) - Princess.WrapAngle(this.cuttyRot));
                    this.cuttyStruct.animType = 1;
                    float num8 = 0.5f;
                    if ((double) Princess.WrapAngle(radians - this.cuttyRot) < 0.0)
                    {
                      this.cuttyStruct.animType = 2;
                      num8 = -0.5f;
                    }
                    this.cuttyStruct.homing = num1;
                    this.cuttyStruct.rot = radians;
                    if ((double) num7 < 2.5)
                      this.cuttyStruct.rot = radians + num8;
                    this.cuttyStruct.talkindex = -1;
                    this.scheduleAction(140);
                    this.newAction = true;
                  }
                  else if (flag3)
                  {
                    this.homing = 0;
                    float radians = 0.0f;
                    bool flag4 = false;
                    if (num1 == 1)
                    {
                      radians = (float) (-Math.Atan2((double) this.cuttyPos.Z - (double) this.playerpos.Z, (double) this.cuttyPos.X - (double) this.playerpos.X) - 4.7119998931884766);
                      if ((double) this.playerHealth < 100.0)
                        flag4 = true;
                    }
                    if (num1 == 2)
                    {
                      radians = (float) (-Math.Atan2((double) this.cuttyPos.Z - (double) this.remotepos.Z, (double) this.cuttyPos.X - (double) this.remotepos.X) - 4.7119998931884766);
                      if ((double) this.remoteHealth < 100.0)
                        flag4 = true;
                    }
                    float num9 = Math.Abs(Princess.WrapAngle(radians) - Princess.WrapAngle(this.cuttyRot));
                    float num10 = 0.3f;
                    this.cuttyStruct.animType = 1;
                    if ((double) Princess.WrapAngle(radians - this.cuttyRot) < 0.0)
                    {
                      num10 = -0.3f;
                      this.cuttyStruct.animType = 2;
                    }
                    this.cuttyStruct.homing = 5;
                    this.cuttyStruct.rot = radians;
                    if ((double) num9 < 2.5 && !flag4)
                      this.cuttyStruct.rot = radians + num10;
                    this.cuttyStruct.talkindex = -1;
                    this.scheduleAction(140);
                    this.newAction = true;
                  }
                  else
                  {
                    this.homing = 0;
                    float radians = 0.0f;
                    if (num1 == 1)
                      radians = (float) (-Math.Atan2((double) this.cuttyPos.Z - (double) this.playerpos.Z, (double) this.cuttyPos.X - (double) this.playerpos.X) - 1.5700000524520874);
                    if (num1 == 2)
                      radians = (float) (-Math.Atan2((double) this.cuttyPos.Z - (double) this.remotepos.Z, (double) this.cuttyPos.X - (double) this.remotepos.X) - 1.5700000524520874);
                    float num11 = Math.Abs(Princess.WrapAngle(radians) - Princess.WrapAngle(this.cuttyRot));
                    float num12 = 0.5f;
                    this.cuttyStruct.animType = 1;
                    if ((double) Princess.WrapAngle(radians - this.cuttyRot) < 0.0)
                    {
                      num12 = -0.5f;
                      this.cuttyStruct.animType = 2;
                    }
                    this.cuttyStruct.homing = 0;
                    this.cuttyStruct.rot = radians;
                    if ((double) num11 < 2.5)
                      this.cuttyStruct.rot = radians + num12;
                    this.cuttyStruct.talkindex = -1;
                    this.scheduleAction(140);
                    this.newAction = true;
                  }
                }
                else
                {
                  this.turningWait = this.rr.Next(300, 700);
                  if (!this.heartExposed)
                    return;
                  this.turningWait = this.rr.Next(200, 360);
                }
              }
            }
            else
            {
              this.gonnaShit = false;
              this.cuttyStruct.dur = (ushort) this.rr.Next(180, 320);
              this.cuttyStruct.rot = this.cuttyRot;
              this.scheduleAction(145);
              this.shitDelay = 5000f;
            }
          }
        }
      }
    }

    private void pigBones(Vector3 lookVec, ref float[,] heights)
    {
      this.talkSmooth = 0.0f;
      this.lookingatPig = false;
      this.distanceCutty = Vector2.DistanceSquared(new Vector2(this.playerpos.X, this.playerpos.Z), new Vector2(this.cuttyPos.X, this.cuttyPos.Z));
      this.distanceCutty2 = 100000f;
      if (!this.spectator)
        this.distanceCutty2 = Vector2.DistanceSquared(new Vector2(this.remotepos.X, this.remotepos.Z), new Vector2(this.cuttyPos.X, this.cuttyPos.Z));
      if (this.attack1)
        this.pigAttack(ref heights);
      else if (this.cuttyRoll)
        this.pigRoll();
      else if (this.death1)
        this.pigDying();
      else if (this.cuttyBuck)
        this.pigBuck();
      else
        this.pigWaiting();
      if (this.myClip != this.clipIndexA)
      {
        this.tween = 0.0f;
        this.clipIndexB = this.clipIndexA;
        this.clipIndexA = this.myClip;
      }
      this.a = this.pig1[this.clipIndexA];
      this.b = this.pig1[this.clipIndexB];
      if (this.explodeTimer > 0)
        this.volumeBurps();
      this.isSpeaking = false;
      if (this.pigJawIndex >= 0)
      {
        this.isSpeaking = true;
        this.talkSmooth = this.pigJaw[this.pigJawIndex] * 1f;
        ++this.pigJawIndex;
        if ((double) this.talkSmooth > 0.0 && !this.attack1 && (this.homingTimer > 0 || this.death1) && !this.cuttyShit)
        {
          float amount = MathHelper.Clamp((float) (((double) this.talkSmooth - 10.0) / 30.0), 0.0f, 1f);
          int width = (int) MathHelper.Lerp(50f, 350f, amount);
          int thick = (int) MathHelper.Lerp(-100f, -60f, amount);
          float speed = 9f;
          int num = (int) MathHelper.Lerp(0.0f, 17f, amount);
          Matrix.CreateFromYawPitchRoll(-3.07897329f, -0.5f, 0.009578228f, out this.m1);
          Matrix.CreateTranslation(-1.5515343f, 67.19339f, 113.698441f, out this.m2);
          Matrix.Multiply(ref this.m1, ref this.m2, out this.m3);
          Matrix.Multiply(ref this.m3, ref this.princessBone[7], out this.m4);
          Vector3 zero = Vector3.Zero;
          Vector3.Transform(ref zero, ref this.m4, out this.vomitpos);
          if (this.oldvomitpos == Vector3.Zero)
            this.oldvomitpos = this.vomitpos;
          this.vomitveloc = this.vomitpos - this.oldvomitpos;
          this.oldvomitpos = this.vomitpos;
          for (int index = 0; index < num; ++index)
          {
            if (this.death1)
            {
              speed = 5f;
              this.dropPuke2(ref this.puke1, thick, width, speed, this.m4);
            }
            else
              this.dropPuke(ref this.puke1, thick, width, speed, this.m4);
          }
        }
        else
        {
          this.oldvomitpos = Vector3.Zero;
          this.vomitveloc = Vector3.Zero;
        }
        if ((double) this.pigJaw[this.pigJawIndex] == -1.0)
        {
          this.pigJawIndex = -1;
          Princess.someoneTalking = false;
          this.pigLine = -1;
          this.talkSmooth = 0.0f;
          this.oldvomitpos = Vector3.Zero;
          this.vomitveloc = Vector3.Zero;
          if (this.homingTimer > 0)
            this.homingTimer = 2;
        }
      }
      this.currentTimeValue = TimeSpan.FromSeconds((double) this.pigFrame1 * 0.041700001806020737 % this.a.currentClipValue.Duration.TotalSeconds);
      this.currentKeyframe = (int) (this.currentTimeValue.TotalSeconds * 60.0) * 22;
      this.currentTimeValue += TimeSpan.FromSeconds(0.041999999433755875);
      this.a.UpdateBoneTransforms2(this.currentKeyframe, this.currentTimeValue);
      if ((double) this.tween < 1.0)
      {
        double num = (double) this.bFrame1 * 0.041700001806020737;
        this.tween += 0.05f;
        this.currentTimeValue = TimeSpan.FromSeconds(num % this.b.currentClipValue.Duration.TotalSeconds);
        this.currentKeyframe = (int) (this.currentTimeValue.TotalSeconds * 60.0) * 22;
        this.currentTimeValue += TimeSpan.FromSeconds(0.041999999433755875);
        this.b.UpdateBoneTransforms2(this.currentKeyframe, this.currentTimeValue);
        for (int index = 0; index < this.b.boneTransforms.Length; ++index)
          this.a.boneTransforms[index] = Matrix.Lerp(this.b.boneTransforms[index], this.a.boneTransforms[index], this.tween);
      }
      float num1 = 0.0f;
      if (this.homingTimer > 0)
      {
        float cuttyRot = this.cuttyRot;
        this.bonePos = this.homingTimer <= this.homingStart - 50 ? Vector3.Transform(new Vector3(0.0f, 77f, 106f), this.princessBone[7]) : Vector3.Transform(new Vector3(0.0f, 86f, 17f), this.princessBone[4]);
        float y;
        float x;
        if (this.homing == 1 && this.sc.host || this.homing == 2 && !this.sc.host)
        {
          y = this.bonePos.Z - this.playerpos.Z;
          x = this.bonePos.X - this.playerpos.X;
        }
        else
        {
          y = this.bonePos.Z - this.remotepos.Z;
          x = this.bonePos.X - this.remotepos.X;
        }
        num1 = (float) (-Math.Atan2((double) y, (double) x) - (1.5700000524520874 + (double) cuttyRot));
      }
      if (this.homingTimer > 0 || (double) Math.Abs(this.tiltOffset) > 0.0099999997764825821 || (double) Math.Abs(this.piglook - num1) > 0.0099999997764825821)
      {
        this.hurtBoss = 0;
        float num2 = Princess.WrapAngle(num1 - this.piglook);
        this.piglook = Princess.WrapAngle(this.piglook + ((double) num1 != 0.0 ? MathHelper.Clamp(num2, -0.06f, 0.06f) : MathHelper.Clamp(num2, -0.06f, 0.06f)));
        float max = this.angleView[this.df];
        if ((double) this.healthPerc > 0.40000000596046448)
          max = this.angleView[this.df] * 0.8f;
        if ((double) this.healthPerc > 0.800000011920929)
          max = this.angleView[this.df] * 0.6f;
        this.piglook = MathHelper.Clamp(this.piglook, -max, max);
        if (this.homingTimer > 0)
        {
          this.tiltOffset = -MathHelper.Clamp((float) (((double) Vector2.Distance(new Vector2(this.playerpos.X, this.playerpos.Z), new Vector2(this.bonePos.X, this.bonePos.Z)) - 10.0) / 1100.0), 0.0f, 0.6f);
          this.tiltOffset = (float) (Math.Sin((double) this.sc.myTimer / 16.0) * 0.15000000596046448 + 0.10000000149011612) + this.tiltOffset;
          this.tiltOffset *= MathHelper.Clamp((float) (this.homingStart - this.homingTimer) / 70f, 0.0f, 1f);
        }
        else
          this.tiltOffset *= 0.97f;
        this.a.boneTransforms[7] = Matrix.CreateRotationZ(this.tiltOffset + (float) ((double) Math.Abs(this.piglook) * 0.20000000298023224 * 0.699999988079071)) * Matrix.CreateRotationY((float) (-(double) this.piglook * 0.30000001192092896 * 0.699999988079071)) * Matrix.CreateRotationX(this.piglook * 0.7f) * this.a.boneTransforms[7];
        this.a.boneTransforms[5] = Matrix.CreateRotationZ((float) (0.0 + (double) Math.Abs(this.piglook) * 0.44999998807907104 * 0.30000001192092896)) * Matrix.CreateRotationX((float) (-(double) this.piglook * 0.60000002384185791 * 0.30000001192092896)) * Matrix.CreateRotationY((float) (-(double) this.piglook * 0.30000001192092896)) * this.a.boneTransforms[5];
      }
      this.myTimer1 = (float) (Math.Sin((double) this.sc.myTimer / 32.0) / 2.0 + 0.5);
      this.assScale = Vector3.Hermite(new Vector3(1f, 1f, 1f), Vector3.Zero, new Vector3(0.3f, 0.0f, 0.0f), Vector3.Zero, this.myTimer1);
      if (this.cuttyShit)
        this.assRamp += 0.02f;
      else
        this.assRamp -= 0.02f;
      this.assRamp = MathHelper.Clamp(this.assRamp, 0.0f, 1f);
      if ((double) this.assRamp > 0.0)
      {
        this.myTimer2 = (float) (Math.Sin((double) this.sc.myTimer / 16.0) / 2.0 + 0.5);
        this.assScale2 = Vector3.Hermite(new Vector3(0.2f, -1f, -1f), Vector3.Zero, new Vector3(0.0f, -4f, -4f), Vector3.Zero, this.myTimer2);
        this.assScale = Vector3.Lerp(this.assScale, this.assScale2, this.assRamp);
      }
      if (this.cuttyShit)
      {
        --this.shitTimer;
        if ((double) this.shitTimer < 60.0)
          this.shitVol = false;
        if ((double) this.shitTimer <= 0.0)
        {
          this.cuttyShit = false;
          this.shitTimer = 0.0f;
          this.shitDelay = (float) this.rr.Next(950, 1880);
          if (this.heartExposed)
            this.shitDelay = (float) this.rr.Next(1250, 2450);
        }
        if ((double) this.shitTimer > 60.0)
        {
          Matrix.CreateTranslation(-1f, 64f, -82f, out this.m2);
          Matrix.Multiply(ref this.m2, ref this.princessBone[2], out this.m4);
          Vector3 zero = Vector3.Zero;
          Vector3.Transform(ref zero, ref this.m4, out this.vomitpos);
          if (this.oldvomitpos == Vector3.Zero)
            this.oldvomitpos = this.vomitpos;
          this.vomitveloc = this.vomitpos - this.oldvomitpos;
          this.oldvomitpos = this.vomitpos;
          for (int index = 0; index < 15; ++index)
            this.dropShit(ref this.puke1, 5.2f + this.myTimer2, this.m4, this.myTimer2);
        }
      }
      if (!this.jumpVol && !this.rollVol && !this.vomitVol && !this.shitVol && !this.heartVol)
        this.volumeFade = false;
      this.a.boneTransforms[21] = Matrix.CreateScale(this.assScale) * this.a.boneTransforms[21];
      this.heartMatrix = this.a.boneTransforms[17];
      if (this.explodeTimer > 0)
      {
        float num3 = 19f;
        float num4 = 1.4f;
        if (this.death1 || (double) this.heartattack > 0.0)
          num3 = 8f;
        this.a.boneTransforms[17] = Matrix.CreateScale(MathHelper.Lerp(0.25f, num4, (float) (Math.Sin((double) this.sc.myTimer / (double) num3) / 2.0 + 0.5))) * this.a.boneTransforms[17];
      }
      if (this.isSpeaking)
      {
        this.a.boneTransforms[9] = Matrix.CreateRotationZ(MathHelper.ToRadians(0.0f - this.talkSmooth)) * this.a.boneTransforms[9];
        this.a.boneTransforms[6] = Matrix.CreateRotationX(MathHelper.ToRadians((float) (0.0 - (double) this.talkSmooth / 8.0 * Math.Sin((double) this.sc.myTimer / 14.0)))) * this.a.boneTransforms[6];
      }
      if (!this.cuttyisDead)
      {
        this.cuttyVeloc = this.cuttyPos - this.oldcuttyPos;
        this.oldcuttyPos = this.cuttyPos;
        for (int index = 0; index < this.col_Bone.Length - 1; ++index)
        {
          Vector3 vector3 = Vector3.Transform(this.col_Pos[index], this.princessBone[this.col_Bone[index]]);
          float num5 = this.col_Scale[index] * this.cuttyScale * this.hitScale[this.df];
          float num6 = Vector3.Distance(new Vector3(this.playerpos.X, this.playerpos.Y + 90f, this.playerpos.Z), vector3);
          float num7 = Vector3.Distance(new Vector3(this.playerpos.X, this.playerpos.Y, this.playerpos.Z), vector3);
          if ((double) num6 < (double) num5 || (double) num7 < (double) num5)
          {
            this.cuttyCollide = true;
            break;
          }
        }
        float num8 = this.cuttyRot;
        float max = 0.005f;
        if (this.homingDirection > 0)
        {
          num8 = this.targetRot;
          max = 0.02f;
        }
        this.cuttyRot = Princess.WrapAngle(this.cuttyRot + MathHelper.Clamp(Princess.WrapAngle(num8 - this.cuttyRot), -max, max));
        if (this.homingDirection > 0 && (double) Math.Abs(Princess.WrapAngle(this.targetRot - this.cuttyRot)) <= 0.019999999552965164)
        {
          this.homingDirection = 0;
          if (this.homing == 0)
          {
            this.newAction = false;
            this.turningWait = this.rr.Next(400, 950);
            if (this.heartExposed)
              this.turningWait = this.rr.Next(200, 460);
            if ((double) this.buckDelay < 50.0)
              this.buckDelay = 70f;
            if (this.nextAttack < 50)
              this.nextAttack = 70;
            if ((double) this.gonnaRollDelay < 50.0)
              this.gonnaRollDelay = 70f;
            if ((double) this.shitDelay <= 50.0)
              this.shitDelay = 70f;
          }
        }
        if (this.homingTimer > 0)
        {
          --this.homingTimer;
          if (this.homingTimer == this.homingStart - 10)
          {
            this.talkIndex = this.rr.Next(1, 3);
            Princess.whichPigTalks = this.myIndex;
          }
          if (this.homingTimer <= 0)
          {
            this.newAction = false;
            this.vomitVol = false;
            this.gonnaVomit = false;
            this.homing = 0;
            this.homingDirection = 0;
            this.turningWait = this.rr.Next(300, 900);
            if (this.heartExposed)
              this.turningWait = this.rr.Next(150, 360);
            if ((double) this.shitDelay <= 50.0)
              this.shitDelay = 70f;
            if ((double) this.buckDelay <= 50.0)
              this.buckDelay = 70f;
            if ((double) this.gonnaRollDelay <= 50.0)
              this.gonnaRollDelay = 70f;
            if (this.nextAttack <= 50)
              this.nextAttack = 70;
          }
        }
      }
      else
      {
        --this.explodeTimer;
        if (this.explodeTimer <= 0)
          this.updateExplode(ref heights);
        else if (this.explodeTimer == 5)
        {
          this.explode.Play(this.sc.ev, 0.0f, 0.0f);
          this.initExplode();
        }
      }
      if (this.faceseizureTimer > 0)
      {
        --this.faceseizureTimer;
        if (this.faceseizureTimer % 2 == 0)
        {
          Math.Cos((double) this.sc.myTimer / 26.0);
          float num9 = (float) (380.0 + Math.Sin((double) this.sc.myTimer / 34.0) * 220.0);
          float num10 = (float) (480.0 + Math.Cos((double) this.sc.myTimer / 24.0) * 200.0);
          this.a.boneTransforms[7] = Matrix.CreateRotationY((float) this.rr.Next(-15, 15) / num10) * this.a.boneTransforms[7];
          this.a.boneTransforms[7] = Matrix.CreateRotationZ((float) this.rr.Next(-13, 13) / num9) * this.a.boneTransforms[7];
        }
      }
      if (this.seizureTimer > 0)
      {
        --this.seizureTimer;
        float num11 = (float) (350.0 + Math.Cos((double) this.sc.myTimer / 26.0) * 300.0);
        float num12 = (float) (350.0 + Math.Sin((double) this.sc.myTimer / 34.0) * 300.0);
        float num13 = (float) (480.0 + Math.Cos((double) this.sc.myTimer / 24.0) * 200.0);
        this.a.boneTransforms[5] = Matrix.CreateRotationZ((float) this.rr.Next(-10, 10) / num13) * this.a.boneTransforms[5];
        this.a.boneTransforms[5] = Matrix.CreateRotationX((float) this.rr.Next(-10, 10) / num13) * this.a.boneTransforms[5];
        this.a.boneTransforms[12] = Matrix.CreateRotationX((float) this.rr.Next(-20, 20) / num13) * this.a.boneTransforms[12];
        this.a.boneTransforms[12] = Matrix.CreateRotationY((float) this.rr.Next(-20, 20) / num11) * this.a.boneTransforms[12];
        this.a.boneTransforms[13] = Matrix.CreateRotationX((float) this.rr.Next(-10, 10) / num12) * this.a.boneTransforms[13];
        this.a.boneTransforms[13] = Matrix.CreateRotationY((float) this.rr.Next(-20, 20) / num11) * this.a.boneTransforms[13];
        this.a.boneTransforms[16] = Matrix.CreateRotationX((float) this.rr.Next(-10, 10) / num11) * this.a.boneTransforms[16];
        this.a.boneTransforms[16] = Matrix.CreateRotationY((float) this.rr.Next(-10, 10) / num11) * this.a.boneTransforms[16];
        this.a.boneTransforms[17] = Matrix.CreateRotationX((float) this.rr.Next(-20, 20) / num12) * this.a.boneTransforms[17];
        this.a.boneTransforms[17] = Matrix.CreateRotationY((float) this.rr.Next(-20, 20) / num11) * this.a.boneTransforms[17];
        this.a.boneTransforms[7] = Matrix.CreateRotationY((float) this.rr.Next(-20, 20) / num13) * this.a.boneTransforms[7];
        this.a.boneTransforms[20] = Matrix.CreateRotationX((float) this.rr.Next(-20, 20) / num11) * this.a.boneTransforms[20];
        this.a.boneTransforms[20] = Matrix.CreateRotationY((float) this.rr.Next(-10, 10) / num12) * this.a.boneTransforms[20];
      }
      this.cuttyTrans = Matrix.CreateScale(this.cuttyScale) * Matrix.CreateRotationY(this.cuttyRot) * Matrix.CreateTranslation(this.cuttyPos);
      this.a.UpdateWorldTransforms(this.cuttyTrans, this.a.boneTransforms);
      this.a.skinTransforms.CopyTo((Array) this.princessBone, 0);
    }

    private void pigWaiting()
    {
      this.myClip = 0;
      this.fps = 0.4f;
      if (this.homingDirection == 1)
      {
        this.myClip = 5;
        this.fps = 0.8f;
      }
      if (this.homingDirection == 2)
      {
        this.myClip = 6;
        this.fps = 0.8f;
      }
      this.pigFrame1 += this.fps;
      this.bFrame1 += this.fps;
    }

    private void pigDying()
    {
      this.attack1 = false;
      this.myClip = 4;
      if (this.clipIndexA != 4)
      {
        this.sc.dieyell.Play(this.sc.ev, 0.0f, 0.0f);
        this.myClip = 4;
        this.bFrame1 = this.pigFrame1;
        this.pigFrame1 = 0.0f;
      }
      if (!this.cuttyisDead && (double) this.pigFrame1 >= 30.0 && (double) this.pigFrame1 < 30.5)
      {
        this.talkIndex = 0;
        Princess.whichPigTalks = this.myIndex;
        if (!this.spineDestroyed)
          this.spineSwitch();
        else if (!this.assDestroyed)
          this.assSwitch();
        else if (!this.faceDestroyed)
          this.faceSwitch();
      }
      if (!this.cuttyisDead && (double) this.pigFrame1 >= 89.0 && (double) this.pigFrame1 < 89.5)
      {
        if (!this.spineDestroyed)
          this.spineSwitch();
        else if (!this.assDestroyed)
          this.assSwitch();
        else if (!this.faceDestroyed)
          this.faceSwitch();
      }
      if (this.cuttyisDead)
        return;
      this.fps = 0.4f;
      this.pigFrame1 += this.fps;
      this.bFrame1 += this.fps;
      if ((double) this.pigFrame1 < 119.0)
        return;
      this.cuttyisDead = true;
      this.bFrame1 = this.pigFrame1;
      this.pigFrame1 = 119f;
    }

    private void pigRoll()
    {
      this.myClip = 3;
      this.fps = 0.6f;
      if (this.cuttyRollCount < 1)
      {
        this.cuttyRollFade -= 0.012f;
        if ((double) this.cuttyRollFade <= 0.0)
          this.cuttyRollFade = 0.0f;
      }
      else
      {
        this.energize();
        this.energize();
        this.energize();
        this.energize();
      }
      if ((double) this.pigFrame1 > 61.0 && this.cuttyRollCount > 0)
      {
        this.pigFrame1 = 34.2f;
        --this.cuttyRollCount;
        this.dogroll.Play(this.sc.ev, (float) this.rr.Next(-10, 10) / 100f, 0.0f);
      }
      if ((double) this.pigFrame1 >= 65.0)
        this.rollVol = false;
      if ((double) this.pigFrame1 >= 100.0)
      {
        this.cuttyRoll = false;
        this.newAction = false;
        this.cuttyRollFade = 1f;
        this.gonnaRollDelay = (float) this.rr.Next(500, 1150);
        if ((double) this.healthPerc < 0.60000002384185791 && (double) this.healthPerc > 0.20000000298023224)
          this.gonnaRollDelay = (float) this.rr.Next(720, 1350);
        if (this.heartExposed)
          this.gonnaRollDelay = (float) this.rr.Next(1200, 2200);
        if (this.nextAttack <= 50)
          this.nextAttack = 70;
        if (this.turningWait <= 50)
          this.turningWait = 70;
        if ((double) this.buckDelay <= 50.0)
          this.buckDelay = 70f;
        if ((double) this.shitDelay <= 50.0)
          this.shitDelay = 70f;
      }
      this.bFrame1 = this.pigFrame1;
      this.pigFrame1 += this.fps;
      this.bFrame1 += this.fps;
    }

    private void pigAttack(ref float[,] heights)
    {
      this.myClip = 2;
      this.fps = 0.0f;
      --this.attackWait1;
      if ((double) this.attackWait1 <= 0.0)
      {
        this.attackWait1 = 0.0f;
        ++this.attacktimer;
        if ((double) this.attacktimer > (double) this.attackduration)
        {
          this.attacktimer = this.attackduration + 5f;
          --this.attackWait2;
        }
      }
      if ((double) this.attackWait1 > 0.0)
      {
        this.fps = 0.4f;
        this.cuttyPos.Y = -54f;
        if (this.df != 2 && this.df != 5 && (double) this.attackWait1 == 1.0 && !this.shootHeartMessage && this.heartExposed)
        {
          if (this.df != 0 && this.df != 3)
          {
            ++this.heartMessCount;
            if (this.heartMessCount < 5 && this.sc.currentDay < 30)
              this.shootHeartMessage = true;
          }
          else
          {
            ++this.heartMessCount;
            this.shootHeartMessage = true;
          }
        }
      }
      if ((double) this.attackWait2 > 0.0 && (double) this.attackWait1 <= 0.0 && (double) this.attacktimer <= (double) this.attackduration)
      {
        this.upForceAcc += 5f;
        if ((double) this.upForceAcc >= (double) this.upForceMax)
        {
          this.upForceAcc = this.upForceMax;
          this.upForce -= this.grav;
        }
        else
          this.upForce = this.upForceAcc;
        this.cuttyPos.Y += this.upForce;
        if ((double) this.cuttyPos.Y < 0.0 && (double) this.upForce < 0.0)
        {
          this.volumeFade = true;
          this.jumpVol = true;
        }
        if ((double) this.cuttyPos.Y < -54.0)
        {
          this.cuttyPos.Y = -54f;
          this.attacktimer = this.attackduration + 1f;
          this.pigFrame1 = 54f;
        }
        else if ((double) this.attacktimer >= (double) this.attackduration - 1.0)
          this.attacktimer = this.attackduration - 3f;
        this.fps = 0.4f;
        if ((double) this.pigFrame1 > 54.0)
          this.pigFrame1 = 54f;
      }
      if ((double) this.attackWait2 > 0.0 && (double) this.attacktimer > (double) this.attackduration)
      {
        if ((double) this.attackWait2 == 55.0)
        {
          this.sc.cuttyWave.Play(this.sc.ev, 0.0f, 0.0f);
          this.shockTimer = 145f;
          this.shockRadius = 150f;
          this.shockHit = false;
          this.shockHasHit = false;
          this.groundhit = true;
        }
        if ((double) this.pigFrame1 < 54.0)
          this.pigFrame1 = 54f;
        this.cuttyPos.Y = -54f;
        this.fps = 0.4f;
      }
      if ((double) this.attackWait2 <= 0.0)
      {
        this.attack1 = false;
        this.nextAttack = this.rr.Next(500, 1200);
        if (this.heartExposed)
          this.nextAttack = this.rr.Next(150, 560);
        this.newAction = false;
        if ((double) this.buckDelay <= 50.0)
          this.buckDelay = 70f;
        if ((double) this.gonnaRollDelay <= 50.0)
          this.gonnaRollDelay = 70f;
        if (this.nextAttack <= 50)
          this.nextAttack = 70;
        if ((double) this.shitDelay <= 50.0)
          this.shitDelay = 70f;
      }
      this.bFrame1 = this.pigFrame1;
      this.pigFrame1 += this.fps;
      this.bFrame1 += this.fps;
    }

    private void pigBuck()
    {
      this.myClip = 1;
      this.fps = 0.4f;
      if ((double) this.pigFrame1 >= 45.0)
      {
        this.cuttyBuck = false;
        this.newAction = false;
        this.buckDelay = (float) this.rr.Next(800, 1450);
        if ((double) this.healthPerc > 0.800000011920929)
          this.buckDelay = (float) this.rr.Next(500, 950);
        if (this.heartExposed)
          this.buckDelay = (float) this.rr.Next(2500, 5250);
        if (this.nextAttack <= 50)
          this.nextAttack = 70;
        if ((double) this.gonnaRollDelay <= 50.0)
          this.gonnaRollDelay = 70f;
        if (this.turningWait <= 50)
          this.turningWait = 70;
        if ((double) this.shitDelay <= 50.0)
          this.shitDelay = 70f;
      }
      this.bFrame1 = this.pigFrame1;
      this.pigFrame1 += this.fps;
      this.bFrame1 += this.fps;
    }

    public void host_SendData(ref packetSender packetWriter, int timeFrame)
    {
      if (this.cuttyStruct_send.flag == 140)
      {
        packetWriter.Write((byte) 140);
        packetWriter.Write((byte) this.myIndex);
        packetWriter.Write((byte) this.cuttyStruct_send.homing);
        packetWriter.Write(this.cuttyStruct_send.rot);
        packetWriter.Write((byte) this.cuttyStruct_send.animType);
        if (this.cuttyStruct_send.talkindex > -1)
          packetWriter.Write((byte) this.cuttyStruct_send.talkindex);
        else
          packetWriter.Write((byte) 150);
      }
      if (this.cuttyStruct_send.flag == 141)
      {
        packetWriter.Write((byte) 141);
        packetWriter.Write((byte) this.myIndex);
        packetWriter.Write(this.cuttyStruct_send.dur);
      }
      if (this.cuttyStruct_send.flag == 142)
      {
        packetWriter.Write((byte) 142);
        packetWriter.Write((byte) this.myIndex);
        packetWriter.Write(this.cuttyStruct_send.dur);
        packetWriter.Write(this.cuttyStruct_send.rot);
      }
      if (this.cuttyStruct_send.flag == 143)
      {
        packetWriter.Write((byte) 143);
        packetWriter.Write((byte) this.myIndex);
        packetWriter.Write(this.cuttyStruct_send.dur);
        packetWriter.Write(this.cuttyStruct_send.rot);
        if (this.cuttyStruct_send.talkindex > -1)
          packetWriter.Write((byte) this.cuttyStruct_send.talkindex);
        else
          packetWriter.Write((byte) 150);
      }
      if (this.cuttyStruct_send.flag == 144)
      {
        packetWriter.Write((byte) 144);
        packetWriter.Write((byte) this.myIndex);
        packetWriter.Write(this.cuttyStruct_send.dur);
        packetWriter.Write(this.cuttyStruct_send.rot);
      }
      if (this.cuttyStruct_send.flag == 145)
      {
        packetWriter.Write((byte) 145);
        packetWriter.Write((byte) this.myIndex);
        packetWriter.Write(this.cuttyStruct_send.dur);
        packetWriter.Write(this.cuttyStruct_send.rot);
      }
      if (this.cuttyStruct_send.flag == 146)
      {
        packetWriter.Write((byte) 146);
        packetWriter.Write((byte) this.myIndex);
        if (this.cuttyStruct_send.talkindex > -1)
          packetWriter.Write((byte) this.cuttyStruct_send.talkindex);
        else
          packetWriter.Write((byte) 150);
      }
      this.actionScheduled = false;
    }

    private void scheduleAction(int flag)
    {
      this.delay = 0.0f;
      if (this.networkSession != null && this.networkSession.RemoteGamers.Count > 0)
        this.delay = (float) (this.networkSession.RemoteGamers[0].RoundtripTime.Milliseconds / 2);
      this.delay = (float) Math.Round((double) this.delay * 0.059999998658895493);
      this.timeDelay = this.timeframe + (int) this.delay;
      if (this.timeDelay <= this.lasttimeDelay && this.lasttimeDelay - this.timeDelay < 60)
        this.timeDelay = this.lasttimeDelay + 1;
      this.lasttimeDelay = this.timeDelay;
      if (flag == 140)
      {
        this.cuttyStruct_send.flag = flag;
        this.cuttyStruct_send.time = this.timeDelay;
        this.cuttyStruct_send.homing = this.cuttyStruct.homing;
        this.cuttyStruct_send.rot = this.cuttyStruct.rot;
        this.cuttyStruct_send.animType = this.cuttyStruct.animType;
        this.cuttyStruct_send.talkindex = this.cuttyStruct.talkindex;
      }
      if (flag == 141)
      {
        this.cuttyStruct_send.flag = flag;
        this.cuttyStruct_send.time = this.timeDelay;
        this.cuttyStruct_send.dur = this.cuttyStruct.dur;
      }
      if (flag == 142)
      {
        this.cuttyStruct_send.flag = flag;
        this.cuttyStruct_send.time = this.timeDelay;
        this.cuttyStruct_send.dur = this.cuttyStruct.dur;
        this.cuttyStruct_send.rot = this.cuttyStruct.rot;
      }
      if (flag == 143)
      {
        this.cuttyStruct_send.flag = flag;
        this.cuttyStruct_send.time = this.timeDelay;
        this.cuttyStruct_send.dur = this.cuttyStruct.dur;
        this.cuttyStruct_send.rot = this.cuttyStruct.rot;
        this.cuttyStruct_send.talkindex = this.cuttyStruct.talkindex;
      }
      if (flag == 144)
      {
        this.cuttyStruct_send.flag = flag;
        this.cuttyStruct_send.time = this.timeDelay;
        this.cuttyStruct_send.dur = this.cuttyStruct.dur;
        this.cuttyStruct_send.rot = this.cuttyStruct.rot;
      }
      if (flag == 145)
      {
        this.cuttyStruct_send.flag = flag;
        this.cuttyStruct_send.time = this.timeDelay;
        this.cuttyStruct_send.dur = this.cuttyStruct.dur;
        this.cuttyStruct_send.rot = this.cuttyStruct.rot;
      }
      if (flag == 146)
      {
        this.cuttyStruct_send.flag = flag;
        this.cuttyStruct_send.time = this.timeDelay;
        this.cuttyStruct_send.talkindex = this.cuttyStruct.talkindex;
      }
      this.scheduleList.Add(this.cuttyStruct_send);
      this.actionScheduled = true;
    }

    private void runScheduler(ref float[,] heights)
    {
      for (int index = 0; index < this.scheduleList.Count; ++index)
      {
        this.tempConduct = this.scheduleList[index];
        if (this.timeframe >= this.tempConduct.time || Math.Abs(this.tempConduct.time - this.timeframe) > 120)
        {
          this.princessAction(ref this.tempConduct, true, ref heights);
          this.scheduleList.RemoveAt(index);
        }
      }
    }

    public void princessAction(ref Princess.conductor tempy, bool isLocal, ref float[,] heights)
    {
      if (tempy.flag == 140)
      {
        this.homing = tempy.homing;
        this.homingDirection = tempy.animType;
        if (this.homing == 5)
        {
          this.homing = 0;
          this.gonnaShit = true;
          this.volumeFade = true;
          this.shitVol = true;
        }
        this.targetRot = tempy.rot;
        if (this.homing > 0 && this.homing < 5)
        {
          this.homingTimer = this.homingStart;
          this.volumeFade = true;
          this.vomitVol = true;
        }
        if (tempy.talkindex > -1)
        {
          this.talkIndex = tempy.talkindex;
          Princess.whichPigTalks = this.myIndex;
        }
        else
        {
          Princess.cuttyDoneSpeech = true;
          this.cuttyDoneLocalSpeech = true;
        }
      }
      if (tempy.flag == 141)
      {
        this.attack1 = true;
        this.bFrame1 = this.pigFrame1;
        this.pigFrame1 = 0.0f;
        this.attacktimer = 0.0f;
        this.attackWait1 = 42f;
        this.attackWait2 = 62f;
        this.attackduration = (float) tempy.dur;
        this.attackduration = (double) this.attackduration != 2500.0 ? MathHelper.Lerp(110f, 200f, (float) (((double) this.attackduration - 500.0) / 1400.0)) : (float) this.rr.Next(70, 85);
        this.grav = 0.5f;
        this.upForceAcc = 0.0f;
        this.upForce = 0.0f;
        this.upForceMax = this.grav * (this.attackduration / 2f);
      }
      if (tempy.flag == 142)
      {
        this.death1 = true;
        this.cuttyisDead = false;
        this.health = (ushort) 0;
      }
      if (tempy.flag == 143)
      {
        this.bFrame1 = this.pigFrame1;
        this.pigFrame1 = 0.0f;
        this.cuttyRoll = true;
        this.cuttyRollCount = (int) tempy.dur;
        if (this.cuttyRollCount > 3)
          this.windy.Play(this.sc.ev, (float) this.rr.Next(-20, 10) / 100f, 0.0f);
        else
          this.windy.Play(this.sc.ev, (float) this.rr.Next(50, 70) / 100f, 0.0f);
        this.volumeFade = true;
        this.rollVol = true;
        if (tempy.talkindex > -1)
        {
          this.talkIndex = tempy.talkindex;
          Princess.whichPigTalks = this.myIndex;
        }
      }
      if (tempy.flag == 144)
      {
        this.cuttyBuck = true;
        this.bFrame1 = this.pigFrame1;
        this.pigFrame1 = 0.0f;
        this.bucking.Play(this.sc.ev, 0.0f, 0.0f);
      }
      if (tempy.flag == 145)
      {
        this.cuttyShit = true;
        this.shitDelay = 5000f;
        this.shitTimer = (float) tempy.dur;
        this.fart.Play(this.sc.ev, (float) this.rr.Next(-50, 10) / 100f, 0.0f);
        this.volumeFade = true;
        this.shitVol = true;
      }
      if (tempy.flag != 146)
        return;
      if (tempy.talkindex > -1)
      {
        this.talkIndex = tempy.talkindex;
        Princess.whichPigTalks = this.myIndex;
      }
      else
      {
        Princess.cuttyDoneSpeech = true;
        this.cuttyDoneLocalSpeech = true;
      }
    }

    private static float WrapAngle(float radians)
    {
      while ((double) radians < -3.1415927410125732)
        radians += 6.28318548f;
      while ((double) radians > 3.1415927410125732)
        radians -= 6.28318548f;
      return radians;
    }

    public void Draw(
      Vector3 campos,
      Matrix view,
      Matrix proj,
      bool showSphere,
      ref Texture2D ttworld,
      Matrix viewWorld,
      int tech,
      bool walletopen)
    {
      this.campos = campos;
      this.view = view;
      this.proj = proj;
      if (this.chunk.startDrop)
        this.DrawInstance(this.chunk, "fastShader4");
      if (this.faceChunk.startDrop)
        this.DrawInstance(this.faceChunk, "fastShader4");
      if (this.assChunk.startDrop)
        this.DrawInstance(this.assChunk, "fastShader4");
      if (this.death1)
        this.sc.GraphicsDevice.RasterizerState = RasterizerState.CullNone;
      if (this.explodeTimer > 0)
        this.drawPrincess(ref ttworld, viewWorld, tech);
      else
        this.drawExplode();
      if (this.explodeTimer < 5)
        this.drawGuts();
      if (this.death1)
        this.sc.GraphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;
      if (this.sc.bossLoaded && this.explodeTimer > 0 && this.heartExposed)
      {
        this.sc.GraphicsDevice.DepthStencilState = DepthStencilState.None;
        float dist = Vector2.Distance(new Vector2(campos.X, campos.Z), new Vector2(this.cuttyPos.X, this.cuttyPos.Z));
        if (!walletopen)
          this.drawHeart(dist);
        this.sc.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
      }
      if (this.showSkelTimer <= 0 || this.cuttyisDead)
        return;
      --this.showSkelTimer;
      if (this.showSkelTimer < 0)
        this.showSkelTimer = 0;
      if (this.showSkelTimer % 5 != 0)
        return;
      this.sc.GraphicsDevice.DepthStencilState = DepthStencilState.None;
      this.sc.GraphicsDevice.BlendState = BlendState.Additive;
      this.drawCuttySkel();
      this.sc.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
      this.sc.GraphicsDevice.BlendState = BlendState.NonPremultiplied;
    }

    public void DrawBoulders(Vector3 campos)
    {
      this.rocks.SetCamera(this.view, this.proj);
      this.rocks.Draw(0);
    }

    public void drawDots()
    {
      this.dots.SetCamera(this.view, this.proj);
      this.dots.Draw(0);
    }

    public void resetExplody(bool death)
    {
      if (death)
      {
        this.explodeTimer = 50;
        this.death1 = false;
        this.pigFrame1 = 0.0f;
        this.cuttyStruct.dur = (ushort) 40;
        this.cuttyStruct.rot = this.cuttyRot;
        this.scheduleAction(142);
      }
      int num = 390;
      this.explodePart = new Matrix[390];
      this.explodePart[0] = Matrix.CreateScale(14.4770775f, 11.2121181f, 8.26777649f) * Matrix.CreateTranslation(-24.7192039f, 28.82737f, 98.2355652f);
      this.explodePart[1] = Matrix.CreateScale(15.8450623f, 13.7972507f, 9.090149f) * Matrix.CreateTranslation(-23.6899433f, 19.77886f, 98.3357544f);
      this.explodePart[2] = Matrix.CreateScale(17.4130974f, 21.4828186f, 33.9534378f) * Matrix.CreateTranslation(1.65366387f, 67.8324051f, -95.31728f);
      this.explodePart[3] = Matrix.CreateScale(22.4398041f, 30.7695618f, 41.8243942f) * Matrix.CreateTranslation(10.01247f, 47.05307f, -93.637f);
      this.explodePart[4] = Matrix.CreateScale(19.0596581f, 20.0293884f, 42.9884949f) * Matrix.CreateTranslation(0.8243537f, 81.26076f, -84.04066f);
      this.explodePart[5] = Matrix.CreateScale(19.2028f, 28.08191f, 62.05641f) * Matrix.CreateTranslation(7.27769375f, 63.8781776f, -81.66424f);
      this.explodePart[6] = Matrix.CreateScale(15.1004181f, 18.2701263f, 30.98259f) * Matrix.CreateTranslation(0.677528143f, 72.45757f, -75.2011261f);
      this.explodePart[7] = Matrix.CreateScale(19.9726486f, 24.4801331f, 36.26729f) * Matrix.CreateTranslation(8.476687f, 56.1039963f, -68.76012f);
      this.explodePart[8] = Matrix.CreateScale(21.6068916f, 19.5090828f, 35.45726f) * Matrix.CreateTranslation(-24.0604057f, 68.10201f, -87.5686f);
      this.explodePart[9] = Matrix.CreateScale(40.9519043f, 17.9072189f, 49.5625153f) * Matrix.CreateTranslation(-16.16684f, 57.6215057f, -81.8079f);
      this.explodePart[10] = Matrix.CreateScale(22.91507f, 20.475647f, 62.72592f) * Matrix.CreateTranslation(-13.84039f, 77.5453339f, -72.96725f);
      this.explodePart[11] = Matrix.CreateScale(25.1755447f, 26.5256271f, 71.84491f) * Matrix.CreateTranslation(-6.78990269f, 62.5605164f, -72.38807f);
      this.explodePart[12] = Matrix.CreateScale(16.2295532f, 19.7223f, 27.7150955f) * Matrix.CreateTranslation(15.3734856f, 29.21568f, 77.74955f);
      this.explodePart[13] = Matrix.CreateScale(17.9194145f, 29.104538f, 28.817627f) * Matrix.CreateTranslation(22.88195f, 9.356084f, 81.37706f);
      this.explodePart[14] = Matrix.CreateScale(17.4487534f, 17.945179f, 51.2271271f) * Matrix.CreateTranslation(14.35212f, 42.52254f, 82.97742f);
      this.explodePart[15] = Matrix.CreateScale(18.75489f, 24.6713524f, 52.8300476f) * Matrix.CreateTranslation(19.5092163f, 27.9348049f, 86.21612f);
      this.explodePart[16] = Matrix.CreateScale(15.7858276f, 20.1220627f, 32.4174042f) * Matrix.CreateTranslation(15.5183878f, 32.50083f, 96.3827744f);
      this.explodePart[17] = Matrix.CreateScale(16.5564537f, 29.6898041f, 28.3560181f) * Matrix.CreateTranslation(21.71776f, 12.9260454f, 98.0993652f);
      this.explodePart[18] = Matrix.CreateScale(30.0158157f, 27.516861f, 35.14643f) * Matrix.CreateTranslation(-12.7490406f, 73.25353f, -27.2979259f);
      this.explodePart[19] = Matrix.CreateScale(31.0348587f, 38.4284134f, 2345f / 64f) * Matrix.CreateTranslation(-1.116889f, 47.157917f, -22.5119267f);
      this.explodePart[20] = Matrix.CreateScale(13.0927238f, 15.2379684f, 52.02321f) * Matrix.CreateTranslation(2.47303081f, 79.73395f, -18.2450466f);
      this.explodePart[21] = Matrix.CreateScale(20.9427719f, 18.4639664f, 41.7236938f) * Matrix.CreateTranslation(10.8162107f, 67.45801f, -3.322219f);
      this.explodePart[22] = Matrix.CreateScale(22.9941254f, 14.6978455f, 108.765106f) * Matrix.CreateTranslation(3.93300319f, 85.14862f, -6.235113f);
      this.explodePart[23] = Matrix.CreateScale(19.2102318f, 19.7856445f, 84.88803f) * Matrix.CreateTranslation(10.3272f, 75.57598f, 8.226435f);
      this.explodePart[24] = Matrix.CreateScale(15.626091f, 16.8935928f, 51.94104f) * Matrix.CreateTranslation(5.584772f, 82.858284f, 27.410841f);
      this.explodePart[25] = Matrix.CreateScale(19.2180176f, 22.0432816f, 45.7770233f) * Matrix.CreateTranslation(11.0459261f, 69.4459839f, 26.98805f);
      this.explodePart[26] = Matrix.CreateScale(37.494648f, 40.3542366f, 32.7109528f) * Matrix.CreateTranslation(-28.310461f, 48.4921341f, 41.111824f);
      this.explodePart[27] = Matrix.CreateScale(60.7146759f, 46.58931f, 44.9161377f) * Matrix.CreateTranslation(-12.9514561f, 16.3996181f, 53.01792f);
      this.explodePart[28] = Matrix.CreateScale(39.0284424f, 33.295372f, 37.5158768f) * Matrix.CreateTranslation(-20.6230125f, 66.4883041f, 43.1314735f);
      this.explodePart[29] = Matrix.CreateScale(38.7563248f, 47.3498154f, 42.2367554f) * Matrix.CreateTranslation(-4.89138937f, 34.503952f, 51.1159973f);
      this.explodePart[30] = Matrix.CreateScale(33.0288f, 28.2645836f, 57.991272f) * Matrix.CreateTranslation(-26.9589977f, 70.70919f, 13.8625078f);
      this.explodePart[31] = Matrix.CreateScale(52.907135f, 26.618103f, 33.70124f) * Matrix.CreateTranslation(-16.9818f, 54.75593f, 4.402969f);
      this.explodePart[32] = Matrix.CreateScale(29.04358f, 19.2313728f, 54.5500336f) * Matrix.CreateTranslation(-29.4950428f, 64.6914444f, -17.1086483f);
      this.explodePart[33] = Matrix.CreateScale(43.1888657f, 17.2819977f, 51.04892f) * Matrix.CreateTranslation(-22.3663559f, 54.92744f, -16.26659f);
      this.explodePart[34] = Matrix.CreateScale(21.4846516f, 18.3734818f, 32.009346f) * Matrix.CreateTranslation(-34.8309937f, 60.37344f, 46.739357f);
      this.explodePart[35] = Matrix.CreateScale(30.3456421f, 20.5705566f, 34.15812f) * Matrix.CreateTranslation(-23.67651f, 46.0856f, 56.83587f);
      this.explodePart[36] = Matrix.CreateScale(26.0079651f, 16.7719955f, 44.7887878f) * Matrix.CreateTranslation(27.7478352f, 58.45891f, 46.6015167f);
      this.explodePart[37] = Matrix.CreateScale(26.2869415f, 20.8171539f, 51.86377f) * Matrix.CreateTranslation(29.9728241f, 48.2990532f, 67.1472855f);
      this.explodePart[38] = Matrix.CreateScale(20.68274f, 19.3252335f, 55.8286133f) * Matrix.CreateTranslation(32.1576462f, 35.80836f, 89.1287155f);
      this.explodePart[39] = Matrix.CreateScale(22.7410583f, 15.6056824f, 39.5073853f) * Matrix.CreateTranslation(31.96695f, 46.7583122f, 77.5795441f);
      this.explodePart[40] = Matrix.CreateScale(0.6192398f, 0.201683044f, 0.6689148f) * Matrix.CreateTranslation(23.0448761f, 40.5665627f, 104.068077f);
      this.explodePart[41] = Matrix.CreateScale(18.2528076f, 11.090745f, 16.89746f) * Matrix.CreateTranslation(43.78763f, 16.61206f, -15.8910217f);
      this.explodePart[42] = Matrix.CreateScale(15.8088493f, 13.4112873f, 12.4124641f) * Matrix.CreateTranslation(40.646534f, 8.695201f, -17.6561813f);
      this.explodePart[43] = Matrix.CreateScale(4.861637f, 5.441223f, 9.439075f) * Matrix.CreateTranslation(41.8224335f, 23.5101967f, 0.188108444f);
      this.explodePart[44] = Matrix.CreateScale(12.355938f, 10.2266617f, 10.0089264f) * Matrix.CreateTranslation(37.045536f, 16.9355659f, -0.311102152f);
      this.explodePart[45] = Matrix.CreateScale(44.4997253f, 27.41536f, 48.5091858f) * Matrix.CreateTranslation(-11.931428f, 37.51112f, -57.8408623f);
      this.explodePart[46] = Matrix.CreateScale(46.2295532f, 38.30728f, 63.03299f) * Matrix.CreateTranslation(-12.7092743f, 19.5747089f, -62.4907761f);
      this.explodePart[47] = Matrix.CreateScale(24.33699f, 16.4522552f, 41.9118652f) * Matrix.CreateTranslation(-25.9925327f, 71.40927f, -63.72718f);
      this.explodePart[48] = Matrix.CreateScale(33.444397f, 19.1965561f, 46.79094f) * Matrix.CreateTranslation(-24.3881721f, 62.71343f, -64.12918f);
      this.explodePart[49] = Matrix.CreateScale(41.41916f, 20.6044159f, 48.0802f) * Matrix.CreateTranslation(-21.2609386f, 55.36613f, -62.5402f);
      this.explodePart[50] = Matrix.CreateScale(50.64865f, 19.7068825f, 38.26271f) * Matrix.CreateTranslation(-16.0151367f, 49.049942f, -53.27703f);
      this.explodePart[51] = Matrix.CreateScale(0.08560181f, 0.01689148f, 0.0660553f) * Matrix.CreateTranslation(-39.325798f, 44.99202f, -58.7752724f);
      this.explodePart[52] = Matrix.CreateScale(12.2883f, 19.992775f, 9549f / 256f) * Matrix.CreateTranslation(-6.0450716f, 64.48841f, -92.82181f);
      this.explodePart[53] = Matrix.CreateScale(22.1835861f, 26.1779976f, 69.61978f) * Matrix.CreateTranslation(-3.41908336f, 46.6790123f, -79.25354f);
      this.explodePart[54] = Matrix.CreateScale(29.6253281f, 30.2159252f, 82.78897f) * Matrix.CreateTranslation(-0.237475872f, 29.2365685f, -72.28792f);
      this.explodePart[55] = Matrix.CreateScale(38.5157623f, 38.9511642f, 75.8085f) * Matrix.CreateTranslation(5.39734936f, 7.356596f, -68.28343f);
      this.explodePart[56] = Matrix.CreateScale(24.8575516f, 17.0466919f, 82.86948f) * Matrix.CreateTranslation(-11.4328337f, 82.44336f, 8.98785f);
      this.explodePart[57] = Matrix.CreateScale(25.84169f, 19.3814011f, 81.69614f) * Matrix.CreateTranslation(-9.275717f, 75.7301941f, 11.5062656f);
      this.explodePart[58] = Matrix.CreateScale(20.0608215f, 17.0951767f, 61.574585f) * Matrix.CreateTranslation(-4.1694293f, 66.6553f, 6.879777f);
      this.explodePart[59] = Matrix.CreateScale(18.4435234f, 23.0261574f, 32.279213f) * Matrix.CreateTranslation(2.72918534f, 52.00983f, -2.47990227f);
      this.explodePart[60] = Matrix.CreateScale(31.2046432f, 19.327961f, 41.41841f) * Matrix.CreateTranslation(-30.9928341f, 47.470192f, 51.0726547f);
      this.explodePart[61] = Matrix.CreateScale(39.83934f, 18.2626076f, 35.09835f) * Matrix.CreateTranslation(-19.0639515f, 35.9397125f, 60.94499f);
      this.explodePart[62] = Matrix.CreateScale(31.8992462f, 26.8799248f, 48.78044f) * Matrix.CreateTranslation(-12.06262f, 38.14187f, 10.80822f);
      this.explodePart[63] = Matrix.CreateScale(45.4189453f, 40.1329651f, 84.17444f) * Matrix.CreateTranslation(-13.6203394f, 14.9370232f, -6.189102f);
      this.explodePart[64] = Matrix.CreateScale(10.4002724f, 7.857049f, 10.8650665f) * Matrix.CreateTranslation(-26.1597919f, -2.77828288f, 3.40860176f);
      this.explodePart[65] = Matrix.CreateScale(8.638336f, 9.4921f, 9.11322f) * Matrix.CreateTranslation(-27.9738922f, -8.927f, 2.64363456f);
      this.explodePart[66] = Matrix.CreateScale(39.75426f, 30.111412f, 46.4996376f) * Matrix.CreateTranslation(-19.011116f, 41.20406f, 10.0744381f);
      this.explodePart[67] = Matrix.CreateScale(47.43918f, 44.1776123f, 90.6597f) * Matrix.CreateTranslation(-18.1052933f, 16.5422916f, -10.80101f);
      this.explodePart[68] = Matrix.CreateScale(21.7923126f, 16.4284439f, 34.52677f) * Matrix.CreateTranslation(40.2600937f, 36.11992f, 35.4087372f);
      this.explodePart[69] = Matrix.CreateScale(2.16503525f, 0.574066162f, 2.17190552f) * Matrix.CreateTranslation(38.183f, 31.4127f, 49.45735f);
      this.explodePart[70] = Matrix.CreateScale(21.9795456f, 24.3106117f, 41.41684f) * Matrix.CreateTranslation(35.1985359f, 21.2314568f, 29.0091858f);
      this.explodePart[71] = Matrix.CreateScale(12.8490829f, 11.8690434f, 26.5528641f) * Matrix.CreateTranslation(39.9800568f, 31.0200386f, 49.40527f);
      this.explodePart[72] = Matrix.CreateScale(13.7948914f, 18.5056686f, 34.09932f) * Matrix.CreateTranslation(34.670208f, 18.5674229f, 45.0485725f);
      this.explodePart[73] = Matrix.CreateScale(28.8376923f, 22.5473671f, 53.9349823f) * Matrix.CreateTranslation(39.2548828f, 37.099926f, 16.4781532f);
      this.explodePart[74] = Matrix.CreateScale(29.047905f, 31.93254f, 70.12552f) * Matrix.CreateTranslation(38.241497f, 17.06254f, 1.43232727f);
      this.explodePart[75] = Matrix.CreateScale(37.3182831f, 26.6465f, 55.5844727f) * Matrix.CreateTranslation(34.8539467f, 38.7868f, 6.08684635f);
      this.explodePart[76] = Matrix.CreateScale(31.8704987f, 35.9521179f, 64.01532f) * Matrix.CreateTranslation(35.1561623f, 18.83377f, -9.923008f);
      this.explodePart[77] = Matrix.CreateScale(3.39435959f, 1.31049347f, 3.00019836f) * Matrix.CreateTranslation(35.5943069f, 33.30713f, 20.70087f);
      this.explodePart[78] = Matrix.CreateScale(2.28316116f, 1.24946976f, 1.75086975f) * Matrix.CreateTranslation(33.336647f, 39.71297f, 37.1850281f);
      this.explodePart[79] = Matrix.CreateScale(2.4970932f, 1.43185425f, 0.7927513f) * Matrix.CreateTranslation(33.5271454f, 39.1270332f, 37.5406342f);
      this.explodePart[80] = Matrix.CreateScale(19.76847f, 22.1541824f, 51.6752777f) * Matrix.CreateTranslation(27.993782f, 56.9497261f, -71.59706f);
      this.explodePart[81] = Matrix.CreateScale(20.3502426f, 33.9149628f, 62.45746f) * Matrix.CreateTranslation(30.1669159f, 34.7374f, -76.8075256f);
      this.explodePart[82] = Matrix.CreateScale(19.619957f, 23.6631165f, 45.3392334f) * Matrix.CreateTranslation(31.799118f, 49.812088f, -66.02525f);
      this.explodePart[83] = Matrix.CreateScale(20.6167679f, 38.3967361f, 60.2436829f) * Matrix.CreateTranslation(33.9882965f, 25.1333542f, -72.31908f);
      this.explodePart[84] = Matrix.CreateScale(39.316803f, 22.9502354f, 49.5209045f) * Matrix.CreateTranslation(-18.3812084f, 43.0540161f, -62.88692f);
      this.explodePart[85] = Matrix.CreateScale(37.9767f, 30.3631973f, 61.9349976f) * Matrix.CreateTranslation(-22.3778858f, 26.9120979f, -68.8922958f);
      this.explodePart[86] = Matrix.CreateScale(1.43629074f, 0.815485f, 2.63928223f) * Matrix.CreateTranslation(-36.23982f, 10.0433493f, -78.6697845f);
      this.explodePart[87] = Matrix.CreateScale(2.7681427f, 1.3553772f, 4.13863373f) * Matrix.CreateTranslation(-36.80842f, 9.36445f, -78.71055f);
      this.explodePart[88] = Matrix.CreateScale(33.7002373f, 17.6817169f, 43.6951447f) * Matrix.CreateTranslation(-30.5040321f, 41.629528f, 51.7120819f);
      this.explodePart[89] = Matrix.CreateScale(38.97284f, 16.9244652f, 32.88659f) * Matrix.CreateTranslation(-11.8817005f, 29.3670712f, 64.06844f);
      this.explodePart[90] = Matrix.CreateScale(15.2653809f, 16.1364555f, 12.99361f) * Matrix.CreateTranslation(-43.2333336f, 29.1355686f, 63.6934242f);
      this.explodePart[91] = Matrix.CreateScale(10.6638451f, 22.2144737f, 11.5874939f) * Matrix.CreateTranslation(-47.6410675f, 12.582777f, 58.8817062f);
      this.explodePart[92] = Matrix.CreateScale(44.5580444f, 24.72963f, 71.3735657f) * Matrix.CreateTranslation(-11.27385f, 18.15395f, 4.224779f);
      this.explodePart[93] = Matrix.CreateScale(46.9076843f, 33.9648666f, 84.84607f) * Matrix.CreateTranslation(-6.439537f, 2.11944866f, 0.727767944f);
      this.explodePart[94] = Matrix.CreateScale(7.6967926f, 9.989346f, 9.529007f) * Matrix.CreateTranslation(-0.5703161f, 45.3139267f, 30.14122f);
      this.explodePart[95] = Matrix.CreateScale(28.5241089f, 21.7954636f, 39.56392f) * Matrix.CreateTranslation(-7.09975863f, 31.01323f, 17.2173576f);
      this.explodePart[96] = Matrix.CreateScale(0.100842476f, 0.131212234f, 0.0503664f) * Matrix.CreateTranslation(4.371228f, 27.6498241f, -14.3554106f);
      this.explodePart[97] = Matrix.CreateScale(0.230323792f, 0.201673508f, 0.09950924f) * Matrix.CreateTranslation(4.350857f, 27.51936f, -14.3592377f);
      this.explodePart[98] = Matrix.CreateScale(45.705f, 23.2005959f, 45.2009277f) * Matrix.CreateTranslation(-24.8033524f, 47.28013f, -5.09341145f);
      this.explodePart[99] = Matrix.CreateScale(45.7579041f, 26.533493f, 70.69827f) * Matrix.CreateTranslation(-23.3904362f, 38.3879242f, -5.11177635f);
      this.explodePart[100] = Matrix.CreateScale(41.5874176f, 26.8710289f, 82.33168f) * Matrix.CreateTranslation(-23.7912426f, 26.8710861f, -9.617586f);
      this.explodePart[101] = Matrix.CreateScale(38.0875549f, 31.390274f, 72.2792358f) * Matrix.CreateTranslation(-20.9877739f, 10.4635839f, -23.3085327f);
      this.explodePart[102] = Matrix.CreateScale(24.1288834f, 21.19019f, 54.5145721f) * Matrix.CreateTranslation(19.9892f, 69.1618958f, -93.04912f);
      this.explodePart[103] = Matrix.CreateScale(20.9859238f, 30.6050873f, 49.5060577f) * Matrix.CreateTranslation(23.6068821f, 51.185276f, -87.96055f);
      this.explodePart[104] = Matrix.CreateScale(18.3195267f, 19.6714935f, 45.5862732f) * Matrix.CreateTranslation(25.523468f, 62.1968f, -77.1501541f);
      this.explodePart[105] = Matrix.CreateScale(18.5366287f, 29.3665848f, 50.45575f) * Matrix.CreateTranslation(27.0929775f, 43.77159f, -85.28785f);
      this.explodePart[106] = Matrix.CreateScale(17.6482315f, 20.7278347f, 37.7838058f) * Matrix.CreateTranslation(36.08632f, 38.0568581f, -59.8853264f);
      this.explodePart[107] = Matrix.CreateScale(19.0933838f, 33.8624344f, 53.80287f) * Matrix.CreateTranslation(37.31041f, 15.800602f, -67.43016f);
      this.explodePart[108] = Matrix.CreateScale(18.1195f, 19.89926f, 34.7316055f) * Matrix.CreateTranslation(39.01675f, 30.7725353f, -56.1278877f);
      this.explodePart[109] = Matrix.CreateScale(20.47631f, 30.6600342f, 53.2099457f) * Matrix.CreateTranslation(40.6205368f, 11.7818584f, -63.2143478f);
      this.explodePart[110] = Matrix.CreateScale(23.2578659f, 14.2745667f, 28.4950676f) * Matrix.CreateTranslation(-30.4667988f, 40.7994041f, -54.05661f);
      this.explodePart[111] = Matrix.CreateScale(20.4860458f, 17.9341469f, 28.7432022f) * Matrix.CreateTranslation(-32.0495644f, 30.6904469f, -53.6598549f);
      this.explodePart[112] = Matrix.CreateScale(2.97157288f, 1.65757179f, 1.85355377f) * Matrix.CreateTranslation(-41.9155235f, 10.5625372f, -77.46623f);
      this.explodePart[113] = Matrix.CreateScale(3.423195f, 1.76472187f, 1.95228577f) * Matrix.CreateTranslation(-41.58939f, 9.913489f, -77.2366f);
      this.explodePart[114] = Matrix.CreateScale(31.7808838f, 19.328167f, 33.57852f) * Matrix.CreateTranslation(-7.498803f, 21.0214634f, 67.5123749f);
      this.explodePart[115] = Matrix.CreateScale(38.1394348f, 19.170517f, 40.84024f) * Matrix.CreateTranslation(-4.13096142f, 12.9227314f, 68.8412552f);
      this.explodePart[116] = Matrix.CreateScale(34.2757645f, 23.3549957f, 42.60518f) * Matrix.CreateTranslation(-29.8811417f, 34.91813f, 51.4102249f);
      this.explodePart[117] = Matrix.CreateScale(33.6230469f, 30.66101f, 39.6873169f) * Matrix.CreateTranslation(-23.7236271f, 18.1671829f, 54.18229f);
      this.explodePart[118] = Matrix.CreateScale(2.40023422f, 1.15826607f, 2.42973328f) * Matrix.CreateTranslation(-15.6293592f, 30.6438618f, 73.71498f);
      this.explodePart[119] = Matrix.CreateScale(2.93688679f, 0.9970646f, 3.242424f) * Matrix.CreateTranslation(-15.5234051f, 30.3766861f, 74.08604f);
      this.explodePart[120] = Matrix.CreateScale(29.58239f, 14.5123482f, 26.3638687f) * Matrix.CreateTranslation(-27.8660316f, 44.3657646f, -68.80113f);
      this.explodePart[121] = Matrix.CreateScale(19.0583916f, 21.7441864f, 19.1761017f) * Matrix.CreateTranslation(-24.78543f, 32.6768074f, -68.129364f);
      this.explodePart[122] = Matrix.CreateScale(6.21643829f, 10.5399666f, 5.50731659f) * Matrix.CreateTranslation(-40.3018379f, 28.1391945f, -83.23457f);
      this.explodePart[123] = Matrix.CreateScale(8.946846f, 15.99828f, 10.6760254f) * Matrix.CreateTranslation(-40.008007f, 16.9445152f, -81.6502151f);
      this.explodePart[124] = Matrix.CreateScale(6.421974f, 7.0790863f, 5.77170563f) * Matrix.CreateTranslation(-39.8197441f, 26.2047882f, -84.7570953f);
      this.explodePart[125] = Matrix.CreateScale(6.469208f, 10.7965775f, 5.86374664f) * Matrix.CreateTranslation(-39.8822937f, 19.67662f, -84.7700958f);
      this.explodePart[126] = Matrix.CreateScale(26.5667267f, 19.2143631f, 46.1826477f) * Matrix.CreateTranslation(-14.9929724f, 47.8912544f, -86.97806f);
      this.explodePart[(int) sbyte.MaxValue] = Matrix.CreateScale(25.005722f, 25.0918121f, 42.25612f) * Matrix.CreateTranslation(-17.8462582f, 33.91532f, -87.39686f);
      this.explodePart[128] = Matrix.CreateScale(27.5605621f, 12.5740242f, 30.2937164f) * Matrix.CreateTranslation(-19.5261765f, 57.1399727f, -94.71356f);
      this.explodePart[129] = Matrix.CreateScale(22.8588562f, 13.7384491f, 47.53586f) * Matrix.CreateTranslation(-16.1874638f, 51.7570953f, -86.35681f);
      this.explodePart[130] = Matrix.CreateScale(26.7060623f, 18.025383f, 40.900116f) * Matrix.CreateTranslation(-30.56873f, 47.6332855f, -87.11176f);
      this.explodePart[131] = Matrix.CreateScale(27.9014969f, 23.9775543f, 41.54036f) * Matrix.CreateTranslation(-29.06662f, 35.898243f, -86.6576462f);
      this.explodePart[132] = Matrix.CreateScale(17.6640587f, 15.3649874f, 21.1505127f) * Matrix.CreateTranslation(-5.8724556f, 11.7808208f, 116.307526f);
      this.explodePart[133] = Matrix.CreateScale(38.83422f, 22.5255814f, 51.65512f) * Matrix.CreateTranslation(-28.2905655f, 52.8759956f, -18.3642883f);
      this.explodePart[134] = Matrix.CreateScale(45.399704f, 21.26149f, 44.79889f) * Matrix.CreateTranslation(-24.0159245f, 45.19824f, -19.4098988f);
      this.explodePart[135] = Matrix.CreateScale(49.6664429f, 22.9556274f, 38.2384644f) * Matrix.CreateTranslation(-19.2793179f, 37.979084f, -21.4360428f);
      this.explodePart[136] = Matrix.CreateScale(55.22206f, 21.8528214f, 33.83525f) * Matrix.CreateTranslation(-10.8283749f, 31.4076672f, -21.7110519f);
      this.explodePart[137] = Matrix.CreateScale(7.72804451f, 4.23419952f, 11.2688866f) * Matrix.CreateTranslation(21.3355484f, -4.921878f, -56.2412071f);
      this.explodePart[138] = Matrix.CreateScale(8.126251f, 4.41032028f, 14.8531494f) * Matrix.CreateTranslation(21.9203968f, -6.21652746f, -57.9412842f);
      this.explodePart[139] = Matrix.CreateScale(8.596619f, 5.097332f, 17.0483131f) * Matrix.CreateTranslation(22.65899f, -8.068317f, -59.038868f);
      this.explodePart[140] = Matrix.CreateScale(8.751112f, 5.33847237f, 17.602478f) * Matrix.CreateTranslation(23.2470779f, -9.96559f, -59.5301743f);
      this.explodePart[141] = Matrix.CreateScale(17.7325172f, 15.4876022f, 42.9429855f) * Matrix.CreateTranslation(-0.49205637f, 76.0922f, 45.215126f);
      this.explodePart[142] = Matrix.CreateScale(18.3487244f, 19.8565369f, 75.0374146f) * Matrix.CreateTranslation(3.15614939f, 65.8434448f, 40.9911041f);
      this.explodePart[143] = Matrix.CreateScale(20.3877182f, 21.4870453f, 89.95314f) * Matrix.CreateTranslation(6.618634f, 54.0098152f, 40.1334953f);
      this.explodePart[144] = Matrix.CreateScale(18.078186f, 33.6147f, 119.358551f) * Matrix.CreateTranslation(8.895262f, 37.5266151f, 27.0926876f);
      this.explodePart[145] = Matrix.CreateScale(16.796936f, 13.6263962f, 30.6300964f) * Matrix.CreateTranslation(38.4120941f, 68.8596649f, 33.59689f);
      this.explodePart[146] = Matrix.CreateScale(23.8457031f, 13.673912f, 44.0822754f) * Matrix.CreateTranslation(37.9676476f, 63.1320572f, 31.72934f);
      this.explodePart[147] = Matrix.CreateScale(28.9913635f, 17.5076561f, 53.97577f) * Matrix.CreateTranslation(37.872345f, 56.9620056f, 31.8189011f);
      this.explodePart[148] = Matrix.CreateScale(24.3113976f, 18.4508133f, 46.2654343f) * Matrix.CreateTranslation(39.4797478f, 50.6376648f, 40.66784f);
      this.explodePart[149] = Matrix.CreateScale(1.2020874f, 0.7558899f, 2.82455444f) * Matrix.CreateTranslation(26.45124f, 48.87663f, 14.3901482f);
      this.explodePart[150] = Matrix.CreateScale(0.8041611f, 0.5078888f, 0.7917175f) * Matrix.CreateTranslation(23.6282482f, 50.3465576f, 4.95288849f);
      this.explodePart[151] = Matrix.CreateScale(26.532547f, 13.2281189f, 29.6400757f) * Matrix.CreateTranslation(40.0280952f, 55.1189728f, 21.5256233f);
      this.explodePart[152] = Matrix.CreateScale(26.4509048f, 13.9334068f, 40.3142548f) * Matrix.CreateTranslation(39.9965439f, 51.59658f, 26.996542f);
      this.explodePart[153] = Matrix.CreateScale(22.7717285f, 13.0061321f, 46.8504028f) * Matrix.CreateTranslation(41.0865173f, 45.8022346f, 34.7190132f);
      this.explodePart[154] = Matrix.CreateScale(18.97654f, 15.9103355f, 45.0751877f) * Matrix.CreateTranslation(42.1090355f, 39.3630676f, 42.1466141f);
      this.explodePart[155] = Matrix.CreateScale(27.2036972f, 20.0533562f, 57.0071564f) * Matrix.CreateTranslation(22.0065842f, 57.0008774f, 30.0798683f);
      this.explodePart[156] = Matrix.CreateScale(26.2267227f, 20.1033936f, 77.94928f) * Matrix.CreateTranslation(25.68183f, 49.2500954f, 33.6646957f);
      this.explodePart[157] = Matrix.CreateScale(26.37326f, 21.7622643f, 99.3378f) * Matrix.CreateTranslation(28.4004631f, 38.32013f, 42.6281929f);
      this.explodePart[158] = Matrix.CreateScale(22.3193436f, 27.86692f, 103.434967f) * Matrix.CreateTranslation(29.7070713f, 23.9688282f, 52.7985878f);
      this.explodePart[159] = Matrix.CreateScale(16.4133263f, 6.882597f, 13.29364f) * Matrix.CreateTranslation(29.5435753f, 45.3499336f, 111.467644f);
      this.explodePart[160] = Matrix.CreateScale(16.8652878f, 6.652622f, 14.03598f) * Matrix.CreateTranslation(30.7244015f, 44.3122749f, 111.480812f);
      this.explodePart[161] = Matrix.CreateScale(16.3983231f, 6.839443f, 14.2990875f) * Matrix.CreateTranslation(30.8857288f, 43.1740646f, 111.385307f);
      this.explodePart[162] = Matrix.CreateScale(15.3027306f, 7.73844528f, 12.8626137f) * Matrix.CreateTranslation(31.4388161f, 41.54636f, 112.1036f);
      this.explodePart[163] = Matrix.CreateScale(13.3741074f, 7.956669f, 8.541534f) * Matrix.CreateTranslation(19.98711f, 61.609127f, 75.7359848f);
      this.explodePart[164] = Matrix.CreateScale(15.5501633f, 7.57181168f, 12.5512619f) * Matrix.CreateTranslation(22.9794731f, 58.1905327f, 77.66637f);
      this.explodePart[165] = Matrix.CreateScale(16.701664f, 8.761715f, 15.6258163f) * Matrix.CreateTranslation(24.67745f, 54.4718628f, 79.31373f);
      this.explodePart[166] = Matrix.CreateScale(15.7676353f, 10.8921814f, 19.15535f) * Matrix.CreateTranslation(25.6757f, 49.662426f, 82.55539f);
      this.explodePart[167] = Matrix.CreateScale(30.5431366f, 13.3894577f, 9095f / 256f) * Matrix.CreateTranslation(25.9121971f, 68.19394f, 56.6474152f);
      this.explodePart[168] = Matrix.CreateScale(29.2040482f, 13.2920151f, 34.0642f) * Matrix.CreateTranslation(27.2773533f, 65.77502f, 58.583f);
      this.explodePart[169] = Matrix.CreateScale(28.675354f, 14.0015526f, 31.5326614f) * Matrix.CreateTranslation(28.0583973f, 60.9236259f, 61.4249954f);
      this.explodePart[170] = Matrix.CreateScale(27.2481689f, 15.6033783f, 30.3562164f) * Matrix.CreateTranslation(29.2277527f, 56.2848129f, 64.6238f);
      this.explodePart[171] = Matrix.CreateScale(24.7338181f, 11.7464828f, 38.40564f) * Matrix.CreateTranslation(18.01219f, 75.7313156f, 46.3738823f);
      this.explodePart[172] = Matrix.CreateScale(25.351326f, 9.682056f, 40.6983643f) * Matrix.CreateTranslation(20.5420589f, 73.9257f, 46.95279f);
      this.explodePart[173] = Matrix.CreateScale(29.4558029f, 10.6743927f, 39.6487732f) * Matrix.CreateTranslation(23.7341671f, 72.2710342f, 51.1119652f);
      this.explodePart[174] = Matrix.CreateScale(29.6939163f, 9.300003f, 36.35971f) * Matrix.CreateTranslation(25.48057f, 71.14641f, 53.9619f);
      this.explodePart[175] = Matrix.CreateScale(31.8777771f, 12.2824364f, 40.7221375f) * Matrix.CreateTranslation(23.3140259f, 68.6196f, 39.2558746f);
      this.explodePart[176] = Matrix.CreateScale(29.334198f, 13.3327026f, 40.646286f) * Matrix.CreateTranslation(24.93291f, 66.27664f, 41.7317619f);
      this.explodePart[177] = Matrix.CreateScale(28.129364f, 12.913578f, 38.0032349f) * Matrix.CreateTranslation(26.196228f, 62.6504326f, 45.6793442f);
      this.explodePart[178] = Matrix.CreateScale(27.405365f, 14.56274f, 35.19861f) * Matrix.CreateTranslation(27.4020538f, 58.2446175f, 52.1572533f);
      this.explodePart[179] = Matrix.CreateScale(24.6087036f, 20.153511f, 38.3083649f) * Matrix.CreateTranslation(18.7464142f, 83.06308f, -36.1855354f);
      this.explodePart[180] = Matrix.CreateScale(24.9135666f, 25.3553925f, 43.3033142f) * Matrix.CreateTranslation(25.0366821f, 69.2202759f, -29.7664013f);
      this.explodePart[181] = Matrix.CreateScale(25.3261414f, 26.8349419f, 48.0741119f) * Matrix.CreateTranslation(31.3798065f, 50.6861f, -23.4622135f);
      this.explodePart[182] = Matrix.CreateScale(26.961853f, 36.1292343f, 42.38472f) * Matrix.CreateTranslation(38.1731262f, 28.6982861f, -21.9097748f);
      this.explodePart[183] = Matrix.CreateScale(22.320343f, 15.1391029f, 47.7946167f) * Matrix.CreateTranslation(16.3276672f, 84.65627f, -75.4420853f);
      this.explodePart[184] = Matrix.CreateScale(22.3694458f, 15.7072754f, 51.3842163f) * Matrix.CreateTranslation(18.6363773f, 79.50743f, -75.75903f);
      this.explodePart[185] = Matrix.CreateScale(21.86863f, 15.4810257f, 40.85614f) * Matrix.CreateTranslation(21.44018f, 72.8196945f, -68.8776855f);
      this.explodePart[186] = Matrix.CreateScale(23.4079285f, 19.0727539f, 31.71936f) * Matrix.CreateTranslation(24.7727985f, 63.71541f, -61.7109337f);
      this.explodePart[187] = Matrix.CreateScale(12.43129f, 9.600494f, 14.0327187f) * Matrix.CreateTranslation(32.3223953f, 84.9490356f, -53.67837f);
      this.explodePart[188] = Matrix.CreateScale(14.5814819f, 10.5791321f, 20.6931458f) * Matrix.CreateTranslation(36.7197952f, 78.46515f, -50.35573f);
      this.explodePart[189] = Matrix.CreateScale(16.352829f, 12.117363f, 23.881443f) * Matrix.CreateTranslation(40.0940933f, 71.48632f, -47.22887f);
      this.explodePart[190] = Matrix.CreateScale(17.7413979f, 15.3151093f, 26.9282532f) * Matrix.CreateTranslation(43.86021f, 63.06702f, -43.834362f);
      this.explodePart[191] = Matrix.CreateScale(17.01392f, 9.551792f, 34.38224f) * Matrix.CreateTranslation(39.01611f, 68.98143f, -68.95471f);
      this.explodePart[192] = Matrix.CreateScale(16.4206581f, 10.467411f, 33.8974762f) * Matrix.CreateTranslation(41.08218f, 65.50758f, -67.25849f);
      this.explodePart[193] = Matrix.CreateScale(16.3080826f, 11.028141f, 32.7050552f) * Matrix.CreateTranslation(43.0477448f, 60.3603f, -64.71068f);
      this.explodePart[194] = Matrix.CreateScale(18.0765381f, 12.2995033f, 29.978157f) * Matrix.CreateTranslation(45.82735f, 54.8033371f, -63.04539f);
      this.explodePart[195] = Matrix.CreateScale(7.742874f, 9.1087f, 27.45758f) * Matrix.CreateTranslation(29.9632034f, 84.95617f, -72.01425f);
      this.explodePart[196] = Matrix.CreateScale(11.3649635f, 8.566036f, 34.850647f) * Matrix.CreateTranslation(32.66638f, 81.3652954f, -74.3969f);
      this.explodePart[197] = Matrix.CreateScale(14.2987213f, 10.4345512f, 41.9302368f) * Matrix.CreateTranslation(35.0379f, 77.13804f, -75.64045f);
      this.explodePart[198] = Matrix.CreateScale(17.8922577f, 9.501492f, 44.1286f) * Matrix.CreateTranslation(37.6214676f, 74.01816f, -75.2116852f);
      this.explodePart[199] = Matrix.CreateScale(16.9508057f, 11.778801f, 28.9880142f) * Matrix.CreateTranslation(37.3512421f, 67.72262f, -89.938324f);
      this.explodePart[200] = Matrix.CreateScale(17.7756042f, 12.2869568f, 34.3668747f) * Matrix.CreateTranslation(40.64209f, 61.558136f, -88.02314f);
      this.explodePart[201] = Matrix.CreateScale(18.57172f, 15.1267967f, 42.68152f) * Matrix.CreateTranslation(43.6677666f, 53.9607468f, -85.80877f);
      this.explodePart[202] = Matrix.CreateScale(18.8281784f, 17.5754318f, 41.70263f) * Matrix.CreateTranslation(45.7804642f, 45.82873f, -85.1540146f);
      this.explodePart[203] = Matrix.CreateScale(12.4942741f, 13.0299f, 52.12349f) * Matrix.CreateTranslation(39.7224f, 77.80955f, 14.3757906f);
      this.explodePart[204] = Matrix.CreateScale(14.7355576f, 13.759758f, 65.85361f) * Matrix.CreateTranslation(43.01034f, 71.64808f, 7.872326f);
      this.explodePart[205] = Matrix.CreateScale(16.2443047f, 15.9571342f, 82.6863861f) * Matrix.CreateTranslation(44.88639f, 63.3528671f, -6.726181f);
      this.explodePart[206] = Matrix.CreateScale(15.854847f, 20.9458313f, 65.11706f) * Matrix.CreateTranslation(46.14355f, 52.8698158f, -44.5972443f);
      this.explodePart[207] = Matrix.CreateScale(7.573597f, 6.17913437f, 17.5561676f) * Matrix.CreateTranslation(43.47756f, 60.4482079f, 1.73781347f);
      this.explodePart[208] = Matrix.CreateScale(14.9325218f, 11.3613052f, 66.3983154f) * Matrix.CreateTranslation(36.9505f, 79.94822f, -18.3107357f);
      this.explodePart[209] = Matrix.CreateScale(14.7690392f, 10.57782f, 63.1564331f) * Matrix.CreateTranslation(34.1586876f, 84.6526f, -25.4470234f);
      this.explodePart[210] = Matrix.CreateScale(1.87646294f, 1.47547913f, 5.69796753f) * Matrix.CreateTranslation(33.84909f, 84.123f, 13.6842747f);
      this.explodePart[211] = Matrix.CreateScale(15.2451973f, 12.7906265f, 51.3098145f) * Matrix.CreateTranslation(39.77407f, 74.24559f, -20.8484268f);
      this.explodePart[212] = Matrix.CreateScale(16.1185f, 13.6088867f, 34.80075f) * Matrix.CreateTranslation(42.1274567f, 68.39919f, -25.5051727f);
      this.explodePart[213] = Matrix.CreateScale(12.2697372f, 13.0057678f, 45.78473f) * Matrix.CreateTranslation(46.7951965f, 62.5547676f, 11.8672686f);
      this.explodePart[214] = Matrix.CreateScale(205f / 16f, 15.5860405f, 50.4308777f) * Matrix.CreateTranslation(47.04791f, 55.54995f, 3.44603157f);
      this.explodePart[215] = Matrix.CreateScale(13.7662468f, 15.400444f, 45.36403f) * Matrix.CreateTranslation(49.5959129f, 44.3420029f, -9.175696f);
      this.explodePart[216] = Matrix.CreateScale(10.7607765f, 23.1552124f, 49.2191f) * Matrix.CreateTranslation(50.9434624f, 30.2497272f, -22.6975861f);
      this.explodePart[217] = Matrix.CreateScale(10.3190441f, 13.9531288f, 30.9442825f) * Matrix.CreateTranslation(17.0953426f, 78.6333847f, -5.764005f);
      this.explodePart[218] = Matrix.CreateScale(16.2158089f, 15.0659866f, 35.460556f) * Matrix.CreateTranslation(23.7442226f, 69.73243f, -1.14709f);
      this.explodePart[219] = Matrix.CreateScale(21.4226913f, 16.3327026f, 36.2049866f) * Matrix.CreateTranslation(30.1892757f, 59.4802551f, 2.38697624f);
      this.explodePart[220] = Matrix.CreateScale(24.2591286f, 21.5742874f, 29.8954163f) * Matrix.CreateTranslation(35.6708641f, 47.1998329f, 1.77355957f);
      this.explodePart[221] = Matrix.CreateScale(22.7072067f, 15.1654015f, 77.41116f) * Matrix.CreateTranslation(19.84553f, 85.92539f, 3.24015617f);
      this.explodePart[222] = Matrix.CreateScale(20.559906f, 15.4300461f, 79.448f) * Matrix.CreateTranslation(25.5477f, 80.55085f, 7.163082f);
      this.explodePart[223] = Matrix.CreateScale(17.8968582f, 14.7262039f, 72.80011f) * Matrix.CreateTranslation(29.87858f, 73.330986f, 9.01767f);
      this.explodePart[224] = Matrix.CreateScale(15.1303139f, 21.75592f, 58.0606537f) * Matrix.CreateTranslation(35.1779556f, 61.32845f, 6.213442f);
      this.explodePart[225] = Matrix.CreateScale(9.317448f, 10.3883286f, 44.1647644f) * Matrix.CreateTranslation(17.2794514f, 83.87123f, 24.8179474f);
      this.explodePart[226] = Matrix.CreateScale(12.60273f, 11.61142f, 44.9111481f) * Matrix.CreateTranslation(20.8008537f, 78.21008f, 26.275013f);
      this.explodePart[227] = Matrix.CreateScale(14.85955f, 12.84087f, 36.144104f) * Matrix.CreateTranslation(24.5952663f, 71.22392f, 23.7516479f);
      this.explodePart[228] = Matrix.CreateScale(18.4909973f, 12.9163933f, 20.715271f) * Matrix.CreateTranslation(28.8345337f, 63.7258034f, 17.567667f);
      this.explodePart[229] = Matrix.CreateScale(14.2975464f, 10.7392883f, 34.46691f) * Matrix.CreateTranslation(47.7618141f, 55.46646f, -14.542532f);
      this.explodePart[230] = Matrix.CreateScale(12.5010872f, 9.310886f, 23.9573936f) * Matrix.CreateTranslation(47.1440163f, 60.1732445f, -4.32091665f);
      this.explodePart[231] = Matrix.CreateScale(1.34025574f, 1.09700775f, 3.64852142f) * Matrix.CreateTranslation(52.63345f, 59.6453247f, -19.45566f);
      this.explodePart[232] = Matrix.CreateScale(0.6336365f, 0.475177765f, 0.6898041f) * Matrix.CreateTranslation(43.2851028f, 54.88142f, -22.40847f);
      this.explodePart[233] = Matrix.CreateScale(14.9642563f, 11.024662f, 26.0441818f) * Matrix.CreateTranslation(49.10553f, 49.94267f, -17.6106f);
      this.explodePart[234] = Matrix.CreateScale(13.880291f, 14.4815216f, 21.2514267f) * Matrix.CreateTranslation(50.87748f, 42.3252f, -18.0229511f);
      this.explodePart[235] = Matrix.CreateScale(13.9896355f, 9.112564f, 38.1278763f) * Matrix.CreateTranslation(48.0644379f, 42.7996674f, -51.6010857f);
      this.explodePart[236] = Matrix.CreateScale(13.1122475f, 9.581547f, 43.44069f) * Matrix.CreateTranslation(49.67265f, 39.8028069f, -44.9492569f);
      this.explodePart[237] = Matrix.CreateScale(11.52277f, 10.4775658f, 38.361908f) * Matrix.CreateTranslation(50.44282f, 34.933403f, -41.77121f);
      this.explodePart[238] = Matrix.CreateScale(9.278172f, 14.9362144f, 34.6504974f) * Matrix.CreateTranslation(51.05473f, 27.8323784f, -39.88987f);
      this.explodePart[239] = Matrix.CreateScale(13.4374352f, 7.81518936f, 31.4893036f) * Matrix.CreateTranslation(47.2850533f, 50.9167557f, -41.1992836f);
      this.explodePart[240] = Matrix.CreateScale(0.546402f, 0.167453766f, 0.9639435f) * Matrix.CreateTranslation(51.5306168f, 52.99216f, -47.86547f);
      this.explodePart[241] = Matrix.CreateScale(12.5388756f, 7.950783f, 17.96243f) * Matrix.CreateTranslation(46.8352165f, 52.83833f, -34.9109459f);
      this.explodePart[242] = Matrix.CreateScale(0.812927246f, 0.5229912f, 0.971801758f) * Matrix.CreateTranslation(42.7952728f, 48.8004456f, -48.8122368f);
      this.explodePart[243] = Matrix.CreateScale(14.6373138f, 11.247715f, 37.3317261f) * Matrix.CreateTranslation(47.7406f, 42.2726746f, -78.37468f);
      this.explodePart[244] = Matrix.CreateScale(14.5512238f, 11.0041809f, 45.00654f) * Matrix.CreateTranslation(47.68757f, 38.7668648f, -78.23061f);
      this.explodePart[245] = Matrix.CreateScale(13.0395241f, 11.2842712f, 45.02868f) * Matrix.CreateTranslation(48.3209f, 33.33625f, -74.26215f);
      this.explodePart[246] = Matrix.CreateScale(10.5057373f, 15.1098938f, 44.14154f) * Matrix.CreateTranslation(49.4791527f, 25.7630386f, -66.11387f);
      this.explodePart[247] = Matrix.CreateScale(15.5014648f, 18.0767288f, 55.59584f) * Matrix.CreateTranslation(17.24342f, 47.2134933f, -18.728651f);
      this.explodePart[248] = Matrix.CreateScale(19.07344f, 23.9562073f, 111.906494f) * Matrix.CreateTranslation(18.8859863f, 36.0172462f, -53.7851753f);
      this.explodePart[249] = Matrix.CreateScale(21.8725967f, 23.6431561f, 97.74243f) * Matrix.CreateTranslation(20.7032967f, 22.3458023f, -7791f / 128f);
      this.explodePart[250] = Matrix.CreateScale(21.3578758f, 32.8601456f, 75.0892944f) * Matrix.CreateTranslation(24.4010277f, 4.362201f, -66.28195f);
      this.explodePart[251] = Matrix.CreateScale(39.3914642f, 21.1478958f, 21.2209568f) * Matrix.CreateTranslation(-26.055788f, 65.2784958f, 18.1813755f);
      this.explodePart[252] = Matrix.CreateScale(44.6576233f, 24.1561279f, 40.8132935f) * Matrix.CreateTranslation(-26.05249f, 57.9575081f, 10.0550766f);
      this.explodePart[253] = Matrix.CreateScale(46.666214f, 24.81445f, 42.42134f) * Matrix.CreateTranslation(-24.583334f, 49.98239f, 10.8176956f);
      this.explodePart[254] = Matrix.CreateScale(47.11537f, 29.04306f, 29.1212158f) * Matrix.CreateTranslation(-22.836813f, 40.6946526f, 19.14212f);
      this.explodePart[(int) byte.MaxValue] = Matrix.CreateScale(7.741117f, 17.1695862f, 29.3646774f) * Matrix.CreateTranslation(-5.892443f, 69.97655f, 50.8186646f);
      this.explodePart[256] = Matrix.CreateScale(13.02623f, 21.4629211f, 41.78871f) * Matrix.CreateTranslation(-1.96052575f, 3527f / 64f, 63.46292f);
      this.explodePart[257] = Matrix.CreateScale(18.8374977f, 24.1212254f, 57.3445435f) * Matrix.CreateTranslation(2.459224f, 37.1668f, 83.61486f);
      this.explodePart[258] = Matrix.CreateScale(26.28875f, 32.9216537f, 50.4528961f) * Matrix.CreateTranslation(7.60254145f, 17.14613f, 88.26848f);
      this.explodePart[259] = Matrix.CreateScale(21.7856522f, 12.76709f, 19.8228531f) * Matrix.CreateTranslation(-18.6751633f, 78.1567841f, 46.27141f);
      this.explodePart[260] = Matrix.CreateScale(23.6215515f, 13.5829315f, 28.6945114f) * Matrix.CreateTranslation(-17.0146542f, 73.26574f, 50.84252f);
      this.explodePart[261] = Matrix.CreateScale(26.1430359f, 14.5051193f, 31.8182678f) * Matrix.CreateTranslation(-15.8990822f, 67.04201f, 55.9826241f);
      this.explodePart[262] = Matrix.CreateScale(29.386322f, 15.8401756f, 36.7682648f) * Matrix.CreateTranslation(-13.3403816f, 60.84601f, 62.8799248f);
      this.explodePart[263] = Matrix.CreateScale(17.1857529f, 11.8979187f, 54.82617f) * Matrix.CreateTranslation(14.8161516f, 25.9783173f, 37.08486f);
      this.explodePart[264] = Matrix.CreateScale(16.0711327f, 11.34214f, 57.2019653f) * Matrix.CreateTranslation(17.5110512f, 22.6491642f, 41.5145569f);
      this.explodePart[265] = Matrix.CreateScale(14.64164f, 9.176123f, 51.1224823f) * Matrix.CreateTranslation(47.8439255f, 48.1778526f, -50.4570351f);
      this.explodePart[266] = Matrix.CreateScale(15.0920563f, 9.420319f, 52.49585f) * Matrix.CreateTranslation(48.74552f, 45.7879524f, -49.90796f);
      this.explodePart[267] = Matrix.CreateScale(16.3912659f, 13.7155132f, 54.7410126f) * Matrix.CreateTranslation(19.2778778f, 16.6186848f, 44.7582245f);
      this.explodePart[268] = Matrix.CreateScale(15.0419006f, 16.6673889f, 51.56897f) * Matrix.CreateTranslation(20.9582672f, 9.726122f, 47.05005f);
      this.explodePart[269] = Matrix.CreateScale(13.2184143f, 9.149948f, 25.82454f) * Matrix.CreateTranslation(12.1533527f, 40.25004f, 50.7354927f);
      this.explodePart[270] = Matrix.CreateScale(14.3089638f, 9.8034935f, 43.99594f) * Matrix.CreateTranslation(12.6596794f, 37.1393929f, 42.0807343f);
      this.explodePart[271] = Matrix.CreateScale(17.2439957f, 11.5307617f, 67.73486f) * Matrix.CreateTranslation(15.3467159f, 30.4183044f, 34.3815842f);
      this.explodePart[272] = Matrix.CreateScale(1.61276817f, 0.489341736f, 1.64398193f) * Matrix.CreateTranslation(17.0124989f, 33.1573524f, 2.413669f);
      this.explodePart[273] = Matrix.CreateScale(15.5487671f, 10.8210926f, 58.9225922f) * Matrix.CreateTranslation(13.2418957f, 33.9315872f, 36.0010262f);
      this.explodePart[274] = Matrix.CreateScale(14.8968658f, 13.7477608f, 52.40547f) * Matrix.CreateTranslation(12.805872f, 25.7786465f, -6.52240849f);
      this.explodePart[275] = Matrix.CreateScale(16.9656525f, 13.6676521f, 61.42038f) * Matrix.CreateTranslation(14.0886173f, 20.9465637f, -7.286235f);
      this.explodePart[276] = Matrix.CreateScale(17.9778824f, 15.1225052f, 71.9154358f) * Matrix.CreateTranslation(15.9401283f, 14.113246f, -6.632375f);
      this.explodePart[277] = Matrix.CreateScale(18.6211929f, 17.1617432f, 80.421814f) * Matrix.CreateTranslation(17.7096348f, 7.06802559f, -3.35475159f);
      this.explodePart[278] = Matrix.CreateScale(16.7254486f, 15.8545914f, 44.894165f) * Matrix.CreateTranslation(9.453372f, 67.27686f, -24.703104f);
      this.explodePart[279] = Matrix.CreateScale(18.4049454f, 16.1858177f, 75.79428f) * Matrix.CreateTranslation(11.7659731f, 60.872654f, -24.9282036f);
      this.explodePart[280] = Matrix.CreateScale(19.0218353f, 18.8684387f, 95.5869141f) * Matrix.CreateTranslation(13.2333755f, 52.8915825f, -34.8245049f);
      this.explodePart[281] = Matrix.CreateScale(17.5304413f, 27.630127f, 110.573853f) * Matrix.CreateTranslation(13.9410076f, 39.43802f, -55.7464638f);
      this.explodePart[282] = Matrix.CreateScale(17.8151169f, 13.4596329f, 36.33947f) * Matrix.CreateTranslation(0.233820915f, 84.86167f, -60.0324936f);
      this.explodePart[283] = Matrix.CreateScale(17.6779785f, 13.4469757f, 43.69464f) * Matrix.CreateTranslation(3.10785532f, 79.86958f, -50.9571228f);
      this.explodePart[284] = Matrix.CreateScale(18.1733246f, 15.5835342f, 50.95349f) * Matrix.CreateTranslation(5.6127243f, 72.813385f, -43.82808f);
      this.explodePart[285] = Matrix.CreateScale(17.5526466f, 18.4057465f, 43.58432f) * Matrix.CreateTranslation(8.074933f, 65.1538f, -41.68637f);
      this.explodePart[286] = Matrix.CreateScale(27.1202545f, 15.6020164f, 30.8329849f) * Matrix.CreateTranslation(-16.1887245f, 55.5183258f, 62.34473f);
      this.explodePart[287] = Matrix.CreateScale(31.22409f, 15.879818f, 30.1970215f) * Matrix.CreateTranslation(-14.26668f, 49.6826477f, 67.759285f);
      this.explodePart[288] = Matrix.CreateScale(27.0406265f, 22.5823975f, 32.4923248f) * Matrix.CreateTranslation(-8.965259f, 32.75258f, 80.14053f);
      this.explodePart[289] = Matrix.CreateScale(9.319027f, 3.43231964f, 6.278137f) * Matrix.CreateTranslation(-1.83895612f, 42.861496f, 93.22227f);
      this.explodePart[290] = Matrix.CreateScale(29.0023727f, 16.5878868f, 30.36441f) * Matrix.CreateTranslation(-12.2411766f, 43.2531471f, 74.0332642f);
      this.explodePart[291] = Matrix.CreateScale(22.10379f, 10.6019993f, 30.9484482f) * Matrix.CreateTranslation(-12.036561f, 17.72539f, 95.82309f);
      this.explodePart[292] = Matrix.CreateScale(21.42044f, 12.1611938f, 32.0494843f) * Matrix.CreateTranslation(-6.39344931f, 12.701849f, 98.35145f);
      this.explodePart[293] = Matrix.CreateScale(24.7842865f, 11.6879959f, 20.4261551f) * Matrix.CreateTranslation(-4.69348145f, 38.2279053f, 96.80124f);
      this.explodePart[294] = Matrix.CreateScale(23.9533615f, 12.7207336f, 29.85862f) * Matrix.CreateTranslation(-4.047507f, 34.657814f, 97.89841f);
      this.explodePart[295] = Matrix.CreateScale(21.54126f, 14.1473351f, 38.76631f) * Matrix.CreateTranslation(-2.837391f, 28.991436f, 99.14063f);
      this.explodePart[296] = Matrix.CreateScale(18.5433884f, 17.77774f, 41.3868942f) * Matrix.CreateTranslation(-1.41254258f, 21.8644047f, 99.5911942f);
      this.explodePart[297] = Matrix.CreateScale(9.404152f, 6.980793f, 13.711895f) * Matrix.CreateTranslation(-7.936737f, 23.2943916f, 117.647835f);
      this.explodePart[298] = Matrix.CreateScale(14.7682343f, 8.163692f, 18.60865f) * Matrix.CreateTranslation(-7.61920166f, 18.92338f, 117.247986f);
      this.explodePart[299] = Matrix.CreateScale(11.4793987f, 9.450093f, 8.831047f) * Matrix.CreateTranslation(-18.4909763f, 29.10902f, 94.9472961f);
      this.explodePart[300] = Matrix.CreateScale(16.3285828f, 10.6938438f, 17.06247f) * Matrix.CreateTranslation(-16.334795f, 23.5063515f, 88.361496f);
      this.explodePart[301] = Matrix.CreateScale(18.57172f, 15.1267967f, 42.68152f) * Matrix.CreateTranslation(43.6677666f, 53.9607468f, -85.80877f);
      this.explodePart[302] = Matrix.CreateScale(18.8281784f, 17.5754318f, 41.70263f) * Matrix.CreateTranslation(45.7804642f, 45.82873f, -85.1540146f);
      this.explodePart[303] = Matrix.CreateScale(12.4942741f, 13.0299f, 52.12349f) * Matrix.CreateTranslation(39.7224f, 77.80955f, 14.3757906f);
      this.explodePart[304] = Matrix.CreateScale(14.7355576f, 13.759758f, 65.85361f) * Matrix.CreateTranslation(43.01034f, 71.64808f, 7.872326f);
      this.explodePart[305] = Matrix.CreateScale(16.2443047f, 15.9571342f, 82.6863861f) * Matrix.CreateTranslation(44.88639f, 63.3528671f, -6.726181f);
      this.explodePart[306] = Matrix.CreateScale(15.854847f, 20.9458313f, 65.11706f) * Matrix.CreateTranslation(46.14355f, 52.8698158f, -44.5972443f);
      this.explodePart[307] = Matrix.CreateScale(7.573597f, 6.17913437f, 17.5561676f) * Matrix.CreateTranslation(43.47756f, 60.4482079f, 1.73781347f);
      this.explodePart[308] = Matrix.CreateScale(14.9325218f, 11.3613052f, 66.3983154f) * Matrix.CreateTranslation(36.9505f, 79.94822f, -18.3107357f);
      this.explodePart[309] = Matrix.CreateScale(14.7690392f, 10.57782f, 63.1564331f) * Matrix.CreateTranslation(34.1586876f, 84.6526f, -25.4470234f);
      this.explodePart[310] = Matrix.CreateScale(1.87646294f, 1.47547913f, 5.69796753f) * Matrix.CreateTranslation(33.84909f, 84.123f, 13.6842747f);
      this.explodePart[311] = Matrix.CreateScale(15.2451973f, 12.7906265f, 51.3098145f) * Matrix.CreateTranslation(39.77407f, 74.24559f, -20.8484268f);
      this.explodePart[312] = Matrix.CreateScale(16.1185f, 13.6088867f, 34.80075f) * Matrix.CreateTranslation(42.1274567f, 68.39919f, -25.5051727f);
      this.explodePart[313] = Matrix.CreateScale(12.2697372f, 13.0057678f, 45.78473f) * Matrix.CreateTranslation(46.7951965f, 62.5547676f, 11.8672686f);
      this.explodePart[314] = Matrix.CreateScale(205f / 16f, 15.5860405f, 50.4308777f) * Matrix.CreateTranslation(47.04791f, 55.54995f, 3.44603157f);
      this.explodePart[315] = Matrix.CreateScale(13.7662468f, 15.400444f, 45.36403f) * Matrix.CreateTranslation(49.5959129f, 44.3420029f, -9.175696f);
      this.explodePart[316] = Matrix.CreateScale(10.7607765f, 23.1552124f, 49.2191f) * Matrix.CreateTranslation(50.9434624f, 30.2497272f, -22.6975861f);
      this.explodePart[317] = Matrix.CreateScale(10.3190441f, 13.9531288f, 30.9442825f) * Matrix.CreateTranslation(17.0953426f, 78.6333847f, -5.764005f);
      this.explodePart[318] = Matrix.CreateScale(16.2158089f, 15.0659866f, 35.460556f) * Matrix.CreateTranslation(23.7442226f, 69.73243f, -1.14709f);
      this.explodePart[319] = Matrix.CreateScale(21.4226913f, 16.3327026f, 36.2049866f) * Matrix.CreateTranslation(30.1892757f, 59.4802551f, 2.38697624f);
      this.explodePart[320] = Matrix.CreateScale(24.2591286f, 21.5742874f, 29.8954163f) * Matrix.CreateTranslation(35.6708641f, 47.1998329f, 1.77355957f);
      this.explodePart[321] = Matrix.CreateScale(22.7072067f, 15.1654015f, 77.41116f) * Matrix.CreateTranslation(19.84553f, 85.92539f, 3.24015617f);
      this.explodePart[322] = Matrix.CreateScale(20.559906f, 15.4300461f, 79.448f) * Matrix.CreateTranslation(25.5477f, 80.55085f, 7.163082f);
      this.explodePart[323] = Matrix.CreateScale(17.8968582f, 14.7262039f, 72.80011f) * Matrix.CreateTranslation(29.87858f, 73.330986f, 9.01767f);
      this.explodePart[324] = Matrix.CreateScale(15.1303139f, 21.75592f, 58.0606537f) * Matrix.CreateTranslation(35.1779556f, 61.32845f, 6.213442f);
      this.explodePart[325] = Matrix.CreateScale(9.317448f, 10.3883286f, 44.1647644f) * Matrix.CreateTranslation(17.2794514f, 83.87123f, 24.8179474f);
      this.explodePart[326] = Matrix.CreateScale(12.60273f, 11.61142f, 44.9111481f) * Matrix.CreateTranslation(20.8008537f, 78.21008f, 26.275013f);
      this.explodePart[327] = Matrix.CreateScale(14.85955f, 12.84087f, 36.144104f) * Matrix.CreateTranslation(24.5952663f, 71.22392f, 23.7516479f);
      this.explodePart[328] = Matrix.CreateScale(18.4909973f, 12.9163933f, 20.715271f) * Matrix.CreateTranslation(28.8345337f, 63.7258034f, 17.567667f);
      this.explodePart[329] = Matrix.CreateScale(14.2975464f, 10.7392883f, 34.46691f) * Matrix.CreateTranslation(47.7618141f, 55.46646f, -14.542532f);
      this.explodePart[330] = Matrix.CreateScale(12.5010872f, 9.310886f, 23.9573936f) * Matrix.CreateTranslation(47.1440163f, 60.1732445f, -4.32091665f);
      this.explodePart[331] = Matrix.CreateScale(1.34025574f, 1.09700775f, 3.64852142f) * Matrix.CreateTranslation(52.63345f, 59.6453247f, -19.45566f);
      this.explodePart[332] = Matrix.CreateScale(0.6336365f, 0.475177765f, 0.6898041f) * Matrix.CreateTranslation(43.2851028f, 54.88142f, -22.40847f);
      this.explodePart[333] = Matrix.CreateScale(14.9642563f, 11.024662f, 26.0441818f) * Matrix.CreateTranslation(49.10553f, 49.94267f, -17.6106f);
      this.explodePart[334] = Matrix.CreateScale(13.880291f, 14.4815216f, 21.2514267f) * Matrix.CreateTranslation(50.87748f, 42.3252f, -18.0229511f);
      this.explodePart[335] = Matrix.CreateScale(13.9896355f, 9.112564f, 38.1278763f) * Matrix.CreateTranslation(48.0644379f, 42.7996674f, -51.6010857f);
      this.explodePart[336] = Matrix.CreateScale(13.1122475f, 9.581547f, 43.44069f) * Matrix.CreateTranslation(49.67265f, 39.8028069f, -44.9492569f);
      this.explodePart[337] = Matrix.CreateScale(11.52277f, 10.4775658f, 38.361908f) * Matrix.CreateTranslation(50.44282f, 34.933403f, -41.77121f);
      this.explodePart[338] = Matrix.CreateScale(9.278172f, 14.9362144f, 34.6504974f) * Matrix.CreateTranslation(51.05473f, 27.8323784f, -39.88987f);
      this.explodePart[339] = Matrix.CreateScale(13.4374352f, 7.81518936f, 31.4893036f) * Matrix.CreateTranslation(47.2850533f, 50.9167557f, -41.1992836f);
      this.explodePart[340] = Matrix.CreateScale(0.546402f, 0.167453766f, 0.9639435f) * Matrix.CreateTranslation(51.5306168f, 52.99216f, -47.86547f);
      this.explodePart[341] = Matrix.CreateScale(12.5388756f, 7.950783f, 17.96243f) * Matrix.CreateTranslation(46.8352165f, 52.83833f, -34.9109459f);
      this.explodePart[342] = Matrix.CreateScale(0.812927246f, 0.5229912f, 0.971801758f) * Matrix.CreateTranslation(42.7952728f, 48.8004456f, -48.8122368f);
      this.explodePart[343] = Matrix.CreateScale(14.6373138f, 11.247715f, 37.3317261f) * Matrix.CreateTranslation(47.7406f, 42.2726746f, -78.37468f);
      this.explodePart[344] = Matrix.CreateScale(14.5512238f, 11.0041809f, 45.00654f) * Matrix.CreateTranslation(47.68757f, 38.7668648f, -78.23061f);
      this.explodePart[345] = Matrix.CreateScale(13.0395241f, 11.2842712f, 45.02868f) * Matrix.CreateTranslation(48.3209f, 33.33625f, -74.26215f);
      this.explodePart[346] = Matrix.CreateScale(10.5057373f, 15.1098938f, 44.14154f) * Matrix.CreateTranslation(49.4791527f, 25.7630386f, -66.11387f);
      this.explodePart[347] = Matrix.CreateScale(15.5014648f, 18.0767288f, 55.59584f) * Matrix.CreateTranslation(17.24342f, 47.2134933f, -18.728651f);
      this.explodePart[348] = Matrix.CreateScale(19.07344f, 23.9562073f, 111.906494f) * Matrix.CreateTranslation(18.8859863f, 36.0172462f, -53.7851753f);
      this.explodePart[349] = Matrix.CreateScale(21.8725967f, 23.6431561f, 97.74243f) * Matrix.CreateTranslation(20.7032967f, 22.3458023f, -7791f / 128f);
      this.explodePart[350] = Matrix.CreateScale(21.3578758f, 32.8601456f, 75.0892944f) * Matrix.CreateTranslation(24.4010277f, 4.362201f, -66.28195f);
      this.explodePart[351] = Matrix.CreateScale(39.3914642f, 21.1478958f, 21.2209568f) * Matrix.CreateTranslation(-26.055788f, 65.2784958f, 18.1813755f);
      this.explodePart[352] = Matrix.CreateScale(44.6576233f, 24.1561279f, 40.8132935f) * Matrix.CreateTranslation(-26.05249f, 57.9575081f, 10.0550766f);
      this.explodePart[353] = Matrix.CreateScale(46.666214f, 24.81445f, 42.42134f) * Matrix.CreateTranslation(-24.583334f, 49.98239f, 10.8176956f);
      this.explodePart[354] = Matrix.CreateScale(47.11537f, 29.04306f, 29.1212158f) * Matrix.CreateTranslation(-22.836813f, 40.6946526f, 19.14212f);
      this.explodePart[355] = Matrix.CreateScale(7.741117f, 17.1695862f, 29.3646774f) * Matrix.CreateTranslation(-5.892443f, 69.97655f, 50.8186646f);
      this.explodePart[356] = Matrix.CreateScale(13.02623f, 21.4629211f, 41.78871f) * Matrix.CreateTranslation(-1.96052575f, 3527f / 64f, 63.46292f);
      this.explodePart[357] = Matrix.CreateScale(18.8374977f, 24.1212254f, 57.3445435f) * Matrix.CreateTranslation(2.459224f, 37.1668f, 83.61486f);
      this.explodePart[358] = Matrix.CreateScale(26.28875f, 32.9216537f, 50.4528961f) * Matrix.CreateTranslation(7.60254145f, 17.14613f, 88.26848f);
      this.explodePart[359] = Matrix.CreateScale(21.7856522f, 12.76709f, 19.8228531f) * Matrix.CreateTranslation(-18.6751633f, 78.1567841f, 46.27141f);
      this.explodePart[360] = Matrix.CreateScale(23.6215515f, 13.5829315f, 28.6945114f) * Matrix.CreateTranslation(-17.0146542f, 73.26574f, 50.84252f);
      this.explodePart[361] = Matrix.CreateScale(26.1430359f, 14.5051193f, 31.8182678f) * Matrix.CreateTranslation(-15.8990822f, 67.04201f, 55.9826241f);
      this.explodePart[362] = Matrix.CreateScale(29.386322f, 15.8401756f, 36.7682648f) * Matrix.CreateTranslation(-13.3403816f, 60.84601f, 62.8799248f);
      this.explodePart[363] = Matrix.CreateScale(17.1857529f, 11.8979187f, 54.82617f) * Matrix.CreateTranslation(14.8161516f, 25.9783173f, 37.08486f);
      this.explodePart[364] = Matrix.CreateScale(16.0711327f, 11.34214f, 57.2019653f) * Matrix.CreateTranslation(17.5110512f, 22.6491642f, 41.5145569f);
      this.explodePart[365] = Matrix.CreateScale(14.64164f, 9.176123f, 51.1224823f) * Matrix.CreateTranslation(47.8439255f, 48.1778526f, -50.4570351f);
      this.explodePart[366] = Matrix.CreateScale(15.0920563f, 9.420319f, 52.49585f) * Matrix.CreateTranslation(48.74552f, 45.7879524f, -49.90796f);
      this.explodePart[367] = Matrix.CreateScale(16.3912659f, 13.7155132f, 54.7410126f) * Matrix.CreateTranslation(19.2778778f, 16.6186848f, 44.7582245f);
      this.explodePart[368] = Matrix.CreateScale(15.0419006f, 16.6673889f, 51.56897f) * Matrix.CreateTranslation(20.9582672f, 9.726122f, 47.05005f);
      this.explodePart[369] = Matrix.CreateScale(13.2184143f, 9.149948f, 25.82454f) * Matrix.CreateTranslation(12.1533527f, 40.25004f, 50.7354927f);
      this.explodePart[370] = Matrix.CreateScale(14.3089638f, 9.8034935f, 43.99594f) * Matrix.CreateTranslation(12.6596794f, 37.1393929f, 42.0807343f);
      this.explodePart[371] = Matrix.CreateScale(17.2439957f, 11.5307617f, 67.73486f) * Matrix.CreateTranslation(15.3467159f, 30.4183044f, 34.3815842f);
      this.explodePart[372] = Matrix.CreateScale(1.61276817f, 0.489341736f, 1.64398193f) * Matrix.CreateTranslation(17.0124989f, 33.1573524f, 2.413669f);
      this.explodePart[373] = Matrix.CreateScale(15.5487671f, 10.8210926f, 58.9225922f) * Matrix.CreateTranslation(13.2418957f, 33.9315872f, 36.0010262f);
      this.explodePart[374] = Matrix.CreateScale(14.8968658f, 13.7477608f, 52.40547f) * Matrix.CreateTranslation(12.805872f, 25.7786465f, -6.52240849f);
      this.explodePart[375] = Matrix.CreateScale(16.9656525f, 13.6676521f, 61.42038f) * Matrix.CreateTranslation(14.0886173f, 20.9465637f, -7.286235f);
      this.explodePart[376] = Matrix.CreateScale(17.9778824f, 15.1225052f, 71.9154358f) * Matrix.CreateTranslation(15.9401283f, 14.113246f, -6.632375f);
      this.explodePart[377] = Matrix.CreateScale(18.6211929f, 17.1617432f, 80.421814f) * Matrix.CreateTranslation(17.7096348f, 7.06802559f, -3.35475159f);
      this.explodePart[378] = Matrix.CreateScale(16.7254486f, 15.8545914f, 44.894165f) * Matrix.CreateTranslation(9.453372f, 67.27686f, -24.703104f);
      this.explodePart[379] = Matrix.CreateScale(18.4049454f, 16.1858177f, 75.79428f) * Matrix.CreateTranslation(11.7659731f, 60.872654f, -24.9282036f);
      this.explodePart[380] = Matrix.CreateScale(19.0218353f, 18.8684387f, 95.5869141f) * Matrix.CreateTranslation(13.2333755f, 52.8915825f, -34.8245049f);
      this.explodePart[381] = Matrix.CreateScale(17.5304413f, 27.630127f, 110.573853f) * Matrix.CreateTranslation(13.9410076f, 39.43802f, -55.7464638f);
      this.explodePart[382] = Matrix.CreateScale(17.8151169f, 13.4596329f, 36.33947f) * Matrix.CreateTranslation(0.233820915f, 84.86167f, -60.0324936f);
      this.explodePart[383] = Matrix.CreateScale(17.6779785f, 13.4469757f, 43.69464f) * Matrix.CreateTranslation(3.10785532f, 79.86958f, -50.9571228f);
      this.explodePart[384] = Matrix.CreateScale(18.1733246f, 15.5835342f, 50.95349f) * Matrix.CreateTranslation(5.6127243f, 72.813385f, -43.82808f);
      this.explodePart[385] = Matrix.CreateScale(17.5526466f, 18.4057465f, 43.58432f) * Matrix.CreateTranslation(8.074933f, 65.1538f, -41.68637f);
      this.explodePart[386] = Matrix.CreateScale(27.1202545f, 15.6020164f, 30.8329849f) * Matrix.CreateTranslation(-16.1887245f, 55.5183258f, 62.34473f);
      this.explodePart[387] = Matrix.CreateScale(31.22409f, 15.879818f, 30.1970215f) * Matrix.CreateTranslation(-14.26668f, 49.6826477f, 67.759285f);
      this.explodePart[388] = Matrix.CreateScale(27.0406265f, 22.5823975f, 32.4923248f) * Matrix.CreateTranslation(-8.965259f, 32.75258f, 80.14053f);
      this.explodePart[389] = Matrix.CreateScale(9.319027f, 3.43231964f, 6.278137f) * Matrix.CreateTranslation(-1.83895612f, 42.861496f, 93.22227f);
      int randomSeed = this.randomSeed;
      for (int index = 0; index < num; ++index)
      {
        this.bloody.dupe[index] = new explodeDupe(randomSeed);
        ++randomSeed;
      }
      this.bloody.max = num;
    }

    public void initExplode()
    {
      float num1 = 5f;
      float y = -100f;
      float num2 = 1f;
      Random random = new Random();
      if (this.sc.bossexplodechoice == 1)
        y = (float) random.Next(-96000, -36000) / 100f;
      if (this.sc.bossexplodechoice == 2)
        y = (float) random.Next(-21000, -3000) / 100f;
      if (this.sc.bossexplodechoice == 3)
        y = (float) random.Next(1500, 26000) / 100f;
      ++this.sc.bossexplodechoice;
      if (this.sc.bossexplodechoice > 3)
        this.sc.bossexplodechoice = 1;
      num2 = (float) random.Next(90, 195) / 100f;
      float reality = 3f;
      num1 = (float) random.Next(250, 400) / 100f;
      Vector3 vector3_1 = new Vector3((float) random.Next(-40, 40) / 100f, (float) random.Next(-20, 20) / 100f, (float) random.Next(-40, 40) / 100f);
      for (int index = 0; index < this.explodePart.Length; ++index)
      {
        float num3 = (float) random.Next(410, 490) / 100f;
        this.explodePart[index] = this.explodePart[index] * Matrix.CreateScale(this.cuttyScale * 1f) * Matrix.CreateRotationY(this.cuttyRot) * Matrix.CreateTranslation(new Vector3(this.cuttyPos.X, this.cuttyPos.Y + 20f, this.cuttyPos.Z));
        Vector3 vector3_2 = Vector3.Transform(Vector3.Zero, this.explodePart[index]) - new Vector3(this.cuttyPos.X, y, this.cuttyPos.Z);
        this.bloody.dupe[index].createState(this.explodePart[index], (vector3_1 + Vector3.Normalize(vector3_2)) * num3, this.cuttyScale, reality);
      }
    }

    private void updateExplode(ref float[,] heights)
    {
      this.bloody.tempindex = 0;
      for (int index = 0; index < this.bloody.max; ++index)
      {
        if (this.bloody.dupe[index].move == 1)
        {
          this.bloody.dupe[index].Update(ref heights);
          this.bloody.stream[index].Trans = this.bloody.dupe[index].transform;
          this.bloody.displayList[this.bloody.tempindex] = this.bloody.stream[index];
          ++this.bloody.tempindex;
          if ((double) this.sc.myTimer % 4.0 == 0.0 && this.bloody.dupe[index].age > 2300)
          {
            if ((double) Math.Abs(this.bloody.dupe[index].mypos.X) > 7000.0 || (double) Math.Abs(this.bloody.dupe[index].mypos.Z) > 7000.0)
              this.bloody.dupe[index].move = 0;
            this.bloody.dupe[index].scalePart *= 0.97f;
            this.bloody.dupe[index].myscale *= 0.97f;
            if (this.bloody.dupe[index].age > 2750)
              this.bloody.dupe[index].move = 0;
          }
        }
      }
      if (this.bloody.tempindex >= 4)
        return;
      this.bloody.index = 0;
      this.bloody.max = 0;
    }

    private void drawExplode()
    {
      int tempindex = this.bloody.tempindex;
      if (tempindex < 1)
        return;
      ModelMeshPart meshPart = this.bloody.model.Meshes[0].MeshParts[0];
      this.bloody.buffer.SetData<Princess.instancedObject>(this.bloody.displayList, 0, tempindex, SetDataOptions.Discard);
      Effect effect = meshPart.Effect;
      effect.CurrentTechnique = effect.Techniques["fastShader"];
      effect.Parameters["View"].SetValue(this.view);
      effect.Parameters["Projection"].SetValue(this.proj);
      effect.CurrentTechnique.Passes[0].Apply();
      this._vertexBufferBindings[0] = new VertexBufferBinding(meshPart.VertexBuffer, meshPart.VertexOffset, 0);
      this._vertexBufferBindings[1] = new VertexBufferBinding((VertexBuffer) this.bloody.buffer, 0, 1);
      this.sc.GraphicsDevice.SetVertexBuffers(this._vertexBufferBindings);
      this.sc.GraphicsDevice.Indices = meshPart.IndexBuffer;
      this.sc.GraphicsDevice.DrawInstancedPrimitives(PrimitiveType.TriangleList, 0, 0, meshPart.NumVertices, meshPart.StartIndex, meshPart.PrimitiveCount, tempindex);
    }

    private void energize()
    {
      Vector3 position = new Vector3((float) this.rr.Next(-2900, 2900), (float) this.rr.Next(20, 60), (float) this.rr.Next(-2900, 2900)) + new Vector3(3000f, 10f, 3000f);
      Vector3 velocity = Vector3.Normalize(this.cuttyPos - position) * Vector3.Distance(this.cuttyPos, position) * (float) this.rr.Next(10, 60) / 100f;
      this.dots.AddParticle(position, velocity);
    }

    private void drawPrincess(ref Texture2D myTexture, Matrix viewWorld, int tech)
    {
      if (!this.pigModelLoaded)
        return;
      this.pigModel.Meshes[this.sc.bossIndex].MeshParts[0].Effect = this.pigSkin;
      this.pigSkin.Parameters["darkness"].SetValue(MathHelper.Lerp(0.0f, 1.2f, this.sc.darkness));
      this.pigSkin.Parameters["gDiffuse"].SetValue((Texture) myTexture);
      this.pigSkin.Parameters["projectorView"].SetValue(viewWorld);
      this.pigSkin.Parameters["amb"].SetValue(new Vector3(0.4f, 0.4f, 0.4f));
      this.pigSkin.Parameters["diff"].SetValue(new Vector3(0.7f, 0.7f, 0.7f));
      this.pigSkin.Parameters["LightDirection"].SetValue(new Vector3(0.7f, -0.7f, 0.0f));
      this.pigSkin.Parameters["View"].SetValue(this.view);
      this.pigSkin.Parameters["Projection"].SetValue(this.proj);
      this.pigSkin.Parameters["Bones"].SetValue(this.a.skinTransforms);
      this.pigSkin.CurrentTechnique = this.pigSkin.Techniques[tech];
      this.pigModel.Meshes[this.sc.bossIndex].Draw();
    }

    private void drawCuttySkel()
    {
      this.sc.bossAll.Meshes[0].MeshParts[0].Effect = this.pigSkin;
      this.pigSkin.Parameters["View"].SetValue(this.view);
      this.pigSkin.Parameters["Projection"].SetValue(this.proj);
      this.pigSkin.Parameters["Bones"].SetValue(this.a.skinTransforms);
      this.pigSkin.CurrentTechnique = this.pigSkin.Techniques["skeleton"];
      this.sc.bossAll.Meshes[0].Draw();
    }

    private void drawHeart(float dist)
    {
      float num1 = (float) ((Math.Cos((double) this.sc.myTimer / 60.0) * 3.0 + 4.0) / 100.0);
      float num2 = 1.8f;
      if (this.death1 || (double) this.heartattack > 0.0)
      {
        num1 = 0.16f;
        num2 = 2.2f;
      }
      this.heartTimer += 0.08f + num1;
      this.a.boneTransforms[17] = Matrix.CreateScale(MathHelper.Lerp(0.1f, num2, 1f - (float) Math.Abs(Math.Sin((double) this.heartTimer)))) * this.heartMatrix;
      this.a.UpdateWorldTransforms(this.cuttyTrans, this.a.boneTransforms);
      --this.heartattack;
      if ((double) this.heartattack < 60.0)
        this.heartVol = false;
      if ((double) this.heartattack <= 0.0 && !this.death1)
      {
        this.sc.bossAll.Meshes[8].MeshParts[0].Effect = this.pigSkin;
        this.pigSkin.Parameters["fade"].SetValue(dist);
        this.pigSkin.Parameters["slide"].SetValue(this.sc.myTimer * (3f / 500f));
        this.pigSkin.Parameters["View"].SetValue(this.view);
        this.pigSkin.Parameters["Projection"].SetValue(this.proj);
        this.pigSkin.Parameters["Bones"].SetValue(this.a.skinTransforms);
        this.pigSkin.CurrentTechnique = this.pigSkin.Techniques["heart"];
        this.sc.bossAll.Meshes[8].Draw();
      }
      else
      {
        this.sc.bossAll.Meshes[8].MeshParts[0].Effect = this.pigSkin;
        this.pigSkin.Parameters["slide"].SetValue(this.sc.myTimer * 0.01f);
        this.pigSkin.Parameters["pulse"].SetValue(0.2f + (float) Math.Abs(Math.Sin((double) this.sc.myTimer / 4.0)));
        this.pigSkin.Parameters["View"].SetValue(this.view);
        this.pigSkin.Parameters["Projection"].SetValue(this.proj);
        this.pigSkin.Parameters["Bones"].SetValue(this.a.skinTransforms);
        this.pigSkin.CurrentTechnique = this.pigSkin.Techniques["heartattack"];
        this.sc.bossAll.Meshes[8].Draw();
      }
    }

    private void DrawModel(Model model, Matrix world)
    {
      Vector3 vector3_1 = new Vector3(0.52f, 0.52f, 0.52f);
      Vector3 vector3_2 = new Vector3(0.85f, 0.85f, 0.85f);
      foreach (BasicEffect effect in model.Meshes[0].Effects)
      {
        effect.World = world;
        effect.View = this.view;
        effect.Projection = this.proj;
        effect.LightingEnabled = true;
        effect.DirectionalLight0.Enabled = true;
        effect.DirectionalLight0.Direction = new Vector3(0.2f, -0.5f, 0.1f);
        effect.AmbientLightColor = vector3_2;
        effect.DirectionalLight0.DiffuseColor = vector3_1;
        effect.PreferPerPixelLighting = false;
      }
      model.Meshes[0].Draw();
    }

    private void shockWave(ref float[,] heights)
    {
      --this.shockTimer;
      if ((double) this.shockTimer <= 0.0)
        this.jumpVol = false;
      this.shockRadius += (float) this.rr.Next(8, 15);
      if (!this.shockHasHit && (double) Vector3.Distance(this.playerpos, this.cuttyPos) < (double) this.shockRadius)
      {
        this.shockHasHit = true;
        this.shockHit = true;
      }
      Vector3 up = Vector3.Up;
      float num1 = 120f / (float) (2.0 * (double) this.shockRadius * 3.1400001049041748);
      if ((double) num1 < 0.019999999552965164)
        num1 = 0.02f;
      float maxValue1 = (float) (this.rr.Next(2100, 9000) / 5);
      Vector3 position = new Vector3(this.shockRadius, 0.0f, 0.0f);
      for (float radians = 0.0f; (double) radians < 6.28000020980835; radians += num1 + (float) this.rr.Next(0, 30) / 500f)
      {
        Matrix.CreateRotationY(radians, out this.m1);
        Vector3.Transform(ref position, ref this.m1, out this.v1);
        this.v1.X += this.cuttyPos.X + (float) this.rr.Next(-12, 12);
        this.v1.Z += this.cuttyPos.Z + (float) this.rr.Next(-12, 12);
        Princess.GetHeightFast(ref heights, new Vector2(this.v1.X, this.v1.Z), out this.v1.Y);
        Vector3 result = new Vector3(this.v1.X, 0.0f, this.v1.Z) - new Vector3(this.cuttyPos.X, 0.0f, this.cuttyPos.Z);
        Vector3.Normalize(ref result, out result);
        int num2 = this.rr.Next(1, 3);
        result.Y = (float) this.rr.Next(80, 130) / 100f;
        for (int index = 0; index < num2; ++index)
        {
          int maxValue2 = this.rr.Next(0, 90);
          this.rocks.AddParticle(this.v1 + new Vector3((float) this.rr.Next(-maxValue2, maxValue2) / 100f, 0.0f, (float) this.rr.Next(-maxValue2, maxValue2) / 100f), result * (float) this.rr.Next(0, (int) maxValue1) / 10f);
        }
      }
    }

    public void drawCanvas()
    {
      this.canvas.Meshes[0].MeshParts[0].Effect = this.simple;
      this.simple.Parameters["world"].SetValue(Matrix.CreateTranslation(3000f, 0.5f, 3000f));
      this.simple.Parameters["Projection"].SetValue(this.proj);
      this.simple.Parameters["View"].SetValue(this.view);
      this.simple.CurrentTechnique = this.simple.Techniques[0];
      this.canvas.Meshes[0].Draw();
    }

    public void drawBurst()
    {
      if ((double) this.burstfade < 0.0)
        return;
      Vector3 objectPosition = new Vector3(this.cuttyPos.X, this.burstY, this.cuttyPos.Z);
      if (this.playerpos != objectPosition)
        objectPosition = Vector3.Normalize(this.playerpos - objectPosition) with
        {
          Y = 0.0f
        } * 250f + new Vector3(this.cuttyPos.X, this.burstY, this.cuttyPos.Z);
      Matrix billboard = Matrix.CreateBillboard(objectPosition, this.campos, this.view.Up, new Vector3?(this.view.Forward));
      if (this.explodeTimer <= 5)
      {
        if (this.explodeTimer >= -60)
        {
          this.burstscale += 0.03f;
          this.burstfade += 0.05f;
          if ((double) this.burstfade > 1.0)
            this.burstfade = 1f;
          if ((double) this.burstscale > 1.0)
            this.burstscale = 1f;
        }
        if (this.explodeTimer < -60)
        {
          this.burstY -= 0.15f;
          this.burstfade *= 0.99f;
          this.burstfade -= 0.0001f;
          this.burstscale -= 0.008f;
          if ((double) this.burstscale < 0.0)
            this.burstscale = 0.0f;
        }
      }
      this.burstMatrix *= Matrix.CreateRotationZ(0.02f);
      this.grid.Meshes[0].MeshParts[0].Effect = this.burst;
      this.burst.Parameters["fader"].SetValue(this.burstfade);
      this.burst.Parameters["world"].SetValue(Matrix.CreateScale(this.burstscale) * this.burstMatrix * billboard);
      this.burst.Parameters["Projection"].SetValue(this.proj);
      this.burst.Parameters["View"].SetValue(this.view);
      this.burst.CurrentTechnique = this.burst.Techniques[0];
      this.grid.Meshes[0].Draw();
    }

    public void drawGuts()
    {
      this.gutsModel.Meshes[0].MeshParts[0].Effect = this.gutsEffect;
      this.gutsEffect.Parameters["world"].SetValue(Matrix.CreateTranslation(3000f, 0.0f, 3000f));
      this.gutsEffect.Parameters["Projection"].SetValue(this.proj);
      this.gutsEffect.Parameters["View"].SetValue(this.view);
      this.gutsEffect.CurrentTechnique = this.gutsEffect.Techniques[0];
      this.gutsModel.Meshes[0].Draw();
    }

    public void drawTunnel()
    {
      this.tunnel.Meshes[0].MeshParts[0].Effect = this.tunnelfx;
      this.tunnelfx.Parameters["u"].SetValue(this.sc.myTimer * (11f / 1000f));
      this.tunnelfx.Parameters["fade"].SetValue(this.cuttyRollFade);
      this.tunnelfx.Parameters["world"].SetValue(Matrix.CreateRotationY(this.cuttyRot - 1.57f) * Matrix.CreateTranslation(3000f, 0.0f, 3000f));
      this.tunnelfx.Parameters["Projection"].SetValue(this.proj);
      this.tunnelfx.Parameters["View"].SetValue(this.view);
      this.tunnelfx.CurrentTechnique = this.tunnelfx.Techniques[0];
      this.tunnel.Meshes[0].Draw();
    }

    private void DrawInstance(Princess.shell shell, string tech)
    {
      int tempindex = shell.tempindex;
      if (tempindex < 1)
        return;
      ModelMeshPart meshPart = shell.model.Meshes[0].MeshParts[0];
      shell.buffer.SetData<Princess.instancedObject>(shell.displayList, 0, tempindex, SetDataOptions.Discard);
      Effect effect = meshPart.Effect;
      effect.Parameters["darkness"].SetValue(MathHelper.Lerp(0.3f, 1.2f, this.sc.darkness));
      effect.Parameters["amb"].SetValue(new Vector3(0.4f, 0.4f, 0.4f));
      effect.Parameters["diff"].SetValue(new Vector3(0.7f, 0.7f, 0.7f));
      effect.Parameters["LightDirection"].SetValue(new Vector3(0.7f, -0.8f, 0.0f));
      effect.CurrentTechnique = effect.Techniques[tech];
      effect.Parameters["View"].SetValue(this.view);
      effect.Parameters["Projection"].SetValue(this.proj);
      effect.CurrentTechnique.Passes[0].Apply();
      this._vertexBufferBindings[0] = new VertexBufferBinding(meshPart.VertexBuffer, meshPart.VertexOffset, 0);
      this._vertexBufferBindings[1] = new VertexBufferBinding((VertexBuffer) shell.buffer, 0, 1);
      this.sc.GraphicsDevice.SetVertexBuffers(this._vertexBufferBindings);
      this.sc.GraphicsDevice.Indices = meshPart.IndexBuffer;
      this.sc.GraphicsDevice.DrawInstancedPrimitives(PrimitiveType.TriangleList, 0, 0, meshPart.NumVertices, meshPart.StartIndex, meshPart.PrimitiveCount, tempindex);
    }

    public void DrawPuke(float fader)
    {
      int tempindex = this.puke1.tempindex;
      if (tempindex < 1)
        return;
      ModelMeshPart meshPart = this.puke1.model.Meshes[0].MeshParts[0];
      this.puke1.buffer.SetData<Princess.instancedObject>(this.puke1.displayList, 0, tempindex, SetDataOptions.Discard);
      Effect effect = meshPart.Effect;
      effect.CurrentTechnique = effect.Techniques["fastShader2"];
      effect.Parameters[nameof (fader)].SetValue(fader);
      effect.Parameters["View"].SetValue(this.view);
      effect.Parameters["Projection"].SetValue(this.proj);
      effect.CurrentTechnique.Passes[0].Apply();
      this._vertexBufferBindings[0] = new VertexBufferBinding(meshPart.VertexBuffer, meshPart.VertexOffset, 0);
      this._vertexBufferBindings[1] = new VertexBufferBinding((VertexBuffer) this.puke1.buffer, 0, 1);
      this.sc.GraphicsDevice.SetVertexBuffers(this._vertexBufferBindings);
      this.sc.GraphicsDevice.Indices = meshPart.IndexBuffer;
      this.sc.GraphicsDevice.DrawInstancedPrimitives(PrimitiveType.TriangleList, 0, 0, meshPart.NumVertices, meshPart.StartIndex, meshPart.PrimitiveCount, tempindex);
    }

    private static void GetHeightFast(ref float[,] heights, Vector2 position, out float height)
    {
      int index1 = (int) MathHelper.Clamp(position.X / Princess.unit, 0.0f, (float) (Princess.bitmap - 2));
      int index2 = (int) MathHelper.Clamp(position.Y / Princess.unit, 0.0f, (float) (Princess.bitmap - 2));
      height = heights[index1, index2];
    }

    public struct instancedObject : IVertexType
    {
      public Matrix Trans;
      public Vector3 color;
      private static readonly VertexDeclaration InstanceVertexDeclaration = new VertexDeclaration(new VertexElement[5]
      {
        new VertexElement(0, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 0),
        new VertexElement(16, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 1),
        new VertexElement(32, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 2),
        new VertexElement(48, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 3),
        new VertexElement(64, VertexElementFormat.Vector3, VertexElementUsage.Normal, 1)
      });

      VertexDeclaration IVertexType.VertexDeclaration
      {
        get => Princess.instancedObject.InstanceVertexDeclaration;
      }
    }

    public struct shell
    {
      public int max;
      public int tempindex;
      public int index;
      public int maxCapacity;
      public Matrix[] offset;
      public bool startDrop;
      public float dropTimer;
      public int[] bone;
      public Princess.instancedObject[] stream;
      public DynamicVertexBuffer buffer;
      public Princess.instancedObject[] displayList;
      public chunkDupe[] dupe;
      public Model model;
    }

    public struct vomit
    {
      public int max;
      public int tempindex;
      public int index;
      public int maxCapacity;
      public Princess.instancedObject[] stream;
      public DynamicVertexBuffer buffer;
      public Princess.instancedObject[] displayList;
      public vomitDupe[] dupe;
      public Model model;
    }

    public struct finale
    {
      public int max;
      public int tempindex;
      public int index;
      public int maxCapacity;
      public Princess.instancedObject[] stream;
      public DynamicVertexBuffer buffer;
      public Princess.instancedObject[] displayList;
      public explodeDupe[] dupe;
      public Model model;
    }

    public struct conductor
    {
      public int flag;
      public int time;
      public int homing;
      public float rot;
      public int animType;
      public int talkindex;
      public ushort dur;
    }

    public struct paintBody
    {
      public List<int> index;
      public List<float> x;
      public List<float> z;
    }
  }
}
