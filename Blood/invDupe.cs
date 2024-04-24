using Microsoft.Xna.Framework;
using System;

#nullable disable
namespace Blood
{
  public class invDupe
  {
    public static int glowIndex = -1;
    public static int bitmap;
    public static float unit;
    private float x1 = 3130f;
    private float x2 = 3660f;
    private float z1 = 4450f;
    private float z2 = 4800f;
    private Vector3 scale0;
    private Quaternion rotation0;
    private Quaternion rotation1;
    private Vector3 position0;
    public float gravity;
    public Vector3 scale;
    public float ratio;
    public float bounce;
    public float groundHeight;
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
    public bool localShell;
    public bool barnok;
    public int landupright;
    public int randBounce = 10;
    public int age;
    public bool isLocal = true;
    private bool farmerowned;
    private Vector3 dump1;
    private Vector3 dump2;
    private Quaternion qq;
    private Vector3 v;
    private float result;
    public Randoms rr;

    public invDupe(int i) => this.rr = new Randoms(i);

    public void init(
      float bounce,
      float scale,
      float ratio,
      Matrix startpos,
      Vector3 veloc,
      int move,
      float grav,
      int rbounce,
      float ta,
      float tb,
      int landupright,
      bool oblong)
    {
      this.isLocal = true;
      this.age = 0;
      this.ratio = ratio;
      this.scale = new Vector3(scale, scale, scale);
      this.bounce = bounce;
      this.randBounce = rbounce;
      this.landupright = landupright;
      this.move = move;
      this.sloper = 0.0f;
      if (oblong)
        this.scale = new Vector3(scale * ((float) this.rr.Next(80, 150) / 100f), scale * ((float) this.rr.Next(80, 120) / 100f), scale * ((float) this.rr.Next(80, 150) / 100f));
      this.firstHit = 0;
      this.gravity = grav;
      startpos.Decompose(out this.dump1, out this.qq, out this.dump2);
      this.myRot = Matrix.CreateFromQuaternion(this.qq);
      this.turnRate = (float) this.rr.Next((int) ta, (int) tb) / 1000f;
      this.inertRot = Matrix.CreateFromAxisAngle(Vector3.Normalize(Vector3.Cross(-veloc, Vector3.Up)), this.turnRate / 3f);
      this.v = Vector3.Transform(Vector3.Up, this.myRot);
      this.result = Vector3.Dot(this.v, Vector3.Up);
      this.scaler = (float) (2.0 - (double) Math.Abs(this.result) * (2.0 - (double) ratio * 2.0)) * scale;
      this.velocity = move <= 0 ? Vector3.Zero : veloc;
      this.mypos = Vector3.Transform(Vector3.Zero, startpos);
      this.transform = Matrix.CreateScale(scale) * this.myRot * Matrix.CreateTranslation(this.mypos);
    }

    public void initGrenade(
      Vector3 startpos,
      Vector3 veloc,
      byte bounce,
      int seed,
      bool isLocal,
      int age,
      int small)
    {
      this.rr.changeSeed(seed);
      this.isLocal = isLocal;
      this.age = age;
      this.ratio = 0.5f;
      this.scale = new Vector3(2f, 2f, 2f);
      this.farmerowned = false;
      if (small == 2)
      {
        this.scale = new Vector3(2f, 2f, 2f);
        this.farmerowned = true;
      }
      if (small == 0)
        this.scale = new Vector3(1f, 1f, 1f);
      this.bounce = (float) bounce / (float) byte.MaxValue;
      this.randBounce = 35;
      this.landupright = 0;
      this.move = 1;
      this.firstHit = 0;
      this.gravity = -0.09f;
      this.sloper = 0.0f;
      this.myRot = Matrix.CreateFromYawPitchRoll((float) this.rr.Next(-860, 890) / 100f, (float) this.rr.Next(-860, 890) / 100f, (float) this.rr.Next(-860, 890) / 100f);
      this.turnRate = (float) this.rr.Next(260, 390) / 1000f;
      this.inertRot = Matrix.CreateFromAxisAngle(Vector3.Normalize(Vector3.Cross(-veloc, Vector3.Up)), this.turnRate / 2f);
      this.v = Vector3.Transform(Vector3.Up, this.myRot);
      this.result = Vector3.Dot(this.v, Vector3.Up);
      this.scaler = (float) (2.0 - (double) Math.Abs(this.result) * (2.0 - (double) this.ratio * 2.0)) * this.scale.X;
      this.velocity = veloc;
      this.mypos = startpos;
      this.transform = Matrix.CreateScale(this.scale) * this.myRot * Matrix.CreateTranslation(this.mypos);
    }

