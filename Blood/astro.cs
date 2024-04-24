using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SkinnedModel;
using System;
using System.Collections.Generic;

#pragma warning disable CS0414
#pragma warning disable CS0649
#pragma warning disable CS0169
#nullable disable
namespace Blood
{
  public class astro : GameScreen
  {
    public static int teamCount = 0;
    public static int oldteamCount = 0;
    public static bool someonedied = false;
    public static Matrix inDumper = Matrix.Identity;
    public static Vector3 rovpos;
    public static Vector3 rovveloc;
    private Vector3 campos;
    private Vector3 camlookpos;
    public int chosen = -1;
    private int type;
    private Vector3 norm1;
    private Vector3 norm2;
    private float dot;
    private int myframe;
    public float facingRover;
    public List<int> doorList = new List<int>();
    private BasicEffect basiceffect;
    public List<astro.overhead> drawOverheads = new List<astro.overhead>();
    public List<astro.seat> seats = new List<astro.seat>();
    private List<int> rider = new List<int>();
    public bool manhit;
    public bool saluteRequest;
    public bool everyoneOut;
    private readonly VertexBufferBinding[] _vertexBufferBindings = new VertexBufferBinding[2];
    private static VertexDeclaration vd = new VertexDeclaration(new VertexElement[8]
    {
      new VertexElement(0, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 1),
      new VertexElement(16, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 2),
      new VertexElement(32, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 3),
      new VertexElement(48, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 4),
      new VertexElement(64, VertexElementFormat.Single, VertexElementUsage.Fog, 0),
      new VertexElement(68, VertexElementFormat.Single, VertexElementUsage.Fog, 1),
      new VertexElement(72, VertexElementFormat.Single, VertexElementUsage.Fog, 2),
      new VertexElement(76, VertexElementFormat.Single, VertexElementUsage.Fog, 3)
    });
    private astro.conductor tempConduct = new astro.conductor();
    public astro.npc man;
    public astro.skinstream tempySkin = new astro.skinstream();
    private ScreenManager sc;
    private ContentManager content;
    private float camradian;
    private Matrix view;
    private Matrix proj;
    private Vector3 light;
    private Vector3 diff;
    private Vector3 amb;
    private int lastmanAlive = -1;
    private List<int> parts;
    private int[] s;
    private Effect dayEffect;
    private Effect tintEffect;
    private Vector3 v1;
    private Vector3 v2;
    private Vector3 v3;
    private Vector3 vZero = Vector3.Zero;
    private Matrix m1;
    private Matrix m2;
    private Matrix m3;
    private Matrix m4;
    private float f1;
    private float f2;
    private float f3;
    private Random rand1;
    private SpriteBatch spriteBatch;
    private Model sphere;
    private Vector2 myStart;
    private Vector2 myDest;
    private Effect simpEffect;
    private Texture2D whitesquare;
    private Texture2D greensquare;
    private Texture2D redsquare;

