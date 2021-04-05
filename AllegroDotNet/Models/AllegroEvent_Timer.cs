namespace AllegroDotNet.Models
{
    public sealed class AllegroEvent_Timer
    {
        public long Count => _allegroEvent.NativeEvent.timer.count;
        public double Error => _allegroEvent.NativeEvent.timer.error;

        private readonly AllegroEvent _allegroEvent = null;

        internal AllegroEvent_Timer(AllegroEvent allegroEvent)
        {
            _allegroEvent = allegroEvent;
        }
    }
}
