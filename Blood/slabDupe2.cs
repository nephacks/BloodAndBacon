using Microsoft.Xna.Framework;
using System;

#pragma warning disable CS0649
#pragma warning disable CS0169
#nullable disable
namespace Blood
{
  internal class slabDupe2
  {
    public Matrix myRot;
    public bool move;
    public Vector3 mypos;
    private float groundHeight;
    private Vector3 normal;
    private Vector3 rot;
    private Vector3 delta;
    public Vector3 grav;
    public Vector3 oldpos;
    public float scaler;
    private int stateFlag;
    public int locationIndex;
    public Matrix Transform;
    public int hits;
    public Random rr;

    public slabDupe2(int val) => this.rr = new Random(val);

    public void init(Vector3 startpos, Vector3 normal, float scaleSize, int val)
    {
      this.rr = new Random(val);
      this.scaler = (float) this.rr.Next(150, 250) / 100f;
      this.scaler *= scaleSize;
      this.mypos = new Vector3(startpos.X, startpos.Y, startpos.Z);
      Vector3 scales = new Vector3((float) this.rr.Next(90, 110) / 100f, 1f, (float) this.rr.Next(90, 110) / 100f) * this.scaler;
      Matrix rotationY = Matrix.CreateRotationY((float) this.rr.Next(-1000, 1000) / 100f) with
      {
        Up = normal
      };
      rotationY.Right = Vector3.Cross(rotationY.Forward, rotationY.Up);
      rotationY.Right = Vector3.Normalize(rotationY.Right);
      rotationY.Forward = Vector3.Cross(rotationY.Up, rotationY.Right);
      rotationY.Forward = Vector3.Normalize(rotationY.Forward);
      this.myRot = rotationY;
      this.Transform = Matrix.CreateScale(scales) * Matrix.CreateTranslation(new Vector3(0.0f, this.scaler / 2.2f, 0.0f)) * this.myRot * Matrix.CreateTranslation(this.mypos);
      this.oldpos = this.mypos;
    }
  }
}
