using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

#pragma warning disable CS0414
#pragma warning disable CS0649
#nullable disable
namespace Blood
{
  internal class Rover : GameScreen
  {
    private KeyboardState keyState;
    private KeyboardState prevkeyState;
    private MouseState mouseState;
    private MouseState prevMouse;
    public float thumb;
    public float righttrig;
    public float leftTrig;
    public Matrix smallWorld;
    private int fliptimer;
    private Vector3 reflectnormal;
    public bool brakeson;
    public bool scopemode;
    public Vector3 position = new Vector3(1400f, 0.0f, 700f);
    public float facingDirection = 3.14f;
    private Vector3 delta;
    private bool jumpnow;
    private float spinny = 1f;
    private Vector3 lastmovement = Vector3.Zero;
    private Matrix lastOrient = Matrix.Identity;
    public float dotty;
    public float mydotty;
    public float hillalign;
    public float futureDot;
    public int shockhit;
    public float leanAmt;
    public Vector3 pp;
    public int indexMatrix = 1;
    public float indexValue;
    private Matrix lean;
    private Matrix pitch;
    public Vector3 aVector = Vector3.Zero;
    public Vector3 bVector = Vector3.Zero;
    public int flipflag;
    private int oldhangtime;
    private Vector3 oldgrav = Vector3.Zero;
    public int turnDir = 1;
    public int spinflag;
    public float rotAlign;
    private float incRot;
    private Vector3 axisdelta = Vector3.Zero;
    private Matrix carRot = Matrix.CreateFromYawPitchRoll(0.0f, 0.0f, 0.0f);
    private int hithard;
    public Vector3 normal = Vector3.Zero;
    private Vector3 jumpstart = Vector3.Zero;
    private Vector3 lastNormal = Vector3.Zero;
    private Vector3 workingNormal = Vector3.Zero;
    private Vector3 oldnormal = Vector3.Zero;
    private Vector3 futurenormal = Vector3.Zero;
    public Vector3 futureposition = Vector3.Zero;
    private int hangtime;
    public int gridscale;
    public int bitmap;
    private float heightmapWidth;
    public Vector3 newPosition;
    public Vector3 gndPosition;
    private float solarx;
    private float solary;
    public int solarflag;
    public int solar1 = 1;
    public float scoopx = 1f;
    public int scoopflag;
    public int scoop1 = 1;
    public bool scooperON;
    public float speedx;
    public Matrix orientation = Matrix.Identity;
    private Matrix orientationx = Matrix.Identity;
    private Matrix lastorientation = Matrix.Identity;
    public int myside;
    public int groundflag;
    public Vector3 movement = Vector3.Zero;
    public Vector3 inertial = Vector3.Zero;
    public Vector3 velocity = Vector3.Zero;
    public Vector3 grav = Vector3.Zero;
    private float zspin;
    public float min = 7f;
    public static float turnSpeed = 0.11f;
    public static float max = -65f;
    public static float realGrav = -0.8f;
    public static float fric = 0.9f;
    public static float fricOrig = 0.9f;
    public static int rockhitCount = 0;
    public static Vector3 farmLocation = Vector3.Zero;
    public static bool nearfarm = false;
    private float speed;
    public float[] region1 = new float[15];
    public float[] region2 = new float[15];
    public float[] region3 = new float[15];
    public float alfa;
    public int onramp;
    private Vector3 rampNormal = Vector3.Zero;
    private float rampHeight;
    private float rampSpline;
    public float directme;
    public int camSwitch;
    public int dashcam;
    public Vector3 amb = new Vector3(0.3f, 0.3f, 0.3f);
    public Vector3 diffu = new Vector3(1.2f, 1.1f, 1f);
    private Matrix[] boneTransforms;
    private Random rr;
    private GraphicsDevice gr;
    private ScreenManager sc;
    private SoundEffect jumpit;
    private float horn = 10f;
    private ContentManager content;

    public void LoadContent(ContentManager content, ScreenManager sc)
    {
      this.content = content;
      this.rr = new Random();
      this.sc = sc;
      this.gr = sc.GraphicsDevice;
      this.jumpit = content.Load<SoundEffect>("astro\\Audio\\horn1");
      Rover.realGrav = -0.6f;
      sc.RoverEquip();
      this.boneTransforms = new Matrix[sc.roverModel.Bones.Count];
    }

    public override void UnloadContent() => this.content.Unload();

