using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Windows.Forms;


#pragma warning disable CS0219
#pragma warning disable CS0414
#pragma warning disable CS0169
#nullable disable
namespace Blood
{
  public class ScreenManager : DrawableGameComponent
  {
    public int tunnelUppy = 10;
    public bool showTunnels;
    public int totalPlayers = 2;
    public List<int> tunnelDay = new List<int>()
    {
      2,
      7,
      12,
      18,
      23
    };
    public List<int> heirlooms = new List<int>()
    {
      0,
      0,
      0,
      0,
      0,
      0,
      0
    };
    public int ammoboxCount;
    public int cogCount;
    public int flashlight1;
    public int flashlight2;
    public int flashlight3;
    public int goggles;
    public int redskull1;
    public int redskull2;
    public int redskull3;
    public int tusk1;
    public int tusk2;
    public int tusk3;
    public int[] map = new int[20];
    public int[] ammobox1 = new int[20];
    public int[] ammobox2 = new int[20];
    public int[] ammobox3 = new int[20];
    public int[] cog1 = new int[20];
    public int[] cog2 = new int[20];
    public int[] cog3 = new int[20];
    public int[] exitkey = new int[20];
    public int[,] code1 = new int[20, 3];
    public int[,] code2 = new int[20, 3];
    public int[,] code3 = new int[20, 3];
    public bool localLoad = true;
    public float litex;
    public float litey;
    public float litez;
    public Color hostblue = new Color(0, 78, (int) byte.MaxValue, (int) byte.MaxValue);
    public float notch;
    public bool formDrawBand;
    public bool formDrawBG;
    public int formBandColorIndex;
    public Color[] formBandColor = new Color[5]
    {
      new Color(225, 178, 30, (int) byte.MaxValue),
      new Color(32, 210, 19, (int) byte.MaxValue),
      new Color(42, 137, 217, (int) byte.MaxValue),
      new Color(166, 86, 178, (int) byte.MaxValue),
      new Color(175, 52, 52, (int) byte.MaxValue)
    };
    public int formBGColorIndex;
    public Color[] color_0 = new Color[5]
    {
      new Color(210, 210, 210, (int) byte.MaxValue),
      new Color(180, 180, 180, (int) byte.MaxValue),
      new Color(110, 110, 110, (int) byte.MaxValue),
      new Color(60, 60, 60, (int) byte.MaxValue),
      new Color(15, 15, 15, (int) byte.MaxValue)
    };
    public Rectangle formBand = new Rectangle(1020, 77, 132, 125);
    public Rectangle formBandL = new Rectangle(0, 0, 132, 125);
    public Rectangle zoomRectangle = new Rectangle(0, 0, 0, 0);
    public Matrix[] wallguns = new Matrix[21];
    public float[] recoilTime = new float[21]
    {
      0.5f,
      0.0f,
      0.5f,
      0.0f,
      0.5f,
      0.0f,
      1.1f,
      0.0f,
      1f,
      0.0f,
      1.2f,
      0.0f,
      1.2f,
      0.0f,
      0.5f,
      0.0f,
      0.5f,
      0.0f,
      1.1f,
      0.0f,
      1.2f
    };
    public int[] recoilA = new int[21]
    {
      45,
      0,
      25,
      0,
      25,
      0,
      35,
      0,
      50,
      0,
      20,
      0,
      38,
      0,
      10,
      0,
      10,
      0,
      20,
      0,
      35
    };
    public int[] recoilB = new int[21]
    {
      110,
      0,
      60,
      0,
      40,
      0,
      54,
      0,
      130,
      0,
      30,
      0,
      60,
      0,
      10,
      0,
      10,
      0,
      50,
      0,
      45
    };
    public float[] gunDam = new float[21]
    {
      2f,
      0.0f,
      1f,
      0.0f,
      1f,
      0.0f,
      1.3f,
      0.0f,
      3f,
      0.0f,
      1.15f,
      0.0f,
      0.9f,
      0.0f,
      1f,
      0.0f,
      0.5f,
      0.0f,
      0.8f,
      0.0f,
      1.4f
    };
    public int[] gunVibro = new int[21]
    {
      18,
      0,
      10,
      0,
      10,
      0,
      12,
      0,
      25,
      0,
      15,
      0,
      11,
      0,
      80,
      0,
      10,
      0,
      10,
      0,
      35
    };
    public float[] gunVibroAmt = new float[21]
    {
      80f,
      0.0f,
      120f,
      0.0f,
      80f,
      0.0f,
      110f,
      0.0f,
      80f,
      0.0f,
      100f,
      0.0f,
      100f,
      0.0f,
      80f,
      0.0f,
      12f,
      0.0f,
      20f,
      0.0f,
      150f
    };
    public float[] gunDelay = new float[21]
    {
      9f,
      0.0f,
      8f,
      0.0f,
      8f,
      0.0f,
      7f,
      0.0f,
      16f,
      0.0f,
      7f,
      0.0f,
      6f,
      0.0f,
      29f,
      0.0f,
      9f,
      0.0f,
      6f,
      0.0f,
      5f
    };
    public float[] gunRadius = new float[21]
    {
      700f,
      0.0f,
      600f,
      0.0f,
      100f,
      0.0f,
      1000f,
      0.0f,
      1500f,
      0.0f,
      1000f,
      0.0f,
      3500f,
      0.0f,
      10f,
      0.0f,
      600f,
      0.0f,
      1100f,
      0.0f,
      1200f
    };
    public Vector2[] sf = new Vector2[24]
    {
      new Vector2(50f, 110f),
      new Vector2(0.0f, 0.0f),
      new Vector2(50f, 110f),
      new Vector2(0.0f, 0.0f),
      new Vector2(10f, 30f),
      new Vector2(0.0f, 0.0f),
      new Vector2(120f, 150f),
      new Vector2(0.0f, 0.0f),
      new Vector2(160f, 200f),
      new Vector2(0.0f, 0.0f),
      new Vector2(130f, 210f),
      new Vector2(0.0f, 0.0f),
      new Vector2(50f, 110f),
      new Vector2(0.0f, 0.0f),
      new Vector2(180f, 230f),
      new Vector2(0.0f, 0.0f),
      new Vector2(50f, 110f),
      new Vector2(0.0f, 0.0f),
      new Vector2(80f, 120f),
      new Vector2(0.0f, 0.0f),
      new Vector2(180f, 190f),
      new Vector2(0.0f, 0.0f),
      new Vector2(0.0f, 0.0f),
      new Vector2(0.0f, 0.0f)
    };
    public Vector2[] ff = new Vector2[24]
    {
      new Vector2(35f, 55f),
      new Vector2(0.0f, 0.0f),
      new Vector2(35f, 55f),
      new Vector2(0.0f, 0.0f),
      new Vector2(10f, 30f),
      new Vector2(0.0f, 0.0f),
      new Vector2(65f, 85f),
      new Vector2(0.0f, 0.0f),
      new Vector2(90f, 100f),
      new Vector2(0.0f, 0.0f),
      new Vector2(60f, 90f),
      new Vector2(0.0f, 0.0f),
      new Vector2(35f, 55f),
      new Vector2(0.0f, 0.0f),
      new Vector2(150f, 195f),
      new Vector2(0.0f, 0.0f),
      new Vector2(35f, 55f),
      new Vector2(0.0f, 0.0f),
      new Vector2(35f, 55f),
      new Vector2(0.0f, 0.0f),
      new Vector2(75f, 85f),
      new Vector2(0.0f, 0.0f),
      new Vector2(0.0f, 0.0f),
      new Vector2(0.0f, 0.0f)
    };
    public Matrix[] flashOffset = new Matrix[22]
    {
      Matrix.CreateTranslation(5.85f, 2.77f, 0.0f) * Matrix.CreateRotationX(MathHelper.ToRadians(-90f)) * Matrix.CreateRotationY(MathHelper.ToRadians(187f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(1f)) * Matrix.CreateTranslation(-24.784f, 42.639f, 2.188f),
      Matrix.Identity,
      Matrix.CreateTranslation(4.6f, 1.93f, 0.0f) * Matrix.CreateRotationX(MathHelper.ToRadians(-90f)) * Matrix.CreateRotationY(MathHelper.ToRadians(187f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(1f)) * Matrix.CreateTranslation(-24.784f, 42.639f, 2.188f),
      Matrix.Identity,
      Matrix.CreateTranslation(7.8f, 2f, 0.0f) * Matrix.CreateRotationX(MathHelper.ToRadians(-90f)) * Matrix.CreateRotationY(MathHelper.ToRadians(187f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(1f)) * Matrix.CreateTranslation(-24.784f, 42.639f, 2.188f),
      Matrix.Identity,
      Matrix.CreateTranslation(15.47f, 2.25f, 0.0f) * Matrix.CreateRotationX(MathHelper.ToRadians(-90f)) * Matrix.CreateRotationY(MathHelper.ToRadians(187f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(1f)) * Matrix.CreateTranslation(-24.784f, 42.639f, 2.188f),
      Matrix.Identity,
      Matrix.CreateTranslation(15.45f, 1.831f, 0.0f) * Matrix.CreateRotationX(MathHelper.ToRadians(-90f)) * Matrix.CreateRotationY(MathHelper.ToRadians(187f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(1f)) * Matrix.CreateTranslation(-24.784f, 42.639f, 2.188f),
      Matrix.Identity,
      Matrix.CreateTranslation(17.7f, 1.831f, 0.0f) * Matrix.CreateRotationX(MathHelper.ToRadians(-90f)) * Matrix.CreateRotationY(MathHelper.ToRadians(187f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(1f)) * Matrix.CreateTranslation(-24.784f, 42.639f, 2.188f),
      Matrix.Identity,
      Matrix.CreateTranslation(9.5f, 1.35f, 0.0f) * Matrix.CreateRotationX(MathHelper.ToRadians(-90f)) * Matrix.CreateRotationY(MathHelper.ToRadians(187f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(1f)) * Matrix.CreateTranslation(-24.784f, 42.639f, 2.188f),
      Matrix.Identity,
      Matrix.CreateTranslation(16.4f, 3f, 0.0f) * Matrix.CreateRotationX(MathHelper.ToRadians(-90f)) * Matrix.CreateRotationY(MathHelper.ToRadians(187f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(1f)) * Matrix.CreateTranslation(-24.784f, 42.639f, 2.188f),
      Matrix.Identity,
      Matrix.CreateTranslation(5.85f, 2.77f, 0.0f) * Matrix.CreateRotationX(MathHelper.ToRadians(-90f)) * Matrix.CreateRotationY(MathHelper.ToRadians(187f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(1f)) * Matrix.CreateTranslation(-24.784f, 42.639f, 2.188f),
      Matrix.Identity,
      Matrix.CreateTranslation(4.6f, 1.6f, 0.0f) * Matrix.CreateRotationX(MathHelper.ToRadians(-90f)) * Matrix.CreateRotationY(MathHelper.ToRadians(187f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(1f)) * Matrix.CreateTranslation(-24.784f, 42.639f, 2.188f),
      Matrix.Identity,
      Matrix.CreateTranslation(14f, 2f, 0.0f) * Matrix.CreateRotationX(MathHelper.ToRadians(-90f)) * Matrix.CreateRotationY(MathHelper.ToRadians(187f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(1f)) * Matrix.CreateTranslation(-24.784f, 42.639f, 2.188f),
      Matrix.Identity
    };
    public Matrix[] shellExit = new Matrix[22]
    {
      Matrix.CreateRotationY(-1.57f) * Matrix.CreateTranslation(1f, 1.6f, 1f) * Matrix.CreateFromYawPitchRoll(MathHelper.ToRadians(11f), MathHelper.ToRadians(-86f), MathHelper.ToRadians(-180f)) * Matrix.CreateTranslation(-24.784f, 42.639f, 2.188f),
      Matrix.Identity,
      Matrix.CreateRotationY(-1.57f) * Matrix.CreateTranslation(-1f, 1.8f, 0.0f) * Matrix.CreateFromYawPitchRoll(MathHelper.ToRadians(11f), MathHelper.ToRadians(-86f), MathHelper.ToRadians(-180f)) * Matrix.CreateTranslation(-24.784f, 42.639f, 2.188f),
      Matrix.Identity,
      Matrix.CreateRotationY(-1.57f) * Matrix.CreateTranslation(-1f, 1.8f, 0.0f) * Matrix.CreateFromYawPitchRoll(MathHelper.ToRadians(11f), MathHelper.ToRadians(-86f), MathHelper.ToRadians(-180f)) * Matrix.CreateTranslation(-24.784f, 42.639f, 2.188f),
      Matrix.Identity,
      Matrix.CreateRotationY(-1.57f) * Matrix.CreateTranslation(2.7f, 1.8f, 0.3f) * Matrix.CreateFromYawPitchRoll(MathHelper.ToRadians(11f), MathHelper.ToRadians(-86f), MathHelper.ToRadians(-180f)) * Matrix.CreateTranslation(-24.784f, 42.639f, 2.188f),
      Matrix.Identity,
      Matrix.CreateRotationY(-1.57f) * Matrix.CreateTranslation(2.7f, 1.8f, 0.3f) * Matrix.CreateFromYawPitchRoll(MathHelper.ToRadians(11f), MathHelper.ToRadians(-86f), MathHelper.ToRadians(-180f)) * Matrix.CreateTranslation(-24.784f, 42.639f, 2.188f),
      Matrix.Identity,
      Matrix.CreateRotationY(-1.57f) * Matrix.CreateTranslation(1.2f, 1.8f, 0.3f) * Matrix.CreateFromYawPitchRoll(MathHelper.ToRadians(11f), MathHelper.ToRadians(-86f), MathHelper.ToRadians(-180f)) * Matrix.CreateTranslation(-24.784f, 42.639f, 2.188f),
      Matrix.Identity,
      Matrix.CreateRotationY(-1.57f) * Matrix.CreateTranslation(-1.5f, 1.8f, 0.6f) * Matrix.CreateFromYawPitchRoll(MathHelper.ToRadians(11f), MathHelper.ToRadians(-86f), MathHelper.ToRadians(-180f)) * Matrix.CreateTranslation(-24.784f, 42.639f, 2.188f),
      Matrix.Identity,
      Matrix.CreateRotationY(-1.57f) * Matrix.CreateTranslation(1.2f, 1.8f, 0.3f) * Matrix.CreateFromYawPitchRoll(MathHelper.ToRadians(11f), MathHelper.ToRadians(-86f), MathHelper.ToRadians(-180f)) * Matrix.CreateTranslation(-24.784f, 42.639f, 2.188f),
      Matrix.Identity,
      Matrix.CreateRotationY(-1.57f) * Matrix.CreateTranslation(1f, 1.6f, 1f) * Matrix.CreateFromYawPitchRoll(MathHelper.ToRadians(11f), MathHelper.ToRadians(-86f), MathHelper.ToRadians(-180f)) * Matrix.CreateTranslation(-24.784f, 42.639f, 2.188f),
      Matrix.Identity,
      Matrix.CreateRotationY(-1.57f) * Matrix.CreateTranslation(-4f, 1.8f, 0.4f) * Matrix.CreateFromYawPitchRoll(MathHelper.ToRadians(11f), MathHelper.ToRadians(-86f), MathHelper.ToRadians(-180f)) * Matrix.CreateTranslation(-24.784f, 42.639f, 2.188f),
      Matrix.Identity,
      Matrix.CreateRotationY(-1.57f) * Matrix.CreateTranslation(1f, 2f, 1f) * Matrix.CreateFromYawPitchRoll(MathHelper.ToRadians(11f), MathHelper.ToRadians(-86f), MathHelper.ToRadians(-180f)) * Matrix.CreateTranslation(-24.784f, 42.639f, 2.188f),
      Matrix.Identity
    };
    public Matrix flashlightOffset = Matrix.CreateTranslation(0.0f, -5f, 0.0f) * Matrix.CreateFromYawPitchRoll(MathHelper.ToRadians(8f), MathHelper.ToRadians(-86f), MathHelper.ToRadians(-180f)) * Matrix.CreateTranslation(-24.784f, 42.639f, 2.188f);
    public Matrix gunOffset = Matrix.CreateRotationX(MathHelper.ToRadians(-90f)) * Matrix.CreateRotationY(MathHelper.ToRadians(186.8f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(1f)) * Matrix.CreateTranslation(-24.784f, 42.639f, 2.188f);
    public float[] axGun = new float[21]
    {
      0.0f,
      0.0f,
      0.0f,
      0.0f,
      0.0f,
      0.0f,
      11f / 1000f,
      0.0f,
      11f / 1000f,
      0.0f,
      1f / 500f,
      0.0f,
      11f / 1000f,
      0.0f,
      1f / 500f,
      0.0f,
      0.0f,
      0.0f,
      0.0f,
      0.0f,
      11f / 1000f
    };
    public float[] ayGun = new float[21]
    {
      0.0f,
      0.0f,
      0.0f,
      0.0f,
      0.0f,
      0.0f,
      -0.038f,
      0.0f,
      -0.038f,
      0.0f,
      -0.091f,
      0.0f,
      -0.038f,
      0.0f,
      -0.091f,
      0.0f,
      0.0f,
      0.0f,
      0.0f,
      0.0f,
      -0.038f
    };
    public float[] bxGun = new float[21]
    {
      0.0f,
      0.0f,
      0.0f,
      0.0f,
      0.0f,
      0.0f,
      -0.531f,
      0.0f,
      -0.531f,
      0.0f,
      -0.722f,
      0.0f,
      -0.531f,
      0.0f,
      -0.722f,
      0.0f,
      0.0f,
      0.0f,
      0.0f,
      0.0f,
      -0.531f
    };
    public float[] byGun = new float[21]
    {
      0.0f,
      0.0f,
      0.0f,
      0.0f,
      0.0f,
      0.0f,
      -0.193f,
      0.0f,
      -0.193f,
      0.0f,
      -0.214f,
      0.0f,
      -0.193f,
      0.0f,
      -0.214f,
      0.0f,
      0.0f,
      0.0f,
      0.0f,
      0.0f,
      -0.193f
    };
    private ScreenManager.xcross tempcross1 = new ScreenManager.xcross();
    private ScreenManager.xcross tempcross2 = new ScreenManager.xcross();
    private ScreenManager.xcross tempcross3 = new ScreenManager.xcross();
    private ScreenManager.xcross tempcross4 = new ScreenManager.xcross();
    public List<ScreenManager.xcross> crosshair1 = new List<ScreenManager.xcross>();
    public List<Texture2D> crosshairC = new List<Texture2D>();
    public Texture2D basicCrosshair1;
    public Texture2D basicCrosshair2;
    public Texture2D basicCrosshair3;
    public Texture2D basicCrosshair4;
    public int crossIndex;
    public bool allachieves;
    public bool lockVideosetup;
    public bool dlcreleased = true;
    public int cryptHits = 666;
    public int cryptHitsReset = 666;
    public int takepic;
    public bool bonusweek;
    public bool developer;
    public bool guestpresent;
    public bool guest;
    public bool hordemode;
    public bool tunnelMode;
    public bool paintland;
    public int stats_pumpkins;
    public int stats_total;
    public bool forcedout;
    public bool nomovies;
    public string scrnfilename = "";
    public Viewport viewportX = new Viewport(0, 0, 1280, 720);
    public Vector2 textPosition;
    public List<string> kickplayerName = new List<string>();
    public List<CSteamID> kickplayerID = new List<CSteamID>();
    public CSteamID kickID = new CSteamID();
    public string[] fakenames = new string[100]
    {
      "DeadlyPelican",
      "K9Nine619",
      "Kacil",
      "Kaeede",
      "Ticalisoul",
      "SinfulDarkRain",
      "kramberry69",
      "Kain173",
      "UnearnedOrphan",
      "RainbowDashOps",
      "LilERome",
      "kalekemo",
      "tishy19",
      "SHINO BAZ",
      "Honeybeezy",
      "Lopez Ya Dig",
      "Vash Yudai",
      "Furiousfreb",
      "nytemystress",
      "kase2254",
      "HarlotSanctuary",
      "Nintendo",
      "Ca1iso",
      "KatanOmega",
      "katj93",
      "Hobag00782",
      "GNR Nightfall",
      "CNUT21",
      "KazerN4",
      "colonelcheru",
      "Soshii",
      "AsianAvery",
      "KcTheGinger",
      "Krennar",
      "Reek Gz",
      "Ken Is So Wavy",
      "BeheldKerreK",
      "BumbleBee13035",
      "Avatar Zadkiel",
      "keving813",
      "w1cked Dragon",
      "I DUNNO",
      "kfnnapa",
      "snub killer75",
      "KoA xBIGxBOSSx",
      "munkee21",
      "Still Element",
      "Boston96",
      "Aiea Boy",
      "kienenator1",
      "Kiggy429",
      "SamplingKILLA",
      "IDOCOLOMBIANS69",
      "KillaEyez1121",
      "Killerblonde41",
      "blackpantha2",
      "Fred The Spy",
      "wraith2345",
      "KillzoneX5",
      "x1scorpio1x",
      "Kimogila",
      "elitesplicer247",
      "King Killa T",
      "PhilliesPwnYou",
      "Malice 731",
      "aMp FuZioN",
      "JackxBauerxCTU",
      "Sktchd Drknss",
      "king mat 93",
      "Kingofnot7",
      "Dragon King",
      "Kickakapow",
      "kirakomrade",
      "elksdb19",
      "c0uch tr0ll",
      "SuicideSpartan",
      "SirDragonKitty",
      "Kisom",
      "xEmbrac3",
      "animefan1",
      "A2K Kitta",
      "kittenx2008",
      "Kizsurian",
      "Kjgmusic",
      "Krack Dojo",
      "Posui",
      "KayMomo",
      "knb",
      "Kneepad",
      "DrzChamp777",
      "Knux7654",
      "KO M0NKEY",
      "KoA xBIGxBOSSx",
      "DoomShadow24",
      "KOF SHOPPA",
      "kogosamaru",
      "SSG KOHJEX",
      "Daislynn",
      "koolaid252",
      "GameTriforce4"
    };
    public string[] dumAss = new string[35]
    {
      "Use BounceBack when Bleeding Out",
      "Can't take BounceBack while standing",
      "No, you can't use that now",
      "You're standing now, you idiot",
      "No please, ..stop pressing that button",
      "Why are doing this?",
      "Stop trying to use BounceBack",
      "Shit you're Dumb",
      "Stop or you will be booted",
      "I don't think you understand Bounceback",
      "BounceBack is for Later silly",
      "Hey dumbass get a life",
      "I'm going to boot you right now",
      "it's time to tell you a story",
      "I grew up in canada on my dad's pig farm",
      "he was mental and would kidnap people",
      "I was afraid of him he had a temper",
      "he built a huge industrial meat grinder",
      "a horrible smell came from our backyard",
      "One day I went to see what it was",
      "dead bodies everywhere, and rotting",
      "I woke up one night to quiet screaming",
      "my father was staring at me",
      "I finally ran away from home",
      "and I told the police about that farm",
      "my twin brother vanished too",
      "he stole my last pair of green overalls",
      "but that story is for another day",
      "I built this farm with my 2 bare hands",
      "I learned a lot from my father",
      "Would you like to see my meat grinder?",
      "yeah life is hard for me",
      "Sometimes I cry uncontrollably",
      "I get so angry I want to smash everytyhing",
      "But I would never hurt you...."
    };
    public bool hover;
    public bool myplayerCheats;
    public List<ulong> strangers = new List<ulong>();
    public int drwhoCount;
    public bool friended;
    public List<ulong> kickers = new List<ulong>();
    public List<int> redsuns = new List<int>();
    public bool hostAllowCheats = true;
    public bool allWeapons = true;
    public bool hostFriendly;
    public bool hostBobbleheads;
    public bool shownames;
    public string glowtype = "EdgeDetect";
    public CSteamID hostowner = new CSteamID();
    public int myplayerindex;
    public Color[] colors = new Color[8]
    {
      new Color(237, 28, 36, (int) byte.MaxValue),
      new Color(242, 212, 0, (int) byte.MaxValue),
      new Color(0, 171, 0, (int) byte.MaxValue),
      new Color((int) byte.MaxValue, 140, 0, (int) byte.MaxValue),
      Color.Gold,
      Color.Cyan,
      Color.PaleGreen,
      Color.PeachPuff
    };
    public bool blackandwhite = true;
    private string[] dayTips;
    public bool usingMouse;
    public bool host = true;
    public bool rebuildFog;
    public bool rebuildTwinSplat;
    public bool deactivated;
    public bool rebuildTargets;
    public int tempRifle = 2;
    public int tempPistol = 2;
    public int tempAmmo;
    public int tempMag;
    public int bossexplodechoice = 1;
    public bool setgraphics;
    public bool justsetgraphics;
    public bool drawme = true;
    public int mousefade;
    public Vector2 mymouse = Vector2.Zero;
    public float mylens = 58f;
    public float myfov = 0.75f;
    public int leaderboardCounter;
    public int leaderboardSelect = 1;
    public achieve trophy;
    public Lobby lobby;
    public Workshop workshop;
    public goldenkey goldKeys;
    public Microsoft.Xna.Framework.Input.Keys lmb_key = Microsoft.Xna.Framework.Input.Keys.VolumeDown;
    public Microsoft.Xna.Framework.Input.Keys mmb_key = Microsoft.Xna.Framework.Input.Keys.VolumeMute;
    public Microsoft.Xna.Framework.Input.Keys rmb_key = Microsoft.Xna.Framework.Input.Keys.VolumeUp;
    public Microsoft.Xna.Framework.Input.Keys but1_key = Microsoft.Xna.Framework.Input.Keys.Print;
    public Microsoft.Xna.Framework.Input.Keys but2_key = Microsoft.Xna.Framework.Input.Keys.PrintScreen;
    public Microsoft.Xna.Framework.Input.Keys escape_key = Microsoft.Xna.Framework.Input.Keys.Escape;
    public Microsoft.Xna.Framework.Input.Keys w_key = Microsoft.Xna.Framework.Input.Keys.W;
    public Microsoft.Xna.Framework.Input.Keys a_key = Microsoft.Xna.Framework.Input.Keys.A;
    public Microsoft.Xna.Framework.Input.Keys s_key = Microsoft.Xna.Framework.Input.Keys.S;
    public Microsoft.Xna.Framework.Input.Keys d_key = Microsoft.Xna.Framework.Input.Keys.D;
    public Microsoft.Xna.Framework.Input.Keys f_key = Microsoft.Xna.Framework.Input.Keys.F;
    public Microsoft.Xna.Framework.Input.Keys q_key = Microsoft.Xna.Framework.Input.Keys.Q;
    public Microsoft.Xna.Framework.Input.Keys e_key = Microsoft.Xna.Framework.Input.Keys.E;
    public Microsoft.Xna.Framework.Input.Keys x_key = Microsoft.Xna.Framework.Input.Keys.X;
    public string myXkey = nameof (x_key);
    public Microsoft.Xna.Framework.Input.Keys r_key = Microsoft.Xna.Framework.Input.Keys.R;
    public Microsoft.Xna.Framework.Input.Keys b_key = Microsoft.Xna.Framework.Input.Keys.B;
    public Microsoft.Xna.Framework.Input.Keys t_key = Microsoft.Xna.Framework.Input.Keys.T;
    public Microsoft.Xna.Framework.Input.Keys u_key = Microsoft.Xna.Framework.Input.Keys.Space;
    public Microsoft.Xna.Framework.Input.Keys enter_key = Microsoft.Xna.Framework.Input.Keys.Enter;
    public Microsoft.Xna.Framework.Input.Keys up_key = Microsoft.Xna.Framework.Input.Keys.Up;
    public Microsoft.Xna.Framework.Input.Keys down_key = Microsoft.Xna.Framework.Input.Keys.Down;
    public Microsoft.Xna.Framework.Input.Keys right_key = Microsoft.Xna.Framework.Input.Keys.Right;
    public Microsoft.Xna.Framework.Input.Keys left_key = Microsoft.Xna.Framework.Input.Keys.Left;
    public Microsoft.Xna.Framework.Input.Keys dead_key = Microsoft.Xna.Framework.Input.Keys.Left;
    public Microsoft.Xna.Framework.Input.Keys f10_key = Microsoft.Xna.Framework.Input.Keys.F10;
    public Microsoft.Xna.Framework.Input.Keys plus_key = Microsoft.Xna.Framework.Input.Keys.OemPlus;
    public Microsoft.Xna.Framework.Input.Keys space_key = Microsoft.Xna.Framework.Input.Keys.Space;
    public chatbox chat;
    public Microsoft.Xna.Framework.Input.Keys one_key = Microsoft.Xna.Framework.Input.Keys.D1;
    public Microsoft.Xna.Framework.Input.Keys two_key = Microsoft.Xna.Framework.Input.Keys.D2;
    public Microsoft.Xna.Framework.Input.Keys three_key = Microsoft.Xna.Framework.Input.Keys.D3;
    public Microsoft.Xna.Framework.Input.Keys four_key = Microsoft.Xna.Framework.Input.Keys.D4;
    public Microsoft.Xna.Framework.Input.Keys tab_key = Microsoft.Xna.Framework.Input.Keys.Tab;
    public Microsoft.Xna.Framework.Input.Keys f1_key = Microsoft.Xna.Framework.Input.Keys.F1;
    public Microsoft.Xna.Framework.Input.Keys f2_key = Microsoft.Xna.Framework.Input.Keys.F2;
    public Microsoft.Xna.Framework.Input.Keys f3_key = Microsoft.Xna.Framework.Input.Keys.F3;
    public Microsoft.Xna.Framework.Input.Keys leftshift_key = Microsoft.Xna.Framework.Input.Keys.LeftShift;
    private KeyboardState keyState;
    private bool skipsettings;
    public bool drawViewport = true;
    public Rectangle screenSize;
    public Rectangle origSize;
    public float startResX;
    public float startResY;
    public int width;
    public int hite;
    public float aspect;
    public float orighite;
    public bool easter_skulltalk;
    public bool easter_skull1;
    public bool easter_skull2;
    public bool easter_skull3;
    public Vector2 winCenter;
    public int screenoffsetX;
    public int screenoffsetY;
    public Vector2 winCorner;
    public float isMaximized = 1f;
    public bool screenAction;
    public int myval;
    public int thisVersion = 4;
    public string loadMoment = "null";
    public bool removeNicely;
    public bool walletHint;
    public bool walletHintShow;
    public bool deathcamHint;
    public bool viewGarbage;
    public bool kilroyExists;
    public bool cheat_mousetest;
    public bool cheat_astro;
    public bool cheat_avoidhoming;
    public bool cheatsOn;
    public bool cheat_skipday;
    public bool cheat_allweapons;
    public bool cheat_noenemies;
    public bool cheat_killboss;
    public bool networkLag;
    public byte networkQuality;
    public bool debug_showGarbage;
    public bool debug_showSeed;
    public bool debug_showHoming;
    public bool debug_showAccuracy;
    public bool debug_showNetwork;
    public bool debug_show;
    public bool debug_cauldron;
    public bool cheat_SendPackage;
    public bool cheat_Invincible;
    public bool cheat_FastFiring;
    public bool cheat_InfiniteAmmo;
    public bool cheat_AllExplode;
    public bool cheat_PickupPack;
    public bool cheat_unlockAll;
    public bool cheat_nokick;
    private Vector2 topcorner;
    private Color bluePen = new Color(7, 6, 107, (int) byte.MaxValue);
    private Color bluePen2 = new Color(7, 6, 107, (int) byte.MaxValue);
    private Color redPen = new Color(230, 9, 12, (int) byte.MaxValue);
    private Color grnPen = new Color(20, 220, 10, (int) byte.MaxValue);
    public bool bool_0;
    public int[] lag = new int[16]
    {
      0,
      10,
      50,
      55,
      70,
      75,
      110,
      115,
      130,
      135,
      180,
      185,
      210,
      310,
      525,
      700
    };
    public float[] loss = new float[16]
    {
      0.0f,
      0.05f,
      0.05f,
      0.1f,
      0.05f,
      0.1f,
      0.05f,
      0.13f,
      0.05f,
      0.15f,
      0.1f,
      0.2f,
      0.15f,
      0.3f,
      0.51f,
      0.65f
    };
    public List<int>[] predayList = new List<int>[7]
    {
      new List<int>() { 1 },
      new List<int>() { 28, 24 },
      new List<int>() { 29, 34 },
      new List<int>() { 26, 25 },
      new List<int>() { 27 },
      new List<int>() { 30, 9 },
      new List<int>() { 32 }
    };
    public List<int>[] dayList = new List<int>[9]
    {
      new List<int>() { 1 },
      new List<int>() { 2, 13 },
      new List<int>() { 18, 35 },
      new List<int>() { 7, 3, 22 },
      new List<int>() { 8, 4, 22 },
      new List<int>() { 9, 14 },
      new List<int>() { 19, 21 },
      new List<int>() { 30, 31 },
      new List<int>() { 33 }
    };
    public int weFailed;
    public bool updatedTrialFile;
    public int trialattempt;
    public int trialTimer;
    public long trialStart;
    private Rectangle cancelButtonBlue = new Rectangle(365, 546, 50, 26);
    private Rectangle cancelButtonRed = new Rectangle(313, 546, 50, 26);
    private Rectangle saveButtonBlue = new Rectangle(313, 580, 71, 34);
    private Rectangle saveButtonRed = new Rectangle(313, 614, 71, 34);
    private Rectangle resetButtonBlue = new Rectangle(393, 580, 71, 34);
    private Rectangle resetButtonRed = new Rectangle(393, 614, 71, 34);
    private Rectangle cancelButtonX = new Rectangle(700, 700, 50, 26);
    private Rectangle saveButtonX = new Rectangle(700, 730, 71, 34);
    private Rectangle resetButtonX = new Rectangle(700, 770, 71, 34);
    private Rectangle blackX = new Rectangle(700, 820, 20, 20);
    private TrialStorage storageTrial = new TrialStorage();
    private TrialData trials = new TrialData();
    private string[] away = new string[27]
    {
      "AWAY",
      "OINK",
      "PIGS",
      "WHY",
      "WAIT",
      "OOHH",
      "OUCH",
      "SURE",
      "FARM",
      "DONT",
      "PORK",
      "HAM",
      "SHIT",
      "DANG",
      "KISS",
      "HOLE",
      "GRIN",
      "PINK",
      "DUNG",
      "POOP",
      "FART",
      "BOAR",
      "SPAM",
      "PUBG",
      "WINK",
      "LICK",
      "PUBG"
    };
    private int awayIndex;
    public bool keepShowingWarning = true;
    private float versionNumber = 48f;
    public SoundEffect crash;
    public bool barnsLoaded;
    public bool mountainBuildingLoaded;
    public bool loadGuns;
    public bool loadMainModels;
    public bool showVideoSetup;
    public float fileVersion;
    public float spaceVersion = 2.1f;
    public int errorMessageTimer;
    public string errorMessage = "";
    public bool leavingGame;
    public bool isLoading = true;
    public float blackdayFader;
    public float introCamera;
    public bool fenceDemo;
    public bool musicDemo;
    public int dataPause;
    public float myTimer;
    public bool titlesLoaded;
    public int grenades;
    public int milks;
    public int hulks;
    public int pills;
    public int rockets;
    public int[] hats = new int[16];
    public string[] hatnames = new string[16]
    {
      "nothing",
      "top-hat",
      "cowboy hat",
      "russian bol",
      "tracktor cap",
      "german helmut",
      "wizard hat",
      "gas mask",
      "pumpkin",
      "elfinhat",
      "redsun hat",
      "macarthur",
      "snowcap",
      "peruvian pom",
      "irish tweed",
      "bowler hat"
    };
    public bool man1;
    public bool man2;
    public bool man3;
    public bool man4;
    public bool star1;
    public bool star2;
    public bool star3;
    public int workshopNum;
    public bool bossLoaded;
    public bool cuttyLoaded;
    public bool bigmodelLoaded;
    public Vector3[,] hatTransX;
    public Vector3[,] hatRotX;
    public float[,] hatScaleX;
    public Vector2 hatTrigger = new Vector2(-1f, -1f);
    public int privateMode;
    public int gameState;
    public int gameSpectate;
    public int gameNPC = 1;
    public int gameSeed;
    public bool levelChange;
    public bool sendlevelChange;
    public string newDayTime = "am";
    public float darkness = 1f;
    public float olderdarkness = 1f;
    public float oldFenceDarkness = 1f;
    public float oldMirvDarkness = 1f;
    public float realDarkness = 1f;
    public int realMoon;
    public Vector3 moontype = new Vector3(0.0f, 0.1f, -0.3f) * 2f;
    public int previousDay = 1;
    public int currentDay = 1;
    public int tempcurrentDay = 1;
    public int curDay = 1;
    public bool FarmerUnlocked;
    public string dayTime = "am";
    public bool mustarDay;
    public int int_0;
    public int int_1;
    public int int_2;
    public int int_3;
    public float boar1Rot;
    public float boar2Rot;
    public float float_0;
    public float float_1;
    public int boar1Borders = 1;
    public int boar2Borders = 1;
    public int int_4;
    public int int_5;
    public int revengeDay;
    public int grinderYesterday;
    public int grinderToday;
    public float bloodLevel;
    public int fencecharge;
    public int weaponEndofDay;
    public int previousWeapons;
    public int boar1Variant;
    public int boar2Variant = 1;
    public int int_6;
    public int boarCount = 100;
    public int int_7 = 80;
    public int int_8 = 80;
    public int headless1Percent = 30;
    public int headless2Percent = 30;
    public int boar1explode = 1;
    public int boar1shottie = 1;
    public int boar2explode = 1;
    public int boar2shottie = 1;
    public int[] weapon_Unlock = new int[26]
    {
      0,
      0,
      1,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0
    };
    public bool scarh_Unlock;
    public int[] grinder_Unlock = new int[6]
    {
      1,
      0,
      0,
      0,
      0,
      0
    };
    public int[] grinder_Supply = new int[6]
    {
      100,
      100,
      100,
      100,
      100,
      100
    };
    public int int_9 = 15;
    public int int_10;
    public int boar1MinSize;
    public int boar1MaxSize;
    public int boar1GiantOdds;
    public int boar1TinyOdds;
    public int int_11;
    public int boar1TurnRate;
    public int int_12 = 15;
    public int int_13;
    public int boar2MinSize;
    public int boar2MaxSize;
    public int boar2GiantOdds;
    public int boar2TinyOdds;
    public int int_14;
    public int boar2TurnRate;
    public int boarAttack;
    public int boarTurnRate;
    public float[] handicapDam = new float[5]
    {
      3f,
      1f,
      0.5f,
      0.5f,
      0.5f
    };
    public float[] handicapBite = new float[5]
    {
      0.5f,
      1f,
      2f,
      2f,
      2f
    };
    public float[] handicapSpeed = new float[4]
    {
      0.6f,
      1f,
      1.5f,
      1.5f
    };
    public float[] handicapTurn = new float[5]
    {
      1f,
      1f,
      3f,
      3f,
      3f
    };
    public float[] handicapDam2 = new float[5]
    {
      3f,
      0.7f,
      0.25f,
      0.25f,
      0.25f
    };
    public float[] handicapBite2 = new float[5]
    {
      0.5f,
      1.5f,
      3f,
      2f,
      2f
    };
    public float[] handicapSpeed2 = new float[4]
    {
      0.6f,
      1f,
      1.5f,
      1.5f
    };
    public float[] handicapTurn2 = new float[5]
    {
      1f,
      1.2f,
      3f,
      3f,
      3f
    };
    public float[] handicapDam4 = new float[5]
    {
      2f,
      0.75f,
      0.25f,
      0.25f,
      0.25f
    };
    public float[] handicapBite4 = new float[5]
    {
      1f,
      2f,
      3f,
      2f,
      2f
    };
    public float[] handicapSpeed4 = new float[4]
    {
      1f,
      1.1f,
      1.5f,
      1.5f
    };
    public float[] handicapTurn4 = new float[5]
    {
      1f,
      1.2f,
      3f,
      3f,
      3f
    };
    public int[] boarPercent = new int[3]{ 80, 40, 0 };
    public int[] boarDistance = new int[3]{ 300, 600, 1100 };
    public int[] boarHomingLimit = new int[3]{ 2, 5, 12 };
    public SoundEffectInstance corncobMusic;
    public SoundEffectInstance crickets;
    public bool gameMusicPlaying;
    public SoundEffect mainTheme;
    public SoundEffect xmas1;
    public SoundEffect xmas2;
    public SoundEffect[] pigExplode;
    public SoundEffect[] steps;
    public SoundEffect[] crumble;
    public SoundEffect[] pump;
    public SoundEffect[] boarbite;
    public SoundEffect[] ricochete;
    public SoundEffect[] sproing;
    public SoundEffect[] grenadePop1;
    public SoundEffect[] pigSqueal;
    public SoundEffect[] pigDie;
    public SoundEffect hammer1;
    public SoundEffect doorRattle;
    public SoundEffect buttonPress;
    public SoundEffect buttonDeny;
    public SoundEffect achieve1;
    public SoundEffect buttonPackage;
    public SoundEffect mirvDrop;
    public SoundEffect doorUnlock;
    public SoundEffect pickup1;
    public SoundEffect pickup2;
    public SoundEffect pickupGrenade;
    public SoundEffect drinkMilk;
    public SoundEffect piledriver;
    public SoundEffect fireworks;
    public SoundEffect fireworks2;
    public SoundEffect barndoor;
    public SoundEffect fence;
    public SoundEffect crunch;
    public SoundEffect shotgunPump;
    public SoundEffect gusher;
    public SoundEffect hulkRoar;
    public SoundEffect hulkRoar2;
    public SoundEffect roar;
    public SoundEffect gamestart;
    public SoundEffect abort;
    public SoundEffect harp2;
    public SoundEffect humm;
    public SoundEffect chunk1;
    public SoundEffect chunk2;
    public SoundEffect meaty;
    public SoundEffect manyell;
    public SoundEffect hurt;
    public SoundEffect grabby;
    public SoundEffect chomp2;
    public SoundEffect bonepop;
    public SoundEffect report;
    public SoundEffect dieyell;
    public SoundEffect cuttygouge;
    public SoundEffect cuttyWave;
    public SoundEffect buzz;
    public SoundEffect newtip;
    public SoundEffect pillRattler;
    public SoundEffect pillswallow;
    public SoundEffect pillselect;
    public SoundEffect jot1;
    public SoundEffect jot2;
    public SoundEffect cashout;
    public SoundEffect scribble;
    public SoundEffect menuclick;
    public SoundEffect switchweapon;
    public SoundEffect melee;
    public SoundEffect lightClick;
    public SoundEffect grinder;
    public SoundEffects grinderMotor;
    public SoundEffects chain;
    public SoundEffect ring;
    public SoundEffect chomp;
    public SoundEffect ruffles;
    public SoundEffect falldown;
    public SoundEffect falldown2;
    public SoundEffect toneer;
    public SoundEffect dying;
    public SoundEffect drip;
    public SoundEffect ding;
    public SoundEffect achievepop;
    public SoundEffect pileDriverSure;
    public SoundEffect scree;
    public SoundEffect xmas;
    public SoundEffect startMusic;
    public SoundEffect accept;
    public SoundEffect cancel;
    public SoundEffect equipx;
    public SoundEffect wavecomplete;
    public SoundEffect allpigs;
    public SoundEffect fanfare;
    public SoundEffect[] metalHit;
    public SoundEffect[] cocking = new SoundEffect[22];
    public SoundEffect[] gunFire = new SoundEffect[22];
    public SoundEffect[] gunMuffle = new SoundEffect[22];
    public SoundEffect[] gunDry = new SoundEffect[22];
    public SoundEffect[] shellSound = new SoundEffect[22];
    public SoundEffect tick;
    public SoundEffect switch2;
    public SoundEffect grow;
    public Vector3 hatTrans = Vector3.Zero;
    public float hatscale = 1f;
    public int hatindex;
    public Effect hatEffect;
    public Matrix[,] hatMatrix = new Matrix[11, 16];
    public Matrix[,] temphatMatrix = new Matrix[11, 16];
    public Model gunPack;
    public Model hatPack;
    public Model[] shellPack = new Model[22];
    public Texture2D[] gunTextures = new Texture2D[22];
    public Texture2D[] hatTextures = new Texture2D[16];
    public Texture2D goldkeyTexture;
    public Texture2D blimpTexture;
    public Texture2D moonTexture;
    public Model pigAll;
    public Model pigModel;
    public Model pigModelPrincess;
    public Model cowModel;
    public Model bossAll;
    public int bossIndex;
    public Model water;
    public Model boar1basicModel;
    public Model model_0;
    public Model boarbruteModel;
    public Model bruteheadlessModel;
    public Model boarSkel;
    public Model boarSkelHeadless;
    public Model charModel;
    public Model boarArmorModel;
    public Model boarArmorModelHeadless;
    public Model boarmasterModel;
    public Model piggyModel;
    public Model boarmasterModelHeadless;
    public Model zombieModel;
    public Model cube;
    public Model decal;
    public Model decalb;
    public Model decal2;
    public Model biteDecal;
    public Model explosionDecal;
    public Model fireballDecal;
    public Model fireballDecal2;
    public Model buttonModel;
    public Model grass;
    public Model trees;
    public Model farmTriangles;
    public Model farmTriangles2;
    public Model farmTriangles3;
    public Model barnTriangles;
    public Model doorTriangles;
    public Model farmBuilding;
    public Model farmBuilding2;
    public Model farmBuilding3;
    public Model farmBuildingspace;
    public Model tunnel1;
    public Model tunnelTriangle;
    public Model tunnelheights;
    public Model barnBuilding;
    public Model mountain;
    public Texture2D waterTexture;
    public Texture2D johnnyWallet;
    public Texture2D landoWallet;
    public Texture2D farmerWallet;
    public Texture2D skellyWallet;
    public Texture2D johnWallet;
    public Texture2D daisyWallet;
    public Texture2D vikingWallet;
    public Texture2D deadWallet;
    public Texture2D robotWallet;
    public Texture2D golemWallet;
    public Texture2D astroWallet;
    public Texture2D paper1;
    public Texture2D controller;
    public Texture2D controller2;
    public Texture2D blankpaper;
    public Texture2D blankpaper2;
    public Texture2D instructions;
    public Texture2D page1;
    public Texture2D page2;
    public Texture2D page3;
    public Texture2D page4;
    public Texture2D page5;
    public Texture2D page6;
    public Texture2D page7;
    public Texture2D reflectionMap;
    public Texture2D spotTexture;
    public Texture2D crosshair;
    public Texture2D burster;
    public Texture2D electrify;
    public Texture2D muzzles;
    public Texture2D blasts;
    public Model heightmodel;
    public Model heightmodel2;
    public Model farmspacecollide;
    public Texture2D grassTexture;
    public Texture2D mountTexture;
    public Texture2D grassTextureNight;
    public Texture2D mountTextureNight;
    public Texture2D texture2D_0;
    public Texture2D buildingRGBNight;
    public Texture2D buildingShadow;
    public Texture2D buildingShadowNight;
    public Texture2D buildingshadspace;
    public Texture2D barnRGB;
    public Texture2D barnShadow;
    public Model gunMuzzle;
    public Model gunBlast;
    public Model blueLaser;
    public Texture2D overlay;
    public Texture2D overlayStats;
    public Texture2D overlayStats2;
    public Texture2D bc1;
    public Texture2D bc2;
    public Texture2D titleTrailer;
    public Texture2D titleTrailerDemo;
    public Texture2D titleFrame;
    public Texture2D titleBG;
    public Texture2D titleBG2;
    public Texture2D titlePig0;
    public Texture2D titlePig1;
    public Texture2D titlePig2;
    public Texture2D titlePig3;
    public Texture2D titleFaces;
    public Texture2D titleCharsJoin;
    public Texture2D titleCharsMain;
    public Texture2D titleCharsSingle;
    public Texture2D titleCharsVideo;
    public Texture2D titleCharsDemo;
    public Texture2D titleHeaderBloodBacon;
    public Texture2D titleHeaderBloodBaconB;
    public Texture2D titleHeaderBloodBaconC;
    public Texture2D titleHeaderLobby;
    public Texture2D titleHeaderVideos;
    public Texture2D titleHeaderControls;
    public Texture2D titleHeaderDiary;
    public Texture2D titleHeaderSecrets;
    public Texture2D titleHeaderMore;
    public Texture2D titleheaderSettings;
    public Texture2D texture2D_1;
    public Texture2D titleHeaderMultiplayer;
    public Texture2D texture2D_2;
    public Texture2D texture2D_3;
    public Texture2D titleHeaderLobbies;
    public Texture2D titleHeaderLobbies2;
    public Texture2D titleHeaderAudio;
    public Texture2D titleCharsGraphics;
    public Texture2D titleHeaderJoin;
    public Texture2D titleCreditWall;
    public Texture2D titleCreditBlank;
    public Texture2D titleCredit1;
    public Texture2D titleCredit2;
    public Texture2D titleHeaderWorkshop;
    public Texture2D titleHeaderWorkshop2;
    public Texture2D titleHeaderWorkshopPublish;
    public Texture2D titleHeaderWorkshopPublish2;
    public Texture2D button;
    public Texture2D titleHeaderTunnelDays;
    public Model farmerModel;
    public Model twinModel;
    public Model farmerModelskull;
    public Texture2D farmerTexture;
    public Texture2D twinTexture;
    public Texture2D pigTexture;
    public Model player1Model;
    public Model model_1;
    public Model player2Model;
    public Model model_2;
    public Model whiteNPCModel;
    public Model whiteNPCnoarms;
    public Model blackNPCModel;
    public Model farmerNPCModel;
    public Model skelNPCmodel;
    public Model daisyNPCmodel;
    public Model vikingNPCmodel;
    public Model strawNPCModel;
    public Model robotNPCModel;
    public Model golemNPCModel;
    public Model astroNPCModel;
    public Model blackNPCnoarms;
    public Model farmerNPCnoarms;
    public Model skelNPCnoarms;
    public Model daisyNPCnoarms;
    public Model vikingNPCnoarms;
    public Model strawNPCnoarms;
    public Model robotNPCnoarms;
    public Model golemNPCnoarms;
    public Model astroNPCnoarms;
    public Model ghostNPCmodel;
    public Texture2D blackNPCTexture;
    public Texture2D farmerNPCTexture;
    public Texture2D skelNPCTexture;
    public Texture2D daisyNPCTexture;
    public Texture2D vikingNPCTexture;
    public Texture2D strawNPCTexture;
    public Texture2D robotNPCTexture;
    public Texture2D golemNPCTexture;
    public Texture2D astroNPCTexture;
    public Texture2D ghostNPCTexture;
    public Texture2D texture2D_4;
    public Texture2D texture2D_5;
    public Texture2D texture2D_6;
    public Texture2D texture2D_7;
    public Texture2D texture2D_8;
    public Texture2D texture2D_9;
    public Texture2D texture2D_10;
    public Texture2D texture2D_11;
    public Texture2D texture2D_12;
    public Texture2D[] badges;
    public Texture2D whiteNPCTexture;
    public Texture2D texture2D_13;
    public Texture2D whiteNPCTextureGreen2;
    public Texture2D texture2D_14;
    public Texture2D farmerGreen;
    public Texture2D daisyGreen;
    public Texture2D vikingGreen;
    public Texture2D skelGreen;
    public Texture2D strawGreen;
    public Texture2D robotGreen;
    public Texture2D golemGreen;
    public Texture2D astroGreen;
    public Texture2D whiteNPCdead;
    public Texture2D blackNPCdead;
    public Texture2D farmerDead;
    public Texture2D skelDead;
    public Texture2D daisyDead;
    public Texture2D vikingDead;
    public Texture2D strawDead;
    public Texture2D robotDead;
    public Texture2D golemDead;
    public Texture2D astroDead;
    public Texture2D wound;
    public Rectangle[] woundRect;
    public Texture2D star;
    public Texture2D starB;
    public Texture2D staroff;
    public Texture2D certified;
    public int paintColor = 5;
    public int paintColorCanvas = 8;
    public int paintRemColor = 5;
    public int paintRemColorCanvas = 8;
    public bool walletLoaded;
    public bool moremodelsLoaded;
    public bool audioLoaded;
    public SpriteFont landerfont;
    public SpriteFont font;
    public SpriteFont font3;
    public SpriteFont grungeFont;
    public SpriteFont font2;
    public SpriteFont fontsmall;
    public SpriteFont lilyFont;
    public SpriteFont arialfont;
    public SpriteFont scribblefont;
    public SpriteFont scribblefont2;
    public SpriteFont terminal;
    public SpriteFont squarefont;
    public SpriteBatch SpriteBatch;
    private bool isInitialized;
    public bool tryPurchase;
    public bool rtLock;
    public int setupnum = 1;
    public int aa;
    public List<GameScreen> screens = new List<GameScreen>();
    private List<GameScreen> screensToUpdate = new List<GameScreen>();
    private InputState input = new InputState();
    private spaceStorage storageSpacePrefs = new spaceStorage();
    private SpaceData spaceprefs = new SpaceData();
    private PrefStorage storagePrefs = new PrefStorage();
    private PrefData prefs = new PrefData();
    private GameStorage storageGame = new GameStorage();
    public GameData gdata = new GameData();
    public string storeState = "";
    public bool protectScreen;
    public int[] days = new int[201];
    public float camradian1 = -1.725f;
    public float camheight1 = 2.95f;
    public Vector3 vector3_0 = new Vector3(-21.53f, 48.7f, 15.2f);
    public Vector3 camlookpos3rd1 = new Vector3(172.4f, 10.25f, -14.95f);
    public float camradian2 = -1.55f;
    public float camheight2 = 2.08f;
    public Vector3 vector3_1 = new Vector3(-71f, 303f, 6.3f);
    public Vector3 camlookpos3rd2 = new Vector3(-45.6f, 259f, 6.7f);
    public Texture2D whiteTexture;
    public Texture2D blackTexture;
    public Texture2D menuBlob;
    public Texture2D menuBlob2;
    public Texture2D redTexture;
    public int brightness;
    public int brightBU;
    public int contrast;
    public int contrastBU;
    public int redContrast;
    public int shitContrast;
    public BlendState brightnessUP;
    public BlendState brightnessDOWN;
    public BlendState contrastBlend;
    public ushort dayLevel = 1;
    public float mv = 0.5f;
    public float ev = 0.8f;
    public float vv = 0.7f;
    public int df = 1;
    public int df_orig = 1;
    public float pad_invertY = 1f;
    public float pad_sensitivity = 1f;
    public bool pad_vibro = true;
    public bool pad_reload = true;
    public bool pad_togglesprint = true;
    public int aliasing;
    public int resolution;
    public int fullscreen;
    public string playername = "Player";
    public int gorelevel;
    public bool doubleAmmo;
    public bool fastnades;
    public bool fullmode = true;
    public bool border = true;
    public List<string> resnames;
    public Vector2 hud_enemy = new Vector2(90f, 35f);
    public Vector2 hud_clock = new Vector2(490f, 35f);
    public Vector2 hud_day = new Vector2(1180f, 35f);
    public Vector2 hud_player1 = new Vector2(485f, 620f);
    public Vector2 hud_player2 = new Vector2(70f, 620f);
    public Vector2 hud_weapons = new Vector2(1130f, 290f);
    public Vector2 hud_dpad = new Vector2(1135f, 360f);
    public Color color_enemy = new Color(210, 0, 0, (int) byte.MaxValue);
    public Color color_day = new Color(210, 0, 0, (int) byte.MaxValue);
    public Color color_clock = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    public Color color_player1 = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    public Color color_player2 = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    public Color color_weapons = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    public Color color_dpad = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    private SoundEffect opening;
    public ContentManager content;
    public ContentManager content2;
    public ContentManager conModel;
    public string gamername = "noname";
    public Viewport myviewport;
    public GraphicsDeviceManager graphics;
    public int cardx;
    public int cardy;
    public int devicex;
    public int devicey;
    public int viewportx;
    public int viewporty;
    public astro astronaut;
    public int frontDoor;
    public bool debug;
    public int aliasSet = 2;
    public PlayerIndex gamerindex;
    public int myindex;
    public float typewriterblank = 500f;
    public int textflag;
    public float typewriterwait = 100f;
    public float typeposition;
    public float typevertical = 100f;
    public int typewriterdelay = 3;
    public float siders = 10f;
    public float bottomer = 710f;
    public float topper = 10f;
    public float voiceVolume = 0.5f;
    public int bgindex = 1;
    public int planet = 1;
    public float fadeSetting = 10f;
    public float filterSetting;
    public float intenseSetting = 8f;
    public float gamefadeSetting = 7f;
    public float gamefilterSetting;
    public float gameintenseSetting = 3f;
    public int aliasSetting;
    public float aspectratio = 1.78f;
    public float aspectratio2 = 1.78f;
    public int vehicleindex = 3;
    public bool space_vibro = true;
    public int space_invertX = 1;
    public int space_invertY = 1;
    public float space_sentivityX = 1f;
    public float space_sentivityY = 1f;
    public int space_winvertX = 1;
    public int space_winvertY = 1;
    public float space_wsentivityX = 1f;
    public float space_wsentivityY = 1f;
    public int space_rinvertX = 1;
    public int space_rinvertY = 1;
    public float space_rsentivityX = 1f;
    public float space_rsentivityY = 1f;
    public int vibroSetting = 1;
    public float camradian;
    public float camradius = 1000f;
    public int[] allcamsradius = new int[4]{ 0, 1, 3, 4 };
    public int[] allcamsorbit = new int[4];
    public int[] allcamsaltitude = new int[4];
    public int[] allcamslens = new int[4];
    public int roverindex = 2;
    public int roverrotlock;
    public int roverhitelock = 1;
    public float[] roverdist = new float[3]
    {
      200f,
      440f,
      800f
    };
    public float[] roverheight = new float[3]
    {
      100f,
      400f,
      700f
    };
    public float[] roverradian = new float[3]
    {
      100f,
      100f,
      100f
    };
    public int landerindex = 1;
    public int landerrotlock;
    public int landerhitelock = 1;
    public float[] landerdist = new float[3]
    {
      500f,
      1400f,
      2500f
    };
    public float[] landerheight = new float[3]
    {
      300f,
      300f,
      300f
    };
    public float[] landerradian = new float[3]
    {
      100f,
      100f,
      100f
    };
    public int loadflag;
    public int drawflag = 1;
    public int menuflag;
    public SpriteFont halo;
    public SpriteFont halo2;
    public Texture2D glow1;
    public SoundEffect landerEngine;
    public SoundEffect fuellow;
    public SoundEffect fuelfull;
    public SoundEffect opensolar;
    public SoundEffect refine1;
    public SoundEffect refine2;
    public SoundEffect roverEngine;
    public SoundEffect dropEngine;
    public SoundEffect gravel;
    public SoundEffect overture;
    public SoundEffect breath;
    public SoundEffect boom;
    public SoundEffect clickmenu;
    public SoundEffect click;
    public SoundEffect step;
    public SoundEffect forward;
    public SoundEffect back;
    public SoundEffect rejected;
    public SoundEffect radio1;
    public SoundEffect radio2;
    public SoundEffect radio3;
    public SoundEffect release;
    public SoundEffect cablesnap;
    public SoundEffect crack;
    public SoundEffect cheer;
    public SoundEffect breakage;
    public SoundEffect breakage2;
    public SoundEffect dropBeacon;
    public SoundEffect eraseBeacon;
    public SoundEffect warning;
    public SoundEffect boulderhit;
    public SoundEffect boulderhit2;
    public SoundEffect boulderhit3;
    public SoundEffect boulderhit4;
    public SoundEffect shalehit1;
    public SoundEffect steeldrum1;
    public SoundEffect steeldrum2;
    public SoundEffect forklift;
    public SoundEffect confirm;
    public SoundEffect shocks;
    public SoundEffect shocks2;
    public SoundEffect shocks3;
    public SoundEffect shocks4;
    public SoundEffect enginex;
    public SoundEffect scoopx;
    public SoundEffect groundhit;
    public SoundEffect ramp;
    public SoundEffect tada;
    public SoundEffect tada2;
    public SoundEffect tada3;
    public SoundEffect tada4;
    public SoundEffect tada5;
    public SoundEffect tada6;
    public SoundEffect tada7;
    public SoundEffect tada10;
    public SoundEffect gemfound;
    public SoundEffect select;
    public SoundEffect land;
    public SoundEffect jump;
    public SoundEffect bone;
    public SoundEffect alarm1;
    public SoundEffect lever;
    public SoundEffect door;
    public SoundEffect drop;
    public SoundEffect horn;
    public SoundEffect hum;
    public int[] equip = new int[18]
    {
      1,
      1,
      1,
      1,
      1,
      1,
      1,
      1,
      1,
      1,
      1,
      1,
      2,
      1,
      3,
      3,
      2,
      1
    };
    public float roverSpeed = 1f;
    public float roverGrip = 1f;
    public float roverTurn = 0.25f;
    public bool cheats_test = true;
    public Vector3 gemDropPosition;
    public Vector3 gemDropVelocity;
    public float gemDropScale;
    public int gemDropType;
    public string mess = "";
    public int oldgamercount;
    public int oldgamer0;
    public int oldgamer1;
    public int oldgamer2;
    public int oldgamer3;
    public PlayerIndex playnum;
    public StorageDevice device;
    public float rightstickX;
    public float rightstickY;
    public float lefttrigger;
    public float righttrigger;
    public bool rightbumper;
    public bool leftbumper;
    public string[] planetName = new string[10]
    {
      "none",
      "Mercury",
      "Venus",
      "Earth",
      "Mars",
      "Jupiter",
      "Saturn",
      "Uranus",
      "Neptune",
      "Pluto"
    };
    public buildStars Globalstarmap = new buildStars();
    public float vehiclelerp = 1f;
    public Texture2D blankTexture;
    public int poppy;
    public int menutype;
    public Texture2D manmadestars;
    public GraphicsDeviceManager gg;
    public int loadscreenIndex = 1;
    public List<int> loadScreen = new List<int>();
    public Texture2D camedit;
    public Texture2D interfaceBlob;
    public Texture2D starblob;
    public Texture2D messageBlob;
    public Texture2D iconbar;
    public Texture2D hudbuttons;
    public Texture2D helmet1;
    public Texture2D helmet2;
    public Texture2D rooms;
    public Texture2D codeBG;
    public Texture2D gear2;
    public Texture2D buttonOn;
    public Texture2D loadBG;
    public Texture2D entryrgb2;
    public Texture2D entryShad;
    public SoundEffect buttonGong;
    public SoundEffect spinpics;
    public SpriteFont tahoma1;
    public SpriteFont tahoma2;
    public SpriteFont loadfont1;
    public int bitmap = 290;
    public int gridScale = 150;
    public int unit = 289;
    public string body;
    public string scooper;
    public string hauler;
    public string solar;
    public string solarB;
    public string weapon;
    public string rack;
    public string backwheel;
    public string rfjoint;
    public string lfjoint;
    public string rf;
    public string lf;
    public List<string> roverparts = new List<string>();
    public Model roverModel;
    public Model astroModel;
    public Model controllerX;
    public Matrix wheelRollMatrix = Matrix.Identity;
    public Matrix wheelRollMatrix2 = Matrix.Identity;
    public Matrix rackMatrix = Matrix.Identity;
    public Matrix solar1aMatrix = Matrix.Identity;
    public Matrix solar1bMatrix = Matrix.Identity;
    public Matrix scooperMatrix = Matrix.Identity;
    public Matrix bucketMatrix = Matrix.Identity;
    public Matrix binMatrix = Matrix.Identity;
    public ModelBone BackWheelBone;
    public ModelBone leftFrontWheelBone;
    public ModelBone rightFrontWheelBone;
    public ModelBone leftFrontjointBone;
    public ModelBone rightFrontjointBone;
    public ModelBone rackBone;
    public ModelBone haulerBone;
    public ModelBone bodyBone;
    public ModelBone weaponBone;
    public ModelBone scooperBone;
    public ModelBone modelBone_0;
    public ModelBone modelBone_1;
    public Matrix BackWheelTrans;
    public Matrix leftFrontWheelTrans;
    public Matrix rightFrontWheelTrans;
    public Matrix leftFrontjointTrans;
    public Matrix rightFrontjointTrans;
    public Matrix rackTrans;
    public Matrix bodyTrans;
    public Matrix haulerTrans;
    public Matrix weaponTrans;
    public Matrix scooperTrans;
    public Matrix solar1aTrans;
    public Matrix solar1bTrans;
    private Matrix[] origTransforms;
    public string errorline = "";
    public Matrix ScaleMatrix1;
    public Rectangle ScaleRect1;
    public Vector2 diffscaler;
    public float startaspect;
    public float stretch;
    public float xoffset;
    public bool inSpace;
    public bool astroloaded;
    public float startwidth = 1280f;
    public float starthite = 720f;
    public PlayerIndex playerindex;
    private int callback;
    public string stat1 = "";
    public string stat2 = "";
    public string stat3 = "";
    public string stat4 = "";
    public string stat5 = "";
    public string stat6 = "";
    public string stat7 = "";
    public float ar1 = 0.95f;
    public float ar2 = 0.7f;
    private Random rr;
    public int chatIndex;
    public float chatFade;
    public List<ScreenManager.chatty> chatHistory = new List<ScreenManager.chatty>();

    public ScreenManager(bool sentGraphics, int x, int y, Game game, GraphicsDeviceManager gg)
      : base(game)
    {
      this.graphics = gg;
      if (!sentGraphics)
        return;
      this.cardx = x;
      this.cardy = y;
    }

    public override void Initialize()
    {
      base.Initialize();
      this.isInitialized = true;
    }

    private void Form1_KeyDown(object sender, FormClosingEventArgs e) => SteamAPI.Shutdown();

    protected override void LoadContent()
    {
      this.rr = new Random();
      this.trialStart = Stopwatch.GetTimestamp();
      this.steamStart();
      this.cardx = this.graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Width;
      this.cardy = this.graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Height;
      int num1 = 1280;
      int num2 = 0;
      bool flag = false;
      this.resnames = new List<string>();
      this.width = this.cardx;
      this.hite = this.cardy;
      foreach (DisplayMode supportedDisplayMode in this.graphics.GraphicsDevice.Adapter.SupportedDisplayModes)
      {
        if (supportedDisplayMode.Width == num1 && !flag)
        {
          this.width = supportedDisplayMode.Width;
          this.hite = supportedDisplayMode.Height;
          this.resolution = num2;
          flag = true;
        }
        ++num2;
        this.resnames.Add(supportedDisplayMode.Width.ToString() + " by " + (object) supportedDisplayMode.Height);
      }
      this.aspect = (float) this.cardx / (float) this.cardy;
      this.aspectratio = this.aspect / 1.77777f;
      this.chat = new chatbox();
      this.content = this.Game.Content;
      this.content2 = new ContentManager((System.IServiceProvider) this.Game.Services, "ABCDE1");
      this.conModel = new ContentManager((System.IServiceProvider) this.Game.Services, "ABCDE2");
      this.SpriteBatch = new SpriteBatch(this.graphics.GraphicsDevice);
      this.strangers.Clear();
      this.redsuns.Clear();
      this.kickers.Clear();
      this.pileDriverSure = this.content2.Load<SoundEffect>("piledriver");
      this.scree = this.content.Load<SoundEffect>("audio//scree");
      this.xmas = this.content.Load<SoundEffect>("audio//xmas");
      this.cancel = this.content.Load<SoundEffect>("audio//cancel1");
      this.accept = this.content.Load<SoundEffect>("audio//accept1");
      this.equipx = this.content.Load<SoundEffect>("audio//equipon");
      this.wavecomplete = this.content.Load<SoundEffect>("audio//wavecomplete");
      this.achievepop = this.content.Load<SoundEffect>("audio//achieves");
      this.tick = this.content.Load<SoundEffect>("audio//tick");
      this.wound = this.content.Load<Texture2D>("texture//woundTarget");
      this.font3 = this.content2.Load<SpriteFont>("awatermark");
      this.landerfont = this.content2.Load<SpriteFont>("TextureFont1");
      this.font = this.content2.Load<SpriteFont>("ammomedium3");
      this.grungeFont = this.content2.Load<SpriteFont>("ammoLargest");
      this.font2 = this.content.Load<SpriteFont>("font//Font");
      this.lilyFont = this.content.Load<SpriteFont>("font//lilyUPC");
      this.fontsmall = this.content2.Load<SpriteFont>("ammosmall3");
      this.arialfont = this.content2.Load<SpriteFont>("Arial");
      this.scribblefont = this.content2.Load<SpriteFont>("scribbleFont2");
      this.scribblefont2 = this.content.Load<SpriteFont>("font//afont5");
      this.terminal = this.content2.Load<SpriteFont>("deadfont2");
      this.squarefont = this.content2.Load<SpriteFont>("square1");
      this.trophy = new achieve(this);
      this.lobby = new Lobby(this, this.pileDriverSure);
      this.workshop = new Workshop(this);
      this.goldKeys = new goldenkey(this, this.content);
      this.star = this.content.Load<Texture2D>("texture//star");
      this.staroff = this.content.Load<Texture2D>("texture//staroff");
      this.starB = this.content.Load<Texture2D>("texture//starBorder");
      this.certified = this.content.Load<Texture2D>("texture//certified");
      this.overlay = this.content2.Load<Texture2D>("overlay");
      this.menuBlob2 = this.content.Load<Texture2D>("texture//menuBlob3");
      this.blankpaper = this.content.Load<Texture2D>("texture//controls3");
      this.topcorner = new Vector2((float) (640 - this.blankpaper.Width / 2), (float) (370 - this.blankpaper.Height / 2));
      this.whiteTexture = new Texture2D(this.graphics.GraphicsDevice, 1, 1);
      this.redTexture = new Texture2D(this.graphics.GraphicsDevice, 1, 1);
      this.whiteTexture.SetData<Color>(new Color[1]
      {
        Color.White
      });
      this.redTexture.SetData<Color>(new Color[1]
      {
        Color.DarkRed
      });
      this.blackTexture = new Texture2D(this.graphics.GraphicsDevice, 1, 1);
      this.blackTexture.SetData<Color>(new Color[1]
      {
        Color.Black
      });
      this.wallguns[0] = Matrix.CreateScale(2.2f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateRotationY(3.14159226f) * Matrix.CreateRotationZ(0.0f) * Matrix.CreateTranslation(291.5962f, 71.9474258f, 1804.34558f);
      this.wallguns[2] = Matrix.CreateScale(2.38f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateRotationY(3.14159226f) * Matrix.CreateRotationZ(0.0f) * Matrix.CreateTranslation(291.8526f, 41.1326256f, 1804.2345f);
      this.wallguns[4] = Matrix.CreateScale(2.6f) * Matrix.CreateRotationX(0.152077273f) * Matrix.CreateRotationY(3.19815063f) * Matrix.CreateRotationZ(0.00637560943f) * Matrix.CreateTranslation(237.415756f, 67f, 1803.80334f);
      this.wallguns[6] = Matrix.CreateScale(2.01601434f) * Matrix.CreateRotationX(0.08249152f) * Matrix.CreateRotationY(0.0157990921f) * Matrix.CreateRotationZ(0.00130620052f) * Matrix.CreateTranslation(264.234619f, 37.7654953f, 1444.6427f);
      this.wallguns[8] = Matrix.CreateScale(2.50793862f) * Matrix.CreateRotationX(0.101869315f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationZ(0.0f) * Matrix.CreateTranslation(323.015717f, 39.4098854f, 1445.35376f);
      this.wallguns[10] = Matrix.CreateScale(2.30707574f) * Matrix.CreateRotationX(0.133999035f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationZ(0.0f) * Matrix.CreateTranslation(266.287537f, 69.95057f, 1444.93567f);
      this.wallguns[12] = Matrix.CreateScale(2.40376782f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationZ(0.0f) * Matrix.CreateTranslation(339.7893f, 70.4536362f, 1445.09082f);
      this.wallguns[14] = Matrix.CreateScale(2.83508658f) * Matrix.CreateRotationX(0.1f) * Matrix.CreateRotationY(-0.05f) * Matrix.CreateRotationZ(0.0f) * Matrix.CreateTranslation(295.4769f, 113.618713f, 1447.42761f);
      this.wallguns[16] = Matrix.CreateScale(2.3f) * Matrix.CreateRotationX(0.152077273f) * Matrix.CreateRotationY(3.19815063f) * Matrix.CreateRotationZ(0.00637560943f) * Matrix.CreateTranslation(242f, 39f, 1803.80334f);
      this.wallguns[18] = Matrix.CreateScale(2.8f) * Matrix.CreateRotationX(0.08249152f) * Matrix.CreateRotationY(0.0157990921f) * Matrix.CreateRotationZ(0.00130620052f) * Matrix.CreateTranslation(487f, 38f, 1444.6427f);
      this.wallguns[20] = Matrix.CreateScale(2.6f) * Matrix.CreateTranslation(550f, 41f, 1445.25f);
      this.shitContrast = 128;
      this.redContrast = 128;
      this.setBlendState();
      this.resetVideo();
      this.resetAudio();
      this.resetGame();
      foreach (GameScreen screen in this.screens)
        screen.LoadContent();
      this.keyState = Keyboard.GetState();
      if (this.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftShift) || this.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.RightAlt) || this.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.RightShift))
      {
        this.fullscreen = 0;
        this.fullmode = false;
        this.drawViewport = false;
        this.skipsettings = true;
      }
      this.resetGame();
      this.LoadGame(false);
      if (!this.skipsettings)
        this.LoadPrefs();
      this.LoadSavedKeys();
      if (this.bonusweek)
      {
        this.man1 = true;
        this.man2 = true;
        this.FarmerUnlocked = true;
        this.hats[9] = 1;
      }
      this.currentDay = this.curDay;
      this.setupnum = this.resolution;
      if (this.setupnum > this.resnames.Count - 1)
        this.setupnum = 0;
      this.aa = this.aliasing;
      if (!this.skipsettings)
        this.setResolution();
      else
        this.setResolutionSafe();
      this.setgraphics = false;
      this.loadAudio();
      this.audioLoaded = true;
      if (!this.walletLoaded)
        this.loadWallet();
      this.mainTheme = this.content.Load<SoundEffect>("audio\\Corncob");
      this.centerWindow();
      this.bossexplodechoice = this.rr.Next(1, 4);
      this.Game.Deactivated += new EventHandler<EventArgs>(this.DeactivatedEventHandler);
      this.Game.Activated += new EventHandler<EventArgs>(this.ActivatedEventHandler);
      this.basicCrosshair1 = this.content.Load<Texture2D>("crosshair//crosshair1");
      this.basicCrosshair2 = this.content.Load<Texture2D>("crosshair//crosshair1");
      this.basicCrosshair3 = this.content.Load<Texture2D>("crosshair//crosshair1");
      this.basicCrosshair4 = this.content.Load<Texture2D>("crosshair//crosshair1");
      this.getLoadOut();
      this.woundRect = new Rectangle[17];
      this.woundRect[0] = new Rectangle(0, 0, 64, 64);
      this.woundRect[1] = new Rectangle(0, 0, 64, 64);
      this.woundRect[2] = new Rectangle(64, 0, 64, 64);
      this.woundRect[3] = new Rectangle(128, 0, 64, 64);
      this.woundRect[4] = new Rectangle(192, 0, 64, 64);
      this.woundRect[5] = new Rectangle(0, 64, 64, 64);
      this.woundRect[6] = new Rectangle(64, 64, 64, 64);
      this.woundRect[7] = new Rectangle(128, 64, 64, 64);
      this.woundRect[8] = new Rectangle(192, 64, 64, 64);
      this.woundRect[9] = new Rectangle(0, 128, 64, 64);
      this.woundRect[10] = new Rectangle(64, 128, 64, 64);
      this.woundRect[11] = new Rectangle(128, 128, 64, 64);
      this.woundRect[12] = new Rectangle(192, 128, 64, 64);
      this.woundRect[13] = new Rectangle(0, 192, 64, 64);
      this.woundRect[14] = new Rectangle(64, 192, 64, 64);
      this.woundRect[15] = new Rectangle(128, 192, 64, 64);
      this.woundRect[16] = new Rectangle(192, 192, 64, 64);
    }

    private void keymaker(ref Microsoft.Xna.Framework.Input.Keys origkey, string line)
    {
      try
      {
        char[] chArray = new char[2]{ ' ', '\t' };
        string[] strArray = line.Split(chArray);
        origkey = (Microsoft.Xna.Framework.Input.Keys) Enum.Parse(typeof (Microsoft.Xna.Framework.Input.Keys), strArray[0]);
      }
      catch
      {
        return;
      }
    }

    public void getLoadOut()
    {
      string path1 = "Content\\crosshair\\1a.block";
      string path2 = "Content\\crosshair\\2a.block";
      string path3 = "Content\\crosshair\\3a.block";
      this.crosshair1.Clear();
      this.tempcross1.texture = this.basicCrosshair1;
      this.tempcross1.type = 1;
      this.tempcross1.legal = true;
      this.crosshair1.Add(this.tempcross1);
      this.tempcross2.type = 0;
      this.tempcross2.legal = true;
      if (File.Exists(path1))
        this.tempcross2.legal = false;
      this.tempcross2.texture = this.basicCrosshair2;
      this.crosshair1.Add(this.tempcross2);
      this.tempcross3.type = 0;
      this.tempcross3.legal = true;
      if (File.Exists(path2))
        this.tempcross3.legal = false;
      this.tempcross3.texture = this.basicCrosshair3;
      this.crosshair1.Add(this.tempcross3);
      this.tempcross4.type = 0;
      this.tempcross4.legal = true;
      if (File.Exists(path3))
        this.tempcross4.legal = false;
      this.tempcross4.texture = this.basicCrosshair4;
      this.crosshair1.Add(this.tempcross4);
      string str1 = "Content\\crosshair";
      for (int index = 1; index < 4; ++index)
      {
        string str2 = index.ToString() + "a.png";
        if (File.Exists(str1 + "\\" + str2))
        {
          try
          {
            using (FileStream fileStream = new FileStream(str1 + "\\" + str2, FileMode.Open))
            {
              this.crosshair1[index].type = 1;
              this.crosshair1[index].texture = Texture2D.FromStream(this.GraphicsDevice, (Stream) fileStream);
            }
          }
          catch
          {
          }
        }
      }
    }

    public void loadCrosshairC()
    {
      this.crosshairC.Clear();
      string path1 = "CrossHairs";
      string path2 = "UploadData";
      if (!Directory.Exists(path1))
        Directory.CreateDirectory(path1);
      if (!Directory.Exists(path2))
        Directory.CreateDirectory(path2);
      foreach (string enumerateFile in Directory.EnumerateFiles(path1, "*.png", SearchOption.TopDirectoryOnly))
      {
        string str = enumerateFile.Substring(path1.Length + 1);
        if (File.Exists(path1 + "\\" + str))
        {
          using (FileStream fileStream = new FileStream(path1 + "\\" + str, FileMode.Open))
            this.crosshairC.Add(Texture2D.FromStream(this.GraphicsDevice, (Stream) fileStream));
        }
      }
    }

    public void saveLoadOut()
    {
      string path1 = "Content\\crosshair\\1a.png";
      string path2 = "Content\\crosshair\\2a.png";
      string path3 = "Content\\crosshair\\3a.png";
      string path4 = "Content\\crosshair\\1a.block";
      string path5 = "Content\\crosshair\\2a.block";
      string path6 = "Content\\crosshair\\3a.block";
      if (File.Exists(path1))
        File.Delete(path1);
      if (File.Exists(path2))
        File.Delete(path2);
      if (File.Exists(path3))
        File.Delete(path3);
      if (File.Exists(path4))
        File.Delete(path4);
      if (File.Exists(path5))
        File.Delete(path5);
      if (File.Exists(path6))
        File.Delete(path6);
      if (this.crosshair1[1].type == 1)
      {
        using (Stream stream = (Stream) File.OpenWrite(path1))
          this.crosshair1[1].texture.SaveAsPng(stream, this.crosshair1[1].texture.Width, this.crosshair1[1].texture.Height);
        if (!this.crosshair1[1].legal)
          File.Create(path4);
      }
      if (this.crosshair1[2].type == 1)
      {
        using (Stream stream = (Stream) File.OpenWrite(path2))
          this.crosshair1[2].texture.SaveAsPng(stream, this.crosshair1[2].texture.Width, this.crosshair1[2].texture.Height);
        if (!this.crosshair1[2].legal)
          File.Create(path5);
      }
      if (this.crosshair1[3].type == 1)
      {
        using (Stream stream = (Stream) File.OpenWrite(path3))
          this.crosshair1[3].texture.SaveAsPng(stream, this.crosshair1[3].texture.Width, this.crosshair1[3].texture.Height);
        if (!this.crosshair1[3].legal)
          File.Create(path6);
      }
      this.crossIndex = 0;
      this.nextLoadout();
    }

    public void nextLoadout()
    {
      ++this.crossIndex;
      if (this.crossIndex > 3)
      {
        this.crossIndex = 0;
      }
      else
      {
        if (this.crossIndex == 1 && this.crosshair1[1].type == 0)
          this.crossIndex = 2;
        if (this.crossIndex == 2 && this.crosshair1[2].type == 0)
          this.crossIndex = 3;
        if (this.crossIndex != 3 || this.crosshair1[3].type != 0)
          return;
        this.crossIndex = 0;
      }
    }

    public string LoadSavedKeys()
    {
      string path1 = "SAVES//savekeys";
      if (File.Exists(path1))
      {
        try
        {
          using (StreamReader streamReader = new StreamReader((Stream) File.Open(path1, FileMode.Open)))
          {
            this.keymaker(ref this.escape_key, streamReader.ReadLine());
            this.keymaker(ref this.w_key, streamReader.ReadLine());
            this.keymaker(ref this.s_key, streamReader.ReadLine());
            this.keymaker(ref this.a_key, streamReader.ReadLine());
            this.keymaker(ref this.d_key, streamReader.ReadLine());
            this.keymaker(ref this.space_key, streamReader.ReadLine());
            this.keymaker(ref this.leftshift_key, streamReader.ReadLine());
            this.keymaker(ref this.r_key, streamReader.ReadLine());
            this.keymaker(ref this.x_key, streamReader.ReadLine());
            this.keymaker(ref this.q_key, streamReader.ReadLine());
            this.keymaker(ref this.e_key, streamReader.ReadLine());
            this.keymaker(ref this.f_key, streamReader.ReadLine());
            this.keymaker(ref this.one_key, streamReader.ReadLine());
            this.keymaker(ref this.two_key, streamReader.ReadLine());
            this.keymaker(ref this.three_key, streamReader.ReadLine());
            this.keymaker(ref this.four_key, streamReader.ReadLine());
            this.keymaker(ref this.f1_key, streamReader.ReadLine());
            this.keymaker(ref this.f2_key, streamReader.ReadLine());
            this.keymaker(ref this.f3_key, streamReader.ReadLine());
            this.keymaker(ref this.tab_key, streamReader.ReadLine());
            this.keymaker(ref this.up_key, streamReader.ReadLine());
            this.keymaker(ref this.down_key, streamReader.ReadLine());
            this.keymaker(ref this.left_key, streamReader.ReadLine());
            this.keymaker(ref this.lmb_key, streamReader.ReadLine());
            this.keymaker(ref this.rmb_key, streamReader.ReadLine());
            this.keymaker(ref this.mmb_key, streamReader.ReadLine());
            this.keymaker(ref this.but1_key, streamReader.ReadLine());
            this.keymaker(ref this.but2_key, streamReader.ReadLine());
            this.keymaker(ref this.t_key, streamReader.ReadLine());
            this.keymaker(ref this.enter_key, streamReader.ReadLine());
            this.keymaker(ref this.plus_key, streamReader.ReadLine());
            streamReader.Close();
            streamReader.Dispose();
            return "OKAY";
          }
        }
        catch
        {
          return "FAIL";
        }
      }
      else
      {
        using (IsolatedStorageFile store = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, (System.Type) null, (System.Type) null))
        {
          string path2 = "savekeys";
          if (!store.FileExists(path2))
            return "nofile";
          try
          {
            using (StreamReader streamReader = new StreamReader((Stream) store.OpenFile(path2, FileMode.Open)))
            {
              this.keymaker(ref this.escape_key, streamReader.ReadLine());
              this.keymaker(ref this.w_key, streamReader.ReadLine());
              this.keymaker(ref this.s_key, streamReader.ReadLine());
              this.keymaker(ref this.a_key, streamReader.ReadLine());
              this.keymaker(ref this.d_key, streamReader.ReadLine());
              this.keymaker(ref this.space_key, streamReader.ReadLine());
              this.keymaker(ref this.leftshift_key, streamReader.ReadLine());
              this.keymaker(ref this.r_key, streamReader.ReadLine());
              this.keymaker(ref this.x_key, streamReader.ReadLine());
              this.keymaker(ref this.q_key, streamReader.ReadLine());
              this.keymaker(ref this.e_key, streamReader.ReadLine());
              this.keymaker(ref this.f_key, streamReader.ReadLine());
              this.keymaker(ref this.one_key, streamReader.ReadLine());
              this.keymaker(ref this.two_key, streamReader.ReadLine());
              this.keymaker(ref this.three_key, streamReader.ReadLine());
              this.keymaker(ref this.four_key, streamReader.ReadLine());
              this.keymaker(ref this.f1_key, streamReader.ReadLine());
              this.keymaker(ref this.f2_key, streamReader.ReadLine());
              this.keymaker(ref this.f3_key, streamReader.ReadLine());
              this.keymaker(ref this.tab_key, streamReader.ReadLine());
              this.keymaker(ref this.up_key, streamReader.ReadLine());
              this.keymaker(ref this.down_key, streamReader.ReadLine());
              this.keymaker(ref this.left_key, streamReader.ReadLine());
              this.keymaker(ref this.lmb_key, streamReader.ReadLine());
              this.keymaker(ref this.rmb_key, streamReader.ReadLine());
              this.keymaker(ref this.mmb_key, streamReader.ReadLine());
              this.keymaker(ref this.but1_key, streamReader.ReadLine());
              this.keymaker(ref this.but2_key, streamReader.ReadLine());
              this.keymaker(ref this.t_key, streamReader.ReadLine());
              this.keymaker(ref this.enter_key, streamReader.ReadLine());
              streamReader.Close();
              streamReader.Dispose();
              return "OKAY";
            }
          }
          catch
          {
            return "FAIL";
          }
        }
      }
    }

    public bool SaveSavedKeys()
    {
      string path = "SAVES//savekeys";
      if (!Directory.Exists("SAVES"))
        Directory.CreateDirectory("SAVES");
      try
      {
        using (StreamWriter streamWriter = new StreamWriter((Stream) File.Open(path, FileMode.Create)))
        {
          streamWriter.WriteLine(this.escape_key.ToString());
          streamWriter.WriteLine(this.w_key.ToString());
          streamWriter.WriteLine(this.s_key.ToString());
          streamWriter.WriteLine(this.a_key.ToString());
          streamWriter.WriteLine(this.d_key.ToString());
          streamWriter.WriteLine(this.space_key.ToString());
          streamWriter.WriteLine(this.leftshift_key.ToString());
          streamWriter.WriteLine(this.r_key.ToString());
          streamWriter.WriteLine(this.x_key.ToString());
          streamWriter.WriteLine(this.q_key.ToString());
          streamWriter.WriteLine(this.e_key.ToString());
          streamWriter.WriteLine(this.f_key.ToString());
          streamWriter.WriteLine(this.one_key.ToString());
          streamWriter.WriteLine(this.two_key.ToString());
          streamWriter.WriteLine(this.three_key.ToString());
          streamWriter.WriteLine(this.four_key.ToString());
          streamWriter.WriteLine(this.f1_key.ToString());
          streamWriter.WriteLine(this.f2_key.ToString());
          streamWriter.WriteLine(this.f3_key.ToString());
          streamWriter.WriteLine(this.tab_key.ToString());
          streamWriter.WriteLine(this.up_key.ToString());
          streamWriter.WriteLine(this.down_key.ToString());
          streamWriter.WriteLine(this.left_key.ToString());
          streamWriter.WriteLine(this.lmb_key.ToString());
          streamWriter.WriteLine(this.rmb_key.ToString());
          streamWriter.WriteLine(this.mmb_key.ToString());
          streamWriter.WriteLine(this.but1_key.ToString());
          streamWriter.WriteLine(this.but2_key.ToString());
          streamWriter.WriteLine(this.t_key.ToString());
          streamWriter.WriteLine(this.enter_key.ToString());
          streamWriter.WriteLine(this.plus_key.ToString());
          streamWriter.Close();
          streamWriter.Dispose();
          return true;
        }
      }
      catch
      {
        return false;
      }
    }

    public void steamStart() => SteamAPI.Init();

    public void exitmyGame()
    {
      SteamAPI.Shutdown();
      this.Game.Exit();
    }

    public void loadSpaceFarm()
    {
      this.farmspacecollide = this.conModel.Load<Model>("farm01spaceCollide");
      this.farmBuildingspace = this.conModel.Load<Model>("farm01space");
      this.texture2D_0 = this.content.Load<Texture2D>("texture//buildingRGB");
      this.buildingshadspace = this.content.Load<Texture2D>("texture//buildingShadowSpace");
    }

    public void mainModels()
    {
      this.water = this.conModel.Load<Model>("water");
      this.boar1basicModel = this.conModel.Load<Model>("boarWalk_reduct");
      this.boarSkel = this.content.Load<Model>("npc\\boarSkel");
      this.charModel = this.conModel.Load<Model>("boarCharred");
      this.zombieModel = this.conModel.Load<Model>("boarCharred");
      this.cube = this.conModel.Load<Model>("cube");
      this.decal = this.conModel.Load<Model>("outline2");
      this.decalb = this.conModel.Load<Model>("outline2b");
      this.decal2 = this.conModel.Load<Model>("outline3");
      this.biteDecal = this.conModel.Load<Model>("outlineBites");
      this.explosionDecal = this.conModel.Load<Model>("outlineExplode");
      this.fireballDecal = this.conModel.Load<Model>("outlineFireball");
      this.fireballDecal2 = this.conModel.Load<Model>("outlineFireballblue");
      this.buttonModel = this.conModel.Load<Model>("button");
      this.mountain = this.conModel.Load<Model>("mountain");
      this.gunMuzzle = this.conModel.Load<Model>("gunMuzzle");
      this.gunBlast = this.conModel.Load<Model>("gunblast");
      this.blueLaser = this.conModel.Load<Model>("tracer");
      this.shellPack[0] = this.conModel.Load<Model>("indieShell");
      this.shellPack[2] = this.conModel.Load<Model>("45shell2");
      this.shellPack[4] = this.conModel.Load<Model>("Wshell");
      this.shellPack[6] = this.conModel.Load<Model>("AKshell2");
      this.shellPack[8] = this.conModel.Load<Model>("shotgunShell");
      this.shellPack[10] = this.conModel.Load<Model>("m16shell");
      this.shellPack[12] = this.conModel.Load<Model>("uziShell");
      this.shellPack[14] = this.conModel.Load<Model>("AKshell2");
      this.shellPack[16] = this.conModel.Load<Model>("45shell2");
      this.shellPack[18] = this.conModel.Load<Model>("m16shell");
      this.shellPack[20] = this.conModel.Load<Model>("SCARshell");
      this.gunPack = this.conModel.Load<Model>("gunPack");
      this.hatPack = this.conModel.Load<Model>("hatPack");
      this.grass = this.conModel.Load<Model>("farmGrass");
      this.trees = this.conModel.Load<Model>("farmTrees");
      this.farmTriangles = this.conModel.Load<Model>("farm01triangle");
      this.farmTriangles2 = this.conModel.Load<Model>("farm02triangle");
      this.farmTriangles3 = this.conModel.Load<Model>("farm03triangle");
      this.barnTriangles = this.conModel.Load<Model>("barn01triangle");
      this.doorTriangles = this.conModel.Load<Model>("door01triangle");
      this.farmBuilding = this.conModel.Load<Model>("farm01");
      this.farmBuilding2 = this.conModel.Load<Model>("farm02");
      this.farmBuilding3 = this.conModel.Load<Model>("farm03");
      this.barnBuilding = this.conModel.Load<Model>("barn01");
      this.heightmodel = this.conModel.Load<Model>("farm01collide");
      this.heightmodel2 = this.conModel.Load<Model>("farm01collide2");
      this.tunnel1 = this.conModel.Load<Model>("tunnelA");
      this.tunnelTriangle = this.conModel.Load<Model>("tunnelAtriangle");
      this.tunnelheights = this.conModel.Load<Model>("tunnelAcollide");
      this.blasts = this.content.Load<Texture2D>("texture//blasts");
      this.burster = this.content.Load<Texture2D>("texture//burster");
      this.button = this.content.Load<Texture2D>("texture//button");
      this.crosshair = this.content.Load<Texture2D>("texture//crosshair");
      this.electrify = this.content.Load<Texture2D>("texture//electrify");
      this.muzzles = this.content.Load<Texture2D>("texture//muzzles");
      this.overlayStats = this.content.Load<Texture2D>("texture//overlayStats");
      this.overlayStats2 = this.content.Load<Texture2D>("texture//overlayStats2");
      this.reflectionMap = this.content.Load<Texture2D>("texture//reflectionMap");
      this.spotTexture = this.content.Load<Texture2D>("texture//spotTexture");
      this.waterTexture = this.content.Load<Texture2D>("texture//waterTexture");
      this.loadMainModels = true;
    }

    public void loadBoss()
    {
      this.bossAll = this.conModel.Load<Model>("bossAll");
      this.bossLoaded = true;
    }

    public void loadWallet()
    {
      this.landoWallet = this.content.Load<Texture2D>("texture\\landoWallet");
      this.johnWallet = this.content.Load<Texture2D>("texture\\johnnyWallet");
      this.farmerWallet = this.content.Load<Texture2D>("texture\\farmerWallet");
      this.skellyWallet = this.content.Load<Texture2D>("texture\\skelWallet");
      this.daisyWallet = this.content.Load<Texture2D>("texture\\daisyWallet");
      this.vikingWallet = this.content.Load<Texture2D>("texture\\vikingWallet");
      this.deadWallet = this.content.Load<Texture2D>("texture\\deadWallet");
      this.robotWallet = this.content.Load<Texture2D>("texture\\robotWallet");
      this.golemWallet = this.content.Load<Texture2D>("texture\\golemWallet");
      this.astroWallet = this.content.Load<Texture2D>("texture\\astroWallet");
      this.johnnyWallet = this.johnWallet;
      this.controller = this.content.Load<Texture2D>("texture//controls");
      this.instructions = this.content.Load<Texture2D>("texture//instructions");
      this.page1 = this.content.Load<Texture2D>("texture//page1");
      this.page2 = this.content.Load<Texture2D>("texture//page2");
      this.page3 = this.content.Load<Texture2D>("texture//page3");
      this.page4 = this.content.Load<Texture2D>("texture//page4");
      this.page5 = this.content.Load<Texture2D>("texture//page5");
      this.page6 = this.content.Load<Texture2D>("texture//page6");
      this.page7 = this.content.Load<Texture2D>("texture//page7");
      this.paper1 = this.content.Load<Texture2D>("texture//paper1");
      this.walletLoaded = true;
    }

    public void loadTitles()
    {
      this.titleBG2 = this.content.Load<Texture2D>("texture//titleBG3");
      this.titleBG = this.content.Load<Texture2D>("texture//titleBG");
      this.titleFaces = this.content.Load<Texture2D>("texture//titleFaces");
      this.titleCharsSingle = this.content.Load<Texture2D>("texture//titleCharsSingle");
      this.titleCharsGraphics = this.content.Load<Texture2D>("texture//titleCharsGraphics");
      this.titleHeaderTunnelDays = this.content.Load<Texture2D>("texture//titleHeaderTunnelDays");
      this.titleHeaderBloodBacon = this.content.Load<Texture2D>("texture//titleHeaderBloodBacon");
      this.titleHeaderBloodBaconB = this.content.Load<Texture2D>("texture//titleHeaderBloodBaconB");
      this.titleHeaderBloodBaconC = this.content.Load<Texture2D>("texture//titleHeaderBloodBaconC");
      this.titleHeaderWorkshop = this.content.Load<Texture2D>("texture//titleHeaderWorkshop");
      this.titleHeaderWorkshop2 = this.content.Load<Texture2D>("texture//titleHeaderWorkshop2");
      this.titleHeaderWorkshopPublish = this.content.Load<Texture2D>("texture//titleHeaderWorkshopPublish");
      this.titleHeaderWorkshopPublish2 = this.content.Load<Texture2D>("texture//titleHeaderWorkshopPublish2");
      this.titleHeaderDiary = this.content.Load<Texture2D>("texture//titleHeaderDiary");
      this.titleHeaderSecrets = this.content.Load<Texture2D>("texture//titleHeaderSecrets");
      this.titleHeaderMore = this.content.Load<Texture2D>("texture//titleHeaderMore");
      this.titleheaderSettings = this.content.Load<Texture2D>("texture//titleHeaderSettings");
      this.titleHeaderLobbies = this.content.Load<Texture2D>("texture//titleHeaderLobbies");
      this.titleHeaderLobbies2 = this.content.Load<Texture2D>("texture//titleHeaderLobbies2");
      this.titleHeaderMultiplayer = this.content.Load<Texture2D>("texture//titleHeaderMultiplayer");
      this.texture2D_3 = this.content.Load<Texture2D>("texture//titleHeader6Multiplayer");
      this.texture2D_2 = this.content.Load<Texture2D>("texture//titleHeader4Multiplayer");
      this.texture2D_1 = this.content.Load<Texture2D>("texture//titleHeader2player");
      this.titleHeaderJoin = this.content.Load<Texture2D>("texture//titleHeaderJoin");
      this.titleCreditBlank = this.content.Load<Texture2D>("texture//titleCreditBlank");
      this.titleCredit1 = this.content.Load<Texture2D>("texture//titleCredit1");
      this.titleCredit2 = this.content.Load<Texture2D>("texture//titleCredit2");
      this.titleHeaderAudio = this.content.Load<Texture2D>("texture//titleHeaderAudio");
      this.titleHeaderVideos = this.content.Load<Texture2D>("texture//titleHeaderVideos");
      this.titleHeaderControls = this.content.Load<Texture2D>("texture//titleHeaderControls");
      this.titleFrame = this.content.Load<Texture2D>("texture//titleFrame");
      this.titleTrailer = this.content.Load<Texture2D>("texture//titleTrailer");
      this.titlesLoaded = true;
    }

    public void loadFarmer()
    {
      this.farmerModel = this.conModel.Load<Model>("farmerWait1");
      this.farmerModelskull = this.conModel.Load<Model>("farmerWait1skull");
      this.farmerTexture = this.content.Load<Texture2D>("texture//Farmer01");
      this.whiteNPCModel = this.content.Load<Model>("boss//jonWalk2");
      this.whiteNPCnoarms = this.conModel.Load<Model>("jonWalknoarms");
      this.whiteNPCTexture = this.content.Load<Texture2D>("texture//jon6");
      this.texture2D_13 = this.content.Load<Texture2D>("texture//jon6");
      this.whiteNPCdead = this.content.Load<Texture2D>("texture//jonDead2");
      this.whiteNPCTextureGreen2 = this.content.Load<Texture2D>("texture//jon6green2");
      this.blackNPCModel = this.conModel.Load<Model>("blackWalk2");
      this.blackNPCnoarms = this.conModel.Load<Model>("blackWalknoarms");
      this.blackNPCTexture = this.content.Load<Texture2D>("texture//Black2");
      this.texture2D_4 = this.content.Load<Texture2D>("texture//Black2");
      this.blackNPCdead = this.content.Load<Texture2D>("texture//jonDead2");
      this.texture2D_14 = this.content.Load<Texture2D>("texture//jon6green3");
      this.farmerNPCModel = this.conModel.Load<Model>("farmerWalk2");
      this.farmerNPCnoarms = this.conModel.Load<Model>("farmerWalknoarms");
      this.farmerNPCTexture = this.content.Load<Texture2D>("texture//farmer6");
      this.texture2D_5 = this.content.Load<Texture2D>("texture//farmer6");
      this.farmerGreen = this.content.Load<Texture2D>("texture//FarmerGreen");
      this.farmerDead = this.content.Load<Texture2D>("texture//jonDead");
      this.skelNPCmodel = this.conModel.Load<Model>("crackWalk1");
      this.skelNPCnoarms = this.conModel.Load<Model>("crackWalk1noarms");
      this.skelNPCTexture = this.content.Load<Texture2D>("texture//skel1");
      this.texture2D_6 = this.content.Load<Texture2D>("texture//skel1");
      this.skelGreen = this.content.Load<Texture2D>("texture//skelGreen");
      this.skelDead = this.content.Load<Texture2D>("texture//skelDead");
      this.daisyNPCmodel = this.conModel.Load<Model>("girlWalk1");
      this.daisyNPCnoarms = this.conModel.Load<Model>("girlWalk1noarms");
      this.daisyNPCTexture = this.content.Load<Texture2D>("texture//daisy7orig");
      this.texture2D_7 = this.content.Load<Texture2D>("texture//daisy7orig");
      this.daisyGreen = this.content.Load<Texture2D>("texture//daisyBlue");
      this.daisyDead = this.content.Load<Texture2D>("texture//jonDead");
      this.vikingNPCmodel = this.conModel.Load<Model>("vikingWalk1");
      this.vikingNPCnoarms = this.conModel.Load<Model>("vikingWalknoarms");
      this.vikingNPCTexture = this.content.Load<Texture2D>("texture//viking");
      this.texture2D_8 = this.content.Load<Texture2D>("texture//viking");
      this.vikingGreen = this.content.Load<Texture2D>("texture//vikingBlue");
      this.vikingDead = this.content.Load<Texture2D>("texture//vikingdead");
      this.ghostNPCmodel = this.conModel.Load<Model>("ghostWalk1");
      this.ghostNPCTexture = this.content.Load<Texture2D>("texture//deather");
      this.strawNPCModel = this.conModel.Load<Model>("strawWalk1");
      this.strawNPCnoarms = this.conModel.Load<Model>("strawWalk1noarms");
      this.strawNPCTexture = this.content.Load<Texture2D>("texture//straw2");
      this.texture2D_9 = this.content.Load<Texture2D>("texture//straw2");
      this.strawGreen = this.content.Load<Texture2D>("texture//strawGreen");
      this.strawDead = this.content.Load<Texture2D>("texture//strawDead");
      this.robotNPCModel = this.conModel.Load<Model>("robotWalk2");
      this.robotNPCnoarms = this.conModel.Load<Model>("robotNoarms");
      this.robotNPCTexture = this.content.Load<Texture2D>("texture//Robot2");
      this.texture2D_10 = this.content.Load<Texture2D>("texture//Robot2");
      this.robotGreen = this.content.Load<Texture2D>("texture//Robot2Green");
      this.robotDead = this.content.Load<Texture2D>("texture//Robot2Dead");
      this.golemNPCModel = this.conModel.Load<Model>("golemWalk1");
      this.golemNPCnoarms = this.conModel.Load<Model>("golemWalk1noarms");
      this.golemNPCTexture = this.content.Load<Texture2D>("texture//golem1");
      this.texture2D_11 = this.content.Load<Texture2D>("texture//golem1");
      this.golemGreen = this.content.Load<Texture2D>("texture//golemGreen");
      this.golemDead = this.content.Load<Texture2D>("texture//golemDead");
      this.astroNPCModel = this.conModel.Load<Model>("astroWalk2");
      this.astroNPCnoarms = this.conModel.Load<Model>("astroWalknoarms");
      this.astroNPCTexture = this.content.Load<Texture2D>("texture//Astro2");
      this.texture2D_12 = this.content.Load<Texture2D>("texture//Astro2");
      this.astroGreen = this.content.Load<Texture2D>("texture//AstroGreen");
      this.astroDead = this.content.Load<Texture2D>("texture//AstroDead");
    }

    public void loadBigModel()
    {
    }

    public void loadModels()
    {
      this.pigAll = this.conModel.Load<Model>("cuttyAll");
      this.pigModel = this.conModel.Load<Model>("cuttyWalk");
    }

    public void loadAudio()
    {
      this.tada3 = this.content.Load<SoundEffect>("astro\\Audio\\tadar3");
      this.grow = this.content.Load<SoundEffect>("astro\\Audio\\grow");
      this.jot1 = this.content.Load<SoundEffect>("audio\\pageturn");
      this.jot2 = this.content.Load<SoundEffect>("audio\\jot");
      this.drip = this.content.Load<SoundEffect>("audio\\drip");
      this.spinpics = this.content.Load<SoundEffect>("audio\\spinpics");
      this.menuclick = this.content.Load<SoundEffect>("audio\\menuClick");
      this.cashout = this.content.Load<SoundEffect>("audio\\cashout2");
      this.scribble = this.content.Load<SoundEffect>("audio\\scrib1");
      this.piledriver = this.content.Load<SoundEffect>("audio\\piledriver");
      this.report = this.content.Load<SoundEffect>("audio\\report2");
      this.gamestart = this.content.Load<SoundEffect>("audio\\gamestart3");
      this.ding = this.content.Load<SoundEffect>("audio\\ding");
      this.fireworks = this.content.Load<SoundEffect>("audio\\fireworks");
      this.fireworks2 = this.content.Load<SoundEffect>("audio\\fireworks2");
      this.cocking[0] = this.content.Load<SoundEffect>("audio\\gunCock");
      this.cocking[2] = this.content.Load<SoundEffect>("audio\\gunCock2");
      this.cocking[4] = this.content.Load<SoundEffect>("audio\\gunCock2");
      this.cocking[6] = this.content.Load<SoundEffect>("audio\\akCock");
      this.cocking[8] = this.content.Load<SoundEffect>("audio\\shotgunReload1");
      this.cocking[10] = this.content.Load<SoundEffect>("audio\\m16Cock");
      this.cocking[12] = this.content.Load<SoundEffect>("audio\\smgCock");
      this.cocking[14] = this.content.Load<SoundEffect>("audio\\rocketReload");
      this.cocking[16] = this.content.Load<SoundEffect>("audio\\paintballCock");
      this.cocking[18] = this.content.Load<SoundEffect>("audio\\p90Cock");
      this.cocking[20] = this.content.Load<SoundEffect>("audio\\scarCock");
      this.gunFire[0] = this.content.Load<SoundEffect>("audio\\indiePistol2");
      this.gunFire[2] = this.content.Load<SoundEffect>("audio\\pistol4");
      this.gunFire[4] = this.content.Load<SoundEffect>("audio\\pistolsilent");
      this.gunFire[6] = this.content.Load<SoundEffect>("audio\\ak7");
      this.gunFire[8] = this.content.Load<SoundEffect>("audio\\shotgunFire1");
      this.gunFire[10] = this.content.Load<SoundEffect>("audio\\m16a3");
      this.gunFire[12] = this.content.Load<SoundEffect>("audio\\smg5");
      this.gunFire[14] = this.content.Load<SoundEffect>("audio\\mirvfire");
      this.gunFire[16] = this.content.Load<SoundEffect>("audio\\paintballFire");
      this.gunFire[18] = this.content.Load<SoundEffect>("audio\\p90double");
      this.gunFire[20] = this.content.Load<SoundEffect>("audio\\scar1");
      this.gunMuffle[0] = this.content.Load<SoundEffect>("audio\\indiePistolmuffle");
      this.gunMuffle[2] = this.content.Load<SoundEffect>("audio\\pistolMuffle2");
      this.gunMuffle[4] = this.content.Load<SoundEffect>("audio\\pistolsilent2");
      this.gunMuffle[6] = this.content.Load<SoundEffect>("audio\\ak1");
      this.gunMuffle[8] = this.content.Load<SoundEffect>("audio\\shotgunFire1");
      this.gunMuffle[10] = this.content.Load<SoundEffect>("audio\\m16b");
      this.gunMuffle[12] = this.content.Load<SoundEffect>("audio\\smgfire1");
      this.gunMuffle[14] = this.content.Load<SoundEffect>("audio\\m16b");
      this.gunMuffle[16] = this.content.Load<SoundEffect>("audio\\paintballFire2");
      this.gunMuffle[18] = this.content.Load<SoundEffect>("audio\\p90bang");
      this.gunMuffle[20] = this.content.Load<SoundEffect>("audio\\scar7");
      this.gunDry[0] = this.content.Load<SoundEffect>("audio\\indieEmpty");
      this.gunDry[2] = this.content.Load<SoundEffect>("audio\\coltdry2");
      this.gunDry[4] = this.content.Load<SoundEffect>("audio\\coltdry2");
      this.gunDry[6] = this.content.Load<SoundEffect>("audio\\ak_dry");
      this.gunDry[8] = this.content.Load<SoundEffect>("audio\\shotgundry");
      this.gunDry[10] = this.content.Load<SoundEffect>("audio\\m16dry");
      this.gunDry[12] = this.content.Load<SoundEffect>("audio\\shotgundry");
      this.gunDry[14] = this.content.Load<SoundEffect>("audio\\mirvDry");
      this.gunDry[16] = this.content.Load<SoundEffect>("audio\\m16dry");
      this.gunDry[18] = this.content.Load<SoundEffect>("audio\\ak_dry");
      this.gunDry[20] = this.content.Load<SoundEffect>("audio\\scarDry");
      this.shellSound[0] = this.content.Load<SoundEffect>("audio\\shellHit");
      this.shellSound[2] = this.content.Load<SoundEffect>("audio\\shellHit");
      this.shellSound[4] = this.content.Load<SoundEffect>("audio\\shellhit4");
      this.shellSound[6] = this.content.Load<SoundEffect>("audio\\shell2Hit");
      this.shellSound[8] = this.content.Load<SoundEffect>("audio\\shellhit3");
      this.shellSound[10] = this.content.Load<SoundEffect>("audio\\shell2Hit");
      this.shellSound[12] = this.content.Load<SoundEffect>("audio\\shell2Hit");
      this.shellSound[14] = this.content.Load<SoundEffect>("audio\\shell2Hit");
      this.shellSound[16] = this.content.Load<SoundEffect>("audio\\shell2Hit");
      this.shellSound[18] = this.content.Load<SoundEffect>("audio\\shell2Hit");
      this.shellSound[20] = this.content.Load<SoundEffect>("audio\\shellHit5");
      this.shotgunPump = this.content.Load<SoundEffect>("audio\\shotgunPump");
      this.bonepop = this.content.Load<SoundEffect>("audio\\bonepop");
      this.chomp2 = this.content.Load<SoundEffect>("audio\\chomp1");
      this.dieyell = this.content.Load<SoundEffect>("audio\\death");
      this.cuttygouge = this.content.Load<SoundEffect>("audio\\cuttyGouge2");
      this.cuttyWave = this.content.Load<SoundEffect>("audio\\cuttyGouge4");
      this.buzz = this.content.Load<SoundEffect>("audio\\buzz");
      this.steps = new SoundEffect[6];
      this.steps[0] = this.content.Load<SoundEffect>("audio\\dirtStep3");
      this.steps[1] = this.content.Load<SoundEffect>("audio\\dirtStep4");
      this.steps[2] = this.content.Load<SoundEffect>("audio\\dirtStep5");
      this.steps[3] = this.content.Load<SoundEffect>("audio\\dirtStep6");
      this.steps[4] = this.content.Load<SoundEffect>("audio\\dirtStep7");
      this.steps[5] = this.content.Load<SoundEffect>("audio\\dirtStep8");
      this.crickets = this.content.Load<SoundEffect>("audio\\crickets").CreateInstance();
      this.crickets.IsLooped = true;
      this.pigExplode = new SoundEffect[4];
      this.pigExplode[0] = this.content.Load<SoundEffect>("audio\\pigExplode1");
      this.pigExplode[1] = this.content.Load<SoundEffect>("audio\\pigExplode2");
      this.pigExplode[2] = this.content.Load<SoundEffect>("audio\\pigExplode3");
      this.pigExplode[3] = this.content.Load<SoundEffect>("audio\\pigExplode4");
      this.xmas1 = this.content.Load<SoundEffect>("audio\\xmas1");
      this.xmas2 = this.content.Load<SoundEffect>("audio\\xmas2");
      this.hammer1 = this.content.Load<SoundEffect>("audio\\hammer1");
      this.doorRattle = this.content.Load<SoundEffect>("audio\\doorRattle");
      this.doorUnlock = this.content.Load<SoundEffect>("audio\\unlock");
      this.pillswallow = this.content.Load<SoundEffect>("audio\\pillswallow");
      this.pillRattler = this.content.Load<SoundEffect>("audio\\pillrattle3");
      this.pillselect = this.content.Load<SoundEffect>("audio\\pillselect");
      this.newtip = this.content.Load<SoundEffect>("audio\\message5");
      this.gusher = this.content.Load<SoundEffect>("audio\\gusher");
      this.pump = new SoundEffect[2];
      this.pump[0] = this.content.Load<SoundEffect>("audio\\pump2");
      this.pump[1] = this.content.Load<SoundEffect>("audio\\pump3");
      this.fanfare = this.content.Load<SoundEffect>("audio\\fanfare");
      this.achieve1 = this.content.Load<SoundEffect>("audio\\achv");
      this.hulkRoar2 = this.content.Load<SoundEffect>("audio\\hulkRoar2");
      this.hulkRoar = this.content.Load<SoundEffect>("audio\\hulkRoar");
      this.roar = this.content.Load<SoundEffect>("audio\\roar");
      this.crunch = this.content.Load<SoundEffect>("audio\\crunch");
      this.fence = this.content.Load<SoundEffect>("audio\\shock");
      this.crumble = new SoundEffect[3];
      this.crumble[0] = this.content.Load<SoundEffect>("audio\\crumble3");
      this.crumble[1] = this.content.Load<SoundEffect>("audio\\crumble4");
      this.crumble[2] = this.content.Load<SoundEffect>("audio\\crumble");
      this.switchweapon = this.content.Load<SoundEffect>("audio\\sWeapon");
      this.melee = this.content.Load<SoundEffect>("audio\\melee");
      this.metalHit = new SoundEffect[4];
      this.metalHit[0] = this.content.Load<SoundEffect>("audio\\metalHit1");
      this.metalHit[1] = this.content.Load<SoundEffect>("audio\\metalHit2");
      this.metalHit[2] = this.content.Load<SoundEffect>("audio\\metalHit3");
      this.metalHit[3] = this.content.Load<SoundEffect>("audio\\metalHit4");
      this.pigSqueal = new SoundEffect[4];
      this.pigSqueal[0] = this.content.Load<SoundEffect>("audio\\piggy");
      this.pigSqueal[1] = this.content.Load<SoundEffect>("audio\\piggy2");
      this.pigSqueal[2] = this.content.Load<SoundEffect>("audio\\piggy3");
      this.pigSqueal[3] = this.content.Load<SoundEffect>("audio\\piggy4");
      this.pigDie = new SoundEffect[5];
      this.pigDie[0] = this.content.Load<SoundEffect>("audio//pigDie1");
      this.pigDie[1] = this.content.Load<SoundEffect>("audio//pigDie2");
      this.pigDie[2] = this.content.Load<SoundEffect>("audio//pigDie3");
      this.pigDie[3] = this.content.Load<SoundEffect>("audio//pigDie4");
      this.pigDie[4] = this.content.Load<SoundEffect>("audio//pigDie5");
      this.allpigs = this.content.Load<SoundEffect>("audio\\pigDie15");
      this.barndoor = this.content.Load<SoundEffect>("audio\\barndoor");
      this.grenadePop1 = new SoundEffect[2];
      this.grenadePop1[0] = this.content.Load<SoundEffect>("audio\\gren6");
      this.grenadePop1[1] = this.content.Load<SoundEffect>("audio\\grenadeExplode");
      this.ring = this.content.Load<SoundEffect>("audio\\completed");
      this.sproing = new SoundEffect[2];
      this.sproing[0] = this.content.Load<SoundEffect>("audio\\sproing3");
      this.sproing[1] = this.content.Load<SoundEffect>("audio\\sproing2");
      this.chomp = this.content.Load<SoundEffect>("audio\\chomp2");
      this.ruffles = this.content.Load<SoundEffect>("audio\\ruffles");
      this.falldown = this.content.Load<SoundEffect>("audio\\falldown2");
      this.falldown2 = this.content.Load<SoundEffect>("audio\\falldown3");
      this.toneer = this.content.Load<SoundEffect>("audio\\tonewtf");
      this.dying = this.content.Load<SoundEffect>("audio\\dying2");
      this.chunk1 = this.content.Load<SoundEffect>("audio\\chunkhit1");
      this.chunk2 = this.content.Load<SoundEffect>("audio\\chunkhit2");
      this.meaty = this.content.Load<SoundEffect>("audio\\meat");
      this.manyell = this.content.Load<SoundEffect>("audio\\manyell");
      this.hurt = this.content.Load<SoundEffect>("audio\\hurt");
      this.grabby = this.content.Load<SoundEffect>("audio\\grabWeaponZ");
      this.chain = new SoundEffects(2, true);
      this.chain.sound[0] = this.content.Load<SoundEffect>("audio\\chainRattle").CreateInstance();
      this.chain.sound[1] = this.content.Load<SoundEffect>("audio\\chainRattle").CreateInstance();
      this.ricochete = new SoundEffect[3];
      this.ricochete[0] = this.content.Load<SoundEffect>("audio\\ric6");
      this.ricochete[1] = this.content.Load<SoundEffect>("audio\\ric7");
      this.ricochete[2] = this.content.Load<SoundEffect>("audio\\ric8");
      this.abort = this.content.Load<SoundEffect>("audio\\abort");
      this.harp2 = this.content.Load<SoundEffect>("audio\\harp2");
      this.humm = this.content.Load<SoundEffect>("audio\\humm");
      this.switch2 = this.content.Load<SoundEffect>("audio\\switch2");
      this.lightClick = this.content.Load<SoundEffect>("audio\\switch");
      this.grinder = this.content.Load<SoundEffect>("audio\\grind");
      this.grinderMotor = new SoundEffects(1);
      this.grinderMotor.sound[0] = this.content.Load<SoundEffect>("audio\\grinderMotor").CreateInstance();
      this.grinderMotor.sound[0].IsLooped = true;
      this.pickup1 = this.content.Load<SoundEffect>("audio\\pickup1");
      this.pickup2 = this.content.Load<SoundEffect>("audio\\pickup2");
      this.pickupGrenade = this.content.Load<SoundEffect>("audio\\pickupMain");
      this.drinkMilk = this.content.Load<SoundEffect>("audio\\drinkmilk");
      this.mirvDrop = this.content.Load<SoundEffect>("audio\\build4");
      this.buttonPress = this.content.Load<SoundEffect>("audio\\buttonPress");
      this.buttonDeny = this.content.Load<SoundEffect>("audio\\buttonDeny");
      this.buttonPackage = this.content.Load<SoundEffect>("audio\\buttonPackage");
      this.boarbite = new SoundEffect[5];
      this.boarbite[0] = this.content.Load<SoundEffect>("audio\\bite6");
      this.boarbite[1] = this.content.Load<SoundEffect>("audio\\bite7");
      this.boarbite[2] = this.content.Load<SoundEffect>("audio\\bite8");
      this.boarbite[3] = this.content.Load<SoundEffect>("audio\\bite1");
      this.boarbite[4] = this.content.Load<SoundEffect>("audio\\bite2");
    }

    public void loadBarns()
    {
      this.barnRGB = this.content.Load<Texture2D>("texture//barnRGB");
      this.barnShadow = this.content.Load<Texture2D>("texture//barnShadow");
      this.barnsLoaded = true;
    }

    public void loadMountBuilding()
    {
      this.grassTexture = this.content.Load<Texture2D>("texture//grassTexture");
      this.texture2D_0 = this.content.Load<Texture2D>("texture//buildingRGB");
      this.buildingShadow = this.content.Load<Texture2D>("texture//buildingShadow");
      this.buildingRGBNight = this.content.Load<Texture2D>("texture//buildingRGBpm");
      this.buildingShadowNight = this.content.Load<Texture2D>("texture//buildingShadowpm");
      this.mountainBuildingLoaded = true;
    }

    public void loadGUNS()
    {
      this.gunTextures[0] = this.content.Load<Texture2D>("texture//indiepistol2");
      this.gunTextures[2] = this.content.Load<Texture2D>("texture//Colt2");
      this.gunTextures[4] = this.content.Load<Texture2D>("texture//Silentp");
      this.gunTextures[6] = this.content.Load<Texture2D>("texture//AK47");
      this.gunTextures[8] = this.content.Load<Texture2D>("texture//shotgun3");
      this.gunTextures[10] = this.content.Load<Texture2D>("texture//m16map2");
      this.gunTextures[12] = this.content.Load<Texture2D>("texture//uzi2");
      this.gunTextures[14] = this.content.Load<Texture2D>("texture//bfg1");
      this.gunTextures[16] = this.content.Load<Texture2D>("texture//paintballgun");
      this.gunTextures[18] = this.content.Load<Texture2D>("texture//abc4");
      this.gunTextures[20] = this.content.Load<Texture2D>("texture//scarTexture");
      this.hatTextures[0] = this.content.Load<Texture2D>("texture//hat1");
      this.hatTextures[1] = this.content.Load<Texture2D>("texture//hat2");
      this.hatTextures[2] = this.content.Load<Texture2D>("texture//hat3");
      this.hatTextures[3] = this.content.Load<Texture2D>("texture//hat4");
      this.hatTextures[4] = this.content.Load<Texture2D>("texture//hat5");
      this.hatTextures[5] = this.content.Load<Texture2D>("texture//hat6");
      this.hatTextures[6] = this.content.Load<Texture2D>("texture//hat7");
      this.hatTextures[7] = this.content.Load<Texture2D>("texture//hat8");
      this.hatTextures[8] = this.content.Load<Texture2D>("texture//hat9");
      this.hatTextures[9] = this.content.Load<Texture2D>("texture//hat10");
      this.hatTextures[10] = this.content.Load<Texture2D>("texture//hat11");
      this.hatTextures[11] = this.content.Load<Texture2D>("texture//hat12");
      this.hatTextures[12] = this.content.Load<Texture2D>("texture//hat13");
      this.hatTextures[13] = this.content.Load<Texture2D>("texture//hat14");
      this.hatTextures[14] = this.content.Load<Texture2D>("texture//hat15");
      this.hatTextures[15] = this.content.Load<Texture2D>("texture//hat15");
      this.goldkeyTexture = this.content.Load<Texture2D>("texture//goldkey");
      this.blimpTexture = this.content.Load<Texture2D>("texture//blimp");
      this.moonTexture = this.content.Load<Texture2D>("texture//moon");
      this.hatEffect = this.content.Load<Effect>("effects//hateffect");
      this.hatTransX = new Vector3[11, 16];
      this.hatRotX = new Vector3[11, 16];
      this.hatScaleX = new float[11, 16];
      this.setHatMatrix();
      if (this.debug_show)
        this.setTempHatMatrix(ref this.temphatMatrix);
      this.loadGuns = true;
    }

    public void setHatMatrix()
    {
      this.hatMatrix[0, 0] = Matrix.CreateRotationZ(-0.06f) * Matrix.CreateRotationY(-0.05f) * Matrix.CreateRotationX(-0.1f) * Matrix.CreateScale(0.9f) * Matrix.CreateTranslation(0.447f, 52.717f, 1.22f);
      this.hatMatrix[0, 1] = Matrix.CreateRotationZ(-0.118f) * Matrix.CreateRotationY(0.158f) * Matrix.CreateRotationX(-0.117f) * Matrix.CreateScale(1.07f) * Matrix.CreateTranslation(0.455f, 51.295f, 1.425f);
      this.hatMatrix[0, 2] = Matrix.CreateRotationZ(-0.119f) * Matrix.CreateRotationY(0.022f) * Matrix.CreateRotationX(0.053f) * Matrix.CreateScale(1.13f) * Matrix.CreateTranslation(0.56f, 50.96f, 1.03f);
      this.hatMatrix[0, 3] = Matrix.CreateRotationZ(-0.156f) * Matrix.CreateRotationY(0.177f) * Matrix.CreateRotationX(-0.149f) * Matrix.CreateScale(1.034f) * Matrix.CreateTranslation(0.531f, 52.27f, 1.055f);
      this.hatMatrix[0, 4] = Matrix.CreateRotationZ(-0.123f) * Matrix.CreateRotationY(0.176f) * Matrix.CreateRotationX(-0.216f) * Matrix.CreateScale(1.18f) * Matrix.CreateTranslation(0.64f, 51.279f, 2.141f);
      this.hatMatrix[0, 5] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(1.06f) * Matrix.CreateTranslation(0.7f, 50.6f, 2.2f);
      this.hatMatrix[0, 6] = Matrix.CreateRotationZ(-0.197f) * Matrix.CreateRotationY(0.121f) * Matrix.CreateRotationX(0.35f) * Matrix.CreateScale(1.01f) * Matrix.CreateTranslation(3f / 500f, 48.432f, 2.28f);
      this.hatMatrix[0, 7] = Matrix.CreateRotationZ(-0.11f) * Matrix.CreateRotationY(0.074f) * Matrix.CreateRotationX(-0.05f) * Matrix.CreateScale(0.85f) * Matrix.CreateTranslation(0.96f, 48.29f, 3.713f);
      this.hatMatrix[0, 8] = Matrix.CreateRotationZ(-0.08f) * Matrix.CreateRotationY(0.02f) * Matrix.CreateRotationX(-0.09f) * Matrix.CreateScale(0.9f) * Matrix.CreateTranslation(0.65f, 52.49f, 1.28f);
      this.hatMatrix[0, 9] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(1.06f) * Matrix.CreateTranslation(0.17f, 50.52f, 2.2f);
      this.hatMatrix[0, 10] = Matrix.CreateRotationZ(-0.08f) * Matrix.CreateRotationY(0.21f) * Matrix.CreateRotationX(-0.16f) * Matrix.CreateScale(1.01f) * Matrix.CreateTranslation(0.67f, 52.19f, 1.27f);
      this.hatMatrix[0, 11] = Matrix.CreateRotationZ(-0.08f) * Matrix.CreateRotationY(0.02f) * Matrix.CreateRotationX(-0.09f) * Matrix.CreateScale(0.9f) * Matrix.CreateTranslation(0.65f, 52.49f, 1.28f);
      this.hatMatrix[0, 12] = this.hatMatrix[0, 2];
      this.hatMatrix[0, 13] = this.hatMatrix[0, 8];
      this.hatMatrix[0, 14] = this.hatMatrix[0, 0];
      this.hatMatrix[1, 0] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(1f) * Matrix.CreateTranslation(0.4f, 51.1f, 1.5f);
      this.hatMatrix[1, 1] = Matrix.CreateRotationZ(-0.15f) * Matrix.CreateRotationY(0.08f) * Matrix.CreateRotationX(0.02f) * Matrix.CreateScale(0.98f) * Matrix.CreateTranslation(0.49f, 50.8f, 1.4f);
      this.hatMatrix[1, 2] = Matrix.CreateRotationZ(-0.078f) * Matrix.CreateRotationY(1f / 1000f) * Matrix.CreateRotationX(-0.01f) * Matrix.CreateScale(0.96f) * Matrix.CreateTranslation(0.5f, 50.6f, 1.5f);
      this.hatMatrix[1, 3] = Matrix.CreateRotationZ(-0.133f) * Matrix.CreateRotationY(0.11f) * Matrix.CreateRotationX(-0.043f) * Matrix.CreateScale(1f) * Matrix.CreateTranslation(0.4f, 51.1f, 1.5f);
      this.hatMatrix[1, 4] = Matrix.CreateRotationZ(-0.066f) * Matrix.CreateRotationY(0.12f) * Matrix.CreateRotationX(-0.036f) * Matrix.CreateScale(1.102f) * Matrix.CreateTranslation(0.381f, 50.635f, 1.874f);
      this.hatMatrix[1, 5] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(0.94f) * Matrix.CreateTranslation(0.7f, 50.7f, 2.09f);
      this.hatMatrix[1, 6] = Matrix.CreateRotationZ(-0.179f) * Matrix.CreateRotationY(0.093f) * Matrix.CreateRotationX(0.19f) * Matrix.CreateScale(0.93f) * Matrix.CreateTranslation(0.03f, 48.19f, 2.457f);
      this.hatMatrix[1, 7] = Matrix.CreateRotationZ(-0.145f) * Matrix.CreateRotationY(0.074f) * Matrix.CreateRotationX(-0.093f) * Matrix.CreateScale(0.92f) * Matrix.CreateTranslation(0.1f, 48.2f, 3.618f);
      this.hatMatrix[1, 8] = Matrix.CreateRotationZ(-0.13f) * Matrix.CreateRotationY(0.03f) * Matrix.CreateRotationX(-0.03f) * Matrix.CreateScale(0.89f) * Matrix.CreateTranslation(0.4f, 51.1f, 1.5f);
      this.hatMatrix[1, 9] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(-0.02f) * Matrix.CreateRotationX(-0.08f) * Matrix.CreateScale(0.9f) * Matrix.CreateTranslation(0.422f, 50.533f, 2.278f);
      this.hatMatrix[1, 10] = Matrix.CreateRotationZ(-0.14f) * Matrix.CreateRotationY(0.13f) * Matrix.CreateRotationX(-0.13f) * Matrix.CreateScale(0.98f) * Matrix.CreateTranslation(0.56f, 51.63f, 1.5f);
      this.hatMatrix[1, 11] = Matrix.CreateRotationZ(-0.13f) * Matrix.CreateRotationY(0.03f) * Matrix.CreateRotationX(-0.03f) * Matrix.CreateScale(0.89f) * Matrix.CreateTranslation(0.4f, 51.1f, 1.5f);
      this.hatMatrix[1, 12] = this.hatMatrix[1, 2];
      this.hatMatrix[1, 13] = this.hatMatrix[1, 8];
      this.hatMatrix[1, 14] = this.hatMatrix[1, 0];
      this.hatMatrix[2, 0] = Matrix.CreateRotationZ(-0.073f) * Matrix.CreateRotationY(0.015f) * Matrix.CreateRotationX(-0.101f) * Matrix.CreateScale(1.02f) * Matrix.CreateTranslation(-0.015f, 51.327f, 1.335f);
      this.hatMatrix[2, 1] = Matrix.CreateRotationZ(-0.016f) * Matrix.CreateRotationY(0.004f) * Matrix.CreateRotationX(-0.177f) * Matrix.CreateScale(0.92f) * Matrix.CreateTranslation(0.1f, 51.3f, 1.2f);
      this.hatMatrix[2, 2] = Matrix.CreateRotationZ(-0.052f) * Matrix.CreateRotationY(0.071f) * Matrix.CreateRotationX(-0.01f) * Matrix.CreateScale(1f) * Matrix.CreateTranslation(0.0f, 50.9f, 1.2f);
      this.hatMatrix[2, 3] = Matrix.CreateRotationZ(-0.14f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(1.02f) * Matrix.CreateTranslation(0.1f, 51.4f, 1.5f);
      this.hatMatrix[2, 4] = Matrix.CreateRotationZ(-0.025f) * Matrix.CreateRotationY(0.087f) * Matrix.CreateRotationX(-0.092f) * Matrix.CreateScale(1.02f) * Matrix.CreateTranslation(-0.005f, 51.2f, 1.613f);
      this.hatMatrix[2, 5] = Matrix.CreateRotationZ(-0.14f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(0.9f) * Matrix.CreateTranslation(0.2f, 50.7f, 2f);
      this.hatMatrix[2, 6] = Matrix.CreateRotationZ(-0.004f) * Matrix.CreateRotationY(0.075f) * Matrix.CreateRotationX(0.11f) * Matrix.CreateScale(0.94f) * Matrix.CreateTranslation(0.0f, 48.3f, 2.4f);
      this.hatMatrix[2, 7] = Matrix.CreateRotationZ(-0.14f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(0.94f) * Matrix.CreateTranslation(0.0f, 48.3f, 3.613f);
      this.hatMatrix[2, 8] = Matrix.CreateRotationZ(0.01f) * Matrix.CreateRotationY(-0.15f) * Matrix.CreateRotationX(-0.09f) * Matrix.CreateScale(0.86f) * Matrix.CreateTranslation(0.1f, 51.4f, 1.31f);
      this.hatMatrix[2, 9] = Matrix.CreateRotationZ(-0.14f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(0.9f) * Matrix.CreateTranslation(-0.111f, 50.152f, 2.238f);
      this.hatMatrix[2, 10] = Matrix.CreateRotationZ(-0.02f) * Matrix.CreateRotationY(0.07f) * Matrix.CreateRotationX(-0.14f) * Matrix.CreateScale(1.02f) * Matrix.CreateTranslation(-0.09f, 51.18f, 1.243f);
      this.hatMatrix[2, 11] = Matrix.CreateRotationZ(0.01f) * Matrix.CreateRotationY(-0.15f) * Matrix.CreateRotationX(-0.09f) * Matrix.CreateScale(0.86f) * Matrix.CreateTranslation(0.1f, 51.4f, 1.31f);
      this.hatMatrix[2, 12] = this.hatMatrix[2, 2];
      this.hatMatrix[2, 13] = this.hatMatrix[2, 8];
      this.hatMatrix[2, 14] = this.hatMatrix[2, 0];
      this.hatMatrix[3, 0] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(1.02f) * Matrix.CreateTranslation(0.6f, 52.5f, 1f);
      this.hatMatrix[3, 1] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(1f) * Matrix.CreateTranslation(0.6f, 51.8f, 0.7f);
      this.hatMatrix[3, 2] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(1.02f) * Matrix.CreateTranslation(0.6f, 51.6f, 0.9f);
      this.hatMatrix[3, 3] = Matrix.CreateRotationZ(-0.08f) * Matrix.CreateRotationY(0.03f) * Matrix.CreateRotationX(-0.22f) * Matrix.CreateScale(1.07f) * Matrix.CreateTranslation(0.6f, 52f, 1.05f);
      this.hatMatrix[3, 4] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(1.1f) * Matrix.CreateTranslation(0.6f, 51.9f, 1.8f);
      this.hatMatrix[3, 5] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(0.9f) * Matrix.CreateTranslation(0.6f, 52f, 1.4f);
      this.hatMatrix[3, 6] = Matrix.CreateRotationZ(-0.129f) * Matrix.CreateRotationY(-11f / 1000f) * Matrix.CreateRotationX(0.111f) * Matrix.CreateScale(0.96f) * Matrix.CreateTranslation(0.2f, 48.8f, 2.2f);
      this.hatMatrix[3, 7] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(0.96f) * Matrix.CreateTranslation(0.2f, 48.8f, 2.2f);
      this.hatMatrix[3, 8] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(0.892f) * Matrix.CreateTranslation(0.553f, 52.556f, 0.966f);
      this.hatMatrix[3, 9] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(-0.13f) * Matrix.CreateRotationX(-0.3f) * Matrix.CreateScale(0.97f) * Matrix.CreateTranslation(0.46f, 51f, 1.95f);
      this.hatMatrix[3, 10] = Matrix.CreateRotationZ(-0.1f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(0.97f) * Matrix.CreateTranslation(0.6f, 52.33f, 1.13f);
      this.hatMatrix[3, 11] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(0.892f) * Matrix.CreateTranslation(0.553f, 52.556f, 0.966f);
      this.hatMatrix[3, 12] = this.hatMatrix[3, 2];
      this.hatMatrix[3, 13] = this.hatMatrix[3, 8];
      this.hatMatrix[3, 14] = this.hatMatrix[3, 0];
      this.hatMatrix[4, 0] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(1.06f) * Matrix.CreateTranslation(0.514f, 51.891f, 2.25f);
      this.hatMatrix[4, 1] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(1.06f) * Matrix.CreateTranslation(0.7f, 51.3f, 1.5f);
      this.hatMatrix[4, 2] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(1.06f) * Matrix.CreateTranslation(0.7f, 51.1f, 2f);
      this.hatMatrix[4, 3] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(1.06f) * Matrix.CreateTranslation(0.7f, 52f, 2.2f);
      this.hatMatrix[4, 4] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(1.1f) * Matrix.CreateTranslation(0.6f, 51.5f, 2.6f);
      this.hatMatrix[4, 5] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(-0.279f) * Matrix.CreateScale(1.026f) * Matrix.CreateTranslation(0.812f, 50.808f, 2.632f);
      this.hatMatrix[4, 6] = Matrix.CreateRotationZ(-0.13f) * Matrix.CreateRotationY(0.03f) * Matrix.CreateRotationX(0.1f) * Matrix.CreateScale(1.01f) * Matrix.CreateTranslation(0.4f, 48.34f, 3.1f);
      this.hatMatrix[4, 7] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(0.98f) * Matrix.CreateTranslation(0.4f, 48.4f, 3.1f);
      this.hatMatrix[4, 8] = Matrix.CreateRotationZ(-0.092f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.129f) * Matrix.CreateScale(0.885f) * Matrix.CreateTranslation(0.788f, 52.403f, 2.157f);
      this.hatMatrix[4, 9] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(1.06f) * Matrix.CreateTranslation(0.68f, 50.43f, 2.7f);
      this.hatMatrix[4, 10] = Matrix.CreateRotationZ(-0.08f) * Matrix.CreateRotationY(0.02f) * Matrix.CreateRotationX(-0.02f) * Matrix.CreateScale(1.06f) * Matrix.CreateTranslation(0.8f, 52.05f, 1.67f);
      this.hatMatrix[4, 11] = Matrix.CreateRotationZ(-0.092f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.129f) * Matrix.CreateScale(0.885f) * Matrix.CreateTranslation(0.788f, 52.403f, 2.157f);
      this.hatMatrix[4, 12] = this.hatMatrix[4, 2];
      this.hatMatrix[4, 13] = this.hatMatrix[4, 8];
      this.hatMatrix[4, 14] = this.hatMatrix[4, 0];
      this.hatMatrix[5, 0] = Matrix.CreateRotationZ(-0.056f) * Matrix.CreateRotationY(0.012f) * Matrix.CreateRotationX(0.093f) * Matrix.CreateScale(1.1f) * Matrix.CreateTranslation(0.1f, 52.8f, 1.4f);
      this.hatMatrix[5, 1] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(-0.03f) * Matrix.CreateRotationX(-0.07f) * Matrix.CreateScale(0.94f) * Matrix.CreateTranslation(0.0f, 52.9f, 1.27f);
      this.hatMatrix[5, 2] = Matrix.CreateRotationZ(0.01f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(-0.06f) * Matrix.CreateScale(1.07f) * Matrix.CreateTranslation(0.19f, 52.61f, 1.53f);
      this.hatMatrix[5, 3] = Matrix.CreateRotationZ(-0.05f) * Matrix.CreateRotationY(0.04f) * Matrix.CreateRotationX(-0.29f) * Matrix.CreateScale(1.1f) * Matrix.CreateTranslation(-0.05f, 52.54f, 1.47f);
      this.hatMatrix[5, 4] = Matrix.CreateRotationZ(-0.04f) * Matrix.CreateRotationY(0.06f) * Matrix.CreateRotationX(0.07f) * Matrix.CreateScale(1.15f) * Matrix.CreateTranslation(-0.04f, 52.1f, 2f);
      this.hatMatrix[5, 5] = Matrix.CreateRotationZ(-0.14f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(1.02f) * Matrix.CreateTranslation(0.2f, 51.9f, 1.9f);
      this.hatMatrix[5, 6] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.06f) * Matrix.CreateScale(0.94f) * Matrix.CreateTranslation(-0.1f, 49.4f, 2.38f);
      this.hatMatrix[5, 7] = Matrix.CreateRotationZ(-0.14f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(0.94f) * Matrix.CreateTranslation(-0.1f, 49.4f, 2.6f);
      this.hatMatrix[5, 8] = Matrix.CreateRotationZ(-0.01f) * Matrix.CreateRotationY(0.19f) * Matrix.CreateRotationX(0.05f) * Matrix.CreateScale(0.94f) * Matrix.CreateTranslation(0.1f, 52.8f, 1.4f);
      this.hatMatrix[5, 9] = Matrix.CreateRotationZ(0.01f) * Matrix.CreateRotationY(-0.07f) * Matrix.CreateRotationX(0.04f) * Matrix.CreateScale(1.02f) * Matrix.CreateTranslation(-0.17f, 51.55f, 1.9f);
      this.hatMatrix[5, 10] = Matrix.CreateRotationZ(0.05f) * Matrix.CreateRotationY(0.06f) * Matrix.CreateRotationX(-0.1f) * Matrix.CreateScale(1.15f) * Matrix.CreateTranslation(0.01f, 53.11f, 1.7f);
      this.hatMatrix[5, 11] = Matrix.CreateRotationZ(-0.01f) * Matrix.CreateRotationY(0.19f) * Matrix.CreateRotationX(0.05f) * Matrix.CreateScale(0.94f) * Matrix.CreateTranslation(0.1f, 52.8f, 1.4f);
      this.hatMatrix[5, 12] = this.hatMatrix[5, 2];
      this.hatMatrix[5, 13] = this.hatMatrix[5, 8];
      this.hatMatrix[5, 14] = this.hatMatrix[5, 0];
      this.hatMatrix[6, 0] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(0.84f) * Matrix.CreateTranslation(0.6f, 51.4f, 2.2f);
      this.hatMatrix[6, 1] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(1.06f) * Matrix.CreateTranslation(0.7f, 51.3f, 1.5f);
      this.hatMatrix[6, 2] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(1.06f) * Matrix.CreateTranslation(0.7f, 51.1f, 2f);
      this.hatMatrix[6, 3] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(1.06f) * Matrix.CreateTranslation(0.7f, 52f, 2.2f);
      this.hatMatrix[6, 4] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(1.1f) * Matrix.CreateTranslation(0.6f, 51.5f, 2.6f);
      this.hatMatrix[6, 5] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(1.06f) * Matrix.CreateTranslation(0.7f, 50.6f, 2.7f);
      this.hatMatrix[6, 6] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(0.98f) * Matrix.CreateTranslation(0.4f, 48.4f, 3.1f);
      this.hatMatrix[6, 7] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(0.94f) * Matrix.CreateTranslation(0.2f, 48.5f, 3.1f);
      this.hatMatrix[6, 8] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(0.84f) * Matrix.CreateTranslation(0.6f, 51.4f, 2.2f);
      this.hatMatrix[6, 9] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(1.06f) * Matrix.CreateTranslation(0.7f, 50.6f, 2.7f);
      this.hatMatrix[6, 10] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(1.06f) * Matrix.CreateTranslation(0.7f, 52f, 2.2f);
      this.hatMatrix[6, 11] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(0.84f) * Matrix.CreateTranslation(0.6f, 51.4f, 2.2f);
      this.hatMatrix[6, 12] = this.hatMatrix[6, 2];
      this.hatMatrix[6, 13] = this.hatMatrix[6, 8];
      this.hatMatrix[6, 14] = this.hatMatrix[6, 0];
      this.hatMatrix[7, 0] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(1.1f) * Matrix.CreateTranslation(0.1f, 52.8f, 1.4f);
      this.hatMatrix[7, 1] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(0.94f) * Matrix.CreateTranslation(0.0f, 52.9f, 1f);
      this.hatMatrix[7, 2] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(1f) * Matrix.CreateTranslation(0.0f, 52.9f, 1f);
      this.hatMatrix[7, 3] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(1.1f) * Matrix.CreateTranslation(0.1f, 52.8f, 1.4f);
      this.hatMatrix[7, 4] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(1.1f) * Matrix.CreateTranslation(0.1f, 52.1f, 2f);
      this.hatMatrix[7, 5] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(1.02f) * Matrix.CreateTranslation(0.2f, 51.9f, 1.9f);
      this.hatMatrix[7, 6] = Matrix.CreateRotationZ(-0.05f) * Matrix.CreateRotationY(0.02f) * Matrix.CreateRotationX(0.13f) * Matrix.CreateScale(0.94f) * Matrix.CreateTranslation(-0.1f, 49.4f, 2.6f);
      this.hatMatrix[7, 7] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(0.94f) * Matrix.CreateTranslation(-0.1f, 49.4f, 2.6f);
      this.hatMatrix[7, 8] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.217f) * Matrix.CreateScale(0.588f) * Matrix.CreateTranslation(0.1f, 53.567f, 1.635f);
      this.hatMatrix[7, 9] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(1.02f) * Matrix.CreateTranslation(-0.21f, 50.87f, 2.28f);
      this.hatMatrix[7, 10] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(0.97f) * Matrix.CreateTranslation(-0.05f, 52.6f, 1.4f);
      this.hatMatrix[7, 11] = Matrix.CreateRotationZ(0.0f) * Matrix.CreateRotationY(0.0f) * Matrix.CreateRotationX(0.217f) * Matrix.CreateScale(0.588f) * Matrix.CreateTranslation(0.1f, 53.567f, 1.635f);
      this.hatMatrix[7, 12] = this.hatMatrix[7, 2];
      this.hatMatrix[7, 13] = this.hatMatrix[7, 8];
      this.hatMatrix[7, 14] = this.hatMatrix[7, 0];
      this.hatMatrix[8, 0] = Matrix.CreateRotationZ(-0.06f) * Matrix.CreateRotationY(0.21f) * Matrix.CreateRotationX(0.11f) * Matrix.CreateScale(1.15f) * Matrix.CreateTranslation(0.62f, 54.41f, 0.39f);
      this.hatMatrix[8, 1] = Matrix.CreateRotationZ(-0.04f) * Matrix.CreateRotationY(0.19f) * Matrix.CreateRotationX(0.03f) * Matrix.CreateScale(1.22f) * Matrix.CreateTranslation(0.59f, 54.45f, -0.44f);
      this.hatMatrix[8, 2] = Matrix.CreateRotationZ(-0.08f) * Matrix.CreateRotationY(0.22f) * Matrix.CreateRotationX(-0.08f) * Matrix.CreateScale(1.82f) * Matrix.CreateTranslation(0.55f, 51.63f, 0.25f);
      this.hatMatrix[8, 3] = Matrix.CreateRotationZ(-0.08f) * Matrix.CreateRotationY(0.25f) * Matrix.CreateRotationX(0.2f) * Matrix.CreateScale(1.3f) * Matrix.CreateTranslation(0.99f, 55.06f, 1.2f);
      this.hatMatrix[8, 4] = Matrix.CreateRotationZ(-0.1f) * Matrix.CreateRotationY(0.15f) * Matrix.CreateRotationX(0.23f) * Matrix.CreateScale(1.66f) * Matrix.CreateTranslation(0.92f, 54.35f, 0.24f);
      this.hatMatrix[8, 5] = Matrix.CreateRotationZ(0.05f) * Matrix.CreateRotationY(6.49f) * Matrix.CreateRotationX(-0.19f) * Matrix.CreateScale(1.52f) * Matrix.CreateTranslation(0.71f, 52.19f, 0.33f);
      this.hatMatrix[8, 6] = Matrix.CreateRotationZ(-0.07f) * Matrix.CreateRotationY(0.22f) * Matrix.CreateRotationX(0.06f) * Matrix.CreateScale(1.92f) * Matrix.CreateTranslation(0.98f, 46.53f, 2.19f);
      this.hatMatrix[8, 7] = Matrix.CreateRotationZ(-0.05f) * Matrix.CreateRotationY(0.19f) * Matrix.CreateRotationX(-0.18f) * Matrix.CreateScale(1.2f) * Matrix.CreateTranslation(0.49f, 48.13f, 2.92f);
      this.hatMatrix[8, 8] = Matrix.CreateRotationZ(-0.118f) * Matrix.CreateRotationY(0.555f) * Matrix.CreateRotationX(0.09f) * Matrix.CreateScale(0.588f) * Matrix.CreateTranslation(0.615f, 54.355f, 0.733f);
      this.hatMatrix[8, 9] = Matrix.CreateRotationZ(-0.04f) * Matrix.CreateRotationY(6.41f) * Matrix.CreateRotationX(-0.13f) * Matrix.CreateScale(1.52f) * Matrix.CreateTranslation(0.64f, 51.33f, 1.79f);
      this.hatMatrix[8, 10] = Matrix.CreateRotationZ(-0.06f) * Matrix.CreateRotationY(0.22f) * Matrix.CreateRotationX(0.0f) * Matrix.CreateScale(1.3f) * Matrix.CreateTranslation(0.93f, 54.83f, 1.04f);
      this.hatMatrix[8, 11] = Matrix.CreateRotationZ(-0.118f) * Matrix.CreateRotationY(0.555f) * Matrix.CreateRotationX(0.09f) * Matrix.CreateScale(0.588f) * Matrix.CreateTranslation(0.615f, 54.355f, 0.733f);
      this.hatMatrix[8, 12] = this.hatMatrix[8, 2];
      this.hatMatrix[8, 13] = this.hatMatrix[8, 8];
      this.hatMatrix[8, 14] = this.hatMatrix[8, 0];
      this.hatMatrix[9, 0] = Matrix.CreateRotationZ(-0.06f) * Matrix.CreateRotationY(0.037f) * Matrix.CreateRotationX(-0.007f) * Matrix.CreateScale(0.351f) * Matrix.CreateTranslation(0.207f, 53.021f, 1.758f);
      this.hatMatrix[9, 1] = Matrix.CreateRotationZ(-0.04f) * Matrix.CreateRotationY(0.092f) * Matrix.CreateRotationX(-0.177f) * Matrix.CreateScale(0.388f) * Matrix.CreateTranslation(0.138f, 52.637f, 1.519f);
      this.hatMatrix[9, 2] = Matrix.CreateRotationZ(-11f / 1000f) * Matrix.CreateRotationY(0.033f) * Matrix.CreateRotationX(-0.371f) * Matrix.CreateScale(0.805f) * Matrix.CreateTranslation(0.192f, 51.125f, 0.674f);
      this.hatMatrix[9, 3] = Matrix.CreateRotationZ(-0.108f) * Matrix.CreateRotationY(0.063f) * Matrix.CreateRotationX(-1f / 1000f) * Matrix.CreateScale(0.543f) * Matrix.CreateTranslation(0.241f, 52.212f, 1.986f);
      this.hatMatrix[9, 4] = Matrix.CreateRotationZ(-0.064f) * Matrix.CreateRotationY(0.031f) * Matrix.CreateRotationX(0.112f) * Matrix.CreateScale(0.612f) * Matrix.CreateTranslation(0.152f, 51.922f, 2.251f);
      this.hatMatrix[9, 5] = Matrix.CreateRotationZ(0.05f) * Matrix.CreateRotationY(6.26f) * Matrix.CreateRotationX(0.035f) * Matrix.CreateScale(0.473f) * Matrix.CreateTranslation(0.296f, 51.88f, 2.275f);
      this.hatMatrix[9, 6] = Matrix.CreateRotationZ(-0.055f) * Matrix.CreateRotationY(-0.053f) * Matrix.CreateRotationX(-0.211f) * Matrix.CreateScale(1.048f) * Matrix.CreateTranslation(0.158f, 47.864f, 2.599f);
      this.hatMatrix[9, 7] = Matrix.CreateRotationZ(-0.167f) * Matrix.CreateRotationY(0.01f) * Matrix.CreateRotationX(-0.01f) * Matrix.CreateScale(0.75f) * Matrix.CreateTranslation(0.007f, 47.829f, 4.321f);
      this.hatMatrix[9, 8] = Matrix.CreateRotationZ(-0.56f) * Matrix.CreateRotationY(-0.191f) * Matrix.CreateRotationX(-0.037f) * Matrix.CreateScale(0.247f) * Matrix.CreateTranslation(0.849f, 52.831f, 2.174f);
      this.hatMatrix[9, 9] = Matrix.CreateRotationZ(-0.04f) * Matrix.CreateRotationY(6.41f) * Matrix.CreateRotationX(-0.032f) * Matrix.CreateScale(0.512f) * Matrix.CreateTranslation(0.154f, 51.673f, 2.431f);
      this.hatMatrix[9, 10] = Matrix.CreateRotationZ(-0.06f) * Matrix.CreateRotationY(-0.04f) * Matrix.CreateRotationX(-0.096f) * Matrix.CreateScale(0.732f) * Matrix.CreateTranslation(0.173f, 52.535f, 1.964f);
      this.hatMatrix[9, 11] = Matrix.CreateRotationZ(-0.56f) * Matrix.CreateRotationY(-0.191f) * Matrix.CreateRotationX(-0.037f) * Matrix.CreateScale(0.247f) * Matrix.CreateTranslation(0.849f, 52.831f, 2.174f);
      this.hatMatrix[9, 12] = this.hatMatrix[9, 2];
      this.hatMatrix[9, 13] = this.hatMatrix[9, 8];
      this.hatMatrix[9, 14] = this.hatMatrix[9, 0];
      this.hatMatrix[10, 0] = Matrix.CreateRotationZ(-0.06f) * Matrix.CreateRotationY(-3f / 1000f) * Matrix.CreateRotationX(-0.018f) * Matrix.CreateScale(0.364f) * Matrix.CreateTranslation(0.603f, 53.857f, 1.474f);
      this.hatMatrix[10, 1] = Matrix.CreateRotationZ(-3f / 500f) * Matrix.CreateRotationY(-0.019f) * Matrix.CreateRotationX(-0.565f) * Matrix.CreateScale(0.477f) * Matrix.CreateTranslation(0.274f, 53.233f, -0.257f);
      this.hatMatrix[10, 2] = Matrix.CreateRotationZ(-0.08f) * Matrix.CreateRotationY(0.02f) * Matrix.CreateRotationX(-0.08f) * Matrix.CreateScale(1.244f) * Matrix.CreateTranslation(0.188f, 51.73f, 1.03f);
      this.hatMatrix[10, 3] = Matrix.CreateRotationZ(-0.08f) * Matrix.CreateRotationY(0.121f) * Matrix.CreateRotationX(0.134f) * Matrix.CreateScale(0.855f) * Matrix.CreateTranslation(0.098f, 53.298f, 1.645f);
      this.hatMatrix[10, 4] = Matrix.CreateRotationZ(-0.091f) * Matrix.CreateRotationY(-0.406f) * Matrix.CreateRotationX(0.287f) * Matrix.CreateScale(0.494f) * Matrix.CreateTranslation(0.834f, 53.76f, 1.535f);
      this.hatMatrix[10, 5] = Matrix.CreateRotationZ(0.256f) * Matrix.CreateRotationY(6.307f) * Matrix.CreateRotationX(-0.304f) * Matrix.CreateScale(0.916f) * Matrix.CreateTranslation(0.101f, 51.522f, 0.847f);
      this.hatMatrix[10, 6] = Matrix.CreateRotationZ(-0.064f) * Matrix.CreateRotationY(-0.016f) * Matrix.CreateRotationX(0.178f) * Matrix.CreateScale(1.187f) * Matrix.CreateTranslation(0.017f, 46.788f, 2.261f);
      this.hatMatrix[10, 7] = Matrix.CreateRotationZ(-0.05f) * Matrix.CreateRotationY(0.105f) * Matrix.CreateRotationX(0.037f) * Matrix.CreateScale(0.927f) * Matrix.CreateTranslation(0.417f, 48.328f, 3.541f);
      this.hatMatrix[10, 8] = Matrix.CreateRotationZ(-0.118f) * Matrix.CreateRotationY(-0.168f) * Matrix.CreateRotationX(0.09f) * Matrix.CreateScale(0.742f) * Matrix.CreateTranslation(0.817f, 53.551f, 1.557f);
      this.hatMatrix[10, 9] = Matrix.CreateRotationZ(-0.04f) * Matrix.CreateRotationY(6.41f) * Matrix.CreateRotationX(-0.13f) * Matrix.CreateScale(0.946f) * Matrix.CreateTranslation(0.189f, 51.33f, 1.79f);
      this.hatMatrix[10, 10] = Matrix.CreateRotationZ(-0.06f) * Matrix.CreateRotationY(0.056f) * Matrix.CreateRotationX(-0.203f) * Matrix.CreateScale(1.108f) * Matrix.CreateTranslation(0.408f, 52.712f, 1.04f);
      this.hatMatrix[10, 11] = Matrix.CreateRotationZ(-0.118f) * Matrix.CreateRotationY(-0.168f) * Matrix.CreateRotationX(0.09f) * Matrix.CreateScale(0.742f) * Matrix.CreateTranslation(0.817f, 53.551f, 1.557f);
      this.hatMatrix[10, 12] = this.hatMatrix[10, 2];
      this.hatMatrix[10, 13] = this.hatMatrix[10, 8];
      this.hatMatrix[10, 14] = this.hatMatrix[10, 0];
    }

    public void setTempHatMatrix(ref Matrix[,] hatMatrix)
    {
      int gameNpc = this.gameNPC;
      this.gameNPC = 0;
      this.hatindex = 1;
      hatMatrix[0, 0] = this.CreateRotationZ(-0.06f) * this.CreateRotationY(-0.05f) * this.CreateRotationX(-0.1f) * this.CreateScale(0.9f) * this.CreateTranslation(0.447f, 52.717f, 1.22f);
      hatMatrix[0, 1] = this.CreateRotationZ(-0.118f) * this.CreateRotationY(0.158f) * this.CreateRotationX(-0.117f) * this.CreateScale(1.07f) * this.CreateTranslation(0.455f, 51.295f, 1.425f);
      hatMatrix[0, 2] = this.CreateRotationZ(-0.119f) * this.CreateRotationY(0.022f) * this.CreateRotationX(0.053f) * this.CreateScale(1.13f) * this.CreateTranslation(0.56f, 50.96f, 1.03f);
      hatMatrix[0, 3] = this.CreateRotationZ(-0.156f) * this.CreateRotationY(0.177f) * this.CreateRotationX(-0.149f) * this.CreateScale(1.034f) * this.CreateTranslation(0.531f, 52.27f, 1.055f);
      hatMatrix[0, 4] = this.CreateRotationZ(-0.123f) * this.CreateRotationY(0.176f) * this.CreateRotationX(-0.216f) * this.CreateScale(1.18f) * this.CreateTranslation(0.64f, 51.279f, 2.141f);
      hatMatrix[0, 5] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1.06f) * this.CreateTranslation(0.7f, 50.6f, 2.2f);
      hatMatrix[0, 6] = this.CreateRotationZ(-0.197f) * this.CreateRotationY(0.121f) * this.CreateRotationX(0.35f) * this.CreateScale(1.01f) * this.CreateTranslation(3f / 500f, 48.432f, 2.28f);
      hatMatrix[0, 7] = this.CreateRotationZ(-0.11f) * this.CreateRotationY(0.074f) * this.CreateRotationX(-0.05f) * this.CreateScale(0.85f) * this.CreateTranslation(0.96f, 48.29f, 3.713f);
      hatMatrix[0, 8] = this.CreateRotationZ(-0.08f) * this.CreateRotationY(0.02f) * this.CreateRotationX(-0.09f) * this.CreateScale(0.9f) * this.CreateTranslation(0.65f, 52.49f, 1.28f);
      hatMatrix[0, 9] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1.06f) * this.CreateTranslation(0.17f, 50.52f, 2.2f);
      hatMatrix[0, 10] = this.CreateRotationZ(-0.08f) * this.CreateRotationY(0.21f) * this.CreateRotationX(-0.16f) * this.CreateScale(1.01f) * this.CreateTranslation(0.67f, 52.19f, 1.27f);
      hatMatrix[0, 11] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(0.9f) * this.CreateTranslation(1f, 52.9f, 1.5f);
      hatMatrix[0, 12] = hatMatrix[0, 2];
      hatMatrix[0, 13] = hatMatrix[0, 8];
      hatMatrix[0, 14] = hatMatrix[0, 0];
      this.gameNPC = 1;
      this.hatindex = 1;
      hatMatrix[1, 0] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1f) * this.CreateTranslation(0.4f, 51.1f, 1.5f);
      hatMatrix[1, 1] = this.CreateRotationZ(-0.15f) * this.CreateRotationY(0.08f) * this.CreateRotationX(0.02f) * this.CreateScale(0.98f) * this.CreateTranslation(0.49f, 50.8f, 1.4f);
      hatMatrix[1, 2] = this.CreateRotationZ(-0.078f) * this.CreateRotationY(1f / 1000f) * this.CreateRotationX(-0.01f) * this.CreateScale(0.96f) * this.CreateTranslation(0.5f, 50.6f, 1.5f);
      hatMatrix[1, 3] = this.CreateRotationZ(-0.133f) * this.CreateRotationY(0.11f) * this.CreateRotationX(-0.043f) * this.CreateScale(1f) * this.CreateTranslation(0.4f, 51.1f, 1.5f);
      hatMatrix[1, 4] = this.CreateRotationZ(-0.066f) * this.CreateRotationY(0.12f) * this.CreateRotationX(-0.036f) * this.CreateScale(1.102f) * this.CreateTranslation(0.381f, 50.635f, 1.874f);
      hatMatrix[1, 5] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(0.94f) * this.CreateTranslation(0.7f, 50.7f, 2.09f);
      hatMatrix[1, 6] = this.CreateRotationZ(-0.179f) * this.CreateRotationY(0.093f) * this.CreateRotationX(0.19f) * this.CreateScale(0.93f) * this.CreateTranslation(0.03f, 48.19f, 2.457f);
      hatMatrix[1, 7] = this.CreateRotationZ(-0.145f) * this.CreateRotationY(0.074f) * this.CreateRotationX(-0.093f) * this.CreateScale(0.92f) * this.CreateTranslation(0.1f, 48.2f, 3.618f);
      hatMatrix[1, 8] = this.CreateRotationZ(-0.13f) * this.CreateRotationY(0.03f) * this.CreateRotationX(-0.03f) * this.CreateScale(0.89f) * this.CreateTranslation(0.4f, 51.1f, 1.5f);
      hatMatrix[1, 9] = this.CreateRotationZ(0.0f) * this.CreateRotationY(-0.02f) * this.CreateRotationX(-0.08f) * this.CreateScale(0.9f) * this.CreateTranslation(0.422f, 50.533f, 2.278f);
      hatMatrix[1, 10] = this.CreateRotationZ(-0.14f) * this.CreateRotationY(0.13f) * this.CreateRotationX(-0.13f) * this.CreateScale(0.98f) * this.CreateTranslation(0.56f, 51.63f, 1.5f);
      hatMatrix[1, 11] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(0.9f) * this.CreateTranslation(1f, 52.9f, 1.5f);
      hatMatrix[1, 12] = hatMatrix[1, 2];
      hatMatrix[1, 13] = hatMatrix[1, 8];
      hatMatrix[1, 14] = hatMatrix[1, 0];
      this.gameNPC = 2;
      this.hatindex = 1;
      hatMatrix[2, 0] = this.CreateRotationZ(-0.073f) * this.CreateRotationY(0.015f) * this.CreateRotationX(-0.101f) * this.CreateScale(1.02f) * this.CreateTranslation(-0.015f, 51.327f, 1.335f);
      hatMatrix[2, 1] = this.CreateRotationZ(-0.016f) * this.CreateRotationY(0.004f) * this.CreateRotationX(-0.177f) * this.CreateScale(0.92f) * this.CreateTranslation(0.1f, 51.3f, 1.2f);
      hatMatrix[2, 2] = this.CreateRotationZ(-0.052f) * this.CreateRotationY(0.071f) * this.CreateRotationX(-0.01f) * this.CreateScale(1f) * this.CreateTranslation(0.0f, 50.9f, 1.2f);
      hatMatrix[2, 3] = this.CreateRotationZ(-0.14f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1.02f) * this.CreateTranslation(0.1f, 51.4f, 1.5f);
      hatMatrix[2, 4] = this.CreateRotationZ(-0.025f) * this.CreateRotationY(0.087f) * this.CreateRotationX(-0.092f) * this.CreateScale(1.02f) * this.CreateTranslation(-0.005f, 51.2f, 1.613f);
      hatMatrix[2, 5] = this.CreateRotationZ(-0.14f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(0.9f) * this.CreateTranslation(0.2f, 50.7f, 2f);
      hatMatrix[2, 6] = this.CreateRotationZ(-0.004f) * this.CreateRotationY(0.075f) * this.CreateRotationX(0.11f) * this.CreateScale(0.94f) * this.CreateTranslation(0.0f, 48.3f, 2.4f);
      hatMatrix[2, 7] = this.CreateRotationZ(-0.14f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(0.94f) * this.CreateTranslation(0.0f, 48.3f, 3.613f);
      hatMatrix[2, 8] = this.CreateRotationZ(0.01f) * this.CreateRotationY(-0.15f) * this.CreateRotationX(-0.09f) * this.CreateScale(0.86f) * this.CreateTranslation(0.1f, 51.4f, 1.31f);
      hatMatrix[2, 9] = this.CreateRotationZ(-0.14f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(0.9f) * this.CreateTranslation(-0.111f, 50.152f, 2.238f);
      hatMatrix[2, 10] = this.CreateRotationZ(-0.02f) * this.CreateRotationY(0.07f) * this.CreateRotationX(-0.14f) * this.CreateScale(1.02f) * this.CreateTranslation(-0.09f, 51.18f, 1.243f);
      hatMatrix[2, 11] = this.CreateRotationZ(-0.14f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(0.9f) * this.CreateTranslation(1f, 52.9f, 1.5f);
      hatMatrix[2, 12] = hatMatrix[2, 2];
      hatMatrix[2, 13] = hatMatrix[2, 8];
      hatMatrix[2, 14] = hatMatrix[2, 0];
      this.gameNPC = 3;
      this.hatindex = 1;
      hatMatrix[3, 0] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1.02f) * this.CreateTranslation(0.6f, 52.5f, 1f);
      hatMatrix[3, 1] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1f) * this.CreateTranslation(0.6f, 51.8f, 0.7f);
      hatMatrix[3, 2] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1.02f) * this.CreateTranslation(0.6f, 51.6f, 0.9f);
      hatMatrix[3, 3] = this.CreateRotationZ(-0.08f) * this.CreateRotationY(0.03f) * this.CreateRotationX(-0.22f) * this.CreateScale(1.07f) * this.CreateTranslation(0.6f, 52f, 1.05f);
      hatMatrix[3, 4] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1.1f) * this.CreateTranslation(0.6f, 51.9f, 1.8f);
      hatMatrix[3, 5] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(0.9f) * this.CreateTranslation(0.6f, 52f, 1.4f);
      hatMatrix[3, 6] = this.CreateRotationZ(-0.129f) * this.CreateRotationY(-11f / 1000f) * this.CreateRotationX(0.111f) * this.CreateScale(0.96f) * this.CreateTranslation(0.2f, 48.8f, 2.2f);
      hatMatrix[3, 7] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(0.96f) * this.CreateTranslation(0.2f, 48.8f, 2.2f);
      hatMatrix[3, 8] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(0.892f) * this.CreateTranslation(0.553f, 52.556f, 0.966f);
      hatMatrix[3, 9] = this.CreateRotationZ(0.0f) * this.CreateRotationY(-0.13f) * this.CreateRotationX(-0.3f) * this.CreateScale(0.97f) * this.CreateTranslation(0.46f, 51f, 1.95f);
      hatMatrix[3, 10] = this.CreateRotationZ(-0.1f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(0.97f) * this.CreateTranslation(0.6f, 52.33f, 1.13f);
      hatMatrix[3, 11] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(0.9f) * this.CreateTranslation(1f, 52.9f, 1.5f);
      hatMatrix[3, 12] = hatMatrix[3, 2];
      hatMatrix[3, 13] = hatMatrix[3, 8];
      hatMatrix[3, 14] = hatMatrix[3, 0];
      this.gameNPC = 4;
      this.hatindex = 1;
      hatMatrix[4, 0] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1.06f) * this.CreateTranslation(0.514f, 51.891f, 2.25f);
      hatMatrix[4, 1] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1.06f) * this.CreateTranslation(0.7f, 51.3f, 1.5f);
      hatMatrix[4, 2] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1.06f) * this.CreateTranslation(0.7f, 51.1f, 2f);
      hatMatrix[4, 3] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1.06f) * this.CreateTranslation(0.7f, 52f, 2.2f);
      hatMatrix[4, 4] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1.1f) * this.CreateTranslation(0.6f, 51.5f, 2.6f);
      hatMatrix[4, 5] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(-0.279f) * this.CreateScale(1.026f) * this.CreateTranslation(0.812f, 50.808f, 2.632f);
      hatMatrix[4, 6] = this.CreateRotationZ(-0.13f) * this.CreateRotationY(0.03f) * this.CreateRotationX(0.1f) * this.CreateScale(1.01f) * this.CreateTranslation(0.4f, 48.34f, 3.1f);
      hatMatrix[4, 7] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(0.98f) * this.CreateTranslation(0.4f, 48.4f, 3.1f);
      hatMatrix[4, 8] = this.CreateRotationZ(-0.092f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.129f) * this.CreateScale(0.885f) * this.CreateTranslation(0.788f, 52.403f, 2.157f);
      hatMatrix[4, 9] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1.06f) * this.CreateTranslation(0.68f, 50.43f, 2.7f);
      hatMatrix[4, 10] = this.CreateRotationZ(-0.08f) * this.CreateRotationY(0.02f) * this.CreateRotationX(-0.02f) * this.CreateScale(1.06f) * this.CreateTranslation(0.8f, 52.05f, 1.67f);
      hatMatrix[4, 11] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(0.9f) * this.CreateTranslation(1f, 52.9f, 1.5f);
      hatMatrix[4, 12] = hatMatrix[4, 2];
      hatMatrix[4, 13] = hatMatrix[4, 8];
      hatMatrix[4, 14] = hatMatrix[4, 0];
      this.gameNPC = 5;
      this.hatindex = 1;
      hatMatrix[5, 0] = this.CreateRotationZ(-0.056f) * this.CreateRotationY(0.012f) * this.CreateRotationX(0.093f) * this.CreateScale(1.1f) * this.CreateTranslation(0.1f, 52.8f, 1.4f);
      hatMatrix[5, 1] = this.CreateRotationZ(0.0f) * this.CreateRotationY(-0.03f) * this.CreateRotationX(-0.07f) * this.CreateScale(0.94f) * this.CreateTranslation(0.0f, 52.9f, 1.27f);
      hatMatrix[5, 2] = this.CreateRotationZ(0.01f) * this.CreateRotationY(0.0f) * this.CreateRotationX(-0.06f) * this.CreateScale(1.07f) * this.CreateTranslation(0.19f, 52.61f, 1.53f);
      hatMatrix[5, 3] = this.CreateRotationZ(-0.05f) * this.CreateRotationY(0.04f) * this.CreateRotationX(-0.29f) * this.CreateScale(1.1f) * this.CreateTranslation(-0.05f, 52.54f, 1.47f);
      hatMatrix[5, 4] = this.CreateRotationZ(-0.04f) * this.CreateRotationY(0.06f) * this.CreateRotationX(0.07f) * this.CreateScale(1.15f) * this.CreateTranslation(-0.04f, 52.1f, 2f);
      hatMatrix[5, 5] = this.CreateRotationZ(-0.14f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1.02f) * this.CreateTranslation(0.2f, 51.9f, 1.9f);
      hatMatrix[5, 6] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.06f) * this.CreateScale(0.94f) * this.CreateTranslation(-0.1f, 49.4f, 2.38f);
      hatMatrix[5, 7] = this.CreateRotationZ(-0.14f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(0.94f) * this.CreateTranslation(-0.1f, 49.4f, 2.6f);
      hatMatrix[5, 8] = this.CreateRotationZ(-0.01f) * this.CreateRotationY(0.19f) * this.CreateRotationX(0.05f) * this.CreateScale(0.94f) * this.CreateTranslation(0.1f, 52.8f, 1.4f);
      hatMatrix[5, 9] = this.CreateRotationZ(0.01f) * this.CreateRotationY(-0.07f) * this.CreateRotationX(0.04f) * this.CreateScale(1.02f) * this.CreateTranslation(-0.17f, 51.55f, 1.9f);
      hatMatrix[5, 10] = this.CreateRotationZ(0.05f) * this.CreateRotationY(0.06f) * this.CreateRotationX(-0.1f) * this.CreateScale(1.15f) * this.CreateTranslation(0.01f, 53.11f, 1.7f);
      hatMatrix[5, 11] = this.CreateRotationZ(-0.14f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(0.9f) * this.CreateTranslation(1f, 52.9f, 1.5f);
      hatMatrix[5, 12] = hatMatrix[5, 2];
      hatMatrix[5, 13] = hatMatrix[5, 8];
      hatMatrix[5, 14] = hatMatrix[5, 0];
      this.gameNPC = 6;
      this.hatindex = 1;
      hatMatrix[6, 0] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(0.84f) * this.CreateTranslation(0.6f, 51.4f, 2.2f);
      hatMatrix[6, 1] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1.06f) * this.CreateTranslation(0.7f, 51.3f, 1.5f);
      hatMatrix[6, 2] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1.06f) * this.CreateTranslation(0.7f, 51.1f, 2f);
      hatMatrix[6, 3] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1.06f) * this.CreateTranslation(0.7f, 52f, 2.2f);
      hatMatrix[6, 4] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1.1f) * this.CreateTranslation(0.6f, 51.5f, 2.6f);
      hatMatrix[6, 5] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1.06f) * this.CreateTranslation(0.7f, 50.6f, 2.7f);
      hatMatrix[6, 6] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(0.98f) * this.CreateTranslation(0.4f, 48.4f, 3.1f);
      hatMatrix[6, 7] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(0.94f) * this.CreateTranslation(0.2f, 48.5f, 3.1f);
      hatMatrix[6, 8] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(0.84f) * this.CreateTranslation(0.6f, 51.4f, 2.2f);
      hatMatrix[6, 9] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1.06f) * this.CreateTranslation(0.7f, 50.6f, 2.7f);
      hatMatrix[6, 10] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1.06f) * this.CreateTranslation(0.7f, 52f, 2.2f);
      hatMatrix[6, 11] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(0.9f) * this.CreateTranslation(1f, 52.9f, 1.5f);
      hatMatrix[6, 12] = hatMatrix[6, 2];
      hatMatrix[6, 13] = hatMatrix[6, 8];
      hatMatrix[6, 14] = hatMatrix[6, 0];
      this.gameNPC = 7;
      this.hatindex = 1;
      hatMatrix[7, 0] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1.1f) * this.CreateTranslation(0.1f, 52.8f, 1.4f);
      hatMatrix[7, 1] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(0.94f) * this.CreateTranslation(0.0f, 52.9f, 1f);
      hatMatrix[7, 2] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1f) * this.CreateTranslation(0.0f, 52.9f, 1f);
      hatMatrix[7, 3] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1.1f) * this.CreateTranslation(0.1f, 52.8f, 1.4f);
      hatMatrix[7, 4] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1.1f) * this.CreateTranslation(0.1f, 52.1f, 2f);
      hatMatrix[7, 5] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1.02f) * this.CreateTranslation(0.2f, 51.9f, 1.9f);
      hatMatrix[7, 6] = this.CreateRotationZ(-0.05f) * this.CreateRotationY(0.02f) * this.CreateRotationX(0.13f) * this.CreateScale(0.94f) * this.CreateTranslation(-0.1f, 49.4f, 2.6f);
      hatMatrix[7, 7] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(0.94f) * this.CreateTranslation(-0.1f, 49.4f, 2.6f);
      hatMatrix[7, 8] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.217f) * this.CreateScale(0.588f) * this.CreateTranslation(0.1f, 53.567f, 1.635f);
      hatMatrix[7, 9] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1.02f) * this.CreateTranslation(-0.21f, 50.87f, 2.28f);
      hatMatrix[7, 10] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(0.97f) * this.CreateTranslation(-0.05f, 52.6f, 1.4f);
      hatMatrix[7, 11] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(0.9f) * this.CreateTranslation(1f, 52.9f, 1.5f);
      hatMatrix[7, 12] = hatMatrix[7, 2];
      hatMatrix[7, 13] = hatMatrix[7, 8];
      hatMatrix[7, 14] = hatMatrix[7, 0];
      this.gameNPC = 8;
      this.hatindex = 1;
      hatMatrix[8, 0] = this.CreateRotationZ(-0.06f) * this.CreateRotationY(0.21f) * this.CreateRotationX(0.11f) * this.CreateScale(1.15f) * this.CreateTranslation(0.62f, 54.41f, 0.39f);
      hatMatrix[8, 1] = this.CreateRotationZ(-0.04f) * this.CreateRotationY(0.19f) * this.CreateRotationX(0.03f) * this.CreateScale(1.22f) * this.CreateTranslation(0.59f, 54.45f, -0.44f);
      hatMatrix[8, 2] = this.CreateRotationZ(-0.08f) * this.CreateRotationY(0.22f) * this.CreateRotationX(-0.08f) * this.CreateScale(1.82f) * this.CreateTranslation(0.55f, 51.63f, 0.25f);
      hatMatrix[8, 3] = this.CreateRotationZ(-0.08f) * this.CreateRotationY(0.25f) * this.CreateRotationX(0.2f) * this.CreateScale(1.3f) * this.CreateTranslation(0.99f, 55.06f, 1.2f);
      hatMatrix[8, 4] = this.CreateRotationZ(-0.1f) * this.CreateRotationY(0.15f) * this.CreateRotationX(0.23f) * this.CreateScale(1.66f) * this.CreateTranslation(0.92f, 54.35f, 0.24f);
      hatMatrix[8, 5] = this.CreateRotationZ(0.05f) * this.CreateRotationY(6.49f) * this.CreateRotationX(-0.19f) * this.CreateScale(1.52f) * this.CreateTranslation(0.71f, 52.19f, 0.33f);
      hatMatrix[8, 6] = this.CreateRotationZ(-0.07f) * this.CreateRotationY(0.22f) * this.CreateRotationX(0.06f) * this.CreateScale(1.92f) * this.CreateTranslation(0.98f, 46.53f, 2.19f);
      hatMatrix[8, 7] = this.CreateRotationZ(-0.05f) * this.CreateRotationY(0.19f) * this.CreateRotationX(-0.18f) * this.CreateScale(1.2f) * this.CreateTranslation(0.49f, 48.13f, 2.92f);
      hatMatrix[8, 8] = this.CreateRotationZ(-0.118f) * this.CreateRotationY(0.555f) * this.CreateRotationX(0.09f) * this.CreateScale(0.588f) * this.CreateTranslation(0.615f, 54.355f, 0.733f);
      hatMatrix[8, 9] = this.CreateRotationZ(-0.04f) * this.CreateRotationY(6.41f) * this.CreateRotationX(-0.13f) * this.CreateScale(1.52f) * this.CreateTranslation(0.64f, 51.33f, 1.79f);
      hatMatrix[8, 10] = this.CreateRotationZ(-0.06f) * this.CreateRotationY(0.22f) * this.CreateRotationX(0.0f) * this.CreateScale(1.3f) * this.CreateTranslation(0.93f, 54.83f, 1.04f);
      hatMatrix[8, 11] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1f) * this.CreateTranslation(1f, 52.77f, 1f);
      hatMatrix[8, 12] = hatMatrix[8, 2];
      hatMatrix[8, 13] = hatMatrix[8, 8];
      hatMatrix[8, 14] = hatMatrix[8, 0];
      this.gameNPC = 9;
      this.hatindex = 1;
      hatMatrix[9, 0] = this.CreateRotationZ(-0.06f) * this.CreateRotationY(0.037f) * this.CreateRotationX(-0.007f) * this.CreateScale(0.351f) * this.CreateTranslation(0.207f, 53.021f, 1.758f);
      hatMatrix[9, 1] = this.CreateRotationZ(-0.04f) * this.CreateRotationY(0.092f) * this.CreateRotationX(-0.177f) * this.CreateScale(0.388f) * this.CreateTranslation(0.138f, 52.637f, 1.519f);
      hatMatrix[9, 2] = this.CreateRotationZ(-11f / 1000f) * this.CreateRotationY(0.033f) * this.CreateRotationX(-0.371f) * this.CreateScale(0.805f) * this.CreateTranslation(0.192f, 51.125f, 0.674f);
      hatMatrix[9, 3] = this.CreateRotationZ(-0.108f) * this.CreateRotationY(0.063f) * this.CreateRotationX(-1f / 1000f) * this.CreateScale(0.543f) * this.CreateTranslation(0.241f, 52.212f, 1.986f);
      hatMatrix[9, 4] = this.CreateRotationZ(-0.064f) * this.CreateRotationY(0.031f) * this.CreateRotationX(0.112f) * this.CreateScale(0.612f) * this.CreateTranslation(0.152f, 51.922f, 2.251f);
      hatMatrix[9, 5] = this.CreateRotationZ(0.05f) * this.CreateRotationY(6.26f) * this.CreateRotationX(0.035f) * this.CreateScale(0.473f) * this.CreateTranslation(0.296f, 51.88f, 2.275f);
      hatMatrix[9, 6] = this.CreateRotationZ(-0.055f) * this.CreateRotationY(-0.053f) * this.CreateRotationX(-0.211f) * this.CreateScale(1.048f) * this.CreateTranslation(0.158f, 47.864f, 2.599f);
      hatMatrix[9, 7] = this.CreateRotationZ(-0.167f) * this.CreateRotationY(0.01f) * this.CreateRotationX(-0.01f) * this.CreateScale(0.75f) * this.CreateTranslation(0.007f, 47.829f, 4.321f);
      hatMatrix[9, 8] = this.CreateRotationZ(-0.56f) * this.CreateRotationY(-0.191f) * this.CreateRotationX(-0.037f) * this.CreateScale(0.247f) * this.CreateTranslation(0.849f, 52.831f, 2.174f);
      hatMatrix[9, 9] = this.CreateRotationZ(-0.04f) * this.CreateRotationY(6.41f) * this.CreateRotationX(-0.032f) * this.CreateScale(0.512f) * this.CreateTranslation(0.154f, 51.673f, 2.431f);
      hatMatrix[9, 10] = this.CreateRotationZ(-0.06f) * this.CreateRotationY(-0.04f) * this.CreateRotationX(-0.096f) * this.CreateScale(0.732f) * this.CreateTranslation(0.173f, 52.535f, 1.964f);
      hatMatrix[9, 11] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1f) * this.CreateTranslation(1f, 52.77f, 1f);
      hatMatrix[9, 12] = hatMatrix[9, 2];
      hatMatrix[9, 13] = hatMatrix[9, 8];
      hatMatrix[9, 14] = hatMatrix[9, 0];
      this.gameNPC = 10;
      this.hatindex = 1;
      hatMatrix[10, 0] = this.CreateRotationZ(-0.06f) * this.CreateRotationY(-3f / 1000f) * this.CreateRotationX(-0.018f) * this.CreateScale(0.364f) * this.CreateTranslation(0.603f, 53.857f, 1.474f);
      hatMatrix[10, 1] = this.CreateRotationZ(-3f / 500f) * this.CreateRotationY(-0.019f) * this.CreateRotationX(-0.565f) * this.CreateScale(0.477f) * this.CreateTranslation(0.274f, 53.233f, -0.257f);
      hatMatrix[10, 2] = this.CreateRotationZ(-0.08f) * this.CreateRotationY(0.02f) * this.CreateRotationX(-0.08f) * this.CreateScale(1.244f) * this.CreateTranslation(0.188f, 51.73f, 1.03f);
      hatMatrix[10, 3] = this.CreateRotationZ(-0.08f) * this.CreateRotationY(0.121f) * this.CreateRotationX(0.134f) * this.CreateScale(0.855f) * this.CreateTranslation(0.098f, 53.298f, 1.645f);
      hatMatrix[10, 4] = this.CreateRotationZ(-0.091f) * this.CreateRotationY(-0.406f) * this.CreateRotationX(0.287f) * this.CreateScale(0.494f) * this.CreateTranslation(0.834f, 53.76f, 1.535f);
      hatMatrix[10, 5] = this.CreateRotationZ(0.256f) * this.CreateRotationY(6.307f) * this.CreateRotationX(-0.304f) * this.CreateScale(0.916f) * this.CreateTranslation(0.101f, 51.522f, 0.847f);
      hatMatrix[10, 6] = this.CreateRotationZ(-0.064f) * this.CreateRotationY(-0.016f) * this.CreateRotationX(0.178f) * this.CreateScale(1.187f) * this.CreateTranslation(0.017f, 46.788f, 2.261f);
      hatMatrix[10, 7] = this.CreateRotationZ(-0.05f) * this.CreateRotationY(0.105f) * this.CreateRotationX(0.037f) * this.CreateScale(0.927f) * this.CreateTranslation(0.417f, 48.328f, 3.541f);
      hatMatrix[10, 8] = this.CreateRotationZ(-0.118f) * this.CreateRotationY(-0.168f) * this.CreateRotationX(0.09f) * this.CreateScale(0.742f) * this.CreateTranslation(0.817f, 53.551f, 1.557f);
      hatMatrix[10, 9] = this.CreateRotationZ(-0.04f) * this.CreateRotationY(6.41f) * this.CreateRotationX(-0.13f) * this.CreateScale(0.946f) * this.CreateTranslation(0.189f, 51.33f, 1.79f);
      hatMatrix[10, 10] = this.CreateRotationZ(-0.06f) * this.CreateRotationY(0.056f) * this.CreateRotationX(-0.203f) * this.CreateScale(1.108f) * this.CreateTranslation(0.408f, 52.712f, 1.04f);
      hatMatrix[10, 11] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.0f) * this.CreateRotationX(0.0f) * this.CreateScale(1f) * this.CreateTranslation(1f, 52.77f, 1f);
      hatMatrix[10, 12] = hatMatrix[10, 2];
      hatMatrix[10, 13] = hatMatrix[10, 8];
      hatMatrix[10, 14] = this.CreateRotationZ(0.0f) * this.CreateRotationY(0.18f) * this.CreateRotationX(0.0f) * this.CreateScale(1f) * this.CreateTranslation(1f, 52.94f, 1f);
      this.gameNPC = gameNpc;
    }

    public Matrix CreateRotationZ(float z)
    {
      if ((double) this.hatTrigger.X != -1.0 && (int) this.hatTrigger.X != this.gameNPC && (int) this.hatTrigger.Y != this.hatindex)
        return Matrix.CreateRotationZ(z);
      this.hatRotX[this.gameNPC, this.hatindex - 1].Z = z;
      return Matrix.CreateRotationZ(z);
    }

    public Matrix CreateRotationY(float y)
    {
      if ((double) this.hatTrigger.X != -1.0 && (int) this.hatTrigger.X != this.gameNPC && (int) this.hatTrigger.Y != this.hatindex)
        return Matrix.CreateRotationY(y);
      this.hatRotX[this.gameNPC, this.hatindex - 1].Y = y;
      return Matrix.CreateRotationY(y);
    }

    public Matrix CreateRotationX(float x)
    {
      if ((double) this.hatTrigger.X != -1.0 && (int) this.hatTrigger.X != this.gameNPC && (int) this.hatTrigger.Y != this.hatindex)
        return Matrix.CreateRotationX(x);
      this.hatRotX[this.gameNPC, this.hatindex - 1].X = x;
      return Matrix.CreateRotationX(x);
    }

    public Matrix CreateScale(float a)
    {
      if ((double) this.hatTrigger.X != -1.0 && (int) this.hatTrigger.X != this.gameNPC && (int) this.hatTrigger.Y != this.hatindex)
        return Matrix.CreateScale(a);
      this.hatScaleX[this.gameNPC, this.hatindex - 1] = a;
      return Matrix.CreateScale(a);
    }

    public Matrix CreateTranslation(float x, float y, float z)
    {
      if ((double) this.hatTrigger.X != -1.0 && (int) this.hatTrigger.X != this.gameNPC && (int) this.hatTrigger.Y != this.hatindex)
      {
        ++this.hatindex;
        return Matrix.CreateTranslation(new Vector3(x, y, z));
      }
      this.hatTransX[this.gameNPC, this.hatindex - 1] = new Vector3(x, y, z);
      ++this.hatindex;
      if (this.hatindex > 15)
        this.hatindex = 0;
      return Matrix.CreateTranslation(new Vector3(x, y, z));
    }

    public void setBlendState()
    {
      this.brightness = 128;
      this.brightBU = 128;
      this.contrast = 128;
      this.contrastBU = 128;
      this.brightnessUP = new BlendState();
      BlendState brightnessUp1 = this.brightnessUP;
      this.brightnessUP.AlphaSourceBlend = Blend.One;
      brightnessUp1.ColorSourceBlend = Blend.One;
      BlendState brightnessUp2 = this.brightnessUP;
      this.brightnessUP.AlphaDestinationBlend = Blend.One;
      brightnessUp2.ColorDestinationBlend = Blend.One;
      this.brightnessDOWN = new BlendState();
      BlendState brightnessDown1 = this.brightnessDOWN;
      this.brightnessDOWN.AlphaSourceBlend = Blend.Zero;
      brightnessDown1.ColorSourceBlend = Blend.Zero;
      BlendState brightnessDown2 = this.brightnessDOWN;
      this.brightnessDOWN.AlphaDestinationBlend = Blend.SourceColor;
      brightnessDown2.ColorDestinationBlend = Blend.SourceColor;
      this.contrastBlend = new BlendState();
      BlendState contrastBlend1 = this.contrastBlend;
      this.contrastBlend.AlphaSourceBlend = Blend.DestinationColor;
      contrastBlend1.ColorSourceBlend = Blend.DestinationColor;
      BlendState contrastBlend2 = this.contrastBlend;
      this.contrastBlend.AlphaDestinationBlend = Blend.SourceColor;
      contrastBlend2.ColorDestinationBlend = Blend.SourceColor;
    }

    public static RenderTarget2D CopyTexture2D(
      GraphicsDevice gr,
      Texture2D image,
      Rectangle source,
      SpriteBatch sb)
    {
      Rectangle destinationRectangle = new Rectangle(0, 0, source.Width, source.Height);
      RenderTarget2D renderTarget = new RenderTarget2D(gr, source.Width, source.Height, true, SurfaceFormat.Color, DepthFormat.None);
      gr.SetRenderTarget(renderTarget);
      gr.Clear(Color.Transparent);
      sb.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
      sb.Draw(image, destinationRectangle, new Rectangle?(source), Color.White);
      sb.End();
      return renderTarget;
    }

    protected override void UnloadContent()
    {
      foreach (GameScreen screen in this.screens)
        screen.UnloadContent();
    }

    private void DeactivatedEventHandler(object sender, EventArgs e)
    {
      this.awayIndex = this.rr.Next(0, this.away.Length);
      GamePad.SetVibration(PlayerIndex.One, 0.0f, 0.0f);
      GamePad.SetVibration(PlayerIndex.Two, 0.0f, 0.0f);
      GamePad.SetVibration(PlayerIndex.Three, 0.0f, 0.0f);
      GamePad.SetVibration(PlayerIndex.Four, 0.0f, 0.0f);
      this.deactivated = true;
      this.rebuildFog = true;
      this.rebuildTwinSplat = true;
      this.graphics.GraphicsDevice.VertexSamplerStates[0] = SamplerState.PointClamp;
    }

    private void ActivatedEventHandler(object sender, EventArgs e)
    {
      this.graphics.GraphicsDevice.VertexSamplerStates[0] = SamplerState.PointClamp;
      this.deactivated = false;
      this.rebuildTargets = true;
    }

    public override void Update(GameTime gameTime)
    {
      if (SteamAPI.IsSteamRunning())
        SteamAPI.RunCallbacks();
      if (!this.workshop.textureBusy)
      {
        this.trophy.UpdateState();
        if (this.gameState > 0)
        {
          ++this.leaderboardCounter;
          if (this.leaderboardCounter > 1800)
          {
            if (this.leaderboardSelect == 1)
              this.trophy.updateLeaderboards();
            if (this.leaderboardSelect == 2)
              this.trophy.updateLeaderboards2();
            if (this.leaderboardSelect == 3)
              this.trophy.updateLeaderboards3();
            if (this.leaderboardSelect == 4)
              this.trophy.updateLeaderboards4();
            ++this.leaderboardSelect;
            if (this.leaderboardSelect > 4)
              this.leaderboardSelect = 1;
            this.leaderboardCounter = 0;
          }
        }
      }
      this.input.Update();
      this.screensToUpdate.Clear();
      foreach (GameScreen screen in this.screens)
        this.screensToUpdate.Add(screen);
      bool otherScreenHasFocus = !this.Game.IsActive;
      bool coveredByOtherScreen = false;
      while (this.screensToUpdate.Count > 0)
      {
        GameScreen gameScreen = this.screensToUpdate[this.screensToUpdate.Count - 1];
        this.screensToUpdate.RemoveAt(this.screensToUpdate.Count - 1);
        gameScreen.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        if (gameScreen.ScreenState == ScreenState.TransitionOn || gameScreen.ScreenState == ScreenState.Active)
        {
          if (!otherScreenHasFocus)
          {
            gameScreen.HandleInput(this.input);
            otherScreenHasFocus = true;
          }
          if (!gameScreen.IsPopup)
            coveredByOtherScreen = true;
        }
      }
    }

    public override void Draw(GameTime gameTime)
    {
      if (!this.deactivated)
      {
        this.devicex = this.width;
        this.devicey = this.hite;
        if (this.drawViewport && !this.inSpace)
          this.graphics.GraphicsDevice.Viewport = this.myviewport;
        this.viewportx = this.myviewport.Width;
        this.viewporty = this.myviewport.Height;
        foreach (GameScreen screen in this.screens)
        {
          if (screen.ScreenState != ScreenState.Hidden)
            screen.Draw(gameTime);
        }
        this.drawBrightness();
        if (Princess.cuttyCount > 0)
          this.drawRedness();
        if (this.shitContrast != 128)
          this.drawShitness();
        if (this.contrastBU != 128)
          this.drawNuke();
        base.Draw(gameTime);
      }
      else
      {
        this.SpriteBatch.Begin();
        this.SpriteBatch.DrawString(this.grungeFont, this.away[this.awayIndex], new Vector2((float) (this.myviewport.Width / 2), (float) (this.myviewport.Height / 2)) - this.grungeFont.MeasureString(this.away[this.awayIndex]) / 2f, Color.White);
        this.SpriteBatch.End();
      }
      if (this.takepic > 0)
        --this.takepic;
      if (this.takepic == 1)
      {
        try
        {
          int backBufferWidth = this.GraphicsDevice.PresentationParameters.BackBufferWidth;
          int backBufferHeight = this.GraphicsDevice.PresentationParameters.BackBufferHeight;
          int[] data = new int[backBufferWidth * backBufferHeight];
          this.graphics.GraphicsDevice.GetBackBufferData<int>(data);
          Texture2D texture2D = new Texture2D(this.graphics.GraphicsDevice, backBufferWidth, backBufferHeight, false, this.graphics.GraphicsDevice.PresentationParameters.BackBufferFormat);
          texture2D.SetData<int>(data);
          if (!Directory.Exists("World"))
            Directory.CreateDirectory("World");
          Stream stream = (Stream) File.OpenWrite(this.scrnfilename);
          texture2D.SaveAsJpeg(stream, 478, 277);
          stream.Dispose();
          texture2D.Dispose();
          this.takepic = 0;
        }
        catch
        {
          this.takepic = 0;
        }
        this.takepic = 0;
      }
      if (this.takepic != 4)
        return;
      try
      {
        RenderTarget2D renderTarget = new RenderTarget2D(this.GraphicsDevice, 250, 250, true, SurfaceFormat.Color, DepthFormat.None, 2, RenderTargetUsage.DiscardContents);
        this.GraphicsDevice.SetRenderTarget(renderTarget);
        this.GraphicsDevice.Clear(new Color(32, 46, 95, (int) byte.MaxValue));
        this.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.LinearWrap, (DepthStencilState) null, (RasterizerState) null);
        if (this.formDrawBG)
          this.SpriteBatch.Draw(this.whiteTexture, new Rectangle(0, 0, 250, 250), this.color_0[this.formBGColorIndex]);
        this.SpriteBatch.Draw(this.crosshair1[this.crossIndex].texture, new Rectangle(0, 0, 250, 250), new Rectangle?(this.zoomRectangle), Color.White);
        if (this.formDrawBand)
        {
          this.SpriteBatch.Draw(this.titleHeaderWorkshopPublish2, this.formBandL, new Rectangle?(this.formBand), this.formBandColor[this.formBandColorIndex]);
          if (this.workshop.formMark != "")
            this.SpriteBatch.DrawString(this.font3, this.workshop.formMark, new Vector2(37f, 37f), Color.Black, -0.78539f, this.font3.MeasureString(this.workshop.formMark) / 2f, 1f, SpriteEffects.None, 0.0f);
        }
        this.SpriteBatch.End();
        Texture2D texture2D = (Texture2D) renderTarget;
        this.GraphicsDevice.SetRenderTarget((RenderTarget2D) null);
        using (Stream stream = (Stream) File.OpenWrite("image.jpg"))
          texture2D.SaveAsJpeg(stream, 250, 250);
        texture2D.Dispose();
        this.takepic = 0;
        this.workshop.createNewItem();
      }
      catch
      {
        this.takepic = 0;
      }
      this.takepic = 0;
      this.workshop.showPublishbox = false;
    }

    public void drawBrightness()
    {
      int x = 0;
      int y = 0;
      if (this.protectScreen)
      {
        x = this.myviewport.X;
        y = this.myviewport.Y;
      }
      if (!this.inSpace)
      {
        if (this.brightness == 128 && this.contrast == 128)
          return;
        if (this.brightness > 128)
        {
          this.SpriteBatch.Begin(SpriteSortMode.Deferred, this.brightnessUP);
          this.SpriteBatch.Draw(this.whiteTexture, new Rectangle(x, y, this.myviewport.Width, this.myviewport.Height), new Color(this.brightness - 128, this.brightness - 128, this.brightness - 128, (int) byte.MaxValue));
          this.SpriteBatch.End();
        }
        else
        {
          this.SpriteBatch.Begin(SpriteSortMode.Deferred, this.brightnessDOWN);
          int num = (int) ((float) this.brightness * 1.5f);
          this.SpriteBatch.Draw(this.whiteTexture, new Rectangle(x, y, this.myviewport.Width, this.myviewport.Height), new Color(64 + num, 64 + num, 64 + num, (int) byte.MaxValue));
          this.SpriteBatch.End();
        }
        this.SpriteBatch.Begin(SpriteSortMode.Deferred, this.contrastBlend);
        this.SpriteBatch.Draw(this.whiteTexture, new Rectangle(x, y, this.myviewport.Width, this.myviewport.Height), new Color(this.contrast, this.contrast, this.contrast, (int) byte.MaxValue));
        this.SpriteBatch.End();
      }
      else
      {
        if (this.brightness == 128 && this.contrast == 128)
          return;
        if (this.brightness > 128)
        {
          this.SpriteBatch.Begin(SpriteSortMode.Immediate, this.brightnessUP);
          this.SpriteBatch.Draw(this.whiteTexture, new Rectangle(0, 0, this.GraphicsDevice.Viewport.Width, this.GraphicsDevice.Viewport.Height), new Color(this.brightness - 128, this.brightness - 128, this.brightness - 128, (int) byte.MaxValue));
          this.SpriteBatch.End();
        }
        else
        {
          this.SpriteBatch.Begin(SpriteSortMode.Immediate, this.brightnessDOWN);
          int num = (int) ((float) this.brightness * 1.5f);
          this.SpriteBatch.Draw(this.whiteTexture, new Rectangle(0, 0, this.GraphicsDevice.Viewport.Width, this.GraphicsDevice.Viewport.Height), new Color(64 + num, 64 + num, 64 + num, (int) byte.MaxValue));
          this.SpriteBatch.End();
        }
        this.SpriteBatch.Begin(SpriteSortMode.Immediate, this.contrastBlend);
        this.SpriteBatch.Draw(this.whiteTexture, new Rectangle(0, 0, this.GraphicsDevice.Viewport.Width, this.GraphicsDevice.Viewport.Height), new Color(this.contrast, this.contrast, this.contrast, (int) byte.MaxValue));
        this.SpriteBatch.End();
      }
    }

    public void drawRedness()
    {
      int x = 0;
      int y = 0;
      if (this.protectScreen)
      {
        x = this.myviewport.X;
        y = this.myviewport.Y;
      }
      if (this.redContrast == 128)
        return;
      this.SpriteBatch.Begin(SpriteSortMode.Deferred, this.contrastBlend);
      this.SpriteBatch.Draw(this.whiteTexture, new Rectangle(x, y, this.myviewport.Width, this.myviewport.Height), new Color(128, this.redContrast, this.redContrast, (int) byte.MaxValue));
      this.SpriteBatch.End();
    }

    public void drawShitness()
    {
      int x = 0;
      int y = 0;
      if (this.protectScreen)
      {
        x = this.myviewport.X;
        y = this.myviewport.Y;
      }
      if (this.shitContrast == 128)
        return;
      this.SpriteBatch.Begin(SpriteSortMode.Deferred, this.contrastBlend);
      int num = (int) ((double) (128 - this.shitContrast) * 0.30000001192092896);
      this.SpriteBatch.Draw(this.whiteTexture, new Rectangle(x, y, this.myviewport.Width, this.myviewport.Height), new Color(128 - num, this.shitContrast, 128 - num, (int) byte.MaxValue));
      this.SpriteBatch.End();
    }

    public void drawNuke()
    {
      int x = 0;
      int y = 0;
      if (this.protectScreen)
      {
        x = this.myviewport.X;
        y = this.myviewport.Y;
      }
      if (this.contrastBU == 128)
        return;
      this.SpriteBatch.Begin(SpriteSortMode.Deferred, this.contrastBlend);
      this.SpriteBatch.Draw(this.whiteTexture, new Rectangle(x, y, this.myviewport.Width, this.myviewport.Height), new Color(this.contrastBU, this.contrastBU, 158, (int) byte.MaxValue));
      this.SpriteBatch.End();
    }

    public void AddScreen(GameScreen screen, PlayerIndex? controllingPlayer)
    {
      screen.ControllingPlayer = controllingPlayer;
      screen.ScreenManager = this;
      screen.IsExiting = false;
      if (this.isInitialized)
        screen.LoadContent();
      this.screens.Add(screen);
    }

    public void RemoveScreen(GameScreen screen)
    {
      if (this.isInitialized)
        screen.UnloadContent();
      this.screens.Remove(screen);
      this.screensToUpdate.Remove(screen);
    }

    public GameScreen[] GetScreens() => this.screens.ToArray();

    public bool LoadPrefs()
    {
      this.prefs = this.storagePrefs.LoadPreferences();
      if (this.prefs.fileExists)
      {
        this.fileVersion = this.prefs.fileVersion;
        this.mv = this.prefs.mv;
        this.ev = this.prefs.ev;
        this.vv = this.prefs.vv;
        this.df = this.prefs.df;
        this.df_orig = this.df;
        this.brightness = this.prefs.brightness;
        this.brightBU = this.brightness;
        this.contrast = this.prefs.contrast;
        this.pad_invertY = this.prefs.pad_invertY;
        this.pad_sensitivity = this.prefs.pad_sensitivity;
        this.pad_vibro = this.prefs.pad_vibro;
        this.hud_enemy = this.prefs.hud_enemy;
        this.hud_clock = this.prefs.hud_clock;
        this.hud_day = this.prefs.hud_day;
        this.hud_player1 = this.prefs.hud_player1;
        this.hud_player2 = this.prefs.hud_player2;
        this.hud_weapons = this.prefs.hud_weapons;
        this.hud_dpad = this.prefs.hud_dpad;
        this.camradian1 = this.prefs.camradianA;
        this.camheight1 = this.prefs.camheightA;
        this.vector3_0 = this.prefs.vector3_0;
        this.camlookpos3rd1 = this.prefs.camlookpos3rdA;
        this.camradian2 = this.prefs.camradianB;
        this.camheight2 = this.prefs.camheightB;
        this.vector3_1 = this.prefs.vector3_1;
        this.camlookpos3rd2 = this.prefs.camlookpos3rdB;
        this.curDay = (int) MathHelper.Clamp((float) this.prefs.curDay, 1f, (float) ((int) this.maxDay() + 1));
        this.FarmerUnlocked = this.prefs.FarmerUnlocked;
        this.pad_reload = true;
        this.pad_togglesprint = this.prefs.pad_togglesprint;
        this.aliasing = this.prefs.aliasing;
        this.resolution = this.prefs.resolution;
        this.fullscreen = this.prefs.fullscreen;
        this.aspectratio = this.prefs.aspectratio;
        if (this.prefs.playername != "")
          this.playername = this.prefs.playername;
        this.mylens = this.prefs.lens;
        if ((double) this.mylens < 20.0 || (double) this.mylens > 150.0)
          this.mylens = 58f;
        this.myfov = (float) Math.Cos((double) MathHelper.ToRadians((float) (((double) this.mylens + 30.0) / 2.0)));
        this.gorelevel = this.prefs.gore;
        this.fastnades = this.prefs.fastnades;
        this.star1 = this.prefs.star1;
        this.star2 = this.prefs.star2;
        this.star3 = this.prefs.star3;
        this.doubleAmmo = this.prefs.doubleAmmo;
        if (!this.star1)
          this.fastnades = false;
        if (!this.star2)
          this.gorelevel = 0;
        if (!this.star3)
          this.doubleAmmo = false;
        this.workshopNum = (int) this.prefs.workshopNum;
        if ((double) this.fileVersion != (double) this.versionNumber)
        {
          this.resetPreferences();
          this.SavePrefs();
        }
      }
      return this.prefs.fileExists;
    }

    public void SavePrefs()
    {
      this.prefs.fileVersion = this.versionNumber;
      this.prefs.mv = this.mv;
      this.prefs.ev = this.ev;
      this.prefs.vv = this.vv;
      this.prefs.df = !this.host ? this.df_orig : this.df;
      this.prefs.brightness = this.brightness;
      this.brightBU = this.brightness;
      this.prefs.contrast = this.contrast;
      this.prefs.pad_invertY = this.pad_invertY;
      this.prefs.pad_sensitivity = this.pad_sensitivity;
      this.prefs.pad_vibro = this.pad_vibro;
      this.prefs.hud_enemy = this.hud_enemy;
      this.prefs.hud_clock = this.hud_clock;
      this.prefs.hud_day = this.hud_day;
      this.prefs.hud_player1 = this.hud_player1;
      this.prefs.hud_player2 = this.hud_player2;
      this.prefs.hud_weapons = this.hud_weapons;
      this.prefs.hud_dpad = this.hud_dpad;
      this.prefs.camradianA = this.camradian1;
      this.prefs.camheightA = this.camheight1;
      this.prefs.vector3_0 = this.vector3_0;
      this.prefs.camlookpos3rdA = this.camlookpos3rd1;
      this.prefs.camradianB = this.camradian2;
      this.prefs.camheightB = this.camheight2;
      this.prefs.vector3_1 = this.vector3_1;
      this.prefs.camlookpos3rdB = this.camlookpos3rd2;
      if (this.currentDay >= 1 && this.currentDay <= (int) this.maxDay() + 1)
        this.curDay = this.currentDay;
      this.prefs.curDay = (ushort) this.curDay;
      this.prefs.FarmerUnlocked = this.FarmerUnlocked;
      this.prefs.pad_reload = this.pad_reload;
      this.prefs.pad_togglesprint = this.pad_togglesprint;
      this.prefs.aliasing = this.aliasing;
      this.prefs.resolution = this.resolution;
      this.prefs.fullscreen = this.fullscreen;
      this.prefs.aspectratio = this.aspectratio;
      this.prefs.playername = this.playername;
      this.prefs.lens = this.mylens;
      this.prefs.gore = this.gorelevel;
      this.prefs.fastnades = this.fastnades;
      this.prefs.star1 = this.star1;
      this.prefs.star2 = this.star2;
      this.prefs.star3 = this.star3;
      this.prefs.doubleAmmo = this.doubleAmmo;
      this.prefs.workshopNum = (byte) this.workshopNum;
      this.storagePrefs.SavePreferences(this.prefs);
      this.storeState = this.storagePrefs.status;
      if (!(this.storeState != ""))
        return;
      this.AddScreen((GameScreen) new MessageBoxScreen2(this.storeState.ToString(), 0), new PlayerIndex?());
    }

    public bool LoadGame(bool resetthis)
    {
      this.gdata = this.storageGame.LoadGame();
      if (this.gdata.fileExists)
      {
        this.fileVersion = this.gdata.fileVersion;
        for (int index = 0; index < this.days.Length; ++index)
          this.days[index] = (int) this.gdata.days[index];
        this.scarh_Unlock = this.gdata.scarh;
        this.weaponUnlock_bits(this.gdata.weaponsunlocked);
        this.grinderUnlock_bits(this.gdata.grinderunlocked);
        this.grenades = (int) this.gdata.grenades;
        this.milks = (int) this.gdata.milks;
        this.hulks = (int) this.gdata.bulkify;
        this.pills = (int) this.gdata.pills;
        this.rockets = (int) this.gdata.mirv;
        int hats = (int) this.gdata.hats;
        this.hats[7] = this.ReadFromBitfield(ref hats, 1);
        this.hats[6] = this.ReadFromBitfield(ref hats, 1);
        this.hats[5] = this.ReadFromBitfield(ref hats, 1);
        this.hats[4] = this.ReadFromBitfield(ref hats, 1);
        this.hats[3] = this.ReadFromBitfield(ref hats, 1);
        this.hats[2] = this.ReadFromBitfield(ref hats, 1);
        this.hats[1] = this.ReadFromBitfield(ref hats, 1);
        this.hats[0] = 0;
        int mats = (int) this.gdata.mats;
        this.hats[15] = this.ReadFromBitfield(ref mats, 1);
        this.hats[14] = this.ReadFromBitfield(ref mats, 1);
        this.hats[13] = this.ReadFromBitfield(ref mats, 1);
        this.hats[12] = this.ReadFromBitfield(ref mats, 1);
        this.hats[11] = this.ReadFromBitfield(ref mats, 1);
        this.hats[10] = this.ReadFromBitfield(ref mats, 1);
        this.hats[9] = this.ReadFromBitfield(ref mats, 1);
        this.hats[8] = this.ReadFromBitfield(ref mats, 1);
        this.man1 = this.gdata.man1;
        this.man2 = this.gdata.man2;
        this.man3 = this.gdata.man3;
        this.man4 = this.gdata.man4;
        this.goggles = (int) this.gdata.goggles;
        this.flashlight1 = (int) this.gdata.flashlight1;
        this.flashlight2 = (int) this.gdata.flashlight2;
        this.flashlight3 = (int) this.gdata.flashlight3;
        this.ammoboxCount = 0;
        for (int index = 0; index < this.map.Length; ++index)
          this.map[index] = (int) this.gdata.map[index];
        for (int index = 0; index < this.ammobox1.Length; ++index)
        {
          this.ammobox1[index] = (int) this.gdata.ammobox1[index];
          this.ammobox2[index] = (int) this.gdata.ammobox2[index];
          this.ammobox3[index] = (int) this.gdata.ammobox3[index];
          this.ammoboxCount += this.ammobox1[index] + this.ammobox2[index] + this.ammobox3[index];
          if (this.ammoboxCount > 10)
            this.ammoboxCount = 10;
        }
        for (int index = 0; index < this.cog1.Length; ++index)
        {
          this.cog1[index] = (int) this.gdata.cog1[index];
          this.cog2[index] = (int) this.gdata.cog2[index];
          this.cog3[index] = (int) this.gdata.cog3[index];
        }
        for (int index = 0; index < this.exitkey.Length; ++index)
          this.exitkey[index] = (int) this.gdata.exitkey[index];
        for (int index = 0; index < 20; ++index)
        {
          this.code1[index, 0] = (int) this.gdata.code1[index, 0];
          this.code1[index, 1] = (int) this.gdata.code1[index, 1];
          this.code1[index, 2] = (int) this.gdata.code1[index, 2];
          this.code2[index, 0] = (int) this.gdata.code2[index, 0];
          this.code2[index, 1] = (int) this.gdata.code2[index, 1];
          this.code2[index, 2] = (int) this.gdata.code2[index, 2];
          this.code3[index, 0] = (int) this.gdata.code3[index, 0];
          this.code3[index, 1] = (int) this.gdata.code3[index, 1];
          this.code3[index, 2] = (int) this.gdata.code3[index, 2];
        }
        this.redskull1 = (int) this.gdata.redskull1;
        this.redskull2 = (int) this.gdata.redskull2;
        this.redskull3 = (int) this.gdata.redskull3;
        this.tusk1 = (int) this.gdata.tusk1;
        this.tusk2 = (int) this.gdata.tusk2;
        this.tusk3 = (int) this.gdata.tusk3;
        this.heirlooms[0] = (int) this.gdata.heirloom[0];
        this.heirlooms[1] = (int) this.gdata.heirloom[1];
        this.heirlooms[2] = (int) this.gdata.heirloom[2];
        this.heirlooms[3] = (int) this.gdata.heirloom[3];
        this.heirlooms[4] = (int) this.gdata.heirloom[4];
        this.heirlooms[5] = (int) this.gdata.heirloom[5];
        this.heirlooms[6] = (int) this.gdata.heirloom[6];
        if (this.bonusweek)
        {
          this.man1 = true;
          this.man2 = true;
          this.FarmerUnlocked = true;
          this.hats[9] = 1;
        }
        if (this.grenades > 10)
          this.grenades = 10;
        if (this.milks > 10)
          this.milks = 10;
        if (this.hulks > 5)
          this.hulks = 5;
        if (this.pills > 5)
          this.pills = 5;
        if (this.rockets > 5)
          this.rockets = 5;
        if ((double) this.fileVersion != (double) this.versionNumber)
          this.fileVersion = this.versionNumber;
      }
      else if (resetthis)
      {
        this.resetGame();
        this.SaveGame();
        this.fanfare.Play(1f, 1f, 0.0f);
      }
      return this.gdata.fileExists;
    }

    public void SaveGame()
    {
      this.gdata.fileVersion = this.versionNumber;
      for (int index = 0; index < this.days.Length; ++index)
        this.gdata.days[index] = Math.Max((byte) this.days[index], this.gdata.days[index]);
      this.gdata.weaponsunlocked = this.weapon_Unlock[0] + this.weapon_Unlock[2] * 2 + this.weapon_Unlock[4] * 4 + this.weapon_Unlock[6] * 8 + this.weapon_Unlock[8] * 16 + this.weapon_Unlock[10] * 32 + this.weapon_Unlock[12] * 64 + this.weapon_Unlock[14] * 128 + this.weapon_Unlock[16] * 256 + this.weapon_Unlock[18] * 512 + this.weapon_Unlock[20] * 1024 + this.weapon_Unlock[22] * 2048;
      this.gdata.scarh = this.scarh_Unlock;
      this.gdata.grinderunlocked = this.grinder_Unlock[1] + this.grinder_Unlock[2] * 2 + this.grinder_Unlock[3] * 4 + this.grinder_Unlock[4] * 8 + this.grinder_Unlock[5] * 16;
      this.gdata.grenades = (byte) MathHelper.Clamp((float) this.grenades, 0.0f, 10f);
      this.gdata.milks = (byte) MathHelper.Clamp((float) this.milks, 0.0f, 10f);
      this.gdata.bulkify = (byte) MathHelper.Clamp((float) this.hulks, 0.0f, 5f);
      this.gdata.pills = (byte) MathHelper.Clamp((float) this.pills, 0.0f, 5f);
      this.gdata.mirv = (byte) MathHelper.Clamp((float) this.rockets, 0.0f, 2f);
      int bitfield = 0;
      this.AddToBitfield(ref bitfield, 1, this.hats[1]);
      this.AddToBitfield(ref bitfield, 1, this.hats[2]);
      this.AddToBitfield(ref bitfield, 1, this.hats[3]);
      this.AddToBitfield(ref bitfield, 1, this.hats[4]);
      this.AddToBitfield(ref bitfield, 1, this.hats[5]);
      this.AddToBitfield(ref bitfield, 1, this.hats[6]);
      this.AddToBitfield(ref bitfield, 1, this.hats[7]);
      this.gdata.hats = (byte) bitfield;
      bitfield = 0;
      this.AddToBitfield(ref bitfield, 1, this.hats[8]);
      this.AddToBitfield(ref bitfield, 1, this.hats[9]);
      this.AddToBitfield(ref bitfield, 1, this.hats[10]);
      this.AddToBitfield(ref bitfield, 1, this.hats[11]);
      this.AddToBitfield(ref bitfield, 1, this.hats[12]);
      this.AddToBitfield(ref bitfield, 1, this.hats[13]);
      this.AddToBitfield(ref bitfield, 1, this.hats[14]);
      this.AddToBitfield(ref bitfield, 1, this.hats[15]);
      this.gdata.mats = (byte) bitfield;
      this.gdata.man1 = this.man1;
      this.gdata.man2 = this.man2;
      this.gdata.man3 = this.man3;
      this.gdata.man4 = this.man4;
      this.gdata.goggles = (byte) this.goggles;
      this.gdata.flashlight1 = (byte) this.flashlight1;
      this.gdata.flashlight2 = (byte) this.flashlight2;
      this.gdata.flashlight3 = (byte) this.flashlight3;
      for (int index = 0; index < this.map.Length; ++index)
        this.gdata.map[index] = (byte) this.map[index];
      for (int index = 0; index < this.ammobox1.Length; ++index)
      {
        this.gdata.ammobox1[index] = (byte) this.ammobox1[index];
        this.gdata.ammobox2[index] = (byte) this.ammobox2[index];
        this.gdata.ammobox3[index] = (byte) this.ammobox3[index];
      }
      for (int index = 0; index < this.cog1.Length; ++index)
      {
        this.gdata.cog1[index] = (byte) this.cog1[index];
        this.gdata.cog2[index] = (byte) this.cog2[index];
        this.gdata.cog3[index] = (byte) this.cog3[index];
      }
      for (int index = 0; index < this.exitkey.Length; ++index)
        this.gdata.exitkey[index] = (byte) this.exitkey[index];
      for (int index = 0; index < 20; ++index)
      {
        this.gdata.code1[index, 0] = (byte) this.code1[index, 0];
        this.gdata.code1[index, 1] = (byte) this.code1[index, 1];
        this.gdata.code1[index, 2] = (byte) this.code1[index, 2];
        this.gdata.code2[index, 0] = (byte) this.code2[index, 0];
        this.gdata.code2[index, 1] = (byte) this.code2[index, 1];
        this.gdata.code2[index, 2] = (byte) this.code2[index, 2];
        this.gdata.code3[index, 0] = (byte) this.code3[index, 0];
        this.gdata.code3[index, 1] = (byte) this.code3[index, 1];
        this.gdata.code3[index, 2] = (byte) this.code3[index, 2];
      }
      this.gdata.redskull1 = (byte) this.redskull1;
      this.gdata.redskull2 = (byte) this.redskull2;
      this.gdata.redskull3 = (byte) this.redskull3;
      this.gdata.tusk1 = (byte) this.tusk1;
      this.gdata.tusk2 = (byte) this.tusk2;
      this.gdata.tusk3 = (byte) this.tusk3;
      this.gdata.heirloom[0] = (byte) this.heirlooms[0];
      this.gdata.heirloom[1] = (byte) this.heirlooms[1];
      this.gdata.heirloom[2] = (byte) this.heirlooms[2];
      this.gdata.heirloom[3] = (byte) this.heirlooms[3];
      this.gdata.heirloom[4] = (byte) this.heirlooms[4];
      this.gdata.heirloom[5] = (byte) this.heirlooms[5];
      this.gdata.heirloom[6] = (byte) this.heirlooms[6];
      this.storageGame.SaveGame(this.gdata);
      this.storeState = this.storageGame.status;
      if (!(this.storeState != ""))
        return;
      this.AddScreen((GameScreen) new MessageBoxScreen2(this.storeState.ToString(), 0), new PlayerIndex?());
    }

    public void savePickups()
    {
      this.gdata = this.storageGame.LoadGame();
      if (!this.gdata.fileExists)
        return;
      this.gdata.pills = (byte) this.pills;
      this.gdata.grenades = (byte) this.grenades;
      this.gdata.milks = (byte) this.milks;
      this.gdata.bulkify = (byte) this.hulks;
      this.storageGame.SaveGame(this.gdata);
    }

    public void resetTunnels()
    {
      this.ammoboxCount = 0;
      this.flashlight1 = 0;
      this.flashlight2 = 0;
      this.flashlight3 = 0;
      this.goggles = 0;
      this.redskull1 = 0;
      this.redskull2 = 0;
      this.redskull3 = 0;
      this.tusk1 = 0;
      this.tusk2 = 0;
      this.tusk3 = 0;
      this.map = new int[20];
      this.ammobox1 = new int[20];
      this.ammobox2 = new int[20];
      this.ammobox3 = new int[20];
      this.cog1 = new int[20];
      this.cog2 = new int[20];
      this.cog3 = new int[20];
      this.exitkey = new int[20];
      this.code1 = new int[20, 3];
      this.code2 = new int[20, 3];
      this.code3 = new int[20, 3];
      this.heirlooms = new List<int>()
      {
        0,
        0,
        0,
        0,
        0,
        0,
        0
      };
      this.exitkey = new int[20];
      string path1 = "World\\minimap0";
      string path2 = "World\\minimap1";
      string path3 = "World\\minimap2";
      string path4 = "World\\minimap3";
      string path5 = "World\\minimap4";
      if (File.Exists(path1))
        File.Delete(path1);
      if (File.Exists(path2))
        File.Delete(path2);
      if (File.Exists(path3))
        File.Delete(path3);
      if (File.Exists(path4))
        File.Delete(path4);
      if (File.Exists(path5))
        File.Delete(path5);
      List<Vector2> blob = new List<Vector2>();
      this.saveTunnelItems(true, ref blob, 0);
    }

    public void saveTunnelItems(bool includeAll, ref List<Vector2> blob, int mazeid)
    {
      this.gdata = this.storageGame.LoadGame();
      if (this.gdata.fileExists)
      {
        this.gdata.scarh = this.scarh_Unlock;
        if (this.scarh_Unlock)
          this.weapon_Unlock[20] = 1;
        this.gdata.flashlight1 = (byte) this.flashlight1;
        this.gdata.flashlight2 = (byte) this.flashlight2;
        this.gdata.flashlight3 = (byte) this.flashlight3;
        if (this.redskull1 == 2)
          this.gdata.redskull1 = (byte) this.redskull1;
        if (this.redskull2 == 2)
          this.gdata.redskull2 = (byte) this.redskull2;
        if (this.redskull3 == 2)
          this.gdata.redskull3 = (byte) this.redskull3;
        if (this.tusk1 == 2)
          this.gdata.tusk1 = (byte) this.tusk1;
        if (this.tusk2 == 2)
          this.gdata.tusk2 = (byte) this.tusk2;
        if (this.tusk3 == 2)
          this.gdata.tusk3 = (byte) this.tusk3;
        for (int index = 0; index < this.map.Length; ++index)
          this.gdata.map[index] = (byte) this.map[index];
        int num = 0;
        for (int index = 0; index < this.ammobox1.Length; ++index)
        {
          this.gdata.ammobox1[index] = (byte) this.ammobox1[index];
          this.gdata.ammobox2[index] = (byte) this.ammobox2[index];
          this.gdata.ammobox3[index] = (byte) this.ammobox3[index];
          num += this.ammobox1[index] + this.ammobox2[index] + this.ammobox3[index];
          if (num > 10)
            num = 10;
        }
        for (int index = 0; index < this.cog1.Length; ++index)
        {
          this.gdata.cog1[index] = (byte) this.cog1[index];
          this.gdata.cog2[index] = (byte) this.cog2[index];
          this.gdata.cog3[index] = (byte) this.cog3[index];
        }
        for (int index = 0; index < 20; ++index)
        {
          this.gdata.code1[index, 0] = (byte) this.code1[index, 0];
          this.gdata.code1[index, 1] = (byte) this.code1[index, 1];
          this.gdata.code1[index, 2] = (byte) this.code1[index, 2];
          this.gdata.code2[index, 0] = (byte) this.code2[index, 0];
          this.gdata.code2[index, 1] = (byte) this.code2[index, 1];
          this.gdata.code2[index, 2] = (byte) this.code2[index, 2];
          this.gdata.code3[index, 0] = (byte) this.code3[index, 0];
          this.gdata.code3[index, 1] = (byte) this.code3[index, 1];
          this.gdata.code3[index, 2] = (byte) this.code3[index, 2];
        }
        this.gdata.heirloom[0] = (byte) this.heirlooms[0];
        this.gdata.heirloom[1] = (byte) this.heirlooms[1];
        this.gdata.heirloom[2] = (byte) this.heirlooms[2];
        this.gdata.heirloom[3] = (byte) this.heirlooms[3];
        this.gdata.heirloom[4] = (byte) this.heirlooms[4];
        this.gdata.heirloom[5] = (byte) this.heirlooms[5];
        this.gdata.heirloom[6] = (byte) this.heirlooms[6];
        if (includeAll)
        {
          this.ammoboxCount = num;
          int bitfield = 0;
          this.AddToBitfield(ref bitfield, 1, this.hats[8]);
          this.AddToBitfield(ref bitfield, 1, this.hats[9]);
          this.AddToBitfield(ref bitfield, 1, this.hats[10]);
          this.AddToBitfield(ref bitfield, 1, this.hats[11]);
          this.AddToBitfield(ref bitfield, 1, this.hats[12]);
          this.AddToBitfield(ref bitfield, 1, this.hats[13]);
          this.AddToBitfield(ref bitfield, 1, this.hats[14]);
          this.AddToBitfield(ref bitfield, 1, this.hats[15]);
          this.gdata.mats = (byte) bitfield;
          for (int index = 0; index < this.exitkey.Length; ++index)
            this.gdata.exitkey[index] = (byte) this.exitkey[index];
          this.gdata.redskull1 = (byte) this.redskull1;
          this.gdata.redskull2 = (byte) this.redskull2;
          this.gdata.redskull3 = (byte) this.redskull3;
          this.gdata.tusk1 = (byte) this.tusk1;
          this.gdata.tusk2 = (byte) this.tusk2;
          this.gdata.tusk3 = (byte) this.tusk3;
          this.gdata.goggles = (byte) this.goggles;
        }
        this.storageGame.SaveGame(this.gdata);
      }
      blob = blob.Distinct<Vector2>().ToList<Vector2>();
      string path = "World//minimap" + mazeid.ToString();
      if (!Directory.Exists("World"))
        Directory.CreateDirectory("World");
      try
      {
        using (BinaryWriter binaryWriter = new BinaryWriter((Stream) File.Open(path, FileMode.Create)))
        {
          for (int index = 0; index < blob.Count; ++index)
          {
            binaryWriter.Write((byte) blob[index].X);
            binaryWriter.Write((byte) blob[index].Y);
          }
          binaryWriter.Close();
        }
      }
      catch
      {
      }
    }

    public void saveTunnelCodes()
    {
      this.gdata = this.storageGame.LoadGame();
      if (!this.gdata.fileExists)
        return;
      for (int index = 0; index < this.cog1.Length; ++index)
      {
        this.gdata.cog1[index] = (byte) this.cog1[index];
        this.gdata.cog2[index] = (byte) this.cog2[index];
        this.gdata.cog3[index] = (byte) this.cog3[index];
      }
      for (int index = 0; index < 20; ++index)
      {
        this.gdata.code1[index, 0] = (byte) this.code1[index, 0];
        this.gdata.code1[index, 1] = (byte) this.code1[index, 1];
        this.gdata.code1[index, 2] = (byte) this.code1[index, 2];
        this.gdata.code2[index, 0] = (byte) this.code2[index, 0];
        this.gdata.code2[index, 1] = (byte) this.code2[index, 1];
        this.gdata.code2[index, 2] = (byte) this.code2[index, 2];
        this.gdata.code3[index, 0] = (byte) this.code3[index, 0];
        this.gdata.code3[index, 1] = (byte) this.code3[index, 1];
        this.gdata.code3[index, 2] = (byte) this.code3[index, 2];
      }
      this.storageGame.SaveGame(this.gdata);
    }

    public void SaveEquipables()
    {
      this.gdata = this.storageGame.LoadGame();
      if (!this.gdata.fileExists)
        return;
      int bitfield1 = 0;
      this.AddToBitfield(ref bitfield1, 1, this.hats[1]);
      this.AddToBitfield(ref bitfield1, 1, this.hats[2]);
      this.AddToBitfield(ref bitfield1, 1, this.hats[3]);
      this.AddToBitfield(ref bitfield1, 1, this.hats[4]);
      this.AddToBitfield(ref bitfield1, 1, this.hats[5]);
      this.AddToBitfield(ref bitfield1, 1, this.hats[6]);
      this.AddToBitfield(ref bitfield1, 1, this.hats[7]);
      this.gdata.hats = (byte) bitfield1;
      int bitfield2 = 0;
      this.AddToBitfield(ref bitfield2, 1, this.hats[8]);
      this.AddToBitfield(ref bitfield2, 1, this.hats[9]);
      this.AddToBitfield(ref bitfield2, 1, this.hats[10]);
      this.AddToBitfield(ref bitfield2, 1, this.hats[11]);
      this.AddToBitfield(ref bitfield2, 1, this.hats[12]);
      this.AddToBitfield(ref bitfield2, 1, this.hats[13]);
      this.AddToBitfield(ref bitfield2, 1, this.hats[14]);
      this.AddToBitfield(ref bitfield2, 1, this.hats[15]);
      this.gdata.mats = (byte) bitfield2;
      this.gdata.man1 = this.man1;
      this.gdata.man2 = this.man2;
      this.gdata.man3 = this.man3;
      this.gdata.man4 = this.man4;
      this.storageGame.SaveGame(this.gdata);
    }

    private int ReadFromBitfield(ref int bitfield, int bitCount)
    {
      int num = bitfield & (1 << bitCount) - 1;
      bitfield >>= bitCount;
      return num;
    }

    private void AddToBitfield(ref int bitfield, int bitCount, int value)
    {
      bitfield <<= bitCount;
      bitfield |= value;
    }

    public ushort maxDay()
    {
      ushort num = 0;
      for (int index = 0; index < this.days.Length; ++index)
      {
        if (this.days[index] > 0)
          num = (ushort) index;
        if (num > (ushort) 101)
          num = (ushort) 101;
      }
      return num;
    }

    public void resetGame()
    {
      this.days = new int[201];
      for (int index = 0; index < this.days.Length; ++index)
        this.days[index] = 0;
      this.days[0] = 1;
      this.gdata.days = new byte[201];
      for (int index = 0; index < this.gdata.days.Length; ++index)
        this.gdata.days[index] = (byte) 0;
      this.weaponResetMode("reset");
      int[] numArray = new int[6];
      numArray[0] = 1;
      this.grinder_Unlock = numArray;
      this.grinder_Supply = new int[6]
      {
        100,
        50,
        50,
        2,
        1,
        1
      };
      this.grenades = 0;
      this.milks = 0;
      this.hulks = 0;
      this.pills = 0;
      this.rockets = 0;
      for (int index = 0; index < this.hats.Length; ++index)
        this.hats[index] = 0;
      this.goggles = 0;
      this.flashlight1 = 0;
      this.flashlight2 = 0;
      this.flashlight3 = 0;
      this.map = new int[20];
      this.ammobox1 = new int[20];
      this.ammobox2 = new int[20];
      this.ammobox3 = new int[20];
      this.cog1 = new int[20];
      this.cog2 = new int[20];
      this.cog3 = new int[20];
      this.exitkey = new int[20];
      this.code1 = new int[20, 3];
      this.code2 = new int[20, 3];
      this.code3 = new int[20, 3];
      this.redskull1 = 0;
      this.redskull2 = 0;
      this.redskull3 = 0;
      this.tusk1 = 0;
      this.tusk2 = 0;
      this.tusk3 = 0;
      this.heirlooms = new List<int>()
      {
        0,
        0,
        0,
        0,
        0,
        0,
        0
      };
    }

    public void weaponResetMode(string flag)
    {
      this.weapon_Unlock = new int[25];
      for (int index = 0; index < this.weapon_Unlock.Length - 1; ++index)
        this.weapon_Unlock[index] = 0;
      if (flag == "pistol")
      {
        this.weapon_Unlock[2] = 1;
        if (this.scarh_Unlock)
          this.weapon_Unlock[20] = 1;
      }
      if (flag == "reset")
        this.weapon_Unlock[2] = 1;
      if (flag == "all")
      {
        this.weapon_Unlock[0] = 1;
        this.weapon_Unlock[2] = 1;
        this.weapon_Unlock[4] = 1;
        this.weapon_Unlock[6] = 1;
        this.weapon_Unlock[8] = 1;
        this.weapon_Unlock[10] = 1;
        this.weapon_Unlock[12] = 1;
        this.weapon_Unlock[14] = 1;
        this.weapon_Unlock[16] = 1;
        this.weapon_Unlock[18] = 1;
        if (this.scarh_Unlock)
          this.weapon_Unlock[20] = 1;
      }
      if (!(flag == "horde"))
        return;
      this.weapon_Unlock[0] = 1;
      this.weapon_Unlock[2] = 1;
      this.weapon_Unlock[4] = 1;
      this.weapon_Unlock[6] = 1;
      this.weapon_Unlock[8] = 1;
      this.weapon_Unlock[10] = 1;
      this.weapon_Unlock[12] = 1;
      this.weapon_Unlock[14] = 0;
      this.weapon_Unlock[16] = 0;
      this.weapon_Unlock[18] = 1;
      this.weapon_Unlock[20] = 0;
      if (!this.scarh_Unlock)
        return;
      this.weapon_Unlock[20] = 1;
    }

    public void weaponUnlock_bits(int bit)
    {
      if ((bit & 1) != 0)
        this.weapon_Unlock[0] = 1;
      if ((bit & 2) != 0)
        this.weapon_Unlock[2] = 1;
      if ((bit & 4) != 0)
        this.weapon_Unlock[4] = 1;
      if ((bit & 8) != 0)
        this.weapon_Unlock[6] = 1;
      if ((bit & 16) != 0)
        this.weapon_Unlock[8] = 1;
      if ((bit & 32) != 0)
        this.weapon_Unlock[10] = 1;
      if ((bit & 64) != 0)
        this.weapon_Unlock[12] = 1;
      if ((bit & 128) != 0)
        this.weapon_Unlock[14] = 1;
      if ((bit & 256) != 0)
        this.weapon_Unlock[16] = 1;
      if ((bit & 512) != 0)
        this.weapon_Unlock[18] = 1;
      if ((bit & 1024) != 0)
        this.weapon_Unlock[20] = 1;
      if (!this.scarh_Unlock || this.currentDay < 12)
        return;
      this.weapon_Unlock[20] = 1;
    }

    public void grinderUnlock_bits(int bit)
    {
      if ((bit & 1) != 0)
        this.grinder_Unlock[1] = 1;
      if ((bit & 2) != 0)
        this.grinder_Unlock[2] = 1;
      if ((bit & 4) != 0)
        this.grinder_Unlock[3] = 1;
      if ((bit & 8) != 0)
        this.grinder_Unlock[4] = 1;
      if ((bit & 16) == 0)
        return;
      this.grinder_Unlock[5] = 1;
    }

    public void weaponDayEnd(ref int[] x)
    {
      if ((this.weaponEndofDay & 1) != 0)
        x[0] = 1;
      if ((this.weaponEndofDay & 2) != 0)
        x[2] = 1;
      if ((this.weaponEndofDay & 4) != 0)
        x[4] = 1;
      if ((this.weaponEndofDay & 8) != 0)
        x[6] = 1;
      if ((this.weaponEndofDay & 16) != 0)
        x[8] = 1;
      if ((this.weaponEndofDay & 32) != 0)
        x[10] = 1;
      if ((this.weaponEndofDay & 64) != 0)
        x[12] = 1;
      if ((this.weaponEndofDay & 128) != 0)
        x[14] = 1;
      if ((this.weaponEndofDay & 256) != 0)
        x[16] = 1;
      if ((this.weaponEndofDay & 512) == 0)
        return;
      x[18] = 1;
    }

    public void resetAudio()
    {
      this.mv = 0.5f;
      this.ev = 0.8f;
      this.vv = 0.6f;
    }

    public void resetVideo()
    {
      this.brightness = 128;
      this.brightBU = 128;
      this.contrast = 128;
      this.hud_enemy = new Vector2(80f, 35f);
      this.hud_clock = new Vector2(490f, 35f);
      this.hud_day = new Vector2(1200f, 35f);
      this.hud_player1 = new Vector2(495f, 620f);
      this.hud_player2 = new Vector2(50f, 640f);
      this.hud_weapons = new Vector2(1090f, 250f);
      this.hud_dpad = new Vector2(1115f, 300f);
    }

    public void resetPreferences()
    {
      this.mv = 0.9f;
      this.ev = 1f;
      this.vv = 1f;
      this.df = 1;
      this.pad_invertY = 1f;
      this.pad_sensitivity = 1f;
      this.pad_vibro = true;
      this.pad_reload = true;
      this.brightness = 128;
      this.contrast = 128;
      this.hud_enemy = new Vector2(80f, 35f);
      this.hud_clock = new Vector2(490f, 35f);
      this.hud_day = new Vector2(1200f, 35f);
      this.hud_player1 = new Vector2(495f, 620f);
      this.hud_player2 = new Vector2(50f, 640f);
      this.hud_weapons = new Vector2(1090f, 250f);
      this.hud_dpad = new Vector2(1115f, 300f);
      this.camradian1 = -1.725f;
      this.camheight1 = 2.95f;
      this.vector3_0 = new Vector3(-21.53f, 48.7f, 15.2f);
      this.camlookpos3rd1 = new Vector3(172.4f, 10.25f, -14.95f);
      this.camradian2 = -1.55f;
      this.camheight2 = 2.08f;
      this.vector3_1 = new Vector3(-71f, 303f, 6.3f);
      this.camlookpos3rd2 = new Vector3(-45.6f, 259f, 6.7f);
      this.resolution = 0;
      this.aliasing = 0;
      this.fullscreen = 0;
      this.gorelevel = 0;
      this.fastnades = false;
      this.star1 = false;
      this.star2 = false;
      this.star3 = false;
      this.workshopNum = 0;
    }

    public void resetColors()
    {
      this.color_enemy = new Color(210, 0, 0, (int) byte.MaxValue);
      this.color_day = new Color(210, 0, 0, (int) byte.MaxValue);
      this.color_clock = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.color_player1 = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.color_player2 = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.color_weapons = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      this.color_dpad = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    }

    public void FadeBackBufferToBlack(int alpha)
    {
      this.SpriteBatch.Begin();
      this.SpriteBatch.Draw(this.blackTexture, new Rectangle(0, 0, this.graphics.GraphicsDevice.Viewport.Width, this.graphics.GraphicsDevice.Viewport.Height), new Color(0, 0, 0, (int) (byte) alpha));
      this.SpriteBatch.End();
    }

    public Rectangle adjustRect(Rectangle ss) => ss;

    public Rectangle adjustRect2(Rectangle ss)
    {
      Vector2 vector2 = new Vector2((float) this.screenSize.Width / (float) this.origSize.Width, (float) this.screenSize.Height / (float) this.origSize.Height);
      return new Rectangle(ss.X, ss.Y, (int) ((double) ss.Width * (double) vector2.X), (int) ((double) ss.Height * (double) vector2.Y))
      {
        X = (int) ((double) (ss.X - this.myviewport.X + 1) * (double) vector2.X),
        Y = (int) ((double) (ss.Y - this.myviewport.Y + 1) * (double) vector2.Y)
      };
    }

    public Vector2 adjustVector(Vector2 ss)
    {
      Vector2 vector2 = new Vector2((float) this.origSize.Width / (float) this.screenSize.Width, (float) this.origSize.Height / (float) this.screenSize.Height);
      return new Vector2((float) ((double) ss.X - (double) this.myviewport.X + 1.0), (float) ((double) ss.Y - (double) this.myviewport.Y + 1.0));
    }

    public Vector2 adjustVector2(Vector2 ss)
    {
      Vector2 vector2_1 = new Vector2((float) this.origSize.Width / (float) this.screenSize.Width, (float) this.origSize.Height / (float) this.screenSize.Height);
      Vector2 vector2_2 = new Vector2((float) ((double) ss.X - (double) this.myviewport.X + 1.0), (float) ((double) ss.Y - (double) this.myviewport.Y + 1.0));
      vector2_2.X *= vector2_1.X;
      vector2_2.Y *= vector2_1.Y;
      return vector2_2;
    }

    public Vector2 adjustVector3(Vector2 ss)
    {
      Vector2 vector2_1 = new Vector2((float) this.width / this.startwidth, (float) this.hite / this.starthite);
      Vector2 vector2_2 = new Vector2((float) ((double) ss.X - (double) this.myviewport.X + 1.0), (float) ((double) ss.Y - (double) this.myviewport.Y + 1.0));
      vector2_2.X *= vector2_1.X;
      vector2_2.Y *= vector2_1.Y;
      return vector2_2;
    }

    public float adjustScale() => 1f;

    public void windowMax(float inc, int horiz, int vert)
    {
    }

    public void setAntiAliasing(int aa)
    {
      if (aa > 0)
      {
        this.graphics.PreferMultiSampling = true;
        this.graphics.PreparingDeviceSettings += new EventHandler<PreparingDeviceSettingsEventArgs>(this.graphics_PreparingDeviceSettings);
      }
      else
        this.graphics.PreferMultiSampling = false;
      this.graphics.ApplyChanges();
    }

    public void setResolutionSafe()
    {
      this.graphics.GraphicsDevice.VertexSamplerStates[0] = SamplerState.PointClamp;
      this.width = this.graphics.GraphicsDevice.Viewport.Width;
      this.hite = this.graphics.GraphicsDevice.Viewport.Height;
      this.origSize = new Rectangle(0, 0, 1280, 720);
      this.winCenter = new Vector2((float) (this.width / 2), (float) (this.hite / 2));
      this.myviewport = this.graphics.GraphicsDevice.Viewport;
      this.startResX = (float) this.width;
      this.startResY = (float) this.hite;
      if ((double) this.startResX > (double) this.width)
        this.startResX = (float) (this.width - 4);
      if ((double) this.startResY > (double) this.hite)
        this.startResY = (float) (this.hite - 4);
      this.myviewport.Width = (int) this.startResX;
      this.myviewport.Height = (int) this.startResY;
      this.myviewport.X = this.width / 2 - this.myviewport.Width / 2;
      this.myviewport.Y = this.hite / 2 - this.myviewport.Height / 2;
      this.screenSize = new Rectangle(this.myviewport.X, this.myviewport.Y, this.myviewport.Width, this.myviewport.Height);
      this.graphics.GraphicsDevice.VertexSamplerStates[0] = SamplerState.PointClamp;
      this.setgraphics = true;
    }

    public void setResolution()
    {
      try
      {
        this.graphics.GraphicsDevice.VertexSamplerStates[0] = SamplerState.PointClamp;
        int num = 0;
        foreach (DisplayMode supportedDisplayMode in this.graphics.GraphicsDevice.Adapter.SupportedDisplayModes)
        {
          if (num != this.setupnum)
          {
            ++num;
          }
          else
          {
            this.width = supportedDisplayMode.Width;
            this.hite = supportedDisplayMode.Height;
            break;
          }
        }
        this.graphics.PreferredBackBufferWidth = this.width;
        this.graphics.PreferredBackBufferHeight = this.hite;
        this.graphics.IsFullScreen = this.fullmode;
        if (this.aa > 0)
        {
          this.graphics.PreferMultiSampling = true;
          this.graphics.PreparingDeviceSettings += new EventHandler<PreparingDeviceSettingsEventArgs>(this.graphics_PreparingDeviceSettings);
        }
        else
          this.graphics.PreferMultiSampling = false;
        this.graphics.ApplyChanges();
        this.resolution = this.setupnum;
        this.aliasing = this.aa;
        this.origSize = new Rectangle(0, 0, 1280, 720);
        this.winCenter = new Vector2((float) (this.width / 2), (float) (this.hite / 2));
        this.myviewport = this.graphics.GraphicsDevice.Viewport;
        float aspectratio = this.aspectratio;
        if (this.drawViewport)
        {
          if ((double) aspectratio <= 1.0)
          {
            this.startResX = (float) this.width;
            this.startResY = (float) this.hite * aspectratio;
          }
          else
          {
            this.startResX = (float) this.width / aspectratio;
            this.startResY = (float) this.hite;
          }
        }
        else
        {
          this.startResX = (float) this.width;
          this.startResY = (float) this.hite;
        }
        if ((double) this.startResX > (double) this.width)
          this.startResX = (float) (this.width - 4);
        if ((double) this.startResY > (double) this.hite)
          this.startResY = (float) (this.hite - 4);
        this.myviewport.Width = (int) this.startResX;
        this.myviewport.Height = (int) this.startResY;
        this.myviewport.X = this.width / 2 - this.myviewport.Width / 2;
        this.myviewport.Y = this.hite / 2 - this.myviewport.Height / 2;
        this.screenSize = new Rectangle(this.myviewport.X, this.myviewport.Y, this.myviewport.Width, this.myviewport.Height);
        this.graphics.GraphicsDevice.VertexSamplerStates[0] = SamplerState.PointClamp;
        this.setgraphics = true;
        this.justsetgraphics = true;
      }
      catch
      {
        this.setResolutionSafe();
      }
    }

    public void removeBorder()
    {
      ((Form) Control.FromHandle(this.Game.Window.Handle)).FormBorderStyle = FormBorderStyle.None;
    }

    public void addBorder()
    {
      ((Form) Control.FromHandle(this.Game.Window.Handle)).FormBorderStyle = FormBorderStyle.Fixed3D;
    }

    public void centerWindow()
    {
      Mouse.WindowHandle = this.Game.Window.Handle;
      this.winCorner = new Vector2((float) (this.devicex / 2), (float) (this.devicey / 2));
    }

    private void graphics_PreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e)
    {
      e.GraphicsDeviceInformation.PresentationParameters.MultiSampleCount = this.aa;
    }

    public void addChatMsg(
      string name,
      Color nameColor,
      string message,
      Color messColor,
      int gap,
      ulong ID)
    {
      this.chatHistory.Add(new ScreenManager.chatty()
      {
        idlong = ID,
        name = name,
        nameColor = nameColor,
        message = message,
        messColor = messColor,
        gap = gap
      });
      if (this.chatHistory.Count <= 500)
        return;
      this.chatHistory.RemoveAt(0);
    }

    public void reColorChatBox(ref List<dummyOwner> remplayer)
    {
      for (int index1 = 0; index1 < this.chatHistory.Count; ++index1)
      {
        if (this.chatHistory[index1].idlong != 5UL)
        {
          bool flag = false;
          for (int index2 = 0; index2 < remplayer.Count; ++index2)
          {
            if ((long) this.chatHistory[index1].idlong != (long) this.hostowner.m_SteamID)
            {
              if ((long) this.chatHistory[index1].idlong == (long) remplayer[index2].id.m_SteamID)
              {
                this.chatHistory[index1].nameColor = this.colors[index2];
                this.chatHistory[index1].messColor = Color.LightSteelBlue;
                flag = true;
                break;
              }
            }
            else
            {
              this.chatHistory[index1].nameColor = this.hostblue;
              this.chatHistory[index1].messColor = Color.White;
              flag = true;
              break;
            }
          }
          if (!flag)
          {
            this.chatHistory[index1].nameColor = Color.Gray;
            this.chatHistory[index1].messColor = Color.Gray;
          }
        }
      }
    }

    public void echoCOMMANDS()
    {
      this.addChatMsg("*****************************************************", Color.Yellow, "", Color.Black, 160, 5UL);
      this.addChatMsg("*", Color.Yellow, "", Color.White, 160, 5UL);
      this.addChatMsg("*   :info         ", Color.Yellow, " LIST ALL AVAILABLE COMMANDS", Color.White, 160, 5UL);
      this.addChatMsg("*   :invite         ", Color.Yellow, " INVITE FRIEND", Color.White, 160, 5UL);
      this.addChatMsg("*   :cheats         ", Color.Yellow, " TOGGLE ALLOWED CHEATS", Color.White, 160, 5UL);
      this.addChatMsg("*   :friendly   ", Color.Yellow, " TOGGLE FRIENDLY FIRE ON/OFF ", Color.White, 160, 5UL);
      this.addChatMsg("*   :password ", Color.Yellow, " MAKE LOBBY PASSWORD REQUIRED ", Color.White, 160, 5UL);
      this.addChatMsg("*   :restart     ", Color.Yellow, " RESTART THE LEVEL  ", Color.White, 160, 5UL);
      this.addChatMsg("*   :more ", Color.Yellow, " LIST MORE COMMANDS", Color.White, 160, 5UL);
      this.addChatMsg("*", Color.Yellow, "", Color.White, 160, 5UL);
    }

    public void echoCOMMANDS2()
    {
      this.addChatMsg("*****************************************************", Color.Yellow, "", Color.Black, 160, 5UL);
      this.addChatMsg("*", Color.Yellow, "", Color.White, 160, 5UL);
      this.addChatMsg("*   :skin        ", Color.Yellow, " CHANGE CHARACTER SKIN  :skin daisy", Color.White, 160, 5UL);
      this.addChatMsg("*   :names         ", Color.Yellow, " TOGGLE OVERHEAD NAMES", Color.White, 160, 5UL);
      this.addChatMsg("*   :glow     ", Color.Yellow, " CHANGE GLOW TYPE", Color.White, 160, 5UL);
      this.addChatMsg("*   :bobble        ", Color.Yellow, " TOGGLE BIG HEADS", Color.White, 160, 5UL);
      this.addChatMsg("*   :kick      ", Color.Yellow, " KICK PLAYER FROM GAME ", Color.White, 160, 5UL);
      this.addChatMsg("*   :push      ", Color.Yellow, " PUSH PLAYER FROM BARN", Color.White, 160, 5UL);
      this.addChatMsg("*", Color.Yellow, "", Color.White, 160, 5UL);
    }

    public void refreshList()
    {
      this.predayList = new List<int>[7]
      {
        new List<int>() { 1 },
        new List<int>() { 28, 24 },
        new List<int>() { 29, 34 },
        new List<int>() { 26, 25 },
        new List<int>() { 27 },
        new List<int>() { 30, 9 },
        new List<int>() { 32 }
      };
      this.dayList = new List<int>[9]
      {
        new List<int>() { 1 },
        new List<int>() { 2, 13 },
        new List<int>() { 18, 35 },
        new List<int>() { 7, 3, 22 },
        new List<int>() { 8, 4, 22 },
        new List<int>() { 9, 14 },
        new List<int>() { 19, 21 },
        new List<int>() { 30, 31 },
        new List<int>() { 33 }
      };
    }

    public string getTip(int index)
    {
      if (!this.usingMouse)
        this.dayTips = new string[37]
        {
          "",
          "run around the farm, explore",
          "use LeftBumper to highlight enemies",
          "find the water pump to heal",
          "Electric Fence has been repaired",
          "check the mailbox for packages",
          "learn to use the grinder",
          "use LeftTrigger to melee",
          "press A to jump over enemies",
          "Dpad-Up to use flashlight",
          "Click R3 to change cameras",
          "Press Start to edit Camera",
          "customize your camera views",
          "good job...",
          "almost there...",
          "only a few remaining...",
          "now is a good time to explore",
          "use the flashlight...",
          "use RightBumper to clean yourself",
          "This is Revenge-Day !!",
          "Revenge-Days have infinite ammo",
          "Revenge-Day is once a week",
          "stats LeftBumper",
          "Shoot the Grinder Buttons",
          "Back button to open Wallet Menu",
          "Press Start to Edit Cameras",
          "Click R3 to change cameras",
          "Pistols have infinite Ammo",
          "Talk to the Farmer",
          "Y Button to switch Weapons",
          "LeftTrigger to shove whole bodies",
          "shoot or kick small parts",
          "Tutorial is almost over",
          "end of Tutorial",
          "there is a Boss Fight Day 10",
          "things are going to get tough",
          "Enter Key open Chatbox"
        };
      else
        this.dayTips = new string[37]
        {
          "",
          "run around the farm, explore",
          "use " + this.getNameForTip(this.e_key) + " to highlight enemies",
          "find the water pump to heal",
          "Electric Fence has been repaired",
          "check the mailbox for packages",
          "learn to use the grinder",
          "use " + this.getNameForTip(this.rmb_key) + " to melee",
          "press " + this.getNameForTip(this.space_key) + " to jump over enemies",
          this.getNameForTip(this.f_key) + " to use flashlight",
          "F1 F2 F3 to change camera",
          "Press F10 to edit Camera",
          "customize your camera views",
          "good job...",
          "almost there...",
          "only a few remaining...",
          "now is a good time to explore",
          "use the flashlight...",
          "press " + this.getNameForTip(this.t_key) + " to clean yourself",
          "This is Revenge-Day !!",
          "Revenge-Days have infinite ammo",
          "Revenge-Day is once a week",
          "stats press " + this.getNameForTip(this.tab_key),
          "Shoot the Grinder Buttons",
          "ESC Key to open Wallet Menu",
          "Press F10 to Edit Cameras",
          "F1 F2 F3 to change cameras",
          "Pistols have infinite Ammo",
          "Talk to the Farmer",
          "press " + this.getNameForTip(this.q_key) + " to switch Weapons",
          "press " + this.getNameForTip(this.rmb_key) + " to shove whole bodies",
          "shoot or kick small parts",
          "Tutorial is almost over",
          "end of Tutorial",
          "there is a Boss Fight Day 10",
          "things are going to get tough",
          "Enter Key for Chatbox"
        };
      return this.dayTips[index];
    }

    public string getNameForTip(Microsoft.Xna.Framework.Input.Keys k)
    {
      string nameForTip = k.ToString() + " Key";
      if (k == Microsoft.Xna.Framework.Input.Keys.VolumeUp)
        nameForTip = "RMB";
      if (k == Microsoft.Xna.Framework.Input.Keys.VolumeDown)
        nameForTip = "LMB";
      if (k == Microsoft.Xna.Framework.Input.Keys.VolumeMute)
        nameForTip = "MMB";
      if (k == Microsoft.Xna.Framework.Input.Keys.Print)
        nameForTip = "BUT1";
      if (k == Microsoft.Xna.Framework.Input.Keys.PrintScreen)
        nameForTip = "BUT2";
      return nameForTip;
    }

    public void queryKeySquare(Rectangle rr, int index, ref int whichKEY)
    {
      Vector2 vector2 = this.adjustVector2(this.mymouse);
      if (((double) vector2.Y <= (double) rr.Y || (double) vector2.Y > (double) (rr.Y + rr.Height) || (double) vector2.X <= (double) rr.X ? 0 : ((double) vector2.X <= (double) (rr.X + rr.Width) ? 1 : 0)) == 0)
        return;
      whichKEY = index;
    }

    public void getXkey()
    {
      this.myXkey = this.x_key.ToString();
      if (this.x_key == Microsoft.Xna.Framework.Input.Keys.VolumeUp)
        this.myXkey = "RMB";
      if (this.x_key == Microsoft.Xna.Framework.Input.Keys.VolumeDown)
        this.myXkey = "LMB";
      if (this.x_key == Microsoft.Xna.Framework.Input.Keys.VolumeMute)
        this.myXkey = "MMB";
      if (this.x_key == Microsoft.Xna.Framework.Input.Keys.Print)
        this.myXkey = "BUT1";
      if (this.x_key != Microsoft.Xna.Framework.Input.Keys.PrintScreen)
        return;
      this.myXkey = "BUT2";
    }

    public string getKeyName(Microsoft.Xna.Framework.Input.Keys k)
    {
      string keyName = k.ToString();
      if (k == Microsoft.Xna.Framework.Input.Keys.VolumeUp)
        keyName = "RMB";
      if (k == Microsoft.Xna.Framework.Input.Keys.VolumeDown)
        keyName = "LMB";
      if (k == Microsoft.Xna.Framework.Input.Keys.VolumeMute)
        keyName = "MMB";
      if (k == Microsoft.Xna.Framework.Input.Keys.Print)
        keyName = "BUT1";
      if (k == Microsoft.Xna.Framework.Input.Keys.PrintScreen)
        keyName = "BUT2";
      return keyName;
    }

    public void drawInteractive(
      SpriteBatch spriteBatch,
      ref int whichKEY,
      ref int thisKEY,
      SpriteFont font2,
      ref int val,
      ref float yy,
      string thekey,
      string descr)
    {
      float num = 23f;
      float x1 = 100f;
      float x2 = 400f;
      yy += num;
      ++val;
      this.bluePen = whichKEY != val ? this.bluePen2 : this.grnPen;
      if (thisKEY == val)
        this.bluePen = this.redPen;
      spriteBatch.DrawString(this.scribblefont, descr + " :", this.topcorner + new Vector2(x1, yy), this.bluePen);
      spriteBatch.DrawString(this.scribblefont, thekey, this.topcorner + new Vector2(x2, yy), this.bluePen);
      Vector2 vector2 = this.scribblefont.MeasureString(thekey);
      vector2.Y /= 3f;
      this.queryKeySquare(new Rectangle((int) ((double) this.topcorner.X + (double) x2), (int) ((double) this.topcorner.Y + (double) yy + (double) vector2.Y), (int) vector2.X, (int) vector2.Y), val, ref whichKEY);
    }

    public void drawKeyBindings2(
      SpriteBatch spriteBatch,
      ref int whichKEY,
      ref int thisKEY,
      SpriteFont font2)
    {
      this.topcorner = new Vector2((float) (640 - this.blankpaper.Width / 2), (float) (370 - this.blankpaper.Height / 2));
      float num1 = 100f;
      float num2 = 22f;
      float x1 = 100f;
      float x2 = 400f;
      int val1 = 0;
      num1 = 78f;
      num1 = 56f;
      float yy1 = 34f;
      spriteBatch.Draw(this.blankpaper, this.topcorner, Color.White);
      int val2 = 28;
      this.drawInteractive(spriteBatch, ref whichKEY, ref thisKEY, font2, ref val2, ref yy1, this.getKeyName(this.plus_key), "change crosshair");
      this.drawInteractive(spriteBatch, ref whichKEY, ref thisKEY, font2, ref val1, ref yy1, this.getKeyName(this.escape_key), "open wallet");
      this.drawInteractive(spriteBatch, ref whichKEY, ref thisKEY, font2, ref val1, ref yy1, this.getKeyName(this.lmb_key), "fire gun/use");
      this.drawInteractive(spriteBatch, ref whichKEY, ref thisKEY, font2, ref val1, ref yy1, this.getKeyName(this.rmb_key), "melee");
      this.drawInteractive(spriteBatch, ref whichKEY, ref thisKEY, font2, ref val1, ref yy1, "mouse", "aim/look");
      this.drawInteractive(spriteBatch, ref whichKEY, ref thisKEY, font2, ref val1, ref yy1, this.getKeyName(this.w_key), "forward");
      this.drawInteractive(spriteBatch, ref whichKEY, ref thisKEY, font2, ref val1, ref yy1, this.getKeyName(this.s_key), "backward");
      this.drawInteractive(spriteBatch, ref whichKEY, ref thisKEY, font2, ref val1, ref yy1, this.getKeyName(this.a_key), "strafe left");
      this.drawInteractive(spriteBatch, ref whichKEY, ref thisKEY, font2, ref val1, ref yy1, this.getKeyName(this.d_key), "strafe right");
      this.drawInteractive(spriteBatch, ref whichKEY, ref thisKEY, font2, ref val1, ref yy1, this.getKeyName(this.space_key), "jump");
      this.drawInteractive(spriteBatch, ref whichKEY, ref thisKEY, font2, ref val1, ref yy1, this.getKeyName(this.leftshift_key), "sprint");
      this.drawInteractive(spriteBatch, ref whichKEY, ref thisKEY, font2, ref val1, ref yy1, this.getKeyName(this.r_key), "reload");
      this.drawInteractive(spriteBatch, ref whichKEY, ref thisKEY, font2, ref val1, ref yy1, this.getKeyName(this.x_key), "interact");
      this.drawInteractive(spriteBatch, ref whichKEY, ref thisKEY, font2, ref val1, ref yy1, this.getKeyName(this.q_key), "switch weapons");
      this.drawInteractive(spriteBatch, ref whichKEY, ref thisKEY, font2, ref val1, ref yy1, this.getKeyName(this.e_key), "highlight enemies");
      this.drawInteractive(spriteBatch, ref whichKEY, ref thisKEY, font2, ref val1, ref yy1, this.getKeyName(this.f_key), "flashlight");
      float y = yy1 + num2;
      int index1 = val1 + 1;
      this.bluePen = whichKEY != index1 ? this.bluePen2 : this.grnPen;
      if (thisKEY == index1)
        this.bluePen = this.redPen;
      spriteBatch.DrawString(this.scribblefont, "pickups :", this.topcorner + new Vector2(x1, (float) (int) y), this.bluePen);
      Vector2 vector2_1 = this.scribblefont.MeasureString(this.one_key.ToString() + " ");
      vector2_1.Y /= 3f;
      spriteBatch.DrawString(this.scribblefont, this.one_key.ToString() + " ", this.topcorner + new Vector2(x2, y), this.bluePen);
      this.queryKeySquare(new Rectangle((int) ((double) this.topcorner.X + (double) x2), (int) ((double) this.topcorner.Y + (double) y + (double) vector2_1.Y), (int) vector2_1.X, (int) vector2_1.Y), index1, ref whichKEY);
      int index2 = index1 + 1;
      this.bluePen = whichKEY != index2 ? this.bluePen2 : this.grnPen;
      if (thisKEY == index2)
        this.bluePen = this.redPen;
      Vector2 vector2_2 = this.scribblefont.MeasureString(this.two_key.ToString() + " ");
      vector2_2.Y /= 3f;
      spriteBatch.DrawString(this.scribblefont, this.two_key.ToString() + " ", this.topcorner + new Vector2(vector2_1.X + x2, y), this.bluePen);
      this.queryKeySquare(new Rectangle((int) ((double) this.topcorner.X + (double) vector2_1.X + (double) x2), (int) ((double) this.topcorner.Y + (double) y + (double) vector2_2.Y), (int) vector2_2.X, (int) vector2_2.Y), index2, ref whichKEY);
      int index3 = index2 + 1;
      this.bluePen = whichKEY != index3 ? this.bluePen2 : this.grnPen;
      if (thisKEY == index3)
        this.bluePen = this.redPen;
      Vector2 vector2_3 = this.scribblefont.MeasureString(this.three_key.ToString() + " ");
      vector2_3.Y /= 3f;
      spriteBatch.DrawString(this.scribblefont, this.three_key.ToString() + " ", this.topcorner + new Vector2(vector2_2.X + vector2_1.X + x2, y), this.bluePen);
      this.queryKeySquare(new Rectangle((int) ((double) this.topcorner.X + (double) vector2_2.X + (double) vector2_1.X + (double) x2), (int) ((double) this.topcorner.Y + (double) y + (double) vector2_3.Y), (int) vector2_3.X, (int) vector2_3.Y), index3, ref whichKEY);
      int index4 = index3 + 1;
      this.bluePen = whichKEY != index4 ? this.bluePen2 : this.grnPen;
      if (thisKEY == index4)
        this.bluePen = this.redPen;
      Vector2 vector2_4 = this.scribblefont.MeasureString(this.four_key.ToString() + " ");
      vector2_4.Y /= 3f;
      spriteBatch.DrawString(this.scribblefont, this.four_key.ToString() + " ", this.topcorner + new Vector2(vector2_3.X + vector2_2.X + vector2_1.X + x2, y), this.bluePen);
      this.queryKeySquare(new Rectangle((int) ((double) this.topcorner.X + (double) vector2_3.X + (double) vector2_2.X + (double) vector2_1.X + (double) x2), (int) ((double) this.topcorner.Y + (double) y + (double) vector2_4.Y), (int) vector2_4.X, (int) vector2_4.Y), index4, ref whichKEY);
      float yy2 = y + num2;
      int index5 = index4 + 1;
      this.bluePen = whichKEY != index5 ? this.bluePen2 : this.grnPen;
      if (thisKEY == index5)
        this.bluePen = this.redPen;
      spriteBatch.DrawString(this.scribblefont, "camera views :", this.topcorner + new Vector2(x1, (float) (int) yy2), this.bluePen);
      vector2_1 = this.scribblefont.MeasureString(this.f1_key.ToString() + " ");
      vector2_1.Y /= 3f;
      spriteBatch.DrawString(this.scribblefont, this.f1_key.ToString() + " ", this.topcorner + new Vector2(x2, yy2), this.bluePen);
      this.queryKeySquare(new Rectangle((int) ((double) this.topcorner.X + (double) x2), (int) ((double) this.topcorner.Y + (double) yy2 + (double) vector2_1.Y), (int) vector2_1.X, (int) vector2_1.Y), index5, ref whichKEY);
      int index6 = index5 + 1;
      this.bluePen = whichKEY != index6 ? this.bluePen2 : this.grnPen;
      if (thisKEY == index6)
        this.bluePen = this.redPen;
      vector2_2 = this.scribblefont.MeasureString(this.f2_key.ToString() + " ");
      vector2_2.Y /= 3f;
      spriteBatch.DrawString(this.scribblefont, this.f2_key.ToString() + " ", this.topcorner + new Vector2(vector2_1.X + x2, yy2), this.bluePen);
      this.queryKeySquare(new Rectangle((int) ((double) this.topcorner.X + (double) vector2_1.X + (double) x2), (int) ((double) this.topcorner.Y + (double) yy2 + (double) vector2_2.Y), (int) vector2_2.X, (int) vector2_2.Y), index6, ref whichKEY);
      int val3 = index6 + 1;
      this.bluePen = whichKEY != val3 ? this.bluePen2 : this.grnPen;
      if (thisKEY == val3)
        this.bluePen = this.redPen;
      Vector2 vector2_5 = this.scribblefont.MeasureString(this.f3_key.ToString() + " ");
      vector2_5.Y /= 3f;
      spriteBatch.DrawString(this.scribblefont, this.f3_key.ToString(), this.topcorner + new Vector2(vector2_2.X + vector2_1.X + x2, yy2), this.bluePen);
      this.queryKeySquare(new Rectangle((int) ((double) this.topcorner.X + (double) vector2_2.X + (double) vector2_1.X + (double) x2), (int) ((double) this.topcorner.Y + (double) yy2 + (double) vector2_5.Y), (int) vector2_5.X, (int) vector2_5.Y), val3, ref whichKEY);
      this.drawInteractive(spriteBatch, ref whichKEY, ref thisKEY, font2, ref val3, ref yy2, this.getKeyName(this.tab_key), "round stats / minimap");
      this.drawInteractive(spriteBatch, ref whichKEY, ref thisKEY, font2, ref val3, ref yy2, this.getKeyName(this.up_key), "fov adjust");
      this.drawInteractive(spriteBatch, ref whichKEY, ref thisKEY, font2, ref val3, ref yy2, this.getKeyName(this.down_key), "fov adjust");
      this.drawInteractive(spriteBatch, ref whichKEY, ref thisKEY, font2, ref val3, ref yy2, this.getKeyName(this.left_key), "fov reset");
      this.drawInteractive(spriteBatch, ref whichKEY, ref thisKEY, font2, ref val3, ref yy2, this.getKeyName(this.t_key), "wiping face");
      this.drawInteractive(spriteBatch, ref whichKEY, ref thisKEY, font2, ref val3, ref yy2, this.getKeyName(this.enter_key), "open chatbox");
      if (whichKEY == 36 || whichKEY == 30 || whichKEY == 33)
      {
        whichKEY = 0;
        thisKEY = 0;
      }
      this.queryKeySquare(new Rectangle((int) this.topcorner.X + 520, (int) this.topcorner.Y + 20, 50, 26), 36, ref whichKEY);
      this.queryKeySquare(new Rectangle((int) this.topcorner.X + 221, (int) this.topcorner.Y + 629, 71, 34), 30, ref whichKEY);
      this.queryKeySquare(new Rectangle((int) this.topcorner.X + 341, (int) this.topcorner.Y + 629, 71, 34), 33, ref whichKEY);
      spriteBatch.Draw(this.paper1, this.topcorner + new Vector2(520f, 20f), new Rectangle?(this.cancelButtonBlue), Color.White);
      spriteBatch.Draw(this.paper1, this.topcorner + new Vector2(221f, 629f), new Rectangle?(this.saveButtonBlue), Color.White);
      spriteBatch.Draw(this.paper1, this.topcorner + new Vector2(341f, 629f), new Rectangle?(this.resetButtonBlue), Color.White);
      if (whichKEY == 36)
        spriteBatch.Draw(this.paper1, this.topcorner + new Vector2(520f, 20f), new Rectangle?(this.cancelButtonRed), Color.White);
      if (whichKEY == 30)
        spriteBatch.Draw(this.paper1, this.topcorner + new Vector2(221f, 629f), new Rectangle?(this.saveButtonRed), Color.White);
      if (whichKEY == 33)
        spriteBatch.Draw(this.paper1, this.topcorner + new Vector2(341f, 629f), new Rectangle?(this.resetButtonRed), Color.White);
      if (thisKEY != 0 && thisKEY != 33 && thisKEY != 30 && thisKEY != 36)
      {
        string text = "Press Any Key\nTo Remap Red Key";
        spriteBatch.DrawString(font2, text, new Vector2(980f, 300f), this.redPen);
      }
      else if (whichKEY != 0 && whichKEY != 33 && whichKEY != 30 && whichKEY != 36)
      {
        string text = "Left Mouse Click\nTo Choose Key";
        spriteBatch.DrawString(font2, text, new Vector2(980f, 300f), this.grnPen);
      }
      else
      {
        if (whichKEY != 0 && whichKEY != 33 && whichKEY != 30 && whichKEY != 36)
          return;
        string text = "Remap Keys Use\nMouse to Highlight";
        spriteBatch.DrawString(font2, text, new Vector2(980f, 300f), Color.White);
      }
    }

    public void LoadAstroParameters()
    {
      this.inSpace = true;
      this.bgindex = 1;
      Randoms.initRandom(7);
      this.rr = new Random();
      this.aspectratio2 = !this.fullmode ? (float) this.width / (float) this.hite : this.aspectratio * 1.77777f;
      this.startwidth = 1280f;
      this.starthite = 720f;
      this.startaspect = (float) Math.Round((double) this.startwidth / (double) this.starthite, 2);
      this.stretch = this.startaspect / this.aspectratio2;
      this.xoffset = (float) (0.0 - ((double) this.width * (double) this.stretch - (double) this.width) * 0.5);
      float num = (float) (((double) this.hite - (double) this.hite / (double) this.stretch) * 0.5);
      if ((double) this.startaspect >= (double) this.aspectratio2)
      {
        this.ScaleMatrix1 = Matrix.CreateScale((float) this.width / this.startwidth, (float) this.hite / this.starthite / this.stretch, 1f) * Matrix.CreateTranslation(0.0f, num, 0.0f);
        this.ScaleRect1 = new Rectangle(0, (int) num, this.width, (int) ((double) this.hite / (double) this.stretch));
        this.diffscaler = new Vector2(this.startwidth / (float) this.width, this.starthite / (float) this.hite * this.stretch);
      }
      else
      {
        this.ScaleMatrix1 = Matrix.CreateScale(this.stretch * ((float) this.width / this.startwidth), (float) this.hite / this.starthite, 1f) * Matrix.CreateTranslation(this.xoffset, 0.0f, 0.0f);
        this.ScaleRect1 = new Rectangle((int) this.xoffset, 0, (int) ((double) this.width * (double) this.stretch), this.hite);
        this.diffscaler = new Vector2(this.startwidth / (float) this.width, this.starthite / (float) this.hite * this.stretch);
      }
    }

    public void LoadAstro()
    {
      if (this.astroloaded)
        return;
      astroDupe.sics = new List<int>();
      astroDupe.acc = 650f;
      astroDupe.farmLocation = new Vector3(0.0f, 5f, 0.0f);
      astroDupe.constantRoverPosition = Vector3.Zero;
      astroDupe.facility = Vector4.Zero;
      astro.teamCount = 0;
      astro.oldteamCount = 0;
      astro.someonedied = false;
      astro.inDumper = Matrix.Identity;
      astro.rovpos = Vector3.Zero;
      astro.rovveloc = Vector3.Zero;
      Lander.farmLocation = Vector3.Zero;
      Lander.nearfarm = false;
      Rover.turnSpeed = 0.11f;
      Rover.max = -65f;
      Rover.realGrav = -0.8f;
      Rover.fric = 0.9f;
      Rover.fricOrig = 0.9f;
      Rover.rockhitCount = 0;
      Rover.farmLocation = Vector3.Zero;
      Rover.nearfarm = false;
      Overlay.manbouy = Vector3.Zero;
      Facility.atMain = false;
      Facility.offset = new Vector3(0.0f, 0.0f, 0.0f);
      Facility.outsideCastle = true;
      Facility.inFacility = false;
      Facility.atSwitch = false;
      Facility.atSwitch2 = false;
      Facility.atMain = false;
      Facility.createWorkerLoc = Vector4.Zero;
      Facility.openConstruction = false;
      Facility.mypath.Clear();
      Facility.facilityPlot.Clear();
      Facility.reachPlot.Clear();
      Facility.dummyPlot.Clear();
      gemstruct.totalGems = 0;
      gemstruct.setitRight = Matrix.Identity;
      gemstruct.setVacuum = Matrix.Identity;
      gemstruct.inDumper = Matrix.Identity;
      objDupe.objectData = new int[500, 500];
      objDupe.flowersaved = 0;
      this.controllerX = this.content.Load<Model>("astro\\models\\controller");
      this.astroModel = this.content.Load<Model>("astro\\npc\\astroWalk1");
      this.astronaut = new astro();
      this.astronaut.LoadContent(this.content, this);
      this.Globalstarmap.LoadContent(this, this.content, this.GraphicsDevice, 1600, 25000, false, 0);
      this.blankTexture = this.content.Load<Texture2D>("astro\\menus\\blank");
      this.tahoma1 = this.content.Load<SpriteFont>("astro\\fonts\\tahoma1");
      this.tahoma2 = this.content.Load<SpriteFont>("astro\\fonts\\tahoma2");
      this.whiteTexture = new Texture2D(this.GraphicsDevice, 1, 1);
      this.whiteTexture.SetData<Color>(new Color[1]
      {
        Color.White
      });
      this.camedit = this.content.Load<Texture2D>("astro\\textures\\camedit");
      this.entryrgb2 = this.content.Load<Texture2D>("astro\\textures\\entryRGB3");
      this.entryShad = this.content.Load<Texture2D>("astro\\textures\\entryShad2");
      this.messageBlob = this.content.Load<Texture2D>("astro\\textures//messageblob");
      this.iconbar = this.content.Load<Texture2D>("astro\\textures//iconbar");
      this.hudbuttons = this.content.Load<Texture2D>("astro\\textures//hudbuttons");
      this.helmet1 = this.content.Load<Texture2D>("astro\\textures//helmet1");
      this.helmet2 = this.content.Load<Texture2D>("astro\\textures//helmet2");
      this.interfaceBlob = this.content.Load<Texture2D>("astro\\textures\\interfaceBlob3");
      this.rooms = this.content.Load<Texture2D>("astro\\textures//rooms");
      this.codeBG = this.content.Load<Texture2D>("astro\\loading//dossy");
      this.buttonGong = this.content.Load<SoundEffect>("astro\\Audio//gong");
      this.gear2 = this.content.Load<Texture2D>("astro\\sprites//icons//gear1");
      this.loadBG = this.content.Load<Texture2D>("astro\\menus//Loading");
      this.loadfont1 = this.content.Load<SpriteFont>("astro\\fonts//tag");
      this.roverModel = this.content.Load<Model>("astro\\models\\tank3");
      this.origTransforms = new Matrix[this.roverModel.Bones.Count];
      this.roverModel.CopyBoneTransformsTo(this.origTransforms);
      this.halo = this.content.Load<SpriteFont>("astro\\fonts\\halo");
      this.halo2 = this.content.Load<SpriteFont>("astro\\fonts\\halo2");
      this.glow1 = this.content.Load<Texture2D>("astro\\menus\\glow1");
      this.opensolar = this.content.Load<SoundEffect>("astro\\Audio\\solarOpen");
      this.fuellow = this.content.Load<SoundEffect>("astro\\Audio\\fuelMore");
      this.fuelfull = this.content.Load<SoundEffect>("astro\\Audio\\fuelFull");
      this.grow = this.content.Load<SoundEffect>("astro\\Audio\\grow");
      this.landerEngine = this.content.Load<SoundEffect>("astro\\Audio\\thrust");
      this.roverEngine = this.content.Load<SoundEffect>("astro\\Audio\\engine");
      this.dropEngine = this.content.Load<SoundEffect>("astro\\Audio\\engine2");
      this.gravel = this.content.Load<SoundEffect>("astro\\Audio\\dirt2");
      this.overture = this.content.Load<SoundEffect>("astro\\Audio\\score");
      this.breath = this.content.Load<SoundEffect>("astro\\Audio\\breath2");
      this.boom = this.content.Load<SoundEffect>("astro\\Audio\\boom1");
      this.clickmenu = this.content.Load<SoundEffect>("astro\\Audio\\clickmenu");
      this.forward = this.content.Load<SoundEffect>("astro\\Audio\\forward");
      this.back = this.content.Load<SoundEffect>("astro\\Audio\\back");
      this.click = this.content.Load<SoundEffect>("astro\\audio\\switch2");
      this.drop = this.content.Load<SoundEffect>("astro\\audio\\drop");
      this.horn = this.content.Load<SoundEffect>("astro\\Audio\\horn1");
      this.select = this.content.Load<SoundEffect>("astro\\audio\\select1");
      this.step = this.content.Load<SoundEffect>("astro\\audio\\dirtStep3");
      this.crack = this.content.Load<SoundEffect>("astro\\Audio\\crack");
      this.cablesnap = this.content.Load<SoundEffect>("astro\\Audio\\cable");
      this.release = this.content.Load<SoundEffect>("astro\\Audio\\release");
      this.rejected = this.content.Load<SoundEffect>("astro\\Audio\\rejected");
      this.radio1 = this.content.Load<SoundEffect>("astro\\Audio\\radio1");
      this.radio2 = this.content.Load<SoundEffect>("astro\\Audio\\radioTalk2");
      this.radio3 = this.content.Load<SoundEffect>("astro\\Audio\\radioTalk3");
      this.eraseBeacon = this.content.Load<SoundEffect>("astro\\Audio\\pickBeacon");
      this.breakage = this.content.Load<SoundEffect>("astro\\Audio\\breakage");
      this.breakage2 = this.content.Load<SoundEffect>("astro\\Audio\\breakage2");
      this.cheer = this.content.Load<SoundEffect>("astro\\Audio\\cheer-01");
      this.dropBeacon = this.content.Load<SoundEffect>("astro\\Audio\\dropBeacon");
      this.warning = this.content.Load<SoundEffect>("astro\\Audio\\0527");
      this.boulderhit = this.content.Load<SoundEffect>("astro\\Audio\\boulderhit");
      this.boulderhit2 = this.content.Load<SoundEffect>("astro\\Audio\\boulderhit2");
      this.boulderhit3 = this.content.Load<SoundEffect>("astro\\Audio\\boulderhit3");
      this.boulderhit4 = this.content.Load<SoundEffect>("astro\\Audio\\boulderhit4");
      this.shalehit1 = this.content.Load<SoundEffect>("astro\\Audio\\shale");
      this.steeldrum1 = this.content.Load<SoundEffect>("astro\\Audio\\steel");
      this.steeldrum2 = this.content.Load<SoundEffect>("astro\\Audio\\synth");
      this.confirm = this.content.Load<SoundEffect>("astro\\Audio\\confirm1");
      this.forklift = this.content.Load<SoundEffect>("astro\\Audio\\forklift");
      this.enginex = this.content.Load<SoundEffect>("astro\\Audio\\enginex");
      this.scoopx = this.content.Load<SoundEffect>("astro\\Audio\\scoopx");
      this.shocks = this.content.Load<SoundEffect>("astro\\Audio\\shocks");
      this.groundhit = this.content.Load<SoundEffect>("astro\\Audio\\groundhit");
      this.ramp = this.content.Load<SoundEffect>("astro\\Audio\\ramp2");
      this.tada = this.content.Load<SoundEffect>("astro\\Audio\\tada");
      this.tada2 = this.content.Load<SoundEffect>("astro\\Audio\\tada2");
      this.tada3 = this.content.Load<SoundEffect>("astro\\Audio\\tadar3");
      this.tada4 = this.content.Load<SoundEffect>("astro\\Audio\\tadar4");
      this.tada5 = this.content.Load<SoundEffect>("astro\\Audio\\tadar5");
      this.tada6 = this.content.Load<SoundEffect>("astro\\Audio\\tadar6");
      this.tada7 = this.content.Load<SoundEffect>("astro\\Audio\\tadar7");
      this.tada10 = this.content.Load<SoundEffect>("astro\\Audio\\tadar10");
      this.gemfound = this.content.Load<SoundEffect>("astro\\Audio\\gemfound");
      this.land = this.content.Load<SoundEffect>("astro\\Audio\\land");
      this.jump = this.content.Load<SoundEffect>("astro\\Audio\\jump");
      this.bone = this.content.Load<SoundEffect>("astro\\Audio\\bone1");
      this.alarm1 = this.content.Load<SoundEffect>("astro\\Audio\\alarm1");
      this.lever = this.content.Load<SoundEffect>("astro\\Audio\\lever1");
      this.door = this.content.Load<SoundEffect>("astro\\Audio\\door");
      this.typewriterblank = 450f;
      this.textflag = 0;
      this.typewriterwait = (float) this.rr.Next(700, 1100);
      this.typeposition = 0.0f;
      this.typevertical = (float) this.rr.Next(430, 500);
      this.typewriterdelay = this.rr.Next(2, 6);
      this.astroloaded = true;
    }

    public void LoadSpacePrefs()
    {
      this.spaceprefs = this.storageSpacePrefs.LoadPreferences();
      if (this.storageSpacePrefs.status == "fail")
      {
        this.horn.Play(this.ev, 1f, 0.0f);
        this.horn.Play(this.ev, 1f, 0.0f);
      }
      else if (this.spaceprefs.fileExists)
      {
        this.spaceVersion = this.spaceprefs.fileVersion;
        this.mv = this.spaceprefs.mv;
        this.ev = this.spaceprefs.ev;
        this.voiceVolume = this.spaceprefs.vv;
        this.df = this.spaceprefs.df;
        this.brightness = this.spaceprefs.brightness;
        this.contrast = this.spaceprefs.contrast;
        this.space_invertX = this.spaceprefs.pad_invertX;
        this.space_sentivityX = this.spaceprefs.pad_sensitivityX;
        this.space_invertY = this.spaceprefs.pad_invertY;
        this.space_sentivityY = this.spaceprefs.pad_sensitivityY;
        this.space_winvertX = this.spaceprefs.pad_winvertX;
        this.space_wsentivityX = this.spaceprefs.pad_wsensitivityX;
        this.space_winvertY = this.spaceprefs.pad_winvertY;
        this.space_wsentivityY = this.spaceprefs.pad_wsensitivityY;
        this.space_rinvertX = this.spaceprefs.pad_rinvertX;
        this.space_rsentivityX = this.spaceprefs.pad_rsensitivityX;
        this.space_rinvertY = this.spaceprefs.pad_rinvertY;
        this.space_rsentivityY = this.spaceprefs.pad_rsensitivityY;
        this.vibroSetting = this.spaceprefs.pad_vibro;
        try
        {
          Array.Copy((Array) this.spaceprefs.allcamsradius, (Array) this.allcamsradius, 4);
          Array.Copy((Array) this.spaceprefs.allcamsorbit, (Array) this.allcamsorbit, 4);
          Array.Copy((Array) this.spaceprefs.allcamslens, (Array) this.allcamslens, 4);
          Array.Copy((Array) this.spaceprefs.allcamsaltitude, (Array) this.allcamsaltitude, 4);
        }
        catch
        {
        }
        this.roverindex = this.spaceprefs.roverindex;
        this.roverrotlock = this.spaceprefs.roverrotlock;
        this.roverhitelock = this.spaceprefs.roverhitelock;
        this.landerindex = this.spaceprefs.landerindex;
        this.landerrotlock = this.spaceprefs.landerrotlock;
        this.landerhitelock = this.spaceprefs.landerhitelock;
        try
        {
          Array.Copy((Array) this.spaceprefs.roverdist, (Array) this.roverdist, 3);
          Array.Copy((Array) this.spaceprefs.roverheight, (Array) this.roverheight, 3);
          Array.Copy((Array) this.spaceprefs.roverradian, (Array) this.roverradian, 3);
          Array.Copy((Array) this.spaceprefs.landerdist, (Array) this.landerdist, 3);
          Array.Copy((Array) this.spaceprefs.landerheight, (Array) this.landerheight, 3);
          Array.Copy((Array) this.spaceprefs.landerradian, (Array) this.landerradian, 3);
        }
        catch
        {
        }
      }
      else
      {
        this.horn.Play(this.ev, -1f, 0.0f);
        this.horn.Play(this.ev, -1f, 0.0f);
      }
    }

    public void SaveSpacePrefs()
    {
      this.spaceprefs.fileVersion = this.spaceVersion;
      this.spaceprefs.mv = this.mv;
      this.spaceprefs.ev = this.ev;
      this.spaceprefs.vv = this.voiceVolume;
      this.spaceprefs.df = this.df;
      this.spaceprefs.brightness = this.brightness;
      this.spaceprefs.contrast = this.contrast;
      this.spaceprefs.pad_invertX = this.space_invertX;
      this.spaceprefs.pad_sensitivityX = this.space_sentivityX;
      this.spaceprefs.pad_invertY = this.space_invertY;
      this.spaceprefs.pad_sensitivityY = this.space_sentivityY;
      this.spaceprefs.pad_vibro = this.vibroSetting;
      this.spaceprefs.pad_winvertX = this.space_winvertX;
      this.spaceprefs.pad_wsensitivityX = this.space_wsentivityX;
      this.spaceprefs.pad_winvertY = this.space_winvertY;
      this.spaceprefs.pad_wsensitivityY = this.space_wsentivityY;
      this.spaceprefs.pad_rinvertX = this.space_rinvertX;
      this.spaceprefs.pad_rsensitivityX = this.space_rsentivityX;
      this.spaceprefs.pad_rinvertY = this.space_rinvertY;
      this.spaceprefs.pad_rsensitivityY = this.space_rsentivityY;
      this.spaceprefs.allcamsradius = new int[4];
      Array.Copy((Array) this.allcamsradius, (Array) this.spaceprefs.allcamsradius, 4);
      this.spaceprefs.allcamsorbit = new int[4];
      Array.Copy((Array) this.allcamsorbit, (Array) this.spaceprefs.allcamsorbit, 4);
      this.spaceprefs.allcamslens = new int[4];
      Array.Copy((Array) this.allcamslens, (Array) this.spaceprefs.allcamslens, 4);
      this.spaceprefs.allcamsaltitude = new int[4];
      Array.Copy((Array) this.allcamsaltitude, (Array) this.spaceprefs.allcamsaltitude, 4);
      this.spaceprefs.roverindex = this.roverindex;
      this.spaceprefs.roverrotlock = this.roverrotlock;
      this.spaceprefs.roverhitelock = this.roverhitelock;
      this.spaceprefs.roverdist = new float[3];
      Array.Copy((Array) this.roverdist, (Array) this.spaceprefs.roverdist, 3);
      this.spaceprefs.roverheight = new float[3];
      Array.Copy((Array) this.roverheight, (Array) this.spaceprefs.roverheight, 3);
      this.spaceprefs.roverradian = new float[3];
      Array.Copy((Array) this.roverradian, (Array) this.spaceprefs.roverradian, 3);
      this.spaceprefs.landerindex = this.landerindex;
      this.spaceprefs.landerrotlock = this.landerrotlock;
      this.spaceprefs.landerhitelock = this.landerhitelock;
      this.spaceprefs.landerdist = new float[3];
      Array.Copy((Array) this.landerdist, (Array) this.spaceprefs.landerdist, 3);
      this.spaceprefs.landerheight = new float[3];
      Array.Copy((Array) this.landerheight, (Array) this.spaceprefs.landerheight, 3);
      this.spaceprefs.landerradian = new float[3];
      Array.Copy((Array) this.landerradian, (Array) this.spaceprefs.landerradian, 3);
      this.storageSpacePrefs.SaveSpacePreferences(this.spaceprefs);
    }

    public void resetSpacePrefs()
    {
      this.brightness = 128;
      this.contrast = 128;
      this.mv = 0.9f;
      this.ev = 0.9f;
      this.voiceVolume = 0.9f;
      this.df = 1;
      this.vibroSetting = 1;
      this.allcamsradius = new int[4]{ 0, 1, 3, 4 };
      this.allcamsorbit = new int[4];
      this.allcamsaltitude = new int[4];
      this.allcamslens = new int[4];
      this.space_vibro = true;
      this.space_invertX = 1;
      this.space_invertY = 1;
      this.space_sentivityX = 1f;
      this.space_sentivityY = 1f;
      this.space_winvertX = 1;
      this.space_winvertY = 1;
      this.space_wsentivityX = 1f;
      this.space_wsentivityY = 1f;
      this.space_rinvertX = 1;
      this.space_rinvertY = 1;
      this.space_rsentivityX = 1f;
      this.space_rsentivityY = 1f;
      this.roverindex = 2;
      this.roverrotlock = 0;
      this.roverhitelock = 1;
      this.roverdist = new float[3]{ 200f, 440f, 800f };
      this.roverheight = new float[3]{ 100f, 400f, 700f };
      this.roverradian = new float[3]{ 100f, 100f, 100f };
      this.landerindex = 1;
      this.landerrotlock = 0;
      this.landerhitelock = 1;
      this.landerdist = new float[3]{ 500f, 1400f, 2500f };
      this.landerheight = new float[3]{ 300f, 300f, 300f };
      this.landerradian = new float[3]{ 100f, 100f, 100f };
    }

    public bool SaveSpaceKeys()
    {
      string path = "SAVES//spacekeys";
      if (!Directory.Exists("SAVES"))
        Directory.CreateDirectory("SAVES");
      try
      {
        using (StreamWriter streamWriter = new StreamWriter((Stream) File.Open(path, FileMode.Create)))
        {
          streamWriter.WriteLine(this.escape_key.ToString());
          streamWriter.WriteLine(this.w_key.ToString());
          streamWriter.WriteLine(this.s_key.ToString());
          streamWriter.WriteLine(this.a_key.ToString());
          streamWriter.WriteLine(this.d_key.ToString());
          streamWriter.WriteLine(this.space_key.ToString());
          streamWriter.WriteLine(this.leftshift_key.ToString());
          streamWriter.WriteLine(this.r_key.ToString());
          streamWriter.WriteLine(this.x_key.ToString());
          streamWriter.WriteLine(this.q_key.ToString());
          streamWriter.WriteLine(this.e_key.ToString());
          streamWriter.WriteLine(this.f_key.ToString());
          streamWriter.WriteLine(this.one_key.ToString());
          streamWriter.WriteLine(this.two_key.ToString());
          streamWriter.WriteLine(this.three_key.ToString());
          streamWriter.WriteLine(this.four_key.ToString());
          streamWriter.WriteLine(this.f1_key.ToString());
          streamWriter.WriteLine(this.f2_key.ToString());
          streamWriter.WriteLine(this.f3_key.ToString());
          streamWriter.WriteLine(this.tab_key.ToString());
          streamWriter.WriteLine(this.up_key.ToString());
          streamWriter.WriteLine(this.down_key.ToString());
          streamWriter.WriteLine(this.left_key.ToString());
          streamWriter.WriteLine(this.lmb_key.ToString());
          streamWriter.WriteLine(this.rmb_key.ToString());
          streamWriter.WriteLine(this.mmb_key.ToString());
          streamWriter.WriteLine(this.but1_key.ToString());
          streamWriter.WriteLine(this.but2_key.ToString());
          streamWriter.WriteLine(this.t_key.ToString());
          streamWriter.WriteLine(this.enter_key.ToString());
          streamWriter.WriteLine(this.u_key.ToString());
          streamWriter.Close();
          streamWriter.Dispose();
          return true;
        }
      }
      catch
      {
        return false;
      }
    }

    public string LoadSpaceKeys()
    {
      string path = "SAVES//spacekeys";
      if (!File.Exists(path))
        return "nofile";
      try
      {
        using (StreamReader streamReader = new StreamReader((Stream) File.Open(path, FileMode.Open)))
        {
          this.keymaker(ref this.escape_key, streamReader.ReadLine());
          this.keymaker(ref this.w_key, streamReader.ReadLine());
          this.keymaker(ref this.s_key, streamReader.ReadLine());
          this.keymaker(ref this.a_key, streamReader.ReadLine());
          this.keymaker(ref this.d_key, streamReader.ReadLine());
          this.keymaker(ref this.space_key, streamReader.ReadLine());
          this.keymaker(ref this.leftshift_key, streamReader.ReadLine());
          this.keymaker(ref this.r_key, streamReader.ReadLine());
          this.keymaker(ref this.x_key, streamReader.ReadLine());
          this.keymaker(ref this.q_key, streamReader.ReadLine());
          this.keymaker(ref this.e_key, streamReader.ReadLine());
          this.keymaker(ref this.f_key, streamReader.ReadLine());
          this.keymaker(ref this.one_key, streamReader.ReadLine());
          this.keymaker(ref this.two_key, streamReader.ReadLine());
          this.keymaker(ref this.three_key, streamReader.ReadLine());
          this.keymaker(ref this.four_key, streamReader.ReadLine());
          this.keymaker(ref this.f1_key, streamReader.ReadLine());
          this.keymaker(ref this.f2_key, streamReader.ReadLine());
          this.keymaker(ref this.f3_key, streamReader.ReadLine());
          this.keymaker(ref this.tab_key, streamReader.ReadLine());
          this.keymaker(ref this.up_key, streamReader.ReadLine());
          this.keymaker(ref this.down_key, streamReader.ReadLine());
          this.keymaker(ref this.left_key, streamReader.ReadLine());
          this.keymaker(ref this.lmb_key, streamReader.ReadLine());
          this.keymaker(ref this.rmb_key, streamReader.ReadLine());
          this.keymaker(ref this.mmb_key, streamReader.ReadLine());
          this.keymaker(ref this.but1_key, streamReader.ReadLine());
          this.keymaker(ref this.but2_key, streamReader.ReadLine());
          this.keymaker(ref this.t_key, streamReader.ReadLine());
          this.keymaker(ref this.enter_key, streamReader.ReadLine());
          this.keymaker(ref this.u_key, streamReader.ReadLine());
          streamReader.Close();
          streamReader.Dispose();
          return "OKAY";
        }
      }
      catch
      {
        return "FAIL";
      }
    }

    public void queryKeySquare2(Rectangle rr, int index, ref int whichKEY)
    {
      Vector2 mymouse = this.mymouse;
      Vector2 vector2 = new Vector2((float) this.origSize.Width / (float) this.width, (float) this.origSize.Height / (float) this.hite);
      mymouse.X *= vector2.X;
      mymouse.Y *= vector2.Y;
      if (((double) mymouse.Y <= (double) rr.Y || (double) mymouse.Y > (double) (rr.Y + rr.Height) || (double) mymouse.X <= (double) rr.X ? 0 : ((double) mymouse.X <= (double) (rr.X + rr.Width) ? 1 : 0)) == 0)
        return;
      whichKEY = index;
    }

    public void drawInteractive3(
      Vector2 topcorner,
      SpriteBatch spriteBatch,
      ref int whichKEY,
      ref int thisKEY,
      SpriteFont font2,
      ref int val,
      ref float yy,
      string thekey,
      string descr)
    {
      SpriteFont scribblefont2 = this.scribblefont2;
      float num = 23.3f;
      float x1 = 100f;
      float x2 = 400f;
      yy += num;
      ++val;
      this.bluePen = whichKEY != val ? Color.White : this.grnPen;
      if (thisKEY == val)
        this.bluePen = this.redPen;
      spriteBatch.DrawString(scribblefont2, descr + " :", topcorner + new Vector2(x1, yy), this.bluePen);
      if (descr == "na")
        spriteBatch.DrawString(scribblefont2, "------", topcorner + new Vector2(x2, yy), this.bluePen);
      else
        spriteBatch.DrawString(scribblefont2, thekey, topcorner + new Vector2(x2, yy), this.bluePen);
      Vector2 vector2 = scribblefont2.MeasureString(thekey);
      this.queryKeySquare2(new Rectangle((int) ((double) topcorner.X + (double) x2), (int) ((double) topcorner.Y + (double) yy - (double) vector2.Y / 25.0), (int) vector2.X, (int) ((double) vector2.Y / 1.2000000476837158)), val, ref whichKEY);
    }

    public void drawKeyBindings3(
      SpriteBatch spriteBatch,
      ref int whichKEY,
      ref int thisKEY,
      SpriteFont font2)
    {
      SpriteFont scribblefont2 = this.scribblefont2;
      double y1 = (double) scribblefont2.MeasureString("XXX").Y;
      Vector2 topcorner = new Vector2((float) (640 - this.blankpaper.Width / 2), 20f);
      float num1 = -25f;
      float num2 = 1.2f;
      float num3 = 125f;
      float num4 = 22f;
      float x1 = 100f;
      float x2 = 400f;
      int val1 = 0;
      num3 = 103f;
      num3 = 81f;
      num3 = 59f;
      float yy1 = 37f;
      Color white1 = Color.White;
      Color white2 = Color.White;
      spriteBatch.Draw(this.paper1, new Rectangle(0, 0, 1280, 720), new Rectangle?(this.blackX), Color.White);
      this.drawInteractive3(topcorner, spriteBatch, ref whichKEY, ref thisKEY, font2, ref val1, ref yy1, this.getKeyName(this.escape_key), "menus");
      this.drawInteractive3(topcorner, spriteBatch, ref whichKEY, ref thisKEY, font2, ref val1, ref yy1, this.getKeyName(this.lmb_key), "gas/thrust");
      this.drawInteractive3(topcorner, spriteBatch, ref whichKEY, ref thisKEY, font2, ref val1, ref yy1, this.getKeyName(this.rmb_key), "brake/ramp");
      this.drawInteractive3(topcorner, spriteBatch, ref whichKEY, ref thisKEY, font2, ref val1, ref yy1, "mouse", "camera look");
      this.drawInteractive3(topcorner, spriteBatch, ref whichKEY, ref thisKEY, font2, ref val1, ref yy1, this.getKeyName(this.w_key), "forward/pitch");
      this.drawInteractive3(topcorner, spriteBatch, ref whichKEY, ref thisKEY, font2, ref val1, ref yy1, this.getKeyName(this.s_key), "backward/pitch");
      this.drawInteractive3(topcorner, spriteBatch, ref whichKEY, ref thisKEY, font2, ref val1, ref yy1, this.getKeyName(this.a_key), "left/turn");
      this.drawInteractive3(topcorner, spriteBatch, ref whichKEY, ref thisKEY, font2, ref val1, ref yy1, this.getKeyName(this.d_key), "right/turn");
      this.drawInteractive3(topcorner, spriteBatch, ref whichKEY, ref thisKEY, font2, ref val1, ref yy1, this.getKeyName(this.space_key), "jump");
      this.drawInteractive3(topcorner, spriteBatch, ref whichKEY, ref thisKEY, font2, ref val1, ref yy1, this.getKeyName(this.leftshift_key), "sprint");
      this.drawInteractive3(topcorner, spriteBatch, ref whichKEY, ref thisKEY, font2, ref val1, ref yy1, this.getKeyName(this.r_key), "na");
      this.drawInteractive3(topcorner, spriteBatch, ref whichKEY, ref thisKEY, font2, ref val1, ref yy1, this.getKeyName(this.x_key), "activate");
      this.drawInteractive3(topcorner, spriteBatch, ref whichKEY, ref thisKEY, font2, ref val1, ref yy1, this.getKeyName(this.t_key), "callout/honk");
      this.drawInteractive3(topcorner, spriteBatch, ref whichKEY, ref thisKEY, font2, ref val1, ref yy1, this.getKeyName(this.enter_key), "objectives");
      this.drawInteractive3(topcorner, spriteBatch, ref whichKEY, ref thisKEY, font2, ref val1, ref yy1, this.getKeyName(this.f_key), "na");
      float y2 = yy1 + num4;
      int index1 = val1 + 1;
      Color color1 = whichKEY != index1 ? white2 : this.grnPen;
      if (thisKEY == index1)
        color1 = this.redPen;
      spriteBatch.DrawString(scribblefont2, "selection bar", topcorner + new Vector2(x1, (float) (int) y2), color1);
      Vector2 vector2_1 = scribblefont2.MeasureString(this.one_key.ToString() + " ");
      spriteBatch.DrawString(scribblefont2, this.stripD(this.one_key.ToString()) + " ", topcorner + new Vector2(x2, y2), color1);
      this.queryKeySquare2(new Rectangle((int) ((double) topcorner.X + (double) x2), (int) ((double) topcorner.Y + (double) y2 + (double) vector2_1.Y / (double) num1), (int) vector2_1.X, (int) ((double) vector2_1.Y / (double) num2)), index1, ref whichKEY);
      int index2 = index1 + 1;
      Color color2 = whichKEY != index2 ? white2 : this.grnPen;
      if (thisKEY == index2)
        color2 = this.redPen;
      Vector2 vector2_2 = scribblefont2.MeasureString(this.two_key.ToString() + " ");
      spriteBatch.DrawString(scribblefont2, this.stripD(this.two_key.ToString()) + " ", topcorner + new Vector2(vector2_1.X + x2, y2), color2);
      this.queryKeySquare2(new Rectangle((int) ((double) topcorner.X + (double) vector2_1.X + (double) x2), (int) ((double) topcorner.Y + (double) y2 + (double) vector2_2.Y / (double) num1), (int) vector2_2.X, (int) ((double) vector2_2.Y / (double) num2)), index2, ref whichKEY);
      int index3 = index2 + 1;
      Color color3 = whichKEY != index3 ? white2 : this.grnPen;
      if (thisKEY == index3)
        color3 = this.redPen;
      Vector2 vector2_3 = scribblefont2.MeasureString(this.three_key.ToString() + " ");
      spriteBatch.DrawString(scribblefont2, this.stripD(this.three_key.ToString()) + " ", topcorner + new Vector2(vector2_2.X + vector2_1.X + x2, y2), color3);
      this.queryKeySquare2(new Rectangle((int) ((double) topcorner.X + (double) vector2_2.X + (double) vector2_1.X + (double) x2), (int) ((double) topcorner.Y + (double) y2 + (double) vector2_3.Y / (double) num1), (int) vector2_3.X, (int) ((double) vector2_3.Y / (double) num2)), index3, ref whichKEY);
      int index4 = index3 + 1;
      Color color4 = whichKEY != index4 ? white2 : this.grnPen;
      if (thisKEY == index4)
        color4 = this.redPen;
      Vector2 vector2_4 = scribblefont2.MeasureString(this.four_key.ToString() + " ");
      spriteBatch.DrawString(scribblefont2, this.stripD(this.four_key.ToString()) + " ", topcorner + new Vector2(vector2_3.X + vector2_2.X + vector2_1.X + x2, y2), color4);
      this.queryKeySquare2(new Rectangle((int) ((double) topcorner.X + (double) vector2_3.X + (double) vector2_2.X + (double) vector2_1.X + (double) x2), (int) ((double) topcorner.Y + (double) y2 + (double) vector2_4.Y / (double) num1), (int) vector2_4.X, (int) ((double) vector2_4.Y / (double) num2)), index4, ref whichKEY);
      float yy2 = y2 + num4;
      int index5 = index4 + 1;
      Color color5 = whichKEY != index5 ? white2 : this.grnPen;
      if (thisKEY == index5)
        color5 = this.redPen;
      spriteBatch.DrawString(scribblefont2, "camera edit :", topcorner + new Vector2(x1, (float) (int) yy2), color5);
      vector2_1 = scribblefont2.MeasureString(this.f1_key.ToString() + " ");
      spriteBatch.DrawString(scribblefont2, this.f1_key.ToString() + " ", topcorner + new Vector2(x2, yy2), color5);
      this.queryKeySquare2(new Rectangle((int) ((double) topcorner.X + (double) x2), (int) ((double) topcorner.Y + (double) yy2 + (double) vector2_1.Y / (double) num1), (int) vector2_1.X, (int) ((double) vector2_1.Y / (double) num2)), index5, ref whichKEY);
      int val2 = index5 + 1 + 1;
      this.drawInteractive3(topcorner, spriteBatch, ref whichKEY, ref thisKEY, font2, ref val2, ref yy2, this.getKeyName(this.tab_key), "camera views");
      this.drawInteractive3(topcorner, spriteBatch, ref whichKEY, ref thisKEY, font2, ref val2, ref yy2, this.getKeyName(this.u_key), "camera unlock");
      this.drawInteractive3(topcorner, spriteBatch, ref whichKEY, ref thisKEY, font2, ref val2, ref yy2, this.getKeyName(this.left_key), "select bar left");
      this.drawInteractive3(topcorner, spriteBatch, ref whichKEY, ref thisKEY, font2, ref val2, ref yy2, this.getKeyName(this.right_key), "select bar right");
      this.drawInteractive3(topcorner, spriteBatch, ref whichKEY, ref thisKEY, font2, ref val2, ref yy2, this.getKeyName(this.up_key), "activate selection");
      this.drawInteractive3(topcorner, spriteBatch, ref whichKEY, ref thisKEY, font2, ref val2, ref yy2, this.getKeyName(this.e_key), "na");
      if (whichKEY == 36 || whichKEY == 30 || whichKEY == 33)
      {
        whichKEY = 0;
        thisKEY = 0;
      }
      this.queryKeySquare2(new Rectangle((int) topcorner.X + 520, (int) topcorner.Y + 40, 50, 26), 36, ref whichKEY);
      this.queryKeySquare2(new Rectangle((int) topcorner.X + 221, (int) topcorner.Y + 629, 71, 34), 30, ref whichKEY);
      this.queryKeySquare2(new Rectangle((int) topcorner.X + 341, (int) topcorner.Y + 629, 71, 34), 33, ref whichKEY);
      spriteBatch.Draw(this.paper1, topcorner + new Vector2(520f, 40f), new Rectangle?(this.cancelButtonX), Color.White);
      spriteBatch.Draw(this.paper1, topcorner + new Vector2(200f, 629f), new Rectangle?(this.saveButtonX), Color.White);
      spriteBatch.Draw(this.paper1, topcorner + new Vector2(341f, 629f), new Rectangle?(this.resetButtonX), Color.White);
      if (whichKEY == 36)
        spriteBatch.Draw(this.paper1, topcorner + new Vector2(520f, 40f), new Rectangle?(this.cancelButtonX), new Color(0, 90, 245));
      if (whichKEY == 30)
        spriteBatch.Draw(this.paper1, topcorner + new Vector2(200f, 629f), new Rectangle?(this.saveButtonX), new Color(0, 90, 245));
      if (whichKEY == 33)
        spriteBatch.Draw(this.paper1, topcorner + new Vector2(341f, 629f), new Rectangle?(this.resetButtonX), new Color(0, 90, 245));
      if (thisKEY != 0 && thisKEY != 33 && thisKEY != 30 && thisKEY != 36)
      {
        string text = "Press Any Key\nTo Remap Red Key";
        spriteBatch.DrawString(scribblefont2, text, new Vector2(980f, 340f), this.redPen);
      }
      else if (whichKEY != 0 && whichKEY != 33 && whichKEY != 30 && whichKEY != 36)
      {
        string text = "Left Mouse Click\nTo Select Key";
        spriteBatch.DrawString(scribblefont2, text, new Vector2(980f, 340f), this.grnPen);
      }
      else
      {
        if (whichKEY != 0 && whichKEY != 33 && whichKEY != 30 && whichKEY != 36)
          return;
        string text = "Remap Keys Use\nMouse to Highlight";
        spriteBatch.DrawString(scribblefont2, text, new Vector2(980f, 340f), Color.White);
      }
    }

    public string stripD(string thing) => thing.Replace("D", "");

    public void Roverbones()
    {
      this.bodyBone = this.roverModel.Bones["body"];
      this.haulerBone = this.roverModel.Bones["hauler1"];
      this.weaponBone = this.roverModel.Bones["weapon1"];
      this.rackBone = this.roverModel.Bones["rack"];
      this.scooperBone = this.roverModel.Bones["scooper1"];
      this.BackWheelBone = this.roverModel.Bones["backwheel1"];
      this.leftFrontWheelBone = this.roverModel.Bones["LF1"];
      this.rightFrontWheelBone = this.roverModel.Bones["RF1"];
      this.leftFrontjointBone = this.roverModel.Bones["LFjoint"];
      this.rightFrontjointBone = this.roverModel.Bones["RFjoint"];
      this.modelBone_0 = this.roverModel.Bones["solar1"];
      this.modelBone_1 = this.roverModel.Bones["solar1b"];
      this.rackTrans = this.rackBone.Transform;
      this.bodyTrans = this.bodyBone.Transform;
      this.haulerTrans = this.haulerBone.Transform;
      this.weaponTrans = this.weaponBone.Transform;
      this.scooperTrans = this.scooperBone.Transform;
      this.BackWheelTrans = this.BackWheelBone.Transform;
      this.leftFrontWheelTrans = this.leftFrontWheelBone.Transform;
      this.rightFrontWheelTrans = this.rightFrontWheelBone.Transform;
      this.leftFrontjointTrans = this.leftFrontjointBone.Transform;
      this.rightFrontjointTrans = this.rightFrontjointBone.Transform;
      this.solar1aTrans = this.modelBone_0.Transform;
      this.solar1bTrans = this.modelBone_1.Transform;
    }

    public void RoverEquip()
    {
      this.roverModel.CopyBoneTransformsFrom(this.origTransforms);
      this.roverparts.Clear();
      this.roverparts.Add("body");
      this.roverparts.Add("rack");
      this.rackBone = this.roverModel.Bones["rack"];
      this.bodyBone = this.roverModel.Bones["body"];
      this.rackTrans = this.rackBone.Transform;
      this.bodyTrans = this.bodyBone.Transform;
      this.roverparts.Add("RFjoint");
      this.roverparts.Add("LFjoint");
      this.leftFrontjointBone = this.roverModel.Bones["LFjoint"];
      this.rightFrontjointBone = this.roverModel.Bones["RFjoint"];
      this.leftFrontjointTrans = this.leftFrontjointBone.Transform;
      this.rightFrontjointTrans = this.rightFrontjointBone.Transform;
      int num1 = this.equip[3];
      int num2 = this.equip[6];
      int num3 = this.equip[9];
      int num4 = this.equip[12];
      int num5 = this.equip[15];
      this.roverparts.Add("weapon" + (object) num5);
      this.weaponBone = this.roverModel.Bones["weapon" + (object) num5];
      this.weaponTrans = this.weaponBone.Transform;
      this.roverparts.Add("solar" + (object) num2);
      this.modelBone_0 = this.roverModel.Bones["solar" + (object) num2];
      this.solar1aTrans = this.modelBone_0.Transform;
      this.solar1bTrans = Matrix.Identity;
      if (num2 == 1)
      {
        this.roverparts.Add("solar1b");
        this.modelBone_1 = this.roverModel.Bones["solar1b"];
        this.solar1bTrans = this.modelBone_1.Transform;
      }
      this.roverparts.Add("scooper" + (object) num1);
      this.scooperBone = this.roverModel.Bones["scooper" + (object) num1];
      this.scooperTrans = this.scooperBone.Transform;
      this.scooperMatrix = Matrix.CreateRotationX(0.0f) * Matrix.CreateTranslation(0.0f, 21.825f, 8.95f);
      this.scooperBone.Transform = this.scooperMatrix * this.scooperTrans;
      if (num3 == 1)
      {
        Rover.realGrav = -0.6f;
        this.roverGrip = 0.6f;
        Rover.fric = this.roverGrip;
        Rover.fricOrig = this.roverGrip;
        this.roverSpeed = -50f;
        Rover.max = this.roverSpeed;
        this.roverTurn = 0.11f;
        Rover.turnSpeed = this.roverTurn;
      }
      if (num3 == 2)
      {
        Rover.realGrav = -1.8f;
        this.roverGrip = 0.2f;
        Rover.fric = this.roverGrip;
        Rover.fricOrig = this.roverGrip;
        this.roverSpeed = -25f;
        Rover.max = this.roverSpeed;
        this.roverTurn = 0.35f;
        Rover.turnSpeed = this.roverTurn;
      }
      if (num3 == 3)
      {
        Rover.realGrav = -1f;
        this.roverGrip = 0.92f;
        Rover.fric = this.roverGrip;
        Rover.fricOrig = this.roverGrip;
        this.roverSpeed = -40f;
        Rover.max = this.roverSpeed;
        this.roverTurn = 0.11f;
        Rover.turnSpeed = this.roverTurn;
      }
      this.roverparts.Add("RF" + (object) num3);
      this.roverparts.Add("LF" + (object) num3);
      this.roverparts.Add("backwheel" + (object) num3);
      this.leftFrontWheelBone = this.roverModel.Bones["LF" + (object) num3];
      this.rightFrontWheelBone = this.roverModel.Bones["RF" + (object) num3];
      this.leftFrontWheelTrans = this.leftFrontWheelBone.Transform;
      this.rightFrontWheelTrans = this.rightFrontWheelBone.Transform;
      this.BackWheelBone = this.roverModel.Bones["backwheel" + (object) num3];
      this.BackWheelTrans = this.BackWheelBone.Transform;
      this.roverparts.Add("hauler" + (object) num4);
      this.haulerBone = this.roverModel.Bones["hauler" + (object) num4];
      this.haulerTrans = this.haulerBone.Transform;
      this.wheelRollMatrix = Matrix.CreateRotationX(0.0f);
      this.wheelRollMatrix2 = Matrix.CreateRotationY(0.0f);
      this.rackMatrix = Matrix.CreateTranslation((float) Math.Sin(0.0) * 4f, 0.0f, (float) (-Math.Cos(0.0) * 120.0 + 114.0));
    }

    public class xcross
    {
      public Texture2D texture;
      public int type;
      public bool legal;
    }

    public class chatty
    {
      public string message;
      public string name;
      public Color messColor;
      public Color nameColor;
      public int gap;
      public ulong idlong;
    }
  }
}
