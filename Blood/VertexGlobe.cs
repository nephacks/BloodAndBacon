// Decompiled with JetBrains decompiler
// Type: Blood.VertexGlobe
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#nullable disable
namespace Blood
{
  public struct VertexGlobe : IVertexType
  {
    public Vector3 Position;
    public Vector3 Normal;
    public Vector4 TextureCoordinate;
    public Vector4 TexWeights;
    public static int SizeInBytes = 56;
    private static readonly VertexDeclaration myVertexDeclaration = new VertexDeclaration(new VertexElement[4]
    {
      new VertexElement(0, VertexElementFormat.Vector3, VertexElementUsage.Position, 0),
      new VertexElement(12, VertexElementFormat.Vector3, VertexElementUsage.Normal, 0),
      new VertexElement(24, VertexElementFormat.Vector4, VertexElementUsage.TextureCoordinate, 0),
      new VertexElement(40, VertexElementFormat.Vector4, VertexElementUsage.TextureCoordinate, 1)
    });

    public VertexDeclaration VertexDeclaration => VertexGlobe.myVertexDeclaration;
  }
}
