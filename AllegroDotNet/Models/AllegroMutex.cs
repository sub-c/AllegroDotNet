using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// An opaque structure representing a mutex.
    /// </summary>
    public sealed class AllegroMutex : NativePointerWrapper, IEquatable<AllegroMutex>
    {
        internal AllegroMutex()
        {
        }

        /// <summary>
        /// Determines if two <see cref="AllegroMutex"/> native pointers are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the native pointers are equal, otherwise false.</returns>
        public bool Equals(AllegroMutex other)
        {
            return NativeIntPtr == other?.NativeIntPtr;
        }
    }
}