    public void LoadContent(ContentManager content, ScreenManager sc)
    {
      this.sc = sc;
      this.rand1 = new Random();
      this.parts = new List<int>(5);
      this.s = new int[5];
      this.man = new astro.npc();
      this.man.alive = (ushort) 0;
      this.man.alive2 = (ushort) 55555;
      this.man.data = sc.astroModel.Tag as SkinningDataX;
      this.makeImage(this.man.data.Bones, this.man.data.Width, this.man.data.Hite, ref this.man.bitmap);
      this.man.model1 = sc.astroModel;
      this.man.texture2D_0 = content.Load<Texture2D>("astro\\npc\\SpacesuitRe");
      this.man.max = 600;
      this.man.dupe = new List<astroDupe>(this.man.max);
      this.man.dupe.Capacity = 600;
      this.man.displayBody1 = new astro.skinstream[this.man.max];
      this.man.displayBody2 = new astro.skinstream[this.man.max];
      this.man.displayHand1 = new astro.skinstream[this.man.max];
      this.man.displayFist = new astro.skinstream[this.man.max];
      this.man.displayPack1 = new astro.skinstream[this.man.max];
      this.man.displayHelm1 = new astro.skinstream[this.man.max];
      this.man.displayHead1 = new astro.skinstream[this.man.max];
      this.man.displayHammer = new astro.skinstream[this.man.max];
      this.man.bodybuffer1 = new DynamicVertexBuffer(sc.GraphicsDevice, astro.vd, this.man.max, BufferUsage.WriteOnly);
      this.man.helmbuffer1 = new DynamicVertexBuffer(sc.GraphicsDevice, astro.vd, this.man.max, BufferUsage.WriteOnly);
      this.man.handbuffer1 = new DynamicVertexBuffer(sc.GraphicsDevice, astro.vd, this.man.max, BufferUsage.WriteOnly);
      this.man.fistbuffer = new DynamicVertexBuffer(sc.GraphicsDevice, astro.vd, this.man.max, BufferUsage.WriteOnly);
      this.man.packbuffer4 = new DynamicVertexBuffer(sc.GraphicsDevice, astro.vd, this.man.max, BufferUsage.WriteOnly);
      this.man.headbuffer5 = new DynamicVertexBuffer(sc.GraphicsDevice, astro.vd, this.man.max, BufferUsage.WriteOnly);
      this.man.bodybuffer2 = new DynamicVertexBuffer(sc.GraphicsDevice, astro.vd, this.man.max, BufferUsage.WriteOnly);
      this.man.hammerbuffer = new DynamicVertexBuffer(sc.GraphicsDevice, astro.vd, this.man.max, BufferUsage.WriteOnly);
      this.man.uv = new Vector3[9];
      this.man.uv[0] = new Vector3(50f, 50f, 1f);
      this.man.uv[1] = new Vector3(0.156f, 0.253000021f, 4f);
      this.man.uv[2] = new Vector3(0.575f, 0.195f, 3f);
      this.man.uv[3] = new Vector3(0.414f, 0.480000019f, 3f);
      this.man.uv[4] = new Vector3(0.58f, 0.480000019f, 3f);
      this.man.uv[5] = new Vector3(0.381f, 0.348999977f, 4f);
      this.man.uv[6] = new Vector3(0.618f, 0.356f, 4f);
      this.man.uv[7] = new Vector3(0.5f, 0.15f, 2f);
      this.man.uv[8] = new Vector3(0.5f, 0.58f, 1.4f);
      this.man.targ = new Matrix[8];
      this.man.targ[0] = Matrix.CreateTranslation(new Vector3(1f, 131f, -124f));
      this.man.targ[1] = Matrix.CreateTranslation(new Vector3(-36.3f, 157.6f, 155.7f));
      this.man.targ[2] = Matrix.CreateTranslation(new Vector3(29f, 157.5f, 155.7f));
      this.man.targ[3] = Matrix.CreateTranslation(new Vector3(-8f, 131.4f, -55f));
      this.man.targ[4] = Matrix.CreateTranslation(new Vector3(8f, 131.4f, -55f));
      this.man.targ[5] = Matrix.CreateTranslation(new Vector3(-30f, 164f, 50f));
      this.man.targ[6] = Matrix.CreateTranslation(new Vector3(30f, 164f, 50f));
      this.man.targ[7] = Matrix.CreateTranslation(new Vector3(-1f, 124f, 232f));
      this.man.bone = new int[8]
      {
        2,
        7,
        7,
        24,
        19,
        16,
        12,
        10
      };
      this.dayEffect = content.Load<Effect>("astro\\shaders\\EffectXbox");
      this.tintEffect = content.Load<Effect>("astro\\shaders\\EffectXboxTint");
      float num1 = 1f / (float) this.man.data.Width;
      float num2 = 1f / (float) this.man.data.Hite;
      float num3 = num1 / 2f;
      float num4 = num2 / 2f;
      this.dayEffect.Parameters["BoneDelta"].SetValue(num1);
      this.dayEffect.Parameters["RowDelta"].SetValue(num2);
      this.dayEffect.Parameters["halfWidth"].SetValue(num3);
      this.dayEffect.Parameters["halfHeight"].SetValue(num4);
      this.dayEffect.Parameters["Texture"].SetValue((Texture) this.man.texture2D_0);
      this.dayEffect.Parameters["AnimationTexture"].SetValue((Texture) this.man.bitmap);
      this.tintEffect.Parameters["BoneDelta"].SetValue(num1);
      this.tintEffect.Parameters["RowDelta"].SetValue(num2);
      this.tintEffect.Parameters["halfWidth"].SetValue(num3);
      this.tintEffect.Parameters["halfHeight"].SetValue(num4);
      this.tintEffect.Parameters["Texture"].SetValue((Texture) this.man.texture2D_0);
      this.tintEffect.Parameters["AnimationTexture"].SetValue((Texture) this.man.bitmap);
      this.man.eff = this.dayEffect;
      astroDupe.sics = new List<int>(2 * (this.man.data.Clips.Length + 1));
      astroDupe.sics.Add(this.man.data.Clips[0]);
      astroDupe.sics.Add(0);
      for (int index = 1; index < this.man.data.Clips.Length; ++index)
      {
        astroDupe.sics.Add(this.man.data.Clips[index] - this.man.data.Clips[index - 1]);
        astroDupe.sics.Add(this.man.data.Clips[index - 1]);
      }
      this.spriteBatch = new SpriteBatch(sc.GraphicsDevice);
      this.basiceffect = new BasicEffect(sc.GraphicsDevice)
      {
        TextureEnabled = true,
        VertexColorEnabled = true
      };
      this.sphere = content.Load<Model>("astro\\models\\sphere");
      this.simpEffect = content.Load<Effect>("astro\\shaders\\simple");
      this.greensquare = new Texture2D(sc.GraphicsDevice, 1, 1);
      this.greensquare.SetData<Color>(new Color[1]
      {
        Color.Green
      });
      this.redsquare = new Texture2D(sc.GraphicsDevice, 1, 1);
      this.redsquare.SetData<Color>(new Color[1]
      {
        Color.DarkRed
      });
      this.whitesquare = new Texture2D(sc.GraphicsDevice, 1, 1);
      this.whitesquare.SetData<Color>(new Color[1]
      {
        Color.Gray
      });
      this.buildSeats();
      this.resetStates();
    }

    public override void UnloadContent()
    {
      this.man.bitmap.Dispose();
      this.content.Unload();
    }

    private void makeImage(Matrix[] m, int width, int hite, ref Texture2D tt)
    {
      tt = new Texture2D(this.sc.GraphicsDevice, width, hite, false, SurfaceFormat.Vector4);
      Vector4[] data = new Vector4[width * hite];
      int index1 = 0;
      for (int index2 = 0; index2 < m.Length; ++index2)
      {
        data[index1] = new Vector4(m[index2].M11, m[index2].M21, m[index2].M31, m[index2].M41);
        int index3 = index1 + 1;
        data[index3] = new Vector4(m[index2].M12, m[index2].M22, m[index2].M32, m[index2].M42);
        int index4 = index3 + 1;
        data[index4] = new Vector4(m[index2].M13, m[index2].M23, m[index2].M33, m[index2].M43);
        index1 = index4 + 1;
      }
      tt.SetData<Vector4>(data);
    }

    private void resetStates()
    {
      this.man.hitindex = 0;
      this.man.dupe.Clear();
    }

