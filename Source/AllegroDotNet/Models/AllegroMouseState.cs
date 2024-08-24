using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models;

/// <summary>
/// This structure contains information about the state of the mouse at a moment in time.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct AllegroMouseState
{
    public int X
    {
        readonly get => x;
        set => x = value;
    }

    public int Y
    {
        readonly get => y;
        set => y = value;
    }

    public int Z
    {
        readonly get => z;
        set => z = value;
    }

    public int W
    {
        readonly get => w;
        set => w = value;
    }

    public int[] MoreAxes
    {
        readonly get => more_axes;
        set => more_axes = value;
    }

    public int Buttons
    {
        readonly get => buttons;
        set => buttons = value;
    }

    public float Pressure
    {
        readonly get => pressure;
        set => pressure = value;
    }

    public AllegroDisplay? Display
    {
        readonly get => NativePointer.Create<AllegroDisplay>(display);
        set => display = value?.Pointer ?? IntPtr.Zero;
    }

    private const int MaxExtraAxes = 4;

    private int x;
    private int y;
    private int z;
    private int w;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = MaxExtraAxes)] private int[] more_axes;
    private int buttons;
    private float pressure;
    private IntPtr display;

    public AllegroMouseState()
    {
        x = 0;
        y = 0;
        z = 0;
        w = 0;
        more_axes = new int[MaxExtraAxes];
        buttons = 0;
        pressure = 0f;
        display = IntPtr.Zero;
    }
}
