using System;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native.Libraries
{
    internal static class AllegroLibrary
    {
        private static readonly IntPtr _nativeAllegroLibrary = NativeLibrary.LoadAllegroLibrary();

        #region Audio codecs addon
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_init_acodec_addon();
        public static al_init_acodec_addon AlInitAcodecAddon =
            NativeLibrary.LoadNativeFunction<al_init_acodec_addon>(_nativeAllegroLibrary, "al_init_acodec_addon");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_is_acodec_addon_initialized();
        public static al_is_acodec_addon_initialized AlIsAcodecAddonInitialized =
            NativeLibrary.LoadNativeFunction<al_is_acodec_addon_initialized>(_nativeAllegroLibrary, "al_is_acodec_addon_initialized");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_allegro_acodec_version();
        public static al_get_allegro_acodec_version AlGetAllegroAcodecVersion =
            NativeLibrary.LoadNativeFunction<al_get_allegro_acodec_version>(_nativeAllegroLibrary, "al_get_allegro_acodec_version");
        #endregion

        #region Graphics routines
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate NativeAllegroColor al_map_rgb(byte r, byte g, byte b);
        public static al_map_rgb AlMapRgb =
            NativeLibrary.LoadNativeFunction<al_map_rgb>(_nativeAllegroLibrary, "al_map_rgb");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate NativeAllegroColor al_map_rgb_f(float r, float g, float b);
        public static al_map_rgb_f AlMapRgbF =
            NativeLibrary.LoadNativeFunction<al_map_rgb_f>(_nativeAllegroLibrary, "al_map_rgb_f");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate NativeAllegroColor al_map_rgba(byte r, byte g, byte b, byte a);
        public static al_map_rgba AlMapRgba =
            NativeLibrary.LoadNativeFunction<al_map_rgba>(_nativeAllegroLibrary, "al_map_rgba");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate NativeAllegroColor al_premul_rgba(byte r, byte g, byte b, byte a);
        public static al_premul_rgba AlPremulRgba =
            NativeLibrary.LoadNativeFunction<al_premul_rgba>(_nativeAllegroLibrary, "al_premul_rgba");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate NativeAllegroColor al_map_rgba_f(float r, float g, float b, float a);
        public static al_map_rgba_f AlMapRgbaF =
            NativeLibrary.LoadNativeFunction<al_map_rgba_f>(_nativeAllegroLibrary, "al_map_rgba_f");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate NativeAllegroColor al_premul_rgba_f(float r, float g, float b, float a);
        public static al_premul_rgba_f AlPremulRgbaF =
            NativeLibrary.LoadNativeFunction<al_premul_rgba_f>(_nativeAllegroLibrary, "al_premul_rgba_f");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_unmap_rgb(NativeAllegroColor color, ref byte r, ref byte g, ref byte b);
        public static al_unmap_rgb AlUnmapRgb =
            NativeLibrary.LoadNativeFunction<al_unmap_rgb>(_nativeAllegroLibrary, "al_unmap_rgb");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_unmap_rgb_f(NativeAllegroColor color, ref float r, ref float g, ref float b);
        public static al_unmap_rgb_f AlUnmapRgbF =
            NativeLibrary.LoadNativeFunction<al_unmap_rgb_f>(_nativeAllegroLibrary, "al_unmap_rgb_f");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_unmap_rgba(NativeAllegroColor color, ref byte r, ref byte g, ref byte b, ref byte a);
        public static al_unmap_rgba AlUnmapRgba =
            NativeLibrary.LoadNativeFunction<al_unmap_rgba>(_nativeAllegroLibrary, "al_unmap_rgba");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_unmap_rgba_f(NativeAllegroColor color, ref float r, ref float g, ref float b, ref float a);
        public static al_unmap_rgba_f AlUnmapRgbaF =
            NativeLibrary.LoadNativeFunction<al_unmap_rgba_f>(_nativeAllegroLibrary, "al_unmap_rgba_f");
            
        //[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        //public delegate ();
        //public static Al =
        //    NativeLibrary.LoadNativeFunction<>(_nativeAllegroLibrary, "");
        #endregion
    }
}
