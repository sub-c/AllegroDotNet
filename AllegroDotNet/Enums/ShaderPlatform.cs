namespace AllegroDotNet.Enums
{
    /// <summary>
    /// The underlying platform which the ALLEGRO_SHADER is built on top of, which dictates the language
    /// used to program the shader.
    /// </summary>
    public enum ShaderPlatform : int
    {
        /// <summary>
        /// Automatically pick shader language.
        /// </summary>
        Auto = 0,

        /// <summary>
        /// OpenGL Shading Language
        /// </summary>
        GLSL = 1,

        /// <summary>
        /// High Level Shader Language (for Direct3D)
        /// </summary>
        HLSL = 2
    }
}
