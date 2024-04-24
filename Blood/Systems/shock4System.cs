using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace Blood
{
  internal class shock4System : ParticleSystem
  {
    public shock4System(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "spire4";
      settings.MaxParticles = 24000;
      settings.Duration = TimeSpan.FromSeconds(1.3999999761581421);
      settings.DurationRandomness = 0.1f;
      settings.EmitterVelocitySensitivity = 2f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 2f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 2f;
      settings.Gravity = new Vector3(0.0f, 0.0f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color(250, 170, 205, 120);
      settings.MaxColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 200);
      settings.MinRotateSpeed = 2f;
      settings.MaxRotateSpeed = 8f;
      settings.MinStartSize = 25f;
      settings.MaxStartSize = 40f;
      settings.MinEndSize = 2f;
      settings.MaxEndSize = 6f;
      settings.BlendState = BlendState.Additive;
    }
  }
}
