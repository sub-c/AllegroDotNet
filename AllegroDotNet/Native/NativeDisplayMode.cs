using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeDisplayMode
    {
        public int width;
        public int height;
        public int format;
        public int refresh_rate;
    }
}
