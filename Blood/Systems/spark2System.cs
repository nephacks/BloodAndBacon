using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace Blood
{
  internal class spark2System : ParticleSystem
  {
    public spark2System(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "sparke2";
      settings.MaxParticles = 6000;
      settings.Duration = TimeSpan.FromSeconds(1.5);
      settings.DurationRandomness = 0.2f;
      settings.EmitterVelocitySensitivity = 2f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 2f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 2f;
      settings.Gravity = new Vector3(0.0f, -100f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color(245, 155, 155, (int) byte.MaxValue);
      settings.MaxColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      settings.MinRotateSpeed = 5f;
      settings.MaxRotateSpeed = 15f;
      settings.MinStartSize = 0.5f;
      settings.MaxStartSize = 3f;
      settings.MinEndSize = 0.1f;
      settings.MaxEndSize = 0.1f;
      settings.BlendState = BlendState.Additive;
    }
  }
}
