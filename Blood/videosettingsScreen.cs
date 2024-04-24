using System;

#nullable disable
namespace Blood
{
  internal class videosettingsScreen : MenuScreen
  {
    private MenuEntry brightness;
    private MenuEntry contrast;

    public videosettingsScreen()
      : base("Video Settings")
    {
      this.brightness = new MenuEntry(string.Empty);
      this.contrast = new MenuEntry(string.Empty);
      this.SetMenuEntryText();
      this.brightness.Selected += new EventHandler<PlayerIndexEventArgs>(this.setBrite);
      this.contrast.Selected += new EventHandler<PlayerIndexEventArgs>(this.setCon);
      this.MenuEntries.Add(this.brightness);
      this.MenuEntries.Add(this.contrast);
    }

    private void SetMenuEntryText()
    {
      this.brightness.Text = "BRIGHTEN";
      this.contrast.Text = "CONTRAST";
      this.brightness.Type = 1;
      this.contrast.Type = 1;
      this.brightness.Lists = new string[21]
      {
        "00",
        "01",
        "02",
        "03",
        "04",
        "05",
        "06",
        "07",
        "08",
        "09",
        "10",
        "11",
        "12",
        "13",
        "14",
        "15",
        "16",
        "17",
        "18",
        "19",
        "20"
      };
      this.contrast.Lists = new string[21]
      {
        "00",
        "01",
        "02",
        "03",
        "04",
        "05",
        "06",
        "07",
        "08",
        "09",
        "10",
        "11",
        "12",
        "13",
        "14",
        "15",
        "16",
        "17",
        "18",
        "19",
        "20"
      };
    }

    private void setBrite(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.brightness = (int) (28.0 + (double) this.brightness.Amount * 10.0);
    }

    private void setCon(object sender, PlayerIndexEventArgs e)
    {
      this.ScreenManager.contrast = (int) (28.0 + (double) this.contrast.Amount * 10.0);
    }

    private void setBorder(object sender, PlayerIndexEventArgs e)
    {
    }

    private void intensitySelected(object sender, PlayerIndexEventArgs e)
    {
    }

    private void filterSelected(object sender, PlayerIndexEventArgs e)
    {
    }

    private void bgfadeSelected(object sender, PlayerIndexEventArgs e)
    {
    }

    private void planetSelected(object sender, PlayerIndexEventArgs e)
    {
    }
  }
}
