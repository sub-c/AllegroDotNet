﻿using System;
using System.Runtime.InteropServices;
using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native.Libraries;

namespace SubC.AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
        /// <summary>
        /// Gets the compiled version of the Allegro library.
        /// </summary>
        /// <returns>
        /// Returns the (compiled) version of the Allegro library, packed into a single integer as groups of 8 bits in
        /// the form (major &lt;&lt; 24) | (minor &lt;&lt; 16) | (revision &lt;&lt; 8) | release.
        /// </returns>
        public static int GetAllegroVersion() =>
            AllegroLibrary.AlGetAllegroVersion();

        /// <summary>
        /// Gets the global application name string.
        /// </summary>
        /// <returns>Returns the global application name string.</returns>
        public static string GetAppName()
        {
            var nativeStringPtr = AllegroLibrary.AlGetAppName();
            return Marshal.PtrToStringAnsi(nativeStringPtr);
        }

        /// <summary>
        /// Gets the number of CPU cores that the system Allegro is running on has and which could be detected, or a negative number if detection
        /// failed. Even if a positive number is returned, it might be that it is not correct. For example, Allegro running on a virtual machine will
        /// return the amount of CPU's of the VM, and not that of the underlying system.
        /// 
        /// Furthermore even if the number is correct, this only gives you information about the total CPU cores of the system Allegro runs on.The
        /// amount of cores available to your program may be less due to circumstances such as programs that are currently running.
        /// 
        /// Therefore, it's best to use this for advisory purposes only. It is certainly a bad idea to make your program exclusive to systems for
        /// which this function returns a certain "desirable" number.
        /// 
        /// This function may be called prior to al_install_system or al_init.
        /// </summary>
        /// <returns>
        /// Returns the number of CPU cores that the system Allegro is running on has and which could be detected, or a negative number if detection
        /// failed.
        /// </returns>
        public static int GetCpuCount() =>
            AllegroLibrary.AlGetCpuCount();

        /// <summary>
        /// Gets the global organization name string.
        /// </summary>
        /// <returns>Returns the global organization name string.</returns>
        public static string GetOrgName()
        {
            var nativeStringPtr = AllegroLibrary.AlGetOrgName();
            return Marshal.PtrToStringAnsi(nativeStringPtr);
        }

        /// <summary>
        /// Gets the size in MB of the random access memory that the system Allegro is running on has and which could be detected, or a negative
        /// number if detection failed. Even if a positive number is returned, it might be that it is not correct. For example, Allegro running on a
        /// virtual machine will return the amount of RAM of the VM, and not that of the underlying system.
        ///
        /// Furthermore even if the number is correct, this only gives you information about the total physical memory of the system Allegro runs on.
        /// The memory available to your program may be less or more than what this function returns due to circumstances such as virtual memory, and
        /// other programs that are currently running.
        ///
        /// Therefore, it's best to use this for advisory purposes only. It is certainly a bad idea to make your program exclusive to systems for
        /// which this function returns a certain "desirable" number.
        ///
        /// This function may be called prior to al_install_system or al_init.
        /// </summary>
        /// <returns>
        /// Returns the size in MB of the random access memory that the system Allegro is running on has and which could be detected, or a negative
        /// number if detection failed.
        /// </returns>
        public static int GetRamSize() =>
            AllegroLibrary.AlGetRamSize();

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
        {
            var nativePath = AllegroLibrary.AlGetStandardPath((int)standardPath);
            return nativePath == IntPtr.Zero ? null : new AllegroPath { NativeIntPtr = nativePath };
        }

        /// <summary>
        /// Gets the system configuration that configures Allegro and its addons. You may populate this configuration before Allegro is initialized
        /// to control things like logging and system drivers (DirectX vs OpenGL, etc).
        /// </summary>
        /// <returns>
        /// Returns the system configuration structure. The returned configuration should not be destroyed with al_destroy_config. This is mainly
        /// used for configuring Allegro and its addons. You may populate this configuration before Allegro is installed to control things like
        /// the logging levels and other features.
        /// </returns>
        public static AllegroConfig GetSystemConfig()
        {
            var nativeConfig = AllegroLibrary.AlGetSystemConfig();
            return nativeConfig == IntPtr.Zero ? null : new AllegroConfig { NativeIntPtr = nativeConfig };
        }

        /// <summary>
        /// Gets the platform that Allegro is running on.
        /// </summary>
        /// <returns>Returns the platform that Allegro is running on.</returns>
        public static SystemID GetSystemID() =>
            (SystemID)AllegroLibrary.AlGetSystemID();

        /// <summary>
        /// Initialize the Allegro system. No other Allegro functions can be called before this (with one or two exceptions).
        /// </summary>
        /// <returns>
        /// Returns true if Allegro was successfully initialized by this function call (or already was initialized previously), false if Allegro
        /// cannot be used. A common reason for this function to fail is when the version of Allegro you compiled your game against is not compatible
        /// with the version of the shared libraries that were found on the system.
        /// </returns>
        public static bool Init() =>
            AllegroLibrary.AlInstallSystem(AlConstants.AllegroVersionInt, IntPtr.Zero);

        /// <summary>
        /// Initialize the Allegro system. No other Allegro functions can be called before this (with one or two exceptions).
        /// </summary>
        /// <param name="allegroVersionInt">The version field should always be set to <see cref="AlConstants.AllegroVersionInt"/>.</param>
        /// <returns>
        /// Returns true if Allegro was successfully initialized by this function call (or already was initialized previously), false if Allegro
        /// cannot be used. A common reason for this function to fail is when the version of Allegro you compiled your game against is not compatible
        /// with the version of the shared libraries that were found on the system.
        /// </returns>
        public static bool InstallSystem(int allegroVersionInt) =>
            AllegroLibrary.AlInstallSystem(allegroVersionInt, IntPtr.Zero);

        /// <summary>
        /// Determines if Allegro has been initialized.
        /// </summary>
        /// <returns>Returns true if Allegro is initialized, otherwise returns false.</returns>
        public static bool IsSystemInstalled() =>
            AllegroLibrary.AlIsSystemInstalled();

        /// <summary>
        /// Register a function to be called when an internal Allegro assertion fails.
        /// Pass NULL to reset to the default behaviour, which is to do whatever the standard assert() macro does.
        /// </summary>
        /// <param name="assertHandler">Method to be called when an internal Allegor assertion fails.</param>
        public static void RegisterAssertHandler(Delegates.AssertHandler assertHandler) =>
            AllegroLibrary.AlRegisterAssertHandler(assertHandler);

        /// <summary>
        /// Register a callback which is called whenever Allegro writes something to its log files. The default logging to allegro.log is disabled
        /// while this callback is active. Pass NULL to revert to the default logging.
        /// This function may be called prior to al_install_system.
        /// See the example allegro5.cfg for documentation on how to configure the used debug channels, logging levels and trace format.
        /// </summary>
        /// <param name="traceHandler">Method to be called when Allegro would write something to its log files.</param>
        public static void RegisterTraceHandler(Delegates.TraceHandler traceHandler) =>
            AllegroLibrary.AlRegisterTraceHandler(traceHandler);

        /// <summary>
        /// Sets the global application name.
        /// The application name is used by <see cref="GetStandardPath(StandardPath)"/> to build the full path to an application's files.
        /// This function may be called before <see cref="Init()"/> or <see cref="InstallSystem(int)"/>.
        /// </summary>
        /// <param name="appName">The new application name.</param>
        public static void SetAppName(string appName) =>
            AllegroLibrary.AlSetAppName(appName);

        /// <summary>
        /// This override the executable name used by <see cref="GetStandardPath(StandardPath)"/> for <see cref="StandardPath.ExeNamePath"/>
        /// and <see cref="StandardPath.ResourcesPath"/>.
        /// One possibility where changing this can be useful is if you use the Python wrapper. Allegro would then by default think that the system's
        /// Python executable is the current executable - but you can set it to the .py file being executed instead.
        /// </summary>
        /// <param name="exeName">The new executable name.</param>
        public static void SetExeName(string exeName) =>
            AllegroLibrary.AlSetExeName(exeName);

        /// <summary>
        /// Sets the global organization name.
        ///
        /// The organization name is used by <see cref="GetStandardPath(StandardPath)"/> to build the full path to an application's files.
        ///
        /// This function may be called before <see cref="Init()"/> or <see cref="InstallSystem(int)"/>.
        /// </summary>
        /// <param name="orgName">The new org name.</param>
        public static void SetOrgName(string orgName) =>
            AllegroLibrary.AlSetOrgName(orgName);

        /// <summary>
        /// Closes down the Allegro system.
        /// </summary>
        public static void UninstallSystem() =>
            AllegroLibrary.AlUninstallSystem();

        #region P/Invokes
        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern int al_get_allegro_version();

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_get_app_name();

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern int al_get_cpu_count();

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_get_org_name();

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern int al_get_ram_size();

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_get_standard_path(int id);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_get_system_config();

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern int al_get_system_id();

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern bool al_install_system(int version, IntPtr atExitPtr);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern bool al_is_system_installed();

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows, CharSet = CharSet.Ansi)]
        //private static extern void al_register_assert_handler(Delegates.AssertHandler assertHandler);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows, CharSet = CharSet.Ansi)]
        //private static extern void al_register_trace_handler(Delegates.TraceHandler traceHandler);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows, CharSet = CharSet.Ansi)]
        //private static extern void al_set_app_name([MarshalAs(UnmanagedType.LPStr)] string name);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows, CharSet = CharSet.Ansi)]
        //private static extern void al_set_exe_name([MarshalAs(UnmanagedType.LPStr)] string name);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows, CharSet = CharSet.Ansi)]
        //private static extern void al_set_org_name([MarshalAs(UnmanagedType.LPStr)] string name);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_uninstall_system();
        #endregion
    }
}
