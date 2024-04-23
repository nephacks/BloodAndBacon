// Decompiled with JetBrains decompiler
// Type: Blood.ProjectileTrailSettingsSystem
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
  internal class ProjectileTrailSettingsSystem : ParticleSystem
  {
    public ProjectileTrailSettingsSystem(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "smoke";
      settings.MaxParticles = 1000;
      settings.Duration = TimeSpan.FromSeconds(3.0);
      settings.DurationRandomness = 1.5f;
      settings.EmitterVelocitySensitivity = 0.1f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 1f;
      settings.MinVerticalVelocity = -1f;
      settings.MaxVerticalVelocity = 1f;
      settings.Gravity = new Vector3(0.0f, 0.0f, 0.0f);
      settings.EndVelocity = 1f;
      settings.MinColor = new Color((int) byte.MaxValue, 64, 96, 128);
      settings.MaxColor = new Color(128, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      settings.MinRotateSpeed = -4f;
      settings.MaxRotateSpeed = 4f;
      settings.MinStartSize = 2f;
      settings.MaxStartSize = 4f;
      settings.MinEndSize = 5f;
      settings.MaxEndSize = 15f;
      settings.BlendState = BlendState.NonPremultiplied;
    }
  }
}
