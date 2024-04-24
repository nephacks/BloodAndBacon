using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

#nullable disable
namespace Blood
{
  internal class headBlood2System : ParticleSystem
  {
    public headBlood2System(Game game, ContentManager content)
      : base(game, content)
    {
    }

    protected override void InitializeSettings(ParticleSettings settings)
    {
      settings.TextureName = "heart";
      settings.MaxParticles = 0;
      settings.Duration = TimeSpan.FromSeconds(2.0);
      settings.DurationRandomness = 0.3f;
      settings.EmitterVelocitySensitivity = 2f;
      settings.MinHorizontalVelocity = 0.0f;
      settings.MaxHorizontalVelocity = 0.0f;
      settings.MinVerticalVelocity = 0.0f;
      settings.MaxVerticalVelocity = 0.0f;
      settings.Gravity = new Vector3(0.0f, -150f, 0.0f);
      settings.EndVelocity = 0.0f;
      settings.MinColor = new Color(80, 80, 80, 45);
      settings.MaxColor = new Color(245, 245, 245, 130);
      settings.MinRotateSpeed = 0.0f;
      settings.MaxRotateSpeed = 0.0f;
      settings.MinStartSize = 0.5f;
      settings.MaxStartSize = 5f;
      settings.MinEndSize = 0.3f;
      settings.MaxEndSize = 0.3f;
      settings.BlendState = BlendState.NonPremultiplied;
    }
  }
}
