using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

#pragma warning disable CS0169
#nullable disable
namespace Blood
{
  public class Workshop
  {
    public bool testmode;
    private bool excellent;
    public List<Rectangle> entryBox = new List<Rectangle>();
    public List<Workshop.diaryEntry> entry = new List<Workshop.diaryEntry>();
    public int entryIndex;
    public bool showPublishbox;
    public bool populateNow;
    public ERemoteStoragePublishedFileVisibility seeFriends = ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityFriendsOnly;
    public ERemoteStoragePublishedFileVisibility seePublic;
    public ERemoteStoragePublishedFileVisibility seePrivate = ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityPrivate;
    public ERemoteStoragePublishedFileVisibility formVisibility;
    public ERemoteStoragePublishedFileVisibility formVisibilityPrivate = ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityPrivate;
    public ERemoteStoragePublishedFileVisibility formPublic;
    public string changenotes = "The Farmer Says Hello";
    public string formTitle = "my title";
    public string formDescr = "my crosshair";
    public string formMark = "MOD";
    public string formTAG = "Crosshair";
    public string[] availableTAGS = new string[9]
    {
      "Crosshair",
      "Testing",
      "Funny",
      "Fullscreen",
      "Night",
      "Daytime",
      "Boss",
      "Small",
      "Random"
    };
    public AppId_t myappID = new AppId_t(434570U);
    private PublishedFileId_t[] published;
    public uint totalSubscriptions;
    public string status = "";
    public string workstatus = "";
    public SteamAPICall_t Handle;
    public UGCUpdateHandle_t updateHandle;
    public PublishedFileId_t publishedfiledid;
    public string publishedfileFolder = "";
    public int downloadComplete = 4;
    public int myTimer = 240;
    public SteamAPICall_t smallhandle;
    public bool weSubscribed;
    public int fileSize = 250;
    private ScreenManager sc;
    public bool textureBusy;
    public int subIndex;
    public List<Texture2D> crosshairS = new List<Texture2D>();
    public CallResult<CreateItemResult_t> createItem;
    public CallResult<UGCUpdateHandle_t> updateItem;
    public CallResult<SubmitItemUpdateResult_t> submitItem;
    public CallResult<UGCQueryHandle_t> getItem;
    private GraphicsDeviceManager gr;

    public Workshop(ScreenManager screenmanager) => this.sc = screenmanager;

    public void forceDownloadFileId()
    {
      this.weSubscribed = false;
      string str = "\\diary";
      if (this.testmode)
        str = "\\diarytest";
      this.entry = new List<Workshop.diaryEntry>();
      this.entry.Clear();
      this.entryBox.Clear();
      this.publishedfiledid = new PublishedFileId_t();
      if (!SteamAPI.IsSteamRunning() || this.published == null)
        return;
      for (int index = 0; index < this.published.Length; ++index)
      {
        try
        {
          string pchFolder;
          if (SteamUGC.GetItemInstallInfo(this.published[index], out ulong _, out pchFolder, 512U, out uint _))
          {
            this.publishedfileFolder = "";
            if (File.Exists(pchFolder + str))
            {
              this.fileSize = (int) new FileInfo(pchFolder + str).Length;
              this.weSubscribed = true;
              this.publishedfileFolder = pchFolder;
              this.publishedfiledid = this.published[index];
              SteamUGC.SubscribeItem(this.publishedfiledid);
              SteamUGC.DownloadItem(this.publishedfiledid, true);
              this.downloadComplete = 4;
              this.myTimer = 240;
            }
          }
        }
        catch
        {
        }
      }
    }

