using System;
using System.Runtime.InteropServices;

namespace AllegroDotNet.Native
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeEventHeader
    {
        public uint type;
        public IntPtr source;
        public double timestamp;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeAnyEvent
    {
        public NativeEventHeader header;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeDisplayEvent
    {
        public NativeEventHeader header;
        public int x, y;
        public int width, height;
        public int orientation;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeJoystickEvent
    {
        public NativeEventHeader header;
        public IntPtr id;
        public int stick;
        public int axis;
        public float pos;
        public int button;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeKeyboardEvent
    {
        public NativeEventHeader header;
        public IntPtr display;
        public int keycode;
        public int unichar;
        public uint modifiers;
        public bool repeat;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeMouseEvent
    {
        public NativeEventHeader header;
        public IntPtr display;
        public int x, y, z, w;
        public int dx, dy, dz, dw;
        public uint button;
        public float pressure;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeTimerEvent
    {
        public NativeEventHeader header;
        public long count;
        public double error;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeTouchEvent
    {
        public NativeEventHeader header;
        public int id;
        public float x, y;
        public float dx, dy;
        public bool primary;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeUserEvent
    {
        public NativeEventHeader header;
        public IntPtr __internal__descr;
        public IntPtr data1;
        public IntPtr data2;
        public IntPtr data3;
        public IntPtr data4;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct NativeAllegroEvent
    {
        [FieldOffset(0)]
        public uint type;

        [FieldOffset(0)]
        public NativeAnyEvent any;

        [FieldOffset(0)]
        public NativeDisplayEvent display;

        [FieldOffset(0)]
        public NativeJoystickEvent joystick;

        [FieldOffset(0)]
        public NativeKeyboardEvent keyboard;

        [FieldOffset(0)]
        public NativeMouseEvent mouse;

        [FieldOffset(0)]
        public NativeTimerEvent timer;

        [FieldOffset(0)]
        public NativeTouchEvent touch;

        [FieldOffset(0)]
        public NativeUserEvent user;
    }
}