    public bool boxcollide(Vector3 min, Vector3 max, Vector3 foffset)
    {
      BoundingBox a_kBox = new BoundingBox(min, max);
      if (a_kBox.Intersects(new BoundingSphere(this.position, 50f)))
      {
        float a_fDist = 9000f;
        Vector3 vector3 = this.velocity;
        if ((double) this.velocity.Length() <= 0.10000000149011612)
          vector3 = foffset - this.position;
        Vector3 direction = Vector3.Normalize(vector3);
        Ray a_kRay = new Ray(this.newPosition, direction);
        this.IntersectRayVsBox(a_kBox, a_kRay, out a_fDist, out this.reflectnormal);
        if ((double) a_fDist < 50.0)
        {
          float num = MathHelper.Max(2f, this.velocity.Length() * 0.2f);
          if ((double) num == 2.0)
            this.reflectnormal *= 2f;
          else
            this.reflectnormal = Vector3.Reflect(num * direction, this.reflectnormal);
          return true;
        }
      }
      return false;
    }

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
      ref int[,] heights,
      ref Vector3[,] normals)
    {
      this.mouseState = mouse;
      this.prevMouse = prevmouse;
      this.keyState = keystate;
      this.prevkeyState = prevkeystate;
      if (this.sc.usingMouse)
      {
        this.leftTrig = 0.0f;
        if (this.KMdown(this.sc.a_key))
        {
          this.thumb += 0.04f;
          if ((double) this.thumb > 1.0)
            this.thumb = 1f;
        }
        if (this.KMdown(this.sc.d_key))
        {
          this.thumb -= 0.04f;
          if ((double) this.thumb < -1.0)
            this.thumb = -1f;
        }
        if (this.method_0(this.sc.a_key) && this.method_0(this.sc.d_key))
        {
          if ((double) this.thumb < 0.0)
          {
            this.thumb += 0.1f;
            if ((double) this.thumb > 0.0)
              this.thumb = 0.0f;
          }
          if ((double) this.thumb > 0.0)
          {
            this.thumb -= 0.1f;
            if ((double) this.thumb < 0.0)
              this.thumb = 0.0f;
          }
        }
        if (!this.KMdown(this.sc.lmb_key) && !this.KMdown(this.sc.w_key))
        {
          this.righttrig += 0.07f;
          if ((double) this.righttrig > 0.0)
            this.righttrig = 0.0f;
        }
        else
        {
          this.righttrig -= 0.07f;
          if ((double) this.righttrig < -1.0)
            this.righttrig = -1f;
        }
        this.leftTrig = this.KMdown(this.sc.rmb_key) || this.KMdown(this.sc.s_key) ? -1f : 0.0f;
      }
      else
      {
        this.thumb = -currentGamePadState.ThumbSticks.Left.X;
        this.righttrig = -currentGamePadState.Triggers.Right;
        this.leftTrig = -currentGamePadState.Triggers.Left;
      }
      Vector3 foffset = new Vector3(Facility.offset.X + 2200f, Facility.offset.Y + 360f, Facility.offset.Z + 4080f);
      if ((double) Vector3.DistanceSquared(foffset, this.position) < 640000.0 && this.boxcollide(new Vector3(-350f, -700f, -400f) * 1f + foffset, new Vector3(350f, 700f, 400f) * 1f + foffset, foffset))
      {
        this.velocity = this.reflectnormal;
        this.grav = this.reflectnormal;
        this.movement /= 4f;
      }
      --Rover.rockhitCount;
      bool flag1 = true;
      if (this.groundflag == 1)
      {
        this.speed = (float) ((double) this.righttrig / 1.0 - (double) this.leftTrig / 1.5);
        if ((double) this.righttrig > -0.0099999997764825821 && (double) this.leftTrig > -0.0099999997764825821)
          this.movement.Z /= 1.03f;
        if ((double) this.leftTrig < 0.0 && (double) this.righttrig < 0.0)
        {
          flag1 = false;
          this.movement *= 0.97f;
          this.speed = 0.0f;
          this.righttrig = 0.0f;
          this.leftTrig = 0.0f;
        }
        if ((double) this.movement.Z > (double) this.min)
          this.movement.Z = this.min;
        if ((double) this.movement.Z > (double) Rover.max || (double) this.leftTrig < -0.40000000596046448)
          this.movement.Z += this.speed * 1.1f;
        if ((double) this.movement.Z < (double) Rover.max)
          this.movement.Z = Rover.max;
        if (this.scooperON)
          Rover.fric = 0.0f;
        Vector3 vector3 = Vector3.Transform(this.movement, this.orientation);
        if ((double) Rover.fric > 0.0099999997764825821)
        {
          float num = 1f - Rover.fric;
          float y = vector3.Y;
          vector3 = vector3 * num + Rover.fric * this.velocity;
          if ((double) vector3.Length() > 0.0)
            vector3 = (Vector3.Normalize(vector3) * vector3.Length()) with
            {
              Y = y
            };
        }
        this.velocity = vector3;
        float num1 = 1.3f - this.normal.Y;
        if (this.onramp > 0 || (double) this.normal.Y > 0.89999997615814209 && (double) this.righttrig == 0.0 && (double) this.leftTrig == 0.0)
        {
          num1 = 0.0f;
          this.grav *= 0.985f;
          this.movement *= 0.985f;
          this.velocity *= 0.985f;
        }
        if (this.hithard == 0)
        {
          this.grav.Z += (float) ((double) this.normal.Z * (double) num1 * 0.5) * Rover.fric;
          this.grav.X += (float) ((double) this.normal.X * (double) num1 * 0.5) * Rover.fric;
        }
        this.grav /= 1.02f;
      }
      else
      {
        this.speed = this.righttrig;
        this.velocity.Y += Rover.realGrav;
      }
      this.newPosition = this.position + this.velocity + this.grav;
      this.gndPosition.Y = this.newPosition.Y;
      this.oldnormal = this.normal;
      this.hitramp(heights, normals, ref this.onramp, ref this.position, ref this.newPosition, ref this.gndPosition, ref this.normal);
      if (this.groundflag == 0)
        this.speedx *= 1f - MathHelper.Clamp(Math.Abs(this.newPosition.Y - this.gndPosition.Y) / 500f, 0.0f, 0.1f);
      else
        this.speedx = this.movement.Z;
      if (this.hangtime < 0)
        ++this.hangtime;
      if (!this.scopemode && this.groundflag == 1 && this.hangtime >= 0)
      {
        this.hillalign = Vector3.Dot(Vector3.Down, Vector3.Normalize(this.orientation.Forward));
        float num2 = 10f;
        float num3 = Vector2.Distance(new Vector2(this.newPosition.X, this.newPosition.Z), new Vector2(this.position.X, this.position.Z));
        bool flag2 = (double) num3 > (double) num2 && (double) this.hillalign >= 0.0;
        bool flag3 = (double) num3 > (double) num2 && (double) this.hillalign < 0.0;
        bool flag4 = (double) this.newPosition.Y < (double) this.position.Y && (double) this.hillalign < 0.0;
        if ((flag2 || flag3) && !flag4)
        {
          float num4 = 150f;
          Vector3 vector3 = this.velocity + this.grav;
          this.futureposition = this.newPosition + num4 * Vector3.Normalize(new Vector3(vector3.X, 0.0f, vector3.Z));
          this.GetHeightAndNormalX(ref heights, ref normals, this.futureposition, out this.futureposition.Y, out this.futurenormal);
          this.futureDot = Vector3.Dot(this.futurenormal, this.normal);
          bool flag5 = (double) this.futureDot <= 0.99000000953674316;
          if (this.onramp == 0 && flag5)
          {
            this.groundflag = 0;
            this.zspin = this.movement.Z;
            this.rotAlign = 1f;
            this.incRot = 0.06f;
            this.grav = Vector3.Zero;
            this.velocity = (double) this.hillalign >= -0.699999988079071 ? this.newPosition - this.position : new Vector3(this.newPosition.X, this.gndPosition.Y, this.newPosition.Z) - this.position;
            this.jumpnow = true;
          }
        }
      }
      if (this.groundflag == 0)
      {
        Vector3 vector3_1 = Vector3.Transform(new Vector3(0.0f, 33f, 0.0f), this.orientation);
        if (this.hithard == 0)
        {
          if ((double) this.orientation.Left.Y < 0.800000011920929 && (double) this.thumb < 0.0)
          {
            this.lean = Matrix.CreateFromAxisAngle(this.orientation.Forward, (float) (-(double) this.thumb / 55.0));
            this.orientation *= this.lean;
          }
          else if ((double) this.orientation.Left.Y > -0.800000011920929 && (double) this.thumb > 0.0)
          {
            this.lean = Matrix.CreateFromAxisAngle(this.orientation.Backward, this.thumb / 55f);
            this.orientation *= this.lean;
          }
          if ((double) this.orientation.Backward.Y < 0.85000002384185791 && (double) this.speed == 0.0)
          {
            this.pitch = Matrix.CreateFromAxisAngle(this.orientation.Left, 0.015f);
            this.orientation *= this.pitch;
          }
          else if ((double) this.orientation.Backward.Y > -0.85000002384185791 && (double) this.speed <= -0.0099999997764825821)
          {
            this.pitch = Matrix.CreateFromAxisAngle(this.orientation.Right, (float) -((double) this.speed / 45.0));
            this.orientation *= this.pitch;
          }
        }
        else if (this.hithard == 1)
        {
          this.carRot = Matrix.CreateFromAxisAngle(this.axisdelta * (float) this.turnDir, Rover.turnSpeed);
          this.orientation *= this.carRot;
        }
        else if (this.hithard == 11)
        {
          if ((double) this.newPosition.Y <= (double) this.gndPosition.Y)
          {
            this.shockhit = 20;
            this.velocity = Vector3.Reflect(this.velocity, this.normal);
            this.velocity.Y *= (float) this.rr.Next(60, 100) / 100f;
          }
          float num = MathHelper.Clamp(Vector3.Distance(this.newPosition, this.position), 5f, 50f);
          this.delta.X = this.position.X - this.newPosition.X;
          this.delta.Y = 1f / 1000f;
          this.delta.Z = this.position.Z - this.newPosition.Z;
          this.carRot = Matrix.CreateFromAxisAngle(Vector3.Cross(Vector3.Normalize(this.delta), Vector3.Up), num / 60f);
          this.orientation *= this.carRot;
        }
        else if (this.hithard == 2)
        {
          this.carRot = Matrix.CreateFromAxisAngle(this.axisdelta * (float) this.turnDir, Rover.turnSpeed);
          this.orientation *= this.carRot;
        }
        else if (this.hithard == 22)
        {
          if ((double) this.newPosition.Y <= (double) this.gndPosition.Y)
          {
            this.shockhit = 20;
            this.velocity = Vector3.Reflect(this.velocity, this.normal);
            this.velocity.Y *= (float) this.rr.Next(80, 100) / 100f;
          }
          float num = MathHelper.Clamp(Vector3.Distance(this.newPosition, this.position), 5f, 50f);
          this.delta.X = this.position.X - this.newPosition.X;
          this.delta.Y = 1f / 1000f;
          this.delta.Z = this.position.Z - this.newPosition.Z;
          this.carRot = Matrix.CreateFromAxisAngle(Vector3.Cross(Vector3.Normalize(this.delta), Vector3.Up), num / 150f);
          this.orientation *= this.carRot;
        }
        Vector3 vector3_2 = Vector3.Transform(new Vector3(0.0f, 33f, 0.0f), this.orientation);
        this.orientation *= Matrix.CreateTranslation(vector3_1 - vector3_2);
        ++this.hangtime;
        if (this.hangtime > 30)
          this.incRot = 0.06f;
        this.lastorientation = this.orientation;
      }
      if (this.flipflag > 1)
      {
        --this.flipflag;
        this.facingDirection += Rover.turnSpeed * (float) this.turnDir;
        if ((double) this.facingDirection > 6.2831850051879883)
          this.facingDirection = 0.0f;
        if ((double) this.facingDirection < 0.0)
          this.facingDirection = 6.283185f;
        this.orientationx = Matrix.CreateRotationY(this.facingDirection);
        this.orientationx.Up = this.normal;
        this.orientationx.Right = Vector3.Cross(this.orientationx.Forward, this.orientationx.Up);
        this.orientationx.Right = Vector3.Normalize(this.orientationx.Right);
        this.orientationx.Forward = Vector3.Cross(this.orientationx.Up, this.orientationx.Right);
        this.orientationx.Forward = Vector3.Normalize(this.orientationx.Forward);
        this.orientation = this.orientationx;
      }
      if ((double) this.newPosition.Y <= (double) this.gndPosition.Y + 10.0 || this.groundflag == 1)
      {
        if (((double) this.newPosition.Y - 20.0 <= (double) this.gndPosition.Y || this.groundflag == 1) && this.hithard == 0)
        {
          this.rotAlign -= this.incRot;
          if ((double) this.rotAlign < 0.0)
            this.rotAlign = 0.0f;
        }
        float num5 = Vector3.Distance(this.position, this.newPosition);
        float num6 = MathHelper.Lerp(0.0f, 0.05f, num5 / 8f);
        float num7 = MathHelper.Lerp(0.05f, 0.01f + MathHelper.Lerp(0.06f, 0.0f, Rover.fric), (float) (((double) num5 - 8.0) / 70.0));
        this.spinny = 1f;
        if ((double) this.movement.Z > 0.0)
          this.spinny = -1f;
        if (this.flipflag == 0)
        {
          if (!this.sc.usingMouse)
          {
            if ((double) num5 <= 8.0)
              this.facingDirection += this.thumb * num6 * this.spinny;
            else
              this.facingDirection += this.thumb * num7 * this.spinny;
          }
          else if ((double) num5 <= 8.0)
            this.facingDirection += this.thumb * num6 * this.spinny;
          else
            this.facingDirection += this.thumb * num7 * this.spinny;
          if ((double) this.facingDirection > 6.283185)
            this.facingDirection = 0.0f;
          if ((double) this.facingDirection < 0.0)
            this.facingDirection = 6.283185f;
        }
        this.orientationx = Matrix.CreateRotationY(this.facingDirection);
        this.orientationx.Up = this.normal;
        this.orientationx.Right = Vector3.Cross(this.orientationx.Forward, this.orientationx.Up);
        this.orientationx.Right = Vector3.Normalize(this.orientationx.Right);
        this.orientationx.Forward = Vector3.Cross(this.orientationx.Up, this.orientationx.Right);
        this.orientationx.Forward = Vector3.Normalize(this.orientationx.Forward);
        if ((double) this.rotAlign > 0.0)
        {
          Quaternion rotation1;
          Vector3 translation1;
          this.lastorientation.Decompose(out Vector3 _, out rotation1, out translation1);
          Quaternion rotation2;
          Vector3 translation2;
          this.orientationx.Decompose(out Vector3 _, out rotation2, out translation2);
          this.orientation = Matrix.CreateFromQuaternion(Quaternion.Slerp(rotation2, rotation1, this.rotAlign)) * Matrix.CreateTranslation(Vector3.Lerp(translation2, translation1, this.rotAlign));
        }
        else
          this.orientation = this.orientationx;
        if ((double) this.movement.Z <= 0.0)
        {
          if ((double) this.movement.Z < -20.0)
          {
            float num8 = MathHelper.Clamp(Math.Abs(this.movement.Z + 15f) / 30f, 0.0f, 1f);
            this.leanAmt += this.thumb / 25f * num8 * MathHelper.Lerp(0.0f, 1.2f, Rover.fric);
            this.leanAmt = MathHelper.Clamp(this.leanAmt, -0.6f, 0.6f);
            Rover.fric += Math.Abs(this.leanAmt / 30f) * num8;
            if ((double) Rover.fric > (double) Rover.fricOrig)
              Rover.fric = Rover.fricOrig;
          }
          else
          {
            Rover.fric += 0.05f;
            if ((double) Rover.fric > (double) Rover.fricOrig)
              Rover.fric = Rover.fricOrig;
          }
        }
      }
      --this.fliptimer;
      if ((double) this.newPosition.Y <= (double) this.gndPosition.Y || this.groundflag == 1)
      {
        if (this.fliptimer > 0)
        {
          this.newPosition.Y = this.gndPosition.Y;
          this.groundflag = 0;
          this.zspin = this.movement.Z;
        }
        else
        {
          this.jumpnow = false;
          this.groundflag = 1;
          float num9 = Vector3.Distance(this.position, this.newPosition);
          if (this.hithard > 0)
          {
            this.hithard = 0;
            this.grav = Vector3.Zero;
            this.movement.Z = 0.0f;
            this.velocity = new Vector3(this.velocity.X, 0.0f, this.velocity.Z);
            this.flipflag = 0;
            this.hangtime = -30;
            this.rotAlign = 1f;
          }
          else if (this.hangtime > 1 || this.flipflag == 1)
          {
            float num10 = Vector3.Dot(Vector3.Normalize(new Vector3(this.normal.X, this.normal.Y, this.normal.Z)), Vector3.Normalize(new Vector3(this.lastorientation.Up.X, this.lastorientation.Up.Y, this.lastorientation.Up.Z)));
            float num11 = Vector3.Dot(Vector3.Normalize(this.normal), Vector3.Normalize(this.lastorientation.Right));
            float num12 = Vector3.Dot(Vector3.Normalize(this.normal), Vector3.Normalize(this.lastorientation.Forward));
            if ((double) num10 < 0.800000011920929 || this.flipflag == 1)
            {
              if (((double) Math.Abs(num11) <= (double) Math.Abs(num12) ? 2 : 1) != 1 && this.flipflag != 1)
              {
                this.flipflag = 0;
                this.shockhit = this.hangtime + 10;
                this.orientation = this.orientationx;
                this.axisdelta = this.orientation.Left;
                this.turnDir = -1;
                if (this.rr.Next(1, 1000) > 920)
                  this.turnDir = 1;
                Rover.turnSpeed = (float) ((double) this.rr.Next(5, 11) / 100.0 + (double) num9 / 350.0);
                if ((double) num12 < 0.0)
                  this.turnDir = 1;
                if ((double) this.velocity.Length() < (double) Math.Abs(Rover.max) * 0.949999988079071)
                {
                  this.hithard = 2;
                  this.velocity = Vector3.Reflect(this.velocity, this.normal);
                  float num13 = (float) this.rr.Next(3, 7) / 10f;
                  this.velocity.X *= num13;
                  this.velocity.Z *= num13;
                  this.velocity.Y = MathHelper.Clamp(Math.Abs(this.velocity.Y), 15f, 25f);
                  this.fliptimer = this.rr.Next(5, 30);
                }
                else
                {
                  this.hithard = 22;
                  this.velocity = Vector3.Reflect(this.velocity, this.normal);
                  float num14 = (float) this.rr.Next(3, 7) / 10f;
                  this.velocity.X *= num14;
                  this.velocity.Z *= num14;
                  this.velocity.Y = MathHelper.Clamp(Math.Abs(this.velocity.Y), 15f, 25f);
                  this.fliptimer = this.rr.Next(10, 130);
                }
                this.grav = Vector3.Zero;
                this.groundflag = 0;
                this.zspin = this.movement.Z;
                this.hangtime = 0;
                this.oldhangtime = 0;
                this.rotAlign = 1f;
                this.incRot = 0.06f;
              }
              else if (this.flipflag == 0)
              {
                this.flipflag = 20;
                this.oldhangtime = this.hangtime;
                this.turnDir = 1;
                Rover.turnSpeed = (float) this.rr.Next(10, 14) / 100f;
                if ((double) num11 > 0.0)
                  this.turnDir = -1;
                this.shockhit = this.hangtime + 10;
                this.hangtime = 0;
                this.hithard = 0;
              }
              else
              {
                this.flipflag = 0;
                this.orientation = this.orientationx;
                this.axisdelta = this.orientation.Forward;
                Rover.turnSpeed = (float) ((double) this.rr.Next(6, 18) / 100.0 + (double) num9 / 350.0);
                this.hithard = 1;
                this.velocity = Vector3.Reflect(this.velocity, this.normal);
                float num15 = (float) this.rr.Next(3, 7) / 10f;
                this.velocity.X *= num15;
                this.velocity.Z *= num15;
                this.velocity.Y = MathHelper.Clamp(Math.Abs(this.velocity.Y), 15f, 35f);
                this.fliptimer = this.rr.Next(5, 30);
                this.grav = Vector3.Zero;
                this.groundflag = 0;
                this.zspin = this.movement.Z;
                this.hangtime = 0;
                this.oldhangtime = 0;
                this.rotAlign = 1f;
                this.incRot = 0.06f;
              }
            }
          }
          if (this.hithard == 0)
          {
            this.hangtime = (int) MathHelper.Min((float) this.hangtime, 0.0f);
            this.newPosition.Y = this.gndPosition.Y;
          }
        }
      }
      this.leanAmt *= 0.92f;
      if ((double) Rover.fric <= (double) Rover.fricOrig)
        Rover.fric = Rover.fricOrig;
      if (flag1)
      {
        if (this.groundflag == 1)
        {
          this.sc.wheelRollMatrix *= Matrix.CreateRotationX(this.movement.Z / 25f);
        }
        else
        {
          this.zspin *= 0.986f;
          this.sc.wheelRollMatrix *= Matrix.CreateRotationX(this.zspin / 25f);
        }
      }
      this.sc.wheelRollMatrix2 = Matrix.CreateRotationY(this.thumb / 2.5f);
      this.sc.rackMatrix = Matrix.CreateTranslation((float) Math.Sin(-(double) this.thumb / 1.7999999523162842) * 4f, 0.0f, (float) (-Math.Cos(-(double) this.thumb / 1.7999999523162842) * 120.0 + 114.0));
      this.animateparts();
      float num16 = this.position.X - this.newPosition.X;
      float num17 = this.position.Z - this.newPosition.Z;
      if ((double) Math.Abs(num16) > 148.0)
        this.position.X -= (float) (Math.Sign(num16) * 148);
      else
        this.position.X = this.newPosition.X;
      if ((double) Math.Abs(num17) > 148.0)
        this.position.Z -= (float) (Math.Sign(num17) * 148);
      else
        this.position.Z = this.newPosition.Z;
      this.position.Y = this.newPosition.Y;
      this.pp = new Vector3(this.position.X, this.position.Y + MathHelper.Lerp(0.0f, 20f, Math.Abs(this.leanAmt)), this.position.Z);
    }

