// Decompiled with JetBrains decompiler
// Type: Blood.shock5System
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
  internal class shock5System : ParticleSystem
  {
    public shock5System(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "spire5";
      settings.MaxParticles = 25000;
      settings.Duration = TimeSpan.FromSeconds(1.0);
      settings.DurationRandomness = 0.1f;
      settings.EmitterVelocitySensitivity = 2f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 2f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 2f;
      settings.Gravity = new Vector3(0.0f, -20f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color(100, 100, 205, 60);
      settings.MaxColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 200);
      settings.MinRotateSpeed = 2f;
      settings.MaxRotateSpeed = 8f;
      settings.MinStartSize = 5f;
      settings.MaxStartSize = 59f;
      settings.MinEndSize = 2f;
      settings.MaxEndSize = 6f;
      settings.BlendState = BlendState.Additive;
    }
  }
}
