using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// An abstract configuration structure.
    /// </summary>
    public sealed class AllegroConfig : NativePointerWrapper, IEquatable<AllegroConfig>
    {
        internal AllegroConfig()
        {
        }

        /// <summary>
        /// Determines if two <see cref="AllegroConfig"/> native pointers are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the native pointers are equal, otherwise false.</returns>
        public bool Equals(AllegroConfig other)
        {
            throw new NotImplementedException();
        }
    }
}
