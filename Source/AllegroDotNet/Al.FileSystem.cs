using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
  public static AllegroFSEntry? CreateFSEntry(string? path)
  {
    using var nativePath = new CStringAnsi(path);
    var pointer = Interop.Core.AlCreateFsEntry(nativePath.Pointer);
    return NativePointer.Create<AllegroFSEntry>(pointer);
  }

  public static void DestroyFSEntry(AllegroFSEntry? entry)
  {
    Interop.Core.AlDestroyFsEntry(NativePointer.Get(entry));
  }

  public static string? GetFSEntryName(AllegroFSEntry? entry)
  {
    var pointer = Interop.Core.AlGetFsEntryName(NativePointer.Get(entry));
    return CStringAnsi.ToCSharpString(pointer);
  }

  public static bool UpdateFSEntry(AllegroFSEntry? entry)
  {
    return Interop.Core.AlUpdateFsEntry(NativePointer.Get(entry)) != 0;
  }

  public static FileMode GetFSEntryMode(AllegroFSEntry? entry)
  {
    return (FileMode)Interop.Core.AlGetFsEntryMode(NativePointer.Get(entry));
  }

  public static ulong GetFSEntryATime(AllegroFSEntry? entry)
  {
    return Interop.Core.AlGetFsEntryAtime(NativePointer.Get(entry));
  }

  public static ulong GetFSEntryCTime(AllegroFSEntry? entry)
  {
    return Interop.Core.AlGetFsEntryCtime(NativePointer.Get(entry));
  }

  public static ulong GetFSEntryMTime(AllegroFSEntry? entry)
  {
    return Interop.Core.AlGetFsEntryMtime(NativePointer.Get(entry));
  }

  public static ulong GetFSEntrySize(AllegroFSEntry? entry)
  {
    return Interop.Core.AlGetFsEntrySize(NativePointer.Get(entry));
  }

  public static bool FSEntryExists(AllegroFSEntry? entry)
  {
    return Interop.Core.AlFsEntryExists(NativePointer.Get(entry)) != 0;
  }

  public static bool RemoveFSEntry(AllegroFSEntry? entry)
  {
    return Interop.Core.AlRemoveFsEntry(NativePointer.Get(entry)) != 0;
  }

  public static bool FilenameExists(string? path)
  {
    using var nativePath = new CStringAnsi(path);
    return Interop.Core.AlFilenameExists(nativePath.Pointer) != 0;
  }

  public static bool RemoveFilename(string? path)
  {
    using var nativePath = new CStringAnsi(path);
    return Interop.Core.AlRemoveFilename(nativePath.Pointer) != 0;
  }

  public static bool OpenDirectory(AllegroFSEntry? entry)
  {
    return Interop.Core.AlOpenDirectory(NativePointer.Get(entry)) != 0;
  }

  public static AllegroFSEntry? ReadDirectory(AllegroFSEntry? entry)
  {
    var pointer = Interop.Core.AlReadDirectory(NativePointer.Get(entry));
    return NativePointer.Create<AllegroFSEntry>(pointer);
  }

  public static bool CloseDirectory(AllegroFSEntry? entry)
  {
    return Interop.Core.AlCloseDirectory(NativePointer.Get(entry)) != 0;
  }

  public static string? GetCurrentDirectory()
  {
    var pointer = Interop.Core.AlGetCurrentDirectory();
    return CStringAnsi.ToCSharpString(pointer);
  }

  public static bool ChangeDirectory(string? path)
  {
    using var nativePath = new CStringAnsi(path);
    return Interop.Core.AlChangeDirectory(nativePath.Pointer) != 0;
  }

  public static bool MakeDirectory(string? path)
  {
    using var nativePath = new CStringAnsi(path);
    return Interop.Core.AlMakeDirectory(nativePath.Pointer) != 0;
  }

  public static AllegroFile? OpenFSEntry(AllegroFSEntry? entry, string? mode)
  {
    using var nativeMode = new CStringAnsi(mode);
    var pointer = Interop.Core.ALOpenFsEntry(NativePointer.Get(entry), nativeMode.Pointer);
    return NativePointer.Create<AllegroFile>(pointer);
  }

  public static int ForEachFSEntry(AllegroFSEntry? entry, Delegates.ForEachFsCallback callback, IntPtr extra)
  {
    return Interop.Core.AlForEachFsEntry(NativePointer.Get(entry), callback, extra);
  }

  public static void SetFSInterface(AllegroFileInterface fsInterface)
  {
    Interop.Core.AlSetFsInterface(ref fsInterface);
  }

  public static void SetStandardFsInterface()
  {
    Interop.Core.AlSetStandardFileInterface();
  }

  public static AllegroFileInterface? GetFsInterface()
  {
    var pointer = Interop.Core.AlGetFsInterface();
    return pointer == IntPtr.Zero
      ? null
      : Marshal.PtrToStructure<AllegroFileInterface>(pointer);
  }
}
