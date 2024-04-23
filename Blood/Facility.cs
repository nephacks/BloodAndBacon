// Decompiled with JetBrains decompiler
// Type: Blood.Facility
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

#nullable disable
namespace Blood
{
  public class Facility : GameScreen
  {
    private KeyboardState keyState;
    private KeyboardState prevkeyState;
    private MouseState mouseState;
    private MouseState prevMouse;
    private GamePadState gamePadState;
    private GamePadState prevstate;
    public static Vector3 offset = new Vector3(0.0f, 0.0f, 0.0f);
    public static bool outsideCastle = true;
    public static bool inFacility = false;
    public static bool atSwitch = false;
    public static bool atSwitch2 = false;
    public static bool atMain = false;
    public static Vector4 createWorkerLoc = Vector4.Zero;
    public static bool openConstruction = false;
    public static List<Vector2> mypath = new List<Vector2>();
    public static List<float> facilityPlot = new List<float>();
    public static List<float> reachPlot = new List<float>();
    public static List<Vector2> dummyPlot = new List<Vector2>();
    private float sightLimit = 2250000f;
    private int myframe;
    private int playerIndex;
    public float specRot = 4.7f;
    public float specRot2 = 23f / 1000f;
    private float camtilt;
    private float camrot;
    public bool rebuild;
    private int gridwidth;
    public static int[,] heightData;
    private int[,] heightsEntry;
    public static int[,] clickable;
    public int[,] clickableEntry;
    public int gridVal;
    public bool jumping;
    public bool steep;
    private int gateShake;
    private int clangID;
    private Matrix gateShakeMatrix;
    private float gateRot;
    private Effect blurEffect;
    private Matrix[] clickLocation = new Matrix[1800];
    private List<int> clickList = new List<int>();
    private List<bool> clickListBool = new List<bool>();
    private List<float> triList = new List<float>();
    private List<float> deadList = new List<float>();
    private List<float> hallList = new List<float>();
    private List<float> crossList = new List<float>();
    private List<float> longList = new List<float>();
    private List<float> cornerList = new List<float>();
    private List<float> oxygenList = new List<float>();
    private List<float> powerList = new List<float>();
    private List<float> salvageList = new List<float>();
    private List<float> stairList = new List<float>();
    private List<float> holyList = new List<float>();
    private List<float> brokeList = new List<float>();
    public bool drawingEntry = true;
    public int drawcount;
    private int clickCount;
    private int floorFlag = 3;
    private int gateID = -1;
    private int gateAnim;
    private int lastFloorBuilt = -1;
    private int pitIndex;
    private int lastpitBuilt = -1;
    private Model triHall;
    private Model hallWay;
    private Model stairWell;
    private Model paperCard;
    private Model corner;
    private Model deadend;
    private Model deadend2;
    private Model brokeHall;
    private Model crossHall;
    private Model holyHall;
    private Model powerHall;
    private Model salvageHall;
    private Model oxygenHall;
    private Model rustedgate;
    private Model rustedgate2;
    private Model mainDoor;
    private Model onyxDoor;
    private Model prisonDoor;
    private Model spiderskullDoor;
    private Model pit1;
    private Model newFrame;
    private Model oldFrame;
    private Model invPack;
    private Model tunnelWater;
    private Model ceiling;
    private Model ceiling2;
    private Model entryWay;
    private Model altar;
    private Model longHall;
    private Model gauntlet;
    private Model flame;
    private Model ghostpath1;
    private Model ghostpath2;
    private Model ghostpath3;
    private Model ghostpath4;
    private Model ghostpath5;
    private Model ghostpath6;
    private Model ghostpath7;
    private Model torch;
    private Model vaultChest;
    private Model vaultChest3;
    private Model switchModel;
    private Model trapModel;
    private Model vaultChest2;
    private Model plaque;
    private Model lootball;
    private Model cube;
    private Effect fogEffect;
    private Effect facShader;
    private Vector4 shadRect = new Vector4(1250f, 1050f, 100f, 100f);
    private Vector4 whiteRect = new Vector4(1250f, 850f, 80f, 80f);
    private Vector4 rgb1Rect = new Vector4(300f, 700f, 500f, 500f);
    private Vector4 rgb1catacombs = new Vector4(1400f, 500f, 500f, 500f);
    private Vector4 rgb1RectServant = new Vector4(0.0f, 0.0f, 1000f, 800f);
    private Vector4 rgb1RectPrison = new Vector4(500f, 1200f, 500f, 500f);
    private Vector4 rgb1RectNobles = new Vector4(1000f, 1200f, 500f, 500f);
    private Vector4 rgb1RectRoyal = new Vector4(1500f, 1200f, 500f, 500f);
    private Vector4 rgb1RectRoof = new Vector4(1400f, 0.0f, 500f, 500f);
    private Vector4[] rgbRect;
    private Vector4 gateshadRect = new Vector4(1200f, 0.0f, 200f, 200f);
    private Vector4 prisonrgbRect = new Vector4(1000f, 0.0f, 200f, 200f);
    private Vector4 tombrgbRect = new Vector4(800f, 0.0f, 200f, 200f);
    private Vector4 woodenrgbRect = new Vector4(1000f, 200f, 200f, 200f);
    private Vector4 skullrgbRect = new Vector4(800f, 200f, 200f, 200f);
    private Vector4 spiderrgbRect = new Vector4(800f, 400f, 200f, 200f);
    private Vector4 trapShadRect = new Vector4(600f, 1000f, 200f, 200f);
    private Vector4 trapRect = new Vector4(400f, 1000f, 200f, 200f);
    private Vector4 switchShadRect = new Vector4(1600f, 1000f, 200f, 200f);
    private Vector4 switchRect = new Vector4(600f, 800f, 200f, 200f);
    private Vector4 chestRect = new Vector4(0.0f, 1000f, 200f, 200f);
    private Vector4 chestRect3 = new Vector4(1800f, 1000f, 200f, 200f);
    private Vector4 gateOrangeRect = new Vector4(824f, 1200f, 313f, 313f);
    private Vector4 gatergbRect2 = new Vector4(502f, 1200f, 313f, 313f);
    private Vector4 vaultchestshadRect = new Vector4(1200f, 800f, 200f, 200f);
    private Vector4 kingchestRect = new Vector4(1000f, 600f, 200f, 200f);
    private Vector4 spiderchestRect = new Vector4(1000f, 400f, 200f, 200f);
    private Vector4 powerShad = new Vector4(0.0f, 1300f, 400f, 400f);
    private PresentationParameters pp;
    private RenderTarget2D resolveTargetX;
    public Texture2D rooms;
    public Texture2D reflec;
    public Texture2D entryTexture;
    public Texture2D dirtrgb;
    public Texture2D mixrgb;
    private float[] brokePos;
    private float[] stairwellPos;
    private float[] holyPos;
    private float[] puzzleDoorPos;
    private float[] victoryPos;
    public float[] trihallPos;
    public float[] crossPos;
    public float[] hallwayPos;
    public float[] longPos;
    public float[] deadPos;
    public float[] cornerPos;
    public float[] entryPos;
    public float[] chestPos;
    public float[] trapPos;
    public float[] switchPos;
    public float[] gatePos;
    public float[] powerPos;
    public float[] salvagePos;
    public float[] oxygenPos;
    private int[] gatePP;
    private int[] chestPP;
    private int[] switchPP;
    private int[] trapPP;
    private int[] defaultDoorTag;
    public int[] pointer;
    private int[] doorTag;
    private int[] skullPortrait = new int[9];
    private float[] switchRot;
    private float[] chestRot;
    private float[] gateTrans;
    private float[] chestTrans;
    private List<int> closeGate = new List<int>();
    private int[] gateSpeed = new int[20]
    {
      120,
      180,
      120,
      120,
      120,
      1,
      1,
      1,
      1,
      1,
      -100,
      -150,
      -100,
      -100,
      -100,
      1,
      1,
      1,
      1,
      1
    };
    private int lastTrigger;
    private int bottomless = -2000000000;
    private ScreenManager sc;
    private Vector3 campos;
    private Vector3 camlookpos;
    private Vector3 pos;
    private Vector2 norm1;
    private Vector2 norm2;
    private Vector3 norm3;
    private float dot;
    private bool facingIt;
    private Matrix faciltyMatrix = Matrix.Identity;
    public Vector2 facilityLocate = new Vector2(0.0f, 0.0f);
    public Vector3 gridset = new Vector3(9000f, 0.0f, 9000f);
    public float scaler = 4f;
    private multiply multi = new multiply();
    private int[] entryHit;
    private int[] entryHitEnter;
    private float entryRampHite;
    public bool onRamp;
    private ContentManager content;

    public void LoadContent(ContentManager contentx, ScreenManager screenManager)
    {
      this.sc = screenManager;
      if (this.content == null)
        this.content = new ContentManager((IServiceProvider) this.sc.Game.Services, "Content");
      this.gridwidth = 90;
      Facility.heightData = new int[2 * this.gridwidth, 2 * this.gridwidth];
      this.heightsEntry = new int[2 * this.gridwidth, 2 * this.gridwidth];
      Facility.clickable = new int[2 * this.gridwidth, 2 * this.gridwidth];
      this.clickableEntry = new int[2 * this.gridwidth, 2 * this.gridwidth];
      this.fogEffect = this.content.Load<Effect>("astro\\shaders\\fogShader");
      this.facShader = this.content.Load<Effect>("astro\\shaders\\facilityShader");
      this.rooms = this.sc.rooms;
      this.dirtrgb = new Texture2D(this.sc.GraphicsDevice, 500, 500);
      this.entryTexture = this.sc.entryShad;
      this.mixrgb = this.sc.entryrgb2;
      this.entryWay = this.content.Load<Model>("astro\\models\\castleEntry");
      this.facShader.Parameters["rgbTexture"].SetValue((Texture) this.rooms);
      this.blurEffect = this.content.Load<Effect>("astro\\shaders\\postShader");
      this.vaultChest = this.content.Load<Model>("astro\\models\\vaultChest");
      this.vaultChest3 = this.content.Load<Model>("astro\\models\\vaultChest3");
      this.vaultChest2 = this.content.Load<Model>("astro\\models\\vaultChest2");
      this.switchModel = this.content.Load<Model>("astro\\models\\switch2");
      this.trapModel = this.content.Load<Model>("astro\\models\\trap");
      this.triHall = this.content.Load<Model>("astro\\models\\castleThree");
      this.holyHall = this.content.Load<Model>("astro\\models\\castleHoly");
      this.powerHall = this.content.Load<Model>("astro\\models\\castlePower");
      this.salvageHall = this.content.Load<Model>("astro\\models\\castleSalvage");
      this.oxygenHall = this.content.Load<Model>("astro\\models\\castleOxygen");
      this.hallWay = this.content.Load<Model>("astro\\models\\castleHall");
      this.corner = this.content.Load<Model>("astro\\models\\castleCorner");
      this.deadend = this.content.Load<Model>("astro\\models\\castleDeadend");
      this.crossHall = this.content.Load<Model>("astro\\models\\castleCross");
      this.longHall = this.content.Load<Model>("astro\\models\\castleLongHall");
      this.mainDoor = this.content.Load<Model>("astro\\models\\castleGateNew2");
      this.cube = this.content.Load<Model>("astro\\models\\cube");
      this.rgbRect = new Vector4[6]
      {
        this.rgb1catacombs,
        this.rgb1RectPrison,
        this.rgb1RectServant,
        this.rgb1RectNobles,
        this.rgb1RectRoyal,
        this.rgb1RectRoof
      };
      CultureInfo invariantCulture1 = CultureInfo.InvariantCulture;
      StreamReader streamReader1 = new StreamReader("content/astro/collide/entry.txt");
      int index1 = 0;
      this.entryHit = new int[597];
      while (!streamReader1.EndOfStream)
      {
        int int32 = Convert.ToInt32(streamReader1.ReadLine(), (IFormatProvider) invariantCulture1);
        this.entryHit[index1] = int32;
        ++index1;
      }
      streamReader1.Close();
      streamReader1.Dispose();
      CultureInfo invariantCulture2 = CultureInfo.InvariantCulture;
      StreamReader streamReader2 = new StreamReader("content/astro/collide/entry0.txt");
      int index2 = 0;
      this.entryHitEnter = new int[3795];
      while (!streamReader2.EndOfStream)
      {
        int int32 = Convert.ToInt32(streamReader2.ReadLine(), (IFormatProvider) invariantCulture2);
        this.entryHitEnter[index2] = int32;
        ++index2;
      }
      streamReader2.Close();
      streamReader2.Dispose();
      this.pp = this.sc.GraphicsDevice.PresentationParameters;
      this.resolveTargetX = new RenderTarget2D(this.sc.GraphicsDevice, 1280, 720, false, this.pp.BackBufferFormat, this.pp.DepthStencilFormat, 0, RenderTargetUsage.DiscardContents);
      this.loadOffset();
      this.pointer = new int[2000];
      this.doorTag = new int[2000];
      this.createPointers();
      int length = this.doorTag.Length;
      this.switchRot = new float[length];
      this.chestRot = new float[length];
      this.chestTrans = new float[length];
      this.gateTrans = new float[length];
      this.clickLocation = new Matrix[length];
      for (int index3 = 0; index3 < this.switchRot.Length; ++index3)
        this.switchRot[index3] = 0.0f;
      for (int index4 = 0; index4 < this.gateTrans.Length; ++index4)
        this.gateTrans[index4] = 0.0f;
      for (int index5 = 0; index5 < this.chestTrans.Length; ++index5)
        this.chestTrans[index5] = 0.0f;
      for (int index6 = 0; index6 < this.chestRot.Length; ++index6)
        this.chestRot[index6] = 0.0f;
      this.loadClickables();
      this.floorFlag = 3;
      this.lastTrigger = 3;
      this.buildFloor(3);
      this.updateGateCollision();
    }

    public new void UnloadContent()
    {
      this.content.Unload();
      this.content.Dispose();
      this.content = (ContentManager) null;
    }

    public void resetClickables()
    {
      this.createPointers();
      int length = this.doorTag.Length;
      this.switchRot = new float[length];
      this.chestRot = new float[length];
      this.chestTrans = new float[length];
      this.gateTrans = new float[length];
      this.clickLocation = new Matrix[length];
      for (int index = 0; index < this.switchRot.Length; ++index)
        this.switchRot[index] = 0.0f;
      for (int index = 0; index < this.gateTrans.Length; ++index)
        this.gateTrans[index] = 0.0f;
      for (int index = 0; index < this.chestTrans.Length; ++index)
        this.chestTrans[index] = 0.0f;
      for (int index = 0; index < this.chestRot.Length; ++index)
        this.chestRot[index] = 0.0f;
    }

    public bool method_0(int floor, float sum)
    {
      return floor == 1 && (double) sum != -920.0 || floor == 2 && (double) sum != -460.0 || floor == 3 && (double) sum != 0.0 || floor == 4 && (double) sum != 460.0 || floor == 5 && (double) sum != 920.0 && (double) sum != 1120.0 || floor == 6 && (double) sum != 1380.0;
    }