    public bool populateDiary()
    {
      if (this.downloadComplete <= 0 || !(this.publishedfileFolder != ""))
        return false;
      ulong punBytesDownloaded = 0;
      ulong punBytesTotal = 5;
      SteamUGC.GetItemDownloadInfo(this.publishedfiledid, out punBytesDownloaded, out punBytesTotal);
      if ((long) punBytesTotal != (long) punBytesDownloaded || punBytesTotal != 0UL)
        return false;
      this.downloadComplete = 0;
      this.entry.Clear();
      this.entryBox.Clear();
      int num1 = 0;
      int num2 = 0;
      string[] directories = Directory.GetDirectories(this.publishedfileFolder);
      for (int index = directories.Length - 1; index >= 0; --index)
      {
        this.sc.tick.Play(0.5f, -0.2f, 1f);
        if (File.Exists(directories[index].ToString() + "\\report.wav"))
        {
          if (File.Exists(directories[index].ToString() + "\\report.txt"))
          {
            try
            {
              Workshop.diaryEntry diaryEntry = new Workshop.diaryEntry();
              diaryEntry.path = directories[index];
              diaryEntry.dates = new DirectoryInfo(directories[index]).Name;
              diaryEntry.motion = new List<float>();
              diaryEntry.media = new List<Texture2D>();
              diaryEntry.soundhit = new List<SoundEffect>();
              diaryEntry.voice = this.sc.tick;
              this.entry.Add(diaryEntry);
              Rectangle rectangle = new Rectangle(630, 230, 120, 30);
              if (diaryEntry.dates.Split('.')[2] == "21")
              {
                rectangle = num1 != 0 ? new Rectangle(660, 290 + (num1 - 1) % 20 * 30, 100, 15) : new Rectangle(635, 232, 120, 30);
                ++num1;
              }
              else
              {
                ++num2;
                rectangle = new Rectangle(790, 290 + (num2 - 1) % 20 * 30, 100, 15);
              }
              this.entryBox.Add(rectangle);
            }
            catch
            {
            }
          }
        }
      }
      return true;
    }

    public bool populateDiaryContents(int myIndex)
    {
      bool flag = false;
      if (this.publishedfileFolder != "")
      {
        string[] directories = Directory.GetDirectories(this.publishedfileFolder);
        for (int index1 = 0; index1 < directories.Length; ++index1)
        {
          if (new DirectoryInfo(directories[index1]).Name == this.entry[myIndex].dates)
          {
            try
            {
              using (FileStream fileStream = new FileStream(directories[index1] + "\\report.wav", FileMode.Open))
                this.entry[myIndex].voice = SoundEffect.FromStream((Stream) fileStream);
              CultureInfo invariantCulture = CultureInfo.InvariantCulture;
              StreamReader streamReader = new StreamReader(directories[index1] + "\\report.txt");
              this.entry[myIndex].motion.Clear();
              while (!streamReader.EndOfStream)
              {
                float num = (float) Convert.ToDecimal(streamReader.ReadLine(), (IFormatProvider) invariantCulture);
                this.entry[myIndex].motion.Add(num);
              }
              streamReader.Close();
              streamReader.Dispose();
              this.entry[myIndex].soundhit.Clear();
              this.entry[myIndex].media.Clear();
              for (int index2 = 0; index2 < 10; ++index2)
              {
                if (File.Exists(directories[index1] + "\\" + (object) index2 + "ss.wav"))
                {
                  using (FileStream fileStream = new FileStream(directories[index1] + "\\" + (object) index2 + "ss.wav", FileMode.Open))
                    this.entry[myIndex].soundhit.Add(SoundEffect.FromStream((Stream) fileStream));
                }
                if (File.Exists(directories[index1] + "\\" + (object) index2 + "mm.png"))
                {
                  using (FileStream fileStream = new FileStream(directories[index1] + "\\" + (object) index2 + "mm.png", FileMode.Open))
                    this.entry[myIndex].media.Add(Texture2D.FromStream(this.sc.GraphicsDevice, (Stream) fileStream));
                }
                if (File.Exists(directories[index1] + "\\" + (object) index2 + "mm.jpg"))
                {
                  using (FileStream fileStream = new FileStream(directories[index1] + "\\" + (object) index2 + "mm.jpg", FileMode.Open))
                    this.entry[myIndex].media.Add(Texture2D.FromStream(this.sc.GraphicsDevice, (Stream) fileStream));
                }
              }
              flag = true;
              break;
            }
            catch
            {
              flag = false;
              break;
            }
          }
        }
      }
      return flag;
    }

    public void createUpdateItemX()
    {
      string path = "fileid";
      if (this.testmode)
        path = "fileTestid";
      if (!SteamAPI.IsSteamRunning())
        return;
      if (File.Exists(path))
      {
        using (BinaryReader binaryReader = new BinaryReader((Stream) File.Open(path, FileMode.Open)))
        {
          this.publishedfiledid = new PublishedFileId_t(binaryReader.ReadUInt64());
          binaryReader.Close();
        }
        this.startUpdatingNewItemX();
      }
      else
        this.sc.abort.Play(this.sc.ev, 1f, 0.0f);
    }