    public void dropAstronaut(int seed, Vector2 pos, int amt, astroDupe.emotion emo)
    {
      pos.X = (float) ((int) (((double) pos.X + 75.0) / 150.0) * 150 - 75);
      pos.Y = (float) ((int) (((double) pos.Y + 75.0) / 150.0) * 150 - 75);
      Vector3 startpos = Vector3.Zero;
      int seed1 = this.rand1.Next(9000, 22000);
      startpos = new Vector3(pos.X, 0.0f, pos.Y);
      this.man.dupe.Add(new astroDupe(startpos, 1, seed1, 0, this.sc, emo));
    }

    public void dropFacilityAstronaut(int seed, Vector2 pos, astroDupe.emotion emo, float rotter)
    {
      int num = this.rand1.Next(14, Facility.reachPlot.Count / 2);
      Vector2 destiny = new Vector2(Facility.reachPlot[num * 2], Facility.reachPlot[num * 2 + 1]);
      Vector2 startpos1 = new Vector2((float) (((double) pos.X - (double) Facility.offset.X) * 4.0), (float) (((double) pos.Y - (double) Facility.offset.Z) * 4.0));
      int seed1 = this.rand1.Next(9000, 22000);
      Vector3 startpos2 = Vector3.Zero;
      startpos2 = new Vector3(pos.X, Facility.offset.Y, pos.Y);
      this.man.dupe.Add(new astroDupe(startpos2, 2, seed1, 0, this.sc, emo, rotter));
      int index = this.man.dupe.Count - 1;
      try
      {
        this.man.dupe[index].botPath.Clear();
        if (this.botPath(ref Facility.reachPlot, ref this.man.dupe[index].botPath, startpos1, destiny) == "good")
        {
          this.man.dupe[index].move = 2;
          this.man.dupe[index].botStart = 0.0f;
        }
        else
        {
          this.man.dupe[index].move = 2;
          this.man.dupe[index].botStart = 0.0f;
        }
      }
      catch
      {
      }
    }

    public void newDestination(int i, Vector2 pos)
    {
      int num = this.rand1.Next(0, Facility.reachPlot.Count / 2);
      Vector2 destiny = new Vector2(Facility.reachPlot[num * 2], Facility.reachPlot[num * 2 + 1]);
      Vector2 startpos = new Vector2((float) (((double) pos.X - (double) Facility.offset.X) * 4.0), (float) (((double) pos.Y - (double) Facility.offset.Z) * 4.0));
      this.myDest = destiny;
      try
      {
        if (this.botPath(ref Facility.reachPlot, ref this.man.dupe[i].botPath, startpos, destiny) == "good")
        {
          this.man.dupe[i].move = 2;
          this.man.dupe[i].botStart = 0.0f;
        }
        else
        {
          destiny.X /= 4f;
          destiny.X += Facility.offset.X;
          destiny.Y /= 4f;
          destiny.Y += Facility.offset.Z;
          this.man.dupe[i].mypos.X = destiny.X;
          this.man.dupe[i].mypos.Z = destiny.Y;
          this.man.dupe[i].move = 2;
          this.man.dupe[i].botStart = 0.0f;
          this.man.dupe[i].botPath.Clear();
          this.man.dupe[i].botPath.Add(destiny);
          this.myStart = startpos;
        }
      }
      catch
      {
      }
    }

    private string botPath(
      ref List<float> floorplot,
      ref List<Vector2> botPath,
      Vector2 startpos,
      Vector2 destiny)
    {
      List<Vector2> vector2List = new List<Vector2>();
      float num1 = 800f;
      int index1 = -1;
      for (int index2 = 0; index2 < floorplot.Count; index2 += 2)
      {
        vector2List.Add(new Vector2(floorplot[index2] + 0.0f, floorplot[index2 + 1] + 0.0f));
        float num2 = Vector2.Distance(new Vector2(floorplot[index2] + 0.0f, floorplot[index2 + 1] + 0.0f), startpos);
        if ((double) num2 <= (double) num1)
        {
          num1 = num2;
          index1 = index2;
        }
      }
      if (index1 == -1)
        return "lost early";
      Vector2 start = new Vector2(floorplot[index1] + 0.0f, floorplot[index1 + 1] + 0.0f);
      List<Vector2> search = new List<Vector2>();
      List<Vector2> result = new List<Vector2>();
      vector2List.ForEach((Action<Vector2>) (item => search.Add(item)));
      bool flag = this.buildbotPath(ref search, ref result, start, destiny);
      botPath.Clear();
      for (int index3 = 0; index3 < result.Count; ++index3)
        botPath.Add(result[index3]);
      botPath.Add(destiny);
      return !flag ? "lost here " : "good";
    }

    private bool buildbotPath(
      ref List<Vector2> source,
      ref List<Vector2> result,
      Vector2 start,
      Vector2 end)
    {
      bool flag = true;
      Random random = new Random();
      List<Vector2> vector2List1 = new List<Vector2>();
      for (int index = 0; index < source.Count; ++index)
      {
        float num = Vector2.Distance(start, source[index]);
        if ((double) num > 50.0 && (double) num <= 400.0)
          vector2List1.Add(source[index]);
      }
      if (vector2List1.Count == 0)
        return false;
      List<Vector2> vector2List2 = new List<Vector2>();
      while (vector2List1.Count > 0)
      {
        int index = random.Next(0, vector2List1.Count);
        vector2List2.Add(vector2List1[index]);
        vector2List1.RemoveAt(index);
      }
      for (int index = 0; index < vector2List2.Count; ++index)
      {
        if ((double) Vector2.Distance(end, vector2List2[index]) > 500.0)
        {
          start = vector2List2[index];
          source.Remove(start);
          result.Add(start);
          if (flag = this.buildbotPath(ref source, ref result, start, end))
            return true;
          if (!flag)
            result.Remove(start);
        }
        else
        {
          result.Add(vector2List2[index]);
          return true;
        }
      }
      return flag;
    }

