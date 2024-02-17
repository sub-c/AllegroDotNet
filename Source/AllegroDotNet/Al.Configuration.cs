using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
  public static AllegroConfig? CreateConfig()
  {
    var pointer = Interop.Core.AlCreateConfig();
    return NativePointer.Create<AllegroConfig>(pointer);
  }

  public static void DestroyConfig(AllegroConfig? config)
  {
    Interop.Core.AlDestroyConfig(NativePointer.Get(config));
  }

  public static AllegroConfig? LoadConfig(string? filename)
  {
    using var nativeFilename = new CStringAnsi(filename);
    var pointer = Interop.Core.AlLoadConfigFile(nativeFilename.Pointer);
    return NativePointer.Create<AllegroConfig>(pointer);
  }

  public static AllegroConfig? LoadConfigF(AllegroFile? file)
  {
    var pointer = Interop.Core.AlLoadConfigFile(NativePointer.Get(file));
    return NativePointer.Create<AllegroConfig>(pointer);
  }

  public static bool SaveConfigFile(string filename, AllegroConfig? config)
  {
    using var nativeFilename = new CStringAnsi(filename);
    return Interop.Core.AlSaveConfigFile(nativeFilename.Pointer, NativePointer.Get(config)) != 0;
  }

  public static bool SaveConfigFileF(AllegroFile? file, AllegroConfig? config)
  {
    return Interop.Core.AlSaveConfigFileF(NativePointer.Get(file), NativePointer.Get(config)) != 0;
  }

  public static void AddConfigSection(AllegroConfig? config, string? section)
  {
    using var nativeSection = new CStringAnsi(section);
    Interop.Core.AlAddConfigSection(NativePointer.Get(config), nativeSection.Pointer);
  }

  public static bool RemoveConfigSection(AllegroConfig? config, string? section)
  {
    using var nativeSection = new CStringAnsi(section);
    return Interop.Core.AlRemoveConfigSection(NativePointer.Get(config), nativeSection.Pointer) != 0;
  }

  public static void AddConfigComment(AllegroConfig? config, string? section, string? comment)
  {
    using var nativeSection = new CStringAnsi(section);
    using var nativeComment = new CStringAnsi(comment);
    Interop.Core.AlAddConfigComment(NativePointer.Get(config), nativeSection.Pointer, nativeComment.Pointer);
  }

  public static string? GetConfigValue(AllegroConfig? config, string? section, string? key)
  {
    using var nativeSection = new CStringAnsi(section);
    using var nativeKey = new CStringAnsi(key);
    var pointer = Interop.Core.AlGetConfigValue(NativePointer.Get(config), nativeSection.Pointer, nativeKey.Pointer);
    return CStringAnsi.ToCSharpString(pointer);
  }

  public static void SetConfigValue(AllegroConfig? config, string? section, string? key, string? value)
  {
    using var nativeSection = new CStringAnsi(section);
    using var nativeKey = new CStringAnsi(key);
    using var nativeValue = new CStringAnsi(value);
    Interop.Core.AlSetConfigValue(NativePointer.Get(config), nativeSection.Pointer, nativeKey.Pointer, nativeValue.Pointer);
  }

  public static bool RemoveConfigKey(AllegroConfig? config, string? section, string? key)
  {
    using var nativeSection = new CStringAnsi(section);
    using var nativeKey = new CStringAnsi(key);
    return Interop.Core.AlRemoveConfigKey(NativePointer.Get(config), nativeSection.Pointer, nativeKey.Pointer) != 0;
  }

  public static string? GetFirstConfigSection(AllegroConfig? config, out AllegroConfigSection? section)
  {
    var nativeSection = IntPtr.Zero;
    var pointer = Interop.Core.AlGetFirstConfigSection(NativePointer.Get(config), ref nativeSection);
    section = NativePointer.Create<AllegroConfigSection>(nativeSection);
    return CStringAnsi.ToCSharpString(pointer);
  }

  public static string? GetNextConfigSection(AllegroConfigSection? section)
  {
    var nativeSection = NativePointer.Get(section);
    var pointer = Interop.Core.AlGetNextConfigSection(ref nativeSection);

    if (section is not null)
      section.Pointer = nativeSection;

    return CStringAnsi.ToCSharpString(pointer);
  }

  public static string? GetFirstConfigEntry(AllegroConfig? config, string? section, out AllegroConfigEntry? entry)
  {
    var nativeEntry = IntPtr.Zero;
    using var nativeSection = new CStringAnsi(section);
    var pointer = Interop.Core.AlGetFirstConfigEntry(NativePointer.Get(config), nativeSection.Pointer, ref nativeEntry);
    entry = NativePointer.Create<AllegroConfigEntry>(nativeEntry);
    return CStringAnsi.ToCSharpString(pointer);
  }

  public static string? GetNextConfigEntry(AllegroConfigEntry? entry)
  {
    var nativeEntry = NativePointer.Get(entry);
    var pointer = Interop.Core.AlGetNextConfigEntry(ref nativeEntry);

    if (entry is not null)
      entry.Pointer = nativeEntry;

    return CStringAnsi.ToCSharpString(pointer);
  }

  public static AllegroConfig? MergeConfig(AllegroConfig? config1, AllegroConfig? config2)
  {
    var pointer = Interop.Core.AlMergeConfig(NativePointer.Get(config1), NativePointer.Get(config2));
    return NativePointer.Create<AllegroConfig>(pointer);
  }

  public static void MergeConfigInto(AllegroConfig? master, AllegroConfig? add)
  {
    Interop.Core.AlMergeConfigInto(NativePointer.Get(master), NativePointer.Get(add));
  }
}
