using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// Represent an opaque timeout value.
    /// </summary>
    public sealed class AllegroTimeout : IEquatable<AllegroTimeout>
    {
        internal NativeAllegroTimeout NativeTimeout = new NativeAllegroTimeout();

        /// <summary>
        /// Determines if two <see cref="AllegroTimeout"/> are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the timeouts are equal, otherwise false.</returns>
        public bool Equals(AllegroTimeout other)
        {
            return NativeTimeout.__pad1__ == other?.NativeTimeout.__pad1__
                && NativeTimeout.__pad2__ == other?.NativeTimeout.__pad2__;
        }
    }
}
