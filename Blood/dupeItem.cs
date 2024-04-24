﻿using Microsoft.Xna.Framework;
using System;

#pragma warning disable CS0169
#nullable disable
namespace Blood
{
  public class dupeItem
  {
    private float oldY;
    private Matrix m1;
    private Matrix m2;
    private Matrix m3;
    private Matrix m4;
    private float f1;
    private float f2;
    private Vector3 v1;
    private Vector3 v2;
    public bool itBleeds;
    public bool kickable;
    public static int bleed = 260;
    public static int bitmap;
    public static float unit;
    private Vector3 scale0;
    private Quaternion rotation0;
    private Quaternion rotation1;
    private Vector3 position0;
    public int group = 1;
    private float gravity;
    public float scale;
    public float ratio;
    public float bounce;
    private float groundHeight;
    public Matrix myRot;
    public Matrix inertRot;
    public Matrix oldRot;
    public float sloper;
    public float turnRate = 0.3f;
    public int move;
    public Vector3 mypos;
    public Vector3 oldpos;
    public Vector3 normal;
    public float scaler;
    public Vector3 velocity;
    public Matrix transform;
    public float tint;
    public int firstHit;
    public int secondhit;
    public bool localShell;
    public bool landupright;
    public int randBounce = 10;
    public int alive;
    public int kicked;
    public int gash;
    public int freq;
    public Vector3 vortex = Vector3.Zero;
    public ushort partID;
    public int hits;
    public int mult;
    public int lastKicked;
    public Vector3 dump1;
    public Vector3 dump2;
    private Quaternion qq;
    private Vector3 v;
    private float result;
    public Randoms rr;

    public dupeItem(int i) => this.rr = new Randoms(i);

    public void assignRandom(int seed) => this.rr.changeSeed(seed);

    public void init(
      int group,
      float bounce,
      float scale,
      float ratio,
      Matrix startpos,
      Vector3 veloc,
      bool localShell,
      float grav,
      int rbounce,
      float ta,
      float tb,
      bool landupright,
      bool itBleeds,
      bool kickable,
      int boarSEED,
      int mult)
    {
      this.group = group;
      this.partID = (ushort) (boarSEED * mult);
      this.mult = mult;
      this.lastKicked = 0;
      this.ratio = ratio;
      this.scale = scale;
      this.bounce = bounce;
      this.localShell = localShell;
      this.randBounce = rbounce;
      this.landupright = landupright;
      this.itBleeds = itBleeds;
      this.kickable = kickable;
      this.alive = 0;
      this.kicked = 60;
      this.move = 1;
      this.firstHit = 0;
      this.secondhit = -1;
      this.gravity = grav;
      this.gash = this.rr.Next(50, 250);
      this.freq = this.rr.Next(4, 16);
      startpos.Decompose(out this.dump1, out this.qq, out this.dump2);
      this.myRot = Matrix.CreateFromQuaternion(this.qq);
      this.turnRate = (float) this.rr.Next((int) ta, (int) tb) / 1000f;
      this.inertRot = Matrix.CreateFromAxisAngle(Vector3.Normalize(Vector3.Cross(-veloc, Vector3.Up)), this.turnRate);
      this.v = Vector3.Transform(Vector3.Up, this.myRot);
      this.result = Vector3.Dot(this.v, Vector3.Up);
      this.scaler = (float) (2.0 - (double) Math.Abs(this.result) * (2.0 - (double) ratio * 2.0)) * scale;
      this.velocity = this.move <= 0 ? Vector3.Zero : veloc;
      this.mypos = Vector3.Transform(Vector3.Zero, startpos);
      this.transform = Matrix.CreateScale(scale) * this.myRot * Matrix.CreateTranslation(this.mypos);
      this.oldY = this.mypos.Y;
      this.oldpos = this.mypos;
      this.oldRot = this.myRot;
    }

