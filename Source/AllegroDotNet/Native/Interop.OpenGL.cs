using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native;

internal static partial class Interop
{
  public static OpenGLContext OpenGL => _openGLContext ??= new();

  private static OpenGLContext? _openGLContext;

  public sealed class OpenGLContext
  {
    #region OpenGL Routines

    public al_get_opengl_extension_list AlGetOpenGLExtensionList { get; }
    public al_get_opengl_proc_address AlGetOpenGLProcAddress { get; }
    public al_get_opengl_texture AlGetOpenGLTexture { get; }
    public al_get_opengl_texture_size AlGetOpenGLTextureSize { get; }
    public al_get_opengl_texture_position AlGetOpenGLTexturePosition { get; }
    public al_get_opengl_program_object AlGetOpenGLProgramObject { get; }
    public al_get_opengl_fbo AlGetOpenGLFbo { get; }
    public al_remove_opengl_fbo AlRemoveOpenGLFbo { get; }
    public al_have_opengl_extension AlHaveOpenGLExtension { get; }
    public al_get_opengl_version AlGetOpenGLVersion { get; }
    public al_get_opengl_variant AlGetOpenGLVariant { get; }
    public al_set_current_opengl_context AlSetCurrentOpenGLContext { get; }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_opengl_extension_list();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_opengl_proc_address(IntPtr name);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_opengl_texture(IntPtr bitmap);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_get_opengl_texture_size(IntPtr bitmap, ref int w, ref int h);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_get_opengl_texture_position(IntPtr bitmap, ref int u, ref int v);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_opengl_program_object(IntPtr shader);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_opengl_fbo(IntPtr bitmap);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_remove_opengl_fbo(IntPtr bitmap);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool al_have_opengl_extension(IntPtr extension);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_opengl_version();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_opengl_variant();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_current_opengl_context(IntPtr display);

    #endregion

    public OpenGLContext()
    {
      AlGetOpenGLExtensionList = LoadFunction<al_get_opengl_extension_list>();
      AlGetOpenGLProcAddress = LoadFunction<al_get_opengl_proc_address>();
      AlGetOpenGLTexture = LoadFunction<al_get_opengl_texture>();
      AlGetOpenGLTextureSize = LoadFunction<al_get_opengl_texture_size>();
      AlGetOpenGLTexturePosition = LoadFunction<al_get_opengl_texture_position>();
      AlGetOpenGLProgramObject = LoadFunction<al_get_opengl_program_object>();
      AlGetOpenGLFbo = LoadFunction<al_get_opengl_fbo>();
      AlRemoveOpenGLFbo = LoadFunction<al_remove_opengl_fbo>();
      AlHaveOpenGLExtension = LoadFunction<al_have_opengl_extension>();
      AlGetOpenGLVersion = LoadFunction<al_get_opengl_version>();
      AlGetOpenGLVariant = LoadFunction<al_get_opengl_variant>();
      AlSetCurrentOpenGLContext = LoadFunction<al_set_current_opengl_context>();
    }
  }
}
