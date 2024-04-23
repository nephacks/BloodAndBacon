// Decompiled with JetBrains decompiler
// Type: Blood.ExplosionSmokeSettingsSystem
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
  internal class ExplosionSmokeSettingsSystem : ParticleSystem
  {
    public ExplosionSmokeSettingsSystem(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "smoke";
      settings.MaxParticles = 200;
      settings.Duration = TimeSpan.FromSeconds(4.0);
      settings.DurationRandomness = 0.0f;
      settings.EmitterVelocitySensitivity = 1f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 50f;
      settings.MinVerticalVelocity = -10f;
      settings.MaxVerticalVelocity = 50f;
      settings.Gravity = new Vector3(0.0f, -20f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color((int) byte.MaxValue, 211, 211, 211);
      settings.MaxColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      settings.MinRotateSpeed = -2f;
      settings.MaxRotateSpeed = 2f;
      settings.MinStartSize = 10f;
      settings.MaxStartSize = 10f;
      settings.MinEndSize = 100f;
      settings.MaxEndSize = 200f;
      settings.BlendState = BlendState.Additive;
    }
  }
}
