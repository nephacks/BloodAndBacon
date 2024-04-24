using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Steamworks;
using System;
using System.Collections.Generic;

#nullable disable
namespace Blood
{
  public class Lobby
  {
    private SoundEffect signal;
    private ScreenManager sc;
    public bool ALLClear = true;
    public int ALLCount;
    public string ver = "";
    public int paintVersion = 59;
    public int versionNumber = 18;
    public int version4Player = 39;
    public int version6Player = 25;
    public int version4Tunnel = 160;
    public CSteamID inviteLobbyID;
    public CSteamID inviteFriendID;
    public bool inviteRequest;
    public string inviteName = "NO";
    public bool inLobby;
    public string lobbyplayers = "";
    public string friendnum = "";
    public string nickname = "Player";
    public string password = "";
    public string players = "2";
    public string lobbyVersion = "";
    public string lobbyVersion4 = "";
    public string lobbyVersion6 = "";
    public string lobbyState = "";
    public string lobbyDay = "";
    public string lobbyChar = "";
    public string lobbyName = "";
    public string lobbyPassword = "";
    public CallResult<LobbyCreated_t> lobbyCreatedResult;
    public CallResult<LobbyMatchList_t> lobbyRequestResult;
    public CallResult<LobbyEnter_t> lobbyEnteredResult;
    public Callback<GameLobbyJoinRequested_t> lobbyJoinRequest;
    public List<Lobby.dummyOwner> testlist = new List<Lobby.dummyOwner>();
    public List<Lobby.lobbyowner> lobbys = new List<Lobby.lobbyowner>();
    public List<CSteamID> joinedLobby = new List<CSteamID>();
    public List<CSteamID> createdLobby = new List<CSteamID>();

    public Lobby(ScreenManager screenmanager, SoundEffect noise)
    {
      this.signal = noise;
      this.sc = screenmanager;
    }

    public void acceptRequests()
    {
      if (!SteamAPI.IsSteamRunning())
        return;
      this.inviteRequest = false;
      this.lobbyJoinRequest = Callback<GameLobbyJoinRequested_t>.Create(new Callback<GameLobbyJoinRequested_t>.DispatchDelegate(this.onJoinRequestResult));
    }

    public void onJoinRequestResult(GameLobbyJoinRequested_t pCallback)
    {
      if (this.inviteRequest || !SteamAPI.IsSteamRunning())
        return;
      this.inviteLobbyID = pCallback.m_steamIDLobby;
      this.inviteFriendID = pCallback.m_steamIDFriend;
      this.inviteRequest = true;
      this.inviteName = "NO";
      try
      {
        char[] charArray = SteamFriends.GetFriendPersonaName(this.inviteFriendID).ToCharArray();
        this.inviteName = "";
        for (int index = 0; index < charArray.Length; ++index)
        {
          if (!this.sc.font2.Characters.Contains(charArray[index]))
            charArray[index] = '*';
          this.inviteName += charArray[index].ToString();
        }
      }
      catch
      {
      }
      if (!(this.inviteName == ""))
        return;
      this.inviteName = "NO";
    }

    public void getFriendsLobby()
    {
      int friendCount = SteamFriends.GetFriendCount(EFriendFlags.k_EFriendFlagImmediate);
      for (int iFriend = 0; iFriend < friendCount; ++iFriend)
      {
        CSteamID friendByIndex = SteamFriends.GetFriendByIndex(iFriend, EFriendFlags.k_EFriendFlagImmediate);
        FriendGameInfo_t pFriendGameInfo;
        if (SteamFriends.GetFriendGamePlayed(friendByIndex, out pFriendGameInfo) && pFriendGameInfo.m_steamIDLobby.IsValid() && pFriendGameInfo.m_gameID.AppID().m_AppId == 434570U)
        {
          CSteamID steamIdLobby = pFriendGameInfo.m_steamIDLobby;
          string friendPersonaName = SteamFriends.GetFriendPersonaName(friendByIndex);
          string lobbyData1 = SteamMatchmaking.GetLobbyData(steamIdLobby, "state");
          string lobbyData2 = SteamMatchmaking.GetLobbyData(steamIdLobby, "players");
          char[] charArray = friendPersonaName.ToCharArray();
          string str = "";
          try
          {
            for (int index = 0; index < charArray.Length; ++index)
            {
              if (!this.sc.font2.Characters.Contains(charArray[index]))
                charArray[index] = '*';
              str += charArray[index].ToString();
            }
          }
          catch
          {
          }
          if (str == "")
            str = "waiting";
          Lobby.lobbyowner lobbyowner = new Lobby.lobbyowner();
          lobbyowner.id = steamIdLobby;
          lobbyowner.name = str;
          lobbyowner.state = lobbyData1;
          bool flag = true;
          for (int index = 0; index < this.lobbys.Count; ++index)
          {
            if (lobbyowner.id == this.lobbys[index].id)
            {
              flag = false;
              break;
            }
          }
          if (flag && lobbyData2 == this.friendnum)
            this.lobbys.Add(lobbyowner);
        }
      }
    }

