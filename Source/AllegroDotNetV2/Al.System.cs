using System.Runtime.InteropServices;
using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
  /// <summary>
  /// Initializes the Allegro system. No other Allegro functions can be called before this (with one or two exceptions).
  /// </summary>
  /// <param name="version">
  /// The version of Allegro to initialize. The correct version of the native library (ex: "allegro-5.2.dll") must be available.
  /// </param>
  /// <param name="atExit">Optional function to register as an <code>atexit()</code> function.</param>
  /// <returns>True on success, otherwise false.</returns>
  public static bool InstallSystem(AllegroLibraryVersion version, Delegates.AtExitDelegate? atExit)
  {
    return Interop.Context.Core.AlInstallSystem((int)version, atExit) == 1;
  }

  /// <summary>
  /// Initializes the Allegro system, expecting version 5.2.8 of the Allegro 5 native library to be available.
  /// </summary>
  /// <returns>True on success, otherwise false.</returns>
  public static bool Init()
  {
    return InstallSystem(AllegroLibraryVersion.V528, null);
  }

  /// <summary>
  /// Closes down the Allegro system.
  /// </summary>
  public static void UninstallSystem()
  {
    Interop.Context.Core.AlUninstallSystem();
  }

  /// <summary>
  /// Checks if the Allegro system has been initialized.
  /// </summary>
  /// <returns>True if initialized, otherwise false.</returns>
  public static bool IsSystemInstalled()
  {
    return Interop.Context.Core.AlIsSystemInstalled() == 1;
  }

  /// <summary>
  /// Returns the compiled version of the Allegro library.
  /// </summary>
  /// <returns>
  /// The compiled version of the Allegro library, packed into a single integer as groups of 8 bits.
  /// </returns>
  public static uint GetAllegroVersion()
  {
    return Interop.Context.Core.AlGetAllegroVersion();
  }

  /// <summary>
  /// Gets a system path, depending on the <c>standardPath</c> parameter. Some of these paths may be affected by the organization
  /// and application name, so be sure to set those before calling this function.
  /// <para>
  /// The paths are not guaranteed to be unique (e.g., SETTINGS and DATA may be the same on some platforms), so you
  /// should be sure your filenames are unique if you need to avoid naming collisions. Also, a returned path may not
  /// actually exist on the file system.
  /// </para>
  /// </summary>
  /// <param name="standardPath"></param>
  /// <returns></returns>
  public static AllegroPath? GetStandardPath(StandardPath standardPath)
  {
    var pointer = Interop.Context.Core.AlGetStandardPath((int)standardPath);
    return NativePointer.Create<AllegroPath>(pointer);
  }

  /// <summary>
  /// This override the executable name used by <see cref="GetStandardPath"/> for
  /// <see cref="StandardPath.ExeNamePath"/> and <see cref="StandardPath.ResourcesPath"/>.
  /// <para>
  /// One possibility where changing this can be useful is if you use the Python wrapper. Allegro would then by
  /// default think that the system’s Python executable is the current executable - but you can set it to the
  /// .py file being executed instead.
  /// </para>
  /// </summary>
  /// <param name="name">The executable name.</param>
  public static void SetExeName(string name)
  {
    var nativeName = Marshal.StringToHGlobalAnsi(name);
    Interop.Context.Core.AlSetExeName(nativeName);
    Marshal.FreeHGlobal(nativeName);
  }

  /// <summary>
  /// Sets the global application name. The application name is used by <see cref="GetStandardPath"/>
  /// to build the full path to an application’s files. This function may be called before
  /// <see cref="Init"/> or <see cref="InstallSystem"/>.
  /// </summary>
  /// <param name="name">The application name.</param>
  public static void SetAppName(string name)
  {
    var nativeName = Marshal.StringToHGlobalAnsi(name);
    Interop.Context.Core.AlSetAppName(nativeName);
    Marshal.FreeHGlobal(nativeName);
  }

  /// <summary>
  /// Sets the global organization name. The organization name is used by <see cref="GetStandardPath"/>
  /// to build the full path to an application’s files. This function may be called before
  /// <see cref="Init"/> or <see cref="InstallSystem"/>.
  /// </summary>
  /// <param name="name">The organization name.</param>
  public static void SetOrgName(string name)
  {
    var nativeName = Marshal.StringToHGlobalAnsi(name);
    Interop.Context.Core.AlSetOrgName(nativeName);
    Marshal.FreeHGlobal(nativeName);
  }

  /// <summary>
  /// Gets the global application name.
  /// </summary>
  /// <returns>The global application name string.</returns>
  public static string? GetAppName()
  {
    var nativeName = Interop.Context.Core.AlGetAppName();
    return Marshal.PtrToStringAnsi(nativeName);
  }

  /// <summary>
  /// Gets the global organization name.
  /// </summary>
  /// <returns>The global organization name string.</returns>
  public static string? GetOrgName()
  {
    var nativeName = Interop.Context.Core.AlGetOrgName();
    return Marshal.PtrToStringAnsi(nativeName);
  }

  /// <summary>
  /// <para>
  /// Returns the system configuration structure. The returned configuration should not be destroyed with
  /// <see cref="DestroyConfig"/>. This is mainly used for configuring Allegro and its addons. You may populate this
  /// configuration before Allegro is installed to control things like the logging levels and other features.
  /// </para>
  /// <para>
  /// Allegro will try to populate this configuration by loading a configuration file from a few different locations,
  /// in this order:
  /// </para>
  /// <list type="table">
  /// <item>
  /// Unix only: /etc/allegro5rc
  /// </item>
  /// <item>
  /// Unix only: $HOME/allegro5rc
  /// </item>
  /// <item>
  /// Unix only: $HOME/.allegro5rc
  /// </item>
  /// <item>
  /// allegro5.cfg next to the executable
  /// </item>
  /// </list>
  /// <para>
  /// If multiple copies are found, then they are merged using <see cref="MergeConfigInto"/>.
  /// The contents of this file are documented inside a prototypical <c>allegro5.cfg</c> that you can find in the
  /// root directory of the source distributions of Allegro. Note that Allegro will not look into that file
  /// unless you make a copy of it and place it next to your executable!
  /// </para>
  /// </summary>
  /// <returns></returns>
  public static AllegroConfig? GetSystemConfig()
  {
    var pointer = Interop.Context.Core.AlGetSystemConfig();
    return NativePointer.Create<AllegroConfig>(pointer);
  }

  /// <summary>
  /// Detects the platform that Allegro is running on.
  /// </summary>
  /// <returns>The system identifier that Allegro detected.</returns>
  public static SystemId GetSystemId()
  {
    var nativeId = Interop.Context.Core.AlGetSystemId();
    return (SystemId)nativeId;
  }

  /// <summary>
  /// Register a function to be called when an internal Allegro assertion fails. Pass <c>null</c> to reset to the
  /// default behaviour, which is to do whatever the standard <c>assert()</c> macro does.
  /// </summary>
  /// <param name="handler">The assert handler delegate.</param>
  public static void RegisterAssertHandler(Delegates.RegisterAssertHandlerDelegate? handler)
  {
    Interop.Context.Core.AlRegisterAssertHandler(handler);
  }

  /// <summary>
  /// Register a callback which is called whenever Allegro writes something to its log files. The default logging to
  /// <c>allegro.log</c> is disabled while this callback is active. Pass <c>null</c> to revert to the default logging.
  /// This function may be called prior to <see cref="InstallSystem"/>.
  /// </summary>
  /// <param name="handler">The trace handler delegate.</param>
  public static void RegisterTraceHandler(Delegates.RegisterTraceHandlerDelegate? handler)
  {
    Interop.Context.Core.AlRegisterTraceHandler(handler);
  }

  /// <summary>
  /// Returns the number of CPU cores that the system Allegro is running on has and which could be detected, or a
  /// negative number if detection failed. Even if a positive number is returned, it might be that it is not correct.
  /// For example, Allegro running on a virtual machine will return the amount of CPU’s of the VM, and not that of the
  /// underlying system.
  /// <para>
  /// Furthermore even if the number is correct, this only gives you information about the total CPU cores of the
  /// system Allegro runs on. The amount of cores available to your program may be less due to circumstances such as
  /// programs that are currently running.
  /// </para>
  /// <para>
  /// Therefore, it’s best to use this for advisory purposes only. It is certainly a bad idea to make your program
  /// exclusive to systems for which this function returns a certain “desirable” number.
  /// </para>
  /// </summary>
  /// <returns>The number of CPU cores that Allegro could detect.</returns>
  public static int GetCpuCount()
  {
    return Interop.Context.Core.AlGetCpuCount();
  }

  /// <summary>
  /// Returns the size in MB of the random access memory that the system Allegro is running on has and which could
  /// be detected, or a negative number if detection failed. Even if a positive number is returned, it might be that
  /// it is not correct. For example, Allegro running on a virtual machine will return the amount of RAM of the VM,
  /// and not that of the underlying system.
  /// <para>
  /// Furthermore even if the number is correct, this only gives you information about the total physical memory of
  /// the system Allegro runs on. The memory available to your program may be less or more than what this function
  /// returns due to circumstances such as virtual memory, and other programs that are currently running.
  /// </para>
  /// <para>
  /// Therefore, it’s best to use this for advisory purposes only. It is certainly a bad idea to make your program
  /// exclusive to systems for which this function returns a certain “desirable” number.
  /// </para>
  /// <para>
  /// This function may be called prior to <see cref="InstallSystem"/> or <see cref="Init"/>.
  /// </para>
  /// </summary>
  /// <returns>The size in MB of random access memory that Allegro could detect.</returns>
  public static int GetRamSize()
  {
    return Interop.Context.Core.AlGetRamSize();
  }
}