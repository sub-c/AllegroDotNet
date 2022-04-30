using System;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models
{
  public sealed class AllegroMouseState
  {
    internal NativeMouseState MouseState = new();

    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeMouseState
    {
      public int x;
      public int y;
      public int z;
      public int w;

      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
      public int[] more_axes;

      public int buttons;
      public float pressure;
      public IntPtr display;
    }
  }
}