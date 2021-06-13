using SubC.AllegroDotNet.Enums;

namespace SubC.AllegroDotNet.Models
{
    public sealed class AllegroEvent_Display
    {
        public int Height => _allegroEvent.NativeEvent.display.height;
        public DisplayOrientation Orientation => (DisplayOrientation)_allegroEvent.NativeEvent.display.orientation;
        public int Width => _allegroEvent.NativeEvent.display.width;
        public int X => _allegroEvent.NativeEvent.display.x;
        public int Y => _allegroEvent.NativeEvent.display.y;

        private readonly AllegroEvent _allegroEvent = null;

        internal AllegroEvent_Display(AllegroEvent allegroEvent)
        {
            _allegroEvent = allegroEvent;
        }
    }
}
