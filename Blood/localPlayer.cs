// Decompiled with JetBrains decompiler
// Type: Blood.localPlayer
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Steamworks;
using System;
using System.Collections.Generic;

#nullable disable
namespace Blood
{
  public class localPlayer
  {
    private ScreenManager sc;
    public int inFarm = 1;
    public bool nearItems;
    public Vector3 vec;
    public int isLiftingIndex;
    public bool sentgameINFO;
    public bool infoRequest;
    public List<CSteamID> steamNameID = new List<CSteamID>();
    public float floaty;
    private bool inSquare;
    private Vector2 limitX;
    private Vector2 limitZ;
    public Vector3 normal;
    public bool bobblehead;
    public bool kicked;
    public Vector3 motionVec = Vector3.Zero;
    public Vector3 jump = Vector3.Zero;
    public byte uvIndex;
    public byte cuttyXcoord;
    public byte cuttyYcoord;
    public byte cuttyindexBit;
    public ushort cuttyhealth = 2500;
    public byte cuttyDamBit;
    public ushort cuttyDamage;
    public bool cuttyonFire;
    public byte bossindexBit;
    public ushort bosshealth = 2500;
    public byte bossDamBit;
    public ushort bossDamage;
    public float futureDamage;
    public int triggerEvent;
    public bool bloodExists;
    public int bloodCoil;
    public int bloodIndex;
    public float bloodPool = 16f;
    public Matrix bloodPos;
    public float bloodRot;
    public Matrix[] boneTransforms;
    public bool isDown;
    public int fallState;
    public bool isLiftingOpponent;
    public bool cheats;
    public bool onMilk;
    public bool onHulk;
    public bool remoteUsingMilk;
    public bool remoteUsingHulk;
    public bool noArms;
    public int armTimer;
    public float slope;
    public bool inBarn;
    private float x1;
    private float x2;
    private float z1;
    private float z2;
    private float u1;
    private float u2;
    private float w1;
    private float w2;
    private Vector4 b0;
    private Vector4 b1;
    private Vector4 b2;
    public float ground;
    private float lastHite;
    private bool moving;
    private bool notRotating;
    private bool headfeetAligned;
    private bool alreadyMoving;
    public bool falling;
    public bool jumping;
    public bool jumpCalled;
    public int jumpCount;
    public byte difficulty;
    private float dist;
    private float dir1;
    private float dir2;
    private float mySign = 1f;
    private float mult = 1.3f;
    private float cross = 0.3f;
    private float rotOffset;
    private Vector2 v1;
    private Vector3 v2;
    private Vector3 v3;
    private float incry;
    public Matrix cambone;
    public Matrix pistolHand;
    public Matrix oldpistolHand;
    public Matrix headbone;
    public Vector2 recoilVec;
    public Vector3 gunpos;
    public Vector3 gunlook;
    public float gunDelay;
    public int flashChoice;
    public int flashSide;
    public int nextgunChoice;
    public float sprint = 1.5f;
    public float sprintTime = 240f;
    public float sprintRest;
    public int gunChoice = 2;
    public int lastWeapon = 2;
    public int primaryChoice = 2;
    public int secondaryChoice = 2;
    public int[] resetmag = new int[22]
    {
      7,
      0,
      15,
      0,
      10,
      0,
      40,
      0,
      10,
      0,
      30,
      0,
      35,
      0,
      1,
      0,
      80,
      0,
      50,
      0,
      30,
      0
    };
    public int[] mag = new int[22]
    {
      7,
      0,
      15,
      0,
      10,
      0,
      40,
      0,
      10,
      0,
      30,
      0,
      35,
      0,
      1,
      0,
      80,
      0,
      50,
      0,
      30,
      0
    };
    public int[] resetammo = new int[22]
    {
      50000,
      0,
      50000,
      0,
      50000,
      0,
      200,
      0,
      80,
      0,
      240,
      0,
      300,
      0,
      0,
      0,
      50000,
      0,
      300,
      0,
      250,
      0
    };
    public int[] ammo = new int[22]
    {
      50000,
      0,
      50000,
      0,
      50000,
      0,
      200,
      0,
      80,
      0,
      240,
      0,
      300,
      0,
      0,
      0,
      50000,
      0,
      300,
      0,
      250,
      0
    };
    public int[] doubleammo = new int[22]
    {
      50000,
      0,
      50000,
      0,
      50000,
      0,
      400,
      0,
      160,
      0,
      480,
      0,
      600,
      0,
      0,
      0,
      50000,
      0,
      650,
      0,
      500,
      0
    };
    public int milkEffects;
    public int hulkEffects;
    public int stats_countdown = 600;
    public bool stats_ready;
    public bool stats_record;
    public bool stats_send;
    public int stats_sendTimer;
    public bool stats_show;
    public int stats_timer;
    public ushort stats_shotsfired;
    public ushort stats_shotshit;
    public ushort stats_headshots;
    public ushort stats_asshits;
    public ushort stats_bulkified;
    public ushort stats_shottied;
    public ushort stats_grenadier;
    public ushort stats_melees;
    public ushort stats_meleehits;
    public ushort stats_spinebounces;
    public ushort stats_oneshots;
    public ushort stats_knockdown;
    public float animCount = -1f;
    public float animTween;
    public List<int> animList = new List<int>();
    public int animClip = -1;
    public int animMax;
    public int animMin;
    public int animLoop;
    public float recoilTimer2;
    public float recoilTimer;
    public float flashTimer;
    public float blastTimer;
    public float blastRot;
    public bool bool_0;
    public bool dropshellAK;
    public bool gunFired;
    public bool flashfromSide;
    public float gunsideScale;
    public float gunfrontScale;
    public static float Unit = 30f;
    public static int bitmap = 200;
    public static float Grid = 6000f;
    public static int pType = 25;
    public bool closeCam = true;
    public bool autoCamOn;
    public float autoCamTimer;
    public int autoCamTarget;
    public float headRot;
    public float feetRot;
    public float stickLen;
    public Vector3 fallVec = Vector3.Zero;
    public float fallPosition;
    public float fallGrav;
    public float fallAcc;
    private int restTime;
    private int restTime2;
    private float rotLerp;
    private float lastFeetRot;
    private float rotGoal;
    private float oldRot;
    private Vector3 oldPos;
    public localPlayer.nowState now;
    public bool tunnelHeal;
    public localPlayer.conductor creature;
    public localPlayer.conductor creaturemulti;
    public localPlayer.conductor creatureShock;
    public localPlayer.conductor shatter;
    public bool grenToss;
    public bool rocketLaunch;
    public ushort grenSeed;
    public Vector3 grenPos;
    public Vector3 grenVeloc;
    public byte grenBounce;
    public byte grenAge;
    public byte grenCook;
    public byte grenState;
    public bool reload;
    public bool farmerTalk;
    public byte farmerIndex;
    public int partTIME;
    public int partTYPE;
    public ushort partID;
    public byte partHIT;
    public Vector3 partPOS;
    public Vector3 partVEL;
    public Quaternion partQUAT;
    public byte pumpkinID;
    public float currentSmoothing;
    public float smoothingDecay;
    public localPlayer.npcState simulationState;
    private localPlayer.npcState previousState;
    public localPlayer.npcState displayState;
    public int oldmyScore = -1;
    public int oldremScore = -1;
    public int oldColtAmmo = -1;
    public int oldAkAmmo = -1;
    public int oldAkMag = -1;
    public Matrix transform;
    public float frame1;
    public float step1;
    public float tween = 1f;
    public float incr;
    public int clip1;
    public int clip2;

