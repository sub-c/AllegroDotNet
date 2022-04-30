using System;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models
{
  public sealed class AllegroKeyboardState
  {
    public AllegroDisplay Display
    {
      get
      {
        DisplayProxy.NativePointer = KeyboardState.display;
        return DisplayProxy;
      }
    }

    internal AllegroDisplay DisplayProxy = new();
    internal NativeKeyboardState KeyboardState;

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct NativeKeyboardState
    {
      public IntPtr display;
      public uint __key_down__internal__1;
      public uint __key_down__internal__2;
      public uint __key_down__internal__3;
      public uint __key_down__internal__4;
      public uint __key_down__internal__5;
      public uint __key_down__internal__6;
      public uint __key_down__internal__7;
      public uint __key_down__internal__8;
    }
  }
}