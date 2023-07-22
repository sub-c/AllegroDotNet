using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native.Structs;

/// <summary>
/// This structure holds the data for Allegro events.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct AllegroEvent
{
  [FieldOffset(0)]
  internal uint type;

  [FieldOffset(0)]
  internal AllegroEventHeader any;

  [FieldOffset(0)]
  internal AllegroDisplayEvent display;

  [FieldOffset(0)]
  internal AllegroJoystickEvent joystick;

  [FieldOffset(0)]
  internal AllegroKeyboardEvent keyboard;

  [FieldOffset(0)]
  internal AllegroMouseEvent mouse;

  [FieldOffset(0)]
  internal AllegroTimerEvent timer;

  [FieldOffset(0)]
  internal AllegroTouchEvent touch;

  [FieldOffset(0)]
  internal AllegroUserEvent user;
}

[StructLayout(LayoutKind.Sequential)]
internal struct AllegroEventHeader
{
  public uint type;
  public IntPtr source;
  public double timestamp;
}

[StructLayout(LayoutKind.Sequential)]
internal struct AllegroDisplayEvent
{
  public AllegroEventHeader header;
  public int x;
  public int y;
  public int width;
  public int height;
  public int orientation;
}

[StructLayout(LayoutKind.Sequential)]
internal struct AllegroJoystickEvent
{
  public AllegroEventHeader header;
  public IntPtr id;
  public int stick;
  public int axis;
  public float pos;
  public int button;
}

[StructLayout(LayoutKind.Sequential)]
internal struct AllegroKeyboardEvent
{
  public AllegroEventHeader header;
  public IntPtr display;
  public int keycode;
  public int unichar;
  public uint modifiers;
  public byte repeat;
}

[StructLayout(LayoutKind.Sequential)]
internal struct AllegroMouseEvent
{
  public AllegroEventHeader header;
  public IntPtr display;
  public int x;
  public int y;
  public int z;
  public int w;
  public int dx;
  public int dy;
  public int dz;
  public int dw;
  public uint button;
  public float pressure;
}

[StructLayout(LayoutKind.Sequential)]
internal struct AllegroTimerEvent
{
  public AllegroEventHeader header;
  public long count;
  public double error;
}

[StructLayout(LayoutKind.Sequential)]
internal struct AllegroTouchEvent
{
  public AllegroEventHeader header;
  public IntPtr display;
  public int id;
  public float x;
  public float y;
  public float dx;
  public float dy;
  public byte primary;
}

[StructLayout(LayoutKind.Sequential)]
internal struct AllegroUserEvent
{
  public AllegroEventHeader header;
  public IntPtr __internal_descr;
  public IntPtr data1;
  public IntPtr data2;
  public IntPtr data3;
  public IntPtr data4;
}