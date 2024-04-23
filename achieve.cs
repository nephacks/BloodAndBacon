// Decompiled with JetBrains decompiler
// Type: Blood.achieve
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Steamworks;

#nullable disable
namespace Blood
{
  public class achieve
  {
    public bool allcomplete;
    private SteamLeaderboard_t m_SteamLeaderboard;
    public CallResult<LeaderboardFindResult_t> LeaderboardFindResult;
    private SteamLeaderboard_t m_SteamLeaderboard2;
    public CallResult<LeaderboardFindResult_t> LeaderboardFindResult2;
    private SteamLeaderboard_t m_SteamLeaderboard3;
    public CallResult<LeaderboardFindResult_t> LeaderboardFindResult3;
    private SteamLeaderboard_t m_SteamLeaderboard4;
    public CallResult<LeaderboardFindResult_t> LeaderboardFindResult4;
    private int myframe;
    private ScreenManager sc;
    public achieve.ach kaboom;
    public achieve.ach whileyourdown;
    public achieve.ach youmurderer;
    public achieve.ach hulk;
    public achieve.ach skidmarked;
    public achieve.ach knockout;
    public achieve.ach bitethehand;
    public achieve.ach gasguzzler;
    public achieve.ach ambidextrous;
    public achieve.ach needygreedy;
    public achieve.ach royaltykiller;
    public achieve.ach pyromaniac;
    public achieve.ach fryertuck;
    public achieve.ach chunkkicker;
    public achieve.ach acidwashed;
    public achieve.ach credits;
    public achieve.ach graphics;
    public achieve.ach blindedbythelight;
    public achieve.ach thelongestyard;
    public achieve.ach youarethechampion;
    public achieve.ach aptpupil;
    public achieve.ach milehighclub;
    public achieve.ach frankenstein;
    public achieve.ach bounce;
    public achieve.ach swallow;
    public achieve.ach coward;
    public achieve.ach ridethewave;
    public achieve.ach offkey;
    public achieve.ach birds;
    public achieve.ach hardened;
    public achieve.ach death;
    public achieve.ach madhatter;
    public achieve.ach drwho;
    public achieve.ach hindenburg;
    public achieve.ach redsun;
    public achieve.ach unfriended;
    public achieve.ach walkinghere;
    public achieve.ach spacedeath;
    public achieve.ach spaceevent;
    public achieve.ach heirlooms;
    public achieve.ach mrgreen;
    public achieve.ach freefall;
    private int pigskilled;
    private int mostpigsgrinded;
    private int milksdrank;
    private int mostko;

    public achieve(ScreenManager sm)
    {
      if (SteamAPI.IsSteamRunning())
      {
        this.LeaderboardFindResult = CallResult<LeaderboardFindResult_t>.Create(new CallResult<LeaderboardFindResult_t>.APIDispatchDelegate(this.OnLeaderboardFindResult));
        this.LeaderboardFindResult.Set(SteamUserStats.FindLeaderboard(nameof (pigskilled)));
        this.LeaderboardFindResult2 = CallResult<LeaderboardFindResult_t>.Create(new CallResult<LeaderboardFindResult_t>.APIDispatchDelegate(this.OnLeaderboardFindResult2));
        this.LeaderboardFindResult2.Set(SteamUserStats.FindLeaderboard(nameof (mostpigsgrinded)));
        this.LeaderboardFindResult3 = CallResult<LeaderboardFindResult_t>.Create(new CallResult<LeaderboardFindResult_t>.APIDispatchDelegate(this.OnLeaderboardFindResult3));
        this.LeaderboardFindResult3.Set(SteamUserStats.FindLeaderboard(nameof (milksdrank)));
        this.LeaderboardFindResult4 = CallResult<LeaderboardFindResult_t>.Create(new CallResult<LeaderboardFindResult_t>.APIDispatchDelegate(this.OnLeaderboardFindResult4));
        this.LeaderboardFindResult4.Set(SteamUserStats.FindLeaderboard(nameof (mostko)));
      }
      this.getStat("stat_pigskilled", ref this.pigskilled);
      this.getStat("stat_mostpigsgrinded", ref this.mostpigsgrinded);
      this.getStat("stat_milksdrank", ref this.milksdrank);
      this.getStat("stat_mostko", ref this.mostko);
      this.sc = sm;
      this.init();
    }