    public localPlayer(ContentManager content, Vector3 vv, float rot, int xtend)
    {
      this.simulationState.npcPosition = vv;
      this.simulationState.npcRotation = -1.57f;
      this.feetRot = -1.57f;
      this.lastFeetRot = -1.57f;
      this.simulationState.npcTilt = 0.0f;
      this.previousState = this.simulationState;
      this.displayState = this.simulationState;
      this.displayState.npcPosition = vv;
      this.feetRot = this.displayState.npcRotation;
      this.lastFeetRot = this.displayState.npcRotation;
      this.headRot = this.displayState.npcRotation;
      this.currentSmoothing = 1f;
      this.smoothingDecay = 0.1f;
      this.now = new localPlayer.nowState();
      this.boneTransforms = new Matrix[29];
      this.creature.id = (ushort) 65000;
      this.creaturemulti.id = (ushort) 65000;
      this.creaturemulti.id2 = (ushort) 65000;
      this.creaturemulti.id3 = (ushort) 65000;
      this.creaturemulti.id4 = (ushort) 65000;
      this.creaturemulti.id5 = (ushort) 65000;
      this.creatureShock.id = (ushort) 65000;
      this.creatureShock.id2 = (ushort) 65000;
      this.creatureShock.id3 = (ushort) 65000;
      this.creatureShock.id4 = (ushort) 65000;
      this.creatureShock.id5 = (ushort) 65000;
      this.creatureShock.id6 = (ushort) 65000;
      this.creatureShock.id7 = (ushort) 65000;
      this.creatureShock.id8 = (ushort) 65000;
      this.shatter.id = (ushort) 65000;
      this.shatter.id2 = (ushort) 65000;
      this.shatter.id3 = (ushort) 65000;
      this.shatter.id4 = (ushort) 65000;
      this.shatter.id5 = (ushort) 65000;
      this.shatter.id6 = (ushort) 65000;
      this.shatter.id7 = (ushort) 65000;
      this.shatter.id8 = (ushort) 65000;
      this.pumpkinID = byte.MaxValue;
      this.partID = (ushort) 0;
      this.frame1 = 100000f;
      this.step1 = this.frame1;
      this.animList.Capacity = 20;
      this.x1 = (float) (150.0 + (double) localPlayer.Grid / 2.0);
      this.x2 = (float) (640.0 + (double) localPlayer.Grid / 2.0);
      this.z1 = (float) (1470.0 + (double) localPlayer.Grid / 2.0);
      this.z2 = (float) (1780.0 + (double) localPlayer.Grid / 2.0);
      this.u1 = (float) (590.0 + (double) localPlayer.Grid / 2.0);
      this.u2 = (float) (730.0 + (double) localPlayer.Grid / 2.0);
      this.w1 = (float) (1570.0 + (double) localPlayer.Grid / 2.0);
      this.w2 = (float) (1630.0 + (double) localPlayer.Grid / 2.0);
      this.b0 = new Vector4(3145f, 3730f, 4465f, 4785f);
      this.b1 = new Vector4(this.x1, this.x2, this.z1, this.z2);
      this.b2 = new Vector4(this.u1, this.u2, this.w1, this.w2);
      this.limitX = new Vector2(650f, 5350f);
      this.limitZ = new Vector2(650f, 5350f);
      if (xtend == 1)
      {
        this.limitX = new Vector2(650f, 11000f);
        this.limitZ = new Vector2(650f, 5350f);
      }
      else
      {
        if (xtend != 2)
          return;
        this.limitX = new Vector2(200f, 5800f);
        this.limitZ = new Vector2(200f, 5800f);
      }
    }

