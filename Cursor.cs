// Decompiled with JetBrains decompiler
// Type: Blood.Cursor
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

#nullable disable
namespace Blood
{
  public class Cursor
  {
    private const float CursorSpeed = 250f;
    private GraphicsDevice gr;
    public bool ignorebounds;
    public Vector2 Position;
    public Vector3 rayPos = Vector3.Zero;
    public Vector3 rayDir = Vector3.Zero;
    public bool isTunnel;
    public bool isDoor;
    public bool isDoor1;
    public bool isDoor2;
    public bool isDoor3;
    public bool isCrypt;
    public bool isCrypt2;
    public float closestIntersection = float.MaxValue;
    public Vector3[] pickedTriangle;
    private Matrix inverseTransform;
    private Dictionary<string, object> tagData;
    private Dictionary<string, object> tagData2;
    private Dictionary<string, object> tagDataDoor;
    private Dictionary<string, object> tagDataTunnel;
    private Dictionary<string, object> tagDataDoor1;
    private Dictionary<string, object> tagDataDoor2;
    private Dictionary<string, object> tagDataDoor3;
    private Dictionary<string, object> tagDataDoorH;
    private BoundingSphere boundingSphere;
    public Vector3[] vertices;
    public Vector3[] vertices1;
    public Vector3[] vertices2;
    public Vector3[] doorVertices;
    public Vector3[] tunnelvertices3;
    public Vector3[] door1Vertices;
    public Vector3[] cryptVertices;
    public Vector3[] cryptVertices2;
    public Vector3[] door2Vertices;
    private int vertLength;
    private int maxLength;
    private int minLength;
    private float intersection;
    private static Vector3 edge1;
    private static Vector3 edge2;
    private static float determinant;
    private static float inverseDeterminant;
    private static Vector3 distanceVector;
    private static float triangleU;
    private static Vector3 distanceCrossEdge1;
    private static float triangleV;
    private static float rayDistance;
    private Vector3 v1;
    private Vector3 v2;
    private Vector3 v3;
    private Vector3 nearSource;
    private Vector3 farSource;
    private Vector3 nearPoint;
    private Vector3 farPoint;
    private Vector3 direction;
    private Ray ray;
    private int i;
    private BoundingBox myBox;
    private BoundingSphere myTarget;

    public void LoadContent(
      ContentManager content,
      GraphicsDevice device,
      ref Model model1,
      ref Model doorModel,
      ref Model model2)
    {
      this.gr = device;
      this.Position = new Vector2((float) this.gr.Viewport.Width, (float) this.gr.Viewport.Height) / 2f;
      this.pickedTriangle = new Vector3[3];
      this.pickedTriangle[0] = Vector3.Zero;
      this.pickedTriangle[1] = Vector3.Zero;
      this.pickedTriangle[2] = Vector3.Zero;
      this.tagDataDoor = (Dictionary<string, object>) doorModel.Tag;
      this.doorVertices = (Vector3[]) this.tagDataDoor["Vertices"];
      this.tagData = (Dictionary<string, object>) model1.Tag;
      this.boundingSphere = (BoundingSphere) this.tagData["BoundingSphere"];
      this.vertices = (Vector3[]) this.tagData["Vertices"];
      this.tagData2 = (Dictionary<string, object>) model2.Tag;
      this.vertices1 = (Vector3[]) this.tagData["Vertices"];
      this.vertices2 = (Vector3[]) this.tagData2["Vertices"];
      this.minLength = this.vertices1.Length;
      this.maxLength = this.vertices1.Length + this.vertices2.Length;
      Array.Resize<Vector3>(ref this.vertices, this.vertices1.Length + this.vertices2.Length);
      for (int index = 0; index < this.vertices1.Length; ++index)
        this.vertices[index] = this.vertices1[index];
      for (int index = 0; index < this.vertices2.Length; ++index)
        this.vertices[index + this.vertices1.Length] = this.vertices2[index];
      this.myBox = new BoundingBox(Vector3.Zero, Vector3.Up);
      this.myTarget = new BoundingSphere(Vector3.Zero, 5f);
    }

    public void addTriangles() => this.vertLength = this.maxLength;

    public void delTriangles() => this.vertLength = this.minLength;

