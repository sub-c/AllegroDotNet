using System.Runtime.InteropServices;

namespace AllegroDotNet.Native
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeAllegroColor
    {
        public float r, g, b, a;
    }
}
