using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Globalization;
using System.IO;

#pragma warning disable CS0649
#pragma warning disable CS0169
#nullable disable
namespace Blood
{
  internal class Lander : GameScreen
  {
    private Vector2 ggO = Vector2.Zero;
    public bool radioFixed;
    public float mytimer;
    public static Vector3 farmLocation = Vector3.Zero;
    public static bool nearfarm = false;
    private KeyboardState keyState;
    private KeyboardState prevkeyState;
    private MouseState mouseState;
    private MouseState prevMouse;
    public float curve = 0.5f;
    public float origthrust = 1.5f;
    public float thrust = 1.5f;
    private float maxspeed = 250f;
    private float gravity = -0.65f;
    private float terminalveloc = -365f;
    public bool onDropship;
    public bool insideDropship;
    public Vector3 position = new Vector3(4000f, 0.0f, 2000f);
    public Vector3 dropshipVeloc;
    public Vector3 dropship;
    private Vector3 reflectnormal;
    public float landerDirectionX;
    public float landerDirectionZ;
    public float shieldhit;
    private Vector3 lasthite;
    private Vector3 landerBottom;
    public Vector3 surface;
    public int bitmap;
    public float gridScale;
    private float rayDistance = 5f;
    private float heightmapWidth;
    private float turnAmountZ;
    private float turnAmountX;
    public Vector3 orbitPos = new Vector3(0.0f, 0.0f, 0.0f);
    private Model model;
    private Vector3 newPosition;
    public float waterlevel;
    public float camrot;
    private int flameFlag = 1;
    public Vector3 ground;
    public float lscale;
    public float lander2ground;
    public Matrix orientation = Matrix.Identity;
    private Matrix orientationx = Matrix.Identity;
    private Matrix lastorientation = Matrix.Identity;
    private Matrix wheelRollMatrix = Matrix.Identity;
    private Matrix flameMatrix = Matrix.Identity;
    public float gemmax = 1f;
    public int gems;
    public Vector3 movement;
    public Vector3 velocity = Vector3.Zero;
    public Vector3 normal;
    public float maxthrust = 1.6f;
    public float speed;
    public float normalizedSpeed;
    private ModelBone podBone;
    private ModelBone doorBone;
    private ModelBone modelBone_0;
    private ModelBone flameBone;
    private Matrix podTransform;
    private Matrix doorTransform;
    private Matrix door2Transform;
    private Matrix flameTransform;
    public int commandFlag;
    public int rampSwitch;
    public int door1 = 1;
    private float doorVar1;
    private float doorVar2;
    public int impact;
    public float diff = 80f;
    private float offset = 60f;
    private float movedistx;
    private Vector3 deltax;
    private float movedist1;
    private Vector3 delta1 = new Vector3(1f, 0.0f, 0.0f);
    private Vector3 grav = Vector3.Zero;
    private GraphicsDevice device;
    public int vi;
    public int shockhit;
    public float directme = 3f;
    public int[,] allheights;
    public int vbi;
    public Vector3 goof = Vector3.Zero;
    public int dentme;
    public int dentme2;
    private int dentpercent;
    public int dentpercent2;
    public float[] region1 = new float[15];
    public float[] region2 = new float[15];
    public float rightTrigger;
    public float leftTrigger;
    private float reducer;
    private Vector3 directLight = Vector3.Zero;
    public Vector3 amb = new Vector3(0.3f, 0.3f, 0.3f);
    public Vector3 diffu = new Vector3(1.2f, 1.1f, 1f);
    private Matrix[] boneTransforms;
    private float[] rFlame = new float[8]
    {
      0.6f,
      0.82f,
      0.63f,
      0.79f,
      0.62f,
      0.82f,
      0.65f,
      0.82f
    };
    private Vector3[] rAmbient = new Vector3[6]
    {
      new Vector3(0.2f, 0.2f, 1f),
      new Vector3(0.5f, 1f, 0.7f),
      new Vector3(0.3f, 2f, 0.6f),
      new Vector3(0.5f, 0.9f, 0.2f),
      new Vector3(0.6f, 0.4f, 1.6f),
      new Vector3(1f, 1f, 0.7f)
    };
    private int rrcount;
    public int altitude;
    public float[,] drophite;
    private ScreenManager sc;
    private ContentManager content;

    public void LoadContent(ContentManager content, ScreenManager screenManager)
    {
      this.sc = screenManager;
      this.content = content;
      this.device = screenManager.GraphicsDevice;
      this.model = content.Load<Model>("astro\\models\\Lander");
      this.podBone = this.model.Bones["pod"];
      this.doorBone = this.model.Bones["door"];
      this.modelBone_0 = this.model.Bones["door2"];
      this.flameBone = this.model.Bones["flame"];
      this.flameTransform = this.flameBone.Transform;
      this.podTransform = this.podBone.Transform;
      this.doorTransform = this.doorBone.Transform;
      this.door2Transform = this.modelBone_0.Transform;
      this.orientation = Matrix.CreateRotationY(10f);
      this.orientation.Up = Vector3.Up;
      this.orientation.Right = Vector3.Cross(this.orientation.Forward, this.orientation.Up);
      this.orientation.Right = Vector3.Normalize(this.orientation.Right);
      this.orientation.Forward = Vector3.Cross(this.orientation.Up, this.orientation.Right);
      this.orientation.Forward = Vector3.Normalize(this.orientation.Forward);
      this.lastorientation = this.orientation;
      this.drophite = new float[81, 81];
      CultureInfo invariantCulture = CultureInfo.InvariantCulture;
      StreamReader streamReader = new StreamReader("Content/astro/text/dropHite.txt");
      for (int index1 = 0; index1 < 81; ++index1)
      {
        for (int index2 = 0; index2 < 81; ++index2)
        {
          this.drophite[index2, 80 - index1] = Convert.ToSingle(streamReader.ReadLine(), (IFormatProvider) invariantCulture);
          this.drophite[index2, 80 - index1] *= 5f;
        }
      }
      streamReader.Close();
      streamReader.Dispose();
      this.boneTransforms = new Matrix[this.model.Bones.Count];
    }

    public override void UnloadContent() => this.content.Unload();

