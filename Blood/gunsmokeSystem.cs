// Decompiled with JetBrains decompiler
// Type: Blood.gunsmokeSystem
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
  internal class gunsmokeSystem : ParticleSystem
  {
    public gunsmokeSystem(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "mistmini";
      settings.MaxParticles = 25;
      settings.Duration = TimeSpan.FromSeconds(1.1);
      settings.DurationRandomness = 0.2f;
      settings.EmitterVelocitySensitivity = 2f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 2f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 2f;
      settings.Gravity = new Vector3(0.0f, 20f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color(155, 155, (int) byte.MaxValue, 170);
      settings.MaxColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 190);
      settings.MinRotateSpeed = -1.35f;
      settings.MaxRotateSpeed = 2.35f;
      settings.MinStartSize = 1f;
      settings.MaxStartSize = 10f;
      settings.MinEndSize = 35f;
      settings.MaxEndSize = 45f;
      settings.BlendState = BlendState.NonPremultiplied;
    }
  }
}
