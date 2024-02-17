using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models;

[StructLayout(LayoutKind.Sequential)]
public struct AllegroVertex
{
  public AllegroColor Color
  {
    readonly get => color;
    set => color = value;
  }

  public float U
  {
    readonly get => u;
    set => u = value;
  }

  public float V
  {
    readonly get => v;
    set => v = value;
  }

  public float X
  {
    readonly get => x;
    set => x = value;
  }

  public float Y
  {
    readonly get => y;
    set => y = value;
  }

  public float Z
  {
    readonly get => z;
    set => z = value;
  }

  private float x;
  private float y;
  private float z;
  private float u;
  private float v;
  private AllegroColor color;
}
