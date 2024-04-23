// Decompiled with JetBrains decompiler
// Type: Blood.starburstSystem
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
  internal class starburstSystem : ParticleSystem
  {
    public starburstSystem(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "star";
      settings.MaxParticles = 6000;
      settings.Duration = TimeSpan.FromSeconds(8.0);
      settings.DurationRandomness = 1f;
      settings.EmitterVelocitySensitivity = 3f;
      settings.MinHorizontalVelocity = 5f;
      settings.MaxHorizontalVelocity = 5f;
      settings.MinVerticalVelocity = 5f;
      settings.MaxVerticalVelocity = 5f;
      settings.Gravity = new Vector3(0.0f, 0.0f, 0.0f);
      settings.EndVelocity = 5f;
      settings.MinColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      settings.MaxColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      settings.MinRotateSpeed = 0.3f;
      settings.MaxRotateSpeed = 0.8f;
      settings.MinStartSize = 25f;
      settings.MaxStartSize = 25f;
      settings.MinEndSize = 39f;
      settings.MaxEndSize = 45f;
      settings.BlendState = BlendState.Additive;
    }
  }
}