    public void addTunnel(Model tunnel, ref Model door1, ref Model crypt)
    {
      this.tagDataTunnel = (Dictionary<string, object>) tunnel.Tag;
      this.tunnelvertices3 = (Vector3[]) this.tagDataTunnel["Vertices"];
      this.minLength = this.vertices1.Length + this.tunnelvertices3.Length;
      this.maxLength = this.vertices1.Length + this.tunnelvertices3.Length + this.vertices2.Length;
      this.vertLength = this.maxLength;
      Array.Resize<Vector3>(ref this.vertices, this.vertices1.Length + this.vertices2.Length + this.tunnelvertices3.Length);
      for (int index = 0; index < this.vertices1.Length; ++index)
        this.vertices[index] = this.vertices1[index];
      for (int index = 0; index < this.tunnelvertices3.Length; ++index)
        this.vertices[index + this.vertices1.Length] = this.tunnelvertices3[index];
      for (int index = 0; index < this.vertices2.Length; ++index)
        this.vertices[index + this.vertices1.Length + this.tunnelvertices3.Length] = this.vertices2[index];
      this.tagDataDoor1 = (Dictionary<string, object>) door1.Tag;
      this.door1Vertices = (Vector3[]) this.tagDataDoor1["Vertices"];
      this.tagDataDoor2 = (Dictionary<string, object>) crypt.Tag;
      this.cryptVertices = (Vector3[]) this.tagDataDoor2["Vertices"];
    }

    public void addTunnel2(
      Model tunnel,
      ref Model door1,
      ref Model door2,
      ref Model crypt,
      ref Model crypt2)
    {
      this.tagDataTunnel = (Dictionary<string, object>) tunnel.Tag;
      this.tunnelvertices3 = (Vector3[]) this.tagDataTunnel["Vertices"];
      this.tagDataDoor1 = (Dictionary<string, object>) door1.Tag;
      this.door1Vertices = (Vector3[]) this.tagDataDoor1["Vertices"];
      this.tagDataDoorH = (Dictionary<string, object>) door2.Tag;
      this.door2Vertices = (Vector3[]) this.tagDataDoorH["Vertices"];
      this.tagDataDoor2 = (Dictionary<string, object>) crypt.Tag;
      this.cryptVertices = (Vector3[]) this.tagDataDoor2["Vertices"];
      this.tagDataDoor3 = (Dictionary<string, object>) crypt2.Tag;
      this.cryptVertices2 = (Vector3[]) this.tagDataDoor3["Vertices"];
    }

    public float? hitBox(Vector3 nearPoint, Vector3 farPoint, Vector3 min, Vector3 max)
    {
      this.direction = farPoint - nearPoint;
      this.direction.Normalize();
      this.ray.Position = nearPoint;
      this.ray.Direction = this.direction;
      this.myBox.Min = min;
      this.myBox.Max = max;
      return this.myBox.Intersects(this.ray);
    }

    public float? hitSphere(Vector3 nearPoint, Vector3 farPoint, Vector3 cent, float radius)
    {
      this.direction = farPoint - nearPoint;
      this.direction.Normalize();
      this.ray.Position = nearPoint;
      this.ray.Direction = this.direction;
      this.myTarget.Center = cent;
      this.myTarget.Radius = radius;
      return this.myTarget.Intersects(this.ray);
    }

    public float? hitSphere2(Vector3 nearPoint, Vector3 farPoint, Vector3 cent, float radius)
    {
      this.direction = farPoint - nearPoint;
      this.direction.Normalize();
      this.ray.Position = nearPoint;
      this.ray.Direction = this.direction;
      this.rayDir = this.ray.Direction;
      this.rayPos = this.ray.Position;
      this.myTarget.Center = cent;
      this.myTarget.Radius = radius;
      return this.myTarget.Intersects(this.ray);
    }

    public Ray CalculateCursorRay(Matrix projectionMatrix, Matrix viewMatrix)
    {
      this.nearSource = new Vector3(this.Position, 0.0f);
      this.farSource = new Vector3(this.Position, 1f);
      this.nearPoint = this.gr.Viewport.Unproject(this.nearSource, projectionMatrix, viewMatrix, Matrix.Identity);
      this.farPoint = this.gr.Viewport.Unproject(this.farSource, projectionMatrix, viewMatrix, Matrix.Identity);
      this.direction = this.farPoint - this.nearPoint;
      this.direction.Normalize();
      this.ray.Direction = this.direction;
      this.ray.Position = this.nearPoint;
      return this.ray;
    }

