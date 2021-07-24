namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// This class holds the touch event data.
    /// </summary>
    public sealed class AllegroEvent_Touch
    {
        /// <summary>
        /// An identifier for this touch. If supported by the device it will stay the same for events from the
        /// same finger until the touch ends. 
        /// </summary>
        public int ID => _allegroEvent.NativeEvent.touch.id;

        /// <summary>
        /// Movement speed in pixels in x direction. 
        /// </summary>
        public float DX => _allegroEvent.NativeEvent.touch.dx;

        /// <summary>
        /// Movement speed in pixels in y direction. 
        /// </summary>
        public float DY => _allegroEvent.NativeEvent.touch.dy;

        /// <summary>
        /// Whether this is the only/first touch or an additional touch. 
        /// </summary>
        public bool Primary => _allegroEvent.NativeEvent.touch.primary;

        /// <summary>
        /// The x coordinate of the touch in pixels. 
        /// </summary>
        public float X => _allegroEvent.NativeEvent.touch.x;

        /// <summary>
        /// The y coordinate of the touch in pixels. 
        /// </summary>
        public float Y => _allegroEvent.NativeEvent.touch.y;

        private readonly AllegroEvent _allegroEvent = null;

        internal AllegroEvent_Touch(AllegroEvent allegroEvent)
        {
            _allegroEvent = allegroEvent;
        }
    }
}
