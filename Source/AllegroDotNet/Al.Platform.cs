using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet
{
  public static partial class Al
  {
    public static IntPtr GetWinWindowHandle(AllegroDisplay? display)
    {
      if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
      {
        throw new NotSupportedException($"{nameof(GetWinWindowHandle)} is only supported on Windows.");
      }
      if (NativeFunctions.AlGetWinWindowHandle == null)
      {
        NativeFunctions.AlGetWinWindowHandle = NativeInterop.LoadFunction<NativeFunctions.al_get_win_window_handle>(NativeFunctions.AllegroLibrary);
      }
      return NativeFunctions.AlGetWinWindowHandle(NativePointerModel.GetPointer(display));
    }
  }
}
