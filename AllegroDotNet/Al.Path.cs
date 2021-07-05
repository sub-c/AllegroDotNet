using System;
using System.Runtime.InteropServices;
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
        /// Create a path structure from a string. The last component, if it is followed by a directory separator
        /// and is neither “.” nor “..”, is treated as the last directory name in the path. Otherwise the last
        /// component is treated as the filename. The string may be NULL for an empty path.
        /// </summary>
        /// <param name="pathString">The string to make a path from.</param>
        /// <returns>Null if error, otherwise the path instance.</returns>
        public static AllegroPath CreatePath(string pathString)
        {
            var nativePath = AllegroLibrary.AlCreatePath(pathString);
            return nativePath == IntPtr.Zero ? null : new AllegroPath { NativeIntPtr = nativePath };
        }

        /// <summary>
        /// This is the same as al_create_path, but interprets the passed string as a directory path. The filename component of the returned path will always be empty.
        /// </summary>
        /// <param name="pathString">The string to make a path from.</param>
        /// <returns>Null if error, otherwise the path instance.</returns>
        public static AllegroPath CreatePathForDirectory(string pathString)
        {
            var nativePath = AllegroLibrary.AlCreatePathForDirectory(pathString);
            return nativePath == IntPtr.Zero ? null : new AllegroPath { NativeIntPtr = nativePath };
        }

        /// <summary>
        /// Free a path structure.
        /// </summary>
        /// <param name="path">The path instance to destroy.</param>
        public static void DestroyPath(AllegroPath path) =>
            AllegroLibrary.AlDestroyPath(path.NativeIntPtr);

        /// <summary>
        /// Clones an <see cref="AllegroPath"/> structure.
        /// </summary>
        /// <param name="path">The path to clone.</param>
        /// <returns>Null on failure, otherwise the clone path instance.</returns>
        public static AllegroPath ClonePath(AllegroPath path)
        {
            var nativePath = AllegroLibrary.AlClonePath(path.NativeIntPtr);
            return nativePath == IntPtr.Zero ? null : new AllegroPath { NativeIntPtr = nativePath };
        }

        /// <summary>
        /// Concatenate two path structures. The first path structure is modified. If ‘tail’ is an absolute path,
        /// this function does nothing.
        /// <para>
        /// If ‘tail’ is a relative path, all of its directory components will be appended to ‘path’. tail’s filename
        /// will also overwrite path’s filename, even if it is just the empty string.
        /// </para>
        /// <para>
        /// Tail’s drive is ignored.
        /// </para>
        /// </summary>
        /// <param name="path">The path to add to/modify.</param>
        /// <param name="tail">The path to add from.</param>
        /// <returns>
        /// True if ‘tail’ was a relative path and so concatenated to ‘path’, otherwise returns false.
        /// </returns>
        public static bool JoinPaths(AllegroPath path, AllegroPath tail) =>
            AllegroLibrary.AlJoinPaths(path.NativeIntPtr, tail.NativeIntPtr);

        /// <summary>
        /// Concatenate two path structures, modifying the second path structure. If tail is an absolute path,
        /// this function does nothing. Otherwise, the drive and path components in head are inserted at the start of
        /// tail.
        /// <para>
        /// For example, if head is “/anchor/” and tail is “data/file.ext”, then after the call tail becomes
        /// “/anchor/data/file.ext”.
        /// </para>
        /// </summary>
        /// <param name="head">The head of the path.</param>
        /// <param name="tail">The path to add to the head.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public static bool RebasePath(AllegroPath head, AllegroPath tail) =>
            AllegroLibrary.AlRebasePath(head.NativeIntPtr, tail.NativeIntPtr);

        /// <summary>
        /// Return the drive letter on a path, or the empty string if there is none.
        /// The “drive letter” is only used on Windows, and is usually a string like “c:”, but may be something
        /// like “\\Computer Name” in the case of UNC (Uniform Naming Convention) syntax.
        /// </summary>
        /// <param name="path">The path instance.</param>
        /// <returns>Empty string if no drive in the path, otherwise the drive letter on the path.</returns>
        public static string GetPathDrive(AllegroPath path) =>
            Marshal.PtrToStringAnsi(AllegroLibrary.AlGetPathDrive(path.NativeIntPtr));

        /// <summary>
        /// Return the number of directory components in a path.
        /// The directory components do not include the final part of a path (the filename).
        /// </summary>
        /// <param name="path">The path instance.</param>
        /// <returns>The number of directory components.</returns>
        public static int GetPathNumComponents(AllegroPath path) =>
            AllegroLibrary.AlGetPathNumComponents(path.NativeIntPtr);

        /// <summary>
        /// Return the i’th directory component of a path, counting from zero. If the index is negative then count
        /// from the right, i.e. -1 refers to the last path component. It is an error to pass an index which is out
        /// of bounds.
        /// </summary>
        /// <param name="path">The path instance.</param>
        /// <param name="i">The component index, starting from zero.</param>
        /// <returns>The path component as a string.</returns>
        public static string GetPathComponent(AllegroPath path, int i) =>
            Marshal.PtrToStringAnsi(AllegroLibrary.AlGetPathComponent(path.NativeIntPtr, i));

        /// <summary>
        /// Returns the last directory component, or NULL if there are no directory components.
        /// </summary>
        /// <param name="path">The path component.</param>
        /// <returns>Null if no directory components, otherwise the last directory component.</returns>
        public static string GetPathTail(AllegroPath path) =>
            Marshal.PtrToStringAnsi(AllegroLibrary.AlGetPathTail(path.NativeIntPtr));

        /// <summary>
        /// Return the filename part of the path, or the empty string if there is none. The returned pointer is
        /// valid only until the filename part of the path is modified in any way, or until the path is destroyed.
        /// </summary>
        /// <param name="path">The path instance.</param>
        /// <returns>Empty string if no filename in path, otherwise the filename of the path.</returns>
        public static string GetPathFilename(AllegroPath path) =>
            Marshal.PtrToStringAnsi(AllegroLibrary.AlGetPathFilename(path.NativeIntPtr));

        /// <summary>
        /// Return the basename, i.e. filename with the extension removed. If the filename doesn’t have an extension,
        /// the whole filename is the basename. If there is no filename part then the empty string is returned.
        /// <para>
        /// The returned pointer is valid only until the filename part of the path is modified in any way, or until
        /// the path is destroyed.
        /// </para>
        /// </summary>
        /// <param name="path">The path instance.</param>
        /// <returns>The filename with extension renmoved, otherwise an empty string.</returns>
        public static string GetPathBasename(AllegroPath path) =>
            Marshal.PtrToStringAnsi(AllegroLibrary.AlGetPathBasename(path.NativeIntPtr));

        /// <summary>
        /// Return a pointer to the start of the extension of the filename, i.e. everything from the final dot (‘.’)
        /// character onwards. If no dot exists, returns an empty string.
        /// <para>
        /// The returned pointer is valid only until the filename part of the path is modified in any way, or until
        /// the path is destroyed.
        /// </para>
        /// </summary>
        /// <param name="path">The path instance.</param>
        /// <returns>The filename with only the extension, otherwise an empty string.</returns>
        public static string GetPathExtension(AllegroPath path) =>
            Marshal.PtrToStringAnsi(AllegroLibrary.AlGetPathExtension(path.NativeIntPtr));

        /// <summary>
        /// Set the drive string on a path. The drive may be NULL, which is equivalent to setting the drive
        /// string to the empty string.
        /// </summary>
        /// <param name="path">The path instance.</param>
        /// <param name="drive">The drive to set.</param>
        public static void SetPathDrive(AllegroPath path, string drive) =>
            AllegroLibrary.AlSetPathDrive(path.NativeIntPtr, drive);

        /// <summary>
        /// Append a directory component.
        /// </summary>
        /// <param name="path">The path instance.</param>
        /// <param name="componentString">The component string to append.</param>
        public static void AppendPathComponent(AllegroPath path, string componentString) =>
            AllegroLibrary.AlAppendPathComponent(path.NativeIntPtr, componentString);

        /// <summary>
        /// Insert a directory component at index i. If the index is negative then count from the right, i.e. -1
        /// refers to the last path component. It is an error to pass an index i which is not within these bounds:
        /// 0 &lt;= i &lt;= <see cref="GetPathNumComponents(AllegroPath)"/>.
        /// </summary>
        /// <param name="path">The path instance.</param>
        /// <param name="i">The component index.</param>
        /// <param name="componentString">The component to insert.</param>
        public static void InsertPathComponent(AllegroPath path, int i, string componentString) =>
            AllegroLibrary.AlInsertPathComponent(path.NativeIntPtr, i, componentString);

        /// <summary>
        /// Replace the i’th directory component by another string. If the index is negative then count from the right,
        /// i.e. -1 refers to the last path component. It is an error to pass an index which is out of bounds.
        /// </summary>
        /// <param name="path">The path instance.</param>
        /// <param name="i">The index to replace over.</param>
        /// <param name="componentString">The component to replace with.</param>
        public static void ReplacePathComponent(AllegroPath path, int i, string componentString) =>
            AllegroLibrary.AlReplacePathComponent(path.NativeIntPtr, i, componentString);

        /// <summary>
        /// Delete the i’th directory component. If the index is negative then count from the right, i.e. -1 refers to
        /// the last path component. It is an error to pass an index which is out of bounds.
        /// </summary>
        /// <param name="path">The path instance.</param>
        /// <param name="i">The index to delete.</param>
        public static void RemovePathComponent(AllegroPath path, int i) =>
            AllegroLibrary.AlRemovePathComponent(path.NativeIntPtr, i);

        /// <summary>
        /// Remove the last directory component, if any.
        /// </summary>
        /// <param name="path">The path instance.</param>
        public static void DropPathTail(AllegroPath path) =>
            AllegroLibrary.AlDropPathTail(path.NativeIntPtr);

        /// <summary>
        /// Set the optional filename part of the path. The filename may be NULL, which is equivalent to setting
        /// the filename to the empty string.
        /// </summary>
        /// <param name="path">The path instance.</param>
        /// <param name="filename">The filename to set.</param>
        public static void SetPathFilename(AllegroPath path, string filename) =>
            AllegroLibrary.AlSetPathFilename(path.NativeIntPtr, filename);

        /// <summary>
        /// Replaces the extension of the path with the given one, i.e. replaces everything from the final dot (‘.’)
        /// character onwards, including the dot. If the filename of the path has no extension, the given one is
        /// appended. Usually the new extension you supply should include a leading dot.
        /// </summary>
        /// <param name="path">The path instance.</param>
        /// <param name="extension">The extension to set.</param>
        /// <returns>False if the path contains no filename part, i.e. the filename part is the empty string.</returns>
        public static bool SetPathExtension(AllegroPath path, string extension) =>
            AllegroLibrary.AlSetPathExtension(path.NativeIntPtr, extension);

        /// <summary>
        /// Convert a path to its string representation, i.e. optional drive, followed by directory components
        /// separated by ‘delim’, followed by an optional filename.
        /// <para>
        /// The returned pointer is valid only until the path is modified in any way, or until the path is destroyed.
        /// This returns a null-terminated string. If you need an ALLEGRO_USTR instead, use al_path_ustr.
        /// </para>
        /// </summary>
        /// <param name="path">The path instance.</param>
        /// <param name="delim">Use <c>Constants.AllegroNativePathSep</c>, unless you want a custom separator.</param>
        /// <returns>The string version of the path.</returns>
        public static string PathCStr(AllegroPath path, char delim)
        {
            var nativeString = AllegroLibrary.AlPathCstr(path.NativeIntPtr, delim);
            return nativeString == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(nativeString);
        }

        /// <summary>
        /// Convert a path to its string representation, i.e. optional drive, followed by directory components
        /// separated by ‘delim’, followed by an optional filename.
        /// <para>
        /// The returned pointer is valid only until the path is modified in any way, or until the path is destroyed.
        /// This returns an ALLEGRO_USTR. If you need a null-terminated string instead, use al_path_cstr.
        /// </para>
        /// </summary>
        /// <param name="path">The path instance.</param>
        /// <param name="delim">Use <c>Constants.AllegroNativePathSep</c>, unless you want a custom separator.</param>
        /// <returns>The string version of the path.</returns>
        public static string PathUStr(AllegroPath path, char delim)
        {
            var nativeString = AllegroLibrary.AlPathUstr(path.NativeIntPtr, delim);
            return nativeString == IntPtr.Zero ? null : Marshal.PtrToStringUni(nativeString);
        }

        /// <summary>
        /// Removes any leading ‘..’ directory components in absolute paths. Removes all ‘.’ directory components.
        /// <para>
        /// Note that this does not collapse “x/../y” sections into “y”. This is by design. If “/foo” on your system
        /// is a symlink to “/bar/baz”, then “/foo/../quux” is actually “/bar/quux”, not “/quux” as a naive removal
        /// of “..” components would give you.
        /// </para>
        /// </summary>
        /// <param name="path">The path instance.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public static bool MakePathCanonical(AllegroPath path) =>
            AllegroLibrary.AlMakePathCanonical(path.NativeIntPtr);

        #region P/Invokes
        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //public static extern IntPtr al_create_path([MarshalAs(UnmanagedType.LPStr)] string str);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //public static extern IntPtr al_create_path_for_directory([MarshalAs(UnmanagedType.LPStr)] string str);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //public static extern void al_destroy_path(IntPtr path);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //public static extern IntPtr al_clone_path(IntPtr path);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //public static extern bool al_join_paths(IntPtr path, IntPtr tail);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //public static extern bool al_rebase_path(IntPtr head, IntPtr tail);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //public static extern IntPtr al_get_path_drive(IntPtr path);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //public static extern int al_get_path_num_components(IntPtr path);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //public static extern IntPtr al_get_path_component(IntPtr path, int i);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //public static extern IntPtr al_get_path_tail(IntPtr path);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //public static extern IntPtr al_get_path_filename(IntPtr path);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //public static extern IntPtr al_get_path_basename(IntPtr path);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //public static extern IntPtr al_get_path_extension(IntPtr path);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //public static extern void al_set_path_drive(IntPtr path, [MarshalAs(UnmanagedType.LPStr)] string drive);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //public static extern void al_append_path_component(IntPtr path, [MarshalAs(UnmanagedType.LPStr)] string s);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //public static extern void al_insert_path_component(IntPtr path, int i, [MarshalAs(UnmanagedType.LPStr)] string s);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //public static extern void al_replace_path_component(IntPtr path, int i, [MarshalAs(UnmanagedType.LPStr)] string s);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //public static extern void al_remove_path_component(IntPtr path, int i);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //public static extern void al_drop_path_tail(IntPtr path);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //public static extern void al_set_path_filename(IntPtr path, [MarshalAs(UnmanagedType.LPStr)] string filename);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //public static extern bool al_set_path_extension(IntPtr path, [MarshalAs(UnmanagedType.LPStr)] string extension);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //public static extern IntPtr al_path_cstr(IntPtr path, char delim);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //public static extern IntPtr al_path_ustr(IntPtr path, char delim);

        //[DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        //public static extern bool al_make_path_canonical(IntPtr path);
        #endregion
    }
}
