using SubC.AllegroDotNet.Enums;
using System;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models
{
  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct AllegroLockedRegion
  {
    public IntPtr Data
    {
      get => data;
      set => data = value;
    }

    public PixelFormat Format
    {
      get => (PixelFormat)format;
      set => format = (int)value;
    }

    public int Pitch

    {
      get => pitch;
      set => pitch = value;
    }

    public int PixelSize
    {
      get => pixel_size;
      set => pixel_size = value;
    }

    internal IntPtr data;
    internal int format;
    internal int pitch;
    internal int pixel_size;
  }
}