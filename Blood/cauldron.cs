using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

#pragma warning disable CS0414
#nullable disable
namespace Blood
{
  public class cauldron
  {
    private ScreenManager sc;
    private ContentManager content;
    private Matrix discPos = Matrix.Identity;
    public static int bitmap;
    public static float unit;
    public int caldkinIndex = -1;
    public int level;
    public int oldlevel;
    private int soundcount;
    private float lightFade = 1f;
    private Vector3 glowcolor = new Vector3(0.0f, 0.0f, 0.0f);
    private int glowOnce;
    private float glowRamp;
    private float glowInc = 0.1f;
    private Vector3 flashlightDir = Vector3.One;
    public cauldron.finale bloody;
    public Matrix[] explodePart;
    public int explodeTimer = 100;
    public bool explode;
    private cauldron.hitStream hitstreamTemp = new cauldron.hitStream();
    private static VertexDeclaration vd2 = new VertexDeclaration(new VertexElement[6]
    {
      new VertexElement(0, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 0),
      new VertexElement(16, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 1),
      new VertexElement(32, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 2),
      new VertexElement(48, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 3),
      new VertexElement(64, VertexElementFormat.Single, VertexElementUsage.Fog, 0),
      new VertexElement(68, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 4)
    });
    public int fireRamp = 130;
    public int fireTimer = 500;
    public bool isFull;
    private cauldron.hole fireball;
    private readonly VertexBufferBinding[] _vertexBufferBindings = new VertexBufferBinding[2];
    private static VertexDeclaration instanceDec = new VertexDeclaration(new VertexElement[5]
    {
      new VertexElement(0, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 0),
      new VertexElement(16, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 1),
      new VertexElement(32, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 2),
      new VertexElement(48, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 3),
      new VertexElement(64, VertexElementFormat.Single, VertexElementUsage.Fog, 0)
    });
    private cauldron.instancedObject[] tempInstance = new cauldron.instancedObject[1];
    public cauldron.shell cald;
    public cauldron.shell liquid;
    public cauldron.shell c_leg;
    public cauldron.shell c_big;
    public cauldron.shell c_base;
    public cauldron.shell c_top;
    public cauldron.shell c_ring;
    public SoundEffect sound1;
    public SoundEffect boil;
    public SoundEffect pop2;
    public SoundEffect explodeSound;
    public SoundEffect cackle;
    public SoundEffect cackle2;
    public SoundEffect cackle3;
    public SoundEffect shortboil;
    public SoundEffect sizzle;
    public SoundEffect sizzle2;
    public int alive;
    private Matrix view;
    private Matrix proj;
    private Random rr;
    private Random rx;
    public bool exists;
    public int mainSeed = 1;
    public Vector3 mainScale = Vector3.One;