    public void init()
    {
      this.kaboom = new achieve.ach();
      this.initAchievement(this.kaboom, "kaboom", true, 10);
      this.whileyourdown = new achieve.ach();
      this.initAchievement(this.whileyourdown, "whileyourdown", true, 10);
      this.youmurderer = new achieve.ach();
      this.initAchievement(this.youmurderer, "youmurderer", true, 100);
      this.hulk = new achieve.ach();
      this.initAchievement(this.hulk, "hulk", true, 5);
      this.skidmarked = new achieve.ach();
      this.initAchievement(this.skidmarked, "skidmarked", false, 0);
      this.knockout = new achieve.ach();
      this.initAchievement(this.knockout, "knockout", true, 10);
      this.bitethehand = new achieve.ach();
      this.initAchievement(this.bitethehand, "bitethehand", true, 10);
      this.gasguzzler = new achieve.ach();
      this.initAchievement(this.gasguzzler, "gasguzzler", false, 0);
      this.ambidextrous = new achieve.ach();
      this.initAchievement(this.ambidextrous, "ambidextrous", false, 0);
      this.needygreedy = new achieve.ach();
      this.initAchievement(this.needygreedy, "needygreedy", false, 0);
      this.royaltykiller = new achieve.ach();
      this.initAchievement(this.royaltykiller, "royaltykiller", false, 0);
      this.pyromaniac = new achieve.ach();
      this.initAchievement(this.pyromaniac, "pyromaniac", false, 0);
      this.fryertuck = new achieve.ach();
      this.initAchievement(this.fryertuck, "fryertuck", true, 10);
      this.chunkkicker = new achieve.ach();
      this.initAchievement(this.chunkkicker, "chunkkicker", true, 50);
      this.acidwashed = new achieve.ach();
      this.initAchievement(this.acidwashed, "acidwashed", false, 0);
      this.credits = new achieve.ach();
      this.initAchievement(this.credits, "credits", false, 0);
      this.graphics = new achieve.ach();
      this.initAchievement(this.graphics, "graphics", false, 0);
      this.blindedbythelight = new achieve.ach();
      this.initAchievement(this.blindedbythelight, "blindedbythelight", false, 0);
      this.thelongestyard = new achieve.ach();
      this.initAchievement(this.thelongestyard, "thelongestyard", false, 0);
      this.youarethechampion = new achieve.ach();
      this.initAchievement(this.youarethechampion, "youarethechampion", false, 0);
      this.aptpupil = new achieve.ach();
      this.initAchievement(this.aptpupil, "aptpupil", false, 0);
      this.milehighclub = new achieve.ach();
      this.initAchievement(this.milehighclub, "milehighclub", false, 0);
      this.frankenstein = new achieve.ach();
      this.initAchievement(this.frankenstein, "frankenstein", true, 10);
      this.bounce = new achieve.ach();
      this.initAchievement(this.bounce, "bounce", true, 20);
      this.swallow = new achieve.ach();
      this.initAchievement(this.swallow, "swallow", true, 20);
      this.coward = new achieve.ach();
      this.initAchievement(this.coward, "coward", false, 0);
      this.ridethewave = new achieve.ach();
      this.initAchievement(this.ridethewave, "ridethewave", false, 0);
      this.offkey = new achieve.ach();
      this.initAchievement(this.offkey, "offkey", false, 0);
      this.birds = new achieve.ach();
      this.initAchievement(this.birds, "birds", false, 0);
      this.hardened = new achieve.ach();
      this.initAchievement(this.hardened, "hardened", false, 0);
      this.death = new achieve.ach();
      this.initAchievement(this.death, "death", false, 0);
      this.madhatter = new achieve.ach();
      this.initAchievement(this.madhatter, "madhatter", false, 0);
      this.drwho = new achieve.ach();
      this.initAchievement(this.drwho, "drwho", true, 10);
      this.hindenburg = new achieve.ach();
      this.initAchievement(this.hindenburg, "hindenburg", false, 0);
      this.redsun = new achieve.ach();
      this.initAchievement(this.redsun, "redsun", false, 0);
      this.unfriended = new achieve.ach();
      this.initAchievement(this.unfriended, "unfriended", true, 10);
      this.walkinghere = new achieve.ach();
      this.initAchievement(this.walkinghere, "walkinghere", false, 0);
      this.spacedeath = new achieve.ach();
      this.initAchievement(this.spacedeath, "spacedeath", false, 0);
      this.spaceevent = new achieve.ach();
      this.initAchievement(this.spaceevent, "spaceevent", false, 0);
      this.heirlooms = new achieve.ach();
      this.initAchievement(this.heirlooms, "heirlooms", false, 0);
      this.mrgreen = new achieve.ach();
      this.initAchievement(this.mrgreen, "mrgreen", false, 0);
      this.freefall = new achieve.ach();
      this.initAchievement(this.freefall, "freefall", false, 0);
    }