    private void onLobbyRequestResult(LobbyMatchList_t pCallback, bool fails)
    {
      uint nLobbiesMatching = pCallback.m_nLobbiesMatching;
      this.lobbys.Clear();
      if (nLobbiesMatching > 0U)
      {
        for (int iLobby = 0; (long) iLobby < (long) nLobbiesMatching; ++iLobby)
        {
          CSteamID lobbyByIndex = SteamMatchmaking.GetLobbyByIndex(iLobby);
          string lobbyData1 = SteamMatchmaking.GetLobbyData(lobbyByIndex, "name");
          string lobbyData2 = SteamMatchmaking.GetLobbyData(lobbyByIndex, "state");
          char[] charArray = lobbyData1.ToCharArray();
          string str = "";
          try
          {
            for (int index = 0; index < charArray.Length; ++index)
            {
              if (!this.sc.font2.Characters.Contains(charArray[index]))
                charArray[index] = '*';
              str += charArray[index].ToString();
            }
          }
          catch
          {
          }
          if (str == "")
            str = "waiting";
          this.lobbys.Add(new Lobby.lobbyowner()
          {
            id = lobbyByIndex,
            name = str,
            state = lobbyData2
          });
        }
      }
      this.sc.lobby.getFriendsLobby();
    }

    public void requestLobby(string num)
    {
      if (!SteamAPI.IsSteamRunning())
        return;
      this.friendnum = num;
      SteamMatchmaking.AddRequestLobbyListStringFilter("players", num, ELobbyComparison.k_ELobbyComparisonEqual);
      this.lobbyRequestResult = CallResult<LobbyMatchList_t>.Create(new CallResult<LobbyMatchList_t>.APIDispatchDelegate(this.onLobbyRequestResult));
      SteamMatchmaking.AddRequestLobbyListResultCountFilter(50);
      SteamMatchmaking.AddRequestLobbyListDistanceFilter(ELobbyDistanceFilter.k_ELobbyDistanceFilterWorldwide);
      this.lobbyRequestResult.Set(SteamMatchmaking.RequestLobbyList());
    }

    private void onLobbyEnterResult(LobbyEnter_t pCallback, bool failed)
    {
      if (!SteamAPI.IsSteamRunning())
        return;
      if (pCallback.m_EChatRoomEnterResponse == 1U)
      {
        CSteamID steamIDLobby = new CSteamID(pCallback.m_ulSteamIDLobby);
        this.lobbyplayers = SteamMatchmaking.GetLobbyData(steamIDLobby, "players");
        this.joinedLobby.Add(steamIDLobby);
        this.inLobby = true;
      }
      else
      {
        CSteamID csteamId = new CSteamID();
        this.lobbyplayers = "0";
        this.joinedLobby.Add(csteamId);
        this.inLobby = false;
      }
    }

