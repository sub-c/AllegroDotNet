using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// This class contains the joystick event data.
    /// </summary>
    public sealed class AllegroEvent_Joystick
    {
        /// <summary>
        /// The axis number on the stick, counting from zero. 
        /// </summary>
        public int Axis => _allegroEvent.NativeEvent.joystick.axis;

        /// <summary>
        /// The button which was pressed, counting from zero. 
        /// </summary>
        public int Button => _allegroEvent.NativeEvent.joystick.button;

        /// <summary>
        /// The joystick which generated the event. 
        /// </summary>
        public AllegroJoystick ID
            => _allegroEvent.NativeEvent.joystick.id == IntPtr.Zero ? null : new AllegroJoystick { NativeIntPtr = _allegroEvent.NativeEvent.joystick.id };

        /// <summary>
        /// The axis position, from -1.0 to +1.0. 
        /// </summary>
        public float Pos => _allegroEvent.NativeEvent.joystick.pos;

        /// <summary>
        /// The stick number, counting from zero. Axes on a joystick are grouped into “sticks”. 
        /// </summary>
        public int Stick => _allegroEvent.NativeEvent.joystick.stick;

        private readonly AllegroEvent _allegroEvent = null;

        internal AllegroEvent_Joystick(AllegroEvent allegroEvent)
        {
            _allegroEvent = allegroEvent;
        }
    }
}
