using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeMonitorInfo
    {
        public int x1;
        public int y1;
        public int x2;
        public int y2;
    }
}
