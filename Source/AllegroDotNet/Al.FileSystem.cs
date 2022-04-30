using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet
{
  public static partial class Al
  {
    public static AllegroFsEntry? CreateFsEntry(string path)
    {
      var nativePath = Marshal.StringToHGlobalAnsi(path);
      var nativeEntry = NativeFunctions.AlCreateFsEntry(nativePath);
      Marshal.FreeHGlobal(nativePath);
      return NativePointerModel.Create<AllegroFsEntry>(nativeEntry);
    }

    public static void DestroyFsEntry(AllegroFsEntry? fsEntry)
    {
      NativeFunctions.AlDestroyFsEntry(NativePointerModel.GetPointer(fsEntry));
    }

    public static string? GetFsEntryName(AllegroFsEntry? fsEntry)
    {
      var nativeValue = NativeFunctions.AlGetFsEntryName(NativePointerModel.GetPointer(fsEntry));
      return nativeValue == IntPtr.Zero
          ? null
          : Marshal.PtrToStringAnsi(nativeValue);
    }

    public static bool UpdateFsEntry(AllegroFsEntry? fsEntry)
    {
      return NativeFunctions.AlUpdateFsEntry(NativePointerModel.GetPointer(fsEntry));
    }

    public static FileMode GetFsEntryMode(AllegroFsEntry? fsEntry)
    {
      return (FileMode)NativeFunctions.AlGetFsEntryMode(NativePointerModel.GetPointer(fsEntry));
    }

    public static ulong GetFsEntryATime(AllegroFsEntry? fsEntry)
    {
      return NativeFunctions.AlGetFsEntryATime(NativePointerModel.GetPointer(fsEntry));
    }

    public static ulong GetFsEntryCTime(AllegroFsEntry? fsEntry)
    {
      return NativeFunctions.AlGetFsEntryCTime(NativePointerModel.GetPointer(fsEntry));
    }

    public static ulong GetFsEntryMTime(AllegroFsEntry? fsEntry)
    {
      return NativeFunctions.AlGetFsEntryMTime(NativePointerModel.GetPointer(fsEntry));
    }

    public static long GetFsEntrySize(AllegroFsEntry? fsEntry)
    {
      return NativeFunctions.AlGetFsEntrySize(NativePointerModel.GetPointer(fsEntry));
    }

    public static bool FsEntryExists(AllegroFsEntry? fsEntry)
    {
      return NativeFunctions.AlFsEntryExists(NativePointerModel.GetPointer(fsEntry));
    }

    public static bool RemoveFsEntry(AllegroFsEntry? fsEntry)
    {
      return NativeFunctions.AlRemoveFsEntry(NativePointerModel.GetPointer(fsEntry));
    }

    public static bool FilenameExists(string path)
    {
      var nativePath = Marshal.StringToHGlobalAnsi(path);
      var nativeValue = NativeFunctions.AlFilenameExists(nativePath);
      Marshal.FreeHGlobal(nativePath);
      return nativeValue;
    }

    public static bool RemoveFilename(string path)
    {
      var nativePath = Marshal.StringToHGlobalAnsi(path);
      var nativeValue = NativeFunctions.AlRemoveFilename(nativePath);
      Marshal.FreeHGlobal(nativePath);
      return nativeValue;
    }

    public static bool OpenDirectory(AllegroFsEntry? fsEntry)
    {
      return NativeFunctions.AlOpenDirectory(NativePointerModel.GetPointer(fsEntry));
    }

    public static AllegroFsEntry? ReadDirectory(AllegroFsEntry? fsEntry)
    {
      var nativeEntry = NativeFunctions.AlReadDirectory(NativePointerModel.GetPointer(fsEntry));
      return NativePointerModel.Create<AllegroFsEntry>(nativeEntry);
    }

    public static bool CloseDirectory(AllegroFsEntry? fsEntry)
    {
      return NativeFunctions.AlCloseDirectory(NativePointerModel.GetPointer(fsEntry));
    }

    public static string? GetCurrentDirectory()
    {
      var nativeDirectory = NativeFunctions.AlGetCurrentDirectory();
      var managedValue = nativeDirectory == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(nativeDirectory);
      Free(nativeDirectory);
      return managedValue;
    }

    public static bool ChangeDirectory(string path)
    {
      var nativePath = Marshal.StringToHGlobalAnsi(path);
      var value = NativeFunctions.AlChangeDirectory(nativePath);
      Marshal.FreeHGlobal(nativePath);
      return value;
    }

    public static bool MakeDirectory(string path)
    {
      var nativePath = Marshal.StringToHGlobalAnsi(path);
      var value = NativeFunctions.AlMakeDirectory(nativePath);
      Marshal.FreeHGlobal(nativePath);
      return value;
    }

    public static AllegroFile? OpenFsEntry(AllegroFsEntry? fsEntry, string mode)
    {
      var nativeMode = Marshal.StringToHGlobalAnsi(mode);
      var nativeFile = NativeFunctions.AlOpenFsEntry(NativePointerModel.GetPointer(fsEntry), nativeMode);
      Marshal.FreeHGlobal(nativeMode);
      return NativePointerModel.Create<AllegroFile>(nativeFile);
    }

    public static FsEntryResult ForEachFsEntry(AllegroFsEntry? directory, NativeDelegates.ForEachFsEntry callback, IntPtr extra)
    {
      return (FsEntryResult)NativeFunctions.AlForEachFsEntry(NativePointerModel.GetPointer(directory), callback, extra);
    }

    public static void SetFsInterface(AllegroFsInterface? fsInterface)
    {
      throw new NotImplementedException();
    }

    public static void SetStandardFsInterface()
    {
      NativeFunctions.AlSetStandardFsInterface();
    }

    public static AllegroFsInterface? GetFsInterface()
    {
      throw new NotImplementedException();
    }
  }
}