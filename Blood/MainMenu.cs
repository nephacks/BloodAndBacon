// Decompiled with JetBrains decompiler
// Type: Blood.MainMenu
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using SkinnedModel;
using Steamworks;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Text;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace Blood
{
  internal class MainMenu : GameScreen
  {
    private bool newpage = true;
    private bool drawsubs;
    private bool drawcustom;
    private int xx = 57;
    private int yy = 48;
    private Rectangle[] myRect;
    private int pigcount;
    private int pigwalk;
    private List<string> me = new List<string>();
    private bool coopAlpha = true;
    private bool paintunlocked = true;
    private bool downloadAudio;
    private bool checkTrophyOnce;
    private bool jumptomain;
    private string lobbynum = "";
    private bool noMovies;
    private bool showHelp;
    private bool showGamepad;
    private bool showInstruct;
    private bool covered;
    private int whichKEY;
    private int thisKEY;
    private int whichbutton;
    private int lastbutton;
    private int highlight;
    private int highlighttimer;
    private bool mousemoving;
    private bool delayinput;
    private bool mouseback;
    private bool mousepress;
    private bool mousePressHold;
    private bool mousemiddle;
    private bool mousenum1;
    private bool mousenum2;
    private int[] menuArray = new int[11]
    {
      0,
      6,
      1,
      8,
      2,
      9,
      3,
      10,
      4,
      7,
      5
    };
    private int itemSelect;
    private int lastselect;
    private int myIndex;
    private Rectangle sliderBoxRect = new Rectangle(575, 547, 34, 46);
    private Rectangle sliderGlowRect = new Rectangle(634, 547, 34, 46);
    private Rectangle sliderRect = new Rectangle(486, 631, 320, 14);
    private float origMouseX;
    private Vector2 origMouseXY;
    private Vector2 origPlaque;
    private float nowMouseX;
    private float sliderbox1;
    private float float_0;
    private float sliderbox2;
    private float float_1;
    private float sliderbox3;
    private float float_2;
    private float sliderbox4;
    private float float_3;
    private int updownIndex;
    private int slider1;
    private int slider2;
    private int slider3;
    private int slider4;
    private int slider5;
    public int zoomX;
    public int zoomY;
    private Rectangle formCorner1 = new Rectangle(710, 75, 34, 35);
    private Rectangle formCorner2 = new Rectangle(929, 75, 34, 35);
    private Rectangle formCorner3 = new Rectangle(929, 291, 34, 35);
    private Rectangle formCorner4 = new Rectangle(710, 291, 34, 35);
    private Rectangle formLeft = new Rectangle(710, 143, 38, 110);
    private Rectangle formRight = new Rectangle(925, 145, 38, 110);
    private Rectangle formUp = new Rectangle(781, 75, 113, 35);
    private Rectangle formDown = new Rectangle(783, 291, 113, 35);
    private Rectangle formCenter = new Rectangle(806, 165, 68, 65);
    private Rectangle workshopRedbox = new Rectangle(682, 91, 29, 29);
    private Rectangle workshopDelbox1 = new Rectangle(479, 142, 29, 29);
    private Rectangle workshopDelbox2 = new Rectangle(684, 142, 29, 29);
    private Rectangle workshopDelbox3 = new Rectangle(889, 142, 29, 29);
    private int workshopBGindex;
    private Rectangle rectangle_0 = new Rectangle(359, 303, 150, 149);
    private Rectangle rectangle_1 = new Rectangle(564, 303, 150, 149);
    private Rectangle rectangle_2 = new Rectangle(769, 303, 150, 149);
    private Rectangle workshopx1 = new Rectangle(261, 144, 44, 44);
    private Rectangle workshopx2 = new Rectangle(261, 196, 44, 44);
    private Rectangle workshopx3 = new Rectangle(261, 249, 44, 44);
    private Rectangle workshopt1 = new Rectangle(355, 138, 158, 157);
    private Rectangle workshopt2 = new Rectangle(560, 138, 158, 157);
    private Rectangle workshopt3 = new Rectangle(765, 138, 158, 157);
    private Rectangle rectangle_3 = new Rectangle(352, 135, 164, 162);
    private Rectangle rectangle_4 = new Rectangle(557, 135, 164, 162);
    private Rectangle rectangle_5 = new Rectangle(762, 135, 164, 162);
    private Rectangle workshopBottomSubtitle = new Rectangle(461, 629, 358, 27);
    private Rectangle workshopBottomCustitle = new Rectangle(461, 659, 358, 27);
    private int subRow;
    private Rectangle workshopLeftarrow = new Rectangle(69, 496, 61, 98);
    private Rectangle workshopRightarrow = new Rectangle(1146, 496, 61, 98);
    private Rectangle workshopNums1 = new Rectangle(283, 4, 843, 19);
    private Rectangle workshopNums2 = new Rectangle(283, 22, 843, 19);
    private Rectangle workshopNums3 = new Rectangle(283, 39, 843, 19);
    private Rectangle workshopNums4 = new Rectangle(283, 57, 843, 19);
    private Rectangle workshopNumsX = new Rectangle(283, 603, 843, 19);
    private int workshopChosen = 1;
    private int flashindex;
    private Color[] flashing = new Color[60]
    {
      new Color((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue),
      new Color(225, (int) byte.MaxValue, 0, (int) byte.MaxValue),
      new Color(200, (int) byte.MaxValue, 0, (int) byte.MaxValue),
      new Color(175, (int) byte.MaxValue, 0, (int) byte.MaxValue),
      new Color(150, (int) byte.MaxValue, 0, (int) byte.MaxValue),
      new Color(125, (int) byte.MaxValue, 0, (int) byte.MaxValue),
      new Color(100, (int) byte.MaxValue, 0, (int) byte.MaxValue),
      new Color(75, (int) byte.MaxValue, 0, (int) byte.MaxValue),
      new Color(50, (int) byte.MaxValue, 0, (int) byte.MaxValue),
      new Color(0, (int) byte.MaxValue, 0, (int) byte.MaxValue),
      new Color(0, (int) byte.MaxValue, 25, (int) byte.MaxValue),
      new Color(0, (int) byte.MaxValue, 50, (int) byte.MaxValue),
      new Color(0, (int) byte.MaxValue, 70, (int) byte.MaxValue),
      new Color(0, (int) byte.MaxValue, 100, (int) byte.MaxValue),
      new Color(0, (int) byte.MaxValue, 120, (int) byte.MaxValue),
      new Color(0, (int) byte.MaxValue, 150, (int) byte.MaxValue),
      new Color(0, (int) byte.MaxValue, 170, (int) byte.MaxValue),
      new Color(0, (int) byte.MaxValue, 200, (int) byte.MaxValue),
      new Color(0, (int) byte.MaxValue, 225, (int) byte.MaxValue),
      new Color(0, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue),
      new Color(0, 225, (int) byte.MaxValue, (int) byte.MaxValue),
      new Color(0, 200, (int) byte.MaxValue, (int) byte.MaxValue),
      new Color(0, 170, (int) byte.MaxValue, (int) byte.MaxValue),
      new Color(0, 150, (int) byte.MaxValue, (int) byte.MaxValue),
      new Color(0, 120, (int) byte.MaxValue, (int) byte.MaxValue),
      new Color(0, 100, (int) byte.MaxValue, (int) byte.MaxValue),
      new Color(0, 70, (int) byte.MaxValue, (int) byte.MaxValue),
      new Color(0, 55, (int) byte.MaxValue, (int) byte.MaxValue),
      new Color(0, 25, (int) byte.MaxValue, (int) byte.MaxValue),
      new Color(0, 0, (int) byte.MaxValue, (int) byte.MaxValue),
      new Color(25, 0, (int) byte.MaxValue, (int) byte.MaxValue),
      new Color(50, 0, (int) byte.MaxValue, (int) byte.MaxValue),
      new Color(70, 0, (int) byte.MaxValue, (int) byte.MaxValue),
      new Color(100, 0, (int) byte.MaxValue, (int) byte.MaxValue),
      new Color(120, 0, (int) byte.MaxValue, (int) byte.MaxValue),
      new Color(150, 0, (int) byte.MaxValue, (int) byte.MaxValue),
      new Color(170, 0, (int) byte.MaxValue, (int) byte.MaxValue),
      new Color(200, 0, (int) byte.MaxValue, (int) byte.MaxValue),
      new Color(225, 0, (int) byte.MaxValue, (int) byte.MaxValue),
      new Color((int) byte.MaxValue, 0, (int) byte.MaxValue, (int) byte.MaxValue),
      new Color((int) byte.MaxValue, 0, 225, (int) byte.MaxValue),
      new Color((int) byte.MaxValue, 0, 200, (int) byte.MaxValue),
      new Color((int) byte.MaxValue, 0, 170, (int) byte.MaxValue),
      new Color((int) byte.MaxValue, 0, 150, (int) byte.MaxValue),
      new Color((int) byte.MaxValue, 0, 125, (int) byte.MaxValue),
      new Color((int) byte.MaxValue, 0, 100, (int) byte.MaxValue),
      new Color((int) byte.MaxValue, 0, 70, (int) byte.MaxValue),
      new Color((int) byte.MaxValue, 0, 50, (int) byte.MaxValue),
      new Color((int) byte.MaxValue, 0, 25, (int) byte.MaxValue),
      new Color((int) byte.MaxValue, 0, 0, (int) byte.MaxValue),
      new Color((int) byte.MaxValue, 25, 0, (int) byte.MaxValue),
      new Color((int) byte.MaxValue, 50, 0, (int) byte.MaxValue),
      new Color((int) byte.MaxValue, 70, 0, (int) byte.MaxValue),
      new Color((int) byte.MaxValue, 100, 0, (int) byte.MaxValue),
      new Color((int) byte.MaxValue, 120, 0, (int) byte.MaxValue),
      new Color((int) byte.MaxValue, 150, 0, (int) byte.MaxValue),
      new Color((int) byte.MaxValue, 170, 0, (int) byte.MaxValue),
      new Color((int) byte.MaxValue, 200, 0, (int) byte.MaxValue),
      new Color((int) byte.MaxValue, 225, 0, (int) byte.MaxValue),
      new Color((int) byte.MaxValue, (int) byte.MaxValue, 0, (int) byte.MaxValue)
    };
    private Rectangle workshopb1 = new Rectangle(150, 468, 158, 157);
    private Rectangle workshopb2 = new Rectangle(355, 468, 158, 157);
    private Rectangle workshopb3 = new Rectangle(560, 468, 158, 157);
    private Rectangle workshopb4 = new Rectangle(765, 468, 158, 157);
    private Rectangle workshopb5 = new Rectangle(970, 468, 158, 157);
    private Rectangle formPreview = new Rectangle(712, 77, 250, 250);
    private Rectangle formCheckbox = new Rectangle(204, 415, 52, 50);
    private Rectangle formTitle = new Rectangle(333, 180, 315, 39);
    private Rectangle formDescr = new Rectangle(334, 257, 367, 73);
    private Rectangle formPublic = new Rectangle(351, 432, 30, 30);
    private Rectangle formPrivate = new Rectangle(460, 432, 30, 30);
    private Rectangle formFriends = new Rectangle(565, 432, 30, 30);
    private Rectangle formBut1 = new Rectangle(747, 336, 28, 28);
    private Rectangle rectangle_6 = new Rectangle(747, 369, 28, 28);
    private Rectangle formBut2 = new Rectangle(782, 336, 28, 28);
    private Rectangle rectangle_7 = new Rectangle(782, 369, 28, 28);
    private Rectangle formBut3 = new Rectangle(818, 336, 28, 28);
    private Rectangle rectangle_8 = new Rectangle(818, 369, 28, 28);
    private Rectangle formBut4 = new Rectangle(855, 336, 28, 28);
    private Rectangle rectangle_9 = new Rectangle(855, 369, 28, 28);
    private Rectangle formBut5 = new Rectangle(892, 336, 28, 28);
    private Rectangle rectangle_10 = new Rectangle(892, 369, 28, 28);
    private Rectangle formTerms = new Rectangle(332, 543, 207, 29);
    private Rectangle formCancel = new Rectangle(651, 582, 144, 65);
    private Rectangle formPublish = new Rectangle(819, 582, 144, 65);
    private Rectangle formWaterMark = new Rectangle(332, 346, 315, 39);
    private bool formDrawBG;
    private int formBGColorindex;
    private Color[] color_0 = new Color[5]
    {
      new Color(210, 210, 210, (int) byte.MaxValue),
      new Color(180, 180, 180, (int) byte.MaxValue),
      new Color(110, 110, 110, (int) byte.MaxValue),
      new Color(60, 60, 60, (int) byte.MaxValue),
      new Color(15, 15, 15, (int) byte.MaxValue)
    };
    private bool formDrawBand;
    private int formBandColorIndex;
    private Color[] formBandColor = new Color[5]
    {
      new Color(225, 178, 30, (int) byte.MaxValue),
      new Color(32, 210, 19, (int) byte.MaxValue),
      new Color(42, 137, 217, (int) byte.MaxValue),
      new Color(166, 86, 178, (int) byte.MaxValue),
      new Color(175, 52, 52, (int) byte.MaxValue)
    };
    private Rectangle formBand = new Rectangle(1020, 76, 132, 125);
    private Rectangle formBandL = new Rectangle(711, 76, 132, 125);
    public int formtagIndex;
    private Rectangle[] formTag = new Rectangle[9]
    {
      new Rectangle(729, 423, 71, 16),
      new Rectangle(810, 423, 56, 16),
      new Rectangle(882, 423, 86, 16),
      new Rectangle(727, 445, 79, 19),
      new Rectangle(816, 448, 47, 17),
      new Rectangle(879, 446, 64, 19),
      new Rectangle(742, 469, 42, 21),
      new Rectangle(810, 470, 50, 20),
      new Rectangle(877, 471, 64, 19)
    };
    private Rectangle star1 = new Rectangle(508, 473, 75, 75);
    private Rectangle star2 = new Rectangle(602, 473, 75, 75);
    private Rectangle star3 = new Rectangle(697, 473, 75, 75);
    private Rectangle star4 = new Rectangle(118, 470, 74, 86);
    private Rectangle star5 = new Rectangle(299, 107, 60, 60);
    private Rectangle bonusPaint = new Rectangle(113, 204, 57, 39);
    private Rectangle bonusSpeak = new Rectangle(1065, 163, 100, 90);
    private Rectangle bonusGrab0 = new Rectangle(346, 220, 143, 76);
    private Rectangle bonusGrab = new Rectangle(566, 220, 143, 76);
    private Rectangle bonusGrab2 = new Rectangle(796, 220, 143, 76);
    private Rectangle secretCoop = new Rectangle(657, 484, 27, 26);
    private Rectangle creditBox = new Rectangle(20, 274, 104, 54);
    private Rectangle creditBoxGlow = new Rectangle(20, 341, 104, 54);
    private Rectangle creditBox2 = new Rectangle(20, 274, 104, 54);
    private Rectangle creditBoxGlow2 = new Rectangle(20, 341, 104, 54);
    private Rectangle bonus = new Rectangle(132, 272, 172, 74);
    private Rectangle bonusGlow = new Rectangle(132, 350, 172, 74);
    private Rectangle audio = new Rectangle(235, 572, 148, 70);
    private Rectangle audioGlow = new Rectangle(235, 648, 148, 70);
    private Rectangle keymap = new Rectangle(414, 572, 148, 70);
    private Rectangle keymapGlow = new Rectangle(414, 648, 148, 70);
    private Rectangle button = new Rectangle(132, 446, 218, 83);
    private Rectangle buttonOn = new Rectangle(367, 446, 226, 92);
    private Rectangle button2 = new Rectangle(10, 552, 218, 83);
    private Rectangle buttonOn2 = new Rectangle(4, 644, 226, 92);
    private Rectangle button3 = new Rectangle(10, 758, 218, 83);
    private Rectangle buttonOn3 = new Rectangle(4, 850, 226, 92);
    private Rectangle button4 = new Rectangle(256, 769, 174, 66);
    private Rectangle buttonOn4 = new Rectangle(256, 861, 174, 66);
    private Rectangle button4x = new Rectangle(470, 769, 174, 66);
    private Rectangle rectangle_11 = new Rectangle(470, 861, 174, 66);
    private Rectangle arrowup = new Rectangle(480, 280, 43, 38);
    private Rectangle arrowdown = new Rectangle(480, 331, 43, 38);
    private Rectangle arrowright = new Rectangle(430, 280, 43, 38);
    private Rectangle arrowleft = new Rectangle(430, 331, 43, 38);
    private Rectangle arrowplus = new Rectangle(380, 280, 43, 38);
    private Rectangle arrowminus = new Rectangle(380, 331, 43, 38);
    private Rectangle redbox = new Rectangle(4, 181, 34, 34);
    private Rectangle redboxfill = new Rectangle(4, 232, 34, 34);
    private Rectangle arrowfill = new Rectangle(480, 380, 43, 38);
    private MainMenu.initb b = new MainMenu.initb();
    private MainMenu.states menuState;
    private MainMenu.states lastState;
    private MainMenu.states lastState2;
    private Vector2 pigVec = new Vector2(475f, 399f);
    private Rectangle pigRect = new Rectangle(450, 399, 400, 260);
    private bool trailershown;
    private bool exitMyGame;
    private int randomPhrase;
    private Vector2[] nameSpot = new Vector2[21]
    {
      new Vector2(300f, 311f),
      new Vector2(640f, 311f),
      new Vector2(980f, 311f),
      new Vector2(300f, 351f),
      new Vector2(640f, 351f),
      new Vector2(980f, 351f),
      new Vector2(300f, 391f),
      new Vector2(640f, 391f),
      new Vector2(980f, 391f),
      new Vector2(300f, 431f),
      new Vector2(640f, 431f),
      new Vector2(980f, 431f),
      new Vector2(300f, 471f),
      new Vector2(640f, 471f),
      new Vector2(980f, 471f),
      new Vector2(300f, 511f),
      new Vector2(640f, 511f),
      new Vector2(980f, 511f),
      new Vector2(300f, 551f),
      new Vector2(640f, 551f),
      new Vector2(980f, 551f)
    };
    private string[] fakenames = new string[100]
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
    private int celselect;
    private List<int> randomNames = new List<int>();
    private static StringBuilder mybuilder = new StringBuilder(62, 62);
    private int moreTimer;
    private float titlecounter;
    private float ramp;
    private int rampCount;
    private int counterStart;
    private SoundEffectInstance menuMusic;
    private SoundEffectInstance speaker;
    private SoundEffect music1;
    private SoundEffect speak;
    private GamePadState prevstate;
    private GamePadState gamePadState;
    private KeyboardState prevKeys;
    private KeyboardState keyState;
    private MouseState prevMouse;
    private MouseState mouseState;
    private Microsoft.Xna.Framework.Input.Keys[] pressedKeys;
    private ContentManager content2;
    private ScreenManager sc;
    private SpriteBatch spriteBatch;
    private Random rr;
    public SpriteFont font;
    public SpriteFont font2;
    public SpriteFont font3;
    public SpriteFont deadfont;
    public SpriteFont diaryfont;
    private string ss;
    private PlayerIndex playerindex;
    private PlayerIndex tempindex;
    private int menuSelect = 1;
    private string hostChoice = "";
    private string highlightname = "";
    private Rectangle glow = new Rectangle(1244, 477, 123, 120);
    private Rectangle taken = new Rectangle(957, 725, 100, 98);
    private Rectangle locked = new Rectangle(842, 725, 100, 98);
    private Vector2[] selectPoint = new Vector2[12]
    {
      new Vector2(126f, 434f),
      new Vector2(307f, 434f),
      new Vector2(490f, 434f),
      new Vector2(670f, 434f),
      new Vector2(858f, 434f),
      new Vector2(1037f, 434f),
      new Vector2(252f, 468f),
      new Vector2(984f, 468f),
      new Vector2(433f, 468f),
      new Vector2(613f, 468f),
      new Vector2(800f, 468f),
      new Vector2(513f, 190f)
    };
    private Rectangle[] vehicleCard = new Rectangle[5]
    {
      new Rectangle(0, 98, 100, 98),
      new Rectangle(100, 98, 100, 98),
      new Rectangle(200, 98, 100, 98),
      new Rectangle(300, 98, 100, 98),
      new Rectangle(400, 98, 100, 98)
    };
    private Rectangle[] charCard = new Rectangle[5]
    {
      new Rectangle(0, 0, 100, 98),
      new Rectangle(100, 0, 100, 98),
      new Rectangle(200, 0, 100, 98),
      new Rectangle(300, 0, 100, 98),
      new Rectangle(400, 0, 100, 98)
    };
    private float ramper;
    private int val1;
    private int val2;
    private int indieIndex = 1;
    private Thread backgroundThread;
    private EventWaitHandle backgroundThreadExit;
    private bool isBusy;
    private List<int> loads = new List<int>();
    private bool showTitle;
    private int pulseTimer;
    private Model farmerModel;
    private Texture2D farmerTexture;
    private AnimationPlayer[] farmer1;
    private Effect farmerSkin;
    private int farmerGlitchCount;
    private int farmerGlitchIndex;
    private MainMenu.npcanim farmerAnim;
    private string[] months = new string[13]
    {
      "Ozo",
      "Jan",
      "Feb",
      "Mar",
      "Apr",
      "May",
      "Jun",
      "Jul",
      "Aug",
      "Sept",
      "Oct",
      "Nov",
      "Dec"
    };
    private SoundEffects farmerDialog1;
    private bool bool_0;
    private int talkIndex = -1;
    private List<float> farmerJaw;
    private int farmerJawIndex = -1;
    private float talkAverage;
    private float talkSmooth;
    private float desiredAngle;
    private Vector2 adj = Vector2.Zero;
    private Vector2 basePos = Vector2.Zero;
    private Vector2 pos1 = Vector2.Zero;
    private Vector2 pos2 = Vector2.Zero;
    private float tiltDown;
    private float farmerlook;
    private float farmertilt;
    private float farmerFrame1;
    private int currentKeyframe;
    private TimeSpan currentTimeValue;
    private float followTimer;
    private float followTween;
    private float headTween;
    private Matrix headMatrix = Matrix.Identity;
    private Matrix lastheadMatrix = Matrix.Identity;
    private Rectangle diaryRGB = new Rectangle(917, 1229, 129, 126);
    private Rectangle diaryGlow = new Rectangle(1054, 1229, 129, 126);
    private Rectangle diaryDark = new Rectangle(1190, 1229, 129, 126);
    private bool recording1;
    private bool recording2;
    private bool recording3;
    private bool recording4;
    private Vector3[] LightDirectionX = new Vector3[9]
    {
      new Vector3(0.6f, 1f, -0.9f),
      new Vector3(0.6f, 1f, 0.1f),
      new Vector3(0.6f, 1f, 0.9f),
      new Vector3(0.6f, 0.3f, -0.9f),
      new Vector3(0.6f, 0.3f, 0.1f),
      new Vector3(0.6f, 0.3f, 0.9f),
      new Vector3(0.6f, -1f, -0.9f),
      new Vector3(0.6f, -1f, 0.1f),
      new Vector3(0.6f, -1f, 0.9f)
    };
    private Vector3[] DiffuseLightX = new Vector3[9]
    {
      new Vector3(1f, 0.8f, 0.8f),
      new Vector3(1f, 1f, 0.8f),
      new Vector3(0.7f, 0.7f, 1f),
      new Vector3(1f, 0.9f, 0.9f),
      new Vector3(1f, 1f, 0.85f),
      new Vector3(0.7f, 0.7f, 1f),
      new Vector3(1f, 0.9f, 0.9f),
      new Vector3(1f, 1f, 0.9f),
      new Vector3(0.7f, 0.7f, 1f)
    };
    private Vector3[] AmbientLightX = new Vector3[9]
    {
      new Vector3(0.7f, 0.6f, 0.6f),
      new Vector3(0.7f, 0.7f, 0.65f),
      new Vector3(0.6f, 0.6f, 0.7f),
      new Vector3(0.4f, 0.3f, 0.3f),
      new Vector3(0.4f, 0.4f, 0.39f),
      new Vector3(0.3f, 0.3f, 0.4f),
      new Vector3(0.1f, 0.05f, 0.05f),
      new Vector3(0.1f, 0.1f, 0.1f),
      new Vector3(0.1f, 0.1f, 0.2f)
    };
    private int briteX = 4;
    private int colorX = 4;
    private int briteXold;
    private int colorXold;
    private int briteXtemp;
    private int colorXtemp;
    private float liteTween;
    private List<MainMenu.imim> im = new List<MainMenu.imim>();
    private List<int> displayList = new List<int>();
    private Vector2 lastlookpos = new Vector2(390f, 142f);
    private Vector2[] lookpos = new Vector2[7]
    {
      new Vector2(390f, 195f),
      new Vector2(910f, 128f),
      new Vector2(616f, 390f),
      new Vector2(414f, 537f),
      new Vector2(136f, 567f),
      new Vector2(30f, 296f),
      new Vector2(64f, 28f)
    };
    private Vector2[] lookposOrig = new Vector2[7]
    {
      new Vector2(390f, 195f),
      new Vector2(910f, 128f),
      new Vector2(616f, 390f),
      new Vector2(414f, 537f),
      new Vector2(136f, 567f),
      new Vector2(30f, 296f),
      new Vector2(64f, 28f)
    };
    private Vector2 lookPosRR = new Vector2(0.0f, 0.0f);
    private int lookIndex;
    private bool followMouse;
    private bool followPoint = true;
    private int directNum = -1;
    private int directRate;
    private int directNumX;
    private int directNumY;
    private int entryIndex = -1;
    private int mediaIndex;
    private ContentManager Content;

    private void Form1_KeyDown(object sender, FormClosingEventArgs e)
    {
      this.abortThread();
      this.UnloadContent();
      this.ScreenManager.exitmyGame();
      this.exitMyGame = true;
    }

    public MainMenu(bool showit)
    {
      if (showit)
      {
        this.TransitionOnTime = TimeSpan.FromSeconds(0.0);
        this.TransitionOffTime = TimeSpan.FromSeconds(0.20000000298023224);
      }
      else
      {
        this.TransitionOnTime = TimeSpan.FromSeconds(0.0);
        this.TransitionOffTime = TimeSpan.FromSeconds(0.20000000298023224);
      }
      this.backgroundThread = new Thread(new ThreadStart(this.BackgroundWorkerThread));
      this.backgroundThread.Name = "fuckerThread";
      this.backgroundThreadExit = (EventWaitHandle) new ManualResetEvent(false);
      this.showTitle = showit;
    }

    public override void LoadContent()
    {
      this.sc = this.ScreenManager;
      this.sc.inSpace = false;
      this.sc.trophy.checkAll();
      ((Form) Control.FromHandle(this.sc.Game.Window.Handle)).FormClosing += new FormClosingEventHandler(this.Form1_KeyDown);
      try
      {
        if (SteamAPI.IsSteamRunning())
        {
          CSteamID steamId = SteamUser.GetSteamID();
          this.sc.developer = false;
          if (steamId.m_SteamID == 76561198259812257UL)
            this.sc.developer = true;
          this.sc.guestpresent = false;
        }
      }
      catch
      {
      }
      this.sc.cryptHits = this.sc.cryptHitsReset;
      this.sc.bool_0 = false;
      this.sc.hostAllowCheats = true;
      this.sc.allWeapons = true;
      this.sc.hostFriendly = false;
      this.sc.hostBobbleheads = false;
      this.sc.hordemode = false;
      this.sc.paintland = false;
      this.sc.tunnelMode = false;
      this.sc.hatindex = 0;
      if (!this.sc.host)
        this.sc.df = this.sc.df_orig;
      this.sc.host = true;
      this.sc.myfov = (float) Math.Cos((double) MathHelper.ToRadians((float) (((double) this.sc.mylens + 30.0) / 2.0)));
      this.sc.lobby.inviteRequest = false;
      this.sc.lobby.acceptRequests();
      this.sc.introCamera = 0.0f;
      this.content2 = new ContentManager((System.IServiceProvider) this.ScreenManager.Game.Services, "ABCDE1");
      this.sc.chatHistory.Clear();
      this.sc.weFailed = 0;
      this.sc.keepShowingWarning = true;
      this.sc.walletHint = false;
      this.sc.walletHintShow = false;
      this.sc.deathcamHint = false;
      this.spriteBatch = new SpriteBatch(this.sc.GraphicsDevice);
      this.sc.easter_skull1 = false;
      this.sc.easter_skull2 = false;
      this.sc.easter_skull3 = false;
      this.sc.easter_skulltalk = false;
      this.speak = this.content2.Load<SoundEffect>("cough");
      this.speaker = this.speak.CreateInstance();
      this.font = this.content2.Load<SpriteFont>("ammo");
      this.font2 = this.content2.Load<SpriteFont>("ammomedium");
      this.font3 = this.sc.font3;
      this.deadfont = this.content2.Load<SpriteFont>("deadfont");
      this.diaryfont = this.sc.font3;
      Princess.cuttyCount = 0;
      Princess4.cuttyCount = 0;
      this.sc.redContrast = 128;
      this.sc.shitContrast = 128;
      this.sc.contrastBU = 128;
      this.rr = new Random();
      this.sc.bc1 = this.content2.Load<Texture2D>("bc1");
      this.sc.bc2 = this.content2.Load<Texture2D>("bc2");
      this.music1 = this.content2.Load<SoundEffect>("ThunderDreams");
      this.menuMusic = this.music1.CreateInstance();
      this.menuMusic.IsLooped = true;
      this.menuMusic.Play();
      this.menuMusic.Volume = 0.5f;
      int num = this.rr.Next(0, 5);
      List<string> stringList = new List<string>();
      if (num == 0)
      {
        stringList.Add("titlePigA");
        stringList.Add("titlePigB");
        stringList.Add("titlePigC");
      }
      if (num == 1)
      {
        stringList.Add("titlePigC");
        stringList.Add("titlePigB");
        stringList.Add("titlePigA");
      }
      if (num == 2)
      {
        stringList.Add("titlePigB");
        stringList.Add("titlePigA");
        stringList.Add("titlePigC");
      }
      if (num == 3)
      {
        stringList.Add("titlePigC");
        stringList.Add("titlePigA");
        stringList.Add("titlePigB");
      }
      if (num == 4)
      {
        stringList.Add("titlePigA");
        stringList.Add("titlePigC");
        stringList.Add("titlePigB");
      }
      int index1 = this.rr.Next(0, stringList.Count);
      this.sc.titlePig0 = this.content2.Load<Texture2D>(stringList[index1]);
      stringList.RemoveAt(index1);
      int index2 = this.rr.Next(0, stringList.Count);
      this.sc.titlePig2 = this.content2.Load<Texture2D>(stringList[index2]);
      stringList.RemoveAt(index2);
      int index3 = this.rr.Next(0, stringList.Count);
      this.sc.titlePig3 = this.content2.Load<Texture2D>(stringList[index3]);
      this.sc.titlePig1 = this.content2.Load<Texture2D>("pigsrun2");
      this.myRect = new Rectangle[20];
      this.myRect[0] = new Rectangle(0, 0, 300, 195);
      this.myRect[1] = new Rectangle(0, 199, 300, 195);
      this.myRect[2] = new Rectangle(304, 0, 300, 195);
      this.myRect[3] = new Rectangle(304, 199, 300, 195);
      this.myRect[4] = new Rectangle(608, 0, 300, 195);
      this.myRect[5] = new Rectangle(608, 199, 300, 195);
      this.myRect[6] = new Rectangle(0, 398, 300, 195);
      this.myRect[7] = new Rectangle(0, 597, 300, 195);
      this.myRect[8] = new Rectangle(304, 398, 300, 195);
      this.myRect[9] = new Rectangle(304, 597, 300, 195);
      this.myRect[10] = new Rectangle(608, 398, 300, 195);
      this.myRect[11] = new Rectangle(608, 597, 300, 195);
      this.myRect[12] = new Rectangle(912, 0, 300, 195);
      this.myRect[13] = new Rectangle(912, 199, 300, 195);
      this.myRect[14] = new Rectangle(1216, 0, 300, 195);
      this.myRect[15] = new Rectangle(912, 398, 300, 195);
      this.myRect[16] = new Rectangle(1216, 199, 300, 195);
      this.myRect[17] = new Rectangle(912, 597, 300, 195);
      this.myRect[18] = new Rectangle(1216, 398, 300, 195);
      this.myRect[19] = new Rectangle(1216, 597, 300, 195);
      if (!this.sc.titlesLoaded)
        this.sc.loadTitles();
      if (this.showTitle)
      {
        this.counterStart = 260;
        this.titlecounter = (float) (this.counterStart + 80);
      }
      this.backgroundThread.Start();
      this.mouseState = Mouse.GetState();
      this.sc.mymouse.X = (float) this.mouseState.X;
      this.sc.mymouse.Y = (float) this.mouseState.Y;
      this.sc.Game.IsMouseVisible = false;
      this.sc.tempRifle = 2;
      this.sc.tempPistol = 2;
      this.sc.tempAmmo = 0;
      this.sc.tempMag = 0;
      this.sc.lobby.players = "0";
      this.sc.lobby.lobbyplayers = "0";
      this.Content = new ContentManager((System.IServiceProvider) this.sc.Game.Services, "Content");
      this.sc.loadFarmer();
      this.farmerModel = this.sc.farmerModel;
      this.farmerTexture = this.sc.farmerTexture;
      this.farmerSkin = this.Content.Load<Effect>("effects\\farmerSkinDiary");
      this.farmerSkin.Parameters["World"].SetValue(Matrix.CreateTranslation(0.0f, 0.0f, 0.0f));
      this.farmerSkin.Parameters["Texture"].SetValue((Texture) this.farmerTexture);
      SkinningData tag = this.sc.farmerModel.Tag as SkinningData;
      this.farmer1 = new AnimationPlayer[11];
      this.farmer1[0] = new AnimationPlayer(tag);
      this.farmer1[0].StartClip(tag.AnimationClips["farmer"]);
      this.farmer1[1] = new AnimationPlayer(tag);
      this.farmer1[1].StartClip(tag.AnimationClips["wave"]);
      this.farmer1[2] = new AnimationPlayer(tag);
      this.farmer1[2].StartClip(tag.AnimationClips["pat"]);
      this.farmer1[3] = new AnimationPlayer(tag);
      this.farmer1[3].StartClip(tag.AnimationClips["nose"]);
      this.farmer1[4] = new AnimationPlayer(tag);
      this.farmer1[4].StartClip(tag.AnimationClips["kick"]);
      this.farmer1[5] = new AnimationPlayer(tag);
      this.farmer1[5].StartClip(tag.AnimationClips["convulse1"]);
      this.farmer1[6] = new AnimationPlayer(tag);
      this.farmer1[6].StartClip(tag.AnimationClips["vomit"]);
      this.farmer1[7] = new AnimationPlayer(tag);
      this.farmer1[7].StartClip(tag.AnimationClips["vomit2"]);
      this.farmer1[8] = new AnimationPlayer(tag);
      this.farmer1[8].StartClip(tag.AnimationClips["point1"]);
      this.farmer1[9] = new AnimationPlayer(tag);
      this.farmer1[9].StartClip(tag.AnimationClips["clap"]);
      this.farmer1[10] = new AnimationPlayer(tag);
      this.farmer1[10].StartClip(tag.AnimationClips["head"]);
      this.farmerJaw = new List<float>();
      this.farmerAnim.animCount = -1f;
      this.farmerAnim.animTween = 0.0f;
      this.farmerAnim.animList = new List<int>();
      this.farmerAnim.animClip = -1;
      this.farmerAnim.animMax = 0;
      this.farmerAnim.animMin = 0;
      this.farmerAnim.animLoop = 0;
      this.im.Clear();
      for (int index4 = 0; index4 < 10; ++index4)
      {
        this.im.Add(new MainMenu.imim());
        this.im[index4].spriteIndex = index4;
      }
      this.displayList.Clear();
      if (!this.sc.localLoad)
      {
        this.loads.Add(4);
      }
      else
      {
        this.sc.loadModels();
        this.sc.moremodelsLoaded = true;
      }
    }

   // public override void UnloadContent() => this.content2.Unload();

        public override void UnloadContent()
        {
            if (this.content2 != null)
                this.content2.Unload();
        }

        private void BackgroundWorkerThread()
    {
      this.backgroundThread.IsBackground = true;
      while (!this.backgroundThreadExit.WaitOne(50))
      {
        if (!this.isBusy && this.loads.Count > 0)
        {
          this.isBusy = true;
          switch (this.loads[0])
          {
            case 4:
              this.sc.loadModels();
              this.sc.loadBigModel();
              this.sc.moremodelsLoaded = true;
              break;
          }
          this.loads.RemoveAt(0);
          this.isBusy = false;
        }
      }
    }

    private void abortThread()
    {
      try
      {
        if (this.backgroundThread == null)
          return;
        this.backgroundThreadExit.Set();
        this.backgroundThread.Join();
      }
      catch
      {
      }
    }

    private void disposeMovies()
    {
    }

    public override void Update(
      GameTime gameTime,
      bool otherScreenHasFocus,
      bool coveredByOtherScreen)
    {
      if (this.pigwalk > 500)
        ++this.pigwalk;
      if (this.pigwalk % 3 == 0 && this.pigwalk > 500)
      {
        ++this.pigcount;
        this.pigcount %= 20;
      }
      ++this.sc.workshop.myTimer;
      ++this.sc.myTimer;
      ++this.moreTimer;
      this.titlecounter -= 1.5f;
      if ((int) this.titlecounter <= this.counterStart / 2 && this.rampCount == 0)
      {
        this.ramp = 0.0f;
        this.rampCount = 1;
      }
      if (!this.sc.lobby.ALLClear)
      {
        ++this.sc.lobby.ALLCount;
        if (this.sc.lobby.ALLCount > 1800)
          this.sc.lobby.ALLClear = true;
      }
      else
        this.sc.lobby.ALLCount = 0;
      this.covered = otherScreenHasFocus;
      base.Update(gameTime, false, false);
    }

    public void selectOne(int min, int max, InputState input)
    {
      if (input.IsMenuLeft(this.ControllingPlayer))
      {
        --this.whichbutton;
        if (this.whichbutton < min)
          this.whichbutton = max;
        this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
      }
      if (!input.IsMenuRight(this.ControllingPlayer))
        return;
      ++this.whichbutton;
      if (this.whichbutton > max)
        this.whichbutton = min;
      this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
    }

    public void selectOneExclusive(int min, int max, InputState input)
    {
      if (input.IsMenuLeftExclusive(this.ControllingPlayer))
      {
        this.sc.Game.IsMouseVisible = false;
        --this.whichbutton;
        this.whichbutton = (int) MathHelper.Clamp((float) this.whichbutton, (float) min, (float) max);
        this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
      }
      if (input.IsMenuRightExclusive(this.ControllingPlayer))
      {
        this.sc.Game.IsMouseVisible = false;
        ++this.whichbutton;
        this.whichbutton = (int) MathHelper.Clamp((float) this.whichbutton, (float) min, (float) max);
        this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
      }
      if (input.IsNewButtonPress(Buttons.LeftShoulder, this.ControllingPlayer, out this.playerindex))
      {
        this.sc.Game.IsMouseVisible = false;
        --this.whichbutton;
        this.whichbutton = (int) MathHelper.Clamp((float) this.whichbutton, (float) min, (float) max);
        this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
      }
      if (input.IsNewButtonPress(Buttons.RightShoulder, this.ControllingPlayer, out this.playerindex))
      {
        this.sc.Game.IsMouseVisible = false;
        ++this.whichbutton;
        this.whichbutton = (int) MathHelper.Clamp((float) this.whichbutton, (float) min, (float) max);
        this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
      }
      if (this.menuState == MainMenu.states.graphics)
        return;
      if (input.IsNewButtonPress(Buttons.DPadLeft, this.ControllingPlayer, out this.playerindex))
      {
        this.sc.Game.IsMouseVisible = false;
        --this.whichbutton;
        this.whichbutton = (int) MathHelper.Clamp((float) this.whichbutton, (float) min, (float) max);
        this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
      }
      if (!input.IsNewButtonPress(Buttons.DPadRight, this.ControllingPlayer, out this.playerindex))
        return;
      this.sc.Game.IsMouseVisible = false;
      ++this.whichbutton;
      this.whichbutton = (int) MathHelper.Clamp((float) this.whichbutton, (float) min, (float) max);
      this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
    }

    public void backtomain(InputState input, int num)
    {
      if ((this.mouseState.RightButton != Microsoft.Xna.Framework.Input.ButtonState.Pressed ? 0 : (this.prevMouse.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Released ? 1 : 0)) == 0 && !input.IsNewButtonPress(Buttons.B, this.ControllingPlayer, out this.playerindex) && !input.IsMenuCancel(this.ControllingPlayer, out this.playerindex))
        return;
      this.whichbutton = num;
      this.menuState = MainMenu.states.main;
      this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
      this.delayinput = true;
    }

    public void forgotsave()
    {
      this.sc.SavePrefs();
      this.sc.setupnum = this.sc.resolution;
      this.sc.aa = this.sc.aliasing;
      this.sc.setgraphics = false;
      this.menuState = this.lastState2;
      this.whichbutton = 1;
      this.delayinput = true;
    }

    public bool KMtoggle(Microsoft.Xna.Framework.Input.Keys k)
    {
      return this.keyState.IsKeyDown(k) && this.prevKeys.IsKeyUp(k);
    }

    private void handleDiary(ref InputState input)
    {
      if (this.sc.workshop.myTimer % 250 == 0 || !this.sc.workshop.populateNow)
      {
        this.sc.workshop.populateDiary();
        this.sc.workshop.populateNow = true;
      }
      this.farmerBones(ref this.farmer1[0]);
      this.directNum = -1;
      if (this.sc.developer && this.sc.workshop.testmode)
      {
        if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.F1))
        {
          this.recording1 = !this.recording1;
          if (this.recording1)
          {
            this.recording2 = false;
            this.recording3 = false;
            this.recording4 = false;
          }
        }
        if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.F2))
        {
          this.recording2 = !this.recording2;
          if (this.recording2)
          {
            this.recording1 = false;
            this.recording3 = false;
            this.recording4 = false;
          }
        }
        if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.F3))
        {
          this.recording3 = !this.recording3;
          if (this.recording3)
          {
            this.recording1 = false;
            this.recording2 = false;
            this.recording4 = false;
          }
        }
        if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.F4))
        {
          this.recording4 = !this.recording4;
          if (this.recording4)
          {
            this.recording1 = false;
            this.recording2 = false;
            this.recording3 = false;
          }
        }
        if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.F5))
        {
          this.writeFile();
          this.sc.tick.Play(this.sc.ev, 0.8f, 0.0f);
        }
        if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.Home))
          this.removeTrack(100);
        if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.PageUp))
          this.removeTrack(101);
        if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.PageDown))
          this.removeTrack(102);
        if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.NumPad1))
          this.removeTrack(0);
        if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.NumPad2))
          this.removeTrack(1);
        if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.NumPad3))
          this.removeTrack(2);
        if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.NumPad4))
          this.removeTrack(3);
        if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.NumPad5))
          this.removeTrack(4);
        if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.NumPad6))
          this.removeTrack(5);
        if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.NumPad7))
          this.removeTrack(6);
        if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.NumPad8))
          this.removeTrack(7);
        if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.NumPad9))
          this.removeTrack(8);
        if (this.recording1)
        {
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D1))
            this.directNum = 1000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D2))
            this.directNum = 2000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D3))
            this.directNum = 3000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D4))
            this.directNum = 4000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D5))
            this.directNum = 5000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D6))
            this.directNum = 6000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D7))
            this.directNum = 7000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D8))
            this.directNum = 8000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D9))
            this.directNum = 9000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D0))
            this.directNum = 10000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.Q))
            this.directNum = 11000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.W))
            this.directNum = 12000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.E))
            this.directNum = 13000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.R))
            this.directNum = 14000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.T))
            this.directNum = 15000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.Y))
            this.directNum = 16000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.U))
            this.directNum = 17000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.I))
            this.directNum = 18000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.O))
            this.directNum = 19000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.P))
            this.directNum = 20000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.A))
            this.directNum = 21000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.S))
            this.directNum = 22000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D))
            this.directNum = 23000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.F))
            this.directNum = 24000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.G))
            this.directNum = 25000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.H))
            this.directNum = 26000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.J))
            this.directNum = 27000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.K))
            this.directNum = 28000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.L))
            this.directNum = 29000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.OemSemicolon))
            this.directNum = 30000;
        }
        if (this.recording2)
        {
          this.directRate = 0;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D1))
          {
            this.directNum = 51000;
            this.directRate = 0;
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D2))
          {
            this.directNum = 52000;
            this.directRate = 0;
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D3))
          {
            this.directNum = 53000;
            this.directRate = 0;
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D4))
          {
            this.directNum = 54000;
            this.directRate = 0;
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D5))
          {
            this.directNum = 55000;
            this.directRate = 0;
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D6))
          {
            this.directNum = 56000;
            this.directRate = 0;
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D7))
          {
            this.directNum = 57000;
            this.directRate = 0;
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D8))
          {
            this.directNum = 58000;
            this.directRate = 0;
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.Q))
          {
            this.directNum = 51000;
            this.directRate = 1;
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.W))
          {
            this.directNum = 52000;
            this.directRate = 1;
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.E))
          {
            this.directNum = 53000;
            this.directRate = 1;
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.R))
          {
            this.directNum = 54000;
            this.directRate = 1;
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.T))
          {
            this.directNum = 55000;
            this.directRate = 1;
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.Y))
          {
            this.directNum = 56000;
            this.directRate = 1;
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.U))
          {
            this.directNum = 57000;
            this.directRate = 1;
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.I))
          {
            this.directNum = 58000;
            this.directRate = 1;
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.O))
          {
            this.directNum = 59000;
            this.directRate = 1;
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.A))
          {
            this.directNum = 51000;
            this.directRate = 2;
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.S))
          {
            this.directNum = 52000;
            this.directRate = 2;
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D))
          {
            this.directNum = 53000;
            this.directRate = 2;
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.F))
          {
            this.directNum = 54000;
            this.directRate = 2;
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.G))
          {
            this.directNum = 55000;
            this.directRate = 2;
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.H))
          {
            this.directNum = 56000;
            this.directRate = 2;
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.J))
          {
            this.directNum = 57000;
            this.directRate = 2;
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.K))
          {
            this.directNum = 58000;
            this.directRate = 2;
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.L))
          {
            this.directNum = 59000;
            this.directRate = 2;
          }
          if (this.directNum >= 51000 && this.directNum <= 60000)
          {
            this.directNumX = (int) this.sc.adjustVector2(this.sc.mymouse).X + 5000;
            this.directNumY = (int) this.sc.adjustVector2(this.sc.mymouse).Y + 5000;
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.Z))
            this.directNum = 81000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.X))
            this.directNum = 82000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.C))
            this.directNum = 83000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.V))
            this.directNum = 84000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.B))
            this.directNum = 85000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.N))
            this.directNum = 86000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.M))
            this.directNum = 87000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.OemComma))
            this.directNum = 88000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.OemPeriod))
            this.directNum = 89000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.OemQuestion))
            this.directNum = 90000;
        }
        if (this.recording3)
        {
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D1))
            this.mediaIndex = 0;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D2))
            this.mediaIndex = 1;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D3))
            this.mediaIndex = 2;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D4))
            this.mediaIndex = 3;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D5))
            this.mediaIndex = 4;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D6))
            this.mediaIndex = 5;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D7))
            this.mediaIndex = 6;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D8))
            this.mediaIndex = 7;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D9))
            this.mediaIndex = 8;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D0))
            this.mediaIndex = 9;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.Q))
          {
            for (int index = 0; index < 10; ++index)
            {
              if (this.mediaIndex == index)
                this.directNum = 201000 + index * 1000;
            }
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.W))
          {
            for (int index = 0; index < 10; ++index)
            {
              if (this.mediaIndex == index)
                this.directNum = 211000 + index * 1000;
            }
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.E))
          {
            for (int index = 0; index < 10; ++index)
            {
              if (this.mediaIndex == index)
                this.directNum = 221000 + index * 1000;
            }
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.R))
          {
            for (int index = 0; index < 10; ++index)
            {
              if (this.mediaIndex == index)
                this.directNum = 231000 + index * 1000;
            }
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.T))
          {
            for (int index = 0; index < 10; ++index)
            {
              if (this.mediaIndex == index)
                this.directNum = 241000 + index * 1000;
            }
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.Y))
          {
            for (int index = 0; index < 10; ++index)
            {
              if (this.mediaIndex == index)
                this.directNum = 251000 + index * 1000;
            }
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.U))
          {
            for (int index = 0; index < 10; ++index)
            {
              if (this.mediaIndex == index)
                this.directNum = 261000 + index * 1000;
            }
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.I))
          {
            for (int index = 0; index < 10; ++index)
            {
              if (this.mediaIndex == index)
                this.directNum = 271000 + index * 1000;
            }
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.O))
          {
            for (int index = 0; index < 10; ++index)
            {
              if (this.mediaIndex == index)
                this.directNum = 281000 + index * 1000;
            }
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.P))
          {
            for (int index = 0; index < 10; ++index)
            {
              if (this.mediaIndex == index)
                this.directNum = 291000 + index * 1000;
            }
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.A))
          {
            for (int index = 0; index < 10; ++index)
            {
              if (this.mediaIndex == index)
                this.directNum = 111000 + index * 1000;
            }
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.S))
          {
            for (int index = 0; index < 10; ++index)
            {
              if (this.mediaIndex == index)
                this.directNum = 121000 + index * 1000;
            }
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D))
          {
            for (int index = 0; index < 10; ++index)
            {
              if (this.mediaIndex == index)
                this.directNum = 131000 + index * 1000;
            }
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.F))
          {
            for (int index = 0; index < 10; ++index)
            {
              if (this.mediaIndex == index)
                this.directNum = 141000 + index * 1000;
            }
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.Z))
          {
            for (int index = 0; index < 10; ++index)
            {
              if (this.mediaIndex == index)
                this.directNum = 151000 + index * 1000;
            }
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.X))
          {
            for (int index = 0; index < 10; ++index)
            {
              if (this.mediaIndex == index)
                this.directNum = 161000 + index * 1000;
            }
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.C))
          {
            for (int index = 0; index < 10; ++index)
            {
              if (this.mediaIndex == index)
                this.directNum = 171000 + index * 1000;
            }
          }
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.V))
          {
            for (int index = 0; index < 10; ++index)
            {
              if (this.mediaIndex == index)
                this.directNum = 181000 + index * 1000;
            }
          }
        }
        if (this.recording4)
        {
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D1))
            this.directNum = 301000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D2))
            this.directNum = 302000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D3))
            this.directNum = 303000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D4))
            this.directNum = 304000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D5))
            this.directNum = 305000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D6))
            this.directNum = 306000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D7))
            this.directNum = 307000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D8))
            this.directNum = 308000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D9))
            this.directNum = 309000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.Y))
            this.colorXtemp = 0;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.U))
            this.colorXtemp = 1;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.I))
            this.colorXtemp = 2;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.H))
            this.colorXtemp = 3;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.J))
            this.colorXtemp = 4;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.K))
            this.colorXtemp = 5;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.N))
            this.colorXtemp = 6;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.M))
            this.colorXtemp = 7;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.OemComma))
            this.colorXtemp = 8;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.Q))
            this.directNum = 311000 + this.colorXtemp * 1000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.W))
            this.directNum = 321000 + this.colorXtemp * 1000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.E))
            this.directNum = 331000 + this.colorXtemp * 1000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.A))
            this.directNum = 341000 + this.colorXtemp * 1000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.S))
            this.directNum = 351000 + this.colorXtemp * 1000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.D))
            this.directNum = 361000 + this.colorXtemp * 1000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.Z))
            this.directNum = 371000 + this.colorXtemp * 1000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.X))
            this.directNum = 381000 + this.colorXtemp * 1000;
          if (this.KMtoggle(Microsoft.Xna.Framework.Input.Keys.C))
            this.directNum = 391000 + this.colorXtemp * 1000;
        }
      }
      if (!this.mouseback && !input.IsNewButtonPress(Buttons.Back, this.ControllingPlayer, out this.playerindex) && !input.IsMenuCancel(this.ControllingPlayer, out this.playerindex))
      {
        if ((this.mousepress || input.IsMenuSelect(this.ControllingPlayer, out this.playerindex)) && this.sc.workshop.entry.Count > 0)
        {
          for (int index = 0; index < this.sc.workshop.entry.Count; ++index)
          {
            if (this.whichbutton == index)
            {
              this.resetImages();
              this.entryIndex = index;
              if (this.sc.workshop.entry[index].dates == "03.20.21" && (!this.sc.star1 || !this.sc.star2 || !this.sc.star3))
              {
                this.sc.harp2.Play(this.sc.ev, 0.5f, 0.0f);
                this.sc.star1 = true;
                this.sc.star2 = true;
                this.sc.star3 = true;
              }
              if (this.followPoint)
                this.lastlookpos = this.lookpos[this.lookIndex];
              if (!this.followPoint)
                this.lastlookpos = this.sc.adjustVector2(this.sc.mymouse);
              this.lookIndex = 0;
              this.followTween = 1f;
              this.sc.workshop.entryIndex = index;
              this.farmerTalk();
              this.sc.workshopNum = this.sc.workshop.fileSize;
              this.sc.SavePrefs();
              this.followTimer = 2f;
              break;
            }
          }
        }
        if (this.whichbutton != -1)
          this.lastbutton = this.whichbutton;
        if (!this.mousemoving)
          return;
        this.whichbutton = -1;
      }
      else
      {
        this.bool_0 = false;
        try
        {
          this.farmerDialog1.sound[0].Dispose();
        }
        catch
        {
          this.bool_0 = false;
        }
        this.resetFarmerDirector();
        this.resetImages();
        this.sc.workshop.populateNow = false;
        this.whichbutton = 0;
        this.menuState = MainMenu.states.more;
        this.menuSelect = 1;
        this.sc.switch2.Play(this.sc.ev * 0.2f, 0.1f, 0.0f);
        this.delayinput = true;
      }
    }

    private void handleMain(ref InputState input)
    {
      this.pigwalk = 0;
      this.pigcount = 11;
      this.sc.hordemode = false;
      this.sc.paintland = false;
      this.sc.lobby.players = "0";
      this.sc.lobby.lobbyplayers = "0";
      if (!this.mouseback && !input.IsNewButtonPress(Buttons.Back, this.ControllingPlayer, out this.playerindex) && !input.IsMenuCancel(this.ControllingPlayer, out this.playerindex))
      {
        this.selectOneExclusive(0, 3, input);
        if (this.sc.moremodelsLoaded && (this.mousepress || input.IsMenuSelect(this.ControllingPlayer, out this.playerindex)))
        {
          if (this.whichbutton == 0)
          {
            this.whichbutton = 0;
            this.menuState = MainMenu.states.playgame;
            this.b.main = false;
            this.menuSelect = 1;
            this.sc.switch2.Play(this.sc.ev * 0.2f, 0.1f, 0.0f);
          }
          if (this.whichbutton == 1)
          {
            this.whichbutton = 0;
            this.menuState = MainMenu.states.coopChoice;
            this.b.main = false;
            this.sc.switch2.Play(this.sc.ev * 0.2f, 0.2f, 0.0f);
          }
          if (this.whichbutton == 2)
          {
            this.whichbutton = 0;
            this.menuState = MainMenu.states.settings;
            this.b.main = false;
            this.sc.switch2.Play(this.sc.ev * 0.2f, 0.2f, 0.0f);
          }
          if (this.whichbutton == 3)
          {
            this.whichbutton = 0;
            this.checkTrophyOnce = false;
            this.menuState = MainMenu.states.more;
            this.b.main = false;
            this.moreTimer = 440;
            this.sc.switch2.Play(this.sc.ev * 0.2f, 0.1f, 0.0f);
          }
          if (this.whichbutton == 7 && !this.sc.lockVideosetup)
          {
            this.sc.setupnum = this.sc.resolution;
            this.sc.aa = this.sc.aliasing;
            this.whichbutton = 0;
            this.sc.harp2.Play(this.sc.ev * 0.6f, 0.4f, 0.0f);
            this.lastState2 = MainMenu.states.main;
            this.menuState = MainMenu.states.graphics;
            this.b.main = false;
            this.sc.switch2.Play(this.sc.ev * 0.2f, 0.2f, 0.0f);
          }
          if (this.whichbutton == 8)
          {
            this.whichbutton = 0;
            this.sc.harp2.Play(this.sc.ev * 0.6f, -0.2f, 0.0f);
            this.lastState2 = MainMenu.states.main;
            this.menuState = MainMenu.states.audio;
            this.b.main = false;
            this.sc.switch2.Play(this.sc.ev * 0.2f, 0.2f, 0.0f);
            this.slider1 = (int) Math.Round(Math.Sqrt((double) this.sc.mv * 100.0));
            this.slider2 = (int) Math.Round(Math.Sqrt((double) this.sc.ev * 100.0));
            this.slider3 = (int) Math.Round(Math.Sqrt((double) this.sc.vv * 100.0));
            this.slider1 = (int) MathHelper.Clamp((float) this.slider1, 0.0f, 10f);
            this.slider2 = (int) MathHelper.Clamp((float) this.slider2, 0.0f, 10f);
            this.slider3 = (int) MathHelper.Clamp((float) this.slider3, 0.0f, 10f);
            this.sliderbox1 = (float) ((double) this.slider1 * 31.399999618530273 - 157.0);
            this.sliderbox2 = (float) ((double) this.slider2 * 31.399999618530273 - 157.0);
            this.sliderbox3 = (float) ((double) this.slider3 * 31.399999618530273 - 157.0);
            this.myIndex = -1;
          }
          if (this.whichbutton == 9)
          {
            this.whichbutton = 0;
            this.sc.harp2.Play(this.sc.ev * 0.6f, 0.2f, 0.0f);
            this.menuState = MainMenu.states.controls;
            this.b.main = false;
            this.lastState2 = MainMenu.states.main;
            this.sc.switch2.Play(this.sc.ev * 0.2f, 0.2f, 0.0f);
          }
          if (this.whichbutton == 11 && this.paintunlocked)
          {
            this.sc.harp2.Play(this.sc.ev * 0.6f, -0.2f, 0.0f);
            MessageBoxScreen2 screen = new MessageBoxScreen2("Name a Famous Painter", 4);
            screen.Approved += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
            {
              this.sc.SavePrefs();
              this.whichbutton = 0;
              this.menuState = MainMenu.states.multi3player;
              this.b.main = false;
              this.sc.switch2.Play(this.sc.ev * 0.2f, 0.2f, 0.0f);
              this.delayinput = true;
            });
            screen.Failed += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
            {
              this.sc.pigDie[0].Play(this.sc.ev, 0.0f, 0.0f);
              this.delayinput = true;
            });
            screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
            this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
          }
          if (this.whichbutton == 12)
          {
            this.sc.harp2.Play(this.sc.ev * 0.6f, 0.2f, 0.0f);
            if (this.sc.star1)
            {
              MessageBoxScreen2 screen = new MessageBoxScreen2("SECRET ABILITY\nEnable Faster Grenades?\n", 1);
              screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
              {
                this.sc.fastnades = true;
                this.delayinput = true;
                this.sc.SavePrefs();
              });
              screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
              {
                this.sc.fastnades = false;
                this.delayinput = true;
                this.sc.SavePrefs();
              });
              this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
            }
            if (!this.sc.star1)
            {
              MessageBoxScreen2 screen = new MessageBoxScreen2("SECRET#1  LOCKED", 0);
              screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
              screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
              this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
            }
          }
          if (this.whichbutton == 13)
          {
            this.sc.harp2.Play(this.sc.ev * 0.6f, 0.2f, 0.0f);
            if (this.sc.star2)
            {
              MessageBoxScreen2 screen = new MessageBoxScreen2("SECRET ABILITY\nEnable Extra Gore?\nchatbox :gore\n", 1);
              screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
              {
                this.sc.gorelevel = 1;
                this.delayinput = true;
                this.sc.SavePrefs();
              });
              screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
              {
                this.sc.gorelevel = 0;
                this.delayinput = true;
                this.sc.SavePrefs();
              });
              this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
            }
            if (!this.sc.star2)
            {
              MessageBoxScreen2 screen = new MessageBoxScreen2("SECRET#2  LOCKED", 0);
              screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
              screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
              this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
            }
          }
          if (this.whichbutton == 14)
          {
            this.sc.harp2.Play(this.sc.ev * 0.6f, 0.2f, 0.0f);
            if (this.sc.star3)
            {
              MessageBoxScreen2 screen = new MessageBoxScreen2("SECRET ABILITY\nEnable Double Ammo?\n", 1);
              screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
              {
                this.sc.doubleAmmo = true;
                this.delayinput = true;
                this.sc.SavePrefs();
              });
              screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
              {
                this.sc.doubleAmmo = false;
                this.delayinput = true;
                this.sc.SavePrefs();
              });
              this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
            }
            if (!this.sc.star3)
            {
              MessageBoxScreen2 screen = new MessageBoxScreen2("SECRET#3  LOCKED", 0);
              screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
              screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
              this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
            }
          }
        }
        if (this.sc.developer && this.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F1) && this.prevKeys.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.F1))
        {
          this.sc.resetGame();
          this.sc.harp2.Play(this.sc.ev, 0.0f, 0.0f);
          for (int index = 0; index < this.sc.days.Length; ++index)
          {
            this.sc.days[index] = 0;
            this.sc.gdata.days[index] = (byte) 0;
          }
          int num = 50;
          for (int index = 0; index < num; ++index)
            this.sc.days[index] = 1;
          for (int index = 0; index < this.sc.hats.Length; ++index)
            this.sc.hats[index] = 0;
          this.sc.hats[1] = 0;
          this.sc.hats[2] = 0;
          this.sc.hats[3] = 0;
          this.sc.hats[4] = 0;
          this.sc.hats[5] = 0;
          this.sc.hats[6] = 0;
          this.sc.hats[7] = 0;
          this.sc.hats[8] = 0;
          this.sc.hats[9] = 0;
          this.sc.hats[10] = 0;
          this.sc.hats[11] = 0;
          this.sc.hats[12] = 0;
          this.sc.hats[13] = 0;
          this.sc.hats[14] = 0;
          this.sc.hats[15] = 0;
          this.sc.man1 = true;
          this.sc.man2 = true;
          this.sc.man3 = true;
          this.sc.man4 = true;
          this.sc.FarmerUnlocked = true;
          this.sc.resetTunnels();
          this.sc.goggles = 1;
          this.sc.exitkey[0] = 0;
          this.sc.exitkey[1] = 0;
          this.sc.exitkey[2] = 0;
          this.sc.exitkey[3] = 0;
          this.sc.exitkey[4] = 0;
          this.sc.exitkey[5] = 0;
          this.sc.flashlight1 = 0;
          this.sc.flashlight2 = 0;
          this.sc.flashlight3 = 0;
          this.sc.SaveGame();
        }
        if (this.sc.developer && this.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F3) && this.prevKeys.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.F3))
        {
          MessageBoxScreen2 screen = new MessageBoxScreen2("Give all Achievements\nAre you sure?\n", 1);
          screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
          {
            this.sc.trophy.gimme();
            this.delayinput = true;
          });
          screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
          this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
        }
        if (this.sc.developer && this.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F4) && this.prevKeys.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.F4))
        {
          MessageBoxScreen2 screen = new MessageBoxScreen2("Delete all Achievements\nAre you sure?\n", 1);
          screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
          {
            this.sc.man4 = false;
            this.sc.star1 = false;
            this.sc.star2 = false;
            this.sc.star3 = false;
            this.sc.trophy.resetStats();
            this.sc.trophy.init();
            this.sc.fanfare.Play(this.sc.ev, 0.0f, 0.0f);
            this.delayinput = true;
          });
          screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
          this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
        }
        if (this.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F5) && this.prevKeys.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.F5))
        {
          MessageBoxScreen2 screen = new MessageBoxScreen2("Delete All Preferences\nAre you sure?\n", 1);
          screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
          {
            using (IsolatedStorageFile store = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, (System.Type) null, (System.Type) null))
            {
              string str = "saveprefs";
              if (store.FileExists(str))
                store.DeleteFile(str);
            }
            string path = "SAVES//saveprefs";
            if (!File.Exists(path))
              File.Delete(path);
            this.sc.fanfare.Play(this.sc.ev, 0.0f, 0.0f);
            this.delayinput = true;
            this.sc.resetPreferences();
            this.sc.SavePrefs();
          });
          screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
          this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
        }
        if (this.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F6) && this.prevKeys.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.F6))
        {
          MessageBoxScreen2 screen = new MessageBoxScreen2("Reset Blood and Bacon\nStart Game from Day 1\nAre you sure?\n", 1);
          screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
          {
            using (IsolatedStorageFile store = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, (System.Type) null, (System.Type) null))
            {
              string str = "savegame";
              if (store.FileExists(str))
                store.DeleteFile(str);
            }
            string path = "SAVES//savegame";
            if (!File.Exists(path))
              File.Delete(path);
            this.sc.resetGame();
            this.sc.man1 = false;
            this.sc.man2 = false;
            this.sc.man3 = false;
            this.sc.man4 = false;
            this.sc.SaveGame();
            this.sc.fanfare.Play(this.sc.ev, 0.0f, 0.0f);
            this.delayinput = true;
          });
          screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
          this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
        }
        if (this.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F7) && this.prevKeys.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.F7))
        {
          MessageBoxScreen2 screen = new MessageBoxScreen2("Reset Tunnels Update\nAre you sure?\n", 1);
          screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
          {
            this.sc.resetTunnels();
            this.sc.fanfare.Play(this.sc.ev, 0.3f, 0.0f);
          });
          screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
          this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
        }
        if (this.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F8) && this.prevKeys.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.F8))
        {
          MessageBoxScreen2 screen = new MessageBoxScreen2("Delete Space Mission Data\nAre you sure?\n", 1);
          screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
          {
            string path = "SAVES//spaceprefs";
            if (File.Exists(path))
            {
              try
              {
                File.Delete(path);
                this.sc.fanfare.Play(this.sc.ev, 0.0f, 0.0f);
              }
              catch
              {
                this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
              }
            }
            this.delayinput = true;
            this.sc.resetSpacePrefs();
            this.sc.SaveSpacePrefs();
            this.sc.man4 = false;
          });
          screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
          this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
        }
        if (this.whichbutton != -1)
          this.lastbutton = this.whichbutton;
        if (!this.mousemoving)
          return;
        this.whichbutton = -1;
      }
      else
        this.exitGame();
    }

    private void handleMore(ref InputState input)
    {
      if (this.moreTimer % 450 == 0)
      {
        this.sc.workshop.getSubscribedItems();
        this.sc.workshop.forceDownloadFileId();
      }
      if (this.moreTimer > 300 && !this.b.more && SteamAPI.IsSteamRunning())
      {
        this.sc.trophy.checkAll();
        this.b.more = true;
      }
      if (this.sc.trophy.allcomplete)
      {
        if (!this.sc.allachieves)
          this.sc.achievepop.Play(this.sc.ev, 0.0f, -1f);
        this.sc.allachieves = true;
      }
      else
        this.sc.allachieves = false;
      if (!this.mouseback && !input.IsNewButtonPress(Buttons.Back, this.ControllingPlayer, out this.playerindex) && !input.IsMenuCancel(this.ControllingPlayer, out this.playerindex))
      {
        this.selectOneExclusive(0, 3, input);
        if (this.mousepress || input.IsMenuSelect(this.ControllingPlayer, out this.playerindex))
        {
          if (this.whichbutton == 4)
          {
            this.whichbutton = 0;
            this.menuState = MainMenu.states.main;
            this.b.more = false;
            this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
            this.delayinput = true;
            return;
          }
          if (this.whichbutton == 0)
          {
            if (SteamAPI.IsSteamRunning())
            {
              this.sc.workshop.getSubscribedItems();
              this.sc.workshop.forceDownloadFileId();
              if (this.sc.workshop.weSubscribed)
              {
                this.whichbutton = -1;
                this.menuState = MainMenu.states.diary;
                this.b.more = false;
                this.menuSelect = 1;
                this.sc.switch2.Play(this.sc.ev * 0.2f, 0.1f, 0.0f);
              }
              else
              {
                this.sc.cancel.Play(this.sc.ev, 0.5f, 0.0f);
                MessageBoxScreen2 screen = new MessageBoxScreen2("Subscribe to the\nDearDiary Workshop", 0);
                screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
                screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
                this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
                this.delayinput = true;
                this.sc.workshopNum = 0;
                this.sc.SavePrefs();
              }
            }
            else
            {
              this.sc.cancel.Play(this.sc.ev, (float) this.rr.Next(-60, 60) / 100f, 0.0f);
              MessageBoxScreen2 screen = new MessageBoxScreen2("Steam is currently\noffline, try later.", 0);
              screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
              screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
              this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
              this.delayinput = true;
              this.sc.workshopNum = 0;
              this.sc.SavePrefs();
            }
          }
          if (this.whichbutton == 1)
          {
            this.whichbutton = 0;
            this.menuState = MainMenu.states.workshop;
            this.b.more = false;
            this.subRow = 0;
            this.workshopChosen = 1;
            this.drawsubs = false;
            this.drawcustom = false;
            this.sc.hammer1.Play(this.sc.ev, 0.0f, 0.0f);
            this.sc.loadCrosshairC();
            this.delayinput = true;
          }
          if (this.whichbutton == 2)
          {
            this.sc.harp2.Play(this.sc.ev * 0.6f, -0.2f, 0.0f);
            MessageBoxScreen2 screen = new MessageBoxScreen2("Name a Famous Painter", 4);
            screen.Approved += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
            {
              this.sc.SavePrefs();
              this.whichbutton = 0;
              this.menuState = MainMenu.states.multi3player;
              this.b.main = false;
              this.sc.switch2.Play(this.sc.ev * 0.2f, 0.2f, 0.0f);
              this.delayinput = true;
            });
            screen.Failed += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
            {
              this.sc.pigDie[0].Play(this.sc.ev, 0.0f, 0.0f);
              this.delayinput = true;
            });
            screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
            this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
          }
          if (this.whichbutton == 3)
          {
            this.whichbutton = 0;
            this.menuState = MainMenu.states.videos;
            this.b.more = false;
            this.sc.switch2.Play(this.sc.ev * 0.2f, 0.1f, 0.0f);
          }
          if (this.whichbutton == 12)
          {
            this.sc.harp2.Play(this.sc.ev * 0.6f, 0.2f, 0.0f);
            if (this.sc.star1)
            {
              MessageBoxScreen2 screen = new MessageBoxScreen2("SECRET ABILITY\nEnable Faster Grenades?\n", 1);
              screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
              {
                this.sc.fastnades = true;
                this.delayinput = true;
                this.sc.SavePrefs();
              });
              screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
              {
                this.sc.fastnades = false;
                this.delayinput = true;
                this.sc.SavePrefs();
              });
              this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
            }
            if (!this.sc.star1)
            {
              MessageBoxScreen2 screen = new MessageBoxScreen2("SECRET#1  LOCKED", 0);
              screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
              screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
              this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
            }
          }
          if (this.whichbutton == 13)
          {
            this.sc.harp2.Play(this.sc.ev * 0.6f, 0.2f, 0.0f);
            if (this.sc.star2)
            {
              MessageBoxScreen2 screen = new MessageBoxScreen2("SECRET ABILITY\nEnable Extra Gore?\nchatbox :gore\n", 1);
              screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
              {
                this.sc.gorelevel = 1;
                this.delayinput = true;
                this.sc.SavePrefs();
              });
              screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
              {
                this.sc.gorelevel = 0;
                this.delayinput = true;
                this.sc.SavePrefs();
              });
              this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
            }
            if (!this.sc.star2)
            {
              MessageBoxScreen2 screen = new MessageBoxScreen2("SECRET#2  LOCKED", 0);
              screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
              screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
              this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
            }
          }
          if (this.whichbutton == 14)
          {
            this.sc.harp2.Play(this.sc.ev * 0.6f, 0.2f, 0.0f);
            if (this.sc.star3)
            {
              MessageBoxScreen2 screen = new MessageBoxScreen2("SECRET ABILITY\nEnable Double Ammo?\n", 1);
              screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
              {
                this.sc.doubleAmmo = true;
                this.delayinput = true;
                this.sc.SavePrefs();
              });
              screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
              {
                this.sc.doubleAmmo = false;
                this.delayinput = true;
                this.sc.SavePrefs();
              });
              this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
            }
            if (!this.sc.star3)
            {
              MessageBoxScreen2 screen = new MessageBoxScreen2("SECRET#3  LOCKED", 0);
              screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
              screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
              this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
            }
          }
        }
        if (this.whichbutton != -1)
          this.lastbutton = this.whichbutton;
        if (!this.mousemoving)
          return;
        this.whichbutton = -1;
      }
      else
      {
        this.whichbutton = 0;
        this.menuState = MainMenu.states.main;
        this.b.more = false;
        this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
        this.delayinput = true;
      }
    }

    private void handleWorkshop(ref InputState input)
    {
      this.selectOneExclusive(0, 3, input);
      if (this.mousepress || input.IsMenuSelect(this.ControllingPlayer, out this.playerindex))
      {
        if (!this.sc.workshop.showPublishbox)
        {
          if (this.whichbutton == 0)
          {
            this.drawcustom = true;
            this.drawsubs = false;
            this.subRow = 0;
            this.sc.switch2.Play(this.sc.ev * 0.2f, 0.1f, 0.0f);
            if (this.sc.crosshairC.Count < 1)
              this.techinfoBox("No Custom Crosshairs Found\nPlease Place PNG Files\nIn The Crosshairs Folder\n");
          }
          if (this.whichbutton == 1)
          {
            this.drawsubs = true;
            this.drawcustom = false;
            this.subRow = 0;
            this.sc.workshop.getSubscribedItems();
            if (this.sc.workshop.totalSubscriptions <= 0U)
            {
              MessageBoxScreen2 screen = new MessageBoxScreen2("You Have No Subscriptions\nPlease Visit The Workshop\nAnd Pick A Few...\n", 18);
              screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
              {
                this.sc.workshop.openWEB("steam://url/SteamWorkshopPage/" + (object) this.sc.workshop.myappID);
                this.delayinput = true;
              });
              screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
              this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
            }
            if (this.sc.workshop.totalSubscriptions > 0U)
            {
              this.sc.switch2.Play(this.sc.ev * 0.2f, 0.1f, 0.0f);
              this.sc.workshop.getSubbedTextures();
            }
          }
          if (this.whichbutton == 2)
          {
            if (this.sc.workshop.status == "")
            {
              if (this.sc.crosshair1[this.workshopChosen].type == 1 && this.sc.crosshair1[this.workshopChosen].legal)
              {
                this.sc.switch2.Play(this.sc.ev * 0.2f, 0.1f, 0.0f);
                this.sc.workshop.showPublishbox = true;
                this.zoomX = 0;
                this.zoomY = 0;
              }
              else
              {
                if (this.sc.crosshair1[this.workshopChosen].legal)
                  this.techinfoBox("Please Select A Filled Loadout\n");
                if (!this.sc.crosshair1[this.workshopChosen].legal)
                  this.techinfoBox("You are not allowed\nto republish this item\n");
              }
            }
            if (this.sc.workshop.status == "FAIL" || this.sc.workshop.status == "DONE")
              this.sc.workshop.status = "";
          }
          if (this.whichbutton == 3)
          {
            this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
            this.sc.saveLoadOut();
            this.checkTrophyOnce = false;
            this.menuState = MainMenu.states.more;
            this.delayinput = true;
            this.whichbutton = 1;
          }
          if (this.whichbutton == 20)
            this.workshopChosen = 1;
          if (this.whichbutton == 21)
            this.workshopChosen = 2;
          if (this.whichbutton == 22)
            this.workshopChosen = 3;
          if (this.whichbutton == 28)
          {
            this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            --this.subRow;
            if (this.subRow <= 0)
              this.subRow = 0;
          }
          if (this.whichbutton == 29)
          {
            this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
            ++this.subRow;
            if (this.subRow > 3)
              this.subRow = 3;
          }
          if (this.whichbutton == 23)
          {
            int num = this.subRow * 5 + 1;
            if (!this.drawcustom && !this.drawsubs || this.drawcustom && this.sc.crosshairC.Count < num || this.drawsubs && this.sc.workshop.crosshairS.Count < num)
            {
              this.techinfoBox("This Slot Is Empty\n");
            }
            else
            {
              this.sc.drip.Play(this.sc.ev, -0.5f, 0.0f);
              if (this.drawcustom)
              {
                this.sc.crosshair1[this.workshopChosen].texture = this.sc.crosshairC[num - 1];
                this.sc.crosshair1[this.workshopChosen].type = 1;
                this.sc.crosshair1[this.workshopChosen].legal = true;
              }
              if (this.drawsubs)
              {
                this.sc.crosshair1[this.workshopChosen].texture = this.sc.workshop.crosshairS[num - 1];
                this.sc.crosshair1[this.workshopChosen].type = 1;
                this.sc.crosshair1[this.workshopChosen].legal = false;
              }
            }
          }
          if (this.whichbutton == 24)
          {
            int num = this.subRow * 5 + 2;
            if (!this.drawcustom && !this.drawsubs || this.drawcustom && this.sc.crosshairC.Count < num || this.drawsubs && this.sc.workshop.crosshairS.Count < num)
            {
              this.techinfoBox("This Slot Is Empty\n");
            }
            else
            {
              this.sc.drip.Play(this.sc.ev, -0.5f, 0.0f);
              if (this.drawcustom)
              {
                this.sc.crosshair1[this.workshopChosen].texture = this.sc.crosshairC[num - 1];
                this.sc.crosshair1[this.workshopChosen].type = 1;
                this.sc.crosshair1[this.workshopChosen].legal = true;
              }
              if (this.drawsubs)
              {
                this.sc.crosshair1[this.workshopChosen].texture = this.sc.workshop.crosshairS[num - 1];
                this.sc.crosshair1[this.workshopChosen].type = 1;
                this.sc.crosshair1[this.workshopChosen].legal = false;
              }
            }
          }
          if (this.whichbutton == 25)
          {
            int num = this.subRow * 5 + 3;
            if (!this.drawcustom && !this.drawsubs || this.drawcustom && this.sc.crosshairC.Count < num || this.drawsubs && this.sc.workshop.crosshairS.Count < num)
            {
              this.techinfoBox("This Slot Is Empty\n");
            }
            else
            {
              this.sc.drip.Play(this.sc.ev, -0.5f, 0.0f);
              if (this.drawcustom)
              {
                this.sc.crosshair1[this.workshopChosen].texture = this.sc.crosshairC[num - 1];
                this.sc.crosshair1[this.workshopChosen].type = 1;
                this.sc.crosshair1[this.workshopChosen].legal = true;
              }
              if (this.drawsubs)
              {
                this.sc.crosshair1[this.workshopChosen].texture = this.sc.workshop.crosshairS[num - 1];
                this.sc.crosshair1[this.workshopChosen].type = 1;
                this.sc.crosshair1[this.workshopChosen].legal = false;
              }
            }
          }
          if (this.whichbutton == 26)
          {
            int num = this.subRow * 5 + 4;
            if (!this.drawcustom && !this.drawsubs || this.drawcustom && this.sc.crosshairC.Count < num || this.drawsubs && this.sc.workshop.crosshairS.Count < num)
            {
              this.techinfoBox("This Slot Is Empty\n");
            }
            else
            {
              this.sc.drip.Play(this.sc.ev, -0.5f, 0.0f);
              if (this.drawcustom)
              {
                this.sc.crosshair1[this.workshopChosen].texture = this.sc.crosshairC[num - 1];
                this.sc.crosshair1[this.workshopChosen].type = 1;
                this.sc.crosshair1[this.workshopChosen].legal = true;
              }
              if (this.drawsubs)
              {
                this.sc.crosshair1[this.workshopChosen].texture = this.sc.workshop.crosshairS[num - 1];
                this.sc.crosshair1[this.workshopChosen].type = 1;
                this.sc.crosshair1[this.workshopChosen].legal = false;
              }
            }
          }
          if (this.whichbutton == 27)
          {
            int num = this.subRow * 5 + 5;
            if (!this.drawcustom && !this.drawsubs || this.drawcustom && this.sc.crosshairC.Count < num || this.drawsubs && this.sc.workshop.crosshairS.Count < num)
            {
              this.techinfoBox("This Slot Is Empty\n");
            }
            else
            {
              this.sc.drip.Play(this.sc.ev, -0.5f, 0.0f);
              if (this.drawcustom)
              {
                this.sc.crosshair1[this.workshopChosen].texture = this.sc.crosshairC[num - 1];
                this.sc.crosshair1[this.workshopChosen].type = 1;
                this.sc.crosshair1[this.workshopChosen].legal = true;
              }
              if (this.drawsubs)
              {
                this.sc.crosshair1[this.workshopChosen].texture = this.sc.workshop.crosshairS[num - 1];
                this.sc.crosshair1[this.workshopChosen].type = 1;
                this.sc.crosshair1[this.workshopChosen].legal = false;
              }
            }
          }
          if (this.whichbutton == 30)
            this.sc.crosshair1[1].type = 0;
          if (this.whichbutton == 31)
            this.sc.crosshair1[2].type = 0;
          if (this.whichbutton == 32)
            this.sc.crosshair1[3].type = 0;
        }
        if (this.sc.workshop.showPublishbox)
        {
          if (this.whichbutton == 4)
          {
            MessageBoxScreen2 screen = new MessageBoxScreen2("Title", 14);
            screen.Approved += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
            {
              this.sc.switch2.Play(this.sc.ev * 0.2f, 0.2f, 0.0f);
              this.delayinput = true;
            });
            screen.Failed += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
            {
              this.sc.pigDie[1].Play(this.sc.ev, 0.0f, 0.0f);
              this.delayinput = true;
            });
            screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
            this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
          }
          if (this.whichbutton == 5)
          {
            MessageBoxScreen2 screen = new MessageBoxScreen2("Description", 15);
            screen.Approved += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
            {
              this.sc.switch2.Play(this.sc.ev * 0.2f, 0.2f, 0.0f);
              this.delayinput = true;
            });
            screen.Failed += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
            {
              this.sc.pigDie[1].Play(this.sc.ev, 0.0f, 0.0f);
              this.delayinput = true;
            });
            screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
            this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
          }
          if (this.whichbutton == 50)
          {
            MessageBoxScreen2 screen = new MessageBoxScreen2("Corner WaterMark", 17);
            screen.Approved += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
            {
              this.sc.switch2.Play(this.sc.ev * 0.2f, 0.2f, 0.0f);
              this.delayinput = true;
            });
            screen.Failed += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
            screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
            this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
          }
          if (this.whichbutton == 6)
          {
            if (this.formDrawBG)
            {
              if (this.formBGColorindex == 0)
                this.formDrawBG = false;
            }
            else
              this.formDrawBG = true;
            this.formBGColorindex = 0;
          }
          if (this.whichbutton == 7)
          {
            if (this.formDrawBG)
            {
              if (this.formBGColorindex == 1)
                this.formDrawBG = false;
            }
            else
              this.formDrawBG = true;
            this.formBGColorindex = 1;
          }
          if (this.whichbutton == 8)
          {
            if (this.formDrawBG)
            {
              if (this.formBGColorindex == 2)
                this.formDrawBG = false;
            }
            else
              this.formDrawBG = true;
            this.formBGColorindex = 2;
          }
          if (this.whichbutton == 9)
          {
            if (this.formDrawBG)
            {
              if (this.formBGColorindex == 3)
                this.formDrawBG = false;
            }
            else
              this.formDrawBG = true;
            this.formBGColorindex = 3;
          }
          if (this.whichbutton == 10)
          {
            if (this.formDrawBG)
            {
              if (this.formBGColorindex == 4)
                this.formDrawBG = false;
            }
            else
              this.formDrawBG = true;
            this.formBGColorindex = 4;
          }
          if (this.whichbutton == 66)
          {
            if (this.formDrawBand)
            {
              if (this.formBandColorIndex == 0)
                this.formDrawBand = false;
            }
            else
              this.formDrawBand = true;
            this.formBandColorIndex = 0;
          }
          if (this.whichbutton == 67)
          {
            if (this.formDrawBand)
            {
              if (this.formBandColorIndex == 1)
                this.formDrawBand = false;
            }
            else
              this.formDrawBand = true;
            this.formBandColorIndex = 1;
          }
          if (this.whichbutton == 68)
          {
            if (this.formDrawBand)
            {
              if (this.formBandColorIndex == 2)
                this.formDrawBand = false;
            }
            else
              this.formDrawBand = true;
            this.formBandColorIndex = 2;
          }
          if (this.whichbutton == 69)
          {
            if (this.formDrawBand)
            {
              if (this.formBandColorIndex == 3)
                this.formDrawBand = false;
            }
            else
              this.formDrawBand = true;
            this.formBandColorIndex = 3;
          }
          if (this.whichbutton == 70)
          {
            if (this.formDrawBand)
            {
              if (this.formBandColorIndex == 4)
                this.formDrawBand = false;
            }
            else
              this.formDrawBand = true;
            this.formBandColorIndex = 4;
          }
          if (this.whichbutton >= 40 && this.whichbutton <= 48)
          {
            this.formtagIndex = this.whichbutton - 40;
            this.sc.workshop.formTAG = this.sc.workshop.availableTAGS[this.formtagIndex];
            this.sc.drip.Play(this.sc.ev, 0.0f, 0.0f);
          }
          if (this.whichbutton == 11)
          {
            this.sc.workshop.formVisibility = this.sc.workshop.seePublic;
            this.sc.drip.Play(this.sc.ev, 0.0f, 0.0f);
          }
          if (this.whichbutton == 12)
          {
            this.sc.workshop.formVisibility = this.sc.workshop.seePrivate;
            this.sc.drip.Play(this.sc.ev, 0.0f, 0.0f);
          }
          if (this.whichbutton == 13)
          {
            this.sc.workshop.formVisibility = this.sc.workshop.seeFriends;
            this.sc.drip.Play(this.sc.ev, 0.0f, 0.0f);
          }
          if (this.whichbutton == 15)
          {
            this.sc.workshop.showPublishbox = false;
            this.sc.cancel.Play(this.sc.ev, 0.0f, 0.0f);
          }
          if (this.whichbutton == 16)
          {
            this.sc.switch2.Play(this.sc.ev * 0.2f, 0.1f, 0.0f);
            if (this.sc.workshop.status == "")
            {
              string path = "UploadData";
              if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
              using (Stream stream = (Stream) File.OpenWrite("UploadData\\dummyB.png"))
                this.sc.crosshair1[this.workshopChosen].texture.SaveAsPng(stream, this.sc.crosshair1[this.workshopChosen].texture.Width, this.sc.crosshair1[this.workshopChosen].texture.Height);
              this.sc.crossIndex = this.workshopChosen;
              this.sc.formDrawBand = this.formDrawBand;
              this.sc.formDrawBG = this.formDrawBG;
              this.sc.formBandColorIndex = this.formBandColorIndex;
              this.sc.formBGColorIndex = this.formBGColorindex;
              this.sc.takepic = 5;
              this.delayinput = true;
            }
            else
            {
              this.sc.abort.Play(this.sc.ev, -0.3f, 0.0f);
              this.sc.workshop.showPublishbox = false;
            }
          }
        }
      }
      if (this.sc.workshop.showPublishbox && this.mousePressHold && this.workshopChosen != -1)
      {
        if (this.whichbutton == 80)
        {
          this.zoomX = 0;
          this.zoomY = 0;
        }
        if (this.whichbutton == 81)
          this.zoomX -= 2;
        if (this.whichbutton == 82)
          this.zoomX += 2;
        if (this.whichbutton == 83)
          this.zoomY -= 2;
        if (this.whichbutton == 84)
          this.zoomY += 2;
        if (this.whichbutton == 85)
        {
          this.zoomX -= 2;
          this.zoomY -= 2;
        }
        if (this.whichbutton == 86)
        {
          this.zoomX += 2;
          this.zoomY += 2;
        }
        if (this.whichbutton == 87)
        {
          this.zoomX += 2;
          this.zoomY += 2;
        }
        if (this.whichbutton == 88)
        {
          this.zoomX -= 2;
          this.zoomY -= 2;
        }
        if (this.zoomX < 0)
          this.zoomX = 0;
        if (this.zoomY < 0)
          this.zoomY = 0;
        if (this.zoomX > this.sc.crosshair1[this.workshopChosen].texture.Width / 2 - 10)
          this.zoomX = this.sc.crosshair1[this.workshopChosen].texture.Width / 2 - 10;
        if (this.zoomY > this.sc.crosshair1[this.workshopChosen].texture.Height / 2 - 10)
          this.zoomY = this.sc.crosshair1[this.workshopChosen].texture.Height / 2 - 10;
      }
      if (this.mouseback || input.IsNewButtonPress(Buttons.B, this.ControllingPlayer, out this.playerindex) || input.IsMenuCancel(this.ControllingPlayer, out this.playerindex))
      {
        if (this.sc.workshop.showPublishbox)
        {
          this.sc.workshop.showPublishbox = false;
          this.delayinput = true;
          this.sc.cancel.Play(this.sc.ev, 0.0f, 0.0f);
        }
        else
        {
          this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
          this.sc.saveLoadOut();
          this.checkTrophyOnce = false;
          this.menuState = MainMenu.states.more;
          this.delayinput = true;
          this.whichbutton = 1;
        }
      }
      if (this.whichbutton != -1)
        this.lastbutton = this.whichbutton;
      if (!this.mousemoving)
        return;
      this.whichbutton = -1;
    }

    private void handleCreditwall(ref InputState input)
    {
      if (!this.mouseback && !input.IsMenuCancel(this.ControllingPlayer, out this.playerindex))
        return;
      this.whichbutton = 0;
      this.menuState = MainMenu.states.multi2player;
      this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
      this.delayinput = true;
    }

    private void handleAlphateam(ref InputState input)
    {
      if (!this.mouseback && !input.IsMenuCancel(this.ControllingPlayer, out this.playerindex))
        return;
      this.whichbutton = 0;
      this.menuState = MainMenu.states.multi4player;
      this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
      this.delayinput = true;
    }

    private void handlePlaygame(ref InputState input)
    {
      if (this.mousepress || input.IsMenuSelect(this.ControllingPlayer, out this.playerindex))
      {
        if (this.whichbutton == 0 || this.whichbutton == -1 && this.mousepress)
        {
          if (this.menuSelect == 4 && !this.sc.FarmerUnlocked)
            this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
          else if (this.menuSelect == 8 && !this.sc.man1)
            this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
          else if (this.menuSelect == 9 && !this.sc.man2)
            this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
          else if (this.menuSelect == 10 && !this.sc.man3)
            this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
          else if (this.menuSelect == 7 && !this.sc.man4)
            this.sc.abort.Play(this.sc.ev, 0.4f, 0.0f);
          else if (this.menuSelect == 6)
          {
            int num = (int) this.sc.maxDay();
            this.sc.usingMouse = this.mousepress;
            this.sc.playerindex = this.playerindex;
            if ((!this.sc.trophy.spacedeath.trophywon || !this.sc.trophy.spaceevent.trophywon ? 0 : (this.sc.trophy.walkinghere.trophywon ? 1 : 0)) == 0)
            {
              MessageBoxScreen2 screen1 = new MessageBoxScreen2("Optional Space Achievements\nUnlock All 3 Now?\n", 1);
              screen1.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
              {
                this.sc.fanfare.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
                this.sc.trophy.gimmeSpace();
                this.sc.trophy.checkAll();
              });
              screen1.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender1, e1) =>
              {
                MessageBoxScreen2 screen2 = new MessageBoxScreen2("Visit The Farm in 3019\nPlay Unpopular Space Update?\n", 1);
                screen2.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender2, e2) => this.CreateSpace(this.playerindex));
                screen2.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender3, e3) => this.delayinput = true);
                this.sc.AddScreen((GameScreen) screen2, new PlayerIndex?());
              });
              this.sc.AddScreen((GameScreen) screen1, new PlayerIndex?());
            }
            else
            {
              MessageBoxScreen2 screen = new MessageBoxScreen2("Visit The Farm in 3019\nPlay Unpopular Space Update?\n", 1);
              screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.CreateSpace(this.playerindex));
              screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
              this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
            }
            if (!this.sc.man4)
            {
              this.sc.errorMessage = "astronaut unlocked !!!";
              this.sc.errorMessageTimer = 360;
              this.sc.fanfare.Play(this.sc.ev, 0.0f, 0.0f);
              this.sc.man4 = true;
              this.sc.SaveEquipables();
            }
          }
          else
          {
            this.sc.usingMouse = this.mousepress;
            this.sc.gamestart.Play(this.sc.ev, 0.0f, 0.0f);
            this.CreateSession(this.playerindex);
          }
        }
        if (this.whichbutton == 1)
        {
          this.whichbutton = 0;
          this.menuState = MainMenu.states.main;
          this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
          this.delayinput = true;
        }
      }
      if (this.mouseback || input.IsMenuCancel(this.ControllingPlayer, out this.playerindex))
      {
        this.whichbutton = 0;
        this.menuState = MainMenu.states.main;
        this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
        this.delayinput = true;
      }
      if (input.IsMenuUp(this.ControllingPlayer) && this.menuSelect != 6 && this.menuSelect != 7)
      {
        this.lastselect = this.itemSelect;
        this.itemSelect = this.itemSelect % this.menuArray.Length >= 4 ? 10 : 9;
        this.menuSelect = this.menuArray[this.itemSelect % this.menuArray.Length];
        this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
        this.whichbutton = 0;
      }
      if (input.IsMenuDown(this.ControllingPlayer) && (this.menuSelect == 6 || this.menuSelect == 7))
      {
        this.itemSelect = this.lastselect;
        this.menuSelect = this.menuArray[this.itemSelect % this.menuArray.Length];
        this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
        this.whichbutton = 0;
      }
      if (input.IsMenuRight(this.ControllingPlayer) || input.IsNewButtonPress(Buttons.RightShoulder, this.ControllingPlayer, out this.playerindex))
      {
        ++this.itemSelect;
        this.menuSelect = this.menuArray[this.itemSelect % this.menuArray.Length];
        this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
        this.whichbutton = 0;
      }
      if (input.IsMenuLeft(this.ControllingPlayer) || input.IsNewButtonPress(Buttons.LeftShoulder, this.ControllingPlayer, out this.playerindex))
      {
        --this.itemSelect;
        if (this.itemSelect < 0)
          this.itemSelect = this.menuArray.Length;
        this.menuSelect = this.menuArray[this.itemSelect % this.menuArray.Length];
        this.sc.tick.Play(this.sc.ev, -0.1f, 0.0f);
        this.whichbutton = 0;
      }
      if (this.mousemoving)
      {
        int menuSelect = this.menuSelect;
        for (int index = 0; index <= 10; ++index)
        {
          if (index <= 5)
            this.queryButton2(new Rectangle((int) this.selectPoint[index].X, (int) this.selectPoint[index].Y, this.glow.Width, this.glow.Height), index);
          else
            this.queryButton2(new Rectangle((int) this.selectPoint[index].X, (int) this.selectPoint[index].Y, 50, 50), index);
        }
        if (menuSelect != this.menuSelect)
          this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
      }
      if (this.menuSelect == 0)
        this.sc.gameNPC = 4;
      if (this.menuSelect == 1)
        this.sc.gameNPC = 3;
      if (this.menuSelect == 2)
        this.sc.gameNPC = 0;
      if (this.menuSelect == 3)
        this.sc.gameNPC = 1;
      if (this.menuSelect == 4)
        this.sc.gameNPC = 2;
      if (this.menuSelect == 5)
        this.sc.gameNPC = 5;
      if (this.menuSelect == 7)
        this.sc.gameNPC = 10;
      if (this.menuSelect == 8)
        this.sc.gameNPC = 7;
      if (this.menuSelect == 9)
        this.sc.gameNPC = 8;
      if (this.menuSelect == 10)
        this.sc.gameNPC = 9;
      if (this.whichbutton != -1)
        this.lastbutton = this.whichbutton;
      if (!this.mousemoving)
        return;
      this.whichbutton = -1;
    }

    private void handleMultijoinStart(ref InputState input)
    {
      if (this.mousepress || input.IsMenuSelect(this.ControllingPlayer, out this.playerindex))
      {
        if (this.whichbutton == 0 || this.whichbutton == -1 && this.mousepress)
        {
          if (this.menuSelect == 4 && !this.sc.FarmerUnlocked)
            this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
          else if (this.menuSelect == 8 && !this.sc.man1)
            this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
          else if (this.menuSelect == 9 && !this.sc.man2)
            this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
          else if (this.menuSelect == 10 && !this.sc.man3)
            this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
          else if (this.menuSelect == 7 && !this.sc.man4)
            this.sc.abort.Play(this.sc.ev, 0.4f, 0.0f);
          else if (this.menuSelect == 6)
          {
            if ((!this.sc.trophy.spacedeath.trophywon || !this.sc.trophy.spaceevent.trophywon ? 0 : (this.sc.trophy.walkinghere.trophywon ? 1 : 0)) == 0)
            {
              MessageBoxScreen2 screen = new MessageBoxScreen2("Optional Space Achievements\nUnlock All 3 Now?\n", 1);
              screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
              {
                this.sc.fanfare.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
                this.sc.trophy.gimmeSpace();
                this.sc.trophy.checkAll();
              });
              screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
              {
                this.delayinput = true;
                this.sc.abort.Play(this.sc.ev, -0.2f, 0.0f);
              });
              this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
            }
            this.sc.errorMessage = "astronaut unlocked !!!";
            this.sc.errorMessageTimer = 360;
            if (!this.sc.man4)
            {
              this.sc.fanfare.Play(this.sc.ev, 0.0f, 0.0f);
              this.sc.man4 = true;
              this.sc.SaveEquipables();
            }
          }
          else if (this.sc.lobby.joinedLobby.Count > 0)
          {
            if (this.sc.lobby.lobbyPassword != "")
            {
              PlayerIndex pp = this.playerindex;
              bool usingmouse = false;
              if (this.mousepress)
                usingmouse = true;
              MessageBoxScreen2 screen = new MessageBoxScreen2("Password Please", 6, this.sc.lobby.lobbyPassword);
              screen.Approved += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
              {
                int day = this.sc.lobby.joinLobby(this.sc.lobby.joinedLobby[0]);
                if (day != 0 && day != 200 && day >= 1 && day <= 101)
                {
                  this.sc.usingMouse = usingmouse;
                  this.sc.gamestart.Play(this.sc.ev, 0.0f, 0.0f);
                  this.JoinCoopSession(pp, day);
                }
                else
                  this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
              });
              screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f));
              screen.Failed += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.sc.pigDie[0].Play(this.sc.ev, 0.0f, 0.0f));
              this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
            }
            else
            {
              int day = this.sc.lobby.joinLobby(this.sc.lobby.joinedLobby[0]);
              if (day != 0 && day != 200 && day >= 1 && day <= 101)
              {
                this.sc.usingMouse = this.mousepress;
                this.sc.gamestart.Play(this.sc.ev, 0.0f, 0.0f);
                this.JoinCoopSession(this.playerindex, day);
              }
              else
              {
                string messagex = "Cannot Join\nHost Started the Game";
                this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
                if (this.sc.lobby.lobbyState == "0")
                  messagex = "Cannot Join\nHost is not Ready";
                if (this.sc.lobby.lobbyState == "20")
                  messagex = "Cannot Join\nGame is in Progress";
                if (this.sc.lobby.lobbyState == "6")
                  messagex = "Cannot Join\nlobby is Full";
                MessageBoxScreen2 screen = new MessageBoxScreen2(messagex, 0);
                screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
                screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
                this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
              }
            }
          }
          else
            this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
        }
        if (this.whichbutton == 1)
        {
          this.sc.lobby.uncreateLobby();
          this.sc.lobby.leaveLobby();
          this.whichbutton = 0;
          this.menuState = !this.jumptomain ? MainMenu.states.cooplobby : MainMenu.states.main;
          this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
          this.delayinput = true;
        }
      }
      if (this.mouseback || input.IsMenuCancel(this.ControllingPlayer, out this.playerindex))
      {
        this.sc.lobby.uncreateLobby();
        this.sc.lobby.leaveLobby();
        this.whichbutton = 0;
        this.menuState = !this.jumptomain ? MainMenu.states.cooplobby : MainMenu.states.main;
        this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
        this.delayinput = true;
      }
      if (input.IsMenuUp(this.ControllingPlayer) && this.menuSelect != 6 && this.menuSelect != 7)
      {
        this.lastselect = this.itemSelect;
        this.itemSelect = this.itemSelect % this.menuArray.Length >= 4 ? 10 : 9;
        this.menuSelect = this.menuArray[this.itemSelect % this.menuArray.Length];
        this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
        this.whichbutton = 0;
      }
      if (input.IsMenuDown(this.ControllingPlayer) && (this.menuSelect == 6 || this.menuSelect == 7))
      {
        this.itemSelect = this.lastselect;
        this.menuSelect = this.menuArray[this.itemSelect % this.menuArray.Length];
        this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
        this.whichbutton = 0;
      }
      if (input.IsMenuRight(this.ControllingPlayer) || input.IsNewButtonPress(Buttons.RightShoulder, this.ControllingPlayer, out this.playerindex))
      {
        ++this.itemSelect;
        this.menuSelect = this.menuArray[this.itemSelect % this.menuArray.Length];
        this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
        this.whichbutton = 0;
      }
      if (input.IsMenuLeft(this.ControllingPlayer) || input.IsNewButtonPress(Buttons.LeftShoulder, this.ControllingPlayer, out this.playerindex))
      {
        --this.itemSelect;
        if (this.itemSelect < 0)
          this.itemSelect = this.menuArray.Length;
        this.menuSelect = this.menuArray[this.itemSelect % this.menuArray.Length];
        this.sc.tick.Play(this.sc.ev, -0.1f, 0.0f);
        this.whichbutton = 0;
      }
      if (this.mousemoving)
      {
        int menuSelect = this.menuSelect;
        for (int index = 0; index <= 10; ++index)
        {
          if (index <= 5)
            this.queryButton2(new Rectangle((int) this.selectPoint[index].X, (int) this.selectPoint[index].Y, this.glow.Width, this.glow.Height), index);
          else
            this.queryButton2(new Rectangle((int) this.selectPoint[index].X, (int) this.selectPoint[index].Y, 50, 50), index);
        }
        if (menuSelect != this.menuSelect)
          this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
      }
      if (this.menuSelect == 0)
        this.sc.gameNPC = 4;
      if (this.menuSelect == 1)
        this.sc.gameNPC = 3;
      if (this.menuSelect == 2)
        this.sc.gameNPC = 0;
      if (this.menuSelect == 3)
        this.sc.gameNPC = 1;
      if (this.menuSelect == 4)
        this.sc.gameNPC = 2;
      if (this.menuSelect == 5)
        this.sc.gameNPC = 5;
      if (this.menuSelect == 7)
        this.sc.gameNPC = 10;
      if (this.menuSelect == 8)
        this.sc.gameNPC = 7;
      if (this.menuSelect == 9)
        this.sc.gameNPC = 8;
      if (this.menuSelect == 10)
        this.sc.gameNPC = 9;
      if (this.whichbutton != -1)
        this.lastbutton = this.whichbutton;
      if (!this.mousemoving)
        return;
      this.whichbutton = -1;
    }

    private void handleMultiHostStart(ref InputState input)
    {
      if (this.mousepress || input.IsMenuSelect(this.ControllingPlayer, out this.playerindex))
      {
        if (this.whichbutton == 0 || this.whichbutton == -1 && this.mousepress)
        {
          if (this.menuSelect == 4 && !this.sc.FarmerUnlocked)
            this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
          else if (this.menuSelect == 8 && !this.sc.man1)
            this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
          else if (this.menuSelect == 9 && !this.sc.man2)
            this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
          else if (this.menuSelect == 10 && !this.sc.man3)
            this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
          else if (this.menuSelect == 7 && !this.sc.man4)
            this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
          else if (this.menuSelect == 6)
          {
            if ((!this.sc.trophy.spacedeath.trophywon || !this.sc.trophy.spaceevent.trophywon ? 0 : (this.sc.trophy.walkinghere.trophywon ? 1 : 0)) == 0)
            {
              MessageBoxScreen2 screen = new MessageBoxScreen2("Optional Space Achievements\nUnlock All 3 Now?\n", 1);
              screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
              {
                this.sc.fanfare.Play(this.sc.ev * 0.5f, 0.0f, 0.0f);
                this.sc.trophy.gimmeSpace();
                this.sc.trophy.checkAll();
              });
              screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
              {
                this.delayinput = true;
                this.sc.abort.Play(this.sc.ev, -0.2f, 0.0f);
              });
              this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
            }
            this.sc.errorMessage = "astronaut unlocked !!!";
            this.sc.errorMessageTimer = 360;
            if (!this.sc.man4)
            {
              this.sc.fanfare.Play(this.sc.ev, 0.0f, 0.0f);
              this.sc.man4 = true;
              this.sc.SaveEquipables();
            }
          }
          else if (this.menuSelect == 11)
          {
            MessageBoxScreen2 screen = new MessageBoxScreen2("Enter Password", 7);
            screen.Approved += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
            {
              this.sc.harp2.Play(this.sc.ev, 0.2f, 0.0f);
              if (this.sc.lobby.createdLobby.Count > 0)
                this.sc.lobby.setPassword(this.sc.lobby.createdLobby[0]);
              this.delayinput = true;
            });
            screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
            this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
          }
          else
          {
            this.sc.usingMouse = this.mousepress;
            this.sc.gamestart.Play(this.sc.ev, 0.0f, 0.0f);
            this.CreateCoopSession(this.playerindex);
          }
        }
        if (this.whichbutton == 1)
        {
          this.sc.lobby.uncreateLobby();
          this.sc.lobby.leaveLobby();
          this.whichbutton = 0;
          this.menuState = MainMenu.states.main;
          if (this.lobbynum == "2")
            this.menuState = MainMenu.states.multi2player;
          if (this.lobbynum == "4")
            this.menuState = MainMenu.states.multi4player;
          if (this.lobbynum == "3")
            this.menuState = MainMenu.states.multi3player;
          if (this.lobbynum == "6")
            this.menuState = MainMenu.states.multi6player;
          this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
          this.delayinput = true;
        }
      }
      if (this.mouseback || input.IsMenuCancel(this.ControllingPlayer, out this.playerindex))
      {
        this.sc.lobby.uncreateLobby();
        this.sc.lobby.leaveLobby();
        this.whichbutton = 0;
        this.menuState = MainMenu.states.main;
        if (this.lobbynum == "2")
          this.menuState = MainMenu.states.multi2player;
        if (this.lobbynum == "4")
          this.menuState = MainMenu.states.multi4player;
        if (this.lobbynum == "3")
          this.menuState = MainMenu.states.multi3player;
        if (this.lobbynum == "6")
          this.menuState = MainMenu.states.multi6player;
        this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
        this.delayinput = true;
      }
      if (input.IsMenuUp(this.ControllingPlayer) && this.menuSelect != 6 && this.menuSelect != 7)
      {
        this.lastselect = this.itemSelect;
        this.itemSelect = this.itemSelect % this.menuArray.Length >= 4 ? 10 : 9;
        this.menuSelect = this.menuArray[this.itemSelect % this.menuArray.Length];
        this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
        this.whichbutton = 0;
      }
      if (input.IsMenuDown(this.ControllingPlayer) && (this.menuSelect == 6 || this.menuSelect == 7))
      {
        this.itemSelect = this.lastselect;
        this.menuSelect = this.menuArray[this.itemSelect % this.menuArray.Length];
        this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
        this.whichbutton = 0;
      }
      if (input.IsMenuRight(this.ControllingPlayer) || input.IsNewButtonPress(Buttons.RightShoulder, this.ControllingPlayer, out this.playerindex))
      {
        ++this.itemSelect;
        this.menuSelect = this.menuArray[this.itemSelect % this.menuArray.Length];
        this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
        this.whichbutton = 0;
      }
      if (input.IsMenuLeft(this.ControllingPlayer) || input.IsNewButtonPress(Buttons.LeftShoulder, this.ControllingPlayer, out this.playerindex))
      {
        --this.itemSelect;
        if (this.itemSelect < 0)
          this.itemSelect = this.menuArray.Length;
        this.menuSelect = this.menuArray[this.itemSelect % this.menuArray.Length];
        this.sc.tick.Play(this.sc.ev, -0.1f, 0.0f);
        this.whichbutton = 0;
      }
      if (this.mousemoving)
      {
        int menuSelect = this.menuSelect;
        for (int index = 0; index <= 11; ++index)
        {
          if (index <= 5)
          {
            this.queryButton2(new Rectangle((int) this.selectPoint[index].X, (int) this.selectPoint[index].Y, this.glow.Width, this.glow.Height), index);
          }
          else
          {
            Rectangle rr = new Rectangle((int) this.selectPoint[index].X, (int) this.selectPoint[index].Y, 50, 50);
            if (index == 11)
            {
              rr.Width = 233;
              rr.Height = 40;
            }
            this.queryButton2(rr, index);
          }
        }
        if (menuSelect != this.menuSelect)
          this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
      }
      if (this.menuSelect == 0)
        this.sc.gameNPC = 4;
      if (this.menuSelect == 1)
        this.sc.gameNPC = 3;
      if (this.menuSelect == 2)
        this.sc.gameNPC = 0;
      if (this.menuSelect == 3)
        this.sc.gameNPC = 1;
      if (this.menuSelect == 4)
        this.sc.gameNPC = 2;
      if (this.menuSelect == 5)
        this.sc.gameNPC = 5;
      if (this.menuSelect == 7)
        this.sc.gameNPC = 10;
      if (this.menuSelect == 8)
        this.sc.gameNPC = 7;
      if (this.menuSelect == 9)
        this.sc.gameNPC = 8;
      if (this.menuSelect == 10)
        this.sc.gameNPC = 9;
      if (this.whichbutton != -1)
        this.lastbutton = this.whichbutton;
      if (!this.mousemoving)
        return;
      this.whichbutton = -1;
    }

    private void handleDisplay(ref InputState input)
    {
      if (this.mouseback || input.IsNewButtonPress(Buttons.B, this.ControllingPlayer, out this.playerindex) || input.IsMenuCancel(this.ControllingPlayer, out this.playerindex))
      {
        this.menuState = MainMenu.states.controls;
        this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
        this.delayinput = true;
        this.showHelp = false;
        this.showGamepad = false;
        this.showInstruct = false;
      }
      if (this.whichbutton != -1)
        this.lastbutton = this.whichbutton;
      if (!this.mousemoving)
        return;
      this.whichbutton = -1;
    }

    private void handleSettings(ref InputState input)
    {
      this.selectOneExclusive(0, 2, input);
      if (this.mousepress || input.IsMenuSelect(this.ControllingPlayer, out this.playerindex))
      {
        if (this.whichbutton == 0)
        {
          this.whichbutton = 0;
          this.menuState = MainMenu.states.audio;
          this.lastState2 = MainMenu.states.settings;
          this.sc.switch2.Play(this.sc.ev * 0.2f, 0.1f, 0.0f);
          this.slider1 = (int) Math.Round(Math.Sqrt((double) this.sc.mv * 100.0));
          this.slider2 = (int) Math.Round(Math.Sqrt((double) this.sc.ev * 100.0));
          this.slider3 = (int) Math.Round(Math.Sqrt((double) this.sc.vv * 100.0));
          this.slider1 = (int) MathHelper.Clamp((float) this.slider1, 0.0f, 10f);
          this.slider2 = (int) MathHelper.Clamp((float) this.slider2, 0.0f, 10f);
          this.slider3 = (int) MathHelper.Clamp((float) this.slider3, 0.0f, 10f);
          this.sliderbox1 = (float) ((double) this.slider1 * 31.399999618530273 - 157.0);
          this.sliderbox2 = (float) ((double) this.slider2 * 31.399999618530273 - 157.0);
          this.sliderbox3 = (float) ((double) this.slider3 * 31.399999618530273 - 157.0);
          this.myIndex = -1;
        }
        if (this.whichbutton == 1 && !this.sc.lockVideosetup)
        {
          this.whichbutton = 0;
          this.sc.setupnum = this.sc.resolution;
          this.sc.aa = this.sc.aliasing;
          this.menuState = MainMenu.states.graphics;
          this.lastState2 = MainMenu.states.settings;
          this.sc.switch2.Play(this.sc.ev * 0.2f, 0.1f, 0.0f);
        }
        if (this.whichbutton == 2)
        {
          this.whichbutton = 0;
          this.menuState = MainMenu.states.controls;
          this.lastState2 = MainMenu.states.settings;
          this.sc.switch2.Play(this.sc.ev * 0.2f, 0.2f, 0.0f);
        }
        if (this.whichbutton == 3)
        {
          this.whichbutton = 0;
          this.menuState = MainMenu.states.main;
          this.sc.switch2.Play(this.sc.ev * 0.2f, 0.2f, 0.0f);
        }
        if (this.whichbutton == 4)
        {
          this.sc.pigSqueal[this.rr.Next(0, 4)].Play(this.sc.ev, (float) this.rr.Next(-80, 80) / 100f, (float) this.rr.Next(-80, 80) / 100f);
          ++this.pigcount;
          this.pigcount %= 20;
          ++this.pigwalk;
          if (this.pigwalk > 10)
          {
            this.pigwalk = 505;
            if (!this.sc.star1)
            {
              this.sc.harp2.Play(this.sc.ev, 0.0f, 0.0f);
              MessageBoxScreen2 screen = new MessageBoxScreen2("Secret Star\n", 9);
              screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
              screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
              this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
              this.delayinput = true;
            }
            this.sc.star1 = true;
            this.sc.SavePrefs();
          }
        }
      }
      this.backtomain(input, 2);
      if (this.whichbutton != -1)
        this.lastbutton = this.whichbutton;
      if (!this.mousemoving)
        return;
      this.whichbutton = -1;
    }

    private void handleCoopChoice(ref InputState input)
    {
      this.selectOneExclusive(0, 2, input);
      if (this.mousepress || input.IsMenuSelect(this.ControllingPlayer, out this.playerindex))
      {
        if (this.whichbutton == 0)
        {
          this.sc.switch2.Play(this.sc.ev * 0.2f, 0.1f, 0.0f);
          this.whichbutton = 0;
          MessageBoxScreen2 screen = new MessageBoxScreen2("Enter Your Name", 4);
          screen.Approved += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
          {
            this.sc.SavePrefs();
            this.whichbutton = 0;
            this.menuState = MainMenu.states.multi2player;
            this.sc.switch2.Play(this.sc.ev * 0.2f, 0.2f, 0.0f);
            this.delayinput = true;
          });
          screen.Failed += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
          {
            this.sc.pigDie[0].Play(this.sc.ev, 0.0f, 0.0f);
            this.delayinput = true;
          });
          screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
          this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
        }
        if (this.whichbutton == 1)
        {
          this.whichbutton = 0;
          this.sc.harp2.Play(this.sc.ev * 0.6f, -0.2f, 0.0f);
          MessageBoxScreen2 screen = new MessageBoxScreen2("Enter Your Name", 4);
          screen.Approved += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
          {
            this.sc.SavePrefs();
            this.whichbutton = 0;
            this.menuState = MainMenu.states.multi4player;
            this.sc.switch2.Play(this.sc.ev * 0.2f, 0.2f, 0.0f);
            this.delayinput = true;
          });
          screen.Failed += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
          {
            this.sc.pigDie[0].Play(this.sc.ev, 0.0f, 0.0f);
            this.delayinput = true;
          });
          screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
          this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
        }
        if (this.whichbutton == 2)
        {
          this.whichbutton = 0;
          this.sc.harp2.Play(this.sc.ev * 0.6f, -0.2f, 0.0f);
          MessageBoxScreen2 screen = new MessageBoxScreen2("Enter Your Name", 4);
          screen.Approved += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
          {
            this.sc.SavePrefs();
            this.whichbutton = 0;
            this.menuState = MainMenu.states.multi6player;
            this.sc.switch2.Play(this.sc.ev * 0.2f, 0.2f, 0.0f);
            this.delayinput = true;
          });
          screen.Failed += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
          {
            this.sc.pigDie[0].Play(this.sc.ev, 0.0f, 0.0f);
            this.delayinput = true;
          });
          screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
          this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
        }
        if (this.whichbutton == 3)
        {
          this.whichbutton = 0;
          this.menuState = MainMenu.states.main;
          this.sc.switch2.Play(this.sc.ev * 0.2f, 0.2f, 0.0f);
        }
      }
      this.backtomain(input, 1);
      if (this.whichbutton != -1)
        this.lastbutton = this.whichbutton;
      if (!this.mousemoving)
        return;
      this.whichbutton = -1;
    }

    private void method_0(ref InputState input)
    {
      this.selectOneExclusive(0, 2, input);
      if (this.mousepress || input.IsMenuSelect(this.ControllingPlayer, out this.playerindex))
      {
        if (this.whichbutton == 0)
        {
          this.whichbutton = 0;
          this.sc.lobby.password = "";
          this.lobbynum = "2";
          this.menuState = MainMenu.states.multiHostStart;
          this.sc.lobby.createLobby(2);
          this.sc.switch2.Play(this.sc.ev * 0.2f, 0.1f, 0.0f);
        }
        if (this.whichbutton == 1)
        {
          this.sc.switch2.Play(this.sc.ev * 0.2f, 0.2f, 0.0f);
          this.whichbutton = 0;
          this.menuState = MainMenu.states.cooplobby;
          this.whichKEY = 0;
          this.sc.lobby.lobbys.Clear();
          this.lobbynum = "2";
          this.sc.lobby.requestLobby("2");
        }
        if (this.whichbutton == 2)
        {
          this.whichbutton = 1;
          this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
          this.menuState = MainMenu.states.main;
        }
        if (this.whichbutton == 7)
        {
          this.sc.harp2.Play(this.sc.ev * 0.6f, 0.4f, 0.0f);
          this.whichbutton = 0;
          this.menuState = MainMenu.states.creditwall;
          this.sc.switch2.Play(this.sc.ev * 0.2f, 0.2f, 0.0f);
        }
      }
      this.backtomain(input, 1);
      if (this.whichbutton != -1)
        this.lastbutton = this.whichbutton;
      if (!this.mousemoving)
        return;
      this.whichbutton = -1;
    }

    private void method_1(ref InputState input)
    {
      this.selectOneExclusive(0, 2, input);
      if (this.mousepress || input.IsMenuSelect(this.ControllingPlayer, out this.playerindex))
      {
        if (this.whichbutton == 0)
        {
          this.whichbutton = 0;
          this.sc.lobby.password = "";
          this.lobbynum = "3";
          this.menuState = MainMenu.states.multiHostStart;
          this.sc.lobby.createLobby(3);
          this.sc.switch2.Play(this.sc.ev * 0.2f, 0.1f, 0.0f);
        }
        if (this.whichbutton == 1)
        {
          this.sc.switch2.Play(this.sc.ev * 0.2f, 0.2f, 0.0f);
          this.whichbutton = 0;
          this.menuState = MainMenu.states.cooplobby;
          this.whichKEY = 0;
          this.sc.lobby.lobbys.Clear();
          this.lobbynum = "3";
          this.sc.lobby.requestLobby("3");
        }
        if (this.whichbutton == 2)
        {
          this.whichbutton = 1;
          this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
          this.menuState = MainMenu.states.main;
        }
      }
      this.backtomain(input, 1);
      if (this.whichbutton != -1)
        this.lastbutton = this.whichbutton;
      if (!this.mousemoving)
        return;
      this.whichbutton = -1;
    }

    private void method_2(ref InputState input)
    {
      this.selectOneExclusive(0, 2, input);
      if (this.mousepress || input.IsMenuSelect(this.ControllingPlayer, out this.playerindex))
      {
        if (this.whichbutton == 0)
        {
          this.whichbutton = 0;
          this.sc.lobby.password = "";
          this.lobbynum = "4";
          this.menuState = MainMenu.states.multiHostStart;
          this.sc.lobby.createLobby(4);
          this.sc.switch2.Play(this.sc.ev * 0.2f, 0.1f, 0.0f);
        }
        if (this.whichbutton == 1)
        {
          this.sc.switch2.Play(this.sc.ev * 0.2f, 0.2f, 0.0f);
          this.whichbutton = 0;
          this.menuState = MainMenu.states.cooplobby;
          this.whichKEY = 0;
          this.sc.lobby.lobbys.Clear();
          this.lobbynum = "4";
          this.sc.lobby.requestLobby("4");
        }
        if (this.whichbutton == 2)
        {
          this.whichbutton = 1;
          this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
          this.menuState = MainMenu.states.main;
        }
        if (this.whichbutton == 7)
        {
          if (this.sc.developer)
          {
            this.whichbutton = 0;
            this.sc.lobby.password = "";
            this.lobbynum = "4";
            this.menuState = MainMenu.states.multiHostStart;
            this.sc.lobby.createLobby(44);
          }
          else
          {
            this.sc.harp2.Play(this.sc.ev * 0.6f, 0.4f, 0.0f);
            this.whichbutton = 0;
            this.menuState = MainMenu.states.alphateam;
            this.sc.switch2.Play(this.sc.ev * 0.2f, 0.2f, 0.0f);
          }
        }
      }
      this.backtomain(input, 1);
      if (this.whichbutton != -1)
        this.lastbutton = this.whichbutton;
      if (!this.mousemoving)
        return;
      this.whichbutton = -1;
    }

    private void method_3(ref InputState input)
    {
      this.selectOneExclusive(0, 2, input);
      if (this.mousepress || input.IsMenuSelect(this.ControllingPlayer, out this.playerindex))
      {
        if (this.whichbutton == 0)
        {
          this.whichbutton = 0;
          this.sc.lobby.password = "";
          this.lobbynum = "6";
          this.menuState = MainMenu.states.multiHostStart;
          this.sc.lobby.createLobby(6);
          this.sc.switch2.Play(this.sc.ev * 0.2f, 0.1f, 0.0f);
        }
        if (this.whichbutton == 1)
        {
          this.sc.switch2.Play(this.sc.ev * 0.2f, 0.2f, 0.0f);
          this.whichbutton = 0;
          this.menuState = MainMenu.states.cooplobby;
          this.whichKEY = 0;
          this.sc.lobby.lobbys.Clear();
          this.lobbynum = "6";
          this.sc.lobby.requestLobby("6");
        }
        if (this.whichbutton == 2)
        {
          this.whichbutton = 1;
          this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
          this.menuState = MainMenu.states.main;
        }
      }
      this.backtomain(input, 1);
      if (this.whichbutton != -1)
        this.lastbutton = this.whichbutton;
      if (!this.mousemoving)
        return;
      this.whichbutton = -1;
    }

    private void handleControls(ref InputState input)
    {
      this.selectOneExclusive(0, 3, input);
      if (this.mousepress || input.IsMenuSelect(this.ControllingPlayer, out this.playerindex))
      {
        if (this.whichbutton == 0)
        {
          this.showHelp = true;
          this.sc.switch2.Play(this.sc.ev * 0.2f, 0.1f, 0.0f);
          this.sc.trophy.win(this.sc.trophy.aptpupil);
          this.menuState = MainMenu.states.displaykeys;
          this.sc.LoadSavedKeys();
          this.thisKEY = 0;
          this.whichKEY = 0;
        }
        if (this.whichbutton == 1)
        {
          this.showInstruct = true;
          this.sc.switch2.Play(this.sc.ev * 0.2f, 0.1f, 0.0f);
          this.sc.trophy.win(this.sc.trophy.aptpupil);
          this.menuState = MainMenu.states.display;
        }
        if (this.whichbutton == 2)
        {
          this.showGamepad = true;
          this.sc.switch2.Play(this.sc.ev * 0.2f, 0.1f, 0.0f);
          this.sc.trophy.win(this.sc.trophy.aptpupil);
          this.menuState = MainMenu.states.display;
        }
        if (this.whichbutton == 3)
        {
          this.whichbutton = 1;
          this.menuState = MainMenu.states.settings;
          this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
          this.delayinput = true;
        }
      }
      if (this.mouseback || input.IsNewButtonPress(Buttons.B, this.ControllingPlayer, out this.playerindex) || input.IsMenuCancel(this.ControllingPlayer, out this.playerindex))
      {
        this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
        this.menuState = this.lastState2;
        this.delayinput = true;
        this.whichbutton = 1;
      }
      if (this.whichbutton != -1)
        this.lastbutton = this.whichbutton;
      if (!this.mousemoving)
        return;
      this.whichbutton = -1;
    }

    private void handleDisplaykeys(ref InputState input)
    {
      if (this.thisKEY != 0 && (this.mousepress || this.mouseback || this.mousemiddle || this.mousenum1 || this.mousenum2) && this.thisKEY == this.whichKEY)
      {
        Microsoft.Xna.Framework.Input.Keys keys = Microsoft.Xna.Framework.Input.Keys.VolumeUp;
        if (this.mousepress)
          keys = Microsoft.Xna.Framework.Input.Keys.VolumeDown;
        if (this.mouseback)
          keys = Microsoft.Xna.Framework.Input.Keys.VolumeUp;
        if (this.mousemiddle)
          keys = Microsoft.Xna.Framework.Input.Keys.VolumeMute;
        if (this.mousenum1)
          keys = Microsoft.Xna.Framework.Input.Keys.Print;
        if (this.mousenum2)
          keys = Microsoft.Xna.Framework.Input.Keys.PrintScreen;
        if (this.thisKEY == 2)
        {
          this.sc.lmb_key = keys;
          this.thisKEY = 0;
        }
        if (this.thisKEY == 3)
        {
          this.sc.rmb_key = keys;
          this.thisKEY = 0;
        }
        if (this.thisKEY == 9)
        {
          this.sc.space_key = keys;
          this.thisKEY = 0;
        }
        if (this.thisKEY == 5)
        {
          this.sc.w_key = keys;
          this.thisKEY = 0;
        }
        if (this.thisKEY == 6)
        {
          this.sc.s_key = keys;
          this.thisKEY = 0;
        }
        if (this.thisKEY == 10)
        {
          this.sc.leftshift_key = keys;
          this.thisKEY = 0;
        }
        if (this.thisKEY == 11)
        {
          this.sc.r_key = keys;
          this.thisKEY = 0;
        }
        if (this.thisKEY == 12)
        {
          this.sc.x_key = keys;
          this.thisKEY = 0;
        }
        if (this.thisKEY == 13)
        {
          this.sc.q_key = keys;
          this.thisKEY = 0;
        }
        if (this.thisKEY == 14)
        {
          this.sc.e_key = keys;
          this.thisKEY = 0;
        }
        if (this.thisKEY == 28)
        {
          this.sc.enter_key = keys;
          this.thisKEY = 0;
        }
        if (this.thisKEY == 27)
        {
          this.sc.t_key = keys;
          this.thisKEY = 0;
        }
        if (this.thisKEY == 29)
        {
          this.sc.plus_key = keys;
          this.thisKEY = 0;
        }
      }
      if (this.thisKEY != 0 && this.pressedKeys.Length > 0)
      {
        if (this.thisKEY == 1)
        {
          this.sc.escape_key = this.pressedKeys[0];
          this.thisKEY = 0;
        }
        if (this.thisKEY == 2)
        {
          this.sc.lmb_key = this.pressedKeys[0];
          this.thisKEY = 0;
        }
        if (this.thisKEY == 3)
        {
          this.sc.rmb_key = this.pressedKeys[0];
          this.thisKEY = 0;
        }
        if (this.thisKEY == 5)
        {
          this.sc.w_key = this.pressedKeys[0];
          this.thisKEY = 0;
        }
        if (this.thisKEY == 6)
        {
          this.sc.s_key = this.pressedKeys[0];
          this.thisKEY = 0;
        }
        if (this.thisKEY == 7)
        {
          this.sc.a_key = this.pressedKeys[0];
          this.thisKEY = 0;
        }
        if (this.thisKEY == 8)
        {
          this.sc.d_key = this.pressedKeys[0];
          this.thisKEY = 0;
        }
        if (this.thisKEY == 9)
        {
          this.sc.space_key = this.pressedKeys[0];
          this.thisKEY = 0;
        }
        if (this.thisKEY == 10)
        {
          this.sc.leftshift_key = this.pressedKeys[0];
          this.thisKEY = 0;
        }
        if (this.thisKEY == 11)
        {
          this.sc.r_key = this.pressedKeys[0];
          this.thisKEY = 0;
        }
        if (this.thisKEY == 12)
        {
          this.sc.x_key = this.pressedKeys[0];
          this.thisKEY = 0;
        }
        if (this.thisKEY == 13)
        {
          this.sc.q_key = this.pressedKeys[0];
          this.thisKEY = 0;
        }
        if (this.thisKEY == 14)
        {
          this.sc.e_key = this.pressedKeys[0];
          this.thisKEY = 0;
        }
        if (this.thisKEY == 15)
        {
          this.sc.f_key = this.pressedKeys[0];
          this.thisKEY = 0;
        }
        if (this.thisKEY == 16)
        {
          this.sc.one_key = this.pressedKeys[0];
          this.thisKEY = 0;
        }
        if (this.thisKEY == 17)
        {
          this.sc.two_key = this.pressedKeys[0];
          this.thisKEY = 0;
        }
        if (this.thisKEY == 18)
        {
          this.sc.three_key = this.pressedKeys[0];
          this.thisKEY = 0;
        }
        if (this.thisKEY == 19)
        {
          this.sc.four_key = this.pressedKeys[0];
          this.thisKEY = 0;
        }
        if (this.thisKEY == 20)
        {
          this.sc.f1_key = this.pressedKeys[0];
          this.thisKEY = 0;
        }
        if (this.thisKEY == 21)
        {
          this.sc.f2_key = this.pressedKeys[0];
          this.thisKEY = 0;
        }
        if (this.thisKEY == 22)
        {
          this.sc.f3_key = this.pressedKeys[0];
          this.thisKEY = 0;
        }
        if (this.thisKEY == 23)
        {
          this.sc.tab_key = this.pressedKeys[0];
          this.thisKEY = 0;
        }
        if (this.thisKEY == 24)
        {
          this.sc.up_key = this.pressedKeys[0];
          this.thisKEY = 0;
        }
        if (this.thisKEY == 25)
        {
          this.sc.down_key = this.pressedKeys[0];
          this.thisKEY = 0;
        }
        if (this.thisKEY == 26)
        {
          this.sc.left_key = this.pressedKeys[0];
          this.thisKEY = 0;
        }
        if (this.thisKEY == 27)
        {
          this.sc.t_key = this.pressedKeys[0];
          this.thisKEY = 0;
        }
        if (this.thisKEY == 28)
        {
          this.sc.enter_key = this.pressedKeys[0];
          this.thisKEY = 0;
        }
        if (this.thisKEY == 29)
        {
          this.sc.plus_key = this.pressedKeys[0];
          this.thisKEY = 0;
        }
      }
      if (this.mousepress || input.IsMenuSelect(this.ControllingPlayer, out this.playerindex))
      {
        if (this.whichKEY == 4)
        {
          this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
          this.thisKEY = 0;
        }
        if (this.whichKEY == 30)
        {
          this.sc.SaveSavedKeys();
          this.sc.getXkey();
          this.sc.harp2.Play(this.sc.ev * 0.4f, 0.0f, 0.0f);
          this.thisKEY = 0;
        }
        if (this.whichKEY == 33)
        {
          this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
          this.thisKEY = 0;
          this.sc.rmb_key = Microsoft.Xna.Framework.Input.Keys.VolumeUp;
          this.sc.lmb_key = Microsoft.Xna.Framework.Input.Keys.VolumeDown;
          this.sc.mmb_key = Microsoft.Xna.Framework.Input.Keys.VolumeMute;
          this.sc.but1_key = Microsoft.Xna.Framework.Input.Keys.Print;
          this.sc.but2_key = Microsoft.Xna.Framework.Input.Keys.PrintScreen;
          this.sc.escape_key = Microsoft.Xna.Framework.Input.Keys.Escape;
          this.sc.w_key = Microsoft.Xna.Framework.Input.Keys.W;
          this.sc.a_key = Microsoft.Xna.Framework.Input.Keys.A;
          this.sc.s_key = Microsoft.Xna.Framework.Input.Keys.S;
          this.sc.d_key = Microsoft.Xna.Framework.Input.Keys.D;
          this.sc.f_key = Microsoft.Xna.Framework.Input.Keys.F;
          this.sc.q_key = Microsoft.Xna.Framework.Input.Keys.Q;
          this.sc.e_key = Microsoft.Xna.Framework.Input.Keys.E;
          this.sc.x_key = Microsoft.Xna.Framework.Input.Keys.X;
          this.sc.r_key = Microsoft.Xna.Framework.Input.Keys.R;
          this.sc.up_key = Microsoft.Xna.Framework.Input.Keys.Up;
          this.sc.down_key = Microsoft.Xna.Framework.Input.Keys.Down;
          this.sc.left_key = Microsoft.Xna.Framework.Input.Keys.Left;
          this.sc.space_key = Microsoft.Xna.Framework.Input.Keys.Space;
          this.sc.one_key = Microsoft.Xna.Framework.Input.Keys.D1;
          this.sc.two_key = Microsoft.Xna.Framework.Input.Keys.D2;
          this.sc.three_key = Microsoft.Xna.Framework.Input.Keys.D3;
          this.sc.four_key = Microsoft.Xna.Framework.Input.Keys.D4;
          this.sc.tab_key = Microsoft.Xna.Framework.Input.Keys.Tab;
          this.sc.f1_key = Microsoft.Xna.Framework.Input.Keys.F1;
          this.sc.f2_key = Microsoft.Xna.Framework.Input.Keys.F2;
          this.sc.f3_key = Microsoft.Xna.Framework.Input.Keys.F3;
          this.sc.leftshift_key = Microsoft.Xna.Framework.Input.Keys.LeftShift;
          this.sc.t_key = Microsoft.Xna.Framework.Input.Keys.T;
          this.sc.enter_key = Microsoft.Xna.Framework.Input.Keys.Enter;
          this.sc.plus_key = Microsoft.Xna.Framework.Input.Keys.OemPlus;
        }
        if (this.whichKEY == 36)
        {
          this.menuState = MainMenu.states.controls;
          this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
          this.delayinput = true;
          this.showHelp = false;
          this.whichbutton = 0;
        }
        this.thisKEY = this.whichKEY != 2 || this.whichKEY != 3 || this.whichKEY != 4 || this.whichKEY != 30 || this.whichKEY != 33 || this.whichKEY != 36 ? (this.thisKEY != this.whichKEY ? this.whichKEY : 0) : 0;
      }
      if (this.mouseback && this.whichKEY == 0 || input.IsNewButtonPress(Buttons.B, this.ControllingPlayer, out this.playerindex))
      {
        this.menuState = MainMenu.states.controls;
        this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
        this.delayinput = true;
        this.showHelp = false;
      }
      if (!this.mouseback || this.thisKEY != 0)
        return;
      this.whichKEY = 0;
    }

    private void handleAudio(ref InputState input)
    {
      if (this.whichbutton < 2)
        this.selectOneExclusive(0, 1, input);
      if (input.IsMenuUp(this.ControllingPlayer))
      {
        --this.whichbutton;
        if (this.whichbutton < 2)
          this.whichbutton = 2;
        this.sc.tick.Play(this.sc.ev, 0.2f, 0.0f);
      }
      if (input.IsMenuDown(this.ControllingPlayer))
      {
        ++this.whichbutton;
        if (this.whichbutton < 2)
          this.whichbutton = 2;
        if (this.whichbutton > 4)
          this.whichbutton = 4;
        this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
      }
      if (input.IsMenuRight(this.ControllingPlayer) || input.IsMenuLeft(this.ControllingPlayer))
      {
        float num = 31.4f;
        if (input.IsMenuLeft(this.ControllingPlayer))
          num = -31.4f;
        if (this.whichbutton == 2)
        {
          this.sliderbox1 += num;
          this.sliderbox1 = MathHelper.Clamp(this.sliderbox1, -157f, 157f);
          if (this.slider1 != (int) (((double) this.sliderbox1 + 157.0) / 31.399999618530273))
            this.sc.tick.Play(0.8f, MathHelper.Clamp((float) ((double) this.slider1 / 10.0 - 0.5), -1f, 1f), 0.0f);
          this.slider1 = (int) (((double) this.sliderbox1 + 157.0) / 31.399999618530273);
          this.sc.mv = (float) (this.slider1 * this.slider1) / 100f;
          this.menuMusic.Volume = this.sc.mv;
        }
        if (this.whichbutton == 3)
        {
          this.sliderbox2 += num;
          this.sliderbox2 = MathHelper.Clamp(this.sliderbox2, -157f, 157f);
          if (this.slider2 != (int) (((double) this.sliderbox2 + 157.0) / 31.399999618530273))
            this.sc.tick.Play(0.8f, MathHelper.Clamp((float) ((double) this.slider2 / 10.0 - 0.5), -1f, 1f), 0.0f);
          this.slider2 = (int) (((double) this.sliderbox2 + 157.0) / 31.399999618530273);
          this.sc.ev = (float) (this.slider2 * this.slider2) / 100f;
        }
        if (this.whichbutton == 4)
        {
          this.sliderbox3 += num;
          this.sliderbox3 = MathHelper.Clamp(this.sliderbox3, -157f, 157f);
          if (this.slider3 != (int) (((double) this.sliderbox3 + 157.0) / 31.399999618530273))
            this.sc.tick.Play(0.8f, MathHelper.Clamp((float) ((double) this.slider3 / 10.0 - 0.5), -1f, 1f), 0.0f);
          this.slider3 = (int) (((double) this.sliderbox3 + 157.0) / 31.399999618530273);
          this.sc.vv = (float) (this.slider3 * this.slider3) / 100f;
        }
      }
      if (this.myIndex == 0)
      {
        if (this.mousepress)
        {
          this.origMouseX = this.adjustMouse().X;
          this.float_0 = this.sliderbox1;
        }
        if (this.mousePressHold)
        {
          this.sliderbox1 = this.float_0 + (this.adjustMouse().X - this.origMouseX);
          this.sliderbox1 = MathHelper.Clamp(this.sliderbox1, -157f, 157f);
          if (this.slider1 != (int) (((double) this.sliderbox1 + 157.0) / 31.399999618530273))
            this.sc.tick.Play(0.8f, MathHelper.Clamp((float) ((double) this.slider1 / 10.0 - 0.5), -1f, 1f), 0.0f);
          this.slider1 = (int) (((double) this.sliderbox1 + 157.0) / 31.399999618530273);
          this.sc.mv = (float) (this.slider1 * this.slider1) / 100f;
          this.menuMusic.Volume = this.sc.mv;
        }
      }
      if (this.myIndex == 1)
      {
        if (this.mousepress)
        {
          this.origMouseX = this.adjustMouse().X;
          this.float_1 = this.sliderbox2;
        }
        if (this.mousePressHold)
        {
          this.sliderbox2 = this.float_1 + (this.adjustMouse().X - this.origMouseX);
          this.sliderbox2 = MathHelper.Clamp(this.sliderbox2, -157f, 157f);
          if (this.slider2 != (int) (((double) this.sliderbox2 + 157.0) / 31.399999618530273))
            this.sc.tick.Play(0.8f, MathHelper.Clamp((float) ((double) this.slider2 / 10.0 - 0.5), -1f, 1f), 0.0f);
          this.slider2 = (int) (((double) this.sliderbox2 + 157.0) / 31.399999618530273);
          this.sc.ev = (float) (this.slider2 * this.slider2) / 100f;
        }
      }
      if (this.myIndex == 2)
      {
        if (this.mousepress)
        {
          this.origMouseX = this.adjustMouse().X;
          this.float_2 = this.sliderbox3;
        }
        if (this.mousePressHold)
        {
          this.sliderbox3 = this.float_2 + (this.adjustMouse().X - this.origMouseX);
          this.sliderbox3 = MathHelper.Clamp(this.sliderbox3, -157f, 157f);
          if (this.slider3 != (int) (((double) this.sliderbox3 + 157.0) / 31.399999618530273))
            this.sc.tick.Play(0.8f, MathHelper.Clamp((float) ((double) this.slider3 / 10.0 - 0.5), -1f, 1f), 0.0f);
          this.slider3 = (int) (((double) this.sliderbox3 + 157.0) / 31.399999618530273);
          this.sc.vv = (float) (this.slider3 * this.slider3) / 100f;
        }
      }
      if (this.mousepress || input.IsMenuSelect(this.ControllingPlayer, out this.playerindex))
      {
        if (this.whichbutton == 0)
        {
          this.sc.SavePrefs();
          this.sc.harp2.Play(this.sc.ev, 0.1f, 0.0f);
          this.menuState = this.lastState2;
          this.delayinput = true;
        }
        if (this.whichbutton == 1)
        {
          this.whichbutton = 0;
          this.menuState = this.lastState2;
          this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
          this.delayinput = true;
        }
        if (this.whichbutton > 1)
        {
          this.whichbutton = 0;
          this.sc.switch2.Play(this.sc.ev, 0.0f, 0.0f);
        }
      }
      if (this.mouseback || input.IsNewButtonPress(Buttons.B, this.ControllingPlayer, out this.playerindex) || input.IsMenuCancel(this.ControllingPlayer, out this.playerindex))
      {
        this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
        this.menuState = this.lastState2;
        this.delayinput = true;
        this.whichbutton = 0;
      }
      if (this.whichbutton != -1)
        this.lastbutton = this.whichbutton;
      if (!this.mousemoving)
        return;
      this.whichbutton = -1;
    }

    private void handleVideos(ref InputState input)
    {
      this.selectOneExclusive(0, 2, input);
      if (this.mousepress || input.IsMenuSelect(this.ControllingPlayer, out this.playerindex))
      {
        if (this.whichbutton == 0)
        {
          this.menuState = MainMenu.states.credit;
          try
          {
            MediaScreen screen = new MediaScreen(1);
            screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
            {
              this.menuState = MainMenu.states.videos;
              this.delayinput = true;
            });
            screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
            {
              this.menuState = MainMenu.states.videos;
              this.delayinput = true;
            });
            this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
          }
          catch
          {
            this.menuState = MainMenu.states.videos;
            this.delayinput = true;
            this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
            this.sc.trophy.win(this.sc.trophy.credits);
          }
        }
        if (this.whichbutton == 1)
        {
          this.menuState = MainMenu.states.trailer;
          try
          {
            MediaScreen screen = new MediaScreen(0);
            screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
            {
              this.menuState = MainMenu.states.videos;
              this.delayinput = true;
            });
            screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
            {
              this.menuState = MainMenu.states.videos;
              this.delayinput = true;
            });
            this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
          }
          catch
          {
            this.menuState = MainMenu.states.videos;
            this.delayinput = true;
            this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
          }
        }
        if (this.whichbutton == 2)
        {
          this.whichbutton = 3;
          this.menuState = MainMenu.states.more;
          this.checkTrophyOnce = false;
          this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
          this.delayinput = true;
        }
      }
      if (this.mouseback || input.IsNewButtonPress(Buttons.B, this.ControllingPlayer, out this.playerindex) || input.IsMenuCancel(this.ControllingPlayer, out this.playerindex))
      {
        this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
        this.menuState = MainMenu.states.more;
        this.checkTrophyOnce = false;
        this.delayinput = true;
        this.whichbutton = 0;
      }
      if (this.whichbutton != -1)
        this.lastbutton = this.whichbutton;
      if (!this.mousemoving)
        return;
      this.whichbutton = -1;
    }

    private void handleGraphics(ref InputState input)
    {
      this.selectOneExclusive(0, 1, input);
      if (this.mousepress || input.IsMenuSelect(this.ControllingPlayer, out this.playerindex))
      {
        if (this.whichbutton == 0)
        {
          this.sc.setResolution();
          this.sc.trophy.win(this.sc.trophy.graphics);
          this.delayinput = true;
        }
        if (this.whichbutton == 1)
        {
          if (this.sc.setgraphics)
          {
            this.forgotsave();
            this.whichbutton = 1;
          }
          else
          {
            this.menuState = this.lastState2;
            this.whichbutton = 1;
            this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
            this.delayinput = true;
          }
        }
      }
      if ((this.mouseState.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && this.prevMouse.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Released || input.IsNewButtonPress(Buttons.B, this.ControllingPlayer, out this.playerindex) ? 1 : (input.IsMenuCancel(this.ControllingPlayer, out this.playerindex) ? 1 : 0)) != 0)
      {
        if (this.sc.setgraphics)
        {
          this.forgotsave();
          this.whichbutton = 1;
        }
        else
        {
          this.whichbutton = 1;
          this.menuState = this.lastState2;
          this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
          this.delayinput = true;
        }
      }
      if (this.highlighttimer > 0)
      {
        --this.highlighttimer;
        if (this.highlighttimer == 0)
          this.highlight = 0;
      }
      bool flag1 = input.IsNewButtonPress(Buttons.DPadLeft, this.ControllingPlayer, out this.playerindex);
      bool flag2 = input.IsNewButtonPress(Buttons.DPadRight, this.ControllingPlayer, out this.playerindex);
      bool flag3 = input.IsNewButtonPress(Buttons.DPadUp, this.ControllingPlayer, out this.playerindex);
      bool flag4 = input.IsNewButtonPress(Buttons.DPadDown, this.ControllingPlayer, out this.playerindex);
      bool flag5 = this.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.OemPlus) && this.prevKeys.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.OemPlus);
      bool flag6 = this.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.OemMinus) && this.prevKeys.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.OemMinus);
      if (flag5 || this.mousepress && this.whichbutton == 9)
      {
        if (flag5)
        {
          this.highlight = 9;
          this.highlighttimer = 5;
        }
        this.sc.aspectratio += 0.025f;
        if ((double) this.sc.aspectratio > 3.0)
          this.sc.aspectratio = 3f;
        this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
        this.sc.setResolution();
      }
      if (flag6 || this.mousepress && this.whichbutton == 10)
      {
        if (flag6)
        {
          this.highlight = 10;
          this.highlighttimer = 5;
        }
        this.sc.aspectratio -= 0.025f;
        if ((double) this.sc.aspectratio < 0.30000001192092896)
          this.sc.aspectratio = 0.3f;
        this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
        this.sc.setResolution();
      }
      if (flag1 || this.mousepress && this.whichbutton == 7)
      {
        if (flag1)
        {
          this.highlight = 7;
          this.highlighttimer = 5;
        }
        this.sc.aa -= 2;
        if (this.sc.aa < 0)
          this.sc.aa = 8;
        this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
      }
      if (flag2 || this.mousepress && this.whichbutton == 8)
      {
        if (flag2)
        {
          this.highlight = 8;
          this.highlighttimer = 5;
        }
        this.sc.aa += 2;
        if (this.sc.aa > 8)
          this.sc.aa = 0;
        this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
      }
      if (flag3 || this.mousepress && this.whichbutton == 6)
      {
        if (flag3)
        {
          this.highlight = 6;
          this.highlighttimer = 5;
        }
        ++this.sc.setupnum;
        if (this.sc.setupnum > this.sc.resnames.Count - 1)
          this.sc.setupnum = 0;
        this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
      }
      if (flag4 || this.mousepress && this.whichbutton == 5)
      {
        if (flag4)
        {
          this.highlight = 5;
          this.highlighttimer = 5;
        }
        --this.sc.setupnum;
        if (this.sc.setupnum < 0)
          this.sc.setupnum = this.sc.resnames.Count - 1;
        this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
      }
      if (this.mousepress && this.whichbutton == 11)
      {
        this.sc.fullmode = !this.sc.fullmode;
        this.sc.setResolution();
        this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
      }
      if (this.mousepress && this.whichbutton == 12)
      {
        this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
        this.sc.border = !this.sc.border;
        if (!this.sc.fullmode)
        {
          if (this.sc.border)
            this.sc.addBorder();
          else
            this.sc.removeBorder();
        }
      }
      if (this.whichbutton != -1)
        this.lastbutton = this.whichbutton;
      if (!this.mousemoving)
        return;
      this.whichbutton = -1;
    }

    private void handleCooplobby(ref InputState input)
    {
      if ((this.mousepress || input.IsMenuSelect(this.ControllingPlayer, out this.playerindex)) && this.whichKEY >= 0 && this.sc.lobby.lobbys.Count > 0 && this.whichKEY < this.sc.lobby.lobbys.Count && this.sc.lobby.joinLobby(this.sc.lobby.lobbys[this.whichKEY].id) == 200)
      {
        this.sc.lobby.lobbyName = this.sc.lobby.lobbys[this.whichKEY].name;
        this.whichbutton = 0;
        this.jumptomain = false;
        this.menuState = MainMenu.states.multijoinStart;
        if (this.sc.lobby.joinedLobby.Count > 0)
          this.sc.lobby.grabDayCharState(this.sc.lobby.joinedLobby[0]);
        this.sc.switch2.Play(this.sc.ev * 0.2f, 0.1f, 0.0f);
      }
      if (input.IsMenuDown(this.ControllingPlayer) && this.whichKEY + 3 <= 20)
      {
        this.whichKEY += 3;
        this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
      }
      if (input.IsMenuUp(this.ControllingPlayer) && this.whichKEY - 3 >= 0)
      {
        this.whichKEY -= 3;
        this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
      }
      if (input.IsMenuLeft(this.ControllingPlayer))
      {
        --this.whichKEY;
        this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
        if (this.whichKEY < 0)
          this.whichKEY = 0;
      }
      if (input.IsMenuRight(this.ControllingPlayer))
      {
        ++this.whichKEY;
        this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
        if (this.whichKEY > 20)
          this.whichKEY = 20;
      }
      if (!this.mouseback && !input.IsNewButtonPress(Buttons.B, this.ControllingPlayer, out this.playerindex) && !input.IsMenuCancel(this.ControllingPlayer, out this.playerindex))
        return;
      this.sc.lobby.leaveLobby();
      this.sc.lobby.uncreateLobby();
      this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
      this.menuState = MainMenu.states.main;
      if (this.lobbynum == "2")
        this.menuState = MainMenu.states.multi2player;
      if (this.lobbynum == "4")
        this.menuState = MainMenu.states.multi4player;
      if (this.lobbynum == "3")
        this.menuState = MainMenu.states.multi3player;
      if (this.lobbynum == "6")
        this.menuState = MainMenu.states.multi6player;
      this.delayinput = true;
      this.whichbutton = 1;
    }

    private void handleTrailer(ref InputState input)
    {
      if (!this.mouseback && !input.IsNewButtonPress(Buttons.B, this.ControllingPlayer, out this.playerindex) && !input.IsMenuCancel(this.ControllingPlayer, out this.playerindex))
        return;
      this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
      this.menuState = MainMenu.states.videos;
      this.delayinput = true;
      this.whichbutton = 1;
    }

    private void handleCredit(ref InputState input)
    {
      if (!this.mouseback && !input.IsNewButtonPress(Buttons.B, this.ControllingPlayer, out this.playerindex) && !input.IsMenuCancel(this.ControllingPlayer, out this.playerindex))
        return;
      this.sc.switch2.Play(this.sc.ev * 0.2f, -0.2f, 0.0f);
      this.menuState = MainMenu.states.videos;
      this.delayinput = true;
      this.whichbutton = 0;
    }

    public override void HandleInput(InputState input)
    {
      if (!this.sc.audioLoaded)
        return;
      if (input == null)
        throw new ArgumentNullException(nameof (input));
      if (this.ControllingPlayer.HasValue)
      {
        this.playerindex = this.ControllingPlayer.Value;
        this.gamePadState = input.CurrentGamePadStates[(int) this.playerindex];
        this.prevstate = input.LastGamePadStates[(int) this.playerindex];
        GamePad.SetVibration(this.playerindex, 0.0f, 0.0f);
      }
      this.prevKeys = input.lastKeyState;
      this.keyState = input.currentKeyState;
      this.prevMouse = this.mouseState;
      this.mouseState = Mouse.GetState();
      this.pressedKeys = this.keyState.GetPressedKeys();
      if (this.delayinput)
      {
        this.prevMouse = this.mouseState;
        this.prevKeys = this.keyState;
        this.prevstate = this.gamePadState;
      }
      if ((double) this.titlecounter <= 0.0 && !this.delayinput)
      {
        if (this.mouseState.X == (int) this.sc.mymouse.X && this.mouseState.Y == (int) this.sc.mymouse.Y)
        {
          this.mousemoving = false;
          --this.sc.mousefade;
          if (this.sc.mousefade == 0)
            this.sc.Game.IsMouseVisible = false;
        }
        else
        {
          this.mousemoving = true;
          this.sc.mousefade = 210;
          this.sc.Game.IsMouseVisible = true;
          if (this.sc.justsetgraphics)
          {
            this.sc.justsetgraphics = false;
            this.sc.mousefade = 0;
            this.sc.Game.IsMouseVisible = false;
            this.mousemoving = false;
            this.whichbutton = 0;
          }
        }
      }
      else
        this.sc.Game.IsMouseVisible = false;
      this.sc.mymouse.X = (float) this.mouseState.X;
      this.sc.mymouse.Y = (float) this.mouseState.Y;
      this.mouseback = this.mouseState.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && this.prevMouse.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Released;
      this.mousepress = this.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter) && this.prevKeys.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.Enter) || this.mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && this.prevMouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released;
      this.mousePressHold = this.mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed;
      this.mousemiddle = this.mouseState.MiddleButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && this.prevMouse.MiddleButton == Microsoft.Xna.Framework.Input.ButtonState.Released;
      this.mousenum1 = this.mouseState.XButton1 == Microsoft.Xna.Framework.Input.ButtonState.Pressed && this.prevMouse.XButton1 == Microsoft.Xna.Framework.Input.ButtonState.Released;
      this.mousenum2 = this.mouseState.XButton2 == Microsoft.Xna.Framework.Input.ButtonState.Pressed && this.prevMouse.XButton2 == Microsoft.Xna.Framework.Input.ButtonState.Released;
      if (this.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F10) && this.prevKeys.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.F10))
      {
        this.sc.fullmode = !this.sc.fullmode;
        this.sc.setResolution();
      }
      if (this.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F9) && this.prevKeys.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.F9))
      {
        this.sc.border = !this.sc.border;
        if (!this.sc.fullmode)
        {
          if (this.sc.border)
            this.sc.addBorder();
          else
            this.sc.removeBorder();
        }
      }
      if ((double) this.titlecounter <= 0.0)
      {
        if (this.sc.lobby.inviteRequest)
        {
          this.sc.harp2.Play(this.sc.ev, 0.0f, 0.0f);
          string messagex = "Enter Your Name?\n";
          try
          {
            messagex = this.sc.lobby.inviteName + " Invites You\nEnter Your Name?";
          }
          catch
          {
          }
          MessageBoxScreen2 screen = new MessageBoxScreen2(messagex, 4);
          screen.Approved += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
          {
            this.sc.SavePrefs();
            this.sc.lobby.uncreateLobby();
            this.sc.lobby.leaveLobby();
            if (this.sc.lobby.joinLobby(this.sc.lobby.inviteLobbyID) == 200)
            {
              this.sc.lobby.lobbyName = this.sc.lobby.inviteName;
              this.whichbutton = 0;
              this.jumptomain = true;
              this.menuState = MainMenu.states.multijoinStart;
              if (this.sc.lobby.joinedLobby.Count > 0)
                this.sc.lobby.grabDayCharState(this.sc.lobby.joinedLobby[0]);
              this.sc.switch2.Play(this.sc.ev * 0.2f, 0.1f, 0.0f);
            }
            this.sc.lobby.inviteRequest = false;
          });
          screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
          {
            this.delayinput = true;
            this.sc.lobby.inviteRequest = false;
          });
          this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
        }
        if (this.menuState == MainMenu.states.main)
          this.handleMain(ref input);
        else if (this.menuState == MainMenu.states.creditwall)
          this.handleCreditwall(ref input);
        else if (this.menuState == MainMenu.states.alphateam)
          this.handleAlphateam(ref input);
        else if (this.menuState == MainMenu.states.playgame)
          this.handlePlaygame(ref input);
        else if (this.menuState == MainMenu.states.multijoinStart)
          this.handleMultijoinStart(ref input);
        else if (this.menuState == MainMenu.states.multiHostStart)
          this.handleMultiHostStart(ref input);
        else if (this.menuState == MainMenu.states.display)
          this.handleDisplay(ref input);
        else if (this.menuState == MainMenu.states.settings)
          this.handleSettings(ref input);
        else if (this.menuState == MainMenu.states.coopChoice)
          this.handleCoopChoice(ref input);
        else if (this.menuState == MainMenu.states.multi2player)
          this.method_0(ref input);
        else if (this.menuState == MainMenu.states.multi4player)
          this.method_2(ref input);
        else if (this.menuState == MainMenu.states.multi3player)
          this.method_1(ref input);
        else if (this.menuState == MainMenu.states.multi6player)
          this.method_3(ref input);
        else if (this.menuState == MainMenu.states.workshop)
          this.handleWorkshop(ref input);
        else if (this.menuState == MainMenu.states.controls)
          this.handleControls(ref input);
        else if (this.menuState == MainMenu.states.displaykeys)
          this.handleDisplaykeys(ref input);
        else if (this.menuState == MainMenu.states.audio)
          this.handleAudio(ref input);
        else if (this.menuState == MainMenu.states.videos)
          this.handleVideos(ref input);
        else if (this.menuState == MainMenu.states.graphics)
          this.handleGraphics(ref input);
        else if (this.menuState == MainMenu.states.cooplobby)
          this.handleCooplobby(ref input);
        else if (this.menuState == MainMenu.states.trailer)
          this.handleTrailer(ref input);
        else if (this.menuState == MainMenu.states.credit)
          this.handleCredit(ref input);
        else if (this.menuState == MainMenu.states.diary)
          this.handleDiary(ref input);
        else if (this.menuState == MainMenu.states.more)
          this.handleMore(ref input);
      }
      this.delayinput = false;
    }

    public void techinfoBox(string ss)
    {
      MessageBoxScreen2 screen = new MessageBoxScreen2(ss, 16);
      screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
      screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
      this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
    }

    public void backgroundPlay()
    {
    }

    public void drawHelper(string mess, int totalbuttons, int butnum, float gap)
    {
      int num1 = totalbuttons - 1;
      float num2 = 214f;
      float num3 = (float) ((double) totalbuttons * (double) num2 + (double) num1 * (double) gap);
      float y1 = 320f;
      float x1 = (float) (640.0 - (double) num3 / 2.0) + (float) butnum * (num2 + gap);
      if (!this.covered && this.sc.Game.IsMouseVisible)
        this.queryButton(new Rectangle((int) x1, (int) y1, 214, 70), butnum);
      Color color = new Color(180, 180, 180);
      if (this.whichbutton == butnum)
      {
        color = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2(x1 - 4f, y1), new Rectangle?(this.buttonOn), Color.White);
      }
      else
      {
        color = new Color(160, 160, 160);
        this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2(x1, y1), new Rectangle?(this.button), Color.White);
      }
      float x2 = (float) ((double) x1 + (double) num2 / 2.0 - (double) this.deadfont.MeasureString(mess).X / 2.0 + 3.0);
      float y2 = (float) (350.0 - (double) this.deadfont.MeasureString(mess).Y / 2.5);
      this.spriteBatch.DrawString(this.deadfont, mess, new Vector2(x2 - 3f, y2 - 3f), Color.Black);
      this.spriteBatch.DrawString(this.deadfont, mess, new Vector2(x2, y2), color);
    }

    public void drawHelper2(string mess, int totalbuttons, int butnum, float gap)
    {
      int num1 = totalbuttons - 1;
      float num2 = 214f;
      float num3 = (float) ((double) totalbuttons * (double) num2 + (double) num1 * (double) gap);
      float y1 = 320f;
      float x1 = (float) (640.0 - (double) num3 / 2.0) + (float) butnum * (num2 + gap);
      if (!this.covered && this.sc.Game.IsMouseVisible)
        this.queryButton(new Rectangle((int) x1, (int) y1, 214, 70), butnum);
      Color color = new Color(180, 180, 180);
      if (this.whichbutton == butnum)
      {
        color = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2(x1 - 4f, y1), new Rectangle?(this.buttonOn2), Color.White);
      }
      else
      {
        color = new Color(160, 160, 160);
        this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2(x1, y1), new Rectangle?(this.button2), Color.White);
      }
      float x2 = (float) ((double) x1 + (double) num2 / 2.0 - (double) this.deadfont.MeasureString(mess).X / 2.0 + 3.0);
      float y2 = (float) (350.0 - (double) this.deadfont.MeasureString(mess).Y / 2.5);
      this.spriteBatch.DrawString(this.deadfont, mess, new Vector2(x2 - 3f, y2 - 3f), Color.Black);
      this.spriteBatch.DrawString(this.deadfont, mess, new Vector2(x2, y2), color);
    }

    public void drawHelper3(string mess, int totalbuttons, int butnum, float gap)
    {
      int num1 = totalbuttons - 1;
      float num2 = 214f;
      float num3 = (float) ((double) totalbuttons * (double) num2 + (double) num1 * (double) gap);
      float y1 = 320f;
      float x1 = (float) (640.0 - (double) num3 / 2.0) + (float) butnum * (num2 + gap);
      if (!this.covered && this.sc.Game.IsMouseVisible)
        this.queryButton(new Rectangle((int) x1, (int) y1, 214, 70), butnum);
      Color color = new Color(180, 180, 180);
      if (this.whichbutton == butnum)
      {
        color = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2(x1 - 4f, y1), new Rectangle?(this.buttonOn3), Color.White);
      }
      else
      {
        color = new Color(160, 160, 160);
        this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2(x1, y1), new Rectangle?(this.button3), Color.White);
      }
      float x2 = (float) ((double) x1 + (double) num2 / 2.0 - (double) this.deadfont.MeasureString(mess).X / 2.0 + 3.0);
      float y2 = (float) (350.0 - (double) this.deadfont.MeasureString(mess).Y / 2.5);
      this.spriteBatch.DrawString(this.deadfont, mess, new Vector2(x2 - 3f, y2 - 3f), Color.Black);
      this.spriteBatch.DrawString(this.deadfont, mess, new Vector2(x2, y2), color);
    }

    public void drawHelper4(string mess, int totalbuttons, int butnum, float gap, bool flash)
    {
      int num1 = totalbuttons - 1;
      float num2 = 174f;
      float num3 = (float) ((double) totalbuttons * (double) num2 + (double) num1 * (double) gap);
      float num4 = 330f;
      float x1 = (float) (640.0 - (double) num3 / 2.0) + (float) butnum * (num2 + gap);
      int num5 = 15;
      if (!this.covered && this.sc.Game.IsMouseVisible)
        this.queryButton(new Rectangle((int) x1, (int) num4 + num5, 175, 62), butnum);
      Color color = new Color(180, 180, 180);
      if (this.whichbutton == butnum)
      {
        color = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2(x1, (float) num5 + num4), new Rectangle?(this.buttonOn4), Color.White);
      }
      else
      {
        color = new Color(160, 160, 160);
        this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2(x1, (float) num5 + num4), new Rectangle?(this.button4), Color.White);
      }
      if (flash)
        color = this.flashing[this.flashindex];
      float x2 = (float) ((double) x1 + (double) num2 / 2.0 - (double) this.sc.fontsmall.MeasureString(mess).X / 2.0);
      float y = (float) (num5 + 360) - this.sc.fontsmall.MeasureString(mess).Y / 3f;
      this.spriteBatch.DrawString(this.sc.fontsmall, mess, new Vector2(x2 - 1f, y - 1f), new Color(50, 50, 50, (int) byte.MaxValue));
      this.spriteBatch.DrawString(this.sc.fontsmall, mess, new Vector2(x2, y), color);
    }

    public void drawHelper5(string mess, int totalbuttons, int butnum, float gap, bool flash)
    {
      int num1 = totalbuttons - 1;
      float num2 = 174f;
      float num3 = (float) ((double) totalbuttons * (double) num2 + (double) num1 * (double) gap);
      float num4 = 330f;
      float x1 = (float) (640.0 - (double) num3 / 2.0) + (float) butnum * (num2 + gap);
      int num5 = 15;
      if (!this.covered && this.sc.Game.IsMouseVisible)
        this.queryButton(new Rectangle((int) x1, (int) num4 + num5, 175, 62), butnum);
      Color color = new Color(180, 180, 180);
      if (this.whichbutton == butnum)
      {
        color = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2(x1, (float) num5 + num4), new Rectangle?(this.rectangle_11), Color.White);
      }
      else
      {
        color = new Color(160, 160, 160);
        this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2(x1, (float) num5 + num4), new Rectangle?(this.button4x), Color.White);
      }
      if (flash)
        color = this.flashing[this.flashindex];
      float x2 = (float) ((double) x1 + (double) num2 / 2.0 - (double) this.sc.fontsmall.MeasureString(mess).X / 2.0);
      float y = (float) (num5 + 360) - this.sc.fontsmall.MeasureString(mess).Y / 3f;
      this.spriteBatch.DrawString(this.sc.fontsmall, mess, new Vector2(x2 - 1f, y - 1f), new Color(50, 50, 50, (int) byte.MaxValue));
      this.spriteBatch.DrawString(this.sc.fontsmall, mess, new Vector2(x2, y), color);
    }

    public void queryButtonX(Rectangle rr, Vector2 vv, int ch)
    {
      rr = new Rectangle((int) vv.X, (int) vv.Y, rr.Width, rr.Height);
      Vector2 mymouse = this.sc.mymouse;
      if ((double) this.sc.aspectratio <= 1.0)
        mymouse.Y -= (float) (((double) this.sc.screenSize.Height - (double) this.sc.screenSize.Height * (double) this.sc.aspectratio) * (0.5 / (double) this.sc.aspectratio));
      else
        mymouse.X -= (float) (((double) this.sc.screenSize.Width - (double) this.sc.screenSize.Width / (double) this.sc.aspectratio) * (0.5 * (double) this.sc.aspectratio));
      Vector2 vector2_1 = 1f * new Vector2((float) this.sc.screenSize.Width / (float) this.sc.origSize.Width, (float) this.sc.screenSize.Height / (float) this.sc.origSize.Height);
      Vector2 vector2_2 = mymouse / vector2_1;
      if (((double) vector2_2.Y <= (double) rr.Y || (double) vector2_2.Y > (double) (rr.Y + rr.Height) || (double) vector2_2.X <= (double) rr.X ? 0 : ((double) vector2_2.X <= (double) (rr.X + rr.Width) ? 1 : 0)) == 0)
        return;
      this.myIndex = ch;
    }

    public void queryButton(Rectangle rr, int index)
    {
      Vector2 vector2 = this.sc.adjustVector2(this.sc.mymouse);
      if (((double) vector2.Y <= (double) rr.Y || (double) vector2.Y > (double) (rr.Y + rr.Height) || (double) vector2.X <= (double) rr.X ? 0 : ((double) vector2.X <= (double) (rr.X + rr.Width) ? 1 : 0)) == 0)
        return;
      this.whichbutton = index;
    }

    public void queryButton2(Rectangle rr, int index)
    {
      Vector2 vector2 = this.sc.adjustVector2(this.sc.mymouse);
      if (((double) vector2.Y <= (double) rr.Y || (double) vector2.Y > (double) (rr.Y + rr.Height) || (double) vector2.X <= (double) rr.X ? 0 : ((double) vector2.X <= (double) (rr.X + rr.Width) ? 1 : 0)) == 0)
        return;
      this.menuSelect = index;
    }

    public void queryKeySquare(Rectangle rr, int index)
    {
      Vector2 vector2 = this.sc.adjustVector2(this.sc.mymouse);
      if (((double) vector2.Y <= (double) rr.Y || (double) vector2.Y > (double) (rr.Y + rr.Height) || (double) vector2.X <= (double) rr.X ? 0 : ((double) vector2.X <= (double) (rr.X + rr.Width) ? 1 : 0)) == 0)
        return;
      this.whichKEY = index;
    }

    public Vector2 adjustMouse()
    {
      Vector2 mymouse = this.sc.mymouse;
      if ((double) this.sc.aspectratio <= 1.0)
        mymouse.Y -= (float) (((double) this.sc.screenSize.Height - (double) this.sc.screenSize.Height * (double) this.sc.aspectratio) * (0.5 / (double) this.sc.aspectratio));
      else
        mymouse.X -= (float) (((double) this.sc.screenSize.Width - (double) this.sc.screenSize.Width / (double) this.sc.aspectratio) * (0.5 * (double) this.sc.aspectratio));
      Vector2 vector2 = 1f * new Vector2((float) this.sc.screenSize.Width / (float) this.sc.origSize.Width, (float) this.sc.screenSize.Height / (float) this.sc.origSize.Height);
      return mymouse / vector2;
    }

    private void drawmain()
    {
      this.menuMusic.Volume = this.sc.mv;
      this.backgroundPlay();
      this.spriteBatch.Draw(this.sc.titleBG, this.sc.origSize, Color.White);
      this.spriteBatch.Draw(this.sc.titleHeaderBloodBacon, this.sc.origSize, Color.White);
      if (this.newpage)
        this.spriteBatch.Draw(this.sc.titlePig0, new Vector2(475f, 399f), new Rectangle?(new Rectangle(0, 0, 400, 260)), Color.White, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
      if (!this.newpage)
      {
        if (this.sc.star1)
        {
          if (!this.sc.fastnades)
            this.spriteBatch.Draw(this.sc.staroff, new Vector2(514f, 477f), Color.White);
          if (this.sc.fastnades)
            this.spriteBatch.Draw(this.sc.star, new Vector2(514f, 477f), Color.White);
        }
        if (this.sc.star2)
        {
          if (this.sc.gorelevel < 1)
            this.spriteBatch.Draw(this.sc.staroff, new Vector2(607f, 477f), Color.White);
          if (this.sc.gorelevel > 0)
            this.spriteBatch.Draw(this.sc.star, new Vector2(607f, 477f), Color.White);
        }
        if (this.sc.star3)
        {
          if (!this.sc.doubleAmmo)
            this.spriteBatch.Draw(this.sc.staroff, new Vector2(701f, 477f), Color.White);
          if (this.sc.doubleAmmo)
            this.spriteBatch.Draw(this.sc.star, new Vector2(701f, 477f), Color.White);
        }
        this.spriteBatch.Draw(this.sc.titleHeaderSecrets, this.sc.origSize, Color.White);
      }
      this.drawHelper("single", 4, 0, 20f);
      this.drawHelper("co-op", 4, 1, 20f);
      this.drawHelper("setup", 4, 2, 20f);
      if (!this.newpage)
        this.drawHelper("credits", 4, 3, 20f);
      if (this.newpage)
        this.drawHelper("more", 4, 3, 20f);
      if (!this.covered && this.sc.Game.IsMouseVisible)
      {
        this.queryButton(new Rectangle(586, 230, 80, 25), 7);
        this.queryButton(new Rectangle(424, 230, 80, 25), 8);
        this.queryButton(new Rectangle(754, 230, 80, 25), 9);
        if (this.paintunlocked)
          this.queryButton(this.bonusPaint, 11);
        if (!this.newpage)
        {
          this.queryButton(this.star1, 12);
          this.queryButton(this.star2, 13);
          this.queryButton(this.star3, 14);
        }
        if (this.lastbutton != this.whichbutton && this.whichbutton != -1)
          this.sc.tick.Play(this.sc.ev, 0.2f, 0.0f);
      }
      if (this.whichbutton == 7)
        this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2(564f, 220f), new Rectangle?(this.bonusGlow), Color.White, 0.0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0.0f);
      else
        this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2(564f, 220f), new Rectangle?(this.bonus), Color.White, 0.0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0.0f);
      if (this.whichbutton == 8)
        this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2(414f, 230f), new Rectangle?(this.audioGlow), Color.White, 0.0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0.0f);
      else
        this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2(414f, 230f), new Rectangle?(this.audio), Color.White, 0.0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0.0f);
      if (this.whichbutton == 9)
        this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2(744f, 230f), new Rectangle?(this.keymapGlow), Color.White, 0.0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0.0f);
      else
        this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2(744f, 230f), new Rectangle?(this.keymap), Color.White, 0.0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0.0f);
      if (this.whichbutton == 12)
        this.spriteBatch.Draw(this.sc.starB, new Vector2(507f, 472f), Color.White);
      if (this.whichbutton == 13)
        this.spriteBatch.Draw(this.sc.starB, new Vector2(600f, 472f), Color.White);
      if (this.whichbutton != 14)
        return;
      this.spriteBatch.Draw(this.sc.starB, new Vector2(694f, 472f), Color.White);
    }

    private void drawmore()
    {
      this.menuMusic.Volume = this.sc.mv;
      this.backgroundPlay();
      this.spriteBatch.Draw(this.sc.titleBG, this.sc.origSize, Color.White);
      this.spriteBatch.Draw(this.sc.titleHeaderMore, this.sc.origSize, Color.White);
      if (this.newpage)
      {
        if (this.sc.star1)
        {
          if (!this.sc.fastnades)
            this.spriteBatch.Draw(this.sc.staroff, new Vector2(514f, 477f), Color.White);
          if (this.sc.fastnades)
            this.spriteBatch.Draw(this.sc.star, new Vector2(514f, 477f), Color.White);
        }
        if (this.sc.star2)
        {
          if (this.sc.gorelevel < 1)
            this.spriteBatch.Draw(this.sc.staroff, new Vector2(607f, 477f), Color.White);
          if (this.sc.gorelevel > 0)
            this.spriteBatch.Draw(this.sc.star, new Vector2(607f, 477f), Color.White);
        }
        if (this.sc.star3)
        {
          if (!this.sc.doubleAmmo)
            this.spriteBatch.Draw(this.sc.staroff, new Vector2(701f, 477f), Color.White);
          if (this.sc.doubleAmmo)
            this.spriteBatch.Draw(this.sc.star, new Vector2(701f, 477f), Color.White);
        }
        this.spriteBatch.Draw(this.sc.titleHeaderSecrets, this.sc.origSize, Color.White);
      }
      if (this.sc.allachieves)
        this.spriteBatch.Draw(this.sc.certified, new Vector2(250f, 65f), Color.White);
      this.drawHelper("diary", 5, 0, 18f);
      this.drawHelper("workshop", 5, 1, 18f);
      this.drawHelper("paintland", 5, 2, 18f);
      this.drawHelper("credits", 5, 3, 18f);
      this.drawHelper("back", 5, 4, 18f);
      if (this.sc.workshopNum == this.sc.workshop.fileSize)
        ;
      if (!this.covered && this.sc.Game.IsMouseVisible)
      {
        this.queryButton(this.star1, 12);
        this.queryButton(this.star2, 13);
        this.queryButton(this.star3, 14);
        if (this.lastbutton != this.whichbutton && this.whichbutton != -1)
          this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
      }
      if (this.whichbutton == 12)
        this.spriteBatch.Draw(this.sc.starB, new Vector2(507f, 472f), Color.White);
      if (this.whichbutton == 13)
        this.spriteBatch.Draw(this.sc.starB, new Vector2(600f, 472f), Color.White);
      if (this.whichbutton != 14)
        return;
      this.spriteBatch.Draw(this.sc.starB, new Vector2(694f, 472f), Color.White);
    }

    private void drawcoopChoice()
    {
      this.backgroundPlay();
      this.spriteBatch.Draw(this.sc.titleBG, this.sc.origSize, Color.White);
      this.spriteBatch.Draw(this.sc.titlePig2, new Vector2(475f, 399f), new Rectangle?(new Rectangle(0, 0, 400, 260)), Color.White, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
      this.spriteBatch.Draw(this.sc.titleHeaderMultiplayer, this.sc.origSize, Color.White);
      this.drawHelper("2player", 4, 0, 20f);
      this.drawHelper2("4player", 4, 1, 20f);
      this.drawHelper3("hordes", 4, 2, 20f);
      this.drawHelper("back", 4, 3, 20f);
      if (this.covered || !this.sc.Game.IsMouseVisible || this.lastbutton == this.whichbutton || this.whichbutton == -1)
        return;
      this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
    }

    private void drawmulti2player()
    {
      this.backgroundPlay();
      this.spriteBatch.Draw(this.sc.titleBG, this.sc.origSize, Color.White);
      this.spriteBatch.Draw(this.sc.titlePig2, new Vector2(475f, 399f), new Rectangle?(new Rectangle(0, 0, 400, 260)), Color.White, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
      this.spriteBatch.Draw(this.sc.texture2D_1, this.sc.origSize, Color.White);
      this.drawHelper2("host", 3, 0, 35f);
      this.drawHelper2("join", 3, 1, 35f);
      this.drawHelper2("back", 3, 2, 35f);
      if (!this.covered && this.sc.Game.IsMouseVisible)
      {
        this.queryButton(new Rectangle(580, 230, 100, 54), 7);
        if (this.lastbutton != this.whichbutton && this.whichbutton != -1)
          this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
      }
      if (this.whichbutton == 7)
        this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2(580f, 230f), new Rectangle?(this.creditBoxGlow), Color.White);
      else
        this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2(580f, 230f), new Rectangle?(this.creditBox), Color.White);
    }

    private void drawmulti3player()
    {
      this.backgroundPlay();
      this.spriteBatch.Draw(this.sc.titleBG2, this.sc.origSize, Color.White);
      this.drawHelper2("host", 3, 0, 35f);
      this.drawHelper2("join", 3, 1, 35f);
      this.drawHelper3("back", 3, 2, 35f);
      if (this.covered || !this.sc.Game.IsMouseVisible)
        return;
      this.queryButton(new Rectangle(900, 175, 100, 54), 7);
      if (this.lastbutton == this.whichbutton || this.whichbutton == -1)
        return;
      this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
    }

    private void drawmulti4player()
    {
      this.backgroundPlay();
      this.spriteBatch.Draw(this.sc.titleBG, this.sc.origSize, Color.White);
      this.spriteBatch.Draw(this.sc.titlePig2, new Vector2(475f, 399f), new Rectangle?(new Rectangle(0, 0, 400, 260)), Color.White, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
      this.spriteBatch.Draw(this.sc.texture2D_2, this.sc.origSize, Color.White);
      this.drawHelper2("host", 3, 0, 35f);
      this.drawHelper2("join", 3, 1, 35f);
      this.drawHelper2("back", 3, 2, 35f);
      if (!this.covered && this.sc.Game.IsMouseVisible)
      {
        this.queryButton(new Rectangle(900, 175, 100, 54), 7);
        if (this.lastbutton != this.whichbutton && this.whichbutton != -1)
          this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
      }
      if (this.whichbutton == 7)
        this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2(900f, 175f), new Rectangle?(this.creditBoxGlow), Color.White);
      else
        this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2(900f, 175f), new Rectangle?(this.creditBox), Color.White);
    }

    private void drawmulti6player()
    {
      this.backgroundPlay();
      this.spriteBatch.Draw(this.sc.titleBG, this.sc.origSize, Color.White);
      this.spriteBatch.Draw(this.sc.titlePig2, new Vector2(475f, 399f), new Rectangle?(new Rectangle(0, 0, 400, 260)), Color.White, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
      this.spriteBatch.Draw(this.sc.texture2D_3, this.sc.origSize, Color.White);
      this.drawHelper("host", 3, 0, 35f);
      this.drawHelper("join", 3, 1, 35f);
      this.drawHelper("back", 3, 2, 35f);
      if (this.covered || !this.sc.Game.IsMouseVisible)
        return;
      this.queryButton(new Rectangle(900, 175, 100, 54), 7);
      if (this.lastbutton == this.whichbutton || this.whichbutton == -1)
        return;
      this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
    }

    private void drawplaygame()
    {
      this.backgroundPlay();
      this.spriteBatch.Draw(this.sc.titleBG, this.sc.origSize, Color.White);
      this.spriteBatch.Draw(this.sc.titleHeaderBloodBaconB, this.sc.origSize, Color.White);
      this.spriteBatch.Draw(this.sc.titleHeaderTunnelDays, this.sc.origSize, Color.White);
      this.spriteBatch.Draw(this.sc.titleCharsSingle, this.sc.origSize, Color.White);
      this.spriteBatch.Draw(this.sc.titleFaces, new Rectangle(0, 220, 1280, 500), new Rectangle?(new Rectangle(0, 220, 1280, 500)), Color.White);
      Rectangle destinationRectangle;
      if (!this.sc.man1)
      {
        destinationRectangle = new Rectangle((int) this.selectPoint[8].X + 1, (int) this.selectPoint[8].Y - 1, 48, 48);
        this.spriteBatch.Draw(this.sc.overlay, destinationRectangle, new Rectangle?(this.locked), Color.White);
      }
      if (!this.sc.man2)
      {
        destinationRectangle = new Rectangle((int) this.selectPoint[9].X + 1, (int) this.selectPoint[9].Y - 1, 48, 48);
        this.spriteBatch.Draw(this.sc.overlay, destinationRectangle, new Rectangle?(this.locked), Color.White);
      }
      if (!this.sc.man3)
      {
        destinationRectangle = new Rectangle((int) this.selectPoint[10].X + 1, (int) this.selectPoint[10].Y - 1, 48, 48);
        this.spriteBatch.Draw(this.sc.overlay, destinationRectangle, new Rectangle?(this.locked), Color.White);
      }
      if (!this.sc.FarmerUnlocked)
      {
        destinationRectangle = new Rectangle((int) this.selectPoint[4].X + 11, (int) this.selectPoint[4].Y + 11, this.locked.Width, this.locked.Height);
        this.spriteBatch.Draw(this.sc.overlay, destinationRectangle, new Rectangle?(this.locked), Color.White);
      }
      if (!this.sc.man4)
      {
        destinationRectangle = new Rectangle((int) this.selectPoint[7].X, (int) this.selectPoint[7].Y, this.locked.Width, this.locked.Height);
        destinationRectangle.Width = 48;
        destinationRectangle.Height = 48;
        this.spriteBatch.Draw(this.sc.overlay, destinationRectangle, new Rectangle?(this.locked), Color.White);
      }
      destinationRectangle = new Rectangle((int) this.selectPoint[this.menuSelect].X - 1, (int) this.selectPoint[this.menuSelect].Y - 1, this.glow.Width, this.glow.Height);
      if (this.menuSelect >= 6)
      {
        if (this.menuSelect <= 10)
        {
          destinationRectangle.Width = 52;
          destinationRectangle.Height = 52;
        }
        else
        {
          destinationRectangle.X = 551;
          destinationRectangle.Y = 212;
          destinationRectangle.Width = 205;
          destinationRectangle.Height = 53;
        }
      }
      if (this.menuSelect <= 10)
        this.spriteBatch.Draw(this.sc.overlay, destinationRectangle, new Rectangle?(this.glow), Color.White);
      this.drawInfo();
      this.drawHelper("start", 2, 0, 20f);
      this.drawHelper("back", 2, 1, 20f);
      if (this.covered || !this.sc.Game.IsMouseVisible || this.lastbutton == this.whichbutton || this.whichbutton == -1)
        return;
      this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
    }

    private void drawmultijoinstart()
    {
      this.backgroundPlay();
      this.spriteBatch.Draw(this.sc.titleBG, this.sc.origSize, Color.White);
      this.spriteBatch.Draw(this.sc.titleHeaderJoin, this.sc.origSize, Color.White);
      this.spriteBatch.Draw(this.sc.titleCharsSingle, this.sc.origSize, Color.White);
      this.spriteBatch.Draw(this.sc.titleFaces, new Rectangle(0, 220, 1280, 500), new Rectangle?(new Rectangle(0, 220, 1280, 500)), Color.White);
      Color color = Color.White;
      if (!this.sc.lobby.inLobby)
        color = new Color((int) byte.MaxValue, 105, 105, (int) byte.MaxValue);
      if (this.sc.lobby.lobbyPassword != "")
        color = new Color(105, 105, (int) byte.MaxValue, (int) byte.MaxValue);
      if (this.sc.lobby.lobbyState == "20")
        color = new Color((int) byte.MaxValue, 90, 90, (int) byte.MaxValue);
      if ((double) this.sc.myTimer % 30.0 == 0.0 && this.sc.lobby.joinedLobby.Count > 0)
        this.sc.lobby.grabDayCharState(this.sc.lobby.joinedLobby[0]);
      if (this.sc.developer)
        this.spriteBatch.DrawString(this.sc.font2, this.sc.lobby.lobbyPassword, new Vector2((float) (640.0 - (double) this.sc.font2.MeasureString(this.sc.lobby.lobbyPassword).X / 2.0), 30f), Color.White);
      this.spriteBatch.DrawString(this.sc.font2, this.sc.lobby.lobbyName + "'s Game", new Vector2(640f, 130f) - this.sc.font2.MeasureString(this.sc.lobby.lobbyName + "'s Game") / 2f, color);
      string str = "";
      if (this.sc.lobby.lobbyChar == "0")
        str = "Lando Bacon";
      if (this.sc.lobby.lobbyChar == "1")
        str = "Johnny Blood";
      if (this.sc.lobby.lobbyChar == "2")
        str = "Farmer McDigg";
      if (this.sc.lobby.lobbyChar == "3")
        str = "The Skeleton";
      if (this.sc.lobby.lobbyChar == "4")
        str = "Daisy Dee";
      if (this.sc.lobby.lobbyChar == "5")
        str = "A Viking";
      if (this.sc.lobby.lobbyChar == "7")
        str = "A Scarecrow";
      if (this.sc.lobby.lobbyChar == "8")
        str = "Toy Robot";
      if (this.sc.lobby.lobbyChar == "9")
        str = "The Golem";
      if (this.sc.lobby.lobbyChar == "10")
        str = "Astronaut";
      if (str != "")
        this.spriteBatch.DrawString(this.sc.font2, "Playing as " + str, new Vector2(640f, 160f) - this.sc.font2.MeasureString("Playing as " + str) / 2f, color);
      if (this.sc.lobby.lobbyDay != "null" && this.sc.lobby.lobbyDay != "wait")
      {
        if (this.sc.lobby.lobbyDay == "0")
          this.spriteBatch.DrawString(this.sc.font2, "Choosing A Character", new Vector2(640f, 190f) - this.sc.font2.MeasureString("Choosing A Character") / 2f, color);
        else if (this.sc.lobby.lobbyplayers == "6")
          this.spriteBatch.DrawString(this.sc.font2, "Day 666 Hordes", new Vector2(640f, 190f) - this.sc.font2.MeasureString("Day 666 Hordes") / 2f, color);
        else if (this.sc.lobby.lobbyplayers == "3")
          this.spriteBatch.DrawString(this.sc.font2, "Paint The Farm", new Vector2(640f, 190f) - this.sc.font2.MeasureString("Paint The Farm") / 2f, color);
        else
          this.spriteBatch.DrawString(this.sc.font2, "Playing on Day " + this.sc.lobby.lobbyDay, new Vector2(640f, 190f) - this.sc.font2.MeasureString("Playing on Day " + this.sc.lobby.lobbyDay) / 2f, color);
      }
      else
      {
        if (this.sc.lobby.lobbyDay == "null")
          this.spriteBatch.DrawString(this.sc.font2, "Lobby is Full", new Vector2(640f, 190f) - this.sc.font2.MeasureString("Lobby is Full") / 2f, color);
        if (this.sc.lobby.lobbyDay == "wait")
        {
          color = Color.White;
          this.spriteBatch.DrawString(this.sc.font2, "Please Wait", new Vector2(640f, 190f) - this.sc.font2.MeasureString("Please Wait") / 2f, color);
        }
      }
      bool flag1 = this.sc.lobby.lobbyplayers == "2" && this.sc.lobby.lobbyVersion == this.sc.lobby.versionNumber.ToString();
      bool flag2 = this.sc.lobby.lobbyplayers == "4" && this.sc.lobby.lobbyVersion == this.sc.lobby.version4Player.ToString();
      bool flag3 = this.sc.lobby.lobbyplayers == "6" && this.sc.lobby.lobbyVersion == this.sc.lobby.version6Player.ToString();
      bool flag4 = this.sc.lobby.lobbyplayers == "3" && this.sc.lobby.lobbyDay == this.sc.lobby.paintVersion.ToString();
      bool flag5 = this.sc.lobby.lobbyplayers == "4" && this.sc.lobby.lobbyVersion == this.sc.lobby.version4Tunnel.ToString();
      if (!flag1 && !flag2 && !flag3 && !flag4 && !flag5)
      {
        if (this.sc.lobby.lobbyDay != "wait" && this.sc.lobby.lobbyDay != "null")
          this.spriteBatch.DrawString(this.sc.font2, "** VERSION MISMATCH **", new Vector2(640f, 220f) - this.sc.font2.MeasureString("** VERSION MISMATCH **") / 2f, new Color((int) byte.MaxValue, 0, (int) byte.MaxValue, (int) byte.MaxValue));
      }
      else
      {
        if (this.sc.lobby.lobbyState == "0")
          this.spriteBatch.DrawString(this.sc.font2, "Not Yet Ready", new Vector2(640f, 220f) - this.sc.font2.MeasureString("Not Yet Ready") / 2f, color);
        if (this.sc.lobby.lobbyState == "10")
          this.spriteBatch.DrawString(this.sc.font2, "Waiting in Barn", new Vector2(640f, 220f) - this.sc.font2.MeasureString("Waiting in Barn") / 2f, color);
        if (this.sc.lobby.lobbyState == "20")
          this.spriteBatch.DrawString(this.sc.font2, "Game is in Progress", new Vector2(640f, 220f) - this.sc.font2.MeasureString("Game is in Progress") / 2f, color);
        if (this.sc.lobby.lobbyState == "5")
          this.spriteBatch.DrawString(this.sc.font2, "Lobby Observation", new Vector2(640f, 220f) - this.sc.font2.MeasureString("Lobby Observation") / 2f, color);
        if (this.sc.lobby.lobbyState == "6")
          this.spriteBatch.DrawString(this.sc.font2, "Game Is Full", new Vector2(640f, 220f) - this.sc.font2.MeasureString("Game Is Full") / 2f, color);
      }
      Rectangle destinationRectangle;
      if (!this.sc.man1)
      {
        destinationRectangle = new Rectangle((int) this.selectPoint[8].X + 1, (int) this.selectPoint[8].Y - 1, 48, 48);
        this.spriteBatch.Draw(this.sc.overlay, destinationRectangle, new Rectangle?(this.locked), Color.White);
      }
      if (!this.sc.man2)
      {
        destinationRectangle = new Rectangle((int) this.selectPoint[9].X + 1, (int) this.selectPoint[9].Y - 1, 48, 48);
        this.spriteBatch.Draw(this.sc.overlay, destinationRectangle, new Rectangle?(this.locked), Color.White);
      }
      if (!this.sc.man3)
      {
        destinationRectangle = new Rectangle((int) this.selectPoint[10].X + 1, (int) this.selectPoint[10].Y - 1, 48, 48);
        this.spriteBatch.Draw(this.sc.overlay, destinationRectangle, new Rectangle?(this.locked), Color.White);
      }
      if (!this.sc.FarmerUnlocked)
      {
        destinationRectangle = new Rectangle((int) this.selectPoint[4].X + 11, (int) this.selectPoint[4].Y + 11, this.locked.Width, this.locked.Height);
        this.spriteBatch.Draw(this.sc.overlay, destinationRectangle, new Rectangle?(this.locked), Color.White);
      }
      if (!this.sc.man4)
      {
        destinationRectangle = new Rectangle((int) this.selectPoint[7].X, (int) this.selectPoint[7].Y, this.locked.Width, this.locked.Height);
        destinationRectangle.Width = 48;
        destinationRectangle.Height = 48;
        this.spriteBatch.Draw(this.sc.overlay, destinationRectangle, new Rectangle?(this.locked), Color.White);
      }
      destinationRectangle = new Rectangle((int) this.selectPoint[this.menuSelect].X - 1, (int) this.selectPoint[this.menuSelect].Y - 1, this.glow.Width, this.glow.Height);
      if (this.menuSelect >= 6)
      {
        if (this.menuSelect <= 10)
        {
          destinationRectangle.Width = 52;
          destinationRectangle.Height = 52;
        }
        else
        {
          destinationRectangle.X = 551;
          destinationRectangle.Y = 212;
          destinationRectangle.Width = 205;
          destinationRectangle.Height = 53;
        }
      }
      if (this.menuSelect <= 10)
        this.spriteBatch.Draw(this.sc.overlay, destinationRectangle, new Rectangle?(this.glow), Color.White);
      this.drawInfo();
      this.drawHelper("start", 2, 0, 20f);
      this.drawHelper("back", 2, 1, 20f);
      if (this.covered || !this.sc.Game.IsMouseVisible || this.lastbutton == this.whichbutton || this.whichbutton == -1)
        return;
      this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
    }

    private void drawmultihoststart()
    {
      this.backgroundPlay();
      this.spriteBatch.Draw(this.sc.titleBG, this.sc.origSize, Color.White);
      this.spriteBatch.Draw(this.sc.titleHeaderBloodBaconC, this.sc.origSize, Color.White);
      this.spriteBatch.Draw(this.sc.titleCharsSingle, this.sc.origSize, Color.White);
      this.spriteBatch.Draw(this.sc.titleFaces, new Rectangle(0, 220, 1280, 500), new Rectangle?(new Rectangle(0, 220, 1280, 500)), Color.White);
      if (this.lobbynum == "4" || this.lobbynum == "2")
        this.spriteBatch.Draw(this.sc.titleHeaderTunnelDays, this.sc.origSize, Color.White);
      Rectangle destinationRectangle;
      if (!this.sc.man1)
      {
        destinationRectangle = new Rectangle((int) this.selectPoint[8].X + 1, (int) this.selectPoint[8].Y - 1, 48, 48);
        this.spriteBatch.Draw(this.sc.overlay, destinationRectangle, new Rectangle?(this.locked), Color.White);
      }
      if (!this.sc.man2)
      {
        destinationRectangle = new Rectangle((int) this.selectPoint[9].X + 1, (int) this.selectPoint[9].Y - 1, 48, 48);
        this.spriteBatch.Draw(this.sc.overlay, destinationRectangle, new Rectangle?(this.locked), Color.White);
      }
      if (!this.sc.man3)
      {
        destinationRectangle = new Rectangle((int) this.selectPoint[10].X + 1, (int) this.selectPoint[10].Y - 1, 48, 48);
        this.spriteBatch.Draw(this.sc.overlay, destinationRectangle, new Rectangle?(this.locked), Color.White);
      }
      if (!this.sc.FarmerUnlocked)
      {
        destinationRectangle = new Rectangle((int) this.selectPoint[4].X + 11, (int) this.selectPoint[4].Y + 11, this.locked.Width, this.locked.Height);
        this.spriteBatch.Draw(this.sc.overlay, destinationRectangle, new Rectangle?(this.locked), Color.White);
      }
      if (!this.sc.man4)
      {
        destinationRectangle = new Rectangle((int) this.selectPoint[7].X, (int) this.selectPoint[7].Y, this.locked.Width, this.locked.Height);
        destinationRectangle.Width = 48;
        destinationRectangle.Height = 48;
        this.spriteBatch.Draw(this.sc.overlay, destinationRectangle, new Rectangle?(this.locked), Color.White);
      }
      destinationRectangle = new Rectangle((int) this.selectPoint[this.menuSelect].X - 1, (int) this.selectPoint[this.menuSelect].Y - 1, this.glow.Width, this.glow.Height);
      if (this.menuSelect >= 6)
      {
        if (this.menuSelect <= 10)
        {
          destinationRectangle.Width = 52;
          destinationRectangle.Height = 52;
        }
        else
        {
          destinationRectangle.X = 551;
          destinationRectangle.Y = 212;
          destinationRectangle.Width = 205;
          destinationRectangle.Height = 53;
        }
      }
      if (this.menuSelect <= 10)
        this.spriteBatch.Draw(this.sc.overlay, destinationRectangle, new Rectangle?(this.glow), Color.White);
      this.drawInfo();
      this.drawHelper("start", 2, 0, 20f);
      this.drawHelper("back", 2, 1, 20f);
      if (this.covered || !this.sc.Game.IsMouseVisible || this.lastbutton == this.whichbutton || this.whichbutton == -1)
        return;
      this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
    }

    private void drawsettings()
    {
      this.backgroundPlay();
      this.spriteBatch.Draw(this.sc.titleBG, this.sc.origSize, Color.White);
      this.spriteBatch.Draw(this.sc.titlePig1, new Vector2(475f, 416f), new Rectangle?(this.myRect[this.pigcount]), Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
      this.spriteBatch.Draw(this.sc.titleheaderSettings, this.sc.origSize, Color.White);
      this.drawHelper("audio", 4, 0, 20f);
      this.drawHelper("video", 4, 1, 20f);
      this.drawHelper("controls", 4, 2, 20f);
      this.drawHelper("back", 4, 3, 20f);
      if (this.covered || !this.sc.Game.IsMouseVisible)
        return;
      this.queryButton(new Rectangle(493, 463, 280, 120), 4);
      if (this.lastbutton == this.whichbutton || this.whichbutton == -1)
        return;
      this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
    }

    private void drawcontrols()
    {
      this.backgroundPlay();
      this.spriteBatch.Draw(this.sc.titleBG, this.sc.origSize, Color.White);
      this.spriteBatch.Draw(this.sc.titlePig2, new Vector2(475f, 399f), new Rectangle?(new Rectangle(0, 0, 400, 260)), Color.White, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
      this.spriteBatch.Draw(this.sc.titleHeaderControls, this.sc.origSize, Color.White);
      this.drawHelper("keyboard", 3, 0, 35f);
      this.drawHelper("hot-keys", 3, 1, 35f);
      this.drawHelper("gamepad", 3, 2, 35f);
      if (this.covered || !this.sc.Game.IsMouseVisible)
        return;
      this.queryButton(this.secretCoop, 13);
      if (this.lastbutton == this.whichbutton || this.whichbutton == -1)
        return;
      this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
    }

    private void drawdisplay()
    {
      if (this.showInstruct)
        this.spriteBatch.Draw(this.sc.instructions, new Vector2((float) (640 - this.sc.instructions.Width / 2), (float) (360 - this.sc.instructions.Height / 2)), Color.White);
      if (!this.showGamepad)
        return;
      this.spriteBatch.Draw(this.sc.controller, new Vector2((float) (640 - this.sc.controller.Width / 2), (float) (360 - this.sc.controller.Height / 2)), Color.White);
    }

    private void drawcooplobby()
    {
      if ((int) this.sc.myTimer % 250 == 1)
        this.sc.lobby.requestLobby(this.lobbynum);
      if (this.lobbynum == "6")
        this.spriteBatch.Draw(this.sc.titleHeaderLobbies2, this.sc.origSize, Color.White);
      else
        this.spriteBatch.Draw(this.sc.titleHeaderLobbies, this.sc.origSize, Color.White);
      for (int index = 0; index < 21; ++index)
      {
        Color color = new Color(58, 181, 51, (int) byte.MaxValue);
        string text;
        if (index < this.sc.lobby.lobbys.Count)
        {
          if (this.whichKEY == index)
            color = Color.White;
          text = this.sc.lobby.lobbys[index].name;
          this.spriteBatch.DrawString(this.sc.font2, this.sc.lobby.lobbys[index].name, this.nameSpot[index] - this.sc.font2.MeasureString(this.sc.lobby.lobbys[index].name) / 2f, color);
        }
        else
        {
          text = "empty-slot";
          color = new Color(190, 90, 90, (int) byte.MaxValue);
          if (this.whichKEY == index)
            color = Color.White;
          this.spriteBatch.DrawString(this.sc.font2, "empty-slot", this.nameSpot[index] - this.sc.font2.MeasureString("empty-slot") / 2f, color);
        }
        if (this.mousemoving)
        {
          Vector2 vector2 = this.sc.font2.MeasureString(text);
          this.queryKeySquare(new Rectangle((int) ((double) this.nameSpot[index].X - (double) vector2.X / 2.0), (int) ((double) this.nameSpot[index].Y - (double) vector2.Y / 2.0), (int) vector2.X, (int) vector2.Y), index);
        }
      }
    }

    private void drawvideos()
    {
      this.backgroundPlay();
      this.menuMusic.Volume = this.sc.mv;
      this.spriteBatch.Draw(this.sc.titleBG, this.sc.origSize, Color.White);
      this.spriteBatch.Draw(this.sc.titlePig3, new Vector2(475f, 399f), new Rectangle?(new Rectangle(0, 0, 400, 260)), Color.White, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
      this.spriteBatch.Draw(this.sc.titleHeaderVideos, this.sc.origSize, Color.White);
      if (this.IsActive)
      {
        this.drawHelper("credits", 3, 0, 35f);
        this.drawHelper("trailer", 3, 1, 35f);
        this.drawHelper("back", 3, 2, 35f);
      }
      if (this.covered || !this.sc.Game.IsMouseVisible || this.lastbutton == this.whichbutton || this.whichbutton == -1)
        return;
      this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
    }

    private void drawgraphics()
    {
      this.backgroundPlay();
      this.spriteBatch.Draw(this.sc.titleBG, this.sc.origSize, Color.White);
      this.spriteBatch.Draw(this.sc.titlePig3, new Vector2(475f, 399f), new Rectangle?(new Rectangle(0, 0, 400, 260)), Color.White, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
      int num1 = 346;
      int num2 = 640;
      int num3 = 934;
      this.spriteBatch.Draw(this.sc.titleCharsGraphics, this.sc.origSize, Color.White);
      string text1 = "Aliasing " + (object) this.sc.aa;
      this.spriteBatch.DrawString(this.font2, text1, new Vector2((float) (640.0 - (double) this.font2.MeasureString(text1).X / 2.0), 250f), Color.White);
      string resname = this.sc.resnames[this.sc.setupnum];
      this.spriteBatch.DrawString(this.font2, resname, new Vector2((float) (346.0 - (double) this.font2.MeasureString(resname).X / 2.0), 250f), Color.White);
      this.spriteBatch.DrawString(this.font2, Math.Round((double) this.sc.aspectratio, 1).ToString(), new Vector2((float) (934.0 - (double) this.font2.MeasureString(Math.Round((double) this.sc.aspectratio, 1).ToString()).X / 2.0), 250f), Color.White);
      if (this.IsActive)
      {
        this.drawHelper("apply", 2, 0, 45f);
        this.drawHelper("back", 2, 1, 45f);
      }
      int x1 = num1 + 5;
      int x2 = num1 - (this.arrowdown.Width + 5);
      int x3 = num2 + 5;
      int x4 = num2 - (this.arrowdown.Width + 5);
      int x5 = num3 + 5;
      int x6 = num3 - (this.arrowdown.Width + 5);
      int y = 140;
      if (!this.covered && this.sc.Game.IsMouseVisible)
      {
        Rectangle rr = new Rectangle(x2, y, this.arrowfill.Width, this.arrowfill.Height);
        this.queryButton(rr, 5);
        rr = new Rectangle(x1, y, this.arrowfill.Width, this.arrowfill.Height);
        this.queryButton(rr, 6);
        rr = new Rectangle(x4, y, this.arrowfill.Width, this.arrowfill.Height);
        this.queryButton(rr, 7);
        rr = new Rectangle(x3, y, this.arrowfill.Width, this.arrowfill.Height);
        this.queryButton(rr, 8);
        rr = new Rectangle(x5, y, this.arrowfill.Width, this.arrowfill.Height);
        this.queryButton(rr, 9);
        rr = new Rectangle(x6, y, this.arrowfill.Width, this.arrowfill.Height);
        this.queryButton(rr, 10);
        rr = new Rectangle(330, 321, 34, 34);
        this.queryButton(rr, 11);
        rr = new Rectangle(330, 375, 34, 34);
        this.queryButton(rr, 12);
        if (this.lastbutton != this.whichbutton && this.whichbutton != -1)
          this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
      }
      if (this.whichbutton == 5 || this.highlight == 5)
        this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2((float) x2, (float) y), new Rectangle?(this.arrowfill), Color.White);
      this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2((float) x2, (float) y), new Rectangle?(this.arrowdown), Color.White);
      if (this.whichbutton == 6 || this.highlight == 6)
        this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2((float) x1, (float) y), new Rectangle?(this.arrowfill), Color.White);
      this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2((float) x1, (float) y), new Rectangle?(this.arrowup), Color.White);
      if (this.whichbutton == 7 || this.highlight == 7)
        this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2((float) x4, (float) y), new Rectangle?(this.arrowfill), Color.White);
      this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2((float) x4, (float) y), new Rectangle?(this.arrowleft), Color.White);
      if (this.whichbutton == 8 || this.highlight == 8)
        this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2((float) x3, (float) y), new Rectangle?(this.arrowfill), Color.White);
      this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2((float) x3, (float) y), new Rectangle?(this.arrowright), Color.White);
      if (this.whichbutton == 9 || this.highlight == 9)
        this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2((float) x5, (float) y), new Rectangle?(this.arrowfill), Color.White);
      this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2((float) x5, (float) y), new Rectangle?(this.arrowplus), Color.White);
      if (this.whichbutton == 10 || this.highlight == 10)
        this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2((float) x6, (float) y), new Rectangle?(this.arrowfill), Color.White);
      this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2((float) x6, (float) y), new Rectangle?(this.arrowminus), Color.White);
      if (!this.sc.fullmode)
        this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2(330f, 321f), new Rectangle?(this.redboxfill), Color.White);
      else
        this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2(330f, 321f), new Rectangle?(this.redbox), Color.White);
      if (!this.sc.border)
        this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2(330f, 375f), new Rectangle?(this.redboxfill), Color.White);
      else
        this.spriteBatch.Draw(this.sc.menuBlob2, new Vector2(330f, 375f), new Rectangle?(this.redbox), Color.White);
      string text2 = "F10 WINDOWED  ";
      this.spriteBatch.DrawString(this.font2, text2, new Vector2(330f - this.font2.MeasureString(text2).X, 320f), Color.White);
      string text3 = "F9 NO BORDERS ";
      this.spriteBatch.DrawString(this.font2, text3, new Vector2(330f - this.font2.MeasureString(text3).X, 374f), Color.White);
      this.drawData();
    }

    private void drawaudio()
    {
      this.spriteBatch.Draw(this.sc.titleBG, this.sc.origSize, Color.White);
      this.spriteBatch.Draw(this.sc.titlePig3, new Vector2(475f, 399f), new Rectangle?(new Rectangle(0, 0, 400, 260)), Color.White, 0.0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0.0f);
      this.spriteBatch.Draw(this.sc.titleHeaderAudio, this.sc.origSize, Color.White);
      if (this.IsActive)
      {
        this.drawHelper("save", 2, 0, 65f);
        this.drawHelper("back", 2, 1, 65f);
      }
      if (!this.covered && this.sc.Game.IsMouseVisible && this.lastbutton != this.whichbutton && this.whichbutton != -1)
        this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
      int index = this.myIndex;
      this.myIndex = -1;
      Vector2 vector2_1 = new Vector2(640f, 240f);
      Vector2 vector2_2 = new Vector2(-120f, -100f);
      this.spriteBatch.DrawString(this.sc.scribblefont, this.slider1.ToString(), new Vector2(vector2_2.X + 350f, vector2_2.Y + 25f) + vector2_1 - this.sc.scribblefont.MeasureString(this.slider1.ToString()) / 2f, Color.White);
      this.queryButtonX(this.sliderBoxRect, vector2_1 + vector2_2 + new Vector2(105f + this.sliderbox1, 4f), 0);
      this.spriteBatch.Draw(this.sc.paper1, vector2_1 + vector2_2 + new Vector2(-40f, 20f), new Rectangle?(this.sliderRect), Color.White);
      if (this.myIndex != 0 && this.whichbutton != 2)
        this.spriteBatch.Draw(this.sc.paper1, vector2_1 + vector2_2 + new Vector2(105f + this.sliderbox1, 4f), new Rectangle?(this.sliderBoxRect), Color.White);
      else
        this.spriteBatch.Draw(this.sc.paper1, vector2_1 + vector2_2 + new Vector2(105f + this.sliderbox1, 4f), new Rectangle?(this.sliderGlowRect), Color.White);
      vector2_2 = new Vector2(-120f, -50f);
      this.spriteBatch.DrawString(this.sc.scribblefont, this.slider2.ToString(), new Vector2(vector2_2.X + 350f, vector2_2.Y + 25f) + vector2_1 - this.sc.scribblefont.MeasureString(this.slider2.ToString()) / 2f, Color.White);
      this.queryButtonX(this.sliderBoxRect, vector2_1 + vector2_2 + new Vector2(105f + this.sliderbox2, 4f), 1);
      this.spriteBatch.Draw(this.sc.paper1, vector2_1 + vector2_2 + new Vector2(-40f, 20f), new Rectangle?(this.sliderRect), Color.White);
      if (this.myIndex != 1 && this.whichbutton != 3)
        this.spriteBatch.Draw(this.sc.paper1, vector2_1 + vector2_2 + new Vector2(105f + this.sliderbox2, 4f), new Rectangle?(this.sliderBoxRect), Color.White);
      else
        this.spriteBatch.Draw(this.sc.paper1, vector2_1 + vector2_2 + new Vector2(105f + this.sliderbox2, 4f), new Rectangle?(this.sliderGlowRect), Color.White);
      vector2_2 = new Vector2(-120f, 0.0f);
      this.spriteBatch.DrawString(this.sc.scribblefont, this.slider3.ToString(), new Vector2(vector2_2.X + 350f, vector2_2.Y + 25f) + vector2_1 - this.sc.scribblefont.MeasureString(this.slider3.ToString()) / 2f, Color.White);
      this.queryButtonX(this.sliderBoxRect, vector2_1 + vector2_2 + new Vector2(105f + this.sliderbox3, 4f), 2);
      this.spriteBatch.Draw(this.sc.paper1, vector2_1 + vector2_2 + new Vector2(-40f, 20f), new Rectangle?(this.sliderRect), Color.White);
      if (this.myIndex != 2 && this.whichbutton != 4)
        this.spriteBatch.Draw(this.sc.paper1, vector2_1 + vector2_2 + new Vector2(105f + this.sliderbox3, 4f), new Rectangle?(this.sliderBoxRect), Color.White);
      else
        this.spriteBatch.Draw(this.sc.paper1, vector2_1 + vector2_2 + new Vector2(105f + this.sliderbox3, 4f), new Rectangle?(this.sliderGlowRect), Color.White);
      if (index == this.myIndex || this.myIndex == -1)
        return;
      this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
    }

    private void drawdiary()
    {
      this.spriteBatch.Draw(this.sc.titleHeaderDiary, this.sc.origSize, Color.White);
      if (this.sc.developer)
      {
        if (this.recording1 && (double) this.sc.myTimer % 15.0 < 7.0)
          this.spriteBatch.DrawString(this.deadfont, "Record Body", new Vector2(700f, 20f), Color.White);
        if (this.recording2 && (double) this.sc.myTimer % 15.0 < 7.0)
          this.spriteBatch.DrawString(this.deadfont, "Record Sprites", new Vector2(700f, 20f), Color.Green);
        if (this.recording3 && (double) this.sc.myTimer % 15.0 < 7.0)
          this.spriteBatch.DrawString(this.deadfont, "Record RotScale", new Vector2(700f, 20f), Color.Yellow);
        if (this.recording4 && (double) this.sc.myTimer % 15.0 < 7.0)
          this.spriteBatch.DrawString(this.deadfont, "Record Lights", new Vector2(700f, 20f), Color.Yellow);
      }
      if (this.sc.workshop.entry.Count <= 0)
        return;
      this.sc.workshop.entryIndex = (int) MathHelper.Clamp((float) this.sc.workshop.entryIndex, 0.0f, (float) (this.sc.workshop.entry.Count - 1));
      bool flag = false;
      byte a = byte.MaxValue;
      if (this.farmerJawIndex != -1)
        a = (byte) 50;
      for (int index = 0; index < this.sc.workshop.entry.Count; ++index)
      {
        this.queryButton(this.sc.workshop.entryBox[index], index);
        Vector2 position = new Vector2((float) this.sc.workshop.entryBox[index].X, (float) (this.sc.workshop.entryBox[index].Y - 10));
        string[] strArray = this.sc.workshop.entry[index].dates.Split('.');
        string text1 = this.months[Convert.ToInt32(strArray[0])] + "." + strArray[1];
        string text2 = "";
        Color color1 = new Color(120, 120, 160, (int) a);
        Color color2 = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) a);
        if (strArray[2].Length == 4)
        {
          text1 = this.months[Convert.ToInt32(strArray[0])] + "." + strArray[1];
          text2 = strArray[2];
          color1 = new Color(90, 90, 90, (int) a);
        }
        if (strArray[2].Length == 2 && !flag)
        {
          flag = true;
          if (this.whichbutton == index)
          {
            if (this.farmerJawIndex == -1 && this.followPoint)
            {
              this.followPoint = false;
              this.followTimer = 200f;
              this.lastlookpos = this.lookpos[this.lookIndex];
              this.followTween = 1f;
            }
            this.spriteBatch.DrawString(this.diaryfont, text1, position, color2, 0.0f, Vector2.Zero, 1.6f, SpriteEffects.None, 0.0f);
          }
          else
            this.spriteBatch.DrawString(this.diaryfont, text1, position, color1, 0.0f, Vector2.Zero, 1.6f, SpriteEffects.None, 0.0f);
        }
        else if (this.whichbutton == index)
        {
          if (this.farmerJawIndex == -1 && this.followPoint)
          {
            this.followPoint = false;
            this.followTimer = 200f;
            this.lastlookpos = this.lookpos[this.lookIndex];
            this.followTween = 1f;
          }
          this.spriteBatch.DrawString(this.diaryfont, text1, position, color2);
          this.spriteBatch.DrawString(this.diaryfont, text2, position + new Vector2(75f, 0.0f), color2);
        }
        else
        {
          this.spriteBatch.DrawString(this.diaryfont, text1, position, color1);
          this.spriteBatch.DrawString(this.diaryfont, text2, position + new Vector2(75f, 0.0f), color1);
        }
      }
      if (this.lastbutton != this.whichbutton && this.whichbutton != -1)
        this.sc.tick.Play(this.sc.ev, 0.2f, 0.0f);
      if (this.farmerJawIndex == -1 || this.sc.workshop.entry.Count <= 0)
        return;
      int entryIndex = this.sc.workshop.entryIndex;
      for (int index = this.displayList.Count - 1; index >= 0; --index)
      {
        int display = this.displayList[index];
        if (this.im[display].show && this.sc.workshop.entry[entryIndex].media.Count > this.im[display].spriteIndex)
        {
          this.im[display].tween += this.im[display].tweenRate;
          Vector2 position = this.im[display].pos;
          if ((double) this.im[display].tween > 1.0)
          {
            this.im[display].tween = 1f;
            this.im[display].oldpos = this.im[display].pos;
          }
          else
            position = Vector2.Lerp(this.im[display].oldpos, this.im[display].pos, this.im[display].tween);
          Texture2D medium = this.sc.workshop.entry[entryIndex].media[this.im[display].spriteIndex];
          Vector2 origin = new Vector2((float) (medium.Width / 2), (float) (medium.Height / 2));
          if (this.im[display].full)
            this.spriteBatch.Draw(medium, new Rectangle(0, 0, 1280, 720), Color.White);
          else
            this.spriteBatch.Draw(medium, position, new Rectangle?(), Color.White, this.im[display].rot, origin, this.im[display].scale, this.im[display].flip, 0.0f);
        }
      }
    }

    private void drawworkshop()
    {
      this.backgroundPlay();
      this.spriteBatch.Draw(this.sc.titleBG, this.sc.origSize, Color.White);
      this.spriteBatch.Draw(this.sc.titleHeaderWorkshop, this.sc.origSize, Color.White);
      if (this.drawsubs)
      {
        this.spriteBatch.Draw(this.sc.titleHeaderWorkshop2, this.workshopBottomSubtitle, new Rectangle?(this.workshopBottomSubtitle), Color.White);
        if (!this.sc.workshop.textureBusy && this.sc.workshop.crosshairS.Count > this.subRow * 5)
        {
          for (int index = this.subRow * 5; index < this.subRow * 5 + 5 && index <= this.sc.workshop.crosshairS.Count - 1; ++index)
          {
            this.spriteBatch.Draw(this.sc.whiteTexture, new Rectangle(154 + index % 5 * 205, 471, 150, 150), new Color(35, 35, 35, (int) byte.MaxValue));
            this.spriteBatch.Draw(this.sc.workshop.crosshairS[index], new Rectangle(154 + index % 5 * 205, 471, 150, 150), Color.White);
          }
        }
      }
      if (this.drawcustom)
      {
        this.spriteBatch.Draw(this.sc.titleHeaderWorkshop2, this.workshopBottomSubtitle, new Rectangle?(this.workshopBottomCustitle), Color.White);
        if (this.sc.crosshairC.Count > this.subRow * 5)
        {
          for (int index = this.subRow * 5; index < this.subRow * 5 + 5 && index <= this.sc.crosshairC.Count - 1; ++index)
          {
            this.spriteBatch.Draw(this.sc.whiteTexture, new Rectangle(154 + index % 5 * 205, 471, 150, 150), new Color(35, 35, 35, (int) byte.MaxValue));
            this.spriteBatch.Draw(this.sc.crosshairC[index], new Rectangle(154 + index % 5 * 205, 471, 150, 150), Color.White);
          }
        }
      }
      if (this.subRow == 0)
        this.spriteBatch.Draw(this.sc.titleHeaderWorkshop2, this.workshopNumsX, new Rectangle?(this.workshopNums1), Color.White);
      else if (this.subRow == 1)
        this.spriteBatch.Draw(this.sc.titleHeaderWorkshop2, this.workshopNumsX, new Rectangle?(this.workshopNums2), Color.White);
      else if (this.subRow == 2)
        this.spriteBatch.Draw(this.sc.titleHeaderWorkshop2, this.workshopNumsX, new Rectangle?(this.workshopNums3), Color.White);
      else if (this.subRow == 3)
        this.spriteBatch.Draw(this.sc.titleHeaderWorkshop2, this.workshopNumsX, new Rectangle?(this.workshopNums4), Color.White);
      for (int index = 1; index < 4; ++index)
      {
        if (this.sc.crosshair1[index].type == 1)
        {
          this.spriteBatch.Draw(this.sc.titleHeaderWorkshop2, new Rectangle(154 + index * 205, 141, 150, 150), new Rectangle?(this.rectangle_0), Color.White);
          this.spriteBatch.Draw(this.sc.crosshair1[index].texture, new Rectangle(154 + index * 205, 141, 150, 150), Color.White);
          if (index == 1)
            this.spriteBatch.Draw(this.sc.titleHeaderWorkshop2, this.workshopDelbox1, new Rectangle?(this.workshopRedbox), Color.White);
          if (index == 2)
            this.spriteBatch.Draw(this.sc.titleHeaderWorkshop2, this.workshopDelbox2, new Rectangle?(this.workshopRedbox), Color.White);
          if (index == 3)
            this.spriteBatch.Draw(this.sc.titleHeaderWorkshop2, this.workshopDelbox3, new Rectangle?(this.workshopRedbox), Color.White);
        }
      }
      if (!this.sc.workshop.showPublishbox)
      {
        this.drawHelper4("CUSTOM", 4, 0, 15f, false);
        this.drawHelper4("SUBSCRIBE", 4, 1, 15f, false);
        string mess = "PUBLISH";
        bool flash = false;
        if (this.sc.workshop.status == "WORK")
        {
          mess = this.sc.workshop.workstatus;
          flash = true;
        }
        if (this.sc.workshop.status == "FAIL")
          mess = "FAIL";
        if (this.sc.workshop.status == "DONE")
          mess = "DONE";
        if (this.sc.crosshair1[this.workshopChosen].legal)
          this.drawHelper4(mess, 4, 2, 15f, flash);
        if (!this.sc.crosshair1[this.workshopChosen].legal)
          this.drawHelper5(mess, 4, 2, 15f, flash);
        this.drawHelper4("BACK", 4, 3, 15f, false);
      }
      if (!this.covered && this.sc.Game.IsMouseVisible)
      {
        if (this.sc.workshop.showPublishbox)
        {
          this.queryButton(this.formTitle, 4);
          this.queryButton(this.formDescr, 5);
          this.queryButton(this.formBut1, 6);
          this.queryButton(this.formBut2, 7);
          this.queryButton(this.formBut3, 8);
          this.queryButton(this.formBut4, 9);
          this.queryButton(this.formBut5, 10);
          this.queryButton(this.rectangle_6, 66);
          this.queryButton(this.rectangle_7, 67);
          this.queryButton(this.rectangle_8, 68);
          this.queryButton(this.rectangle_9, 69);
          this.queryButton(this.rectangle_10, 70);
          this.queryButton(this.formPublic, 11);
          this.queryButton(this.formPrivate, 12);
          this.queryButton(this.formFriends, 13);
          this.queryButton(this.formTerms, 14);
          this.queryButton(this.formCancel, 15);
          this.queryButton(this.formPublish, 16);
          this.queryButton(this.formTag[0], 40);
          this.queryButton(this.formTag[1], 41);
          this.queryButton(this.formTag[2], 42);
          this.queryButton(this.formTag[3], 43);
          this.queryButton(this.formTag[4], 44);
          this.queryButton(this.formTag[5], 45);
          this.queryButton(this.formTag[6], 46);
          this.queryButton(this.formTag[7], 47);
          this.queryButton(this.formTag[8], 48);
          this.queryButton(this.formWaterMark, 50);
          if (this.lastbutton != this.whichbutton && this.whichbutton != -1)
            this.sc.tick.Play(this.sc.ev, 0.1f, 0.0f);
          this.queryButton(this.formCenter, 80);
          this.queryButton(this.formLeft, 81);
          this.queryButton(this.formRight, 82);
          this.queryButton(this.formDown, 83);
          this.queryButton(this.formUp, 84);
          this.queryButton(this.formCorner1, 85);
          this.queryButton(this.formCorner2, 86);
          this.queryButton(this.formCorner3, 87);
          this.queryButton(this.formCorner4, 88);
        }
        else
        {
          this.queryButton(this.workshopt1, 20);
          this.queryButton(this.workshopt2, 21);
          this.queryButton(this.workshopt3, 22);
          this.queryButton(this.workshopb1, 23);
          this.queryButton(this.workshopb2, 24);
          this.queryButton(this.workshopb3, 25);
          this.queryButton(this.workshopb4, 26);
          this.queryButton(this.workshopb5, 27);
          this.queryButton(this.workshopLeftarrow, 28);
          this.queryButton(this.workshopRightarrow, 29);
          if (this.sc.crosshair1[1].type == 1)
            this.queryButton(this.workshopDelbox1, 30);
          if (this.sc.crosshair1[2].type == 1)
            this.queryButton(this.workshopDelbox2, 31);
          if (this.sc.crosshair1[3].type == 1)
            this.queryButton(this.workshopDelbox3, 32);
          if (this.lastbutton != this.whichbutton && this.whichbutton != -1)
          {
            if (this.whichbutton >= 23 && this.whichbutton <= 27)
            {
              if (this.whichbutton == 23)
                this.sc.tick.Play(this.sc.ev * 0.6f, -0.7f, 0.0f);
              if (this.whichbutton == 24)
                this.sc.tick.Play(this.sc.ev * 0.6f, -0.65f, 0.0f);
              if (this.whichbutton == 25)
                this.sc.tick.Play(this.sc.ev * 0.6f, -0.55f, 0.0f);
              if (this.whichbutton == 26)
                this.sc.tick.Play(this.sc.ev * 0.6f, -0.5f, 0.0f);
              if (this.whichbutton == 27)
                this.sc.tick.Play(this.sc.ev * 0.6f, -0.45f, 0.0f);
            }
            else if (this.whichbutton >= 20 && this.whichbutton <= 22)
            {
              if (this.whichbutton == 20)
                this.sc.tick.Play(this.sc.ev * 0.6f, -0.3f, 0.0f);
              if (this.whichbutton == 21)
                this.sc.tick.Play(this.sc.ev * 0.6f, -0.25f, 0.0f);
              if (this.whichbutton == 22)
                this.sc.tick.Play(this.sc.ev * 0.6f, -0.2f, 0.0f);
            }
            else
              this.sc.tick.Play(this.sc.ev, 0.0f, 0.0f);
          }
        }
      }
      if (!this.sc.workshop.showPublishbox)
      {
        if (this.whichbutton == 20)
          this.spriteBatch.Draw(this.sc.titleHeaderWorkshop2, this.workshopt1, new Rectangle?(this.workshopt1), Color.White);
        if (this.whichbutton == 21)
          this.spriteBatch.Draw(this.sc.titleHeaderWorkshop2, this.workshopt2, new Rectangle?(this.workshopt1), Color.White);
        if (this.whichbutton == 22)
          this.spriteBatch.Draw(this.sc.titleHeaderWorkshop2, this.workshopt3, new Rectangle?(this.workshopt1), Color.White);
        ++this.flashindex;
        this.flashindex %= this.flashing.Length;
        if (this.workshopChosen == 1)
          this.spriteBatch.Draw(this.sc.titleHeaderWorkshop2, this.rectangle_3, new Rectangle?(this.rectangle_5), this.flashing[this.flashindex]);
        if (this.workshopChosen == 2)
          this.spriteBatch.Draw(this.sc.titleHeaderWorkshop2, this.rectangle_4, new Rectangle?(this.rectangle_5), this.flashing[this.flashindex]);
        if (this.workshopChosen == 3)
          this.spriteBatch.Draw(this.sc.titleHeaderWorkshop2, this.rectangle_5, new Rectangle?(this.rectangle_5), this.flashing[this.flashindex]);
        if (this.whichbutton == 23)
          this.spriteBatch.Draw(this.sc.titleHeaderWorkshop2, this.workshopb1, new Rectangle?(this.workshopb1), Color.White);
        if (this.whichbutton == 24)
          this.spriteBatch.Draw(this.sc.titleHeaderWorkshop2, this.workshopb2, new Rectangle?(this.workshopb2), Color.White);
        if (this.whichbutton == 25)
          this.spriteBatch.Draw(this.sc.titleHeaderWorkshop2, this.workshopb3, new Rectangle?(this.workshopb3), Color.White);
        if (this.whichbutton == 26)
          this.spriteBatch.Draw(this.sc.titleHeaderWorkshop2, this.workshopb4, new Rectangle?(this.workshopb4), Color.White);
        if (this.whichbutton == 27)
          this.spriteBatch.Draw(this.sc.titleHeaderWorkshop2, this.workshopb5, new Rectangle?(this.workshopb5), Color.White);
        if (this.whichbutton == 28)
          this.spriteBatch.Draw(this.sc.titleHeaderWorkshop2, this.workshopLeftarrow, new Rectangle?(this.workshopLeftarrow), Color.White);
        if (this.whichbutton == 29)
          this.spriteBatch.Draw(this.sc.titleHeaderWorkshop2, this.workshopRightarrow, new Rectangle?(this.workshopRightarrow), Color.White);
      }
      if (!this.sc.workshop.showPublishbox)
        return;
      this.spriteBatch.Draw(this.sc.titleHeaderWorkshopPublish, this.sc.origSize, Color.White);
      if (this.formDrawBG)
        this.spriteBatch.Draw(this.sc.whiteTexture, this.formPreview, this.color_0[this.formBGColorindex]);
      Rectangle rectangle = new Rectangle(this.zoomX, this.zoomY, this.sc.crosshair1[this.workshopChosen].texture.Width - 2 * this.zoomX, this.sc.crosshair1[this.workshopChosen].texture.Height - 2 * this.zoomY);
      this.sc.zoomRectangle = rectangle;
      this.spriteBatch.Draw(this.sc.crosshair1[this.workshopChosen].texture, this.formPreview, new Rectangle?(rectangle), Color.White);
      this.spriteBatch.DrawString(this.sc.fontsmall, this.sc.workshop.formTitle, new Vector2(344f, 181f), Color.White);
      this.spriteBatch.DrawString(this.sc.fontsmall, this.sc.workshop.formMark, new Vector2(344f, 349f), Color.White);
      this.me.Clear();
      string[] strArray = this.sc.workshop.formDescr.Split(' ');
      string str = "";
      bool flag = false;
      for (int index = 0; index < strArray.Length; ++index)
      {
        str = str + strArray[index] + " ";
        flag = false;
        if (str.Length > 29)
        {
          this.me.Add(str + "\n");
          str = "";
          flag = true;
        }
      }
      if (!flag)
        this.me.Add(str);
      for (int index = 0; index < this.me.Count; ++index)
      {
        float x = 344f;
        float y = (float) (259 + 18 * index);
        this.spriteBatch.DrawString(this.sc.fontsmall, this.me[index], new Vector2(x, y), Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
      }
      if (this.whichbutton == 4)
        this.spriteBatch.Draw(this.sc.titleHeaderWorkshopPublish2, this.formTitle, new Rectangle?(this.formTitle), Color.White);
      if (this.whichbutton == 5)
        this.spriteBatch.Draw(this.sc.titleHeaderWorkshopPublish2, this.formDescr, new Rectangle?(this.formDescr), Color.White);
      if (this.whichbutton == 50)
        this.spriteBatch.Draw(this.sc.titleHeaderWorkshopPublish2, this.formWaterMark, new Rectangle?(this.formWaterMark), Color.White);
      if (this.whichbutton == 6)
        this.spriteBatch.Draw(this.sc.titleHeaderWorkshopPublish2, this.formBut1, new Rectangle?(this.formBut1), Color.White);
      if (this.whichbutton == 7)
        this.spriteBatch.Draw(this.sc.titleHeaderWorkshopPublish2, this.formBut2, new Rectangle?(this.formBut2), Color.White);
      if (this.whichbutton == 8)
        this.spriteBatch.Draw(this.sc.titleHeaderWorkshopPublish2, this.formBut3, new Rectangle?(this.formBut3), Color.White);
      if (this.whichbutton == 9)
        this.spriteBatch.Draw(this.sc.titleHeaderWorkshopPublish2, this.formBut4, new Rectangle?(this.formBut4), Color.White);
      if (this.whichbutton == 10)
        this.spriteBatch.Draw(this.sc.titleHeaderWorkshopPublish2, this.formBut5, new Rectangle?(this.formBut5), Color.White);
      if (this.whichbutton == 66)
        this.spriteBatch.Draw(this.sc.titleHeaderWorkshopPublish2, this.rectangle_6, new Rectangle?(this.rectangle_6), Color.White);
      if (this.whichbutton == 67)
        this.spriteBatch.Draw(this.sc.titleHeaderWorkshopPublish2, this.rectangle_7, new Rectangle?(this.rectangle_7), Color.White);
      if (this.whichbutton == 68)
        this.spriteBatch.Draw(this.sc.titleHeaderWorkshopPublish2, this.rectangle_8, new Rectangle?(this.rectangle_8), Color.White);
      if (this.whichbutton == 69)
        this.spriteBatch.Draw(this.sc.titleHeaderWorkshopPublish2, this.rectangle_9, new Rectangle?(this.rectangle_9), Color.White);
      if (this.whichbutton == 70)
        this.spriteBatch.Draw(this.sc.titleHeaderWorkshopPublish2, this.rectangle_10, new Rectangle?(this.rectangle_10), Color.White);
      if (this.whichbutton == 11)
        this.spriteBatch.Draw(this.sc.titleHeaderWorkshopPublish2, this.formPublic, new Rectangle?(this.formPublic), Color.White);
      if (this.whichbutton == 12)
        this.spriteBatch.Draw(this.sc.titleHeaderWorkshopPublish2, this.formPrivate, new Rectangle?(this.formPrivate), Color.White);
      if (this.whichbutton == 13)
        this.spriteBatch.Draw(this.sc.titleHeaderWorkshopPublish2, this.formFriends, new Rectangle?(this.formFriends), Color.White);
      if (this.whichbutton == 14)
        this.spriteBatch.Draw(this.sc.titleHeaderWorkshopPublish2, this.formTerms, new Rectangle?(this.formTerms), Color.White);
      if (this.whichbutton == 15)
        this.spriteBatch.Draw(this.sc.titleHeaderWorkshopPublish2, this.formCancel, new Rectangle?(this.formCancel), Color.White);
      if (this.whichbutton == 16)
        this.spriteBatch.Draw(this.sc.titleHeaderWorkshopPublish2, this.formPublish, new Rectangle?(this.formPublish), Color.White);
      if (this.sc.workshop.formVisibility == this.sc.workshop.seePublic)
        this.spriteBatch.Draw(this.sc.titleHeaderWorkshopPublish2, new Vector2(348f, 413f), new Rectangle?(this.formCheckbox), Color.White);
      if (this.sc.workshop.formVisibility == this.sc.workshop.seePrivate)
        this.spriteBatch.Draw(this.sc.titleHeaderWorkshopPublish2, new Vector2(457f, 413f), new Rectangle?(this.formCheckbox), Color.White);
      if (this.sc.workshop.formVisibility == this.sc.workshop.seeFriends)
        this.spriteBatch.Draw(this.sc.titleHeaderWorkshopPublish2, new Vector2(562f, 413f), new Rectangle?(this.formCheckbox), Color.White);
      this.spriteBatch.Draw(this.sc.titleHeaderWorkshopPublish2, this.formTag[this.formtagIndex], new Rectangle?(this.formTag[this.formtagIndex]), Color.White);
      if (!this.formDrawBand)
        return;
      this.spriteBatch.Draw(this.sc.titleHeaderWorkshopPublish2, this.formBandL, new Rectangle?(this.formBand), this.formBandColor[this.formBandColorIndex]);
      if (!(this.sc.workshop.formMark != ""))
        return;
      this.spriteBatch.DrawString(this.font3, this.sc.workshop.formMark, new Vector2(748f, 113f), Color.Black, -0.78539f, this.font3.MeasureString(this.sc.workshop.formMark) / 2f, 1f, SpriteEffects.None, 0.0f);
    }

    private void drawFooter()
    {
      if (this.sc.errorMessageTimer > 0)
      {
        MainMenu.mybuilder.Length = 0;
        MainMenu.mybuilder.Append(this.sc.errorMessage);
        this.spriteBatch.DrawString(this.font, MainMenu.mybuilder, new Vector2(10f, 10f), Color.White);
      }
      this.spriteBatch.End();
      if (this.menuState != MainMenu.states.diary || !SteamAPI.IsSteamRunning())
        return;
      this.sc.GraphicsDevice.BlendState = BlendState.NonPremultiplied;
      this.sc.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
      this.sc.GraphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;
      this.drawFarmer();
    }

    public override void Draw(GameTime gameTime)
    {
      this.sc.GraphicsDevice.Clear(Color.Black);
      if (!this.sc.audioLoaded)
        return;
      if (this.menuState == MainMenu.states.diary)
        this.menuMusic.Volume = 0.0f;
      Matrix scale1 = Matrix.CreateScale((float) this.sc.screenSize.Width / (float) this.sc.origSize.Width, (float) this.sc.screenSize.Height / (float) this.sc.origSize.Height, 1f);
      this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.LinearClamp, (DepthStencilState) null, (RasterizerState) null, (Effect) null, scale1);
      --this.sc.errorMessageTimer;
      if ((double) this.titlecounter <= 0.0)
      {
        if (this.menuState == MainMenu.states.main)
        {
          this.drawmain();
          this.drawFooter();
          return;
        }
        if (this.menuState == MainMenu.states.more)
        {
          this.drawmore();
          this.drawFooter();
          return;
        }
        if (this.menuState == MainMenu.states.coopChoice)
        {
          this.drawcoopChoice();
          this.drawFooter();
          return;
        }
        if (this.menuState == MainMenu.states.multi2player)
        {
          this.drawmulti2player();
          this.drawFooter();
          return;
        }
        if (this.menuState == MainMenu.states.multi4player)
        {
          this.drawmulti4player();
          this.drawFooter();
          return;
        }
        if (this.menuState == MainMenu.states.multi6player)
        {
          this.drawmulti6player();
          this.drawFooter();
          return;
        }
        if (this.menuState == MainMenu.states.multi3player)
        {
          this.drawmulti3player();
          this.drawFooter();
          return;
        }
        if (this.menuState == MainMenu.states.playgame)
        {
          this.drawplaygame();
          this.drawFooter();
          return;
        }
        if (this.menuState == MainMenu.states.multijoinStart)
        {
          this.drawmultijoinstart();
          this.drawFooter();
          return;
        }
        if (this.menuState == MainMenu.states.multiHostStart)
        {
          this.drawmultihoststart();
          this.drawFooter();
          return;
        }
        if (this.menuState == MainMenu.states.cooplobby)
        {
          this.drawcooplobby();
          this.drawFooter();
          return;
        }
        if (this.menuState == MainMenu.states.settings)
        {
          this.drawsettings();
          this.drawFooter();
          return;
        }
        if (this.menuState == MainMenu.states.display)
        {
          this.drawdisplay();
          this.drawFooter();
          return;
        }
        if (this.menuState == MainMenu.states.controls)
        {
          this.drawcontrols();
          this.drawFooter();
          return;
        }
        if (this.menuState == MainMenu.states.graphics)
        {
          this.drawgraphics();
          this.drawFooter();
          return;
        }
        if (this.menuState == MainMenu.states.audio)
        {
          this.drawaudio();
          this.drawFooter();
          return;
        }
        if (this.menuState == MainMenu.states.videos)
        {
          this.drawvideos();
          this.drawFooter();
          return;
        }
        if (this.menuState == MainMenu.states.workshop)
        {
          this.drawworkshop();
          this.drawFooter();
          return;
        }
        if (this.menuState == MainMenu.states.diary)
        {
          this.drawdiary();
          this.drawFooter();
          return;
        }
        if (this.menuState == MainMenu.states.displaykeys)
        {
          this.sc.drawKeyBindings2(this.spriteBatch, ref this.whichKEY, ref this.thisKEY, this.font2);
          this.drawFooter();
          return;
        }
        if (this.menuState == MainMenu.states.trailer)
        {
          this.menuMusic.Volume = 0.0f;
          this.drawFooter();
          return;
        }
        if (this.menuState == MainMenu.states.credit)
        {
          this.menuMusic.Volume = 0.0f;
          this.drawFooter();
          return;
        }
        if (this.menuState == MainMenu.states.creditwall)
        {
          this.spriteBatch.Draw(this.sc.titleCreditBlank, this.sc.origSize, Color.White);
          this.spriteBatch.Draw(this.sc.titleCredit1, this.sc.origSize, Color.White);
          this.drawFooter();
          return;
        }
        if (this.menuState == MainMenu.states.alphateam)
        {
          this.spriteBatch.Draw(this.sc.titleCreditBlank, this.sc.origSize, Color.White);
          this.spriteBatch.Draw(this.sc.titleCredit2, this.sc.origSize, Color.White);
          this.drawFooter();
          return;
        }
      }
      else if ((double) this.titlecounter <= (double) this.counterStart)
      {
        Vector2 origin = new Vector2((float) this.sc.bc2.Width / 2f, (float) this.sc.bc2.Height / 2f);
        if ((double) this.ramp < 1.0 && (double) this.ramp + 0.070000000298023224 >= 1.0)
          this.sc.pileDriverSure.Play(this.sc.ev, -0.2f, 0.0f);
        this.ramp += 0.07f;
        if ((double) this.ramp > 1.0)
          this.ramp = 1f;
        float scale2 = MathHelper.Hermite(18f, 0.0f, 0.9f, 0.0f, this.ramp);
        Vector2 position = new Vector2((float) (this.sc.origSize.Width / 2), (float) (this.sc.origSize.Height / 2));
        if ((double) this.titlecounter > (double) (this.counterStart / 2))
          this.spriteBatch.Draw(this.sc.bc1, position, new Rectangle?(), Color.White, 0.0f, origin, scale2, SpriteEffects.None, 0.0f);
        else
          this.spriteBatch.Draw(this.sc.bc2, position, new Rectangle?(), Color.White, 0.0f, origin, scale2, SpriteEffects.None, 0.0f);
      }
      this.drawFooter();
    }

    public void drawInfo()
    {
      int curDay = this.sc.curDay;
      this.spriteBatch.DrawString(this.font2, "Start on Day " + (object) curDay, new Vector2(23f, 313f), Color.Black);
      this.spriteBatch.DrawString(this.font2, "Start on Day " + (object) curDay, new Vector2(20f, 310f), Color.White);
      int num = (int) this.sc.maxDay() + 1;
      if (num > 101)
        num = 101;
      if (num <= 1)
        return;
      this.spriteBatch.DrawString(this.font2, "Best Day " + (object) num, new Vector2(23f, 343f), Color.Black);
      this.spriteBatch.DrawString(this.font2, "Best Day " + (object) num, new Vector2(20f, 340f), Color.White);
    }

    public void drawData()
    {
      MainMenu.mybuilder.Length = 0;
      MainMenu.mybuilder.Append("Current Graphics");
      this.spriteBatch.DrawString(this.font2, MainMenu.mybuilder, new Vector2(30f, 50f), Color.White);
      MainMenu.mybuilder.Length = 0;
      MainMenu.mybuilder.Concat(this.sc.width);
      MainMenu.mybuilder.Append(" x ");
      MainMenu.mybuilder.Concat(this.sc.hite);
      this.spriteBatch.DrawString(this.font2, MainMenu.mybuilder, new Vector2(30f, 90f), Color.White);
      MainMenu.mybuilder.Length = 0;
      MainMenu.mybuilder.Append("AntiAlias ");
      MainMenu.mybuilder.Concat(this.sc.aliasing);
      this.spriteBatch.DrawString(this.font2, MainMenu.mybuilder, new Vector2(30f, 130f), Color.White);
    }

    private void exitGame()
    {
      MessageBoxScreen2 screen = new MessageBoxScreen2("You Finished?\n", 1);
      screen.Accepted += (EventHandler<PlayerIndexEventArgs>) ((sender, e) =>
      {
        this.abortThread();
        this.UnloadContent();
        this.ScreenManager.exitmyGame();
        this.exitMyGame = true;
      });
      screen.Cancelled += (EventHandler<PlayerIndexEventArgs>) ((sender, e) => this.delayinput = true);
      this.sc.AddScreen((GameScreen) screen, new PlayerIndex?());
    }

    private void CreateSpace(PlayerIndex playerindex)
    {
      this.sc.LoadAstro();
      this.disconnectData();
      this.menuMusic.Stop();
      this.abortThread();
      this.sc.Game.IsMouseVisible = false;
      this.sc.host = true;
      ((Form) Control.FromHandle(this.sc.Game.Window.Handle)).FormClosing -= new FormClosingEventHandler(this.Form1_KeyDown);
      this.sc.LoadAstroParameters();
      this.sc.inSpace = true;
      this.sc.bgindex = 1;
      this.sc.loadflag = 0;
      LoadingScreen1.Load(this.ScreenManager, true, new PlayerIndex?(playerindex), (NetworkSession) null, (GameScreen) new GameplayScreen(1f));
    }

    private void CreateSession(PlayerIndex playerindex)
    {
      this.sc.errorMessageTimer = 230;
      this.sc.errorMessage = "starting game . . .";
      this.sc.resetGame();
      this.sc.LoadGame(true);
      this.sc.LoadPrefs();
      this.sc.currentDay = this.sc.curDay;
      this.disconnectData();
      this.sc.gameState = 0;
      this.sc.gameSpectate = 1;
      this.sc.showTunnels = true;
      this.sc.gameSeed = this.rr.Next(1, 5000);
      this.menuMusic.Stop();
      this.abortThread();
      this.sc.Game.IsMouseVisible = false;
      this.sc.host = true;
      this.sc.playerindex = playerindex;
      ((Form) Control.FromHandle(this.sc.Game.Window.Handle)).FormClosing -= new FormClosingEventHandler(this.Form1_KeyDown);
      LoadingScreen1.Load(this.ScreenManager, true, new PlayerIndex?(playerindex), (NetworkSession) null, (GameScreen) new BloodnBacon((NetworkSession) null));
    }

    private void CreateCoopSession(PlayerIndex playerindex)
    {
      if ((this.sc.lobby.players == "4" || this.sc.lobby.players == "2" || this.sc.lobby.players == "6" ? 1 : (this.sc.lobby.players == "3" ? 1 : 0)) == 0)
      {
        this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
      }
      else
      {
        this.sc.showTunnels = false;
        this.sc.resetGame();
        this.sc.LoadGame(true);
        this.sc.LoadPrefs();
        this.sc.currentDay = this.sc.curDay;
        this.sc.hordemode = false;
        this.sc.paintland = false;
        if (this.sc.lobby.players == "6")
          this.sc.hordemode = true;
        if (this.sc.lobby.players == "3")
          this.sc.paintland = true;
        this.menuMusic.Stop();
        this.abortThread();
        this.sc.tempRifle = 2;
        this.sc.tempPistol = 2;
        this.sc.tempAmmo = 0;
        this.sc.tempMag = 0;
        this.sc.gameState = 0;
        this.sc.gameSpectate = 0;
        this.sc.gameSeed = this.rr.Next(1, 5000);
        this.sc.Game.IsMouseVisible = false;
        this.sc.host = true;
        this.disconnectData();
        ((Form) Control.FromHandle(this.sc.Game.Window.Handle)).FormClosing -= new FormClosingEventHandler(this.Form1_KeyDown);
        if (this.sc.lobby.players == "3")
        {
          this.sc.currentDay = 1;
          LoadingScreen1.Load(this.ScreenManager, true, new PlayerIndex?(playerindex), (NetworkSession) null, (GameScreen) new BloodnBacon3P((NetworkSession) null));
        }
        if (this.sc.lobby.players == "6")
          LoadingScreen1.Load(this.ScreenManager, true, new PlayerIndex?(playerindex), (NetworkSession) null, (GameScreen) new BloodnBacon6P((NetworkSession) null));
        if (this.sc.lobby.players == "2")
        {
          this.sc.showTunnels = true;
          this.sc.totalPlayers = 2;
          LoadingScreen1.Load(this.ScreenManager, true, new PlayerIndex?(playerindex), (NetworkSession) null, (GameScreen) new BloodnBacon4PT((NetworkSession) null));
        }
        if (!(this.sc.lobby.players == "4"))
          return;
        if (this.sc.lobby.ver == this.sc.lobby.version4Tunnel.ToString())
        {
          this.sc.tada3.Play(this.sc.ev, 0.0f, 0.0f);
          this.sc.showTunnels = true;
          this.sc.totalPlayers = 4;
          LoadingScreen1.Load(this.ScreenManager, true, new PlayerIndex?(playerindex), (NetworkSession) null, (GameScreen) new BloodnBacon4PT((NetworkSession) null));
        }
        else
        {
          this.sc.showTunnels = true;
          this.sc.totalPlayers = 4;
          LoadingScreen1.Load(this.ScreenManager, true, new PlayerIndex?(playerindex), (NetworkSession) null, (GameScreen) new BloodnBacon4PT((NetworkSession) null));
        }
      }
    }

    private void JoinCoopSession(PlayerIndex playerindex, int day)
    {
      if ((this.sc.lobby.lobbyplayers == "4" || this.sc.lobby.lobbyplayers == "2" || this.sc.lobby.lobbyplayers == "6" ? 1 : (this.sc.lobby.lobbyplayers == "3" ? 1 : 0)) == 0)
      {
        this.sc.abort.Play(this.sc.ev, 0.0f, 0.0f);
      }
      else
      {
        this.sc.showTunnels = false;
        this.sc.hordemode = false;
        this.sc.paintland = false;
        if (this.sc.lobby.lobbyplayers == "6")
          this.sc.hordemode = true;
        if (this.sc.lobby.lobbyplayers == "3")
          this.sc.paintland = true;
        this.sc.resetGame();
        this.sc.LoadGame(true);
        this.sc.LoadPrefs();
        this.sc.currentDay = day;
        this.sc.gameState = 0;
        this.sc.gameSpectate = 0;
        this.sc.gameSeed = this.rr.Next(1, 5000);
        this.sc.tempRifle = 2;
        this.sc.tempPistol = 2;
        this.sc.tempAmmo = 0;
        this.sc.tempMag = 0;
        this.menuMusic.Stop();
        this.abortThread();
        this.disconnectData();
        this.sc.Game.IsMouseVisible = false;
        this.sc.host = false;
        ((Form) Control.FromHandle(this.sc.Game.Window.Handle)).FormClosing -= new FormClosingEventHandler(this.Form1_KeyDown);
        if (this.sc.lobby.lobbyplayers == "3")
        {
          this.sc.totalPlayers = 3;
          this.sc.currentDay = 1;
          LoadingScreen1.Load(this.ScreenManager, true, new PlayerIndex?(playerindex), (NetworkSession) null, (GameScreen) new BloodnBacon3P((NetworkSession) null));
        }
        if (this.sc.lobby.lobbyplayers == "6")
        {
          this.sc.totalPlayers = 6;
          LoadingScreen1.Load(this.ScreenManager, true, new PlayerIndex?(playerindex), (NetworkSession) null, (GameScreen) new BloodnBacon6P((NetworkSession) null));
        }
        if (this.sc.lobby.lobbyplayers == "4")
        {
          if (this.sc.lobby.lobbyVersion == this.sc.lobby.version4Tunnel.ToString())
          {
            this.sc.totalPlayers = 4;
            this.sc.tada3.Play(this.sc.ev, 0.0f, 0.0f);
            this.sc.showTunnels = true;
            LoadingScreen1.Load(this.ScreenManager, true, new PlayerIndex?(playerindex), (NetworkSession) null, (GameScreen) new BloodnBacon4PT((NetworkSession) null));
          }
          else
          {
            this.sc.totalPlayers = 4;
            this.sc.showTunnels = true;
            LoadingScreen1.Load(this.ScreenManager, true, new PlayerIndex?(playerindex), (NetworkSession) null, (GameScreen) new BloodnBacon4PT((NetworkSession) null));
          }
        }
        if (!(this.sc.lobby.lobbyplayers == "2"))
          return;
        this.sc.totalPlayers = 2;
        this.sc.showTunnels = true;
        LoadingScreen1.Load(this.ScreenManager, true, new PlayerIndex?(playerindex), (NetworkSession) null, (GameScreen) new BloodnBacon4PT((NetworkSession) null));
      }
    }

    public void disconnectData()
    {
      try
      {
        if (!SteamAPI.IsSteamRunning())
          return;
        CSteamID psteamIDRemote = new CSteamID();
        uint pcubMsgSize = 0;
        while (SteamNetworking.IsP2PPacketAvailable(out pcubMsgSize))
          SteamNetworking.ReadP2PPacket(new byte[(int)pcubMsgSize], pcubMsgSize, out uint _, out psteamIDRemote);
        this.sc.lobby.closeSession(psteamIDRemote);
      }
      catch
      {
      }
    }

    private static float WrapAngle(float radians)
    {
      while ((double) radians < -3.1415927410125732)
        radians += 6.28318548f;
      while ((double) radians > 3.1415927410125732)
        radians -= 6.28318548f;
      return radians;
    }

    private void farmerManager(string type)
    {
      if (!(type != ""))
        return;
      switch (type)
      {
        case "wave":
          this.farmerAnim.animList.Clear();
          this.farmerAnim.animList.Add(25);
          this.farmerAnim.animList.Add(26);
          this.farmerAnim.animList.Add(27);
          this.farmerAnim.animList.Add(28);
          this.farmerAnim.animClip = 1;
          this.farmerAnim.animCount = 0.0f;
          this.farmerAnim.animMin = 0;
          this.farmerAnim.animMax = 75;
          this.farmerAnim.animTween = 0.0f;
          this.farmerAnim.animLoop = 0;
          break;
        case "vomit":
          this.farmerAnim.animList.Clear();
          this.farmerAnim.animList.Add(12);
          this.farmerAnim.animList.Add(13);
          this.farmerAnim.animList.Add(14);
          this.farmerAnim.animList.Add(15);
          this.farmerAnim.animList.Add(16);
          this.farmerAnim.animList.Add(17);
          this.farmerAnim.animList.Add(22);
          this.farmerAnim.animList.Add(23);
          this.farmerAnim.animList.Add(24);
          this.farmerAnim.animList.Add(26);
          this.farmerAnim.animList.Add(27);
          this.farmerAnim.animList.Add(28);
          this.farmerAnim.animClip = 6;
          this.farmerAnim.animCount = 0.0f;
          this.farmerAnim.animMin = 0;
          this.farmerAnim.animMax = 162;
          this.farmerAnim.animTween = 0.0f;
          this.farmerAnim.animLoop = 0;
          break;
        case "vomit2":
          this.farmerAnim.animList.Clear();
          this.farmerAnim.animList.Add(12);
          this.farmerAnim.animList.Add(13);
          this.farmerAnim.animList.Add(14);
          this.farmerAnim.animList.Add(15);
          this.farmerAnim.animList.Add(16);
          this.farmerAnim.animList.Add(17);
          this.farmerAnim.animList.Add(22);
          this.farmerAnim.animList.Add(23);
          this.farmerAnim.animList.Add(24);
          this.farmerAnim.animList.Add(26);
          this.farmerAnim.animList.Add(27);
          this.farmerAnim.animList.Add(28);
          this.farmerAnim.animClip = 7;
          this.farmerAnim.animCount = 0.0f;
          this.farmerAnim.animMin = 0;
          this.farmerAnim.animMax = 87;
          this.farmerAnim.animTween = 0.0f;
          this.farmerAnim.animLoop = 0;
          break;
        case "convulse1":
          this.farmerAnim.animList.Clear();
          this.farmerAnim.animList.Add(2);
          this.farmerAnim.animList.Add(3);
          this.farmerAnim.animList.Add(4);
          this.farmerAnim.animList.Add(7);
          this.farmerAnim.animList.Add(8);
          this.farmerAnim.animList.Add(9);
          this.farmerAnim.animList.Add(12);
          this.farmerAnim.animList.Add(13);
          this.farmerAnim.animList.Add(14);
          this.farmerAnim.animList.Add(15);
          this.farmerAnim.animList.Add(16);
          this.farmerAnim.animList.Add(22);
          this.farmerAnim.animList.Add(23);
          this.farmerAnim.animList.Add(24);
          this.farmerAnim.animList.Add(26);
          this.farmerAnim.animList.Add(27);
          this.farmerAnim.animList.Add(28);
          this.farmerAnim.animClip = 5;
          this.farmerAnim.animCount = 0.0f;
          this.farmerAnim.animMin = 0;
          this.farmerAnim.animMax = 210;
          this.farmerAnim.animTween = 0.0f;
          this.farmerAnim.animLoop = 0;
          break;
        case "kick":
          this.farmerAnim.animList.Clear();
          this.farmerAnim.animList.Add(7);
          this.farmerAnim.animList.Add(8);
          this.farmerAnim.animList.Add(9);
          this.farmerAnim.animClip = 4;
          this.farmerAnim.animCount = 0.0f;
          this.farmerAnim.animMin = 0;
          this.farmerAnim.animMax = 150;
          this.farmerAnim.animTween = 0.0f;
          this.farmerAnim.animLoop = 0;
          break;
        case "pat":
          this.farmerAnim.animList.Clear();
          this.farmerAnim.animList.Add(14);
          this.farmerAnim.animList.Add(22);
          this.farmerAnim.animList.Add(23);
          this.farmerAnim.animList.Add(24);
          this.farmerAnim.animList.Add(26);
          this.farmerAnim.animList.Add(27);
          this.farmerAnim.animList.Add(28);
          this.farmerAnim.animClip = 2;
          this.farmerAnim.animCount = 0.0f;
          this.farmerAnim.animMin = 0;
          this.farmerAnim.animMax = 150;
          this.farmerAnim.animTween = 0.0f;
          this.farmerAnim.animLoop = 0;
          break;
        case "point1":
          this.farmerAnim.animList.Clear();
          this.farmerAnim.animList.Add(22);
          this.farmerAnim.animList.Add(23);
          this.farmerAnim.animList.Add(24);
          this.farmerAnim.animList.Add(26);
          this.farmerAnim.animList.Add(27);
          this.farmerAnim.animList.Add(28);
          this.farmerAnim.animClip = 8;
          this.farmerAnim.animCount = 0.0f;
          this.farmerAnim.animMin = 0;
          this.farmerAnim.animMax = 200;
          this.farmerAnim.animTween = 0.0f;
          this.farmerAnim.animLoop = 0;
          break;
        case "clap":
          this.farmerAnim.animList.Clear();
          this.farmerAnim.animList.Add(21);
          this.farmerAnim.animList.Add(22);
          this.farmerAnim.animList.Add(23);
          this.farmerAnim.animList.Add(24);
          this.farmerAnim.animList.Add(25);
          this.farmerAnim.animList.Add(26);
          this.farmerAnim.animList.Add(27);
          this.farmerAnim.animList.Add(28);
          this.farmerAnim.animClip = 9;
          this.farmerAnim.animCount = 0.0f;
          this.farmerAnim.animMin = 0;
          this.farmerAnim.animMax = 200;
          this.farmerAnim.animTween = 0.0f;
          this.farmerAnim.animLoop = 0;
          break;
        case "head":
          this.farmerAnim.animList.Clear();
          this.farmerAnim.animList.Add(21);
          this.farmerAnim.animList.Add(22);
          this.farmerAnim.animList.Add(23);
          this.farmerAnim.animList.Add(24);
          this.farmerAnim.animList.Add(25);
          this.farmerAnim.animList.Add(26);
          this.farmerAnim.animList.Add(27);
          this.farmerAnim.animList.Add(28);
          this.farmerAnim.animClip = 10;
          this.farmerAnim.animCount = 0.0f;
          this.farmerAnim.animMin = 0;
          this.farmerAnim.animMax = 102;
          this.farmerAnim.animTween = 0.0f;
          this.farmerAnim.animLoop = 0;
          break;
        case "nose":
          this.farmerAnim.animList.Clear();
          this.farmerAnim.animList.Add(22);
          this.farmerAnim.animList.Add(23);
          this.farmerAnim.animList.Add(24);
          this.farmerAnim.animClip = 3;
          this.farmerAnim.animCount = 0.0f;
          this.farmerAnim.animMin = 0;
          this.farmerAnim.animMax = 95;
          this.farmerAnim.animTween = 0.0f;
          this.farmerAnim.animLoop = 0;
          break;
      }
    }

    private void farmerBones(ref AnimationPlayer a)
    {
      this.talkSmooth = 0.0f;
      float num = 5f;
      if (this.farmerJawIndex < 0)
      {
        if (this.farmerAnim.animClip == -1)
          --this.farmerGlitchCount;
        if (this.farmerAnim.animClip == -1 && this.farmerGlitchCount < 0)
        {
          this.farmerGlitchIndex = this.rr.Next(0, 4);
          if (this.farmerGlitchIndex > 4)
            this.farmerGlitchIndex = 0;
          if (this.farmerGlitchIndex == 0)
            this.farmerManager("wave");
          if (this.farmerGlitchIndex == 1)
            this.farmerManager("nose");
          if (this.farmerGlitchIndex == 3)
            this.farmerManager("kick");
          this.farmerGlitchCount = this.rr.Next(100, 500);
        }
      }
      if (this.farmerJawIndex >= 0 && this.bool_0)
      {
        ++this.farmerJawIndex;
        this.directorManager();
        this.talkAverage = this.farmerJaw[this.farmerJawIndex] % 1000f;
        if (this.farmerJawIndex > 1 && this.farmerJawIndex < this.farmerJaw.Count - 2)
          this.talkAverage = (float) (((double) this.farmerJaw[this.farmerJawIndex - 1] % 1000.0 + (double) this.farmerJaw[this.farmerJawIndex] % 1000.0 + (double) this.farmerJaw[this.farmerJawIndex + 1] % 1000.0) / 3.0);
        this.talkAverage = MathHelper.Clamp(this.talkAverage, 0.0f, 30f);
        this.talkSmooth = this.talkAverage;
        if ((double) this.farmerJaw[this.farmerJawIndex] == -1.0)
        {
          this.followPoint = true;
          Vector2.Lerp(ref this.pos1, ref this.pos2, this.followTween, out this.lastlookpos);
          this.lookIndex = 0;
          this.followTween = 1f;
          this.headTween = 1f;
          this.farmerJawIndex = -1;
          this.talkIndex = -1;
          this.talkSmooth = 0.0f;
          this.resetImages();
        }
      }
      --this.followTimer;
      if ((double) this.followTimer <= 0.0 && !this.followPoint)
      {
        this.followTimer = 0.0f;
        this.followPoint = true;
        this.lastlookpos = this.sc.adjustVector2(this.sc.mymouse);
        this.followTween = 1f;
        this.lookIndex = 0;
      }
      this.adj = this.sc.adjustVector2(this.sc.mymouse);
      if (this.followPoint)
        this.adj = this.lookpos[this.lookIndex];
      this.pos1 = this.adj;
      this.adj.X = (float) ((((double) this.adj.X + 250.0) / 1280.0 - 0.5) * 2.7999999523162842);
      this.adj.X = MathHelper.Clamp(this.adj.X, -1.4f, 0.9f);
      this.adj.Y = (float) ((((double) this.adj.Y + 120.0) / 720.0 - 0.5) * 2.0);
      this.adj.Y = MathHelper.Clamp(this.adj.Y, -0.75f, 0.4f);
      this.basePos = this.lastlookpos;
      this.pos2 = this.basePos;
      this.basePos.X = (float) ((((double) this.basePos.X + 240.0) / 1280.0 - 0.5) * 2.7999999523162842);
      this.basePos.X = MathHelper.Clamp(this.basePos.X, -1.4f, 0.9f);
      this.basePos.Y = (float) ((((double) this.basePos.Y + 100.0) / 720.0 - 0.5) * 2.0);
      this.basePos.Y = MathHelper.Clamp(this.basePos.Y, -0.75f, 0.4f);
      this.followTween -= 0.05f;
      if ((double) this.followTween <= 0.0)
        this.followTween = 0.0f;
      this.headTween -= 0.1f;
      if ((double) this.headTween <= 0.0)
        this.headTween = 0.0f;
      this.desiredAngle = MathHelper.Lerp(this.adj.X, this.basePos.X, this.followTween);
      this.tiltDown = MathHelper.Lerp(this.adj.Y, this.basePos.Y, this.followTween);
      this.farmerFrame1 += 0.4f;
      this.currentTimeValue = TimeSpan.FromSeconds((double) this.farmerFrame1 * 0.041700001806020737 % a.currentClipValue.Duration.TotalSeconds);
      this.currentKeyframe = (int) (this.currentTimeValue.TotalSeconds * 60.0) * 28;
      this.currentTimeValue += TimeSpan.FromSeconds(0.041999999433755875);
      a.UpdateBoneTransforms2(this.currentKeyframe, this.currentTimeValue);
      a.boneTransforms[19] = Matrix.CreateRotationZ(MathHelper.ToRadians(num - this.talkSmooth)) * a.boneTransforms[19];
      this.headMatrix = Matrix.CreateRotationY(this.desiredAngle) * a.boneTransforms[16];
      this.headMatrix = Matrix.CreateRotationX(this.tiltDown) * this.headMatrix;
      a.boneTransforms[16] = Matrix.Lerp(this.headMatrix, this.lastheadMatrix, this.headTween);
      this.lastheadMatrix = a.boneTransforms[16];
      if ((double) this.farmerAnim.animCount > -1.0)
      {
        this.currentTimeValue = TimeSpan.FromSeconds((double) this.farmerAnim.animCount * 0.40000000596046448 * 0.041700001806020737 % this.farmer1[this.farmerAnim.animClip].currentClipValue.Duration.TotalSeconds);
        this.currentKeyframe = (int) (this.currentTimeValue.TotalSeconds * 60.0) * 28;
        this.currentTimeValue += TimeSpan.FromSeconds(0.041999999433755875);
        this.farmer1[this.farmerAnim.animClip].UpdateBoneTransforms2(this.currentKeyframe, this.currentTimeValue);
        this.farmerAnim.animTween = MathHelper.Clamp(this.farmerAnim.animTween, 0.0f, 1f);
        for (int index = 0; index < this.farmerAnim.animList.Count; ++index)
          a.boneTransforms[this.farmerAnim.animList[index]] = a.boneTransforms[this.farmerAnim.animList[index]] * (1f - this.farmerAnim.animTween) + this.farmer1[this.farmerAnim.animClip].boneTransforms[this.farmerAnim.animList[index]] * this.farmerAnim.animTween;
        ++this.farmerAnim.animCount;
        if ((double) this.farmerAnim.animCount < (double) (this.farmerAnim.animMin + 7))
          this.farmerAnim.animTween += 0.166666672f;
        if ((double) this.farmerAnim.animCount > (double) (this.farmerAnim.animMax - 7))
          this.farmerAnim.animTween -= 0.166666672f;
        if ((double) this.farmerAnim.animCount > (double) this.farmerAnim.animMax)
        {
          if (this.farmerAnim.animLoop == 0)
          {
            this.farmerAnim.animCount = -1f;
            this.farmerAnim.animTween = 0.0f;
            this.farmerAnim.animClip = -1;
          }
          else
          {
            this.farmerAnim.animCount = (float) this.farmerAnim.animMin;
            this.farmerAnim.animTween = 0.0f;
            --this.farmerAnim.animLoop;
          }
        }
      }
      a.UpdateWorldTransforms(Matrix.CreateScale(2f) * Matrix.CreateRotationY(1.57f) * Matrix.CreateTranslation(0.0f, 20f, 30f), a.boneTransforms);
    }

    private void removeTrack(int t)
    {
      this.sc.tick.Play(this.sc.ev, -1f, 0.0f);
      this.sc.tick.Play(this.sc.ev, -1f, 0.0f);
      if (t == 100)
      {
        for (int index = 0; index < this.farmerJaw.Count; ++index)
        {
          if ((double) this.farmerJaw[index] >= 1000.0 && (double) this.farmerJaw[index] < 10999.0)
            this.farmerJaw[index] %= 1000f;
        }
      }
      if (t == 101)
      {
        for (int index = 0; index < this.farmerJaw.Count; ++index)
        {
          if ((double) this.farmerJaw[index] >= 11000.0 && (double) this.farmerJaw[index] < 20999.0)
            this.farmerJaw[index] %= 1000f;
        }
      }
      if (t == 102)
      {
        for (int index = 0; index < this.farmerJaw.Count; ++index)
        {
          if ((double) this.farmerJaw[index] >= 21000.0 && (double) this.farmerJaw[index] < 30999.0)
            this.farmerJaw[index] %= 1000f;
        }
      }
      if (t >= 0 && t <= 8)
      {
        for (int index = 0; index < this.farmerJaw.Count; ++index)
        {
          if ((double) this.farmerJaw[index] >= (double) (51000 + t * 1000) && (double) this.farmerJaw[index] < (double) (51999 + t * 1000))
            this.farmerJaw[index] %= 1000f;
          if ((double) this.farmerJaw[index] >= (double) (61000 + t * 1000) && (double) this.farmerJaw[index] < (double) (61999 + t * 1000))
            this.farmerJaw[index] %= 1000f;
          if ((double) this.farmerJaw[index] >= (double) (71000 + t * 1000) && (double) this.farmerJaw[index] < (double) (71999 + t * 1000))
            this.farmerJaw[index] %= 1000f;
          if ((double) this.farmerJaw[index] >= (double) (81000 + t * 1000) && (double) this.farmerJaw[index] < (double) (81999 + t * 1000))
            this.farmerJaw[index] %= 1000f;
          if ((double) this.farmerJaw[index] >= (double) (201000 + t * 1000) && (double) this.farmerJaw[index] < (double) (201999 + t * 1000))
            this.farmerJaw[index] %= 1000f;
          if ((double) this.farmerJaw[index] >= (double) (211000 + t * 1000) && (double) this.farmerJaw[index] < (double) (211999 + t * 1000))
            this.farmerJaw[index] %= 1000f;
          if ((double) this.farmerJaw[index] >= (double) (221000 + t * 1000) && (double) this.farmerJaw[index] < (double) (221999 + t * 1000))
            this.farmerJaw[index] %= 1000f;
          if ((double) this.farmerJaw[index] >= (double) (231000 + t * 1000) && (double) this.farmerJaw[index] < (double) (231999 + t * 1000))
            this.farmerJaw[index] %= 1000f;
          if ((double) this.farmerJaw[index] >= (double) (241000 + t * 1000) && (double) this.farmerJaw[index] < (double) (241999 + t * 1000))
            this.farmerJaw[index] %= 1000f;
          if ((double) this.farmerJaw[index] >= (double) (251000 + t * 1000) && (double) this.farmerJaw[index] < (double) (251999 + t * 1000))
            this.farmerJaw[index] %= 1000f;
          if ((double) this.farmerJaw[index] >= (double) (261000 + t * 1000) && (double) this.farmerJaw[index] < (double) (261999 + t * 1000))
            this.farmerJaw[index] %= 1000f;
          if ((double) this.farmerJaw[index] >= (double) (271000 + t * 1000) && (double) this.farmerJaw[index] < (double) (271999 + t * 1000))
            this.farmerJaw[index] %= 1000f;
          if ((double) this.farmerJaw[index] >= (double) (281000 + t * 1000) && (double) this.farmerJaw[index] < (double) (281999 + t * 1000))
            this.farmerJaw[index] %= 1000f;
          if ((double) this.farmerJaw[index] >= (double) (291000 + t * 1000) && (double) this.farmerJaw[index] < (double) (291999 + t * 1000))
            this.farmerJaw[index] %= 1000f;
          if ((double) this.farmerJaw[index] >= (double) (111000 + t * 1000) && (double) this.farmerJaw[index] < (double) (111999 + t * 1000))
            this.farmerJaw[index] %= 1000f;
          if ((double) this.farmerJaw[index] >= (double) (121000 + t * 1000) && (double) this.farmerJaw[index] < (double) (121999 + t * 1000))
            this.farmerJaw[index] %= 1000f;
          if ((double) this.farmerJaw[index] >= (double) (131000 + t * 1000) && (double) this.farmerJaw[index] < (double) (131999 + t * 1000))
            this.farmerJaw[index] %= 1000f;
          if ((double) this.farmerJaw[index] >= (double) (141000 + t * 1000) && (double) this.farmerJaw[index] < (double) (141999 + t * 1000))
            this.farmerJaw[index] %= 1000f;
          if ((double) this.farmerJaw[index] >= (double) (151000 + t * 1000) && (double) this.farmerJaw[index] < (double) (151999 + t * 1000))
            this.farmerJaw[index] %= 1000f;
          if ((double) this.farmerJaw[index] >= (double) (161000 + t * 1000) && (double) this.farmerJaw[index] < (double) (161999 + t * 1000))
            this.farmerJaw[index] %= 1000f;
          if ((double) this.farmerJaw[index] >= (double) (171000 + t * 1000) && (double) this.farmerJaw[index] < (double) (171999 + t * 1000))
            this.farmerJaw[index] %= 1000f;
          if ((double) this.farmerJaw[index] >= (double) (181000 + t * 1000) && (double) this.farmerJaw[index] < (double) (181999 + t * 1000))
            this.farmerJaw[index] %= 1000f;
        }
      }
      this.writeFile();
    }

    private void writeFile()
    {
      using (StreamWriter streamWriter = new StreamWriter((Stream) File.Open(this.sc.workshop.entry[this.entryIndex].path + "\\report.txt", FileMode.Create)))
      {
        for (int index = 0; index < this.farmerJaw.Count; ++index)
          streamWriter.WriteLine(this.farmerJaw[index]);
      }
    }

    private void directorManager()
    {
      int num1 = -1;
      if (this.directNum > 999 && (double) this.farmerJaw[this.farmerJawIndex] < 1000.0 && this.farmerJawIndex < this.farmerJaw.Count - 2)
      {
        if (this.directNum >= 51000 && this.directNum <= 60000 && ((double) this.farmerJaw[this.farmerJawIndex + 1] > 999.0 || (double) this.farmerJaw[this.farmerJawIndex + 2] > 999.0))
        {
          num1 = -1;
        }
        else
        {
          if (this.directNum >= 51000 && this.directNum <= 60000)
          {
            if (this.directRate == 1)
            {
              this.directNum += 10000;
              this.sc.tick.Play(this.sc.ev, 1f, 0.0f);
            }
            if (this.directRate == 2)
            {
              this.directNum += 20000;
              this.sc.tick.Play(this.sc.ev, -1f, 0.0f);
            }
          }
          this.farmerJaw[this.farmerJawIndex] = this.farmerJaw[this.farmerJawIndex] % 1000f + (float) this.directNum;
          this.sc.workshop.entry[this.entryIndex].motion[this.farmerJawIndex] = this.farmerJaw[this.farmerJawIndex];
          if (this.directNum >= 51000 && this.directNum <= 80000 && this.farmerJawIndex < this.farmerJaw.Count - 2)
          {
            int index1 = this.farmerJawIndex + 1;
            int index2 = this.farmerJawIndex + 2;
            this.farmerJaw[index1] = this.farmerJaw[index1] % 1000f + (float) (this.directNumX * 1000);
            this.sc.workshop.entry[this.entryIndex].motion[index1] = this.farmerJaw[index1];
            this.farmerJaw[index2] = this.farmerJaw[index2] % 1000f + (float) (this.directNumY * 1000);
            this.sc.workshop.entry[this.entryIndex].motion[index2] = this.farmerJaw[index2];
          }
        }
      }
      if ((double) this.farmerJaw[this.farmerJawIndex] > 999.0)
        num1 = (int) this.farmerJaw[this.farmerJawIndex] / 1000;
      if (num1 >= 1 && num1 <= 10)
      {
        this.followPoint = true;
        this.headTween = 1f;
        Vector2.Lerp(ref this.pos1, ref this.pos2, this.followTween, out this.lastlookpos);
        if (num1 == 1)
        {
          this.lookPosRR = new Vector2((float) this.rr.Next(-30, 30), (float) this.rr.Next(-30, 30));
          this.lookpos[0] = this.lookposOrig[0] + this.lookPosRR;
          this.lookIndex = 0;
          this.followTween = 1f;
        }
        if (num1 == 2)
        {
          this.lookPosRR = new Vector2((float) this.rr.Next(-50, 50), (float) this.rr.Next(10, 250));
          this.lookpos[1] = this.lookposOrig[1] + this.lookPosRR;
          this.lookIndex = 1;
          this.followTween = 1f;
        }
        if (num1 == 3)
        {
          this.lookPosRR = new Vector2((float) this.rr.Next(-100, 100), (float) this.rr.Next(-100, 100));
          this.lookpos[2] = this.lookposOrig[2] + this.lookPosRR;
          this.lookIndex = 2;
          this.followTween = 1f;
        }
        if (num1 == 4)
        {
          this.lookPosRR = new Vector2((float) this.rr.Next(-100, 100), (float) this.rr.Next(-50, 50));
          this.lookpos[3] = this.lookposOrig[3] + this.lookPosRR;
          this.lookIndex = 3;
          this.followTween = 1f;
        }
        if (num1 == 5)
        {
          this.lookPosRR = new Vector2((float) this.rr.Next(-100, 100), (float) this.rr.Next(-100, 100));
          this.lookpos[4] = this.lookposOrig[4] + this.lookPosRR;
          this.lookIndex = 4;
          this.followTween = 1f;
        }
        if (num1 == 6)
        {
          this.lookPosRR = new Vector2((float) this.rr.Next(-150, 150), (float) this.rr.Next(-100, 100));
          this.lookpos[5] = this.lookposOrig[5] + this.lookPosRR;
          this.lookIndex = 5;
          this.followTween = 1f;
        }
        if (num1 != 7)
          return;
        this.lookPosRR = new Vector2((float) this.rr.Next(-150, 150), (float) this.rr.Next(-150, 150));
        this.lookpos[6] = this.lookposOrig[6] + this.lookPosRR;
        this.lookIndex = 6;
        this.followTween = 1f;
      }
      else if (num1 >= 11 && num1 <= 20)
      {
        if (num1 == 11)
          this.farmerManager("point1");
        if (num1 == 12)
          this.farmerManager("clap");
        if (num1 == 13)
          this.farmerManager("wave");
        if (num1 == 14)
          this.farmerManager("nose");
        if (num1 == 15)
          this.farmerManager("kick");
        if (num1 != 16)
          return;
        this.farmerManager("head");
      }
      else
      {
        if (num1 >= 21 && num1 <= 30)
        {
          if (this.entryIndex >= 0)
          {
            try
            {
              if (num1 == 21)
                this.sc.workshop.entry[this.entryIndex].soundhit[0].Play(this.sc.ev, 0.0f, 0.0f);
              if (num1 == 22)
                this.sc.workshop.entry[this.entryIndex].soundhit[1].Play(this.sc.ev, 0.0f, 0.0f);
              if (num1 == 23)
                this.sc.workshop.entry[this.entryIndex].soundhit[2].Play(this.sc.ev, 0.0f, 0.0f);
              if (num1 == 24)
                this.sc.workshop.entry[this.entryIndex].soundhit[3].Play(this.sc.ev, 0.0f, 0.0f);
              if (num1 == 25)
                this.sc.workshop.entry[this.entryIndex].soundhit[4].Play(this.sc.ev, 0.0f, 0.0f);
              if (num1 == 26)
                this.sc.workshop.entry[this.entryIndex].soundhit[5].Play(this.sc.ev, 0.0f, 0.0f);
              if (num1 == 27)
                this.sc.workshop.entry[this.entryIndex].soundhit[6].Play(this.sc.ev, 0.0f, 0.0f);
              if (num1 == 28)
                this.sc.workshop.entry[this.entryIndex].soundhit[7].Play(this.sc.ev, 0.0f, 0.0f);
              if (num1 == 29)
                this.sc.workshop.entry[this.entryIndex].soundhit[8].Play(this.sc.ev, 0.0f, 0.0f);
              if (num1 != 30)
                return;
              this.sc.workshop.entry[this.entryIndex].soundhit[9].Play(this.sc.ev, 0.0f, 0.0f);
              return;
            }
            catch
            {
              return;
            }
          }
        }
        if (num1 >= 51)
        {
          if (num1 <= 60)
          {
            try
            {
              for (int index3 = 51; index3 <= 60; ++index3)
              {
                if (num1 == index3)
                {
                  int index4 = index3 - 51;
                  this.im[index4].show = true;
                  this.im[index4].tween = 0.0f;
                  this.im[index4].tweenRate = 1f;
                  this.im[index4].pos = new Vector2((float) ((double) this.farmerJaw[this.farmerJawIndex + 1] / 1000.0 - 5000.0), (float) ((double) this.farmerJaw[this.farmerJawIndex + 2] / 1000.0 - 5000.0));
                  if (this.displayList.Contains(index4))
                    break;
                  this.displayList.Insert(0, index4);
                  break;
                }
              }
              return;
            }
            catch
            {
              return;
            }
          }
        }
        if (num1 >= 61)
        {
          if (num1 <= 70)
          {
            try
            {
              for (int index5 = 61; index5 <= 70; ++index5)
              {
                if (num1 == index5)
                {
                  int index6 = index5 - 61;
                  this.im[index6].show = true;
                  this.im[index6].oldpos = Vector2.Lerp(this.im[index6].oldpos, this.im[index6].pos, this.im[index6].tween);
                  this.im[index6].tween = 0.0f;
                  this.im[index6].tweenRate = 0.07f;
                  this.im[index6].pos = new Vector2((float) ((double) this.farmerJaw[this.farmerJawIndex + 1] / 1000.0 - 5000.0), (float) ((double) this.farmerJaw[this.farmerJawIndex + 2] / 1000.0 - 5000.0));
                  if (this.displayList.Contains(index6))
                    break;
                  this.displayList.Insert(0, index6);
                  break;
                }
              }
              return;
            }
            catch
            {
              return;
            }
          }
        }
        if (num1 >= 71)
        {
          if (num1 <= 80)
          {
            try
            {
              for (int index7 = 71; index7 <= 80; ++index7)
              {
                if (num1 == index7)
                {
                  int index8 = index7 - 71;
                  this.im[index8].show = true;
                  this.im[index8].oldpos = Vector2.Lerp(this.im[index8].oldpos, this.im[index8].pos, this.im[index8].tween);
                  this.im[index8].tween = 0.0f;
                  this.im[index8].tweenRate = 0.01f;
                  this.im[index8].pos = new Vector2((float) ((double) this.farmerJaw[this.farmerJawIndex + 1] / 1000.0 - 5000.0), (float) ((double) this.farmerJaw[this.farmerJawIndex + 2] / 1000.0 - 5000.0));
                  if (this.displayList.Contains(index8))
                    break;
                  this.displayList.Insert(0, index8);
                  break;
                }
              }
              return;
            }
            catch
            {
              return;
            }
          }
        }
        if (num1 >= 81)
        {
          if (num1 <= 90)
          {
            try
            {
              for (int index9 = 81; index9 <= 90; ++index9)
              {
                if (num1 == index9)
                {
                  int index10 = index9 - 81;
                  this.im[index10].show = false;
                  this.displayList.Remove(index10);
                  break;
                }
              }
              return;
            }
            catch
            {
              return;
            }
          }
        }
        if (num1 >= 201)
        {
          if (num1 <= 210)
          {
            try
            {
              for (int index = 201; index <= 210; ++index)
              {
                if (num1 == index)
                {
                  this.im[index - 201].spriteIndex = 0;
                  break;
                }
              }
              return;
            }
            catch
            {
              return;
            }
          }
        }
        if (num1 >= 211)
        {
          if (num1 <= 220)
          {
            try
            {
              for (int index = 211; index <= 220; ++index)
              {
                if (num1 == index)
                {
                  this.im[index - 211].spriteIndex = 1;
                  break;
                }
              }
              return;
            }
            catch
            {
              return;
            }
          }
        }
        if (num1 >= 221)
        {
          if (num1 <= 230)
          {
            try
            {
              for (int index = 221; index <= 230; ++index)
              {
                if (num1 == index)
                {
                  this.im[index - 221].spriteIndex = 2;
                  break;
                }
              }
              return;
            }
            catch
            {
              return;
            }
          }
        }
        if (num1 >= 231)
        {
          if (num1 <= 240)
          {
            try
            {
              for (int index = 231; index <= 240; ++index)
              {
                if (num1 == index)
                {
                  this.im[index - 231].spriteIndex = 3;
                  break;
                }
              }
              return;
            }
            catch
            {
              return;
            }
          }
        }
        if (num1 >= 241)
        {
          if (num1 <= 250)
          {
            try
            {
              for (int index = 241; index <= 250; ++index)
              {
                if (num1 == index)
                {
                  this.im[index - 241].spriteIndex = 4;
                  break;
                }
              }
              return;
            }
            catch
            {
              return;
            }
          }
        }
        if (num1 >= 251)
        {
          if (num1 <= 260)
          {
            try
            {
              for (int index = 251; index <= 260; ++index)
              {
                if (num1 == index)
                {
                  this.im[index - 251].spriteIndex = 5;
                  break;
                }
              }
              return;
            }
            catch
            {
              return;
            }
          }
        }
        if (num1 >= 261)
        {
          if (num1 <= 270)
          {
            try
            {
              for (int index = 261; index <= 270; ++index)
              {
                if (num1 == index)
                {
                  this.im[index - 261].spriteIndex = 6;
                  break;
                }
              }
              return;
            }
            catch
            {
              return;
            }
          }
        }
        if (num1 >= 271)
        {
          if (num1 <= 280)
          {
            try
            {
              for (int index = 271; index <= 280; ++index)
              {
                if (num1 == index)
                {
                  this.im[index - 271].spriteIndex = 7;
                  break;
                }
              }
              return;
            }
            catch
            {
              return;
            }
          }
        }
        if (num1 >= 281)
        {
          if (num1 <= 290)
          {
            try
            {
              for (int index = 281; index <= 290; ++index)
              {
                if (num1 == index)
                {
                  this.im[index - 281].spriteIndex = 8;
                  break;
                }
              }
              return;
            }
            catch
            {
              return;
            }
          }
        }
        if (num1 >= 291)
        {
          if (num1 <= 300)
          {
            try
            {
              for (int index = 291; index <= 300; ++index)
              {
                if (num1 == index)
                {
                  this.im[index - 291].spriteIndex = 9;
                  break;
                }
              }
              return;
            }
            catch
            {
              return;
            }
          }
        }
        if (num1 >= 111)
        {
          if (num1 <= 120)
          {
            try
            {
              for (int index = 111; index <= 120; ++index)
              {
                if (num1 == index)
                {
                  this.im[index - 111].rot -= 0.2f;
                  break;
                }
              }
              return;
            }
            catch
            {
              return;
            }
          }
        }
        if (num1 >= 121)
        {
          if (num1 <= 130)
          {
            try
            {
              for (int index = 121; index <= 130; ++index)
              {
                if (num1 == index)
                {
                  this.im[index - 121].rot += 0.2f;
                  break;
                }
              }
              return;
            }
            catch
            {
              return;
            }
          }
        }
        if (num1 >= 131)
        {
          if (num1 <= 140)
          {
            try
            {
              for (int index = 131; index <= 140; ++index)
              {
                if (num1 == index)
                {
                  this.im[index - 131].scale *= 0.66f;
                  break;
                }
              }
              return;
            }
            catch
            {
              return;
            }
          }
        }
        if (num1 >= 141)
        {
          if (num1 <= 150)
          {
            try
            {
              for (int index = 141; index <= 150; ++index)
              {
                if (num1 == index)
                {
                  this.im[index - 141].scale *= 1.33f;
                  break;
                }
              }
              return;
            }
            catch
            {
              return;
            }
          }
        }
        if (num1 >= 151)
        {
          if (num1 <= 160)
          {
            try
            {
              for (int index = 151; index <= 160; ++index)
              {
                if (num1 == index)
                {
                  this.im[index - 151].flip = SpriteEffects.FlipHorizontally;
                  break;
                }
              }
              return;
            }
            catch
            {
              return;
            }
          }
        }
        if (num1 >= 161)
        {
          if (num1 <= 170)
          {
            try
            {
              for (int index = 161; index <= 170; ++index)
              {
                if (num1 == index)
                {
                  this.im[index - 161].flip = SpriteEffects.None;
                  break;
                }
              }
              return;
            }
            catch
            {
              return;
            }
          }
        }
        if (num1 >= 171)
        {
          if (num1 <= 180)
          {
            try
            {
              for (int index = 171; index <= 180; ++index)
              {
                if (num1 == index)
                {
                  int num2 = index - 171;
                  this.displayList.Remove(num2);
                  this.displayList.Insert(0, num2);
                  break;
                }
              }
              return;
            }
            catch
            {
              return;
            }
          }
        }
        if (num1 >= 181)
        {
          if (num1 <= 190)
          {
            try
            {
              for (int index = 181; index <= 190; ++index)
              {
                if (num1 == index)
                {
                  int num3 = index - 181;
                  this.displayList.Remove(num3);
                  this.displayList.Add(num3);
                  break;
                }
              }
              return;
            }
            catch
            {
              return;
            }
          }
        }
        try
        {
          for (int index11 = 301; index11 <= 310; ++index11)
          {
            if (num1 == index11)
            {
              int index12 = index11 - 301;
              if (this.im[index12].show)
              {
                this.im[index12].show = false;
                this.im[index12].full = false;
                this.displayList.Remove(index12);
                return;
              }
              this.im[index12].show = true;
              this.im[index12].full = true;
              this.displayList.Remove(index12);
              for (int index13 = 0; index13 < this.displayList.Count; ++index13)
              {
                if (this.im[this.displayList[index13]].full)
                {
                  this.displayList.Insert(index13, index12);
                  break;
                }
              }
              if (this.displayList.Contains(index12))
                return;
              this.displayList.Add(index12);
              return;
            }
          }
        }
        catch
        {
        }
        for (int index = 311; index <= 320; ++index)
        {
          if (num1 == index)
          {
            this.briteXold = this.briteX;
            this.colorXold = this.colorX;
            this.liteTween = 0.0f;
            this.briteX = 0;
            this.colorX = index - 311;
            return;
          }
        }
        for (int index = 321; index <= 330; ++index)
        {
          if (num1 == index)
          {
            this.briteXold = this.briteX;
            this.colorXold = this.colorX;
            this.liteTween = 0.0f;
            this.briteX = 1;
            this.colorX = index - 321;
            return;
          }
        }
        for (int index = 331; index <= 340; ++index)
        {
          if (num1 == index)
          {
            this.briteXold = this.briteX;
            this.colorXold = this.colorX;
            this.liteTween = 0.0f;
            this.briteX = 2;
            this.colorX = index - 331;
            return;
          }
        }
        for (int index = 341; index <= 350; ++index)
        {
          if (num1 == index)
          {
            this.briteXold = this.briteX;
            this.colorXold = this.colorX;
            this.liteTween = 0.0f;
            this.briteX = 3;
            this.colorX = index - 341;
            return;
          }
        }
        for (int index = 351; index <= 360; ++index)
        {
          if (num1 == index)
          {
            this.briteXold = this.briteX;
            this.colorXold = this.colorX;
            this.liteTween = 0.0f;
            this.briteX = 4;
            this.colorX = index - 351;
            return;
          }
        }
        for (int index = 361; index <= 370; ++index)
        {
          if (num1 == index)
          {
            this.briteXold = this.briteX;
            this.colorXold = this.colorX;
            this.liteTween = 0.0f;
            this.briteX = 5;
            this.colorX = index - 361;
            return;
          }
        }
        for (int index = 371; index <= 380; ++index)
        {
          if (num1 == index)
          {
            this.briteXold = this.briteX;
            this.colorXold = this.colorX;
            this.liteTween = 0.0f;
            this.briteX = 6;
            this.colorX = index - 371;
            return;
          }
        }
        for (int index = 381; index <= 390; ++index)
        {
          if (num1 == index)
          {
            this.briteXold = this.briteX;
            this.colorXold = this.colorX;
            this.liteTween = 0.0f;
            this.briteX = 7;
            this.colorX = index - 381;
            return;
          }
        }
        for (int index = 391; index <= 400; ++index)
        {
          if (num1 == index)
          {
            this.briteXold = this.briteX;
            this.colorXold = this.colorX;
            this.liteTween = 0.0f;
            this.briteX = 8;
            this.colorX = index - 391;
            break;
          }
        }
      }
    }

    private void farmerTalk()
    {
      this.bool_0 = false;
      try
      {
        this.farmerDialog1.sound[0].Dispose();
      }
      catch
      {
        this.bool_0 = false;
      }
      try
      {
        if (this.sc.workshop.populateDiaryContents(this.sc.workshop.entryIndex))
        {
          this.farmerDialog1 = new SoundEffects(1);
          this.farmerDialog1.sound[0] = this.sc.workshop.entry[this.sc.workshop.entryIndex].voice.CreateInstance();
          this.farmerJaw.Clear();
          for (int index = 0; index < this.sc.workshop.entry[this.sc.workshop.entryIndex].motion.Count - 1; ++index)
            this.farmerJaw.Add(this.sc.workshop.entry[this.sc.workshop.entryIndex].motion[index]);
          this.farmerJaw.Add(-1f);
          this.farmerDialog1.count = 0;
          this.farmerDialog1.sound[0].Play();
          this.farmerDialog1.sound[0].Volume = this.sc.vv;
          this.bool_0 = true;
          this.farmerJawIndex = 1;
        }
        else
          this.bool_0 = false;
      }
      catch
      {
        this.bool_0 = false;
      }
    }

    private void drawFarmer()
    {
      Vector3 vector3_1 = this.LightDirectionX[this.briteX];
      Vector3 vector3_2 = this.DiffuseLightX[this.colorX];
      Vector3 vector3_3 = this.AmbientLightX[this.colorX];
      if ((double) this.liteTween <= 1.0)
      {
        this.liteTween += 0.02f;
        vector3_1 = Vector3.Lerp(this.LightDirectionX[this.briteXold], this.LightDirectionX[this.briteX], this.liteTween);
        vector3_2 = Vector3.Lerp(this.DiffuseLightX[this.colorXold], this.DiffuseLightX[this.colorX], this.liteTween);
        vector3_3 = Vector3.Lerp(this.AmbientLightX[this.colorXold], this.AmbientLightX[this.colorX], this.liteTween);
      }
      Matrix lookAt = Matrix.CreateLookAt(new Vector3(120f, 90f, 40f), new Vector3(0.0f, 90f, -10f), Vector3.Up);
      Matrix perspectiveFieldOfView = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(50f), 1.78f, 10f, 15000f);
      this.farmerModel.Meshes[0].MeshParts[0].Effect = this.farmerSkin;
      this.farmerSkin.Parameters["View"].SetValue(lookAt);
      this.farmerSkin.Parameters["Projection"].SetValue(perspectiveFieldOfView);
      this.farmerSkin.Parameters["Bones"].SetValue(this.farmer1[0].skinTransforms);
      this.farmerSkin.Parameters["LightDirection"].SetValue(Vector3.Normalize(vector3_1));
      this.farmerSkin.Parameters["AmbientLight"].SetValue(vector3_3);
      this.farmerSkin.Parameters["DiffuseLight"].SetValue(vector3_2);
      this.farmerSkin.Parameters["flash"].SetValue(Vector3.Zero);
      this.farmerSkin.CurrentTechnique = this.farmerSkin.Techniques["SkinnedEffect"];
      this.farmerModel.Meshes[0].Draw();
    }

    private void resetFarmerDirector()
    {
      this.followPoint = true;
      this.followTimer = 0.0f;
      this.farmerJawIndex = -1;
      this.talkIndex = -1;
      this.talkSmooth = 0.0f;
    }

    private void resetImages()
    {
      this.im.Clear();
      for (int index = 0; index < 10; ++index)
      {
        this.im.Add(new MainMenu.imim());
        this.im[index].spriteIndex = index;
      }
      this.displayList.Clear();
      this.briteXold = this.briteX;
      this.colorXold = this.colorX;
      this.briteX = 4;
      this.colorX = 4;
      this.liteTween = 0.0f;
    }

    private enum states
    {
      main,
      playgame,
      settings,
      videos,
      trailer,
      credit,
      graphics,
      gamesetup,
      controller,
      coopChoice,
      keyboard,
      display,
      displaykeys,
      cooplobby,
      multiHostStart,
      multi2player,
      multijoinStart,
      multi4player,
      multi6player,
      multi3player,
      controls,
      creditwall,
      alphateam,
      audio,
      workshop,
      diary,
      more,
    }

    private class initb
    {
      public bool main;
      public bool playgame;
      public bool settings;
      public bool videos;
      public bool trailer;
      public bool credit;
      public bool graphics;
      public bool gamesetup;
      public bool controller;
      public bool coopChoice;
      public bool keyboard;
      public bool display;
      public bool displaykeys;
      public bool cooplobby;
      public bool multiHostStart;
      public bool multi2player;
      public bool multijoinStart;
      public bool multi4player;
      public bool multi6player;
      public bool multi3player;
      public bool controls;
      public bool creditwall;
      public bool alphateam;
      public bool audio;
      public bool workshop;
      public bool diary;
      public bool more;
    }

    private struct npcanim
    {
      public float animCount;
      public float animTween;
      public List<int> animList;
      public bool looped;
      public int animClip;
      public int animMax;
      public int animMin;
      public int animLoop;
      public float tweenspeed;
    }

    public class imim
    {
      public bool full;
      public bool show;
      public bool shake;
      public int shaketimer;
      public Vector2 pos = Vector2.Zero;
      public Vector2 oldpos = Vector2.Zero;
      public float tween;
      public float tweenRate = 1f;
      public int spriteIndex;
      public float scale = 1f;
      public float rot;
      public SpriteEffects flip;
    }
  }
}
