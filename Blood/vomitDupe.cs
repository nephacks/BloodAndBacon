using Microsoft.Xna.Framework;
using System;

#nullable disable
namespace Blood
{
  public class vomitDupe
  {
    private Matrix m1;
    private Matrix m2;
    private Matrix m3;
    private Matrix m4;
    private float rotz;
    public static int bitmap;
    public static float unit;
    public float age;
    private Vector3 scalePart;
    public Vector3 mycolor;
    private float gravity;
    public float scale;
    public float ratio;
    public float bounce;
    private float groundHeight;
    public Matrix myRot;
    public float sloper;
    public int move;
    public bool splat;
    public Vector3 mypos;
    public Vector3 normal;
    public Vector3 velocity;
    public Matrix transform;
    public int randBounce = 10;
    public readonly Random[] rr = new Random[2];
    public int lastKicked;
    private Quaternion qq;
    private Vector3 v;
    private float result;

    public vomitDupe(int i) => this.rr[0] = new Random(i);

    public void init(
      float bounce,
      Matrix mm,
      Vector3 veloc,
      float grav,
      int rbounce,
      float ta,
      float tb)
    {
      this.groundHeight = -500f;
      this.bounce = bounce;
      this.randBounce = rbounce;
      this.gravity = grav;
      this.age = 0.0f;
      this.velocity = veloc;
      mm.Decompose(out this.scalePart, out this.qq, out this.mypos);
      this.myRot = Matrix.CreateFromQuaternion(this.qq);
      this.transform = mm;
      this.scale = (float) (((double) this.scalePart.X + (double) this.scalePart.Y + (double) this.scalePart.Z) / 2.0);
      this.v = Vector3.Transform(Vector3.Up, this.myRot);
      this.result = Vector3.Dot(this.v, Vector3.Up);
      this.move = 1;
      this.splat = false;
    }

    public void Update(ref float[,] heights, Vector3 inherit)
    {
      ++this.age;
      if (this.move == 1)
      {
        this.mypos += inherit;
        this.mypos.X += this.velocity.X;
        this.mypos.Y += this.velocity.Y;
        this.mypos.Z += this.velocity.Z;
        this.velocity.Y += this.gravity;
        float num1 = 0.0f;
        if ((double) this.velocity.Z > 0.0)
          num1 = 3.14f;
        float d1 = this.velocity.Y / Vector2.Distance(new Vector2(this.velocity.X, this.velocity.Z), new Vector2(0.0f, 0.0f));
        float d2 = this.velocity.X / this.velocity.Z;
        this.rotz += 0.8f;
        Matrix.CreateRotationZ(this.rotz, out this.m1);
        Matrix.CreateRotationX((float) Math.Atan((double) d1), out this.m2);
        Matrix.CreateRotationY((float) Math.Atan((double) d2) + num1, out this.m4);
        Matrix.Multiply(ref this.m1, ref this.m2, out this.m3);
        Matrix.Multiply(ref this.m3, ref this.m4, out this.myRot);
        if ((double) this.age > 8.0)
          vomitDupe.GetHeightFastest(ref heights, new Vector2(this.mypos.X, this.mypos.Z), out this.groundHeight, out this.normal);
        this.scalePart.X *= 1.02f;
        this.scalePart.Y *= 1.02f;
        if ((double) this.mypos.Y < (double) this.groundHeight)
        {
          this.velocity = Vector3.Reflect(this.velocity, this.normal + new Vector3((float) this.rr[0].Next(-this.randBounce, this.randBounce) / 200f, 0.0f, (float) this.rr[0].Next(-this.randBounce, this.randBounce) / 200f)) * new Vector3(0.52f, this.bounce, 0.52f);
          this.move = 2;
          if (this.rr[0].Next(1, 100) < 70)
            this.move = 3;
          this.splat = true;
          this.scalePart.Z *= 0.7f;
          this.scalePart.X *= 0.92f;
          this.scalePart.Y *= 0.92f;
          float num2 = 0.0f;
          if ((double) this.velocity.Z > 0.0)
            num2 = 3.14f;
          float d3 = this.velocity.Y / Vector2.Distance(new Vector2(this.velocity.X, this.velocity.Z), new Vector2(0.0f, 0.0f));
          float d4 = this.velocity.X / this.velocity.Z;
          this.myRot = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationX((float) Math.Atan((double) d3)) * Matrix.CreateRotationY((float) Math.Atan((double) d4) + num2);
          this.mypos.Y = this.scale + this.groundHeight;
        }
      }
      if (this.move == 2)
      {
        this.mypos.X += this.velocity.X;
        this.mypos.Y += this.velocity.Y;
        this.mypos.Z += this.velocity.Z;
        this.velocity.Y += this.gravity / 2.5f;
        this.velocity *= new Vector3(0.93f, 0.93f, 0.93f);
        this.scalePart.Z *= 0.94f;
        this.scalePart.X *= 0.95f;
        this.scalePart.Y *= 0.95f;
        if ((double) this.scalePart.X < 0.40000000596046448)
          this.move = 3;
      }
      Matrix.CreateScale(this.scalePart.X, this.scalePart.Y, this.scalePart.Z, out this.m1);
      Matrix.CreateTranslation(this.mypos.X, this.mypos.Y, this.mypos.Z, out this.m4);
      Matrix.Multiply(ref this.m1, ref this.myRot, out this.m3);
      Matrix.Multiply(ref this.m3, ref this.m4, out this.transform);
    }

    private static void GetHeightFast(
      ref float[,] heights,
      Vector2 position,
      out float height,
      out Vector3 normal)
    {
      int index1 = (int) MathHelper.Clamp(position.X / vomitDupe.unit, 0.0f, (float) (vomitDupe.bitmap - 2));
      int index2 = (int) MathHelper.Clamp(position.Y / vomitDupe.unit, 0.0f, (float) (vomitDupe.bitmap - 2));
      float num1 = position.X % vomitDupe.unit / vomitDupe.unit;
      float num2 = position.Y % vomitDupe.unit / vomitDupe.unit;
      float num3 = (float) ((1.0 - (double) num1) * (double) heights[index1, index2] + (double) num1 * (double) heights[index1 + 1, index2]);
      float num4 = (float) ((1.0 - (double) num1) * (double) heights[index1, index2 + 1] + (double) num1 * (double) heights[index1 + 1, index2 + 1]);
      height = (float) ((1.0 - (double) num2) * (double) num3 + (double) num2 * (double) num4);
      normal = new Vector3(0.0f, 1f, 0.0f);
    }

    private static void GetHeightFastest(
      ref float[,] heights,
      Vector2 position,
      out float height,
      out Vector3 normal)
    {
      int index1 = (int) MathHelper.Clamp(position.X / vomitDupe.unit, 0.0f, (float) (vomitDupe.bitmap - 2));
      int index2 = (int) MathHelper.Clamp(position.Y / vomitDupe.unit, 0.0f, (float) (vomitDupe.bitmap - 2));
      height = heights[index1, index2];
      normal = new Vector3(0.0f, 1f, 0.0f);
    }
  }
}