    private void initAchievement(achieve.ach ach, string name, bool useStat, int val)
    {
      ach.wait = false;
      ach.statreached = val;
      ach.useStat = useStat;
      ach.name = name;
      ach.statname = "stat_" + name;
      if (useStat)
      {
        ach.stat = 0;
        this.getStat(ach.statname, ref ach.stat);
      }
      ach.trophywon = false;
      this.getachStatus(ach.name, ref ach.trophywon);
    }

    public void checkAll()
    {
      this.allcomplete = true;
      this.checkAchievement(this.kaboom, "kaboom", true, 10);
      if (!this.kaboom.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.whileyourdown, "whileyourdown", true, 10);
      if (!this.whileyourdown.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.youmurderer, "youmurderer", true, 100);
      if (!this.youmurderer.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.hulk, "hulk", true, 5);
      if (!this.hulk.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.skidmarked, "skidmarked", false, 0);
      if (!this.skidmarked.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.knockout, "knockout", true, 10);
      if (!this.knockout.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.bitethehand, "bitethehand", true, 10);
      if (!this.bitethehand.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.gasguzzler, "gasguzzler", false, 0);
      if (!this.gasguzzler.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.ambidextrous, "ambidextrous", false, 0);
      if (!this.ambidextrous.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.needygreedy, "needygreedy", false, 0);
      if (!this.needygreedy.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.royaltykiller, "royaltykiller", false, 0);
      if (!this.royaltykiller.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.pyromaniac, "pyromaniac", false, 0);
      if (!this.pyromaniac.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.fryertuck, "fryertuck", true, 10);
      if (!this.fryertuck.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.chunkkicker, "chunkkicker", true, 50);
      if (!this.chunkkicker.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.acidwashed, "acidwashed", false, 0);
      if (!this.acidwashed.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.credits, "credits", false, 0);
      if (!this.credits.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.graphics, "graphics", false, 0);
      if (!this.graphics.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.blindedbythelight, "blindedbythelight", false, 0);
      if (!this.blindedbythelight.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.thelongestyard, "thelongestyard", false, 0);
      if (!this.thelongestyard.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.youarethechampion, "youarethechampion", false, 0);
      if (!this.youarethechampion.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.aptpupil, "aptpupil", false, 0);
      if (!this.aptpupil.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.milehighclub, "milehighclub", false, 0);
      if (!this.milehighclub.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.frankenstein, "frankenstein", true, 10);
      if (!this.frankenstein.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.bounce, "bounce", true, 20);
      if (!this.bounce.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.swallow, "swallow", true, 20);
      if (!this.youmurderer.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.coward, "coward", false, 0);
      if (!this.coward.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.ridethewave, "ridethewave", false, 0);
      if (!this.ridethewave.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.offkey, "offkey", false, 0);
      if (!this.offkey.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.birds, "birds", false, 0);
      if (!this.birds.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.hardened, "hardened", false, 0);
      if (!this.hardened.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.death, "death", false, 0);
      if (!this.death.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.madhatter, "madhatter", false, 0);
      if (!this.madhatter.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.drwho, "drwho", true, 10);
      if (!this.drwho.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.hindenburg, "hindenburg", false, 0);
      if (!this.hindenburg.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.redsun, "redsun", false, 0);
      if (!this.redsun.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.unfriended, "unfriended", true, 10);
      if (!this.unfriended.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.walkinghere, "walkinghere", false, 0);
      if (!this.walkinghere.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.spacedeath, "spacedeath", false, 0);
      if (!this.spacedeath.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.spaceevent, "spaceevent", false, 0);
      if (!this.spaceevent.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.heirlooms, "heirloom", false, 0);
      if (!this.heirlooms.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.mrgreen, "mrgreen", false, 0);
      if (!this.mrgreen.trophywon)
        this.allcomplete = false;
      this.checkAchievement(this.freefall, "freefall", false, 0);
      if (this.freefall.trophywon)
        return;
      this.allcomplete = false;
    }

