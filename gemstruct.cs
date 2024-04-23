// Decompiled with JetBrains decompiler
// Type: Blood.gemstruct
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
  internal class gemstruct : GameScreen
  {
    public gemstruct.gemtype gtype;
    public static int totalGems = 0;
    public static Matrix setitRight = Matrix.Identity;
    public static Matrix setVacuum = Matrix.Identity;
    public static Matrix inDumper = Matrix.Identity;
    private Vector3[] origDumper1 = new Vector3[4]
    {
      new Vector3(-0.555f, 1.421f, 57f / 1000f),
      new Vector3(0.529f, 1.421f, 57f / 1000f),
      new Vector3(0.673f, 1.446f, 1.894f),
      new Vector3(-0.699f, 1.446f, 1.894f)
    };
    private Vector3[] origRegion1 = new Vector3[5]
    {
      new Vector3(-0.536f, 0.05f, -2.2f),
      new Vector3(0.543f, 0.05f, -2.2f),
      new Vector3(0.498f, 0.0f, -0.007f),
      new Vector3(-0.525f, 0.0f, -0.007f),
      new Vector3(-0.536f, 0.388f, -1.937f)
    };
    private Vector3 pipeShot = new Vector3(-0.31384f, 2.13954f, -0.19438f);
    public Model model;
    public List<gemDupe> Inst = new List<gemDupe>();
    public int max = 300;
    public int maxgemx = 200;
    public gemDupe[] xInst;
    public int xTrack;
    private int bitmap = 290;
    private int grid = 150;
    private readonly VertexBufferBinding[] _vertexBufferBindings = new VertexBufferBinding[2];
    private DynamicVertexBuffer shaleBuffer;
    private DynamicVertexBuffer shale1Buffer;
    private static VertexDeclaration vd = new VertexDeclaration(new VertexElement[5]
    {
      new VertexElement(0, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 0),
      new VertexElement(16, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 1),
      new VertexElement(32, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 2),
      new VertexElement(48, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 3),
      new VertexElement(64, VertexElementFormat.Single, VertexElementUsage.Fog, 0)
    });
    public int xCount;
    public gemstruct.transcolor[] Trans;
    public gemstruct.transcolor[] xTrans;
    private ScreenManager sc;
    private GraphicsDevice gr;
    private Random rr;
    private SoundEffect crunch;
    private ContentManager content;

    public void LoadContent(ContentManager content, ScreenManager sc)
    {
      this.crunch = content.Load<SoundEffect>("astro\\Audio\\crunch");
      this.sc = sc;
      this.gr = sc.GraphicsDevice;
      this.rr = new Random();
      this.max = 300;
      this.Trans = new gemstruct.transcolor[this.max];
      this.xTrans = new gemstruct.transcolor[300];
      this.xInst = new gemDupe[300];
      this.shaleBuffer = new DynamicVertexBuffer(this.gr, gemstruct.vd, 3600, BufferUsage.WriteOnly);
      this.shale1Buffer = new DynamicVertexBuffer(this.gr, gemstruct.vd, 200, BufferUsage.WriteOnly);
      for (int index = 0; index < this.Trans.Length; ++index)
      {
        Matrix fromYawPitchRoll = Matrix.CreateFromYawPitchRoll((float) this.rr.Next(0, 880000) / 900f, (float) this.rr.Next(0, 880000) / 900f, (float) this.rr.Next(0, 880000) / 900f);
        float scale = (float) this.rr.Next(10000, 36000) / 10000f;
        Vector3 position = new Vector3(0.0f, 0.0f, 0.0f);
        this.Trans[index].Trans = Matrix.CreateScale(scale) * fromYawPitchRoll * Matrix.CreateTranslation(position);
      }
      int index1 = 0;
      this.pipeShot = Vector3.Transform(this.pipeShot, Matrix.CreateScale(1.5f));
      Vector3[] origDumper1 = this.origDumper1;
      for (int index2 = 0; index2 < origDumper1.Length; ++index2)
      {
        this.origDumper1[index1] = Vector3.Transform(this.origDumper1[index1], Matrix.CreateScale(1.5f));
        ++index1;
      }
      int index3 = 0;
      Vector3[] origRegion1 = this.origRegion1;
      for (int index4 = 0; index4 < origRegion1.Length; ++index4)
      {
        this.origRegion1[index3] = Vector3.Transform(this.origRegion1[index3], Matrix.CreateScale(1.5f));
        ++index3;
      }
    }

    public override void UnloadContent()
    {
      this.content.Unload();
      this.shaleBuffer.Dispose();
      this.shale1Buffer.Dispose();
    }

    public void uptheRamp(
      int val,
      ref Rover rover,
      gemDupe v,
      ref gemDupe[] gemxInst,
      ref int gemxCount,
      ref gemstruct.transcolor[] transx,
      ref int gemxtrack)
    {
      if (v.onramp == 5 || v.onramp != 1)
        return;
      v.rampy = gemstruct.setitRight;
      v.velocity += new Vector3(0.0f, 0.03f, 0.1f);
      if ((double) v.mypos.Z > (double) this.origRegion1[2].Z * 30.0)
      {
        if (gemstruct.totalGems > 250)
        {
          this.crunch.Play(this.sc.ev, 0.3f, 0.0f);
          v.mypos = rover.position + Vector3.Transform(new Vector3(-14.25f, 94.5f, -7.95000029f), rover.orientation);
          v.velocity = Vector3.Transform(new Vector3((float) this.rr.Next(-100, 90) / 50f, 3f, 6f), rover.orientation);
          v.rampy = Matrix.Identity;
          v.onramp = 5;
          v.move = true;
        }
        else
        {
          v.onramp = 2;
          v.mypos = this.pipeShot * 30f;
          v.velocity = new Vector3((float) this.rr.Next(-300, 700) / 300f, (float) ((double) this.rr.Next(-300, 300) / 200.0 + (double) (gemstruct.totalGems / 60) * (double) v.scaler / 15.0), (float) this.rr.Next(400, 2400) / 300f);
          this.crunch.Play(this.sc.ev, 0.0f, 0.0f);
          ++gemstruct.totalGems;
          v.onramp = -1;
          v.rampy = Matrix.Identity;
          v.move = false;
          if (gemxCount < this.maxgemx)
            gemxInst[gemxtrack] = new gemDupe(this.sc, v.mypos, Vector3.Zero, true, this.rr.Next(2, 100));
          gemxInst[gemxtrack].mypos = v.mypos;
          gemxInst[gemxtrack].velocity = v.velocity;
          gemxInst[gemxtrack].scaler = v.scaler;
          gemxInst[gemxtrack].onramp = 2;
          ++gemxCount;
          if (gemxCount > this.maxgemx - 1)
            gemxCount = this.maxgemx - 1;
          ++gemxtrack;
          if (gemxtrack <= this.maxgemx - 1)
            return;
          gemxtrack = 0;
        }
      }
      else
      {
        if ((double) v.mypos.X > (double) this.origRegion1[2].X * 30.0 || (double) v.mypos.X < (double) this.origRegion1[3].X * 30.0)
          v.velocity.X = (float) (-(double) v.velocity.X / 2.0);
        v.velocity.X += (float) ((0.0 - (double) v.mypos.X) / 140.0);
        v.groundHeight = 0.0f;
        v.normal = Vector3.Up;
      }
    }

    public void hitDumper(gemDupe v)
    {
      if (v.onramp == 3)
      {
        v.rampy = gemstruct.inDumper;
      }
      else
      {
        if (v.onramp != 2)
          return;
        v.rampy = gemstruct.inDumper;
        v.velocity.Y += -0.2f;
        float num1 = v.scaler * 1f;
        float num2 = MathHelper.Lerp(this.origDumper1[1].X * 30f - num1, this.origDumper1[2].X * 30f - num1, (float) (((double) v.mypos.Z - (double) this.origDumper1[0].Z * 30.0) / ((double) this.origDumper1[3].Z * 30.0 - (double) this.origDumper1[0].Z * 30.0)));
        if ((double) v.mypos.X > (double) num2)
        {
          v.mypos.X = num2;
          v.velocity.X = (float) (-(double) v.velocity.X / 1.5);
        }
        else
        {
          float num3 = MathHelper.Lerp(this.origDumper1[0].X * 30f + num1, this.origDumper1[3].X * 30f + num1, (float) (((double) v.mypos.Z - (double) this.origDumper1[0].Z * 30.0) / ((double) this.origDumper1[3].Z * 30.0 - (double) this.origDumper1[0].Z * 30.0)));
          if ((double) v.mypos.X < (double) num3)
          {
            v.mypos.X = num3;
            v.velocity.X = (float) (-(double) v.velocity.X / 1.5);
          }
        }
        if ((double) v.mypos.Z > (double) this.origDumper1[2].Z * 30.0 - (double) num1)
        {
          v.mypos.Z = this.origDumper1[2].Z * 30f - num1;
          v.velocity.Z = (float) (-(double) v.velocity.Z / 1.5);
        }
        else if ((double) v.mypos.Z < (double) this.origDumper1[1].Z * 30.0 + (double) num1 && (double) v.velocity.Z < 0.0)
        {
          v.mypos.Z = this.origDumper1[1].Z * 30f + num1;
          v.velocity.Z = (float) (-(double) v.velocity.Z / 1.5);
        }
        v.groundHeight = (float) ((double) this.origDumper1[0].Y * 30.0 + (double) (gemstruct.totalGems / 60) * (double) v.scaler);
        v.normal = Vector3.Up;
      }
    }

    public void drawShale(Vector3 light, Vector3 amb, Vector3 diff, Matrix view, Matrix proj)
    {
      this.DrawInstance(this.model, this.Trans, this.Inst.Count, this.shaleBuffer, light, amb, diff, view, proj);
    }

    public void drawShaleInDumper(
      Vector3 light,
      Vector3 amb,
      Vector3 diff,
      Matrix view,
      Matrix proj)
    {
      this.DrawInstance(this.model, this.xTrans, this.xCount, this.shale1Buffer, light, amb, diff, view, proj);
    }

    public void DrawInstance(
      Model model,
      gemstruct.transcolor[] minstances,
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
      dd.SetData<gemstruct.transcolor>(minstances, 0, cc, SetDataOptions.Discard);
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

    public enum gemtype
    {
      shale,
      ruby,
      sapphire,
      chaff,
      iron,
      salt,
      emerald,
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

      VertexDeclaration IVertexType.VertexDeclaration => gemstruct.transcolor.VertexDeclaration;
    }
  }
}
