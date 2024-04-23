// Decompiled with JetBrains decompiler
// Type: Blood.chunkDupe
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;
using System;

#nullable disable
namespace Blood
{
  public class chunkDupe
  {
    private Matrix m1;
    private Matrix m2;
    private Matrix m3;
    private Matrix m4;
    public bool itBleeds;
    public bool kickable;
    public static int bitmap;
    public static float unit;
    private Vector3 scalePart;
    private Quaternion rotation0;
    private Quaternion rotation1;
    private Vector3 position0;
    public Matrix tempTrans;
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
    public int tint;
    public int tint2;
    public int firstHit;
    public int secondhit;
    public bool localShell;
    public bool landupright;
    public int randBounce = 10;
    public int alive;
    public int kicked;
    public int bleed = 260;
    public int gash;
    public int freq;
    public Vector3 vortex = Vector3.Zero;
    public Vector3 emitVec;
    public int partID;
    public int mult;
    public readonly Random[] rr = new Random[2];
    public int lastKicked;
    private Vector3 dump1;
    private Vector3 dump2;
    private Quaternion qq;
    private Vector3 v;
    private float result;

    public chunkDupe(int i) => this.rr[0] = new Random(i);

    public void init(
      float bounce,
      float scale,
      float ratio,
      Matrix startpos,
      Vector3 veloc,
      float grav,
      int rbounce,
      float ta,
      float tb)
    {
      this.ratio = ratio;
      this.scale = scale;
      this.bounce = bounce;
      this.randBounce = rbounce;
      this.alive = 0;
      this.move = 0;
      this.gravity = grav;
      startpos.Decompose(out this.dump1, out this.qq, out this.dump2);
      this.myRot = Matrix.CreateFromQuaternion(this.qq);
      this.turnRate = (float) this.rr[0].Next((int) ta, (int) tb) / 1000f;
      this.inertRot = Matrix.CreateFromAxisAngle(Vector3.Normalize(new Vector3((float) this.rr[0].Next(-800, 800) / 100f, (float) this.rr[0].Next(-800, 800) / 100f, (float) this.rr[0].Next(-800, 800) / 100f)), this.turnRate);
      this.v = Vector3.Transform(Vector3.Up, this.myRot);
      this.result = Vector3.Dot(this.v, Vector3.Up);
      this.scaler = (float) (2.0 - (double) Math.Abs(this.result) * (2.0 - (double) ratio * 2.0)) * scale;
      this.velocity = Vector3.Zero;
      this.mypos = Vector3.Transform(Vector3.Zero, startpos);
      this.transform = startpos;
    }

    public void createState(Matrix mm)
    {
      mm.Decompose(out this.scalePart, out this.qq, out this.mypos);
      this.myRot = Matrix.CreateFromQuaternion(this.qq);
    }

    public void Update(ref float[,] heights)
    {
      if (this.move == 1)
      {
        this.mypos.X += this.velocity.X;
        this.mypos.Y += this.velocity.Y;
        this.mypos.Z += this.velocity.Z;
        this.velocity.Y += this.gravity;
        this.myRot *= this.inertRot;
        chunkDupe.GetHeightFast(heights, new Vector2(this.mypos.X, this.mypos.Z), out this.groundHeight, out this.normal);
        this.scaler = this.scale * 4f;
        if ((double) this.mypos.Y < (double) this.scaler + (double) this.groundHeight || (double) this.sloper > 0.0)
        {
          Vector3 vector3 = new Vector3((float) this.rr[0].Next(-this.randBounce, this.randBounce) / 200f, 0.0f, (float) this.rr[0].Next(-this.randBounce, this.randBounce) / 200f);
          if ((double) Math.Abs(this.velocity.Y) > 2.0)
            this.velocity = Vector3.Reflect(this.velocity, this.normal + vector3) * new Vector3(0.94f, this.bounce, 0.94f);
          else
            this.velocity *= new Vector3(0.85f, 0.0f, 0.85f);
          if ((double) this.normal.Y < 0.949999988079071)
            this.velocity += new Vector3(this.normal.X, 0.0f, this.normal.Z);
          this.inertRot = Matrix.CreateFromAxisAngle(Vector3.Normalize(Vector3.Cross(-this.velocity, Vector3.Up)), this.turnRate);
          if (((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Z) < 0.20000000298023224 || (double) this.sloper > 0.0) && (double) this.sloper < 1.0)
            this.sloper += 0.1f;
          if ((double) this.sloper >= 1.0)
          {
            this.velocity = Vector3.Zero;
            this.move = 2;
            this.sloper = 0.0f;
          }
          this.mypos.Y = this.scaler + this.groundHeight;
        }
      }
      if (this.move == 2)
      {
        this.scalePart *= 0.98f;
        if ((double) this.scalePart.X < 0.0099999997764825821)
          this.move = 3;
      }
      Matrix.CreateScale(this.scalePart.X, this.scalePart.Y, this.scalePart.Z, out this.m1);
      Matrix.CreateTranslation(this.mypos.X, this.mypos.Y, this.mypos.Z, out this.m4);
      Matrix.Multiply(ref this.m1, ref this.myRot, out this.m3);
      Matrix.Multiply(ref this.m3, ref this.m4, out this.transform);
    }

    private static void GetHeightFast(
      float[,] heights,
      Vector2 position,
      out float height,
      out Vector3 normal)
    {
      int index1 = (int) MathHelper.Clamp(position.X / chunkDupe.unit, 0.0f, (float) (chunkDupe.bitmap - 2));
      int index2 = (int) MathHelper.Clamp(position.Y / chunkDupe.unit, 0.0f, (float) (chunkDupe.bitmap - 2));
      height = heights[index1, index2];
      normal = new Vector3(0.0f, 1f, 0.0f);
    }
  }
}