    private void checkAchievement(achieve.ach ach, string name, bool useStat, int val)
    {
      if (ach.trophywon)
        return;
      this.getachStatus(ach.name, ref ach.trophywon);
    }

    public void leaderPigsKilled()
    {
      if (this.pigskilled == 0)
      {
        this.getStat("stat_pigskilled", ref this.pigskilled);
      }
      else
      {
        ++this.pigskilled;
        this.setStat("stat_pigskilled", this.pigskilled);
      }
    }

    public void leaderPigsGrinded()
    {
      if (this.mostpigsgrinded == 0)
      {
        this.getStat("stat_mostpigsgrinded", ref this.mostpigsgrinded);
      }
      else
      {
        ++this.mostpigsgrinded;
        this.setStat("stat_mostpigsgrinded", this.mostpigsgrinded);
      }
    }

    public void leaderMostKO()
    {
      if (this.mostko == 0)
      {
        this.getStat("stat_mostko", ref this.mostko);
      }
      else
      {
        ++this.mostko;
        this.setStat("stat_mostko", this.mostko);
      }
    }

    public void leaderMostMilkDrank()
    {
      if (this.milksdrank == 0)
      {
        this.getStat("stat_milksdrank", ref this.milksdrank);
      }
      else
      {
        ++this.milksdrank;
        this.setStat("stat_milksdrank", this.milksdrank);
      }
    }

    public void updateLeaderboards()
    {
      if (!SteamAPI.IsSteamRunning())
        return;
      try
      {
        SteamUserStats.UploadLeaderboardScore(this.m_SteamLeaderboard, ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodForceUpdate, this.pigskilled, (int[]) null, 0);
      }
      catch
      {
      }
    }

    public void updateLeaderboards2()
    {
      if (!SteamAPI.IsSteamRunning())
        return;
      try
      {
        SteamUserStats.UploadLeaderboardScore(this.m_SteamLeaderboard2, ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodForceUpdate, this.mostpigsgrinded, (int[]) null, 0);
      }
      catch
      {
      }
    }

    public void updateLeaderboards3()
    {
      if (!SteamAPI.IsSteamRunning())
        return;
      try
      {
        SteamUserStats.UploadLeaderboardScore(this.m_SteamLeaderboard3, ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodForceUpdate, this.milksdrank, (int[]) null, 0);
      }
      catch
      {
      }
    }

    public void updateLeaderboards4()
    {
      if (!SteamAPI.IsSteamRunning())
        return;
      try
      {
        SteamUserStats.UploadLeaderboardScore(this.m_SteamLeaderboard4, ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodForceUpdate, this.mostko, (int[]) null, 0);
      }
      catch
      {
      }
    }

    private void OnLeaderboardFindResult(LeaderboardFindResult_t pCallback, bool bool_0)
    {
      if (pCallback.m_bLeaderboardFound == (byte) 0)
        return;
      this.m_SteamLeaderboard = pCallback.m_hSteamLeaderboard;
    }

    private void OnLeaderboardFindResult2(LeaderboardFindResult_t pCallback, bool bool_0)
    {
      if (pCallback.m_bLeaderboardFound == (byte) 0)
        return;
      this.m_SteamLeaderboard2 = pCallback.m_hSteamLeaderboard;
    }

