// Decompiled with JetBrains decompiler
// Type: Blood.sparkSystem
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
  internal class sparkSystem : ParticleSystem
  {
    public sparkSystem(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "sparke";
      settings.MaxParticles = 12000;
      settings.Duration = TimeSpan.FromSeconds(3.0);
      settings.DurationRandomness = 0.2f;
      settings.EmitterVelocitySensitivity = 2f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 2f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 2f;
      settings.Gravity = new Vector3(0.0f, -256f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color(245, 108, 108, 200);
      settings.MaxColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      settings.MinRotateSpeed = 5f;
      settings.MaxRotateSpeed = 15f;
      settings.MinStartSize = 2.5f;
      settings.MaxStartSize = 6.2f;
      settings.MinEndSize = 2f;
      settings.MaxEndSize = 3f;
      settings.BlendState = BlendState.Additive;
    }
  }
}
