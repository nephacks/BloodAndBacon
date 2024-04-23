// Decompiled with JetBrains decompiler
// Type: Blood.smokerSystem
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
  internal class smokerSystem : ParticleSystem
  {
    public smokerSystem(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "tracer2";
      settings.MaxParticles = 6200;
      settings.Duration = TimeSpan.FromSeconds(3.2000000476837158);
      settings.DurationRandomness = 2f;
      settings.EmitterVelocitySensitivity = 2f;
      settings.MinHorizontalVelocity = 3f;
      settings.MaxHorizontalVelocity = 15f;
      settings.MinVerticalVelocity = 3f;
      settings.MaxVerticalVelocity = 15f;
      settings.Gravity = new Vector3(0.0f, 0.0f, 0.0f);
      settings.EndVelocity = 3f;
      settings.MinColor = new Color(85, 85, 85, 85);
      settings.MaxColor = new Color(238, 238, 238, 238);
      settings.MinRotateSpeed = 0.0f;
      settings.MaxRotateSpeed = 0.0f;
      settings.MinStartSize = 2f;
      settings.MaxStartSize = 22f;
      settings.MinEndSize = 156f;
      settings.MaxEndSize = 250f;
      settings.BlendState = BlendState.NonPremultiplied;
    }
  }
}