    public void startUpdatingNewItemX()
    {
      if (!SteamAPI.IsSteamRunning())
        return;
      if (!this.testmode)
      {
        this.updateHandle = SteamUGC.StartItemUpdate(this.myappID, this.publishedfiledid);
        SteamUGC.SetItemTitle(this.updateHandle, "DearDiary");
        SteamUGC.SetItemDescription(this.updateHandle, "Weekly Readings From The Farmer");
        SteamUGC.SetItemUpdateLanguage(this.updateHandle, "en");
        SteamUGC.SetItemMetadata(this.updateHandle, "New Update Panel Notes");
        SteamUGC.SetItemTags(this.updateHandle, (IList<string>) new string[1]
        {
          "Farmer Diary"
        });
        SteamUGC.SetItemVisibility(this.updateHandle, this.formPublic);
        string str1 = "UploadData2";
        if (Directory.Exists(str1))
          str1 = Path.GetFullPath(str1);
        SteamUGC.SetItemContent(this.updateHandle, str1);
        string str2 = "image3.jpg";
        if (File.Exists(str2))
          str2 = Path.GetFullPath(str2);
        SteamUGC.SetItemPreview(this.updateHandle, str2);
        this.submitCreatedItemX();
      }
      else
      {
        this.updateHandle = SteamUGC.StartItemUpdate(this.myappID, this.publishedfiledid);
        SteamUGC.SetItemTitle(this.updateHandle, "DearDiaryTest");
        SteamUGC.SetItemDescription(this.updateHandle, "TESTING TESTING");
        SteamUGC.SetItemUpdateLanguage(this.updateHandle, "en");
        SteamUGC.SetItemMetadata(this.updateHandle, "New Test");
        SteamUGC.SetItemTags(this.updateHandle, (IList<string>) new string[1]
        {
          "Farmer Test Diary"
        });
        SteamUGC.SetItemVisibility(this.updateHandle, this.formVisibilityPrivate);
        string str3 = "UploadDataTest";
        if (Directory.Exists(str3))
          str3 = Path.GetFullPath(str3);
        SteamUGC.SetItemContent(this.updateHandle, str3);
        string str4 = "imageTest.jpg";
        if (File.Exists(str4))
          str4 = Path.GetFullPath(str4);
        SteamUGC.SetItemPreview(this.updateHandle, str4);
        this.submitCreatedItemX();
      }
    }

    public void submitCreatedItemX()
    {
      if (!SteamAPI.IsSteamRunning())
        return;
      string changenotes = this.changenotes;
      this.submitItem = CallResult<SubmitItemUpdateResult_t>.Create(new CallResult<SubmitItemUpdateResult_t>.APIDispatchDelegate(this.onSubmitResultX));
      this.Handle = SteamUGC.SubmitItemUpdate(this.updateHandle, changenotes);
      this.submitItem.Set(this.Handle);
    }

    private void onSubmitResultX(SubmitItemUpdateResult_t pCallback, bool fails)
    {
      if (!SteamAPI.IsSteamRunning())
        return;
      if (pCallback.m_eResult == EResult.k_EResultOK)
        this.sc.achievepop.Play(this.sc.ev, -1f, 0.0f);
      else
        this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
    }

    public void createNewItem()
    {
      if (!SteamAPI.IsSteamRunning())
        return;
      this.createItem = CallResult<CreateItemResult_t>.Create(new CallResult<CreateItemResult_t>.APIDispatchDelegate(this.onCreatedResult));
      this.createItem.Set(SteamUGC.CreateItem(this.myappID, EWorkshopFileType.k_EWorkshopFileTypeFirst));
      this.status = "WORK";
      this.workstatus = "UPLOAD";
    }

    private void onCreatedResult(CreateItemResult_t pCallback, bool fails)
    {
      if (!SteamAPI.IsSteamRunning())
        return;
      if (pCallback.m_eResult == EResult.k_EResultOK)
      {
        this.publishedfiledid = pCallback.m_nPublishedFileId;
        this.startUpdatingNewItem();
      }
      else
      {
        this.sc.AddScreen((GameScreen) new MessageBoxScreen2("On Create Attempt \n" + pCallback.m_eResult.ToString() + "\n", 16), new PlayerIndex?());
        this.status = "FAIL";
      }
    }

