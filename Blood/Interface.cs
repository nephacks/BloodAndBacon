using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

#pragma warning disable CS0067
#pragma warning disable CS0414
#pragma warning disable CS0649
#nullable disable
namespace Blood
{
  internal class Interface : MenuScreen
  {
    private SpriteBatch spriteBatch;
    private Rectangle fullscreen;
    private Rectangle topbar;
    private Rectangle bottombar;
    private Rectangle fullscreenRGB;
    private Rectangle topRGB;
    private Rectangle rectangle_0;
    private Rectangle cursor;
    private Rectangle buttonB;
    private Rectangle upgradeslots;
    private Rectangle emptybox;
    private Rectangle boxes;
    private Rectangle[] icons;
    private Vector2[] boxGrid = new Vector2[6]
    {
      new Vector2(317f, 260f),
      new Vector2(317f, 345f),
      new Vector2(317f, 430f),
      new Vector2(907f, 260f),
      new Vector2(907f, 345f),
      new Vector2(907f, 430f)
    };
    private Rectangle[] collide1;
    private Rectangle collideBut1;
    private Rectangle collideBut2;
    private int butpress;
    private float curX;
    private float curY;
    private float curRot;
    private float curScale = 1f;
    private float curOpacity = 0.6f;
    private float boxScaleUp = 1f;
    private int boxInc;
    private int boxIndexUp = -1;
    private float[] boxSize = new float[9]
    {
      0.95f,
      0.98f,
      1f,
      1.03f,
      1.05f,
      1.1f,
      1.13f,
      1.1f,
      1.05f
    };
    private string[] boxName = new string[6]
    {
      "Engine Type",
      "Extractor Type",
      "Solar Panel",
      "Traction Type",
      "Flatbed Depth",
      "Scoping Sys"
    };
    private float boxScaleDown = 1f;
    private int boxDec = 1;
    private int boxIndexDown = -1;
    private int flashTimer;
    private float flashAnim;
    private Rectangle glow = new Rectangle(235, 80, 66, 66);
    private int flash2 = -1;
    private float upgradeScale = 0.2f;
    private float boxOpacity = 0.9f;
    private int max;
    private float currentNum;
    private bool touching;
    private int touchingBox;
    private GamePadState gamestate;
    private GamePadState prevstate;
    private ScreenManager sc;
    private ContentManager content;
    private Matrix projection;
    private Matrix view;
    private Matrix orientation = Matrix.CreateRotationY(1f);
    private float myRot = 1.5f;
    private Vector3 sunDir = new Vector3(0.5f, 1f, 0.1f);

    public event EventHandler<PlayerIndexEventArgs> Accepted;

    public event EventHandler<PlayerIndexEventArgs> Cancelled;

    public Interface()
      : base("")
    {
      this.TransitionOnTime = TimeSpan.FromSeconds(0.0);
      this.TransitionOffTime = TimeSpan.FromSeconds(0.0);
    }

    public override void LoadContent()
    {
      if (this.content == null)
        this.content = new ContentManager((IServiceProvider) this.ScreenManager.Game.Services, "Content");
      this.spriteBatch = new SpriteBatch(this.ScreenManager.GraphicsDevice);
      this.sc = this.ScreenManager;
      this.fullscreen = new Rectangle(0, 74, 1280, 586);
      this.topbar = new Rectangle(0, 0, 1280, 80);
      this.bottombar = new Rectangle(0, 654, 1280, 66);
      this.fullscreenRGB = new Rectangle(0, 0, 150, 68);
      this.topRGB = new Rectangle(155, 0, 39, 113);
      this.rectangle_0 = new Rectangle(0, 70, 40, 40);
      this.cursor = new Rectangle(72, 116, 64, 64);
      this.curX = 640f;
      this.curY = 360f;
      this.buttonB = new Rectangle(198, 0, 26, 26);
      this.emptybox = new Rectangle(250, 0, 66, 66);
      this.boxes = new Rectangle(323, 0, 69, 22);
      this.collide1 = new Rectangle[6];
      this.upgradeslots = new Rectangle(0, 200, 206, 97);
      this.icons = new Rectangle[19];
      this.icons[0] = new Rectangle(0, 310, 66, 66);
      this.icons[1] = new Rectangle(66, 310, 66, 66);
      this.icons[2] = new Rectangle(132, 310, 66, 66);
      this.icons[3] = new Rectangle(0, 376, 66, 66);
      this.icons[4] = new Rectangle(66, 376, 66, 66);
      this.icons[5] = new Rectangle(132, 376, 66, 66);
      this.icons[6] = new Rectangle(0, 442, 66, 66);
      this.icons[7] = new Rectangle(66, 442, 66, 66);
      this.icons[8] = new Rectangle(132, 442, 66, 66);
      this.icons[9] = new Rectangle(0, 508, 66, 66);
      this.icons[10] = new Rectangle(66, 508, 66, 66);
      this.icons[11] = new Rectangle(132, 508, 66, 66);
      this.icons[12] = new Rectangle(0, 574, 66, 66);
      this.icons[13] = new Rectangle(66, 574, 66, 66);
      this.icons[14] = new Rectangle(132, 574, 66, 66);
      this.icons[15] = new Rectangle(0, 640, 66, 66);
      this.icons[16] = new Rectangle(66, 640, 66, 66);
      this.icons[17] = new Rectangle(132, 640, 66, 66);
      this.sc.RoverEquip();
    }

