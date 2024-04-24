using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace Blood
{
  internal class dropSystem : ParticleSystem
  {
    public dropSystem(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "blood2";
      settings.MaxParticles = 15000;
      settings.Duration = TimeSpan.FromSeconds(3.0);
      settings.DurationRandomness = 1.2f;
      settings.EmitterVelocitySensitivity = 2f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 0.0f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 0.0f;
      settings.Gravity = new Vector3(0.0f, -130f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color(100, 100, 100, (int) byte.MaxValue);
      settings.MaxColor = new Color(200, 200, 200, (int) byte.MaxValue);
      settings.MinRotateSpeed = 0.0f;
      settings.MaxRotateSpeed = 0.0f;
      settings.MinStartSize = 2.4f;
      settings.MaxStartSize = 7.5f;
      settings.MinEndSize = 0.1f;
      settings.MaxEndSize = 0.5f;
      settings.BlendState = BlendState.AlphaBlend;
    }
  }
}
