using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// An opaque structure representing a thread.
    /// </summary>
    public sealed class AllegroThread : NativePointerWrapper, IEquatable<AllegroThread>
    {
        internal AllegroThread()
        {
        }

        /// <summary>
        /// Determines if two <see cref="AllegroThread"/> native pointers are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the native pointers are equal, otherwise false.</returns>
        public bool Equals(AllegroThread other)
        {
            return NativeIntPtr == other?.NativeIntPtr;
        }
    }
}
