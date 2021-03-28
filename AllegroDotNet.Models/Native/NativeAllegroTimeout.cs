using System.Runtime.InteropServices;

namespace AllegroDotNet.Models.Native
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeAllegroTimeout
    {
        ulong __pad1__;
        ulong __pad2__;
    }
}
