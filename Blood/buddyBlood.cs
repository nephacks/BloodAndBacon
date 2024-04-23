// Decompiled with JetBrains decompiler
// Type: Blood.buddyBlood
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
  internal class buddyBlood : ParticleSystem
  {
    public buddyBlood(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "blood2";
      settings.MaxParticles = 7000;
      settings.Duration = TimeSpan.FromSeconds(3.0);
      settings.DurationRandomness = 1.2f;
      settings.EmitterVelocitySensitivity = 2f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 0.0f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 0.0f;
      settings.Gravity = new Vector3(0.0f, -150f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color(100, 100, 100, 150);
      settings.MaxColor = new Color(225, 225, 225, 200);
      settings.MinRotateSpeed = 5f;
      settings.MaxRotateSpeed = 17f;
      settings.MinStartSize = 0.6f;
      settings.MaxStartSize = 1.5f;
      settings.MinEndSize = 0.2f;
      settings.MaxEndSize = 0.5f;
      settings.BlendState = BlendState.NonPremultiplied;
    }
  }
}
