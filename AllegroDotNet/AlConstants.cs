using System;
using System.Runtime.InteropServices;
using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;

namespace SubC.AllegroDotNet
{
    /// <summary>
    /// Constants values for <c>#define</c> Allegro constants, as well as AllegroDotNet specific settings.
    /// </summary>
    public static class AlConstants
    {
        #region Allegro
        /// <summary>
        /// Disables panning and plays the sample at original pan.
        /// </summary>
        public const float AllegroAudioPanNone = -1000.0f;

        /// <summary>
        /// Value returned for end-of-file situations; use <see cref="Al.FEoF(Models.AllegroFile)"/> if the Allegro
        /// method returns -1 for any errors and you want verify it is a end-of-file error.
        /// </summary>
        public const int AllegroEof = -1;

        /// <summary>
        /// Used to refer to the default display adapter.
        /// </summary>
        public const int AllegroDefaultDisplayAdapter = -1;

        /// <summary>
        /// Maximum amount of joystick axes per stick.
        /// </summary>
        public const int AllegroMaxJoystickAxes = 3;

        /// <summary>
        /// Maximum amount of joystick buttons.
        /// </summary>
        public const int AllegroMaxJoystickButtons = 32;

        /// <summary>
        /// Maximum amount of joystick sticks.
        /// </summary>
        public const int AllegroMaxJoystickSticks = 16;

#if Windows
        /// <summary>
        /// Windows-specific drive separator character.
        /// </summary>
        public const char AllegroNativeDriveSep = ':';

        /// <summary>
        /// Windows-specific path/directory separator character.
        /// </summary>
        public const char AllegroNativePathSep = '\\';
#else
        public const char AllegroNativeDriveSep = '\0';
        public const char AllegroNativePathSep = '/';
#endif
        /// <summary>
        /// Maximum text length for a display title window.
        /// </summary>
        public const int AllegroNewWindowTitleMaxSize = 255;

        /// <summary>
        /// Version of Allegro that this library expects to be using.
        /// </summary>
        public const int AllegroVersionInt = 84018945; // 5.2.7.0 (release)
        #endregion

        #region AllegroDotNet
        /// <summary>
        /// Delegate used for user-defined loading of fonts.
        /// </summary>
        /// <param name="filename">Filename of the font.</param>
        /// <param name="size">Size of the font.</param>
        /// <param name="flags">Font loading flags (<see cref="LoadFontFlags"/>).</param>
        /// <returns></returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr LoadFontDelegate([MarshalAs(UnmanagedType.LPStr)] string filename, int size, int flags);

        /// <summary>
        /// Delegate used for user-defined text callbacks for multi-line text.
        /// </summary>
        /// <param name="lineNum">The line number.</param>
        /// <param name="line">The text in line.</param>
        /// <param name="size">The font size.</param>
        /// <param name="extra">Extra parameters.</param>
        /// <returns>True if successful, otherwise false.</returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool TextCallbackDelegate(int lineNum, [MarshalAs(UnmanagedType.LPStr)] string line, int size, IntPtr extra);

        /// <summary>
        /// Delegate used for user-defined processes using <see cref="AllegroThread"/>.
        /// </summary>
        /// <param name="nativeThread">The native pointer to the Allegro thread.</param>
        /// <param name="nativeArgument">The native pointer to the argument passed when creating the thread.</param>
        /// <returns>Native pointer to the thread created.</returns>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate IntPtr ThreadProcessDelegate(IntPtr nativeThread, IntPtr nativeArgument);

        /// <summary>
        /// Delegate used for user-defined detached processes.
        /// </summary>
        /// <param name="nativeArgument">
        /// The native pointer to the argument passed when creating the detached thread.
        /// </param>
        /// <returns>True on success, otherwise false.</returns>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate IntPtr DetachedThreadProcessDelegate(IntPtr nativeArgument);

        /// <summary>
        /// Delegate used for callbacks when iterating through a <see cref="AllegroFSEntry"/> when using
        /// <see cref="Al.ForEachFSEntry(AllegroFSEntry, ForEachFSEntryCallback, IntPtr)"/>.
        /// </summary>
        /// <param name="dir">The native pointer to the Allegro FS Entry.</param>
        /// <param name="extra">
        /// The data that was originally passed when
        /// <see cref="Al.ForEachFSEntry(AllegroFSEntry, ForEachFSEntryCallback, IntPtr)"/> was invoked.
        /// </param>
        /// <returns>A <see cref="ForEachFSEntryResult"/> value.</returns>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ForEachFSEntryCallback(IntPtr dir, IntPtr extra);

        /// <summary>
        /// The library filename where all Allegro (including addons) functions can be found.
        /// </summary>
        public const string AllegroMonolithDllFilenameWindows = "allegro_monolith-debug-5.2.dll";
#endregion
    }
}
