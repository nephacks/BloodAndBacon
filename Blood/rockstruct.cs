// Decompiled with JetBrains decompiler
// Type: Blood.rockstruct
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

#nullable disable
namespace Blood
{
  internal class rockstruct : GameScreen
  {
    public float flowerDistance;
    private int frame;
    private int acre = 21000;
    public Model rock;
    public Model rockB;
    public Model flower;
    public int maxrockCount;
    public int maxflowerCount;
    public objDupe[] rockInst;
    public objDupe[] flowerInst;
    public int chosen = -1;
    public int chosenfar = -1;
    public int rockCount;
    public int flowerCount;
    public List<int> rockMoving = new List<int>();
    public List<int> rockClose = new List<int>();
    public Vector2 myPOS = new Vector2(0.0f, 0.0f);
    public Vector2 oldmyPOS = new Vector2(0.0f, 0.0f);
    public Model slab;
    public Model slablet;
    public int slabmax;
    public int slab2max;
    public Texture2D reflection;
    public slabDupe[] slabInst;
    public slabDupe2[] slabDupe2_0;
    public int slabCount;
    public int int_0;
    public Vector2 slabPOS = new Vector2(0.0f, 0.0f);
    public Vector2 vector2_0 = new Vector2(0.0f, 0.0f);
    private float minAngle;
    private float maxAngle;
    private Random rr;
    public int maxcount2 = 20;
    public Model rock1;
    public Model rockB1;
    public Model rockB2;
    public rockBreak[] rockBreak_0 = new rockBreak[40];
    public int int_1;
    public Model rock2;
    public rockBreak[] rockBreak_1 = new rockBreak[40];
    public int int_2;
    private Random random;
    private int gridscale;
    private int bitmap;
    private int hectare = 2000;
    private int grid = 150;
    private readonly VertexBufferBinding[] _vertexBufferBindings = new VertexBufferBinding[2];
    private DynamicVertexBuffer rockBuffer;
    private DynamicVertexBuffer dynamicVertexBuffer_0;
    private DynamicVertexBuffer dynamicVertexBuffer_1;
    private DynamicVertexBuffer slabBuffer;
    private DynamicVertexBuffer dynamicVertexBuffer_2;
    private DynamicVertexBuffer flowerBuffer;
    private static VertexDeclaration vd = new VertexDeclaration(new VertexElement[5]
    {
      new VertexElement(0, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 0),
      new VertexElement(16, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 1),
      new VertexElement(32, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 2),
      new VertexElement(48, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 3),
      new VertexElement(64, VertexElementFormat.Single, VertexElementUsage.Fog, 0)
    });
    private rockstruct.transcolor[] rockTrans;
    private rockstruct.transcolor[] transcolor_0;
    private rockstruct.transcolor[] transcolor_1;
    private rockstruct.transcolor[] slabTrans;
    private rockstruct.transcolor[] transcolor_2;
    public rockstruct.transcolor[] flowerTrans;
    private ScreenManager sc;
    private GraphicsDevice gr;
    private ContentManager content;
    private float thisframe;

    public void LoadContent(
      ContentManager content,
      ScreenManager sc,
      int grid,
      int bit,
      int count)
    {
      this.content = content;
      this.random = new Random();
      this.sc = sc;
      this.gr = sc.GraphicsDevice;
      this.gridscale = grid;
      this.bitmap = bit;
      this.thisframe = 0.0f;
      this.rr = new Random();
      objDupe.objectData = new int[500, 500];
      this.maxrockCount = count;
      this.maxflowerCount = 200;
      this.rockInst = new objDupe[this.maxrockCount];
      for (int var = 0; var < this.maxrockCount; ++var)
        this.rockInst[var] = new objDupe(var);
      this.rockTrans = new rockstruct.transcolor[this.maxrockCount];
      this.rockBuffer = new DynamicVertexBuffer(this.gr, rockstruct.vd, this.maxrockCount, BufferUsage.WriteOnly);
      this.flowerInst = new objDupe[this.maxflowerCount];
      for (int var = 0; var < this.maxflowerCount; ++var)
        this.flowerInst[var] = new objDupe(var);
      this.flowerTrans = new rockstruct.transcolor[this.maxflowerCount];
      this.flowerBuffer = new DynamicVertexBuffer(this.gr, rockstruct.vd, this.maxflowerCount, BufferUsage.WriteOnly);
      this.slabmax = 80;
      this.slabTrans = new rockstruct.transcolor[this.slabmax];
      this.slabInst = new slabDupe[this.slabmax];
      for (int val = 0; val < this.slabmax; ++val)
        this.slabInst[val] = new slabDupe(val);
      this.slabBuffer = new DynamicVertexBuffer(this.gr, rockstruct.vd, this.slabmax, BufferUsage.WriteOnly);
      this.minAngle = 0.3f;
      this.maxAngle = 0.85f;
      this.minAngle = 0.0f;
      this.maxAngle = 0.99f;
      this.slab2max = 200;
      this.transcolor_2 = new rockstruct.transcolor[this.slab2max];
      this.slabDupe2_0 = new slabDupe2[this.slab2max];
      this.slabDupe2_0 = new slabDupe2[this.slab2max];
      for (int val = 0; val < this.slab2max; ++val)
        this.slabDupe2_0[val] = new slabDupe2(val);
      this.dynamicVertexBuffer_2 = new DynamicVertexBuffer(this.gr, rockstruct.vd, this.slab2max, BufferUsage.WriteOnly);
      this.rockCount = 0;
      this.int_1 = 0;
      this.int_2 = 0;
      this.slabCount = 0;
      this.int_0 = 0;
      this.rockBreak_0 = new rockBreak[this.maxcount2];
      this.transcolor_0 = new rockstruct.transcolor[this.maxcount2];
      this.dynamicVertexBuffer_0 = new DynamicVertexBuffer(this.gr, rockstruct.vd, this.maxcount2, BufferUsage.WriteOnly);
      this.rockBreak_1 = new rockBreak[this.maxcount2];
      this.transcolor_1 = new rockstruct.transcolor[this.maxcount2];
      this.dynamicVertexBuffer_1 = new DynamicVertexBuffer(this.gr, rockstruct.vd, this.maxcount2, BufferUsage.WriteOnly);
    }

    public override void UnloadContent()
    {
      this.content.Unload();
      this.rockInst.Initialize();
      this.rockBuffer.Dispose();
      this.rockBuffer.Dispose();
      this.dynamicVertexBuffer_0.Dispose();
      this.dynamicVertexBuffer_1.Dispose();
      this.slabBuffer.Dispose();
      this.dynamicVertexBuffer_2.Dispose();
    }

