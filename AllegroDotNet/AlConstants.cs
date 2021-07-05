using System;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet
{
    /// <summary>
    /// Constants values for <c>#define</c> Allegro constants, as well as AllegroDotNet specific settings.
    /// </summary>
    public static class AlConstants
    {
        #region Allegro
        public const float AllegroAudioPanNone = -1000.0f;

        public const int AllegroDefaultDisplayAdapter = -1;

        public const int AllegroMaxJoystickAxes = 3;
        public const int AllegroMaxJoystickButtons = 32;
        public const int AllegroMaxJoystickSticks = 16;

#if Windows
        public const char AllegroNativeDriveSep = ':'; // Windows
        public const char AllegroNativePathSep = '\\'; // Windows
#else
        public const char AllegroNativeDriveSep = '\0';
        public const char AllegroNativePathSep = '/';
#endif

        public const int AllegroNewWindowTitleMaxSize = 255;

        public const int AllegroVersionInt = 84018945; // 5.2.7.0 (release)
        #endregion

        #region AllegroDotNet
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr LoadFontDelegate([MarshalAs(UnmanagedType.LPStr)] string filename, int size, int flags);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool TextCallbackDelegate(int lineNum, [MarshalAs(UnmanagedType.LPStr)] string line, int size, IntPtr extra);

        /// <summary>
        /// The library filename where all Allegro (including addons) functions can be found.
        /// </summary>
        public const string AllegroMonolithDllFilenameWindows = "allegro_monolith-debug-5.2.dll";
#endregion
    }
}
