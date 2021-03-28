using System.Runtime.InteropServices;

namespace AllegroDotNet.Models.Native
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeAllegroColor
    {
        float r, g, b, a;
    }
}
