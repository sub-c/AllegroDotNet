using System;
using System.Runtime.InteropServices;

namespace AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
        #region P/Invokes
        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern IntPtr al_malloc_with_context(
            UIntPtr n,
            int line,
            [MarshalAs(UnmanagedType.LPStr)] string file,
            [MarshalAs(UnmanagedType.LPStr)] string func);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern void al_free_with_context(
            IntPtr ptr,
            int line,
            [MarshalAs(UnmanagedType.LPStr)] string file,
            [MarshalAs(UnmanagedType.LPStr)] string func);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern IntPtr al_realloc_with_context(
            IntPtr ptr,
            UIntPtr n,
            int line,
            [MarshalAs(UnmanagedType.LPStr)] string file,
            [MarshalAs(UnmanagedType.LPStr)] string func);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern IntPtr al_calloc_with_context(
            UIntPtr count,
            UIntPtr n,
            int line,
            [MarshalAs(UnmanagedType.LPStr)] string file,
            [MarshalAs(UnmanagedType.LPStr)] string func);

        [DllImport(AlConstants.AllegroCoreDllFilename)]
        private static extern void al_set_memory_interface(IntPtr memoryInterface);
        #endregion
    }
}