    public cauldron(ScreenManager ss, ContentManager cc)
    {
      this.rr = new Random();
      this.content = cc;
      this.sc = ss;
      this.bloody = new cauldron.finale();
      this.bloody.max = 0;
      this.bloody.maxCapacity = 200;
      this.bloody.index = 0;
      this.bloody.model = this.content.Load<Model>("Models//bloodything");
      this.bloody.buffer = new DynamicVertexBuffer(this.sc.GraphicsDevice, cauldron.instanceDec, this.bloody.maxCapacity, BufferUsage.WriteOnly);
      this.bloody.displayList = new cauldron.instancedObject[this.bloody.maxCapacity];
      this.bloody.dupe = new explodeDupe2[this.bloody.maxCapacity];
      for (int i = 0; i < this.bloody.maxCapacity; ++i)
        this.bloody.dupe[i] = new explodeDupe2(i);
      this.bloody.stream = new cauldron.instancedObject[this.bloody.maxCapacity];
      this.resetExplody(false);
      this.fireball = new cauldron.hole();
      this.fireball.stainR = new Vector4[80];
      this.fireball.stainR[0] = new Vector4(0.0f, 0.0f, 133f, 200f);
      this.fireball.stainR[1] = new Vector4(798f, 0.0f, 133f, 200f);
      this.fireball.stainR[2] = new Vector4(532f, 400f, 133f, 200f);
      this.fireball.stainR[3] = new Vector4(665f, 800f, 133f, 200f);
      this.fireball.stainR[4] = new Vector4(1064f, 400f, 133f, 200f);
      this.fireball.stainR[5] = new Vector4(1197f, 600f, 133f, 200f);
      this.fireball.stainR[6] = new Vector4(1463f, 800f, 133f, 200f);
      this.fireball.stainR[7] = new Vector4(931f, 1000f, 133f, 200f);
      this.fireball.stainR[8] = new Vector4(1197f, 1000f, 133f, 200f);
      this.fireball.stainR[9] = new Vector4(133f, 0.0f, 133f, 200f);
      this.fireball.stainR[10] = new Vector4(266f, 0.0f, 133f, 200f);
      this.fireball.stainR[11] = new Vector4(0.0f, 200f, 133f, 200f);
      this.fireball.stainR[12] = new Vector4(133f, 200f, 133f, 200f);
      this.fireball.stainR[13] = new Vector4(266f, 200f, 133f, 200f);
      this.fireball.stainR[14] = new Vector4(399f, 0.0f, 133f, 200f);
      this.fireball.stainR[15] = new Vector4(532f, 0.0f, 133f, 200f);
      this.fireball.stainR[16] = new Vector4(399f, 200f, 133f, 200f);
      this.fireball.stainR[17] = new Vector4(665f, 0.0f, 133f, 200f);
      this.fireball.stainR[18] = new Vector4(532f, 200f, 133f, 200f);
      this.fireball.stainR[19] = new Vector4(665f, 200f, 133f, 200f);
      this.fireball.stainR[20] = new Vector4(798f, 200f, 133f, 200f);
      this.fireball.stainR[21] = new Vector4(0.0f, 400f, 133f, 200f);
      this.fireball.stainR[22] = new Vector4(133f, 400f, 133f, 200f);
      this.fireball.stainR[23] = new Vector4(0.0f, 600f, 133f, 200f);
      this.fireball.stainR[24] = new Vector4(266f, 400f, 133f, 200f);
      this.fireball.stainR[25] = new Vector4(133f, 600f, 133f, 200f);
      this.fireball.stainR[26] = new Vector4(399f, 400f, 133f, 200f);
      this.fireball.stainR[27] = new Vector4(0.0f, 800f, 133f, 200f);
      this.fireball.stainR[28] = new Vector4(266f, 600f, 133f, 200f);
      this.fireball.stainR[29] = new Vector4(133f, 800f, 133f, 200f);
      this.fireball.stainR[30] = new Vector4(399f, 600f, 133f, 200f);
      this.fireball.stainR[31] = new Vector4(665f, 400f, 133f, 200f);
      this.fireball.stainR[32] = new Vector4(266f, 800f, 133f, 200f);
      this.fireball.stainR[33] = new Vector4(532f, 600f, 133f, 200f);
      this.fireball.stainR[34] = new Vector4(798f, 400f, 133f, 200f);
      this.fireball.stainR[35] = new Vector4(399f, 800f, 133f, 200f);
      this.fireball.stainR[36] = new Vector4(665f, 600f, 133f, 200f);
      this.fireball.stainR[37] = new Vector4(532f, 800f, 133f, 200f);
      this.fireball.stainR[38] = new Vector4(798f, 600f, 133f, 200f);
      this.fireball.stainR[39] = new Vector4(798f, 800f, 133f, 200f);
      this.fireball.stainR[40] = new Vector4(931f, 0.0f, 133f, 200f);
      this.fireball.stainR[41] = new Vector4(1064f, 0.0f, 133f, 200f);
      this.fireball.stainR[42] = new Vector4(931f, 200f, 133f, 200f);
      this.fireball.stainR[43] = new Vector4(1197f, 0.0f, 133f, 200f);
      this.fireball.stainR[44] = new Vector4(1064f, 200f, 133f, 200f);
      this.fireball.stainR[45] = new Vector4(1330f, 0.0f, 133f, 200f);
      this.fireball.stainR[46] = new Vector4(931f, 400f, 133f, 200f);
      this.fireball.stainR[47] = new Vector4(1197f, 200f, 133f, 200f);
      this.fireball.stainR[48] = new Vector4(1463f, 0.0f, 133f, 200f);
      this.fireball.stainR[49] = new Vector4(1330f, 200f, 133f, 200f);
      this.fireball.stainR[50] = new Vector4(931f, 600f, 133f, 200f);
      this.fireball.stainR[51] = new Vector4(1596f, 0.0f, 133f, 200f);
      this.fireball.stainR[52] = new Vector4(1197f, 400f, 133f, 200f);
      this.fireball.stainR[53] = new Vector4(1463f, 200f, 133f, 200f);
      this.fireball.stainR[54] = new Vector4(1064f, 600f, 133f, 200f);
      this.fireball.stainR[55] = new Vector4(1729f, 0.0f, 133f, 200f);
      this.fireball.stainR[56] = new Vector4(1330f, 400f, 133f, 200f);
      this.fireball.stainR[57] = new Vector4(931f, 800f, 133f, 200f);
      this.fireball.stainR[58] = new Vector4(1596f, 200f, 133f, 200f);
      this.fireball.stainR[59] = new Vector4(1463f, 400f, 133f, 200f);
      this.fireball.stainR[60] = new Vector4(1064f, 800f, 133f, 200f);
      this.fireball.stainR[61] = new Vector4(1729f, 200f, 133f, 200f);
      this.fireball.stainR[62] = new Vector4(1330f, 600f, 133f, 200f);
      this.fireball.stainR[63] = new Vector4(1596f, 400f, 133f, 200f);
      this.fireball.stainR[64] = new Vector4(1197f, 800f, 133f, 200f);
      this.fireball.stainR[65] = new Vector4(1463f, 600f, 133f, 200f);
      this.fireball.stainR[66] = new Vector4(1729f, 400f, 133f, 200f);
      this.fireball.stainR[67] = new Vector4(1330f, 800f, 133f, 200f);
      this.fireball.stainR[68] = new Vector4(1596f, 600f, 133f, 200f);
      this.fireball.stainR[69] = new Vector4(1729f, 600f, 133f, 200f);
      this.fireball.stainR[70] = new Vector4(1596f, 800f, 133f, 200f);
      this.fireball.stainR[71] = new Vector4(1729f, 800f, 133f, 200f);
      this.fireball.stainR[72] = new Vector4(0.0f, 1000f, 133f, 200f);
      this.fireball.stainR[73] = new Vector4(133f, 1000f, 133f, 200f);
      this.fireball.stainR[74] = new Vector4(266f, 1000f, 133f, 200f);
      this.fireball.stainR[75] = new Vector4(399f, 1000f, 133f, 200f);
      this.fireball.stainR[76] = new Vector4(532f, 1000f, 133f, 200f);
      this.fireball.stainR[77] = new Vector4(665f, 1000f, 133f, 200f);
      this.fireball.stainR[78] = new Vector4(798f, 1000f, 133f, 200f);
      this.fireball.stainR[79] = new Vector4(1064f, 1000f, 133f, 200f);
      this.fireball.stainMax = 0;
      this.fireball.stainIndex = 0;
      this.fireball.stainCapacity = 65;
      this.fireball.location = new Vector3[this.fireball.stainCapacity];
      this.fireball.bone = new int[this.fireball.stainCapacity];
      this.fireball.fade = new float[this.fireball.stainCapacity];
      this.fireball.frame = new int[this.fireball.stainCapacity];
      this.fireball.scale = new Matrix[this.fireball.stainCapacity];
      this.fireball.stainTrans = new cauldron.hitStream[this.fireball.stainCapacity];
      this.fireball.stainBuffer = new DynamicVertexBuffer(this.sc.GraphicsDevice, cauldron.vd2, this.fireball.stainCapacity, BufferUsage.WriteOnly);
      this.cald = new cauldron.shell();
      this.cald.max = 0;
      this.cald.type = 0;
      this.cald.maxCapacity = 3;
      this.cald.index = 0;
      this.cald.model1 = this.content.Load<Model>("models\\cauldron");
      this.cald.buffer = new DynamicVertexBuffer(this.sc.GraphicsDevice, cauldron.instanceDec, this.cald.maxCapacity, BufferUsage.WriteOnly);
      this.cald.displayList = new cauldron.instancedObject[this.cald.maxCapacity];
      this.cald.dupe = new caldDupe[this.cald.maxCapacity];
      for (int i = 0; i < this.cald.maxCapacity; ++i)
        this.cald.dupe[i] = new caldDupe(i);
      this.cald.stream = new cauldron.instancedObject[this.cald.maxCapacity];
      this.liquid = new cauldron.shell();
      this.liquid.max = 0;
      this.cald.type = 0;
      this.liquid.maxCapacity = 3;
      this.liquid.index = 0;
      this.liquid.model1 = this.content.Load<Model>("models\\cauldron_fill");
      this.liquid.buffer = new DynamicVertexBuffer(this.sc.GraphicsDevice, cauldron.instanceDec, this.liquid.maxCapacity, BufferUsage.WriteOnly);
      this.liquid.displayList = new cauldron.instancedObject[this.liquid.maxCapacity];
      this.liquid.dupe = new caldDupe[this.liquid.maxCapacity];
      for (int i = 0; i < this.liquid.maxCapacity; ++i)
        this.liquid.dupe[i] = new caldDupe(i);
      this.liquid.stream = new cauldron.instancedObject[this.liquid.maxCapacity];
      this.c_leg = new cauldron.shell();
      this.c_leg.max = 0;
      this.c_leg.type = 1;
      this.c_leg.maxCapacity = 5;
      this.c_leg.index = 0;
      this.c_leg.model1 = this.content.Load<Model>("models\\cald_leg");
      int maxCapacity1 = this.c_leg.maxCapacity;
      this.c_leg.buffer = new DynamicVertexBuffer(this.sc.GraphicsDevice, cauldron.instanceDec, maxCapacity1, BufferUsage.WriteOnly);
      this.c_leg.displayList = new cauldron.instancedObject[maxCapacity1];
      this.c_leg.dupe = new caldDupe[maxCapacity1];
      for (int i = 0; i < maxCapacity1; ++i)
        this.c_leg.dupe[i] = new caldDupe(i);
      this.c_leg.stream = new cauldron.instancedObject[maxCapacity1];
      this.c_big = new cauldron.shell();
      this.c_big.max = 0;
      this.c_big.type = 2;
      this.c_big.maxCapacity = 5;
      this.c_big.index = 0;
      this.c_big.model1 = this.content.Load<Model>("models\\cald_big");
      int maxCapacity2 = this.c_big.maxCapacity;
      this.c_big.buffer = new DynamicVertexBuffer(this.sc.GraphicsDevice, cauldron.instanceDec, maxCapacity2, BufferUsage.WriteOnly);
      this.c_big.displayList = new cauldron.instancedObject[maxCapacity2];
      this.c_big.dupe = new caldDupe[maxCapacity2];
      for (int i = 0; i < maxCapacity2; ++i)
        this.c_big.dupe[i] = new caldDupe(i);
      this.c_big.stream = new cauldron.instancedObject[maxCapacity2];
      this.c_base = new cauldron.shell();
      this.c_base.max = 0;
      this.c_base.type = 3;
      this.c_base.maxCapacity = 5;
      this.c_base.index = 0;
      this.c_base.model1 = this.content.Load<Model>("models\\cald_base");
      int maxCapacity3 = this.c_base.maxCapacity;
      this.c_base.buffer = new DynamicVertexBuffer(this.sc.GraphicsDevice, cauldron.instanceDec, maxCapacity3, BufferUsage.WriteOnly);
      this.c_base.displayList = new cauldron.instancedObject[maxCapacity3];
      this.c_base.dupe = new caldDupe[maxCapacity3];
      for (int i = 0; i < maxCapacity3; ++i)
        this.c_base.dupe[i] = new caldDupe(i);
      this.c_base.stream = new cauldron.instancedObject[maxCapacity3];
      this.c_top = new cauldron.shell();
      this.c_top.max = 0;
      this.c_top.type = 4;
      this.c_top.maxCapacity = 5;
      this.c_top.index = 0;
      this.c_top.model1 = this.content.Load<Model>("models\\cald_top");
      int maxCapacity4 = this.c_top.maxCapacity;
      this.c_top.buffer = new DynamicVertexBuffer(this.sc.GraphicsDevice, cauldron.instanceDec, maxCapacity4, BufferUsage.WriteOnly);
      this.c_top.displayList = new cauldron.instancedObject[maxCapacity4];
      this.c_top.dupe = new caldDupe[maxCapacity4];
      for (int i = 0; i < maxCapacity4; ++i)
        this.c_top.dupe[i] = new caldDupe(i);
      this.c_top.stream = new cauldron.instancedObject[maxCapacity4];
      this.c_ring = new cauldron.shell();
      this.c_ring.max = 0;
      this.c_ring.type = 4;
      this.c_ring.maxCapacity = 5;
      this.c_ring.index = 0;
      this.c_ring.model1 = this.content.Load<Model>("models\\cald_ring");
      int maxCapacity5 = this.c_ring.maxCapacity;
      this.c_ring.buffer = new DynamicVertexBuffer(this.sc.GraphicsDevice, cauldron.instanceDec, maxCapacity5, BufferUsage.WriteOnly);
      this.c_ring.displayList = new cauldron.instancedObject[maxCapacity5];
      this.c_ring.dupe = new caldDupe[maxCapacity5];
      for (int i = 0; i < maxCapacity5; ++i)
        this.c_ring.dupe[i] = new caldDupe(i);
      this.c_ring.stream = new cauldron.instancedObject[maxCapacity5];
      this.sound1 = this.content.Load<SoundEffect>("audio\\caldHit");
      this.sizzle = this.content.Load<SoundEffect>("audio\\caldSizzle");
      this.sizzle2 = this.content.Load<SoundEffect>("audio\\caldSizzle2");
      this.shortboil = this.content.Load<SoundEffect>("audio\\caldShortBoil");
      this.boil = this.content.Load<SoundEffect>("audio\\caldBoil");
      this.pop2 = this.content.Load<SoundEffect>("audio\\caldexplode");
      this.explodeSound = this.content.Load<SoundEffect>("audio\\caldBlown2");
      this.cackle = this.content.Load<SoundEffect>("audio\\caldCackle");
      this.cackle2 = this.content.Load<SoundEffect>("audio\\caldCackle2");
      this.cackle3 = this.content.Load<SoundEffect>("audio\\caldCackle3");
    }

