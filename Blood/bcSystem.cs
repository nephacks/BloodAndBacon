using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace Blood
{
  internal class bcSystem : ParticleSystem
  {
    public bcSystem(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "spark2";
      settings.MaxParticles = 13500;
      settings.Duration = TimeSpan.FromSeconds(3.0);
      settings.DurationRandomness = 0.0f;
      settings.EmitterVelocitySensitivity = 3f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 0.0f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 0.0f;
      settings.Gravity = new Vector3(0.0f, 0.0f, 0.0f);
      settings.EndVelocity = 0.1f;
      settings.MinColor = new Color(153, 153, 153, 53);
      settings.MaxColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 205);
      settings.MinRotateSpeed = 12f;
      settings.MaxRotateSpeed = 25f;
      settings.MinStartSize = 0.8f;
      settings.MaxStartSize = 2.5f;
      settings.MinEndSize = 0.1f;
      settings.MaxEndSize = 0.2f;
      settings.BlendState = BlendState.Additive;
    }
  }
}
