using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
    public static IntPtr GetOpenGLExtensionList()
    {
        return Interop.OpenGL.AlGetOpenGLExtensionList();
    }

    public static IntPtr GetOpenGLProcAddress(string? name)
    {
        using var nativeName = new CStringAnsi(name);
        return Interop.OpenGL.AlGetOpenGLProcAddress(nativeName.Pointer);
    }

    public static uint GetOpenGLTexture(AllegroBitmap? bitmap)
    {
        return Interop.OpenGL.AlGetOpenGLTexture(NativePointer.Get(bitmap));
    }

    public static bool GetOpenGLTextureSize(AllegroBitmap? bitmap, ref int width, ref int height)
    {
        return Interop.OpenGL.AlGetOpenGLTextureSize(NativePointer.Get(bitmap), ref width, ref height) != 0;
    }

    public static void GetOpenGLTexturePosition(AllegroBitmap? bitmap, ref int u, ref int v)
    {
        Interop.OpenGL.AlGetOpenGLTexturePosition(NativePointer.Get(bitmap), ref u, ref v);
    }

    public static uint GetOpenGLProgramObject(AllegroShader? shader)
    {
        return Interop.OpenGL.AlGetOpenGLProgramObject(NativePointer.Get(shader));
    }

    public static uint GetOpenGLFbo(AllegroBitmap? bitmap)
    {
        return Interop.OpenGL.AlGetOpenGLFbo(NativePointer.Get(bitmap));
    }

    public static void RemoveOpenGLFbo(AllegroBitmap? bitmap)
    {
        Interop.OpenGL.AlRemoveOpenGLFbo(NativePointer.Get(bitmap));
    }

    public static bool HaveOpenGLExtension(string? extension)
    {
        using var nativeExtension = new CStringAnsi(extension);
        return Interop.OpenGL.AlHaveOpenGLExtension(nativeExtension.Pointer);
    }

    public static uint GetOpenGLVersion()
    {
        return Interop.OpenGL.AlGetOpenGLVersion();
    }

    public static OpenGLVariant GetOpenGLVariant()
    {
        return (OpenGLVariant)Interop.OpenGL.AlGetOpenGLVariant();
    }

    public static void SetCurrentOpenGLContext(AllegroDisplay? display)
    {
        Interop.OpenGL.AlSetCurrentOpenGLContext(NativePointer.Get(display));
    }
}
