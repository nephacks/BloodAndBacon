using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;

#pragma warning disable CS0169
#pragma warning disable CS0649
#nullable disable
namespace Blood
{
  internal class remotePlayer
  {
    private float distLimit = 1.3f;
    public byte flag;
    public int tempHealthVal;
    public bool tempLiftVal;
    public bool tempOnMilk;
    public bool tempOnHulk;
    public bool tempJumping;
    public byte uvIndex;
    public byte cuttyXcoord;
    public byte cuttyYcoord;
    public byte cuttyindexBit;
    public ushort cuttyhealth;
    public byte cuttyDamBit;
    public ushort cuttyDamage;
    public bool cuttyonFire;
    public bool tempFire;
    public bool bool_0;
    public bool pillTaken;
    public byte bossindexBit;
    public ushort bosshealth;
    public byte bossDamBit;
    public ushort bossDamage;
    public float diff;
    public bool isGone = true;
    public bool stats_recieved;
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
    public float realDarkness;
    public int realMoon;
    public int newDayTime;
    public int boarSpawn = -1;
    public int boarCount;
    public int boarHealth;
    public int boarAttack;
    public int boarMinSize;
    public int boarMaxSize;
    public int boarGiantOdds;
    public int boarTinyOdds;
    public int boarCharge;
    public int boarTurnRate;
    public int boarDist0;
    public int boarDist1;
    public int boarDist2;
    public int boarDist3;
    public int boarDist4;
    public int boarDist5;
    public int boarLimit0;
    public int boarLimit1;
    public int boarLimit2;
    public int boarLimit3;
    public int boarLimit4;
    public int boarLimit5;
    public int triggerEvent;
    public bool bloodExists;
    public int bloodCoil;
    public int bloodIndex;
    public float bloodPool = 16f;
    public Matrix bloodPos;
    public float bloodRot;
    public bool isDown;
    public int fallState;
    public Matrix[] mySkin;
    private bool moving;
    private bool notRotating;
    private bool headfeetAligned;
    private bool alreadyMoving;
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
    public int verifyTime;
    public bool set_newTime;
    public bool hasnoArms;
    public int armTimer;
    public int remoteTick;
    public int last_remoteTick;
    public int boarDropTimer = -1;
    public int boarSeed;
    public int boarHandicap;
    public Matrix cambone;
    public Matrix pistolHand;
    public Matrix headbone;
    public Vector2 recoilVec;
    public Vector3 gunpos;
    public Vector3 gunlook;
    public int gunChoice;
    public int guntimer;
    public int flashChoice;
    public int flashSide;
    public int primaryChoice = 2;
    public int secondaryChoice = 8;
    public int lastWeapon = 2;
    public float animCount = -1f;
    public float animTween;
    public List<int> animList = new List<int>();
    public int animClip = -1;
    public int animMax;
    public int animMin;
    public int animLoop;
    public float recoilTimer;
    public float flashTimer;
    public float blastTimer;
    public float blastRot;
    public bool flashfromSide;
    public float gunsideScale;
    public float gunfrontScale;
    public int hatindex;
    private bool falling;
    public bool jumping;
    public byte difficulty;
    public bool isLiftingYou;
    public bool onMilk;
    public bool onHulk;
    public int hulkTrans;
    public bool weareUsingMilk;
    public bool tempLever;
    public bool cheats;
    public remotePlayer.nowState now;
    public remotePlayer.conductor creature;
    public remotePlayer.conductor creaturemulti;
    public remotePlayer.conductor creatureShock;
    public remotePlayer.conductor shatter;
    public bool cheat_SendPackage;
    public bool cheat_Invincible;
    public bool cheat_FastFiring;
    public bool cheat_InfiniteAmmo;
    public bool cheat_AllExplode;
    public bool cheat_PickupPack;
    public bool cheat_UnlockAll;
    public int cutty_SendPackage = -1;
    public byte cutty_index;
    public byte cutty_homing;
    public float cutty_rot;
    public byte cutty_curveIndex;
    public float cutty_loop;
    public byte cutty_animtype;
    public byte cutty_talkindex;
    public ushort cutty_dur;
    public float cutty_destx;
    public float cutty_destz;
    public float cutty_targetRate;
    public byte partTYPE;
    public ushort partID;
    public byte partHIT;
    public int partTIME;
    public Vector3 partPOS;
    public Vector3 partVEL;
    public Quaternion partQUAT;
    public bool mirvToss;
    public Vector3 mirvPos = Vector3.Zero;
    public bool grenToss;
    public bool farmerTalk;
    public byte farmerIndex;
    public ushort grenSeed;
    public Vector3 grenPos;
    public Vector3 grenVeloc;
    public byte grenBounce;
    public byte grenAge;
    public int oldScore = -1;
    public int setClock;
    public byte netquality;
    private float incrOffset;
    private Vector3 oldPos;
    public float currentSmoothing;
    public float smoothingDecay;
    public remotePlayer.npcState simulationState;
    private remotePlayer.npcState previousState;
    public remotePlayer.npcState displayState;
    public List<remotePlayer.npcState> myState = new List<remotePlayer.npcState>();
    public remotePlayer.npcState tempState;
    public Vector3 lastPOS;
    public Matrix transform;
    public float frame1;
    public float tween = 1f;
    public float incr;
    public int clip1;
    public int clip2;
    private int restTime;
    public float feetRot;
    public float headRot;
    private int restTime2;
    private float rotLerp;
    private float lastFeetRot;
    public float rotGoal;
    private float[] ff = new float[10]
    {
      -0.02f,
      -0.015f,
      -0.0035f,
      0.0f,
      1f / 1000f,
      1f / 1000f,
      1f / 1000f,
      1f / 1000f,
      1f / 500f,
      3f / 1000f
    };
    private float oldRot;

