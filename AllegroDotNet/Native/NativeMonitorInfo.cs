using System.Runtime.InteropServices;

namespace AllegroDotNet.Native
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeMonitorInfo
    {
        int x1;
        int y1;
        int x2;
        int y2;
    }
}
