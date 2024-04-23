// Decompiled with JetBrains decompiler
// Type: Blood.Cutty
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
using System.Globalization;
using System.IO;
using System.Text;

#nullable disable
namespace Blood
{
  internal class Cutty
  {
    private int hitcounter;
    public static int bitmap;
    public static float unit;
    public static float Grid;
    public static float shortestDistance = 20000f;
    public static byte bit = 0;
    public static byte uvIndex = 0;
    public static int xcoord = 0;
    public static int ycoord = 0;
    public static int cuttyCount = 0;
    public static bool allplayersReady = false;
    public static bool cuttyDoneSpeech = false;
    public static int homingLocal = -1;
    public static int homingRemote = -1;
    public static int speeches = 0;
    public static int whichPigTalks = 0;
    public static bool someoneTalking = false;
    public static int gonnaHealindex = -1;
    public int df;
    public int oldDF;
    private AnimationPlayer a;
    private AnimationPlayer b;
    private Matrix[] cuttyBone;
    private int myClip;
    private NetworkSession networkSession;
    public int break1 = 510;
    public int break2 = 790;
    public float olderDarkness;
    private int timeframe;
    public bool spectator;
    private float playerHealth;
    private float remoteHealth;
    private SoundEffects gallop;
    private SoundEffects burning;
    private ParticleSystem sparks;
    private ParticleSystem dots;
    public float shockRadius;
    public float shockTimer;
    public bool shockHit;
    public bool shockHasHit;
    public static StringBuilder nameBuild = new StringBuilder(32, 32);
    public int myIndex;
    public int myType;
    private int bodyState;
    public bool boneStrike;
    private int showSkelTimer;
    public int seizureTimer;
    private int faceseizureTimer;
    public float glowTimer;
    private Vector3 playerpos;
    private Vector3 remotepos;
    public bool cuttyMouthCollide;
    public bool cuttyAssPush;
    public int cuttyWait;
    public Vector2 cuttyMouthPos;
    private readonly VertexBufferBinding[] _vertexBufferBindings = new VertexBufferBinding[2];
    private Cutty.hitStream hitstreamTemp = new Cutty.hitStream();
    private static VertexDeclaration vd2 = new VertexDeclaration(new VertexElement[6]
    {
      new VertexElement(0, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 0),
      new VertexElement(16, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 1),
      new VertexElement(32, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 2),
      new VertexElement(48, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 3),
      new VertexElement(64, VertexElementFormat.Single, VertexElementUsage.Fog, 0),
      new VertexElement(68, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 4)
    });
    public int fireRamp = 130;
    public int fireTimer = 500;
    public bool onFire;
    private Cutty.hole fireball;
    private static VertexDeclaration instanceDec = new VertexDeclaration(new VertexElement[4]
    {
      new VertexElement(0, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 0),
      new VertexElement(16, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 1),
      new VertexElement(32, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 2),
      new VertexElement(48, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 3)
    });
    private Cutty.instancedObject[] tempInstance = new Cutty.instancedObject[1];
    private Cutty.shell chunk;
    private Cutty.shell faceChunk;
    private Cutty.shell assChunk;
    public static RasterizerState wiredOn = new RasterizerState()
    {
      FillMode = FillMode.WireFrame
    };
    public static RasterizerState wiredOff = new RasterizerState()
    {
      FillMode = FillMode.Solid
    };
    private Curve[] targetX;
    private Curve[] targetZ;
    private float tx;
    private float tz;
    public float targetRate;
    public int targetWait;
    public bool newAction;
    public float[] targetDist;
    public int curveIndex = 1;
    public float loop;
    public float cuttyDistance = 20000f;
    public float fps;
    public ushort assDamage;
    public ushort faceDamage;
    public ushort spineDamage;
    private bool assDestroyed;
    private bool spineDestroyed;
    private bool faceDestroyed;
    public float[] assBreach = new float[6]
    {
      40f,
      50f,
      70f,
      60f,
      70f,
      80f
    };
    public ushort[] assDam = new ushort[6]
    {
      (ushort) 12,
      (ushort) 10,
      (ushort) 8,
      (ushort) 9,
      (ushort) 5,
      (ushort) 5
    };
    public float[] faceBreach = new float[6]
    {
      40f,
      50f,
      70f,
      80f,
      100f,
      100f
    };
    public ushort[] faceDam = new ushort[6]
    {
      (ushort) 14,
      (ushort) 10,
      (ushort) 8,
      (ushort) 8,
      (ushort) 5,
      (ushort) 5
    };
    public float[] spineBreach = new float[6]
    {
      30f,
      40f,
      50f,
      50f,
      60f,
      70f
    };
    public ushort[] spineDam = new ushort[6]
    {
      (ushort) 14,
      (ushort) 10,
      (ushort) 8,
      (ushort) 8,
      (ushort) 5,
      (ushort) 5
    };
    public float delay;
    private int timeDelay;
    private int lasttimeDelay;
    public bool actionScheduled;
    public Cutty.conductor tempConduct = new Cutty.conductor();
    private Cutty.conductor cuttyStruct = new Cutty.conductor();
    private Cutty.conductor cuttyStruct_send = new Cutty.conductor();
    private List<Cutty.conductor> scheduleList = new List<Cutty.conductor>();
    private int currentKeyframe;
    private TimeSpan currentTimeValue;
    private ScreenManager sc;
    private ContentManager content;
    private ContentManager contentB;
    private RenderTarget2D screenTarget1;
    private RenderTarget2D screenTarget2;
    private int targetChoice;
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
    public string[] pigdialogueName = new string[23]
    {
      "entrails",
      "vomit",
      "introduction2",
      "latin1",
      "latin2",
      "nohope",
      "seensmell",
      "timetodie",
      "yell1",
      "roar1",
      "roar2",
      "roar3",
      "roar4",
      "trample1",
      "trample2",
      "brethren1",
      "brethren2",
      "peace1",
      "peace2",
      "spine1",
      "spine2",
      "sport1",
      "sport2"
    };
    private List<int> quips = new List<int>()
    {
      0,
      1,
      5,
      6,
      7,
      5,
      1,
      0,
      6
    };
    public int pigLine = -1;
    public int pigJawIndex = -1;
    public int talkIndex = -1;
    public SoundEffects pigDialog1;
    private float distanceCutty = 1000f;
    private float distanceCutty2 = 1000f;
    private int glowWait = 500;
    public float eyeGlow = 1f;
    public bool isSpeaking;
    public bool isWatching;
    public bool pigDialog1Loaded;
    public bool lookingatPig = true;
    public float[] pigJaw;
    public float talkSmooth;
    public float piglook;
    public float pigPush;
    public float pigFrame1;
    private float animCount = -1f;
    public int animClip;
    private List<int> animList = new List<int>();
    private float animTween;
    private int animLoop;
    private int animMin;
    private int animMax;
    private bool gonnaBite;
    private AnimationPlayer[] pig1;
    private int clipIndexA;
    private int clipIndexB;
    private float tween = 1f;
    private float[] clipRate;
    private float cuttyRate;
    public Vector3 cuttyPos;
    public Vector3 oldcuttyPos;
    public Vector3 cuttyVeloc;
    public float cuttyScale;
    public float cuttyRot;
    private Matrix cuttyTrans;
    private Random rr;
    private Model pigModel;
    private Model sphere;
    private Model eyeglow;
    private int pigIndex;
    private Effect pigSkin;
    private Effect eyeEffect;
    private Effect solidSkin;
    public Effect glowEffect;
    private Texture2D pigTexture;
    private Texture2D eyeTexture1;
    private Texture2D eyeTexture2;
    private Matrix view;
    private Matrix proj;
    public bool attack1;
    private bool attackLand;
    private int nextAttack = 100;
    public bool death1;
    public bool deathsent;
    public bool cuttyisDead;
    public bool cuttyHeal;
    private float gonnaHealDelay;
    private Vector3 roofTop1 = new Vector3(3364f, -1.57f, 4625f);
    private Vector3 roofTop2 = new Vector3(1244f, 0.0f, 2868f);
    private Vector3 roofTop3 = new Vector3(4639f, 0.0f, 2942f);
    private float cuttyDeadx;
    private float cuttyDeadz;
    private float cuttyDeadrot;
    private bool cuttyDyingWalk;
    private float cuttyDeathTimer = 500f;
    private float cuttyHealrot;
    private float origx;
    private float origy;
    private float origz;
    private float destx;
    private float desty;
    private float destz;
    private float upForce;
    private float grav;
    private float attackduration;
    private float attacktimer;
    private float attackWait1;
    private float attackWait2;
    private float healorigx;
    private float healorigy;
    private float healorigz;
    private float healdestx;
    private float healdesty;
    private float healdestz;
    private float healduration;
    private float healtimer;
    private float healWait1;
    private float healWait2;
    private float healChant;
    private bool onGround;
    public ushort startHealth = 1500;
    public ushort health = 1500;
    private float healthPerc;
    private int healCount = 2;
    public byte damagebit = 1;
    public int homing;
    public int homingCount;
    public bool cuttyDoneLocalSpeech;
    public int speechCurveindex = 4;
    public int startCurveindex = 1;
    public float startLoop = 0.2f;
    public float startRate = 9f;
    private List<int> speechList = new List<int>();
    private List<int> speechInclude = new List<int>();

    public Cutty(int index, int type, string name, int healthpoints)
    {
      Cutty.shortestDistance = 20000f;
      Cutty.bit = (byte) 0;
      Cutty.uvIndex = (byte) 0;
      Cutty.xcoord = 0;
      Cutty.ycoord = 0;
      Cutty.cuttyCount = 0;
      Cutty.allplayersReady = false;
      Cutty.cuttyDoneSpeech = false;
      Cutty.homingLocal = -1;
      Cutty.homingRemote = -1;
      Cutty.speeches = 0;
      Cutty.whichPigTalks = 0;
      Cutty.someoneTalking = false;
      Cutty.gonnaHealindex = -1;
      Cutty.homingLocal = -1;
      Cutty.homingRemote = -1;
      Cutty.nameBuild.Length = 0;
      Cutty.nameBuild.Append(name);
      Random random = new Random();
      this.health = (ushort) healthpoints;
      this.startHealth = (ushort) healthpoints;
      if (type == 3)
      {
        this.myIndex = index;
        this.myType = 3;
        this.speechList = new List<int>() { 2 };
        Cutty.speeches = 0;
        this.cuttyPos = new Vector3(6440f, 0.0f, 4526f);
        this.cuttyScale = 0.8f;
        this.speechInclude = new List<int>() { 0 };
        this.speechCurveindex = 4;
        this.startCurveindex = 1;
        this.startLoop = (float) random.Next(20, 90) / 100f;
        this.startRate = 9f;
        this.targetRate = 0.0f;
      }
      if (type == 0)
      {
        this.myIndex = index;
        this.myType = 0;
        this.speechList = new List<int>() { 17, 18 };
        Cutty.speeches = 0;
        this.cuttyPos = new Vector3(6440f, 0.0f, 4526f);
        this.cuttyScale = 0.92f;
        this.speechInclude = new List<int>() { 0 };
        this.speechCurveindex = 4;
        this.startCurveindex = 1;
        this.startLoop = (float) random.Next(10, 95) / 100f;
        this.startRate = 9f;
        this.targetRate = 0.0f;
      }
      if (type == 1)
      {
        this.myIndex = index;
        this.myType = 1;
        this.speechList = new List<int>() { 17, 18 };
        Cutty.speeches = 0;
        this.cuttyPos = new Vector3(5440f, 0.0f, 1500f);
        this.cuttyScale = 0.6f;
        this.speechInclude = new List<int>() { 1 };
        this.speechCurveindex = 5;
        this.startCurveindex = 2;
        this.startLoop = (float) random.Next(20, 90) / 100f;
        this.startRate = 11f;
        this.targetRate = 0.0f;
      }
      if (type == 2)
      {
        this.myIndex = index;
        this.myType = 2;
        this.speechList = new List<int>() { 17, 18 };
        Cutty.speeches = 0;
        this.cuttyPos = new Vector3(6140f, 0.0f, 5826f);
        this.cuttyScale = 0.66f;
        this.speechInclude = new List<int>() { 13 };
        this.speechCurveindex = 6;
        this.startCurveindex = 2;
        this.startLoop = (float) random.Next(20, 90) / 100f;
        this.startRate = 8f;
        this.targetRate = 0.0f;
      }
      if (type == 13)
      {
        this.myIndex = index;
        this.myType = 13;
        this.speechList = new List<int>() { 13, 14 };
        Cutty.speeches = 0;
        this.cuttyPos = new Vector3(6440f, 0.0f, 4526f);
        this.cuttyScale = 0.87f;
        this.speechInclude = new List<int>() { 0 };
        this.speechCurveindex = 4;
        this.startCurveindex = 1;
        this.startLoop = (float) random.Next(10, 95) / 100f;
        this.startRate = 9f;
        this.targetRate = 0.0f;
      }
      if (type == 14)
      {
        this.myIndex = index;
        this.myType = 14;
        this.speechList = new List<int>() { 13, 14 };
        Cutty.speeches = 0;
        this.cuttyPos = new Vector3(5440f, 0.0f, 1500f);
        this.cuttyScale = 0.6f;
        this.speechInclude = new List<int>() { 1 };
        this.speechCurveindex = 5;
        this.startCurveindex = 2;
        this.startLoop = (float) random.Next(20, 90) / 100f;
        this.startRate = 11f;
        this.targetRate = 0.0f;
      }
      if (type == 4)
      {
        this.myIndex = index;
        this.myType = 4;
        this.speechList = new List<int>() { 15, 16 };
        Cutty.speeches = 0;
        this.cuttyPos = new Vector3(6440f, 0.0f, 4526f);
        this.cuttyScale = 0.5f;
        this.speechInclude = new List<int>() { 0 };
        this.speechCurveindex = 4;
        this.startCurveindex = 1;
        this.startLoop = (float) random.Next(10, 95) / 100f;
        this.startRate = 7f;
        this.targetRate = 0.0f;
      }
      if (type == 5)
      {
        this.myIndex = index;
        this.myType = 5;
        this.speechList = new List<int>() { 15, 16 };
        Cutty.speeches = 0;
        this.cuttyPos = new Vector3(5440f, 0.0f, 1500f);
        this.cuttyScale = 1f;
        this.speechInclude = new List<int>() { 1 };
        this.speechCurveindex = 5;
        this.startCurveindex = 2;
        this.startLoop = (float) random.Next(20, 90) / 100f;
        this.startRate = 9f;
        this.targetRate = 0.0f;
      }
      if (type == 6)
      {
        this.myIndex = index;
        this.myType = 6;
        this.speechList = new List<int>() { 21, 22 };
        Cutty.speeches = 0;
        this.cuttyPos = new Vector3(5440f, 0.0f, 1500f);
        this.cuttyScale = 0.9f;
        this.speechInclude = new List<int>() { 1 };
        this.speechCurveindex = 5;
        this.startCurveindex = 3;
        this.startLoop = (float) random.Next(20, 90) / 100f;
        this.startRate = 9f;
        this.targetRate = 0.0f;
      }
      if (type == 7)
      {
        this.myIndex = index;
        this.myType = 7;
        this.speechList = new List<int>() { 21, 22 };
        Cutty.speeches = 0;
        this.cuttyPos = new Vector3(6140f, 0.0f, 5826f);
        this.cuttyScale = 0.85f;
        this.speechInclude = new List<int>() { 13 };
        this.speechCurveindex = 6;
        this.startCurveindex = 1;
        this.startLoop = (float) random.Next(20, 90) / 100f;
        this.startRate = 9f;
        this.targetRate = 0.0f;
      }
      if (type == 8)
      {
        this.myIndex = index;
        this.myType = 3;
        this.speechList = new List<int>() { 21, 22 };
        Cutty.speeches = 0;
        this.cuttyPos = new Vector3(6440f, 0.0f, 4526f);
        this.cuttyScale = 0.82f;
        this.speechInclude = new List<int>() { 0 };
        this.speechCurveindex = 4;
        this.startCurveindex = 2;
        this.startLoop = (float) random.Next(10, 95) / 100f;
        this.startRate = 9f;
        this.targetRate = 0.0f;
      }
      if (type == 11)
      {
        this.myIndex = index;
        this.myType = 11;
        this.speechList = new List<int>() { 19, 20 };
        Cutty.speeches = 0;
        this.cuttyPos = new Vector3(6440f, 0.0f, 4526f);
        this.cuttyScale = 0.7f;
        this.speechInclude = new List<int>() { 0 };
        this.speechCurveindex = 4;
        this.startCurveindex = 1;
        this.startLoop = (float) random.Next(10, 95) / 100f;
        this.startRate = 7f;
        this.targetRate = 0.0f;
      }
      if (type == 12)
      {
        this.myIndex = index;
        this.myType = 12;
        this.speechList = new List<int>() { 19, 20 };
        Cutty.speeches = 0;
        this.cuttyPos = new Vector3(5440f, 0.0f, 1500f);
        this.cuttyScale = 0.8f;
        this.speechInclude = new List<int>() { 1 };
        this.speechCurveindex = 5;
        this.startCurveindex = 2;
        this.startLoop = (float) random.Next(20, 90) / 100f;
        this.startRate = 9f;
        this.targetRate = 0.0f;
      }
      this.oldcuttyPos = this.cuttyPos;
      this.cuttyRot = (float) (3.1400001049041748 + (double) random.Next(-10, 10) / 100.0);
      this.curveIndex = this.speechCurveindex;
      this.loop = 0.5f;
    }

