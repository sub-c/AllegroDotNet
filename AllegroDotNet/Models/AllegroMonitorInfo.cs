using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// Describes a monitor’s size and position relative to other monitors. x1, y1 will be 0, 0 on the primary display.
    /// Other monitors can have negative values if they are to the left or above the primary display. x2, y2 are the
    /// coordinates one beyond the bottom right pixel, so that x2-x1 gives the width and y2-y1 gives the height of the
    /// display.
    /// </summary>
    public sealed class AllegroMonitorInfo : IEquatable<AllegroMonitorInfo>
    {
        internal NativeMonitorInfo Native = new NativeMonitorInfo();

        /// <summary>
        /// Determines if two <see cref="AllegroMonitorInfo"/> are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the monitor infos are equal, otherwise false.</returns>
        public bool Equals(AllegroMonitorInfo other)
        {
            return Native.x1 == other?.Native.x1
                && Native.x2 == other?.Native.x2
                && Native.y1 == other?.Native.y1
                && Native.y2 == other?.Native.y2;
        }
    }
}
