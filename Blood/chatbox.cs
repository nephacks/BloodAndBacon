// Decompiled with JetBrains decompiler
// Type: Blood.chatbox
// Assembly: BloodandBacon, Version=2.1.1.8, Culture=neutral, PublicKeyToken=null
// MVID: F4C16F53-CCDA-4F28-8BE8-E2C669EABDFC
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Blood and Bacon\BloodandBacon_Slayed.exe

using System;

#nullable disable
namespace Blood
{
  public class chatbox
  {
    private ulong num;
    public bool message2send;
    public int messageIndex = -1;
    public bool sendAgain;
    public string message = "";
    public ulong bignum1;
    public ulong bignum2;
    public byte len1;
    public byte len2;

    public chatbox()
    {
      this.message2send = false;
      this.message = "";
      this.len1 = (byte) 0;
      this.len2 = (byte) 0;
    }

    public string getMessage(ulong num1, byte len1, ulong num2, byte len2)
    {
      string str = "";
      for (int bitCount = 0; bitCount < (int) len1; ++bitCount)
      {
        ulong val = this.ReadFromBigfield(ref num1, (ulong) bitCount);
        str += this.getLetter(val);
      }
      for (int bitCount = 0; bitCount < (int) len2; ++bitCount)
      {
        ulong val = this.ReadFromBigfield(ref num2, (ulong) bitCount);
        str += this.getLetter(val);
      }
      return str.ToLower();
    }

    public void message2nums(string mess)
    {
      this.bignum1 = 0UL;
      this.bignum2 = 0UL;
      this.len1 = (byte) 0;
      this.len2 = (byte) 0;
      char[] charArray = mess.ToCharArray();
      int num = charArray.Length;
      if (num > 12)
        num = 12;
      for (int bitCount = 0; bitCount < num; ++bitCount)
      {
        this.AddToBigfield(ref this.bignum1, (ulong) bitCount, this.getNum(charArray[bitCount]));
        this.len1 = (byte) num;
      }
      if (charArray.Length <= 12)
        return;
      ulong bitCount1 = 0;
      for (int index = 12; index < charArray.Length; ++index)
      {
        this.AddToBigfield(ref this.bignum2, bitCount1, this.getNum(charArray[index]));
        ++bitCount1;
        this.len2 = (byte) (charArray.Length - 12);
      }
    }

    public void AddToBigfield(ref ulong bitfield, ulong bitCount, ulong value)
    {
      bitfield += value * (ulong) Math.Pow(32.0, (double) bitCount);
    }

    public ulong getNum(char c)
    {
      ulong num = 1;
      string upper = c.ToString().ToUpper();
      if (upper == "A")
        num = 0UL;
      if (upper == "B")
        num = 1UL;
      if (upper == "C")
        num = 2UL;
      if (upper == "D")
        num = 3UL;
      if (upper == "E")
        num = 4UL;
      if (upper == "F")
        num = 5UL;
      if (upper == "G")
        num = 6UL;
      if (upper == "H")
        num = 7UL;
      if (upper == "I")
        num = 8UL;
      if (upper == "J")
        num = 9UL;
      if (upper == "K")
        num = 10UL;
      if (upper == "L")
        num = 11UL;
      if (upper == "M")
        num = 12UL;
      if (upper == "N")
        num = 13UL;
      if (upper == "O")
        num = 14UL;
      if (upper == "P")
        num = 15UL;
      if (upper == "Q")
        num = 16UL;
      if (upper == "R")
        num = 17UL;
      if (upper == "S")
        num = 18UL;
      if (upper == "T")
        num = 19UL;
      if (upper == "U")
        num = 20UL;
      if (upper == "V")
        num = 21UL;
      if (upper == "W")
        num = 22UL;
      if (upper == "X")
        num = 23UL;
      if (upper == "Y")
        num = 24UL;
      if (upper == "Z")
        num = 25UL;
      if (upper == " ")
        num = 26UL;
      if (upper == "?")
        num = 27UL;
      if (upper == "!")
        num = 28UL;
      if (upper == ":")
        num = 29UL;
      if (upper == ")")
        num = 30UL;
      if (upper == "(")
        num = 31UL;
      return num;
    }

