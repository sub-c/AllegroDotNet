using System;
using System.Runtime.InteropServices;
using AllegroDotNet.Models;

namespace AllegroDotNet
{
    /// <summary>
    /// Allegro game library Core methods.
    /// </summary>
    public static partial class Al
    {
        /// <summary>
        /// Create an empty configuration structure.
        /// </summary>
        /// <returns>An empty configuration structure, or <c>null</c> on error.</returns>
        public static AllegroConfig CreateConfig()
        {
            var nativeConfig = al_create_config();
            return nativeConfig == IntPtr.Zero ? null : new AllegroConfig { NativeIntPtr = nativeConfig };
        }

        /// <summary>
        /// Free the resources used by a configuration structure. Does nothing if passed a <c>null</c> configuration.
        /// </summary>
        /// <param name="config">The configuration to free the resources of.</param>
        public static void DestroyConfig(AllegroConfig config)
            => al_destroy_config(config.NativeIntPtr);

        /// <summary>
        /// Read a configuration file from disk. Returns <c>null</c> on error. The configuration structure should be
        /// destroyed with <see cref="DestroyConfig(AllegroConfig)"/>.
        /// </summary>
        /// <param name="filename">The filename of the configuration file on disk.</param>
        /// <returns>The loaded configuration, or <c>null</c> on error.</returns>
        public static AllegroConfig LoadConfigFile(string filename)
        {
            var nativeConfig = al_load_config_file(filename);
            return nativeConfig == IntPtr.Zero ? null : new AllegroConfig { NativeIntPtr = nativeConfig };
        }

        /// <summary>
        /// Read a configuration file from an already open file.
        /// <para>
        /// Returns <c>null</c> on error. The configuration structure should be destroyed with
        /// <see cref="DestroyConfig(AllegroConfig)"/>. The file remains open afterwards.
        /// </para>
        /// </summary>
        /// <param name="file">The already open <see cref="AllegroFile"/> instance.</param>
        /// <returns>The loaded configuration, or <c>null</c> on error.</returns>
        public static AllegroConfig LoadConfigFileF(AllegroFile file)
        {
            var nativeConfig = al_load_config_file_f(file.NativeIntPtr);
            return nativeConfig == IntPtr.Zero ? null : new AllegroConfig { NativeIntPtr = nativeConfig };
        }

        /// <summary>
        /// Write out a configuration file to disk. Returns true on success, false on error.
        /// </summary>
        /// <param name="filename">The filename of the configuration file to write out.</param>
        /// <param name="config">The configuration instance to save.</param>
        /// <returns>Returns true on success, false on error.</returns>
        public static bool SaveConfigFile(string filename, AllegroConfig config)
            => al_save_config_file(filename, config.NativeIntPtr);

        /// <summary>
        /// Write out a configuration file to an already open file.
        /// <para>
        /// Returns true on success, false on error. The file remains open afterwards.
        /// </para>
        /// </summary>
        /// <param name="file">The already open file instance.</param>
        /// <param name="config">The configuration instance to save.</param>
        /// <returns>Returns true on success, false on error.</returns>
        public static bool SaveConfigFileF(AllegroFile file, AllegroConfig config)
            => al_save_config_file_f(file.NativeIntPtr, config.NativeIntPtr);

        /// <summary>
        /// Add a section to a configuration structure with the given name. If the section already exists then
        /// nothing happens.
        /// </summary>
        /// <param name="config">The configuration instance to add to.</param>
        /// <param name="name">The name of the section to add.</param>
        public static void AddConfigSection(AllegroConfig config, string name)
            => al_add_config_section(config.NativeIntPtr, name);

        /// <summary>
        /// Remove a section of a configuration.
        /// <para>
        /// Returns true if the section was removed, or false if the section did not exist.
        /// </para>
        /// </summary>
        /// <param name="config">The configuration instance to remove from.</param>
        /// <param name="section">The name of the section to remove.</param>
        /// <returns>True if the section was removed, otherwise false.</returns>
        public static bool RemoveConfigSection(AllegroConfig config, string section)
            => al_remove_config_section(config.NativeIntPtr, section);

