using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace Blood
{
  internal class debrisBloodSystem : ParticleSystem
  {
    public debrisBloodSystem(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "bloodgrey2";
      settings.MaxParticles = 150000;
      settings.Duration = TimeSpan.FromSeconds(43.0);
      settings.DurationRandomness = 0.0f;
      settings.EmitterVelocitySensitivity = 2f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 0.0f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 0.0f;
      settings.Gravity = new Vector3(0.0f, -10f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color(125, 125, 125, (int) byte.MaxValue);
      settings.MaxColor = new Color(125, 125, 125, (int) byte.MaxValue);
      settings.MinRotateSpeed = 0.0f;
      settings.MaxRotateSpeed = 0.0f;
      settings.MinStartSize = 12f;
      settings.MaxStartSize = 12f;
      settings.MinEndSize = 3f;
      settings.MaxEndSize = 3f;
      settings.BlendState = BlendState.NonPremultiplied;
    }
  }
}
