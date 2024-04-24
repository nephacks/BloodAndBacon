using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using System;

#nullable disable
namespace Blood
{
  public abstract class ParticleSystem : GameScreen
  {
    public ParticleSettings settings = new ParticleSettings();
    public static BlendState lastBlend = new BlendState();
    private ContentManager content;
    private Effect particleEffect;
    private EffectParameter effectViewParameter;
    private EffectParameter effectProjectionParameter;
    private EffectParameter effectTimeParameter;
    private EffectParameter effectTexture;
    private ParticleSystem.ParticleVertex[] particles;
    private DynamicVertexBuffer vertexBuffer;
    private IndexBuffer indexBuffer;
    private int firstActiveParticle;
    private int firstNewParticle;
    private int firstFreeParticle;
    private int firstRetiredParticle;
    private float currentTime;
    private int drawCounter;
    private static Random random = new Random();
    public GraphicsDevice gr;

    public ParticleSystem(Game game, ContentManager content) => this.content = content;

    public void Initialize() => this.InitializeSettings(this.settings);

    protected abstract void InitializeSettings(ParticleSettings settings);

    public void unloadContent()
    {
      this.content.Unload();
      this.vertexBuffer.Dispose();
      this.indexBuffer.Dispose();
      this.particles = new ParticleSystem.ParticleVertex[0];
    }

    public void LoadContent(GraphicsDevice gr)
    {
      this.gr = gr;
      this.particles = new ParticleSystem.ParticleVertex[this.settings.MaxParticles * 4];
      for (int index = 0; index < this.settings.MaxParticles; ++index)
      {
        this.particles[index * 4].Corner = new Short2(-1f, -1f);
        this.particles[index * 4 + 1].Corner = new Short2(1f, -1f);
        this.particles[index * 4 + 2].Corner = new Short2(1f, 1f);
        this.particles[index * 4 + 3].Corner = new Short2(-1f, 1f);
      }
      this.LoadParticleEffect();
      this.vertexBuffer = new DynamicVertexBuffer(gr, ParticleSystem.ParticleVertex.VertexDeclaration, this.settings.MaxParticles * 4, BufferUsage.WriteOnly);
      uint[] data = new uint[this.settings.MaxParticles * 6];
      for (int index = 0; index < this.settings.MaxParticles; ++index)
      {
        data[index * 6] = (uint) (index * 4);
        data[index * 6 + 1] = (uint) (index * 4 + 1);
        data[index * 6 + 2] = (uint) (index * 4 + 2);
        data[index * 6 + 3] = (uint) (index * 4);
        data[index * 6 + 4] = (uint) (index * 4 + 2);
        data[index * 6 + 5] = (uint) (index * 4 + 3);
      }
      this.indexBuffer = new IndexBuffer(gr, typeof (uint), data.Length, BufferUsage.WriteOnly);
      this.indexBuffer.SetData<uint>(data);
    }

    private void LoadParticleEffect()
    {
      Effect effect = this.content.Load<Effect>("effects\\ParticleEffect");
      Texture2D texture2D = this.content.Load<Texture2D>("particles\\" + this.settings.TextureName);
      this.particleEffect = effect.Clone();
      EffectParameterCollection parameters = this.particleEffect.Parameters;
      this.effectViewParameter = parameters["View"];
      this.effectProjectionParameter = parameters["Projection"];
      this.effectTimeParameter = parameters["CurrentTime"];
      this.effectTexture = parameters["Texture"];
      parameters["Duration"].SetValue((float) this.settings.Duration.TotalSeconds);
      parameters["DurationRandomness"].SetValue(this.settings.DurationRandomness);
      parameters["Gravity"].SetValue(this.settings.Gravity);
      parameters["EndVelocity"].SetValue(this.settings.EndVelocity);
      parameters["MinColor"].SetValue(this.settings.MinColor.ToVector4());
      parameters["MaxColor"].SetValue(this.settings.MaxColor.ToVector4());
      parameters["RotateSpeed"].SetValue(new Vector2(this.settings.MinRotateSpeed, this.settings.MaxRotateSpeed));
      parameters["StartSize"].SetValue(new Vector2(this.settings.MinStartSize, this.settings.MaxStartSize));
      parameters["EndSize"].SetValue(new Vector2(this.settings.MinEndSize, this.settings.MaxEndSize));
      parameters["Texture"].SetValue((Texture) texture2D);
    }

    public void Update(GameTime gameTime)
    {
      if (this.particles.Length <= 0)
        return;
      this.currentTime += (float) gameTime.ElapsedGameTime.TotalSeconds;
      this.RetireActiveParticles();
      this.FreeRetiredParticles();
      if (this.firstActiveParticle == this.firstFreeParticle)
        this.currentTime = 0.0f;
      if (this.firstRetiredParticle != this.firstActiveParticle)
        return;
      this.drawCounter = 0;
    }

