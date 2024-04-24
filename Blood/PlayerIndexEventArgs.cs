using Microsoft.Xna.Framework;
using System;

#nullable disable
namespace Blood
{
  internal class PlayerIndexEventArgs : EventArgs
  {
    private PlayerIndex playerIndex;

    public PlayerIndexEventArgs(PlayerIndex playerIndex) => this.playerIndex = playerIndex;

    public PlayerIndex PlayerIndex => this.playerIndex;
  }
}
