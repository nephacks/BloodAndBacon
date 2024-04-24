using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace Blood
{
  internal class explode3System : ParticleSystem
  {
    public explode3System(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "raindrop";
      settings.MaxParticles = 3000;
      settings.Duration = TimeSpan.FromSeconds(4.0);
      settings.DurationRandomness = 0.0f;
      settings.EmitterVelocitySensitivity = 1f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 655f;
      settings.MinVerticalVelocity = -155f;
      settings.MaxVerticalVelocity = 655f;
      settings.Gravity = new Vector3(0.0f, -160f, 0.0f);
      settings.EndVelocity = 35f;
      settings.MinColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      settings.MaxColor = new Color(170, 170, (int) byte.MaxValue, (int) byte.MaxValue);
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
