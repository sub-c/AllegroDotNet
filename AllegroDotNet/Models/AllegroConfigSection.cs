using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// An opaque structure used for iterating across sections in a configuration structure.
    /// </summary>
    public sealed class AllegroConfigSection : NativePointerWrapper, IEquatable<AllegroConfigSection>
    {
        internal AllegroConfigSection()
        {
        }

        /// <summary>
        /// Determines if two <see cref="AllegroConfigSection"/> native pointers are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the native pointers are equal, otherwise false.</returns>
        public bool Equals(AllegroConfigSection other)
        {
            return NativeIntPtr == other?.NativeIntPtr;
        }
    }
}
