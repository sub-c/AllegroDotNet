using SubC.AllegroDotNet.Enums;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models;

/// <summary>
/// This structure holds the state of an event in Allegro.
/// </summary>
[DebuggerDisplay("Type = {Type}")]
[StructLayout(LayoutKind.Explicit)]
public struct AllegroEvent
{
  public EventType Type
  {
    readonly get => (EventType)header.type;
    set => header.type = (int)value;
  }

  public AllegroEventSource? Source
  {
    readonly get => NativePointer.Create<AllegroEventSource>(header.source);
    set => header.source = NativePointer.Get(value);
  }

  public double Timestamp
  {
    readonly get => header.timestamp;
    set => header.timestamp = value;
  }

  public AllegroAnyEvent Any
  {
    readonly get => any;
    set => any = value;
  }

  public AllegroDisplayEvent Display
  {
    readonly get => display;
    set => display = value;
  }

  public AllegroJoystickEvent Joystick
  {
    readonly get => joystick;
    set => joystick = value;
  }

  public AllegroKeyboardEvent Keyboard
  {
    readonly get => keyboard;
    set => keyboard = value;
  }

  public AllegroMouseEvent Mouse
  {
    readonly get => mouse;
    set => mouse = value;
  }

  public AllegroTimerEvent Timer
  {
    readonly get => timer;
    set => timer = value;
  }

  public AllegroTouchEvent Touch
  {
    readonly get => touch;
    set => touch = value;
  }

  public AllegroUserEvent User
  {
    readonly get => user;
    set => user = value;
  }

  [FieldOffset(0)] private NativeEventHeader header;
  [FieldOffset(0)] private AllegroAnyEvent any;
  [FieldOffset(0)] private AllegroDisplayEvent display;
  [FieldOffset(0)] private AllegroJoystickEvent joystick;
  [FieldOffset(0)] private AllegroKeyboardEvent keyboard;
  [FieldOffset(0)] private AllegroMouseEvent mouse;
  [FieldOffset(0)] private AllegroTimerEvent timer;
  [FieldOffset(0)] private AllegroTouchEvent touch;
  [FieldOffset(0)] private AllegroUserEvent user;
}

[StructLayout(LayoutKind.Sequential)]
public struct NativeEventHeader
{
  public int type;
  public IntPtr source;
  public double timestamp;
}

[StructLayout(LayoutKind.Sequential)]
public struct AllegroUserEvent
{
  public IntPtr Data1
  {
    readonly get => data1;
    set => data1 = value;
  }

  public IntPtr Data2
  {
    readonly get => data2;
    set => data2 = value;
  }

  public IntPtr Data3
  {
    readonly get => data3;
    set => data3 = value;
  }

  public IntPtr Data4
  {
    readonly get => data4;
    set => data4 = value;
  }

  private NativeEventHeader header;
  private IntPtr __internal__descr;
  private IntPtr data1;
  private IntPtr data2;
  private IntPtr data3;
  private IntPtr data4;
}

[StructLayout(LayoutKind.Sequential)]
public struct AllegroAnyEvent
{
  public EventType Type
  {
    readonly get => (EventType)header.type;
    set => header.type = (int)value;
  }

  public AllegroEventSource? Source
  {
    readonly get => NativePointer.Create<AllegroEventSource>(header.source);
    set => header.source = NativePointer.Get(value);
  }

  public double Timestamp
  {
    readonly get => header.timestamp;
    set => header.timestamp = value;
  }

  private NativeEventHeader header;
}

[StructLayout(LayoutKind.Sequential)]
public struct AllegroDisplayEvent
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

  public int Width
  {
    readonly get => width;
    set => width = value;
  }

  public int Height
  {
    readonly get => height;
    set => height = value;
  }

  public DisplayOrientation Orientation
  {
    readonly get => (DisplayOrientation)orientation;
    set => orientation = (int)value;
  }

  private NativeEventHeader header;
  private int x;
  private int y;
  private int width;
  private int height;
  private int orientation;
}

