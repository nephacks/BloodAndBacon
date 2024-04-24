using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace Blood
{
  internal class farmerSpit : ParticleSystem
  {
    public farmerSpit(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "spit";
      settings.MaxParticles = 1000;
      settings.Duration = TimeSpan.FromSeconds(2.0);
      settings.DurationRandomness = 1.2f;
      settings.EmitterVelocitySensitivity = 2f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 0.0f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 0.0f;
      settings.Gravity = new Vector3(0.0f, -40f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color(120, 100, 100, 200);
      settings.MaxColor = new Color(245, 245, 225, 200);
      settings.MinRotateSpeed = 5f;
      settings.MaxRotateSpeed = 17f;
      settings.MinStartSize = 0.1f;
      settings.MaxStartSize = 0.7f;
      settings.MinEndSize = 0.1f;
      settings.MaxEndSize = 0.1f;
      settings.BlendState = BlendState.NonPremultiplied;
    }
  }
}
