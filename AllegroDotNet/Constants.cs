namespace AllegroDotNet
{
    /// <summary>
    /// Constants values for <c>#define</c> Allegro constants, as well as AllegroDotNet specific settings.
    /// </summary>
    internal static class Constants
    {
        #region Allegro
        public const int AllegroDefaultDisplayAdapter = -1;

        public const int AllegroMaxJoystickAxes = 3;
        public const int AllegroMaxJoystickButtons = 32;
        public const int AllegroMaxJoystickSticks = 16;

        public const char AllegroNativeDriveSep = ':'; // Windows
        public const char AllegroNativePathSep = '\\'; // Windows

        public const int AllegroNewWindowTitleMaxSize = 255;

        public const int AllegroVersionInt = 84019200; // 5.2.8 (Git)
        #endregion

        #region AllegroDotNet
        /// <summary>
        /// The library filename where all Allegro (including addon) functions can be found.
        /// </summary>
        public const string AllegroMonolithDllFilename = "allegro_monolith-5.2.dll";

        /// <summary>
        /// The library filename where core Allegro (non-addon) functions can be found.
        /// </summary>
        public const string AllegroCoreDllFilename = "allegro-5.2.dll";
        #endregion
    }
}
