using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

#nullable disable
namespace Blood
{
  public class InputState
  {
    public const int MaxInputs = 4;
    public readonly GamePadState[] CurrentGamePadStates;
    public readonly GamePadState[] LastGamePadStates;
    public readonly bool[] GamePadWasConnected;
    public KeyboardState currentKeyState;
    public KeyboardState lastKeyState;

    public InputState()
    {
      this.CurrentGamePadStates = new GamePadState[4];
      this.LastGamePadStates = new GamePadState[4];
      this.GamePadWasConnected = new bool[4];
    }

    public void Update()
    {
      for (int index = 0; index < 4; ++index)
      {
        this.LastGamePadStates[index] = this.CurrentGamePadStates[index];
        this.CurrentGamePadStates[index] = GamePad.GetState((PlayerIndex) index);
        if (this.CurrentGamePadStates[index].IsConnected)
          this.GamePadWasConnected[index] = true;
      }
      this.lastKeyState = this.currentKeyState;
      this.currentKeyState = Keyboard.GetState();
    }

    public Vector2 getLeftStick(PlayerIndex? controllingPlayer)
    {
      if (controllingPlayer.HasValue)
        return this.CurrentGamePadStates[(int) controllingPlayer.Value].ThumbSticks.Left;
      if (this.CurrentGamePadStates[0].ThumbSticks.Left != Vector2.Zero)
        return this.CurrentGamePadStates[0].ThumbSticks.Left;
      if (this.CurrentGamePadStates[1].ThumbSticks.Left != Vector2.Zero)
        return this.CurrentGamePadStates[1].ThumbSticks.Left;
      if (this.CurrentGamePadStates[2].ThumbSticks.Left != Vector2.Zero)
        return this.CurrentGamePadStates[2].ThumbSticks.Left;
      return this.CurrentGamePadStates[3].ThumbSticks.Left != Vector2.Zero ? this.CurrentGamePadStates[3].ThumbSticks.Left : Vector2.Zero;
    }

    public bool IsMenuGame(PlayerIndex? controllingPlayer)
    {
      return this.IsNewButtonPress(Buttons.Back, controllingPlayer, out PlayerIndex _);
    }

    public float Trigger(string button, PlayerIndex? controllingPlayer, out float xxx)
    {
      if (controllingPlayer.HasValue)
      {
        PlayerIndex playerIndex = controllingPlayer.Value;
        xxx = 0.0f;
        int index = (int) playerIndex;
        if (button == "right")
          xxx = this.CurrentGamePadStates[index].Triggers.Right;
        if (button == "left")
          xxx = this.CurrentGamePadStates[index].Triggers.Left;
        return xxx;
      }
      xxx = this.Trigger(button, new PlayerIndex?(PlayerIndex.One), out xxx) + this.Trigger(button, new PlayerIndex?(PlayerIndex.Two), out xxx) + this.Trigger(button, new PlayerIndex?(PlayerIndex.Three), out xxx) + this.Trigger(button, new PlayerIndex?(PlayerIndex.Four), out xxx);
      return xxx;
    }

    public float IsTrigger(string val, PlayerIndex? controllingPlayer, out float xxx)
    {
      return this.Trigger(val, controllingPlayer, out xxx);
    }

    public float Stick(string button, PlayerIndex? controllingPlayer, out float xxx)
    {
      if (controllingPlayer.HasValue)
      {
        PlayerIndex playerIndex = controllingPlayer.Value;
        xxx = 0.0f;
        int index = (int) playerIndex;
        if (button == "updown")
          xxx = this.CurrentGamePadStates[index].ThumbSticks.Right.Y;
        if (button == "leftright")
          xxx = this.CurrentGamePadStates[index].ThumbSticks.Right.X;
        return xxx;
      }
      xxx = this.Stick(button, new PlayerIndex?(PlayerIndex.One), out xxx) + this.Stick(button, new PlayerIndex?(PlayerIndex.Two), out xxx) + this.Stick(button, new PlayerIndex?(PlayerIndex.Three), out xxx) + this.Stick(button, new PlayerIndex?(PlayerIndex.Four), out xxx);
      return xxx;
    }

    public float IsStick(string val, PlayerIndex? controllingPlayer, out float xxx)
    {
      return this.Stick(val, controllingPlayer, out xxx);
    }