    public void LoadContent(ScreenManager sc, ContentManager cc)
    {
      this.sc = sc;
      this.content = cc;
      this.contentB = new ContentManager((IServiceProvider) sc.Game.Services, "Content");
      this.setbreakLevels();
      this.oldDF = this.df;
      this.spriteBatch = new SpriteBatch(sc.GraphicsDevice);
      this.rr = new Random();
      this.gallop = new SoundEffects(1);
      this.gallop.sound[0] = this.contentB.Load<SoundEffect>("audio\\gallop").CreateInstance();
      this.gallop.sound[0].IsLooped = true;
      this.gallop.sound[0].Play();
      this.gallop.sound[0].Volume = 0.0f;
      this.burning = new SoundEffects(1);
      this.burning.sound[0] = this.contentB.Load<SoundEffect>("audio\\burning").CreateInstance();
      this.burning.sound[0].IsLooped = true;
      this.burning.sound[0].Play();
      this.burning.sound[0].Volume = 0.0f;
      this.pigModel = sc.pigModel;
      this.pigIndex = 0;
      this.eyeglow = this.content.Load<Model>("Models\\eyeglow");
      this.solidSkin = this.content.Load<Effect>("effects\\SolidSkinEffect");
      this.solidSkin.Parameters["World"].SetValue(Matrix.CreateTranslation(0.0f, 0.0f, 0.0f));
      this.glowEffect = this.content.Load<Effect>("effects\\glowEffect2");
      this.glowEffect.CurrentTechnique = this.glowEffect.Techniques["EdgeDetect"];
      float num1 = 30f;
      Vector2[] vector2Array = new Vector2[12];
      for (int index = 0; index < 12; ++index)
      {
        float num2 = (float) -index;
        vector2Array[index] = new Vector2((float) Math.Sin((double) MathHelper.ToRadians(num2 * num1)), -1.4f * (float) Math.Cos((double) MathHelper.ToRadians((float) (180.0 + (double) num2 * (double) num1))));
      }
      this.glowEffect.Parameters["offsets"].SetValue(vector2Array);
      this.glowEffect.Parameters["glowdist"].SetValue(0.005f);
      if (this.myType == 0 || this.myType == 3 || this.myType == 4 || this.myType == 5)
        this.sparks = (ParticleSystem) new shockSystem(sc.Game, this.contentB);
      if (this.myType == 1)
        this.sparks = (ParticleSystem) new shock2System(sc.Game, this.contentB);
      if (this.myType == 2)
        this.sparks = (ParticleSystem) new shock3System(sc.Game, this.contentB);
      if (this.myType == 6)
        this.sparks = (ParticleSystem) new shock3System(sc.Game, this.contentB);
      if (this.myType == 7)
        this.sparks = (ParticleSystem) new shock4System(sc.Game, this.contentB);
      if (this.myType == 11)
        this.sparks = (ParticleSystem) new shock5System(sc.Game, this.contentB);
      if (this.myType == 12)
        this.sparks = (ParticleSystem) new shock5System(sc.Game, this.contentB);
      if (this.myType == 13)
        this.sparks = (ParticleSystem) new shock4System(sc.Game, this.contentB);
      if (this.myType == 14)
        this.sparks = (ParticleSystem) new shock4System(sc.Game, this.contentB);
      this.sparks.Initialize();
      this.sparks.LoadContent(sc.GraphicsDevice);
      this.dots = (ParticleSystem) new dotSystem(sc.Game, this.contentB);
      this.dots.Initialize();
      this.dots.LoadContent(sc.GraphicsDevice);
      Model model = this.contentB.Load<Model>("Models//block1");
      if (this.myType == 3)
      {
        this.eyeTexture1 = this.contentB.Load<Texture2D>("texture\\eyeglow1");
        this.eyeEffect = this.contentB.Load<Effect>("effects\\eyeEffect");
        this.eyeEffect.Parameters["Texture"].SetValue((Texture) this.eyeTexture1);
        this.pigTexture = this.contentB.Load<Texture2D>("npc\\vepr1");
        model = this.contentB.Load<Model>("Models//block1");
      }
      if (this.myType == 0)
      {
        this.eyeTexture1 = this.contentB.Load<Texture2D>("texture\\eyeglow5");
        this.eyeEffect = this.contentB.Load<Effect>("effects\\eyeEffect");
        this.eyeEffect.Parameters["Texture"].SetValue((Texture) this.eyeTexture1);
        this.pigTexture = this.contentB.Load<Texture2D>("npc\\vepr1Blue");
        model = this.contentB.Load<Model>("Models//blockBlu");
      }
      if (this.myType == 1)
      {
        this.eyeTexture2 = this.contentB.Load<Texture2D>("texture\\eyeglow3");
        this.eyeEffect = this.contentB.Load<Effect>("effects\\eyeEffect");
        this.eyeEffect.Parameters["Texture"].SetValue((Texture) this.eyeTexture2);
        this.pigTexture = this.contentB.Load<Texture2D>("npc\\vepr1Grn2");
        model = this.contentB.Load<Model>("Models//blockGrn2");
      }
      if (this.myType == 2)
      {
        this.eyeTexture2 = this.contentB.Load<Texture2D>("texture\\eyeglow3");
        this.eyeEffect = this.contentB.Load<Effect>("effects\\eyeEffect");
        this.eyeEffect.Parameters["Texture"].SetValue((Texture) this.eyeTexture2);
        this.pigTexture = this.contentB.Load<Texture2D>("npc\\vepr1Grn");
        model = this.contentB.Load<Model>("Models//blockGrn");
      }
      if (this.myType == 13)
      {
        this.eyeTexture1 = this.contentB.Load<Texture2D>("texture\\eyeglow2");
        this.eyeEffect = this.contentB.Load<Effect>("effects\\eyeEffect");
        this.eyeEffect.Parameters["Texture"].SetValue((Texture) this.eyeTexture1);
        this.pigTexture = this.contentB.Load<Texture2D>("npc\\vepr1Red2");
        model = this.contentB.Load<Model>("Models//blockRed");
      }
      if (this.myType == 14)
      {
        this.eyeTexture2 = this.contentB.Load<Texture2D>("texture\\eyeglow2");
        this.eyeEffect = this.contentB.Load<Effect>("effects\\eyeEffect");
        this.eyeEffect.Parameters["Texture"].SetValue((Texture) this.eyeTexture2);
        this.pigTexture = this.contentB.Load<Texture2D>("npc\\vepr1Red");
        model = this.contentB.Load<Model>("Models//blockRed");
      }
      if (this.myType == 4 || this.myType == 5)
      {
        this.eyeTexture2 = this.contentB.Load<Texture2D>("texture\\eyeglow5");
        this.eyeEffect = this.contentB.Load<Effect>("effects\\eyeEffect");
        this.eyeEffect.Parameters["Texture"].SetValue((Texture) this.eyeTexture2);
        this.pigTexture = this.contentB.Load<Texture2D>("npc\\vepr1Gray");
        model = this.contentB.Load<Model>("Models//blockGray");
      }
      if (this.myType == 6)
      {
        this.eyeTexture2 = this.contentB.Load<Texture2D>("texture\\eyeglow6");
        this.eyeEffect = this.contentB.Load<Effect>("effects\\eyeEffect");
        this.eyeEffect.Parameters["Texture"].SetValue((Texture) this.eyeTexture2);
        this.pigTexture = this.contentB.Load<Texture2D>("npc\\veprBrown2");
        model = this.contentB.Load<Model>("Models//block1");
      }
      if (this.myType == 7)
      {
        this.eyeTexture1 = this.contentB.Load<Texture2D>("texture\\eyeglow6");
        this.eyeEffect = this.contentB.Load<Effect>("effects\\eyeEffect");
        this.eyeEffect.Parameters["Texture"].SetValue((Texture) this.eyeTexture1);
        this.pigTexture = this.contentB.Load<Texture2D>("npc\\vepr1");
        model = this.contentB.Load<Model>("Models//block1");
      }
      if (this.myType == 11)
      {
        this.eyeTexture1 = this.contentB.Load<Texture2D>("texture\\eyeglow12");
        this.eyeEffect = this.contentB.Load<Effect>("effects\\eyeEffect");
        this.eyeEffect.Parameters["Texture"].SetValue((Texture) this.eyeTexture1);
        this.pigTexture = this.contentB.Load<Texture2D>("npc\\veprWhite");
        model = this.contentB.Load<Model>("Models//block1");
      }
      if (this.myType == 12)
      {
        this.eyeTexture1 = this.contentB.Load<Texture2D>("texture\\eyeglow12");
        this.eyeEffect = this.contentB.Load<Effect>("effects\\eyeEffect");
        this.eyeEffect.Parameters["Texture"].SetValue((Texture) this.eyeTexture1);
        this.pigTexture = this.contentB.Load<Texture2D>("npc\\veprWhite");
        model = this.contentB.Load<Model>("Models//block1");
      }
      SkinningData tag = this.pigModel.Tag as SkinningData;
      this.pig1 = new AnimationPlayer[7];
      this.pig1[0] = new AnimationPlayer(tag);
      this.pig1[0].StartClip(tag.AnimationClips["cuttyrun"]);
      this.pig1[1] = new AnimationPlayer(tag);
      this.pig1[1].StartClip(tag.AnimationClips["cuttywalk"]);
      this.pig1[2] = new AnimationPlayer(tag);
      this.pig1[2].StartClip(tag.AnimationClips["cuttywait"]);
      this.pig1[3] = new AnimationPlayer(tag);
      this.pig1[3].StartClip(tag.AnimationClips["cuttybite"]);
      this.pig1[4] = new AnimationPlayer(tag);
      this.pig1[4].StartClip(tag.AnimationClips["cuttydie"]);
      this.pig1[5] = new AnimationPlayer(tag);
      this.pig1[5].StartClip(tag.AnimationClips["cuttyjump"]);
      this.pig1[6] = new AnimationPlayer(tag);
      this.pig1[6].StartClip(tag.AnimationClips["cuttyheal"]);
      this.a = this.pig1[0];
      this.b = this.pig1[0];
      this.clipIndexA = 0;
      this.clipRate = new float[7];
      this.clipRate[0] = 7f;
      this.clipRate[1] = 2f;
      this.clipRate[2] = 0.0f;
      this.clipRate[3] = 0.0f;
      this.clipRate[4] = 0.0f;
      this.clipRate[5] = 0.0f;
      this.clipRate[6] = 0.0f;
      this.pigJaw = new float[2200];
      this.pigSkin = this.contentB.Load<Effect>("effects/cuttySkin2");
      this.pigSkin.Parameters["World"].SetValue(Matrix.CreateTranslation(0.0f, 0.0f, 0.0f));
      this.pigSkin.Parameters["Texture"].SetValue((Texture) this.pigTexture);
      this.fireball = new Cutty.hole();
      this.fireball.stainR = new Vector4[80];
      this.fireball.stainR[0] = new Vector4(0.0f, 0.0f, 133f, 200f);
      this.fireball.stainR[1] = new Vector4(798f, 0.0f, 133f, 200f);
      this.fireball.stainR[2] = new Vector4(532f, 400f, 133f, 200f);
      this.fireball.stainR[3] = new Vector4(665f, 800f, 133f, 200f);
      this.fireball.stainR[4] = new Vector4(1064f, 400f, 133f, 200f);
      this.fireball.stainR[5] = new Vector4(1197f, 600f, 133f, 200f);
      this.fireball.stainR[6] = new Vector4(1463f, 800f, 133f, 200f);
      this.fireball.stainR[7] = new Vector4(931f, 1000f, 133f, 200f);
      this.fireball.stainR[8] = new Vector4(1197f, 1000f, 133f, 200f);
      this.fireball.stainR[9] = new Vector4(133f, 0.0f, 133f, 200f);
      this.fireball.stainR[10] = new Vector4(266f, 0.0f, 133f, 200f);
      this.fireball.stainR[11] = new Vector4(0.0f, 200f, 133f, 200f);
      this.fireball.stainR[12] = new Vector4(133f, 200f, 133f, 200f);
      this.fireball.stainR[13] = new Vector4(266f, 200f, 133f, 200f);
      this.fireball.stainR[14] = new Vector4(399f, 0.0f, 133f, 200f);
      this.fireball.stainR[15] = new Vector4(532f, 0.0f, 133f, 200f);
      this.fireball.stainR[16] = new Vector4(399f, 200f, 133f, 200f);
      this.fireball.stainR[17] = new Vector4(665f, 0.0f, 133f, 200f);
      this.fireball.stainR[18] = new Vector4(532f, 200f, 133f, 200f);
      this.fireball.stainR[19] = new Vector4(665f, 200f, 133f, 200f);
      this.fireball.stainR[20] = new Vector4(798f, 200f, 133f, 200f);
      this.fireball.stainR[21] = new Vector4(0.0f, 400f, 133f, 200f);
      this.fireball.stainR[22] = new Vector4(133f, 400f, 133f, 200f);
      this.fireball.stainR[23] = new Vector4(0.0f, 600f, 133f, 200f);
      this.fireball.stainR[24] = new Vector4(266f, 400f, 133f, 200f);
      this.fireball.stainR[25] = new Vector4(133f, 600f, 133f, 200f);
      this.fireball.stainR[26] = new Vector4(399f, 400f, 133f, 200f);
      this.fireball.stainR[27] = new Vector4(0.0f, 800f, 133f, 200f);
      this.fireball.stainR[28] = new Vector4(266f, 600f, 133f, 200f);
      this.fireball.stainR[29] = new Vector4(133f, 800f, 133f, 200f);
      this.fireball.stainR[30] = new Vector4(399f, 600f, 133f, 200f);
      this.fireball.stainR[31] = new Vector4(665f, 400f, 133f, 200f);
      this.fireball.stainR[32] = new Vector4(266f, 800f, 133f, 200f);
      this.fireball.stainR[33] = new Vector4(532f, 600f, 133f, 200f);
      this.fireball.stainR[34] = new Vector4(798f, 400f, 133f, 200f);
      this.fireball.stainR[35] = new Vector4(399f, 800f, 133f, 200f);
      this.fireball.stainR[36] = new Vector4(665f, 600f, 133f, 200f);
      this.fireball.stainR[37] = new Vector4(532f, 800f, 133f, 200f);
      this.fireball.stainR[38] = new Vector4(798f, 600f, 133f, 200f);
      this.fireball.stainR[39] = new Vector4(798f, 800f, 133f, 200f);
      this.fireball.stainR[40] = new Vector4(931f, 0.0f, 133f, 200f);
      this.fireball.stainR[41] = new Vector4(1064f, 0.0f, 133f, 200f);
      this.fireball.stainR[42] = new Vector4(931f, 200f, 133f, 200f);
      this.fireball.stainR[43] = new Vector4(1197f, 0.0f, 133f, 200f);
      this.fireball.stainR[44] = new Vector4(1064f, 200f, 133f, 200f);
      this.fireball.stainR[45] = new Vector4(1330f, 0.0f, 133f, 200f);
      this.fireball.stainR[46] = new Vector4(931f, 400f, 133f, 200f);
      this.fireball.stainR[47] = new Vector4(1197f, 200f, 133f, 200f);
      this.fireball.stainR[48] = new Vector4(1463f, 0.0f, 133f, 200f);
      this.fireball.stainR[49] = new Vector4(1330f, 200f, 133f, 200f);
      this.fireball.stainR[50] = new Vector4(931f, 600f, 133f, 200f);
      this.fireball.stainR[51] = new Vector4(1596f, 0.0f, 133f, 200f);
      this.fireball.stainR[52] = new Vector4(1197f, 400f, 133f, 200f);
      this.fireball.stainR[53] = new Vector4(1463f, 200f, 133f, 200f);
      this.fireball.stainR[54] = new Vector4(1064f, 600f, 133f, 200f);
      this.fireball.stainR[55] = new Vector4(1729f, 0.0f, 133f, 200f);
      this.fireball.stainR[56] = new Vector4(1330f, 400f, 133f, 200f);
      this.fireball.stainR[57] = new Vector4(931f, 800f, 133f, 200f);
      this.fireball.stainR[58] = new Vector4(1596f, 200f, 133f, 200f);
      this.fireball.stainR[59] = new Vector4(1463f, 400f, 133f, 200f);
      this.fireball.stainR[60] = new Vector4(1064f, 800f, 133f, 200f);
      this.fireball.stainR[61] = new Vector4(1729f, 200f, 133f, 200f);
      this.fireball.stainR[62] = new Vector4(1330f, 600f, 133f, 200f);
      this.fireball.stainR[63] = new Vector4(1596f, 400f, 133f, 200f);
      this.fireball.stainR[64] = new Vector4(1197f, 800f, 133f, 200f);
      this.fireball.stainR[65] = new Vector4(1463f, 600f, 133f, 200f);
      this.fireball.stainR[66] = new Vector4(1729f, 400f, 133f, 200f);
      this.fireball.stainR[67] = new Vector4(1330f, 800f, 133f, 200f);
      this.fireball.stainR[68] = new Vector4(1596f, 600f, 133f, 200f);
      this.fireball.stainR[69] = new Vector4(1729f, 600f, 133f, 200f);
      this.fireball.stainR[70] = new Vector4(1596f, 800f, 133f, 200f);
      this.fireball.stainR[71] = new Vector4(1729f, 800f, 133f, 200f);
      this.fireball.stainR[72] = new Vector4(0.0f, 1000f, 133f, 200f);
      this.fireball.stainR[73] = new Vector4(133f, 1000f, 133f, 200f);
      this.fireball.stainR[74] = new Vector4(266f, 1000f, 133f, 200f);
      this.fireball.stainR[75] = new Vector4(399f, 1000f, 133f, 200f);
      this.fireball.stainR[76] = new Vector4(532f, 1000f, 133f, 200f);
      this.fireball.stainR[77] = new Vector4(665f, 1000f, 133f, 200f);
      this.fireball.stainR[78] = new Vector4(798f, 1000f, 133f, 200f);
      this.fireball.stainR[79] = new Vector4(1064f, 1000f, 133f, 200f);
      this.fireball.stainMax = 0;
      this.fireball.stainIndex = 0;
      this.fireball.stainCapacity = 65;
      this.fireball.location = new Vector3[this.fireball.stainCapacity];
      this.fireball.bone = new int[this.fireball.stainCapacity];
      this.fireball.fade = new float[this.fireball.stainCapacity];
      this.fireball.frame = new int[this.fireball.stainCapacity];
      this.fireball.scale = new Matrix[this.fireball.stainCapacity];
      this.fireball.stainTrans = new Cutty.hitStream[this.fireball.stainCapacity];
      this.fireball.stainBuffer = new DynamicVertexBuffer(sc.GraphicsDevice, Cutty.vd2, this.fireball.stainCapacity, BufferUsage.WriteOnly);
      this.col_Bone = new int[8]
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
      this.col_Scale[0] = 96.39428f;
      this.col_Pos[0] = new Vector3(-1.16955519f, 92.69917f, 23.2543983f);
      this.col_Scale[1] = 66.92236f;
      this.col_Pos[1] = new Vector3(-2.6943295f, 89.26898f, 132.9659f);
      this.col_Scale[2] = 46.0443535f;
      this.col_Pos[2] = new Vector3(-2.69420433f, 54.365963f, 213.434036f);
      this.col_Scale[3] = 59.3749123f;
      this.col_Pos[3] = new Vector3(-1.16970563f, 68.89146f, -86.95499f);
      this.col_Scale[4] = 35.39259f;
      this.col_Pos[4] = new Vector3(43.993885f, -7.37780046f, 83.83201f);
      this.col_Scale[5] = 35.39259f;
      this.col_Pos[5] = new Vector3(-47.84444f, -5.906173f, 80.97031f);
      this.col_Scale[6] = 30.3925915f;
      this.col_Pos[6] = new Vector3(34.47692f, -9.459024f, -102.138618f);
      this.col_Scale[7] = 30.3925915f;
      this.col_Pos[7] = new Vector3(-36.9297371f, -9.249221f, -103.242676f);
      this.targetDist = new float[7];
      this.targetX = new Curve[7];
      this.targetZ = new Curve[7];
      for (int index1 = 1; index1 < 7; ++index1)
      {
        CultureInfo invariantCulture = CultureInfo.InvariantCulture;
        StreamReader streamReader = new StreamReader("ABCDE3/target" + (object) index1 + ".txt");
        this.targetDist[index1] = 0.0f;
        this.targetX[index1] = new Curve();
        this.targetZ[index1] = new Curve();
        float x1 = 0.0f;
        float y1 = 0.0f;
        for (int index2 = 0; index2 < 51; ++index2)
        {
          float x2 = x1;
          float y2 = y1;
          x1 = float.Parse(streamReader.ReadLine(), (IFormatProvider) invariantCulture);
          y1 = float.Parse(streamReader.ReadLine(), (IFormatProvider) invariantCulture);
          float position = (float) index2 / 50f;
          this.targetX[index1].Keys.Add(new CurveKey(position, x1 + 3000f));
          this.targetZ[index1].Keys.Add(new CurveKey(position, y1 + 3000f));
          if (index2 > 0)
            this.targetDist[index1] += Vector2.Distance(new Vector2(x2, y2), new Vector2(x1, y1));
        }
        streamReader.Close();
        streamReader.Dispose();
        this.SetTangents(ref this.targetX[index1], ref this.targetZ[index1]);
      }
      this.chunk = new Cutty.shell();
      this.chunk.max = 0;
      this.chunk.type = 0;
      this.chunk.maxCapacity = 300;
      this.chunk.index = 0;
      this.chunk.offset = new Matrix[this.chunk.maxCapacity];
      this.chunk.bone = new int[this.chunk.maxCapacity];
      this.chunk.model = model;
      this.chunk.buffer = new DynamicVertexBuffer(sc.GraphicsDevice, Cutty.instanceDec, this.chunk.maxCapacity, BufferUsage.WriteOnly);
      this.chunk.displayList = new Cutty.instancedObject[this.chunk.maxCapacity];
      this.chunk.dupe = new chunkDupe[this.chunk.maxCapacity];
      for (int i = 0; i < this.chunk.maxCapacity; ++i)
        this.chunk.dupe[i] = new chunkDupe(i);
      this.chunk.stream = new Cutty.instancedObject[this.chunk.maxCapacity];
      this.faceChunk = new Cutty.shell();
      this.faceChunk.max = 0;
      this.faceChunk.type = 0;
      this.faceChunk.maxCapacity = 300;
      this.faceChunk.index = 0;
      this.faceChunk.offset = new Matrix[this.faceChunk.maxCapacity];
      this.faceChunk.bone = new int[this.faceChunk.maxCapacity];
      this.faceChunk.model = model;
      this.faceChunk.buffer = new DynamicVertexBuffer(sc.GraphicsDevice, Cutty.instanceDec, this.faceChunk.maxCapacity, BufferUsage.WriteOnly);
      this.faceChunk.displayList = new Cutty.instancedObject[this.faceChunk.maxCapacity];
      this.faceChunk.dupe = new chunkDupe[this.faceChunk.maxCapacity];
      for (int i = 0; i < this.faceChunk.maxCapacity; ++i)
        this.faceChunk.dupe[i] = new chunkDupe(i);
      this.faceChunk.stream = new Cutty.instancedObject[this.faceChunk.maxCapacity];
      this.assChunk = new Cutty.shell();
      this.assChunk.max = 0;
      this.assChunk.type = 0;
      this.assChunk.maxCapacity = 300;
      this.assChunk.index = 0;
      this.assChunk.offset = new Matrix[this.assChunk.maxCapacity];
      this.assChunk.bone = new int[this.assChunk.maxCapacity];
      this.assChunk.model = model;
      this.assChunk.buffer = new DynamicVertexBuffer(sc.GraphicsDevice, Cutty.instanceDec, this.assChunk.maxCapacity, BufferUsage.WriteOnly);
      this.assChunk.displayList = new Cutty.instancedObject[this.assChunk.maxCapacity];
      this.assChunk.dupe = new chunkDupe[this.assChunk.maxCapacity];
      for (int i = 0; i < this.assChunk.maxCapacity; ++i)
        this.assChunk.dupe[i] = new chunkDupe(i);
      this.assChunk.stream = new Cutty.instancedObject[this.assChunk.maxCapacity];
      Matrix[] matrixArray1 = new Matrix[49]
      {
        Matrix.CreateScale(0.708298f, 0.5569278f, 0.5991605f) * Matrix.CreateRotationX(0.210001826f) * Matrix.CreateRotationY(0.350864947f) * Matrix.CreateRotationZ(-1.0666703f) * Matrix.CreateTranslation(-0.05301531f, 177.234955f, 90.23178f),
        Matrix.CreateScale(0.5166327f, 0.504188538f, 0.5311612f) * Matrix.CreateRotationX(0.007827965f) * Matrix.CreateRotationY(-0.396429867f) * Matrix.CreateRotationZ(1.39527345f) * Matrix.CreateTranslation(-3.18023562f, 186.392883f, 87.43123f),
        Matrix.CreateScale(0.7999118f, 0.854440868f, 0.893641651f) * Matrix.CreateRotationX(0.135744408f) * Matrix.CreateRotationY(0.159144729f) * Matrix.CreateRotationZ(-1.2454927f) * Matrix.CreateTranslation(-3.22693253f, 188.273346f, 79.07738f),
        Matrix.CreateScale(0.5828592f, 0.5635248f, 0.782946646f) * Matrix.CreateRotationX(0.008781614f) * Matrix.CreateRotationY(-0.266933f) * Matrix.CreateRotationZ(1.40754712f) * Matrix.CreateTranslation(-3.1469f, 192.516541f, 71.58341f),
        Matrix.CreateScale(0.6400639f, 0.2944064f, 0.4616332f) * Matrix.CreateRotationX(0.0393642075f) * Matrix.CreateRotationY(-0.0404948369f) * Matrix.CreateRotationZ(0.434354037f) * Matrix.CreateTranslation(-10.1998682f, 183.827026f, 70.40799f),
        Matrix.CreateScale(0.398329139f, 0.227493867f, 0.4011678f) * Matrix.CreateRotationX(0.0393642075f) * Matrix.CreateRotationY(-0.0404948369f) * Matrix.CreateRotationZ(0.434354037f) * Matrix.CreateTranslation(-25.4598751f, 177.1684f, 67.78193f),
        Matrix.CreateScale(0.7384201f, 0.501945555f, 0.950838f) * Matrix.CreateRotationX(-0.244941846f) * Matrix.CreateRotationY(0.3924641f) * Matrix.CreateRotationZ(0.298894346f) * Matrix.CreateTranslation(-39.0057564f, 164.4879f, 57.19427f),
        Matrix.CreateScale(0.6400639f, 0.2944064f, 0.4616332f) * Matrix.CreateRotationX(-0.208394274f) * Matrix.CreateRotationY(-0.0404948369f) * Matrix.CreateRotationZ(0.434354037f) * Matrix.CreateTranslation(-19.7044086f, 177.29863f, 58.7457428f),
        Matrix.CreateScale(0.5828592f, 0.5635248f, 0.782946646f) * Matrix.CreateRotationX(-0.121878006f) * Matrix.CreateRotationY(0.110657275f) * Matrix.CreateRotationZ(1.40260565f) * Matrix.CreateTranslation(-3.38951755f, 192.446533f, 50.8092842f),
        Matrix.CreateScale(0.7999118f, 0.854440868f, 0.893641651f) * Matrix.CreateRotationX(0.09980399f) * Matrix.CreateRotationY(-0.0332119465f) * Matrix.CreateRotationZ(-1.08304024f) * Matrix.CreateTranslation(-0.404371f, 190.257813f, 59.0849762f),
        Matrix.CreateScale(1.01548469f, 0.8137221f, 1.30760431f) * Matrix.CreateRotationX(0.03200087f) * Matrix.CreateRotationY(0.0452531762f) * Matrix.CreateRotationZ(-0.04561152f) * Matrix.CreateTranslation(8.424231f, 174.60968f, 61.6679077f),
        Matrix.CreateScale(1.01548469f, 0.606994569f, 0.674365342f) * Matrix.CreateRotationX(0.0071849837f) * Matrix.CreateRotationY(0.3197445f) * Matrix.CreateRotationZ(-0.4001006f) * Matrix.CreateTranslation(24.9945717f, 172.323318f, 65.43521f),
        Matrix.CreateScale(1.01548469f, 0.9243026f, 1.30760431f) * Matrix.CreateRotationX(-0.361647636f) * Matrix.CreateRotationY(-0.08340433f) * Matrix.CreateRotationZ(-0.472222179f) * Matrix.CreateTranslation(26.2364254f, 162.808609f, 41.711525f),
        Matrix.CreateScale(0.9093862f, 0.8277309f, 1.170985f) * Matrix.CreateRotationX(-0.0441903137f) * Matrix.CreateRotationY(-0.326836765f) * Matrix.CreateRotationZ(-1.29423726f) * Matrix.CreateTranslation(-0.960771441f, 186.283417f, 41.9409752f),
        Matrix.CreateScale(1.01548469f, 0.9243026f, 1.30760431f) * Matrix.CreateRotationX(-0.301399261f) * Matrix.CreateRotationY(-0.00288940337f) * Matrix.CreateRotationZ(-0.10339836f) * Matrix.CreateTranslation(5.90479326f, 167.077f, 27.9189548f),
        Matrix.CreateScale(0.6539163f, 0.6488131f, 0.782946646f) * Matrix.CreateRotationX(-0.07386185f) * Matrix.CreateRotationY(0.3200513f) * Matrix.CreateRotationZ(1.42399287f) * Matrix.CreateTranslation(-0.220458955f, 188.099136f, 29.3506241f),
        Matrix.CreateScale(0.5240074f, 0.2944064f, 0.4616332f) * Matrix.CreateRotationX(-1.16808128f) * Matrix.CreateRotationY(-1.2621994f) * Matrix.CreateRotationZ(1.51201165f) * Matrix.CreateTranslation(-10.1376371f, 179.634033f, 50.76101f),
        Matrix.CreateScale(0.6400639f, 0.2944064f, 0.4616332f) * Matrix.CreateRotationX(-0.320274323f) * Matrix.CreateRotationY(-0.0404948369f) * Matrix.CreateRotationZ(0.434354037f) * Matrix.CreateTranslation(-21.2009182f, 173.672623f, 49.196167f),
        Matrix.CreateScale(0.6400639f, 0.2944064f, 0.283513516f) * Matrix.CreateRotationX(-0.320274323f) * Matrix.CreateRotationY(-0.0404948369f) * Matrix.CreateRotationZ(0.434354037f) * Matrix.CreateTranslation(-13.32279f, 176.576035f, 42.04959f),
        Matrix.CreateScale(0.6400639f, 0.2944064f, 0.4616332f) * Matrix.CreateRotationX(-1.55453336f) * Matrix.CreateRotationY(-1.25074983f) * Matrix.CreateRotationZ(1.97459006f) * Matrix.CreateTranslation(-27.2986584f, 168.950546f, 38.27991f),
        Matrix.CreateScale(0.5240074f, 0.2944064f, 0.4616332f) * Matrix.CreateRotationX(-1.2617631f) * Matrix.CreateRotationY(-1.1686635f) * Matrix.CreateRotationZ(1.6118176f) * Matrix.CreateTranslation(-14.7136383f, 172.310547f, 31.7761459f),
        Matrix.CreateScale(0.9093862f, 0.8277309f, 1.170985f) * Matrix.CreateRotationX(-0.0450054854f) * Matrix.CreateRotationY(-0.37660113f) * Matrix.CreateRotationZ(-1.29187179f) * Matrix.CreateTranslation(-0.0543337837f, 179.605057f, 19.5561619f),
        Matrix.CreateScale(0.506629765f, 0.2944064f, 0.283513516f) * Matrix.CreateRotationX(-0.315507531f) * Matrix.CreateRotationY(-0.06909058f) * Matrix.CreateRotationZ(0.3473774f) * Matrix.CreateTranslation(-9.074999f, 169.204712f, 20.59569f),
        Matrix.CreateScale(0.453718f, 0.2944064f, 0.6959109f) * Matrix.CreateRotationX(-0.3212951f) * Matrix.CreateRotationY(0.0881740749f) * Matrix.CreateRotationZ(0.391626269f) * Matrix.CreateTranslation(-23.6329918f, 164.3047f, 20.9647f),
        Matrix.CreateScale(0.826378644f, 0.561735868f, 1.06409907f) * Matrix.CreateRotationX(-0.236512735f) * Matrix.CreateRotationY(0.1308642f) * Matrix.CreateRotationZ(0.552830756f) * Matrix.CreateTranslation(-39.8892555f, 155.209579f, 31.0455952f),
        Matrix.CreateScale(1.01548469f, 0.9243026f, 1.30760431f) * Matrix.CreateRotationX(-0.373832643f) * Matrix.CreateRotationY(0.111237563f) * Matrix.CreateRotationZ(-0.634495854f) * Matrix.CreateTranslation(23.5781612f, 150.726929f, 16.186039f),
        Matrix.CreateScale(0.6400639f, 0.2944064f, 0.4616332f) * Matrix.CreateRotationX(-1.911975f) * Matrix.CreateRotationY(-1.05743444f) * Matrix.CreateRotationZ(2.49148846f) * Matrix.CreateTranslation(-39.8147125f, 150.03421f, 8.667492f),
        Matrix.CreateScale(0.5333285f, 0.362533242f, 0.799655557f) * Matrix.CreateRotationX(-0.37774083f) * Matrix.CreateRotationY(0.02756262f) * Matrix.CreateRotationZ(0.3302053f) * Matrix.CreateTranslation(-28.23632f, 155.483917f, 7.453938f),
        Matrix.CreateScale(0.453718f, 0.2944064f, 0.6959109f) * Matrix.CreateRotationX(-0.3212951f) * Matrix.CreateRotationY(0.0881740749f) * Matrix.CreateRotationZ(0.391626269f) * Matrix.CreateTranslation(-13.2754126f, 161.798019f, 9.130991f),
        Matrix.CreateScale(0.6539163f, 0.6488131f, 0.782946646f) * Matrix.CreateRotationX(-0.07995875f) * Matrix.CreateRotationY(0.5012596f) * Matrix.CreateRotationZ(1.40878332f) * Matrix.CreateTranslation(-0.00209249835f, 178.286972f, 8.222643f),
        Matrix.CreateScale(0.716868937f, 0.8277309f, 0.9487003f) * Matrix.CreateRotationX(-0.166182f) * Matrix.CreateRotationY(-0.455487341f) * Matrix.CreateRotationZ(-1.28856039f) * Matrix.CreateTranslation(-0.7827156f, 173.972458f, 1.36446822f),
        Matrix.CreateScale(0.8365833f, 0.5147443f, 1.07723927f) * Matrix.CreateRotationX(-0.317229629f) * Matrix.CreateRotationY(0.0121787675f) * Matrix.CreateRotationZ(-0.016896978f) * Matrix.CreateTranslation(1.67415059f, 155.5527f, -4.36086845f),
        Matrix.CreateScale(0.8497695f, 0.773467243f, 1.09421861f) * Matrix.CreateRotationX(-0.473985523f) * Matrix.CreateRotationY(0.308521658f) * Matrix.CreateRotationZ(-0.6299423f) * Matrix.CreateTranslation(12.5180826f, 144.5464f, -13.7990408f),
        Matrix.CreateScale(0.6539163f, 0.6488131f, 0.782946646f) * Matrix.CreateRotationX(-0.07995875f) * Matrix.CreateRotationY(0.5012596f) * Matrix.CreateRotationZ(1.40878332f) * Matrix.CreateTranslation(-0.1792772f, 167.4633f, -9.034153f),
        Matrix.CreateScale(0.6539163f, 0.7550428f, 0.6800631f) * Matrix.CreateRotationX(-0.170430392f) * Matrix.CreateRotationY(-0.455487341f) * Matrix.CreateRotationZ(-1.28856039f) * Matrix.CreateTranslation(-0.465390861f, 163.920563f, -15.0605841f),
        Matrix.CreateScale(0.42149806f, 0.286515862f, 0.542748451f) * Matrix.CreateRotationX(-0.46243003f) * Matrix.CreateRotationY(-0.344241738f) * Matrix.CreateRotationZ(0.687391043f) * Matrix.CreateTranslation(-31.1383877f, 147.327515f, -5.527931f),
        Matrix.CreateScale(0.585995138f, 0.352430344f, 0.808732152f) * Matrix.CreateRotationX(-0.37774083f) * Matrix.CreateRotationY(0.02756262f) * Matrix.CreateRotationZ(0.3302053f) * Matrix.CreateTranslation(-16.01753f, 154.601791f, -6.506987f),
        Matrix.CreateScale(0.4695873f, 0.3192048f, 0.6046713f) * Matrix.CreateRotationX(-0.3445082f) * Matrix.CreateRotationY(-0.3912871f) * Matrix.CreateRotationZ(0.5804604f) * Matrix.CreateTranslation(-21.7727623f, 146.240845f, -17.66944f),
        Matrix.CreateScale(0.6539163f, 0.711675942f, 0.8653891f) * Matrix.CreateRotationX(0.0636596754f) * Matrix.CreateRotationY(0.5069416f) * Matrix.CreateRotationZ(1.55040884f) * Matrix.CreateTranslation(1.66710532f, 155.398422f, -25.4411983f),
        Matrix.CreateScale(0.4695873f, 0.3192048f, 0.6046713f) * Matrix.CreateRotationX(-0.514081061f) * Matrix.CreateRotationY(-0.7301555f) * Matrix.CreateRotationZ(0.8454387f) * Matrix.CreateTranslation(-11.2505932f, 145.335861f, -29.37115f),
        Matrix.CreateScale(0.4695873f, 0.3192048f, 0.6046713f) * Matrix.CreateRotationX(-0.381167471f) * Matrix.CreateRotationY(0.2682071f) * Matrix.CreateRotationZ(0.236839339f) * Matrix.CreateTranslation(-6.37350559f, 151.780411f, -20.7738914f),
        Matrix.CreateScale(0.6539163f, 0.7550428f, 0.8653891f) * Matrix.CreateRotationX(-0.170430392f) * Matrix.CreateRotationY(-0.455487341f) * Matrix.CreateRotationZ(-1.28856039f) * Matrix.CreateTranslation(-0.335520476f, 155.774f, -25.0831718f),
        Matrix.CreateScale(0.452369869f, 0.479965329f, 0.429500252f) * Matrix.CreateRotationX(-0.170430392f) * Matrix.CreateRotationY(-0.455487341f) * Matrix.CreateRotationZ(-1.28856039f) * Matrix.CreateTranslation(0.27977854f, 149.418976f, -42.1035728f),
        Matrix.CreateScale(0.427036077f, 0.635751843f, 0.5851349f) * Matrix.CreateRotationX(0.06155733f) * Matrix.CreateRotationY(0.4416417f) * Matrix.CreateRotationZ(1.54580808f) * Matrix.CreateTranslation(1.27316427f, 149.7724f, -40.8866959f),
        Matrix.CreateScale(0.427036077f, 0.635751843f, 0.5851349f) * Matrix.CreateRotationX(-0.0670146048f) * Matrix.CreateRotationY(0.4416417f) * Matrix.CreateRotationZ(1.54580808f) * Matrix.CreateTranslation(0.7915f, 143.365967f, -54.4582672f),
        Matrix.CreateScale(0.452369869f, 0.3768922f, 0.429500252f) * Matrix.CreateRotationX(-0.170430392f) * Matrix.CreateRotationY(-0.455487341f) * Matrix.CreateRotationZ(-1.28856039f) * Matrix.CreateTranslation(-0.15296115f, 143.779968f, -52.36023f),
        Matrix.CreateScale(0.452369869f, 0.3768922f, 0.429500252f) * Matrix.CreateRotationX(-0.170430392f) * Matrix.CreateRotationY(-0.455487341f) * Matrix.CreateRotationZ(-1.28856039f) * Matrix.CreateTranslation(-0.524064958f, 138.77298f, -61.38392f),
        Matrix.CreateScale(0.315640539f, 0.531923354f, 0.4712606f) * Matrix.CreateRotationX(-0.05475918f) * Matrix.CreateRotationY(0.4416417f) * Matrix.CreateRotationZ(1.54580808f) * Matrix.CreateTranslation(0.6470251f, 136.9542f, -68.02329f),
        Matrix.CreateScale(0.35304898f, 0.3768922f, 0.3485293f) * Matrix.CreateRotationX(-0.170430392f) * Matrix.CreateRotationY(-0.455487341f) * Matrix.CreateRotationZ(-1.28856039f) * Matrix.CreateTranslation(-1.27455974f, 135.538681f, -70.456604f)
      };
      for (int index = 0; index < 49; ++index)
        this.dropChunk(ref this.chunk, matrixArray1[index], 5);
      Matrix[] matrixArray2 = new Matrix[38]
      {
        Matrix.CreateScale(0.5413472f, 0.428533882f, 0.443344f) * Matrix.CreateRotationX(6.538176f) * Matrix.CreateRotationY(0.227865145f) * Matrix.CreateRotationZ(-1.54301238f) * Matrix.CreateTranslation(30.5146618f, 66.49369f, 184.6844f),
        Matrix.CreateScale(0.5413472f, 0.428533882f, 0.443344f) * Matrix.CreateRotationX(2.903015f) * Matrix.CreateRotationY(0.115094252f) * Matrix.CreateRotationZ(-1.63353825f) * Matrix.CreateTranslation(-36.2899933f, 65.29824f, 178.943954f),
        Matrix.CreateScale(0.471658379f, 0.373367757f, 0.460461229f) * Matrix.CreateRotationX(0.2564029f) * Matrix.CreateRotationY(-0.5665432f) * Matrix.CreateRotationZ(1.14696729f) * Matrix.CreateTranslation(-34.4148178f, 76.2559052f, 187.206375f),
        Matrix.CreateScale(1f, 0.5922924f, 1f) * Matrix.CreateRotationX(0.523964047f) * Matrix.CreateRotationY(-0.009579088f) * Matrix.CreateRotationZ(0.0004069961f) * Matrix.CreateTranslation(-4.378996f, 87.8164749f, 205.46991f),
        Matrix.CreateScale(0.637417555f, 0.5045838f, 0.6222853f) * Matrix.CreateRotationX(0.5618843f) * Matrix.CreateRotationY(0.4032182f) * Matrix.CreateRotationZ(-0.744089663f) * Matrix.CreateTranslation(15.5232553f, 86.96487f, 193.86084f),
        Matrix.CreateScale(0.6704292f, 0.428533882f, 0.443344f) * Matrix.CreateRotationX(7.03257036f) * Matrix.CreateRotationY(-1.13666868f) * Matrix.CreateRotationZ(-2.08344436f) * Matrix.CreateTranslation(26.5555153f, 78.0055847f, 189.313156f),
        Matrix.CreateScale(0.748215854f, 0.5922924f, 0.730453253f) * Matrix.CreateRotationX(2.58458328f) * Matrix.CreateRotationY(0.2716956f) * Matrix.CreateRotationZ(-2.22028637f) * Matrix.CreateTranslation(-22.5194111f, 83.2368851f, 197.554611f),
        Matrix.CreateScale(0.6223866f, 0.492685169f, 0.6076112f) * Matrix.CreateRotationX(3.04469419f) * Matrix.CreateRotationY(0.222687855f) * Matrix.CreateRotationZ(-1.69340968f) * Matrix.CreateTranslation(-31.7268333f, 65.11813f, 191.838226f),
        Matrix.CreateScale(0.748215854f, 0.5922924f, 0.730453253f) * Matrix.CreateRotationX(2.821042f) * Matrix.CreateRotationY(0.349551141f) * Matrix.CreateRotationZ(-2.074376f) * Matrix.CreateTranslation(-19.7606258f, 76.6856f, 208.95462f),
        Matrix.CreateScale(0.5413472f, 0.428533882f, 0.443344f) * Matrix.CreateRotationX(2.903015f) * Matrix.CreateRotationY(0.115094252f) * Matrix.CreateRotationZ(-1.63353825f) * Matrix.CreateTranslation(-28.8427868f, 60.8439178f, 204.713776f),
        Matrix.CreateScale(0.490003526f, 0.387889922f, 0.401295364f) * Matrix.CreateRotationX(6.61058331f) * Matrix.CreateRotationY(0.104882136f) * Matrix.CreateRotationZ(-1.45599627f) * Matrix.CreateTranslation(24.0452118f, 63.5904961f, 203.826141f),
        Matrix.CreateScale(0.748215854f, 0.5922924f, 0.730453253f) * Matrix.CreateRotationX(2.85735035f) * Matrix.CreateRotationY(-0.1884174f) * Matrix.CreateRotationZ(-4.12765026f) * Matrix.CreateTranslation(13.5913582f, 78.1093445f, 208.540573f),
        Matrix.CreateScale(0.748215854f, 0.5922924f, 0.730453253f) * Matrix.CreateRotationX(2.90565419f) * Matrix.CreateRotationY(-0.2746308f) * Matrix.CreateRotationZ(-4.101493f) * Matrix.CreateTranslation(12.0863485f, 70.64876f, 226.455139f),
        Matrix.CreateScale(0.5413472f, 0.428533882f, 0.443344f) * Matrix.CreateRotationX(6.61738253f) * Matrix.CreateRotationY(-0.0106212618f) * Matrix.CreateRotationZ(-1.39962709f) * Matrix.CreateTranslation(19.8648472f, 61.85692f, 215.462936f),
        Matrix.CreateScale(0.748215854f, 0.5922924f, 0.730453253f) * Matrix.CreateRotationX(2.78337741f) * Matrix.CreateRotationY(0.037689615f) * Matrix.CreateRotationZ(-3.15569758f) * Matrix.CreateTranslation(-4.38251162f, 77.8521f, 229.155243f),
        Matrix.CreateScale(0.748215854f, 0.5922924f, 0.730453253f) * Matrix.CreateRotationX(3.070413f) * Matrix.CreateRotationY(0.353303343f) * Matrix.CreateRotationZ(-1.88843954f) * Matrix.CreateTranslation(-18.2355232f, 69.75004f, 225.529053f),
        Matrix.CreateScale(0.396332473f, 0.428533882f, 0.3915252f) * Matrix.CreateRotationX(3.00765324f) * Matrix.CreateRotationY(0.05079993f) * Matrix.CreateRotationZ(-1.66092014f) * Matrix.CreateTranslation(-28.5671387f, 59.18479f, 215.669022f),
        Matrix.CreateScale(0.245712832f, 0.3378071f, 0.2780271f) * Matrix.CreateRotationX(2.903015f) * Matrix.CreateRotationY(0.115094252f) * Matrix.CreateRotationZ(-1.63353825f) * Matrix.CreateTranslation(-26.71854f, 56.0220947f, 223.8292f),
        Matrix.CreateScale(0.245712832f, 0.3378071f, 0.6332214f) * Matrix.CreateRotationX(2.912676f) * Matrix.CreateRotationY(-0.019249836f) * Matrix.CreateRotationZ(-1.5989511f) * Matrix.CreateTranslation(-23.7435226f, 54.4811554f, 236.292419f),
        Matrix.CreateScale(0.5944707f, (float)(1471f / (995f * Math.PI)), 0.805785f) * Matrix.CreateRotationX(0.484665453f) * Matrix.CreateRotationY(1.42708552f) * Matrix.CreateRotationZ(-4.524961f) * Matrix.CreateTranslation(-18.9443722f, 67.76714f, 242.680573f),
        Matrix.CreateScale(0.245712832f, 0.3378071f, 0.2780271f) * Matrix.CreateRotationX(2.910827f) * Matrix.CreateRotationY(0.00319445459f) * Matrix.CreateRotationZ(-1.61689639f) * Matrix.CreateTranslation(-21.1254673f, 53.9395561f, 247.274475f),
        Matrix.CreateScale(0.315188259f, 0.113741606f, 0.253966272f) * Matrix.CreateRotationX(-0.187419519f) * Matrix.CreateRotationY(0.88269943f) * Matrix.CreateRotationZ(-6.01985025f) * Matrix.CreateTranslation(-17.9801865f, 80.97128f, 247.917557f),
        Matrix.CreateScale(0.270003438f, 0.113741606f, 0.117846757f) * Matrix.CreateRotationX(-0.013534301f) * Matrix.CreateRotationY(-0.04546181f) * Matrix.CreateRotationZ(-6.114901f) * Matrix.CreateTranslation(-9.500427f, 81.6341248f, 242.116653f),
        Matrix.CreateScale(0.270003438f, 0.113741606f, 0.117846757f) * Matrix.CreateRotationX(0.00174602191f) * Matrix.CreateRotationY(-0.04740022f) * Matrix.CreateRotationZ(-6.441197f) * Matrix.CreateTranslation(-0.5809272f, 81.74283f, 241.965363f),
        Matrix.CreateScale(0.33587113f, 0.3203402f, 0.416631728f) * Matrix.CreateRotationX(4.22820663f) * Matrix.CreateRotationY(1.13292539f) * Matrix.CreateRotationZ(-2.69068861f) * Matrix.CreateTranslation(9.903984f, 78.27347f, 245.569839f),
        Matrix.CreateScale(0.599828362f, 0.5282872f, 0.6118648f) * Matrix.CreateRotationX(-0.477991045f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationZ(0.0f) * Matrix.CreateTranslation(-2.25521255f, 79.89647f, 252.562836f),
        Matrix.CreateScale(0.204737023f, 0.113741606f, 0.253966272f) * Matrix.CreateRotationX(0.163299382f) * Matrix.CreateRotationY(0.9414379f) * Matrix.CreateRotationZ(-5.485871f) * Matrix.CreateTranslation(-14.0745068f, 81.4728851f, 252.087219f),
        Matrix.CreateScale(0.204737023f, 0.113741606f, 0.253966272f) * Matrix.CreateRotationX(2.21588f) * Matrix.CreateRotationY(0.9094076f) * Matrix.CreateRotationZ(-5.26588631f) * Matrix.CreateTranslation(13.2216949f, 76.05087f, 250.120728f),
        Matrix.CreateScale(0.517135441f, 0.493222684f, 0.6414812f) * Matrix.CreateRotationX(2.62006021f) * Matrix.CreateRotationY(1.2401886f) * Matrix.CreateRotationZ(-4.904619f) * Matrix.CreateTranslation(13.9682512f, 65.73363f, 242.17244f),
        Matrix.CreateScale(0.395013779f, 0.312695444f, 0.323502183f) * Matrix.CreateRotationX(6.45413971f) * Matrix.CreateRotationY(-0.00620562257f) * Matrix.CreateRotationZ(-1.5967679f) * Matrix.CreateTranslation(18.48424f, 57.37408f, 236.864075f),
        Matrix.CreateScale(0.272924f, 0.21604839f, 0.223515019f) * Matrix.CreateRotationX(6.45413971f) * Matrix.CreateRotationY(-0.00620562257f) * Matrix.CreateRotationZ(-1.5967679f) * Matrix.CreateTranslation(18.36457f, 56.8671074f, 245.132843f),
        Matrix.CreateScale(0.246836722f, 0.137130082f, 0.3061889f) * Matrix.CreateRotationX(2.090404f) * Matrix.CreateRotationY(0.5680416f) * Matrix.CreateRotationZ(-5.365757f) * Matrix.CreateTranslation(15.8026714f, 57.96174f, 250.370514f),
        Matrix.CreateScale(0.204737023f, 0.113741606f, 0.253966272f) * Matrix.CreateRotationX(1.56665111f) * Matrix.CreateRotationY(0.9414379f) * Matrix.CreateRotationZ(-5.485871f) * Matrix.CreateTranslation(9.297062f, 80.5311661f, 251.529282f),
        Matrix.CreateScale(1f, 0.5922924f, 1f) * Matrix.CreateRotationX(1.3328656f) * Matrix.CreateRotationY(0.00159643311f) * Matrix.CreateRotationZ(-3.13500977f) * Matrix.CreateTranslation(-4.417528f, 75.36524f, 251.056412f),
        Matrix.CreateScale(0.6032753f, 0.3573154f, 0.6032753f) * Matrix.CreateRotationX(1.53681552f) * Matrix.CreateRotationY(-0.00333004212f) * Matrix.CreateRotationZ(-6.26945353f) * Matrix.CreateTranslation(3.22824335f, 61.03654f, 252.714523f),
        Matrix.CreateScale(0.6032753f, 0.3573154f, 0.6032753f) * Matrix.CreateRotationX(1.56231356f) * Matrix.CreateRotationY(-0.00333004212f) * Matrix.CreateRotationZ(-6.26945353f) * Matrix.CreateTranslation(-14.2941628f, 59.0113754f, 250.2981f),
        Matrix.CreateScale(0.395013779f, 0.312695444f, 0.323502183f) * Matrix.CreateRotationX(6.61738253f) * Matrix.CreateRotationY(-0.0106212618f) * Matrix.CreateRotationZ(-1.39962709f) * Matrix.CreateTranslation(19.8525f, 58.3056564f, 226.533859f),
        Matrix.CreateScale(0.5413472f, 0.428533882f, 0.443344f) * Matrix.CreateRotationX(6.538176f) * Matrix.CreateRotationY(0.227865145f) * Matrix.CreateRotationZ(-1.54301238f) * Matrix.CreateTranslation(24.4380646f, 65.51811f, 194.371521f)
      };
      Matrix[] matrixArray3 = new Matrix[36]
      {
        Matrix.CreateScale(0.412092537f, 0.371840417f, 0.393213242f) * Matrix.CreateRotationX(-0.40591684f) * Matrix.CreateRotationY(0.6359218f) * Matrix.CreateRotationZ(-2.29378939f) * Matrix.CreateTranslation(25.6513882f, 47.2626762f, 174.602356f),
        Matrix.CreateScale(0.594862163f, 0.469735622f, 0.532229543f) * Matrix.CreateRotationX(-1.47313476f) * Matrix.CreateRotationY(0.4942707f) * Matrix.CreateRotationZ(3.13798881f) * Matrix.CreateTranslation(12.4021006f, 39.6802521f, 172.0124f),
        Matrix.CreateScale(0.594862163f, 0.469735622f, 0.532229543f) * Matrix.CreateRotationX(-1.48457778f) * Matrix.CreateRotationY(0.0799926147f) * Matrix.CreateRotationZ(3.09845138f) * Matrix.CreateTranslation(-4.063797f, 40.2020264f, 168.499924f),
        Matrix.CreateScale(0.594862163f, 0.469735622f, 0.532229543f) * Matrix.CreateRotationX(-1.48027742f) * Matrix.CreateRotationY(-0.318947047f) * Matrix.CreateRotationZ(3.063091f) * Matrix.CreateTranslation(-20.4748287f, 41.05769f, 168.889984f),
        Matrix.CreateScale(0.594862163f, 0.469735622f, 0.532229543f) * Matrix.CreateRotationX(-1.43791568f) * Matrix.CreateRotationY(-0.866010845f) * Matrix.CreateRotationZ(2.99007273f) * Matrix.CreateTranslation(-34.2251472f, 42.3095665f, 175.418167f),
        Matrix.CreateScale(0.578672349f, 0.42933777f, 0.380951017f) * Matrix.CreateRotationX(-2.53790712f) * Matrix.CreateRotationY(-0.6213276f) * Matrix.CreateRotationZ(-1.53626633f) * Matrix.CreateTranslation(-32.8095f, 36.1086f, 174.392532f),
        Matrix.CreateScale(0.459855229f, 0.433924943f, 0.382990628f) * Matrix.CreateRotationX(0.0976263359f) * Matrix.CreateRotationY(-0.954698265f) * Matrix.CreateRotationZ(1.69763052f) * Matrix.CreateTranslation(-36.7394562f, 43.5855446f, 179.977509f),
        Matrix.CreateScale(0.4600257f, 0.434164166f, 0.3826378f) * Matrix.CreateRotationX(3.22182f) * Matrix.CreateRotationY(-1.07165539f) * Matrix.CreateRotationZ(1.50034285f) * Matrix.CreateTranslation(27.9455032f, 47.37914f, 179.943237f),
        Matrix.CreateScale(0.5302833f, 0.5015824f, 0.5205079f) * Matrix.CreateRotationX(-2.976646f) * Matrix.CreateRotationY(-1.17103243f) * Matrix.CreateRotationZ(1.29784656f) * Matrix.CreateTranslation(27.2072544f, 36.9158554f, 184.3698f),
        Matrix.CreateScale(0.412092537f, 0.371840417f, 0.393213242f) * Matrix.CreateRotationX(-0.3627832f) * Matrix.CreateRotationY(0.4619855f) * Matrix.CreateRotationZ(-2.21147156f) * Matrix.CreateTranslation(26.5840149f, 39.54975f, 176.531448f),
        Matrix.CreateScale(0.6822789f, 0.5580407f, 0.6317565f) * Matrix.CreateRotationX(-2.51370239f) * Matrix.CreateRotationY(-0.4502413f) * Matrix.CreateRotationZ(0.272592545f) * Matrix.CreateTranslation(12.0540209f, 32.7031326f, 175.465485f),
        Matrix.CreateScale(1.02198f, 0.5039385f, 0.8545515f) * Matrix.CreateRotationX(-0.9450256f) * Matrix.CreateRotationY(0.0353116952f) * Matrix.CreateRotationZ(-3.11747313f) * Matrix.CreateTranslation(-2.23121047f, 27.8078785f, 177.898361f),
        Matrix.CreateScale(0.594862163f, 0.469735622f, 0.532229543f) * Matrix.CreateRotationX(-0.5869491f) * Matrix.CreateRotationY(-0.2135827f) * Matrix.CreateRotationZ(2.69659019f) * Matrix.CreateTranslation(-20.2941475f, 33.2250862f, 171.3266f),
        Matrix.CreateScale(0.459855229f, 0.433924943f, 0.382990628f) * Matrix.CreateRotationX(0.0976263359f) * Matrix.CreateRotationY(-0.954698265f) * Matrix.CreateRotationZ(1.69763052f) * Matrix.CreateTranslation(-33.855854f, 35.05395f, 184.652512f),
        Matrix.CreateScale(0.4172351f, 0.389671862f, 0.348589242f) * Matrix.CreateRotationX(-0.0577622131f) * Matrix.CreateRotationY(-1.05275452f) * Matrix.CreateRotationZ(1.937457f) * Matrix.CreateTranslation(-33.29405f, 28.0397434f, 189.096146f),
        Matrix.CreateScale(0.6760227f, 0.567691445f, 0.6267637f) * Matrix.CreateRotationX(-2.32057118f) * Matrix.CreateRotationY(0.490354985f) * Matrix.CreateRotationZ(-0.353961647f) * Matrix.CreateTranslation(-23.4726734f, 24.5519581f, 183.624512f),
        Matrix.CreateScale(0.6645037f, 0.578373849f, 0.6258517f) * Matrix.CreateRotationX(-2.151846f) * Matrix.CreateRotationY(-0.396154553f) * Matrix.CreateRotationZ(0.256574631f) * Matrix.CreateTranslation(16.3120575f, 22.9692516f, 185.879959f),
        Matrix.CreateScale(0.4600257f, 0.434164166f, 0.3826378f) * Matrix.CreateRotationX(3.01451135f) * Matrix.CreateRotationY(-1.16996467f) * Matrix.CreateRotationZ(1.48296416f) * Matrix.CreateTranslation(26.360117f, 26.65583f, 189.718048f),
        Matrix.CreateScale(0.3370805f, 0.436096042f, 0.3361327f) * Matrix.CreateRotationX(-3.10803962f) * Matrix.CreateRotationY(-1.13266158f) * Matrix.CreateRotationZ(1.41281128f) * Matrix.CreateTranslation(25.3104858f, 19.12759f, 194.453186f),
        Matrix.CreateScale(0.6479885f, 0.5938663f, 0.6250597f) * Matrix.CreateRotationX(-2.49073362f) * Matrix.CreateRotationY(-0.452689379f) * Matrix.CreateRotationZ(0.505752563f) * Matrix.CreateTranslation(15.5642786f, 11.3521738f, 192.282791f),
        Matrix.CreateScale(0.812446237f, 0.5033684f, 0.7366666f) * Matrix.CreateRotationX(-2.09887815f) * Matrix.CreateRotationY(-0.0153319612f) * Matrix.CreateRotationZ(0.0414815024f) * Matrix.CreateTranslation(-2.36485314f, 8.460554f, 189.977356f),
        Matrix.CreateScale(0.6776758f, 0.5678505f, 0.6250597f) * Matrix.CreateRotationX(-2.41319346f) * Matrix.CreateRotationY(0.3678197f) * Matrix.CreateRotationZ(-0.369999737f) * Matrix.CreateTranslation(-19.4361858f, 9.257215f, 191.965637f),
        Matrix.CreateScale(0.4625572f, 0.4282468f, 0.385801882f) * Matrix.CreateRotationX(-0.272529483f) * Matrix.CreateRotationY(-1.12875366f) * Matrix.CreateRotationZ(2.17796373f) * Matrix.CreateTranslation(-29.20887f, 19.2966385f, 194.216476f),
        Matrix.CreateScale(0.3375218f, 0.312485933f, 0.281514466f) * Matrix.CreateRotationX(-0.272529483f) * Matrix.CreateRotationY(-1.12875366f) * Matrix.CreateRotationZ(2.17796373f) * Matrix.CreateTranslation(-28.3701363f, 11.101428f, 198.821762f),
        Matrix.CreateScale(69f * (float) Math.E / 899f, 0.342508167f, 0.5465368f) * Matrix.CreateRotationX(2.930468f) * Matrix.CreateRotationY(-1.20815659f) * Matrix.CreateRotationZ(1.59195328f) * Matrix.CreateTranslation(18.28996f, 3.74408841f, 202.226959f),
        Matrix.CreateScale(0.5091167f, 0.474366248f, 0.488078982f) * Matrix.CreateRotationX(-2.84902859f) * Matrix.CreateRotationY(0.6030164f) * Matrix.CreateRotationZ(1.383574f) * Matrix.CreateTranslation(12.8357382f, -1.37391925f, 201.9446f),
        Matrix.CreateScale(0.779578745f, 0.5070165f, 0.8054802f) * Matrix.CreateRotationX(3.90716481f) * Matrix.CreateRotationY(-0.04256754f) * Matrix.CreateRotationZ(0.0198241547f) * Matrix.CreateTranslation(-2.63240218f, -7.928337f, 204.626312f),
        Matrix.CreateScale(0.274790645f, 0.09693247f, 0.100961804f) * Matrix.CreateRotationX(-1.19133484f) * Matrix.CreateRotationY(-0.09895785f) * Matrix.CreateRotationZ(-3.137025f) * Matrix.CreateTranslation(-5.61696959f, -1.37172365f, 191.103561f),
        Matrix.CreateScale(0.442863971f, 0.495045841f, 0.554546f) * Matrix.CreateRotationX(-0.439757824f) * Matrix.CreateRotationY(0.7053175f) * Matrix.CreateRotationZ(1.652292f) * Matrix.CreateTranslation(-19.7751923f, -1.881347f, 200.494812f),
        Matrix.CreateScale(0.3353942f, 0.3181485f, 0.278257966f) * Matrix.CreateRotationX(0.2943784f) * Matrix.CreateRotationY(-1.19494629f) * Matrix.CreateRotationZ(1.59844828f) * Matrix.CreateTranslation(-26.6954613f, 4.25056839f, 202.017181f),
        Matrix.CreateScale(0.274656743f, 0.09697973f, 0.100961804f) * Matrix.CreateRotationX(-1.1885699f) * Matrix.CreateRotationY(0.15338476f) * Matrix.CreateRotationZ(-3.03630519f) * Matrix.CreateTranslation(1.00293958f, -1.56777728f, 199.131378f),
        Matrix.CreateScale(0.231731474f, 0.219816029f, 0.192254767f) * Matrix.CreateRotationX(0.119276673f) * Matrix.CreateRotationY(-1.19494629f) * Matrix.CreateRotationZ(1.59844828f) * Matrix.CreateTranslation(-25.412241f, -1.9873122f, 207.7467f),
        Matrix.CreateScale(0.2220721f, 0.127329335f, 0.2723526f) * Matrix.CreateRotationX(0.460566819f) * Matrix.CreateRotationY(0.9249648f) * Matrix.CreateRotationZ(2.74877667f) * Matrix.CreateTranslation(-23.0452938f, -6.083092f, 208.467178f),
        Matrix.CreateScale(0.616524756f, 0.306016326f, 0.445135653f) * Matrix.CreateRotationX(-0.07961134f) * Matrix.CreateRotationY(0.482848138f) * Matrix.CreateRotationZ(-3.91876268f) * Matrix.CreateTranslation(-14.1401682f, -10.528718f, 205.500977f),
        Matrix.CreateScale(0.208695129f, 0.342383951f, 0.239982754f) * Matrix.CreateRotationX(2.98291874f) * Matrix.CreateRotationY(-1.18532348f) * Matrix.CreateRotationZ(1.53340387f) * Matrix.CreateTranslation(14.6554327f, -8.232341f, 209.462341f),
        Matrix.CreateScale(0.616524756f, 0.3060191f, 0.5121602f) * Matrix.CreateRotationX(-0.176950112f) * Matrix.CreateRotationY(0.137598142f) * Matrix.CreateRotationZ(-2.82613754f) * Matrix.CreateTranslation(7.971637f, -10.1528044f, 206.484344f)
      };
      for (int index = 0; index < 36; ++index)
      {
        this.dropChunk(ref this.faceChunk, matrixArray2[index], 7);
        this.dropChunk(ref this.faceChunk, matrixArray3[index], 9);
      }
      this.dropChunk(ref this.faceChunk, matrixArray2[36], 7);
      this.dropChunk(ref this.faceChunk, matrixArray2[37], 7);
      Matrix[] matrixArray4 = new Matrix[27]
      {
        Matrix.CreateScale(0.6249726f, 0.6249726f, 0.6249726f) * Matrix.CreateRotationX(-0.6496698f) * Matrix.CreateRotationY(0.109089941f) * Matrix.CreateRotationZ(-2.204136f) * Matrix.CreateTranslation(31.5580025f, 43.63091f, -117.8855f),
        Matrix.CreateScale(0.6249726f, 0.6249726f, 0.4483838f) * Matrix.CreateRotationX(-0.961786449f) * Matrix.CreateRotationY(-0.549675941f) * Matrix.CreateRotationZ(-2.98965621f) * Matrix.CreateTranslation(19.322937f, 36.14469f, -113.48896f),
        Matrix.CreateScale(0.7477622f, 0.7477622f, 0.7477622f) * Matrix.CreateRotationX(-2.45042229f) * Matrix.CreateRotationY(-0.05025345f) * Matrix.CreateRotationZ(-0.009903382f) * Matrix.CreateTranslation(-1.28617787f, 42.1092339f, -106.83503f),
        Matrix.CreateScale(0.597931266f, 0.441973358f, 0.597931266f) * Matrix.CreateRotationX(-0.859206557f) * Matrix.CreateRotationY(0.000160249532f) * Matrix.CreateRotationZ(3.02804923f) * Matrix.CreateTranslation(-27.8019485f, 36.4249039f, -117.55912f),
        Matrix.CreateScale(0.762986362f, 0.762986362f, 0.762986362f) * Matrix.CreateRotationX(-2.267468f) * Matrix.CreateRotationY(0.106266044f) * Matrix.CreateRotationZ(-0.204714686f) * Matrix.CreateTranslation(-23.8397312f, 50.02435f, -123.052147f),
        Matrix.CreateScale(0.762986362f, 0.762986362f, 0.762986362f) * Matrix.CreateRotationX(-2.45042229f) * Matrix.CreateRotationY(-0.05025345f) * Matrix.CreateRotationZ(-0.009903382f) * Matrix.CreateTranslation(-0.7291206f, 49.9923935f, -116.357918f),
        Matrix.CreateScale(0.762986362f, 0.762986362f, 0.762986362f) * Matrix.CreateRotationX(-2.28428912f) * Matrix.CreateRotationY(-0.06817425f) * Matrix.CreateRotationZ(-0.07318518f) * Matrix.CreateTranslation(18.1152058f, 48.6339264f, -119.085457f),
        Matrix.CreateScale(0.597931266f, 0.441973358f, 0.597931266f) * Matrix.CreateRotationX(-1.45478988f) * Matrix.CreateRotationY(-1.07084787f) * Matrix.CreateRotationZ(3.31814718f) * Matrix.CreateTranslation(-38.25945f, 49.2515831f, -118.739357f),
        Matrix.CreateScale(0.689880133f, 0.5796665f, 0.689880133f) * Matrix.CreateRotationX(-1.6803323f) * Matrix.CreateRotationY(0.6807442f) * Matrix.CreateRotationZ(-0.0458946452f) * Matrix.CreateTranslation(-37.77458f, 64.05266f, -119.890648f),
        Matrix.CreateScale(0.689880133f, 0.5796665f, 0.689880133f) * Matrix.CreateRotationX(-1.80977535f) * Matrix.CreateRotationY(0.188247547f) * Matrix.CreateRotationZ(0.005669557f) * Matrix.CreateTranslation(-22.2347088f, 64.22835f, -128.553116f),
        Matrix.CreateScale(0.8729049f, 0.8729049f, 0.8729049f) * Matrix.CreateRotationX(-1.8536123f) * Matrix.CreateRotationY(-0.05025345f) * Matrix.CreateRotationZ(-0.009903382f) * Matrix.CreateTranslation(-0.191218659f, 63.247982f, -124.442139f),
        Matrix.CreateScale(0.6249726f, 0.6249726f, 0.6249726f) * Matrix.CreateRotationX(-1.64591384f) * Matrix.CreateRotationY(-0.9861076f) * Matrix.CreateRotationZ(0.0638559759f) * Matrix.CreateTranslation(33.7436562f, 60.5776939f, -116.960587f),
        Matrix.CreateScale(0.6249726f, 0.6249726f, 0.6249726f) * Matrix.CreateRotationX(-1.72335207f) * Matrix.CreateRotationY(-0.4229281f) * Matrix.CreateRotationZ(-0.0570234619f) * Matrix.CreateTranslation(21.4265f, 61.10464f, -127.95314f),
        Matrix.CreateScale(0.6249726f, 0.6249726f, 0.6249726f) * Matrix.CreateRotationX(-1.72335207f) * Matrix.CreateRotationY(-0.4229281f) * Matrix.CreateRotationZ(-0.0570234619f) * Matrix.CreateTranslation(23.2905369f, 76.55791f, -130.131119f),
        Matrix.CreateScale(0.6249726f, 0.6249726f, 0.6249726f) * Matrix.CreateRotationX(-1.64591384f) * Matrix.CreateRotationY(-0.9861076f) * Matrix.CreateRotationZ(0.0638559759f) * Matrix.CreateTranslation(33.7254066f, 76.0334854f, -117.601341f),
        Matrix.CreateScale(1f, 1f, 1f) * Matrix.CreateRotationX(-1.37613463f) * Matrix.CreateRotationY(-0.05025345f) * Matrix.CreateRotationZ(-0.009903382f) * Matrix.CreateTranslation(0.0f, 80.78291f, -124.791214f),
        Matrix.CreateScale(0.689880133f, 0.5796665f, 0.689880133f) * Matrix.CreateRotationX(-1.47535622f) * Matrix.CreateRotationY(0.176530927f) * Matrix.CreateRotationZ(-0.196756691f) * Matrix.CreateTranslation(-22.3326511f, 81.78893f, -129.627457f),
        Matrix.CreateScale(0.689880133f, 0.5796665f, 0.689880133f) * Matrix.CreateRotationX(-1.6803323f) * Matrix.CreateRotationY(0.6807442f) * Matrix.CreateRotationZ(-0.0458946452f) * Matrix.CreateTranslation(-38.1816177f, 81.58589f, -121.385925f),
        Matrix.CreateScale(0.689880133f, 0.5796665f, 0.689880133f) * Matrix.CreateRotationX(-0.9789075f) * Matrix.CreateRotationY(0.6996845f) * Matrix.CreateRotationZ(0.2695538f) * Matrix.CreateTranslation(-37.7920456f, 91.08124f, -119.166168f),
        Matrix.CreateScale(0.689880133f, 0.5796665f, 0.689880133f) * Matrix.CreateRotationX(-1.09600258f) * Matrix.CreateRotationY(0.188247547f) * Matrix.CreateRotationZ(0.005669557f) * Matrix.CreateTranslation(-21.7405815f, 93.62254f, -126.8969f),
        Matrix.CreateScale(0.689880133f, 0.5796665f, 0.689880133f) * Matrix.CreateRotationX(-1.09600258f) * Matrix.CreateRotationY(0.188247547f) * Matrix.CreateRotationZ(0.005669557f) * Matrix.CreateTranslation(-0.182454363f, 98.38738f, -128.579636f),
        Matrix.CreateScale(0.689880133f, 0.5796665f, 0.689880133f) * Matrix.CreateRotationX(-1.26082814f) * Matrix.CreateRotationY(-0.08839668f) * Matrix.CreateRotationZ(-0.0843975f) * Matrix.CreateTranslation(15.7134743f, 97.22399f, -127.682083f),
        Matrix.CreateScale(0.689880133f, 0.5796665f, 0.689880133f) * Matrix.CreateRotationX(-1.379857f) * Matrix.CreateRotationY(-0.5223218f) * Matrix.CreateRotationZ(-0.175904319f) * Matrix.CreateTranslation(26.1630974f, 88.17002f, -126.92717f),
        Matrix.CreateScale(0.689880133f, 0.5796665f, 0.689880133f) * Matrix.CreateRotationX(-0.8142616f) * Matrix.CreateRotationY(-0.8590925f) * Matrix.CreateRotationZ(-0.6278064f) * Matrix.CreateTranslation(32.32895f, 93.55564f, -116.802681f),
        Matrix.CreateScale(1f, 1f, 1f) * Matrix.CreateRotationX(-0.512174f) * Matrix.CreateRotationY(-0.05219151f) * Matrix.CreateRotationZ(-0.7852635f) * Matrix.CreateTranslation(20.5775566f, 101.301186f, -113.120407f),
        Matrix.CreateScale(0.9988255f, 0.943908155f, 0.943908155f) * Matrix.CreateRotationX(-0.8706422f) * Matrix.CreateRotationY(-0.05025345f) * Matrix.CreateRotationZ(-0.009903382f) * Matrix.CreateTranslation(-2.642398f, 108.050682f, -114.009872f),
        Matrix.CreateScale(0.939259f, 0.939259f, 0.939259f) * Matrix.CreateRotationX(-0.634422958f) * Matrix.CreateRotationY(0.241991639f) * Matrix.CreateRotationZ(132f * (float) Math.E / 659f) * Matrix.CreateTranslation(-24.6077633f, 100.642967f, -112.889442f)
      };
      for (int index = 0; index < 27; ++index)
        this.dropChunk(ref this.assChunk, matrixArray4[index], 3);
      this.cuttyBone = new Matrix[this.a.skinTransforms.Length];
    }

    public void setCuttyTargets()
    {
      this.screenTarget1 = new RenderTarget2D(this.sc.GraphicsDevice, 600, 600, true, SurfaceFormat.Color, DepthFormat.None, 0, RenderTargetUsage.DiscardContents);
      this.screenTarget2 = new RenderTarget2D(this.sc.GraphicsDevice, 600, 600, true, SurfaceFormat.Color, DepthFormat.None, 0, RenderTargetUsage.DiscardContents);
      this.sc.isLoading = false;
      this.initTarget();
      this.sc.isLoading = true;
    }

    public void disposeCuttyTargets()
    {
      if (!this.screenTarget1.IsDisposed)
      {
        this.screenTarget1.Dispose();
        this.screenTarget1 = new RenderTarget2D(this.sc.GraphicsDevice, 4, 4, false, SurfaceFormat.Color, DepthFormat.None, 0, RenderTargetUsage.DiscardContents);
      }
      if (this.screenTarget2.IsDisposed)
        return;
      this.screenTarget2.Dispose();
      this.screenTarget2 = new RenderTarget2D(this.sc.GraphicsDevice, 4, 4, false, SurfaceFormat.Color, DepthFormat.None, 0, RenderTargetUsage.DiscardContents);
    }

    public void UnloadContent()
    {
      this.sparks.unloadContent();
      this.dots.unloadContent();
      this.content.Unload();
      this.contentB.Unload();
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
        Cutty.SetCurveKeyTangent(ref key1, ref key3, ref key2);
        x.Keys[index1] = key3;
        CurveKey key4 = y.Keys[index2];
        CurveKey key5 = y.Keys[index3];
        CurveKey key6 = y.Keys[index1];
        Cutty.SetCurveKeyTangent(ref key4, ref key6, ref key5);
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
      if (this.cuttyHeal || !Cutty.cuttyDoneSpeech)
        return;
      this.health -= amt;
      if (this.health >= (ushort) 0 && this.health < (ushort) 15000)
        return;
      this.health = (ushort) 0;
    }

    public void checkTargets(Vector3 gunpos, Vector3 gunlook, ref Cursor genCursor, float wall)
    {
      if (!Cutty.cuttyDoneSpeech)
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
        for (int index = 0; index < this.col_Bone.Length; ++index)
        {
          Matrix matrix = Matrix.CreateTranslation(this.col_Pos[index]) * this.cuttyBone[this.col_Bone[index]];
          Vector3 cent = Vector3.Transform(Vector3.Zero, matrix);
          float? nullable = genCursor.hitSphere2(gunpos, gunlook, cent, this.col_Scale[index] * this.cuttyScale);
          if (nullable.HasValue && (double) nullable.Value < (double) num && (double) nullable.Value < (double) wall)
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
        if (this.boneHit == 0)
        {
          Vector3 vector3 = Vector3.Transform(this.hitEdge - this.hitCenter, Matrix.CreateRotationY(-this.cuttyRot));
          if ((double) vector3.X < 0.0)
            this.addBulletHole(new Vector2(222f, 183f), new Vector2(500f, 268f), new Vector2(300f, 530f), new Vector2(504f, 472f), vector3.Z, vector3.Y, this.boneHit);
          else
            this.addBulletHole(new Vector2(790f, 183f), new Vector2(515f, 268f), new Vector2(734f, 550f), new Vector2(517f, 470f), vector3.Z, vector3.Y, -this.boneHit);
        }
        else if (this.boneHit == 1)
        {
          Vector3 vector3 = Vector3.Transform(this.hitEdge - this.hitCenter, Matrix.CreateRotationY(-this.cuttyRot));
          if ((double) vector3.X < 0.0)
            this.addBulletHole(new Vector2(320f, 104f), new Vector2(522f, 125f), new Vector2(267f, 300f), new Vector2(522f, 309f), vector3.Z, vector3.Y, this.boneHit);
          else
            this.addBulletHole(new Vector2(722f, 117f), new Vector2(502f, 125f), new Vector2(774f, 300f), new Vector2(502f, 309f), vector3.Z, vector3.Y, -this.boneHit);
        }
        else if (this.boneHit == 2)
        {
          Vector3 vector3 = Vector3.Transform(this.hitEdge - this.hitCenter, Matrix.CreateRotationY(-this.cuttyRot));
          if ((double) vector3.X < 0.0)
            this.addBulletHole(new Vector2(368f, 37f), new Vector2(515f, 23f), new Vector2(334f, 150f), new Vector2(515f, 178f), vector3.Z, vector3.Y, this.boneHit);
          else
            this.addBulletHole(new Vector2(658f, 33f), new Vector2(509f, 22f), new Vector2(692f, 158f), new Vector2(509f, 176f), vector3.Z, vector3.Y, -this.boneHit);
        }
        else if (this.boneHit == 3)
        {
          Vector3 vector3 = Vector3.Transform(this.hitEdge - this.hitCenter, Matrix.CreateRotationY(-this.cuttyRot));
          if ((double) vector3.X < 0.0)
            this.addBulletHole(new Vector2(505f, 434f), new Vector2(514f, 591f), new Vector2(227f, 477f), new Vector2(460f, 714f), vector3.Y, -vector3.Z, this.boneHit);
          else
            this.addBulletHole(new Vector2(512f, 429f), new Vector2(511f, 591f), new Vector2(755f, 480f), new Vector2(559f, 713f), vector3.Y, -vector3.Z, -this.boneHit);
        }
        else if (this.boneHit == 4)
        {
          Vector3 vector3 = Vector3.Transform(this.hitEdge - this.hitCenter, Matrix.CreateRotationY(-this.cuttyRot));
          this.addBulletHole(new Vector2(862f, 140f), new Vector2(687f, 182f), new Vector2(888f, 347f), new Vector2(723f, 409f), vector3.Z, vector3.Y, this.boneHit);
        }
        else if (this.boneHit == 5)
        {
          Vector3 vector3 = Vector3.Transform(this.hitEdge - this.hitCenter, Matrix.CreateRotationY(-this.cuttyRot));
          this.addBulletHole(new Vector2(161f, 135f), new Vector2(332f, 162f), new Vector2(120f, 334f), new Vector2(269f, 430f), vector3.Z, vector3.Y, this.boneHit);
        }
        else if (this.boneHit == 6)
        {
          Vector3 vector3 = Vector3.Transform(this.hitEdge - this.hitCenter, Matrix.CreateRotationY(-this.cuttyRot));
          this.addBulletHole(new Vector2(758f, 631f), new Vector2(704f, 522f), new Vector2(664f, 698f), new Vector2(594f, 603f), vector3.Z, vector3.Y, this.boneHit);
        }
        else if (this.boneHit == 7)
        {
          Vector3 vector3 = Vector3.Transform(this.hitEdge - this.hitCenter, Matrix.CreateRotationY(-this.cuttyRot));
          this.addBulletHole(new Vector2(272f, 629f), new Vector2(307f, 516f), new Vector2(359f, 702f), new Vector2(426f, 599f), vector3.Z, vector3.Y, this.boneHit);
        }
        ushort amt = 0;
        if ((double) this.distanceCutty < 4000.0)
        {
          ++this.hitcounter;
          if (this.df == 5 && this.hitcounter % 2 == 0)
            ++amt;
          if (this.df == 4)
            ++amt;
          if (this.df == 3)
            amt += (ushort) 2;
          if (this.df > 2 && Cutty.cuttyCount > 1)
            ++amt;
          if (this.df == 2)
            ++amt;
          if (this.df == 1)
            amt += (ushort) 2;
          if (this.df == 0)
            amt += (ushort) 4;
        }
        if ((double) this.distanceCutty < 1200.0)
        {
          if (this.df == 5)
            ++amt;
          if (this.df == 4)
            ++amt;
          if (this.df == 3)
            amt += (ushort) 2;
          if (this.df > 2 && Cutty.cuttyCount > 1)
            ++amt;
          if (this.df == 2)
            amt += (ushort) 2;
          if (this.df == 1)
            amt += (ushort) 3;
          if (this.df == 0)
            amt += (ushort) 4;
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
      float num1 = this.col_Scale[this.boneHit] * this.cuttyScale;
      float amount1 = (float) (((double) sendY + (double) num1) / ((double) num1 * 2.0));
      float amount2 = (float) (((double) sendX + (double) num1) / ((double) num1 * 2.0));
      float num2 = MathHelper.Lerp(MathHelper.Lerp(p3.X, p1.X, amount1), MathHelper.Lerp(p4.X, p2.X, amount1), amount2);
      float num3 = MathHelper.Lerp(MathHelper.Lerp(p3.Y, p4.Y, amount2), MathHelper.Lerp(p1.Y, p2.Y, amount2), amount1);
      Cutty.uvIndex = (byte) this.myIndex;
      Cutty.xcoord = (int) num2;
      Cutty.ycoord = (int) num3;
      this.addTargetBlood(this.sc.paintColor, (int) num2 - 25, (int) num2 + 25, (int) num3 - 25, (int) num3 + 25);
      if (Math.Abs(bonehit) == 1 && (double) amount2 > 0.699999988079071)
        this.addTargetBlood(this.sc.paintColor, 275, 417, 736, 836);
      if (bonehit == 0)
      {
        if ((double) amount2 > 0.60000002384185791)
        {
          this.addTargetBlood(this.sc.paintColor, 592, 945, 755, 880);
          this.addTargetBlood(this.sc.paintColor, 592, 945, 830, 970);
          if ((double) this.distanceCutty < 4000.0 && !this.cuttyHeal)
          {
            ++this.spineDamage;
            if (this.spineDamage > (ushort) 300)
              this.spineDamage = (ushort) 300;
            if ((double) this.spineDamage > (double) this.spineBreach[this.df])
            {
              if (!this.spineDestroyed)
                this.spineSwitch();
              if ((double) this.spineDamage < (double) this.spineBreach[this.df] + (double) (480 / (int) this.spineDam[this.df]))
              {
                this.damHealth(this.spineDam[this.df]);
                this.buzzSkeleton(8);
                this.boneStrike = true;
              }
            }
          }
        }
        if (this.health <= (ushort) 0)
        {
          this.buzzSkeleton(8);
          this.seizureTimer = 40;
          this.boneStrike = true;
        }
      }
      if (Math.Abs(bonehit) == 2)
      {
        if ((double) this.distanceCutty < 2500.0 && !this.cuttyHeal)
        {
          ++this.faceDamage;
          if (this.faceDamage > (ushort) 300)
            this.faceDamage = (ushort) 300;
          if ((double) this.faceDamage > (double) this.faceBreach[this.df])
          {
            if (!this.faceDestroyed)
              this.faceSwitch();
            if ((double) this.faceDamage < (double) this.faceBreach[this.df] + (double) (560 / (int) this.faceDam[this.df]))
            {
              this.damHealth(this.faceDam[this.df]);
              this.buzzSkeleton(4);
              this.boneStrike = true;
            }
          }
        }
        if (this.health <= (ushort) 0)
        {
          this.buzzSkeleton(8);
          this.seizureTimer = 40;
          this.boneStrike = true;
        }
      }
      if (Math.Abs(bonehit) != 3)
        return;
      if ((double) this.distanceCutty < 4000.0 && !this.cuttyHeal)
      {
        ++this.assDamage;
        if (this.assDamage > (ushort) 300)
          this.assDamage = (ushort) 300;
        if ((double) this.assDamage > (double) this.assBreach[this.df])
        {
          if (!this.assDestroyed)
            this.assSwitch();
          if ((double) this.assDamage < (double) this.assBreach[this.df] + (double) (420 / (int) this.assDam[this.df]))
          {
            this.damHealth(this.assDam[this.df]);
            this.buzzSkeleton(8);
            this.boneStrike = true;
            this.seizureTimer = 40;
          }
        }
      }
      if (this.health > (ushort) 0)
        return;
      this.buzzSkeleton(8);
      this.seizureTimer = 40;
      this.boneStrike = true;
    }

    public void buzzSkeleton(int amt)
    {
      this.showSkelTimer = amt;
      this.sc.buzz.Play(this.sc.ev, (float) this.rr.Next(-50, 20) / 100f, 0.0f);
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

    private void spineSwitch()
    {
      this.talkIndex = 8;
      Cutty.whichPigTalks = this.myIndex;
      this.sc.cuttygouge.Play(this.sc.ev, (float) this.rr.Next(-20, 0) / 100f, (float) this.rr.Next(-20, 30) / 100f);
      this.chunk.startDrop = true;
      this.spineDestroyed = true;
      if ((double) this.spineDamage < (double) this.spineBreach[this.df])
        this.spineDamage = (ushort) ((double) this.spineBreach[this.df] + 5.0);
      if (this.bodyState == 0)
      {
        this.bodyState = 1;
        this.pigModel = this.sc.pigAll;
        this.pigIndex = 1;
      }
      else if (this.bodyState == 2)
      {
        this.bodyState = 4;
        this.pigModel = this.sc.pigAll;
        this.pigIndex = 4;
      }
      else if (this.bodyState == 3)
      {
        this.bodyState = 5;
        this.pigModel = this.sc.pigAll;
        this.pigIndex = 5;
      }
      else
      {
        if (this.bodyState != 6)
          return;
        this.bodyState = 7;
        this.pigModel = this.sc.pigAll;
        this.pigIndex = 7;
      }
    }

    private void assSwitch()
    {
      this.talkIndex = 8;
      Cutty.whichPigTalks = this.myIndex;
      this.assChunk.startDrop = true;
      this.sc.cuttygouge.Play(this.sc.ev, (float) this.rr.Next(-20, 0) / 100f, (float) this.rr.Next(-20, 30) / 100f);
      this.assDestroyed = true;
      if ((double) this.assDamage < (double) this.assBreach[this.df])
        this.assDamage = (ushort) ((double) this.assBreach[this.df] + 5.0);
      if (this.bodyState == 0)
      {
        this.bodyState = 2;
        this.pigModel = this.sc.pigAll;
        this.pigIndex = 2;
      }
      else if (this.bodyState == 1)
      {
        this.bodyState = 4;
        this.pigModel = this.sc.pigAll;
        this.pigIndex = 4;
      }
      else if (this.bodyState == 3)
      {
        this.bodyState = 6;
        this.pigModel = this.sc.pigAll;
        this.pigIndex = 6;
      }
      else
      {
        if (this.bodyState != 5)
          return;
        this.bodyState = 7;
        this.pigModel = this.sc.pigAll;
        this.pigIndex = 7;
      }
    }

    private void faceSwitch()
    {
      this.talkIndex = 8;
      Cutty.whichPigTalks = this.myIndex;
      this.faceChunk.startDrop = true;
      this.sc.cuttygouge.Play(this.sc.ev, (float) this.rr.Next(-20, 0) / 100f, (float) this.rr.Next(-20, 30) / 100f);
      this.faceDestroyed = true;
      if ((double) this.faceDamage < (double) this.faceBreach[this.df])
        this.faceDamage = (ushort) ((double) this.faceBreach[this.df] + 5.0);
      if (this.bodyState == 0)
      {
        this.bodyState = 3;
        this.pigModel = this.sc.pigAll;
        this.pigIndex = 3;
      }
      else if (this.bodyState == 2)
      {
        this.bodyState = 6;
        this.pigModel = this.sc.pigAll;
        this.pigIndex = 6;
      }
      else if (this.bodyState == 1)
      {
        this.bodyState = 5;
        this.pigModel = this.sc.pigAll;
        this.pigIndex = 5;
      }
      else
      {
        if (this.bodyState != 4)
          return;
        this.bodyState = 7;
        this.pigModel = this.sc.pigAll;
        this.pigIndex = 7;
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
      this.healthPerc = (float) this.health / (float) this.startHealth;
      this.df = this.sc.df;
      if (!this.spectator)
        this.df += 3;
      this.networkSession = net;
      this.playerpos = playerPos;
      this.remotepos = remotePos;
      this.timeframe = timeframe;
      this.spectator = isSpectating;
      this.playerHealth = playerHealth;
      this.remoteHealth = remoteHealth;
      if (this.sc.host && !this.deathsent)
        this.pigLogic();
      this.pigBones(lookVec, ref heights);
      if (this.chunk.startDrop)
        this.updateChunk(ref this.chunk, ref heights);
      if (this.faceChunk.startDrop)
        this.updateChunk(ref this.faceChunk, ref heights);
      if (this.assChunk.startDrop)
        this.updateChunk(ref this.assChunk, ref heights);
      if (this.sc.host)
        this.runScheduler(ref heights);
      if ((double) this.shockTimer > 0.0)
        this.shockWave(ref heights);
      if (this.sc.host)
      {
        --this.fireTimer;
        if (this.fireTimer <= 0)
        {
          this.onFire = false;
        }
        else
        {
          ushort amt = 1;
          int num = 10;
          if (this.spectator)
            num = 5;
          if (this.df == 5)
            amt = (ushort) 1;
          if (this.df == 4)
            amt = (ushort) 2;
          if (this.df == 3)
            amt = (ushort) 3;
          if (this.df == 2)
            amt = (ushort) 1;
          if (this.df == 1)
            amt = (ushort) 3;
          if (this.df == 0)
            amt = (ushort) 4;
          if ((double) this.sc.myTimer % (double) num == 0.0)
            this.damHealth(amt);
        }
      }
      if (this.onFire)
      {
        this.fireRamp -= 2;
        if (this.fireRamp < 4)
          this.fireRamp = 4;
      }
      else
      {
        ++this.fireRamp;
        if (this.fireRamp > 130)
          this.fireRamp = 130;
      }
      if (this.fireRamp < 130 && (double) this.sc.myTimer % (double) this.fireRamp == 0.0)
        this.addExplosion(ref this.fireball, campos);
      this.updateExplosion(ref this.fireball, campos);
      this.sparks.Update(gm);
      this.dots.Update(gm);
    }

    private void dropChunk(ref Cutty.shell sh, Matrix mm, int bone)
    {
      sh.offset[sh.index] = mm;
      sh.bone[sh.index] = bone;
      sh.dupe[sh.index].init((float) this.rr.Next(20, 60) / 100f, 2f, 1f, mm, new Vector3(2f, 1f, 0.0f), (float) (-(double) this.rr.Next(80, 160) / 1000.0), 80, 80f, 220f);
      sh.stream[sh.index].Trans = sh.dupe[sh.index].transform;
      ++sh.index;
      if (sh.index > sh.maxCapacity - 1)
        sh.index = 0;
      ++sh.max;
      if (sh.max <= sh.maxCapacity - 1)
        return;
      sh.max = sh.maxCapacity;
    }

    private void updateChunk(ref Cutty.shell sh, ref float[,] heights)
    {
      sh.tempindex = 0;
      bool flag = true;
      for (int index = 0; index < sh.max; ++index)
      {
        if (sh.dupe[index].move == 1 || sh.dupe[index].move == 2)
          sh.dupe[index].Update(ref heights);
        if (sh.dupe[index].move == 0)
          sh.dupe[index].transform = sh.offset[index] * this.cuttyBone[sh.bone[index]];
        if (sh.startDrop)
        {
          sh.dropTimer += 0.013f;
          if ((double) index < (double) sh.dropTimer && sh.dupe[index].move == 0)
          {
            sh.dupe[index].move = 1;
            sh.dupe[index].createState(sh.dupe[index].transform);
            Vector3 vector3 = (this.cuttyPos - this.oldcuttyPos) * (float) this.rr.Next(35, 110) / 100f;
            sh.dupe[index].velocity = vector3 + new Vector3((float) this.rr.Next(-50, 50) / 30f, (float) this.rr.Next(10, 40) / 10f, (float) this.rr.Next(-50, 50) / 30f);
            sh.dupe[index].Update(ref heights);
            this.cuttyChunkRelease = true;
            this.hitCenter2 = sh.dupe[index].mypos;
            this.hitEdge2 = this.hitCenter2 + sh.dupe[index].velocity;
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

    private void addExplosion(ref Cutty.hole hole, Vector3 campos)
    {
      hole.location[hole.stainIndex] = new Vector3(0.0f, 145.424255f, 0.0f) + new Vector3((float) this.rr.Next(-90, 90) / 10f, (float) this.rr.Next(-120, -60) / 10f, (float) this.rr.Next(-100, 1150) / 10f);
      hole.bone[hole.stainIndex] = 5;
      Vector3 objectPosition = Vector3.Transform(Vector3.Zero, Matrix.CreateTranslation(hole.location[hole.stainIndex]) * this.cuttyBone[5]);
      Matrix billboard = Matrix.CreateBillboard(objectPosition, new Vector3(campos.X, (float) (((double) campos.Y - (double) objectPosition.Y) / 2.0), campos.Z), this.view.Up, new Vector3?(this.view.Forward));
      Vector3 scales = new Vector3(340f, 600f, 340f) * (float) this.rr.Next(70, 160) / 400f;
      hole.scale[hole.stainIndex] = this.rr.Next(1, 100) >= 50 ? Matrix.CreateScale(scales) * Matrix.CreateRotationY(3.14f) * Matrix.CreateRotationZ((float) this.rr.Next(-20, 20) / 100f) : Matrix.CreateScale(scales) * Matrix.CreateRotationZ((float) this.rr.Next(-20, 20) / 100f);
      hole.stainTrans[hole.stainIndex].Trans = hole.scale[hole.stainIndex] * billboard;
      hole.fade[hole.stainIndex] = (float) this.rr.Next(80, 100) / 100f;
      hole.stainTrans[hole.stainIndex].Fade = hole.fade[hole.stainIndex];
      Vector4 vector4 = hole.stainR[0];
      hole.stainTrans[hole.stainIndex].Coord = new Vector4(1864f / vector4.Z, vector4.X / 1864f, 1200f / vector4.W, vector4.Y / 1200f);
      hole.frame[hole.stainIndex] = 0;
      ++hole.stainIndex;
      if (hole.stainIndex > hole.stainCapacity - 1)
        hole.stainIndex = 0;
      ++hole.stainMax;
      if (hole.stainMax <= hole.stainCapacity - 1)
        return;
      hole.stainMax = hole.stainCapacity;
    }

    private void updateExplosion(ref Cutty.hole hole, Vector3 campos)
    {
      if (!this.burning.sound[0].IsDisposed)
      {
        if (hole.stainMax == 0)
        {
          this.burning.sound[0].Volume = 0.0f;
          return;
        }
        this.burning.sound[0].Volume = this.sc.ev - MathHelper.Clamp((float) (((double) this.distanceCutty - 200.0) / 2200.0), 0.0f, this.sc.ev);
      }
      bool flag = false;
      for (int index = 0; index < hole.stainMax; ++index)
      {
        ++hole.frame[index];
        if (hole.frame[index] > hole.stainR.Length - 1)
        {
          hole.frame[index] = hole.stainR.Length - 1;
        }
        else
        {
          hole.location[index] += new Vector3(0.0f, -1f, -1.1f);
          Vector3 objectPosition = Vector3.Transform(Vector3.Zero, Matrix.CreateTranslation(hole.location[index]) * this.cuttyBone[hole.bone[index]]);
          Matrix billboard = Matrix.CreateBillboard(objectPosition, new Vector3(campos.X, (float) (((double) campos.Y - (double) objectPosition.Y) / 2.0), campos.Z), this.view.Up, new Vector3?(this.view.Forward));
          hole.stainTrans[index].Trans = hole.scale[index] * billboard;
          Vector4 vector4 = hole.stainR[hole.frame[index]];
          hole.stainTrans[index].Coord = new Vector4(1864f / vector4.Z, vector4.X / 1864f, 1200f / vector4.W, vector4.Y / 1200f);
          hole.stainTrans[index].Fade = hole.fade[index];
          flag = true;
        }
      }
      if (flag)
        return;
      hole.stainIndex = 0;
      hole.stainMax = 0;
    }

    private void animManager(string type)
    {
      if (this.animClip != 0 && this.animClip == 3 && (double) this.animCount == 5.0)
        this.sc.chomp2.Play(this.sc.ev, 0.0f, 0.0f);
      switch (type)
      {
        case "bite":
          this.animList.Clear();
          this.animList.Add(5);
          this.animList.Add(7);
          this.animList.Add(8);
          this.animList.Add(9);
          this.animList.Add(12);
          this.animList.Add(16);
          this.animClip = 3;
          this.animCount = 0.0f;
          this.animMin = 0;
          this.animMax = 42;
          this.animTween = 0.0f;
          this.animLoop = 0;
          this.gonnaBite = false;
          break;
        case "bite2":
          this.animList.Clear();
          this.animList.Add(5);
          this.animList.Add(7);
          this.animList.Add(8);
          this.animList.Add(9);
          this.animList.Add(12);
          this.animList.Add(16);
          this.animClip = 3;
          this.animCount = 0.0f;
          this.animMin = 0;
          this.animMax = 42;
          this.animTween = 0.0f;
          this.animLoop = 1;
          this.gonnaBite = false;
          break;
      }
    }

    private void setbreakLevels()
    {
      this.break1 = 510;
      this.break2 = 790;
      if (this.df == 0)
      {
        if ((double) this.healthPerc <= 1.0 && (double) this.healthPerc >= 0.75)
        {
          this.break1 = 400;
          this.break2 = 500;
        }
        if ((double) this.healthPerc < 0.75 && (double) this.healthPerc >= 0.25)
        {
          this.break1 = 150;
          this.break2 = 250;
        }
        if ((double) this.healthPerc < 0.25 && (double) this.healthPerc >= 0.0)
        {
          this.break1 = 200;
          this.break2 = 350;
        }
      }
      else if (this.df == 1)
      {
        if ((double) this.healthPerc <= 1.0 && (double) this.healthPerc >= 0.75)
        {
          this.break1 = 650;
          this.break2 = 790;
        }
        if ((double) this.healthPerc < 0.75 && (double) this.healthPerc >= 0.25)
        {
          this.break1 = 370;
          this.break2 = 510;
        }
        if ((double) this.healthPerc < 0.25 && (double) this.healthPerc >= 0.0)
        {
          this.break1 = 510;
          this.break2 = 850;
        }
      }
      else if (this.df == 2)
      {
        if ((double) this.healthPerc <= 1.0 && (double) this.healthPerc >= 0.75)
        {
          this.break1 = 650;
          this.break2 = 750;
        }
        if ((double) this.healthPerc < 0.75 && (double) this.healthPerc >= 0.25)
        {
          this.break1 = 510;
          this.break2 = 790;
        }
        if ((double) this.healthPerc < 0.25 && (double) this.healthPerc >= 0.0)
        {
          this.break1 = 600;
          this.break2 = 840;
        }
      }
      else if (this.df == 3)
      {
        if ((double) this.healthPerc <= 1.0 && (double) this.healthPerc >= 0.75)
        {
          this.break1 = 400;
          this.break2 = 500;
        }
        if ((double) this.healthPerc < 0.75 && (double) this.healthPerc >= 0.25)
        {
          this.break1 = 150;
          this.break2 = 250;
        }
        if ((double) this.healthPerc < 0.25 && (double) this.healthPerc >= 0.0)
        {
          this.break1 = 200;
          this.break2 = 350;
        }
      }
      else if (this.df == 4)
      {
        if ((double) this.healthPerc <= 1.0 && (double) this.healthPerc >= 0.75)
        {
          this.break1 = 550;
          this.break2 = 790;
        }
        if ((double) this.healthPerc < 0.75 && (double) this.healthPerc >= 0.34999999403953552)
        {
          this.break1 = 650;
          this.break2 = 710;
        }
        if ((double) this.healthPerc < 0.35 && (double) this.healthPerc >= 0.0)
        {
          this.break1 = 610;
          this.break2 = 870;
        }
      }
      else if (this.df == 5)
      {
        if ((double) this.healthPerc <= 1.0 && (double) this.healthPerc >= 0.75)
        {
          this.break1 = 650;
          this.break2 = 750;
        }
        if ((double) this.healthPerc < 0.75 && (double) this.healthPerc >= 0.25)
        {
          this.break1 = 510;
          this.break2 = 790;
        }
        if ((double) this.healthPerc < 0.25 && (double) this.healthPerc >= 0.0)
        {
          this.break1 = 600;
          this.break2 = 850;
        }
      }
      this.oldDF = this.df;
    }

    private void pigLogic()
    {
      if (this.oldDF != this.df)
        this.setbreakLevels();
      --this.targetWait;
      int curveIndex = this.curveIndex;
      if (!this.cuttyDoneLocalSpeech)
      {
        if (!Cutty.allplayersReady || Cutty.someoneTalking)
          return;
        if (Cutty.speeches < this.speechList.Count && this.speechInclude.Contains(Cutty.speeches))
        {
          Cutty.someoneTalking = true;
          this.cuttyStruct.homing = 0;
          this.cuttyStruct.curveIndex = this.speechCurveindex;
          this.cuttyStruct.targetRate = 0.0f;
          this.cuttyStruct.loop = 0.1f;
          this.cuttyStruct.animType = 0;
          this.cuttyStruct.talkindex = this.speechList[Cutty.speeches];
          this.scheduleAction(130);
          ++Cutty.speeches;
        }
        else
        {
          if (Cutty.speeches < this.speechList.Count)
            return;
          this.targetWait = this.rr.Next(600, 800);
          this.cuttyStruct.homing = 0;
          this.cuttyStruct.curveIndex = this.startCurveindex;
          this.cuttyStruct.targetRate = this.startRate;
          this.cuttyStruct.loop = this.startLoop;
          this.cuttyStruct.animType = 0;
          this.cuttyStruct.talkindex = -1;
          this.scheduleAction(130);
          this.cuttyDoneLocalSpeech = true;
          Cutty.cuttyDoneSpeech = true;
        }
      }
      else if (!this.newAction && this.health <= (ushort) 0)
      {
        this.deathsent = true;
        this.targetWait = 500;
        this.cuttyStruct.dur = (ushort) 40;
        this.cuttyStruct.destx = this.cuttyPos.X + (float) (-Math.Cos((double) this.cuttyRot + 1.5700000524520874) * 600.0);
        this.cuttyStruct.destz = this.cuttyPos.Z + (float) Math.Sin((double) this.cuttyRot + 1.5700000524520874) * 600f;
        this.cuttyStruct.rot = this.cuttyRot;
        this.scheduleAction(132);
        this.newAction = true;
      }
      else
      {
        --this.nextAttack;
        if (!this.newAction && (double) this.playerHealth != 100.0 && ((double) this.remoteHealth != 100.0 || this.spectator) && (double) this.healthPerc < 0.72000002861022949 && this.clipIndexA == 1 && this.nextAttack < 0 && this.homing == 0)
        {
          this.homing = 0;
          float num1 = 9000f;
          float num2 = 9000f;
          int num3 = 0;
          float num4 = 0.0f;
          if ((double) this.distanceCutty > 200.0 && (double) this.distanceCutty < 1500.0)
            num1 = MathHelper.Clamp(this.distanceCutty, 300f, 1200f);
          if (!this.spectator && (double) this.distanceCutty2 >= 200.0 && (double) this.distanceCutty2 <= 1500.0)
            num2 = MathHelper.Clamp(this.distanceCutty2, 300f, 1200f);
          if ((double) num1 < (double) num2)
          {
            num3 = 1;
            num4 = num1;
          }
          if ((double) num2 < (double) num1)
          {
            num3 = 2;
            num4 = num2;
          }
          if ((double) num4 >= 200.0 && (double) num4 <= 1500.0)
          {
            this.cuttyStruct.dur = (ushort) num4;
            if (num3 == 1)
            {
              this.cuttyStruct.destx = this.playerpos.X;
              this.cuttyStruct.destz = this.playerpos.Z;
            }
            else
            {
              this.cuttyStruct.destx = this.remotepos.X;
              this.cuttyStruct.destz = this.remotepos.Z;
            }
            this.scheduleAction(131);
            this.newAction = true;
            return;
          }
        }
        if (!this.newAction && Cutty.gonnaHealindex == -1)
        {
          --this.gonnaHealDelay;
          float num5 = 700f;
          bool flag1 = this.healCount == 2 && (double) this.healthPerc > 0.40000000596046448 && (double) this.healthPerc < 0.75;
          bool flag2 = this.healCount > 0 && (double) this.healthPerc < 0.20000000298023224;
          if (this.healCount > 0 && (flag1 || flag2) && (double) this.gonnaHealDelay <= 0.0)
          {
            Vector3 zero = Vector3.Zero;
            float num6 = Vector3.Distance(this.roofTop1, this.cuttyPos);
            float y = this.roofTop1.Y;
            float num7 = num6;
            Vector3 vector3 = this.roofTop1;
            if ((double) num6 > (double) num5)
            {
              float num8 = Vector3.Distance(this.roofTop2, this.cuttyPos);
              y = this.roofTop2.Y;
              num7 = num8;
              vector3 = this.roofTop2;
              if ((double) num8 > (double) num5)
              {
                y = this.roofTop3.Y;
                float num9 = Vector3.Distance(this.roofTop3, this.cuttyPos);
                vector3 = this.roofTop3;
                if ((double) num9 <= (double) num5)
                  num7 = num9;
              }
            }
            if ((double) num7 <= (double) num5)
            {
              --this.healCount;
              this.cuttyStruct.dur = (ushort) num7;
              this.cuttyStruct.destx = vector3.X;
              this.cuttyStruct.destz = vector3.Z;
              float num10 = (float) (-Math.Atan2((double) this.cuttyPos.Z - (double) vector3.Z, (double) this.cuttyPos.X - (double) vector3.X) - 1.5700000524520874);
              float num11 = Cutty.WrapAngle(y - num10);
              float num12 = Cutty.WrapAngle(y + 3.14f - num10);
              this.cuttyStruct.rot = (double) Math.Abs(num11) > (double) Math.Abs(num12) ? num10 + num12 : num10 + num11;
              this.scheduleAction(133);
              this.newAction = true;
              return;
            }
          }
        }
        if (this.targetWait > 0 || this.newAction)
          return;
        this.curveIndex = this.rr.Next(1, 4);
        if (this.curveIndex == curveIndex && this.homing <= 10)
          return;
        if (Cutty.homingLocal == this.myIndex)
          Cutty.homingLocal = -1;
        if (Cutty.homingRemote == this.myIndex)
          Cutty.homingRemote = -1;
        int num13 = this.rr.Next(0, 1000);
        int num14 = this.rr.Next(1, 3);
        if (this.spectator)
          num14 = 1;
        if (this.homing == 11)
          num13 = (double) this.distanceCutty >= (double) this.rr.Next(100, 350) ? this.rr.Next(this.break1, 1000) : 10;
        if (this.homing == 12)
          num13 = (double) this.distanceCutty2 >= (double) this.rr.Next(100, 350) ? this.rr.Next(this.break1, 1000) : 10;
        if (num13 < this.break1)
        {
          if (num14 == 1 && Cutty.homingLocal != -1 && Cutty.homingRemote == -1 && !this.spectator && (double) this.remoteHealth > 0.0)
            num14 = 2;
          if (num14 == 2 && Cutty.homingRemote != -1 && Cutty.homingLocal == -1 && (double) this.playerHealth > 0.0)
            num14 = 1;
          bool flag3 = Cutty.homingRemote != -1 && Cutty.homingLocal != -1;
          bool flag4 = num14 == 1 && Cutty.homingLocal != -1;
          bool flag5 = num14 == 2 && Cutty.homingRemote != -1;
          bool flag6 = (double) this.playerHealth < 1.0 && num14 == 1;
          bool flag7 = (double) this.remoteHealth < 1.0 && num14 == 2;
          bool flag8 = this.homingCount >= 4;
          bool flag9 = this.homingCount >= 2 && (num14 == 1 && (double) this.playerHealth < 105.0 || num14 == 2 && (double) this.remoteHealth < 105.0);
          if (flag8 || flag9 || flag6 || flag7 || flag3 || flag4 || flag5)
            num13 = this.rr.Next(this.break1, 1000);
        }
        if (num13 >= this.break2)
        {
          this.homingCount = 0;
          int num15 = -1;
          this.targetWait = this.rr.Next(270, 500);
          this.cuttyStruct.homing = 0;
          this.cuttyStruct.curveIndex = this.curveIndex;
          this.cuttyStruct.targetRate = (float) ((double) this.rr.Next(90, 130) / 100.0 * 8.0);
          this.cuttyStruct.loop = this.loop;
          this.cuttyStruct.animType = 0;
          if (this.rr.Next(1, 500) < 40 && this.quips.Count > 0 && this.myIndex == 0)
          {
            int index = this.rr.Next(0, this.quips.Count);
            num15 = this.quips[index];
            this.quips.RemoveAt(index);
          }
          this.cuttyStruct.talkindex = num15;
          this.scheduleAction(130);
        }
        else if (num13 >= this.break1)
        {
          this.targetWait = this.rr.Next(150, 300);
          int num16 = -1;
          if (this.homingCount >= 1)
            num16 = this.rr.Next(9, 11);
          this.homingCount = 0;
          this.cuttyStruct.homing = 0;
          this.cuttyStruct.curveIndex = this.curveIndex;
          this.cuttyStruct.targetRate = (float) ((double) this.rr.Next(80, 130) / 100.0 * 2.0);
          this.cuttyStruct.loop = this.loop;
          this.cuttyStruct.animType = 0;
          if (this.rr.Next(1, 500) < 70 && this.quips.Count > 0 && this.myIndex == 0)
          {
            int index = this.rr.Next(0, this.quips.Count);
            num16 = this.quips[index];
            this.quips.RemoveAt(index);
          }
          this.cuttyStruct.talkindex = num16;
          this.scheduleAction(130);
        }
        else
        {
          if (num13 >= this.break1)
            return;
          int num17 = -1;
          ++this.homingCount;
          if (num14 == 1 && (double) this.distanceCutty > 1000.0)
            num17 = 12;
          if (num14 == 2 && (double) this.distanceCutty2 > 1000.0)
            num17 = 12;
          this.targetWait = this.rr.Next(340, 600);
          if (this.homing < 10)
          {
            this.homingCount = 0;
            this.cuttyStruct.homing = num14;
          }
          if (this.homing == 11)
          {
            this.cuttyStruct.homing = 1;
            num17 = -1;
            this.targetWait = this.rr.Next(220, 360);
          }
          if (this.homing == 12)
          {
            this.cuttyStruct.homing = 2;
            num17 = -1;
            this.targetWait = this.rr.Next(220, 360);
          }
          if (this.cuttyStruct.homing == 1)
            Cutty.homingLocal = this.myIndex;
          if (this.cuttyStruct.homing == 2)
            Cutty.homingRemote = this.myIndex;
          this.cuttyStruct.curveIndex = curveIndex;
          this.cuttyStruct.targetRate = (float) this.rr.Next(80, 100) / 10f;
          this.cuttyStruct.loop = this.loop;
          this.cuttyStruct.animType = 0;
          this.cuttyStruct.talkindex = num17;
          this.scheduleAction(130);
        }
      }
    }

    private void volumeGallop()
    {
      if (this.gallop.sound[0].IsDisposed)
        return;
      if (this.clipIndexA == 0)
        this.gallop.sound[0].Volume = this.sc.ev - MathHelper.Clamp(this.distanceCutty / 1900f, 0.0f, this.sc.ev);
      else
        this.gallop.sound[0].Volume = 0.0f;
    }

    private void pigVolume()
    {
      if (this.pigDialog1.sound[0].IsDisposed)
        return;
      this.pigDialog1.sound[0].Volume = this.sc.vv;
    }

    private void pigBones(Vector3 lookVec, ref float[,] heights)
    {
      this.talkSmooth = 0.0f;
      this.lookingatPig = false;
      this.distanceCutty = Vector3.Distance(this.playerpos, this.cuttyPos);
      this.distanceCutty2 = Vector3.Distance(this.remotepos, this.cuttyPos);
      if (this.attack1)
        this.pigAttack(ref heights);
      else if (this.cuttyHeal)
        this.pigHealing(ref heights);
      else if (this.death1 && !this.cuttyisDead)
        this.pigDying();
      else if (this.health > (ushort) 0)
        this.pigClipControl();
      if (this.myClip != this.clipIndexA)
      {
        this.tween = 0.0f;
        this.clipIndexB = this.clipIndexA;
        this.clipIndexA = this.myClip;
      }
      this.a = this.pig1[this.clipIndexA];
      this.b = this.pig1[this.clipIndexB];
      this.volumeGallop();
      this.isSpeaking = false;
      if (this.pigJawIndex >= 0)
      {
        this.isSpeaking = true;
        this.talkSmooth = this.pigJaw[this.pigJawIndex] * 1f;
        ++this.pigJawIndex;
        if ((double) this.pigJaw[this.pigJawIndex] == -1.0)
        {
          this.pigJawIndex = -1;
          Cutty.someoneTalking = false;
          this.pigLine = -1;
          this.talkSmooth = 0.0f;
        }
      }
      double num1 = (double) this.pigFrame1 * 0.041700001806020737;
      this.currentTimeValue = TimeSpan.FromSeconds(num1 % this.a.currentClipValue.Duration.TotalSeconds);
      this.currentKeyframe = (int) (this.currentTimeValue.TotalSeconds * 60.0) * 28;
      this.currentTimeValue += TimeSpan.FromSeconds(0.041999999433755875);
      this.a.UpdateBoneTransforms2(this.currentKeyframe, this.currentTimeValue);
      if ((double) this.tween < 1.0)
      {
        this.tween += 0.05f;
        this.currentTimeValue = TimeSpan.FromSeconds(num1 % this.b.currentClipValue.Duration.TotalSeconds);
        this.currentKeyframe = (int) (this.currentTimeValue.TotalSeconds * 60.0) * 28;
        this.currentTimeValue += TimeSpan.FromSeconds(0.041999999433755875);
        this.b.UpdateBoneTransforms2(this.currentKeyframe, this.currentTimeValue);
        for (int index = 0; index < this.b.boneTransforms.Length; ++index)
          this.a.boneTransforms[index] = Matrix.Lerp(this.b.boneTransforms[index], this.a.boneTransforms[index], this.tween);
      }
      if ((double) this.animCount > -1.0)
      {
        this.currentTimeValue = TimeSpan.FromSeconds((double) this.animCount * 0.40000000596046448 * 0.041700001806020737 % this.pig1[this.animClip].currentClipValue.Duration.TotalSeconds);
        this.currentKeyframe = (int) (this.currentTimeValue.TotalSeconds * 60.0) * 28;
        this.currentTimeValue += TimeSpan.FromSeconds(0.041999999433755875);
        this.pig1[this.animClip].UpdateBoneTransforms2(this.currentKeyframe, this.currentTimeValue);
        this.animTween = MathHelper.Clamp(this.animTween, 0.0f, 1f);
        for (int index = 0; index < this.animList.Count; ++index)
          this.a.boneTransforms[this.animList[index]] = this.a.boneTransforms[this.animList[index]] * (1f - this.animTween) + this.pig1[this.animClip].boneTransforms[this.animList[index]] * this.animTween;
        ++this.animCount;
        if ((double) this.animCount < (double) (this.animMin + 7))
          this.animTween += 0.166666672f;
        if ((double) this.animCount > (double) (this.animMax - 7))
          this.animTween -= 0.166666672f;
        if ((double) this.animCount > (double) this.animMax)
        {
          if (this.animLoop == 0)
          {
            this.animCount = -1f;
            this.animTween = 0.0f;
            this.animClip = 0;
          }
          else
          {
            this.animCount = (float) this.animMin;
            this.animTween = 0.0f;
            --this.animLoop;
          }
        }
      }
      this.isWatching = false;
      if ((double) this.distanceCutty < 600.0 && this.health > (ushort) 0)
      {
        if (this.homing == 0)
          this.isWatching = true;
        if (this.homing == 1)
          this.isWatching = true;
        if (this.homing == 2)
          this.isWatching = true;
      }
      float num2 = 0.0f;
      if (this.isWatching)
        num2 = (float) (-Math.Atan2((double) this.cuttyPos.Z - (double) this.playerpos.Z, (double) this.cuttyPos.X - (double) this.playerpos.X) - (1.5700000524520874 + (double) this.cuttyRot));
      this.piglook = Cutty.WrapAngle(this.piglook + MathHelper.Clamp(Cutty.WrapAngle(num2 - this.piglook), -0.013f, 0.013f));
      this.piglook = MathHelper.Clamp(this.piglook, -0.8f, 0.8f);
      if ((double) this.sc.myTimer % 250.0 == 0.0)
        this.pigPush = (float) this.rr.Next(-100, 100) / 100f;
      this.a.boneTransforms[7] = Matrix.CreateRotationY(-this.piglook) * this.a.boneTransforms[7];
      if (this.isSpeaking)
      {
        this.a.boneTransforms[9] = Matrix.CreateRotationZ(MathHelper.ToRadians(this.talkSmooth - 4f)) * this.a.boneTransforms[9];
        Matrix rotationZ = Matrix.CreateRotationZ(MathHelper.ToRadians((float) (0.0 - (double) this.talkSmooth / 7.0)));
        this.a.boneTransforms[7] = Matrix.CreateRotationX(MathHelper.ToRadians((float) (0.0 - (double) this.talkSmooth / 4.0 * Math.Sin((double) this.sc.myTimer / 14.0)))) * this.a.boneTransforms[7];
        this.a.boneTransforms[7] = rotationZ * this.a.boneTransforms[7];
      }
      if (!this.cuttyisDead)
      {
        string type = "";
        this.cuttyVeloc = this.cuttyPos - this.oldcuttyPos;
        this.oldcuttyPos = this.cuttyPos;
        this.loop += 1f / this.targetDist[this.curveIndex] * this.targetRate;
        if ((double) this.loop >= 1.0)
          this.loop = 0.0f;
        Vector3 vector3 = Vector3.Transform(Vector3.Zero, Matrix.CreateTranslation(-2.69420433f, 12.6439171f, 196.161835f) * this.cuttyBone[9]);
        float num3 = Vector3.DistanceSquared(new Vector3(this.playerpos.X, this.playerpos.Y + 80f, this.playerpos.Z), vector3);
        float num4 = Vector3.DistanceSquared(new Vector3(this.remotepos.X, this.remotepos.Y + 80f, this.remotepos.Z), vector3);
        if (!this.newAction)
        {
          if (this.homing == 0)
          {
            this.tx = this.targetX[this.curveIndex].Evaluate(this.loop);
            this.tz = this.targetZ[this.curveIndex].Evaluate(this.loop);
          }
          if (this.homing == 1 || this.homing == 11)
          {
            if (this.sc.host)
            {
              this.tx = this.playerpos.X;
              this.tz = this.playerpos.Z;
              if (this.homing != 11 && (double) num3 < 22500.0 && !this.gonnaBite)
              {
                this.targetWait = 90;
                this.gonnaBite = true;
                this.cuttyStruct.homing = 11;
                this.cuttyStruct.curveIndex = this.curveIndex;
                this.cuttyStruct.targetRate = this.rr.Next(1, 100) >= 70 ? 8f : 3f;
                this.cuttyStruct.loop = this.loop;
                this.cuttyStruct.animType = this.rr.Next(1, 3);
                this.cuttyStruct.talkindex = -1;
                this.scheduleAction(130);
              }
              if ((double) this.distanceCutty < 50.0 && (double) this.playerHealth > 105.0)
                this.cuttyAssPush = true;
            }
            else
            {
              this.tx = this.remotepos.X;
              this.tz = this.remotepos.Z;
            }
          }
          if (this.homing == 2 || this.homing == 12)
          {
            if (this.sc.host)
            {
              this.tx = this.remotepos.X;
              this.tz = this.remotepos.Z;
              if (this.homing != 12 && (double) num4 < 22500.0 && !this.gonnaBite)
              {
                this.targetWait = 90;
                this.gonnaBite = true;
                this.cuttyStruct.homing = 12;
                this.cuttyStruct.curveIndex = this.curveIndex;
                this.cuttyStruct.targetRate = this.rr.Next(1, 100) >= 70 ? 8f : 3f;
                this.cuttyStruct.loop = this.loop;
                this.cuttyStruct.animType = this.rr.Next(1, 3);
                this.cuttyStruct.talkindex = -1;
                this.scheduleAction(130);
              }
            }
            else
            {
              this.tx = this.playerpos.X;
              this.tz = this.playerpos.Z;
              if ((double) this.distanceCutty < 50.0 && (double) this.playerHealth > 105.0)
                this.cuttyAssPush = true;
              if (this.homing != 12 && (double) num3 < 10000.0 && this.animClip != 3)
                type = "bite";
            }
          }
        }
        this.animManager(type);
        if ((double) num3 < 2500.0 && this.animClip != 3)
        {
          this.cuttyMouthPos = new Vector2(vector3.X, vector3.Z) - new Vector2(this.playerpos.X, this.playerpos.Z);
          this.cuttyMouthCollide = true;
        }
        if ((double) num3 < 22500.0 && this.animClip == 3)
        {
          this.cuttyMouthPos = new Vector2(vector3.X, vector3.Z) - new Vector2(this.playerpos.X, this.playerpos.Z);
          this.cuttyMouthCollide = true;
        }
        float num5 = Cutty.WrapAngle((float) (-Math.Atan2((double) this.cuttyPos.Z - (double) this.tz, (double) this.cuttyPos.X - (double) this.tx) - 1.5700000524520874) - this.cuttyRot);
        float max = 0.065f;
        if (this.homing > 0)
        {
          max = 0.065f;
          num5 = MathHelper.Clamp(num5, -0.065f, max);
          this.cuttyRot = Cutty.WrapAngle(this.cuttyRot + num5);
        }
        if (this.attack1)
        {
          max = 0.06f;
          if (this.attackLand)
            max = 0.004f;
          num5 = MathHelper.Clamp(num5, -max, max);
          this.cuttyRot = Cutty.WrapAngle(this.cuttyRot + num5);
        }
        if (this.death1)
        {
          max = 0.0f;
          if (this.cuttyDyingWalk)
          {
            num5 = MathHelper.Clamp(num5, -0.1f, 0.1f);
            this.cuttyRot = Cutty.WrapAngle(this.cuttyRot + num5);
          }
        }
        if (this.cuttyHeal)
        {
          max = 0.037f;
          if ((double) this.healWait1 <= 0.0)
          {
            num5 = Cutty.WrapAngle(this.cuttyHealrot - this.cuttyRot);
            max = 0.01f;
          }
          if ((double) this.healWait2 <= 0.0)
          {
            num5 = Cutty.WrapAngle(this.cuttyHealrot - this.cuttyRot);
            max = 0.02f;
          }
          num5 = MathHelper.Clamp(num5, -max, max);
          this.cuttyRot = Cutty.WrapAngle(this.cuttyRot + num5);
        }
        if (!this.death1 && !this.cuttyHeal && !this.attack1 && this.homing == 0)
          this.cuttyRot = Cutty.WrapAngle(this.cuttyRot + MathHelper.Clamp(num5, -max, max));
        this.cuttyPos.X += (float) -Math.Cos((double) this.cuttyRot + 1.5700000524520874) * this.cuttyRate;
        this.cuttyPos.Z += (float) Math.Sin((double) this.cuttyRot + 1.5700000524520874) * this.cuttyRate;
      }
      else
      {
        --this.glowWait;
        if (this.glowWait < 0)
        {
          this.eyeGlow -= 1f / 1000f;
          if ((double) this.eyeGlow < 0.0)
            this.eyeGlow = 0.0f;
        }
      }
      if (this.faceseizureTimer > 0)
      {
        --this.faceseizureTimer;
        if (this.faceseizureTimer % 2 == 0)
        {
          Math.Cos((double) this.sc.myTimer / 26.0);
          float num6 = (float) (380.0 + Math.Sin((double) this.sc.myTimer / 34.0) * 220.0);
          float num7 = (float) (480.0 + Math.Cos((double) this.sc.myTimer / 24.0) * 200.0);
          this.a.boneTransforms[7] = Matrix.CreateRotationY((float) this.rr.Next(-15, 15) / num7) * this.a.boneTransforms[7];
          this.a.boneTransforms[7] = Matrix.CreateRotationZ((float) this.rr.Next(-13, 13) / num6) * this.a.boneTransforms[7];
        }
      }
      if (this.seizureTimer > 0)
      {
        --this.seizureTimer;
        float num8 = (float) (350.0 + Math.Cos((double) this.sc.myTimer / 26.0) * 300.0);
        float num9 = (float) (350.0 + Math.Sin((double) this.sc.myTimer / 34.0) * 300.0);
        float num10 = (float) (480.0 + Math.Cos((double) this.sc.myTimer / 24.0) * 200.0);
        this.a.boneTransforms[5] = Matrix.CreateRotationZ((float) this.rr.Next(-10, 10) / num10) * this.a.boneTransforms[5];
        this.a.boneTransforms[5] = Matrix.CreateRotationX((float) this.rr.Next(-10, 10) / num10) * this.a.boneTransforms[5];
        this.a.boneTransforms[12] = Matrix.CreateRotationX((float) this.rr.Next(-20, 20) / num10) * this.a.boneTransforms[12];
        this.a.boneTransforms[12] = Matrix.CreateRotationY((float) this.rr.Next(-20, 20) / num8) * this.a.boneTransforms[12];
        this.a.boneTransforms[13] = Matrix.CreateRotationX((float) this.rr.Next(-10, 10) / num9) * this.a.boneTransforms[13];
        this.a.boneTransforms[13] = Matrix.CreateRotationY((float) this.rr.Next(-20, 20) / num8) * this.a.boneTransforms[13];
        this.a.boneTransforms[16] = Matrix.CreateRotationX((float) this.rr.Next(-10, 10) / num8) * this.a.boneTransforms[16];
        this.a.boneTransforms[16] = Matrix.CreateRotationY((float) this.rr.Next(-10, 10) / num8) * this.a.boneTransforms[16];
        this.a.boneTransforms[17] = Matrix.CreateRotationX((float) this.rr.Next(-20, 20) / num9) * this.a.boneTransforms[17];
        this.a.boneTransforms[17] = Matrix.CreateRotationY((float) this.rr.Next(-20, 20) / num8) * this.a.boneTransforms[17];
        this.a.boneTransforms[7] = Matrix.CreateRotationY((float) this.rr.Next(-20, 20) / num10) * this.a.boneTransforms[7];
        this.a.boneTransforms[20] = Matrix.CreateRotationX((float) this.rr.Next(-20, 20) / num8) * this.a.boneTransforms[20];
        this.a.boneTransforms[20] = Matrix.CreateRotationY((float) this.rr.Next(-10, 10) / num9) * this.a.boneTransforms[20];
        this.a.boneTransforms[25] = Matrix.CreateRotationX((float) this.rr.Next(-20, 20) / num10) * this.a.boneTransforms[25];
        this.a.boneTransforms[25] = Matrix.CreateRotationY((float) this.rr.Next(-10, 10) / num8) * this.a.boneTransforms[25];
      }
      if (!this.attack1 && !this.cuttyHeal)
        Cutty.GetHeightFast(ref heights, new Vector2(this.cuttyPos.X, this.cuttyPos.Z), out this.cuttyPos.Y);
      this.cuttyTrans = Matrix.CreateScale(this.cuttyScale) * Matrix.CreateRotationY(this.cuttyRot) * Matrix.CreateTranslation(this.cuttyPos);
      this.a.UpdateWorldTransforms(this.cuttyTrans, this.a.boneTransforms);
      this.a.skinTransforms.CopyTo((Array) this.cuttyBone, 0);
    }

    private void pigClipControl()
    {
      this.myClip = 0;
      float num1 = Vector2.Distance(new Vector2(this.tx, this.tz), new Vector2(this.cuttyPos.X, this.cuttyPos.Z));
      if (this.homing > 0)
        num1 += 200f;
      float num2 = 0.0f;
      if ((double) num1 >= 220.0 && (double) num1 < 450.0)
        num2 = (double) this.targetRate <= 0.0 ? 2f : this.targetRate;
      else if ((double) num1 >= 450.0 && (double) num1 < 800.0)
        num2 = (double) this.targetRate <= 0.0 ? 3f : this.targetRate * 1.2f;
      else if ((double) num1 >= 800.0)
        num2 = (double) this.targetRate <= 5.0 ? 10f : this.targetRate * 1.3f;
      if ((double) this.cuttyRate > (double) num2)
        this.cuttyRate -= 0.2f;
      else if ((double) this.cuttyRate < (double) num2)
        this.cuttyRate += 0.1f;
      if ((double) this.cuttyRate < 0.0)
        this.cuttyRate = 0.0f;
      if ((double) this.cuttyRate <= 0.0)
        this.myClip = 2;
      if ((double) this.cuttyRate > 0.0 && (double) this.cuttyRate <= (double) this.clipRate[1] * 2.0)
        this.myClip = 1;
      if ((double) this.cuttyRate > 5.0)
        this.myClip = 0;
      this.fps = (float) (((double) this.cuttyRate + 1.0) / ((double) this.clipRate[this.clipIndexA] + 1.0));
      this.pigFrame1 += this.fps;
    }

    private void pigDying()
    {
      this.homing = 0;
      this.attack1 = false;
      if (this.cuttyDyingWalk)
      {
        this.myClip = 0;
        --this.cuttyDeathTimer;
        if ((double) this.cuttyDeathTimer <= 0.0)
        {
          this.cuttyPos.X = this.cuttyDeadx;
          this.cuttyPos.Z = this.cuttyDeadz;
        }
        this.tx = this.cuttyDeadx;
        this.tz = this.cuttyDeadz;
        float num1 = Vector2.Distance(new Vector2(this.tx, this.tz), new Vector2(this.cuttyPos.X, this.cuttyPos.Z));
        this.targetRate = 0.0f;
        float num2 = 0.0f;
        if ((double) num1 >= 20.0 && (double) num1 < 250.0)
          num2 = 2f;
        else if ((double) num1 >= 250.0)
          num2 = 8f;
        if ((double) this.cuttyRate > (double) num2)
          this.cuttyRate -= 0.2f;
        else if ((double) this.cuttyRate < (double) num2)
          this.cuttyRate += 0.1f;
        if ((double) this.cuttyRate < 0.0)
          this.cuttyRate = 0.0f;
        if ((double) this.cuttyRate <= 0.0)
          this.myClip = 2;
        if ((double) this.cuttyRate > 0.0 && (double) this.cuttyRate <= (double) this.clipRate[1] * 2.0)
          this.myClip = 1;
        if ((double) this.cuttyRate > 5.0)
          this.myClip = 0;
        this.fps = (float) (((double) this.cuttyRate + 1.0) / ((double) this.clipRate[this.clipIndexA] + 1.0));
        this.pigFrame1 += this.fps;
        if (this.myClip != 2 || (double) num1 > 20.0 || (double) this.tween < 1.0)
          return;
        this.cuttyDyingWalk = false;
      }
      else
      {
        if (this.cuttyDyingWalk)
          return;
        this.myClip = 4;
        this.cuttyRate = 0.0f;
        if (this.clipIndexA != 4)
        {
          this.sc.dieyell.Play(this.sc.ev, 0.0f, 0.0f);
          this.myClip = 4;
          this.pigFrame1 = 0.0f;
          if (!this.assDestroyed)
            this.assSwitch();
          else if (!this.faceDestroyed)
            this.faceSwitch();
          else if (!this.spineDestroyed)
            this.spineSwitch();
        }
        if (!this.cuttyisDead)
        {
          this.fps = 0.4f;
          this.pigFrame1 += this.fps;
          if ((double) this.pigFrame1 >= 121.0)
          {
            this.fireTimer = 1200;
            this.onFire = true;
            this.cuttyisDead = true;
            this.pigFrame1 = 121f;
            if (!this.assDestroyed)
              this.assSwitch();
            else if (!this.faceDestroyed)
              this.faceSwitch();
            else if (!this.spineDestroyed)
              this.spineSwitch();
          }
        }
        this.cuttyRot = Cutty.WrapAngle(this.cuttyRot + MathHelper.Clamp(Cutty.WrapAngle(this.cuttyDeadrot - this.cuttyRot), -0.06f, 0.06f));
      }
    }

    private void pigHealing(ref float[,] heights)
    {
      this.myClip = 5;
      this.fps = 0.0f;
      --this.healWait1;
      if ((double) this.healWait1 <= 0.0)
      {
        this.healWait1 = 0.0f;
        ++this.healtimer;
        if ((double) this.healtimer > (double) this.healduration)
        {
          this.healtimer = this.healduration + 5f;
          --this.healWait2;
        }
      }
      if ((double) this.healWait1 > 0.0)
      {
        this.fps = 0.4f;
        float height;
        Cutty.GetHeightFast(ref heights, new Vector2(this.cuttyPos.X, this.cuttyPos.Z), out height);
        this.cuttyPos.Y = height;
      }
      if ((double) this.healWait2 > 0.0 && (double) this.healWait1 <= 0.0 && (double) this.healtimer <= (double) this.healduration)
      {
        float amount = this.healtimer / this.healduration;
        if ((double) amount > 1.0)
          amount = 1f;
        this.cuttyPos.X = MathHelper.Lerp(this.healorigx, this.healdestx, amount);
        this.cuttyPos.Z = MathHelper.Lerp(this.healorigz, this.healdestz, amount);
        this.upForce -= this.grav;
        this.cuttyPos.Y += this.upForce;
        float height;
        Cutty.GetHeightFast(ref heights, new Vector2(this.cuttyPos.X, this.cuttyPos.Z), out height);
        if ((double) this.cuttyPos.Y <= (double) height)
          this.cuttyPos.Y = height - 10f;
        else if ((double) this.healtimer == (double) this.healduration)
          this.healtimer = this.healduration - 1f;
        this.fps = 0.4f;
        if ((double) this.pigFrame1 > 54.0)
          this.pigFrame1 = 54f;
      }
      if ((double) this.healWait2 > 0.0 && (double) this.healtimer > (double) this.healduration)
      {
        if ((double) this.healWait2 == 55.0)
          this.sc.piledriver.Play(this.sc.ev, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
        if ((double) this.pigFrame1 < 54.0)
          this.pigFrame1 = 54f;
        float height;
        Cutty.GetHeightFast(ref heights, new Vector2(this.cuttyPos.X, this.cuttyPos.Z), out height);
        this.cuttyPos.Y = height - 10f;
        this.fps = 0.4f;
      }
      this.tx = this.healdestx;
      this.tz = this.healdestz;
      this.homing = 0;
      this.cuttyRate = 0.0f;
      this.targetRate = 0.0f;
      if ((double) this.healWait2 <= 0.0)
      {
        --this.healChant;
        if (this.spectator && (double) this.healChant % 4.0 == 0.0)
          ++this.health;
        if (!this.spectator && (double) this.healChant % 2.0 == 0.0)
          ++this.health;
        if ((int) this.health > (int) this.startHealth)
          this.health = this.startHealth;
        if ((double) this.healChant == 700.0)
        {
          this.talkIndex = 3;
          Cutty.whichPigTalks = this.myIndex;
        }
        if ((double) this.healChant == 400.0)
        {
          this.talkIndex = 4;
          Cutty.whichPigTalks = this.myIndex;
        }
        this.energize(this.cuttyPos);
        this.myClip = 6;
        this.fps = 0.4f;
        if ((double) this.healChant <= 0.0)
        {
          this.cuttyHeal = false;
          this.glowTimer = 0.0f;
          this.talkIndex = 11;
          if (this.quips.Count > 0 && this.myIndex == 0)
          {
            int index = this.rr.Next(0, this.quips.Count);
            this.talkIndex = this.quips[index];
            this.quips.RemoveAt(index);
          }
          Cutty.whichPigTalks = this.myIndex;
          Cutty.gonnaHealindex = -1;
          this.gonnaHealDelay = 600f;
          this.newAction = false;
        }
      }
      this.pigFrame1 += this.fps;
    }

    private void pigAttack(ref float[,] heights)
    {
      this.myClip = 5;
      this.attackLand = false;
      this.fps = 0.0f;
      --this.attackWait1;
      if ((double) this.attackWait1 <= 0.0)
      {
        this.attackWait1 = 0.0f;
        ++this.attacktimer;
        if ((double) this.attacktimer > (double) this.attackduration)
        {
          this.attackLand = true;
          this.attacktimer = this.attackduration + 5f;
          --this.attackWait2;
        }
      }
      if ((double) this.attackWait1 > 0.0)
      {
        this.fps = 0.4f;
        float height;
        Cutty.GetHeightFast(ref heights, new Vector2(this.cuttyPos.X, this.cuttyPos.Z), out height);
        this.cuttyPos.Y = height;
      }
      if ((double) this.attackWait2 > 0.0 && (double) this.attackWait1 <= 0.0 && (double) this.attacktimer <= (double) this.attackduration)
      {
        float amount = this.attacktimer / this.attackduration;
        if ((double) amount > 1.0)
          amount = 1f;
        this.cuttyPos.X = MathHelper.Lerp(this.origx, this.destx, amount);
        this.cuttyPos.Z = MathHelper.Lerp(this.origz, this.destz, amount);
        this.upForce -= this.grav;
        this.cuttyPos.Y += this.upForce;
        float height;
        Cutty.GetHeightFast(ref heights, new Vector2(this.cuttyPos.X, this.cuttyPos.Z), out height);
        if ((double) this.cuttyPos.Y <= (double) height)
          this.cuttyPos.Y = height;
        else if ((double) this.attacktimer >= (double) this.attackduration - 1.0)
          this.attacktimer -= 2f;
        this.fps = 0.4f;
        if ((double) this.pigFrame1 > 54.0)
          this.pigFrame1 = 54f;
      }
      if ((double) this.attackWait2 > 0.0 && (double) this.attacktimer > (double) this.attackduration)
      {
        if ((double) this.attackWait2 == 55.0)
        {
          this.sc.cuttyWave.Play(this.sc.ev, (float) this.rr.Next(-10, 10) / 100f, 0.0f);
          this.sc.piledriver.Play(this.sc.ev, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
          this.shockTimer = 65f;
          this.shockRadius = 80f;
          this.shockHit = false;
          this.shockHasHit = false;
        }
        if ((double) this.pigFrame1 < 54.0)
          this.pigFrame1 = 54f;
        float height;
        Cutty.GetHeightFast(ref heights, new Vector2(this.cuttyPos.X, this.cuttyPos.Z), out height);
        this.cuttyPos.Y = height;
        this.fps = 0.4f;
      }
      if ((double) this.attackWait2 <= 0.0)
      {
        this.attack1 = false;
        this.nextAttack = this.rr.Next(100 + Cutty.cuttyCount * 150, Cutty.cuttyCount * 320);
        this.newAction = false;
      }
      this.tx = this.destx;
      this.tz = this.destz;
      this.homing = 0;
      this.targetWait = 100;
      this.cuttyRate = 0.0f;
      this.targetRate = 0.0f;
      this.pigFrame1 += this.fps;
    }

    public void endHealing()
    {
      if (!this.cuttyHeal)
        return;
      this.homingCount = 0;
      this.targetWait = this.rr.Next(270, 500);
      this.cuttyStruct.homing = 0;
      this.cuttyStruct.curveIndex = this.curveIndex;
      this.cuttyStruct.targetRate = (float) ((double) this.rr.Next(90, 130) / 100.0 * 8.0);
      this.cuttyStruct.loop = this.loop;
      this.cuttyStruct.animType = 0;
      this.cuttyStruct.talkindex = this.rr.Next(9, 12);
      this.scheduleAction(130);
    }

    public void host_SendData(ref packetSender packetWriter, int timeFrame)
    {
      if (this.cuttyStruct_send.flag == 130)
      {
        packetWriter.Write((byte) 130);
        packetWriter.Write((byte) this.myIndex);
        packetWriter.Write((byte) this.cuttyStruct_send.homing);
        packetWriter.Write(this.cuttyStruct_send.targetRate);
        packetWriter.Write((byte) this.cuttyStruct_send.curveIndex);
        packetWriter.Write(this.cuttyStruct_send.loop);
        packetWriter.Write((byte) this.cuttyStruct_send.animType);
        if (this.cuttyStruct_send.talkindex > -1)
          packetWriter.Write((byte) this.cuttyStruct_send.talkindex);
        else
          packetWriter.Write((byte) 150);
      }
      if (this.cuttyStruct_send.flag == 131)
      {
        packetWriter.Write((byte) 131);
        packetWriter.Write((byte) this.myIndex);
        packetWriter.Write(this.cuttyStruct_send.dur);
        packetWriter.Write(this.cuttyStruct_send.destx);
        packetWriter.Write(this.cuttyStruct_send.destz);
      }
      if (this.cuttyStruct_send.flag == 132)
      {
        packetWriter.Write((byte) 132);
        packetWriter.Write((byte) this.myIndex);
        packetWriter.Write(this.cuttyStruct_send.dur);
        packetWriter.Write(this.cuttyStruct_send.destx);
        packetWriter.Write(this.cuttyStruct_send.destz);
        packetWriter.Write(this.cuttyStruct_send.rot);
      }
      if (this.cuttyStruct_send.flag == 133)
      {
        packetWriter.Write((byte) 133);
        packetWriter.Write((byte) this.myIndex);
        packetWriter.Write(this.cuttyStruct_send.dur);
        packetWriter.Write(this.cuttyStruct_send.destx);
        packetWriter.Write(this.cuttyStruct_send.destz);
        packetWriter.Write(this.cuttyStruct_send.rot);
      }
      this.actionScheduled = false;
    }

    private void scheduleAction(int flag)
    {
      this.delay = 0.0f;
      this.delay = (float) Math.Round((double) this.delay * 0.059999998658895493);
      this.timeDelay = this.timeframe + (int) this.delay;
      if (this.timeDelay <= this.lasttimeDelay && this.lasttimeDelay - this.timeDelay < 60)
        this.timeDelay = this.lasttimeDelay + 1;
      this.lasttimeDelay = this.timeDelay;
      this.timeDelay = this.timeframe;
      if (flag == 130)
      {
        this.cuttyStruct_send.flag = flag;
        this.cuttyStruct_send.time = this.timeDelay;
        this.cuttyStruct_send.homing = this.cuttyStruct.homing;
        this.cuttyStruct_send.curveIndex = this.cuttyStruct.curveIndex;
        this.cuttyStruct_send.targetRate = this.cuttyStruct.targetRate;
        this.cuttyStruct_send.loop = this.cuttyStruct.loop;
        this.cuttyStruct_send.animType = this.cuttyStruct.animType;
        this.cuttyStruct_send.talkindex = this.cuttyStruct.talkindex;
      }
      if (flag == 131)
      {
        this.cuttyStruct_send.flag = flag;
        this.cuttyStruct_send.time = this.timeDelay;
        this.cuttyStruct_send.dur = this.cuttyStruct.dur;
        this.cuttyStruct_send.destx = this.cuttyStruct.destx;
        this.cuttyStruct_send.destz = this.cuttyStruct.destz;
      }
      if (flag == 132)
      {
        this.cuttyStruct_send.flag = flag;
        this.cuttyStruct_send.time = this.timeDelay;
        this.cuttyStruct_send.dur = this.cuttyStruct.dur;
        this.cuttyStruct_send.destx = this.cuttyStruct.destx;
        this.cuttyStruct_send.destz = this.cuttyStruct.destz;
        this.cuttyStruct_send.rot = this.cuttyStruct.rot;
      }
      if (flag == 133)
      {
        this.cuttyStruct_send.flag = flag;
        this.cuttyStruct_send.time = this.timeDelay;
        this.cuttyStruct_send.dur = this.cuttyStruct.dur;
        this.cuttyStruct_send.destx = this.cuttyStruct.destx;
        this.cuttyStruct_send.destz = this.cuttyStruct.destz;
        this.cuttyStruct_send.rot = this.cuttyStruct.rot;
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
          this.cuttyAction(ref this.tempConduct, true, ref heights);
          this.scheduleList.RemoveAt(index);
        }
      }
    }

    public void cuttyAction(ref Cutty.conductor tempy, bool isLocal, ref float[,] heights)
    {
      if (tempy.flag == 130)
      {
        if (this.cuttyHeal)
        {
          this.cuttyHeal = false;
          this.glowTimer = 0.0f;
          Cutty.gonnaHealindex = -1;
          this.gonnaHealDelay = 600f;
          this.newAction = false;
        }
        this.homing = tempy.homing;
        this.curveIndex = tempy.curveIndex;
        this.targetRate = tempy.targetRate;
        this.loop = tempy.loop;
        if (tempy.animType != 0)
        {
          if (tempy.animType == 1)
            this.animManager("bite");
          if (tempy.animType == 2)
            this.animManager("bite2");
        }
        if (tempy.talkindex > -1)
        {
          this.talkIndex = tempy.talkindex;
          Cutty.whichPigTalks = this.myIndex;
        }
        else
        {
          Cutty.cuttyDoneSpeech = true;
          this.cuttyDoneLocalSpeech = true;
        }
      }
      if (tempy.flag == 131)
      {
        this.newAction = true;
        this.attack1 = true;
        this.homing = 0;
        this.pigFrame1 = 0.0f;
        this.attacktimer = 0.0f;
        this.attackWait1 = 42.5f;
        this.attackWait2 = 62f;
        this.origx = this.cuttyPos.X;
        this.origy = this.cuttyPos.Y;
        this.origz = this.cuttyPos.Z;
        this.destx = tempy.destx;
        this.destz = tempy.destz;
        Cutty.GetHeightFast(ref heights, new Vector2(this.destx, this.destz), out this.desty);
        this.attackduration = (float) tempy.dur;
        this.attackduration = MathHelper.Lerp(70f, 90f, (float) (((double) this.attackduration - 300.0) / 900.0));
        this.grav = 0.55f;
        if ((double) this.desty > (double) this.origy && (double) this.desty > 50.0)
          this.grav += MathHelper.Lerp(0.0f, 0.7f, (float) (((double) this.desty - (double) this.origy) / 500.0));
        this.upForce = this.grav * (this.attackduration / 2f);
        if ((double) this.desty > (double) this.origy && (double) this.desty > 50.0)
          this.attackduration -= MathHelper.Lerp(0.0f, 15f, (float) (((double) this.desty - (double) this.origy) / 500.0));
      }
      if (tempy.flag == 132)
      {
        this.newAction = true;
        this.death1 = true;
        this.cuttyisDead = false;
        this.cuttyDeathTimer = 500f;
        this.health = (ushort) 0;
        this.homing = 0;
        if (Cutty.homingLocal == this.myIndex)
          Cutty.homingLocal = -1;
        if (Cutty.homingRemote == this.myIndex)
          Cutty.homingRemote = -1;
        this.cuttyDyingWalk = true;
        this.cuttyDeadrot = tempy.rot;
        this.cuttyDeadx = tempy.destx;
        this.cuttyDeadz = tempy.destz;
      }
      if (tempy.flag != 133)
        return;
      this.newAction = true;
      this.pigFrame1 = 0.0f;
      this.homing = 0;
      this.cuttyHeal = true;
      Cutty.gonnaHealindex = this.myIndex;
      this.glowTimer = 1f;
      this.healtimer = 0.0f;
      this.healWait1 = 42.5f;
      this.healWait2 = 62f;
      this.healChant = 800f;
      this.healorigx = this.cuttyPos.X;
      this.healorigy = this.cuttyPos.Y;
      this.healorigz = this.cuttyPos.Z;
      this.healdestx = tempy.destx;
      this.healdestz = tempy.destz;
      this.cuttyHealrot = tempy.rot;
      Cutty.GetHeightFast(ref heights, new Vector2(this.healdestx, this.healdestz), out this.healdesty);
      this.healduration = (float) tempy.dur;
      this.healduration = MathHelper.Clamp(this.healduration / 10f, 70f, 110f);
      this.grav = 0.55f;
      if ((double) this.healdesty > (double) this.healorigy && (double) this.healdesty > 50.0)
        this.grav += MathHelper.Lerp(0.0f, 0.7f, (float) (((double) this.healdesty - (double) this.healorigy) / 500.0));
      this.upForce = this.grav * (this.healduration / 2f);
      if ((double) this.healdesty <= (double) this.healorigy || (double) this.healdesty <= 50.0)
        return;
      this.healduration -= MathHelper.Lerp(0.0f, 15f, (float) (((double) this.healdesty - (double) this.healorigy) / 500.0));
    }

    private static float WrapAngle(float radians)
    {
      while ((double) radians < -3.1415927410125732)
        radians += 6.28318548f;
      while ((double) radians > 3.1415927410125732)
        radians -= 6.28318548f;
      return radians;
    }

    private void initTarget()
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

    public void addTargetBlood(int index, int xmin, int xmax, int ymin, int ymax)
    {
      int minValue1 = (int) ((double) xmin * 0.58499997854232788);
      int minValue2 = (int) ((double) ymin * 0.58499997854232788);
      int maxValue1 = (int) ((double) xmax * 0.58499997854232788);
      int maxValue2 = (int) ((double) ymax * 0.58499997854232788);
      Rectangle rectangle = this.sc.woundRect[index];
      Color color = (new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue) * ((float) this.rr.Next(40, 100) / 100f)) with
      {
        A = byte.MaxValue
      };
      if (this.targetChoice == 2)
      {
        this.sc.GraphicsDevice.SetRenderTarget(this.screenTarget1);
        this.sc.GraphicsDevice.Clear(Color.Transparent);
        this.spriteBatch.Begin();
        this.spriteBatch.Draw((Texture2D) this.screenTarget2, Vector2.Zero, Color.White);
        this.spriteBatch.Draw(this.sc.wound, new Vector2((float) this.rr.Next(minValue1, maxValue1), (float) this.rr.Next(minValue2, maxValue2)), new Rectangle?(rectangle), color, (float) this.rr.Next(-800, 800) / 100f, new Vector2(32f, 32f), (float) this.rr.Next(80, 100) / 100f, SpriteEffects.None, 0.0f);
        this.spriteBatch.End();
        this.sc.GraphicsDevice.SetRenderTarget((RenderTarget2D) null);
        this.pigSkin.Parameters["BloodTexture"].SetValue((Texture) this.screenTarget1);
        this.targetChoice = 1;
      }
      else
      {
        this.sc.GraphicsDevice.SetRenderTarget(this.screenTarget2);
        this.sc.GraphicsDevice.Clear(Color.Transparent);
        this.spriteBatch.Begin();
        this.spriteBatch.Draw((Texture2D) this.screenTarget1, Vector2.Zero, Color.White);
        this.spriteBatch.Draw(this.sc.wound, new Vector2((float) this.rr.Next(minValue1, maxValue1), (float) this.rr.Next(minValue2, maxValue2)), new Rectangle?(rectangle), color, (float) this.rr.Next(-800, 800) / 100f, new Vector2(32f, 32f), (float) this.rr.Next(80, 100) / 100f, SpriteEffects.None, 0.0f);
        this.spriteBatch.End();
        this.sc.GraphicsDevice.SetRenderTarget((RenderTarget2D) null);
        this.pigSkin.Parameters["BloodTexture"].SetValue((Texture) this.screenTarget2);
        this.targetChoice = 2;
      }
    }

    public void Draw(
      Vector3 campos,
      Matrix view,
      Matrix proj,
      bool showSphere,
      ref Texture2D ttworld,
      Matrix viewWorld,
      int tech)
    {
      this.view = view;
      this.proj = proj;
      if (this.chunk.startDrop)
        this.DrawInstance(this.chunk, "fastShader");
      if (this.faceChunk.startDrop)
        this.DrawInstance(this.faceChunk, "fastShader");
      if (this.assChunk.startDrop)
        this.DrawInstance(this.assChunk, "fastShader");
      this.drawCutty(ref ttworld, viewWorld, tech);
      if (this.showSkelTimer <= 0)
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

    public void DrawFireBall() => this.DrawGrenadeExplosion(ref this.fireball, Matrix.Identity);

    public void DrawEyes(Vector3 campos)
    {
      float num = 0.9f;
      if (this.cuttyHeal)
        num = 0.4f + Math.Abs((float) (Math.Sin((double) this.sc.myTimer / 14.0) * 1.6000000238418579));
      Vector3 vector3_1 = Vector3.Transform(Vector3.Zero, Matrix.CreateTranslation(26.98f, 101f, 167.34f) * this.cuttyBone[7]);
      Vector3 objectPosition1 = vector3_1 + Vector3.Normalize(campos - vector3_1) * 12f;
      this.drawEye(Matrix.CreateScale(num * this.eyeGlow) * Matrix.CreateBillboard(objectPosition1, campos, this.view.Up, new Vector3?(this.view.Forward)));
      Vector3 vector3_2 = Vector3.Transform(Vector3.Zero, Matrix.CreateTranslation(-35.36717f, 101f, 167.34f) * this.cuttyBone[7]);
      Vector3 objectPosition2 = vector3_2 + Vector3.Normalize(campos - vector3_2) * 12f;
      this.drawEye(Matrix.CreateScale(num * this.eyeGlow) * Matrix.CreateBillboard(objectPosition2, campos, this.view.Up, new Vector3?(this.view.Forward)));
      this.sparks.SetCamera(this.view, this.proj);
      this.sparks.Draw(0);
      this.dots.SetCamera(this.view, this.proj);
      this.dots.Draw(0);
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

    private void drawCutty(ref Texture2D ttWorld, Matrix viewWorld, int tech)
    {
      float num1 = 0.0f;
      this.pigModel.Meshes[this.pigIndex].MeshParts[0].Effect = this.pigSkin;
      this.pigSkin.Parameters["darkness"].SetValue(MathHelper.Lerp(0.0f, 1.2f, this.sc.darkness));
      this.pigSkin.Parameters["gDiffuse"].SetValue((Texture) ttWorld);
      this.pigSkin.Parameters["projectorView"].SetValue(viewWorld);
      if ((double) this.glowTimer > 0.0)
      {
        float num2 = (float) Math.Abs(Math.Sin((double) this.sc.myTimer / 24.0) * 1.5);
        num1 = (float) Math.Sin((double) this.sc.myTimer / 8.0) / 4f;
        this.pigSkin.Parameters["glow"].SetValue(0.2f + num2);
        this.pigSkin.Parameters["slide"].SetValue(this.sc.myTimer * (3f / 1000f));
        this.pigSkin.Parameters["darkness"].SetValue(MathHelper.Lerp(0.4f, 1.2f, this.sc.darkness));
        tech = 5;
      }
      this.pigSkin.Parameters["eyeglow"].SetValue(this.eyeGlow + num1);
      this.pigSkin.Parameters["amb"].SetValue(new Vector3(0.8f, 0.8f, 0.8f));
      this.pigSkin.Parameters["diff"].SetValue(new Vector3(0.7f, 0.7f, 0.7f));
      this.pigSkin.Parameters["LightDirection"].SetValue(new Vector3(0.7f, -0.7f, 0.0f));
      this.pigSkin.Parameters["View"].SetValue(this.view);
      this.pigSkin.Parameters["Projection"].SetValue(this.proj);
      this.pigSkin.Parameters["Bones"].SetValue(this.a.skinTransforms);
      this.pigSkin.CurrentTechnique = this.pigSkin.Techniques[tech];
      this.pigModel.Meshes[this.pigIndex].Draw();
    }

    public void drawCutty_Glow()
    {
      Vector3 vector3 = new Vector3(0.3f, 0.3f, 0.6f) * (float) (Math.Sin((double) this.sc.myTimer / 50.0) / 2.0 + 0.5);
      this.pigModel.Meshes[this.pigIndex].MeshParts[0].Effect = this.solidSkin;
      this.solidSkin.Parameters["View"].SetValue(this.view);
      this.solidSkin.Parameters["Projection"].SetValue(this.proj);
      this.solidSkin.Parameters["color"].SetValue(vector3);
      this.solidSkin.Parameters["Bones"].SetValue(this.a.skinTransforms);
      this.solidSkin.CurrentTechnique = this.solidSkin.Techniques["SkinnedEffect"];
      this.pigModel.Meshes[this.pigIndex].Draw();
    }

    public void spiralGlow()
    {
      float num1 = 15f;
      Vector2[] vector2Array = new Vector2[24];
      for (int index = 0; index < 24; ++index)
      {
        float num2 = (float) -index;
        vector2Array[index] = new Vector2((float) Math.Sin((double) MathHelper.ToRadians(num2 * num1)), -1.4f * (float) Math.Cos((double) MathHelper.ToRadians((float) (180.0 + (double) num2 * (double) num1))));
      }
      this.glowEffect.Parameters["offsets"].SetValue(vector2Array);
      this.glowEffect.Parameters["glowdist"].SetValue(0.005f);
    }

    private void drawCuttySkel()
    {
      this.sc.pigAll.Meshes[0].MeshParts[0].Effect = this.pigSkin;
      this.pigSkin.Parameters["View"].SetValue(this.view);
      this.pigSkin.Parameters["Projection"].SetValue(this.proj);
      this.pigSkin.Parameters["Bones"].SetValue(this.a.skinTransforms);
      this.pigSkin.CurrentTechnique = this.pigSkin.Techniques[3];
      this.sc.pigAll.Meshes[0].Draw();
    }

    private void drawEye(Matrix world)
    {
      float num = this.eyeGlow;
      if ((double) this.eyeGlow < 0.699999988079071)
      {
        if ((double) this.rr.Next(1, 1000) < 1000.0 / (double) this.eyeGlow)
          num += (float) this.rr.Next(-100, 100) / 500f;
        if ((double) num < 0.0)
          num = 0.0f;
      }
      this.eyeglow.Meshes[0].MeshParts[0].Effect = this.eyeEffect;
      this.eyeEffect.Parameters["darkness"].SetValue(num);
      this.eyeEffect.Parameters["View"].SetValue(this.view);
      this.eyeEffect.Parameters["Projection"].SetValue(this.proj);
      this.eyeEffect.Parameters[nameof (world)].SetValue(world);
      this.eyeEffect.CurrentTechnique = this.eyeEffect.Techniques[0];
      this.eyeglow.Meshes[0].Draw();
    }

    private void shockWave(ref float[,] heights)
    {
      if ((double) this.shockTimer > 10.0)
        this.sc.darkness = this.rr.Next(1, 100) >= 40 ? (float) this.rr.Next(5, 50) / 100f : (float) this.rr.Next(110, 170) / 100f;
      if ((double) this.shockTimer == 5.0)
        this.sc.darkness = this.olderDarkness;
      --this.shockTimer;
      this.shockRadius += (float) this.rr.Next(7, 12);
      if (!this.shockHasHit && (double) this.shockRadius < 1000.0 && (double) Vector3.Distance(this.playerpos, this.cuttyPos) < (double) this.shockRadius)
      {
        this.shockHasHit = true;
        this.shockHit = true;
      }
      Vector3 up = Vector3.Up;
      float num1 = 70f / (float) (2.0 * (double) this.shockRadius * 3.1400001049041748);
      if ((double) num1 < 0.019999999552965164)
        num1 = 0.02f;
      float maxValue1 = (float) (this.rr.Next(1700, 2700) / 100) * (float) (((double) this.shockTimer + 1.0) * 2.0);
      for (float radians = 0.0f; (double) radians < 6.28000020980835; radians += num1)
      {
        Vector3 vector3_1 = Vector3.Transform(new Vector3(this.shockRadius, 0.0f, 0.0f), Matrix.CreateRotationY(radians));
        vector3_1.X += this.cuttyPos.X + (float) this.rr.Next(-12, 12);
        vector3_1.Z += this.cuttyPos.Z + (float) this.rr.Next(-12, 12);
        Cutty.GetHeightFast(ref heights, new Vector2(vector3_1.X, vector3_1.Z), out vector3_1.Y);
        int num2 = this.rr.Next(1, 3);
        for (int index = 0; index < num2; ++index)
        {
          int maxValue2 = this.rr.Next(0, 50);
          Vector3 vector3_2 = new Vector3((float) this.rr.Next(-maxValue2, maxValue2) / 100f, 0.0f, (float) this.rr.Next(-maxValue2, maxValue2) / 100f);
          this.sparks.AddParticle(vector3_1 + vector3_2, new Vector3(0.0f, 1f, 0.0f) * (float) this.rr.Next(0, (int) maxValue1) / 10f);
        }
      }
    }

    private void energize(Vector3 pos)
    {
      Vector3 vector3_1 = new Vector3((float) this.rr.Next(-1000, 1000), (float) this.rr.Next(1000, 2000), (float) this.rr.Next(-1000, 1000));
      Vector3 vector3_2 = new Vector3((float) this.rr.Next(-100, 100), 0.0f, (float) this.rr.Next(-100, 100));
      this.dots.AddParticle(vector3_1 + (pos + vector3_2), -vector3_1 / 4f);
    }

    private void DrawGrenadeExplosion(ref Cutty.hole hole, Matrix world)
    {
      int stainMax = hole.stainMax;
      if (stainMax < 1)
        return;
      ModelMeshPart meshPart = this.sc.fireballDecal.Meshes[0].MeshParts[0];
      hole.stainBuffer.SetData<Cutty.hitStream>(hole.stainTrans, 0, stainMax, SetDataOptions.Discard);
      Effect effect = meshPart.Effect;
      effect.CurrentTechnique = effect.Techniques["premultiply"];
      effect.Parameters["World1"].SetValue(world);
      effect.Parameters["View"].SetValue(this.view);
      effect.Parameters["Projection"].SetValue(this.proj);
      effect.CurrentTechnique.Passes[0].Apply();
      this._vertexBufferBindings[0] = new VertexBufferBinding(meshPart.VertexBuffer, meshPart.VertexOffset, 0);
      this._vertexBufferBindings[1] = new VertexBufferBinding((VertexBuffer) hole.stainBuffer, 0, 1);
      this.sc.GraphicsDevice.SetVertexBuffers(this._vertexBufferBindings);
      this.sc.GraphicsDevice.Indices = meshPart.IndexBuffer;
      this.sc.GraphicsDevice.DrawInstancedPrimitives(PrimitiveType.TriangleList, 0, 0, meshPart.NumVertices, meshPart.StartIndex, meshPart.PrimitiveCount, stainMax);
    }

    private void DrawInstance(Cutty.shell shell, string tech)
    {
      int tempindex = shell.tempindex;
      if (tempindex < 1)
        return;
      ModelMeshPart meshPart = shell.model.Meshes[0].MeshParts[0];
      shell.buffer.SetData<Cutty.instancedObject>(shell.displayList, 0, tempindex, SetDataOptions.Discard);
      Effect effect = meshPart.Effect;
      effect.Parameters["amb"].SetValue(new Vector3(0.8f, 0.8f, 0.8f));
      effect.Parameters["diff"].SetValue(new Vector3(0.7f, 0.7f, 0.7f));
      effect.Parameters["LightDirection"].SetValue(new Vector3(0.7f, -0.7f, 0.0f));
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

    private static void GetHeightFast(ref float[,] heights, Vector2 position, out float height)
    {
      int index1 = (int) MathHelper.Clamp(position.X / Cutty.unit, 0.0f, (float) (Cutty.bitmap - 2));
      int index2 = (int) MathHelper.Clamp(position.Y / Cutty.unit, 0.0f, (float) (Cutty.bitmap - 2));
      float num1 = position.X % Cutty.unit / Cutty.unit;
      float num2 = position.Y % Cutty.unit / Cutty.unit;
      float num3 = (float) ((1.0 - (double) num1) * (double) heights[index1, index2] + (double) num1 * (double) heights[index1 + 1, index2]);
      float num4 = (float) ((1.0 - (double) num1) * (double) heights[index1, index2 + 1] + (double) num1 * (double) heights[index1 + 1, index2 + 1]);
      height = (float) ((1.0 - (double) num2) * (double) num3 + (double) num2 * (double) num4);
    }

    public struct hitStream : IVertexType
    {
      public Matrix Trans;
      public float Fade;
      public Vector4 Coord;
      private static readonly VertexDeclaration VertexDeclaration = new VertexDeclaration(new VertexElement[6]
      {
        new VertexElement(0, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 0),
        new VertexElement(16, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 1),
        new VertexElement(32, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 2),
        new VertexElement(48, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 3),
        new VertexElement(64, VertexElementFormat.Single, VertexElementUsage.Fog, 0),
        new VertexElement(68, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 4)
      });

      VertexDeclaration IVertexType.VertexDeclaration => Cutty.hitStream.VertexDeclaration;
    }

    public struct hole
    {
      public float[] fade;
      public Vector3[] location;
      public int[] bone;
      public Cutty.hitStream[] stainTrans;
      public int[] frame;
      public Matrix[] scale;
      public int stainIndex;
      public int stainMax;
      public int stainCapacity;
      public DynamicVertexBuffer stainBuffer;
      public Vector4[] stainR;
    }

    public struct instancedObject : IVertexType
    {
      public Matrix Trans;
      private static readonly VertexDeclaration InstanceVertexDeclaration = new VertexDeclaration(new VertexElement[4]
      {
        new VertexElement(0, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 0),
        new VertexElement(16, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 1),
        new VertexElement(32, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 2),
        new VertexElement(48, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 3)
      });

      VertexDeclaration IVertexType.VertexDeclaration
      {
        get => Cutty.instancedObject.InstanceVertexDeclaration;
      }
    }

    public struct shell
    {
      public int type;
      public int max;
      public int tempindex;
      public int index;
      public int maxCapacity;
      public Matrix[] offset;
      public bool startDrop;
      public float dropTimer;
      public int[] bone;
      public Cutty.instancedObject[] stream;
      public DynamicVertexBuffer buffer;
      public Cutty.instancedObject[] displayList;
      public chunkDupe[] dupe;
      public Model model;
    }

    public struct conductor
    {
      public int flag;
      public int time;
      public int homing;
      public float targetRate;
      public int curveIndex;
      public float loop;
      public int animType;
      public int talkindex;
      public ushort dur;
      public float destx;
      public float destz;
      public float rot;
    }
  }
}
