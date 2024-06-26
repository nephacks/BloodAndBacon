﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace Blood
{
  internal class follower2System : ParticleSystem
  {
    public follower2System(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "diamond";
      settings.MaxParticles = 6000;
      settings.Duration = TimeSpan.FromSeconds(2.5);
      settings.DurationRandomness = 0.3f;
      settings.EmitterVelocitySensitivity = 1f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 11f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 11f;
      settings.Gravity = new Vector3(0.0f, 0.0f, 0.0f);
      settings.EndVelocity = 11f;
      settings.MinColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      settings.MaxColor = new Color(85, 85, 85, 85);
      settings.MinRotateSpeed = 0.0f;
      settings.MaxRotateSpeed = 0.3f;
      settings.MinStartSize = 3f;
      settings.MaxStartSize = 13f;
      settings.MinEndSize = 25f;
      settings.MaxEndSize = 35f;
      settings.BlendState = BlendState.Additive;
    }
  }
}
