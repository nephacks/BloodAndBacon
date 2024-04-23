// Decompiled with JetBrains decompiler
// Type: Blood.ropeDupe
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

#nullable disable
namespace Blood
{
  internal class ropeDupe
  {
    public static int bitmap;
    public static float unit;
    public float rockScale;
    public Matrix[] tranforms;
    public float dt;
    public float avg;
    public int start;
    public int div = 20;
    private float lengthDiv;
    private Vector3 player1;
    private Vector3 player2;
    public float[] pX;
    public float[] pY;
    public float[] pZ;
    public float[] oX;
    public float[] oY;
    public float[] oZ;
    public float[] aX;
    public float[] aY;
    public float[] aZ;
    private float[] grav;
    private float[] fric;
    private float scaler;
    public bool chainBump;
    private Matrix myRot;
    private Vector3 mypos;
    private Matrix Transform;
    private Random random;

    public ropeDupe(int num)
    {
      this.myRot = Matrix.CreateFromYawPitchRoll(1.57f, 0.0f, 0.0f);
      this.scaler = 2f;
      this.tranforms = new Matrix[num];
      this.div = num;
    }

    public void initialize(Vector3 lander)
    {
      this.random = new Random();
      this.lengthDiv = 6.8f;
      this.dt = 0.3f;
      this.avg = 0.8f;
      this.start = 0;
      this.pX = new float[this.div];
      this.pY = new float[this.div];
      this.pZ = new float[this.div];
      this.oX = new float[this.div];
      this.oY = new float[this.div];
      this.oZ = new float[this.div];
      this.aX = new float[this.div];
      this.aY = new float[this.div];
      this.aZ = new float[this.div];
      this.fric = new float[this.div];
      this.grav = new float[this.div];
      float num = 0.015f;
      for (int index = 0; index < this.div; ++index)
      {
        this.pX[index] = lander.X;
        this.pY[index] = lander.Y - 6.8f * (float) index;
        this.pZ[index] = lander.Z;
        this.oX[index] = lander.X;
        this.oY[index] = lander.Y - 6.8f * (float) index;
        this.oZ[index] = lander.Z;
        this.aX[index] = 0.0f;
        this.aY[index] = 0.0f;
        this.aZ[index] = 0.0f;
        this.fric[index] = 0.999f;
        this.grav[index] = -num;
        num *= 0.99f;
      }
    }

    public void Update(
      Vector3 pos,
      Vector3 pos2,
      Matrix orient,
      Vector3 vel,
      ref float[,] heights)
    {
      this.player1 = pos;
      this.player2 = pos2;
      this.chainBump = false;
      this.calcGround(ref heights);
      for (int index = 0; index < 3; ++index)
      {
        this.calcVelocity();
        this.calcSprings();
        this.calcSprings();
      }
      this.myRot = Matrix.CreateRotationY(-1.57f) * orient;
      this.mypos = new Vector3(this.pX[this.start], this.pY[this.start], this.pZ[this.start]);
      this.Transform = this.myRot * (Matrix.CreateScale(this.scaler) * Matrix.CreateTranslation(this.mypos));
      this.tranforms[this.start] = this.Transform;
      float radians = 0.0f;
      for (int index = 1; index < this.div; ++index)
      {
        radians += 1.57f;
        this.myRot = Matrix.CreateRotationZ(radians) * this.RotateToFace(new Vector3(this.pX[index], this.pY[index], this.pZ[index]), new Vector3(this.pX[index - 1], this.pY[index - 1], this.pZ[index - 1]));
        this.mypos = new Vector3(this.pX[index], this.pY[index], this.pZ[index]);
        this.Transform = Matrix.CreateScale(this.scaler) * this.myRot * Matrix.CreateTranslation(this.mypos);
        this.tranforms[index] = this.Transform;
      }
    }

