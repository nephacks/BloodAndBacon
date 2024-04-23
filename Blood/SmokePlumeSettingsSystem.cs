// Decompiled with JetBrains decompiler
// Type: Blood.SmokePlumeSettingsSystem
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace Blood
{
  internal class SmokePlumeSettingsSystem : ParticleSystem
  {
    public SmokePlumeSettingsSystem(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "smoke";
      settings.MaxParticles = 3500;
      settings.Duration = TimeSpan.FromSeconds(3.0);
      settings.DurationRandomness = 0.22f;
      settings.EmitterVelocitySensitivity = 1f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 15f;
      settings.MinVerticalVelocity = 10f;
      settings.MaxVerticalVelocity = 20f;
      settings.Gravity = new Vector3(-20f, -5f, 0.0f);
      settings.EndVelocity = 0.75f;
      settings.MinColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      settings.MaxColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      settings.MinRotateSpeed = -1f;
      settings.MaxRotateSpeed = 1f;
      settings.MinStartSize = 25f;
      settings.MaxStartSize = 80f;
      settings.MinEndSize = 90f;
      settings.MaxEndSize = 200f;
      settings.BlendState = BlendState.NonPremultiplied;
    }
  }
}
