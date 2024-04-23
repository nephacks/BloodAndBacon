// Decompiled with JetBrains decompiler
// Type: Blood.objDupe
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;
using System;

#nullable disable
namespace Blood
{
  internal class objDupe
  {
    public static int flowersaved = 0;
    public static int[,] objectData;
    public int objx;
    public int objz;
    public bool onMap;
    public float div = 4f;
    public Matrix myRot;
    public bool move;
    public Vector3 mypos;
    public float gemtype;
    private float groundHeight;
    private Vector3 normal;
    private Vector3 rot;
    private Vector3 delta;
    public Vector3 grav;
    public Vector3 oldpos;
    public float scaler;
    public float finalscale = 1f;
    public int stateFlag;
    private ScreenManager sc;
    public Matrix Transform;
    public int hits;
    public Random rr;
    public float mass = 1f;

    public objDupe(int var) => this.rr = new Random(var);

    public void initflower(Vector3 startpos, ScreenManager scc, int pair, int x, int z)
    {
      this.objx = x;
      this.objz = z;
      this.sc = scc;
      if (this.stateFlag == 0)
        this.stateFlag = 15;
      this.rr = new Random(pair);
      this.div = (float) this.rr.Next(300, 500) / 100f;
      this.move = false;
      this.rot = new Vector3((float) this.rr.Next(-1600, 1600) / 100f, 0.0f, 0.0f);
      this.scaler = (float) this.rr.Next(150, 250) / 100f;
      this.finalscale = (float) this.rr.Next(1100, 2100) / 100f;
      if (this.stateFlag == 10)
        this.scaler = this.finalscale;
      this.hits = 10000;
      this.mass = this.scaler + 300f;
      this.myRot = Matrix.CreateFromYawPitchRoll(this.rot.X, this.rot.Y, this.rot.Z);
      this.mypos = new Vector3(startpos.X, startpos.Y, startpos.Z);
      this.Transform = this.myRot * Matrix.CreateScale(this.scaler) * Matrix.CreateTranslation(this.mypos);
      this.oldpos = this.mypos;
    }

    public void init(bool large, Vector3 startpos, ScreenManager scc, int pair, int x, int z)
    {
      this.objx = x;
      this.objz = z;
      this.sc = scc;
      this.stateFlag = 0;
      this.rr = new Random(pair);
      this.move = false;
      this.rot = new Vector3((float) this.rr.Next(100, 1600) / 100f, (float) this.rr.Next(100, 1600) / 100f, (float) this.rr.Next(100, 1600) / 100f);
      this.scaler = (float) this.rr.Next(110, 260) / 100f;
      this.hits = this.rr.Next(3, 7);
      this.mass = this.scaler + 3f;
      if (large)
      {
        this.scaler = (float) this.rr.Next(110, 130) / 10f;
        this.hits = 50;
        this.mass = this.scaler;
      }
      this.myRot = Matrix.CreateFromYawPitchRoll(this.rot.X, this.rot.Y, this.rot.Z);
      this.mypos = new Vector3(startpos.X, startpos.Y + this.scaler * 25f, startpos.Z);
      this.Transform = this.myRot * Matrix.CreateScale(this.scaler) * Matrix.CreateTranslation(this.mypos);
      this.oldpos = this.mypos;
    }

    public void addObject(int c)
    {
      objDupe.objectData[this.objx, this.objz] = c;
      this.onMap = true;
    }

    public void removeObject()
    {
      objDupe.objectData[this.objx, this.objz] = 0;
      this.onMap = false;
    }

    public void Update(ref int[,] heightData, ref Vector3[,] normals, ref int[,] objectData)
    {
      if (this.stateFlag >= 10)
        return;
      if (this.stateFlag == 0)
      {
        float num1 = 1.3f - this.normal.Y;
        this.grav.Z += (float) ((double) this.normal.Z * (double) num1 * 0.30000001192092896);
        this.grav.X += (float) ((double) this.normal.X * (double) num1 * 0.30000001192092896);
        this.grav.Y -= (float) ((double) this.normal.Y * (double) num1 * 0.30000001192092896);
        this.mypos += this.grav;
        this.grav /= 1.005f;
        this.GetHeight(ref heightData, ref normals, this.mypos, out this.groundHeight, out this.normal);
        this.mypos.Y = this.groundHeight + this.scaler * 25f;
        float num2 = Vector3.Distance(this.mypos, this.oldpos);
        this.delta.X = this.oldpos.X - this.mypos.X;
        this.delta.Y = 1f / 1000f;
        this.delta.Z = this.oldpos.Z - this.mypos.Z;
        if ((double) this.delta.LengthSquared() > 0.0)
          this.myRot *= Matrix.CreateFromAxisAngle(Vector3.Cross(Vector3.Normalize(this.delta), Vector3.Up), num2 / (float) (25.0 + (double) this.scaler * 18.0));
        if ((double) num2 < 1.2000000476837158)
        {
          this.grav.X = 0.0f;
          this.grav.Y = 0.0f;
          this.grav.Z = 0.0f;
          this.move = false;
        }
      }
      if (this.stateFlag == 5)
      {
        this.scaler += 0.4f;
        if ((double) this.scaler >= (double) this.finalscale)
        {
          this.stateFlag = 10;
          ++objDupe.flowersaved;
          this.addObject(8);
          if (objDupe.flowersaved == 3)
            this.sc.tada10.Play(this.sc.voiceVolume, 0.0f, 0.0f);
          if (objDupe.flowersaved > 0)
            this.sc.trophy.win(this.sc.trophy.spaceevent);
          objectData[this.objx, this.objz] = 8;
        }
        this.myRot *= Matrix.CreateRotationY(0.04f);
      }
      this.Transform = this.myRot * Matrix.CreateScale(this.scaler) * Matrix.CreateTranslation(this.mypos);
      this.oldpos.X = this.mypos.X;
      this.oldpos.Y = this.mypos.Y;
      this.oldpos.Z = this.mypos.Z;
    }

