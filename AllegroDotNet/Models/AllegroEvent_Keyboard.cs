using AllegroDotNet.Enums;

namespace AllegroDotNet.Models
{
    public sealed class AllegroEvent_Keyboard
    {
        public KeyCode KeyCode => (KeyCode)_allegroEvent.NativeEvent.keyboard.keycode;
        public KeyMod Modifiers => (KeyMod)_allegroEvent.NativeEvent.keyboard.modifiers;
        public bool Repeat => _allegroEvent.NativeEvent.keyboard.repeat;
        public int Unichar => _allegroEvent.NativeEvent.keyboard.unichar;

        private readonly AllegroEvent _allegroEvent = null;

        internal AllegroEvent_Keyboard(AllegroEvent allegroEvent)
        {
            _allegroEvent = allegroEvent;
        }
    }
}
