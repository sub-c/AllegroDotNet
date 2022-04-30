using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models
{
  public sealed class AllegroEventSource : NativePointerModel
  {
    //internal NativeAllegroEventSource NativeEventSource = new();

    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeAllegroEventSource
    {
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
      int[] __pad;
    }
  }
}