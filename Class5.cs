// Decompiled with JetBrains decompiler
// Type: Blood.Class5
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
  internal class Class5 : ParticleSystem
  {
    public Class5(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "bloodblue2";
      settings.MaxParticles = 150000;
      settings.Duration = TimeSpan.FromSeconds(20.0);
      settings.DurationRandomness = 3f;
      settings.EmitterVelocitySensitivity = 2f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 0.0f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 0.0f;
      settings.Gravity = new Vector3(0.0f, 0.0f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color(125, 125, 125, (int) byte.MaxValue);
      settings.MaxColor = new Color(150, 150, 150, (int) byte.MaxValue);
      settings.MinRotateSpeed = 0.0f;
      settings.MaxRotateSpeed = 0.0f;
      settings.MinStartSize = 12f;
      settings.MaxStartSize = 12f;
      settings.MinEndSize = 0.5f;
      settings.MaxEndSize = 0.5f;
      settings.BlendState = BlendState.NonPremultiplied;
    }
  }
}
