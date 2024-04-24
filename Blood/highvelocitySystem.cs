using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace Blood
{
  internal class highvelocitySystem : ParticleSystem
  {
    public highvelocitySystem(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "tracer2";
      settings.MaxParticles = 5000;
      settings.Duration = TimeSpan.FromSeconds(1.6000000238418579);
      settings.DurationRandomness = 1f;
      settings.EmitterVelocitySensitivity = 1f;
      settings.MinHorizontalVelocity = 1f;
      settings.MaxHorizontalVelocity = 26f;
      settings.MinVerticalVelocity = 1f;
      settings.MaxVerticalVelocity = 26f;
      settings.Gravity = new Vector3(0.0f, 0.0f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color(85, 85, 85, 85);
      settings.MaxColor = new Color(238, 238, 238, 238);
      settings.MinRotateSpeed = 0.0f;
      settings.MaxRotateSpeed = 0.0f;
      settings.MinStartSize = 4f;
      settings.MaxStartSize = 15f;
      settings.MinEndSize = 22f;
      settings.MaxEndSize = 25f;
      settings.BlendState = BlendState.NonPremultiplied;
    }
  }
}