    private bool IntersectRayVsBox(
      BoundingBox a_kBox,
      Ray a_kRay,
      out float a_fDist,
      out Vector3 normal)
    {
      normal = Vector3.Down;
      a_fDist = float.MaxValue;
      float? nullable = a_kRay.Intersects(a_kBox);
      if (!nullable.HasValue)
        return false;
      a_fDist = nullable.Value;
      Vector3 vector3_1 = a_kRay.Position + a_kRay.Direction * a_fDist;
      Vector3 vector3_2 = vector3_1 - a_kBox.Min;
      Vector3 vector3_3 = vector3_1 - a_kBox.Max;
      vector3_2.X = Math.Abs(vector3_2.X);
      vector3_2.Y = Math.Abs(vector3_2.Y);
      vector3_2.Z = Math.Abs(vector3_2.Z);
      vector3_3.X = Math.Abs(vector3_3.X);
      vector3_3.Y = Math.Abs(vector3_3.Y);
      vector3_3.Z = Math.Abs(vector3_3.Z);
      normal = Vector3.Left;
      float num = vector3_2.X;
      if ((double) vector3_3.X < (double) num)
      {
        num = vector3_3.X;
        normal = Vector3.Right;
      }
      if ((double) vector3_2.Y < (double) num)
      {
        num = vector3_2.Y;
        normal = Vector3.Down;
      }
      if ((double) vector3_3.Y < (double) num)
      {
        num = vector3_3.Y;
        normal = Vector3.Up;
      }
      if ((double) vector3_2.Z < (double) num)
      {
        num = vector3_2.Z;
        normal = Vector3.Forward;
      }
      if ((double) vector3_3.Z < (double) num)
      {
        float z = vector3_2.Z;
        normal = Vector3.Backward;
      }
      return true;
    }

    public void collideDropship(Vector3 newPosition)
    {
      Vector3 min1 = new Vector3(-51f, -112f, 237f) * 5f + this.dropship;
      Vector3 max1 = new Vector3(51f, 96f, 797f) * 5f + this.dropship;
      Vector3 min2 = new Vector3(-102f, -35f, -673f) * 5f + this.dropship;
      Vector3 max2 = new Vector3(102f, 136f, -112f) * 5f + this.dropship;
      Vector3 min3 = new Vector3(-388f, -21f, -209f) * 5f + this.dropship;
      Vector3 max3 = new Vector3(374f, 76f, -15f) * 5f + this.dropship;
      Vector3 min4 = new Vector3(-115f, (float) sbyte.MinValue, -387f) * 5f + this.dropship;
      Vector3 max4 = new Vector3(115f, 92f, 273f) * 5f + this.dropship;
      Vector3 min5 = new Vector3(-394.79f, -59f, -407.92f) * 5f + this.dropship;
      Vector3 max5 = new Vector3(-318.86f, 91f, 56.31f) * 5f + this.dropship;
      Vector3 min6 = new Vector3(311.73f, -59f, -407.92f) * 5f + this.dropship;
      Vector3 max6 = new Vector3(387.67f, 91f, 56.31f) * 5f + this.dropship;
      if (this.abovedropship(min1, max1) || this.abovedropship(min2, max2) || this.abovedropship(min3, max3) || this.abovedropship(min4, max4) || this.abovedropship(min5, max5) || this.abovedropship(min6, max6) || this.onDropship || this.boxcollide(min1, max1) || this.boxcollide(min2, max2) || this.boxcollide(min3, max3) || this.boxcollide(min4, max4) || this.boxcollide(min5, max5))
        return;
      this.boxcollide(min6, max6);
    }

    public bool abovedropship(Vector3 min, Vector3 max)
    {
      if (this.onDropship || (double) this.newPosition.X <= (double) min.X || (double) this.newPosition.X >= (double) max.X || (double) this.newPosition.Z <= (double) min.Z || (double) this.newPosition.Z >= (double) max.Z || (double) this.newPosition.Y <= (double) max.Y)
        return false;
      this.onDropship = true;
      this.impact = 0;
      return true;
    }

    public bool boxcollide(Vector3 min, Vector3 max)
    {
      if (!this.onDropship)
      {
        BoundingBox a_kBox = new BoundingBox(min, max);
        if (a_kBox.Intersects(new BoundingSphere(this.newPosition, 230f)))
        {
          float a_fDist = 9000f;
          Vector3 vector3 = this.velocity;
          if ((double) this.velocity.Length() <= 0.10000000149011612)
            vector3 = this.dropship - this.newPosition;
          Vector3 direction = Vector3.Normalize(vector3);
          Ray a_kRay = new Ray(this.newPosition, direction);
          this.IntersectRayVsBox(a_kBox, a_kRay, out a_fDist, out this.reflectnormal);
          if ((double) a_fDist < 230.0)
          {
            this.impact = 5;
            float num = MathHelper.Max(20f, this.velocity.Length() * 0.6f);
            if ((double) num == 20.0)
              this.reflectnormal *= 20f;
            else
              this.reflectnormal = Vector3.Reflect(num * direction, this.reflectnormal);
            return true;
          }
        }
      }
      return false;
    }

    public bool KMdown(Keys k)
    {
      bool flag;
      switch (k)
      {
        case Keys.Print:
          flag = this.mouseState.XButton1 == ButtonState.Pressed;
          break;
        case Keys.PrintScreen:
          flag = this.mouseState.XButton2 == ButtonState.Pressed;
          break;
        case Keys.VolumeMute:
          flag = this.mouseState.MiddleButton == ButtonState.Pressed;
          break;
        case Keys.VolumeDown:
          flag = this.mouseState.LeftButton == ButtonState.Pressed;
          break;
        case Keys.VolumeUp:
          flag = this.mouseState.RightButton == ButtonState.Pressed;
          break;
        default:
          flag = this.keyState.IsKeyDown(k);
          break;
      }
      return flag;
    }

    public bool method_0(Keys k)
    {
      bool flag;
      switch (k)
      {
        case Keys.Print:
          flag = this.prevMouse.XButton1 == ButtonState.Released;
          break;
        case Keys.PrintScreen:
          flag = this.prevMouse.XButton2 == ButtonState.Released;
          break;
        case Keys.VolumeMute:
          flag = this.prevMouse.MiddleButton == ButtonState.Released;
          break;
        case Keys.VolumeDown:
          flag = this.prevMouse.LeftButton == ButtonState.Released;
          break;
        case Keys.VolumeUp:
          flag = this.prevMouse.RightButton == ButtonState.Released;
          break;
        default:
          flag = this.prevkeyState.IsKeyUp(k);
          break;
      }
      return flag;
    }

