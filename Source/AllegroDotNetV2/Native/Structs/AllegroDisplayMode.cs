using System.Runtime.InteropServices;
using SubC.AllegroDotNet.Enums;

namespace SubC.AllegroDotNet.Native.Structs;

/// <summary>
/// This structure is used for fullscreen mode queries. Contains information about a supported fullscreen mode.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct AllegroDisplayMode
{
  /// <summary>
  /// Gets or sets the screen width of the mode.
  /// </summary>
  public int Width
  {
    get => width;
    set => width = value;
  }

  /// <summary>
  /// Gets or sets the screen height of the mode.
  /// </summary>
  public int Height
  {
    get => height;
    set => height = value;
  }

  /// <summary>
  /// Gets or sets the pixel format of the mode.
  /// </summary>
  public PixelFormat Format
  {
    get => (PixelFormat)format;
    set => format = (int)value;
  }

  /// <summary>
  /// Gets or sets the refresh rate of the mode.
  /// </summary>
  public int RefreshRate
  {
    get => refresh_rate;
    set => refresh_rate = value;
  }
  
  internal int width;
  internal int height;
  internal int format;
  internal int refresh_rate;
}