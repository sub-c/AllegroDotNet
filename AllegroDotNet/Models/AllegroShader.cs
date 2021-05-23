namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// An ALLEGRO_SHADER is a program that runs on the GPU. It combines both a vertex and a pixel shader.
    /// (In OpenGL terms, an ALLEGRO_SHADER is actually a program which has one or more shaders attached.
    /// This can be confusing.)
    /// <para>
    /// The source code for the underlying vertex or pixel shader can be provided either as GLSL or HLSL,
    /// depending on the value of ALLEGRO_SHADER_PLATFORM used when creating it.
    /// </para>
    /// </summary>
    public class AllegroShader : NativePointerWrapper
    {
        internal AllegroShader()
        {
        }
    }
}
