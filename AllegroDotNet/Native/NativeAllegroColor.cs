using System.Runtime.InteropServices;

namespace AllegroDotNet.Native
{
    [StructLayout(LayoutKind.Sequential, Pack = 16)]
    internal struct NativeAllegroColor
    {
        public float r, g, b, a;
    }
}
