using System;
using System.Runtime.InteropServices;

namespace AllegroDotNet.Models.Native
{
    /// <summary>
    /// Users who wish to manually edit or read from a bitmap are required to lock it first. The ALLEGRO_LOCKED_REGION
    /// structure represents the locked region of the bitmap. This call will work with any bitmap, including memory
    /// bitmaps.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AllegroLockedRegion
    {
        IntPtr data;
        int format;
        int pitch;
        int pixel_size;
    }
}
