using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
  public static AllegroFile? OpenMemfile(IntPtr memory, long size, string mode)
  {
    using var nativeMode = new CStringAnsi(mode);
    var pointer = Interop.Memfile.AlOpenMemfile(memory, size, nativeMode.Pointer);
    return NativePointer.Create<AllegroFile>(pointer);
  }

  public static uint GetAllegroMemfileVersion()
  {
    return Interop.Memfile.AlGetAllegroMemfileVersion();
  }
}
