using Microsoft.Xna.Framework;
using System;

#pragma warning disable CS0169
#nullable disable
namespace Blood
{
  public class debrisDupe
  {
    private Matrix m1;
    private Matrix m2;
    private Matrix m3;
    private Matrix m4;
    public bool itBleeds;
    public bool kickable;
    public static int bitmap;
    public static float unit;
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
    public readonly Random rr;
    public int lastKicked;
    private Vector3 dump1;
    private Vector3 dump2;
    private Quaternion qq;

    public debrisDupe(
      int i,
      float bounce,
      float scale,
      Matrix startpos,
      Vector3 veloc,
      float grav,
      bool itBleeds)
    {
      this.rr = new Random(i);
      this.lastKicked = 0;
      this.scale = scale;
      this.bounce = bounce;
      this.randBounce = 20;
      this.itBleeds = itBleeds;
      this.move = 0;
      this.gravity = grav;
      this.gash = this.rr.Next(50, 250);
      this.freq = this.rr.Next(4, 16);
      startpos.Decompose(out this.dump1, out this.qq, out this.dump2);
      this.myRot = Matrix.CreateFromQuaternion(this.qq);
      this.turnRate = (float) this.rr.Next(25, 45) / 1000f;
      this.inertRot = Matrix.CreateFromAxisAngle(Vector3.Normalize(Vector3.Cross(-veloc, Vector3.Up)), this.turnRate);
      this.velocity = this.move <= 0 ? Vector3.Zero : veloc;
      this.mypos = Vector3.Transform(Vector3.Zero, startpos);
      this.transform = Matrix.CreateScale(scale) * this.myRot * Matrix.CreateTranslation(this.mypos);
      this.oldpos = this.mypos;
      this.oldRot = this.myRot;
    }

    public void Update(ref float[,] heights)
    {
      this.mypos.X += this.velocity.X;
      this.mypos.Y += this.velocity.Y;
      this.mypos.Z += this.velocity.Z;
      this.velocity.Y += this.gravity;
      if ((double) this.velocity.Y < -7.0)
        this.velocity.Y = -7f;
      Matrix.Multiply(ref this.myRot, ref this.inertRot, out this.myRot);
      debrisDupe.GetHeightFast(ref heights, ref this.mypos, out this.groundHeight, out this.normal);
      this.scaler = this.scale;
      if ((double) this.mypos.Y < (double) this.scaler + (double) this.groundHeight || (double) this.sloper > 0.0)
      {
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

    private static void GetHeightFast(
      ref float[,] heights,
      ref Vector3 pos,
      out float height,
      out Vector3 normal)
    {
      normal = new Vector3(0.0f, 1f, 0.0f);
      int index1 = (int) MathHelper.Clamp(pos.X / debrisDupe.unit, 0.0f, (float) (debrisDupe.bitmap - 2));
      int index2 = (int) MathHelper.Clamp(pos.Z / debrisDupe.unit, 0.0f, (float) (debrisDupe.bitmap - 2));
      height = heights[index1, index2];
      if ((double) height < (double) pos.Y)
        return;
      float num1 = pos.X % debrisDupe.unit / debrisDupe.unit;
      float num2 = pos.Z % debrisDupe.unit / debrisDupe.unit;
      float num3 = (float) ((1.0 - (double) num1) * (double) heights[index1, index2] + (double) num1 * (double) heights[index1 + 1, index2]);
      float num4 = (float) ((1.0 - (double) num1) * (double) heights[index1, index2 + 1] + (double) num1 * (double) heights[index1 + 1, index2 + 1]);
      height = (float) ((1.0 - (double) num2) * (double) num3 + (double) num2 * (double) num4);
      normal = Vector3.Normalize(new Vector3(-heights[index1 + 1, index2] + heights[index1, index2], 30f, -heights[index1, index2 + 1] + heights[index1, index2]));
    }
  }
}
