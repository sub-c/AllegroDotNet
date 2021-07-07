using System;
using System.Runtime.InteropServices;
using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using SubC.AllegroDotNet.Native.Libraries;

namespace SubC.AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
        /// <summary>
        /// Install a joystick driver, returning true if successful. If a joystick driver was already installed,
        /// returns true immediately.
        /// <para>
        /// On Windows there are two joystick drivers, a DirectInput one and an Xinput one. If support for XInput was
        /// compiled in, then it can be enabled by calling al_set_config_value(al_get_system_config(), “joystick”,
        /// “driver”, “xinput”) before calling al_install_joystick, or by setting the same option in the allegro5.cfg
        /// configuration file. The Xinput and DirectInput drivers are mutually exclusive. The haptics subsystem will
        /// use the same driver as the joystick system does.
        /// </para>
        /// </summary>
        /// <returns></returns>
        public static bool InstallJoystick() =>
            AllegroLibrary.AlInstallJoystick();

        /// <summary>
        /// Uninstalls the active joystick driver. All outstanding ALLEGRO_JOYSTICK structures are invalidated. If no
        /// joystick driver was active, this function does nothing. This function is automatically called when Allegro
        /// is shut down.
        /// </summary>
        public static void UninstallJoystick() =>
            AllegroLibrary.AlUninstallJoystick();

        /// <summary>
        /// Returns true if <see cref="InstallJoystick"/> was called successfully.
        /// </summary>
        /// <returns>True if <see cref="InstallJoystick"/> was called successfully.</returns>
        public static bool IsJoystickInstalled() =>
            AllegroLibrary.AlIsJoystickInstalled();

        /// <summary>
        /// Allegro is able to cope with users connecting and disconnected joystick devices on-the-fly. On existing
        /// platforms, the joystick event source will generate an event of type ALLEGRO_EVENT_JOYSTICK_CONFIGURATION
        /// when a device is plugged in or unplugged. In response, you should call al_reconfigure_joysticks.
        /// <para>
        /// Afterwards, the number returned by al_get_num_joysticks may be different, and the handles returned by
        /// al_get_joystick may be different or be ordered differently.
        /// </para>
        /// <para>
        /// All ALLEGRO_JOYSTICK handles remain valid, but handles for disconnected devices become inactive: their
        /// states will no longer update, and al_get_joystick will not return the handle. Handles for devices which
        /// remain connected will continue to represent the same devices. Previously inactive handles may become
        /// active again, being reused to represent newly connected devices.
        /// </para>
        /// <para>
        /// It is possible that on some systems, Allegro won’t be able to generate ALLEGRO_EVENT_JOYSTICK_CONFIGURATION
        /// events. If your game has an input configuration screen or similar, you may wish to call
        /// al_reconfigure_joysticks when entering that screen.
        /// </para>
        /// </summary>
        /// <returns>True if the joystick configuration changed, otherwise returns false.</returns>
        public static bool ReconfigureJoysticks() =>
            AllegroLibrary.AlReconfigureJoysticks();

        /// <summary>
        /// Return the number of joysticks currently on the system (or potentially on the system). This number can
        /// change after al_reconfigure_joysticks is called, in order to support hotplugging.
        /// </summary>
        /// <returns>
        /// 0 if there is no joystick driver installed, otherwise the number of joysticks currently on the system.
        /// </returns>
        public static int GetNumJoysticks() =>
            AllegroLibrary.AlGetNumJoysticks();

        /// <summary>
        /// Get a handle for a joystick on the system. The number may be from 0 to al_get_num_joysticks-1. If
        /// successful a pointer to a joystick object is returned, which represents a physical device.
        /// Otherwise NULL is returned.
        /// <para>
        /// The handle and the index are only incidentally linked. After al_reconfigure_joysticks is called,
        /// al_get_joystick may return handles in a different order, and handles which represent disconnected
        /// devices will not be returned.
        /// </para>
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static AllegroJoystick GetJoystick(int num)
        {
            var nativeJoystick = AllegroLibrary.AlGetJoystick(num);
            return nativeJoystick == IntPtr.Zero ? null : new AllegroJoystick { NativeIntPtr = nativeJoystick };
        }

        /// <summary>
        /// This function currently does nothing.
        /// </summary>
        /// <param name="joystick">The joystick to release.</param>
        public static void ReleaseJoystick(AllegroJoystick joystick) =>
            AllegroLibrary.AlReleaseJoystick(joystick.NativeIntPtr);

        /// <summary>
        /// Return if the joystick handle is “active”, i.e. in the current configuration, the handle represents
        /// some physical device plugged into the system. al_get_joystick returns active handles. After
        /// reconfiguration, active handles may become inactive, and vice versa.
        /// </summary>
        /// <param name="joystick">The joystick to check if active.</param>
        /// <returns>True if active, otherwise false.</returns>
        public static bool GetJoystickActive(AllegroJoystick joystick) =>
            AllegroLibrary.AlGetJoystickActive(joystick.NativeIntPtr);

        /// <summary>
        /// Return the name of the given joystick.
        /// </summary>
        /// <param name="joystick">The joystick.</param>
        /// <returns>The name of the joystick.</returns>
        public static string GetJoystickName(AllegroJoystick joystick)
        {
            var nativeString = AllegroLibrary.AlGetJoystickName(joystick.NativeIntPtr);
            return nativeString == IntPtr.Zero ? string.Empty : Marshal.PtrToStringAnsi(nativeString);
        }

        /// <summary>
        /// Return the name of the given “stick”. If the stick doesn’t exist, NULL is returned.
        /// </summary>
        /// <param name="joystick">The joystick.</param>
        /// <param name="stick">The stick number.</param>
        /// <returns>Name of the stick, otherwise null.</returns>
        public static string GetJoystickStickName(AllegroJoystick joystick, int stick)
        {
            var nativeString = AllegroLibrary.AlGetJoystickStickName(joystick.NativeIntPtr, stick);
            return nativeString == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(nativeString);
        }

        /// <summary>
        /// Return the name of the given axis. If the axis doesn’t exist, null is returned.
        /// Indices begin from 0.
        /// </summary>
        /// <param name="joystick">The joystick.</param>
        /// <param name="stick">The stick number.</param>
        /// <param name="axis">The axis number of the stick.</param>
        /// <returns>The name of the stick axis, otherwise null.</returns>
        public static string GetJoystickAxisName(AllegroJoystick joystick, int stick, int axis)
        {
            var nativeString = AllegroLibrary.AlGetJoystickAxisName(joystick.NativeIntPtr, stick, axis);
            return nativeString == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(nativeString);
        }

        /// <summary>
        /// Return the name of the given button. If the button doesn’t exist, NULL is returned.
        /// Indices begin from 0.
        /// </summary>
        /// <param name="joystick">The joystick.</param>
        /// <param name="button">The button index.</param>
        /// <returns>The name of the button.</returns>
        public static string GetJoystickButtonName(AllegroJoystick joystick, int button)
        {
            var nativeString = AllegroLibrary.AlGetJoystickButtonName(joystick.NativeIntPtr, button);
            return nativeString == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(nativeString);
        }

        /// <summary>
        /// Return the flags of the given “stick”. If the stick doesn’t exist, NULL is returned.
        /// Indices begin from 0.
        /// </summary>
        /// <param name="joystick">The joystick.</param>
        /// <param name="stick">The stick.</param>
        /// <returns>Flags for the given stick.</returns>
        public static JoyFlags GetJoystickStickFlags(AllegroJoystick joystick, int stick) =>
            (JoyFlags)AllegroLibrary.AlGetJoystickStickFlags(joystick.NativeIntPtr, stick);

        /// <summary>
        /// Return the number of “sticks” on the given joystick. A stick has one or more axes.
        /// </summary>
        /// <param name="joystick">The joystick.</param>
        /// <returns>The number of “sticks” on the given joystick.</returns>
        public static int GetJoystickNumSticks(AllegroJoystick joystick) =>
            AllegroLibrary.AlGetJoystickNumSticks(joystick.NativeIntPtr);

        /// <summary>
        /// Return the number of axes on the given “stick”. If the stick doesn’t exist, 0 is returned.
        /// </summary>
        /// <param name="joystick">The joystick.</param>
        /// <param name="stick">The stick.</param>
        /// <returns>The number of axes on the given stick.</returns>
        public static int GetJoystickNumAxes(AllegroJoystick joystick, int stick) =>
            AllegroLibrary.AlGetJoystickNumAxes(joystick.NativeIntPtr, stick);

        /// <summary>
        /// Return the number of buttons on the joystick.
        /// </summary>
        /// <param name="joystick">The joystick.</param>
        /// <returns>The number of buttons on the joystick.</returns>
        public static int GetJoystickNumButtons(AllegroJoystick joystick) =>
            AllegroLibrary.AlGetJoystickNumButtons(joystick.NativeIntPtr);

        /// <summary>
        /// Get the current joystick state.
        /// </summary>
        /// <param name="joystick">The joystick.</param>
        /// <param name="joystickState">The joystick state to populate.</param>
        public static void GetJoystickState(AllegroJoystick joystick, AllegroJoystickState joystickState) =>
            AllegroLibrary.AlGetJoystickState(joystick.NativeIntPtr, ref joystickState.Native);

        /// <summary>
        /// Returns the global joystick event source. All joystick events are generated by this event source.
        /// </summary>
        /// <returns>The global joystick event source.</returns>
        public static AllegroEventSource GetJoystickEventSource()
        {
            var nativeEventSource = AllegroLibrary.AlGetJoystickEventSource();
            return nativeEventSource == IntPtr.Zero ? null : new AllegroEventSource { NativeIntPtr = nativeEventSource };
        }

        #region P/Invokes
        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern bool al_install_joystick();

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_uninstall_joystick();

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern bool al_is_joystick_installed();

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern bool al_reconfigure_joysticks();

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern int al_get_num_joysticks();

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_get_joystick(int num);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_release_joystick(IntPtr joy);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern bool al_get_joystick_active(IntPtr joy);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_get_joystick_name(IntPtr joy);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_get_joystick_stick_name(IntPtr joy, int stick);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_get_joystick_axis_name(IntPtr joy, int stick, int axis);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_get_joystick_button_name(IntPtr joy, int button);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern int al_get_joystick_stick_flags(IntPtr joy, int stick);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern int al_get_joystick_num_sticks(IntPtr joy);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern int al_get_joystick_num_axes(IntPtr joy, int stick);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern int al_get_joystick_num_buttons(IntPtr joy);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_get_joystick_state(IntPtr joy, ref NativeJoystickState retState);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_get_joystick_event_source();
        #endregion
    }
}
