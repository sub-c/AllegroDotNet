using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
        /// <summary>
        /// This function sets both the ALLEGRO_FILE_INTERFACE and ALLEGRO_FS_INTERFACE for the calling thread.
        /// <para>
        /// Subsequent calls to al_fopen on the calling thread will be handled by PHYSFS_open(). Operations on the
        /// files returned by al_fopen will then be performed through PhysicsFS. Calls to the Allegro filesystem
        /// functions, such as al_read_directory or al_create_fs_entry, on the calling thread will be diverted to
        /// PhysicsFS.
        /// </para>
        /// <para>
        /// To remember and restore another file I/O backend, you can use al_store_state/al_restore_state.
        /// </para>
        /// <para>
        /// Note: due to an oversight, this function differs from al_set_new_file_interface and
        /// al_set_standard_file_interface which only alter the current ALLEGRO_FILE_INTERFACE.
        /// </para>
        /// <para>
        /// Note: PhysFS does not support the text-mode reading and writing, which means that Windows-style newlines
        /// will not be preserved.
        /// </para>
        /// </summary>
        public static void SetPhysfsFileInterface()
            => al_set_physfs_file_interface();

        /// <summary>
        /// Returns the (compiled) version of the addon, in the same format as al_get_allegro_version.
        /// </summary>
        /// <returns>The (compiled) version of the addon, in the same format as al_get_allegro_version.</returns>
        public static uint GetAllegroPhysfsVersion()
            => al_get_allegro_physfs_version();

        #region P/Invokes
        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_set_physfs_file_interface();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern uint al_get_allegro_physfs_version();
        #endregion
    }
}
