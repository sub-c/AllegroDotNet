using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models
{
  public sealed class AllegroTransform
  {
    internal NativeAllegroTransform Transform = new();

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct NativeAllegroTransform
    {
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
      private float[] m;
    }
  }
}