    public void loadOffset()
    {
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      StreamReader streamReader1 = new StreamReader("content/astro/parts/trihall.txt");
      int newSize1 = 0;
      this.trihallPos = new float[2000];
      while (!streamReader1.EndOfStream)
      {
        this.trihallPos[newSize1] = Convert.ToSingle(streamReader1.ReadLine(), (IFormatProvider) invariantCulture);
        ++newSize1;
      }
      Array.Resize<float>(ref this.trihallPos, newSize1);
      streamReader1.Close();
      streamReader1.Dispose();
      StreamReader streamReader2 = new StreamReader("content/astro/parts/hall.txt");
      int newSize2 = 0;
      this.hallwayPos = new float[2000];
      while (!streamReader2.EndOfStream)
      {
        this.hallwayPos[newSize2] = Convert.ToSingle(streamReader2.ReadLine(), (IFormatProvider) invariantCulture);
        ++newSize2;
      }
      Array.Resize<float>(ref this.hallwayPos, newSize2);
      streamReader2.Close();
      streamReader2.Dispose();
      StreamReader streamReader3 = new StreamReader("content/astro/parts/corner.txt");
      int newSize3 = 0;
      this.cornerPos = new float[2000];
      while (!streamReader3.EndOfStream)
      {
        this.cornerPos[newSize3] = Convert.ToSingle(streamReader3.ReadLine(), (IFormatProvider) invariantCulture);
        ++newSize3;
      }
      Array.Resize<float>(ref this.cornerPos, newSize3);
      streamReader3.Close();
      streamReader3.Dispose();
      StreamReader streamReader4 = new StreamReader("content/astro/parts/power.txt");
      int newSize4 = 0;
      this.powerPos = new float[2000];
      while (!streamReader4.EndOfStream)
      {
        this.powerPos[newSize4] = Convert.ToSingle(streamReader4.ReadLine(), (IFormatProvider) invariantCulture);
        ++newSize4;
      }
      Array.Resize<float>(ref this.powerPos, newSize4);
      streamReader4.Close();
      streamReader4.Dispose();
      StreamReader streamReader5 = new StreamReader("content/astro/parts/oxygen.txt");
      int newSize5 = 0;
      this.oxygenPos = new float[2000];
      while (!streamReader5.EndOfStream)
      {
        this.oxygenPos[newSize5] = Convert.ToSingle(streamReader5.ReadLine(), (IFormatProvider) invariantCulture);
        ++newSize5;
      }
      Array.Resize<float>(ref this.oxygenPos, newSize5);
      streamReader5.Close();
      streamReader5.Dispose();
      StreamReader streamReader6 = new StreamReader("content/astro/parts/salvage.txt");
      int newSize6 = 0;
      this.salvagePos = new float[2000];
      while (!streamReader6.EndOfStream)
      {
        this.salvagePos[newSize6] = Convert.ToSingle(streamReader6.ReadLine(), (IFormatProvider) invariantCulture);
        ++newSize6;
      }
      Array.Resize<float>(ref this.salvagePos, newSize6);
      streamReader6.Close();
      streamReader6.Dispose();
      StreamReader streamReader7 = new StreamReader("content/astro/parts/dead.txt");
      int newSize7 = 0;
      this.deadPos = new float[2000];
      while (!streamReader7.EndOfStream)
      {
        this.deadPos[newSize7] = Convert.ToSingle(streamReader7.ReadLine(), (IFormatProvider) invariantCulture);
        ++newSize7;
      }
      Array.Resize<float>(ref this.deadPos, newSize7);
      streamReader7.Close();
      streamReader7.Dispose();
      StreamReader streamReader8 = new StreamReader("content/astro/parts/entry.txt");
      int newSize8 = 0;
      this.entryPos = new float[2000];
      while (!streamReader8.EndOfStream)
      {
        this.entryPos[newSize8] = Convert.ToSingle(streamReader8.ReadLine(), (IFormatProvider) invariantCulture);
        ++newSize8;
      }
      Array.Resize<float>(ref this.entryPos, newSize8);
      streamReader8.Close();
      streamReader8.Dispose();
      StreamReader streamReader9 = new StreamReader("content/astro/parts/gate.txt");
      int newSize9 = 0;
      this.gatePos = new float[2000];
      while (!streamReader9.EndOfStream)
      {
        this.gatePos[newSize9] = Convert.ToSingle(streamReader9.ReadLine(), (IFormatProvider) invariantCulture);
        ++newSize9;
      }
      Array.Resize<float>(ref this.gatePos, newSize9);
      streamReader9.Close();
      streamReader9.Dispose();
      StreamReader streamReader10 = new StreamReader("content/astro/parts/chest.txt");
      int newSize10 = 0;
      this.chestPos = new float[2000];
      while (!streamReader10.EndOfStream)
      {
        this.chestPos[newSize10] = Convert.ToSingle(streamReader10.ReadLine(), (IFormatProvider) invariantCulture);
        ++newSize10;
      }
      Array.Resize<float>(ref this.chestPos, newSize10);
      streamReader10.Close();
      streamReader10.Dispose();
      StreamReader streamReader11 = new StreamReader("content/astro/parts/switch.txt");
      int newSize11 = 0;
      this.switchPos = new float[2000];
      while (!streamReader11.EndOfStream)
      {
        this.switchPos[newSize11] = Convert.ToSingle(streamReader11.ReadLine(), (IFormatProvider) invariantCulture);
        ++newSize11;
      }
      Array.Resize<float>(ref this.switchPos, newSize11);
      streamReader11.Close();
      streamReader11.Dispose();
      StreamReader streamReader12 = new StreamReader("content/astro/parts/trap.txt");
      int newSize12 = 0;
      this.trapPos = new float[2000];
      while (!streamReader12.EndOfStream)
      {
        this.trapPos[newSize12] = Convert.ToSingle(streamReader12.ReadLine(), (IFormatProvider) invariantCulture);
        ++newSize12;
      }
      Array.Resize<float>(ref this.trapPos, newSize12);
      streamReader12.Close();
      streamReader12.Dispose();
      StreamReader streamReader13 = new StreamReader("content/astro/parts/long.txt");
      int newSize13 = 0;
      this.longPos = new float[2000];
      while (!streamReader13.EndOfStream)
      {
        this.longPos[newSize13] = Convert.ToSingle(streamReader13.ReadLine(), (IFormatProvider) invariantCulture);
        ++newSize13;
      }
      Array.Resize<float>(ref this.longPos, newSize13);
      streamReader13.Close();
      streamReader13.Dispose();
      StreamReader streamReader14 = new StreamReader("content/astro/parts/cross.txt");
      int newSize14 = 0;
      this.crossPos = new float[2000];
      while (!streamReader14.EndOfStream)
      {
        this.crossPos[newSize14] = Convert.ToSingle(streamReader14.ReadLine(), (IFormatProvider) invariantCulture);
        ++newSize14;
      }
      Array.Resize<float>(ref this.crossPos, newSize14);
      streamReader14.Close();
      streamReader14.Dispose();
      StreamReader streamReader15 = new StreamReader("content/astro/parts/gatePP.txt");
      int newSize15 = 0;
      this.gatePP = new int[2000];
      while (!streamReader15.EndOfStream)
      {
        this.gatePP[newSize15] = Convert.ToInt32(streamReader15.ReadLine(), (IFormatProvider) invariantCulture);
        ++newSize15;
      }
      Array.Resize<int>(ref this.gatePP, newSize15);
      streamReader15.Close();
      streamReader15.Dispose();
      StreamReader streamReader16 = new StreamReader("content/astro/parts/chestPP.txt");
      int newSize16 = 0;
      this.chestPP = new int[2000];
      while (!streamReader16.EndOfStream)
      {
        this.chestPP[newSize16] = Convert.ToInt32(streamReader16.ReadLine(), (IFormatProvider) invariantCulture);
        ++newSize16;
      }
      Array.Resize<int>(ref this.chestPP, newSize16);
      streamReader16.Close();
      streamReader16.Dispose();
      StreamReader streamReader17 = new StreamReader("content/astro/parts/switchPP.txt");
      int newSize17 = 0;
      this.switchPP = new int[2000];
      while (!streamReader17.EndOfStream)
      {
        this.switchPP[newSize17] = Convert.ToInt32(streamReader17.ReadLine(), (IFormatProvider) invariantCulture);
        ++newSize17;
      }
      Array.Resize<int>(ref this.switchPP, newSize17);
      streamReader17.Close();
      streamReader17.Dispose();
      StreamReader streamReader18 = new StreamReader("content/astro/parts/trapPP.txt");
      int newSize18 = 0;
      this.trapPP = new int[2000];
      while (!streamReader18.EndOfStream)
      {
        this.trapPP[newSize18] = Convert.ToInt32(streamReader18.ReadLine(), (IFormatProvider) invariantCulture);
        ++newSize18;
      }
      Array.Resize<int>(ref this.trapPP, newSize18);
      streamReader18.Close();
      streamReader18.Dispose();
      this.offsetbyRef(ref this.trihallPos);
      this.offsetbyRef(ref this.hallwayPos);
      this.offsetbyRef(ref this.cornerPos);
      this.offsetbyRef(ref this.deadPos);
      this.offsetbyRef(ref this.longPos);
      this.offsetbyRef(ref this.crossPos);
      this.offsetbyRef(ref this.powerPos);
      this.offsetbyRef(ref this.salvagePos);
      this.offsetbyRef(ref this.oxygenPos);
      this.offsetbyRef(ref this.entryPos);
      this.offsetbyRef(ref this.gatePos);
      this.offsetbyRef(ref this.chestPos);
      this.offsetbyRef(ref this.trapPos);
      this.offsetbyRef(ref this.switchPos);
    }

    public void offsetbyRef(ref float[] part)
    {
      for (int index = 0; index < part.Length; index += 4)
      {
        part[index] = part[index] + this.gridset.X;
        part[index + 2] = part[index + 2] + this.gridset.Z;
      }
    }

    public void createPointers()
    {
      int index1 = 0;
      int index2 = 0;
      int index3 = 0;
      int index4 = 0;
      int newSize = 0;
      for (int index5 = 0; index5 < this.chestPos.Length; index5 += 4)
      {
        this.pointer[newSize] = this.chestPP[index2];
        this.doorTag[newSize] = this.chestPP[index2 + 1];
        index2 += 4;
        ++newSize;
      }
      for (int index6 = 0; index6 < this.trapPos.Length; index6 += 4)
      {
        this.pointer[newSize] = this.trapPP[index4];
        this.doorTag[newSize] = this.trapPP[index4 + 1];
        index4 += 4;
        ++newSize;
      }
      for (int index7 = 0; index7 < this.switchPos.Length; index7 += 4)
      {
        this.pointer[newSize] = this.switchPP[index3];
        this.doorTag[newSize] = this.switchPP[index3 + 1];
        index3 += 4;
        ++newSize;
      }
      for (int index8 = 0; index8 < this.gatePos.Length; index8 += 4)
      {
        this.pointer[newSize] = this.gatePP[index1];
        this.doorTag[newSize] = this.gatePP[index1 + 1];
        if (this.gatePP[index1] == 101)
          this.sc.frontDoor = newSize;
        index1 += 4;
        ++newSize;
      }
      Array.Resize<int>(ref this.pointer, newSize);
      Array.Resize<int>(ref this.doorTag, newSize);
    }

    public void loadClickables() => this.loadClickRef();

    public void loadClickRef()
    {
      this.clickCount = 0;
      for (int index = 0; index < this.chestPos.Length; index += 4)
      {
        Vector4 vector4 = new Vector4(this.chestPos[index], this.chestPos[index + 1], this.chestPos[index + 2], this.chestPos[index + 3]);
        this.clickLocation[this.clickCount] = Matrix.CreateRotationY(vector4.W) * Matrix.CreateTranslation(new Vector3(vector4.X, vector4.Y, vector4.Z));
        ++this.clickCount;
      }
      for (int index = 0; index < this.trapPos.Length; index += 4)
      {
        Vector4 vector4 = new Vector4(this.trapPos[index], this.trapPos[index + 1], this.trapPos[index + 2], this.trapPos[index + 3]);
        this.clickLocation[this.clickCount] = Matrix.CreateRotationY(vector4.W) * Matrix.CreateTranslation(new Vector3(vector4.X, vector4.Y, vector4.Z));
        ++this.clickCount;
      }
      for (int index = 0; index < this.switchPos.Length; index += 4)
      {
        Vector4 vector4 = new Vector4(this.switchPos[index], this.switchPos[index + 1], this.switchPos[index + 2], this.switchPos[index + 3]);
        this.clickLocation[this.clickCount] = Matrix.CreateRotationY(vector4.W) * Matrix.CreateTranslation(new Vector3(vector4.X, vector4.Y, vector4.Z));
        ++this.clickCount;
      }
      for (int index = 0; index < this.gatePos.Length; index += 4)
      {
        Vector4 vector4 = new Vector4(this.gatePos[index], this.gatePos[index + 1], this.gatePos[index + 2], this.gatePos[index + 3]);
        this.clickLocation[this.clickCount] = Matrix.CreateRotationY(vector4.W) * Matrix.CreateTranslation(new Vector3(vector4.X, vector4.Y, vector4.Z));
        ++this.clickCount;
      }
    }