    public void Draw(Matrix viewMatrix, Matrix projectionMatrix, Vector3 sundir)
    {
      this.sc.BackWheelBone.Transform = this.sc.wheelRollMatrix * this.sc.BackWheelTrans;
      this.sc.leftFrontjointBone.Transform = this.sc.wheelRollMatrix2 * this.sc.leftFrontjointTrans;
      this.sc.rightFrontjointBone.Transform = this.sc.wheelRollMatrix2 * this.sc.rightFrontjointTrans;
      this.sc.leftFrontWheelBone.Transform = this.sc.wheelRollMatrix * this.sc.leftFrontWheelTrans;
      this.sc.rightFrontWheelBone.Transform = this.sc.wheelRollMatrix * this.sc.rightFrontWheelTrans;
      this.sc.rackBone.Transform = this.sc.rackMatrix * this.sc.rackTrans;
      this.sc.roverModel.CopyAbsoluteBoneTransformsTo(this.boneTransforms);
      this.pp = new Vector3(this.position.X, this.position.Y + MathHelper.Lerp(0.0f, 20f, Math.Abs(this.leanAmt)), this.position.Z);
      this.smallWorld = this.orientation * Matrix.CreateFromAxisAngle(this.orientation.Forward, this.leanAmt) * Matrix.CreateTranslation(this.pp);
      Matrix matrix = Matrix.CreateScale(1.5f) * this.smallWorld;
      for (int index = 0; index < this.sc.roverparts.Count; ++index)
      {
        ModelMesh mesh = this.sc.roverModel.Meshes[this.sc.roverparts[index]];
        int num = 1;
        if (this.dashcam == 1 && (mesh.Name == "body" || this.scoop1 == 1 || mesh.Name.Contains("weapon")))
          num = 0;
        if (num == 1)
        {
          foreach (BasicEffect effect in mesh.Effects)
          {
            effect.World = this.boneTransforms[mesh.ParentBone.Index] * matrix;
            effect.Alpha = 1f;
            effect.View = viewMatrix;
            effect.Projection = projectionMatrix;
            effect.LightingEnabled = true;
            effect.PreferPerPixelLighting = false;
            effect.DirectionalLight0.Enabled = true;
            effect.AmbientLightColor = this.amb;
            effect.DirectionalLight0.Direction = sundir;
            effect.DirectionalLight0.DiffuseColor = this.diffu;
          }
          mesh.Draw();
        }
      }
    }

