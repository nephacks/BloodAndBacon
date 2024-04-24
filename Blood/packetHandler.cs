using System;

#nullable disable
namespace Blood
{
  internal class packetHandler
  {
    private byte[] thispacket;
    public int index;

    public packetHandler(ref byte[] packet)
    {
      this.thispacket = new byte[packet.Length];
      Array.Copy((Array) packet, (Array) this.thispacket, packet.Length);
      this.index = 0;
    }

    public byte ReadByte()
    {
      byte num = this.thispacket[this.index];
      ++this.index;
      return num;
    }

    public int method_0()
    {
      int int32 = BitConverter.ToInt32(this.thispacket, this.index);
      this.index += 4;
      return int32;
    }

    public ushort method_1()
    {
      ushort uint16 = BitConverter.ToUInt16(this.thispacket, this.index);
      this.index += 2;
      return uint16;
    }
  }
}
