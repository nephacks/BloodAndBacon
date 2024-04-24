using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Text;

#pragma warning disable CS0169
#nullable disable
namespace Blood
{
  public class Overlay : GameScreen
  {
    private const float glowSize = 100f;
    private const float querySize = 50f;
    public static Vector3 manbouy;
    private Vector2 lightPosition;
    private Vector2 flareVector;
    private bool drawmanbouy = true;
    private bool drawbouy1 = true;
    private bool drawbouy2 = true;
    private bool drawfarmbouy = true;
    private bool drawflowerbouy;
    private bool drawfacility = true;
    private bool drawlanderbouy = true;
    private Color barcolor;
    private int barHite;
    private int ypos;
    private int ypos2;
    private Rectangle destbar;
    private Rectangle source;
    private Rectangle dest2;
    private Color grn = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    private float mult1;
    private float mult2;
    private float mult3;
    private float mult4;
    private float mposs1;
    private float mposs2;
    private float mposs3;
    private float mposs4;
    private float mposs5;
    private float mposs6;
    public float flowerScale = 1f;
    private int ww = 640;
    private int yy = -20;
    private int bottom;
    private int left;
    public Matrix View;
    public Matrix Projection;
    public Vector3 LightDirection;
    public float needle;
    public float landerNeedle;
    public float flowerNeedle;
    public float float_0;
    public float float_1;
    public float float_2;
    public float bouymanNeedle;
    public float facilityNeedle;
    public float farmNeedle;
    public static StringBuilder garbageBuild = new StringBuilder(32, 32);
    public string garbageString = "";
    public bool damaged1;
    private Rectangle hud1 = new Rectangle(0, 1116, 1280, 720);
    private Rectangle crackhud1 = new Rectangle(1280, 1116, 1280, 720);
    private Color offColor = new Color(0.4f, 0.4f, 0.4f);
    private Color onColor = new Color(0.3f, 0.5f, 0.33f);
    private Rectangle LanderButtons = new Rectangle(0, 0, 550, 40);
    private Rectangle RoverButtons = new Rectangle(0, 40, 550, 40);
    private Rectangle[] LB_on;
    private Rectangle[] LB_col;
    private Rectangle[] RB_on;
    private Rectangle[] RB_col;
    public float fuelTick;
    public float fuelDec = 1f;
    public float cellTick;
    public float cellDec = 1f;
    public int fuelAMT = 99;
    public int cellAMT = 70;
    private Color[] cellColor = new Color[8]
    {
      Color.Red,
      Color.OrangeRed,
      Color.Orange,
      Color.Yellow,
      Color.YellowGreen,
      new Color(0, 240, 0, (int) byte.MaxValue),
      Color.Green,
      Color.Green
    };
    private Color[] cellColor2 = new Color[8]
    {
      Color.Red,
      Color.OrangeRed,
      Color.Orange,
      Color.Yellow,
      Color.Green,
      new Color(0, 240, 0, (int) byte.MaxValue),
      Color.Green,
      Color.Green
    };
    private float cellScale = 1.6f;
    private Vector2 batpos = new Vector2(1221f, 290f);
    private Rectangle battery = new Rectangle(18, 265, 49, 327);
    private Vector2 batterybarOffset = new Vector2(5f, 81f);
    private Rectangle batteryBar = new Rectangle(260, 346, 33, 162);
    private float fuelScale = 1.8f;
    private Vector2 fuelpos = new Vector2(1192f, 290f);
    private Rectangle fuel = new Rectangle(87, 265, 78, 308);
    private Vector2 fuelbarOffset = new Vector2(7f, 35f);
    private Rectangle fuelBar = new Rectangle(179, 300, 51, 223);
    public bool bigfacilitymarker;
    private Texture2D compassBorder;
    private Texture2D compass;
    private Texture2D landerChip;
    private Texture2D bouy1texture;
    private Texture2D bouy2texture;
    private Texture2D farmtexture;
    private Texture2D bouy3texture;
    private Texture2D manbouytexture;
    private Texture2D facilityTexture;
    private Texture2D facilityTexture2;
    private Texture2D stained;
    private Texture2D dot;
    private Texture2D flowertexture;
    public Vector3 bouy1;
    public Vector3 bouy2;
    public Vector3 bouy3;
    public Vector3 facility;
    public Vector3 farm;
    public Vector3 flower;
    public int nextBouy = 1;
    public int roverbutton1;
    public int roverbutton2;
    public int roverbutton3;
    public int roverbutton4;
    public bool scopeMode;
    public int landerbutton1;
    public int landerbutton2;
    public int landerbutton3;
    public int landerbutton4;
    public float gems;
    public int buttonindex = 1;
    public int moonbuttonindex = 1;
    private Vector3 projectedPosition;
    private SpriteBatch spriteBatch;
    private SpriteFont font;
    private float occlusionAlpha;
    private ScreenManager sc;
    private ContentManager content;
    private Viewport viewport;
    private Vector2 screenCenter;
    private Rectangle rect;
    private float scaler;
    private float[] choose = new float[9]
    {
      1f,
      1f,
      1f,
      0.5f,
      0.33f,
      1f,
      1f,
      1f,
      0.1f
    };
    private Overlay.Flare[] flares = new Overlay.Flare[8]
    {
      new Overlay.Flare(0.1f, 0.7f, new Color(50, 25, 50), "astro\\sprites\\lens\\flare1"),
      new Overlay.Flare(0.4f, 0.4f, new Color(100, (int) byte.MaxValue, 200), "astro\\sprites\\lens\\flare1"),
      new Overlay.Flare(1.2f, 1f, new Color(50, 50, 50), "astro\\sprites\\lens\\flare1"),
      new Overlay.Flare(0.3f, 1f, new Color(130, 50, 100), "astro\\sprites\\lens\\flare2"),
      new Overlay.Flare(0.7f, 1.4f, new Color(100, 100, 100), "astro\\sprites\\lens\\flare2"),
      new Overlay.Flare(0.2f, 0.7f, new Color(50, 45, 25), "astro\\sprites\\lens\\flare3"),
      new Overlay.Flare(0.0f, 1f, new Color(55, 25, 25), "astro\\sprites\\lens\\flare3"),
      new Overlay.Flare(2f, 1.4f, new Color(99, 99, 110), "astro\\sprites\\lens\\flare3")
    };
    private float startwidth2;
    private float starthite2;
    private float startaspect2;
    private float stretch2;
    private Rectangle src;
    private Rectangle destn;
    private float amt;
    private Vector2 ctr;

