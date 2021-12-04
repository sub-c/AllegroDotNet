using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// An opaque object representing an open file. This could be a real file on disk or a virtual file.
    /// </summary>
    public sealed class AllegroFile : NativePointerWrapper, IEquatable<AllegroFile>
    {
        /// <summary>
        /// Determines if two <see cref="AllegroFile"/> native pointers are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the native pointers are equal, otherwise false.</returns>
        public bool Equals(AllegroFile other)
        {
            return NativeIntPtr == other?.NativeIntPtr;
        }
    }
}
