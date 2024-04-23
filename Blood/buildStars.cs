// Decompiled with JetBrains decompiler
// Type: Blood.buildStars
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
  public class buildStars : GameScreen
  {
    private SpriteBatch starBatch;
    public Texture2D starSheet;
    public Texture2D tt;
    public Texture2D manmadestars;
    public Color[] colorArray1 = new Color[0];
    private Texture2D miniPlanet;
    private Texture2D miniSun;
    private Random random;
    private ContentManager content;

    public void LoadContent(
      ScreenManager sc,
      ContentManager content,
      GraphicsDevice gr,
      int max,
      int odds,
      bool addplanet,
      int planet)
    {
      this.content = content;
      this.starSheet = content.Load<Texture2D>("astro\\sprites\\stars\\starSheet");
      this.random = new Random();
      PresentationParameters presentationParameters = gr.PresentationParameters;
      this.starBatch = new SpriteBatch(gr);
      int num1 = max / 2;
      if (addplanet)
        num1 = max / 4;
      this.colorArray1 = new Color[num1 * num1];
      RenderTarget2D renderTarget = new RenderTarget2D(gr, num1, num1, false, SurfaceFormat.Color, DepthFormat.None);
      this.manmadestars = new Texture2D(gr, max, max);
      this.random.Next(1, 3);
      int num2 = 1;
      string[] strArray = new string[18]
      {
        "miniMercury2",
        "miniVenus2",
        "miniEarth2",
        "miniMars2",
        "miniJupiter2",
        "miniSaturn2",
        "miniUranus2",
        "miniNeptune2",
        "miniPluto2",
        "miniMercury",
        "miniVenus",
        "miniEarth",
        "miniMars",
        "miniJupiter",
        "miniSaturn",
        "miniUranus",
        "miniNeptune",
        "miniPluto"
      };
      float num3 = (float) this.random.Next(100, 270) / 100f;
      float num4 = 1f;
      this.miniSun = content.Load<Texture2D>("astro\\sprites\\planets\\sun");
      for (int y = 0; y < max; y += num1)
      {
        for (int x = 0; x < max; x += num1)
        {
          gr.SetRenderTarget(renderTarget);
          gr.Clear(Color.Black);
          this.makestars(num1, odds, addplanet);
          if (addplanet)
          {
            if (x == 600 && y == 300 && num2 == 1)
            {
              string str = strArray[planet];
              this.miniPlanet = content.Load<Texture2D>("astro\\sprites\\planets\\" + str);
              this.starBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);
              this.starBatch.Draw(this.miniPlanet, new Rectangle((int) ((300.0 - 240.0 * (double) num4) / 2.0), (int) ((300.0 - 96.0 * (double) num4) / 2.0), (int) (240.0 * (double) num4), (int) (96.0 * (double) num4)), Color.White);
              this.starBatch.End();
            }
            if (x == 300 && y == 300 && num2 == 2)
            {
              string str = strArray[planet + 9];
              this.miniPlanet = content.Load<Texture2D>("astro\\sprites\\planets\\" + str);
              this.starBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);
              this.starBatch.Draw(this.miniPlanet, new Rectangle((int) ((300.0 - 240.0 * (double) num4) / 2.0), (int) ((300.0 - 96.0 * (double) num4) / 2.0), (int) (240.0 * (double) num4), (int) (96.0 * (double) num4)), Color.White);
              this.starBatch.End();
            }
            if (x == 300 && y == 600)
            {
              this.starBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);
              this.starBatch.Draw(this.miniSun, new Rectangle(100, 100, 150, 150), Color.White);
              this.starBatch.End();
            }
          }
          gr.SetRenderTarget((RenderTarget2D) null);
          this.tt = (Texture2D) renderTarget;
          this.tt.GetData<Color>(this.colorArray1);
          this.manmadestars.SetData<Color>(0, new Rectangle?(new Rectangle(x, y, num1, num1)), this.colorArray1, 0, this.colorArray1.Length);
        }
      }
    }

    public new void UnloadContent()
    {
      this.manmadestars.Dispose();
      this.starBatch.Dispose();
      this.starSheet.Dispose();
      this.content.Unload();
      this.content.Dispose();
      this.content = (ContentManager) null;
    }

    public void makestars(int min, int odds, bool addplanet)
    {
      int num1 = 1;
      int[] numArray1 = new int[18]
      {
        0,
        0,
        4,
        0,
        8,
        0,
        12,
        0,
        16,
        0,
        0,
        4,
        4,
        4,
        8,
        4,
        12,
        4
      };
      int[] numArray2 = new int[18]
      {
        0,
        8,
        8,
        8,
        16,
        8,
        24,
        8,
        32,
        8,
        40,
        8,
        48,
        8,
        56,
        8,
        32,
        8
      };
      int[] numArray3 = new int[16]
      {
        0,
        16,
        12,
        16,
        24,
        16,
        36,
        16,
        0,
        28,
        12,
        28,
        24,
        28,
        36,
        28
      };
      int[] numArray4 = new int[8]
      {
        0,
        40,
        20,
        40,
        40,
        40,
        44,
        16
      };
      int num2 = min;
      int num3 = 6;
      this.starBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive);
      for (int y1 = 0; y1 <= num2; ++y1)
      {
        for (int x1 = 0; x1 <= num2; ++x1)
        {
          if (this.random.Next(1, odds) < 32)
          {
            int num4 = this.random.Next(1, 1000);
            int num5 = 0;
            int num6 = this.random.Next(0, 9);
            int x2 = numArray1[num6 * 2];
            int y2 = numArray1[num6 * 2 + 1];
            int num7 = 4;
            int num8 = 4;
            if (num4 > 45 && num4 < 115)
            {
              x2 = numArray2[num6 * 2];
              y2 = numArray2[num6 * 2 + 1];
              num7 = 8;
              num8 = 8;
            }
            if (num4 < 10)
            {
              int num9 = this.random.Next(0, 8);
              x2 = numArray3[num9 * 2];
              y2 = numArray3[num9 * 2 + 1];
              num7 = 12;
              num8 = 12;
            }
            int num10 = this.random.Next(0, 4);
            if (num4 > 165 && num4 < 170 && num3 > 0)
            {
              num5 = 1;
              x2 = numArray4[num10 * 2];
              y2 = numArray4[num10 * 2 + 1];
              num8 = 20;
              num7 = 20;
              --num3;
            }
            if (num4 > 790)
            {
              x2 = 24;
              y2 = 0;
              num7 = 8;
              num8 = 8;
            }
            if (num4 > 860)
            {
              x2 = 32;
              y2 = 0;
              num7 = 8;
              num8 = 8;
            }
            if (num4 > 930)
            {
              x2 = 40;
              y2 = 0;
              num7 = 8;
              num8 = 8;
            }
            float rotation = (float) this.random.Next(0, 760000) / 1000f;
            float scale = (float) this.random.Next(4000, 10000) / 10000f;
            byte num11 = (byte) this.random.Next(200, (int) byte.MaxValue);
            if (addplanet)
              scale = (float) this.random.Next(15000, 19000) / 10000f;
            Color color = new Color((int) num11, (int) num11, (int) num11, (int) byte.MaxValue);
            if (num5 == 1)
            {
              byte num12 = (byte) this.random.Next(210, (int) byte.MaxValue);
              color = new Color((int) num12, (int) num12, (int) num12, (int) byte.MaxValue);
              if (this.random.Next(1, 5000) < 1200)
                color = new Color((int) (byte) this.random.Next(140, 240), (int) (byte) this.random.Next(140, 240), (int) (byte) this.random.Next(140, 240), (int) byte.MaxValue);
              scale = (float) this.random.Next(8000, 15000) / 10000f;
            }
            int width = num7 * num1;
            int height = num8 * num1;
            if ((double) x1 + (double) width * (double) scale / 2.0 <= (double) num2 && (double) x1 - (double) width * (double) scale / 2.0 >= 0.0 && (double) y1 + (double) height * (double) scale / 2.0 <= (double) num2 && (double) y1 - (double) height * (double) scale / 2.0 >= 0.0)
              this.starBatch.Draw(this.starSheet, new Vector2((float) x1, (float) y1), new Rectangle?(new Rectangle(x2, y2, width, height)), color, rotation, new Vector2((float) (x2 + width / 2), (float) (y2 + height / 2)), scale, SpriteEffects.None, 0.0f);
          }
        }
      }
      this.starBatch.End();
    }
  }
}