    public void buildFloor(int floor)
    {
      this.lastFloorBuilt = floor;
      this.clickList.Clear();
      this.clickListBool.Clear();
      this.triList.Clear();
      this.hallList.Clear();
      this.deadList.Clear();
      this.longList.Clear();
      this.cornerList.Clear();
      this.crossList.Clear();
      this.powerList.Clear();
      this.oxygenList.Clear();
      this.salvageList.Clear();
      Facility.facilityPlot = new List<float>();
      Facility.facilityPlot.Clear();
      Facility.facilityPlot.Add(this.entryPos[0]);
      Facility.facilityPlot.Add(this.entryPos[2] + 200f);
      Facility.facilityPlot.Add(this.entryPos[0]);
      Facility.facilityPlot.Add((float) ((double) this.entryPos[2] + 200.0 + 400.0));
      Facility.facilityPlot.Add(this.entryPos[0]);
      Facility.facilityPlot.Add((float) ((double) this.entryPos[2] + 200.0 + 800.0));
      Facility.facilityPlot.Add(this.entryPos[0]);
      Facility.facilityPlot.Add((float) ((double) this.entryPos[2] + 200.0 + 1200.0));
      Facility.facilityPlot.Add(this.entryPos[0]);
      Facility.facilityPlot.Add((float) ((double) this.entryPos[2] + 200.0 + 1600.0));
      Facility.facilityPlot.Add(this.entryPos[0]);
      Facility.facilityPlot.Add((float) ((double) this.entryPos[2] + 200.0 + 2000.0));
      for (int index1 = 0; index1 < this.gridwidth * 2; ++index1)
      {
        for (int index2 = 0; index2 < this.gridwidth * 2; ++index2)
        {
          Facility.heightData[index1, index2] = this.bottomless;
          Facility.clickable[index1, index2] = -1;
          this.heightsEntry[index1, index2] = this.bottomless;
          this.clickableEntry[index1, index2] = -1;
        }
      }
      Matrix matrix = Matrix.CreateRotationY(this.entryPos[3]) * Matrix.CreateTranslation(new Vector3(this.entryPos[0] / 100f, 0.0f, this.entryPos[2] / 100f));
      for (int index = 0; index < this.entryHit.Length; index += 3)
      {
        int x = this.entryHit[index] / 100;
        int num = (int) ((double) this.entryHit[index + 1] / (double) this.scaler);
        int z = this.entryHit[index + 2] / 100;
        Vector3 vector3 = Vector3.Transform(new Vector3((float) x, 0.0f, (float) z), matrix);
        this.entryRampHite = 1511f / this.scaler + (float) (int) this.entryPos[1] + Facility.offset.Y;
        Facility.heightData[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)] = (int) ((double) (num + (int) this.entryPos[1]) + (double) Facility.offset.Y);
        Facility.clickable[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)] = -13;
        if (x >= -2 && x <= 2 && z >= -35 && z < -31)
          Facility.clickable[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)] = -17;
        if ((x == -3 || x == 3) && z >= -35 && z < -26)
          Facility.clickable[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)] = -17;
        if (x >= -2 && x <= 2 && z >= -10 && z <= 0)
          Facility.clickable[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)] = -9;
      }
      for (int index = 0; index < this.entryHitEnter.Length; index += 3)
      {
        int x = this.entryHitEnter[index] / 100;
        int num = (int) ((double) this.entryHitEnter[index + 1] / (double) this.scaler);
        int z = this.entryHitEnter[index + 2] / 100;
        Vector3 vector3 = Vector3.Transform(new Vector3((float) x, 0.0f, (float) z), matrix);
        this.heightsEntry[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)] = (int) ((double) (num + (int) this.entryPos[1]) + (double) Facility.offset.Y);
        this.clickableEntry[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)] = -33;
        if (x >= -2 && x <= 1 && z >= -31 && z <= -26)
          this.clickableEntry[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)] = -30;
        if (z <= -42)
        {
          this.heightsEntry[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)] = this.bottomless;
          this.clickableEntry[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)] = -1;
        }
      }
      this.buildFloorRef(floor);
      this.assignClickables(floor, 0);
      Vector2 startpos = new Vector2(Facility.facilityPlot[0], Facility.facilityPlot[1]);
      Facility.reachPlot.Add(startpos.X);
      Facility.reachPlot.Add(startpos.Y);
      for (int index = 2; index < Facility.facilityPlot.Count; index += 2)
      {
        Vector2 destiny = new Vector2(Facility.facilityPlot[index], Facility.facilityPlot[index + 1]);
        if (this.botPath(ref Facility.facilityPlot, ref Facility.dummyPlot, startpos, destiny) == "good")
        {
          Facility.reachPlot.Add(destiny.X);
          Facility.reachPlot.Add(destiny.Y);
        }
      }
    }

    public void buildFloorRef(int floor)
    {
      if (this.powerPos != null)
      {
        for (int index = 0; index < this.powerPos.Length; index += 4)
        {
          this.powerList.Add(this.powerPos[index]);
          this.powerList.Add(this.powerPos[index + 1]);
          this.powerList.Add(this.powerPos[index + 2]);
          this.powerList.Add(this.powerPos[index + 3]);
          this.powerList.Add(0.0f);
          Matrix matrix = Matrix.CreateRotationY(this.powerPos[index + 3]) * Matrix.CreateTranslation(new Vector3(this.powerPos[index] / 100f, 0.0f, this.powerPos[index + 2] / 100f));
          for (int x = -4; x <= 5; ++x)
          {
            for (int z = -5; z <= 5; ++z)
            {
              Vector3 vector3 = Vector3.Transform(new Vector3((float) x, 0.0f, (float) z), matrix);
              Facility.heightData[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)] = (int) ((double) this.powerPos[index + 1] + (double) Facility.offset.Y);
            }
          }
          for (int z = -1; z <= 1; ++z)
          {
            Vector3 vector3 = Vector3.Transform(new Vector3(-5f, 0.0f, (float) z), matrix);
            Facility.heightData[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)] = (int) ((double) this.powerPos[index + 1] + (double) Facility.offset.Y);
            vector3 = Vector3.Transform(new Vector3(-6f, 0.0f, (float) z), matrix);
            Facility.heightData[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)] = (int) ((double) this.powerPos[index + 1] + (double) Facility.offset.Y);
            vector3 = Vector3.Transform(new Vector3(5f, 0.0f, (float) z), matrix);
            Facility.heightData[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)] = (int) ((double) this.powerPos[index + 1] + (double) Facility.offset.Y);
          }
          Matrix rotationY = Matrix.CreateRotationY(this.powerPos[index + 3]);
          for (int x = 0; x <= 1; ++x)
          {
            for (int z = -1; z <= 1; ++z)
            {
              Vector3 vector3 = Vector3.Transform(new Vector3((float) x, 0.0f, (float) z), rotationY);
              Facility.facilityPlot.Add(this.powerPos[index] + 400f * vector3.X);
              Facility.facilityPlot.Add(this.powerPos[index + 2] + 400f * vector3.Z);
            }
          }
          Vector3 vector3_1 = Vector3.Transform(new Vector3(-1f, 0.0f, 0.0f), rotationY);
          Facility.facilityPlot.Add(this.powerPos[index] + 400f * vector3_1.X);
          Facility.facilityPlot.Add(this.powerPos[index + 2] + 400f * vector3_1.Z);
        }
      }
      if (this.oxygenPos != null)
      {
        for (int index = 0; index < this.oxygenPos.Length; index += 4)
        {
          this.oxygenList.Add(this.oxygenPos[index]);
          this.oxygenList.Add(this.oxygenPos[index + 1]);
          this.oxygenList.Add(this.oxygenPos[index + 2]);
          this.oxygenList.Add(this.oxygenPos[index + 3]);
          this.oxygenList.Add(0.0f);
          Matrix matrix = Matrix.CreateRotationY(this.oxygenPos[index + 3]) * Matrix.CreateTranslation(new Vector3(this.oxygenPos[index] / 100f, 0.0f, this.oxygenPos[index + 2] / 100f));
          for (int x = -4; x <= 5; ++x)
          {
            for (int z = -5; z <= 5; ++z)
            {
              Vector3 vector3 = Vector3.Transform(new Vector3((float) x, 0.0f, (float) z), matrix);
              Facility.heightData[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)] = (int) ((double) (int) this.oxygenPos[index + 1] + (double) Facility.offset.Y);
            }
          }
          for (int z = -1; z <= 1; ++z)
          {
            Vector3 vector3_2 = Vector3.Transform(new Vector3(-5f, 0.0f, (float) z), matrix);
            Facility.heightData[(int) Math.Round((double) vector3_2.X), (int) Math.Round((double) vector3_2.Z)] = (int) ((double) (int) this.oxygenPos[index + 1] + (double) Facility.offset.Y);
            Vector3 vector3_3 = Vector3.Transform(new Vector3(-6f, 0.0f, (float) z), matrix);
            Facility.heightData[(int) Math.Round((double) vector3_3.X), (int) Math.Round((double) vector3_3.Z)] = (int) ((double) (int) this.oxygenPos[index + 1] + (double) Facility.offset.Y);
            Vector3 vector3_4 = Vector3.Transform(new Vector3(5f, 0.0f, (float) z), matrix);
            Facility.heightData[(int) Math.Round((double) vector3_4.X), (int) Math.Round((double) vector3_4.Z)] = (int) ((double) (int) this.oxygenPos[index + 1] + (double) Facility.offset.Y);
          }
          Matrix rotationY = Matrix.CreateRotationY(this.oxygenPos[index + 3]);
          for (int x = 0; x <= 1; ++x)
          {
            for (int z = -1; z <= 1; ++z)
            {
              Vector3 vector3 = Vector3.Transform(new Vector3((float) x, 0.0f, (float) z), rotationY);
              Facility.facilityPlot.Add(this.oxygenPos[index] + 400f * vector3.X);
              Facility.facilityPlot.Add(this.oxygenPos[index + 2] + 400f * vector3.Z);
            }
          }
          Vector3 vector3_5 = Vector3.Transform(new Vector3(-1f, 0.0f, 0.0f), rotationY);
          Facility.facilityPlot.Add(this.oxygenPos[index] + 400f * vector3_5.X);
          Facility.facilityPlot.Add(this.oxygenPos[index + 2] + 400f * vector3_5.Z);
        }
      }
      if (this.salvagePos != null)
      {
        for (int index = 0; index < this.salvagePos.Length; index += 4)
        {
          this.salvageList.Add(this.salvagePos[index]);
          this.salvageList.Add(this.salvagePos[index + 1]);
          this.salvageList.Add(this.salvagePos[index + 2]);
          this.salvageList.Add(this.salvagePos[index + 3]);
          this.salvageList.Add(0.0f);
          Matrix matrix = Matrix.CreateRotationY(this.salvagePos[index + 3]) * Matrix.CreateTranslation(new Vector3(this.salvagePos[index] / 100f, 0.0f, this.salvagePos[index + 2] / 100f));
          for (int x = -4; x <= 5; ++x)
          {
            for (int z = -5; z <= 5; ++z)
            {
              Vector3 vector3 = Vector3.Transform(new Vector3((float) x, 0.0f, (float) z), matrix);
              Facility.heightData[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)] = (int) ((double) this.salvagePos[index + 1] + (double) Facility.offset.Y);
            }
          }
          for (int z = -1; z <= 1; ++z)
          {
            Vector3 vector3 = Vector3.Transform(new Vector3(-5f, 0.0f, (float) z), matrix);
            Facility.heightData[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)] = (int) ((double) this.salvagePos[index + 1] + (double) Facility.offset.Y);
            vector3 = Vector3.Transform(new Vector3(-6f, 0.0f, (float) z), matrix);
            Facility.heightData[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)] = (int) ((double) this.salvagePos[index + 1] + (double) Facility.offset.Y);
            vector3 = Vector3.Transform(new Vector3(5f, 0.0f, (float) z), matrix);
            Facility.heightData[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)] = (int) ((double) this.salvagePos[index + 1] + (double) Facility.offset.Y);
          }
          Matrix rotationY = Matrix.CreateRotationY(this.salvagePos[index + 3]);
          for (int x = 0; x <= 1; ++x)
          {
            for (int z = -1; z <= 1; ++z)
            {
              Vector3 vector3 = Vector3.Transform(new Vector3((float) x, 0.0f, (float) z), rotationY);
              Facility.facilityPlot.Add(this.salvagePos[index] + 400f * vector3.X);
              Facility.facilityPlot.Add(this.salvagePos[index + 2] + 400f * vector3.Z);
            }
          }
          Vector3 vector3_6 = Vector3.Transform(new Vector3(-1f, 0.0f, 0.0f), rotationY);
          Facility.facilityPlot.Add(this.salvagePos[index] + 400f * vector3_6.X);
          Facility.facilityPlot.Add(this.salvagePos[index + 2] + 400f * vector3_6.Z);
        }
      }
      for (int index = 0; index < this.trihallPos.Length; index += 4)
      {
        this.triList.Add(this.trihallPos[index]);
        this.triList.Add(this.trihallPos[index + 1]);
        this.triList.Add(this.trihallPos[index + 2]);
        this.triList.Add(this.trihallPos[index + 3]);
        this.triList.Add(0.0f);
        Matrix matrix = Matrix.CreateRotationY(this.trihallPos[index + 3]) * Matrix.CreateTranslation(new Vector3(this.trihallPos[index] / 100f, 0.0f, this.trihallPos[index + 2] / 100f));
        for (int x = -6; x < 2; ++x)
        {
          for (int z = -1; z < 2; ++z)
          {
            Vector3 vector3 = Vector3.Transform(new Vector3((float) x, 0.0f, (float) z), matrix);
            Facility.heightData[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)] = (int) ((double) this.trihallPos[index + 1] + (double) Facility.offset.Y);
          }
        }
        for (int x = -1; x < 2; ++x)
        {
          for (int z = -6; z < 7; ++z)
          {
            Vector3 vector3 = Vector3.Transform(new Vector3((float) x, 0.0f, (float) z), matrix);
            Facility.heightData[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)] = (int) ((double) this.trihallPos[index + 1] + (double) Facility.offset.Y);
          }
        }
        Matrix rotationY = Matrix.CreateRotationY(this.trihallPos[index + 3]);
        for (int z = -1; z <= 1; ++z)
        {
          Vector3 vector3 = Vector3.Transform(new Vector3(0.0f, 0.0f, (float) z), rotationY);
          Facility.facilityPlot.Add(this.trihallPos[index] + 400f * vector3.X);
          Facility.facilityPlot.Add(this.trihallPos[index + 2] + 400f * vector3.Z);
        }
        Vector3 vector3_7 = Vector3.Transform(new Vector3(-1f, 0.0f, 0.0f), rotationY);
        Facility.facilityPlot.Add(this.trihallPos[index] + 400f * vector3_7.X);
        Facility.facilityPlot.Add(this.trihallPos[index + 2] + 400f * vector3_7.Z);
      }
      for (int index = 0; index < this.hallwayPos.Length; index += 4)
      {
        this.hallList.Add(this.hallwayPos[index]);
        this.hallList.Add(this.hallwayPos[index + 1]);
        this.hallList.Add(this.hallwayPos[index + 2]);
        this.hallList.Add(this.hallwayPos[index + 3]);
        this.hallList.Add(0.0f);
        Matrix matrix = Matrix.CreateRotationY(this.hallwayPos[index + 3]) * Matrix.CreateTranslation(new Vector3(this.hallwayPos[index] / 100f, 0.0f, this.hallwayPos[index + 2] / 100f));
        for (int x = -1; x < 2; ++x)
        {
          for (int z = -6; z < 3; ++z)
          {
            Vector3 vector3 = Vector3.Transform(new Vector3((float) x, 0.0f, (float) z), matrix);
            Facility.heightData[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)] = (int) ((double) this.hallwayPos[index + 1] + (double) Facility.offset.Y);
          }
        }
        Matrix rotationY = Matrix.CreateRotationY(this.hallwayPos[index + 3]);
        for (int z = -1; z <= 0; ++z)
        {
          Vector3 vector3 = Vector3.Transform(new Vector3(0.0f, 0.0f, (float) z), rotationY);
          Facility.facilityPlot.Add(this.hallwayPos[index] + 400f * vector3.X);
          Facility.facilityPlot.Add(this.hallwayPos[index + 2] + 400f * vector3.Z);
        }
      }
      for (int index = 0; index < this.longPos.Length; index += 4)
      {
        this.longList.Add(this.longPos[index]);
        this.longList.Add(this.longPos[index + 1]);
        this.longList.Add(this.longPos[index + 2]);
        this.longList.Add(this.longPos[index + 3]);
        this.longList.Add(1f);
        Matrix matrix = Matrix.CreateRotationY(this.longPos[index + 3]) * Matrix.CreateTranslation(new Vector3(this.longPos[index] / 100f, 0.0f, this.longPos[index + 2] / 100f));
        for (int x = -1; x < 2; ++x)
        {
          for (int z = -6; z < 7; ++z)
          {
            Vector3 vector3 = Vector3.Transform(new Vector3((float) x, 0.0f, (float) z), matrix);
            Facility.heightData[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)] = (int) ((double) this.longPos[index + 1] + (double) Facility.offset.Y);
          }
        }
        Matrix rotationY = Matrix.CreateRotationY(this.longPos[index + 3]);
        for (int z = -1; z <= 1; ++z)
        {
          Vector3 vector3 = Vector3.Transform(new Vector3(0.0f, 0.0f, (float) z), rotationY);
          Facility.facilityPlot.Add(this.longPos[index] + 400f * vector3.X);
          Facility.facilityPlot.Add(this.longPos[index + 2] + 400f * vector3.Z);
        }
      }
      for (int index = 0; index < this.cornerPos.Length; index += 4)
      {
        this.cornerList.Add(this.cornerPos[index]);
        this.cornerList.Add(this.cornerPos[index + 1]);
        this.cornerList.Add(this.cornerPos[index + 2]);
        this.cornerList.Add(this.cornerPos[index + 3]);
        this.cornerList.Add(0.0f);
        Matrix matrix = Matrix.CreateRotationY(this.cornerPos[index + 3]) * Matrix.CreateTranslation(new Vector3(this.cornerPos[index] / 100f, 0.0f, this.cornerPos[index + 2] / 100f));
        for (int x = -1; x < 2; ++x)
        {
          for (int z = -6; z < 2; ++z)
          {
            Vector3 vector3 = Vector3.Transform(new Vector3((float) x, 0.0f, (float) z), matrix);
            Facility.heightData[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)] = (int) ((double) this.cornerPos[index + 1] + (double) Facility.offset.Y);
          }
        }
        for (int x = -6; x < 2; ++x)
        {
          for (int z = -1; z < 2; ++z)
          {
            Vector3 vector3 = Vector3.Transform(new Vector3((float) x, 0.0f, (float) z), matrix);
            Facility.heightData[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)] = (int) ((double) this.cornerPos[index + 1] + (double) Facility.offset.Y);
          }
        }
        Matrix rotationY = Matrix.CreateRotationY(this.cornerPos[index + 3]);
        for (int z = -1; z <= 0; ++z)
        {
          Vector3 vector3 = Vector3.Transform(new Vector3(0.0f, 0.0f, (float) z), rotationY);
          Facility.facilityPlot.Add(this.cornerPos[index] + 400f * vector3.X);
          Facility.facilityPlot.Add(this.cornerPos[index + 2] + 400f * vector3.Z);
        }
        Vector3 vector3_8 = Vector3.Transform(new Vector3(-1f, 0.0f, 0.0f), rotationY);
        Facility.facilityPlot.Add(this.cornerPos[index] + 400f * vector3_8.X);
        Facility.facilityPlot.Add(this.cornerPos[index + 2] + 400f * vector3_8.Z);
      }
      for (int index = 0; index < this.deadPos.Length; index += 4)
      {
        this.deadList.Add(this.deadPos[index]);
        this.deadList.Add(this.deadPos[index + 1]);
        this.deadList.Add(this.deadPos[index + 2]);
        this.deadList.Add(this.deadPos[index + 3]);
        this.deadList.Add(0.0f);
        Matrix matrix = Matrix.CreateRotationY(this.deadPos[index + 3]) * Matrix.CreateTranslation(new Vector3(this.deadPos[index] / 100f, 0.0f, this.deadPos[index + 2] / 100f));
        for (int x = -1; x < 2; ++x)
        {
          for (int z = -6; z < 2; ++z)
          {
            Vector3 vector3 = Vector3.Transform(new Vector3((float) x, 0.0f, (float) z), matrix);
            Facility.heightData[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)] = (int) ((double) this.deadPos[index + 1] + (double) Facility.offset.Y);
          }
        }
        Matrix rotationY = Matrix.CreateRotationY(this.deadPos[index + 3]);
        for (int z = -1; z <= 0; ++z)
        {
          Vector3 vector3 = Vector3.Transform(new Vector3(0.0f, 0.0f, (float) z), rotationY);
          Facility.facilityPlot.Add(this.deadPos[index] + 400f * vector3.X);
          Facility.facilityPlot.Add(this.deadPos[index + 2] + 400f * vector3.Z);
        }
      }
      for (int index = 0; index < this.crossPos.Length; index += 4)
      {
        this.crossList.Add(this.crossPos[index]);
        this.crossList.Add(this.crossPos[index + 1]);
        this.crossList.Add(this.crossPos[index + 2]);
        this.crossList.Add(this.crossPos[index + 3]);
        this.crossList.Add(0.0f);
        Matrix matrix = Matrix.CreateRotationY(this.crossPos[index + 3]) * Matrix.CreateTranslation(new Vector3(this.crossPos[index] / 100f, 0.0f, this.crossPos[index + 2] / 100f));
        for (int x = -6; x < 7; ++x)
        {
          for (int z = -1; z < 2; ++z)
          {
            Vector3 vector3 = Vector3.Transform(new Vector3((float) x, 0.0f, (float) z), matrix);
            Facility.heightData[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)] = (int) ((double) this.crossPos[index + 1] + (double) Facility.offset.Y);
          }
        }
        for (int x = -1; x < 2; ++x)
        {
          for (int z = -6; z < 7; ++z)
          {
            Vector3 vector3 = Vector3.Transform(new Vector3((float) x, 0.0f, (float) z), matrix);
            Facility.heightData[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)] = (int) ((double) this.crossPos[index + 1] + (double) Facility.offset.Y);
          }
        }
        Matrix rotationY = Matrix.CreateRotationY(this.crossPos[index + 3]);
        for (int z = -1; z <= 1; ++z)
        {
          Vector3 vector3 = Vector3.Transform(new Vector3(0.0f, 0.0f, (float) z), rotationY);
          Facility.facilityPlot.Add(this.crossPos[index] + 400f * vector3.X);
          Facility.facilityPlot.Add(this.crossPos[index + 2] + 400f * vector3.Z);
        }
        Vector3 vector3_9 = Vector3.Transform(new Vector3(-1f, 0.0f, 0.0f), rotationY);
        Facility.facilityPlot.Add(this.crossPos[index] + 400f * vector3_9.X);
        Facility.facilityPlot.Add(this.crossPos[index + 2] + 400f * vector3_9.Z);
        vector3_9 = Vector3.Transform(new Vector3(1f, 0.0f, 0.0f), rotationY);
        Facility.facilityPlot.Add(this.crossPos[index] + 400f * vector3_9.X);
        Facility.facilityPlot.Add(this.crossPos[index + 2] + 400f * vector3_9.Z);
      }
      for (int index = 0; index < this.chestPos.Length; index += 4)
      {
        Vector3 vector3 = Vector3.Transform(new Vector3(0.0f, 0.0f, 0.0f), Matrix.CreateRotationY(this.chestPos[index + 3]) * Matrix.CreateTranslation(new Vector3(this.chestPos[index] / 100f, 0.0f, this.chestPos[index + 2] / 100f)));
        Facility.heightData[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)] = this.bottomless;
      }
    }

    private string botPath(
      ref List<float> floorplot,
      ref List<Vector2> botPath,
      Vector2 startpos,
      Vector2 destiny)
    {
      List<Vector2> vector2List = new List<Vector2>();
      float num1 = 800f;
      int index1 = -1;
      for (int index2 = 0; index2 < floorplot.Count; index2 += 2)
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
        return "lost early";
      Vector2 start = new Vector2(floorplot[index1] + 0.0f, floorplot[index1 + 1] + 0.0f);
      List<Vector2> search = new List<Vector2>();
      List<Vector2> result = new List<Vector2>();
      vector2List.ForEach((Action<Vector2>) (item => search.Add(item)));
      bool flag = this.buildbotPath(ref search, ref result, start, destiny);
      botPath.Clear();
      for (int index3 = 0; index3 < result.Count; ++index3)
        botPath.Add(result[index3]);
      botPath.Add(destiny);
      return !flag ? "lost here " : "good";
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

    public void assignClickables(int floor, int dist)
    {
      for (int num = 0; num < this.clickCount; ++num)
      {
        bool flag = this.pointer[num] >= 290 && this.pointer[num] <= 291;
        if (this.pointer[num] > 299)
          ;
        Vector3 mov = Vector3.Transform(Vector3.Zero, this.clickLocation[num]);
        if ((floor != 1 || (double) mov.Y < -460.0) && (floor != 2 || (double) mov.Y >= -460.0 && (double) mov.Y < 0.0) && (floor != 3 || (double) mov.Y >= 0.0 && (double) mov.Y < 460.0) && (floor != 4 || (double) mov.Y >= 460.0 && (double) mov.Y < 920.0) && (floor != 5 || (double) mov.Y >= 920.0 && (double) mov.Y < 1380.0) && (floor != 6 || (double) mov.Y >= 1380.0 && (double) mov.Y < 1840.0))
        {
          if (!flag)
            this.addClickabletoGrid(mov, num);
          this.clickList.Add(num);
          this.clickListBool.Add(true);
        }
      }
    }

    public void addClickabletoGrid(Vector3 mov, int num)
    {
      if (this.pointer[num] < 1)
        return;
      mov.X = (float) (int) Math.Round((double) mov.X / 100.0);
      mov.Z = (float) (int) Math.Round((double) mov.Z / 100.0);
      Facility.clickable[(int) mov.X - 1, (int) mov.Z - 1] = num;
      Facility.clickable[(int) mov.X, (int) mov.Z - 1] = num;
      Facility.clickable[(int) mov.X + 1, (int) mov.Z - 1] = num;
      Facility.clickable[(int) mov.X - 1, (int) mov.Z] = num;
      Facility.clickable[(int) mov.X, (int) mov.Z] = num;
      Facility.clickable[(int) mov.X + 1, (int) mov.Z] = num;
      Facility.clickable[(int) mov.X - 1, (int) mov.Z + 1] = num;
      Facility.clickable[(int) mov.X, (int) mov.Z + 1] = num;
      Facility.clickable[(int) mov.X + 1, (int) mov.Z + 1] = num;
      if (this.pointer[num] >= 100 && this.pointer[num] <= 150)
      {
        Vector3 vector3_1 = Vector3.Transform(Vector3.Zero, this.clickLocation[num]);
        Vector3 vector3_2 = Vector3.Transform(new Vector3(0.0f, 0.0f, -1f), this.clickLocation[num]) - vector3_1;
        Vector3 vector3_3 = Vector3.Transform(new Vector3(-1f, 0.0f, 0.0f), this.clickLocation[num]) - vector3_1;
        int x1 = (int) vector3_2.X;
        int z1 = (int) vector3_2.Z;
        int x2 = (int) vector3_3.X;
        int z2 = (int) vector3_3.Z;
        Facility.clickable[(int) mov.X + x2 * -1 + x1 * 2, (int) mov.Z + z2 * -1 + z1 * 2] = num;
        Facility.clickable[(int) mov.X + x1 * 2, (int) mov.Z + z1 * 2] = num;
        Facility.clickable[(int) mov.X + x2 + x1 * 2, (int) mov.Z + z2 + z1 * 2] = num;
        Facility.clickable[(int) mov.X + x2 * -1 + x1 * -2, (int) mov.Z + z2 * -1 + z1 * -2] = num;
        Facility.clickable[(int) mov.X + x1 * -2, (int) mov.Z + z1 * -2] = num;
        Facility.clickable[(int) mov.X + x2 + x1 * -2, (int) mov.Z + z2 + z1 * -2] = num;
        Facility.clickable[(int) mov.X + x2 * -1 + x1 * 3, (int) mov.Z + z2 * -1 + z1 * 3] = num;
        Facility.clickable[(int) mov.X + x1 * 3, (int) mov.Z + z1 * 3] = num;
        Facility.clickable[(int) mov.X + x2 + x1 * 3, (int) mov.Z + z2 + z1 * 3] = num;
        Facility.clickable[(int) mov.X + x2 * -1 + x1 * -3, (int) mov.Z + z2 * -1 + z1 * -3] = num;
        Facility.clickable[(int) mov.X + x1 * -3, (int) mov.Z + z1 * -3] = num;
        Facility.clickable[(int) mov.X + x2 + x1 * -3, (int) mov.Z + z2 + z1 * -3] = num;
        Facility.clickable[(int) mov.X + x2 * -1 + x1 * 4, (int) mov.Z + z2 * -1 + z1 * 4] = num;
        Facility.clickable[(int) mov.X + x1 * 4, (int) mov.Z + z1 * 4] = num;
        Facility.clickable[(int) mov.X + x2 + x1 * 4, (int) mov.Z + z2 + z1 * 4] = num;
        Facility.clickable[(int) mov.X + x2 * -1 + x1 * -4, (int) mov.Z + z2 * -1 + z1 * -4] = num;
        Facility.clickable[(int) mov.X + x1 * -4, (int) mov.Z + z1 * -4] = num;
        Facility.clickable[(int) mov.X + x2 + x1 * -4, (int) mov.Z + z2 + z1 * -4] = num;
      }
      if ((this.pointer[num] <= 0 || this.pointer[num] > 44) && (this.pointer[num] < 500 || this.pointer[num] >= 700))
        return;
      Vector3 vector3_4 = Vector3.Transform(Vector3.Zero, this.clickLocation[num]);
      Vector3 vector3_5 = Vector3.Transform(new Vector3(-1f, 0.0f, 0.0f), this.clickLocation[num]) - vector3_4;
      Vector3 vector3_6 = Vector3.Transform(new Vector3(0.0f, 0.0f, -1f), this.clickLocation[num]) - vector3_4;
      int x3 = (int) vector3_5.X;
      int z3 = (int) vector3_5.Z;
      int x4 = (int) vector3_6.X;
      int z4 = (int) vector3_6.Z;
      int num1 = Facility.clickable[(int) mov.X + x4 * -1 + x3 * 2, (int) mov.Z + z4 * -1 + z3 * 2];
      int num2 = Facility.clickable[(int) mov.X + x3 * 2, (int) mov.Z + z3 * 2];
      int num3 = Facility.clickable[(int) mov.X + x4 + x3 * 2, (int) mov.Z + z4 + z3 * 2];
      if (num1 < 0)
        Facility.clickable[(int) mov.X + x4 * -1 + x3 * 2, (int) mov.Z + z4 * -1 + z3 * 2] = num;
      if (num2 < 0)
        Facility.clickable[(int) mov.X + x3 * 2, (int) mov.Z + z3 * 2] = num;
      if (num3 >= 0)
        return;
      Facility.clickable[(int) mov.X + x4 + x3 * 2, (int) mov.Z + z4 + z3 * 2] = num;
    }

    public void updateGateCollision()
    {
      for (int index1 = 0; index1 < this.gatePos.Length; index1 += 4)
      {
        Matrix matrix = Matrix.CreateRotationY(this.gatePos[index1 + 3]) * Matrix.CreateTranslation(new Vector3(this.gatePos[index1] / 100f, 0.0f, this.gatePos[index1 + 2] / 100f));
        Vector3 vector3 = Vector3.Transform(new Vector3(0.0f, 0.0f, 0.0f), matrix);
        int num = this.bottomless;
        int index2 = Facility.clickable[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)];
        if (index2 > -1)
        {
          if (this.pointer[index2] >= 100 && this.pointer[index2] <= 109)
            num = this.bottomless;
          if (this.pointer[index2] >= 110 && this.pointer[index2] <= 119)
            num = (int) ((double) this.gatePos[index1 + 1] / (double) this.scaler + (double) Facility.offset.Y);
          for (int x = -2; x < 3; ++x)
          {
            vector3 = Vector3.Transform(new Vector3((float) x, 0.0f, 0.0f), matrix);
            Facility.heightData[(int) Math.Round((double) vector3.X), (int) Math.Round((double) vector3.Z)] = num;
          }
        }
      }
    }

    public void closeGates()
    {
      for (int index1 = 0; index1 < this.closeGate.Count; ++index1)
      {
        int index2 = this.closeGate[index1];
        if (this.pointer[index2] >= 110 && this.pointer[index2] <= 119)
        {
          float num = 400f;
          if ((double) this.gateTrans[index2] == (double) num && !this.sc.astronaut.doorList.Contains(index2))
          {
            if (this.clickList.Contains(index2))
            {
              if ((double) Vector3.Distance(Vector3.Transform(Vector3.Zero, this.clickLocation[index2] * this.faciltyMatrix), this.campos) > 100.0)
              {
                this.sc.door.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
                this.pointer[index2] -= 10;
                this.closeGate.Remove(index2);
                break;
              }
            }
            else if (index2 != this.sc.frontDoor)
            {
              this.pointer[index2] -= 10;
              this.gateTrans[index2] = 0.0f;
              this.closeGate.Remove(index2);
              break;
            }
          }
        }
        else
        {
          this.closeGate.Remove(index2);
          break;
        }
      }
    }

    public void opengateSLOW(int tempGate)
    {
      if (tempGate < 0)
        return;
      if (this.pointer[tempGate] >= 115)
        this.pointer[tempGate] -= 5;
      if (this.pointer[tempGate] >= 100 && this.pointer[tempGate] < 110)
      {
        if (this.pointer[tempGate] > 104)
          this.pointer[tempGate] -= 5;
        this.pointer[tempGate] += 10;
      }
      if (this.pointer[tempGate] == 101 || this.pointer[tempGate] == 111 || tempGate > 0)
        ;
      if (this.pointer[tempGate] != 110 && this.pointer[tempGate] != 111 || this.closeGate.Contains(tempGate))
        return;
      this.closeGate.Add(tempGate);
    }

    public void opengateFAST(int tempGate)
    {
      if (this.pointer[tempGate] >= 115)
        this.pointer[tempGate] -= 5;
      if (this.pointer[tempGate] >= 100 && this.pointer[tempGate] < 110)
      {
        if (this.pointer[tempGate] > 104)
          this.pointer[tempGate] -= 5;
        this.pointer[tempGate] += 10;
      }
      float num = 240f;
      if (tempGate == this.sc.frontDoor)
        num = 360f;
      else if (this.doorTag[tempGate] > 0)
        num = 360f;
      this.gateTrans[tempGate] = num;
      if (this.pointer[tempGate] != 110 && this.pointer[tempGate] != 111 || this.closeGate.Contains(tempGate))
        return;
      this.closeGate.Add(tempGate);
    }

    public float animGate(int p)
    {
      if (this.pointer[p] >= 100 && this.pointer[p] < 110)
      {
        float num = -20f;
        if ((double) this.gateTrans[p] > 0.0)
        {
          this.gateTrans[p] += num;
          if ((double) this.gateTrans[p] == 300.0)
            this.updateGateCollision();
          if ((double) this.gateTrans[p] <= 0.0)
          {
            this.gateTrans[p] = 0.0f;
            this.updateGateCollision();
          }
        }
        return this.gateTrans[p];
      }
      if (this.pointer[p] < 110 || this.pointer[p] > 120)
        return this.gateTrans[p];
      float num1 = 400f;
      float num2 = 20f;
      if ((double) this.gateTrans[p] < (double) num1)
      {
        this.gateTrans[p] += num2;
        if ((double) this.gateTrans[p] == 100.0)
          this.updateGateCollision();
        if ((double) this.gateTrans[p] >= (double) num1)
        {
          this.gateTrans[p] = num1;
          this.updateGateCollision();
        }
      }
      return this.gateTrans[p];
    }

    public bool Ktoggle(Keys k) => this.keyState.IsKeyDown(k) && this.prevkeyState.IsKeyUp(k);

    public void HandleInput(
      InputState input,
      GamePadState gamePadState,
      GamePadState prevstate,
      Vector3 camposX,
      Vector3 camlookpos)
    {
      int gridVal = this.gridVal;
      this.campos = camposX;
      this.camlookpos = camlookpos;
      this.prevkeyState = input.lastKeyState;
      this.keyState = input.currentKeyState;
      if (this.sc.astronaut.doorList.Count > 0)
      {
        for (int index = 0; index < this.sc.astronaut.doorList.Count; ++index)
        {
          int door = this.sc.astronaut.doorList[index];
          if (this.pointer[door] >= 100 && this.pointer[door] <= 104)
          {
            this.sc.door.Play(this.sc.ev * 0.1f, 0.0f, 0.0f);
            this.opengateSLOW(door);
          }
        }
      }
      if (this.myframe % 20 == 0)
      {
        Facility.atSwitch = false;
        Facility.atSwitch2 = false;
        Facility.atMain = false;
        if (gridVal > -1)
        {
          this.pos = Vector3.Transform(Vector3.Zero, this.clickLocation[gridVal] * this.faciltyMatrix);
          if (this.pointer[gridVal] > 249 && this.pointer[gridVal] < 280)
            this.pos = Vector3.Transform(new Vector3(-278f, 210f, 0.0f), this.clickLocation[gridVal] * this.faciltyMatrix);
          this.norm1 = Vector2.Normalize(new Vector2(this.pos.X, this.pos.Z) - new Vector2(this.campos.X, this.campos.Z));
          this.norm2 = Vector2.Normalize(new Vector2(camlookpos.X, camlookpos.Z) - new Vector2(this.campos.X, this.campos.Z));
          this.dot = Vector2.Dot(this.norm1, this.norm2);
          this.facingIt = (double) this.dot > 0.699999988079071;
          if (this.facingIt)
          {
            if (this.pointer[gridVal] >= 250 && this.pointer[gridVal] <= 280)
            {
              if (this.doorTag[gridVal] == 49)
                Facility.atSwitch = true;
              if (this.doorTag[gridVal] == 40)
                Facility.atSwitch2 = true;
            }
            if (this.pointer[gridVal] == 101)
              Facility.atMain = true;
          }
        }
      }
      if (!this.Ktoggle(this.sc.x_key) && (gamePadState.Buttons.A != ButtonState.Pressed || prevstate.Buttons.A != ButtonState.Released) || gridVal <= -1)
        return;
      this.pos = Vector3.Transform(Vector3.Zero, this.clickLocation[gridVal] * this.faciltyMatrix);
      if (this.pointer[gridVal] > 249 && this.pointer[gridVal] < 280)
        this.pos = Vector3.Transform(new Vector3(-278f, 210f, 0.0f), this.clickLocation[gridVal] * this.faciltyMatrix);
      this.norm1 = Vector2.Normalize(new Vector2(this.pos.X, this.pos.Z) - new Vector2(this.campos.X, this.campos.Z));
      this.norm2 = Vector2.Normalize(new Vector2(camlookpos.X, camlookpos.Z) - new Vector2(this.campos.X, this.campos.Z));
      this.dot = Vector2.Dot(this.norm1, this.norm2);
      this.facingIt = (double) this.dot > 0.699999988079071;
      if (!this.facingIt)
        return;
      if (this.pointer[gridVal] >= 250 && this.pointer[gridVal] <= 280)
      {
        if (this.pointer[gridVal] == 250)
        {
          this.switchRot[gridVal] = 0.0f;
          this.pointer[gridVal] = 251;
        }
        else if (this.pointer[gridVal] == 251)
        {
          this.switchRot[gridVal] = -1.57f;
          this.pointer[gridVal] = 250;
        }
        if (this.doorTag[gridVal] == 49)
        {
          this.sc.lever.Play(this.sc.ev, 0.2f, 0.0f);
          Facility.openConstruction = true;
        }
        if (this.doorTag[gridVal] == 40)
          Facility.createWorkerLoc = new Vector4(this.salvageList[0] / this.scaler + Facility.offset.X, this.salvageList[1] / this.scaler + Facility.offset.Y, this.salvageList[2] / this.scaler + Facility.offset.Z, this.salvageList[3]);
      }
      if (this.pointer[gridVal] >= 100 && this.pointer[gridVal] <= 104)
      {
        if (this.pointer[gridVal] == 101)
        {
          this.sc.door.Play(this.sc.ev * 0.4f, 0.0f, 0.0f);
          this.opengateSLOW(gridVal);
        }
        else
        {
          this.sc.door.Play(this.sc.ev * 0.4f, 0.0f, 0.0f);
          this.opengateSLOW(gridVal);
        }
      }
      else
      {
        if (this.pointer[gridVal] < 105 || this.pointer[gridVal] > 109 || this.gateShake != 0)
          return;
        if (this.doorTag[gridVal] == 0)
        {
          this.gateShake = 61;
          this.clangID = gridVal;
          this.gateShakeMatrix = this.clickLocation[gridVal];
          this.gateRot = (double) Math.Abs(this.campos.X - camlookpos.X) <= (double) Math.Abs(this.campos.Z - camlookpos.Z) ? 1.57f : 0.0f;
        }
        if (this.doorTag[gridVal] != 64)
          return;
        this.pointer[gridVal] = 100;
        this.sc.click.Play(this.sc.ev, 0.0f, 0.0f);
      }
    }

    public void Update()
    {
      ++this.myframe;
      if (this.gateShake > 0)
      {
        --this.gateShake;
        this.clickLocation[this.clangID] *= Matrix.CreateTranslation(Vector3.Transform(new Vector3((float) Math.Sin((double) this.gateShake) * (float) (this.gateShake / 12), 0.0f, 0.0f), Matrix.CreateRotationY(this.gateRot)));
        if (this.gateShake == 0)
          this.clickLocation[this.clangID] = this.gateShakeMatrix;
      }
      if (this.myframe % 10 != 0)
        return;
      Vector2 vector2 = new Vector2(this.campos.X, this.campos.Z);
      for (int index = 0; index < this.clickList.Count; ++index)
      {
        int click = this.clickList[index];
        Vector3 vector3 = Vector3.Transform(Vector3.Zero, this.clickLocation[click] * this.faciltyMatrix);
        float num = Vector2.DistanceSquared(vector2, new Vector2(vector3.X, vector3.Z));
        if (this.pointer[click] > 249 && this.pointer[click] < 280)
          vector3 = Vector3.Transform(new Vector3(-200f, 170f, 0.0f), this.clickLocation[click] * this.faciltyMatrix);
        this.norm1 = Vector2.Normalize(new Vector2(vector3.X, vector3.Z) - new Vector2(this.campos.X, this.campos.Z));
        this.norm2 = Vector2.Normalize(new Vector2(this.camlookpos.X, this.camlookpos.Z) - new Vector2(this.campos.X, this.campos.Z));
        this.dot = Vector2.Dot(this.norm1, this.norm2);
        bool flag = (double) this.dot > 0.20000000298023224;
        this.clickListBool[index] = false;
        if ((double) num < (double) this.sightLimit && flag || (double) num < 90000.0)
          this.clickListBool[index] = true;
      }
      this.checkFacing(ref this.triList);
      this.checkFacing(ref this.longList);
      this.checkFacing(ref this.hallList);
      this.checkFacing(ref this.cornerList);
      this.checkFacing(ref this.deadList);
      this.checkFacing(ref this.crossList);
      this.checkFacing(ref this.powerList);
      this.checkFacing(ref this.oxygenList);
      this.checkFacing(ref this.salvageList);
    }

    public void checkFacing(ref List<float> parts)
    {
      Vector2 vector2 = new Vector2(this.campos.X, this.campos.Z);
      for (int index = 0; index < parts.Count; index += 5)
      {
        Vector3 vector3 = new Vector3(parts[index], parts[index + 1], parts[index + 2]);
        vector3.X /= this.scaler;
        vector3.Z /= this.scaler;
        vector3 += Facility.offset;
        float d = Vector2.DistanceSquared(vector2, new Vector2(vector3.X, vector3.Z));
        this.norm1 = Vector2.Normalize(new Vector2(vector3.X, vector3.Z) - new Vector2(this.campos.X, this.campos.Z));
        this.norm2 = Vector2.Normalize(new Vector2(this.camlookpos.X, this.camlookpos.Z) - new Vector2(this.campos.X, this.campos.Z));
        this.dot = Vector2.Dot(this.norm1, this.norm2);
        bool flag = (double) this.dot > 0.10000000149011612;
        parts[index + 4] = 0.0f;
        if ((double) d < (double) this.sightLimit && flag || (double) d < 160000.0)
        {
          float num = MathHelper.Clamp((float) (1.0 - (Math.Sqrt((double) d) - 50.0) / 400.0), 0.02f, 1f);
          parts[index + 4] = num * this.sc.ev;
        }
      }
    }

    public void DrawBlack(Matrix viewMatrix, Matrix projectionMatrix, Vector3 campos)
    {
      this.faciltyMatrix = Matrix.CreateScale(1f / this.scaler) * Matrix.CreateTranslation(Facility.offset);
      this.fogEffect.Parameters["view"].SetValue(viewMatrix);
      this.fogEffect.Parameters["projection"].SetValue(projectionMatrix);
      this.fogEffect.Parameters["lightColor"].SetValue(new Vector4(1f, 1f, 1f, 1f));
      Vector2 vector2 = new Vector2(campos.X, campos.Z);
      string tech = "black";
      this.facShader.Parameters["view"].SetValue(viewMatrix);
      this.facShader.Parameters["projection"].SetValue(projectionMatrix);
      this.facShader.Parameters[nameof (campos)].SetValue(campos);
      this.drawingEntry = Facility.outsideCastle || this.gridVal < -4 || (double) this.gateTrans[this.sc.frontDoor] != 0.0 || this.gridVal == this.sc.frontDoor;
      if (this.drawingEntry)
        this.DrawEntryWay(this.entryWay, new Vector3(this.entryPos[0], this.entryPos[1], this.entryPos[2]), this.entryPos[3], this.entryTexture, this.dirtrgb, "green");
      for (int index1 = 0; index1 < this.powerList.Count; index1 += 5)
      {
        int index2 = (int) (((double) this.powerList[index1 + 1] + 920.0) / 460.0);
        if ((double) this.powerList[index1 + 4] > 0.0)
          this.castlePartGreen(this.powerHall, new Vector3(this.powerList[index1], this.powerList[index1 + 1], this.powerList[index1 + 2]), this.powerList[index1 + 3], this.whiteRect, this.rgbRect[index2], tech);
      }
      for (int index3 = 0; index3 < this.oxygenList.Count; index3 += 5)
      {
        int index4 = (int) (((double) this.oxygenList[index3 + 1] + 920.0) / 460.0);
        if ((double) this.oxygenList[index3 + 4] > 0.0)
          this.castlePartGreen(this.oxygenHall, new Vector3(this.oxygenList[index3], this.oxygenList[index3 + 1], this.oxygenList[index3 + 2]), this.oxygenList[index3 + 3], this.whiteRect, this.rgbRect[index4], tech);
      }
      for (int index5 = 0; index5 < this.salvageList.Count; index5 += 5)
      {
        int index6 = (int) (((double) this.salvageList[index5 + 1] + 920.0) / 460.0);
        if ((double) this.salvageList[index5 + 4] > 0.0)
          this.castlePartGreen(this.salvageHall, new Vector3(this.salvageList[index5], this.salvageList[index5 + 1], this.salvageList[index5 + 2]), this.salvageList[index5 + 3], this.whiteRect, this.rgbRect[index6], tech);
      }
      for (int index7 = 0; index7 < this.triList.Count; index7 += 5)
      {
        int index8 = (int) (((double) this.triList[index7 + 1] + 920.0) / 460.0);
        if ((double) this.triList[index7 + 4] > 0.0)
          this.castlePartGreen(this.triHall, new Vector3(this.triList[index7], this.triList[index7 + 1], this.triList[index7 + 2]), this.triList[index7 + 3], this.whiteRect, this.rgbRect[index8], tech);
      }
      for (int index9 = 0; index9 < this.hallList.Count; index9 += 5)
      {
        int index10 = (int) (((double) this.hallList[index9 + 1] + 920.0) / 460.0);
        if ((double) this.hallList[index9 + 4] > 0.0)
          this.castlePartGreen(this.hallWay, new Vector3(this.hallList[index9], this.hallList[index9 + 1], this.hallList[index9 + 2]), this.hallList[index9 + 3], this.whiteRect, this.rgbRect[index10], tech);
      }
      for (int index11 = 0; index11 < this.crossList.Count; index11 += 5)
      {
        int index12 = (int) (((double) this.crossList[index11 + 1] + 920.0) / 460.0);
        if ((double) this.crossList[index11 + 4] > 0.0)
          this.castlePartGreen(this.crossHall, new Vector3(this.crossList[index11], this.crossList[index11 + 1], this.crossList[index11 + 2]), this.crossList[index11 + 3], this.whiteRect, this.rgbRect[index12], tech);
      }
      for (int index13 = 0; index13 < this.longList.Count; index13 += 5)
      {
        int index14 = (int) (((double) this.longList[index13 + 1] + 920.0) / 460.0);
        if ((double) this.longList[index13 + 4] > 0.0)
          this.castlePartGreen(this.longHall, new Vector3(this.longList[index13], this.longList[index13 + 1], this.longList[index13 + 2]), this.longList[index13 + 3], this.whiteRect, this.rgbRect[index14], tech);
      }
      for (int index15 = 0; index15 < this.cornerList.Count; index15 += 5)
      {
        int index16 = (int) (((double) this.cornerList[index15 + 1] + 920.0) / 460.0);
        if ((double) this.cornerList[index15 + 4] > 0.0)
          this.castlePartGreen(this.corner, new Vector3(this.cornerList[index15], this.cornerList[index15 + 1], this.cornerList[index15 + 2]), this.cornerList[index15 + 3], this.whiteRect, this.rgbRect[index16], tech);
      }
      for (int index17 = 0; index17 < this.deadList.Count; index17 += 5)
      {
        int index18 = (int) (((double) this.deadList[index17 + 1] + 920.0) / 460.0);
        if ((double) this.deadList[index17 + 4] > 0.0)
          this.castlePartGreen(this.deadend, new Vector3(this.deadList[index17], this.deadList[index17 + 1], this.deadList[index17 + 2]), this.deadList[index17 + 3], this.whiteRect, this.rgbRect[index18], tech);
      }
      for (int index = 0; index < this.clickList.Count; ++index)
      {
        int click = this.clickList[index];
        if (this.pointer[click] >= 290)
          ;
        if (this.pointer[click] > 0 && (this.clickListBool[index] || !Facility.inFacility && click == this.sc.frontDoor))
        {
          if (this.pointer[click] >= 100 && this.pointer[click] <= 150)
          {
            if (click != this.sc.frontDoor)
              this.DrawSpaceDoor(this.mainDoor, this.clickLocation[click], this.gateTrans[click], this.gateshadRect, this.gatergbRect2, tech);
            if (click == this.sc.frontDoor)
              this.DrawSpaceDoor(this.mainDoor, this.clickLocation[click], this.gateTrans[click], this.gateshadRect, this.gateOrangeRect, tech);
          }
          if (this.pointer[click] >= 300 && this.pointer[click] <= 390)
          {
            if (this.pointer[click] == 351)
              ;
            int num = this.doorTag[click] % 1000;
            if (num % 10 == 4)
              this.drawChest(this.vaultChest2, this.clickLocation[click], this.spiderchestRect, tech, click, this.pointer[click]);
            else if (num % 10 == 2)
              this.drawChest(this.vaultChest2, this.clickLocation[click], this.kingchestRect, tech, click, this.pointer[click]);
            else if (num % 10 == 5)
              this.drawChest(this.vaultChest3, this.clickLocation[click], this.chestRect3, tech, click, this.pointer[click]);
            else
              this.drawChest(this.vaultChest, this.clickLocation[click], this.chestRect, tech, click, this.pointer[click]);
          }
        }
      }
    }

    public void Draw(
      Matrix viewMatrix,
      Matrix projectionMatrix,
      Vector3 campos,
      Vector3 dir,
      Vector3 amb,
      Vector3 diff,
      Vector3 planet,
      RenderTarget2D t1,
      Texture2D target2,
      SpriteBatch sp,
      float distance,
      bool set)
    {
      this.drawcount = 0;
      float num1 = 1f - MathHelper.Clamp((float) (((double) distance - 10000.0) / 20000.0), 0.0f, 1f);
      if ((double) num1 <= 0.0)
        return;
      this.faciltyMatrix = Matrix.CreateScale(1f / this.scaler) * Matrix.CreateTranslation(Facility.offset);
      this.fogEffect.Parameters["LightDirection"].SetValue(dir);
      this.fogEffect.Parameters["fader"].SetValue(num1);
      this.fogEffect.Parameters[nameof (amb)].SetValue(amb);
      this.fogEffect.Parameters[nameof (diff)].SetValue(diff);
      this.fogEffect.Parameters["view"].SetValue(viewMatrix);
      this.fogEffect.Parameters["projection"].SetValue(projectionMatrix);
      this.fogEffect.Parameters[nameof (planet)].SetValue(planet);
      Vector2 vector2 = new Vector2(campos.X, campos.Z);
      string tech = "insideDark";
      this.facShader.Parameters["view"].SetValue(viewMatrix);
      this.facShader.Parameters["projection"].SetValue(projectionMatrix);
      this.facShader.Parameters[nameof (campos)].SetValue(campos);
      if (Facility.inFacility || (double) this.gateTrans[this.sc.frontDoor] > 0.0)
      {
        if (Facility.inFacility && set)
        {
          this.sc.GraphicsDevice.SetRenderTarget(this.resolveTargetX);
          this.sc.GraphicsDevice.Clear(Color.Transparent);
          this.sc.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
          this.sc.GraphicsDevice.BlendState = BlendState.Opaque;
          this.sc.GraphicsDevice.RasterizerState = RasterizerState.CullClockwise;
          this.sc.astronaut.Draw(viewMatrix, projectionMatrix, new Vector3(0.0f, 1f, 0.0f), Vector3.Zero, new Vector3(1f, 1f, 1f), -1f, 0.0f);
          for (int index1 = 0; index1 < this.powerList.Count; index1 += 5)
          {
            int index2 = (int) (((double) this.powerList[index1 + 1] + 920.0) / 460.0);
            if ((double) this.powerList[index1 + 4] > 0.0)
            {
              this.castlePart2(this.powerHall, new Vector3(this.powerList[index1], this.powerList[index1 + 1], this.powerList[index1 + 2]), this.powerList[index1 + 3], this.whiteRect, this.rgbRect[index2], tech);
              Matrix offcenter = Matrix.CreateRotationY((float) (-(double) this.myframe / 10.0)) * Matrix.CreateTranslation(-42f, 200f, 325f);
              Vector3 scale = new Vector3(1f, -0.7f, 1f);
              string partname = "rotor";
              this.specialPart(this.powerHall, new Vector3(this.powerList[index1], this.powerList[index1 + 1], this.powerList[index1 + 2]), this.powerList[index1 + 3], this.whiteRect, this.rgbRect[index2], offcenter, scale, partname, "invert");
            }
          }
          for (int index3 = 0; index3 < this.oxygenList.Count; index3 += 5)
          {
            int index4 = (int) (((double) this.oxygenList[index3 + 1] + 920.0) / 460.0);
            if ((double) this.oxygenList[index3 + 4] > 0.0)
              this.castlePart2(this.oxygenHall, new Vector3(this.oxygenList[index3], this.oxygenList[index3 + 1], this.oxygenList[index3 + 2]), this.oxygenList[index3 + 3], this.whiteRect, this.rgbRect[index4], tech);
          }
          for (int index5 = 0; index5 < this.salvageList.Count; index5 += 5)
          {
            int index6 = (int) (((double) this.salvageList[index5 + 1] + 920.0) / 460.0);
            if ((double) this.salvageList[index5 + 4] > 0.0)
              this.castlePart2(this.salvageHall, new Vector3(this.salvageList[index5], this.salvageList[index5 + 1], this.salvageList[index5 + 2]), this.salvageList[index5 + 3], this.whiteRect, this.rgbRect[index6], tech);
          }
          for (int index7 = 0; index7 < this.triList.Count; index7 += 5)
          {
            int index8 = (int) (((double) this.triList[index7 + 1] + 920.0) / 460.0);
            if ((double) this.triList[index7 + 4] > 0.0)
              this.castlePart2(this.triHall, new Vector3(this.triList[index7], this.triList[index7 + 1], this.triList[index7 + 2]), this.triList[index7 + 3], this.whiteRect, this.rgbRect[index8], tech);
          }
          for (int index9 = 0; index9 < this.hallList.Count; index9 += 5)
          {
            int index10 = (int) (((double) this.hallList[index9 + 1] + 920.0) / 460.0);
            if ((double) this.hallList[index9 + 4] > 0.0)
              this.castlePart2(this.hallWay, new Vector3(this.hallList[index9], this.hallList[index9 + 1], this.hallList[index9 + 2]), this.hallList[index9 + 3], this.whiteRect, this.rgbRect[index10], tech);
          }
          for (int index11 = 0; index11 < this.crossList.Count; index11 += 5)
          {
            int index12 = (int) (((double) this.crossList[index11 + 1] + 920.0) / 460.0);
            if ((double) this.crossList[index11 + 4] > 0.0)
              this.castlePart2(this.crossHall, new Vector3(this.crossList[index11], this.crossList[index11 + 1], this.crossList[index11 + 2]), this.crossList[index11 + 3], this.whiteRect, this.rgbRect[index12], tech);
          }
          for (int index13 = 0; index13 < this.longList.Count; index13 += 5)
          {
            int index14 = (int) (((double) this.longList[index13 + 1] + 920.0) / 460.0);
            if ((double) this.longList[index13 + 4] > 0.0)
              this.castlePart2(this.longHall, new Vector3(this.longList[index13], this.longList[index13 + 1], this.longList[index13 + 2]), this.longList[index13 + 3], this.whiteRect, this.rgbRect[index14], tech);
          }
          for (int index15 = 0; index15 < this.cornerList.Count; index15 += 5)
          {
            int index16 = (int) (((double) this.cornerList[index15 + 1] + 920.0) / 460.0);
            if ((double) this.cornerList[index15 + 4] > 0.0)
              this.castlePart2(this.corner, new Vector3(this.cornerList[index15], this.cornerList[index15 + 1], this.cornerList[index15 + 2]), this.cornerList[index15 + 3], this.whiteRect, this.rgbRect[index16], tech);
          }
          for (int index17 = 0; index17 < this.deadList.Count; index17 += 5)
          {
            int index18 = (int) (((double) this.deadList[index17 + 1] + 920.0) / 460.0);
            if ((double) this.deadList[index17 + 4] > 0.0)
              this.castlePart2(this.deadend, new Vector3(this.deadList[index17], this.deadList[index17 + 1], this.deadList[index17 + 2]), this.deadList[index17 + 3], this.whiteRect, this.rgbRect[index18], tech);
          }
          for (int index = 0; index < this.clickList.Count; ++index)
          {
            int click = this.clickList[index];
            if (this.pointer[click] >= 290)
              ;
            if (this.pointer[click] > 0 && (this.clickListBool[index] || !Facility.inFacility && click == this.sc.frontDoor))
            {
              if (this.pointer[click] >= 100 && this.pointer[click] <= 150)
              {
                if (click != this.sc.frontDoor)
                  this.DrawSpaceDoor2(this.mainDoor, this.clickLocation[click], this.gateTrans[click], this.gateshadRect, this.gatergbRect2, tech);
                if (click == this.sc.frontDoor)
                  this.DrawSpaceDoor2(this.mainDoor, this.clickLocation[click], this.gateTrans[click], this.gateshadRect, this.gateOrangeRect, tech);
              }
              this.sc.GraphicsDevice.RasterizerState = RasterizerState.CullNone;
              if (this.pointer[click] >= 300 && this.pointer[click] <= 390)
              {
                if (this.pointer[click] == 351)
                  ;
                int num2 = this.doorTag[click] % 1000;
                if (num2 % 10 == 4)
                  this.drawChest2(this.vaultChest2, this.clickLocation[click], this.spiderchestRect, tech, click, this.pointer[click]);
                else if (num2 % 10 == 2)
                  this.drawChest2(this.vaultChest2, this.clickLocation[click], this.kingchestRect, tech, click, this.pointer[click]);
                else if (num2 % 10 == 5)
                  this.drawChest2(this.vaultChest3, this.clickLocation[click], this.chestRect3, tech, click, this.pointer[click]);
                else
                  this.drawChest2(this.vaultChest, this.clickLocation[click], this.chestRect, tech, click, this.pointer[click]);
              }
              if (this.pointer[click] >= 250 && this.pointer[click] <= 280)
                this.drawSwitch2(this.switchModel, this.clickLocation[click], tech, click, this.pointer[click]);
              if (this.pointer[click] >= 290 && this.pointer[click] <= 295)
                this.drawTrap2(this.trapModel, this.clickLocation[click], tech, click, this.pointer[click]);
            }
          }
          this.sc.GraphicsDevice.SetRenderTarget(t1);
        }
        this.sc.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
        this.sc.GraphicsDevice.BlendState = BlendState.Opaque;
        this.sc.GraphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;
        for (int index19 = 0; index19 < this.powerList.Count; index19 += 5)
        {
          int index20 = (int) (((double) this.powerList[index19 + 1] + 920.0) / 460.0);
          if ((double) this.powerList[index19 + 4] > 0.0)
          {
            this.castlePart(this.powerHall, new Vector3(this.powerList[index19], this.powerList[index19 + 1], this.powerList[index19 + 2]), this.powerList[index19 + 3], this.whiteRect, this.rgbRect[index20], tech);
            Matrix offcenter = Matrix.CreateRotationY((float) (-(double) this.myframe / 10.0)) * Matrix.CreateTranslation(-42f, 200f, 325f);
            Vector3 scale = new Vector3(1f, 1f, 1f);
            string partname = "rotor";
            this.specialPart(this.powerHall, new Vector3(this.powerList[index19], this.powerList[index19 + 1], this.powerList[index19 + 2]), this.powerList[index19 + 3], this.whiteRect, this.rgbRect[index20], offcenter, scale, partname, tech);
          }
        }
        for (int index21 = 0; index21 < this.oxygenList.Count; index21 += 5)
        {
          int index22 = (int) (((double) this.oxygenList[index21 + 1] + 920.0) / 460.0);
          if ((double) this.oxygenList[index21 + 4] > 0.0)
            this.castlePart(this.oxygenHall, new Vector3(this.oxygenList[index21], this.oxygenList[index21 + 1], this.oxygenList[index21 + 2]), this.oxygenList[index21 + 3], this.whiteRect, this.rgbRect[index22], tech);
        }
        for (int index23 = 0; index23 < this.salvageList.Count; index23 += 5)
        {
          int index24 = (int) (((double) this.salvageList[index23 + 1] + 920.0) / 460.0);
          if ((double) this.salvageList[index23 + 4] > 0.0)
            this.castlePart(this.salvageHall, new Vector3(this.salvageList[index23], this.salvageList[index23 + 1], this.salvageList[index23 + 2]), this.salvageList[index23 + 3], this.whiteRect, this.rgbRect[index24], tech);
        }
        for (int index25 = 0; index25 < this.triList.Count; index25 += 5)
        {
          int index26 = (int) (((double) this.triList[index25 + 1] + 920.0) / 460.0);
          if ((double) this.triList[index25 + 4] > 0.0)
            this.castlePart(this.triHall, new Vector3(this.triList[index25], this.triList[index25 + 1], this.triList[index25 + 2]), this.triList[index25 + 3], this.whiteRect, this.rgbRect[index26], tech);
        }
        for (int index27 = 0; index27 < this.hallList.Count; index27 += 5)
        {
          int index28 = (int) (((double) this.hallList[index27 + 1] + 920.0) / 460.0);
          if ((double) this.hallList[index27 + 4] > 0.0)
            this.castlePart(this.hallWay, new Vector3(this.hallList[index27], this.hallList[index27 + 1], this.hallList[index27 + 2]), this.hallList[index27 + 3], this.whiteRect, this.rgbRect[index28], tech);
        }
        for (int index29 = 0; index29 < this.crossList.Count; index29 += 5)
        {
          int index30 = (int) (((double) this.crossList[index29 + 1] + 920.0) / 460.0);
          if ((double) this.crossList[index29 + 4] > 0.0)
            this.castlePart(this.crossHall, new Vector3(this.crossList[index29], this.crossList[index29 + 1], this.crossList[index29 + 2]), this.crossList[index29 + 3], this.whiteRect, this.rgbRect[index30], tech);
        }
        for (int index31 = 0; index31 < this.longList.Count; index31 += 5)
        {
          int index32 = (int) (((double) this.longList[index31 + 1] + 920.0) / 460.0);
          if ((double) this.longList[index31 + 4] > 0.0)
            this.castlePart(this.longHall, new Vector3(this.longList[index31], this.longList[index31 + 1], this.longList[index31 + 2]), this.longList[index31 + 3], this.whiteRect, this.rgbRect[index32], tech);
        }
        for (int index33 = 0; index33 < this.cornerList.Count; index33 += 5)
        {
          int index34 = (int) (((double) this.cornerList[index33 + 1] + 920.0) / 460.0);
          if ((double) this.cornerList[index33 + 4] > 0.0)
            this.castlePart(this.corner, new Vector3(this.cornerList[index33], this.cornerList[index33 + 1], this.cornerList[index33 + 2]), this.cornerList[index33 + 3], this.whiteRect, this.rgbRect[index34], tech);
        }
        for (int index35 = 0; index35 < this.deadList.Count; index35 += 5)
        {
          int index36 = (int) (((double) this.deadList[index35 + 1] + 920.0) / 460.0);
          if ((double) this.deadList[index35 + 4] > 0.0)
            this.castlePart(this.deadend, new Vector3(this.deadList[index35], this.deadList[index35 + 1], this.deadList[index35 + 2]), this.deadList[index35 + 3], this.whiteRect, this.rgbRect[index36], tech);
        }
        for (int index = 0; index < this.clickList.Count; ++index)
        {
          int click = this.clickList[index];
          if (this.pointer[click] >= 290)
            ;
          if (this.pointer[click] > 0 && (this.clickListBool[index] || !Facility.inFacility && click == this.sc.frontDoor))
          {
            if (this.pointer[click] >= 100 && this.pointer[click] <= 150 && click != this.sc.frontDoor)
              this.DrawSpaceDoor(this.mainDoor, this.clickLocation[click], this.animGate(click), this.gateshadRect, this.gatergbRect2, tech);
            if (this.pointer[click] >= 300 && this.pointer[click] <= 390)
            {
              if (this.pointer[click] == 351)
                ;
              int num3 = this.doorTag[click] % 1000;
              if (num3 % 10 == 4)
                this.drawChest(this.vaultChest2, this.clickLocation[click], this.spiderchestRect, tech, click, this.pointer[click]);
              else if (num3 % 10 == 2)
                this.drawChest(this.vaultChest2, this.clickLocation[click], this.kingchestRect, tech, click, this.pointer[click]);
              else if (num3 % 10 == 5)
                this.drawChest(this.vaultChest3, this.clickLocation[click], this.chestRect3, tech, click, this.pointer[click]);
              else
                this.drawChest(this.vaultChest, this.clickLocation[click], this.chestRect, tech, click, this.pointer[click]);
            }
            if (this.pointer[click] >= 250 && this.pointer[click] <= 280)
              this.drawSwitch(this.switchModel, this.clickLocation[click], tech, click, this.pointer[click]);
            if (this.pointer[click] >= 290 && this.pointer[click] <= 295)
              this.drawTrap(this.trapModel, this.clickLocation[click], tech, click, this.pointer[click]);
          }
        }
        if (set)
        {
          this.blurEffect.Parameters["flatTexture"].SetValue((Texture) target2);
          this.blurEffect.Parameters["delta"].SetValue(this.specRot2);
          this.blurEffect.CurrentTechnique = this.blurEffect.Techniques["ripple"];
          sp.Begin(SpriteSortMode.Deferred, BlendState.Additive, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, this.blurEffect);
          sp.Draw((Texture2D) this.resolveTargetX, new Rectangle(0, 0, this.sc.GraphicsDevice.Viewport.Width, this.sc.GraphicsDevice.Viewport.Height), Color.White);
          sp.End();
          this.sc.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
          this.sc.GraphicsDevice.BlendState = BlendState.NonPremultiplied;
          this.sc.GraphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;
        }
      }
      this.closeGates();
      this.DrawSpaceDoor(this.mainDoor, this.clickLocation[this.sc.frontDoor], this.animGate(this.sc.frontDoor), this.gateshadRect, this.gateOrangeRect, tech);
      this.drawingEntry = Facility.outsideCastle || this.gridVal < -4 || (double) this.gateTrans[this.sc.frontDoor] != 0.0 || this.gridVal == this.sc.frontDoor;
      if (!this.drawingEntry)
        return;
      this.DrawEntryWay(this.entryWay, new Vector3(this.entryPos[0], this.entryPos[1], this.entryPos[2]), this.entryPos[3], this.entryTexture, this.dirtrgb, "outdoors");
    }

    private void DrawEntryWay(
      Model model,
      Vector3 pos,
      float rot,
      Texture2D tex,
      Texture2D tex2,
      string tech)
    {
      pos.X /= this.scaler;
      pos.Z /= this.scaler;
      pos += Facility.offset;
      Matrix matrix = Matrix.CreateScale(1f / this.scaler) * Matrix.CreateRotationY(rot) * Matrix.CreateTranslation(pos);
      model.Meshes[0].MeshParts[0].Effect = this.fogEffect;
      this.fogEffect.Parameters["shadowTexture"].SetValue((Texture) tex);
      this.fogEffect.Parameters["rgbTexture"].SetValue((Texture) tex2);
      this.fogEffect.Parameters["rgbTexture2"].SetValue((Texture) this.mixrgb);
      this.fogEffect.Parameters["world"].SetValue(matrix);
      this.fogEffect.CurrentTechnique = this.fogEffect.Techniques[tech];
      model.Meshes[0].Draw();
    }

    private void DrawCube(
      Model model,
      Vector3 pos,
      float rot,
      Texture2D tex,
      Texture2D tex2,
      string tech)
    {
      pos.X /= this.scaler;
      pos.Z /= this.scaler;
      pos += Facility.offset;
      Matrix matrix = Matrix.CreateScale(1f / this.scaler) * Matrix.CreateRotationY(rot) * Matrix.CreateTranslation(pos);
      model.Meshes[0].MeshParts[0].Effect = this.fogEffect;
      this.fogEffect.Parameters["shadowTexture"].SetValue((Texture) tex);
      this.fogEffect.Parameters["rgbTexture"].SetValue((Texture) tex2);
      this.fogEffect.Parameters["rgbTexture2"].SetValue((Texture) this.mixrgb);
      this.fogEffect.Parameters["world"].SetValue(matrix);
      this.fogEffect.CurrentTechnique = this.fogEffect.Techniques[tech];
      model.Meshes[0].Draw();
    }

    private void castlePartGreen(
      Model model,
      Vector3 pos,
      float rot,
      Vector4 uvA,
      Vector4 uvB,
      string tech)
    {
      pos.X /= this.scaler;
      pos.Z /= this.scaler;
      pos += Facility.offset;
      float num1 = 2000f;
      float num2 = 1700f;
      Vector4 vector4_1 = new Vector4(num1 / uvA.Z, uvA.X / num1, num2 / uvA.W, uvA.Y / num2);
      Vector4 vector4_2 = new Vector4(num1 / uvB.Z, uvB.X / num1, num2 / uvB.W, uvB.Y / num2);
      Matrix matrix = Matrix.CreateScale(1f / this.scaler) * Matrix.CreateRotationY(rot) * Matrix.CreateTranslation(pos);
      model.Meshes[0].MeshParts[0].Effect = this.facShader;
      this.facShader.Parameters[nameof (uvA)].SetValue(vector4_1);
      this.facShader.Parameters[nameof (uvB)].SetValue(vector4_2);
      this.facShader.Parameters["floor"].SetValue(pos.Y + 1f);
      this.facShader.Parameters["world"].SetValue(matrix);
      this.facShader.CurrentTechnique = this.facShader.Techniques[tech];
      model.Meshes[0].Draw();
    }

    private void castlePart(
      Model model,
      Vector3 pos,
      float rot,
      Vector4 uvA,
      Vector4 uvB,
      string tech)
    {
      ++this.drawcount;
      pos.X /= this.scaler;
      pos.Z /= this.scaler;
      pos += Facility.offset;
      float num1 = 2000f;
      float num2 = 1700f;
      Vector4 vector4_1 = new Vector4(num1 / uvA.Z, uvA.X / num1, num2 / uvA.W, uvA.Y / num2);
      Vector4 vector4_2 = new Vector4(num1 / uvB.Z, uvB.X / num1, num2 / uvB.W, uvB.Y / num2);
      Matrix matrix = Matrix.CreateScale(1f / this.scaler) * Matrix.CreateRotationY(rot) * Matrix.CreateTranslation(pos);
      model.Meshes[0].MeshParts[0].Effect = this.facShader;
      this.facShader.Parameters[nameof (uvA)].SetValue(vector4_1);
      this.facShader.Parameters[nameof (uvB)].SetValue(vector4_2);
      this.facShader.Parameters["world"].SetValue(matrix);
      this.facShader.CurrentTechnique = this.facShader.Techniques[tech];
      model.Meshes[0].Draw();
    }

    private void castlePart2(
      Model model,
      Vector3 pos,
      float rot,
      Vector4 uvA,
      Vector4 uvB,
      string tech)
    {
      ++this.drawcount;
      pos.X /= this.scaler;
      pos.Z /= this.scaler;
      pos += Facility.offset;
      tech = "invert";
      float num1 = 2000f;
      float num2 = 1700f;
      Vector4 vector4_1 = new Vector4(num1 / uvA.Z, uvA.X / num1, num2 / uvA.W, uvA.Y / num2);
      Vector4 vector4_2 = new Vector4(num1 / uvB.Z, uvB.X / num1, num2 / uvB.W, uvB.Y / num2);
      Matrix matrix = Matrix.CreateScale(1f / this.scaler, (float) (1.0 / (double) this.scaler * -0.699999988079071), 1f / this.scaler) * Matrix.CreateRotationY(rot) * Matrix.CreateTranslation(pos);
      model.Meshes[0].MeshParts[0].Effect = this.facShader;
      this.facShader.Parameters[nameof (uvA)].SetValue(vector4_1);
      this.facShader.Parameters[nameof (uvB)].SetValue(vector4_2);
      this.facShader.Parameters["world"].SetValue(matrix);
      this.facShader.CurrentTechnique = this.facShader.Techniques[tech];
      model.Meshes[0].Draw();
    }

    private void specialPart(
      Model model,
      Vector3 pos,
      float rot,
      Vector4 uvA,
      Vector4 uvB,
      Matrix offcenter,
      Vector3 scale,
      string partname,
      string tech)
    {
      pos.X /= this.scaler;
      pos.Z /= this.scaler;
      pos += Facility.offset;
      float num1 = 2000f;
      float num2 = 1700f;
      Vector4 vector4_1 = new Vector4(num1 / uvA.Z, uvA.X / num1, num2 / uvA.W, uvA.Y / num2);
      Vector4 vector4_2 = new Vector4(num1 / uvB.Z, uvB.X / num1, num2 / uvB.W, uvB.Y / num2);
      Matrix matrix = Matrix.CreateScale(scale / this.scaler) * Matrix.CreateRotationY(rot) * Matrix.CreateTranslation(pos);
      model.Meshes[partname].MeshParts[0].Effect = this.facShader;
      this.facShader.Parameters[nameof (uvA)].SetValue(vector4_1);
      this.facShader.Parameters[nameof (uvB)].SetValue(vector4_2);
      this.facShader.Parameters["world"].SetValue(offcenter * matrix);
      this.facShader.CurrentTechnique = this.facShader.Techniques[tech];
      model.Meshes[partname].Draw();
    }

    private void DrawDoor(Model model, Matrix world, Vector4 uvA, Vector4 uvB, string tech)
    {
      float num1 = 2000f;
      float num2 = 1700f;
      Vector4 vector4_1 = new Vector4(num1 / uvA.Z, uvA.X / num1, num2 / uvA.W, uvA.Y / num2);
      Vector4 vector4_2 = new Vector4(num1 / uvB.Z, uvB.X / num1, num2 / uvB.W, uvB.Y / num2);
      model.Meshes[0].MeshParts[0].Effect = this.facShader;
      this.facShader.Parameters[nameof (uvA)].SetValue(vector4_1);
      this.facShader.Parameters[nameof (uvB)].SetValue(vector4_2);
      this.facShader.Parameters[nameof (world)].SetValue(world * this.faciltyMatrix);
      this.facShader.CurrentTechnique = this.facShader.Techniques[tech];
      model.Meshes[0].Draw();
    }

    private void DrawSpaceDoor(
      Model model,
      Matrix world,
      float amt,
      Vector4 uvA,
      Vector4 uvB,
      string tech)
    {
      float num1 = 2000f;
      float num2 = 1700f;
      Vector4 vector4_1 = new Vector4(num1 / uvA.Z, uvA.X / num1, num2 / uvA.W, uvA.Y / num2);
      Vector4 vector4_2 = new Vector4(num1 / uvB.Z, uvB.X / num1, num2 / uvB.W, uvB.Y / num2);
      model.Meshes[2].MeshParts[0].Effect = this.facShader;
      this.facShader.Parameters[nameof (uvA)].SetValue(vector4_1);
      this.facShader.Parameters[nameof (uvB)].SetValue(vector4_2);
      this.facShader.Parameters[nameof (world)].SetValue(Matrix.CreateTranslation(amt, 0.0f, 0.0f) * world * this.faciltyMatrix);
      this.facShader.CurrentTechnique = this.facShader.Techniques[tech];
      model.Meshes[2].Draw();
      model.Meshes[1].MeshParts[0].Effect = this.facShader;
      this.facShader.Parameters[nameof (world)].SetValue(Matrix.CreateTranslation(-amt, 0.0f, 0.0f) * world * this.faciltyMatrix);
      this.facShader.CurrentTechnique = this.facShader.Techniques[tech];
      model.Meshes[1].Draw();
      model.Meshes[0].MeshParts[0].Effect = this.facShader;
      this.facShader.Parameters[nameof (world)].SetValue(world * this.faciltyMatrix);
      this.facShader.CurrentTechnique = this.facShader.Techniques[tech];
      model.Meshes[0].Draw();
    }

    private void drawChest(
      Model model,
      Matrix world,
      Vector4 color,
      string tech,
      int pointer,
      int val)
    {
      float num1 = 2000f;
      float num2 = 1700f;
      Vector4 vaultchestshadRect = this.vaultchestshadRect;
      Vector4 vector4_1 = color;
      Vector4 vector4_2 = new Vector4(num1 / vaultchestshadRect.Z, vaultchestshadRect.X / num1, num2 / vaultchestshadRect.W, vaultchestshadRect.Y / num2);
      Vector4 vector4_3 = new Vector4(num1 / vector4_1.Z, vector4_1.X / num1, num2 / vector4_1.W, vector4_1.Y / num2);
      model.Meshes[0].MeshParts[0].Effect = this.facShader;
      this.facShader.Parameters["uvA"].SetValue(vector4_2);
      this.facShader.Parameters["uvB"].SetValue(vector4_3);
      this.facShader.Parameters[nameof (world)].SetValue(world * this.faciltyMatrix);
      this.facShader.CurrentTechnique = this.facShader.Techniques[tech];
      model.Meshes[0].Draw();
      if (val % 10 == 1 && (double) this.chestRot[pointer] > -2.0)
      {
        this.chestRot[pointer] -= 0.016f;
        if ((double) this.chestRot[pointer] < -2.0)
          this.chestRot[pointer] = -2f;
      }
      if (val % 10 == 0 && (double) this.chestRot[pointer] < 0.0)
      {
        this.chestRot[pointer] += 0.016f;
        if ((double) this.chestRot[pointer] > 0.0)
          this.chestRot[pointer] = 0.0f;
      }
      Matrix matrix = Matrix.CreateRotationX(this.chestRot[pointer]) * Matrix.CreateTranslation(0.0f, 71f, -52f);
      model.Meshes[1].MeshParts[0].Effect = this.facShader;
      this.facShader.Parameters["uvA"].SetValue(vector4_2);
      this.facShader.Parameters["uvB"].SetValue(vector4_3);
      this.facShader.Parameters[nameof (world)].SetValue(matrix * world * this.faciltyMatrix);
      this.facShader.CurrentTechnique = this.facShader.Techniques[tech];
      model.Meshes[1].Draw();
    }

    private void drawSwitch(Model model, Matrix world, string tech, int pointer, int val)
    {
      float num1 = 2000f;
      float num2 = 1700f;
      Vector4 switchShadRect = this.switchShadRect;
      Vector4 switchRect = this.switchRect;
      Vector4 vector4_1 = new Vector4(num1 / switchShadRect.Z, switchShadRect.X / num1, num2 / switchShadRect.W, switchShadRect.Y / num2);
      Vector4 vector4_2 = new Vector4(num1 / switchRect.Z, switchRect.X / num1, num2 / switchRect.W, switchRect.Y / num2);
      model.Meshes[0].MeshParts[0].Effect = this.facShader;
      this.facShader.Parameters["uvA"].SetValue(vector4_1);
      this.facShader.Parameters["uvB"].SetValue(vector4_2);
      this.facShader.Parameters[nameof (world)].SetValue(Matrix.CreateTranslation(-278f, 250f, 0.0f) * world * this.faciltyMatrix);
      this.facShader.CurrentTechnique = this.facShader.Techniques[tech];
      model.Meshes[0].Draw();
      if (val == 250 && (double) this.switchRot[pointer] < 0.0)
      {
        this.switchRot[pointer] += 0.05f;
        if ((double) this.switchRot[pointer] > 0.0)
          this.switchRot[pointer] = 0.0f;
      }
      if (val == 251 && (double) this.switchRot[pointer] > -1.5700000524520874)
      {
        this.switchRot[pointer] -= 0.05f;
        if ((double) this.switchRot[pointer] < -1.5700000524520874)
          this.switchRot[pointer] = -1.57f;
      }
      Matrix matrix = Matrix.CreateRotationX(this.switchRot[pointer]) * Matrix.CreateTranslation(-278f, 250f, 0.0f);
      model.Meshes[1].MeshParts[0].Effect = this.facShader;
      this.facShader.Parameters["uvA"].SetValue(vector4_1);
      this.facShader.Parameters["uvB"].SetValue(vector4_2);
      this.facShader.Parameters[nameof (world)].SetValue(matrix * world * this.faciltyMatrix);
      this.facShader.CurrentTechnique = this.facShader.Techniques[tech];
      model.Meshes[1].Draw();
    }

    private void drawTrap(Model model, Matrix world, string tech, int pointer, int val)
    {
      float num1 = 2000f;
      float num2 = 1700f;
      Vector4 trapShadRect = this.trapShadRect;
      Vector4 trapRect = this.trapRect;
      Vector4 vector4_1 = new Vector4(num1 / trapShadRect.Z, trapShadRect.X / num1, num2 / trapShadRect.W, trapShadRect.Y / num2);
      Vector4 vector4_2 = new Vector4(num1 / trapRect.Z, trapRect.X / num1, num2 / trapRect.W, trapRect.Y / num2);
      model.Meshes[0].MeshParts[0].Effect = this.facShader;
      this.facShader.Parameters["uvA"].SetValue(vector4_1);
      this.facShader.Parameters["uvB"].SetValue(vector4_2);
      this.facShader.Parameters[nameof (world)].SetValue(world * this.faciltyMatrix);
      this.facShader.CurrentTechnique = this.facShader.Techniques[tech];
      model.Meshes[0].Draw();
    }

    private void DrawDoor2(Model model, Matrix world, Vector4 uvA, Vector4 uvB, string tech)
    {
      float num1 = 2000f;
      float num2 = 1700f;
      tech = "invert";
      Vector4 vector4_1 = new Vector4(num1 / uvA.Z, uvA.X / num1, num2 / uvA.W, uvA.Y / num2);
      Vector4 vector4_2 = new Vector4(num1 / uvB.Z, uvB.X / num1, num2 / uvB.W, uvB.Y / num2);
      model.Meshes[0].MeshParts[0].Effect = this.facShader;
      this.facShader.Parameters[nameof (uvA)].SetValue(vector4_1);
      this.facShader.Parameters[nameof (uvB)].SetValue(vector4_2);
      this.facShader.Parameters[nameof (world)].SetValue(Matrix.CreateScale(1f, -1f, 1f) * world * this.faciltyMatrix);
      this.facShader.CurrentTechnique = this.facShader.Techniques[tech];
      model.Meshes[0].Draw();
    }

    private void DrawSpaceDoor2(
      Model model,
      Matrix world,
      float amt,
      Vector4 uvA,
      Vector4 uvB,
      string tech)
    {
      float num1 = 2000f;
      float num2 = 1700f;
      tech = "invert";
      Vector4 vector4_1 = new Vector4(num1 / uvA.Z, uvA.X / num1, num2 / uvA.W, uvA.Y / num2);
      Vector4 vector4_2 = new Vector4(num1 / uvB.Z, uvB.X / num1, num2 / uvB.W, uvB.Y / num2);
      model.Meshes[2].MeshParts[0].Effect = this.facShader;
      this.facShader.Parameters[nameof (uvA)].SetValue(vector4_1);
      this.facShader.Parameters[nameof (uvB)].SetValue(vector4_2);
      this.facShader.Parameters[nameof (world)].SetValue(Matrix.CreateScale(1f, -0.7f, 1f) * Matrix.CreateTranslation(amt, 0.0f, 0.0f) * world * this.faciltyMatrix);
      this.facShader.CurrentTechnique = this.facShader.Techniques[tech];
      model.Meshes[2].Draw();
      model.Meshes[1].MeshParts[0].Effect = this.facShader;
      this.facShader.Parameters[nameof (world)].SetValue(Matrix.CreateScale(1f, -0.7f, 1f) * Matrix.CreateTranslation(-amt, 0.0f, 0.0f) * world * this.faciltyMatrix);
      this.facShader.CurrentTechnique = this.facShader.Techniques[tech];
      model.Meshes[1].Draw();
      model.Meshes[0].MeshParts[0].Effect = this.facShader;
      this.facShader.Parameters[nameof (world)].SetValue(Matrix.CreateScale(1f, -0.7f, 1f) * world * this.faciltyMatrix);
      this.facShader.CurrentTechnique = this.facShader.Techniques[tech];
      model.Meshes[0].Draw();
    }

    private void drawChest2(
      Model model,
      Matrix world,
      Vector4 color,
      string tech,
      int pointer,
      int val)
    {
      float num1 = 2000f;
      float num2 = 1700f;
      tech = "invert";
      Vector4 vaultchestshadRect = this.vaultchestshadRect;
      Vector4 vector4_1 = color;
      Vector4 vector4_2 = new Vector4(num1 / vaultchestshadRect.Z, vaultchestshadRect.X / num1, num2 / vaultchestshadRect.W, vaultchestshadRect.Y / num2);
      Vector4 vector4_3 = new Vector4(num1 / vector4_1.Z, vector4_1.X / num1, num2 / vector4_1.W, vector4_1.Y / num2);
      model.Meshes[0].MeshParts[0].Effect = this.facShader;
      this.facShader.Parameters["uvA"].SetValue(vector4_2);
      this.facShader.Parameters["uvB"].SetValue(vector4_3);
      this.facShader.Parameters[nameof (world)].SetValue(Matrix.CreateScale(1f, -1.2f, 1f) * world * this.faciltyMatrix);
      this.facShader.CurrentTechnique = this.facShader.Techniques[tech];
      model.Meshes[0].Draw();
    }

    private void drawSwitch2(Model model, Matrix world, string tech, int pointer, int val)
    {
      float num1 = 2000f;
      float num2 = 1700f;
      tech = "invert";
      Vector4 switchShadRect = this.switchShadRect;
      Vector4 switchRect = this.switchRect;
      Vector4 vector4_1 = new Vector4(num1 / switchShadRect.Z, switchShadRect.X / num1, num2 / switchShadRect.W, switchShadRect.Y / num2);
      Vector4 vector4_2 = new Vector4(num1 / switchRect.Z, switchRect.X / num1, num2 / switchRect.W, switchRect.Y / num2);
      model.Meshes[0].MeshParts[0].Effect = this.facShader;
      this.facShader.Parameters["uvA"].SetValue(vector4_1);
      this.facShader.Parameters["uvB"].SetValue(vector4_2);
      this.facShader.Parameters[nameof (world)].SetValue(Matrix.CreateTranslation(-278f, 250f, 0.0f) * Matrix.CreateScale(1f, -0.7f, 1f) * world * this.faciltyMatrix);
      this.facShader.CurrentTechnique = this.facShader.Techniques[tech];
      model.Meshes[0].Draw();
      Matrix matrix = Matrix.CreateRotationX(this.switchRot[pointer]) * Matrix.CreateTranslation(-278f, 250f, 0.0f);
      model.Meshes[1].MeshParts[0].Effect = this.facShader;
      this.facShader.Parameters["uvA"].SetValue(vector4_1);
      this.facShader.Parameters["uvB"].SetValue(vector4_2);
      this.facShader.Parameters[nameof (world)].SetValue(matrix * Matrix.CreateScale(1f, -0.7f, 1f) * world * this.faciltyMatrix);
      this.facShader.CurrentTechnique = this.facShader.Techniques[tech];
      model.Meshes[1].Draw();
    }

    private void drawTrap2(Model model, Matrix world, string tech, int pointer, int val)
    {
      float num1 = 2000f;
      float num2 = 1700f;
      tech = "invert";
      Vector4 trapShadRect = this.trapShadRect;
      Vector4 trapRect = this.trapRect;
      Vector4 vector4_1 = new Vector4(num1 / trapShadRect.Z, trapShadRect.X / num1, num2 / trapShadRect.W, trapShadRect.Y / num2);
      Vector4 vector4_2 = new Vector4(num1 / trapRect.Z, trapRect.X / num1, num2 / trapRect.W, trapRect.Y / num2);
      model.Meshes[0].MeshParts[0].Effect = this.facShader;
      this.facShader.Parameters["uvA"].SetValue(vector4_1);
      this.facShader.Parameters["uvB"].SetValue(vector4_2);
      this.facShader.Parameters[nameof (world)].SetValue(Matrix.CreateScale(1f, -1f, 1f) * world * this.faciltyMatrix);
      this.facShader.CurrentTechnique = this.facShader.Techniques[tech];
      model.Meshes[0].Draw();
    }

    public void GetHeightEntry(Vector3 position, out float height, float h)
    {
      position -= Facility.offset;
      position *= this.scaler;
      float num1 = 100f;
      int index1 = (int) MathHelper.Clamp(position.X / num1, 0.0f, 178f);
      int index2 = (int) MathHelper.Clamp(position.Z / num1, 0.0f, 178f);
      float amount1 = position.X % num1 / num1;
      float amount2 = position.Z % num1 / num1;
      int index3 = index1 + 1;
      int index4 = index2 + 1;
      float num2 = MathHelper.Lerp((float) this.heightsEntry[index1, index2], (float) this.heightsEntry[index3, index2], amount1);
      float num3 = MathHelper.Lerp((float) this.heightsEntry[index1, index4], (float) this.heightsEntry[index3, index4], amount1);
      height = MathHelper.Lerp(num2, num3, amount2);
      this.gridVal = this.clickableEntry[(int) MathHelper.Clamp(position.X / num1, 0.0f, 178f), (int) MathHelper.Clamp(position.Z / num1, 0.0f, 178f)];
      Facility.inFacility = false;
      Facility.outsideCastle = true;
      this.steep = true;
      if (this.gridVal == -30 && !this.jumping)
        Facility.outsideCastle = false;
      if ((double) height >= (double) this.entryRampHite - 1000.0)
        return;
      height = MathHelper.Lerp(h, this.entryRampHite, 0.05f);
      this.steep = false;
    }

    public void GetHeight(Vector3 position, out float height, float h)
    {
      position -= Facility.offset;
      position *= this.scaler;
      float num1 = 100f;
      int index1 = (int) MathHelper.Clamp(position.X / num1, 0.0f, 175f);
      int index2 = (int) MathHelper.Clamp(position.Z / num1, 0.0f, 175f);
      float amount1 = position.X % num1 / num1;
      float amount2 = position.Z % num1 / num1;
      int index3 = index1 + 1;
      int index4 = index2 + 1;
      float num2 = MathHelper.Lerp((float) Facility.heightData[index1, index2], (float) Facility.heightData[index3, index2], amount1);
      float num3 = MathHelper.Lerp((float) Facility.heightData[index1, index4], (float) Facility.heightData[index3, index4], amount1);
      height = MathHelper.Lerp(num2, num3, amount2);
      this.gridVal = Facility.clickable[(int) MathHelper.Clamp((float) Math.Round((double) position.X / (double) num1), 0.0f, 175f), (int) MathHelper.Clamp((float) Math.Round((double) position.Z / (double) num1), 0.0f, 175f)];
      Facility.inFacility = false;
      if (this.gridVal >= -4 || this.gridVal == this.sc.frontDoor || this.gridVal == -9)
        Facility.inFacility = true;
      Facility.outsideCastle = false;
      if (this.gridVal != -17)
        return;
      Facility.outsideCastle = true;
    }
  }
}
