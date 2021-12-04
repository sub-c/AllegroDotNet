using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// Users who wish to manually edit or read from a bitmap are required to lock it first. The ALLEGRO_LOCKED_REGION
    /// structure represents the locked region of the bitmap. This call will work with any bitmap, including memory
    /// bitmaps.
    /// </summary>
    public sealed class AllegroLockedRegion : NativePointerWrapper, IEquatable<AllegroLockedRegion>
    {
        internal AllegroLockedRegion()
        {
        }

        /// <summary>
        /// Determines if two <see cref="AllegroLockedRegion"/> native pointers are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the native pointers are equal, otherwise false.</returns>
        public bool Equals(AllegroLockedRegion other)
        {
            return NativeIntPtr == other?.NativeIntPtr;
        }
    }
}