    public ulong ReadFromBigfield(ref ulong bitfield, ulong bitCount)
    {
      ulong num1 = (ulong) Math.Pow(32.0, (double) (bitCount + 1UL));
      ulong num2 = (ulong) Math.Pow(32.0, (double) bitCount);
      return bitfield % num1 / num2;
    }

    public string getLetter(ulong val)
    {
      string letter = ".";
      if (val == 0UL)
        letter = "A";
      if (val == 1UL)
        letter = "B";
      if (val == 2UL)
        letter = "C";
      if (val == 3UL)
        letter = "D";
      if (val == 4UL)
        letter = "E";
      if (val == 5UL)
        letter = "F";
      if (val == 6UL)
        letter = "G";
      if (val == 7UL)
        letter = "H";
      if (val == 8UL)
        letter = "I";
      if (val == 9UL)
        letter = "J";
      if (val == 10UL)
        letter = "K";
      if (val == 11UL)
        letter = "L";
      if (val == 12UL)
        letter = "M";
      if (val == 13UL)
        letter = "N";
      if (val == 14UL)
        letter = "O";
      if (val == 15UL)
        letter = "P";
      if (val == 16UL)
        letter = "Q";
      if (val == 17UL)
        letter = "R";
      if (val == 18UL)
        letter = "S";
      if (val == 19UL)
        letter = "T";
      if (val == 20UL)
        letter = "U";
      if (val == 21UL)
        letter = "V";
      if (val == 22UL)
        letter = "W";
      if (val == 23UL)
        letter = "X";
      if (val == 24UL)
        letter = "Y";
      if (val == 25UL)
        letter = "Z";
      if (val == 26UL)
        letter = " ";
      if (val == 27UL)
        letter = "?";
      if (val == 28UL)
        letter = "!";
      if (val == 29UL)
        letter = ":";
      if (val == 30UL)
        letter = ")";
      if (val == 31UL)
        letter = "(";
      return letter;
    }

