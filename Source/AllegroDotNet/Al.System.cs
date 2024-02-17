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
  /// Attempts to initialize the Allegro system. The versions tried are limited to versions in the
  /// <see cref="LibraryVersion"/> enumeration.
  /// </summary>
  /// <returns>True if Allegro was initialized, otherwise false.</returns>
  public static bool Init()
  {
    foreach (LibraryVersion libraryVersion in Enum.GetValues(typeof(LibraryVersion)))
    {
      if (InstallSystem(libraryVersion))
        return true;
    }

    return false;
  }

  /// <summary>
  /// Initialize the Allegro system. No other Allegro functions can be called before this (with one or two exceptions).
  /// </summary>
  /// <param name="version">The library version of Allegro to initialize.</param>
  /// <returns>True on success, otherwise false.</returns>
  public static bool InstallSystem(LibraryVersion version)
  {
    return InstallSystem((int)version);
  }

  /// <summary>
  /// Initialize the Allegro system. No other Allegro functions can be called before this (with one or two exceptions).
  /// </summary>
  /// <param name="version">The library version of Allegro to initialize, packed into a integer.</param>
  /// <returns>True on success, otherwise false.</returns>
  public static bool InstallSystem(int version)
  {
    return Interop.Core.AlInstallSystem(version, null) != 0;
  }

  /// <summary>
  /// Closes down the Allegro system.
  /// </summary>
  public static void UninstallSystem()
  {
    Interop.Core.AlUninstallSystem();
  }

  /// <summary>
  /// Returns true if Allegro is initialized, otherwise returns false.
  /// </summary>
  /// <returns>True if Allegro is initialized, otherwise false.</returns>
  public static bool IsSystemInstalled()
  {
    return Interop.Core.AlIsSystemInstalled() != 0;
  }

  /// <summary>
  /// Returns the (compiled) version of the Allegro library, packed into a single integer.
  /// This value can be cast to (or from) a value of <see cref="LibraryVersion"/>, if it defined
  /// in that enumeration; they use the same integer values.
  /// </summary>
  /// <returns>The compiled version of the Allegro library, packed into a single integer.</returns>
  public static uint GetAllegroVersion()
  {
    return Interop.Core.AlGetAllegroVersion();
  }

  public static AllegroPath? GetStandardPath(StandardPath path)
  {
    var pointer = Interop.Core.AlGetStandardPath((int)path);
    return NativePointer.Create<AllegroPath>(pointer);
  }

  public static void SetExeName(string name)
  {
    using var nativeName = new CStringAnsi(name);
    Interop.Core.AlSetExeName(nativeName.Pointer);
  }

  public static void SetAppName(string name)
  {
    using var nativeName = new CStringAnsi(name);
    Interop.Core.AlSetAppName(nativeName.Pointer);
  }

  public static void SetOrgName(string name)
  {
    using var nativeName = new CStringAnsi(name);
    Interop.Core.AlSetOrgName(nativeName.Pointer);
  }

  public static string? GetAppName()
  {
    var pointer = Interop.Core.AlGetAppName();
    return CStringAnsi.ToCSharpString(pointer);
  }

  public static string? GetOrgName()
  {
    var pointer = Interop.Core.AlGetOrgName();
    return CStringAnsi.ToCSharpString(pointer);
  }

  public static AllegroConfig? GetSystemConfig()
  {
    var pointer = Interop.Core.AlGetSystemConfig();
    return NativePointer.Create<AllegroConfig>(pointer);
  }

  public static SystemID GetSystemID()
  {
    return (SystemID)Interop.Core.AlGetSystemId();
  }

  public static void RegisterAssertHandler(Delegates.RegisterAssertHandlerDelegate? handler)
  {
    Interop.Core.AlRegisterAssertHandler(handler);
  }

  public static void RegisterTraceHandler(Delegates.RegisterTraceHandlerDelegate? handler)
  {
    Interop.Core.AlRegisterTraceHandler(handler);
  }

  public static int GetCpuCount()
  {
    return Interop.Core.AlGetCpuCount();
  }

  public static int GetRamSize()
  {
    return Interop.Core.AlGetRamSize();
  }
}
