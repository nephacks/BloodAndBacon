using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace Blood
{
  internal class cloud2System : ParticleSystem
  {
    public cloud2System(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "tracer";
      settings.MaxParticles = 39000;
      settings.Duration = TimeSpan.FromSeconds(40.0);
      settings.DurationRandomness = 4f;
      settings.EmitterVelocitySensitivity = 3f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 0.0f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 0.0f;
      settings.Gravity = new Vector3(0.0f, 0.0f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color(170, 170, 170, 170);
      settings.MaxColor = new Color(170, 170, 170, 170);
      settings.MinRotateSpeed = 0.0f;
      settings.MaxRotateSpeed = 0.0f;
      settings.MinStartSize = 8f;
      settings.MaxStartSize = 8f;
      settings.MinEndSize = 40f;
      settings.MaxEndSize = 40f;
      settings.BlendState = BlendState.NonPremultiplied;
    }
  }
}
