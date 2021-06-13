namespace SubC.AllegroDotNet.Enums
{
    /// <summary>
    /// Possible render states which can be set with Al.SetRenderState().
    /// </summary>
    public enum RenderState
    {
        /// <summary>
        /// If this is set to 1, the values of ALLEGRO_ALPHA_FUNCTION and ALLEGRO_ALPHA_TEST_VALUE define a comparison
        /// function which is performed on the alpha component of each pixel. Only if it evaluates to true the pixel
        /// is written. Otherwise no subsequent processing (like depth test or blending) is performed. This can be
        /// very useful, for example if a depth buffer is used but you do not want fully transparent pixels to modify it. 
        /// </summary>
        AlphaTest = 0x0010,

        /// <summary>
        /// This determines how the framebuffer and depthbuffer are updated whenever a pixel is written (in case alpha
        /// and/or depth testing is enabled: after all such enabled tests succeed). Depth values are only written if
        /// ALLEGRO_DEPTH_TEST is 1, in addition to the write mask flag being set. 
        /// </summary>
        WriteMask,

        /// <summary>
        /// If this is set to 1, compare the depth value of any newly written pixels with the depth value already in
        /// the buffer, according to ALLEGRO_DEPTH_FUNCTION. Allegro primitives with no explicit z coordinate will
        /// write a value of 0 into the depth buffer. 
        /// </summary>
        DepthTest,

        /// <summary>
        /// One of ALLEGRO_RENDER_FUNCTION, only used when ALLEGRO_DEPTH_TEST is 1.
        /// </summary>
        DepthFunction,

        /// <summary>
        /// One of ALLEGRO_RENDER_FUNCTION, only used when ALLEGRO_ALPHA_TEST is 1.
        /// </summary>
        AlphaFunction,

        /// <summary>
        /// Only used when ALLEGRO_ALPHA_TEST is 1. Should be a value of 0 - 255.
        /// </summary>
        AlphaTestValue
    }
}
