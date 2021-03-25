using System.Runtime.InteropServices;

namespace AllegroDotNet.Models
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeAllegroColor
    {
        float r, g, b, a;
    }
}
