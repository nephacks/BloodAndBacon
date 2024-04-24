using Microsoft.Xna.Framework;
using System;

#pragma warning disable CS0414
#pragma warning disable CS0169
#nullable disable
namespace Blood
{
  public class explodeDupe
  {
    private Matrix m1;
    private Matrix m2;
    private Matrix m3;
    private Matrix m4;
    public bool vortexOn;
    public bool poofy;
    public static Vector2 vortex;
    public float myscale = 1f;
    private float cuttyScale = 1f;
    public static int bitmap;
    public static float unit;
    public Vector3 scalePart;
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
    public Vector3 offset;
    public Vector3 normal;
    public float scaler;
    public Vector3 velocity;
    public Matrix transform;
    public int tint;
    public int tint2;
    public int firstHit;
    public bool localShell;
    public bool landupright;
    public int randBounce = 10;
    public int age;
    public int bleed = 260;
    public Vector3 emitVec;
    public int partID;
    public int mult;
    public readonly Random rr;
    public int lastKicked;
    public int cChoice;
    private Quaternion qq;
    public bool spinner;

    public explodeDupe(int i)
    {
      this.rr = new Random(i);
      this.ratio = 1f;
      this.scale = 1f;
      this.bounce = 0.65f;
      this.randBounce = 15;
      this.cChoice = this.rr.Next(1, 7);
      this.move = 1;
      this.gravity = -0.15f;
      this.gravity = -1f / 500f;
      this.turnRate = (float) this.rr.Next(10, 48) / 1000f;
      this.inertRot = Matrix.CreateFromAxisAngle(Vector3.Normalize(new Vector3((float) this.rr.Next(-1800, 1800) / 100f, (float) this.rr.Next(-1800, 1800) / 100f, (float) this.rr.Next(-1800, 1800) / 100f)), this.turnRate);
      if (this.rr.Next(1, 100) < 20)
        this.spinner = true;
      this.velocity = Vector3.Zero;
      this.transform = Matrix.Identity;
    }

    public void createState(Matrix mm, Vector3 veloc, float cuttyScale, float reality)
    {
      mm.Decompose(out this.scalePart, out this.qq, out this.mypos);
      this.myRot = Matrix.CreateRotationX((float) this.rr.Next(-1800, 1800) / 100f) * Matrix.CreateRotationY((float) this.rr.Next(-1800, 1800) / 100f) * Matrix.CreateRotationZ((float) this.rr.Next(-1800, 1800) / 100f);
      this.velocity = (double) this.mypos.Y >= 50.0 ? veloc * (float) this.rr.Next(20, 80) / 100f : veloc * (float) this.rr.Next(70, 99) / 100f;
      this.velocity *= reality;
      this.gravity *= reality;
      this.turnRate *= reality;
      this.myscale = (float) (((double) this.scalePart.X + (double) this.scalePart.Y + (double) this.scalePart.Z) / 3.5);
      this.scale = this.myscale / cuttyScale;
      this.inertRot = Matrix.CreateFromAxisAngle(Vector3.Normalize(Vector3.Cross(-veloc, Vector3.Up)), this.turnRate);
      this.scalePart /= cuttyScale;
      this.poofy = false;
      if (this.rr.Next(1, 1000) < 70)
        this.poofy = true;
      explodeDupe.vortex = Vector2.Zero;
      this.age = 0;
      this.move = 1;
      this.sloper = 0.0f;
      this.oldpos = this.mypos;
    }

    public void Update(ref float[,] heights)
    {
      ++this.age;
      if (this.move == 1)
      {
        this.mypos.X += this.velocity.X;
        this.mypos.Y += this.velocity.Y;
        this.mypos.Z += this.velocity.Z;
        this.velocity.Y += this.gravity;
        this.myRot *= this.inertRot;
        this.groundHeight = -1000f;
        this.offset = !this.spinner ? this.mypos : Vector3.Transform(new Vector3(0.0f, 0.0f, 0.3f) * this.scale, this.myRot) + this.mypos;
        if (this.age > 100)
          explodeDupe.GetHeightFast(heights, new Vector2(this.mypos.X, this.mypos.Z), out this.groundHeight, out this.normal);
        this.scaler = this.scale * 0.3f;
        if ((double) this.mypos.Y < (double) this.scaler + (double) this.groundHeight || (double) this.sloper > 0.0)
        {
          if (this.firstHit < 5)
            this.firstHit = 1;
          Vector3 vector3 = new Vector3((float) this.rr.Next(-this.randBounce, this.randBounce) / 200f, 0.0f, (float) this.rr.Next(-this.randBounce, this.randBounce) / 200f);
          if ((double) Math.Abs(this.velocity.Y) > 1.0)
            this.velocity = Vector3.Reflect(this.velocity, this.normal + vector3) * new Vector3(0.99f, this.bounce, 0.99f);
          else
            this.velocity *= new Vector3(0.99f, 0.0f, 0.99f);
          this.inertRot = Matrix.CreateFromAxisAngle(Vector3.Normalize(Vector3.Cross(-this.velocity, Vector3.Up)), this.turnRate);
          if (((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Z) < 0.05000000074505806 || (double) this.sloper > 0.0) && (double) this.sloper < 1.0)
            this.sloper += 0.1f;
          if ((double) this.sloper >= 1.0)
          {
            this.velocity = Vector3.Zero;
            this.move = 3;
            this.sloper = 0.0f;
          }
          this.mypos.Y = this.scaler + this.groundHeight;
        }
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
      int index1 = (int) MathHelper.Clamp(position.X / explodeDupe.unit, 0.0f, (float) (explodeDupe.bitmap - 2));
      int index2 = (int) MathHelper.Clamp(position.Y / explodeDupe.unit, 0.0f, (float) (explodeDupe.bitmap - 2));
      float num1 = position.X % explodeDupe.unit / explodeDupe.unit;
      float num2 = position.Y % explodeDupe.unit / explodeDupe.unit;
      float num3 = (float) ((1.0 - (double) num1) * (double) heights[index1, index2] + (double) num1 * (double) heights[index1 + 1, index2]);
      float num4 = (float) ((1.0 - (double) num1) * (double) heights[index1, index2 + 1] + (double) num1 * (double) heights[index1 + 1, index2 + 1]);
      height = (float) ((1.0 - (double) num2) * (double) num3 + (double) num2 * (double) num4);
      normal = Vector3.Normalize(new Vector3(-heights[index1 + 1, index2] + heights[index1, index2], 30f, -heights[index1, index2 + 1] + heights[index1, index2]));
    }
  }
}
