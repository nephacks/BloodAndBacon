// Decompiled with JetBrains decompiler
// Type: Blood.rocketSystem
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
  internal class rocketSystem : ParticleSystem
  {
    public rocketSystem(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "mistmini2";
      settings.MaxParticles = 2000;
      settings.Duration = TimeSpan.FromSeconds(3.5);
      settings.DurationRandomness = 0.0f;
      settings.EmitterVelocitySensitivity = 2f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 2f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 2f;
      settings.Gravity = new Vector3(4f, 2f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color(190, 190, 190, 150);
      settings.MaxColor = new Color(210, 210, 210, 195);
      settings.MinRotateSpeed = -1f;
      settings.MaxRotateSpeed = 1f;
      settings.MinStartSize = 25f;
      settings.MaxStartSize = 34f;
      settings.MinEndSize = 36f;
      settings.MaxEndSize = 45f;
      settings.BlendState = BlendState.NonPremultiplied;
    }
  }
}
