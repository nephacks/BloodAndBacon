// Decompiled with JetBrains decompiler
// Type: Blood.explode1System
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
  internal class explode1System : ParticleSystem
  {
    public explode1System(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "diamond";
      settings.MaxParticles = 3000;
      settings.Duration = TimeSpan.FromSeconds(2.0);
      settings.DurationRandomness = 0.0f;
      settings.EmitterVelocitySensitivity = 1f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 55f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 55f;
      settings.Gravity = new Vector3(0.0f, -150f, 0.0f);
      settings.EndVelocity = 25f;
      settings.MinColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      settings.MaxColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      settings.MinRotateSpeed = 0.0f;
      settings.MaxRotateSpeed = 0.0f;
      settings.MinStartSize = 88f;
      settings.MaxStartSize = 124f;
      settings.MinEndSize = 6f;
      settings.MaxEndSize = 12f;
      settings.BlendState = BlendState.Additive;
    }
  }
}