    public void Update(ref float[,] heights)
    {
      this.oldY = this.mypos.Y;
      this.mypos.X += this.velocity.X;
      this.mypos.Y += this.velocity.Y;
      this.mypos.Z += this.velocity.Z;
      this.velocity.Y += this.gravity;
      if ((double) this.velocity.Y < -7.0)
        this.velocity.Y = -7f;
      this.velocity += this.vortex;
      this.vortex *= 0.98f;
      Matrix.Multiply(ref this.myRot, ref this.inertRot, out this.myRot);
      dupeItem.GetHeightSlow(ref heights, ref this.mypos, out this.groundHeight, out this.normal);
      this.scaler = (float) (2.0 - (double) Math.Abs(Vector3.Transform(Vector3.Up, this.myRot).Y) * (2.0 - (double) this.ratio * 2.0)) * this.scale;
      if ((double) this.mypos.Y < (double) this.scaler + (double) this.groundHeight || (double) this.sloper > 0.0)
      {
        ++this.firstHit;
        if ((double) this.velocity.Y < -1.0)
          ++this.secondhit;
        Vector3 vector3 = new Vector3((float) this.rr.Next(-this.randBounce, this.randBounce) / 200f, 0.0f, (float) this.rr.Next(-this.randBounce, this.randBounce) / 200f);
        if ((double) Math.Abs(this.velocity.Y) <= 2.0 && (double) Math.Abs(this.scaler + this.groundHeight - this.mypos.Y) <= 5.0)
          this.velocity *= new Vector3(0.75f, 0.0f, 0.75f);
        else
          this.velocity = Vector3.Reflect(this.velocity, this.normal + vector3) * new Vector3(0.94f, this.bounce, 0.94f);
        if ((double) this.normal.Y < 0.949999988079071)
          this.velocity += new Vector3(this.normal.X, 0.0f, this.normal.Z);
        this.turnRate = Math.Max(Math.Abs(this.turnRate), 0.25f);
        this.inertRot = Matrix.CreateFromAxisAngle(Vector3.Normalize(Vector3.Cross(-this.velocity, Vector3.Up)), this.turnRate);
        if (((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Z) < 0.20000000298023224 || (double) this.sloper > 0.0) && (double) this.sloper < 1.0)
        {
          this.itBleeds = false;
          if (this.landupright)
          {
            if ((double) this.sloper == 0.0)
            {
              this.myRot.Decompose(out this.scale0, out this.rotation0, out this.position0);
              Quaternion.Normalize(this.rotation0);
              Matrix rot = this.myRot with
              {
                Up = this.normal
              };
              if (this.rr.Next(1, 100) < 50)
                rot.Up = -this.normal;
              rot.Right = Vector3.Cross(rot.Forward, rot.Up);
              rot.Right = Vector3.Normalize(rot.Right);
              rot.Forward = Vector3.Cross(rot.Up, rot.Right);
              rot.Forward = Vector3.Normalize(rot.Forward);
              rot.Decompose(out this.scale0, out this.rotation1, out this.position0);
              Quaternion.Normalize(this.rotation1);
            }
            this.sloper += 0.1f;
            this.myRot = Matrix.CreateFromQuaternion(Quaternion.Slerp(this.rotation0, this.rotation1, this.sloper));
          }
          else
            this.sloper += 0.3f;
        }
        if ((double) this.sloper >= 1.0)
        {
          this.velocity = Vector3.Zero;
          this.move = 0;
          this.sloper = 0.0f;
        }
        if ((double) this.scaler + (double) this.groundHeight <= (double) this.mypos.Y + 5.0)
          this.mypos.Y = this.scaler + this.groundHeight;
      }
      Matrix.CreateScale(this.scale, out this.m1);
      Matrix.CreateTranslation(this.mypos.X, this.mypos.Y, this.mypos.Z, out this.m4);
      Matrix.Multiply(ref this.m1, ref this.myRot, out this.m3);
      Matrix.Multiply(ref this.m3, ref this.m4, out this.transform);
    }

