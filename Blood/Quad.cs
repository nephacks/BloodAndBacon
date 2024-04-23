// Decompiled with JetBrains decompiler
// Type: Blood.Quad
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#nullable disable
namespace Blood
{
  public class Quad
  {
    private VertexPositionNormalTexture[] _vertices;
    private int[] _indexes;
    private Vector3 _origin;
    private Vector3 _normal;
    private Vector3 _up;
    private Vector3 _left;
    private Vector3 _upperLeft;
    private Vector3 _upperRight;
    private Vector3 _lowerLeft;
    private Vector3 _lowerRight;

    public VertexPositionNormalTexture[] Vertices
    {
      get => this._vertices;
      set => this._vertices = value;
    }

    public int[] Indexes
    {
      get => this._indexes;
      set => this._indexes = value;
    }

    public Vector3 Origin
    {
      get => this._origin;
      set => this._origin = value;
    }

    public Vector3 Normal
    {
      get => this._normal;
      set => this._normal = value;
    }

    public Vector3 Up
    {
      get => this._up;
      set => this._up = value;
    }

    public Vector3 Left
    {
      get => this._left;
      set => this._left = value;
    }

    public Vector3 UpperLeft
    {
      get => this._upperLeft;
      set => this._upperLeft = value;
    }

    public Vector3 UpperRight
    {
      get => this._upperRight;
      set => this._upperRight = value;
    }

    public Vector3 LowerLeft
    {
      get => this._lowerLeft;
      set => this._lowerLeft = value;
    }

    public Vector3 LowerRight
    {
      get => this._lowerRight;
      set => this._lowerRight = value;
    }

    public Quad(Vector3 origin, Vector3 normal, Vector3 up, float width, float height)
    {
      this.Vertices = new VertexPositionNormalTexture[4];
      this.Indexes = new int[6];
      this.Origin = origin;
      this.Normal = normal;
      this.Up = up;
      this.Left = Vector3.Cross(normal, this.Up);
      Vector3 vector3 = this.Up * height / 2f + origin;
      this.UpperLeft = vector3 + this.Left * width / 2f;
      this.UpperRight = vector3 - this.Left * width / 2f;
      this.LowerLeft = this.UpperLeft - this.Up * height;
      this.LowerRight = this.UpperRight - this.Up * height;
      this.FillVertices();
    }

    private void FillVertices()
    {
      Vector2 vector2_1 = new Vector2(0.0f, 0.0f);
      Vector2 vector2_2 = new Vector2(1f, 0.0f);
      Vector2 vector2_3 = new Vector2(0.0f, 1f);
      Vector2 vector2_4 = new Vector2(1f, 1f);
      for (int index = 0; index < this.Vertices.Length; ++index)
        this.Vertices[index].Normal = this.Normal;
      this.Vertices[0].Position = this.LowerLeft;
      this.Vertices[0].TextureCoordinate = vector2_3;
      this.Vertices[1].Position = this.UpperLeft;
      this.Vertices[1].TextureCoordinate = vector2_1;
      this.Vertices[2].Position = this.LowerRight;
      this.Vertices[2].TextureCoordinate = vector2_4;
      this.Vertices[3].Position = this.UpperRight;
      this.Vertices[3].TextureCoordinate = vector2_2;
      this.Indexes[0] = 0;
      this.Indexes[1] = 1;
      this.Indexes[2] = 2;
      this.Indexes[3] = 2;
      this.Indexes[4] = 1;
      this.Indexes[5] = 3;
    }
  }
}