    public bool insideBarn(Vector3 pos)
    {
      return (double) pos.Y <= 200.0 && (double) this.b0.X < (double) pos.X && (double) pos.X < (double) this.b0.Y && (double) this.b0.Z < (double) pos.Z && (double) pos.Z < (double) this.b0.W && (double) this.simulationState.npcPosition.Y > -200.0;
    }

    public void UpdateLocal(
      ref float[,] heights,
      Vector2 Pos,
      float Tilt,
      float Rot,
      float barndoor,
      int gamestate,
      bool flying)
    {
      float num1 = 2.6f;
      this.vec = Vector3.Transform(new Vector3(-Pos.X, 0.0f, Pos.Y), Matrix.CreateRotationY(Rot)) * (float) ((double) Math.Abs(Pos.X) * (double) num1 * 0.89999997615814209 + (double) Math.Abs(Pos.Y) * (double) num1);
      if (this.jumping)
      {
        this.fallVec += this.vec * 0.1f;
        float val2 = this.vec.Length();
        if (this.milkEffects > 0 && !this.inBarn)
          val2 = Math.Max(16f, val2);
        if ((double) this.fallVec.Length() > (double) val2)
          this.fallVec = Vector3.Normalize(this.fallVec) * val2;
        this.vec = this.fallVec + this.jump;
        this.fallVec *= 0.94f;
      }
      if ((double) this.futureDamage == 0.0)
        this.jump *= 0.98f;
      this.vec += this.motionVec;
      this.motionVec *= 0.9f;
      this.stickLen = this.vec.LengthSquared();
      this.lastHite = this.simulationState.npcPosition.Y;
      this.simulationState.npcRotation = Rot;
      this.simulationState.npcTilt = Tilt;
      this.inSquare = false;
      if (gamestate != 1)
      {
        bool flag1 = (double) this.simulationState.npcPosition.Y <= 200.0 && (double) this.simulationState.npcPosition.Y > -200.0;
        bool flag2 = (double) barndoor >= 120.0;
        Vector2 p1 = new Vector2(this.simulationState.npcPosition.X, this.simulationState.npcPosition.Z);
        bool flag3 = this.inbox(p1, this.b1);
        bool flag4 = false;
        if (flag2)
          flag4 = this.inbox(p1, this.b2);
        if ((flag3 || flag4) && flag1)
        {
          this.inSquare = true;
          bool inbox1 = this.inbox(p1, this.b1);
          bool inbox2 = false;
          if (flag2)
            inbox2 = this.inbox(p1, this.b2);
          Vector2 p2 = p1 + new Vector2(this.vec.X, this.vec.Z);
          if (this.breachx(p2, this.b1, this.b2, inbox1, inbox2, 2))
            this.vec.X = 0.0f;
          if (this.breachz(p2, this.b1, this.b2, inbox1, inbox2, 2))
            this.vec.Z = 0.0f;
        }
      }
      this.inBarn = this.inSquare;
      float num2 = 1f;
      float num3 = -0.9f;
      if (this.inFarm == 2 && !this.nearItems && (double) this.simulationState.npcPosition.Y > -306.0)
      {
        num2 = 0.6f;
        num3 = -0.9f;
      }
      if (!this.inSquare)
      {
        float rise = 0.0f;
        localPlayer.GetHeightFast(ref heights, this.simulationState.npcPosition + this.vec, ref this.simulationState.npcPosition.Y, ref rise, out this.normal);
        this.ground = this.simulationState.npcPosition.Y;
        if (flying)
          this.ground = this.floaty;
        float num4 = 1f;
        if ((double) this.simulationState.npcPosition.Y - (double) this.lastHite < 0.0)
          num4 = -1f;
        rise *= num4;
        this.slope = 0.0f;
        if ((double) this.stickLen > 0.0099999997764825821)
        {
          this.slope = rise / 30f;
          if ((double) this.slope > (double) num2 && !flying)
          {
            localPlayer.GetHeightFast(ref heights, this.simulationState.npcPosition + new Vector3(this.vec.X, 0.0f, 0.0f) + Vector3.Zero, ref this.simulationState.npcPosition.Y, ref rise, out this.normal);
            float num5 = 1f;
            if ((double) this.simulationState.npcPosition.Y - (double) this.lastHite < 0.0)
              num5 = -1f;
            rise *= num5;
            this.slope = rise / 30f;
            if ((double) this.slope <= (double) num2)
            {
              this.simulationState.npcPosition.X += this.vec.X;
            }
            else
            {
              localPlayer.GetHeightFast(ref heights, this.simulationState.npcPosition + new Vector3(0.0f, 0.0f, this.vec.Z) + Vector3.Zero, ref this.simulationState.npcPosition.Y, ref rise, out this.normal);
              float num6 = 1f;
              if ((double) this.simulationState.npcPosition.Y - (double) this.lastHite < 0.0)
                num6 = -1f;
              rise *= num6;
              this.slope = rise / 30f;
              if ((double) this.slope <= (double) num2)
                this.simulationState.npcPosition.Z += this.vec.Z;
              else
                this.simulationState.npcPosition.Y = this.lastHite;
            }
          }
          else
            this.simulationState.npcPosition += this.vec;
          if ((double) this.slope < (double) num3 && !this.jumping)
          {
            this.jumpCalled = true;
            this.fallGrav = -1f;
            this.fallAcc = -1f;
          }
        }
      }
      else
        this.simulationState.npcPosition += this.vec;
      if (this.jumping || flying)
      {
        this.lastHite += this.fallGrav;
        localPlayer.GetGround(ref heights, this.simulationState.npcPosition, ref this.ground, out this.normal);
        if (this.inBarn)
          this.ground = 0.0f;
        if (flying)
        {
          this.ground = this.floaty;
          this.lastHite = this.floaty;
        }
        this.simulationState.npcPosition.Y = MathHelper.Max(this.ground, this.lastHite);
      }
      if ((double) this.simulationState.npcPosition.Y <= (double) this.ground && !this.jumpCalled)
      {
        this.jumpCalled = false;
        this.jumping = false;
        this.jumpCount = 0;
        this.fallVec = Vector3.Zero;
        this.fallGrav = 0.0f;
        this.fallAcc = 0.0f;
        if ((double) this.futureDamage > 0.0)
          this.damHealth(this.futureDamage, false);
        this.futureDamage = 0.0f;
      }
      else
      {
        if (!this.jumping)
        {
          this.fallVec.X = this.vec.X;
          this.fallVec.Z = this.vec.Z;
        }
        this.jumpCalled = false;
        this.jumping = true;
        this.fallGrav += this.fallAcc;
        if ((double) this.fallGrav < -40.0)
          this.fallGrav = -40f;
        this.fallAcc -= 1f / 1000f;
        if ((double) this.fallGrav > 0.0)
          this.fallAcc -= 0.03f;
        if (!flying && (double) Math.Abs(this.normal.Y) < 0.5 && (double) this.simulationState.npcPosition.Y <= (double) this.ground + 40.0 && !this.inBarn)
        {
          this.motionVec.X = this.normal.X * 5f;
          this.motionVec.Z = this.normal.Z * 5f;
          this.fallVec.X = 0.0f;
          this.fallVec.Z = 0.0f;
        }
      }
      if (this.inFarm == 1)
      {
        this.simulationState.npcPosition.X = MathHelper.Clamp(this.simulationState.npcPosition.X, this.limitX.X, this.limitX.Y);
        this.simulationState.npcPosition.Z = MathHelper.Clamp(this.simulationState.npcPosition.Z, this.limitZ.X, this.limitZ.Y);
      }
      this.oldRot = this.displayState.npcRotation;
      this.oldPos = this.displayState.npcPosition;
      this.displayState = this.simulationState;
      this.calcClips();
    }

