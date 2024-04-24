using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;

#pragma warning disable CS0169
#nullable disable
namespace Blood
{
  public class enemyDupe
  {
    private float targetFloor;
    public static int isChasing = -1;
    public static int chaseCount = 0;
    public Vector3 enemyColor;
    public bool enemyisTurning;
    public bool enemyBlocked;
    public int blockedCount;
    public int blockedTimer;
    public float[] skelPath;
    public Vector3[] skelPath3;
    public SoundEffectInstance enemySound;
    public AudioListener audiolistener;
    public AudioEmitter audioemitter;
    public Vector2 destination;
    public Vector2 myhome;
    public Vector3 skelPos1;
    public Vector3 skelPos2;
    public Vector3 skelPos;
    public Vector3 enemypos;
    public Matrix skelRot = Matrix.CreateRotationY(0.0f);
    public int skelIndex;
    public int enemyCounter;
    public float skelInc;
    public float skelStep;
    public float skelOrigRate = 700f;
    public float skelFastRate = 1500f;
    public float skelRate = 700f;
    public int attackAgain = 1;
    public int attackAgainOrig = 1;
    public float skelNewStep;
    public int skelStepTimer;
    private int ch;
    public static int homingCount = 0;
    public static int homingCount2 = 0;
    public float hoff;
    public Vector3 veloc;
    public float gravity = -0.2f;
    public int floorHit;
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
    public bool homing;
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
    public float startHealth = 100f;
    public float health = 100f;
    public Matrix transform;
    public int blood;
    public static List<int> sics;
    public int seed;
    private float groundHeight;
    public int age;
    public int localhitCount;
    public int remotehitCount;
    public float tint;
    public float oldtint;
    public float dying;
    public Random random;
    public Random randomDeath;
    public Random randomHead;
    public Random randomPartsFly;
    public int immunity;
    public int assexplode;
    public static ScreenManager sc;
    public float nightSpeed = 1f;
    public float scaleSpeed = 1f;
    public int defaultClip = 1;

    public enemyDupe(
      int group,
      int variant,
      Vector3 startpos,
      int myMove,
      int seed,
      int age,
      ScreenManager sc,
      int h)
    {
      this.audioemitter = new AudioEmitter();
      this.audiolistener = new AudioListener();
      this.audioemitter.Position = new Vector3(0.0f, 0.0f, 0.0f);
      this.audiolistener.Position = new Vector3(9000f, 0.0f, 9000f);
      this.health = (float) h;
      this.enemypos = startpos;
      this.skelPos = startpos;
      this.nozombies = false;
      enemyDupe.sc = sc;
      enemyDupe.homingCount = 0;
      enemyDupe.homingCount2 = 0;
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
      this.random = new Random();
      this.defaultClip = this.random.Next(1, 3);
      this.myRot = (float) this.random.Next(-800, 800) / 100f;
      this.turn = (float) this.random.Next(-20, 20) / 1000f;
      this.timer = 300f;
      this.clip1 = this.defaultClip;
      this.clip2 = this.defaultClip;
      this.temp1 = this.random.Next(20, 300);
      this.temp2 = this.random.Next(20, 300);
    }

    public void UpdateNormal(ref float[,] heights)
    {
      ++this.age;
      this.hoff = MathHelper.Clamp(this.scale * 50f, 10f, 62f);
      this.targetFloor = this.enemypos.Y + this.scale * 30f;
      --this.timer;
      ++this.temp1;
      ++this.temp2;
      this.frame1 = this.temp1 % enemyDupe.sics[this.clip1 * 2] + enemyDupe.sics[this.clip1 * 2 + 1];
      this.frame2 = this.temp2 % enemyDupe.sics[this.clip2 * 2] + enemyDupe.sics[this.clip2 * 2 + 1];
      this.tween += 0.125f;
      if ((double) this.timer > 0.0)
        return;
      int ch = this.defaultClip;
      int tt = 0;
      int num = this.random.Next(1, 100);
      if (num < 20)
      {
        ch = this.random.Next(3, 5);
        tt = this.random.Next(70, 120);
      }
      if (num >= 20)
      {
        ch = this.random.Next(0, 3);
        tt = 0;
      }
      this.defaultClip = 1;
      this.makeCalc(ch, (float) tt);
    }

    public void UpdateDeath(ref float[,] heights)
    {
      ++this.age;
      --this.timer;
      this.tween += 0.1f;
      if ((double) this.timer > 0.0)
      {
        this.enemypos += this.veloc;
        this.veloc.Y += this.gravity;
        if ((double) this.veloc.Y < -4.0)
          this.veloc.Y = -4f;
        if ((double) this.enemypos.Y + (double) this.hoff < (double) this.targetFloor)
        {
          if (this.floorHit < 2)
          {
            ++this.floorHit;
            this.veloc.Y = (float) (-(double) this.veloc.Y * 0.699999988079071);
            this.enemypos.Y = this.targetFloor + 1f - this.hoff;
          }
          else
            this.enemypos.Y = this.targetFloor - this.hoff;
        }
      }
      if ((double) this.timer <= 120.0)
      {
        this.dying += 0.007f;
        if ((double) this.dying > 0.99000000953674316)
          this.dying = 0.99f;
      }
      if ((double) this.timer <= 0.0)
      {
        if ((double) this.timer < -10.0)
          this.enemypos.Y -= 0.07f;
        if ((double) this.enemypos.Y >= (double) this.targetFloor - 80.0)
          return;
        this.move = 0;
      }
      else
      {
        ++this.temp1;
        ++this.temp2;
        this.frame1 = this.temp1 % enemyDupe.sics[this.clip1 * 2] + enemyDupe.sics[this.clip1 * 2 + 1];
        this.frame2 = this.temp2 % enemyDupe.sics[this.clip2 * 2] + enemyDupe.sics[this.clip2 * 2 + 1];
      }
    }

    public void makeCalc(int ch, float tt)
    {
      this.timer = (double) tt != 0.0 ? tt : (float) this.random.Next(210, 400);
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
      int num1 = (int) ((double) position.X / (double) enemyDupe.unit);
      int num2 = (int) ((double) position.Y / (double) enemyDupe.unit);
      int index1 = (int) MathHelper.Clamp(position.X / enemyDupe.unit, 0.0f, (float) (enemyDupe.bitmap - 2));
      int index2 = (int) MathHelper.Clamp(position.Y / enemyDupe.unit, 0.0f, (float) (enemyDupe.bitmap - 2));
      float num3 = position.X % enemyDupe.unit / enemyDupe.unit;
      float num4 = position.Y % enemyDupe.unit / enemyDupe.unit;
      float num5 = (float) ((1.0 - (double) num3) * (double) heights[index1, index2] + (double) num3 * (double) heights[index1 + 1, index2]);
      float num6 = (float) ((1.0 - (double) num3) * (double) heights[index1, index2 + 1] + (double) num3 * (double) heights[index1 + 1, index2 + 1]);
      height = (float) ((1.0 - (double) num4) * (double) num5 + (double) num4 * (double) num6);
    }
  }
}
