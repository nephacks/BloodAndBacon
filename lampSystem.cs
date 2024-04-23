// Decompiled with JetBrains decompiler
// Type: Blood.lampSystem
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
  internal class lampSystem : ParticleSystem
  {
    public lampSystem(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "lamp";
      settings.MaxParticles = 30;
      settings.Duration = TimeSpan.FromSeconds(0.017000000923871994);
      settings.DurationRandomness = 0.0f;
      settings.EmitterVelocitySensitivity = 2f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 2f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 2f;
      settings.Gravity = new Vector3(0.0f, 0.0f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color(190, 190, 190, (int) byte.MaxValue);
      settings.MaxColor = new Color(220, 220, 220, (int) byte.MaxValue);
      settings.MinRotateSpeed = 0.4f;
      settings.MaxRotateSpeed = 0.5f;
      settings.MinStartSize = 100f;
      settings.MaxStartSize = 100f;
      settings.MinEndSize = 100f;
      settings.MaxEndSize = 100f;
      settings.BlendState = BlendState.Additive;
    }
  }
}