    public remotePlayer(ContentManager content, Vector3 vv)
    {
      this.simulationState.npcPosition = vv;
      this.simulationState.npcRotation = -1.57f;
      this.feetRot = -1.57f;
      this.lastFeetRot = -1.57f;
      this.simulationState.npcTilt = 0.0f;
      this.displayState = this.simulationState;
      this.previousState = this.displayState;
      this.currentSmoothing = 1f;
      this.smoothingDecay = 0.1f;
      this.now = new remotePlayer.nowState();
      this.mySkin = new Matrix[29];
      this.myState.Capacity = 20;
      this.creature.id = (ushort) 65000;
      this.partID = (ushort) 0;
      this.frame1 = 100000f;
      this.animList.Capacity = 20;
    }

    public void handleHealth()
    {
      if (this.isDown && (double) this.now.health > 105.0 && this.fallState != 5 && this.fallState != 4)
      {
        this.fallState = 0;
        this.isDown = false;
      }
      else if (this.fallState == 0 && (double) this.now.health <= 99.0 && (double) this.now.health > 0.0 && !this.isDown)
        this.isDown = true;
      else if (this.fallState <= 2 && (double) this.now.health == 100.0)
        this.fallState = 3;
      else if (this.fallState >= 3 && this.fallState <= 5 && (double) this.now.health <= 99.0 && (double) this.now.health > 0.0)
      {
        this.isDown = true;
        this.fallState = 0;
      }
      else
      {
        if (this.fallState >= 11 || (double) this.now.health != 0.0)
          return;
        this.frame1 = 0.0f;
        this.isLiftingYou = false;
        if (this.fallState == 2)
          this.frame1 = 30f;
        this.isDown = true;
        this.fallState = 11;
      }
    }

    public void handleList()
    {
      if (this.myState.Count < 1)
        return;
      this.previousState = this.displayState;
      this.currentSmoothing = 1f;
      float num = Vector3.DistanceSquared(this.myState[0].npcPosition, this.simulationState.npcPosition);
      this.smoothingDecay = this.myState[0].decay;
      this.simulationState.npcPosition = this.myState[0].npcPosition;
      this.simulationState.npcRotation = this.myState[0].npcRotation;
      this.simulationState.npcTilt = this.myState[0].npcTilt;
      this.incrOffset = this.ff[this.myState.Count];
      if ((double) num > 1.0)
        this.smoothingDecay += this.incrOffset;
      else
        this.smoothingDecay += 0.02f;
      this.currentSmoothing -= this.smoothingDecay;
      this.myState.RemoveAt(0);
    }

    public void UpdateRemote(ref float[,] heights)
    {
      this.currentSmoothing -= this.smoothingDecay;
      if ((double) this.currentSmoothing <= 0.0)
      {
        this.currentSmoothing = 0.0f;
        this.handleList();
      }
      this.oldPos = this.displayState.npcPosition;
      this.oldRot = this.displayState.npcRotation;
      this.displayState.npcPosition = Vector3.Lerp(this.simulationState.npcPosition, this.previousState.npcPosition, this.currentSmoothing);
      this.displayState.npcRotation = MathHelper.Lerp(this.simulationState.npcRotation, this.previousState.npcRotation, this.currentSmoothing);
      this.displayState.npcTilt = MathHelper.Lerp(this.simulationState.npcTilt, this.previousState.npcTilt, this.currentSmoothing);
      this.calcClips();
    }

