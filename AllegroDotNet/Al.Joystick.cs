using System;
using System.Runtime.InteropServices;
using AllegroDotNet.Native;

namespace AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
        #region P/Invokes
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern bool al_install_joystick();

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_uninstall_joystick();

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern bool al_is_joystick_installed();

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern bool al_reconfigure_joysticks();

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern int al_get_num_joysticks();

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_get_joystick(int num);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_release_joystick(IntPtr joy);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern bool al_get_joystick_active(IntPtr joy);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_get_joystick_name(IntPtr joy);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_get_joystick_stick_name(IntPtr joy, int stick);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_get_joystick_axis_name(IntPtr joy, int stick, int axis);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_get_joystick_button_name(IntPtr joy, int button);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern int al_get_joystick_stick_flags(IntPtr joy, int stick);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern int al_get_joystick_num_sticks(IntPtr joy);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern int al_get_joystick_num_axes(IntPtr joy, int stick);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern int al_get_joystick_num_buttons(IntPtr joy);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_get_joystick_state(IntPtr joy, ref NativeJoystickState retState);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_get_joystick_event_source();
        #endregion
    }
}