    public void resetParticleTime()
    {
      this.firstActiveParticle = 0;
      this.firstNewParticle = 0;
      this.firstFreeParticle = 0;
      this.firstRetiredParticle = 0;
    }

    private void RetireActiveParticles()
    {
      float totalSeconds = (float) this.settings.Duration.TotalSeconds;
      while (this.firstActiveParticle != this.firstNewParticle && (double) (this.currentTime - this.particles[this.firstActiveParticle * 4].Time) >= (double) totalSeconds)
      {
        this.particles[this.firstActiveParticle * 4].Time = (float) this.drawCounter;
        ++this.firstActiveParticle;
        if (this.firstActiveParticle >= this.settings.MaxParticles)
          this.firstActiveParticle = 0;
      }
    }

    private void FreeRetiredParticles()
    {
      while (this.firstRetiredParticle != this.firstActiveParticle && this.drawCounter - (int) this.particles[this.firstRetiredParticle * 4].Time >= 4)
      {
        ++this.firstRetiredParticle;
        if (this.firstRetiredParticle >= this.settings.MaxParticles)
          this.firstRetiredParticle = 0;
      }
    }

    public void Draw(int tech)
    {
      if (this.firstNewParticle != this.firstFreeParticle)
        this.AddNewParticlesToVertexBuffer();
      if (this.firstActiveParticle != this.firstFreeParticle)
      {
        this.gr.BlendState = this.settings.BlendState;
        this.effectTimeParameter.SetValue(this.currentTime);
        this.gr.SetVertexBuffer((VertexBuffer) this.vertexBuffer);
        this.gr.Indices = this.indexBuffer;
        this.particleEffect.CurrentTechnique.Passes[tech].Apply();
        if (this.firstActiveParticle < this.firstFreeParticle)
        {
          this.gr.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, this.firstActiveParticle * 4, (this.firstFreeParticle - this.firstActiveParticle) * 4, this.firstActiveParticle * 6, (this.firstFreeParticle - this.firstActiveParticle) * 2);
        }
        else
        {
          this.gr.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, this.firstActiveParticle * 4, (this.settings.MaxParticles - this.firstActiveParticle) * 4, this.firstActiveParticle * 6, (this.settings.MaxParticles - this.firstActiveParticle) * 2);
          if (this.firstFreeParticle > 0)
            this.gr.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, this.firstFreeParticle * 4, 0, this.firstFreeParticle * 2);
        }
      }
      ++this.drawCounter;
    }

    private void AddNewParticlesToVertexBuffer()
    {
      int vertexStride = 36;
      if (this.firstNewParticle < this.firstFreeParticle)
      {
        this.vertexBuffer.SetData<ParticleSystem.ParticleVertex>(this.firstNewParticle * vertexStride * 4, this.particles, this.firstNewParticle * 4, (this.firstFreeParticle - this.firstNewParticle) * 4, vertexStride, SetDataOptions.NoOverwrite);
      }
      else
      {
        this.vertexBuffer.SetData<ParticleSystem.ParticleVertex>(this.firstNewParticle * vertexStride * 4, this.particles, this.firstNewParticle * 4, (this.settings.MaxParticles - this.firstNewParticle) * 4, vertexStride, SetDataOptions.NoOverwrite);
        if (this.firstFreeParticle > 0)
          this.vertexBuffer.SetData<ParticleSystem.ParticleVertex>(0, this.particles, 0, this.firstFreeParticle * 4, vertexStride, SetDataOptions.NoOverwrite);
      }
      this.firstNewParticle = this.firstFreeParticle;
    }

    public void setPaintball(Texture2D tt, Vector4 min, Vector4 max)
    {
      EffectParameterCollection parameters = this.particleEffect.Parameters;
      parameters["Texture"].SetValue((Texture) tt);
      parameters["MinColor"].SetValue(min);
      parameters["MaxColor"].SetValue(max);
    }

    public void setDuration(float secs)
    {
      this.settings.Duration = TimeSpan.FromSeconds((double) secs);
      this.particleEffect.Parameters["Duration"].SetValue((float) this.settings.Duration.TotalSeconds);
    }

    public void SetCamera(Matrix view, Matrix projection)
    {
      this.effectViewParameter.SetValue(view);
      this.effectProjectionParameter.SetValue(projection);
    }

    public void AddParticle(Vector3 position, Vector3 velocity)
    {
      int num = this.firstFreeParticle + 1;
      if (num >= this.settings.MaxParticles)
        num = 0;
      if (num == this.firstRetiredParticle)
        return;
      velocity *= this.settings.EmitterVelocitySensitivity;
      Color color = new Color((int) (byte) ParticleSystem.random.Next((int) byte.MaxValue), (int) (byte) ParticleSystem.random.Next((int) byte.MaxValue), (int) (byte) ParticleSystem.random.Next((int) byte.MaxValue), (int) (byte) ParticleSystem.random.Next((int) byte.MaxValue));
      for (int index = 0; index < 4; ++index)
      {
        this.particles[this.firstFreeParticle * 4 + index].Position = position;
        this.particles[this.firstFreeParticle * 4 + index].Velocity = velocity;
        this.particles[this.firstFreeParticle * 4 + index].Random = color;
        this.particles[this.firstFreeParticle * 4 + index].Time = this.currentTime;
      }
      this.firstFreeParticle = num;
    }

    public void AddParticle2(Vector3 position, Vector3 velocity, int mysize, int mycolor)
    {
      int num = this.firstFreeParticle + 1;
      if (num >= this.settings.MaxParticles)
        num = 0;
      if (num == this.firstRetiredParticle)
        return;
      velocity *= this.settings.EmitterVelocitySensitivity;
      Color color = new Color((int) (byte) ParticleSystem.random.Next((int) byte.MaxValue), (int) (byte) ParticleSystem.random.Next((int) byte.MaxValue), (int) (byte) (mysize + 1), (int) (byte) (mycolor + 1));
      for (int index = 0; index < 4; ++index)
      {
        this.particles[this.firstFreeParticle * 4 + index].Position = position;
        this.particles[this.firstFreeParticle * 4 + index].Velocity = velocity;
        this.particles[this.firstFreeParticle * 4 + index].Random = color;
        this.particles[this.firstFreeParticle * 4 + index].Time = this.currentTime;
      }
      this.firstFreeParticle = num;
    }

    public void AddParticle3(Vector3 position, Vector3 velocity, int mycolor)
    {
      int num = this.firstFreeParticle + 1;
      if (num >= this.settings.MaxParticles)
        num = 0;
      if (num == this.firstRetiredParticle)
        return;
      velocity *= this.settings.EmitterVelocitySensitivity;
      Color color = new Color((int) (byte) ParticleSystem.random.Next((int) byte.MaxValue), (int) (byte) ParticleSystem.random.Next((int) byte.MaxValue), (int) (byte) ParticleSystem.random.Next((int) byte.MaxValue), (int) (byte) (mycolor + 1));
      for (int index = 0; index < 4; ++index)
      {
        this.particles[this.firstFreeParticle * 4 + index].Position = position;
        this.particles[this.firstFreeParticle * 4 + index].Velocity = velocity;
        this.particles[this.firstFreeParticle * 4 + index].Random = color;
        this.particles[this.firstFreeParticle * 4 + index].Time = this.currentTime;
      }
      this.firstFreeParticle = num;
    }

    public void AddParticle5(
      Vector3 position,
      Vector3 velocity,
      int mysize,
      int mycolorx,
      int mycolory,
      int mycolorz)
    {
      int num = this.firstFreeParticle + 1;
      if (num >= this.settings.MaxParticles)
        num = 0;
      if (num == this.firstRetiredParticle)
        return;
      velocity *= this.settings.EmitterVelocitySensitivity;
      Color color = new Color((int) (byte) mysize, (int) (byte) mycolorx, (int) (byte) mycolory, (int) (byte) mycolorz);
      for (int index = 0; index < 4; ++index)
      {
        this.particles[this.firstFreeParticle * 4 + index].Position = position;
        this.particles[this.firstFreeParticle * 4 + index].Velocity = velocity;
        this.particles[this.firstFreeParticle * 4 + index].Random = color;
        this.particles[this.firstFreeParticle * 4 + index].Time = this.currentTime;
      }
      this.firstFreeParticle = num;
    }

    private struct ParticleVertex
    {
      public const int SizeInBytes = 36;
      public Short2 Corner;
      public Vector3 Position;
      public Vector3 Velocity;
      public Color Random;
      public float Time;
      public static readonly VertexDeclaration VertexDeclaration = new VertexDeclaration(new VertexElement[5]
      {
        new VertexElement(0, VertexElementFormat.Short2, VertexElementUsage.Position, 0),
        new VertexElement(4, VertexElementFormat.Vector3, VertexElementUsage.Position, 1),
        new VertexElement(16, VertexElementFormat.Vector3, VertexElementUsage.Normal, 0),
        new VertexElement(28, VertexElementFormat.Color, VertexElementUsage.Color, 0),
        new VertexElement(32, VertexElementFormat.Single, VertexElementUsage.TextureCoordinate, 0)
      });
    }
  }
}