    public override void HandleInput(InputState input)
    {
      if (this.ControllingPlayer.HasValue)
      {
        int index = (int) this.ControllingPlayer.Value;
        this.gamestate = input.CurrentGamePadStates[index];
        this.prevstate = input.LastGamePadStates[index];
      }
      PlayerIndex playerIndex;
      if (input.IsMenuCancel(this.ControllingPlayer, out playerIndex))
      {
        this.sc.scooperMatrix = Matrix.CreateRotationX(0.0f) * Matrix.CreateTranslation(0.0f, 21.825f, 8.95f);
        this.sc.scooperBone.Transform = this.sc.scooperMatrix * this.sc.scooperTrans;
        if (this.Cancelled != null)
          this.Cancelled((object) this, new PlayerIndexEventArgs(playerIndex));
        this.ScreenManager.menuflag = 0;
        this.ExitScreen();
      }
      if (input.IsNewButtonPress(Buttons.A, this.ControllingPlayer, out playerIndex) && this.touchingBox > -1 && this.butpress > 0 && this.flashTimer <= 0)
      {
        int num = this.sc.equip[this.touchingBox * 3];
        this.sc.equip[this.touchingBox * 3] = this.sc.equip[this.touchingBox * 3 + this.butpress];
        this.sc.equip[this.touchingBox * 3 + this.butpress] = num;
        this.sc.select.Play(this.sc.ev, 0.0f, 0.0f);
        this.flashAnim = 0.0f;
        this.flashTimer = 30;
        this.flash2 = this.butpress;
        this.sc.RoverEquip();
      }
      if (this.gamestate.Buttons.RightStick == ButtonState.Pressed)
      {
        int rightStick = (int) this.prevstate.Buttons.RightStick;
      }
      if (this.gamestate.Buttons.LeftStick == ButtonState.Pressed)
      {
        int leftStick = (int) this.prevstate.Buttons.LeftStick;
      }
      float num1 = 12f;
      if (this.touching)
        num1 = 6f;
      Vector2 vector2 = this.gamestate.ThumbSticks.Left * this.gamestate.ThumbSticks.Left.Length();
      this.curX += vector2.X * num1;
      this.curY -= vector2.Y * num1;
      this.curX = MathHelper.Clamp(this.curX, 40f, 1240f);
      this.curY = MathHelper.Clamp(this.curY, 90f, 650f);
      if (this.gamestate.DPad.Right == ButtonState.Pressed && this.prevstate.DPad.Right == ButtonState.Released)
      {
        ++this.currentNum;
        if ((double) this.currentNum > (double) this.max)
          this.currentNum = (float) this.max;
      }
      if (this.gamestate.DPad.Left == ButtonState.Pressed && this.prevstate.DPad.Left == ButtonState.Released)
      {
        --this.currentNum;
        if ((double) this.currentNum < 1.0)
          this.currentNum = 1f;
      }
      if (this.gamestate.Buttons.RightShoulder == ButtonState.Pressed && this.prevstate.Buttons.RightShoulder == ButtonState.Released)
      {
        this.currentNum += (float) (this.max / 4);
        if ((double) this.currentNum > (double) this.max)
          this.currentNum = (float) this.max;
      }
      if (this.gamestate.Buttons.LeftShoulder == ButtonState.Pressed && this.prevstate.Buttons.LeftShoulder == ButtonState.Released)
      {
        this.currentNum -= (float) (this.max / 4);
        if ((double) this.currentNum < 1.0)
          this.currentNum = 1f;
      }
      if ((double) this.gamestate.ThumbSticks.Left.X >= 0.15000000596046448)
      {
        this.currentNum += this.gamestate.ThumbSticks.Left.X * 2f;
        if ((double) this.currentNum > (double) this.max)
          this.currentNum = (float) this.max;
      }
      if ((double) this.gamestate.ThumbSticks.Left.X <= -0.15000000596046448)
      {
        this.currentNum += this.gamestate.ThumbSticks.Left.X * 2f;
        if ((double) this.currentNum < 1.0)
          this.currentNum = 1f;
      }
      float num2 = -this.gamestate.ThumbSticks.Right.X;
      this.sc.wheelRollMatrix *= Matrix.CreateRotationX(-0.04f);
      this.sc.wheelRollMatrix2 = Matrix.CreateRotationY(num2 / 2.5f);
      this.sc.rackMatrix = Matrix.CreateTranslation((float) Math.Sin(-(double) num2 / 1.7999999523162842) * 4f, 0.0f, (float) (-Math.Cos(-(double) num2 / 1.7999999523162842) * 120.0 + 114.0));
      this.myRot += num2 / 15f;
      this.orientation = Matrix.CreateRotationY(this.myRot);
    }