    public void Update2(ref float[,] heights)
    {
      this.mypos.X += this.velocity.X;
      this.mypos.Y += this.velocity.Y;
      this.mypos.Z += this.velocity.Z;
      this.velocity.Y += this.gravity;
      if ((double) this.velocity.Y < -5.0)
        this.velocity.Y = -5f;
      Matrix.Multiply(ref this.myRot, ref this.inertRot, out this.myRot);
      dupeItem.GetHeightFast(ref heights, ref this.mypos, out this.groundHeight, out this.normal);
      this.scaler = (float) (2.0 - (double) Math.Abs(Vector3.Transform(Vector3.Up, this.myRot).Y) * (2.0 - (double) this.ratio * 2.0)) * this.scale;
      if ((double) this.mypos.Y < (double) this.scaler + (double) this.groundHeight || (double) this.sloper > 0.0)
      {
        ++this.firstHit;
        if ((double) this.velocity.Y < -1.0)
          ++this.secondhit;
        Vector3 vector3 = new Vector3((float) this.rr.Next(-this.randBounce, this.randBounce) / 200f, 0.0f, (float) this.rr.Next(-this.randBounce, this.randBounce) / 200f);
        if ((double) Math.Abs(this.velocity.Y) > 2.0)
          this.velocity = Vector3.Reflect(this.velocity, this.normal + vector3) * new Vector3(0.94f, this.bounce, 0.94f);
        else
          this.velocity *= new Vector3(0.75f, 0.0f, 0.75f);
        if ((double) this.normal.Y < 0.949999988079071)
          this.velocity += new Vector3(this.normal.X, 0.0f, this.normal.Z) * 1f;
        this.inertRot = Matrix.CreateFromAxisAngle(Vector3.Normalize(Vector3.Cross(-this.velocity, Vector3.Up)), this.turnRate);
        if (((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Z) < 0.20000000298023224 || (double) this.sloper > 0.0) && (double) this.sloper < 1.0)
        {
          this.itBleeds = false;
          if (this.landupright)
          {
            if ((double) this.sloper == 0.0)
            {
              this.myRot.Decompose(out this.scale0, out this.rotation0, out this.position0);
              Quaternion.Normalize(this.rotation0);
              Matrix rot = this.myRot with
              {
                Up = this.normal
              };
              if (this.rr.Next(1, 100) < 50)
                rot.Up = -this.normal;
              rot.Right = Vector3.Cross(rot.Forward, rot.Up);
              rot.Right = Vector3.Normalize(rot.Right);
              rot.Forward = Vector3.Cross(rot.Up, rot.Right);
              rot.Forward = Vector3.Normalize(rot.Forward);
              rot.Decompose(out this.scale0, out this.rotation1, out this.position0);
              Quaternion.Normalize(this.rotation1);
            }
            this.sloper += 0.1f;
            this.myRot = Matrix.CreateFromQuaternion(Quaternion.Slerp(this.rotation0, this.rotation1, this.sloper));
          }
          else
            this.sloper += 0.3f;
        }
        if ((double) this.sloper >= 1.0)
        {
          this.velocity = Vector3.Zero;
          this.move = 0;
          this.sloper = 0.0f;
        }
        this.mypos.Y = this.scaler + this.groundHeight;
      }
      Matrix.CreateScale(this.scale, out this.m1);
      Matrix.CreateTranslation(this.mypos.X, this.mypos.Y, this.mypos.Z, out this.m4);
      Matrix.Multiply(ref this.m1, ref this.myRot, out this.m3);
      Matrix.Multiply(ref this.m3, ref this.m4, out this.transform);
    }

    public void Update3(ref float[,] heights)
    {
      this.mypos.X += this.velocity.X;
      this.mypos.Y += this.velocity.Y;
      this.mypos.Z += this.velocity.Z;
      this.velocity.Y += this.gravity;
      Matrix.Multiply(ref this.myRot, ref this.inertRot, out this.myRot);
      dupeItem.GetHeightSlow(ref heights, ref this.mypos, out this.groundHeight, out this.normal);
      this.scaler = this.scale;
      if ((double) this.mypos.Y < (double) this.scaler + (double) this.groundHeight || (double) this.sloper > 0.0)
      {
        this.velocity = Vector3.Reflect(this.velocity, this.normal + new Vector3((float) this.rr.Next(-this.randBounce, this.randBounce) / 200f, 0.0f, (float) this.rr.Next(-this.randBounce, this.randBounce) / 200f)) * new Vector3(0.98f, this.bounce, 0.98f);
        this.turnRate = Math.Max(Math.Abs(this.turnRate), 0.05f);
        this.inertRot = Matrix.CreateFromAxisAngle(Vector3.Normalize(Vector3.Cross(-this.velocity, Vector3.Up)), this.turnRate);
        if ((double) this.scaler + (double) this.groundHeight <= (double) this.mypos.Y + 5.0)
          this.mypos.Y = this.scaler + this.groundHeight;
        this.mypos.Y = this.scaler + this.groundHeight;
      }
      Matrix.CreateScale(this.scale, out this.m1);
      Matrix.CreateTranslation(this.mypos.X, this.mypos.Y, this.mypos.Z, out this.m4);
      Matrix.Multiply(ref this.m1, ref this.myRot, out this.m3);
      Matrix.Multiply(ref this.m3, ref this.m4, out this.transform);
    }

