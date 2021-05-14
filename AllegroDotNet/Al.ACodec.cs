using System.Runtime.InteropServices;

namespace AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
        /// <summary>
        /// This function registers all the known audio file type handlers for
        /// <see cref="LoadSample(string)"/>, <see cref="SaveSample(string, Models.AllegroSample)"/>,
        /// <see cref="LoadAudioStream(string, ulong, uint)"/>, etc.
        /// <para>
        /// Depending on what libraries are available, the full set of recognised extensions is: <c>.wav, .flac, .ogg,
        /// .opus, .it, .mod, .s3m, .xm, .voc</c>.
        /// </para>
        /// <para>
        /// Limitations:
        /// </para>
        /// <para>
        ///  Saving is only supported for <c>wav</c> files.
        /// </para>
        /// <para>
        ///  The wav file loader currently only supports 8/16 bit little endian PCM files. 16 bits are used when saving
        ///  <c>wav</c> files. Use <c>flac</c> files if more precision is required.
        /// </para>
        /// <para>
        ///  Module files (<c>.it, .mod, .s3m, .xm</c>) are often composed with streaming in mind, and sometimes cannot be
        ///  easily rendered into a finite length sample. Therefore they cannot be loaded with
        ///  <see cref="LoadSample(string)"/> / <see cref="LoadSampleF(Models.AllegroFile, string)"/> and must be
        ///  streamed with <see cref="LoadAudioStream(string, ulong, uint)"/> or
        ///  <see cref="LoadAudioStreamF(Models.AllegroFile, string, ulong, uint)"/>.
        /// </para>
        /// <para>
        /// <c>.voc</c> file streaming is unimplemented.
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
        /// Returns the (compiled) version of the addon, in the same format as <see cref="GetAllegroVersion"/>.
        /// </summary>
        /// <returns>The (compiled) version of the addon.</returns>
        public static uint GetAllegroACodecVersion()
            => al_get_allegro_acodec_version();

        #region P/Invokes
        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_init_acodec_addon();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_is_acodec_addon_initialized();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern uint al_get_allegro_acodec_version();
        #endregion
    }
}