    public override void Update(
      GameTime gameTime,
      bool otherScreenHasFocus,
      bool coveredByOtherScreen)
    {
      if (this.flashTimer > 0)
      {
        --this.flashTimer;
        this.flashAnim += 8.4f;
        if ((double) this.flashAnim > 126.0)
          this.flashAnim = 0.0f;
      }
      this.touching = false;
      for (int index = 0; index < this.collide1.Length; ++index)
      {
        Rectangle rectangle = new Rectangle((int) ((double) this.curX - 10.0), (int) ((double) this.curY - 10.0), 20, 20);
        if (this.collide1[index].Intersects(rectangle))
        {
          this.touching = true;
          this.touchingBox = index;
          this.butpress = 0;
          if (this.boxIndexUp != index)
          {
            if (this.boxIndexUp > -1)
            {
              this.boxIndexDown = this.boxIndexUp;
              this.boxDec = this.boxSize.Length - 1;
            }
            this.boxIndexUp = index;
            this.boxInc = 0;
          }
        }
      }
      if (!this.touching)
      {
        Rectangle rectangle = new Rectangle((int) ((double) this.curX - 10.0), (int) ((double) this.curY - 10.0), 20, 20);
        if (this.collideBut1.Intersects(rectangle))
        {
          this.touching = true;
          this.butpress = 1;
        }
        else if (this.collideBut2.Intersects(rectangle))
        {
          this.touching = true;
          this.butpress = 2;
        }
        else
          this.butpress = 0;
      }
      this.collideBut1 = new Rectangle(0, 0, 0, 0);
      this.collideBut2 = new Rectangle(0, 0, 0, 0);
      if (this.touching)
      {
        float num = 0.06f;
        this.curScale -= num;
        if ((double) this.curScale < 0.699999988079071)
          this.curScale = 0.7f;
        this.curOpacity += num;
        if ((double) this.curOpacity > 1.1000000238418579)
          this.curOpacity = 1.1f;
        this.curRot += num;
      }
      else
      {
        float num = 0.06f;
        this.curScale += num;
        if ((double) this.curScale > 1.0)
          this.curScale = 1f;
        this.curOpacity -= num;
        if ((double) this.curOpacity < 0.60000002384185791)
          this.curOpacity = 0.6f;
        this.curRot = 0.0f;
      }
      if (!this.touching && this.boxIndexUp > -1)
      {
        this.touchingBox = -1;
        this.boxIndexDown = this.boxIndexUp;
        this.boxDec = this.boxSize.Length - 1;
        this.boxIndexUp = -1;
        this.boxInc = 0;
        this.boxScaleUp = this.boxSize[this.boxInc];
      }
      if (this.boxIndexUp > -1)
      {
        ++this.boxInc;
        if (this.boxInc > this.boxSize.Length - 1)
          this.boxInc = this.boxSize.Length - 1;
        this.boxScaleUp = this.boxSize[this.boxInc];
      }
      if (this.boxIndexDown > -1)
      {
        --this.boxDec;
        if (this.boxDec < 0)
        {
          this.boxDec = 0;
          this.boxIndexDown = -1;
        }
        this.boxScaleDown = this.boxSize[this.boxDec];
      }
      base.Update(gameTime, otherScreenHasFocus, false);
    }