    private bool inbox(Vector2 p, Vector4 box)
    {
      bool flag = true;
      if ((double) p.X < (double) box.X || (double) p.X > (double) box.Y || (double) p.Y < (double) box.Z || (double) p.Y > (double) box.W)
        flag = false;
      return flag;
    }

    private bool breachx(
      Vector2 p,
      Vector4 b1,
      Vector4 b2,
      bool inbox1,
      bool inbox2,
      int weakwall)
    {
      bool flag = false;
      if (inbox1 && !inbox2)
      {
        if ((double) p.X <= (double) b1.X)
          flag = true;
        if ((double) p.X >= (double) b1.Y)
          flag = true;
      }
      if (!inbox1 && inbox2)
      {
        if ((double) p.X <= (double) b2.X && weakwall != 1)
          flag = true;
        if ((double) p.X >= (double) b2.Y && weakwall != 2)
          flag = true;
      }
      return flag;
    }

    private bool breachz(
      Vector2 p,
      Vector4 b1,
      Vector4 b2,
      bool inbox1,
      bool inbox2,
      int weakwall)
    {
      bool flag = false;
      if (inbox1 && !inbox2)
      {
        if ((double) p.Y <= (double) b1.Z)
          flag = true;
        if ((double) p.Y >= (double) b1.W)
          flag = true;
      }
      if (!inbox1 && inbox2)
      {
        if ((double) p.Y <= (double) b2.Z && weakwall != 3)
          flag = true;
        if ((double) p.Y >= (double) b2.W && weakwall != 4)
          flag = true;
      }
      return flag;
    }

