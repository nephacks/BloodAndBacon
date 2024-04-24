using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SkinnedModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

#pragma warning disable CS0219
#pragma warning disable CS0414
#pragma warning disable CS0649
#pragma warning disable CS0169
#nullable disable
namespace Blood
{
  public class enemynpc
  {
    public Vector3 bigcolor = Vector3.One;
    public Vector3 enemypos = Vector3.Zero;
    public Vector2 destination = Vector2.Zero;
    public ushort sendTime;
    public int sendSeed = -1;
    public int lastTime;
    public int iter = -1;
    public int skullindex = -1;
    public int sendDeath = -1;
    public int localhitCount;
    public int remotehitCount;
    private enemynpc.conductor tempConduct = new enemynpc.conductor();
    public enemynpc.npcEnemy skull;
    private Vector3 bottomCorner = new Vector3(-25f, -33.77f, -36.16f);
    private Vector3 topCornernew = new Vector3(28.88f, 26.538f, 38.86f);
    private SoundEffect seen;
    private SoundEffect seen4;
    private SoundEffect enemydie;
    private Effect enemyEffect;
    private int attackWaite;
    private Random rr = new Random();
    public float[] gunDam = new float[23]
    {
      2f,
      0.0f,
      1f,
      0.0f,
      1f,
      0.0f,
      1.2f,
      0.0f,
      3f,
      0.0f,
      1.1f,
      0.0f,
      1f,
      0.0f,
      1f,
      0.0f,
      1f,
      0.0f,
      1f,
      0.0f,
      1.1f,
      0.0f,
      1.3f
    };
    public static int bitmap;
    public static float unit;
    public static float Grid;
    public bool tunnelAvoidDamage;
    public float headRot;
    public Vector3 campos;
    public Vector3 camlookpos;
    public Vector2 hitVel;
    private int timeFrame;
    private Ray cursorRay;
    private Vector3 min;
    private Vector3 max;
    private float? distCheck;
    public Matrix cubeMatrix;
    public Vector3 cubeCenter = Vector3.Zero;
    public Vector3 outside;
    public float scale;
    public Matrix skullView;
    public BoundingBox mybox;
    public Vector2 lastPlayerPos = Vector2.Zero;
    private int seenCounter;
    public bool lightON;
    public Matrix buildingMatrix;
    public int techniWorld;
    public bool tunnelDebug;
    public Texture2D ttWorld;
    public Matrix view;
    public Matrix proj;
    public Matrix matrix_0;
    private Model cube;
    private Matrix enemyProj = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(80f), 1.78f, 1f, 3000f);
    public bool bitSpray;
    public bool bloodSpray;
    public bool decalSpray;
    private readonly VertexBufferBinding[] _vertexBufferBindings = new VertexBufferBinding[2];
    public float flashlightDepth = 100f;
    private int[] handtype = new int[24]
    {
      1,
      1,
      1,
      1,
      1,
      1,
      2,
      2,
      2,
      2,
      2,
      2,
      2,
      2,
      2,
      2,
      1,
      1,
      2,
      2,
      2,
      2,
      2,
      2
    };
    public int explosiveCount;
    private List<int> parts;
    private int[] s;
    private bool enemySchedulethisFrame;
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
    private static VertexDeclaration vd = new VertexDeclaration(new VertexElement[9]
    {
      new VertexElement(0, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 1),
      new VertexElement(16, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 2),
      new VertexElement(32, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 3),
      new VertexElement(48, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 4),
      new VertexElement(64, VertexElementFormat.Single, VertexElementUsage.Fog, 0),
      new VertexElement(68, VertexElementFormat.Single, VertexElementUsage.Fog, 1),
      new VertexElement(72, VertexElementFormat.Single, VertexElementUsage.Fog, 2),
      new VertexElement(76, VertexElementFormat.Single, VertexElementUsage.Fog, 3),
      new VertexElement(80, VertexElementFormat.Single, VertexElementUsage.Fog, 4)
    });
    private enemynpc.skinstream tempySkin = new enemynpc.skinstream();
    private enemynpc.skinstream[] tempySkinArray = new enemynpc.skinstream[1];
    public Texture2D enemyTexture;
    public Texture2D enemyDeadTexture;
    public Texture2D splat2;
    public Model enemyProxy;
    public Effect eff;
    public float[] enemysphereScale;
    public Vector3[] uv;
    public Matrix[] targ;
    public int[] bone;
    public int hitindex;
    public float npcDist;
    private ScreenManager sc;
    private ContentManager cc;
    private ContentManager Content;
    private Vector3[] plot3;
    private Vector2[] enemyHome;
    private Vector2[] enemyInvade;
    private Vector2[] enemyGuard;
    private Vector2[] enemyHome1 = new Vector2[3]
    {
      new Vector2(2007.124f, 1922.5f),
      new Vector2(1632.124f, 1922.5f),
      new Vector2(3382.123f, 2047.5f)
    };
    private Vector2[] enemyInvade1 = new Vector2[2]
    {
      new Vector2(2132.124f, 4297.5f),
      new Vector2(2882.124f, 4297.5f)
    };
    private Vector2[] enemyGuard1 = new Vector2[3]
    {
      new Vector2(2757.124f, 1922.5f),
      new Vector2(2132.124f, 2297.5f),
      new Vector2(1382.124f, 3172.5f)
    };
    private Vector2[] enemyHome2 = new Vector2[2]
    {
      new Vector2(3632.123f, 2672.5f),
      new Vector2(382.124023f, 2797.5f)
    };
    private Vector2[] enemyInvade2 = new Vector2[3]
    {
      new Vector2(2882.124f, 4422.5f),
      new Vector2(2632.124f, 3672.5f),
      new Vector2(2132.124f, 4047.5f)
    };
    private Vector2[] enemyGuard2 = new Vector2[3]
    {
      new Vector2(2132.124f, 2672.5f),
      new Vector2(2257.124f, 1922.5f),
      new Vector2(1882.124f, 2672.5f)
    };
    private Vector2[] enemyHome3 = new Vector2[3]
    {
      new Vector2(4257.123f, 2047.5f),
      new Vector2(2507.124f, 2047.5f),
      new Vector2(4007.123f, 3672.5f)
    };
    private Vector2[] enemyInvade3 = new Vector2[3]
    {
      new Vector2(2132.124f, 4422.5f),
      new Vector2(1007.124f, 3172.5f),
      new Vector2(2882.124f, 4422.5f)
    };
    private Vector2[] enemyGuard3 = new Vector2[3]
    {
      new Vector2(3632.123f, 1047.5f),
      new Vector2(2257.124f, 2172.5f),
      new Vector2(3507.123f, 3172.5f)
    };
    private Vector2[] enemyHome4 = new Vector2[4]
    {
      new Vector2(2132.124f, 3172.5f),
      new Vector2(1507.124f, 1922.5f),
      new Vector2(4007.123f, 3797.5f),
      new Vector2(3757.123f, 2672.5f)
    };
    private Vector2[] enemyGuard4 = new Vector2[5]
    {
      new Vector2(1257.124f, 3547.5f),
      new Vector2(1632.124f, 1547.5f),
      new Vector2(3382.123f, 1172.5f),
      new Vector2(4382.123f, 1797.5f),
      new Vector2(882.124f, 2422.5f)
    };
    private Vector2[] enemyInvade4 = new Vector2[5]
    {
      new Vector2(2507.124f, 4547.5f),
      new Vector2(2632.124f, 3547.5f),
      new Vector2(2882.124f, 2422.5f),
      new Vector2(2882.124f, 4422.5f),
      new Vector2(2882.124f, 2797.5f)
    };
    private int mazeid = -1;

    public enemynpc(ScreenManager sc, ContentManager cc, int mazeid, ref float[,] tunnelheights)
    {
      this.sc = sc;
      this.Content = cc;
      this.mazeid = mazeid;
      this.enemyProxy = this.Content.Load<Model>("models//enemyProxy3");
      this.enemyTexture = this.Content.Load<Texture2D>("texture//enemyTexture2");
      this.enemyDeadTexture = this.Content.Load<Texture2D>("texture//enemyTexture4");
      this.splat2 = this.Content.Load<Texture2D>("texture\\splat2");
      this.seen = this.Content.Load<SoundEffect>("audio//seen3");
      this.seen4 = this.Content.Load<SoundEffect>("audio//seen4");
      this.enemydie = this.Content.Load<SoundEffect>("audio//enemyDie1");
      this.cube = this.Content.Load<Model>("models//cube");
      this.parts = new List<int>(5);
      this.s = new int[5];
      this.enemyInstancing();
      if (mazeid == 0)
      {
        this.enemyHome = this.enemyHome1;
        this.enemyGuard = this.enemyGuard1;
        this.enemyInvade = this.enemyInvade1;
      }
      if (mazeid == 1)
      {
        this.enemyHome = this.enemyHome1;
        this.enemyGuard = this.enemyGuard1;
        this.enemyInvade = this.enemyInvade1;
      }
      if (mazeid == 2)
      {
        this.enemyHome = this.enemyHome2;
        this.enemyGuard = this.enemyGuard2;
        this.enemyInvade = this.enemyInvade2;
      }
      if (mazeid == 3)
      {
        this.enemyHome = this.enemyHome3;
        this.enemyGuard = this.enemyGuard3;
        this.enemyInvade = this.enemyInvade3;
      }
      if (mazeid == 4)
      {
        this.enemyHome = this.enemyHome4;
        this.enemyGuard = this.enemyGuard4;
        this.enemyInvade = this.enemyInvade4;
      }
      this.makeSkulls();
      this.setSkullDifficulty();
      this.readGPSpaths(ref tunnelheights);
      for (int index1 = 0; index1 < this.skull.dupe.Count; ++index1)
      {
        Array.Resize<Vector3>(ref this.skull.dupe[index1].skelPath3, 3);
        for (int index2 = 0; index2 < 3; ++index2)
          this.skull.dupe[index1].skelPath3[index2] = this.skull.dupe[index1].enemypos;
        this.skull.dupe[index1].skelIndex = 0;
        this.skull.dupe[index1].skelInc = 0.0f;
        int index3 = this.skull.dupe[index1].skelIndex + 1;
        this.skull.dupe[index1].skelPos1 = this.skull.dupe[index1].skelPath3[this.skull.dupe[index1].skelIndex];
        this.skull.dupe[index1].skelPos2 = this.skull.dupe[index1].skelPath3[index3];
        this.skull.dupe[index1].skelStep = (float) (0.00279999990016222 / ((double) Vector3.Distance(this.skull.dupe[index1].skelPos1, this.skull.dupe[index1].skelPos2) / (double) this.skull.dupe[index1].skelOrigRate));
      }
    }

