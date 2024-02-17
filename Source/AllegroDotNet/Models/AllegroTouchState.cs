using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models;

[StructLayout(LayoutKind.Sequential)]
public struct AllegroTouchState
{
  public int ID
  {
    readonly get => id;
    set => id = value;
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

  public float DX
  {
    readonly get => dx;
    set => dx = value;
  }

  public float DY
  {
    readonly get => dy;
    set => dy = value;
  }

  public bool Primary
  {
    readonly get => primary != 0;
    set => primary = (byte)(value ? 1 : 0);
  }

  public AllegroDisplay? Display
  {
    readonly get => NativePointer.Create<AllegroDisplay>(display);
    set => display = NativePointer.Get(value);
  }

  private int id;
  private float x;
  private float y;
  private float dx;
  private float dy;
  private byte primary;
  private IntPtr display;
}
