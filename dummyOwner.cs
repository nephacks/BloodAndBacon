// Decompiled with JetBrains decompiler
// Type: Blood.dummyOwner
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Steamworks;
using System;

#nullable disable
namespace Blood
{
  public class dummyOwner : IComparable<dummyOwner>
  {
    public remotePlayer4 r;
    public CSteamID id;

    public dummyOwner(remotePlayer4 r, CSteamID id)
    {
      this.r = r;
      this.id = id;
    }

    public int CompareTo(dummyOwner other) => this.id.m_SteamID.CompareTo(other.id.m_SteamID);
  }
}
