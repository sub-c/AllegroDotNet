using SubC.AllegroDotNet.Enums;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models;

/// <summary>
/// This structure is used for fullscreen mode queries.
/// It contains information about a supported fullscreen mode.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct AllegroDisplayMode
{
    public PixelFormat Format
    {
        readonly get => (PixelFormat)format;
        set => format = (int)value;
    }

    public int Height
    {
        readonly get => height;
        set => height = value;
    }

    public int RefreshRate
    {
        readonly get => refresh_rate;
        set => refresh_rate = value;
    }

    public int Width
    {
        readonly get => width;
        set => width = value;
    }

    internal int width;
    internal int height;
    internal int format;
    internal int refresh_rate;
}
