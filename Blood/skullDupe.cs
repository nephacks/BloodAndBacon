using Microsoft.Xna.Framework;
using System;

#pragma warning disable CS0169
#nullable disable
namespace Blood
{
  public class skullDupe
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
    public int drop;
    public int dropnow;
    public bool itBleeds;
    public bool kickable;
    private Vector3 delta;
    public static int bleed = 260;
    public static int bitmap;
    public static float unit;
    private Vector3 scale0;
    private Quaternion rotation0;
    private Quaternion rotation1;
    private Vector3 position0;
    public int group = 1;
    private float gravity;
    public float ratio;
    public float bounce;
    public Vector3 scale;
    private float groundHeight;
    public Matrix myRot;
    public Matrix inertRot;
    public Matrix oldRot;
    public float sloper;
    public float turnRate = 0.3f;
    public int move;
    public bool canhurt;
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
    public Matrix rot;
    private float result;
    public int seed;
    public Random rr = new Random();
    private int count;
    private int sizer = 1;
    private int startin;
    private float lerper = 1f;
    private float grower = 0.5f;
    public float floor = -305f;
    public bool pop;

    public skullDupe(int i) => this.rr = new Random(i);

    public void init(
      int seeder,
      Vector3 scal,
      Vector3 pos,
      Matrix rot,
      Vector3 veloc,
      int move,
      float floor,
      int tinter)
    {
      this.rr = new Random(seeder);
      this.seed = 0;
      this.gravity = -0.2f;
      this.kickable = true;
      this.alive = 0;
      this.firstHit = 0;
      this.move = move;
      if (move == 3)
        this.canhurt = true;
      this.startin = this.rr.Next(30, 460);
      this.grower = (float) this.rr.Next(50, 82) / 100f;
      this.lerper = 1f;
      this.turnRate = (float) this.rr.Next(320, 500) / 1000f * this.scale.X;
      this.inertRot = Matrix.CreateFromAxisAngle(Vector3.Normalize(Vector3.Cross(-veloc, Vector3.Up)), this.turnRate);
      this.floor = floor;
      this.ratio = 1f;
      this.bounce = (float) this.rr.Next(25, 60) / 100f;
      this.mypos = pos;
      this.scale = scal;
      this.rot = rot;
      this.myRot = rot;
      this.tint = (float) tinter;
      this.velocity = veloc;
      this.oldY = this.mypos.Y;
      this.oldpos = this.mypos;
      this.oldRot = this.myRot;
      this.transform = Matrix.CreateScale(scal) * rot * Matrix.CreateTranslation(pos);
    }

    public void init2(
      int size,
      int group,
      float bounce,
      Vector3 scale,
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
      bool kickable)
    {
      this.sizer = size;
      this.lastKicked = 0;
      this.ratio = ratio;
      this.scale = scale;
      this.bounce = bounce;
      this.localShell = localShell;
      this.randBounce = rbounce;
      this.landupright = false;
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
      this.velocity = this.move <= 0 ? Vector3.Zero : veloc;
      this.mypos = Vector3.Transform(Vector3.Zero, startpos);
      this.transform = Matrix.CreateScale(scale) * this.myRot * Matrix.CreateTranslation(this.mypos);
      this.oldY = this.mypos.Y;
      this.oldpos = this.mypos;
      this.oldRot = this.myRot;
    }

