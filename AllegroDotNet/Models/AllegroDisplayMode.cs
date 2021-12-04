using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// Used for fullscreen mode queries. Contains information about a supported fullscreen modes. The refresh_rate
    /// may be zero if unknown. For an explanation of what format means, see ALLEGRO_PIXEL_FORMAT.
    /// </summary>
    public sealed class AllegroDisplayMode : IEquatable<AllegroDisplayMode>
    {
        internal NativeDisplayMode Native = new NativeDisplayMode();

        /// <summary>
        /// Determines if two <see cref="AllegroDisplayMode"/> are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the display modes are equal, otherwise false.</returns>
        public bool Equals(AllegroDisplayMode other)
        {
            return Native.format == other?.Native.format
                && Native.height == other?.Native.height
                && Native.refresh_rate == other?.Native.refresh_rate
                && Native.width == other?.Native.width;
        }
    }
}
