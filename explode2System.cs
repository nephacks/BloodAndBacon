// Decompiled with JetBrains decompiler
// Type: Blood.explode2System
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
  internal class explode2System : ParticleSystem
  {
    public explode2System(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "star";
      settings.MaxParticles = 3000;
      settings.Duration = TimeSpan.FromSeconds(2.0);
      settings.DurationRandomness = 0.0f;
      settings.EmitterVelocitySensitivity = 1f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 125f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 155f;
      settings.Gravity = new Vector3(0.0f, 0.0f, 0.0f);
      settings.EndVelocity = 15f;
      settings.MinColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      settings.MaxColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      settings.MinRotateSpeed = 0.0f;
      settings.MaxRotateSpeed = 3f;
      settings.MinStartSize = 5f;
      settings.MaxStartSize = 14f;
      settings.MinEndSize = 60f;
      settings.MaxEndSize = 120f;
      settings.BlendState = BlendState.Additive;
    }
  }
}
