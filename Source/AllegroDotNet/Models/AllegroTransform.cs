using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models;

/// <summary>
/// This structure holds the matrix for a transform operation.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct AllegroTransform
{
  public float[,] M
  {
    readonly get => m;
    set => m = value;
  }

  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
  private float[,] m = new float[4,4];

  public AllegroTransform()
  {
  }
}
