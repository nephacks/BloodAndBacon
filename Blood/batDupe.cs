using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

#pragma warning disable CS0169
#nullable disable
namespace Blood
{
  public class batDupe
  {
    public static List<int> sics;
    public int frame1;
    public int tint;
    private int temp1;
    private int clip1;
    private float gravity;
    private float rotz;
    private Random rr;
    private float scale = 1f;
    private Vector3 myaxis;
    public float deathTimer;
    private float dist;
    private float ph;
    public int request;
    public int move;
    public Matrix myRot;
    public Vector3 mypos;
    public Vector3 startpos;
    public Vector3 offset;
    public Vector3 oldpos;
    public int ground;
    public Vector3 velocity;
    public Matrix transform;
    private float batStart;
    private float amp;
    private float freq;
    private float amt;
    private float pathStart;
    public int alreadyBit;
    private int speed = 1;

    public batDupe(
      Vector3 startpos,
      int ground,
      float amt,
      int flag,
      int seed,
      float st,
      int tint)
    {
      this.clip1 = 0;
      this.move = flag;
      this.ground = ground;
      this.pathStart = st;
      this.amt = amt;
      this.rr = new Random(seed);
      this.speed = this.rr.Next(2, 4);
      this.temp1 = this.rr.Next(1, 100);
      this.tint = tint;
      this.batStart = this.pathStart + (float) this.rr.Next(0, 100) / 5000f;
      if ((double) this.batStart > 1.0)
        --this.batStart;
      this.scale = (float) this.rr.Next(40, 130) / 200f;
      this.dist = (float) this.rr.Next(-800, 800) / 100f;
      this.ph = (float) this.rr.Next(4, 12) / 100f;
      this.startpos = startpos;
      this.offset = startpos;
      this.myRot = Matrix.Identity;
      this.transform = this.myRot * Matrix.CreateTranslation(this.mypos);
      this.freq = (float) this.rr.Next(200, 700) / 100f;
      this.amp = (float) this.rr.Next(300, 800) / 250f;
    }

    public void Update(ref Vector3[] batpath)
    {
      this.temp1 += this.speed;
      this.frame1 = this.temp1 % batDupe.sics[this.clip1 * 2] + batDupe.sics[this.clip1 * 2 + 1];
      if (this.move == 0)
      {
        float num1 = (float) (batpath.Length - 1) * this.batStart;
        int index = (int) num1;
        this.batStart += this.amt / (Vector3.Distance(batpath[index], batpath[index + 1]) / 10f);
        if ((double) this.batStart < 1.0)
        {
          this.dist += this.ph;
          this.mypos.X = MathHelper.Lerp(batpath[index].X, batpath[index + 1].X, num1 - (float) index);
          this.mypos.Z = MathHelper.Lerp(batpath[index].Z, batpath[index + 1].Z, num1 - (float) index);
          this.mypos.X += (float) (-Math.Cos((double) this.dist) * 10.0);
          this.mypos.Z += (float) (-Math.Cos((double) this.dist) * 10.0);
          this.mypos.X += 3000f;
          this.mypos.Z += 3000f;
          this.mypos.Y = (float) ((double) MathHelper.Lerp(batpath[index].Y, batpath[index + 1].Y, num1 - (float) index) + (double) this.ground + Math.Sin((double) this.dist * ((double) this.freq / 3.0)) * ((double) this.amp * 2.0));
          this.mypos += this.startpos;
        }
        else
        {
          this.batStart = 0.0f;
          this.startpos = this.offset;
        }
        this.velocity = this.mypos - this.oldpos;
        float num2 = 0.0f;
        if ((double) this.velocity.Z > 0.0)
          num2 = 3.14f;
        float d1 = this.velocity.Y / Vector2.Distance(new Vector2(this.velocity.X, this.velocity.Z), new Vector2(0.0f, 0.0f));
        float d2 = this.velocity.X / this.velocity.Z;
        this.myRot = Matrix.CreateRotationX((float) Math.Atan((double) d1)) * Matrix.CreateRotationY((float) Math.Atan((double) d2) + num2);
        this.oldpos = this.mypos;
      }
      this.transform = Matrix.CreateScale(this.scale) * this.myRot * Matrix.CreateTranslation(this.mypos);
    }
  }
}
