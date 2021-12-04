using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// Opaque handle to a text log window.
    /// </summary>
    public sealed class AllegroTextLog : NativePointerWrapper, IEquatable<AllegroTextLog>
    {
        internal AllegroTextLog()
        {
        }

        /// <summary>
        /// Determines if two <see cref="AllegroTextLog"/> native pointers are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the native pointers are equal, otherwise false.</returns>
        public bool Equals(AllegroTextLog other)
        {
            return NativeIntPtr == other?.NativeIntPtr;
        }
    }
}