    public void RayIntersectsModel3(Ray ray, Matrix modelTransform, Matrix doorTransform)
    {
      Matrix matrix = modelTransform;
      this.inverseTransform = Matrix.Invert(modelTransform);
      ray.Position = Vector3.Transform(ray.Position, this.inverseTransform);
      ray.Direction = Vector3.TransformNormal(ray.Direction, this.inverseTransform);
      this.isDoor = false;
      if (!this.boundingSphere.Intersects(ray).HasValue)
      {
        this.closestIntersection = 10000f;
      }
      else
      {
        this.closestIntersection = 10000f;
        for (this.i = 0; this.i < this.vertLength; this.i += 3)
        {
          this.intersection = 10000f;
          Cursor.RayIntersectsTriangle(ref ray, ref this.vertices[this.i], ref this.vertices[this.i + 1], ref this.vertices[this.i + 2], out this.intersection);
          if ((double) this.intersection != 10000.0 && ((double) this.closestIntersection == 10000.0 || (double) this.intersection < (double) this.closestIntersection))
          {
            this.closestIntersection = this.intersection;
            Vector3.Transform(ref this.vertices[this.i], ref modelTransform, out this.pickedTriangle[0]);
            Vector3.Transform(ref this.vertices[this.i + 1], ref modelTransform, out this.pickedTriangle[1]);
            Vector3.Transform(ref this.vertices[this.i + 2], ref modelTransform, out this.pickedTriangle[2]);
          }
        }
        this.inverseTransform = Matrix.Invert(doorTransform);
        ray.Position = Vector3.Transform(ray.Position, this.inverseTransform);
        ray.Direction = Vector3.TransformNormal(ray.Direction, this.inverseTransform);
        modelTransform = matrix;
        modelTransform *= doorTransform;
        for (this.i = 0; this.i < this.doorVertices.Length; this.i += 3)
        {
          Cursor.RayIntersectsTriangle(ref ray, ref this.doorVertices[this.i], ref this.doorVertices[this.i + 1], ref this.doorVertices[this.i + 2], out this.intersection);
          if ((double) this.intersection < (double) this.closestIntersection)
          {
            this.closestIntersection = this.intersection;
            Vector3.Transform(ref this.doorVertices[this.i], ref modelTransform, out this.pickedTriangle[0]);
            Vector3.Transform(ref this.doorVertices[this.i + 1], ref modelTransform, out this.pickedTriangle[1]);
            Vector3.Transform(ref this.doorVertices[this.i + 2], ref modelTransform, out this.pickedTriangle[2]);
            this.isDoor = true;
          }
        }
      }
    }

    public void RayInteresectGeneric(
      Ray ray,
      Matrix myTransform,
      ref Vector3[] verts,
      ref bool mybool)
    {
      this.inverseTransform = Matrix.Invert(myTransform);
      ray.Position = Vector3.Transform(this.rayPos, this.inverseTransform);
      ray.Direction = Vector3.TransformNormal(this.rayDir, this.inverseTransform);
      if (this.boundingSphere.Intersects(ray).HasValue || this.ignorebounds)
      {
        Matrix matrix = myTransform;
        for (this.i = 0; this.i < verts.Length; this.i += 3)
        {
          Cursor.RayIntersectsTriangle(ref ray, ref verts[this.i], ref verts[this.i + 1], ref verts[this.i + 2], out this.intersection);
          if ((double) this.intersection < (double) this.closestIntersection)
          {
            this.closestIntersection = this.intersection;
            Vector3.Transform(ref verts[this.i], ref matrix, out this.pickedTriangle[0]);
            Vector3.Transform(ref verts[this.i + 1], ref matrix, out this.pickedTriangle[1]);
            Vector3.Transform(ref verts[this.i + 2], ref matrix, out this.pickedTriangle[2]);
            mybool = true;
          }
        }
      }
      this.ignorebounds = false;
    }

