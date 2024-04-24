using Microsoft.Xna.Framework.Content;

#nullable disable
namespace Blood
{
  public class InstancedModelReader : ContentTypeReader<InstancedModel>
  {
    protected override InstancedModel Read(ContentReader input, InstancedModel existingInstance)
    {
      return new InstancedModel(input);
    }
  }
}
