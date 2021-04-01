using System.Runtime.InteropServices;

namespace AllegroDotNet.Models.Native
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeAllegroColor
    {
        public float r, g, b, a;
    }
}
