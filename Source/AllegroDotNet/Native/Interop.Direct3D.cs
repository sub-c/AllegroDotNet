using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native;

internal static partial class Interop
{
    public static Direct3DContext Direct3D => _direct3dContext ??= new();

    private static Direct3DContext? _direct3dContext;

    public sealed class Direct3DContext
    {
        #region Direct3D Routines

        public al_get_d3d_device AlGetD3dDevice { get; }
        public al_get_d3d_system_texture AlGetD3dSystemTexture { get; }
        public al_get_d3d_video_texture AlGetD3dVideoTexture { get; }
        public al_have_d3d_non_pow2_texture_support AlHaveD3dNonPow2TextureSupport { get; }
        public al_have_d3d_non_square_texture_support AlHaveD3dNonSquareTextureSupport { get; }
        public al_get_d3d_texture_size AlGetD3dTextureSize { get; }
        public al_get_d3d_texture_position AlGetD3dTexturePosition { get; }
        public al_is_d3d_device_lost AlIsD3dDeviceLost { get; }
        public al_set_d3d_device_release_callback AlSetD3dDeviceReleaseCallback { get; }
        public al_set_d3d_device_restore_callback AlSetD3dDeviceRestoreCallback { get; }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_d3d_device(IntPtr display);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_d3d_system_texture(IntPtr bitmap);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_d3d_video_texture(IntPtr bitmap);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_have_d3d_non_pow2_texture_support();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_have_d3d_non_square_texture_support();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_get_d3d_texture_size(IntPtr bitmap, ref int width, ref int height);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_get_d3d_texture_position(IntPtr bitmap, ref int u, ref int v);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte al_is_d3d_device_lost(IntPtr display);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_d3d_device_release_callback(Delegates.Direct3DDeviceRelease? callback);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_d3d_device_restore_callback(Delegates.Direct3DDeviceRestore? callback);

        #endregion

        public Direct3DContext()
        {
            AlGetD3dDevice = LoadFunction<al_get_d3d_device>();
            AlGetD3dSystemTexture = LoadFunction<al_get_d3d_system_texture>();
            AlGetD3dVideoTexture = LoadFunction<al_get_d3d_video_texture>();
            AlHaveD3dNonPow2TextureSupport = LoadFunction<al_have_d3d_non_pow2_texture_support>();
            AlHaveD3dNonSquareTextureSupport = LoadFunction<al_have_d3d_non_square_texture_support>();
            AlGetD3dTextureSize = LoadFunction<al_get_d3d_texture_size>();
            AlGetD3dTexturePosition = LoadFunction<al_get_d3d_texture_position>();
            AlIsD3dDeviceLost = LoadFunction<al_is_d3d_device_lost>();
            AlSetD3dDeviceReleaseCallback = LoadFunction<al_set_d3d_device_release_callback>();
            AlSetD3dDeviceRestoreCallback = LoadFunction<al_set_d3d_device_restore_callback>();
        }
    }
}
