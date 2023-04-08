using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet;

public static partial class Al
{
  public static void SetupAllegroInterop()
  {
    NativeInterop.SetupAllegroInterop();
  }

  public static bool InstallSystem(int version, NativeDelegates.AtExitDelegate? atExit)
  {
    NativeInterop.SetupAllegroInterop();
    return NativeFunctions.AlInstallSystem(version, atExit);
  }

  public static bool Init()
  {
    return InstallSystem(ALLEGRO_VERSION_INT, null);
  }

  public static void UninstallSystem()
  {
    NativeFunctions.AlUninstallSystem();
  }

  public static bool IsSystemInstalled()
  {
    return NativeFunctions.AlIsSystemInstalled();
  }

  public static uint GetAllegroVersion()
  {
    return NativeFunctions.AlGetAllegroVersion();
  }

  public static AllegroPath? GetStandardPath(StandardPath id)
  {
    var nativePath = NativeFunctions.AlGetStandardPath((int)id);
    return NativePointerModel.Create<AllegroPath>(nativePath);
  }

  public static void SetExeName(string name)
  {
    var nativeName = Marshal.StringToHGlobalAnsi(name);
    NativeFunctions.AlSetExeName(nativeName);
    Marshal.FreeHGlobal(nativeName);
  }

  public static void SetAppName(string name)
  {
    var nativeName = Marshal.StringToHGlobalAnsi(name);
    NativeFunctions.AlSetAppName(nativeName);
    Marshal.FreeHGlobal(nativeName);
  }

  public static void SetOrgName(string name)
  {
    var nativeName = Marshal.StringToHGlobalAnsi(name);
    NativeFunctions.AlSetOrgName(nativeName);
    Marshal.FreeHGlobal(nativeName);
  }

  public static string? GetAppName()
  {
    var nativeName = NativeFunctions.AlGetAppName();
    return Marshal.PtrToStringAnsi(nativeName);
  }

  public static string? GetOrgName()
  {
    var nativeName = NativeFunctions.AlGetOrgName();
    return Marshal.PtrToStringAnsi(nativeName);
  }

  public static AllegroConfig? GetSystemConfig()
  {
    var nativeConfig = NativeFunctions.AlGetSystemConfig();
    return NativePointerModel.Create<AllegroConfig>(nativeConfig);
  }

  public static SystemID GetSystemID()
  {
    return (SystemID)NativeFunctions.AlGetSystemID();
  }

  public static void RegisterAssertHandler(NativeDelegates.RegisterAssertHandler handler)
  {
    NativeFunctions.AlRegisterAssertHandler(handler);
  }

  public static void RegisterTraceHandler(NativeDelegates.RegisterTraceHandler handler)
  {
    NativeFunctions.AlRegisterTraceHandler(handler);
  }

  public static int GetCpuCount()
  {
    return NativeFunctions.AlGetCpuCount();
  }

  public static int GetRamSize()
  {
    return NativeFunctions.AlGetRamSize();
  }
}
