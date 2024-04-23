// Decompiled with JetBrains decompiler
// Type: Blood.boarDupe
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

#nullable disable
namespace Blood
{
  public class boarDupe
  {
    private int ch;
    public static int homingCount = 0;
    public static int homingCount2 = 0;
    public static int currentDay = 1;
    public static float acc = 3000f;
    public static float handicapSpeed = 1f;
    public static float handicapTurn = 1f;
    public bool undead;
    public bool zombie;
    public bool borders = true;
    public bool interrupt;
    public bool oldturning;
    public float oldturn;
    public float oldtimer;
    public float oldspeed;
    public int oldclip;
    public int oldtemp;
    public int oldframe;
    public bool death;
    public float amp = 1f;
    public float freq = 20f;
    public float charge = 1f;
    public float turnlimit = 0.07f;
    public float turnHelper = 0.07f;
    public int boarGroup = 1;
    public int variant;
    public int isStun;
    public int resetStun;
    public int isChomp;
    public int resetChomp;
    public int isSpooked;
    public int isGrow = -1;
    public bool growTrigger;
    public int isGrowAge;
    private int resetSpooked;
    public int isBlind;
    public int isHead = -1;
    public bool nozombies;
    public int isShocked;
    public int isZap;
    public int isCrumbled;
    public int exploded;
    public int shottie;
    public int timeofDeath;
    public static int bitmap;
    public static float unit;
    public static float Grid;
    public int homing;
    public int splatIndex;
    public int move;
    public float myRot;
    public float myRotHeld;
    public float angleX;
    public float angleZ;
    public float scale;
    public float bluScale;
    public Vector3 mypos;
    public bool isturning;
    public int frame1 = 1;
    public int frame2 = 1;
    public int temp1;
    public int temp2;
    public int clip1;
    public int clip2;
    public float tween;
    public int stunLength = 150;
    public float speed;
    public float turn;
    public float timer;
    public float startHealth = 5f;
    public float health = 5f;
    public Matrix transform;
    public int blood;
    public static List<int> sics;
    public int seed;
    private float groundHeight;
    public int age;
    public float tint;
    public float oldtint;
    public Random random;
    public Random randomDeath;
    public Random randomHead;
    public Random randomPartsFly;
    public int immunity;
    public int assexplode;
    public static ScreenManager sc;
    public float nightSpeed = 1f;
    public float scaleSpeed = 1f;
    private int defaultClip;

