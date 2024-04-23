// Decompiled with JetBrains decompiler
// Type: Blood.astroDupe
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

#nullable disable
namespace Blood
{
  public class astroDupe
  {
    public static Vector3 farmLocation = new Vector3(0.0f, 5f, 0.0f);
    public static Vector3 constantRoverPosition = Vector3.Zero;
    public static Vector4 facility = Vector4.Zero;
    public static float acc = 650f;
    public static List<int> sics;
    public astroDupe.emotion emo;
    public astroDupe.where loc;
    public bool isturning;
    public bool holdlastframe;
    private bool holdlastclip;
    public bool flipinspace;
    private int nextact;
    public Vector3 destination = Vector3.Zero;
    public Vector3 normal = Vector3.Zero;
    public Vector3 posOffset;
    public float rotOffset;
    public int variant;
    public float flipTimer;
    public Matrix flipRot = Matrix.Identity;
    public Vector3 flipDir = Vector3.One;
    public Vector3 flipVeloc = Vector3.One;
    public float flipSpeed;
    public bool employed;
    public List<Vector2> botPath = new List<Vector2>();
    public float botStart;
    public int isShocked;
    public int bodytype;
    public int headType;
    public int packType;
    public int splatIndex;
    public int move;
    public float myRot;
    public float myRotHeld;
    public float angleX;
    public float angleZ;
    public float scale;
    public float bluScale;
    public Vector3 mypos;
    public int frame1 = 1;
    public int frame2 = 1;
    public int temp1;
    public int temp2;
    public int clip1;
    public int clip2;
    public float tween;
    public float tweenspeed = 0.05f;
    public int stunLength = 150;
    public float speed;
    public float turn;
    public float timer;
    public float startHealth = 5f;
    public float health = 5f;
    public Matrix transform;
    public int blood;
    public int seed;
    private float groundHeight;
    public int age;
    public int tint;
    public int oldtint;
    public Random random;
    public int immunity;
    public ScreenManager sc;
    public float scaleSpeed = 1f;
    public int walkClip;
    public int waitClip = 1;
    public int flipClip = 2;
    public int saluteClip = 3;
    public int hammerClip = 4;
    public int dieClip = 5;
    public int climbinClip = 6;
    public int runClip = 7;
    public int climboutClip = 8;
    public int lookClip = 9;
    public int waveClip = 10;
    public int int_0 = 11;
    public int int_1 = 12;
    public int turnfastClip = 50;
    public int walkawayfromtruckClip = 45;
    private int[] terrainCh = new int[0];
    private int[] strandedCh = new int[0];
    private int[] savedCh = new int[0];

    public astroDupe(
      Vector3 startpos,
      int myMove,
      int seed,
      int age,
      ScreenManager sc,
      astroDupe.emotion emo,
      float myrot)
    {
      this.terrainCh = new int[4]
      {
        this.walkClip,
        this.waitClip,
        this.hammerClip,
        this.lookClip
      };
      this.strandedCh = new int[4]
      {
        this.waitClip,
        this.lookClip,
        this.waveClip,
        this.int_0
      };
      this.savedCh = new int[1]{ this.int_1 };
      this.sc = sc;
      this.emo = emo;
      this.loc = astroDupe.where.outofTruck;
      this.random = new Random(seed);
      this.botStart = 0.0f;
      this.bodytype = 1;
      if (this.random.Next(1, 500) < 200)
        this.bodytype = 2;
      this.headType = 1;
      this.packType = this.random.Next(1, 3);
      this.blood = 0;
      this.mypos = startpos;
      this.move = myMove;
      this.tween = 1f;
      this.age = age;
      this.seed = seed;
      this.tint = this.random.Next(0, 7);
      this.scale = 1f;
      this.startHealth = this.health;
      this.myRot = myrot;
      this.speed = this.scale * (astroDupe.acc / 1000f);
      this.turn = (float) this.random.Next(-20, 20) / 1000f;
      this.timer = (float) this.random.Next(20, 300);
      this.clip1 = 0;
      this.clip2 = 0;
      this.timer = 300f;
      this.temp1 = this.random.Next(20, 30000);
      this.temp2 = this.temp1;
    }