    public void placeOBJECTS(
      int vehicleindex,
      ref Rover rover,
      ref Lander lander,
      ref int[,] heightData,
      ref Vector3[,] normalData,
      ref int[,] objectData,
      float color)
    {
      Vector3 vector3 = vehicleindex != 1 ? lander.position : rover.position;
      this.rockCount = 0;
      this.rockInst[0].init(false, new Vector3(0.0f, -100000f, 0.0f), this.sc, 1, 0, 0);
      this.rockTrans[0].Trans = this.rockInst[this.rockCount].Transform;
      this.flowerCount = 0;
      this.flowerInst[0].initflower(new Vector3(0.0f, -100000f, 0.0f), this.sc, 1, 0, 0);
      this.flowerTrans[0].Trans = this.flowerInst[this.flowerCount].Transform;
      for (int x1 = (int) vector3.X - 21000; (double) x1 < (double) vector3.X + 21000.0; x1 += 150)
      {
        for (int z1 = (int) vector3.Z - 21000; (double) z1 < (double) vector3.Z + 21000.0; z1 += 150)
        {
          int num1 = 1999 * this.gridscale;
          float num2 = ((float) (x1 % num1) + 1.5f * (float) num1) % (float) num1;
          float num3 = ((float) (z1 % num1) + 1.5f * (float) num1) % (float) num1;
          float num4 = (float) ((int) num2 / this.gridscale);
          float num5 = (float) ((int) num3 / this.gridscale);
          float x2 = (float) (int) ((double) num4 / 4.0);
          float z2 = (float) (int) ((double) num5 / 4.0);
          int num6 = objectData[(int) x2, (int) z2];
          float height;
          Vector3 normal;
          if (objDupe.objectData[(int) x2, (int) z2] == 0 && num6 >= 27 && num6 <= 30)
          {
            int num7 = ((int) x2 + (int) z2 + 1) * ((int) x2 + (int) z2) / 2 + (int) z2;
            Random random = new Random(num7);
            this.GetHeightNormal(ref heightData, ref normalData, new Vector3((float) (x1 + 300), 0.0f, (float) z1), out height, out normal);
            if ((double) normal.Y >= 0.699999988079071)
            {
              ++this.rockCount;
              int num8 = random.Next(1, 100);
              this.rockInst[this.rockCount].gemtype = num8 >= 20 ? (num8 < 20 || num8 >= 95 ? 0.0f : 1f) : 2f;
              if (num6 == 28 || num6 == 30)
                this.rockInst[this.rockCount].gemtype = 3f;
              bool large = false;
              if (num6 == 29 || num6 == 30)
                large = true;
              this.rockInst[this.rockCount].init(large, new Vector3((float) (x1 + 300), height, (float) z1), this.sc, num7, (int) x2, (int) z2);
              this.rockInst[this.rockCount].addObject(27);
              objDupe.objectData[(int) x2, (int) z2] = 27;
              this.rockTrans[this.rockCount].Trans = this.rockInst[this.rockCount].Transform;
              this.rockTrans[this.rockCount].Color = this.rockInst[this.rockCount].gemtype;
            }
          }
          if (objDupe.objectData[(int) x2, (int) z2] == 0 && num6 == 7)
          {
            int pair = ((int) x2 + (int) z2 + 1) * ((int) x2 + (int) z2) / 2 + (int) z2;
            this.GetHeightNormal(ref heightData, ref normalData, new Vector3((float) x1, 0.0f, (float) z1), out height, out normal);
            if (this.flowerCount < this.maxflowerCount)
            {
              ++this.flowerCount;
              this.flowerInst[this.flowerCount].initflower(new Vector3((float) x1, height, (float) z1), this.sc, pair, (int) x2, (int) z2);
              this.flowerInst[this.flowerCount].addObject(7);
              this.flowerInst[this.flowerCount].gemtype = 1f;
              objDupe.objectData[(int) x2, (int) z2] = 7;
              this.flowerTrans[this.flowerCount].Trans = this.flowerInst[this.flowerCount].Transform;
              this.flowerTrans[this.flowerCount].Color = 1f;
            }
          }
          if (this.rockCount >= this.maxrockCount - 1)
            break;
        }
        if (this.rockCount >= this.maxrockCount - 1)
          break;
      }
    }

    public void removeOBJECTS(
      Vector3 campos,
      Vector3 camlookpos,
      int vehicleindex,
      Vector3 grnd,
      ref int[,] heightData,
      ref Vector3[,] normalData,
      ref int[,] objectData)
    {
      ++this.thisframe;
      this.chosen = -1;
      this.chosenfar = -1;
      float num1 = 35000f;
      this.flowerDistance = 35000f;
      for (int index = 1; index <= this.flowerCount; ++index)
      {
        this.flowerTrans[index].Color = (float) (Math.Sin((double) this.thisframe / (double) this.flowerInst[index].div) / 5.0 + 0.81999999284744263);
        if (this.chosen == -1)
        {
          float num2 = Vector2.Distance(new Vector2(this.flowerInst[index].mypos.X, this.flowerInst[index].mypos.Z), new Vector2(campos.X, campos.Z));
          if (this.flowerInst[index].stateFlag == 15 && (double) num2 < (double) num1)
          {
            this.flowerDistance = num2;
            num1 = num2;
            this.chosenfar = index;
          }
          Vector3 vector2 = Vector3.Normalize(camlookpos - campos);
          float num3 = Vector3.Dot(Vector3.Normalize(new Vector3(this.flowerInst[index].mypos.X, this.flowerInst[index].mypos.Y - 20f, this.flowerInst[index].mypos.Z) - campos), vector2);
          if ((double) num2 < 150.0 && (double) num3 > 0.800000011920929)
            this.chosen = index;
        }
        if (this.flowerInst[index].stateFlag == 5)
        {
          this.flowerInst[index].Update(ref heightData, ref normalData, ref objectData);
          this.flowerTrans[index].Trans = this.flowerInst[index].Transform;
        }
        if ((double) Vector2.DistanceSquared(new Vector2(grnd.X, grnd.Z), new Vector2(this.flowerInst[index].mypos.X, this.flowerInst[index].mypos.Z)) > (double) ((this.acre + 9000) * (this.acre + 9000)))
        {
          if (index != this.flowerCount)
          {
            this.flowerInst[index].move = this.flowerInst[this.flowerCount].move;
            if (this.flowerInst[this.flowerCount].onMap)
            {
              this.flowerInst[index].onMap = true;
              this.flowerInst[index].removeObject();
              this.flowerInst[index].objx = this.flowerInst[this.flowerCount].objx;
              this.flowerInst[index].objz = this.flowerInst[this.flowerCount].objz;
              this.flowerInst[index].addObject(7);
              if (this.flowerInst[this.flowerCount].stateFlag == 10)
              {
                this.flowerInst[index].stateFlag = 10;
                this.flowerInst[this.flowerCount].stateFlag = 0;
                this.flowerInst[index].addObject(8);
              }
              this.flowerInst[this.flowerCount].onMap = false;
            }
            else
            {
              this.flowerInst[index].onMap = false;
              this.flowerInst[index].removeObject();
              this.flowerInst[index].objx = this.rockInst[this.flowerCount].objx;
              this.flowerInst[index].objz = this.rockInst[this.flowerCount].objz;
              this.flowerInst[this.flowerCount].onMap = false;
              this.flowerInst[this.flowerCount].removeObject();
            }
            this.flowerInst[index].mypos = this.flowerInst[this.flowerCount].mypos;
            this.flowerInst[index].scaler = this.flowerInst[this.flowerCount].scaler;
            this.flowerInst[index].myRot = this.flowerInst[this.flowerCount].myRot;
            this.flowerInst[index].Transform = this.flowerInst[this.flowerCount].Transform;
            this.flowerInst[index].hits = this.flowerInst[this.flowerCount].hits;
            this.flowerInst[index].grav = this.flowerInst[this.flowerCount].grav;
            this.flowerTrans[index].Trans = this.flowerInst[this.flowerCount].Transform;
            this.flowerTrans[index].Color = this.flowerTrans[this.flowerCount].Color;
          }
          else
          {
            this.flowerInst[index].removeObject();
            this.flowerInst[index].move = false;
          }
          --this.flowerCount;
          if (this.flowerCount < 0)
            this.flowerCount = 0;
        }
      }
      for (int index = 1 + (int) ((double) this.thisframe % 50.0); index <= this.rockCount && index <= this.rockCount; index += 50)
      {
        float num4 = Vector2.DistanceSquared(new Vector2(grnd.X, grnd.Z), new Vector2(this.rockInst[index].mypos.X, this.rockInst[index].mypos.Z));
        if ((double) num4 > (double) ((this.acre + 9000) * (this.acre + 9000)))
        {
          if (index != this.rockCount)
          {
            this.rockMoving.Remove(index);
            this.rockClose.Remove(index);
            if (this.rockClose.Contains(this.rockCount))
            {
              this.rockClose.Remove(this.rockCount);
              if (!this.rockClose.Contains(index))
                this.rockClose.Add(index);
            }
            if (this.rockInst[this.rockCount].move)
            {
              this.rockMoving.Remove(this.rockCount);
              if (!this.rockMoving.Contains(index))
                this.rockMoving.Add(index);
            }
            this.rockInst[index].move = this.rockInst[this.rockCount].move;
            if (this.rockInst[this.rockCount].onMap)
            {
              this.rockInst[index].removeObject();
              this.rockInst[index].objx = this.rockInst[this.rockCount].objx;
              this.rockInst[index].objz = this.rockInst[this.rockCount].objz;
              this.rockInst[index].addObject(27);
              this.rockInst[index].onMap = true;
              this.rockInst[this.rockCount].onMap = false;
            }
            else
            {
              this.rockInst[index].onMap = false;
              this.rockInst[index].removeObject();
              this.rockInst[index].objx = this.rockInst[this.rockCount].objx;
              this.rockInst[index].objz = this.rockInst[this.rockCount].objz;
              this.rockInst[this.rockCount].onMap = false;
              this.rockInst[this.rockCount].removeObject();
            }
            this.rockInst[index].mypos = this.rockInst[this.rockCount].mypos;
            this.rockInst[index].scaler = this.rockInst[this.rockCount].scaler;
            this.rockInst[index].myRot = this.rockInst[this.rockCount].myRot;
            this.rockInst[index].Transform = this.rockInst[this.rockCount].Transform;
            this.rockInst[index].hits = this.rockInst[this.rockCount].hits;
            this.rockInst[index].grav = this.rockInst[this.rockCount].grav;
            this.rockInst[index].gemtype = this.rockInst[this.rockCount].gemtype;
            this.rockTrans[index].Trans = this.rockInst[this.rockCount].Transform;
            this.rockTrans[index].Color = this.rockTrans[this.rockCount].Color;
          }
          else
          {
            this.rockInst[index].removeObject();
            this.rockMoving.Remove(index);
            this.rockClose.Remove(index);
            this.rockInst[index].move = false;
          }
          --this.rockCount;
          if (this.rockCount < 0)
            this.rockCount = 0;
        }
        else if ((double) num4 < 16000000.0)
        {
          if (!this.rockClose.Contains(index))
            this.rockClose.Add(index);
        }
        else if (this.rockClose.Contains(index))
          this.rockClose.Remove(index);
      }
    }