    public void buildSeats()
    {
      this.seats.Clear();
      this.seats.Add(new astro.seat()
      {
        rotoffset = 3.14f,
        posoffset = new Vector3(0.0f, 0.0f, 121f)
      });
      this.seats.Add(new astro.seat()
      {
        rotoffset = -1.57f,
        posoffset = new Vector3(61f, 0.0f, 35f)
      });
      this.seats.Add(new astro.seat()
      {
        rotoffset = 1.57f,
        posoffset = new Vector3(-63f, 0.0f, 49f)
      });
    }

    public void Update(
      ref int[,] heightData,
      ref Vector3[,] normalData,
      int type,
      Vector3 campos,
      Vector3 camlookpos,
      bool hidden)
    {
      this.type = type;
      this.campos = campos;
      this.camlookpos = camlookpos;
      ++this.myframe;
      this.updateAstro(ref this.man, ref heightData, ref normalData, hidden);
    }

    private void updateAstro(
      ref astro.npc n,
      ref int[,] heightData,
      ref Vector3[,] normalData,
      bool hiddenInLander)
    {
      this.lastmanAlive = -1;
      this.doorList.Clear();
      n.handindex1 = 0;
      n.fistindex1 = 0;
      n.bodyindex1 = 0;
      n.bodyindex2 = 0;
      n.packindex1 = 0;
      n.helmetindex1 = 0;
      n.headindex1 = 0;
      n.hammerindex1 = 0;
      this.drawOverheads.Clear();
      bool flag1 = false;
      if ((double) astro.rovveloc.Length() > 5.0)
        flag1 = true;
      n.alive = (ushort) 0;
      float num1 = 14400f;
      this.chosen = -1;
      this.norm2 = Vector3.Normalize(this.camlookpos - this.campos);
      astro.someonedied = false;
      for (int index = 0; index < n.dupe.Count; ++index)
      {
        if (n.dupe[index].emo == astroDupe.emotion.justsaved && !n.dupe[index].employed)
        {
          n.dupe[index].employed = true;
          n.dupe[index].emo = astroDupe.emotion.safe;
          ++astro.teamCount;
        }
        float num2 = Vector3.DistanceSquared(new Vector3(n.dupe[index].mypos.X, n.dupe[index].mypos.Y + 60f, n.dupe[index].mypos.Z), this.campos);
        bool flag2 = (double) num2 > 225000000.0;
        if (n.dupe[index].move >= 2 && !Facility.inFacility)
          flag2 = true;
        if (flag2 && this.myframe % 60 != 0)
        {
          if (n.dupe[index].emo == astroDupe.emotion.flipping)
            n.dupe.RemoveAt(index);
        }
        else
        {
          this.norm1 = Vector3.Normalize(new Vector3(n.dupe[index].mypos.X, n.dupe[index].mypos.Y + 60f, n.dupe[index].mypos.Z) - this.campos);
          this.dot = Vector3.Dot(this.norm1, this.norm2);
          if ((double) num2 < (double) num1 && (double) this.dot > 0.89999997615814209 && n.dupe[index].loc == astroDupe.where.outofTruck)
          {
            num1 = num2;
            this.chosen = index;
          }
          if (n.dupe[index].move == 1)
          {
            n.dupe[index].UpdateNormally(ref heightData, ref normalData);
            if (flag1 && (!n.dupe[index].flipinspace || (double) n.dupe[index].flipTimer > 3.0) && n.dupe[index].emo == astroDupe.emotion.safe && n.dupe[index].loc == astroDupe.where.outofTruck && (double) Vector3.Distance(astro.rovpos, n.dupe[index].mypos) < 50.0)
            {
              astro.someonedied = true;
              this.sc.manyell.Play(this.sc.ev, (float) this.rand1.Next(-20, 30) / 100f, 0.0f);
              this.manhit = true;
              n.dupe[index].flipinspace = true;
              n.dupe[index].flipVeloc = Vector3.Normalize(astro.rovveloc) * MathHelper.Min(30f, astro.rovveloc.Length() * 0.7f);
              n.dupe[index].flipVeloc.Y = (float) this.rand1.Next(-270, 270) / 100f;
              if (this.rand1.Next(1, 100) < 10)
                n.dupe[index].flipVeloc.Y = (float) this.rand1.Next(220, 470) / 100f;
              n.dupe[index].flipDir = Vector3.Normalize(new Vector3(astro.rovveloc.X, 0.1f, astro.rovveloc.Z));
              n.dupe[index].flipSpeed = (float) this.rand1.Next(4, 18) / 100f;
              if (this.rand1.Next(1, 100) < 50)
                n.dupe[index].flipSpeed *= -1f;
              n.dupe[index].flipRot = Matrix.CreateFromAxisAngle(Vector3.Cross(n.dupe[index].flipDir, Vector3.Up), n.dupe[index].flipSpeed);
              n.dupe[index].flipTimer = 0.0f;
              n.dupe[index].timer = 0.0f;
              if (n.dupe[index].employed)
              {
                --astro.teamCount;
                --astro.oldteamCount;
                if (astro.teamCount < 0)
                  astro.teamCount = 0;
                if (astro.oldteamCount < 0)
                  astro.oldteamCount = 0;
              }
              flag1 = false;
            }
            Matrix.CreateRotationY(n.dupe[index].myRot, out this.m2);
            if (n.dupe[index].clip1 == n.dupe[index].flipClip)
            {
              n.dupe[index].flipRot *= Matrix.CreateFromAxisAngle(Vector3.Cross(n.dupe[index].flipDir, Vector3.Up), n.dupe[index].flipSpeed);
              this.m2 *= Matrix.CreateTranslation(new Vector3(0.0f, -43f, 0.0f)) * n.dupe[index].flipRot * Matrix.CreateTranslation(new Vector3(0.0f, 43f, 0.0f));
            }
            Matrix.CreateTranslation(n.dupe[index].mypos.X, n.dupe[index].mypos.Y, n.dupe[index].mypos.Z, out this.m4);
            Matrix.Multiply(ref this.m2, ref this.m4, out n.dupe[index].transform);
            if (n.dupe[index].loc == astroDupe.where.enteringTruck)
              n.dupe[index].destination = Vector3.Transform(n.dupe[index].posOffset, astro.inDumper);
            if (n.dupe[index].loc == astroDupe.where.inTruck)
            {
              n.dupe[index].mypos = Vector3.Transform(n.dupe[index].posOffset, astro.inDumper);
              n.dupe[index].myRot = this.facingRover + n.dupe[index].rotOffset;
              n.dupe[index].transform = Matrix.CreateRotationY(n.dupe[index].rotOffset) * Matrix.CreateTranslation(n.dupe[index].posOffset) * astro.inDumper;
            }
            if (n.dupe[index].loc == astroDupe.where.leavingTruck)
            {
              n.dupe[index].mypos = Vector3.Transform(n.dupe[index].posOffset, astro.inDumper);
              n.dupe[index].myRot = (float) ((double) this.facingRover + (double) n.dupe[index].rotOffset + 0.0);
              n.dupe[index].transform = Matrix.CreateRotationY(n.dupe[index].rotOffset) * Matrix.CreateTranslation(n.dupe[index].posOffset) * astro.inDumper;
            }
          }
          if (n.dupe[index].move > 1)
          {
            n.dupe[index].updateFacilityAI(ref Facility.heightData, ref normalData);
            if (n.dupe[index].move == 3)
            {
              n.dupe[index].move = 2;
              this.newDestination(index, new Vector2(n.dupe[index].mypos.X, n.dupe[index].mypos.Z));
            }
            Matrix.CreateRotationY(n.dupe[index].myRot, out this.m2);
            Matrix.CreateTranslation(n.dupe[index].mypos.X, n.dupe[index].mypos.Y, n.dupe[index].mypos.Z, out this.m4);
            Matrix.Multiply(ref this.m2, ref this.m4, out n.dupe[index].transform);
            if (Facility.inFacility)
            {
              int num3 = Facility.clickable[(int) MathHelper.Clamp((float) Math.Round(((double) n.dupe[index].mypos.X - (double) Facility.offset.X) * 4.0 / 100.0), 0.0f, 175f), (int) MathHelper.Clamp((float) Math.Round(((double) n.dupe[index].mypos.Z - (double) Facility.offset.Z) * 4.0 / 100.0), 0.0f, 175f)];
              if (num3 > -1)
                this.doorList.Add(num3);
            }
          }
          if (n.dupe[index].loc != astroDupe.where.inTruck || !hiddenInLander)
          {
            if (this.sc.cheat_astro)
              this.drawOverheads.Add(new astro.overhead()
              {
                overheadpos = n.dupe[index].mypos,
                mess1 = n.dupe[index].emo.ToString(),
                mess2 = n.dupe[index].loc.ToString()
              });
            this.tempySkin.Transformation = n.dupe[index].transform;
            this.tempySkin.tween = n.dupe[index].tween;
            this.tempySkin.frame1 = (float) n.dupe[index].frame1;
            this.tempySkin.frame2 = (float) n.dupe[index].frame2;
            this.tempySkin.tint = (float) n.dupe[index].tint;
            if (n.dupe[index].bodytype == 1)
            {
              n.displayBody1[n.bodyindex1] = this.tempySkin;
              ++n.bodyindex1;
            }
            if (n.dupe[index].bodytype == 2)
            {
              n.displayBody2[n.bodyindex2] = this.tempySkin;
              ++n.bodyindex2;
            }
            if (n.dupe[index].clip1 == n.dupe[index].hammerClip)
            {
              n.displayFist[n.fistindex1] = this.tempySkin;
              ++n.fistindex1;
              n.displayHammer[n.hammerindex1] = this.tempySkin;
              ++n.hammerindex1;
            }
            else
            {
              n.displayHand1[n.handindex1] = this.tempySkin;
              ++n.handindex1;
            }
            if (n.dupe[index].packType == 2)
            {
              n.displayPack1[n.packindex1] = this.tempySkin;
              ++n.packindex1;
            }
            if (n.dupe[index].headType == 1)
            {
              n.displayHelm1[n.helmetindex1] = this.tempySkin;
              ++n.helmetindex1;
            }
            if (n.dupe[index].headType == 2)
            {
              n.displayHead1[n.headindex1] = this.tempySkin;
              ++n.headindex1;
            }
            this.lastmanAlive = index;
          }
        }
      }
      if (this.chosen != -1 && this.saluteRequest)
      {
        if (n.dupe[this.chosen].emo == astroDupe.emotion.underground)
          n.dupe[this.chosen].makeSalute(true);
        else if (n.dupe[this.chosen].loc == astroDupe.where.outofTruck)
        {
          if (this.seats.Count > 0)
          {
            Vector3 zero = Vector3.Zero;
            int index1 = 0;
            float num4 = 100000f;
            for (int index2 = 0; index2 < this.seats.Count; ++index2)
            {
              Vector3 vector3 = Vector3.Transform(this.seats[index2].posoffset, astro.inDumper);
              float num5 = Vector3.Distance(n.dupe[this.chosen].mypos, vector3);
              if ((double) num5 < (double) num4)
              {
                index1 = index2;
                num4 = num5;
              }
            }
            n.dupe[this.chosen].posOffset = this.seats[index1].posoffset;
            n.dupe[this.chosen].rotOffset = this.seats[index1].rotoffset;
            this.seats.RemoveAt(index1);
            n.dupe[this.chosen].destination = Vector3.Transform(n.dupe[this.chosen].posOffset, astro.inDumper);
            this.rider.Add(this.chosen);
            n.dupe[this.chosen].makeSalute(true);
          }
          else
            n.dupe[this.chosen].makeSalute(false);
        }
      }
      this.saluteRequest = false;
      if (this.rider.Count > 0 && this.everyoneOut && this.chosen == -1)
      {
        int index = this.rider[0];
        if (n.dupe[index].loc == astroDupe.where.inTruck)
        {
          this.rider.RemoveAt(0);
          this.seats.Add(new astro.seat()
          {
            rotoffset = n.dupe[index].rotOffset,
            posoffset = n.dupe[index].posOffset
          });
          n.dupe[index].leaveTruck();
        }
      }
      this.everyoneOut = false;
    }

