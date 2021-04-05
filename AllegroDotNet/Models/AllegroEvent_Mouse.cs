namespace AllegroDotNet.Models
{
    public sealed class AllegroEvent_Mouse
    {
        public uint Button => _allegroEvent.NativeEvent.mouse.button;
        public int DW => _allegroEvent.NativeEvent.mouse.dw;
        public int DX => _allegroEvent.NativeEvent.mouse.dx;
        public int DY => _allegroEvent.NativeEvent.mouse.dy;
        public int DZ => _allegroEvent.NativeEvent.mouse.dz;
        public float Pressure => _allegroEvent.NativeEvent.mouse.pressure;
        public int W => _allegroEvent.NativeEvent.mouse.w;
        public int X => _allegroEvent.NativeEvent.mouse.x;
        public int Y => _allegroEvent.NativeEvent.mouse.y;
        public int Z => _allegroEvent.NativeEvent.mouse.z;

        private readonly AllegroEvent _allegroEvent;

        internal AllegroEvent_Mouse(AllegroEvent allegroEvent)
        {
            _allegroEvent = allegroEvent;
        }
    }
}
