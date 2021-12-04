using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// An opaque path, representing a drive with one or more directory components.
    /// </summary>
    public sealed class AllegroPath : NativePointerWrapper, IEquatable<AllegroPath>
    {
        internal AllegroPath()
        {
        }

        /// <summary>
        /// Determines if two <see cref="AllegroPath"/> native pointers are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the native pointers are equal, otherwise false.</returns>
        public bool Equals(AllegroPath other)
        {
            return NativeIntPtr == other?.NativeIntPtr;
        }
    }
}