        /// <summary>
        /// Add a comment in a section of a configuration. If the section doesn't yet exist, it will be created.
        /// The section can be <c>null</c> or "" for the global section.
        /// <para>
        /// The comment may or may not begin with a hash character. Any newlines in the comment string will be
        /// replaced by space characters.
        /// </para>
        /// </summary>
        /// <param name="config">The configuration instance to add to.</param>
        /// <param name="section">The section to place the comment.</param>
        /// <param name="comment">The comment to add.</param>
        public static void AddConfigComment(AllegroConfig config, string section, string comment)
            => al_add_config_comment(config.NativeIntPtr, section, comment);

        /// <summary>
        /// Gets a pointer to an internal character buffer that will only remain valid as long as the
        /// <see cref="AllegroConfig"/> structure is not destroyed. Copy the value if you need a copy. The section
        /// can be <c>null</c> or "" for the global section. Returns <c>null</c> if the section or key does not exist.
        /// </summary>
        /// <param name="config">The configuration instance to get from.</param>
        /// <param name="section">The section to get from.</param>
        /// <param name="key">The key to get.</param>
        /// <returns>The string value of the key, or null if it does not exist.</returns>
        public static string GetConfigValue(AllegroConfig config, string section, string key)
        {
            var nativeValue = al_get_config_value(config.NativeIntPtr, section, key);
            return nativeValue == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(nativeValue);
        }

        /// <summary>
        /// Set a value in a section of a configuration. If the section doesn't yet exist, it will be created. If a
        /// value already existed for the given key, it will be overwritten. The section can be <c>null</c> or "" for
        /// the global section.
        /// <para>
        /// For consistency with the on-disk format of config files, any leading and trailing whitespace will be
        /// stripped from the value. If you have significant whitespace you wish to preserve, you should add your
        /// own quote characters and remove them when reading the values back in.
        /// </para>
        /// </summary>
        /// <param name="config">The configuration instance to set in.</param>
        /// <param name="section">The section to set in.</param>
        /// <param name="key">The key to set with value.</param>
        /// <param name="value">The configuration value.</param>
        public static void SetConfigValue(AllegroConfig config, string section, string key, string value)
            => al_set_config_value(config.NativeIntPtr, section, key, value);

        /// <summary>
        /// Remove a key and its associated value in a section of a configuration.
        /// <para>
        /// Returns true if the entry was removed, or false if the entry did not exist.
        /// </para>
        /// </summary>
        /// <param name="config">The configuration instance to remove from.</param>
        /// <param name="section">The section to remove from.</param>
        /// <param name="key">The key to remove.</param>
        /// <returns>True if the entry was removed, or false if the entry did not exist.</returns>
        public static bool RemoveConfigKey(AllegroConfig config, string section, string key)
            => al_remove_config_key(config.NativeIntPtr, section, key);