    public void Draw(
      Matrix view,
      Matrix proj,
      Vector3 light,
      Vector3 diff,
      Vector3 amb,
      float Yscale,
      float camradian)
    {
      if (this.man.bodyindex1 < 1 && this.man.bodyindex2 < 1)
        return;
      this.camradian = camradian;
      this.view = view;
      this.proj = proj;
      this.light = light;
      this.amb = amb;
      this.diff = diff;
      string name = "outdoors";
      if (Facility.inFacility)
        name = "indoors";
      this.man.eff = this.tintEffect;
      this.man.eff.CurrentTechnique = this.man.eff.Techniques[name];
      this.man.eff.Parameters["Scale"].SetValue(Matrix.CreateScale(1f, Yscale, 1f));
      this.man.eff.Parameters["LightDirection"].SetValue(light);
      this.man.eff.Parameters[nameof (diff)].SetValue(diff);
      this.man.eff.Parameters[nameof (amb)].SetValue(amb);
      this.man.eff.Parameters["View"].SetValue(view);
      this.man.eff.Parameters["Projection"].SetValue(proj);
      this.man.eff.CurrentTechnique.Passes[0].Apply();
      if (this.man.handindex1 > 0)
        this.DrawAstroHand(ref this.man, this.man.handindex1);
      if (this.man.fistindex1 > 0)
        this.DrawAstroFist(ref this.man, this.man.fistindex1);
      this.man.eff = this.dayEffect;
      this.man.eff.CurrentTechnique = this.man.eff.Techniques[name];
      this.man.eff.Parameters["Scale"].SetValue(Matrix.CreateScale(1f, Yscale, 1f));
      this.man.eff.Parameters["LightDirection"].SetValue(light);
      this.man.eff.Parameters[nameof (diff)].SetValue(diff);
      this.man.eff.Parameters[nameof (amb)].SetValue(amb);
      this.man.eff.Parameters["View"].SetValue(view);
      this.man.eff.Parameters["Projection"].SetValue(proj);
      this.man.eff.CurrentTechnique.Passes[0].Apply();
      if (this.man.bodyindex1 > 0)
        this.DrawAstroBody1(ref this.man, this.man.bodyindex1);
      if (this.man.bodyindex2 > 0)
        this.DrawAstroBody2(ref this.man, this.man.bodyindex2);
      if (this.man.hammerindex1 > 0)
        this.DrawAstroHammer(ref this.man, this.man.hammerindex1);
      if (this.man.helmetindex1 > 0)
        this.DrawAstroHelmet(ref this.man, this.man.helmetindex1);
      if (this.man.packindex1 > 0)
        this.DrawAstroPack(ref this.man, this.man.packindex1);
      if (this.man.headindex1 > 0)
        this.DrawAstroHead(ref this.man, this.man.headindex1);
      if (!this.sc.cheat_astro)
        return;
      this.DrawHeadQuad();
    }

