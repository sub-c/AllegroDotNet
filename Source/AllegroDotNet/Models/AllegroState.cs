using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models
{
  public sealed class AllegroState
  {
    internal NativeAllegroState State = new();

    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeAllegroState
    {
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
      private byte[] _tls;
    }
  }
}