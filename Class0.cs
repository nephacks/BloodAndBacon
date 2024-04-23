// Decompiled with JetBrains decompiler
// Type: Blood.Class0
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
  internal class Class0 : ParticleSystem
  {
    public Class0(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "star";
      settings.MaxParticles = 2500;
      settings.Duration = TimeSpan.FromSeconds(3.0);
      settings.DurationRandomness = 0.0f;
      settings.EmitterVelocitySensitivity = 2f;
      settings.MinHorizontalVelocity = 1f;
      settings.MaxHorizontalVelocity = 11f;
      settings.MinVerticalVelocity = 1f;
      settings.MaxVerticalVelocity = 11f;
      settings.Gravity = new Vector3(0.0f, -25f, 0.0f);
      settings.EndVelocity = 1f;
      settings.MinColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      settings.MaxColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      settings.MinRotateSpeed = 0.3f;
      settings.MaxRotateSpeed = 0.8f;
      settings.MinStartSize = 14f;
      settings.MaxStartSize = 14f;
      settings.MinEndSize = 79f;
      settings.MaxEndSize = 85f;
      settings.BlendState = BlendState.Additive;
    }
  }
}