    private void animateparts()
    {
      if (this.scoopflag == 1)
      {
        this.scoopflag = 0;
        if (this.scoop1 != 1)
          return;
        this.scoop1 = 2;
        this.scoopx = 1f;
      }
      else if (this.scoopflag == 2)
      {
        this.scoopflag = 0;
        if (this.scoop1 != 100)
          return;
        this.scoop1 = 4;
        this.scoopx = 0.0f;
      }
      else if (this.scoop1 == 2)
      {
        this.scoopx -= 0.05f;
        if ((double) this.scoopx <= 0.0)
        {
          this.scoopx = 0.0f;
          this.scoop1 = 100;
          this.scooperON = true;
        }
        this.sc.scooperMatrix = Matrix.CreateRotationX(MathHelper.Lerp(-0.44f, 0.0f, this.scoopx)) * Matrix.CreateTranslation(0.0f, MathHelper.Lerp(25.98f, 21.825f, this.scoopx), MathHelper.Lerp(-26.1f, 8.95f, this.scoopx));
        this.sc.scooperBone.Transform = this.sc.scooperMatrix * this.sc.scooperTrans;
      }
      else if (this.scoop1 == 4)
      {
        this.scoopx += 0.05f;
        if ((double) this.scoopx >= 1.0)
        {
          this.scoopx = 1f;
          this.scoop1 = 1;
          this.scooperON = false;
        }
        this.sc.scooperMatrix = Matrix.CreateRotationX(MathHelper.Lerp(-0.44f, 0.0f, this.scoopx)) * Matrix.CreateTranslation(0.0f, MathHelper.Lerp(25.98f, 21.825f, this.scoopx), MathHelper.Lerp(-26.1f, 8.95f, this.scoopx));
        this.sc.scooperBone.Transform = this.sc.scooperMatrix * this.sc.scooperTrans;
      }
      else if (this.solarflag == 1)
      {
        this.solarflag = 0;
        if (this.solar1 != 1)
          return;
        this.solar1 = 2;
        this.solarx = 0.0f;
        this.solary = 0.0f;
      }
      else if (this.solarflag == 2)
      {
        this.solarflag = 0;
        if (this.solar1 != 100)
          return;
        this.solar1 = 4;
        this.solarx = 4f;
        this.solary = -160f;
      }
      else if (this.solar1 == 2)
      {
        this.solarx += 0.2f;
        this.sc.solar1aMatrix = Matrix.CreateTranslation(this.solarx, 0.0f, 0.0f);
        this.sc.modelBone_0.Transform = this.sc.solar1aMatrix * this.sc.solar1aTrans;
        if ((double) this.solarx <= 4.0)
          return;
        this.solar1 = 3;
        this.solary = 0.0f;
      }
      else if (this.solar1 == 3)
      {
        this.solary -= 2f;
        this.sc.solar1bMatrix = Matrix.CreateRotationY(MathHelper.ToRadians(this.solary));
        this.sc.modelBone_1.Transform = this.sc.solar1bMatrix * this.sc.solar1bTrans;
        if ((double) this.solary >= -160.0)
          return;
        this.solar1 = 100;
      }
      else if (this.solar1 == 4)
      {
        this.solary += 4f;
        this.sc.solar1bMatrix = Matrix.CreateRotationY(MathHelper.ToRadians(this.solary));
        this.sc.modelBone_1.Transform = this.sc.solar1bMatrix * this.sc.solar1bTrans;
        if ((double) this.solary < 0.0)
          return;
        this.solar1 = 5;
        this.solarx = 4f;
      }
      else
      {
        if (this.solar1 != 5)
          return;
        this.solarx -= 0.6f;
        this.sc.solar1aMatrix = Matrix.CreateTranslation(this.solarx, 0.0f, 0.0f);
        this.sc.modelBone_0.Transform = this.sc.solar1aMatrix * this.sc.solar1aTrans;
        if ((double) this.solarx > 0.0)
          return;
        this.solar1 = 1;
      }
    }

