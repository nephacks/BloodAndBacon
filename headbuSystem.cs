// Decompiled with JetBrains decompiler
// Type: Blood.headbuSystem
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
  internal class headbuSystem : ParticleSystem
  {
    public headbuSystem(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "bloodgrey_bu";
      settings.MaxParticles = 90000;
      settings.Duration = TimeSpan.FromSeconds(1.4);
      settings.DurationRandomness = 0.0f;
      settings.EmitterVelocitySensitivity = 2f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 0.0f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 0.0f;
      settings.Gravity = new Vector3(0.0f, -50f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color(60, 60, 60, 35);
      settings.MaxColor = new Color(205, 205, 205, 70);
      settings.MinRotateSpeed = 1.4f;
      settings.MaxRotateSpeed = 1.5f;
      settings.MinStartSize = 4f;
      settings.MaxStartSize = 11f;
      settings.MinEndSize = 2f;
      settings.MaxEndSize = 3f;
      settings.BlendState = BlendState.NonPremultiplied;
    }
  }
}
