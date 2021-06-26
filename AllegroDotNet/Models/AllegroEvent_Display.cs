using SubC.AllegroDotNet.Enums;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// The details of a display event.
    /// </summary>
    public sealed class AllegroEvent_Display
    {
        /// <summary>
        /// The height of the display.
        /// </summary>
        public int Height => _allegroEvent.NativeEvent.display.height;

        /// <summary>
        /// The display orientation.
        /// </summary>
        public DisplayOrientation Orientation => (DisplayOrientation)_allegroEvent.NativeEvent.display.orientation;

        /// <summary>
        /// The width of the display.
        /// </summary>
        public int Width => _allegroEvent.NativeEvent.display.width;

        /// <summary>
        /// The X position of the monitor, used to determine how monitors are positioned in multi-monitor setups.
        /// </summary>
        public int X => _allegroEvent.NativeEvent.display.x;

        /// <summary>
        /// The Y position of the monitor, used to determine how monitors are positioned in multi-monitor setups.
        /// </summary>
        public int Y => _allegroEvent.NativeEvent.display.y;

        private readonly AllegroEvent _allegroEvent = null;

        internal AllegroEvent_Display(AllegroEvent allegroEvent)
        {
            _allegroEvent = allegroEvent;
        }
    }
}
