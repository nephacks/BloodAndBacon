// Decompiled with JetBrains decompiler
// Type: Blood.MoonSurface
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Blood
{
  internal class MoonSurface : GameScreen
  {
    private ContentManager content;
    public int randomField = 2;
    private Texture2D tt;
    private Color[] colorArray1 = new Color[0];
    private Color[] colorArray2 = new Color[0];
    private Color[] dataArray = new Color[0];
    private GraphicsDevice device;
    private PresentationParameters pp;
    private SpriteBatch spriteBatch;
    public int baseHite = 2000;
    public List<MoonSurface.astroState> astroLoc = new List<MoonSurface.astroState>();
    public Vector2 facility1 = Vector2.Zero;
    public float facility1hite;
    public Vector2 facilitySmooth = Vector2.Zero;
    private Random random;
    private Texture2D brush1;
    private Texture2D brush2;
    private Texture2D brush3;
    private Texture2D brush9;
    private Texture2D mount1;
    private Texture2D valley1;
    private Texture2D object1;
    public Texture2D displayLegend;
    private ScreenManager sc;
    public List<ushort> high;
    public List<ushort> low;

    public void LoadContent(
      ContentManager content,
      ScreenManager sc,
      ref int[,] heightData,
      ref Vector3[,] normalData,
      ref int[,] objectData,
      ref MoonSurface.tex[] texData)
    {
      this.content = content;
      this.sc = sc;
      this.device = sc.GraphicsDevice;
      this.spriteBatch = new SpriteBatch(sc.GraphicsDevice);
      this.displayLegend = new Texture2D(this.device, 500, 500);
      if (sc.planetName[sc.planet] == "Earth")
      {
        this.mount1 = content.Load<Texture2D>("astro\\brushes\\mount4");
        this.valley1 = content.Load<Texture2D>("astro\\brushes\\valley4");
        this.object1 = content.Load<Texture2D>("astro\\brushes\\object4");
        this.brush2 = content.Load<Texture2D>("astro\\brushes\\brush8");
      }
      else if (sc.planetName[sc.planet] == "Mercury")
        this.object1 = content.Load<Texture2D>("astro\\brushes\\object3");
      else if (sc.planetName[sc.planet] == "Venus")
      {
        this.mount1 = content.Load<Texture2D>("astro\\brushes\\mount2");
        this.valley1 = content.Load<Texture2D>("astro\\brushes\\valley2");
        this.object1 = content.Load<Texture2D>("astro\\brushes\\object2");
      }
      else if (sc.planetName[sc.planet] == "Mars")
      {
        this.mount1 = content.Load<Texture2D>("astro\\brushes\\mount5");
        this.valley1 = content.Load<Texture2D>("astro\\brushes\\valley5");
        this.object1 = content.Load<Texture2D>("astro\\brushes\\object5");
      }
      else if (sc.planetName[sc.planet] == "Neptune")
      {
        this.mount1 = content.Load<Texture2D>("astro\\brushes\\mount8");
        this.valley1 = content.Load<Texture2D>("astro\\brushes\\valley8");
        this.object1 = content.Load<Texture2D>("astro\\brushes\\object8");
      }
      else
      {
        this.mount1 = content.Load<Texture2D>("astro\\brushes\\mount1");
        this.valley1 = content.Load<Texture2D>("astro\\brushes\\valley1");
        this.object1 = content.Load<Texture2D>("astro\\brushes\\object1");
      }
      this.high = new List<ushort>();
      this.low = new List<ushort>();
      using (Stream stream = (Stream) File.OpenRead(Directory.GetCurrentDirectory() + "\\Content\\astro\\brushes\\earth2.raw"))
      {
        while (true)
        {
          int num1 = stream.ReadByte();
          int num2 = stream.ReadByte();
          if (num2 != -1)
          {
            if (num1 != -1)
              this.high.Add((ushort) (num1 << 8 | num2));
            else
              break;
          }
          else
            break;
        }
      }
      this.buildTerrain(this.randomField, sc, ref heightData, ref normalData, ref objectData, ref texData);
    }

    public override void UnloadContent()
    {
      this.content.Unload();
      this.high.Clear();
      this.low.Clear();
      this.brush1.Dispose();
      this.tt.Dispose();
      this.colorArray1 = new Color[0];
      this.colorArray2 = new Color[0];
      this.dataArray = new Color[0];
    }

    public void buildTerrain(
      int val,
      ScreenManager sc,
      ref int[,] heightData,
      ref Vector3[,] normalData,
      ref int[,] objectData,
      ref MoonSurface.tex[] texData)
    {
      this.random = new Random(val);
      Color color1 = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      Color color2 = new Color(0, 234, (int) byte.MaxValue);
      Color color3 = new Color((int) byte.MaxValue, 0, 0);
      Color color4 = new Color(0, (int) byte.MaxValue, 0);
      this.dataArray = new Color[250000];
      this.object1.GetData<Color>(this.dataArray);
      for (int index1 = 0; index1 < 500; ++index1)
      {
        for (int index2 = 0; index2 < 500; ++index2)
        {
          if (index2 < 500 && index1 < 500)
          {
            if (this.dataArray[index2 + index1 * 500] == color1)
              objectData[index2, index1] = 27;
            else if (this.dataArray[index2 + index1 * 500] == new Color(150, (int) byte.MaxValue, (int) byte.MaxValue))
              objectData[index2, index1] = 28;
            else if (this.dataArray[index2 + index1 * 500] == new Color(50, 50, 50))
              objectData[index2, index1] = 29;
            else if (this.dataArray[index2 + index1 * 500] == new Color(100, 100, (int) byte.MaxValue))
              objectData[index2, index1] = 30;
            else if (this.dataArray[index2 + index1 * 500] == new Color(155, 0, (int) byte.MaxValue))
              objectData[index2, index1] = 7;
            else if (this.dataArray[index2 + index1 * 500] == color2)
              objectData[index2, index1] = 5;
            else if (this.dataArray[index2 + index1 * 500] == color3)
            {
              this.astroLoc.Add(new MoonSurface.astroState(new Vector2((float) ((index2 - 250) * 4 * 150), (float) ((index1 - 250) * 4 * 150)), astroDupe.emotion.safe));
              objectData[index2, index1] = 0;
            }
            else if (this.dataArray[index2 + index1 * 500] == new Color((int) byte.MaxValue, (int) byte.MaxValue, 0))
            {
              this.astroLoc.Add(new MoonSurface.astroState(new Vector2((float) ((index2 - 250) * 4 * 150), (float) ((index1 - 250) * 4 * 150)), astroDupe.emotion.stranded));
              objectData[index2, index1] = 0;
            }
            else if (this.dataArray[index2 + index1 * 500] == new Color((int) byte.MaxValue, 200, 0))
            {
              this.astroLoc.Add(new MoonSurface.astroState(new Vector2((float) ((index2 - 250) * 4 * 150), (float) ((index1 - 250) * 4 * 150)), astroDupe.emotion.stranded2));
              objectData[index2, index1] = 0;
            }
            else if (this.dataArray[index2 + index1 * 500] == new Color((int) byte.MaxValue, 100, 0))
            {
              this.astroLoc.Add(new MoonSurface.astroState(new Vector2((float) ((index2 - 250) * 4 * 150), (float) ((index1 - 250) * 4 * 150)), astroDupe.emotion.underground));
              objectData[index2, index1] = 0;
            }
            else if (this.dataArray[index2 + index1 * 500] == color4)
            {
              this.facility1 = new Vector2((float) ((index2 - 250) * 4 * 150), (float) ((index1 - 250) * 4 * 150));
              this.facilitySmooth = new Vector2((float) (index2 * 4), (float) (index1 * 4));
              objectData[index2, index1] = 0;
            }
            else
              objectData[index2, index1] = 0;
          }
        }
      }
      this.object1.Dispose();
      if (sc.planetName[sc.planet] == "Mercury")
        this.maketerrain(0, 0, 6, 25, 4, 2, 0, 1, ref heightData, ref normalData, ref texData);
      else if (sc.planetName[sc.planet] == "Venus")
        this.maketerrain(3730, 0, 26, 40, 2, 4, 3, 1, ref heightData, ref normalData, ref texData);
      else if (sc.planetName[sc.planet] == "Earth")
        this.maketerrain(1200, 1, 8, 22, 1, 1, 1, 0, ref heightData, ref normalData, ref texData);
      else if (sc.planetName[sc.planet] == "Mars")
        this.maketerrain(1730, 0, 24, 7, 2, 1, 3, 1, ref heightData, ref normalData, ref texData);
      else if (sc.planetName[sc.planet] == "Neptune")
        this.maketerrain(3730, 0, 12, 12, 1, 1, 1, 1, ref heightData, ref normalData, ref texData);
      else
        this.maketerrain(3000, 2, 10, 25, 2, 6, 3, 1, ref heightData, ref normalData, ref texData);
      this.fixNormals(ref heightData, ref normalData);
      this.facility1hite = (float) heightData[(int) this.facilitySmooth.X, (int) this.facilitySmooth.Y];
    }

    private void coverBrush(
      Texture2D brush,
      string rgb,
      float oddspercent,
      int gapmin,
      int gapmax,
      int rotmin,
      int rotmax,
      int scalemin,
      int scalemax,
      int depthmin,
      int depthmax)
    {
      int num1 = 2000;
      int num2 = brush.Width / 2;
      Color color = Color.White;
      int num3 = 2000 - num2;
      for (int x1 = num2; x1 < num1; x1 += this.random.Next(num2 + gapmin, num2 + gapmax))
      {
        this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, SamplerState.AnisotropicWrap, DepthStencilState.Default, RasterizerState.CullNone);
        for (int y1 = num2; y1 < num1; y1 += this.random.Next(num2 + gapmin, num2 + gapmax))
        {
          if ((double) this.random.Next(0, 100) <= (double) oddspercent)
          {
            float rotation = (float) this.random.Next(rotmin, rotmax) / 1000f;
            float scale = (float) this.random.Next(scalemin, scalemax) / 1000f;
            if (rgb == "red")
              color = new Color((int) (byte) this.random.Next(depthmin, depthmax), 0, 0, (int) byte.MaxValue);
            if (rgb == "grn")
              color = new Color(0, (int) (byte) this.random.Next(depthmin, depthmax), 0, (int) byte.MaxValue);
            if (rgb == "blu")
              color = new Color(0, 0, (int) (byte) this.random.Next(depthmin, depthmax), (int) byte.MaxValue);
            this.spriteBatch.Draw(brush, new Vector2((float) x1, (float) y1), new Rectangle?(), color, rotation, new Vector2((float) num2, (float) num2), scale, SpriteEffects.None, 0.0f);
            int x2 = x1;
            int y2 = y1;
            if (y1 > num3)
              y2 = -(num1 - y1);
            if (x1 > num3)
              x2 = -(num1 - x1);
            if (y1 > num3 || x1 > num3)
              this.spriteBatch.Draw(brush, new Vector2((float) x2, (float) y2), new Rectangle?(), color, rotation, new Vector2((float) num2, (float) num2), scale, SpriteEffects.None, 0.0f);
            if (y1 > num3 && x1 > num3)
            {
              this.spriteBatch.Draw(brush, new Vector2((float) x1, (float) y2), new Rectangle?(), color, rotation, new Vector2((float) num2, (float) num2), scale, SpriteEffects.None, 0.0f);
              this.spriteBatch.Draw(brush, new Vector2((float) x2, (float) y1), new Rectangle?(), color, rotation, new Vector2((float) num2, (float) num2), scale, SpriteEffects.None, 0.0f);
            }
          }
        }
        this.spriteBatch.End();
      }
    }

    public void maketerrain(
      int a,
      int b,
      int c,
      int d,
      int e,
      int f,
      int g,
      int div,
      ref int[,] heightData,
      ref Vector3[,] normalData,
      ref MoonSurface.tex[] texData)
    {
      this.baseHite = a;
      int num1 = 2000;
      for (int index1 = 0; index1 < 2001; ++index1)
      {
        int index2 = index1 - 1;
        int index3 = index2 + 1;
        if (index3 > 1999)
          index3 = 0;
        for (int index4 = 0; index4 < 2001; ++index4)
        {
          if (index4 < 2000 && index1 < 2000)
          {
            int num2 = (int) Vector2.Distance(new Vector2((float) index4, (float) index1), this.facilitySmooth);
            if (num2 <= 3)
              num2 = 0;
            if (num2 > 30)
              num2 = 30;
            if (31 - num2 < 1)
              ;
            heightData[index4, index1] = a;
            heightData[index4, index1] += (int) this.high[index4 + index1 * num1] / 10;
            this.buildtexture(ref heightData, ref texData, index4, index1);
          }
          if (index4 > 0 && index1 > 0)
          {
            int index5 = index4 - 1;
            int index6 = index5 + 1;
            if (index6 > 1999)
              index6 = 0;
            Vector3 vector3 = new Vector3((float) (-heightData[index6, index2] + heightData[index5, index2]), 150f, (float) (-heightData[index5, index3] + heightData[index5, index2]));
            normalData[index5, index3] += vector3;
            normalData[index5, index2] += vector3;
            normalData[index6, index2] += vector3;
            normalData[index5, index2].Normalize();
          }
        }
      }
    }

    public void buildtexture(ref int[,] heightData, ref MoonSurface.tex[] texData, int xx, int yy)
    {
      int num1 = heightData[xx, yy] + 2000;
      int num2 = heightData[xx, yy];
      texData[xx + yy * 2000].TexWeights.X = MathHelper.Clamp((float) (1 - Math.Abs(num2) / 2000), 0.0f, 1f);
      texData[xx + yy * 2000].TexWeights.Y = MathHelper.Clamp((float) (1 - Math.Abs(num2 - 4000) / 3980), 0.0f, 1f);
      texData[xx + yy * 2000].TexWeights.Z = MathHelper.Clamp((float) (1 - Math.Abs(num2 - 8000) / 6000), 0.0f, 1f);
      if (num2 >= 7000)
        texData[xx + yy * 2000].TexWeights.Z = 1f;
      if (num2 <= 20)
      {
        texData[xx + yy * 2000].TexWeights.Y = 0.01f;
        texData[xx + yy * 2000].TexWeights.X = 1f;
      }
      float num3 = texData[xx + yy * 2000].TexWeights.X + texData[xx + yy * 2000].TexWeights.Y + texData[xx + yy * 2000].TexWeights.Z;
      double num4 = (double) MathHelper.Clamp(num3, 1f, 10f);
      float x = texData[xx + yy * 2000].TexWeights.X;
      float y = texData[xx + yy * 2000].TexWeights.Y;
      float z = texData[xx + yy * 2000].TexWeights.Z;
      float num5 = x / num3;
      float num6 = y / num3;
      float num7 = z / num3;
      texData[xx + yy * 2000].TexWeights.X = num5;
      texData[xx + yy * 2000].TexWeights.Y = num6;
      texData[xx + yy * 2000].TexWeights.Z = num7;
    }

    public void fixNormals(ref int[,] heightData, ref Vector3[,] normalData)
    {
      for (int index = 0; index < 2000; ++index)
      {
        Vector3 vector3_1 = Vector3.Normalize((normalData[index, 0] + normalData[index, 1999]) / 2f);
        normalData[index, 0] = vector3_1;
        normalData[index, 1999] = vector3_1;
        Vector3 vector3_2 = Vector3.Normalize((normalData[0, index] + normalData[1999, index]) / 2f);
        normalData[0, index] = vector3_2;
        normalData[1999, index] = vector3_2;
      }
    }

    public void buildObjectMap(int myposx, int myposz, ref int[,] data)
    {
      Color[] data1 = new Color[250000];
      int num1 = 500;
      int num2 = 0;
      int num3 = 500;
      int num4 = 500;
      for (int index1 = 0; index1 < num4; ++index1)
      {
        for (int index2 = num2; index2 < num3; ++index2)
        {
          if (data[index2, index1] == 5)
            data1[index2 + index1 * num1] = new Color(0, 234, (int) byte.MaxValue);
          if (data[index2, index1] == 27)
            data1[index2 + index1 * num1] = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
          if (data[index2, index1] == 99)
            data1[index2 + index1 * num1] = new Color((int) byte.MaxValue, 0, 0);
          if (myposx / 4 == index2 && myposz / 4 == index1)
            data1[index2 + index1 * num1] = new Color(0, (int) byte.MaxValue, 0);
        }
      }
      try
      {
        this.displayLegend.SetData<Color>(data1);
      }
      catch
      {
      }
    }

    public class astroState
    {
      public Vector2 Loc = new Vector2();
      public astroDupe.emotion emo;

      public astroState(Vector2 p1, astroDupe.emotion p2)
      {
        this.Loc = p1;
        this.emo = p2;
      }
    }

    public struct tex
    {
      public Vector3 TexWeights;
    }
  }
}