    public void Update(ref float[,] heights)
    {
      if (this.move == 1)
      {
        this.oldY = this.mypos.Y;
        this.mypos.X += this.velocity.X;
        this.mypos.Y += this.velocity.Y;
        this.mypos.Z += this.velocity.Z;
        this.velocity.Y += this.gravity;
        if ((double) this.velocity.Y < -8.0)
          this.velocity.Y = -8f;
        Matrix.Multiply(ref this.myRot, ref this.inertRot, out this.myRot);
        skullDupe.GetHeightSlow(ref heights, ref this.mypos, out this.groundHeight, out this.normal);
        this.scaler = this.scale.X * (float) this.sizer;
        if ((double) this.mypos.Y < (double) this.scaler + (double) this.groundHeight || (double) this.sloper > 0.0)
        {
          ++this.firstHit;
          Vector3 vector3 = new Vector3((float) this.rr.Next(-this.randBounce, this.randBounce) / 500f, 0.0f, (float) this.rr.Next(-this.randBounce, this.randBounce) / 500f);
          if ((double) Math.Abs(this.velocity.Y) <= 2.0 && (double) Math.Abs(this.scaler + this.groundHeight - this.mypos.Y) <= 5.0)
            this.velocity *= new Vector3(0.75f, 0.0f, 0.75f);
          else
            this.velocity = Vector3.Reflect(this.velocity, this.normal + vector3) * new Vector3(0.91f, this.bounce, 0.91f);
          if ((double) this.normal.Y < 0.949999988079071)
            this.velocity += new Vector3(this.normal.X, 0.0f, this.normal.Z);
          this.turnRate = Math.Max(Math.Abs(this.turnRate), 0.05f);
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
              this.sloper += 0.1f;
          }
          if ((double) this.sloper >= 1.0)
          {
            this.velocity = Vector3.Zero;
            this.move = 2;
            this.sloper = 0.0f;
          }
          if ((double) this.scaler + (double) this.groundHeight <= (double) this.mypos.Y + 5.0)
            this.mypos.Y = this.scaler + this.groundHeight;
        }
      }
      if (this.move == 2)
      {
        this.scaler = this.scale.X * (float) this.sizer;
        this.scale *= 0.99f;
        skullDupe.GetHeightSlow(ref heights, ref this.mypos, out this.groundHeight, out this.normal);
        if ((double) this.scaler + (double) this.groundHeight <= (double) this.mypos.Y + 5.0)
          this.mypos.Y = this.scaler + this.groundHeight;
        if ((double) this.scale.Y < 0.05000000074505806)
          this.move = -1;
      }
      Matrix.CreateScale(this.scale.Y, out this.m1);
      Matrix.CreateTranslation(this.mypos.X, this.mypos.Y, this.mypos.Z, out this.m4);
      Matrix.Multiply(ref this.m1, ref this.myRot, out this.m3);
      Matrix.Multiply(ref this.m3, ref this.m4, out this.transform);
    }

    public void updateSkullHead(ref float[,] heights)
    {
      if (this.move == 1)
      {
        ++this.alive;
        --this.startin;
        if (this.startin <= 0)
        {
          this.lerper *= this.grower;
          Vector3 scales = (1f - this.lerper) * this.scale;
          float num = 34f * scales.Y * this.lerper;
          this.transform = Matrix.CreateScale(scales) * this.rot * Matrix.CreateTranslation(this.mypos.X, this.mypos.Y - num, this.mypos.Z);
          if ((double) this.lerper < 1.0 / 1000.0)
          {
            this.move = 0;
            this.pop = true;
          }
        }
        else
          this.transform = Matrix.CreateScale(3f / 500f) * this.rot * Matrix.CreateTranslation(this.mypos.X, this.mypos.Y, this.mypos.Z);
      }
      if (this.move == 33)
      {
        ++this.alive;
        this.oldY = this.mypos.Y;
        this.mypos.X += this.velocity.X;
        this.mypos.Y += this.velocity.Y;
        this.mypos.Z += this.velocity.Z;
        this.velocity.Y += this.gravity;
        if ((double) this.velocity.Y < -9.0)
          this.velocity.Y = -9f;
        skullDupe.GetHeightSlow(ref heights, ref this.mypos, out this.groundHeight, out this.normal);
        if (this.alive < 14)
          this.groundHeight = -2000f;
        float num = Vector2.Distance(new Vector2(this.mypos.X, this.mypos.Z), new Vector2(this.oldpos.X, this.oldpos.Z));
        this.delta.X = this.oldpos.X - this.mypos.X;
        this.delta.Y = 0.0f;
        this.delta.Z = this.oldpos.Z - this.mypos.Z;
        if (this.alive > 25 && (double) this.delta.Length() > 0.10000000149011612)
          this.myRot *= Matrix.CreateFromAxisAngle(Vector3.Cross(Vector3.Normalize(this.delta), Vector3.Up), num / (34f * this.scale.X));
        this.scaler = this.scale.X * 31f;
        if ((double) this.mypos.Y < (double) this.scaler + (double) this.groundHeight || (double) this.sloper > 0.0)
        {
          ++this.firstHit;
          Vector3 vector3 = new Vector3((float) this.rr.Next(-10, 10) / 300f, 0.0f, (float) this.rr.Next(-10, 10) / 300f);
          if ((double) Math.Abs(this.velocity.Y) <= 2.0 && (double) Math.Abs(this.scaler + this.groundHeight - this.mypos.Y) <= 5.0)
            this.velocity *= new Vector3(0.96f, 0.0f, 0.96f);
          else
            this.velocity = Vector3.Reflect(this.velocity, this.normal + vector3) * new Vector3(0.81f, this.bounce, 0.81f);
          if ((double) this.normal.Y < 0.949999988079071)
            this.velocity += new Vector3(this.normal.X, 0.0f, this.normal.Z) * 0.8f;
          if (((double) Math.Abs(this.velocity.X) + (double) Math.Abs(this.velocity.Z) < 0.20000000298023224 || (double) this.sloper > 0.0) && (double) this.sloper < 1.0)
          {
            this.itBleeds = false;
            this.sloper += 0.2f;
          }
          if ((double) this.sloper >= 1.0)
          {
            this.velocity = Vector3.Zero;
            this.move = 0;
            this.canhurt = false;
            this.sloper = 0.0f;
          }
          if ((double) this.floor > -320.0)
          {
            if ((double) this.mypos.Y < (double) this.floor + (double) this.scaler)
              this.mypos.Y = this.floor + this.scaler;
          }
          else if ((double) this.scaler + (double) this.groundHeight <= (double) this.mypos.Y + 5.0)
            this.mypos.Y = this.scaler + this.groundHeight;
        }
        this.oldpos.X = this.mypos.X;
        this.oldpos.Y = this.mypos.Y;
        this.oldpos.Z = this.mypos.Z;
        this.transform = Matrix.CreateScale(this.scale) * this.myRot * Matrix.CreateTranslation(this.mypos.X, this.mypos.Y, this.mypos.Z);
      }
      if (this.move != 3)
        return;
      ++this.alive;
      this.oldY = this.mypos.Y;
      this.mypos.X += this.velocity.X;
      this.mypos.Y += this.velocity.Y;
      this.mypos.Z += this.velocity.Z;
      this.velocity.Y += this.gravity;
      if ((double) this.velocity.Y < -17.0)
        this.velocity.Y = -17f;
      float num1 = Vector2.Distance(new Vector2(this.mypos.X, this.mypos.Z), new Vector2(this.oldpos.X, this.oldpos.Z));
      this.delta.X = this.oldpos.X - this.mypos.X;
      this.delta.Y = 0.0f;
      this.delta.Z = this.oldpos.Z - this.mypos.Z;
      if (this.alive > 25 && (double) this.delta.Length() > 0.10000000149011612)
      {
        this.turnRate = Math.Min(num1 / (40f * this.scale.X), 0.35f);
        this.myRot *= Matrix.CreateFromAxisAngle(Vector3.Cross(Vector3.Normalize(this.delta), Vector3.Up), this.turnRate);
      }
      else if (this.alive <= 25)
      {
        this.turnRate = Math.Max(Math.Abs(this.turnRate), 0.35f);
        this.inertRot = Matrix.CreateFromAxisAngle(Vector3.Normalize(Vector3.Cross(-this.velocity, Vector3.Up)), this.turnRate);
        Matrix.Multiply(ref this.myRot, ref this.inertRot, out this.myRot);
      }
      skullDupe.GetHeightSlow(ref heights, ref this.mypos, out this.groundHeight, out this.normal);
      if (this.alive < 14)
        this.groundHeight = -2000f;
      this.scaler = this.scale.X * 31f;
      if ((double) this.mypos.Y < (double) this.scaler + (double) this.groundHeight || (double) this.sloper > 0.0)
      {
        ++this.firstHit;
        Vector3 vector3 = new Vector3((float) this.rr.Next(-this.randBounce, this.randBounce) / 400f, 0.0f, (float) this.rr.Next(-this.randBounce, this.randBounce) / 400f);
        if ((double) this.normal.Y < 0.89999997615814209)
          this.velocity = Vector3.Reflect(this.velocity, this.normal + vector3) * new Vector3(0.75f, this.bounce, 0.75f);
        else if ((double) this.normal.Y >= 0.89999997615814209)
          this.velocity = Vector3.Reflect(this.velocity, this.normal + vector3) * new Vector3(0.97f, this.bounce, 0.97f);
        if ((double) Math.Abs(this.velocity.Y) < 1.0)
          this.velocity *= new Vector3(0.98f, 0.0f, 0.98f);
        if ((double) this.mypos.Y - (double) this.groundHeight > 200.0 && (double) this.velocity.Length() > 10.0)
        {
          this.velocity *= new Vector3(0.8f, 1f, 0.8f);
          this.sloper = 0.0f;
        }
        if ((double) this.normal.Y < 0.89999997615814209 && (double) this.velocity.Length() <= 2.0)
        {
          this.velocity += new Vector3(this.normal.X, 0.0f, this.normal.Z) * 1f;
          this.sloper = 0.0f;
        }
        if (((double) this.velocity.Length() <= 1.0 || (double) this.sloper > 0.0) && (double) this.sloper < 1.0 && (double) this.normal.Y > 0.949999988079071)
          this.sloper += 0.1f;
        if ((double) this.sloper >= 1.0)
        {
          this.velocity = Vector3.Zero;
          this.move = 0;
          this.canhurt = false;
          this.sloper = 0.0f;
        }
        if ((double) this.scaler + (double) this.groundHeight <= (double) this.mypos.Y + 5.0)
          this.mypos.Y = this.scaler + this.groundHeight;
      }
      this.oldpos.X = this.mypos.X;
      this.oldpos.Y = this.mypos.Y;
      this.oldpos.Z = this.mypos.Z;
      Matrix.CreateScale(this.scale.X, out this.m1);
      Matrix.CreateTranslation(this.mypos.X, this.mypos.Y, this.mypos.Z, out this.m4);
      Matrix.Multiply(ref this.m1, ref this.myRot, out this.m3);
      Matrix.Multiply(ref this.m3, ref this.m4, out this.transform);
    }

    private static void GetHeightSlow(
      ref float[,] heights,
      ref Vector3 pos,
      out float height,
      out Vector3 normal)
    {
      int index1 = (int) MathHelper.Clamp(pos.X / skullDupe.unit, 0.0f, (float) (skullDupe.bitmap - 2));
      int index2 = (int) MathHelper.Clamp(pos.Z / skullDupe.unit, 0.0f, (float) (skullDupe.bitmap - 2));
      float num1 = pos.X % skullDupe.unit / skullDupe.unit;
      float num2 = pos.Z % skullDupe.unit / skullDupe.unit;
      float num3 = (float) ((1.0 - (double) num1) * (double) heights[index1, index2] + (double) num1 * (double) heights[index1 + 1, index2]);
      float num4 = (float) ((1.0 - (double) num1) * (double) heights[index1, index2 + 1] + (double) num1 * (double) heights[index1 + 1, index2 + 1]);
      height = (float) ((1.0 - (double) num2) * (double) num3 + (double) num2 * (double) num4);
      normal = Vector3.Normalize(new Vector3(-heights[index1 + 1, index2] + heights[index1, index2], 30f, -heights[index1, index2 + 1] + heights[index1, index2]));
    }
  }
}