    public boarDupe(
      int group,
      int variant,
      Vector3 startpos,
      int myMove,
      int seed,
      int age,
      ScreenManager sc,
      string timeofday,
      int formation,
      bool noZboars)
    {
      this.nozombies = noZboars;
      boarDupe.sc = sc;
      boarDupe.homingCount = 0;
      boarDupe.homingCount2 = 0;
      this.splatIndex = 0;
      this.random = new Random(seed);
      this.randomDeath = new Random(seed + 1);
      this.randomHead = new Random(seed + 2);
      this.randomPartsFly = new Random(seed + 3);
      this.blood = 0;
      this.mypos = startpos;
      this.move = myMove;
      this.tween = 1f;
      this.age = age;
      this.seed = seed;
      this.boarGroup = group;
      this.variant = variant;
      if (sc.gameSpectate != 0)
      {
        this.freq = (float) this.random.Next(2000, 10000) / 100f;
        this.amp = (float) this.random.Next(200, 700) / 100f;
      }
      else
      {
        this.freq = (float) this.random.Next(6000, 10000) / 100f;
        this.amp = (float) this.random.Next(700, 900) / 100f;
      }
      this.stunLength = this.random.Next(120, 154);
      this.defaultClip = 0;
      this.nightSpeed = 1f;
      if (group == 1 && this.random.Next(1, 100) < sc.int_7)
      {
        this.defaultClip = 1;
        this.nightSpeed = (float) this.random.Next(5, 10);
        if (variant == 4 && boarDupe.currentDay <= 100)
          this.nightSpeed = (float) this.random.Next(10, 15);
      }
      if (group == 2 && this.random.Next(1, 100) < sc.int_8)
      {
        this.defaultClip = 1;
        this.nightSpeed = (float) this.random.Next(5, 10);
        if (variant == 4 && boarDupe.currentDay <= 100)
          this.nightSpeed = (float) this.random.Next(10, 15);
      }
      this.isBlind = -1;
      this.isSpooked = -1;
      if (this.random.Next(1, 100) < 20 && boarDupe.currentDay != 101)
        this.isSpooked = -1;
      this.resetSpooked = this.isSpooked;
      this.isStun = 0;
      this.resetStun = this.isStun;
      this.isChomp = -1;
      if (variant == 1)
        this.isChomp = 0;
      if (variant == 2 && this.random.Next(1, 100) < 40)
        this.isChomp = 0;
      this.resetChomp = this.isChomp;
      this.isShocked = 0;
      if (variant == 2)
        this.isShocked = -1;
      this.isHead = -1;
      this.exploded = 0;
      this.immunity = 0;
      if (group == 1)
      {
        this.assexplode = sc.boar1explode;
        if (sc.boar1explode == 0)
          this.assexplode = 50000;
        this.borders = false;
        if (sc.boar1Borders == 1)
          this.borders = true;
      }
      if (group == 2)
      {
        this.assexplode = sc.boar2explode;
        if (sc.boar2explode == 0)
          this.assexplode = 50000;
        this.borders = false;
        if (sc.boar2Borders == 1)
          this.borders = true;
      }
      this.shottie = 0;
      if (this.boarGroup == 1)
      {
        this.shottie = sc.boar1shottie;
        if (sc.boar1shottie == 0)
          this.shottie = 50000;
      }
      if (this.boarGroup == 2)
      {
        this.shottie = sc.boar2shottie;
        if (sc.boar2shottie == 0)
          this.shottie = 50000;
      }
      this.homing = 0;
      if (group == 1)
        this.charge = (float) this.random.Next(300, 500) / 10000f * (float) sc.int_11;
      if (group == 2)
        this.charge = (float) this.random.Next(300, 500) / 10000f * (float) sc.int_14;
      this.turnHelper = (float) this.random.Next(130, 200) / 10000f;
      if (group == 1 && (variant == 0 || variant == 3 || variant == 2 || variant == 4) && this.random.Next(1, 100) < sc.headless1Percent)
        this.isHead = 0;
      if (group == 2 && (variant == 0 || variant == 3 || variant == 2 || variant == 4) && this.random.Next(1, 100) < sc.headless2Percent)
        this.isHead = 0;
      this.tint = (float) this.random.Next(1, 6);
      if (variant == 4)
      {
        this.tint = (float) this.random.Next(0, 7);
        if (boarDupe.currentDay == 101 || boarDupe.currentDay == 42 || boarDupe.currentDay == 3)
          this.tint = 6f;
      }
      if (variant == 1)
      {
        int num = this.random.Next(0, 4);
        if (num == 0)
          this.tint = 7f;
        if (num == 1)
          this.tint = 8f;
        if (num == 2)
          this.tint = 9f;
        if (num == 3)
          this.tint = 0.0f;
      }
      if (variant == 2)
      {
        this.tint = 6f;
        if (this.random.Next(1, 100) < 30)
          this.tint = 10f;
      }
      if (variant == 3)
      {
        int num = this.random.Next(0, 4);
        if (num == 0)
          this.tint = 0.0f;
        if (num == 1)
          this.tint = 5f;
        if (num == 2)
          this.tint = 8f;
        if (num == 3)
          this.tint = 9f;
      }
      if (group == 1)
        this.scale = (float) this.random.Next(sc.boar1MinSize, sc.boar1MaxSize) / 50f;
      if (group == 2)
        this.scale = (float) this.random.Next(sc.boar2MinSize, sc.boar2MaxSize) / 50f;
      if (group == 1)
        this.health = this.scale * ((float) sc.int_9 / 10f);
      if (group == 2)
        this.health = this.scale * ((float) sc.int_12 / 10f);
      if (variant == 1)
        this.health *= 2f;
      if ((double) this.health < 1.0)
        this.health = 1f;
      if (sc.int_9 > 5000)
      {
        this.undead = true;
        this.health = 699f;
      }
      this.startHealth = this.health;
      if (group == 1 && this.random.Next(0, 1001) < sc.boar1TinyOdds * 10 || group == 2 && this.random.Next(0, 1001) < sc.boar2TinyOdds * 10)
      {
        this.scale = (float) this.random.Next(3, 6) / 50f;
        this.tint = 0.0f;
        if (this.random.Next(1, 100) < 50 || variant == 4)
          this.tint = 6f;
        this.health = 1f;
        this.isHead = -1;
      }
      if (group == 1 && this.random.Next(0, 1001) < sc.boar1GiantOdds * 10 || group == 2 && this.random.Next(0, 1001) < sc.boar2GiantOdds * 10)
      {
        this.scale = (float) this.random.Next(18, 22) / 50f;
        if (this.random.Next(1, 1000) < 150)
          this.scale = (float) this.random.Next(28, 36) / 50f;
        this.immunity = 50000;
        this.shottie = 5;
        this.tint = 6f;
        this.health = 10f;
        this.isHead = -1;
        if (this.random.Next(1, 100) < 60)
          this.isHead = 0;
      }
      this.isGrow = -1;
      if ((group == 1 && sc.int_7 == 1 || group == 2 && sc.int_8 == 1) && this.immunity < 5000 && this.random.Next(1, 100) < 90)
      {
        this.isGrow = 0;
        this.isGrowAge = this.random.Next(100, 1200);
        this.bluScale = (float) this.random.Next(26, 47) / 100f;
        this.growTrigger = false;
      }
      if (this.undead)
      {
        this.isGrow = 0;
        this.isGrowAge = 250;
        this.bluScale = (float) this.random.Next(35, 38) / 100f;
        this.growTrigger = false;
      }
      this.myRot = (float) this.random.Next(-800, 800) / 100f;
      this.speed = this.scale * (boarDupe.acc / 1000f) * this.nightSpeed;
      this.turn = (float) this.random.Next(-20, 20) / 1000f;
      this.timer = (float) this.random.Next(20, 300);
      this.clip1 = this.defaultClip;
      this.clip2 = this.defaultClip;
      if (group == 1 && sc.int_0 > 0)
        this.timer = (float) sc.int_0;
      if (group == 2 && sc.int_1 > 0)
        this.timer = (float) sc.int_1;
      if (group == 1 && sc.int_2 > 0)
      {
        this.scaleSpeed = (float) this.random.Next(35, 45) / 10f;
        if (sc.int_2 == 1)
          this.speed = (float) (0.20000000298023224 * ((double) boarDupe.acc / 1000.0)) * this.scaleSpeed;
        if (sc.int_2 == 2)
        {
          this.speed = (float) (0.20000000298023224 * ((double) boarDupe.acc / 1000.0) * 7.0);
          this.scaleSpeed = 7f;
        }
        if (sc.int_2 == 3)
        {
          this.speed = (float) (0.20000000298023224 * ((double) boarDupe.acc / 1000.0) * 10.0);
          this.scaleSpeed = 10f;
        }
        if (sc.int_2 == 4)
        {
          this.speed = (float) (0.20000000298023224 * ((double) boarDupe.acc / 1000.0) * 22.0);
          this.scaleSpeed = 22f;
        }
        this.clip1 = this.random.Next(1, 4);
        this.clip2 = this.clip1;
      }
      if (group == 2 && sc.int_3 > 0)
      {
        this.scaleSpeed = (float) this.random.Next(35, 45) / 10f;
        if (sc.int_3 == 1)
          this.speed = (float) (0.20000000298023224 * ((double) boarDupe.acc / 1000.0)) * this.scaleSpeed;
        if (sc.int_3 == 2)
        {
          this.speed = (float) (0.20000000298023224 * ((double) boarDupe.acc / 1000.0) * 7.0);
          this.scaleSpeed = 7f;
        }
        if (sc.int_3 == 3)
        {
          this.speed = (float) (0.20000000298023224 * ((double) boarDupe.acc / 1000.0) * 10.0);
          this.scaleSpeed = 10f;
        }
        if (sc.int_3 == 4)
        {
          this.speed = (float) (0.20000000298023224 * ((double) boarDupe.acc / 1000.0) * 22.0);
          this.scaleSpeed = 22f;
        }
        this.clip1 = this.random.Next(1, 4);
        this.clip2 = this.clip1;
      }
      if (group == 1 && (double) sc.boar1Rot != 0.0)
        this.myRot = sc.boar1Rot;
      if (group == 2 && (double) sc.boar2Rot != 0.0)
        this.myRot = sc.boar2Rot;
      if (group == 1 && (double) sc.float_0 != 99.0)
        this.turn = sc.float_0 / 1000f;
      if (group == 2 && (double) sc.float_1 != 99.0)
        this.turn = sc.float_1 / 1000f;
      if (group == 1)
      {
        sc.boarAttack = sc.int_10;
        sc.boarTurnRate = sc.boar1TurnRate;
      }
      if (group == 2)
      {
        sc.boarAttack = sc.int_13;
        sc.boarTurnRate = sc.boar2TurnRate;
      }
      if (group == 1 && (formation > 19 && formation < 30 || (double) Math.Abs(sc.boar1Rot) >= 50.0))
      {
        Vector2 vector2 = new Vector2(3000f, 3000f);
        if ((double) Math.Abs(sc.boar1Rot) >= 50.0)
          vector2 = new Vector2(sc.boar1Rot, sc.float_0);
        float num1 = -(float) Math.Atan2((double) startpos.Z - (double) vector2.X, (double) startpos.X - (double) vector2.Y);
        float num2 = 6.28318548f * Vector2.Distance(vector2, new Vector2(startpos.X, startpos.Z)) / (this.speed * boarDupe.handicapSpeed);
        if ((double) sc.float_0 >= 0.0)
        {
          this.myRot = num1;
          this.turn = -6.28318548f / num2;
        }
        else
        {
          this.myRot = num1 + 3.14159274f;
          this.turn = (float) (-6.2831854820251465 / (double) num2 * -1.0);
        }
      }
      if (group == 2 && (formation > 19 && formation < 30 || (double) Math.Abs(sc.boar2Rot) >= 50.0))
      {
        Vector2 vector2 = new Vector2(3000f, 3000f);
        if ((double) Math.Abs(sc.boar2Rot) >= 50.0)
          vector2 = new Vector2(sc.boar2Rot, sc.float_1);
        float num3 = -(float) Math.Atan2((double) startpos.Z - (double) vector2.X, (double) startpos.X - (double) vector2.Y);
        float num4 = 6.28318548f * Vector2.Distance(vector2, new Vector2(startpos.X, startpos.Z)) / (this.speed * boarDupe.handicapSpeed);
        if ((double) sc.float_1 >= 0.0)
        {
          this.myRot = num3;
          this.turn = -6.28318548f / num4;
        }
        else
        {
          this.myRot = num3 + 3.14159274f;
          this.turn = (float) (-6.2831854820251465 / (double) num4 * -1.0);
        }
      }
      this.temp1 = this.random.Next(20, 30000);
      this.temp2 = this.random.Next(20, 30000);
    }

