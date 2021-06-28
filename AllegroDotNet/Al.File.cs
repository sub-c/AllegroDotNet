using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;

namespace SubC.AllegroDotNet
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

        public static AllegroFile FOpenInterface(AllegroFileInterface inter, string path, string mode)
        {
            var nativeFile = al_fopen_interface(inter.NativeIntPtr, path, mode);
            return nativeFile == IntPtr.Zero ? null : new AllegroFile { NativeIntPtr = nativeFile };
        }

        public static AllegroFile FOpenSlice(AllegroFile file, long initialSize, string mode)
        {
            var nativeFile = al_fopen_slice(file.NativeIntPtr, new IntPtr(initialSize), mode);
            return nativeFile == IntPtr.Zero ? null : new AllegroFile { NativeIntPtr = nativeFile };
        }

        public static bool FClose(AllegroFile file)
            => al_fclose(file.NativeIntPtr);

        public static ulong FRead(AllegroFile file, ref byte[] dataBuffer, ulong dataBufferSize)
            => al_fread(file.NativeIntPtr, ref dataBuffer, new UIntPtr(dataBufferSize)).ToUInt64();

        public static ulong FWrite(AllegroFile file, ref byte[] dataBuffer, ulong size)
            => al_fwrite(file.NativeIntPtr, ref dataBuffer, new UIntPtr(size)).ToUInt64();

        public static bool FFlush(AllegroFile file)
            => al_fflush(file.NativeIntPtr);

        public static long FTell(AllegroFile file)
            => al_ftell(file.NativeIntPtr);

        public static bool FSeek(AllegroFile file, long offset, Seek whence)
            => al_fseek(file.NativeIntPtr, offset, (int)whence);

        public static bool FEoF(AllegroFile file)
            => al_feof(file.NativeIntPtr);

        public static int FError(AllegroFile file)
            => al_ferror(file.NativeIntPtr);

        public static string FErrMsg(AllegroFile file)
        {
            var nativeErrorMessage = al_ferrmsg(file.NativeIntPtr);
            return nativeErrorMessage == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(nativeErrorMessage);
        }

        public static void FClearErr(AllegroFile file)
            => al_fclearerr(file.NativeIntPtr);

        public static int FUnGetC(AllegroFile file, int c)
            => al_fungetc(file.NativeIntPtr, c);

        public static long FSize(AllegroFile file)
            => al_fsize(file.NativeIntPtr);

        public static int FGetC(AllegroFile file)
            => al_fgetc(file.NativeIntPtr);

        public static int FPutC(AllegroFile file, int c)
            => al_fputc(file.NativeIntPtr, c);

        public static int FPrintF(AllegroFile file, string format, params object[] arguments)
        {
            throw new NotImplementedException();
        }

        public static int VFPrintF(AllegroFile file, string format, params object[] arguments)
        {
            throw new NotImplementedException();
        }

        public static short FRead16LE(AllegroFile file)
            => al_fread16le(file.NativeIntPtr);

        public static short FRead16BE(AllegroFile file)
            => al_fread16be(file.NativeIntPtr);

        public static ulong FWrite16LE(AllegroFile file, short w)
            => al_fwrite16le(file.NativeIntPtr, w).ToUInt64();

        public static ulong FWrite16BE(AllegroFile file, short w)
            => al_fwrite16be(file.NativeIntPtr, w).ToUInt64();

        public static int FRead32LE(AllegroFile file)
            => al_fread32le(file.NativeIntPtr);

        public static int FRead32BE(AllegroFile file)
            => al_fread32be(file.NativeIntPtr);

        public static ulong FWrite32LE(AllegroFile file, int l)
            => al_fwrite32le(file.NativeIntPtr, l).ToUInt64();

        public static ulong FWrite32BE(AllegroFile file, int l)
            => al_fwrite32be(file.NativeIntPtr, l).ToUInt64();

        public static string FGetS(AllegroFile file, ref byte[] buffer, ulong max)
        {
            var nativeString = al_fgets(file.NativeIntPtr, ref buffer, new UIntPtr(max));
            return nativeString == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(nativeString);
        }

        public static AllegroUStr FGetUStr(AllegroFile file)
        {
            var nativeUStr = al_fget_ustr(file.NativeIntPtr);
            return nativeUStr == IntPtr.Zero ? null : new AllegroUStr { NativeIntPtr = nativeUStr };
        }

        public static int FPutS(AllegroFile file, string p)
            => al_fputs(file.NativeIntPtr, p);

        public static AllegroFile FOpenFD(int fd, string mode)
        {
            var nativeFile = al_fopen_fd(fd, mode);
            return nativeFile == IntPtr.Zero ? null : new AllegroFile { NativeIntPtr = nativeFile };
        }

        public static AllegroFile MakeTempFile(string template, AllegroPath returnPath)
        {
            IntPtr nativeFile = IntPtr.Zero;
            IntPtr nullIntPtr = IntPtr.Zero;
            if (returnPath == null)
            {
                nativeFile = al_make_temp_file(template, ref nullIntPtr);
            }
            else
            {
                nativeFile = al_make_temp_file(template, ref returnPath.NativeIntPtr);
            }
            return nativeFile == IntPtr.Zero ? null : new AllegroFile { NativeIntPtr = nativeFile };
        }

        public static void SetNewFileInterface(AllegroFileInterface fileInterface)
            => al_set_new_file_interface(fileInterface.NativeIntPtr);

        public static void SetStandardFileInterface()
            => al_set_standard_file_interface();

        public static AllegroFileInterface GetNewFileInterface()
        {
            var nativeFileInterface = al_get_new_file_interface();
            return nativeFileInterface == IntPtr.Zero ? null : new AllegroFileInterface { NativeIntPtr = nativeFileInterface };
        }

        public static AllegroFile CreateFileHandle(AllegroFileInterface fileInterface, ref byte[] userData)
        {
            var nativeFile = al_create_file_handle(fileInterface.NativeIntPtr, ref userData);
            return nativeFile == IntPtr.Zero ? null : new AllegroFile { NativeIntPtr = nativeFile };
        }

        public static byte[] GetFileUserData(AllegroFile file)
            => al_get_file_userdata(file.NativeIntPtr);

        #region P/Invokes
        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern IntPtr al_fopen(
            [MarshalAs(UnmanagedType.LPStr)] string path,
            [MarshalAs(UnmanagedType.LPStr)] string mode);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern IntPtr al_fopen_interface(
            IntPtr drv,
            [MarshalAs(UnmanagedType.LPStr)] string path,
            [MarshalAs(UnmanagedType.LPStr)] string mode);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern IntPtr al_fopen_slice(
            IntPtr fp,
            IntPtr initialSize,
            [MarshalAs(UnmanagedType.LPStr)] string mode);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_fclose(IntPtr f);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern UIntPtr al_fread(IntPtr f, [MarshalAs(UnmanagedType.LPArray)] ref byte[] ptr, UIntPtr size);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern UIntPtr al_fwrite(IntPtr f, [MarshalAs(UnmanagedType.LPArray)] ref byte[] ptr, UIntPtr size);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_fflush(IntPtr f);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern long al_ftell(IntPtr f);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_fseek(IntPtr f, long offset, int whence);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern bool al_feof(IntPtr f);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern int al_ferror(IntPtr f);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern IntPtr al_ferrmsg(IntPtr f);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern void al_fclearerr(IntPtr f);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern int al_fungetc(IntPtr f, int c);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern long al_fsize(IntPtr f);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern int al_fgetc(IntPtr f);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern int al_fputc(IntPtr f, int c);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern int al_fprintf(IntPtr pfile, [MarshalAs(UnmanagedType.LPStr)] string format, __arglist);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern short al_fread16le(IntPtr f);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern short al_fread16be(IntPtr f);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern UIntPtr al_fwrite16le(IntPtr f, short w);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern UIntPtr al_fwrite16be(IntPtr f, short w);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern int al_fread32le(IntPtr f);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern int al_fread32be(IntPtr f);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern UIntPtr al_fwrite32le(IntPtr f, int l);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern UIntPtr al_fwrite32be(IntPtr f, int l);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern IntPtr al_fgets(IntPtr f, [MarshalAs(UnmanagedType.LPArray)] ref byte[] buf, UIntPtr max);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern IntPtr al_fget_ustr(IntPtr f);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern int al_fputs(IntPtr f, [MarshalAs(UnmanagedType.LPStr)] string p);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern IntPtr al_fopen_fd(int fd, [MarshalAs(UnmanagedType.LPStr)] string mode);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern IntPtr al_make_temp_file([MarshalAs(UnmanagedType.LPStr)] string template, ref IntPtr ret_path);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern void al_set_new_file_interface(IntPtr file_interface);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern void al_set_standard_file_interface();

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern IntPtr al_get_new_file_interface();

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        private static extern IntPtr al_create_file_handle(IntPtr drv, [MarshalAs(UnmanagedType.LPArray)] ref byte[] userdata);

        [DllImport(AlConstants.AllegroMonolithDllFilenameWindows)]
        [return:MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)]
        private static extern byte[] al_get_file_userdata(IntPtr f);
        #endregion
    }
}
