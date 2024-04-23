// Decompiled with JetBrains decompiler
// Type: Blood.electricSystem
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
  internal class electricSystem : ParticleSystem
  {
    public electricSystem(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "electric";
      settings.MaxParticles = 5000;
      settings.Duration = TimeSpan.FromSeconds(3.0);
      settings.DurationRandomness = 0.2f;
      settings.EmitterVelocitySensitivity = 2f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 2f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 2f;
      settings.Gravity = new Vector3(0.0f, -250f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color(145, 108, 208, 200);
      settings.MaxColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      settings.MinRotateSpeed = 6f;
      settings.MaxRotateSpeed = 12f;
      settings.MinStartSize = 1f;
      settings.MaxStartSize = 7f;
      settings.MinEndSize = 1f;
      settings.MaxEndSize = 1f;
      settings.BlendState = BlendState.Additive;
    }
  }
}
