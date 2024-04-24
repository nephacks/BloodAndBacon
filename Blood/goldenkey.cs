using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Globalization;
using System.IO;

#pragma warning disable CS0169
#nullable disable
namespace Blood
{
  public class goldenkey
  {
    public string kb = "bonus";
    public string ke = nameof (exitkey);
    public string kg = "goggles";
    public string km = "minimap";
    public string kc1 = "cog1";
    public string kc2 = "cog2";
    public string kc3 = "cog3";
    public string ka1 = "ammo1";
    public string ka2 = "ammo2";
    public string ka3 = "ammo3";
    public string kh1 = "hat1";
    public string kh2 = "hat2";
    public string kh3 = "hat3";
    public string kf1 = nameof (flashlight1);
    public string kf2 = nameof (flashlight2);
    public string kf3 = nameof (flashlight3);
    private Texture2D flash1;
    private Texture2D flash2;
    private Texture2D flash3;
    private Texture2D ammoboxTexture;
    private Texture2D goggleTexture;
    private Texture2D cogTexture;
    private Texture2D mapTexture;
    private Texture2D exitkeyTexture;
    private Texture2D skullTexture;
    private Texture2D tuskTexture;
    private Texture2D skyboxTexture;
    private Model flashlight1;
    private Model flashlight2;
    private Model flashlight3;
    private Model ammobox;
    private Model goggles1;
    private Model exitkey;
    private Model cog;
    private Model map;
    private Model skullcc;
    private Model tuskcc;
    private Model goldpile;
    public bool nearItems;
    public bool nearExit;
    public bool lookatitems;
    private float speed = 3f;
    public int propHit = 5;
    public int blimpHit = 50;
    public int carryHit = 5;
    public Vector3 blimpTrans = new Vector3(1000f, 1500f, 1000f);
    public float blimpRot;
    public Vector3 blimpVeloc = Vector3.Zero;
    public Vector3 ray = Vector3.Zero;
    public float rayAmt;
    public Matrix myRot = Matrix.Identity;
    private Matrix myRotold = Matrix.Identity;
    private ScreenManager sc;
    private Model key;
    private Effect keyeffect;
    private Effect skulleffect;
    private ContentManager content;
    private float counter;
    private float cogcounter;
    private int gearticker;
    private Vector3 keypos1 = new Vector3(4860f, 968f, 1259f);
    private Vector3 keypos2 = new Vector3(9000f, 30f, 3000f);
    private Vector3 keypos3 = new Vector3(1227f, 25f, 2868f);
    private Vector3 keypos4 = new Vector3(3547f, 230f, 4637f);
    private Vector3 keypos5 = new Vector3(1664f, 28f, -1700f);
    private Vector3 keypos6 = new Vector3(2012f, -130f, 5200f);
    private Vector3 keypos7 = new Vector3(2750f, -130f, 4550f);
    private Vector3 keypos8 = new Vector3(1800f, -130f, 3480f);
    public Vector3 kePos;
    public Vector3 kbPos;
    public Vector3 kmPos;
    public Vector3 kgPos;
    public Vector3 kh1Pos;
    public Vector3 kh2Pos;
    public Vector3 kh3Pos;
    public Vector3 ka1Pos;
    public Vector3 ka2Pos;
    public Vector3 ka3Pos;
    public Vector3 kf1Pos;
    public Vector3 kf2Pos;
    public Vector3 kf3Pos;
    public Vector3 kc1Pos;
    public Vector3 kc2Pos;
    public Vector3 kc3Pos;
    public bool kbHide = true;
    public bool keHide = true;
    public bool kmHide = true;
    public bool kgHide = true;
    public bool kh1Hide = true;
    public bool kh2Hide = true;
    public bool kh3Hide = true;
    public bool ka1Hide = true;
    public bool ka2Hide = true;
    public bool ka3Hide = true;
    public bool kf1Hide = true;
    public bool kf2Hide = true;
    public bool kf3Hide = true;
    public bool kc1Hide = true;
    public bool kc2Hide = true;
    public bool kc3Hide = true;
    public Vector3 flashlight1pos;
    public Vector3 flashlight2pos;
    public Vector3 flashlight3pos;
    public Vector3 ammoboxpos;
    public Vector3 gogglepos;
    public Matrix flashlight1matrix;
    public Matrix flashlight2matrix;
    public Matrix flashlight3matrix;
    public Matrix ammoboxmatrix;
    public Matrix gogglematrix;
    public Vector3 mappos;
    public Vector3 cogpos;
    public Vector3 exitkeypos;
    public Vector3 skullpos;
    public Matrix mapmatrix;
    public Matrix cogmatrix;
    public Matrix exitkeymatrix;
    public Matrix skullmatrix = Matrix.Identity;
    public Matrix matrix_0 = Matrix.Identity;
    public Matrix matrix_1 = Matrix.Identity;
    public Matrix matrix_2 = Matrix.Identity;
    public bool rsFound;
    public Vector3 rs2Pos = Vector3.Zero;
    public Vector3 tuskpos;
    public Matrix tuskmatrix = Matrix.Identity;
    public Matrix matrix_3 = Matrix.Identity;
    public Matrix matrix_4 = Matrix.Identity;
    public Matrix matrix_5 = Matrix.Identity;
    public bool ttFound;
    public Vector3 tt2Pos = Vector3.Zero;
    public bool keyFlashlight1 = true;
    public bool keyFlashlight2 = true;
    public bool keyFlashlight3 = true;
    public bool keyAmmobox = true;
    public bool keyGoggles = true;
    public bool keyMap = true;
    public bool keySkull1 = true;
    public bool keySkull2 = true;
    public bool keySkull3 = true;
    public bool keyTusk1 = true;
    public bool keyTusk2 = true;
    public bool keyTusk3 = true;
    public bool keyCog = true;
    public bool keyExitkey = true;
    private SoundEffect geartick;
    private Curve targetX;
    private Curve targetZ;
    private float tx;
    private float tz;
    public float targetRate;
    public int targetWait;
    public bool newAction;
    public float targetDist;
    public int curveIndex = 1;
    public float loop;
    public float cuttyDistance = 20000f;
    public float fps;
    private bool atGears;

