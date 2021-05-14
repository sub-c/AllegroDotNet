using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
        /// <summary>
        /// Like malloc() in the C standard library (unless overridden with al_set_memory_interface), but
        /// the implementation may be overridden. This matters on Windows.
        /// </summary>
        /// <param name="n">Amount of bytes.</param>
        /// <param name="line">Leave as default to use callers line number.</param>
        /// <param name="file">Leave as default to use callers file.</param>
        /// <param name="func">Leave as default to use callers method.</param>
        /// <returns>An integer-pointer to allocated memory on success, otherwise <see cref="IntPtr.Zero"/>.</returns>
        public static IntPtr Malloc(
            ulong n,
            [CallerLineNumber] int line = 0,
            [CallerFilePath] string file = "unknown",
            [CallerMemberName] string func = "unknown")
            => al_malloc_with_context(new UIntPtr(n), line, file, func);

        /// <summary>
        /// Like free() in the C standard library (unless overridden with al_set_memory_interface), but
        /// the implementation may be overridden. This matters on Windows.
        /// </summary>
        /// <param name="integerPointer">Integer-pointer to previously allocated memory.</param>
        /// <param name="line">Leave as default to use callers line number.</param>
        /// <param name="file">Leave as default to use callers file.</param>
        /// <param name="func">Leave as default to use callers method.</param>
        public static void Free(
            IntPtr integerPointer,
            [CallerLineNumber] int line = 0,
            [CallerFilePath] string file = "unknown",
            [CallerMemberName] string func = "unknown")
            => al_free_with_context(integerPointer, line, file, func);

        /// <summary>
        /// Like realloc() in the C standard library (unless overridden with al_set_memory_interface), but
        /// the implementation may be overridden. This matters on Windows.
        /// </summary>
        /// <param name="integerPointer">Integer-pointer to previously allocated memory.</param>
        /// <param name="n">Amount of bytes.</param>
        /// <param name="line">Leave as default to use callers line number.</param>
        /// <param name="file">Leave as default to use callers file.</param>
        /// <param name="func">Leave as default to use callers method.</param>
        /// <returns>An integer-pointer to reallocated memory on success, othewise <see cref="IntPtr.Zero"/>.</returns>
        public static IntPtr Realloc(
            IntPtr integerPointer,
            ulong n,
            [CallerLineNumber] int line = 0,
            [CallerFilePath] string file = "unknown",
            [CallerMemberName] string func = "unknown")
            => al_realloc_with_context(integerPointer, new UIntPtr(n), line, file, func);

        /// <summary>
        /// Like calloc() in the C standard library (unless overridden with al_set_memory_interface), but
        /// the implementation may be overridden. This matters on Windows.
        /// </summary>
        /// <param name="count">The amount of elements to allocate.</param>
        /// <param name="n">Element size in bytes.</param>
        /// <param name="line">Leave as default to use callers line number.</param>
        /// <param name="file">Leave as default to use callers file.</param>
        /// <param name="func">Leave as default to use callers method.</param>
        /// <returns>An integer-pointer to allocated memory on success, othewise <see cref="IntPtr.Zero"/>.</returns>
        public static IntPtr Calloc(
            ulong count,
            ulong n,
            [CallerLineNumber] int line = 0,
            [CallerFilePath] string file = "unknown",
            [CallerMemberName] string func = "unknown")
            => al_calloc_with_context(new UIntPtr(count), new UIntPtr(n), line, file, func);

        /// <summary>
        /// Like malloc() in the C standard library (unless overridden with al_set_memory_interface), but
        /// the implementation may be overridden. This matters on Windows.
        /// </summary>
        /// <param name="n">Amount of bytes.</param>
        /// <param name="line">Line number.</param>
        /// <param name="file">Source code filename.</param>
        /// <param name="func">Calling function/method.</param>
        /// <returns>An integer-pointer to allocated memory on success, otherwise <see cref="IntPtr.Zero"/>.</returns>
        public static IntPtr MallocWithContext(ulong n, int line, string file, string func)
            => al_malloc_with_context(new UIntPtr(n), line, file, func);

        /// <summary>
        /// Like free() in the C standard library (unless overridden with al_set_memory_interface), but
        /// the implementation may be overridden. This matters on Windows.
        /// </summary>
        /// <param name="integerPointer">Integer-pointer to previously allocated memory.</param>
        /// <param name="line">Line number.</param>
        /// <param name="file">Source code filename.</param>
        /// <param name="func">Calling function/method.</param>
        public static void FreeWithContext(IntPtr integerPointer, int line, string file, string func)
            => al_free_with_context(integerPointer, line, file, func);

        /// <summary>
        /// Like realloc() in the C standard library (unless overridden with al_set_memory_interface), but
        /// the implementation may be overridden. This matters on Windows.
        /// </summary>
        /// <param name="integerPointer">Integer-pointer to previously allocated memory.</param>
        /// <param name="n">Amount of bytes.</param>
        /// <param name="line">Line number.</param>
        /// <param name="file">Source code filename.</param>
        /// <param name="func">Calling function/method.</param>
        /// <returns>An integer-pointer to reallocated memory on success, othewise <see cref="IntPtr.Zero"/>.</returns>
        public static IntPtr ReallocWithContext(IntPtr integerPointer, ulong n, int line, string file, string func)
            => al_realloc_with_context(integerPointer, new UIntPtr(n), line, file, func);

        /// <summary>
        /// Like calloc() in the C standard library (unless overridden with al_set_memory_interface), but
        /// the implementation may be overridden. This matters on Windows.
        /// </summary>
        /// <param name="count">Amount of elements to allocate.</param>
        /// <param name="n">Element size in bytes.</param>
        /// <param name="line">Line number.</param>
        /// <param name="file">Source code filename.</param>
        /// <param name="func">Calling function/method.</param>
        /// <returns>An integer-pointer to allocated memory on success, othewise <see cref="IntPtr.Zero"/>.</returns>
        public static IntPtr CallocWithContext(ulong count, ulong n, int line, string file, string func)
            => al_calloc_with_context(new UIntPtr(count), new UIntPtr(n), line, file, func);

        #region P/Invokes
        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_malloc_with_context(
            UIntPtr n,
            int line,
            [MarshalAs(UnmanagedType.LPStr)] string file,
            [MarshalAs(UnmanagedType.LPStr)] string func);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_free_with_context(
            IntPtr ptr,
            int line,
            [MarshalAs(UnmanagedType.LPStr)] string file,
            [MarshalAs(UnmanagedType.LPStr)] string func);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_realloc_with_context(
            IntPtr ptr,
            UIntPtr n,
            int line,
            [MarshalAs(UnmanagedType.LPStr)] string file,
            [MarshalAs(UnmanagedType.LPStr)] string func);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_calloc_with_context(
            UIntPtr count,
            UIntPtr n,
            int line,
            [MarshalAs(UnmanagedType.LPStr)] string file,
            [MarshalAs(UnmanagedType.LPStr)] string func);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_set_memory_interface(IntPtr memoryInterface);
        #endregion
    }
}
