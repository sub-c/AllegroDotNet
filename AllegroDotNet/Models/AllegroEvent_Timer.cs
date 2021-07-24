namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// This class holds timer event data.
    /// </summary>
    public sealed class AllegroEvent_Timer
    {
        /// <summary>
        /// The timer count value.
        /// </summary>
        public long Count => _allegroEvent.NativeEvent.timer.count;

        /// <summary>
        /// ?
        /// </summary>
        public double Error => _allegroEvent.NativeEvent.timer.error;

        private readonly AllegroEvent _allegroEvent = null;

        internal AllegroEvent_Timer(AllegroEvent allegroEvent)
        {
            _allegroEvent = allegroEvent;
        }
    }
}