    public goldenkey(ScreenManager ss, ContentManager cc)
    {
      this.content = cc;
      this.sc = ss;
      this.keyeffect = this.content.Load<Effect>("effects//keyeffect");
      this.skulleffect = this.content.Load<Effect>("effects//skulleffect");
      this.geartick = this.content.Load<SoundEffect>("audio//geartick");
      this.flash1 = this.content.Load<Texture2D>("texture//flash1");
      this.flashlight1 = this.content.Load<Model>("models//flashlight1");
      this.flash2 = this.content.Load<Texture2D>("texture//flash2");
      this.flashlight2 = this.content.Load<Model>("models//flashlight2");
      this.flash3 = this.content.Load<Texture2D>("texture//flash3");
      this.flashlight3 = this.content.Load<Model>("models//flashlight3");
      this.ammoboxTexture = this.content.Load<Texture2D>("texture//ammoboxTexture2");
      this.ammobox = this.content.Load<Model>("models//ammobox2");
      this.goggleTexture = this.content.Load<Texture2D>("texture//geigerTexture3");
      this.goggles1 = this.content.Load<Model>("models//goggles1");
      this.cog = this.content.Load<Model>("models//damagedCog2");
      this.cogTexture = this.content.Load<Texture2D>("texture//cogTexture");
      this.goldpile = this.content.Load<Model>("models//goldpile");
      this.tuskcc = this.content.Load<Model>("models//tusky");
      this.tuskTexture = this.content.Load<Texture2D>("texture//tuskCrystal");
      this.skullcc = this.content.Load<Model>("models//skullCC");
      this.skullTexture = this.content.Load<Texture2D>("texture//skullCrystal");
      this.skyboxTexture = this.content.Load<Texture2D>("texture//skybox");
      this.map = this.content.Load<Model>("models//map1");
      this.mapTexture = this.content.Load<Texture2D>("texture//mapTexture1");
      this.exitkey = this.content.Load<Model>("models//exitkey");
      this.exitkeyTexture = this.content.Load<Texture2D>("texture//exitkeyTexture");
      this.myRot = Matrix.CreateFromQuaternion(new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
      this.myRotold = this.myRot;
      for (int index1 = 1; index1 < 7; ++index1)
      {
        CultureInfo invariantCulture = CultureInfo.InvariantCulture;
        StreamReader streamReader = new StreamReader("ABCDE3/blimp1.txt");
        this.targetDist = 0.0f;
        this.targetX = new Curve();
        this.targetZ = new Curve();
        float x1 = 0.0f;
        float y1 = 0.0f;
        for (int index2 = 0; index2 < 51; ++index2)
        {
          float x2 = x1;
          float y2 = y1;
          x1 = float.Parse(streamReader.ReadLine(), (IFormatProvider) invariantCulture);
          y1 = float.Parse(streamReader.ReadLine(), (IFormatProvider) invariantCulture);
          float position = (float) index2 / 50f;
          this.targetX.Keys.Add(new CurveKey(position, x1 + 3000f));
          this.targetZ.Keys.Add(new CurveKey(position, y1 + 3000f));
          if (index2 > 0)
            this.targetDist += Vector2.Distance(new Vector2(x2, y2), new Vector2(x1, y1));
        }
        streamReader.Close();
        streamReader.Dispose();
        this.SetTangents(ref this.targetX, ref this.targetZ);
      }
    }

    public void initTunnelItems()
    {
      this.kbPos = this.kePos = this.kmPos = this.kgPos = Vector3.Zero;
      this.kh1Pos = this.kh2Pos = this.kh3Pos = Vector3.Zero;
      this.ka1Pos = this.ka2Pos = this.ka3Pos = Vector3.Zero;
      this.kf1Pos = this.kf2Pos = this.kf3Pos = Vector3.Zero;
      this.kc1Pos = this.kc2Pos = this.kc3Pos = Vector3.Zero;
      this.kbHide = true;
      this.keHide = true;
      this.kmHide = true;
      this.kgHide = true;
      this.kh1Hide = true;
      this.kh2Hide = true;
      this.kh3Hide = true;
      this.ka1Hide = true;
      this.ka2Hide = true;
      this.ka3Hide = true;
      this.kf1Hide = true;
      this.kf2Hide = true;
      this.kf3Hide = true;
      this.kc1Hide = true;
      this.kc2Hide = true;
      this.kc3Hide = true;
      this.keyFlashlight1 = true;
      this.keyFlashlight2 = true;
      this.keyFlashlight3 = true;
      this.keyAmmobox = true;
      this.keyGoggles = true;
      this.keyMap = true;
      this.keyCog = true;
      this.keyExitkey = true;
      this.keySkull1 = true;
      this.keySkull2 = true;
      this.keySkull3 = true;
      this.keyTusk1 = true;
      this.keyTusk2 = true;
      this.keyTusk3 = true;
      this.rsFound = false;
      this.ttFound = false;
    }

    public void resetBlimp()
    {
      this.blimpTrans = new Vector3(1000f, 1500f, 1000f);
      Random random = new Random();
      this.blimpTrans = Vector3.Transform(new Vector3(0.0f, 0.0f, 1f), Matrix.CreateRotationY((float) random.Next(-15000, 15000) / 10f)) * (float) random.Next(2500, 5500);
      this.blimpTrans.X += 3000f;
      this.blimpTrans.Z += 3000f;
      this.blimpTrans.Y = (float) random.Next(1400, 2000);
      this.blimpHit = 50;
      this.propHit = 5;
      this.carryHit = 5;
      this.loop = (float) random.Next(0, 99) / 100f;
      this.myRot = Matrix.CreateFromQuaternion(new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
      this.myRotold = this.myRot;
      this.speed = (float) random.Next(250, 370) / 100f;
    }

    public void SetTangents(ref Curve x, ref Curve y)
    {
      for (int index1 = 0; index1 < x.Keys.Count; ++index1)
      {
        int index2 = index1 - 1;
        if (index2 < 0)
          index2 = index1;
        int index3 = index1 + 1;
        if (index3 == x.Keys.Count)
          index3 = index1;
        CurveKey key1 = x.Keys[index2];
        CurveKey key2 = x.Keys[index3];
        CurveKey key3 = x.Keys[index1];
        goldenkey.SetCurveKeyTangent(ref key1, ref key3, ref key2);
        x.Keys[index1] = key3;
        CurveKey key4 = y.Keys[index2];
        CurveKey key5 = y.Keys[index3];
        CurveKey key6 = y.Keys[index1];
        goldenkey.SetCurveKeyTangent(ref key4, ref key6, ref key5);
        y.Keys[index1] = key6;
      }
    }

    private static void SetCurveKeyTangent(ref CurveKey prev, ref CurveKey cur, ref CurveKey next)
    {
      float num1 = next.Position - prev.Position;
      float num2 = next.Value - prev.Value;
      if ((double) Math.Abs(num2) < 1.4012984643248171E-45)
      {
        cur.TangentIn = 0.0f;
        cur.TangentOut = 0.0f;
      }
      else
      {
        cur.TangentIn = num2 * (cur.Position - prev.Position) / num1;
        cur.TangentOut = num2 * (next.Position - cur.Position) / num1;
      }
    }

    public string updatetunnel(
      Vector3 mypos,
      Vector3 campos,
      int altcam,
      float npctilt,
      float npcrot)
    {
      string str = "-1";
      bool flag = false;
      if ((double) Vector3.Distance(campos, this.kePos) < 50.0)
      {
        if (!this.keHide)
        {
          this.sc.pickup1.Play(this.sc.ev, 0.1f, 0.0f);
          this.keHide = true;
          str = this.ke;
          this.keyExitkey = false;
        }
        else if (flag)
          str = this.ke;
        return str;
      }
      if ((double) Vector3.Distance(campos, this.kbPos) < 50.0)
      {
        if (!this.kbHide)
        {
          this.sc.pickup1.Play(this.sc.ev, 0.1f, 0.0f);
          this.kbHide = true;
          str = this.kb;
        }
        else if (flag)
          str = this.kb;
        return str;
      }
      if ((double) Vector3.Distance(campos, this.kmPos) < 50.0)
      {
        if (!this.kmHide)
        {
          this.sc.pickup1.Play(this.sc.ev, 0.2f, 0.0f);
          this.kmHide = true;
          str = this.km;
          this.keyMap = false;
        }
        else if (flag)
          str = this.km;
        return str;
      }
      if ((double) Vector3.Distance(campos, this.kgPos) < 50.0)
      {
        if (!this.kgHide)
        {
          this.sc.pickup1.Play(this.sc.ev, 0.2f, 0.0f);
          this.kgHide = true;
          str = this.kg;
          this.keyGoggles = false;
        }
        else if (flag)
          str = this.kg;
        return str;
      }
      if ((double) Vector3.Distance(campos, this.kh1Pos) < 50.0)
      {
        if (!this.kh1Hide)
        {
          this.sc.pickup1.Play(this.sc.ev, -0.1f, 0.0f);
          this.kh1Hide = true;
          str = this.kh1;
        }
        else if (flag)
          str = this.kh1;
        return str;
      }
      if ((double) Vector3.Distance(campos, this.kh2Pos) < 50.0)
      {
        if (!this.kh2Hide)
        {
          this.sc.pickup1.Play(this.sc.ev, -0.1f, 0.0f);
          this.kh2Hide = true;
          str = this.kh2;
        }
        else if (flag)
          str = this.kh2;
        return str;
      }
      if ((double) Vector3.Distance(campos, this.kh3Pos) < 50.0)
      {
        if (!this.kh3Hide)
        {
          this.sc.pickup1.Play(this.sc.ev, -0.1f, 0.0f);
          this.kh3Hide = true;
          str = this.kh3;
        }
        else if (flag)
          str = this.kh3;
        return str;
      }
      if ((double) Vector3.Distance(campos, this.kf1Pos) < 50.0)
      {
        if (!this.kf1Hide)
        {
          this.sc.pickup1.Play(this.sc.ev, -0.1f, 0.0f);
          this.kf1Hide = true;
          str = this.kf1;
          this.keyFlashlight1 = false;
        }
        else if (flag)
          str = this.kf1;
        return str;
      }
      if ((double) Vector3.Distance(campos, this.kf2Pos) < 50.0)
      {
        if (!this.kf2Hide)
        {
          this.sc.pickup1.Play(this.sc.ev, -0.1f, 0.0f);
          this.kf2Hide = true;
          str = this.kf2;
          this.keyFlashlight2 = false;
        }
        else if (flag)
          str = this.kf2;
        return str;
      }
      if ((double) Vector3.Distance(campos, this.kf3Pos) < 50.0)
      {
        if (!this.kf3Hide)
        {
          this.sc.pickup1.Play(this.sc.ev, -0.1f, 0.0f);
          this.kf3Hide = true;
          str = this.kf3;
          this.keyFlashlight3 = false;
        }
        else if (flag)
          str = this.kf3;
        return str;
      }
      if ((double) Vector3.Distance(campos, this.ka1Pos) < 50.0)
      {
        if (!this.ka1Hide)
        {
          this.sc.pickup1.Play(this.sc.ev, -0.1f, 0.0f);
          this.ka1Hide = true;
          str = this.ka1;
        }
        else if (flag)
          str = this.ka1;
        return str;
      }
      if ((double) Vector3.Distance(campos, this.ka2Pos) < 50.0)
      {
        if (!this.ka2Hide)
        {
          this.sc.pickup1.Play(this.sc.ev, -0.1f, 0.0f);
          this.ka2Hide = true;
          str = this.ka2;
        }
        else if (flag)
          str = this.ka2;
        return str;
      }
      if ((double) Vector3.Distance(campos, this.ka3Pos) < 50.0)
      {
        if (!this.ka3Hide)
        {
          this.sc.pickup1.Play(this.sc.ev, -0.1f, 0.0f);
          this.ka3Hide = true;
          str = this.ka3;
        }
        else if (flag)
          str = this.ka3;
        return str;
      }
      if ((double) Vector3.Distance(campos, this.kc1Pos) < 50.0)
      {
        if (!this.kc1Hide)
        {
          this.sc.pickup1.Play(this.sc.ev, -0.1f, 0.0f);
          this.kc1Hide = true;
          str = this.kc1;
        }
        else if (flag)
          str = this.kc1;
        return str;
      }
      if ((double) Vector3.Distance(campos, this.kc2Pos) < 50.0)
      {
        if (!this.kc2Hide)
        {
          this.sc.pickup1.Play(this.sc.ev, -0.1f, 0.0f);
          this.kc2Hide = true;
          str = this.kc2;
        }
        else if (flag)
          str = this.kc2;
        return str;
      }
      if ((double) Vector3.Distance(campos, this.kc3Pos) < 50.0)
      {
        if (!this.kc3Hide)
        {
          this.sc.pickup1.Play(this.sc.ev, -0.1f, 0.0f);
          this.kc3Hide = true;
          str = this.kc3;
        }
        else if (flag)
          str = this.kc3;
        return str;
      }
      Vector3 vector3 = (this.flashlight2pos + this.gogglepos) / 2f;
      Vector3 vector1 = Vector3.Normalize(Vector3.Transform(new Vector3(0.0f, 0.0f, 1f), Matrix.CreateRotationX(npctilt) * Matrix.CreateRotationY(npcrot)));
      this.nearItems = (double) Vector3.Distance(campos, vector3) < 700.0;
      this.nearExit = (double) Vector3.Distance(campos, new Vector3(2885f, -250f, 4485f)) < 700.0;
      if (this.nearItems)
      {
        if ((double) Vector3.Distance(campos, this.flashlight1pos) < 70.0 && !this.keyFlashlight1)
        {
          Vector3 vector2 = Vector3.Normalize(this.flashlight1pos - campos);
          if ((double) Vector3.Dot(vector1, vector2) > 0.64999997615814209)
            str = "4";
        }
        if ((double) Vector3.Distance(campos, this.flashlight2pos) < 70.0 && !this.keyFlashlight2)
        {
          Vector3 vector2 = Vector3.Normalize(this.flashlight2pos - campos);
          if ((double) Vector3.Dot(vector1, vector2) > 0.64999997615814209)
            str = "5";
        }
        if ((double) Vector3.Distance(campos, this.flashlight3pos) < 70.0 && !this.keyFlashlight3)
        {
          Vector3 vector2 = Vector3.Normalize(this.flashlight3pos - campos);
          if ((double) Vector3.Dot(vector1, vector2) > 0.64999997615814209)
            str = "6";
        }
        if ((double) Vector3.Distance(campos, this.ammoboxpos) < 70.0 && !this.keyAmmobox && this.sc.ammoboxCount > 0)
        {
          Vector3 vector2 = Vector3.Normalize(this.ammoboxpos - campos);
          if ((double) Vector3.Dot(vector1, vector2) > 0.64999997615814209)
            str = "7";
        }
        if ((double) Vector3.Distance(campos, this.gogglepos) < 70.0 && !this.keyGoggles)
        {
          Vector3 vector2 = Vector3.Normalize(this.gogglepos - campos);
          if ((double) Vector3.Dot(vector1, vector2) > 0.64999997615814209)
            str = "8";
        }
        this.atGears = false;
        if ((double) Vector3.Distance(campos, this.cogpos) < 70.0 && !this.keyCog && this.sc.cogCount > 0)
        {
          Vector3 vector2 = Vector3.Normalize(this.cogpos - campos);
          if ((double) Vector3.Dot(vector1, vector2) > 0.64999997615814209)
          {
            str = "9";
            this.atGears = true;
          }
        }
        if ((double) Vector3.Distance(campos, this.mappos) < 70.0 && !this.keyMap)
        {
          Vector3 vector2 = Vector3.Normalize(this.mappos - campos);
          if ((double) Vector3.Dot(vector1, vector2) > 0.64999997615814209)
            str = "10";
        }
        if ((double) Vector3.Distance(campos, this.exitkeypos) < 70.0 && !this.keyExitkey)
        {
          Vector3 vector2 = Vector3.Normalize(this.exitkeypos - campos);
          if ((double) Vector3.Dot(vector1, vector2) > 0.64999997615814209)
            str = "11";
        }
      }
      if ((double) Vector3.Distance(campos, this.skullpos) < 70.0 && !this.keySkull1)
      {
        Vector3 vector2 = Vector3.Normalize(this.skullpos - campos);
        if ((double) Vector3.Dot(vector1, vector2) > 0.64999997615814209)
          return "13";
      }
      if ((double) Vector3.Distance(campos, this.skullpos) < 70.0 && !this.keySkull2)
      {
        Vector3 vector2 = Vector3.Normalize(this.skullpos - campos);
        if ((double) Vector3.Dot(vector1, vector2) > 0.64999997615814209)
          return "14";
      }
      if ((double) Vector3.Distance(campos, this.skullpos) < 70.0 && !this.keySkull3)
      {
        Vector3 vector2 = Vector3.Normalize(this.skullpos - campos);
        if ((double) Vector3.Dot(vector1, vector2) > 0.64999997615814209)
          return "15";
      }
      if ((double) Vector3.Distance(campos, this.rs2Pos) < 70.0 && this.rsFound)
      {
        Vector3 vector2 = Vector3.Normalize(this.rs2Pos - campos);
        if ((double) Vector3.Dot(vector1, vector2) > 0.64999997615814209)
          return "16";
      }
      if ((double) Vector3.Distance(campos, this.tt2Pos) < 70.0 && this.ttFound)
      {
        Vector3 vector2 = Vector3.Normalize(this.tt2Pos - campos);
        if ((double) Vector3.Dot(vector1, vector2) > 0.64999997615814209)
          return "17";
      }
      if ((double) Vector3.Distance(campos, this.tuskpos) < 70.0 && !this.keyTusk1)
      {
        Vector3 vector2 = Vector3.Normalize(this.tuskpos - campos);
        if ((double) Vector3.Dot(vector1, vector2) > 0.64999997615814209)
          return "18";
      }
      if ((double) Vector3.Distance(campos, this.tuskpos) < 70.0 && !this.keyTusk2)
      {
        Vector3 vector2 = Vector3.Normalize(this.tuskpos - campos);
        if ((double) Vector3.Dot(vector1, vector2) > 0.64999997615814209)
          return "19";
      }
      if ((double) Vector3.Distance(campos, this.tuskpos) < 70.0 && !this.keyTusk3)
      {
        Vector3 vector2 = Vector3.Normalize(this.tuskpos - campos);
        if ((double) Vector3.Dot(vector1, vector2) > 0.64999997615814209)
          return "20";
      }
      return str;
    }

    public int update(Vector3 mypos, Vector3 campos, int altcam)
    {
      int num = -1;
      if (this.sc.dayTime == "pm" && this.sc.hats[2] == 0 && (double) Vector3.Distance(mypos, this.keypos1) < 50.0)
      {
        this.sc.pickup1.Play(this.sc.ev, 0.1f, 0.0f);
        this.sc.hats[2] = 1;
        this.sc.hatindex = 2;
        this.sc.SaveEquipables();
        num = 2;
        bool flag = true;
        for (int index = 1; index < 6; ++index)
        {
          if (this.sc.hats[index] == 0)
          {
            flag = false;
            break;
          }
        }
        if (flag)
          this.sc.trophy.win(this.sc.trophy.madhatter);
      }
      if (this.sc.hordemode)
      {
        if (this.sc.hats[9] == 0 && (double) Vector3.Distance(mypos, this.keypos6) < 50.0)
        {
          this.sc.pickup1.Play(this.sc.ev, 0.1f, 0.0f);
          this.sc.hatindex = 9;
          if (this.sc.dlcreleased || this.sc.developer)
          {
            this.sc.hats[9] = 1;
            this.sc.SaveEquipables();
          }
          num = 9;
        }
        if (this.sc.hats[10] == 0 && (double) Vector3.Distance(mypos, this.keypos7) < 50.0)
        {
          this.sc.pickup1.Play(this.sc.ev, 0.1f, 0.0f);
          this.sc.hatindex = 10;
          if (this.sc.dlcreleased || this.sc.developer)
          {
            this.sc.hats[10] = 1;
            this.sc.SaveEquipables();
          }
          num = 10;
        }
        if (this.sc.hats[11] == 0 && (double) Vector3.Distance(mypos, this.keypos8) < 50.0)
        {
          this.sc.pickup1.Play(this.sc.ev, 0.1f, 0.0f);
          this.sc.hatindex = 11;
          if (this.sc.dlcreleased || this.sc.developer)
          {
            this.sc.hats[11] = 1;
            this.sc.SaveEquipables();
          }
          num = 11;
        }
      }
      else
      {
        if (this.sc.revengeDay > 0 && this.sc.hats[1] == 0 && (double) Vector3.Distance(mypos, this.keypos2) < 50.0)
        {
          this.sc.pickup1.Play(this.sc.ev, 0.1f, 0.0f);
          this.sc.hats[1] = 1;
          this.sc.hatindex = 1;
          this.sc.SaveEquipables();
          num = 1;
          bool flag = true;
          for (int index = 1; index < 6; ++index)
          {
            if (this.sc.hats[index] == 0)
            {
              flag = false;
              break;
            }
          }
          if (flag)
            this.sc.trophy.win(this.sc.trophy.madhatter);
        }
        if (this.sc.dayTime == "am" && this.sc.hats[3] == 0 && (double) Vector3.Distance(campos, this.keypos3) < 50.0)
        {
          this.sc.pickup1.Play(this.sc.ev, 0.1f, 0.0f);
          this.sc.hats[3] = 1;
          this.sc.hatindex = 3;
          this.sc.SaveEquipables();
          num = 3;
          this.sc.trophy.win(this.sc.trophy.death);
          bool flag = true;
          for (int index = 1; index < 6; ++index)
          {
            if (this.sc.hats[index] == 0)
            {
              flag = false;
              break;
            }
          }
          if (flag)
            this.sc.trophy.win(this.sc.trophy.madhatter);
        }
        if (this.sc.currentDay % 20 == 0 && this.sc.hats[4] == 0 && (double) Vector3.Distance(campos, this.keypos4) < 50.0)
        {
          this.sc.pickup1.Play(this.sc.ev, 0.1f, 0.0f);
          this.sc.hats[4] = 1;
          this.sc.hatindex = 4;
          this.sc.SaveEquipables();
          num = 4;
          bool flag = true;
          for (int index = 1; index < 6; ++index)
          {
            if (this.sc.hats[index] == 0)
            {
              flag = false;
              break;
            }
          }
          if (flag)
            this.sc.trophy.win(this.sc.trophy.madhatter);
        }
        if (altcam == 1 && this.sc.hats[5] == 0 && (double) Vector3.Distance(campos, this.keypos5) < 50.0)
        {
          this.sc.pickup1.Play(this.sc.ev, 0.1f, 0.0f);
          this.sc.hats[5] = 1;
          this.sc.hatindex = 5;
          this.sc.SaveEquipables();
          num = 5;
          this.sc.trophy.win(this.sc.trophy.death);
          bool flag = true;
          for (int index = 1; index < 6; ++index)
          {
            if (this.sc.hats[index] == 0)
            {
              flag = false;
              break;
            }
          }
          if (flag)
            this.sc.trophy.win(this.sc.trophy.madhatter);
        }
      }
      return num;
    }

    public void updateBlimp()
    {
      if (this.propHit <= 0)
        this.speed = 1.5f;
      this.loop += 1f / this.targetDist * this.speed;
      if ((double) this.loop >= 1.0)
        this.loop = 0.0f;
      this.tx = this.targetX.Evaluate(this.loop);
      this.tz = this.targetZ.Evaluate(this.loop);
      this.blimpRot = goldenkey.WrapAngle(this.blimpRot + MathHelper.Clamp(goldenkey.WrapAngle((float) (-Math.Atan2((double) this.blimpTrans.Z - (double) this.tz, (double) this.blimpTrans.X - (double) this.tx) - 1.5700000524520874) - this.blimpRot), -0.035f, 0.035f));
      this.myRotold = Matrix.CreateRotationY(this.blimpRot);
      if ((double) this.rayAmt > 0.008999999612569809)
      {
        this.myRot *= Matrix.CreateFromAxisAngle(Vector3.Normalize(Vector3.Cross(this.ray, Vector3.Up)), this.rayAmt);
        this.rayAmt *= 0.99f;
      }
      Quaternion rotation1;
      this.myRot.Decompose(out Vector3 _, out rotation1, out Vector3 _);
      Quaternion rotation2;
      this.myRotold.Decompose(out Vector3 _, out rotation2, out Vector3 _);
      this.myRot = Matrix.CreateFromQuaternion(Quaternion.Lerp(rotation1, rotation2, 0.004f));
      this.blimpTrans += Vector3.Transform(new Vector3(0.0f, 0.0f, 1f), this.myRot) * this.speed;
      if ((double) this.blimpTrans.Y < 1500.0)
        ++this.blimpTrans.Y;
      if ((double) this.blimpTrans.Y <= 1500.0)
        return;
      --this.blimpTrans.Y;
    }

    private static float WrapAngle(float radians)
    {
      while ((double) radians < -3.1415927410125732)
        radians += 6.28318548f;
      while ((double) radians > 3.1415927410125732)
        radians -= 6.28318548f;
      return radians;
    }

    public void draw(Vector3 pos, Matrix view, Matrix proj, int altcam)
    {
      ++this.counter;
      if (this.sc.dayTime == "pm" && this.sc.hats[2] == 0)
        this.DrawKey(this.keypos1, view, proj);
      if (this.sc.hordemode)
      {
        if (this.sc.hats[9] == 0)
          this.DrawKey(this.keypos6, view, proj);
        if (this.sc.hats[10] == 0)
          this.DrawKey(this.keypos7, view, proj);
        if (this.sc.hats[11] != 0)
          return;
        this.DrawKey(this.keypos8, view, proj);
      }
      else
      {
        if (this.sc.revengeDay > 0 && this.sc.hats[1] == 0)
          this.DrawKey(this.keypos2, view, proj);
        if (this.sc.hats[3] == 0 && this.sc.dayTime == "am" && (this.sc.gameState != 1 || altcam == 1))
          this.DrawKey(this.keypos3, view, proj);
        if (this.sc.hats[4] == 0 && this.sc.currentDay % 20 == 0 && (this.sc.gameState != 1 || altcam == 1))
          this.DrawKey(this.keypos4, view, proj);
        if (this.sc.hats[5] == 0 && (this.sc.gameState != 1 || altcam == 1))
          this.DrawKey(this.keypos5, view, proj);
        if (!this.sc.mustarDay || this.blimpHit <= 0)
          return;
        this.updateBlimp();
        this.DrawBlimp(view, proj);
      }
    }

    public void DrawKey(Vector3 pos, Matrix view, Matrix proj)
    {
      float radians = this.counter / 240f;
      Matrix matrix = Matrix.CreateScale(3f) * Matrix.CreateRotationY(radians) * Matrix.CreateTranslation(pos.X, pos.Y, pos.Z);
      this.sc.hatPack.Meshes[35].MeshParts[0].Effect = this.keyeffect;
      this.keyeffect.Parameters["World"].SetValue(matrix);
      this.keyeffect.Parameters["View"].SetValue(view);
      this.keyeffect.Parameters["Projection"].SetValue(proj);
      this.keyeffect.Parameters["LightDirection"].SetValue(Vector3.Normalize(new Vector3((float) Math.Sin((double) this.counter / 15.0), 0.7f, (float) -Math.Cos((double) this.counter / 15.0))));
      this.keyeffect.Parameters["DiffuseLight"].SetValue(0.9f);
      this.keyeffect.Parameters["AmbientLight"].SetValue(0.42f);
      if ((double) this.counter % 95.0 == 0.0)
        this.keyeffect.Parameters["AmbientLight"].SetValue(2f);
      this.keyeffect.Parameters["Texture"].SetValue((Texture) this.sc.goldkeyTexture);
      this.keyeffect.CurrentTechnique = this.keyeffect.Techniques["mykey"];
      this.sc.hatPack.Meshes[35].Draw();
    }

    public void DrawBlimp(Matrix view, Matrix proj)
    {
      Matrix matrix = this.myRot * Matrix.CreateTranslation(this.blimpTrans);
      this.sc.hatPack.Meshes[36].MeshParts[0].Effect = this.keyeffect;
      this.keyeffect.Parameters["World"].SetValue(matrix);
      this.keyeffect.Parameters["View"].SetValue(view);
      this.keyeffect.Parameters["Projection"].SetValue(proj);
      this.keyeffect.Parameters["LightDirection"].SetValue(Vector3.Normalize(new Vector3(1f, 0.7f, 0.0f)));
      this.keyeffect.Parameters["DiffuseLight"].SetValue(0.9f);
      this.keyeffect.Parameters["AmbientLight"].SetValue(0.36f);
      this.keyeffect.Parameters["Texture"].SetValue((Texture) this.sc.blimpTexture);
      this.keyeffect.CurrentTechnique = this.keyeffect.Techniques["mykey"];
      this.sc.hatPack.Meshes[36].Draw();
      if (this.carryHit > 0)
      {
        this.sc.hatPack.Meshes[37].MeshParts[0].Effect = this.keyeffect;
        this.sc.hatPack.Meshes[37].Draw();
      }
      if (this.propHit <= 0)
        return;
      this.sc.hatPack.Meshes[38].MeshParts[0].Effect = this.keyeffect;
      this.keyeffect.Parameters["World"].SetValue(Matrix.CreateRotationZ(this.counter / 10f) * this.myRot * Matrix.CreateTranslation(this.blimpTrans));
      this.sc.hatPack.Meshes[38].Draw();
    }

    public void drawTunnelKeys(Vector3 pos, Matrix view, Matrix proj, Vector3 campos, int altcam)
    {
      this.counter += 6f;
      if (this.atGears)
        this.cogcounter += 0.3f;
      ++this.gearticker;
      if (this.gearticker % 87 == 0 && this.atGears)
        this.geartick.Play(this.sc.ev * 1f, 0.0f, 0.0f);
      if (!this.kbHide)
        this.DrawGoldKey2(this.kbPos, view, proj);
      else
        this.DrawGoldKeyPile(this.kbPos, view, proj);
      if (!this.keHide)
        this.DrawGoldKey2(this.kePos, view, proj);
      else
        this.DrawGoldKeyPile(this.kePos, view, proj);
      if (!this.kmHide)
        this.DrawGoldKey2(this.kmPos, view, proj);
      else
        this.DrawGoldKeyPile(this.kmPos, view, proj);
      if (!this.kgHide)
        this.DrawGoldKey2(this.kgPos, view, proj);
      else
        this.DrawGoldKeyPile(this.kgPos, view, proj);
      if (!this.kh1Hide)
        this.DrawGoldKey2(this.kh1Pos, view, proj);
      else
        this.DrawGoldKeyPile(this.kh1Pos, view, proj);
      if (!this.kh2Hide)
        this.DrawGoldKey2(this.kh2Pos, view, proj);
      else
        this.DrawGoldKeyPile(this.kh2Pos, view, proj);
      if (!this.kh3Hide)
        this.DrawGoldKey2(this.kh3Pos, view, proj);
      else
        this.DrawGoldKeyPile(this.kh3Pos, view, proj);
      if (!this.kf1Hide)
        this.DrawGoldKey2(this.kf1Pos, view, proj);
      else
        this.DrawGoldKeyPile(this.kf1Pos, view, proj);
      if (!this.kf2Hide)
        this.DrawGoldKey2(this.kf2Pos, view, proj);
      else
        this.DrawGoldKeyPile(this.kf2Pos, view, proj);
      if (!this.kf3Hide)
        this.DrawGoldKey2(this.kf3Pos, view, proj);
      else
        this.DrawGoldKeyPile(this.kf3Pos, view, proj);
      if (!this.kc1Hide)
        this.DrawGoldKey2(this.kc1Pos, view, proj);
      else
        this.DrawGoldKeyPile(this.kc1Pos, view, proj);
      if (!this.kc2Hide)
        this.DrawGoldKey2(this.kc2Pos, view, proj);
      else
        this.DrawGoldKeyPile(this.kc2Pos, view, proj);
      if (!this.kc3Hide)
        this.DrawGoldKey2(this.kc3Pos, view, proj);
      else
        this.DrawGoldKeyPile(this.kc3Pos, view, proj);
      if (!this.ka1Hide)
        this.DrawGoldKey2(this.ka1Pos, view, proj);
      else
        this.DrawGoldKeyPile(this.ka1Pos, view, proj);
      if (!this.ka2Hide)
        this.DrawGoldKey2(this.ka2Pos, view, proj);
      else
        this.DrawGoldKeyPile(this.ka2Pos, view, proj);
      if (!this.ka3Hide)
        this.DrawGoldKey2(this.ka3Pos, view, proj);
      else
        this.DrawGoldKeyPile(this.ka3Pos, view, proj);
      if (this.nearItems)
      {
        if (!this.keyFlashlight1)
          this.DrawInvModel(this.flashlight1matrix, view, proj, this.flashlight1, this.flash1);
        if (!this.keyFlashlight2)
          this.DrawInvModel(this.flashlight2matrix, view, proj, this.flashlight2, this.flash2);
        if (!this.keyFlashlight3)
          this.DrawInvModel(this.flashlight3matrix, view, proj, this.flashlight3, this.flash3);
        if (!this.keyGoggles)
          this.DrawInvModel(this.gogglematrix, view, proj, this.goggles1, this.goggleTexture);
        if (!this.keyAmmobox && this.sc.ammoboxCount > 0)
          this.DrawBoxes(this.ammoboxmatrix, view, proj, this.ammobox, this.ammoboxTexture);
        if (!this.keyCog && this.sc.cogCount > 0)
          this.DrawCogs(this.cogmatrix, view, proj, this.cog, this.cogTexture);
        if (!this.keyExitkey)
          this.DrawInvModel(this.exitkeymatrix, view, proj, this.exitkey, this.exitkeyTexture);
        if (!this.keyMap)
          this.DrawInvModel(this.mapmatrix, view, proj, this.map, this.mapTexture);
      }
      Vector3 lite = new Vector3(0.7f, -0.7f, 0.2f);
      if (!this.keySkull1)
        this.DrawInvSkull(new Vector3(0.1f, 0.3f, 1f), this.skullmatrix, view, proj, campos, this.skullcc, this.skullTexture, lite, 0.0f);
      else if (!this.keySkull2)
        this.DrawInvSkull(new Vector3(1f, 0.1f, 0.1f), this.skullmatrix, view, proj, campos, this.skullcc, this.skullTexture, lite, 0.1f);
      else if (!this.keySkull3)
        this.DrawInvSkull(new Vector3(0.2f, 1f, 0.25f), this.skullmatrix, view, proj, campos, this.skullcc, this.skullTexture, lite, 0.0f);
      lite = new Vector3((float) Math.Sin((double) this.sc.myTimer / 30.0), -0.4f, -(float) Math.Cos((double) this.sc.myTimer / 30.0));
      if (!this.keyTusk1)
        this.DrawInvTusk(new Vector3(0.1f, 0.3f, 1f), this.tuskmatrix, view, proj, campos, this.tuskcc, lite, (float) (0.23299999535083771 + (double) this.sc.myTimer / 1500.0));
      if (!this.keyTusk2)
        this.DrawInvTusk(new Vector3(1f, 0.1f, 0.1f), this.tuskmatrix, view, proj, campos, this.tuskcc, lite, 0.0f);
      if (this.keyTusk3)
        return;
      this.DrawInvTusk(new Vector3(0.2f, 1f, 0.25f), this.tuskmatrix, view, proj, campos, this.tuskcc, lite, (float) (5.1999998092651367 - (double) this.sc.myTimer / 1800.0));
    }

    public void drawSkullDisplay(int i, Matrix view, Matrix proj, Vector3 campos, Vector3 lite)
    {
      if (i == 1)
        this.DrawInvSkull(new Vector3(0.1f, 0.3f, 1f), this.matrix_0, view, proj, campos, this.skullcc, this.skullTexture, lite, (float) (0.23299999535083771 + (double) this.sc.myTimer / 1500.0));
      if (i == 2)
        this.DrawInvSkull(new Vector3(1f, 0.1f, 0.1f), this.matrix_1, view, proj, campos, this.skullcc, this.skullTexture, lite, 0.0f);
      if (i != 3)
        return;
      this.DrawInvSkull(new Vector3(0.2f, 1f, 0.25f), this.matrix_2, view, proj, campos, this.skullcc, this.skullTexture, lite, (float) (5.1999998092651367 - (double) this.sc.myTimer / 1800.0));
    }

    public void drawTuskDisplay(int i, Matrix view, Matrix proj, Vector3 campos, Vector3 lite)
    {
      if (i == 1)
        this.DrawInvTusk(new Vector3(0.1f, 0.1f, 1f), this.matrix_3, view, proj, campos, this.tuskcc, lite, (float) (0.23299999535083771 + (double) this.sc.myTimer / 1500.0));
      if (i == 2)
        this.DrawInvTusk(new Vector3(1f, 0.1f, 0.1f), this.matrix_4, view, proj, campos, this.tuskcc, lite, 0.0f);
      if (i != 3)
        return;
      this.DrawInvTusk(new Vector3(0.15f, 1f, 0.15f), this.matrix_5, view, proj, campos, this.tuskcc, lite, (float) (5.1999998092651367 - (double) this.sc.myTimer / 1800.0));
    }

    public void DrawGoldKey2(Vector3 pos, Matrix view, Matrix proj)
    {
      if (pos == Vector3.Zero)
        return;
      float radians = this.counter / 240f;
      Matrix matrix = Matrix.CreateScale(2f) * Matrix.CreateRotationY(radians) * Matrix.CreateTranslation(pos.X, pos.Y, pos.Z);
      this.sc.hatPack.Meshes[35].MeshParts[0].Effect = this.keyeffect;
      this.keyeffect.Parameters["World"].SetValue(matrix);
      this.keyeffect.Parameters["View"].SetValue(view);
      this.keyeffect.Parameters["Projection"].SetValue(proj);
      this.keyeffect.Parameters["LightDirection"].SetValue(Vector3.Normalize(new Vector3((float) Math.Sin((double) this.counter / 25.0), 0.7f, (float) -Math.Cos((double) this.counter / 25.0))));
      this.keyeffect.Parameters["DiffuseLight"].SetValue(0.9f);
      this.keyeffect.Parameters["AmbientLight"].SetValue(0.42f);
      if ((double) this.counter % 145.0 == 0.0)
        this.keyeffect.Parameters["AmbientLight"].SetValue(2f);
      this.keyeffect.Parameters["Texture"].SetValue((Texture) this.sc.goldkeyTexture);
      this.keyeffect.CurrentTechnique = this.keyeffect.Techniques["mykey"];
      this.sc.hatPack.Meshes[35].Draw();
    }

    public void DrawGoldKeyPile(Vector3 pos, Matrix view, Matrix proj)
    {
      if (pos == Vector3.Zero)
        return;
      float radians = (float) (new Random((int) pos.Y).Next(-8600, 8600) / 1000);
      Matrix matrix = Matrix.CreateScale(2f) * Matrix.CreateRotationY(radians) * Matrix.CreateTranslation(pos.X, pos.Y - (float) this.sc.tunnelUppy, pos.Z);
      this.goldpile.Meshes[0].MeshParts[0].Effect = this.keyeffect;
      this.keyeffect.Parameters["World"].SetValue(matrix);
      this.keyeffect.Parameters["View"].SetValue(view);
      this.keyeffect.Parameters["Projection"].SetValue(proj);
      this.keyeffect.Parameters["LightDirection"].SetValue(Vector3.Normalize(new Vector3((float) Math.Sin((double) this.counter / 265.0), 0.7f, (float) -Math.Cos((double) this.counter / 265.0))));
      this.keyeffect.Parameters["DiffuseLight"].SetValue(0.6f);
      this.keyeffect.Parameters["AmbientLight"].SetValue(0.22f);
      this.keyeffect.Parameters["Texture"].SetValue((Texture) this.sc.goldkeyTexture);
      this.keyeffect.CurrentTechnique = this.keyeffect.Techniques["mykey"];
      this.goldpile.Meshes[0].Draw();
    }

    public void DrawInvModel(
      Matrix pos,
      Matrix view,
      Matrix proj,
      Model model,
      Texture2D texture)
    {
      Matrix matrix = Matrix.CreateScale(0.8f) * pos;
      model.Meshes[0].MeshParts[0].Effect = this.keyeffect;
      this.keyeffect.Parameters["World"].SetValue(matrix);
      this.keyeffect.Parameters["View"].SetValue(view);
      this.keyeffect.Parameters["Projection"].SetValue(proj);
      this.keyeffect.Parameters["LightDirection"].SetValue(Vector3.Normalize(new Vector3((float) Math.Sin((double) this.counter / 65.0), 0.7f, (float) -Math.Cos((double) this.counter / 65.0))));
      this.keyeffect.Parameters["DiffuseLight"].SetValue(0.85f);
      this.keyeffect.Parameters["AmbientLight"].SetValue(0.32f);
      this.keyeffect.Parameters["Texture"].SetValue((Texture) texture);
      this.keyeffect.CurrentTechnique = this.keyeffect.Techniques["mykey"];
      model.Meshes[0].Draw();
    }

    public void DrawBoxes(Matrix pos, Matrix view, Matrix proj, Model model, Texture2D texture)
    {
      float[] numArray1 = new float[10]
      {
        -21f,
        -12f,
        -5f,
        3.9f,
        13f,
        21f,
        -27f,
        27f,
        -16f,
        16f
      };
      float[] numArray2 = new float[10]
      {
        -3.2f,
        -2.5f,
        1.5f,
        1.4f,
        -2.5f,
        -3.1f,
        6f,
        6f,
        7.5f,
        7.6f
      };
      float[] numArray3 = new float[10]
      {
        -0.5f,
        -0.35f,
        -0.015f,
        -0.02f,
        0.34f,
        0.51f,
        -0.65f,
        0.65f,
        -0.7f,
        0.99f
      };
      int[] numArray4 = new int[10]
      {
        2,
        3,
        1,
        4,
        0,
        5,
        6,
        7,
        8,
        9
      };
      for (int index = 0; index < this.sc.ammoboxCount; ++index)
      {
        Matrix matrix = Matrix.CreateScale(0.95f) * Matrix.CreateRotationY(numArray3[numArray4[index]]) * Matrix.CreateTranslation(numArray1[numArray4[index]], 0.0f, numArray2[numArray4[index]]) * pos;
        model.Meshes[0].MeshParts[0].Effect = this.keyeffect;
        this.keyeffect.Parameters["World"].SetValue(matrix);
        this.keyeffect.Parameters["View"].SetValue(view);
        this.keyeffect.Parameters["Projection"].SetValue(proj);
        this.keyeffect.Parameters["LightDirection"].SetValue(Vector3.Normalize(new Vector3((float) Math.Sin((double) this.counter / 65.0), 0.7f, (float) -Math.Cos((double) this.counter / 65.0))));
        this.keyeffect.Parameters["DiffuseLight"].SetValue(0.9f);
        this.keyeffect.Parameters["AmbientLight"].SetValue(0.42f);
        this.keyeffect.Parameters["Texture"].SetValue((Texture) texture);
        this.keyeffect.CurrentTechnique = this.keyeffect.Techniques["mykey"];
        model.Meshes[0].Draw();
      }
    }

    public void DrawCogs(Matrix pos, Matrix view, Matrix proj, Model model, Texture2D texture)
    {
      Matrix translation = Matrix.CreateTranslation(10.58f, 0.165f, 0.0f);
      float[] numArray1 = new float[2]{ 9.9f, -12f };
      float[] numArray2 = new float[2]{ -3.5f, -4.2f };
      float[] numArray3 = new float[2]
      {
        3.34159017f,
        2.81159019f
      };
      float radians = (float) (-(double) MathHelper.ToRadians(this.cogcounter) * 0.5) + MathHelper.ToRadians(4f);
      Matrix matrix1 = Matrix.CreateRotationX(MathHelper.ToRadians(25.892f)) * Matrix.CreateRotationZ(MathHelper.ToRadians(-4.823f)) * Matrix.CreateTranslation(0.0f, 4.268f, 0.0f);
      int num = 1;
      if (this.sc.cogCount > 1)
        num = 2;
      for (int index = 0; index < num; ++index)
      {
        if (index == 1)
          radians *= 2.2f;
        Matrix matrix2 = Matrix.CreateRotationY(radians) * matrix1 * Matrix.CreateScale(0.85f) * Matrix.CreateRotationY(numArray3[index]) * Matrix.CreateTranslation(numArray1[index], 0.0f, numArray2[index]) * pos;
        model.Meshes[0].MeshParts[0].Effect = this.keyeffect;
        this.keyeffect.Parameters["World"].SetValue(matrix2);
        this.keyeffect.Parameters["View"].SetValue(view);
        this.keyeffect.Parameters["Projection"].SetValue(proj);
        this.keyeffect.Parameters["LightDirection"].SetValue(Vector3.Normalize(new Vector3((float) Math.Sin((double) this.counter / 65.0), 0.7f, (float) -Math.Cos((double) this.counter / 65.0))));
        this.keyeffect.Parameters["DiffuseLight"].SetValue(0.9f);
        this.keyeffect.Parameters["AmbientLight"].SetValue(0.42f);
        this.keyeffect.Parameters["Texture"].SetValue((Texture) texture);
        this.keyeffect.CurrentTechnique = this.keyeffect.Techniques["mykey"];
        model.Meshes[0].Draw();
        float cogcounter = this.cogcounter;
        if (index == 1)
          cogcounter *= 2.2f;
        Matrix matrix3 = Matrix.CreateRotationY(MathHelper.ToRadians(cogcounter)) * translation * matrix1 * Matrix.CreateScale(0.85f) * Matrix.CreateRotationY(numArray3[index]) * Matrix.CreateTranslation(numArray1[index], 0.0f, numArray2[index]) * pos;
        model.Meshes[1].MeshParts[0].Effect = this.keyeffect;
        this.keyeffect.Parameters["World"].SetValue(matrix3);
        this.keyeffect.CurrentTechnique = this.keyeffect.Techniques["mykey"];
        model.Meshes[1].Draw();
      }
    }

    public void DrawInvSkull(
      Vector3 cc,
      Matrix pos,
      Matrix view,
      Matrix proj,
      Vector3 campos,
      Model model,
      Texture2D texture,
      Vector3 lite,
      float offset)
    {
      Matrix matrix1 = Matrix.CreateScale(0.25f) * pos;
      model.Meshes[0].MeshParts[0].Effect = this.skulleffect;
      Matrix matrix2 = Matrix.Transpose(Matrix.Invert(matrix1 * model.Meshes[0].ParentBone.Transform));
      this.skulleffect.Parameters["World"].SetValue(matrix1 * model.Meshes[0].ParentBone.Transform);
      this.skulleffect.Parameters["View"].SetValue(view);
      this.skulleffect.Parameters["Projection"].SetValue(proj);
      this.skulleffect.Parameters["move"].SetValue(this.sc.myTimer / 340f);
      this.skulleffect.Parameters["move2"].SetValue(this.sc.myTimer / 360f);
      this.skulleffect.Parameters["offsetz"].SetValue(offset);
      this.skulleffect.Parameters["tint"].SetValue(cc);
      this.skulleffect.Parameters["notch"].SetValue(this.sc.notch);
      this.skulleffect.Parameters["Texture"].SetValue((Texture) this.skullTexture);
      this.skulleffect.Parameters["ReflectionMap"].SetValue((Texture) this.skyboxTexture);
      this.skulleffect.Parameters["CameraPosition"].SetValue(campos);
      this.skulleffect.Parameters[nameof (lite)].SetValue(lite);
      this.skulleffect.Parameters["ReflectionView"].SetValue(matrix2);
      this.skulleffect.CurrentTechnique = this.skulleffect.Techniques[0];
      model.Meshes[0].Draw();
    }

    public void DrawInvTusk(
      Vector3 cc,
      Matrix pos,
      Matrix view,
      Matrix proj,
      Vector3 campos,
      Model model,
      Vector3 lite,
      float offset)
    {
      Matrix matrix1 = Matrix.CreateScale(0.25f) * pos;
      model.Meshes[0].MeshParts[0].Effect = this.skulleffect;
      Matrix matrix2 = Matrix.Transpose(Matrix.Invert(matrix1 * model.Meshes[0].ParentBone.Transform));
      this.skulleffect.Parameters["World"].SetValue(matrix1 * model.Meshes[0].ParentBone.Transform);
      this.skulleffect.Parameters["View"].SetValue(view);
      this.skulleffect.Parameters["Projection"].SetValue(proj);
      this.skulleffect.Parameters["move"].SetValue(this.sc.myTimer / 340f);
      this.skulleffect.Parameters["move2"].SetValue(this.sc.myTimer / 360f);
      this.skulleffect.Parameters["offsetz"].SetValue(offset);
      this.skulleffect.Parameters["tint"].SetValue(cc);
      this.skulleffect.Parameters["notch"].SetValue(this.sc.notch);
      this.skulleffect.Parameters["Texture"].SetValue((Texture) this.tuskTexture);
      this.skulleffect.Parameters["ReflectionMap"].SetValue((Texture) this.skyboxTexture);
      this.skulleffect.Parameters["CameraPosition"].SetValue(campos);
      this.skulleffect.Parameters[nameof (lite)].SetValue(lite);
      this.skulleffect.Parameters["ReflectionView"].SetValue(matrix2);
      this.skulleffect.CurrentTechnique = this.skulleffect.Techniques[0];
      model.Meshes[0].Draw();
    }
  }
}