    public void initCauldrons(int seed, ref float[,] heights)
    {
      this.explode = false;
      this.explodeTimer = 200;
      this.sc.shitContrast = 128;
      this.isFull = false;
      this.glowOnce = 0;
      this.level = 0;
      this.oldlevel = 0;
      this.c_big.max = 0;
      this.c_big.index = 0;
      this.c_base.max = 0;
      this.c_base.index = 0;
      this.c_top.max = 0;
      this.c_top.index = 0;
      this.c_ring.max = 0;
      this.c_ring.index = 0;
      this.c_leg.max = 0;
      this.c_leg.index = 0;
      this.fireball.stainMax = 0;
      this.fireball.stainIndex = 0;
      this.liquid.max = 0;
      this.liquid.index = 0;
      this.bloody.max = 0;
      this.bloody.index = 0;
      this.bloody.maxCapacity = 200;
      this.resetExplody(false);
      this.cald.max = 0;
      this.cald.type = 0;
      this.cald.index = 0;
      this.mainSeed = seed;
      this.rx = new Random(seed);
      this.dropcaldron(ref this.cald, this.rx.Next(9000, 22000), ref heights, true);
    }

    private void dropcaldron(ref cauldron.shell sh, int seed, ref float[,] heights, bool inner)
    {
      this.exists = true;
      Vector3 scal = new Vector3(1f, 1f, 1f) * ((float) this.rx.Next(70, 100) / 100f);
      this.mainScale = scal;
      Vector3 vector3 = new Vector3((float) this.rx.Next(500, 5500), 0.0f, (float) this.rx.Next(500, 5500));
      sh.dupe[sh.index].drop = 0;
      Vector3 pos = new Vector3(0.0f, 0.0f, 0.0f) + new Vector3(3000f, 0.0f, 3000f);
      float height;
      cauldron.GetHeightFast(ref heights, ref pos, out height, out Vector3 _);
      pos.Y = height;
      Matrix rotationY = Matrix.CreateRotationY((float) this.rx.Next(0, 8000) / 100f);
      sh.dupe[sh.index].init(scal, pos, rotationY, seed);
      sh.dupe[sh.index].tint = 100f;
      sh.stream[sh.index].Trans = sh.dupe[sh.index].transform;
      sh.stream[sh.index].tint = sh.dupe[sh.index].tint;
      ++sh.index;
      if (sh.index > sh.maxCapacity - 1)
        sh.index = 0;
      ++sh.max;
      if (sh.max > sh.maxCapacity - 1)
        sh.max = sh.maxCapacity;
      this.liquid.dupe[this.liquid.index].init(scal, pos, rotationY, seed);
      this.liquid.dupe[this.liquid.index].tint = 100f;
      this.liquid.stream[this.liquid.index].Trans = this.liquid.dupe[this.liquid.index].transform;
      this.liquid.stream[this.liquid.index].tint = this.liquid.dupe[this.liquid.index].tint;
      ++this.liquid.index;
      if (this.liquid.index > this.liquid.maxCapacity - 1)
        this.liquid.index = 0;
      ++this.liquid.max;
      if (this.liquid.max <= this.liquid.maxCapacity - 1)
        return;
      this.liquid.max = this.liquid.maxCapacity;
    }

