using SubC.AllegroDotNet.Enums;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models;

[StructLayout(LayoutKind.Sequential)]
public struct AllegroKeyboardState
{
  public AllegroDisplay? Display
  {
    readonly get => NativePointer.Create<AllegroDisplay>(display);
    set => display = value?.Pointer ?? IntPtr.Zero;
  }

  private const int InternalKeyDownArraySize = ((int)KeyCode.KeyMax + 31) / 32;

  private IntPtr display = IntPtr.Zero;

  [MarshalAs(UnmanagedType.ByValArray, SizeConst = InternalKeyDownArraySize)]
  private uint[] __key_down__internal__ = new uint[InternalKeyDownArraySize];

  public AllegroKeyboardState()
  {
  }
}