    private void OnLeaderboardFindResult3(LeaderboardFindResult_t pCallback, bool bool_0)
    {
      if (pCallback.m_bLeaderboardFound == (byte) 0)
        return;
      this.m_SteamLeaderboard3 = pCallback.m_hSteamLeaderboard;
    }

    private void OnLeaderboardFindResult4(LeaderboardFindResult_t pCallback, bool bool_0)
    {
      if (pCallback.m_bLeaderboardFound == (byte) 0)
        return;
      this.m_SteamLeaderboard4 = pCallback.m_hSteamLeaderboard;
    }

    public void UpdateState()
    {
      ++this.myframe;
      if (this.myframe % 180 != 0)
        return;
      this.kaboom.wait = false;
      this.whileyourdown.wait = false;
      this.youmurderer.wait = false;
      this.hulk.wait = false;
      this.skidmarked.wait = false;
      this.knockout.wait = false;
      this.bitethehand.wait = false;
      this.ambidextrous.wait = false;
      this.gasguzzler.wait = false;
      this.needygreedy.wait = false;
      this.royaltykiller.wait = false;
      this.pyromaniac.wait = false;
      this.fryertuck.wait = false;
      this.chunkkicker.wait = false;
      this.acidwashed.wait = false;
      this.credits.wait = false;
      this.graphics.wait = false;
      this.youarethechampion.wait = false;
      this.thelongestyard.wait = false;
      this.blindedbythelight.wait = false;
      this.aptpupil.wait = false;
      this.milehighclub.wait = false;
      this.frankenstein.wait = false;
      this.bounce.wait = false;
      this.swallow.wait = false;
      this.coward.wait = false;
      this.ridethewave.wait = false;
      this.offkey.wait = false;
      this.birds.wait = false;
      this.hardened.wait = false;
      this.death.wait = false;
      this.madhatter.wait = false;
      this.drwho.wait = false;
      this.hindenburg.wait = false;
      this.redsun.wait = false;
      this.unfriended.wait = false;
      this.spacedeath.wait = false;
      this.spaceevent.wait = false;
      this.walkinghere.wait = false;
      this.heirlooms.wait = false;
      this.mrgreen.wait = false;
      this.freefall.wait = false;
    }

    public void win(achieve.ach ach)
    {
      if (!SteamAPI.IsSteamRunning() || ach.wait)
        return;
      ach.wait = true;
      if (ach.useStat)
      {
        this.getStat(ach.statname, ref ach.stat);
        ++ach.stat;
        this.setStat(ach.statname, ach.stat);
        if (ach.stat < ach.statreached)
          return;
        if (!ach.trophywon)
          this.sc.achieve1.Play(this.sc.ev, 0.0f, 0.0f);
        this.setAchievement(ach.name);
        ach.trophywon = true;
      }
      else
      {
        if (!ach.trophywon)
          this.sc.achieve1.Play(this.sc.ev, 0.0f, 0.0f);
        this.setAchievement(ach.name);
        ach.trophywon = true;
      }
    }

    private void getachStatus(string name, ref bool stat)
    {
      if (!SteamAPI.IsSteamRunning())
        return;
      bool pbAchieved = false;
      try
      {
        if (!SteamUserStats.GetAchievement(name, out pbAchieved))
          return;
        stat = pbAchieved;
      }
      catch
      {
      }
    }

    private void getStat(string name, ref int stat)
    {
      if (!SteamAPI.IsSteamRunning())
        return;
      SteamUserStats.GetStat(name, out stat);
    }

    private void setStat(string name, int stat)
    {
      if (!SteamAPI.IsSteamRunning())
        return;
      SteamUserStats.SetStat(name, stat);
      SteamUserStats.StoreStats();
    }

    private void setAchievement(string AchName)
    {
      if (!SteamAPI.IsSteamRunning())
        return;
      SteamUserStats.SetAchievement(AchName);
      SteamUserStats.StoreStats();
    }

    private void requestStats()
    {
      if (!SteamAPI.IsSteamRunning())
        return;
      SteamUserStats.RequestCurrentStats();
    }

