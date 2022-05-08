using SubC.AllegroDotNet.Enums;
using System;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models
{
  public sealed class AllegroEvent
  {
    #region Keyboard

    public KeyCode KeyCode
    {
      get => (KeyCode)NativeEvent.keyboard.keycode;
      set => NativeEvent.keyboard.keycode = (int)value;
    }

    public int UniChar
    {
      get => NativeEvent.keyboard.unichar;
      set => NativeEvent.keyboard.keycode = value;
    }

    public uint Modifiers
    {
      get => NativeEvent.keyboard.modifiers;
      set => NativeEvent.keyboard.modifiers = value;
    }

    public bool Repeat
    {
      get => NativeEvent.keyboard.repeat;
      set => NativeEvent.keyboard.repeat = value;
    }

    #endregion Keyboard

    #region Mouse

    public int MouseX
    {
      get => NativeEvent.mouse.x;
      set => NativeEvent.mouse.x = value;
    }

    public int MouseY
    {
      get => NativeEvent.mouse.y;
      set => NativeEvent.mouse.y = value;
    }

    public int MouseZ
    {
      get => NativeEvent.mouse.z;
      set => NativeEvent.mouse.z = value;
    }

    public int MouseW
    {
      get => NativeEvent.mouse.w;
      set => NativeEvent.mouse.w = value;
    }

    public int MouseDX
    {
      get => NativeEvent.mouse.dx;
      set => NativeEvent.mouse.dx = value;
    }

    public int MouseDY
    {
      get => NativeEvent.mouse.dy;
      set => NativeEvent.mouse.dy = value;
    }

    public int MouseDZ
    {
      get => NativeEvent.mouse.dz;
      set => NativeEvent.mouse.dz = value;
    }

    public int MouseDW
    {
      get => NativeEvent.mouse.dw;
      set => NativeEvent.mouse.dw = value;
    }

    public uint MouseButton
    {
      get => NativeEvent.mouse.button;
      set => NativeEvent.mouse.button = value;
    }

    public float MousePressure
    {
      get => NativeEvent.mouse.pressure;
      set => NativeEvent.mouse.pressure = value;
    }

    #endregion

    #region User

    public IntPtr UserData1
    {
      get => NativeEvent.user.data1;
      set => NativeEvent.user.data1 = value;
    }

    public IntPtr UserData2
    {
      get => NativeEvent.user.data2;
      set => NativeEvent.user.data2 = value;
    }

    public IntPtr UserData3
    {
      get => NativeEvent.user.data3;
      set => NativeEvent.user.data3 = value;
    }

    public IntPtr UserData4
    {
      get => NativeEvent.user.data4;
      set => NativeEvent.user.data4 = value;
    }

    #endregion

    public EventType Type
    {
      get => (EventType)NativeEvent.type;
      set => NativeEvent.type = (uint)value;
    }

    internal NativeAllegroEvent NativeEvent;

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct NativeAllegroDisplayEvent
    {
      public NativeAllegroEventHeader header;
      public int x;
      public int y;
      public int width;
      public int height;
      public int orientation;
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    internal struct NativeAllegroEvent
    {
      [FieldOffset(0)]
      public uint type;

      [FieldOffset(0)]
      public NativeAllegroEventHeader any;

      [FieldOffset(0)]
      public NativeAllegroDisplayEvent display;

      [FieldOffset(0)]
      public NativeAllegroJoystickEvent joystick;

      [FieldOffset(0)]
      public NativeAllegroKeyboardEvent keyboard;

      [FieldOffset(0)]
      public NativeAllegroMouseEvent mouse;

      [FieldOffset(0)]
      public NativeAllegroTimerEvent timer;

      [FieldOffset(0)]
      public NativeAllegroTouchEvent touch;

      [FieldOffset(0)]
      public NativeAllegroUserEvent user;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NativeAllegroEventHeader
    {
      public uint type;
      public IntPtr source;
      public double timestamp;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct NativeAllegroJoystickEvent
    {
      public NativeAllegroEventHeader header;
      public IntPtr id;
      public int stick;
      public int axis;
      public float pos;
      public int button;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct NativeAllegroKeyboardEvent
    {
      public NativeAllegroEventHeader header;
      public IntPtr display;
      public int keycode;
      public int unichar;
      public uint modifiers;
      public bool repeat;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct NativeAllegroMouseEvent
    {
      public NativeAllegroEventHeader header;
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

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct NativeAllegroTimerEvent
    {
      public NativeAllegroEventHeader header;
      public long count;
      public double error;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct NativeAllegroTouchEvent
    {
      public NativeAllegroEventHeader header;
      public IntPtr display;
      public int id;
      public float x;
      public float y;
      public float dx;
      public float dy;
      public bool primary;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NativeAllegroUserEvent
    {
      public NativeAllegroEventHeader header;
      public IntPtr __internal_descr;
      public uint __shove_over;
      public IntPtr data1;
      public IntPtr data2;
      public IntPtr data3;
      public IntPtr data4;
    }
  }
}