    public string getStringfromByte(byte mybyte)
    {
      string stringfromByte = "*";
      if (mybyte == (byte) 0)
        stringfromByte = "0";
      if (mybyte == (byte) 1)
        stringfromByte = "1";
      if (mybyte == (byte) 2)
        stringfromByte = "2";
      if (mybyte == (byte) 3)
        stringfromByte = "3";
      if (mybyte == (byte) 4)
        stringfromByte = "4";
      if (mybyte == (byte) 5)
        stringfromByte = "5";
      if (mybyte == (byte) 6)
        stringfromByte = "6";
      if (mybyte == (byte) 7)
        stringfromByte = "7";
      if (mybyte == (byte) 8)
        stringfromByte = "8";
      if (mybyte == (byte) 9)
        stringfromByte = "a";
      if (mybyte == (byte) 10)
        stringfromByte = "b";
      if (mybyte == (byte) 11)
        stringfromByte = "c";
      if (mybyte == (byte) 12)
        stringfromByte = "d";
      if (mybyte == (byte) 13)
        stringfromByte = "e";
      if (mybyte == (byte) 14)
        stringfromByte = "f";
      if (mybyte == (byte) 15)
        stringfromByte = "g";
      if (mybyte == (byte) 16)
        stringfromByte = "h";
      if (mybyte == (byte) 17)
        stringfromByte = "i";
      if (mybyte == (byte) 18)
        stringfromByte = "j";
      if (mybyte == (byte) 19)
        stringfromByte = "k";
      if (mybyte == (byte) 20)
        stringfromByte = "l";
      if (mybyte == (byte) 21)
        stringfromByte = "m";
      if (mybyte == (byte) 22)
        stringfromByte = "n";
      if (mybyte == (byte) 23)
        stringfromByte = "o";
      if (mybyte == (byte) 24)
        stringfromByte = "p";
      if (mybyte == (byte) 25)
        stringfromByte = "q";
      if (mybyte == (byte) 26)
        stringfromByte = "r";
      if (mybyte == (byte) 27)
        stringfromByte = "s";
      if (mybyte == (byte) 28)
        stringfromByte = "t";
      if (mybyte == (byte) 29)
        stringfromByte = "u";
      if (mybyte == (byte) 30)
        stringfromByte = "v";
      if (mybyte == (byte) 31)
        stringfromByte = "w";
      if (mybyte == (byte) 32)
        stringfromByte = "x";
      if (mybyte == (byte) 33)
        stringfromByte = "y";
      if (mybyte == (byte) 34)
        stringfromByte = "z";
      if (mybyte == (byte) 35)
        stringfromByte = "A";
      if (mybyte == (byte) 36)
        stringfromByte = "B";
      if (mybyte == (byte) 37)
        stringfromByte = "C";
      if (mybyte == (byte) 38)
        stringfromByte = "D";
      if (mybyte == (byte) 39)
        stringfromByte = "E";
      if (mybyte == (byte) 40)
        stringfromByte = "F";
      if (mybyte == (byte) 41)
        stringfromByte = "G";
      if (mybyte == (byte) 42)
        stringfromByte = "H";
      if (mybyte == (byte) 43)
        stringfromByte = "I";
      if (mybyte == (byte) 44)
        stringfromByte = "J";
      if (mybyte == (byte) 45)
        stringfromByte = "K";
      if (mybyte == (byte) 46)
        stringfromByte = "L";
      if (mybyte == (byte) 47)
        stringfromByte = "M";
      if (mybyte == (byte) 48)
        stringfromByte = "N";
      if (mybyte == (byte) 49)
        stringfromByte = "O";
      if (mybyte == (byte) 50)
        stringfromByte = "P";
      if (mybyte == (byte) 51)
        stringfromByte = "Q";
      if (mybyte == (byte) 52)
        stringfromByte = "R";
      if (mybyte == (byte) 53)
        stringfromByte = "S";
      if (mybyte == (byte) 54)
        stringfromByte = "T";
      if (mybyte == (byte) 55)
        stringfromByte = "U";
      if (mybyte == (byte) 56)
        stringfromByte = "V";
      if (mybyte == (byte) 57)
        stringfromByte = "W";
      if (mybyte == (byte) 58)
        stringfromByte = "X";
      if (mybyte == (byte) 59)
        stringfromByte = "Y";
      if (mybyte == (byte) 60)
        stringfromByte = "Z";
      if (mybyte == (byte) 61)
        stringfromByte = "!";
      if (mybyte == (byte) 62)
        stringfromByte = "@";
      if (mybyte == (byte) 63)
        stringfromByte = "#";
      if (mybyte == (byte) 64)
        stringfromByte = "$";
      if (mybyte == (byte) 65)
        stringfromByte = "%";
      if (mybyte == (byte) 66)
        stringfromByte = "^";
      if (mybyte == (byte) 67)
        stringfromByte = "&";
      if (mybyte == (byte) 68)
        stringfromByte = "*";
      if (mybyte == (byte) 69)
        stringfromByte = "(";
      if (mybyte == (byte) 70)
        stringfromByte = ")";
      if (mybyte == (byte) 71)
        stringfromByte = "<";
      if (mybyte == (byte) 72)
        stringfromByte = ">";
      if (mybyte == (byte) 73)
        stringfromByte = "?";
      if (mybyte == (byte) 74)
        stringfromByte = ":";
      if (mybyte == (byte) 75)
        stringfromByte = "{";
      if (mybyte == (byte) 76)
        stringfromByte = "}";
      if (mybyte == (byte) 77)
        stringfromByte = "_";
      if (mybyte == (byte) 78)
        stringfromByte = "+";
      if (mybyte == (byte) 79)
        stringfromByte = ",";
      if (mybyte == (byte) 80)
        stringfromByte = ".";
      if (mybyte == (byte) 81)
        stringfromByte = "/";
      if (mybyte == (byte) 82)
        stringfromByte = ";";
      if (mybyte == (byte) 83)
        stringfromByte = "[";
      if (mybyte == (byte) 84)
        stringfromByte = "]";
      if (mybyte == (byte) 85)
        stringfromByte = "-";
      if (mybyte == (byte) 86)
        stringfromByte = "=";
      if (mybyte == (byte) 87)
        stringfromByte = " ";
      if (mybyte == (byte) 88)
        stringfromByte = "9";
      if (mybyte == (byte) 89)
        stringfromByte = "'";
      if (mybyte == (byte) 90)
        stringfromByte = "\"";
      if (mybyte == (byte) 91)
        stringfromByte = "|";
      if (mybyte == (byte) 92)
        stringfromByte = "\\";
      return stringfromByte;
    }
  }
}
