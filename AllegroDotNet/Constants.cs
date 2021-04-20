using System.Collections.Generic;

namespace AllegroDotNet
{
    /// <summary>
    /// Constants values for <c>#define</c> Allegro constants, as well as AllegroDotNet specific settings.
    /// </summary>
    internal static class Constants
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

        public const int AllegroVersionInt = 84019200; // 5.2.8 (Git)
        #endregion

        #region AllegroDotNet
        public const string AllegroACodecAddonDllFilename = AllegroMonolithDllFilename; // "allegro_acodec-5.2.dll";

        public const string AllegroAudioAddonDllFilename = AllegroMonolithDllFilename; // "allegro_audio-5.2.dll";

        /// <summary>
        /// The library filename where core Allegro (non-addon) functions can be found.
        /// </summary>
        public const string AllegroCoreDllFilename = AllegroMonolithDllFilename; //"allegro-5.2.dll";

        public const string AllegroImageAddonDllFilename = AllegroMonolithDllFilename; // "allegro_image-5.2.dll";

        /// <summary>
        /// The library filename where all Allegro (including addon) functions can be found.
        /// </summary>
        public const string AllegroMonolithDllFilename = "allegro_monolith-5.2.dll";

        public static readonly IEnumerable<string> DependencyDllFilenames = new List<string>
        {
            "allegro_monolith-5.2.dll",
            "brotlicommon.dll",
            "brotlidec.dll",
            "bz2.dll",
            "FLAC.dll",
            "freetype.dll",
            "libpng16.dll",
            "ogg.dll",
            "physfs.dll",
            "vorbis.dll",
            "vorbisfile.dll",
            "webp.dll",
            "zlib1.dll"
        };
#endregion
    }
}
