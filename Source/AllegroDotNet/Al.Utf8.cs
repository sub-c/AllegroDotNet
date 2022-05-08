using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet
{
  public static partial class Al
  {
    public static AllegroUstr? UstrNew(string cstr)
    {
      var nativeString = Marshal.StringToHGlobalAnsi(cstr);
      var result = NativeFunctions.AlUstrNew(nativeString);
      Marshal.FreeHGlobal(nativeString);
      return NativePointerModel.Create<AllegroUstr>(result);
    }

    public static AllegroUstr? UStrNewFromBuffer(IntPtr buffer, long size)
    {
      var result = NativeFunctions.AlUstrNewFromBuffer(buffer, size);
      return NativePointerModel.Create<AllegroUstr>(result);
    }

    public static void UstrFree(AllegroUstr? ustr)
    {
      NativeFunctions.AlUstrFree(NativePointerModel.GetPointer(ustr));
    }
  }
}
