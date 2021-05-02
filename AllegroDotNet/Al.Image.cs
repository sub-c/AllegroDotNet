using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
        public static bool InitImageAddon()
            => al_init_image_addon();

        public static bool IsImageAddonInitialized()
            => al_is_image_addon_initialized();

        public static void ShutdownImageAddon()
            => al_shutdown_image_addon();

        public static uint GetAllegroImageVersion()
            => al_get_allegro_image_version();

        #region P/Invokes
        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_init_image_addon();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_is_image_addon_initialized();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_shutdown_image_addon();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern uint al_get_allegro_image_version();
        #endregion
    }
}
