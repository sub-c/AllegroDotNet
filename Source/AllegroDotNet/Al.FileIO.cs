using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet
{
  public static partial class Al
  {
    /// <summary>
    /// Close the given file, writing any buffered output data (if any).
    /// </summary>
    /// <param name="file">The file to close.</param>
    /// <returns>True on success, false on failure. errno is set to indicate the error.</returns>
    public static bool FClose(AllegroFile? file)
    {
      return NativeFunctions.AlFClose(NativePointerModel.GetPointer(file));
    }
  }
}
