using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native;

internal static partial class Interop
{
    public static ImageContext Image => _imageContext ??= new();

    private static ImageContext? _imageContext;

    public sealed class ImageContext
    {
        #region Image I/O Routines

        public al_init_image_addon AlInitImageAddon { get; }
        public al_is_image_addon_initialized AlIsImageAddonInitialized { get; }
        public al_shutdown_image_addon AlShutdownImageAddon { get; }
        public al_get_allegro_image_version AlGetAllegroImageVersion { get; }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_init_image_addon();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_is_image_addon_initialized();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_shutdown_image_addon();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_allegro_image_version();

        #endregion

        public ImageContext()
        {
            AlInitImageAddon = LoadFunction<al_init_image_addon>();
            AlIsImageAddonInitialized = LoadFunction<al_is_image_addon_initialized>();
            AlShutdownImageAddon = LoadFunction<al_shutdown_image_addon>();
            AlGetAllegroImageVersion = LoadFunction<al_get_allegro_image_version>();
        }
    }
}
