// Decompiled with JetBrains decompiler
// Type: Blood.titles
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
  internal class titles : GameScreen
  {
    private int[] shakeX = new int[714]
    {
      526,
      494,
      526,
      492,
      526,
      490,
      526,
      488,
      526,
      486,
      526,
      484,
      526,
      482,
      528,
      482,
      530,
      482,
      532,
      482,
      534,
      482,
      536,
      482,
      538,
      482,
      540,
      482,
      542,
      482,
      544,
      482,
      546,
      482,
      548,
      482,
      550,
      482,
      552,
      482,
      554,
      482,
      555,
      483,
      556,
      484,
      557,
      485,
      557,
      487,
      557,
      489,
      557,
      491,
      558,
      492,
      558,
      494,
      558,
      496,
      557,
      497,
      556,
      498,
      555,
      499,
      574,
      498,
      574,
      496,
      574,
      494,
      574,
      492,
      573,
      491,
      573,
      489,
      573,
      487,
      571,
      487,
      569,
      487,
      569,
      485,
      569,
      483,
      568,
      482,
      570,
      482,
      572,
      482,
      574,
      482,
      576,
      482,
      578,
      482,
      580,
      482,
      582,
      482,
      584,
      482,
      586,
      482,
      588,
      482,
      588,
      484,
      587,
      485,
      586,
      486,
      585,
      487,
      583,
      487,
      581,
      487,
      581,
      489,
      581,
      491,
      581,
      493,
      581,
      495,
      581,
      497,
      598,
      493,
      599,
      492,
      600,
      491,
      600,
      489,
      601,
      488,
      601,
      486,
      603,
      486,
      604,
      485,
      605,
      484,
      607,
      483,
      609,
      483,
      610,
      482,
      612,
      482,
      614,
      482,
      616,
      481,
      618,
      480,
      620,
      480,
      622,
      480,
      624,
      480,
      626,
      480,
      628,
      480,
      630,
      480,
      631,
      481,
      633,
      481,
      634,
      482,
      636,
      483,
      637,
      484,
      637,
      486,
      637,
      488,
      637,
      490,
      636,
      491,
      636,
      493,
      676,
      494,
      677,
      492,
      678,
      491,
      679,
      489,
      680,
      488,
      682,
      488,
      683,
      487,
      684,
      486,
      685,
      485,
      687,
      484,
      688,
      483,
      690,
      483,
      692,
      483,
      693,
      482,
      695,
      482,
      697,
      482,
      699,
      482,
      701,
      482,
      703,
      482,
      704,
      483,
      706,
      483,
      707,
      484,
      708,
      485,
      710,
      486,
      711,
      488,
      720,
      490,
      721,
      489,
      722,
      488,
      724,
      486,
      725,
      485,
      727,
      483,
      729,
      483,
      731,
      482,
      733,
      482,
      734,
      481,
      736,
      481,
      738,
      481,
      740,
      481,
      742,
      481,
      744,
      482,
      746,
      483,
      747,
      484,
      749,
      484,
      751,
      484,
      752,
      486,
      754,
      487,
      755,
      489,
      773,
      489,
      774,
      488,
      774,
      486,
      775,
      484,
      776,
      483,
      778,
      483,
      780,
      483,
      782,
      483,
      784,
      483,
      786,
      483,
      788,
      483,
      790,
      483,
      792,
      483,
      794,
      483,
      796,
      483,
      798,
      483,
      800,
      483,
      801,
      484,
      803,
      485,
      803,
      487,
      804,
      489,
      804,
      491,
      821,
      490,
      821,
      488,
      821,
      486,
      821,
      484,
      822,
      483,
      824,
      483,
      827,
      483,
      829,
      483,
      832,
      483,
      835,
      483,
      837,
      483,
      839,
      483,
      841,
      483,
      843,
      484,
      845,
      485,
      846,
      486,
      847,
      488,
      848,
      489,
      848,
      491,
      862,
      490,
      863,
      489,
      865,
      488,
      866,
      487,
      868,
      486,
      869,
      484,
      871,
      484,
      872,
      483,
      874,
      482,
      876,
      482,
      879,
      481,
      881,
      481,
      883,
      481,
      885,
      481,
      886,
      482,
      887,
      483,
      888,
      484,
      890,
      485,
      892,
      486,
      894,
      486,
      896,
      486,
      898,
      485,
      900,
      485,
      899,
      486,
      916,
      494,
      916,
      492,
      917,
      490,
      918,
      488,
      918,
      486,
      917,
      485,
      916,
      484,
      918,
      484,
      921,
      484,
      924,
      484,
      926,
      484,
      929,
      484,
      932,
      484,
      933,
      483,
      936,
      483,
      938,
      483,
      940,
      483,
      942,
      484,
      943,
      486,
      944,
      487,
      944,
      489,
      944,
      491,
      945,
      492,
      970,
      494,
      970,
      492,
      971,
      491,
      972,
      489,
      972,
      486,
      973,
      485,
      974,
      484,
      975,
      482,
      977,
      482,
      979,
      483,
      979,
      485,
      980,
      486,
      980,
      488,
      980,
      490,
      980,
      492,
      982,
      492,
      983,
      493,
      1001,
      487,
      1001,
      485,
      1001,
      483,
      1003,
      483,
      1006,
      483,
      1009,
      483,
      1012,
      483,
      1015,
      483,
      1020,
      483,
      1022,
      483,
      1024,
      483,
      1026,
      483,
      1028,
      484,
      1030,
      484,
      1032,
      484,
      1034,
      484,
      1036,
      484,
      1037,
      483,
      1039,
      483,
      1040,
      484,
      1039,
      485,
      1048,
      486,
      1048,
      484,
      1049,
      483,
      1050,
      482,
      1051,
      481,
      1053,
      481,
      1055,
      481,
      1057,
      481,
      1059,
      481,
      1061,
      481,
      1062,
      480,
      1064,
      480,
      1066,
      480,
      1067,
      481,
      1067,
      483,
      1068,
      484,
      1079,
      492,
      1080,
      491,
      1082,
      490,
      1084,
      488,
      1086,
      487,
      1088,
      486,
      1090,
      486,
      1091,
      485,
      1093,
      485,
      1095,
      484,
      1097,
      483,
      1099,
      483,
      1102,
      483,
      1104,
      483,
      1106,
      483,
      1108,
      483,
      1109,
      484,
      1111,
      485,
      1112,
      487,
      1114,
      489,
      1114,
      491,
      1116,
      492,
      1117,
      493,
      1132,
      492,
      1132,
      490,
      1132,
      488,
      1132,
      486,
      1132,
      484,
      1133,
      483,
      1134,
      482,
      1135,
      481,
      1137,
      481,
      1139,
      481,
      1141,
      481,
      1142,
      482,
      1143,
      483,
      1144,
      485,
      1144,
      487,
      1145,
      489,
      1148,
      491,
      1150,
      494,
      1151,
      495,
      1151,
      497,
      1152,
      499,
      1153,
      500,
      1154,
      501,
      1155,
      502,
      1156,
      503,
      1158,
      503,
      1160,
      503,
      1161,
      502,
      1162,
      501,
      1163,
      499,
      1163,
      497,
      1163,
      495,
      1163,
      493,
      1163,
      491,
      1163,
      489,
      1163,
      487,
      1163,
      484,
      1163,
      482,
      1164,
      481,
      1166,
      481,
      1167,
      482,
      1167,
      484,
      1167,
      486,
      1166,
      487,
      1166,
      489,
      1166,
      491,
      1166,
      492
    };
    private int[] shakeX2 = new int[746]
    {
      526,
      517,
      526,
      519,
      526,
      521,
      526,
      523,
      526,
      525,
      526,
      527,
      526,
      529,
      527,
      531,
      529,
      531,
      531,
      531,
      533,
      531,
      535,
      531,
      537,
      531,
      539,
      531,
      541,
      531,
      543,
      531,
      545,
      531,
      547,
      531,
      549,
      531,
      551,
      530,
      552,
      529,
      553,
      528,
      555,
      528,
      556,
      527,
      557,
      525,
      558,
      524,
      558,
      522,
      559,
      521,
      560,
      519,
      569,
      525,
      569,
      527,
      569,
      529,
      570,
      530,
      572,
      530,
      574,
      530,
      576,
      530,
      578,
      530,
      580,
      530,
      582,
      530,
      583,
      531,
      585,
      531,
      587,
      531,
      587,
      529,
      587,
      527,
      585,
      527,
      601,
      522,
      602,
      524,
      604,
      526,
      605,
      527,
      606,
      528,
      608,
      528,
      609,
      529,
      610,
      530,
      611,
      531,
      612,
      532,
      614,
      532,
      616,
      532,
      618,
      532,
      620,
      532,
      622,
      532,
      624,
      532,
      626,
      532,
      627,
      531,
      629,
      530,
      631,
      530,
      633,
      530,
      634,
      529,
      636,
      529,
      637,
      528,
      637,
      526,
      637,
      524,
      637,
      522,
      675,
      519,
      676,
      520,
      677,
      521,
      679,
      523,
      680,
      524,
      681,
      526,
      682,
      527,
      683,
      528,
      685,
      528,
      687,
      529,
      688,
      530,
      689,
      531,
      691,
      531,
      692,
      532,
      694,
      532,
      696,
      532,
      698,
      532,
      700,
      532,
      702,
      532,
      703,
      531,
      705,
      530,
      706,
      529,
      708,
      528,
      709,
      527,
      710,
      525,
      710,
      523,
      720,
      520,
      721,
      521,
      722,
      522,
      722,
      524,
      724,
      524,
      725,
      525,
      727,
      525,
      728,
      526,
      728,
      528,
      729,
      529,
      730,
      530,
      732,
      530,
      733,
      531,
      735,
      531,
      736,
      532,
      738,
      533,
      739,
      532,
      741,
      532,
      744,
      531,
      745,
      530,
      747,
      530,
      749,
      530,
      750,
      529,
      752,
      529,
      753,
      528,
      754,
      527,
      755,
      526,
      756,
      525,
      757,
      524,
      757,
      522,
      758,
      521,
      774,
      522,
      774,
      524,
      774,
      526,
      774,
      528,
      775,
      529,
      777,
      529,
      778,
      530,
      780,
      529,
      780,
      527,
      780,
      525,
      779,
      524,
      778,
      523,
      778,
      521,
      778,
      519,
      778,
      517,
      779,
      516,
      794,
      521,
      795,
      523,
      796,
      525,
      797,
      527,
      798,
      528,
      799,
      529,
      800,
      530,
      802,
      530,
      804,
      530,
      806,
      530,
      808,
      530,
      808,
      528,
      807,
      527,
      806,
      526,
      805,
      525,
      804,
      523,
      821,
      523,
      822,
      524,
      823,
      526,
      824,
      528,
      823,
      529,
      821,
      529,
      821,
      531,
      823,
      531,
      825,
      532,
      826,
      531,
      826,
      529,
      826,
      527,
      827,
      526,
      827,
      524,
      861,
      520,
      862,
      521,
      863,
      522,
      863,
      524,
      865,
      524,
      865,
      526,
      866,
      527,
      867,
      528,
      869,
      528,
      870,
      529,
      871,
      530,
      873,
      530,
      875,
      530,
      877,
      530,
      879,
      531,
      881,
      531,
      883,
      531,
      884,
      530,
      886,
      529,
      888,
      529,
      890,
      528,
      892,
      528,
      893,
      527,
      894,
      526,
      895,
      525,
      896,
      524,
      897,
      522,
      915,
      521,
      916,
      523,
      916,
      525,
      916,
      527,
      916,
      529,
      916,
      531,
      918,
      531,
      920,
      531,
      921,
      530,
      921,
      528,
      921,
      526,
      921,
      524,
      921,
      522,
      934,
      521,
      935,
      523,
      936,
      524,
      937,
      526,
      938,
      527,
      940,
      527,
      941,
      528,
      943,
      528,
      944,
      529,
      945,
      530,
      947,
      530,
      949,
      531,
      951,
      531,
      951,
      529,
      949,
      529,
      948,
      528,
      947,
      527,
      947,
      525,
      945,
      525,
      945,
      523,
      959,
      523,
      958,
      524,
      957,
      525,
      957,
      527,
      956,
      528,
      956,
      530,
      958,
      530,
      960,
      530,
      961,
      529,
      962,
      528,
      963,
      527,
      964,
      526,
      964,
      524,
      965,
      523,
      966,
      521,
      967,
      520,
      968,
      519,
      969,
      518,
      971,
      518,
      973,
      518,
      975,
      518,
      977,
      518,
      986,
      523,
      987,
      524,
      988,
      525,
      988,
      527,
      989,
      528,
      990,
      529,
      991,
      530,
      993,
      530,
      995,
      531,
      997,
      531,
      998,
      529,
      998,
      527,
      997,
      526,
      996,
      525,
      996,
      523,
      995,
      522,
      994,
      521,
      1017,
      521,
      1017,
      523,
      1016,
      524,
      1016,
      526,
      1016,
      528,
      1017,
      529,
      1018,
      530,
      1020,
      530,
      1022,
      530,
      1023,
      529,
      1023,
      527,
      1024,
      526,
      1024,
      524,
      1024,
      522,
      1024,
      520,
      1054,
      524,
      1053,
      525,
      1052,
      526,
      1051,
      525,
      1049,
      525,
      1047,
      525,
      1047,
      527,
      1047,
      529,
      1048,
      530,
      1050,
      531,
      1052,
      531,
      1054,
      531,
      1056,
      531,
      1058,
      530,
      1060,
      530,
      1062,
      530,
      1064,
      530,
      1066,
      530,
      1066,
      528,
      1067,
      527,
      1080,
      522,
      1081,
      523,
      1082,
      524,
      1084,
      526,
      1086,
      527,
      1088,
      527,
      1089,
      528,
      1089,
      530,
      1091,
      531,
      1093,
      532,
      1095,
      532,
      1097,
      532,
      1099,
      532,
      1101,
      532,
      1102,
      531,
      1104,
      531,
      1105,
      530,
      1107,
      530,
      1108,
      529,
      1110,
      529,
      1112,
      529,
      1113,
      528,
      1114,
      527,
      1115,
      526,
      1116,
      524,
      1117,
      523,
      1117,
      521,
      1132,
      522,
      1131,
      523,
      1130,
      525,
      1130,
      527,
      1131,
      529,
      1132,
      530,
      1133,
      531,
      1135,
      531,
      1137,
      531,
      1137,
      529,
      1138,
      528,
      1139,
      527,
      1139,
      525,
      1139,
      523,
      1139,
      521,
      1139,
      519,
      1139,
      517,
      1153,
      519,
      1154,
      520,
      1155,
      522,
      1156,
      523,
      1156,
      525,
      1157,
      526,
      1158,
      527,
      1159,
      528,
      1159,
      530,
      1161,
      530,
      1163,
      529,
      1165,
      529,
      1165,
      527,
      1165,
      525,
      1165,
      523,
      1166,
      522,
      1166,
      520,
      1167,
      519,
      1168,
      518,
      1168,
      517
    };
    private float partyDelay;
    private float x;
    private float z;
    private Effect blurEffect;
    private RenderTarget2D resolveTarget;
    private int doneonce;
    private ContentManager content;
    private SpriteBatch spriteBatch;
    private SpriteFont font;
    private SpriteFont font2;
    private Texture2D blankTexture;
    private Model logo;
    private Model stars;
    private float fadeup2;
    private float fadeup1;
    public float timer;
    private float titlecutoff = 8f;
    public int horn;
    private float horntimer;
    private float mytrans = (float) byte.MaxValue;
    private bool lightson;
    private float counter = 1f;
    private int moveflag;
    private int finished;
    private Vector3 where = new Vector3(62f, 10f, 55f);
    private Vector3 hover = new Vector3(0.0f, 0.0f, 0.0f);
    private float hx = 0.0009f;
    private float hy = -1f / 1000f;
    private float hz = -0.0003f;
    private Matrix projectionMatrix;
    private Matrix viewMatrix;
    private float britecount;
    private float howlong;
    private int freq = 3;
    private byte brite;
    private GamePadState previousgamepadstate;
    private Random random;
    private Texture2D bigcorp;
    private Texture2D glower;
    private SoundEffect radiotalk1;
    private SoundEffect spacewind;
    private SoundEffectInstance soundEffectInstance_0;
    private SoundEffectInstance spacewindI;
    private SoundEffect trumpet;
    private ParticleSystem sparks;
    private Matrix ellMatrix = Matrix.Identity;
    private Matrix twoMatrix = Matrix.Identity;
    private Matrix fiveMatrix = Matrix.Identity;
    private Matrix sevenMatrix = Matrix.Identity;
    private ModelBone ellBone;
    private ModelBone twoBone;
    private ModelBone fiveBone;
    private ModelBone sevenBone;
    private Matrix ellTransform;
    private Matrix twoTransform;
    private Matrix fiveTransform;
    private Matrix sevenTransform;
    private float ramper1 = -0.8f;
    private float ramper2 = -0.8f;
    private float ramper3 = -0.8f;
    private float ramper4 = -0.8f;
    private ScreenManager sc;

    public titles()
    {
      this.TransitionOnTime = TimeSpan.FromSeconds(0.0);
      this.TransitionOffTime = TimeSpan.FromSeconds(0.0);
    }

    public override void LoadContent()
    {
      this.sc = this.ScreenManager;
      if (this.content == null)
        this.content = new ContentManager((IServiceProvider) this.ScreenManager.Game.Services, "Content\\astro");
      GraphicsDevice graphicsDevice = this.ScreenManager.GraphicsDevice;
      this.blurEffect = this.content.Load<Effect>("shaders\\postShader");
      PresentationParameters presentationParameters = this.ScreenManager.GraphicsDevice.PresentationParameters;
      this.resolveTarget = new RenderTarget2D(this.sc.GraphicsDevice, 1280, 720, false, presentationParameters.BackBufferFormat, presentationParameters.DepthStencilFormat, presentationParameters.MultiSampleCount, RenderTargetUsage.DiscardContents);
      this.spriteBatch = new SpriteBatch(this.sc.GraphicsDevice);
      this.font = this.content.Load<SpriteFont>("fonts\\Opening");
      this.font2 = this.content.Load<SpriteFont>("fonts\\tag");
      this.blankTexture = this.content.Load<Texture2D>("menus\\blank");
      this.bigcorp = this.content.Load<Texture2D>("textures\\bigcorp");
      this.glower = this.content.Load<Texture2D>("sprites\\glower");
      this.projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(75f), this.sc.aspectratio2, 1f, 5690000f);
      this.viewMatrix = Matrix.CreateLookAt(new Vector3(0.0f, 0.0f, 70f), new Vector3(0.0f, 0.0f, 0.0f), Vector3.Up);
      this.logo = this.content.Load<Model>("models\\L257c");
      this.stars = this.content.Load<Model>("models\\dome3");
      this.radiotalk1 = this.content.Load<SoundEffect>("Audio\\radioTalk1");
      this.soundEffectInstance_0 = this.radiotalk1.CreateInstance();
      this.spacewind = this.content.Load<SoundEffect>("Audio\\spaceWindlow");
      this.spacewindI = this.spacewind.CreateInstance();
      this.trumpet = this.content.Load<SoundEffect>("Audio\\trumpet01");
      this.sparks = (ParticleSystem) new bcSystem(this.sc.Game, this.content);
      this.sparks.Initialize();
      this.sparks.LoadContent(this.sc.GraphicsDevice);
      this.random = new Random(8);
      this.ellBone = this.logo.Bones["ell"];
      this.twoBone = this.logo.Bones["two"];
      this.fiveBone = this.logo.Bones["five"];
      this.sevenBone = this.logo.Bones["seven"];
      this.ellTransform = this.ellBone.Transform;
      this.twoTransform = this.twoBone.Transform;
      this.fiveTransform = this.fiveBone.Transform;
      this.sevenTransform = this.sevenBone.Transform;
    }

    public override void UnloadContent() => this.content.Unload();

    public override void HandleInput(InputState input)
    {
      if (input == null)
        throw new ArgumentNullException(nameof (input));
      PlayerIndex playerIndex1 = PlayerIndex.One;
      for (PlayerIndex playerIndex2 = PlayerIndex.One; playerIndex2 <= PlayerIndex.Four; ++playerIndex2)
      {
        if (GamePad.GetState(playerIndex2).Buttons.Start == ButtonState.Pressed || GamePad.GetState(playerIndex2).Buttons.Back == ButtonState.Pressed)
        {
          playerIndex1 = playerIndex2;
          break;
        }
      }
      GamePadState state = GamePad.GetState(playerIndex1);
      if ((double) this.timer > 3.0 && state.Buttons.Start == ButtonState.Pressed || state.Buttons.Back == ButtonState.Pressed)
        this.finished = 1;
      if (this.finished == 2)
      {
        switch (playerIndex1)
        {
          case PlayerIndex.One:
            this.ScreenManager.oldgamer0 = 0;
            this.ScreenManager.oldgamercount = 0;
            break;
          case PlayerIndex.Two:
            this.ScreenManager.oldgamer1 = 0;
            this.ScreenManager.oldgamercount = 0;
            break;
          case PlayerIndex.Three:
            this.ScreenManager.oldgamer2 = 0;
            this.ScreenManager.oldgamercount = 0;
            break;
          case PlayerIndex.Four:
            this.ScreenManager.oldgamer3 = 0;
            this.ScreenManager.oldgamercount = 0;
            break;
        }
        if (this.spacewindI.State == SoundState.Playing)
          this.spacewindI.Stop();
        if (this.soundEffectInstance_0.State == SoundState.Playing)
          this.soundEffectInstance_0.Stop();
        LoadingScreen2.Load(this.ScreenManager, false, new PlayerIndex?(), (GameScreen) new Background(), (GameScreen) new MainMenuScreen());
      }
      this.previousgamepadstate = state;
    }

    public override void Update(
      GameTime gameTime,
      bool otherScreenHasFocus,
      bool coveredByOtherScreen)
    {
      base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
      float num = (float) (60.0 * gameTime.ElapsedGameTime.TotalSeconds);
      if (!this.IsActive)
        return;
      this.timer += 0.04f * num;
      if (this.spacewindI.State == SoundState.Stopped)
      {
        this.spacewindI.Volume = 1f;
        this.spacewindI.IsLooped = true;
        this.spacewindI.Play();
      }
      else
        this.spacewindI.Resume();
      this.sparks.Update(gameTime);
    }

    public void calcL257(float timeadjust)
    {
      this.x = -(float) Math.Sin((double) this.timer / 1.5);
      this.z = (float) Math.Cos((double) this.timer / 1.5);
      if ((double) this.z < 0.0)
        this.moveflag = 0;
      if ((double) this.z >= 0.99989998340606689 && this.moveflag == 0)
      {
        switch (this.counter)
        {
          case 1f:
            this.where = new Vector3(-68f, -12f, 59f);
            this.hover = new Vector3(0.0f, 0.0f, 0.0f);
            this.hx = 0.0006f;
            this.hy = 0.0006f;
            this.hz = -0.0009f;
            break;
          case 2f:
            this.where = new Vector3(23f, 10f, 58f);
            this.hover = new Vector3(0.0f, 0.0f, 0.0f);
            this.hx = 0.0004f;
            this.hy = -0.0022f;
            this.hz = -0.0003f;
            this.horntimer = 8f;
            break;
          case 3f:
            this.where = new Vector3(-38f, 0.0f, 39f);
            this.hover = new Vector3(0.0f, 0.0f, 0.0f);
            this.hx = 0.0003f;
            this.hy = 0.0008f;
            this.hz = 0.0018f;
            break;
          case 4f:
            this.where = new Vector3(0.0f, 0.0f, -30f);
            this.hover = new Vector3(0.0f, 0.0f, 0.0f);
            this.hx = 0.0f;
            this.hy = 0.0f;
            this.hz = -0.018f;
            this.fadeup2 = 0.0f;
            this.fadeup1 = 0.0f;
            this.horntimer = 0.01f * timeadjust;
            break;
        }
        this.moveflag = 1;
        ++this.counter;
      }
      if ((double) this.counter > 4.0)
      {
        this.lightson = true;
        this.projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(40f), this.sc.aspectratio2, 1f, 5490000f);
      }
      if ((double) this.horntimer > 0.0)
        this.horntimer -= 0.01666f * timeadjust;
      if ((double) this.horntimer < 0.0)
      {
        this.horntimer = 0.0f;
        this.trumpet.Play(0.5f, 0.0f, 0.0f);
      }
      this.hover.X += this.hx * timeadjust;
      this.hover.Y += this.hy * timeadjust;
      this.hover.Z += this.hz * timeadjust;
      if (!this.lightson)
        return;
      this.ramper1 += 0.000400000019f * timeadjust;
      this.ramper2 += 0.000400000019f * timeadjust;
      this.ramper3 += 0.000400000019f * timeadjust;
      this.ramper4 += 0.000400000019f * timeadjust;
      float amount1 = MathHelper.Clamp(this.ramper1, 0.0f, 1f);
      float amount2 = MathHelper.Clamp(this.ramper2, 0.0f, 1f);
      float amount3 = MathHelper.Clamp(this.ramper3, 0.0f, 1f);
      float amount4 = MathHelper.Clamp(this.ramper4, 0.0f, 1f);
      float radians1 = MathHelper.Hermite(2.1f, 0.0f, 0.0f, 0.0f, amount1);
      float radians2 = MathHelper.Hermite(1.75f, 0.0f, 0.0f, 0.0f, amount2);
      float radians3 = MathHelper.Hermite(1.375f, 0.0f, 0.0f, 0.0f, amount3);
      float radians4 = MathHelper.Hermite(1.05f, 0.0f, 0.0f, 0.0f, amount4);
      this.ellMatrix = Matrix.CreateRotationY(radians1);
      this.twoMatrix = Matrix.CreateRotationY(radians2);
      this.fiveMatrix = Matrix.CreateRotationY(radians3);
      this.sevenMatrix = Matrix.CreateRotationY(radians4);
      if ((double) this.ramper1 <= 0.0)
        return;
      this.ellTransform *= Matrix.CreateTranslation(1f / 1000f * timeadjust, 0.0f, 0.0f);
      this.twoTransform *= Matrix.CreateTranslation(0.0003f * timeadjust, 0.0f, 0.0f);
      this.fiveTransform *= Matrix.CreateTranslation(-0.0003f * timeadjust, 0.0f, 0.0f);
      this.sevenTransform *= Matrix.CreateTranslation(-1f / 1000f * timeadjust, 0.0f, 0.0f);
    }

    public override void Draw(GameTime gameTime)
    {
      float timeadjust = (float) (60.0 * gameTime.ElapsedGameTime.TotalSeconds);
      if ((double) this.timer > (double) this.titlecutoff)
      {
        this.sc.GraphicsDevice.SetRenderTarget(this.resolveTarget);
        this.ScreenManager.GraphicsDevice.Clear(Color.Transparent);
        this.RestoreRenderStates();
        foreach (ModelMesh mesh in this.logo.Meshes)
        {
          foreach (BasicEffect effect in mesh.Effects)
          {
            this.ellBone.Transform = this.ellMatrix * this.ellTransform;
            this.twoBone.Transform = this.twoMatrix * this.twoTransform;
            this.fiveBone.Transform = this.fiveMatrix * this.fiveTransform;
            this.sevenBone.Transform = this.sevenMatrix * this.sevenTransform;
            Matrix[] destinationBoneTransforms = new Matrix[this.logo.Bones.Count];
            this.logo.CopyAbsoluteBoneTransformsTo(destinationBoneTransforms);
            effect.World = destinationBoneTransforms[mesh.ParentBone.Index] * Matrix.CreateTranslation(this.where + this.hover);
            effect.View = this.viewMatrix;
            effect.Projection = this.projectionMatrix;
            effect.LightingEnabled = true;
            effect.DirectionalLight0.Enabled = true;
            effect.DirectionalLight1.Enabled = true;
            effect.DirectionalLight2.Enabled = true;
            effect.PreferPerPixelLighting = true;
            effect.SpecularPower = 45f;
            effect.DirectionalLight2.Direction = new Vector3(-0.7f, -0.2f, 0.7f);
            effect.DirectionalLight2.DiffuseColor = new Vector3((float) this.brite, (float) this.brite, (float) this.brite) / 8f;
            effect.DirectionalLight2.SpecularColor = new Vector3((float) this.brite, (float) this.brite, (float) this.brite) / 8f;
            if (this.lightson)
            {
              effect.AmbientLightColor = new Vector3(0.18f, 0.18f, 0.18f) * 0.6f * this.fadeup2;
              effect.DirectionalLight0.Direction = new Vector3(0.0f, 0.0f, -1f);
              effect.DirectionalLight0.DiffuseColor = new Vector3(0.8f, 0.8f, 0.8f) * (float) ((double) this.z / 4.0 + 0.800000011920929) * this.fadeup2;
              effect.DirectionalLight0.SpecularColor = new Vector3(0.05f, 0.05f, 0.05f) * (float) ((double) this.z / 4.0 + 0.800000011920929) * this.fadeup2;
              effect.DirectionalLight1.Direction = new Vector3(0.2f, 1f, 0.0f);
              effect.DirectionalLight1.DiffuseColor = new Vector3(0.6f, 0.6f, 0.6f) * (float) ((double) this.z / 4.0 + 0.800000011920929) * this.fadeup2;
              effect.DirectionalLight1.SpecularColor = new Vector3(0.15f, 0.15f, 0.15f) * this.fadeup2;
              this.fadeup2 += 1f / 1000f * timeadjust;
              if ((double) this.fadeup2 > 0.699999988079071)
                this.fadeup2 = 0.7f;
              this.fadeup1 += 1f / 1000f * timeadjust;
              if ((double) this.fadeup1 > 1.0)
                this.fadeup1 = 1f;
            }
            else
            {
              effect.AmbientLightColor = new Vector3(0.2f, 0.2f, 0.2f) * (float) -((double) this.z + 1.0);
              effect.DirectionalLight0.Direction = new Vector3(this.x, 0.0f, this.z);
              effect.DirectionalLight0.DiffuseColor = new Vector3(1f, 1f, 1f);
              effect.DirectionalLight0.SpecularColor = new Vector3(1.3f, 1.3f, 1.3f);
              if ((double) this.z >= 0.97000002861022949)
                effect.DirectionalLight0.SpecularColor = new Vector3(0.0f, 0.0f, 0.0f);
            }
          }
          mesh.Draw();
        }
        this.sc.GraphicsDevice.SetRenderTarget((RenderTarget2D) null);
      }
      this.sc.GraphicsDevice.Clear(Color.Black);
      if ((double) this.timer > (double) this.titlecutoff && this.soundEffectInstance_0.State == SoundState.Stopped)
        this.soundEffectInstance_0.Play();
      if (this.IsActive && this.soundEffectInstance_0.State == SoundState.Paused)
        this.soundEffectInstance_0.Resume();
      if (!this.IsActive && this.soundEffectInstance_0.State == SoundState.Playing)
        this.soundEffectInstance_0.Pause();
      this.RestoreRenderStates();
      if ((double) this.counter > 4.0)
      {
        foreach (ModelMesh mesh in this.stars.Meshes)
        {
          foreach (BasicEffect effect in mesh.Effects)
          {
            effect.Texture = this.sc.Globalstarmap.manmadestars;
            effect.View = this.viewMatrix;
            effect.LightingEnabled = true;
            effect.Projection = this.projectionMatrix;
            effect.World = Matrix.CreateScale(30f) * Matrix.CreateRotationX((float) (-1.9500000476837158 - (double) this.hover.Z / 400.0));
            effect.AmbientLightColor = new Vector3(1f, 1f, 1f) * this.fadeup1;
            effect.DiffuseColor = new Vector3(1f, 1f, 1f) * this.fadeup1;
            effect.PreferPerPixelLighting = false;
          }
          mesh.Draw();
        }
      }
      if ((double) this.timer > (double) this.titlecutoff)
      {
        this.projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(75f), this.sc.aspectratio2, 1f, 5690000f);
        this.viewMatrix = Matrix.CreateLookAt(new Vector3(0.0f, 0.0f, 70f), new Vector3(0.0f, 0.0f, 0.0f), Vector3.Up);
      }
      if ((double) this.timer > (double) this.titlecutoff)
      {
        foreach (ModelMesh mesh in this.logo.Meshes)
        {
          foreach (BasicEffect effect in mesh.Effects)
          {
            this.calcL257(timeadjust);
            this.ellBone.Transform = this.ellMatrix * this.ellTransform;
            this.twoBone.Transform = this.twoMatrix * this.twoTransform;
            this.fiveBone.Transform = this.fiveMatrix * this.fiveTransform;
            this.sevenBone.Transform = this.sevenMatrix * this.sevenTransform;
            Matrix[] destinationBoneTransforms = new Matrix[this.logo.Bones.Count];
            this.logo.CopyAbsoluteBoneTransformsTo(destinationBoneTransforms);
            effect.World = destinationBoneTransforms[mesh.ParentBone.Index] * Matrix.CreateTranslation(this.where + this.hover);
            effect.View = this.viewMatrix;
            effect.Projection = this.projectionMatrix;
            effect.LightingEnabled = true;
            effect.DirectionalLight0.Enabled = true;
            effect.DirectionalLight1.Enabled = true;
            effect.DirectionalLight2.Enabled = true;
            effect.PreferPerPixelLighting = true;
            effect.SpecularPower = 45f;
            effect.DirectionalLight2.Direction = new Vector3(-0.7f, -0.2f, 0.7f);
            effect.DirectionalLight2.DiffuseColor = new Vector3((float) this.brite, (float) this.brite, (float) this.brite) / 8f;
            effect.DirectionalLight2.SpecularColor = new Vector3((float) this.brite, (float) this.brite, (float) this.brite) / 8f;
            if (this.lightson)
            {
              effect.AmbientLightColor = new Vector3(0.18f, 0.18f, 0.18f) * 0.6f * this.fadeup2;
              effect.DirectionalLight0.Direction = new Vector3(0.0f, 0.0f, -1f);
              effect.DirectionalLight0.DiffuseColor = new Vector3(0.8f, 0.8f, 0.8f) * (float) ((double) this.z / 4.0 + 0.800000011920929) * this.fadeup2;
              effect.DirectionalLight0.SpecularColor = new Vector3(0.05f, 0.05f, 0.05f) * (float) ((double) this.z / 4.0 + 0.800000011920929) * this.fadeup2;
              effect.DirectionalLight1.Direction = new Vector3(0.2f, 1f, 0.0f);
              effect.DirectionalLight1.DiffuseColor = new Vector3(0.6f, 0.6f, 0.6f) * (float) ((double) this.z / 4.0 + 0.800000011920929) * this.fadeup2;
              effect.DirectionalLight1.SpecularColor = new Vector3(0.15f, 0.15f, 0.15f) * this.fadeup2;
            }
            else
            {
              effect.AmbientLightColor = new Vector3(0.2f, 0.2f, 0.2f) * (float) -((double) this.z + 1.0);
              effect.DirectionalLight0.Direction = new Vector3(this.x, 0.0f, this.z);
              effect.DirectionalLight0.DiffuseColor = new Vector3(1f, 1f, 1f);
              effect.DirectionalLight0.SpecularColor = new Vector3(1.3f, 1.3f, 1.3f);
              if ((double) this.z >= 0.97000002861022949)
                effect.DirectionalLight0.SpecularColor = new Vector3(0.0f, 0.0f, 0.0f);
            }
          }
          mesh.Draw();
        }
      }
      if ((double) this.timer <= (double) this.titlecutoff)
      {
        if ((double) this.timer >= 0.0 && this.moveflag == 0)
        {
          this.moveflag = 1;
          this.trumpet.Play(0.5f, 0.0f, 0.0f);
        }
        this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
        float num1 = (float) this.bigcorp.Width / (float) this.bigcorp.Height / this.sc.aspectratio2;
        this.spriteBatch.Draw(this.bigcorp, new Rectangle((int) (float) (0.0 - ((double) this.sc.width * (double) num1 - (double) this.sc.width) * 0.5), 0, (int) ((double) this.sc.width * (double) num1), this.sc.hite), Color.White);
        this.spriteBatch.End();
        if (this.IsActive)
        {
          float x1 = 640f;
          float y = -360f;
          float z = 1343.5f;
          this.projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(30f), this.sc.aspectratio2, 1f, 15000f);
          this.viewMatrix = Matrix.CreateLookAt(new Vector3(x1, -340f, z), new Vector3(x1, y, 0.0f), Vector3.Up);
          int num2 = this.random.Next(4, 20);
          int num3 = num2;
          float num4 = 0.0f;
          float num5 = 0.0f;
          int num6 = num2;
          float num7 = 0.0f;
          float num8 = 0.0f;
          this.partyDelay -= 1f * timeadjust;
          if ((double) this.partyDelay <= 0.0 && this.finished == 0)
          {
            for (int index = 0; index < this.shakeX.Length; index += 2)
            {
              Vector3 vector3 = new Vector3((float) this.random.Next(-100, 100) / 60f, (float) this.random.Next(-100, 100) / 60f, (float) this.random.Next(-100, 100) / 80f);
              if (num3 == num2)
              {
                num4 = (float) this.random.Next(2, 39);
                num5 = (float) (3900.0 - (double) index * 2.0) / 1000f;
                num3 = 0;
              }
              ++num3;
              if (index + 1 <= this.shakeX.Length - 1)
              {
                float x2 = (float) (this.shakeX[index] - 200);
                float num9 = (float) -(-this.shakeX[index + 1] + 165);
                this.sparks.AddParticle(new Vector3(x2, -num9, 0.0f), vector3 + new Vector3((float) Math.Sin((double) num5) * num4, (float) -Math.Cos((double) num5) * num4, (float) ((Math.Sin((double) this.timer * 4.0) + 0.20000000298023224) * 30.0)));
                this.sparks.AddParticle(new Vector3(x2 + 4f, -num9, 0.0f), vector3 + new Vector3((float) Math.Sin((double) num5) * num4, (float) -Math.Cos((double) num5) * num4, (float) ((Math.Sin((double) this.timer * 4.0) + 0.20000000298023224) * 35.0)));
              }
              else
                break;
            }
            for (int index = 0; index < this.shakeX2.Length; index += 2)
            {
              if (num6 == num2)
              {
                num7 = (float) this.random.Next(2, 39);
                num8 = (float) ((double) index * 3.0 - 800.0) / 1000f;
                num6 = 0;
              }
              Vector3 vector3 = new Vector3((float) this.random.Next(-100, 100) / 60f, (float) this.random.Next(-100, 100) / 60f, (float) this.random.Next(-100, 100) / 80f);
              ++num6;
              if (index + 1 <= this.shakeX2.Length - 1)
              {
                float x3 = (float) (this.shakeX2[index] - 200);
                float num10 = (float) -(-this.shakeX2[index + 1] + 165);
                this.sparks.AddParticle(new Vector3(x3, -num10, 0.0f), vector3 + new Vector3((float) Math.Sin((double) num8) * num7, (float) -Math.Cos((double) num8) * num7, (float) ((Math.Sin((double) this.timer * 4.0) + 0.20000000298023224) * 30.0)));
                this.sparks.AddParticle(new Vector3(x3 - 3f, -num10, 0.0f), vector3 + new Vector3((float) Math.Sin((double) num8) * num7, (float) -Math.Cos((double) num8) * num7, (float) ((Math.Sin((double) this.timer * 4.0) + 0.20000000298023224) * 35.0)));
              }
              else
                break;
            }
            this.partyDelay = (float) this.random.Next(6, 25);
          }
        }
      }
      this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive);
      this.britecount += 1f * timeadjust;
      this.howlong -= 1f * timeadjust;
      if ((double) this.howlong <= 0.0 && this.random.Next(1, 5000) < 60)
      {
        this.howlong = (float) this.random.Next(40, 70);
        this.freq = this.random.Next(15, 50);
      }
      if ((double) this.britecount > (double) this.freq && (double) this.howlong > 0.0 && (double) this.z < 0.40000000596046448 && (double) this.timer > 8.0)
      {
        this.britecount = 0.0f;
        this.brite = (byte) this.random.Next(50, (int) byte.MaxValue);
      }
      else
        this.brite = (byte) 0;
      this.spriteBatch.Draw(this.glower, new Rectangle(0, 0, 1280, 720), new Color((int) this.brite, (int) this.brite, (int) this.brite, (int) byte.MaxValue));
      this.spriteBatch.End();
      if ((double) this.timer > 80.0)
        this.finished = 1;
      if (this.finished == 1)
      {
        this.mytrans -= 4f * timeadjust;
        if ((double) this.mytrans < 0.0)
          this.mytrans = 0.0f;
        float num = this.mytrans / (float) byte.MaxValue;
        if (this.soundEffectInstance_0.State == SoundState.Playing)
          this.soundEffectInstance_0.Volume = num;
        if (this.spacewindI.State == SoundState.Playing)
          this.spacewindI.Volume = num;
        if ((double) this.mytrans <= 0.0)
        {
          this.finished = 2;
          this.mytrans = 0.0f;
          if ((double) this.timer < 6.0)
            this.timer = 7f;
        }
        this.sc.FadeBackBufferToBlack((int) byte.MaxValue - (int) this.mytrans);
      }
      if ((double) this.timer > (double) this.titlecutoff)
        return;
      this.sparks.SetCamera(this.viewMatrix, this.projectionMatrix);
      this.sparks.Draw(0);
    }

    private void RestoreRenderStates()
    {
      this.sc.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
      this.sc.GraphicsDevice.BlendState = BlendState.Opaque;
      this.sc.GraphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;
      this.ScreenManager.GraphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;
    }

    private void RenderStates()
    {
      this.sc.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
      this.sc.GraphicsDevice.BlendState = BlendState.AlphaBlend;
      this.sc.GraphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;
      this.ScreenManager.GraphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;
    }
  }
}