    public void simpleObjectAdd(
      float x,
      float z,
      ref int[,] heightData,
      ref Vector3[,] normalData,
      ref int[,] objectData)
    {
      if (this.rockCount >= this.maxrockCount)
        return;
      int num1 = 1999 * this.gridscale;
      float num2 = (float) (((double) x + 0.0) % (double) num1 + 1.5 * (double) num1) % (float) num1;
      float num3 = (float) (((double) z + 0.0) % (double) num1 + 1.5 * (double) num1) % (float) num1;
      float num4 = (float) ((int) num2 / this.gridscale);
      float num5 = (float) ((int) num3 / this.gridscale);
      float x1 = (float) (int) ((double) num4 / 4.0);
      float z1 = (float) (int) ((double) num5 / 4.0);
      int c = objectData[(int) x1, (int) z1];
      float height;
      Vector3 normal;
      if (this.rockCount < this.maxrockCount && c >= 27 && c <= 30 && objDupe.objectData[(int) x1, (int) z1] == 0)
      {
        int num6 = ((int) x1 + (int) z1 + 1) * ((int) x1 + (int) z1) / 2 + (int) z1;
        Random random = new Random(num6);
        this.GetHeightNormal(ref heightData, ref normalData, new Vector3(x, 0.0f, z), out height, out normal);
        if ((double) normal.Y >= 0.699999988079071)
        {
          ++this.rockCount;
          int num7 = random.Next(1, 100);
          this.rockInst[this.rockCount].gemtype = num7 >= 20 ? (num7 < 20 || num7 >= 95 ? 0.0f : 1f) : 2f;
          if (c == 28 || c == 30)
            this.rockInst[this.rockCount].gemtype = 3f;
          bool large = false;
          if (c == 29 || c == 30)
            large = true;
          this.rockInst[this.rockCount].init(large, new Vector3(x, height, z), this.sc, num6, (int) x1, (int) z1);
          this.rockInst[this.rockCount].addObject(27);
          objDupe.objectData[(int) x1, (int) z1] = 27;
          this.rockTrans[this.rockCount].Trans = this.rockInst[this.rockCount].Transform;
          this.rockTrans[this.rockCount].Color = this.rockInst[this.rockCount].gemtype;
        }
      }
      if (c != 7 && c != 8 || objDupe.objectData[(int) x1, (int) z1] != 0)
        return;
      int pair = ((int) x1 + (int) z1 + 1) * ((int) x1 + (int) z1) / 2 + (int) z1;
      this.GetHeightNormal(ref heightData, ref normalData, new Vector3(x, 0.0f, z), out height, out normal);
      if (this.flowerCount >= this.maxflowerCount - 1)
        return;
      ++this.flowerCount;
      if (c == 8)
        this.flowerInst[this.flowerCount].stateFlag = 10;
      if (c == 7)
        this.flowerInst[this.flowerCount].stateFlag = 0;
      this.flowerInst[this.flowerCount].initflower(new Vector3(x, height, z), this.sc, pair, (int) x1, (int) z1);
      this.flowerInst[this.flowerCount].addObject(c);
      this.flowerInst[this.flowerCount].gemtype = 1f;
      objDupe.objectData[(int) x1, (int) z1] = c;
      this.flowerTrans[this.flowerCount].Trans = this.flowerInst[this.flowerCount].Transform;
      this.flowerTrans[this.flowerCount].Color = this.flowerInst[this.flowerCount].gemtype;
    }