    public bool KMtoggle(Keys k)
    {
      bool flag;
      switch (k)
      {
        case Keys.Print:
          flag = this.mouseState.XButton1 == ButtonState.Pressed && this.prevMouse.XButton1 == ButtonState.Released;
          break;
        case Keys.PrintScreen:
          flag = this.mouseState.XButton2 == ButtonState.Pressed && this.prevMouse.XButton2 == ButtonState.Released;
          break;
        case Keys.VolumeMute:
          flag = this.mouseState.MiddleButton == ButtonState.Pressed && this.prevMouse.MiddleButton == ButtonState.Released;
          break;
        case Keys.VolumeDown:
          flag = this.mouseState.LeftButton == ButtonState.Pressed && this.prevMouse.LeftButton == ButtonState.Released;
          break;
        case Keys.VolumeUp:
          flag = this.mouseState.RightButton == ButtonState.Pressed && this.prevMouse.RightButton == ButtonState.Released;
          break;
        default:
          flag = this.keyState.IsKeyDown(k) && this.prevkeyState.IsKeyUp(k);
          break;
      }
      return flag;
    }

    public bool Ktoggle(Keys k) => this.keyState.IsKeyDown(k) && this.prevkeyState.IsKeyUp(k);

    public void HandleInput(
      ref MouseState mouse,
      ref MouseState prevmouse,
      ref KeyboardState keystate,
      ref KeyboardState prevkeystate,
      ref GamePadState currentGamePadState,
      ref int[,] heightData,
      ref Vector3[,] normals)
    {
      this.mouseState = mouse;
      this.prevMouse = prevmouse;
      this.keyState = keystate;
      this.prevkeyState = prevkeystate;
      ++this.rrcount;
      if (this.dentme == 1)
      {
        this.dentmex();
        this.dentme = 0;
      }
      if (this.dentme2 == 1)
      {
        this.dentmex2();
        this.dentme2 = 0;
      }
      this.allheights = heightData;
      this.gemmax = 1f;
      this.leftTrigger = 0.0f;
      if (this.door1 == 1)
      {
        if (!this.sc.usingMouse)
        {
          this.rightTrigger = currentGamePadState.Triggers.Right;
          this.leftTrigger = currentGamePadState.Triggers.Left;
          this.rightTrigger = (float) Math.Pow((double) this.rightTrigger, (double) this.curve);
        }
        else
        {
          if (this.KMdown(this.sc.lmb_key))
          {
            this.rightTrigger += 0.01f;
            this.rightTrigger = (float) Math.Pow((double) this.rightTrigger, 0.8);
            if ((double) this.rightTrigger > 1.0)
              this.rightTrigger = 1f;
          }
          else
          {
            if ((double) this.diff > 100.0)
              this.rightTrigger -= 0.01f;
            else
              this.rightTrigger -= 0.05f;
            if ((double) this.rightTrigger < 0.0)
              this.rightTrigger = 0.0f;
          }
          if (this.KMdown(this.sc.rmb_key))
          {
            if (this.impact == 1 && (double) this.diff <= 40.0)
              this.leftTrigger = 1f;
          }
          else
            this.leftTrigger = 0.0f;
        }
      }
      else
      {
        this.leftTrigger = 0.0f;
        this.rightTrigger = 0.0f;
      }
      this.lscale = (float) ((double) this.normalizedSpeed * (double) this.rFlame[this.rrcount % this.rFlame.Length] + 0.5);
      if ((double) this.rightTrigger <= 0.0)
        this.lscale = 0.0f;
      this.movement = Vector3.Zero;
      if ((double) this.rightTrigger > 0.0)
      {
        this.speed = this.rightTrigger * this.thrust;
        this.normalizedSpeed = this.speed / this.maxthrust;
        this.flameFlag = 1;
      }
      else
      {
        this.speed = 0.0f;
        this.normalizedSpeed = 0.0f;
        this.flameFlag = 0;
      }
      this.movement.Y = this.speed;
      this.newPosition = this.position + this.velocity;
      this.landerBottom = this.newPosition + Vector3.Transform(new Vector3(0.0f, -155f, 0.0f), this.orientation);
      this.surface.X = this.landerBottom.X;
      this.surface.Z = this.landerBottom.Z;
      this.onDropship = false;
      if (this.insideDropship)
        this.collideDropship(this.newPosition);
      if (!this.onDropship)
      {
        this.GetHeightAndNormal(ref heightData, ref normals, this.surface, out this.surface.Y, out this.normal);
        this.altitude = (int) ((double) this.position.Y - (double) this.surface.Y);
      }
      else
      {
        this.ShipHeightandNormal(this.surface, out this.surface.Y, out this.normal);
        float height;
        this.GetHeight(ref heightData, this.surface, out height);
        this.altitude = (int) ((double) this.position.Y - (double) height);
      }
      --this.shieldhit;
      Vector3 vector3_1 = new Vector3(Facility.offset.X + 2200f, Facility.offset.Y + 360f, Facility.offset.Z + 4050f);
      if ((double) Vector3.DistanceSquared(vector3_1, this.position) < 384400.0)
      {
        Vector3 vector3_2 = Vector3.Zero;
        Vector3 vector3_3 = this.position - vector3_1;
        if ((double) vector3_3.LengthSquared() > 0.0)
          vector3_2 = Vector3.Normalize(vector3_3);
        this.shockhit = 30;
        this.shieldhit = 120f;
        float num = this.velocity.Length();
        if ((double) num < 10.0)
          num = 10f;
        this.velocity = vector3_2 * num;
      }
      this.velocity += Vector3.Transform(this.movement, this.orientation) + new Vector3(0.0f, this.gravity, 0.0f);
      if ((double) this.position.Y > 9000.0 + (double) this.surface.Y && (double) this.velocity.Y > 0.0)
        this.velocity -= new Vector3(0.0f, this.velocity.Y * (1E-05f * (float) this.altitude), 0.0f);
      if ((double) this.velocity.Y < (double) this.terminalveloc)
        this.velocity.Y = this.terminalveloc;
      if (this.impact == 0 && (this.altitude < 350 || this.onDropship))
      {
        Vector3 position1 = this.newPosition + Vector3.Transform(new Vector3(0.0f, -150f, 135f), this.orientation);
        Vector3 position2 = this.newPosition + Vector3.Transform(new Vector3(-135f, -150f, 0.0f), this.orientation);
        Vector3 position3 = this.newPosition + Vector3.Transform(new Vector3(0.0f, -150f, -135f), this.orientation);
        Vector3 position4 = this.newPosition + Vector3.Transform(new Vector3(135f, -150f, 0.0f), this.orientation);
        Vector3 position5 = this.newPosition + Vector3.Transform(new Vector3(0.0f, 150f, 120f), this.orientation);
        Vector3 position6 = this.newPosition + Vector3.Transform(new Vector3(-120f, 150f, 0.0f), this.orientation);
        Vector3 position7 = this.newPosition + Vector3.Transform(new Vector3(0.0f, 150f, -120f), this.orientation);
        Vector3 position8 = this.newPosition + Vector3.Transform(new Vector3(120f, 150f, 0.0f), this.orientation);
        Vector3 position9 = this.newPosition + Vector3.Transform(new Vector3(0.0f, (float) byte.MaxValue, 0.0f), this.orientation);
        Vector3 vector3_4 = position1;
        Vector3 vector3_5 = position2;
        Vector3 vector3_6 = position3;
        Vector3 vector3_7 = position4;
        Vector3 vector3_8 = position5;
        Vector3 vector3_9 = position6;
        Vector3 vector3_10 = position7;
        Vector3 vector3_11 = position8;
        Vector3 vector3_12 = position9;
        if (this.onDropship)
        {
          this.GetHeightShip(position1, out vector3_4.Y);
          this.GetHeightShip(position2, out vector3_5.Y);
          this.GetHeightShip(position3, out vector3_6.Y);
          this.GetHeightShip(position4, out vector3_7.Y);
          this.GetHeightShip(position5, out vector3_8.Y);
          this.GetHeightShip(position6, out vector3_9.Y);
          this.GetHeightShip(position7, out vector3_10.Y);
          this.GetHeightShip(position8, out vector3_11.Y);
          this.GetHeightShip(position9, out vector3_12.Y);
        }
        else
        {
          this.GetHeight(ref heightData, position1, out vector3_4.Y);
          this.GetHeight(ref heightData, position2, out vector3_5.Y);
          this.GetHeight(ref heightData, position3, out vector3_6.Y);
          this.GetHeight(ref heightData, position4, out vector3_7.Y);
          this.GetHeight(ref heightData, position5, out vector3_8.Y);
          this.GetHeight(ref heightData, position6, out vector3_9.Y);
          this.GetHeight(ref heightData, position7, out vector3_10.Y);
          this.GetHeight(ref heightData, position8, out vector3_11.Y);
          this.GetHeight(ref heightData, position9, out vector3_12.Y);
        }
        float num1 = 0.0f;
        if (this.onDropship)
          num1 = 10f;
        if ((double) position1.Y >= (double) vector3_4.Y + (double) num1 && (double) position2.Y >= (double) vector3_5.Y + (double) num1 && (double) position3.Y >= (double) vector3_6.Y + (double) num1 && (double) position4.Y >= (double) vector3_7.Y + (double) num1)
        {
          if ((double) position5.Y < (double) vector3_8.Y || (double) position6.Y < (double) vector3_9.Y || (double) position7.Y < (double) vector3_10.Y || (double) position8.Y < (double) vector3_11.Y || (double) position9.Y < (double) vector3_12.Y)
          {
            this.impact = 2;
            if (this.shockhit == 0)
              this.shockhit = 2 + (int) this.velocity.Length() / 2;
          }
        }
        else if ((double) this.rightTrigger == 0.0 && (double) Vector3.Dot(this.normal, this.orientation.Up) > 0.800000011920929 && (this.onDropship || (double) this.velocity.LengthSquared() < 2500.0))
        {
          this.impact = 1;
        }
        else
        {
          this.impact = 2;
          if (this.shockhit == 0)
            this.shockhit = 2 + (int) this.velocity.Length() / 2;
        }
        if (this.impact == 2)
        {
          float num2 = 0.9f;
          this.movedist1 = Vector3.Distance(this.newPosition, this.position) * 0.0005f;
          this.velocity = Vector3.Reflect(this.velocity, this.normal) * 0.8f;
          this.velocity.Y = Math.Abs(this.velocity.Y + 0.0f) * num2;
          this.position.Y = MathHelper.Max(this.newPosition.Y, this.position.Y) + 0.5f;
          this.newPosition = this.position + this.velocity;
          float num3 = 0.0f;
          if ((double) position1.Y < (double) vector3_4.Y)
          {
            this.delta1 = new Vector3(position1.X, 0.0f, position1.Z) - new Vector3(this.newPosition.X, 0.0f, this.newPosition.Z);
            num3 = vector3_4.Y - position1.Y;
          }
          if ((double) position2.Y < (double) vector3_5.Y)
          {
            this.delta1 = new Vector3(position2.X, 0.0f, position2.Z) - new Vector3(this.newPosition.X, 0.0f, this.newPosition.Z);
            num3 = vector3_5.Y - position2.Y;
          }
          if ((double) position3.Y < (double) vector3_6.Y)
          {
            this.delta1 = new Vector3(position3.X, 0.0f, position3.Z) - new Vector3(this.newPosition.X, 0.0f, this.newPosition.Z);
            num3 = vector3_6.Y - position3.Y;
          }
          if ((double) position4.Y < (double) vector3_7.Y)
          {
            this.delta1 = new Vector3(position4.X, 0.0f, position4.Z) - new Vector3(this.newPosition.X, 0.0f, this.newPosition.Z);
            num3 = vector3_7.Y - position4.Y;
          }
          if ((double) position5.Y < (double) vector3_8.Y)
          {
            this.delta1 = new Vector3(position5.X, 0.0f, position5.Z) - new Vector3(this.newPosition.X, 0.0f, this.newPosition.Z);
            num3 = vector3_8.Y - position5.Y;
          }
          if ((double) position6.Y < (double) vector3_9.Y)
          {
            this.delta1 = new Vector3(position6.X, 0.0f, position6.Z) - new Vector3(this.newPosition.X, 0.0f, this.newPosition.Z);
            num3 = vector3_9.Y - position6.Y;
          }
          if ((double) position7.Y < (double) vector3_10.Y)
          {
            this.delta1 = new Vector3(position7.X, 0.0f, position7.Z) - new Vector3(this.newPosition.X, 0.0f, this.newPosition.Z);
            num3 = vector3_10.Y - position7.Y;
          }
          if ((double) position8.Y < (double) vector3_11.Y)
          {
            this.delta1 = new Vector3(position8.X, 0.0f, position8.Z) - new Vector3(this.newPosition.X, 0.0f, this.newPosition.Z);
            num3 = vector3_11.Y - position8.Y;
          }
          if ((double) position9.Y < (double) vector3_12.Y)
          {
            this.delta1 = new Vector3(position9.X, 0.0f, position9.Z) - new Vector3(this.newPosition.X, 0.0f, this.newPosition.Z);
            num3 = vector3_12.Y - position9.Y;
          }
          this.newPosition.Y += Math.Abs(num3) + 1f;
        }
      }
      if (this.impact == 5)
      {
        this.movedist1 = Vector3.Distance(this.newPosition, this.position) * 0.0005f;
        this.velocity = this.reflectnormal;
        this.newPosition = this.position + this.velocity;
        this.shockhit = 40;
      }
      if ((double) this.movedist1 > 0.0 && (double) this.delta1.LengthSquared() > 0.0)
        this.orientation *= Matrix.CreateFromAxisAngle(Vector3.Cross(-Vector3.Normalize(this.delta1), Vector3.Up), this.movedist1);
      this.movedist1 *= 0.94f;
      if ((double) this.newPosition.Y - 300.0 <= (double) this.surface.Y && (double) this.rightTrigger <= 0.0 && this.impact == 2)
      {
        this.movedistx = Vector3.Distance(this.newPosition, this.position) * 0.55f;
        this.deltax = new Vector3(this.newPosition.X, 0.0f, this.newPosition.Z) - new Vector3(this.position.X, 0.0f, this.position.Z);
      }
      if ((double) this.deltax.LengthSquared() > 0.0)
        this.orientation *= Matrix.CreateFromAxisAngle(Vector3.Cross(-Vector3.Normalize(this.deltax), Vector3.Up), this.movedistx * 0.0037f);
      this.movedistx *= 0.97f;
      if ((double) this.diff == (double) this.offset)
      {
        this.orientation *= Matrix.CreateRotationX(this.landerDirectionX) * Matrix.CreateRotationZ(this.landerDirectionZ);
        this.directme = (float) Math.Acos(Convert.ToDouble(Vector3.Dot(this.lastorientation.Forward, Vector3.Forward)));
        if ((double) this.lastorientation.Forward.X > 0.0)
          this.directme = -this.directme;
        this.lasthite = this.newPosition;
      }
      this.lastorientation = this.orientation;
      if ((double) this.rightTrigger <= 0.0 && this.impact == 1 && (this.onDropship || (double) this.velocity.Y < 0.0) && (double) this.landerBottom.Y <= (double) this.surface.Y + 50.0)
      {
        if ((double) this.diff > 0.0)
          --this.diff;
        this.orientationx = Matrix.CreateRotationY(this.directme);
        this.orientationx.Up = this.normal;
        this.orientationx.Right = Vector3.Cross(this.orientationx.Forward, this.orientationx.Up);
        this.orientationx.Right = Vector3.Normalize(this.orientationx.Right);
        this.orientationx.Forward = Vector3.Cross(this.orientationx.Up, this.orientationx.Right);
        this.orientationx.Forward = Vector3.Normalize(this.orientationx.Forward);
        if ((double) this.diff / (double) this.offset > 0.0)
        {
          Quaternion rotation1;
          Vector3 translation1;
          this.lastorientation.Decompose(out Vector3 _, out rotation1, out translation1);
          Quaternion rotation2;
          Vector3 translation2;
          this.orientationx.Decompose(out Vector3 _, out rotation2, out translation2);
          this.orientation = Matrix.CreateFromQuaternion(Quaternion.Slerp(rotation2, rotation1, this.diff / this.offset)) * Matrix.CreateTranslation(Vector3.Lerp(translation2, translation1, this.diff / this.offset));
        }
        if ((double) this.landerBottom.Y <= (double) this.surface.Y || this.onDropship && (double) this.landerBottom.Y <= (double) this.surface.Y + 20.0)
        {
          if ((double) this.velocity.Y < 0.0)
            this.velocity.Y = 0.0f;
          this.velocity /= 1.1f;
          this.newPosition = this.surface + Vector3.Transform(new Vector3(0.0f, 155f, 0.0f), this.orientation);
          this.lastorientation = this.orientation;
          this.movedistx = 0.0f;
          this.movedist1 = 0.0f;
        }
      }
      else
      {
        this.diff = this.offset;
        this.impact = 0;
      }
      if (this.onDropship || this.insideDropship)
        this.newPosition += this.dropshipVeloc;
      float num4 = 0.93f;
      float num5 = 0.993f;
      float num6 = MathHelper.Lerp(1500f, 500f, MathHelper.Clamp((float) (this.altitude / 500), 0.0f, 1f));
      if (this.impact == 2)
        num6 = 500f;
      float num7 = MathHelper.Lerp(num6, 260f, this.rightTrigger * this.rightTrigger * this.rightTrigger);
      if (this.sc.usingMouse)
      {
        if (this.KMdown(this.sc.d_key))
        {
          this.ggO.X += 0.07f;
          if ((double) this.ggO.X > 1.0)
            this.ggO.X = 1f;
        }
        if (this.KMdown(this.sc.a_key))
        {
          this.ggO.X -= 0.07f;
          if ((double) this.ggO.X < -1.0)
            this.ggO.X = -1f;
        }
        if (this.method_0(this.sc.a_key) && this.method_0(this.sc.d_key))
        {
          if ((double) this.ggO.X < 0.0)
          {
            this.ggO.X += 0.1f;
            if ((double) this.ggO.X > 0.0)
              this.ggO.X = 0.0f;
          }
          if ((double) this.ggO.X > 0.0)
          {
            this.ggO.X -= 0.1f;
            if ((double) this.ggO.X < 0.0)
              this.ggO.X = 0.0f;
          }
        }
        if (this.KMdown(this.sc.w_key))
        {
          if ((double) this.ggO.Y < 0.0)
            this.ggO.Y = 0.0f;
          this.ggO.Y += 0.07f;
          if ((double) this.ggO.Y > 1.0)
            this.ggO.Y = 1f;
        }
        if (this.KMdown(this.sc.s_key))
        {
          if ((double) this.ggO.Y > 0.0)
            this.ggO.Y = 0.0f;
          this.ggO.Y -= 0.07f;
          if ((double) this.ggO.Y < -1.0)
            this.ggO.Y = -1f;
        }
        if (this.method_0(this.sc.s_key) && this.method_0(this.sc.w_key))
        {
          if ((double) this.ggO.Y < 0.0)
          {
            this.ggO.Y += 0.1f;
            if ((double) this.ggO.Y > 0.0)
              this.ggO.Y = 0.0f;
          }
          if ((double) this.ggO.Y > 0.0)
          {
            this.ggO.Y -= 0.1f;
            if ((double) this.ggO.Y < 0.0)
              this.ggO.Y = 0.0f;
          }
        }
      }
      else
      {
        this.ggO.X = currentGamePadState.ThumbSticks.Left.X;
        this.ggO.Y = currentGamePadState.ThumbSticks.Left.Y;
      }
      this.turnAmountX = -this.ggO.X / num7;
      this.turnAmountZ = -this.ggO.Y / num7;
      this.landerDirectionX += (float) ((double) this.turnAmountX * Math.Sin((double) this.camrot) + (double) this.turnAmountZ * -Math.Cos((double) this.camrot));
      this.landerDirectionZ += (float) ((double) this.turnAmountZ * -Math.Sin((double) this.camrot) + (double) this.turnAmountX * -Math.Cos((double) this.camrot));
      this.landerDirectionX *= num4;
      this.landerDirectionZ *= num4;
      this.velocity.X *= num5;
      this.velocity.Z *= num5;
      this.lander2ground = this.rayDistance;
      this.ground = this.position - this.orientation.Up * this.rayDistance;
      float height1;
      if (!this.onDropship)
        this.GetHeight(ref heightData, this.ground, out height1);
      else
        this.GetHeightShip(this.ground, out height1);
      if ((double) height1 < (double) this.ground.Y)
      {
        this.rayDistance += 90f;
        if ((double) this.rayDistance > 9000.0)
          this.rayDistance = 9000f;
      }
      if ((double) height1 > (double) this.ground.Y)
      {
        this.rayDistance -= 90f;
        if ((double) this.rayDistance < 90.0)
          this.rayDistance = 90f;
      }
      float num8 = this.position.X - this.newPosition.X;
      float num9 = this.position.Z - this.newPosition.Z;
      if ((double) Math.Abs(num8) > (double) this.maxspeed && !this.onDropship && !this.insideDropship)
        this.position.X -= (float) Math.Sign(num8) * this.maxspeed;
      else
        this.position.X = this.newPosition.X;
      if ((double) Math.Abs(num9) > (double) this.maxspeed && !this.onDropship && !this.insideDropship)
        this.position.Z -= (float) Math.Sign(num9) * this.maxspeed;
      else
        this.position.Z = this.newPosition.Z;
      this.position.Y = this.newPosition.Y;
    }

