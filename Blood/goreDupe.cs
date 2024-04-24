using Microsoft.Xna.Framework;
using System;

#pragma warning disable CS0169
#nullable disable
namespace Blood
{
  public class goreDupe
  {
    public Vector3 scale;
    private Matrix m1;
    private Matrix m2;
    private Matrix m3;
    private Matrix m4;
    private Vector3 v1;
    private Vector3 v2;
    public Matrix myRot;
    public Matrix inertRot;
    public float turnRate = 0.3f;
    public int move;
    public Vector3 mypos;
    public Vector3 oldpos;
    public Vector3 normal;
    public Vector3 velocity;
    public Matrix transform;
    public int tint;
    public int age;
    public readonly Random[] rr = new Random[2];
    public float grav = 0.04f;
    private float spiral;
    private float speed;
    private float sucker;
    private Vector3 dump1;
    private Vector3 dump2;
    private Quaternion qq;

    public goreDupe(int i) => this.rr[0] = new Random(i);

    public void init(
      float bounce,
      float scale,
      Vector3 startpos,
      Vector3 veloc,
      float ta,
      float tb,
      bool oblong)
    {
      this.age = 0;
      this.scale = new Vector3(scale, scale, scale);
      this.move = 1;
      if (oblong)
        this.scale = new Vector3(this.scale.X * ((float) this.rr[0].Next(70, 130) / 100f), this.scale.Y, this.scale.Z * ((float) this.rr[0].Next(70, 130) / 100f));
      Matrix.CreateFromYawPitchRoll((float) this.rr[0].Next(-1900, 1800) / 100f, (float) this.rr[0].Next(-1900, 1800) / 100f, (float) this.rr[0].Next(-1900, 1800) / 100f, out this.myRot);
      this.turnRate = (float) this.rr[0].Next((int) ta, (int) tb) / 2000f;
      Matrix.CreateFromYawPitchRoll((float) this.rr[0].NextDouble() * this.turnRate, (float) this.rr[0].NextDouble() * this.turnRate, (float) this.rr[0].NextDouble() * this.turnRate, out this.inertRot);
      this.velocity = veloc;
      this.mypos = startpos;
      Matrix.CreateScale(scale, out this.m1);
      Matrix.CreateTranslation(this.mypos.X, this.mypos.Y, this.mypos.Z, out this.m4);
      Matrix.Multiply(ref this.m1, ref this.myRot, out this.m3);
      Matrix.Multiply(ref this.m3, ref this.m4, out this.transform);
      this.grav = (double) bounce != 0.0 ? bounce : (float) this.rr[0].Next(90, 380) / 100f;
      this.spiral = (float) this.rr[0].Next(120, 160) / 100f;
      this.sucker = (float) this.rr[0].Next(400, 500) / 10f;
      this.speed = (float) this.rr[0].Next(10, 140) / 1000f;
    }

    public void Update(ref float[,] heights)
    {
      this.mypos.X += this.velocity.X;
      this.mypos.Y += this.velocity.Y;
      this.mypos.Z += this.velocity.Z;
      Matrix.Multiply(ref this.myRot, ref this.inertRot, out this.m1);
      this.myRot = this.m1;
      this.velocity.X = -this.grav;
      Vector3 vector3 = new Vector3(0.0f, 70f, 1338f) - new Vector3(0.0f, this.mypos.Y, this.mypos.Z);
      Vector3.Normalize(ref vector3, out this.v1);
      Matrix.CreateRotationX(-this.spiral, out this.m1);
      Vector3.Transform(ref this.v1, ref this.m1, out this.v2);
      this.velocity += this.v2 * this.speed + vector3 / this.sucker;
      this.velocity *= 0.98f;
      if ((double) this.mypos.X < 1700.0)
        this.age = 600;
      Matrix.CreateScale(this.scale.X, this.scale.Y, this.scale.Z, out this.m1);
      Matrix.CreateTranslation(this.mypos.X, this.mypos.Y, this.mypos.Z, out this.m4);
      Matrix.Multiply(ref this.m1, ref this.myRot, out this.m3);
      Matrix.Multiply(ref this.m3, ref this.m4, out this.transform);
    }
  }
}
