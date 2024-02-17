using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models;

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
