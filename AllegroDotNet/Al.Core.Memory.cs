using System;
using System.Runtime.InteropServices;

namespace AllegroDotNet
{
    /// <summary>
    /// Allegro game library Core methods.
    /// </summary>
    public static partial class Al
    {
        #region P/Invokes
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_free_with_context(
            IntPtr ptr,
            int line,
            [MarshalAs(UnmanagedType.LPStr)] string file,
            [MarshalAs(UnmanagedType.LPStr)] string func);
        #endregion
    }
}