    public astroDupe(
      Vector3 startpos,
      int myMove,
      int seed,
      int age,
      ScreenManager sc,
      astroDupe.emotion emo)
    {
      this.terrainCh = new int[4]
      {
        this.walkClip,
        this.waitClip,
        this.hammerClip,
        this.lookClip
      };
      this.strandedCh = new int[4]
      {
        this.waitClip,
        this.lookClip,
        this.waveClip,
        this.int_0
      };
      this.savedCh = new int[1]{ this.int_1 };
      this.sc = sc;
      this.emo = emo;
      this.loc = astroDupe.where.outofTruck;
      this.random = new Random(seed);
      this.botStart = 0.0f;
      this.bodytype = 1;
      if (this.random.Next(1, 500) < 200)
        this.bodytype = 2;
      this.headType = 1;
      if (this.emo == astroDupe.emotion.stranded)
        this.headType = 2;
      if (this.emo == astroDupe.emotion.stranded2)
      {
        this.headType = 1;
        this.emo = astroDupe.emotion.stranded;
      }
      this.packType = this.random.Next(1, 3);
      this.blood = 0;
      this.mypos = startpos;
      this.move = myMove;
      this.tween = 1f;
      this.age = age;
      this.seed = seed;
      this.tint = this.random.Next(0, 7);
      this.scale = 1f;
      this.startHealth = this.health;
      this.myRot = (float) this.random.Next(-800, 800) / 100f;
      this.speed = this.scale * (astroDupe.acc / 1000f);
      this.turn = (float) this.random.Next(-20, 20) / 1000f;
      this.timer = (float) this.random.Next(20, 300);
      this.clip1 = 0;
      this.clip2 = 0;
      this.timer = 300f;
      this.temp1 = this.random.Next(20, 30000);
      this.temp2 = this.temp1;
    }

    public void updateFacilityAI(ref int[,] heights, ref Vector3[,] normalData)
    {
      if (this.botPath.Count <= 0)
        return;
      if (this.move == 2)
      {
        ++this.temp1;
        ++this.temp2;
        this.frame1 = this.temp1 % astroDupe.sics[this.clip1 * 2] + astroDupe.sics[this.clip1 * 2 + 1];
        this.frame2 = this.temp2 % astroDupe.sics[this.clip2 * 2] + astroDupe.sics[this.clip2 * 2 + 1];
        this.tween += 0.05f;
        this.GetHeight2(ref heights, this.mypos, out this.groundHeight);
        this.mypos.Y = this.groundHeight;
        float num1 = 1f / (float) ((this.botPath.Count - 1) * 400);
        if ((double) this.speed < 2.0)
          this.botStart += num1 * (this.speed * 4f);
        else
          this.botStart += num1 * (this.speed * 5f);
        if ((double) this.botStart < 1.0)
        {
          float num2 = (float) (this.botPath.Count - 1) * this.botStart;
          int index1 = (int) num2;
          int index2 = index1 + 1;
          float num3 = MathHelper.Lerp(this.botPath[index1].X, this.botPath[index2].X, num2 - (float) index1);
          float num4 = MathHelper.Lerp(this.botPath[index1].Y, this.botPath[index2].Y, num2 - (float) index1);
          float x1 = num3 / 4f + Facility.offset.X;
          float y1 = num4 / 4f + Facility.offset.Z;
          float y2 = x1 - this.mypos.X;
          float x2 = y1 - this.mypos.Z;
          if ((double) x1 - (double) this.mypos.X > 0.20000000298023224)
            x2 += 15f;
          if ((double) x1 - (double) this.mypos.X < -0.20000000298023224)
            x2 -= 15f;
          if ((double) y1 - (double) this.mypos.Z > 0.20000000298023224)
            y2 -= 15f;
          if ((double) y1 - (double) this.mypos.Z < -0.20000000298023224)
            y2 += 15f;
          float num5 = (float) Math.Atan2((double) y2, (double) x2) + 0.0f;
          float max = 0.04f;
          if ((double) this.speed == 3.0)
            max = 0.13f;
          this.myRot = astroDupe.WrapAngle(this.myRot + MathHelper.Clamp(astroDupe.WrapAngle(num5 - this.myRot), -max, max));
          float num6 = MathHelper.Clamp(Vector2.Distance(new Vector2(x1, y1), new Vector2(this.mypos.X, this.mypos.Z)) / 50f, 0.5f, 1f);
          if ((double) num6 > 200.0)
            num6 = 1.2f;
          this.mypos += Vector3.Transform(new Vector3(0.0f, 0.0f, 1f) * this.speed * num6, Matrix.CreateRotationY(this.myRot));
        }
        else
        {
          this.botStart = 0.0f;
          this.move = 3;
        }
      }
      if (this.move != 5)
        return;
      ++this.temp1;
      ++this.temp2;
      this.frame1 = this.temp1 % astroDupe.sics[this.clip1 * 2] + astroDupe.sics[this.clip1 * 2 + 1];
      this.frame2 = this.temp2 % astroDupe.sics[this.clip2 * 2] + astroDupe.sics[this.clip2 * 2 + 1];
    }

