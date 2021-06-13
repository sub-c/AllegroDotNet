using System;
using System.Runtime.InteropServices;
using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
        /// <summary>
        /// Create a shader object.
        /// <para>
        /// The platform argument is one of the ALLEGRO_SHADER_PLATFORM values, and specifies the type of shader object
        /// to create, and which language is used to program the shader.
        /// </para>
        /// <para>
        /// The shader platform must be compatible with the type of display that you will use the shader with. For
        /// example, you cannot create and use a HLSL shader on an OpenGL display, nor a GLSL shader on a Direct3D
        /// display.
        /// </para>
        /// The ALLEGRO_SHADER_AUTO value automatically chooses the appropriate platform for the display currently
        /// targeted by the calling thread; there must be such a display. It will create a GLSL shader for an OpenGL
        /// display, and a HLSL shader for a Direct3D display.
        /// <para>
        /// </para>
        /// Returns the shader object on success. Otherwise, returns NULL.
        /// </summary>
        /// <param name="platform">The type of shader to create.</param>
        /// <returns>The shader object on success. Otherwise, returns NULL.</returns>
        public static AllegroShader CreateShader(ShaderPlatform platform)
        {
            var nativeShader = al_create_shader(platform);
            return nativeShader == IntPtr.Zero ? null : new AllegroShader { NativeIntPtr = nativeShader };
        }

        /// <summary>
        /// Attaches the shader’s source code to the shader object and compiles it. Passing NULL deletes the underlying
        /// (OpenGL or DirectX) shader. See also al_attach_shader_source_file if you prefer to obtain your shader
        /// source from an external file.
        /// <para>
        /// If you do not use ALLEGRO_PROGRAMMABLE_PIPELINE Allegro’s graphics functions will not use any shader
        /// specific functions themselves. In case of a system with no fixed function pipeline (like OpenGL ES 2
        /// or OpenGL 3 or 4) this means Allegro’s drawing functions cannot be used.
        /// </para>
        /// <para>
        /// TODO: add the full documentation
        /// </para>
        /// </summary>
        /// <param name="shader">The shader.</param>
        /// <param name="type">The shader type.</param>
        /// <param name="source">The source.</param>
        /// <returns>True on success, otherwise false.</returns>
        public static bool AttachShaderSource(AllegroShader shader, ShaderType type, string source)
            => al_attach_shader_source(shader.NativeIntPtr, type, source);

        /// <summary>
        /// Like al_attach_shader_source but reads the source code for the shader from the named file.
        /// </summary>
        /// <param name="shader">The shader.</param>
        /// <param name="type">The shader type.</param>
        /// <param name="filename">The filename of the source code.</param>
        /// <returns>
        /// True on success and false on error, in which case the error log is updated. The error log can be retrieved
        /// with al_get_shader_log.
        /// </returns>
        public static bool AttachShaderSourceFile(AllegroShader shader, ShaderType type, string filename)
            => al_attach_shader_source_file(shader.NativeIntPtr, type, filename);

        /// <summary>
        /// This is required before the shader can be used with al_use_shader. It should be called after successfully
        /// attaching the pixel and/or vertex shaders with al_attach_shader_source or al_attach_shader_source_file.
        /// <para>
        /// Returns true on success and false on error, in which case the error log is updated. The error log can be
        /// retrieved with al_get_shader_log.
        /// </para>
        /// <para>
        /// Note: If you are using the ALLEGRO_PROGRAMMABLE_PIPELINE flag, then you must specify both a pixel and a
        /// vertex shader sources for anything to be rendered.
        /// </para>
        /// </summary>
        /// <param name="shader">The shader.</param>
        /// <returns>True on success, otherwise false.</returns>
        public static bool BuildShader(AllegroShader shader)
            => al_build_shader(shader.NativeIntPtr);

        /// <summary>
        /// Return a read-only string containing the information log for a shader program. The log is updated
        /// by certain functions, such as al_attach_shader_source or al_build_shader when there is an error.
        /// </summary>
        /// <param name="shader">The shader.</param>
        /// <returns>String of the information log for a shader program, otherwise never null.</returns>
        public static string GetShaderLog(AllegroShader shader)
        {
            var nativeString = al_get_shader_log(shader.NativeIntPtr);
            return nativeString == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(nativeString);
        }

        /// <summary>
        /// Returns the platform the shader was created with (either ALLEGRO_SHADER_HLSL or ALLEGRO_SHADER_GLSL).
        /// </summary>
        /// <param name="shader">The shader.</param>
        /// <returns>The shader platform.</returns>
        public static ShaderPlatform GetShaderPlatform(AllegroShader shader)
            => al_get_shader_platform(shader.NativeIntPtr);

        /// <summary>
        /// Uses the shader for subsequent drawing operations on the current target bitmap. Pass NULL to stop
        /// using any shader on the current target bitmap.
        /// </summary>
        /// <param name="shader">The shader.</param>
        /// <returns>
        /// True on success. Otherwise returns false, e.g. because the shader is incompatible with the target bitmap.
        /// </returns>
        public static bool UseShader(AllegroShader shader)
            => al_use_shader(shader.NativeIntPtr);

        /// <summary>
        /// Destroy a shader. Any bitmaps which currently use the shader will implicitly stop using the shader. In
        /// multi-threaded programs, be careful that no such bitmaps are being accessed by other threads at the time.
        /// <para>
        /// As a convenience, if the target bitmap of the calling thread is using the shader then the shader is
        /// implicitly unused before being destroyed.
        /// </para>
        /// <para>
        /// This function does nothing if the shader argument is NULL.
        /// </para>
        /// </summary>
        /// <param name="shader">The shader to destroy.</param>
        public static void DestroyShader(AllegroShader shader)
            => al_destroy_shader(shader.NativeIntPtr);

        /// <summary>
        /// Sets a texture sampler uniform and texture unit of the current target bitmap’s shader. The given bitmap
        /// must be a video bitmap.
        /// <para>
        /// Different samplers should use different units. The bitmap passed to Allegro’s drawing functions uses the
        /// 0th unit, so if you’re planning on using the al_tex variable in your pixel shader as well as another
        /// sampler, set the other sampler to use a unit different from 0. With the primitives addon, it is possible
        /// to free up the 0th unit by passing NULL as the texture argument to the relevant drawing functions. In
        /// this case, you may set a sampler to use the 0th unit and thus not use al_tex (the al_use_tex variable
        /// will be set to false).
        /// </para>
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="bitmap">The bitmap to set.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>
        /// True on success. Otherwise returns false, e.g. if the uniform by that name does not exist in the shader.
        /// </returns>
        public static bool SetShaderSampler(string name, AllegroBitmap bitmap, int unit)
            => al_set_shader_sampler(name, bitmap.NativeIntPtr, unit);

        /// <summary>
        /// Sets a matrix uniform of the current target bitmap’s shader.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="matrix">The transform matrix.</param>
        /// <returns>
        /// True on success. Otherwise returns false, e.g. if the uniform by that name does not exist in the shader.
        /// </returns>
        public static bool SetShaderMatrix(string name, AllegroTransform matrix)
            => al_set_shader_matrix(name, ref matrix.Native);

        /// <summary>
        /// Sets an integer uniform of the current target bitmap’s shader.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="i">The integer uniform.</param>
        /// <returns>
        /// True on success. Otherwise returns false, e.g. if the uniform by that name does not exist in the shader.
        /// </returns>
        public static bool SetShaderInt(string name, int i)
            => al_set_shader_int(name, i);

        /// <summary>
        /// Sets a float uniform of the target bitmap’s shader.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="f">The float uniform.</param>
        /// <returns>
        /// True on success. Otherwise returns false, e.g. if the uniform by that name does not exist in the shader.
        /// </returns>
        public static bool SetShaderFloat(string name, float f)
            => al_set_shader_float(name, f);

        /// <summary>
        /// Sets a boolean uniform of the target bitmap’s shader.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="b">The bool uniform.</param>
        /// <returns>
        /// True on success. Otherwise returns false, e.g. if the uniform by that name does not exist in the shader.
        /// </returns>
        public static bool SetShaderBool(string name, bool b)
            => al_set_shader_bool(name, b);

        /// <summary>
        /// Sets an integer vector array uniform of the current target bitmap’s shader. The ‘num_components’ parameter
        /// can take one of the values 1, 2, 3 or 4. If it is 1 then an array of ‘num_elems’ integer elements is added.
        /// Otherwise each added array element is assumed to be a vector with 2, 3 or 4 components in it.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="numComponents">The number of components (1 to 4).</param>
        /// <param name="i">The integer.</param>
        /// <param name="numberOfElements">The integer elements.</param>
        /// <returns>
        /// True on success. Otherwise returns false, e.g. if the uniform by that name does not exist in the shader.
        /// </returns>
        public static bool SetShaderIntVector(string name, int numComponents, ref int i, int numberOfElements)
            => al_set_shader_int_vector(name, numComponents, ref i, numberOfElements);

        /// <summary>
        /// Same as al_set_shader_int_vector except all values are float instead of int.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="numComponents">The number of components (1 to 4).</param>
        /// <param name="f">The float.</param>
        /// <param name="numberOfElements">The float elements.</param>
        /// <returns>True on success, otherwise false.</returns>
        public static bool SetShaderFloatVector(string name, int numComponents, ref float f, int numberOfElements)
            => al_set_shader_float_vector(name, numComponents, ref f, numberOfElements);

        /// <summary>
        /// Returns a string containing the source code to Allegro’s default vertex or pixel shader appropriate for the
        /// passed platform. The ALLEGRO_SHADER_AUTO value means GLSL is used if OpenGL is being used otherwise HLSL.
        /// ALLEGRO_SHADER_AUTO requires that there is a current display set on the calling thread. This function
        /// can return NULL if Allegro was built without support for shaders of the selected platform.
        /// </summary>
        /// <param name="platform">The shader platform.</param>
        /// <param name="type">The shader type.</param>
        /// <returns>
        /// Null if Allegro was built without support for the specified shaders, or the source code of the default
        /// shader.
        /// </returns>
        public static string GetDefaultShaderSource(ShaderPlatform platform, ShaderType type)
        {
            var nativeString = al_get_default_shader_source(platform, type);
            return nativeString == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(nativeString);
        }

        #region P/Invokes
        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_create_shader(ShaderPlatform platform);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_attach_shader_source(IntPtr shader, ShaderType type, [MarshalAs(UnmanagedType.LPStr)] string source);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_attach_shader_source_file(IntPtr shader, ShaderType type, [MarshalAs(UnmanagedType.LPStr)] string filename);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_build_shader(IntPtr shader);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_get_shader_log(IntPtr shader);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern ShaderPlatform al_get_shader_platform(IntPtr shader);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_use_shader(IntPtr shader);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_destroy_shader(IntPtr shader);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_shader_sampler([MarshalAs(UnmanagedType.LPStr)] string name, IntPtr bitmap, int unit);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_shader_matrix([MarshalAs(UnmanagedType.LPStr)] string name, ref NativeTransform matrix);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_shader_int([MarshalAs(UnmanagedType.LPStr)] string name, int i);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_shader_float([MarshalAs(UnmanagedType.LPStr)] string name, float f);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_shader_bool([MarshalAs(UnmanagedType.LPStr)] string name, bool b);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_shader_int_vector([MarshalAs(UnmanagedType.LPStr)] string name, int num_components, ref int i, int num_elems);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_shader_float_vector([MarshalAs(UnmanagedType.LPStr)] string name, int num_components, ref float f, int num_elems);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_get_default_shader_source(ShaderPlatform platform, ShaderType type);
        #endregion
    }
}