    public void resetStats()
    {
      if (!SteamAPI.IsSteamRunning())
        return;
      SteamUserStats.ResetAllStats(true);
    }

    private void setAchievement2(achieve.ach ac, string AchName, bool what, int num)
    {
      if (!SteamAPI.IsSteamRunning())
        return;
      SteamUserStats.SetAchievement(AchName);
      SteamUserStats.StoreStats();
    }

    public void gimme()
    {
      if (!SteamAPI.IsSteamRunning())
        return;
      this.setAchievement2(this.kaboom, "kaboom", true, 10);
      this.setAchievement2(this.whileyourdown, "whileyourdown", true, 10);
      this.setAchievement2(this.youmurderer, "youmurderer", true, 100);
      this.setAchievement2(this.hulk, "hulk", true, 5);
      this.setAchievement2(this.skidmarked, "skidmarked", false, 0);
      this.setAchievement2(this.knockout, "knockout", true, 10);
      this.setAchievement2(this.bitethehand, "bitethehand", true, 10);
      this.setAchievement2(this.gasguzzler, "gasguzzler", false, 0);
      this.setAchievement2(this.ambidextrous, "ambidextrous", false, 0);
      this.setAchievement2(this.needygreedy, "needygreedy", false, 0);
      this.setAchievement2(this.royaltykiller, "royaltykiller", false, 0);
      this.setAchievement2(this.pyromaniac, "pyromaniac", false, 0);
      this.setAchievement2(this.fryertuck, "fryertuck", true, 10);
      this.setAchievement2(this.chunkkicker, "chunkkicker", true, 50);
      this.setAchievement2(this.acidwashed, "acidwashed", false, 0);
      this.setAchievement2(this.credits, "credits", false, 0);
      this.setAchievement2(this.graphics, "graphics", false, 0);
      this.setAchievement2(this.blindedbythelight, "blindedbythelight", false, 0);
      this.setAchievement2(this.thelongestyard, "thelongestyard", false, 0);
      this.setAchievement2(this.youarethechampion, "youarethechampion", false, 0);
      this.setAchievement2(this.aptpupil, "aptpupil", false, 0);
      this.setAchievement2(this.milehighclub, "milehighclub", false, 0);
      this.setAchievement2(this.frankenstein, "frankenstein", true, 10);
      this.setAchievement2(this.bounce, "bounce", true, 20);
      this.setAchievement2(this.swallow, "swallow", true, 20);
      this.setAchievement2(this.coward, "coward", false, 0);
      this.setAchievement2(this.ridethewave, "ridethewave", false, 0);
      this.setAchievement2(this.offkey, "offkey", false, 0);
      this.setAchievement2(this.birds, "birds", false, 0);
      this.setAchievement2(this.hardened, "hardened", false, 0);
      this.setAchievement2(this.death, "death", false, 0);
      this.setAchievement2(this.madhatter, "madhatter", false, 0);
      this.setAchievement2(this.drwho, "drwho", true, 10);
      this.setAchievement2(this.hindenburg, "hindenburg", false, 0);
      this.setAchievement2(this.redsun, "redsun", false, 0);
      this.setAchievement2(this.unfriended, "unfriended", true, 10);
      this.setAchievement2(this.spacedeath, "spacedeath", false, 0);
      this.setAchievement2(this.spaceevent, "spaceevent", false, 0);
      this.setAchievement2(this.walkinghere, "walkinghere", false, 0);
      this.setAchievement2(this.heirlooms, "heirlooms", false, 0);
      this.setAchievement2(this.mrgreen, "mrgreen", false, 0);
      this.setAchievement2(this.freefall, "freefall", false, 0);
    }

    public void gimmeSpace()
    {
      if (!SteamAPI.IsSteamRunning())
        return;
      this.setAchievement2(this.spacedeath, "spacedeath", false, 0);
      this.setAchievement2(this.spaceevent, "spaceevent", false, 0);
      this.setAchievement2(this.walkinghere, "walkinghere", false, 0);
    }

    public class ach
    {
      public bool wait;
      public bool useStat;
      public int statreached;
      public string name = "null";
      public bool trophywon;
      public string statname = "null";
      public int stat;
    }
  }
}
