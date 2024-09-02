using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models;

/// <summary>
/// This structure holds the matrix for a transform operation.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct AllegroTransform
{
    public float this[int row, int col]
    {
        readonly get => m[row * 4 + col];
        set => m[row * 4 + col] = value;
    }

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    private float[] m = new float[16];

    public AllegroTransform()
    {
    }
}
