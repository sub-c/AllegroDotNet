using SubC.AllegroDotNet.Enums;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models
{
  public sealed class AllegroDisplayMode
  {
    public int Width
    {
      get => DisplayMode.width;
      set => DisplayMode.width = value;
    }

    public int Height
    {
      get => DisplayMode.height;
      set => DisplayMode.height = value;
    }

    public PixelFormat Format
    {
      get => (PixelFormat)DisplayMode.format;
      set => DisplayMode.format = (int)value;
    }

    public int RefreshRate
    {
      get => DisplayMode.refresh_rate;
      set => DisplayMode.refresh_rate = value;
    }

    internal NativeDisplayMode DisplayMode;

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct NativeDisplayMode
    {
      public int width;
      public int height;
      public int format;
      public int refresh_rate;
    }
  }
}