    private void calcClips()
    {
      this.dir1 = 0.0f;
      this.dir2 = 0.0f;
      this.mySign = 1f;
      this.mult = 1.3f;
      this.cross = 0.3f;
      this.rotOffset = 0.0f;
      this.dist = Vector2.Distance(new Vector2(this.oldPos.X, this.oldPos.Z), new Vector2(this.displayState.npcPosition.X, this.displayState.npcPosition.Z));
      if ((double) this.dist > 0.0)
      {
        this.v1 = Vector2.Normalize(new Vector2(this.displayState.npcPosition.X, this.displayState.npcPosition.Z) - new Vector2(this.oldPos.X, this.oldPos.Z));
        this.v2 = Vector3.Transform(new Vector3(0.0f, 0.0f, 1f), Matrix.CreateRotationY(this.displayState.npcRotation));
        this.v3 = Vector3.Transform(new Vector3(1f, 0.0f, 0.0f), Matrix.CreateRotationY(this.displayState.npcRotation));
        this.dir1 = Vector2.Dot(this.v1, new Vector2(this.v2.X, this.v2.Z));
        this.dir2 = Vector2.Dot(this.v1, new Vector2(this.v3.X, this.v3.Z));
      }
      if ((double) Math.Abs(this.dir1) < (double) this.cross)
      {
        this.mult = 1.6f;
        this.mySign = 1f;
        if ((double) this.dir2 < 0.0)
          this.mySign = -1f;
      }
      else if ((double) this.dir1 < 0.0)
        this.mySign = -1f;
      this.rotOffset = (double) Math.Abs(this.dir1) < (double) this.cross ? (float) (-(double) Math.Abs(this.dir1) * 2.5) : (float) ((1.0 - (double) Math.Abs(this.dir1)) * 2.5);
      if ((double) this.dir1 < 0.0)
        this.rotOffset *= -1f;
      if ((double) this.dir2 < 0.0)
        this.rotOffset *= -1f;
      this.incry = (float) (((double) this.rotGoal - (double) this.rotOffset) / 10.0);
      this.rotGoal -= this.incry;
      if (this.milkEffects > 0)
        this.mult = 1f;
      this.incr = this.dist * this.mySign * this.mult;
      this.incr = MathHelper.Clamp(this.incr, -6f, 6f);
      float num1 = 0.8f;
      if (this.isDown)
        num1 = 0.8f;
      if (this.closeCam)
        num1 = (float) (1.0 - (double) Math.Abs(this.displayState.npcTilt) / 1.5);
      if ((double) this.displayState.npcRotation >= (double) this.feetRot + (double) num1)
        this.feetRot = this.displayState.npcRotation - num1;
      if ((double) this.displayState.npcRotation <= (double) this.feetRot - (double) num1)
        this.feetRot = this.displayState.npcRotation + num1;
      this.moving = this.oldPos != this.displayState.npcPosition;
      this.notRotating = (double) this.oldRot == (double) this.displayState.npcRotation && !this.isDown;
      this.headfeetAligned = (double) this.feetRot == (double) this.displayState.npcRotation;
      if (!this.moving && (!this.notRotating || this.headfeetAligned))
      {
        this.restTime = 0;
        this.rotLerp = 0.0f;
        if (!this.moving)
          this.lastFeetRot = this.feetRot;
      }
      else if (this.alreadyMoving)
      {
        this.rotLerp = 0.0f;
        this.restTime = 0;
        this.feetRot = this.displayState.npcRotation + this.rotGoal;
        this.lastFeetRot = this.feetRot;
      }
      else
      {
        ++this.restTime;
        if (this.restTime > 70 || this.moving)
        {
          this.rotLerp += 0.025f;
          if (this.moving)
            this.rotLerp += 0.05f;
          if ((double) this.rotLerp > 1.0)
          {
            this.rotLerp = 0.0f;
            this.restTime = 0;
            this.lastFeetRot = this.displayState.npcRotation + this.rotGoal;
            this.alreadyMoving = true;
          }
          this.feetRot = MathHelper.Hermite(this.lastFeetRot, 0.0f, this.displayState.npcRotation + this.rotGoal, 0.0f, this.rotLerp);
        }
      }
      if (!this.moving)
        this.alreadyMoving = false;
      this.headRot = this.displayState.npcRotation - this.feetRot;
      this.transform = Matrix.CreateRotationY(this.feetRot) * Matrix.CreateTranslation(this.displayState.npcPosition);
      if (!this.isDown)
      {
        if ((double) this.dist <= 0.0 && !this.jumping)
        {
          ++this.restTime2;
          if (this.clip1 != 1 && this.restTime2 > 5 && !this.isLiftingOpponent)
          {
            this.restTime2 = 0;
            this.clip2 = 1;
            this.swapClips();
          }
          if (this.isLiftingOpponent && this.clip1 != 10)
          {
            this.clip2 = 10;
            this.swapClips();
          }
        }
        if (this.jumping && this.clip1 != 16)
        {
          this.restTime2 = 5;
          this.clip2 = 16;
          this.swapClips();
        }
        if ((double) this.dist > 0.0 && !this.jumping)
        {
          this.restTime2 = 0;
          if (this.clip1 != 0 && (double) Math.Abs(this.dir1) >= (double) this.cross)
          {
            this.clip2 = 0;
            this.swapClips();
          }
          if (this.clip1 != 2 && (double) Math.Abs(this.dir1) < (double) this.cross)
          {
            this.clip2 = 2;
            this.swapClips();
          }
        }
        if (this.clip1 == 16 && (double) this.tween == 1.0)
          this.incr = 1f;
        else if (this.clip1 == 1 && (double) this.tween == 1.0)
          this.incr = 0.4f;
        else if (this.clip1 == 10 && (double) this.tween == 1.0)
          this.incr = 0.4f;
        this.step1 += this.incr;
        if (this.closeCam)
        {
          float num2 = MathHelper.Hermite(0.3f, 0.0f, 1f, 0.0f, Math.Abs(this.displayState.npcTilt * 0.833f));
          if ((double) num2 >= 0.99000000953674316)
            this.step1 = this.frame1;
          this.incr *= num2;
        }
      }
      else
        this.fallManager();
      this.frame1 += this.incr;
      if ((double) this.tween < 1.0)
      {
        this.tween += 0.1f;
        this.tween = MathHelper.Clamp(this.tween, 0.0f, 1f);
      }
      if ((double) this.frame1 >= 0.0)
        return;
      this.frame1 = 100000f;
      this.step1 = this.frame1;
    }

