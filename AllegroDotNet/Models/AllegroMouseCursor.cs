using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// An abstraction of a bitmap for using as a mouse cursor.
    /// </summary>
    public sealed class AllegroMouseCursor : NativePointerWrapper, IEquatable<AllegroMouseCursor>
    {
        internal AllegroMouseCursor()
        {
        }

        /// <summary>
        /// Determines if two <see cref="AllegroMouseCursor"/> native pointers are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the native pointers are equal, otherwise false.</returns>
        public bool Equals(AllegroMouseCursor other)
        {
            return NativeIntPtr == other?.NativeIntPtr;
        }
    }
}
