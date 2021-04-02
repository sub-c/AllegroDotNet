using AllegroDotNet.Models.Native;

namespace AllegroDotNet.Models
{
    /// <summary>
    /// Users who wish to manually edit or read from a bitmap are required to lock it first. The ALLEGRO_LOCKED_REGION
    /// structure represents the locked region of the bitmap. This call will work with any bitmap, including memory
    /// bitmaps.
    /// </summary>
    public sealed class AllegroLockedRegion
    {
        internal NativeLockedRegion Native = new NativeLockedRegion();

        internal AllegroLockedRegion()
        {
        }
    }
}
