namespace AllegroDotNet.Models
{
    public sealed class AllegroEvent_Joystick
    {
        public int Axis => _allegroEvent.NativeEvent.joystick.axis;
        public int Button => _allegroEvent.NativeEvent.joystick.button;
        public AllegroJoystick ID => new AllegroJoystick(_allegroEvent.NativeEvent.joystick.id);
        public float Pos => _allegroEvent.NativeEvent.joystick.pos;
        public int Stick => _allegroEvent.NativeEvent.joystick.stick;

        private readonly AllegroEvent _allegroEvent = null;

        internal AllegroEvent_Joystick(AllegroEvent allegroEvent)
        {
            _allegroEvent = allegroEvent;
        }
    }
}
