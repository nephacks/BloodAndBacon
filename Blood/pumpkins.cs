using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace Blood
{
  public class pumpkins
  {
    private ScreenManager sc;
    private ContentManager content;
    public static int bitmap;
    public static float unit;
    public int pumpkinIndex = -1;
    public int lastpumpkin = -1;
    private readonly VertexBufferBinding[] _vertexBufferBindings = new VertexBufferBinding[2];
    private static VertexDeclaration instanceDec = new VertexDeclaration(new VertexElement[5]
    {
      new VertexElement(0, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 0),
      new VertexElement(16, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 1),
      new VertexElement(32, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 2),
      new VertexElement(48, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 3),
      new VertexElement(64, VertexElementFormat.Single, VertexElementUsage.Fog, 0)
    });
    private pumpkins.instancedObject[] tempInstance = new pumpkins.instancedObject[1];
    public pumpkins.shell pump;
    public pumpkins.shell p_stem;
    public pumpkins.shell p_base;
    public pumpkins.shell p_rind;
    public pumpkins.shell p_chunk;
    public pumpkins.shell p_bitty;
    private SoundEffect sound1;
    private SoundEffect sound2;
    private SoundEffect sound3;
    private SoundEffect sound4;
    private SoundEffect pop;
    private SoundEffect pop2;
    public int alive;
    private Matrix view;
    private Matrix proj;
    private Random rr;
    private Random rx;

    public pumpkins(ScreenManager ss, ContentManager cc)
    {
      this.rr = new Random();
      this.content = cc;
      this.sc = ss;
      this.pump = new pumpkins.shell();
      this.pump.max = 0;
      this.pump.type = 0;
      this.pump.maxCapacity = 90;
      this.pump.index = 0;
      this.pump.model1 = this.content.Load<Model>("models\\pumpkin");
      this.pump.buffer = new DynamicVertexBuffer(this.sc.GraphicsDevice, pumpkins.instanceDec, this.pump.maxCapacity, BufferUsage.WriteOnly);
      this.pump.displayList = new pumpkins.instancedObject[this.pump.maxCapacity];
      this.pump.dupe = new pumpDupe[this.pump.maxCapacity];
      for (int i = 0; i < this.pump.maxCapacity; ++i)
        this.pump.dupe[i] = new pumpDupe(i);
      this.pump.stream = new pumpkins.instancedObject[this.pump.maxCapacity];
      this.p_stem = new pumpkins.shell();
      this.p_stem.max = 0;
      this.p_stem.type = 1;
      this.p_stem.maxCapacity = 10;
      this.p_stem.index = 0;
      this.p_stem.model1 = this.content.Load<Model>("models\\p_stem");
      int maxCapacity1 = this.p_stem.maxCapacity;
      this.p_stem.buffer = new DynamicVertexBuffer(this.sc.GraphicsDevice, pumpkins.instanceDec, maxCapacity1, BufferUsage.WriteOnly);
      this.p_stem.displayList = new pumpkins.instancedObject[maxCapacity1];
      this.p_stem.dupe = new pumpDupe[maxCapacity1];
      for (int i = 0; i < maxCapacity1; ++i)
        this.p_stem.dupe[i] = new pumpDupe(i);
      this.p_stem.stream = new pumpkins.instancedObject[maxCapacity1];
      this.p_base = new pumpkins.shell();
      this.p_base.max = 0;
      this.p_base.type = 2;
      this.p_base.maxCapacity = 20;
      this.p_base.index = 0;
      this.p_base.model1 = this.content.Load<Model>("models\\p_base");
      int maxCapacity2 = this.p_base.maxCapacity;
      this.p_base.buffer = new DynamicVertexBuffer(this.sc.GraphicsDevice, pumpkins.instanceDec, maxCapacity2, BufferUsage.WriteOnly);
      this.p_base.displayList = new pumpkins.instancedObject[maxCapacity2];
      this.p_base.dupe = new pumpDupe[maxCapacity2];
      for (int i = 0; i < maxCapacity2; ++i)
        this.p_base.dupe[i] = new pumpDupe(i);
      this.p_base.stream = new pumpkins.instancedObject[maxCapacity2];
      this.p_rind = new pumpkins.shell();
      this.p_rind.max = 0;
      this.p_rind.type = 3;
      this.p_rind.maxCapacity = 20;
      this.p_rind.index = 0;
      this.p_rind.model1 = this.content.Load<Model>("models\\p_rind");
      int maxCapacity3 = this.p_rind.maxCapacity;
      this.p_rind.buffer = new DynamicVertexBuffer(this.sc.GraphicsDevice, pumpkins.instanceDec, maxCapacity3, BufferUsage.WriteOnly);
      this.p_rind.displayList = new pumpkins.instancedObject[maxCapacity3];
      this.p_rind.dupe = new pumpDupe[maxCapacity3];
      for (int i = 0; i < maxCapacity3; ++i)
        this.p_rind.dupe[i] = new pumpDupe(i);
      this.p_rind.stream = new pumpkins.instancedObject[maxCapacity3];
      this.p_chunk = new pumpkins.shell();
      this.p_chunk.max = 0;
      this.p_chunk.type = 4;
      this.p_chunk.maxCapacity = 20;
      this.p_chunk.index = 0;
      this.p_chunk.model1 = this.content.Load<Model>("models\\p_chunk");
      int maxCapacity4 = this.p_chunk.maxCapacity;
      this.p_chunk.buffer = new DynamicVertexBuffer(this.sc.GraphicsDevice, pumpkins.instanceDec, maxCapacity4, BufferUsage.WriteOnly);
      this.p_chunk.displayList = new pumpkins.instancedObject[maxCapacity4];
      this.p_chunk.dupe = new pumpDupe[maxCapacity4];
      for (int i = 0; i < maxCapacity4; ++i)
        this.p_chunk.dupe[i] = new pumpDupe(i);
      this.p_chunk.stream = new pumpkins.instancedObject[maxCapacity4];
      this.p_bitty = new pumpkins.shell();
      this.p_bitty.max = 0;
      this.p_bitty.type = 4;
      this.p_bitty.maxCapacity = 20;
      this.p_bitty.index = 0;
      this.p_bitty.model1 = this.content.Load<Model>("models\\p_bitty");
      int maxCapacity5 = this.p_bitty.maxCapacity;
      this.p_bitty.buffer = new DynamicVertexBuffer(this.sc.GraphicsDevice, pumpkins.instanceDec, maxCapacity5, BufferUsage.WriteOnly);
      this.p_bitty.displayList = new pumpkins.instancedObject[maxCapacity5];
      this.p_bitty.dupe = new pumpDupe[maxCapacity5];
      for (int i = 0; i < maxCapacity5; ++i)
        this.p_bitty.dupe[i] = new pumpDupe(i);
      this.p_bitty.stream = new pumpkins.instancedObject[maxCapacity5];
      this.sound1 = this.content.Load<SoundEffect>("audio\\squash1");
      this.sound2 = this.content.Load<SoundEffect>("audio\\squash2");
      this.sound3 = this.content.Load<SoundEffect>("audio\\squash3");
      this.sound4 = this.content.Load<SoundEffect>("audio\\squash4");
      this.pop = this.content.Load<SoundEffect>("audio\\pop");
      this.pop2 = this.content.Load<SoundEffect>("audio\\pop2");
    }

    public void initPumpkins(int seed, ref float[,] heights)
    {
      this.p_bitty.max = 0;
      this.p_bitty.index = 0;
      this.p_chunk.max = 0;
      this.p_chunk.index = 0;
      this.p_base.max = 0;
      this.p_stem.index = 0;
      this.p_rind.max = 0;
      this.p_rind.index = 0;
      this.p_stem.max = 0;
      this.p_stem.index = 0;
      this.pump.max = 0;
      this.pump.index = 0;
      this.pump.type = 0;
      this.rx = new Random(seed);
      int num = this.rx.Next(9000, 22000);
      for (int index = 0; index < this.pump.maxCapacity; ++index)
      {
        bool inner = true;
        if ((double) index > (double) this.pump.maxCapacity * 0.15000000596046448)
          inner = false;
        this.dropPumpkin(ref this.pump, num + index * 5, ref heights, inner);
      }
    }

    private void dropPumpkin(ref pumpkins.shell sh, int seed, ref float[,] heights, bool inner)
    {
      float num1 = (float) this.rx.Next(35, 80) / 100f;
      if (this.rx.Next(1, 100) < 6)
        num1 = 1.1f;
      Vector3 scal = new Vector3(num1, (float) ((double) num1 * (double) this.rx.Next(70, 110) / 100.0), num1);
      Vector3 pos = new Vector3((float) this.rx.Next(500, 5500), 0.0f, (float) this.rx.Next(500, 5500));
      sh.dupe[sh.index].drop = 0;
      int num2 = this.rx.Next(0, 220);
      if (num2 < 100)
      {
        if (num2 >= 70 && num2 < 100)
          sh.dupe[sh.index].drop = 1;
        else if (num2 >= 45 && num2 < 70)
          sh.dupe[sh.index].drop = 3;
        else if (num2 >= 34 && num2 < 45)
          sh.dupe[sh.index].drop = 2;
        else if (num2 >= 0 && num2 < 34)
          sh.dupe[sh.index].drop = 4;
      }
      if (inner)
      {
        pos = new Vector3((float) this.rx.Next(-1000, 1000), 0.0f, (float) this.rx.Next(-1000, 1000)) + new Vector3(3000f, 0.0f, 3000f);
      }
      else
      {
        int num3 = this.rx.Next(1, 5);
        if (num3 == 1)
          pos = new Vector3((float) this.rx.Next(-2300, 1690), 0.0f, (float) this.rx.Next(-2700, -1560)) + new Vector3(3000f, 0.0f, 3000f);
        if (num3 == 2)
          pos = new Vector3((float) this.rx.Next(1805, 2700), 0.0f, (float) this.rx.Next(-1095, 2300)) + new Vector3(3000f, 0.0f, 3000f);
        if (num3 == 3)
          pos = new Vector3((float) this.rx.Next(-2240, 2300), 0.0f, (float) this.rx.Next(1970, 2700)) + new Vector3(3000f, 0.0f, 3000f);
        if (num3 == 4)
          pos = new Vector3((float) this.rx.Next(-2700, -1844), 0.0f, (float) this.rx.Next(-2376, 1630)) + new Vector3(3000f, 0.0f, 3000f);
      }
      float height;
      Vector3 normal;
      pumpkins.GetHeightFast(ref heights, ref pos, out height, out normal);
      pos.Y = height + 34f * scal.Y;
      Matrix rotationY = Matrix.CreateRotationY((float) this.rx.Next(0, 8000) / 100f) with
      {
        Up = normal
      };
      rotationY.Right = Vector3.Cross(rotationY.Forward, rotationY.Up);
      rotationY.Right = Vector3.Normalize(rotationY.Right);
      rotationY.Forward = Vector3.Cross(rotationY.Up, rotationY.Right);
      rotationY.Forward = Vector3.Normalize(rotationY.Forward);
      Quaternion rotation;
      rotationY.Decompose(out Vector3 _, out rotation, out Vector3 _);
      Quaternion.Normalize(rotation);
      Matrix fromQuaternion = Matrix.CreateFromQuaternion(rotation);
      sh.dupe[sh.index].init(scal, pos, fromQuaternion, seed);
      sh.dupe[sh.index].tint = (float) this.rx.Next(60, 100);
      sh.stream[sh.index].Trans = sh.dupe[sh.index].transform;
      sh.stream[sh.index].tint = sh.dupe[sh.index].tint;
      ++sh.index;
      if (sh.index > sh.maxCapacity - 1)
        sh.index = 0;
      ++sh.max;
      if (sh.max <= sh.maxCapacity - 1)
        return;
      sh.max = sh.maxCapacity;
    }

    public void dropParts(ref pumpkins.shell sh, int i, Matrix m, int seed, int size)
    {
      Random random = new Random(seed);
      float num1 = (float) random.Next(30, 140) / 100f;
      float ta = 80f;
      float tb = 290f;
      int boarSEED = seed;
      int minValue1 = 110;
      int maxValue1 = 330;
      float num2 = 60f;
      int minValue2 = -240;
      int maxValue2 = -90;
      float num3 = 1000f;
      if (this.sc.revengeDay > 0)
      {
        num1 = (float) random.Next(50, 350) / 100f;
        minValue1 = 100;
        maxValue1 = 500;
      }
      Matrix matrix = Matrix.CreateScale(this.pump.dupe[i].scale) * this.pump.dupe[i].rot * Matrix.CreateTranslation(this.pump.dupe[i].mypos);
      Matrix startpos = m * matrix;
      sh.dupe[sh.index].tint = this.pump.dupe[i].tint;
      Vector3 vector3_1 = new Vector3((float) random.Next(-300, 300) / 120f, (float) random.Next(minValue1, maxValue1) / num2, (float) random.Next(-300, 300) / 120f);
      Vector3 vector3_2 = Vector3.Transform(new Vector3(0.0f, 0.0f, 0.0f), m);
      Vector3 vector3_3 = (float) random.Next(100, 300) / 30f * Vector3.Normalize(vector3_2);
      float bounce = (float) random.Next(300, 700) / 1000f;
      float grav = (float) random.Next(minValue2, maxValue2) / num3;
      sh.dupe[sh.index].init2(size, 1, bounce, this.pump.dupe[i].scale, 0.3f, startpos, new Vector3(vector3_3.X + vector3_1.X, vector3_1.Y, vector3_3.Z + vector3_1.Z) * num1, true, grav, 20, ta, tb, false, false, false, boarSEED);
      sh.stream[sh.index].Trans = sh.dupe[sh.index].transform;
      sh.stream[sh.index].tint = sh.dupe[sh.index].tint;
      ++sh.index;
      if (sh.index > sh.maxCapacity - 1)
        sh.index = 0;
      ++sh.max;
      if (sh.max <= sh.maxCapacity - 1)
        return;
      sh.max = sh.maxCapacity;
    }

    public void updatePumpkin(
      ref pumpkins.shell sh,
      float range,
      ref float[,] heights,
      Vector3 campos,
      Vector3 camlookpos,
      ref localPlayer myPlayer,
      ref Cursor genCursor,
      ref Vector2 hitVel,
      float headRot)
    {
      this.lastpumpkin = -1;
      Vector3 vector2_1 = Vector3.Normalize(camlookpos - campos);
      Vector3 vector3_1 = -vector2_1 * 100f + campos;
      range *= range;
      this.pumpkinIndex = -1;
      bool flag1 = false;
      sh.tempindex = 0;
      this.alive = 0;
      for (int i = 0; i < sh.max; ++i)
      {
        if (sh.dupe[i].move != -1)
        {
          bool flag2 = false;
          ++this.alive;
          float result1;
          Vector3.DistanceSquared(ref myPlayer.displayState.npcPosition, ref sh.dupe[i].mypos, out result1);
          if ((double) result1 < (double) range)
          {
            Vector3 vector3_2 = new Vector3(sh.dupe[i].mypos.X, sh.dupe[i].mypos.Y, sh.dupe[i].mypos.Z) - vector3_1;
            Vector3 result2;
            Vector3.Normalize(ref vector3_2, out result2);
            float result3 = 0.0f;
            Vector3.Dot(ref result2, ref vector2_1, out result3);
            if ((double) result3 > (double) this.sc.myfov)
            {
              if (sh.dupe[i].move > 0)
                sh.dupe[i].updatePumpkin();
              sh.stream[i].Trans = sh.dupe[i].transform;
              sh.stream[i].tint = sh.dupe[i].tint;
              sh.displayList[sh.tempindex] = sh.stream[i];
              ++sh.tempindex;
              flag2 = true;
              if (sh.dupe[i].pop)
              {
                if ((double) this.sc.introCamera <= 0.0)
                  this.pop.Play(this.sc.ev * MathHelper.Clamp((float) (1.0 - (Math.Sqrt((double) result1) - 200.0) / 4000.0), 0.2f, 0.8f), 0.0f, 0.0f);
                sh.dupe[i].pop = false;
              }
              if (sh.dupe[i].kickable && !flag1)
              {
                if (myPlayer.gunFired && (double) result3 > 0.949999988079071)
                {
                  float num = 33f;
                  if (genCursor.hitSphere(myPlayer.gunpos, myPlayer.gunlook, sh.dupe[i].mypos, sh.dupe[i].scale.Y * num).HasValue)
                  {
                    float vol = MathHelper.Clamp((float) (1.0 - (Math.Sqrt((double) result1) - 200.0) / 4000.0), 0.2f, 1f);
                    flag1 = true;
                    this.explode(i, ref myPlayer, ref heights, vol);
                    if (this.pump.dupe[i].drop > 0)
                      this.pumpkinIndex = i;
                    ++this.sc.stats_pumpkins;
                  }
                }
                if (!myPlayer.isDown && !myPlayer.gunFired && (double) result1 < 4900.0 * (double) sh.dupe[i].scale.Y)
                {
                  flag1 = true;
                  if ((double) sh.dupe[i].scale.X < 0.64999997615814209)
                  {
                    this.explode(i, ref myPlayer, ref heights, 1f);
                    if (this.pump.dupe[i].drop > 0)
                      this.pumpkinIndex = i;
                    ++this.sc.stats_pumpkins;
                  }
                  else
                  {
                    this.sc.sproing[this.rr.Next(0, 2)].Play((float) ((double) this.sc.ev * (double) this.rr.Next(50, 90) / 100.0), 0.0f, 0.0f);
                    Vector2 vector2_2 = new Vector2(sh.dupe[i].mypos.X, sh.dupe[i].mypos.Z) - new Vector2(myPlayer.displayState.npcPosition.X, myPlayer.displayState.npcPosition.Z);
                    if ((double) vector2_2.Length() > 0.0)
                    {
                      hitVel = -Vector2.Normalize(vector2_2) * 2.5f;
                      hitVel = Vector2.Transform(new Vector2(-hitVel.X, hitVel.Y), Matrix.CreateRotationZ(-headRot));
                    }
                  }
                }
              }
            }
          }
          if (sh.dupe[i].move > 0 && !flag2)
            sh.dupe[i].updatePumpkin();
          this.lastpumpkin = i;
          sh.dupe[i].pop = false;
        }
      }
    }

    public void updatePumpkinParts(
      ref pumpkins.shell sh,
      float range,
      ref float[,] heights,
      Vector3 campos,
      Vector3 camlookpos,
      ref localPlayer myPlayer,
      ref Cursor genCursor)
    {
      Vector3 vector2 = Vector3.Normalize(camlookpos - campos);
      Vector3 vector3_1 = -vector2 * 100f + campos;
      range *= range;
      sh.tempindex = 0;
      int num = 0;
      for (int index = 0; index < sh.max; ++index)
      {
        if (sh.dupe[index].move != -1)
        {
          ++num;
          bool flag = false;
          float result1;
          Vector3.DistanceSquared(ref myPlayer.displayState.npcPosition, ref sh.dupe[index].mypos, out result1);
          if ((double) result1 < (double) range)
          {
            Vector3 vector3_2 = new Vector3(sh.dupe[index].mypos.X, sh.dupe[index].mypos.Y, sh.dupe[index].mypos.Z) - vector3_1;
            Vector3 result2;
            Vector3.Normalize(ref vector3_2, out result2);
            float result3 = 0.0f;
            Vector3.Dot(ref result2, ref vector2, out result3);
            if ((double) result3 > (double) this.sc.myfov)
            {
              if (sh.dupe[index].move > 0)
                sh.dupe[index].Update(ref heights);
              sh.stream[index].Trans = sh.dupe[index].transform;
              sh.stream[index].tint = sh.dupe[index].tint;
              sh.displayList[sh.tempindex] = sh.stream[index];
              ++sh.tempindex;
              flag = true;
            }
          }
          if (sh.dupe[index].move > 0 && !flag)
            sh.dupe[index].Update(ref heights);
        }
      }
      if (num != 0)
        return;
      sh.max = 0;
      sh.index = 0;
    }

    public void explode(int i, ref localPlayer myPlayer, ref float[,] heights, float vol)
    {
      this.pump.dupe[i].move = -1;
      myPlayer.pumpkinID = (byte) i;
      if (this.pump.dupe[i].drop > 0)
      {
        this.pump.dupe[i].dropnow = this.pump.dupe[i].drop;
        this.pop2.Play(this.sc.ev, (float) this.rr.Next(-15, 15) / 100f, 0.0f);
      }
      int num = this.rr.Next(0, 4);
      if (num == 0)
        this.sound1.Play(this.sc.ev * vol, (float) this.rr.Next(-50, 0) / 100f, 0.0f);
      if (num == 1)
        this.sound2.Play(this.sc.ev * vol, (float) this.rr.Next(-50, 0) / 100f, 0.0f);
      if (num == 2)
        this.sound3.Play(this.sc.ev * vol, (float) this.rr.Next(-50, 0) / 100f, 0.0f);
      if (num == 3)
        this.sound4.Play(this.sc.ev * vol, (float) this.rr.Next(-50, 0) / 100f, 0.0f);
      Matrix m1 = Matrix.CreateRotationX(MathHelper.ToRadians(7.26f)) * Matrix.CreateTranslation(1.63f, 40.52f, 2.89f);
      this.dropParts(ref this.p_stem, i, m1, this.pump.dupe[i].seed, 5);
      Matrix m2 = Matrix.CreateRotationY(MathHelper.ToRadians(-5.13f)) * Matrix.CreateTranslation(-15.9f, -1.29f, -14.283f);
      this.dropParts(ref this.p_rind, i, m2, this.pump.dupe[i].seed + 1, 18);
      Matrix m3 = Matrix.CreateRotationY(MathHelper.ToRadians(-20.3f)) * Matrix.CreateTranslation(23.55f, 0.155f, 5.59f);
      this.dropParts(ref this.p_base, i, m3, this.pump.dupe[i].seed + 2, 18);
      Matrix m4 = Matrix.CreateRotationX(MathHelper.ToRadians(0.0f)) * Matrix.CreateRotationY(MathHelper.ToRadians(-46.59f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(181f)) * Matrix.CreateTranslation(-19.07f, -0.92f, 15.73f);
      this.dropParts(ref this.p_base, i, m4, this.pump.dupe[i].seed + 3, 18);
      Matrix translation = Matrix.CreateTranslation(0.76f, 17.35f, 29f);
      this.dropParts(ref this.p_chunk, i, translation, this.pump.dupe[i].seed + 4, 10);
      Matrix m5 = Matrix.CreateRotationX(MathHelper.ToRadians(-166f)) * Matrix.CreateRotationY(MathHelper.ToRadians(-41f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(9f)) * Matrix.CreateTranslation(21.21f, -11.5f, -26.53f);
      this.dropParts(ref this.p_chunk, i, m5, this.pump.dupe[i].seed + 5, 10);
      Matrix m6 = Matrix.CreateRotationX(MathHelper.ToRadians(-165.9f)) * Matrix.CreateRotationY(MathHelper.ToRadians(-3.14f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(186.15f)) * Matrix.CreateTranslation(-2f, 14.7f, -31.3f);
      this.dropParts(ref this.p_chunk, i, m6, this.pump.dupe[i].seed + 6, 10);
      Matrix m7 = Matrix.CreateRotationX(MathHelper.ToRadians(-14.36f)) * Matrix.CreateRotationY(MathHelper.ToRadians(9.5f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(5.5f)) * Matrix.CreateTranslation(-3.26f, -11.96f, -33.03f);
      this.dropParts(ref this.p_bitty, i, m7, this.pump.dupe[i].seed + 7, 5);
      Matrix m8 = Matrix.CreateRotationX(MathHelper.ToRadians(-171.5f)) * Matrix.CreateRotationY(MathHelper.ToRadians(20f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(7.84f)) * Matrix.CreateTranslation(11.7f, -8.2f, 32.9f);
      this.dropParts(ref this.p_bitty, i, m8, this.pump.dupe[i].seed + 8, 5);
      Matrix m9 = Matrix.CreateRotationX(MathHelper.ToRadians(69f)) * Matrix.CreateRotationY(MathHelper.ToRadians(-42.3f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(3.6f)) * Matrix.CreateTranslation(12.43f, 27f, -11.72f);
      this.dropParts(ref this.p_bitty, i, m9, this.pump.dupe[i].seed + 9, 5);
    }

    public void draw(Matrix view, Matrix proj)
    {
      this.view = view;
      this.proj = proj;
      this.DrawInstance(ref this.pump, "fastShader2", 1f);
      this.DrawInstance(ref this.p_stem, "fastShader2", 1f);
      this.DrawInstance(ref this.p_base, "fastShader2", 1f);
      this.DrawInstance(ref this.p_rind, "fastShader2", 1f);
      this.DrawInstance(ref this.p_chunk, "fastShader2", 1f);
      this.DrawInstance(ref this.p_bitty, "fastShader2", 1f);
    }

    private void DrawInstance(ref pumpkins.shell shell, string tech, float light)
    {
      int tempindex = shell.tempindex;
      if (tempindex < 1)
        return;
      ModelMeshPart meshPart = shell.model1.Meshes[0].MeshParts[0];
      shell.buffer.SetData<pumpkins.instancedObject>(shell.displayList, 0, tempindex, SetDataOptions.Discard);
      Effect effect = meshPart.Effect;
      effect.CurrentTechnique = effect.Techniques[tech];
      Vector3 vector3 = Vector3.Normalize(this.sc.moontype) with
      {
        Y = -0.8f
      };
      effect.Parameters["LightDirection2"].SetValue(vector3);
      effect.Parameters["diff2"].SetValue(new Vector3(0.8f, 0.8f, 0.8f));
      effect.Parameters["amb2"].SetValue(new Vector3(0.2f, 0.2f, 0.2f));
      effect.Parameters["View"].SetValue(this.view);
      effect.Parameters["Projection"].SetValue(this.proj);
      effect.CurrentTechnique.Passes[0].Apply();
      this._vertexBufferBindings[0] = new VertexBufferBinding(meshPart.VertexBuffer, meshPart.VertexOffset, 0);
      this._vertexBufferBindings[1] = new VertexBufferBinding((VertexBuffer) shell.buffer, 0, 1);
      this.sc.GraphicsDevice.SetVertexBuffers(this._vertexBufferBindings);
      this.sc.GraphicsDevice.Indices = meshPart.IndexBuffer;
      this.sc.GraphicsDevice.DrawInstancedPrimitives(PrimitiveType.TriangleList, 0, 0, meshPart.NumVertices, meshPart.StartIndex, meshPart.PrimitiveCount, tempindex);
    }

    private static void GetHeightFast(
      ref float[,] heights,
      ref Vector3 pos,
      out float height,
      out Vector3 normal)
    {
      int index1 = (int) MathHelper.Clamp(pos.X / pumpkins.unit, 0.0f, (float) (pumpkins.bitmap - 2));
      int index2 = (int) MathHelper.Clamp(pos.Z / pumpkins.unit, 0.0f, (float) (pumpkins.bitmap - 2));
      float num1 = pos.X % pumpkins.unit / pumpkins.unit;
      float num2 = pos.Z % pumpkins.unit / pumpkins.unit;
      float num3 = (float) ((1.0 - (double) num1) * (double) heights[index1, index2] + (double) num1 * (double) heights[index1 + 1, index2]);
      float num4 = (float) ((1.0 - (double) num1) * (double) heights[index1, index2 + 1] + (double) num1 * (double) heights[index1 + 1, index2 + 1]);
      height = (float) ((1.0 - (double) num2) * (double) num3 + (double) num2 * (double) num4);
      normal = Vector3.Normalize(new Vector3(-heights[index1 + 1, index2] + heights[index1, index2], 30f, -heights[index1, index2 + 1] + heights[index1, index2]));
    }

    public struct instancedObject : IVertexType
    {
      public Matrix Trans;
      public float tint;
      private static readonly VertexDeclaration InstanceVertexDeclaration = new VertexDeclaration(new VertexElement[5]
      {
        new VertexElement(0, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 0),
        new VertexElement(16, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 1),
        new VertexElement(32, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 2),
        new VertexElement(48, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 3),
        new VertexElement(64, VertexElementFormat.Single, VertexElementUsage.Fog, 0)
      });

      VertexDeclaration IVertexType.VertexDeclaration
      {
        get => pumpkins.instancedObject.InstanceVertexDeclaration;
      }
    }

    public struct shell
    {
      public int type;
      public int drop;
      public int max;
      public int tempindex;
      public int index;
      public int maxCapacity;
      public pumpkins.instancedObject[] stream;
      public DynamicVertexBuffer buffer;
      public pumpkins.instancedObject[] displayList;
      public pumpDupe[] dupe;
      public Model model1;
    }
  }
}