    public void dropParts(ref cauldron.shell sh, int i, Matrix m, int seed, int size)
    {
      Random random = new Random(seed);
      float num1 = (float) random.Next(70, 130) / 100f;
      float ta = 50f;
      float tb = 100f;
      int boarSEED = seed;
      float num2 = 60f;
      float num3 = 1000f;
      Matrix matrix = Matrix.CreateScale(this.cald.dupe[i].scale) * this.cald.dupe[i].rot * Matrix.CreateTranslation(this.cald.dupe[i].mypos);
      Matrix startpos = m * matrix;
      sh.dupe[sh.index].tint = this.cald.dupe[i].tint;
      Vector3 vector3_1 = new Vector3((float) random.Next(-300, 300) / 220f, (float) random.Next(180, 230) / num2, (float) random.Next(-300, 300) / 220f);
      Vector3 vector3_2 = Vector3.Transform(new Vector3(0.0f, 0.0f, 0.0f), m);
      Vector3 vector3_3 = (float) random.Next(100, 300) / 30f * Vector3.Normalize(vector3_2);
      float bounce = (float) random.Next(500, 700) / 1000f;
      float grav = (float) random.Next(-180, -90) / num3;
      sh.dupe[sh.index].init2(size, 1, bounce, this.cald.dupe[i].scale, 0.34f, startpos, new Vector3(vector3_3.X + vector3_1.X, vector3_1.Y, vector3_3.Z + vector3_1.Z) * num1, true, grav, 20, ta, tb, false, false, false, boarSEED);
      sh.stream[sh.index].Trans = sh.dupe[sh.index].transform;
      sh.stream[sh.index].tint = sh.dupe[sh.index].tint;
      ++sh.index;
      if (sh.index > sh.maxCapacity - 1)
        sh.index = 0;
      ++sh.max;
      if (sh.max <= sh.maxCapacity - 1)
        return;
      sh.max = sh.maxCapacity;
    }

    public void ExplodeTrails(ref float[,] heights)
    {
      if (!this.explode)
        return;
      --this.explodeTimer;
      if (this.explodeTimer <= 0)
      {
        this.updateExplode(ref heights);
      }
      else
      {
        if (this.explodeTimer == 160)
          this.explodeSound.Play(this.sc.ev, 0.0f, 0.0f);
        if (this.explodeTimer != 5)
          return;
        this.initExplode();
      }
    }

    public void updatecaldron(
      ref cauldron.shell sh,
      float range,
      ref float[,] heights,
      Vector3 campos,
      Vector3 camlookpos,
      ref localPlayer myPlayer,
      ref Cursor genCursor,
      ref Vector2 hitVel,
      float headRot)
    {
      this.liquid.tempindex = 0;
      if (!this.exists)
        return;
      if (this.rr.Next(1, 600) < 3 && this.level >= 50)
        this.shortboil.Play(this.sc.ev, (float) this.rr.Next(-20, 20) / 100f, (float) this.rr.Next(-40, 40) / 100f);
      if (this.level < 40 && !this.explode && this.glowOnce == 0 && this.level > this.oldlevel)
      {
        this.glowcolor = new Vector3(1.5f, 0.0f, 0.0f);
        this.glowOnce = 1;
        this.glowInc = (float) this.rr.Next(20, 30) / 1000f;
        this.glowRamp = 0.0f;
        this.oldlevel = this.level;
        this.sizzle.Play(this.sc.ev, 0.0f, 0.0f);
        this.addExplosion(ref this.fireball, campos, this.discPos);
        this.addExplosion(ref this.fireball, campos, this.discPos);
        this.addExplosion(ref this.fireball, campos, this.discPos);
      }
      if (this.level > 50 && !this.explode && this.glowOnce == 0 && this.level > this.oldlevel)
      {
        this.glowcolor = new Vector3(2f, 0.0f, 0.0f);
        this.glowOnce = 1;
        this.glowInc = (float) this.rr.Next(5, 10) / 1000f;
        this.glowRamp = 0.0f;
        this.oldlevel = this.level;
        this.sizzle2.Play(this.sc.ev * MathHelper.Clamp((float) (1.0 - (Math.Sqrt((double) Vector3.DistanceSquared(myPlayer.displayState.npcPosition, new Vector3(3000f, 100f, 3000f))) - 200.0) / 4000.0), 0.2f, 0.8f), 0.0f, 0.0f);
        this.addExplosion(ref this.fireball, campos, this.discPos);
        this.addExplosion(ref this.fireball, campos, this.discPos);
        this.addExplosion(ref this.fireball, campos, this.discPos);
      }
      if (this.explode && this.explodeTimer < 180 && this.explodeTimer > -1000 && this.glowOnce == 0)
      {
        this.glowcolor = new Vector3((float) this.rr.Next(0, 50) / 100f, 0.0f, (float) this.rr.Next(80, 180) / 100f);
        this.glowOnce = 1;
        this.glowInc = (float) this.rr.Next(2, 8) / 100f;
        this.glowRamp = 0.0f;
      }
      Vector3 vector2_1 = Vector3.Normalize(camlookpos - campos);
      Vector3 vector3_1 = -vector2_1 * 100f + campos;
      range *= range;
      this.caldkinIndex = -1;
      bool flag1 = false;
      sh.tempindex = 0;
      this.alive = 0;
      --this.soundcount;
      bool flag2 = true;
      for (int index = 0; index < sh.max; ++index)
      {
        if (sh.dupe[index].move != -1)
        {
          if (this.explodeTimer <= -700 && this.exists)
            this.explodeCauldron(0, ref myPlayer, ref heights);
          if (sh.dupe[index].move == 0)
            flag2 = false;
          bool flag3 = false;
          ++this.alive;
          float result1;
          Vector3.DistanceSquared(ref myPlayer.displayState.npcPosition, ref sh.dupe[index].mypos, out result1);
          this.lightFade = 0.0f;
          if ((double) result1 < (double) range)
          {
            Vector3 vector3_2 = new Vector3(sh.dupe[index].mypos.X, sh.dupe[index].mypos.Y, sh.dupe[index].mypos.Z) - vector3_1;
            Vector3 result2;
            Vector3.Normalize(ref vector3_2, out result2);
            float result3 = 0.0f;
            Vector3.Dot(ref result2, ref vector2_1, out result3);
            if ((double) result3 > (double) this.sc.myfov)
            {
              if (myPlayer.now.flashlight)
              {
                this.lightFade = 1f - MathHelper.Clamp((float) (((double) result1 - 20000.0) / 350000.0), 0.0f, 1f);
                this.flashlightDir = Vector3.Normalize(sh.dupe[index].mypos - myPlayer.displayState.npcPosition);
                this.flashlightDir.Z *= -1f;
              }
              if (sh.dupe[index].move > 0)
                sh.dupe[index].updateCualdron();
              sh.stream[index].Trans = sh.dupe[index].transform;
              sh.stream[index].tint = sh.dupe[index].tint;
              sh.displayList[sh.tempindex] = sh.stream[index];
              ++sh.tempindex;
              flag3 = true;
              if (sh.dupe[index].pop)
              {
                if ((double) this.sc.introCamera <= 0.0)
                  this.boil.Play(this.sc.ev * MathHelper.Clamp((float) (1.0 - (Math.Sqrt((double) result1) - 200.0) / 4000.0), 0.2f, 0.8f), 0.0f, 0.0f);
                sh.dupe[index].pop = false;
              }
              if (sh.dupe[index].kickable && !flag1 && !myPlayer.isDown && !myPlayer.gunFired && (double) result1 < 10000.0 * (double) sh.dupe[index].scale.Y)
              {
                flag1 = true;
                if (this.soundcount <= 0)
                {
                  this.sound1.Play(this.sc.ev, (float) this.rr.Next(-10, 10) / 100f, 0.0f);
                  this.soundcount = 20;
                }
                Vector2 vector2_2 = new Vector2(sh.dupe[index].mypos.X, sh.dupe[index].mypos.Z) - new Vector2(myPlayer.displayState.npcPosition.X, myPlayer.displayState.npcPosition.Z);
                if ((double) vector2_2.Length() > 0.0)
                {
                  hitVel = -Vector2.Normalize(vector2_2) * 3.5f;
                  hitVel = Vector2.Transform(new Vector2(-hitVel.X, hitVel.Y), Matrix.CreateRotationZ(-headRot));
                }
              }
            }
          }
          if (sh.dupe[index].move > 0 && !flag3)
            sh.dupe[index].updateCualdron();
          sh.dupe[index].pop = false;
        }
      }
      if (!this.exists || flag2)
        return;
      if (this.level >= 1 && !this.explode)
      {
        for (int index = 0; index < this.liquid.max; ++index)
        {
          int num1 = Math.Min(this.level, 40);
          float num2 = MathHelper.Lerp(1f, 1.2f, (float) num1 / 40f);
          float num3 = MathHelper.Lerp(38f, 78f, (float) num1 / 40f) * this.liquid.dupe[index].scale.X;
          this.liquid.dupe[index].rot *= Matrix.CreateRotationY(1f / 500f);
          this.liquid.dupe[index].transform = Matrix.CreateScale(this.liquid.dupe[index].scale * num2) * this.liquid.dupe[index].rot * Matrix.CreateTranslation(this.liquid.dupe[index].mypos.X, this.liquid.dupe[index].mypos.Y + num3, this.liquid.dupe[index].mypos.Z);
          this.liquid.stream[index].Trans = this.liquid.dupe[index].transform;
          this.liquid.stream[index].tint = 100f;
          this.discPos = this.liquid.dupe[index].transform;
          this.liquid.displayList[this.liquid.tempindex] = this.liquid.stream[index];
          ++this.liquid.tempindex;
        }
        if ((double) this.sc.myTimer % 20.0 == 0.0 && this.rr.Next(Math.Min(this.level, 40), 45) > 39)
          this.addExplosion(ref this.fireball, campos, this.discPos);
      }
      this.updateExplosion(ref this.fireball, campos, this.discPos);
    }