    private void GetHeightX(
      ref int[,] heightData,
      ref Vector3[,] normals,
      Vector3 position,
      out float height,
      out Vector3 normal)
    {
      int gridScale = this.sc.gridScale;
      int bitmap = this.sc.bitmap;
      int num1 = (bitmap - 1) * gridScale;
      position.X = (float) ((double) position.X % (double) num1 + 1.5 * (double) num1) % (float) num1;
      position.Z = (float) ((double) position.Z % (double) num1 + 1.5 * (double) num1) % (float) num1;
      Vector3 vector3_1 = position;
      int index1 = (int) vector3_1.X / gridScale;
      int index2 = (int) vector3_1.Z / gridScale;
      float amount1 = vector3_1.X % (float) gridScale / (float) gridScale;
      float amount2 = vector3_1.Z % (float) gridScale / (float) gridScale;
      int index3 = index1 + 1;
      int index4 = index2 + 1;
      if (index3 > bitmap - 2)
        index3 = 0;
      if (index4 > bitmap - 2)
        index4 = 0;
      float num2 = MathHelper.Lerp((float) heightData[index1, index2], (float) heightData[index3, index2], amount1);
      float num3 = MathHelper.Lerp((float) heightData[index1, index4], (float) heightData[index3, index4], amount1);
      height = MathHelper.Lerp(num2, num3, amount2);
      Vector3 vector3_2 = Vector3.Lerp(normals[index1, index2], normals[index3, index2], amount1);
      Vector3 vector3_3 = Vector3.Lerp(normals[index1, index4], normals[index3, index4], amount1);
      normal = Vector3.Lerp(vector3_2, vector3_3, amount2);
      if ((double) normal.LengthSquared() <= 0.0)
        return;
      normal = Vector3.Normalize(normal);
    }

    public void GetHeight(
      ref int[,] heightData,
      ref Vector3[,] normals,
      Vector3 position,
      out float height,
      out Vector3 normal)
    {
      int gridScale = this.sc.gridScale;
      int bitmap = this.sc.bitmap;
      int num1 = (bitmap - 1) * gridScale;
      position.X = (float) ((double) position.X % (double) num1 + 1.5 * (double) num1) % (float) num1;
      position.Z = (float) ((double) position.Z % (double) num1 + 1.5 * (double) num1) % (float) num1;
      Vector3 vector3_1 = position;
      int x1 = (int) vector3_1.X / gridScale;
      int z1 = (int) vector3_1.Z / gridScale;
      float num2 = vector3_1.X % (float) gridScale / (float) gridScale;
      float num3 = vector3_1.Z % (float) gridScale / (float) gridScale;
      int x2 = x1 + 1;
      int z2 = z1 + 1;
      if (x2 > bitmap - 2)
        x2 = 0;
      if (z2 > bitmap - 2)
        z2 = 0;
      Vector3 vector3_2 = new Vector3((float) x1, (float) heightData[x1, z1], (float) z1);
      if ((double) num2 + (double) num3 >= 1.0)
        vector3_2 = new Vector3((float) x2, (float) heightData[x2, z2], (float) z2);
      Vector3 vector3_3 = new Vector3((float) x1, (float) heightData[x1, z2], (float) z2);
      Vector3 vector3_4 = new Vector3((float) x2, (float) heightData[x2, z1], (float) z1);
      Vector2 vector2 = new Vector2(vector3_1.X / (float) gridScale, vector3_1.Z / (float) gridScale);
      float num4 = (float) (((double) vector3_3.Z - (double) vector3_4.Z) * ((double) vector3_2.X - (double) vector3_4.X) + ((double) vector3_4.X - (double) vector3_3.X) * ((double) vector3_2.Z - (double) vector3_4.Z));
      float num5 = (float) (((double) vector3_3.Z - (double) vector3_4.Z) * ((double) vector2.X - (double) vector3_4.X) + ((double) vector3_4.X - (double) vector3_3.X) * ((double) vector2.Y - (double) vector3_4.Z)) / num4;
      float num6 = (float) (((double) vector3_4.Z - (double) vector3_2.Z) * ((double) vector2.X - (double) vector3_4.X) + ((double) vector3_2.X - (double) vector3_4.X) * ((double) vector2.Y - (double) vector3_4.Z)) / num4;
      float num7 = 1f - num5 - num6;
      height = (float) ((double) num5 * (double) vector3_2.Y + (double) num6 * (double) vector3_3.Y + (double) num7 * (double) vector3_4.Y);
      if ((double) num2 + (double) num3 > 1.0)
        vector3_2 = new Vector3((float) x2, (float) heightData[x2, z2], (float) z2);
      vector3_2.Y /= (float) gridScale;
      vector3_3.Y /= (float) gridScale;
      vector3_4.Y /= (float) gridScale;
      Vector3 vector3_5 = vector3_2;
      Vector3 vector3_6 = vector3_3;
      Vector3 vector3_7 = Vector3.Normalize(Vector3.Cross(vector3_4 - vector3_6, vector3_5 - vector3_6));
      if ((double) vector3_7.Y < 0.0)
        vector3_7 = -vector3_7;
      normal = vector3_7;
    }
  }
}
