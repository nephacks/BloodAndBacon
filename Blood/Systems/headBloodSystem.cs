using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace Blood
{
  internal class headBloodSystem : ParticleSystem
  {
    public headBloodSystem(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "bloodgrey";
      settings.MaxParticles = 80000;
      settings.Duration = TimeSpan.FromSeconds(1.4);
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
      settings.MinStartSize = 10f;
      settings.MaxStartSize = 12f;
      settings.MinEndSize = 1f;
      settings.MaxEndSize = 1f;
      settings.BlendState = BlendState.NonPremultiplied;
    }
  }
}
