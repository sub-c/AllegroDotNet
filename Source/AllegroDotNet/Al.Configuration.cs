using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet
{
  public static partial class Al
  {
    public static AllegroConfig? CreateConfig()
    {
      var nativeConfig = NativeFunctions.AlCreateConfig();
      return NativePointerModel.Create<AllegroConfig>(nativeConfig);
    }

    public static void DestroyConfig(AllegroConfig? config)
    {
      NativeFunctions.AlDestroyConfig(NativePointerModel.GetPointer(config));
    }

    public static AllegroConfig? LoadConfigFile(string filename)
    {
      var nativeFilename = Marshal.StringToHGlobalAnsi(filename);
      var nativeConfig = NativeFunctions.AlLoadConfigFile(nativeFilename);
      Marshal.FreeHGlobal(nativeFilename);
      return NativePointerModel.Create<AllegroConfig>(nativeConfig);
    }

    public static AllegroConfig? LoadConfigFileF(AllegroFile? file)
    {
      var nativeConfig = NativeFunctions.AlLoadConfigFileF(NativePointerModel.GetPointer(file));
      return NativePointerModel.Create<AllegroConfig>(nativeConfig);
    }

    public static bool SaveConfigFile(string filename, AllegroConfig? config)
    {
      var nativeFilename = Marshal.StringToHGlobalAnsi(filename);
      var result = NativeFunctions.AlSaveConfigFile(nativeFilename, NativePointerModel.GetPointer(config));
      Marshal.FreeHGlobal(nativeFilename);
      return result;
    }

    public static bool SaveConfigFileF(AllegroFile? file, AllegroConfig? config)
    {
      return NativeFunctions.AlSaveConfigFileF(NativePointerModel.GetPointer(file), NativePointerModel.GetPointer(config));
    }

    public static void AddConfigSection(AllegroConfig? config, string section)
    {
      var nativeSection = Marshal.StringToHGlobalAnsi(section);
      NativeFunctions.AlAddConfigSection(NativePointerModel.GetPointer(config), nativeSection);
      Marshal.FreeHGlobal(nativeSection);
    }

    public static void RemoveConfigSection(AllegroConfig? config, string section)
    {
      var nativeSection = Marshal.StringToHGlobalAnsi(section);
      NativeFunctions.AlRemoveConfigSection(NativePointerModel.GetPointer(config), nativeSection);
      Marshal.FreeHGlobal(nativeSection);
    }

    public static void AddConfigComment(AllegroConfig? config, string section, string comment)
    {
      var nativeSection = Marshal.StringToHGlobalAnsi(section);
      var nativeComment = Marshal.StringToHGlobalAnsi(comment);
      NativeFunctions.AlAddConfigComment(NativePointerModel.GetPointer(config), nativeSection, nativeComment);
      Marshal.FreeHGlobal(nativeComment);
      Marshal.FreeHGlobal(nativeSection);
    }

    public static string? GetConfigValue(AllegroConfig? config, string section, string key)
    {
      var nativeSection = Marshal.StringToHGlobalAnsi(section);
      var nativeKey = Marshal.StringToHGlobalAnsi(key);
      var nativeValue = NativeFunctions.AlGetConfigValue(NativePointerModel.GetPointer(config), nativeSection, nativeKey);
      Marshal.FreeHGlobal(nativeKey);
      Marshal.FreeHGlobal(nativeSection);
      return Marshal.PtrToStringAnsi(nativeValue);
    }

    public static void SetConfigValue(AllegroConfig? config, string section, string key, string value)
    {
      var nativeSection = Marshal.StringToHGlobalAnsi(section);
      var nativeKey = Marshal.StringToHGlobalAnsi(key);
      var nativeValue = Marshal.StringToHGlobalAnsi(value);
      NativeFunctions.AlSetConfigValue(NativePointerModel.GetPointer(config), nativeSection, nativeKey, nativeValue);
      Marshal.FreeHGlobal(nativeValue);
      Marshal.FreeHGlobal(nativeKey);
      Marshal.FreeHGlobal(nativeSection);
    }

    public static bool RemoveConfigKey(AllegroConfig? config, string section, string key)
    {
      var nativeSection = Marshal.StringToHGlobalAnsi(section);
      var nativeKey = Marshal.StringToHGlobalAnsi(key);
      var value = NativeFunctions.AlRemoveConfigKey(NativePointerModel.GetPointer(config), nativeSection, nativeKey);
      Marshal.FreeHGlobal(nativeKey);
      Marshal.FreeHGlobal(nativeSection);
      return value;
    }

    public static string? GetFirstConfigSection(AllegroConfig? config, out AllegroConfigSection configSection)
    {
      configSection = new();
      var nativeValue = NativeFunctions.AlGetFirstConfigSection(NativePointerModel.GetPointer(config), ref configSection.NativePointer);
      return Marshal.PtrToStringAnsi(nativeValue);
    }

    public static string? GetNextConfigSection(AllegroConfigSection configSection)
    {
      var nativeValue = NativeFunctions.AlGetNextConfigSection(ref configSection.NativePointer);
      return Marshal.PtrToStringAnsi(nativeValue);
    }

    public static string? GetFirstConfigEntry(AllegroConfig? config, string section, out AllegroConfigEntry configEntry)
    {
      configEntry = new();
      var nativeSection = Marshal.StringToHGlobalAnsi(section);
      var nativeValue = NativeFunctions.AlGetFirstConfigEntry(NativePointerModel.GetPointer(config), nativeSection, ref configEntry.NativePointer);
      Marshal.FreeHGlobal(nativeSection);
      return Marshal.PtrToStringAnsi(nativeValue);
    }

    public static string? GetNextConfigEntry(AllegroConfigEntry configEntry)
    {
      var nativeValue = NativeFunctions.AlGetNextConfigEntry(ref configEntry.NativePointer);
      return Marshal.PtrToStringAnsi(nativeValue);
    }

    public static AllegroConfig? MergeConfig(AllegroConfig? config1, AllegroConfig? config2)
    {
      var nativeConfig = NativeFunctions.AlMergeConfig(NativePointerModel.GetPointer(config1), NativePointerModel.GetPointer(config2));
      return NativePointerModel.Create<AllegroConfig>(nativeConfig);
    }

    public static void MergeConfigInto(AllegroConfig? masterConfig, AllegroConfig? addConfig)
    {
      NativeFunctions.AlMergeConfigInto(NativePointerModel.GetPointer(masterConfig), NativePointerModel.GetPointer(addConfig));
    }
  }
}