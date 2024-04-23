// Decompiled with JetBrains decompiler
// Type: Blood.multiply
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;

#nullable disable
namespace Blood
{
  public class multiply
  {
    private Matrix m1;
    private Matrix m2;
    private Matrix m3;
    private Matrix m4;
    private Matrix r1;
    private Matrix r2;
    private Matrix r3;
    private Matrix result;

    public Matrix rotX(float x, ref Matrix m)
    {
      Matrix.CreateRotationX(x, out this.m1);
      Matrix.Multiply(ref this.m1, ref m, out this.result);
      return this.result;
    }

    public Matrix rotY(float y, ref Matrix m)
    {
      Matrix.CreateRotationY(y, out this.m1);
      Matrix.Multiply(ref this.m1, ref m, out this.result);
      return this.result;
    }

    public Matrix rotZ(float z, ref Matrix m)
    {
      Matrix.CreateRotationY(z, out this.m1);
      Matrix.Multiply(ref this.m1, ref m, out this.result);
      return this.result;
    }

    public Matrix rotXY(float x, float y, ref Matrix m)
    {
      Matrix.CreateRotationX(x, out this.m1);
      Matrix.CreateRotationY(y, out this.m2);
      Matrix.Multiply(ref this.m1, ref this.m2, out this.m3);
      Matrix.Multiply(ref this.m3, ref m, out this.result);
      return this.result;
    }

    public Matrix rotXZ(float x, float z, ref Matrix m)
    {
      Matrix.CreateRotationX(x, out this.m1);
      Matrix.CreateRotationZ(z, out this.m2);
      Matrix.Multiply(ref this.m1, ref this.m2, out this.m3);
      Matrix.Multiply(ref this.m3, ref m, out this.result);
      return this.result;
    }

    public Matrix rotYX(float y, float x, ref Matrix m)
    {
      Matrix.CreateRotationY(y, out this.m1);
      Matrix.CreateRotationX(x, out this.m2);
      Matrix.Multiply(ref this.m1, ref this.m2, out this.m3);
      Matrix.Multiply(ref this.m3, ref m, out this.result);
      return this.result;
    }

    public Matrix rotYZ(float y, float z, ref Matrix m)
    {
      Matrix.CreateRotationY(y, out this.m1);
      Matrix.CreateRotationZ(z, out this.m2);
      Matrix.Multiply(ref this.m1, ref this.m2, out this.m3);
      Matrix.Multiply(ref this.m3, ref m, out this.result);
      return this.result;
    }

    public Matrix rotZX(float z, float x, ref Matrix m)
    {
      Matrix.CreateRotationZ(z, out this.m1);
      Matrix.CreateRotationX(x, out this.m2);
      Matrix.Multiply(ref this.m1, ref this.m2, out this.m3);
      Matrix.Multiply(ref this.m3, ref m, out this.result);
      return this.result;
    }

    public Matrix rotZY(float z, float y, ref Matrix m)
    {
      Matrix.CreateRotationZ(z, out this.m1);
      Matrix.CreateRotationY(y, out this.m2);
      Matrix.Multiply(ref this.m1, ref this.m2, out this.m3);
      Matrix.Multiply(ref this.m3, ref m, out this.result);
      return this.result;
    }

    public Matrix rotXYZ(float x, float y, float z, ref Matrix m)
    {
      Matrix.CreateRotationX(x, out this.m1);
      Matrix.CreateRotationY(y, out this.m2);
      Matrix.CreateRotationZ(z, out this.m3);
      Matrix.Multiply(ref this.m1, ref this.m2, out this.r1);
      Matrix.Multiply(ref this.r1, ref this.m3, out this.r2);
      Matrix.Multiply(ref this.r2, ref m, out this.result);
      return this.result;
    }

    public Matrix rotZXY(float z, float x, float y, ref Matrix m)
    {
      Matrix.CreateRotationZ(z, out this.m1);
      Matrix.CreateRotationX(x, out this.m2);
      Matrix.CreateRotationY(y, out this.m3);
      Matrix.Multiply(ref this.m1, ref this.m2, out this.r1);
      Matrix.Multiply(ref this.r1, ref this.m3, out this.r2);
      Matrix.Multiply(ref this.r2, ref m, out this.result);
      return this.result;
    }
  }
}