    public void collideROCKS(
      int vehicleindex,
      ref Lander lander,
      ref Rover rover,
      Vector3 campos,
      ref SoundEffect boulderhit,
      ref SoundEffect crack,
      ref int[,] heightData,
      ref Vector3[,] normals,
      ref int[,] objectData,
      ref Vector3 vec,
      ref Vector3 hitVec)
    {
      this.sc.gemDropType = 0;
      Vector3 vector3_1 = vehicleindex != 1 ? lander.position : rover.position;
      switch (vehicleindex)
      {
        case 1:
          for (int index = 0; index < this.rockClose.Count; ++index)
          {
            int k = this.rockClose[index];
            float num1 = Vector3.DistanceSquared(this.rockInst[k].mypos, rover.position);
            float num2 = (float) (40.0 + (double) this.rockInst[k].scaler * 30.0);
            if ((double) num1 < (double) num2 * (double) num2)
            {
              boulderhit.Play(this.sc.ev, 0.0f, 0.0f);
              Vector2 vector2_1 = Vector2.Zero;
              Vector2 vector2_2 = new Vector2(rover.position.X - this.rockInst[k].mypos.X, rover.position.Z - this.rockInst[k].mypos.Z);
              if ((double) vector2_2.LengthSquared() > 0.0)
                vector2_1 = Vector2.Normalize(vector2_2);
              if (this.rockInst[k].hits > 1)
              {
                rover.grav.X = vector2_1.X * 3f * this.rockInst[k].mass;
                rover.grav.Z = vector2_1.Y * 3f * this.rockInst[k].mass;
                Rover.fric = 0.99f;
                Rover.rockhitCount = 150;
                rover.movement *= 0.0f;
              }
              rover.shockhit = 15;
              bool flag = true;
              this.rockInst[k].move = true;
              if (!this.rockMoving.Contains(k))
                this.rockMoving.Add(k);
              this.rockInst[k].grav.X += (float) (-(double) vector2_1.X * 10.0) / this.rockInst[k].mass;
              this.rockInst[k].grav.Z += (float) (-(double) vector2_1.Y * 10.0) / this.rockInst[k].mass;
              --this.rockInst[k].hits;
              if (this.rockInst[k].hits <= 0)
              {
                this.sc.gemDropPosition = this.rockInst[k].mypos;
                this.sc.gemDropVelocity = this.rockInst[k].grav;
                this.sc.gemDropScale = this.rockInst[k].scaler;
                this.sc.gemDropType = (int) this.rockInst[k].gemtype;
                if (this.sc.gemDropType > 0)
                  this.sc.breakage.Play(this.sc.ev, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
                else
                  this.sc.breakage2.Play(this.sc.ev, (float) this.rr.Next(-10, 30) / 100f, 0.0f);
                this.splitBoulder(k, ref rover, ref boulderhit, ref crack, ref objectData);
              }
              if (flag)
                break;
            }
          }
          break;
        case 2:
          float height1;
          this.GetHeightOnly(ref heightData, lander.position, out height1);
          if ((double) lander.position.Y - (double) height1 < 500.0)
          {
            for (int index1 = 0; index1 < this.rockClose.Count; ++index1)
            {
              int index2 = this.rockClose[index1];
              float num3 = Vector3.DistanceSquared(this.rockInst[index2].mypos, lander.position);
              float num4 = (float) (220.0 + (double) this.rockInst[index2].scaler * 30.0);
              if ((double) num3 < (double) num4 * (double) num4)
              {
                boulderhit.Play(this.sc.ev, 0.0f, 0.0f);
                Vector3 vector3_2 = Vector3.Zero;
                Vector3 vector3_3 = lander.position - this.rockInst[index2].mypos;
                if ((double) vector3_3.LengthSquared() > 0.0)
                  vector3_2 = Vector3.Normalize(vector3_3);
                lander.shockhit = 30;
                lander.velocity = vector3_2 * lander.velocity.Length();
                break;
              }
            }
            break;
          }
          break;
        case 3:
          float height2;
          this.GetHeightOnly(ref heightData, campos, out height2);
          if ((double) campos.Y - (double) height2 < 500.0)
          {
            for (int index3 = 0; index3 < this.rockClose.Count; ++index3)
            {
              int index4 = this.rockClose[index3];
              float num5 = Vector3.DistanceSquared(this.rockInst[index4].mypos, campos);
              float num6 = (float) (50.0 + (double) this.rockInst[index4].scaler * 30.0);
              if ((double) num5 < (double) num6 * (double) num6)
              {
                boulderhit.Play(this.sc.ev, 0.0f, 0.0f);
                Vector3 vector3_4 = Vector3.Zero;
                Vector3 vector3_5 = campos - this.rockInst[index4].mypos;
                if ((double) vector3_5.LengthSquared() > 0.0)
                  vector3_4 = Vector3.Normalize(vector3_5);
                lander.shockhit = 20;
                hitVec = vector3_4 * vec.Length() * 4f;
                break;
              }
            }
            break;
          }
          break;
      }
      for (int index5 = 0; index5 < this.rockMoving.Count; ++index5)
      {
        int index6 = this.rockMoving[index5];
        this.rockInst[index6].Update(ref heightData, ref normals, ref objectData);
        this.rockTrans[index6].Trans = this.rockInst[index6].Transform;
        int num = 0;
        for (int index7 = 0; index7 < this.rockClose.Count; ++index7)
        {
          int index8 = this.rockClose[index7];
          if (index8 != index6 && (double) Vector3.Distance(this.rockInst[index8].mypos, this.rockInst[index6].mypos) < (double) this.rockInst[index6].scaler * 27.0 + (double) this.rockInst[index8].scaler * 27.0)
          {
            Vector3 normal = Vector3.Zero;
            Vector3 vector3_6 = this.rockInst[index6].mypos - this.rockInst[index8].mypos;
            if ((double) vector3_6.LengthSquared() > 0.0)
              normal = Vector3.Normalize(vector3_6);
            this.rockInst[index6].grav = Vector3.Reflect(this.rockInst[index6].grav, normal) * 0.5f;
            this.rockInst[index8].move = true;
            if (!this.rockMoving.Contains(index8))
              this.rockMoving.Add(index8);
            this.rockInst[index8].grav.X += (float) (-(double) normal.X * (double) this.rockInst[index6].mass * 4.0);
            this.rockInst[index8].grav.Z += (float) (-(double) normal.Z * (double) this.rockInst[index6].mass * 4.0);
            ++num;
            if (num > 0)
              break;
          }
        }
        if (!this.rockInst[index6].move || (double) Vector2.Distance(new Vector2(vector3_1.X, vector3_1.Z), new Vector2(this.rockInst[index6].mypos.X, this.rockInst[index6].mypos.Z)) > 13000.0)
        {
          this.rockInst[index6].move = false;
          this.rockMoving.Remove(index6);
        }
      }
      for (int index = 0; index < this.int_1; ++index)
      {
        if (!this.rockBreak_0[index].move)
        {
          this.rockBreak_0[index] = this.rockBreak_0[this.int_1 - 1];
          this.rockBreak_0[index].move = this.rockBreak_0[this.int_1 - 1].move;
          this.rockBreak_0[index].mytime = this.rockBreak_0[this.int_1 - 1].mytime;
          this.rockBreak_0[index].onramp = this.rockBreak_0[this.int_1 - 1].onramp;
          this.rockBreak_0[index].mypos = this.rockBreak_0[this.int_1 - 1].mypos;
          this.rockBreak_0[index].scaler = this.rockBreak_0[this.int_1 - 1].scaler;
          this.rockBreak_0[index].myRot = this.rockBreak_0[this.int_1 - 1].myRot;
          this.rockBreak_0[index].Transform = this.rockBreak_0[this.int_1 - 1].Transform;
          this.rockBreak_0[index].velocity = this.rockBreak_0[this.int_1 - 1].velocity;
          this.rockBreak_0[index].Transform = this.rockBreak_0[this.int_1 - 1].Transform;
          this.transcolor_0[index].Trans = this.rockBreak_0[this.int_1 - 1].Transform;
          this.transcolor_0[index].Color = this.transcolor_0[this.int_1 - 1].Color;
          --this.int_1;
          break;
        }
      }
      for (int index = 0; index < this.int_1; ++index)
      {
        if (this.rockBreak_0[index].move)
        {
          this.rockBreak_0[index].Update(ref heightData);
          this.transcolor_0[index].Trans = this.rockBreak_0[index].Transform;
        }
      }
      for (int index = 0; index < this.int_2; ++index)
      {
        if (!this.rockBreak_1[index].move)
        {
          if (this.rockBreak_1[index].onramp == 10 && (double) this.rockBreak_1[index].scaler > 0.5 && this.int_2 < this.rockBreak_1.Length - 2)
          {
            this.rr = new Random((int) this.rockBreak_1[index].mypos.X * 12);
            Vector3 vector3_7 = new Vector3((float) this.rr.Next(-1000, 1000) / 120f, (float) this.rr.Next(-1000, 1000) / 410f, (float) this.rr.Next(-1000, 1000) / 110f) * this.rockBreak_1[index].scaler;
            Vector3 vector3_8 = new Vector3((float) this.rr.Next(-1000, 1000) / 320f, (float) this.rr.Next(-1000, 1000) / 500f, (float) this.rr.Next(-1000, 1000) / 320f);
            Matrix fromYawPitchRoll1 = Matrix.CreateFromYawPitchRoll(vector3_8.X + (float) this.random.Next(-1000, 1000), vector3_8.X + (float) this.random.Next(-1000, 1000), vector3_8.X);
            this.rockBreak_1[this.int_2] = new rockBreak(this.sc, this.rockBreak_1[index].mypos + vector3_7, this.rockBreak_1[index].scaler / 2f, fromYawPitchRoll1, this.rockBreak_1[index].velocity + vector3_8, 5, true);
            this.transcolor_1[this.int_2].Trans = this.rockBreak_1[this.int_2].Transform;
            this.transcolor_1[this.int_2].Color = this.transcolor_1[index].Color;
            ++this.int_2;
            this.rr = new Random((int) this.rockBreak_1[index].mypos.Z * 76);
            Vector3 vector3_9 = new Vector3((float) this.rr.Next(-1000, 1000) / 90f, (float) this.rr.Next(-1000, 1000) / 395f, (float) this.rr.Next(-1000, 1000) / 90f) * this.rockBreak_1[index].scaler;
            vector3_8 = new Vector3((float) this.rr.Next(-1000, 1000) / 330f, (float) this.rr.Next(-1000, 1000) / 500f, (float) this.rr.Next(-1000, 1000) / 330f);
            Matrix fromYawPitchRoll2 = Matrix.CreateFromYawPitchRoll(vector3_8.X + (float) this.random.Next(-1000, 1000), vector3_8.X + (float) this.random.Next(-1000, 1000), vector3_8.X);
            this.rockBreak_1[this.int_2] = new rockBreak(this.sc, this.rockBreak_1[index].mypos + vector3_9, this.rockBreak_1[index].scaler / 2f, fromYawPitchRoll2, this.rockBreak_1[index].velocity + vector3_8, 5, true);
            this.transcolor_1[this.int_2].Trans = this.rockBreak_1[this.int_2].Transform;
            this.transcolor_1[this.int_2].Color = this.transcolor_1[index].Color;
            ++this.int_2;
          }
          this.rockBreak_1[index] = this.rockBreak_1[this.int_2 - 1];
          this.rockBreak_1[index].move = this.rockBreak_1[this.int_2 - 1].move;
          this.rockBreak_1[index].mytime = this.rockBreak_1[this.int_2 - 1].mytime;
          this.rockBreak_1[index].onramp = this.rockBreak_1[this.int_2 - 1].onramp;
          this.rockBreak_1[index].mypos = this.rockBreak_1[this.int_2 - 1].mypos;
          this.rockBreak_1[index].scaler = this.rockBreak_1[this.int_2 - 1].scaler;
          this.rockBreak_1[index].myRot = this.rockBreak_1[this.int_2 - 1].myRot;
          this.rockBreak_1[index].Transform = this.rockBreak_1[this.int_2 - 1].Transform;
          this.rockBreak_1[index].velocity = this.rockBreak_1[this.int_2 - 1].velocity;
          this.transcolor_1[index].Trans = this.rockBreak_1[this.int_2 - 1].Transform;
          this.transcolor_1[index].Color = this.transcolor_1[this.int_2 - 1].Color;
          --this.int_2;
          break;
        }
      }
      for (int index = 0; index < this.int_2; ++index)
      {
        if (this.rockBreak_1[index].move)
        {
          this.rockBreak_1[index].Update(ref heightData);
          this.transcolor_1[index].Trans = this.rockBreak_1[index].Transform;
        }
      }
    }

    public void splitBoulder(
      int k,
      ref Rover rover,
      ref SoundEffect boulderhit,
      ref SoundEffect crack,
      ref int[,] objectData)
    {
      bool flag = (double) this.rockInst[k].gemtype == 0.0;
      float scaler = this.rockInst[k].scaler;
      Vector3 vector3_1 = this.rockInst[k].mypos + new Vector3(0.0f, (float) (-(double) scaler * 10.0), 0.0f);
      float color = this.rockTrans[k].Color;
      float num = 0.0f;
      Vector3 grav = this.rockInst[k].grav;
      objectData[this.rockInst[k].objx, this.rockInst[k].objz] = 0;
      if (k != this.rockCount)
      {
        this.rockMoving.Remove(k);
        this.rockClose.Remove(k);
        if (this.rockClose.Contains(this.rockCount))
        {
          this.rockClose.Remove(this.rockCount);
          if (!this.rockClose.Contains(k))
            this.rockClose.Add(k);
        }
        if (this.rockInst[this.rockCount].move)
        {
          this.rockMoving.Remove(this.rockCount);
          this.rockMoving.Add(k);
        }
        if (this.rockInst[this.rockCount].onMap)
        {
          this.rockInst[k].onMap = true;
          this.rockInst[k].removeObject();
          this.rockInst[k].objx = this.rockInst[this.rockCount].objx;
          this.rockInst[k].objz = this.rockInst[this.rockCount].objz;
          this.rockInst[k].addObject(27);
          this.rockInst[this.rockCount].onMap = false;
        }
        else
        {
          this.rockInst[k].onMap = false;
          this.rockInst[k].removeObject();
          this.rockInst[k].objx = this.rockInst[this.rockCount].objx;
          this.rockInst[k].objz = this.rockInst[this.rockCount].objz;
          this.rockInst[this.rockCount].removeObject();
          this.rockInst[this.rockCount].onMap = false;
        }
        this.rockInst[k].move = this.rockInst[this.rockCount].move;
        this.rockInst[k].mypos = this.rockInst[this.rockCount].mypos;
        this.rockInst[k].scaler = this.rockInst[this.rockCount].scaler;
        this.rockInst[k].myRot = this.rockInst[this.rockCount].myRot;
        this.rockInst[k].Transform = this.rockInst[this.rockCount].Transform;
        this.rockInst[k].hits = this.rockInst[this.rockCount].hits;
        this.rockInst[k].grav = this.rockInst[this.rockCount].grav;
        this.rockInst[k].gemtype = this.rockInst[this.rockCount].gemtype;
        this.rockTrans[k].Trans = this.rockInst[this.rockCount].Transform;
        this.rockTrans[k].Color = this.rockTrans[this.rockCount].Color;
      }
      else
      {
        this.rockInst[k].removeObject();
        this.rockMoving.Remove(k);
        this.rockClose.Remove(k);
        this.rockInst[k].move = false;
      }
      --this.rockCount;
      if (this.rockCount < 0)
        this.rockCount = 0;
      if (this.int_1 < this.rockBreak_0.Length - 2)
      {
        this.rockBreak_0[this.int_1] = new rockBreak(this.sc, vector3_1 + rover.orientation.Left * (scaler * 12f), scaler, Matrix.CreateFromYawPitchRoll(rover.facingDirection, 0.0f, 0.0f), grav * (float) this.random.Next(60, 150) / 100f + rover.orientation.Left * scaler, 5, false);
        this.transcolor_0[this.int_1].Trans = this.rockBreak_0[this.int_1].Transform;
        this.transcolor_0[this.int_1].Color = num;
        ++this.int_1;
        this.rockBreak_0[this.int_1] = new rockBreak(this.sc, vector3_1 + rover.orientation.Right * (scaler * 12f), scaler, Matrix.CreateFromYawPitchRoll(rover.facingDirection + 3.14f, 0.0f, 0.0f), grav * (float) this.random.Next(60, 150) / 100f + rover.orientation.Right * scaler, 5, false);
        this.transcolor_0[this.int_1].Trans = this.rockBreak_0[this.int_1].Transform;
        this.transcolor_0[this.int_1].Color = num;
        ++this.int_1;
      }
      if (this.int_2 < this.rockBreak_1.Length - 2)
      {
        Vector3 vector3_2 = new Vector3((float) (this.random.Next(-1000, 1000) / 200), (float) (this.random.Next(2000, 6000) / 200), (float) (this.random.Next(-1000, 1000) / 200)) * scaler;
        Vector3 vector3_3 = new Vector3((float) (this.random.Next(-2000, 2000) / 200), (float) (this.random.Next(-2000, 4000) / 200), (float) (this.random.Next(-2000, 2000) / 200));
        Matrix fromYawPitchRoll1 = Matrix.CreateFromYawPitchRoll(vector3_2.X + (float) this.random.Next(-1000, 1000), vector3_2.X + (float) this.random.Next(-1000, 1000), vector3_2.X);
        this.rockBreak_1[this.int_2] = new rockBreak(this.sc, vector3_1 + vector3_2, scaler / ((float) this.random.Next(120, 250) / 100f), fromYawPitchRoll1, -grav + vector3_3, 5, true);
        this.transcolor_1[this.int_2].Trans = this.rockBreak_1[this.int_2].Transform;
        ++this.int_2;
        Vector3 vector3_4 = new Vector3((float) (this.random.Next(-1000, 1000) / 200), (float) (this.random.Next(-1000, 3000) / 200), (float) (this.random.Next(-1000, 1000) / 200)) * scaler;
        vector3_3 = new Vector3((float) (this.random.Next(-2000, 2000) / 200), (float) (this.random.Next(-2000, 4000) / 200), (float) (this.random.Next(-2000, 2000) / 200));
        Matrix fromYawPitchRoll2 = Matrix.CreateFromYawPitchRoll(vector3_4.X + (float) this.random.Next(-1000, 1000), vector3_4.X + (float) this.random.Next(-1000, 1000), vector3_4.X);
        this.rockBreak_1[this.int_2] = new rockBreak(this.sc, vector3_1 + vector3_4, scaler / ((float) this.random.Next(130, 280) / 100f), fromYawPitchRoll2, grav + vector3_3, 5, true);
        this.transcolor_1[this.int_2].Trans = this.rockBreak_1[this.int_2].Transform;
        ++this.int_2;
        if (flag)
        {
          vector3_4 = new Vector3((float) (this.random.Next(-1000, 1000) / 200), (float) (this.random.Next(-1000, 3000) / 200), (float) (this.random.Next(-1000, 1000) / 200)) * scaler;
          vector3_3 = new Vector3((float) (this.random.Next(-2000, 2000) / 200), (float) (this.random.Next(-2000, 4000) / 200), (float) (this.random.Next(-2000, 2000) / 200));
          Matrix fromYawPitchRoll3 = Matrix.CreateFromYawPitchRoll(vector3_4.X + (float) this.random.Next(-1000, 1000), vector3_4.X + (float) this.random.Next(-1000, 1000), vector3_4.X);
          this.rockBreak_1[this.int_2] = new rockBreak(this.sc, vector3_1 + vector3_4, scaler / ((float) this.random.Next(120, 250) / 100f), fromYawPitchRoll3, grav + vector3_3, 5, false);
          this.transcolor_1[this.int_2].Trans = this.rockBreak_1[this.int_2].Transform;
          ++this.int_2;
        }
      }
      if ((double) scaler <= 3.0)
        return;
      crack.Play(this.sc.ev, 0.0f, 0.0f);
    }

    public void placeSLABLET(
      Vector3 grnd,
      ref int[,] heightData,
      ref Vector3[,] normalData,
      float ratio)
    {
      ratio *= 0.43f;
      float radians1 = 0.0f;
      float num1 = (float) this.random.Next(50, 800) / 100f;
      int num2 = this.random.Next(2, 5);
      float height;
      Vector3 normal;
      for (int index = 0; index < num2; ++index)
      {
        if (this.int_0 < this.slab2max - 1)
        {
          radians1 += (float) this.random.Next(50, 150) / 100f;
          if ((double) radians1 <= 6.28000020980835 + (double) num1)
          {
            Vector3 vector3 = Vector3.Transform(ratio * Vector3.Right * (float) this.random.Next(1300, 1600) / 10f, Matrix.CreateRotationY(radians1));
            this.GetHeightNormal(ref heightData, ref normalData, grnd + vector3, out height, out normal);
            ++this.int_0;
            int int0 = this.int_0;
            this.slabDupe2_0[int0].init(new Vector3(grnd.X + vector3.X, height, grnd.Z + vector3.Z), normal, 1f * ratio, this.random.Next(2, 4000));
            this.transcolor_2[int0].Trans = this.slabDupe2_0[int0].Transform;
          }
          else
            break;
        }
      }
      float radians2 = 0.0f;
      float num3 = (float) this.random.Next(50, 800) / 100f;
      int num4 = this.random.Next(2, 6);
      for (int index = 0; index < num4; ++index)
      {
        if (this.int_0 < this.slab2max - 1)
        {
          radians2 += (float) this.random.Next(50, 150) / 100f;
          if ((double) radians2 <= 6.28000020980835 + (double) num3)
          {
            Vector3 vector3 = Vector3.Transform(ratio * Vector3.Right * (float) this.random.Next(1700, 2300) / 10f, Matrix.CreateRotationY(radians2));
            this.GetHeightNormal(ref heightData, ref normalData, grnd + vector3, out height, out normal);
            ++this.int_0;
            int int0 = this.int_0;
            this.slabDupe2_0[int0].init(new Vector3(grnd.X + vector3.X, height, grnd.Z + vector3.Z), normal, 0.8f * ratio, this.random.Next(2, 4000));
            this.transcolor_2[int0].Trans = this.slabDupe2_0[int0].Transform;
          }
          else
            break;
        }
      }
      float radians3 = 0.0f;
      float num5 = (float) this.random.Next(50, 800) / 100f;
      int num6 = this.random.Next(2, 7);
      for (int index = 0; index < num6; ++index)
      {
        if (this.int_0 < this.slab2max - 1)
        {
          radians3 += (float) this.random.Next(50, 150) / 100f;
          if ((double) radians3 > 6.28000020980835 + (double) num5)
            break;
          Vector3 vector3 = Vector3.Transform(ratio * Vector3.Right * (float) this.random.Next(2450, 2700) / 10f, Matrix.CreateRotationY(radians3));
          this.GetHeightNormal(ref heightData, ref normalData, grnd + vector3, out height, out normal);
          ++this.int_0;
          int int0 = this.int_0;
          this.slabDupe2_0[int0].init(new Vector3(grnd.X + vector3.X, height, grnd.Z + vector3.Z), normal, 0.5f * ratio, this.random.Next(2, 4000));
          this.transcolor_2[int0].Trans = this.slabDupe2_0[int0].Transform;
        }
      }
    }

    public void method_0(
      int vehicleindex,
      ref Rover rover,
      ref Lander lander,
      ref int[,] heightData,
      ref Vector3[,] normalData,
      ref int[,] objectData)
    {
      Vector3 vector3 = vehicleindex != 1 ? lander.position : rover.position;
      this.slabInst[0].init(new Vector3(0.0f, -100000f, 0.0f), Vector3.Up, this.random.Next(2, 4000));
      this.slabTrans[0].Trans = this.slabInst[0].Transform;
      for (int index = 1; index < this.slabmax; ++index)
      {
        float x = vector3.X + (float) this.random.Next(-this.acre, this.acre);
        float z = vector3.Z + (float) this.random.Next(-this.acre, this.acre);
        float height;
        Vector3 normal;
        this.GetHeightNormal(ref heightData, ref normalData, new Vector3(x, 0.0f, z), out height, out normal);
        int num1 = 2000 * this.gridscale;
        float num2 = (float) (((double) x + 200.0) % (double) num1 + 1.5 * (double) num1) % (float) num1;
        float num3 = (float) (((double) z + 200.0) % (double) num1 + 1.5 * (double) num1) % (float) num1;
        float num4 = (float) ((int) num2 / this.gridscale);
        float num5 = (float) ((int) num3 / this.gridscale);
        int num6 = objectData[(int) num4 / 4, (int) num5 / 4];
        if ((double) normal.Y <= (double) this.maxAngle && (double) normal.Y >= (double) this.minAngle && num6 == 5)
        {
          ++this.slabCount;
          this.slabInst[this.slabCount].init(new Vector3(x, height, z), normal, this.random.Next(2, 4000));
          this.slabTrans[this.slabCount].Trans = this.slabInst[this.slabCount].Transform;
          if (this.int_0 < this.slab2max - 1)
            this.placeSLABLET(new Vector3(x, height, z), ref heightData, ref normalData, this.slabInst[this.slabCount].scaler);
        }
      }
    }

    public void method_1(
      int frame,
      int vehicleindex,
      Vector3 grnd,
      ref int[,] heightData,
      ref Vector3[,] normalData,
      ref int[,] objectData)
    {
      int num1 = frame % 50;
      for (int index = 1 + num1; index <= this.slabCount && index <= this.slabCount; index += 50)
      {
        if ((double) Vector2.DistanceSquared(new Vector2(grnd.X, grnd.Z), new Vector2(this.slabInst[index].mypos.X, this.slabInst[index].mypos.Z)) > (double) ((this.acre + 9000) * (this.acre + 9000)))
        {
          if (index != this.slabCount)
          {
            this.slabInst[index].move = this.slabInst[this.slabCount].move;
            this.slabInst[index].mypos = this.slabInst[this.slabCount].mypos;
            this.slabInst[index].scaler = this.slabInst[this.slabCount].scaler;
            this.slabInst[index].myRot = this.slabInst[this.slabCount].myRot;
            this.slabInst[index].Transform = this.slabInst[this.slabCount].Transform;
            this.slabInst[index].hits = this.slabInst[this.slabCount].hits;
            this.slabInst[index].grav = this.slabInst[this.slabCount].grav;
            this.slabTrans[index].Trans = this.slabInst[this.slabCount].Transform;
          }
          --this.slabCount;
          if (this.slabCount < 0)
            this.slabCount = 0;
        }
      }
      for (int index = 1 + num1; index <= this.int_0 && index <= this.int_0; index += 50)
      {
        if ((double) Vector2.DistanceSquared(new Vector2(grnd.X, grnd.Z), new Vector2(this.slabDupe2_0[index].mypos.X, this.slabDupe2_0[index].mypos.Z)) > (double) ((this.acre + 5000) * (this.acre + 5000)))
        {
          if (index != this.int_0)
          {
            this.slabDupe2_0[index].move = this.slabDupe2_0[this.int_0].move;
            this.slabDupe2_0[index].mypos = this.slabDupe2_0[this.int_0].mypos;
            this.slabDupe2_0[index].scaler = this.slabDupe2_0[this.int_0].scaler;
            this.slabDupe2_0[index].myRot = this.slabDupe2_0[this.int_0].myRot;
            this.slabDupe2_0[index].Transform = this.slabDupe2_0[this.int_0].Transform;
            this.slabDupe2_0[index].hits = this.slabDupe2_0[this.int_0].hits;
            this.slabDupe2_0[index].grav = this.slabDupe2_0[this.int_0].grav;
            this.transcolor_2[index].Trans = this.slabDupe2_0[this.int_0].Transform;
          }
          --this.int_0;
          if (this.int_0 < 0)
            this.int_0 = 0;
        }
      }
      this.slabPOS.X = grnd.X;
      this.slabPOS.Y = grnd.Z;
      float num2 = Math.Abs(this.slabPOS.X - this.vector2_0.X);
      float num3 = Math.Abs(this.slabPOS.Y - this.vector2_0.Y);
      if ((double) num2 <= 300.0 && (double) num3 <= 300.0)
        return;
      if (this.slabCount < this.slabmax - 1)
      {
        float x;
        float z;
        if ((double) num2 >= (double) num3)
        {
          if ((double) this.slabPOS.X > (double) this.vector2_0.X)
          {
            x = grnd.X + (float) this.acre;
            z = grnd.Z + (float) this.random.Next(-this.acre, this.acre);
          }
          else
          {
            x = grnd.X - (float) this.acre;
            z = grnd.Z + (float) this.random.Next(-this.acre, this.acre);
          }
        }
        else if ((double) this.slabPOS.Y > (double) this.vector2_0.Y)
        {
          x = grnd.X + (float) this.random.Next(-this.acre, this.acre);
          z = grnd.Z + (float) this.acre;
        }
        else
        {
          x = grnd.X + (float) this.random.Next(-this.acre, this.acre);
          z = grnd.Z - (float) this.acre;
        }
        float height;
        Vector3 normal;
        this.GetHeightNormal(ref heightData, ref normalData, new Vector3(x, 0.0f, z), out height, out normal);
        int num4 = 2000 * this.gridscale;
        float num5 = (float) (((double) x + 200.0) % (double) num4 + 1.5 * (double) num4) % (float) num4;
        float num6 = (float) (((double) z + 200.0) % (double) num4 + 1.5 * (double) num4) % (float) num4;
        float num7 = (float) ((int) num5 / this.gridscale);
        float num8 = (float) ((int) num6 / this.gridscale);
        int num9 = objectData[(int) num7 / 4, (int) num8 / 4];
        if ((double) normal.Y <= (double) this.maxAngle && (double) normal.Y >= (double) this.minAngle && num9 == 5)
        {
          ++this.slabCount;
          int slabCount = this.slabCount;
          this.slabInst[slabCount].init(new Vector3(x, height, z), normal, this.random.Next(2, 4000));
          this.slabTrans[slabCount].Trans = this.slabInst[slabCount].Transform;
          if (this.int_0 < this.slab2max - 1)
            this.placeSLABLET(new Vector3(x, height, z), ref heightData, ref normalData, this.slabInst[this.slabCount].scaler);
        }
      }
      this.vector2_0 = this.slabPOS;
    }

    public void drawObjects(Vector3 light, Vector3 amb, Vector3 diff, Matrix view, Matrix proj)
    {
      this.DrawInstance(this.rock, this.rockTrans, this.rockCount, this.rockBuffer, light, amb, diff, view, proj);
    }

    public void drawFlowers(Vector3 light, Vector3 amb, Vector3 diff, Matrix view, Matrix proj)
    {
      this.DrawInstanceFlower(this.flower, this.flowerTrans, this.flowerCount, this.flowerBuffer, light, amb, diff, view, proj);
    }

    public void drawSlabs(
      Vector3 light,
      Vector3 amb,
      Vector3 diff,
      Matrix view,
      Matrix proj,
      Vector3 campos)
    {
      this.DrawInstanceSlab(this.slab, this.slabTrans, this.slabCount, this.slabBuffer, light, amb, diff, view, proj, campos);
      this.DrawInstanceSlab(this.slablet, this.transcolor_2, this.int_0, this.dynamicVertexBuffer_2, light, amb, diff, view, proj, campos);
    }

    public void drawRockRubble(
      Vector3 light,
      Vector3 amb,
      Vector3 diff,
      Matrix view,
      Matrix proj)
    {
      this.DrawInstance2(this.rock1, this.transcolor_0, this.int_1, this.dynamicVertexBuffer_0, light, amb, diff, view, proj);
    }

    public void drawBrokenSides(
      Vector3 light,
      Vector3 amb,
      Vector3 diff,
      Matrix view,
      Matrix proj)
    {
      this.DrawInstance2(this.rock2, this.transcolor_1, this.int_2, this.dynamicVertexBuffer_1, light, amb, diff, view, proj);
    }

    public void DrawInstanceSlab(
      Model model,
      rockstruct.transcolor[] minstances,
      int cc,
      DynamicVertexBuffer dd,
      Vector3 light,
      Vector3 amb,
      Vector3 diff,
      Matrix view,
      Matrix proj,
      Vector3 campos)
    {
      if (cc == 0)
        return;
      ModelMeshPart meshPart = model.Meshes[0].MeshParts[0];
      dd.SetData<rockstruct.transcolor>(minstances, 1, cc, SetDataOptions.Discard);
      this._vertexBufferBindings[0] = new VertexBufferBinding(meshPart.VertexBuffer, meshPart.VertexOffset, 0);
      this._vertexBufferBindings[1] = new VertexBufferBinding((VertexBuffer) dd, 0, 1);
      this.sc.GraphicsDevice.SetVertexBuffers(this._vertexBufferBindings);
      this.gr.Indices = meshPart.IndexBuffer;
      Effect effect = meshPart.Effect;
      ++this.frame;
      effect.CurrentTechnique = effect.Techniques["Reflection1"];
      effect.Parameters["ReflectionMap"].SetValue((Texture) this.reflection);
      effect.Parameters["slide"].SetValue((float) this.frame / 150f);
      effect.Parameters["CameraPosition"].SetValue(campos);
      effect.Parameters["View"].SetValue(view);
      effect.Parameters["Projection"].SetValue(proj);
      effect.Parameters["LightDirection"].SetValue(light);
      effect.Parameters[nameof (diff)].SetValue(diff);
      effect.Parameters[nameof (amb)].SetValue(amb);
      effect.CurrentTechnique.Passes[0].Apply();
      this.gr.DrawInstancedPrimitives(PrimitiveType.TriangleList, 0, 0, meshPart.NumVertices, meshPart.StartIndex, meshPart.PrimitiveCount, cc);
    }

    public void DrawInstanceFlower(
      Model model,
      rockstruct.transcolor[] minstances,
      int cc,
      DynamicVertexBuffer dd,
      Vector3 light,
      Vector3 amb,
      Vector3 diff,
      Matrix view,
      Matrix proj)
    {
      if (cc == 0)
        return;
      ModelMeshPart meshPart = model.Meshes[0].MeshParts[0];
      dd.SetData<rockstruct.transcolor>(minstances, 1, cc, SetDataOptions.Discard);
      this._vertexBufferBindings[0] = new VertexBufferBinding(meshPart.VertexBuffer, meshPart.VertexOffset, 0);
      this._vertexBufferBindings[1] = new VertexBufferBinding((VertexBuffer) dd, 0, 1);
      this.sc.GraphicsDevice.SetVertexBuffers(this._vertexBufferBindings);
      this.gr.Indices = meshPart.IndexBuffer;
      Effect effect = meshPart.Effect;
      effect.CurrentTechnique = effect.Techniques["fastShaderflower"];
      effect.Parameters["View"].SetValue(view);
      effect.Parameters["Projection"].SetValue(proj);
      effect.Parameters["LightDirection"].SetValue(light);
      effect.Parameters[nameof (diff)].SetValue(diff);
      effect.Parameters[nameof (amb)].SetValue(amb);
      effect.CurrentTechnique.Passes[0].Apply();
      this.gr.DrawInstancedPrimitives(PrimitiveType.TriangleList, 0, 0, meshPart.NumVertices, meshPart.StartIndex, meshPart.PrimitiveCount, cc);
    }

    public void DrawInstance(
      Model model,
      rockstruct.transcolor[] minstances,
      int cc,
      DynamicVertexBuffer dd,
      Vector3 light,
      Vector3 amb,
      Vector3 diff,
      Matrix view,
      Matrix proj)
    {
      if (cc == 0)
        return;
      ModelMeshPart meshPart = model.Meshes[0].MeshParts[0];
      dd.SetData<rockstruct.transcolor>(minstances, 1, cc, SetDataOptions.Discard);
      this._vertexBufferBindings[0] = new VertexBufferBinding(meshPart.VertexBuffer, meshPart.VertexOffset, 0);
      this._vertexBufferBindings[1] = new VertexBufferBinding((VertexBuffer) dd, 0, 1);
      this.sc.GraphicsDevice.SetVertexBuffers(this._vertexBufferBindings);
      this.gr.Indices = meshPart.IndexBuffer;
      Effect effect = meshPart.Effect;
      effect.CurrentTechnique = effect.Techniques["fastShader"];
      effect.Parameters["View"].SetValue(view);
      effect.Parameters["Projection"].SetValue(proj);
      effect.Parameters["LightDirection"].SetValue(light);
      effect.Parameters[nameof (diff)].SetValue(diff);
      effect.Parameters[nameof (amb)].SetValue(amb);
      effect.CurrentTechnique.Passes[0].Apply();
      this.gr.DrawInstancedPrimitives(PrimitiveType.TriangleList, 0, 0, meshPart.NumVertices, meshPart.StartIndex, meshPart.PrimitiveCount, cc);
    }

    public void DrawInstance2(
      Model model,
      rockstruct.transcolor[] minstances,
      int cc,
      DynamicVertexBuffer dd,
      Vector3 light,
      Vector3 amb,
      Vector3 diff,
      Matrix view,
      Matrix proj)
    {
      if (cc == 0)
        return;
      ModelMeshPart meshPart = model.Meshes[0].MeshParts[0];
      dd.SetData<rockstruct.transcolor>(minstances, 0, cc, SetDataOptions.Discard);
      this._vertexBufferBindings[0] = new VertexBufferBinding(meshPart.VertexBuffer, meshPart.VertexOffset, 0);
      this._vertexBufferBindings[1] = new VertexBufferBinding((VertexBuffer) dd, 0, 1);
      this.sc.GraphicsDevice.SetVertexBuffers(this._vertexBufferBindings);
      this.gr.Indices = meshPart.IndexBuffer;
      Effect effect = meshPart.Effect;
      effect.CurrentTechnique = effect.Techniques["fastShader"];
      effect.Parameters["View"].SetValue(view);
      effect.Parameters["Projection"].SetValue(proj);
      effect.Parameters["LightDirection"].SetValue(light);
      effect.Parameters[nameof (diff)].SetValue(diff);
      effect.Parameters[nameof (amb)].SetValue(amb);
      effect.CurrentTechnique.Passes[0].Apply();
      this.gr.DrawInstancedPrimitives(PrimitiveType.TriangleList, 0, 0, meshPart.NumVertices, meshPart.StartIndex, meshPart.PrimitiveCount, cc);
    }

    public void GetHeightOnly(ref int[,] heightData, Vector3 position, out float height)
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

    private void GetHeightNormalX(
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

    public void GetHeightNormal(
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

    public void GetHeightNormalReturns(
      ref int[,] heightData,
      ref Vector3[,] normals,
      Vector3 position,
      out float height,
      out int objx,
      out int objz)
    {
      int gridScale = this.sc.gridScale;
      int bitmap = this.sc.bitmap;
      int num1 = (bitmap - 1) * gridScale;
      position.X = (float) ((double) position.X % (double) num1 + 1.5 * (double) num1) % (float) num1;
      position.Z = (float) ((double) position.Z % (double) num1 + 1.5 * (double) num1) % (float) num1;
      Vector3 vector3_1 = position;
      int x1 = (int) vector3_1.X / gridScale;
      int z1 = (int) vector3_1.Z / gridScale;
      objx = x1;
      objz = z1;
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
    }

    public struct transcolor : IVertexType
    {
      public Matrix Trans;
      public float Color;
      private static readonly VertexDeclaration VertexDeclaration = new VertexDeclaration(new VertexElement[5]
      {
        new VertexElement(0, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 0),
        new VertexElement(16, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 1),
        new VertexElement(32, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 2),
        new VertexElement(48, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 3),
        new VertexElement(64, VertexElementFormat.Single, VertexElementUsage.Fog, 0)
      });

      VertexDeclaration IVertexType.VertexDeclaration => rockstruct.transcolor.VertexDeclaration;
    }
  }
}