    public void UpdateNoHeight()
    {
      this.groundHeight = 0.75f;
      this.normal = Vector3.Up;
      this.mypos.X += this.velocity.X;
      this.mypos.Y += this.velocity.Y;
      this.mypos.Z += this.velocity.Z;
      this.velocity.Y += this.gravity;
      if ((double) this.velocity.Y < -6.0)
        this.velocity.Y = -7f;
      this.myRot *= this.inertRot;
      this.scaler = (float) (2.0 - (double) Math.Abs(Vector3.Transform(Vector3.Up, this.myRot).Y) * (2.0 - (double) this.ratio * 2.0)) * this.scale;
      if ((double) this.mypos.Y < (double) this.scaler + (double) this.groundHeight || (double) this.sloper > 0.0)
      {
        ++this.firstHit;
        if ((double) this.velocity.Y < -1.0)
          ++this.secondhit;
        Vector3 vector3 = new Vector3((float) this.rr.Next(-this.randBounce, this.randBounce) / 200f, 0.0f, (float) this.rr.Next(-this.randBounce, this.randBounce) / 200f);
        if ((double) Math.Abs(this.velocity.Y) > 2.0)
          this.velocity = Vector3.Reflect(this.velocity, this.normal + vector3) * new Vector3(0.94f, this.bounce, 0.94f);
        else
          this.velocity *= new Vector3(0.75f, 0.0f, 0.75f);
        if ((double) this.normal.Y < 0.949999988079071)
          this.velocity += new Vector3(this.normal.X, 0.0f, this.normal.Z) * 1f;
        this.inertRot = Matrix.CreateFromAxisAngle(Vector3.Normalize(Vector3.Cross(-this.velocity, Vector3.Up)), this.turnRate);
        if (((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Z) < 0.20000000298023224 || (double) this.sloper > 0.0) && (double) this.sloper < 1.0)
        {
          if (this.landupright)
          {
            if ((double) this.sloper == 0.0)
            {
              this.myRot.Decompose(out this.scale0, out this.rotation0, out this.position0);
              Quaternion.Normalize(this.rotation0);
              Matrix rot = this.myRot with
              {
                Up = this.normal
              };
              if (this.rr.Next(1, 100) < 50)
                rot.Up = -this.normal;
              rot.Right = Vector3.Cross(rot.Forward, rot.Up);
              rot.Right = Vector3.Normalize(rot.Right);
              rot.Forward = Vector3.Cross(rot.Up, rot.Right);
              rot.Forward = Vector3.Normalize(rot.Forward);
              rot.Decompose(out this.scale0, out this.rotation1, out this.position0);
              Quaternion.Normalize(this.rotation1);
            }
            this.sloper += 0.1f;
            this.myRot = Matrix.CreateFromQuaternion(Quaternion.Slerp(this.rotation0, this.rotation1, this.sloper));
          }
          else
            this.sloper += 0.3f;
        }
        if ((double) this.sloper >= 1.0)
        {
          this.velocity = Vector3.Zero;
          this.move = 0;
          this.sloper = 0.0f;
        }
        this.mypos.Y = this.scaler + this.groundHeight;
      }
      this.transform = Matrix.CreateScale(this.scale) * this.myRot * Matrix.CreateTranslation(this.mypos);
    }

    private static void GetHeightFast(
      ref float[,] heights,
      ref Vector3 pos,
      out float height,
      out Vector3 normal)
    {
      int index1 = (int) MathHelper.Clamp(pos.X / dupeItem.unit, 0.0f, (float) (dupeItem.bitmap - 2));
      int index2 = (int) MathHelper.Clamp(pos.Z / dupeItem.unit, 0.0f, (float) (dupeItem.bitmap - 2));
      float num1 = pos.X % dupeItem.unit / dupeItem.unit;
      float num2 = pos.Z % dupeItem.unit / dupeItem.unit;
      float num3 = (float) ((1.0 - (double) num1) * (double) heights[index1, index2] + (double) num1 * (double) heights[index1 + 1, index2]);
      float num4 = (float) ((1.0 - (double) num1) * (double) heights[index1, index2 + 1] + (double) num1 * (double) heights[index1 + 1, index2 + 1]);
      height = (float) ((1.0 - (double) num2) * (double) num3 + (double) num2 * (double) num4);
      normal = Vector3.Normalize(new Vector3(-heights[index1 + 1, index2] + heights[index1, index2], 30f, -heights[index1, index2 + 1] + heights[index1, index2]));
    }

    private static void GetHeightSlow(
      ref float[,] heights,
      ref Vector3 pos,
      out float height,
      out Vector3 normal)
    {
      int index1 = (int) MathHelper.Clamp(pos.X / dupeItem.unit, 0.0f, (float) (dupeItem.bitmap - 2));
      int index2 = (int) MathHelper.Clamp(pos.Z / dupeItem.unit, 0.0f, (float) (dupeItem.bitmap - 2));
      float num1 = pos.X % dupeItem.unit / dupeItem.unit;
      float num2 = pos.Z % dupeItem.unit / dupeItem.unit;
      float num3 = (float) ((1.0 - (double) num1) * (double) heights[index1, index2] + (double) num1 * (double) heights[index1 + 1, index2]);
      float num4 = (float) ((1.0 - (double) num1) * (double) heights[index1, index2 + 1] + (double) num1 * (double) heights[index1 + 1, index2 + 1]);
      height = (float) ((1.0 - (double) num2) * (double) num3 + (double) num2 * (double) num4);
      normal = Vector3.Normalize(new Vector3(-heights[index1 + 1, index2] + heights[index1, index2], 30f, -heights[index1, index2 + 1] + heights[index1, index2]));
    }
  }
}
