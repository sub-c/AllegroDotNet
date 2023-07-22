using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native.Structs;

/// <summary>
/// This structure holds the data for a locked bitmap region.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct AllegroLockedRegion
{
  internal IntPtr data;
  internal int format;
  internal int pitch;
  internal int pixel_size;
}