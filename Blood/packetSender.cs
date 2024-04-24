using System;
using System.Collections.Generic;

#nullable disable
namespace Blood
{
  internal class packetSender
  {
    public byte[] packetB = new byte[1];
    public List<byte> packet = new List<byte>();

    public packetSender()
    {
      this.packet = new List<byte>();
      this.packet.Clear();
    }

    public void Write(byte val) => this.packet.Add(val);

    public void Write(float val)
    {
      foreach (byte num in BitConverter.GetBytes(val))
        this.packet.Add(num);
    }

    public void Write(int val)
    {
      foreach (byte num in BitConverter.GetBytes(val))
        this.packet.Add(num);
    }

    public void WriteU(ulong val)
    {
      foreach (byte num in BitConverter.GetBytes(val))
        this.packet.Add(num);
    }

    public void Write(uint val)
    {
      foreach (byte num in BitConverter.GetBytes(val))
        this.packet.Add(num);
    }

    public void Write(ushort val)
    {
      foreach (byte num in BitConverter.GetBytes(val))
        this.packet.Add(num);
    }

    public void Write(bool val)
    {
      foreach (byte num in BitConverter.GetBytes(val))
        this.packet.Add(num);
    }

    public void WriteString(string val)
    {
      for (int startIndex = 0; startIndex < val.Length; ++startIndex)
        this.packet.Add(this.getByteFromString(val.Substring(startIndex, 1)));
    }

    public byte[] mypackets() => this.packet.ToArray();

    public void clean() => this.packet.Clear();

    public byte getByteFromString(string s)
    {
      byte byteFromString = 78;
      if (s == "0")
        byteFromString = (byte) 0;
      if (s == "1")
        byteFromString = (byte) 1;
      if (s == "2")
        byteFromString = (byte) 2;
      if (s == "3")
        byteFromString = (byte) 3;
      if (s == "4")
        byteFromString = (byte) 4;
      if (s == "5")
        byteFromString = (byte) 5;
      if (s == "6")
        byteFromString = (byte) 6;
      if (s == "7")
        byteFromString = (byte) 7;
      if (s == "8")
        byteFromString = (byte) 8;
      if (s == "a")
        byteFromString = (byte) 9;
      if (s == "b")
        byteFromString = (byte) 10;
      if (s == "c")
        byteFromString = (byte) 11;
      if (s == "d")
        byteFromString = (byte) 12;
      if (s == "e")
        byteFromString = (byte) 13;
      if (s == "f")
        byteFromString = (byte) 14;
      if (s == "g")
        byteFromString = (byte) 15;
      if (s == "h")
        byteFromString = (byte) 16;
      if (s == "i")
        byteFromString = (byte) 17;
      if (s == "j")
        byteFromString = (byte) 18;
      if (s == "k")
        byteFromString = (byte) 19;
      if (s == "l")
        byteFromString = (byte) 20;
      if (s == "m")
        byteFromString = (byte) 21;
      if (s == "n")
        byteFromString = (byte) 22;
      if (s == "o")
        byteFromString = (byte) 23;
      if (s == "p")
        byteFromString = (byte) 24;
      if (s == "q")
        byteFromString = (byte) 25;
      if (s == "r")
        byteFromString = (byte) 26;
      if (s == nameof (s))
        byteFromString = (byte) 27;
      if (s == "t")
        byteFromString = (byte) 28;
      if (s == "u")
        byteFromString = (byte) 29;
      if (s == "v")
        byteFromString = (byte) 30;
      if (s == "w")
        byteFromString = (byte) 31;
      if (s == "x")
        byteFromString = (byte) 32;
      if (s == "y")
        byteFromString = (byte) 33;
      if (s == "z")
        byteFromString = (byte) 34;
      if (s == "A")
        byteFromString = (byte) 35;
      if (s == "B")
        byteFromString = (byte) 36;
      if (s == "C")
        byteFromString = (byte) 37;
      if (s == "D")
        byteFromString = (byte) 38;
      if (s == "E")
        byteFromString = (byte) 39;
      if (s == "F")
        byteFromString = (byte) 40;
      if (s == "G")
        byteFromString = (byte) 41;
      if (s == "H")
        byteFromString = (byte) 42;
      if (s == "I")
        byteFromString = (byte) 43;
      if (s == "J")
        byteFromString = (byte) 44;
      if (s == "K")
        byteFromString = (byte) 45;
      if (s == "L")
        byteFromString = (byte) 46;
      if (s == "M")
        byteFromString = (byte) 47;
      if (s == "N")
        byteFromString = (byte) 48;
      if (s == "O")
        byteFromString = (byte) 49;
      if (s == "P")
        byteFromString = (byte) 50;
      if (s == "Q")
        byteFromString = (byte) 51;
      if (s == "R")
        byteFromString = (byte) 52;
      if (s == "S")
        byteFromString = (byte) 53;
      if (s == "T")
        byteFromString = (byte) 54;
      if (s == "U")
        byteFromString = (byte) 55;
      if (s == "V")
        byteFromString = (byte) 56;
      if (s == "W")
        byteFromString = (byte) 57;
      if (s == "X")
        byteFromString = (byte) 58;
      if (s == "Y")
        byteFromString = (byte) 59;
      if (s == "Z")
        byteFromString = (byte) 60;
      if (s == "!")
        byteFromString = (byte) 61;
      if (s == "@")
        byteFromString = (byte) 62;
      if (s == "#")
        byteFromString = (byte) 63;
      if (s == "$")
        byteFromString = (byte) 64;
      if (s == "%")
        byteFromString = (byte) 65;
      if (s == "^")
        byteFromString = (byte) 66;
      if (s == "&")
        byteFromString = (byte) 67;
      if (s == "*")
        byteFromString = (byte) 68;
      if (s == "(")
        byteFromString = (byte) 69;
      if (s == ")")
        byteFromString = (byte) 70;
      if (s == "<")
        byteFromString = (byte) 71;
      if (s == ">")
        byteFromString = (byte) 72;
      if (s == "?")
        byteFromString = (byte) 73;
      if (s == ":")
        byteFromString = (byte) 74;
      if (s == "{")
        byteFromString = (byte) 75;
      if (s == "}")
        byteFromString = (byte) 76;
      if (s == "_")
        byteFromString = (byte) 77;
      if (s == "+")
        byteFromString = (byte) 78;
      if (s == ",")
        byteFromString = (byte) 79;
      if (s == ".")
        byteFromString = (byte) 80;
      if (s == "/")
        byteFromString = (byte) 81;
      if (s == ";")
        byteFromString = (byte) 82;
      if (s == "[")
        byteFromString = (byte) 83;
      if (s == "]")
        byteFromString = (byte) 84;
      if (s == "-")
        byteFromString = (byte) 85;
      if (s == "=")
        byteFromString = (byte) 86;
      if (s == " ")
        byteFromString = (byte) 87;
      if (s == "9")
        byteFromString = (byte) 88;
      if (s == "'")
        byteFromString = (byte) 89;
      if (s == "\"")
        byteFromString = (byte) 90;
      if (s == "|")
        byteFromString = (byte) 91;
      if (s == "\\")
        byteFromString = (byte) 92;
      return byteFromString;
    }
  }
}