    public void RayIntersectsModel2(
      Ray ray,
      Matrix modelTransform,
      Matrix doorTransform,
      Matrix doorTransform1,
      Matrix doorTransform2,
      Matrix doorTransform3,
      Matrix cryptTransform)
    {
      this.rayDir = this.rayPos = this.pickedTriangle[0] = this.pickedTriangle[1] = this.pickedTriangle[2] = Vector3.Zero;
      this.rayDir = ray.Direction;
      this.rayPos = ray.Position;
      Matrix matrix = modelTransform;
      this.inverseTransform = Matrix.Invert(modelTransform);
      ray.Position = Vector3.Transform(ray.Position, this.inverseTransform);
      ray.Direction = Vector3.TransformNormal(ray.Direction, this.inverseTransform);
      this.isDoor = false;
      this.isDoor1 = false;
      this.isDoor2 = false;
      this.isDoor3 = false;
      this.isCrypt = false;
      if (!this.boundingSphere.Intersects(ray).HasValue)
      {
        this.closestIntersection = 10000f;
      }
      else
      {
        this.closestIntersection = 10000f;
        for (this.i = 0; this.i < this.vertLength; this.i += 3)
        {
          this.intersection = 10000f;
          Cursor.RayIntersectsTriangle(ref ray, ref this.vertices[this.i], ref this.vertices[this.i + 1], ref this.vertices[this.i + 2], out this.intersection);
          if ((double) this.intersection != 10000.0 && ((double) this.closestIntersection == 10000.0 || (double) this.intersection < (double) this.closestIntersection))
          {
            this.closestIntersection = this.intersection;
            Vector3.Transform(ref this.vertices[this.i], ref modelTransform, out this.pickedTriangle[0]);
            Vector3.Transform(ref this.vertices[this.i + 1], ref modelTransform, out this.pickedTriangle[1]);
            Vector3.Transform(ref this.vertices[this.i + 2], ref modelTransform, out this.pickedTriangle[2]);
          }
        }
        this.inverseTransform = Matrix.Invert(doorTransform);
        ray.Position = Vector3.Transform(ray.Position, this.inverseTransform);
        ray.Direction = Vector3.TransformNormal(ray.Direction, this.inverseTransform);
        modelTransform = matrix;
        modelTransform *= doorTransform;
        for (this.i = 0; this.i < this.doorVertices.Length; this.i += 3)
        {
          Cursor.RayIntersectsTriangle(ref ray, ref this.doorVertices[this.i], ref this.doorVertices[this.i + 1], ref this.doorVertices[this.i + 2], out this.intersection);
          if ((double) this.intersection < (double) this.closestIntersection)
          {
            this.closestIntersection = this.intersection;
            Vector3.Transform(ref this.doorVertices[this.i], ref modelTransform, out this.pickedTriangle[0]);
            Vector3.Transform(ref this.doorVertices[this.i + 1], ref modelTransform, out this.pickedTriangle[1]);
            Vector3.Transform(ref this.doorVertices[this.i + 2], ref modelTransform, out this.pickedTriangle[2]);
            this.isDoor = true;
          }
        }
        this.inverseTransform = Matrix.Invert(doorTransform1);
        ray.Position = Vector3.Transform(this.rayPos, this.inverseTransform);
        ray.Direction = Vector3.TransformNormal(this.rayDir, this.inverseTransform);
        modelTransform = doorTransform1;
        for (this.i = 0; this.i < this.door1Vertices.Length; this.i += 3)
        {
          Cursor.RayIntersectsTriangle(ref ray, ref this.door1Vertices[this.i], ref this.door1Vertices[this.i + 1], ref this.door1Vertices[this.i + 2], out this.intersection);
          if ((double) this.intersection < (double) this.closestIntersection)
          {
            this.closestIntersection = this.intersection;
            Vector3.Transform(ref this.door1Vertices[this.i], ref modelTransform, out this.pickedTriangle[0]);
            Vector3.Transform(ref this.door1Vertices[this.i + 1], ref modelTransform, out this.pickedTriangle[1]);
            Vector3.Transform(ref this.door1Vertices[this.i + 2], ref modelTransform, out this.pickedTriangle[2]);
            this.isDoor1 = true;
          }
        }
        this.inverseTransform = Matrix.Invert(doorTransform2);
        ray.Position = Vector3.Transform(this.rayPos, this.inverseTransform);
        ray.Direction = Vector3.TransformNormal(this.rayDir, this.inverseTransform);
        modelTransform = doorTransform2;
        for (this.i = 0; this.i < this.door1Vertices.Length; this.i += 3)
        {
          Cursor.RayIntersectsTriangle(ref ray, ref this.door1Vertices[this.i], ref this.door1Vertices[this.i + 1], ref this.door1Vertices[this.i + 2], out this.intersection);
          if ((double) this.intersection < (double) this.closestIntersection)
          {
            this.closestIntersection = this.intersection;
            Vector3.Transform(ref this.door1Vertices[this.i], ref modelTransform, out this.pickedTriangle[0]);
            Vector3.Transform(ref this.door1Vertices[this.i + 1], ref modelTransform, out this.pickedTriangle[1]);
            Vector3.Transform(ref this.door1Vertices[this.i + 2], ref modelTransform, out this.pickedTriangle[2]);
            this.isDoor2 = true;
          }
        }
        this.inverseTransform = Matrix.Invert(doorTransform3);
        ray.Position = Vector3.Transform(this.rayPos, this.inverseTransform);
        ray.Direction = Vector3.TransformNormal(this.rayDir, this.inverseTransform);
        modelTransform = doorTransform3;
        for (this.i = 0; this.i < this.door1Vertices.Length; this.i += 3)
        {
          Cursor.RayIntersectsTriangle(ref ray, ref this.door1Vertices[this.i], ref this.door1Vertices[this.i + 1], ref this.door1Vertices[this.i + 2], out this.intersection);
          if ((double) this.intersection < (double) this.closestIntersection)
          {
            this.closestIntersection = this.intersection;
            Vector3.Transform(ref this.door1Vertices[this.i], ref modelTransform, out this.pickedTriangle[0]);
            Vector3.Transform(ref this.door1Vertices[this.i + 1], ref modelTransform, out this.pickedTriangle[1]);
            Vector3.Transform(ref this.door1Vertices[this.i + 2], ref modelTransform, out this.pickedTriangle[2]);
            this.isDoor3 = true;
          }
        }
        this.inverseTransform = Matrix.Invert(cryptTransform);
        ray.Position = Vector3.Transform(this.rayPos, this.inverseTransform);
        ray.Direction = Vector3.TransformNormal(this.rayDir, this.inverseTransform);
        modelTransform = cryptTransform;
        for (this.i = 0; this.i < this.cryptVertices.Length; this.i += 3)
        {
          Cursor.RayIntersectsTriangle(ref ray, ref this.cryptVertices[this.i], ref this.cryptVertices[this.i + 1], ref this.cryptVertices[this.i + 2], out this.intersection);
          if ((double) this.intersection < (double) this.closestIntersection)
          {
            this.closestIntersection = this.intersection;
            Vector3.Transform(ref this.cryptVertices[this.i], ref modelTransform, out this.pickedTriangle[0]);
            Vector3.Transform(ref this.cryptVertices[this.i + 1], ref modelTransform, out this.pickedTriangle[1]);
            Vector3.Transform(ref this.cryptVertices[this.i + 2], ref modelTransform, out this.pickedTriangle[2]);
            this.isCrypt = true;
          }
        }
      }
    }