    public override void Draw(GameTime gameTime)
    {
      this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
      this.spriteBatch.Draw(this.sc.interfaceBlob, this.fullscreen, new Rectangle?(this.fullscreenRGB), Color.White);
      this.spriteBatch.End();
      this.sc.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
      this.sc.GraphicsDevice.BlendState = BlendState.NonPremultiplied;
      this.sc.GraphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;
      this.ScreenManager.GraphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;
      Vector2 vector2_1 = new Vector2(this.curX - 640f, this.curY - 320f) * -0.1f;
      this.view = Matrix.CreateLookAt(new Vector3(-200f, 120f, -vector2_1.X), new Vector3(0.0f, 30f + vector2_1.Y, -vector2_1.X), Vector3.Up);
      this.projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(60f), 1.778f, 1f, 95000f);
      this.DrawRover(this.view, this.projection, Vector3.Normalize(new Vector3(1f, -0.8f, 0.25f)));
      this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
      Vector2 vector2_2 = new Vector2(this.curX - 640f, this.curY - 320f) * -0.3f;
      for (int index = 0; index < this.boxGrid.Length; ++index)
      {
        Vector2 vector2_3 = vector2_2 + this.boxGrid[index];
        this.collide1[index] = new Rectangle((int) vector2_3.X, (int) vector2_3.Y, 66, 66);
        bool flag = true;
        if (this.touchingBox == index)
        {
          if (this.sc.equip[index * 3] != 0)
            this.spriteBatch.Draw(this.sc.interfaceBlob, vector2_3 + new Vector2(33f, 33f), new Rectangle?(this.icons[index * 3 + this.sc.equip[index * 3] - 1]), Color.White * 1f, 0.0f, new Vector2(33f, 33f), this.boxScaleUp, SpriteEffects.None, 0.0f);
          else
            this.spriteBatch.Draw(this.sc.interfaceBlob, vector2_3 + new Vector2(33f, 33f), new Rectangle?(this.emptybox), Color.White * 1f, 0.0f, new Vector2(33f, 33f), this.boxScaleUp, SpriteEffects.None, 0.0f);
          if (this.flashTimer > 0)
            this.spriteBatch.Draw(this.sc.interfaceBlob, vector2_3 + new Vector2(33f, 33f), new Rectangle?(new Rectangle(this.glow.X, 85 + (int) this.flashAnim, this.glow.Width, this.glow.Height)), Color.White, 0.0f, new Vector2(33f, 33f), this.boxScaleUp, SpriteEffects.None, 0.0f);
          if (this.touching)
          {
            if (index < 3)
            {
              int num = index * 3;
              this.spriteBatch.Draw(this.sc.interfaceBlob, vector2_3 + new Vector2(-221f, -31f), new Rectangle?(this.upgradeslots), Color.White);
              this.spriteBatch.DrawString(this.sc.tahoma2, this.boxName[index], vector2_3 + new Vector2(-221f, -28f), new Color(0, 0, 0, (int) byte.MaxValue));
              if (this.sc.equip[num + 1] != 0)
              {
                float x = vector2_3.X - 81f;
                this.collideBut1 = new Rectangle((int) x, (int) vector2_3.Y, 66, 66);
                this.spriteBatch.Draw(this.sc.interfaceBlob, new Vector2(x, vector2_3.Y), new Rectangle?(this.icons[num + this.sc.equip[num + 1] - 1]), Color.White * 1f);
                if (this.flashTimer > 0 && this.flash2 == 1)
                  this.spriteBatch.Draw(this.sc.interfaceBlob, new Vector2(x, vector2_3.Y), new Rectangle?(new Rectangle(this.glow.X, 85 + (int) this.flashAnim, this.glow.Width, this.glow.Height)), Color.White);
              }
              if (this.sc.equip[num + 2] != 0)
              {
                float x = vector2_3.X - 151f;
                this.collideBut2 = new Rectangle((int) x, (int) vector2_3.Y, 66, 66);
                this.spriteBatch.Draw(this.sc.interfaceBlob, new Vector2(x, vector2_3.Y), new Rectangle?(this.icons[num + this.sc.equip[num + 2] - 1]), Color.White * 1f);
                if (this.flashTimer > 0 && this.flash2 == 2)
                  this.spriteBatch.Draw(this.sc.interfaceBlob, new Vector2(x, vector2_3.Y), new Rectangle?(new Rectangle(this.glow.X, 85 + (int) this.flashAnim, this.glow.Width, this.glow.Height)), Color.White);
              }
            }
            else
            {
              int num = index * 3;
              this.spriteBatch.Draw(this.sc.interfaceBlob, vector2_3 + new Vector2(81f, -31f), new Rectangle?(this.upgradeslots), Color.White * 1f);
              this.spriteBatch.DrawString(this.sc.tahoma2, this.boxName[index], vector2_3 + new Vector2(81f, -28f), new Color(0, 0, 0, (int) byte.MaxValue));
              if (this.sc.equip[num + 1] != 0)
              {
                float x = vector2_3.X + 81f;
                this.collideBut1 = new Rectangle((int) x, (int) vector2_3.Y, 66, 66);
                this.spriteBatch.Draw(this.sc.interfaceBlob, new Vector2(x, vector2_3.Y), new Rectangle?(this.icons[num + this.sc.equip[num + 1] - 1]), Color.White * 1f);
                if (this.flashTimer > 0 && this.flash2 == 1)
                  this.spriteBatch.Draw(this.sc.interfaceBlob, new Vector2(x, vector2_3.Y), new Rectangle?(new Rectangle(this.glow.X, 85 + (int) this.flashAnim, this.glow.Width, this.glow.Height)), Color.White);
              }
              if (this.sc.equip[num + 2] != 0)
              {
                float x = vector2_3.X + 151f;
                this.collideBut2 = new Rectangle((int) x, (int) vector2_3.Y, 66, 66);
                this.spriteBatch.Draw(this.sc.interfaceBlob, new Vector2(x, vector2_3.Y), new Rectangle?(this.icons[num + this.sc.equip[num + 2] - 1]), Color.White * 1f);
                if (this.flashTimer > 0 && this.flash2 == 2)
                  this.spriteBatch.Draw(this.sc.interfaceBlob, new Vector2(x, vector2_3.Y), new Rectangle?(new Rectangle(this.glow.X, 85 + (int) this.flashAnim, this.glow.Width, this.glow.Height)), Color.White);
              }
            }
            flag = false;
          }
        }
        else
        {
          float scale = 1f;
          if (this.boxIndexDown == index)
            scale = this.boxScaleDown;
          if (this.sc.equip[index * 3] != 0)
            this.spriteBatch.Draw(this.sc.interfaceBlob, vector2_3 + new Vector2(33f, 33f), new Rectangle?(this.icons[index * 3 + this.sc.equip[index * 3] - 1]), Color.White * 1f, 0.0f, new Vector2(33f, 33f), scale, SpriteEffects.None, 0.0f);
          else
            this.spriteBatch.Draw(this.sc.interfaceBlob, vector2_3 + new Vector2(33f, 33f), new Rectangle?(this.emptybox), Color.White * 1f, 0.0f, new Vector2(33f, 33f), scale, SpriteEffects.None, 0.0f);
        }
        if (flag)
        {
          if (index > 2)
            this.spriteBatch.Draw(this.sc.interfaceBlob, vector2_2 + this.boxGrid[index] + new Vector2(86f, 10f), new Rectangle?(this.boxes), Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally, 0.0f);
          else
            this.spriteBatch.Draw(this.sc.interfaceBlob, vector2_2 + this.boxGrid[index] + new Vector2(-86f, 10f), new Rectangle?(this.boxes), Color.White);
        }
      }
      this.spriteBatch.Draw(this.sc.interfaceBlob, new Vector2(this.curX, this.curY), new Rectangle?(this.cursor), Color.White * this.curOpacity, this.curRot, new Vector2(32f, 32f), this.curScale, SpriteEffects.None, 0.0f);
      this.spriteBatch.Draw(this.sc.interfaceBlob, this.topbar, new Rectangle?(this.topRGB), Color.White);
      this.spriteBatch.Draw(this.sc.interfaceBlob, this.bottombar, new Rectangle?(this.rectangle_0), Color.White);
      float x1 = 115f;
      float num1 = 35f;
      this.spriteBatch.DrawString(this.sc.tahoma1, "Settings", new Vector2(x1, 40f), Color.White * 0.4f);
      float x2 = x1 + (this.sc.tahoma1.MeasureString("Settings").X + num1);
      this.spriteBatch.DrawString(this.sc.tahoma1, "Rover257", new Vector2(x2, 40f), Color.White * 1f);
      this.spriteBatch.DrawString(this.sc.tahoma1, "Lander257", new Vector2(x2 + (this.sc.tahoma1.MeasureString("Rover257").X + num1), 40f), Color.White * 0.4f);
      this.spriteBatch.End();
    }