    public void Update(ref float[,] heights)
    {
      this.mypos.X += this.velocity.X;
      this.mypos.Y += this.velocity.Y;
      this.mypos.Z += this.velocity.Z;
      this.velocity.Y += this.gravity;
      this.myRot *= this.inertRot;
      if ((double) this.velocity.Y < -6.0)
        this.velocity.Y = -7f;
      invDupe.GetHeightFast(heights, new Vector2(this.mypos.X, this.mypos.Z), out this.groundHeight, out this.normal);
      this.scaler = (float) (2.0 - (double) Math.Abs(Vector3.Dot(Vector3.Normalize(Vector3.Transform(Vector3.Up, this.myRot)), Vector3.Up)) * (2.0 - (double) this.ratio * 2.0)) * this.scale.X;
      if ((double) this.mypos.Y < (double) this.scaler + (double) this.groundHeight || (double) this.sloper > 0.0)
      {
        if ((double) this.velocity.LengthSquared() > 4.0)
          ++this.firstHit;
        Vector3 vector3 = new Vector3((float) this.rr.Next(-this.randBounce, this.randBounce) / 200f, 0.0f, (float) this.rr.Next(-this.randBounce, this.randBounce) / 200f);
        if ((double) Math.Abs(this.velocity.Y) <= 2.0 && (double) Math.Abs(this.scaler + this.groundHeight - this.mypos.Y) <= 5.0)
          this.velocity *= new Vector3(0.87f, 0.0f, 0.87f);
        else
          this.velocity = Vector3.Reflect(this.velocity, this.normal + vector3) * new Vector3(0.94f, this.bounce, 0.94f);
        if ((double) this.normal.Y < 0.949999988079071)
          this.velocity += new Vector3(this.normal.X, 0.0f, this.normal.Z);
        this.inertRot = Matrix.CreateFromAxisAngle(Vector3.Normalize(Vector3.Cross(-this.velocity, Vector3.Up)), this.turnRate);
        if (((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Z) < 0.20000000298023224 || (double) this.sloper > 0.0) && (double) this.sloper < 1.0)
        {
          if (this.landupright > 0)
          {
            if ((double) this.sloper == 0.0)
            {
              this.myRot.Decompose(out this.scale0, out this.rotation0, out this.position0);
              Quaternion.Normalize(this.rotation0);
              Matrix rot = this.myRot with
              {
                Up = this.normal
              };
              if (this.rr.Next(1, 100) < 50 && this.landupright == 2)
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
            this.sloper += 0.1f;
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
      this.transform = Matrix.CreateScale(this.scale.X, this.scale.Y, this.scale.Z) * this.myRot * Matrix.CreateTranslation(this.mypos);
    }

    public void UpdateInBarn(ref float[,] heights)
    {
      this.mypos.X += this.velocity.X;
      this.mypos.Y += this.velocity.Y;
      this.mypos.Z += this.velocity.Z;
      this.velocity.Y += this.gravity;
      this.myRot *= this.inertRot;
      if ((double) this.velocity.Y < -6.0)
        this.velocity.Y = -7f;
      bool flag = (double) this.x1 < (double) this.mypos.X && (double) this.mypos.X < (double) this.x2 && (double) this.z1 < (double) this.mypos.Z && (double) this.mypos.Z < (double) this.z2;
      this.groundHeight = 0.0f;
      this.normal = Vector3.Up;
      if (!flag && !this.farmerowned)
      {
        invDupe.GetHeightFast(heights, new Vector2(this.mypos.X, this.mypos.Z), out this.groundHeight, out this.normal);
        if ((double) this.groundHeight != 0.0)
        {
          this.normal = Vector3.Zero;
          if ((double) this.mypos.X > (double) this.x2)
            this.normal.X = -1f;
          else if ((double) this.mypos.X < (double) this.x1)
            this.normal.X = 1f;
          if ((double) this.mypos.Z < (double) this.z1)
            this.normal.Z = 1f;
          else if ((double) this.mypos.Z > (double) this.z2)
            this.normal.Z = -1f;
        }
      }
      this.scaler = (float) (2.0 - (double) Math.Abs(Vector3.Dot(Vector3.Normalize(Vector3.Transform(Vector3.Up, this.myRot)), Vector3.Up)) * (2.0 - (double) this.ratio * 2.0)) * this.scale.X;
      if ((double) this.mypos.Y < (double) this.scaler + (double) this.groundHeight || (double) this.sloper > 0.0)
      {
        if ((double) this.velocity.LengthSquared() > 4.0)
          ++this.firstHit;
        Vector3 vector3 = new Vector3((float) this.rr.Next(-this.randBounce, this.randBounce) / 200f, 0.0f, (float) this.rr.Next(-this.randBounce, this.randBounce) / 200f);
        if ((double) Math.Abs(this.velocity.Y) > 2.0)
          this.velocity = Vector3.Reflect(this.velocity, this.normal + vector3) * new Vector3(0.94f, this.bounce, 0.94f);
        else
          this.velocity *= new Vector3(0.87f, 0.0f, 0.87f);
        if ((double) this.normal.Y < 0.949999988079071)
          this.velocity += new Vector3(this.normal.X, 0.0f, this.normal.Z);
        this.inertRot = Matrix.CreateFromAxisAngle(Vector3.Normalize(Vector3.Cross(-this.velocity, Vector3.Up)), this.turnRate);
        if (((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Z) < 0.20000000298023224 || (double) this.sloper > 0.0) && (double) this.sloper < 1.0)
        {
          if (this.landupright > 0)
          {
            if ((double) this.sloper == 0.0)
            {
              this.myRot.Decompose(out this.scale0, out this.rotation0, out this.position0);
              Quaternion.Normalize(this.rotation0);
              Matrix rot = this.myRot with
              {
                Up = this.normal
              };
              if (this.rr.Next(1, 100) < 50 && this.landupright == 2)
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
            this.sloper += 0.1f;
        }
        if ((double) this.sloper >= 1.0)
        {
          this.velocity = Vector3.Zero;
          this.move = 0;
          this.sloper = 0.0f;
        }
        if ((double) this.normal.Y > 0.60000002384185791)
          this.mypos.Y = this.scaler + this.groundHeight;
      }
      this.transform = Matrix.CreateScale(this.scale.X, this.scale.Y, this.scale.Z) * this.myRot * Matrix.CreateTranslation(this.mypos);
    }

    private static void GetHeightFast(
      float[,] heights,
      Vector2 position,
      out float height,
      out Vector3 normal)
    {
      int index1 = (int) MathHelper.Clamp(position.X / invDupe.unit, 0.0f, (float) (invDupe.bitmap - 2));
      int index2 = (int) MathHelper.Clamp(position.Y / invDupe.unit, 0.0f, (float) (invDupe.bitmap - 2));
      float num1 = position.X % invDupe.unit / invDupe.unit;
      float num2 = position.Y % invDupe.unit / invDupe.unit;
      float num3 = (float) ((1.0 - (double) num1) * (double) heights[index1, index2] + (double) num1 * (double) heights[index1 + 1, index2]);
      float num4 = (float) ((1.0 - (double) num1) * (double) heights[index1, index2 + 1] + (double) num1 * (double) heights[index1 + 1, index2 + 1]);
      height = (float) ((1.0 - (double) num2) * (double) num3 + (double) num2 * (double) num4);
      normal = Vector3.Normalize(new Vector3(-heights[index1 + 1, index2] + heights[index1, index2], 30f, -heights[index1, index2 + 1] + heights[index1, index2]));
    }
  }
}