    public void UpdateNormally(ref int[,] heightData, ref Vector3[,] normalData)
    {
      ++this.age;
      if (this.move != 1)
        return;
      if (this.clip1 != 2)
      {
        if (this.loc != astroDupe.where.enteringTruck)
        {
          this.mypos.X += (float) -Math.Cos((double) this.myRot + 1.5707999467849731) * this.speed;
          this.mypos.Z += (float) Math.Sin((double) this.myRot + 1.5707999467849731) * this.speed;
          this.GetHeight(ref heightData, this.mypos, out this.groundHeight);
          this.mypos.Y = this.groundHeight;
          this.myRot += this.turn;
          --this.timer;
          this.tween += this.tweenspeed;
          if ((double) this.tween >= 0.9)
            this.holdlastclip = false;
          if ((double) this.timer <= 0.0)
          {
            if (this.loc == astroDupe.where.outofTruck)
              this.terrainChooseClip(0);
            if (this.loc == astroDupe.where.leavingTruck)
            {
              this.loc = astroDupe.where.outofTruck;
              this.holdlastclip = true;
              this.terrainChooseClip(this.turnfastClip);
            }
          }
        }
        if (this.loc == astroDupe.where.enteringTruck)
        {
          this.tween += 0.05f;
          float x1 = this.destination.X;
          float z = this.destination.Z;
          float y = x1 - this.mypos.X;
          float x2 = z - this.mypos.Z;
          if ((double) x1 - (double) this.mypos.X > 0.20000000298023224)
            x2 += 15f;
          if ((double) x1 - (double) this.mypos.X < -0.20000000298023224)
            x2 -= 15f;
          if ((double) z - (double) this.mypos.Z > 0.20000000298023224)
            y -= 15f;
          if ((double) z - (double) this.mypos.Z < -0.20000000298023224)
            y += 15f;
          this.myRot = astroDupe.WrapAngle(this.myRot + MathHelper.Clamp(astroDupe.WrapAngle((float) Math.Atan2((double) y, (double) x2) + 0.0f - this.myRot), -0.04f, 0.04f));
          float num1 = Vector2.Distance(new Vector2(x1, z), new Vector2(this.mypos.X, this.mypos.Z));
          float num2 = MathHelper.Clamp(num1 / 200f, 0.8f, 1f);
          if ((double) num1 > 40.0)
          {
            this.mypos += Vector3.Transform(new Vector3(0.0f, 0.0f, 1f) * this.speed * num2, Matrix.CreateRotationY(this.myRot));
            this.GetHeight(ref heightData, this.mypos, out this.groundHeight);
            this.mypos.Y = this.groundHeight;
          }
          if ((double) num1 <= 40.0)
          {
            this.isturning = false;
            this.speed = 0.0f;
            this.turn = 0.0f;
            this.timer = 234f;
            this.temp1 = 0;
            this.temp2 = 0;
            this.holdlastframe = true;
            this.loc = astroDupe.where.inTruck;
            this.tweenspeed = 0.1f;
            this.switchClip(this.climbinClip);
          }
        }
      }
      else if (this.clip1 == 2)
      {
        this.flipTimer += 0.03f;
        this.mypos += this.flipVeloc;
        this.tween += 0.05f;
        this.GetHeight(ref heightData, this.mypos, out this.groundHeight);
        if ((double) this.mypos.Y < (double) this.groundHeight)
        {
          this.flipVeloc.Y += 0.5f;
          this.mypos.Y = this.groundHeight;
        }
      }
      if (this.holdlastframe && (double) this.timer <= 0.0)
        return;
      ++this.temp1;
      if (!this.holdlastclip)
        ++this.temp2;
      this.frame1 = this.temp1 % astroDupe.sics[this.clip1 * 2] + astroDupe.sics[this.clip1 * 2 + 1];
      this.frame2 = this.temp2 % astroDupe.sics[this.clip2 * 2] + astroDupe.sics[this.clip2 * 2 + 1];
    }

