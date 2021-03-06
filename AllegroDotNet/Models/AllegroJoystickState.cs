﻿using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// This is a structure that is used to hold a “snapshot” of a joystick’s axes and buttons at a particular
    /// instant. All fields public and read-only.
    /// </summary>
    public sealed class AllegroJoystickState
    {
        /// <summary>
        /// State of the joystick buttons.
        /// </summary>
        public int[] Button => Native.button;

        internal NativeJoystickState Native = new NativeJoystickState(initialize: true);
    }
}
