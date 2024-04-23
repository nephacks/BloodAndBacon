// Decompiled with JetBrains decompiler
// Type: Blood.InstancedModelReader
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

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
