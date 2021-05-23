namespace SubC.AllegroDotNet.Enums
{
    /// <summary>
    /// Used with al_attach_shader_source and al_attach_shader_source_file to specify how to interpret the attached
    /// source.
    /// </summary>
    public enum ShaderType : int
    {
        /// <summary>
        /// A vertex shader is executed for each vertex it is used with. The program will output exactly one vertex
        /// at a time. When Allegro’s graphics are being used then in addition to all vertices of primitives from the
        /// primitives addon, each drawn bitmap also consists of four vertices.
        /// </summary>
        VertexShader = 1,

        /// <summary>
        /// A pixel shader is executed for each pixel it is used with. The program will output exactly one pixel at a
        /// time - either in the backbuffer or in the current target bitmap.
        /// <para>
        /// With Allegro’s builtin graphics this means the shader is for example called for each destination pixel of
        /// the output of an al_draw_bitmap call.
        /// </para>
        /// <para>
        /// A more accurate term for pixel shader would be fragment shader since one final pixel in the target bitmap
        /// is not necessarily composed of only a single output but of multiple fragments (for example when
        /// multi-sampling is being used).
        /// </para>
        /// </summary>
        PixelShader = 2
    }
}
