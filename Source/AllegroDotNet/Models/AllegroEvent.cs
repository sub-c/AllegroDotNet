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

    [StructLayout(LayoutKind.Sequential)]
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
      public IntPtr data1;
      public IntPtr data2;
      public IntPtr data3;
      public IntPtr data4;
    }
  }
}