    public int joinLobby(CSteamID lobbyid)
    {
      if (!SteamAPI.IsSteamRunning() || this.createdLobby.Contains(lobbyid))
        return 0;
      if (this.createdLobby.Count > 0)
        this.uncreateLobby();
      if (!this.joinedLobby.Contains(lobbyid))
      {
        if (this.joinedLobby.Count > 0)
          this.leaveLobby();
        this.lobbyEnteredResult = CallResult<LobbyEnter_t>.Create(new CallResult<LobbyEnter_t>.APIDispatchDelegate(this.onLobbyEnterResult));
        this.lobbyEnteredResult.Set(SteamMatchmaking.JoinLobby(lobbyid));
        this.inLobby = false;
        this.lobbyChar = "";
        this.lobbyDay = "wait";
        this.lobbyState = "";
        this.lobbyVersion = "";
        this.lobbyPassword = "";
        return 200;
      }
      int num = 0;
      if (SteamMatchmaking.GetLobbyData(lobbyid, "state") == "10")
      {
        string lobbyData = SteamMatchmaking.GetLobbyData(lobbyid, "version");
        bool flag1 = this.lobbyplayers == "2" && lobbyData == this.versionNumber.ToString();
        bool flag2 = this.lobbyplayers == "4" && lobbyData == this.version4Player.ToString();
        bool flag3 = this.lobbyplayers == "6" && lobbyData == this.version6Player.ToString();
        bool flag4 = this.lobbyplayers == "4" && lobbyData == this.version4Tunnel.ToString();
        bool flag5 = this.lobbyplayers == "3" && SteamMatchmaking.GetLobbyData(lobbyid, "day") == this.paintVersion.ToString();
        if (flag4 || flag5 || flag1 || flag2 || flag3)
        {
          string str = SteamMatchmaking.GetLobbyData(lobbyid, "day");
          if (flag5)
            str = "1";
#pragma warning disable CS0168
          try
          {
            if (str != "")
              num = Convert.ToInt32(str);
          }
          catch (OverflowException ex)
          {
            num = 0;
          }
          catch (FormatException ex)
          {
            num = 0;
          }
#pragma warning restore CS0168
        }
      }
      return num;
    }

    private void onLobbyCreatedResult(LobbyCreated_t pCallback, bool fails)
    {
      if (SteamAPI.IsSteamRunning())
      {
        if (pCallback.m_eResult == EResult.k_EResultOK)
        {
          this.ver = this.versionNumber.ToString();
          if (this.players == "6")
            this.ver = this.version6Player.ToString();
          if (this.players == "4")
            this.ver = this.version4Player.ToString();
          if (this.players == "44")
          {
            this.ver = this.version4Tunnel.ToString();
            this.players = "4";
          }
          CSteamID ulSteamIdLobby = (CSteamID) pCallback.m_ulSteamIDLobby;
          string personaName = SteamFriends.GetPersonaName();
          SteamMatchmaking.SetLobbyData(ulSteamIdLobby, "name", personaName);
          SteamMatchmaking.SetLobbyData(ulSteamIdLobby, "state", "0");
          SteamMatchmaking.SetLobbyData(ulSteamIdLobby, "day", "0");
          SteamMatchmaking.SetLobbyData(ulSteamIdLobby, "char", "11");
          SteamMatchmaking.SetLobbyData(ulSteamIdLobby, "nickname", this.nickname);
          SteamMatchmaking.SetLobbyData(ulSteamIdLobby, "version", this.ver);
          SteamMatchmaking.SetLobbyData(ulSteamIdLobby, "password", this.password);
          SteamMatchmaking.SetLobbyData(ulSteamIdLobby, "players", this.players);
          if (!this.createdLobby.Contains(ulSteamIdLobby))
          {
            this.createdLobby.Add(ulSteamIdLobby);
            this.sc.errorMessage = "lobby created";
            this.sc.errorMessageTimer = 150;
          }
          else
          {
            this.sc.errorMessage = "lobby null";
            this.sc.errorMessageTimer = 150;
          }
          this.ALLClear = true;
        }
        else
        {
          this.sc.errorMessage = "lobby failed";
          this.sc.errorMessageTimer = 150;
        }
        this.ALLClear = true;
      }
      else
      {
        this.sc.errorMessage = "no lobby no steam";
        this.sc.errorMessageTimer = 150;
      }
    }