    public void UpdateMore(
      ref List<Vector3> pos,
      Matrix orient,
      Vector3 vel,
      ref float[,] heights)
    {
      this.chainBump = false;
      this.calcGroundMax(ref pos, ref heights);
      for (int index = 0; index < 3; ++index)
      {
        this.calcVelocity();
        this.calcSprings();
        this.calcSprings();
      }
      this.myRot = Matrix.CreateRotationY(-1.57f) * orient;
      this.mypos = new Vector3(this.pX[this.start], this.pY[this.start], this.pZ[this.start]);
      this.Transform = this.myRot * (Matrix.CreateScale(this.scaler) * Matrix.CreateTranslation(this.mypos));
      this.tranforms[this.start] = this.Transform;
      float radians = 0.0f;
      for (int index = 1; index < this.div; ++index)
      {
        radians += 1.57f;
        this.myRot = Matrix.CreateRotationZ(radians) * this.RotateToFace(new Vector3(this.pX[index], this.pY[index], this.pZ[index]), new Vector3(this.pX[index - 1], this.pY[index - 1], this.pZ[index - 1]));
        this.mypos = new Vector3(this.pX[index], this.pY[index], this.pZ[index]);
        this.Transform = Matrix.CreateScale(this.scaler) * this.myRot * Matrix.CreateTranslation(this.mypos);
        this.tranforms[index] = this.Transform;
      }
    }

    public void calcVelocity()
    {
      for (int index = 1; index < this.div; ++index)
      {
        float num1 = this.pX[index];
        float num2 = this.pY[index];
        float num3 = this.pZ[index];
        this.pX[index] += (float) ((double) this.fric[index] * (double) this.pX[index] - (double) this.fric[index] * (double) this.oX[index] + (double) this.aX[index] * (double) this.dt * (double) this.dt);
        this.pY[index] += (float) ((double) this.fric[index] * (double) this.pY[index] - (double) this.fric[index] * (double) this.oY[index] + (double) this.aY[index] * (double) this.dt * (double) this.dt) + this.grav[index];
        this.pZ[index] += (float) ((double) this.fric[index] * (double) this.pZ[index] - (double) this.fric[index] * (double) this.oZ[index] + (double) this.aZ[index] * (double) this.dt * (double) this.dt);
        this.oX[index] = num1;
        this.oY[index] = num2;
        this.oZ[index] = num3;
        this.aX[index] *= 0.87f;
        this.aY[index] *= 0.87f;
        this.aZ[index] *= 0.87f;
      }
    }

    public void calcGround(ref float[,] heights)
    {
      for (int index = 1; index < this.div; ++index)
      {
        Vector3 vector3_1 = new Vector3(this.pX[index], this.pY[index], this.pZ[index]);
        float num = 1f;
        Vector3 up = Vector3.Up;
        if ((double) num > (double) this.pY[index] - 1.0)
        {
          this.pY[index] = num + 1f;
          this.fric[index] = 0.98f;
        }
        else
          this.fric[index] = 0.999f;
        if (!this.chainBump && (double) Vector3.Distance(vector3_1, this.player1) < 15.0 && index > this.start + 2)
        {
          Vector3 vector3_2 = Vector3.Normalize(vector3_1 - this.player1) * 4f;
          this.aX[index] = vector3_2.X;
          this.aY[index] = vector3_2.Y;
          this.aZ[index] = vector3_2.Z;
          this.chainBump = true;
        }
        if (!this.chainBump && (double) Vector3.Distance(vector3_1, this.player2) < 15.0 && index > this.start + 2)
        {
          Vector3 vector3_3 = Vector3.Normalize(vector3_1 - this.player2) * 4f;
          this.aX[index] = vector3_3.X;
          this.aY[index] = vector3_3.Y;
          this.aZ[index] = vector3_3.Z;
          this.chainBump = true;
        }
        if ((double) vector3_1.Z > 4803.0)
          this.pZ[index] = 4803f;
      }
    }

