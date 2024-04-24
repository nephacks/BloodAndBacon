using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace Blood
{
  internal class Class4 : ParticleSystem
  {
    public Class4(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "bluediamond";
      settings.MaxParticles = 2500;
      settings.Duration = TimeSpan.FromSeconds(3.0);
      settings.DurationRandomness = 0.0f;
      settings.EmitterVelocitySensitivity = 2f;
      settings.MinHorizontalVelocity = 1f;
      settings.MaxHorizontalVelocity = 11f;
      settings.MinVerticalVelocity = 1f;
      settings.MaxVerticalVelocity = 11f;
      settings.Gravity = new Vector3(0.0f, -25f, 0.0f);
      settings.EndVelocity = 1f;
      settings.MinColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      settings.MaxColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      settings.MinRotateSpeed = 0.3f;
      settings.MaxRotateSpeed = 0.8f;
      settings.MinStartSize = 14f;
      settings.MaxStartSize = 14f;
      settings.MinEndSize = 79f;
      settings.MaxEndSize = 85f;
      settings.BlendState = BlendState.Additive;
    }
  }
}