    public void startUpdatingNewItem()
    {
      if (!SteamAPI.IsSteamRunning())
        return;
      this.updateHandle = SteamUGC.StartItemUpdate(this.myappID, this.publishedfiledid);
      this.excellent = false;
      if (this.formTitle != "my title" && this.formDescr != "my crosshair")
      {
        this.excellent = true;
        SteamUGC.SetItemTitle(this.updateHandle, this.formTitle);
        SteamUGC.SetItemDescription(this.updateHandle, this.formDescr);
        SteamUGC.SetItemUpdateLanguage(this.updateHandle, "en");
        SteamUGC.SetItemMetadata(this.updateHandle, "No New Notes");
        SteamUGC.SetItemTags(this.updateHandle, (IList<string>) new string[1]
        {
          this.formTAG
        });
        SteamUGC.SetItemVisibility(this.updateHandle, this.formVisibility);
      }
      else
      {
        SteamUGC.SetItemTitle(this.updateHandle, "incompatible");
        SteamUGC.SetItemDescription(this.updateHandle, "item marked as null");
        SteamUGC.SetItemUpdateLanguage(this.updateHandle, "en");
        SteamUGC.SetItemMetadata(this.updateHandle, "warning");
        SteamUGC.SetItemTags(this.updateHandle, (IList<string>) new string[1]
        {
          "Broken"
        });
        SteamUGC.SetItemVisibility(this.updateHandle, this.formVisibilityPrivate);
      }
      string str1 = "UploadData";
      if (Directory.Exists(str1))
      {
        this.sc.harp2.Play(this.sc.ev, 1f, 0.0f);
        str1 = Path.GetFullPath(str1);
      }
      SteamUGC.SetItemContent(this.updateHandle, str1);
      string str2 = "image.jpg";
      if (File.Exists(str2))
      {
        this.sc.harp2.Play(0.5f, -0.5f, 0.0f);
        str2 = Path.GetFullPath(str2);
      }
      if (this.excellent)
        SteamUGC.SetItemPreview(this.updateHandle, str2);
      this.submitCreatedItem();
    }

    public void submitCreatedItem()
    {
      if (!SteamAPI.IsSteamRunning())
        return;
      string pchChangeNote = "No Change notes today.";
      if (!this.excellent)
        pchChangeNote = "warning: item incompatible";
      this.submitItem = CallResult<SubmitItemUpdateResult_t>.Create(new CallResult<SubmitItemUpdateResult_t>.APIDispatchDelegate(this.onSubmitResult));
      this.Handle = SteamUGC.SubmitItemUpdate(this.updateHandle, pchChangeNote);
      this.submitItem.Set(this.Handle);
    }

    private void onSubmitResult(SubmitItemUpdateResult_t pCallback, bool fails)
    {
      if (!SteamAPI.IsSteamRunning())
        return;
      if (pCallback.m_eResult == EResult.k_EResultOK)
      {
        this.status = "DONE";
        this.workstatus = "";
        this.sc.achievepop.Play(this.sc.ev, 0.0f, 0.0f);
      }
      else
      {
        this.status = "FAIL";
        this.workstatus = "";
        this.sc.AddScreen((GameScreen) new MessageBoxScreen2("Submission Failure \n" + pCallback.m_eResult.ToString() + "\n", 16), new PlayerIndex?());
      }
    }

    public void getSubscribedItems()
    {
      this.textureBusy = true;
      this.totalSubscriptions = 0U;
      if (SteamAPI.IsSteamRunning())
      {
        try
        {
          this.totalSubscriptions = SteamUGC.GetNumSubscribedItems();
          if (this.totalSubscriptions > 0U)
          {
           this.published = new PublishedFileId_t[(int)this.totalSubscriptions];
           int subscribedItems = (int) SteamUGC.GetSubscribedItems(this.published, this.totalSubscriptions);
          }
        }
        catch
        {
        }
      }
      this.textureBusy = false;
    }

    public void getSubbedTextures()
    {
      this.textureBusy = true;
      if (SteamAPI.IsSteamRunning())
      {
        this.crosshairS.Clear();
        this.subIndex = 0;
        if (this.published != null)
        {
          for (int index = 0; index < this.published.Length; ++index)
          {
            try
            {
              string pchFolder;
              if (SteamUGC.GetItemInstallInfo(this.published[index], out ulong _, out pchFolder, 512U, out uint _))
              {
                string str = "dummyB.png";
                if (File.Exists(pchFolder + "\\" + str))
                {
                  try
                  {
                    using (FileStream fileStream = new FileStream(pchFolder + "\\" + str, FileMode.Open))
                      this.crosshairS.Add(Texture2D.FromStream(this.sc.GraphicsDevice, (Stream) fileStream));
                  }
                  catch
                  {
                  }
                }
              }
            }
            catch
            {
            }
          }
        }
      }
      this.textureBusy = false;
    }

    public void openWEB(string mypage)
    {
      if (!SteamAPI.IsSteamRunning())
        return;
      try
      {
        SteamFriends.ActivateGameOverlayToWebPage(mypage);
      }
      catch
      {
      }
    }

    public class diaryEntry
    {
      public string path;
      public string dates;
      public SoundEffect voice;
      public List<float> motion;
      public List<Texture2D> media;
      public List<SoundEffect> soundhit;
    }
  }
}
