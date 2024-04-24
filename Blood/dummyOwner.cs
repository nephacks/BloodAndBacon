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
