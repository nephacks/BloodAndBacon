// Decompiled with JetBrains decompiler
// Type: Blood.webDupe
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

#nullable disable
namespace Blood
{
  public class webDupe
  {
    public static int isChasing = -1;
    public static int chaseCount = 0;
    public Vector3 enemyColor;
    public bool enemyisTurning;
    public bool enemyBlocked;
    public float[] skelPath;
    public Vector2 destination;
    public Vector3 skelPos1;
    public Vector3 skelPos2;
    public Vector3 skelPos;
    public Vector3 enemypos;
    public Matrix skelRot = Matrix.CreateRotationY(0.0f);
    public int skelIndex;
    public int enemyCounter;
    public float skelInc;
    public float skelStep;
    public int pauseCount;
    public float skelOrigRate = 700f;
    public float skelFastRate = 1500f;
    public float skelNewStep;
    public int skelStepTimer;
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
    public Matrix myRot2;
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
    public float wait;
    public float clipchange;
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
    public int immunity;
    public int assexplode;
    public static ScreenManager sc;
    public float nightSpeed = 1f;
    public float scaleSpeed = 1f;
    public int defaultClip = 1;

    public webDupe(
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
      this.enemypos = startpos;
      this.skelPos = startpos;
      this.nozombies = noZboars;
      webDupe.sc = sc;
      webDupe.homingCount = 0;
      webDupe.homingCount2 = 0;
      this.splatIndex = 0;
      this.scale = 1f;
      this.blood = 0;
      this.mypos = startpos;
      this.move = myMove;
      this.tween = 1f;
      this.age = age;
      this.seed = seed;
      this.boarGroup = group;
      this.variant = variant;
      this.defaultClip = 1;
      this.nightSpeed = 1f;
      this.random = new Random();
      this.myRot = (float) this.random.Next(-800, 800) / 100f;
      this.speed = this.scale * (webDupe.acc / 1000f) * this.nightSpeed;
      this.turn = (float) this.random.Next(-20, 20) / 1000f;
      this.timer = 300f;
      this.clip1 = this.defaultClip;
      this.clip2 = this.defaultClip;
      this.temp1 = this.random.Next(20, 300);
      this.temp2 = this.random.Next(20, 300);
    }

    public void UpdateWeb(ref float[,] heights)
    {
      ++this.age;
      --this.wait;
      ++this.clipchange;
      if ((double) this.wait > 0.0)
        return;
      --this.timer;
      ++this.temp1;
      ++this.temp2;
      this.frame1 = this.temp1 % webDupe.sics[this.clip1 * 2] + webDupe.sics[this.clip1 * 2 + 1];
      this.frame2 = this.temp2 % webDupe.sics[this.clip2 * 2] + webDupe.sics[this.clip2 * 2 + 1];
      this.tween += 0.1f;
      if ((double) this.timer > 0.0)
        return;
      if ((double) this.clipchange > 1000.0)
      {
        this.defaultClip = this.random.Next(0, 4);
        this.clipchange = 0.0f;
      }
      this.makeCalc(this.defaultClip);
      this.wait = (float) this.random.Next(100, 450);
    }

    public void makeCalc(int ch)
    {
      this.timer = (float) this.random.Next(240, 680);
      this.speed = 0.0f;
      this.turn = 0.0f;
      this.setClips(ch);
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

    private static void GetHeightFast(ref float[,] heights, Vector2 position, out float height)
    {
      int num1 = (int) ((double) position.X / (double) webDupe.unit);
      int num2 = (int) ((double) position.Y / (double) webDupe.unit);
      int index1 = (int) MathHelper.Clamp(position.X / webDupe.unit, 0.0f, (float) (webDupe.bitmap - 2));
      int index2 = (int) MathHelper.Clamp(position.Y / webDupe.unit, 0.0f, (float) (webDupe.bitmap - 2));
      float num3 = position.X % webDupe.unit / webDupe.unit;
      float num4 = position.Y % webDupe.unit / webDupe.unit;
      float num5 = (float) ((1.0 - (double) num3) * (double) heights[index1, index2] + (double) num3 * (double) heights[index1 + 1, index2]);
      float num6 = (float) ((1.0 - (double) num3) * (double) heights[index1, index2 + 1] + (double) num3 * (double) heights[index1 + 1, index2 + 1]);
      height = (float) ((1.0 - (double) num4) * (double) num5 + (double) num4 * (double) num6);
    }
  }
}