    public void Draw(Matrix viewMatrix, Matrix projectionMatrix, Vector3 sundir)
    {
      this.animateparts();
      this.flameMatrix = Matrix.CreateScale(this.lscale);
      this.flameBone.Transform = this.flameMatrix * this.flameTransform;
      this.model.CopyAbsoluteBoneTransformsTo(this.boneTransforms);
      Matrix matrix = this.orientation * Matrix.CreateTranslation(this.position);
      foreach (ModelMesh mesh in this.model.Meshes)
      {
        ++this.mytimer;
        int num = 1;
        if (mesh.Name == "flame")
        {
          if (this.flameFlag == 0)
          {
            num = 0;
          }
          else
          {
            this.reducer = 1f - MathHelper.Clamp((float) (((double) this.lander2ground - 400.0) / 2200.0), 0.0f, 1f);
            this.directLight = this.orientation.Up;
          }
        }
        if (mesh.Name == "interior" && this.door1 == 1)
          num = 0;
        if (num == 1)
        {
          foreach (BasicEffect effect in mesh.Effects)
          {
            effect.PreferPerPixelLighting = false;
            effect.World = this.boneTransforms[mesh.ParentBone.Index] * matrix;
            if (mesh.Name == "dish1" && this.radioFixed)
              effect.World = Matrix.CreateRotationY(0.9f * (float) Math.Sin((double) this.mytimer / 400.0)) * this.boneTransforms[mesh.ParentBone.Index] * matrix;
            effect.View = viewMatrix;
            effect.Projection = projectionMatrix;
            effect.LightingEnabled = true;
            effect.DirectionalLight0.Enabled = true;
            effect.AmbientLightColor = this.amb * 0.8f;
            if (mesh.Name == "interior")
              effect.AmbientLightColor = new Vector3(1f, 1f, 1f);
            if (mesh.Name == "flame")
              effect.AmbientLightColor = this.rAmbient[this.rrcount % this.rAmbient.Length];
            if ((double) this.reducer > 0.0)
            {
              effect.DirectionalLight1.Enabled = true;
              effect.DirectionalLight1.Direction = this.directLight;
              effect.DirectionalLight1.DiffuseColor = new Vector3(0.8f, 1f, 1f) * this.lscale * this.reducer;
            }
            effect.DirectionalLight0.Direction = sundir;
            effect.DirectionalLight0.DiffuseColor = this.diffu;
          }
          mesh.Draw();
        }
      }
    }

