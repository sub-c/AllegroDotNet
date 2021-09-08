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
            var nativeFile = AllegroLibrary.AlFopen(path, mode);
            return nativeFile == IntPtr.Zero ? null : new AllegroFile { NativeIntPtr = nativeFile };
        }

        /// <summary>
        /// Opens a file using the specified interface, instead of the interface set with
        /// <see cref="SetNewFileInterface(AllegroFileInterface)"/>.
        /// </summary>
        /// <param name="inter">The interface.</param>
        /// <param name="path">The path.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        public static AllegroFile FOpenInterface(AllegroFileInterface inter, string path, string mode)
        {
            var nativeFile = AllegroLibrary.AlFopenInterface(inter.NativeIntPtr, path, mode);
            return nativeFile == IntPtr.Zero ? null : new AllegroFile { NativeIntPtr = nativeFile };
        }

        /// <summary>
        /// Opens a slice (subset) of an already open random access file as if it were a stand alone file. While the
        /// slice is open, the parent file handle must not be used in any way.
        /// <para>
        /// The slice is opened at the current location of the parent file, up through <c>initialSize</c> bytes.
        /// The <c>initialSize</c> may be any non-negative integer that will not exceed the bounds of the parent file.
        /// </para>
        /// <para>
        /// Seeking with <see cref="Seek.Set"/> will be relative to this starting location.
        /// <see cref="Seek.End"/> will be relative to the starting location plus the size of the slice.
        /// </para>
        /// <para>
        /// The mode can be any combination of: r: read access, w: write access, e: expandable
        /// </para>
        /// <para>
        /// For example, a mode of “rw” indicates the file can be read and written. (Note that this is slightly
        /// different from the stdio modes.) Keep in mind that the parent file must support random access and
        /// be open in normal write mode(not append) for the slice to work in a well defined way.
        /// </para>
        /// <para>
        /// If the slice is marked as expandable, then reads and writes can happen after the initial end point,
        /// and the slice will grow accordingly. Otherwise, all activity is restricted to the initial size of
        /// the slice.
        /// </para>
        /// <para>
        /// A slice must be closed with <see cref="FClose(AllegroFile)"/>. The parent file will then be positioned
        /// immediately after the end of the slice.
        /// </para>
        /// </summary>
        /// <param name="file">The file instance.</param>
        /// <param name="initialSize">The initial size of the slice.</param>
        /// <param name="mode">Any combination of: r: read access, w: write access, e: expandable</param>
        /// <returns></returns>
        public static AllegroFile FOpenSlice(AllegroFile file, long initialSize, string mode)
        {
            var nativeFile = AllegroLibrary.AlFopenSlice(file.NativeIntPtr, new IntPtr(initialSize), mode);
            return nativeFile == IntPtr.Zero ? null : new AllegroFile { NativeIntPtr = nativeFile };
        }

        /// <summary>
        /// Close the given file, writing any buffered output data (if any).
        /// errno is set to indicate the error.
        /// </summary>
        /// <param name="file">The file interface.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool FClose(AllegroFile file) =>
            AllegroLibrary.AlFclose(file.NativeIntPtr);

        /// <summary>
        /// Read ‘size’ bytes into the buffer pointed to by ‘ptr’, from the given file.
        /// <para>
        /// Returns the number of bytes actually read. If an error occurs, or the end-of-file is reached, the
        /// return value is a short byte count (or zero).
        /// </para>
        /// <para>
        /// <see cref="FRead(AllegroFile, ref byte[], ulong)"/> does not distinguish between EOF and other errors.
        /// Use <see cref="FEoF(AllegroFile)"/> and <see cref="FError(AllegroFile)"/> to determine which occurred.
        /// </para>
        /// </summary>
        /// <param name="file">The file interface.</param>
        /// <param name="dataBuffer">The data buffer.</param>
        /// <param name="dataBufferSize">The data buffer size.</param>
        /// <returns>The amount of bytes read.</returns>
        public static ulong FRead(AllegroFile file, ref byte[] dataBuffer, ulong dataBufferSize) =>
            AllegroLibrary.AlFread(file.NativeIntPtr, ref dataBuffer, new UIntPtr(dataBufferSize)).ToUInt64();

        /// <summary>
        /// Write <c>size</c> bytes from the buffer pointed to by <c>dataBuffer</c> into the given file.
        /// Returns the number of bytes actually written. If an error occurs, the return value is a short byte
        /// count (or zero).
        /// </summary>
        /// <param name="file">The file instance.</param>
        /// <param name="dataBuffer">The data buffer.</param>
        /// <param name="size">The amount of bytes to write.</param>
        /// <returns>The amount of bytes actually written.</returns>
        public static ulong FWrite(AllegroFile file, ref byte[] dataBuffer, ulong size) =>
            AllegroLibrary.AlFwrite(file.NativeIntPtr, ref dataBuffer, new UIntPtr(size)).ToUInt64();

        /// <summary>
        /// Flush any pending writes to the given file.
        /// Returns true on success, false otherwise. errno is set to indicate the error.
        /// </summary>
        /// <param name="file">The file instance.</param>
        /// <returns>Returns true on success, false otherwise. errno is set to indicate the error.</returns>
        public static bool FFlush(AllegroFile file) =>
            AllegroLibrary.AlFflush(file.NativeIntPtr);

        /// <summary>
        /// Returns the current position in the given file, or -1 on error. errno is set to indicate the error.
        /// On some platforms this function may not support large files.
        /// </summary>
        /// <param name="file">The file instance.</param>
        /// <returns>The current position in bytes of the given file instance, or -1 on error.</returns>
        public static long FTell(AllegroFile file) =>
            AllegroLibrary.AlFtell(file.NativeIntPtr);

        /// <summary>
        /// Set the current position of the given file to a position relative to that specified by
        /// <c>whence</c>, plus <c>offset</c> number of bytes.
        /// <para>
        /// After a successful seek, the end-of-file indicator is cleared and all pushback bytes are forgotten.
        /// On some platforms this function may not support large files.
        /// </para>
        /// </summary>
        /// <param name="file">The file instance.</param>
        /// <param name="offset">The offset from <c>whence</c> in bytes.</param>
        /// <param name="whence">The position to seek to in bytes.</param>
        /// <returns>Returns true on success, false on failure. errno is set to indicate the error.</returns>
        public static bool FSeek(AllegroFile file, long offset, Seek whence) =>
            AllegroLibrary.AlFseek(file.NativeIntPtr, offset, (int)whence);

        /// <summary>
        /// Returns true if the end-of-file indicator has been set on the file, i.e. we have attempted to read
        /// past the end of the file. This does not return true if we simply are at the end of the file.
        /// </summary>
        /// <param name="file">The file instance.</param>
        /// <returns>True if end-of-file indicator has been set (attempted to read beyond end of file).</returns>
        public static bool FEoF(AllegroFile file) =>
            AllegroLibrary.AlFeof(file.NativeIntPtr);

        /// <summary>
        /// Returns non-zero if the error indicator is set on the given file, i.e. there was some sort of previous
        /// error. The error code may be system or file interface specific.
        /// </summary>
        /// <param name="file">The file instance.</param>
        /// <returns>Non-zero if the error indicator is set, otherwise zero.</returns>
        public static int FError(AllegroFile file) =>
            AllegroLibrary.AlFerror(file.NativeIntPtr);

        /// <summary>
        /// Return a message string with details about the last error that occurred on the given file handle. The
        /// returned string is empty if there was no error, or if the file interface does not provide more information.
        /// </summary>
        /// <param name="file">The file interface.</param>
        /// <returns>The message string with details about the last error, or empty if no error.</returns>
        public static string FErrMsg(AllegroFile file)
        {
            var nativeErrorMessage = AllegroLibrary.AlFerrmsg(file.NativeIntPtr);
            return nativeErrorMessage == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(nativeErrorMessage);
        }

        /// <summary>
        /// Clear the error indicator for the given file.
        /// The standard I/O backend also clears the end-of-file indicator, and other backends should try to do this.
        /// However, they may not if it would require too much effort (e.g. PhysicsFS backend), so your code should
        /// not rely on it if you need your code to be portable to other backends.
        /// </summary>
        /// <param name="file">The file interface.</param>
        public static void FClearErr(AllegroFile file) =>
            AllegroLibrary.AlFclearerr(file.NativeIntPtr);

        /// <summary>
        /// Ungets a single byte from a file. Pushed-back bytes are not written to the file, only made available for
        /// subsequent reads, in reverse order.
        /// <para>
        /// The number of pushbacks depends on the backend. The standard I/O backend only guarantees a single pushback;
        /// this depends on the libc implementation.
        /// </para>
        /// <para>
        /// For backends that follow the standard behavior, the pushback buffer will be cleared after any seeking or
        /// writing; also calls to <see cref="FSeek(AllegroFile, long, Seek)"/> and <see cref="FTell(AllegroFile)"/>
        /// are relative to the number of pushbacks. If a pushback causes the position to become negative, the behavior
        /// of <see cref="FSeek(AllegroFile, long, Seek)"/> and <see cref="FTell(AllegroFile)"/> are undefined.
        /// </para>
        /// </summary>
        /// <param name="file">The file instance.</param>
        /// <param name="c">The byte to unget; it will be cast to <c>uchar</c>.</param>
        /// <returns>Returns the ungotten byte (cast back to an int) on success, or EOF on error.</returns>
        public static int FUnGetC(AllegroFile file, int c) =>
            AllegroLibrary.AlFungetc(file.NativeIntPtr, c);

        /// <summary>
        /// Return the size of the file, if it can be determined, or -1 otherwise.
        /// </summary>
        /// <param name="file">The file instance.</param>
        /// <returns>The size of the file in bytes, or -1 if it cannot be determined.</returns>
        public static long FSize(AllegroFile file) =>
            AllegroLibrary.AlFsize(file.NativeIntPtr);

        /// <summary>
        /// Read and return next byte in the given file. Returns EOF on end of file or if an error occurred.
        /// </summary>
        /// <param name="file"></param>
        /// <returns>Returns the gotten byte (cast back to an int) on success, or EOF on error.</returns>
        public static int FGetC(AllegroFile file) =>
            AllegroLibrary.AlFgetc(file.NativeIntPtr);

        /// <summary>
        /// Write a single byte to the given file. The byte written is the value of c cast to an unsigned char.
        /// </summary>
        /// <param name="file">The file instance.</param>
        /// <param name="c">The byte to write; it will be cast to <c>uchar</c>.</param>
        /// <returns>Returns the written byte (cast back to an int) on success, or EOF on error.</returns>
        public static int FPutC(AllegroFile file, int c) =>
            AllegroLibrary.AlFputc(file.NativeIntPtr, c);

        /// <summary>
        /// Writes to a file with stdio “printf”-like formatting. 
        /// </summary>
        /// <param name="file">The file instance.</param>
        /// <param name="format">The format string.</param>
        /// <param name="arguments">The format arguments.</param>
        /// <returns>Returns the number of bytes written, or a negative number on error.</returns>
        public static int FPrintF(AllegroFile file, string format, params object[] arguments)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Like <see cref="FPrintF(AllegroFile, string, object[])"/> but takes a va_list. Useful for creating
        /// your own variations of formatted printing. Returns the number of bytes written, or a negative number
        /// on error.
        /// </summary>
        /// <param name="file">The file instance.</param>
        /// <param name="format">The format string.</param>
        /// <param name="arguments">The format arguments.</param>
        /// <returns>Returns the number of bytes written, or a negative number on error.</returns>
        public static int VFPrintF(AllegroFile file, string format, params object[] arguments)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a 16-bit word in little-endian format (LSB first).
        /// </summary>
        /// <param name="file">The file instance.</param>
        /// <returns>
        /// Returns the 16-bit word. On failure, returns EOF (-1). Since -1 is also a valid return value, use
        /// <see cref="FEoF(AllegroFile)"/> to check if the end of the file was reached prematurely, or
        /// <see cref="FError(AllegroFile)"/> to check if an error
        /// occurred.
        /// </returns>
        public static short FRead16LE(AllegroFile file) =>
            AllegroLibrary.AlFread16le(file.NativeIntPtr);

        /// <summary>
        /// Reads a 16-bit word in big-endian format (MSB first).
        /// </summary>
        /// <param name="file">The file instance.</param>
        /// <returns>
        /// Returns the 16-bit word. On failure, returns EOF (-1). Since -1 is also a valid return value, use
        /// <see cref="FEoF(AllegroFile)"/> to check if the end of the file was reached prematurely, or
        /// <see cref="FError(AllegroFile)"/> to check if an error occurred.
        /// </returns>
        public static short FRead16BE(AllegroFile file) =>
            AllegroLibrary.AlFread16be(file.NativeIntPtr);

        /// <summary>
        /// Writes a 16-bit word in little-endian format (LSB first).
        /// </summary>
        /// <param name="file">The file instance.</param>
        /// <param name="w">The 16-bit word to write.</param>
        /// <returns>Returns the number of bytes written: 2 on success, less than 2 on an error.</returns>
        public static ulong FWrite16LE(AllegroFile file, short w) =>
            AllegroLibrary.AlFwrite16le(file.NativeIntPtr, w).ToUInt64();

        /// <summary>
        /// Writes a 16-bit word in big-endian format (MSB first).
        /// </summary>
        /// <param name="file">The file instance.</param>
        /// <param name="w">The 16-bit word to write.</param>
        /// <returns>Returns the number of bytes written: 2 on success, less than 2 on an error.</returns>
        public static ulong FWrite16BE(AllegroFile file, short w) =>
            AllegroLibrary.AlFwrite16be(file.NativeIntPtr, w).ToUInt64();

        /// <summary>
        /// Reads a 32-bit word in little-endian format (LSB first).
        /// </summary>
        /// <param name="file">The file instance.</param>
        /// <returns>
        /// Returns the 32-bit word. On failure, returns EOF (-1). Since -1 is also a valid return value, use
        /// <see cref="FEoF(AllegroFile)"/> to check if the end of the file was reached prematurely, or
        /// <see cref="FError(AllegroFile)"/> to check if an error occurred.
        /// </returns>
        public static int FRead32LE(AllegroFile file) =>
            AllegroLibrary.AlFread32le(file.NativeIntPtr);

        /// <summary>
        /// Read a 32-bit word in big-endian format (MSB first).
        /// </summary>
        /// <param name="file">The file instance.</param>
        /// <returns>
        /// Returns the 32-bit word. On failure, returns EOF (-1). Since -1 is also a valid return value, use
        /// <see cref="FEoF(AllegroFile)"/> to check if the end of the file was reached prematurely, or
        /// <see cref="FError(AllegroFile)"/> to check if an error occurred.
        /// </returns>
        public static int FRead32BE(AllegroFile file) =>
            AllegroLibrary.AlFread32be(file.NativeIntPtr);

        /// <summary>
        /// Writes a 32-bit word in little-endian format (LSB first).
        /// </summary>
        /// <param name="file">The file instance.</param>
        /// <param name="l">The 32-bit word to write.</param>
        /// <returns>Returns the number of bytes written: 4 on success, less than 4 on an error.</returns>
        public static ulong FWrite32LE(AllegroFile file, int l) =>
            AllegroLibrary.AlFwrite32le(file.NativeIntPtr, l).ToUInt64();

        /// <summary>
        /// Writes a 32-bit word in big-endian format (MSB first).
        /// </summary>
        /// <param name="file">The file instance.</param>
        /// <param name="l">The 32-bit word to write.</param>
        /// <returns>Returns the number of bytes written: 4 on success, less than 4 on an error.</returns>
        public static ulong FWrite32BE(AllegroFile file, int l) =>
            AllegroLibrary.AlFwrite32be(file.NativeIntPtr, l).ToUInt64();

        /// <summary>
        /// Read a string of bytes terminated with a newline or end-of-file into the buffer given. The line
        /// terminator(s), if any, are included in the returned string. A maximum of max-1 bytes are read, with
        /// one byte being reserved for a NULL terminator.
        /// </summary>
        /// <param name="file">The file instance.</param>
        /// <param name="buffer">The buffer to fill.</param>
        /// <param name="max">Maximum size of the buffer.</param>
        /// <returns></returns>
        public static string FGetS(AllegroFile file, ref byte[] buffer, ulong max)
        {
            var nativeString = AllegroLibrary.AlFgets(file.NativeIntPtr, ref buffer, new UIntPtr(max));
            return nativeString == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(nativeString);
        }

        /// <summary>
        /// Read a string of bytes terminated with a newline or end-of-file. The line terminator(s), if any, are
        /// included in the returned string.
        /// </summary>
        /// <param name="file">The file instance.</param>
        /// <returns>
        /// Returns a pointer to a new <see cref="AllegroUStr"/> structure. This must be freed eventually with
        /// al_ustr_free. Returns <c>null</c> if an error occurred or if the end of file was reached without reading
        /// any bytes.
        /// </returns>
        public static AllegroUStr FGetUStr(AllegroFile file)
        {
            var nativeUStr = AllegroLibrary.AlFgetUstr(file.NativeIntPtr);
            return nativeUStr == IntPtr.Zero ? null : new AllegroUStr { NativeIntPtr = nativeUStr };
        }

        /// <summary>
        /// Writes a string to file. 
        /// </summary>
        /// <param name="file">The file instance.</param>
        /// <param name="p">The string to write.</param>
        /// <returns>Returns a non-negative integer on success, <see cref="AlConstants.AllegroEof"/> on error.</returns>
        public static int FPutS(AllegroFile file, string p) =>
            AllegroLibrary.AlFputs(file.NativeIntPtr, p);

        /// <summary>
        /// Create an ALLEGRO_FILE object that operates on an open file descriptor using stdio routines.
        /// See the documentation of fdopen() for a description of the ‘mode’ argument.
        /// </summary>
        /// <param name="fd">Open file descriptor from stdio routines.</param>
        /// <param name="mode">Access mode to open the file in ("r", "w", etc).</param>
        /// <returns>
        /// Returns an <see cref="AllegroFile"/> object on success or <c>null</c> on an error.
        /// On an error, the Allegro errno will be set and the file descriptor will not be closed.
        /// </returns>
        public static AllegroFile FOpenFD(int fd, string mode)
        {
            var nativeFile = AllegroLibrary.AlFopenFd(fd, mode);
            return nativeFile == IntPtr.Zero ? null : new AllegroFile { NativeIntPtr = nativeFile };
        }

        /// <summary>
        /// Make a temporary randomly named file given a filename ‘template’.
        /// <para>
        /// ‘template’ is a string giving the format of the generated filename and should include one or more capital
        /// Xs. The Xs are replaced with random alphanumeric characters, produced using a simple pseudo-random number
        /// generator only. There should be no path separators.
        /// </para>
        /// <para>
        /// If <c>returnPath</c> is not <c>null</c>, the address it points to will be set to point to a new path
        /// structure with the name of the temporary file.
        /// </para>
        /// </summary>
        /// <param name="template">The template string.</param>
        /// <param name="returnPath">If non-null, the address will point to the new path structure.</param>
        /// <returns>Returns the opened ALLEGRO_FILE on success, <c>null</c> on failure.</returns>
        public static AllegroFile MakeTempFile(string template, AllegroPath returnPath)
        {
            var nativeFile = IntPtr.Zero;
            var nullIntPtr = IntPtr.Zero;
            if (returnPath == null)
            {
                nativeFile = AllegroLibrary.AlMakeTempFile(template, ref nullIntPtr);
            }
            else
            {
                nativeFile = AllegroLibrary.AlMakeTempFile(template, ref returnPath.NativeIntPtr);
            }
            return nativeFile == IntPtr.Zero ? null : new AllegroFile { NativeIntPtr = nativeFile };
        }

        /// <summary>
        /// Set the <see cref="AllegroFileInterface"/> table for the calling thread. This will change the handler for
        /// later calls to <see cref="FOpen(string, string)"/>.
        /// </summary>
        /// <param name="fileInterface">The file interface to set.</param>
        public static void SetNewFileInterface(AllegroFileInterface fileInterface) =>
            AllegroLibrary.AlSetNewFileInterface(fileInterface.NativeIntPtr);

        /// <summary>
        /// Set the <see cref="AllegroFileInterface"/> table to the default, for the calling thread. This will change
        /// the handler for later calls to <see cref="FOpen(string, string)"/>.
        /// </summary>
        public static void SetStandardFileInterface() =>
            AllegroLibrary.AlSetStandardFileInterface();

        /// <summary>
        /// Return a pointer to the <see cref="AllegroFileInterface"/> table in effect for the calling thread.
        /// </summary>
        /// <returns></returns>
        public static AllegroFileInterface GetNewFileInterface()
        {
            var nativeFileInterface = AllegroLibrary.AlGetNewFileInterface();
            return nativeFileInterface == IntPtr.Zero ? null : new AllegroFileInterface { NativeIntPtr = nativeFileInterface };
        }

        /// <summary>
        /// Creates an empty, opened file handle with some abstract user data. This allows custom interfaces to extend
        /// the <see cref="AllegroFile"/> struct with their own data. You should close the handle with the standard
        /// <see cref="FClose(AllegroFile)"/> function when you are finished with it.
        /// </summary>
        /// <param name="fileInterface">The file itnerface.</param>
        /// <param name="userData">The abstract user data.</param>
        /// <returns>An empty, opened file handle with the given abstract user data.</returns>
        public static AllegroFile CreateFileHandle(AllegroFileInterface fileInterface, ref byte[] userData)
        {
            var nativeFile = AllegroLibrary.AlCreateFileHandle(fileInterface.NativeIntPtr, ref userData);
            return nativeFile == IntPtr.Zero ? null : new AllegroFile { NativeIntPtr = nativeFile };
        }

        /// <summary>
        /// Returns a pointer to the custom userdata that is attached to the file handle. This is intended to be
        /// used by functions that extend <see cref="AllegroFileInterface"/>.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>A pointer to the customer user data.</returns>
        public static byte[] GetFileUserData(AllegroFile file) =>
            AllegroLibrary.AlGetFileUserdata(file.NativeIntPtr);
    }
}
