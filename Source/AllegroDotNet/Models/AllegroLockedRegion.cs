using SubC.AllegroDotNet.Enums;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models;

/// <summary>
/// This structure contains the state of a locked region of a bitmap.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct AllegroLockedRegion
{
    public IntPtr Data
    {
        readonly get => data;
        set => data = value;
    }

    public PixelFormat Format
    {
        readonly get => (PixelFormat)format;
        set => format = (int)value;
    }

    public int Pitch
    {
        readonly get => pitch;
        set => pitch = value;
    }

    public int PixelSize
    {
        readonly get => pixel_size;
        set => pixel_size = value;
    }

    private IntPtr data;
    private int format;
    private int pitch;
    private int pixel_size;
}