[StructLayout(LayoutKind.Sequential)]
public struct AllegroJoystickEvent
{
  public AllegroJoystick? ID
  {
    readonly get => NativePointer.Create<AllegroJoystick>(id);
    set => id = NativePointer.Get(value);
  }

  public int Stick
  {
    readonly get => stick;
    set => stick = value;
  }

  public int Axis
  {
    readonly get => axis;
    set => axis = value;
  }

  public float Pos
  {
    readonly get => pos;
    set => pos = value;
  }

  public int Button
  {
    readonly get => button;
    set => button = value;
  }

  private NativeEventHeader header;
  private IntPtr id;
  private int stick;
  private int axis;
  private float pos;
  private int button;
}

[StructLayout(LayoutKind.Sequential)]
public struct AllegroKeyboardEvent
{
  public AllegroDisplay? Display
  {
    readonly get => NativePointer.Create<AllegroDisplay>(display);
    set => display = NativePointer.Get(value);
  }

  public KeyCode KeyCode
  {
    readonly get => (KeyCode)keycode;
    set => keycode = (int)value;
  }

  public int Unichar
  {
    readonly get => unichar;
    set => unichar = value;
  }

  public uint Modifiers
  {
    readonly get => modifiers;
    set => modifiers = value;
  }

  public bool Repeat
  {
    readonly get => repeat != 0;
    set => repeat = (byte)(value ? 1 : 0);
  }

  private NativeEventHeader header;
  private IntPtr display;
  private int keycode;
  private int unichar;
  private uint modifiers;
  private byte repeat;
}

[StructLayout(LayoutKind.Sequential)]
public struct AllegroMouseEvent
{
  public AllegroDisplay? Display
  {
    readonly get => NativePointer.Create<AllegroDisplay>(display);
    set => display = NativePointer.Get(value);
  }

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

  public int DX
  {
    readonly get => dx;
    set => dx = value;
  }

  public int DY
  {
    readonly get => dy;
    set => dy = value;
  }

  public int DZ
  {
    readonly get => dz;
    set => dz = value;
  }

  public int DW
  {
    readonly get => dw;
    set => dw = value;
  }

  public uint Button
  {
    readonly get => button;
    set => button = value;
  }

  public float Pressure
  {
    readonly get => pressure;
    set => pressure = value;
  }

  private NativeEventHeader header;
  private IntPtr display;
  private int x;
  private int y;
  private int z;
  private int w;
  private int dx;
  private int dy;
  private int dz;
  private int dw;
  private uint button;
  private float pressure;
}

[StructLayout(LayoutKind.Sequential)]
public struct AllegroTimerEvent
{
  public long Count
  {
    readonly get => count;
    set => count = value;
  }

  public double Error
  {
    readonly get => error;
    set => error = value;
  }

  private NativeEventHeader header;
  private long count;
  private double error;
}

[StructLayout(LayoutKind.Sequential)]
public struct AllegroTouchEvent
{
  public AllegroDisplay? Display
  {
    readonly get => NativePointer.Create<AllegroDisplay>(display);
    set => display = NativePointer.Get(value);
  }

  public int TouchID
  {
    readonly get => id;
    set => id = value;
  }

  public float TouchX
  {
    readonly get => x;
    set => x = value;
  }

  public float TouchY
  {
    get => y;
    set => y = value;
  }

  public float TouchDX
  {
    get => dx;
    set => dx = value;
  }

  public float TouchDY
  {
    get => dy;
    set => dy = value;
  }

  public bool TouchPrimary
  {
    get => primary != 0;
    set => primary = (byte)(value ? 1 : 0);
  }

  private NativeEventHeader header;
  private IntPtr display;
  private int id;
  private float x;
  private float y;
  private float dx;
  private float dy;
  private byte primary;
}
