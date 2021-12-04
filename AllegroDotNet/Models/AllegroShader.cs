using SubC.AllegroDotNet.Native;
using System;

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
    public class AllegroShader : NativePointerWrapper, IEquatable<AllegroShader>
    {
        internal AllegroShader()
        {
        }

        /// <summary>
        /// Determines if two <see cref="AllegroShader"/> native pointers are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the native pointers are equal, otherwise false.</returns>
        public bool Equals(AllegroShader other)
        {
            return NativeIntPtr == other?.NativeIntPtr;
        }
    }
}