    public void terrainChooseClip(int myact)
    {
      if (!this.flipinspace)
      {
        if (this.isturning)
        {
          this.isturning = false;
          this.timer = (float) this.random.Next(240, 530);
          this.turn = (float) this.random.Next(-7, 7) / 1000f;
          this.speed = this.scale * (astroDupe.acc / 1000f);
        }
        else
        {
          int num = this.terrainCh[this.random.Next(0, this.terrainCh.Length)];
          if (this.emo == astroDupe.emotion.stranded)
            num = this.strandedCh[this.random.Next(0, this.strandedCh.Length)];
          if (myact != 0)
            num = myact;
          if (this.nextact != 0)
          {
            num = this.nextact;
            this.nextact = 0;
          }
          if (num == this.walkClip)
          {
            this.timer = (float) this.random.Next(250, 800);
            this.turn = (float) this.random.Next(-9, 9) / 1000f;
            if (this.random.Next(1, 1000) < 90)
              this.turn = (float) this.random.Next(-20, 20) / 1000f;
            this.speed = this.scale * (astroDupe.acc / 1000f);
            this.tweenspeed = 0.05f;
            this.switchClip(this.walkClip);
          }
          if (num == this.walkawayfromtruckClip)
          {
            this.timer = (float) this.random.Next(300, 440);
            this.turn = 0.0f;
            this.speed = this.scale * (astroDupe.acc / 1000f);
            this.isturning = false;
            this.tweenspeed = 0.05f;
            this.holdlastclip = true;
            this.loc = astroDupe.where.outofTruck;
            this.switchClip(this.walkClip);
            if (this.emo == astroDupe.emotion.stranded)
            {
              if ((double) Vector3.Distance(this.mypos, astroDupe.farmLocation) < 3000.0)
              {
                this.emo = astroDupe.emotion.justsaved;
                Overlay.manbouy = Vector3.Zero;
                this.nextact = this.int_1;
              }
              else
                Overlay.manbouy = this.mypos;
            }
          }
          if (num == this.turnfastClip)
          {
            this.timer = 40f;
            this.turn = 0.08f;
            if (this.random.Next(1, 1000) < 500)
              this.turn = -0.08f;
            this.speed = 0.4f;
            this.holdlastclip = true;
            this.isturning = false;
            this.tweenspeed = 0.1f;
            this.nextact = this.walkawayfromtruckClip;
            this.switchClip(this.walkClip);
          }
          if (num == this.waitClip)
          {
            this.isturning = false;
            this.holdlastclip = true;
            this.timer = (float) this.random.Next(80, 280);
            this.tweenspeed = 0.05f;
            this.speed = 0.0f;
            this.turn = 0.0f;
            this.switchClip(this.waitClip);
          }
          if (num == this.hammerClip)
          {
            this.isturning = false;
            this.holdlastclip = true;
            this.timer = (float) this.random.Next(130, 360);
            this.tweenspeed = 0.05f;
            this.speed = 0.0f;
            this.turn = 0.0f;
            this.switchClip(this.hammerClip);
          }
          if (num == this.lookClip)
          {
            this.temp2 = 0;
            this.holdlastclip = true;
            this.isturning = false;
            this.tweenspeed = 0.05f;
            this.timer = 200f;
            this.speed = 0.0f;
            this.turn = 0.0f;
            this.switchClip(this.lookClip);
          }
          if (num == this.waveClip)
          {
            this.temp2 = 0;
            this.holdlastclip = true;
            this.isturning = false;
            this.timer = (float) this.random.Next(135, 290);
            this.tweenspeed = 0.05f;
            this.speed = 0.0f;
            this.turn = 0.0f;
            this.switchClip(this.waveClip);
          }
          if (num == this.int_0)
          {
            this.temp2 = 0;
            this.holdlastclip = false;
            this.isturning = false;
            this.timer = 490f;
            this.tweenspeed = 0.05f;
            this.speed = 0.0f;
            this.turn = 0.0f;
            this.switchClip(this.int_0);
          }
          if (num == this.int_1)
          {
            this.temp2 = 0;
            this.holdlastclip = false;
            this.isturning = false;
            this.timer = 755f;
            this.tweenspeed = 0.05f;
            this.speed = 0.0f;
            this.turn = 0.0f;
            this.switchClip(this.int_1);
          }
        }
      }
      if (!this.flipinspace)
        return;
      this.switchClip(this.flipClip);
    }

