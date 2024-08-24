using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models;

/// <summary>
/// An opaque structure representing the state of Allegro.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct AllegroState
{
    private const int InternalTlsArraySize = 1024;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = InternalTlsArraySize)]
    private byte[] _tls = new byte[InternalTlsArraySize];

    public AllegroState()
    {
    }
}
