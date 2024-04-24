using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace Blood
{
  internal class vietnamSystem : ParticleSystem
  {
    public vietnamSystem(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "sparke2";
      settings.MaxParticles = 9500;
      settings.Duration = TimeSpan.FromSeconds(3.0);
      settings.DurationRandomness = 0.0f;
      settings.EmitterVelocitySensitivity = 2f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 2f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 2f;
      settings.Gravity = new Vector3(0.0f, -20f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color((int) byte.MaxValue, 108, 108, 200);
      settings.MaxColor = new Color((int) byte.MaxValue, 205, 205, (int) byte.MaxValue);
      settings.MinRotateSpeed = 0.0f;
      settings.MaxRotateSpeed = 0.0f;
      settings.MinStartSize = 30f;
      settings.MaxStartSize = 45f;
      settings.MinEndSize = 8f;
      settings.MaxEndSize = 8f;
      settings.BlendState = BlendState.Additive;
    }
  }
}
