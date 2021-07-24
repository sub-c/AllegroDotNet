using SubC.AllegroDotNet.Enums;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// This class contains keyboard event data.
    /// </summary>
    public sealed class AllegroEvent_Keyboard
    {
        /// <summary>
        /// The code corresponding to the physical key which was pressed.
        /// </summary>
        public KeyCode KeyCode => (KeyCode)_allegroEvent.NativeEvent.keyboard.keycode;

        /// <summary>
        /// This is a bitfield of the modifier keys which were pressed when the event occurred.
        /// See <see cref="KeyMod"/> for the constants. 
        /// </summary>
        public KeyMod Modifiers => (KeyMod)_allegroEvent.NativeEvent.keyboard.modifiers;

        /// <summary>
        /// Indicates if this is a repeated character. 
        /// </summary>
        public bool Repeat => _allegroEvent.NativeEvent.keyboard.repeat;

        /// <summary>
        /// A Unicode code point (character). This may be zero or negative if the event was generated for a non-visible
        /// “character”, such as an arrow or Function key. In that case you can act upon the keycode field.
        /// </summary>
        public int Unichar => _allegroEvent.NativeEvent.keyboard.unichar;

        private readonly AllegroEvent _allegroEvent = null;

        internal AllegroEvent_Keyboard(AllegroEvent allegroEvent)
        {
            _allegroEvent = allegroEvent;
        }
    }
}