    public void Load(ContentManager content, ScreenManager screenmanage)
    {
      this.content = content;
      this.rect = new Rectangle(0, 0, screenmanage.GraphicsDevice.PresentationParameters.BackBufferWidth, screenmanage.GraphicsDevice.PresentationParameters.BackBufferHeight);
      this.sc = screenmanage;
      this.spriteBatch = new SpriteBatch(this.sc.GraphicsDevice);
      this.viewport = this.sc.GraphicsDevice.Viewport;
      this.screenCenter = new Vector2((float) this.viewport.Width, (float) this.viewport.Height) / 2f;
      this.font = content.Load<SpriteFont>("astro\\fonts\\datafont");
      this.stained = content.Load<Texture2D>("astro\\sprites\\stained");
      this.dot = content.Load<Texture2D>("astro\\sprites\\blackdot");
      this.LB_on = new Rectangle[5];
      this.LB_col = new Rectangle[5];
      this.RB_on = new Rectangle[5];
      this.RB_col = new Rectangle[5];
      this.LB_on[0] = new Rectangle(0, 160, 100, 40);
      this.LB_on[1] = new Rectangle(0, 160, 100, 40);
      this.LB_on[2] = new Rectangle(149, 160, 100, 40);
      this.LB_on[3] = new Rectangle(298, 160, 100, 40);
      this.LB_on[4] = new Rectangle(449, 160, 100, 40);
      this.RB_on[0] = new Rectangle(0, 200, 100, 40);
      this.RB_on[1] = new Rectangle(0, 200, 100, 40);
      this.RB_on[2] = new Rectangle(149, 200, 100, 40);
      this.RB_on[3] = new Rectangle(298, 200, 100, 40);
      this.RB_on[4] = new Rectangle(449, 200, 100, 40);
      this.LB_col[0] = new Rectangle(0, 80, 100, 40);
      this.LB_col[1] = new Rectangle(0, 80, 100, 40);
      this.LB_col[2] = new Rectangle(149, 80, 100, 40);
      this.LB_col[3] = new Rectangle(298, 80, 100, 40);
      this.LB_col[4] = new Rectangle(449, 80, 100, 40);
      this.RB_col[0] = new Rectangle(0, 120, 100, 40);
      this.RB_col[1] = new Rectangle(0, 120, 100, 40);
      this.RB_col[2] = new Rectangle(149, 120, 100, 40);
      this.RB_col[3] = new Rectangle(298, 120, 100, 40);
      this.RB_col[4] = new Rectangle(449, 120, 100, 40);
      this.compassBorder = content.Load<Texture2D>("astro\\sprites\\compass\\compassBorder");
      this.compass = content.Load<Texture2D>("astro\\sprites\\compass\\compass");
      this.landerChip = content.Load<Texture2D>("astro\\sprites\\compass\\landerChip");
      this.bouy1texture = content.Load<Texture2D>("astro\\sprites\\compass\\bouy1");
      this.bouy2texture = content.Load<Texture2D>("astro\\sprites\\compass\\bouy2");
      this.bouy3texture = content.Load<Texture2D>("astro\\sprites\\compass\\bouy3");
      this.farmtexture = content.Load<Texture2D>("astro\\sprites\\compass\\farmIcon");
      this.flowertexture = content.Load<Texture2D>("astro\\sprites\\compass\\flower1");
      this.manbouytexture = content.Load<Texture2D>("astro\\sprites\\compass\\littleman");
      this.facilityTexture = content.Load<Texture2D>("astro\\sprites\\compass\\facilityIcon");
      this.facilityTexture2 = content.Load<Texture2D>("astro\\sprites\\compass\\facilityIconBig");
      foreach (Overlay.Flare flare in this.flares)
        flare.Texture = content.Load<Texture2D>(flare.TextureName);
      this.startwidth2 = (float) this.sc.helmet1.Width;
      this.starthite2 = (float) this.sc.helmet1.Height;
      this.startaspect2 = this.startwidth2 / this.starthite2;
      this.stretch2 = this.startaspect2 / this.sc.aspectratio2;
      Vector2 vector2 = new Vector2(1280f, 720f) * 0.8f;
      if ((double) vector2.X / (double) vector2.Y >= (double) this.sc.aspectratio2)
      {
        this.src = new Rectangle(0, 0, this.sc.helmet1.Width, this.sc.helmet1.Height);
        this.amt = (float) this.sc.helmet1.Width / vector2.X;
        this.destn = new Rectangle((int) ((double) this.sc.width * 0.5), (int) ((double) this.sc.hite * 0.5), (int) ((double) this.sc.width * (double) this.amt), (int) ((double) this.sc.hite / (double) this.stretch2 * (double) this.amt));
        this.ctr = new Vector2((float) this.sc.helmet1.Width, (float) this.sc.helmet1.Height) / 2f;
      }
      else
      {
        this.src = new Rectangle(0, 0, this.sc.helmet1.Width, this.sc.helmet1.Height);
        this.amt = (float) this.sc.helmet1.Height / vector2.Y;
        this.destn = new Rectangle((int) ((double) this.sc.width * 0.5), (int) ((double) this.sc.hite * 0.5), (int) ((double) this.sc.width * (double) this.stretch2 * (double) this.amt), (int) ((double) this.sc.hite * (double) this.amt));
        this.ctr = new Vector2((float) this.sc.helmet1.Width, (float) this.sc.helmet1.Height) / 2f;
      }
      this.bottom = 720 - this.RoverButtons.Height - 20;
      this.left = 640 - this.RoverButtons.Width / 2;
    }

