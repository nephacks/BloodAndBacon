// Decompiled with JetBrains decompiler
// Type: Blood.spitSystem
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
  internal class spitSystem : ParticleSystem
  {
    public spitSystem(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "tracer2";
      settings.MaxParticles = 5000;
      settings.Duration = TimeSpan.FromSeconds(1.0);
      settings.DurationRandomness = 0.1f;
      settings.EmitterVelocitySensitivity = 1f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 0.0f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 0.0f;
      settings.Gravity = new Vector3(0.0f, -90f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color((int) byte.MaxValue, 34, 19, 200);
      settings.MaxColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, 230, (int) byte.MaxValue);
      settings.MinRotateSpeed = 35f;
      settings.MaxRotateSpeed = 125f;
      settings.MinStartSize = 6f;
      settings.MaxStartSize = 4f;
      settings.MinEndSize = 3f;
      settings.MaxEndSize = 3f;
      settings.BlendState = BlendState.NonPremultiplied;
    }
  }
}
