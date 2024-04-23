// Decompiled with JetBrains decompiler
// Type: Blood.GlobeMaker
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
  internal class GlobeMaker : GameScreen
  {
    private GraphicsDevice device;
    private ContentManager content;
    private string bodytype = "moon";
    public int Tw;
    public float scale = 40000f;
    public float radius;
    public VertexBuffer terrainVertexBuffer;
    public IndexBuffer terrainIndexBuffer;
    public VertexBuffer terrainVertexDeclaration;
    public int craterindex = 1;
    public int craterindex2 = 1;
    public int craterindex3 = 1;
    public float blend1 = 1f;
    public float blend2;
    public float blend3;
    public int bumpindex = 1;
    public int bumpit = 1;
    public int bumpit2 = 1;
    public int startx;
    public int starty;
    public float bumpreduce = 1f;
    public int bumpindex2 = 1;
    public int startx2;
    public int starty2;
    public float bumpreduce2 = 1f;
    public float spinspeed;
    public float axisangle;
    public int poly = 80;
    public float tall = 1f;
    public float spec = 1f;
    public float spec2 = 5f;
    public float spec3 = 5f;
    public float specA = 1f;
    public float specA2 = 5f;
    public float specA3 = 5f;
    public float clamp1;
    public float clamp2;
    public float s1 = 1f;
    public float spintoggle;
    public int[,] heightData;
    private Random random;

    public void Load(ContentManager contentx, ScreenManager graphics, string body, float diameter)
    {
      this.scale = diameter;
      this.random = new Random();
      this.bodytype = body;
      this.content = contentx;
      this.device = graphics.GraphicsDevice;
      if (this.content != null)
        return;
      this.content = new ContentManager((IServiceProvider) this.ScreenManager.Game.Services, "Content");
    }

    public void LoadVertices()
    {
      this.LoadHeightData();
      VertexGlobe[] vertices = this.SetUpTv();
      int[] indices = this.SetUpTerrainIndices();
      VertexGlobe[] normals = this.CalculateNormals(vertices, indices);
      this.CopyToTerrainBuffers(normals, indices);
      this.terrainVertexDeclaration = new VertexBuffer(this.device, typeof (VertexGlobe), normals.Length, BufferUsage.None);
    }

    public void LoadHeightData()
    {
      this.Tw = this.poly;
      this.heightData = new int[this.poly, this.poly];
    }

    public VertexGlobe[] SetUpTv()
    {
      VertexGlobe[] vertexGlobeArray = new VertexGlobe[this.Tw * this.Tw];
      for (int index1 = 0; index1 < this.Tw; ++index1)
      {
        for (int index2 = 0; index2 < this.Tw; ++index2)
        {
          float num1 = (float) index2;
          if ((double) num1 == (double) (this.Tw - 1))
            num1 = 0.0f;
          this.radius = 205f * this.scale;
          if (this.bodytype == "moon")
            this.radius = (float) (this.heightData[index1, index2] + 100) * this.scale;
          float num2 = (float) (((double) index1 - (double) (this.Tw - 1) / 2.0) / ((double) this.Tw / (3.1415927410125732 + 3.1415927410125732 / (double) (this.Tw - 1))));
          float num3 = (float) (((double) num1 - (double) (this.Tw - 1) / 2.0) / ((double) this.Tw / (6.2831854820251465 + 6.2831854820251465 / (double) (this.Tw - 1))));
          float num4 = (float) (Math.Sin(((double) num2 + (double) this.spec3 + 1.0) * (double) this.spec) / (double) this.spec2 * (Math.Cos(((double) num3 + 2.0) * 1.0) + 1.0) / 2.0 + 1.0);
          float num5 = (float) (Math.Sin(((double) num2 + (double) this.spec3 + 1.0) * (double) this.spec) / (double) this.spec2 * (Math.Sin(((double) num3 + (double) this.spec3) * 1.0) + 1.0) / 2.0 + 1.0);
          float num6 = (float) (Math.Sin(((double) num2 + (double) this.specA3 - 17.0) * (double) this.specA) / (double) this.specA2 * (-Math.Cos(((double) num3 + (double) this.spec3) * 1.0) + 1.0) / 3.0 + 1.0);
          float num7 = (float) (Math.Sin(((double) num2 + (double) this.specA3 - 1.0) * (double) this.specA) / (double) this.specA2 * (Math.Cos(((double) num3 + 0.0) * 1.0) + 1.0) / 3.0 + 1.0);
          float x = 0.0f;
          float y = 0.0f;
          float z = 0.0f;
          if (this.bodytype == "moon")
          {
            x = (float) (Math.Sin((double) num3) * (-Math.Cos((double) num2) * (double) this.radius)) * num4 * num5 * this.s1;
            y = (float) Math.Sin((double) num2) * this.radius * this.tall;
            z = (float) (-Math.Cos((double) num3) * (-Math.Cos((double) num2) * (double) this.radius)) * num6 * num7 * this.s1;
          }
          if (this.bodytype == "planet")
          {
            x = (float) Math.Sin((double) num3) * ((float) -Math.Cos((double) num2) * this.radius);
            y = (float) Math.Sin((double) num2) * this.radius;
            z = (float) (-Math.Cos((double) num3) * (-Math.Cos((double) num2) * (double) this.radius));
          }
          vertexGlobeArray[index1 + index2 * this.Tw].Position = new Vector3(x, y, z);
          vertexGlobeArray[index1 + index2 * this.Tw].TextureCoordinate.X = (float) index2 / (float) (this.Tw - 1);
          vertexGlobeArray[index1 + index2 * this.Tw].TextureCoordinate.Y = (float) index1 / (float) (this.Tw - 1);
          if (this.bodytype == "moon")
          {
            vertexGlobeArray[index1 + index2 * this.Tw].TexWeights.X = 0.0f;
            vertexGlobeArray[index1 + index2 * this.Tw].TexWeights.Y = this.blend1;
            vertexGlobeArray[index1 + index2 * this.Tw].TexWeights.Z = this.blend2;
            vertexGlobeArray[index1 + index2 * this.Tw].TexWeights.W = this.blend3;
          }
          if (this.bodytype == "planet")
          {
            vertexGlobeArray[index1 + index2 * this.Tw].TexWeights.X = 0.0f;
            vertexGlobeArray[index1 + index2 * this.Tw].TexWeights.Y = 0.0f;
            vertexGlobeArray[index1 + index2 * this.Tw].TexWeights.Z = 1f;
            vertexGlobeArray[index1 + index2 * this.Tw].TexWeights.W = 0.0f;
          }
          float num8 = vertexGlobeArray[index1 + index2 * this.Tw].TexWeights.X + vertexGlobeArray[index1 + index2 * this.Tw].TexWeights.Y + vertexGlobeArray[index1 + index2 * this.Tw].TexWeights.Z + vertexGlobeArray[index1 + index2 * this.Tw].TexWeights.W;
          vertexGlobeArray[index1 + index2 * this.Tw].TexWeights.X /= num8;
          vertexGlobeArray[index1 + index2 * this.Tw].TexWeights.Y /= num8;
          vertexGlobeArray[index1 + index2 * this.Tw].TexWeights.Z /= num8;
          vertexGlobeArray[index1 + index2 * this.Tw].TexWeights.W /= num8;
        }
      }
      return vertexGlobeArray;
    }

    public int[] SetUpTerrainIndices()
    {
      int[] numArray1 = new int[(this.Tw - 1) * (this.Tw - 1) * 6];
      int num1 = 0;
      for (int index1 = 0; index1 < this.Tw - 1; ++index1)
      {
        for (int index2 = 0; index2 < this.Tw - 1; ++index2)
        {
          int num2 = index1 + 1;
          int num3 = index2 + 1;
          int num4 = index1 + index2 * this.Tw;
          int num5 = num2 + index2 * this.Tw;
          int num6 = index1 + num3 * this.Tw;
          int num7 = num2 + num3 * this.Tw;
          int[] numArray2 = numArray1;
          int index3 = num1;
          int num8 = index3 + 1;
          int num9 = num6;
          numArray2[index3] = num9;
          int[] numArray3 = numArray1;
          int index4 = num8;
          int num10 = index4 + 1;
          int num11 = num5;
          numArray3[index4] = num11;
          int[] numArray4 = numArray1;
          int index5 = num10;
          int num12 = index5 + 1;
          int num13 = num4;
          numArray4[index5] = num13;
          int[] numArray5 = numArray1;
          int index6 = num12;
          int num14 = index6 + 1;
          int num15 = num6;
          numArray5[index6] = num15;
          int[] numArray6 = numArray1;
          int index7 = num14;
          int num16 = index7 + 1;
          int num17 = num7;
          numArray6[index7] = num17;
          int[] numArray7 = numArray1;
          int index8 = num16;
          num1 = index8 + 1;
          int num18 = num5;
          numArray7[index8] = num18;
        }
      }
      return numArray1;
    }

    public VertexGlobe[] CalculateNormals(VertexGlobe[] vertices, int[] indices)
    {
      for (int index = 0; index < vertices.Length; ++index)
        vertices[index].Normal = new Vector3(0.0f, 0.0f, 0.0f);
      for (int index1 = 0; index1 < indices.Length / 3; ++index1)
      {
        int index2 = indices[index1 * 3];
        int index3 = indices[index1 * 3 + 1];
        int index4 = indices[index1 * 3 + 2];
        Vector3 vector3 = Vector3.Cross(vertices[index2].Position - vertices[index4].Position, vertices[index2].Position - vertices[index3].Position);
        vertices[index2].Normal += vector3;
        vertices[index3].Normal += vector3;
        vertices[index4].Normal += vector3;
      }
      for (int index = 0; index < vertices.Length; ++index)
        vertices[index].Normal.Normalize();
      for (int index5 = 0; index5 < this.Tw; ++index5)
      {
        int index6 = index5;
        int index7 = this.Tw * this.Tw - this.Tw + index5;
        Vector3 vector3 = (vertices[index6].Normal + vertices[index7].Normal) / 2f;
        vertices[index6].Normal = vector3;
        vertices[index7].Normal = vector3;
      }
      return vertices;
    }

    public void CopyToTerrainBuffers(VertexGlobe[] vertices, int[] indices)
    {
      this.terrainVertexBuffer = new VertexBuffer(this.device, typeof (VertexGlobe), vertices.Length, BufferUsage.WriteOnly);
      this.terrainVertexBuffer.SetData<VertexGlobe>(vertices);
      this.terrainIndexBuffer = new IndexBuffer(this.device, typeof (int), indices.Length, BufferUsage.WriteOnly);
      this.terrainIndexBuffer.SetData<int>(indices);
    }
  }
}
