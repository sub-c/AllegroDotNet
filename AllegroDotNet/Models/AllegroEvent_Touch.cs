namespace SubC.AllegroDotNet.Models
{
    public sealed class AllegroEvent_Touch
    {
        public int ID => _allegroEvent.NativeEvent.touch.id;
        public float DX => _allegroEvent.NativeEvent.touch.dx;
        public float DY => _allegroEvent.NativeEvent.touch.dy;
        public bool Primary => _allegroEvent.NativeEvent.touch.primary;
        public float X => _allegroEvent.NativeEvent.touch.x;
        public float Y => _allegroEvent.NativeEvent.touch.y;

        private readonly AllegroEvent _allegroEvent = null;

        internal AllegroEvent_Touch(AllegroEvent allegroEvent)
        {
            _allegroEvent = allegroEvent;
        }
    }
}