    private void swapClips()
    {
      this.tween = 1f - this.tween;
      this.tween = MathHelper.Clamp(this.tween, 0.0f, 1f);
      int clip2 = this.clip2;
      this.clip2 = this.clip1;
      this.clip1 = clip2;
    }

    private void fallManager()
    {
      if (!this.noArms && this.gunChoice != localPlayer.pType)
      {
        this.gunChoice = this.primaryChoice;
        this.lastWeapon = this.gunChoice;
        this.now.weapon = this.gunChoice;
      }
      if ((double) this.now.health == 100.0)
      {
        this.now.tempHealth -= 0.02f;
        if ((double) this.now.tempHealth < 0.0)
          this.now.tempHealth = 0.0f;
      }
      else
      {
        this.damHealth(0.02f, false);
        this.now.tempHealth = this.now.health;
      }
      if ((double) this.now.tempHealth < 1.0 && this.fallState < 11)
      {
        this.now.health = 0.0f;
        this.now.tempHealth = 0.0f;
        this.frame1 = 0.0f;
        if (this.fallState == 2)
          this.frame1 = 30f;
        this.fallState = 11;
      }
      if (this.fallState == 0)
      {
        this.fallState = 1;
        this.frame1 = 0.0f;
        this.clip2 = 8;
        this.swapClips();
        this.incr = 0.8f;
        this.triggerEvent = 3;
        if (this.closeCam || this.autoCamOn)
          return;
        this.autoCamOn = true;
        this.autoCamTarget = 1;
        this.autoCamTimer = 0.0f;
      }
      else if (this.fallState == 1)
      {
        this.incr = 0.8f;
        if ((double) this.frame1 <= 30.0)
          return;
        this.fallState = 2;
        this.clip2 = 9;
        this.swapClips();
      }
      else if (this.fallState == 2)
        this.incr = 0.4f;
      else if (this.fallState == 3)
      {
        this.triggerEvent = 2;
        this.fallState = 4;
        this.now.health = 100f;
        this.frame1 = 0.0f;
        this.clip2 = 7;
        this.swapClips();
        this.incr = 0.4f;
        if (this.remoteUsingMilk)
          this.incr = 0.7f;
        if (!this.closeCam || this.autoCamOn)
          return;
        this.autoCamOn = true;
        this.autoCamTarget = 1;
        this.autoCamTimer = 0.0f;
      }
      else if (this.fallState == 4)
      {
        this.incr = 0.4f;
        if (this.remoteUsingMilk)
          this.incr = 0.7f;
        this.now.health = 100f;
        if ((double) this.frame1 <= 85.0)
          return;
        this.fallState = 5;
        this.restTime2 = 0;
        this.clip2 = 1;
        this.swapClips();
      }
      else if (this.fallState == 5)
      {
        this.now.health = 100f;
        if ((double) this.tween < 0.89999997615814209)
          return;
        this.fallState = 0;
        this.now.health = 198f;
        this.triggerEvent = 1;
        if (this.closeCam && !this.autoCamOn)
        {
          this.autoCamOn = false;
          this.autoCamTimer = 0.0f;
          this.autoCamTarget = 0;
        }
        else
        {
          this.autoCamOn = true;
          this.autoCamTarget = 0;
          this.autoCamTimer = 1f;
        }
      }
      else if (this.fallState == 11)
      {
        this.now.health = 0.0f;
        this.clip2 = 11;
        this.swapClips();
        this.fallState = 12;
        this.incr = 0.6f;
        this.triggerEvent = 4;
        if (this.autoCamOn)
          return;
        this.autoCamOn = true;
        this.autoCamTarget = 1;
        this.autoCamTimer = 0.0f;
      }
      else
      {
        if (this.fallState != 12)
          return;
        this.incr = 0.6f;
        this.now.health = 0.0f;
        if ((double) this.frame1 <= 128.0)
          return;
        this.frame1 = 128f;
        this.incr = 0.0f;
      }
    }

