using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace Blood
{
  internal class dotSystem : ParticleSystem
  {
    public dotSystem(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "dot";
      settings.MaxParticles = 4000;
      settings.Duration = TimeSpan.FromSeconds(4.1999998092651367);
      settings.DurationRandomness = 0.1f;
      settings.EmitterVelocitySensitivity = 2f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 2f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 2f;
      settings.Gravity = new Vector3(0.0f, 0.0f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color(100, 100, 245, 120);
      settings.MaxColor = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 250);
      settings.MinRotateSpeed = 2f;
      settings.MaxRotateSpeed = 4f;
      settings.MinStartSize = 25f;
      settings.MaxStartSize = 40f;
      settings.MinEndSize = 3f;
      settings.MaxEndSize = 12f;
      settings.BlendState = BlendState.Additive;
    }
  }
}