    public void setPassword(CSteamID lobby)
    {
      if (!SteamAPI.IsSteamRunning())
        return;
      SteamMatchmaking.SetLobbyData(lobby, "password", this.password);
    }

    public void createLobby(int num)
    {
      if (SteamAPI.IsSteamRunning())
      {
        if (this.createdLobby.Count > 0)
          this.uncreateLobby();
        if (this.joinedLobby.Count > 0)
          this.leaveLobby();
        this.players = num.ToString();
        if (num == 44)
          num = 4;
        this.lobbyCreatedResult = CallResult<LobbyCreated_t>.Create(new CallResult<LobbyCreated_t>.APIDispatchDelegate(this.onLobbyCreatedResult));
        this.lobbyCreatedResult.Set(SteamMatchmaking.CreateLobby(ELobbyType.k_ELobbyTypePublic, num));
        this.ALLClear = false;
        this.sc.errorMessage = "request sent waiting...";
        this.sc.errorMessageTimer = 700;
      }
      else
      {
        this.sc.errorMessage = "request failed";
        this.sc.errorMessageTimer = 150;
      }
    }

    public void leaveLobby()
    {
      if (!SteamAPI.IsSteamRunning())
        return;
      for (int index = 0; index < this.joinedLobby.Count; ++index)
        SteamMatchmaking.LeaveLobby(this.joinedLobby[index]);
      this.joinedLobby.Clear();
    }

    public void uncreateLobby()
    {
      if (!SteamAPI.IsSteamRunning())
        return;
      for (int index = 0; index < this.createdLobby.Count; ++index)
        SteamMatchmaking.LeaveLobby(this.createdLobby[index]);
      this.createdLobby.Clear();
    }

    public bool inviteFriend(CSteamID ID)
    {
      if (!SteamAPI.IsSteamRunning())
        return false;
      SteamFriends.ActivateGameOverlayInviteDialog(ID);
      return true;
    }

    public bool inthisLobby(CSteamID lobbyID)
    {
      if (!SteamAPI.IsSteamRunning())
        return false;
      CSteamID steamId = SteamUser.GetSteamID();
      for (int iMember = 0; iMember < SteamMatchmaking.GetNumLobbyMembers(lobbyID); ++iMember)
      {
        if (SteamMatchmaking.GetLobbyMemberByIndex(lobbyID, iMember) == steamId)
          return true;
      }
      return false;
    }

    public void grabDayCharState(CSteamID lobbyid)
    {
      this.lobbyChar = "";
      this.lobbyDay = "null";
      this.lobbyState = "";
      this.lobbyVersion = "";
      this.lobbyVersion4 = "";
      this.lobbyVersion6 = "";
      this.lobbyPassword = "";
      if (!SteamAPI.IsSteamRunning())
        return;
      this.lobbyDay = SteamMatchmaking.GetLobbyData(lobbyid, "day");
      this.lobbyChar = SteamMatchmaking.GetLobbyData(lobbyid, "char");
      this.lobbyState = SteamMatchmaking.GetLobbyData(lobbyid, "state");
      this.lobbyVersion = SteamMatchmaking.GetLobbyData(lobbyid, "version");
      this.lobbyPassword = SteamMatchmaking.GetLobbyData(lobbyid, "password");
      if (!(this.lobbyDay == ""))
        return;
      this.lobbyDay = "null";
    }

    public void closeSession(CSteamID id)
    {
      if (!SteamAPI.IsSteamRunning())
        return;
      SteamNetworking.CloseP2PSessionWithUser(id);
    }

    public class dummyOwner : IComparable<Lobby.dummyOwner>
    {
      public CSteamID id;
      public string name = "empty-slot";
      public Color mycolor = Color.White;

      public dummyOwner(CSteamID id, string name, Color cc)
      {
        this.id = id;
        this.name = name;
        this.mycolor = cc;
      }

      public int CompareTo(Lobby.dummyOwner other)
      {
        return this.id.m_SteamID.CompareTo(other.id.m_SteamID);
      }
    }

    public class lobbyowner
    {
      public CSteamID id;
      public string name = "empty-slot";
      public string state = "null";
    }
  }
}