    public void RayIntersectsModel(
      Ray ray,
      Matrix modelTransform,
      Matrix doorTransform,
      bool checkDoor)
    {
      this.rayDir = this.rayPos = this.pickedTriangle[0] = this.pickedTriangle[1] = this.pickedTriangle[2] = Vector3.Zero;
      this.rayDir = ray.Direction;
      this.rayPos = ray.Position;
      this.inverseTransform = Matrix.Invert(modelTransform);
      ray.Position = Vector3.Transform(ray.Position, this.inverseTransform);
      ray.Direction = Vector3.TransformNormal(ray.Direction, this.inverseTransform);
      this.isDoor = false;
      this.isDoor1 = false;
      this.isDoor2 = false;
      this.isDoor3 = false;
      this.isCrypt = false;
      if (!this.boundingSphere.Intersects(ray).HasValue)
      {
        this.closestIntersection = 10000f;
      }
      else
      {
        this.closestIntersection = 10000f;
        for (this.i = 0; this.i < this.vertLength; this.i += 3)
        {
          this.intersection = 10000f;
          Cursor.RayIntersectsTriangle(ref ray, ref this.vertices[this.i], ref this.vertices[this.i + 1], ref this.vertices[this.i + 2], out this.intersection);
          if ((double) this.intersection != 10000.0 && ((double) this.closestIntersection == 10000.0 || (double) this.intersection < (double) this.closestIntersection))
          {
            this.closestIntersection = this.intersection;
            Vector3.Transform(ref this.vertices[this.i], ref modelTransform, out this.pickedTriangle[0]);
            Vector3.Transform(ref this.vertices[this.i + 1], ref modelTransform, out this.pickedTriangle[1]);
            Vector3.Transform(ref this.vertices[this.i + 2], ref modelTransform, out this.pickedTriangle[2]);
          }
        }
        if (!checkDoor)
          return;
        this.inverseTransform = Matrix.Invert(doorTransform);
        ray.Position = Vector3.Transform(ray.Position, this.inverseTransform);
        ray.Direction = Vector3.TransformNormal(ray.Direction, this.inverseTransform);
        modelTransform *= doorTransform;
        for (this.i = 0; this.i < this.doorVertices.Length; this.i += 3)
        {
          Cursor.RayIntersectsTriangle(ref ray, ref this.doorVertices[this.i], ref this.doorVertices[this.i + 1], ref this.doorVertices[this.i + 2], out this.intersection);
          if ((double) this.intersection < (double) this.closestIntersection)
          {
            this.closestIntersection = this.intersection;
            Vector3.Transform(ref this.doorVertices[this.i], ref modelTransform, out this.pickedTriangle[0]);
            Vector3.Transform(ref this.doorVertices[this.i + 1], ref modelTransform, out this.pickedTriangle[1]);
            Vector3.Transform(ref this.doorVertices[this.i + 2], ref modelTransform, out this.pickedTriangle[2]);
            this.isDoor = true;
          }
        }
      }
    }

