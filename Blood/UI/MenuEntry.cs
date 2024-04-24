using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace Blood
{
  internal class MenuEntry
  {
    private string[] lists;
    private string text;
    private int myindex;
    private int type;
    private float amount;
    private bool active;
    private ContentManager content;
    private Matrix projectionMatrix;
    private Matrix viewMatrix;
    private float aspectRatio;
    private Vector3 camlookpos = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 campos = new Vector3(0.0f, 0.0f, 2000f);
    private ScreenManager sc;
    private SpriteBatch spriteBatch;
    private Vector2 textPosition = new Vector2(256f);
    private float radians = Convert.ToSingle(Math.PI / 5.0);

    public string Text
    {
      get => this.text;
      set => this.text = value;
    }

    public int Type
    {
      get => this.type;
      set => this.type = value;
    }

    public float Amount
    {
      get => this.amount;
      set => this.amount = value;
    }

    public string[] Lists
    {
      get => this.lists;
      set => this.lists = value;
    }

    public int Myindex
    {
      get => this.myindex;
      set => this.myindex = value;
    }

    public bool Active
    {
      get => this.active;
      set => this.active = value;
    }

    public event EventHandler<PlayerIndexEventArgs> Selected;

    protected internal virtual void OnSelectEntry(PlayerIndex playerIndex)
    {
      if (this.Selected == null)
        return;
      this.Selected((object) this, new PlayerIndexEventArgs(playerIndex));
    }

    public MenuEntry(string text) => this.text = text;

    public void LoadContent(MenuScreen screen)
    {
      this.sc = screen.ScreenManager;
      if (this.content == null)
        this.content = new ContentManager((IServiceProvider) this.sc.Game.Services, "Content");
      this.spriteBatch = this.sc.SpriteBatch;
      this.aspectRatio = (float) this.sc.GraphicsDevice.Viewport.Width / (float) this.sc.GraphicsDevice.Viewport.Height;
      this.projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(30f), 1.77f, 1f, 490000f);
      this.viewMatrix = Matrix.CreateLookAt(this.campos, this.camlookpos, Vector3.Up);
    }

    public virtual void Draw(
      MenuScreen screen,
      Vector2 position,
      bool isSelected,
      GameTime gameTime,
      float index,
      float count,
      float timeadjust)
    {
      if (this.sc.menutype != 1)
        this.sc.halo = this.sc.halo2;
      count += timeadjust * 1f;
      Vector3 color = this.sc.menutype != 1 ? (isSelected ? new Vector3(2.5f, 2.5f, 2.5f) : new Vector3(0.2f, 0.5f, 0.75f)) : (isSelected ? new Vector3(2.5f, 2.5f, 2.5f) : new Vector3(0.2f, 0.5f, 0.78f));
      Vector2 vector2 = new Vector2((float) ((1280.0 - (double) this.sc.halo.MeasureString(this.text).X) / 2.0), 360f);
      if (this.type == 1)
        vector2.X = (float) (640.0 - ((double) position.X + 240.0) / 2.0);
      Vector3 position1 = new Vector3(vector2.X, position.Y, 0.0f);
      Vector3 trans2 = new Vector3((float) (640.0 + ((double) position.X + 90.0) / 2.0), position.Y + 15f, 0.0f);
      Vector3 vector3 = new Vector3(0.0f, 0.0f, 0.0f);
      float num = screen.TransitionPosition * 1.2f;
      if (screen.ScreenState == ScreenState.TransitionOn)
      {
        vector3.Y += MathHelper.Clamp((num - (float) (1.0 - ((double) index + 2.0) / (double) count)) * count, 0.0f, 1f) * 2f;
        position1.X += (float) (Math.Cos((double) vector3.Y) * 1400.0 - 1400.0);
        trans2.X += (float) (Math.Cos((double) vector3.Y) * 1400.0 - 1400.0);
      }
      else if (screen.ScreenState == ScreenState.TransitionOff)
      {
        vector3.Y -= MathHelper.Clamp((num - index / count) * count, 0.0f, 1f) * 2f;
        position1.X -= vector3.Y * 910f;
        trans2.X -= vector3.Y * 910f;
      }
      this.DrawMenu(this.text, position1, trans2, isSelected, color);
    }

    public virtual float GetHeight(MenuScreen screen) => (float) (this.sc.halo.LineSpacing + 3);

    private void DrawMenu(
      string text,
      Vector3 position,
      Vector3 trans2,
      bool isSelected,
      Vector3 color)
    {
      string text1 = "";
      if (this.Type == 1)
        text1 = this.lists[(int) this.amount] ?? "";
      Color color1 = new Color(110, 160, (int) byte.MaxValue, 150);
      color1 = new Color(5, 125, 248, 160);
      if (this.sc.menutype == 1)
        color1 = new Color(5, 125, 248, 170);
      this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) null, this.sc.ScaleMatrix1);
      float width = this.sc.halo.MeasureString(text).X + 100f;
      float height = this.sc.halo.MeasureString(text).Y + 22f;
      if (isSelected)
        this.spriteBatch.Draw(this.sc.glow1, new Rectangle((int) position.X - 50, (int) position.Y - 15, (int) width, (int) height), color1);
      this.spriteBatch.DrawString(this.sc.halo, text, new Vector2(position.X, position.Y), new Color(color.X, color.Y, color.Z, 155f));
      if (this.Type == 1)
        this.spriteBatch.DrawString(this.sc.halo, text1, new Vector2(trans2.X - this.sc.halo.MeasureString(text1).X / 2f, position.Y), new Color(color.X, color.Y, color.Z, 155f));
      this.spriteBatch.End();
    }
  }
}
