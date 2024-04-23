﻿// Decompiled with JetBrains decompiler
// Type: Blood.cloud1System
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
  internal class cloud1System : ParticleSystem
  {
    public cloud1System(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "tracer";
      settings.MaxParticles = 39000;
      settings.Duration = TimeSpan.FromSeconds(25.0);
      settings.DurationRandomness = 0.0f;
      settings.EmitterVelocitySensitivity = 3f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 0.0f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 0.0f;
      settings.Gravity = new Vector3(0.0f, 0.0f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color(119, 119, 119, 119);
      settings.MaxColor = new Color(119, 119, 119, 119);
      settings.MinRotateSpeed = 0.0f;
      settings.MaxRotateSpeed = 0.0f;
      settings.MinStartSize = 15f;
      settings.MaxStartSize = 15f;
      settings.MinEndSize = 30f;
      settings.MaxEndSize = 30f;
      settings.BlendState = BlendState.NonPremultiplied;
    }
  }
}