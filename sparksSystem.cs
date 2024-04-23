// Decompiled with JetBrains decompiler
// Type: Blood.sparksSystem
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
  internal class sparksSystem : ParticleSystem
  {
    public sparksSystem(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "spark";
      settings.MaxParticles = 75000;
      settings.Duration = TimeSpan.FromSeconds(3.0);
      settings.DurationRandomness = 1f;
      settings.EmitterVelocitySensitivity = 1f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 0.0f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 0.0f;
      settings.Gravity = new Vector3(0.0f, -50f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color(119, 119, 119, 119);
      settings.MaxColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      settings.MinRotateSpeed = -8f;
      settings.MaxRotateSpeed = 8f;
      settings.MinStartSize = 9f;
      settings.MaxStartSize = 11f;
      settings.MinEndSize = 0.0f;
      settings.MaxEndSize = 1f;
      settings.BlendState = BlendState.Additive;
    }
  }
}
