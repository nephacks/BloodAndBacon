using System;

#nullable disable
namespace Blood
{
  internal class setCamera : MenuScreen
  {
    private MenuEntry radiusEntry;
    private MenuEntry orbitEntry;
    private MenuEntry altitudeEntry;
    private MenuEntry lensEntry;
    private int myindex;

    public setCamera(int indexer)
      : base("SetCamera")
    {
      this.myindex = indexer;
      this.radiusEntry = new MenuEntry(string.Empty);
      this.orbitEntry = new MenuEntry(string.Empty);
      this.altitudeEntry = new MenuEntry(string.Empty);
      this.lensEntry = new MenuEntry(string.Empty);
      this.SetMenuEntryText(indexer);
      this.radiusEntry.Selected += new EventHandler<PlayerIndexEventArgs>(this.setRadius);
      this.orbitEntry.Selected += new EventHandler<PlayerIndexEventArgs>(this.setOrbit);
      this.altitudeEntry.Selected += new EventHandler<PlayerIndexEventArgs>(this.setAlititude);
      this.lensEntry.Selected += new EventHandler<PlayerIndexEventArgs>(this.setLens);
      this.MenuEntries.Add(this.radiusEntry);
      this.MenuEntries.Add(this.orbitEntry);
      this.MenuEntries.Add(this.altitudeEntry);
      this.MenuEntries.Add(this.lensEntry);
    }

    private void SetMenuEntryText(int indexer)
    {
      this.radiusEntry.Text = "Distance";
      this.orbitEntry.Text = "Orbiting";
      this.altitudeEntry.Text = "Altitude";
      this.lensEntry.Text = "Lensing";
      this.radiusEntry.Type = 1;
      this.orbitEntry.Type = 1;
      this.altitudeEntry.Type = 1;
      this.lensEntry.Type = 1;
      this.radiusEntry.Lists = new string[5]
      {
        "Inside",
        "Near",
        "Medium",
        "Far",
        "Eagle"
      };
      this.orbitEntry.Lists = new string[2]
      {
        "Free",
        "Follow"
      };
      this.altitudeEntry.Lists = new string[2]
      {
        "Locked",
        "Manual"
      };
      this.lensEntry.Lists = new string[2]
      {
        "Static",
        "Dynamic"
      };
      this.radiusEntry.Myindex = indexer;
      this.orbitEntry.Myindex = indexer;
      this.altitudeEntry.Myindex = indexer;
      this.lensEntry.Myindex = indexer;
    }

    private void setRadius(object sender, PlayerIndexEventArgs e)
    {
      float[] numArray = new float[5]
      {
        50f,
        250f,
        600f,
        1200f,
        1600f
      };
      this.ScreenManager.allcamsradius[this.radiusEntry.Myindex] = (int) this.radiusEntry.Amount;
      this.ScreenManager.roverdist[this.myindex - 1] = numArray[this.radiusEntry.Myindex];
    }

    private void setOrbit(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.allcamsorbit[this.orbitEntry.Myindex] = (int) this.orbitEntry.Amount;
      this.ScreenManager.allcamsorbit[1] = (int) this.orbitEntry.Amount;
      this.ScreenManager.allcamsorbit[2] = (int) this.orbitEntry.Amount;
      this.ScreenManager.allcamsorbit[3] = (int) this.orbitEntry.Amount;
      this.ScreenManager.roverrotlock = (int) this.orbitEntry.Amount;
    }

    private void setAlititude(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.allcamsaltitude[this.altitudeEntry.Myindex] = (int) this.altitudeEntry.Amount;
      this.ScreenManager.allcamsaltitude[1] = (int) this.altitudeEntry.Amount;
      this.ScreenManager.allcamsaltitude[2] = (int) this.altitudeEntry.Amount;
      this.ScreenManager.allcamsaltitude[3] = (int) this.altitudeEntry.Amount;
      this.ScreenManager.roverhitelock = 1 - (int) this.altitudeEntry.Amount;
    }

    private void setLens(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.allcamslens[this.lensEntry.Myindex] = (int) this.lensEntry.Amount;
    }
  }
}