    public bool Bumper(string button, PlayerIndex? controllingPlayer, out bool yyy)
    {
      if (controllingPlayer.HasValue)
      {
        PlayerIndex playerIndex = controllingPlayer.Value;
        yyy = false;
        int index = (int) playerIndex;
        switch (button)
        {
          case "left":
            return this.CurrentGamePadStates[index].IsButtonDown(Buttons.LeftShoulder);
          case "right":
            return this.CurrentGamePadStates[index].IsButtonDown(Buttons.RightShoulder);
          default:
            return yyy;
        }
      }
      else
        return this.Bumper(button, new PlayerIndex?(PlayerIndex.One), out yyy) || this.Bumper(button, new PlayerIndex?(PlayerIndex.Two), out yyy) || this.Bumper(button, new PlayerIndex?(PlayerIndex.Three), out yyy) || this.Bumper(button, new PlayerIndex?(PlayerIndex.Four), out yyy);
    }

    public bool IsBumper(string val, PlayerIndex? controllingPlayer, out bool yyy)
    {
      return this.Bumper(val, controllingPlayer, out yyy);
    }

    public bool IsNewButtonPress(
      Buttons button,
      PlayerIndex? controllingPlayer,
      out PlayerIndex playerIndex)
    {
      if (controllingPlayer.HasValue)
      {
        playerIndex = controllingPlayer.Value;
        int index = (int) playerIndex;
        return this.CurrentGamePadStates[index].IsButtonDown(button) && this.LastGamePadStates[index].IsButtonUp(button);
      }
      return this.IsNewButtonPress(button, new PlayerIndex?(PlayerIndex.One), out playerIndex) || this.IsNewButtonPress(button, new PlayerIndex?(PlayerIndex.Two), out playerIndex) || this.IsNewButtonPress(button, new PlayerIndex?(PlayerIndex.Three), out playerIndex) || this.IsNewButtonPress(button, new PlayerIndex?(PlayerIndex.Four), out playerIndex);
    }

    public bool IsMenuSelect(PlayerIndex? controllingPlayer, out PlayerIndex playerIndex)
    {
      if (this.IsNewButtonPress(Buttons.A, controllingPlayer, out playerIndex) || this.currentKeyState.IsKeyDown(Keys.Enter) && this.lastKeyState.IsKeyUp(Keys.Enter))
        return true;
      return this.currentKeyState.IsKeyDown(Keys.A) && this.lastKeyState.IsKeyUp(Keys.A);
    }

    public bool IsMenuCancel(PlayerIndex? controllingPlayer, out PlayerIndex playerIndex)
    {
      if (this.IsNewButtonPress(Buttons.B, controllingPlayer, out playerIndex) || this.IsNewButtonPress(Buttons.Back, controllingPlayer, out playerIndex) || this.currentKeyState.IsKeyDown(Keys.Escape) && this.lastKeyState.IsKeyUp(Keys.Escape) || this.currentKeyState.IsKeyDown(Keys.Back) && this.lastKeyState.IsKeyUp(Keys.Back) || this.currentKeyState.IsKeyDown(Keys.Delete) && this.lastKeyState.IsKeyUp(Keys.Delete))
        return true;
      return this.currentKeyState.IsKeyDown(Keys.B) && this.lastKeyState.IsKeyUp(Keys.B);
    }

    public bool IsMenuUp(PlayerIndex? controllingPlayer)
    {
      PlayerIndex playerIndex;
      if (this.IsNewButtonPress(Buttons.DPadUp, controllingPlayer, out playerIndex) || this.IsNewButtonPress(Buttons.LeftThumbstickUp, controllingPlayer, out playerIndex) || this.IsNewButtonPress(Buttons.RightThumbstickUp, controllingPlayer, out playerIndex))
        return true;
      return this.currentKeyState.IsKeyDown(Keys.Up) && this.lastKeyState.IsKeyUp(Keys.Up);
    }

    public bool IsMenuDown(PlayerIndex? controllingPlayer)
    {
      PlayerIndex playerIndex;
      if (this.IsNewButtonPress(Buttons.DPadDown, controllingPlayer, out playerIndex) || this.IsNewButtonPress(Buttons.LeftThumbstickDown, controllingPlayer, out playerIndex) || this.IsNewButtonPress(Buttons.RightThumbstickDown, controllingPlayer, out playerIndex))
        return true;
      return this.currentKeyState.IsKeyDown(Keys.Down) && this.lastKeyState.IsKeyUp(Keys.Down);
    }

