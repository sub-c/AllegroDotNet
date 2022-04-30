using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet
{
  public static partial class Al
  {
    public static double GetTime()
    {
      return NativeFunctions.AlGetTime();
    }

    public static void InitTimeout(AllegroTimeout timeout, double seconds)
    {
      NativeFunctions.AlInitTimeout(ref timeout.NativeTimeout, seconds);
    }

    public static void Rest(double seconds)
    {
      NativeFunctions.AlRest(seconds);
    }
  }
}