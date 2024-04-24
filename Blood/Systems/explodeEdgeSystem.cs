using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace Blood
{
  internal class explodeEdgeSystem : ParticleSystem
  {
    public explodeEdgeSystem(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "star";
      settings.MaxParticles = 8000;
      settings.Duration = TimeSpan.FromSeconds(6.0);
      settings.DurationRandomness = 2f;
      settings.EmitterVelocitySensitivity = 1f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 0.0f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 0.0f;
      settings.Gravity = new Vector3(0.0f, -20f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color((int) byte.MaxValue, 68, 68, 68);
      settings.MaxColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      settings.MinRotateSpeed = -6f;
      settings.MaxRotateSpeed = 7f;
      settings.MinStartSize = 11f;
      settings.MaxStartSize = 14f;
      settings.MinEndSize = 24f;
      settings.MaxEndSize = 32f;
      settings.BlendState = BlendState.NonPremultiplied;
    }
  }
}
