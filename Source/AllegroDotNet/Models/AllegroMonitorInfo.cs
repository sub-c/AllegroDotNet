using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models;

/// <summary>
/// This structure contains information about a video mode of a monitor.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct AllegroMonitorInfo
{
    public int X1
    {
        readonly get => x1;
        set => x1 = value;
    }

    public int Y1
    {
        readonly get => y1;
        set => y1 = value;
    }

    public int X2
    {
        readonly get => x2;
        set => x2 = value;
    }

    public int Y2
    {
        readonly get => y2;
        set => y2 = value;
    }

    private int x1;
    private int y1;
    private int x2;
    private int y2;
}
