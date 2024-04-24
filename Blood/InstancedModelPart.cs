using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

#nullable disable
namespace Blood
{
  internal class InstancedModelPart
  {
    private const int MaxShaderMatrices = 60;
    private const int SizeOfVector4 = 16;
    private const int SizeOfMatrix = 64;
    private int indexCount;
    private int vertexCount;
    private int vertexStride;
    public List<int> show = new List<int>();
    private VertexDeclaration vertexDeclaration;
    private VertexBuffer vertexBuffer;
    private IndexBuffer indexBuffer;
    private Effect effect;
    private GraphicsDevice graphicsDevice;
    private int maxInstances;
    private Matrix[] tempMatrices = new Matrix[60];
    private Matrix[] fortyMatrices = new Matrix[40];
    private int[] tempColors = new int[40];
    private ContentManager content;

    internal InstancedModelPart(ContentReader input, GraphicsDevice graphicsDevice)
    {
      this.graphicsDevice = graphicsDevice;
      this.indexCount = input.ReadInt32();
      this.vertexCount = input.ReadInt32();
      this.vertexStride = input.ReadInt32();
      this.vertexDeclaration = input.ReadObject<VertexDeclaration>();
      this.vertexBuffer = input.ReadObject<VertexBuffer>();
      this.indexBuffer = input.ReadObject<IndexBuffer>();
      input.ReadSharedResource<Effect>((Action<Effect>) (value => this.effect = value));
      this.content = new ContentManager(input.ContentManager.ServiceProvider, "Content");
      this.maxInstances = Math.Min((int) ushort.MaxValue / this.vertexCount, 60);
      this.ReplicateIndexData();
    }

    private void ReplicateIndexData()
    {
      ushort[] data1 = new ushort[this.indexCount];
      this.indexBuffer.GetData<ushort>(data1);
      this.indexBuffer.Dispose();
      ushort[] data2 = new ushort[this.indexCount * this.maxInstances];
      int index1 = 0;
      for (int index2 = 0; index2 < this.maxInstances; ++index2)
      {
        int num = index2 * this.vertexCount;
        for (int index3 = 0; index3 < this.indexCount; ++index3)
        {
          data2[index1] = (ushort) ((uint) data1[index3] + (uint) num);
          ++index1;
        }
      }
      this.indexBuffer = new IndexBuffer(this.graphicsDevice, typeof (VertexPositionColor), 2 * data2.Length, BufferUsage.None);
      this.indexBuffer.SetData<ushort>(data2);
    }

    public void DrawGems(
      ref Matrix[] instanceTransforms,
      Matrix view,
      Matrix projection,
      Vector3 light,
      Vector3 amb,
      Vector3 diffu,
      Vector3 vpos)
    {
    }

    private void DrawShader60gems(ref Matrix[] iTT)
    {
    }

    public void breakage(
      ref Matrix[] instanceTransforms,
      Matrix view,
      Matrix projection,
      Vector3 light,
      Vector3 amb,
      Vector3 diffu,
      int count)
    {
    }

    public void boulders(
      ref Matrix[] instanceTransforms,
      Matrix view,
      Matrix projection,
      Vector3 light,
      Vector3 amb,
      Vector3 diffu,
      int count)
    {
      this.graphicsDevice.Indices = this.indexBuffer;
      this.effect.CurrentTechnique = this.effect.Techniques[nameof (boulders)];
      this.effect.Parameters["View"].SetValue(view);
      this.effect.Parameters["Projection"].SetValue(projection);
      this.effect.Parameters["VertexCount"].SetValue(this.vertexCount);
      this.effect.Parameters["LightDirection"].SetValue(light);
      this.effect.Parameters["DiffuseLight"].SetValue(diffu);
      this.effect.Parameters["AmbientLight"].SetValue(amb);
      this.DrawShaderRocks(ref instanceTransforms, count);
    }

    private void DrawShaderRocks(ref Matrix[] iTT, int count)
    {
      for (int sourceIndex = 0; sourceIndex < count; sourceIndex += this.maxInstances)
      {
        int length = count - sourceIndex;
        if (length > this.maxInstances)
          length = this.maxInstances;
        Array.Copy((Array) iTT, sourceIndex, (Array) this.tempMatrices, 0, length);
        this.effect.Parameters["InstanceTransforms"].SetValue(this.tempMatrices);
        this.graphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, length * this.vertexCount, 0, length * this.indexCount / 3);
      }
    }

    public void smallGems(
      ref Matrix[] instanceTransforms,
      Matrix view,
      Matrix projection,
      Vector3 light,
      Vector3 amb,
      Vector3 diffu)
    {
    }

    private void DrawShaderGems(ref Matrix[] iTT)
    {
    }

    public void chain(
      ref Matrix[] instanceTransforms,
      Matrix view,
      Matrix projection,
      Vector3 light,
      Vector3 amb,
      Vector3 diffu,
      int start)
    {
    }

    private void DrawChain(ref Matrix[] iTT, int start)
    {
    }
  }
}
