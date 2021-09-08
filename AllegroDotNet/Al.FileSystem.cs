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
        /// <summary>
        /// Creates an <see cref="AllegroFSEntry"/> object pointing to path on the filesystem. ‘path’ can be a file or
        /// a directory and must not be <c>null</c>.
        /// </summary>
        /// <param name="path">A file or directory.</param>
        /// <returns>The FS Entry instance on success, otherwise null.</returns>
        public static AllegroFSEntry CreateFsEntry(string path)
        {
            var nativeFsEntry = AllegroLibrary.AlCreateFsEntry(path);
            return nativeFsEntry == IntPtr.Zero ? null : new AllegroFSEntry { NativeIntPtr = nativeFsEntry };
        }

        /// <summary>
        /// Destroys a fs entry handle. The file or directory represented by it is not destroyed. If the entry was
        /// opened, it is closed before being destroyed.
        /// </summary>
        /// <param name="fsEntry">The FS Entry instance.</param>
        public static void DestroyFSEntry(AllegroFSEntry fsEntry) =>
            AllegroLibrary.AlDestroyFsEntry(fsEntry.NativeIntPtr);

        /// <summary>
        /// Returns the entry’s filename path. Note that the filesystem encoding may not be known and the conversion
        /// to UTF-8 could in very rare cases cause this to return an invalid path. Therefore it’s always safest to
        /// access the file over its <see cref="AllegroFSEntry"/> and not the path.
        /// </summary>
        /// <param name="fsEntry">The FS Entry instance.</param>
        /// <returns>
        /// On success returns a read only string which you must not modify or destroy. Returns <c>null</c> on failure.
        /// </returns>
        public static string GetFSEntryName(AllegroFSEntry fsEntry)
        {
            var nativeString = AllegroLibrary.AlGetFsEntryName(fsEntry.NativeIntPtr);
            return nativeString == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(nativeString);
        }

        /// <summary>
        /// Updates file status information for a filesystem entry. File status information is automatically updated
        /// when the entry is created, however you may update it again with this function, e.g. in case it changed.
        /// </summary>
        /// <param name="fsEntry">The FS Entry instance.</param>
        /// <returns>
        /// Returns true on success, false on failure. Fills in errno to indicate the error.
        /// </returns>
        public static bool UpdateFSEntry(AllegroFSEntry fsEntry) =>
            AllegroLibrary.AlUpdateFsEntry(fsEntry.NativeIntPtr);

        /// <summary>
        /// Returns the entry’s mode flags, i.e. permissions and whether the entry refers to a file or directory.
        /// </summary>
        /// <param name="fsEntry">The FS Entry instance.</param>
        /// <returns>
        /// Returns the entry’s mode flags, i.e. permissions and whether the entry refers to a file or directory.
        /// </returns>
        public static FileMode GetFSEntryMode(AllegroFSEntry fsEntry) =>
            (FileMode)AllegroLibrary.AlGetFsEntryMode(fsEntry.NativeIntPtr);

        /// <summary>
        /// Returns the time in seconds since the epoch since the entry was last accessed. Warning: some filesystems
        /// either don’t support this flag, or people turn it off to increase performance. It may not be valid in all
        /// circumstances.
        /// </summary>
        /// <param name="fsEntry">The FS Entry instance.</param>
        /// <returns>Returns the time in seconds since the epoch since the entry was last accessed.</returns>
        public static long GetFSEntryATime(AllegroFSEntry fsEntry) =>
            AllegroLibrary.AlGetFsEntryAtime(fsEntry.NativeIntPtr);

        /// <summary>
        /// Returns the time in seconds since the epoch this entry was created on the filesystem.
        /// </summary>
        /// <param name="fsEntry">The FS Entry instance.</param>
        /// <returns>
        /// Returns the time in seconds since the epoch this entry was created on the filesystem.
        /// </returns>
        public static long GetFSEntryCTime(AllegroFSEntry fsEntry) =>
            AllegroLibrary.AlGetFsEntryCtime(fsEntry.NativeIntPtr);

        /// <summary>
        /// Returns the time in seconds since the epoch since the entry was last modified.
        /// </summary>
        /// <param name="fsEntry">The FS Entry instance.</param>
        /// <returns>
        /// Returns the time in seconds since the epoch since the entry was last modified.
        /// </returns>
        public static long GetFSEntryMTime(AllegroFSEntry fsEntry) =>
            AllegroLibrary.AlGetFsEntryMode(fsEntry.NativeIntPtr);

        /// <summary>
        /// Returns the size, in bytes, of the given entry. May not return anything sensible for a directory entry.
        /// </summary>
        /// <param name="fsEntry">The FS Entry instance.</param>
        /// <returns>
        /// Returns the size, in bytes, of the given entry. May not return anything sensible for a directory entry.
        /// </returns>
        public static long GetFSEntrySize(AllegroFSEntry fsEntry) =>
            AllegroLibrary.AlGetFsEntrySize(fsEntry.NativeIntPtr);

        /// <summary>
        /// Check if the given entry exists on in the filesystem. Returns true if it does exist or false if it doesn’t
        /// exist, or an error occurred. Error is indicated in Allegro’s errno.
        /// </summary>
        /// <param name="fsEntry">The FS Entry instance.</param>
        /// <returns>True if it does exist or false if it doesn’t exist, or an error occurred.</returns>
        public static bool FSEntryExists(AllegroFSEntry fsEntry) =>
            AllegroLibrary.AlFsEntryExists(fsEntry.NativeIntPtr);

        /// <summary>
        /// Delete this filesystem entry from the filesystem. Only files and empty directories may be deleted.
        /// </summary>
        /// <param name="fsEntry">The FS Entry instance.</param>
        /// <returns>
        /// Returns true on success, and false on failure, error is indicated in Allegro’s errno.
        /// </returns>
        public static bool RemoveFSEntry(AllegroFSEntry fsEntry) =>
            AllegroLibrary.AlRemoveFsEntry(fsEntry.NativeIntPtr);

        /// <summary>
        /// Check if the path exists on the filesystem, without creating an <see cref="AllegroFSEntry"/> object
        /// explicitly.
        /// </summary>
        /// <param name="path">The path to check.</param>
        /// <returns>True if the path exists, otherwise false.</returns>
        public static bool FilenameExists(string path) =>
            AllegroLibrary.AlFilenameExists(path);

        /// <summary>
        /// Delete the given path from the filesystem, which may be a file or an empty directory. This is the same as
        /// <see cref="RemoveFSEntry(AllegroFSEntry)"/>, except it expects the path as a string.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>
        /// True on success, and false on failure. Allegro’s errno is filled in to indicate the error.
        /// </returns>
        public static bool RemoveFilename(string path) =>
            AllegroLibrary.AlRemoveFilename(path);

        /// <summary>
        /// Opens a directory entry object. You must call this before using
        /// <see cref="ReadDirectory(AllegroFSEntry)"/> on an entry and you must call
        /// <see cref="CloseDirectory(AllegroFSEntry)"/> when you no longer need it.
        /// </summary>
        /// <param name="fsEntry">The FS Entry instance.</param>
        /// <returns>Returns true on success, otherwise false.</returns>
        public static bool OpenDirectory(AllegroFSEntry fsEntry) =>
            AllegroLibrary.AlOpenDirectory(fsEntry.NativeIntPtr);

        /// <summary>
        /// Reads the next directory item and returns a filesystem entry for it. Returns NULL if there are no more
        /// entries or if an error occurs. Call <see cref="DestroyFSEntry(AllegroFSEntry)"/> on the returned entry
        /// when you are done with it. This function will ignore any files or directories named . or .. which may
        /// exist on certain platforms and may signify the current and the parent directory.
        /// </summary>
        /// <param name="fsEntry">The FS Entry.</param>
        /// <returns>Null if there are no more entries or error occurs, otherwise the next directory item.</returns>
        public static AllegroFSEntry ReadDirectory(AllegroFSEntry fsEntry)
        {
            var nativeFSEntry = AllegroLibrary.AlReadDirectory(fsEntry.NativeIntPtr);
            return nativeFSEntry == IntPtr.Zero ? null : new AllegroFSEntry { NativeIntPtr = nativeFSEntry };
        }

        /// <summary>
        /// Closes a previously opened directory entry object.
        /// </summary>
        /// <param name="fsEntry">The FS Entry instance.</param>
        /// <returns>
        /// Returns true on success, false on failure and fills in Allegro’s errno to indicate the error.
        /// </returns>
        public static bool CloseDirectory(AllegroFSEntry fsEntry) =>
            AllegroLibrary.AlCloseDirectory(fsEntry.NativeIntPtr);

        /// <summary>
        /// Returns the path to the current working directory, or <c>null</c> on failure. The returned path is
        /// dynamically allocated and must be destroyed with <see cref="Free(IntPtr, int, string, string)"/>.
        /// Allegro’s errno is filled in to indicate the error if there is a failure. This function may not be
        /// implemented on some (virtual) filesystems.
        /// </summary>
        /// <returns>Path to the current working directory, otherwise <c>null</c>.</returns>
        public static string GetCurrentDirectory()
        {
            var nativeString = AllegroLibrary.AlGetCurrentDirectory();
            return nativeString == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(nativeString);
        }

        /// <summary>
        /// Changes the current working directory to ‘path’.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>Returns true on success, false on error.</returns>
        public static bool ChangeDirectory(string path) =>
            AllegroLibrary.AlChangeDirectory(path);

        /// <summary>
        /// Creates a new directory on the filesystem. This function also creates any parent directories as needed.
        /// </summary>
        /// <param name="path">The directory path.</param>
        /// <returns>
        /// Returns true on success (including if the directory already exists), otherwise returns false on error.
        /// Fills in Allegro’s errno to indicate the error.
        /// </returns>
        public static bool MakeDirectory(string path) =>
            AllegroLibrary.AlMakeDirectory(path);

        /// <summary>
        /// Open an <see cref="AllegroFile"/> handle to a filesystem entry, for the given access mode. This is like
        /// calling <see cref="FOpen(string, string)"/> with the name of the filesystem entry, but uses the appropriate
        /// file interface, not whatever was set with the latest call to
        /// <see cref="SetNewFileInterface(AllegroFileInterface)"/>.
        /// </summary>
        /// <param name="fsEntry">The FS Entry instance.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>Returns the handle on success, <c>null</c> on error.</returns>
        public static AllegroFile OpenFSEntry(AllegroFSEntry fsEntry, string mode)
        {
            var nativeFile = AllegroLibrary.AlOpenFsEntry(fsEntry.NativeIntPtr, mode);
            return nativeFile == IntPtr.Zero ? null : new AllegroFile { NativeIntPtr = nativeFile };
        }

        /// <summary>
        /// This function takes the <see cref="AllegroFSEntry"/> dir, which should represent a directory, and looks for
        /// any other file system entries that are in it. This function will then call the callback function callback
        /// once for every filesystem entry in the directory dir.
        /// <para>
        /// This function will skip any files or directories named . or .. which may exist on certain platforms and may
        /// signify the current and the parent directory. The callback will not be called for files or directories with
        /// such a name.
        /// </para>
        /// </summary>
        /// <param name="fsEntry">The FS Entry instance.</param>
        /// <param name="callback">The callback method.</param>
        /// <param name="extra">Extra data parameter passed to each call to the callback method.</param>
        /// <returns></returns>
        public static ForEachFSEntryResult ForEachFSEntry(
            AllegroFSEntry fsEntry,
            AlConstants.ForEachFSEntryCallback callback,
            IntPtr extra) =>
            (ForEachFSEntryResult)AllegroLibrary.AlForEachFsEntry(fsEntry.NativeIntPtr, callback, extra);

        /// <summary>
        /// Set the <see cref="AllegroFSInterface"/> table for the calling thread.
        /// </summary>
        /// <param name="fsInterface">The FS Interface instance.</param>
        public static void SetFSInterface(AllegroFSInterface fsInterface) =>
            AllegroLibrary.AlSetFsInterface(fsInterface.NativeIntPtr);

        /// <summary>
        /// Return the <see cref="AllegroFSInterface"/> table to the default, for the calling thread.
        /// </summary>
        public static void SetStandardFSInterface() =>
            AllegroLibrary.AlSetStandardFsInterface();

        /// <summary>
        /// Return a pointer to the <see cref="AllegroFSInterface"/> table in effect for the calling thread.
        /// </summary>
        /// <returns>The FS Interface instance on success, otherwise <c>null</c>.</returns>
        public static AllegroFSInterface GetFSInterface()
        {
            var nativeFSInterface = AllegroLibrary.AlGetFsInterface();
            return nativeFSInterface == IntPtr.Zero ? null : new AllegroFSInterface { NativeIntPtr = nativeFSInterface };
        }
    }
}
