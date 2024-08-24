using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native;

internal sealed class CStringAnsi : IDisposable
{
    public IntPtr Pointer { get; }

    public CStringAnsi(string? csString)
    {
        Pointer = csString is null
          ? IntPtr.Zero
          : Marshal.StringToHGlobalAnsi(csString);
    }

    public void Dispose()
    {
        if (Pointer != IntPtr.Zero)
            Marshal.FreeHGlobal(Pointer);
    }

    public static string? ToCSharpString(IntPtr cString)
    {
        return Marshal.PtrToStringAnsi(cString);
    }
}
