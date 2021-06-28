using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SubC.AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
        /// <summary>
        /// Initializes the image addon. This registers bitmap format handlers for
        /// <see cref="LoadBitmap(string)"/>, <see cref="LoadBitmapF(Models.AllegroFile, string)"/>,
        /// <see cref="SaveBitmap(string, Models.AllegroBitmap)"/>,
        /// <see cref="SaveBitmapF(Models.AllegroFile, string, Models.AllegroBitmap)"/>.
        /// <para>
        /// The following types are built into the Allegro image addon and guaranteed to be available: BMP, DDS, PCX,
        /// TGA. Every platform also supports JPEG and PNG via external dependencies.
        /// </para>
        /// <para>
        /// Other formats may be available depending on the operating system and installed libraries, but are not
        /// guaranteed and should not be assumed to be universally available.
        /// </para>
        /// <para>
        /// The DDS format is only supported to load from, and only if the DDS file contains textures compressed in the
        /// DXT1, DXT3 and DXT5 formats. Note that when loading a DDS file, the created bitmap will always be a video
        /// bitmap and will have the pixel format matching the format in the file.
        /// </para>
        /// </summary>
        /// <returns>True on success, otherwise false.</returns>
        public static bool InitImageAddon()
            => al_init_image_addon();

        /// <summary>
        /// Returns true if the image addon is initialized, otherwise returns false.
        /// </summary>
        /// <returns>True if the image addon is initialized, otherwise returns false.</returns>
        public static bool IsImageAddonInitialized()
            => al_is_image_addon_initialized();

        /// <summary>
        /// Shut down the image addon. This is done automatically at program exit, but can be called any time the
        /// user wishes as well.
        /// </summary>
        public static void ShutdownImageAddon()
            => al_shutdown_image_addon();

        /// <summary>
        /// Returns the (compiled) version of the addon, in the same format as <see cref="GetAllegroVersion"/>.
        /// </summary>
        /// <returns></returns>
        public static uint GetAllegroImageVersion()
            => al_get_allegro_image_version();

        #region P/Invokes
        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_init_image_addon();

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_is_image_addon_initialized();

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern void al_shutdown_image_addon();

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern uint al_get_allegro_image_version();
        #endregion
    }
}
