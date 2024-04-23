// Decompiled with JetBrains decompiler
// Type: Blood.rockSystem
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
  internal class rockSystem : ParticleSystem
  {
    public rockSystem(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "rock1";
      settings.MaxParticles = 35000;
      settings.Duration = TimeSpan.FromSeconds(5.0);
      settings.DurationRandomness = 0.5f;
      settings.EmitterVelocitySensitivity = 2f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 2f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 2f;
      settings.Gravity = new Vector3(0.0f, -650f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color(95, 135, 95, (int) byte.MaxValue);
      settings.MaxColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      settings.MinRotateSpeed = -12f;
      settings.MaxRotateSpeed = 12f;
      settings.MinStartSize = 5f;
      settings.MaxStartSize = 28f;
      settings.MinEndSize = 1f;
      settings.MaxEndSize = 6f;
      settings.BlendState = BlendState.AlphaBlend;
    }
  }
}
