using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
    public static IntPtr GetD3dDevice(AllegroDisplay? display)
    {
        return Interop.Direct3D.AlGetD3dDevice(NativePointer.Get(display));
    }

    public static IntPtr GetD3dSystemTexture(AllegroBitmap? bitmap)
    {
        return Interop.Direct3D.AlGetD3dSystemTexture(NativePointer.Get(bitmap));
    }

    public static IntPtr GetD3dVideoTexture(AllegroBitmap? bitmap)
    {
        return Interop.Direct3D.AlGetD3dVideoTexture(NativePointer.Get(bitmap));
    }

    public static bool HaveD3dNonPow2TextureSupport()
    {
        return Interop.Direct3D.AlHaveD3dNonPow2TextureSupport() != 0;
    }

    public static bool HaveD3dNonSquareTextureSupport()
    {
        return Interop.Direct3D.AlHaveD3dNonSquareTextureSupport() != 0;
    }

    public static bool GetD3dTextureSize(AllegroBitmap? bitmap, ref int width, ref int height)
    {
        return Interop.Direct3D.AlGetD3dTextureSize(NativePointer.Get(bitmap), ref width, ref height) != 0;
    }

    public static void GetD3dTexturePosition(AllegroBitmap? bitmap, ref int u, ref int v)
    {
        Interop.Direct3D.AlGetD3dTexturePosition(NativePointer.Get(bitmap), ref u, ref v);
    }

    public static bool IsD3dDeviceLost(AllegroDisplay? display)
    {
        return Interop.Direct3D.AlIsD3dDeviceLost(NativePointer.Get(display)) != 0;
    }

    public static void SetD3dDeviceReleaseCallback(Delegates.Direct3DDeviceRelease? callback)
    {
        Interop.Direct3D.AlSetD3dDeviceReleaseCallback(callback);
    }

    public static void SetD3dDeviceRestoreCallback(Delegates.Direct3DDeviceRestore? callback)
    {
        Interop.Direct3D.AlSetD3dDeviceRestoreCallback(callback);
    }
}