    public bool IsMenuUpX(PlayerIndex? controllingPlayer)
    {
      PlayerIndex playerIndex;
      if (this.IsNewButtonPress(Buttons.DPadUp, controllingPlayer, out playerIndex) || this.IsNewButtonPress(Buttons.LeftThumbstickUp, controllingPlayer, out playerIndex))
        return true;
      return this.currentKeyState.IsKeyDown(Keys.Up) && this.lastKeyState.IsKeyUp(Keys.Up);
    }

    public bool IsMenuDownX(PlayerIndex? controllingPlayer)
    {
      PlayerIndex playerIndex;
      if (this.IsNewButtonPress(Buttons.DPadDown, controllingPlayer, out playerIndex) || this.IsNewButtonPress(Buttons.LeftThumbstickDown, controllingPlayer, out playerIndex))
        return true;
      return this.currentKeyState.IsKeyDown(Keys.Down) && this.lastKeyState.IsKeyUp(Keys.Down);
    }

    public bool IsMenuRight(PlayerIndex? controllingPlayer)
    {
      PlayerIndex playerIndex;
      if (this.IsNewButtonPress(Buttons.DPadRight, controllingPlayer, out playerIndex) || this.IsNewButtonPress(Buttons.LeftThumbstickRight, controllingPlayer, out playerIndex) || this.IsNewButtonPress(Buttons.RightThumbstickRight, controllingPlayer, out playerIndex))
        return true;
      return this.currentKeyState.IsKeyDown(Keys.Right) && this.lastKeyState.IsKeyUp(Keys.Right);
    }

    public bool IsMenuLeft(PlayerIndex? controllingPlayer)
    {
      PlayerIndex playerIndex;
      if (this.IsNewButtonPress(Buttons.DPadLeft, controllingPlayer, out playerIndex) || this.IsNewButtonPress(Buttons.LeftThumbstickLeft, controllingPlayer, out playerIndex) || this.IsNewButtonPress(Buttons.RightThumbstickLeft, controllingPlayer, out playerIndex))
        return true;
      return this.currentKeyState.IsKeyDown(Keys.Left) && this.lastKeyState.IsKeyUp(Keys.Left);
    }

    public bool IsMenuRightExclusive(PlayerIndex? controllingPlayer)
    {
      PlayerIndex playerIndex;
      if (this.IsNewButtonPress(Buttons.LeftThumbstickRight, controllingPlayer, out playerIndex) || this.IsNewButtonPress(Buttons.RightThumbstickRight, controllingPlayer, out playerIndex))
        return true;
      return this.currentKeyState.IsKeyDown(Keys.Right) && this.lastKeyState.IsKeyUp(Keys.Right);
    }

    public bool IsMenuLeftExclusive(PlayerIndex? controllingPlayer)
    {
      PlayerIndex playerIndex;
      if (this.IsNewButtonPress(Buttons.LeftThumbstickLeft, controllingPlayer, out playerIndex) || this.IsNewButtonPress(Buttons.RightThumbstickLeft, controllingPlayer, out playerIndex))
        return true;
      return this.currentKeyState.IsKeyDown(Keys.Left) && this.lastKeyState.IsKeyUp(Keys.Left);
    }

    public bool IsMenuRightX(PlayerIndex? controllingPlayer)
    {
      PlayerIndex playerIndex;
      if (this.IsNewButtonPress(Buttons.DPadRight, controllingPlayer, out playerIndex) || this.IsNewButtonPress(Buttons.LeftThumbstickRight, controllingPlayer, out playerIndex))
        return true;
      return this.currentKeyState.IsKeyDown(Keys.Right) && this.lastKeyState.IsKeyUp(Keys.Right);
    }

    public bool IsMenuLeftX(PlayerIndex? controllingPlayer)
    {
      PlayerIndex playerIndex;
      if (this.IsNewButtonPress(Buttons.DPadLeft, controllingPlayer, out playerIndex) || this.IsNewButtonPress(Buttons.LeftThumbstickLeft, controllingPlayer, out playerIndex))
        return true;
      return this.currentKeyState.IsKeyDown(Keys.Left) && this.lastKeyState.IsKeyUp(Keys.Left);
    }

    public bool IsPauseGame(PlayerIndex? controllingPlayer)
    {
      return this.IsNewButtonPress(Buttons.Start, controllingPlayer, out PlayerIndex _);
    }
  }
}
