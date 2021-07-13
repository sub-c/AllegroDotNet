using System;
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
        public static AllegroFSEntry CreateFsEntry(string path)
        {
            var nativeFsEntry = AllegroLibrary.AlCreateFsEntry(path);
            return nativeFsEntry == IntPtr.Zero ? null : new AllegroFSEntry { NativeIntPtr = nativeFsEntry };
        }

        public static void DestroyFSEntry(AllegroFSEntry fsEntry) =>
            AllegroLibrary.AlDestroyFsEntry(fsEntry.NativeIntPtr);

        public static string GetFSEntryName(AllegroFSEntry fsEntry)
        {
            var nativeString = AllegroLibrary.AlGetFsEntryName(fsEntry.NativeIntPtr);
            return nativeString == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(nativeString);
        }

        public static bool UpdateFSEntry(AllegroFSEntry fsEntry) =>
            AllegroLibrary.AlUpdateFsEntry(fsEntry.NativeIntPtr);

        public static FileMode GetFSEntryMode(AllegroFSEntry fsEntry) =>
            (FileMode)AllegroLibrary.AlGetFsEntryMode(fsEntry.NativeIntPtr);

        public static long GetFSEntryATime(AllegroFSEntry fsEntry) =>
            AllegroLibrary.AlGetFsEntryAtime(fsEntry.NativeIntPtr);

        public static long GetFSEntryCTime(AllegroFSEntry fsEntry) =>
            AllegroLibrary.AlGetFsEntryCtime(fsEntry.NativeIntPtr);

        public static long GetFSEntryMTime(AllegroFSEntry fsEntry) =>
            AllegroLibrary.AlGetFsEntryMode(fsEntry.NativeIntPtr);

        public static long GetFSEntrySize(AllegroFSEntry fsEntry) =>
            AllegroLibrary.AlGetFsEntrySize(fsEntry.NativeIntPtr);

        public static bool FSEntryExists(AllegroFSEntry fsEntry) =>
            AllegroLibrary.AlFsEntryExists(fsEntry.NativeIntPtr);

        public static bool RemoveFSEntry(AllegroFSEntry fsEntry) =>
            AllegroLibrary.AlRemoveFsEntry(fsEntry.NativeIntPtr);

        public static bool FilenameExists(string path) =>
            AllegroLibrary.AlFilenameExists(path);

        public static bool RemoveFilename(string path) =>
            AllegroLibrary.AlRemoveFilename(path);

        public static bool OpenDirectory(AllegroFSEntry fsEntry) =>
            AllegroLibrary.AlOpenDirectory(fsEntry.NativeIntPtr);

        public static AllegroFSEntry ReadDirectory(AllegroFSEntry fsEntry)
        {
            var nativeFSEntry = AllegroLibrary.AlReadDirectory(fsEntry.NativeIntPtr);
            return nativeFSEntry == IntPtr.Zero ? null : new AllegroFSEntry { NativeIntPtr = nativeFSEntry };
        }

        public static bool CloseDirectory(AllegroFSEntry fsEntry) =>
            AllegroLibrary.AlCloseDirectory(fsEntry.NativeIntPtr);

        public static string GetCurrentDirectory()
        {
            var nativeString = AllegroLibrary.AlGetCurrentDirectory();
            return nativeString == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(nativeString);
        }

        public static bool ChangeDirectory(string path) =>
            AllegroLibrary.AlChangeDirectory(path);

        public static bool MakeDirectory(string path) =>
            AllegroLibrary.AlMakeDirectory(path);

        public static AllegroFile OpenFSEntry(AllegroFSEntry fsEntry, string mode)
        {
            var nativeFile = AllegroLibrary.AlOpenFsEntry(fsEntry.NativeIntPtr, mode);
            return nativeFile == IntPtr.Zero ? null : new AllegroFile { NativeIntPtr = nativeFile };
        }

        public static int ForEachFSEntry(AllegroFSEntry fsEntry, AlConstants.ForEachFSEntryCallback callback, IntPtr extra) =>
            AllegroLibrary.AlForEachFsEntry(fsEntry.NativeIntPtr, callback, extra);

        public static void SetFSInterface(AllegroFSInterface fsInterface) =>
            AllegroLibrary.AlSetFsInterface(fsInterface.NativeIntPtr);

        public static void SetStandardFSInterface() =>
            AllegroLibrary.AlSetStandardFsInterface();

        public static AllegroFSInterface GetFSInterface()
        {
            var nativeFSInterface = AllegroLibrary.AlGetFsInterface();
            return nativeFSInterface == IntPtr.Zero ? null : new AllegroFSInterface { NativeIntPtr = nativeFSInterface };
        }

        #region P/Invokes
        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_create_fs_entry([MarshalAs(UnmanagedType.LPStr)] string path);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_destroy_fs_entry(IntPtr fh);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_get_fs_entry_name(IntPtr e);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern bool al_update_fs_entry(IntPtr e);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern uint al_get_fs_entry_mode(IntPtr e);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern long al_get_fs_entry_atime(IntPtr e);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern long al_get_fs_entry_ctime(IntPtr e);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern long al_get_fs_entry_mtime(IntPtr e);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern long al_get_fs_entry_size(IntPtr e);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern bool al_fs_entry_exists(IntPtr e);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern bool al_remove_fs_entry(IntPtr e);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern bool al_filename_exists([MarshalAs(UnmanagedType.LPStr)] string path);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern bool al_remove_filename([MarshalAs(UnmanagedType.LPStr)] string path);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern bool al_open_directory(IntPtr e);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_read_directory(IntPtr e);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern bool al_close_directory(IntPtr e);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_get_current_directory();

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern bool al_change_directory([MarshalAs(UnmanagedType.LPStr)] string path);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern bool al_make_directory([MarshalAs(UnmanagedType.LPStr)] string path);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_open_fs_entry(IntPtr e, [MarshalAs(UnmanagedType.LPStr)] string mode);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern int al_for_each_fs_entry(IntPtr dir, ForEachFSEntryCallback callback, IntPtr extra);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_set_fs_interface(IntPtr fs_interface);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern void al_set_standard_fs_interface();

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //private static extern IntPtr al_get_fs_interface();
        #endregion
    }
}
