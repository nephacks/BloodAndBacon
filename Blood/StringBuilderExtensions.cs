using System;
using System.Text;

#nullable disable
namespace Blood
{
  public static class StringBuilderExtensions
  {
    private static readonly char[] ms_digits = new char[16]
    {
      '0',
      '1',
      '2',
      '3',
      '4',
      '5',
      '6',
      '7',
      '8',
      '9',
      'A',
      'B',
      'C',
      'D',
      'E',
      'F'
    };
    private static readonly uint ms_default_decimal_places = 5;
    private static readonly char ms_default_pad_char = '0';

    public static StringBuilder Concat(
      this StringBuilder string_builder,
      uint uint_val,
      uint pad_amount,
      char pad_char,
      uint base_val)
    {
      uint val2 = 0;
      uint num = uint_val;
      do
      {
        num /= base_val;
        ++val2;
      }
      while (num > 0U);
      string_builder.Append(pad_char, (int) Math.Max(pad_amount, val2));
      int length = string_builder.Length;
      for (; val2 > 0U; --val2)
      {
        --length;
                string_builder[length] = StringBuilderExtensions.ms_digits[(int)((uint_val % base_val))];
        uint_val /= base_val;
      }
      return string_builder;
    }

    public static StringBuilder Concat(this StringBuilder string_builder, uint uint_val)
    {
      string_builder.Concat(uint_val, 0U, StringBuilderExtensions.ms_default_pad_char, 10U);
      return string_builder;
    }

    public static StringBuilder Concat(
      this StringBuilder string_builder,
      uint uint_val,
      uint pad_amount)
    {
      string_builder.Concat(uint_val, pad_amount, StringBuilderExtensions.ms_default_pad_char, 10U);
      return string_builder;
    }

    public static StringBuilder Concat(
      this StringBuilder string_builder,
      uint uint_val,
      uint pad_amount,
      char pad_char)
    {
      string_builder.Concat(uint_val, pad_amount, pad_char, 10U);
      return string_builder;
    }

    public static StringBuilder Concat(
      this StringBuilder string_builder,
      int int_val,
      uint pad_amount,
      char pad_char,
      uint base_val)
    {
      if (int_val < 0)
      {
        string_builder.Append('-');
        uint uint_val = (uint) (-1 - int_val + 1);
        string_builder.Concat(uint_val, pad_amount, pad_char, base_val);
      }
      else
        string_builder.Concat((uint) int_val, pad_amount, pad_char, base_val);
      return string_builder;
    }

    public static StringBuilder Concat(this StringBuilder string_builder, int int_val)
    {
      string_builder.Concat(int_val, 0U, StringBuilderExtensions.ms_default_pad_char, 10U);
      return string_builder;
    }

    public static StringBuilder Concat(
      this StringBuilder string_builder,
      int int_val,
      uint pad_amount)
    {
      string_builder.Concat(int_val, pad_amount, StringBuilderExtensions.ms_default_pad_char, 10U);
      return string_builder;
    }

    public static StringBuilder Concat(
      this StringBuilder string_builder,
      int int_val,
      uint pad_amount,
      char pad_char)
    {
      string_builder.Concat(int_val, pad_amount, pad_char, 10U);
      return string_builder;
    }

    public static StringBuilder Concat(
      this StringBuilder string_builder,
      float float_val,
      uint decimal_places,
      uint pad_amount,
      char pad_char)
    {
      if (decimal_places == 0U)
      {
        int int_val = (double) float_val < 0.0 ? (int) ((double) float_val - 0.5) : (int) ((double) float_val + 0.5);
        string_builder.Concat(int_val, pad_amount, pad_char, 10U);
      }
      else
      {
        int int_val = (int) float_val;
        string_builder.Concat(int_val, pad_amount, pad_char, 10U);
        string_builder.Append('.');
        float num = Math.Abs(float_val - (float) int_val);
        do
        {
          num *= 10f;
          --decimal_places;
        }
        while (decimal_places > 0U);
        float uint_val = num + 0.5f;
        string_builder.Concat((uint) uint_val, 0U, '0', 10U);
      }
      return string_builder;
    }

    public static StringBuilder Concat(this StringBuilder string_builder, float float_val)
    {
      string_builder.Concat(float_val, StringBuilderExtensions.ms_default_decimal_places, 0U, StringBuilderExtensions.ms_default_pad_char);
      return string_builder;
    }

    public static StringBuilder Concat(
      this StringBuilder string_builder,
      float float_val,
      uint decimal_places)
    {
      string_builder.Concat(float_val, decimal_places, 0U, StringBuilderExtensions.ms_default_pad_char);
      return string_builder;
    }

    public static StringBuilder Concat(
      this StringBuilder string_builder,
      float float_val,
      uint decimal_places,
      uint pad_amount)
    {
      string_builder.Concat(float_val, decimal_places, pad_amount, StringBuilderExtensions.ms_default_pad_char);
      return string_builder;
    }
  }
}
