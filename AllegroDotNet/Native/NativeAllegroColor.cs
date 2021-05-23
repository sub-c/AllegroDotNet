using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native
{
    [StructLayout(LayoutKind.Sequential, Pack = 16)]
    internal struct NativeAllegroColor
    {
        public float r, g, b, a;
    }
}
