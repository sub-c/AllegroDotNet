using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SubC.AllegroDotNet
{
  public static partial class Al
  {
    public static bool InitTtfAddon()
    {
      return NativeFunctions.AlInitTtfAddon();
    }

    public static bool IsTtfAddonInitialized()
    {
      return NativeFunctions.AlIsTtfAddonInitialized();
    }

    public static void ShutdownTtfAddon()
    {
      NativeFunctions.AlShutdownTtfAddon();
    }

    public static AllegroFont? LoadTtfFont(string filename, int size, LoadTtfFontFlags flags)
    {
      var nativeFilename = Marshal.StringToHGlobalAnsi(filename);
      var result = NativeFunctions.AlLoadTtfFont(nativeFilename, size, (int)flags);
      Marshal.FreeHGlobal(nativeFilename);
      return NativePointerModel.Create<AllegroFont>(result);
    }

    public static AllegroFont? LoadTtfFontF(AllegroFile? file, string filename, int size, LoadTtfFontFlags flags)
    {
      var nativeFilename = Marshal.StringToHGlobalAnsi(filename);
      var result = NativeFunctions.AlLoadTtfFontF(NativePointerModel.GetPointer(file), nativeFilename, size, (int)flags);
      Marshal.FreeHGlobal(nativeFilename);
      return NativePointerModel.Create<AllegroFont>(result);
    }

    public static AllegroFont? LoadTtfFontStretch(string filename, int width, int height, LoadTtfFontFlags flags)
    {
      var nativeFilename = Marshal.StringToHGlobalAnsi(filename);
      var result = NativeFunctions.AlLoadTtfFontStretch(nativeFilename, width, height, (int)flags);
      Marshal.FreeHGlobal(nativeFilename);
      return NativePointerModel.Create<AllegroFont>(result);
    }

    public static AllegroFont? LoadTtfFontStretchF(AllegroFile? file, string filename, int width, int height, LoadTtfFontFlags flags)
    {
      var nativeFilename = Marshal.StringToHGlobalAnsi(filename);
      var result = NativeFunctions.AlLoadTtfFontStretchF(NativePointerModel.GetPointer(file), nativeFilename, width, height, (int)flags);
      Marshal.FreeHGlobal(nativeFilename);
      return NativePointerModel.Create<AllegroFont>(result);
    }

    public static uint GetAllegroTtfVersion()
    {
      return NativeFunctions.AlGetAllegroTtfVersion();
    }
  }
}
