// Decompiled with JetBrains decompiler
// Type: Blood.SoundEffects
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

#nullable disable
namespace Blood
{
  public class SoundEffects
  {
    public static int totalReplay;
    public int count;
    public static int total;
    public SoundEffectInstance[] sound;
    public List<int> missed = new List<int>();
    public bool canReplay;

    public SoundEffects(int size)
    {
      SoundEffects.total += size;
      this.sound = new SoundEffectInstance[size];
      this.canReplay = false;
      this.missed.Capacity = 0;
    }

    public SoundEffects(int size, bool canReplay)
    {
      SoundEffects.total += size;
      this.sound = new SoundEffectInstance[size];
      this.canReplay = canReplay;
      this.missed.Capacity = 5;
    }

    public void Play(float vol, float pitch, float pan)
    {
      ++this.count;
      if (this.count > this.sound.Length - 1)
        this.count = 0;
      if (this.sound[this.count].State == SoundState.Stopped)
      {
        this.sound[this.count].Volume = vol;
        this.sound[this.count].Pitch = pitch;
        this.sound[this.count].Pan = pan;
        this.sound[this.count].Play();
      }
      else
      {
        this.sound[this.count].Stop();
        if (this.sound[this.count].State == SoundState.Stopped)
        {
          this.sound[this.count].Play();
        }
        else
        {
          if (!this.canReplay || this.missed.Count >= 5)
            return;
          this.missed.Add(this.count);
          ++SoundEffects.totalReplay;
        }
      }
    }

    public void rePlay()
    {
      if (this.missed.Count <= 0)
        return;
      if (this.sound[this.missed[0]].State == SoundState.Stopped)
      {
        this.sound[this.missed[0]].Play();
        this.missed.RemoveAt(0);
        --SoundEffects.totalReplay;
      }
      else
        this.sound[this.missed[0]].Stop();
    }

    public void ramp(float vol, float rampy)
    {
      if (this.sound[0].State == SoundState.Stopped || this.sound[0].State == SoundState.Paused)
        this.sound[0].Play();
      if (this.sound[0].State != SoundState.Playing)
        return;
      this.sound[0].Volume = vol * MathHelper.Lerp(0.0f, 1f, rampy);
      this.sound[0].Pitch = MathHelper.Lerp(-1f, 0.0f, rampy);
    }
  }
}
