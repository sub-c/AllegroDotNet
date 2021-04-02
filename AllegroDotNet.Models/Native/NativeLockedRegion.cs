using System;
using System.Runtime.InteropServices;

namespace AllegroDotNet.Models.Native
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeLockedRegion
    {
        IntPtr data;
        int format;
        int pitch;
        int pixel_size;
    }
}
