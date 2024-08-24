using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native;

internal static partial class Interop
{
    public static ACodecContext ACodec => _acodecContext ??= new();

    private static ACodecContext? _acodecContext;

    public sealed class ACodecContext
    {
        #region Audio Codec Routines

        public al_init_acodec_addon AlInitACodecAddon { get; }
        public al_is_acodec_addon_initialized AlIsACodecAddonInitialized { get; }
        public al_get_allegro_acodec_version AlGetAllegroACodecVersion { get; }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_init_acodec_addon();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_is_acodec_addon_initialized();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_allegro_acodec_version();

        #endregion

        public ACodecContext()
        {
            AlInitACodecAddon = LoadFunction<al_init_acodec_addon>();
            AlIsACodecAddonInitialized = LoadFunction<al_is_acodec_addon_initialized>();
            AlGetAllegroACodecVersion = LoadFunction<al_get_allegro_acodec_version>();
        }
    }
}