    private void DrawAstroBody1(ref astro.npc n, int cc)
    {
      ModelMeshPart meshPart = n.model1.Meshes["body1"].MeshParts[0];
      n.bodybuffer1.SetData<astro.skinstream>(n.displayBody1, 0, cc, SetDataOptions.Discard);
      this._vertexBufferBindings[0] = new VertexBufferBinding(meshPart.VertexBuffer, meshPart.VertexOffset, 0);
      this._vertexBufferBindings[1] = new VertexBufferBinding((VertexBuffer) n.bodybuffer1, 0, 1);
      this.sc.GraphicsDevice.SetVertexBuffers(this._vertexBufferBindings);
      this.sc.GraphicsDevice.Indices = meshPart.IndexBuffer;
      this.sc.GraphicsDevice.DrawInstancedPrimitives(PrimitiveType.TriangleList, 0, 0, meshPart.NumVertices, meshPart.StartIndex, meshPart.PrimitiveCount, cc);
    }

    private void DrawAstroBody2(ref astro.npc n, int cc)
    {
      ModelMeshPart meshPart = n.model1.Meshes["body2"].MeshParts[0];
      n.bodybuffer2.SetData<astro.skinstream>(n.displayBody2, 0, cc, SetDataOptions.Discard);
      this._vertexBufferBindings[0] = new VertexBufferBinding(meshPart.VertexBuffer, meshPart.VertexOffset, 0);
      this._vertexBufferBindings[1] = new VertexBufferBinding((VertexBuffer) n.bodybuffer2, 0, 1);
      this.sc.GraphicsDevice.SetVertexBuffers(this._vertexBufferBindings);
      this.sc.GraphicsDevice.Indices = meshPart.IndexBuffer;
      this.sc.GraphicsDevice.DrawInstancedPrimitives(PrimitiveType.TriangleList, 0, 0, meshPart.NumVertices, meshPart.StartIndex, meshPart.PrimitiveCount, cc);
    }

