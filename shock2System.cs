// Decompiled with JetBrains decompiler
// Type: Blood.shock2System
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
  internal class shock2System : ParticleSystem
  {
    public shock2System(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "spire2";
      settings.MaxParticles = 24000;
      settings.Duration = TimeSpan.FromSeconds(1.6000000238418579);
      settings.DurationRandomness = 0.1f;
      settings.EmitterVelocitySensitivity = 2f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 2f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 2f;
      settings.Gravity = new Vector3(0.0f, 0.0f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color(120, 110, 105, 120);
      settings.MaxColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 205);
      settings.MinRotateSpeed = 8f;
      settings.MaxRotateSpeed = 17f;
      settings.MinStartSize = 25f;
      settings.MaxStartSize = 40f;
      settings.MinEndSize = 2f;
      settings.MaxEndSize = 6f;
      settings.BlendState = BlendState.Additive;
    }
  }
}