    public void switchClip(int ch)
    {
      int frame2 = this.frame2;
      this.frame2 = this.frame1;
      this.frame1 = frame2;
      int temp2 = this.temp2;
      this.temp2 = this.temp1;
      this.temp1 = temp2;
      this.tween = 0.0f;
      this.clip2 = this.clip1;
      this.clip1 = ch;
    }

    public void leaveTruck()
    {
      this.temp2 = 0;
      this.timer = 186f;
      this.turn = 0.0f;
      this.speed = 0.0f;
      this.tweenspeed = 0.1f;
      this.isturning = false;
      this.loc = astroDupe.where.leavingTruck;
      this.holdlastframe = false;
      this.holdlastclip = true;
      this.switchClip(this.climboutClip);
    }

    public void makeSalute(bool commandtoenter)
    {
      this.isturning = false;
      this.speed = 0.0f;
      this.turn = 0.0f;
      this.timer = 80f;
      this.temp2 = 0;
      if (!commandtoenter)
      {
        this.tweenspeed = 0.05f;
        this.switchClip(this.saluteClip);
      }
      if (!commandtoenter)
        return;
      this.timer = 235f;
      this.turn = 0.0f;
      this.speed = 3f;
      this.isturning = false;
      if (this.emo == astroDupe.emotion.underground)
      {
        this.speed = 3f;
        this.temp2 = this.random.Next(10, 300);
        this.switchClip(this.runClip);
      }
      else
      {
        if (this.emo == astroDupe.emotion.stranded)
        {
          Overlay.manbouy = Vector3.Zero;
          this.loc = astroDupe.where.enteringTruck;
        }
        this.loc = astroDupe.where.enteringTruck;
        this.temp2 = this.random.Next(10, 300);
        this.switchClip(this.runClip);
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

    private void GetHeight(ref int[,] heightData, Vector3 position, out float height)
    {
      int gridScale = this.sc.gridScale;
      int bitmap = this.sc.bitmap;
      int num1 = (bitmap - 1) * gridScale;
      position.X = (float) ((double) position.X % (double) num1 + 1.5 * (double) num1) % (float) num1;
      position.Z = (float) ((double) position.Z % (double) num1 + 1.5 * (double) num1) % (float) num1;
      Vector3 vector3 = position;
      int index1 = (int) vector3.X / gridScale;
      int index2 = (int) vector3.Z / gridScale;
      float num2 = vector3.X % (float) gridScale / (float) gridScale;
      float num3 = vector3.Z % (float) gridScale / (float) gridScale;
      int index3 = index1 + 1;
      int index4 = index2 + 1;
      if (index3 > bitmap - 2)
        index3 = 0;
      if (index4 > bitmap - 2)
        index4 = 0;
      float num4 = (float) ((1.0 - (double) num2) * (double) heightData[index1, index2] + (double) num2 * (double) heightData[index3, index2]);
      float num5 = (float) ((1.0 - (double) num2) * (double) heightData[index1, index4] + (double) num2 * (double) heightData[index3, index4]);
      height = (float) ((1.0 - (double) num3) * (double) num4 + (double) num3 * (double) num5);
    }

    private void GetHeightNormal(
      ref int[,] heightData,
      ref Vector3[,] normals,
      Vector3 position,
      out float height,
      out Vector3 normal)
    {
      int gridScale = this.sc.gridScale;
      int bitmap = this.sc.bitmap;
      int num1 = (bitmap - 1) * gridScale;
      position.X = (float) ((double) position.X % (double) num1 + 1.5 * (double) num1) % (float) num1;
      position.Z = (float) ((double) position.Z % (double) num1 + 1.5 * (double) num1) % (float) num1;
      Vector3 vector3_1 = position;
      int index1 = (int) vector3_1.X / gridScale;
      int index2 = (int) vector3_1.Z / gridScale;
      float amount1 = vector3_1.X % (float) gridScale / (float) gridScale;
      float amount2 = vector3_1.Z % (float) gridScale / (float) gridScale;
      int index3 = index1 + 1;
      int index4 = index2 + 1;
      if (index3 > bitmap - 2)
        index3 = 0;
      if (index4 > bitmap - 2)
        index4 = 0;
      float num2 = MathHelper.Lerp((float) heightData[index1, index2], (float) heightData[index3, index2], amount1);
      float num3 = MathHelper.Lerp((float) heightData[index1, index4], (float) heightData[index3, index4], amount1);
      height = MathHelper.Lerp(num2, num3, amount2);
      Vector3 vector3_2 = Vector3.Lerp(normals[index1, index2], normals[index3, index2], amount1);
      Vector3 vector3_3 = Vector3.Lerp(normals[index1, index4], normals[index3, index4], amount1);
      normal = Vector3.Lerp(vector3_2, vector3_3, amount2);
      if ((double) normal.LengthSquared() <= 0.0)
        return;
      normal = Vector3.Normalize(normal);
    }

    public void GetHeight2(ref int[,] heightData, Vector3 position, out float height)
    {
      float y = position.Y;
      position -= Facility.offset;
      position *= 4f;
      float num1 = 100f;
      int index1 = (int) MathHelper.Clamp(position.X / num1, 0.0f, 175f);
      int index2 = (int) MathHelper.Clamp(position.Z / num1, 0.0f, 175f);
      float amount1 = position.X % num1 / num1;
      float amount2 = position.Z % num1 / num1;
      int index3 = index1 + 1;
      int index4 = index2 + 1;
      float num2 = MathHelper.Lerp((float) heightData[index1, index2], (float) heightData[index3, index2], amount1);
      float num3 = MathHelper.Lerp((float) heightData[index1, index4], (float) heightData[index3, index4], amount1);
      height = MathHelper.Lerp(num2, num3, amount2);
      if ((double) height >= (double) Facility.offset.Y - 500.0)
        return;
      height = y;
    }

    public enum emotion
    {
      flipping,
      hungry,
      thirsty,
      stranded,
      stranded2,
      safe,
      working,
      underground,
      sweeping,
      digging,
      angry,
      trucking,
      justsaved,
      scaredintruck,
    }

    public enum where
    {
      outofTruck,
      inTruck,
      enteringTruck,
      leavingTruck,
      inspace,
    }
  }
}
