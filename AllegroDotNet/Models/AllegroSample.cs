using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// An ALLEGRO_SAMPLE object stores the data necessary for playing pre-defined digital audio. It holds a
    /// user-specified PCM data buffer and information about its format (data length, depth, frequency, channel
    /// configuration). You can have the same ALLEGRO_SAMPLE playing multiple times simultaneously.
    /// </summary>
    public sealed class AllegroSample : NativePointerWrapper, IEquatable<AllegroSample>
    {
        internal AllegroSample()
        {
        }

        /// <summary>
        /// Determines if two <see cref="AllegroSample"/> native pointers are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the native pointers are equal, otherwise false.</returns>
        public bool Equals(AllegroSample other)
        {
            return NativeIntPtr == other?.NativeIntPtr;
        }
    }
}