    public void DrawRover(Matrix viewMatrix, Matrix projectionMatrix, Vector3 sundir)
    {
      this.sc.BackWheelBone.Transform = this.sc.wheelRollMatrix * this.sc.BackWheelTrans;
      this.sc.leftFrontjointBone.Transform = this.sc.wheelRollMatrix2 * this.sc.leftFrontjointTrans;
      this.sc.rightFrontjointBone.Transform = this.sc.wheelRollMatrix2 * this.sc.rightFrontjointTrans;
      this.sc.leftFrontWheelBone.Transform = this.sc.wheelRollMatrix * this.sc.leftFrontWheelTrans;
      this.sc.rightFrontWheelBone.Transform = this.sc.wheelRollMatrix * this.sc.rightFrontWheelTrans;
      this.sc.rackBone.Transform = this.sc.rackMatrix * this.sc.rackTrans;
      if (this.sc.equip[3] == 1)
        this.sc.scooperMatrix = Matrix.CreateRotationX(-0.44f) * Matrix.CreateTranslation(0.0f, 25.98f, -26.1f);
      if (this.sc.equip[3] > 1)
        this.sc.scooperMatrix = Matrix.CreateRotationX(0.0f) * Matrix.CreateTranslation(0.0f, 21f, -44f);
      this.sc.scooperBone.Transform = this.sc.scooperMatrix * this.sc.scooperTrans;
      Matrix[] destinationBoneTransforms = new Matrix[this.sc.roverModel.Bones.Count];
      this.sc.roverModel.CopyAbsoluteBoneTransformsTo(destinationBoneTransforms);
      Vector3 vector3_1 = new Vector3(0.0f, 0.0f, 0.0f);
      float angle = 0.0f;
      Vector3 position = new Vector3(vector3_1.X, vector3_1.Y + MathHelper.Lerp(0.0f, 20f, Math.Abs(angle)), vector3_1.Z);
      Matrix matrix = this.orientation * Matrix.CreateFromAxisAngle(this.orientation.Forward, angle) * Matrix.CreateTranslation(position);
      Vector3 vector3_2 = new Vector3(0.5f, 0.47f, 0.35f);
      Vector3 vector3_3 = new Vector3(1f, 1f, 1f);
      for (int index = 0; index < this.sc.roverparts.Count; ++index)
      {
        ModelMesh mesh = this.sc.roverModel.Meshes[this.sc.roverparts[index]];
        foreach (BasicEffect effect in mesh.Effects)
        {
          effect.World = destinationBoneTransforms[mesh.ParentBone.Index] * matrix;
          effect.Alpha = 1f;
          effect.View = viewMatrix;
          effect.Projection = projectionMatrix;
          effect.LightingEnabled = true;
          effect.PreferPerPixelLighting = false;
          effect.DirectionalLight0.Enabled = true;
          effect.AmbientLightColor = vector3_2;
          effect.DirectionalLight0.Direction = sundir;
          effect.DirectionalLight0.DiffuseColor = vector3_3;
        }
        mesh.Draw();
      }
    }
  }
}
