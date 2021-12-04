using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// An opaque type representing an open display or window.
    /// </summary>
    public sealed class AllegroDisplay : NativePointerWrapper, IEquatable<AllegroDisplay>
    {
        internal AllegroDisplay()
        {
        }

        /// <summary>
        /// Determines if two <see cref="AllegroDisplay"/> native pointers are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the native pointers are equal, otherwise false.</returns>
        public bool Equals(AllegroDisplay other)
        {
            return NativeIntPtr == other?.NativeIntPtr;
        }
    }
}
