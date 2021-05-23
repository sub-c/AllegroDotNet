using System;
using System.Runtime.InteropServices;
using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;

namespace SubC.AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int ForEachFSEntryCallback(IntPtr dir, IntPtr extra);

        public static AllegroFSEntry CreateFsEntry(string path)
        {
            var nativeFsEntry = al_create_fs_entry(path);
            return nativeFsEntry == IntPtr.Zero ? null : new AllegroFSEntry { NativeIntPtr = nativeFsEntry };
        }

        public static void DestroyFSEntry(AllegroFSEntry fsEntry)
            => al_destroy_fs_entry(fsEntry.NativeIntPtr);

        public static string GetFSEntryName(AllegroFSEntry fsEntry)
        {
            var nativeString = al_get_fs_entry_name(fsEntry.NativeIntPtr);
            return nativeString == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(nativeString);
        }

        public static bool UpdateFSEntry(AllegroFSEntry fsEntry)
            => al_update_fs_entry(fsEntry.NativeIntPtr);

        public static FileMode GetFSEntryMode(AllegroFSEntry fsEntry)
            => (FileMode)al_get_fs_entry_mode(fsEntry.NativeIntPtr);

        public static long GetFSEntryATime(AllegroFSEntry fsEntry)
            => al_get_fs_entry_atime(fsEntry.NativeIntPtr);

        public static long GetFSEntryCTime(AllegroFSEntry fsEntry)
            => al_get_fs_entry_ctime(fsEntry.NativeIntPtr);

        public static long GetFSEntryMTime(AllegroFSEntry fsEntry)
            => al_get_fs_entry_mtime(fsEntry.NativeIntPtr);

        public static long GetFSEntrySize(AllegroFSEntry fsEntry)
            => al_get_fs_entry_size(fsEntry.NativeIntPtr);

        public static bool FSEntryExists(AllegroFSEntry fsEntry)
            => al_fs_entry_exists(fsEntry.NativeIntPtr);

        public static bool RemoveFSEntry(AllegroFSEntry fsEntry)
            => al_remove_fs_entry(fsEntry.NativeIntPtr);

        public static bool FilenameExists(string path)
            => al_filename_exists(path);

        public static bool RemoveFilename(string path)
            => al_remove_filename(path);

        public static bool OpenDirectory(AllegroFSEntry fsEntry)
            => al_open_directory(fsEntry.NativeIntPtr);

        public static AllegroFSEntry ReadDirectory(AllegroFSEntry fsEntry)
        {
            var nativeFSEntry = al_read_directory(fsEntry.NativeIntPtr);
            return nativeFSEntry == IntPtr.Zero ? null : new AllegroFSEntry { NativeIntPtr = nativeFSEntry };
        }

        public static bool CloseDirectory(AllegroFSEntry fsEntry)
            => al_close_directory(fsEntry.NativeIntPtr);

        public static string GetCurrentDirectory()
        {
            var nativeString = al_get_current_directory();
            return nativeString == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(nativeString);
        }

        public static bool ChangeDirectory(string path)
            => al_change_directory(path);

        public static bool MakeDirectory(string path)
            => al_make_directory(path);

        public static AllegroFile OpenFSEntry(AllegroFSEntry fsEntry, string mode)
        {
            var nativeFile = al_open_fs_entry(fsEntry.NativeIntPtr, mode);
            return nativeFile == IntPtr.Zero ? null : new AllegroFile { NativeIntPtr = nativeFile };
        }

        public static int ForEachFSEntry(AllegroFSEntry fsEntry, ForEachFSEntryCallback callback, IntPtr extra)
            => al_for_each_fs_entry(fsEntry.NativeIntPtr, callback, extra);

        public static void SetFSInterface(AllegroFSInterface fsInterface)
            => al_set_fs_interface(fsInterface.NativeIntPtr);

        public static void SetStandardFSInterface()
            => al_set_standard_fs_interface();

        public static AllegroFSInterface GetFSInterface()
        {
            var nativeFSInterface = al_get_fs_interface();
            return nativeFSInterface == IntPtr.Zero ? null : new AllegroFSInterface { NativeIntPtr = nativeFSInterface };
        }

        #region P/Invokes
        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_create_fs_entry([MarshalAs(UnmanagedType.LPStr)] string path);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_destroy_fs_entry(IntPtr fh);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_get_fs_entry_name(IntPtr e);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_update_fs_entry(IntPtr e);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern uint al_get_fs_entry_mode(IntPtr e);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern long al_get_fs_entry_atime(IntPtr e);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern long al_get_fs_entry_ctime(IntPtr e);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern long al_get_fs_entry_mtime(IntPtr e);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern long al_get_fs_entry_size(IntPtr e);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_fs_entry_exists(IntPtr e);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_remove_fs_entry(IntPtr e);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_filename_exists([MarshalAs(UnmanagedType.LPStr)] string path);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_remove_filename([MarshalAs(UnmanagedType.LPStr)] string path);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_open_directory(IntPtr e);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_read_directory(IntPtr e);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_close_directory(IntPtr e);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_get_current_directory();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_change_directory([MarshalAs(UnmanagedType.LPStr)] string path);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_make_directory([MarshalAs(UnmanagedType.LPStr)] string path);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_open_fs_entry(IntPtr e, [MarshalAs(UnmanagedType.LPStr)] string mode);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_for_each_fs_entry(IntPtr dir, ForEachFSEntryCallback callback, IntPtr extra);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_set_fs_interface(IntPtr fs_interface);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_set_standard_fs_interface();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_get_fs_interface();
        #endregion
    }
}
