using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native;

internal static partial class Interop
{
    public static MemfileContext Memfile => _memfileContext ??= new();

    private static MemfileContext? _memfileContext;

    public sealed class MemfileContext
    {
        #region Memfile Routines

        public al_open_memfile AlOpenMemfile { get; }
        public al_get_allegro_memfile_version AlGetAllegroMemfileVersion { get; }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_open_memfile(IntPtr mem, long size, IntPtr mode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_allegro_memfile_version();

        #endregion

        public MemfileContext()
        {
            AlOpenMemfile = LoadFunction<al_open_memfile>();
            AlGetAllegroMemfileVersion = LoadFunction<al_get_allegro_memfile_version>();
        }
    }
}