    public void hitramp(
      int[,] heights,
      Vector3[,] normals,
      ref int onramp,
      ref Vector3 position,
      ref Vector3 newPosition,
      ref Vector3 gndPosition,
      ref Vector3 normal)
    {
      if (onramp == 0 && (double) Vector3.Distance(position, new Vector3(this.region1[0], this.region1[1], this.region1[2])) > 200.0)
      {
        this.GetHeightAndNormalX(ref heights, ref normals, newPosition, out gndPosition.Y, out normal);
      }
      else
      {
        this.rampSpline = 0.0f;
        this.myside = 0;
        if (onramp < 2)
        {
          float num1 = 0.0f;
          Vector2 vector2_1 = new Vector2(this.region1[9], this.region1[11]);
          Vector2 zero = Vector2.Zero;
          Vector2 vector2_2 = new Vector2(position.X + this.velocity.X, position.Z + this.velocity.Z);
          this.alfa = 0.0f;
          for (int index = 0; index < 12; index += 3)
          {
            Vector2 vector2_3 = vector2_1;
            vector2_1 = new Vector2(this.region1[index], this.region1[index + 2]);
            Vector2 vector2_4 = vector2_2 - vector2_3;
            Vector2 vector2_5 = vector2_2 - vector2_1;
            float num2 = (float) ((double) vector2_4.X * (double) vector2_5.Y - (double) vector2_5.X * (double) vector2_4.Y);
            float num3 = (float) Math.Acos((double) Vector2.Dot(vector2_4, vector2_5) / ((double) vector2_4.Length() * (double) vector2_5.Length()));
            float num4 = (double) num2 > 0.0 ? num3 : -num3;
            if ((double) Math.Abs(num4) > (double) num1)
            {
              num1 = Math.Abs(num4);
              this.myside = index / 3;
            }
            if (index > 0)
              this.alfa += num4;
          }
          if ((double) Math.Abs(this.alfa) >= 3.1415927410125732 && onramp == 0)
          {
            if (this.myside != 1)
            {
              newPosition.X = position.X - this.velocity.X;
              newPosition.Y = position.Y - this.velocity.Y;
              newPosition.Z = position.Z - this.velocity.Z;
              this.velocity.X = -this.velocity.X;
              this.velocity.Z = -this.velocity.Z;
              this.velocity.Y = -this.velocity.Y;
              this.movement /= 2f;
              this.grav = this.velocity;
            }
            else
              onramp = 1;
          }
          if ((double) Math.Abs(this.alfa) < 3.1415927410125732 && onramp == 1)
          {
            if (this.myside != 1)
            {
              Vector3 vector3 = Vector3.Zero;
              if (this.myside == 2)
                vector3 = new Vector3(this.region1[3], this.region1[4], this.region1[5]) - new Vector3(this.region1[0], this.region1[1], this.region1[2]);
              if (this.myside == 0)
                vector3 = new Vector3(this.region1[0], this.region1[1], this.region1[2]) - new Vector3(this.region1[3], this.region1[4], this.region1[5]);
              if (this.myside == 3)
              {
                onramp = 2;
              }
              else
              {
                this.movement /= 2f;
                newPosition.X = position.X - this.velocity.X;
                newPosition.Y = position.Y - this.velocity.Y;
                newPosition.Z = position.Z - this.velocity.Z;
                this.velocity = Vector3.Reflect(this.velocity, Vector3.Normalize(vector3)) / 1f;
                this.grav = this.velocity;
              }
              this.grav.Y = 0.0f;
            }
            else
              onramp = 0;
          }
          this.rampNormal = new Vector3(this.region1[12], this.region1[13], this.region1[14]);
          Vector3 vector3_1 = new Vector3(this.region1[0], this.region1[1], this.region1[2]);
          Vector3 vector3_2 = new Vector3(this.region1[3], this.region1[4], this.region1[5]);
          Vector3 vector3_3 = new Vector3(this.region1[6], this.region1[7], this.region1[8]);
          Vector3 vector3_4 = new Vector3(this.region1[9], this.region1[10], this.region1[11]);
          Vector3 vector3_5 = new Vector3(position.X + this.velocity.X, position.Y + this.velocity.Y, position.Z + this.velocity.Z);
          float num5 = Vector3.Distance(vector3_1, vector3_2);
          float num6 = Vector3.Distance(vector3_2, vector3_5);
          float num7 = Vector3.Distance(vector3_1, vector3_5);
          float num8 = Vector3.Distance(vector3_2, vector3_3);
          float num9 = Vector3.Distance(vector3_1, vector3_4);
          float num10 = Vector3.Distance(vector3_3, vector3_5);
          float num11 = Vector3.Distance(vector3_4, vector3_5);
          float num12 = Vector3.Distance(vector3_3, vector3_4);
          float num13 = Math.Abs((float) Math.Acos(((double) num7 * (double) num7 + (double) num6 * (double) num6 - (double) num5 * (double) num5) / (2.0 * (double) num7 * (double) num6)));
          if ((double) num13 >= 1.5)
            this.rampSpline = (float) (((double) num13 - 1.5) / 1.6415927410125732);
          float num14 = Math.Abs((float) Math.Acos(((double) num10 * (double) num10 + (double) num11 * (double) num11 - (double) num12 * (double) num12) / (2.0 * (double) num10 * (double) num11)));
          if ((double) num14 >= 2.0)
            this.rampSpline = (float) (((double) num14 - 2.0) / 1.1415927410125732);
          float num15 = (float) Math.Sin(Math.Acos(((double) num5 * (double) num5 + (double) num6 * (double) num6 - (double) num7 * (double) num7) / (2.0 * (double) num5 * (double) num6))) * num6;
          float amount1 = num15 / num8;
          float amount2 = num15 / num9;
          Vector3 vector3_6 = Vector3.Lerp(vector3_2, vector3_3, amount1);
          Vector3 vector3_7 = Vector3.Lerp(vector3_1, vector3_4, amount2);
          float amount3 = (float) Math.Sin(Math.Acos(((double) num8 * (double) num8 + (double) num10 * (double) num10 - (double) num6 * (double) num6) / (2.0 * (double) num8 * (double) num10))) * num10 / Vector3.Distance(vector3_6, vector3_7);
          this.rampHeight = MathHelper.Lerp(vector3_6.Y, vector3_7.Y, amount3);
          if (onramp == 0)
            this.rampHeight = (float) (((double) vector3_1.Y + (double) vector3_2.Y) / 2.0);
          if ((double) this.rampSpline > 0.0 && onramp == 1)
          {
            this.GetHeightAndNormalX(ref heights, ref normals, newPosition, out gndPosition.Y, out normal);
            gndPosition.Y = (float) (((double) vector3_1.Y + (double) vector3_2.Y) / 2.0);
          }
          if (onramp == 1 && (double) num14 >= 2.0)
          {
            normal = new Vector3(this.region2[12], this.region2[13], this.region2[14]);
            gndPosition.Y = MathHelper.Lerp(vector3_3.Y, vector3_4.Y, amount3);
          }
          if (onramp == 1)
            this.grav = (Vector3.Lerp(vector3_6, vector3_7, 0.5f) - vector3_5) / 30f;
        }
        if (onramp == 2)
        {
          float num16 = 0.0f;
          Vector2 vector2_6 = new Vector2(this.region2[9], this.region2[11]);
          Vector2 zero = Vector2.Zero;
          Vector2 vector2_7 = new Vector2(position.X + this.velocity.X, position.Z + this.velocity.Z);
          this.alfa = 0.0f;
          for (int index = 0; index < 12; index += 3)
          {
            Vector2 vector2_8 = vector2_6;
            vector2_6 = new Vector2(this.region2[index], this.region2[index + 2]);
            Vector2 vector2_9 = vector2_7 - vector2_8;
            Vector2 vector2_10 = vector2_7 - vector2_6;
            float num17 = (float) ((double) vector2_9.X * (double) vector2_10.Y - (double) vector2_10.X * (double) vector2_9.Y);
            float num18 = (float) Math.Acos((double) Vector2.Dot(vector2_9, vector2_10) / ((double) vector2_9.Length() * (double) vector2_10.Length()));
            float num19 = (double) num17 > 0.0 ? num18 : -num18;
            if ((double) Math.Abs(num19) > (double) num16)
            {
              num16 = Math.Abs(num19);
              this.myside = index / 3;
            }
            if (index > 0)
              this.alfa += num19;
          }
          if ((double) Math.Abs(this.alfa) < 3.1415927410125732)
          {
            onramp = this.myside;
            Vector3 vector3 = Vector3.Zero;
            if (this.myside == 2)
              vector3 = new Vector3(this.region2[3], this.region2[4], this.region2[5]) - new Vector3(this.region2[0], this.region2[1], this.region2[2]);
            if (this.myside == 0)
              vector3 = new Vector3(this.region2[0], this.region2[1], this.region2[2]) - new Vector3(this.region2[3], this.region2[4], this.region2[5]);
            if (this.myside == 2 || this.myside == 0)
            {
              newPosition.X = position.X - this.velocity.X;
              newPosition.Y = position.Y - this.velocity.Y;
              newPosition.Z = position.Z - this.velocity.Z;
              this.movement = Vector3.Zero;
              this.velocity = Vector3.Reflect(this.velocity, Vector3.Normalize(vector3)) / 1f;
              this.grav = this.velocity;
              onramp = 2;
            }
          }
          this.grav.Y = 0.0f;
          this.rampNormal = new Vector3(this.region2[12], this.region2[13], this.region2[14]);
          Vector3 vector3_8 = new Vector3(this.region2[0], this.region2[1], this.region2[2]);
          Vector3 vector3_9 = new Vector3(this.region2[3], this.region2[4], this.region2[5]);
          Vector3 vector3_10 = new Vector3(this.region2[6], this.region2[7], this.region2[8]);
          Vector3 vector3_11 = new Vector3(this.region2[9], this.region2[10], this.region2[11]);
          Vector3 vector3_12 = new Vector3(position.X + this.velocity.X, position.Y + this.velocity.Y, position.Z + this.velocity.Z);
          float num20 = Vector3.Distance(vector3_8, vector3_9);
          float num21 = Vector3.Distance(vector3_9, vector3_12);
          float num22 = Vector3.Distance(vector3_8, vector3_12);
          float num23 = Vector3.Distance(vector3_9, vector3_10);
          float num24 = Vector3.Distance(vector3_8, vector3_11);
          float num25 = Vector3.Distance(vector3_10, vector3_12);
          float num26 = Vector3.Distance(vector3_11, vector3_12);
          float num27 = Vector3.Distance(vector3_10, vector3_11);
          float num28 = Math.Abs((float) Math.Acos(((double) num22 * (double) num22 + (double) num21 * (double) num21 - (double) num20 * (double) num20) / (2.0 * (double) num22 * (double) num21)));
          if ((double) num28 >= 2.0)
            this.rampSpline = (float) (((double) num28 - 2.0) / 1.1415927410125732);
          float num29 = Math.Abs((float) Math.Acos(((double) num25 * (double) num25 + (double) num26 * (double) num26 - (double) num27 * (double) num27) / (2.0 * (double) num25 * (double) num26)));
          if ((double) num29 >= 2.5)
            this.rampSpline = (float) (((double) num29 - 2.5) / 0.64159274101257324);
          float num30 = (float) Math.Sin(Math.Acos(((double) num20 * (double) num20 + (double) num21 * (double) num21 - (double) num22 * (double) num22) / (2.0 * (double) num20 * (double) num21))) * num21;
          float amount4 = num30 / num23;
          float amount5 = num30 / num24;
          Vector3 vector3_13 = Vector3.Lerp(vector3_9, vector3_10, amount4);
          Vector3 vector3_14 = Vector3.Lerp(vector3_8, vector3_11, amount5);
          float amount6 = (float) Math.Sin(Math.Acos(((double) num23 * (double) num23 + (double) num25 * (double) num25 - (double) num21 * (double) num21) / (2.0 * (double) num23 * (double) num25))) * num25 / Vector3.Distance(vector3_13, vector3_14);
          this.rampHeight = MathHelper.Lerp(vector3_13.Y, vector3_14.Y, amount6);
          if (onramp == 2)
          {
            normal = new Vector3(this.region1[12], this.region1[13], this.region1[14]);
            gndPosition.Y = MathHelper.Lerp(vector3_9.Y, vector3_8.Y, amount6);
          }
          if (onramp == 2 && (double) num29 >= 2.5)
          {
            normal = new Vector3(this.region3[12], this.region3[13], this.region3[14]);
            gndPosition.Y = MathHelper.Lerp(vector3_10.Y, vector3_11.Y, amount6);
          }
          if (onramp == 1)
          {
            this.rampNormal = new Vector3(this.region1[12], this.region1[13], this.region1[14]);
            normal = new Vector3(this.region2[12], this.region2[13], this.region2[14]);
            gndPosition.Y = MathHelper.Lerp(vector3_9.Y, vector3_8.Y, amount6);
          }
          this.grav = (Vector3.Lerp(vector3_13, vector3_14, 0.5f) - vector3_12) / 20f;
        }
        if (onramp == 3)
        {
          float num31 = 0.0f;
          Vector2 vector2_11 = new Vector2(this.region3[9], this.region3[11]);
          Vector2 zero = Vector2.Zero;
          Vector2 vector2_12 = new Vector2(position.X + this.velocity.X, position.Z + this.velocity.Z);
          this.alfa = 0.0f;
          for (int index = 0; index < 12; index += 3)
          {
            Vector2 vector2_13 = vector2_11;
            vector2_11 = new Vector2(this.region3[index], this.region3[index + 2]);
            Vector2 vector2_14 = vector2_12 - vector2_13;
            Vector2 vector2_15 = vector2_12 - vector2_11;
            float num32 = (float) ((double) vector2_14.X * (double) vector2_15.Y - (double) vector2_15.X * (double) vector2_14.Y);
            float num33 = (float) Math.Acos((double) Vector2.Dot(vector2_14, vector2_15) / ((double) vector2_14.Length() * (double) vector2_15.Length()));
            float num34 = (double) num32 > 0.0 ? num33 : -num33;
            if ((double) Math.Abs(num34) > (double) num31)
            {
              num31 = Math.Abs(num34);
              this.myside = index / 3;
            }
            if (index > 0)
              this.alfa += num34;
          }
          if ((double) Math.Abs(this.alfa) < 3.1415927410125732)
          {
            if (this.myside != 1)
            {
              this.movement = Vector3.Zero;
              Vector3 vector3 = Vector3.Zero;
              if (this.myside == 2)
                vector3 = new Vector3(this.region3[3], this.region3[4], this.region3[5]) - new Vector3(this.region3[0], this.region3[1], this.region3[2]);
              if (this.myside == 0)
                vector3 = new Vector3(this.region3[0], this.region3[1], this.region3[2]) - new Vector3(this.region3[3], this.region3[4], this.region3[5]);
              if (this.myside == 3)
              {
                newPosition.X = position.X - this.velocity.X;
                newPosition.Y = position.Y - this.velocity.Y;
                newPosition.Z = position.Z - this.velocity.Z;
                this.velocity = Vector3.Zero;
                this.grav = this.velocity;
                this.camSwitch = 1;
              }
              else
              {
                newPosition.X = position.X - this.velocity.X;
                newPosition.Y = position.Y - this.velocity.Y;
                newPosition.Z = position.Z - this.velocity.Z;
                this.velocity = Vector3.Reflect(this.velocity, Vector3.Normalize(vector3)) / 1f;
                this.grav = this.velocity;
              }
            }
            else
              onramp = 2;
          }
          this.grav.Y = 0.0f;
          this.rampNormal = new Vector3(this.region3[12], this.region3[13], this.region3[14]);
          Vector3 vector3_15 = new Vector3(this.region3[0], this.region3[1], this.region3[2]);
          Vector3 vector3_16 = new Vector3(this.region3[3], this.region3[4], this.region3[5]);
          Vector3 vector3_17 = new Vector3(this.region3[6], this.region3[7], this.region3[8]);
          Vector3 vector3_18 = new Vector3(this.region3[9], this.region3[10], this.region3[11]);
          Vector3 vector3_19 = new Vector3(position.X + this.velocity.X, position.Y + this.velocity.Y, position.Z + this.velocity.Z);
          float num35 = Vector3.Distance(vector3_15, vector3_16);
          float num36 = Vector3.Distance(vector3_16, vector3_19);
          float num37 = Vector3.Distance(vector3_15, vector3_19);
          float num38 = Vector3.Distance(vector3_16, vector3_17);
          float num39 = Vector3.Distance(vector3_15, vector3_18);
          float num40 = Vector3.Distance(vector3_17, vector3_19);
          float num41 = Math.Abs((float) Math.Acos(((double) num37 * (double) num37 + (double) num36 * (double) num36 - (double) num35 * (double) num35) / (2.0 * (double) num37 * (double) num36)));
          if ((double) num41 >= 2.5)
            this.rampSpline = (float) (((double) num41 - 2.5) / 0.64159274101257324);
          float num42 = (float) Math.Sin(Math.Acos(((double) num35 * (double) num35 + (double) num36 * (double) num36 - (double) num37 * (double) num37) / (2.0 * (double) num35 * (double) num36))) * num36;
          float amount7 = num42 / num38;
          float amount8 = num42 / num39;
          Vector3 vector3_20 = Vector3.Lerp(vector3_16, vector3_17, amount7);
          Vector3 vector3_21 = Vector3.Lerp(vector3_15, vector3_18, amount8);
          float amount9 = (float) Math.Sin(Math.Acos(((double) num38 * (double) num38 + (double) num40 * (double) num40 - (double) num36 * (double) num36) / (2.0 * (double) num38 * (double) num40))) * num40 / Vector3.Distance(vector3_20, vector3_21);
          this.rampHeight = MathHelper.Lerp(vector3_20.Y, vector3_21.Y, amount9);
          normal = new Vector3(this.region2[12], this.region2[13], this.region2[14]);
          gndPosition.Y = MathHelper.Lerp(vector3_16.Y, vector3_15.Y, amount9);
          this.grav = (Vector3.Lerp(vector3_20, vector3_21, 0.5f) - vector3_19) / 20f;
          if (onramp == 2)
          {
            this.rampNormal = new Vector3(this.region2[12], this.region2[13], this.region2[14]);
            normal = new Vector3(this.region3[12], this.region3[13], this.region3[14]);
            gndPosition.Y = MathHelper.Lerp(vector3_16.Y, vector3_15.Y, amount9);
          }
        }
        if (onramp > 0)
        {
          normal = Vector3.Lerp(this.rampNormal, normal, this.rampSpline * 0.5f);
          normal.Normalize();
          gndPosition.Y = MathHelper.Lerp(this.rampHeight, gndPosition.Y + 0.0f, this.rampSpline / 2f);
          float num = 1f;
          if ((double) Math.Abs(this.facingDirection - this.directme) > 3.1400001049041748)
            num = -1f;
          if ((double) this.facingDirection < (double) this.directme)
            this.facingDirection += 0.03f * num;
          if ((double) this.facingDirection > (double) this.directme)
            this.facingDirection -= 0.03f * num;
          this.grav.Y = 0.0f;
        }
        if (onramp != 0)
          return;
        this.GetHeightAndNormalX(ref heights, ref normals, newPosition, out gndPosition.Y, out normal);
        if ((double) this.rampSpline <= 0.0)
          return;
        normal = Vector3.Lerp(normal, this.rampNormal, this.rampSpline * 0.5f);
        gndPosition.Y = MathHelper.Lerp(gndPosition.Y, this.rampHeight + 0.0f, this.rampSpline / 2f);
        normal.Normalize();
        this.grav.Y = 0.0f;
      }
    }

