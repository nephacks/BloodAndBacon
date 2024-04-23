// Decompiled with JetBrains decompiler
// Type: Blood.tmake
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace Blood
{
  internal class tmake : GameScreen
  {
    private GraphicsDevice device;
    private ContentManager content;
    public int Tw;
    public int gridScale;
    public VertexMultitextured[] Tv;
    public int[] terrainIndices;
    private int[,] heightDatax;
    public VertexBuffer terrainVertexBuffer;
    public IndexBuffer terrainIndexBuffer;
    public VertexBuffer terrainVertexDeclaration;
    public int[,] heightData;
    public Vector3[,] normals;
    public Vector3 heightmapPosition;
    public int heightmapWidth;
    private ScreenManager sc;

    public void Load(ContentManager content, ScreenManager graphics)
    {
      this.sc = graphics;
      this.Tw = this.sc.bitmap;
      this.gridScale = this.sc.gridScale;
      this.Tv = new VertexMultitextured[this.Tw * this.Tw];
      this.device = graphics.GraphicsDevice;
      if (content != null)
        return;
      content = new ContentManager((IServiceProvider) this.sc.Game.Services, "Content");
    }

    public override void UnloadContent()
    {
      this.content.Unload();
      this.terrainVertexBuffer.Dispose();
      this.terrainIndexBuffer.Dispose();
      this.terrainVertexDeclaration.Dispose();
      this.Tv = new VertexMultitextured[0];
      this.heightData = new int[0, 0];
      this.normals = new Vector3[0, 0];
    }

    public void move(int x, int z)
    {
      this.terrainVertexBuffer.SetData<VertexMultitextured>(0, this.Tv, z * 290, 290, 56);
    }

    public void moveall() => this.terrainVertexBuffer.SetData<VertexMultitextured>(this.Tv);

    public void moveX(int indexer)
    {
      this.terrainVertexBuffer.SetData<VertexMultitextured>(indexer * 14 * 4, this.Tv, indexer, 5, 56);
    }

    public void moveOne(int indexer)
    {
      this.terrainVertexBuffer.SetData<VertexMultitextured>(indexer * 14 * 4, this.Tv, indexer, 1, 56);
    }

    public void LoadVertices()
    {
      this.LoadHeightData();
      VertexMultitextured[] vertices = this.SetUpTv();
      this.terrainIndices = this.SetUpTerrainIndices();
      VertexMultitextured[] normals = this.CalculateNormals(vertices, this.terrainIndices);
      this.CopyToTerrainBuffers(normals, this.terrainIndices);
      this.terrainVertexDeclaration = new VertexBuffer(this.device, typeof (VertexMultitextured), normals.Length, BufferUsage.None);
    }

    public void LoadHeightData()
    {
      this.heightmapWidth = (this.Tw - 1) * this.gridScale;
      this.heightData = new int[this.Tw, this.Tw];
      this.heightDatax = new int[this.Tw + 1, this.Tw + 1];
      for (int index1 = 0; index1 < this.Tw; ++index1)
      {
        for (int index2 = 0; index2 < this.Tw; ++index2)
        {
          this.heightDatax[index1, index2] = 5;
          this.heightData[index1, index2] = this.heightDatax[index1, index2];
          if (index2 == this.Tw - 1)
          {
            this.heightData[index1, index2] = this.heightDatax[index1, 0];
            this.heightDatax[index1, index2] = this.heightDatax[index1, 0];
          }
          if (index1 == this.Tw - 1)
          {
            this.heightData[index1, index2] = this.heightDatax[0, index2];
            this.heightDatax[index1, index2] = this.heightDatax[0, index2];
          }
        }
      }
    }

    public VertexMultitextured[] SetUpTv()
    {
      float gridScale = (float) this.gridScale;
      this.heightmapPosition = new Vector3((float) -((this.Tw - 1) * this.gridScale / 2), 0.0f, (float) -((this.Tw - 1) * this.gridScale / 2));
      for (int index1 = 0; index1 < this.Tw; ++index1)
      {
        for (int index2 = 0; index2 < this.Tw; ++index2)
        {
          this.Tv[index1 + index2 * this.Tw].Position = new Vector3(gridScale * (float) (index1 - (this.Tw - 1) / 2), (float) this.heightDatax[index1, index2], gridScale * (float) (index2 - (this.Tw - 1) / 2));
          this.Tv[index1 + index2 * this.Tw].TextureCoordinate.X = (float) index1 / ((float) (this.Tw - 1) / 10f);
          this.Tv[index1 + index2 * this.Tw].TextureCoordinate.Y = (float) index2 / ((float) (this.Tw - 1) / 10f);
          this.Tv[index1 + index2 * this.Tw].TexWeights.X = MathHelper.Clamp((float) (1.0 - (double) Math.Abs(this.heightDatax[index1, index2]) / 40.0), 0.0f, 1f);
          this.Tv[index1 + index2 * this.Tw].TexWeights.Y = MathHelper.Clamp((float) (1.0 - (double) Math.Abs(this.heightDatax[index1, index2] - 50) / 80.0), 0.0f, 1f);
          this.Tv[index1 + index2 * this.Tw].TexWeights.Z = MathHelper.Clamp((float) (1.0 - (double) Math.Abs(this.heightDatax[index1, index2] - 140) / 120.0), 0.0f, 1f);
          this.Tv[index1 + index2 * this.Tw].TexWeights.W = MathHelper.Clamp((float) (1.0 - (double) Math.Abs(this.heightDatax[index1, index2] - 410) / 180.0), 0.0f, 1f);
          float num = this.Tv[index1 + index2 * this.Tw].TexWeights.X + this.Tv[index1 + index2 * this.Tw].TexWeights.Y + this.Tv[index1 + index2 * this.Tw].TexWeights.Z + this.Tv[index1 + index2 * this.Tw].TexWeights.W;
          this.Tv[index1 + index2 * this.Tw].TexWeights.X /= num;
          this.Tv[index1 + index2 * this.Tw].TexWeights.Y /= num;
          this.Tv[index1 + index2 * this.Tw].TexWeights.Z /= num;
          this.Tv[index1 + index2 * this.Tw].TexWeights.W /= num;
        }
      }
      return this.Tv;
    }

    public int[] SetUpTerrainIndices()
    {
      int[] numArray1 = new int[(this.Tw - 1) * (this.Tw - 1) * 6];
      int num1 = 0;
      for (int index1 = 0; index1 < this.Tw - 1; ++index1)
      {
        for (int index2 = 0; index2 < this.Tw - 1; ++index2)
        {
          int num2 = index1 + index2 * this.Tw;
          int num3 = index1 + 1 + index2 * this.Tw;
          int num4 = index1 + (index2 + 1) * this.Tw;
          int num5 = index1 + 1 + (index2 + 1) * this.Tw;
          int[] numArray2 = numArray1;
          int index3 = num1;
          int num6 = index3 + 1;
          int num7 = num2;
          numArray2[index3] = num7;
          int[] numArray3 = numArray1;
          int index4 = num6;
          int num8 = index4 + 1;
          int num9 = num3;
          numArray3[index4] = num9;
          int[] numArray4 = numArray1;
          int index5 = num8;
          int num10 = index5 + 1;
          int num11 = num4;
          numArray4[index5] = num11;
          int[] numArray5 = numArray1;
          int index6 = num10;
          int num12 = index6 + 1;
          int num13 = num3;
          numArray5[index6] = num13;
          int[] numArray6 = numArray1;
          int index7 = num12;
          int num14 = index7 + 1;
          int num15 = num5;
          numArray6[index7] = num15;
          int[] numArray7 = numArray1;
          int index8 = num14;
          num1 = index8 + 1;
          int num16 = num4;
          numArray7[index8] = num16;
        }
      }
      return numArray1;
    }

    public VertexMultitextured[] CalculateNormals(VertexMultitextured[] vertices, int[] indices)
    {
      for (int index = 0; index < vertices.Length; ++index)
        vertices[index].Normal = new Vector3(0.0f, 0.0f, 0.0f);
      int index1 = 0;
      int index2 = 0;
      int num = 1;
      this.normals = new Vector3[this.Tw, this.Tw];
      for (int index3 = 0; index3 < indices.Length / 3; ++index3)
      {
        int index4 = indices[index3 * 3];
        int index5 = indices[index3 * 3 + 1];
        int index6 = indices[index3 * 3 + 2];
        Vector3 vector3 = Vector3.Cross(vertices[index4].Position - vertices[index6].Position, vertices[index4].Position - vertices[index5].Position);
        vertices[index4].Normal += vector3;
        vertices[index5].Normal += vector3;
        vertices[index6].Normal += vector3;
        ++num;
        if (num > 1)
        {
          this.normals[index1, index2] = vector3;
          num = 0;
          ++index2;
          if (index2 >= this.Tw - 1)
          {
            index2 = 0;
            ++index1;
          }
        }
      }
      for (int index7 = 0; index7 < vertices.Length; ++index7)
        vertices[index7].Normal.Normalize();
      for (int index8 = 0; index8 < this.Tw; ++index8)
      {
        int index9 = index8;
        int index10 = this.Tw * this.Tw - this.Tw + index8;
        Vector3 vector3_1 = (vertices[index9].Normal + vertices[index10].Normal) / 2f;
        vertices[index9].Normal = vector3_1;
        vertices[index10].Normal = vector3_1;
        int index11 = index8 * this.Tw;
        int index12 = index8 * this.Tw + (this.Tw - 1);
        Vector3 vector3_2 = (vertices[index11].Normal + vertices[index12].Normal) / 2f;
        vertices[index11].Normal = vector3_2;
        vertices[index12].Normal = vector3_2;
      }
      return vertices;
    }

    public void CopyToTerrainBuffers(VertexMultitextured[] vertices, int[] indices)
    {
      this.terrainVertexBuffer = new VertexBuffer(this.device, typeof (VertexMultitextured), vertices.Length, BufferUsage.WriteOnly);
      this.terrainVertexBuffer.SetData<VertexMultitextured>(vertices);
      this.terrainIndexBuffer = new IndexBuffer(this.device, typeof (int), indices.Length, BufferUsage.WriteOnly);
      this.terrainIndexBuffer.SetData<int>(indices);
    }

    public void updateTerrainBuffers(VertexMultitextured[] vertices)
    {
      this.terrainVertexBuffer.SetData<VertexMultitextured>(vertices);
    }

    public VertexPositionTexture[] SetUpFullscreenVertices()
    {
      return new VertexPositionTexture[4]
      {
        new VertexPositionTexture(new Vector3(-1f, 1f, 0.0f), new Vector2(0.0f, 1f)),
        new VertexPositionTexture(new Vector3(1f, 1f, 0.0f), new Vector2(1f, 1f)),
        new VertexPositionTexture(new Vector3(-1f, -1f, 0.0f), new Vector2(0.0f, 0.0f)),
        new VertexPositionTexture(new Vector3(1f, -1f, 0.0f), new Vector2(1f, 0.0f))
      };
    }
  }
}
