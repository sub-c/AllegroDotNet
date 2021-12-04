using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// This is an abstract data type representing a timer object.
    /// </summary>
    public sealed class AllegroTimer : NativePointerWrapper, IEquatable<AllegroTimer>
    {
        internal AllegroTimer()
        {
        }

        /// <summary>
        /// Determines if two <see cref="AllegroTimer"/> native pointers are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the native pointers are equal, otherwise false.</returns>
        public bool Equals(AllegroTimer other)
        {
            return NativeIntPtr == other?.NativeIntPtr;
        }
    }
}
