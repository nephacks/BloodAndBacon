using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace Blood
{
  internal class skidsSystem : ParticleSystem
  {
    public skidsSystem(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "skid";
      settings.MaxParticles = 9000;
      settings.Duration = TimeSpan.FromSeconds(3.0);
      settings.DurationRandomness = 0.0f;
      settings.EmitterVelocitySensitivity = 0.0f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 0.0f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 0.0f;
      settings.Gravity = new Vector3(0.0f, 1f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 190);
      settings.MaxColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 190);
      settings.MinRotateSpeed = 0.0f;
      settings.MaxRotateSpeed = 0.0f;
      settings.MinStartSize = 12f;
      settings.MaxStartSize = 12f;
      settings.MinEndSize = 6f;
      settings.MaxEndSize = 6f;
      settings.BlendState = BlendState.NonPremultiplied;
    }
  }
}
