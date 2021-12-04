using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// An opaque structure representing a condition variable.
    /// </summary>
    public sealed class AllegroCond : NativePointerWrapper, IEquatable<AllegroCond>
    {
        internal AllegroCond()
        {
        }

        /// <summary>
        /// Determines if two <see cref="AllegroCond"/> native pointers are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the native pointers are equal, otherwise false.</returns>
        public bool Equals(AllegroCond other)
        {
            return NativeIntPtr == other?.NativeIntPtr;
        }
    }
}
