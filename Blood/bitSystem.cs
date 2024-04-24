using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace Blood
{
  internal class bitSystem : ParticleSystem
  {
    public bitSystem(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "bit1";
      settings.MaxParticles = 5000;
      settings.Duration = TimeSpan.FromSeconds(1.2);
      settings.DurationRandomness = 0.23f;
      settings.EmitterVelocitySensitivity = 2f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 0.0f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 0.0f;
      settings.Gravity = new Vector3(0.0f, -110f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, 200, 215);
      settings.MaxColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      settings.MinRotateSpeed = -8f;
      settings.MaxRotateSpeed = 10f;
      settings.MinStartSize = 1.2f;
      settings.MaxStartSize = 5.2f;
      settings.MinEndSize = 0.1f;
      settings.MaxEndSize = 0.3f;
      settings.BlendState = BlendState.NonPremultiplied;
    }
  }
}
