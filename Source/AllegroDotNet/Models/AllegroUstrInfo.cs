using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models;

/// <summary>
/// This struct is an opaque type that holds additional information about a <see cref="AllegroUstr"/> that
/// references an external memory buffer.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct AllegroUstrInfo
{
    private int mlen;
    private int slen;
    private IntPtr data;
}