    public void calcGroundMax(ref List<Vector3> pos, ref float[,] heights)
    {
      for (int index1 = 1; index1 < this.div; ++index1)
      {
        Vector3 vector3_1 = new Vector3(this.pX[index1], this.pY[index1], this.pZ[index1]);
        float num = 1f;
        Vector3 up = Vector3.Up;
        if ((double) num > (double) this.pY[index1] - 1.0)
        {
          this.pY[index1] = num + 1f;
          this.fric[index1] = 0.98f;
        }
        else
          this.fric[index1] = 0.999f;
        for (int index2 = 0; index2 < pos.Count; ++index2)
        {
          if (!this.chainBump && (double) Vector3.Distance(vector3_1, pos[index2]) < 15.0 && index1 > this.start + 2)
          {
            Vector3 vector3_2 = Vector3.Normalize(vector3_1 - pos[index2]) * 4f;
            this.aX[index1] = vector3_2.X;
            this.aY[index1] = vector3_2.Y;
            this.aZ[index1] = vector3_2.Z;
            this.chainBump = true;
            break;
          }
        }
        if ((double) vector3_1.Z > 4803.0)
          this.pZ[index1] = 4803f;
      }
    }

    public void calcSprings()
    {
      for (int index = this.div - 1; index >= this.start + 1; --index)
      {
        float num1 = this.pX[index] - this.pX[index - 1];
        float num2 = this.pY[index] - this.pY[index - 1];
        float num3 = this.pZ[index] - this.pZ[index - 1];
        float num4 = Vector3.Distance(new Vector3(this.pX[index], this.pY[index], this.pZ[index]), new Vector3(this.pX[index - 1], this.pY[index - 1], this.pZ[index - 1]));
        float num5 = num4 - this.lengthDiv;
        this.pX[index] -= num1 / num4 * this.avg * num5;
        this.pY[index] -= num2 / num4 * this.avg * num5;
        this.pZ[index] -= num3 / num4 * this.avg * num5;
        if (index > this.start + 1)
        {
          this.pX[index - 1] += num1 / num4 * this.avg * num5;
          this.pY[index - 1] += num2 / num4 * this.avg * num5;
          this.pZ[index - 1] += num3 / num4 * this.avg * num5;
        }
      }
    }

    public Matrix RotateToFace(Vector3 O, Vector3 P)
    {
      Vector3 vector3_1 = Vector3.Cross(O, P);
      Vector3 vector2 = O - P;
      Vector3 result1 = Vector3.Cross(vector3_1, vector2);
      Vector3.Normalize(ref result1, out result1);
      Vector3 result2 = Vector3.Cross(result1, vector3_1);
      Vector3.Normalize(ref result2, out result2);
      Vector3 vector3_2 = Vector3.Cross(result2, result1);
      return new Matrix(result1.X, result1.Y, result1.Z, 0.0f, vector3_2.X, vector3_2.Y, vector3_2.Z, 0.0f, result2.X, result2.Y, result2.Z, 0.0f, 0.0f, 0.0f, 0.0f, 1f);
    }

    private static void GetHeight(
      ref float[,] heights,
      Vector3 position,
      out float height,
      out Vector3 normal)
    {
      int index1 = (int) MathHelper.Clamp(position.X / ropeDupe.unit, 0.0f, (float) (ropeDupe.bitmap - 2));
      int index2 = (int) MathHelper.Clamp(position.Z / ropeDupe.unit, 0.0f, (float) (ropeDupe.bitmap - 2));
      float num1 = position.X % ropeDupe.unit / ropeDupe.unit;
      float num2 = position.Z % ropeDupe.unit / ropeDupe.unit;
      float num3 = (float) ((1.0 - (double) num1) * (double) heights[index1, index2] + (double) num1 * (double) heights[index1 + 1, index2]);
      float num4 = (float) ((1.0 - (double) num1) * (double) heights[index1, index2 + 1] + (double) num1 * (double) heights[index1 + 1, index2 + 1]);
      height = (float) ((1.0 - (double) num2) * (double) num3 + (double) num2 * (double) num4);
      normal = Vector3.Normalize(new Vector3(-heights[index1 + 1, index2] + heights[index1, index2], 30f, -heights[index1, index2 + 1] + heights[index1, index2]));
    }
  }
}