    public void hitramp2(
      int[,] heights,
      Vector3[,] normals,
      ref int onramp,
      ref Vector3 position,
      ref Vector3 newPosition,
      ref Vector3 gndPosition,
      ref Vector3 normal,
      ref Vector3 velocity)
    {
      if (onramp == 0 && (double) Vector3.Distance(position, new Vector3(this.region1[0], this.region1[1], this.region1[2])) > 200.0)
      {
        this.GetHeightAndNormalX(ref heights, ref normals, newPosition, out gndPosition.Y, out normal);
      }
      else
      {
        this.rampSpline = 0.0f;
        this.myside = 0;
        if (onramp < 2)
        {
          float num1 = 0.0f;
          Vector2 vector2_1 = new Vector2(this.region1[9], this.region1[11]);
          Vector2 zero = Vector2.Zero;
          Vector2 vector2_2 = new Vector2(position.X + velocity.X, position.Z + velocity.Z);
          this.alfa = 0.0f;
          for (int index = 0; index < 12; index += 3)
          {
            Vector2 vector2_3 = vector2_1;
            vector2_1 = new Vector2(this.region1[index], this.region1[index + 2]);
            Vector2 vector2_4 = vector2_2 - vector2_3;
            Vector2 vector2_5 = vector2_2 - vector2_1;
            float num2 = (float) ((double) vector2_4.X * (double) vector2_5.Y - (double) vector2_5.X * (double) vector2_4.Y);
            float num3 = (float) Math.Acos((double) Vector2.Dot(vector2_4, vector2_5) / ((double) vector2_4.Length() * (double) vector2_5.Length()));
            float num4 = (double) num2 > 0.0 ? num3 : -num3;
            if ((double) Math.Abs(num4) > (double) num1)
            {
              num1 = Math.Abs(num4);
              this.myside = index / 3;
            }
            if (index > 0)
              this.alfa += num4;
          }
          if ((double) Math.Abs(this.alfa) >= 3.1415927410125732 && onramp == 0)
          {
            if (this.myside != 1)
            {
              newPosition.X = position.X - velocity.X;
              newPosition.Y = position.Y - velocity.Y;
              newPosition.Z = position.Z - velocity.Z;
              velocity.X = -velocity.X;
              velocity.Z = -velocity.Z;
              velocity.Y = -velocity.Y;
            }
            else
              onramp = 1;
          }
          if ((double) Math.Abs(this.alfa) < 3.1415927410125732 && onramp == 1)
          {
            if (this.myside != 1)
            {
              Vector3 vector3 = Vector3.Zero;
              if (this.myside == 2)
                vector3 = new Vector3(this.region1[3], this.region1[4], this.region1[5]) - new Vector3(this.region1[0], this.region1[1], this.region1[2]);
              if (this.myside == 0)
                vector3 = new Vector3(this.region1[0], this.region1[1], this.region1[2]) - new Vector3(this.region1[3], this.region1[4], this.region1[5]);
              if (this.myside == 3)
              {
                onramp = 2;
              }
              else
              {
                this.movement /= 2f;
                newPosition.X = position.X - velocity.X;
                newPosition.Y = position.Y - velocity.Y;
                newPosition.Z = position.Z - velocity.Z;
                Vector3 normal1 = Vector3.Normalize(vector3);
                velocity = Vector3.Reflect(velocity, normal1) / 1.5f;
              }
            }
            else
              onramp = 0;
          }
          this.rampNormal = new Vector3(this.region1[12], this.region1[13], this.region1[14]);
          Vector3 vector3_1 = new Vector3(this.region1[0], this.region1[1], this.region1[2]);
          Vector3 vector3_2 = new Vector3(this.region1[3], this.region1[4], this.region1[5]);
          Vector3 vector3_3 = new Vector3(this.region1[6], this.region1[7], this.region1[8]);
          Vector3 vector3_4 = new Vector3(this.region1[9], this.region1[10], this.region1[11]);
          Vector3 vector3_5 = new Vector3(position.X + velocity.X, position.Y + velocity.Y, position.Z + velocity.Z);
          float num5 = Vector3.Distance(vector3_1, vector3_2);
          float num6 = Vector3.Distance(vector3_2, vector3_5);
          float num7 = Vector3.Distance(vector3_1, vector3_5);
          float num8 = Vector3.Distance(vector3_2, vector3_3);
          float num9 = Vector3.Distance(vector3_1, vector3_4);
          float num10 = Vector3.Distance(vector3_3, vector3_5);
          float num11 = Vector3.Distance(vector3_4, vector3_5);
          float num12 = Vector3.Distance(vector3_3, vector3_4);
          float num13 = Math.Abs((float) Math.Acos(((double) num7 * (double) num7 + (double) num6 * (double) num6 - (double) num5 * (double) num5) / (2.0 * (double) num7 * (double) num6)));
          if ((double) num13 >= 1.5)
            this.rampSpline = (float) (((double) num13 - 1.5) / 1.6415927410125732);
          float num14 = Math.Abs((float) Math.Acos(((double) num10 * (double) num10 + (double) num11 * (double) num11 - (double) num12 * (double) num12) / (2.0 * (double) num10 * (double) num11)));
          if ((double) num14 >= 2.0)
            this.rampSpline = (float) (((double) num14 - 2.0) / 1.1415927410125732);
          float num15 = (float) Math.Sin(Math.Acos(((double) num5 * (double) num5 + (double) num6 * (double) num6 - (double) num7 * (double) num7) / (2.0 * (double) num5 * (double) num6))) * num6;
          float amount1 = num15 / num8;
          float amount2 = num15 / num9;
          Vector3 vector3_6 = Vector3.Lerp(vector3_2, vector3_3, amount1);
          Vector3 vector3_7 = Vector3.Lerp(vector3_1, vector3_4, amount2);
          float amount3 = (float) Math.Sin(Math.Acos(((double) num8 * (double) num8 + (double) num10 * (double) num10 - (double) num6 * (double) num6) / (2.0 * (double) num8 * (double) num10))) * num10 / Vector3.Distance(vector3_6, vector3_7);
          this.rampHeight = MathHelper.Lerp(vector3_6.Y, vector3_7.Y, amount3);
          if (onramp == 0)
            this.rampHeight = (float) (((double) vector3_1.Y + (double) vector3_2.Y) / 2.0);
          if ((double) this.rampSpline > 0.0 && onramp == 1)
          {
            this.GetHeightAndNormalX(ref heights, ref normals, newPosition, out gndPosition.Y, out normal);
            gndPosition.Y = (float) (((double) vector3_1.Y + (double) vector3_2.Y) / 2.0);
          }
          if (onramp == 1 && (double) num14 >= 2.0)
          {
            normal = new Vector3(this.region2[12], this.region2[13], this.region2[14]);
            gndPosition.Y = MathHelper.Lerp(vector3_3.Y, vector3_4.Y, amount3);
          }
          if (onramp == 1)
            this.grav = (Vector3.Lerp(vector3_6, vector3_7, 0.5f) - vector3_5) / 30f;
        }
        if (onramp == 2)
        {
          float num16 = 0.0f;
          Vector2 vector2_6 = new Vector2(this.region2[9], this.region2[11]);
          Vector2 zero = Vector2.Zero;
          Vector2 vector2_7 = new Vector2(position.X + velocity.X, position.Z + velocity.Z);
          this.alfa = 0.0f;
          for (int index = 0; index < 12; index += 3)
          {
            Vector2 vector2_8 = vector2_6;
            vector2_6 = new Vector2(this.region2[index], this.region2[index + 2]);
            Vector2 vector2_9 = vector2_7 - vector2_8;
            Vector2 vector2_10 = vector2_7 - vector2_6;
            float num17 = (float) ((double) vector2_9.X * (double) vector2_10.Y - (double) vector2_10.X * (double) vector2_9.Y);
            float num18 = (float) Math.Acos((double) Vector2.Dot(vector2_9, vector2_10) / ((double) vector2_9.Length() * (double) vector2_10.Length()));
            float num19 = (double) num17 > 0.0 ? num18 : -num18;
            if ((double) Math.Abs(num19) > (double) num16)
            {
              num16 = Math.Abs(num19);
              this.myside = index / 3;
            }
            if (index > 0)
              this.alfa += num19;
          }
          if ((double) Math.Abs(this.alfa) < 3.1415927410125732)
          {
            onramp = this.myside;
            Vector3 vector3 = Vector3.Zero;
            if (this.myside == 2)
              vector3 = new Vector3(this.region2[3], this.region2[4], this.region2[5]) - new Vector3(this.region2[0], this.region2[1], this.region2[2]);
            if (this.myside == 0)
              vector3 = new Vector3(this.region2[0], this.region2[1], this.region2[2]) - new Vector3(this.region2[3], this.region2[4], this.region2[5]);
            if (this.myside == 2 || this.myside == 0)
            {
              newPosition.X = position.X - velocity.X;
              newPosition.Y = position.Y - velocity.Y;
              newPosition.Z = position.Z - velocity.Z;
              Vector3 normal2 = Vector3.Normalize(vector3);
              velocity = Vector3.Reflect(velocity, normal2) / 2f;
              onramp = 2;
            }
          }
          this.rampNormal = new Vector3(this.region2[12], this.region2[13], this.region2[14]);
          Vector3 vector3_8 = new Vector3(this.region2[0], this.region2[1], this.region2[2]);
          Vector3 vector3_9 = new Vector3(this.region2[3], this.region2[4], this.region2[5]);
          Vector3 vector3_10 = new Vector3(this.region2[6], this.region2[7], this.region2[8]);
          Vector3 vector3_11 = new Vector3(this.region2[9], this.region2[10], this.region2[11]);
          Vector3 vector3_12 = new Vector3(position.X + velocity.X, position.Y + velocity.Y, position.Z + velocity.Z);
          float num20 = Vector3.Distance(vector3_8, vector3_9);
          float num21 = Vector3.Distance(vector3_9, vector3_12);
          float num22 = Vector3.Distance(vector3_8, vector3_12);
          float num23 = Vector3.Distance(vector3_9, vector3_10);
          float num24 = Vector3.Distance(vector3_8, vector3_11);
          float num25 = Vector3.Distance(vector3_10, vector3_12);
          float num26 = Vector3.Distance(vector3_11, vector3_12);
          float num27 = Vector3.Distance(vector3_10, vector3_11);
          float num28 = Math.Abs((float) Math.Acos(((double) num22 * (double) num22 + (double) num21 * (double) num21 - (double) num20 * (double) num20) / (2.0 * (double) num22 * (double) num21)));
          if ((double) num28 >= 2.0)
            this.rampSpline = (float) (((double) num28 - 2.0) / 1.1415927410125732);
          float num29 = Math.Abs((float) Math.Acos(((double) num25 * (double) num25 + (double) num26 * (double) num26 - (double) num27 * (double) num27) / (2.0 * (double) num25 * (double) num26)));
          if ((double) num29 >= 2.5)
            this.rampSpline = (float) (((double) num29 - 2.5) / 0.64159274101257324);
          float num30 = (float) Math.Sin(Math.Acos(((double) num20 * (double) num20 + (double) num21 * (double) num21 - (double) num22 * (double) num22) / (2.0 * (double) num20 * (double) num21))) * num21;
          float amount4 = num30 / num23;
          float amount5 = num30 / num24;
          Vector3 vector3_13 = Vector3.Lerp(vector3_9, vector3_10, amount4);
          Vector3 vector3_14 = Vector3.Lerp(vector3_8, vector3_11, amount5);
          float amount6 = (float) Math.Sin(Math.Acos(((double) num23 * (double) num23 + (double) num25 * (double) num25 - (double) num21 * (double) num21) / (2.0 * (double) num23 * (double) num25))) * num25 / Vector3.Distance(vector3_13, vector3_14);
          this.rampHeight = MathHelper.Lerp(vector3_13.Y, vector3_14.Y, amount6);
          if (onramp == 2)
          {
            normal = new Vector3(this.region1[12], this.region1[13], this.region1[14]);
            gndPosition.Y = MathHelper.Lerp(vector3_9.Y, vector3_8.Y, amount6);
          }
          if (onramp == 2 && (double) num29 >= 2.5)
          {
            normal = new Vector3(this.region3[12], this.region3[13], this.region3[14]);
            gndPosition.Y = MathHelper.Lerp(vector3_10.Y, vector3_11.Y, amount6);
          }
          if (onramp == 1)
          {
            this.rampNormal = new Vector3(this.region1[12], this.region1[13], this.region1[14]);
            normal = new Vector3(this.region2[12], this.region2[13], this.region2[14]);
            gndPosition.Y = MathHelper.Lerp(vector3_9.Y, vector3_8.Y, amount6);
          }
        }
        if (onramp == 3)
        {
          float num31 = 0.0f;
          Vector2 vector2_11 = new Vector2(this.region3[9], this.region3[11]);
          Vector2 zero = Vector2.Zero;
          Vector2 vector2_12 = new Vector2(position.X + velocity.X, position.Z + velocity.Z);
          this.alfa = 0.0f;
          for (int index = 0; index < 12; index += 3)
          {
            Vector2 vector2_13 = vector2_11;
            vector2_11 = new Vector2(this.region3[index], this.region3[index + 2]);
            Vector2 vector2_14 = vector2_12 - vector2_13;
            Vector2 vector2_15 = vector2_12 - vector2_11;
            float num32 = (float) ((double) vector2_14.X * (double) vector2_15.Y - (double) vector2_15.X * (double) vector2_14.Y);
            float num33 = (float) Math.Acos((double) Vector2.Dot(vector2_14, vector2_15) / ((double) vector2_14.Length() * (double) vector2_15.Length()));
            float num34 = (double) num32 > 0.0 ? num33 : -num33;
            if ((double) Math.Abs(num34) > (double) num31)
            {
              num31 = Math.Abs(num34);
              this.myside = index / 3;
            }
            if (index > 0)
              this.alfa += num34;
          }
          if ((double) Math.Abs(this.alfa) < 3.1415927410125732)
          {
            if (this.myside != 1)
            {
              this.movement = Vector3.Zero;
              Vector3 vector3 = Vector3.Zero;
              if (this.myside == 2)
                vector3 = new Vector3(this.region3[3], this.region3[4], this.region3[5]) - new Vector3(this.region3[0], this.region3[1], this.region3[2]);
              if (this.myside == 0)
                vector3 = new Vector3(this.region3[0], this.region3[1], this.region3[2]) - new Vector3(this.region3[3], this.region3[4], this.region3[5]);
              if (this.myside == 3)
              {
                newPosition.X = position.X - velocity.X;
                newPosition.Y = position.Y - velocity.Y;
                newPosition.Z = position.Z - velocity.Z;
                velocity = Vector3.Zero;
              }
              else
              {
                newPosition.X = position.X - velocity.X;
                newPosition.Y = position.Y - velocity.Y;
                newPosition.Z = position.Z - velocity.Z;
                Vector3 normal3 = Vector3.Normalize(vector3);
                velocity = Vector3.Reflect(velocity, normal3) / 2f;
              }
            }
            else
              onramp = 2;
          }
          this.rampNormal = new Vector3(this.region3[12], this.region3[13], this.region3[14]);
          Vector3 vector3_15 = new Vector3(this.region3[0], this.region3[1], this.region3[2]);
          Vector3 vector3_16 = new Vector3(this.region3[3], this.region3[4], this.region3[5]);
          Vector3 vector3_17 = new Vector3(this.region3[6], this.region3[7], this.region3[8]);
          Vector3 vector3_18 = new Vector3(this.region3[9], this.region3[10], this.region3[11]);
          Vector3 vector3_19 = new Vector3(position.X + velocity.X, position.Y + velocity.Y, position.Z + velocity.Z);
          float num35 = Vector3.Distance(vector3_15, vector3_16);
          float num36 = Vector3.Distance(vector3_16, vector3_19);
          float num37 = Vector3.Distance(vector3_15, vector3_19);
          float num38 = Vector3.Distance(vector3_16, vector3_17);
          float num39 = Vector3.Distance(vector3_15, vector3_18);
          float num40 = Vector3.Distance(vector3_17, vector3_19);
          float num41 = Math.Abs((float) Math.Acos(((double) num37 * (double) num37 + (double) num36 * (double) num36 - (double) num35 * (double) num35) / (2.0 * (double) num37 * (double) num36)));
          if ((double) num41 >= 2.5)
            this.rampSpline = (float) (((double) num41 - 2.5) / 0.64159274101257324);
          float num42 = (float) Math.Sin(Math.Acos(((double) num35 * (double) num35 + (double) num36 * (double) num36 - (double) num37 * (double) num37) / (2.0 * (double) num35 * (double) num36))) * num36;
          float amount7 = num42 / num38;
          float amount8 = num42 / num39;
          Vector3 vector3_20 = Vector3.Lerp(vector3_16, vector3_17, amount7);
          Vector3 vector3_21 = Vector3.Lerp(vector3_15, vector3_18, amount8);
          float amount9 = (float) Math.Sin(Math.Acos(((double) num38 * (double) num38 + (double) num40 * (double) num40 - (double) num36 * (double) num36) / (2.0 * (double) num38 * (double) num40))) * num40 / Vector3.Distance(vector3_20, vector3_21);
          this.rampHeight = MathHelper.Lerp(vector3_20.Y, vector3_21.Y, amount9);
          normal = new Vector3(this.region2[12], this.region2[13], this.region2[14]);
          gndPosition.Y = MathHelper.Lerp(vector3_16.Y, vector3_15.Y, amount9);
          if (onramp == 2)
          {
            this.rampNormal = new Vector3(this.region2[12], this.region2[13], this.region2[14]);
            normal = new Vector3(this.region3[12], this.region3[13], this.region3[14]);
            gndPosition.Y = MathHelper.Lerp(vector3_16.Y, vector3_15.Y, amount9);
          }
        }
        if (onramp > 0)
        {
          normal = Vector3.Lerp(this.rampNormal, normal, this.rampSpline * 0.5f);
          normal.Normalize();
          gndPosition.Y = MathHelper.Lerp(this.rampHeight, gndPosition.Y + 0.0f, this.rampSpline / 2f);
        }
        if (onramp != 0)
          return;
        this.GetHeightAndNormalX(ref heights, ref normals, newPosition, out gndPosition.Y, out normal);
        if ((double) this.rampSpline <= 0.0)
          return;
        normal = Vector3.Lerp(normal, this.rampNormal, this.rampSpline * 0.5f);
        gndPosition.Y = MathHelper.Lerp(gndPosition.Y, this.rampHeight + 0.0f, this.rampSpline / 2f);
        normal.Normalize();
      }
    }

