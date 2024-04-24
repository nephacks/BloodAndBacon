using Microsoft.Xna.Framework;
using System;

#nullable disable
namespace Blood
{
  public class Randoms
  {
    public int seedIndex;
    public static float[] vals;
    private int maximum = 10000;

    public Randoms(int start) => this.seedIndex = start % this.maximum;

    public void changeSeed(int start) => this.seedIndex = start % this.maximum;

    public static void initRandom(int seed)
    {
      Random random = new Random(seed);
      Randoms.vals = new float[10000];
      for (int index = 0; index < 10000; ++index)
        Randoms.vals[index] = (float) random.NextDouble();
    }

    public int Next(int min, int max)
    {
      ++this.seedIndex;
      if (this.seedIndex > this.maximum - 1)
        this.seedIndex = 0;
      float val = Randoms.vals[this.seedIndex];
      return (int) MathHelper.Lerp((float) min, (float) max, val);
    }
  }
}
