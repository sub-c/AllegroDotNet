using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet
{
  public static partial class Al
  {
    public static IntPtr Malloc(
        ulong size,
        [CallerLineNumber] int line = 0,
        [CallerFilePath] string file = "",
        [CallerMemberName] string function = "")
    {
      return MallocWithContext(size, line, file, function);
    }

    public static void Free(
        IntPtr pointer,
        [CallerLineNumber] int line = 0,
        [CallerFilePath] string file = "",
        [CallerMemberName] string function = "")
    {
      FreeWithContext(pointer, line, file, function);
    }

    public static IntPtr Realloc(
        IntPtr pointer,
        ulong size,
        [CallerLineNumber] int line = 0,
        [CallerFilePath] string file = "",
        [CallerMemberName] string function = "")
    {
      return ReallocWithContext(pointer, size, line, file, function);
    }

    public static IntPtr Calloc(
        ulong count,
        ulong size,
        [CallerLineNumber] int line = 0,
        [CallerFilePath] string file = "",
        [CallerMemberName] string function = "")
    {
      return CallocWithContext(count, size, line, file, function);
    }

    public static IntPtr MallocWithContext(
        ulong size,
        [CallerLineNumber] int line = 0,
        [CallerFilePath] string file = "",
        [CallerMemberName] string function = "")
    {
      var nativeFile = Marshal.StringToHGlobalAnsi(file);
      var nativeFunction = Marshal.StringToHGlobalAnsi(function);
      var nativeValue = NativeFunctions.AlMallocWithContext(new UIntPtr(size), line, nativeFile, nativeFunction);
      Marshal.FreeHGlobal(nativeFile);
      Marshal.FreeHGlobal(nativeFunction);
      return nativeValue;
    }

    public static void FreeWithContext(
        IntPtr pointer,
        [CallerLineNumber] int line = 0,
        [CallerFilePath] string file = "",
        [CallerMemberName] string function = "")
    {
      var nativeStringFile = Marshal.StringToHGlobalAnsi(file);
      var nativeStringFunction = Marshal.StringToHGlobalAnsi(function);
      NativeFunctions.AlFreeWithContext(pointer, line, nativeStringFile, nativeStringFunction);
      Marshal.FreeHGlobal(nativeStringFile);
      Marshal.FreeHGlobal(nativeStringFunction);
    }

    public static IntPtr ReallocWithContext(
        IntPtr pointer,
        ulong size,
        [CallerLineNumber] int line = 0,
        [CallerFilePath] string file = "",
        [CallerMemberName] string function = "")
    {
      var nativeFile = Marshal.StringToHGlobalAnsi(file);
      var nativeFunction = Marshal.StringToHGlobalAnsi(function);
      var nativeValue = NativeFunctions.AlReallocWithContext(pointer, new UIntPtr(size), line, nativeFile, nativeFunction);
      Marshal.FreeHGlobal(nativeFile);
      Marshal.FreeHGlobal(nativeFunction);
      return nativeValue;
    }

    public static IntPtr CallocWithContext(
        ulong count,
        ulong size,
        [CallerLineNumber] int line = 0,
        [CallerFilePath] string file = "",
        [CallerMemberName] string function = "")
    {
      var nativeFile = Marshal.StringToHGlobalAnsi(file);
      var nativeFunction = Marshal.StringToHGlobalAnsi(function);
      var nativeValue = NativeFunctions.AlCallocWithContext(new UIntPtr(count), new UIntPtr(size), line, nativeFile, nativeFunction);
      Marshal.FreeHGlobal(nativeFile);
      Marshal.FreeHGlobal(nativeFunction);
      return nativeValue;
    }

    public static void SetMemoryInterface(AllegroMemoryInterface memoryInterface)
    {
      NativeFunctions.AlSetMemoryInterface(ref memoryInterface.MemoryInterface);
    }
  }
}