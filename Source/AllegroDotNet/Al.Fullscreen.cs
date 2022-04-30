using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet
{
  public static partial class Al
  {
    public static AllegroDisplayMode? GetDisplayMode(int index, AllegroDisplayMode displayMode)
    {
      var nativeValue = NativeFunctions.AlGetDisplayMode(index, ref displayMode.DisplayMode);
      return nativeValue == IntPtr.Zero ? null : displayMode;
    }

    public static int GetNumDisplayModes()
    {
      return NativeFunctions.AlGetNumDisplayModes();
    }
  }
}