    private void dentmex()
    {
    }

    private void dentmex2()
    {
    }

    private void animateparts()
    {
      if (this.commandFlag == 1)
      {
        this.commandFlag = 0;
        this.gemmax = 0.0f;
        if (this.door1 == 1)
          this.door1 = 8;
      }
      if (this.commandFlag == 2)
      {
        this.commandFlag = 0;
        if (this.door1 == 10)
          this.door1 = 3;
        this.region1 = new float[15];
        this.region2 = new float[15];
      }
      if (this.door1 == 8)
      {
        this.doorVar1 -= 1.6f;
        this.doorBone.Transform = Matrix.CreateRotationZ(MathHelper.ToRadians(this.doorVar1)) * this.doorTransform;
        Vector3 position = Vector3.Transform(Vector3.Transform(new Vector3(6f, 282f, 0.0f), this.doorBone.Transform), this.orientation * Matrix.CreateTranslation(this.position));
        float height;
        this.GetHeight(ref this.allheights, position, out height);
        if ((double) position.Y <= (double) height)
          this.door1 = 9;
      }
      if (this.door1 == 9)
      {
        this.doorVar2 += 3f;
        this.modelBone_0.Transform = Matrix.CreateTranslation(0.0f, this.doorVar2, 0.0f) * this.door2Transform;
        if ((double) this.doorVar2 >= 139.5)
        {
          this.door1 = 10;
          Vector3 position = Vector3.Transform(Vector3.Transform(new Vector3(-3.6f, 288f, -75f), this.doorBone.Transform), this.orientation * Matrix.CreateTranslation(this.position));
          this.region1[0] = position.X;
          this.region1[1] = position.Y;
          this.region1[2] = position.Z;
          position = Vector3.Transform(new Vector3(-3.6f, 288f, 75f), this.doorBone.Transform);
          position = Vector3.Transform(position, this.orientation * Matrix.CreateTranslation(this.position));
          this.region1[3] = position.X;
          this.region1[4] = position.Y;
          this.region1[5] = position.Z;
          position = Vector3.Transform(new Vector3(96f, -20.34f, -66f), this.orientation * Matrix.CreateTranslation(this.position));
          this.region1[6] = position.X;
          this.region1[7] = position.Y;
          this.region1[8] = position.Z;
          position = Vector3.Transform(new Vector3(66f, -20.34f, -96f), this.orientation * Matrix.CreateTranslation(this.position));
          this.region1[9] = position.X;
          this.region1[10] = position.Y;
          this.region1[11] = position.Z;
          position = Vector3.Transform(new Vector3(300f, 288f, 75f), this.doorBone.Transform);
          position = Vector3.Transform(position, this.orientation * Matrix.CreateTranslation(this.position));
          position = Vector3.Normalize(new Vector3(this.region1[3], this.region1[4], this.region1[5]) - new Vector3(position.X, position.Y, position.Z));
          this.region1[12] = position.X;
          this.region1[13] = position.Y;
          this.region1[14] = position.Z;
          position = Vector3.Transform(new Vector3(36.9f, 1.35f, -67.8f), this.orientation * Matrix.CreateTranslation(this.position));
          this.region2[0] = position.X;
          this.region2[1] = position.Y;
          this.region2[2] = position.Z;
          position = Vector3.Transform(new Vector3(67.8f, 1.35f, -37.8f), this.orientation * Matrix.CreateTranslation(this.position));
          this.region2[3] = position.X;
          this.region2[4] = position.Y;
          this.region2[5] = position.Z;
          position = Vector3.Transform(new Vector3(-12.66f, 1.35f, 40.0500031f), this.orientation * Matrix.CreateTranslation(this.position));
          this.region2[6] = position.X;
          this.region2[7] = position.Y;
          this.region2[8] = position.Z;
          position = Vector3.Transform(new Vector3(-42.66f, 1.35f, 10.05f), this.orientation * Matrix.CreateTranslation(this.position));
          this.region2[9] = position.X;
          this.region2[10] = position.Y;
          this.region2[11] = position.Z;
          position = Vector3.Transform(new Vector3(67.8f, -300f, -37.8f), this.orientation * Matrix.CreateTranslation(this.position));
          position = Vector3.Normalize(new Vector3(this.region2[3], this.region2[4], this.region2[5]) - new Vector3(position.X, position.Y, position.Z));
          this.region2[12] = position.X;
          this.region2[13] = position.Y;
          this.region2[14] = position.Z;
          this.rampSwitch = 1;
        }
      }
      if (this.door1 == 3)
      {
        this.doorVar2 -= 4f;
        this.modelBone_0.Transform = Matrix.CreateTranslation(0.0f, this.doorVar2, 0.0f) * this.door2Transform;
        if ((double) this.doorVar2 <= 0.0)
          this.door1 = 2;
      }
      if (this.door1 != 2)
        return;
      this.doorVar1 += 2f;
      if ((double) this.doorVar1 >= 0.0)
      {
        this.door1 = 1;
        this.doorVar1 = 0.0f;
      }
      this.doorBone.Transform = Matrix.CreateRotationZ(MathHelper.ToRadians(this.doorVar1)) * this.doorTransform;
    }

