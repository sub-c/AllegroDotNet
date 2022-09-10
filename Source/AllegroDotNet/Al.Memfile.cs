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

    public static (AllegroFile?, IntPtr) OpenMemfile(byte[] bytes, MemfileMode mode)
    {
      var modeString = mode.HasFlag(MemfileMode.Read) ? "r" : string.Empty;
      modeString += mode.HasFlag(MemfileMode.Write) ? "w" : string.Empty;
      var nativeMode = Marshal.StringToHGlobalAnsi(modeString);
      var nativeMemory = Marshal.AllocHGlobal(bytes.Length);
      Marshal.Copy(bytes, 0, nativeMemory, bytes.Length);
      var nativeMemfile = NativeFunctions.AlOpenMemfile(nativeMemory, bytes.Length, nativeMode);
      Marshal.FreeHGlobal(nativeMode);
      var allegroFile = NativePointerModel.Create<AllegroFile>(nativeMemfile);
      return (allegroFile, nativeMemfile);
    }

    public static uint GetAllegroMemfileVersion()
    {
      return NativeFunctions.AlGetAllegroMemfileVersion();
    }
  }
}
