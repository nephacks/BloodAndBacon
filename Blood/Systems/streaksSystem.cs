using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace Blood
{
  internal class streaksSystem : ParticleSystem
  {
    public streaksSystem(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "trail";
      settings.MaxParticles = 16000;
      settings.Duration = TimeSpan.FromSeconds(0.800000011920929);
      settings.DurationRandomness = 0.0f;
      settings.EmitterVelocitySensitivity = 1f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 0.0f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 0.0f;
      settings.Gravity = new Vector3(0.0f, 0.0f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color(80, 80, 80, 80);
      settings.MaxColor = new Color(80, 80, 80, 80);
      settings.MinRotateSpeed = 0.0f;
      settings.MaxRotateSpeed = 0.0f;
      settings.MinStartSize = 5f;
      settings.MaxStartSize = 5f;
      settings.MinEndSize = 0.1f;
      settings.MaxEndSize = 0.1f;
      settings.BlendState = BlendState.Additive;
    }
  }
}
