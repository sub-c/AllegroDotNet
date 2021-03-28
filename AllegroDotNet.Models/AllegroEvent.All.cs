namespace AllegroDotNet.Models
{
    public sealed class AllegroEvent_All
    {
        public AllegroEventSource Source => new AllegroEventSource(_allegroEvent.NativeEvent.any.header.source);
        public double Timestamp => _allegroEvent.NativeEvent.any.header.timestamp;

        private readonly AllegroEvent _allegroEvent = null;

        public AllegroEvent_All(AllegroEvent allegroEvent)
        {
            _allegroEvent = allegroEvent;
        }
    }
}