    private void calTint()
    {
      float num = this.tint - (float) (int) this.tint;
      this.tint = (float) new int[13]
      {
        9,
        8,
        7,
        5,
        3,
        11,
        6,
        6,
        6,
        6,
        6,
        6,
        6
      }[(int) MathHelper.Clamp((float) ((int) this.health / 100), 0.0f, 7f)] + num;
      if ((double) this.health >= 100.0)
        return;
      this.undead = false;
    }

    public void UpdateNormal(ref float[,] heights)
    {
      ++this.age;
      if (this.undead)
        this.calTint();
      if (this.growTrigger)
      {
        this.scale += 1f / 500f;
        if ((double) this.scale > (double) this.bluScale)
        {
          this.growTrigger = false;
          if (!this.undead)
          {
            this.isGrow = 2;
            if (this.boarGroup == 1)
              this.health = this.scale * ((float) boarDupe.sc.int_9 / 10f);
            if (this.boarGroup == 2)
              this.health = this.scale * ((float) boarDupe.sc.int_12 / 10f);
            if (this.homing != 0)
              this.speed = this.scale * (boarDupe.acc / 1000f) * this.scaleSpeed;
          }
          else
            this.isGrow = -1;
        }
      }
      this.mypos.X += (float) (-Math.Cos((double) this.myRot + 1.5707999467849731) * ((double) this.speed * (double) boarDupe.handicapSpeed));
      this.mypos.Z += (float) Math.Sin((double) this.myRot + 1.5707999467849731) * (this.speed * boarDupe.handicapSpeed);
      if ((double) this.mypos.X > 5900.0 || (double) this.mypos.X < 100.0)
        this.mypos.X = 6000f - this.mypos.X;
      if ((double) this.mypos.Z > 5900.0 || (double) this.mypos.Z < 100.0)
        this.mypos.Z = 6000f - this.mypos.Z;
      boarDupe.GetHeightFast(ref heights, new Vector2(this.mypos.X, this.mypos.Z), out this.groundHeight);
      this.mypos.Y = this.groundHeight;
      this.myRot += this.turn;
      --this.timer;
      ++this.temp1;
      ++this.temp2;
      this.frame1 = this.temp1 % boarDupe.sics[this.clip1 * 2] + boarDupe.sics[this.clip1 * 2 + 1];
      this.frame2 = this.temp2 % boarDupe.sics[this.clip2 * 2] + boarDupe.sics[this.clip2 * 2 + 1];
      this.tween += 0.125f;
      if ((double) this.timer > 0.0)
        return;
      this.makeCalc();
    }

