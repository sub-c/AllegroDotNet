using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// An opaque structure used for iterating across entries in a configuration section.
    /// </summary>
    public sealed class AllegroConfigEntry : NativePointerWrapper, IEquatable<AllegroConfigEntry>
    {
        internal AllegroConfigEntry()
        {
        }

        /// <summary>
        /// Determines if two <see cref="AllegroConfigEntry"/> native pointers are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the native pointers are equal, otherwise false.</returns>
        public bool Equals(AllegroConfigEntry other)
        {
            throw new NotImplementedException();
        }
    }
}
