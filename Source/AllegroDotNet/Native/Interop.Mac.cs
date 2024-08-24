using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native;

internal static partial class Interop
{
    public static MacContext Mac => _macContext ??= new();

    private static MacContext? _macContext;

    public sealed class MacContext
    {
        #region Mac Routines

        public al_osx_get_window AlOsxGetWindow { get; }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_osx_get_window(IntPtr display);

        #endregion

        public MacContext()
        {
            AlOsxGetWindow = LoadFunction<al_osx_get_window>();
        }
    }
}
