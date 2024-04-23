// Decompiled with JetBrains decompiler
// Type: Blood.ExplosionSettingsSystem
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
  internal class ExplosionSettingsSystem : ParticleSystem
  {
    public ExplosionSettingsSystem(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "explosion";
      settings.MaxParticles = 100;
      settings.Duration = TimeSpan.FromSeconds(2.0);
      settings.DurationRandomness = 1f;
      settings.EmitterVelocitySensitivity = 1f;
      settings.MinHorizontalVelocity = 20f;
      settings.MaxHorizontalVelocity = 30f;
      settings.MinVerticalVelocity = -20f;
      settings.MaxVerticalVelocity = 20f;
      settings.Gravity = new Vector3(0.0f, 0.0f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color((int) byte.MaxValue, 128, 128, 128);
      settings.MaxColor = new Color((int) byte.MaxValue, 169, 169, 169);
      settings.MinRotateSpeed = -1f;
      settings.MaxRotateSpeed = 1f;
      settings.MinStartSize = 10f;
      settings.MaxStartSize = 10f;
      settings.MinEndSize = 100f;
      settings.MaxEndSize = 200f;
      settings.BlendState = BlendState.Additive;
    }
  }
}
