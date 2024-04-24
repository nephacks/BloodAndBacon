using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

#nullable disable
namespace Blood
{
  public class InstancedModel
  {
    private List<InstancedModelPart> modelParts = new List<InstancedModelPart>();
    private GraphicsDevice graphicsDevice;
    public List<int> show = new List<int>();

    internal InstancedModel(ContentReader input)
    {
      this.graphicsDevice = InstancedModel.GetGraphicsDevice(input);
      int num = input.ReadInt32();
      for (int index = 0; index < num; ++index)
        this.modelParts.Add(new InstancedModelPart(input, this.graphicsDevice));
    }

    private static GraphicsDevice GetGraphicsDevice(ContentReader input)
    {
      return ((IGraphicsDeviceService) input.ContentManager.ServiceProvider.GetService(typeof (IGraphicsDeviceService))).GraphicsDevice;
    }

    public void DrawGems(
      ref Matrix[] instanceTransforms,
      Matrix view,
      Matrix projection,
      Vector3 light,
      Vector3 amb,
      Vector3 diffu,
      Vector3 vpos)
    {
      if (this.show.Count == 0)
        return;
      this.modelParts[0].show = this.show;
      this.modelParts[0].DrawGems(ref instanceTransforms, view, projection, light, amb, diffu, vpos);
    }

    public void DrawBoulders(
      ref Matrix[] instanceTransforms,
      Matrix view,
      Matrix projection,
      Vector3 light,
      Vector3 amb,
      Vector3 diffu,
      int count)
    {
      if (count == 0)
        return;
      this.modelParts[0].boulders(ref instanceTransforms, view, projection, light, amb, diffu, count);
    }

    public void DrawBreak(
      ref Matrix[] instanceTransforms,
      Matrix view,
      Matrix projection,
      Vector3 light,
      Vector3 amb,
      Vector3 diffu,
      int count)
    {
      if (count == 0)
        return;
      this.modelParts[0].breakage(ref instanceTransforms, view, projection, light, amb, diffu, count);
    }

    public void DrawSmallGems(
      ref Matrix[] instanceTransforms,
      int count,
      Matrix view,
      Matrix projection,
      Vector3 light,
      Vector3 amb,
      Vector3 diffu)
    {
      if (count == 0)
        return;
      this.modelParts[0].smallGems(ref instanceTransforms, view, projection, light, amb, diffu);
    }

    public void DrawChain(
      ref Matrix[] instanceTransforms,
      Matrix view,
      Matrix projection,
      Vector3 light,
      Vector3 amb,
      Vector3 diffu,
      int start)
    {
      if (instanceTransforms.Length == 0)
        return;
      this.modelParts[0].chain(ref instanceTransforms, view, projection, light, amb, diffu, start);
    }
  }
}