    public void damHealth(float dam, bool cheat)
    {
      if (cheat || (double) this.now.health == 100.0)
        return;
      this.now.health -= dam;
      if ((double) this.now.health < 0.0)
        this.now.health = 0.0f;
      if ((double) this.now.health != 100.0)
        return;
      this.now.health = 98f;
    }

    private static void GetHeightFast(
      ref float[,] heights,
      Vector3 position,
      ref float height,
      ref float rise,
      out Vector3 normal)
    {
      int index1 = (int) ((double) position.X / (double) localPlayer.Unit);
      int index2 = (int) ((double) position.Z / (double) localPlayer.Unit);
      float num1 = position.X % localPlayer.Unit / localPlayer.Unit;
      float num2 = position.Z % localPlayer.Unit / localPlayer.Unit;
      float num3 = (float) ((1.0 - (double) num1) * (double) heights[index1, index2] + (double) num1 * (double) heights[index1 + 1, index2]);
      float num4 = (float) ((1.0 - (double) num1) * (double) heights[index1, index2 + 1] + (double) num1 * (double) heights[index1 + 1, index2 + 1]);
      height = (float) ((1.0 - (double) num2) * (double) num3 + (double) num2 * (double) num4);
      float num5 = MathHelper.Max(MathHelper.Max(heights[index1, index2], heights[index1 + 1, index2 + 1]), MathHelper.Max(heights[index1 + 1, index2], heights[index1, index2 + 1]));
      float num6 = MathHelper.Min(MathHelper.Min(heights[index1, index2], heights[index1 + 1, index2 + 1]), MathHelper.Min(heights[index1 + 1, index2], heights[index1, index2 + 1]));
      rise = num5 - num6;
      normal = Vector3.Normalize(new Vector3(-heights[index1 + 1, index2] + heights[index1, index2], 30f, -heights[index1, index2 + 1] + heights[index1, index2]));
    }