        /// <summary>
        /// Returns the name of the first section in the given config file. Usually this will return an empty string
        /// for the global section, even it contains no values. The iterator parameter will receive an opaque
        /// iterator which is used by al_get_next_config_section to iterate over the remaining sections.
        /// <para>
        /// The returned string and the iterator are only valid as long as no change is made to the passed
        /// <see cref="AllegroConfig"/>.
        /// </para>
        /// </summary>
        /// <param name="config">The configuration instance.</param>
        /// <param name="iterator">The configuration iterator.</param>
        /// <returns>The first configuration section name.</returns>
        public static string GetFirstConfigSection(AllegroConfig config, IntPtr iterator)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the name of the next section in the given config file or <c>null</c> if there are no more sections.
        /// The iterator must have been obtained with <see cref="GetFirstConfigSection(AllegroConfig, IntPtr)"/>first.
        /// </summary>
        /// <param name="iterator">The configuration section iterator.</param>
        /// <returns>The next configuration section.</returns>
        public static string GetNextConfigSection(IntPtr iterator)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the name of the first key in the given section in the given config or <c>null</c> if the section is
        /// empty. The iterator works like the one for <see cref="GetFirstConfigSection(AllegroConfig, IntPtr)"/>.
        /// <para>
        /// The returned string and the iterator are only valid as long as no change is made to the passed
        /// <see cref="AllegroConfig"/>.
        /// </para>
        /// </summary>
        /// <param name="config">The configuration instance.</param>
        /// <param name="section">The section to get the first entry from.</param>
        /// <param name="iterator">The first configuration entry iterator.</param>
        /// <returns>The name of the first configuration entry.</returns>
        public static string GetFirstConfigEntry(AllegroConfig config, string section, IntPtr iterator)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the next key for the iterator obtained by
        /// <see cref="GetFirstConfigEntry(AllegroConfig, string, IntPtr)"/>. The iterator works like the one for 
        /// <see cref="GetNextConfigSection(IntPtr)"/>.
        /// </summary>
        /// <param name="iterator">The configuration entry iterator.</param>
        /// <returns>The next configuration entry, or null if none.</returns>
        public static string GetNextConfigEntry(IntPtr iterator)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Merge two configuration structures, and return the result as a new configuration. Values in configuration 
        /// <c>config2</c> override those in <c>config1</c>. Neither of the input configuration structures are
        /// modified. Comments from <c>config2</c> are not retained.
        /// </summary>
        /// <param name="config1">The configuration instance to be merged and overwritten to.</param>
        /// <param name="config2">The configuration instance to be merged and overwrite existing values.</param>
        /// <returns>The merged configuration instance.</returns>
        public static AllegroConfig MergeConfig(AllegroConfig config1, AllegroConfig config2)
        {
            var nativeConfig = al_merge_config(config1.NativeIntPtr, config2.NativeIntPtr);
            return nativeConfig == IntPtr.Zero ? null : new AllegroConfig { NativeIntPtr = nativeConfig };
        }

        /// <summary>
        /// Merge one configuration structure into another. Values in configuration <c>configAdd</c> override those
        /// in <c>master</c>. <c>master</c> is modified. Comments from <c>configAdd</c> are not retained.
        /// </summary>
        /// <param name="master">The resulting merged configuration.</param>
        /// <param name="configAdd">The configuration to merge from, overwritting existing values with this.</param>
        public static void MergeConfigInto(AllegroConfig master, AllegroConfig configAdd)
            => al_merge_config_into(master.NativeIntPtr, configAdd.NativeIntPtr);

        #region P/Invokes
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_create_config();

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_destroy_config(IntPtr config);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_load_config_file([MarshalAs(UnmanagedType.LPStr)] string filename);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_load_config_file_f(IntPtr file);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern bool al_save_config_file(
            [MarshalAs(UnmanagedType.LPStr)] string filename,
            IntPtr config);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern bool al_save_config_file_f(IntPtr file, IntPtr config);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_add_config_section(IntPtr config, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern bool al_remove_config_section(
            IntPtr config,
            [MarshalAs(UnmanagedType.LPStr)] string section);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_add_config_comment(
            IntPtr config,
            [MarshalAs(UnmanagedType.LPStr)] string section,
            [MarshalAs(UnmanagedType.LPStr)] string comment);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_get_config_value(
            IntPtr config,
            [MarshalAs(UnmanagedType.LPStr)] string section,
            [MarshalAs(UnmanagedType.LPStr)] string key);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_set_config_value(
            IntPtr config,
            [MarshalAs(UnmanagedType.LPStr)] string section,
            [MarshalAs(UnmanagedType.LPStr)] string key,
            [MarshalAs(UnmanagedType.LPStr)] string value);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern bool al_remove_config_key(
            IntPtr config,
            [MarshalAs(UnmanagedType.LPStr)] string section,
            [MarshalAs(UnmanagedType.LPStr)] string key);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_get_first_config_section(IntPtr config, ref IntPtr iterator);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_get_next_config_section(ref IntPtr iterator);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_get_first_config_entry(
            IntPtr config,
            [MarshalAs(UnmanagedType.LPStr)] string section,
            ref IntPtr iterator);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_get_next_config_entry(ref IntPtr iterator);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_merge_config(IntPtr config1, IntPtr config2);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_merge_config_into(IntPtr configMaster, IntPtr configAdd);
        #endregion
    }
}
