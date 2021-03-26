using System;
using System.Runtime.InteropServices;
using AllegroDotNet.Models;

namespace AllegroDotNet
{
    public static partial class Al
    {
        #region Managed Methods
        /// <summary>
        /// Gets the compiled version of the ALlegro library.
        /// </summary>
        /// <returns>
        /// Returns the (compiled) version of the Allegro library, packed into a single integer as groups of 8 bits in the form (major << 24) |
        /// (minor << 16) | (revision << 8) | release.
        /// </returns>
        public static int GetAllegroVersion()
            => al_get_allegro_version();

        /// <summary>
        /// Gets the global application name string.
        /// </summary>
        /// <returns>Returns the global application name string.</returns>
        public static string GetAppName()
        {
            var nativeStringPtr = al_get_app_name();
            return Marshal.PtrToStringAnsi(nativeStringPtr);
        }

        /// <summary>
        /// Gets the global organization name string.
        /// </summary>
        /// <returns>Returns the global organization name string.</returns>
        public static string GetOrgName()
        {
            var nativeStringPtr = al_get_org_name();
            return Marshal.PtrToStringAnsi(nativeStringPtr);
        }

        /// <summary>
        /// Gets a system path, depending on the id parameter. Some of these paths may be affected by the organization and application name, so
        /// be sure to set those before calling this function.
        /// 
        /// The paths are not guaranteed to be unique (e.g., SETTINGS and DATA may be the same on some platforms), so you should be sure your
        /// filenames are unique if you need to avoid naming collisions. Also, a returned path may not actually exist on the file system.
        /// </summary>
        /// <param name="standardPath">The path to get.</param>
        /// <returns>An <see cref="AllegroPath"/> to the requested standard path.</returns>
        public static AllegroPath GetStandardPath(StandardPath standardPath)
            => new AllegroPath
            {
                NativeIntPtr = al_get_standard_path((int)standardPath)
            };

        /// <summary>
        /// Initialize the Allegro system. No other Allegro functions can be called before this (with one or two exceptions).
        /// </summary>
        /// <returns>
        /// Returns true if Allegro was successfully initialized by this function call (or already was initialized previously), false if Allegro
        /// cannot be used. A common reason for this function to fail is when the version of Allegro you compiled your game against is not compatible
        /// with the version of the shared libraries that were found on the system.
        /// </returns>
        public static bool Init()
            => al_install_system(Constants.AllegroVersionInt, IntPtr.Zero);

        /// <summary>
        /// Initialize the Allegro system. No other Allegro functions can be called before this (with one or two exceptions).
        /// </summary>
        /// <param name="allegroVersionInt">The version field should always be set to <see cref="Constants.AllegroVersionInt"/>.</param>
        /// <returns>
        /// Returns true if Allegro was successfully initialized by this function call (or already was initialized previously), false if Allegro
        /// cannot be used. A common reason for this function to fail is when the version of Allegro you compiled your game against is not compatible
        /// with the version of the shared libraries that were found on the system.
        /// </returns>
        public static bool InstallSystem(int allegroVersionInt)
            => al_install_system(allegroVersionInt, IntPtr.Zero);

        /// <summary>
        /// Determines if Allegro has been initialized.
        /// </summary>
        /// <returns>Returns true if Allegro is initialized, otherwise returns false.</returns>
        public static bool IsSystemInstalled()
            => al_is_system_installed();

        /// <summary>
        /// Sets the global application name.
        ///
        /// The application name is used by <see cref="GetStandardPath(StandardPath)"/> to build the full path to an application's files.
        ///
        /// This function may be called before <see cref="Init()"/> or <see cref="InstallSystem(int)"/>.
        /// </summary>
        /// <param name="appName">The new application name.</param>
        public static void SetAppName(string appName)
            => al_set_app_name(appName);

        /// <summary>
        /// This override the executable name used by <see cref="GetStandardPath(StandardPath)"/> for <see cref="StandardPath.ExeNamePath"/>
        /// and <see cref="StandardPath.ResourcesPath"/>.
        ///
        /// One possibility where changing this can be useful is if you use the Python wrapper. Allegro would then by default think that the system's
        /// Python executable is the current executable - but you can set it to the .py file being executed instead.
        /// </summary>
        /// <param name="exeName">The new executable name.</param>
        public static void SetExeName(string exeName)
            => al_set_exe_name(exeName);

        /// <summary>
        /// Sets the global organization name.
        ///
        /// The organization name is used by <see cref="GetStandardPath(StandardPath)"/> to build the full path to an application's files.
        ///
        /// This function may be called before <see cref="Init()"/> or <see cref="InstallSystem(int)"/>.
        /// </summary>
        /// <param name="orgName">The new org name.</param>
        public static void SetOrgName(string orgName)
            => al_set_org_name(orgName);

        /// <summary>
        /// Closes down the Allegro system.
        /// </summary>
        public static void UninstallSystem()
            => al_uninstall_system();
        #endregion

        #region P/Invokes
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern int al_get_allegro_version();

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_get_app_name();

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_get_org_name();

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_get_standard_path(int id);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern bool al_install_system(int version, IntPtr atExitPtr);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern bool al_is_system_installed();

        [DllImport(Constants.AllegroCoreDllFilename, CharSet = CharSet.Ansi)]
        private static extern void al_set_app_name([MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(Constants.AllegroCoreDllFilename, CharSet = CharSet.Ansi)]
        private static extern void al_set_exe_name([MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(Constants.AllegroCoreDllFilename, CharSet = CharSet.Ansi)]
        private static extern void al_set_org_name([MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_uninstall_system();
        #endregion
    }
}