    public void Update1(
      ref Cursor cursor,
      ref Cursor genCursor,
      ref localPlayer myPlayer,
      ref Vector2 hitVel,
      ref float camshaker,
      ref float[,] th,
      ref float[,] fh,
      List<BloodnBacon.myDoor> combo,
      List<BloodnBacon.myDoor> plain)
    {
      this.bitSpray = false;
      this.decalSpray = false;
      this.bloodSpray = false;
      if (this.skull.dupe.Count <= 0)
        return;
      this.updateEnemySkull1(ref this.skull, ref th, ref fh, ref genCursor, ref myPlayer, combo, plain);
      this.splatEnemySkull(ref this.skull, ref cursor, ref genCursor, ref myPlayer, ref hitVel, ref camshaker);
    }

    public void Update2(
      ref Cursor cursor,
      ref Cursor genCursor,
      ref localPlayer myPlayer,
      ref Vector2 hitVel,
      ref float camshaker,
      ref float[,] th,
      ref float[,] fh,
      List<BloodnBacon4PT.myDoor> combo,
      List<BloodnBacon4PT.myDoor> plain)
    {
      this.bitSpray = false;
      this.decalSpray = false;
      this.bloodSpray = false;
      if (this.skull.dupe.Count <= 0)
        return;
      this.updateEnemySkull2(ref this.skull, ref th, ref fh, ref genCursor, ref myPlayer, combo, plain);
      this.splatEnemySkull(ref this.skull, ref cursor, ref genCursor, ref myPlayer, ref hitVel, ref camshaker);
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

    public void enemyInstancing()
    {
      this.skull = new enemynpc.npcEnemy();
      this.skull.hitindex = -1;
      this.skull.alive = 0;
      this.skull.alive2 = 666;
      this.skull.data = this.enemyProxy.Tag as SkinningDataX;
      this.makeImage(this.skull.data.Bones, this.skull.data.Width, this.skull.data.Hite, ref this.skull.bitmap);
      this.skull.Texture1 = this.enemyTexture;
      this.skull.model1 = this.enemyProxy;
      this.skull.max = 5;
      this.skull.dupe = new List<enemyDupe>(this.skull.max);
      this.skull.dupe.Capacity = 5;
      this.skull.display1 = new enemynpc.skinstream[this.skull.max];
      this.skull.buffer1 = new DynamicVertexBuffer(this.sc.GraphicsDevice, enemynpc.vd, this.skull.max, BufferUsage.WriteOnly);
      this.skull.targ = new Matrix[6];
      this.skull.targ[0] = Matrix.CreateTranslation(new Vector3(1.15f, -8.9f, 20.45f));
      this.skull.targ[1] = Matrix.CreateTranslation(new Vector3(0.5f, -21f, -25.6f));
      this.skull.targ[2] = Matrix.CreateTranslation(new Vector3(-6.4f, -17.11f, -6.5f));
      this.skull.targ[3] = Matrix.CreateTranslation(new Vector3(7.2f, -16.8f, -7f));
      this.skull.targ[4] = Matrix.CreateTranslation(new Vector3(-16.46f, 8.33f, 22.675f));
      this.skull.targ[5] = Matrix.CreateTranslation(new Vector3(17.5f, 8.7f, 23.56f));
      this.skull.bone = new int[6]{ 1, 4, 1, 1, 1, 1 };
      this.enemysphereScale = new float[6]
      {
        54.7f,
        24.5f,
        25.6f,
        25.6f,
        22f,
        24f
      };
      this.enemyEffect = this.Content.Load<Effect>("effects\\Effectenemy1");
      this.skull.eff = this.enemyEffect;
      this.skull.uv = new Vector3[9];
      this.skull.uv[0] = new Vector3(0.01f, 0.01f, 10f);
      this.skull.uv[1] = new Vector3(0.504f, 0.0730000138f, 1f);
      this.skull.uv[2] = new Vector3(0.397f, 0.287f, 1f);
      this.skull.uv[3] = new Vector3(0.611f, 0.287f, 1f);
      this.skull.uv[4] = new Vector3(0.397f, 0.439f, 1f);
      this.skull.uv[5] = new Vector3(0.649f, 0.439f, 1f);
      this.skull.uv[6] = new Vector3(0.343f, 0.856f, 1f);
      this.skull.uv[7] = new Vector3(0.19f, 0.29400003f, 1f);
      this.skull.uv[8] = new Vector3(0.814f, 0.29400003f, 1f);
      for (int index = 0; index < this.skull.uv.Length; ++index)
        this.skull.eff.Parameters["v" + index.ToString()].SetValue(this.skull.uv[index]);
      this.skull.eff.Parameters["BoneDelta"].SetValue(1f / (float) this.skull.data.Width);
      this.skull.eff.Parameters["RowDelta"].SetValue(1f / (float) this.skull.data.Hite);
      this.skull.eff.Parameters["AnimationTexture"].SetValue((Texture) this.skull.bitmap);
      this.skull.eff.Parameters["hole1"].SetValue((Texture) this.splat2);
      this.skull.eff.Parameters["Texture"].SetValue((Texture) this.skull.Texture1);
      this.skull.eff.Parameters["Texture2"].SetValue((Texture) this.enemyDeadTexture);
      this.skull.npcDist = 20000f;
      enemyDupe.sics = new List<int>(2 * (this.skull.data.Clips.Length + 1));
      enemyDupe.sics.Add(this.skull.data.Clips[0]);
      enemyDupe.sics.Add(0);
      for (int index = 1; index < this.skull.data.Clips.Length; ++index)
      {
        enemyDupe.sics.Add(this.skull.data.Clips[index] - this.skull.data.Clips[index - 1]);
        enemyDupe.sics.Add(this.skull.data.Clips[index - 1]);
      }
    }

    public void addEnemyBlood(ref enemynpc.npcEnemy n, int i, int bodypart)
    {
      int blood = n.dupe[i].blood;
      this.parts.Clear();
      this.s[4] = blood / 100000;
      this.s[3] = blood % 100000 / 10000;
      this.s[2] = blood % 10000 / 1000;
      this.s[1] = blood % 1000 / 100;
      this.s[0] = blood % 100 / 10;
      this.parts.Add(this.s[0]);
      this.parts.Add(this.s[1]);
      this.parts.Add(this.s[2]);
      this.parts.Add(this.s[3]);
      this.parts.Add(this.s[4]);
      if (this.parts.Contains(bodypart))
        return;
      this.s[n.dupe[i].splatIndex] = bodypart;
      n.dupe[i].blood = this.s[4] * 100000 + this.s[3] * 10000 + this.s[2] * 1000 + this.s[1] * 100 + this.s[0] * 10 + 6;
      ++n.dupe[i].splatIndex;
      if (n.dupe[i].splatIndex <= 4)
        return;
      n.dupe[i].splatIndex = 0;
    }

    private Matrix RotateToFaceE(
      Vector3 O,
      Vector3 P,
      Vector3 U,
      Matrix mm,
      ref bool turning,
      Matrix tilt)
    {
      if ((double) Vector3.Distance(O, P) < 5.0)
        return mm;
      Vector3 vector2 = O - P;
      Vector3 result1 = Vector3.Cross(U, vector2);
      Vector3.Normalize(ref result1, out result1);
      Vector3 result2 = Vector3.Cross(result1, U);
      Vector3.Normalize(ref result2, out result2);
      Vector3 vector3 = Vector3.Cross(result2, result1);
      Matrix matrix = new Matrix(result1.X, result1.Y, result1.Z, 0.0f, vector3.X, vector3.Y, vector3.Z, 0.0f, result2.X, result2.Y, result2.Z, 0.0f, 0.0f, 0.0f, 0.0f, 1f);
      Quaternion fromRotationMatrix1 = Quaternion.CreateFromRotationMatrix(mm);
      Quaternion fromRotationMatrix2 = Quaternion.CreateFromRotationMatrix(tilt * matrix);
      if ((double) Math.Abs(fromRotationMatrix2.W - fromRotationMatrix1.W) <= 0.20000000298023224 && (double) fromRotationMatrix1.X == (double) fromRotationMatrix2.X && (double) fromRotationMatrix1.Y == (double) fromRotationMatrix2.Y && (double) fromRotationMatrix1.Z == (double) fromRotationMatrix2.Z)
        return mm;
      Matrix fromQuaternion = Matrix.CreateFromQuaternion(Quaternion.Lerp(fromRotationMatrix1, fromRotationMatrix2, 0.12f));
      turning = true;
      return fromQuaternion;
    }

    private void readGPSpaths(ref float[,] tunnelheights)
    {
      string str = this.mazeid.ToString();
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      StreamReader streamReader = new StreamReader("Content/gpspath/maze" + str + ".txt");
      int newSize = 0;
      this.plot3 = new Vector3[2100];
      while (!streamReader.EndOfStream)
      {
        float x = Convert.ToSingle(streamReader.ReadLine(), (IFormatProvider) invariantCulture) + 3000f;
        float z = Convert.ToSingle(streamReader.ReadLine(), (IFormatProvider) invariantCulture) + 3000f;
        float height = 0.0f;
        this.GetHeightFast(ref tunnelheights, new Vector3(x, 0.0f, z), ref height);
        this.plot3[newSize] = new Vector3(x, height, z);
        ++newSize;
      }
      Array.Resize<Vector3>(ref this.plot3, newSize);
      streamReader.Close();
      streamReader.Dispose();
    }

    public void makeSkulls()
    {
      int h = 10;
      if (this.mazeid == 1)
      {
        Vector3 startpos = new Vector3(this.enemyHome[0].X, -242f, this.enemyHome[0].Y);
        this.skull.dupe.Add(new enemyDupe(0, 0, startpos, 1, 1, this.timeFrame, this.sc, 160));
        this.skull.dupe[0].myhome = this.enemyHome[0];
        this.skull.dupe[0].enemySound = this.Content.Load<SoundEffect>("audio\\enemySound3").CreateInstance();
        this.skull.dupe[0].enemySound.IsLooped = true;
        this.skull.dupe[0].enemySound.Volume = 0.0f;
        this.skull.dupe[0].enemySound.Apply3D(this.skull.dupe[0].audiolistener, this.skull.dupe[0].audioemitter);
        this.skull.dupe[0].enemySound.Play();
        startpos = new Vector3(this.enemyHome[2].X, -242f, this.enemyHome[2].Y);
        this.skull.dupe.Add(new enemyDupe(0, 0, startpos, 1, 1, this.timeFrame, this.sc, 220));
        this.skull.dupe[1].myhome = this.enemyHome[2];
        this.skull.dupe[1].enemySound = this.Content.Load<SoundEffect>("audio\\enemySound6").CreateInstance();
        this.skull.dupe[1].enemySound.IsLooped = true;
        this.skull.dupe[1].enemySound.Volume = 0.0f;
        this.skull.dupe[1].enemySound.Apply3D(this.skull.dupe[0].audiolistener, this.skull.dupe[0].audioemitter);
        this.skull.dupe[1].enemySound.Play();
      }
      if (this.mazeid == 2)
      {
        Vector3 startpos = new Vector3(this.enemyHome[0].X, -242f, this.enemyHome[0].Y);
        this.skull.dupe.Add(new enemyDupe(0, 0, startpos, 1, 1, this.timeFrame, this.sc, 210));
        this.skull.dupe[0].enemySound = this.Content.Load<SoundEffect>("audio\\enemySound3").CreateInstance();
        this.skull.dupe[0].myhome = this.enemyHome[0];
        this.skull.dupe[0].enemySound.IsLooped = true;
        this.skull.dupe[0].enemySound.Volume = 0.0f;
        this.skull.dupe[0].enemySound.Apply3D(this.skull.dupe[0].audiolistener, this.skull.dupe[0].audioemitter);
        this.skull.dupe[0].enemySound.Play();
        startpos = new Vector3(this.enemyHome[1].X, -242f, this.enemyHome[1].Y);
        this.skull.dupe.Add(new enemyDupe(0, 0, startpos, 1, 1, this.timeFrame, this.sc, 310));
        this.skull.dupe[1].myhome = this.enemyHome[1];
        this.skull.dupe[1].enemySound = this.Content.Load<SoundEffect>("audio\\enemySound5").CreateInstance();
        this.skull.dupe[1].enemySound.IsLooped = true;
        this.skull.dupe[1].enemySound.Volume = 0.0f;
        this.skull.dupe[1].enemySound.Apply3D(this.skull.dupe[0].audiolistener, this.skull.dupe[0].audioemitter);
        this.skull.dupe[1].enemySound.Play();
      }
      if (this.mazeid == 3)
      {
        Vector3 startpos = new Vector3(this.enemyHome[0].X, -242f, this.enemyHome[0].Y);
        this.skull.dupe.Add(new enemyDupe(0, 0, startpos, 1, 1, this.timeFrame, this.sc, 220));
        this.skull.dupe[0].myhome = this.enemyHome[0];
        this.skull.dupe[0].enemySound = this.Content.Load<SoundEffect>("audio\\enemySound2a").CreateInstance();
        this.skull.dupe[0].enemySound.IsLooped = true;
        this.skull.dupe[0].enemySound.Volume = 0.0f;
        this.skull.dupe[0].enemySound.Apply3D(this.skull.dupe[0].audiolistener, this.skull.dupe[0].audioemitter);
        this.skull.dupe[0].enemySound.Play();
        startpos = new Vector3(this.enemyHome[2].X, -242f, this.enemyHome[2].Y);
        this.skull.dupe.Add(new enemyDupe(0, 0, startpos, 1, 1, this.timeFrame, this.sc, 270));
        this.skull.dupe[1].myhome = this.enemyHome[2];
        this.skull.dupe[1].enemySound = this.rr.Next(1, 100) <= 60 ? this.Content.Load<SoundEffect>("audio\\enemySound2b").CreateInstance() : this.Content.Load<SoundEffect>("audio\\enemySound2").CreateInstance();
        this.skull.dupe[1].enemySound.IsLooped = true;
        this.skull.dupe[1].enemySound.Volume = 0.0f;
        this.skull.dupe[1].enemySound.Apply3D(this.skull.dupe[0].audiolistener, this.skull.dupe[0].audioemitter);
        this.skull.dupe[1].enemySound.Play();
      }
      if (this.mazeid != 4)
        return;
      Vector3 startpos1 = new Vector3(this.enemyHome[0].X, -242f, this.enemyHome[0].Y);
      this.skull.dupe.Add(new enemyDupe(0, 0, startpos1, 1, 1, this.timeFrame, this.sc, h));
      this.skull.dupe[0].myhome = this.enemyHome[0];
      this.skull.dupe[0].enemySound = this.Content.Load<SoundEffect>("audio\\enemySound2a").CreateInstance();
      this.skull.dupe[0].enemySound.IsLooped = true;
      this.skull.dupe[0].enemySound.Volume = 0.0f;
      this.skull.dupe[0].enemySound.Apply3D(this.skull.dupe[0].audiolistener, this.skull.dupe[0].audioemitter);
      this.skull.dupe[0].enemySound.Play();
      startpos1 = new Vector3(this.enemyHome[1].X, -242f, this.enemyHome[1].Y);
      this.skull.dupe.Add(new enemyDupe(0, 0, startpos1, 1, 1, this.timeFrame, this.sc, h));
      this.skull.dupe[1].myhome = this.enemyHome[1];
      this.skull.dupe[1].enemySound = this.Content.Load<SoundEffect>("audio\\enemySound5").CreateInstance();
      this.skull.dupe[1].enemySound.IsLooped = true;
      this.skull.dupe[1].enemySound.Volume = 0.0f;
      this.skull.dupe[1].enemySound.Apply3D(this.skull.dupe[1].audiolistener, this.skull.dupe[1].audioemitter);
      this.skull.dupe[1].enemySound.Play();
      startpos1 = new Vector3(this.enemyHome[2].X, -242f, this.enemyHome[2].Y);
      this.skull.dupe.Add(new enemyDupe(0, 0, startpos1, 1, 1, this.timeFrame, this.sc, h));
      this.skull.dupe[2].myhome = this.enemyHome[2];
      this.skull.dupe[2].enemySound = this.Content.Load<SoundEffect>("audio\\enemySound6").CreateInstance();
      this.skull.dupe[2].enemySound.IsLooped = true;
      this.skull.dupe[2].enemySound.Volume = 0.0f;
      this.skull.dupe[2].enemySound.Apply3D(this.skull.dupe[2].audiolistener, this.skull.dupe[2].audioemitter);
      this.skull.dupe[2].enemySound.Play();
      startpos1 = new Vector3(this.enemyHome[3].X, -242f, this.enemyHome[3].Y);
      this.skull.dupe.Add(new enemyDupe(0, 0, startpos1, 1, 1, this.timeFrame, this.sc, h));
      this.skull.dupe[3].myhome = this.enemyHome[3];
      this.skull.dupe[3].enemySound = this.Content.Load<SoundEffect>("audio\\enemySound2b").CreateInstance();
      this.skull.dupe[3].enemySound.IsLooped = true;
      this.skull.dupe[3].enemySound.Volume = 0.0f;
      this.skull.dupe[3].enemySound.Apply3D(this.skull.dupe[3].audiolistener, this.skull.dupe[3].audioemitter);
      this.skull.dupe[3].enemySound.Play();
    }

    public void setSkullDifficulty()
    {
      int num1 = 0;
      int num2 = 2;
      int num3 = 5;
      int num4 = 6;
      int num5 = 8;
      int num6 = 300;
      int[] numArray = new int[3]{ 10, 90, 160 };
      float num7 = new float[3]{ 1.3f, 2.4f, 3.5f }[this.sc.df];
      if (this.sc.totalPlayers > 2)
      {
        num7 = new float[3]{ 2f, 3.5f, 5.2f }[this.sc.df];
        numArray = new int[3]{ 20, 110, 180 };
      }
      if (this.mazeid == 1)
      {
        this.skull.dupe[0].health = (float) (120 + numArray[this.sc.df]);
        this.skull.dupe[0].tint = (float) num4;
        this.skull.dupe[0].scale = 1.25f;
        this.skull.dupe[0].attackAgain = 10;
        this.skull.dupe[0].attackAgainOrig = 10;
        this.skull.dupe[0].skelOrigRate = (float) (650 + num6);
        this.skull.dupe[0].skelFastRate = this.skull.dupe[0].skelOrigRate * num7;
        this.skull.dupe[0].health = (float) (130 + numArray[this.sc.df]);
        this.skull.dupe[1].tint = (float) num2;
        this.skull.dupe[1].scale = 0.8f;
        this.skull.dupe[1].attackAgain = 10;
        this.skull.dupe[1].attackAgainOrig = 10;
        this.skull.dupe[1].skelOrigRate = (float) (550 + num6);
        this.skull.dupe[1].skelFastRate = this.skull.dupe[1].skelOrigRate * num7;
      }
      if (this.mazeid == 2)
      {
        this.skull.dupe[0].health = (float) (210 + numArray[this.sc.df]);
        this.skull.dupe[0].tint = (float) num4;
        this.skull.dupe[0].scale = 1.25f;
        this.skull.dupe[0].attackAgain = 10;
        this.skull.dupe[0].attackAgainOrig = 10;
        this.skull.dupe[0].skelOrigRate = (float) (650 + num6);
        this.skull.dupe[0].skelFastRate = this.skull.dupe[0].skelOrigRate * num7;
        this.skull.dupe[1].health = (float) (200 + numArray[this.sc.df]);
        this.skull.dupe[1].tint = (float) num1;
        this.skull.dupe[1].scale = 0.95f;
        this.skull.dupe[1].attackAgain = 10;
        this.skull.dupe[1].attackAgainOrig = 10;
        this.skull.dupe[1].skelOrigRate = (float) (600 + num6);
        this.skull.dupe[1].skelFastRate = this.skull.dupe[1].skelOrigRate * num7;
      }
      if (this.mazeid == 3)
      {
        this.skull.dupe[0].health = (float) (210 + numArray[this.sc.df]);
        this.skull.dupe[0].tint = (float) num4;
        this.skull.dupe[0].scale = 1f;
        this.skull.dupe[0].attackAgain = 1;
        this.skull.dupe[0].attackAgainOrig = 1;
        this.skull.dupe[0].skelOrigRate = (float) (650 + num6);
        this.skull.dupe[0].skelFastRate = this.skull.dupe[0].skelOrigRate * num7;
        this.skull.dupe[1].health = (float) (220 + numArray[this.sc.df]);
        this.skull.dupe[1].tint = (float) num3;
        this.skull.dupe[1].scale = 0.95f;
        this.skull.dupe[1].attackAgain = 1;
        this.skull.dupe[1].attackAgainOrig = 1;
        this.skull.dupe[1].skelOrigRate = (float) (600 + num6);
        this.skull.dupe[1].skelFastRate = this.skull.dupe[1].skelOrigRate * num7;
      }
      if (this.mazeid != 4)
        return;
      this.skull.dupe[0].health = (float) (130 + numArray[this.sc.df]);
      this.skull.dupe[0].tint = (float) num4;
      this.skull.dupe[0].scale = 1f;
      this.skull.dupe[0].attackAgain = 0;
      this.skull.dupe[0].attackAgainOrig = 0;
      this.skull.dupe[0].skelOrigRate = (float) (650 + num6);
      this.skull.dupe[0].skelFastRate = this.skull.dupe[0].skelOrigRate * num7;
      this.skull.dupe[1].health = (float) (150 + numArray[this.sc.df]);
      this.skull.dupe[1].tint = (float) num1;
      this.skull.dupe[1].scale = 0.95f;
      this.skull.dupe[1].attackAgain = 0;
      this.skull.dupe[1].attackAgainOrig = 0;
      this.skull.dupe[1].skelOrigRate = (float) (600 + num6);
      this.skull.dupe[1].skelFastRate = this.skull.dupe[1].skelOrigRate * num7;
      this.skull.dupe[2].health = (float) (180 + numArray[this.sc.df]);
      this.skull.dupe[2].tint = (float) num5;
      this.skull.dupe[2].scale = 0.8f;
      this.skull.dupe[2].attackAgain = 0;
      this.skull.dupe[2].attackAgainOrig = 0;
      this.skull.dupe[2].skelOrigRate = (float) (890 + num6);
      this.skull.dupe[2].skelFastRate = this.skull.dupe[2].skelOrigRate * num7;
      this.skull.dupe[3].health = (float) (200 + numArray[this.sc.df]);
      this.skull.dupe[3].tint = (float) num3;
      this.skull.dupe[3].scale = 1.4f;
      this.skull.dupe[3].attackAgain = 0;
      this.skull.dupe[3].attackAgainOrig = 0;
      this.skull.dupe[3].skelOrigRate = (float) (1100 + num6);
      this.skull.dupe[3].skelFastRate = this.skull.dupe[3].skelOrigRate * num7;
    }

    public void updateEnemySkull1(
      ref enemynpc.npcEnemy n,
      ref float[,] tunnelheights,
      ref float[,] farmheights,
      ref Cursor genCursor,
      ref localPlayer myPlayer,
      List<BloodnBacon.myDoor> combo,
      List<BloodnBacon.myDoor> plain)
    {
      n.alive = 0;
      n.index1 = 0;
      --this.seenCounter;
      for (int index1 = 0; index1 < n.dupe.Count; ++index1)
      {
        if (n.dupe[index1].move > 0 && !n.dupe[index1].death)
          ++n.alive;
        if (n.dupe[index1].death)
        {
          if (n.dupe[index1].move > 0)
          {
            n.dupe[index1].UpdateDeath(ref tunnelheights);
            n.dupe[index1].enemySound.Volume = 0.0f;
            n.dupe[index1].mypos = n.dupe[index1].enemypos + new Vector3(0.0f, n.dupe[index1].hoff, 0.0f);
            n.dupe[index1].myRot2 = n.dupe[index1].skelRot;
            n.dupe[index1].transform = Matrix.CreateScale(n.dupe[index1].scale) * n.dupe[index1].myRot2 * Matrix.CreateTranslation(n.dupe[index1].mypos);
            this.tempySkin.Transformation = n.dupe[index1].transform;
            this.tempySkin.tween = n.dupe[index1].tween;
            this.tempySkin.frame1 = (float) n.dupe[index1].frame1;
            this.tempySkin.frame2 = (float) n.dupe[index1].frame2;
            this.tempySkin.blood = (float) n.dupe[index1].blood;
            this.tempySkin.tint = n.dupe[index1].tint + n.dupe[index1].dying;
            n.display1[n.index1] = this.tempySkin;
            ++n.index1;
            if (n.alive2 == index1 && (double) n.dupe[index1].enemypos.Y < -250.0)
            {
              if (this.sc.goldKeys.keyTusk1 && this.sc.tusk1 == 0 && this.mazeid == 1)
                this.sc.goldKeys.keyTusk1 = false;
              if (this.sc.goldKeys.keyTusk2 && this.sc.tusk2 == 0 && this.mazeid == 2)
                this.sc.goldKeys.keyTusk2 = false;
              if (this.sc.goldKeys.keyTusk3 && this.sc.tusk3 == 0 && this.mazeid == 4)
                this.sc.goldKeys.keyTusk3 = false;
            }
          }
        }
        else
        {
          n.dupe[index1].skelInc += n.dupe[index1].skelStep;
          if ((double) n.dupe[index1].skelInc > 1.0)
          {
            n.dupe[index1].skelInc = 0.0f;
            ++n.dupe[index1].skelIndex;
            bool flag = true;
            int index2 = n.dupe[index1].skelIndex + 1;
            if (index2 > n.dupe[index1].skelPath3.Length - 1)
            {
              index2 = 0;
              this.findenemyDestination(ref n, index1, ref this.enemyGuard, ref this.enemyInvade);
              flag = false;
            }
            if (flag)
            {
              n.dupe[index1].skelPos1 = n.dupe[index1].skelPath3[n.dupe[index1].skelIndex];
              n.dupe[index1].skelPos2 = n.dupe[index1].skelPath3[index2];
              n.dupe[index1].skelStepTimer = 0;
            }
          }
          n.dupe[index1].skelPos = Vector3.Lerp(n.dupe[index1].skelPos1, n.dupe[index1].skelPos2, n.dupe[index1].skelInc);
          Matrix rotationX = Matrix.CreateRotationX((float) Math.Atan(((double) n.dupe[index1].skelPos2.Y - (double) n.dupe[index1].skelPos1.Y) / 125.0));
          n.dupe[index1].skelRot = this.RotateToFaceE(n.dupe[index1].skelPos, n.dupe[index1].skelPos2, Vector3.Up, n.dupe[index1].skelRot, ref n.dupe[index1].enemyisTurning, rotationX);
          Vector3 enemypos = n.dupe[index1].enemypos;
          n.dupe[index1].enemypos = n.dupe[index1].skelPos;
          if (!n.dupe[index1].enemySound.IsDisposed)
          {
            float num = 1f - MathHelper.Clamp((float) (((double) Vector3.Distance(this.campos, n.dupe[index1].enemypos) - 250.0) / 1100.0), 0.0f, 1f);
            n.dupe[index1].enemySound.Volume = num * this.sc.ev;
            n.dupe[index1].audioemitter.Position = n.dupe[index1].mypos;
            n.dupe[index1].audiolistener.Position = this.campos;
            n.dupe[index1].audiolistener.Forward = Vector3.Transform(new Vector3(0.0f, 0.0f, 1f), Matrix.CreateRotationY(myPlayer.displayState.npcRotation));
            n.dupe[index1].enemySound.Apply3D(n.dupe[index1].audiolistener, n.dupe[index1].audioemitter);
          }
          if ((double) this.sc.myTimer % 3.0 == 0.0)
            this.UpdatePickingEnemyDoors(this.enemyProj, Matrix.CreateLookAt(new Vector3(n.dupe[index1].skelPos1.X, n.dupe[index1].skelPos1.Y + 45f, n.dupe[index1].skelPos1.Z), new Vector3(n.dupe[index1].skelPos2.X, n.dupe[index1].skelPos2.Y + 45f, n.dupe[index1].skelPos2.Z), Vector3.Up), ref genCursor, ref n, index1, combo, plain);
          if (n.dupe[index1].enemyBlocked)
          {
            n.dupe[index1].enemypos = enemypos;
            this.findenemyDestination(ref n, index1, ref this.enemyGuard, ref this.enemyInvade);
            n.dupe[index1].enemyBlocked = false;
          }
          n.dupe[index1].UpdateNormal(ref tunnelheights);
          n.dupe[index1].mypos = n.dupe[index1].enemypos + new Vector3(0.0f, n.dupe[index1].hoff, 0.0f);
          n.dupe[index1].myRot2 = n.dupe[index1].skelRot;
          n.dupe[index1].transform = Matrix.CreateScale(n.dupe[index1].scale) * n.dupe[index1].myRot2 * Matrix.CreateTranslation(n.dupe[index1].mypos);
          this.tempySkin.Transformation = n.dupe[index1].transform;
          this.tempySkin.tween = n.dupe[index1].tween;
          this.tempySkin.frame1 = (float) n.dupe[index1].frame1;
          this.tempySkin.frame2 = (float) n.dupe[index1].frame2;
          this.tempySkin.blood = (float) n.dupe[index1].blood;
          this.tempySkin.tint = n.dupe[index1].tint;
          n.display1[n.index1] = this.tempySkin;
          ++n.index1;
        }
      }
    }

    public void updateEnemySkull2(
      ref enemynpc.npcEnemy n,
      ref float[,] tunnelheights,
      ref float[,] farmheights,
      ref Cursor genCursor,
      ref localPlayer myPlayer,
      List<BloodnBacon4PT.myDoor> combo,
      List<BloodnBacon4PT.myDoor> plain)
    {
      n.alive = 0;
      n.index1 = 0;
      --this.seenCounter;
      for (int index1 = 0; index1 < n.dupe.Count; ++index1)
      {
        if (n.dupe[index1].move > 0 && !n.dupe[index1].death)
          ++n.alive;
        if (n.dupe[index1].death)
        {
          if (n.dupe[index1].move > 0)
          {
            n.dupe[index1].UpdateDeath(ref tunnelheights);
            n.dupe[index1].enemySound.Volume = 0.0f;
            n.dupe[index1].mypos = n.dupe[index1].enemypos + new Vector3(0.0f, n.dupe[index1].hoff, 0.0f);
            n.dupe[index1].myRot2 = n.dupe[index1].skelRot;
            n.dupe[index1].transform = Matrix.CreateScale(n.dupe[index1].scale) * n.dupe[index1].myRot2 * Matrix.CreateTranslation(n.dupe[index1].mypos);
            this.tempySkin.Transformation = n.dupe[index1].transform;
            this.tempySkin.tween = n.dupe[index1].tween;
            this.tempySkin.frame1 = (float) n.dupe[index1].frame1;
            this.tempySkin.frame2 = (float) n.dupe[index1].frame2;
            this.tempySkin.blood = (float) n.dupe[index1].blood;
            this.tempySkin.tint = n.dupe[index1].tint + n.dupe[index1].dying;
            n.display1[n.index1] = this.tempySkin;
            ++n.index1;
            if (n.alive2 == index1 && (double) n.dupe[index1].enemypos.Y < -250.0)
            {
              if (this.sc.goldKeys.keyTusk1 && this.sc.tusk1 == 0 && this.mazeid == 1)
                this.sc.goldKeys.keyTusk1 = false;
              if (this.sc.goldKeys.keyTusk2 && this.sc.tusk2 == 0 && this.mazeid == 2)
                this.sc.goldKeys.keyTusk2 = false;
              if (this.sc.goldKeys.keyTusk3 && this.sc.tusk3 == 0 && this.mazeid == 4)
                this.sc.goldKeys.keyTusk3 = false;
            }
          }
        }
        else
        {
          n.dupe[index1].skelInc += n.dupe[index1].skelStep;
          if ((double) n.dupe[index1].skelInc > 1.0)
          {
            n.dupe[index1].skelInc = 0.0f;
            ++n.dupe[index1].skelIndex;
            bool flag = true;
            int index2 = n.dupe[index1].skelIndex + 1;
            if (index2 > n.dupe[index1].skelPath3.Length - 1)
            {
              if (this.sc.host)
              {
                index2 = 0;
                this.findenemyDestination(ref n, index1, ref this.enemyGuard, ref this.enemyInvade);
                flag = false;
              }
              else
              {
                n.dupe[index1].skelIndex = n.dupe[index1].skelPath3.Length - 2;
                n.dupe[index1].skelInc = 1f;
                flag = false;
              }
            }
            if (flag)
            {
              n.dupe[index1].skelPos1 = n.dupe[index1].skelPath3[n.dupe[index1].skelIndex];
              n.dupe[index1].skelPos2 = n.dupe[index1].skelPath3[index2];
              n.dupe[index1].skelStepTimer = 0;
            }
          }
          n.dupe[index1].skelPos = Vector3.Lerp(n.dupe[index1].skelPos1, n.dupe[index1].skelPos2, n.dupe[index1].skelInc);
          Matrix rotationX = Matrix.CreateRotationX((float) Math.Atan(((double) n.dupe[index1].skelPos2.Y - (double) n.dupe[index1].skelPos1.Y) / 125.0));
          n.dupe[index1].skelRot = this.RotateToFaceE(n.dupe[index1].skelPos, n.dupe[index1].skelPos2, Vector3.Up, n.dupe[index1].skelRot, ref n.dupe[index1].enemyisTurning, rotationX);
          Vector3 enemypos = n.dupe[index1].enemypos;
          n.dupe[index1].enemypos = n.dupe[index1].skelPos;
          if (!n.dupe[index1].enemySound.IsDisposed)
          {
            float num = 1f - MathHelper.Clamp((float) (((double) Vector3.Distance(this.campos, n.dupe[index1].enemypos) - 350.0) / 1400.0), 0.0f, 1f);
            n.dupe[index1].enemySound.Volume = num * this.sc.ev;
            n.dupe[index1].audioemitter.Position = n.dupe[index1].mypos;
            n.dupe[index1].audiolistener.Position = this.campos;
            n.dupe[index1].audiolistener.Forward = Vector3.Transform(new Vector3(0.0f, 0.0f, 1f), Matrix.CreateRotationY(myPlayer.displayState.npcRotation));
            n.dupe[index1].enemySound.Apply3D(n.dupe[index1].audiolistener, n.dupe[index1].audioemitter);
          }
          if ((double) this.sc.myTimer % 3.0 == 0.0 && this.sc.host)
            this.UpdatePickingEnemyDoors(this.enemyProj, Matrix.CreateLookAt(new Vector3(n.dupe[index1].skelPos1.X, n.dupe[index1].skelPos1.Y + 45f, n.dupe[index1].skelPos1.Z), new Vector3(n.dupe[index1].skelPos2.X, n.dupe[index1].skelPos2.Y + 45f, n.dupe[index1].skelPos2.Z), Vector3.Up), ref genCursor, ref n, index1, combo, plain);
          if (n.dupe[index1].enemyBlocked && this.sc.host)
          {
            n.dupe[index1].enemypos = enemypos;
            this.findenemyDestination(ref n, index1, ref this.enemyGuard, ref this.enemyInvade);
            n.dupe[index1].enemyBlocked = false;
          }
          n.dupe[index1].UpdateNormal(ref tunnelheights);
          n.dupe[index1].mypos = n.dupe[index1].enemypos + new Vector3(0.0f, n.dupe[index1].hoff, 0.0f);
          n.dupe[index1].myRot2 = n.dupe[index1].skelRot;
          n.dupe[index1].transform = Matrix.CreateScale(n.dupe[index1].scale) * n.dupe[index1].myRot2 * Matrix.CreateTranslation(n.dupe[index1].mypos);
          this.tempySkin.Transformation = n.dupe[index1].transform;
          this.tempySkin.tween = n.dupe[index1].tween;
          this.tempySkin.frame1 = (float) n.dupe[index1].frame1;
          this.tempySkin.frame2 = (float) n.dupe[index1].frame2;
          this.tempySkin.blood = (float) n.dupe[index1].blood;
          this.tempySkin.tint = n.dupe[index1].tint;
          n.display1[n.index1] = this.tempySkin;
          ++n.index1;
        }
      }
    }

    private void splatEnemySkull(
      ref enemynpc.npcEnemy n,
      ref Cursor cursor,
      ref Cursor genCursor,
      ref localPlayer myPlayer,
      ref Vector2 hitVel,
      ref float camshaker)
    {
      --this.attackWaite;
      n.hitindex = -1;
      n.npcDist = 20000f;
      float num1 = cursor.closestIntersection * cursor.closestIntersection;
      Vector3 vector2_1 = Vector3.Normalize(this.camlookpos - this.campos);
      Vector3 vector3_1 = -vector2_1 * 100f + this.campos;
      int num2 = 25000000;
      float result1 = 0.0f;
      Vector2 vector2_2 = new Vector2(myPlayer.displayState.npcPosition.X, myPlayer.displayState.npcPosition.Z);
      for (int index1 = 0; index1 < n.dupe.Count; ++index1)
      {
        Vector2 vector2_3 = new Vector2(n.dupe[index1].mypos.X, n.dupe[index1].mypos.Z) - vector2_2;
        float num3 = vector2_3.LengthSquared();
        Vector3 result2;
        if (!myPlayer.gunFired && this.attackWaite <= 0 && (double) myPlayer.now.health > 0.0 && !n.dupe[index1].death && (double) myPlayer.displayState.npcPosition.Y < -80.0 && (double) num3 < 400.0 * (double) n.dupe[index1].scale * (400.0 * (double) n.dupe[index1].scale))
        {
          int index2 = n.dupe[index1].frame1 * 19 + 1;
          Matrix.CreateTranslation(5f, 0.0f, 0.0f, out this.m1);
          Matrix.Multiply(ref this.m1, ref n.data.Bones[index2], out this.m2);
          Matrix.Multiply(ref this.m2, ref n.dupe[index1].transform, out this.m3);
          Vector3.Transform(ref this.vZero, ref this.m3, out result2);
          if ((double) (new Vector2(result2.X, result2.Z) - vector2_2).LengthSquared() < (double) (10000f * n.dupe[index1].scale * n.dupe[index1].scale))
          {
            float dam = (float) this.rr.Next(900, 1000) / 100f;
            if (this.sc.df == 0)
              dam = (float) this.rr.Next(900, 1200) / 300f;
            if (!myPlayer.isLiftingOpponent && myPlayer.fallState == 0)
            {
              hitVel = -Vector2.Normalize(vector2_3) * 2.5f;
              hitVel = Vector2.Transform(new Vector2(-hitVel.X, hitVel.Y), Matrix.CreateRotationZ(-this.headRot));
            }
            if (this.tunnelAvoidDamage)
            {
              dam = 0.0f;
              hitVel = Vector2.Zero;
            }
            if ((double) myPlayer.now.health < 150.0)
              this.sc.hurt.Play(this.sc.ev, (float) this.rr.Next(-30, 20) / 100f, 0.0f);
            else
              this.sc.boarbite[this.rr.Next(0, 5)].Play(this.sc.ev, (float) this.rr.Next(-10, 20) / 100f, (float) this.rr.Next(-70, 70) / 100f);
            if (this.rr.Next(1, 200) < 10)
              camshaker = 20f;
            if (this.rr.Next(1, 200) < 45)
              myPlayer.bloodCoil = 50;
            if (myPlayer.isDown)
            {
              myPlayer.damHealth(dam * 0.5f, this.sc.cheat_Invincible);
              this.attackWaite = 200;
              n.dupe[index1].attackAgain = 0;
            }
            else
            {
              if (this.rr.Next(1, 100) < 20)
                this.seen4.Play(this.sc.ev, 0.0f, 0.0f);
              myPlayer.damHealth(dam, this.sc.cheat_Invincible);
              this.attackWaite = 2;
              n.dupe[index1].attackAgain = 0;
            }
          }
        }
        if (myPlayer.gunChoice != 14 && myPlayer.gunFired && (double) num3 < (double) num2)
        {
          Vector3 vector3_2 = new Vector3(n.dupe[index1].mypos.X, n.dupe[index1].mypos.Y, n.dupe[index1].mypos.Z) - vector3_1;
          Vector3.Normalize(ref vector3_2, out result2);
          Vector3.Dot(ref result2, ref vector2_1, out result1);
          if ((double) num3 < 22500.0 || (double) result1 > (double) this.sc.myfov)
          {
            float num4 = 0.98f;
            if ((double) num3 < 90000.0)
              num4 = 0.2f;
            if ((!myPlayer.closeCam || (double) result1 > (double) num4) && (double) num3 < (double) n.npcDist * (double) n.npcDist && (double) num3 < (double) num1)
            {
              float scale = 1f;
              if (myPlayer.gunChoice == 8 && (double) num3 > 90000.0)
                scale = 2f;
              int index3 = n.dupe[index1].frame1 * 19 + 3;
              Matrix matrix2 = n.data.Bones[index3] * n.dupe[index1].transform;
              Matrix.CreateScale(scale, out this.m1);
              Matrix.Multiply(ref this.m1, ref matrix2, out this.m2);
              Vector3.Transform(ref this.bottomCorner, ref this.m2, out this.min);
              Vector3.Transform(ref this.topCornernew, ref this.m2, out this.max);
              this.distCheck = genCursor.hitBox(myPlayer.gunpos, myPlayer.gunlook, this.min, this.max);
              if (this.distCheck.HasValue && (double) this.distCheck.Value < (double) n.npcDist && (double) this.distCheck.Value < (double) cursor.closestIntersection)
              {
                n.npcDist = this.distCheck.Value;
                n.hitindex = index1;
              }
            }
          }
        }
      }
      if (this.skull.hitindex == -1)
        this.skull.npcDist = 10000f;
      else if (myPlayer.gunChoice == 8 && (double) this.skull.npcDist > 1500.0)
      {
        this.skull.npcDist = 10000f;
        this.skull.hitindex = -1;
      }
      else if ((double) this.skull.npcDist > (double) cursor.closestIntersection)
      {
        this.skull.npcDist = 10000f;
        this.skull.hitindex = -1;
      }
      else
      {
        float num5 = 9000f;
        this.cubeCenter = Vector3.Zero;
        int num6 = -1;
        for (int index4 = 0; index4 < n.targ.Length; ++index4)
        {
          int index5 = n.dupe[this.skull.hitindex].frame1 * 19 + n.bone[index4];
          this.cubeMatrix = n.targ[index4] * n.data.Bones[index5] * n.dupe[this.skull.hitindex].transform;
          this.cubeCenter = Vector3.Transform(Vector3.Zero, this.cubeMatrix);
          this.distCheck = genCursor.hitSphere2(myPlayer.gunpos, myPlayer.gunlook, this.cubeCenter, n.dupe[this.skull.hitindex].scale * (0.5f * this.enemysphereScale[index4]));
          if (this.distCheck.HasValue && (double) this.distCheck.Value < (double) num5)
          {
            num5 = this.distCheck.Value;
            num6 = index4;
            if (index4 == 0)
              num6 = 5;
          }
        }
        if (num6 == -1)
        {
          this.skull.hitindex = -1;
        }
        else
        {
          if ((double) num5 >= 9000.0)
            return;
          if (this.sc.host)
          {
            ++n.dupe[this.skull.hitindex].localhitCount;
            if (n.dupe[this.skull.hitindex].localhitCount > 4 && !n.dupe[this.skull.hitindex].homing)
            {
              this.lastPlayerPos = new Vector2(this.campos.X, this.campos.Z);
              this.findenemyDestination2(ref n, this.skull.hitindex, this.lastPlayerPos);
              n.dupe[this.skull.hitindex].localhitCount = 0;
            }
          }
          myPlayer.now.accuracy = (ushort) this.skull.hitindex;
          bool flag = this.explosiveCount > 0 && this.handtype[myPlayer.gunChoice] == 2;
          this.outside = num5 * genCursor.rayDir + genCursor.rayPos;
          this.scale = n.dupe[this.skull.hitindex].scale;
          if (!flag)
          {
            this.bitSpray = true;
            myPlayer.now.gunfired = 12;
          }
          if (flag)
          {
            this.bloodSpray = true;
            myPlayer.now.gunfired = 13;
            if (this.rr.Next(1, 100) < 20)
              this.addEnemyBlood(ref n, this.skull.hitindex, this.rr.Next(0, 9));
            if (this.rr.Next(1, 100) < 50)
            {
              Vector3 cameraPosition = new Vector3(n.dupe[this.skull.hitindex].mypos.X, n.dupe[this.skull.hitindex].mypos.Y + 50f, n.dupe[this.skull.hitindex].mypos.Z);
              this.skullView = Matrix.CreateLookAt(cameraPosition, new Vector3(cameraPosition.X + (float) this.rr.Next(-7000, 7000) / 40f, cameraPosition.Y + (float) this.rr.Next(-7000, 7000) / 40f, cameraPosition.Z + (float) this.rr.Next(-7000, 7000) / 40f), Vector3.Right);
              this.decalSpray = true;
            }
          }
          if (!n.dupe[this.skull.hitindex].death && ((double) n.dupe[this.skull.hitindex].timer < 30.0 || n.dupe[this.skull.hitindex].defaultClip >= 0 && n.dupe[this.skull.hitindex].defaultClip <= 2))
          {
            n.dupe[this.skull.hitindex].temp1 = 1;
            n.dupe[this.skull.hitindex].temp2 = 1;
            n.dupe[this.skull.hitindex].makeCalc(this.rr.Next(5, 8), 35f);
            n.dupe[this.skull.hitindex].defaultClip = 5;
          }
          if (!flag)
            this.sc.metalHit[this.rr.Next(0, 4)].Play(this.sc.ev * 0.5f, (float) this.rr.Next(-30, 40) / 100f, (float) this.rr.Next(-30, 30) / 100f);
          if ((double) n.dupe[this.skull.hitindex].health <= 0.0 || n.dupe[this.skull.hitindex].death)
            return;
          if (flag)
          {
            n.dupe[this.skull.hitindex].health -= this.gunDam[myPlayer.lastWeapon] * 5f;
            if (this.sc.df == 0)
              n.dupe[this.skull.hitindex].health -= this.gunDam[myPlayer.lastWeapon] * 4f;
          }
          if (!flag)
          {
            n.dupe[this.skull.hitindex].health -= this.gunDam[myPlayer.lastWeapon] * 1f;
            if (this.sc.df == 0)
              n.dupe[this.skull.hitindex].health -= this.gunDam[myPlayer.lastWeapon] * 2f;
          }
          if ((double) n.dupe[this.skull.hitindex].health > 0.0)
            return;
          this.killSkull(ref n, this.skull.hitindex);
          this.sendDeath = this.skull.hitindex;
        }
      }
    }

    public void killSkull(ref enemynpc.npcEnemy n, int i)
    {
      if (enemyDupe.isChasing == i)
        enemyDupe.isChasing = -1;
      n.dupe[i].timeofDeath = -this.timeFrame;
      n.dupe[i].health = 0.0f;
      n.dupe[i].death = true;
      n.dupe[i].enemySound.Volume = 0.0f;
      this.enemydie.Play(this.sc.ev, (float) this.rr.Next(-20, 20) / 100f, 0.0f);
      int ch = this.rr.Next(8, 10);
      n.dupe[i].defaultClip = ch;
      n.dupe[i].makeCalc(ch, 238f);
      n.dupe[i].temp1 = 1;
      if (n.alive != 1 || (this.sc.goldKeys.keyTusk1 && this.sc.tusk1 == 0 && this.mazeid == 1 || this.sc.goldKeys.keyTusk2 && this.sc.tusk2 == 0 && this.mazeid == 2 ? 1 : (!this.sc.goldKeys.keyTusk3 || this.sc.tusk3 != 0 ? 0 : (this.mazeid == 4 ? 1 : 0))) == 0)
        return;
      n.alive2 = i;
      this.sc.newtip.Play(this.sc.ev, 0.0f, 0.0f);
      this.sc.goldKeys.tuskpos = new Vector3(n.dupe[i].enemypos.X, -265f, n.dupe[i].enemypos.Z);
      this.sc.goldKeys.tuskmatrix = Matrix.CreateScale(5f) * Matrix.CreateRotationY(3f) * Matrix.CreateTranslation(this.sc.goldKeys.tuskpos);
    }

    public void findenemyDestination(
      ref enemynpc.npcEnemy n,
      int i,
      ref Vector2[] guard,
      ref Vector2[] invade)
    {
      if (enemyDupe.isChasing == i)
        enemyDupe.isChasing = -1;
      bool flag1 = false;
      bool flag2 = false;
      ++n.dupe[i].enemyCounter;
      if (n.dupe[i].blockedCount > 3)
        flag2 = true;
      if (!flag2 && (flag1 || n.dupe[i].enemyCounter % 3 == 0))
      {
        n.dupe[i].destination = guard[this.rr.Next(0, guard.Length)];
        if ((double) Vector2.Distance(new Vector2(n.dupe[i].destination.X, n.dupe[i].destination.Y), new Vector2(n.dupe[i].enemypos.X, n.dupe[i].enemypos.Z)) < 250.0)
        {
          flag1 = true;
          for (int index = 0; index < guard.Length; ++index)
          {
            n.dupe[i].destination = guard[index];
            if ((double) Vector2.Distance(new Vector2(n.dupe[i].destination.X, n.dupe[i].destination.Y), new Vector2(n.dupe[i].enemypos.X, n.dupe[i].enemypos.Z)) > 250.0)
            {
              flag1 = false;
              break;
            }
          }
        }
        else
          flag1 = false;
      }
      if (flag2 || flag1 || n.dupe[i].enemyCounter % 3 == 1)
      {
        n.dupe[i].destination = n.dupe[i].myhome;
        if ((double) Vector2.Distance(new Vector2(n.dupe[i].destination.X, n.dupe[i].destination.Y), new Vector2(n.dupe[i].enemypos.X, n.dupe[i].enemypos.Z)) < 250.0)
          flag1 = true;
      }
      if (!flag2 && (flag1 || n.dupe[i].enemyCounter % 3 == 2))
      {
        n.dupe[i].destination = invade[this.rr.Next(0, invade.Length)];
        if ((double) Vector2.Distance(new Vector2(n.dupe[i].destination.X, n.dupe[i].destination.Y), new Vector2(n.dupe[i].enemypos.X, n.dupe[i].enemypos.Z)) < 250.0)
        {
          bool flag3 = true;
          for (int index = 0; index < invade.Length; ++index)
          {
            n.dupe[i].destination = invade[index];
            if ((double) Vector2.Distance(new Vector2(n.dupe[i].destination.X, n.dupe[i].destination.Y), new Vector2(n.dupe[i].enemypos.X, n.dupe[i].enemypos.Z)) > 250.0)
            {
              flag3 = false;
              break;
            }
          }
        }
      }
      int ity = 1;
      if (n.dupe[i].blockedCount > 3)
        ity = 3;
      int myseed = this.rr.Next(1, 230);
      if (!(this.skeletonPath(ity, ref n, i, n.dupe[i].enemypos, n.dupe[i].destination, myseed) == "good"))
        return;
      n.dupe[i].blockedCount = 0;
      n.dupe[i].homing = false;
      ++this.sendTime;
      this.enemypos = n.dupe[i].enemypos;
      this.destination = n.dupe[i].destination;
      this.sendSeed = myseed;
      this.iter = ity;
      this.skullindex = i;
    }

    public string skeletonPath(
      int ity,
      ref enemynpc.npcEnemy n,
      int i,
      Vector3 enemypos,
      Vector2 destination,
      int myseed)
    {
      List<Vector3> vector3List = new List<Vector3>();
      float num1 = 150f;
      int index1 = -1;
      for (int index2 = 0; index2 < this.plot3.Length; ++index2)
      {
        vector3List.Add(this.plot3[index2]);
        float num2 = Vector2.Distance(new Vector2(this.plot3[index2].X, this.plot3[index2].Z), new Vector2(enemypos.X, enemypos.Z));
        if ((double) num2 < (double) num1)
        {
          num1 = num2;
          index1 = index2;
        }
      }
      if (index1 == -1)
        return "lost start not found";
      Vector3 start = this.plot3[index1];
      bool flag = false;
      List<Vector3> final = new List<Vector3>();
      List<Vector3> search = new List<Vector3>();
      List<Vector3> result = new List<Vector3>();
      Random random = new Random(myseed);
      vector3List.ForEach((Action<Vector3>) (item => search.Add(item)));
      for (int index3 = 0; index3 < 100; ++index3)
      {
        int index4 = random.Next(0, search.Count);
        int index5 = random.Next(0, search.Count);
        Vector3 vector3 = search[index4];
        search[index4] = search[index5];
        search[index5] = vector3;
      }
      for (int index6 = 0; index6 < ity; ++index6)
      {
        flag = this.buildPath(ref search, ref result, start, destination, myseed);
        if (final.Count == 0 || result.Count < final.Count && flag)
        {
          final.Clear();
          result.ForEach((Action<Vector3>) (item => final.Add(item)));
        }
        search.Clear();
        result.Clear();
        ++myseed;
        vector3List.ForEach((Action<Vector3>) (item => search.Add(item)));
        for (int index7 = 0; index7 < 100; ++index7)
        {
          int index8 = random.Next(0, search.Count);
          int index9 = random.Next(0, search.Count);
          Vector3 vector3 = search[index8];
          search[index8] = search[index9];
          search[index9] = vector3;
        }
      }
      if (final.Count < 3 && flag)
        return "too close";
      if (!flag)
        return "lost destination not found";
      final.Insert(0, enemypos);
      Array.Resize<Vector3>(ref n.dupe[i].skelPath3, final.Count);
      for (int index10 = 0; index10 < final.Count; ++index10)
        n.dupe[i].skelPath3[index10] = final[index10];
      n.dupe[i].skelIndex = 0;
      n.dupe[i].skelInc = 0.0f;
      int index11 = n.dupe[i].skelIndex + 1;
      n.dupe[i].skelPos1 = n.dupe[i].skelPath3[n.dupe[i].skelIndex];
      n.dupe[i].skelPos2 = n.dupe[i].skelPath3[index11];
      n.dupe[i].skelStep = (float) (0.00279999990016222 / ((double) Vector3.Distance(n.dupe[i].skelPos1, n.dupe[i].skelPos2) / (double) n.dupe[i].skelOrigRate));
      n.dupe[i].homing = false;
      return "good";
    }

    public bool buildPath(
      ref List<Vector3> source,
      ref List<Vector3> result,
      Vector3 start,
      Vector2 end,
      int seed)
    {
      bool flag = true;
      Random random = new Random(seed);
      List<Vector3> vector3List1 = new List<Vector3>();
      for (int index = 0; index < source.Count; ++index)
      {
        float num = Vector2.Distance(new Vector2(start.X, start.Z), new Vector2(source[index].X, source[index].Z));
        if ((double) num > 50.0 && (double) num <= 135.0)
          vector3List1.Add(source[index]);
      }
      if (vector3List1.Count == 0)
        return false;
      List<Vector3> vector3List2 = new List<Vector3>();
      while (vector3List1.Count > 0)
      {
        int index = random.Next(0, vector3List1.Count);
        vector3List2.Add(vector3List1[index]);
        vector3List1.RemoveAt(index);
      }
      for (int index = 0; index < vector3List2.Count; ++index)
      {
        if ((double) Vector2.Distance(end, new Vector2(vector3List2[index].X, vector3List2[index].Z)) >= 125.0)
        {
          start = vector3List2[index];
          source.Remove(start);
          result.Add(start);
          if (flag = this.buildPath(ref source, ref result, start, end, seed + 1))
            return true;
          if (!flag)
            result.Remove(start);
        }
        else
        {
          result.Add(vector3List2[index]);
          return true;
        }
      }
      return flag;
    }

    public void findenemyDestination2(ref enemynpc.npcEnemy n, int i, Vector2 dest)
    {
      n.dupe[i].destination = dest;
      int myseed = this.rr.Next(1, 230);
      if (!(this.skullChasePath(3, ref n, i, n.dupe[i].enemypos, n.dupe[i].destination, myseed) == "good"))
        return;
      n.dupe[i].blockedCount = 0;
      ++this.sendTime;
      this.enemypos = n.dupe[i].enemypos;
      this.destination = n.dupe[i].destination;
      this.sendSeed = myseed;
      this.iter = 33;
      this.skullindex = i;
    }

    public string skullChasePath(
      int ity,
      ref enemynpc.npcEnemy n,
      int i,
      Vector3 enemypos,
      Vector2 destination,
      int myseed)
    {
      List<Vector3> vector3List = new List<Vector3>();
      float num1 = 130f;
      int index1 = -1;
      int num2 = 0;
      for (int index2 = 0; index2 < this.plot3.Length; ++index2)
      {
        float num3 = Vector2.Distance(destination, new Vector2(enemypos.X, enemypos.Z)) + 400f;
        float num4 = Vector2.Distance(destination, new Vector2(this.plot3[index2].X, this.plot3[index2].Z));
        float num5 = Vector2.Distance(new Vector2(this.plot3[index2].X, this.plot3[index2].Z), new Vector2(enemypos.X, enemypos.Z));
        if ((double) num5 <= (double) num3)
        {
          ++num2;
          vector3List.Add(this.plot3[index2]);
          if ((double) num5 < (double) num1 && (double) num4 <= (double) num3)
          {
            num1 = num5;
            index1 = index2;
          }
        }
      }
      if (index1 == -1)
      {
        enemyDupe.isChasing = -1;
        return "nostart";
      }
      Vector3 start = this.plot3[index1];
      bool flag = false;
      List<Vector3> final = new List<Vector3>();
      List<Vector3> search = new List<Vector3>();
      List<Vector3> result = new List<Vector3>();
      vector3List.ForEach((Action<Vector3>) (item => search.Add(item)));
      for (int index3 = 0; index3 < ity; ++index3)
      {
        flag = this.buildChasePath(ref search, ref result, start, destination, myseed);
        if (final.Count == 0 || result.Count < final.Count && flag)
        {
          final.Clear();
          result.ForEach((Action<Vector3>) (item => final.Add(item)));
        }
        search.Clear();
        result.Clear();
        vector3List.ForEach((Action<Vector3>) (item => search.Add(item)));
      }
      if (final.Count < 1 && flag)
      {
        enemyDupe.isChasing = -1;
        return "tooclose";
      }
      if (!flag)
      {
        enemyDupe.isChasing = -1;
        return "lost";
      }
      final.Insert(0, new Vector3(enemypos.X, enemypos.Y, enemypos.Z));
      Array.Resize<Vector3>(ref n.dupe[i].skelPath3, final.Count);
      for (int index4 = 0; index4 < final.Count; ++index4)
        n.dupe[i].skelPath3[index4] = final[index4];
      n.dupe[i].skelIndex = 0;
      n.dupe[i].skelInc = 0.0f;
      int index5 = n.dupe[i].skelIndex + 1;
      n.dupe[i].skelPos1 = n.dupe[i].skelPath3[n.dupe[i].skelIndex];
      n.dupe[i].skelPos2 = n.dupe[i].skelPath3[index5];
      n.dupe[i].skelStep = (float) (0.00279999990016222 / ((double) Vector3.Distance(n.dupe[i].skelPos1, n.dupe[i].skelPos2) / (double) n.dupe[i].skelFastRate));
      if (this.rr.Next(1, 100) > 30)
        this.seen4.Play(this.sc.ev, 0.0f, 0.0f);
      else
        this.seen.Play(this.sc.ev, 0.0f, 0.0f);
      if (!n.dupe[i].death)
      {
        int ch = this.rr.Next(3, 5);
        n.dupe[i].makeCalc(ch, 90f);
        n.dupe[i].defaultClip = ch;
      }
      n.dupe[i].localhitCount = 0;
      n.dupe[i].remotehitCount = 0;
      n.dupe[i].homing = true;
      return "good";
    }

    private bool buildChasePath(
      ref List<Vector3> source,
      ref List<Vector3> result,
      Vector3 start,
      Vector2 end,
      int myseed)
    {
      bool flag = true;
      Random random = new Random(myseed);
      List<Vector3> vector3List1 = new List<Vector3>();
      float num1 = 10000f;
      for (int index = 0; index < source.Count; ++index)
      {
        float num2 = Vector2.Distance(new Vector2(start.X, start.Z), new Vector2(source[index].X, source[index].Z));
        float num3 = Vector2.Distance(end, new Vector2(source[index].X, source[index].Z));
        if ((double) num2 > 50.0 && (double) num2 <= 125.0 && (double) num3 < (double) num1)
        {
          if ((double) num1 != 10000.0)
            vector3List1.RemoveAt(vector3List1.Count - 1);
          num1 = num3;
          vector3List1.Add(source[index]);
        }
      }
      if (vector3List1.Count == 0)
        return false;
      List<Vector3> vector3List2 = new List<Vector3>();
      while (vector3List1.Count > 0)
      {
        int index = random.Next(0, vector3List1.Count);
        vector3List2.Add(vector3List1[index]);
        vector3List1.RemoveAt(index);
      }
      for (int index = 0; index < vector3List2.Count; ++index)
      {
        if ((double) Vector2.Distance(end, new Vector2(vector3List2[index].X, vector3List2[index].Z)) > 125.0)
        {
          start = vector3List2[index];
          source.Remove(start);
          result.Add(start);
          if (flag = this.buildChasePath(ref source, ref result, start, end, myseed + 1))
            return true;
          if (!flag)
            result.Remove(start);
        }
        else
        {
          result.Add(vector3List2[index]);
          return true;
        }
      }
      return flag;
    }

    private void UpdatePickingEnemyDoors(
      Matrix projection,
      Matrix view,
      ref Cursor c,
      ref enemynpc.npcEnemy n,
      int p,
      List<BloodnBacon.myDoor> combo,
      List<BloodnBacon.myDoor> plain)
    {
      --n.dupe[p].blockedTimer;
      if (n.dupe[p].blockedTimer <= 0)
        n.dupe[p].blockedCount = 0;
      this.cursorRay = c.CalculateCursorRay(projection, view);
      c.rayDir = c.rayPos = c.pickedTriangle[0] = c.pickedTriangle[1] = c.pickedTriangle[2] = Vector3.Zero;
      c.rayDir = this.cursorRay.Direction;
      c.rayPos = this.cursorRay.Position;
      c.closestIntersection = 10000f;
      for (int index = 0; index < combo.Count; ++index)
      {
        bool mybool = false;
        c.RayInteresectGeneric(this.cursorRay, combo[index].doorMatrix, ref c.door1Vertices, ref mybool);
        if (mybool && combo[index].doorlock && (double) c.closestIntersection < 200.0)
        {
          n.dupe[p].enemyBlocked = true;
          n.dupe[p].blockedTimer = 50;
          ++n.dupe[p].blockedCount;
          return;
        }
      }
      for (int index = 0; index < plain.Count; ++index)
      {
        bool mybool = false;
        c.RayInteresectGeneric(this.cursorRay, plain[index].doorMatrix, ref c.door1Vertices, ref mybool);
        if (mybool && plain[index].doorlock && (double) c.closestIntersection < 200.0)
        {
          n.dupe[p].enemyBlocked = true;
          n.dupe[p].blockedTimer = 50;
          ++n.dupe[p].blockedCount;
          break;
        }
      }
    }

    private void UpdatePickingEnemyDoors(
      Matrix projection,
      Matrix view,
      ref Cursor c,
      ref enemynpc.npcEnemy n,
      int p,
      List<BloodnBacon4PT.myDoor> combo,
      List<BloodnBacon4PT.myDoor> plain)
    {
      --n.dupe[p].blockedTimer;
      if (n.dupe[p].blockedTimer <= 0)
        n.dupe[p].blockedCount = 0;
      this.cursorRay = c.CalculateCursorRay(projection, view);
      c.rayDir = c.rayPos = c.pickedTriangle[0] = c.pickedTriangle[1] = c.pickedTriangle[2] = Vector3.Zero;
      c.rayDir = this.cursorRay.Direction;
      c.rayPos = this.cursorRay.Position;
      c.closestIntersection = 10000f;
      for (int index = 0; index < combo.Count; ++index)
      {
        bool mybool = false;
        c.RayInteresectGeneric(this.cursorRay, combo[index].doorMatrix, ref c.door1Vertices, ref mybool);
        if (mybool && combo[index].doorlock && (double) c.closestIntersection < 200.0)
        {
          n.dupe[p].enemyBlocked = true;
          n.dupe[p].blockedTimer = 50;
          ++n.dupe[p].blockedCount;
          return;
        }
      }
      for (int index = 0; index < plain.Count; ++index)
      {
        bool mybool = false;
        c.RayInteresectGeneric(this.cursorRay, plain[index].doorMatrix, ref c.door1Vertices, ref mybool);
        if (mybool && plain[index].doorlock && (double) c.closestIntersection < 200.0)
        {
          n.dupe[p].enemyBlocked = true;
          n.dupe[p].blockedTimer = 50;
          ++n.dupe[p].blockedCount;
          break;
        }
      }
    }

    private void UpdatePickingEnemyPlayer(
      Matrix projection,
      ref Cursor c,
      ref enemynpc.npcEnemy n,
      int p,
      bool omni)
    {
      Matrix viewMatrix = Matrix.Identity;
      Vector3 cameraPosition = new Vector3(0.0f, 45f, 0.0f) + n.dupe[p].enemypos;
      if (!omni)
        viewMatrix = Matrix.CreateLookAt(cameraPosition, cameraPosition + Vector3.Transform(new Vector3(0.0f, 0.0f, -50f), n.dupe[p].skelRot), Vector3.Up);
      if (omni)
        viewMatrix = Matrix.CreateLookAt(cameraPosition, this.campos, Vector3.Up);
      bool mybool = false;
      this.cursorRay = c.CalculateCursorRay(projection, viewMatrix);
      c.rayDir = c.rayPos = c.pickedTriangle[0] = c.pickedTriangle[1] = c.pickedTriangle[2] = Vector3.Zero;
      c.rayDir = this.cursorRay.Direction;
      c.rayPos = this.cursorRay.Position;
      c.closestIntersection = 10000f;
      c.ignorebounds = true;
      c.RayInteresectGeneric(this.cursorRay, this.buildingMatrix, ref c.tunnelvertices3, ref mybool);
      if (enemyDupe.isChasing != p && enemyDupe.isChasing != -1 || (double) Vector3.Distance(this.campos, n.dupe[p].enemypos) <= 100.0)
        return;
      float? nullable = new BoundingSphere()
      {
        Center = this.campos,
        Radius = 80f
      }.Intersects(this.cursorRay);
      if (!nullable.HasValue || (double) nullable.Value >= (double) c.closestIntersection || !this.lightON && (double) nullable.Value >= 300.0)
        return;
      this.lastPlayerPos = new Vector2(this.campos.X, this.campos.Z);
      if (this.seenCounter <= 0)
      {
        this.seen.Play(this.sc.ev, 0.0f, 0.0f);
        this.seenCounter = 120;
      }
      enemyDupe.isChasing = p;
      this.findenemyDestination2(ref this.skull, p, this.lastPlayerPos);
    }

    public void Draw(bool tunnelCheats)
    {
      if (this.skull.index1 <= 0)
        return;
      this.DrawSkull1(ref this.skull, this.skull.index1);
    }

    private void DrawSkull1(ref enemynpc.npcEnemy n, int cc)
    {
      ModelMeshPart meshPart = n.model1.Meshes[0].MeshParts[0];
      n.buffer1.SetData<enemynpc.skinstream>(n.display1, 0, cc, SetDataOptions.Discard);
      int index = this.techniWorld;
      if (index == 2)
        index = 1;
      float num = 0.2f;
      if (this.tunnelDebug)
        num = 1f;
      n.eff.CurrentTechnique = n.eff.Techniques[index];
      n.eff.Parameters["darkness"].SetValue(num);
      n.eff.Parameters["gDiffuse"].SetValue((Texture) this.ttWorld);
      n.eff.Parameters["depth"].SetValue(this.flashlightDepth);
      n.eff.Parameters["View"].SetValue(this.view);
      n.eff.Parameters["Projection"].SetValue(this.proj);
      n.eff.Parameters["projectorView"].SetValue(this.matrix_0);
      n.eff.CurrentTechnique.Passes[0].Apply();
      this._vertexBufferBindings[0] = new VertexBufferBinding(meshPart.VertexBuffer, meshPart.VertexOffset, 0);
      this._vertexBufferBindings[1] = new VertexBufferBinding((VertexBuffer) n.buffer1, 0, 1);
      this.sc.GraphicsDevice.SetVertexBuffers(this._vertexBufferBindings);
      this.sc.GraphicsDevice.Indices = meshPart.IndexBuffer;
      this.sc.GraphicsDevice.DrawInstancedPrimitives(PrimitiveType.TriangleList, 0, 0, meshPart.NumVertices, meshPart.StartIndex, meshPart.PrimitiveCount, cc);
    }

    private void DrawModel(Model model, Matrix world, Vector3 cc)
    {
      Vector3 vector3_1 = cc;
      Vector3 vector3_2 = cc;
      foreach (BasicEffect effect in model.Meshes[0].Effects)
      {
        effect.World = world;
        effect.View = this.view;
        effect.Projection = this.proj;
        effect.LightingEnabled = true;
        effect.EmissiveColor = cc;
        effect.DirectionalLight0.Enabled = true;
        effect.DirectionalLight0.Direction = new Vector3(0.2f, -0.5f, 0.1f);
        effect.AmbientLightColor = vector3_2;
        effect.DirectionalLight0.DiffuseColor = vector3_1;
        effect.PreferPerPixelLighting = false;
      }
      model.Meshes[0].Draw();
    }

    public void GetHeightFast(ref float[,] heights, Vector3 position, ref float height)
    {
      int index1 = (int) MathHelper.Clamp(position.X / enemynpc.unit, 0.0f, (float) (enemynpc.bitmap - 2));
      int index2 = (int) MathHelper.Clamp(position.Z / enemynpc.unit, 0.0f, (float) (enemynpc.bitmap - 2));
      float num1 = position.X % enemynpc.unit / enemynpc.unit;
      float num2 = position.Z % enemynpc.unit / enemynpc.unit;
      float num3 = (float) ((1.0 - (double) num1) * (double) heights[index1, index2] + (double) num1 * (double) heights[index1 + 1, index2]);
      float num4 = (float) ((1.0 - (double) num1) * (double) heights[index1, index2 + 1] + (double) num1 * (double) heights[index1 + 1, index2 + 1]);
      height = (float) ((1.0 - (double) num2) * (double) num3 + (double) num2 * (double) num4);
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

    public struct npcEnemy
    {
      public int alive;
      public int alive2;
      public Model model1;
      public enemynpc.skinstream[] display1;
      public List<int> explodelist;
      public List<int> shockList;
      public List<int> shatterList;
      public List<enemyDupe> dupe;
      public List<enemynpc.conductor> conductor;
      public int max;
      public int index1;
      public DynamicVertexBuffer buffer1;
      public SkinningDataX data;
      public Texture2D bitmap;
      public Texture2D Texture1;
      public Effect eff;
      public Vector3[] uv;
      public Matrix[] targ;
      public int[] bone;
      public int hitindex;
      public float npcDist;
    }

    public struct skinstream : IVertexType
    {
      public Matrix Transformation;
      public float frame1;
      public float frame2;
      public float tween;
      public float blood;
      public float tint;
      private static readonly VertexDeclaration VertexDeclaration = new VertexDeclaration(new VertexElement[9]
      {
        new VertexElement(0, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 1),
        new VertexElement(16, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 2),
        new VertexElement(32, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 3),
        new VertexElement(48, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 4),
        new VertexElement(64, VertexElementFormat.Single, VertexElementUsage.Fog, 0),
        new VertexElement(68, VertexElementFormat.Single, VertexElementUsage.Fog, 1),
        new VertexElement(72, VertexElementFormat.Single, VertexElementUsage.Fog, 2),
        new VertexElement(76, VertexElementFormat.Single, VertexElementUsage.Fog, 3),
        new VertexElement(80, VertexElementFormat.Single, VertexElementUsage.Fog, 4)
      });

      VertexDeclaration IVertexType.VertexDeclaration => enemynpc.skinstream.VertexDeclaration;
    }
  }
}