    public void GetHeightAndNormalX(
      ref int[,] heights,
      ref Vector3[,] normals,
      Vector3 position,
      out float height,
      out Vector3 normal)
    {
      if (Rover.nearfarm)
      {
        this.GetHeightFarmOldschool(ref heights, position, out height, out normal, false);
      }
      else
      {
        this.heightmapWidth = (float) ((this.bitmap - 1) * this.gridscale);
        position.X = (float) ((double) position.X % (double) this.heightmapWidth + 1.5 * (double) this.heightmapWidth) % this.heightmapWidth;
        position.Z = (float) ((double) position.Z % (double) this.heightmapWidth + 1.5 * (double) this.heightmapWidth) % this.heightmapWidth;
        Vector3 vector3_1 = position;
        int index1 = (int) vector3_1.X / this.gridscale;
        int index2 = (int) vector3_1.Z / this.gridscale;
        float amount1 = vector3_1.X % (float) this.gridscale / (float) this.gridscale;
        float amount2 = vector3_1.Z % (float) this.gridscale / (float) this.gridscale;
        int index3 = index1 + 1;
        int index4 = index2 + 1;
        if (index3 > this.bitmap - 2)
          index3 = 0;
        if (index4 > this.bitmap - 2)
          index4 = 0;
        float num1 = MathHelper.Lerp((float) heights[index1, index2], (float) heights[index3, index2], amount1);
        float num2 = MathHelper.Lerp((float) heights[index1, index4], (float) heights[index3, index4], amount1);
        height = MathHelper.Lerp(num1, num2, amount2);
        Vector3 vector3_2 = Vector3.Lerp(normals[index1, index2], normals[index3, index2], amount1);
        Vector3 vector3_3 = Vector3.Lerp(normals[index1, index4], normals[index3, index4], amount1);
        normal = Vector3.Lerp(vector3_2, vector3_3, amount2);
        normal.Normalize();
      }
    }

    public void GetHeightFarmOldschool(
      ref int[,] heights,
      Vector3 position,
      out float height,
      out Vector3 normal,
      bool onlyheight)
    {
      height = 1f;
      normal = Vector3.Up;
    }

    public void GetHeightFarm(
      ref int[,] heights,
      Vector3 position,
      out float height,
      out Vector3 normal,
      bool onlyheight)
    {
      Vector3 vector3_1 = new Vector3(3000f - Rover.farmLocation.X, 0.0f, 3000f - Rover.farmLocation.Z);
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
  }
}