    public void UpdateDeath(ref float[,] heights)
    {
      ++this.age;
      if (this.undead)
        this.calTint();
      this.mypos.X += this.angleX * (this.speed * boarDupe.handicapSpeed);
      this.mypos.Z += this.angleZ * (this.speed * boarDupe.handicapSpeed);
      this.mypos.X = MathHelper.Clamp(this.mypos.X, 100f, 5900f);
      this.mypos.Z = MathHelper.Clamp(this.mypos.Z, 100f, 5900f);
      boarDupe.GetHeightFast(ref heights, new Vector2(this.mypos.X, this.mypos.Z), out this.groundHeight);
      this.mypos.Y = this.groundHeight;
      this.myRot += this.turn;
      --this.timer;
      this.tween += 0.125f;
      if ((double) this.timer <= 0.0)
      {
        this.turn *= 0.98f;
        this.speed *= 0.98f;
        if ((double) this.speed >= 0.05000000074505806)
          return;
        this.makeCalc();
      }
      else
      {
        ++this.temp1;
        ++this.temp2;
        this.frame1 = this.temp1 % boarDupe.sics[this.clip1 * 2] + boarDupe.sics[this.clip1 * 2 + 1];
        this.frame2 = this.temp2 % boarDupe.sics[this.clip2 * 2] + boarDupe.sics[this.clip2 * 2 + 1];
      }
    }

