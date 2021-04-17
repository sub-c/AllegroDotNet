using System.Runtime.InteropServices;

namespace AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
        /// <summary>
        /// This function registers all the known audio file type handlers for al_load_sample, al_save_sample,
        /// al_load_audio_stream, etc.
        /// <para>
        /// Depending on what libraries are available, the full set of recognised extensions is: .wav, .flac, .ogg,
        /// .opus, .it, .mod, .s3m, .xm, .voc.
        /// </para>
        /// <para>
        /// Limitations:
        /// </para>
        /// <para>
        ///  Saving is only supported for wav files.
        /// </para>
        /// <para>
        ///  The wav file loader currently only supports 8/16 bit little endian PCM files. 16 bits are used when saving
        ///  wav files.Use flac files if more precision is required.
        /// </para>
        /// <para>
        ///  Module files (.it, .mod, .s3m, .xm) are often composed with streaming in mind, and sometimes cannot be
        ///  easily rendered into a finite length sample.Therefore they cannot be loaded with al_load_sample /
        ///  al_load_sample_f and must be streamed with al_load_audio_stream or al_load_audio_stream_f.
        /// </para>
        /// <para>
        /// .voc file streaming is unimplemented.
        /// </para>
        /// </summary>
        /// <returns>True on success, otherwise false.</returns>
        public static bool InitACodecAddon()
            => al_init_acodec_addon();

        /// <summary>
        /// Returns true if the acodec addon is initialized, otherwise returns false.
        /// </summary>
        /// <returns>True if the acodec addon is initialized, otherwise returns false.</returns>
        public static bool IsACodecAddonInitialized()
            => al_is_acodec_addon_initialized();

        /// <summary>
        /// Returns the (compiled) version of the addon, in the same format as al_get_allegro_version.
        /// </summary>
        /// <returns>The (compiled) version of the addon.</returns>
        public static uint GetAllegroACodecVersion()
            => al_get_allegro_acodec_version();

        #region P/Invokes
        [DllImport(Constants.AllegroACodecAddonDllFilename)]
        private static extern bool al_init_acodec_addon();

        [DllImport(Constants.AllegroACodecAddonDllFilename)]
        private static extern bool al_is_acodec_addon_initialized();

        [DllImport(Constants.AllegroACodecAddonDllFilename)]
        private static extern uint al_get_allegro_acodec_version();
        #endregion
    }
}