    public override void UnloadContent() => this.content.Unload();

    public void Update(int x)
    {
      bool flag = false;
      if ((double) this.projectedPosition.Z > 0.0 || this.scopeMode || Facility.inFacility)
        flag = true;
      if (flag)
      {
        this.lightPosition = new Vector2(this.projectedPosition.X, this.projectedPosition.Y);
        this.flareVector = this.screenCenter - this.lightPosition;
        this.occlusionAlpha = MathHelper.Clamp((float) (-((double) this.LightDirection.Y - 0.10000000149011612) / 0.10000000149011612), 0.0f, 1.2f);
      }
      if (x == 1)
      {
        this.cellAMT = (int) MathHelper.Clamp((float) this.cellAMT, 5f, 100f);
        this.barcolor = this.cellColor[this.cellAMT / 20];
        int height = (int) ((double) this.cellAMT / 100.0 * (double) this.batteryBar.Height);
        int num = this.batteryBar.Height - height;
        this.destbar = new Rectangle((int) this.batpos.X + (int) ((double) this.batterybarOffset.X / (double) this.cellScale), (int) ((double) num / (double) this.cellScale) + (int) this.batpos.Y + (int) ((double) this.batterybarOffset.Y / (double) this.cellScale), (int) ((double) this.batteryBar.Width / (double) this.cellScale), (int) ((double) height / (double) this.cellScale));
        this.source = new Rectangle(this.batteryBar.X, this.batteryBar.Y + num, this.batteryBar.Width, height);
        this.dest2 = new Rectangle((int) this.batpos.X, (int) this.batpos.Y, (int) ((double) this.battery.Width / (double) this.cellScale), (int) ((double) this.battery.Height / (double) this.cellScale));
        this.mposs1 = (float) (this.ww - 7) - 70.028f * this.float_0;
        this.drawbouy1 = (double) this.mposs1 < (double) (this.ww + 118) && (double) this.mposs1 > (double) (this.ww - 125) && this.bouy1 != Vector3.Zero;
        this.mposs2 = (float) (this.ww - 7) - 70.028f * this.float_1;
        this.drawbouy2 = (double) this.mposs2 < (double) (this.ww + 118) && (double) this.mposs2 > (double) (this.ww - 125) && this.bouy2 != Vector3.Zero;
        this.mposs3 = (float) (this.ww - 7) - 70.028f * this.bouymanNeedle;
        this.drawmanbouy = (double) this.mposs3 < (double) (this.ww + 118) && (double) this.mposs3 > (double) (this.ww - 125) && Overlay.manbouy != Vector3.Zero;
        this.mposs4 = (float) (this.ww - 7) - 70.028f * this.farmNeedle;
        this.drawfarmbouy = (double) this.mposs4 < (double) (this.ww + 118) && (double) this.mposs4 > (double) (this.ww - 125) && this.farm != Vector3.Zero;
        this.mposs5 = (float) (this.ww - 12) - 70.028f * this.landerNeedle;
        this.drawlanderbouy = (double) this.mposs5 < (double) (this.ww + 112) && (double) this.mposs5 > (double) (this.ww - 132);
        this.mposs6 = (float) (this.ww - 12) - 70.028f * this.flowerNeedle;
        this.drawflowerbouy = (double) this.mposs6 < (double) (this.ww + 112) && (double) this.mposs6 > (double) (this.ww - 132) && this.flower != Vector3.Zero;
        if (this.roverbutton1 != 0)
        {
          --this.roverbutton1;
          this.mult1 = (float) this.roverbutton1 / 40f;
        }
        if (this.roverbutton2 != 0)
        {
          --this.roverbutton2;
          this.mult2 = (float) this.roverbutton2 / 40f;
        }
        if (this.roverbutton3 != 0)
        {
          --this.roverbutton3;
          this.mult3 = (float) this.roverbutton3 / 40f;
        }
        if (this.roverbutton4 != 0)
        {
          --this.roverbutton4;
          this.mult4 = (float) this.roverbutton4 / 40f;
        }
      }
      if (x != 2)
        return;
      this.fuelAMT = (int) MathHelper.Clamp((float) this.fuelAMT, 4f, 100f);
      this.barcolor = this.cellColor2[this.fuelAMT / 20];
      int height1 = (int) ((double) this.fuelAMT / 100.0 * (double) this.fuelBar.Height);
      int num1 = this.fuelBar.Height - height1;
      this.destbar = new Rectangle((int) this.fuelpos.X + (int) ((double) this.fuelbarOffset.X / (double) this.fuelScale), (int) ((double) num1 / (double) this.fuelScale) + (int) this.fuelpos.Y + (int) ((double) this.fuelbarOffset.Y / (double) this.fuelScale), (int) ((double) this.fuelBar.Width / (double) this.fuelScale), (int) ((double) height1 / (double) this.fuelScale));
      this.source = new Rectangle(this.fuelBar.X, this.fuelBar.Y + num1, this.fuelBar.Width, height1);
      this.dest2 = new Rectangle((int) this.fuelpos.X, (int) this.fuelpos.Y, (int) ((double) this.fuel.Width / (double) this.fuelScale), (int) ((double) this.fuel.Height / (double) this.fuelScale));
      this.mposs1 = (float) (this.ww - 7) - 70.028f * this.float_0;
      this.drawbouy1 = (double) this.mposs1 < (double) (this.ww + 118) && (double) this.mposs1 > (double) (this.ww - 125) && this.bouy1 != Vector3.Zero;
      this.mposs2 = (float) (this.ww - 7) - 70.028f * this.float_1;
      this.drawbouy2 = (double) this.mposs2 < (double) (this.ww + 118) && (double) this.mposs2 > (double) (this.ww - 125) && this.bouy2 != Vector3.Zero;
      this.mposs3 = (float) (this.ww - 12) - 70.028f * this.facilityNeedle;
      this.drawfacility = (double) this.mposs3 < (double) (this.ww + 112) && (double) this.mposs3 > (double) (this.ww - 132) && this.facility != Vector3.Zero;
      this.mposs4 = (float) (this.ww - 7) - 70.028f * this.bouymanNeedle;
      this.drawmanbouy = (double) this.mposs4 < (double) (this.ww + 118) && (double) this.mposs4 > (double) (this.ww - 125) && Overlay.manbouy != Vector3.Zero;
      this.mposs5 = (float) (this.ww - 7) - 70.028f * this.farmNeedle;
      this.drawfarmbouy = (double) this.mposs5 < (double) (this.ww + 118) && (double) this.mposs5 > (double) (this.ww - 125) && this.farm != Vector3.Zero;
      this.mposs6 = (float) (this.ww - 12) - 70.028f * this.flowerNeedle;
      this.drawflowerbouy = (double) this.mposs6 < (double) (this.ww + 112) && (double) this.mposs6 > (double) (this.ww - 132) && this.flower != Vector3.Zero;
      if (this.landerbutton1 != 0)
      {
        --this.landerbutton1;
        this.mult1 = (float) this.landerbutton1 / 40f;
      }
      if (this.landerbutton2 != 0)
      {
        --this.landerbutton2;
        this.mult2 = (float) this.landerbutton2 / 40f;
      }
      if (this.landerbutton3 != 0)
      {
        --this.landerbutton3;
        this.mult3 = (float) (this.landerbutton3 % 52) / 40f;
      }
      if (this.landerbutton4 == 0)
        return;
      --this.landerbutton4;
      this.mult4 = (float) this.landerbutton4 / 40f;
    }

