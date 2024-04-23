// Decompiled with JetBrains decompiler
// Type: Blood.skullkins
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace Blood
{
  public class skullkins
  {
    public static float pumpkindistance = 10000f;
    private Effect effect;
    private ScreenManager sc;
    private ContentManager content;
    public static int bitmap;
    public static float unit;
    public int pumpkinIndex = -1;
    public int lastpumpkin = -1;
    private Vector3 lightpos;
    private Vector3 lightlookpos;
    private bool lighton;
    private bool gunfired;
    private readonly VertexBufferBinding[] _vertexBufferBindings = new VertexBufferBinding[2];
    private static VertexDeclaration instanceDec = new VertexDeclaration(new VertexElement[5]
    {
      new VertexElement(0, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 0),
      new VertexElement(16, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 1),
      new VertexElement(32, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 2),
      new VertexElement(48, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 3),
      new VertexElement(64, VertexElementFormat.Single, VertexElementUsage.Fog, 0)
    });
    private skullkins.instancedObject[] tempInstance = new skullkins.instancedObject[1];
    public skullkins.shell pump;
    public skullkins.shell p_stem;
    public skullkins.shell p_base;
    public skullkins.shell p_rind;
    public skullkins.shell p_chunk;
    public skullkins.shell p_bitty;
    private SoundEffect sound1;
    private SoundEffect sound2;
    private SoundEffect sound3;
    private SoundEffect sound4;
    private SoundEffect pop;
    private SoundEffect pop2;
    private SoundEffect ss1;
    private SoundEffect ss2;
    private Texture2D skulltexture;
    public int alive;
    private Matrix view;
    private Matrix proj;
    private Random rz;

    public skullkins(ScreenManager ss, ContentManager cc)
    {
      this.rz = new Random();
      this.content = cc;
      this.sc = ss;
      this.pump = new skullkins.shell();
      this.pump.max = 0;
      this.pump.type = 0;
      this.pump.maxCapacity = 290;
      this.pump.index = 0;
      this.pump.model1 = this.content.Load<Model>("models\\skull1");
      this.pump.buffer = new DynamicVertexBuffer(this.sc.GraphicsDevice, skullkins.instanceDec, this.pump.maxCapacity, BufferUsage.WriteOnly);
      this.pump.displayList = new skullkins.instancedObject[this.pump.maxCapacity];
      this.pump.dupe = new skullDupe[this.pump.maxCapacity];
      for (int i = 0; i < this.pump.maxCapacity; ++i)
        this.pump.dupe[i] = new skullDupe(i);
      this.pump.stream = new skullkins.instancedObject[this.pump.maxCapacity];
      this.p_stem = new skullkins.shell();
      this.p_stem.max = 0;
      this.p_stem.type = 1;
      this.p_stem.maxCapacity = 30;
      this.p_stem.index = 0;
      this.p_stem.model1 = this.content.Load<Model>("models\\s_stem");
      int maxCapacity1 = this.p_stem.maxCapacity;
      this.p_stem.buffer = new DynamicVertexBuffer(this.sc.GraphicsDevice, skullkins.instanceDec, maxCapacity1, BufferUsage.WriteOnly);
      this.p_stem.displayList = new skullkins.instancedObject[maxCapacity1];
      this.p_stem.dupe = new skullDupe[maxCapacity1];
      for (int i = 0; i < maxCapacity1; ++i)
        this.p_stem.dupe[i] = new skullDupe(i);
      this.p_stem.stream = new skullkins.instancedObject[maxCapacity1];
      this.p_base = new skullkins.shell();
      this.p_base.max = 0;
      this.p_base.type = 2;
      this.p_base.maxCapacity = 40;
      this.p_base.index = 0;
      this.p_base.model1 = this.content.Load<Model>("models\\s_base");
      int maxCapacity2 = this.p_base.maxCapacity;
      this.p_base.buffer = new DynamicVertexBuffer(this.sc.GraphicsDevice, skullkins.instanceDec, maxCapacity2, BufferUsage.WriteOnly);
      this.p_base.displayList = new skullkins.instancedObject[maxCapacity2];
      this.p_base.dupe = new skullDupe[maxCapacity2];
      for (int i = 0; i < maxCapacity2; ++i)
        this.p_base.dupe[i] = new skullDupe(i);
      this.p_base.stream = new skullkins.instancedObject[maxCapacity2];
      this.p_rind = new skullkins.shell();
      this.p_rind.max = 0;
      this.p_rind.type = 3;
      this.p_rind.maxCapacity = 40;
      this.p_rind.index = 0;
      this.p_rind.model1 = this.content.Load<Model>("models\\s_rind");
      int maxCapacity3 = this.p_rind.maxCapacity;
      this.p_rind.buffer = new DynamicVertexBuffer(this.sc.GraphicsDevice, skullkins.instanceDec, maxCapacity3, BufferUsage.WriteOnly);
      this.p_rind.displayList = new skullkins.instancedObject[maxCapacity3];
      this.p_rind.dupe = new skullDupe[maxCapacity3];
      for (int i = 0; i < maxCapacity3; ++i)
        this.p_rind.dupe[i] = new skullDupe(i);
      this.p_rind.stream = new skullkins.instancedObject[maxCapacity3];
      this.p_chunk = new skullkins.shell();
      this.p_chunk.max = 0;
      this.p_chunk.type = 4;
      this.p_chunk.maxCapacity = 40;
      this.p_chunk.index = 0;
      this.p_chunk.model1 = this.content.Load<Model>("models\\s_chunk");
      int maxCapacity4 = this.p_chunk.maxCapacity;
      this.p_chunk.buffer = new DynamicVertexBuffer(this.sc.GraphicsDevice, skullkins.instanceDec, maxCapacity4, BufferUsage.WriteOnly);
      this.p_chunk.displayList = new skullkins.instancedObject[maxCapacity4];
      this.p_chunk.dupe = new skullDupe[maxCapacity4];
      for (int i = 0; i < maxCapacity4; ++i)
        this.p_chunk.dupe[i] = new skullDupe(i);
      this.p_chunk.stream = new skullkins.instancedObject[maxCapacity4];
      this.p_bitty = new skullkins.shell();
      this.p_bitty.max = 0;
      this.p_bitty.type = 4;
      this.p_bitty.maxCapacity = 40;
      this.p_bitty.index = 0;
      this.p_bitty.model1 = this.content.Load<Model>("models\\s_bitty");
      int maxCapacity5 = this.p_bitty.maxCapacity;
      this.p_bitty.buffer = new DynamicVertexBuffer(this.sc.GraphicsDevice, skullkins.instanceDec, maxCapacity5, BufferUsage.WriteOnly);
      this.p_bitty.displayList = new skullkins.instancedObject[maxCapacity5];
      this.p_bitty.dupe = new skullDupe[maxCapacity5];
      for (int i = 0; i < maxCapacity5; ++i)
        this.p_bitty.dupe[i] = new skullDupe(i);
      this.p_bitty.stream = new skullkins.instancedObject[maxCapacity5];
      this.sound1 = this.content.Load<SoundEffect>("audio\\squash1");
      this.sound2 = this.content.Load<SoundEffect>("audio\\squash2");
      this.sound3 = this.content.Load<SoundEffect>("audio\\squash3");
      this.sound4 = this.content.Load<SoundEffect>("audio\\squash4");
      this.pop = this.content.Load<SoundEffect>("audio\\pop");
      this.pop2 = this.content.Load<SoundEffect>("audio\\pop2");
      this.ss1 = this.content.Load<SoundEffect>("audio\\bonehit");
      this.ss2 = this.content.Load<SoundEffect>("audio\\bonehit2");
      this.skulltexture = this.content.Load<Texture2D>("texture\\skull2");
      this.effect = this.content.Load<Effect>("effects\\instancerDeep2");
    }

    public void emitPumpkins(
      int seeder,
      Vector3 pos,
      Matrix rotter,
      ref float[,] heights,
      bool sendpos,
      bool placeit,
      float floor)
    {
      this.pump.type = 0;
      this.dropPumpkin(seeder, ref this.pump, pos, rotter, ref heights, placeit, floor);
    }

    private void dropPumpkin(
      int seeder,
      ref skullkins.shell sh,
      Vector3 pos,
      Matrix rotter,
      ref float[,] heights,
      bool placeit,
      float floor)
    {
      sh.dupe[sh.index].rr = new Random(seeder);
      float num1 = (float) sh.dupe[sh.index].rr.Next(9, 23) / 100f;
      Vector3 scal = new Vector3(num1, num1, num1);
      sh.dupe[sh.index].drop = 0;
      Vector3 pos1;
      float height;
      Vector3 normal;
      Vector3 veloc;
      int move;
      if (placeit)
      {
        pos1 = pos;
        skullkins.GetHeightFast(ref heights, ref pos1, out height, out normal);
        veloc = Vector3.Transform(new Vector3((float) sh.dupe[sh.index].rr.Next(-20, 20) / 100f, (float) sh.dupe[sh.index].rr.Next(-20, 20) / 100f, -0.5f), rotter);
        move = 3;
      }
      else
      {
        move = 3;
        pos1 = pos;
        skullkins.GetHeightFast(ref heights, ref pos1, out height, out normal);
        veloc = Vector3.Transform(new Vector3((float) sh.dupe[sh.index].rr.Next(-120, 120) / 100f, (float) sh.dupe[sh.index].rr.Next(-120, 120) / 100f, (float) -sh.dupe[sh.index].rr.Next(8, 25)), rotter);
      }
      Matrix rot = Matrix.CreateRotationX((float) sh.dupe[sh.index].rr.Next(0, 8000) / 100f) * Matrix.CreateRotationY((float) sh.dupe[sh.index].rr.Next(0, 8000) / 100f);
      int tinter = sh.dupe[sh.index].rr.Next(0, 11);
      sh.dupe[sh.index].tint = (float) sh.dupe[sh.index].rr.Next(0, 11);
      int num2 = 4;
      if (this.sc.df == 0)
        num2 = 12;
      if (sh.dupe[sh.index].rr.Next(1, 1000) < num2)
      {
        tinter = 11;
        float num3 = (float) sh.dupe[sh.index].rr.Next(16, 22) / 100f;
        scal = new Vector3(num3, num3, num3);
      }
      if (placeit)
      {
        tinter = 11;
        float num4 = (float) sh.dupe[sh.index].rr.Next(16, 22) / 100f;
        scal = new Vector3(num4, num4, num4);
      }
      sh.dupe[sh.index].init(seeder, scal, pos1, rot, veloc, move, floor, tinter);
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

    public void dropParts(ref skullkins.shell sh, int i, Matrix m, int size)
    {
      float num1 = (float) this.rz.Next(30, 140) / 100f;
      float ta = 120f;
      float tb = 220f;
      int minValue1 = 110;
      int maxValue1 = 350;
      float num2 = 60f;
      int minValue2 = -200;
      int maxValue2 = -130;
      float num3 = 1000f;
      if (this.sc.revengeDay > 0)
      {
        num1 = (float) this.rz.Next(50, 350) / 100f;
        minValue1 = 100;
        maxValue1 = 500;
      }
      Matrix matrix = Matrix.CreateScale(this.pump.dupe[i].scale) * this.pump.dupe[i].rot * Matrix.CreateTranslation(this.pump.dupe[i].mypos);
      Matrix startpos = m * matrix;
      sh.dupe[sh.index].tint = this.pump.dupe[i].tint;
      Vector3 vector3_1 = new Vector3((float) this.rz.Next(-300, 300) / 120f, (float) this.rz.Next(minValue1, maxValue1) / num2, (float) this.rz.Next(-300, 300) / 120f);
      Vector3 vector3_2 = Vector3.Transform(new Vector3(0.0f, 0.0f, 0.0f), m);
      Vector3 vector3_3 = (float) this.rz.Next(100, 200) / 30f * Vector3.Normalize(vector3_2);
      float bounce = (float) this.rz.Next(300, 700) / 1000f;
      float grav = (float) this.rz.Next(minValue2, maxValue2) / num3;
      sh.dupe[sh.index].init2(size, 1, bounce, this.pump.dupe[i].scale, 0.3f, startpos, new Vector3(vector3_3.X + vector3_1.X, vector3_1.Y, vector3_3.Z + vector3_1.Z) * num1, true, grav, 20, ta, tb, false, false, false);
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

    public void updateSkullkin(
      ref skullkins.shell sh,
      float range,
      ref float[,] heights,
      Vector3 campos,
      Vector3 camlookpos,
      ref localPlayer myPlayer,
      ref Cursor genCursor,
      ref Vector2 hitVel,
      float headRot,
      Vector3 remVec,
      Vector3 remplayerPOS)
    {
      this.lightpos = campos;
      this.lightlookpos = camlookpos;
      this.lighton = myPlayer.now.flashlight;
      this.gunfired = myPlayer.gunFired;
      this.lastpumpkin = -1;
      Vector3 vector2_1 = Vector3.Normalize(camlookpos - campos);
      Vector3 vector3_1 = -vector2_1 * 100f + campos;
      range *= range;
      this.pumpkinIndex = -1;
      float vol = 0.0f;
      bool flag1 = false;
      sh.tempindex = 0;
      this.alive = 0;
      skullkins.pumpkindistance = 10000f;
      float num1 = myPlayer.vec.Length();
      float num2 = remVec.Length();
      for (int index = 0; index < sh.max; ++index)
      {
        if (sh.dupe[index].move != -1)
        {
          float result1;
          Vector3.DistanceSquared(ref myPlayer.displayState.npcPosition, ref sh.dupe[index].mypos, out result1);
          if (sh.dupe[index].firstHit == 1)
          {
            sh.dupe[index].firstHit = 2;
            vol = MathHelper.Clamp((float) (1.0 - (Math.Sqrt((double) result1) - 200.0) / 2000.0), 0.1f, 1f);
            if (sh.dupe[sh.index].rr.Next(1, 100) < 80)
              this.ss1.Play(this.sc.ev * vol, (float) sh.dupe[sh.index].rr.Next(-20, 60) / 100f, (float) sh.dupe[sh.index].rr.Next(-100, 100) / 100f);
          }
          if (sh.dupe[index].firstHit == 4)
          {
            sh.dupe[index].firstHit = 5;
            vol = MathHelper.Clamp((float) (1.0 - (Math.Sqrt((double) result1) - 200.0) / 2000.0), 0.1f, 1f);
            if (sh.dupe[sh.index].rr.Next(1, 100) < 80)
              this.ss2.Play(this.sc.ev * vol, (float) sh.dupe[sh.index].rr.Next(-20, 60) / 100f, (float) sh.dupe[sh.index].rr.Next(-100, 100) / 100f);
          }
          bool flag2 = false;
          bool flag3 = false;
          bool flag4 = false;
          ++this.alive;
          if ((double) result1 < (double) range)
          {
            Vector3 vector3_2 = new Vector3(sh.dupe[index].mypos.X, sh.dupe[index].mypos.Y, sh.dupe[index].mypos.Z) - vector3_1;
            Vector3 result2;
            Vector3.Normalize(ref vector3_2, out result2);
            float result3 = 0.0f;
            Vector3.Dot(ref result2, ref vector2_1, out result3);
            if ((double) result3 > (double) this.sc.myfov)
            {
              if (sh.dupe[index].move > 0)
                sh.dupe[index].updateSkullHead(ref heights);
              sh.stream[index].Trans = sh.dupe[index].transform;
              sh.stream[index].tint = sh.dupe[index].tint;
              sh.displayList[sh.tempindex] = sh.stream[index];
              ++sh.tempindex;
              flag2 = true;
              if (sh.dupe[index].kickable && !flag1)
              {
                if (myPlayer.gunFired && (double) result3 > 0.949999988079071)
                {
                  float num3 = 32f;
                  if (genCursor.hitSphere(myPlayer.gunpos, myPlayer.gunlook, sh.dupe[index].mypos, sh.dupe[index].scale.Y * num3).HasValue && Math.Sqrt((double) result1) <= (double) skullkins.pumpkindistance)
                  {
                    skullkins.pumpkindistance = (float) Math.Sqrt((double) result1);
                    vol = MathHelper.Clamp((float) (1.0 - (Math.Sqrt((double) result1) - 200.0) / 4000.0), 0.2f, 1f);
                    this.pumpkinIndex = index;
                  }
                }
                if ((double) num2 > 0.0 && !flag4)
                {
                  float result4;
                  Vector3.DistanceSquared(ref remplayerPOS, ref sh.dupe[index].mypos, out result4);
                  if ((double) result4 < 6400.0 * (double) sh.dupe[index].scale.X)
                  {
                    sh.dupe[index].move = 3;
                    sh.dupe[index].firstHit = 0;
                    sh.dupe[index].velocity = remVec * (float) sh.dupe[sh.index].rr.Next(100, 200) / 100f;
                    sh.dupe[index].velocity.Y = (float) sh.dupe[sh.index].rr.Next(5, 15) / 10f;
                    sh.dupe[index].velocity.X += (float) sh.dupe[sh.index].rr.Next(-100, 100) / 100f;
                    sh.dupe[index].velocity.Z += (float) sh.dupe[sh.index].rr.Next(-100, 100) / 100f;
                    if (sh.dupe[sh.index].rr.Next(1, 100) < 30)
                      this.ss2.Play(this.sc.ev * 0.5f, (float) sh.dupe[sh.index].rr.Next(-40, 40) / 100f, (float) sh.dupe[sh.index].rr.Next(-100, 100) / 100f);
                  }
                }
                if (!myPlayer.isDown && !myPlayer.gunFired && (double) result1 < 6400.0 * (double) sh.dupe[index].scale.X)
                {
                  if ((double) num1 > 1.0 && !flag3)
                  {
                    sh.dupe[index].move = 3;
                    sh.dupe[index].firstHit = 0;
                    sh.dupe[index].velocity = myPlayer.vec * (float) sh.dupe[sh.index].rr.Next(50, 100) / 100f;
                    sh.dupe[index].velocity.Y = (float) sh.dupe[sh.index].rr.Next(5, 15) / 10f;
                    sh.dupe[index].velocity.X += (float) sh.dupe[sh.index].rr.Next(-100, 100) / 100f;
                    sh.dupe[index].velocity.Z += (float) sh.dupe[sh.index].rr.Next(-100, 100) / 100f;
                    if (sh.dupe[sh.index].rr.Next(1, 100) < 40)
                      this.ss2.Play(this.sc.ev * 0.5f, (float) sh.dupe[sh.index].rr.Next(-40, 40) / 100f, (float) sh.dupe[sh.index].rr.Next(-100, 100) / 100f);
                  }
                  if (sh.dupe[index].move == 3 && sh.dupe[index].canhurt)
                  {
                    sh.dupe[index].canhurt = false;
                    this.sc.falldown2.Play(this.sc.ev, (float) sh.dupe[sh.index].rr.Next(-20, 20) / 100f, 0.0f);
                    Vector2 vector2_2 = new Vector2(sh.dupe[index].mypos.X, sh.dupe[index].mypos.Z) - new Vector2(myPlayer.displayState.npcPosition.X, myPlayer.displayState.npcPosition.Z);
                    if ((double) vector2_2.Length() > 0.0)
                    {
                      hitVel = -Vector2.Normalize(vector2_2) * 2.5f;
                      hitVel = Vector2.Transform(new Vector2(-hitVel.X, hitVel.Y), Matrix.CreateRotationZ(-headRot));
                    }
                    if (this.sc.df == 0)
                      myPlayer.damHealth((float) sh.dupe[sh.index].rr.Next(3, 6), false);
                    else
                      myPlayer.damHealth((float) sh.dupe[sh.index].rr.Next(7, 11), false);
                  }
                }
              }
            }
          }
          if (sh.dupe[index].move > 0 && !flag2)
            sh.dupe[index].updateSkullHead(ref heights);
          this.lastpumpkin = index;
          sh.dupe[index].pop = false;
        }
      }
      if (this.pumpkinIndex == -1)
        return;
      this.explode(this.pumpkinIndex, ref myPlayer, ref heights, vol);
    }

    public void updateSkullParts(
      ref skullkins.shell sh,
      float range,
      ref float[,] heights,
      Vector3 campos,
      Vector3 camlookpos,
      ref localPlayer myPlayer,
      ref Cursor genCursor)
    {
      this.lightpos = campos;
      this.lightlookpos = camlookpos;
      this.lighton = myPlayer.now.flashlight;
      this.gunfired = myPlayer.gunFired;
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
      if ((double) this.pump.dupe[i].tint != 11.0)
      {
        int num = this.rz.Next(0, 4);
        if (num == 0)
          this.sound1.Play(this.sc.ev * vol, (float) this.rz.Next(-50, 0) / 100f, 0.0f);
        if (num == 1)
          this.sound2.Play(this.sc.ev * vol, (float) this.rz.Next(-50, 0) / 100f, 0.0f);
        if (num == 2)
          this.sound3.Play(this.sc.ev * vol, (float) this.rz.Next(-50, 0) / 100f, 0.0f);
        if (num == 3)
          this.sound4.Play(this.sc.ev * vol, (float) this.rz.Next(-50, 0) / 100f, 0.0f);
      }
      else if (!myPlayer.tunnelHeal)
      {
        this.sc.toneer.Play(this.sc.ev, 0.0f, 0.0f);
        myPlayer.tunnelHeal = true;
      }
      Matrix m1 = Matrix.CreateRotationX(MathHelper.ToRadians(7.26f)) * Matrix.CreateTranslation(1.63f, 40.52f, 2.89f);
      this.dropParts(ref this.p_stem, i, m1, 5);
      Matrix m2 = Matrix.CreateRotationY(MathHelper.ToRadians(-5.13f)) * Matrix.CreateTranslation(-15.9f, -1.29f, -14.283f);
      this.dropParts(ref this.p_rind, i, m2, 18);
      Matrix m3 = Matrix.CreateRotationY(MathHelper.ToRadians(-20.3f)) * Matrix.CreateTranslation(23.55f, 0.155f, 5.59f);
      this.dropParts(ref this.p_base, i, m3, 18);
      Matrix m4 = Matrix.CreateRotationX(MathHelper.ToRadians(0.0f)) * Matrix.CreateRotationY(MathHelper.ToRadians(-46.59f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(181f)) * Matrix.CreateTranslation(-19.07f, -0.92f, 15.73f);
      this.dropParts(ref this.p_base, i, m4, 18);
      Matrix translation = Matrix.CreateTranslation(0.76f, 17.35f, 29f);
      this.dropParts(ref this.p_chunk, i, translation, 10);
      Matrix m5 = Matrix.CreateRotationX(MathHelper.ToRadians(-166f)) * Matrix.CreateRotationY(MathHelper.ToRadians(-41f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(9f)) * Matrix.CreateTranslation(21.21f, -11.5f, -26.53f);
      this.dropParts(ref this.p_chunk, i, m5, 10);
      Matrix m6 = Matrix.CreateRotationX(MathHelper.ToRadians(-165.9f)) * Matrix.CreateRotationY(MathHelper.ToRadians(-3.14f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(186.15f)) * Matrix.CreateTranslation(-2f, 14.7f, -31.3f);
      this.dropParts(ref this.p_chunk, i, m6, 10);
      Matrix m7 = Matrix.CreateRotationX(MathHelper.ToRadians(-14.36f)) * Matrix.CreateRotationY(MathHelper.ToRadians(9.5f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(5.5f)) * Matrix.CreateTranslation(-3.26f, -11.96f, -33.03f);
      this.dropParts(ref this.p_bitty, i, m7, 5);
      Matrix m8 = Matrix.CreateRotationX(MathHelper.ToRadians(-171.5f)) * Matrix.CreateRotationY(MathHelper.ToRadians(20f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(7.84f)) * Matrix.CreateTranslation(11.7f, -8.2f, 32.9f);
      this.dropParts(ref this.p_bitty, i, m8, 5);
      Matrix m9 = Matrix.CreateRotationX(MathHelper.ToRadians(69f)) * Matrix.CreateRotationY(MathHelper.ToRadians(-42.3f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(3.6f)) * Matrix.CreateTranslation(12.43f, 27f, -11.72f);
      this.dropParts(ref this.p_bitty, i, m9, 5);
    }

    public void draw(Matrix view, Matrix proj)
    {
      this.view = view;
      this.proj = proj;
      this.DrawInstance(ref this.pump, "fastShader2");
      this.DrawInstance(ref this.p_stem, "fastShader2");
      this.DrawInstance(ref this.p_base, "fastShader2");
      this.DrawInstance(ref this.p_rind, "fastShader2");
      this.DrawInstance(ref this.p_chunk, "fastShader2");
      this.DrawInstance(ref this.p_bitty, "fastShader2");
    }

    private void DrawInstance(ref skullkins.shell shell, string tech)
    {
      int tempindex = shell.tempindex;
      if (tempindex < 1)
        return;
      ModelMeshPart meshPart = shell.model1.Meshes[0].MeshParts[0];
      shell.buffer.SetData<skullkins.instancedObject>(shell.displayList, 0, tempindex, SetDataOptions.Discard);
      this.effect.CurrentTechnique = this.effect.Techniques[tech];
      Vector3 vector3 = Vector3.Normalize(this.lightpos - this.lightlookpos);
      vector3.Y *= -1f;
      vector3.X *= -1f;
      float num = 1.1f;
      float val2 = 700f;
      if (!this.lighton)
      {
        num = 0.3f;
        val2 = 350f;
      }
      if (this.gunfired)
      {
        Math.Max(450f, val2);
        num = 1.3f;
      }
      this.effect.Parameters["depth"].SetValue(5000);
      this.effect.Parameters["lightPos1"].SetValue(this.lightpos);
      this.effect.Parameters["Texture"].SetValue((Texture) this.skulltexture);
      this.effect.Parameters["LightDirection2"].SetValue(vector3);
      this.effect.Parameters["diff2"].SetValue(new Vector3(0.8f, 0.8f, 0.8f) * num);
      this.effect.Parameters["amb2"].SetValue(new Vector3(0.2f, 0.2f, 0.2f));
      this.effect.Parameters["View"].SetValue(this.view);
      this.effect.Parameters["Projection"].SetValue(this.proj);
      this.effect.CurrentTechnique.Passes[0].Apply();
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
      int index1 = (int) MathHelper.Clamp(pos.X / skullkins.unit, 0.0f, (float) (skullkins.bitmap - 2));
      int index2 = (int) MathHelper.Clamp(pos.Z / skullkins.unit, 0.0f, (float) (skullkins.bitmap - 2));
      float num1 = pos.X % skullkins.unit / skullkins.unit;
      float num2 = pos.Z % skullkins.unit / skullkins.unit;
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
        get => skullkins.instancedObject.InstanceVertexDeclaration;
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
      public skullkins.instancedObject[] stream;
      public DynamicVertexBuffer buffer;
      public skullkins.instancedObject[] displayList;
      public skullDupe[] dupe;
      public Model model1;
    }
  }
}
