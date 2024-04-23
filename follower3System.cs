// Decompiled with JetBrains decompiler
// Type: Blood.follower3System
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
  internal class follower3System : ParticleSystem
  {
    public follower3System(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "horseshoe";
      settings.MaxParticles = 6000;
      settings.Duration = TimeSpan.FromSeconds(2.5);
      settings.DurationRandomness = 0.2f;
      settings.EmitterVelocitySensitivity = 1f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 10f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 10f;
      settings.Gravity = new Vector3(0.0f, 0.0f, 0.0f);
      settings.EndVelocity = 10f;
      settings.MinColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      settings.MaxColor = new Color(85, 85, 85, 85);
      settings.MinRotateSpeed = 0.5f;
      settings.MaxRotateSpeed = 3f;
      settings.MinStartSize = 3f;
      settings.MaxStartSize = 13f;
      settings.MinEndSize = 25f;
      settings.MaxEndSize = 35f;
      settings.BlendState = BlendState.Additive;
    }
  }
}