    private void setClips(int chx)
    {
      int frame2 = this.frame2;
      this.frame2 = this.frame1;
      this.frame1 = frame2;
      int temp2 = this.temp2;
      this.temp2 = this.temp1;
      this.temp1 = temp2;
      this.tween = 0.0f;
      this.clip2 = this.clip1;
      this.clip1 = chx;
    }

    public void makeCalc()
    {
      this.isChomp = this.resetChomp;
      this.isStun = this.resetStun;
      this.isSpooked = this.resetSpooked;
      if (this.interrupt)
      {
        this.interrupt = false;
        this.clip2 = this.clip1;
        this.clip1 = this.oldclip;
        this.temp2 = this.temp1;
        this.temp1 = this.oldtemp;
        this.frame2 = this.frame1;
        this.frame1 = this.oldframe;
        this.turn = this.oldturn;
        this.isturning = this.oldturning;
        this.speed = this.oldspeed;
        this.timer = this.oldtimer;
        this.tween = 0.0f;
      }
      else if (this.isShocked == 2)
      {
        if (!this.undead)
        {
          if (this.death && this.isHead <= 0 && !this.nozombies)
          {
            this.isGrow = 0;
            this.isGrowAge = this.age + this.random.Next(100, 600);
            this.bluScale = (float) this.random.Next(25, 60) / 100f;
            this.growTrigger = false;
            this.assexplode = 50;
            this.shottie = 500;
            this.death = false;
            this.undead = true;
            this.zombie = true;
            this.blood = 0;
            this.health = 300f;
            this.isShocked = 0;
            if (this.homing != 0)
            {
              this.isturning = false;
              this.timer = 50000f;
              this.ch = 2;
              if (this.random.Next(1, 100) < 51)
                this.ch = 3;
              this.speed = (float) ((double) this.scale * ((double) boarDupe.acc / 1000.0) * (double) this.charge * 1.5);
              this.scaleSpeed = this.charge;
              this.setClips(this.ch);
            }
            else
            {
              this.isturning = false;
              this.timer = (float) this.random.Next(120, 280);
              this.speed = 0.0f;
              this.turn = 0.0f;
              this.setClips(5);
            }
          }
          else
          {
            this.move = 0;
            this.isShocked = 3;
            this.tween = 1f;
            this.health = 0.0f;
            this.blood = 0;
          }
        }
        else
        {
          this.isShocked = 0;
          this.blood = 0;
          this.death = false;
          this.isStun = 0;
          this.undead = true;
          if (this.homing != 0)
          {
            this.isturning = false;
            this.timer = 50000f;
            this.ch = 2;
            if (this.random.Next(1, 100) < 51)
              this.ch = 3;
            this.speed = (float) ((double) this.scale * ((double) boarDupe.acc / 1000.0) * (double) this.charge * 1.2000000476837158);
            this.scaleSpeed = this.charge;
          }
          else if (this.random.Next(0, 200) < 130)
          {
            this.timer = (float) this.random.Next(250, 800);
            this.turn = 0.0f;
            if (this.random.Next(1, 1000) < 90)
              this.turn = (float) this.random.Next(-20, 20) / 1000f;
            this.speed = this.scale * (boarDupe.acc / 1000f) * this.nightSpeed;
            this.isturning = false;
            this.ch = this.defaultClip;
          }
          else
          {
            this.isturning = false;
            this.timer = (float) this.random.Next(120, 280);
            this.speed = 0.0f;
            this.turn = 0.0f;
            this.ch = 5;
          }
          this.setClips(this.ch);
        }
      }
      else
      {
        if (this.clip1 >= 10)
        {
          if (!this.undead)
          {
            this.tween = 1f;
            this.move = 0;
            return;
          }
          this.death = false;
          this.isStun = 0;
          if ((double) this.health > 100.0)
            this.health -= 50f;
          this.isturning = false;
          this.timer = (float) this.random.Next(120, 280);
          this.speed = 0.0f;
          this.turn = 0.0f;
          this.ch = 5;
          this.setClips(this.ch);
        }
        if (this.isturning)
        {
          if (this.random.Next(0, 200) < 160)
          {
            this.isturning = false;
            this.timer = (float) this.random.Next(240, 530);
            this.turn = (float) this.random.Next(-7, 7) / 1000f;
            this.speed = this.scale * (boarDupe.acc / 1000f) * this.nightSpeed;
          }
          else
          {
            this.isturning = false;
            this.timer = (float) this.random.Next(120, 280);
            this.speed = 0.0f;
            this.turn = 0.0f;
            this.ch = 5;
          }
          this.setClips(this.ch);
        }
        else
        {
          if (this.random.Next(0, 200) < 130)
          {
            this.timer = (float) this.random.Next(250, 800);
            this.turn = (float) this.random.Next(-7, 7) / 1000f;
            if (this.random.Next(1, 1000) < 90)
              this.turn = (float) this.random.Next(-20, 20) / 1000f;
            this.speed = this.scale * (boarDupe.acc / 1000f) * this.nightSpeed;
            this.isturning = true;
            this.ch = this.defaultClip;
          }
          else
          {
            this.isturning = false;
            this.timer = (float) this.random.Next(120, 280);
            this.speed = 0.0f;
            this.turn = 0.0f;
            this.ch = 5;
          }
          this.setClips(this.ch);
        }
      }
    }

    private static void GetHeightFast(ref float[,] heights, Vector2 position, out float height)
    {
      int num1 = (int) ((double) position.X / (double) boarDupe.unit);
      int num2 = (int) ((double) position.Y / (double) boarDupe.unit);
      int index1 = (int) MathHelper.Clamp(position.X / boarDupe.unit, 0.0f, (float) (boarDupe.bitmap - 2));
      int index2 = (int) MathHelper.Clamp(position.Y / boarDupe.unit, 0.0f, (float) (boarDupe.bitmap - 2));
      float num3 = position.X % boarDupe.unit / boarDupe.unit;
      float num4 = position.Y % boarDupe.unit / boarDupe.unit;
      float num5 = (float) ((1.0 - (double) num3) * (double) heights[index1, index2] + (double) num3 * (double) heights[index1 + 1, index2]);
      float num6 = (float) ((1.0 - (double) num3) * (double) heights[index1, index2 + 1] + (double) num3 * (double) heights[index1 + 1, index2 + 1]);
      height = (float) ((1.0 - (double) num4) * (double) num5 + (double) num4 * (double) num6);
    }
  }
}
