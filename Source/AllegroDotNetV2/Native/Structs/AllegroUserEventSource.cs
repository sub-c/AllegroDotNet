using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native.Structs;

[StructLayout(LayoutKind.Sequential)]
internal struct NativeAllegroEventSource
{
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
  int[] __pad;
}