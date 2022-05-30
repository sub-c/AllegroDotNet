using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet
{
  public static partial class Al
  {
    public static AllegroFile? OpenMemfile(IntPtr memory, long size, MemfileMode mode)
    {
      var modeString = string.Empty;
      modeString += mode.HasFlag(MemfileMode.Read) ? "r" : string.Empty;
      modeString += mode.HasFlag(MemfileMode.Write) ? "w" : string.Empty;
      var nativeMode = Marshal.StringToHGlobalAnsi(modeString);
      var result = NativeFunctions.AlOpenMemfile(memory, size, nativeMode);
      Marshal.FreeHGlobal(nativeMode);
      return NativePointerModel.Create<AllegroFile>(result);
    }

    public static uint GetAllegroMemfileVersion()
    {
      return NativeFunctions.AlGetAllegroMemfileVersion();
    }
  }
}