    private static void GetGround(
      ref float[,] heights,
      Vector3 position,
      ref float height,
      out Vector3 normal)
    {
      int index1 = (int) ((double) position.X / (double) localPlayer.Unit);
      int index2 = (int) ((double) position.Z / (double) localPlayer.Unit);
      float num1 = position.X % localPlayer.Unit / localPlayer.Unit;
      float num2 = position.Z % localPlayer.Unit / localPlayer.Unit;
      float num3 = (float) ((1.0 - (double) num1) * (double) heights[index1, index2] + (double) num1 * (double) heights[index1 + 1, index2]);
      float num4 = (float) ((1.0 - (double) num1) * (double) heights[index1, index2 + 1] + (double) num1 * (double) heights[index1 + 1, index2 + 1]);
      height = (float) ((1.0 - (double) num2) * (double) num3 + (double) num2 * (double) num4);
      normal = Vector3.Normalize(new Vector3(-heights[index1 + 1, index2] + heights[index1, index2], 30f, -heights[index1, index2 + 1] + heights[index1, index2]));
    }

    public class nowState
    {
      public float health = 199f;
      public byte whichLevel;
      public byte byte_0 = 12;
      public byte byte_1 = 12;
      public bool leverOn;
      public byte bonusnpc;
      public bool rocketLoaded;
      public float tempHealth;
      public byte load;
      public ushort myscore;
      public ushort remscore;
      public bool flashlight;
      public int animation;
      public int weapon;
      public int gunfired;
      public byte doorOpen;
      public Vector3 destiny;
      public ushort accuracy;
      public int grinder;
    }

    public struct conductor
    {
      public byte type;
      public ushort id;
      public ushort id2;
      public ushort id3;
      public ushort id4;
      public ushort id5;
      public ushort id6;
      public ushort id7;
      public ushort id8;
      public byte action;
      public byte bodypart;
      public ushort frame;
      public int time;
      public float rot;
      public byte speed;
      public bool died;
      public bool died2;
      public bool died3;
      public bool died4;
      public bool died5;
      public Vector3 veloc;
    }

    public struct npcState
    {
      public Vector3 npcPosition;
      public float npcRotation;
      public float npcTilt;
    }
  }
}