    private void DrawAstroHand(ref astro.npc n, int cc)
    {
      ModelMeshPart meshPart = n.model1.Meshes["hands1"].MeshParts[0];
      n.handbuffer1.SetData<astro.skinstream>(n.displayHand1, 0, cc, SetDataOptions.Discard);
      this._vertexBufferBindings[0] = new VertexBufferBinding(meshPart.VertexBuffer, meshPart.VertexOffset, 0);
      this._vertexBufferBindings[1] = new VertexBufferBinding((VertexBuffer) n.handbuffer1, 0, 1);
      this.sc.GraphicsDevice.SetVertexBuffers(this._vertexBufferBindings);
      this.sc.GraphicsDevice.Indices = meshPart.IndexBuffer;
      this.sc.GraphicsDevice.DrawInstancedPrimitives(PrimitiveType.TriangleList, 0, 0, meshPart.NumVertices, meshPart.StartIndex, meshPart.PrimitiveCount, cc);
    }

    private void DrawAstroFist(ref astro.npc n, int cc)
    {
      ModelMeshPart meshPart = n.model1.Meshes["hands2"].MeshParts[0];
      n.fistbuffer.SetData<astro.skinstream>(n.displayFist, 0, cc, SetDataOptions.Discard);
      this._vertexBufferBindings[0] = new VertexBufferBinding(meshPart.VertexBuffer, meshPart.VertexOffset, 0);
      this._vertexBufferBindings[1] = new VertexBufferBinding((VertexBuffer) n.fistbuffer, 0, 1);
      this.sc.GraphicsDevice.SetVertexBuffers(this._vertexBufferBindings);
      this.sc.GraphicsDevice.Indices = meshPart.IndexBuffer;
      this.sc.GraphicsDevice.DrawInstancedPrimitives(PrimitiveType.TriangleList, 0, 0, meshPart.NumVertices, meshPart.StartIndex, meshPart.PrimitiveCount, cc);
    }

    private void DrawAstroHammer(ref astro.npc n, int cc)
    {
      ModelMeshPart meshPart = n.model1.Meshes["hammer1"].MeshParts[0];
      n.hammerbuffer.SetData<astro.skinstream>(n.displayHammer, 0, cc, SetDataOptions.Discard);
      this._vertexBufferBindings[0] = new VertexBufferBinding(meshPart.VertexBuffer, meshPart.VertexOffset, 0);
      this._vertexBufferBindings[1] = new VertexBufferBinding((VertexBuffer) n.hammerbuffer, 0, 1);
      this.sc.GraphicsDevice.SetVertexBuffers(this._vertexBufferBindings);
      this.sc.GraphicsDevice.Indices = meshPart.IndexBuffer;
      this.sc.GraphicsDevice.DrawInstancedPrimitives(PrimitiveType.TriangleList, 0, 0, meshPart.NumVertices, meshPart.StartIndex, meshPart.PrimitiveCount, cc);
    }

    private void DrawAstroHelmet(ref astro.npc n, int cc)
    {
      ModelMeshPart meshPart = n.model1.Meshes["helmet1"].MeshParts[0];
      n.helmbuffer1.SetData<astro.skinstream>(n.displayHelm1, 0, cc, SetDataOptions.Discard);
      this._vertexBufferBindings[0] = new VertexBufferBinding(meshPart.VertexBuffer, meshPart.VertexOffset, 0);
      this._vertexBufferBindings[1] = new VertexBufferBinding((VertexBuffer) n.helmbuffer1, 0, 1);
      this.sc.GraphicsDevice.SetVertexBuffers(this._vertexBufferBindings);
      this.sc.GraphicsDevice.Indices = meshPart.IndexBuffer;
      this.sc.GraphicsDevice.DrawInstancedPrimitives(PrimitiveType.TriangleList, 0, 0, meshPart.NumVertices, meshPart.StartIndex, meshPart.PrimitiveCount, cc);
    }

    private void DrawAstroPack(ref astro.npc n, int cc)
    {
      ModelMeshPart meshPart = n.model1.Meshes["pack1"].MeshParts[0];
      n.packbuffer4.SetData<astro.skinstream>(n.displayPack1, 0, cc, SetDataOptions.Discard);
      this._vertexBufferBindings[0] = new VertexBufferBinding(meshPart.VertexBuffer, meshPart.VertexOffset, 0);
      this._vertexBufferBindings[1] = new VertexBufferBinding((VertexBuffer) n.packbuffer4, 0, 1);
      this.sc.GraphicsDevice.SetVertexBuffers(this._vertexBufferBindings);
      this.sc.GraphicsDevice.Indices = meshPart.IndexBuffer;
      this.sc.GraphicsDevice.DrawInstancedPrimitives(PrimitiveType.TriangleList, 0, 0, meshPart.NumVertices, meshPart.StartIndex, meshPart.PrimitiveCount, cc);
    }

    private void DrawAstroHead(ref astro.npc n, int cc)
    {
      ModelMeshPart meshPart = n.model1.Meshes["head1"].MeshParts[0];
      n.headbuffer5.SetData<astro.skinstream>(n.displayHead1, 0, cc, SetDataOptions.Discard);
      this._vertexBufferBindings[0] = new VertexBufferBinding(meshPart.VertexBuffer, meshPart.VertexOffset, 0);
      this._vertexBufferBindings[1] = new VertexBufferBinding((VertexBuffer) n.headbuffer5, 0, 1);
      this.sc.GraphicsDevice.SetVertexBuffers(this._vertexBufferBindings);
      this.sc.GraphicsDevice.Indices = meshPart.IndexBuffer;
      this.sc.GraphicsDevice.DrawInstancedPrimitives(PrimitiveType.TriangleList, 0, 0, meshPart.NumVertices, meshPart.StartIndex, meshPart.PrimitiveCount, cc);
    }

