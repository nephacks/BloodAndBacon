// Decompiled with JetBrains decompiler
// Type: Blood.PlayerIndexEventArgs
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

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
