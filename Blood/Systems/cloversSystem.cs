using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace Blood
{
  internal class cloversSystem : ParticleSystem
  {
    public cloversSystem(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "clover";
      settings.MaxParticles = 6000;
      settings.Duration = TimeSpan.FromSeconds(8.0);
      settings.DurationRandomness = 1f;
      settings.EmitterVelocitySensitivity = 3f;
      settings.MinHorizontalVelocity = 5f;
      settings.MaxHorizontalVelocity = 5f;
      settings.MinVerticalVelocity = 5f;
      settings.MaxVerticalVelocity = 5f;
      settings.Gravity = new Vector3(0.0f, 0.0f, 0.0f);
      settings.EndVelocity = 5f;
      settings.MinColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      settings.MaxColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      settings.MinRotateSpeed = 0.0f;
      settings.MaxRotateSpeed = 1f;
      settings.MinStartSize = 28f;
      settings.MaxStartSize = 28f;
      settings.MinEndSize = 55f;
      settings.MaxEndSize = 55f;
      settings.BlendState = BlendState.Additive;
    }
  }
}
