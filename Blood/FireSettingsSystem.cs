using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace Blood
{
  internal class FireSettingsSystem : ParticleSystem
  {
    public FireSettingsSystem(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "fire";
      settings.MaxParticles = 2400;
      settings.Duration = TimeSpan.FromSeconds(2.0);
      settings.DurationRandomness = 1f;
      settings.EmitterVelocitySensitivity = 1f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 15f;
      settings.MinVerticalVelocity = -10f;
      settings.MaxVerticalVelocity = 10f;
      settings.Gravity = new Vector3(0.0f, 15f, 0.0f);
      settings.EndVelocity = 1f;
      settings.MinColor = new Color(10, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      settings.MaxColor = new Color(40, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      settings.MinRotateSpeed = 0.0f;
      settings.MaxRotateSpeed = 0.0f;
      settings.MinStartSize = 5f;
      settings.MaxStartSize = 10f;
      settings.MinEndSize = 10f;
      settings.MaxEndSize = 40f;
      settings.BlendState = BlendState.Additive;
    }
  }
}
