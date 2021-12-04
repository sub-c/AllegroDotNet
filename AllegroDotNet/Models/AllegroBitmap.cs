using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// Abstract type representing a bitmap (2D image).
    /// </summary>
    public sealed class AllegroBitmap : NativePointerWrapper, IEquatable<AllegroBitmap>
    {
        internal AllegroBitmap()
        {
        }

        /// <summary>
        /// Determines if two <see cref="AllegroBitmap"/> native pointers are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the native pointers are equal, otherwise false.</returns>
        public bool Equals(AllegroBitmap other)
        {
            return NativeIntPtr == other?.NativeIntPtr;
        }
    }
}