    private static void RayIntersectsTriangle(
      ref Ray ray,
      ref Vector3 vertex1,
      ref Vector3 vertex2,
      ref Vector3 vertex3,
      out float result)
    {
      Vector3.Subtract(ref vertex2, ref vertex1, out Cursor.edge1);
      Vector3.Subtract(ref vertex3, ref vertex1, out Cursor.edge2);
      Vector3 result1;
      Vector3.Cross(ref ray.Direction, ref Cursor.edge2, out result1);
      Vector3.Dot(ref Cursor.edge1, ref result1, out Cursor.determinant);
      if ((double) Cursor.determinant > -1.4012984643248171E-45 && (double) Cursor.determinant < 1.4012984643248171E-45)
      {
        result = 10000f;
      }
      else
      {
        Cursor.inverseDeterminant = 1f / Cursor.determinant;
        Vector3.Subtract(ref ray.Position, ref vertex1, out Cursor.distanceVector);
        Vector3.Dot(ref Cursor.distanceVector, ref result1, out Cursor.triangleU);
        Cursor.triangleU *= Cursor.inverseDeterminant;
        if ((double) Cursor.triangleU >= 0.0 && (double) Cursor.triangleU <= 1.0)
        {
          Vector3.Cross(ref Cursor.distanceVector, ref Cursor.edge1, out Cursor.distanceCrossEdge1);
          Vector3.Dot(ref ray.Direction, ref Cursor.distanceCrossEdge1, out Cursor.triangleV);
          Cursor.triangleV *= Cursor.inverseDeterminant;
          if ((double) Cursor.triangleV >= 0.0 && (double) Cursor.triangleU + (double) Cursor.triangleV <= 1.0)
          {
            Vector3.Dot(ref Cursor.edge2, ref Cursor.distanceCrossEdge1, out Cursor.rayDistance);
            Cursor.rayDistance *= Cursor.inverseDeterminant;
            if ((double) Cursor.rayDistance < 0.0)
              result = 10000f;
            else
              result = Cursor.rayDistance;
          }
          else
            result = 10000f;
        }
        else
          result = 10000f;
      }
    }

