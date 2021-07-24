namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// Event data common to all events.
    /// </summary>
    public sealed class AllegroEvent_All
    {
        /// <summary>
        /// Source that raised the event.
        /// </summary>
        public AllegroEventSource Source => new AllegroEventSource { NativeIntPtr = _allegroEvent.NativeEvent.any.header.source };

        /// <summary>
        /// The timestamp when the event was raised (<see cref="Al.GetTime"/>).
        /// </summary>
        public double Timestamp => _allegroEvent.NativeEvent.any.header.timestamp;

        private readonly AllegroEvent _allegroEvent = null;

        internal AllegroEvent_All(AllegroEvent allegroEvent)
        {
            _allegroEvent = allegroEvent;
        }
    }
}