    private void DrawHeadQuad()
    {
      for (int index = 0; index < this.drawOverheads.Count; ++index)
      {
        string lower1 = this.drawOverheads[index].mess1.ToLower();
        string lower2 = this.drawOverheads[index].mess2.ToLower();
        Vector3 overheadpos = this.drawOverheads[index].overheadpos;
        this.basiceffect.View = this.view;
        this.basiceffect.Projection = this.proj;
        Vector2 origin1 = this.sc.landerfont.MeasureString(lower1) / 2f;
        float scale1 = 0.25f;
        this.basiceffect.World = Matrix.CreateScale(-1f, -1f, 1f) * Matrix.CreateRotationY((float) (-(double) this.camradian - 3.1400001049041748)) * Matrix.CreateTranslation(overheadpos.X, overheadpos.Y + 95f, overheadpos.Z);
        this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, (SamplerState) null, DepthStencilState.Default, RasterizerState.CullNone, (Effect) this.basiceffect);
        this.spriteBatch.DrawString(this.sc.landerfont, lower1, Vector2.Zero, Color.White, 0.0f, origin1, scale1, SpriteEffects.None, 0.0f);
        this.spriteBatch.End();
        float scale2 = 0.18f;
        Vector2 origin2 = this.sc.landerfont.MeasureString(lower2) / 2f;
        this.basiceffect.World = Matrix.CreateScale(-1f, -1f, 1f) * Matrix.CreateRotationY((float) (-(double) this.camradian - 3.1400001049041748)) * Matrix.CreateTranslation(overheadpos.X, overheadpos.Y + 80f, overheadpos.Z);
        this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, (SamplerState) null, DepthStencilState.Default, RasterizerState.CullNone, (Effect) this.basiceffect);
        this.spriteBatch.DrawString(this.sc.landerfont, lower2, Vector2.Zero, Color.White, 0.0f, origin2, scale2, SpriteEffects.None, 0.0f);
        this.spriteBatch.End();
      }
    }

    private void drawFloorPlot(Matrix world, Texture2D tt)
    {
      this.sc.GraphicsDevice.DepthStencilState = DepthStencilState.None;
      this.sphere.Meshes[0].MeshParts[0].Effect = this.simpEffect;
      this.simpEffect.CurrentTechnique = this.simpEffect.Techniques["straight"];
      this.simpEffect.Parameters["val"].SetValue(1);
      this.simpEffect.Parameters["campos"].SetValue(this.campos);
      this.simpEffect.Parameters["modelTexture"].SetValue((Texture) tt);
      this.simpEffect.Parameters[nameof (world)].SetValue(world);
      this.simpEffect.Parameters["view"].SetValue(this.view);
      this.simpEffect.Parameters["projection"].SetValue(this.proj);
      this.simpEffect.CurrentTechnique.Passes[0].Apply();
      this.sphere.Meshes[0].Draw();
      this.sc.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
    }

    public class overhead
    {
      public Vector3 overheadpos { get; set; }

      public string mess1 { get; set; }

      public string mess2 { get; set; }
    }

    public struct seat
    {
      public Vector3 posoffset;
      public float rotoffset;
    }

    public struct skinstream : IVertexType
    {
      public Matrix Transformation;
      public float frame1;
      public float frame2;
      public float tween;
      public float tint;
      private static readonly VertexDeclaration VertexDeclaration = new VertexDeclaration(new VertexElement[8]
      {
        new VertexElement(0, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 1),
        new VertexElement(16, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 2),
        new VertexElement(32, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 3),
        new VertexElement(48, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 4),
        new VertexElement(64, VertexElementFormat.Single, VertexElementUsage.Fog, 0),
        new VertexElement(68, VertexElementFormat.Single, VertexElementUsage.Fog, 1),
        new VertexElement(72, VertexElementFormat.Single, VertexElementUsage.Fog, 2),
        new VertexElement(76, VertexElementFormat.Single, VertexElementUsage.Fog, 3)
      });

      VertexDeclaration IVertexType.VertexDeclaration => astro.skinstream.VertexDeclaration;
    }

    public struct conductor
    {
      public byte type;
      public int id;
      public byte action;
      public byte bodypart;
      public int frame;
      public int time;
      public bool died;
      public Vector3 veloc;
    }

    public struct npc
    {
      public ushort alive;
      public ushort alive2;
      public Model model1;
      public Model model2;
      public astro.skinstream[] displayBody1;
      public astro.skinstream[] displayBody2;
      public astro.skinstream[] displayHelm1;
      public astro.skinstream[] displayHand1;
      public astro.skinstream[] displayFist;
      public astro.skinstream[] displayPack1;
      public astro.skinstream[] displayHead1;
      public astro.skinstream[] displayHammer;
      public DynamicVertexBuffer bodybuffer1;
      public DynamicVertexBuffer bodybuffer2;
      public DynamicVertexBuffer helmbuffer1;
      public DynamicVertexBuffer handbuffer1;
      public DynamicVertexBuffer fistbuffer;
      public DynamicVertexBuffer packbuffer4;
      public DynamicVertexBuffer headbuffer5;
      public DynamicVertexBuffer hammerbuffer;
      public int handindex1;
      public int fistindex1;
      public int bodyindex1;
      public int bodyindex2;
      public int headindex1;
      public int helmetindex1;
      public int packindex1;
      public int hammerindex1;
      public List<int> explodelist;
      public List<int> shockList;
      public List<int> shatterList;
      public List<astroDupe> dupe;
      public List<astro.conductor> conductor;
      public int max;
      public SkinningDataX data;
      public Texture2D bitmap;
      public Texture2D texture2D_0;
      public Texture2D texture2D_1;
      public Texture2D boneTexture;
      public Texture2D charTexture;
      public Effect eff;
      public Vector3[] uv;
      public Matrix[] targ;
      public int[] bone;
      public int hitindex;
    }
  }
}
