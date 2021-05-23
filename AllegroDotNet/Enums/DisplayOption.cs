namespace SubC.AllegroDotNet.Enums
{
    public enum DisplayOption : int
    {
        /// <summary>
        /// Individual color component size in bits.
        /// </summary>
        RedSize = 0,

        /// <summary>
        /// Individual color component size in bits.
        /// </summary>
        GreenSize = 1,

        /// <summary>
        /// Individual color component size in bits.
        /// </summary>
        BlueSize = 2,

        /// <summary>
        /// Individual color component size in bits.
        /// </summary>
        AlphaSize = 3,

        /// <summary>
        /// Individual color component size in bits.
        /// </summary>
        RedShift = 4,

        /// <summary>
        /// Individual color component size in bits.
        /// </summary>
        GreenShift = 5,

        /// <summary>
        /// Individual color component size in bits.
        /// </summary>
        BlueShift = 6,

        /// <summary>
        /// Individual color component size in bits.
        /// </summary>
        AlphaShift = 7,

        /// <summary>
        /// This can be used to define the required accumulation buffer size.
        /// </summary>
        AccRedSize = 8,

        /// <summary>
        /// This can be used to define the required accumulation buffer size.
        /// </summary>
        AccGreenSize = 9,

        /// <summary>
        /// This can be used to define the required accumulation buffer size.
        /// </summary>
        AccBlueSize = 10,

        /// <summary>
        /// This can be used to define the required accumulation buffer size.
        /// </summary>
        AccAlphaSize = 11,

        /// <summary>
        /// Whether the display is a stereo display.
        /// </summary>
        Stereo = 12,

        /// <summary>
        /// Number of auxiliary buffers the display should have.
        /// </summary>
        AuxBuffers = 13,

        /// <summary>
        /// This can be used to ask for a specific bit depth. For example to force a 16-bit framebuffer set this to 16.
        /// </summary>
        ColorSize = 14,

        /// <summary>
        /// How many depth buffer (z-buffer) bits to use.
        /// </summary>
        DepthSize = 15,

        /// <summary>
        /// How many bits to use for the stencil buffer.
        /// </summary>
        StencilSize = 16,

        /// <summary>
        /// Whether to use multisampling (1) or not (0).
        /// </summary>
        SampleBuffers = 17,

        /// <summary>
        /// If the above is 1, the number of samples to use per pixel. Else 0.
        /// </summary>
        Samples = 18,

        /// <summary>
        /// 0 if hardware acceleration is not used with this display.
        /// </summary>
        RenderMethod = 19,

        /// <summary>
        /// Whether to use floating point color components.
        /// </summary>
        FloatColor = 20,

        /// <summary>
        /// Whether to use a floating point depth buffer.
        /// </summary>
        FloatDepth = 21,

        /// <summary>
        /// Whether the display uses a single buffer (1) or another update method (0).
        /// </summary>
        SingleBuffer = 22,

        /// <summary>
        /// If the above is 0, this is set to 1 to indicate the display is using a copying method to make the next buffer in the flip chain
        /// available, or to 2 to indicate a flipping or other method.
        /// </summary>
        SwapMethod = 23,

        /// <summary>
        /// Indicates if Allegro's graphics functions can use this display. If you request a display not useable by Allegro, you can still use
        /// for example OpenGL to draw graphics.
        /// </summary>
        CompatibleDisplay = 24,

        /// <summary>
        /// Set to 1 if the display is capable of updating just a region, and 0 if calling al_update_display_region is equivalent to
        /// <see cref="Al.FlipDisplay()"/>.
        /// </summary>
        UpdateDisplayRegion = 25,

        /// <summary>
        /// Set to 1 to tell the driver to wait for vsync in al_flip_display, or to 2 to force vsync off. The default of 0 means that Allegro
        /// does not try to modify the vsync behavior so it may be on or off. Note that even in the case of 1 or 2 it is possible to override the
        /// vsync behavior in the graphics driver so you should not rely on it. 
        /// </summary>
        Vsync = 26,

        /// <summary>
        /// When queried this returns the maximum size (width as well as height) a bitmap can have for this display. Calls to
        /// <see cref="Al.CreateBitmap()"/> or <see cref="Al.LoadBitmap()"/> for bitmaps larger than this size will fail. It does not apply to
        /// memory bitmaps which always can have arbitrary size (but are slow for drawing).
        /// </summary>
        MaxBitmapSize = 27,

        /// <summary>
        /// Set to 1 if textures used for bitmaps on this display can have a size which is not a power of two. This is mostly useful if you use
        /// Allegro to load textures as otherwise only power-of-two textures will be used internally as bitmap storage.
        /// </summary>
        SupportNpotBitmap = 28,

        /// <summary>
        /// Set to 1 if you can use <see cref="Al.SetTargetBitmap()"/> on bitmaps of this display to draw into them. If this is not the case software
        /// emulation will be used when drawing into display bitmaps (which can be very slow).
        /// </summary>
        CanDrawIntoBitmap = 29,

        /// <summary>
        /// This is set to 1 if the <see cref="Al.SetSeparateBlender()"/> function is supported. Otherwise the alpha parameters will be ignored.
        /// </summary>
        SupportSeparateAlpha = 30,

        /// <summary>
        /// This is on by default. It causes any existing memory bitmaps with the <see cref="BitmapFlags.AutoConvertBitmaps"/> flag to be converted
        /// to a display bitmap of the newly created display with the option set.
        /// </summary>
        AutoConvertBitmaps = 31,

        /// <summary>
        /// This is a bit-combination of the orientations supported by the application. The orientations are the same as for
        /// <see cref="Al.GetDisplayOrientation()"/> with the additional possibilities:
        /// <para><see cref="DisplayOrientation.Portrait"/></para>
        /// <para><see cref="DisplayOrientation.Landscape"/></para>
        /// <para><see cref="DisplayOrientation.All"/></para>
        /// <para>
        /// <see cref="DisplayOrientation.Portrait"/> means only the two portrait orientations are supported,
        /// <see cref="DisplayOrientation.Landscape"/> means only the two landscape orientations and <see cref="DisplayOrientation.All"/> allows all
        /// four orientations. When the orientation changes between a portrait and a landscape orientation the display needs to be resized. This is
        /// done by sending an <see cref="EventType.DisplayResize"/> message which should be handled by calling <see cref="Al.AcknowledgeResize()"/>.
        /// </para>
        /// </summary>
        SupportedOrientations = 32,

        /// <summary>
        /// Request a specific OpenGL major version.
        /// </summary>
        OpenGLMajorVersion = 33,

        /// <summary>
        /// Request a specific OpenGL minor version.
        /// </summary>
        OpenGLMinorVersion = 34,

        /// <summary>
        /// Value is equal to the amount of display options.
        /// </summary>
        DisplayOptionsCount
    }
}
