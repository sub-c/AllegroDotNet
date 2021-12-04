using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// An opaque type representing a string. ALLEGRO_USTRs normally contain UTF-8 encoded strings, but they may be
    /// used to hold any byte sequences, including NULs.
    /// </summary>
    public sealed class AllegroUStr : NativePointerWrapper, IEquatable<AllegroUStr>
    {
        internal AllegroUStr()
        {
        }


        /// <summary>
        /// Determines if two <see cref="AllegroUStr"/> native pointers are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the native pointers are equal, otherwise false.</returns>
        public bool Equals(AllegroUStr other)
        {
            return NativeIntPtr == other?.NativeIntPtr;
        }
    }
}