    public void explodeCauldron(int i, ref localPlayer myPlayer, ref float[,] heights)
    {
      this.cald.dupe[i].move = -1;
      this.exists = false;
      this.level = 0;
      this.pop2.Play(this.sc.ev, (float) this.rr.Next(-10, 0) / 100f, 0.0f);
      Matrix m1 = Matrix.CreateRotationX(MathHelper.ToRadians(-14.7f)) * Matrix.CreateRotationY(MathHelper.ToRadians(26.8f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(3.5f)) * Matrix.CreateTranslation(19.6f, 24.5f, 42.6f);
      this.dropParts(ref this.c_leg, i, m1, this.cald.dupe[i].seed, 23);
      Matrix m2 = Matrix.CreateRotationX(MathHelper.ToRadians(157f)) * Matrix.CreateRotationY(MathHelper.ToRadians(36f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(175.2f)) * Matrix.CreateTranslation(25.3f, 23.8f, -33.9f);
      this.dropParts(ref this.c_leg, i, m2, this.cald.dupe[i].seed + 1, 23);
      Matrix m3 = Matrix.CreateRotationX(MathHelper.ToRadians(-162.7f)) * Matrix.CreateRotationY(MathHelper.ToRadians(-73.5f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(137f)) * Matrix.CreateTranslation(-47.7f, 24.5f, 1.57f);
      this.dropParts(ref this.c_leg, i, m3, this.cald.dupe[i].seed + 2, 23);
      Matrix m4 = Matrix.CreateRotationX(MathHelper.ToRadians(4.7f)) * Matrix.CreateRotationY(MathHelper.ToRadians(2.9f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(-2.6f)) * Matrix.CreateTranslation(-0.26f, 56.3f, 26.6f);
      this.dropParts(ref this.c_big, i, m4, this.cald.dupe[i].seed + 3, 28);
      Matrix m5 = Matrix.CreateRotationX(MathHelper.ToRadians(4.7f)) * Matrix.CreateRotationY(MathHelper.ToRadians(218f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(1.4f)) * Matrix.CreateTranslation(-21f, 56.3f, -42.7f);
      this.dropParts(ref this.c_big, i, m5, this.cald.dupe[i].seed + 4, 28);
      Matrix m6 = Matrix.CreateRotationX(MathHelper.ToRadians(-139.5f)) * Matrix.CreateRotationY(MathHelper.ToRadians(21.8f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(165.6f)) * Matrix.CreateTranslation(5.9f, 38.2f, -18.2f);
      this.dropParts(ref this.c_base, i, m6, this.cald.dupe[i].seed + 5, 24);
      Matrix m7 = Matrix.CreateRotationX(MathHelper.ToRadians(23.2f)) * Matrix.CreateRotationY(MathHelper.ToRadians(-58.4f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(26f)) * Matrix.CreateTranslation(-17.7f, 38.2f, 14.3f);
      this.dropParts(ref this.c_base, i, m7, this.cald.dupe[i].seed + 6, 24);
      Matrix m8 = Matrix.CreateRotationX(MathHelper.ToRadians(55f)) * Matrix.CreateRotationY(MathHelper.ToRadians(34f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(16.1f)) * Matrix.CreateTranslation(55f, 38.2f, 19.6f);
      this.dropParts(ref this.c_base, i, m8, this.cald.dupe[i].seed + 7, 24);
      Matrix m9 = Matrix.CreateRotationX(MathHelper.ToRadians(7.4f)) * Matrix.CreateRotationY(MathHelper.ToRadians(118f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(1.8f)) * Matrix.CreateTranslation(41.2f, 67.9f, -30.8f);
      this.dropParts(ref this.c_top, i, m9, this.cald.dupe[i].seed + 8, 19);
      Matrix m10 = Matrix.CreateRotationX(MathHelper.ToRadians(6.13f)) * Matrix.CreateRotationY(MathHelper.ToRadians(158.5f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(0.9f)) * Matrix.CreateTranslation(19.8f, 67.9f, -52.5f);
      this.dropParts(ref this.c_top, i, m10, this.cald.dupe[i].seed + 9, 19);
      Matrix m11 = Matrix.CreateRotationX(MathHelper.ToRadians(20.8f)) * Matrix.CreateRotationY(MathHelper.ToRadians(-86.6f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(-15f)) * Matrix.CreateTranslation(-48.5f, 67.9f, -5.6f);
      this.dropParts(ref this.c_top, i, m11, this.cald.dupe[i].seed + 10, 19);
      Matrix m12 = Matrix.CreateRotationX(MathHelper.ToRadians(1.8f)) * Matrix.CreateRotationY(MathHelper.ToRadians(77.8f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(-4f)) * Matrix.CreateTranslation(45.8f, 67.9f, 3.2f);
      this.dropParts(ref this.c_top, i, m12, this.cald.dupe[i].seed + 11, 19);
      Matrix m13 = Matrix.CreateRotationX(MathHelper.ToRadians(16.5f)) * Matrix.CreateRotationY(MathHelper.ToRadians(12.3f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(-88.4f)) * Matrix.CreateTranslation(-12f, 45.5f, 36.7f);
      this.dropParts(ref this.c_ring, i, m13, this.cald.dupe[i].seed + 12, 21);
      Matrix m14 = Matrix.CreateRotationX(MathHelper.ToRadians(-98f)) * Matrix.CreateRotationY(MathHelper.ToRadians(-3.7f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(-101.8f)) * Matrix.CreateTranslation(36.9f, 45.5f, -1.4f);
      this.dropParts(ref this.c_ring, i, m14, this.cald.dupe[i].seed + 13, 21);
      Matrix m15 = Matrix.CreateRotationX(MathHelper.ToRadians(119f)) * Matrix.CreateRotationY(MathHelper.ToRadians(-4.3f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(-78.4f)) * Matrix.CreateTranslation(-29.5f, 45.5f, -20.5f);
      this.dropParts(ref this.c_ring, i, m15, this.cald.dupe[i].seed + 14, 21);
    }

    public void updatecaldronParts(
      ref cauldron.shell sh,
      float range,
      ref float[,] heights,
      Vector3 campos,
      Vector3 camlookpos,
      ref localPlayer myPlayer,
      ref Cursor genCursor)
    {
      Vector3 vector2 = Vector3.Normalize(camlookpos - campos);
      Vector3 vector3_1 = -vector2 * 100f + campos;
      range *= range;
      sh.tempindex = 0;
      int num = 0;
      for (int index = 0; index < sh.max; ++index)
      {
        if (sh.dupe[index].move != -1)
        {
          ++num;
          bool flag = false;
          float result1;
          Vector3.DistanceSquared(ref myPlayer.displayState.npcPosition, ref sh.dupe[index].mypos, out result1);
          if ((double) result1 < (double) range)
          {
            Vector3 vector3_2 = new Vector3(sh.dupe[index].mypos.X, sh.dupe[index].mypos.Y, sh.dupe[index].mypos.Z) - vector3_1;
            Vector3 result2;
            Vector3.Normalize(ref vector3_2, out result2);
            float result3 = 0.0f;
            Vector3.Dot(ref result2, ref vector2, out result3);
            if ((double) result3 > (double) this.sc.myfov)
            {
              if (sh.dupe[index].move > 0)
                sh.dupe[index].Update(ref heights);
              sh.stream[index].Trans = sh.dupe[index].transform;
              sh.stream[index].tint = sh.dupe[index].tint;
              sh.displayList[sh.tempindex] = sh.stream[index];
              ++sh.tempindex;
              flag = true;
            }
          }
          if (sh.dupe[index].move > 0 && !flag)
            sh.dupe[index].Update(ref heights);
        }
      }
      if (num != 0)
        return;
      sh.max = 0;
      sh.index = 0;
    }

    private void addExplosion(ref cauldron.hole hole, Vector3 campos, Matrix pp)
    {
      hole.location[hole.stainIndex] = new Vector3((float) this.rr.Next(-100, 100) / 20f, (float) this.rr.Next(-120, -60) / 10f, (float) this.rr.Next(-100, 100) / 20f);
      Vector3 objectPosition = Vector3.Transform(Vector3.Zero, Matrix.CreateTranslation(hole.location[hole.stainIndex]) * pp);
      Matrix billboard = Matrix.CreateBillboard(objectPosition, new Vector3(campos.X, (float) (((double) campos.Y - (double) objectPosition.Y) / 2.0), campos.Z), this.view.Up, new Vector3?(this.view.Forward));
      Vector3 scales = new Vector3(340f, 700f, 340f) * (float) this.rr.Next(70, 160) / 600f;
      hole.scale[hole.stainIndex] = this.rr.Next(1, 100) >= 50 ? Matrix.CreateScale(scales) * Matrix.CreateRotationY(3.14f) * Matrix.CreateRotationZ((float) this.rr.Next(-5, 5) / 100f) : Matrix.CreateScale(scales) * Matrix.CreateRotationZ((float) this.rr.Next(-5, 5) / 100f);
      hole.stainTrans[hole.stainIndex].Trans = hole.scale[hole.stainIndex] * billboard;
      hole.fade[hole.stainIndex] = (float) this.rr.Next(80, 100) / 100f;
      hole.stainTrans[hole.stainIndex].Fade = hole.fade[hole.stainIndex];
      Vector4 vector4 = hole.stainR[0];
      hole.stainTrans[hole.stainIndex].Coord = new Vector4(1864f / vector4.Z, vector4.X / 1864f, 1200f / vector4.W, vector4.Y / 1200f);
      hole.frame[hole.stainIndex] = 0;
      ++hole.stainIndex;
      if (hole.stainIndex > hole.stainCapacity - 1)
        hole.stainIndex = 0;
      ++hole.stainMax;
      if (hole.stainMax <= hole.stainCapacity - 1)
        return;
      hole.stainMax = hole.stainCapacity;
    }

    private void updateExplosion(ref cauldron.hole hole, Vector3 campos, Matrix pp)
    {
      bool flag = false;
      for (int index = 0; index < hole.stainMax; ++index)
      {
        ++hole.frame[index];
        if (hole.frame[index] > hole.stainR.Length - 1)
        {
          hole.frame[index] = hole.stainR.Length - 1;
        }
        else
        {
          hole.location[index] += new Vector3(0.0f, -0.01f, 0.0f);
          Vector3 objectPosition = Vector3.Transform(Vector3.Zero, Matrix.CreateTranslation(hole.location[index]) * pp);
          Matrix billboard = Matrix.CreateBillboard(objectPosition, new Vector3(campos.X, (float) (((double) campos.Y - (double) objectPosition.Y) / 2.0), campos.Z), this.view.Up, new Vector3?(this.view.Forward));
          hole.stainTrans[index].Trans = hole.scale[index] * billboard;
          Vector4 vector4 = hole.stainR[hole.frame[index]];
          hole.stainTrans[index].Coord = new Vector4(1864f / vector4.Z, vector4.X / 1864f, 1200f / vector4.W, vector4.Y / 1200f);
          hole.stainTrans[index].Fade = hole.fade[index];
          flag = true;
        }
      }
      if (flag)
        return;
      hole.stainIndex = 0;
      hole.stainMax = 0;
    }

    public void draw(Matrix view, Matrix proj)
    {
      this.view = view;
      this.proj = proj;
      Vector3 diff = new Vector3(0.8f, 0.8f, 0.8f);
      Vector3 amb1 = new Vector3(0.2f, 0.2f, 0.2f);
      Vector3 amb2 = amb1;
      if (this.glowOnce > 0)
      {
        amb2 = Vector3.Lerp(amb1, this.glowcolor, this.glowRamp);
        this.glowRamp += this.glowInc;
        if ((double) this.glowRamp >= 1.0)
        {
          this.glowOnce = 2;
          this.glowInc *= -1f;
        }
        if ((double) this.glowRamp < 0.0)
          this.glowOnce = 0;
      }
      if (this.exists)
      {
        if ((double) this.lightFade == 0.0)
          this.DrawInstance(ref this.cald, "fastShader2", diff, amb2);
        else
          this.DrawInstanceLight(ref this.cald, nameof (cauldron), diff, amb2);
        if (!this.explode)
          this.DrawInstance(ref this.liquid, "brightshader", diff, amb1);
      }
      this.DrawInstance(ref this.c_leg, "fastShader2", diff, amb1);
      this.DrawInstance(ref this.c_big, "fastShader2", diff, amb1);
      this.DrawInstance(ref this.c_base, "fastShader2", diff, amb1);
      this.DrawInstance(ref this.c_top, "fastShader2", diff, amb1);
      this.DrawInstance(ref this.c_ring, "fastShader2", diff, amb1);
    }

    private void DrawInstanceLight(
      ref cauldron.shell shell,
      string tech,
      Vector3 diff,
      Vector3 amb)
    {
      int tempindex = shell.tempindex;
      if (tempindex < 1)
        return;
      ModelMeshPart meshPart = shell.model1.Meshes[0].MeshParts[0];
      shell.buffer.SetData<cauldron.instancedObject>(shell.displayList, 0, tempindex, SetDataOptions.Discard);
      Effect effect = meshPart.Effect;
      effect.CurrentTechnique = effect.Techniques[tech];
      Vector3 vector3 = Vector3.Normalize(this.sc.moontype) with
      {
        Y = -0.8f
      };
      effect.Parameters["FlashLightDirection"].SetValue(this.flashlightDir);
      effect.Parameters["dimmer"].SetValue(this.lightFade);
      effect.Parameters["LightDirection2"].SetValue(vector3);
      effect.Parameters["diff2"].SetValue(diff);
      effect.Parameters["amb2"].SetValue(amb);
      effect.Parameters["View"].SetValue(this.view);
      effect.Parameters["Projection"].SetValue(this.proj);
      effect.CurrentTechnique.Passes[0].Apply();
      this._vertexBufferBindings[0] = new VertexBufferBinding(meshPart.VertexBuffer, meshPart.VertexOffset, 0);
      this._vertexBufferBindings[1] = new VertexBufferBinding((VertexBuffer) shell.buffer, 0, 1);
      this.sc.GraphicsDevice.SetVertexBuffers(this._vertexBufferBindings);
      this.sc.GraphicsDevice.Indices = meshPart.IndexBuffer;
      this.sc.GraphicsDevice.DrawInstancedPrimitives(PrimitiveType.TriangleList, 0, 0, meshPart.NumVertices, meshPart.StartIndex, meshPart.PrimitiveCount, tempindex);
    }

    private void DrawInstance(ref cauldron.shell shell, string tech, Vector3 diff, Vector3 amb)
    {
      int tempindex = shell.tempindex;
      if (tempindex < 1)
        return;
      ModelMeshPart meshPart = shell.model1.Meshes[0].MeshParts[0];
      shell.buffer.SetData<cauldron.instancedObject>(shell.displayList, 0, tempindex, SetDataOptions.Discard);
      Effect effect = meshPart.Effect;
      effect.CurrentTechnique = effect.Techniques[tech];
      Vector3 vector3 = Vector3.Normalize(this.sc.moontype) with
      {
        Y = -0.8f
      };
      effect.Parameters["LightDirection2"].SetValue(vector3);
      effect.Parameters["diff2"].SetValue(diff);
      effect.Parameters["amb2"].SetValue(amb);
      effect.Parameters["View"].SetValue(this.view);
      effect.Parameters["Projection"].SetValue(this.proj);
      effect.CurrentTechnique.Passes[0].Apply();
      this._vertexBufferBindings[0] = new VertexBufferBinding(meshPart.VertexBuffer, meshPart.VertexOffset, 0);
      this._vertexBufferBindings[1] = new VertexBufferBinding((VertexBuffer) shell.buffer, 0, 1);
      this.sc.GraphicsDevice.SetVertexBuffers(this._vertexBufferBindings);
      this.sc.GraphicsDevice.Indices = meshPart.IndexBuffer;
      this.sc.GraphicsDevice.DrawInstancedPrimitives(PrimitiveType.TriangleList, 0, 0, meshPart.NumVertices, meshPart.StartIndex, meshPart.PrimitiveCount, tempindex);
    }

    public void DrawFireBall()
    {
      if (!this.exists || this.explode)
        return;
      this.sc.GraphicsDevice.BlendState = BlendState.Additive;
      this.sc.GraphicsDevice.RasterizerState = RasterizerState.CullNone;
      this.sc.GraphicsDevice.DepthStencilState = DepthStencilState.DepthRead;
      this.DrawGrenadeExplosion(ref this.fireball, Matrix.Identity);
      this.sc.GraphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;
    }

    private void DrawGrenadeExplosion(ref cauldron.hole hole, Matrix world)
    {
      int stainMax = hole.stainMax;
      if (stainMax < 1)
        return;
      ModelMeshPart meshPart = this.sc.fireballDecal2.Meshes[0].MeshParts[0];
      hole.stainBuffer.SetData<cauldron.hitStream>(hole.stainTrans, 0, stainMax, SetDataOptions.Discard);
      Effect effect = meshPart.Effect;
      effect.CurrentTechnique = effect.Techniques["premultiply"];
      effect.Parameters["World1"].SetValue(world);
      effect.Parameters["View"].SetValue(this.view);
      effect.Parameters["Projection"].SetValue(this.proj);
      effect.CurrentTechnique.Passes[0].Apply();
      this._vertexBufferBindings[0] = new VertexBufferBinding(meshPart.VertexBuffer, meshPart.VertexOffset, 0);
      this._vertexBufferBindings[1] = new VertexBufferBinding((VertexBuffer) hole.stainBuffer, 0, 1);
      this.sc.GraphicsDevice.SetVertexBuffers(this._vertexBufferBindings);
      this.sc.GraphicsDevice.Indices = meshPart.IndexBuffer;
      this.sc.GraphicsDevice.DrawInstancedPrimitives(PrimitiveType.TriangleList, 0, 0, meshPart.NumVertices, meshPart.StartIndex, meshPart.PrimitiveCount, stainMax);
    }

    public void resetExplody(bool death)
    {
      int length = this.bloody.maxCapacity - 1;
      this.explodePart = new Matrix[length];
      Random random = new Random(this.mainSeed);
      for (int index = 0; index < length; ++index)
        this.explodePart[index] = Matrix.CreateScale(new Vector3((float) random.Next(100, 400) / 10f, (float) random.Next(300, 1200) / 10f, (float) random.Next(100, 400) / 10f)) * Matrix.CreateTranslation((float) random.Next(-200, 200) / 10f, (float) random.Next(0, 280) / 12f, (float) random.Next(-200, 200) / 10f);
      int mainSeed = this.mainSeed;
      for (int index = 0; index < length; ++index)
      {
        this.bloody.dupe[index] = new explodeDupe2(mainSeed + index);
        ++mainSeed;
      }
      this.bloody.max = length;
    }

    public void initExplode()
    {
      float num1 = 1f;
      Random random = new Random();
      float y = (float) random.Next(-4500, -2200) / 100f;
      num1 = (float) random.Next(90, 195) / 100f;
      float reality = 1.1f;
      Vector3 vector3_1 = new Vector3((float) random.Next(-40, 40) / 200f, (float) random.Next(-20, 20) / 100f, (float) random.Next(-40, 40) / 200f);
      for (int index = 0; index < this.explodePart.Length; ++index)
      {
        float num2 = (float) random.Next(410, 510) / 100f;
        this.explodePart[index] = this.explodePart[index] * Matrix.CreateScale(this.mainScale.X) * Matrix.CreateRotationY(0.0f) * Matrix.CreateTranslation(new Vector3(3000f, 0.0f, 3000f));
        Vector3 vector3_2 = Vector3.Transform(Vector3.Zero, this.explodePart[index]) - new Vector3(3000f, y, 3000f);
        this.bloody.dupe[index].createState(this.explodePart[index], (vector3_1 + Vector3.Normalize(vector3_2)) * num2, this.mainScale.X, reality);
      }
    }

    private void updateExplode(ref float[,] heights)
    {
      this.bloody.tempindex = 0;
      for (int index = 0; index < this.bloody.max; ++index)
      {
        if (this.bloody.dupe[index].move == 1)
        {
          this.bloody.dupe[index].Update(ref heights);
          this.bloody.stream[index].Trans = this.bloody.dupe[index].transform;
          this.bloody.displayList[this.bloody.tempindex] = this.bloody.stream[index];
          ++this.bloody.tempindex;
          if ((double) this.sc.myTimer % 4.0 == 0.0 && this.bloody.dupe[index].age > 1500)
          {
            if ((double) Math.Abs(this.bloody.dupe[index].mypos.X) > 7000.0 || (double) Math.Abs(this.bloody.dupe[index].mypos.Z) > 7000.0)
              this.bloody.dupe[index].move = 0;
            this.bloody.dupe[index].scalePart *= 0.97f;
            this.bloody.dupe[index].myscale *= 0.97f;
            if (this.bloody.dupe[index].age > 2100)
            {
              this.bloody.dupe[index].move = 0;
              this.explodeTimer = 200;
              this.explode = false;
              this.level = 0;
            }
          }
        }
      }
      if (this.bloody.tempindex >= 4 && this.explode)
        return;
      this.bloody.index = 0;
      this.bloody.max = 0;
    }

    private static void GetHeightFast(
      ref float[,] heights,
      ref Vector3 pos,
      out float height,
      out Vector3 normal)
    {
      int index1 = (int) MathHelper.Clamp(pos.X / cauldron.unit, 0.0f, (float) (cauldron.bitmap - 2));
      int index2 = (int) MathHelper.Clamp(pos.Z / cauldron.unit, 0.0f, (float) (cauldron.bitmap - 2));
      float num1 = pos.X % cauldron.unit / cauldron.unit;
      float num2 = pos.Z % cauldron.unit / cauldron.unit;
      float num3 = (float) ((1.0 - (double) num1) * (double) heights[index1, index2] + (double) num1 * (double) heights[index1 + 1, index2]);
      float num4 = (float) ((1.0 - (double) num1) * (double) heights[index1, index2 + 1] + (double) num1 * (double) heights[index1 + 1, index2 + 1]);
      height = (float) ((1.0 - (double) num2) * (double) num3 + (double) num2 * (double) num4);
      normal = Vector3.Normalize(new Vector3(-heights[index1 + 1, index2] + heights[index1, index2], 30f, -heights[index1, index2 + 1] + heights[index1, index2]));
    }

    public struct finale
    {
      public int max;
      public int tempindex;
      public int index;
      public int maxCapacity;
      public cauldron.instancedObject[] stream;
      public DynamicVertexBuffer buffer;
      public cauldron.instancedObject[] displayList;
      public explodeDupe2[] dupe;
      public Model model;
    }

    public struct hitStream : IVertexType
    {
      public Matrix Trans;
      public float Fade;
      public Vector4 Coord;
      private static readonly VertexDeclaration VertexDeclaration = new VertexDeclaration(new VertexElement[6]
      {
        new VertexElement(0, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 0),
        new VertexElement(16, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 1),
        new VertexElement(32, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 2),
        new VertexElement(48, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 3),
        new VertexElement(64, VertexElementFormat.Single, VertexElementUsage.Fog, 0),
        new VertexElement(68, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 4)
      });

      VertexDeclaration IVertexType.VertexDeclaration => cauldron.hitStream.VertexDeclaration;
    }

    public struct hole
    {
      public float[] fade;
      public Vector3[] location;
      public int[] bone;
      public cauldron.hitStream[] stainTrans;
      public int[] frame;
      public Matrix[] scale;
      public int stainIndex;
      public int stainMax;
      public int stainCapacity;
      public DynamicVertexBuffer stainBuffer;
      public Vector4[] stainR;
    }

    public struct instancedObject : IVertexType
    {
      public Matrix Trans;
      public float tint;
      private static readonly VertexDeclaration InstanceVertexDeclaration = new VertexDeclaration(new VertexElement[5]
      {
        new VertexElement(0, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 0),
        new VertexElement(16, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 1),
        new VertexElement(32, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 2),
        new VertexElement(48, VertexElementFormat.Vector4, VertexElementUsage.BlendWeight, 3),
        new VertexElement(64, VertexElementFormat.Single, VertexElementUsage.Fog, 0)
      });

      VertexDeclaration IVertexType.VertexDeclaration
      {
        get => cauldron.instancedObject.InstanceVertexDeclaration;
      }
    }

    public struct shell
    {
      public int type;
      public int drop;
      public int max;
      public int tempindex;
      public int index;
      public int maxCapacity;
      public cauldron.instancedObject[] stream;
      public DynamicVertexBuffer buffer;
      public cauldron.instancedObject[] displayList;
      public caldDupe[] dupe;
      public Model model1;
    }
  }
}