    private void calcClips()
    {
      this.dir1 = 0.0f;
      this.dir2 = 0.0f;
      this.mySign = 1f;
      this.mult = 1.3f;
      this.cross = 0.3f;
      this.rotOffset = 0.0f;
      this.dist = Vector2.Distance(new Vector2(this.displayState.npcPosition.X, this.displayState.npcPosition.Z), new Vector2(this.oldPos.X, this.oldPos.Z));
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
      this.incr = this.dist * this.mySign * this.mult;
      this.incr = MathHelper.Clamp(this.incr, -6f, 6f);
      this.distLimit = 1.3f;
      if (this.isDown)
        this.distLimit = 0.8f;
      if ((double) this.displayState.npcRotation >= (double) this.feetRot + (double) this.distLimit)
        this.feetRot = this.displayState.npcRotation - this.distLimit;
      if ((double) this.displayState.npcRotation <= (double) this.feetRot - (double) this.distLimit)
        this.feetRot = this.displayState.npcRotation + this.distLimit;
      this.moving = this.oldPos != this.displayState.npcPosition;
      this.notRotating = (double) this.oldRot == (double) this.displayState.npcRotation;
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
          if (this.clip1 != 1 && this.restTime2 > 5)
          {
            this.restTime2 = 0;
            this.clip2 = 1;
            this.swapClips();
          }
          if (this.isLiftingYou && this.clip1 != 10 && !this.pillTaken)
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
    }

    private void swapClips()
    {
      this.tween = 1f - this.tween;
      int clip2 = this.clip2;
      this.clip2 = this.clip1;
      this.clip1 = clip2;
    }

    private void fallManager()
    {
      this.now.liftHealth -= 0.02f;
      if ((double) this.now.liftHealth < 0.0)
        this.now.liftHealth = 0.0f;
      if (this.fallState == 0)
      {
        this.fallState = 1;
        this.frame1 = 0.0f;
        this.clip2 = 8;
        this.swapClips();
        this.incr = 0.8f;
        this.triggerEvent = 3;
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
        this.frame1 = 0.0f;
        this.clip2 = 7;
        this.swapClips();
        this.incr = 0.4f;
        if (!this.weareUsingMilk)
          return;
        this.incr = 0.7f;
      }
      else if (this.fallState == 4)
      {
        this.isDown = true;
        this.incr = 0.4f;
        if (this.weareUsingMilk)
          this.incr = 0.7f;
        if ((double) this.frame1 <= 85.0 && (double) this.now.health <= 105.0)
          return;
        if ((double) this.now.health > 105.0)
        {
          this.fallState = 5;
          this.restTime2 = 0;
          this.clip2 = 1;
          this.swapClips();
        }
        else
          this.frame1 = 85f;
      }
      else if (this.fallState == 5)
      {
        this.isDown = true;
        this.frame1 = 94f;
        if ((double) this.tween < 0.89999997615814209)
          return;
        this.isDown = false;
        this.fallState = 0;
        this.triggerEvent = 1;
      }
      else if (this.fallState == 11)
      {
        this.now.health = 0.0f;
        this.clip2 = 11;
        this.swapClips();
        this.fallState = 12;
        this.incr = 0.8f;
        this.triggerEvent = 4;
      }
      else
      {
        if (this.fallState != 12)
          return;
        this.incr = 0.8f;
        this.now.health = 0.0f;
        if ((double) this.frame1 <= 128.0)
          return;
        this.frame1 = 128f;
        this.incr = 0.0f;
      }
    }

    public class nowState
    {
      public float health = 199f;
      public byte whichLevel;
      public byte byte_0 = 10;
      public byte byte_1 = 10;
      public bool leverOn;
      public int leverRespond;
      public bool rocketLoaded;
      public byte bonusnpc;
      public float liftHealth;
      public byte load;
      public byte loadDay = 1;
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
      public int boarID = -1;
      public int bloodpart = -1;
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
      public float decay;
      public Vector3 npcPosition;
      public float npcRotation;
      public float npcTilt;
    }
  }
}
