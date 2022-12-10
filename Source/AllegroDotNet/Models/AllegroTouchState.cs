using System;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models
{
  public sealed class AllegroTouchState
  {
    public int ID
    {
      get => NativeTouchState.id;
      set => NativeTouchState.id = value;
    }

    public float X
    {
      get => NativeTouchState.x;
      set => NativeTouchState.x = value;
    }

    public float Y
    {
      get => NativeTouchState.y;
      set => NativeTouchState.y = value;
    }

    public float DX
    {
      get => NativeTouchState.dx;
      set => NativeTouchState.dx = value;
    }

    public float DY
    {
      get => NativeTouchState.dy;
      set => NativeTouchState.dy = value;
    }

    public bool Primary
    {
      get => NativeTouchState.primary;
      set => NativeTouchState.primary = value;
    }

    public AllegroDisplay? Display
    {
      get => new() { NativePointer = NativeTouchState.display };
      set => NativeTouchState.display = value?.NativePointer ?? IntPtr.Zero;
    }

    internal NativeAllegroTouchState NativeTouchState = new();

    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeAllegroTouchState
    {
      public int id;
      public float x, y;
      public float dx, dy;
      public bool primary;
      public IntPtr display;
    }
  }
}