    public void GetHeightAndNormal(
      ref int[,] heightData,
      ref Vector3[,] normals,
      Vector3 position,
      out float height,
      out Vector3 normal)
    {
      if (Lander.nearfarm)
      {
        this.GetHeightFarm(ref heightData, position, out height, out normal, false);
      }
      else
      {
        this.heightmapWidth = (float) (this.bitmap - 1) * this.gridScale;
        position.X = (float) ((double) position.X % (double) this.heightmapWidth + 1.5 * (double) this.heightmapWidth) % this.heightmapWidth;
        position.Z = (float) ((double) position.Z % (double) this.heightmapWidth + 1.5 * (double) this.heightmapWidth) % this.heightmapWidth;
        Vector3 vector3_1 = position;
        int index1 = (int) vector3_1.X / (int) this.gridScale;
        int index2 = (int) vector3_1.Z / (int) this.gridScale;
        float amount1 = vector3_1.X % this.gridScale / this.gridScale;
        float amount2 = vector3_1.Z % this.gridScale / this.gridScale;
        int index3 = index1 + 1;
        int index4 = index2 + 1;
        if (index3 > this.bitmap - 2)
          index3 = 0;
        if (index4 > this.bitmap - 2)
          index4 = 0;
        float num1 = MathHelper.Lerp((float) heightData[index1, index2], (float) heightData[index3, index2], amount1);
        float num2 = MathHelper.Lerp((float) heightData[index1, index4], (float) heightData[index3, index4], amount1);
        height = MathHelper.Lerp(num1, num2, amount2);
        Vector3 vector3_2 = Vector3.Lerp(normals[index1, index2], normals[index3, index2], amount1);
        Vector3 vector3_3 = Vector3.Lerp(normals[index1, index4], normals[index3, index4], amount1);
        normal = Vector3.Lerp(vector3_2, vector3_3, amount2);
        normal = Vector3.Normalize(normal);
      }
    }

