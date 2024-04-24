using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace Blood
{
  internal class dot2System : ParticleSystem
  {
    public dot2System(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "dot2";
      settings.MaxParticles = 4000;
      settings.Duration = TimeSpan.FromSeconds(3.2000000476837158);
      settings.DurationRandomness = 0.1f;
      settings.EmitterVelocitySensitivity = 2f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 2f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 2f;
      settings.Gravity = new Vector3(0.0f, -5f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color(80, 90, 170, 160);
      settings.MaxColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 250);
      settings.MinRotateSpeed = 6f;
      settings.MaxRotateSpeed = 22f;
      settings.MinStartSize = 10f;
      settings.MaxStartSize = 40f;
      settings.MinEndSize = 2f;
      settings.MaxEndSize = 6f;
      settings.BlendState = BlendState.Additive;
    }
  }
}
