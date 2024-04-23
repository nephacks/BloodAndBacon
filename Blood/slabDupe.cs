// Decompiled with JetBrains decompiler
// Type: Blood.slabDupe
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;
using System;

#nullable disable
namespace Blood
{
  internal class slabDupe
  {
    public Matrix myRot;
    public bool move;
    public Vector3 mypos;
    private Vector3 normal;
    private Vector3 delta;
    public Vector3 grav;
    public Vector3 oldpos;
    public float scaler;
    private int stateFlag;
    public int locationIndex;
    public Matrix Transform;
    public int hits;
    public Random rr;

    public slabDupe(int val) => this.rr = new Random(val);

    public void init(Vector3 startpos, Vector3 normal, int val)
    {
      this.rr = new Random(val);
      this.scaler = (float) this.rr.Next(120, 240) / 100f;
      this.mypos = new Vector3(startpos.X, startpos.Y, startpos.Z);
      this.hits = this.rr.Next(5, 15);
      if ((double) this.scaler < 4.0)
        this.hits = this.rr.Next(0, 4);
      this.hits = this.rr.Next(1, 3);
      Matrix rotationY = Matrix.CreateRotationY((float) this.rr.Next(0, 1000) / 100f) with
      {
        Up = normal
      };
      rotationY.Right = Vector3.Cross(rotationY.Forward, rotationY.Up);
      rotationY.Right = Vector3.Normalize(rotationY.Right);
      rotationY.Forward = Vector3.Cross(rotationY.Up, rotationY.Right);
      rotationY.Forward = Vector3.Normalize(rotationY.Forward);
      this.myRot = rotationY;
      this.Transform = Matrix.CreateTranslation(new Vector3(0.0f, this.scaler / 2f, 0.0f)) * this.myRot * Matrix.CreateScale(this.scaler) * Matrix.CreateTranslation(this.mypos);
      this.oldpos = this.mypos;
    }
  }
}
