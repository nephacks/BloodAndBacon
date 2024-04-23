// Decompiled with JetBrains decompiler
// Type: Blood.gemDupe
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;
using System;

#nullable disable
namespace Blood
{
  internal class gemDupe
  {
    public Matrix myRot;
    public bool move;
    public Vector3 mypos;
    private Random random;
    public float groundHeight;
    public Vector3 normal;
    private Vector3 delta;
    public Vector3 oldpos;
    public float scaler;
    public Vector3 velocity = Vector3.Zero;
    public int onramp;
    public Matrix rampy = Matrix.Identity;
    public Matrix transform;
    public int locationIndex;
    public int transIndex;
    private ScreenManager sc;

    public gemDupe(ScreenManager scc, Vector3 startpos, Vector3 veloc, bool mybool, int j)
    {
      this.sc = scc;
      this.move = mybool;
      this.random = new Random(j * 5);
      if (this.move)
        this.onramp = 5;
      this.myRot = Matrix.CreateFromYawPitchRoll((float) this.random.Next(0, 880000) / 900f, (float) this.random.Next(0, 880000) / 900f, (float) this.random.Next(0, 880000) / 900f);
      this.scaler = (float) this.random.Next(300, 700) / 100f;
      this.velocity = !this.move ? Vector3.Zero : veloc + new Vector3((float) this.random.Next(-10000, 10000) / 8000f, 0.0f, (float) this.random.Next(-10000, 10000) / 8000f);
      this.normal = new Vector3((float) this.random.Next(-100, 100) / 700f, 1f, (float) this.random.Next(-100, 100) / 700f);
      this.mypos = new Vector3(startpos.X, startpos.Y, startpos.Z);
      this.transform = Matrix.CreateScale(this.scaler) * this.myRot * Matrix.CreateTranslation(this.mypos) * this.rampy;
      this.oldpos = this.mypos;
    }

    public void Update(ref int[,] heightData)
    {
      if (this.onramp != 3)
      {
        this.mypos.X += this.velocity.X;
        this.mypos.Y += this.velocity.Y;
        this.mypos.Z += this.velocity.Z;
        if (this.onramp == 5)
        {
          this.GetHeight(ref heightData, this.mypos, out this.groundHeight);
          this.velocity += new Vector3(0.0f, -0.35f, 0.0f);
          float num = Vector3.Distance(this.mypos, this.oldpos);
          this.delta.X = this.oldpos.X - this.mypos.X;
          this.delta.Y = 0.0f;
          this.delta.Z = this.oldpos.Z - this.mypos.Z;
          if ((double) this.delta.LengthSquared() > 0.0)
            this.myRot *= Matrix.CreateFromAxisAngle(Vector3.Cross(Vector3.Normalize(this.delta), Vector3.Up), num / (float) (2.0 + (double) this.scaler * 2.0));
          if ((double) this.mypos.Y < (double) this.groundHeight + (double) this.scaler)
          {
            this.velocity = Vector3.Reflect(this.velocity, this.normal) * 0.3f;
            if ((double) this.groundHeight + (double) this.scaler - (double) this.mypos.Y < 0.60000002384185791)
            {
              this.velocity = Vector3.Zero;
              this.onramp = 0;
            }
            this.mypos.Y = this.groundHeight + this.scaler;
          }
        }
        if (this.onramp == 1)
        {
          float num = Vector3.Distance(this.mypos, this.oldpos);
          this.delta.X = this.oldpos.X - this.mypos.X;
          this.delta.Y = 0.0f;
          this.delta.Z = this.oldpos.Z - this.mypos.Z;
          if ((double) this.delta.LengthSquared() > 0.0)
            this.myRot *= Matrix.CreateFromAxisAngle(Vector3.Cross(Vector3.Normalize(this.delta), Vector3.Up), num / (float) (2.0 + (double) this.scaler * 2.0));
          if ((double) this.mypos.Y < (double) this.groundHeight + (double) this.scaler)
          {
            this.velocity = Vector3.Reflect(this.velocity, this.normal);
            this.mypos.Y = this.groundHeight + this.scaler;
          }
        }
        if (this.onramp == 2)
        {
          float num = Vector3.Distance(this.mypos, this.oldpos);
          this.delta.X = this.oldpos.X - this.mypos.X;
          this.delta.Y = 0.0f;
          this.delta.Z = this.oldpos.Z - this.mypos.Z;
          if ((double) this.delta.LengthSquared() > 0.0)
            this.myRot *= Matrix.CreateFromAxisAngle(Vector3.Cross(Vector3.Normalize(this.delta), Vector3.Up), num / (float) (1.0 + (double) this.scaler * 2.0));
          if ((double) this.mypos.Y < (double) this.groundHeight + (double) this.scaler)
          {
            this.velocity = Vector3.Reflect(this.velocity, this.normal) / 1.5f;
            if ((double) this.groundHeight + (double) this.scaler - (double) this.mypos.Y < 0.20000000298023224)
            {
              this.velocity.Y = 0.0f;
              this.onramp = 3;
            }
            this.mypos.Y = this.groundHeight + this.scaler;
          }
        }
        this.oldpos.X = this.mypos.X;
        this.oldpos.Y = this.mypos.Y;
        this.oldpos.Z = this.mypos.Z;
      }
      this.transform = Matrix.CreateScale(this.scaler) * this.myRot * Matrix.CreateTranslation(this.mypos) * this.rampy;
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