    public void GetHeight(ref int[,] heightData, Vector3 position, out float height)
    {
      if (Lander.nearfarm)
      {
        this.GetHeightFarm(ref heightData, position, out height, out Vector3 _, true);
      }
      else
      {
        this.heightmapWidth = (float) (this.bitmap - 1) * this.gridScale;
        position.X = (float) ((double) position.X % (double) this.heightmapWidth + 1.5 * (double) this.heightmapWidth) % this.heightmapWidth;
        position.Z = (float) ((double) position.Z % (double) this.heightmapWidth + 1.5 * (double) this.heightmapWidth) % this.heightmapWidth;
        Vector3 vector3 = position;
        int index1 = (int) vector3.X / (int) this.gridScale;
        int index2 = (int) vector3.Z / (int) this.gridScale;
        float amount1 = vector3.X % this.gridScale / this.gridScale;
        float amount2 = vector3.Z % this.gridScale / this.gridScale;
        int index3 = index1 + 1;
        int index4 = index2 + 1;
        if (index3 > this.bitmap - 2)
          index3 = 0;
        if (index4 > this.bitmap - 2)
          index4 = 0;
        float num1 = MathHelper.Lerp((float) heightData[index1, index2], (float) heightData[index3, index2], amount1);
        float num2 = MathHelper.Lerp((float) heightData[index1, index4], (float) heightData[index3, index4], amount1);
        height = MathHelper.Lerp(num1, num2, amount2);
      }
    }

