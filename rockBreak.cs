// Decompiled with JetBrains decompiler
// Type: Blood.rockBreak
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;
using System;

#nullable disable
namespace Blood
{
  internal class rockBreak
  {
    public Matrix myRot;
    public bool move;
    public Vector3 mypos;
    private float groundHeight;
    private Vector3 delta;
    public Vector3 velocity;
    public Vector3 oldpos;
    public float scaler;
    public Matrix Transform;
    public int hits;
    public int onramp;
    public int mycolor;
    private Random random;
    public int mytime;
    private int breakodds;
    private int gravflag;
    private float grav = -0.35f;
    private ScreenManager sc;

    public rockBreak(
      ScreenManager scc,
      Vector3 startpos,
      float scale,
      Matrix rot,
      Vector3 vel,
      int rampflag,
      bool cansplit)
    {
      this.sc = scc;
      this.random = new Random(Math.Abs((int) startpos.X * 57));
      this.gravflag = 1;
      this.mytime = this.random.Next(90, 140);
      this.scaler = scale;
      this.myRot = rot;
      this.mypos = new Vector3(startpos.X, startpos.Y + this.scaler * 18f, startpos.Z);
      this.velocity = vel;
      this.Transform = this.myRot * Matrix.CreateScale(this.scaler) * Matrix.CreateTranslation(this.mypos);
      this.oldpos = this.mypos;
      this.onramp = rampflag;
      this.move = true;
      this.breakodds = 0;
      if (cansplit)
        this.breakodds = this.random.Next(0, 4);
      this.grav = (float) (-(double) this.random.Next(310, 500) / 1000.0);
    }

    public void Update(ref int[,] heightData)
    {
      this.mypos.X += this.velocity.X;
      this.mypos.Y += this.velocity.Y;
      this.mypos.Z += this.velocity.Z;
      if (this.onramp == 5)
      {
        --this.mytime;
        this.velocity /= 1.009f;
        this.GetHeight(ref heightData, this.mypos, out this.groundHeight);
        if (this.gravflag == 1)
          this.velocity += new Vector3(0.0f, this.grav, 0.0f);
        float num = Vector3.Distance(this.mypos, this.oldpos);
        this.delta.X = this.oldpos.X - this.mypos.X;
        this.delta.Y = 0.0f;
        this.delta.Z = this.oldpos.Z - this.mypos.Z;
        if ((double) this.delta.LengthSquared() > 0.0)
          this.myRot *= Matrix.CreateFromAxisAngle(Vector3.Cross(Vector3.Normalize(this.delta), Vector3.Up), num / (float) (15.0 + (double) this.scaler * 14.0));
        if ((double) this.mypos.Y <= (double) this.groundHeight + (double) this.scaler * 14.0 || (double) this.velocity.Y == 0.0)
        {
          this.velocity.Y = (float) (-(double) this.velocity.Y * 0.60000002384185791);
          if ((double) Math.Abs(this.velocity.Y) < 1.0)
          {
            this.velocity.Y = 0.0f;
            this.gravflag = 0;
          }
          if (this.mytime <= 0 || (double) Vector2.Distance(Vector2.Zero, new Vector2(this.velocity.X, this.velocity.Z)) < 0.10000000149011612)
          {
            this.move = true;
            this.onramp = 7;
            this.mytime = 260;
            this.velocity.Y = -Math.Abs(this.velocity.Y);
          }
          this.mypos.Y = this.groundHeight + this.scaler * 14f;
        }
        if (this.breakodds == 1)
        {
          this.move = false;
          this.onramp = 10;
          this.velocity.Y = -Math.Abs(this.velocity.Y);
        }
      }
      if (this.onramp == 7)
      {
        --this.mytime;
        this.GetHeight(ref heightData, this.mypos, out this.groundHeight);
        this.velocity = new Vector3(this.velocity.X /= 1.008f, -1f, this.velocity.Z /= 1.008f);
        float num = Vector3.Distance(this.mypos, this.oldpos);
        this.delta.X = this.oldpos.X - this.mypos.X;
        this.delta.Y = 0.0f;
        this.delta.Z = this.oldpos.Z - this.mypos.Z;
        if ((double) this.delta.LengthSquared() > 0.0)
          this.myRot *= Matrix.CreateFromAxisAngle(Vector3.Cross(Vector3.Normalize(this.delta), Vector3.Up), num / (float) (15.0 + (double) this.scaler * 14.0));
        if (this.mytime <= 0)
        {
          this.velocity = Vector3.Zero;
          this.move = false;
          this.onramp = 0;
        }
      }
      this.oldpos.X = this.mypos.X;
      this.oldpos.Y = this.mypos.Y;
      this.oldpos.Z = this.mypos.Z;
      this.Transform = this.myRot * (Matrix.CreateScale(this.scaler) * Matrix.CreateTranslation(this.mypos));
      this.Transform.M42 = (float) Math.Sign(this.Transform.M42) * ((float) Math.Abs((int) this.Transform.M42) + (float) this.mycolor * (1f / 1000f));
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
      float amount1 = vector3.X % (float) gridScale / (float) gridScale;
      float amount2 = vector3.Z % (float) gridScale / (float) gridScale;
      int index3 = index1 + 1;
      int index4 = index2 + 1;
      if (index3 > bitmap - 2)
        index3 = 0;
      if (index4 > bitmap - 2)
        index4 = 0;
      float num2 = MathHelper.Lerp((float) heightData[index1, index2], (float) heightData[index3, index2], amount1);
      float num3 = MathHelper.Lerp((float) heightData[index1, index4], (float) heightData[index3, index4], amount1);
      height = MathHelper.Lerp(num2, num3, amount2);
    }
  }
}