    public void findAdjacent(
      bool isDoor,
      Matrix modelTransform,
      Matrix doorTransform,
      Vector3 a,
      Vector3 b,
      Vector3 c,
      out Vector3 found)
    {
      found = Vector3.Zero;
      if (isDoor)
      {
        for (int index = 0; index < this.doorVertices.Length; index += 3)
        {
          this.v1 = Vector3.Transform(this.doorVertices[index], modelTransform * doorTransform);
          this.v2 = Vector3.Transform(this.doorVertices[index + 1], modelTransform * doorTransform);
          this.v3 = Vector3.Transform(this.doorVertices[index + 2], modelTransform * doorTransform);
          if ((!(a != this.v1) || !(a != this.v2) || !(a != this.v3)) && (!(b != this.v1) || !(b != this.v2) || !(b != this.v3)) && !(c == this.v1) && !(c == this.v2) && !(c == this.v3))
          {
            if (!(a == this.v2) || !(b == this.v3))
            {
              if (!(b == this.v2) || !(a == this.v3))
              {
                if (!(a == this.v1) || !(b == this.v3))
                {
                  if (!(b == this.v1) || !(a == this.v3))
                  {
                    if (!(a == this.v1) || !(b == this.v2))
                    {
                      if (b == this.v1 && a == this.v2)
                      {
                        found = this.v3;
                        break;
                      }
                    }
                    else
                    {
                      found = this.v3;
                      break;
                    }
                  }
                  else
                  {
                    found = this.v2;
                    break;
                  }
                }
                else
                {
                  found = this.v2;
                  break;
                }
              }
              else
              {
                found = this.v1;
                break;
              }
            }
            else
            {
              found = this.v1;
              break;
            }
          }
        }
      }
      else
      {
        for (int index = 0; index < this.vertLength; index += 3)
        {
          this.v1 = Vector3.Transform(this.vertices[index], modelTransform);
          this.v2 = Vector3.Transform(this.vertices[index + 1], modelTransform);
          this.v3 = Vector3.Transform(this.vertices[index + 2], modelTransform);
          if ((!(a != this.v1) || !(a != this.v2) || !(a != this.v3)) && (!(b != this.v1) || !(b != this.v2) || !(b != this.v3)) && !(c == this.v1) && !(c == this.v2) && !(c == this.v3))
          {
            if (!(a == this.v2) || !(b == this.v3))
            {
              if (!(b == this.v2) || !(a == this.v3))
              {
                if (!(a == this.v1) || !(b == this.v3))
                {
                  if (!(b == this.v1) || !(a == this.v3))
                  {
                    if (!(a == this.v1) || !(b == this.v2))
                    {
                      if (b == this.v1 && a == this.v2)
                      {
                        found = this.v3;
                        break;
                      }
                    }
                    else
                    {
                      found = this.v3;
                      break;
                    }
                  }
                  else
                  {
                    found = this.v2;
                    break;
                  }
                }
                else
                {
                  found = this.v2;
                  break;
                }
              }
              else
              {
                found = this.v1;
                break;
              }
            }
            else
            {
              found = this.v1;
              break;
            }
          }
        }
      }
    }

    public void findAdjacentGen(
      ref Vector3[] vertices,
      Matrix modelTransform,
      Vector3 a,
      Vector3 b,
      Vector3 c,
      out Vector3 found)
    {
      found = Vector3.Zero;
      for (int index = 0; index < vertices.Length; index += 3)
      {
        this.v1 = Vector3.Transform(vertices[index], modelTransform);
        this.v2 = Vector3.Transform(vertices[index + 1], modelTransform);
        this.v3 = Vector3.Transform(vertices[index + 2], modelTransform);
        if ((!(a != this.v1) || !(a != this.v2) || !(a != this.v3)) && (!(b != this.v1) || !(b != this.v2) || !(b != this.v3)) && !(c == this.v1) && !(c == this.v2) && !(c == this.v3))
        {
          if (!(a == this.v2) || !(b == this.v3))
          {
            if (!(b == this.v2) || !(a == this.v3))
            {
              if (!(a == this.v1) || !(b == this.v3))
              {
                if (!(b == this.v1) || !(a == this.v3))
                {
                  if (!(a == this.v1) || !(b == this.v2))
                  {
                    if (b == this.v1 && a == this.v2)
                    {
                      found = this.v3;
                      break;
                    }
                  }
                  else
                  {
                    found = this.v3;
                    break;
                  }
                }
                else
                {
                  found = this.v2;
                  break;
                }
              }
              else
              {
                found = this.v2;
                break;
              }
            }
            else
            {
              found = this.v1;
              break;
            }
          }
          else
          {
            found = this.v1;
            break;
          }
        }
      }
    }
  }
}
