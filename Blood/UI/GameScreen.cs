using Microsoft.Xna.Framework;
using System;

#nullable disable
namespace Blood
{
  public abstract class GameScreen
  {
    public bool isSigner;
    private bool isPopup;
    private bool isHandled = true;
    public bool drawlast;
    private TimeSpan transitionOnTime = TimeSpan.Zero;
    private TimeSpan transitionOffTime = TimeSpan.Zero;
    private float transitionPosition = 1f;
    private ScreenState screenState;
    private bool isExiting;
    private bool otherScreenHasFocus;
    private ScreenManager screenManager;
    private PlayerIndex? controllingPlayer;

    public bool IsPopup
    {
      get => this.isPopup;
      protected set => this.isPopup = value;
    }

    public bool IsHandled
    {
      get => this.isHandled;
      protected set => this.isHandled = value;
    }

    public TimeSpan TransitionOnTime
    {
      get => this.transitionOnTime;
      protected set => this.transitionOnTime = value;
    }

    public TimeSpan TransitionOffTime
    {
      get => this.transitionOffTime;
      protected set => this.transitionOffTime = value;
    }

    public float TransitionPosition
    {
      get => this.transitionPosition;
      protected set => this.transitionPosition = value;
    }

    public byte TransitionAlpha
    {
      get
      {
        return (byte) ((double) byte.MaxValue - (double) this.TransitionPosition * (double) byte.MaxValue);
      }
    }

    public ScreenState ScreenState
    {
      get => this.screenState;
      protected set => this.screenState = value;
    }

    public bool IsExiting
    {
      get => this.isExiting;
      protected internal set => this.isExiting = value;
    }

    public bool IsActive
    {
      get
      {
        if (this.otherScreenHasFocus)
          return false;
        return this.screenState == ScreenState.TransitionOn || this.screenState == ScreenState.Active;
      }
    }

    public ScreenManager ScreenManager
    {
      get => this.screenManager;
      internal set => this.screenManager = value;
    }

    public PlayerIndex? ControllingPlayer
    {
      get => this.controllingPlayer;
      internal set => this.controllingPlayer = value;
    }

    public virtual void LoadContent()
    {
    }

    public virtual void UnloadContent()
    {
    }

    public virtual void Update(
      GameTime gameTime,
      bool otherScreenHasFocus,
      bool coveredByOtherScreen)
    {
      this.otherScreenHasFocus = otherScreenHasFocus;
      if (this.isExiting)
      {
        this.screenState = ScreenState.TransitionOff;
        if (this.UpdateTransition(gameTime, this.transitionOffTime, 1))
          return;
        this.ScreenManager.RemoveScreen(this);
      }
      else if (coveredByOtherScreen)
      {
        if (this.UpdateTransition(gameTime, this.transitionOffTime, 1))
          this.screenState = ScreenState.TransitionOff;
        else
          this.screenState = ScreenState.Hidden;
      }
      else if (this.UpdateTransition(gameTime, this.transitionOnTime, -1))
        this.screenState = ScreenState.TransitionOn;
      else
        this.screenState = ScreenState.Active;
    }

    private bool UpdateTransition(GameTime gameTime, TimeSpan time, int direction)
    {
      this.transitionPosition += (!(time == TimeSpan.Zero) ? (float) (gameTime.ElapsedGameTime.TotalMilliseconds / time.TotalMilliseconds) : 1f) * (float) direction;
      if ((direction >= 0 || (double) this.transitionPosition > 0.0) && (direction <= 0 || (double) this.transitionPosition < 1.0))
        return true;
      this.transitionPosition = MathHelper.Clamp(this.transitionPosition, 0.0f, 1f);
      return false;
    }

    public virtual void HandleInput(InputState input)
    {
    }

    public virtual void Draw(GameTime gameTime)
    {
    }

    public void ExitScreen()
    {
      if (this.TransitionOffTime == TimeSpan.Zero)
        this.ScreenManager.RemoveScreen(this);
      else
        this.isExiting = true;
    }
  }
}