    public void Draw(int x)
    {
      this.scaler = this.choose[this.sc.aliasSetting];
      this.projectedPosition = this.viewport.Project(-this.LightDirection, this.Projection, this.View with
      {
        Translation = Vector3.Zero
      }, Matrix.Identity);
      if (x == 1)
        this.DrawStatsRover();
      if (x == 2)
        this.DrawStatsLander();
      if (x == 3)
        this.DrawScreenHuman();
      if ((double) this.projectedPosition.Z > 0.0 || this.scopeMode || Facility.inFacility)
        return;
      this.DrawFlares(this.lightPosition, this.flareVector);
    }

    private void DrawStatsRover()
    {
      this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) null, this.sc.ScaleMatrix1);
      this.spriteBatch.Draw(this.sc.hudbuttons, this.destbar, new Rectangle?(this.source), this.barcolor);
      this.spriteBatch.Draw(this.sc.hudbuttons, this.dest2, new Rectangle?(this.battery), Color.White);
      if (this.drawbouy1)
        this.spriteBatch.Draw(this.bouy1texture, new Vector2(this.mposs1, (float) (32 + this.yy)), new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 190));
      if (this.drawbouy2)
        this.spriteBatch.Draw(this.bouy2texture, new Vector2(this.mposs2, (float) (32 + this.yy)), new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 190));
      if (this.drawmanbouy)
        this.spriteBatch.Draw(this.manbouytexture, new Vector2(this.mposs3, (float) (32 + this.yy)), new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 190));
      if (this.drawfarmbouy)
        this.spriteBatch.Draw(this.farmtexture, new Vector2(this.mposs4, (float) (32 + this.yy)), new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 190));
      if (this.drawlanderbouy)
        this.spriteBatch.Draw(this.landerChip, new Vector2(this.mposs5, (float) (32 + this.yy)), new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 190));
      if (this.drawflowerbouy)
        this.spriteBatch.Draw(this.flowertexture, new Vector2(this.mposs6, (float) (46 + this.yy)), new Rectangle?(), Color.White, 0.0f, new Vector2(12f, 12f), this.flowerScale, SpriteEffects.None, 0.0f);
      this.spriteBatch.Draw(this.compass, new Vector2((float) (this.ww - 110), (float) (30 + this.yy)), new Rectangle?(new Rectangle((int) (70.027999877929688 * (double) this.needle), 0, 220, 45)), Color.White, 0.0f, new Vector2(0.0f, 0.0f), 1f, SpriteEffects.None, 0.0f);
      this.spriteBatch.Draw(this.compassBorder, new Vector2((float) (this.ww - this.compassBorder.Width / 2), (float) (30 + this.yy)), Color.White);
      this.spriteBatch.Draw(this.sc.hudbuttons, new Vector2((float) this.left, (float) this.bottom), new Rectangle?(this.RoverButtons), Color.White);
      this.spriteBatch.Draw(this.sc.hudbuttons, new Vector2((float) this.left, (float) this.bottom) + new Vector2((float) this.RB_on[this.buttonindex].X, 0.0f), new Rectangle?(this.RB_on[this.buttonindex]), Color.White);
      if (this.roverbutton1 != 0)
        this.spriteBatch.Draw(this.sc.hudbuttons, new Vector2((float) this.left, (float) this.bottom) + new Vector2((float) this.RB_col[1].X, 0.0f), new Rectangle?(this.RB_col[1]), this.grn * this.mult1);
      if (this.roverbutton2 != 0)
        this.spriteBatch.Draw(this.sc.hudbuttons, new Vector2((float) this.left, (float) this.bottom) + new Vector2((float) this.RB_col[2].X, 0.0f), new Rectangle?(this.RB_col[2]), this.grn * this.mult2);
      if (this.roverbutton3 != 0)
        this.spriteBatch.Draw(this.sc.hudbuttons, new Vector2((float) this.left, (float) this.bottom) + new Vector2((float) this.RB_col[3].X, 0.0f), new Rectangle?(this.RB_col[3]), this.grn * this.mult3);
      if (this.roverbutton4 != 0)
        this.spriteBatch.Draw(this.sc.hudbuttons, new Vector2((float) this.left, (float) this.bottom) + new Vector2((float) this.RB_col[4].X, 0.0f), new Rectangle?(this.RB_col[4]), this.grn * this.mult4);
      this.spriteBatch.End();
    }

    private void DrawStatsLander()
    {
      this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) null, this.sc.ScaleMatrix1);
      this.spriteBatch.Draw(this.sc.hudbuttons, this.destbar, new Rectangle?(this.source), this.barcolor);
      this.spriteBatch.Draw(this.sc.hudbuttons, this.dest2, new Rectangle?(this.fuel), Color.White);
      if (this.drawbouy1)
        this.spriteBatch.Draw(this.bouy1texture, new Vector2(this.mposs1, (float) (32 + this.yy)), new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 210));
      if (this.drawbouy2)
        this.spriteBatch.Draw(this.bouy2texture, new Vector2(this.mposs2, (float) (32 + this.yy)), new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 210));
      if (this.drawfacility)
      {
        if (this.bigfacilitymarker)
          this.spriteBatch.Draw(this.facilityTexture2, new Vector2(this.mposs3, (float) (32 + this.yy)), new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 210));
        else
          this.spriteBatch.Draw(this.facilityTexture, new Vector2(this.mposs3, (float) (32 + this.yy)), new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 210));
      }
      if (this.drawmanbouy)
        this.spriteBatch.Draw(this.manbouytexture, new Vector2(this.mposs4, (float) (32 + this.yy)), new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 210));
      if (this.drawfarmbouy)
        this.spriteBatch.Draw(this.farmtexture, new Vector2(this.mposs5, (float) (32 + this.yy)), new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 210));
      if (this.drawflowerbouy)
        this.spriteBatch.Draw(this.flowertexture, new Vector2(this.mposs6, (float) (46 + this.yy)), new Rectangle?(), Color.White, 0.0f, new Vector2(12f, 12f), this.flowerScale, SpriteEffects.None, 0.0f);
      this.spriteBatch.Draw(this.compass, new Vector2((float) (this.ww - 110), (float) (30 + this.yy)), new Rectangle?(new Rectangle((int) (70.027999877929688 * (double) this.needle), 0, 220, 45)), Color.White, 0.0f, new Vector2(0.0f, 0.0f), 1f, SpriteEffects.None, 0.0f);
      this.spriteBatch.Draw(this.compassBorder, new Vector2((float) (this.ww - this.compassBorder.Width / 2), (float) (30 + this.yy)), Color.White);
      this.spriteBatch.Draw(this.sc.hudbuttons, new Vector2((float) this.left, (float) this.bottom), new Rectangle?(this.LanderButtons), Color.White);
      this.spriteBatch.Draw(this.sc.hudbuttons, new Vector2((float) this.left, (float) this.bottom) + new Vector2((float) this.LB_on[this.buttonindex].X, 0.0f), new Rectangle?(this.LB_on[this.buttonindex]), Color.White);
      if (this.landerbutton1 != 0)
        this.spriteBatch.Draw(this.sc.hudbuttons, new Vector2((float) this.left, (float) this.bottom) + new Vector2((float) this.LB_col[1].X, 0.0f), new Rectangle?(this.LB_col[1]), this.grn * this.mult2);
      if (this.landerbutton2 != 0)
        this.spriteBatch.Draw(this.sc.hudbuttons, new Vector2((float) this.left, (float) this.bottom) + new Vector2((float) this.LB_col[2].X, 0.0f), new Rectangle?(this.LB_col[2]), this.grn * this.mult2);
      if (this.landerbutton3 != 0)
        this.spriteBatch.Draw(this.sc.hudbuttons, new Vector2((float) this.left, (float) this.bottom) + new Vector2((float) this.LB_col[3].X, 0.0f), new Rectangle?(this.LB_col[3]), this.grn * this.mult3);
      if (this.landerbutton4 != 0)
        this.spriteBatch.Draw(this.sc.hudbuttons, new Vector2((float) this.left, (float) this.bottom) + new Vector2((float) this.LB_col[4].X, 0.0f), new Rectangle?(this.LB_col[4]), this.grn * this.mult4);
      this.spriteBatch.End();
    }

    private void DrawScreenHuman()
    {
      this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
      if (!this.damaged1)
        this.spriteBatch.Draw(this.sc.helmet1, this.destn, new Rectangle?(this.src), Color.White, 0.0f, this.ctr, SpriteEffects.None, 0.0f);
      if (this.damaged1)
        this.spriteBatch.Draw(this.sc.helmet2, this.destn, new Rectangle?(this.src), Color.White, 0.0f, this.ctr, SpriteEffects.None, 0.0f);
      this.spriteBatch.End();
    }

    private void DrawFlares(Vector2 lightPosition, Vector2 flareVector)
    {
      this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive);
      foreach (Overlay.Flare flare in this.flares)
      {
        Vector2 position = lightPosition + flareVector * flare.Position;
        Vector4 vector4 = flare.Color.ToVector4();
        vector4.W *= this.occlusionAlpha;
        Vector2 origin = new Vector2((float) flare.Texture.Width, (float) flare.Texture.Height) / 2f;
        this.spriteBatch.Draw(flare.Texture, position, new Rectangle?(), new Color(vector4), 1f, origin, flare.Scale, SpriteEffects.None, 0.0f);
      }
      this.spriteBatch.End();
    }

    private class Flare
    {
      public float Position;
      public float Scale;
      public Color Color;
      public string TextureName;
      public Texture2D Texture;

      public Flare(float position, float scale, Color color, string textureName)
      {
        this.Position = position;
        this.Scale = scale;
        this.Color = color;
        this.TextureName = textureName;
      }
    }
  }
}