    public void GetHeightFarm(
      ref int[,] heights,
      Vector3 position,
      out float height,
      out Vector3 normal,
      bool onlyheight)
    {
      Vector3 vector3_1 = new Vector3(3000f - Lander.farmLocation.X, 0.0f, 3000f - Lander.farmLocation.Z);
      position += vector3_1;
      int x1 = (int) MathHelper.Clamp(position.X / 30f, 0.0f, 198f);
      int z1 = (int) MathHelper.Clamp(position.Z / 30f, 0.0f, 198f);
      float num1 = (float) ((double) position.X % 30.0 / 30.0);
      float num2 = (float) ((double) position.Z % 30.0 / 30.0);
      int x2 = x1 + 1;
      int z2 = z1 + 1;
      if (x2 > 198)
        x2 = 0;
      if (z2 > 198)
        z2 = 0;
      Vector3 vector3_2 = new Vector3((float) x1, (float) heights[x1, z1], (float) z1);
      if ((double) num1 + (double) num2 >= 1.0)
        vector3_2 = new Vector3((float) x2, (float) heights[x2, z2], (float) z2);
      Vector3 vector3_3 = new Vector3((float) x1, (float) heights[x1, z2], (float) z2);
      Vector3 vector3_4 = new Vector3((float) x2, (float) heights[x2, z1], (float) z1);
      Vector2 vector2 = new Vector2(position.X / 30f, position.Z / 30f);
      float num3 = (float) (((double) vector3_3.Z - (double) vector3_4.Z) * ((double) vector3_2.X - (double) vector3_4.X) + ((double) vector3_4.X - (double) vector3_3.X) * ((double) vector3_2.Z - (double) vector3_4.Z));
      float num4 = (float) (((double) vector3_3.Z - (double) vector3_4.Z) * ((double) vector2.X - (double) vector3_4.X) + ((double) vector3_4.X - (double) vector3_3.X) * ((double) vector2.Y - (double) vector3_4.Z)) / num3;
      float num5 = (float) (((double) vector3_4.Z - (double) vector3_2.Z) * ((double) vector2.X - (double) vector3_4.X) + ((double) vector3_2.X - (double) vector3_4.X) * ((double) vector2.Y - (double) vector3_4.Z)) / num3;
      float num6 = 1f - num4 - num5;
      height = (float) ((double) num4 * (double) vector3_2.Y + (double) num5 * (double) vector3_3.Y + (double) num6 * (double) vector3_4.Y);
      normal = Vector3.Zero;
      if (onlyheight)
        return;
      if ((double) num1 + (double) num2 > 1.0)
        vector3_2 = new Vector3((float) x2, (float) heights[x2, z2], (float) z2);
      vector3_2.Y /= 30f;
      vector3_3.Y /= 30f;
      vector3_4.Y /= 30f;
      Vector3 vector3_5 = vector3_2;
      Vector3 vector3_6 = vector3_3;
      Vector3 vector3_7 = Vector3.Normalize(Vector3.Cross(vector3_4 - vector3_6, vector3_5 - vector3_6));
      if ((double) vector3_7.Y < 0.0)
        vector3_7 = -vector3_7;
      normal = vector3_7;
    }

    public void ShipHeightandNormal(Vector3 position, out float height, out Vector3 normal)
    {
      int num1 = 81;
      float num2 = 102.5f;
      this.heightmapWidth = 8200f;
      position.X = (float) (((double) position.X - (double) this.dropship.X) % (double) this.heightmapWidth + 1.5 * (double) this.heightmapWidth) % this.heightmapWidth;
      position.Z = (float) (((double) position.Z - (double) this.dropship.Z) % (double) this.heightmapWidth + 1.5 * (double) this.heightmapWidth) % this.heightmapWidth;
      Vector3 vector3 = position;
      int index1 = (int) vector3.X / 102;
      int index2 = (int) vector3.Z / 102;
      float amount1 = vector3.X % num2 / num2;
      float amount2 = vector3.Z % num2 / num2;
      int index3 = index1 + 1;
      int index4 = index2 + 1;
      if (index3 > 79)
        index3 = 0;
      if (index4 > num1 - 2)
        index4 = 0;
      float num3 = this.dropship.Y + MathHelper.Lerp(this.drophite[index1, index2], this.drophite[index3, index2], amount1);
      float num4 = this.dropship.Y + MathHelper.Lerp(this.drophite[index1, index4], this.drophite[index3, index4], amount1);
      height = MathHelper.Lerp(num3, num4, amount2);
      normal = Vector3.Normalize(new Vector3(-this.drophite[index3, index2] + this.drophite[index1, index2], 102.5f, -this.drophite[index1, index4] + this.drophite[index1, index2]));
    }

    public void GetHeightShip(Vector3 position, out float height)
    {
      int num1 = 81;
      float num2 = 102.5f;
      this.heightmapWidth = 8200f;
      position.X = (float) (((double) position.X - (double) this.dropship.X) % (double) this.heightmapWidth + 1.5 * (double) this.heightmapWidth) % this.heightmapWidth;
      position.Z = (float) (((double) position.Z - (double) this.dropship.Z) % (double) this.heightmapWidth + 1.5 * (double) this.heightmapWidth) % this.heightmapWidth;
      Vector3 vector3 = position;
      int index1 = (int) vector3.X / 102;
      int index2 = (int) vector3.Z / 102;
      float amount1 = vector3.X % num2 / num2;
      float amount2 = vector3.Z % num2 / num2;
      int index3 = index1 + 1;
      int index4 = index2 + 1;
      if (index3 > 79)
        index3 = 0;
      if (index4 > num1 - 2)
        index4 = 0;
      float num3 = this.dropship.Y + MathHelper.Lerp(this.drophite[index1, index2], this.drophite[index3, index2], amount1);
      float num4 = this.dropship.Y + MathHelper.Lerp(this.drophite[index1, index4], this.drophite[index3, index4], amount1);
      height = MathHelper.Lerp(num3, num4, amount2);
    }
  }
}
