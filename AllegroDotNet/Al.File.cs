using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using AllegroDotNet.Enums;
using AllegroDotNet.Models;

namespace AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
        /// <summary>
        /// Creates and opens a file (real or virtual) given the path and mode. The current file interface is used to
        /// open the file.
        /// <para>
        /// Depending on the stream type and the mode string, files may be opened in “text” mode. The
        /// handling of newlines is particularly important. For example, using the default stdio-based streams on DOS
        /// and Windows platforms, where the native end-of-line terminators are CR+LF sequences, a call to al_fgetc
        /// may return just one character (‘\n’) where there were two bytes (CR+LF) in the file. When writing out
        /// ‘\n’, two bytes would be written instead. (As an aside, ‘\n’ is not defined to be equal to LF either.)
        /// </para>
        /// <para>
        /// Newline translations can be useful for text files but is disastrous for binary files. To avoid this
        /// behaviour you need to open file streams in binary mode by using a mode argument containing a “b”, e.g.
        /// “rb”, “wb”.
        /// </para>
        /// </summary>
        /// <param name="path">Path to the file to open.</param>
        /// <param name="mode">Access mode to open the file in ("r", "w", etc).</param>
        /// <returns>Returns a file handle on success, or NULL on error.</returns>
        public static AllegroFile FOpen(string path, string mode)
        {
            var nativeFile = al_fopen(path, mode);
            return nativeFile == IntPtr.Zero ? null : new AllegroFile { NativeIntPtr = nativeFile };
        }

        //public static AllegroFile FOpenInterface(out AllegroFileInterface fileInterface, string path, string mode)
        //{

        //}

        #region P/Invokes
        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern IntPtr al_fopen(
            [MarshalAs(UnmanagedType.LPStr)] string path,
            [MarshalAs(UnmanagedType.LPStr)] string mode);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern IntPtr al_fopen_interface(
            IntPtr drv,
            [MarshalAs(UnmanagedType.LPStr)] string path,
            [MarshalAs(UnmanagedType.LPStr)] string mode);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern IntPtr al_fopen_slice(
            IntPtr fp,
            IntPtr initialSize,
            [MarshalAs(UnmanagedType.LPStr)] string mode);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern bool al_fclose(IntPtr f);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern IntPtr al_fread(IntPtr f, IntPtr ptr, IntPtr size);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern IntPtr al_fwrite(IntPtr f, IntPtr ptr, IntPtr size);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern bool al_fflush(IntPtr f);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern long al_ftell(IntPtr f);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern bool al_fseek(IntPtr f, long offset, Seek whence);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern bool al_feof(IntPtr f);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern int al_ferror(IntPtr f);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern IntPtr al_ferrmsg(IntPtr f);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern void al_fclearerr(IntPtr f);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern int al_fungetc(IntPtr f, int c);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern long al_fsize(IntPtr f);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern int al_fgetc(IntPtr f);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern int al_fputc(IntPtr f, int c);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern int al_fprintf(IntPtr pfile, [MarshalAs(UnmanagedType.LPStr)] string format, __arglist);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern short al_fread16le(IntPtr f);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern short al_fread16be(IntPtr f);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern IntPtr al_fwrite16le(IntPtr f, short w);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern IntPtr al_fwrite16be(IntPtr f, short w);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern int al_fread32le(IntPtr f);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern int al_fread32be(IntPtr f);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern IntPtr al_fwrite32le(IntPtr f, int l);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern IntPtr al_fwrite32be(IntPtr f, int l);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern IntPtr al_fgets(IntPtr f, IntPtr buf, IntPtr max);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern IntPtr al_fget_ustr(IntPtr f);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern int al_fputs(IntPtr f, IntPtr p);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern IntPtr al_fopen_fd(int fd, IntPtr mode);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern IntPtr al_make_temp_file(IntPtr template, out IntPtr ret_path);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern void al_set_new_file_interface(IntPtr file_interface);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern void al_set_standard_file_interface();

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern IntPtr al_get_new_file_interface();

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern IntPtr al_create_file_handle(IntPtr drv, int userdata);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern void al_get_file_userdata(IntPtr f);
        #endregion
    }
}
