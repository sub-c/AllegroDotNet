namespace AllegroDotNet.Models
{
    public sealed class AllegroEvent_All
    {
        public AllegroEventSource Source => new AllegroEventSource { NativeIntPtr = _allegroEvent.NativeEvent.any.header.source };
        public double Timestamp => _allegroEvent.NativeEvent.any.header.timestamp;

        private readonly AllegroEvent _allegroEvent = null;

        internal AllegroEvent_All(AllegroEvent allegroEvent)
        {
            _allegroEvent = allegroEvent;
        }
    }
}
