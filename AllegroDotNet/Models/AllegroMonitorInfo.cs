using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// Describes a monitor’s size and position relative to other monitors. x1, y1 will be 0, 0 on the primary display.
    /// Other monitors can have negative values if they are to the left or above the primary display. x2, y2 are the
    /// coordinates one beyond the bottom right pixel, so that x2-x1 gives the width and y2-y1 gives the height of the
    /// display.
    /// </summary>
    public sealed class AllegroMonitorInfo
    {
        internal NativeMonitorInfo Native = new NativeMonitorInfo();
    }
}
